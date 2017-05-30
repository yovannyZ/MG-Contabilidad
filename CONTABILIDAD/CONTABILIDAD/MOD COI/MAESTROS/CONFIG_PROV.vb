Imports System.Data.SqlClient
Public Class CONFIG_PROV
    Dim COD_REPORTE, FILA1, FILA2, formula As String
    Dim I1 As Decimal
    Dim I10 As Decimal
    Dim I2 As Decimal
    Dim I3 As Decimal
    Dim I4 As Decimal
    Dim I5 As Decimal
    Dim I6 As Decimal
    Dim I7 As Decimal
    Dim I8 As Decimal
    Dim I9 As Decimal
    Dim OBJ As New Class1

    Private Sub btn_calculo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_calculo.Click
        btn_calculo.Enabled = False
        btn_imprimir.Enabled = True
        Dim CONT As Integer = cbo_reg.SelectedIndex
        If (CONT = Integer.Parse("0")) Then
            calculo_compras()
            resolver_compras()
        ElseIf (CONT = Integer.Parse("1")) Then
            calculo_ventas()
            resolver_ventas()
        ElseIf (CONT = Integer.Parse("2")) Then
            calculo_honorario()
            resolver_honorario()
        End If
        btn_grabar.Enabled = True
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
        Dim CONT0 As Integer = cbo_reg.SelectedIndex
        If (CONT0 = Integer.Parse("0")) Then
            dgw_calculo.Rows.Clear()
            'btn_calculo.Enabled = True
            'btn_grabar.Enabled = False
            dgw_calculo.Rows.Add("01")
            dgw_calculo.Rows.Add("02")
            dgw_calculo.Rows.Add("03")
            dgw_calculo.Rows.Add("04")
            dgw_calculo.Rows.Add("05")
            dgw_calculo.Rows.Add("06")
            dgw_calculo.Rows.Add("07")
            dgw_calculo.Rows.Add("08")
        ElseIf (CONT0 = Integer.Parse("1")) Then
            dgw_calculo.Rows.Clear()
            'btn_calculo.Enabled = True
            'btn_grabar.Enabled = False
            dgw_calculo.Rows.Add("01")
            dgw_calculo.Rows.Add("02")
            dgw_calculo.Rows.Add("03")
            dgw_calculo.Rows.Add("04")
            dgw_calculo.Rows.Add("05")
            dgw_calculo.Rows.Add("06")
        ElseIf (CONT0 = Integer.Parse("2")) Then
            dgw_calculo.Rows.Clear()
            dgw_calculo.Rows.Add("01")
            dgw_calculo.Rows.Add("02")
            dgw_calculo.Rows.Add("03")
            dgw_calculo.Rows.Add("04")
            'btn_grabar.Enabled = False
            'btn_calculo.Enabled = True
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(101) = 0
        Close()
    End Sub
    Sub ELIMINAR()
        'Dim i, cont As Integer
        'i = 0
        'cont = dgw_det.RowCount - 1
        'For i = 0 To cont
        Try
            Dim CMD As New SqlCommand("ELIMINAR_PRESENTACION", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REPORTE
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        'Next
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar.Click
        Select Case cbo_reg.SelectedIndex
            Case "0"
                COD_REPORTE = "RC"
            Case "1"
                COD_REPORTE = "RV"
            Case "2"
                COD_REPORTE = "RH"
        End Select
        If (CONTAR_REG() > 0) Then
            ELIMINAR()
            INSERTAR()
            'MessageBox.Show("La Configuración de Provisiones ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            INSERTAR()
        End If

    End Sub
    Sub INSERTAR()
        Dim I As Integer = 0
        Dim M, N As String
        Dim CONT As Integer = (dgw_calculo.Rows.Count - 1)
        Dim CONT1 As Integer = CONT
        I = 0
        Do While (I <= CONT1)
            'If ((dgw_calculo.Item(1, I).Value) <> "") Then
            N = (dgw_calculo.Item(1, I).Value)
            If N <> "" Then
                M = N
            Else
                M = ""
            End If
            Try
                Dim CMD As New SqlCommand("INSERTAR_PRESENTACION", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REPORTE
                CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = dgw_calculo.Item(0, I).Value.ToString
                CMD.Parameters.Add("@CALCULO", SqlDbType.VarChar).Value = M
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
            End Try
            'End If
            I += 1
        Loop
        MessageBox.Show("La Configuración de Provisiones se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'btn_grabar.Enabled = False
    End Sub

    Public Sub calculo_compras()
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim formula As String = ""
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            Dim LIMITE As Integer
            If dgw_calculo.Item(1, i).Value = "" Then
                dgw_calculo.Item(2, i).Value = "0.00"
                Continue Do
            End If
            hallar_importes_compras()
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
            CONT0 = (LIMITE - 1)
            j = 0
            Do While (j <= CONT0)
                Dim cadena As String
                Dim form_acum As String = ""
                If (j = 0) Then
                    cadena = formula.Substring(j, 2)
                Else
                    cadena = formula.Substring((j * 3), 2)
                End If
                Select Case cadena
                    Case "01" : form_acum = cadena.Replace("01", (Decimal.Parse((I1))))
                    Case "02" : form_acum = cadena.Replace("02", (Decimal.Parse((I2))))
                    Case "03" : form_acum = cadena.Replace("03", (Decimal.Parse((I3))))
                    Case "04" : form_acum = cadena.Replace("04", (Decimal.Parse((I4))))
                    Case "05" : form_acum = cadena.Replace("05", (Decimal.Parse((I5))))
                    Case "06" : form_acum = cadena.Replace("06", (Decimal.Parse((I6))))
                    Case "07" : form_acum = cadena.Replace("07", (Decimal.Parse((I7))))
                    Case "08" : form_acum = cadena.Replace("08", (Decimal.Parse((I8))))
                    Case "09" : form_acum = cadena.Replace("09", (Decimal.Parse((I9))))
                    Case "10" : form_acum = cadena.Replace("10", (Decimal.Parse((I10))))
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

    Sub calculo_honorario()
        Dim formula, cadena, form_acum, resultado As String
        Dim i, cont, tamaño, j, LIMITE As Integer
        cont = dgw_calculo.Rows.Count - 1 : i = 0 : j = 0
        formula = ""
        For i = 0 To cont
            If dgw_calculo.Item(1, i).Value = "" Then
                dgw_calculo.Item(2, i).Value = "0.00"
            Else
                hallar_importes_honorario()
                formula = dgw_calculo.Item(1, i).Value
                tamaño = formula.Length
                Select Case (tamaño)
                    Case 2 : LIMITE = 1
                    Case 5 : LIMITE = 2
                    Case 8 : LIMITE = 3
                    Case 11 : LIMITE = 4
                    Case 14 : LIMITE = 5
                End Select
                resultado = ""
                For j = 0 To LIMITE - 1
                    If j = 0 Then
                        cadena = formula.Substring(j, 2)
                    Else
                        cadena = formula.Substring((j * 3), 2)
                    End If
                    Select Case cadena
                        Case "01" : form_acum = cadena.Replace("01", Decimal.Parse(I1))
                        Case "02" : form_acum = cadena.Replace("02", Decimal.Parse(I2))
                        Case "03" : form_acum = cadena.Replace("03", Decimal.Parse(I3))
                        Case "04" : form_acum = cadena.Replace("04", Decimal.Parse(I4))
                        Case "05" : form_acum = cadena.Replace("05", Decimal.Parse(I5))
                        Case "06" : form_acum = cadena.Replace("06", Decimal.Parse(I6))
                        Case "07" : form_acum = cadena.Replace("07", Decimal.Parse(I7))
                        Case "08" : form_acum = cadena.Replace("08", Decimal.Parse(I8))
                        Case "09" : form_acum = cadena.Replace("09", Decimal.Parse(I9))
                        Case "10" : form_acum = cadena.Replace("10", Decimal.Parse(I10))
                    End Select
                    If tamaño = 2 Then
                        resultado = form_acum
                    ElseIf j <> LIMITE - 1 Then
                        resultado = resultado & form_acum & formula.Substring((j * 3) + 2, 1)
                    Else
                        resultado = resultado & form_acum
                    End If
                Next
                Try
                    dgw_calculo.Item(2, i).Value = resultado
                Catch ex As Exception
                    dgw_calculo.Item(2, i).Value = "0.00"
                End Try
            End If
        Next

    End Sub
    Sub calculo_ventas()
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim formula As String = ""
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            Dim LIMITE As Integer
            If dgw_calculo.Item(1, i).Value = "" Then
                dgw_calculo.Item(2, i).Value = "0.00"
                Continue Do
            End If
            hallar_importes_ventas()
            formula = (dgw_calculo.Item(1, i).Value)
            Dim tamaño As Integer = formula.Length
            Select Case tamaño
                Case 2 : LIMITE = 1
                Case 5 : LIMITE = 2
                Case 8 : LIMITE = 3
                Case 11 : LIMITE = 4
                Case 14 : LIMITE = 5
            End Select
            Dim resultado As String = ""
            CONT0 = (LIMITE - 1)
            j = 0
            Do While (j <= CONT0)
                Dim cadena As String
                Dim form_acum As String = ""
                If (j = 0) Then
                    cadena = formula.Substring(j, 2)
                Else
                    cadena = formula.Substring((j * 3), 2)
                End If
                Select Case cadena
                    Case "01" : form_acum = cadena.Replace("01", (Decimal.Parse((I1))))
                    Case "02" : form_acum = cadena.Replace("02", (Decimal.Parse((I2))))
                    Case "03" : form_acum = cadena.Replace("03", (Decimal.Parse((I3))))
                    Case "04" : form_acum = cadena.Replace("04", (Decimal.Parse((I4))))
                    Case "05" : form_acum = cadena.Replace("05", (Decimal.Parse((I5))))
                    Case "06" : form_acum = cadena.Replace("06", (Decimal.Parse((I6))))
                    Case "07" : form_acum = cadena.Replace("07", (Decimal.Parse((I7))))
                    Case "08" : form_acum = cadena.Replace("08", (Decimal.Parse((I8))))
                    Case "09" : form_acum = cadena.Replace("09", (Decimal.Parse((I9))))
                    Case "10" : form_acum = cadena.Replace("10", (Decimal.Parse((I10))))
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
    Sub NUEVO_REGISTRO()
        Dim CONT0 As Integer = cbo_reg.SelectedIndex
        If (CONT0 = Integer.Parse("0")) Then
            dgw_calculo.Rows.Clear()
            dgw_calculo.Rows.Add("01")
            dgw_calculo.Rows.Add("02")
            dgw_calculo.Rows.Add("03")
            dgw_calculo.Rows.Add("04")
            dgw_calculo.Rows.Add("05")
            dgw_calculo.Rows.Add("06")
            dgw_calculo.Rows.Add("07")
            dgw_calculo.Rows.Add("08")
            btn_calculo.Select()
        ElseIf (CONT0 = Integer.Parse("1")) Then
            dgw_calculo.Rows.Clear()
            dgw_calculo.Rows.Add("01")
            dgw_calculo.Rows.Add("02")
            dgw_calculo.Rows.Add("03")
            dgw_calculo.Rows.Add("04")
            dgw_calculo.Rows.Add("05")
            dgw_calculo.Rows.Add("06")
            btn_calculo.Select()
        ElseIf (CONT0 = Integer.Parse("2")) Then
            dgw_calculo.Rows.Clear()
            dgw_calculo.Rows.Add("01")
            dgw_calculo.Rows.Add("02")
            dgw_calculo.Rows.Add("03")
            dgw_calculo.Rows.Add("04")
            btn_calculo.Select()
        End If
    End Sub
    Private Sub cbo_reg_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_reg.SelectedIndexChanged
        Select Case cbo_reg.SelectedIndex
            Case "0"
                COD_REPORTE = "RC"
            Case "1"
                COD_REPORTE = "RV"
            Case "2"
                COD_REPORTE = "RH"
        End Select
        If (CONTAR_REG() > 0) Then
            CARGAR_FORMULAS()
        Else
            NUEVO_REGISTRO()
        End If
    End Sub
    Sub CARGAR_FORMULAS()
        dgw_calculo.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_FORMULAS_PRESENTACION", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REPORTE
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_calculo.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CONFIG_HO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB")
        End If
    End Sub

    Private Sub CONFIG_HO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw_calculo.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PRESENTACION", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REPORTE
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
        End Try
        Return CONT
    End Function



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

    Public Sub hallar_importes_compras()
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_IMPORTES_REGISTRO_COMPRAS", con)
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

    Public Sub hallar_importes_honorario()
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

    Public Sub hallar_importes_ventas()
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_IMPORTES_REGISTRO_VENTAS", con)
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
    Public Sub resolver_compras()
        Dim monto As New Decimal
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        dgw_calculo.Item(3, i).Value = ""
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            If dgw_calculo.Item(2, i).Value = "" Then
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

    Public Sub resolver_honorario()
        Dim monto As New Decimal
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        dgw_calculo.Item(3, i).Value = ""
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            If dgw_calculo.Item(2, i).Value = "" Then
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

    Public Sub resolver_ventas()
        Dim monto As New Decimal
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        dgw_calculo.Item(3, i).Value = ""
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            If dgw_calculo.Item(2, i).Value = "" Then
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

End Class