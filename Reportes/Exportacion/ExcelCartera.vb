Imports System.Data
Imports System.Globalization
Imports ClosedXML.Excel

''' <summary>
''' R07 · Cartera de saldos pendientes en Excel (ClosedXML).
''' Hoja «Cartera» con columnas calculadas por fórmula (saldo,
''' días vencido y categoría), total SUBTOTAL que respeta el
''' autofiltro, formato condicional y hoja «Resumen» que lee la
''' cartera con SUMIF.
''' </summary>
Public Class ExcelCartera

    Private Const FilaTitulo As Integer = 1
    Private Const FilaSubtitulo As Integer = 2
    Private Const FilaEncabezado As Integer = 3
    Private Const FilaDatos As Integer = 4

    Private Const ColCedula As Integer = 1
    Private Const ColSocio As Integer = 2
    Private Const ColTelefono As Integer = 3
    Private Const ColPlan As Integer = 4
    Private Const ColInicio As Integer = 5
    Private Const ColVence As Integer = 6
    Private Const ColPrecio As Integer = 7
    Private Const ColPagado As Integer = 8
    Private Const ColSaldo As Integer = 9
    Private Const ColDias As Integer = 10
    Private Const ColCategoria As Integer = 11

    Private Shared ReadOnly Azul As XLColor =
        XLColor.FromHtml("#193D88")

    Private Shared ReadOnly AzulClaro As XLColor =
        XLColor.FromHtml("#D9E2F3")

    Private Shared ReadOnly GrisClaro As XLColor =
        XLColor.FromHtml("#F2F5FA")

    Private Shared ReadOnly Rojo As XLColor =
        XLColor.FromHtml("#B42318")

    Private Shared ReadOnly Verde As XLColor =
        XLColor.FromHtml("#1E7B34")

    ''' <summary>
    ''' Genera la cartera a partir de los filtros del Centro de
    ''' reportes y devuelve la ruta del archivo.
    ''' </summary>
    Public Shared Function Generar(
        filtro As FiltroReporte,
        ruta As String
    ) As String

        If Not Sesion.PuedeExportarReporte(TipoReporte.R07) Then
            Throw New UnauthorizedAccessException(
                "El usuario actual no tiene permiso para exportar la cartera.")
        End If

        Dim datos As DataTable =
            ReporteDAO.ObtenerCartera(
                If(filtro Is Nothing, False, filtro.IncluirAlDia)
            )

        Return Generar(datos, ruta, DateTime.Today)

    End Function

    ''' <summary>
    ''' Variante usada por las pruebas: recibe los datos ya
    ''' consultados y la fecha de corte.
    ''' </summary>
    Public Shared Function Generar(
        datos As DataTable,
        ruta As String,
        Optional fechaCorte As Date = Nothing
    ) As String

        If datos Is Nothing Then
            Throw New ArgumentNullException(NameOf(datos))
        End If

        If String.IsNullOrWhiteSpace(ruta) Then
            Throw New ArgumentException("Debe indicar la ruta del archivo.", NameOf(ruta))
        End If

        If fechaCorte = Date.MinValue Then fechaCorte = DateTime.Today

        Using libro As New XLWorkbook()

            Dim cartera As IXLWorksheet =
                ConstruirCartera(libro, datos, fechaCorte)

            ConstruirResumen(libro, cartera, datos)

            libro.Properties.Title = "Cartera de saldos pendientes"
            libro.Properties.Author = Usuario()
            libro.Properties.Company = "GymControl"

            libro.SaveAs(ruta)

        End Using

        Return ruta

    End Function

    ' =====================================================
    ' HOJA CARTERA
    ' =====================================================
    Private Shared Function ConstruirCartera(
        libro As XLWorkbook,
        datos As DataTable,
        fechaCorte As Date
    ) As IXLWorksheet

        Dim hoja As IXLWorksheet = libro.Worksheets.Add("Cartera")

        ' ---------- Titulo ----------
        hoja.Cell(FilaTitulo, 1).Value =
            "GIMNASIO TITÁN · CARTERA DE SALDOS PENDIENTES"
        hoja.Range(FilaTitulo, 1, FilaTitulo, ColCategoria).Merge()
        hoja.Range(FilaTitulo, 1, FilaTitulo, ColCategoria).Style.
            Fill.BackgroundColor = Azul
        hoja.Range(FilaTitulo, 1, FilaTitulo, ColCategoria).Style.
            Font.FontColor = XLColor.White
        hoja.Range(FilaTitulo, 1, FilaTitulo, ColCategoria).Style.
            Font.Bold = True
        hoja.Range(FilaTitulo, 1, FilaTitulo, ColCategoria).Style.
            Font.FontSize = 16
        hoja.Range(FilaTitulo, 1, FilaTitulo, ColCategoria).Style.
            Alignment.Vertical = XLAlignmentVerticalValues.Center
        hoja.Row(FilaTitulo).Height = 30

        ' ---------- Subtitulo ----------
        hoja.Cell(FilaSubtitulo, 1).Value =
            "Fecha de corte: " & fechaCorte.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) &
            " · Generado por " & Usuario() &
            " el " & DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture)
        hoja.Range(FilaSubtitulo, 1, FilaSubtitulo, ColCategoria).Merge()
        hoja.Range(FilaSubtitulo, 1, FilaSubtitulo, ColCategoria).Style.
            Font.FontSize = 9
        hoja.Range(FilaSubtitulo, 1, FilaSubtitulo, ColCategoria).Style.
            Font.FontColor = XLColor.Gray
        hoja.Row(FilaSubtitulo).Height = 18

        ' ---------- Encabezados ----------
        Dim encabezados As String() = {
            "Cédula", "Socio", "Teléfono", "Plan", "Inicio", "Vence",
            "Precio C$", "Pagado C$", "Saldo C$", "Días venc.", "Categoría"
        }

        For indice As Integer = 0 To encabezados.Length - 1
            hoja.Cell(FilaEncabezado, indice + 1).Value = encabezados(indice)
        Next

        Dim rangoEncabezado As IXLRange =
            hoja.Range(FilaEncabezado, 1, FilaEncabezado, ColCategoria)

        rangoEncabezado.Style.Fill.BackgroundColor = AzulClaro
        rangoEncabezado.Style.Font.Bold = True
        rangoEncabezado.Style.Font.FontColor = Azul
        rangoEncabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        rangoEncabezado.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
        rangoEncabezado.Style.Alignment.WrapText = True
        rangoEncabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        rangoEncabezado.Style.Border.InsideBorder = XLBorderStyleValues.Thin
        hoja.Row(FilaEncabezado).Height = 24

        ' ---------- Datos ----------
        Dim fila As Integer = FilaDatos

        For Each registro As DataRow In datos.Rows

            EscribirTexto(hoja.Cell(fila, ColCedula), registro, "cedula")
            EscribirTexto(hoja.Cell(fila, ColSocio), registro, "socio")
            EscribirTexto(hoja.Cell(fila, ColTelefono), registro, "telefono")
            EscribirTexto(hoja.Cell(fila, ColPlan), registro, "plan")

            EscribirFecha(hoja.Cell(fila, ColInicio), registro, "fecha_inicio")
            EscribirFecha(hoja.Cell(fila, ColVence), registro, "fecha_vencimiento")

            EscribirMoneda(hoja.Cell(fila, ColPrecio), registro, "precio_pactado")
            EscribirMoneda(hoja.Cell(fila, ColPagado), registro, "pagado")

            ' Saldo, dias y categoria son formulas: si el contador
            ' corrige el precio o un pago, todo se recalcula.
            hoja.Cell(fila, ColSaldo).FormulaA1 =
                "=G" & fila & "-H" & fila
            hoja.Cell(fila, ColSaldo).Style.NumberFormat.Format =
                """C$ ""#,##0.00"

            hoja.Cell(fila, ColDias).FormulaA1 =
                "=IF(TODAY()>F" & fila & ",TODAY()-F" & fila & ",0)"
            hoja.Cell(fila, ColDias).Style.NumberFormat.Format = "0"
            hoja.Cell(fila, ColDias).Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center

            hoja.Cell(fila, ColCategoria).FormulaA1 =
                "=IF(J" & fila & "=0,""Al día""," &
                "IF(J" & fila & "<=30,""1–30""," &
                "IF(J" & fila & "<=60,""31–60"",""Más de 60"")))"

            If (fila - FilaDatos) Mod 2 = 1 Then
                hoja.Range(fila, 1, fila, ColCategoria).Style.
                    Fill.BackgroundColor = GrisClaro
            End If

            fila += 1

        Next

        Dim ultimaFila As Integer = fila - 1
        Dim ultimaFilaFormula As Integer = Math.Max(ultimaFila, FilaDatos)

        ' ---------- Fila de totales con SUBTOTAL ----------
        ' SUBTOTAL(9, ...) suma solo las filas visibles del autofiltro.
        Dim filaTotal As Integer = ultimaFila + 1

        hoja.Cell(filaTotal, ColSocio).Value = "Total visible"
        hoja.Cell(filaTotal, ColSocio).Style.Font.Bold = True

        hoja.Cell(filaTotal, ColPrecio).FormulaA1 =
            "=SUBTOTAL(9,G" & FilaDatos & ":G" & ultimaFilaFormula & ")"
        hoja.Cell(filaTotal, ColPagado).FormulaA1 =
            "=SUBTOTAL(9,H" & FilaDatos & ":H" & ultimaFilaFormula & ")"
        hoja.Cell(filaTotal, ColSaldo).FormulaA1 =
            "=SUBTOTAL(9,I" & FilaDatos & ":I" & ultimaFilaFormula & ")"

        Dim rangoTotal As IXLRange =
            hoja.Range(filaTotal, 1, filaTotal, ColCategoria)

        rangoTotal.Style.Fill.BackgroundColor = AzulClaro
        rangoTotal.Style.Font.Bold = True
        rangoTotal.Style.Border.TopBorder = XLBorderStyleValues.Thin
        rangoTotal.Style.Border.BottomBorder = XLBorderStyleValues.Double
        hoja.Range(filaTotal, ColPrecio, filaTotal, ColSaldo).Style.
            NumberFormat.Format = """C$ ""#,##0.00"

        ' ---------- Formatos ----------
        If ultimaFila >= FilaDatos Then

            Dim rangoDatos As IXLRange =
                hoja.Range(FilaDatos, 1, ultimaFila, ColCategoria)

            rangoDatos.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            rangoDatos.Style.Border.InsideBorder = XLBorderStyleValues.Hair
            rangoDatos.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center

            hoja.Range(FilaDatos, ColPrecio, ultimaFila, ColSaldo).Style.
                NumberFormat.Format = """C$ ""#,##0.00"

            ' Barras de datos sobre el saldo.
            hoja.Range(FilaDatos, ColSaldo, ultimaFila, ColSaldo).
                AddConditionalFormat().
                DataBar(XLColor.FromHtml("#5B9BD5"), False).
                Minimum(XLCFContentType.Minimum, 0).
                Maximum(XLCFContentType.Maximum, 0)

            ' Escala de color sobre los dias vencidos.
            hoja.Range(FilaDatos, ColDias, ultimaFila, ColDias).
                AddConditionalFormat().
                ColorScale().
                LowestValue(XLColor.FromHtml("#C6EFCE")).
                Midpoint(XLCFContentType.Percent, 50, XLColor.FromHtml("#FFEB9C")).
                HighestValue(XLColor.FromHtml("#FFC7CE"))

            ' Saldo pendiente en rojo.
            hoja.Range(FilaDatos, ColSaldo, ultimaFila, ColSaldo).
                AddConditionalFormat().
                WhenGreaterThan(0).
                Font.FontColor = Rojo

            ' Autofiltro sobre los encabezados.
            hoja.Range(FilaEncabezado, 1, ultimaFila, ColCategoria).
                SetAutoFilter()

        End If

        ' ---------- Presentacion ----------
        hoja.SheetView.FreezeRows(FilaEncabezado)

        hoja.Column(ColCedula).Width = 20
        hoja.Column(ColSocio).Width = 34
        hoja.Column(ColTelefono).Width = 14
        hoja.Column(ColPlan).Width = 14
        hoja.Column(ColInicio).Width = 12
        hoja.Column(ColVence).Width = 12
        hoja.Column(ColPrecio).Width = 13
        hoja.Column(ColPagado).Width = 13
        hoja.Column(ColSaldo).Width = 13
        hoja.Column(ColDias).Width = 11
        hoja.Column(ColCategoria).Width = 13

        hoja.PageSetup.PageOrientation = XLPageOrientation.Landscape
        hoja.PageSetup.PagesWide = 1
        hoja.PageSetup.SetRowsToRepeatAtTop(FilaEncabezado, FilaEncabezado)

        Return hoja

    End Function

    ' =====================================================
    ' HOJA RESUMEN
    ' =====================================================
    Private Shared Sub ConstruirResumen(
        libro As XLWorkbook,
        cartera As IXLWorksheet,
        datos As DataTable
    )

        Dim resumen As IXLWorksheet = libro.Worksheets.Add("Resumen")

        resumen.Cell(1, 1).Value = "RESUMEN DE CARTERA POR CATEGORÍA"
        resumen.Range(1, 1, 1, 3).Merge()
        resumen.Range(1, 1, 1, 3).Style.Fill.BackgroundColor = Azul
        resumen.Range(1, 1, 1, 3).Style.Font.FontColor = XLColor.White
        resumen.Range(1, 1, 1, 3).Style.Font.Bold = True
        resumen.Range(1, 1, 1, 3).Style.Font.FontSize = 14
        resumen.Row(1).Height = 26

        resumen.Cell(2, 1).Value =
            "Las cifras se recalculan con fórmulas sobre la hoja Cartera."
        resumen.Range(2, 1, 2, 3).Merge()
        resumen.Range(2, 1, 2, 3).Style.Font.Italic = True
        resumen.Range(2, 1, 2, 3).Style.Font.FontSize = 9
        resumen.Range(2, 1, 2, 3).Style.Font.FontColor = XLColor.Gray

        Dim encabezados As String() = {"Categoría", "Membresías", "Saldo C$"}

        For indice As Integer = 0 To encabezados.Length - 1
            resumen.Cell(4, indice + 1).Value = encabezados(indice)
        Next

        Dim rangoEncabezado As IXLRange = resumen.Range(4, 1, 4, 3)
        rangoEncabezado.Style.Fill.BackgroundColor = AzulClaro
        rangoEncabezado.Style.Font.Bold = True
        rangoEncabezado.Style.Font.FontColor = Azul
        rangoEncabezado.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
        rangoEncabezado.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
        rangoEncabezado.Style.Border.InsideBorder = XLBorderStyleValues.Thin

        Dim categorias As String() = {
            "Al día", "1–30", "31–60", "Más de 60"
        }

        Dim ultimaFilaCartera As Integer =
            Math.Max(
                FilaDatos + Math.Max(datos.Rows.Count - 1, 0),
                FilaDatos
            )

        Dim fila As Integer = 5

        For Each categoria As String In categorias

            resumen.Cell(fila, 1).Value = categoria

            resumen.Cell(fila, 2).FormulaA1 =
                "=COUNTIF(Cartera!$K$" & FilaDatos & ":$K$" &
                ultimaFilaCartera & ",A" & fila & ")"

            resumen.Cell(fila, 3).FormulaA1 =
                "=SUMIF(Cartera!$K$" & FilaDatos & ":$K$" &
                ultimaFilaCartera & ",A" & fila &
                ",Cartera!$I$" & FilaDatos & ":$I$" &
                ultimaFilaCartera & ")"

            resumen.Cell(fila, 3).Style.NumberFormat.Format =
                """C$ ""#,##0.00"

            fila += 1

        Next

        Dim filaTotal As Integer = fila

        resumen.Cell(filaTotal, 1).Value = "TOTAL"
        resumen.Cell(filaTotal, 2).FormulaA1 =
            "=SUM(B5:B" & (filaTotal - 1) & ")"
        resumen.Cell(filaTotal, 3).FormulaA1 =
            "=SUM(C5:C" & (filaTotal - 1) & ")"
        resumen.Cell(filaTotal, 3).Style.NumberFormat.Format =
            """C$ ""#,##0.00"

        Dim rangoTotal As IXLRange = resumen.Range(filaTotal, 1, filaTotal, 3)
        rangoTotal.Style.Fill.BackgroundColor = AzulClaro
        rangoTotal.Style.Font.Bold = True
        rangoTotal.Style.Border.TopBorder = XLBorderStyleValues.Thin
        rangoTotal.Style.Border.BottomBorder = XLBorderStyleValues.Double

        ' Barras de datos sobre el saldo por categoria.
        resumen.Range(5, 3, filaTotal - 1, 3).
            AddConditionalFormat().
            DataBar(XLColor.FromHtml("#ED7D31"), False).
            Minimum(XLCFContentType.Minimum, 0).
            Maximum(XLCFContentType.Maximum, 0)

        resumen.Range(5, 3, filaTotal - 1, 3).
            AddConditionalFormat().
            WhenGreaterThan(0).
            Font.FontColor = Rojo

        resumen.Column(1).Width = 18
        resumen.Column(2).Width = 16
        resumen.Column(3).Width = 18

        ' Proteger el resumen: las formulas no se borran por accidente.
        resumen.Protection.Protect()

        ' El resumen va primero, como pide la propuesta.
        resumen.Position = 1

    End Sub

    ' =====================================================
    ' AUXILIARES
    ' =====================================================
    Private Shared Sub EscribirTexto(
        celda As IXLCell,
        fila As DataRow,
        campo As String
    )

        If Not fila.Table.Columns.Contains(campo) Then Return
        If fila.IsNull(campo) Then Return

        celda.Value = Convert.ToString(fila(campo), CultureInfo.CurrentCulture)

    End Sub

    Private Shared Sub EscribirFecha(
        celda As IXLCell,
        fila As DataRow,
        campo As String
    )

        If Not fila.Table.Columns.Contains(campo) Then Return
        If fila.IsNull(campo) Then Return

        celda.Value = Convert.ToDateTime(fila(campo), CultureInfo.InvariantCulture)
        celda.Style.NumberFormat.Format = "dd/mm/yyyy"

    End Sub

    Private Shared Sub EscribirMoneda(
        celda As IXLCell,
        fila As DataRow,
        campo As String
    )

        If Not fila.Table.Columns.Contains(campo) Then Return
        If fila.IsNull(campo) Then Return

        celda.Value = Convert.ToDouble(fila(campo), CultureInfo.InvariantCulture)
        celda.Style.NumberFormat.Format = """C$ ""#,##0.00"

    End Sub

    Private Shared Function Usuario() As String

        Return If(
            String.IsNullOrWhiteSpace(Sesion.NombreUsuario),
            "Sistema",
            Sesion.NombreUsuario
        )

    End Function

End Class
