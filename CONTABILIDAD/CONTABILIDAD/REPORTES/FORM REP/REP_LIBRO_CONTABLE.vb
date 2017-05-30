Imports Microsoft.Reporting.WinForms
Public Class REP_LIBRO_CONTABLE
    Private Sub REP_LIBRO_CONTABLE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String, ByVal COD_MES As String, ByVal COD_BANCO As String, ByVal SALDO As Decimal, ByVal DESC_BANCO As String, ByVal TC_ANTERIOR As Decimal, ByVal TC_ACTUAL As Decimal)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO00))
        parametros.Add(New ReportParameter("MES", MES00))
        parametros.Add(New ReportParameter("SALDO", (SALDO)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("COD_BANCO", COD_BANCO))
        parametros.Add(New ReportParameter("DESC_BANCO", DESC_BANCO))
        parametros.Add(New ReportParameter("TC_ANTERIOR", TC_ANTERIOR))
        parametros.Add(New ReportParameter("TC_ACTUAL", TC_ACTUAL))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.I_BANCO1TableAdapter.Connection = con
        Me.I_BANCO1TableAdapter.Fill(Me.DT_LIBRO.I_BANCO1, COD_BANCO, COD_MES, AÑO00)
        Dim SALDO0 As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.DT_LIBRO.I_BANCO1.Rows.Count - 1)
        I = 0
        '     -------------------------------------------
        Dim ultimo_saldo As Decimal
        '-------------------------------------------
        Do While (I <= CONT)
            Dim DEBE0 As New Decimal
            Dim HABER0 As New Decimal
            DEBE0 = Decimal.Parse(Me.DT_LIBRO.I_BANCO1.Rows.Item(I).Item(5))
            HABER0 = Decimal.Parse(Me.DT_LIBRO.I_BANCO1.Rows.Item(I).Item(6))
            SALDO0 = Decimal.Subtract(Decimal.Add(SALDO0, DEBE0), HABER0)
            Me.DT_LIBRO.I_BANCO1.Rows.Item(I).Item(15) = SALDO0
            '---------------
            If I = CONT Then
                ultimo_saldo = SALDO0
                Me.DT_LIBRO.I_BANCO1.Rows.Item(I).Item(17) = ultimo_saldo
            End If
            '-------------
            I += 1

          
        Loop
    End Sub
End Class