Imports Microsoft.Reporting.WinForms
Public Class REP_CXP_PTE1_COI

    Private Sub REP_CXP_PTE1_COI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal COD_SUC As String, ByVal ST_SUC As String, ByVal AÑO00 As String, ByVal MES00 As String, ByVal ST_PER As String, ByVal COD_PER As String, ByVal ST_DOC As String, ByVal COD_DOC As String, ByVal ST_CUENTA As String, ByVal COD_CUENTA As String, ByVal FECHA00 As Date, ByVal DESC_MES00 As String, ByVal TITULO As String, ByVal CADENA As String, ByVal TIPO_REPORTE As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("FECHA", (FECHA00)))
        parametros.Add(New ReportParameter("AÑO0", AÑO00))
        parametros.Add(New ReportParameter("MES0", DESC_MES00))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CXP_PTES1TableAdapter.Connection = con
        Me.REPORTE_CXP_PTES1TableAdapter.CommandTimeout = 720
        Me.REPORTE_CXP_PTES1TableAdapter.Fill(Me.DT_VARIOS.REPORTE_CXP_PTES1, COD_SUC, ST_SUC, AÑO00, MES00, ST_PER, COD_PER, ST_DOC, COD_DOC, ST_CUENTA, COD_CUENTA, CADENA, TIPO_REPORTE)
    End Sub
End Class