Imports Microsoft.Reporting.WinForms
Public Class REP_ESTADISTICA_GASTO

    Private Sub REP_ESTADISTICA_GASTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub

    Sub CREAR_REPORTE(ByVal DES_MES As String, ByVal AÑO00 As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("AÑO", AÑO00))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
End Class