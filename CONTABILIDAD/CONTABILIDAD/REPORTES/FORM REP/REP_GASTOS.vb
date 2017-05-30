Imports Microsoft.Reporting.WinForms
Public Class REP_GASTOS
    Public Rep As String
    Private Sub REP_GASTOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Rep = "Orden" Then
            Me.ReportViewer1.Visible = True
            Me.ReportViewer2.Visible = False
            Me.ReportViewer1.RefreshReport()
            Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Me.ReportViewer1.RefreshReport()
        ElseIf Rep = "CC" Then
            Me.ReportViewer1.Visible = False
            Me.ReportViewer2.Visible = True
            Me.ReportViewer2.RefreshReport()
            Me.ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer2.ZoomMode = ZoomMode.PageWidth
            Me.ReportViewer2.RefreshReport()
        End If
    End Sub

    Public Sub CrearReporte(ByVal EMPRESA As String, ByVal RUC As String, ByVal Año As String, ByVal Mes As String, ByVal Desc_Mes As String)
        Try
            Dim Parametros As New List(Of ReportParameter)
            Parametros.Add(New ReportParameter("EMPRESA", EMPRESA))
            Parametros.Add(New ReportParameter("RUC", RUC))
            Parametros.Add(New ReportParameter("DESC_MES", Desc_Mes))
            Parametros.Add(New ReportParameter("AÑO", Año))
            If Rep = "Orden" Then
                ReportViewer1.LocalReport.SetParameters(Parametros)
                Me.REPORTE_GASTOPRODUCCIONTableAdapter.Connection = con
                Me.REPORTE_GASTOPRODUCCIONTableAdapter.Fill(Me.DT_REP_GASTO_PRODUCCION.REPORTE_GASTOPRODUCCION, Año, Mes)
            ElseIf Rep = "CC" Then
                ReportViewer2.LocalReport.SetParameters(Parametros)
                Me.REPORTE_GASTOPRODUCCIONCCTableAdapter.Connection = con
                Me.REPORTE_GASTOPRODUCCIONCCTableAdapter.Fill(Me.DT_REP_GASTO_PRODUCCION.REPORTE_GASTOPRODUCCIONCC, Año, Mes)
            End If
        Catch EX As Exception
            MessageBox.Show(String.Format("Error al crear el reporte.{0}{1}", Environment.NewLine, EX.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class