Imports Microsoft.Reporting.WinForms
Public Class REP_CC_DETALLE1

    Private Sub REP_CC_DETALLE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta l�nea de c�digo carga datos en la tabla 'DT_CC_T_CON.REPORTE_CC_CTA_DETALLE1' Puede moverla o quitarla seg�n sea necesario.
        'Me.REPORTE_CC_CTA_DETALLE1TableAdapter.Fill(Me.DT_CC_T_CON.REPORTE_CC_CTA_DETALLE1 )
        'TODO: esta l�nea de c�digo carga datos en la tabla 'DT_CC_T_CON.REPORTE_CC_CTA_DETALLE1' Puede moverla o quitarla seg�n sea necesario.
        'Me.REPORTE_CC_CTA_DETALLE1TableAdapter.Fill(Me.DT_CC_T_CON.REPORTE_CC_CTA_DETALLE1)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal TITULO As String, ByVal COD_CTA As String, ByVal ST_CTA As String, ByVal COD_CC As String, ByVal ST_CC As String, ByVal A�O0 As String, ByVal MES1 As String, ByVal MES2 As String, ByVal ORD As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("ORD", ORD))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_CC_CTA_DETALLE1TableAdapter.Connection = con
        Me.REPORTE_CC_CTA_DETALLE1TableAdapter.Fill(Me.DT_CC_T_CON.REPORTE_CC_CTA_DETALLE1, COD_CTA, ST_CTA, COD_CC, ST_CC, A�O0, MES1, MES2)
    End Sub
End Class