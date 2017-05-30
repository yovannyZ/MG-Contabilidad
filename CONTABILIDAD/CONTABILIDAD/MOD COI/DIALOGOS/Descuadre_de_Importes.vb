Imports System.Data.SqlClient
Public Class Descuadre_de_Importes

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancel_Button.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub Descuadre_de_Importes_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DGW.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
    End Sub
    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OK_Button.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub


End Class