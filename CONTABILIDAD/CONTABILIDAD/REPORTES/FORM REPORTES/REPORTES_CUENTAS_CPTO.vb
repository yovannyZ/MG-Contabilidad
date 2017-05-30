Imports System.Data.SqlClient
Public Class REPORTES_CUENTAS_CPTO
    Dim OBJ As New Class1
    Dim ofr1 As New REP_CPTO_CTAS
    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar1.Click
        main(32) = 0
        Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If ComboBox1.SelectedIndex = 0 Then
            ofr1.ORD = "0"
        Else
            ofr1.ORD = "1"
        End If
        ofr1.CREAR_REPORTE()
        ofr1.ShowDialog()
    End Sub
    Private Sub REPORTE_CUENTA_GASTO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_CUENTA_GASTO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        ComboBox1.SelectedIndex = 0
        ComboBox1.Select()
    End Sub
End Class