Imports MySqlConnector

Public Class ConexionBD

    Private Shared ReadOnly cadenaConexion As String =
        "Server=localhost;Port=3306;Database=gimnasio_db;User ID=gym_app;Password=Gym#2026app;"

    Public Shared Function ObtenerConexion() As MySqlConnection
        Return New MySqlConnection(cadenaConexion)
    End Function

    Public Shared Function ProbarConexion() As Boolean
        Try
            Using conexion As MySqlConnection = ObtenerConexion()
                conexion.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

End Class