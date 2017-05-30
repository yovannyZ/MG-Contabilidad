Imports Microsoft.Reporting.WinForms
Public Class FrmEstadisitcaUNConceptoViewer

    Private Sub FrmEstadisitcaUNConceptoViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub

    Public Sub CREAR_REPORTE(ByVal MES As String, ByVal año As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", MES))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", año))
        ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub

    Sub LIMPIAR()
        DsUnidadNegocioConcepto.Dt_4.Clear()
    End Sub

    Public Sub llenar_dt(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal p4 As String, ByVal p5 As String, ByVal p6 As String, ByVal p7 As String, ByVal p8 As String, _
     ByVal p9 As String, ByVal p10 As String, ByVal p11 As String, ByVal p12 As Decimal, ByVal p13 As Decimal, ByVal p14 As Decimal, ByVal p15 As Decimal, ByVal p16 As Decimal, ByVal p17 As Decimal, _
     ByVal p18 As Decimal, ByVal p19 As Decimal, ByVal p20 As Decimal, ByVal p21 As Decimal, ByVal p22 As Decimal, ByVal p23 As Decimal, ByVal p24 As Decimal, ByVal p25 As Decimal, ByVal p26 As Decimal, _
     ByVal p27 As Decimal, ByVal p28 As Decimal, ByVal p29 As Decimal, ByVal p30 As Decimal, ByVal p31 As Decimal, ByVal p32 As Decimal, ByVal p33 As Decimal, ByVal p34 As Decimal, ByVal p35 As Decimal)
        DsUnidadNegocioConcepto.Dt_4.Rows.Add(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35)
    End Sub
End Class