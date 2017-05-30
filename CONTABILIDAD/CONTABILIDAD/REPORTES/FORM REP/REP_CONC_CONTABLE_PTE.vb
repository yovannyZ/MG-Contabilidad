Imports Microsoft.Reporting.WinForms
Public Class REP_CONC_CONTABLE_PTE

    Private Sub REP_CONC_PTE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String, ByVal COD_MES As String, ByVal COD_BANCO As String, ByVal DEBE As Decimal, ByVal HABER As Decimal, ByVal DESC_BANCO As String, ByVal FECHA_CONC As Date, ByVal TC_CUENTA As Decimal, ByVal TC_CONTABLE As Decimal, ByVal SALDO_CONTABLE As Decimal)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO00))
        parametros.Add(New ReportParameter("MES", MES00))
        parametros.Add(New ReportParameter("DEBE", (DEBE)))
        parametros.Add(New ReportParameter("HABER", (HABER)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("COD_BANCO", COD_BANCO))
        parametros.Add(New ReportParameter("DESC_BANCO", DESC_BANCO))
        parametros.Add(New ReportParameter("TC_CUENTA", TC_CUENTA))
        parametros.Add(New ReportParameter("TC_CONTABLE", TC_CONTABLE))
        parametros.Add(New ReportParameter("SALDO_CONTABLE", SALDO_CONTABLE))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_BANCO_CONC_PTE2TableAdapter.Connection = con
        Me.REPORTE_BANCO_CONC_PTE2TableAdapter.Fill(Me.DT_CONC_PTE.REPORTE_BANCO_CONC_PTE2, COD_BANCO, AÑO00, COD_MES, "0", FECHA_CONC)
    End Sub
End Class