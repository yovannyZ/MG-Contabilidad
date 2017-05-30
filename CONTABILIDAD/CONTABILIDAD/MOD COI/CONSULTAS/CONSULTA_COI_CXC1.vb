Imports System.Data.SqlClient
Public Class CONSULTA_COI_CXC1
    Dim fila2 As Integer
    Dim OBJ As New Class1
    Dim ST_CTA, STATUS_SUC, COD_CUENTA, COD_SUCURSAL As String

    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim i As Integer = 0
        Do While (i <= (DGW_PER1.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(DGW_PER1.Item(1, i).Value.ToString))
                If (TXT_DESC1.Text.ToLower = Strings.Mid(DGW_PER1.Item(1, i).Value.ToString, f, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                    DGW_PER1.CurrentCell = (DGW_PER1.Rows.Item(i).Cells.Item(1))
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        DGW_PER1.Focus()
    End Sub
    Private Sub BTN_CONSULTA1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA1.Click
        If ch_si1.Checked And CBO_SUCURSAL1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_SUCURSAL1.Focus() : Exit Sub
        If TXT_COD1.Text.Trim = "" Then MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : TXT_COD1.Focus() : Exit Sub
        If ch_cta.Checked = True And txt_cod_cta0.Text = "" Then MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        '--------------------------------------
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_año2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año2.Focus() : Exit Sub
        If TabControl1.SelectedIndex = 0 Then
        Else
            If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
            If cbo_año1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año1.Focus() : Exit Sub
        End If
        STATUS_SUC = "1"
        If ch_si1.Checked = False Then
            STATUS_SUC = "1"
            COD_SUCURSAL = ""
        Else
            STATUS_SUC = "0"
            COD_SUCURSAL = CBO_SUCURSAL1.SelectedValue.ToString
        End If
        If ch_cta.Checked = False Then
            ST_CTA = "1"
            COD_CUENTA = ""
        Else
            ST_CTA = "0"
            COD_CUENTA = txt_cod_cta0.Text.ToString
        End If
        MOSTRAR_CONSULTA()
        HALLAR_TOTALES()
    End Sub
    Sub HALLAR_TOTALES()
        Dim I, CONT As Integer
        Dim mon As String
        Dim sum_soles, sum_dolares As Decimal
        CONT = DGW_DET1.Rows.Count - 1
        sum_soles = 0
        sum_dolares = 0
        For I = 0 To CONT
            mon = DGW_DET1.Item(5, I).Value.ToString
            If mon = "S" Then
                sum_soles = sum_soles + DGW_DET1.Item(4, I).Value
            ElseIf mon = "D" Then
                sum_dolares = sum_dolares + DGW_DET1.Item(4, I).Value
            End If
        Next
        txt_soles.Text = OBJ.HACER_DECIMAL(sum_soles)
        txt_dolares.Text = OBJ.HACER_DECIMAL(sum_dolares)
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(42) = 0
        Close()
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim i As Integer = fila2
        Do While (i <= (DGW_PER1.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(DGW_PER1.Item(1, i).Value.ToString))
                If (TXT_DESC1.Text.ToLower = Strings.Mid(DGW_PER1.Item(1, i).Value.ToString, f, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                    DGW_PER1.CurrentCell = (DGW_PER1.Rows.Item(i).Cells.Item(1))
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        DGW_PER1.Focus()
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XCOBRAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            DGW_PER1.DataSource = (DT)
            DGW_PER1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            DGW_PER1.Columns.Item(0).Width = &H37
            DGW_PER1.Columns.Item(1).Width = 300
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
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cta.CheckedChanged
        If ch_cta.Checked = True Then
            txt_cod_cta0.Enabled = True
            txt_desc_cta0.Enabled = True
        Else
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            txt_cod_cta0.Enabled = False
            txt_desc_cta0.Enabled = False
        End If
    End Sub
    Private Sub ch_si1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si1.CheckedChanged
        If ch_si1.Checked = True Then
            CBO_SUCURSAL1.Enabled = True
        Else
            CBO_SUCURSAL1.SelectedIndex = -1
            CBO_SUCURSAL1.Enabled = False
        End If
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            Panel_cuenta.Visible = False
            k2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            Panel_cuenta.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub
    Sub DGW_CUENTAS()
        Try
            dgw_cta.DataSource = (OBJ.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "C"))
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("Arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(4).Visible = False
            dgw_cta.Columns.Item(0).Width = (70)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGW_PER1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = DGW_PER1.Item(0, DGW_PER1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = DGW_PER1.Item(1, DGW_PER1.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = DGW_PER1.Item(2, DGW_PER1.CurrentRow.Index).Value.ToString
            PANEL_PER1.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER1.Visible = False
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            txt_doc_per1.Clear()
            TXT_COD1.Focus()
        End If
    End Sub
    Sub MOSTRAR_CONSULTA()
        If TabControl1.SelectedIndex = 0 Then
            '-------------------------------------------------------------------------
            DGW_DET1.Rows.Clear()
            Try
                Dim PROG_01 As New SqlCommand("CONSULTA_CXC_PENDIENTES_COI", con)
                PROG_01.CommandType = (CommandType.StoredProcedure)
                PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD1.Text
                PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC
                PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
                'PROG_01.Parameters.Add("@MES1", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes1.Text)
                PROG_01.Parameters.Add("@MES2", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
                PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
                PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
                PROG_01.Parameters.Add("@STATUS_CTA", SqlDbType.Char).Value = ST_CTA
                PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
                PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text

                con.Open()
                PROG_01.CommandTimeout = 720
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    If Rs3.GetValue(4) <> "0.00" Then
                        DGW_DET1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13))
                    End If
                Loop
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            '-------------------------------------------------------------------------
        ElseIf TabControl1.SelectedIndex = 1 Then
            '-------------------------------------------------------------------------
            DGW_DET2.Rows.Clear()
            Try
                Dim PROG_01 As New SqlCommand("CONSULTA_CXC_CANCELADAS_COI", con)
                PROG_01.CommandType = (CommandType.StoredProcedure)
                PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD1.Text
                PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC
                PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
                PROG_01.Parameters.Add("@MES1", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes1.Text)
                PROG_01.Parameters.Add("@MES2", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
                PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
                PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
                PROG_01.Parameters.Add("@STATUS_CTA", SqlDbType.Char).Value = ST_CTA
                PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
                PROG_01.Parameters.Add("@FE_AÑO1", SqlDbType.Char).Value = cbo_año1.Text
                PROG_01.Parameters.Add("@FE_AÑO2", SqlDbType.Char).Value = cbo_año2.Text
                con.Open()
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    DGW_DET2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20))
                Loop
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            '-------------------------------------------------------------------------
        ElseIf TabControl1.SelectedIndex = 2 Then
            '-------------------------------------------------------------------------
            DGW_DET3.Rows.Clear()
            Try
                Dim PROG_01 As New SqlCommand("CONSULTA_CXC_KARDEX_COI", con)
                PROG_01.CommandType = (CommandType.StoredProcedure)
                PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD1.Text
                PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC
                PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
                PROG_01.Parameters.Add("@MES1", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes1.Text)
                PROG_01.Parameters.Add("@MES2", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
                PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
                PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
                PROG_01.Parameters.Add("@STATUS_CTA", SqlDbType.Char).Value = ST_CTA
                PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
                PROG_01.Parameters.Add("@FE_AÑO1", SqlDbType.Char).Value = cbo_año1.Text
                PROG_01.Parameters.Add("@FE_AÑO2", SqlDbType.Char).Value = cbo_año2.Text
                con.Open()
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    DGW_DET3.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20))
                Loop
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            '-------------------------------------------------------------------------
        Else
            DGW_DET1.Rows.Clear()
            DGW_DET2.Rows.Clear()
            DGW_DET3.Rows.Clear()
        End If
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        'dtp1.Focus()
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = (dgw_cta.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) = "") Then
            TXT_DESC1.Focus()
        ElseIf (DGW_PER1.RowCount = 0) Then
            MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            DGW_PER1.Sort(DGW_PER1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
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
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If ((Strings.Trim(txt_desc_cta0.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = (dgw_cta.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(TXT_DESC1.Text) = "") Then
                txt_doc_per1.Focus()
            ElseIf (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
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
    Private Sub TXT_DOC_PER1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txt_doc_per1.Text) = "") Then
                TXT_COD1.Focus()
            ElseIf (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
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
    Private Sub CONSULTA_COI_CXC1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CONSULTA_COI_CXC1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DGW_DET1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET11.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET3.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        CARGAR_PERSONAS()
        DGW_CUENTAS()
        CARGAR_SUCURSAL()
        CARGAR_AÑOS()
        CBO_SUCURSAL1.Focus()
        '------------------------------
        Label5.Visible = False
        Label6.Visible = False
        cbo_año1.Visible = False
        cbo_mes1.Visible = False
        If COD_MOD = "BCO" Then
            Label11.Visible = False
            ch_cta.Visible = False
            txt_cod_cta0.Visible = False
            txt_desc_cta0.Visible = False
            Panel_cuenta.Visible = False
            k2.Visible = False
        Else
            Label11.Visible = True
            ch_cta.Visible = True
            txt_cod_cta0.Visible = True
            txt_desc_cta0.Visible = True
            'Panel_cuenta.Visible = True
            k2.Visible = True
        End If


    End Sub
    Sub CARGAR_AÑOS()
        cbo_año1.Items.Clear()
        cbo_año2.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año1.Items.Add(Rs3.GetString(0))
                Me.cbo_año2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub DGW_DET1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_DET1.CellEnter
        Try
            Dim i As Integer = DGW_DET1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (DGW_DET1.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            HISTORIAL()
        End If
    End Sub
    Sub HISTORIAL()
        DGW_DET11.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_CXC_KARDEX_COI2", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD1.Text
            PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
            PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            PROG_01.Parameters.Add("@STATUS_CTA", SqlDbType.Char).Value = ST_CTA
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = DGW_DET1.Item(0, DGW_DET1.CurrentRow.Index).Value.ToString
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_DET1.Item(1, DGW_DET1.CurrentRow.Index).Value.ToString
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DET11.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            Label5.Visible = False
            Label6.Visible = False
            cbo_año1.Visible = False
            cbo_mes1.Visible = False
            If COD_MOD = "BCO" Then
                Label11.Visible = False
                ch_cta.Visible = False
                txt_cod_cta0.Visible = False
                txt_desc_cta0.Visible = False
                Panel_cuenta.Visible = False
                k2.Visible = False
            Else
                Label11.Visible = True
                ch_cta.Visible = True
                txt_cod_cta0.Visible = True
                txt_desc_cta0.Visible = True
                'Panel_cuenta.Visible = True
                k2.Visible = True
            End If
        ElseIf TabControl1.SelectedIndex = 1 Then
            Label5.Visible = True
            Label6.Visible = True
            cbo_año1.Visible = True
            cbo_mes1.Visible = True
        ElseIf TabControl1.SelectedIndex = 2 Then
            Label5.Visible = True
            Label6.Visible = True
            cbo_año1.Visible = True
            cbo_mes1.Visible = True
        Else
        End If
    End Sub
  
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox1_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles GroupBox1.Layout

    End Sub
End Class