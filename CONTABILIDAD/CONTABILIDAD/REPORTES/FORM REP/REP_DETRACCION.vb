Imports Microsoft.Reporting.WinForms
Public Class REP_DETRACCION

    Private Sub REP_DETRACCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta l�nea de c�digo carga datos en la tabla 'DT_DETRACCION.REPORTE_DETRACCION' Puede moverla o quitarla seg�n sea necesario.

        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.REPORTE_DETRACCIONTableAdapter.Fill(Me.DT_DETRACCION.REPORTE_DETRACCION)
    End Sub
    Public Sub CREAR_REPORTE(ByVal A�O0 As String, ByVal DES_MES As String, ByVal COD_MES As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("A�O0", A�O0))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_DETRACCIONTableAdapter.Connection = con
        Me.REPORTE_DETRACCIONTableAdapter.Fill(Me.DT_DETRACCION.REPORTE_DETRACCION, COD_MES, A�O0)
    End Sub
End Class