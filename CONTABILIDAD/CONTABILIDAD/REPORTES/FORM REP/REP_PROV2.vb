Imports Microsoft.Reporting.WinForms
Public Class REP_PROV2
    Private Sub REP_PROV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal FILA1 As String, ByVal FILA2 As String, ByVal TITULO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("FILA1", FILA1))
        parametros.Add(New ReportParameter("FILA2", FILA2))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
    Sub LIMPIAR()
        Me.DT_CONFIG_PROV2.Clear()
    End Sub
    Sub llenar_dt(ByVal COD_DOC As String, ByVal DES_DOC As String, ByVal S1 As Decimal, ByVal S2 As Decimal, ByVal S3 As Decimal, ByVal S4 As Decimal, ByVal S5 As Decimal, ByVal S6 As Decimal, ByVal S7 As Decimal, ByVal S8 As Decimal, ByVal FE_MES00 As String)
        Me.DT_CONFIG_PROV2.CONFIG_PROV2.Rows.Add(COD_DOC, DES_DOC, S1, S2, S3, S4, S5, S6, S7, S8, FE_MES00)
    End Sub
End Class