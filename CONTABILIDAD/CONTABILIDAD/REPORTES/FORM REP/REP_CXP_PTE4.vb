Imports Microsoft.Reporting.WinForms
Public Class REP_CXP_PTE4

    Private Sub REP_CXP_PTE4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal FECHA1 As String, ByVal FECHA2 As String)
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("FECHA_DEL", FECHA1))
        parametros.Add(New ReportParameter("FECHA_AL", FECHA2))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
    End Sub
    Public Sub parametros(ByVal cod_sucursal As String, ByVal cod_per As String, ByVal status_suc As String, ByVal status_per As String, ByVal fecha1 As DateTime, ByVal fecha2 As DateTime, ByVal STATUS_DOC As String, ByVal COD_DOC As String, ByVal DIAS As Integer, ByVal BLOQUES As Integer, ByVal DEL_1 As DateTime, ByVal STATUS_CTA As String, ByVal COD_CTA As String)
        fecha2 = fecha2.Date.AddDays(1)
        Me.REPORTE_CXP_PTES3TableAdapter.Connection = con
        Me.REPORTE_CXP_PTES3TableAdapter.Fill(Me.DT_REPORTES.REPORTE_CXP_PTES3, cod_sucursal, status_suc, fecha1, fecha2, status_per, cod_per, STATUS_DOC, COD_DOC, STATUS_CTA, COD_CTA)
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.DT_REPORTES.REPORTE_CXP_PTES3.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim FECHA_Q As DateTime
            Dim FECHA As DateTime = Date.Parse(Me.DT_REPORTES.REPORTE_CXP_PTES3.Rows.Item(I).Item(8))
            If (DateTime.Compare(FECHA, DEL_1) <= 0) Then
                FECHA_Q = DEL_1
            Else
                Dim J As Integer = 0
                J = 0
                Do While (J <= BLOQUES)
                    If (DateTime.Compare(FECHA, DEL_1.AddDays(CDbl((DIAS * J)))) <= 0) Then
                        FECHA_Q = DEL_1.AddDays(CDbl((DIAS * J)))
                        Exit Do
                    End If
                    J += 1
                Loop
            End If
            Me.DT_REPORTES.REPORTE_CXP_PTES3.Rows.Item(I).Item(15) = FECHA_Q
            Me.DT_REPORTES.REPORTE_CXP_PTES3.Rows.Item(I).Item(16) = 1
            I += 1
        Loop
    End Sub


End Class