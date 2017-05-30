Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_CTA_GRAL
    Dim OBJ As New Class1
    Dim OFR As New REP_CTA_GRAL
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        If CBO_MES2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES2.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If CBO_ORDEN.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
        Dim COD_CTA As String = txt_cod_cta0.Text
        Dim MES1 As String = CBO_MES.Text
        Dim MES_INI As Integer = (MES1 - 1).ToString("00")
        Dim MES2 As String = CBO_MES2.Text
        Dim ORDEN As String = CBO_ORDEN.Text
        OFR.CREAR_REPORTE(COD_CTA, txt_desc_cta0.Text, MES1, MES2, ORDEN, MES_INI)
        OFR.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(69) = 0
        Close()
    End Sub
    Sub CUENTAS()
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value).Length <> 8) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta0.Clear()
                txt_desc_cta0.Clear()
            Else
                txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                PaneL_CTA.Visible = False
                KL.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        KeyPreview = True
        CBO_AUX00()
        CUENTAS()
        cbo_aux.Focus()
    End Sub
    Sub CBO_AUX00()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        If (dgw_cta.Item(0, i).Value.ToString.Length <> 8) Then
                            MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_cta0.Clear()
                            txt_desc_cta0.Clear()
                            txt_cod_cta0.Focus()
                        Else
                            txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                            txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                            CBO_ORDEN.Focus()
                        End If
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
            End If
        End If
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        If CBO_MES2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES2.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub

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

    Private Sub ExportarWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True
        Dim COD_CTA As String = txt_cod_cta0.Text
        Dim MES1 As String = CBO_MES.Text
        Dim MES_INI As Integer = (MES1 - 1).ToString("00")
        Dim MES2 As String = CBO_MES2.Text
        Dim ORDEN As String = CBO_ORDEN.Text
        '-----------------------------------
        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet

        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"

            oHoja.Range("A1:H1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:H2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA
            oHoja.Range("A3:H3").Merge()
            oHoja.Range("A3:H3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("CUENTA: {0} {1}", txt_cod_cta0.Text, txt_desc_cta0.Text)

            Dim strRango As String = "A5:P6"
            oHoja.Cells(5, 1) = "MES" : oHoja.Cells(5, 2) = "COMPROBANTE" : oHoja.Cells(6, 2) = "COD"
            oHoja.Cells(6, 3) = "AUX" : oHoja.Cells(6, 4) = "NRO" : oHoja.Cells(5, 5) = "DOCUMENTO"
            oHoja.Cells(6, 5) = "FECHA" : oHoja.Cells(6, 6) = "NUMERO" : oHoja.Cells(6, 7) = "COD"
            oHoja.Cells(5, 8) = "CTA.CTE." : oHoja.Cells(5, 9) = "COD C.C." : oHoja.Cells(5, 10) = "GLOSA"
            oHoja.Cells(5, 11) = "REFERENCIA" : oHoja.Cells(6, 11) = "NRO" : oHoja.Cells(6, 12) = "COD"
            oHoja.Cells(5, 13) = "MON." : oHoja.Cells(5, 14) = "$/ IMPORTE" : oHoja.Cells(5, 15) = "S/ IMPORTE"
            oHoja.Cells(6, 15) = "DEBE" : oHoja.Cells(6, 16) = "HABER"

            oHoja.Range("B5:D5").Merge() : oHoja.Range("E5:G5").Merge()
            oHoja.Range("K5:L5").Merge() : oHoja.Range("O5:P5").Merge()

            oHoja.Range("A:D").NumberFormat = "@"
            oHoja.Range("E:E").NumberFormat = "dd/mm/yyyy"
            oHoja.Range("F:M").NumberFormat = "@"
            oHoja.Range("N:N").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* "" ""??_);_(@_)"
            oHoja.Range("O:P").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* "" ""??_);_(@_)"
            'oHoja.Range("F:F").NumberFormat = "dd/mm/yyyy"
            'oHoja.Range("G:J").NumberFormat = "@"
            'oHoja.Range("K:N").NumberFormat = "_(s/.* #,##0.00_);_(s/.* (#,##0.00);_(s/.* ""-""??_);_(@_)"
            'oHoja.Range("O:O").NumberFormat = "@"
            'oHoja.Range("P:P").NumberFormat = "_(s/.* #,##0.0000_);_(s/.* (#,##0.0000);_(s/.* ""-""??_);_(@_)"

            archivoExcel = String.Format("Cuenta_General_{0}", txt_cod_cta0.Text)

            Dim Fila As Integer = 7

            Dim cmd As New SqlCommand("REPORTE_CTA_GRAL", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@MES1", SqlDbType.Char)
            Dim par3 As SqlParameter = cmd.Parameters.Add("@MES2", SqlDbType.VarChar)
            Dim par4 As SqlParameter = cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char)
            Dim par5 As SqlParameter = cmd.Parameters.Add("@MES_INI", SqlDbType.Char)

            par1.Value = AÑO : par2.Value = MES1 : par3.Value = MES2
            par4.Value = txt_cod_cta0.Text : par5.Value = MES_INI


            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dtrOrden As DataRow

            Dim tReg As Integer = dt.Rows.Count
            Dim fAct As Integer = 0
            For Each dtrOrden In dt.Rows
                oHoja.Cells(Fila, 1) = dtrOrden(1)
                oHoja.Cells(Fila, 2) = dtrOrden(2)
                oHoja.Cells(Fila, 3) = dtrOrden(3)
                oHoja.Cells(Fila, 4) = dtrOrden(4)
                oHoja.Cells(Fila, 5) = dtrOrden(9)
                oHoja.Cells(Fila, 6) = dtrOrden(8)
                oHoja.Cells(Fila, 7) = dtrOrden(7)
                oHoja.Cells(Fila, 8) = dtrOrden(10)
                oHoja.Cells(Fila, 9) = dtrOrden(12)
                oHoja.Cells(Fila, 10) = dtrOrden(13)
                oHoja.Cells(Fila, 11) = dtrOrden(14)
                oHoja.Cells(Fila, 12) = dtrOrden(15)
                oHoja.Cells(Fila, 13) = dtrOrden(17)
                oHoja.Cells(Fila, 14) = dtrOrden(18)
                oHoja.Cells(Fila, 15) = dtrOrden(23)
                oHoja.Cells(Fila, 16) = dtrOrden(24)

                Fila += 1
                fAct += 1
                bwExportar.ReportProgress((fAct / tReg) * 100)
            Next
            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            oHoja.Range(String.Format("A7:P{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:P{0}", Fila - 1)).Interior.ColorIndex = 2

            'ActiveWindow.SplitRow = 6
            'ActiveWindow.FreezePanes = True

            oHoja.Columns.AutoFit()
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

    Private Sub ExportarProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        tspbExportar.Value = e.ProgressPercentage
        tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub

    Private Sub ExportarComplete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls ", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btn_imprimir1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir1.Click

    End Sub
End Class