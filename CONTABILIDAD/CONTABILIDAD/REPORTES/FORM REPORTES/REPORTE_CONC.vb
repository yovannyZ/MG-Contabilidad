Imports System.Data.SqlClient
Public Class REPORTE_CONC
    Dim DEBE, HABER As Decimal
    Dim REP As New REP_CONC_PTE
    Dim REP2 As New REP_CONC
    Dim FECHA_CONC As DateTime
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (Strings.Trim(txt_cod_ban.Text) = "") Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbo_mes.Focus()
        ElseIf (cbo_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el AÑo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        Else
            Dim DESC_MES00 As String = ""
            Dim CONT0 As String = Me.cbo_mes.Text
            If (CONT0 = "01") Then
                DESC_MES00 = "ENERO"
            ElseIf (CONT0 = "02") Then
                DESC_MES00 = "FEBRERO"
            ElseIf (CONT0 = "03") Then
                DESC_MES00 = "MARZO"
            ElseIf (CONT0 = "04") Then
                DESC_MES00 = "ABRIL"
            ElseIf (CONT0 = "05") Then
                DESC_MES00 = "MAYO"
            ElseIf (CONT0 = "06") Then
                DESC_MES00 = "JUNIO"
            ElseIf (CONT0 = "07") Then
                DESC_MES00 = "JULIO"
            ElseIf (CONT0 = "08") Then
                DESC_MES00 = "AGOSTO"
            ElseIf (CONT0 = "09") Then
                DESC_MES00 = "SETIEMBRE"
            ElseIf (CONT0 = "10") Then
                DESC_MES00 = "OCTUBRE"
            ElseIf (CONT0 = "11") Then
                DESC_MES00 = "NOVIEMBRE"
            ElseIf (CONT0 = "12") Then
                DESC_MES00 = "DICIEMBRE"
            Else
                DESC_MES00 = "INICIO"
            End If
            SALDOS()
            '---------------------------------------------
            FECHA_CONC = DateTime.Parse(("01/" & CONT0 & "/" & cbo_año.Text))
            '---------------------------------------------
            If CH_PTE.Checked Then
                REP.CREAR_REPORTE(cbo_año.Text, DESC_MES00, cbo_mes.Text, txt_cod_ban.Text, DEBE, HABER, txt_desc_ban.Text, FECHA_CONC)
                REP.ShowDialog()
            Else
                REP2.CREAR_REPORTE(cbo_año.Text, DESC_MES00, cbo_mes.Text, txt_cod_ban.Text, Decimal.Zero, Decimal.Zero, txt_desc_ban.Text, FECHA_CONC)
                REP2.ShowDialog()
            End If
        End If
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(12) = 0
        Close()
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CH_PTE_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles CH_PTE.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If CH_PTE.Checked Then
                CH_PTE.Checked = False
            Else
                CH_PTE.Checked = True
            End If
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            kl1.Focus()
        End If
    End Sub
    Private Sub REPORTE_CONC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_CONC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑO()
        CARGAR_BANCOS()
        cbo_año.Text = AÑO
        cbo_mes.Text = MES
    End Sub
    Sub SALDOS()
        DEBE = New Decimal
        HABER = New Decimal
        Try
            Dim Prog002 As New SqlCommand("HALLAR_SALDOS_BANCOS", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            Prog002.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            Prog002.Parameters.Add("@FE_MES", SqlDbType.Char).Value = cbo_mes.Text
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DEBE = Decimal.Parse(Rs3.GetValue(0))
                HABER = Decimal.Parse(Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAr0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAr0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        cbo_mes.Select()
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
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAr0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAr0)
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

    Private Sub panel_bancos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panel_bancos.Paint

    End Sub

    Private Sub txt_cod_ban_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_ban.TextChanged

    End Sub
End Class