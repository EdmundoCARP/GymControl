<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstructores
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
        btnNuevo = New Button()
        btnEliminar = New Button()
        btnEditar = New Button()
        btnGuardar = New Button()
        btnCancelar = New Button()
        lblBuscar = New Label()
        txtBuscar = New TextBox()
        btnBuscar = New Button()
        dgvInstructores = New DataGridView()
        grpDatos = New GroupBox()
        lblCedula = New Label()
        lblNombres = New Label()
        lblApellidos = New Label()
        lblTelefono = New Label()
        lblCorreo = New Label()
        lblEspecialidad = New Label()
        lblFechaContra = New Label()
        txtCedula = New TextBox()
        txtNombres = New TextBox()
        txtApellido = New TextBox()
        txtTelefono = New TextBox()
        txtCorreo = New TextBox()
        txtEspecialidad = New TextBox()
        dtpFechaContratacion = New DateTimePicker()
        chkInstructor = New CheckBox()
        errValidacion = New ErrorProvider(components)
        stsEstado = New StatusStrip()
        lblTotal = New ToolStripStatusLabel()
        CType(dgvInstructores, ComponentModel.ISupportInitialize).BeginInit()
        grpDatos.SuspendLayout()
        CType(errValidacion, ComponentModel.ISupportInitialize).BeginInit()
        stsEstado.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnNuevo
        ' 
        btnNuevo.BackColor = Color.CornflowerBlue
        btnNuevo.Location = New Point(12, 12)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 0
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = False
        ' 
        ' btnEliminar
        ' 
        btnEliminar.BackColor = Color.DarkSalmon
        btnEliminar.Location = New Point(316, 12)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(75, 23)
        btnEliminar.TabIndex = 1
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = False
        ' 
        ' btnEditar
        ' 
        btnEditar.BackColor = Color.Coral
        btnEditar.Location = New Point(112, 12)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(75, 23)
        btnEditar.TabIndex = 2
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.Cyan
        btnGuardar.Location = New Point(211, 12)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 3
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.Red
        btnCancelar.Location = New Point(413, 12)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(75, 23)
        btnCancelar.TabIndex = 4
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' lblBuscar
        ' 
        lblBuscar.AutoSize = True
        lblBuscar.Location = New Point(20, 62)
        lblBuscar.Name = "lblBuscar"
        lblBuscar.Size = New Size(48, 15)
        lblBuscar.TabIndex = 5
        lblBuscar.Text = "Buscar :"
        ' 
        ' txtBuscar
        ' 
        txtBuscar.Location = New Point(76, 59)
        txtBuscar.Name = "txtBuscar"
        txtBuscar.PlaceholderText = "Cedula o nombre"
        txtBuscar.Size = New Size(315, 23)
        txtBuscar.TabIndex = 6
        ' 
        ' btnBuscar
        ' 
        btnBuscar.Location = New Point(413, 59)
        btnBuscar.Name = "btnBuscar"
        btnBuscar.Size = New Size(75, 23)
        btnBuscar.TabIndex = 7
        btnBuscar.Text = "Buscar"
        btnBuscar.UseVisualStyleBackColor = True
        ' 
        ' dgvInstructores
        ' 
        dgvInstructores.AllowUserToAddRows = False
        dgvInstructores.AllowUserToDeleteRows = False
        dgvInstructores.AllowUserToResizeColumns = False
        dgvInstructores.AllowUserToResizeRows = False
        dgvInstructores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInstructores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstructores.Location = New Point(20, 88)
        dgvInstructores.Name = "dgvInstructores"
        dgvInstructores.ReadOnly = True
        dgvInstructores.Size = New Size(468, 483)
        dgvInstructores.TabIndex = 8
        ' 
        ' grpDatos
        ' 
        grpDatos.Controls.Add(chkInstructor)
        grpDatos.Controls.Add(dtpFechaContratacion)
        grpDatos.Controls.Add(txtEspecialidad)
        grpDatos.Controls.Add(txtCorreo)
        grpDatos.Controls.Add(txtTelefono)
        grpDatos.Controls.Add(txtApellido)
        grpDatos.Controls.Add(txtNombres)
        grpDatos.Controls.Add(txtCedula)
        grpDatos.Controls.Add(lblFechaContra)
        grpDatos.Controls.Add(lblEspecialidad)
        grpDatos.Controls.Add(lblCorreo)
        grpDatos.Controls.Add(lblTelefono)
        grpDatos.Controls.Add(lblApellidos)
        grpDatos.Controls.Add(lblNombres)
        grpDatos.Controls.Add(lblCedula)
        grpDatos.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpDatos.Location = New Point(512, 62)
        grpDatos.Name = "grpDatos"
        grpDatos.Size = New Size(363, 442)
        grpDatos.TabIndex = 9
        grpDatos.TabStop = False
        grpDatos.Text = "Datos del instructor"
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Location = New Point(8, 39)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(50, 15)
        lblCedula.TabIndex = 0
        lblCedula.Text = "Cedula :"
        ' 
        ' lblNombres
        ' 
        lblNombres.AutoSize = True
        lblNombres.Location = New Point(9, 91)
        lblNombres.Name = "lblNombres"
        lblNombres.Size = New Size(64, 15)
        lblNombres.TabIndex = 3
        lblNombres.Text = "Nombres :"
        ' 
        ' lblApellidos
        ' 
        lblApellidos.AutoSize = True
        lblApellidos.Location = New Point(9, 145)
        lblApellidos.Name = "lblApellidos"
        lblApellidos.Size = New Size(63, 15)
        lblApellidos.TabIndex = 4
        lblApellidos.Text = "Apellidos :"
        ' 
        ' lblTelefono
        ' 
        lblTelefono.AutoSize = True
        lblTelefono.Location = New Point(8, 191)
        lblTelefono.Name = "lblTelefono"
        lblTelefono.Size = New Size(62, 15)
        lblTelefono.TabIndex = 5
        lblTelefono.Text = "Telefono :"
        ' 
        ' lblCorreo
        ' 
        lblCorreo.AutoSize = True
        lblCorreo.Location = New Point(9, 238)
        lblCorreo.Name = "lblCorreo"
        lblCorreo.Size = New Size(51, 15)
        lblCorreo.TabIndex = 6
        lblCorreo.Text = "Correo :"
        ' 
        ' lblEspecialidad
        ' 
        lblEspecialidad.AutoSize = True
        lblEspecialidad.Location = New Point(8, 285)
        lblEspecialidad.Name = "lblEspecialidad"
        lblEspecialidad.Size = New Size(79, 15)
        lblEspecialidad.TabIndex = 7
        lblEspecialidad.Text = "Especialidad :"
        ' 
        ' lblFechaContra
        ' 
        lblFechaContra.AutoSize = True
        lblFechaContra.Location = New Point(8, 343)
        lblFechaContra.Name = "lblFechaContra"
        lblFechaContra.Size = New Size(135, 15)
        lblFechaContra.TabIndex = 8
        lblFechaContra.Text = "Fecha de contratacion :"
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(134, 36)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(189, 23)
        txtCedula.TabIndex = 9
        ' 
        ' txtNombres
        ' 
        txtNombres.Location = New Point(134, 88)
        txtNombres.Name = "txtNombres"
        txtNombres.Size = New Size(189, 23)
        txtNombres.TabIndex = 10
        ' 
        ' txtApellido
        ' 
        txtApellido.Location = New Point(134, 142)
        txtApellido.Name = "txtApellido"
        txtApellido.Size = New Size(189, 23)
        txtApellido.TabIndex = 11
        ' 
        ' txtTelefono
        ' 
        txtTelefono.Location = New Point(134, 188)
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Size = New Size(189, 23)
        txtTelefono.TabIndex = 12
        ' 
        ' txtCorreo
        ' 
        txtCorreo.Location = New Point(134, 235)
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Size = New Size(189, 23)
        txtCorreo.TabIndex = 13
        ' 
        ' txtEspecialidad
        ' 
        txtEspecialidad.Location = New Point(134, 282)
        txtEspecialidad.Name = "txtEspecialidad"
        txtEspecialidad.Size = New Size(189, 23)
        txtEspecialidad.TabIndex = 14
        ' 
        ' dtpFechaContratacion
        ' 
        dtpFechaContratacion.Format = DateTimePickerFormat.Short
        dtpFechaContratacion.Location = New Point(144, 337)
        dtpFechaContratacion.Name = "dtpFechaContratacion"
        dtpFechaContratacion.Size = New Size(200, 23)
        dtpFechaContratacion.TabIndex = 15
        ' 
        ' chkInstructor
        ' 
        chkInstructor.AutoSize = True
        chkInstructor.Checked = True
        chkInstructor.CheckState = CheckState.Checked
        chkInstructor.Location = New Point(149, 379)
        chkInstructor.Name = "chkInstructor"
        chkInstructor.Size = New Size(121, 19)
        chkInstructor.TabIndex = 16
        chkInstructor.Text = "Instructor Activo"
        chkInstructor.UseVisualStyleBackColor = True
        ' 
        ' errValidacion
        ' 
        errValidacion.ContainerControl = Me
        ' 
        ' stsEstado
        ' 
        stsEstado.Items.AddRange(New ToolStripItem() {lblTotal})
        stsEstado.Location = New Point(0, 599)
        stsEstado.Name = "stsEstado"
        stsEstado.Size = New Size(901, 22)
        stsEstado.TabIndex = 10
        stsEstado.Text = "Estado :"
        ' 
        ' lblTotal
        ' 
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(39, 17)
        lblTotal.Text = "Total :"
        ' 
        ' frmInstructores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(901, 621)
        Controls.Add(stsEstado)
        Controls.Add(grpDatos)
        Controls.Add(dgvInstructores)
        Controls.Add(btnBuscar)
        Controls.Add(txtBuscar)
        Controls.Add(lblBuscar)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Controls.Add(btnEditar)
        Controls.Add(btnEliminar)
        Controls.Add(btnNuevo)
        Name = "frmInstructores"
        Text = "frmInstructores"
        CType(dgvInstructores, ComponentModel.ISupportInitialize).EndInit()
        grpDatos.ResumeLayout(False)
        grpDatos.PerformLayout()
        CType(errValidacion, ComponentModel.ISupportInitialize).EndInit()
        stsEstado.ResumeLayout(False)
        stsEstado.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dgvInstructores As DataGridView
    Friend WithEvents grpDatos As GroupBox
    Friend WithEvents lblNombres As Label
    Friend WithEvents lblCedula As Label
    Friend WithEvents lblFechaContra As Label
    Friend WithEvents lblEspecialidad As Label
    Friend WithEvents lblCorreo As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblApellidos As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents dtpFechaContratacion As DateTimePicker
    Friend WithEvents txtEspecialidad As TextBox
    Friend WithEvents chkInstructor As CheckBox
    Friend WithEvents errValidacion As ErrorProvider
    Friend WithEvents stsEstado As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
End Class
