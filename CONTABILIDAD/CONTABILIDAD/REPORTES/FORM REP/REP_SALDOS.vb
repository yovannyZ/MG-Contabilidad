Imports Microsoft.Reporting.WinForms
Public Class REP_SALDOS

    Private Sub REP_SALDOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal MES_DEL As String, ByVal MES_AL As String, ByVal NIVEL As String, ByVal P0 As Integer, ByVal P1 As Integer, ByVal P2 As Integer, ByVal P3 As Integer, ByVal P4 As Integer, ByVal P5 As Integer, ByVal P6 As Integer, ByVal P7 As Integer, ByVal P8 As Integer, ByVal P9 As Integer, ByVal P10 As Integer, ByVal P11 As Integer, ByVal P12 As Integer, ByVal P13 As Integer, ByVal SUM As Decimal)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("MES_DEL", MES_DEL))
        parametros.Add(New ReportParameter("MES_AL", MES_AL))
        parametros.Add(New ReportParameter("P0", (P0)))
        parametros.Add(New ReportParameter("P1", (P1)))
        parametros.Add(New ReportParameter("P2", (P2)))
        parametros.Add(New ReportParameter("P3", (P3)))
        parametros.Add(New ReportParameter("P4", (P4)))
        parametros.Add(New ReportParameter("P5", (P5)))
        parametros.Add(New ReportParameter("P6", (P6)))
        parametros.Add(New ReportParameter("P7", (P7)))
        parametros.Add(New ReportParameter("P8", (P8)))
        parametros.Add(New ReportParameter("P9", (P9)))
        parametros.Add(New ReportParameter("P10", (P10)))
        parametros.Add(New ReportParameter("P11", (P11)))
        parametros.Add(New ReportParameter("P12", (P12)))
        parametros.Add(New ReportParameter("P13", (P13)))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("SUMA", (SUM)))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_MAESTRO_SALDOSTableAdapter.Connection = con
        Me.REPORTE_MAESTRO_SALDOSTableAdapter.Fill(Me.DT_REP_SALDOS.REPORTE_MAESTRO_SALDOS, NIVEL, AÑO)
    End Sub

End Class