Imports Microsoft.Reporting.WinForms
Public Class REP_PY

    Private Sub REP_PY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_PY.REPORTE_PROYECTO' Puede moverla o quitarla según sea necesario.
        'Me.REPORTE_PROYECTOTableAdapter.Fill(Me.DT_PY.REPORTE_PROYECTO)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal FEC1 As Date, ByVal FEC2 As Date, ByVal COD_PY As String, ByVal DESC_PY As String, ByVal ST_PROYECTO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("PROYECTO", DESC_PY))
        parametros.Add(New ReportParameter("DEL", FEC1))
        parametros.Add(New ReportParameter("AL", FEC2))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_PROYECTOTableAdapter.Connection = con
        Me.REPORTE_PROYECTOTableAdapter.Fill(Me.DT_PY.REPORTE_PROYECTO, FEC1, FEC2.AddDays(1), COD_PY, ST_PROYECTO)
    End Sub
End Class