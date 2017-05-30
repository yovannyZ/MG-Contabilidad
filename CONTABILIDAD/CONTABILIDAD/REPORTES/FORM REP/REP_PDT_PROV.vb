Imports Microsoft.Reporting.WinForms
Public Class REP_PDT_PROV
    Private Sub REP_PDT_PROV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal TITULO As String, ByVal AÑO0 As String, ByVal REGISTROS As Integer)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        parametros.Add(New ReportParameter("REGISTROS", REGISTROS))
        'parametros.Add(New ReportParameter("IMPORTE", IMPORTES))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
    Public Sub LIMPIAR()
        Me.DT_PDT_PROVISIONES.Clear()
    End Sub

    Public Sub llenar_dt(ByVal COD_DOC As String, ByVal DES_DOC As String, ByVal NRO_DOC As String, ByVal FEC_DOC As String, ByVal COD_PER As String, ByVal DOC_PER As String, ByVal DES_PER As String, ByVal BI As Decimal, ByVal IGV As Decimal, ByVal RENTA As Decimal, ByVal TC As Decimal, ByVal AUX As String, ByVal COM As String, ByVal NRO_COM As String, ByVal MONEDA As String, ByVal COD_TIPO_DOC As String, ByVal NRO_DOC_PER As String, ByVal TIPO_PER As String, ByVal IMPORTE As Decimal)
        Me.DT_PDT_PROVISIONES.PDT.Rows.Add(COD_DOC, DES_DOC, NRO_DOC, FEC_DOC, COD_PER, DOC_PER, DES_PER, BI, IGV, RENTA, TC, AUX, COM, NRO_COM, MONEDA, COD_TIPO_DOC, NRO_DOC_PER, TIPO_PER, IMPORTE)
    End Sub
End Class