Imports Microsoft.Reporting.WinForms
Public Class REP_CPTO_CTAS
    Public ORD As String

    Private Sub REP_CPTO_CTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
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
        Me.DataTable2TableAdapter.Connection = con
        Me.DataTable2TableAdapter.Fill(DT_CTA_GASTO.DataTable2)
    End Sub
End Class