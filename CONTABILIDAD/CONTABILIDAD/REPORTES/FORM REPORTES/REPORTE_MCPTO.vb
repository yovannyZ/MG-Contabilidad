Imports Microsoft.Reporting.WinForms
Public Class REPORTE_MCPTO
    Public ORD As String

    Private Sub REPORTE_MCPTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.ShowFindControls = True
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("ORD", ORD))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.MAESTRO_CONCEPTOSTableAdapter.Connection = con
        Me.MAESTRO_CONCEPTOSTableAdapter.Fill(Me.DT_REP_MCPTO.MAESTRO_CONCEPTOS)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()

    End Sub
End Class