Public Class frmSocios

    'Fuente de datos para los socios
    Private bsSocios As New BindingSource()

    'Navegador de registros
    Private bnvSocios As BindingNavigator

    'Modo actual del formulario
    Private modoActual As String = "Consulta"




    Private Sub ConfigurarDataGridView()

        With dgvSocios

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoGenerateColumns = False

        End With

    End Sub


    Private Sub CrearBindingNavigator()

        bnvSocios = New BindingNavigator(True)

        With bnvSocios

            .Name = "bnvSocios"
            .BindingSource = bsSocios
            .Dock = DockStyle.None
            .Location = New Point(dgvSocios.Left, dgvSocios.Top - 30)
            .Width = dgvSocios.Width

        End With

        Me.Controls.Add(bnvSocios)

    End Sub


    Private Sub ActualizarEstado()

        'Actualizamos el StatusStrip
        If stsEstado IsNot Nothing Then

            stsEstado.Items.Clear()

            Dim item As New ToolStripStatusLabel()

            item.Text = "Modo: " & modoActual

            stsEstado.Items.Add(item)

        End If

    End Sub
    Private Sub frmSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfigurarDataGridView()
        CrearBindingNavigator()
        CargarDatosPrueba()

        modoActual = "Consulta"
        ActualizarEstado()

    End Sub
    Private Sub CargarDatosPrueba()

        Dim tabla As New DataTable()

        tabla.Columns.Add("ID", GetType(Integer))
        tabla.Columns.Add("Cédula", GetType(String))
        tabla.Columns.Add("Nombres", GetType(String))
        tabla.Columns.Add("Apellidos", GetType(String))
        tabla.Columns.Add("Teléfono", GetType(String))
        tabla.Columns.Add("Estado", GetType(String))

        tabla.Rows.Add(1, "001-010101-0001A", "Carlos", "Pérez", "8888-1111", "Activo")
        tabla.Rows.Add(2, "001-020202-0002B", "María", "López", "8888-2222", "Activo")
        tabla.Rows.Add(3, "001-030303-0003C", "Juan", "Gómez", "8888-3333", "Inactivo")

        bsSocios.DataSource = tabla
        dgvSocios.DataSource = bsSocios

    End Sub
    Private Function ValidarDatos() As Boolean

        errSocios.Clear()

        Dim valido As Boolean = True

        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            errSocios.SetError(txtNombre, "El nombre es obligatorio.")
            valido = False
        End If

        If String.IsNullOrWhiteSpace(txtApellido.Text) Then
            errSocios.SetError(txtApellido, "El apellido es obligatorio.")
            valido = False
        End If

        If String.IsNullOrWhiteSpace(txtCedula.Text) Then
            errSocios.SetError(txtCedula, "La cédula es obligatoria.")
            valido = False
        End If

        If Not valido Then
            MessageBox.Show("Complete los campos obligatorios.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End If

        Return valido

    End Function

    Private Sub grpDatos_Enter(sender As Object, e As EventArgs) Handles grpDatos.Enter

    End Sub
    Private Sub btnVerMembresias_Click(
    sender As Object,
    e As EventArgs
) Handles btnVerMembresias.Click

        Dim formulario As New frmMembresiasPagos()
        formulario.ShowDialog()
    End Sub
End Class