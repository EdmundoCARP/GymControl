Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Globalization

''' <summary>
''' R01 · Recibo de pago en ticket de 80 mm.
''' Dibuja el ticket completo sobre un PrintDocument. El tamaño
''' de papel (80 mm ≈ 315 centésimas de pulgada) se fija antes
''' de imprimir y las coordenadas se manejan en MarginBounds.
''' </summary>
Public Class ImpresorRecibo

    Public Const AnchoTicket As Integer = 315
    Public Const AltoTicket As Integer = 760

    Private ReadOnly _recibo As DataRow

    Public Sub New(recibo As DataRow)

        If recibo Is Nothing Then
            Throw New ArgumentNullException(NameOf(recibo))
        End If

        _recibo = recibo

    End Sub

    ''' <summary>
    ''' Configura papel y margenes. Se llama desde el formulario
    ''' antes de la vista previa o de la impresión directa.
    ''' </summary>
    Public Sub PrepararDocumento(documento As PrintDocument)

        documento.DocumentName = "Recibo GymControl"
        documento.OriginAtMargins = False
        documento.DefaultPageSettings.PaperSize =
            New PaperSize("Ticket 80 mm", AnchoTicket, AltoTicket)
        documento.DefaultPageSettings.Margins =
            New Margins(12, 12, 12, 12)
        documento.DefaultPageSettings.Landscape = False

    End Sub

    Public Sub Dibujar(e As PrintPageEventArgs)

        Dim limites As Rectangle = e.MarginBounds
        Dim g As Graphics = e.Graphics

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Dim ancho As Single = limites.Width
        Dim x As Single = limites.Left
        Dim y As Single = limites.Top

        Dim centrado As New StringFormat()
        centrado.Alignment = StringAlignment.Center
        centrado.LineAlignment = StringAlignment.Near

        Dim izquierda As New StringFormat()
        izquierda.Alignment = StringAlignment.Near
        izquierda.LineAlignment = StringAlignment.Near

        Dim derecha As New StringFormat()
        derecha.Alignment = StringAlignment.Far
        derecha.LineAlignment = StringAlignment.Near

        Using fuenteTitulo As New Font("Segoe UI", 12.0F, FontStyle.Bold)
            Using fuenteSubtitulo As New Font("Segoe UI", 8.5F, FontStyle.Regular)
                Using fuenteNormal As New Font("Segoe UI", 8.0F, FontStyle.Regular)
                    Using fuenteNegrita As New Font("Segoe UI", 8.5F, FontStyle.Bold)
                        Using fuentePequena As New Font("Segoe UI", 7.5F, FontStyle.Regular)
                            Using tinta As New SolidBrush(Color.Black)
                                Using gris As New SolidBrush(Color.DimGray)
                                    Using linea As New Pen(Color.Black, 1.0F)

                                        ' Encabezado institucional.
                                        Dim altoTitulo As Single =
                                            g.MeasureString(
                                                "GIMNASIO TITÁN",
                                                fuenteTitulo,
                                                CInt(ancho)
                                            ).Height

                                        g.DrawString(
                                            "GIMNASIO TITÁN",
                                            fuenteTitulo,
                                            tinta,
                                            New RectangleF(x, y, ancho, altoTitulo),
                                            centrado
                                        )
                                        y += altoTitulo

                                        g.DrawString(
                                            "Recibo de pago",
                                            fuenteSubtitulo,
                                            gris,
                                            New RectangleF(x, y, ancho, 18),
                                            centrado
                                        )
                                        y += 22

                                        g.DrawLine(linea, x, y, x + ancho, y)
                                        y += 8

                                        ' Número y fecha.
                                        y = DibujarFila(
                                            g, "Recibo N.º",
                                            Texto("numero_recibo"),
                                            fuenteNormal, fuenteNegrita,
                                            tinta, x, y, ancho, izquierda, derecha
                                        )

                                        y = DibujarFila(
                                            g, "Fecha",
                                            Fecha("fecha_pago", "dd/MM/yyyy HH:mm"),
                                            fuenteNormal, fuenteNormal,
                                            tinta, x, y, ancho, izquierda, derecha
                                        )

                                        y += 3
                                        g.DrawLine(linea, x, y, x + ancho, y)
                                        y += 8

                                        ' Socio.
                                        y = DibujarParrafo(
                                            g, "Socio: " & Texto("socio"),
                                            fuenteNormal, tinta, x, y, ancho
                                        )

                                        y = DibujarParrafo(
                                            g, "Cédula: " & Texto("cedula"),
                                            fuenteNormal, tinta, x, y, ancho
                                        )

                                        y += 3
                                        g.DrawLine(linea, x, y, x + ancho, y)
                                        y += 8

                                        ' Período del plan.
                                        Dim periodo As String =
                                            Texto("plan") & " " &
                                            Fecha("fecha_inicio", "dd/MM") & " – " &
                                            Fecha("fecha_vencimiento", "dd/MM/yyyy")

                                        y = DibujarParrafo(
                                            g, periodo,
                                            fuenteNormal, tinta, x, y, ancho
                                        )

                                        y += 4

                                        y = DibujarFila(
                                            g,
                                            "Abono (" & Texto("metodo_pago") & ")",
                                            Monto("monto"),
                                            fuenteNormal, fuenteNegrita,
                                            tinta, x, y, ancho, izquierda, derecha
                                        )

                                        Dim letras As String =
                                            NumeroALetras.ConvertirCordobas(
                                                Numero("monto")
                                            )

                                        y = DibujarParrafo(
                                            g, letras,
                                            fuentePequena, gris, x, y, ancho
                                        )

                                        y += 4

                                        y = DibujarFila(
                                            g,
                                            "Saldo pendiente",
                                            Monto("saldo_membresia"),
                                            fuenteNormal, fuenteNormal,
                                            tinta, x, y, ancho, izquierda, derecha
                                        )

                                        y += 3
                                        g.DrawLine(linea, x, y, x + ancho, y)
                                        y += 8

                                        ' Usuario y despedida.
                                        Dim atendio As String =
                                            "Atendió: " & Texto("registrado_por")

                                        g.DrawString(
                                            atendio,
                                            fuentePequena,
                                            gris,
                                            New RectangleF(x, y, ancho, 16),
                                            centrado
                                        )
                                        y += 16

                                        g.DrawString(
                                            "¡Gracias por entrenar con nosotros!",
                                            fuentePequena,
                                            gris,
                                            New RectangleF(x, y, ancho, 16),
                                            centrado
                                        )

                                        ' Marca de agua para reimpresión de anulados.
                                        If Entero("anulado") = 1 Then
                                            DibujarAnulado(g, limites)
                                        End If

                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using

        e.HasMorePages = False

    End Sub

    Private Shared Function DibujarFila(
        g As Graphics,
        etiqueta As String,
        valor As String,
        fuenteEtiqueta As Font,
        fuenteValor As Font,
        pincel As Brush,
        x As Single,
        y As Single,
        ancho As Single,
        izquierda As StringFormat,
        derecha As StringFormat
    ) As Single

        Dim alto As Single =
            Math.Max(
                g.MeasureString(etiqueta, fuenteEtiqueta).Height,
                g.MeasureString(valor, fuenteValor).Height
            )

        Dim mitad As Single = ancho * 0.45F

        g.DrawString(
            etiqueta,
            fuenteEtiqueta,
            pincel,
            New RectangleF(x, y, mitad, alto),
            izquierda
        )

        g.DrawString(
            valor,
            fuenteValor,
            pincel,
            New RectangleF(x + mitad, y, ancho - mitad, alto),
            derecha
        )

        Return y + alto

    End Function

    Private Shared Function DibujarParrafo(
        g As Graphics,
        texto As String,
        fuente As Font,
        pincel As Brush,
        x As Single,
        y As Single,
        ancho As Single
    ) As Single

        Dim alto As Single =
            g.MeasureString(texto, fuente, CInt(ancho)).Height

        g.DrawString(
            texto,
            fuente,
            pincel,
            New RectangleF(x, y, ancho, alto + 2)
        )

        Return y + alto

    End Function

    Private Shared Sub DibujarAnulado(g As Graphics, limites As Rectangle)

        Dim estado As GraphicsState = g.Save()

        Try

            Using fuente As New Font("Segoe UI", 38.0F, FontStyle.Bold)
                Using pincel As New SolidBrush(Color.FromArgb(95, 190, 0, 0))
                    g.TranslateTransform(
                        limites.Left + limites.Width / 2.0F,
                        limites.Top + limites.Height / 2.0F
                    )
                    g.RotateTransform(-32.0F)

                    Dim formato As New StringFormat()
                    formato.Alignment = StringAlignment.Center
                    formato.LineAlignment = StringAlignment.Center

                    g.DrawString(
                        "ANULADO",
                        fuente,
                        pincel,
                        New RectangleF(-160, -30, 320, 60),
                        formato
                    )
                End Using
            End Using

        Finally
            g.Restore(estado)
        End Try

    End Sub

    Private Function Texto(campo As String) As String

        If Not _recibo.Table.Columns.Contains(campo) Then Return ""
        If _recibo.IsNull(campo) Then Return ""
        Return Convert.ToString(_recibo(campo), CultureInfo.CurrentCulture)

    End Function

    Private Function Entero(campo As String) As Integer

        If Not _recibo.Table.Columns.Contains(campo) Then Return 0
        If _recibo.IsNull(campo) Then Return 0
        Return Convert.ToInt32(_recibo(campo), CultureInfo.InvariantCulture)

    End Function

    Private Function Numero(campo As String) As Decimal

        If Not _recibo.Table.Columns.Contains(campo) Then Return 0D
        If _recibo.IsNull(campo) Then Return 0D
        Return Convert.ToDecimal(_recibo(campo), CultureInfo.InvariantCulture)

    End Function

    Private Function Fecha(campo As String, formato As String) As String

        If Not _recibo.Table.Columns.Contains(campo) Then Return ""
        If _recibo.IsNull(campo) Then Return ""

        Return Convert.ToDateTime(
            _recibo(campo),
            CultureInfo.InvariantCulture
        ).ToString(formato, CultureInfo.CurrentCulture)

    End Function

    Private Function Monto(campo As String) As String

        Return "C$ " & Numero(campo).ToString("N2", CultureInfo.CurrentCulture)

    End Function

End Class
