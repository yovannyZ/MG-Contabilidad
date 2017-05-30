Imports Microsoft.Reporting.WinForms
Public Class REP_DIARIO_DET
    Public HOJA As String
    Private Sub REP_DIARIO_DET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       Select Case HOJA
            Case "01"
                ReportViewer1.RefreshReport()
                ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer1.ZoomMode = ZoomMode.PageWidth
                'ReportViewer1.RefreshReport()
            Case "02"
                ReportViewer2.RefreshReport()
                ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer2.ZoomMode = ZoomMode.PageWidth
                'ReportViewer2.RefreshReport()
        End Select
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
        ReportViewer2.RefreshReport()
    End Sub

    Public Sub CREAR_REPORTE(ByVal EMISION As DateTime, ByVal COD_MES As String, ByVal DESC_MES As String, _
            ByVal COD_AUX As String, ByVal STATUS_AUX As String, ByVal TITULO As String, ByVal MOSTRAR_TOTAL As Boolean)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("MES", DESC_MES))
        parametros.Add(New ReportParameter("EMISION", (EMISION)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("DESC_MES", DESC_MES))
        parametros.Add(New ReportParameter("MOSTRAR_TOTAL", MOSTRAR_TOTAL))
        'Me.ReportViewer1.LocalReport.SetParameters(parametros)
        'Me.REPORTE_DIARIO_DETTableAdapter.Connection = con
        'Me.REPORTE_DIARIO_DETTableAdapter.Fill(Me.DT_REP_DIARIO_DET.REPORTE_DIARIO_DET, AÑO, COD_MES, COD_AUX, STATUS_AUX)
        Select Case HOJA
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
                Me.REPORTE_DIARIO_DETTableAdapter.Connection = con
                Me.REPORTE_DIARIO_DETTableAdapter.CommandTimeOut = 720
                Me.REPORTE_DIARIO_DETTableAdapter.Fill(Me.DT_REP_DIARIO_DET.REPORTE_DIARIO_DET, AÑO, COD_MES, COD_AUX, STATUS_AUX)
            Case "02"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
                Me.REPORTE_DIARIO_DETTableAdapter.Connection = con
                Me.REPORTE_DIARIO_DETTableAdapter.CommandTimeOut = 720
                Me.REPORTE_DIARIO_DETTableAdapter.Fill(Me.DT_REP_DIARIO_DET.REPORTE_DIARIO_DET, AÑO, COD_MES, COD_AUX, STATUS_AUX)
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