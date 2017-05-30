Imports System.Data.SqlClient
Public Class REPORTE_PROV2
    Dim FILA1, FILA2, MES00, MES01 As String
    Dim I1, I10, I2, I3, I4, I5, I6, I7, I8, I9 As Decimal
    Dim OBJ As New Class1
    Dim REP1 As New REP_PROV2
    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar1.Click
        main(99) = 0
        Me.Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        Dim TITULO As String
        MES00 = OBJ.COD_MES(cbo_mes1.Text)
        MES01 = OBJ.COD_MES(cbo_mes2.Text)
        Dim CONT0 As Integer = cbo_prov.SelectedIndex

        If (CONT0 = Integer.Parse("0")) Then
            TITULO = "Compras"
        ElseIf (CONT0 = Integer.Parse("1")) Then
            TITULO = "Ventas"
        ElseIf (CONT0 = Integer.Parse("2")) Then
            TITULO = "Honorarios"
        End If

        If (VERIFICAR_TITULO() = 0) Then
            MessageBox.Show("El reporte no cuenta con Título", "NO EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes1.Focus()
        ElseIf (VERIFICAR_FORMULA() = 0) Then
            MessageBox.Show("La provisión no cuenta con Fórmula", "NO EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes1.Focus()
        Else
            Dim VAR1 As Integer = cbo_prov.SelectedIndex
            If (VAR1 = Integer.Parse("0")) Then
                hallar_calculo_compras()
                hallar_filas_compras()
                importes_compras()
                calculo()
                resolver()
                LLENAR_DATASET()
                REP1.CREAR_REPORTE(FILA1, FILA2, TITULO)
                REP1.ShowDialog()
            ElseIf (VAR1 = Integer.Parse("1")) Then
                hallar_calculo_ventas()
                hallar_filas_ventas()
                importes_ventas()
                calculo()
                resolver()
                LLENAR_DATASET()
                REP1.CREAR_REPORTE(FILA1, FILA2, TITULO)
                REP1.ShowDialog()
            ElseIf (VAR1 = Integer.Parse("2")) Then
                hallar_calculo_honorarios()
                hallar_filas_honorarios()
                importes_honorarios()
                calculo()
                resolver()
                LLENAR_DATASET()
                REP1.CREAR_REPORTE(FILA1, FILA2, TITULO)
                REP1.ShowDialog()
            End If
        End If
    End Sub
    Sub calculo()
        Dim cont As Integer = (dgw_calculo.Rows.Count - 1)
        Dim cont2 As Integer = (dgw_importe.Rows.Count - 1)
        Dim formula As String = ""
        Dim CONT0 As Integer = (13 + cont2)
        Dim i As Integer = 13
        Do While (i <= CONT0)
            Dim VAR1 As Integer = cont
            Dim k As Integer = 0
            Do While (k <= VAR1)
                Dim LIMITE As Integer
                If (dgw_calculo.Item(1, k).Value.ToString = "") Then
                    dgw_importe.Item(i, k).Value = "0.00"
                    Continue Do
                End If
                I1 = Decimal.Parse(dgw_importe.Item(3, (i - 13)).Value)
                I2 = Decimal.Parse(dgw_importe.Item(4, (i - 13)).Value)
                I3 = Decimal.Parse(dgw_importe.Item(5, (i - 13)).Value)
                I4 = Decimal.Parse(dgw_importe.Item(6, (i - 13)).Value)
                I5 = Decimal.Parse(dgw_importe.Item(7, (i - 13)).Value)
                I6 = Decimal.Parse(dgw_importe.Item(8, (i - 13)).Value)
                I7 = Decimal.Parse(dgw_importe.Item(9, (i - 13)).Value)
                I8 = Decimal.Parse(dgw_importe.Item(10, (i - 13)).Value)
                I9 = Decimal.Parse(dgw_importe.Item(11, (i - 13)).Value)
                I10 = Decimal.Parse(dgw_importe.Item(12, (i - 13)).Value)
                formula = (dgw_calculo.Item(1, k).Value)
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
                Dim j As Integer = 0
                Do While (j <= (LIMITE - 1))
                    Dim cadena As String
                    Dim form_acum As String
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
                    dgw_importe.Item((k + 13), (i - 13)).Value = resultado
                Catch ex As Exception
                    dgw_importe.Item((k + 13), (i - 13)).Value = "0.00"
                End Try
                k += 1
            Loop
            i += 1
        Loop
    End Sub
    Sub hallar_calculo_compras()
        dgw_calculo.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_PRESENTACION_PROVISIONES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = "RC"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_calculo.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_calculo_honorarios()
        dgw_calculo.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_PRESENTACION_PROVISIONES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = "RH"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_calculo.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_calculo_ventas()
        dgw_calculo.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_PRESENTACION_PROVISIONES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = "RV"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_calculo.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_filas_compras()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_FILAS_REP_RC", con)
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
    Sub hallar_filas_honorarios()
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
    Sub hallar_filas_ventas()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_FILAS_REP_RV", con)
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
    Sub importes_compras()
        dgw_importe.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PROV2_COMPRAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = MES00
            PROG_01.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES01
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_importe.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_honorarios()
        dgw_importe.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PROV2_HONORARIOS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = MES00
            PROG_01.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES01
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_importe.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_ventas()
        dgw_importe.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PROV2_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = MES00
            PROG_01.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES01
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_importe.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LLENAR_DATASET()
        REP1.LIMPIAR()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, Decimal.Parse((dgw_importe.Item(21, I).Value)), Decimal.Parse((dgw_importe.Item(22, I).Value)), Decimal.Parse((dgw_importe.Item(23, I).Value)), Decimal.Parse((dgw_importe.Item(24, I).Value)), Decimal.Parse((dgw_importe.Item(25, I).Value)), Decimal.Parse((dgw_importe.Item(26, I).Value)), Decimal.Parse((dgw_importe.Item(27, I).Value)), Decimal.Parse((dgw_importe.Item(28, I).Value)), dgw_importe.Item(2, I).Value.ToString)
            I += 1
        Loop
    End Sub
    Sub resolver()
        Dim formula As String
        Dim i, cont, k As Integer
        Dim monto As Decimal = 0.0
        i = 0
        cont = dgw_importe.Rows.Count - 1
        'dgw_calculo.Item(i + 8, i - 24).Value = ""
        For k = 0 To cont
            For i = 13 To 20
                If dgw_importe.Item(i, k).Value = "" Then
                    dgw_importe.Item(i + 8, k).Value = "0.00"
                Else
                    formula = dgw_importe.Item(i, k).Value
                    Try
                        Dim CMD As New SqlCommand("SELECT " & formula, con)
                        con.Open()
                        monto = CMD.ExecuteScalar()
                        con.Close()
                    Catch ex As Exception
                        dgw_importe.Item(i + 8, k).Value = "0.00"
                    End Try
                    dgw_importe.Item(i + 8, k).Value = monto
                End If
            Next
        Next
    End Sub
    Function VERIFICAR_FORMULA() As Integer
        Dim COD_REP As String = ""
        Dim CONT As Integer = 0
        Dim CONT0 As Integer = cbo_prov.SelectedIndex
        If (CONT0 = Integer.Parse("0")) Then
            COD_REP = "RC"
        ElseIf (CONT0 = Integer.Parse("1")) Then
            COD_REP = "RV"
        ElseIf (CONT0 = Integer.Parse("2")) Then
            COD_REP = "RH"
        End If
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PRESENTACION", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REP
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Function VERIFICAR_TITULO() As Integer
        Dim COD_REP As String = ""
        Dim CONT As Integer = 0
        Dim CONT0 As Integer = cbo_prov.SelectedIndex
        If (CONT0 = Integer.Parse("0")) Then
            COD_REP = "RC"
        ElseIf (CONT0 = Integer.Parse("1")) Then
            COD_REP = "RV"
        ElseIf (CONT0 = Integer.Parse("2")) Then
            COD_REP = "RH"
        End If
        Try
            Dim CMD As New SqlCommand("VERIFICAR_TITULO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REP
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
End Class