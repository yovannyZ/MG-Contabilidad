Imports System.Data.SqlClient
Public Class REPORTE_M_CUENTAS
    Private obj As New Class1
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        Dim ofr As New REP_M_CUENTA
        ofr.CREAR_REPORTE(txt_cod1.Text, txt_cod2.Text)
        ofr.ShowDialog()
    End Sub
    Private Sub btn_pantalla2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla2.Click
        Dim ofr As New REP_M_AUTO
        ofr.CREAR_REPORTE()
        ofr.ShowDialog()
    End Sub
    Private Sub btn_pantalla3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla3.Click
        Dim ofr As New REP_CUADRE_AUTO
        ofr.CREAR_REPORTE()
        ofr.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click, btn_salir3.Click
        main(10) = 0
        Me.Close()
    End Sub
    Private Sub REPORTE_M_CUENTAS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_M_CUENTAS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
    End Sub
    Private Sub txt_cod1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod1.LostFocus
        txt_desc1.Text = obj.DESC_CUENTA(txt_cod1.Text, AÑO)
    End Sub
    Private Sub txt_cod2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod2.LostFocus
        txt_desc2.Text = obj.DESC_CUENTA(txt_cod2.Text, AÑO)
    End Sub
End Class