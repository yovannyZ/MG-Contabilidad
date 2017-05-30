Imports Microsoft.Reporting.WinForms
Public Class REP_DESCUADRE_COMP

    Private Sub REP_DESCUADRE_COMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal TIPO0 As String, ByVal AÑO0 As String, ByVal MES0 As String, ByVal DESC_MES As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO0))
        parametros.Add(New ReportParameter("MES", DESC_MES))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_DESCUADRE_COMPTableAdapter.Connection = con
        Me.REPORTE_DESCUADRE_COMPTableAdapter.Fill(Me.DT_REPORTES.REPORTE_DESCUADRE_COMP, TIPO0, AÑO0, MES0)
    End Sub

End Class