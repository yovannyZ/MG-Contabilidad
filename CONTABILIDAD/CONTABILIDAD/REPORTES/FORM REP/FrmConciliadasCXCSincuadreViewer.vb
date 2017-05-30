Imports Microsoft.Reporting.WinForms
Public Class FrmConciliadasCXCSincuadreViewer

    Private Sub FrmConciliadasCXCSincuadreViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub


    Public Sub CREAR_REPORTE(ByVal MES As String, ByVal codCuenta As String, ByVal desCuenta As String, ByVal anio As String, ByVal titulo As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", MES))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", anio))
        parametros.Add(New ReportParameter("COD_CUENTA", codCuenta))
        parametros.Add(New ReportParameter("DES_CUENTA", desCuenta))
        parametros.Add(New ReportParameter("TITULO", titulo))
        ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub

    Sub LIMPIAR()
        DsConciliadasSinCuadrar.Dt_01.Clear()
    End Sub

    Public Sub llenar_dt(ByVal p1 As String, ByVal p2 As String, ByVal p3 As Date, ByVal p4 As String, ByVal p5 As String, ByVal p6 As String, ByVal p7 As Date, ByVal p8 As String, _
     ByVal p9 As String, ByVal p10 As String, ByVal p11 As String, ByVal p12 As String, ByVal p13 As Decimal, ByVal p14 As Decimal, ByVal p15 As String, ByVal p16 As String, ByVal p17 As Decimal, _
     ByVal p18 As String, ByVal p19 As Date, ByVal p20 As String)
        DsConciliadasSinCuadrar.Dt_01.Rows.Add(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20)
    End Sub
End Class