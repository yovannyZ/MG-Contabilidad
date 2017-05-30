Imports Microsoft.Reporting.WinForms
Public Class REPORTE_CC

    Private Sub reporte_centro_costos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(33) = 0
    End Sub

    Private Sub reporte_centro_costos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       'PARAMETROS
        ''''''''''''''''''''''''''''''''''''''''''
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        ' A�ado el/los par�metro/s al ReportViewer.
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        ''''''''''''''''''''''''''''''''''''''''''''
        'LLENADO DE DATASET
        'me.
        'TODO: esta l�nea de c�digo carga datos en la tabla 'DT_CENTRO_COSTOS.CENTRO_COSTOS' Puede moverla o quitarla seg�n sea necesario.
        CENTRO_COSTOSTableAdapter.Connection = con
        Me.CENTRO_COSTOSTableAdapter.Fill(Me.DT_CENTRO_COSTOS.CENTRO_COSTOS)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'IMPRESION
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class