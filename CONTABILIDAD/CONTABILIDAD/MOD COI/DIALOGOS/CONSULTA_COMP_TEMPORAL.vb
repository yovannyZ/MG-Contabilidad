Imports System.Data.SqlClient
Public Class CONSULTA_COMP_TEMPORAL
    Dim año0, mes0 As String
    Dim OBJ As New Class1
    Public Sub CARGAR_DETALLES(ByVal COD_AUX As Object, ByVal COD_COMP As Object, ByVal NRO_COMP As Object)
        dgw_det.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_T_CON_DIARIO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            PROG_01.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = (año0)
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (mes0)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_det.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), _
                Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), _
                Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), _
                Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), _
                Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), _
                Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ch_cod_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cod.CheckedChanged
        If ch_cod.Checked Then
            DGW_CAB.Sort(DGW_CAB.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_rs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_rs.CheckedChanged
        If ch_rs.Checked Then
            DGW_CAB.Sort(DGW_CAB.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub DGW_CAB_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW_CAB.CellEnter
        If (con.State <> ConnectionState.Open) And DGW_CAB.RowCount > 0 Then
            Dim COD_AUX As String = DGW_CAB.Item(0, DGW_CAB.CurrentRow.Index).Value.ToString
            Dim COD_COMP As String = DGW_CAB.Item(2, DGW_CAB.CurrentRow.Index).Value.ToString
            Dim NRO_COMP As String = DGW_CAB.Item(4, DGW_CAB.CurrentRow.Index).Value.ToString
            CARGAR_DETALLES(COD_AUX, COD_COMP, NRO_COMP)
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ACEPTAR.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Hide()
    End Sub
    Private Sub txt_letra_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra.TextChanged
        Dim i As Integer
        If ch_cod.Checked Then
            txt_letra.Focus()
            i = 0
            Do While (i <= (DGW_CAB.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((DGW_CAB.Item(0, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    DGW_CAB.CurrentCell = (DGW_CAB.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_rs.Checked Then
            txt_letra.Focus()
            i = 0
            Do While (i <= (DGW_CAB.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((DGW_CAB.Item(1, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    DGW_CAB.CurrentCell = (DGW_CAB.Rows.Item(i).Cells.Item(1))
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub
    Private Sub CONSULTA_REQ_ORD_PROD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGW_CAB.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        dgw_det.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        'CARGAR_AÑO()
        'cbo_año.Text = AÑO
        'cbo_mes.Text = OBJ.DESC_MESMES
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
    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Hide()
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged, cbo_año.SelectedIndexChanged
        If cbo_año.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 Then
            dgw_det.Rows.Clear()
            año0 = cbo_año.Text
            mes0 = OBJ.COD_MES(cbo_mes.Text)
            MOSTRAR_I_CON()
        End If
    End Sub
    Sub MOSTRAR_I_CON()
        DGW_CAB.Rows.Clear()
        Try
            Dim Prog002 As New SqlCommand("MOSTRAR_ICON_DIARIO", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año0
            Prog002.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes0
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DGW_CAB.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class