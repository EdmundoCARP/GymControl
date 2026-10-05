Public Class frmActividades

    Private idSeleccionado As Integer = 0

    Private Sub frmActividades_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        CargarDatos()
        Limpiar()

    End Sub

    Private Sub CargarDatos()

        Try

            dgvActividades.DataSource =
                ActividadDAO.ObtenerTodos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar las actividades." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub

    Private Sub Limpiar()

        idSeleccionado = 0

        txtNombre.Clear()
        txtDescripcion.Clear()
        txtDuracion.Clear()
        txtCupo.Clear()

        chkActivo.Checked = True

        txtNombre.Focus()

    End Sub

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        Limpiar()

    End Sub

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        If txtNombre.Text.Trim() = "" Then

            MessageBox.Show("Ingrese el nombre.")

            Return

        End If

        Dim duracion As Integer

        If Not Integer.TryParse(
            txtDuracion.Text,
            duracion
        ) OrElse duracion <= 0 Then

            MessageBox.Show(
                "La duración debe ser mayor que 0."
            )

            Return

        End If

        Dim cupo As Integer

        If Not Integer.TryParse(
            txtCupo.Text,
            cupo
        ) OrElse cupo <= 0 Then

            MessageBox.Show(
                "El cupo debe ser mayor que 0."
            )

            Return

        End If

        Try

            If idSeleccionado = 0 Then

                ActividadDAO.Crear(
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    duracion,
                    cupo
                )

                MessageBox.Show(
                    "Actividad creada correctamente."
                )

            Else

                ActividadDAO.Actualizar(
                    idSeleccionado,
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    duracion,
                    cupo,
                    chkActivo.Checked
                )

                MessageBox.Show(
                    "Actividad actualizada correctamente."
                )

            End If

            CargarDatos()
            Limpiar()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo guardar la actividad." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub

    Private Sub dgvActividades_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvActividades.CellClick

        If e.RowIndex < 0 Then Return

        Dim fila =
            dgvActividades.Rows(e.RowIndex)

        idSeleccionado =
            Convert.ToInt32(
                fila.Cells("id_actividad").Value
            )

        txtNombre.Text =
            fila.Cells("nombre").Value.ToString()

        txtDescripcion.Text =
            fila.Cells("descripcion").Value.ToString()

        txtDuracion.Text =
            fila.Cells("duracion_min").Value.ToString()

        txtCupo.Text =
            fila.Cells("cupo_maximo").Value.ToString()

        chkActivo.Checked =
            Convert.ToBoolean(
                fila.Cells("activo").Value
            )

    End Sub

    Private Sub txtCupo_TextChanged(sender As Object, e As EventArgs) Handles txtCupo.TextChanged

    End Sub
End Class