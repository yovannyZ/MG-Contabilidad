Imports Microsoft.Reporting.WinForms
Public Class REP_PERSONA1

    Private Sub REP_PERSONA1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.Refresh()
    End Sub
    Sub CREAR_REPORTE(ByVal DESC_CLASE As String, ByVal COD_CLASE As String, ByVal DESC_CAT As String, ByVal COD_CAT As String)
        Me.REPORTE_PERSONAS1TableAdapter.Connection = con
        Me.REPORTE_PERSONAS1TableAdapter.Fill(Me.DT_REP_PERSONA1.REPORTE_PERSONAS1, COD_CLASE, COD_CAT)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("CLASE", DESC_CLASE))
        parametros.Add(New ReportParameter("CATEGORIA", DESC_CAT))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub

End Class