<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActividades
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
        txtNombre = New TextBox()
        txtDescripcion = New TextBox()
        txtCupo = New TextBox()
        txtDuracion = New TextBox()
        chkActivo = New CheckBox()
        btnGuardar = New Button()
        btnNuevo = New Button()
        dgvActividades = New DataGridView()
        lblNombre = New Label()
        lblDescripcion = New Label()
        lblCupo = New Label()
        lblDuracion = New Label()
        lblActividades = New Label()
        CType(dgvActividades, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(232, 49)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(100, 23)
        txtNombre.TabIndex = 0
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(232, 86)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(100, 23)
        txtDescripcion.TabIndex = 1
        ' 
        ' txtCupo
        ' 
        txtCupo.Location = New Point(232, 122)
        txtCupo.Name = "txtCupo"
        txtCupo.Size = New Size(100, 23)
        txtCupo.TabIndex = 2
        ' 
        ' txtDuracion
        ' 
        txtDuracion.Location = New Point(232, 162)
        txtDuracion.Name = "txtDuracion"
        txtDuracion.Size = New Size(100, 23)
        txtDuracion.TabIndex = 3
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Location = New Point(171, 191)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(60, 19)
        chkActivo.TabIndex = 4
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(232, 216)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 5
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(330, 216)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 6
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' dgvActividades
        ' 
        dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvActividades.Location = New Point(1, 245)
        dgvActividades.Name = "dgvActividades"
        dgvActividades.Size = New Size(541, 200)
        dgvActividades.TabIndex = 7
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New Point(171, 56)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(51, 15)
        lblNombre.TabIndex = 8
        lblNombre.Text = "Nombre"
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoSize = True
        lblDescripcion.Location = New Point(153, 94)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(69, 15)
        lblDescripcion.TabIndex = 9
        lblDescripcion.Text = "Descripcion"
        ' 
        ' lblCupo
        ' 
        lblCupo.AutoSize = True
        lblCupo.Location = New Point(186, 122)
        lblCupo.Name = "lblCupo"
        lblCupo.Size = New Size(36, 15)
        lblCupo.TabIndex = 10
        lblCupo.Text = "Cupo"
        ' 
        ' lblDuracion
        ' 
        lblDuracion.AutoSize = True
        lblDuracion.Location = New Point(171, 165)
        lblDuracion.Name = "lblDuracion"
        lblDuracion.Size = New Size(55, 15)
        lblDuracion.TabIndex = 11
        lblDuracion.Text = "Duracion"
        ' 
        ' lblActividades
        ' 
        lblActividades.AutoSize = True
        lblActividades.Font = New Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActividades.Location = New Point(215, 9)
        lblActividades.Name = "lblActividades"
        lblActividades.Size = New Size(138, 31)
        lblActividades.TabIndex = 12
        lblActividades.Text = "Actividades"
        ' 
        ' frmActividades
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(542, 450)
        Controls.Add(lblActividades)
        Controls.Add(lblDuracion)
        Controls.Add(lblCupo)
        Controls.Add(lblDescripcion)
        Controls.Add(lblNombre)
        Controls.Add(dgvActividades)
        Controls.Add(btnNuevo)
        Controls.Add(btnGuardar)
        Controls.Add(chkActivo)
        Controls.Add(txtDuracion)
        Controls.Add(txtCupo)
        Controls.Add(txtDescripcion)
        Controls.Add(txtNombre)
        Name = "frmActividades"
        Text = "frmActividades"
        CType(dgvActividades, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtCupo As TextBox
    Friend WithEvents txtDuracion As TextBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvActividades As DataGridView
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblCupo As Label
    Friend WithEvents lblDuracion As Label
    Friend WithEvents lblActividades As Label
End Class
