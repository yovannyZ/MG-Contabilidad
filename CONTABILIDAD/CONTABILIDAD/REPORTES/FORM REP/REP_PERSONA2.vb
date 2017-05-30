Imports Microsoft.Reporting.WinForms
Public Class REP_PERSONA2

    Private Sub REP_PERSONA2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.Refresh()
    End Sub
    Sub CREAR_REPORTE(ByVal DESC_PAIS As String, ByVal DESC_CLASE As String, ByVal COD_CLASE As String, ByVal DESC_CAT As String, ByVal COD_CAT As String, ByVal cod_pais As String, ByVal status_dep As String, ByVal cod_dep As String, ByVal status_pro As String, ByVal cod_pro As String, ByVal status_dist As String, ByVal cod_dist As String)
        Me.REPORTE_PERSONAS2TableAdapter.Connection = con
        Me.REPORTE_PERSONAS2TableAdapter.Fill(Me.DT_REP_PERSONAS2.REPORTE_PERSONAS2, COD_CLASE, COD_CAT, cod_pais, status_dep, cod_dep, status_pro, cod_pro, status_dist, cod_dist)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("CLASE", DESC_CLASE))
        parametros.Add(New ReportParameter("CATEGORIA", DESC_CAT))
        parametros.Add(New ReportParameter("DESC_PAIS", DESC_PAIS))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub

End Class