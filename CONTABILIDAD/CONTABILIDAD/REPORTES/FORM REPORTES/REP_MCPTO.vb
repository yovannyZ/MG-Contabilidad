Imports System.Data.SqlClient
Public Class REP_MCPTO
    Dim OBJ As New Class1
    Dim ofr1 As New REPORTE_MCPTO
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (ComboBox1.SelectedIndex = 0) Then
            ofr1.ORD = "0"
        Else
            ofr1.ORD = "1"
        End If
        ofr1.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(30) = 0
        Close()
    End Sub
    Private Sub REP_MCPTO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REP_MCPTO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        ComboBox1.Select()
    End Sub
End Class