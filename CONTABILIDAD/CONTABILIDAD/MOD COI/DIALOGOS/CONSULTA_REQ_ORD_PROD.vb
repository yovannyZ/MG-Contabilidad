Imports System.Data.SqlClient
Public Class CONSULTA_REQ_ORD_PROD
    Public con0 As New SqlConnection
    Public _fecha As DateTime
    Dim OBJ As New Class1
    Public Sub CARGAR_DETALLES(ByVal nro_ord_prod As Object, ByVal AÑO0 As Object, ByVal MES0 As Object)
        If OBJ.DIR_TABLA_DESC("COS", "TSIST") = "NO" Then
            con0 = con
        End If
        DGW_DET.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_ORD_PROD_DET", con0)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@NRO_ORD_PROD", SqlDbType.Char).Value = (nro_ord_prod)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@fecha", SqlDbType.DateTime).Value = _fecha
            con0.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DET.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con0.Close()
        Catch ex As Exception

            con0.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Public Sub CARGAR_ORD_PROD()
        If OBJ.DIR_TABLA_DESC("COS", "TSIST") = "NO" Then
            con0 = con
        End If
        DGW_CAB.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_ORD_PROD_PTE", con0)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@fecha", SqlDbType.DateTime).Value = _fecha
            con0.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_CAB.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6))
            Loop
            con0.Close()
        Catch ex As Exception
            con0.Close()
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
        If (con0.State <> ConnectionState.Open) Then
            Dim NRO_ORDEN As String = DGW_CAB.Item(0, DGW_CAB.CurrentRow.Index).Value.ToString
            Dim AÑO0 As String = DGW_CAB.Item(5, DGW_CAB.CurrentRow.Index).Value.ToString
            Dim MES0 As String = DGW_CAB.Item(6, DGW_CAB.CurrentRow.Index).Value.ToString
            CARGAR_DETALLES(NRO_ORDEN, AÑO0, MES0)
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
        DGW_DET.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
    End Sub
    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Hide()
    End Sub
End Class