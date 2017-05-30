Imports Microsoft.Reporting.WinForms
Public Class REP_DESCUADRE_CXP

    Private Sub REP_DESCUADRE_CXP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal cod_sucursal As String, ByVal st_sucursal As String, ByVal DES_MES0 As String, ByVal COD_MES As String)
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES", DES_MES0))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_DESCUADRE_CXPTableAdapter.Connection = con
        Me.REPORTE_DESCUADRE_CXPTableAdapter.Fill(Me.DT_REPORTES.REPORTE_DESCUADRE_CXP, cod_sucursal, st_sucursal, AÑO, COD_MES)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class