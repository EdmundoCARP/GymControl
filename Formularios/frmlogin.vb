Public Class frmlogin
    Private Sub btnIniciarSesion_Click(
    sender As Object,
    e As EventArgs
) Handles btnIniciarSesion.Click

        Dim nombreUsuario As String = txtUsuario.Text.Trim()
        Dim contrasena As String = txtcontrasena.Text

        If nombreUsuario = "" OrElse contrasena = "" Then

            MessageBox.Show(
            "Debe ingresar usuario y contraseña.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )

            Return

        End If

        Try

            Dim usuario As Usuario =
            UsuarioDAO.ObtenerPorNombre(nombreUsuario)

            If usuario Is Nothing Then

                BitacoraDAO.Registrar(
                Nothing,
                nombreUsuario,
                "Fallido"
            )

                MessageBox.Show(
                "Usuario o contraseña incorrectos.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

                Return

            End If

            If Not usuario.Activo Then

                BitacoraDAO.Registrar(
                usuario.IdUsuario,
                nombreUsuario,
                "Bloqueado"
            )

                MessageBox.Show(
                "Esta cuenta está bloqueada.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

                Return

            End If

            Dim contrasenaCorrecta As Boolean =
            Seguridad.Verificar(
                contrasena,
                usuario.Sal,
                usuario.ContrasenaHash
            )

            If Not contrasenaCorrecta Then

                Dim intentos As Integer =
                UsuarioDAO.RegistrarFallo(usuario.IdUsuario)

                If intentos >= 3 Then

                    BitacoraDAO.Registrar(
                    usuario.IdUsuario,
                    nombreUsuario,
                    "Bloqueado"
                )

                    MessageBox.Show(
                    "La cuenta ha sido bloqueada después de 3 intentos fallidos.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

                Else

                    BitacoraDAO.Registrar(
                    usuario.IdUsuario,
                    nombreUsuario,
                    "Fallido"
                )

                    MessageBox.Show(
                    "Contraseña incorrecta." &
                    Environment.NewLine &
                    "Intentos fallidos: " & intentos & " de 3.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                End If

                Return

            End If

            UsuarioDAO.RegistrarAccesoExitoso(usuario.IdUsuario)

            BitacoraDAO.Registrar(
            usuario.IdUsuario,
            nombreUsuario,
            "Exitoso"
        )

            Sesion.IdUsuario = usuario.IdUsuario
            Sesion.NombreUsuario = usuario.NombreUsuario
            Sesion.Rol = usuario.Rol
            Sesion.IdSocio = usuario.IdSocio
            Sesion.IdInstructor = usuario.IdInstructor

            MessageBox.Show(
            "Bienvenido, " & usuario.NombreUsuario &
            Environment.NewLine &
            "Rol: " & usuario.Rol,
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

            'Más adelante aquí abriremos:
            'frmPrincipal para Administrador, Recepcionista e Instructor
            'frmPortalSocio para Socio

        Catch ex As Exception

            MessageBox.Show(
            "Error al iniciar sesión:" &
            Environment.NewLine &
            ex.Message,
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

        End Try

    End Sub
End Class