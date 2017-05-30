Imports System.Data.SqlClient
Public Class CONSULTA_ANA_PENDIENT_OTROS
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

                cbo_año2.Items.Add(Rs3.GetString(0))

            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_ANA_PENDIENT_PAGAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_mes2.Text = obj.DESC_MES(MES)
        CARGAR_AÑO()
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        'CARGAR_CUENTA2()
        LLENAR_CBO_AUXILIAR()
        PERSONAS()
        CARGAR_MONEDA()

    End Sub
    Sub CARGAR_MONEDA()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI

        cbo_moneda2.DataSource = DT
        cbo_moneda2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda2.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda2.SelectedIndex = -1
       
    End Sub
    Sub PERSONAS()
       
        Try
            dgw_per2.DataSource = obj.MOSTRAR_PERSONAS_PAGAR

            dgw_per2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per2.Columns.Item(0).Width = 50
            dgw_per2.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
       
    End Sub
    Sub LLENAR_CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
      
        '------------------------------------------
        cbo_auxiliar2.DataSource = DT
        cbo_auxiliar2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar2.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar2.SelectedIndex = -1

    End Sub
   
    Sub LLENAR_CBO_COMPROBANTE2()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX2)
        cbo_comprobante2.DataSource = DT
        cbo_comprobante2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_comprobante2.ValueMember = DT.Columns.Item(1).ToString
        cbo_comprobante2.SelectedIndex = -1
        If (cbo_comprobante2.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
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
   
   
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir2.Click
        main(41) = 0
        Close()
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
   
   
    Sub MOSTRAR_CONSULTA2()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_ANALISIS_OTRAS", con)
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
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
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
            Dim comand1 As New SqlCommand("MODIFICAR_ANALISIS_OTROS_CONSULTA", con)
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
        MOSTRAR_CONSULTA2() : FOCO_NUEVO_REG()
        Panel3.Visible = False
        BTN_MOD_ANA.Focus()
        'dgw2.CurrentCell = (dgw2.Rows.Item(INDICE2).Cells.Item(1))
    End Sub
    Sub FOCO_NUEVO_REG()
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
   Private Sub cbo_año2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_año2.SelectedIndexChanged
        CARGAR_CUENTA2()
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
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_ANALISIS_OTROS", con)
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

    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes2.SelectedIndexChanged

    End Sub

    Private Sub CH_AUX2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH_AUX2.CheckedChanged
        If CH_AUX2.Checked = True Then
            cbo_auxiliar2.Enabled = True
        Else
            cbo_auxiliar2.SelectedIndex = -1
            cbo_auxiliar2.Enabled = False
        End If
    End Sub

    Private Sub ch_com2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_com2.CheckedChanged
        If ch_com2.Checked = True Then
            cbo_comprobante2.Enabled = True
        Else
            cbo_comprobante2.SelectedIndex = -1
            cbo_comprobante2.Enabled = False
        End If
    End Sub
End Class