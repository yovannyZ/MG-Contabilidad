Imports Microsoft.Reporting.WinForms
Public Class REP_CONCILIACION

    Private Sub REP_CONCILIACION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub CREAR_REPORTE(ByVal CODBANCO As String, ByVal DESC_BANCO As String, ByVal MES00 As String, ByVal DESC_MES As String, ByVal AÑO00 As String, ByVal ST_CON As Integer)
        Dim PARAMETROS As New List(Of ReportParameter)
        PARAMETROS.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        PARAMETROS.Add(New ReportParameter("RUC", RUC_EMPRESA))
        PARAMETROS.Add(New ReportParameter("AÑO", AÑO00))
        PARAMETROS.Add(New ReportParameter("DESC_MES", DESC_MES))
        PARAMETROS.Add(New ReportParameter("COD_BANCO", CODBANCO))
        PARAMETROS.Add(New ReportParameter("DESC_BANCO", DESC_BANCO))
        ReportViewer1.LocalReport.SetParameters(PARAMETROS)
        Me.CONCILIACIONTableAdapter.Connection = con
        Me.CONCILIACIONTableAdapter.Fill(Me.DT_REP_CONCILICACION.CONCILIACION, CODBANCO, MES00, AÑO00, ST_CON)
    End Sub
End Class