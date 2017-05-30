Imports Microsoft.Reporting.WinForms
Public Class REP_CONCILIADO_OTROS
    Public HOJA As String
    Private Sub REP_CONCILIADO_OTROS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case HOJA
            Case "01"
                ReportViewer1.RefreshReport()
                ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Case "02"
                ReportViewer2.RefreshReport()
                ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer2.ZoomMode = ZoomMode.PageWidth
        End Select
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
        ReportViewer2.Refresh()
    End Sub
    Sub CREAR_REPORTE(ByVal DES_MES As String, ByVal DES_CTA As String, ByVal COD_CTA As String, ByVal AÑO0 As String, ByVal COD_MES As String, ByVal S_CONCILIADO As String, ByVal COD_PER As String, ByVal S_PER As String, ByVal FECHA_CONC As DateTime, ByVal ORDEN As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("DES_CUENTA", DES_CTA))
        parametros.Add(New ReportParameter("COD_CUENTA", COD_CTA))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        parametros.Add(New ReportParameter("ORDEN", ORDEN))
        'Me.ReportViewer1.LocalReport.SetParameters(parametros)
        'Me.REPORTE_CONCILIADAS_OTROSTableAdapter.Connection = con
        'Me.REPORTE_CONCILIADAS_OTROSTableAdapter.Fill(Me.DT_REP_ANA_OTROS.REPORTE_CONCILIADAS_OTROS, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, COD_PER, S_PER, FECHA_CONC)
        Select Case HOJA
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
                Me.REPORTE_CONCILIADAS_OTROSTableAdapter.Connection = con
                Me.REPORTE_CONCILIADAS_OTROSTableAdapter.Fill(Me.DT_REP_ANA_OTROS.REPORTE_CONCILIADAS_OTROS, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, COD_PER, S_PER, FECHA_CONC)
            Case "02"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
                Me.REPORTE_CONCILIADAS_OTROSTableAdapter.Connection = con
                Me.REPORTE_CONCILIADAS_OTROSTableAdapter.Fill(Me.DT_REP_ANA_OTROS.REPORTE_CONCILIADAS_OTROS, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, COD_PER, S_PER, FECHA_CONC)
        End Select
    End Sub


    Sub UBICAR_REPORTE()
        '-------------------
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ReportViewer2.Visible = False
        '-------------------
        Select Case HOJA
            Case "01" : ReportViewer1.Visible = True
            Case "02" : ReportViewer2.Visible = True
        End Select
        '-------------------
    End Sub

End Class