''' <summary>
''' Metadatos del catalogo de reportes R01-R09: nombre,
''' descripcion, herramienta y nombres de archivo sugeridos.
''' Un solo lugar para que el Centro, los visores y los
''' exportadores hablen el mismo idioma.
''' </summary>
Public Module ReporteUtilidades

    Public Function Codigo(reporte As TipoReporte) As String

        Select Case reporte
            Case TipoReporte.R01 : Return "R01"
            Case TipoReporte.R02 : Return "R02"
            Case TipoReporte.R03 : Return "R03"
            Case TipoReporte.R04 : Return "R04"
            Case TipoReporte.R05 : Return "R05"
            Case TipoReporte.R06 : Return "R06"
            Case TipoReporte.R07 : Return "R07"
            Case TipoReporte.R08 : Return "R08"
            Case TipoReporte.R09 : Return "R09"
            Case Else : Return ""
        End Select

    End Function

    Public Function DesdeCodigo(codigo As String) As TipoReporte?

        Select Case (codigo & "").Trim().ToUpperInvariant()
            Case "R01" : Return TipoReporte.R01
            Case "R02" : Return TipoReporte.R02
            Case "R03" : Return TipoReporte.R03
            Case "R04" : Return TipoReporte.R04
            Case "R05" : Return TipoReporte.R05
            Case "R06" : Return TipoReporte.R06
            Case "R07" : Return TipoReporte.R07
            Case "R08" : Return TipoReporte.R08
            Case "R09" : Return TipoReporte.R09
            Case Else : Return Nothing
        End Select

    End Function

    Public Function NombreReporte(reporte As TipoReporte) As String

        Select Case reporte
            Case TipoReporte.R01 : Return "R01 · Recibo de pago"
            Case TipoReporte.R02 : Return "R02 · Constancia de membresía"
            Case TipoReporte.R03 : Return "R03 · Listado de vencimientos"
            Case TipoReporte.R04 : Return "R04 · Ingresos por período"
            Case TipoReporte.R05 : Return "R05 · Estado de cuenta del socio"
            Case TipoReporte.R06 : Return "R06 · Horario semanal y ocupación"
            Case TipoReporte.R07 : Return "R07 · Cartera de saldos pendientes"
            Case TipoReporte.R08 : Return "R08 · Informe gerencial mensual"
            Case TipoReporte.R09 : Return "R09 · Libro de ingresos anual"
            Case Else : Return "Reporte"
        End Select

    End Function

    Public Function DescripcionReporte(reporte As TipoReporte) As String

        Select Case reporte
            Case TipoReporte.R01
                Return "Ticket de 80 mm con número de recibo, período, " &
                       "abono, monto en letras, saldo y usuario que atendió."

            Case TipoReporte.R02
                Return "Constancia formal de la membresía activa, con " &
                       "párrafo ajustado, tabla de datos, fecha en letras y firma."

            Case TipoReporte.R03
                Return "Socios que vencen en los próximos días o vencieron " &
                       "recientemente. Incluye teléfono, saldo y columna Llamada."

            Case TipoReporte.R04
                Return "Pagos válidos agrupados por día y por método, con " &
                       "subtotales, total general y pagos anulados aparte."

            Case TipoReporte.R05
                Return "Membresías del socio con sus pagos, incluidos los " &
                       "anulados, saldo por membresía y saldo total."

            Case TipoReporte.R06
                Return "Matriz de clases por hora y día, con actividad, " &
                       "instructor, sala y horas semanales por sala/instructor."

            Case TipoReporte.R07
                Return "Cartera en Excel con fórmulas de saldo y días vencido, " &
                       "categorías, total SUBTOTAL, filtro y hoja Resumen."

            Case TipoReporte.R08
                Return "Informe gerencial en PDF con indicadores del mes, " &
                       "ingresos por plan, saldos altos y horas por instructor."

            Case TipoReporte.R09
                Return "Libro anual en Excel con una hoja por mes, tablas, " &
                       "totales sin anulados y Resumen con fórmulas."

            Case Else
                Return ""
        End Select

    End Function

    Public Function Herramienta(reporte As TipoReporte) As String

        Select Case reporte
            Case TipoReporte.R01, TipoReporte.R02, TipoReporte.R03
                Return "PrintDocument"
            Case TipoReporte.R04, TipoReporte.R05, TipoReporte.R06
                Return "ReportViewer + RDLC"
            Case TipoReporte.R07, TipoReporte.R09
                Return "ClosedXML"
            Case TipoReporte.R08
                Return "QuestPDF"
            Case Else
                Return ""
        End Select

    End Function

    ''' <summary>
    ''' Extension que debe usar el archivo de cada reporte.
    ''' </summary>
    Public Function ExtensionReporte(reporte As TipoReporte) As String

        Select Case reporte
            Case TipoReporte.R07, TipoReporte.R09 : Return "xlsx"
            Case TipoReporte.R08 : Return "pdf"
            Case Else : Return "pdf"
        End Select

    End Function

    ''' <summary>
    ''' Nombre sugerido del archivo de salida. Ejemplos del
    ''' enunciado: Cartera_2026-10-18.xlsx, Ingresos_2026.xlsx.
    ''' </summary>
    Public Function NombreArchivo(
        reporte As TipoReporte,
        Optional fecha As Date? = Nothing,
        Optional anio As Integer = 0,
        Optional mes As Integer = 0
    ) As String

        Dim hoy As Date = If(fecha.HasValue, fecha.Value, DateTime.Today)
        Dim extension As String = ExtensionReporte(reporte)

        Select Case reporte

            Case TipoReporte.R07
                Return "Cartera_" & hoy.ToString("yyyy-MM-dd") & "." & extension

            Case TipoReporte.R08
                Dim anioInforme As Integer = If(anio > 0, anio, hoy.Year)
                Dim mesInforme As Integer = If(mes > 0, mes, hoy.Month)
                Return "Informe_" & anioInforme.ToString("0000") &
                       "-" & mesInforme.ToString("00") & "." & extension

            Case TipoReporte.R09
                Dim anioLibro As Integer = If(anio > 0, anio, hoy.Year)
                Return "Ingresos_" & anioLibro.ToString("0000") & "." & extension

            Case TipoReporte.R01
                Return "Recibo_" & hoy.ToString("yyyyMMdd") & "." & extension

            Case TipoReporte.R02
                Return "Constancia_" & hoy.ToString("yyyyMMdd") & "." & extension

            Case TipoReporte.R03
                Return "Vencimientos_" & hoy.ToString("yyyyMMdd") & "." & extension

            Case TipoReporte.R04
                Return "Ingresos_" & hoy.ToString("yyyyMMdd") & "." & extension

            Case TipoReporte.R05
                Return "EstadoCuenta_" & hoy.ToString("yyyyMMdd") & "." & extension

            Case TipoReporte.R06
                Return "Horario_" & hoy.ToString("yyyyMMdd") & "." & extension

            Case Else
                Return "Reporte." & extension

        End Select

    End Function

    ''' <summary>
    ''' Lista completa en el orden del catalogo. El Centro la filtra
    ''' con Sesion.PuedeVerReporte.
    ''' </summary>
    Public Function Catalogo() As TipoReporte()

        Return New TipoReporte() {
            TipoReporte.R01,
            TipoReporte.R02,
            TipoReporte.R03,
            TipoReporte.R04,
            TipoReporte.R05,
            TipoReporte.R06,
            TipoReporte.R07,
            TipoReporte.R08,
            TipoReporte.R09
        }

    End Function

    Public Function Grupo(reporte As TipoReporte) As String

        Select Case reporte
            Case TipoReporte.R01, TipoReporte.R02, TipoReporte.R03
                Return "Impresión directa"
            Case TipoReporte.R04, TipoReporte.R05, TipoReporte.R06
                Return "Reportes en visor"
            Case TipoReporte.R07, TipoReporte.R08, TipoReporte.R09
                Return "Archivos"
            Case Else
                Return "Reportes"
        End Select

    End Function

    Public Function NombreArchivo(
        reporte As TipoReporte,
        extension As String
    ) As String

        Dim nombre As String = NombreArchivo(reporte)
        Return IO.Path.ChangeExtension(nombre, extension)

    End Function

End Module
