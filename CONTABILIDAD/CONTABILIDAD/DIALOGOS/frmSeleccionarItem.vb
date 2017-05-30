Public Class frmSeleccionarItem

    Private Sub Cancelar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Aceptar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If tgvItem.RowCount > 0 AndAlso Not tgvItem.CurrentNode Is Nothing Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Public Sub New(ByVal lista As Dictionary(Of String, String))

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        For Each item As KeyValuePair(Of String, String) In lista
            tgvItem.Nodes.Add(item.Key, item.Value)
        Next
    End Sub
End Class