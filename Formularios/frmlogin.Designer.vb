<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmlogin
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
        txtcontrasena = New TextBox()
        btnIniciarSesion = New Button()
        lblUsuario = New Label()
        lblContrasena = New Label()
        SuspendLayout()
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(390, 273)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(100, 23)
        txtUsuario.TabIndex = 1
        txtUsuario.UseSystemPasswordChar = True
        ' 
        ' txtcontrasena
        ' 
        txtcontrasena.Location = New Point(390, 330)
        txtcontrasena.Name = "txtcontrasena"
        txtcontrasena.Size = New Size(100, 23)
        txtcontrasena.TabIndex = 2
        ' 
        ' btnIniciarSesion
        ' 
        btnIniciarSesion.Location = New Point(390, 375)
        btnIniciarSesion.Name = "btnIniciarSesion"
        btnIniciarSesion.Size = New Size(75, 23)
        btnIniciarSesion.TabIndex = 3
        btnIniciarSesion.Text = "Iniciar Sesion"
        btnIniciarSesion.UseVisualStyleBackColor = True
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.Location = New Point(338, 273)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(46, 15)
        lblUsuario.TabIndex = 4
        lblUsuario.Text = "usuario"
        ' 
        ' lblContrasena
        ' 
        lblContrasena.AutoSize = True
        lblContrasena.Location = New Point(317, 333)
        lblContrasena.Name = "lblContrasena"
        lblContrasena.Size = New Size(67, 15)
        lblContrasena.TabIndex = 5
        lblContrasena.Text = "Contrasena"
        ' 
        ' frmlogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblContrasena)
        Controls.Add(lblUsuario)
        Controls.Add(btnIniciarSesion)
        Controls.Add(txtcontrasena)
        Controls.Add(txtUsuario)
        Name = "frmlogin"
        Text = "frmlogin"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtcontrasena As TextBox
    Friend WithEvents btnIniciarSesion As Button
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblContrasena As Label
End Class
