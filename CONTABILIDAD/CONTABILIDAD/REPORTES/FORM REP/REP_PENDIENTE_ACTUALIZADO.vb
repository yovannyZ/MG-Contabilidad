Imports Microsoft.Reporting.WinForms
Public Class REP_PENDIENTE_ACTUALIZADO
    Public HOJA As String
    Private Sub REP_PENDIENTE_ACTUALIZADO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DT_REP_ANA_CXP.REPORTE_CONCILIADAS_ACTUALIZADO' Puede moverla o quitarla según sea necesario.
        ' Me.REPORTE_CONCILIADAS_ACTUALIZADOTableAdapter.Fill(Me.DT_REP_ANA_CXP.REPORTE_CONCILIADAS_ACTUALIZADO)
        Select Case HOJA
            Case "01"
                ReportViewer1.RefreshReport()
                ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
                ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Case "02"
                'ReportViewer2.RefreshReport()
                'ReportViewer2.SetDisplayMode(DisplayMode.PrintLayout)
                'ReportViewer2.ZoomMode = ZoomMode.PageWidth
        End Select
        ReportViewer1.RefreshReport()
        ReportViewer1.Refresh()
        'ReportViewer2.RefreshReport()
        'Me.ReportViewer2.RefreshReport()
        'Me.ReportViewer2.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Sub CREAR_REPORTE(ByVal DES_MES As String, ByVal DES_CTA As String, ByVal COD_CTA As String, ByVal AÑO0 As String, ByVal COD_MES As String, ByVal S_CONCILIADO As String, ByVal COD_PER As String, ByVal S_PER As String, ByVal SALDOS As Decimal, ByVal FECHA_CONC As DateTime, ByVal VISIBLE As String)
        Dim parametros As New List(Of ReportParameter)
        parametros.Add(New ReportParameter("RUC", RUC_EMPRESA))
        parametros.Add(New ReportParameter("EMPRESA", DESC_EMPRESA))
        parametros.Add(New ReportParameter("DES_MES", DES_MES))
        parametros.Add(New ReportParameter("DES_CUENTA", DES_CTA))
        parametros.Add(New ReportParameter("COD_CUENTA", COD_CTA))
        parametros.Add(New ReportParameter("AÑO0", AÑO0))
        parametros.Add(New ReportParameter("MAESTRO", (SALDOS)))
        parametros.Add(New ReportParameter("VISIBLE", (VISIBLE)))
        Select Case HOJA
            Case "01"
                Me.ReportViewer1.LocalReport.SetParameters(parametros)
                'Me.REPORTE_CONCILIADAS_ACTUALIZADOTableAdapter.Connection = con
                'Me.REPORTE_CONCILIADAS_ACTUALIZADOTableAdapter.Fill(Me.DT_REP_ANA_CXP.REPORTE_CONCILIADAS_ACTUALIZADO, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, COD_PER, S_PER, FECHA_CONC)
            Case "02"
                'Me.ReportViewer2.LocalReport.SetParameters(parametros)
                'Me.REPORTE_CONCILIADASTableAdapter.Connection = con
                'Me.REPORTE_CONCILIADASTableAdapter.Fill(Me.DT_REP_ANA_CXP.REPORTE_CONCILIADAS, AÑO0, COD_MES, COD_CTA, S_CONCILIADO, COD_PER, S_PER, FECHA_CONC)
        End Select
    End Sub
    Sub UBICAR_REPORTE()
        '-------------------
        'INVISIBLE TODOS
        ReportViewer1.Visible = False
        ''ReportViewer2.Visible = False
        '-------------------
        Select Case HOJA
            Case "01" : ReportViewer1.Visible = True
                'Case "02" : ReportViewer2.Visible = True
        End Select
        '-------------------
    End Sub
    Public Sub LimpiarDt()
        DT_REP_ANA_CXP.REPORTE_ACTUALIZADO.Clear()
    End Sub
    Public Sub LlenarDt(ByVal COD_MONEDA As String, ByVal DESC_MONEDA As String, ByVal FECHA_COMP As DateTime, ByVal COD_AUX As String, ByVal COD_COMP As String, _
                        ByVal NRO_COMP As String, ByVal FECHA_DOC As DateTime, ByVal NRO_DOC As String, ByVal COD_DOC As String, ByVal COD_PER As String, _
                        ByVal DESC_PER As String, ByVal COD_D_H As String, ByVal IMP_S As Decimal, ByVal IMP_D As Decimal, ByVal GLOSA As String, _
                        ByVal COD_CUENTA As String, ByVal TIPO_CAMBIO As Decimal, ByVal STATUS_CONCILIADO As String, ByVal FECHA_VEN As DateTime, ByVal NRO_DOC_PER As String)
        DT_REP_ANA_CXP.REPORTE_ACTUALIZADO.Rows.Add(COD_MONEDA, DESC_MONEDA, FECHA_COMP, COD_AUX, COD_COMP, _
                                                    NRO_COMP, FECHA_DOC, NRO_DOC, COD_DOC, COD_PER, _
                                                    DESC_PER, COD_D_H, IMP_S, IMP_D, GLOSA, _
                                                    COD_CUENTA, TIPO_CAMBIO, STATUS_CONCILIADO, FECHA_VEN, NRO_DOC_PER)
    End Sub
End Class