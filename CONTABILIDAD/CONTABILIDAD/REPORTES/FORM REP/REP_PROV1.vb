Imports Microsoft.Reporting.WinForms
Public Class REP_PROV1
    Public HOJA As String
    Private Sub REP_PROV1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case HOJA
            Case "02"
                ReportViewer1.RefreshReport()
                ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Case "01"
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
        Me.ReportViewer2.RefreshReport()

        ReportViewer3.RefreshReport()
        ReportViewer3.Refresh()
        Me.ReportViewer3.RefreshReport()
    End Sub
    Sub CREAR_REPORTE(ByVal FILA1 As String, ByVal FILA2 As String, ByVal PAG As Integer, ByVal FEC As DateTime, ByVal ORD As String, ByVal TITULO As String, ByVal DES_MES As String, ByVal AÑO00 As String, ByVal DES_CLIENTE As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("FILA1", FILA1))
        parametros.Add(New ReportParameter("FILA2", FILA2))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("NRO_PAG", PAG))
        parametros.Add(New ReportParameter("FECHA", (FEC)))
        parametros.Add(New ReportParameter("ORD", ORD))
        parametros.Add(New ReportParameter("TITULO", TITULO))
        parametros.Add(New ReportParameter("AÑO1", AÑO00))
        parametros.Add(New ReportParameter("DESMES", DES_MES))
        parametros.Add(New ReportParameter("DES_CLIENTE", DES_CLIENTE))
        'Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Select Case HOJA
            Case "02"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Case "01"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
            Case "03"
                Me.ReportViewer3.LocalReport.SetParameters(parametros)
        End Select
    End Sub
    Sub LIMPIAR()
        Me.DT_CONFIG_PROV.Clear()
    End Sub
    Sub llenar_dt(ByVal COD_COM As String, ByVal NRO_COM As String, ByVal UNION As String, ByVal FEC_DOC As DateTime, ByVal FEC_VEN As DateTime, ByVal NRO_DOC_PER As String, ByVal DES_PROV As String, ByVal COD_REF As String, ByVal NRO_REF As String, ByVal TC As Decimal, ByVal COD_PER As String, ByVal COD_DOC As String, ByVal DESC_DOC As String, ByVal MON As String, ByVal S1 As Decimal, ByVal S2 As Decimal, ByVal S3 As Decimal, ByVal S4 As Decimal, ByVal S5 As Decimal, ByVal S6 As Decimal, ByVal S7 As Decimal, ByVal S8 As Decimal, ByVal FECHA_REF As DateTime, ByVal TOTAL_ME As Decimal, ByVal TOTAL_HON As Decimal, ByVal COD_TIP_DOC As String)
        Me.DT_CONFIG_PROV.CONFIG_PROV.Rows.Add(COD_COM, NRO_COM, UNION, FEC_DOC, FEC_VEN, NRO_DOC_PER, DES_PROV, COD_REF, NRO_REF, TC, COD_PER, COD_DOC, DESC_DOC, MON, S1, S2, S3, S4, S5, S6, S7, S8, "", FECHA_REF, TOTAL_ME, TOTAL_HON, COD_TIP_DOC)
    End Sub
    Sub UBICAR_REPORTE()
        '-------------------
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ReportViewer2.Visible = False
        ReportViewer3.Visible = False
        '-------------------
        Select Case HOJA
            Case "02" : ReportViewer1.Visible = True
            Case "01" : ReportViewer2.Visible = True
            Case "03" : ReportViewer3.Visible = True
        End Select
        '-------------------
    End Sub
End Class