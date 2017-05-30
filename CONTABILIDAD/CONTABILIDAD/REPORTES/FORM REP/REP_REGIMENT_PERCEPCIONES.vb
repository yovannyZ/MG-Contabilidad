Imports Microsoft.Reporting.WinForms
Public Class REP_REGIMENT_PERCEPCIONES

    Private Sub REP_REGIMENT_PERCEPCIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_RETENCION.REPORTE_REGIMEN_PERCEPCIONES' Puede moverla o quitarla según sea necesario.
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String, ByVal DES_MES As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("AÑO0", AÑO00))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)

        Me.REPORTE_REGIMEN_PERCEPCIONESTableAdapter.Connection = con
        Me.REPORTE_REGIMEN_PERCEPCIONESTableAdapter.Fill(Me.DT_RETENCION.REPORTE_REGIMEN_PERCEPCIONES, AÑO00, MES00)
    End Sub
End Class