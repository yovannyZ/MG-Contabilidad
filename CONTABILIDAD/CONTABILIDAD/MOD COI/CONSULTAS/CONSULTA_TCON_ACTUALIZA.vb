Imports System.Data.SqlClient
Public Class CONSULTA_TCON_ACTUALIZA
    Dim COD_ACT, ST_COMP, ST_AUX, NRO_COMP0, ITEM0, COD_COMP0, COD_REF, COD_PROY, COD_MES, COD_AUX, COD_AUX0, COD_CC, COD_COMP, COD_CONT As String
    Dim INDICE As Integer
    Dim con00 As New SqlConnection(("data source=" & nombre_servidor & ";initial catalog=BD_COS" & COD_EMPRESA & ";uid=miguel;pwd=main;"))
    Dim OBJ As New Class1
    Dim ofr As New CONSULTA_REQ_ORD_PROD
    Private _fec As Date
    Sub boton3()
        ofr.con0 = con00
        ofr._fecha = _fec
        ofr.CARGAR_ORD_PROD()
        ofr.ShowDialog()
        If (ofr.DialogResult = Windows.Forms.DialogResult.OK) Then
            txt_nro_req2.Text = ofr.DGW_CAB.Item(0, ofr.DGW_CAB.CurrentRow.Index).Value.ToString
            Try
                COD_ACT = ofr.DGW_DET.Item(0, ofr.DGW_DET.CurrentRow.Index).Value.ToString
            Catch ex As Exception
                COD_ACT = ""
            End Try
            cbo_act02.SelectedIndex = -1
            cbo_act02.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
            ofr.Hide()
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar2.Click
        main(36) = 0
        Close()
    End Sub
    Private Sub btn_consulta1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta2.Click
        If (CH_AUX2.Checked And (cbo_auxiliar2.SelectedIndex = -1)) Then MessageBox.Show("Debe elegir la Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_auxiliar2.Focus() : Exit Sub
        If (ch_com2.Checked And (cbo_comprobante2.SelectedIndex = -1)) Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_comprobante2.Focus() : Exit Sub
        If txt_cta.Text.Trim = "" Then MessageBox.Show("Debe elgir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub
        COD_MES = OBJ.COD_MES(cbo_mes2.Text)
        ST_AUX = "1"
        ST_COMP = "1"
        COD_AUX = ""
        COD_COMP = ""
        If CH_AUX2.Checked Then
            ST_AUX = "0"
            COD_AUX = cbo_auxiliar2.SelectedValue.ToString
        End If
        If ch_com2.Checked Then
            ST_COMP = "0"
            COD_COMP = cbo_comprobante2.SelectedValue.ToString
        End If
        MOSTRAR_CONSULTA()
        GroupBox2.Enabled = False
    End Sub
    Private Sub btn_lim_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_lim2.Click
        CBO_CC02.SelectedIndex = -1
        CBO_PROYECTO02.SelectedIndex = -1
        txt_nro_req2.Clear()
        cbo_act02.SelectedIndex = -1
        cbo_tipo_ref2.SelectedIndex = -1
        txt_nro_ref2.Clear()
    End Sub
    Private Sub BTN_LIMP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_LIMP2.Click
        CH_AUX2.Checked = False
        cbo_auxiliar2.SelectedIndex = -1
        ch_com2.Checked = False
        cbo_comprobante2.SelectedIndex = -1
        txt_cta.Clear()
        txt_desc_cta.Clear()
        dgw2.Rows.Clear()
        GroupBox2.Enabled = True
        txt_cta.Focus()
    End Sub
    Private Sub BTN_MOD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_MOD21.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elelgir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE = dgw2.CurrentRow.Index
        LIMPIAR_DET()
        If dgw2.Item(7, dgw2.CurrentRow.Index).Value = "D" Then
            CheckBox1.Visible = True
        Else
            CheckBox1.Visible = False
        End If
        _fec = dgw2.Item(8, INDICE).Value()
        CARGAR_DET()
        Panel2.Visible = True
        CBO_CC02.Focus()
    End Sub
    Private Sub btn_mod2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod22.Click
        COD_CC = "" : COD_PROY = "" : COD_CONT = "" : COD_ACT = "" : COD_REF = ""
        '-----------------------------------------------
        Dim ST_REP As String = "0"
        If ch_rep2.Checked = True Then ST_REP = "1"
        '-----------------------------------------------
        Dim ST_AUTO As String = "0"
        If ch_auto2.Checked = True Then ST_AUTO = "1"
        '-----------------------------------------------
        Dim ST_ANA As String = "0"
        If ch_ana2.Checked = True Then ST_ANA = "1"
        '-----------------------------------------------
        If (CBO_CC02.SelectedIndex <> -1) Then
            COD_CC = OBJ.COD_CC(CBO_CC02.Text)
        End If
        '-----------------------------------------------
        If (CBO_PROYECTO02.SelectedIndex <> -1) Then
            COD_PROY = OBJ.COD_PROYECTO(CBO_PROYECTO02.Text)
        End If
        '-----------------------------------------------
        COD_CONT = txt_nro_req2.Text
        If (cbo_act02.SelectedIndex <> -1) Then
            COD_ACT = cbo_act02.SelectedValue.ToString
        End If
        '-----------------------------------------------
        If (cbo_tipo_ref2.SelectedIndex <> -1) Then
            COD_REF = OBJ.COD_DOC(cbo_tipo_ref2.Text)
        End If
        '-----------------------------------------------------------
        Dim IMP1, IMP2, DIFERENCIA As Decimal
        IMP1 = txt_importe12.Text
        IMP2 = txt_importe22.Text
        DIFERENCIA = IMP1 - IMP2
        If DIFERENCIA > 0 Then
            DIFERENCIA = DIFERENCIA
        Else
            DIFERENCIA = DIFERENCIA * -1
        End If
        If DIFERENCIA > "0.03" Then
            MessageBox.Show("El importe sólo debe variar en el intervalo < -0.03 a 0.03 >", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub
            txt_importe22.Focus()
            Exit Sub
        End If
        ' --------------------------------------------------------
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_T_CON", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP0
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP0
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año2.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = COD_MES
            comand1.Parameters.Add("@ITEM", SqlDbType.VarChar).Value = ITEM0
            comand1.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = COD_CC
            comand1.Parameters.Add("@COD_CONTROL", SqlDbType.VarChar).Value = COD_CONT
            comand1.Parameters.Add("@COD_PROYECTO", SqlDbType.VarChar).Value = COD_PROY
            comand1.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = COD_ACT
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta02.Text
            comand1.Parameters.Add("@GLOSA", SqlDbType.VarChar).Value = TXT_GLOSA2.Text
            comand1.Parameters.Add("@STATUS_REP", SqlDbType.VarChar).Value = ST_REP
            comand1.Parameters.Add("@COD_REF", SqlDbType.Char).Value = COD_REF
            comand1.Parameters.Add("@NRO_REF", SqlDbType.VarChar).Value = txt_nro_ref2.Text
            comand1.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = dtp_ref2.Value
            comand1.Parameters.Add("@ST_AUTO", SqlDbType.VarChar).Value = ST_AUTO
            comand1.Parameters.Add("@ENLACE", SqlDbType.VarChar).Value = txt_enlace2.Text
            comand1.Parameters.Add("@DESTINO", SqlDbType.VarChar).Value = txt_destino2.Text
            comand1.Parameters.Add("@ST_ANA", SqlDbType.Char).Value = ST_ANA
            comand1.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = txt_importe22.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD2.Text
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw2.Item(15, dgw2.CurrentRow.Index).Value = COD_CC
        dgw2.Item(16, dgw2.CurrentRow.Index).Value = COD_CONT
        dgw2.Item(17, dgw2.CurrentRow.Index).Value = COD_PROY
        dgw2.Item(18, dgw2.CurrentRow.Index).Value = COD_ACT
        dgw2.Item(2, dgw2.CurrentRow.Index).Value = TXT_GLOSA2.Text
        MOSTRAR_CONSULTA()
        If dgw2.RowCount <> 0 Then
            FOCO_NUEVO_REG()
        Else
        End If
        Panel2.Visible = False
        BTN_MOD21.Focus()

    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw2.RowCount - 1
        Dim NRO_OC As String = NRO_DOC2.Text
        For I = 0 To CONT
            If NRO_OC = dgw2.Item(1, I).Value.ToString.ToLower Then
                dgw2.CurrentCell = (dgw2.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub btn_req_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_req2.Click
        boton3()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button22.Click
        Panel2.Visible = False
        BTN_MOD21.Focus()
    End Sub
    Sub CARGAR_CUENTA()
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año2.Text)
            dgw_cta.DataSource = (DT)
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año2.Text)
            dgw_cta02.DataSource = (DT)
            dgw_cta02.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta02.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_DET()
        txt_cta02.Text = txt_cta.Text
        txt_desc_cta02.Text = txt_desc_cta.Text
        NRO_DOC2.Text = dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString()
        CBO_CC02.Text = OBJ.DESC_CC(dgw2.Item(15, dgw2.CurrentRow.Index).Value.ToString)
        txt_nro_req2.Text = dgw2.Item(16, dgw2.CurrentRow.Index).Value.ToString
        CBO_PROYECTO02.Text = OBJ.DESC_PROYECTO(dgw2.Item(17, dgw2.CurrentRow.Index).Value.ToString)
        COD_ACT = dgw2.Item(18, dgw2.CurrentRow.Index).Value.ToString
        cbo_act02.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
        TXT_GLOSA2.Text = dgw2.Item(2, dgw2.CurrentRow.Index).Value.ToString
        COD_AUX0 = dgw2.Item(19, dgw2.CurrentRow.Index).Value.ToString
        COD_COMP0 = dgw2.Item(20, dgw2.CurrentRow.Index).Value.ToString
        NRO_COMP0 = dgw2.Item(21, dgw2.CurrentRow.Index).Value.ToString
        ITEM0 = dgw2.Item(23, dgw2.CurrentRow.Index).Value.ToString
        ch_rep2.Checked = dgw2.Item(25, dgw2.CurrentRow.Index).Value
        ch_auto2.Checked = dgw2.Item(29, dgw2.CurrentRow.Index).Value
        txt_enlace2.Text = dgw2.Item(30, dgw2.CurrentRow.Index).Value
        txt_destino2.Text = dgw2.Item(31, dgw2.CurrentRow.Index).Value
        ch_ana2.Checked = dgw2.Item(32, dgw2.CurrentRow.Index).Value
        '----------------------------------------------------------------------
        COD_REF = (dgw2.Item(26, dgw2.CurrentRow.Index).Value.ToString)
        If COD_REF = "" Then
            cbo_tipo_ref2.SelectedIndex = -1
        Else
            COD_REF = (dgw2.Item(26, dgw2.CurrentRow.Index).Value.ToString)
            cbo_tipo_ref2.Text = OBJ.DESC_DOC(COD_REF)
        End If
        txt_nro_ref2.Text = (dgw2.Item(27, dgw2.CurrentRow.Index).Value.ToString)
        Try
            dtp_ref2.Value = (dgw2.Item(28, dgw2.CurrentRow.Index).Value)
        Catch ex As Exception
        End Try
        '--------------------------------------------------------
        If dgw2.Item(3, dgw2.CurrentRow.Index).Value = "0.00" Then
            txt_importe12.Text = OBJ.HACER_DECIMAL(dgw2.Item(4, dgw2.CurrentRow.Index).Value)
            txt_importe22.Text = OBJ.HACER_DECIMAL(dgw2.Item(4, dgw2.CurrentRow.Index).Value)
        Else
            txt_importe12.Text = OBJ.HACER_DECIMAL(dgw2.Item(3, dgw2.CurrentRow.Index).Value)
            txt_importe22.Text = OBJ.HACER_DECIMAL(dgw2.Item(3, dgw2.CurrentRow.Index).Value)
        End If

        TXT_COD2.Text = dgw2.Item(10, dgw2.CurrentRow.Index).Value.ToString
        TXT_DESC2.Text = dgw2.Item(11, dgw2.CurrentRow.Index).Value.ToString
        txt_doc_per2.Text = dgw2.Item(12, dgw2.CurrentRow.Index).Value.ToString
    End Sub
    Sub CBO_ACTIVIDAD()
        Dim RPTA As String
        RPTA = OBJ.DIR_TABLA_DESC("COS", "TSIST")

        If RPTA = "SI" Then
            Dim GEN As New Genericos
            Dim DT As New DataTable
            DT = GEN.CBO_ACTIVIDAD(con00)
            cbo_act02.DataSource = DT
            cbo_act02.DisplayMember = DT.Columns.Item(0).ToString
            cbo_act02.ValueMember = DT.Columns.Item(1).ToString
            cbo_act02.SelectedIndex = -1
        Else
        End If
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_auxiliar2.SelectedIndexChanged
        If (cbo_auxiliar2.SelectedIndex <> -1) Then
            COD_AUX = cbo_auxiliar2.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                LLENAR_CBO_COMPROBANTE()
            End If
        End If
    End Sub
    Sub CBO_PROYECTO0()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PROYECTO_FECHA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA_GRAL
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_PROYECTO02.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cta2.CheckedChanged
        txt_cta02.Enabled = ch_cta2.Checked
        txt_desc_cta02.Enabled = ch_cta2.Checked
        If txt_cta02.Enabled Then
            txt_cta02.Focus()
        End If
        If ch_cta2.Checked = True Then
            ch_auto2.Enabled = True
        Else
            ch_auto2.Enabled = False
        End If
    End Sub
    Sub DGW_CC0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        CBO_CC02.DataSource = DT
        CBO_CC02.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC02.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC02.SelectedIndex = -1
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            Panel_cta.Visible = False
            KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_cta.Clear()
            txt_desc_cta.Clear()
            txt_cta.Focus()
        End If
    End Sub
    Private Sub dgw_cta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta02.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta02.Text = (dgw_cta02.Item(0, dgw_cta02.CurrentRow.Index).Value)
            txt_desc_cta02.Text = (dgw_cta02.Item(1, dgw_cta02.CurrentRow.Index).Value)
            '----------------------------------------------------------
            If ch_cta2.Checked = True And txt_cta02.Text <> "" Then
                If CONTAR_REG(txt_cta02.Text, cbo_año2.Text) > 0 Then
                    txt_destino2.Text = OBJ.HALLAR_CTA_DESTINO(cbo_año2.Text, txt_cta02.Text)
                    txt_enlace2.Text = OBJ.HALLAR_CTA_ENLACE(cbo_año2.Text, txt_cta02.Text)
                    Panel_cta02.Visible = False
                    KL01.Focus()
                Else
                    txt_destino2.Clear()
                    txt_enlace2.Clear()
                    Panel_cta02.Visible = False
                    KL01.Focus()
                End If
            Else
                Panel_cta02.Visible = False
                KL01.Focus()
            End If
            '----------------------------------------------------------
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta02.Visible = False
            txt_cta02.Clear()
            txt_desc_cta02.Clear()
            txt_cta02.Focus()
        End If
    End Sub
    Sub LIMPIAR_DET()
        PANEL_PER2.Visible = False
        TXT_COD2.Clear()
        TXT_DESC2.Clear()
        NRO_DOC2.Clear()
        txt_doc_per2.Clear()
        txt_cta02.Clear()
        txt_enlace2.Clear()
        txt_destino2.Clear()
        cbo_tipo_ref2.SelectedIndex = -1
        txt_nro_ref2.Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        txt_cta02.Enabled = False
        txt_desc_cta02.Clear()
        txt_desc_cta02.Enabled = False
        CBO_CC02.SelectedIndex = -1
        CBO_PROYECTO02.SelectedIndex = -1
        txt_nro_req2.Clear()
        cbo_act02.SelectedIndex = -1
        TXT_GLOSA2.Clear()
        TXT_COD2.Enabled = False
        TXT_DESC2.Enabled = False
        txt_doc_per2.Enabled = False
        ch_cta2.Checked = False
        ch_rep2.Checked = False
        ch_ana2.Checked = False
        ch_auto2.Checked = False
        ch_auto2.Enabled = False
        GroupBox3.Visible = False
        CheckBox1.Visible = False
    End Sub
    Sub LLENAR_CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar2.DataSource = DT
        cbo_auxiliar2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar2.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar2.SelectedIndex = -1
    End Sub
    Sub LLENAR_CBO_COMPROBANTE()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_comprobante2.DataSource = DT
        cbo_comprobante2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_comprobante2.ValueMember = DT.Columns.Item(1).ToString
        cbo_comprobante2.SelectedIndex = -1
        If (cbo_comprobante2.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub MOSTRAR_CONSULTA()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_T_CON_ACTUALIZA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
            PROG_01.Parameters.Add("@ST_AUX", SqlDbType.Char).Value = ST_AUX
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            PROG_01.Parameters.Add("@ST_COMP", SqlDbType.Char).Value = ST_COMP
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), Rs3.GetValue(31), Rs3.GetValue(32))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta.LostFocus
        If (Strings.Trim(txt_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el cbo_año1.text elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        btn_consulta2.Focus()
                        Return
                    End If
                    If (txt_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta02.LostFocus
        If (Strings.Trim(txt_cta02.Text) <> "") Then
            If (dgw_cta02.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el cbo_año1.text elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta02.Sort(dgw_cta02.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta02.RowCount - 1))
                    If (txt_cta02.Text.ToLower = dgw_cta02.Item(0, i).Value.ToString.ToLower) Then
                        '-----------------------------------
                        txt_cta02.Text = dgw_cta02.Item(0, i).Value.ToString
                        txt_desc_cta02.Text = dgw_cta02.Item(1, i).Value.ToString
                        KL01.Focus()
                        Return
                        '---------------------------------
                    End If
                    If (txt_cta02.Text.ToLower = Strings.Mid((dgw_cta02.Item(0, i).Value), 1, Strings.Len(txt_cta02.Text)).ToLower) Then
                        dgw_cta02.CurrentCell = (dgw_cta02.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta02.Visible = True
                dgw_cta02.Focus()
            End If
        End If
    End Sub
    Function CONTAR_REG(ByVal COD_CTA0 As Object, ByVal AÑO0 As Object) As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_AUTOMATICAS2", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CTA0
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO0
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el cbo_año1.text elegido", "Aviso:")
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta02.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta02.Text) <> "")) Then
            If (dgw_cta02.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el cbo_año1.text elegido", "Aviso:")
            Else
                dgw_cta02.Sort(dgw_cta02.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta02.RowCount - 1))
                    If (txt_desc_cta02.Text.ToLower = Strings.Mid((dgw_cta02.Item(1, i).Value), 1, Strings.Len(txt_desc_cta02.Text)).ToLower) Then
                        dgw_cta02.CurrentCell = (dgw_cta02.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta02.Visible = True
                dgw_cta02.Focus()
            End If
        End If
    End Sub
    Private Sub CONSULTA_TCON_ACTUALIZA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub CBO_CONTROL0()
    End Sub
    Private Sub CONSULTA_TCON_ACTUALIZA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_mes2.Text = OBJ.DESC_MES(MES)
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_PERSONAS()
        LLENAR_CBO_AUXILIAR()
        CBO_REFERENCIA()
        CARGAR_AÑO()
        DGW_CC0()
        CBO_PROYECTO0()
        CBO_CONTROL0()
        CBO_ACTIVIDAD()
        txt_letra2.Clear()
        cbo_año2.Text = "2010"
        txt_cta.Focus()
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XCOBRAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            DGW_PER2.DataSource = (DT)
            DGW_PER2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            DGW_PER2.Columns(0).Width = &H37
            DGW_PER2.Columns(1).Width = 300
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CBO_REFERENCIA()
        cbo_tipo_ref2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_REF", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_ref2.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar2.Click
        dgw2.Sort(dgw2.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Dim i As Integer
        txt_letra2.Focus()
        If Trim(txt_letra2.Text) <> "" Then
            For i = 0 To dgw2.RowCount() - 1
                If txt_letra2.Text.ToLower = Mid(dgw2.Item(1, i).Value, 1, Len(txt_letra2.Text)).ToLower Then
                    dgw2.CurrentCell = dgw2.Rows(i).Cells(1)
                    Exit For
                End If
            Next
        Else
        End If
    End Sub
    Private Sub cbo_año1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año2.SelectedIndexChanged
        CARGAR_CUENTA()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox3.Visible = True
        Else
            GroupBox3.Visible = False
        End If
    End Sub
    Private Sub txt_importe2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_importe22.KeyPress
        e.Handled = Numero(e, txt_importe22)
    End Sub
    Function Numero(ByVal e As KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.]" Then
            Return True
        End If
        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Private Sub txt_importe2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_importe22.LostFocus
        Try
            txt_importe22.Text = OBJ.HACER_DECIMAL(txt_importe22.Text)
        Catch ex As Exception
            txt_importe22.Text = "0.00"
            txt_importe22.Focus()
        Finally
        End Try
    End Sub
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_COD2.LostFocus
        If (Strings.Trim(TXT_COD2.Text) = "") Then
            TXT_DESC2.Focus()
        ElseIf (DGW_PER2.RowCount = 0) Then
            MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            DGW_PER2.Sort(DGW_PER2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= (DGW_PER2.RowCount - 1))
                If (TXT_COD2.Text.ToLower = DGW_PER2.Item(0, i).Value.ToString.ToLower) Then
                    TXT_COD2.Text = DGW_PER2.Item(0, i).Value.ToString
                    TXT_DESC2.Text = DGW_PER2.Item(1, i).Value.ToString
                    txt_doc_per2.Text = DGW_PER2.Item(2, i).Value.ToString
                    'dtp1.Select()
                    Return
                End If
                If (TXT_COD2.Text.ToLower = Strings.Mid((DGW_PER2.Item(0, i).Value), 1, Strings.Len(TXT_COD2.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                i += 1
            Loop
            PANEL_PER2.Visible = True
            DGW_PER2.Visible = True
            DGW_PER2.Focus()
        End If
    End Sub
    Private Sub TXT_DESC1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_DESC2.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(TXT_DESC2.Text) = "") Then
                txt_doc_per2.Focus()
            ElseIf (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER2.RowCount - 1))
                    If (TXT_DESC2.Text.ToLower = Strings.Mid((DGW_PER2.Item(1, i).Value), 1, Strings.Len(TXT_DESC2.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txt_doc_per2.Text) = "") Then
                TXT_COD2.Focus()
            ElseIf (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER2.RowCount - 1))
                    If (txt_doc_per2.Text.ToLower = Strings.Mid((DGW_PER2.Item(2, i).Value), 1, Strings.Len(txt_doc_per2.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub
    Private Sub DGW_PER1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGW_PER2.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD2.Text = DGW_PER2.Item(0, DGW_PER2.CurrentRow.Index).Value.ToString
            TXT_DESC2.Text = DGW_PER2.Item(1, DGW_PER2.CurrentRow.Index).Value.ToString
            txt_doc_per2.Text = DGW_PER2.Item(2, DGW_PER2.CurrentRow.Index).Value.ToString
            PANEL_PER2.Visible = False
            'k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER2.Visible = False
            TXT_COD2.Clear()
            TXT_DESC2.Clear()
            txt_doc_per2.Clear()
            TXT_COD2.Focus()
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            'TXT_COD1.Clear()
            'TXT_DESC1.Clear()
            'txt_doc_per1.Clear()
            PANEL_PER2.Visible = False
            TXT_COD2.Enabled = False
            TXT_DESC2.Enabled = False
            txt_doc_per2.Enabled = False
        Else
            TXT_COD2.Enabled = True
            TXT_DESC2.Enabled = True
            txt_doc_per2.Enabled = True
        End If
    End Sub
End Class