Imports System.Data.SqlClient
Public Class CONSULTA_TBANCO_ACTUALIZA
    Dim COD_ACT, ST_COMP, ST_AUX, NRO_COMP0, ITEM0, COD_COMP0, COD_MP0, NRO_MP0, COD_REF, COD_PROY, COD_MES, COD_AUX, COD_AUX0, COD_CC, COD_COMP, COD_CONT As String
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
            txt_nro_req.Text = ofr.DGW_CAB.Item(0, ofr.DGW_CAB.CurrentRow.Index).Value.ToString
            Try
                COD_ACT = ofr.DGW_DET.Item(0, ofr.DGW_DET.CurrentRow.Index).Value.ToString
            Catch ex As Exception
                COD_ACT = ""
            End Try
            cbo_act01.SelectedIndex = -1
            cbo_act01.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
            ofr.Hide()
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(42) = 0
        Close()
    End Sub
    Private Sub btn_consulta1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta1.Click
        If (CH_AUX.Checked And (cbo_auxiliar.SelectedIndex = -1)) Then MessageBox.Show("Debe elegir la Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_auxiliar.Focus() : Exit Sub
        If (ch_com.Checked And (cbo_comprobante.SelectedIndex = -1)) Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_comprobante.Focus() : Exit Sub
        If txt_cod_ban.Text.Trim = "" Then MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        COD_MES = OBJ.COD_MES(cbo_mes.Text)
        ST_AUX = "1"
        ST_COMP = "1"
        COD_AUX = ""
        COD_COMP = ""
        If CH_AUX.Checked Then
            ST_AUX = "0"
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
        End If
        If ch_com.Checked Then
            ST_COMP = "0"
            COD_COMP = cbo_comprobante.SelectedValue.ToString
        End If
        '---------------------------------------------------------------------------------
        If OBJ.VERIFICAR_CIERRE_PERIODO(cbo_año1.Text, OBJ.COD_MES(cbo_mes.Text), "BCO") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        ElseIf OBJ.VERIFICAR_BLOKEO_PERIODO(cbo_año1.Text, OBJ.COD_MES(cbo_mes.Text), "BCO") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA()
            GroupBox2.Enabled = False
        End If
    End Sub
    Private Sub btn_lim_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_lim.Click
        CBO_CC01.SelectedIndex = -1
        CBO_PROYECTO01.SelectedIndex = -1
        txt_nro_req.Clear()
        cbo_act01.SelectedIndex = -1
    End Sub
    Private Sub BTN_LIMP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_LIMP.Click
        CH_AUX.Checked = False
        cbo_auxiliar.SelectedIndex = -1
        ch_com.Checked = False
        cbo_comprobante.SelectedIndex = -1
        dgw1.Rows.Clear()
        GroupBox2.Enabled = True
    End Sub
    Private Sub BTN_MOD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_MOD.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elelgir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE = dgw1.CurrentRow.Index
        LIMPIAR_DET()
        CARGAR_DET()
        Panel1.Visible = True
        CBO_CC01.Focus()
    End Sub
    Private Sub btn_mod2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod2.Click
        COD_CC = "" : COD_PROY = "" : COD_CONT = "" : COD_ACT = "" : COD_REF = ""
        If (CBO_CC01.SelectedIndex <> -1) Then
            COD_CC = OBJ.COD_CC(CBO_CC01.Text)
        End If
        '-----------------------------------------------
        If (CBO_PROYECTO01.SelectedIndex <> -1) Then
            COD_PROY = OBJ.COD_PROYECTO(CBO_PROYECTO01.Text)
        End If
        '-----------------------------------------------
        COD_CONT = txt_nro_req.Text
        If (cbo_act01.SelectedIndex <> -1) Then
            COD_ACT = cbo_act01.SelectedValue.ToString
        End If

        Try
            Dim comand1 As New SqlCommand("MODIFICAR_T_BANCO", con)
            comand1.CommandType = (CommandType.StoredProcedure)
           
            comand1.Parameters.Add("@ITEM", SqlDbType.VarChar).Value = ITEM0
            comand1.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = COD_CC
            comand1.Parameters.Add("@COD_CONTROL", SqlDbType.VarChar).Value = COD_CONT
            comand1.Parameters.Add("@COD_PROYECTO", SqlDbType.VarChar).Value = COD_PROY
            comand1.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = COD_ACT
            comand1.Parameters.Add("@GLOSA", SqlDbType.VarChar).Value = TXT_GLOSA.Text
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD1.Text
            comand1.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod_cta.Text
            comand1.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP0
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = NRO_MP0
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        MOSTRAR_CONSULTA()
        If dgw1.RowCount <> 0 Then
            FOCO_NUEVO_REG()
        Else
        End If
        Panel1.Visible = False
        BTN_MOD.Focus()
    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        Dim NRO_OC As String = NRO_DOC.Text
        For I = 0 To CONT
            If NRO_OC = dgw1.Item(1, I).Value.ToString.ToLower Then
                dgw1.CurrentCell = (dgw1.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub btn_req_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_req.Click
        boton3()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Panel1.Visible = False
        BTN_MOD.Focus()
    End Sub
    Sub CARGAR_BANCOS()
        Try
            dgw_ban.DataSource = OBJ.MOSTRAR_BANCO_COMP
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
            dgw_ban.Columns(2).Visible = False
            dgw_ban.Columns(3).Visible = False
            dgw_ban.Columns(0).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '--------------------------------------------------------
        Try
            dgw_ban2.DataSource = OBJ.MOSTRAR_BANCO_COMP
            dgw_ban2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
            dgw_ban2.Columns(2).Visible = False
            dgw_ban2.Columns(3).Visible = False
            dgw_ban2.Columns(0).Width = 50
            dgw_ban2.Columns(1).Width = 210
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_DET()
        txt_cod_ban2.Text = txt_cod_ban.Text
        txt_desc_ban2.Text = txt_desc_ban.Text
        NRO_DOC.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString()
        txt_cod_cta.Text = dgw1.Item(22, dgw1.CurrentRow.Index).Value.ToString()
        txt_desc_cta.Text = dgw1.Item(23, dgw1.CurrentRow.Index).Value.ToString()

        CBO_CC01.Text = OBJ.DESC_CC(dgw1.Item(11, dgw1.CurrentRow.Index).Value.ToString)
        txt_nro_req.Text = dgw1.Item(12, dgw1.CurrentRow.Index).Value.ToString
        CBO_PROYECTO01.Text = OBJ.DESC_PROYECTO(dgw1.Item(13, dgw1.CurrentRow.Index).Value.ToString)
        COD_ACT = dgw1.Item(21, dgw1.CurrentRow.Index).Value.ToString
        cbo_act01.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
        TXT_GLOSA.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        '----------
        COD_AUX0 = dgw1.Item(14, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP0 = dgw1.Item(15, dgw1.CurrentRow.Index).Value.ToString
        NRO_COMP0 = dgw1.Item(16, dgw1.CurrentRow.Index).Value.ToString
        COD_MP0 = dgw1.Item(19, dgw1.CurrentRow.Index).Value.ToString
        NRO_MP0 = dgw1.Item(20, dgw1.CurrentRow.Index).Value.ToString
        ITEM0 = dgw1.Item(17, dgw1.CurrentRow.Index).Value.ToString

        '----------------------------------------------------------------------

        TXT_COD1.Text = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString
        TXT_DESC1.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        txt_doc_per1.Text = dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Sub CBO_ACTIVIDAD()
        Dim RPTA As String
        RPTA = OBJ.DIR_TABLA_DESC("COS", "TSIST")

        If RPTA = "SI" Then
            Dim GEN As New Genericos
            Dim DT As New DataTable
            DT = GEN.CBO_ACTIVIDAD(con00)
            cbo_act01.DataSource = DT
            cbo_act01.DisplayMember = DT.Columns.Item(0).ToString
            cbo_act01.ValueMember = DT.Columns.Item(1).ToString
            cbo_act01.SelectedIndex = -1
        Else
        End If
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex <> -1) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
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
                CBO_PROYECTO01.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    If dgw1.Item(18, dgw1.CurrentRow.Index).Value.ToString = "S" Then
    '        MessageBox.Show("Esta Contabilizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Sub
    '    End If



    '    txt_cod_ban2.Enabled = ch_banco.Checked
    '    txt_desc_ban2.Enabled = ch_banco.Checked
    '    If txt_cod_ban2.Enabled Then
    '        txt_cod_ban2.Focus()
    '    End If
    'End Sub
    Sub DGW_CC0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        CBO_CC01.DataSource = DT
        CBO_CC01.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC01.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC01.SelectedIndex = -1
    End Sub


    Sub LIMPIAR_DET()
        PANEL_PER1.Visible = False
        NRO_DOC.Clear()
        TXT_COD1.Clear()
        TXT_DESC1.Clear()
        txt_doc_per1.Clear()
        'txt_cta01.Clear()


        ch_per.Checked = False
        'txt_cta01.Enabled = False
        'txt_desc_cta01.Clear()
        'txt_desc_cta01.Enabled = False
        CBO_CC01.SelectedIndex = -1
        CBO_PROYECTO01.SelectedIndex = -1
        txt_nro_req.Clear()
        cbo_act01.SelectedIndex = -1
        TXT_GLOSA.Clear()
        TXT_COD1.Enabled = False
        TXT_DESC1.Enabled = False
        txt_doc_per1.Enabled = False
        'ch_banco.Checked = False
        ch_per.Checked = False
        ch_cpto.Checked = False
        txt_cod_ban2.Enabled = False
        txt_desc_ban2.Enabled = False
        txt_cod_cta.Enabled = False
        txt_desc_cta.Enabled = False

    End Sub
    Sub LLENAR_CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar.DataSource = DT
        cbo_auxiliar.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar.SelectedIndex = -1
    End Sub
    Sub LLENAR_CBO_COMPROBANTE()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_comprobante.DataSource = DT
        cbo_comprobante.DisplayMember = DT.Columns.Item(0).ToString
        cbo_comprobante.ValueMember = DT.Columns.Item(1).ToString
        cbo_comprobante.SelectedIndex = -1
        If (cbo_comprobante.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub MOSTRAR_CONSULTA()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_T_BANCO_ACTUALIZA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
            PROG_01.Parameters.Add("@ST_AUX", SqlDbType.Char).Value = ST_AUX
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            PROG_01.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            PROG_01.Parameters.Add("@ST_COMP", SqlDbType.Char).Value = ST_COMP
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
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


    Private Sub CONSULTA_TCON_ACTUALIZA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub CBO_CONTROL0()
    End Sub
    Private Sub CONSULTA_TCON_ACTUALIZA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_mes.Text = OBJ.DESC_MES(MES)
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_PERSONAS()
        CONCEPTOS()
        LLENAR_CBO_AUXILIAR()
        CARGAR_BANCOS()
        CARGAR_AÑO()
        DGW_CC0()
        CBO_PROYECTO0()
        CBO_CONTROL0()
        CBO_ACTIVIDAD()
        txt_letra.Clear()
        cbo_año1.Text = "2010"
        'txt_cta.Focus()
    End Sub
    Sub CONCEPTOS()
        Try
            Dim pro As New SqlCommand("DGW_CONCEPTOS_NIVEL5", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_cta.DataSource = dt
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(0).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XCOBRAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            DGW_PER1.DataSource = (DT)
            DGW_PER1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            DGW_PER1.Columns(0).Width = &H37
            DGW_PER1.Columns(1).Width = 300
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
                cbo_año1.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        dgw1.Sort(dgw1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        Dim i As Integer
        txt_letra.Focus()
        If Trim(txt_letra.Text) <> "" Then
            For i = 0 To dgw1.RowCount() - 1
                If txt_letra.Text.ToLower = Mid(dgw1.Item(1, i).Value, 1, Len(txt_letra.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(1)
                    Exit For
                End If
            Next
        Else
        End If
    End Sub
    Private Sub cbo_año1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año1.SelectedIndexChanged
        'CARGAR_BANCOS()
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
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) = "") Then
            TXT_DESC1.Focus()
        ElseIf (DGW_PER1.RowCount = 0) Then
            MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            DGW_PER1.Sort(DGW_PER1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= (DGW_PER1.RowCount - 1))
                If (TXT_COD1.Text.ToLower = DGW_PER1.Item(0, i).Value.ToString.ToLower) Then
                    TXT_COD1.Text = DGW_PER1.Item(0, i).Value.ToString
                    TXT_DESC1.Text = DGW_PER1.Item(1, i).Value.ToString
                    txt_doc_per1.Text = DGW_PER1.Item(2, i).Value.ToString
                    'dtp1.Select()
                    Return
                End If
                If (TXT_COD1.Text.ToLower = Strings.Mid((DGW_PER1.Item(0, i).Value), 1, Strings.Len(TXT_COD1.Text)).ToLower) Then
                    DGW_PER1.CurrentCell = (DGW_PER1.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                i += 1
            Loop
            PANEL_PER1.Visible = True
            DGW_PER1.Visible = True
            DGW_PER1.Focus()
        End If
    End Sub
    Private Sub TXT_DESC1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_DESC1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(TXT_DESC1.Text) = "") Then
                txt_doc_per1.Focus()
            ElseIf (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER1.RowCount - 1))
                    If (TXT_DESC1.Text.ToLower = Strings.Mid((DGW_PER1.Item(1, i).Value), 1, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                        DGW_PER1.CurrentCell = (DGW_PER1.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER1.Visible = True
                DGW_PER1.Visible = True
                DGW_PER1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txt_doc_per1.Text) = "") Then
                TXT_COD1.Focus()
            ElseIf (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER1.RowCount - 1))
                    If (txt_doc_per1.Text.ToLower = Strings.Mid((DGW_PER1.Item(2, i).Value), 1, Strings.Len(txt_doc_per1.Text)).ToLower) Then
                        DGW_PER1.CurrentCell = (DGW_PER1.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER1.Visible = True
                DGW_PER1.Visible = True
                DGW_PER1.Focus()
            End If
        End If
    End Sub
    Private Sub DGW_PER1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGW_PER1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = DGW_PER1.Item(0, DGW_PER1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = DGW_PER1.Item(1, DGW_PER1.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = DGW_PER1.Item(2, DGW_PER1.CurrentRow.Index).Value.ToString
            PANEL_PER1.Visible = False
            'k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER1.Visible = False
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            txt_doc_per1.Clear()
            TXT_COD1.Focus()
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_per.CheckedChanged
        If ch_per.Checked = False Then
            'TXT_COD1.Clear()
            'TXT_DESC1.Clear()
            'txt_doc_per1.Clear()
            PANEL_PER1.Visible = False
            TXT_COD1.Enabled = False
            TXT_DESC1.Enabled = False
            txt_doc_per1.Enabled = False
        Else
            TXT_COD1.Enabled = True
            TXT_DESC1.Enabled = True
            txt_doc_per1.Enabled = True
        End If
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban.RowCount - 1)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        btn_consulta1.Focus()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Mid(dgw_ban.Item(0, i).Value, 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban1.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban.RowCount - 1)
                    If (txt_desc_ban.Text.ToLower = Mid(dgw_ban.Item(1, i).Value, 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban1.Visible = True
                Panel_ban1.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            Panel_ban1.Visible = False
            KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_ban1.Visible = False
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
        End If
    End Sub
    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        txt_cod_ban.Focus()
                        Return
                    End If
                    If (txt_cod_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cta.Visible = True
                dgw_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso Trim(txt_desc_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value.ToString
            panel_cta.Visible = False
            'k1.Focus()
        End If
    End Sub
    Private Sub txt_cod_ban2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban2.LostFocus
        If (Strings.Trim(txt_cod_ban2.Text) <> "") Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban2.RowCount - 1)
                    If (txt_cod_ban2.Text.ToLower = dgw_ban2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban2.Text = dgw_ban2.Item(0, i).Value.ToString
                        txt_desc_ban2.Text = dgw_ban2.Item(1, i).Value.ToString
                        'btn_consulta1.Focus()
                        Return
                    End If
                    If (txt_cod_ban2.Text.ToLower = Mid(dgw_ban2.Item(0, i).Value, 1, Strings.Len(txt_cod_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban2.Visible = True
                dgw_ban2.Visible = True
                dgw_ban2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban2.Text) <> "")) Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban2.RowCount - 1)
                    If (txt_desc_ban2.Text.ToLower = Mid(dgw_ban2.Item(1, i).Value, 1, Strings.Len(txt_desc_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban2.Visible = True
                Panel_ban2.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_ban2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban2.Text = dgw_ban2.Item(0, dgw_ban2.CurrentRow.Index).Value.ToString
            txt_desc_ban2.Text = dgw_ban2.Item(1, dgw_ban2.CurrentRow.Index).Value.ToString
            Panel_ban2.Visible = False
            KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_ban2.Visible = False
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
            txt_cod_ban2.Focus()
        End If
    End Sub
    Private Sub ch_cpto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_cpto.CheckedChanged
        If ch_cpto.Checked = False Then
            panel_cta.Visible = False
            txt_cod_cta.Enabled = False
            txt_desc_cta.Enabled = False
        Else
            txt_cod_cta.Enabled = True
            txt_desc_cta.Enabled = True
        End If
    End Sub
End Class