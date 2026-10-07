<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSocios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        btnNuevo = New Button()
        btnEditar = New Button()
        btnGuardar = New Button()
        btnEliminar = New Button()
        btnCancelar = New Button()
        cboEstado = New ComboBox()
        txtBuscar = New TextBox()
        lblBuscar = New Label()
        grpDatos = New GroupBox()
        lblCamposObligatorios = New Label()
        txtDireccion = New TextBox()
        lblDireccion = New Label()
        txtCorreo = New TextBox()
        lblCorreo = New Label()
        txtTelefono = New TextBox()
        lblTelefono = New Label()
        cboGenero = New ComboBox()
        lblGenero = New Label()
        lblFechaNacimiento = New Label()
        dtpFechaNacimiento = New DateTimePicker()
        txtApellido = New TextBox()
        lblApellidos = New Label()
        txtNombre = New TextBox()
        lblNombres = New Label()
        txtCedula = New TextBox()
        lblCedula = New Label()
        btnBuscar = New Button()
        grpCuenta = New GroupBox()
        btnVerMembresias = New Button()
        btnRestablecerContrasena = New Button()
        TextBox1 = New TextBox()
        lblUsuario = New Label()
        chkTieneCuenta = New CheckBox()
        stsEstado = New StatusStrip()
        dgvSocios = New DataGridView()
        errSocios = New ErrorProvider(components)
        grpDatos.SuspendLayout()
        grpCuenta.SuspendLayout()
        CType(dgvSocios, ComponentModel.ISupportInitialize).BeginInit()
        CType(errSocios, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(12, 12)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(94, 12)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(75, 23)
        btnEditar.TabIndex = 1
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.Blue
        btnGuardar.ForeColor = SystemColors.Control
        btnGuardar.Location = New Point(175, 12)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 2
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.Red
        btnEliminar.ForeColor = SystemColors.Control
        btnEliminar.Location = New Point(256, 12)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(75, 23)
        btnEliminar.TabIndex = 3
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(337, 12)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(75, 23)
        btnCancelar.TabIndex = 4
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' cboEstado
        ' 
        cboEstado.FormattingEnabled = True
        cboEstado.Location = New Point(854, 17)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(121, 23)
        cboEstado.TabIndex = 6
        cboEstado.Text = "Estado :"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(652, 16)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "cedula,  nombre o apellido"
        txtBuscar.Size = New Size(185, 23)
        txtBuscar.TabIndex = 7
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(601, 20)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(45, 15)
        lblBuscar.TabIndex = 8
        lblBuscar.Text = "Buscar:"
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(lblCamposObligatorios)
        grpDatos.Controls.Add(txtDireccion)
        grpDatos.Controls.Add(lblDireccion)
        grpDatos.Controls.Add(txtCorreo)
        grpDatos.Controls.Add(lblCorreo)
        grpDatos.Controls.Add(txtTelefono)
        grpDatos.Controls.Add(lblTelefono)
        grpDatos.Controls.Add(cboGenero)
        grpDatos.Controls.Add(lblGenero)
        grpDatos.Controls.Add(lblFechaNacimiento)
        grpDatos.Controls.Add(dtpFechaNacimiento)
        grpDatos.Controls.Add(txtApellido)
        grpDatos.Controls.Add(lblApellidos)
        grpDatos.Controls.Add(txtNombre)
        grpDatos.Controls.Add(lblNombres)
        grpDatos.Controls.Add(txtCedula)
        grpDatos.Controls.Add(lblCedula)
        grpDatos.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpDatos.Location = New Point(614, 42)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(460, 419)
        grpDatos.TabIndex = 10
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del socio"
        ' 
        ' lblCamposObligatorios
        ' 
        lblCamposObligatorios.AutoSize = True
        lblCamposObligatorios.Font = New Font("Segoe UI Light", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblCamposObligatorios.Location = New Point(9, 386)
        lblCamposObligatorios.Name = "lblCamposObligatorios"
        lblCamposObligatorios.Size = New Size(120, 15)
        lblCamposObligatorios.TabIndex = 22
        lblCamposObligatorios.Text = "* Campos Obligatorios"
        ' 
        ' txtDireccion
        ' 
        txtDireccion.Location = New Point(137, 332)
        txtDireccion.Multiline = True
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Size = New Size(261, 30)
        txtDireccion.TabIndex = 21
        ' 
        ' lblDireccion
        ' 
        lblDireccion.AutoSize = True
        lblDireccion.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDireccion.Location = New Point(12, 332)
        lblDireccion.Name = "lblDireccion"
        lblDireccion.Size = New Size(57, 15)
        lblDireccion.TabIndex = 20
        lblDireccion.Text = "Direccion"
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(137, 286)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(261, 23)
        txtCorreo.TabIndex = 19
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCorreo.Location = New Point(12, 286)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(43, 15)
        lblCorreo.TabIndex = 18
        lblCorreo.Text = "Correo"
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(137, 237)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(130, 23)
        txtTelefono.TabIndex = 17
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Font = New Font("Segoe UI", 9F)
        lblTelefono.Location = New Point(12, 240)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(53, 15)
        lblTelefono.TabIndex = 16
        lblTelefono.Text = "Telefono"
        ' 
        ' cboGenero
        ' 
        cboGenero.DropDownStyle = ComboBoxStyle.DropDownList
        cboGenero.FormattingEnabled = True
        cboGenero.Items.AddRange(New Object() {"F", "M"})
        cboGenero.Location = New Point(323, 180)
        cboGenero.Name = "cboGenero"
        cboGenero.Size = New Size(121, 23)
        cboGenero.TabIndex = 15
        ' 
        ' lblGenero
        ' 
        lblGenero.AutoSize = True
        lblGenero.Font = New Font("Segoe UI", 9F)
        lblGenero.Location = New Point(267, 186)
        lblGenero.Name = "lblGenero"
        lblGenero.Size = New Size(45, 15)
        lblGenero.TabIndex = 14
        lblGenero.Text = "Genero"
        ' 
        ' lblFechaNacimiento
        ' 
        lblFechaNacimiento.AutoSize = True
        lblFechaNacimiento.Font = New Font("Segoe UI", 9F)
        lblFechaNacimiento.Location = New Point(12, 186)
        lblFechaNacimiento.Name = "lblFechaNacimiento"
        lblFechaNacimiento.Size = New Size(117, 15)
        lblFechaNacimiento.TabIndex = 13
        lblFechaNacimiento.Text = "Fecha de nacimiento"
        ' 
        ' dtpFechaNacimiento
        ' 
        dtpFechaNacimiento.Font = New Font("Segoe UI", 9F)
        dtpFechaNacimiento.Format = DateTimePickerFormat.Short
        dtpFechaNacimiento.Location = New Point(148, 180)
        dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        dtpFechaNacimiento.Size = New Size(113, 23)
        dtpFechaNacimiento.TabIndex = 12
        ' 
        ' txtApellido
        ' 
        txtApellido.Location = New Point(148, 128)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(213, 23)
        txtApellido.TabIndex = 5
        ' 
        ' lblApellidos
        ' 
        lblApellidos.AutoSize = True
        lblApellidos.Font = New Font("Segoe UI", 9F)
        lblApellidos.Location = New Point(12, 136)
        lblApellidos.Name = "lblApellidos"
        lblApellidos.Size = New Size(64, 15)
        lblApellidos.TabIndex = 4
        lblApellidos.Text = "Apellidos *"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(148, 79)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(213, 23)
        txtNombre.TabIndex = 3
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.Font = New Font("Segoe UI", 9F)
        lblNombres.Location = New Point(12, 87)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(64, 15)
        lblNombres.TabIndex = 2
        lblNombres.Text = "Nombres *"
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(148, 26)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(213, 23)
        txtCedula.TabIndex = 1
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Font = New Font("Segoe UI", 9F)
        lblCedula.Location = New Point(12, 29)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(52, 15)
        lblCedula.TabIndex = 0
        lblCedula.Text = "Cedula *"
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(983, 17)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(75, 23)
        btnBuscar.TabIndex = 11
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' grpCuenta
        ' 
        grpCuenta.Controls.Add(btnVerMembresias)
        grpCuenta.Controls.Add(btnRestablecerContrasena)
        grpCuenta.Controls.Add(TextBox1)
        grpCuenta.Controls.Add(lblUsuario)
        grpCuenta.Controls.Add(chkTieneCuenta)
        grpCuenta.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpCuenta.Location = New Point(614, 467)
        grpCuenta.Name = "grpCuenta"
        grpCuenta.Size = New Size(460, 154)
        grpCuenta.TabIndex = 12
        grpCuenta.TabStop = False
        grpCuenta.Text = "Cuenta de acceso al portal"
        ' 
        ' btnVerMembresias
        ' 
        btnVerMembresias.Font = New Font("Segoe UI", 9F)
        btnVerMembresias.Location = New Point(267, 103)
        btnVerMembresias.Name = "btnVerMembresias"
        btnVerMembresias.Size = New Size(168, 36)
        btnVerMembresias.TabIndex = 4
        btnVerMembresias.Text = "Ver membresias del socio"
        btnVerMembresias.UseVisualStyleBackColor = True
        ' 
        ' btnRestablecerContrasena
        ' 
        btnRestablecerContrasena.Font = New Font("Segoe UI", 9F)
        btnRestablecerContrasena.Location = New Point(50, 103)
        btnRestablecerContrasena.Name = "btnRestablecerContrasena"
        btnRestablecerContrasena.Size = New Size(168, 36)
        btnRestablecerContrasena.TabIndex = 3
        btnRestablecerContrasena.Text = "Restablecer Contraseña"
        btnRestablecerContrasena.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(148, 57)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(296, 23)
        TextBox1.TabIndex = 2
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Location = New Point(18, 62)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(49, 15)
        lblUsuario.TabIndex = 1
        lblUsuario.Text = "Usuario"
        ' 
        ' chkTieneCuenta
        ' 
        chkTieneCuenta.AutoSize = True
        chkTieneCuenta.Location = New Point(12, 32)
        chkTieneCuenta.Name = "chkTieneCuenta"
        chkTieneCuenta.Size = New Size(196, 19)
        chkTieneCuenta.TabIndex = 0
        chkTieneCuenta.Text = "El socio tiene cuenta de acceso"
        chkTieneCuenta.UseVisualStyleBackColor = True
        ' 
        ' stsEstado
        ' 
        stsEstado.Location = New Point(0, 641)
        stsEstado.Name = "stsEstado"
        stsEstado.Size = New Size(1086, 22)
        stsEstado.TabIndex = 13
        ' 
        ' dgvSocios
        ' 
        dgvSocios.AllowUserToAddRows = False
        dgvSocios.AllowUserToDeleteRows = False
        dgvSocios.AllowUserToResizeColumns = False
        dgvSocios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSocios.BackgroundColor = SystemColors.ButtonFace
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvSocios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvSocios.DefaultCellStyle = DataGridViewCellStyle2
        dgvSocios.Location = New Point(12, 84)
        dgvSocios.MultiSelect = False
        dgvSocios.Name = "dgvSocios"
        dgvSocios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvSocios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSocios.Size = New Size(584, 537)
        dgvSocios.TabIndex = 14
        ' 
        ' errSocios
        ' 
        errSocios.ContainerControl = Me
        ' 
        ' frmSocios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1086, 663)
        Controls.Add(dgvSocios)
        Controls.Add(stsEstado)
        Controls.Add(grpCuenta)
        Controls.Add(btnBuscar)
        Controls.Add(grpDatos)
        Controls.Add(lblBuscar)
        Controls.Add(txtBuscar)
        Controls.Add(cboEstado)
        Controls.Add(btnCancelar)
        Controls.Add(btnEliminar)
        Controls.Add(btnGuardar)
        Controls.Add(btnEditar)
        Controls.Add(btnNuevo)
        Font = New Font("Segoe UI", 9F)
        Name = "frmSocios"
        Text = "Gestion de socios"
        grpDatos.ResumeLayout(False)
        grpDatos.PerformLayout()
        grpCuenta.ResumeLayout(False)
        grpCuenta.PerformLayout()
        CType(dgvSocios, ComponentModel.ISupportInitialize).EndInit()
        CType(errSocios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblCedula As Label
    Friend WithEvents lblNombres As Label
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents dtpFechaNacimiento As DateTimePicker
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents lblApellidos As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents lblTelefono As Label
    Friend WithEvents cboGenero As ComboBox
    Friend WithEvents lblGenero As Label
    Friend WithEvents lblFechaNacimiento As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents lblDireccion As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents lblCorreo As Label
    Friend WithEvents lblCamposObligatorios As Label
    Friend WithEvents grpCuenta As GroupBox
    Friend WithEvents btnRestablecerContrasena As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents chkTieneCuenta As CheckBox
    Friend WithEvents btnVerMembresias As Button
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents dgvSocios As DataGridView
    Friend WithEvents errSocios As ErrorProvider
End Class
