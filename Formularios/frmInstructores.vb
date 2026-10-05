Imports MySqlConnector

Public Class frmInstructores

    Private idInstructorSeleccionado As Integer = 0
    Private modoNuevo As Boolean = False

    Private Sub frmInstructores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarTabla()
        LimpiarCampos()
        CargarInstructores()
        CambiarModo(False)

    End Sub

    '========================================================
    ' CONFIGURAR DATAGRIDVIEW
    '========================================================
    Private Sub ConfigurarTabla()

        dgvInstructores.AutoGenerateColumns = True
        dgvInstructores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvInstructores.MultiSelect = False
        dgvInstructores.ReadOnly = True
        dgvInstructores.AllowUserToAddRows = False

    End Sub

    '========================================================
    ' CARGAR INSTRUCTORES
    '========================================================
    Private Sub CargarInstructores()

        Try

            Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()

                conexion.Open()

                Dim sql As String =
                    "SELECT id_instructor, cedula, nombres, apellidos, " &
                    "especialidad, telefono, correo, fecha_contratacion, activo " &
                    "FROM instructores " &
                    "ORDER BY apellidos, nombres"

                Using comando As New MySqlCommand(sql, conexion)

                    Using adaptador As New MySqlDataAdapter(comando)

                        Dim tabla As New DataTable()
                        adaptador.Fill(tabla)

                        dgvInstructores.DataSource = tabla

                    End Using

                End Using

            End Using

            ActualizarTotal()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los instructores." &
                vbCrLf & vbCrLf & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    '========================================================
    ' ACTUALIZAR TOTAL
    '========================================================
    Private Sub ActualizarTotal()

        lblTotal.Text = "Total: " & dgvInstructores.Rows.Count & " instructores"

    End Sub

    '========================================================
    ' LIMPIAR CAMPOS
    '========================================================
    Private Sub LimpiarCampos()

        idInstructorSeleccionado = 0

        txtCedula.Clear()
        txtNombres.Clear()
        txtApellido.Clear()
        txtEspecialidad.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()

        dtpFechaContratacion.Value = DateTime.Today

        chkInstructor.Checked = True

        errValidacion.Clear()

    End Sub

    '========================================================
    ' VALIDAR DATOS
    '========================================================
    Private Function ValidarDatos() As Boolean

        errValidacion.Clear()

        Dim valido As Boolean = True

        If String.IsNullOrWhiteSpace(txtCedula.Text) Then

            errValidacion.SetError(
                txtCedula,
                "La cédula es obligatoria.")

            valido = False

        End If

        If String.IsNullOrWhiteSpace(txtNombres.Text) Then

            errValidacion.SetError(
                txtNombres,
                "Los nombres son obligatorios.")

            valido = False

        End If

        If String.IsNullOrWhiteSpace(txtApellido.Text) Then

            errValidacion.SetError(
                txtApellido,
                "Los apellidos son obligatorios.")

            valido = False

        End If

        If String.IsNullOrWhiteSpace(txtEspecialidad.Text) Then

            errValidacion.SetError(
                txtEspecialidad,
                "La especialidad es obligatoria.")

            valido = False

        End If

        If Not valido Then

            MessageBox.Show(
                "Complete los campos obligatorios.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

        End If

        Return valido

    End Function

    '========================================================
    ' CAMBIAR MODO DEL FORMULARIO
    '========================================================
    Private Sub CambiarModo(edicion As Boolean)

        txtCedula.Enabled = edicion
        txtNombres.Enabled = edicion
        txtApellido.Enabled = edicion
        txtEspecialidad.Enabled = edicion
        txtTelefono.Enabled = edicion
        txtCorreo.Enabled = edicion
        dtpFechaContratacion.Enabled = edicion
        chkInstructor.Enabled = edicion

        btnNuevo.Enabled = Not edicion
        btnEditar.Enabled = Not edicion AndAlso idInstructorSeleccionado > 0
        btnGuardar.Enabled = edicion
        btnEliminar.Enabled = Not edicion AndAlso idInstructorSeleccionado > 0
        btnCancelar.Enabled = edicion

    End Sub

    '========================================================
    ' SELECCIONAR INSTRUCTOR EN EL DATAGRIDVIEW
    '========================================================
    Private Sub dgvInstructores_SelectionChanged(
        sender As Object,
        e As EventArgs) Handles dgvInstructores.SelectionChanged

        If modoNuevo Then Exit Sub

        If dgvInstructores.CurrentRow Is Nothing Then Exit Sub

        Try

            idInstructorSeleccionado =
                Convert.ToInt32(
                    dgvInstructores.CurrentRow.Cells("id_instructor").Value)

            txtCedula.Text =
                dgvInstructores.CurrentRow.Cells("cedula").Value.ToString()

            txtNombres.Text =
                dgvInstructores.CurrentRow.Cells("nombres").Value.ToString()

            txtApellido.Text =
                dgvInstructores.CurrentRow.Cells("apellidos").Value.ToString()

            txtEspecialidad.Text =
                dgvInstructores.CurrentRow.Cells("especialidad").Value.ToString()

            txtTelefono.Text =
                dgvInstructores.CurrentRow.Cells("telefono").Value.ToString()

            txtCorreo.Text =
                dgvInstructores.CurrentRow.Cells("correo").Value.ToString()

            If Not IsDBNull(
                dgvInstructores.CurrentRow.Cells("fecha_contratacion").Value) Then

                dtpFechaContratacion.Value =
                    Convert.ToDateTime(
                        dgvInstructores.CurrentRow.Cells("fecha_contratacion").Value)

            End If

            If Not IsDBNull(
                dgvInstructores.CurrentRow.Cells("activo").Value) Then

                chkInstructor.Checked =
                    Convert.ToBoolean(
                        dgvInstructores.CurrentRow.Cells("activo").Value)

            End If

            btnEditar.Enabled = True
            btnEliminar.Enabled = True

        Catch

            idInstructorSeleccionado = 0

        End Try

    End Sub

    '========================================================
    ' BOTÓN NUEVO
    '========================================================
    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs) Handles btnNuevo.Click

        modoNuevo = True

        LimpiarCampos()
        CambiarModo(True)

        txtCedula.Focus()

    End Sub

    '========================================================
    ' BOTÓN EDITAR
    '========================================================
    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs) Handles btnEditar.Click

        If idInstructorSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un instructor primero.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Exit Sub

        End If

        modoNuevo = False

        CambiarModo(True)

        txtCedula.Focus()

    End Sub

    '========================================================
    ' BOTÓN CANCELAR
    '========================================================
    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs) Handles btnCancelar.Click

        modoNuevo = False

        LimpiarCampos()
        CargarInstructores()
        CambiarModo(False)

    End Sub

    '========================================================
    ' BOTÓN GUARDAR
    '========================================================
    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs) Handles btnGuardar.Click

        If Not ValidarDatos() Then Exit Sub

        Try

            Using conexion As MySqlConnection =
                ConexionBD.ObtenerConexion()

                conexion.Open()

                Dim sql As String

                '--------------------------------------------
                ' NUEVO INSTRUCTOR
                '--------------------------------------------
                If modoNuevo Then

                    sql =
                        "INSERT INTO instructores " &
                        "(cedula, nombres, apellidos, especialidad, telefono, correo, fecha_contratacion, activo) " &
                        "VALUES (@cedula, @nombres, @apellidos, @especialidad, @telefono, @correo, @fecha, @activo)"

                Else

                    '----------------------------------------
                    ' EDITAR INSTRUCTOR
                    '----------------------------------------
                    sql =
                        "UPDATE instructores SET " &
                        "cedula = @cedula, " &
                        "nombres = @nombres, " &
                        "apellidos = @apellidos, " &
                        "especialidad = @especialidad, " &
                        "telefono = @telefono, " &
                        "correo = @correo, " &
                        "fecha_contratacion = @fecha, " &
                        "activo = @activo " &
                        "WHERE id_instructor = @id"

                End If

                Using comando As New MySqlCommand(sql, conexion)

                    comando.Parameters.AddWithValue(
                        "@cedula",
                        txtCedula.Text.Trim())

                    comando.Parameters.AddWithValue(
                        "@nombres",
                        txtNombres.Text.Trim())

                    comando.Parameters.AddWithValue(
                        "@apellidos",
                        txtApellido.Text.Trim())

                    comando.Parameters.AddWithValue(
                        "@especialidad",
                        txtEspecialidad.Text.Trim())

                    comando.Parameters.AddWithValue(
                        "@telefono",
                        txtTelefono.Text.Trim())

                    comando.Parameters.AddWithValue(
                        "@correo",
                        txtCorreo.Text.Trim())

                    comando.Parameters.AddWithValue(
                        "@fecha",
                        dtpFechaContratacion.Value.Date)

                    comando.Parameters.AddWithValue(
                        "@activo",
                        chkInstructor.Checked)

                    If Not modoNuevo Then

                        comando.Parameters.AddWithValue(
                            "@id",
                            idInstructorSeleccionado)

                    End If

                    comando.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Instructor guardado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            modoNuevo = False

            LimpiarCampos()
            CargarInstructores()
            CambiarModo(False)

        Catch ex As Exception

            MessageBox.Show(
                "Error al guardar el instructor:" &
                vbCrLf & vbCrLf &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    '========================================================
    ' BOTÓN ELIMINAR / DESACTIVAR
    '========================================================
    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs) Handles btnEliminar.Click

        If idInstructorSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un instructor primero.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Exit Sub

        End If

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de desactivar este instructor?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If respuesta <> DialogResult.Yes Then Exit Sub

        Try

            Using conexion As MySqlConnection =
                ConexionBD.ObtenerConexion()

                conexion.Open()

                Dim sql As String =
                    "UPDATE instructores " &
                    "SET activo = 0 " &
                    "WHERE id_instructor = @id"

                Using comando As New MySqlCommand(sql, conexion)

                    comando.Parameters.AddWithValue(
                        "@id",
                        idInstructorSeleccionado)

                    comando.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Instructor desactivado correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            modoNuevo = False

            LimpiarCampos()
            CargarInstructores()
            CambiarModo(False)

        Catch ex As Exception

            MessageBox.Show(
                "Error al desactivar el instructor:" &
                vbCrLf & vbCrLf &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    '========================================================
    ' BOTÓN BUSCAR
    '========================================================
    Private Sub btnBuscar_Click(
        sender As Object,
        e As EventArgs) Handles btnBuscar.Click

        BuscarInstructor()

    End Sub

    '========================================================
    ' BUSCAR
    '========================================================
    Private Sub BuscarInstructor()

        Try

            Using conexion As MySqlConnection =
                ConexionBD.ObtenerConexion()

                conexion.Open()

                Dim sql As String =
                    "SELECT id_instructor, cedula, nombres, apellidos, " &
                    "especialidad, telefono, correo, fecha_contratacion, activo " &
                    "FROM instructores " &
                    "WHERE cedula LIKE @buscar " &
                    "OR nombres LIKE @buscar " &
                    "OR apellidos LIKE @buscar " &
                    "OR especialidad LIKE @buscar " &
                    "ORDER BY apellidos, nombres"

                Using comando As New MySqlCommand(sql, conexion)

                    comando.Parameters.AddWithValue(
                        "@buscar",
                        "%" & txtBuscar.Text.Trim() & "%")

                    Using adaptador As New MySqlDataAdapter(comando)

                        Dim tabla As New DataTable()

                        adaptador.Fill(tabla)

                        dgvInstructores.DataSource = tabla

                    End Using

                End Using

            End Using

            ActualizarTotal()

        Catch ex As Exception

            MessageBox.Show(
                "Error al realizar la búsqueda:" &
                vbCrLf & vbCrLf &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    '========================================================
    ' ENTER EN BUSCAR
    '========================================================
    Private Sub txtBuscar_KeyDown(
        sender As Object,
        e As KeyEventArgs) Handles txtBuscar.KeyDown

        If e.KeyCode = Keys.Enter Then

            BuscarInstructor()

            e.SuppressKeyPress = True

        End If

    End Sub

End Class