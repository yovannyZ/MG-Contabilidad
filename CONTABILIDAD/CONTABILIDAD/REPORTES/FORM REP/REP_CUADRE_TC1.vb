Imports Microsoft.Reporting.WinForms
Public Class REP_CUADRE_TC1
    Public op As Integer

    Private Sub REP_CUADRE_TC1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If op = 0 Then
            Me.ReportViewer1.Visible = True
            Me.ReportViewer2.Visible = False
            Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Me.ReportViewer1.Refresh()
            Me.ReportViewer1.RefreshReport()
        ElseIf op = 1 Then
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

        If op = 0 Then
            Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Me.CUADRE_PCTASXC_VS_TCTASXC_DOC1TableAdapter.Connection = con
            Me.CUADRE_PCTASXC_VS_TCTASXC_DOC1TableAdapter.Fill(Me.DT_REP_CUADRE_TC1.CUADRE_PCTASXC_VS_TCTASXC_DOC1, COD_CUENTA, AÑO0, MES0)
        ElseIf op = 1 Then
            Me.ReportViewer2.LocalReport.SetParameters(parametros)
            Me.CUADRE_PCTASXC_VS_TCTASXC1TableAdapter.Connection = con
            Me.CUADRE_PCTASXC_VS_TCTASXC1TableAdapter.Fill(Me.DT_REP_CUADRE_TC2.CUADRE_PCTASXC_VS_TCTASXC1, COD_CUENTA, AÑO0, MES0)
        End If
    End Sub
End Class