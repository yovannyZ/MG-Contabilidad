Imports Microsoft.Reporting.WinForms
Public Class REP_CTA_AUX

    Private Sub REP_CTA_AUX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_AUX As String, ByVal COD_CTA As String, ByVal DESC_CTA As String, ByVal MES1 As String, ByVal MES2 As String, ByVal ORDEN As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("A�O", A�O))
        parametros.Add(New ReportParameter("COD_CUENTA", COD_CTA))
        parametros.Add(New ReportParameter("DESC_CUENTA", DESC_CTA))
        parametros.Add(New ReportParameter("MES1", MES1))
        parametros.Add(New ReportParameter("MES2", MES2))
        parametros.Add(New ReportParameter("ORDEN", ORDEN))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        'MES2 = (CDbl((Decimal.Parse(MES2) + 1)))
        Me.REPORTE_CTA_AUXTableAdapter.Connection = con
        Me.REPORTE_CTA_AUXTableAdapter.Fill(Me.DT_REP_CTA_AUX.REPORTE_CTA_AUX, COD_AUX, A�O, MES1, MES2, COD_CTA)
    End Sub

End Class