Imports Microsoft.Reporting.WinForms
Public Class REP_REPARABLE

    Private Sub REP_REPARABLE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_MES As String, ByVal DESC_MES As String, ByVal COD_MES2 As String, ByVal DESC_MES2 As String, ByVal ST_CTA As String, ByVal COD_CTA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DESC_MES))
        parametros.Add(New ReportParameter("DES_MES2", DESC_MES2))
        parametros.Add(New ReportParameter("AÑO0", AÑO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CUENTA_REPARABLETableAdapter.Connection = con
        Me.REPORTE_CUENTA_REPARABLETableAdapter.CommandTimeout = 720
        Me.REPORTE_CUENTA_REPARABLETableAdapter.Fill(Me.DT_REPARABLE.REPORTE_CUENTA_REPARABLE, AÑO, COD_MES, COD_MES2, COD_CTA, ST_CTA)
    End Sub

End Class