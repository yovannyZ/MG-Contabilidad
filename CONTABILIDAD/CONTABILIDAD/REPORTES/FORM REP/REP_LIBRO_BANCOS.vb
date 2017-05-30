Imports Microsoft.Reporting.WinForms
Public Class REP_LIBRO_BANCOS

    Private Sub REP_LIBRO_BANCOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub CREAR_REPORTE(ByVal COD_BANCO As String, ByVal DESC_BANCO As String, ByVal NRO_CUENTA As String, _
        ByVal DESC_MES As String, ByVal MES00 As String, ByVal AÑO00 As String, ByVal COD_CUENTA As String)
        Dim Parametros As New List(Of ReportParameter)
        Parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        Parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        Parametros.Add(New ReportParameter("COD_BANCO", COD_BANCO))
        Parametros.Add(New ReportParameter("DESC_BANCO", DESC_BANCO))
        Parametros.Add(New ReportParameter("NRO_CUENTA", NRO_CUENTA))
        Parametros.Add(New ReportParameter("DESC_MES", DESC_MES))
        Parametros.Add(New ReportParameter("AÑO", AÑO00))
        Parametros.Add(New ReportParameter("COD_CUENTA", COD_CUENTA))

        Me.ReportViewer1.LocalReport.SetParameters(Parametros)
        'TODO: esta línea de código carga datos en la tabla 'DT_REP_LIBRO_BANCOS.LIBRO_BANCOS' Puede moverla o quitarla según sea necesario.
        Me.LIBRO_BANCOSTableAdapter.Connection = con
        Me.LIBRO_BANCOSTableAdapter.Fill(Me.DT_REP_LIBRO_BANCOS.LIBRO_BANCOS, COD_BANCO, MES00, AÑO00)

        'Me.ReportViewer1.RefreshReport()
    End Sub
End Class