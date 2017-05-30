Imports System.Data.SqlClient
Public Class REPORTE_BAN_CUENTA
    Private obj As New Class1

    Private Sub REPORTE_BAN_CUENTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.DGW_CUENTAS00()
        Me.CARGAR_MONEDA()
        Me.cbo_mes2.Text = FECHA_INI.ToString("MMMM").ToUpper
    End Sub
    Public Sub CARGAR_MONEDA()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        Me.cbo_moneda.DataSource = DT
        Me.cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        Me.cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        Me.cbo_moneda.SelectedIndex = -1
    End Sub

    Public Sub DGW_CUENTAS00()
        Try
            Dim DT As New DataTable
            DT = Me.obj.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "B")
            Me.dgw_cta.DataSource = DT
            Me.dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            Me.dgw_cta.Columns.Item(2).Visible = False
            Me.dgw_cta.Columns.Item(3).Visible = False
            Me.dgw_cta.Columns.Item(4).Visible = False
            Me.dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.LostFocus

    End Sub

    Private Sub txt_cod_cta0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.TextChanged

    End Sub
End Class