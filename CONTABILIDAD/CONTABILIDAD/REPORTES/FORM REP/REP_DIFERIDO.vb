Imports Microsoft.Reporting.WinForms
Public Class REP_DIFERIDO

    Private Sub REP_DIFERIDO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub

    Sub CREAR_REPORTE(ByVal año As String, ByVal mes As String, ByVal cuenta As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_I_DIFERIDOTableAdapter.Connection = con
        Me.REPORTE_I_DIFERIDOTableAdapter.Fill(Me.DT_REP_DIFERIDOS.REPORTE_I_DIFERIDO, año, mes, cuenta)
    End Sub
End Class
