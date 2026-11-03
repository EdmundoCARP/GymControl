''' <summary>
''' Fechas redactadas para documentos formales (R02).
''' Ejemplo: "a los dieciocho días del mes de octubre del año dos mil veintiséis".
''' </summary>
Public Module FechaEnLetras

    ''' <summary>
    ''' Redaccion completa usada en la constancia de membresía.
    ''' </summary>
    Public Function Completar(fecha As Date) As String

        Dim dia As String

        If fecha.Day = 1 Then
            dia = "al primer día"
        Else
            dia = "a los " & NumeroALetras.ConvertirNumero(fecha.Day) & " días"
        End If

        Return dia &
               " del mes de " &
               NumeroALetras.NombreMes(fecha.Month) &
               " del año " &
               NumeroALetras.ConvertirNumero(fecha.Year)

    End Function

    ''' <summary>
    ''' Fecha corta en palabras: "18 de octubre de 2026".
    ''' </summary>
    Public Function FechaLarga(fecha As Date) As String

        Return fecha.Day.ToString() &
               " de " &
               NumeroALetras.NombreMes(fecha.Month) &
               " de " &
               fecha.Year.ToString()

    End Function

End Module
