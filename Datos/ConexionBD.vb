Imports MySqlConnector

Public Class ConexionBD

    Private Shared ReadOnly cadenaConexion As String =
        "Server=localhost;Port=3306;Database=gimnasio_db;User ID=gym_app;Password=Gym#2026app;"

    ' Usuario de solo lectura para el modulo de reportes
    ' (ver Database\reportes_vistas.sql). La clave se guarda
    ' fuera del repositorio con dotnet user-secrets.
    Public Shared Function ObtenerConexion() As MySqlConnection
        Return New MySqlConnection(cadenaConexion)
    End Function

    Public Shared Function ObtenerConexionReportes() As MySqlConnection
        Return New MySqlConnection(CrearCadenaReportes())
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

    Private Shared Function CrearCadenaReportes() As String

        Dim constructor As New MySqlConnectionStringBuilder()

        constructor.Server = "localhost"
        constructor.Port = 3306
        constructor.Database = "gimnasio_db"
        constructor.UserID = "gym_reportes"
        constructor.Password = ObtenerClaveReportes()

        Return constructor.ConnectionString

    End Function

    Private Shared Function ObtenerClaveReportes() As String

        Dim clave As String =
            SecretosLocales.ObtenerSecreto("Reportes:ClaveBD")

        If String.IsNullOrWhiteSpace(clave) Then
            clave = Environment.GetEnvironmentVariable("GYM_REPORTES_CLAVE")
        End If

        If String.IsNullOrWhiteSpace(clave) Then

            Throw New InvalidOperationException(
                "No se encontro la clave del usuario de reportes." &
                Environment.NewLine &
                "Ejecute en la carpeta del proyecto:" &
                Environment.NewLine &
                "dotnet user-secrets set ""Reportes:ClaveBD"" ""<clave>"""
            )

        End If

        Return clave

    End Function

End Class
