Public Class frmPortalSocio

    'Temporizador para actualizar la fecha y hora
    Private WithEvents reloj As New Timer()

    Private Sub frmPortalSocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '========================================
        ' FECHA Y HORA ACTUAL
        '========================================
        DateTimePicker1.Value = DateTime.Now

        lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")

        reloj.Interval = 1000
        reloj.Start()


        '========================================
        ' DATOS DEL SOCIO
        '========================================
        lblSaludo.Text = "Hola, Ana Lucía Rodríguez"

        lblDatosSocio.Text =
            "Socia N.º 3 • Último acceso: " &
            DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")


        '========================================
        ' MEMBRESÍA
        '========================================
        lblTipo.Text = "Mensual"
        lblInicio.Text = "01/09/2026"
        lblVence.Text = "30/09/2026"
        lblIncluyeClases.Text = "Sí"

        lblEstado.Text = "ACTIVA"

        lblDiasRestantes.Text = "Días restantes: 9 de 30"

        '30 días de membresía - 9 restantes
        prgMembresia.Minimum = 0
        prgMembresia.Maximum = 30
        prgMembresia.Value = 21


        '========================================
        ' ESTADO DE CUENTA
        '========================================
        lblTotal.Text = "C$ 800.00"
        lblPagado.Text = "C$ 500.00"
        lblSaldo.Text = "C$ 300.00"


        '========================================
        ' STATUS STRIP
        '========================================
        lblSesion.Text = "Usuario: Ana Lucía Rodríguez"
        lblRol.Text = "Rol: Socio | Solo lectura"


        '========================================
        ' INDICACIÓN
        '========================================
        lblNotaIndicacion.Text =
            "Renueve en recepción antes del vencimiento para no perder el acceso."


        '========================================
        ' TABLA DE PAGOS
        '========================================
        ConfigurarTablaPagos()


        '========================================
        ' TABLA DE CLASES
        '========================================
        ConfigurarTablaClases()

    End Sub


    '========================================
    ' ACTUALIZAR RELOJ CADA SEGUNDO
    '========================================
    Private Sub reloj_Tick(sender As Object, e As EventArgs) Handles reloj.Tick

        lblFechaHora.Text =
            DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")

    End Sub


    '========================================
    ' TABLA MIS PAGOS
    '========================================
    Private Sub ConfigurarTablaPagos()

        dgvMisPagos.Columns.Clear()
        dgvMisPagos.Rows.Clear()

        dgvMisPagos.Columns.Add("colFecha", "Fecha")
        dgvMisPagos.Columns.Add("colConcepto", "Concepto")
        dgvMisPagos.Columns.Add("colMonto", "Monto C$")
        dgvMisPagos.Columns.Add("colMetodo", "Método")

        dgvMisPagos.Rows.Add(
            "01/09/2026",
            "Mensual sep.",
            "500.00",
            "Efectivo"
        )

        dgvMisPagos.Rows.Add(
            "01/08/2026",
            "Mensual ago.",
            "800.00",
            "Tarjeta"
        )

        dgvMisPagos.Rows.Add(
            "02/05/2026",
            "Trimestral",
            "2,200.00",
            "Transfer."
        )

        dgvMisPagos.Rows.Add(
            "02/02/2026",
            "Mensual feb.",
            "800.00",
            "Efectivo"
        )

        dgvMisPagos.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvMisPagos.ReadOnly = True
        dgvMisPagos.AllowUserToAddRows = False
        dgvMisPagos.AllowUserToDeleteRows = False
        dgvMisPagos.RowHeadersVisible = False

    End Sub


    '========================================
    ' TABLA CLASES
    '========================================
    Private Sub ConfigurarTablaClases()

        dgvClases.Columns.Clear()
        dgvClases.Rows.Clear()

        dgvClases.Columns.Add("colDia", "Día")
        dgvClases.Columns.Add("colHora", "Hora")
        dgvClases.Columns.Add("colActividad", "Actividad")
        dgvClases.Columns.Add("colInstructor", "Instructor")
        dgvClases.Columns.Add("colSala", "Sala")

        dgvClases.Rows.Add(
            "Lunes",
            "06:00 a. m.",
            "Spinning",
            "Marvin Castillo",
            "Ciclo"
        )

        dgvClases.Rows.Add(
            "Lunes",
            "06:00 p. m.",
            "Zumba",
            "Yahaira López",
            "Sala A"
        )

        dgvClases.Rows.Add(
            "Martes",
            "07:00 a. m.",
            "Funcional",
            "Yahaira López",
            "Sala A"
        )

        dgvClases.Rows.Add(
            "Miércoles",
            "08:00 a. m.",
            "Yoga",
            "Fátima Rivas",
            "Sala B"
        )

        dgvClases.Rows.Add(
            "Jueves",
            "09:00 a. m.",
            "Boxeo",
            "Óscar Díaz",
            "Libre"
        )

        dgvClases.Rows.Add(
            "Viernes",
            "05:00 p. m.",
            "CrossFit",
            "Marvin Castillo",
            "Libre"
        )

        dgvClases.Rows.Add(
            "Sábado",
            "07:00 a. m.",
            "Yoga",
            "Fátima Rivas",
            "Sala B"
        )

        dgvClases.Rows.Add(
            "Sábado",
            "08:00 a. m.",
            "Zumba",
            "Yahaira López",
            "Sala A"
        )

        dgvClases.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvClases.ReadOnly = True
        dgvClases.AllowUserToAddRows = False
        dgvClases.AllowUserToDeleteRows = False
        dgvClases.RowHeadersVisible = False

    End Sub


    '========================================
    ' BOTÓN CAMBIAR CONTRASEÑA
    '========================================
    Private Sub btnCambiarContrasena_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCambiarContrasena.Click

        MessageBox.Show(
            "Aquí se abrirá el formulario para cambiar la contraseña.",
            "Cambiar contraseña",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub


    '========================================
    ' BOTÓN CERRAR SESIÓN
    '========================================
    Private Sub btnCerrarSesion_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCerrarSesion.Click

        Dim respuesta As DialogResult

        respuesta = MessageBox.Show(
            "¿Está seguro de que desea cerrar sesión?",
            "Cerrar sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If respuesta = DialogResult.Yes Then

            reloj.Stop()
            Me.Close()

        End If

    End Sub


    '========================================
    ' CERRAR FORMULARIO
    '========================================
    Private Sub frmPortalSocio_FormClosed(
        sender As Object,
        e As FormClosedEventArgs
    ) Handles MyBase.FormClosed

        reloj.Stop()
        reloj.Dispose()

    End Sub

End Class