Imports Microsoft.Reporting.WinForms
Public Class REP_CXP_PTE1

    Private Sub REP_CXP_PTE1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_SUC As String, ByVal ST_SUC As String, ByVal FECHA1 As DateTime, ByVal FECHA2 As DateTime, ByVal ST_PER As String, ByVal COD_PER As String, ByVal ST_DOC As String, ByVal COD_DOC As String, ByVal ST_CUENTA As String, ByVal COD_CUENTA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA_DEL", (FECHA1)))
        parametros.Add(New ReportParameter("FECHA_AL", (FECHA2)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CXP_PTES1TableAdapter.Connection = con
        Me.REPORTE_CXP_PTES1TableAdapter.Fill(Me.DT_REPORTES.REPORTE_CXP_PTES1, COD_SUC, ST_SUC, FECHA1, FECHA2.AddDays(1), ST_PER, COD_PER, ST_DOC, COD_DOC, ST_CUENTA, COD_CUENTA)
    End Sub


End Class