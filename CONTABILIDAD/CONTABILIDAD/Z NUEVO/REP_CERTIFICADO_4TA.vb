Imports Microsoft.Reporting.WinForms
Public Class REP_CERTIFICADO_4TA

    Private Sub REP_CERTIFICADO_4TA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_CONFIG.REPORTE_DET_CERTIFICADO_4TA' Puede moverla o quitarla según sea necesario.
        'Me.REPORTE_DET_CERTIFICADO_4TATableAdapter.Fill(Me.DT_CONFIG.REPORTE_DET_CERTIFICADO_4TA)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
        'Me.ReportViewer1.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES0 As String, ByVal COD_PER As String, _
        ByVal ORDENBI0 As String, ByVal ORDENRENTA0 As String, ByVal TIPO0 As String, ByVal EMISION As Date, _
        ByVal FUNCIONARIO As String, ByVal CARGO As String, ByVal DNI As String, ByVal DIR_PER As String, _
        ByVal SER_PRESTADO As String, ByVal DES_PER As String, ByVal RUC_PER As String, ByVal MONTO_BI As Decimal, _
        ByVal MONTO_RENTA As Decimal, ByVal IND As String, ByVal cRet As Decimal, ByVal sRet As Decimal)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("AÑO0", AÑO00))
        parametros.Add(New ReportParameter("EMISION", EMISION))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("DIR_EMPRESA", DIR_EMPRESA))
        parametros.Add(New ReportParameter("FUNCIONARIO", FUNCIONARIO))
        parametros.Add(New ReportParameter("CARGO", CARGO))
        parametros.Add(New ReportParameter("DNI", DNI))
        parametros.Add(New ReportParameter("DIR_PER", DIR_PER))
        parametros.Add(New ReportParameter("SERVICIO_PRESTADO", SER_PRESTADO))
        parametros.Add(New ReportParameter("DES_PER", DES_PER))
        parametros.Add(New ReportParameter("RUC_PER", RUC_PER))
        parametros.Add(New ReportParameter("MONTO_BI", MONTO_BI))
        parametros.Add(New ReportParameter("MONTO_RENTA", MONTO_RENTA))
        parametros.Add(New ReportParameter("IND", IND))
        parametros.Add(New ReportParameter("cRet", cRet))
        parametros.Add(New ReportParameter("sRet", sRet))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)

        'Me.REPORTE_DET_CERTIFICADO_4TATableAdapter.Connection = con
        'Me.REPORTE_DET_CERTIFICADO_4TATableAdapter.Fill(Me.DT_CONFIG.REPORTE_DET_CERTIFICADO_4TA, MES0, AÑO00, COD_PER, ORDENBI0, ORDENRENTA0, TIPO0)
    End Sub

    Sub LlenarDT(ByVal Serie As String, ByVal Numero As String, ByVal Fecha As DateTime, ByVal BI As Decimal, _
        ByVal Porcentaje As Decimal, ByVal Importe As Decimal)
        Me.DT_CONFIG.DataTable1.Rows.Add(Serie, Numero, Fecha, BI, Porcentaje, Importe)
    End Sub
End Class