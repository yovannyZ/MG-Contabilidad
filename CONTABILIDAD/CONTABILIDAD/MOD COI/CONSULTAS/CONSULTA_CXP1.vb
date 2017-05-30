Imports System.Data.SqlClient
Public Class CONSULTA_CXP1
    Dim COD_SUCURSAL As String
    'dim components As IContainer
    Dim fila2 As Integer
    Dim OBJ As New Class1
    Dim STATUS_SUC As String
    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (DGW_PER1.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(DGW_PER1.Item(1, i).Value.ToString)
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
        If (ch_si1.Checked And (CBO_SUCURSAL1.SelectedIndex = -1)) Then
            MessageBox.Show("Debe elegir la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL1.Focus()
        ElseIf (TXT_COD1.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD1.Focus()
        Else
            STATUS_SUC = "1"
            If ch_si1.Checked = False Then
                STATUS_SUC = "1"
                COD_SUCURSAL = ""
            Else
                STATUS_SUC = "0"
                COD_SUCURSAL = CBO_SUCURSAL1.SelectedValue.ToString
            End If
            MOSTRAR_CONSULTA()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(21) = 0
        Close()
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        'Dim VB$t_i4$L0 As Integer = (DGW_PER1.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= (DGW_PER1.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(DGW_PER1.Item(1, i).Value.ToString)
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
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            DGW_PER1.DataSource = (DT)
            DGW_PER1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            DGW_PER1.Columns.Item(0).Width = (&H37)
            DGW_PER1.Columns.Item(1).Width = (300)
        Catch ex As Exception
            MsgBox(ex.Message)

            'MsgBox(ex.Message)

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
    Private Sub ch_si1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si1.CheckedChanged
        CBO_SUCURSAL1.Enabled = ch_si1.Checked
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
        DGW_DET1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_CXP_PENDIENTES", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (TXT_COD1.Text)
            PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = (STATUS_SUC)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (COD_SUCURSAL)
            PROG_01.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = (dtp1.Value.Date)
            PROG_01.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = (dtp2.Value.Date)
            PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = (TIPO_USU)
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = (COD_USU)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DET1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        DGW_DET2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_CXP_CANCELADAS", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (TXT_COD1.Text)
            PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = (STATUS_SUC)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (COD_SUCURSAL)
            PROG_01.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = (dtp1.Value.Date)
            PROG_01.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = (dtp2.Value.Date)
            PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = (TIPO_USU)
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = (COD_USU)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DET2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), (Rs3.GetValue(18)), Rs3.GetValue(19))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        DGW_DET3.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_CXP_KARDEX", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (TXT_COD1.Text)
            PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = (STATUS_SUC)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (COD_SUCURSAL)
            PROG_01.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = (dtp1.Value.Date)
            PROG_01.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = (dtp2.Value.Date)
            PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = (TIPO_USU)
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = (COD_USU)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DET3.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), (Rs3.GetValue(18)), Rs3.GetValue(19))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD1.LostFocus
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
                    dtp1.Select()
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
    Private Sub TXT_DESC1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC1.KeyDown
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
    Private Sub TXT_DOC_PER1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per1.KeyDown
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
    Private Sub CONSULTA_CXP1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CONSULTA_CXP1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DGW_DET1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        DGW_DET11.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        DGW_DET2.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        DGW_DET3.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        CARGAR_PERSONAS()
        CARGAR_SUCURSAL()
        CBO_SUCURSAL1.Focus()
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
            Dim PROG_01 As New SqlCommand("CONSULTA_CXP_KARDEX2", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (TXT_COD1.Text)
            PROG_01.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = (STATUS_SUC)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (COD_SUCURSAL)
            'PROG_01.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = (dtp1.Value.Date)
            'PROG_01.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = (dtp2.Value.Date)
            PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = (TIPO_USU)
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = (COD_USU)

            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = DGW_DET1.Item(0, DGW_DET1.CurrentRow.Index).Value.ToString
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_DET1.Item(1, DGW_DET1.CurrentRow.Index).Value.ToString
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DET11.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), (Rs3.GetValue(18)), Rs3.GetValue(19))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

  



    Private Sub DGW_DET1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_DET1.CellContentClick

    End Sub
End Class