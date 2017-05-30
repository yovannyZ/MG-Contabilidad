Imports Microsoft.Reporting.WinForms
Public Class REP_RESUMEN_TCXP

    Private Sub REP_RESUMEN_TCXP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.REPORTE_SALDOS_TCXP2TableAdapter.Fill(Me.DT_REP_ANA_CXP.REPORTE_SALDOS_TCXP2)

    End Sub
    Sub CREAR_REPORTE(ByVal DES_MES As String, ByVal DES_CTA As String, ByVal COD_CTA As String, ByVal AÑO0 As String, ByVal COD_MES As String, ByVal S_CONCILIADO As String, ByVal FECHA_CONC As DateTime, ByVal DES_TIPO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("DES_CUENTA", DES_CTA))
        parametros.Add(New ReportParameter("COD_CUENTA", COD_CTA))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_SALDOS_TCXP2TableAdapter.Connection = con
        Me.REPORTE_SALDOS_TCXP2TableAdapter.Fill(Me.DT_REP_ANA_CXP.REPORTE_SALDOS_TCXP2, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, FECHA_CONC, DES_TIPO)
    End Sub
End Class