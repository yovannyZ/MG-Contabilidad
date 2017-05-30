Imports System.Data.SqlClient
Public Class CONSULTA_CPTOS
    Dim C As Boolean
    Dim COD_AUX, mes6, mes_t, mes_i, variable, COD_COMP, cod_moneda, CUENTA_IGV, CUENTA_TOTAL, mes_e As String
    Dim OBJ As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(8) = 0
        Close()
    End Sub
    Private Sub btn_consulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta.Click
        variable = "I"
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl1.SelectedTab = TabPage4
        cbo_mes3.Text = cbo_mes_i.Text
        cbo_año3.Text = cbo_año_i.Text
        TextBox1.Text = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString & " " & dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString
        CARGAR_CTA_DEFECTO_INGRESO()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
 Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        variable = "E"
        Try
            Dim i As Integer = dgw4.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl1.SelectedTab = TabPage4
        cbo_mes3.Text = cbo_mes_e.Text
        cbo_año3.Text = cbo_año_e.Text
        TextBox1.Text = dgw4.Item(0, dgw4.CurrentRow.Index).Value.ToString & " " & dgw4.Item(1, dgw4.CurrentRow.Index).Value.ToString
        CARGAR_CTA_DEFECTO_EGRESO()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año_i.Items.Clear()
        cbo_año_e.Items.Clear()
        cbo_año3.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año_i.Items.Add(Rs3.GetString(0))
                cbo_año_e.Items.Add(Rs3.GetString(0))
                cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONCEPTOS()
        dgw_cpto1.DataSource = OBJ.MOSTRAR_CONCEPTOS_STATUS("I")
        dgw_cpto1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_cpto1.Columns(2).Visible = False
        dgw_cpto1.Columns(3).Visible = False
        dgw_cpto1.Columns(4).Visible = False
        dgw_cpto1.Columns(0).Width = 50
        '-----------------------------------------------------
        dgw_cpto2.DataSource = OBJ.MOSTRAR_CONCEPTOS_STATUS("E")
        dgw_cpto2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_cpto2.Columns(2).Visible = False
        dgw_cpto2.Columns(3).Visible = False
        dgw_cpto2.Columns(4).Visible = False
        dgw_cpto2.Columns(0).Width = 50
    End Sub
    Sub CARGAR_BANCOS_CABECERA_EGRESO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_I_BANCO2", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_e.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_e
            CMD.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod2.Text
            CMD.Parameters.Add("@TIPO_OPERACION", SqlDbType.Char).Value = "E"
            CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cbo_TIPO2.SelectedValue.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw3.DataSource = (DT)
            dgw3.Columns.Item(0).Width = 36
            dgw3.Columns.Item(1).Width = 80
            dgw3.Columns.Item(3).Width = 30
            dgw3.Columns.Item(2).Width = 70
            dgw3.Columns.Item(4).Width = &H2D
            dgw3.Columns.Item(5).Width = 60
            dgw3.Columns.Item(6).Visible = False
            dgw3.Columns.Item(11).Visible = False
            dgw3.Columns.Item(7).Width = 70
            dgw3.Columns.Item(8).Width = 70
            dgw3.Columns.Item(9).Width = 40
            dgw3.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw3.Columns.Item(7).DefaultCellStyle.Alignment = &H400
            dgw3.Columns.Item(8).DefaultCellStyle.Alignment = &H400
            dgw3.Columns.Item(2).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_BANCOS_CABECERA_INGRESO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_I_BANCO2", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_i.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_i
            CMD.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod1.Text
            CMD.Parameters.Add("@TIPO_OPERACION", SqlDbType.Char).Value = "I"
            CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cbo_TIPO.SelectedValue.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = (DT)
            dgw1.Columns.Item(0).Width = 36
            dgw1.Columns.Item(1).Width = 80
            dgw1.Columns.Item(3).Width = 30
            dgw1.Columns.Item(2).Width = 70
            dgw1.Columns.Item(4).Width = &H2D
            dgw1.Columns.Item(5).Width = 60
            dgw1.Columns.Item(6).Width = 180
            dgw1.Columns.Item(7).Width = 70
            dgw1.Columns.Item(8).Width = 70
            dgw1.Columns.Item(9).Width = 40
            dgw1.Columns.Item(11).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw1.Columns.Item(7).DefaultCellStyle.Alignment = &H400
            dgw1.Columns.Item(8).DefaultCellStyle.Alignment = &H400
            dgw1.Columns.Item(2).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Sub CARGAR_CONTABLE2()
    '    dgw7.Rows.Clear()
    '    Try
    '        Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE", con)
    '        pro_02.CommandType = (CommandType.StoredProcedure)
    '        pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
    '        pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (OBJ.COD_MES(cbo_mes3.Text))
    '        pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
    '        con.Open()
    '        pro_02.ExecuteNonQuery()
    '        Dim rs2 As SqlDataReader = pro_02.ExecuteReader
    '        Do While rs2.Read
    '            dgw7.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)))
    '        Loop
    '        con.Close()
    '    Catch ex As Exception
    '        con.Close()
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Sub CARGAR_CTA()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CTA_TBANCO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@TIPO", SqlDbType.Char).Value = "I"
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw7.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CTA_DEFECTO_EGRESO()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CTA_TBANCO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw4.Item(0, dgw4.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@TIPO", SqlDbType.Char).Value = "E"
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw7.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CTA_DEFECTO_INGRESO()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CTA_TBANCO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@TIPO", SqlDbType.Char).Value = "I"
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw7.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cargar_monedas()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_TIPO.DataSource = DT
        cbo_TIPO2.DataSource = DT
        cbo_TIPO.DisplayMember = DT.Columns.Item(0).ToString
        cbo_TIPO2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_TIPO.ValueMember = DT.Columns.Item(1).ToString
        cbo_TIPO.SelectedIndex = -1
        cbo_TIPO2.ValueMember = DT.Columns.Item(1).ToString
        cbo_TIPO2.SelectedIndex = -1
        cbo_TIPO2.SelectedIndex = -1
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_i.SelectedIndexChanged
        If txt_cod1.Text = "" Then MessageBox.Show("Debe ingresar el banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod1.Focus() : Exit Sub
        If cbo_año_i.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año_i.Focus() : Exit Sub
        If cbo_TIPO.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_TIPO.Focus() : Exit Sub
        mes_i = OBJ.COD_MES(cbo_mes_i.Text)
        dgw2.Columns.Clear()
        CARGAR_BANCOS_CABECERA_INGRESO()
    End Sub
    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_e.SelectedIndexChanged
        If txt_cod2.Text = "" Then MessageBox.Show("Debe ingresar el banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod2.Focus() : Exit Sub
        If cbo_año_e.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año_e.Focus() : Exit Sub
        If cbo_TIPO2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_TIPO2.Focus() : Exit Sub
        mes_e = OBJ.COD_MES(cbo_mes_e.Text)
        dgw4.Columns.Clear()
        CARGAR_BANCOS_CABECERA_EGRESO()
    End Sub
    Private Sub cbo_mes3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes3.SelectedIndexChanged
        If cbo_mes3.SelectedIndex <> -1 And cbo_año3.SelectedIndex <> -1 Then
            If variable = "I" Then
                CARGAR_CTA_DEFECTO_INGRESO()
            Else
                CARGAR_CTA_DEFECTO_EGRESO()
            End If
        End If
    End Sub
    Private Sub dgw_cpto1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cpto1.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod1.Text = dgw_cpto1.Item(0, dgw_cpto1.CurrentRow.Index).Value.ToString
            txt_desc1.Text = dgw_cpto1.Item(1, dgw_cpto1.CurrentRow.Index).Value.ToString
            panel_cpto1.Visible = False
            KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cpto1.Visible = False
            txt_cod1.Clear()
            txt_desc1.Clear()
            txt_cod1.Focus()
        End If
    End Sub
    Private Sub dgw_ban2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cpto2.KeyDown
        'If (e.KeyData = Keys.Return) Then
        '    txt_cod2.Text = dgw_cpto2.Item(0, dgw_cpto2.CurrentRow.Index).Value.ToString
        '    txt_desc2.Text = dgw_cpto2.Item(1, dgw_cpto2.CurrentRow.Index).Value.ToString
        '    cbo_TIPO2.SelectedValue = dgw_cpto2.Item(2, dgw_cpto2.CurrentRow.Index).Value.ToString
        '    panel_cpto2.Visible = False
        'End If
        If (e.KeyData = Keys.Return) Then
            txt_cod2.Text = dgw_cpto2.Item(0, dgw_cpto2.CurrentRow.Index).Value.ToString
            txt_desc2.Text = dgw_cpto2.Item(1, dgw_cpto2.CurrentRow.Index).Value.ToString
            panel_cpto2.Visible = False
            TextBox3.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cpto2.Visible = False
            txt_cod2.Clear()
            txt_desc2.Clear()
            txt_cod2.Focus()
        End If
    End Sub
    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (dgw1.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            T_BANCO()
        End If
    End Sub
    Private Sub dgw3_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw3.CellEnter
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (dgw3.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            T_BANCO_EGRESO()
        End If
    End Sub
    Sub limpiar()
        cbo_mes_i.SelectedIndex = -1
        cbo_mes_e.SelectedIndex = -1
        cbo_TIPO.SelectedIndex = -1
        cbo_TIPO2.SelectedIndex = -1
        panel_cpto1.Visible = False
        panel_cpto2.Visible = False
    End Sub
    Sub T_BANCO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_T_BANCO2", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_i.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_i
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(11, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw2.DataSource = (DT)
            dgw2.Columns.Item(0).Width = 50
            dgw2.Columns.Item(1).Width = 180
            dgw2.Columns.Item(2).Width = 70
            dgw2.Columns.Item(3).Width = 30
            dgw2.Columns.Item(4).Width = 30
            dgw2.Columns.Item(5).Width = 60
            dgw2.Columns.Item(6).Width = 70
            dgw2.Columns.Item(7).Width = 35
            dgw2.Columns.Item(8).Width = 50
            dgw2.Columns.Item(9).Width = 40
            dgw2.Columns.Item(10).Width = 180
            dgw2.Columns.Item(6).DefaultCellStyle.Format = "d"
            dgw2.Columns.Item(2).DefaultCellStyle.Format = "N2"
            dgw2.Columns.Item(2).DefaultCellStyle.Alignment = &H40
            dgw2.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub T_BANCO_EGRESO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_T_BANCO2", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            'CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = (cbo_año_e.Text)
            'CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (mes_e)
            'CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = (dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString)
            'CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = (txt_cod2.Text)
            'CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = (dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_e.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_e
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw3.Item(11, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw4.DataSource = (DT)
            dgw4.Columns.Item(0).Width = 50
            dgw4.Columns.Item(1).Width = 180
            dgw4.Columns.Item(2).Width = 70
            dgw4.Columns.Item(3).Width = 30
            dgw4.Columns.Item(4).Width = 30
            dgw4.Columns.Item(5).Width = 60
            dgw4.Columns.Item(6).Width = 70
            dgw4.Columns.Item(7).Width = 35
            dgw4.Columns.Item(8).Width = 50
            dgw4.Columns.Item(9).Width = 40
            dgw4.Columns.Item(10).Width = 180
            dgw4.Columns.Item(6).DefaultCellStyle.Format = "d"
            dgw4.Columns.Item(2).DefaultCellStyle.Format = "N2"
            dgw4.Columns.Item(2).DefaultCellStyle.Alignment = &H40
            dgw4.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw4.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cod1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod1.LostFocus
        If (Strings.Trim(txt_cod1.Text) <> "") Then
            If (dgw_cpto1.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cpto1.Sort(dgw_cpto1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT00 As Integer = (dgw_cpto1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT00)
                    If (txt_cod1.Text.ToLower = dgw_cpto1.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod1.Text = dgw_cpto1.Item(0, i).Value.ToString
                        txt_desc1.Text = dgw_cpto1.Item(1, i).Value.ToString
                        cbo_TIPO.Focus()
                        Return
                    End If
                    If (txt_cod1.Text.ToLower = Strings.Mid((dgw_cpto1.Item(0, i).Value), 1, Strings.Len(txt_cod1.Text)).ToLower) Then
                        dgw_cpto1.CurrentCell = dgw_cpto1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cpto1.CurrentCell = dgw_cpto1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cpto1.Visible = True
                dgw_cpto1.Visible = True
                dgw_cpto1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod2.LostFocus
        If (Strings.Trim(txt_cod2.Text) <> "") Then
            If (dgw_cpto2.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cpto2.Sort(dgw_cpto2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT00 As Integer = (dgw_cpto2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT00)
                    If (txt_cod2.Text.ToLower = dgw_cpto2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod2.Text = dgw_cpto2.Item(0, i).Value.ToString
                        txt_desc2.Text = dgw_cpto2.Item(1, i).Value.ToString
                        cbo_TIPO2.Focus()
                        Return
                    End If
                    If (txt_cod2.Text.ToLower = Strings.Mid((dgw_cpto2.Item(0, i).Value), 1, Strings.Len(txt_cod2.Text)).ToLower) Then
                        dgw_cpto2.CurrentCell = dgw_cpto2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cpto2.CurrentCell = dgw_cpto2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cpto2.Visible = True
                dgw_cpto2.Visible = True
                dgw_cpto2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc1.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc1.Text) <> "")) Then
            If (dgw_cpto1.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cpto1.Sort(dgw_cpto1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT00 As Integer = (dgw_cpto1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT00)
                    If (txt_desc1.Text.ToLower = Strings.Mid((dgw_cpto1.Item(1, i).Value), 1, Strings.Len(txt_desc1.Text)).ToLower) Then
                        dgw_cpto1.CurrentCell = dgw_cpto1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cpto1.CurrentCell = dgw_cpto1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cpto1.Visible = True
                dgw_cpto1.Visible = True
                dgw_cpto1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc2.Text) <> "")) Then
            If (dgw_cpto2.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cpto2.Sort(dgw_cpto2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT00 As Integer = (dgw_cpto2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT00)
                    If (txt_desc2.Text.ToLower = Strings.Mid((dgw_cpto2.Item(1, i).Value), 1, Strings.Len(txt_desc2.Text)).ToLower) Then
                        dgw_cpto2.CurrentCell = dgw_cpto2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cpto2.CurrentCell = dgw_cpto2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cpto2.Visible = True
                dgw_cpto2.Visible = True
                dgw_cpto2.Focus()
            End If
        End If
    End Sub
    Private Sub CONSULTA_IBANCO_TIPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(60) = 0
    End Sub
    Private Sub CONSULTA_IBANCO_TIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub CONSULTA_IBANCO_TIPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        variable = ""
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw4.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw7.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        cbo_año_i.Text = AÑO
        cbo_año_e.Text = AÑO
        cbo_año3.Text = AÑO
        CARGAR_AÑO()
        limpiar()
        CARGAR_CONCEPTOS()
        cargar_monedas()
        txt_cod1.Focus()
    End Sub
    Private Sub cbo_año3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año3.SelectedIndexChanged
        If cbo_mes3.SelectedIndex <> -1 And cbo_año3.SelectedIndex <> -1 Then
            If variable = "I" Then
                CARGAR_CTA_DEFECTO_INGRESO()
            Else
                CARGAR_CTA_DEFECTO_EGRESO()
            End If
        End If
    End Sub

    Private Sub dgw1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellContentClick

    End Sub
End Class