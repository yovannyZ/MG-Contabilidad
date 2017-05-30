Imports Microsoft.Reporting.WinForms
Public Class REP_ANA_TP

    Private Sub REP_ANA_TP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub
    Sub CREAR_REPORTE(ByVal TITULO As String)
        Dim aa As String = System.Windows.Forms.Application.StartupPath
        Dim DES_RUTA As String = (aa & "\REPORTES\" & "REP_ANA_TP.rdlc")
        ReportViewer1.LocalReport.ReportPath = DES_RUTA
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
    Sub LIMPIAR()
        Me.DT_REP_ANA_TP.DataTable1.Clear()
    End Sub
    Sub llenar_dt(ByVal COD_PER As String, ByVal DES_PER As String, ByVal COD_DOC As String, ByVal NRO_DOC As String, ByVal FEC_DOC As String, ByVal D As Decimal, ByVal S As Decimal, ByVal D2 As Decimal, ByVal S2 As Decimal, ByVal MON As String, ByVal CTA As String, ByVal AUX As String, ByVal COD_COMP As String, ByVal NRO_COMP As String, ByVal MON_ANA As String)
        Me.DT_REP_ANA_TP.DataTable1.Rows.Add(COD_PER, DES_PER, COD_DOC, NRO_DOC, FEC_DOC, D, S, D2, S2, MON, CTA, AUX, COD_COMP, NRO_COMP, MON_ANA)
    End Sub
End Class