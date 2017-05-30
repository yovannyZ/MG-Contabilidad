Imports Microsoft.Reporting.WinForms
Public Class REP_BALANCE_PER

    Private Sub REP_BALANCE_PER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_FORMATO As String, ByVal MES As String, ByVal DESC_FORMATO As String, ByVal FECHA As DateTime, ByVal AÑO_ANT As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_FORMATO", COD_FORMATO))
        parametros.Add(New ReportParameter("DESC_FORMATO", DESC_FORMATO))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("AÑO1", AÑO))
        parametros.Add(New ReportParameter("AÑO2", AÑO_ANT))
        parametros.Add(New ReportParameter("MES", MES))
        parametros.Add(New ReportParameter("FECHA", (FECHA)))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_BALANCE_PERTableAdapter.Connection = con
        Me.REPORTE_BALANCE_PERTableAdapter.Fill(Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER, COD_FORMATO)
        '--------------------------------------------------------------------------
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Count - 1)
        I = 0
        Dim ACTIVO, PASIVO, IMP0, TOT0 As Decimal
        Dim ACTIVO2, PASIVO2, IMP02, TOT02 As Decimal
        ACTIVO = 0 : PASIVO = 0 : IMP0 = 0 : TOT0 = 0
        ACTIVO2 = 0 : PASIVO2 = 0 : IMP02 = 0 : TOT02 = 0
        Do While (I <= CONT)
            If (Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(8).ToString = "A") Then
                ACTIVO = ACTIVO + Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(3)
                ACTIVO2 = ACTIVO2 + Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(4)
            Else
                PASIVO = PASIVO + Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(3)
                PASIVO2 = PASIVO2 + Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(4)
                TOT0 = Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(9)
                TOT02 = Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Item(I).Item(10)
            End If
            I += 1
        Loop
        IMP0 = (PASIVO * -1) - ACTIVO
        IMP02 = (PASIVO2 * -1) - ACTIVO2
        Dim DESC As String = "GANANCIA DEL EJERCICIO"
        Dim DESC2 As String = "GANANCIA DEL EJERCICIO"
        If IMP0 > 0 Then DESC = "PERDIDA DEL EJERCICIO"
        If IMP02 > 0 Then DESC2 = "PERDIDA DEL EJERCICIO"
        Me.DT_REP_FORMATO_PER.REPORTE_BALANCE_PER.Rows.Add(New Object() {COD_FORMATO, "99", "", IMP0, IMP02, "", "", DESC & " / " & DESC2, "X", TOT0, TOT02})
        '--------------------------------------------------------------------------
    End Sub

End Class