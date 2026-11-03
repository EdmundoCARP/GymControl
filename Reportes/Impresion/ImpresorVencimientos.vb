Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Globalization

''' <summary>
''' R03 · Listado de vencimientos.
''' Pagina con HasMorePages, encabezado repetido, filas alternas,
''' columnas Llamada y Saldo, y pie con número de página. El
''' índice de la fila vive en el objeto (no en PrintPage) y se
''' reinicia en BeginPrint para que la vista previa y la
''' impresión recorran el documento desde el principio.
''' </summary>
Public Class ImpresorVencimientos

    Private ReadOnly _tabla As DataTable
    Private _filaActual As Integer
    Private _pagina As Integer

    Public Property DiasAdelante As Integer = 7
    Public Property DiasAtras As Integer = 15
    Public Property FechaImpresion As Date = DateTime.Now

    Public Sub New(tabla As DataTable)

        If tabla Is Nothing Then
            Throw New ArgumentNullException(NameOf(tabla))
        End If

        _tabla = tabla

    End Sub

    Public Sub PrepararDocumento(documento As PrintDocument)

        documento.DocumentName = "Vencimientos"
        documento.OriginAtMargins = False
        documento.DefaultPageSettings.Margins =
            New Margins(50, 50, 50, 50)

    End Sub

    ''' <summary>
    ''' Se enlaza al evento BeginPrint. Reinicia la paginación.
    ''' </summary>
    Public Sub Iniciar()

        _filaActual = 0
        _pagina = 0

    End Sub

    Public Sub ImprimirPagina(e As PrintPageEventArgs)

        _pagina += 1

        Dim limites As Rectangle = e.MarginBounds
        Dim g As Graphics = e.Graphics

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Dim azul As Color = Color.FromArgb(25, 61, 136)
        Dim grisFila As Color = Color.FromArgb(242, 244, 248)
        Dim lineaColor As Color = Color.FromArgb(215, 220, 230)
        Dim rojo As Color = Color.FromArgb(180, 35, 24)

        Using tinta As New SolidBrush(Color.Black)
            Using gris As New SolidBrush(Color.DimGray)
                Using blanco As New SolidBrush(Color.White)
                    Using azulPincel As New SolidBrush(azul)
                        Using fondoAlterno As New SolidBrush(grisFila)
                            Using linea As New Pen(lineaColor, 1.0F)
                                Using lineaAzul As New Pen(azul, 1.4F)
                                    Using fuenteTitulo As New Font("Segoe UI", 15.0F, FontStyle.Bold)
                                        Using fuenteSubtitulo As New Font("Segoe UI", 8.5F, FontStyle.Regular)
                                            Using fuenteCabecera As New Font("Segoe UI", 8.0F, FontStyle.Bold)
                                                Using fuenteFila As New Font("Segoe UI", 8.5F, FontStyle.Regular)
                                                    Using fuenteNegrita As New Font("Segoe UI", 8.5F, FontStyle.Bold)
                                                        Using fuentePie As New Font("Segoe UI", 8.0F, FontStyle.Regular)

                                                            Dim x As Single = limites.Left
                                                            Dim y As Single = limites.Top
                                                            Dim ancho As Single = limites.Width

                                                            ' Encabezado.
                                                            g.DrawString(
                                                                "LISTADO DE VENCIMIENTOS",
                                                                fuenteTitulo,
                                                                azulPincel,
                                                                New RectangleF(x, y, ancho, 30)
                                                            )

                                                            y += 26

                                                            g.DrawString(
                                                                "Vencen en los próximos " &
                                                                DiasAdelante.ToString() &
                                                                " días · vencidas hace hasta " &
                                                                DiasAtras.ToString() &
                                                                " días · Impreso: " &
                                                                FechaImpresion.ToString("dd/MM/yyyy HH:mm"),
                                                                fuenteSubtitulo,
                                                                gris,
                                                                New RectangleF(x, y, ancho, 18)
                                                            )

                                                            y += 22

                                                            g.DrawLine(lineaAzul, x, y, x + ancho, y)
                                                            y += 8

                                                            ' Distribución de columnas.
                                                            Dim columnas As Single() = {
                                                                ancho * 0.05F,
                                                                ancho * 0.29F,
                                                                ancho * 0.14F,
                                                                ancho * 0.13F,
                                                                ancho * 0.12F,
                                                                ancho * 0.07F,
                                                                ancho * 0.11F,
                                                                ancho * 0.09F
                                                            }

                                                            Dim encabezados As String() = {
                                                                "N.º", "Socio", "Teléfono", "Plan",
                                                                "Vence", "Días", "Saldo C$", "Llamada"
                                                            }

                                                            Dim altoCabecera As Single = 26
                                                            Dim altoFila As Single = 25

                                                            ' Fondo del encabezado.
                                                            g.FillRectangle(azulPincel, x, y, ancho, altoCabecera)
                                                            g.DrawRectangle(lineaAzul, x, y, ancho, altoCabecera)

                                                            Dim posX As Single = x

                                                            For i As Integer = 0 To columnas.Length - 1

                                                                Dim formato As New StringFormat()
                                                                formato.Alignment =
                                                                    If(i = 0 OrElse i = 7,
                                                                       StringAlignment.Center,
                                                                       StringAlignment.Near)
                                                                formato.LineAlignment = StringAlignment.Center
                                                                formato.Trimming = StringTrimming.EllipsisCharacter

                                                                g.DrawString(
                                                                    encabezados(i),
                                                                    fuenteCabecera,
                                                                    blanco,
                                                                    New RectangleF(
                                                                        posX + 3, y,
                                                                        columnas(i) - 6, altoCabecera
                                                                    ),
                                                                    formato
                                                                )

                                                                posX += columnas(i)

                                                            Next

                                                            y += altoCabecera

                                                            ' Filas.
                                                            Dim filasDisponibles As Integer =
                                                                CInt(
                                                                    Math.Floor(
                                                                        (limites.Bottom - y - 30) / altoFila
                                                                    )
                                                                )

                                                            If filasDisponibles < 1 Then filasDisponibles = 1

                                                            Dim filasDibujadas As Integer = 0

                                                            While _filaActual < _tabla.Rows.Count AndAlso
                                                                  filasDibujadas < filasDisponibles

                                                                Dim fila As DataRow = _tabla.Rows(_filaActual)

                                                                If filasDibujadas Mod 2 = 1 Then
                                                                    g.FillRectangle(
                                                                        fondoAlterno,
                                                                        x, y, ancho, altoFila
                                                                    )
                                                                End If

                                                                g.DrawLine(
                                                                    linea,
                                                                    x, y + altoFila,
                                                                    x + ancho, y + altoFila
                                                                )

                                                                Dim valores As String() = {
                                                                    (_filaActual + 1).ToString(),
                                                                    Texto(fila, "socio"),
                                                                    Texto(fila, "telefono"),
                                                                    Texto(fila, "plan"),
                                                                    Fecha(fila, "fecha_vencimiento"),
                                                                    Entero(fila, "dias").ToString(),
                                                                    Monto(fila, "saldo"),
                                                                    ""
                                                                }

                                                                posX = x

                                                                For i As Integer = 0 To columnas.Length - 1

                                                                    Dim formato As New StringFormat()
                                                                    formato.Alignment =
                                                                        If(i = 0 OrElse i = 7,
                                                                           StringAlignment.Center,
                                                                           StringAlignment.Near)
                                                                    formato.LineAlignment = StringAlignment.Center
                                                                    formato.Trimming = StringTrimming.EllipsisCharacter

                                                                    Dim pincel As Brush = tinta

                                                                    If i = 5 AndAlso Entero(fila, "dias") < 0 Then
                                                                        pincel = New SolidBrush(rojo)
                                                                    End If

                                                                    g.DrawString(
                                                                        valores(i),
                                                                        If(i = 5, fuenteNegrita, fuenteFila),
                                                                        pincel,
                                                                        New RectangleF(
                                                                            posX + 3, y,
                                                                            columnas(i) - 6, altoFila
                                                                        ),
                                                                        formato
                                                                    )

                                                                    If ReferenceEquals(pincel, tinta) = False Then
                                                                        pincel.Dispose()
                                                                    End If

                                                                    posX += columnas(i)

                                                                Next

                                                                ' Línea vertical de la columna Llamada.
                                                                g.DrawLine(
                                                                    linea,
                                                                    x + ancho - columnas(7), y,
                                                                    x + ancho - columnas(7), y + altoFila
                                                                )

                                                                y += altoFila
                                                                filasDibujadas += 1
                                                                _filaActual += 1

                                                            End While

                                                            ' Pie.
                                                            Dim textoPagina As String =
                                                                "Página " & _pagina.ToString()

                                                            g.DrawString(
                                                                textoPagina,
                                                                fuentePie,
                                                                gris,
                                                                New RectangleF(
                                                                    x, limites.Bottom - 18,
                                                                    ancho / 2.0F, 16
                                                                )
                                                            )

                                                            g.DrawString(
                                                                "Gimnasio Titán · " &
                                                                FechaImpresion.ToString("dd/MM/yyyy HH:mm"),
                                                                fuentePie,
                                                                gris,
                                                                New RectangleF(
                                                                    x + ancho / 2.0F,
                                                                    limites.Bottom - 18,
                                                                    ancho / 2.0F, 16
                                                                ),
                                                                New StringFormat() With {
                                                                    .Alignment = StringAlignment.Far
                                                                }
                                                            )

                                                            If _tabla.Rows.Count = 0 Then

                                                                g.DrawString(
                                                                    "No hay membresías en el rango seleccionado.",
                                                                    fuenteFila,
                                                                    gris,
                                                                    New RectangleF(
                                                                        x, y + 10,
                                                                        ancho, 20
                                                                    ),
                                                                    New StringFormat() With {
                                                                        .Alignment = StringAlignment.Center
                                                                    }
                                                                )

                                                            End If

                                                            e.HasMorePages = _filaActual < _tabla.Rows.Count

                                                        End Using
                                                    End Using
                                                End Using
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using

    End Sub

    Private Shared Function Texto(fila As DataRow, campo As String) As String

        If Not fila.Table.Columns.Contains(campo) Then Return ""
        If fila.IsNull(campo) Then Return ""
        Return Convert.ToString(fila(campo), CultureInfo.CurrentCulture)

    End Function

    Private Shared Function Entero(fila As DataRow, campo As String) As Integer

        If Not fila.Table.Columns.Contains(campo) Then Return 0
        If fila.IsNull(campo) Then Return 0
        Return Convert.ToInt32(fila(campo), CultureInfo.InvariantCulture)

    End Function

    Private Shared Function Fecha(fila As DataRow, campo As String) As String

        If Not fila.Table.Columns.Contains(campo) Then Return ""
        If fila.IsNull(campo) Then Return ""

        Return Convert.ToDateTime(
            fila(campo),
            CultureInfo.InvariantCulture
        ).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture)

    End Function

    Private Shared Function Monto(fila As DataRow, campo As String) As String

        If Not fila.Table.Columns.Contains(campo) Then Return "0.00"
        If fila.IsNull(campo) Then Return "0.00"

        Return Convert.ToDecimal(
            fila(campo),
            CultureInfo.InvariantCulture
        ).ToString("N2", CultureInfo.CurrentCulture)

    End Function

End Class
