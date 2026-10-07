<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPortalSocio
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
        pnlHeader = New Panel()
        lblFechaHora = New Label()
        DateTimePicker1 = New DateTimePicker()
        lblTotslTitulo = New Label()
        ilblDatosSocio = New Label()
        lblSaludo = New Label()
        btnCambiarContraseña = New Button()
        btnCerrarSesion = New Button()
        pnlMembresia = New Panel()
        lblTituloMembresia = New Label()
        lblTipoTitulo = New Label()
        lblTipo = New Label()
        lblInicioTitulo = New Label()
        lblInicio = New Label()
        lblVenceTitulo = New Label()
        lblVence = New Label()
        lblIncluyeClases = New Label()
        lblClasesTitulo = New Label()
        lblEstado = New Label()
        lblDiasRestantes = New Label()
        prgMembresia = New ProgressBar()
        lblNotaIndicacion = New Label()
        pnlCuenta = New Panel()
        lblTituloCuenta = New Label()
        lblTotalTitulo = New Label()
        lblPagadoTitulo = New Label()
        lblSaldoTitulo = New Label()
        lblTotal = New Label()
        lblPagado = New Label()
        lblSaldo = New Label()
        lblMisPagos = New Label()
        dgvMisPagos = New DataGridView()
        lblClasesDisponibles = New Label()
        dgvClases = New DataGridView()
        stsSesion = New StatusStrip()
        MySqlCommand1 = New MySqlConnector.MySqlCommand()
        lblSesion = New ToolStripStatusLabel()
        lblRol = New ToolStripStatusLabel()
        ToolStrip1 = New ToolStrip()
        pnlHeader.SuspendLayout()
        pnlMembresia.SuspendLayout()
        pnlCuenta.SuspendLayout()
        CType(dgvMisPagos, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvClases, ComponentModel.ISupportInitialize).BeginInit()
        stsSesion.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.DimGray
        pnlHeader.Controls.Add(btnCerrarSesion)
        pnlHeader.Controls.Add(btnCambiarContraseña)
        pnlHeader.Controls.Add(lblFechaHora)
        pnlHeader.Controls.Add(DateTimePicker1)
        pnlHeader.Controls.Add(lblTotslTitulo)
        pnlHeader.Controls.Add(ilblDatosSocio)
        pnlHeader.Controls.Add(lblSaludo)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(992, 87)
        pnlHeader.TabIndex = 0
        ' 
        ' lblFechaHora
        ' 
        lblFechaHora.AutoSize = True
        lblFechaHora.Location = New Point(397, 52)
        lblFechaHora.Name = "lblFechaHora"
        lblFechaHora.Size = New Size(58, 15)
        lblFechaHora.TabIndex = 4
        lblFechaHora.Text = "06:02 p.m"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(307, 47)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(78, 23)
        DateTimePicker1.TabIndex = 3
        ' 
        ' lblTotslTitulo
        ' 
        lblTotslTitulo.AutoSize = True
        lblTotslTitulo.Location = New Point(213, 53)
        lblTotslTitulo.Name = "lblTotslTitulo"
        lblTotslTitulo.Size = New Size(95, 15)
        lblTotslTitulo.TabIndex = 2
        lblTotslTitulo.Text = "Total Membresia"
        ' 
        ' ilblDatosSocio
        ' 
        ilblDatosSocio.AutoSize = True
        ilblDatosSocio.Location = New Point(141, 53)
        ilblDatosSocio.Name = "ilblDatosSocio"
        ilblDatosSocio.Size = New Size(66, 15)
        ilblDatosSocio.TabIndex = 1
        ilblDatosSocio.Text = "Socia N.o 3"
        ' 
        ' lblSaludo
        ' 
        lblSaludo.AutoSize = True
        lblSaludo.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSaludo.Location = New Point(122, 9)
        lblSaludo.Name = "lblSaludo"
        lblSaludo.Size = New Size(232, 25)
        lblSaludo.TabIndex = 0
        lblSaludo.Text = "Hola, Ana Lucia Rodriguez"
        ' 
        ' btnCambiarContraseña
        ' 
        btnCambiarContraseña.BackColor = SystemColors.Highlight
        btnCambiarContraseña.ForeColor = SystemColors.MenuText
        btnCambiarContraseña.Location = New Point(666, 42)
        btnCambiarContraseña.Name = "btnCambiarContraseña"
        btnCambiarContraseña.Size = New Size(147, 23)
        btnCambiarContraseña.TabIndex = 5
        btnCambiarContraseña.Text = "Cambiar contraseña"
        btnCambiarContraseña.UseVisualStyleBackColor = False
        ' 
        ' btnCerrarSesion
        ' 
        btnCerrarSesion.BackColor = Color.Red
        btnCerrarSesion.ForeColor = SystemColors.Control
        btnCerrarSesion.Location = New Point(833, 42)
        btnCerrarSesion.Name = "btnCerrarSesion"
        btnCerrarSesion.Size = New Size(147, 23)
        btnCerrarSesion.TabIndex = 6
        btnCerrarSesion.Text = "Cerrar Sesion"
        btnCerrarSesion.UseVisualStyleBackColor = False
        ' 
        ' pnlMembresia
        ' 
        pnlMembresia.Controls.Add(ToolStrip1)
        pnlMembresia.Controls.Add(lblNotaIndicacion)
        pnlMembresia.Controls.Add(prgMembresia)
        pnlMembresia.Controls.Add(lblDiasRestantes)
        pnlMembresia.Controls.Add(lblEstado)
        pnlMembresia.Controls.Add(lblClasesTitulo)
        pnlMembresia.Controls.Add(lblIncluyeClases)
        pnlMembresia.Controls.Add(lblVence)
        pnlMembresia.Controls.Add(lblVenceTitulo)
        pnlMembresia.Controls.Add(lblInicio)
        pnlMembresia.Controls.Add(lblInicioTitulo)
        pnlMembresia.Controls.Add(lblTipo)
        pnlMembresia.Controls.Add(lblTipoTitulo)
        pnlMembresia.Controls.Add(lblTituloMembresia)
        pnlMembresia.Location = New Point(13, 126)
        pnlMembresia.Name = "pnlMembresia"
        pnlMembresia.Size = New Size(523, 260)
        pnlMembresia.TabIndex = 1
        ' 
        ' lblTituloMembresia
        ' 
        lblTituloMembresia.AutoSize = True
        lblTituloMembresia.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTituloMembresia.Location = New Point(22, 21)
        lblTituloMembresia.Name = "lblTituloMembresia"
        lblTituloMembresia.Size = New Size(109, 20)
        lblTituloMembresia.TabIndex = 0
        lblTituloMembresia.Text = "Mi membresia"
        ' 
        ' lblTipoTitulo
        ' 
        lblTipoTitulo.AutoSize = True
        lblTipoTitulo.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTipoTitulo.Location = New Point(22, 59)
        lblTipoTitulo.Name = "lblTipoTitulo"
        lblTipoTitulo.Size = New Size(29, 15)
        lblTipoTitulo.TabIndex = 7
        lblTipoTitulo.Text = "Tipo"
        ' 
        ' lblTipo
        ' 
        lblTipo.AutoSize = True
        lblTipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTipo.Location = New Point(22, 92)
        lblTipo.Name = "lblTipo"
        lblTipo.Size = New Size(53, 15)
        lblTipo.TabIndex = 8
        lblTipo.Text = "Mensual"
        ' 
        ' lblInicioTitulo
        ' 
        lblInicioTitulo.AutoSize = True
        lblInicioTitulo.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblInicioTitulo.Location = New Point(128, 59)
        lblInicioTitulo.Name = "lblInicioTitulo"
        lblInicioTitulo.Size = New Size(34, 15)
        lblInicioTitulo.TabIndex = 9
        lblInicioTitulo.Text = "Inicio"
        ' 
        ' lblInicio
        ' 
        lblInicio.AutoSize = True
        lblInicio.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInicio.Location = New Point(128, 92)
        lblInicio.Name = "lblInicio"
        lblInicio.Size = New Size(73, 15)
        lblInicio.TabIndex = 10
        lblInicio.Text = "01/09/2026"
        ' 
        ' lblVenceTitulo
        ' 
        lblVenceTitulo.AutoSize = True
        lblVenceTitulo.Location = New Point(249, 59)
        lblVenceTitulo.Name = "lblVenceTitulo"
        lblVenceTitulo.Size = New Size(38, 15)
        lblVenceTitulo.TabIndex = 11
        lblVenceTitulo.Text = "Vence"
        ' 
        ' lblVence
        ' 
        lblVence.AutoSize = True
        lblVence.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblVence.Location = New Point(249, 92)
        lblVence.Name = "lblVence"
        lblVence.Size = New Size(73, 15)
        lblVence.TabIndex = 12
        lblVence.Text = "30/09/2026"
        ' 
        ' lblIncluyeClases
        ' 
        lblIncluyeClases.AutoSize = True
        lblIncluyeClases.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblIncluyeClases.Location = New Point(384, 92)
        lblIncluyeClases.Name = "lblIncluyeClases"
        lblIncluyeClases.Size = New Size(17, 15)
        lblIncluyeClases.TabIndex = 13
        lblIncluyeClases.Text = "Si"
        ' 
        ' lblClasesTitulo
        ' 
        lblClasesTitulo.AutoSize = True
        lblClasesTitulo.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblClasesTitulo.Location = New Point(384, 59)
        lblClasesTitulo.Name = "lblClasesTitulo"
        lblClasesTitulo.Size = New Size(78, 15)
        lblClasesTitulo.TabIndex = 14
        lblClasesTitulo.Text = "Incluye clases"
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.BackColor = Color.Silver
        lblEstado.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEstado.Location = New Point(458, 26)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(47, 15)
        lblEstado.TabIndex = 15
        lblEstado.Text = "ACTIVA"
        ' 
        ' lblDiasRestantes
        ' 
        lblDiasRestantes.AutoSize = True
        lblDiasRestantes.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiasRestantes.ForeColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        lblDiasRestantes.Location = New Point(22, 163)
        lblDiasRestantes.Name = "lblDiasRestantes"
        lblDiasRestantes.Size = New Size(135, 15)
        lblDiasRestantes.TabIndex = 16
        lblDiasRestantes.Text = "Dias restantes : 9 de 30"
        ' 
        ' prgMembresia
        ' 
        prgMembresia.BackColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        prgMembresia.ForeColor = Color.FromArgb(CByte(192), CByte(64), CByte(0))
        prgMembresia.Location = New Point(22, 193)
        prgMembresia.Maximum = 30
        prgMembresia.Name = "prgMembresia"
        prgMembresia.Size = New Size(483, 23)
        prgMembresia.Style = ProgressBarStyle.Continuous
        prgMembresia.TabIndex = 17
        prgMembresia.Value = 21
        ' 
        ' lblNotaIndicacion
        ' 
        lblNotaIndicacion.AutoSize = True
        lblNotaIndicacion.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblNotaIndicacion.Location = New Point(22, 230)
        lblNotaIndicacion.Name = "lblNotaIndicacion"
        lblNotaIndicacion.Size = New Size(367, 15)
        lblNotaIndicacion.TabIndex = 18
        lblNotaIndicacion.Text = "Renueve en recepcion antes del vencimiento para no perder el acceso"
        ' 
        ' pnlCuenta
        ' 
        pnlCuenta.BackColor = SystemColors.ButtonFace
        pnlCuenta.Controls.Add(lblSaldo)
        pnlCuenta.Controls.Add(lblPagado)
        pnlCuenta.Controls.Add(lblTotal)
        pnlCuenta.Controls.Add(lblSaldoTitulo)
        pnlCuenta.Controls.Add(lblPagadoTitulo)
        pnlCuenta.Controls.Add(lblTotalTitulo)
        pnlCuenta.Controls.Add(lblTituloCuenta)
        pnlCuenta.Location = New Point(557, 126)
        pnlCuenta.Name = "pnlCuenta"
        pnlCuenta.Size = New Size(377, 260)
        pnlCuenta.TabIndex = 2
        ' 
        ' lblTituloCuenta
        ' 
        lblTituloCuenta.AutoSize = True
        lblTituloCuenta.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTituloCuenta.Location = New Point(17, 21)
        lblTituloCuenta.Name = "lblTituloCuenta"
        lblTituloCuenta.Size = New Size(101, 15)
        lblTituloCuenta.TabIndex = 1
        lblTituloCuenta.Text = "Estado de cuenta"
        ' 
        ' lblTotalTitulo
        ' 
        lblTotalTitulo.AutoSize = True
        lblTotalTitulo.Font = New Font("Segoe UI", 9F)
        lblTotalTitulo.Location = New Point(17, 59)
        lblTotalTitulo.Name = "lblTotalTitulo"
        lblTotalTitulo.Size = New Size(95, 15)
        lblTotalTitulo.TabIndex = 2
        lblTotalTitulo.Text = "Total Membresia"
        ' 
        ' lblPagadoTitulo
        ' 
        lblPagadoTitulo.AutoSize = True
        lblPagadoTitulo.Font = New Font("Segoe UI", 9F)
        lblPagadoTitulo.Location = New Point(17, 101)
        lblPagadoTitulo.Name = "lblPagadoTitulo"
        lblPagadoTitulo.Size = New Size(47, 15)
        lblPagadoTitulo.TabIndex = 3
        lblPagadoTitulo.Text = "Pagado"
        ' 
        ' lblSaldoTitulo
        ' 
        lblSaldoTitulo.AutoSize = True
        lblSaldoTitulo.Font = New Font("Segoe UI", 9F)
        lblSaldoTitulo.Location = New Point(17, 145)
        lblSaldoTitulo.Name = "lblSaldoTitulo"
        lblSaldoTitulo.Size = New Size(92, 15)
        lblSaldoTitulo.TabIndex = 4
        lblSaldoTitulo.Text = "Saldo Pendiente"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.Location = New Point(289, 59)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(73, 15)
        lblTotal.TabIndex = 5
        lblTotal.Text = "= C$ 800.00"
        ' 
        ' lblPagado
        ' 
        lblPagado.AutoSize = True
        lblPagado.BackColor = Color.White
        lblPagado.Font = New Font("Segoe UI", 9F)
        lblPagado.ForeColor = Color.Red
        lblPagado.Location = New Point(289, 101)
        lblPagado.Name = "lblPagado"
        lblPagado.Size = New Size(68, 15)
        lblPagado.TabIndex = 6
        lblPagado.Text = "= C$ 500.00"
        ' 
        ' lblSaldo
        ' 
        lblSaldo.AutoSize = True
        lblSaldo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSaldo.ForeColor = Color.ForestGreen
        lblSaldo.Location = New Point(289, 145)
        lblSaldo.Name = "lblSaldo"
        lblSaldo.Size = New Size(73, 15)
        lblSaldo.TabIndex = 7
        lblSaldo.Text = "= C$ 300.00"
        ' 
        ' lblMisPagos
        ' 
        lblMisPagos.AutoSize = True
        lblMisPagos.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMisPagos.Location = New Point(26, 403)
        lblMisPagos.Name = "lblMisPagos"
        lblMisPagos.Size = New Size(80, 20)
        lblMisPagos.TabIndex = 3
        lblMisPagos.Text = "Mis Pagos"
        ' 
        ' dgvMisPagos
        ' 
        dgvMisPagos.BackgroundColor = SystemColors.ButtonFace
        dgvMisPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMisPagos.Location = New Point(12, 426)
        dgvMisPagos.Name = "dgvMisPagos"
        dgvMisPagos.Size = New Size(443, 210)
        dgvMisPagos.TabIndex = 4
        ' 
        ' lblClasesDisponibles
        ' 
        lblClasesDisponibles.AutoSize = True
        lblClasesDisponibles.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClasesDisponibles.Location = New Point(492, 403)
        lblClasesDisponibles.Name = "lblClasesDisponibles"
        lblClasesDisponibles.Size = New Size(226, 20)
        lblClasesDisponibles.TabIndex = 5
        lblClasesDisponibles.Text = "Clases disponibles esta semana"
        ' 
        ' dgvClases
        ' 
        dgvClases.BackgroundColor = SystemColors.ButtonFace
        dgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvClases.Location = New Point(492, 426)
        dgvClases.Name = "dgvClases"
        dgvClases.Size = New Size(443, 210)
        dgvClases.TabIndex = 6
        ' 
        ' stsSesion
        ' 
        stsSesion.Items.AddRange(New ToolStripItem() {lblSesion, lblRol})
        stsSesion.Location = New Point(0, 658)
        stsSesion.Name = "stsSesion"
        stsSesion.Size = New Size(992, 22)
        stsSesion.TabIndex = 7
        stsSesion.Text = "StatusStrip1"
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CommandTimeout = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.Transaction = Nothing
        MySqlCommand1.UpdatedRowSource = UpdateRowSource.None
        ' 
        ' lblSesion
        ' 
        lblSesion.Name = "lblSesion"
        lblSesion.Size = New Size(53, 17)
        lblSesion.Text = "Usuario :"
        ' 
        ' lblRol
        ' 
        lblRol.Name = "lblRol"
        lblRol.Size = New Size(36, 17)
        lblRol.Text = "Rol :  "
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(523, 25)
        ToolStrip1.TabIndex = 19
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' frmPortalSocio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(992, 680)
        Controls.Add(stsSesion)
        Controls.Add(dgvClases)
        Controls.Add(lblClasesDisponibles)
        Controls.Add(dgvMisPagos)
        Controls.Add(lblMisPagos)
        Controls.Add(pnlCuenta)
        Controls.Add(pnlMembresia)
        Controls.Add(pnlHeader)
        Name = "frmPortalSocio"
        Text = "Portal del socio - Mi membresia"
        WindowState = FormWindowState.Minimized
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlMembresia.ResumeLayout(False)
        pnlMembresia.PerformLayout()
        pnlCuenta.ResumeLayout(False)
        pnlCuenta.PerformLayout()
        CType(dgvMisPagos, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvClases, ComponentModel.ISupportInitialize).EndInit()
        stsSesion.ResumeLayout(False)
        stsSesion.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents ilblDatosSocio As Label
    Friend WithEvents lblSaludo As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents lblTotslTitulo As Label
    Friend WithEvents lblFechaHora As Label



    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents btnCambiarContraseña As Button
    Friend WithEvents pnlMembresia As Panel
    Friend WithEvents lblInicioTitulo As Label
    Friend WithEvents lblTipo As Label
    Friend WithEvents lblTipoTitulo As Label
    Friend WithEvents lblTituloMembresia As Label
    Friend WithEvents lblIncluyeClases As Label
    Friend WithEvents lblVence As Label
    Friend WithEvents lblVenceTitulo As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents lblClasesTitulo As Label

    Private Sub pnlMembresia_Paint(sender As Object, e As PaintEventArgs) Handles pnlMembresia.Paint

    End Sub

    Friend WithEvents lblDiasRestantes As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblNotaIndicacion As Label
    Friend WithEvents prgMembresia As ProgressBar
    Friend WithEvents pnlCuenta As Panel
    Friend WithEvents lblTituloCuenta As Label
    Friend WithEvents lblSaldo As Label
    Friend WithEvents lblPagado As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblSaldoTitulo As Label
    Friend WithEvents lblPagadoTitulo As Label
    Friend WithEvents lblTotalTitulo As Label
    Friend WithEvents lblMisPagos As Label
    Friend WithEvents dgvMisPagos As DataGridView
    Friend WithEvents lblClasesDisponibles As Label
    Friend WithEvents dgvClases As DataGridView
    Friend WithEvents stsSesion As StatusStrip
    Friend WithEvents MySqlCommand1 As MySqlConnector.MySqlCommand
    Friend WithEvents lblSesion As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents lblRol As ToolStripStatusLabel
End Class
