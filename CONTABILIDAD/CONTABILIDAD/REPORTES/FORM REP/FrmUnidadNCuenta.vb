Imports Microsoft.Reporting.WinForms
Public Class FrmUnidadNCuenta

    Private Sub FrmUnidadNCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
    End Sub

    Public Sub CREAR_REPORTE(ByVal MES As String, ByVal OPCION As String, ByVal año As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("MES", MES))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("OPCION", OPCION))
        parametros.Add(New ReportParameter("AÑO", año))

        For Each ROW As DataRow In Me.DsUnidadNegocioConcepto.DtUnidadNegocio.Rows
            Select Case CStr(ROW("Codigo"))
                Case "1" : parametros.Add(New ReportParameter("UNIDAD01", CStr(ROW("Descripcion"))))
                Case "2" : parametros.Add(New ReportParameter("UNIDAD02", CStr(ROW("Descripcion"))))
                Case "3" : parametros.Add(New ReportParameter("UNIDAD03", CStr(ROW("Descripcion"))))
                Case "4" : parametros.Add(New ReportParameter("UNIDAD04", CStr(ROW("Descripcion"))))
                Case "5" : parametros.Add(New ReportParameter("UNIDAD05", CStr(ROW("Descripcion"))))
                Case "6" : parametros.Add(New ReportParameter("UNIDAD06", CStr(ROW("Descripcion"))))
                Case "7" : parametros.Add(New ReportParameter("UNIDAD07", CStr(ROW("Descripcion"))))
                Case "8" : parametros.Add(New ReportParameter("UNIDAD08", CStr(ROW("Descripcion"))))
                Case "9" : parametros.Add(New ReportParameter("UNIDAD09", CStr(ROW("Descripcion"))))
                Case "0" : parametros.Add(New ReportParameter("UNIDAD10", CStr(ROW("Descripcion"))))
            End Select
        Next

        ReportViewer1.LocalReport.SetParameters(parametros)

    End Sub

    Sub LIMPIAR()
        DsUnidadNegocioConcepto.Dt_3.Clear()
    End Sub
    Public Sub llenar_dt(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal p4 As String, ByVal p5 As String, ByVal p6 As String, ByVal p7 As String, ByVal p8 As String, _
    ByVal p9 As String, ByVal p10 As Decimal, ByVal p11 As Decimal, ByVal p12 As Decimal, ByVal p13 As Decimal, ByVal p14 As Decimal, ByVal p15 As Decimal, ByVal p16 As Decimal, _
    ByVal p17 As Decimal, ByVal p18 As Decimal, ByVal p19 As Decimal, ByVal p20 As Decimal, ByVal p21 As Decimal, ByVal p22 As Decimal, ByVal p23 As Decimal, ByVal p24 As Decimal, _
    ByVal p25 As Decimal, ByVal p26 As Decimal, ByVal p27 As Decimal, ByVal p28 As Decimal, ByVal p29 As Decimal)

        DsUnidadNegocioConcepto.Dt_3.Rows.Add(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, _
         p23, p24, p25, p26, p27, p28, p29)

    End Sub
End Class