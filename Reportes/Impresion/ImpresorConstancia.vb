Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Globalization

''' <summary>
''' R02 · Constancia de membresía vigente.
''' Documento carta vertical. Usa e.MarginBounds para que los
''' márgenes configurados con PageSetupDialog se respeten, ajusta
''' el párrafo con DrawString y dibuja el logo institucional.
''' </summary>
Public Class ImpresorConstancia

    Private ReadOnly _membresia As DataRow
    Private ReadOnly _fechaEmision As Date

    Public Sub New(membresia As DataRow, Optional fechaEmision As Date = Nothing)

        If membresia Is Nothing Then
            Throw New ArgumentNullException(NameOf(membresia))
        End If

        _membresia = membresia
        _fechaEmision = If(fechaEmision = Date.MinValue, DateTime.Today, fechaEmision)

    End Sub

    Public Sub PrepararDocumento(documento As PrintDocument)

        documento.DocumentName = "Constancia de membresía"
        documento.OriginAtMargins = False
        documento.DefaultPageSettings.Landscape = False

        ' Carta vertical; el usuario puede cambiarla con psdPagina.
        Dim carta As New PaperSize("Carta", 850, 1100)
        documento.DefaultPageSettings.PaperSize = carta
        documento.DefaultPageSettings.Margins =
            New Margins(100, 100, 100, 100)

    End Sub

    Public Sub Dibujar(e As PrintPageEventArgs)

        Dim limites As Rectangle = e.MarginBounds
        Dim g As Graphics = e.Graphics

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Dim x As Single = limites.Left
        Dim y As Single = limites.Top
        Dim ancho As Single = limites.Width

        Dim centrado As New StringFormat()
        centrado.Alignment = StringAlignment.Center
        centrado.LineAlignment = StringAlignment.Near

        Dim izquierda As New StringFormat()
        izquierda.Alignment = StringAlignment.Near
        izquierda.LineAlignment = StringAlignment.Near

        Dim derecha As New StringFormat()
        derecha.Alignment = StringAlignment.Far
        derecha.LineAlignment = StringAlignment.Near

        Using tinta As New SolidBrush(Color.Black)
            Using gris As New SolidBrush(Color.DimGray)
                Using azul As New SolidBrush(Color.FromArgb(25, 61, 136))
                    Using linea As New Pen(Color.FromArgb(25, 61, 136), 1.2F)
                        Using fuenteTitulo As New Font("Segoe UI", 20.0F, FontStyle.Bold)
                            Using fuenteSubtitulo As New Font("Segoe UI", 10.0F, FontStyle.Bold)
                                Using fuenteNormal As New Font("Segoe UI", 10.5F, FontStyle.Regular)
                                    Using fuenteNegrita As New Font("Segoe UI", 10.0F, FontStyle.Bold)
                                        Using fuentePequena As New Font("Segoe UI", 8.5F, FontStyle.Regular)

                                            ' Logo institucional azul, centrado y proporcional.
                                            Dim logo As Image = RecursosReportes.ObtenerLogoAzul()

                                            If logo IsNot Nothing Then

                                                Using logo
                                                    Dim anchoLogo As Single = 130
                                                    Dim altoLogo As Single =
                                                        anchoLogo * logo.Height / logo.Width

                                                    g.DrawImage(
                                                        logo,
                                                        New RectangleF(
                                                            x + (ancho - anchoLogo) / 2.0F,
                                                            y,
                                                            anchoLogo,
                                                            altoLogo
                                                        )
                                                    )

                                                    y += altoLogo + 12
                                                End Using

                                            End If

                                            g.DrawString(
                                                "CONSTANCIA",
                                                fuenteTitulo,
                                                azul,
                                                New RectangleF(x, y, ancho, 36),
                                                centrado
                                            )
                                            y += 34

                                            g.DrawString(
                                                "DE MEMBRESÍA VIGENTE",
                                                fuenteSubtitulo,
                                                gris,
                                                New RectangleF(x, y, ancho, 22),
                                                centrado
                                            )
                                            y += 26

                                            g.DrawLine(linea, x, y, x + ancho, y)
                                            y += 18

                                            Dim parrafo As String =
                                                "El Gimnasio Titán hace constar que el/la socio(a) " &
                                                Texto("socio") &
                                                ", con cédula de identidad " &
                                                Texto("cedula") &
                                                ", se encuentra registrado(a) en nuestra base de datos " &
                                                "y mantiene vigente la membresía que se detalla a continuación."

                                            y = DibujarParrafo(
                                                g, parrafo, fuenteNormal, tinta,
                                                x, y, ancho
                                            )

                                            y += 14

                                            ' Tabla de datos de la membresía.
                                            Dim altoFila As Single = 28
                                            Dim anchoEtiqueta As Single = ancho * 0.38F

                                            y = DibujarFilaTabla(
                                                g, "Plan contratado", Texto("plan"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y = DibujarFilaTabla(
                                                g, "Fecha de inicio", Fecha("fecha_inicio"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y = DibujarFilaTabla(
                                                g, "Fecha de vencimiento", Fecha("fecha_vencimiento"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y = DibujarFilaTabla(
                                                g, "Estado", Texto("estado"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y = DibujarFilaTabla(
                                                g, "Precio pactado", Monto("precio_pactado"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y = DibujarFilaTabla(
                                                g, "Pagado", Monto("pagado"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y = DibujarFilaTabla(
                                                g, "Saldo pendiente", Monto("saldo"),
                                                fuenteNormal, fuenteNegrita,
                                                x, y, ancho, anchoEtiqueta,
                                                altoFila, tinta, linea
                                            )

                                            y += 24

                                            Dim cierre As String =
                                                "La presente constancia se emite a solicitud del interesado(a) " &
                                                "para los fines que estime convenientes."

                                            y = DibujarParrafo(
                                                g, cierre, fuenteNormal, tinta,
                                                x, y, ancho
                                            )

                                            y += 10

                                            Dim fechaTexto As String =
                                                "Dado en Managua, " &
                                                FechaEnLetras.Completar(_fechaEmision) & "."

                                            y = DibujarParrafo(
                                                g, fechaTexto, fuenteNormal, tinta,
                                                x, y, ancho
                                            )

                                            y += 70

                                            ' Firmas y sello.
                                            Dim anchoFirma As Single = ancho * 0.42F
                                            Dim centro As Single = x + ancho / 2.0F
                                            Dim izquierdaFirma As Single = centro - anchoFirma - 25
                                            Dim derechaFirma As Single = centro + 25

                                            g.DrawLine(
                                                linea,
                                                izquierdaFirma, y,
                                                izquierdaFirma + anchoFirma, y
                                            )
                                            g.DrawLine(
                                                linea,
                                                derechaFirma, y,
                                                derechaFirma + anchoFirma, y
                                            )

                                            g.DrawString(
                                                "Firma autorizada",
                                                fuentePequena,
                                                gris,
                                                New RectangleF(
                                                    izquierdaFirma, y + 4,
                                                    anchoFirma, 18
                                                ),
                                                centrado
                                            )

                                            g.DrawString(
                                                "Sello del gimnasio",
                                                fuentePequena,
                                                gris,
                                                New RectangleF(
                                                    derechaFirma, y + 4,
                                                    anchoFirma, 18
                                                ),
                                                centrado
                                            )

                                            g.DrawString(
                                                "Gimnasio Titán · Managua, Nicaragua",
                                                fuentePequena,
                                                gris,
                                                New RectangleF(
                                                    x, limites.Bottom - 18,
                                                    ancho, 16
                                                ),
                                                centrado
                                            )

                                        End Using
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
            New RectangleF(x, y, ancho, alto + 4)
        )

        Return y + alto

    End Function

    Private Shared Function DibujarFilaTabla(
        g As Graphics,
        etiqueta As String,
        valor As String,
        fuenteEtiqueta As Font,
        fuenteValor As Font,
        x As Single,
        y As Single,
        ancho As Single,
        anchoEtiqueta As Single,
        alto As Single,
        pincel As Brush,
        linea As Pen
    ) As Single

        Dim fondo As New SolidBrush(Color.FromArgb(242, 244, 248))

        Try
            g.FillRectangle(fondo, x, y, anchoEtiqueta, alto)
        Finally
            fondo.Dispose()
        End Try

        Dim izquierda As New StringFormat()
        izquierda.Alignment = StringAlignment.Near
        izquierda.LineAlignment = StringAlignment.Center

        Dim derecha As New StringFormat()
        derecha.Alignment = StringAlignment.Near
        derecha.LineAlignment = StringAlignment.Center

        g.DrawString(
            etiqueta,
            fuenteEtiqueta,
            pincel,
            New RectangleF(x + 6, y, anchoEtiqueta - 12, alto),
            izquierda
        )

        g.DrawString(
            valor,
            fuenteValor,
            pincel,
            New RectangleF(x + anchoEtiqueta + 8, y, ancho - anchoEtiqueta - 12, alto),
            derecha
        )

        g.DrawRectangle(linea, x, y, ancho, alto)

        Return y + alto

    End Function

    Private Function Texto(campo As String) As String

        If Not _membresia.Table.Columns.Contains(campo) Then Return ""
        If _membresia.IsNull(campo) Then Return ""
        Return Convert.ToString(_membresia(campo), CultureInfo.CurrentCulture)

    End Function

    Private Function Numero(campo As String) As Decimal

        If Not _membresia.Table.Columns.Contains(campo) Then Return 0D
        If _membresia.IsNull(campo) Then Return 0D
        Return Convert.ToDecimal(_membresia(campo), CultureInfo.InvariantCulture)

    End Function

    Private Function Fecha(campo As String) As String

        If Not _membresia.Table.Columns.Contains(campo) Then Return ""
        If _membresia.IsNull(campo) Then Return ""

        Return Convert.ToDateTime(
            _membresia(campo),
            CultureInfo.InvariantCulture
        ).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)

    End Function

    Private Function Monto(campo As String) As String

        Return "C$ " & Numero(campo).ToString("N2", CultureInfo.CurrentCulture)

    End Function

End Class
