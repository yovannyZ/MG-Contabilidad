Imports Microsoft.Reporting.WinForms
Public Class REP_CTA_CTA_CTE

    Private Sub REP_CTA_CTA_CTE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_CTA As String, ByVal DESC_CTA As String, ByVal MES1 As String, ByVal MES2 As String, ByVal ORDEN As String, ByVal STATUS_PER As String, ByVal COD_PER As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_CTA", COD_CTA))
        parametros.Add(New ReportParameter("DESC_CTA", DESC_CTA))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES1", MES1))
        parametros.Add(New ReportParameter("MES2", MES2))
        parametros.Add(New ReportParameter("ORDEN", ORDEN))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CTA_CTA_CTETableAdapter.Connection = con
        Me.REPORTE_CTA_CTA_CTETableAdapter.Fill(Me.DT_REP_CTA_AUX.REPORTE_CTA_CTA_CTE, AÑO, MES1, MES2, COD_CTA, STATUS_PER, COD_PER)
    End Sub

End Class