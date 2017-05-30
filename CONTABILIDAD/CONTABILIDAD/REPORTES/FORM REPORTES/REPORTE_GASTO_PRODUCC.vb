Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_GASTO_PRODUCC
    Private bwExportar As New BackgroundWorker
    Private rutaExcel, archivoExcel As String
    Dim AÑO0, MES00 As String
    Private Exito As Boolean
    Private ofr As New REP_GASTOS

    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(112) = (0)
        Close()
    End Sub

    Private Sub GASTOS_PRODUCCION_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        CARGAR_AÑOS()
    End Sub

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click

        If cbo_mes.SelectedIndex = -1 Then
            MsgBox("Seleccione el mes", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If cbo_año.SelectedIndex = -1 Then
            MsgBox("Seleccione el año", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Try
        AÑO0 = cbo_año.Text
        MES00 = (cbo_mes.SelectedIndex + 1).ToString("00")
        '    CR.conectar(nombre_servidor, con.Database, "miguel", "main")
        '    CR.rutaRpt = Application.StartupPath & "\REPORTES"
        '    If Rb_Orden.Checked = True Then
        '        CR.custTitle = "Reporte de Gastos por Orden de Producción"
        '        CR.printrpt("GastoProduccion.rpt", "@FE_AÑO;" & AÑO0, "@FE_MES;" & MES00, _
        '        "EMPRESA;" & DESC_EMPRESA, "RUC;" & RUC_EMPRESA)
        '    ElseIf Rb_Costos.Checked = True Then
        '        CR.custTitle = "Reporte de Gastos por Centro de Costo"
        '        CR.printrpt("GastoProduccionCC.rpt", "@FE_AÑO;" & AÑO0, "@FE_MES;" & MES00, _
        '        "EMPRESA;" & DESC_EMPRESA, "RUC;" & RUC_EMPRESA)
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al cargar el informe" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
        'End Try

        If Rb_Orden.Checked = True Then
            ofr.Rep = "Orden"
            ofr.Text = "Reporte de Gastos por Orden de Producción"
        Else
            ofr.Rep = "CC"
            ofr.Text = "Reporte de Gastos por Centro de Costos"
        End If
        ofr.CrearReporte(DESC_EMPRESA, RUC_EMPRESA, AÑO0, MES00, cbo_mes.Text)
        ofr.ShowDialog()
    End Sub

    'Private Sub Exportar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
    Private Sub ExportarWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True
        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.WorkBooks.Add
        Dim oHoja As Object = oLibro.ActiveSheet
        Try
            oExcel.DisplayAlerts = False
            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA
            oHoja.Range("A3:C3").Merge()
            oHoja.Range("A3:C3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("DEL MES DE: {0} {1}", cbo_mes.Text, cbo_año.Text)

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"
            Dim strRango As String = ""
            Dim Fila As Integer = 6
            If Rb_Orden.Checked Then
                archivoExcel = "Gasto_OrdenProduccion"
                strRango = "D3:N3"
                oHoja.Range(strRango).Merge()
                oHoja.Range(strRango).NumberFormat = "@"
                oHoja.Range(strRango).Font.Bold = True
                oHoja.Range(strRango).VerticalAlignment = -4108
                oHoja.Range(strRango).HorizontalAlignment = -4108
                oHoja.Range(strRango) = "GASTO POR ORDEN DE PRODUCCION"

                strRango = "A5:R5"
                oHoja.Cells(5, 1) = "ORD./PROD." : oHoja.Cells(5, 2) = "FEC. INICIO" : oHoja.Cells(5, 3) = "ACTIVIDAD" : oHoja.Cells(5, 4) = "FEC. INICIO"
                oHoja.Cells(5, 5) = "COD" : oHoja.Cells(5, 6) = "NUMERO" : oHoja.Cells(5, 7) = "FECHA"
                oHoja.Cells(5, 8) = "IMPORTE" : oHoja.Cells(5, 9) = "MON." : oHoja.Cells(5, 10) = "IMP. CONT."
                oHoja.Cells(5, 11) = "T.C." : oHoja.Cells(5, 12) = "GLOSA" : oHoja.Cells(5, 13) = "CTA. CTE."
                oHoja.Cells(5, 14) = "NOMBRE/RAZON SOCIAL" : oHoja.Cells(5, 15) = "CUENTA" : oHoja.Cells(5, 16) = "AUX"
                oHoja.Cells(5, 17) = "COMP" : oHoja.Cells(5, 18) = "NRO."

                oHoja.Range("A:A").NumberFormat = "@"
                oHoja.Range("B:B").NumberFormat = "dd/mm/yyyy"
                oHoja.Range("C:C").NumberFormat = "@"
                oHoja.Range("D:D").NumberFormat = "dd/mm/yyyy"
                oHoja.Range("E:F").NumberFormat = "@"
                oHoja.Range("G:G").NumberFormat = "dd/mm/yyyy"
                oHoja.Range("H:H").NumberFormat = "_(s/.* #,##0.00_);_(s/.* (#,##0.00);_(s/.* ""-""??_);_(@_)"
                oHoja.Range("I:I").NumberFormat = "@"
                oHoja.Range("J:J").NumberFormat = "_(s/.* #,##0.00_);_(s/.* (#,##0.00);_(s/.* ""-""??_);_(@_)"
                oHoja.Range("K:K").NumberFormat = "_(s/.* #,##0.0000_);_(s/.* (#,##0.0000);_(s/.* ""-""??_);_(@_)"
                oHoja.Range("L:R").NumberFormat = "@"

                Dim cmd As New SqlCommand("REPORTE_GASTOPRODUCCION", con)
                cmd.CommandType = CommandType.StoredProcedure

                Dim pr1 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
                pr1.Value = AÑO0
                Dim pr2 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
                pr2.Value = MES00
                Dim dtOrden As New DataTable
                Dim daOrden As New SqlDataAdapter(cmd)
                daOrden.Fill(dtOrden)

                Dim dtrOrden As DataRow
                Dim dtcOrden As DataColumn
                Dim c As Integer
                Dim tReg As Integer = dtOrden.Rows.Count
                Dim fAct As Integer = 0

                For Each dtrOrden In dtOrden.Rows
                    c = 1
                    For Each dtcOrden In dtOrden.Columns
                        oHoja.Cells(Fila, c) = dtrOrden(dtcOrden)
                        c += 1
                    Next
                    Fila += 1
                    fAct += 1
                    bwExportar.ReportProgress((fAct / tReg) * 100)
                Next
            Else
                archivoExcel = "Gasto_CentroCosto"

                strRango = "D3:K3"
                oHoja.Range(strRango).Merge()
                oHoja.Range(strRango).NumberFormat = "@"
                oHoja.Range(strRango).Font.Bold = True
                oHoja.Range(strRango).VerticalAlignment = -4108
                oHoja.Range(strRango).HorizontalAlignment = -4108
                oHoja.Range(strRango) = "GASTO POR CENTRO DE COSTO"

                strRango = "A5:P5"
                oHoja.Cells(5, 1) = "CENTRO COSTO" : oHoja.Cells(5, 2) = "CC" : oHoja.Cells(5, 3) = "COD" : oHoja.Cells(5, 4) = "NUMERO"
                oHoja.Cells(5, 5) = "FECHA" : oHoja.Cells(5, 6) = "IMPORTE" : oHoja.Cells(5, 7) = "MON."
                oHoja.Cells(5, 8) = "IMP. CONT." : oHoja.Cells(5, 9) = "T.C." : oHoja.Cells(5, 10) = "GLOSA"
                oHoja.Cells(5, 11) = "CTA. CTE." : oHoja.Cells(5, 12) = "NOMBRE/RAZON SOCIAL" : oHoja.Cells(5, 13) = "CUENTA"
                oHoja.Cells(5, 14) = "AUX" : oHoja.Cells(5, 15) = "COMP" : oHoja.Cells(5, 16) = "NRO."

                oHoja.Range("A:D").NumberFormat = "@"
                oHoja.Range("E:E").NumberFormat = "dd/mm/yyyy"
                oHoja.Range("F:F").NumberFormat = "_(s/.* #,##0.00_);_(s/.* (#,##0.00);_(s/.* ""-""??_);_(@_)"
                oHoja.Range("G:G").NumberFormat = "@"
                oHoja.Range("H:H").NumberFormat = "_(s/.* #,##0.00_);_(s/.* (#,##0.00);_(s/.* ""-""??_);_(@_)"
                oHoja.Range("I:I").NumberFormat = "_(s/.* #,##0.0000_);_(s/.* (#,##0.0000);_(s/.* ""-""??_);_(@_)"
                oHoja.Range("J:P").NumberFormat = "@"
                Dim cmd As New SqlCommand("REPORTE_GASTOPRODUCCIONCC", con)
                cmd.CommandType = CommandType.StoredProcedure

                Dim pr1 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
                pr1.Value = AÑO0
                Dim pr2 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
                pr2.Value = MES00
                Dim dtOrden As New DataTable
                Dim daOrden As New SqlDataAdapter(cmd)
                daOrden.Fill(dtOrden)

                Dim dtrOrden As DataRow
                Dim dtcOrden As DataColumn
                Dim c As Integer
                Dim tReg As Integer = dtOrden.Rows.Count
                Dim fAct As Integer = 0

                For Each dtrOrden In dtOrden.Rows
                    c = 1
                    For Each dtcOrden In dtOrden.Columns
                        oHoja.Cells(Fila, c) = dtrOrden(dtcOrden)
                        c += 1
                    Next
                    Fila += 1
                    fAct += 1
                    bwExportar.ReportProgress((fAct / tReg) * 100)
                Next
            End If

            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format(IIf(Rb_Orden.Checked, "A6:R{0}", "A6:P{0}"), Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format(IIf(Rb_Orden.Checked, "A6:R{0}", "A6:P{0}"), Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.Autofit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try

    End Sub

    Private Sub ExportarProgress(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        tspbExportar.Value = e.ProgressPercentage
        tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub

    Private Sub ExportarComplete(ByVal Sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tspbExportar.Value = 0
        stEstado.Visible = False
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If cbo_mes.SelectedIndex = -1 Then
            MsgBox("Seleccione el mes", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If cbo_año.SelectedIndex = -1 Then
            MsgBox("Seleccione el año", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        AÑO0 = cbo_año.Text
        MES00 = (cbo_mes.SelectedIndex + 1).ToString("00")

        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                bwExportar.RunWorkerAsync()
            End If
        End If
    End Sub
End Class