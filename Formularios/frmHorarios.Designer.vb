<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorarios
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
        cboInstructor = New ComboBox()
        cboActividad = New ComboBox()
        cboSala = New ComboBox()
        cboDia = New ComboBox()
        dtpHoraInicio = New DateTimePicker()
        dtpHoraFin = New DateTimePicker()
        btnNuevo = New Button()
        btnGuardar = New Button()
        btnDesactivar = New Button()
        lblInicio = New Label()
        lblSala = New Label()
        lblHorario = New Label()
        lblDia = New Label()
        lblInstructor = New Label()
        lblActividad = New Label()
        FiltroInstructor = New Label()
        lblFin = New Label()
        cboFiltroInstructor = New ComboBox()
        cboFiltroSala = New ComboBox()
        dgvHorarios = New DataGridView()
        FiltroSala = New Label()
        lblChoque = New Label()
        lblEstado = New Label()
        lblNuevosHorarios = New Label()
        CType(dgvHorarios, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cboInstructor
        ' 
        cboInstructor.FormattingEnabled = True
        cboInstructor.Location = New Point(76, 245)
        cboInstructor.Name = "cboInstructor"
        cboInstructor.Size = New Size(121, 23)
        cboInstructor.TabIndex = 0
        ' 
        ' cboActividad
        ' 
        cboActividad.FormattingEnabled = True
        cboActividad.Location = New Point(287, 250)
        cboActividad.Name = "cboActividad"
        cboActividad.Size = New Size(121, 23)
        cboActividad.TabIndex = 1
        ' 
        ' cboSala
        ' 
        cboSala.FormattingEnabled = True
        cboSala.Location = New Point(76, 274)
        cboSala.Name = "cboSala"
        cboSala.Size = New Size(121, 23)
        cboSala.TabIndex = 2
        ' 
        ' cboDia
        ' 
        cboDia.FormattingEnabled = True
        cboDia.Location = New Point(287, 282)
        cboDia.Name = "cboDia"
        cboDia.Size = New Size(121, 23)
        cboDia.TabIndex = 3
        ' 
        ' dtpHoraInicio
        ' 
        dtpHoraInicio.Format = DateTimePickerFormat.Time
        dtpHoraInicio.Location = New Point(76, 310)
        dtpHoraInicio.Name = "dtpHoraInicio"
        dtpHoraInicio.ShowUpDown = True
        dtpHoraInicio.Size = New Size(200, 23)
        dtpHoraInicio.TabIndex = 4
        ' 
        ' dtpHoraFin
        ' 
        dtpHoraFin.Format = DateTimePickerFormat.Time
        dtpHoraFin.Location = New Point(342, 318)
        dtpHoraFin.Name = "dtpHoraFin"
        dtpHoraFin.ShowUpDown = True
        dtpHoraFin.Size = New Size(200, 23)
        dtpHoraFin.TabIndex = 5
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(12, 349)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 6
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(115, 349)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(75, 23)
        btnGuardar.TabIndex = 7
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' btnDesactivar
        ' 
        btnDesactivar.Location = New Point(219, 349)
        btnDesactivar.Name = "btnDesactivar"
        btnDesactivar.Size = New Size(75, 23)
        btnDesactivar.TabIndex = 8
        btnDesactivar.Text = "Desactivar"
        btnDesactivar.UseVisualStyleBackColor = True
        ' 
        ' lblInicio
        ' 
        lblInicio.AutoSize = True
        lblInicio.Location = New Point(25, 310)
        lblInicio.Name = "lblInicio"
        lblInicio.Size = New Size(36, 15)
        lblInicio.TabIndex = 9
        lblInicio.Text = "Inicio"
        ' 
        ' lblSala
        ' 
        lblSala.AutoSize = True
        lblSala.Location = New Point(25, 272)
        lblSala.Name = "lblSala"
        lblSala.Size = New Size(28, 15)
        lblSala.TabIndex = 10
        lblSala.Text = "Sala"
        ' 
        ' lblHorario
        ' 
        lblHorario.AutoSize = True
        lblHorario.Location = New Point(386, -1)
        lblHorario.Name = "lblHorario"
        lblHorario.Size = New Size(52, 15)
        lblHorario.TabIndex = 11
        lblHorario.Text = "Horarios"
        ' 
        ' lblDia
        ' 
        lblDia.AutoSize = True
        lblDia.Location = New Point(229, 282)
        lblDia.Name = "lblDia"
        lblDia.Size = New Size(24, 15)
        lblDia.TabIndex = 12
        lblDia.Text = "Dia"
        ' 
        ' lblInstructor
        ' 
        lblInstructor.AutoSize = True
        lblInstructor.Location = New Point(12, 245)
        lblInstructor.Name = "lblInstructor"
        lblInstructor.Size = New Size(58, 15)
        lblInstructor.TabIndex = 13
        lblInstructor.Text = "Instructor"
        ' 
        ' lblActividad
        ' 
        lblActividad.AutoSize = True
        lblActividad.Location = New Point(219, 253)
        lblActividad.Name = "lblActividad"
        lblActividad.Size = New Size(57, 15)
        lblActividad.TabIndex = 14
        lblActividad.Text = "Actividad"
        ' 
        ' FiltroInstructor
        ' 
        FiltroInstructor.AutoSize = True
        FiltroInstructor.Location = New Point(21, 29)
        FiltroInstructor.Name = "FiltroInstructor"
        FiltroInstructor.Size = New Size(88, 15)
        FiltroInstructor.TabIndex = 15
        FiltroInstructor.Text = "Filtro Instructor"
        ' 
        ' lblFin
        ' 
        lblFin.AutoSize = True
        lblFin.Location = New Point(303, 318)
        lblFin.Name = "lblFin"
        lblFin.Size = New Size(23, 15)
        lblFin.TabIndex = 16
        lblFin.Text = "Fin"
        ' 
        ' cboFiltroInstructor
        ' 
        cboFiltroInstructor.FormattingEnabled = True
        cboFiltroInstructor.Location = New Point(115, 23)
        cboFiltroInstructor.Name = "cboFiltroInstructor"
        cboFiltroInstructor.Size = New Size(121, 23)
        cboFiltroInstructor.TabIndex = 17
        ' 
        ' cboFiltroSala
        ' 
        cboFiltroSala.FormattingEnabled = True
        cboFiltroSala.Location = New Point(351, 26)
        cboFiltroSala.Name = "cboFiltroSala"
        cboFiltroSala.Size = New Size(121, 23)
        cboFiltroSala.TabIndex = 18
        ' 
        ' dgvHorarios
        ' 
        dgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHorarios.Location = New Point(-1, 55)
        dgvHorarios.Name = "dgvHorarios"
        dgvHorarios.Size = New Size(798, 174)
        dgvHorarios.TabIndex = 19
        ' 
        ' FiltroSala
        ' 
        FiltroSala.AutoSize = True
        FiltroSala.Location = New Point(287, 26)
        FiltroSala.Name = "FiltroSala"
        FiltroSala.Size = New Size(58, 15)
        FiltroSala.TabIndex = 20
        FiltroSala.Text = "Filtro Sala"
        ' 
        ' lblChoque
        ' 
        lblChoque.AutoSize = True
        lblChoque.Location = New Point(25, 388)
        lblChoque.Name = "lblChoque"
        lblChoque.Size = New Size(0, 15)
        lblChoque.TabIndex = 21
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(28, 426)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(0, 15)
        lblEstado.TabIndex = 22
        ' 
        ' lblNuevosHorarios
        ' 
        lblNuevosHorarios.AutoSize = True
        lblNuevosHorarios.Location = New Point(377, 232)
        lblNuevosHorarios.Name = "lblNuevosHorarios"
        lblNuevosHorarios.Size = New Size(95, 15)
        lblNuevosHorarios.TabIndex = 23
        lblNuevosHorarios.Text = "Nuevos Horarios"
        ' 
        ' frmHorarios
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblNuevosHorarios)
        Controls.Add(lblEstado)
        Controls.Add(lblChoque)
        Controls.Add(FiltroSala)
        Controls.Add(dgvHorarios)
        Controls.Add(cboFiltroSala)
        Controls.Add(cboFiltroInstructor)
        Controls.Add(lblFin)
        Controls.Add(FiltroInstructor)
        Controls.Add(lblActividad)
        Controls.Add(lblInstructor)
        Controls.Add(lblDia)
        Controls.Add(lblHorario)
        Controls.Add(lblSala)
        Controls.Add(lblInicio)
        Controls.Add(btnDesactivar)
        Controls.Add(btnGuardar)
        Controls.Add(btnNuevo)
        Controls.Add(dtpHoraFin)
        Controls.Add(dtpHoraInicio)
        Controls.Add(cboDia)
        Controls.Add(cboSala)
        Controls.Add(cboActividad)
        Controls.Add(cboInstructor)
        Name = "frmHorarios"
        Text = "frmHorarios"
        CType(dgvHorarios, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboInstructor As ComboBox
    Friend WithEvents cboActividad As ComboBox
    Friend WithEvents cboSala As ComboBox
    Friend WithEvents cboDia As ComboBox
    Friend WithEvents dtpHoraInicio As DateTimePicker
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnDesactivar As Button
    Friend WithEvents lblInicio As Label
    Friend WithEvents lblSala As Label
    Friend WithEvents lblHorario As Label
    Friend WithEvents lblDia As Label
    Friend WithEvents lblInstructor As Label
    Friend WithEvents lblActividad As Label
    Friend WithEvents FiltroInstructor As Label
    Friend WithEvents lblFin As Label
    Friend WithEvents cboFiltroInstructor As ComboBox
    Friend WithEvents cboFiltroSala As ComboBox
    Friend WithEvents dgvHorarios As DataGridView
    Friend WithEvents FiltroSala As Label
    Friend WithEvents lblChoque As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblNuevosHorarios As Label
End Class
