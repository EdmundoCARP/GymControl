Public Class frmCambiarContrasena
    Private Sub frmCambiarContrasena_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtActual.UseSystemPasswordChar = True
        txtNueva.UseSystemPasswordChar = True
        txtConfirmar.UseSystemPasswordChar = True

    End Sub

    Private Sub btnCambiar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCambiar.Click

        If txtActual.Text = "" OrElse
           txtNueva.Text = "" OrElse
           txtConfirmar.Text = "" Then

            MessageBox.Show(
                "Debe completar todos los campos.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If txtNueva.Text <> txtConfirmar.Text Then

            MessageBox.Show(
                "Las nuevas contraseñas no coinciden.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If txtNueva.Text.Length < 8 Then

            MessageBox.Show(
                "La nueva contraseña debe tener al menos 8 caracteres.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Dim usuario As Usuario =
                UsuarioDAO.ObtenerPorId(
                    Sesion.IdUsuario
                )

            If usuario Is Nothing Then

                MessageBox.Show(
                    "No se encontró el usuario.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

                Return

            End If

            Dim actualCorrecta As Boolean =
                Seguridad.Verificar(
                    txtActual.Text,
                    usuario.Sal,
                    usuario.ContrasenaHash
                )

            If Not actualCorrecta Then

                MessageBox.Show(
                    "La contraseña actual es incorrecta.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                txtActual.Clear()
                txtActual.Focus()

                Return

            End If

            UsuarioDAO.CambiarContrasena(
                Sesion.IdUsuario,
                txtNueva.Text
            )

            MessageBox.Show(
                "Contraseña cambiada correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            txtActual.Clear()
            txtNueva.Clear()
            txtConfirmar.Clear()

            Me.Close()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cambiar la contraseña." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try
    End Sub
End Class