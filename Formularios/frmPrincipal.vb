Public Class frmPrincipal

    Private Sub frmPrincipal_Load(
        sender As Object,
        e As EventArgs) Handles MyBase.Load

        'Estado inicial
        lblTitulo.Text = "GymControl"
        sstSesionn.Text = "Sesión iniciada"

        'Abrir siempre en Inicio
        MostrarInicio()

    End Sub

    '========================================================
    ' MOSTRAR INICIO
    '========================================================
    Private Sub MostrarInicio()

        pnlNavegacion.Visible = True
        pnlIndicadores.Visible = True
        pnlClasesHoy.Visible = True
        pnlIngresosMes.Visible = True
        pnlMembresiasVencer.Visible = True
        pnlSociosActivos.Visible = True

        lblTitulo.Text = "Panel principal"

    End Sub

    '========================================================
    ' BOTÓN INICIO
    '========================================================
    Private Sub btnInicio_Click(
        sender As Object,
        e As EventArgs) Handles btnInicio.Click

        MostrarInicio()

    End Sub

    '========================================================
    ' BOTÓN INSTRUCTORES
    '========================================================
    Private Sub btnInstructores_Click(
        sender As Object,
        e As EventArgs) Handles btnInstructores.Click
        MessageBox.Show("Boton Instructores funcionando")
        Dim formulario As New frmInstructores()

        formulario.ShowDialog()

    End Sub

    '========================================================
    ' BOTÓN SOCIOS
    '========================================================
    Private Sub btnSocios_Click(
        sender As Object,
        e As EventArgs) Handles btnSocios.Click

        Dim formulario As New frmSocios()

        formulario.ShowDialog()

    End Sub

    '========================================================
    ' NUEVO SOCIO
    '========================================================
    Private Sub btnNuevoSocio_Click(
        sender As Object,
        e As EventArgs) Handles btnNuevoSocio.Click

        Dim formulario As New frmSocios()

        formulario.ShowDialog()

    End Sub

    '========================================================
    ' MEMBRESÍAS
    '========================================================
    Private Sub btnMembresias_Click(
        sender As Object,
        e As EventArgs) Handles btnMembresias.Click

        MessageBox.Show(
            "Módulo de Membresías.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' PAGOS
    '========================================================
    Private Sub btnPagos_Click(
        sender As Object,
        e As EventArgs) Handles btnPagos.Click

        MessageBox.Show(
            "Módulo de Pagos.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' REGISTRAR PAGO
    '========================================================
    Private Sub btnRegistrarPago_Click(
        sender As Object,
        e As EventArgs) Handles btnRegistrarPago.Click

        MessageBox.Show(
            "Módulo para registrar pagos.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' RENOVAR MEMBRESÍA
    '========================================================
    Private Sub btnRenovarMembresia_Click(
        sender As Object,
        e As EventArgs) Handles btnRenovarMembresia.Click

        MessageBox.Show(
            "Módulo para renovar membresías.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' HORARIOS
    '========================================================
    Private Sub btnHorarios_Click(
        sender As Object,
        e As EventArgs) Handles btnHorarios.Click

        MessageBox.Show(
            "Módulo de Horarios.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' VER HORARIOS
    '========================================================
    Private Sub btnVerHorarios_Click(
        sender As Object,
        e As EventArgs) Handles btnVerHorarios.Click

        MessageBox.Show(
            "Consulta de horarios.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' ACTIVIDAD DE SALAS
    '========================================================
    Private Sub btnActvSalas_Click(
        sender As Object,
        e As EventArgs) Handles btnActSalas.Click

        MessageBox.Show(
            "Módulo de actividad de salas.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' BITÁCORA DE ACCESOS
    '========================================================
    Private Sub btnBitacoradeaccesos_Click(
        sender As Object,
        e As EventArgs) Handles btnBitacoradeaccesos.Click

        MessageBox.Show(
            "Módulo de bitácora de accesos.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' USUARIOS Y ROLES
    '========================================================
    Private Sub btnUsuarioyroles_Click(
        sender As Object,
        e As EventArgs) Handles btnUsuarioyroles.Click

        MessageBox.Show(
            "Módulo de usuarios y roles.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

    End Sub

    '========================================================
    ' CERRAR SESIÓN
    '========================================================
    Private Sub btnCerrarsesion_Click(
        sender As Object,
        e As EventArgs) Handles btnCerrarsesion.Click

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Desea cerrar la sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then

            Me.Hide()

            Dim login As New frmLogin()

            login.ShowDialog()

            Me.Close()

        End If

    End Sub

    '========================================================
    ' MENÚ INSTRUCTORES
    '========================================================
    Private Sub InstructoresToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs) Handles InstructoresToolStripMenuItem.Click

        btnInstructores.PerformClick()

    End Sub

    '========================================================
    ' MENÚ HORARIOS
    '========================================================
    Private Sub HorariosToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs) Handles HorariosToolStripMenuItem.Click

        btnHorarios.PerformClick()

    End Sub

    '========================================================
    ' MENÚ SOCIOS
    '========================================================
    Private Sub SociosToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs) Handles SociosToolStripMenuItem.Click

        btnSocios.PerformClick()

    End Sub

    '========================================================
    ' MENÚ MEMBRESÍAS
    '========================================================
    Private Sub MembresiasToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs) Handles MembresiasToolStripMenuItem.Click

        btnMembresias.PerformClick()

    End Sub

    '========================================================
    ' MENÚ PAGOS
    '========================================================
    Private Sub PagosToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs) Handles PagosToolStripMenuItem.Click

        btnPagos.PerformClick()

    End Sub

End Class