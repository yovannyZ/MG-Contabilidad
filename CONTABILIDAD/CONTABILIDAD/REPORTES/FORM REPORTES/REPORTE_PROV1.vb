Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_PROV1
    Dim OBJ As New Class1
    Dim FILA1, FILA2, MES00, AÑO00, ord, HOJA As String
    Dim REP1 As New REP_PROV1
    Dim REP2 As New REP_PROV_VENTAS
    Dim I1, I2, I3, I4, I5, I6, I7, I8, I9, I10 As Decimal
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean


    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar1.Click
        main(98) = 0
        Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (cbo_prov.SelectedIndex = 0 OrElse cbo_prov.SelectedIndex = 1) AndAlso CBO_PCTAJE.SelectedIndex <> 2 Then
            If CBO_PCTAJE.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el I.G.V.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_PCTAJE.Focus() : Exit Sub
            If CBO_O1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden B.I.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_O1.Focus() : Exit Sub
            If CBO_O2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden I.G.V.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_O2.Focus() : Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------
        If cbo_prov.SelectedIndex = 2 AndAlso cbo_hoja.SelectedIndex = 2 Then MessageBox.Show("Elija otro tipo de Hoja para la impresion de este Reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_orden.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        If cbo_hoja.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Hoja a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub
        '---------------------------------------------------------------------------------------------------
        MES00 = OBJ.COD_MES(cbo_mes.Text)
        AÑO00 = cbo_año.Text
        Select Case cbo_hoja.SelectedIndex
            Case "0" : HOJA = "01"
            Case "1" : HOJA = "02"
            Case "2" : HOJA = "03"
        End Select
        Select Case cbo_orden.SelectedIndex
            Case "0" : ord = "0"
            Case "1" : ord = "1"
            Case "2" : ord = "2"
        End Select
        Dim TITULO, TITULO_CLIENTE, PAGINA As String
        TITULO = "" : TITULO_CLIENTE = "" : PAGINA = ""
        If txt_pag.Text = "" Then PAGINA = "0" Else PAGINA = txt_pag.Text
        Select Case cbo_prov.SelectedIndex
            Case "0" : TITULO = "Compras" : TITULO_CLIENTE = "Proveedor"
            Case "1" : TITULO = "Ventas" : TITULO_CLIENTE = "Cliente"
            Case "2" : TITULO = "Honorarios"
                TITULO_CLIENTE = "Proveedor"
        End Select
        If VERIFICAR_TITULO() = 0 Then
            MessageBox.Show("El reporte no cuenta con Título", "NO EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus() : Exit Sub
        End If
        If VERIFICAR_FORMULA() = 0 Then
            MessageBox.Show("La provisión no cuenta con Fórmula", "NO EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus() : Exit Sub
        End If
        '------------------------------------------------------------------------
        Select Case cbo_prov.SelectedIndex
            Case "0"
                hallar_calculo_compras()
                hallar_filas_compras()
                importes_compras()
                calculo()
                resolver()
                hallando_porcentajes_igv1()
                LLENAR_DATASET()
                '------------------------
                REP1.HOJA = HOJA
                REP1.UBICAR_REPORTE()
                '------------------------
                REP1.CREAR_REPORTE(FILA1, FILA2, PAGINA, dtp2.Value, ord, TITULO, cbo_mes.Text, cbo_año.Text, TITULO_CLIENTE)
                REP1.ShowDialog()
            Case "1"
                hallar_calculo_ventas()
                hallar_filas_ventas()
                importes_ventas()
                calculo()
                resolver()
                hallando_porcentajes_igv1()
                LLENAR_DATASET_VENTAS()
                '------------------------
                REP2.HOJA = HOJA
                REP2.UBICAR_REPORTE()
                '------------------------
                REP2.CREAR_REPORTE(FILA1, FILA2, PAGINA, dtp2.Value, ord, TITULO, cbo_mes.Text, cbo_año.Text, TITULO_CLIENTE)
                REP2.ShowDialog()
            Case "2"
                hallar_calculo_honorarios()
                hallar_filas_honorarios()
                importes_honorarios()
                calculo()
                resolver()
                LLENAR_DATASET_honorarios()
                '------------------------
                REP1.HOJA = HOJA
                REP1.UBICAR_REPORTE()
                '------------------------
                REP1.CREAR_REPORTE(FILA1, FILA2, PAGINA, dtp2.Value, ord, TITULO, cbo_mes.Text, cbo_año.Text, TITULO_CLIENTE)
                REP1.ShowDialog()
        End Select
    End Sub
    Sub LLENAR_DATASET_honorarios()
        REP1.LIMPIAR()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim TOTAL_ME As Decimal
            If dgw_importe.Item(13, I).Value = "D" Then
                TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
            Else
                TOTAL_ME = "0.00"
            End If
            REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value), Date.Parse(dgw_importe.Item(4, I).Value), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value, dgw_importe.Item(8, I).Value, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, dgw_importe.Item(13, I).Value.ToString, Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(41, I).Value, TOTAL_ME, dgw_importe.Item(43, I).Value, dgw_importe.Item(44, I).Value)
            'dgw_importe.Item(41, I).Value----- es total me (moneda extranjera)
            I += 1
        Loop
    End Sub
    Sub hallando_porcentajes_igv1()
        '----------------------------------------------------------
        Dim I, CONT As Integer
        Dim N1, N2 As String
        Dim DIV, NUM1, NUM2 As Decimal
        N1 = CBO_O1.Text
        N2 = CBO_O2.Text
        CONT = dgw_importe.RowCount - 1
        For I = 0 To CONT
            Select Case N1
                Case "01" : NUM1 = dgw_importe.Item(32, I).Value
                Case "02" : NUM1 = dgw_importe.Item(33, I).Value
                Case "03" : NUM1 = dgw_importe.Item(34, I).Value
                Case "04" : NUM1 = dgw_importe.Item(35, I).Value
                Case "05" : NUM1 = dgw_importe.Item(36, I).Value
                Case "06" : NUM1 = dgw_importe.Item(37, I).Value
                Case "07" : NUM1 = dgw_importe.Item(38, I).Value
                Case "08" : NUM1 = dgw_importe.Item(39, I).Value
            End Select
            Select Case N2
                Case "01" : NUM2 = dgw_importe.Item(32, I).Value
                Case "02" : NUM2 = dgw_importe.Item(33, I).Value
                Case "03" : NUM2 = dgw_importe.Item(34, I).Value
                Case "04" : NUM2 = dgw_importe.Item(35, I).Value
                Case "05" : NUM2 = dgw_importe.Item(36, I).Value
                Case "06" : NUM2 = dgw_importe.Item(37, I).Value
                Case "07" : NUM2 = dgw_importe.Item(38, I).Value
                Case "08" : NUM2 = dgw_importe.Item(39, I).Value
            End Select
            If NUM1 <> "0.00" Then
                DIV = NUM2 / NUM1 * 100
            Else
                DIV = "0.00"
            End If
            dgw_importe.Item(42, I).Value = OBJ.HACER_DECIMAL(DIV)
        Next
    End Sub
    Sub calculo()
        Dim cont As Integer = dgw_calculo.Rows.Count - 1
        Dim cont2 As Integer = dgw_importe.Rows.Count - 1
        Dim formula As String = ""
        Dim CONT0 As Integer = (24 + cont2)
        Dim i As Integer = 24
        For i = 24 To CONT0
            Dim VAR1 As Integer = cont
            Dim k As Integer = 0
            For k = 0 To cont
                Dim LIMITE As Integer
                If (dgw_calculo.Item(1, k).Value.ToString = "") Then
                    dgw_importe.Item(i, k).Value = "0.00"
                End If
                I1 = Decimal.Parse(dgw_importe.Item(14, (i - 24)).Value)
                I2 = Decimal.Parse(dgw_importe.Item(15, (i - 24)).Value)
                I3 = Decimal.Parse(dgw_importe.Item(16, (i - 24)).Value)
                I4 = Decimal.Parse(dgw_importe.Item(17, (i - 24)).Value)
                I5 = Decimal.Parse(dgw_importe.Item(18, (i - 24)).Value)
                I6 = Decimal.Parse(dgw_importe.Item(19, (i - 24)).Value)
                I7 = Decimal.Parse(dgw_importe.Item(20, (i - 24)).Value)
                I8 = Decimal.Parse(dgw_importe.Item(21, (i - 24)).Value)
                I9 = Decimal.Parse(dgw_importe.Item(22, (i - 24)).Value)
                I10 = Decimal.Parse(dgw_importe.Item(23, (i - 24)).Value)
                formula = (dgw_calculo.Item(1, k).Value)
                Dim tamaño As Integer = formula.Length
                Select Case tamaño
                    Case 2 : LIMITE = 1
                    Case 5 : LIMITE = 2
                    Case 8 : LIMITE = 3
                    Case 11 : LIMITE = 4
                    Case 14 : LIMITE = 5
                End Select
                Dim resultado As String = ""
                Dim j As Integer = 0
                For j = 0 To (LIMITE - 1)
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
                Next
                '----------------------------------------------------------
                Dim COLUMNA As Integer
                COLUMNA = dgw_calculo.Item(0, k).Value
                Select Case COLUMNA
                    Case "01"
                        Try
                            dgw_importe.Item(24, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(24, (i - 24)).Value = "0.00"
                        End Try
                    Case "02"
                        Try
                            dgw_importe.Item(25, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(25, (i - 24)).Value = "0.00"
                        End Try
                    Case "03"
                        Try
                            dgw_importe.Item(26, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(26, (i - 24)).Value = "0.00"
                        End Try
                    Case "04"
                        Try
                            dgw_importe.Item(27, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(27, (i - 24)).Value = "0.00"
                        End Try
                    Case "05"
                        Try
                            dgw_importe.Item(28, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(28, (i - 24)).Value = "0.00"
                        End Try
                    Case "06"
                        Try
                            dgw_importe.Item(29, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(29, (i - 24)).Value = "0.00"
                        End Try
                    Case "07"
                        Try
                            dgw_importe.Item(30, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(30, (i - 24)).Value = "0.00"
                        End Try
                    Case "08"
                        Try
                            dgw_importe.Item(31, (i - 24)).Value = resultado
                        Catch ex As Exception
                            dgw_importe.Item(32, (i - 24)).Value = "0.00"
                        End Try
                End Select
            Next
        Next
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
                dgw_calculo.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1))
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
                dgw_calculo.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1))
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
                dgw_calculo.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_filas()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_FILAS_REP_RC", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                FILA1 = Rs3.GetValue(0)
                FILA2 = Rs3.GetValue(1)
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
                FILA1 = Rs3.GetValue(0)
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
                FILA1 = Rs3.GetValue(0)
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
                FILA1 = Rs3.GetValue(0)
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
            Dim PROG_01 As New SqlCommand("REPORTE_REGISTRO_COMPRAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@fe_año", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@fe_mes", SqlDbType.Char).Value = MES00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_importe.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Rs3.GetValue(24), "", "", Rs3.GetValue(26))
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
            Dim PROG_01 As New SqlCommand("REPORTE_REGISTRO_HONORARIOS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@fe_año", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@fe_mes", SqlDbType.Char).Value = MES00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_importe.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Now, "", Rs3.GetValue(24), Rs3.GetValue(26))
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
            Dim PROG_01 As New SqlCommand("REPORTE_REGISTRO_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@fe_año", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@fe_mes", SqlDbType.Char).Value = MES00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_importe.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Rs3.GetValue(24), Rs3.GetValue(25), "", "", Rs3.GetValue(27))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LLENAR_DATASET()

        'If cbo_hoja.SelectedIndex <> 0 Then
        '    REP1.LIMPIAR()
        '    Dim I As Integer = 0
        '    Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
        '    Dim CONT0 As Integer = CONT
        '    I = 0
        '    'TOTAL_ME = 0
        '    Do While (I <= CONT0)
        '        Dim TOTAL_ME As Decimal
        '        If dgw_importe.Item(13, I).Value = "D" Then
        '            TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
        '        Else
        '            TOTAL_ME = "0.00"
        '        End If

        '        REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(41, I).Value, TOTAL_ME)
        '        I += 1
        '    Loop

        'Else
        '---------------------------------------------------------------------------------------------------------
        'PARA HOJA A4
        '---------------------------------------------------------------------------------------------------------
        'If cbo_hoja.SelectedIndex = 0 Then
        If CBO_PCTAJE.SelectedIndex = 0 Then
            REP1.LIMPIAR()
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If Decimal.Parse(dgw_importe.Item(42, I).Value) < 18.5 Then
                    Dim TOTAL_ME As Decimal
                    If dgw_importe.Item(13, I).Value = "D" Then
                        TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
                    Else
                        TOTAL_ME = "0.00"
                    End If
                    REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(41, I).Value, TOTAL_ME, "0.00", dgw_importe.Item(44, I).Value)
                End If
                I += 1
            Loop
        ElseIf CBO_PCTAJE.SelectedIndex = 1 Then
            REP1.LIMPIAR()
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If Decimal.Parse(dgw_importe.Item(42, I).Value) >= 18.5 Then
                    Dim TOTAL_ME As Decimal
                    If dgw_importe.Item(13, I).Value = "D" Then
                        TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
                    Else
                        TOTAL_ME = "0.00"
                    End If
                    REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(41, I).Value, TOTAL_ME, "0.00", dgw_importe.Item(44, I).Value)
                End If
                I += 1
            Loop
        ElseIf CBO_PCTAJE.SelectedIndex = 2 Then
            REP1.LIMPIAR()
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                Dim TOTAL_ME As Decimal
                If dgw_importe.Item(13, I).Value = "D" Then
                    TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
                Else
                    TOTAL_ME = "0.00"
                End If
                REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(41, I).Value, TOTAL_ME, "0.00", dgw_importe.Item(44, I).Value)
                I += 1
            Loop
        End If
        'End If
    End Sub
    Sub LLENAR_DATASET_VENTAS()


        If CBO_PCTAJE.SelectedIndex = 0 Then
            REP2.LIMPIAR()
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If Decimal.Parse(dgw_importe.Item(42, I).Value) < 18.5 Then
                    Dim TOTAL_ME As Decimal
                    If dgw_importe.Item(13, I).Value = "D" Then
                        TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
                    Else
                        TOTAL_ME = "0.00"
                    End If
                    REP2.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(40, I).Value, dgw_importe.Item(41, I).Value, TOTAL_ME, dgw_importe.Item(44, I).Value)
                End If
                I += 1
            Loop
        ElseIf CBO_PCTAJE.SelectedIndex = 1 Then
            REP2.LIMPIAR()
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If Decimal.Parse(dgw_importe.Item(42, I).Value) >= 18.5 Then
                    Dim TOTAL_ME As Decimal
                    If dgw_importe.Item(13, I).Value = "D" Then
                        TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
                    Else
                        TOTAL_ME = "0.00"
                    End If
                    REP2.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(40, I).Value, dgw_importe.Item(41, I).Value, TOTAL_ME, dgw_importe.Item(44, I).Value)
                End If
                I += 1
            Loop
        ElseIf CBO_PCTAJE.SelectedIndex = 2 Then
            REP2.LIMPIAR()
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                Dim TOTAL_ME As Decimal
                If dgw_importe.Item(13, I).Value = "D" Then
                    TOTAL_ME = ((dgw_importe.Item(32, I).Value) + (dgw_importe.Item(33, I).Value) + (dgw_importe.Item(34, I).Value) + (dgw_importe.Item(35, I).Value) + (dgw_importe.Item(36, I).Value) + (dgw_importe.Item(37, I).Value) + (dgw_importe.Item(38, I).Value) + (dgw_importe.Item(39, I).Value)) / (dgw_importe.Item(9, I).Value)
                Else
                    TOTAL_ME = "0.00"
                End If
                REP2.llenar_dt(dgw_importe.Item(0, I).Value, dgw_importe.Item(1, I).Value, dgw_importe.Item(2, I).Value, _
                    Date.Parse(dgw_importe.Item(3, I).Value), Date.Parse(dgw_importe.Item(4, I).Value), dgw_importe.Item(5, I).Value, _
                    dgw_importe.Item(6, I).Value, dgw_importe.Item(7, I).Value, dgw_importe.Item(8, I).Value, _
                    Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value, dgw_importe.Item(11, I).Value, _
                    dgw_importe.Item(12, I).Value, dgw_importe.Item(13, I).Value, Decimal.Parse(dgw_importe.Item(32, I).Value), _
                    Decimal.Parse(dgw_importe.Item(33, I).Value), Decimal.Parse(dgw_importe.Item(34, I).Value), _
                    Decimal.Parse(dgw_importe.Item(35, I).Value), Decimal.Parse(dgw_importe.Item(36, I).Value), _
                    Decimal.Parse(dgw_importe.Item(37, I).Value), Decimal.Parse(dgw_importe.Item(38, I).Value), _
                    Decimal.Parse(dgw_importe.Item(39, I).Value), dgw_importe.Item(40, I).Value, dgw_importe.Item(41, I).Value, _
                    TOTAL_ME, dgw_importe.Item(44, I).Value)
                I += 1
            Loop
            '----------------------------------
        End If
        'End If
    End Sub
    Private Sub REPORTE_PROV1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_PROV1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        KeyPreview = True
        cbo_orden.SelectedIndex = 0
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub resolver()
        Dim formula As String
        Dim i, cont, k As Integer
        Dim monto As Decimal = 0.0
        i = 0
        cont = dgw_importe.Rows.Count - 1
        'dgw_calculo.Item(i + 8, i - 24).Value = ""
        For k = 0 To cont
            For i = 24 To 31
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
        Dim CONT As Integer = 0
        Dim COD_REP As String = ""
        Select Case cbo_prov.SelectedIndex
            Case "0"
                COD_REP = "RC"
            Case "1"
                COD_REP = "RV"
            Case "2"
                COD_REP = "RH"
        End Select
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PRESENTACION", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REP
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Function VERIFICAR_TITULO() As Integer
        Dim CONT As Integer = 0
        Dim COD_REP As String = ""
        Select Case cbo_prov.SelectedIndex
            Case "0"
                COD_REP = "RC"
            Case "1"
                COD_REP = "RV"
            Case "2"
                COD_REP = "RH"
        End Select
        Try
            Dim CMD As New SqlCommand("VERIFICAR_TITULO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = COD_REP
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Private Sub cbo_prov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_prov.SelectedIndexChanged
        Select Case cbo_prov.SelectedIndex
            Case 0 : CARGAR_CBO_RC()
            Case 1 : CARGAR_CBO_RV()
        End Select
    End Sub
    Sub CARGAR_CBO_RC()
        CBO_O1.Items.Clear()
        CBO_O2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_PRESENTACION_PROVISIONES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = "RC"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_O1.Items.Add(Rs3.GetValue(0))
                CBO_O2.Items.Add(Rs3.GetValue(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CBO_RV()
        CBO_O1.Items.Clear()
        CBO_O2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_PRESENTACION_PROVISIONES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = "RV"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_O1.Items.Add(Rs3.GetValue(0))
                CBO_O2.Items.Add(Rs3.GetValue(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If (cbo_prov.SelectedIndex = 0 OrElse cbo_prov.SelectedIndex = 1) AndAlso CBO_PCTAJE.SelectedIndex <> 2 Then
            If CBO_PCTAJE.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el I.G.V.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_PCTAJE.Focus() : Exit Sub
            If CBO_O1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden B.I.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_O1.Focus() : Exit Sub
            If CBO_O2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden I.G.V.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_O2.Focus() : Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------
        If cbo_prov.SelectedIndex = 2 AndAlso cbo_hoja.SelectedIndex = 2 Then MessageBox.Show("Elija otro tipo de Hoja para la impresion de este Reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_orden.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub


        If VERIFICAR_TITULO() = 0 Then
            MessageBox.Show("El reporte no cuenta con Título", "NO EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus() : Exit Sub
        End If

        If VERIFICAR_FORMULA() = 0 Then
            MessageBox.Show("La provisión no cuenta con Fórmula", "NO EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus() : Exit Sub
        End If


        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                bwExportar.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub ExportarWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        MES00 = OBJ.COD_MES(cbo_mes.Text)
       
        Dim TITULO, TITULO_CLIENTE, PAGINA As String
        TITULO = "" : TITULO_CLIENTE = "" : PAGINA = ""

        Select Case cbo_prov.SelectedIndex
            Case "0" : TITULO = "Compras" : TITULO_CLIENTE = "Proveedor"
            Case "1" : TITULO = "Ventas" : TITULO_CLIENTE = "Cliente"
            Case "2" : TITULO = "Honorarios" : TITULO_CLIENTE = "Proveedor"
        End Select
        '------------------------------------------------------------------------
        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet

        '-----------------------------------
        con.Open()
        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"

            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA

            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA

            oHoja.Range("A3:B3").Merge()
            oHoja.Range("A3:B3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("DE: {0} {1}", cbo_mes.Text, cbo_año.Text)

            oHoja.Range("C2:N2").Merge()
            oHoja.Range("C2:N2").Font.Bold = True
            oHoja.Range("C2:N2").VerticalAlignment = -4108
            oHoja.Range("C2:N2").HorizontalAlignment = -4108
            oHoja.Cells(2, 3).Value = cbo_prov.Text
            'oHoja.Cells(3, 1) = String.Format("CUENTA: {0} {1}", txt_cod_cta0.Text, txt_desc_cta0.Text)

            Dim strRango As String = "A5:AC6"
            oHoja.Cells(5, 1) = "DOCUMENTO"
            oHoja.Cells(6, 1) = "COD" : oHoja.Cells(6, 2) = "DOCUMENTO" : oHoja.Cells(6, 3) = "NRO.DOC."
            oHoja.Cells(6, 4) = "EMISION" : oHoja.Cells(6, 5) = "PAG./VENC."

            oHoja.Cells(5, 6) = "COMPROBANTE"
            oHoja.Cells(6, 6) = "COD" : oHoja.Cells(6, 7) = "NRO.COMP."

            oHoja.Cells(5, 8) = "PERSONA"
            oHoja.Cells(6, 8) = "Cod.  -  Nº" : oHoja.Cells(6, 9) = "DESCRIPCION"

            oHoja.Cells(5, 10) = "ORDEN"
            oHoja.Cells(6, 10) = "ORDEN01" : oHoja.Cells(6, 11) = "ORDEN02" : oHoja.Cells(6, 12) = "ORDEN03"
            oHoja.Cells(6, 13) = "ORDEN04" : oHoja.Cells(6, 14) = "ORDEN05" : oHoja.Cells(6, 15) = "ORDEN06"
            oHoja.Cells(6, 16) = "ORDEN07" : oHoja.Cells(6, 17) = "ORDEN08" : oHoja.Cells(6, 18) = "ORDEN09"
            oHoja.Cells(6, 19) = "ORDEN10"

            oHoja.Cells(5, 20) = "TOTAL DOC"

            oHoja.Cells(5, 21) = "REFERENCIA"
            oHoja.Cells(6, 21) = "COD" : oHoja.Cells(6, 22) = "NRO" : oHoja.Cells(6, 23) = "FEC"

            oHoja.Cells(5, 24) = "TC"

            oHoja.Cells(5, 25) = "CTA.CTE"

            oHoja.Cells(5, 26) = "TOTAL ME"

            oHoja.Cells(5, 27) = "DETRACCION"
            oHoja.Cells(6, 27) = "NRO.DET" : oHoja.Cells(6, 28) = "COD.TASA" : oHoja.Cells(6, 29) = "FEC.DET"

            oHoja.Range("A5:E5").Merge()
            oHoja.Range("F5:G5").Merge()
            oHoja.Range("H5:I5").Merge()
            oHoja.Range("J5:S5").Merge()
            oHoja.Range("U5:W5").Merge()

            oHoja.Range("AA5:AC5").Merge()


            oHoja.Range("A:C,F:I,U:V,Y:Y").NumberFormat = "@"
            oHoja.Range("D:E").NumberFormat = "dd/mm/yyyy"
            'oHoja.Range("F:I").NumberFormat = "@"
            oHoja.Range("J:T,Z:Z").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"
            'oHoja.Range("U:V").NumberFormat = "@"
            oHoja.Range("W:W").NumberFormat = "dd/mm/yyyy"
            oHoja.Range("X:X").NumberFormat = "_(* #,##0.0000_);_(* (#,##0.0000);_(* ""-""????_);_(@_)"
            'oHoja.Range("X:X").NumberFormat = "@"
            'oHoja.Range("N:N").NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($.* ""-""??_);_(@_)"
            'oHoja.Range("O:P").NumberFormat = "_(s/.* #,##0.00_);_(s/.* (#,##0.00);_(s/.* ""-""??_);_(@_)"
            oHoja.Range("AC:AC").NumberFormat = "dd/mm/yyyy"


            archivoExcel = String.Format("Provisiones_{0}", cbo_prov.Text)

            Dim Fila As Integer = 7
            Dim CMD As New SqlCommand
            Select Case cbo_prov.SelectedIndex
                Case "0"
                    CMD = New SqlCommand("REPORTE_REGISTRO_COMPRAS", con)                    
                Case "1"
                    CMD = New SqlCommand("REPORTE_REGISTRO_VENTAS", con)
                Case "2"
                    CMD = New SqlCommand("REPORTE_REGISTRO_HONORARIOS", con)
            End Select

            CMD.CommandType = CommandType.StoredProcedure
            Dim par1 As SqlParameter = CMD.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par2 As SqlParameter = CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            par1.Value = MES00 : par2.Value = AÑO

            Dim drd As SqlDataReader = CMD.ExecuteReader
            Dim bs As New BindingSource
            bs.DataSource = drd
            drd.Close()
            Dim tReg As Integer = bs.Count
            drd = CMD.ExecuteReader
            Dim fAct As Integer = 0
            Dim POS_CODDOC As Integer = drd.GetOrdinal("COD_DOC")
            Dim POS_DESDOC As Integer = drd.GetOrdinal("DESC_DOC")
            Dim POS_NRODOC As Integer = drd.GetOrdinal("NUM_DOC")
            Dim POS_FECHADOC As Integer = drd.GetOrdinal("FECHA_DOC")
            Dim POS_FECHAVEN As Integer = drd.GetOrdinal("FECHA_VEN")
            Dim POS_CODCOMP As Integer = drd.GetOrdinal("COD_COMP")
            Dim POS_NROCOMP As Integer = drd.GetOrdinal("NRO_COMP")
            Dim POS_NRODOCPER As Integer = drd.GetOrdinal("NRO_DOC_PER")
            Dim POS_DESCPER As Integer = drd.GetOrdinal("DESC_PROVEEDOR")
            Dim POS_IMP01 As Integer = drd.GetOrdinal("IMP01")
            Dim POS_IMP02 As Integer = drd.GetOrdinal("IMP02")
            Dim POS_IMP03 As Integer = drd.GetOrdinal("IMP03")
            Dim POS_IMP04 As Integer = drd.GetOrdinal("IMP04")
            Dim POS_IMP05 As Integer = drd.GetOrdinal("IMP05")
            Dim POS_IMP06 As Integer = drd.GetOrdinal("IMP06")
            Dim POS_IMP07 As Integer = drd.GetOrdinal("IMP07")
            Dim POS_IMP08 As Integer = drd.GetOrdinal("IMP08")
            Dim POS_IMP09 As Integer = drd.GetOrdinal("IMP09")
            Dim POS_IMP10 As Integer = drd.GetOrdinal("IMP10")
            Dim POS_TOTAL As Integer = drd.GetOrdinal("IMP_TOTAL")
            Dim POS_CODREF As Integer = drd.GetOrdinal("COD_REF")
            Dim POS_NROREF As Integer = drd.GetOrdinal("NRO_REF")
            Dim POS_FECREF As Integer = drd.GetOrdinal("FECHA_REF")
            Dim POS_CODMON As Integer = drd.GetOrdinal("COD_MONEDA")
            Dim POS_TC As Integer = drd.GetOrdinal("TIPO_CAMBIO")
            Dim POS_CODPER As Integer = drd.GetOrdinal("COD_PER")
            Dim POS_COD_TIP_DOC As Integer = drd.GetOrdinal("COD_TIPO_DOC")
            Dim POS_NRO_DET As Integer = drd.GetOrdinal("NRO_DET")
            Dim POS_TASA_DET As Integer = drd.GetOrdinal("TASA_DET")
            Dim POS_FECHA_DET As Integer = drd.GetOrdinal("FECHA_DET")
            While drd.Read
                Dim total As Decimal
                Dim codDoc As String = drd.GetString(POS_CODDOC)
                total = drd.GetDecimal(POS_IMP01) + drd.GetDecimal(POS_IMP02) + drd.GetDecimal(POS_IMP03) + drd.GetDecimal(POS_IMP04) + drd.GetDecimal(POS_IMP05) + drd.GetDecimal(POS_IMP06) + drd.GetDecimal(POS_IMP07) + drd.GetDecimal(POS_IMP08) + drd.GetDecimal(POS_IMP09) + drd.GetDecimal(POS_IMP10)
                oHoja.Cells(Fila, 1) = drd.GetString(POS_CODDOC)
                oHoja.Cells(Fila, 2) = drd.GetString(POS_DESDOC)
                oHoja.Cells(Fila, 3) = drd.GetString(POS_NRODOC)
                oHoja.Cells(Fila, 4) = drd.GetDateTime(POS_FECHADOC)
                oHoja.Cells(Fila, 5) = drd.GetDateTime(POS_FECHAVEN)
                oHoja.Cells(Fila, 6) = drd.GetString(POS_CODCOMP)
                oHoja.Cells(Fila, 7) = drd.GetString(POS_NROCOMP)
                oHoja.Cells(Fila, 8) = drd.GetString(POS_COD_TIP_DOC) & " - " & drd.GetString(POS_NRODOCPER)
                oHoja.Cells(Fila, 9) = drd.GetString(POS_DESCPER)
                oHoja.Cells(Fila, 10) = drd.GetDecimal(POS_IMP01)
                oHoja.Cells(Fila, 11) = drd.GetDecimal(POS_IMP02)
                oHoja.Cells(Fila, 12) = drd.GetDecimal(POS_IMP03)
                oHoja.Cells(Fila, 13) = drd.GetDecimal(POS_IMP04)
                oHoja.Cells(Fila, 14) = drd.GetDecimal(POS_IMP05)
                oHoja.Cells(Fila, 15) = drd.GetDecimal(POS_IMP06)
                oHoja.Cells(Fila, 16) = drd.GetDecimal(POS_IMP07)
                oHoja.Cells(Fila, 17) = drd.GetDecimal(POS_IMP08)
                oHoja.Cells(Fila, 18) = drd.GetDecimal(POS_IMP09)
                oHoja.Cells(Fila, 19) = drd.GetDecimal(POS_IMP10)
                oHoja.Cells(Fila, 20) = total
                If codDoc = "07" OrElse codDoc = "87" OrElse codDoc = "97" OrElse _
                codDoc = "08" OrElse codDoc = "88" OrElse codDoc = "98" Then
                    oHoja.Cells(Fila, 21) = drd.GetString(POS_CODREF)
                    oHoja.Cells(Fila, 22) = drd.GetString(POS_NROREF)
                    oHoja.Cells(Fila, 23) = IIf(drd.GetString(POS_CODREF).Trim = "", "", drd.GetDateTime(POS_FECREF))
                End If
                oHoja.Cells(Fila, 24) = drd.GetDecimal(POS_TC)
                oHoja.Cells(Fila, 25) = drd.GetString(POS_CODPER)
                oHoja.Cells(Fila, 26) = IIf(drd.GetString(POS_CODMON) <> "S", drd.GetDecimal(POS_TOTAL) / drd.GetDecimal(POS_TC), 0)
                If cbo_prov.SelectedIndex = "0" Then
                    oHoja.Cells(Fila, 27) = drd.GetString(POS_NRO_DET)
                    oHoja.Cells(Fila, 28) = IIf(drd.GetDecimal(POS_TASA_DET) = 0, "", drd.GetDecimal(POS_TASA_DET))
                    oHoja.Cells(Fila, 29) = drd.GetDateTime(POS_FECHA_DET)
                End If
                Fila += 1
                fAct += 1
                bwExportar.ReportProgress((fAct / tReg) * 100)
            End While
            drd.Close()
            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            oHoja.Range(String.Format("A7:AC{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:AC{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub ExportarProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        tspbExportar.Value = e.ProgressPercentage
        tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub

    Private Sub ExportarComplete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls ", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tspbExportar.Value = 0
        stEstado.Visible = False
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class