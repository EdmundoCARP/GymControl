Imports MySqlConnector
Imports System.Data

Public Class MembresiaDAO

    Public Shared Function BuscarSocioPorCedula(
        cedula As String
    ) As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_socio, cedula, nombres, apellidos, activo " &
            "FROM socios " &
            "WHERE cedula = @cedula"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@cedula", cedula)

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using
        End Using

        Return tabla

    End Function


    Public Shared Function ObtenerTipos() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_tipo, nombre, duracion_dias, precio " &
            "FROM tipos_membresia " &
            "WHERE activo = 1 " &
            "ORDER BY nombre"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using
        End Using

        Return tabla

    End Function


    Public Shared Function ObtenerMembresias(
        idSocio As Integer
    ) As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT m.id_membresia, " &
            "tm.nombre AS tipo, " &
            "m.fecha_inicio, " &
            "m.fecha_vencimiento, " &
            "m.precio_pactado AS precio, " &
            "m.estado " &
            "FROM membresias m " &
            "INNER JOIN tipos_membresia tm " &
            "ON tm.id_tipo = m.id_tipo " &
            "WHERE m.id_socio = @id_socio " &
            "ORDER BY m.fecha_inicio DESC"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id_socio", idSocio)

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using
        End Using

        Return tabla

    End Function


    Public Shared Sub Crear(
        idSocio As Integer,
        idTipo As Integer,
        fechaInicio As DateTime,
        fechaVencimiento As DateTime,
        precio As Decimal,
        estado As String
    )

        Dim sql As String =
            "INSERT INTO membresias " &
            "(id_socio, id_tipo, fecha_inicio, fecha_vencimiento, precio_pactado, estado) " &
            "VALUES " &
            "(@id_socio, @id_tipo, @inicio, @vencimiento, @precio, @estado)"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id_socio", idSocio)
                comando.Parameters.AddWithValue("@id_tipo", idTipo)
                comando.Parameters.AddWithValue("@inicio", fechaInicio)
                comando.Parameters.AddWithValue("@vencimiento", fechaVencimiento)
                comando.Parameters.AddWithValue("@precio", precio)
                comando.Parameters.AddWithValue("@estado", estado)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub


    Public Shared Sub ActualizarEstado(
        idMembresia As Integer,
        estado As String
    )

        Dim sql As String =
            "UPDATE membresias " &
            "SET estado = @estado " &
            "WHERE id_membresia = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@estado", estado)
                comando.Parameters.AddWithValue("@id", idMembresia)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub


    Public Shared Function ObtenerResumenPago(
        idMembresia As Integer
    ) As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT " &
            "m.precio_pactado AS total, " &
            "COALESCE(SUM(CASE " &
            "WHEN p.anulado = 0 THEN p.monto " &
            "ELSE 0 END), 0) AS pagado, " &
            "m.precio_pactado - COALESCE(SUM(CASE " &
            "WHEN p.anulado = 0 THEN p.monto " &
            "ELSE 0 END), 0) AS saldo " &
            "FROM membresias m " &
            "LEFT JOIN pagos p " &
            "ON p.id_membresia = m.id_membresia " &
            "WHERE m.id_membresia = @id " &
            "GROUP BY m.id_membresia, m.precio_pactado"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", idMembresia)

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using
        End Using

        Return tabla

    End Function


    Public Shared Function ObtenerPagos(
        idMembresia As Integer
    ) As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_pago, fecha_pago, monto, metodo_pago, " &
            "referencia, observacion, anulado " &
            "FROM pagos " &
            "WHERE id_membresia = @id " &
            "ORDER BY fecha_pago DESC"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", idMembresia)

                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using

            End Using
        End Using

        Return tabla

    End Function


    ''' <summary>
    ''' Registra un pago y devuelve el id generado, para que R01
    ''' pueda imprimir el recibo inmediatamente después.
    ''' </summary>
    Public Shared Function RegistrarPago(
        idMembresia As Integer,
        monto As Decimal,
        metodo As String,
        referencia As String,
        observacion As String
    ) As Integer

        If Sesion.IdUsuario <= 0 Then

            Throw New InvalidOperationException(
                "No hay un usuario de sesión válido para registrar el pago."
            )

        End If

        Dim sql As String =
            "INSERT INTO pagos " &
            "(id_membresia, id_usuario_registro, fecha_pago, monto, " &
            "metodo_pago, referencia, observacion, anulado) " &
            "VALUES " &
            "(@id_membresia, @id_usuario, NOW(), @monto, @metodo, " &
            "@referencia, @observacion, 0)"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue(
                    "@id_membresia",
                    idMembresia
                )

                comando.Parameters.AddWithValue(
                    "@id_usuario",
                    Sesion.IdUsuario
                )

                comando.Parameters.AddWithValue(
                    "@monto",
                    monto
                )

                comando.Parameters.AddWithValue(
                    "@metodo",
                    metodo
                )

                comando.Parameters.AddWithValue(
                    "@referencia",
                    referencia
                )

                comando.Parameters.AddWithValue(
                    "@observacion",
                    observacion
                )

                conexion.Open()
                comando.ExecuteNonQuery()

                Return Convert.ToInt32(comando.LastInsertedId)

            End Using
        End Using

    End Function


    Public Shared Sub AnularPago(
        idPago As Integer
    )

        Dim sql As String =
            "UPDATE pagos " &
            "SET anulado = 1 " &
            "WHERE id_pago = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", idPago)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

End Class
