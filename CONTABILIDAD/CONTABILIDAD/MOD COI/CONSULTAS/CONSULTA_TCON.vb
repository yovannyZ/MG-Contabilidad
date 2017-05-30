Imports System.Data.SqlClient
Public Class CONSULTA_TCON
    Dim COD_AUX, STATUS_COM, STATUS_AUX, COD_COM, COD_COMP, mes0 As String
    Dim DD, DH, SD, SH As Decimal
    Dim OBJ As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(46) = 0
        Close()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btn_consulta1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta1.Click
        If (Strings.Trim(txt_cta.Text) = "") Then
            MessageBox.Show("Debe elegir una Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta.Focus()
        ElseIf (CH_AUX.Checked And (cbo_auxiliar.SelectedIndex = -1)) Then
            MessageBox.Show("Debe elegir auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_auxiliar.Focus()
        ElseIf cbo_año.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        ElseIf (ch_com.Checked And (cbo_comprobante.SelectedIndex = -1)) Then
            MessageBox.Show("Debe elegir comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_comprobante.Focus()
        Else
            If CH_AUX.Checked Then
                STATUS_AUX = "0"
                COD_AUX = cbo_auxiliar.SelectedValue.ToString
            Else
                STATUS_AUX = "1"
                COD_AUX = " "
            End If
            If ch_com.Checked Then
                STATUS_COM = "0"
                COD_COM = cbo_comprobante.SelectedValue.ToString
            Else
                STATUS_COM = "1"
                COD_COM = " "
            End If
            mes0 = OBJ.COD_MES(cbo_mes.Text)
            CARGAR_T_CON_CAB()
            HALLAR_SUMA()
        End If
    End Sub
    Sub CARGAR_CUENTA()
        Dim AÑO0 As String
        AÑO0 = cbo_año.Text
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS(AÑO0)
            dgw_cta.DataSource = (DT)
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_T_CON_CAB()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_TCON_CONSULTA2", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (mes0)
            PROG_01.Parameters.Add("@STATUS_AUX", SqlDbType.Char).Value = (STATUS_AUX)
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = (COD_AUX)
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (txt_cta.Text)
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = (COD_COM)
            PROG_01.Parameters.Add("@STATUS_COM", SqlDbType.Char).Value = (STATUS_COM)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex <> -1) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                LLENAR_CBO_COMPROBANTE()
            End If
        End If
    End Sub
    Private Sub cbo_comprobante_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_comprobante.SelectedIndexChanged
        If ((cbo_auxiliar.SelectedIndex <> -1) And (cbo_comprobante.SelectedIndex <> -1)) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            COD_COMP = cbo_comprobante.SelectedValue.ToString
            If (COD_COMP = "System.Data.DataRowView") Then
            End If
        End If
    End Sub
    Private Sub CH_PER_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_AUX.CheckedChanged
        '-----no existe ch_per ojo y puse CH_AUX
        If CH_AUX.Checked Then
            cbo_auxiliar.Enabled = True
            cbo_comprobante.Enabled = True
            ch_com.Enabled = True
        Else
            cbo_auxiliar.SelectedIndex = -1
            cbo_comprobante.SelectedIndex = -1
            cbo_auxiliar.Enabled = False
            cbo_comprobante.Enabled = False
            ch_com.Checked = False
            ch_com.Enabled = False
        End If
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
    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw1.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            T_CON()
        End If
    End Sub
    Sub HALLAR_SUMA()
        Dim CONT As Integer = (dgw1.Rows.Count - 1)
        Dim I As Integer = 0
        Do While (I <= CONT)
            SD = (Decimal.Add(SD, dgw1.Item(3, I).Value))
            SH = (Decimal.Add(SH, dgw1.Item(4, I).Value))
            DD = (Decimal.Add(DD, dgw1.Item(5, I).Value))
            DH = (Decimal.Add(DH, dgw1.Item(6, I).Value))
            I += 1
        Loop
        txt_sd.Text = (SD)
        txt_sh.Text = (SH)
        txt_dd.Text = (DD)
        txt_dh.Text = (DH)
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
    Sub T_CON()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_TCON_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes0
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(16, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(17, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(18, dgw1.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw2.DataSource = (DT)
            dgw2.Columns.Item(0).Width = 60 : dgw2.Columns.Item(1).Width = 200
            dgw2.Columns.Item(2).Width = 70 : dgw2.Columns.Item(3).Width = 70
            dgw2.Columns.Item(4).Width = 70 : dgw2.Columns.Item(5).Width = 70
            dgw2.Columns.Item(6).Width = 35 : dgw2.Columns.Item(7).Width = 60
            dgw2.Columns.Item(8).Width = 60 : dgw2.Columns.Item(9).Width = 80
            dgw2.Columns.Item(10).Width = 70 : dgw2.Columns.Item(11).Width = &H37
            dgw2.Columns.Item(12).Width = &H37 : dgw2.Columns.Item(13).Width = &H2D
            dgw2.Columns.Item(14).Width = &H37 : dgw2.Columns.Item(15).Width = &H37
            dgw2.Columns.Item(16).Width = &H37 : dgw2.Columns.Item(17).Width = &H37
            dgw2.Columns.Item(2).DefaultCellStyle.Alignment = &H40 : dgw2.Columns.Item(3).DefaultCellStyle.Alignment = &H40
            dgw2.Columns.Item(4).DefaultCellStyle.Alignment = &H40 : dgw2.Columns.Item(5).DefaultCellStyle.Alignment = &H40
            dgw2.Columns.Item(7).DefaultCellStyle.Alignment = &H40 : dgw2.Columns.Item(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter : dgw2.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns.Item(2).DefaultCellStyle.Format = "N2" : dgw2.Columns.Item(3).DefaultCellStyle.Format = "N2" : dgw2.Columns.Item(4).DefaultCellStyle.Format = "N2"
            dgw2.Columns.Item(5).DefaultCellStyle.Format = "N2" : dgw2.Columns.Item(10).DefaultCellStyle.Format = "d"
            dgw2.Columns.Item(18).Visible = False : dgw2.Columns.Item(19).Visible = False
            dgw2.Columns.Item(20).Width = 180
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta.LostFocus
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
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
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
    Private Sub CONSULTA_TCON_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub CONSULTA_TCON_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_AÑO()
        LLENAR_CBO_AUXILIAR()
    End Sub
    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged
        txt_cta.Clear()
        txt_desc_cta.Clear()
        txt_sd.Clear()
        txt_sh.Clear()
        txt_dd.Clear()
        txt_dh.Clear()
        txt_cta.Focus()
        CARGAR_CUENTA()
    End Sub
End Class