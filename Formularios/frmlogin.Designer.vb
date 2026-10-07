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
        btnIngresar = New Button()
        lblUsuario = New Label()
        lblContrasena = New Label()
        chkMostrar = New CheckBox()
        lblMensaje = New Label()
        stsConexion = New StatusStrip()
        btnSalir = New Button()
        LblTitulo = New Label()
        lblSubtitulo = New Label()
        SuspendLayout()
        ' 
        ' txtUsuario
        ' 
        txtUsuario.Location = New Point(213, 148)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(100, 23)
        txtUsuario.TabIndex = 1
        txtUsuario.Text = "m"
        ' 
        ' txtcontrasena
        ' 
        txtcontrasena.Location = New Point(213, 245)
        txtcontrasena.Name = "txtcontrasena"
        txtcontrasena.Size = New Size(100, 23)
        txtcontrasena.TabIndex = 2
        ' 
        ' btnIngresar
        ' 
        btnIngresar.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnIngresar.Location = New Point(203, 340)
        btnIngresar.Name = "btnIngresar"
        btnIngresar.Size = New Size(75, 23)
        btnIngresar.TabIndex = 3
        btnIngresar.Text = "Iniciar Sesion"
        btnIngresar.UseVisualStyleBackColor = True
        ' 
        ' lblUsuario
        ' 
        lblUsuario.AutoSize = True
        lblUsuario.BorderStyle = BorderStyle.FixedSingle
        lblUsuario.Font = New Font("Segoe UI", 10.5F)
        lblUsuario.Location = New Point(213, 113)
        lblUsuario.Name = "lblUsuario"
        lblUsuario.Size = New Size(56, 21)
        lblUsuario.TabIndex = 4
        lblUsuario.Text = "usuario"
        ' 
        ' lblContrasena
        ' 
        lblContrasena.AutoSize = True
        lblContrasena.BorderStyle = BorderStyle.FixedSingle
        lblContrasena.Font = New Font("Segoe UI", 10.5F)
        lblContrasena.Location = New Point(213, 194)
        lblContrasena.Name = "lblContrasena"
        lblContrasena.Size = New Size(81, 21)
        lblContrasena.TabIndex = 5
        lblContrasena.Text = "Contrasena"
        ' 
        ' chkMostrar
        ' 
        chkMostrar.AutoSize = True
        chkMostrar.Location = New Point(203, 294)
        chkMostrar.Name = "chkMostrar"
        chkMostrar.Size = New Size(130, 19)
        chkMostrar.TabIndex = 6
        chkMostrar.Text = "Mostrar Contraseña"
        chkMostrar.UseVisualStyleBackColor = True
        ' 
        ' lblMensaje
        ' 
        lblMensaje.AutoSize = True
        lblMensaje.Location = New Point(269, 298)
        lblMensaje.Name = "lblMensaje"
        lblMensaje.Size = New Size(0, 15)
        lblMensaje.TabIndex = 7
        ' 
        ' stsConexion
        ' 
        stsConexion.Location = New Point(0, 428)
        stsConexion.Name = "stsConexion"
        stsConexion.Size = New Size(577, 22)
        stsConexion.TabIndex = 8
        stsConexion.Text = "Servidor: localhost:3306 | BD: gimnasio_db"
        ' 
        ' btnSalir
        ' 
        btnSalir.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Location = New Point(293, 340)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(75, 23)
        btnSalir.TabIndex = 9
        btnSalir.Text = "Salir"
        btnSalir.UseVisualStyleBackColor = True
        ' 
        ' LblTitulo
        ' 
        LblTitulo.AutoSize = True
        LblTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblTitulo.ForeColor = SystemColors.Highlight
        LblTitulo.Location = New Point(216, 19)
        LblTitulo.Name = "LblTitulo"
        LblTitulo.Size = New Size(152, 32)
        LblTitulo.TabIndex = 10
        LblTitulo.Text = "GymControl"
        LblTitulo.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblSubtitulo
        ' 
        lblSubtitulo.AutoSize = True
        lblSubtitulo.Font = New Font("Segoe UI Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitulo.ForeColor = Color.DimGray
        lblSubtitulo.Location = New Point(203, 69)
        lblSubtitulo.Name = "lblSubtitulo"
        lblSubtitulo.Size = New Size(205, 17)
        lblSubtitulo.TabIndex = 11
        lblSubtitulo.Text = "Gimnasio Titan . Sistema de gestion"
        lblSubtitulo.TextAlign = ContentAlignment.TopCenter
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(577, 450)
        Controls.Add(lblSubtitulo)
        Controls.Add(LblTitulo)
        Controls.Add(btnSalir)
        Controls.Add(stsConexion)
        Controls.Add(lblMensaje)
        Controls.Add(chkMostrar)
        Controls.Add(lblContrasena)
        Controls.Add(lblUsuario)
        Controls.Add(btnIngresar)
        Controls.Add(txtcontrasena)
        Controls.Add(txtUsuario)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmLogin"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtcontrasena As TextBox
    Friend WithEvents btnIngresar As Button
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblContrasena As Label
    Friend WithEvents chkMostrar As CheckBox
    Friend WithEvents lblMensaje As Label
    Friend WithEvents stsConexion As StatusStrip
    Friend WithEvents btnSalir As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents lblSubtitulo As Label
End Class
