Imports MySqlConnector

Public Class UsuarioDAO

    Public Shared Function ObtenerPorNombre(nombreUsuario As String) As Usuario

        Dim sql As String =
            "SELECT u.id_usuario,
                    u.nombre_usuario,
                    u.contrasena_hash,
                    u.sal,
                    u.id_rol,
                    r.nombre AS rol,
                    u.id_socio,
                    u.id_instructor,
                    u.intentos_fallidos,
                    u.activo,
                    u.ultimo_acceso
             FROM usuarios u
             INNER JOIN roles r ON r.id_rol = u.id_rol
             WHERE u.nombre_usuario = @usuario"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@usuario", nombreUsuario)

                conexion.Open()

                Using lector As MySqlDataReader = comando.ExecuteReader()

                    If Not lector.Read() Then
                        Return Nothing
                    End If

                    Dim usuario As New Usuario()

                    usuario.IdUsuario = Convert.ToInt32(lector("id_usuario"))
                    usuario.NombreUsuario = lector("nombre_usuario").ToString()
                    usuario.ContrasenaHash = lector("contrasena_hash").ToString()
                    usuario.Sal = lector("sal").ToString()
                    usuario.IdRol = Convert.ToInt32(lector("id_rol"))
                    usuario.Rol = lector("rol").ToString()
                    usuario.IntentosFallidos = Convert.ToInt32(lector("intentos_fallidos"))
                    usuario.Activo = Convert.ToBoolean(lector("activo"))

                    If IsDBNull(lector("id_socio")) Then
                        usuario.IdSocio = Nothing
                    Else
                        usuario.IdSocio = Convert.ToInt32(lector("id_socio"))
                    End If

                    If IsDBNull(lector("id_instructor")) Then
                        usuario.IdInstructor = Nothing
                    Else
                        usuario.IdInstructor = Convert.ToInt32(lector("id_instructor"))
                    End If

                    If IsDBNull(lector("ultimo_acceso")) Then
                        usuario.UltimoAcceso = Nothing
                    Else
                        usuario.UltimoAcceso =
                            Convert.ToDateTime(lector("ultimo_acceso"))
                    End If

                    Return usuario

                End Using

            End Using
        End Using

    End Function

    Public Shared Function RegistrarFallo(idUsuario As Integer) As Integer

        Dim sql As String =
            "UPDATE usuarios
             SET intentos_fallidos = intentos_fallidos + 1,
                 activo = CASE
                            WHEN intentos_fallidos + 1 >= 3 THEN 0
                            ELSE activo
                          END
             WHERE id_usuario = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", idUsuario)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using

            Using comando As New MySqlCommand(
                "SELECT intentos_fallidos FROM usuarios WHERE id_usuario = @id",
                conexion)

                comando.Parameters.AddWithValue("@id", idUsuario)

                Return Convert.ToInt32(comando.ExecuteScalar())

            End Using
        End Using

    End Function

    Public Shared Sub RegistrarAccesoExitoso(idUsuario As Integer)

        Dim sql As String =
            "UPDATE usuarios
             SET intentos_fallidos = 0,
                 activo = 1,
                 ultimo_acceso = NOW()
             WHERE id_usuario = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", idUsuario)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    Public Shared Sub Desbloquear(idUsuario As Integer)

        Dim sql As String =
            "UPDATE usuarios
             SET intentos_fallidos = 0,
                 activo = 1
             WHERE id_usuario = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", idUsuario)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

End Class
