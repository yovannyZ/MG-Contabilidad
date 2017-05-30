Imports Microsoft.Reporting.WinForms
Public Class REP_FORMULARIO_SEGURIDAD

    Private Sub REP_FORMULARIO_SEGURIDAD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'FORMULARIO_SEGURIDAD.CONSULTA_FORMULARIO_SEGURIDAD' Puede moverla o quitarla según sea necesario.
        'Me.CONSULTA_FORMULARIO_SEGURIDADTableAdapter.Fill(Me.FORMULARIO_SEGURIDAD.CONSULTA_FORMULARIO_SEGURIDAD)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.Refresh()
    End Sub
    Sub CREAR_REPORTE(ByVal COD_MODULO As String, ByVal ST_MENU As String, ByVal COD_MENU As String, ByVal DESC_MODULO As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("MODULO", DESC_MODULO))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.CONSULTA_FORMULARIO_SEGURIDADTableAdapter.Connection = con
        Me.CONSULTA_FORMULARIO_SEGURIDADTableAdapter.Fill(Me.FORMULARIO_SEGURIDAD.CONSULTA_FORMULARIO_SEGURIDAD, COD_MODULO, ST_MENU, COD_MENU)
    End Sub
End Class