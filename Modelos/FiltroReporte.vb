''' <summary>
''' Parametros de entrada de un reporte. Un solo objeto agrupa
''' fechas, socio, instructor, sala, metodo y opciones; los
''' formularios y el ReporteDAO lo usan para no repetir firmas.
''' </summary>
Public Class FiltroReporte

    Public Property IdSocio As Integer?
    Public Property IdInstructor As Integer?
    Public Property IdSala As Integer?

    Public Property FechaDesde As Date = New Date(DateTime.Today.Year, 1, 1)
    Public Property FechaHasta As Date = DateTime.Today

    ''' <summary>Vacio o "Todos" significa sin filtro por metodo.</summary>
    Public Property Metodo As String = ""

    Public Property DiasAdelante As Integer = 7
    Public Property DiasAtras As Integer = 15
    Public Property SoloConSaldo As Boolean = False

    Public Property Anio As Integer = DateTime.Today.Year
    Public Property Mes As Integer = DateTime.Today.Month
    Public Property IncluirAlDia As Boolean = False

    Public Sub New()
    End Sub

    Public Sub New(
        desde As Date,
        hasta As Date,
        Optional metodo As String = ""
    )
        FechaDesde = desde
        FechaHasta = hasta
        Me.Metodo = If(metodo, "")
    End Sub

    Public Function FechaDesdeSql() As Date

        Return FechaDesde.Date

    End Function

    Public Function FechaHastaSql() As Date

        Return FechaHasta.Date

    End Function

    Public Function MetodoSql() As String

        If String.IsNullOrWhiteSpace(Metodo) OrElse
           String.Equals(Metodo, "Todos", StringComparison.OrdinalIgnoreCase) Then

            Return ""

        End If

        Return Metodo.Trim()

    End Function

End Class
