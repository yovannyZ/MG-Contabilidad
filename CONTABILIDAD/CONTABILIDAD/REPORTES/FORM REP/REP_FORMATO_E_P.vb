Imports Microsoft.Reporting.WinForms
Public Class REP_FORMATO_E_P

    Private Sub REP_FORMATO_E_P_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_FORMATO As String, ByVal MES As String, ByVal DESC_FORMATO As String, ByVal FECHA As DateTime)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_FORMATO", COD_FORMATO))
        parametros.Add(New ReportParameter("DESC_FORMATO", DESC_FORMATO))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES", MES))
        parametros.Add(New ReportParameter("FECHA", (FECHA)))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_BALANCETableAdapter.Connection = con
        Me.REPORTE_BALANCETableAdapter.Fill(Me.DT_REP_FORMATO.REPORTE_BALANCE, COD_FORMATO)
    End Sub

End Class