Public Module Sesion

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

End Module
