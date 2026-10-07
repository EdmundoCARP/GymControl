<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        mnuPrincipal = New MenuStrip()
        ArchivoToolStripMenuItem = New ToolStripMenuItem()
        SociosToolStripMenuItem = New ToolStripMenuItem()
        MembresiasToolStripMenuItem = New ToolStripMenuItem()
        PagosToolStripMenuItem = New ToolStripMenuItem()
        InstructoresToolStripMenuItem = New ToolStripMenuItem()
        HorariosToolStripMenuItem = New ToolStripMenuItem()
        ReportesToolStripMenuItem = New ToolStripMenuItem()
        SeguridadToolStripMenuItem = New ToolStripMenuItem()
        AyudaToolStripMenuItem = New ToolStripMenuItem()
        pnlNavegacion = New Panel()
        btnCerrarsesion = New Button()
        btnBitacoradeaccesos = New Button()
        btnUsuarioyroles = New Button()
        btnHorarios = New Button()
        btnActSalas = New Button()
        btnInstructores = New Button()
        btnPagos = New Button()
        btnMembresias = New Button()
        btnSocios = New Button()
        btnInicio = New Button()
        pnlIndicadores = New Panel()
        pnlClasesHoy = New Panel()
        lblSalasUso = New Label()
        lblNum4 = New Label()
        lblclasesprog = New Label()
        pnlIngresosMes = New Panel()
        lblPagReg = New Label()
        lblNum3 = New Label()
        lblIngresosMes = New Label()
        pnlMembresiasVencer = New Panel()
        lblProxx = New Label()
        lblNum2 = New Label()
        lblMembreciasvencer = New Label()
        lblResumen = New Label()
        lblTitulo = New Label()
        pnlSociosActivos = New Panel()
        lblEstemes = New Label()
        lblNum1 = New Label()
        lblSociosActivos = New Label()
        dvgClasesHoy = New DataGridView()
        lblPorVencer = New Label()
        lblClasesHoy = New Label()
        lblAccesosRapidos = New Label()
        btnNuevoSocio = New Button()
        btnRegistrarPago = New Button()
        btnRenovarMembresia = New Button()
        btnVerHorarios = New Button()
        sstSesionn = New StatusStrip()
        DataGridView1 = New DataGridView()
        mnuPrincipal.SuspendLayout()
        pnlNavegacion.SuspendLayout()
        pnlIndicadores.SuspendLayout()
        pnlClasesHoy.SuspendLayout()
        pnlIngresosMes.SuspendLayout()
        pnlMembresiasVencer.SuspendLayout()
        pnlSociosActivos.SuspendLayout()
        CType(dvgClasesHoy, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' mnuPrincipal
        ' 
        mnuPrincipal.Items.AddRange(New ToolStripItem() {ArchivoToolStripMenuItem, SociosToolStripMenuItem, MembresiasToolStripMenuItem, PagosToolStripMenuItem, InstructoresToolStripMenuItem, HorariosToolStripMenuItem, ReportesToolStripMenuItem, SeguridadToolStripMenuItem, AyudaToolStripMenuItem})
        mnuPrincipal.Location = New Point(0, 0)
        mnuPrincipal.Name = "mnuPrincipal"
        mnuPrincipal.Size = New Size(935, 24)
        mnuPrincipal.TabIndex = 0
        mnuPrincipal.Text = "MenuStrip1"
        ' 
        ' ArchivoToolStripMenuItem
        ' 
        ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        ArchivoToolStripMenuItem.Size = New Size(60, 20)
        ArchivoToolStripMenuItem.Text = "Archivo"
        ' 
        ' SociosToolStripMenuItem
        ' 
        SociosToolStripMenuItem.Name = "SociosToolStripMenuItem"
        SociosToolStripMenuItem.Size = New Size(53, 20)
        SociosToolStripMenuItem.Text = "Socios"
        ' 
        ' MembresiasToolStripMenuItem
        ' 
        MembresiasToolStripMenuItem.Name = "MembresiasToolStripMenuItem"
        MembresiasToolStripMenuItem.Size = New Size(83, 20)
        MembresiasToolStripMenuItem.Text = "Membresias"
        ' 
        ' PagosToolStripMenuItem
        ' 
        PagosToolStripMenuItem.Name = "PagosToolStripMenuItem"
        PagosToolStripMenuItem.Size = New Size(51, 20)
        PagosToolStripMenuItem.Text = "Pagos"
        ' 
        ' InstructoresToolStripMenuItem
        ' 
        InstructoresToolStripMenuItem.Name = "InstructoresToolStripMenuItem"
        InstructoresToolStripMenuItem.Size = New Size(81, 20)
        InstructoresToolStripMenuItem.Text = "Instructores"
        ' 
        ' HorariosToolStripMenuItem
        ' 
        HorariosToolStripMenuItem.Name = "HorariosToolStripMenuItem"
        HorariosToolStripMenuItem.Size = New Size(64, 20)
        HorariosToolStripMenuItem.Text = "Horarios"
        ' 
        ' ReportesToolStripMenuItem
        ' 
        ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        ReportesToolStripMenuItem.Size = New Size(65, 20)
        ReportesToolStripMenuItem.Text = "Reportes"
        ' 
        ' SeguridadToolStripMenuItem
        ' 
        SeguridadToolStripMenuItem.Name = "SeguridadToolStripMenuItem"
        SeguridadToolStripMenuItem.Size = New Size(72, 20)
        SeguridadToolStripMenuItem.Text = "Seguridad"
        ' 
        ' AyudaToolStripMenuItem
        ' 
        AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        AyudaToolStripMenuItem.Size = New Size(53, 20)
        AyudaToolStripMenuItem.Text = "Ayuda"
        ' 
        ' pnlNavegacion
        ' 
        pnlNavegacion.BackColor = Color.Red
        pnlNavegacion.Controls.Add(btnCerrarsesion)
        pnlNavegacion.Controls.Add(btnBitacoradeaccesos)
        pnlNavegacion.Controls.Add(btnUsuarioyroles)
        pnlNavegacion.Controls.Add(btnHorarios)
        pnlNavegacion.Controls.Add(btnActSalas)
        pnlNavegacion.Controls.Add(btnInstructores)
        pnlNavegacion.Controls.Add(btnPagos)
        pnlNavegacion.Controls.Add(btnMembresias)
        pnlNavegacion.Controls.Add(btnSocios)
        pnlNavegacion.Controls.Add(btnInicio)
        pnlNavegacion.Location = New Point(12, 27)
        pnlNavegacion.Name = "pnlNavegacion"
        pnlNavegacion.Size = New Size(155, 498)
        pnlNavegacion.TabIndex = 1
        ' 
        ' btnCerrarsesion
        ' 
        btnCerrarsesion.BackColor = Color.IndianRed
        btnCerrarsesion.Location = New Point(17, 470)
        btnCerrarsesion.Name = "btnCerrarsesion"
        btnCerrarsesion.Size = New Size(115, 23)
        btnCerrarsesion.TabIndex = 9
        btnCerrarsesion.Text = "Cerrar sesion"
        btnCerrarsesion.UseVisualStyleBackColor = False
        ' 
        ' btnBitacoradeaccesos
        ' 
        btnBitacoradeaccesos.Location = New Point(17, 402)
        btnBitacoradeaccesos.Name = "btnBitacoradeaccesos"
        btnBitacoradeaccesos.Size = New Size(115, 50)
        btnBitacoradeaccesos.TabIndex = 8
        btnBitacoradeaccesos.Text = "Bitacora de accesos"
        btnBitacoradeaccesos.UseVisualStyleBackColor = True
        ' 
        ' btnUsuarioyroles
        ' 
        btnUsuarioyroles.Location = New Point(17, 334)
        btnUsuarioyroles.Name = "btnUsuarioyroles"
        btnUsuarioyroles.Size = New Size(115, 46)
        btnUsuarioyroles.TabIndex = 7
        btnUsuarioyroles.Text = "Usuarios y roles "
        btnUsuarioyroles.UseVisualStyleBackColor = True
        ' 
        ' btnHorarios
        ' 
        btnHorarios.Location = New Point(17, 290)
        btnHorarios.Name = "btnHorarios"
        btnHorarios.Size = New Size(115, 23)
        btnHorarios.TabIndex = 6
        btnHorarios.Text = "Horarios"
        btnHorarios.UseVisualStyleBackColor = True
        ' 
        ' btnActSalas
        ' 
        btnActSalas.Location = New Point(17, 248)
        btnActSalas.Name = "btnActSalas"
        btnActSalas.Size = New Size(115, 23)
        btnActSalas.TabIndex = 5
        btnActSalas.Text = "Actividades y salas"
        btnActSalas.UseVisualStyleBackColor = True
        ' 
        ' btnInstructores
        ' 
        btnInstructores.Location = New Point(17, 203)
        btnInstructores.Name = "btnInstructores"
        btnInstructores.Size = New Size(115, 23)
        btnInstructores.TabIndex = 4
        btnInstructores.Text = "Instructores"
        btnInstructores.UseVisualStyleBackColor = True
        ' 
        ' btnPagos
        ' 
        btnPagos.Location = New Point(17, 150)
        btnPagos.Name = "btnPagos"
        btnPagos.Size = New Size(115, 23)
        btnPagos.TabIndex = 3
        btnPagos.Text = "Pagos"
        btnPagos.UseVisualStyleBackColor = True
        ' 
        ' btnMembresias
        ' 
        btnMembresias.Location = New Point(17, 103)
        btnMembresias.Name = "btnMembresias"
        btnMembresias.Size = New Size(115, 23)
        btnMembresias.TabIndex = 2
        btnMembresias.Text = "Membresias"
        btnMembresias.UseVisualStyleBackColor = True
        ' 
        ' btnSocios
        ' 
        btnSocios.Location = New Point(17, 55)
        btnSocios.Name = "btnSocios"
        btnSocios.Size = New Size(115, 23)
        btnSocios.TabIndex = 1
        btnSocios.Text = "Socios"
        btnSocios.UseVisualStyleBackColor = True
        ' 
        ' btnInicio
        ' 
        btnInicio.Location = New Point(17, 9)
        btnInicio.Name = "btnInicio"
        btnInicio.Size = New Size(115, 23)
        btnInicio.TabIndex = 0
        btnInicio.Text = "Inicio"
        btnInicio.UseVisualStyleBackColor = True
        ' 
        ' pnlIndicadores
        ' 
        pnlIndicadores.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        pnlIndicadores.Controls.Add(pnlClasesHoy)
        pnlIndicadores.Controls.Add(pnlIngresosMes)
        pnlIndicadores.Controls.Add(pnlMembresiasVencer)
        pnlIndicadores.Controls.Add(lblResumen)
        pnlIndicadores.Controls.Add(lblTitulo)
        pnlIndicadores.Controls.Add(pnlSociosActivos)
        pnlIndicadores.Location = New Point(183, 27)
        pnlIndicadores.Name = "pnlIndicadores"
        pnlIndicadores.Size = New Size(693, 235)
        pnlIndicadores.TabIndex = 2
        ' 
        ' pnlClasesHoy
        ' 
        pnlClasesHoy.BackColor = Color.Blue
        pnlClasesHoy.Controls.Add(lblSalasUso)
        pnlClasesHoy.Controls.Add(lblNum4)
        pnlClasesHoy.Controls.Add(lblclasesprog)
        pnlClasesHoy.Location = New Point(514, 81)
        pnlClasesHoy.Name = "pnlClasesHoy"
        pnlClasesHoy.Size = New Size(152, 129)
        pnlClasesHoy.TabIndex = 5
        ' 
        ' lblSalasUso
        ' 
        lblSalasUso.AutoSize = True
        lblSalasUso.BackColor = Color.Lime
        lblSalasUso.Location = New Point(44, 95)
        lblSalasUso.Name = "lblSalasUso"
        lblSalasUso.Size = New Size(79, 15)
        lblSalasUso.TabIndex = 3
        lblSalasUso.Text = "3 salas en uso"
        ' 
        ' lblNum4
        ' 
        lblNum4.AutoSize = True
        lblNum4.BackColor = SystemColors.ActiveCaption
        lblNum4.BorderStyle = BorderStyle.Fixed3D
        lblNum4.Location = New Point(67, 58)
        lblNum4.Name = "lblNum4"
        lblNum4.Size = New Size(15, 17)
        lblNum4.TabIndex = 1
        lblNum4.Text = "9"
        ' 
        ' lblclasesprog
        ' 
        lblclasesprog.AutoSize = True
        lblclasesprog.Location = New Point(11, 11)
        lblclasesprog.Name = "lblclasesprog"
        lblclasesprog.Size = New Size(136, 15)
        lblclasesprog.TabIndex = 0
        lblclasesprog.Text = "Clases programadas hoy"
        ' 
        ' pnlIngresosMes
        ' 
        pnlIngresosMes.BackColor = Color.PaleVioletRed
        pnlIngresosMes.BorderStyle = BorderStyle.FixedSingle
        pnlIngresosMes.Controls.Add(lblPagReg)
        pnlIngresosMes.Controls.Add(lblNum3)
        pnlIngresosMes.Controls.Add(lblIngresosMes)
        pnlIngresosMes.Location = New Point(337, 81)
        pnlIngresosMes.Name = "pnlIngresosMes"
        pnlIngresosMes.Size = New Size(147, 129)
        pnlIngresosMes.TabIndex = 4
        ' 
        ' lblPagReg
        ' 
        lblPagReg.AutoSize = True
        lblPagReg.BackColor = Color.SteelBlue
        lblPagReg.Location = New Point(11, 95)
        lblPagReg.Name = "lblPagReg"
        lblPagReg.Size = New Size(121, 15)
        lblPagReg.TabIndex = 3
        lblPagReg.Text = "132 pagos registrados"
        ' 
        ' lblNum3
        ' 
        lblNum3.AutoSize = True
        lblNum3.BackColor = SystemColors.ActiveCaption
        lblNum3.BorderStyle = BorderStyle.Fixed3D
        lblNum3.Location = New Point(39, 58)
        lblNum3.Name = "lblNum3"
        lblNum3.Size = New Size(80, 17)
        lblNum3.TabIndex = 1
        lblNum3.Text = "C$ 148,600.00"
        ' 
        ' lblIngresosMes
        ' 
        lblIngresosMes.AutoSize = True
        lblIngresosMes.Location = New Point(11, 11)
        lblIngresosMes.Name = "lblIngresosMes"
        lblIngresosMes.Size = New Size(95, 15)
        lblIngresosMes.TabIndex = 0
        lblIngresosMes.Text = "Ingresos del Mes"
        ' 
        ' pnlMembresiasVencer
        ' 
        pnlMembresiasVencer.BackColor = Color.Pink
        pnlMembresiasVencer.BorderStyle = BorderStyle.FixedSingle
        pnlMembresiasVencer.Controls.Add(lblProxx)
        pnlMembresiasVencer.Controls.Add(lblNum2)
        pnlMembresiasVencer.Controls.Add(lblMembreciasvencer)
        pnlMembresiasVencer.Location = New Point(154, 81)
        pnlMembresiasVencer.Name = "pnlMembresiasVencer"
        pnlMembresiasVencer.Size = New Size(152, 129)
        pnlMembresiasVencer.TabIndex = 3
        ' 
        ' lblProxx
        ' 
        lblProxx.AutoSize = True
        lblProxx.BackColor = Color.Gold
        lblProxx.Location = New Point(34, 95)
        lblProxx.Name = "lblProxx"
        lblProxx.Size = New Size(92, 15)
        lblProxx.TabIndex = 3
        lblProxx.Text = "proximos 7 dias "
        ' 
        ' lblNum2
        ' 
        lblNum2.AutoSize = True
        lblNum2.BackColor = Color.Aqua
        lblNum2.BorderStyle = BorderStyle.Fixed3D
        lblNum2.Location = New Point(67, 57)
        lblNum2.Name = "lblNum2"
        lblNum2.Size = New Size(21, 17)
        lblNum2.TabIndex = 1
        lblNum2.Text = "14"
        ' 
        ' lblMembreciasvencer
        ' 
        lblMembreciasvencer.AutoSize = True
        lblMembreciasvencer.Location = New Point(11, 11)
        lblMembreciasvencer.Name = "lblMembreciasvencer"
        lblMembreciasvencer.Size = New Size(134, 15)
        lblMembreciasvencer.TabIndex = 0
        lblMembreciasvencer.Text = "Membrecias por vencer "
        ' 
        ' lblResumen
        ' 
        lblResumen.AutoSize = True
        lblResumen.Location = New Point(3, 44)
        lblResumen.Name = "lblResumen"
        lblResumen.Size = New Size(227, 15)
        lblResumen.TabIndex = 2
        lblResumen.Text = "Resumen del dia - lunes 21 de Septiembre"
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitulo.Location = New Point(3, 9)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(212, 35)
        lblTitulo.TabIndex = 1
        lblTitulo.Text = "Panel de Control"
        ' 
        ' pnlSociosActivos
        ' 
        pnlSociosActivos.BackColor = Color.DodgerBlue
        pnlSociosActivos.BorderStyle = BorderStyle.FixedSingle
        pnlSociosActivos.Controls.Add(lblEstemes)
        pnlSociosActivos.Controls.Add(lblNum1)
        pnlSociosActivos.Controls.Add(lblSociosActivos)
        pnlSociosActivos.Location = New Point(12, 81)
        pnlSociosActivos.Name = "pnlSociosActivos"
        pnlSociosActivos.Size = New Size(115, 129)
        pnlSociosActivos.TabIndex = 0
        ' 
        ' lblEstemes
        ' 
        lblEstemes.AutoSize = True
        lblEstemes.BackColor = Color.OrangeRed
        lblEstemes.Location = New Point(21, 95)
        lblEstemes.Name = "lblEstemes"
        lblEstemes.Size = New Size(73, 15)
        lblEstemes.TabIndex = 3
        lblEstemes.Text = "+6 este mes "
        ' 
        ' lblNum1
        ' 
        lblNum1.AutoSize = True
        lblNum1.BackColor = Color.Aquamarine
        lblNum1.BorderStyle = BorderStyle.Fixed3D
        lblNum1.Location = New Point(38, 58)
        lblNum1.Name = "lblNum1"
        lblNum1.Size = New Size(27, 17)
        lblNum1.TabIndex = 1
        lblNum1.Text = "186"
        ' 
        ' lblSociosActivos
        ' 
        lblSociosActivos.AutoSize = True
        lblSociosActivos.Location = New Point(11, 11)
        lblSociosActivos.Name = "lblSociosActivos"
        lblSociosActivos.Size = New Size(83, 15)
        lblSociosActivos.TabIndex = 0
        lblSociosActivos.Text = "Socios Activos"
        ' 
        ' dvgClasesHoy
        ' 
        dvgClasesHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dvgClasesHoy.Location = New Point(586, 302)
        dvgClasesHoy.Name = "dvgClasesHoy"
        dvgClasesHoy.Size = New Size(299, 150)
        dvgClasesHoy.TabIndex = 4
        ' 
        ' lblPorVencer
        ' 
        lblPorVencer.AutoSize = True
        lblPorVencer.Font = New Font("Segoe UI", 12.25F, FontStyle.Bold)
        lblPorVencer.Location = New Point(186, 274)
        lblPorVencer.Name = "lblPorVencer"
        lblPorVencer.Size = New Size(261, 23)
        lblPorVencer.TabIndex = 5
        lblPorVencer.Text = "Membresias proximas a vencer "
        ' 
        ' lblClasesHoy
        ' 
        lblClasesHoy.AutoSize = True
        lblClasesHoy.Font = New Font("Segoe UI", 12.25F, FontStyle.Bold)
        lblClasesHoy.Location = New Point(586, 274)
        lblClasesHoy.Name = "lblClasesHoy"
        lblClasesHoy.Size = New Size(120, 23)
        lblClasesHoy.TabIndex = 6
        lblClasesHoy.Text = "Clases de Hoy"
        ' 
        ' lblAccesosRapidos
        ' 
        lblAccesosRapidos.AutoSize = True
        lblAccesosRapidos.Font = New Font("Segoe UI", 12.25F, FontStyle.Bold)
        lblAccesosRapidos.Location = New Point(186, 466)
        lblAccesosRapidos.Name = "lblAccesosRapidos"
        lblAccesosRapidos.Size = New Size(140, 23)
        lblAccesosRapidos.TabIndex = 7
        lblAccesosRapidos.Text = "Accesos Rapidos"
        ' 
        ' btnNuevoSocio
        ' 
        btnNuevoSocio.BackColor = Color.SteelBlue
        btnNuevoSocio.Location = New Point(189, 497)
        btnNuevoSocio.Name = "btnNuevoSocio"
        btnNuevoSocio.Size = New Size(121, 28)
        btnNuevoSocio.TabIndex = 8
        btnNuevoSocio.Text = "+ Nuevo Socio"
        btnNuevoSocio.UseVisualStyleBackColor = False
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.Location = New Point(337, 497)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(121, 28)
        btnRegistrarPago.TabIndex = 9
        btnRegistrarPago.Text = "Registrar Pago"
        btnRegistrarPago.UseVisualStyleBackColor = True
        ' 
        ' btnRenovarMembresia
        ' 
        btnRenovarMembresia.Location = New Point(482, 497)
        btnRenovarMembresia.Name = "btnRenovarMembresia"
        btnRenovarMembresia.Size = New Size(121, 28)
        btnRenovarMembresia.TabIndex = 10
        btnRenovarMembresia.Text = "Renovar membresia"
        btnRenovarMembresia.UseVisualStyleBackColor = True
        ' 
        ' btnVerHorarios
        ' 
        btnVerHorarios.Location = New Point(625, 497)
        btnVerHorarios.Name = "btnVerHorarios"
        btnVerHorarios.Size = New Size(121, 28)
        btnVerHorarios.TabIndex = 11
        btnVerHorarios.Text = "Ver horarios"
        btnVerHorarios.UseVisualStyleBackColor = True
        ' 
        ' sstSesionn
        ' 
        sstSesionn.Location = New Point(0, 552)
        sstSesionn.Name = "sstSesionn"
        sstSesionn.Size = New Size(935, 22)
        sstSesionn.TabIndex = 12
        sstSesionn.Text = "Sesion Iniciada"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(195, 300)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(342, 150)
        DataGridView1.TabIndex = 13
        ' 
        ' frmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(935, 574)
        Controls.Add(DataGridView1)
        Controls.Add(sstSesionn)
        Controls.Add(btnVerHorarios)
        Controls.Add(btnRenovarMembresia)
        Controls.Add(btnRegistrarPago)
        Controls.Add(btnNuevoSocio)
        Controls.Add(lblAccesosRapidos)
        Controls.Add(lblClasesHoy)
        Controls.Add(lblPorVencer)
        Controls.Add(dvgClasesHoy)
        Controls.Add(pnlIndicadores)
        Controls.Add(pnlNavegacion)
        Controls.Add(mnuPrincipal)
        MainMenuStrip = mnuPrincipal
        Name = "frmPrincipal"
        Text = "GymControl - Panel Principal"
        mnuPrincipal.ResumeLayout(False)
        mnuPrincipal.PerformLayout()
        pnlNavegacion.ResumeLayout(False)
        pnlIndicadores.ResumeLayout(False)
        pnlIndicadores.PerformLayout()
        pnlClasesHoy.ResumeLayout(False)
        pnlClasesHoy.PerformLayout()
        pnlIngresosMes.ResumeLayout(False)
        pnlIngresosMes.PerformLayout()
        pnlMembresiasVencer.ResumeLayout(False)
        pnlMembresiasVencer.PerformLayout()
        pnlSociosActivos.ResumeLayout(False)
        pnlSociosActivos.PerformLayout()
        CType(dvgClasesHoy, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents mnuPrincipal As MenuStrip
    Friend WithEvents pnlNavegacion As Panel
    Friend WithEvents btnCerrarsesion As Button
    Friend WithEvents btnBitacoradeaccesos As Button
    Friend WithEvents btnUsuarioyroles As Button
    Friend WithEvents btnHorarios As Button
    Friend WithEvents btnActSalas As Button
    Friend WithEvents btnInstructores As Button
    Friend WithEvents btnPagos As Button
    Friend WithEvents btnMembresias As Button
    Friend WithEvents btnSocios As Button
    Friend WithEvents btnInicio As Button
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SociosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MembresiasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PagosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstructoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HorariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeguridadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlIndicadores As Panel
    Friend WithEvents pnlSociosActivos As Panel
    Friend WithEvents lblNum1 As Label
    Friend WithEvents lblSociosActivos As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblResumen As Label
    Friend WithEvents lblEstemes As Label
    Friend WithEvents pnlMembresiasVencer As Panel
    Friend WithEvents lblProxx As Label
    Friend WithEvents lblNum2 As Label
    Friend WithEvents lblMembreciasvencer As Label
    Friend WithEvents pnlIngresosMes As Panel
    Friend WithEvents lblPagReg As Label
    Friend WithEvents lblNum3 As Label
    Friend WithEvents lblIngresosMes As Label
    Friend WithEvents pnlClasesHoy As Panel
    Friend WithEvents lblSalasUso As Label
    Friend WithEvents lblNum4 As Label
    Friend WithEvents lblclasesprog As Label
    Friend WithEvents dvgClasesHoy As DataGridView
    Friend WithEvents lblPorVencer As Label
    Friend WithEvents lblClasesHoy As Label
    Friend WithEvents lblAccesosRapidos As Label
    Friend WithEvents btnNuevoSocio As Button
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents btnRenovarMembresia As Button
    Friend WithEvents btnVerHorarios As Button
    Friend WithEvents sstSesionn As StatusStrip
    Friend WithEvents DataGridView1 As DataGridView
End Class
