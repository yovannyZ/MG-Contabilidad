Imports Microsoft.Reporting.WinForms
Public Class REP_PERCEPCION
    Private Sub REP_RETENCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_RETENCION.REPORTE_PERCEPCION' Puede moverla o quitarla según sea necesario.
        'Me.REPORTE_PERCEPCIONTableAdapter.Fill(Me.DT_RETENCION.REPORTE_PERCEPCION)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String, ByVal DES_MES As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("AÑO0", AÑO00))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_PERCEPCIONTableAdapter.Connection = con
        Me.REPORTE_PERCEPCIONTableAdapter.Fill(Me.DT_RETENCION.REPORTE_PERCEPCION, AÑO00, MES00)
    End Sub
End Class