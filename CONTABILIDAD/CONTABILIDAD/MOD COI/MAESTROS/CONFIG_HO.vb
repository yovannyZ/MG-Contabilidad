Imports System.Data.SqlClient
Public Class CONFIG_HO
    Private FILA1 As String
    Private FILA2 As String
    Private formula As String
    Private I1 As Decimal
    Private I10 As Decimal
    Private I2 As Decimal
    Private I3 As Decimal
    Private I4 As Decimal
    Private I5 As Decimal
    Private I6 As Decimal
    Private I7 As Decimal
    Private I8 As Decimal
    Private I9 As Decimal
    'Private REP1 As REP_HO
    Private Sub btn_calculo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_calculo.Click
        btn_calculo.Enabled = False
        btn_imprimir.Enabled = True
        calculo()
        resolver()
    End Sub
    Public Sub resolver()
        Dim monto As New Decimal
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        dgw_calculo.Item(3, i).Value = ""
        i = 0
        Do While (i <= cont)
            If dgw_calculo.Item(2, i).Value.ToString = "" Then
                dgw_calculo.Item(3, i).Value = ""
            Else
                Dim formula As String = (dgw_calculo.Item(2, i).Value)
                Try
                    Dim CMD As New SqlCommand(("SELECT " & formula), con)
                    con.Open()
                    monto = Decimal.Parse(CMD.ExecuteScalar)
                    con.Close()
                Catch ex As Exception


                    dgw_calculo.Item(3, i).Value = ""

                End Try
                dgw_calculo.Item(3, i).Value = monto
            End If
            i += 1
        Loop
    End Sub


    Private Sub btn_imprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_imprimir.Click
        hallar_filas()
        Dim c1 As String = (dgw_calculo.Item(3, 0).Value)
        Dim c2 As String = (dgw_calculo.Item(3, 1).Value)
        Dim c3 As String = (dgw_calculo.Item(3, 2).Value)
        Dim c4 As String = (dgw_calculo.Item(3, 3).Value)
        Dim CONT As Integer = (dgw_calculo.Rows.Count - 1)
        Dim SUMA As New Decimal
        Dim I As Integer = 0
        Do While (I <= CONT)
            SUMA = Decimal.Parse(Decimal.Add(SUMA, dgw_calculo.Item(3, I).Value))
            I += 1
        Loop
        'REP1.CREAR_REPORTE(FILA1, FILA2, c1, c2, c3, c4, SUMA)
        'REP1.ShowDialog()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        dgw_calculo.Rows.Clear()
        dgw_calculo.Rows.Add(New Object() {"01"})
        dgw_calculo.Rows.Add(New Object() {"02"})
        dgw_calculo.Rows.Add(New Object() {"03"})
        dgw_calculo.Rows.Add(New Object() {"04"})
        btn_imprimir.Enabled = False
        btn_calculo.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(29) = 0
        Close()
    End Sub

    Public Sub calculo()
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim formula As String = ""
        i = 0
        Do While (i <= cont)
            Dim LIMITE As Integer
            If dgw_calculo.Item(1, i).Value = "" Then
                dgw_calculo.Item(2, i).Value = "0.00"
                Continue Do
            End If
            hallar_importes()
            formula = (dgw_calculo.Item(1, i).Value)
            Dim tamaño As Integer = formula.Length
            Select Case tamaño
                Case 2
                    LIMITE = 1

                Case 5
                    LIMITE = 2

                Case 8
                    LIMITE = 3

                Case 11
                    LIMITE = 4

                Case 14
                    LIMITE = 5

            End Select
            Dim resultado As String = ""
            j = 0
            Do While (j <= LIMITE - 1)
                Dim cadena As String
                Dim form_acum As String = ""
                If (j = 0) Then
                    cadena = formula.Substring(j, 2)
                Else
                    cadena = formula.Substring((j * 3), 2)
                End If
                Select Case cadena
                    Case "01"
                        form_acum = cadena.Replace("01", (Decimal.Parse((I1))))

                    Case "02"
                        form_acum = cadena.Replace("02", (Decimal.Parse((I2))))

                    Case "03"
                        form_acum = cadena.Replace("03", (Decimal.Parse((I3))))

                    Case "04"
                        form_acum = cadena.Replace("04", (Decimal.Parse((I4))))

                    Case "05"
                        form_acum = cadena.Replace("05", (Decimal.Parse((I5))))

                    Case "06"
                        form_acum = cadena.Replace("06", (Decimal.Parse((I6))))

                    Case "07"
                        form_acum = cadena.Replace("07", (Decimal.Parse((I7))))

                    Case "08"
                        form_acum = cadena.Replace("08", (Decimal.Parse((I8))))

                    Case "09"
                        form_acum = cadena.Replace("09", (Decimal.Parse((I9))))

                    Case "10"
                        form_acum = cadena.Replace("10", (Decimal.Parse((I10))))

                End Select
                If (tamaño = 2) Then
                    resultado = form_acum
                ElseIf (j <> (LIMITE - 1)) Then
                    resultado = (resultado & form_acum & formula.Substring(((j * 3) + 2), 1))
                Else
                    resultado = (resultado & form_acum)
                End If
                j += 1
            Loop
            Try
                dgw_calculo.Item(2, i).Value = resultado
            Catch ex As Exception


                dgw_calculo.Item(2, i).Value = "0.00"

            End Try
            i += 1
        Loop
    End Sub

    Private Sub CONFIG_HO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CONFIG_HO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw_calculo.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_calculo.Rows.Add(New Object() {"01"})
        dgw_calculo.Rows.Add(New Object() {"02"})
        dgw_calculo.Rows.Add(New Object() {"03"})
        dgw_calculo.Rows.Add(New Object() {"04"})
        btn_calculo.Select()
    End Sub

   

    Public Sub hallar_filas()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_FILAS_REP_HO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                FILA1 = (Rs3.GetValue(0))
                FILA2 = Rs3.GetValue(1)
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub hallar_importes()
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_IMPORTES_REGISTRO_HONORARIOS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                I1 = Decimal.Parse(Rs3.GetValue(0))
                I2 = Decimal.Parse(Rs3.GetValue(1))
                I3 = Decimal.Parse(Rs3.GetValue(2))
                I4 = Decimal.Parse(Rs3.GetValue(3))
                I5 = Decimal.Parse(Rs3.GetValue(4))
                I6 = Decimal.Parse(Rs3.GetValue(5))
                I7 = Decimal.Parse(Rs3.GetValue(6))
                I8 = Decimal.Parse(Rs3.GetValue(7))
                I9 = Decimal.Parse(Rs3.GetValue(8))
                I10 = Decimal.Parse(Rs3.GetValue(9))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

End Class