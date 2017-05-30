Imports Microsoft.Reporting.WinForms
Public Class REP_M_CUENTA

    Private Sub REP_M_CUENTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal CUENTA1 As String, ByVal CUENTA2 As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_M_CUENTASTableAdapter.Connection = con
        Me.REPORTE_M_CUENTASTableAdapter.Fill(Me.REPORTE_MAESTROS.REPORTE_M_CUENTAS, AÑO, CUENTA1, CUENTA2)
    End Sub

End Class