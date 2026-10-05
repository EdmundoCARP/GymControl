<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarContrasena
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
        lblActual = New Label()
        lblNueva = New Label()
        lblConfirmar = New Label()
        txtConfirmar = New TextBox()
        txtNueva = New TextBox()
        txtActual = New TextBox()
        Label1 = New Label()
        btnCambiar = New Button()
        SuspendLayout()
        ' 
        ' lblActual
        ' 
        lblActual.AutoSize = True
        lblActual.Location = New Point(108, 152)
        lblActual.Name = "lblActual"
        lblActual.Size = New Size(104, 15)
        lblActual.TabIndex = 0
        lblActual.Text = "Contrasena Actual"
        ' 
        ' lblNueva
        ' 
        lblNueva.AutoSize = True
        lblNueva.Location = New Point(108, 211)
        lblNueva.Name = "lblNueva"
        lblNueva.Size = New Size(104, 15)
        lblNueva.TabIndex = 1
        lblNueva.Text = "Contrasena Nueva"
        ' 
        ' lblConfirmar
        ' 
        lblConfirmar.AutoSize = True
        lblConfirmar.Location = New Point(108, 273)
        lblConfirmar.Name = "lblConfirmar"
        lblConfirmar.Size = New Size(124, 15)
        lblConfirmar.TabIndex = 2
        lblConfirmar.Text = "Confirmar Contrasena"
        ' 
        ' txtConfirmar
        ' 
        txtConfirmar.Location = New Point(238, 273)
        txtConfirmar.Name = "txtConfirmar"
        txtConfirmar.Size = New Size(100, 23)
        txtConfirmar.TabIndex = 3
        txtConfirmar.UseSystemPasswordChar = True
        ' 
        ' txtNueva
        ' 
        txtNueva.Location = New Point(235, 208)
        txtNueva.Name = "txtNueva"
        txtNueva.Size = New Size(100, 23)
        txtNueva.TabIndex = 4
        txtNueva.UseSystemPasswordChar = True
        ' 
        ' txtActual
        ' 
        txtActual.Location = New Point(235, 152)
        txtActual.Name = "txtActual"
        txtActual.Size = New Size(100, 23)
        txtActual.TabIndex = 5
        txtActual.UseSystemPasswordChar = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(146, 46)
        Label1.Name = "Label1"
        Label1.Size = New Size(229, 31)
        Label1.TabIndex = 6
        Label1.Text = "Cambiar Contrasena"
        ' 
        ' btnCambiar
        ' 
        btnCambiar.Location = New Point(238, 344)
        btnCambiar.Name = "btnCambiar"
        btnCambiar.Size = New Size(75, 23)
        btnCambiar.TabIndex = 7
        btnCambiar.Text = "Cambiar"
        btnCambiar.UseVisualStyleBackColor = True
        ' 
        ' frmCambiarContrasena
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(509, 450)
        Controls.Add(btnCambiar)
        Controls.Add(Label1)
        Controls.Add(txtActual)
        Controls.Add(txtNueva)
        Controls.Add(txtConfirmar)
        Controls.Add(lblConfirmar)
        Controls.Add(lblNueva)
        Controls.Add(lblActual)
        Name = "frmCambiarContrasena"
        Text = "frmCambiarContrasena"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblActual As Label
    Friend WithEvents lblNueva As Label
    Friend WithEvents lblConfirmar As Label
    Friend WithEvents txtConfirmar As TextBox
    Friend WithEvents txtNueva As TextBox
    Friend WithEvents txtActual As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCambiar As Button
End Class
