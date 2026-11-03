Imports System.Data
Imports MySqlConnector

''' <summary>
''' Capa de datos del modulo de reportes. Consulta exclusivamente
''' las cuatro vistas de Database\reportes_vistas.sql con el
''' usuario de solo lectura gym_reportes. Ningun formulario
''' contiene SQL: todos pasan por aqui.
''' </summary>
Public Class ReporteDAO

    ' =====================================================
    ' R01 · RECIBO
    ' =====================================================
    Public Shared Function ObtenerRecibo(idPago As Integer) As DataTable

        Dim sql As String =
            "SELECT * FROM vw_ingresos_detalle " &
            "WHERE id_pago = @id_pago"

        Return Consultar(
            sql,
            New MySqlParameter("@id_pago", idPago)
        )

    End Function

    ' =====================================================
    ' R02 · CONSTANCIA
    ' =====================================================
    Public Shared Function ObtenerConstancia(
        idMembresia As Integer
    ) As DataTable

        Dim sql As String =
            "SELECT * FROM vw_saldos_membresia " &
            "WHERE id_membresia = @id_membresia"

        Return Consultar(
            sql,
            New MySqlParameter("@id_membresia", idMembresia)
        )

    End Function

    ' =====================================================
    ' R03 · VENCIMIENTOS
    ' =====================================================
    Public Shared Function ObtenerVencimientos(
        diasAdelante As Integer,
        diasAtras As Integer,
        soloConSaldo As Boolean
    ) As DataTable

        Dim sql As String =
            "SELECT id_membresia, cedula, socio, telefono, plan, " &
            "       fecha_inicio, fecha_vencimiento, " &
            "       dias_restantes AS dias, " &
            "       precio_pactado, pagado, saldo, estado, estado_real " &
            "FROM vw_saldos_membresia " &
            "WHERE estado_real <> 'Cancelada' " &
            "  AND dias_restantes BETWEEN -@dias_atras AND @dias_adelante " &
            "  AND (@solo_con_saldo = 0 OR saldo > 0) " &
            "ORDER BY fecha_vencimiento, socio"

        Return Consultar(
            sql,
            New MySqlParameter("@dias_atras", Math.Max(0, diasAtras)),
            New MySqlParameter("@dias_adelante", Math.Max(0, diasAdelante)),
            New MySqlParameter("@solo_con_saldo", If(soloConSaldo, 1, 0))
        )

    End Function

    ' =====================================================
    ' R04 · INGRESOS POR PERIODO
    ' =====================================================
    Public Shared Function ObtenerIngresos(
        desde As Date,
        hasta As Date,
        metodo As String
    ) As DataTable

        Dim sql As String =
            "SELECT id_pago, numero_recibo, fecha, hora, periodo, " &
            "       id_socio, cedula, socio, id_membresia, plan, " &
            "       metodo_pago, monto, referencia, anulado, " &
            "       registrado_por " &
            "FROM vw_ingresos_detalle " &
            "WHERE fecha BETWEEN @desde AND @hasta " &
            "  AND anulado = 0 " &
            "  AND (@metodo = '' OR metodo_pago = @metodo) " &
            "ORDER BY fecha, metodo_pago, id_pago"

        Return Consultar(
            sql,
            New MySqlParameter("@desde", desde.Date),
            New MySqlParameter("@hasta", hasta.Date),
            New MySqlParameter("@metodo", If(metodo, "").Trim())
        )

    End Function

    ''' <summary>
    ''' Cantidad y monto de los pagos anulados del período. Se
    ''' muestran en una línea aparte de R04 para no mezclarlos con
    ''' los ingresos válidos.
    ''' </summary>
    Public Shared Function ObtenerAnulados(
        desde As Date,
        hasta As Date
    ) As DataRow

        Dim sql As String =
            "SELECT COUNT(*) AS cantidad, " &
            "       COALESCE(SUM(monto), 0) AS monto " &
            "FROM vw_ingresos_detalle " &
            "WHERE fecha BETWEEN @desde AND @hasta " &
            "  AND anulado = 1"

        Dim tabla As DataTable = Consultar(
            sql,
            New MySqlParameter("@desde", desde.Date),
            New MySqlParameter("@hasta", hasta.Date)
        )

        If tabla.Rows.Count = 0 Then Return Nothing
        Return tabla.Rows(0)

    End Function

    ' =====================================================
    ' R05 · ESTADO DE CUENTA
    ' =====================================================
    Public Shared Function ObtenerEstadoCuenta(
        idSocio As Integer,
        desde As Date
    ) As DataTable

        Dim sql As String =
            "SELECT * FROM vw_estado_cuenta " &
            "WHERE id_socio = @id_socio " &
            "  AND (fecha_inicio >= @desde " &
            "       OR (fecha_pago IS NOT NULL AND fecha_pago >= @desde)) " &
            "ORDER BY fecha_inicio, id_membresia, fecha_pago"

        Return Consultar(
            sql,
            New MySqlParameter("@id_socio", idSocio),
            New MySqlParameter("@desde", desde.Date)
        )

    End Function

    ' =====================================================
    ' R06 · HORARIO SEMANAL
    ' =====================================================
    Public Shared Function ObtenerHorario(
        idInstructor As Integer?,
        idSala As Integer?
    ) As DataTable

        Dim sql As String =
            "SELECT * FROM vw_horario_semanal " &
            "WHERE estado = 'Activo' " &
            "  AND (@id_instructor = 0 OR id_instructor = @id_instructor) " &
            "  AND (@id_sala = 0 OR id_sala = @id_sala) " &
            "ORDER BY hora_inicio, dia_semana, actividad"

        Return Consultar(
            sql,
            New MySqlParameter("@id_instructor", Valor(idInstructor)),
            New MySqlParameter("@id_sala", Valor(idSala))
        )

    End Function

    Public Shared Function ObtenerHorasPorSala(
        idInstructor As Integer?,
        idSala As Integer?
    ) As DataTable

        Dim sql As String =
            "SELECT sala, COUNT(*) AS clases, " &
            "       ROUND(SUM(minutos) / 60, 2) AS horas, " &
            "       MAX(capacidad) AS capacidad " &
            "FROM vw_horario_semanal " &
            "WHERE estado = 'Activo' " &
            "  AND (@id_instructor = 0 OR id_instructor = @id_instructor) " &
            "  AND (@id_sala = 0 OR id_sala = @id_sala) " &
            "GROUP BY sala " &
            "ORDER BY sala"

        Return Consultar(
            sql,
            New MySqlParameter("@id_instructor", Valor(idInstructor)),
            New MySqlParameter("@id_sala", Valor(idSala))
        )

    End Function

    Public Shared Function ObtenerHorasPorInstructor(
        idInstructor As Integer?,
        idSala As Integer?
    ) As DataTable

        Dim sql As String =
            "SELECT instructor, COUNT(*) AS clases, " &
            "       ROUND(SUM(minutos) / 60, 2) AS horas " &
            "FROM vw_horario_semanal " &
            "WHERE estado = 'Activo' " &
            "  AND (@id_instructor = 0 OR id_instructor = @id_instructor) " &
            "  AND (@id_sala = 0 OR id_sala = @id_sala) " &
            "GROUP BY instructor " &
            "ORDER BY instructor"

        Return Consultar(
            sql,
            New MySqlParameter("@id_instructor", Valor(idInstructor)),
            New MySqlParameter("@id_sala", Valor(idSala))
        )

    End Function

    ' =====================================================
    ' COMBOS
    ' =====================================================
    Public Shared Function ObtenerSocios() As DataTable

        Dim sql As String =
            "SELECT DISTINCT id_socio, cedula, socio " &
            "FROM vw_saldos_membresia " &
            "ORDER BY socio"

        Return Consultar(sql)

    End Function

    Public Shared Function ObtenerInstructores() As DataTable

        Dim sql As String =
            "SELECT DISTINCT id_instructor, instructor " &
            "FROM vw_horario_semanal " &
            "ORDER BY instructor"

        Return Consultar(sql)

    End Function

    Public Shared Function ObtenerSalas() As DataTable

        Dim sql As String =
            "SELECT DISTINCT id_sala, sala " &
            "FROM vw_horario_semanal " &
            "ORDER BY sala"

        Return Consultar(sql)

    End Function

    Public Shared Function ObtenerAnios() As DataTable

        Dim sql As String =
            "SELECT DISTINCT anio " &
            "FROM vw_ingresos_detalle " &
            "ORDER BY anio DESC"

        Return Consultar(sql)

    End Function

    ' =====================================================
    ' R07 · CARTERA
    ' =====================================================
    Public Shared Function ObtenerCartera(
        incluirAlDia As Boolean
    ) As DataTable

        Dim sql As String =
            "SELECT cedula, socio, telefono, plan, " &
            "       fecha_inicio, fecha_vencimiento, " &
            "       precio_pactado, pagado, saldo, " &
            "       dias_vencido, estado_real " &
            "FROM vw_saldos_membresia " &
            "WHERE estado_real <> 'Cancelada' " &
            "  AND (@incluir_al_dia = 1 OR saldo > 0) " &
            "ORDER BY dias_vencido DESC, saldo DESC, socio"

        Return Consultar(
            sql,
            New MySqlParameter("@incluir_al_dia", If(incluirAlDia, 1, 0))
        )

    End Function

    ' =====================================================
    ' R08 · INFORME GERENCIAL
    ' =====================================================
    Public Shared Function ObtenerIndicadores(
        mes As Integer,
        anio As Integer
    ) As DataRow

        Dim sql As String =
            "SELECT " &
            " (SELECT COUNT(DISTINCT id_socio) " &
            "    FROM vw_saldos_membresia " &
            "   WHERE estado_real = 'Activa') AS socios_activos, " &
            " (SELECT COUNT(*) " &
            "    FROM vw_saldos_membresia " &
            "   WHERE YEAR(fecha_inicio) = @anio " &
            "     AND MONTH(fecha_inicio) = @mes) AS nuevas_membresias, " &
            " (SELECT COALESCE(SUM(monto), 0) " &
            "    FROM vw_ingresos_detalle " &
            "   WHERE anio = @anio AND mes = @mes " &
            "     AND anulado = 0) AS ingresos_mes, " &
            " (SELECT COALESCE(SUM(saldo), 0) " &
            "    FROM vw_saldos_membresia " &
            "   WHERE estado_real <> 'Cancelada') AS por_cobrar"

        Dim tabla As DataTable = Consultar(
            sql,
            New MySqlParameter("@mes", mes),
            New MySqlParameter("@anio", anio)
        )

        If tabla.Rows.Count = 0 Then Return Nothing
        Return tabla.Rows(0)

    End Function

    Public Shared Function ObtenerIngresosPorPlan(
        mes As Integer,
        anio As Integer
    ) As DataTable

        Dim sql As String =
            "SELECT plan, " &
            "       COUNT(*) AS vendidas, " &
            "       COALESCE(SUM(CASE WHEN anulado = 0 " &
            "                         THEN monto ELSE 0 END), 0) AS ingresos " &
            "FROM vw_ingresos_detalle " &
            "WHERE anio = @anio AND mes = @mes " &
            "GROUP BY plan " &
            "ORDER BY ingresos DESC, plan"

        Return Consultar(
            sql,
            New MySqlParameter("@mes", mes),
            New MySqlParameter("@anio", anio)
        )

    End Function

    Public Shared Function ObtenerSaldosAltos() As DataTable

        Dim sql As String =
            "SELECT socio, cedula, telefono, plan, " &
            "       fecha_vencimiento, saldo, dias_vencido " &
            "FROM vw_saldos_membresia " &
            "WHERE estado_real <> 'Cancelada' AND saldo > 0 " &
            "ORDER BY saldo DESC, dias_vencido DESC " &
            "LIMIT 10"

        Return Consultar(sql)

    End Function

    Public Shared Function ObtenerHorasInstructores() As DataTable

        Dim sql As String =
            "SELECT instructor, COUNT(*) AS clases, " &
            "       ROUND(SUM(minutos) / 60, 2) AS horas " &
            "FROM vw_horario_semanal " &
            "WHERE estado = 'Activo' " &
            "GROUP BY instructor " &
            "ORDER BY horas DESC, instructor"

        Return Consultar(sql)

    End Function

    ' =====================================================
    ' R09 · LIBRO ANUAL
    ' =====================================================
    Public Shared Function ObtenerIngresosAnio(
        anio As Integer
    ) As DataTable

        Dim sql As String =
            "SELECT fecha, numero_recibo, socio, plan, " &
            "       metodo_pago, monto, anulado " &
            "FROM vw_ingresos_detalle " &
            "WHERE anio = @anio " &
            "ORDER BY fecha, id_pago"

        Return Consultar(
            sql,
            New MySqlParameter("@anio", anio)
        )

    End Function

    ' =====================================================
    ' INFRAESTRUCTURA
    ' =====================================================
    Private Shared Function Consultar(
        sql As String,
        ParamArray parametros() As MySqlParameter
    ) As DataTable

        Dim tabla As New DataTable()

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexionReportes()

            Using comando As New MySqlCommand(sql, conexion)

                If parametros IsNot Nothing Then
                    comando.Parameters.AddRange(parametros)
                End If

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using
        End Using

        Return tabla

    End Function

    Private Shared Function Valor(valor As Integer?) As Integer

        If valor.HasValue Then Return valor.Value
        Return 0

    End Function

End Class
