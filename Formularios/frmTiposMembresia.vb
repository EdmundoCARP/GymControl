Public Class frmTiposMembresia

    Private idSeleccionado As Integer = 0

    Private Sub frmTiposMembresia_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        CargarDatos()
        Limpiar()

    End Sub

    Private Sub CargarDatos()

        Try

            dgvTipos.DataSource =
                TipoMembresiaDAO.ObtenerTodos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los tipos de membresía." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub Limpiar()

        idSeleccionado = 0

        txtNombre.Clear()
        txtDescripcion.Clear()
        txtDuracion.Clear()
        txtPrecio.Clear()

        chkIncluyeClases.Checked = True
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

            MessageBox.Show("La duración debe ser un número mayor que 0.")
            Return

        End If

        Dim precio As Decimal

        If Not Decimal.TryParse(
            txtPrecio.Text,
            precio
        ) OrElse precio < 0 Then

            MessageBox.Show("Ingrese un precio válido.")
            Return

        End If

        Try

            If idSeleccionado = 0 Then

                TipoMembresiaDAO.Crear(
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    duracion,
                    precio,
                    chkIncluyeClases.Checked
                )

                MessageBox.Show("Tipo de membresía creado correctamente.")

            Else

                TipoMembresiaDAO.Actualizar(
                    idSeleccionado,
                    txtNombre.Text.Trim(),
                    txtDescripcion.Text.Trim(),
                    duracion,
                    precio,
                    chkIncluyeClases.Checked,
                    chkActivo.Checked
                )

                MessageBox.Show("Tipo de membresía actualizado correctamente.")

            End If

            CargarDatos()
            Limpiar()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo guardar." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub

    Private Sub dgvTipos_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvTipos.CellClick

        If e.RowIndex < 0 Then Return

        Dim fila = dgvTipos.Rows(e.RowIndex)

        idSeleccionado =
            Convert.ToInt32(fila.Cells("id_tipo").Value)

        txtNombre.Text =
            fila.Cells("nombre").Value.ToString()

        txtDescripcion.Text =
            fila.Cells("descripcion").Value.ToString()

        txtDuracion.Text =
            fila.Cells("duracion_dias").Value.ToString()

        txtPrecio.Text =
            fila.Cells("precio").Value.ToString()

        chkIncluyeClases.Checked =
            Convert.ToBoolean(
                fila.Cells("incluye_clases").Value
            )

        chkActivo.Checked =
            Convert.ToBoolean(
                fila.Cells("activo").Value
            )

    End Sub

End Class