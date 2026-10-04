Public Class Usuario

    Public Property IdUsuario As Integer
    Public Property NombreUsuario As String
    Public Property ContrasenaHash As String
    Public Property Sal As String
    Public Property IdRol As Integer
    Public Property Rol As String
    Public Property IdSocio As Integer?
    Public Property IdInstructor As Integer?
    Public Property IntentosFallidos As Integer
    Public Property Activo As Boolean
    Public Property UltimoAcceso As DateTime?

End Class