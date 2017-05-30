Imports Microsoft.Reporting.WinForms
Public Class REP_MOV_CTA

    Private Sub REP_MOV_CTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, ByVal status_ban As String, ByVal COD_BAN As String, ByVal TIPO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA1", (fecha1)))
        parametros.Add(New ReportParameter("FECHA2", (fecha2)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)

        Me.DataTable1TableAdapter.Connection = con
        Me.DataTable1TableAdapter.Fill(Me.DT_REP_MOV_CTA.DataTable1, status_ban, COD_BAN, fecha1, fecha2, TIPO)
    End Sub

End Class