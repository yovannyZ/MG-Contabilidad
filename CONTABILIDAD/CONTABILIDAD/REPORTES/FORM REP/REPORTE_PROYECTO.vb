Imports Microsoft.Reporting.WinForms
Public Class REPORTE_PROYECTO
    Private Sub REPORTE_PROYECTO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(34) = 0
    End Sub
    Private Sub REPORTE_PROYECTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'PARAMETROS
        ''''''''''''''''''''''''''''''''''''''''''
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        ' Añado el/los parámetro/s al ReportViewer.
        ReportViewer1.LocalReport.SetParameters(parametros)
        ''''''''''''''''''''''''''''''''''''''''''''
        'LLENADO DE DATASET
        ''''''''''''''''''''''''''''''''''''''''''''
        PROYECTOTableAdapter.Connection = con
        PROYECTOTableAdapter.Fill(Me.DT_CENTRO_COSTOS.PROYECTO)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'IMPRESION
        ''''''''''''''''''''''''''''''''''''''''''''
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.RefreshReport()
    End Sub
End Class