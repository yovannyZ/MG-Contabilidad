Imports System.Data.SqlClient
Public Class CONSULTA_IBANCO_TIPO
    Dim COD_AUX, variable, mes6, COD_COMP, mes_t, mes_i, mes_e, CUENTA_IGV, CUENTA_TOTAL, cod_moneda As String
    Dim OBJ As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(18) = 0
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
        TabControl1.SelectedTab = (TabPage4)
        cbo_mes3.Text = cbo_mes_i.Text
        cbo_año3.Text = cbo_año_i.Text
        'TextBox1.Text = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString) & " " & (dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString)
        CARGAR_CPTO_DEFECTO_INGRESO()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
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
        CARGAR_CPTO_DEFECTO_EGRESO()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año_i.Items.Clear()
        cbo_año_e.Items.Clear()
        cbo_año_t.Items.Clear()
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
                cbo_año_t.Items.Add(Rs3.GetString(0))
                cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS_COMPROBANTE", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban2.DataSource = dt
            dgw_ban3.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            dgw_ban2.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            dgw_ban3.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            dgw_ban.Columns.Item(2).Visible = False
            dgw_ban2.Columns.Item(2).Visible = False
            dgw_ban3.Columns.Item(2).Visible = False
            dgw_ban.Columns.Item(3).Visible = False
            dgw_ban2.Columns.Item(3).Visible = False
            dgw_ban3.Columns.Item(3).Visible = False
            dgw_ban.Columns.Item(0).Width = &H37
            dgw_ban2.Columns.Item(0).Width = &H37
            dgw_ban3.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_BANCOS_CABECERA_EGRESO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_I_BANCO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_e.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_e
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban2.Text
            CMD.Parameters.Add("@TIPO_OPERACION", SqlDbType.Char).Value = "E"
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw3.DataSource = (DT)
            dgw3.Columns.Item(0).Width = 36
            dgw3.Columns.Item(1).Width = &H2D
            dgw3.Columns.Item(3).Width = 30
            dgw3.Columns.Item(2).Width = 70
            dgw3.Columns.Item(4).Width = &H2D
            dgw3.Columns.Item(5).Width = 60
            dgw3.Columns.Item(6).Width = 180
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
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_I_BANCO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_i.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_i
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            CMD.Parameters.Add("@TIPO_OPERACION", SqlDbType.Char).Value = "I"
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = (DT)
            dgw1.Columns.Item(0).Width = 36
            dgw1.Columns.Item(1).Width = &H2D
            dgw1.Columns.Item(3).Width = 30
            dgw1.Columns.Item(2).Width = 70
            dgw1.Columns.Item(4).Width = &H2D
            dgw1.Columns.Item(5).Width = 60
            dgw1.Columns.Item(6).Width = 180
            dgw1.Columns.Item(7).Width = 70
            dgw1.Columns.Item(8).Width = 70
            dgw1.Columns.Item(9).Width = 40
            dgw1.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw1.Columns.Item(7).DefaultCellStyle.Alignment = &H400
            dgw1.Columns.Item(8).DefaultCellStyle.Alignment = &H400
            dgw1.Columns.Item(2).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONTABLE2()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw7.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CPTO()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CPTO_TBANCO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
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
    Sub CARGAR_CPTO_DEFECTO_EGRESO()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CPTO_TBANCO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = dgw4.Item(0, dgw4.CurrentRow.Index).Value.ToString
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
        End Try
    End Sub
    Sub CARGAR_CPTO_DEFECTO_INGRESO()
        dgw7.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CPTO_TBANCO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
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
    Sub CARGAR_HABER_BANCOS()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_I_BANCO_DH", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_t.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_t
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban3.Text
            CMD.Parameters.Add("@TIPO_OPERACION", SqlDbType.Char).Value = "T"
            CMD.Parameters.Add("@COD_DH", SqlDbType.Char).Value = "H"
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw5.DataSource = (DT)
            dgw5.Columns.Item(0).Width = 36
            dgw5.Columns.Item(1).Width = &H2D
            dgw5.Columns.Item(3).Width = 30
            dgw5.Columns.Item(2).Width = 70
            dgw5.Columns.Item(4).Width = &H2D
            dgw5.Columns.Item(5).Width = 60
            dgw5.Columns.Item(6).Width = 180
            dgw5.Columns.Item(7).Width = 70
            dgw5.Columns.Item(8).Width = 70
            dgw5.Columns.Item(9).Width = 40
            dgw5.Columns.Item(11).Width = 35
            dgw5.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw5.Columns.Item(7).DefaultCellStyle.Alignment = &H400
            dgw5.Columns.Item(8).DefaultCellStyle.Alignment = &H400
            dgw5.Columns.Item(2).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub cargar_monedas()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_TIPO.DataSource = DT
        cbo_TIPO2.DataSource = DT
        cbo_TIPO3.DataSource = DT
        cbo_TIPO.DisplayMember = DT.Columns.Item(0).ToString
        cbo_TIPO2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_TIPO3.DisplayMember = DT.Columns.Item(0).ToString
        cbo_TIPO.ValueMember = DT.Columns.Item(1).ToString
        cbo_TIPO.SelectedIndex = -1
        cbo_TIPO2.ValueMember = DT.Columns.Item(1).ToString
        cbo_TIPO2.SelectedIndex = -1
        cbo_TIPO3.ValueMember = DT.Columns.Item(1).ToString
        cbo_TIPO2.SelectedIndex = -1
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_i.SelectedIndexChanged
        If txt_cod_ban.Text = "" Then
            MessageBox.Show("Debe ingresar el banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf (cbo_año_i.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año_i.Focus()
        Else
            mes_i = OBJ.COD_MES(cbo_mes_i.Text)
            dgw2.Columns.Clear()
            CARGAR_BANCOS_CABECERA_INGRESO()
        End If
    End Sub
    Private Sub cbo_mes_t_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_t.SelectedIndexChanged
        If txt_cod_ban3.Text = "" Then
            MessageBox.Show("Debe ingresar el banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban3.Focus()
        ElseIf cbo_año_t.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año_t.Focus()
        Else
            mes_t = OBJ.COD_MES(cbo_mes_t.Text)
            dgw6.Columns.Clear()
            CARGAR_HABER_BANCOS()
        End If
    End Sub
    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_e.SelectedIndexChanged
        mes_e = (OBJ.COD_MES(cbo_mes_e.Text))
        dgw4.Columns.Clear()
        CARGAR_BANCOS_CABECERA_EGRESO()
    End Sub
    Private Sub cbo_mes3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes3.SelectedIndexChanged
        If cbo_mes3.SelectedIndex <> -1 And cbo_año3.SelectedIndex <> -1 Then
            If variable = "I" Then
                CARGAR_CPTO_DEFECTO_INGRESO()
            Else
                CARGAR_CPTO_DEFECTO_EGRESO()
            End If
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            cbo_TIPO.SelectedValue = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            txt_cod_ban2.Text = txt_cod_ban.Text
            txt_desc_ban2.Text = txt_desc_ban.Text
            txt_cod_ban3.Text = txt_cod_ban.Text
            txt_desc_ban3.Text = txt_desc_ban.Text
            panel_bancos.Visible = False
            KL1.Focus()
        End If
    End Sub
    Private Sub dgw_ban2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban2.Text = dgw_ban2.Item(0, dgw_ban2.CurrentRow.Index).Value.ToString
            txt_desc_ban2.Text = dgw_ban2.Item(1, dgw_ban2.CurrentRow.Index).Value.ToString
            cbo_TIPO2.SelectedValue = dgw_ban2.Item(2, dgw_ban2.CurrentRow.Index).Value.ToString
            panel_bancos2.Visible = False
        End If
    End Sub
    Private Sub dgw_ban3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban3.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban3.Text = dgw_ban3.Item(0, dgw_ban3.CurrentRow.Index).Value.ToString
            txt_desc_ban3.Text = dgw_ban3.Item(1, dgw_ban3.CurrentRow.Index).Value.ToString
            cbo_TIPO3.SelectedValue = dgw_ban3.Item(2, dgw_ban3.CurrentRow.Index).Value.ToString
            panel_bancos3.Visible = False
        End If
    End Sub
    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw1.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
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
        If ((dgw3.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            T_BANCO_EGRESO()
        End If
    End Sub
    Private Sub dgw5_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw5.CellEnter
        Try
            Dim i As Integer = dgw5.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw5.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            I_BANCO_DEBE()
        End If
    End Sub
    Sub I_BANCO_DEBE()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_I_BANCO_HABER", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_t.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes_t.Text)
            CMD.Parameters.Add("@TIPO_OPERACION", SqlDbType.Char).Value = "T"
            CMD.Parameters.Add("@COD_DH", SqlDbType.Char).Value = "D"
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = dgw5.Item(1, dgw5.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = dgw5.Item(0, dgw5.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw6.DataSource = (DT)
            dgw6.Columns.Item(0).Width = 36
            dgw6.Columns.Item(1).Width = &H2D
            dgw6.Columns.Item(3).Width = 30
            dgw6.Columns.Item(2).Width = 70
            dgw6.Columns.Item(4).Width = &H2D
            dgw6.Columns.Item(5).Width = 60
            dgw6.Columns.Item(6).Width = 180
            dgw6.Columns.Item(7).Width = 70
            dgw6.Columns.Item(8).Width = 70
            dgw6.Columns.Item(9).Width = 40
            dgw6.Columns.Item(11).Width = 35
            dgw6.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw6.Columns.Item(7).DefaultCellStyle.Alignment = &H400
            dgw6.Columns.Item(8).DefaultCellStyle.Alignment = &H400
            dgw6.Columns.Item(2).DefaultCellStyle.Format = "d"
            dgw6.Columns.Item(12).Width = 40
            dgw6.Columns.Item(13).Width = 200
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub limpiar()
        cbo_mes_i.SelectedIndex = -1
        cbo_mes_e.SelectedIndex = -1
        cbo_mes_t.SelectedIndex = -1
        cbo_TIPO.SelectedIndex = -1
        cbo_TIPO2.SelectedIndex = -1
        cbo_TIPO3.SelectedIndex = -1
        panel_bancos.Visible = False
        panel_bancos2.Visible = False
        panel_bancos3.Visible = False
    End Sub
    Sub T_BANCO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_T_BANCO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_i.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes_i
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
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
            dgw2.Columns.Item(6).DefaultCellStyle.Format = ("d")
            dgw2.Columns.Item(2).DefaultCellStyle.Format = ("N2")
            dgw2.Columns.Item(2).DefaultCellStyle.Alignment = (&H40)
            dgw2.Columns.Item(3).DefaultCellStyle.Alignment = (32)
            dgw2.Columns.Item(8).DefaultCellStyle.Alignment = (32)
        Catch ex As Exception
            MsgBox(ex.Message)

            'MsgBox(ex.Message)

        End Try
    End Sub
    Sub T_BANCO_EGRESO()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_CONSULTA_T_BANCO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = (cbo_año_e.Text)
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (mes_e)
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = (dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString)
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = (txt_cod_ban2.Text)
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = (dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString)
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw4.DataSource = (DT)
            dgw4.Columns.Item(0).Width = (50)
            dgw4.Columns.Item(1).Width = (180)
            dgw4.Columns.Item(2).Width = (70)
            dgw4.Columns.Item(3).Width = (30)
            dgw4.Columns.Item(4).Width = (30)
            dgw4.Columns.Item(5).Width = (60)
            dgw4.Columns.Item(6).Width = (70)
            dgw4.Columns.Item(7).Width = (35)
            dgw4.Columns.Item(8).Width = (50)
            dgw4.Columns.Item(9).Width = (40)
            dgw4.Columns.Item(10).Width = (180)
            dgw4.Columns.Item(6).DefaultCellStyle.Format = ("d")
            dgw4.Columns.Item(2).DefaultCellStyle.Format = ("N2")
            dgw4.Columns.Item(2).DefaultCellStyle.Alignment = (&H40)
            dgw4.Columns.Item(3).DefaultCellStyle.Alignment = (32)
            dgw4.Columns.Item(8).DefaultCellStyle.Alignment = (32)
        Catch ex As Exception
            MsgBox(ex.Message)

            'MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban.RowCount - 1))
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        cbo_TIPO.SelectedValue = dgw_ban.Item(2, i).Value.ToString
                        cbo_año_i.Select()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod_ban2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban2.LostFocus
        If (Strings.Trim(txt_cod_ban2.Text) <> "") Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_ban2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban2.RowCount - 1))
                    If (txt_cod_ban2.Text.ToLower = dgw_ban2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban2.Text = dgw_ban2.Item(0, i).Value.ToString
                        txt_desc_ban2.Text = dgw_ban2.Item(1, i).Value.ToString
                        cbo_TIPO2.SelectedValue = dgw_ban2.Item(2, i).Value.ToString
                        cbo_año_e.Select()
                        Return
                    End If
                    If (txt_cod_ban2.Text.ToLower = Strings.Mid((dgw_ban2.Item(0, i).Value), 1, Strings.Len(txt_cod_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                panel_bancos2.Visible = True
                dgw_ban2.Visible = True
                dgw_ban2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod_ban3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban3.LostFocus
        If (Strings.Trim(txt_cod_ban3.Text) <> "") Then
            If (dgw_ban3.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban3.Sort(dgw_ban3.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_ban3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban3.RowCount - 1))
                    If (txt_cod_ban3.Text.ToLower = dgw_ban3.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban3.Text = dgw_ban3.Item(0, i).Value.ToString
                        txt_desc_ban3.Text = dgw_ban3.Item(1, i).Value.ToString
                        cbo_TIPO3.SelectedValue = dgw_ban3.Item(2, i).Value.ToString
                        cbo_año_t.Select()
                        Return
                    End If
                    If (txt_cod_ban3.Text.ToLower = Strings.Mid((dgw_ban3.Item(0, i).Value), 1, Strings.Len(txt_cod_ban3.Text)).ToLower) Then
                        dgw_ban3.CurrentCell = (dgw_ban3.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban3.CurrentCell = (dgw_ban3.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                panel_bancos3.Visible = True
                dgw_ban3.Visible = True
                dgw_ban3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban.RowCount - 1))
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban2.Text) <> "")) Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_ban2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban2.RowCount - 1))
                    If (txt_desc_ban2.Text.ToLower = Strings.Mid((dgw_ban2.Item(1, i).Value), 1, Strings.Len(txt_desc_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                panel_bancos2.Visible = True
                dgw_ban2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban3.Text) <> "")) Then
            If (dgw_ban3.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban3.Sort(dgw_ban3.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_ban3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban3.RowCount - 1))
                    If (txt_desc_ban3.Text.ToLower = Strings.Mid((dgw_ban3.Item(1, i).Value), 1, Strings.Len(txt_desc_ban3.Text)).ToLower) Then
                        dgw_ban3.CurrentCell = (dgw_ban3.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban3.CurrentCell = (dgw_ban3.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                panel_bancos3.Visible = True
                dgw_ban3.Focus()
            End If
        End If
    End Sub
    Private Sub CONSULTA_IBANCO_TIPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(31) = 0
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
        dgw5.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw6.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw7.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        cbo_año_i.Text = AÑO
        cbo_año_e.Text = AÑO
        cbo_año_t.Text = AÑO
        cbo_año3.Text = AÑO
        CARGAR_AÑO()
        limpiar()
        CARGAR_BANCOS()
        cargar_monedas()
        txt_cod_ban.Focus()
    End Sub



    Private Sub cbo_año3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año3.SelectedIndexChanged
        If cbo_mes3.SelectedIndex <> -1 And cbo_año3.SelectedIndex <> -1 Then
            If variable = "I" Then
                CARGAR_CPTO_DEFECTO_INGRESO()
            Else
                CARGAR_CPTO_DEFECTO_EGRESO()
            End If
        End If
    End Sub
End Class