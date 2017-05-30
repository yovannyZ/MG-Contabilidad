Imports Microsoft.Reporting.WinForms
Public Class REP_CXP_PTE3_COI

    Private Sub REP_CXP_PTE3_COI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_SUC As String, ByVal ST_SUC As String, ByVal FECHA1 As DateTime, ByVal FECHA2 As DateTime, ByVal ST_PER As String, ByVal COD_PER As String, ByVal ST_DOC As String, ByVal COD_DOC As String, ByVal ST_CTA As String, ByVal COD_CTA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA_DEL", (FECHA1)))
        parametros.Add(New ReportParameter("FECHA_AL", (FECHA2)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CXP_PTES2TableAdapter.Connection = con
        Me.REPORTE_CXP_PTES2TableAdapter.Fill(Me.DT_REPORTES.REPORTE_CXP_PTES2, COD_SUC, ST_SUC, FECHA1, FECHA2, ST_PER, COD_PER, ST_DOC, COD_DOC, ST_CTA, COD_CTA)
    End Sub

End Class