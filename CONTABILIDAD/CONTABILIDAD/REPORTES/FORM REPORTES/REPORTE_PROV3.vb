Imports System.Data.SqlClient
Public Class REPORTE_PROV3
    Dim FILA2, MES01, MES00, ST_PER, COD_PER, FILA1 As String
    Dim I1, I10, I2, I3, I4, I5, I6, I7, I8, I9 As Decimal
    Dim OBJ As New Class1
    Dim REP1 As New REP_PROV3
    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar1.Click
        main(100) = 0
        Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        If ch_per1.Checked = True And txt_cod_per.Text = "" Then MessageBox.Show("Debe elegir la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per.Focus() : Exit Sub
        Dim R, TITULO As String
        TITULO = "" : R = ""
        MES00 = OBJ.COD_MES(cbo_mes1.Text)
        MES01 = OBJ.COD_MES(cbo_mes2.Text)
        Dim CONT0 As Integer = cbo_prov.SelectedIndex
        If (CONT0 = Integer.Parse("0")) Then
            TITULO = "COMPRAS"
            R = " "
        ElseIf (CONT0 = Integer.Parse("1")) Then
            TITULO = "VENTAS"
            R = " "
        ElseIf (CONT0 = Integer.Parse("2")) Then
            TITULO = "HONORARIOS"
            R = "R"
        End If
        '---------------------------------------------------------
        If ch_per1.Checked = True Then
            ST_PER = "0"
            COD_PER = txt_cod_per.Text
        Else
            ST_PER = "1"
            COD_PER = " "
        End If
        '---------------------------------------------------------
        Dim VAR1 As Integer = cbo_prov.SelectedIndex
        If (VAR1 = Integer.Parse("0")) Then
            hallar_calculo_compras()
            importes_compras()
            calculo()
            LLENAR_DATASET()
            REP1.CREAR_REPORTE(MES00, MES01, TITULO, R, cbo_año.Text)
            REP1.ShowDialog()
        ElseIf (VAR1 = Integer.Parse("1")) Then
            hallar_calculo_ventas()
            importes_ventas()
            calculo()
            LLENAR_DATASET()
            REP1.CREAR_REPORTE(MES00, MES01, TITULO, R, cbo_año.Text)
            REP1.ShowDialog()
        ElseIf (VAR1 = Integer.Parse("2")) Then
            hallar_calculo_HONORARIOs()
            importes_honorarios()
            calculo()
            LLENAR_DATASET()
            REP1.CREAR_REPORTE(MES00, MES01, TITULO, R, cbo_año.Text)
            REP1.ShowDialog()
        End If
    End Sub
    Sub calculo()
        Dim c1 As Integer = dgw1.Rows.Count - 1
        Dim c2 As Integer = dgw2.Rows.Count - 1
        Dim CONT0 As Integer = (17 + c2)
        Dim j As Integer = 17
        Do While (j <= CONT0)
            Dim bi As New Decimal
            Dim igv As New Decimal
            Dim renta As New Decimal
            Dim VAR1 As Integer = c1
            Dim i As Integer = 0
            Do While (i <= VAR1)
                I1 = Decimal.Parse(dgw2.Item(7, (j - 17)).Value)
                I2 = Decimal.Parse(dgw2.Item(8, (j - 17)).Value)
                I3 = Decimal.Parse(dgw2.Item(9, (j - 17)).Value)
                I4 = Decimal.Parse(dgw2.Item(10, (j - 17)).Value)
                I5 = Decimal.Parse(dgw2.Item(11, (j - 17)).Value)
                I6 = Decimal.Parse(dgw2.Item(12, (j - 17)).Value)
                I7 = Decimal.Parse(dgw2.Item(13, (j - 17)).Value)
                I8 = Decimal.Parse(dgw2.Item(14, (j - 17)).Value)
                I9 = Decimal.Parse(dgw2.Item(15, (j - 17)).Value)
                I10 = Decimal.Parse(dgw2.Item(16, (j - 17)).Value)
                Dim tipo_orden As String = dgw1.Item(1, i).Value.ToString
                Dim NRO_ORDEN As String = dgw1.Item(0, i).Value.ToString
                Select Case tipo_orden
                    Case "B"
                        Select Case NRO_ORDEN
                            Case "01"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(7, (j - 17)).Value))
                            Case "02"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(8, (j - 17)).Value))
                            Case "03"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(9, (j - 17)).Value))
                            Case "04"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(10, (j - 17)).Value))
                            Case "05"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(11, (j - 17)).Value))
                            Case "06"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(12, (j - 17)).Value))
                            Case "07"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(13, (j - 17)).Value))
                            Case "08"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(14, (j - 17)).Value))
                            Case "09"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(15, (j - 17)).Value))
                            Case "10"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(16, (j - 17)).Value))
                        End Select
                    Case "I"
                        Select Case NRO_ORDEN
                            Case "01"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(7, (j - 17)).Value))
                            Case "02"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(8, (j - 17)).Value))
                            Case "03"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(9, (j - 17)).Value))
                            Case "04"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(10, (j - 17)).Value))
                            Case "05"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(11, (j - 17)).Value))
                            Case "06"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(12, (j - 17)).Value))
                            Case "07"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(13, (j - 17)).Value))
                            Case "08"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(14, (j - 17)).Value))
                            Case "09"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(15, (j - 17)).Value))
                            Case "10"
                                igv = Decimal.Parse(Decimal.Add(igv, dgw2.Item(16, (j - 17)).Value))
                        End Select
                    Case "R"
                        Select Case NRO_ORDEN
                            Case "01"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(7, (j - 17)).Value))
                            Case "02"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(8, (j - 17)).Value))
                            Case "03"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(9, (j - 17)).Value))
                            Case "04"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(10, (j - 17)).Value))
                            Case "05"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(11, (j - 17)).Value))
                            Case "06"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(12, (j - 17)).Value))
                            Case "07"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(13, (j - 17)).Value))
                            Case "08"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(14, (j - 17)).Value))
                            Case "09"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(15, (j - 17)).Value))
                            Case "10"
                                renta = Decimal.Parse(Decimal.Add(renta, dgw2.Item(16, (j - 17)).Value))
                        End Select
                End Select
                i += 1
            Loop
            dgw2.Item(17, (j - 17)).Value = bi
            dgw2.Item(18, (j - 17)).Value = igv
            dgw2.Item(19, (j - 17)).Value = renta
            j += 1
        Loop
    End Sub
    Sub hallar_calculo_compras()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONFIG_PROV3", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "C"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_calculo_HONORARIOs()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONFIG_PROV3", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "H"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_calculo_ventas()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONFIG_PROV3", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "V"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_compras()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PROV3_COMPRAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = MES00
            PROG_01.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES01
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@ST_PER", SqlDbType.Char).Value = ST_PER
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), _
                Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), _
                Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), _
                Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), 0, 0, 0, Rs3.GetValue(17), Rs3.GetValue(18), _
                Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_honorarios()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PROV3_HONORARIOS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = MES00
            PROG_01.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES01
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@ST_PER", SqlDbType.Char).Value = ST_PER
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), 0, 0, 0, Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_ventas()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PROV3_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = MES00
            PROG_01.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES01
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@ST_PER", SqlDbType.Char).Value = ST_PER
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), 0, 0, 0, Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21))
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
        Dim CONT As Integer = (dgw2.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            REP1.llenar_dt(dgw2.Item(0, I).Value.ToString, dgw2.Item(1, I).Value.ToString, _
            dgw2.Item(2, I).Value.ToString, dgw2.Item(3, I).Value.ToString, dgw2.Item(4, I).Value.ToString, _
            dgw2.Item(5, I).Value.ToString, dgw2.Item(6, I).Value.ToString, Decimal.Parse((dgw2.Item(17, I).Value)), _
            Decimal.Parse((dgw2.Item(18, I).Value)), Decimal.Parse((dgw2.Item(19, I).Value)), _
            Decimal.Parse((dgw2.Item(20, I).Value)), dgw2.Item(21, I).Value, dgw2.Item(22, I).Value, _
            dgw2.Item(23, I).Value, dgw2.Item(24, I).Value, dgw2.Item(25, I).Value)
            I += 1
        Loop
    End Sub
    Sub resolver()
        Dim monto As New Decimal
        Dim i As Integer = 0
        Dim cont As Integer = (dgw2.Rows.Count - 1)
        Dim CONT0 As Integer = cont
        Dim k As Integer = 0
        Do While (k <= CONT0)
            i = 13
            Do
                If dgw2.Item(i, k).Value.ToString = "" Then
                    dgw2.Item((i + 8), k).Value = "0.00"
                Else
                    Dim formula As String = (dgw2.Item(i, k).Value)
                    Try
                        Dim CMD As New SqlCommand(("SELECT " & formula), con)
                        con.Open()
                        monto = Decimal.Parse(CMD.ExecuteScalar)
                        con.Close()
                    Catch ex As Exception
                        dgw2.Item((i + 8), k).Value = "0.00"
                    End Try
                    dgw2.Item((i + 8), k).Value = monto
                End If
                i += 1
            Loop While (i <= 20)
            k += 1
        Loop
    End Sub
    Private Sub REPORTE_PROV3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_PROV3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_AÑO()
        'PERSONAS()
        cbo_año.Text = AÑO
    End Sub
    Sub PERSONAS()
        Try
            dgw_per.DataSource = OBJ.MOSTRAR_PERSONAS_PAGAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Sub PERSONAS_ventas()
        Try
            dgw_per.DataSource = OBJ.MOSTRAR_PERSONAS_COBRAR

            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
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
    Private Sub txt_cod_per_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per.LostFocus
        If (Strings.Trim(txt_cod_per.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        Return
                    End If
                    If (txt_cod_per.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla pendientes por cobrar", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per.Text = (dgw_per.Item(0, dgw_per.CurrentRow.Index).Value)
            txt_desc_per.Text = (dgw_per.Item(1, dgw_per.CurrentRow.Index).Value)
            txt_doc_per.Text = (dgw_per.Item(2, dgw_per.CurrentRow.Index).Value)
            Panel_per.Visible = False
            'btn_pantalla1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            Panel_per.Visible = False
            txt_cod_per.Focus()
        End If
    End Sub
    Private Sub ch_per1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked = True Then
            txt_cod_per.Enabled = True
            txt_desc_per.Enabled = True
            txt_doc_per.Enabled = True
        Else
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per.Enabled = False
            txt_desc_per.Enabled = False
            txt_doc_per.Enabled = False
        End If
    End Sub

    Private Sub cbo_prov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_prov.SelectedIndexChanged
        If cbo_prov.SelectedIndex = 0 Or cbo_prov.SelectedIndex = 2 Then
            PERSONAS()
        ElseIf cbo_prov.SelectedIndex = 1 Then
            PERSONAS_ventas()
        End If
    End Sub

    Private Sub txt_doc_per_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_doc_per.TextChanged

    End Sub
End Class