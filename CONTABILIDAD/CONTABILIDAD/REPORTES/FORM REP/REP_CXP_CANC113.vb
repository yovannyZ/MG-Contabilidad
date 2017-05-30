Imports Microsoft.Reporting.WinForms
Public Class REP_CXP_CANC113
    Private Sub REP_CXP_CANC113_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal cod_sucursal As String, ByVal status_suc As String, ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, ByVal ST_BANCO As String, ByVal COD_BANCO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA_DEL", fecha1))
        parametros.Add(New ReportParameter("FECHA_AL", fecha2))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CXP_CANC12TableAdapter.Connection = con
        Me.REPORTE_CXP_CANC12TableAdapter.Fill(Me.REPORTE_VARIOS.REPORTE_CXP_CANC12, status_suc, cod_sucursal, fecha1, fecha2, ST_BANCO, COD_BANCO)
    End Sub

End Class