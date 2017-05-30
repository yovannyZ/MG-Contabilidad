Imports Microsoft.Reporting.WinForms
Public Class REP_TCXC

    Private Sub REP_TCXC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal DES_MES As String, ByVal DES_CTA As String, ByVal COD_CTA As String, ByVal AÑO0 As String, ByVal COD_MES As String, ByVal S_CONCILIADO As String, ByVal COD_PER As String, ByVal S_PER As String, ByVal FECHA_CONC As DateTime)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("DES_CUENTA", DES_CTA))
        parametros.Add(New ReportParameter("COD_CUENTA", COD_CTA))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_SALDOS_TCXCTableAdapter.Connection = con
        Me.REPORTE_SALDOS_TCXCTableAdapter.Fill(Me.DT_REP_ANA_CXC.REPORTE_SALDOS_TCXC, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, COD_PER, S_PER, FECHA_CONC)
    End Sub

End Class