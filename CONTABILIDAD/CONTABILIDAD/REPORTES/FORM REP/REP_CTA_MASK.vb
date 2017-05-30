Imports Microsoft.Reporting.WinForms
Public Class REP_CTA_MASK

    Private Sub REP_CTA_MASK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal MASK As String, ByVal MASK_X As String, ByVal MES1 As String, ByVal MES2 As String, ByVal ORDEN As String, ByVal COD_AUX As String, ByVal COD_COMP As String, ByVal PROCESO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("MASCARA", MASK_X))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES1", MES1))
        parametros.Add(New ReportParameter("MES2", MES2))
        parametros.Add(New ReportParameter("ORDEN", ORDEN))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        'MES2 = (CDbl((Decimal.Parse(MES2) + 1)))
        Me.REPORTE_CTA_MASKTableAdapter.Connection = con
        Me.REPORTE_CTA_MASKTableAdapter.Fill(Me.DT_REP_CTA_AUX.REPORTE_CTA_MASK, AÑO, MES1, MES2, MASK, COD_AUX, COD_COMP, PROCESO)
    End Sub

End Class