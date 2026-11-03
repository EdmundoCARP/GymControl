Imports System.Drawing
Imports System.IO
Imports System.Reflection

''' <summary>
''' Acceso a los recursos incrustados del modulo de reportes:
''' logos UNI y plantillas .rdlc. Los nombres logicos se fijan
''' en GymControl.vbproj para que no dependan de la ruta fisica.
''' </summary>
Public Module RecursosReportes

    Public Const LogoAzul As String = "GymControl.Recursos.logo_uni_azul.png"
    Public Const LogoBlanco As String = "GymControl.Recursos.logo_uni_blanco.png"

    Public Const RdlcR04 As String = "GymControl.Reportes.Rdlc.R04_Ingresos.rdlc"
    Public Const RdlcR05 As String = "GymControl.Reportes.Rdlc.R05_EstadoCuenta.rdlc"
    Public Const RdlcR06 As String = "GymControl.Reportes.Rdlc.R06_Horario.rdlc"

    Public Function ObtenerLogoAzul() As Image

        Return CargarImagen(LogoAzul)

    End Function

    Public Function ObtenerLogoBlanco() As Image

        Return CargarImagen(LogoBlanco)

    End Function

    Public Function CargarImagen(nombreRecurso As String) As Image

        Dim flujo As Stream = AbrirRecurso(nombreRecurso)

        If flujo Is Nothing Then Return Nothing

        ' Se copia el flujo para que la imagen no dependa de el.
        Using flujo
            Using copia As New MemoryStream()
                flujo.CopyTo(copia)
                copia.Position = 0

                Using imagen As Image = Image.FromStream(copia)
                    Return New Bitmap(imagen)
                End Using
            End Using
        End Using

    End Function

    Public Function AbrirRecurso(nombreRecurso As String) As Stream

        Dim ensamblado As Assembly = GetType(RecursosReportes).Assembly

        Dim flujo As Stream =
            ensamblado.GetManifestResourceStream(nombreRecurso)

        If flujo IsNot Nothing Then Return flujo

        ' Tolerancia por si el nombre cambia al compilar con otro
        ' espacio de nombres raiz.
        For Each nombre As String In ensamblado.GetManifestResourceNames()

            If nombre.EndsWith(
                nombreRecurso,
                StringComparison.OrdinalIgnoreCase) Then

                Return ensamblado.GetManifestResourceStream(nombre)

            End If

        Next

        Return Nothing

    End Function

End Module
