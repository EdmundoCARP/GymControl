Public Class frmBitacoras
    Private Sub frmBitacoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        CargarBitacora()

    End Sub


    Private Sub CargarBitacora()

        Try

            dgvBitacora.DataSource =
                BitacoraDAO.ObtenerTodos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cargar la bitácora." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub btnActualizar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnActualizar.Click

        CargarBitacora()
    End Sub
End Class