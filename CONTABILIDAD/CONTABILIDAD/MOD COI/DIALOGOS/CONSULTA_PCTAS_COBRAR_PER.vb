Imports System.Data.SqlClient
Public Class CONSULTA_PCTAS_COBRAR_PER
    Public COD_CPTO00 As String
    Public COD_PER00 As String
    Public COD_SUC As String
    Public IMPORTE0 As Decimal
    Public im1, im2 As Decimal
    Public indice As String

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Sub CARGAR_PCTAS_COBRAR_PERSONA()
        DGW_CAB.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONSULTA_PCTAS_COBRAR_PTES", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (COD_SUC)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER00)
            PROG_01.Parameters.Add("@STATUS_PER", SqlDbType.Char).Value = ("0")
            'PROG_01.Parameters.Add("@COD_CPTO", SqlDbType.Char).Value = ""
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_CAB.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), Rs3.GetValue(8))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub ch_cod_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cod.CheckedChanged
        If ch_cod.Checked Then
            DGW_CAB.Sort(DGW_CAB.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_rs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_rs.CheckedChanged
        If ch_rs.Checked Then
            DGW_CAB.Sort(DGW_CAB.Columns.Item(4), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub CH_TODOS_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        CARGAR_PCTAS_COBRAR_PERSONA()
    End Sub
    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click

        im1 = DGW_CAB.Item(8, DGW_CAB.CurrentRow.Index).Value.ToString
        im2 = DGW_CAB.Item(17, DGW_CAB.CurrentRow.Index).Value.ToString
        IMPORTE0 = DGW_CAB.Item(17, DGW_CAB.CurrentRow.Index).Value

        Dim I As Integer = 0
        Dim CONT As Integer = (DGW_CAB.Rows.Count - 1)

        I = 0
        Do While (I <= CONT)
            If (DGW_CAB.Item(11, I).Value.ToString = "True") Then
                Dim cod_per As String = DGW_CAB.Item(5, I).Value.ToString
                Dim cod_doc As String = DGW_CAB.Item(2, I).Value.ToString
                Dim nro_doc As String = DGW_CAB.Item(4, I).Value.ToString
                If VERIFICAR(cod_per, cod_doc, nro_doc) = False Then
                    LBL.Text = "NO"
                    MessageBox.Show("El Documento ya se ingresó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Do
                End If
                LBL.Text = "SI"
                DGW.Rows.Add(New Object() {cod_per, cod_doc, nro_doc})
            End If
            I += 1
        Loop
        'End If
    End Sub
    Private Sub rb_ruc_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rb_ruc.CheckedChanged
        If rb_ruc.Checked Then
            DGW_CAB.Sort(DGW_CAB.Columns.Item(11), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub rd_nc_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rd_nc.CheckedChanged
        If rd_nc.Checked Then
            DGW_CAB.Sort(DGW_CAB.Columns.Item(12), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub txt_letra_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra.TextChanged
        Dim i As Integer
        If ch_cod.Checked Then
            txt_letra.Focus()

            i = 0
            Do While (i <= (DGW_CAB.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((DGW_CAB.Item(2, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    DGW_CAB.CurrentCell = (DGW_CAB.Rows.Item(i).Cells.Item(2))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_rs.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L1 As Integer = (DGW_CAB.RowCount - 1)
            i = 0
            Do While (i <= (DGW_CAB.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((DGW_CAB.Item(4, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    DGW_CAB.CurrentCell = (DGW_CAB.Rows.Item(i).Cells.Item(4))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf rb_ruc.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L2 As Integer = (DGW_CAB.RowCount - 1)
            i = 0
            Do While (i <= (DGW_CAB.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((DGW_CAB.Item(11, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    DGW_CAB.CurrentCell = (DGW_CAB.Rows.Item(i).Cells.Item(11))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf rd_nc.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L3 As Integer = (DGW_CAB.RowCount - 1)
            i = 0
            Do While (i <= (DGW_CAB.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((DGW_CAB.Item(12, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    DGW_CAB.CurrentCell = (DGW_CAB.Rows.Item(i).Cells.Item(12))
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Public Function VERIFICAR(ByVal COD_PER As Object, ByVal COD_DOC As Object, ByVal NRO_DOC As Object) As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW.Rows.Count - 1)

        I = 0
        Do While (I <= CONT)
            If COD_PER = DGW.Item(0, I).Value.ToString And COD_DOC = DGW.Item(1, I).Value.ToString And NRO_DOC = DGW.Item(2, I).Value.ToString Then
                Return False
            End If
            I += 1
        Loop
        Return True

    End Function
    Private Sub CONSULTA_PCTAS_PAGAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGW_CAB.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        ch_rs.Checked = True
    End Sub
    Private Sub DGW_CAB_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_CAB.CellEnter


    End Sub
End Class