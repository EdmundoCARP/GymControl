Imports System.IO
Imports System.Text.Json

''' <summary>
''' Lectura de secretos locales guardados con "dotnet user-secrets".
''' Viven en %APPDATA%\Microsoft\UserSecrets\&lt;UserSecretsId&gt;\secrets.json,
''' fuera del repositorio, así que nunca se versionan junto al código.
''' </summary>
Public Module SecretosLocales

    ' Debe coincidir con <UserSecretsId> de GymControl.vbproj
    Private Const IdSecretos As String = "GymControl-3de0a0e2-e7ac-43f5-8974-3f2a05fedf12"

    ''' <summary>
    ''' Devuelve el valor de un secreto o Nothing si no existe.
    ''' Ejemplo: ObtenerSecreto("OpenRouter:ApiKey")
    ''' </summary>
    Public Function ObtenerSecreto(nombre As String) As String

        Dim ruta As String = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Microsoft",
            "UserSecrets",
            IdSecretos,
            "secrets.json")

        If Not File.Exists(ruta) Then Return Nothing

        Using flujo As FileStream = File.OpenRead(ruta)
            Using documento As JsonDocument = JsonDocument.Parse(flujo)

                Dim valor As JsonElement
                If documento.RootElement.TryGetProperty(nombre, valor) Then
                    Return valor.GetString()
                End If

            End Using
        End Using

        Return Nothing

    End Function

End Module
