Public Class frmLogin

    Private Sub frmLogin_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        txtUsuario.Clear()
        txtcontrasena.Clear()

        txtcontrasena.UseSystemPasswordChar = True

        chkMostrar.Checked = False

        lblMensaje.Text = ""
        lblMensaje.Visible = False

        stsConexion.Text =
            "Servidor: localhost:3306 | BD: gimnasio_db"

        txtUsuario.Focus()

    End Sub


    Private Sub chkMostrar_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkMostrar.CheckedChanged

        txtcontrasena.UseSystemPasswordChar =
            Not chkMostrar.Checked

    End Sub


    Private Sub btnIngresar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnIngresar.Click

        lblMensaje.Text = ""
        lblMensaje.Visible = False

        Dim nombreUsuario As String =
            txtUsuario.Text.Trim()

        Dim contrasena As String =
            txtcontrasena.Text

        If nombreUsuario = "" OrElse contrasena = "" Then

            lblMensaje.Text =
                "Debe ingresar usuario y contraseña."

            lblMensaje.Visible = True

            txtUsuario.Focus()

            Return

        End If


        Try

            Dim usuario As Usuario =
                UsuarioDAO.ObtenerPorNombre(nombreUsuario)


            ' Usuario no existe
            If usuario Is Nothing Then

                BitacoraDAO.Registrar(
                    Nothing,
                    nombreUsuario,
                    "Fallido"
                )

                lblMensaje.Text =
                    "Usuario o contraseña incorrectos."

                lblMensaje.Visible = True

                txtcontrasena.Clear()
                txtcontrasena.Focus()

                Return

            End If


            ' Cuenta bloqueada
            If Not usuario.Activo Then

                BitacoraDAO.Registrar(
                    usuario.IdUsuario,
                    nombreUsuario,
                    "Bloqueado"
                )

                lblMensaje.Text =
                    "Esta cuenta está bloqueada."

                lblMensaje.Visible = True

                Return

            End If


            ' Verificar contraseña
            Dim contrasenaCorrecta As Boolean =
                Seguridad.Verificar(
                    contrasena,
                    usuario.Sal,
                    usuario.ContrasenaHash
                )


            ' Contraseña incorrecta
            If Not contrasenaCorrecta Then

                Dim intentos As Integer =
                    UsuarioDAO.RegistrarFallo(
                        usuario.IdUsuario
                    )


                If intentos >= 3 Then

                    BitacoraDAO.Registrar(
                        usuario.IdUsuario,
                        nombreUsuario,
                        "Bloqueado"
                    )

                    lblMensaje.Text =
                        "Cuenta bloqueada después de 3 intentos fallidos."

                    lblMensaje.Visible = True

                    txtcontrasena.Clear()

                Else

                    BitacoraDAO.Registrar(
                        usuario.IdUsuario,
                        nombreUsuario,
                        "Fallido"
                    )

                    Dim restantes As Integer =
                        3 - intentos

                    lblMensaje.Text =
                        "Usuario o contraseña incorrectos. " &
                        "Intentos restantes: " &
                        restantes.ToString()

                    lblMensaje.Visible = True

                    txtcontrasena.Clear()
                    txtcontrasena.Focus()

                End If

                Return

            End If


            ' Login correcto
            UsuarioDAO.RegistrarAccesoExitoso(
                usuario.IdUsuario
            )


            BitacoraDAO.Registrar(
                usuario.IdUsuario,
                nombreUsuario,
                "Exitoso"
            )


            ' Cargar sesión
            Sesion.IdUsuario =
                usuario.IdUsuario

            Sesion.NombreUsuario =
                usuario.NombreUsuario

            Sesion.Rol =
                usuario.Rol

            Sesion.IdSocio =
                usuario.IdSocio

            Sesion.IdInstructor =
                usuario.IdInstructor

            Sesion.IdUsuario = usuario.IdUsuario
            Sesion.NombreUsuario = usuario.NombreUsuario
            Sesion.Rol = usuario.Rol
            Sesion.IdSocio = usuario.IdSocio
            Sesion.IdInstructor = usuario.IdInstructor

            Dim formulario As Form

            If usuario.Rol = "Socio" Then
                formulario = New frmPortalSocio()
            Else
                formulario = New frmPrincipal()
            End If

            Me.Hide()
            formulario.ShowDialog()
            Me.Show()

            MessageBox.Show(
                "Bienvenido, " &
                usuario.NombreUsuario &
                Environment.NewLine &
                "Rol: " &
                usuario.Rol,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )


        Catch ex As Exception

            lblMensaje.Text =
                "Error al iniciar sesión."

            lblMensaje.Visible = True

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


    Private Sub btnSalir_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSalir.Click

        Application.Exit()

    End Sub
End Class