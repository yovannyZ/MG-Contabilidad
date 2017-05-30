Imports Microsoft.Reporting.WinForms
Public Class REP_FLUJO_EFECTIVO
    Private Sub REP_FLUJO_EFECTIVO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub

    Sub CREAR_REPORTE(ByVal añoProceso As String, ByVal mesProceso As String, ByVal diaProceso As String, _
    ByVal saldoInicial As String, ByVal diferenciaCambio As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("AÑO", añoProceso))
        parametros.Add(New ReportParameter("MES", mesProceso))
        parametros.Add(New ReportParameter("DIA", diaProceso))
        parametros.Add(New ReportParameter("SALDO_INICIAL", saldoInicial))
        parametros.Add(New ReportParameter("DIF_CAMBIO", diferenciaCambio))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub

    Sub LIMPIAR()
        Me.REPORTE_VARIOS.REPORTE_FLUJO_EFECTIVO.Clear()
    End Sub

    Sub llenar_dt(ByVal codigoConcepto As String, ByVal descripcionConcepto As String, ByVal importe As String, _
    ByVal codigoNivelUno As String, ByVal descripcionNivelUno As String, ByVal codigoNivelDos As String, ByVal descripcionNivelDos As String)
        Me.REPORTE_VARIOS.REPORTE_FLUJO_EFECTIVO.Rows.Add(codigoConcepto, descripcionConcepto, importe, codigoNivelUno, descripcionNivelUno, _
            codigoNivelDos, descripcionNivelDos)
    End Sub
End Class