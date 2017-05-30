Imports Microsoft.Reporting.WinForms
Public Class REP_BALANCE_H

    Private Sub REP_BALANCE_H_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal COD_FORMATO As String, ByVal MES As String, ByVal DESC_FORMATO As String, ByVal FECHA As DateTime)
        Dim FALTA As Integer
        Dim STATUS As String
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("COD_FORMATO", COD_FORMATO))
        parametros.Add(New ReportParameter("DESC_FORMATO", DESC_FORMATO))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("MES", MES))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        parametros.Add(New ReportParameter("FECHA", (FECHA)))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.REPORTE_BALANCETableAdapter.Connection = con
        Me.REPORTE_BALANCETableAdapter.Fill(Me.DT_REP_FORMATO.REPORTE_BALANCE, COD_FORMATO)
        '------------------------------------------------------------------------------
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Count - 1)
        Dim CONTA As Integer = 0
        Dim CONTX As Integer = 0
        I = 0
        Dim ACTIVO, PASIVO, IMP0, TOT0 As Decimal
        ACTIVO = 0 : PASIVO = 0 : IMP0 = 0 : TOT0 = 0
        Do While (I <= CONT)
            If (Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Item(I).Item(7).ToString = "A") Then
                CONTA += 1
                ACTIVO = ACTIVO + Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Item(I).Item(3)
            Else
                CONTX += 1
                PASIVO = PASIVO + Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Item(I).Item(3)
                TOT0 = Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Item(I).Item(8)
            End If
            I += 1
        Loop
        IMP0 = (PASIVO * -1) - ACTIVO
        Dim DESC As String = "GANANCIA DEL EJERCICIO"
        If IMP0 > 0 Then DESC = "PERDIDA DEL EJERCICIO"
        Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Add(New Object() {COD_FORMATO, "99", "", IMP0, "", "", DESC, "X", TOT0})
        '--------------------------------------------------------------------------
        CONTX = CONTX + 1
        If (CONTA > CONTX) Then
            FALTA = (CONTA - CONTX)
            STATUS = "X"
        Else
            FALTA = (CONTX - CONTA)
            STATUS = "A"
        End If
        Dim CONT1 As Integer = (FALTA - 5)
        Dim I2 As Integer = 0
        Do While (I2 <= CONT1)
            'Do While (I2 <= FALTA)
            Me.DT_REP_FORMATO.REPORTE_BALANCE.Rows.Add(New Object() {"", "", "", 0, "", "", "", STATUS, 1})
            I2 += 1
        Loop
    End Sub

End Class