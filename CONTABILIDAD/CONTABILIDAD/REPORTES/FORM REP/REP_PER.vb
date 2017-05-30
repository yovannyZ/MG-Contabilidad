Imports Microsoft.Reporting.WinForms
Public Class REP_PER
    Friend TipoImpresion As String
    Public TASA As Decimal

    Private Sub REP_RET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If TipoImpresion = "V" Then
            ReportViewer2.Visible = True
            ReportViewer1.Visible = False
            ReportViewer2.RefreshReport()
            ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer2.ZoomMode = ZoomMode.PageWidth
            ReportViewer2.RefreshReport()
            ReportViewer2.Refresh()
        Else
            ReportViewer1.Visible = True
            ReportViewer2.Visible = False
            ReportViewer1.RefreshReport()
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.PageWidth
            ReportViewer1.RefreshReport()
            ReportViewer1.Refresh()
        End If
    End Sub
    Sub CREAR_REPORTE(ByVal FECHA_RET As String, ByVal DES_PER As String, ByVal RUC_PER As String, ByVal TC As String, _
    ByVal TOTAL_BI As String, ByVal TOTAL_IMPORTE As String, ByVal LETRAS As String, ByVal NRO_RET As String, ByVal rutaLogo As String)

        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("FECHA_RET", FECHA_RET))
        parametros.Add(New ReportParameter("DES_PER", DES_PER))
        parametros.Add(New ReportParameter("RUC_PER", RUC_PER))
        parametros.Add(New ReportParameter("TC", TC))
        parametros.Add(New ReportParameter("TOTAL_BI", TOTAL_BI))
        parametros.Add(New ReportParameter("TOTAL_IMPORTE", TOTAL_IMPORTE))
        parametros.Add(New ReportParameter("LETRAS", LETRAS))
        parametros.Add(New ReportParameter("NRO_RET", NRO_RET))

        If TipoImpresion = "V" Then
            parametros.Add(New ReportParameter("RUC_EMPRESA", RUC_EMPRESA))
            parametros.Add(New ReportParameter("DIR_EMPRESA", DIR_EMPRESA))
            parametros.Add(New ReportParameter("FONO_EMPRESA", FONO_EMPRESA))
            parametros.Add(New ReportParameter("WEB_EMPRESA", WEB_EMPRESA))
            parametros.Add(New ReportParameter("EMAIL_EMPRESA", EMAIL_EMPRESA))
            parametros.Add(New ReportParameter("RUTA_LOGO", rutaLogo))
            ReportViewer2.LocalReport.EnableExternalImages = True
            ReportViewer2.LocalReport.SetParameters(parametros)
        Else
            parametros.Add(New ReportParameter("TASA", TASA))
            ReportViewer1.LocalReport.SetParameters(parametros)
        End If
    End Sub
    Sub LIMPIAR()
        DT_RETENCION.PERCEPCION.Clear()
    End Sub
    Sub llenar_dt(ByVal COD_DOC As String, ByVal SERIE As String, ByVal NRO_CORRELATIVO As String, ByVal FECHA_DOC As String, _
    ByVal BASE_I As Decimal, ByVal IMPORTE As Decimal, ByVal COD_D_H As String, ByVal conCopia As String)
        DT_RETENCION.PERCEPCION.Rows.Add(COD_DOC, SERIE, NRO_CORRELATIVO, FECHA_DOC, BASE_I, IMPORTE, COD_D_H, conCopia)
    End Sub
End Class