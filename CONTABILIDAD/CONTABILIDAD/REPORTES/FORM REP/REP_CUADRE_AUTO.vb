Imports Microsoft.Reporting.WinForms
Public Class REP_CUADRE_AUTO

    Private Sub REP_CUADRE_AUTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.CUADRE_AUTOMATICATableAdapter.Connection = con
        Me.CUADRE_AUTOMATICATableAdapter.Fill(Me.REPORTE_MAESTROS.CUADRE_AUTOMATICA, AÑO)
    End Sub
End Class