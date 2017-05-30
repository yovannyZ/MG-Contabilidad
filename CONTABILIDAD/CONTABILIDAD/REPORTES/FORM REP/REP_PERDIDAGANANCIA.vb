Imports Microsoft.Reporting.WinForms
Public Class REP_PERDIDAGANANCIA
    Public TIPOK As String
    Private Sub REP_ESTADISTICA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case TIPOK
            Case "01"
                ReportViewer1.RefreshReport()
                ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Case "02"
                ReportViewer2.RefreshReport()
                ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer2.ZoomMode = ZoomMode.PageWidth
            Case "03"
                ReportViewer3.RefreshReport()
                ReportViewer3.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer3.ZoomMode = ZoomMode.PageWidth
            Case "04"
                ReportViewer3.RefreshReport()
                ReportViewer3.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer3.ZoomMode = ZoomMode.PageWidth
        End Select
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()

        ReportViewer2.RefreshReport()
        Me.ReportViewer2.RefreshReport()

        ReportViewer3.RefreshReport()
        Me.ReportViewer3.RefreshReport()

        ReportViewer4.RefreshReport()
        Me.ReportViewer4.RefreshReport()

    End Sub
    Sub CREAR_REPORTE(ByVal DES_MES As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        'Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.ReportViewer1.Clear()
        Select Case TIPOK
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Case "02"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
            Case "03"
                Me.ReportViewer3.LocalReport.SetParameters(parametros)
            Case "04"
                Me.ReportViewer4.LocalReport.SetParameters(parametros)
        End Select
    End Sub
    Sub UBICAR_REPORTE()
        '-------------------
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ReportViewer2.Visible = False
        ReportViewer3.Visible = False
        ReportViewer4.Visible = False
        '-------------------
        Select Case TIPOK
            Case "01" : ReportViewer1.Visible = True
            Case "02" : ReportViewer2.Visible = True
            Case "03" : ReportViewer3.Visible = True
            Case "04" : ReportViewer4.Visible = True
        End Select
        '-------------------
    End Sub
End Class