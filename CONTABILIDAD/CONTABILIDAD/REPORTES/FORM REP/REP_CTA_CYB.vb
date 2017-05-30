Imports Microsoft.Reporting.WinForms
Public Class REP_CTA_CYB
    Public ORD As String

    Private Sub REP_CTA_CYB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE()
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("ORD", Me.ORD))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.MAESTRO_BANCOSTableAdapter.Connection = con
        Me.MAESTRO_BANCOSTableAdapter.Fill(Me.DT_REP_CTA_CYB.MAESTRO_BANCOS)
    End Sub

End Class