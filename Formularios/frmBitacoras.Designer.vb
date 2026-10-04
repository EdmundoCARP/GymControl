<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBitacoras
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
        dgvBitacora = New DataGridView()
        btnActualizar = New Button()
        LblBitacoras = New Label()
        CType(dgvBitacora, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvBitacora
        ' 
        dgvBitacora.AllowUserToAddRows = False
        dgvBitacora.AllowUserToDeleteRows = False
        dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBitacora.Location = New Point(-1, 226)
        dgvBitacora.MultiSelect = False
        dgvBitacora.Name = "dgvBitacora"
        dgvBitacora.ReadOnly = True
        dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBitacora.Size = New Size(801, 224)
        dgvBitacora.TabIndex = 0
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnActualizar.Location = New Point(580, 137)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(80, 23)
        btnActualizar.TabIndex = 1
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' LblBitacoras
        ' 
        LblBitacoras.AutoSize = True
        LblBitacoras.Font = New Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblBitacoras.Location = New Point(302, 27)
        LblBitacoras.Name = "LblBitacoras"
        LblBitacoras.Size = New Size(228, 31)
        LblBitacoras.TabIndex = 2
        LblBitacoras.Text = "Bitacoras De Acceso"
        ' 
        ' frmBitacoras
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LblBitacoras)
        Controls.Add(btnActualizar)
        Controls.Add(dgvBitacora)
        Name = "frmBitacoras"
        Text = "frmBitacoras"
        CType(dgvBitacora, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvBitacora As DataGridView
    Friend WithEvents btnActualizar As Button
    Friend WithEvents LblBitacoras As Label
End Class
