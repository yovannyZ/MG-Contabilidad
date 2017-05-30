Imports Microsoft.Reporting.WinForms
Public Class REP_MAYOR
    Public HOJA As String
    Public OCULTAR_TOTAL As Boolean = True
    Private Sub REP_MAYOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ReportViewer2.RefreshReport()
        Me.ReportViewer2.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal MES0 As String, ByVal EMISION As DateTime)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES", MES0))
        parametros.Add(New ReportParameter("EMISION", (EMISION)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("OCULTAR_TOTAL", OCULTAR_TOTAL))
        'Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Select Case HOJA
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Case "02"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
        End Select
    End Sub
    Sub UBICAR_REPORTE()
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ReportViewer2.Visible = False
        Select Case HOJA
            Case "01" : ReportViewer1.Visible = True
            Case "02" : ReportViewer2.Visible = True
        End Select
    End Sub
End Class