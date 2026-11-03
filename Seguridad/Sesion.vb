''' <summary>
''' Reportes del modulo R01-R09. Los codigos coinciden con el
''' catalogo de la propuesta y se usan en nombres de archivo,
''' ramas de GitHub y en el Tag de los nodos del Centro de reportes.
''' </summary>
Public Enum TipoReporte
    R01
    R02
    R03
    R04
    R05
    R06
    R07
    R08
    R09
End Enum

''' <summary>
''' Datos de la sesion activa y control de acceso por rol.
''' Toda la matriz de permisos del modulo de reportes vive aqui,
''' de modo que los formularios no la dupliquen.
''' </summary>
Public Module Sesion

    ' Nombres exactos de la tabla roles.
    Public Const RolAdministrador As String = "Administrador"
    Public Const RolRecepcionista As String = "Recepcionista"
    Public Const RolInstructor As String = "Instructor"
    Public Const RolSocio As String = "Socio"

    Public Property IdUsuario As Integer
    Public Property NombreUsuario As String
    Public Property Rol As String
    Public Property IdSocio As Integer?
    Public Property IdInstructor As Integer?

    Public Sub CerrarSesion()

        IdUsuario = 0
        NombreUsuario = Nothing
        Rol = Nothing
        IdSocio = Nothing
        IdInstructor = Nothing

    End Sub

    Public Function EstaLogueado() As Boolean

        Return IdUsuario > 0 AndAlso Not String.IsNullOrWhiteSpace(Rol)

    End Function

    Public Function EsAdministrador() As Boolean

        Return Rol = RolAdministrador

    End Function

    Public Function TieneRol(ParamArray roles() As String) As Boolean

        If String.IsNullOrWhiteSpace(Rol) Then Return False

        For Each nombreRol As String In roles
            If String.Equals(Rol, nombreRol, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next

        Return False

    End Function

    ' =====================================================
    ' MATRIZ DE PERMISOS DEL MODULO DE REPORTES
    ' -----------------------------------------------------
    ' Administrador : R01 a R09
    ' Recepcionista : R01, R02, R03, R05, R06
    ' Instructor    : R06 (solo su horario)
    ' Socio         : R05 (solo su estado de cuenta) y R06
    ' =====================================================

    ''' <summary>
    ''' Indica si el rol puede entrar al Centro de reportes de
    ''' frmPrincipal. El socio entra por su portal.
    ''' </summary>
    Public Function TieneAccesoModuloReportes() As Boolean

        Return TieneRol(RolAdministrador, RolRecepcionista, RolInstructor)

    End Function

    Public Function PuedeVerReporte(reporte As TipoReporte) As Boolean

        Select Case Rol

            Case RolAdministrador
                Return True

            Case RolRecepcionista
                Return reporte = TipoReporte.R01 OrElse
                       reporte = TipoReporte.R02 OrElse
                       reporte = TipoReporte.R03 OrElse
                       reporte = TipoReporte.R05 OrElse
                       reporte = TipoReporte.R06

            Case RolInstructor
                Return reporte = TipoReporte.R06

            Case RolSocio
                Return reporte = TipoReporte.R05 OrElse
                       reporte = TipoReporte.R06

            Case Else
                Return False

        End Select

    End Function

    ''' <summary>
    ''' Exportar (PDF/Excel) sigue la misma matriz que consultar.
    ''' Los reportes R01-R03 son impresion directa y no generan
    ''' archivos desde el Centro; su impresion se valida con
    ''' PuedeVerReporte.
    ''' </summary>
    Public Function PuedeExportarReporte(reporte As TipoReporte) As Boolean

        Return PuedeVerReporte(reporte)

    End Function

    ''' <summary>
    ''' Aplica los filtros obligatorios del rol sobre los parametros
    ''' del reporte. El socio nunca puede consultar otro socio y el
    ''' instructor nunca puede consultar el horario de otro.
    ''' </summary>
    Public Sub AplicarRestricciones(filtro As FiltroReporte)

        If filtro Is Nothing Then Return

        Select Case Rol

            Case RolSocio
                filtro.IdSocio = IdSocio

            Case RolInstructor
                filtro.IdInstructor = IdInstructor

        End Select

    End Sub

    ''' <summary>
    ''' Comprueba que el socio consultado sea el de la sesion.
    ''' </summary>
    Public Function ValidarSocioPermitido(idSocio As Integer?) As Boolean

        If Rol <> RolSocio Then Return True
        If Not IdSocio.HasValue Then Return False

        Return idSocio.HasValue AndAlso idSocio.Value = IdSocio.Value

    End Function

    ''' <summary>
    ''' Comprueba que el instructor consultado sea el de la sesion.
    ''' </summary>
    Public Function ValidarInstructorPermitido(idInstructor As Integer?) As Boolean

        If Rol <> RolInstructor Then Return True
        If Not IdInstructor.HasValue Then Return False

        Return idInstructor.HasValue AndAlso
               idInstructor.Value = IdInstructor.Value

    End Function

    ''' <summary>
    ''' Valida el acceso y, si no hay permiso, muestra el mensaje
    ''' estandar del sistema. Devuelve True cuando puede continuar.
    ''' </summary>
    Public Function ValidarAccesoReporte(
        reporte As TipoReporte,
        Optional mostrarMensaje As Boolean = True
    ) As Boolean

        If PuedeVerReporte(reporte) Then Return True

        If mostrarMensaje Then

            MessageBox.Show(
                "No tiene permisos para acceder a: " &
                ReporteUtilidades.NombreReporte(reporte) & ".",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        End If

        Return False

    End Function

End Module
