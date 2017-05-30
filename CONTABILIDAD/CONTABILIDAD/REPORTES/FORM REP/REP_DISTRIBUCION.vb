Imports Microsoft.Reporting.WinForms
Public Class REP_DISTRIBUCION
    Public FICHA As String
    Private Sub REP_DISTRIBUCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FICHA = "0" Then
            ReportViewer1.RefreshReport()
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.PageWidth
            ReportViewer1.RefreshReport()
            ReportViewer1.Refresh()
        Else
            ReportViewer2.RefreshReport()
            ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer2.ZoomMode = ZoomMode.PageWidth
            ReportViewer2.RefreshReport()
            ReportViewer2.Refresh()
        End If
    End Sub

    Sub CREAR_REPORTE(ByVal STNEG As String, ByVal CODNEG As String, ByVal ST_CC As String, ByVal COD_CC As String, ByVal FE_AÑO As String, ByVal FE_MES As String)
        Dim PARAMETROS As New List(Of ReportParameter)
        If FICHA = "0" Then
            PARAMETROS.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
            PARAMETROS.Add(New ReportParameter("RUC", RUC_EMPRESA))
            Me.ReportViewer1.LocalReport.SetParameters(PARAMETROS)
            Me.REPORTE_DISTRIBUCIONTableAdapter.Connection = con
            Me.REPORTE_DISTRIBUCIONTableAdapter.Fill(Me.DT_ESTADISTICA.REPORTE_DISTRIBUCION, STNEG, CODNEG, ST_CC, COD_CC, FICHA, FE_AÑO, FE_MES)
        ElseIf FICHA = "1" Then
            PARAMETROS.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
            PARAMETROS.Add(New ReportParameter("RUC", RUC_EMPRESA))
            Me.ReportViewer2.LocalReport.SetParameters(PARAMETROS)
            Me.REPORTE_DISTRIBUCIONTableAdapter.Connection = con
            Me.REPORTE_DISTRIBUCIONTableAdapter.Fill(Me.DT_ESTADISTICA.REPORTE_DISTRIBUCION, STNEG, CODNEG, ST_CC, COD_CC, FICHA, FE_AÑO, FE_MES)
        End If
    End Sub
    Sub VISUALIZAR_REPORTVIEWER()
        ReportViewer1.Visible = False : ReportViewer2.Visible = False
        If FICHA = "0" Then
            ReportViewer1.Visible = True : ReportViewer2.Visible = False
        ElseIf FICHA = "1" Then
            ReportViewer1.Visible = False : ReportViewer2.Visible = True
        End If
    End Sub
End Class