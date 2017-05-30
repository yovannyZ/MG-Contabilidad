Imports Microsoft.Reporting.WinForms
Public Class REP_LIBRO

    Private Sub REP_LIBRO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_LIBRO.I_BANCO' Puede moverla o quitarla según sea necesario.
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
        Me.ReportViewer1.Refresh()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal AÑO00 As String, ByVal MES00 As String, ByVal COD_MES As String, _
        ByVal COD_BANCO As String, ByVal SALDO As Decimal, ByVal DESC_BANCO As String, _
        ByVal NRO_CUENTA As String, ByVal COD_CUENTA As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("AÑO", AÑO00))
        parametros.Add(New ReportParameter("MES", MES00))
        parametros.Add(New ReportParameter("SALDO", (SALDO)))
        parametros.Add(New ReportParameter("COD_USU", COD_USU))
        parametros.Add(New ReportParameter("COD_BANCO", COD_BANCO))
        parametros.Add(New ReportParameter("DESC_BANCO", DESC_BANCO))
        parametros.Add(New ReportParameter("NRO_CUENTA", NRO_CUENTA))
        parametros.Add(New ReportParameter("COD_CUENTA", COD_CUENTA))
        Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.I_BANCOTableAdapter.Connection = con
        Me.I_BANCOTableAdapter.Fill(Me.DT_LIBRO.I_BANCO, COD_BANCO, COD_MES, AÑO00)
        Dim SALDO0 As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.DT_LIBRO.I_BANCO.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim DEBE0 As New Decimal
            Dim HABER0 As New Decimal
            DEBE0 = Decimal.Parse(Me.DT_LIBRO.I_BANCO.Rows.Item(I).Item(5))
            HABER0 = Decimal.Parse(Me.DT_LIBRO.I_BANCO.Rows.Item(I).Item(6))
            SALDO0 = Decimal.Subtract(Decimal.Add(SALDO0, DEBE0), HABER0)
            Me.DT_LIBRO.I_BANCO.Rows.Item(I).Item(15) = SALDO0
            I += 1
        Loop
    End Sub

End Class