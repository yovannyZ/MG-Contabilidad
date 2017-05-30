Imports System.Data.SqlClient
Public Class REPORTE_CTA_CYB
    Dim ofr1 As New REP_CTA_CYB
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If ComboBox1.SelectedIndex = 0 Then
            ofr1.ORD = "0"
        Else
            ofr1.ORD = "1"
        End If
        ofr1.CREAR_REPORTE()
        ofr1.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(31) = 0
        Close()
    End Sub
End Class