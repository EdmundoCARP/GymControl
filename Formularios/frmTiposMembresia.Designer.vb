<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiposMembresia
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
        lblNombre = New Label()
        lblDuracion = New Label()
        lblPrecio = New Label()
        lblDescripcion = New Label()
        txtNombre = New TextBox()
        txtPrecio = New TextBox()
        txtDuracion = New TextBox()
        txtDescripcion = New TextBox()
        chkActivo = New CheckBox()
        chkIncluyeClases = New CheckBox()
        btnNuevo = New Button()
        btnGuardar = New Button()
        dgvTipos = New DataGridView()
        lblTiposMembresia = New Label()
        CType(dgvTipos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblNombre
        ' 
        lblNombre.AutoSize = True
        lblNombre.Location = New Point(124, 61)
        lblNombre.Name = "lblNombre"
        lblNombre.Size = New Size(51, 15)
        lblNombre.TabIndex = 0
        lblNombre.Text = "Nombre"
        ' 
        ' lblDuracion
        ' 
        lblDuracion.AutoSize = True
        lblDuracion.Location = New Point(124, 97)
        lblDuracion.Name = "lblDuracion"
        lblDuracion.Size = New Size(55, 15)
        lblDuracion.TabIndex = 1
        lblDuracion.Text = "Duracion"
        ' 
        ' lblPrecio
        ' 
        lblPrecio.AutoSize = True
        lblPrecio.Location = New Point(135, 171)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New Size(40, 15)
        lblPrecio.TabIndex = 2
        lblPrecio.Text = "Precio"
        ' 
        ' lblDescripcion
        ' 
        lblDescripcion.AutoSize = True
        lblDescripcion.Location = New Point(124, 136)
        lblDescripcion.Name = "lblDescripcion"
        lblDescripcion.Size = New Size(69, 15)
        lblDescripcion.TabIndex = 3
        lblDescripcion.Text = "Descripcion"
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(199, 58)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(100, 23)
        txtNombre.TabIndex = 4
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Location = New Point(181, 171)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.Size = New Size(100, 23)
        txtPrecio.TabIndex = 5
        ' 
        ' txtDuracion
        ' 
        txtDuracion.Location = New Point(199, 94)
        txtDuracion.Name = "txtDuracion"
        txtDuracion.Size = New Size(100, 23)
        txtDuracion.TabIndex = 6
        ' 
        ' txtDescripcion
        ' 
        txtDescripcion.Location = New Point(199, 136)
        txtDescripcion.Name = "txtDescripcion"
        txtDescripcion.Size = New Size(100, 23)
        txtDescripcion.TabIndex = 7
        ' 
        ' chkActivo
        ' 
        chkActivo.AutoSize = True
        chkActivo.Location = New Point(135, 200)
        chkActivo.Name = "chkActivo"
        chkActivo.Size = New Size(60, 19)
        chkActivo.TabIndex = 8
        chkActivo.Text = "Activo"
        chkActivo.UseVisualStyleBackColor = True
        ' 
        ' chkIncluyeClases
        ' 
        chkIncluyeClases.AutoSize = True
        chkIncluyeClases.Location = New Point(202, 200)
        chkIncluyeClases.Name = "chkIncluyeClases"
        chkIncluyeClases.Size = New Size(97, 19)
        chkIncluyeClases.TabIndex = 9
        chkIncluyeClases.Text = "IncluyeClases"
        chkIncluyeClases.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(124, 234)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 10
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(215, 234)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 11
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' dgvTipos
        ' 
        dgvTipos.AllowUserToAddRows = False
        dgvTipos.AllowUserToDeleteRows = False
        dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTipos.Location = New Point(-2, 274)
        dgvTipos.MultiSelect = False
        dgvTipos.Name = "dgvTipos"
        dgvTipos.ReadOnly = True
        dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTipos.Size = New Size(469, 175)
        dgvTipos.TabIndex = 12
        ' 
        ' lblTiposMembresia
        ' 
        lblTiposMembresia.AutoSize = True
        lblTiposMembresia.Font = New Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTiposMembresia.Location = New Point(135, 9)
        lblTiposMembresia.Name = "lblTiposMembresia"
        lblTiposMembresia.Size = New Size(229, 31)
        lblTiposMembresia.TabIndex = 13
        lblTiposMembresia.Text = "Tipos de Membresia"
        ' 
        ' frmTiposMembresia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(462, 450)
        Controls.Add(lblTiposMembresia)
        Controls.Add(dgvTipos)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(chkIncluyeClases)
        Controls.Add(chkActivo)
        Controls.Add(txtDescripcion)
        Controls.Add(txtDuracion)
        Controls.Add(txtPrecio)
        Controls.Add(txtNombre)
        Controls.Add(lblDescripcion)
        Controls.Add(lblPrecio)
        Controls.Add(lblDuracion)
        Controls.Add(lblNombre)
        Name = "frmTiposMembresia"
        Text = "frmTiposMembresia"
        CType(dgvTipos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents lblDuracion As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtDuracion As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents chkActivo As CheckBox
    Friend WithEvents chkIncluyeClases As CheckBox
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents dgvTipos As DataGridView
    Friend WithEvents lblTiposMembresia As Label
End Class
