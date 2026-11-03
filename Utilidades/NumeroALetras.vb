''' <summary>
''' Conversion de cantidades a letras para los comprobantes.
''' Se usa en R01 (monto del recibo) y en R02 (fecha en letras).
''' Casos de prueba de la propuesta: 80, 250, 1,000 y 7,800.
''' </summary>
Public Module NumeroALetras

    Private ReadOnly Unidades As String() = {
        "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete",
        "ocho", "nueve", "diez", "once", "doce", "trece", "catorce",
        "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve",
        "veinte", "veintiuno", "veintidós", "veintitrés", "veinticuatro",
        "veinticinco", "veintiséis", "veintisiete", "veintiocho",
        "veintinueve"
    }

    Private ReadOnly Decenas As String() = {
        "", "", "veinte", "treinta", "cuarenta", "cincuenta",
        "sesenta", "setenta", "ochenta", "noventa"
    }

    Private ReadOnly Centenas As String() = {
        "", "ciento", "doscientos", "trescientos", "cuatrocientos",
        "quinientos", "seiscientos", "setecientos", "ochocientos",
        "novecientos"
    }

    Private ReadOnly Meses As String() = {
        "enero", "febrero", "marzo", "abril", "mayo", "junio",
        "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"
    }

    ''' <summary>
    ''' Convierte un entero positivo a letras. No agrega la moneda.
    ''' </summary>
    Public Function ConvertirNumero(numero As Long) As String

        If numero = 0 Then Return "cero"
        If numero < 0 Then Return "menos " & ConvertirNumero(-numero)

        Return ConvertirEntero(numero).Trim()

    End Function

    ''' <summary>
    ''' Monto en letras con el formato de los recibos:
    ''' "trescientos córdobas netos".
    ''' </summary>
    Public Function ConvertirCordobas(monto As Decimal) As String

        If monto < 0 Then
            Return "menos " & ConvertirCordobas(-monto)
        End If

        Dim entero As Long = CLng(Math.Truncate(monto))
        Dim centavos As Integer =
            CInt(Math.Round((monto - entero) * 100D, MidpointRounding.AwayFromZero))

        ' Por si el redondeo produce 100 centavos.
        If centavos >= 100 Then
            entero += 1
            centavos -= 100
        End If

        Dim letras As String = Apocopar(ConvertirEntero(entero))

        If centavos = 0 Then
            Return letras & " córdobas netos"
        End If

        Return letras & " córdobas con " &
               centavos.ToString("00") & "/100 netos"

    End Function

    ''' <summary>
    ''' Nombre del mes en minusculas, por ejemplo "octubre".
    ''' </summary>
    Public Function NombreMes(mes As Integer) As String

        If mes < 1 OrElse mes > 12 Then Return ""
        Return Meses(mes - 1)

    End Function

    Private Function ConvertirEntero(numero As Long) As String

        If numero = 0 Then Return ""

        If numero < 100 Then Return ConvertirDecenas(CInt(numero))

        If numero < 1000 Then

            Dim centena As Integer = CInt(numero \ 100)
            Dim resto As Integer = CInt(numero Mod 100)
            Dim texto As String

            If centena = 1 AndAlso resto = 0 Then
                texto = "cien"
            Else
                texto = Centenas(centena)
            End If

            If resto > 0 Then
                texto &= " " & ConvertirDecenas(resto)
            End If

            Return texto.Trim()

        End If

        If numero < 1000000 Then

            Dim miles As Long = numero \ 1000
            Dim resto As Long = numero Mod 1000
            Dim texto As String

            If miles = 1 Then
                texto = "mil"
            Else
                texto = ConvertirEntero(miles) & " mil"
            End If

            If resto > 0 Then
                texto &= " " & ConvertirEntero(resto)
            End If

            Return texto.Trim()

        End If

        If numero < 1000000000000L Then

            Dim millones As Long = numero \ 1000000
            Dim resto As Long = numero Mod 1000000
            Dim texto As String

            If millones = 1 Then
                texto = "un millón"
            Else
                texto = ConvertirEntero(millones) & " millones"
            End If

            If resto > 0 Then
                texto &= " " & ConvertirEntero(resto)
            End If

            Return texto.Trim()

        End If

        ' Fuera del rango de una factura; se usa el numero tal cual.
        Return numero.ToString()

    End Function

    Private Function ConvertirDecenas(numero As Integer) As String

        If numero < 30 Then
            Return Unidades(numero)
        End If

        Dim decena As Integer = numero \ 10
        Dim unidad As Integer = numero Mod 10

        If unidad = 0 Then
            Return Decenas(decena)
        End If

        Return Decenas(decena) & " y " & Unidades(unidad)

    End Function

    ''' <summary>
    ''' Ajusta "uno" a "un" delante de "córdobas" y "veintiuno"
    ''' a "veintiún".
    ''' </summary>
    Private Function Apocopar(texto As String) As String

        If texto.EndsWith("veintiuno", StringComparison.Ordinal) Then
            Return texto.Substring(0, texto.Length - 9) & "veintiún"
        End If

        If texto = "uno" Then Return "un"

        If texto.EndsWith(" uno", StringComparison.Ordinal) Then
            Return texto.Substring(0, texto.Length - 4) & " un"
        End If

        Return texto

    End Function

End Module
