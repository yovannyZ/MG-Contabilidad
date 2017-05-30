Imports Microsoft.Reporting.WinForms
Public Class REP_CONC_CONTABLE

    Private Sub REP_CONC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String, ByVal COD_MES As String, ByVal COD_BANCO As String, ByVal DEBE As Decimal, ByVal HABER As Decimal, ByVal DESC_BANCO As String, ByVal FECHA_CONC As Date)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO00))
        parametros.Add(New ReportParameter("MES", MES00))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("COD_BANCO", COD_BANCO))
        parametros.Add(New ReportParameter("DESC_BANCO", DESC_BANCO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_BANCO_CONC_PTETableAdapter.Connection = con
        Me.REPORTE_BANCO_CONC_PTETableAdapter.Fill(Me.DT_CONC_PTE.REPORTE_BANCO_CONC_PTE, COD_BANCO, AÑO00, COD_MES, "1", FECHA_CONC)
    End Sub
End Class