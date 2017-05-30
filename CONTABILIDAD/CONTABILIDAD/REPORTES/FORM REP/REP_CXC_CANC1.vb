Imports Microsoft.Reporting.WinForms
Public Class REP_CXC_CANC1
    Public TIPO_REP As String
    Private Sub REP_CXC_CANC1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case TIPO_REP
            Case "01"
                ReportViewer1.RefreshReport()
                ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Case "02"
                ReportViewer2.RefreshReport()
                ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer2.ZoomMode = ZoomMode.PageWidth
            Case "03"
                ReportViewer3.RefreshReport()
                ReportViewer3.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer3.ZoomMode = ZoomMode.PageWidth
        End Select
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
        ReportViewer2.RefreshReport()
        Me.ReportViewer2.Refresh()
    End Sub
    Public Sub CREAR_REPORTE(ByVal FECHA1 As String, ByVal FECHA2 As String)
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA_DEL", FECHA1))
        parametros.Add(New ReportParameter("FECHA_AL", FECHA2))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Select Case TIPO_REP
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Case "02"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
            Case "03"
                Me.ReportViewer3.LocalReport.SetParameters(parametros)
        End Select
    End Sub
    Sub LIMPIAR()
        REPORTE_VARIOS.REPORTE_CXC_CANC1.Clear()
    End Sub
    Public Sub parametros(ByVal cod_sucursal As String, ByVal cod_per As String, ByVal status_suc As String, ByVal status_per As String, ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, ByVal ST_BANCO As String, ByVal COD_BANCO As String)
        fecha2 = fecha2.Date.AddDays(1)
        Me.REPORTE_CXC_CANC1TableAdapter.Connection = con
        REPORTE_CXC_CANC1TableAdapter.Fill(Me.REPORTE_VARIOS.REPORTE_CXC_CANC1, status_suc, cod_sucursal, status_per, cod_per, fecha1, fecha2, ST_BANCO, COD_BANCO)
        '-----------------------------------------------------
    End Sub
    Sub UBICAR_REPORTE()
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ReportViewer2.Visible = False
        ReportViewer3.Visible = False
        '-------------------
        Select Case TIPO_REP
            Case "01" : ReportViewer1.Visible = True
            Case "02" : ReportViewer2.Visible = True
            Case "03" : ReportViewer3.Visible = True
        End Select
        '-------------------
    End Sub
End Class