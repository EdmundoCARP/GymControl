Imports MySqlConnector
Imports System.Data

Public Class TipoMembresiaDAO

    Public Shared Function ObtenerTodos() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_tipo,
                    nombre,
                    descripcion,
                    duracion_dias,
                    precio,
                    incluye_clases,
                    activo
             FROM tipos_membresia
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
        precio As Decimal,
        incluyeClases As Boolean
    )

        Dim sql As String =
            "INSERT INTO tipos_membresia
            (nombre, descripcion, duracion_dias, precio, incluye_clases, activo)
            VALUES
            (@nombre, @descripcion, @duracion, @precio, @clases, 1)"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@descripcion", descripcion)
                comando.Parameters.AddWithValue("@duracion", duracion)
                comando.Parameters.AddWithValue("@precio", precio)
                comando.Parameters.AddWithValue("@clases", incluyeClases)

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
        precio As Decimal,
        incluyeClases As Boolean,
        activo As Boolean
    )

        Dim sql As String =
            "UPDATE tipos_membresia
             SET nombre = @nombre,
                 descripcion = @descripcion,
                 duracion_dias = @duracion,
                 precio = @precio,
                 incluye_clases = @clases,
                 activo = @activo
             WHERE id_tipo = @id"

        Using conexion As MySqlConnection = ConexionBD.ObtenerConexion()
            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@id", id)
                comando.Parameters.AddWithValue("@nombre", nombre)
                comando.Parameters.AddWithValue("@descripcion", descripcion)
                comando.Parameters.AddWithValue("@duracion", duracion)
                comando.Parameters.AddWithValue("@precio", precio)
                comando.Parameters.AddWithValue("@clases", incluyeClases)
                comando.Parameters.AddWithValue("@activo", activo)

                conexion.Open()
                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

End Class
