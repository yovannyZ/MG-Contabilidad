Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_CPTO_CONS
    Dim cod_moneda As String
    Dim obj As New Class1
    Dim REP As New REP_CPTO_CONS

    Private MONEDA, DESCMONEDA, CodCpto, DescCpto As String
    Private Fecha1, Fecha2 As Date
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If Trim(txt_cod_cta.Text) = "" Then MessageBox.Show("Debe elegir un Concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta.Focus() : Exit Sub
        If cbo_tipo.SelectedIndex = -1 Then MessageBox.Show("Debe elegir una Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
        If (DateTime.Compare(dtp_del.Value.Date, dtp_al.Value.Date) > 0) Then
            MessageBox.Show("El Rango es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.dtp_del.Focus()
        End If
        cod_moneda = obj.COD_MONEDA(cbo_tipo.Text)
        REP.CREAR_REPORTE(dtp_del.Value.Date, dtp_al.Value.Date, "0", txt_cod_cta.Text.ToString, cbo_tipo.Text, cod_moneda)
        REP.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(11) = 0
        Close()
    End Sub
    Sub cargar_monedas()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_tipo.DataSource = DT
        cbo_tipo.DisplayMember = DT.Columns.Item(0).ToString
        cbo_tipo.ValueMember = DT.Columns.Item(1).ToString
        cbo_tipo.SelectedIndex = -1
    End Sub
    Sub CONCEPTOS()
        Try
            Dim pro As New SqlCommand("DGW_CONCEPTOS_NIVEL5", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_cta.DataSource = dt
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(0).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value.ToString
            panel_cta.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cta.Visible = False
            txt_cod_cta.Clear()
            txt_desc_cta.Clear()
            txt_cod_cta.Focus()
        End If
    End Sub
    Private Sub REPORTE_CPTO_CONS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub REPORTE_MOV_CTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CONCEPTOS()
        cargar_monedas()
        txt_cod_cta.Focus()
    End Sub
    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        cbo_tipo.Focus()
                        Return
                    End If
                    If (txt_cod_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_cta.Visible = True
                'dgw_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
       
    End Sub

    Private Sub cbo_tipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_tipo.KeyDown
        If (e.KeyData = Keys.Down) Then
            'txt_cod_cta.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            dtp_del.Focus()
        End If
    End Sub

    Private Sub txt_desc_cta_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                'panel_cta.Visible = True
                'panel_cta.Focus()
                '-----------
                panel_cta.Visible = True
                'dgw_cta.Visible = True
                'dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desc_cta.TextChanged

    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If Trim(txt_cod_cta.Text) = "" Then MessageBox.Show("Debe elegir un Concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta.Focus() : Exit Sub
        If cbo_tipo.SelectedIndex = -1 Then MessageBox.Show("Debe elegir una Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
        If (DateTime.Compare(dtp_del.Value.Date, dtp_al.Value.Date) > 0) Then MessageBox.Show("El Rango es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Me.dtp_del.Focus() : Exit Sub

        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                MONEDA = (obj.COD_MONEDA(cbo_tipo.Text))
                DESCMONEDA = cbo_tipo.Text
                CodCpto = txt_cod_cta.Text
                DescCpto = txt_desc_cta.Text
                Fecha1 = dtp_del.Value
                Fecha2 = dtp_al.Value
                bwExportar.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub ExportarWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet
        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"

            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA
            

            oHoja.Range("C2:I2").Merge()
            oHoja.Range("C2:I2").Font.Bold = True
            oHoja.Cells(2, 3) = "MOVIMIENTO POR CONCEPTO - CONSOLIDADO"

            oHoja.Range("A3:C3").Merge()
            oHoja.Range("A3:C3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("Moneda: {0}", DESCMONEDA)

            oHoja.Range("A4:C4").Merge()
            oHoja.Range("A4:C4").Font.Bold = True
            oHoja.Cells(4, 1) = String.Format("Fecha del: {0} Al: {1}", Fecha1.ToShortDateString, Fecha2.ToShortDateString)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A6:M7"

            oHoja.Range("A6:B6").Merge()
            oHoja.Cells(6, 1) = "Concepto"
            oHoja.Cells(7, 1) = "Cod." : oHoja.Cells(7, 2) = "Descripción"

            oHoja.Range("C6:E6").Merge()
            oHoja.Cells(6, 3) = "Documento"
            oHoja.Cells(7, 3) = "Cod."
            oHoja.Cells(7, 4) = "Numero"
            oHoja.Cells(7, 5) = "Fecha"

            oHoja.Range("F6:G6").Merge()
            oHoja.Cells(6, 6) = "Medio Pago"
            oHoja.Cells(7, 6) = "Cod."
            oHoja.Cells(7, 7) = "Numero"

            oHoja.Cells(6, 7) = "M"
            oHoja.Cells(6, 8) = "T.O."
            oHoja.Cells(6, 9) = "Glosa"
            oHoja.Cells(6, 10) = "Importe"

            oHoja.Range("K6:M6").Merge()
            oHoja.Cells(6, 11) = "Comprobante"
            oHoja.Cells(7, 11) = "Aux." : oHoja.Cells(7, 12) = "Cod."
            oHoja.Cells(7, 13) = "Numero"

            oHoja.Range("A:D,F:I,K:M").NumberFormat = "@"
            oHoja.Range("E:E").NumberFormat = "DD/MM/YYYY"
            oHoja.Range("J:J").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 8
            archivoExcel = "ConsolidadoCpto"
            'checkforillegalcrossthreadcalls
            Dim Cmd As New SqlCommand("BANCO_CONSOLIDADO_CPTO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_CPTO", SqlDbType.Char).Value = CodCpto
            Cmd.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = MONEDA
            Cmd.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = Fecha1.Date
            Cmd.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = Fecha2.Date

            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader

            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(10)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(18)
                oHoja.Cells(Fila, 3) = Rs3.GetValue(7)
                oHoja.Cells(Fila, 4) = Rs3.GetValue(8)
                oHoja.Cells(Fila, 5) = Rs3.GetValue(9)
                oHoja.Cells(Fila, 6) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 7) = Rs3.GetValue(1)
                oHoja.Cells(Fila, 8) = ""
                oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                oHoja.Cells(Fila, 11) = Rs3.GetValue(4)
                oHoja.Cells(Fila, 12) = Rs3.GetValue(5)
                oHoja.Cells(Fila, 13) = Rs3.GetValue(21)
                Fila += 1
            Loop
            Rs3.Close()

            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A8:M{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A8:M{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
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

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete
    End Sub
End Class