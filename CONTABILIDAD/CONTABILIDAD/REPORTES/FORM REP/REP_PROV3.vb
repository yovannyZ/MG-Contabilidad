Imports Microsoft.Reporting.WinForms
Public Class REP_PROV3

    Private Sub REP_PROV3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal MES01 As String, ByVal MES02 As String, ByVal TITULO As String, ByVal R As String, ByVal AÑO0 As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("MES01", MES01))
        parametros.Add(New ReportParameter("MES02", MES02))
        parametros.Add(New ReportParameter("R", R))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
    Sub LIMPIAR()
        Me.DT_CONFIG_PROV3.Clear()
    End Sub

    Sub llenar_dt(ByVal COD_DOC As String, ByVal DES_DOC As String, ByVal NRO_DOC As String, _
    ByVal FEC_DOC As String, ByVal COD_PER As String, ByVal DOC_PER As String, ByVal DES_PER As String, _
    ByVal BI As Decimal, ByVal IGV As Decimal, ByVal RENTA As Decimal, ByVal TC As Decimal, _
    ByVal AUX As String, ByVal COM As String, ByVal NRO_COM As String, ByVal MONEDA As String, _
    ByVal MES_PROC As String)
        Me.DT_CONFIG_PROV3.CONFIG_PROV3.Rows.Add(COD_DOC, DES_DOC, NRO_DOC, FEC_DOC, COD_PER, DOC_PER, DES_PER, BI, IGV, RENTA, TC, AUX, COM, NRO_COM, MONEDA, MES_PROC)
    End Sub

End Class