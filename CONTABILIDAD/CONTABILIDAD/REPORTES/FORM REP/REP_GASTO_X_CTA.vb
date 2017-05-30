Imports Microsoft.Reporting.WinForms
Public Class REP_GASTO_X_CTA

    Private Sub REP_GASTO_X_CTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_GASTO_CTA.REPORTE_GASTO_X_CTA' Puede moverla o quitarla según sea necesario.

        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.REPORTE_GASTO_X_CTATableAdapter.Fill(Me.DT_GASTO_CTA.REPORTE_GASTO_X_CTA)

        'Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_GASTO_X_CTATableAdapter.Connection = con
        Me.REPORTE_GASTO_X_CTATableAdapter.Fill(Me.DT_GASTO_CTA.REPORTE_GASTO_X_CTA, AÑO00, MES00)
    End Sub
End Class