Public Class frmUsuarios

    Private idUsuarioSeleccionado As Integer = 0

    Private Sub frmUsuarios_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Sesion.Rol <> "Administrador" Then

            MessageBox.Show(
                "No tiene permisos para acceder a este módulo.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Me.Close()

            Return

        End If

        CargarRoles()
        CargarUsuarios()
        LimpiarFormulario()

    End Sub


    Private Sub CargarRoles()

        cboRol.Items.Clear()

        cboRol.Items.Add(
            New ComboBoxItem(1, "Administrador")
        )

        cboRol.Items.Add(
            New ComboBoxItem(2, "Recepcionista")
        )

        cboRol.Items.Add(
            New ComboBoxItem(3, "Instructor")
        )

        cboRol.Items.Add(
            New ComboBoxItem(4, "Socio")
        )

        cboRol.SelectedIndex = -1

    End Sub


    Private Sub CargarUsuarios()

        Try

            dgvUsuarios.DataSource =
                UsuarioDAO.ObtenerTodos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los usuarios." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub LimpiarFormulario()

        idUsuarioSeleccionado = 0

        txtUsuario.Clear()
        txtContrasena.Clear()

        cboRol.SelectedIndex = -1

        chkActivo.Checked = True

        txtUsuario.Focus()

    End Sub


    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        LimpiarFormulario()

    End Sub


    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        If txtUsuario.Text.Trim() = "" Then

            MessageBox.Show(
                "Debe ingresar un nombre de usuario.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        If txtContrasena.Text = "" Then

            MessageBox.Show(
                "Debe ingresar una contraseña.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        If cboRol.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Debe seleccionar un rol.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Dim rol As ComboBoxItem =
            CType(
                cboRol.SelectedItem,
                ComboBoxItem
            )


        Try

            If idUsuarioSeleccionado = 0 Then

                UsuarioDAO.Crear(
                    txtUsuario.Text.Trim(),
                    txtContrasena.Text,
                    rol.Id
                )

                MessageBox.Show(
                    "Usuario creado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            Else

                UsuarioDAO.Actualizar(
                    idUsuarioSeleccionado,
                    txtUsuario.Text.Trim(),
                    rol.Id,
                    chkActivo.Checked
                )

                MessageBox.Show(
                    "Usuario actualizado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

            CargarUsuarios()
            LimpiarFormulario()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo guardar el usuario." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub dgvUsuarios_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvUsuarios.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim fila As DataGridViewRow =
            dgvUsuarios.Rows(e.RowIndex)

        idUsuarioSeleccionado =
            Convert.ToInt32(
                fila.Cells("id_usuario").Value
            )

        txtUsuario.Text =
            fila.Cells("nombre_usuario").Value.ToString()

        Dim nombreRol As String =
            fila.Cells("rol").Value.ToString()

        For i As Integer = 0 To cboRol.Items.Count - 1

            Dim item As ComboBoxItem =
                CType(
                    cboRol.Items(i),
                    ComboBoxItem
                )

            If item.Text = nombreRol Then

                cboRol.SelectedIndex = i

                Exit For

            End If

        Next

        chkActivo.Checked =
            Convert.ToBoolean(
                fila.Cells("activo").Value
            )

        txtContrasena.Clear()

    End Sub


    Private Sub btnDesbloquear_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDesbloquear.Click

        If idUsuarioSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un usuario.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Try

            UsuarioDAO.Desbloquear(
                idUsuarioSeleccionado
            )

            MessageBox.Show(
                "Usuario desbloqueado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarUsuarios()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo desbloquear el usuario." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub btnRestablecer_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRestablecer.Click

        If idUsuarioSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un usuario.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        If txtContrasena.Text = "" Then

            MessageBox.Show(
                "Escriba la nueva contraseña.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If


        Try

            UsuarioDAO.RestablecerContrasena(
                idUsuarioSeleccionado,
                txtContrasena.Text
            )

            MessageBox.Show(
                "Contraseña restablecida correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            txtContrasena.Clear()
            CargarUsuarios()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo restablecer la contraseña." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

End Class
Public Class ComboBoxItem

    Public Property Id As Integer

    Public Property Text As String

    Public Sub New(
        id As Integer,
        text As String
    )

        Me.Id = id
        Me.Text = text

    End Sub

    Public Overrides Function ToString() As String

        Return Text

    End Function

End Class