Imports System.Data
Imports System.Globalization
Imports ClosedXML.Excel

''' <summary>
''' R09 · Libro de ingresos anual en Excel (ClosedXML).
''' Una hoja por mes con los pagos del año en una tabla de Excel,
''' total que excluye anulados, y una hoja «Resumen» con fórmulas
''' SUMIFS que leen cada hoja mensual. La hoja Resumen queda
''' protegida y en la primera posición.
''' </summary>
Public Class ExcelLibroAnual

    Private Const ColFecha As Integer = 1
    Private Const ColRecibo As Integer = 2
    Private Const ColSocio As Integer = 3
    Private Const ColPlan As Integer = 4
    Private Const ColMetodo As Integer = 5
    Private Const ColMonto As Integer = 6
    Private Const ColAnulado As Integer = 7

    Private Shared ReadOnly Azul As XLColor =
        XLColor.FromHtml("#193D88")

    Private Shared ReadOnly AzulClaro As XLColor =
        XLColor.FromHtml("#D9E2F3")

    Private Shared ReadOnly Verde As XLColor =
        XLColor.FromHtml("#1E7B34")

    Private Shared ReadOnly Rojo As XLColor =
        XLColor.FromHtml("#B42318")

    ''' <summary>Nombres usados como nombre de hoja y en las fórmulas.</summary>
    Private Shared ReadOnly Meses As String() = {
        "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
    }

    ''' <summary>Nombre ASCII para las tablas de Excel (sin tildes).</summary>
    Private Shared ReadOnly MesesTabla As String() = {
        "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
    }

    ''' <summary>
    ''' Genera el libro del año indicado y devuelve la ruta.
    ''' </summary>
    Public Shared Function Generar(
        anio As Integer,
        ruta As String
    ) As String

        If Not Sesion.PuedeExportarReporte(TipoReporte.R09) Then
            Throw New UnauthorizedAccessException(
                "El usuario actual no tiene permiso para exportar el libro anual.")
        End If

        Dim datos As DataTable = ReporteDAO.ObtenerIngresosAnio(anio)

        Return Generar(datos, anio, ruta)

    End Function

    ''' <summary>
    ''' Variante usada por las pruebas: recibe los datos ya
    ''' consultados y el año del libro.
    ''' </summary>
    Public Shared Function Generar(
        datos As DataTable,
        anio As Integer,
        ruta As String
    ) As String

        If datos Is Nothing Then
            Throw New ArgumentNullException(NameOf(datos))
        End If

        If String.IsNullOrWhiteSpace(ruta) Then
            Throw New ArgumentException("Debe indicar la ruta del archivo.", NameOf(ruta))
        End If

        Using libro As New XLWorkbook()

            Dim ultimasFilas(11) As Integer

            For mes As Integer = 1 To 12

                Dim ultimaFilaDatos As Integer = 4

                ConstruirHojaMes(
                    libro, datos, anio, mes, ultimaFilaDatos
                )

                ' Ultima fila con datos (o 4 si el mes esta vacio).
                ultimasFilas(mes - 1) = Math.Max(ultimaFilaDatos, 4)

            Next

            ConstruirResumen(libro, anio, ultimasFilas)

            libro.Properties.Title = "Libro de ingresos " & anio.ToString()
            libro.Properties.Author = Usuario()
            libro.Properties.Company = "GymControl"

            libro.SaveAs(ruta)

        End Using

        Return ruta

    End Function

    ' =====================================================
    ' HOJA DE UN MES
    ' =====================================================
    Private Shared Function ConstruirHojaMes(
        libro As XLWorkbook,
        datos As DataTable,
        anio As Integer,
        mes As Integer,
        ByRef ultimaFilaDatos As Integer
    ) As IXLWorksheet

        Dim nombreMes As String = NombreMes(mes)
        Dim hoja As IXLWorksheet = libro.Worksheets.Add(nombreMes)

        ' ---------- Titulo ----------
        hoja.Cell(1, 1).Value =
            "GIMNASIO TITÁN · INGRESOS DE " &
            nombreMes.ToUpperInvariant() & " " & anio.ToString()
        hoja.Range(1, 1, 1, ColAnulado).Merge()
        hoja.Range(1, 1, 1, ColAnulado).Style.
            Fill.BackgroundColor = Azul
        hoja.Range(1, 1, 1, ColAnulado).Style.
            Font.FontColor = XLColor.White
        hoja.Range(1, 1, 1, ColAnulado).Style.Font.Bold = True
        hoja.Range(1, 1, 1, ColAnulado).Style.Font.FontSize = 13
        hoja.Range(1, 1, 1, ColAnulado).Style.
            Alignment.Vertical = XLAlignmentVerticalValues.Center
        hoja.Row(1).Height = 26

        ' ---------- Encabezados en la fila 3 ----------
        Dim encabezados As String() = {
            "Fecha", "Recibo", "Socio", "Plan", "Método",
            "Monto C$", "Anulado"
        }

        For indice As Integer = 0 To encabezados.Length - 1
            hoja.Cell(3, indice + 1).Value = encabezados(indice)
        Next

        Dim rangoEncabezado As IXLRange = hoja.Range(3, 1, 3, ColAnulado)
        rangoEncabezado.Style.Fill.BackgroundColor = AzulClaro
        rangoEncabezado.Style.Font.Bold = True
        rangoEncabezado.Style.Font.FontColor = Azul
        rangoEncabezado.Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center
        rangoEncabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        rangoEncabezado.Style.Border.InsideBorder = XLBorderStyleValues.Thin

        ' ---------- Filas del mes ----------
        Dim filas As New List(Of DataRow)()

        For Each registro As DataRow In datos.Rows

            If Not registro.Table.Columns.Contains("fecha") Then Continue For
            If registro.IsNull("fecha") Then Continue For

            Dim fecha As Date =
                Convert.ToDateTime(registro("fecha"), CultureInfo.InvariantCulture)

            If fecha.Year = anio AndAlso fecha.Month = mes Then
                filas.Add(registro)
            End If

        Next

        If filas.Count = 0 Then

            ultimaFilaDatos = 4

            hoja.Cell(5, 1).Value = "Sin pagos registrados"
            hoja.Range(5, 1, 5, ColAnulado).Merge()
            hoja.Range(5, 1, 5, ColAnulado).Style.Font.Italic = True
            hoja.Range(5, 1, 5, ColAnulado).Style.Font.FontColor = XLColor.Gray
            hoja.Range(5, 1, 5, ColAnulado).Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center

        Else

            Dim fila As Integer = 4

            For Each registro As DataRow In filas

                hoja.Cell(fila, ColFecha).Value =
                    Convert.ToDateTime(
                        registro("fecha"),
                        CultureInfo.InvariantCulture
                    )
                hoja.Cell(fila, ColFecha).Style.NumberFormat.Format = "dd/mm/yyyy"

                EscribirTexto(hoja.Cell(fila, ColRecibo), registro, "numero_recibo")
                EscribirTexto(hoja.Cell(fila, ColSocio), registro, "socio")
                EscribirTexto(hoja.Cell(fila, ColPlan), registro, "plan")
                EscribirTexto(hoja.Cell(fila, ColMetodo), registro, "metodo_pago")

                hoja.Cell(fila, ColMonto).Value =
                    Convert.ToDouble(
                        registro("monto"),
                        CultureInfo.InvariantCulture
                    )
                hoja.Cell(fila, ColMonto).Style.NumberFormat.Format =
                    """C$ ""#,##0.00"

                Dim anulado As Integer = 0

                If registro.Table.Columns.Contains("anulado") AndAlso
                   Not registro.IsNull("anulado") Then

                    anulado = Convert.ToInt32(
                        registro("anulado"),
                        CultureInfo.InvariantCulture
                    )

                End If

                hoja.Cell(fila, ColAnulado).Value = If(anulado = 1, "Sí", "No")
                hoja.Cell(fila, ColAnulado).Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center

                fila += 1

            Next

            ultimaFilaDatos = fila - 1

            ' Tabla de Excel: filas alternas, filtro y estilo.
            Dim tabla As IXLTable =
                hoja.Range(3, 1, ultimaFilaDatos, ColAnulado).
                    CreateTable("Tbl" & MesesTabla(mes - 1))

            tabla.Theme = XLTableTheme.TableStyleMedium2
            tabla.SetShowAutoFilter(True)
            tabla.SetShowRowStripes(True)

            ' Total del mes sin pagos anulados.
            Dim filaTotal As Integer = ultimaFilaDatos + 2

            hoja.Cell(filaTotal, ColSocio).Value =
                "Total del mes (sin anulados)"
            hoja.Cell(filaTotal, ColSocio).Style.Font.Bold = True

            hoja.Cell(filaTotal, ColMonto).FormulaA1 =
                "=SUMIFS(F4:F" & ultimaFilaDatos &
                ",G4:G" & ultimaFilaDatos & ",""No"")"
            hoja.Cell(filaTotal, ColMonto).Style.Font.Bold = True
            hoja.Cell(filaTotal, ColMonto).Style.NumberFormat.Format =
                """C$ ""#,##0.00"

            hoja.Range(filaTotal, ColSocio, filaTotal, ColMonto).Style.
                Fill.BackgroundColor = AzulClaro

        End If

        ' ---------- Presentacion ----------
        hoja.SheetView.FreezeRows(3)

        hoja.Column(ColFecha).Width = 12
        hoja.Column(ColRecibo).Width = 11
        hoja.Column(ColSocio).Width = 34
        hoja.Column(ColPlan).Width = 14
        hoja.Column(ColMetodo).Width = 15
        hoja.Column(ColMonto).Width = 14
        hoja.Column(ColAnulado).Width = 10

        hoja.PageSetup.PageOrientation = XLPageOrientation.Portrait
        hoja.PageSetup.PagesWide = 1
        hoja.PageSetup.SetRowsToRepeatAtTop(3, 3)

        Return hoja

    End Function

    ' =====================================================
    ' HOJA RESUMEN
    ' =====================================================
    Private Shared Sub ConstruirResumen(
        libro As XLWorkbook,
        anio As Integer,
        ultimasFilas As Integer()
    )

        Dim resumen As IXLWorksheet = libro.Worksheets.Add("Resumen")

        resumen.Cell(1, 1).Value =
            "RESUMEN ANUAL DE INGRESOS · " & anio.ToString()
        resumen.Range(1, 1, 1, 6).Merge()
        resumen.Range(1, 1, 1, 6).Style.Fill.BackgroundColor = Azul
        resumen.Range(1, 1, 1, 6).Style.Font.FontColor = XLColor.White
        resumen.Range(1, 1, 1, 6).Style.Font.Bold = True
        resumen.Range(1, 1, 1, 6).Style.Font.FontSize = 14
        resumen.Row(1).Height = 28

        resumen.Cell(2, 1).Value =
            "Todas las celdas son fórmulas que leen las hojas mensuales."
        resumen.Range(2, 1, 2, 6).Merge()
        resumen.Range(2, 1, 2, 6).Style.Font.Italic = True
        resumen.Range(2, 1, 2, 6).Style.Font.FontSize = 9
        resumen.Range(2, 1, 2, 6).Style.Font.FontColor = XLColor.Gray

        Dim encabezados As String() = {
            "Mes", "Efectivo", "Tarjeta", "Transferencia",
            "Total", "Variación"
        }

        For indice As Integer = 0 To encabezados.Length - 1
            resumen.Cell(4, indice + 1).Value = encabezados(indice)
        Next

        Dim rangoEncabezado As IXLRange = resumen.Range(4, 1, 4, 6)
        rangoEncabezado.Style.Fill.BackgroundColor = AzulClaro
        rangoEncabezado.Style.Font.Bold = True
        rangoEncabezado.Style.Font.FontColor = Azul
        rangoEncabezado.Style.Alignment.Horizontal =
            XLAlignmentHorizontalValues.Center
        rangoEncabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        rangoEncabezado.Style.Border.InsideBorder = XLBorderStyleValues.Thin

        Dim metodos As String() = {"Efectivo", "Tarjeta", "Transferencia"}

        For mes As Integer = 1 To 12

            Dim fila As Integer = 4 + mes
            Dim nombreHoja As String = NombreMes(mes)
            Dim ultima As Integer = Math.Max(ultimasFilas(mes - 1), 4)

            resumen.Cell(fila, 1).Value = nombreHoja

            For indiceMetodo As Integer = 0 To metodos.Length - 1

                Dim columna As Integer = 2 + indiceMetodo

                resumen.Cell(fila, columna).FormulaA1 =
                    "=SUMIFS('" & nombreHoja & "'!$F$4:$F$" & ultima &
                    ",'" & nombreHoja & "'!$E$4:$E$" & ultima &
                    ",""" & metodos(indiceMetodo) & """" &
                    ",'" & nombreHoja & "'!$G$4:$G$" & ultima &
                    ",""No"")"

                resumen.Cell(fila, columna).Style.NumberFormat.Format =
                    """C$ ""#,##0.00"

            Next

            ' Total del mes = suma de los tres metodos.
            resumen.Cell(fila, 5).FormulaA1 =
                "=SUM(B" & fila & ":D" & fila & ")"
            resumen.Cell(fila, 5).Style.NumberFormat.Format =
                """C$ ""#,##0.00"

            ' Variacion respecto al mes anterior.
            If mes = 1 Then

                resumen.Cell(fila, 6).Value = ""

            Else

                Dim filaAnterior As Integer = fila - 1

                resumen.Cell(fila, 6).FormulaA1 =
                    "=IFERROR((E" & fila & "-E" & filaAnterior & ")/E" &
                    filaAnterior & ","""")"
                resumen.Cell(fila, 6).Style.NumberFormat.Format = "0.00%"

            End If

        Next

        ' ---------- Fila de total anual ----------
        Dim filaTotal As Integer = 17

        resumen.Cell(filaTotal, 1).Value = "TOTAL ANUAL"
        resumen.Cell(filaTotal, 1).Style.Font.Bold = True

        For columna As Integer = 2 To 5

            resumen.Cell(filaTotal, columna).FormulaA1 =
                "=SUM(" & LetraColumna(columna) & "5:" &
                LetraColumna(columna) & "16)"
            resumen.Cell(filaTotal, columna).Style.Font.Bold = True
            resumen.Cell(filaTotal, columna).Style.NumberFormat.Format =
                """C$ ""#,##0.00"

        Next

        Dim rangoTotal As IXLRange = resumen.Range(filaTotal, 1, filaTotal, 6)
        rangoTotal.Style.Fill.BackgroundColor = AzulClaro
        rangoTotal.Style.Border.TopBorder = XLBorderStyleValues.Thin
        rangoTotal.Style.Border.BottomBorder = XLBorderStyleValues.Double

        ' ---------- Formato condicional de la variacion ----------
        Dim rangoVariacion As IXLRange = resumen.Range(6, 6, 16, 6)

        rangoVariacion.AddConditionalFormat().
            WhenGreaterThan(0).
            Font.FontColor = Verde

        rangoVariacion.AddConditionalFormat().
            WhenLessThan(0).
            Font.FontColor = Rojo

        ' Barras de datos sobre el total de cada mes.
        resumen.Range(5, 5, 16, 5).
            AddConditionalFormat().
            DataBar(XLColor.FromHtml("#5B9BD5"), False).
            Minimum(XLCFContentType.Minimum, 0).
            Maximum(XLCFContentType.Maximum, 0)

        resumen.Column(1).Width = 15
        resumen.Column(2).Width = 15
        resumen.Column(3).Width = 15
        resumen.Column(4).Width = 17
        resumen.Column(5).Width = 16
        resumen.Column(6).Width = 12

        resumen.SheetView.FreezeRows(4)

        ' Proteger las formulas del resumen; los meses quedan editables.
        resumen.Protection.Protect()

        ' Resumen en la primera posicion.
        resumen.Position = 1

    End Sub

    ' =====================================================
    ' AUXILIARES
    ' =====================================================
    Private Shared Function NombreMes(mes As Integer) As String

        Try

            Dim cultura As CultureInfo =
                CultureInfo.GetCultureInfo("es-NI")

            Dim nombre As String =
                cultura.DateTimeFormat.GetMonthName(mes)

            If String.IsNullOrWhiteSpace(nombre) Then
                Return Meses(mes - 1)
            End If

            Return Char.ToUpperInvariant(nombre(0)) & nombre.Substring(1)

        Catch

            Return Meses(mes - 1)

        End Try

    End Function

    Private Shared Function LetraColumna(columna As Integer) As String

        If columna <= 0 Then Return "A"
        If columna <= 26 Then Return ChrW(64 + columna).ToString()

        Return ChrW(64 + (columna - 1) \ 26).ToString() &
               ChrW(65 + (columna - 1) Mod 26).ToString()

    End Function

    Private Shared Sub EscribirTexto(
        celda As IXLCell,
        fila As DataRow,
        campo As String
    )

        If Not fila.Table.Columns.Contains(campo) Then Return
        If fila.IsNull(campo) Then Return

        celda.Value = Convert.ToString(fila(campo), CultureInfo.CurrentCulture)

    End Sub

    Private Shared Function Usuario() As String

        Return If(
            String.IsNullOrWhiteSpace(Sesion.NombreUsuario),
            "Sistema",
            Sesion.NombreUsuario
        )

    End Function

End Class
