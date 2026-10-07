Imports MySqlConnector
Imports System.Data

Public Class HorarioDAO

    Public Shared Function ObtenerTodos() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT
                h.id_horario,
                h.id_instructor,
                CONCAT(i.nombres, ' ', i.apellidos) AS instructor,
                h.id_actividad,
                a.nombre AS actividad,
                h.id_sala,
                s.nombre AS sala,
                h.dia_semana,
                CASE h.dia_semana
                    WHEN 1 THEN 'Lunes'
                    WHEN 2 THEN 'Martes'
                    WHEN 3 THEN 'Miércoles'
                    WHEN 4 THEN 'Jueves'
                    WHEN 5 THEN 'Viernes'
                    WHEN 6 THEN 'Sábado'
                    WHEN 7 THEN 'Domingo'
                END AS dia,
                h.hora_inicio,
                h.hora_fin,
                h.activo
             FROM horarios h
             INNER JOIN instructores i
                ON i.id_instructor = h.id_instructor
             INNER JOIN actividades a
                ON a.id_actividad = h.id_actividad
             INNER JOIN salas s
                ON s.id_sala = h.id_sala
             ORDER BY h.dia_semana,
                      h.hora_inicio"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                Using adaptador As New MySqlDataAdapter(comando)

                    adaptador.Fill(tabla)

                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Shared Function ObtenerInstructores() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_instructor,
                    CONCAT(nombres, ' ', apellidos) AS nombre
             FROM instructores
             WHERE activo = 1
             ORDER BY apellidos, nombres"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                Using adaptador As New MySqlDataAdapter(comando)

                    adaptador.Fill(tabla)

                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Shared Function ObtenerActividades() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_actividad,
                    nombre
             FROM actividades
             WHERE activo = 1
             ORDER BY nombre"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                Using adaptador As New MySqlDataAdapter(comando)

                    adaptador.Fill(tabla)

                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Shared Function ObtenerSalas() As DataTable

        Dim tabla As New DataTable()

        Dim sql As String =
            "SELECT id_sala,
                    nombre
             FROM salas
             WHERE activo = 1
             ORDER BY nombre"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                Using adaptador As New MySqlDataAdapter(comando)

                    adaptador.Fill(tabla)

                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Shared Function ExisteChoque(
        idInstructor As Integer,
        idSala As Integer,
        dia As Integer,
        horaInicio As TimeSpan,
        horaFin As TimeSpan,
        idHorarioExcluir As Integer
    ) As Boolean

        Dim sql As String =
            "SELECT COUNT(*)
             FROM horarios
             WHERE dia_semana = @dia
               AND activo = 1
               AND id_horario <> @id
               AND
               (
                    id_instructor = @instructor
                    OR id_sala = @sala
               )
               AND
               (
                    @inicio < hora_fin
                    AND @fin > hora_inicio
               )"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue(
                    "@dia",
                    dia
                )

                comando.Parameters.AddWithValue(
                    "@id",
                    idHorarioExcluir
                )

                comando.Parameters.AddWithValue(
                    "@instructor",
                    idInstructor
                )

                comando.Parameters.AddWithValue(
                    "@sala",
                    idSala
                )

                comando.Parameters.AddWithValue(
                    "@inicio",
                    horaInicio
                )

                comando.Parameters.AddWithValue(
                    "@fin",
                    horaFin
                )

                conexion.Open()

                Return Convert.ToInt32(
                    comando.ExecuteScalar()
                ) > 0

            End Using
        End Using

    End Function


    Public Shared Sub Crear(
        idInstructor As Integer,
        idActividad As Integer,
        idSala As Integer,
        dia As Integer,
        horaInicio As TimeSpan,
        horaFin As TimeSpan
    )

        Dim sql As String =
            "INSERT INTO horarios
             (id_instructor,
              id_actividad,
              id_sala,
              dia_semana,
              hora_inicio,
              hora_fin,
              activo)
             VALUES
             (@instructor,
              @actividad,
              @sala,
              @dia,
              @inicio,
              @fin,
              1)"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue("@instructor", idInstructor)
                comando.Parameters.AddWithValue("@actividad", idActividad)
                comando.Parameters.AddWithValue("@sala", idSala)
                comando.Parameters.AddWithValue("@dia", dia)
                comando.Parameters.AddWithValue("@inicio", horaInicio)
                comando.Parameters.AddWithValue("@fin", horaFin)

                conexion.Open()

                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub


    Public Shared Sub Desactivar(
        idHorario As Integer
    )

        Dim sql As String =
            "UPDATE horarios
             SET activo = 0
             WHERE id_horario = @id"

        Using conexion As MySqlConnection =
            ConexionBD.ObtenerConexion()

            Using comando As New MySqlCommand(sql, conexion)

                comando.Parameters.AddWithValue(
                    "@id",
                    idHorario
                )

                conexion.Open()

                comando.ExecuteNonQuery()

            End Using
        End Using

    End Sub

End Class
