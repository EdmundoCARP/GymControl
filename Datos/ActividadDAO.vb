Imports MySqlConnector
Imports System.Data

Public Class ActividadDAO

    Public Shared Function ObtenerTodos() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_actividad,
                    nombre,
                    descripcion,
                    duracion_min,
                    cupo_maximo,
                    activo
             FROM actividades
             ORDER BY nombre"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)
                Using adaptador As New MySqlDataAdapter(comando)
                    adaptador.Fill(tabla)
                End Using
            End Using
        End Using

        Return tabla

    End Function

    Public Shared Sub Crear(
        nombre As String,
        descripcion As String,
        duracion As Integer,
        cupo As Integer
    )

        Dim sql As String =
            "INSERT INTO actividades
            (nombre, descripcion, duracion_min, cupo_maximo, activo)
            VALUES
            (@nombre, @descripcion, @duracion, @cupo, 1)"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@descripcion", descripcion)
                comando.Parameters.AddWithValue("@duracion", duracion)
                comando.Parameters.AddWithValue("@cupo", cupo)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

    Public Shared Sub Actualizar(
        id As Integer,
        nombre As String,
        descripcion As String,
        duracion As Integer,
        cupo As Integer,
        activo As Boolean
    )

        Dim sql As String =
            "UPDATE actividades
             SET nombre = @nombre,
                 descripcion = @descripcion,
                 duracion_min = @duracion,
                 cupo_maximo = @cupo,
                 activo = @activo
             WHERE id_actividad = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", id)
                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@descripcion", descripcion)
                comando.Parameters.AddWithValue("@duracion", duracion)
                comando.Parameters.AddWithValue("@cupo", cupo)
                comando.Parameters.AddWithValue("@activo", activo)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

End Class
