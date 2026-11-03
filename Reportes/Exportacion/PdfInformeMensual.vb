Imports System.Data
Imports System.Globalization
Imports System.IO
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure

''' <summary>
''' R08 · Informe gerencial mensual en PDF (QuestPDF).
''' Encabezado con logo, cuatro indicadores del mes, tabla de
''' ingresos por tipo de membresía, los diez saldos más altos y
''' las horas de clase por instructor. Pie con usuario y
''' «Página x de y».
''' </summary>
Public Class PdfInformeMensual

    Private Shared ReadOnly Azul As Color = Color.FromHex("#193D88")
    Private Shared ReadOnly AzulClaro As Color = Color.FromHex("#E8EDF7")
    Private Shared ReadOnly GrisTexto As Color = Color.FromHex("#4A4A4A")
    Private Shared ReadOnly Rojo As Color = Color.FromHex("#B42318")
    Private Shared ReadOnly GrisFila As Color = Color.FromHex("#F4F6FA")

    Shared Sub New()

        QuestPDF.Settings.License = LicenseType.Community
        QuestPDF.Settings.UseSystemFonts = True

    End Sub

    ''' <summary>
    ''' Consulta los datos del mes y genera el PDF. Devuelve la ruta.
    ''' </summary>
    Public Shared Function Generar(
        anio As Integer,
        mes As Integer,
        ruta As String
    ) As String

        If Not Sesion.PuedeExportarReporte(TipoReporte.R08) Then
            Throw New UnauthorizedAccessException(
                "El usuario actual no tiene permiso para exportar el informe.")
        End If

        Dim indicadores As DataRow =
            ReporteDAO.ObtenerIndicadores(mes, anio)

        Dim porPlan As DataTable =
            ReporteDAO.ObtenerIngresosPorPlan(mes, anio)

        Dim saldos As DataTable =
            ReporteDAO.ObtenerSaldosAltos()

        Dim horas As DataTable =
            ReporteDAO.ObtenerHorasInstructores()

        Return Generar(
            indicadores, porPlan, saldos, horas, anio, mes, ruta
        )

    End Function

    ''' <summary>
    ''' Variante usada por las pruebas: recibe las tablas ya
    ''' consultadas, de modo que la composición no toca la base.
    ''' </summary>
    Public Shared Function Generar(
        indicadores As DataRow,
        porPlan As DataTable,
        saldos As DataTable,
        horas As DataTable,
        anio As Integer,
        mes As Integer,
        ruta As String
    ) As String

        If String.IsNullOrWhiteSpace(ruta) Then
            Throw New ArgumentException("Debe indicar la ruta del archivo.", NameOf(ruta))
        End If

        Dim logo As Byte() = Logo()

        Document.Create(
            Sub(documento)

                documento.Page(
                    Sub(pagina)

                        pagina.Size(PageSizes.Letter)
                        pagina.Margin(1.1F, Unit.Centimetre)
                        pagina.PageColor(Colors.White)

                        pagina.DefaultTextStyle(
                            Function(estilo)
                                Return estilo.
                                    FontSize(9).
                                    FontFamily("Arial").
                                    FontColor(GrisTexto)
                            End Function
                        )

                        pagina.Header().Element(
                            Sub(contenedor)
                                ComponerEncabezado(contenedor, logo, anio, mes)
                            End Sub
                        )

                        pagina.Content().PaddingVertical(10).Element(
                            Sub(contenedor)
                                ComponerContenido(
                                    contenedor, indicadores, porPlan, saldos, horas
                                )
                            End Sub
                        )

                        pagina.Footer().Element(AddressOf ComponerPie)

                    End Sub
                )

            End Sub
        ).GeneratePdf(ruta)

        Return ruta

    End Function

    ' =====================================================
    ' ENCABEZADO
    ' =====================================================
    Private Shared Sub ComponerEncabezado(
        contenedor As IContainer,
        logo As Byte(),
        anio As Integer,
        mes As Integer
    )

        contenedor.Column(
            Sub(columna)

                columna.Item().Row(
                    Sub(fila)

                        If logo IsNot Nothing Then

                            fila.ConstantItem(52).
                                Height(42).
                                Image(logo).
                                FitArea()

                        End If

                        fila.RelativeItem().PaddingLeft(10).Column(
                            Sub(texto)

                                texto.Item().
                                    Text("GIMNASIO TITÁN").
                                    FontSize(18).
                                    Bold().
                                    FontColor(Azul)

                                texto.Item().
                                    Text("Informe gerencial mensual").
                                    FontSize(11).
                                    SemiBold()

                                texto.Item().
                                    Text(NombreMes(mes) & " de " & anio.ToString()).
                                    FontSize(9).
                                    FontColor(Colors.Grey.Darken1)

                            End Sub
                        )

                        fila.ConstantItem(150).AlignRight().Column(
                            Sub(texto)

                                texto.Item().
                                    AlignRight().
                                    Text("Generado: " &
                                         DateTime.Now.ToString("dd/MM/yyyy HH:mm")).
                                    FontSize(8)

                                texto.Item().
                                    AlignRight().
                                    Text("Usuario: " & Usuario()).
                                    FontSize(8)

                            End Sub
                        )

                    End Sub
                )

                columna.Item().
                    PaddingTop(8).
                    LineHorizontal(1.5F).
                    LineColor(Azul)

            End Sub
        )

    End Sub

    ' =====================================================
    ' CONTENIDO
    ' =====================================================
    Private Shared Sub ComponerContenido(
        contenedor As IContainer,
        indicadores As DataRow,
        porPlan As DataTable,
        saldos As DataTable,
        horas As DataTable
    )

        contenedor.Column(
            Sub(columna)

                ' ---------- Indicadores ----------
                ComponerIndicadores(columna, indicadores)

                ' ---------- Ingresos por plan ----------
                columna.Item().PaddingTop(16).Element(
                    Sub(bloque)
                        ComponerTablaPlanes(bloque, porPlan)
                    End Sub
                )

                ' ---------- Saldos mas altos ----------
                columna.Item().PaddingTop(16).Element(
                    Sub(bloque)
                        ComponerTablaSaldos(bloque, saldos)
                    End Sub
                )

                ' ---------- Horas por instructor ----------
                columna.Item().PaddingTop(16).Element(
                    Sub(bloque)
                        ComponerTablaHoras(bloque, horas)
                    End Sub
                )

            End Sub
        )

    End Sub

    Private Shared Sub ComponerIndicadores(
        columna As ColumnDescriptor,
        indicadores As DataRow
    )

        Dim socios As String = Entero(indicadores, "socios_activos").ToString("N0")
        Dim nuevas As String = Entero(indicadores, "nuevas_membresias").ToString("N0")
        Dim ingresos As String = Monto(Decimal(indicadores, "ingresos_mes"))
        Dim porCobrar As String = Monto(Decimal(indicadores, "por_cobrar"))

        columna.Item().Row(
            Sub(fila)

                AgregarIndicador(fila, "Socios activos", socios)
                AgregarIndicador(fila, "Nuevas membresías", nuevas)
                AgregarIndicador(fila, "Ingresos del mes", ingresos)
                AgregarIndicador(fila, "Saldo por cobrar", porCobrar)

            End Sub
        )

    End Sub

    Private Shared Sub AgregarIndicador(
        fila As RowDescriptor,
        etiqueta As String,
        valor As String
    )

        fila.RelativeItem().
            Padding(3).
            Background(AzulClaro).
            Border(1).
            BorderColor(Color.FromHex("#C9D5EA")).
            PaddingVertical(8).
            PaddingHorizontal(10).
            Column(
                Sub(bloque)

                    bloque.Item().
                        Text(etiqueta).
                        FontSize(8).
                        FontColor(Colors.Grey.Darken1)

                    bloque.Item().
                        PaddingTop(2).
                        Text(valor).
                        FontSize(14).
                        Bold().
                        FontColor(Azul)

                End Sub
            )

    End Sub

    ' =====================================================
    ' TABLAS
    ' =====================================================
    Private Shared Sub ComponerTablaPlanes(
        contenedor As IContainer,
        datos As DataTable
    )

        Dim filas As New List(Of String())
        Dim totalVendidas As Integer = 0
        Dim totalIngresos As Decimal = 0D

        If datos IsNot Nothing Then

            For Each registro As DataRow In datos.Rows

                Dim vendidas As Integer = Entero(registro, "vendidas")
                Dim ingresos As Decimal = Decimal(registro, "ingresos")

                totalVendidas += vendidas
                totalIngresos += ingresos

                filas.Add(
                    New String() {
                        Texto(registro, "plan"),
                        vendidas.ToString("N0"),
                        Monto(ingresos)
                    }
                )

            Next

        End If

        If filas.Count > 0 Then
            filas.Add(
                New String() {
                    "TOTAL", totalVendidas.ToString("N0"), Monto(totalIngresos)
                }
            )
        End If

        ComponerTabla(
            contenedor,
            "Ingresos por tipo de membresía",
            New String() {"Plan", "Vendidas", "Ingresos C$"},
            New Single() {3.2F, 1.2F, 1.8F},
            New Boolean() {False, True, True},
            filas
        )

    End Sub

    Private Shared Sub ComponerTablaSaldos(
        contenedor As IContainer,
        datos As DataTable
    )

        Dim filas As New List(Of String())

        If datos IsNot Nothing Then

            For Each registro As DataRow In datos.Rows

                Dim saldo As Decimal = Decimal(registro, "saldo")
                Dim dias As Integer = Entero(registro, "dias_vencido")

                filas.Add(
                    New String() {
                        Texto(registro, "socio"),
                        Texto(registro, "cedula"),
                        Texto(registro, "plan"),
                        Fecha(registro, "fecha_vencimiento"),
                        Monto(saldo),
                        dias.ToString("N0")
                    }
                )

            Next

        End If

        ComponerTabla(
            contenedor,
            "Diez saldos más altos",
            New String() {
                "Socio", "Cédula", "Plan", "Vence", "Saldo C$", "Días venc."
            },
            New Single() {3.4F, 1.7F, 1.2F, 1.2F, 1.5F, 1.0F},
            New Boolean() {False, False, False, False, True, True},
            filas
        )

    End Sub

    Private Shared Sub ComponerTablaHoras(
        contenedor As IContainer,
        datos As DataTable
    )

        Dim filas As New List(Of String())
        Dim totalClases As Integer = 0
        Dim totalHoras As Decimal = 0D

        If datos IsNot Nothing Then

            For Each registro As DataRow In datos.Rows

                Dim clases As Integer = Entero(registro, "clases")
                Dim horasClase As Decimal = Decimal(registro, "horas")

                totalClases += clases
                totalHoras += horasClase

                filas.Add(
                    New String() {
                        Texto(registro, "instructor"),
                        clases.ToString("N0"),
                        horasClase.ToString("N2")
                    }
                )

            Next

        End If

        If filas.Count > 0 Then
            filas.Add(
                New String() {
                    "TOTAL", totalClases.ToString("N0"), totalHoras.ToString("N2")
                }
            )
        End If

        ComponerTabla(
            contenedor,
            "Horas de clase por instructor",
            New String() {"Instructor", "Clases", "Horas semanales"},
            New Single() {3.4F, 1.4F, 1.8F},
            New Boolean() {False, True, True},
            filas
        )

    End Sub

    Private Shared Sub ComponerTabla(
        contenedor As IContainer,
        titulo As String,
        encabezados As String(),
        anchos As Single(),
        alinearDerecha As Boolean(),
        filas As List(Of String())
    )

        contenedor.Column(
            Sub(columna)

                columna.Item().
                    Text(titulo).
                    FontSize(11).
                    Bold().
                    FontColor(Azul)

                columna.Item().PaddingTop(3).LineHorizontal(1).
                    LineColor(Color.FromHex("#C9D5EA"))

                If filas.Count = 0 Then

                    columna.Item().
                        PaddingTop(8).
                        PaddingBottom(4).
                        Text("Sin datos para el período.").
                        Italic().
                        FontColor(Colors.Grey.Medium)

                    Return

                End If

                columna.Item().PaddingTop(5).Table(
                    Sub(tabla)

                        tabla.ColumnsDefinition(
                            Sub(definicion)
                                For Each ancho As Single In anchos
                                    definicion.RelativeColumn(ancho)
                                Next
                            End Sub
                        )

                        tabla.Header(
                            Sub(encabezado)

                                For indice As Integer = 0 To encabezados.Length - 1

                                    Dim celda As IContainer =
                                        encabezado.Cell().
                                            Background(Azul).
                                            PaddingVertical(5).
                                            PaddingHorizontal(5)

                                    If alinearDerecha(indice) Then
                                        celda = celda.AlignRight()
                                    End If

                                    celda.Text(encabezados(indice)).
                                        FontSize(8).
                                        Bold().
                                        FontColor(Colors.White)

                                Next

                            End Sub
                        )

                        Dim numeroFila As Integer = 0

                        For Each valores As String() In filas

                            Dim esTotal As Boolean =
                                valores.Length > 0 AndAlso
                                String.Equals(valores(0), "TOTAL", StringComparison.Ordinal)

                            Dim fondo As Color =
                                If(esTotal, AzulClaro,
                                   If(numeroFila Mod 2 = 0, Colors.White, GrisFila))

                            For indice As Integer = 0 To valores.Length - 1

                                Dim celda As IContainer =
                                    tabla.Cell().
                                        Background(fondo).
                                        BorderBottom(0.5F).
                                        BorderColor(Color.FromHex("#D7DCE6")).
                                        PaddingVertical(4).
                                        PaddingHorizontal(5)

                                If alinearDerecha(indice) Then
                                    celda = celda.AlignRight()
                                End If

                                If esTotal Then

                                    celda.Text(valores(indice)).
                                        FontSize(8).
                                        Bold().
                                        FontColor(Azul)

                                ElseIf indice = valores.Length - 1 AndAlso
                                       EsColumnaDias(encabezados(indice)) AndAlso
                                       valores(indice).StartsWith("-") Then

                                    celda.Text(valores(indice)).
                                        FontSize(8).
                                        FontColor(Rojo)

                                Else

                                    celda.Text(valores(indice)).FontSize(8)

                                End If

                            Next

                            numeroFila += 1

                        Next

                    End Sub
                )

            End Sub
        )

    End Sub

    ' =====================================================
    ' PIE
    ' =====================================================
    Private Shared Sub ComponerPie(contenedor As IContainer)

        contenedor.Column(
            Sub(columna)

                columna.Item().
                    PaddingBottom(4).
                    LineHorizontal(0.5F).
                    LineColor(Color.FromHex("#C9D5EA"))

                columna.Item().Row(
                    Sub(fila)

                        fila.RelativeItem().
                            Text("Generado por " & Usuario() & " · " &
                                 DateTime.Now.ToString("dd/MM/yyyy HH:mm")).
                            FontSize(7).
                            FontColor(Colors.Grey.Medium)

                        fila.ConstantItem(90).AlignRight().Text(
                            Sub(texto)

                                texto.DefaultTextStyle(
                                    Function(estilo)
                                        Return estilo.
                                            FontSize(7).
                                            FontColor(Colors.Grey.Medium)
                                    End Function
                                )

                                texto.Span("Página ")
                                texto.CurrentPageNumber()
                                texto.Span(" de ")
                                texto.TotalPages()

                            End Sub
                        )

                    End Sub
                )

            End Sub
        )

    End Sub

    ' =====================================================
    ' AUXILIARES
    ' =====================================================
    Private Shared Function Logo() As Byte()

        Using flujo As Stream =
            RecursosReportes.AbrirRecurso(RecursosReportes.LogoAzul)

            If flujo Is Nothing Then Return Nothing

            Using memoria As New MemoryStream()
                flujo.CopyTo(memoria)
                Return memoria.ToArray()
            End Using

        End Using

    End Function

    Private Shared Function NombreMes(mes As Integer) As String

        Dim nombre As String = NumeroALetras.NombreMes(mes)

        If String.IsNullOrWhiteSpace(nombre) Then Return mes.ToString()

        Return Char.ToUpperInvariant(nombre(0)) & nombre.Substring(1)

    End Function

    Private Shared Function EsColumnaDias(encabezado As String) As Boolean

        Return encabezado.IndexOf("Días", StringComparison.OrdinalIgnoreCase) >= 0

    End Function

    Private Shared Function Usuario() As String

        Return If(
            String.IsNullOrWhiteSpace(Sesion.NombreUsuario),
            "Sistema",
            Sesion.NombreUsuario
        )

    End Function

    Private Shared Function Texto(fila As DataRow, campo As String) As String

        If fila Is Nothing Then Return ""
        If Not fila.Table.Columns.Contains(campo) Then Return ""
        If fila.IsNull(campo) Then Return ""

        Return Convert.ToString(fila(campo), CultureInfo.CurrentCulture)

    End Function

    Private Shared Function Entero(fila As DataRow, campo As String) As Integer

        If fila Is Nothing Then Return 0
        If Not fila.Table.Columns.Contains(campo) Then Return 0
        If fila.IsNull(campo) Then Return 0

        Return Convert.ToInt32(fila(campo), CultureInfo.InvariantCulture)

    End Function

    Private Shared Function Decimal(fila As DataRow, campo As String) As Decimal

        If fila Is Nothing Then Return 0D
        If Not fila.Table.Columns.Contains(campo) Then Return 0D
        If fila.IsNull(campo) Then Return 0D

        Return Convert.ToDecimal(fila(campo), CultureInfo.InvariantCulture)

    End Function

    Private Shared Function Fecha(fila As DataRow, campo As String) As String

        If fila Is Nothing Then Return ""
        If Not fila.Table.Columns.Contains(campo) Then Return ""
        If fila.IsNull(campo) Then Return ""

        Return Convert.ToDateTime(
            fila(campo),
            CultureInfo.InvariantCulture
        ).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)

    End Function

    Private Shared Function Monto(valor As Decimal) As String

        Return "C$ " & valor.ToString("N2", CultureInfo.CurrentCulture)

    End Function

End Class
