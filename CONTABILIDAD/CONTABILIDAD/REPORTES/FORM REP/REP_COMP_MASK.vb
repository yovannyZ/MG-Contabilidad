Imports Microsoft.Reporting.WinForms
Public Class REP_COMP_MASK

    Private Sub REP_COMP_MASK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal MES1 As String, ByVal FECHA As DateTime, ByVal MASK As String, ByVal MES2 As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES1", MES1))
        parametros.Add(New ReportParameter("FECHA", (FECHA)))
        parametros.Add(New ReportParameter("MASK", MASK))
        parametros.Add(New ReportParameter("MES2", MES2))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub


End Class