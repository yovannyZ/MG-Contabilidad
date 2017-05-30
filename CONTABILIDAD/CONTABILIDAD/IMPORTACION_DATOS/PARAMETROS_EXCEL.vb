Public Class PARAMETROS_EXCEL

    Public Columnas As New List(Of String)
    Private Sub PARAMETROS_EXCEL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkTodos.Checked = True
    End Sub

    Public Sub ObtenerColumnas(ByVal oDataGrid As DataGridView)
        For i As Integer = 0 To oDataGrid.ColumnCount - 1
            If oDataGrid.Columns(i).Visible Then
                chkListCampos.Items.Add(oDataGrid.Columns(i).HeaderText)
            End If
        Next
    End Sub

    Private Sub Aceptar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If chkListCampos.CheckedItems.Count > 0 Then
            For Each item As String In chkListCampos.CheckedItems
                Columnas.Add(item)
            Next
        End If
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        For i As Integer = 0 To chkListCampos.Items.Count - 1
            chkListCampos.SetItemChecked(i, chkTodos.Checked)
        Next
    End Sub
End Class