Imports System.Data.SqlClient
Public Class DESCUADRE_CXC
    Dim REP As New REP_DESCUADRE_CXC
    Private OBJ As New Class1
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (ch_si1.Checked And (CBO_SUCURSAL1.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL1.Focus()
        ElseIf (CBO_MES.SelectedIndex = -1) Then
            MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_MES.Focus()
        Else
            Dim COD_SUC As String = CBO_SUCURSAL1.SelectedValue.ToString
            Dim ST_SUC As String = "1"
            If ch_si1.Checked Then
                ST_SUC = "0"
            End If
            Dim COD_MES As String = (OBJ.COD_MES(CBO_MES.Text))

            REP.CREAR_REPORTE(COD_SUC, ST_SUC, CBO_MES.Text, COD_MES)
            REP.ShowDialog()
        End If
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(55) = 0
        Close()
    End Sub

    Sub CARGAR_SUCURSAL()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_SUCURSAL
        CBO_SUCURSAL1.DataSource = DT
        CBO_SUCURSAL1.DisplayMember = DT.Columns.Item(0).ToString
        CBO_SUCURSAL1.ValueMember = DT.Columns.Item(1).ToString
        CBO_SUCURSAL1.SelectedIndex = -1
    End Sub

    Private Sub ch_si1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si1.CheckedChanged
        CBO_SUCURSAL1.Enabled = ch_si1.Checked
    End Sub


    Private Sub DESCUADRE_CXC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_SUCURSAL()

    End Sub
End Class