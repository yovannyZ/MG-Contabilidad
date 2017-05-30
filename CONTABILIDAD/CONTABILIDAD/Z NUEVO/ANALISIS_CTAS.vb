Imports System.Data.SqlClient
Public Class ANALISIS_CTAS
    Dim OBJ As New Class1
    Dim cod_mes As String
    Private Sub ANALISIS_CTAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ANALISIS_CTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        'dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        cbo_cta.Focus()
        cbo_cta.SelectedIndex = 0
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                'verificacion
                cbo_año_v.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTA2()
        '-----------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año.Text)
            dgw_cta.DataSource = (DT)
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub CARGAR_CUENTA()
        '-----------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año_v.Text)
            dgw_cta_v.DataSource = (DT)
            dgw_cta_v.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta_v.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub DGW_PERSONAS()
        If cbo_cta.SelectedIndex = 0 Then
            Try
                dgw_per.DataSource = (OBJ.MOSTRAR_PERSONAS_COBRAR)
                dgw_per.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
                dgw_per.Columns.Item(0).Width = (50)
                dgw_per.Columns.Item(1).Width = (&HEB)
            Catch ex As Exception
                MsgBox(ex.Message)

                'MsgBox(ex.Message)
                MessageBox.Show("Ocurrió un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        ElseIf cbo_cta.SelectedIndex = 1 Then
            Try
                dgw_per.DataSource = (OBJ.MOSTRAR_PERSONAS_PAGAR)
                dgw_per.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
                dgw_per.Columns.Item(0).Width = (50)
                dgw_per.Columns.Item(1).Width = (&HEB)
            Catch ex As Exception
                MsgBox(ex.Message)

                'MsgBox(ex.Message)
                MessageBox.Show("Ocurrió un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try
        End If
      
    End Sub
    Private Sub txt_cod_per0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per.LostFocus
        If (Strings.Trim(txt_cod_per.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_cod_per.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        Return
                    End If
                    If (txt_cod_per.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
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
            txt_cod_per.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            Panel_per.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per.Visible = False
            txt_cod_per.Focus()
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per.Focus()
        End If
    End Sub
    Private Sub txt_cta2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta.LostFocus
        If (Strings.Trim(txt_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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
    Private Sub txt_desc_cta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
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
    Private Sub dgw_cta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            Panel_cta.Visible = False
            'KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_cta.Clear()
            txt_desc_cta.Clear()
            txt_cta.Focus()
        End If
    End Sub
    Private Sub btn_salir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir2.Click
        main(109) = 0
        Close()
    End Sub

    Private Sub btn_consulta2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta2.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If txt_cod_per.Text.Trim = "" Then MessageBox.Show("Debe elegir Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per.Focus() : Exit Sub
        If txt_cta.Text.Trim = "" Then MessageBox.Show("Debe elgir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub



      
        MOSTRAR_CONSULTA()
        G2.Enabled = False
        BTN_MOD_ANA.Focus()


    End Sub
    Sub MOSTRAR_CONSULTA()
        dgw.Rows.Clear()
        Dim ST_PDTE As String
        If st_pendiente.Checked = True Then
            ST_PDTE = "0"
        Else
            ST_PDTE = "1"
        End If
        Dim tipo_cta As String
        If cbo_cta.SelectedIndex = 0 Then
            tipo_cta = "C"
        ElseIf cbo_cta.SelectedIndex = 1 Then
            tipo_cta = "P"
        End If
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_ANALISIS_DE_CTAS", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per.Text.Trim
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo_cta
            PROG_01.Parameters.Add("@ST_PENDIENTE", SqlDbType.Char).Value = ST_PDTE
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged
        CARGAR_CUENTA2()
    End Sub

    Private Sub BTN_LIMP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP2.Click
        'txt_cta.Clear()
        'txt_desc_cta.Clear()
        dgw.Rows.Clear()
        G2.Enabled = True
        'txt_cta.Focus()
        txt_cod_per.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        txt_cod_per.Focus()
    End Sub
    Sub limpiar()
        txt_cod_doc.Clear()
        ch_conci.Checked = False
        txt_nro_doc.Clear()
        txt_item.Clear()
        ch_importe.Checked = False
        GroupBox1.Enabled = False
    End Sub

    Private Sub ch_importe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_importe.CheckedChanged
        If ch_importe.Checked = True Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub BTN_MOD_ANA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MOD_ANA.Click
        Try
            Dim i As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        limpiar()
        CARGAR_DET()
        Panel3.Visible = True
        txt_cod_doc.Focus()
    End Sub
    Sub CARGAR_DET()
        txt_cod_doc.Text = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        txt_nro_doc.Text = dgw.Item(1, dgw.CurrentRow.Index).Value.ToString
        txt_item.Text = dgw.Item(2, dgw.CurrentRow.Index).Value.ToString
        txtItemAnte.Text = dgw.Item(2, dgw.CurrentRow.Index).Value

        txt_im_soles.Text = dgw.Item(6, dgw.CurrentRow.Index).Value.ToString
        txt_im_dolares.Text = dgw.Item(7, dgw.CurrentRow.Index).Value.ToString
        Dim ch_concil As String
        ch_concil = dgw.Item(10, dgw.CurrentRow.Index).Value.ToString
        If ch_concil = "1" Then ch_conci.Checked = True Else ch_conci.Checked = False
    End Sub

    Private Sub btn_lim2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lim2.Click
        limpiar()
    End Sub

    Private Sub cancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel2.Click
        Panel3.Visible = False
    End Sub

    Private Sub btn_mod22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mod22.Click
        Dim ch_concil As String
        If ch_conci.Checked = True Then ch_concil = "1" Else ch_concil = "0"
        Dim tipo_cta As String
        If cbo_cta.SelectedIndex = 0 Then
            tipo_cta = "C"
        ElseIf cbo_cta.SelectedIndex = 1 Then
            tipo_cta = "P"
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_ANALISIS_DE_CTAS", con)
            comand1.CommandType = (CommandType.StoredProcedure)

            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = dgw.Item(12, dgw.CurrentRow.Index).Value
            comand1.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw.Item(3, dgw.CurrentRow.Index).Value
            comand1.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw.Item(4, dgw.CurrentRow.Index).Value
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw.Item(5, dgw.CurrentRow.Index).Value
            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_cod_doc.Text
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per.Text
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = txt_doc_per.Text
            comand1.Parameters.Add("@ITEM", SqlDbType.Char).Value = txt_item.Text
            comand1.Parameters.Add("@ITEM_ANTE", SqlDbType.Char).Value = txtItemAnte.Text
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
            comand1.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = txt_im_soles.Text
            comand1.Parameters.Add("@IMP_D", SqlDbType.Decimal).Value = txt_im_dolares.Text
            comand1.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char).Value = ch_concil
            comand1.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo_cta
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        MOSTRAR_CONSULTA()
        Panel3.Visible = False
        BTN_MOD_ANA.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_MOD_ANA.Select()
            Return
        End Try
        Dim tipo_cta As String
        If cbo_cta.SelectedIndex = 0 Then
            tipo_cta = "C"
        ElseIf cbo_cta.SelectedIndex = 1 Then
            tipo_cta = "P"
        End If
        Dim COD_CLASE As String = dgw.Item(1, dgw.CurrentRow.Index).Value.ToString

        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR N° DOC: " & COD_CLASE), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_ANALISIS_DE_CTAS", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = dgw.Item(12, dgw.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw.Item(3, dgw.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw.Item(4, dgw.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw.Item(5, dgw.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_cod_doc.Text
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per.Text
                CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = txt_doc_per.Text
                CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = txt_item.Text
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
                CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo_cta
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA()
            Panel3.Visible = False
            BTN_MOD_ANA.Select()
        Else
        End If
        'dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index)
    End Sub

    Private Sub cbo_cta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_cta.SelectedIndexChanged
        DGW_PERSONAS()
    End Sub
    Sub MOSTRAR_CONSULTA_DUPLICADAS()
        dgw_v.Rows.Clear()
        Dim ST_PDTE As String
        If st_pendiente.Checked = True Then
            ST_PDTE = "0"
        Else
            ST_PDTE = "1"
        End If
        Dim tipo_cta As String = ""
        If cbo_cuenta_v.SelectedIndex = 0 Then
            tipo_cta = "C"
        ElseIf cbo_cuenta_v.SelectedIndex = 1 Then
            tipo_cta = "P"
        End If
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_ANALISIS_DE_CTAS_DUPLICADAS", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_v.Text
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta_v.Text
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo_cta
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_v.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta2_v.Click
        If cbo_año_v.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If txt_cod_cta_v.Text.Trim = "" Then MessageBox.Show("Debe elgir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub

        MOSTRAR_CONSULTA_DUPLICADAS()
        G2_v.Enabled = False
        'BTN_MOD_ANA.Focus()
    End Sub

    Private Sub txt_desc_cta_v_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta_v.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_v.Text) <> "")) Then
            If (dgw_cta_v.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta_v.Sort(dgw_cta_v.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_v.RowCount - 1))
                    If (txt_desc_cta_v.Text.ToLower = Strings.Mid((dgw_cta_v.Item(1, i).Value), 1, Strings.Len(txt_desc_cta_v.Text)).ToLower) Then
                        dgw_cta_v.CurrentCell = (dgw_cta_v.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_cta_v.Visible = True
                dgw_cta_v.Focus()
            End If
        End If
    End Sub

    Private Sub cbo_año_v_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año_v.SelectedIndexChanged
        CARGAR_CUENTA()
    End Sub

    Private Sub txt_cod_cta_v_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta_v.LostFocus
        If (Strings.Trim(txt_cod_cta_v.Text) <> "") Then
            If (dgw_cta_v.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta_v.Sort(dgw_cta_v.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_v.RowCount - 1))
                    If (txt_cod_cta_v.Text.ToLower = dgw_cta_v.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta_v.Text = dgw_cta_v.Item(0, i).Value.ToString
                        txt_desc_cta_v.Text = dgw_cta_v.Item(1, i).Value.ToString
                        btn_consulta2_v.Focus()
                        Return
                    End If
                    If (txt_cod_cta_v.Text.ToLower = Strings.Mid((dgw_cta_v.Item(0, i).Value), 1, Strings.Len(txt_cod_cta_v.Text)).ToLower) Then
                        dgw_cta_v.CurrentCell = (dgw_cta_v.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_cta_v.Visible = True
                dgw_cta_v.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_cta_v_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta_v.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta_v.Text = (dgw_cta_v.Item(0, dgw_cta_v.CurrentRow.Index).Value)
            txt_desc_cta_v.Text = (dgw_cta_v.Item(1, dgw_cta_v.CurrentRow.Index).Value)
            panel_cta_v.Visible = False
            'KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cta_v.Visible = False
            txt_cod_cta_v.Clear()
            txt_desc_cta_v.Clear()
            txt_cod_cta_v.Focus()
        End If
    End Sub
    Sub limpiar_verificacion()
        txt_cod_cta_v.Clear()
        txt_desc_cta_v.Clear()
        G2_v.Enabled = True
        dgw_v.Rows.Clear()
        txt_cod_cta_v.Focus()
    End Sub
    Private Sub btn_limpiar_v_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar_v.Click
        limpiar_verificacion()
    End Sub

    Private Sub btn_salir_v_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_v.Click
        main(109) = 0
        Close()
    End Sub

    Private Sub txt_desc_cta_v_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_desc_cta_v.LostFocus

    End Sub
End Class