Imports Microsoft.Reporting.WinForms
Public Class REP_BALANCE_ANUAL

    Private Sub REP_BALANCE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_REP_FORMATO.REPORTE_BALANCE_ANUAL1' Puede moverla o quitarla según sea necesario.
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_FORMATO As String, ByVal MES As String, ByVal DESC_FORMATO As String, ByVal FECHA As DateTime)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_FORMATO", COD_FORMATO))
        parametros.Add(New ReportParameter("DESC_FORMATO", DESC_FORMATO))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("MES", MES))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("FECHA", (FECHA)))
        ReportViewer1.LocalReport.SetParameters(parametros)
        '--------------------------------------------------------------------------
        'Dim I As Integer = 0
        'Dim CONT As Integer = (Me.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Count - 1)
        'I = 0
        'Dim ACTIVO, PASIVO, IMP0, TOT0 As Decimal
        'ACTIVO = 0 : PASIVO = 0 : IMP0 = 0 : TOT0 = 0
        'Do While (I <= CONT)
        '    If (Me.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
        '        ACTIVO = ACTIVO + Me.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(14)
        '    Else
        '        PASIVO = PASIVO + Me.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(14)
        '        TOT0 = Me.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(21)
        '    End If
        '    I += 1
        'Loop
        'IMP0 = (PASIVO * -1) - ACTIVO
        'Dim DESC As String = "GANANCIA DEL EJERCICIO"
        'If IMP0 > 0 Then DESC = "PERDIDA DEL EJERCICIO"
        'Me.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, IMP0, COD_FORMATO, "X", "99", "", "", DESC, TOT0, "")
        '--------------------------------------------------------------------------
    End Sub
End Class