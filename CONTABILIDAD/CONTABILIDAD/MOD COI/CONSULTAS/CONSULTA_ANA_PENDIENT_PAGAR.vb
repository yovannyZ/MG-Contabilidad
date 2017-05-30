Imports System.Data.SqlClient
Public Class CONSULTA_ANA_PENDIENT_PAGAR
    Dim obj As New Class1
    Dim INDICE, INDICE2, INDICE3, INDICE4 As Integer
    Dim COD_ACT, NRO_COMP0, COD_COMP02, cod_mon4, cod_mon3, SUCURSAL03, COD_AUX, COD_AUX0, COD_COMP, COD_COMP0, COD_CONT, COD_MES, ITEM0, COD_AUX03, COD_COMP03, NRO_COMP03, DOC_PER03, ITEM03, COD_AUX2 As String
    Dim ST_AUX, COD_MES2, ST_AUX2, COD_AUX02, NRO_COMP02, ITEM02, ST_COMP, cod_mon, ST_COMP2, COD_COMP2, cod_mon2, DOC_PER02, COD_MES3, COD_MES4 As String
    Private Sub CONSULTA_ANA_PENDIENT_PAGAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
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
                cbo_año2.Items.Add(Rs3.GetString(0))
                cbo_año3.Items.Add(Rs3.GetString(0))
                cbo_año4.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_ANA_PENDIENT_PAGAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_mes.Text = obj.DESC_MES(MES)
        cbo_mes2.Text = obj.DESC_MES(MES)
        cbo_mes4.Text = obj.DESC_MES(MES)
        CARGAR_AÑO()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw4.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        'CARGAR_CUENTA()
        LLENAR_CBO_AUXILIAR()
        PERSONAS()
        CARGAR_MONEDA()
        txt_cta.Focus()
    End Sub
    Sub CARGAR_MONEDA()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT
        cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
        '---------------------------------------------------------
        cbo_moneda2.DataSource = DT
        cbo_moneda2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda2.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda2.SelectedIndex = -1
        '---------------------------------------------------------
        cbo_moneda3.DataSource = DT
        cbo_moneda3.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda3.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda3.SelectedIndex = -1
        '---------------------------------------------------------
        cbo_moneda4.DataSource = DT
        cbo_moneda4.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda4.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda4.SelectedIndex = -1
    End Sub
    Sub PERSONAS()
        Try
            dgw_per.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '-----------------------------------------
        Try
            dgw_per2.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per2.Columns.Item(0).Width = 50
            dgw_per2.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '-----------------------------------------
        Try
            dgw_per3.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per3.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per3.Columns.Item(0).Width = 50
            dgw_per3.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '-----------------------------------------
        Try
            dgw_per4.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per4.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per4.Columns.Item(0).Width = 50
            dgw_per4.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Sub LLENAR_CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar.DataSource = DT
        cbo_auxiliar.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar.SelectedIndex = -1
        '------------------------------------------
        cbo_auxiliar2.DataSource = DT
        cbo_auxiliar2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar2.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar2.SelectedIndex = -1

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
    Sub LLENAR_CBO_COMPROBANTE2()
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
    Sub CARGAR_CUENTA1()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año1.Text)
            dgw_cta.DataSource = (DT)
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(0).Width = (80)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTA2()
        '-----------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año2.Text)
            dgw_cta2.DataSource = (DT)
            dgw_cta2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta2.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub CARGAR_CUENTA3()
        '-----------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año3.Text)
            dgw_cta3.DataSource = (DT)
            dgw_cta3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta3.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTA4()
        '-----------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año4.Text)
            dgw_cta4.DataSource = (DT)
            dgw_cta4.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta4.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir2.Click, btn_salir3.Click, btn_cancelar.Click
        main(31) = 0
        Close()
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex <> -1) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                LLENAR_CBO_COMPROBANTE()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
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
    Private Sub txt_cta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta.LostFocus
        If (Strings.Trim(txt_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        btn_consulta1.Focus()
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
    Sub LIMPIAR_DET()
        'txt_cta01.Clear()
        btn_mod2.Enabled = True
        btn_lim.Enabled = True
        txt_cod_per.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        txt_doc.Clear()
        txt_nro_doc.Clear()
        txt_importe.Clear()
        cbo_moneda.SelectedIndex = -1
        txt_cod_per.Enabled = False
        txt_desc_per.Enabled = False
        txt_doc_per.Enabled = False
        ch_per.Checked = False
        txt_doc.Enabled = False
        txt_nro_doc.Enabled = False
    End Sub
    Sub LIMPIAR_DET2()
        btn_mod22.Enabled = True
        btn_lim2.Enabled = True
        txt_cod_per2.Clear()
        txt_desc_per2.Clear()
        txt_doc_per2.Clear()
        txt_doc2.Clear()
        txt_nro_doc2.Clear()
        txt_im_soles.Clear()
        txt_im_dolares.Clear()
        cbo_moneda2.SelectedIndex = -1
        txt_cod_per2.Enabled = False
        txt_desc_per2.Enabled = False
        txt_doc_per2.Enabled = False
        ch_per2.Checked = False
        txt_doc2.Enabled = False
        txt_nro_doc2.Enabled = False
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
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
    Private Sub btn_consulta1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consulta1.Click
        If CH_AUX.Checked And cbo_auxiliar.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_auxiliar.Focus() : Exit Sub
        If (ch_com.Checked And (cbo_comprobante.SelectedIndex = -1)) Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_comprobante.Focus() : Exit Sub
        If txt_cta.Text.Trim = "" Then MessageBox.Show("Debe elgir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub

        COD_MES = (obj.COD_MES(cbo_mes.Text))
        ST_AUX = "1" : ST_COMP = "1"
        COD_AUX = "" : COD_COMP = ""
        If CH_AUX.Checked Then
            ST_AUX = "0"
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
        End If
        If ch_com.Checked Then
            ST_COMP = "0"
            COD_COMP = cbo_comprobante.SelectedValue.ToString
        End If
        '---------------------------------------------------------------------------------
        If obj.VERIFICAR_CIERRE_PERIODO(cbo_año1.Text, obj.COD_MES(cbo_mes.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        ElseIf obj.VERIFICAR_BLOKEO_PERIODO(cbo_año1.Text, obj.COD_MES(cbo_mes.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA()
            GroupBox2.Enabled = False
            BTN_MOD.Focus()
        End If
    End Sub
    Sub MOSTRAR_CONSULTA()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_PENDIENTES_PAGAR", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
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
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub MOSTRAR_CONSULTA2()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_ANALISIS_PAGAR", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES2
            PROG_01.Parameters.Add("@ST_AUX", SqlDbType.Char).Value = ST_AUX2
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX2
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta2.Text
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP2
            PROG_01.Parameters.Add("@ST_COMP", SqlDbType.Char).Value = ST_COMP2
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ch_per_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ch_per.CheckedChanged
        If ch_per.Checked = True Then
            txt_cod_per.Enabled = True
            txt_desc_per.Enabled = True
            txt_doc_per.Enabled = True
            txt_cod_per.Focus()
        End If
    End Sub
    Private Sub BTN_LIMP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_LIMP.Click
        CH_AUX.Checked = False
        cbo_auxiliar.SelectedIndex = -1
        ch_com.Checked = False
        cbo_comprobante.SelectedIndex = -1
        txt_cta.Clear()
        txt_desc_cta.Clear()
        dgw1.Rows.Clear()
        GroupBox2.Enabled = True
        txt_cta.Focus()
    End Sub
    Private Sub btn_lim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_lim.Click
        txt_doc.Clear()
        txt_nro_doc.Clear()
        txt_importe.Clear()
        cbo_moneda.SelectedIndex = -1
        txt_doc.Focus()
    End Sub
    Private Sub BTN_MOD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_MOD.Click
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
        txt_doc.Focus()
    End Sub
    Private Sub btn_mod2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mod2.Click
        cod_mon = ""
        If (cbo_moneda.SelectedIndex <> -1) Then
            cod_mon = obj.COD_MONEDA(cbo_moneda.Text)
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_TCTAS_PAGAR_CONSULTA", con)
            comand1.CommandType = (CommandType.StoredProcedure)

            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_doc.Text
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_importe.Text
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cod_mon
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
            comand1.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX0
            comand1.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP0
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP0
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = TXT_CTA11.Text
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw1.Item(6, dgw1.CurrentRow.Index).Value = cod_mon
        dgw1.Item(0, dgw1.CurrentRow.Index).Value = txt_doc.Text
        dgw1.Item(1, dgw1.CurrentRow.Index).Value = txt_nro_doc.Text
        dgw1.Item(5, dgw1.CurrentRow.Index).Value = txt_importe.Text
        MOSTRAR_CONSULTA() : FOCO_NUEVO_REG()
        Panel1.Visible = False
        BTN_MOD.Focus()
        'dgw1.CurrentCell = (dgw1.Rows.Item(INDICE).Cells.Item(1))
    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc.Text
        For I = 0 To CONT
            If NRO_OC = dgw1.Item(1, I).Value.ToString.ToLower Then
                dgw1.CurrentCell = (dgw1.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel.Click
        Panel1.Visible = False
        BTN_MOD.Focus()
    End Sub
    Sub CARGAR_DET()
        txt_cod_per.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_per.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_doc_per.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        txt_doc.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_doc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_importe.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        cod_mon = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        cbo_moneda.Text = obj.DESC_MONEDA(cod_mon)
        COD_AUX0 = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP0 = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString
        NRO_COMP0 = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        TXT_CTA11.Text = txt_cta.Text
        'ITEM0 = dgw1.Item(23, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Sub CARGAR_DET2()
        txt_cod_per2.Text = dgw2.Item(2, dgw2.CurrentRow.Index).Value.ToString
        txt_desc_per2.Text = dgw2.Item(3, dgw2.CurrentRow.Index).Value.ToString
        txt_doc_per2.Text = dgw2.Item(4, dgw2.CurrentRow.Index).Value.ToString
        txt_doc2.Text = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
        txt_nro_doc2.Text = dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString
        txt_im_soles.Text = dgw2.Item(5, dgw2.CurrentRow.Index).Value.ToString
        txt_im_dolares.Text = dgw2.Item(6, dgw2.CurrentRow.Index).Value.ToString
        cod_mon2 = dgw2.Item(7, dgw2.CurrentRow.Index).Value.ToString
        cbo_moneda2.Text = obj.DESC_MONEDA(cod_mon2)
        COD_AUX02 = dgw2.Item(8, dgw2.CurrentRow.Index).Value.ToString
        COD_COMP02 = dgw2.Item(9, dgw2.CurrentRow.Index).Value.ToString
        NRO_COMP02 = dgw2.Item(10, dgw2.CurrentRow.Index).Value.ToString
        DOC_PER02 = dgw2.Item(11, dgw2.CurrentRow.Index).Value.ToString
        ITEM02 = dgw2.Item(12, dgw2.CurrentRow.Index).Value.ToString
        TXT_CTA22.Text = txt_cta2.Text
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
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
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
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per.Text = (dgw_per.Item(0, dgw_per.CurrentRow.Index).Value)
            txt_desc_per.Text = (dgw_per.Item(1, dgw_per.CurrentRow.Index).Value)
            txt_doc_per.Text = (dgw_per.Item(2, dgw_per.CurrentRow.Index).Value)
            Panel_per.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            Panel_per.Visible = False
            txt_cod_per.Focus()
        End If
    End Sub
    Private Sub cbo_auxiliar2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_auxiliar2.SelectedIndexChanged
        If (cbo_auxiliar2.SelectedIndex <> -1) Then
            COD_AUX2 = cbo_auxiliar2.SelectedValue.ToString
            If (COD_AUX2 <> "System.Data.DataRowView") Then
                LLENAR_CBO_COMPROBANTE2()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta2.Text) <> "")) Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta2.RowCount - 1))
                    If (txt_desc_cta2.Text.ToLower = Strings.Mid((dgw_cta2.Item(1, i).Value), 1, Strings.Len(txt_desc_cta2.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = (dgw_cta2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta2.Visible = True
                dgw_cta2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta2.LostFocus
        If (Strings.Trim(txt_cta2.Text) <> "") Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta2.RowCount - 1))
                    If (txt_cta2.Text.ToLower = dgw_cta2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta2.Text = dgw_cta2.Item(0, i).Value.ToString
                        txt_desc_cta2.Text = dgw_cta2.Item(1, i).Value.ToString
                        btn_consulta2.Focus()
                        Return
                    End If
                    If (txt_cta2.Text.ToLower = Strings.Mid((dgw_cta2.Item(0, i).Value), 1, Strings.Len(txt_cta2.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = (dgw_cta2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta2.Visible = True
                dgw_cta2.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta2.Text = (dgw_cta2.Item(0, dgw_cta2.CurrentRow.Index).Value)
            txt_desc_cta2.Text = (dgw_cta2.Item(1, dgw_cta2.CurrentRow.Index).Value)
            Panel_cta2.Visible = False
            'KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta2.Visible = False
            txt_cta2.Clear()
            txt_desc_cta2.Clear()
            txt_cta2.Focus()
        End If
    End Sub
    Private Sub btn_consulta2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consulta2.Click
        If CH_AUX2.Checked And cbo_auxiliar2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_auxiliar2.Focus() : Exit Sub
        If ch_com2.Checked And cbo_comprobante2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_comprobante2.Focus() : Exit Sub
        If txt_cta2.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta2.Focus() : Exit Sub

        COD_MES2 = (obj.COD_MES(cbo_mes2.Text))
        ST_AUX2 = "1" : ST_COMP2 = "1"
        COD_AUX2 = "" : COD_COMP2 = ""
        If CH_AUX2.Checked Then
            ST_AUX2 = "0"
            COD_AUX2 = cbo_auxiliar2.SelectedValue.ToString
        End If
        If ch_com2.Checked Then
            ST_COMP2 = "0"
            COD_COMP2 = cbo_comprobante2.SelectedValue.ToString
        End If
        'MOSTRAR_CONSULTA2()
        'G2.Enabled = False
        'BTN_MOD_ANA.Focus()
        '---------------------------------------------------------------------------------
        If obj.VERIFICAR_CIERRE_PERIODO(cbo_año2.Text, obj.COD_MES(cbo_mes2.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw2.Rows.Clear()
            cbo_mes2.Focus()
            Exit Sub
        ElseIf obj.VERIFICAR_BLOKEO_PERIODO(cbo_año2.Text, obj.COD_MES(cbo_mes2.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw2.Rows.Clear()
            cbo_mes2.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA2()
            G2.Enabled = False
            BTN_MOD_ANA.Focus()
        End If
    End Sub
    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked = True Then
            txt_cod_per2.Enabled = True
            txt_desc_per2.Enabled = True
            txt_doc_per2.Enabled = True
            txt_cod_per2.Focus()
        End If
    End Sub
    Private Sub BTN_LIMP2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_LIMP2.Click
        CH_AUX2.Checked = False
        cbo_auxiliar2.SelectedIndex = -1
        ch_com2.Checked = False
        cbo_comprobante2.SelectedIndex = -1
        txt_cta2.Clear()
        txt_desc_cta2.Clear()
        dgw2.Rows.Clear()
        G2.Enabled = True
        txt_cta2.Focus()
    End Sub
    Private Sub btn_lim2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_lim2.Click
        txt_doc2.Clear()
        txt_nro_doc2.Clear()
        txt_im_soles.Clear()
        txt_im_dolares.Clear()
        cbo_moneda2.SelectedIndex = -1
        txt_doc2.Focus()
    End Sub
    Private Sub BTN_MOD_ANA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTN_MOD_ANA.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE2 = dgw2.CurrentRow.Index
        LIMPIAR_DET2()
        CARGAR_DET2()
        Panel3.Visible = True
        txt_doc2.Focus()
    End Sub
    Private Sub btn_mod22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_mod22.Click
        cod_mon2 = ""
        If (cbo_moneda2.SelectedIndex <> -1) Then
            cod_mon2 = obj.COD_MONEDA(cbo_moneda2.Text)
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_ANALISIS_PAGAR_CONSULTA", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_doc2.Text
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc2.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per2.Text
            comand1.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = txt_im_soles.Text
            comand1.Parameters.Add("@IMP_D", SqlDbType.Decimal).Value = txt_im_dolares.Text
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cod_mon2
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES2
            comand1.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX02
            comand1.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP02
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP02
            comand1.Parameters.Add("@ITEM", SqlDbType.Char).Value = ITEM02
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DOC_PER02
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta2.Text
            comand1.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = TXT_CTA22.Text
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw2.Item(7, dgw2.CurrentRow.Index).Value = cod_mon2
        dgw2.Item(0, dgw2.CurrentRow.Index).Value = txt_doc2.Text
        dgw2.Item(1, dgw2.CurrentRow.Index).Value = txt_nro_doc2.Text
        dgw2.Item(5, dgw2.CurrentRow.Index).Value = txt_im_soles.Text
        dgw2.Item(6, dgw2.CurrentRow.Index).Value = txt_im_dolares.Text
        MOSTRAR_CONSULTA2() : FOCO_NUEVO_REG2()
        Panel3.Visible = False
        BTN_MOD_ANA.Focus()
        'dgw2.CurrentCell = (dgw2.Rows.Item(INDICE2).Cells.Item(1))
    End Sub
    Sub FOCO_NUEVO_REG2()
        Dim I, CONT As Integer
        CONT = dgw2.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc2.Text
        For I = 0 To CONT
            If NRO_OC = dgw2.Item(1, I).Value.ToString.ToLower Then
                dgw2.CurrentCell = (dgw2.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub cancel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel2.Click
        Panel3.Visible = False
        BTN_MOD_ANA.Focus()
    End Sub
    Private Sub txt_cta3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta3.LostFocus
        If (Strings.Trim(txt_cta3.Text) <> "") Then
            If (dgw_cta3.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta3.Sort(dgw_cta3.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta3.RowCount - 1))
                    If (txt_cta3.Text.ToLower = dgw_cta3.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta3.Text = dgw_cta3.Item(0, i).Value.ToString
                        txt_desc_cta3.Text = dgw_cta3.Item(1, i).Value.ToString
                        btn_consulta3.Focus()
                        Return
                    End If
                    If (txt_cta3.Text.ToLower = Strings.Mid((dgw_cta3.Item(0, i).Value), 1, Strings.Len(txt_cta3.Text)).ToLower) Then
                        dgw_cta3.CurrentCell = (dgw_cta3.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta3.Visible = True
                dgw_cta3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta3.Text) <> "")) Then
            If (dgw_cta3.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta3.Sort(dgw_cta3.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta3.RowCount - 1))
                    If (txt_desc_cta3.Text.ToLower = Strings.Mid((dgw_cta3.Item(1, i).Value), 1, Strings.Len(txt_desc_cta3.Text)).ToLower) Then
                        dgw_cta3.CurrentCell = (dgw_cta3.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta3.Visible = True
                dgw_cta3.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta3.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta3.Text = (dgw_cta3.Item(0, dgw_cta3.CurrentRow.Index).Value)
            txt_desc_cta3.Text = (dgw_cta3.Item(1, dgw_cta3.CurrentRow.Index).Value)
            Panel_cta3.Visible = False
            'KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta3.Visible = False
            txt_cta3.Clear()
            txt_desc_cta3.Clear()
            txt_cta3.Focus()
        End If
    End Sub
    Private Sub btn_consulta3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta3.Click
        If txt_cta3.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta3.Focus() : Exit Sub
        COD_MES3 = obj.COD_MES(cbo_mes3.Text)

        '---------------------------------------------------------------------------------
        If obj.VERIFICAR_CIERRE_PERIODO(cbo_año3.Text, obj.COD_MES(cbo_mes3.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw3.Rows.Clear()
            cbo_mes3.Focus()
            Exit Sub
        ElseIf obj.VERIFICAR_BLOKEO_PERIODO(cbo_año3.Text, obj.COD_MES(cbo_mes3.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw3.Rows.Clear()
            cbo_mes3.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA3()
            G3.Enabled = False
            BTN_MOD_GESTION.Focus()
        End If
        'MOSTRAR_CONSULTA3()
        'G3.Enabled = False
        'BTN_MOD_GESTION.Focus()
    End Sub
    Sub MOSTRAR_CONSULTA3()
        dgw3.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_GESTION_PAGAR", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw3.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_MOD_GESTION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MOD_GESTION.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE3 = dgw3.CurrentRow.Index
        LIMPIAR_DET3()
        CARGAR_DET3()
        Panel4.Visible = True
        txt_doc3.Focus()
    End Sub
    Sub LIMPIAR_DET3()
        btn_mod23.Enabled = True
        btn_lim3.Enabled = True
        txt_cod_per3.Clear()
        txt_desc_per3.Clear()
        txt_doc_per3.Clear()
        txt_doc3.Clear()
        txt_nro_doc3.Clear()
        txt_im_inicial.Clear()
        txt_im_doc.Clear()
        cbo_moneda3.SelectedIndex = -1
        txt_cod_per3.Enabled = False
        txt_desc_per3.Enabled = False
        txt_doc3.Enabled = False
        txt_nro_doc3.Enabled = False
        txt_doc_per3.Enabled = False
        ch_per3.Checked = False
    End Sub
    Sub CARGAR_DET3()
        txt_cod_per3.Text = dgw3.Item(2, dgw3.CurrentRow.Index).Value.ToString
        txt_desc_per3.Text = dgw3.Item(3, dgw3.CurrentRow.Index).Value.ToString
        txt_doc_per3.Text = dgw3.Item(4, dgw3.CurrentRow.Index).Value.ToString
        txt_doc3.Text = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
        txt_nro_doc3.Text = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
        txt_im_inicial.Text = dgw3.Item(5, dgw3.CurrentRow.Index).Value.ToString
        txt_im_doc.Text = dgw3.Item(6, dgw3.CurrentRow.Index).Value.ToString
        cod_mon3 = dgw3.Item(7, dgw3.CurrentRow.Index).Value.ToString
        cbo_moneda3.Text = obj.DESC_MONEDA(cod_mon3)
        TXT_CTA33.Text = txt_cta3.Text
        '----------------------------------------------------------------
        DOC_PER03 = dgw3.Item(9, dgw3.CurrentRow.Index).Value.ToString
        SUCURSAL03 = dgw3.Item(8, dgw3.CurrentRow.Index).Value.ToString
    End Sub
    Private Sub BTN_LIMP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP3.Click
        txt_cta3.Clear()
        txt_desc_cta3.Clear()
        dgw3.Rows.Clear()
        G3.Enabled = True
        txt_cta3.Focus()
    End Sub
    Private Sub txt_cod_per2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per2.LostFocus
        If (Strings.Trim(txt_cod_per2.Text) <> "") Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per2.Text.ToLower = dgw_per2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per2.Text = dgw_per2.Item(0, i).Value.ToString
                        txt_desc_per2.Text = dgw_per2.Item(1, i).Value.ToString
                        txt_doc_per2.Text = dgw_per2.Item(2, i).Value.ToString
                        Return
                    End If
                    If (txt_cod_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(0, i).Value), 1, Strings.Len(txt_cod_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per2.Text) <> "")) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla pendientes por cobrar", "Mensaje")
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(1, i).Value), 1, Strings.Len(txt_desc_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per2.Text) <> "")) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje")
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(2, i).Value), 1, Strings.Len(txt_doc_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_per2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per2.Text = (dgw_per2.Item(0, dgw_per2.CurrentRow.Index).Value)
            txt_desc_per2.Text = (dgw_per2.Item(1, dgw_per2.CurrentRow.Index).Value)
            txt_doc_per2.Text = (dgw_per2.Item(2, dgw_per2.CurrentRow.Index).Value)
            Panel_per2.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per2.Clear()
            txt_desc_per2.Clear()
            txt_doc_per2.Clear()
            Panel_per2.Visible = False
            txt_cod_per2.Focus()
        End If
    End Sub
    Private Sub txt_cod_per3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per3.LostFocus
        If (Strings.Trim(txt_cod_per3.Text) <> "") Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_per3.Sort(dgw_per3.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per3.Text.ToLower = dgw_per3.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per3.Text = dgw_per3.Item(0, i).Value.ToString
                        txt_desc_per3.Text = dgw_per3.Item(1, i).Value.ToString
                        txt_doc_per3.Text = dgw_per3.Item(2, i).Value.ToString
                        Return
                    End If
                    If (txt_cod_per3.Text.ToLower = Strings.Mid((dgw_per3.Item(0, i).Value), 1, Strings.Len(txt_cod_per3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per3.Text) <> "")) Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla pendientes por cobrar", "Mensaje")
            Else
                dgw_per3.Sort(dgw_per3.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_per3.Text.ToLower = Strings.Mid((dgw_per3.Item(1, i).Value), 1, Strings.Len(txt_desc_per3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per3.Text) <> "")) Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje")
            Else
                dgw_per3.Sort(dgw_per3.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per3.Text.ToLower = Strings.Mid((dgw_per3.Item(2, i).Value), 1, Strings.Len(txt_doc_per3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_per3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per3.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per3.Text = (dgw_per3.Item(0, dgw_per3.CurrentRow.Index).Value)
            txt_desc_per3.Text = (dgw_per3.Item(1, dgw_per3.CurrentRow.Index).Value)
            txt_doc_per3.Text = (dgw_per3.Item(2, dgw_per3.CurrentRow.Index).Value)
            Panel_per3.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per3.Clear()
            txt_desc_per3.Clear()
            txt_doc_per3.Clear()
            Panel_per3.Visible = False
            txt_cod_per3.Focus()
        End If
    End Sub
    Private Sub cancel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel3.Click
        Panel4.Visible = False
        BTN_MOD_GESTION.Focus()
    End Sub
    Private Sub btn_lim3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_lim3.Click
        txt_doc3.Clear()
        txt_nro_doc3.Clear()
        txt_im_inicial.Clear()
        txt_im_doc.Clear()
        cbo_moneda3.SelectedIndex = -1
        txt_doc3.Focus()
    End Sub
    Private Sub btn_mod23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mod23.Click
        cod_mon3 = ""
        If (cbo_moneda3.SelectedIndex <> -1) Then
            cod_mon3 = obj.COD_MONEDA(cbo_moneda3.Text)
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_GESTION_PAGAR_CONSULTA", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_doc3.Text
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc3.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per3.Text
            comand1.Parameters.Add("@IMP_INI", SqlDbType.Decimal).Value = txt_im_inicial.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_im_doc.Text
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cod_mon3
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
            comand1.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = SUCURSAL03
            comand1.Parameters.Add("@CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DOC_PER03
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = TXT_CTA33.Text
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw3.Item(7, dgw3.CurrentRow.Index).Value = cod_mon3
        dgw3.Item(0, dgw3.CurrentRow.Index).Value = txt_doc3.Text
        dgw3.Item(1, dgw3.CurrentRow.Index).Value = txt_nro_doc3.Text
        dgw3.Item(5, dgw3.CurrentRow.Index).Value = txt_im_inicial.Text
        dgw3.Item(6, dgw3.CurrentRow.Index).Value = txt_im_doc.Text
        MOSTRAR_CONSULTA3() : FOCO_NUEVO_REG3()
        Panel4.Visible = False
        BTN_MOD_GESTION.Focus()
        'dgw3.CurrentCell = (dgw3.Rows.Item(INDICE3).Cells.Item(1))
    End Sub
    Sub FOCO_NUEVO_REG3()
        Dim I, CONT As Integer
        CONT = dgw3.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc3.Text
        For I = 0 To CONT
            If NRO_OC = dgw3.Item(1, I).Value.ToString.ToLower Then
                dgw3.CurrentCell = (dgw3.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub cbo_año1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_año1.SelectedIndexChanged
        CARGAR_CUENTA1()
    End Sub
    Private Sub cbo_año2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_año2.SelectedIndexChanged
        CARGAR_CUENTA2()
    End Sub
    Private Sub cbo_año3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_año3.SelectedIndexChanged
        CARGAR_CUENTA3()
    End Sub
    Private Sub cbo_año4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año4.SelectedIndexChanged
        CARGAR_CUENTA4()
    End Sub
    Private Sub txt_cta4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta4.LostFocus
        If (Strings.Trim(txt_cta4.Text) <> "") Then
            If (dgw_cta4.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta4.Sort(dgw_cta4.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta4.RowCount - 1))
                    If (txt_cta4.Text.ToLower = dgw_cta4.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta4.Text = dgw_cta4.Item(0, i).Value.ToString
                        txt_desc_cta4.Text = dgw_cta4.Item(1, i).Value.ToString
                        TextBox15.Focus()
                        Return
                    End If
                    If (txt_cta4.Text.ToLower = Strings.Mid((dgw_cta4.Item(0, i).Value), 1, Strings.Len(txt_cta4.Text)).ToLower) Then
                        dgw_cta4.CurrentCell = (dgw_cta4.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta4.Visible = True
                dgw_cta4.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta4.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta4.Text) <> "")) Then
            If (dgw_cta4.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta4.Sort(dgw_cta4.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta4.RowCount - 1))
                    If (txt_desc_cta4.Text.ToLower = Strings.Mid((dgw_cta4.Item(1, i).Value), 1, Strings.Len(txt_desc_cta4.Text)).ToLower) Then
                        dgw_cta4.CurrentCell = (dgw_cta4.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta4.Visible = True
                dgw_cta4.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta4.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta4.Text = (dgw_cta4.Item(0, dgw_cta4.CurrentRow.Index).Value)
            txt_desc_cta4.Text = (dgw_cta4.Item(1, dgw_cta4.CurrentRow.Index).Value)
            Panel_cta4.Visible = False
            TextBox15.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta4.Visible = False
            txt_cta4.Clear()
            txt_desc_cta4.Clear()
            txt_cta4.Focus()
        End If
    End Sub
    Private Sub btn_consulta4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta4.Click
        If txt_cta4.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta4.Focus() : Exit Sub
        COD_MES4 = obj.COD_MES(cbo_mes4.Text)
        'MOSTRAR_CONSULTA4()
        'GroupBox6.Enabled = False
        'BTN_MOD_PEND.Focus()
        '---------------------------------------------------------------------------------
        If obj.VERIFICAR_CIERRE_PERIODO(cbo_año4.Text, obj.COD_MES(cbo_mes4.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw4.Rows.Clear()
            cbo_mes4.Focus()
            Exit Sub
        ElseIf obj.VERIFICAR_BLOKEO_PERIODO(cbo_año4.Text, obj.COD_MES(cbo_mes4.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw4.Rows.Clear()
            cbo_mes4.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA4()
            GroupBox6.Enabled = False
            BTN_MOD_PEND.Focus()
        End If
    End Sub
    Sub MOSTRAR_CONSULTA4()
        dgw4.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_PCTAS_PAGAR", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año4.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES4
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta4.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw4.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_salir4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir4.Click
        main(31) = 0
        Close()
    End Sub
    Private Sub BTN_LIMP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP4.Click
        txt_cta4.Clear()
        txt_desc_cta4.Clear()
        dgw4.Rows.Clear()
        GroupBox6.Enabled = True
        txt_cta4.Focus()
    End Sub
    Private Sub BTN_MOD_PEND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MOD_PEND.Click
        Try
            Dim i As Integer = dgw4.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elelgir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE4 = dgw4.CurrentRow.Index
        LIMPIAR_DET4()
        CARGAR_DET4()
        Panel5.Visible = True
        txt_doc4.Focus()
    End Sub
    Sub LIMPIAR_DET4()
        'txt_cta01.Clear()
        btn_mod24.Enabled = True
        btn_lim4.Enabled = True
        txt_cod_per4.Clear()
        txt_desc_per4.Clear()
        txt_doc_per4.Clear()
        txt_doc4.Clear()
        txt_nro_doc4.Clear()
        txt_im_doc_pen.Clear()
        txt_im_inicial_pen.Clear()
        cbo_moneda4.SelectedIndex = -1
        txt_cod_per4.Enabled = False
        txt_desc_per4.Enabled = False
        txt_doc_per4.Enabled = False
        ch_per4.Checked = False
        txt_doc4.Enabled = False
        txt_nro_doc4.Enabled = False
    End Sub
    Sub CARGAR_DET4()
        txt_cod_per4.Text = dgw4.Item(2, dgw4.CurrentRow.Index).Value.ToString
        txt_desc_per4.Text = dgw4.Item(3, dgw4.CurrentRow.Index).Value.ToString
        txt_doc_per4.Text = dgw4.Item(4, dgw4.CurrentRow.Index).Value.ToString
        txt_doc4.Text = dgw4.Item(0, dgw4.CurrentRow.Index).Value.ToString
        txt_nro_doc4.Text = dgw4.Item(1, dgw4.CurrentRow.Index).Value.ToString
        txt_im_doc_pen.Text = dgw4.Item(5, dgw4.CurrentRow.Index).Value.ToString
        cod_mon4 = dgw4.Item(6, dgw4.CurrentRow.Index).Value.ToString
        cbo_moneda4.Text = obj.DESC_MONEDA(cod_mon4)
        TXT_CTA34.Text = txt_cta4.Text
        txt_im_inicial_pen.Text = dgw4.Item(7, dgw4.CurrentRow.Index).Value.ToString
        'ITEM0 = dgw1.Item(23, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Private Sub btn_lim4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lim4.Click
        txt_doc4.Clear()
        txt_nro_doc4.Clear()
        txt_im_inicial_pen.Clear()
        txt_im_doc_pen.Clear()
        cbo_moneda4.SelectedIndex = -1
        txt_doc4.Focus()
    End Sub

    Private Sub cancel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel4.Click
        Panel5.Visible = False
        BTN_MOD_PEND.Focus()
    End Sub

    Private Sub btn_mod24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mod24.Click
        cod_mon4 = ""
        If (cbo_moneda4.SelectedIndex <> -1) Then
            cod_mon4 = obj.COD_MONEDA(cbo_moneda4.Text)
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_PCTAS_PAGAR_CONSULTA", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_doc4.Text
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc4.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per4.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_im_doc_pen.Text
            comand1.Parameters.Add("@IMP_INI", SqlDbType.Decimal).Value = txt_im_inicial_pen.Text
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cod_mon4
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año4.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES4
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = TXT_CTA34.Text
            comand1.Parameters.Add("@CUENTA", SqlDbType.VarChar).Value = txt_cta4.Text
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw4.Item(6, dgw4.CurrentRow.Index).Value = cod_mon4
        dgw4.Item(0, dgw4.CurrentRow.Index).Value = txt_doc4.Text
        dgw4.Item(1, dgw4.CurrentRow.Index).Value = txt_nro_doc4.Text
        dgw4.Item(5, dgw4.CurrentRow.Index).Value = txt_im_doc_pen.Text
        dgw4.Item(7, dgw4.CurrentRow.Index).Value = txt_im_inicial_pen.Text
        MOSTRAR_CONSULTA4() : FOCO_NUEVO_REG4()
        Panel5.Visible = False
        BTN_MOD_PEND.Focus()
        'dgw4.CurrentCell = (dgw4.Rows.Item(INDICE4).Cells.Item(1))
    End Sub
    Sub FOCO_NUEVO_REG4()
        Dim I, CONT As Integer
        CONT = dgw4.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc4.Text
        For I = 0 To CONT
            If NRO_OC = dgw4.Item(1, I).Value.ToString.ToLower Then
                dgw4.CurrentCell = (dgw4.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub txt_im_inicial_pen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_im_inicial_pen.KeyPress
        e.Handled = Numero(e, txt_im_inicial_pen)
    End Sub
    Private Sub txt_im_inicial_pen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_im_inicial_pen.LostFocus
        Try
            txt_im_inicial_pen.Text = obj.HACER_DECIMAL(txt_im_inicial_pen.Text)
        Catch ex As Exception
            'HALLAR_TOTAL_DOC01()
        End Try
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
    Private Sub txt_im_doc_pen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_im_doc_pen.KeyPress
        e.Handled = Numero(e, txt_im_doc_pen)
    End Sub
    Private Sub txt_im_doc_pen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_im_doc_pen.LostFocus
        Try
            txt_im_doc_pen.Text = obj.HACER_DECIMAL(txt_im_doc_pen.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_MOD.Select()
            Return
        End Try
        LIMPIAR_DET()
        CARGAR_DET()
        Dim COD_CLASE As String = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        Panel1.Visible = True
        btn_mod2.Enabled = False
        btn_lim.Enabled = False

        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR: " & COD_CLASE & " " & dgw1.Item(3, dgw1.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_PENDIENTES_PAGAR", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
                CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
                CMD.Parameters.Add("@INDICE", SqlDbType.Int).Value = dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA()
            Panel1.Visible = False
            BTN_MOD.Select()
        Else
        End If
        'dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_MOD_ANA.Select()
            Return
        End Try
        LIMPIAR_DET2()
        CARGAR_DET2()
        Dim COD_CLASE As String = dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString
        Panel3.Visible = True
        btn_mod22.Enabled = False
        btn_lim2.Enabled = False
        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR: " & COD_CLASE & " " & dgw2.Item(3, dgw2.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_ANALISIS_PAGAR", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES2

                CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw2.Item(8, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw2.Item(9, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw2.Item(10, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw2.Item(1, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw2.Item(2, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw2.Item(11, dgw2.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta2.Text
                CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = dgw2.Item(12, dgw2.CurrentRow.Index).Value
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA2()
            Panel3.Visible = False
            BTN_MOD_ANA.Select()
        Else
        End If
        'dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index)
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_MOD_GESTION.Select()
            Return
        End Try
        LIMPIAR_DET3()
        CARGAR_DET3()
        Dim COD_CLASE As String = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
        Panel4.Visible = True
        btn_mod23.Enabled = False
        btn_lim3.Enabled = False
        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR: " & COD_CLASE & " " & dgw3.Item(3, dgw3.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_GESTION_PAGAR", con)
                CMD.CommandType = CommandType.StoredProcedure

                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw3.Item(8, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw3.Item(2, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw3.Item(0, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw3.Item(1, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw3.Item(9, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA3()
            Panel4.Visible = False
            BTN_MOD_GESTION.Select()
        Else
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim i As Integer = dgw4.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_MOD_PEND.Select()
            Return
        End Try
        LIMPIAR_DET4()
        CARGAR_DET4()
        Dim COD_CLASE As String = dgw4.Item(1, dgw4.CurrentRow.Index).Value.ToString
        Panel5.Visible = True
        btn_mod24.Enabled = False
        btn_lim4.Enabled = False
        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR: " & COD_CLASE & " " & dgw4.Item(3, dgw4.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_GESTION_PAGAR", con)
                CMD.CommandType = CommandType.StoredProcedure

                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw4.Item(9, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw4.Item(2, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw4.Item(0, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw4.Item(1, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw4.Item(8, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta4.Text
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año4.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES4
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA4()
            Panel5.Visible = False
            BTN_MOD_PEND.Select()
        Else
        End If
    End Sub

    Private Sub txt_im_inicial_pen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_im_inicial_pen.TextChanged

    End Sub
End Class