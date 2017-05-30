Imports System.Data.SqlClient
Public Class REPORTE_CTA_RESUMEN
    Dim DESC_MES As String
    Dim OBJ As New Class1
    Dim OFR As New REP_CTA_RESUMEN
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        Dim COD_AUX As String = OBJ.COD_AUX(cbo_aux.Text)
        OFR.CREAR_REPORTE(COD_AUX, cbo_aux.Text, CBO_MES.Text)
        OFR.Show()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(&H4C) = 0
        Close()
    End Sub
    Sub cargar_aux()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cargar_aux()
    End Sub
End Class