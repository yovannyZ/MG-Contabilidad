Imports Microsoft.Reporting.WinForms
Public Class REPORTE_AUX_COMP

    Private Sub REPORTE_AUX_COMP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(35) = 0
    End Sub

    Private Sub REPORTE_AUX_COMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_CENTRO_COSTOS.AUX_COMPROBANTE' Puede moverla o quitarla según sea necesario.
        'Me.AUX_COMPROBANTETableAdapter.Fill(Me.DT_CENTRO_COSTOS.AUX_COMPROBANTE)
        'Me.ReportViewer1.RefreshReport()
        'PARAMETROS
        ''''''''''''''''''''''''''''''''''''''''''
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        ' Añado el/los parámetro/s al ReportViewer.
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        ''''''''''''''''''''''''''''''''''''''''''''
        'LLENADO DE DATASET
        ''''''''''''''''''''''''''''''''''''''''''''
        AUX_COMPROBANTETableAdapter.Connection = con
        Me.AUX_COMPROBANTETableAdapter.Fill(Me.DT_CENTRO_COSTOS.AUX_COMPROBANTE)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'IMPRESION
        ''''''''''''''''''''''''''''''''''''''''''''
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class