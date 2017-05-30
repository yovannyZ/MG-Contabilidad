Imports Microsoft.Reporting.WinForms
Public Class REP_FORMATO_E_P_PER

    Private Sub REP_FORMATO_E_P_PER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_FORMATO As String, ByVal MES As String, ByVal DESC_FORMATO As String, ByVal FECHA As DateTime, ByVal AÑO_ANT As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_FORMATO", COD_FORMATO))
        parametros.Add(New ReportParameter("DESC_FORMATO", DESC_FORMATO))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("AÑO1", AÑO))
        parametros.Add(New ReportParameter("AÑO2", AÑO_ANT))
        parametros.Add(New ReportParameter("MES", MES))
        parametros.Add(New ReportParameter("FECHA", (FECHA)))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_BALANCE_PERTableAdapter.Connection = con
        Me.REPORTE_BALANCE_PERTableAdapter.Fill(Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER, COD_FORMATO)
    End Sub

End Class