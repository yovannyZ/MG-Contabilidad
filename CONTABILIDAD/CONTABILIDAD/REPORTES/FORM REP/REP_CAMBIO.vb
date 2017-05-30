Imports Microsoft.Reporting.WinForms
Public Class REP_CAMBIO
    Public al As DateTime
    Public cod_mon As String
    Public del As DateTime
    Public DESC_MON As String
    Private Sub REP_CAMBIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_REP_CAMBIO.TIPO_CAMBIO' Puede moverla o quitarla según sea necesario.
        'Me.TIPO_CAMBIOTableAdapter.Fill(Me.DT_REP_CAMBIO.TIPO_CAMBIO)
        'Me.ReportViewer1.RefreshReport()
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("MONEDA", Me.DESC_MON))
        parametros.Add(New ReportParameter("COD_USU", DESC_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.TIPO_CAMBIOTableAdapter.Connection = con2
        Me.TIPO_CAMBIOTableAdapter.Fill(Me.DT_REP_CAMBIO.TIPO_CAMBIO, cod_mon, del, al)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.Refresh()
    End Sub
End Class