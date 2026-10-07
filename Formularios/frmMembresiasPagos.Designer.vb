<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembresiasPagos
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
        components = New ComponentModel.Container()
        Monto = New Label()
        txtCedula = New TextBox()
        btnRegistrar = New Button()
        lblTotal = New Label()
        cboTipo = New ComboBox()
        dtpInicio = New DateTimePicker()
        dtpVencimiento = New DateTimePicker()
        txtMonto = New TextBox()
        cboEstado = New ComboBox()
        MySqlCommandBuilder1 = New MySqlConnector.MySqlCommandBuilder()
        btnCancelar = New Button()
        btnSuspender = New Button()
        btnBuscarSocio = New Button()
        btnRenovar = New Button()
        dgvMembresias = New DataGridView()
        lblPrecio = New Label()
        lblCedula = New Label()
        lblEstado = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        txtPrecio = New TextBox()
        txtObservacion = New TextBox()
        txtReferencia = New TextBox()
        cboMetodo = New ComboBox()
        btnRegistrarPago = New Button()
        dgvPagos = New DataGridView()
        lblBuscarSocio = New Label()
        lblSocio = New Label()
        lblSaldo = New Label()
        lblPagado = New Label()
        lblMembresiasPagos = New Label()
        lblTipo = New Label()
        lblVencimiento = New Label()
        lblInicio = New Label()
        btnAnularPago = New Button()
        btnNuevo = New Button()
        LblRefencia = New Label()
        lblMetodo = New Label()
        lblObservacion = New Label()
        CType(dgvMembresias, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvPagos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Monto
        ' 
        Monto.AutoSize = True
        Monto.Location = New Point(447, 98)
        Monto.Name = "Monto"
        Monto.Size = New Size(43, 15)
        Monto.TabIndex = 0
        Monto.Text = "Monto"
        ' 
        ' txtCedula
        ' 
        txtCedula.Location = New Point(80, 43)
        txtCedula.Name = "txtCedula"
        txtCedula.Size = New Size(100, 23)
        txtCedula.TabIndex = 1
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.Location = New Point(92, 283)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(75, 23)
        btnRegistrar.TabIndex = 2
        btnRegistrar.Text = "Registrar"
        btnRegistrar.UseVisualStyleBackColor = True
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(662, 54)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(0, 15)
        lblTotal.TabIndex = 3
        ' 
        ' cboTipo
        ' 
        cboTipo.FormattingEnabled = True
        cboTipo.Location = New Point(67, 98)
        cboTipo.Name = "cboTipo"
        cboTipo.Size = New Size(121, 23)
        cboTipo.TabIndex = 4
        ' 
        ' dtpInicio
        ' 
        dtpInicio.Format = DateTimePickerFormat.Short
        dtpInicio.Location = New Point(67, 134)
        dtpInicio.Name = "dtpInicio"
        dtpInicio.Size = New Size(200, 23)
        dtpInicio.TabIndex = 5
        ' 
        ' dtpVencimiento
        ' 
        dtpVencimiento.Format = DateTimePickerFormat.Short
        dtpVencimiento.Location = New Point(80, 174)
        dtpVencimiento.Name = "dtpVencimiento"
        dtpVencimiento.Size = New Size(200, 23)
        dtpVencimiento.TabIndex = 6
        ' 
        ' txtMonto
        ' 
        txtMonto.Location = New Point(511, 95)
        txtMonto.Name = "txtMonto"
        txtMonto.Size = New Size(100, 23)
        txtMonto.TabIndex = 7
        ' 
        ' cboEstado
        ' 
        cboEstado.FormattingEnabled = True
        cboEstado.Location = New Point(80, 242)
        cboEstado.Name = "cboEstado"
        cboEstado.Size = New Size(121, 23)
        cboEstado.TabIndex = 8
        ' 
        ' MySqlCommandBuilder1
        ' 
        MySqlCommandBuilder1.DataAdapter = Nothing
        MySqlCommandBuilder1.QuotePrefix = "`"
        MySqlCommandBuilder1.QuoteSuffix = "`"
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(353, 285)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(75, 23)
        btnCancelar.TabIndex = 9
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' btnSuspender
        ' 
        btnSuspender.Location = New Point(263, 285)
        btnSuspender.Name = "btnSuspender"
        btnSuspender.Size = New Size(75, 23)
        btnSuspender.TabIndex = 10
        btnSuspender.Text = "Suspender"
        btnSuspender.UseVisualStyleBackColor = True
        ' 
        ' btnBuscarSocio
        ' 
        btnBuscarSocio.Location = New Point(196, 46)
        btnBuscarSocio.Name = "btnBuscarSocio"
        btnBuscarSocio.Size = New Size(75, 23)
        btnBuscarSocio.TabIndex = 11
        btnBuscarSocio.Text = "Buscar"
        btnBuscarSocio.UseVisualStyleBackColor = True
        ' 
        ' btnRenovar
        ' 
        btnRenovar.Location = New Point(173, 285)
        btnRenovar.Name = "btnRenovar"
        btnRenovar.Size = New Size(75, 23)
        btnRenovar.TabIndex = 12
        btnRenovar.Text = "Renovar"
        btnRenovar.UseVisualStyleBackColor = True
        ' 
        ' dgvMembresias
        ' 
        dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMembresias.Location = New Point(1, 311)
        dgvMembresias.Name = "dgvMembresias"
        dgvMembresias.Size = New Size(427, 141)
        dgvMembresias.TabIndex = 13
        ' 
        ' lblPrecio
        ' 
        lblPrecio.AutoSize = True
        lblPrecio.Location = New Point(34, 216)
        lblPrecio.Name = "lblPrecio"
        lblPrecio.Size = New Size(40, 15)
        lblPrecio.TabIndex = 14
        lblPrecio.Text = "Precio"
        ' 
        ' lblCedula
        ' 
        lblCedula.AutoSize = True
        lblCedula.Location = New Point(30, 46)
        lblCedula.Name = "lblCedula"
        lblCedula.Size = New Size(44, 15)
        lblCedula.TabIndex = 15
        lblCedula.Text = "Cedula"
        ' 
        ' lblEstado
        ' 
        lblEstado.AutoSize = True
        lblEstado.Location = New Point(30, 250)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New Size(42, 15)
        lblEstado.TabIndex = 16
        lblEstado.Text = "Estado"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' txtPrecio
        ' 
        txtPrecio.Location = New Point(88, 213)
        txtPrecio.Name = "txtPrecio"
        txtPrecio.ReadOnly = True
        txtPrecio.Size = New Size(100, 23)
        txtPrecio.TabIndex = 18
        ' 
        ' txtObservacion
        ' 
        txtObservacion.Location = New Point(532, 208)
        txtObservacion.Name = "txtObservacion"
        txtObservacion.Size = New Size(100, 23)
        txtObservacion.TabIndex = 19
        ' 
        ' txtReferencia
        ' 
        txtReferencia.Location = New Point(521, 172)
        txtReferencia.Name = "txtReferencia"
        txtReferencia.Size = New Size(100, 23)
        txtReferencia.TabIndex = 20
        ' 
        ' cboMetodo
        ' 
        cboMetodo.FormattingEnabled = True
        cboMetodo.Location = New Point(511, 137)
        cboMetodo.Name = "cboMetodo"
        cboMetodo.Size = New Size(121, 23)
        cboMetodo.TabIndex = 21
        ' 
        ' btnRegistrarPago
        ' 
        btnRegistrarPago.Location = New Point(439, 246)
        btnRegistrarPago.Name = "btnRegistrarPago"
        btnRegistrarPago.Size = New Size(93, 23)
        btnRegistrarPago.TabIndex = 22
        btnRegistrarPago.Text = "RegistrarPago"
        btnRegistrarPago.UseVisualStyleBackColor = True
        ' 
        ' dgvPagos
        ' 
        dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPagos.Location = New Point(434, 311)
        dgvPagos.Name = "dgvPagos"
        dgvPagos.Size = New Size(368, 141)
        dgvPagos.TabIndex = 23
        ' 
        ' lblBuscarSocio
        ' 
        lblBuscarSocio.AutoSize = True
        lblBuscarSocio.Location = New Point(12, 11)
        lblBuscarSocio.Name = "lblBuscarSocio"
        lblBuscarSocio.Size = New Size(74, 15)
        lblBuscarSocio.TabIndex = 24
        lblBuscarSocio.Text = "Buscar Socio"
        ' 
        ' lblSocio
        ' 
        lblSocio.AutoSize = True
        lblSocio.Location = New Point(30, 75)
        lblSocio.Name = "lblSocio"
        lblSocio.Size = New Size(0, 15)
        lblSocio.TabIndex = 25
        ' 
        ' lblSaldo
        ' 
        lblSaldo.AutoSize = True
        lblSaldo.Location = New Point(434, 50)
        lblSaldo.Name = "lblSaldo"
        lblSaldo.Size = New Size(0, 15)
        lblSaldo.TabIndex = 26
        ' 
        ' lblPagado
        ' 
        lblPagado.AutoSize = True
        lblPagado.Location = New Point(532, 50)
        lblPagado.Name = "lblPagado"
        lblPagado.Size = New Size(0, 15)
        lblPagado.TabIndex = 27
        ' 
        ' lblMembresiasPagos
        ' 
        lblMembresiasPagos.AutoSize = True
        lblMembresiasPagos.Font = New Font("Segoe UI", 17.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMembresiasPagos.Location = New Point(301, 19)
        lblMembresiasPagos.Name = "lblMembresiasPagos"
        lblMembresiasPagos.Size = New Size(233, 31)
        lblMembresiasPagos.TabIndex = 28
        lblMembresiasPagos.Text = "Membresias Y pagos"
        ' 
        ' lblTipo
        ' 
        lblTipo.AutoSize = True
        lblTipo.Location = New Point(30, 101)
        lblTipo.Name = "lblTipo"
        lblTipo.Size = New Size(31, 15)
        lblTipo.TabIndex = 29
        lblTipo.Text = "Tipo"
        ' 
        ' lblVencimiento
        ' 
        lblVencimiento.AutoSize = True
        lblVencimiento.Location = New Point(1, 180)
        lblVencimiento.Name = "lblVencimiento"
        lblVencimiento.Size = New Size(73, 15)
        lblVencimiento.TabIndex = 30
        lblVencimiento.Text = "Vencimiento"
        ' 
        ' lblInicio
        ' 
        lblInicio.AutoSize = True
        lblInicio.Location = New Point(25, 134)
        lblInicio.Name = "lblInicio"
        lblInicio.Size = New Size(36, 15)
        lblInicio.TabIndex = 31
        lblInicio.Text = "Inicio"
        ' 
        ' btnAnularPago
        ' 
        btnAnularPago.Location = New Point(551, 246)
        btnAnularPago.Name = "btnAnularPago"
        btnAnularPago.Size = New Size(97, 23)
        btnAnularPago.TabIndex = 32
        btnAnularPago.Text = "Anular Pago"
        btnAnularPago.UseVisualStyleBackColor = True
        ' 
        ' btnNuevo
        ' 
        btnNuevo.Location = New Point(11, 282)
        btnNuevo.Name = "btnNuevo"
        btnNuevo.Size = New Size(75, 23)
        btnNuevo.TabIndex = 33
        btnNuevo.Text = "Nuevo"
        btnNuevo.UseVisualStyleBackColor = True
        ' 
        ' LblRefencia
        ' 
        LblRefencia.AutoSize = True
        LblRefencia.Location = New Point(441, 180)
        LblRefencia.Name = "LblRefencia"
        LblRefencia.Size = New Size(62, 15)
        LblRefencia.TabIndex = 34
        LblRefencia.Text = "Referencia"
        ' 
        ' lblMetodo
        ' 
        lblMetodo.AutoSize = True
        lblMetodo.Location = New Point(447, 137)
        lblMetodo.Name = "lblMetodo"
        lblMetodo.Size = New Size(49, 15)
        lblMetodo.TabIndex = 35
        lblMetodo.Text = "Metodo"
        ' 
        ' lblObservacion
        ' 
        lblObservacion.AutoSize = True
        lblObservacion.Location = New Point(441, 216)
        lblObservacion.Name = "lblObservacion"
        lblObservacion.Size = New Size(73, 15)
        lblObservacion.TabIndex = 36
        lblObservacion.Text = "Observacion"
        ' 
        ' frmMembresiasPagos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblObservacion)
        Controls.Add(lblMetodo)
        Controls.Add(LblRefencia)
        Controls.Add(btnNuevo)
        Controls.Add(btnAnularPago)
        Controls.Add(lblInicio)
        Controls.Add(lblVencimiento)
        Controls.Add(lblTipo)
        Controls.Add(lblMembresiasPagos)
        Controls.Add(lblPagado)
        Controls.Add(lblSaldo)
        Controls.Add(lblSocio)
        Controls.Add(lblBuscarSocio)
        Controls.Add(dgvPagos)
        Controls.Add(btnRegistrarPago)
        Controls.Add(cboMetodo)
        Controls.Add(txtReferencia)
        Controls.Add(txtObservacion)
        Controls.Add(txtPrecio)
        Controls.Add(lblEstado)
        Controls.Add(lblCedula)
        Controls.Add(lblPrecio)
        Controls.Add(dgvMembresias)
        Controls.Add(btnRenovar)
        Controls.Add(btnBuscarSocio)
        Controls.Add(btnSuspender)
        Controls.Add(btnCancelar)
        Controls.Add(cboEstado)
        Controls.Add(txtMonto)
        Controls.Add(dtpVencimiento)
        Controls.Add(dtpInicio)
        Controls.Add(cboTipo)
        Controls.Add(lblTotal)
        Controls.Add(btnRegistrar)
        Controls.Add(txtCedula)
        Controls.Add(Monto)
        Name = "frmMembresiasPagos"
        Text = "frmMembresiasPagos"
        CType(dgvMembresias, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvPagos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Monto As Label
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents dtpVencimiento As DateTimePicker
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents MySqlCommandBuilder1 As MySqlConnector.MySqlCommandBuilder
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnSuspender As Button
    Friend WithEvents btnBuscarSocio As Button
    Friend WithEvents btnRenovar As Button
    Friend WithEvents dgvMembresias As DataGridView
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblCedula As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents cboMetodo As ComboBox
    Friend WithEvents btnRegistrarPago As Button
    Friend WithEvents dgvPagos As DataGridView
    Friend WithEvents lblBuscarSocio As Label
    Friend WithEvents lblSocio As Label
    Friend WithEvents lblSaldo As Label
    Friend WithEvents lblPagado As Label
    Friend WithEvents lblMembresiasPagos As Label
    Friend WithEvents lblTipo As Label
    Friend WithEvents lblVencimiento As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents btnAnularPago As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents LblRefencia As Label
    Friend WithEvents lblMetodo As Label
    Friend WithEvents lblObservacion As Label
End Class
