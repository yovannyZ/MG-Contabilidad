Imports Microsoft.Reporting.WinForms
Public Class REP_CUADRE_TP1
    Public op As Reporte
    Public Enum Reporte
        Saldos = 0
        Documentos = 1
    End Enum

    Private Sub REP_CUADRE_TP1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If op = Reporte.Documentos Then
            Me.ReportViewer1.Visible = True
            Me.ReportViewer2.Visible = False
            Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Me.ReportViewer1.Refresh()
            Me.ReportViewer1.RefreshReport()
        ElseIf op = Reporte.Saldos Then
            Me.ReportViewer1.Visible = False
            Me.ReportViewer2.Visible = True
            Me.ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer2.ZoomMode = ZoomMode.PageWidth
            Me.ReportViewer2.Refresh()
            Me.ReportViewer2.RefreshReport()
        End If

    End Sub
    Public Sub CREAR_REPORTE(ByVal AÑO0 As String, ByVal MES0 As String, ByVal DESC_MES As String, ByVal COD_CUENTA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("PERIODO", String.Format("{0} {1}", DESC_MES, AÑO0)))

        If op = Reporte.Documentos Then
            Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter.Connection = con
            Me.CUADRE_PCTASXP_VS_TCTASXP_DOC1TableAdapter.Fill(Me.DT_REP_CUADRE_TP1.CUADRE_PCTASXP_VS_TCTASXP_DOC1, COD_CUENTA, AÑO0, MES0)
        ElseIf op = Reporte.Saldos Then
            Me.ReportViewer2.LocalReport.SetParameters(parametros)
            Me.CUADRE_PCTASXP_VS_TCTASXP1TableAdapter.Connection = con
            Me.CUADRE_PCTASXP_VS_TCTASXP1TableAdapter.Fill(Me.DT_REP_CUADRE_TP2.CUADRE_PCTASXP_VS_TCTASXP1, COD_CUENTA, AÑO0, MES0)
        End If
    End Sub
End Class