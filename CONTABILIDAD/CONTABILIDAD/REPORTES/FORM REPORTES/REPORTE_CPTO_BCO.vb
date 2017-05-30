Imports System.Data.SqlClient
Public Class REPORTE_CPTO_BCO
    Dim cod_moneda As String
    Dim obj As New Class1
    Dim REP As New REP_CPTO_BCO
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If Trim(txt_cod_ban.Text) = "" Then MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        If Trim(txt_cod_cta.Text) = "" And ch_cpto.Checked Then MessageBox.Show("Debe elegir un Concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta.Focus() : Exit Sub
        Dim cod_cpto, status_cpto As String
        If (DateTime.Compare(dtp_del.Value, dtp_al.Value) > 0) Then MessageBox.Show("El Rango es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp_del.Focus() : Exit Sub
        Dim cod_ban As String = txt_cod_ban.Text
        If ch_cpto.Checked Then
            status_cpto = "0"
            cod_cpto = txt_cod_cta.Text
        Else
            status_cpto = "1"
            cod_cpto = " "
        End If
        Dim desc_moneda As String = obj.DESC_MONEDA(cod_moneda)
        REP.CREAR_REPORTE(dtp_del.Value.Date, dtp_al.Value.Date, cod_ban, txt_desc_ban.Text, status_cpto, cod_cpto, desc_moneda)
        REP.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(10) = 0
        Close()
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
    Private Sub ch_cpto_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cpto.CheckedChanged
        If ch_cpto.Checked Then
            txt_cod_cta.ReadOnly = False
            txt_desc_cta.ReadOnly = False
        Else
            txt_cod_cta.Clear()
            txt_desc_cta.Clear()
            panel_cta.Visible = False
            txt_cod_cta.ReadOnly = True
            txt_desc_cta.ReadOnly = True
        End If
    End Sub
    Sub CONCEPTOS()
        Try
            Dim pro As New SqlCommand("DGW_CONCEPTOS", con)
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
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            cod_moneda = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            KL1.Focus()
        End If
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value.ToString
            panel_cta.Visible = False
            k1.Focus()
        End If
    End Sub
    Private Sub REPORTE_CPTO_BCO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub REPORTE_MOV_CTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_BANCOS()
        CONCEPTOS()
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
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
                        cod_moneda = dgw_ban.Item(2, i).Value.ToString
                        dtp_del.Select()
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
    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
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
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
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
 Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
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

    Private Sub txt_cod_cta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cta.TextChanged

    End Sub

    Private Sub txt_desc_cta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desc_cta.TextChanged

    End Sub

    Private Sub dgw_cta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cta.CellContentClick

    End Sub

    Private Sub txt_cod_ban_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_ban.TextChanged

    End Sub

    Private Sub txt_desc_ban_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desc_ban.TextChanged

    End Sub

    Private Sub dgw_ban_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_ban.CellContentClick

    End Sub
End Class