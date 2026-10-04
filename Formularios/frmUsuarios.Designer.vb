<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        txtUsuario = New TextBox()
        txtContrasena = New TextBox()
        cborol = New ComboBox()
        chkActivo = New CheckBox()
        dgvUsuarios = New DataGridView()
        btnNuevo = New Button()
        btnGuardar = New Button()
        btnDesbloquear = New Button()
        btnEditar = New Button()
        btnRestablecer = New Button()
        lblUsuario = New Label()
        lblrol = New Label()
        lblContrasena = New Label()
        lblEstado = New Label()
        lblGestionDeUsuarios = New Label()
        CType(dgvUsuarios, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(89, 93)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(100, 23)
        txtUsuario.TabIndex = 0
        ' 
        ' txtContrasena
        ' 
        txtContrasena.Location = New Point(89, 124)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.Size = New Size(100, 23)
        txtContrasena.TabIndex = 1
        txtContrasena.UseSystemPasswordChar = True
        ' 
        ' cborol
        ' 
        cborol.DropDownStyle = ComboBoxStyle.DropDownList
        cborol.FormattingEnabled = True
        cborol.Location = New Point(89, 163)
        cborol.Name = "cborol"
        cborol.Size = New Size(121, 23)
        cborol.TabIndex = 2
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Checked = True
        chkActivo.CheckState = CheckState.Checked
        chkActivo.Location = New Point(89, 205)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(60, 19)
        chkActivo.TabIndex = 3
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' dgvUsuarios
        ' 
        dgvUsuarios.AllowUserToAddRows = False
        dgvUsuarios.AllowUserToDeleteRows = False
        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsuarios.Location = New Point(2, 241)
        dgvUsuarios.MultiSelect = False
        dgvUsuarios.Name = "dgvUsuarios"
        dgvUsuarios.ReadOnly = True
        dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsuarios.Size = New Size(799, 209)
        dgvUsuarios.TabIndex = 4
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(242, 132)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 5
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(288, 186)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 6
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnDesbloquear
        ' 
        btnDesbloquear.Location = New Point(400, 186)
        btnDesbloquear.Name = "btnDesbloquear"
        btnDesbloquear.Size = New Size(92, 23)
        btnDesbloquear.TabIndex = 7
        btnDesbloquear.Text = "Desbloquear"
        btnDesbloquear.UseVisualStyleBackColor = True
        ' 
        ' btnEditar
        ' 
        btnEditar.Location = New Point(346, 132)
        btnEditar.Name = "btnEditar"
        btnEditar.Size = New Size(75, 23)
        btnEditar.TabIndex = 8
        btnEditar.Text = "Editar"
        btnEditar.UseVisualStyleBackColor = True
        ' 
        ' btnRestablecer
        ' 
        btnRestablecer.Location = New Point(453, 132)
        btnRestablecer.Name = "btnRestablecer"
        btnRestablecer.Size = New Size(75, 23)
        btnRestablecer.TabIndex = 9
        btnRestablecer.Text = "Restablecer"
        btnRestablecer.UseVisualStyleBackColor = True
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Location = New Point(27, 101)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(47, 15)
        lblUsuario.TabIndex = 10
        lblUsuario.Text = "Usuario"
        ' 
        ' lblrol
        ' 
        lblrol.AutoSize = True
        lblrol.Location = New Point(50, 166)
        lblrol.Name = "lblrol"
        lblrol.Size = New Size(24, 15)
        lblrol.TabIndex = 11
        lblrol.Text = "Rol"
        ' 
        ' lblContrasena
        ' 
        lblContrasena.AutoSize = True
        lblContrasena.Location = New Point(12, 132)
        lblContrasena.Name = "lblContrasena"
        lblContrasena.Size = New Size(67, 15)
        lblContrasena.TabIndex = 12
        lblContrasena.Text = "Contrasena"
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(27, 206)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(42, 15)
        lblEstado.TabIndex = 13
        lblEstado.Text = "Estado"
        ' 
        ' lblGestionDeUsuarios
        ' 
        lblGestionDeUsuarios.AutoSize = True
        lblGestionDeUsuarios.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGestionDeUsuarios.Location = New Point(192, 9)
        lblGestionDeUsuarios.Name = "lblGestionDeUsuarios"
        lblGestionDeUsuarios.Size = New Size(208, 30)
        lblGestionDeUsuarios.TabIndex = 14
        lblGestionDeUsuarios.Text = "Gestion de Usuarios"
        ' 
        ' frmUsuarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(798, 450)
        Controls.Add(lblGestionDeUsuarios)
        Controls.Add(lblEstado)
        Controls.Add(lblContrasena)
        Controls.Add(lblrol)
        Controls.Add(lblUsuario)
        Controls.Add(btnRestablecer)
        Controls.Add(btnEditar)
        Controls.Add(btnDesbloquear)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(dgvUsuarios)
        Controls.Add(chkActivo)
        Controls.Add(cborol)
        Controls.Add(txtContrasena)
        Controls.Add(txtUsuario)
        Name = "frmUsuarios"
        Text = "frmUsuarios"
        CType(dgvUsuarios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents cborol As ComboBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnDesbloquear As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents btnRestablecer As Button
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblrol As Label
    Friend WithEvents lblContrasena As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblGestionDeUsuarios As Label
End Class
