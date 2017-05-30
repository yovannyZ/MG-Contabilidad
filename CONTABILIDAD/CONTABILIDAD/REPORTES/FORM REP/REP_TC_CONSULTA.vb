Imports Microsoft.Reporting.WinForms
Public Class REP_TC_CONSULTA

    Private Sub REP_TC_CONSULTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub
    Sub CREAR_REPORTE(ByVal MES0 As String, ByVal AÑO0 As String, ByVal COMPRA As Decimal, ByVal VENTA As Decimal)
        Dim parametros As New List(Of ReportParameter)
        '--------------------------------------------------------------------
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("MES0", MES0))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        parametros.Add(New ReportParameter("COMPRA", COMPRA))
        parametros.Add(New ReportParameter("VENTA", VENTA))

        '------------------------------------------------
        ReportViewer1.LocalReport.SetParameters(parametros)
        '------------------------------------------------
    End Sub
    Sub LIMPIAR()
        DT_CONSULTA_TC.Clear()

    End Sub
    Sub llenar_dt(ByVal DIA As String, ByVal cod_MON As String, ByVal desc_MON As String, ByVal TIPO_VENTAS As Decimal, ByVal TIPO_COMPRA As Decimal)
        DT_CONSULTA_TC.TC.Rows.Add(DIA, cod_MON, desc_MON, TIPO_VENTAS, TIPO_COMPRA)
    End Sub
End Class