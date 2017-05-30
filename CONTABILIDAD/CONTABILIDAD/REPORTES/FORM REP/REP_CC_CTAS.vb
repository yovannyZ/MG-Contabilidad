Imports Microsoft.Reporting.WinForms
Public Class REP_CC_CTAS
    Private Sub REP_CC_CTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_CONC_PTE.REPORTE_BANCO_CONC_PTE' Puede moverla o quitarla según sea necesario.
        'Me.REPORTE_BANCO_CONC_PTETableAdapter.Fill(Me.DT_CONC_PTE.REPORTE_BANCO_CONC_PTE)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.REPORTE_CC_CTASTableAdapter.Fill(Me.DT_CC_T_CON.REPORTE_CC_CTAS)
    End Sub
    Sub CREAR_REPORTE(ByVal MES_AL As String, ByVal COD_CTA As String, ByVal ST_CTA As String, ByVal COD_MONEDA As String, ByVal P1 As Integer, ByVal P2 As Integer, ByVal P3 As Integer, ByVal P4 As Integer, ByVal P5 As Integer, ByVal P6 As Integer, ByVal P7 As Integer, ByVal P8 As Integer, ByVal P9 As Integer, ByVal P10 As Integer, ByVal P11 As Integer, ByVal P12 As Integer, ByVal DES_MONEDA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("MES_AL", MES_AL))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("P1", (P1)))
        parametros.Add(New ReportParameter("P2", (P2)))
        parametros.Add(New ReportParameter("P3", (P3)))
        parametros.Add(New ReportParameter("P4", (P4)))
        parametros.Add(New ReportParameter("P5", (P5)))
        parametros.Add(New ReportParameter("P6", (P6)))
        parametros.Add(New ReportParameter("P7", (P7)))
        parametros.Add(New ReportParameter("P8", (P8)))
        parametros.Add(New ReportParameter("P9", (P9)))
        parametros.Add(New ReportParameter("P10", (P10)))
        parametros.Add(New ReportParameter("P11", (P11)))
        parametros.Add(New ReportParameter("P12", (P12)))
        parametros.Add(New ReportParameter("DES_MONEDA", DES_MONEDA))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        'Me.REPORTE_CC_CTASTableAdapter.Connection = con
        'Me.REPORTE_CC_CTASTableAdapter.Fill(Me.DT_CC_T_CON.REPORTE_CC_CTAS, ST_CTA, COD_CTA, COD_MONEDA, AÑO)
    End Sub
    Sub LIMPIAR()
        DT_CC_T_CON.REPORTE_CC_CTAS2.Clear()
    End Sub

    Sub llenar_dt(ByVal COD_CC As String, ByVal DES_AREA As String, ByVal DES_CTA As String, ByVal COD_CTA As String, ByVal C1 As Decimal, ByVal C2 As Decimal, ByVal C3 As Decimal, ByVal C4 As Decimal, ByVal C5 As Decimal, ByVal C6 As Decimal, ByVal C7 As Decimal, ByVal C8 As Decimal, ByVal C9 As Decimal, ByVal C10 As Decimal, ByVal C11 As Decimal, ByVal C12 As Decimal, ByVal TOTAL As Decimal)
        DT_CC_T_CON.REPORTE_CC_CTAS2.Rows.Add(COD_CC, DES_AREA, DES_CTA, COD_CTA, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, TOTAL)
    End Sub
End Class