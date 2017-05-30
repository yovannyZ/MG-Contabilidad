Imports System.Data.SqlClient
Public Class REPORTE_CXP2_CANC
    Dim COD_CLASE1, STATUS_SUC2, STATUS_SUC1, STATUS_PER2, STATUS_PER1, COD_CLASE2, COD_PER1, COD_PER2, COD_SUCURSAL1, COD_SUCURSAL2 As String
    Dim TIPO_REP As String
    Dim OBJ As New Class1
    Dim ofr1 As New REP_CXP_CANC1
    Dim REP As New REP_CXP_CANC113
 Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If ch_si1.Checked And Me.CBO_SUCURSAL1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_SUCURSAL1.Focus() : Exit Sub
        If ch_per1.Checked And Trim(TXT_COD1.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : TXT_COD1.Focus() : Exit Sub
        If (DateTime.Compare(dtp01.Value, dtp02.Value) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub
        If ch_si1.Checked Then
            STATUS_SUC1 = "0"
            COD_SUCURSAL1 = CBO_SUCURSAL1.SelectedValue.ToString
        Else
            STATUS_SUC1 = "1"
            COD_SUCURSAL1 = "  "
        End If
        If ch_per1.Checked Then
            STATUS_PER1 = "0"
            COD_PER1 = TXT_COD1.Text
        Else
            STATUS_PER1 = "1"
            COD_PER1 = "  "
        End If
        TIPO_REP = "02"
        '------------------------
        ofr1.TIPO_REP = TIPO_REP
        ofr1.UBICAR_REPORTE()
        '------------------------
        ofr1.CREAR_REPORTE(dtp01.Value.ToString.Substring(0, 10), dtp02.Value.ToString.Substring(0, 10))
        ofr1.parametros(COD_SUCURSAL1, COD_PER1, STATUS_SUC1, STATUS_PER1, dtp01.Value, dtp02.Value, "1", " ", "", "")
        ofr1.ShowDialog()
    End Sub
    Private Sub btn_pantalla2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla2.Click
        If ch_si2.Checked And cbo_sucursal2.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_sucursal2.Focus() : Exit Sub
        If ch_per2.Checked And Trim(txt_cod2.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod2.Focus() : Exit Sub
        If (DateTime.Compare(dtp03.Value, dtp04.Value) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub
        If ch_si2.Checked Then
            STATUS_SUC2 = "0"
            COD_SUCURSAL2 = cbo_sucursal2.SelectedValue.ToString
        Else
            STATUS_SUC2 = "1"
            COD_SUCURSAL2 = "  "
        End If
        '--------------------------------------------------------------
        If ch_per2.Checked Then
            STATUS_PER2 = "0"
            COD_PER2 = txt_cod2.Text
        Else
            STATUS_PER2 = "1"
            COD_PER2 = "  "
        End If
        TIPO_REP = "01"
        '------------------------
        ofr1.TIPO_REP = TIPO_REP
        ofr1.UBICAR_REPORTE()
        '------------------------
        ofr1.CREAR_REPORTE(dtp03.Value.ToString.Substring(0, 10), dtp04.Value.ToString.Substring(0, 10))
        ofr1.parametros(COD_SUCURSAL2, COD_PER2, STATUS_SUC2, STATUS_PER2, dtp03.Value, dtp04.Value, "1", " ", "", "")
        ofr1.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click, btn_salir2.Click, Button4.Click
        main(2) = 0
        Me.Close()
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            dgw_per1.DataSource = DT
            dgw_per1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per1.Columns.Item(0).Width = &H37
            dgw_per1.Columns.Item(1).Width = 240
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            dgw_per2.DataSource = DT
            dgw_per2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per2.Columns.Item(0).Width = &H37
            dgw_per2.Columns.Item(1).Width = 240
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SUCURSAL()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_SUCURSAL
        CBO_SUCURSAL1.DataSource = DT
        CBO_SUCURSAL1.DisplayMember = DT.Columns.Item(0).ToString
        CBO_SUCURSAL1.ValueMember = DT.Columns.Item(1).ToString
        CBO_SUCURSAL1.SelectedIndex = -1
        cbo_sucursal2.DataSource = DT
        cbo_sucursal2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_sucursal2.ValueMember = DT.Columns.Item(1).ToString
        cbo_sucursal2.SelectedIndex = -1

        cbo_sucursal3.DataSource = DT
        cbo_sucursal3.DisplayMember = DT.Columns.Item(0).ToString
        cbo_sucursal3.ValueMember = DT.Columns.Item(1).ToString
        cbo_sucursal3.SelectedIndex = -1
    End Sub
    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            TXT_COD1.Enabled = True
            TXT_DESC1.Enabled = True
            txt_doc_per1.Enabled = True
        Else
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            txt_doc_per1.Clear()
            TXT_COD1.Enabled = False
            TXT_DESC1.Enabled = False
            txt_doc_per1.Enabled = False
        End If
    End Sub
    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked Then
            txt_cod2.Enabled = True
            txt_desc2.Enabled = True
            txt_doc_per2.Enabled = True
        Else
            txt_cod2.Clear()
            txt_desc2.Clear()
            txt_doc_per2.Clear()
            txt_cod2.Enabled = False
            txt_desc2.Enabled = False
            txt_doc_per2.Enabled = False
        End If
    End Sub
    Private Sub ch_si1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si1.CheckedChanged
        If ch_si1.Checked Then
            CBO_SUCURSAL1.Enabled = True
        Else
            CBO_SUCURSAL1.SelectedIndex = -1
            CBO_SUCURSAL1.Enabled = False
        End If
    End Sub
    Private Sub ch_suc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si2.CheckedChanged
        If ch_si2.Checked Then
            cbo_sucursal2.Enabled = True
        Else
            cbo_sucursal2.SelectedIndex = -1
            cbo_sucursal2.Enabled = False
        End If
    End Sub
    Private Sub dgw_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = dgw_per1.Item(0, dgw_per1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = dgw_per1.Item(1, dgw_per1.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = dgw_per1.Item(2, dgw_per1.CurrentRow.Index).Value.ToString
            Panel_PER1.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER1.Visible = False
            TXT_COD1.Focus()
        End If
    End Sub
    Private Sub dgw_per2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod2.Text = dgw_per2.Item(0, dgw_per2.CurrentRow.Index).Value.ToString
            txt_desc2.Text = dgw_per2.Item(1, dgw_per2.CurrentRow.Index).Value.ToString
            txt_doc_per2.Text = dgw_per2.Item(2, dgw_per2.CurrentRow.Index).Value.ToString
            Panel_per2.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per2.Visible = False
            txt_cod2.Focus()
        End If
    End Sub
    Private Sub REPORTE_CANC_COB_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
        If (e.KeyCode = Keys.F1) Then
            Try
            Catch ex As Exception
                'MessageBox.Show(exc.Message, "Error al Cargar ayuda ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End If
    End Sub
    Private Sub REPORTE_PTE_GRAL_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_PERSONAS()
        CARGAR_SUCURSAL()
        CARGAR_BANCOS()
        dtp01.Value = FECHA_GRAL
        dtp02.Value = FECHA_GRAL
    End Sub
    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS_COMPROBANTE", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(2).Visible = False
            dgw_ban.Columns.Item(3).Visible = False
            dgw_ban.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) <> "") Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (TXT_COD1.Text.ToLower = dgw_per1.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD1.Text = dgw_per1.Item(0, i).Value.ToString
                        TXT_DESC1.Text = dgw_per1.Item(1, i).Value.ToString
                        txt_doc_per1.Text = dgw_per1.Item(2, i).Value.ToString
                        dtp01.Focus()
                        Return
                    End If
                    If (TXT_COD1.Text.ToLower = Strings.Mid((dgw_per1.Item(0, i).Value), 1, Strings.Len(TXT_COD1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod2.LostFocus
        If (Strings.Trim(Me.txt_cod2.Text) <> "") Then
            If (Me.dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_per2.Sort(Me.dgw_per2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (Me.dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod2.Text.ToLower = dgw_per2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod2.Text = dgw_per2.Item(0, i).Value.ToString
                        txt_desc2.Text = dgw_per2.Item(1, i).Value.ToString
                        txt_doc_per2.Text = dgw_per2.Item(2, i).Value.ToString
                        dtp03.Focus()
                        Return
                    End If
                    If (txt_cod2.Text.ToLower = Strings.Mid((dgw_per2.Item(0, i).Value), 1, Strings.Len(Me.txt_cod2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC1.Text) <> "")) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (TXT_DESC1.Text.ToLower = Strings.Mid((dgw_per1.Item(1, i).Value), 1, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc2.Text) <> "")) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_per2.Sort(dgw_per2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc2.Text.ToLower = Strings.Mid((dgw_per2.Item(1, i).Value), 1, Strings.Len(txt_desc2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_per1.Sort(dgw_per1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per1.Text.ToLower = Strings.Mid((dgw_per1.Item(2, i).Value), 1, Strings.Len(txt_doc_per1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(2, i).Value), 1, Strings.Len(txt_doc_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        'cod_moneda = dgw_ban.Item(2, i).Value.ToString
                        'dtp_del.Select()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub


    Private Sub txt_cod_ban_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_ban.TextChanged

    End Sub

    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            'cod_moneda = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            'KL1.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ch_si3.Checked And cbo_sucursal3.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_sucursal3.Focus() : Exit Sub
        If ch_ban.Checked And txt_cod_ban.Text = "" Then MessageBox.Show("Debe seleccionar el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        If (DateTime.Compare(dtp05.Value, dtp06.Value) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp05.Focus() : Exit Sub
        If ch_si3.Checked Then
            STATUS_SUC2 = "0"
            COD_SUCURSAL2 = cbo_sucursal3.SelectedValue.ToString
        Else
            STATUS_SUC2 = "1"
            COD_SUCURSAL2 = "  "
        End If
        '--------------------------------------------------------------
        Dim ST_BANCO, COD_BANCO As String
        If ch_ban.Checked Then
            ST_BANCO = "0"
            COD_BANCO = txt_cod_ban.Text
        Else
            ST_BANCO = "1"
            COD_BANCO = "  "
        End If
        REP.CREAR_REPORTE(COD_SUCURSAL2, STATUS_SUC2, dtp05.Value, dtp06.Value, ST_BANCO, COD_BANCO)
        'REP.parametros(COD_SUCURSAL2, " ", STATUS_SUC2, "1", dtp04.Value, dtp05.Value, "1", " ", ST_BANCO, COD_BANCO)
        REP.ShowDialog()
    End Sub


End Class