Imports Microsoft.Reporting.WinForms
Public Class REP_PROV_VENTAS_GASTO
    Private Sub REP_PROV_VENTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_REP_ANA_OTROS.REPORTE_TOTROS_KARDEX_NO_ACUMULADO' Puede moverla o quitarla según sea necesario.
        'Me.REPORTE_TOTROS_KARDEX_NO_ACUMULADOTableAdapter.Fill(Me.DT_REP_ANA_OTROS.REPORTE_TOTROS_KARDEX_NO_ACUMULADO)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal ORD As String, ByVal TITULO As String, ByVal DES_MES As String, ByVal DES_CLIENTE As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("ORD", ORD))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("AÑO1", AÑO))
        parametros.Add(New ReportParameter("DESMES", DES_MES))
        parametros.Add(New ReportParameter("DES_CLIENTE", DES_CLIENTE))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
    Sub LIMPIAR()
        Me.DT_CONFIG_PROV.CONFIG_PROV1.Clear()
    End Sub
    Sub llenar_dt(ByVal COD_COM As String, ByVal NRO_COM As String, ByVal UNION As String, ByVal FEC_DOC As DateTime, ByVal FEC_VEN As DateTime, ByVal NRO_DOC_PER As String, ByVal DES_PROV As String, ByVal COD_PER As String, ByVal COD_DOC As String, ByVal DESC_DOC As String, ByVal MON As String, ByVal serie As String, ByVal total As String, ByVal prov As String, ByVal FALTANTE As String, ByVal st_gasto As String)
        Me.DT_CONFIG_PROV.CONFIG_PROV1.Rows.Add(COD_COM, NRO_COM, UNION, FEC_DOC, FEC_VEN, NRO_DOC_PER, DES_PROV, COD_PER, COD_DOC, DESC_DOC, MON, serie, total, prov, FALTANTE, st_gasto)
    End Sub
End Class