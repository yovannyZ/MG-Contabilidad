Imports Microsoft.Reporting.WinForms
Public Class REP_M_AUTO

    Private Sub REP_M_AUTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE()
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_M_AUTOMATICASTableAdapter.Connection = con
        Me.REPORTE_M_AUTOMATICASTableAdapter.Fill(Me.REPORTE_MAESTROS.REPORTE_M_AUTOMATICAS, AÑO)
    End Sub

End Class