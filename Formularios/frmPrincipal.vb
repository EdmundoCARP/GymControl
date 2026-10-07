Public Class frmPrincipal
    Private Sub pnlSociosActivos_Paint(sender As Object, e As PaintEventArgs) Handles pnlSociosActivos.Paint

    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblProxx_Click(sender As Object, e As EventArgs) Handles lblProxx.Click

    End Sub

    Private Sub pnlIndicadores_Paint(sender As Object, e As PaintEventArgs) Handles pnlIndicadores.Paint

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvgClasesHoy.CellContentClick

    End Sub

    Private Sub btnInstructores_Click(sender As Object, e As EventArgs) Handles btnInstructores.Click

    End Sub

    Private Sub frmPrincipal_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnMembresiasPagos_Click(
    sender As Object,
    e As EventArgs
) Handles btnMembresiasPagos.Click

        Dim formulario As New frmMembresiasPagos()
        formulario.ShowDialog()

    End Sub

    Private Sub btnRegistrarPago_Click(
    sender As Object,
    e As EventArgs
) Handles btnRegistrarPago.Click

        Dim formulario As New frmMembresiasPagos()
        formulario.ShowDialog()

    End Sub


    Private Sub btnRenovarMembresia_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRenovarMembresia.Click

        Dim formulario As New frmMembresiasPagos()
        formulario.ShowDialog()

    End Sub

End Class