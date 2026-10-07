Imports System.Data

Public Class frmMembresiasPagos

    Private idSocioSeleccionado As Integer = 0
    Private idMembresiaSeleccionada As Integer = 0
    Private idPagoSeleccionado As Integer = 0

    Private Sub frmMembresiasPagos_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        If Sesion.Rol <> "Administrador" AndAlso
           Sesion.Rol <> "Recepcionista" Then

            MessageBox.Show(
                "No tiene permisos para acceder a este módulo.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Me.Close()
            Return

        End If

        cboEstado.Items.Clear()
        cboEstado.Items.Add("Activa")
        cboEstado.Items.Add("Suspendida")
        cboEstado.Items.Add("Cancelada")
        cboEstado.SelectedIndex = 0

        cboMetodo.Items.Clear()
        cboMetodo.Items.Add("Efectivo")
        cboMetodo.Items.Add("Tarjeta")
        cboMetodo.Items.Add("Transferencia")
        cboMetodo.SelectedIndex = 0

        dtpInicio.Value = DateTime.Today
        dtpVencimiento.Value = DateTime.Today.AddDays(30)

        txtPrecio.ReadOnly = True

        lblSocio.Text = "Socio no seleccionado"
        lblTotal.Text = "Total: C$ 0.00"
        lblPagado.Text = "Pagado: C$ 0.00"
        lblSaldo.Text = "Saldo: C$ 0.00"

        CargarTipos()

        dgvMembresias.AutoGenerateColumns = True
        dgvPagos.AutoGenerateColumns = True

    End Sub


    Private Sub CargarTipos()

        Try

            Dim tabla As DataTable =
                MembresiaDAO.ObtenerTipos()

            cboTipo.DataSource = tabla
            cboTipo.DisplayMember = "nombre"
            cboTipo.ValueMember = "id_tipo_membresia"

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los tipos de membresía." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub btnBuscarSocio_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscarSocio.Click

        If txtCedula.Text.Trim() = "" Then

            MessageBox.Show(
                "Ingrese la cédula del socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCedula.Focus()
            Return

        End If

        Try

            Dim tabla As DataTable =
                MembresiaDAO.BuscarSocioPorCedula(
                    txtCedula.Text.Trim()
                )

            If tabla.Rows.Count = 0 Then

                MessageBox.Show(
                    "No se encontró un socio con esa cédula.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                idSocioSeleccionado = 0
                lblSocio.Text = "Socio no seleccionado"
                dgvMembresias.DataSource = Nothing

                Return

            End If

            Dim fila As DataRow = tabla.Rows(0)

            idSocioSeleccionado =
                Convert.ToInt32(fila("id_socio"))

            lblSocio.Text =
                fila("nombres").ToString() &
                " " &
                fila("apellidos").ToString()

            CargarMembresias()

        Catch ex As Exception

            MessageBox.Show(
                "Error al buscar el socio." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub CargarMembresias()

        If idSocioSeleccionado = 0 Then
            Return
        End If

        Try

            dgvMembresias.DataSource =
                MembresiaDAO.ObtenerMembresias(
                    idSocioSeleccionado
                )

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar las membresías." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub cboTipo_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboTipo.SelectedIndexChanged

        If cboTipo.SelectedItem Is Nothing Then
            Return
        End If

        Try

            Dim fila As DataRowView =
                TryCast(cboTipo.SelectedItem, DataRowView)

            If fila Is Nothing Then
                Return
            End If

            Dim precio As Decimal =
                Convert.ToDecimal(fila("precio"))

            Dim duracion As Integer =
                Convert.ToInt32(fila("duracion_dias"))

            txtPrecio.Text =
                precio.ToString("0.00")

            dtpVencimiento.Value =
                dtpInicio.Value.AddDays(duracion)

        Catch
        End Try

    End Sub


    Private Sub dtpInicio_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpInicio.ValueChanged

        If cboTipo.SelectedItem Is Nothing Then
            Return
        End If

        Try

            Dim fila As DataRowView =
                TryCast(cboTipo.SelectedItem, DataRowView)

            If fila Is Nothing Then
                Return
            End If

            Dim duracion As Integer =
                Convert.ToInt32(fila("duracion_dias"))

            dtpVencimiento.Value =
                dtpInicio.Value.AddDays(duracion)

        Catch
        End Try

    End Sub


    Private Sub btnRegistrar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegistrar.Click

        If idSocioSeleccionado = 0 Then

            MessageBox.Show(
                "Primero debe buscar y seleccionar un socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If cboTipo.SelectedValue Is Nothing Then

            MessageBox.Show(
                "Seleccione un tipo de membresía.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If dtpVencimiento.Value <= dtpInicio.Value Then

            MessageBox.Show(
                "La fecha de vencimiento debe ser posterior a la fecha de inicio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Dim precio As Decimal

            If Not Decimal.TryParse(
                txtPrecio.Text,
                precio
            ) Then

                MessageBox.Show(
                    "El precio no es válido.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            MembresiaDAO.Crear(
                idSocioSeleccionado,
                Convert.ToInt32(cboTipo.SelectedValue),
                dtpInicio.Value,
                dtpVencimiento.Value,
                precio,
                "Activa"
            )

            MessageBox.Show(
                "Membresía registrada correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarMembresias()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo registrar la membresía." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub dgvMembresias_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvMembresias.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim fila =
            dgvMembresias.Rows(e.RowIndex)

        If fila.Cells("id_membresia").Value Is Nothing Then
            Return
        End If

        idMembresiaSeleccionada =
            Convert.ToInt32(
                fila.Cells("id_membresia").Value
            )

        If fila.Cells("fecha_inicio").Value IsNot Nothing Then
            dtpInicio.Value =
                Convert.ToDateTime(
                    fila.Cells("fecha_inicio").Value
                )
        End If

        If fila.Cells("fecha_vencimiento").Value IsNot Nothing Then
            dtpVencimiento.Value =
                Convert.ToDateTime(
                    fila.Cells("fecha_vencimiento").Value
                )
        End If

        If fila.Cells("precio").Value IsNot Nothing Then
            txtPrecio.Text =
                Convert.ToDecimal(
                    fila.Cells("precio").Value
                ).ToString("0.00")
        End If

        If fila.Cells("estado").Value IsNot Nothing Then
            cboEstado.Text =
                fila.Cells("estado").Value.ToString()
        End If

        CargarResumenPago()

        CargarPagos()

    End Sub


    Private Sub CargarResumenPago()

        If idMembresiaSeleccionada = 0 Then
            Return
        End If

        Try

            Dim tabla =
                MembresiaDAO.ObtenerResumenPago(
                    idMembresiaSeleccionada
                )

            If tabla.Rows.Count = 0 Then
                Return
            End If

            Dim fila = tabla.Rows(0)

            Dim total As Decimal =
                Convert.ToDecimal(fila("total"))

            Dim pagado As Decimal =
                Convert.ToDecimal(fila("pagado"))

            Dim saldo As Decimal =
                Convert.ToDecimal(fila("saldo"))

            lblTotal.Text =
                "Total: C$ " &
                total.ToString("0.00")

            lblPagado.Text =
                "Pagado: C$ " &
                pagado.ToString("0.00")

            lblSaldo.Text =
                "Saldo: C$ " &
                saldo.ToString("0.00")

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo calcular el saldo." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub


    Private Sub CargarPagos()

        If idMembresiaSeleccionada = 0 Then
            Return
        End If

        Try

            dgvPagos.DataSource =
                MembresiaDAO.ObtenerPagos(
                    idMembresiaSeleccionada
                )

        Catch ex As Exception

            MessageBox.Show(
                "No se pudieron cargar los pagos." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub


    Private Sub btnRegistrarPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegistrarPago.Click

        If idMembresiaSeleccionada = 0 Then

            MessageBox.Show(
                "Seleccione una membresía primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim monto As Decimal

        If Not Decimal.TryParse(
            txtMonto.Text,
            monto
        ) OrElse monto <= 0 Then

            MessageBox.Show(
                "Ingrese un monto válido.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Dim tabla =
                MembresiaDAO.ObtenerResumenPago(
                    idMembresiaSeleccionada
                )

            If tabla.Rows.Count = 0 Then
                Return
            End If

            Dim saldo As Decimal =
                Convert.ToDecimal(
                    tabla.Rows(0)("saldo")
                )

            If monto > saldo Then

                MessageBox.Show(
                    "El pago no puede ser mayor que el saldo pendiente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            MembresiaDAO.RegistrarPago(
                idMembresiaSeleccionada,
                monto,
                cboMetodo.Text,
                txtReferencia.Text.Trim(),
                txtObservacion.Text.Trim()
            )

            MessageBox.Show(
                "Pago registrado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            txtMonto.Clear()
            txtReferencia.Clear()
            txtObservacion.Clear()

            CargarResumenPago()
            CargarPagos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo registrar el pago." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub dgvPagos_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvPagos.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim fila =
            dgvPagos.Rows(e.RowIndex)

        If fila.Cells("id_pago").Value Is Nothing Then
            Return
        End If

        idPagoSeleccionado =
            Convert.ToInt32(
                fila.Cells("id_pago").Value
            )

    End Sub


    Private Sub btnAnularPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAnularPago.Click

        If idPagoSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un pago.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If MessageBox.Show(
            "¿Está seguro de anular este pago?",
            "GymControl",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        ) <> DialogResult.Yes Then

            Return

        End If

        Try

            MembresiaDAO.AnularPago(
                idPagoSeleccionado
            )

            MessageBox.Show(
                "Pago anulado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            idPagoSeleccionado = 0

            CargarResumenPago()
            CargarPagos()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo anular el pago." &
                Environment.NewLine &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub


    Private Sub btnSuspender_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSuspender.Click

        CambiarEstadoSeleccionado("Suspendida")

    End Sub


    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelar.Click

        CambiarEstadoSeleccionado("Cancelada")

    End Sub


    Private Sub CambiarEstadoSeleccionado(
        estado As String
    )

        If idMembresiaSeleccionada = 0 Then

            MessageBox.Show(
                "Seleccione una membresía.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            MembresiaDAO.ActualizarEstado(
                idMembresiaSeleccionada,
                estado
            )

            MessageBox.Show(
                "La membresía ahora está " & estado.ToLower() & ".",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarMembresias()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo cambiar el estado." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub


    Private Sub btnRenovar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRenovar.Click

        If idSocioSeleccionado = 0 Then

            MessageBox.Show(
                "Primero seleccione un socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If cboTipo.SelectedValue Is Nothing Then
            Return
        End If

        Try

            Dim precio As Decimal

            If Not Decimal.TryParse(
                txtPrecio.Text,
                precio
            ) Then

                MessageBox.Show(
                    "El precio no es válido."
                )

                Return

            End If

            MembresiaDAO.Crear(
                idSocioSeleccionado,
                Convert.ToInt32(cboTipo.SelectedValue),
                DateTime.Today,
                dtpVencimiento.Value,
                precio,
                "Activa"
            )

            MessageBox.Show(
                "Membresía renovada correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarMembresias()

        Catch ex As Exception

            MessageBox.Show(
                "No se pudo renovar la membresía." &
                Environment.NewLine &
                ex.Message
            )

        End Try

    End Sub

End Class