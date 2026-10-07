Public Class frmHorarios

    Private idSeleccionado As Integer = 0

    Private Sub frmHorarios_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Sesion.Rol <> "Administrador" AndAlso
           Sesion.Rol <> "Recepcionista" AndAlso
           Sesion.Rol <> "Instructor" Then

            MessageBox.Show(
                "No tiene permisos para acceder a este módulo.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Me.Close()
            Return

        End If

        CargarCombos()
        ConfigurarGrid()
        CargarDatos()
        Limpiar()

        If Sesion.Rol <> "Administrador" Then

            btnGuardar.Enabled = False
            btnNuevo.Enabled = False
            btnDesactivar.Enabled = False

            cboInstructor.Enabled = False
            cboActividad.Enabled = False
            cboSala.Enabled = False
            cboDia.Enabled = False
            dtpHoraInicio.Enabled = False
            dtpHoraFin.Enabled = False

        End If

    End Sub


    Private Sub ConfigurarGrid()

        dgvHorarios.ReadOnly = True

        dgvHorarios.AllowUserToAddRows = False

        dgvHorarios.AllowUserToDeleteRows = False

        dgvHorarios.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvHorarios.MultiSelect = False

        dgvHorarios.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

    End Sub


    Private Sub CargarCombos()

        Try

            cboInstructor.DisplayMember = "nombre"
            cboInstructor.ValueMember = "id_instructor"
            cboInstructor.DataSource =
                HorarioDAO.ObtenerInstructores()

            cboActividad.DisplayMember = "nombre"
            cboActividad.ValueMember = "id_actividad"
            cboActividad.DataSource =
                HorarioDAO.ObtenerActividades()

            cboSala.DisplayMember = "nombre"
            cboSala.ValueMember = "id_sala"
            cboSala.DataSource =
                HorarioDAO.ObtenerSalas()

            cboDia.Items.Clear()

            cboDia.Items.Add("Lunes")
            cboDia.Items.Add("Martes")
            cboDia.Items.Add("Miércoles")
            cboDia.Items.Add("Jueves")
            cboDia.Items.Add("Viernes")
            cboDia.Items.Add("Sábado")
            cboDia.Items.Add("Domingo")

            cboDia.SelectedIndex = 0

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los catálogos." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub


    Private Sub CargarDatos()

        Try

            dgvHorarios.DataSource =
                HorarioDAO.ObtenerTodos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los horarios." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub


    Private Sub Limpiar()

        idSeleccionado = 0

        If cboInstructor.Items.Count > 0 Then
            cboInstructor.SelectedIndex = 0
        End If

        If cboActividad.Items.Count > 0 Then
            cboActividad.SelectedIndex = 0
        End If

        If cboSala.Items.Count > 0 Then
            cboSala.SelectedIndex = 0
        End If

        cboDia.SelectedIndex = 0

        dtpHoraInicio.Value =
            Date.Today.AddHours(8)

        dtpHoraFin.Value =
            Date.Today.AddHours(9)

        lblChoque.Text = ""

        lblEstado.Text =
            "Nuevo horario"

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

        If cboInstructor.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione un instructor.")
            Return
        End If

        If cboActividad.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una actividad.")
            Return
        End If

        If cboSala.SelectedValue Is Nothing Then
            MessageBox.Show("Seleccione una sala.")
            Return
        End If

        If cboDia.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione un día.")
            Return
        End If

        Dim horaInicio As TimeSpan =
            dtpHoraInicio.Value.TimeOfDay

        Dim horaFin As TimeSpan =
            dtpHoraFin.Value.TimeOfDay

        If horaFin <= horaInicio Then

            MessageBox.Show(
                "La hora final debe ser mayor que la hora inicial."
            )

            Return

        End If

        Dim idInstructor As Integer =
            Convert.ToInt32(
                cboInstructor.SelectedValue
            )

        Dim idActividad As Integer =
            Convert.ToInt32(
                cboActividad.SelectedValue
            )

        Dim idSala As Integer =
            Convert.ToInt32(
                cboSala.SelectedValue
            )

        Dim dia As Integer =
            cboDia.SelectedIndex + 1

        Try

            Dim choque As Boolean =
                HorarioDAO.ExisteChoque(
                    idInstructor,
                    idSala,
                    dia,
                    horaInicio,
                    horaFin,
                    idSeleccionado
                )

            If choque Then

                lblChoque.Text =
                    "⚠ CHOQUE: el instructor o la sala ya tienen un horario en ese intervalo."

                MessageBox.Show(
                    "Existe un choque de horario." &
                    Environment.NewLine &
                    "Revise el instructor y la sala.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            HorarioDAO.Crear(
                idInstructor,
                idActividad,
                idSala,
                dia,
                horaInicio,
                horaFin
            )

            MessageBox.Show(
                "Horario registrado correctamente."
            )

            CargarDatos()
            Limpiar()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo guardar el horario." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub


    Private Sub dgvHorarios_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvHorarios.CellClick

        If e.RowIndex < 0 Then Return

        Dim fila =
            dgvHorarios.Rows(e.RowIndex)

        idSeleccionado =
            Convert.ToInt32(
                fila.Cells("id_horario").Value
            )

        lblEstado.Text =
            "Horario seleccionado: " &
            idSeleccionado.ToString()

    End Sub


    Private Sub btnDesactivar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnDesactivar.Click

        If idSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un horario."
            )

            Return

        End If

        If MessageBox.Show(
            "¿Desea desactivar este horario?",
            "GymControl",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        ) <> DialogResult.Yes Then

            Return

        End If

        Try

            HorarioDAO.Desactivar(
                idSeleccionado
            )

            MessageBox.Show(
                "Horario desactivado correctamente."
            )

            CargarDatos()
            Limpiar()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo desactivar." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub

End Class