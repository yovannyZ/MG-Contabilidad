Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_MOV_CTA
    Private REP As New REP_MOV_CTA
    Private TIPO As String
    Private Fecha1, Fecha2 As Date
    Private status_ban, Cod_Ban, DescBanco As String
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If ((Strings.Trim(txt_cod_ban.Text) = "") And ch_bco.Checked) Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        Else
            If (DateTime.Compare(dtp_del.Value, dtp_al.Value) > 0) Then
                MessageBox.Show("El Rango es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtp_del.Focus()
            End If
            If ch_bco.Checked Then
                status_ban = "0"
                cod_ban = txt_cod_ban.Text
            Else
                status_ban = "1"
                cod_ban = ""
            End If
            '-----------------------------------------------
            If dtp_del.Value = dtp_al.Value Then
                TIPO = "IGUAL"
            Else
                TIPO = "DIFERENTE"
            End If
            '-----------------------------------------------
            REP.CREAR_REPORTE(dtp_del.Value.ToShortDateString, dtp_al.Value.ToShortDateString, status_ban, Cod_Ban, TIPO)
            REP.ShowDialog()
        End If
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(15) = 0
        Me.Close()
    End Sub
    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ch_bco_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_bco.CheckedChanged
        If ch_bco.Checked Then
            txt_cod_ban.Enabled = True
            txt_desc_ban.Enabled = True
        Else
            txt_cod_ban.Enabled = False
            txt_desc_ban.Enabled = False
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            KL1.Focus()
        End If
    End Sub
    Private Sub REPORTE_MOV_CTA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub REPORTE_MOV_CTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_BANCOS()
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        dtp_del.Select()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(Me.txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    Me.dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(Me.txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If ((Strings.Trim(txt_cod_ban.Text) = "") And ch_bco.Checked) Then MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        
        If (DateTime.Compare(dtp_del.Value, dtp_al.Value) > 0) Then
            MessageBox.Show("El Rango es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_del.Focus()
        End If
        If ch_bco.Checked Then
            status_ban = "0"
            cod_ban = txt_cod_ban.Text
        Else
            status_ban = "1"
            cod_ban = ""
        End If
        '-----------------------------------------------
        If dtp_del.Value = dtp_al.Value Then
            TIPO = "IGUAL"
        Else
            TIPO = "DIFERENTE"
        End If
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
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
            oHoja.Range("A3:E3").Merge()
            oHoja.Range("A3:E3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("Fecha del: {0} Al: {1}", Fecha1.ToShortDateString, Fecha2.ToShortDateString)

            oHoja.Range("C2:I2").Merge()
            oHoja.Range("C2:I2").Font.Bold = True
            oHoja.Cells(2, 3) = "MOVIMIENTO POR CUENTA"


            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:O6"

            oHoja.Range("A5:B5").Merge()
            oHoja.Cells(5, 1) = "Banco"
            oHoja.Cells(6, 1) = "Cod."
            oHoja.Cells(6, 2) = "Banco"

            oHoja.Range("C5:E5").Merge()
            oHoja.Cells(5, 3) = "Caja Bancos"
            oHoja.Cells(6, 3) = "Cod." : oHoja.Cells(6, 4) = "Numero"
            oHoja.Cells(6, 5) = "Fecha"

            oHoja.Cells(5, 6) = "Operación"

            oHoja.Range("G5:I5").Merge()
            oHoja.Cells(5, 7) = "Importe"
            oHoja.Cells(6, 7) = "Ingreso" : oHoja.Cells(6, 8) = "Egreso"
            oHoja.Cells(6, 9) = "M"

            oHoja.Range("J5:L5").Merge()
            oHoja.Cells(5, 10) = "Comprobante"
            oHoja.Cells(6, 10) = "Aux." : oHoja.Cells(6, 11) = "Cod."
            oHoja.Cells(6, 12) = "Numero"

            oHoja.Cells(5, 13) = "Fecha"
            oHoja.Cells(6, 13) = "Diferido"
            oHoja.Cells(5, 14) = "Cod."
            oHoja.Cells(6, 14) = "CPTO"


            oHoja.Cells(5, 15) = "Cuenta"

            oHoja.Range("A:D,F:F,I:L,N:O").NumberFormat = "@"
            oHoja.Range("E:E,M:M").NumberFormat = "DD/MM/YYYY"
            oHoja.Range("G:H").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 7
            archivoExcel = "BancosRango"
            'checkforillegalcrossthreadcalls
            Dim Cmd As New SqlCommand("REPORTE_bancos_rango", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@STATUS_BCO", SqlDbType.Char).Value = status_ban
            Cmd.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = Cod_Ban
            Cmd.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = Fecha1.Date
            Cmd.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = Fecha2.Date
            Cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO

            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader

            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(3)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(11)
                oHoja.Cells(Fila, 3) = Rs3.GetValue(1)
                oHoja.Cells(Fila, 4) = Rs3.GetValue(2)
                oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                oHoja.Cells(Fila, 7) = Rs3.GetValue(15)
                oHoja.Cells(Fila, 8) = Rs3.GetValue(16)
                oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                oHoja.Cells(Fila, 10) = Rs3.GetValue(8)
                oHoja.Cells(Fila, 11) = Rs3.GetValue(9)
                oHoja.Cells(Fila, 12) = Rs3.GetValue(10)
                oHoja.Cells(Fila, 13) = Rs3.GetValue(17)
                oHoja.Cells(Fila, 14) = Rs3.GetValue(18)
                oHoja.Cells(Fila, 15) = Rs3.GetValue(13)
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
            oHoja.Range(String.Format("A7:O{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:O{0}", Fila - 1)).Interior.ColorIndex = 2

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