Imports Microsoft.Reporting.WinForms
Public Class REP_CTA_RESUMEN

    Private Sub REP_CTA_RESUMEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_AUX As String, ByVal DESC_AUX As String, ByVal MES1 As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_AUX", COD_AUX))
        parametros.Add(New ReportParameter("DESC_AUX", DESC_AUX))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES", MES1))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CTA_RESUMENTableAdapter.Connection = con
        Me.REPORTE_CTA_RESUMENTableAdapter.Fill(Me.DT_REP_CTA_AUX.REPORTE_CTA_RESUMEN, AÑO, MES1, COD_AUX)
    End Sub

End Class