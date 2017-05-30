Imports Microsoft.Reporting.WinForms
Public Class REP_CPTO_CONS

    Private Sub REP_CPTO_CONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, ByVal STATUS_CPTO As String, ByVal COD_CPTO As String, ByVal MONEDA As String, ByVal COD_MONEDA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA1", (fecha1)))
        parametros.Add(New ReportParameter("FECHA2", (fecha2)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("MONEDA", MONEDA))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        fecha2 = fecha2.Date.AddDays(1)
        Me.DataTable1TableAdapter.Connection = con
        Me.DataTable1TableAdapter.Fill(Me.DT_REP_CPTO_CONS.DataTable1, COD_MONEDA, fecha1, fecha2, COD_CPTO)
    End Sub

End Class