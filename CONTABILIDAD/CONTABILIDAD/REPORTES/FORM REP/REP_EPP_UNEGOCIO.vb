Imports Microsoft.Reporting.WinForms
Public Class REP_EPP_UNEGOCIO
    Public TIPOK As String
    Private Sub REP_ESTADISTICA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim frm As New Form
        'Dim dgv As New DataGridView
        'dgv.DataSource = Me.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO
        'dgv.Dock = DockStyle.Fill
        'frm.Controls.Add(dgv)
        'frm.ShowDialog()

        Select Case TIPOK
            Case "01"
                ReportViewer4.RefreshReport()
                ReportViewer4.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer4.ZoomMode = ZoomMode.PageWidth
                'Case "02"
                '    ReportViewer2.RefreshReport()
                '    ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
                '    ReportViewer2.ZoomMode = ZoomMode.PageWidth
            Case "03"
                ReportViewer3.RefreshReport()
                ReportViewer3.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer3.ZoomMode = ZoomMode.PageWidth
                'Case "04"
                '    ReportViewer3.RefreshReport()
                '    ReportViewer3.SetDisplayMode(DisplayMode.PrintLayout)
                '    ReportViewer3.ZoomMode = ZoomMode.PageWidth
        End Select
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()

        ReportViewer2.RefreshReport()
        Me.ReportViewer2.RefreshReport()

        ReportViewer3.RefreshReport()
        Me.ReportViewer3.RefreshReport()

        ReportViewer4.RefreshReport()
        Me.ReportViewer4.RefreshReport()


    End Sub
    Sub CREAR_REPORTE(ByVal DES_MES As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("AÑO", AÑO))
        Dim VAL As String = ""
        For Each ROW As DataRow In Me.dtEstadisticaPerdidasGanancia.NEGOCIO.Rows
            Select Case CStr(ROW("CODIGO"))
                Case "01" : parametros.Add(New ReportParameter("NEG01", CStr(ROW("DESCRIPCION"))))
                Case "02" : parametros.Add(New ReportParameter("NEG02", CStr(ROW("DESCRIPCION"))))
                Case "03" : parametros.Add(New ReportParameter("NEG03", CStr(ROW("DESCRIPCION"))))
                Case "04" : parametros.Add(New ReportParameter("NEG04", CStr(ROW("DESCRIPCION"))))
                Case "05" : parametros.Add(New ReportParameter("NEG05", CStr(ROW("DESCRIPCION"))))
                Case "06" : parametros.Add(New ReportParameter("NEG06", CStr(ROW("DESCRIPCION"))))
                Case "07" : parametros.Add(New ReportParameter("NEG07", CStr(ROW("DESCRIPCION"))))
                Case "08" : parametros.Add(New ReportParameter("NEG08", CStr(ROW("DESCRIPCION"))))
                Case "09" : parametros.Add(New ReportParameter("NEG09", CStr(ROW("DESCRIPCION"))))
                Case "10" : parametros.Add(New ReportParameter("NEG10", CStr(ROW("DESCRIPCION"))))
                Case "11" : parametros.Add(New ReportParameter("NEG11", CStr(ROW("DESCRIPCION"))))
                Case "12" : parametros.Add(New ReportParameter("NEG12", CStr(ROW("DESCRIPCION"))))
            End Select
        Next
        'Me.ReportViewer1.LocalReport.SetParameters(parametros)
        Me.ReportViewer1.Clear()
        Select Case TIPOK
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
            Case "02"
                Me.ReportViewer2.LocalReport.SetParameters(parametros)
            Case "03"
                Me.ReportViewer3.LocalReport.SetParameters(parametros)
            Case "04"
                Me.ReportViewer4.LocalReport.SetParameters(parametros)
        End Select
    End Sub
    Sub UBICAR_REPORTE()
        '-------------------
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ReportViewer2.Visible = False
        ReportViewer3.Visible = False
        ReportViewer4.Visible = False
        '-------------------
        Select Case TIPOK
            Case "01" : ReportViewer1.Visible = True
            Case "02" : ReportViewer2.Visible = True
            Case "03" : ReportViewer3.Visible = True
            Case "04" : ReportViewer4.Visible = True
        End Select
        '-------------------
    End Sub
End Class