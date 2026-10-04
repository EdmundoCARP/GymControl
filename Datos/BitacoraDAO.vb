Imports MySqlConnector

Public Class BitacoraDAO

    Public Shared Sub Registrar(
        idUsuario As Integer?,
        usuarioIntento As String,
        resultado As String
    )

        Dim sql As String =
            "INSERT INTO bitacora_accesos
             (id_usuario, usuario_intento, resultado, equipo)
             VALUES
             (@id_usuario, @usuario, @resultado, @equipo)"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                If idUsuario.HasValue Then
                    comando.Parameters.AddWithValue(
                        "@id_usuario",
                        idUsuario.Value
                    )
                Else
                    comando.Parameters.AddWithValue(
                        "@id_usuario",
                        DBNull.Value
                    )
                End If

                comando.Parameters.AddWithValue(
                    "@usuario",
                    usuarioIntento
                )

                comando.Parameters.AddWithValue(
                    "@resultado",
                    resultado
                )

                comando.Parameters.AddWithValue(
                    "@equipo",
                    Environment.MachineName
                )

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    Public Shared Function ObtenerTodos() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_bitacora,
                    id_usuario,
                    usuario_intento,
                    fecha_hora,
                    resultado,
                    equipo
             FROM bitacora_accesos
             ORDER BY fecha_hora DESC"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                Using adaptador As New MySqlDataAdapter(comando)

                    adaptador.Fill(tabla)

                End Using

            End Using
        End Using

        Return tabla

    End Function

End Class
