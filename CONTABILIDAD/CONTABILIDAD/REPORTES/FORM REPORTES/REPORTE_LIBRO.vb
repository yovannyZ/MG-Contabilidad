Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_LIBRO
    Private OBJ As New Class1

    Private DEBE, HABER, SALDO As Decimal
    Private REP As New REP_LIBRO

    Private AÑO0, MES0, DESC_MES0, CodBanco, DescBanco As String
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
    Dim COD_CUENTA As String

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (Strings.Trim(txt_cod_ban.Text) = "") Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf (cboMes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboMes.Focus()
        ElseIf (cbo_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        Else
            Dim DESC_MES00 As String = ""
            Dim VAR1 As String = OBJ.COD_MES(Me.cboMes.Text)
            If (VAR1 = "01") Then
                DESC_MES00 = "ENERO"
            ElseIf (VAR1 = "02") Then
                DESC_MES00 = "FEBRERO"
            ElseIf (VAR1 = "03") Then
                DESC_MES00 = "MARZO"
            ElseIf (VAR1 = "04") Then
                DESC_MES00 = "ABRIL"
            ElseIf (VAR1 = "05") Then
                DESC_MES00 = "MAYO"
            ElseIf (VAR1 = "06") Then
                DESC_MES00 = "JUNIO"
            ElseIf (VAR1 = "07") Then
                DESC_MES00 = "JULIO"
            ElseIf (VAR1 = "08") Then
                DESC_MES00 = "AGOSTO"
            ElseIf (VAR1 = "09") Then
                DESC_MES00 = "SETIEMBRE"
            ElseIf (VAR1 = "10") Then
                DESC_MES00 = "OCTUBRE"
            ElseIf (VAR1 = "11") Then
                DESC_MES00 = "NOVIEMBRE"
            ElseIf (VAR1 = "12") Then
                DESC_MES00 = "DICIEMBRE"
            Else
                DESC_MES00 = "INICIO"
            End If
            SALDOS()
            REP.CREAR_REPORTE(cbo_año.Text, DESC_MES00, OBJ.COD_MES(cboMes.Text), txt_cod_ban.Text, SALDO, txt_desc_ban.Text, txtNroCuenta.Text, COD_CUENTA)
            REP.ShowDialog()
        End If
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(30) = 0
        Me.Close()
    End Sub

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

    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H37
            dgw_ban.Columns.Item(3).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            txtNroCuenta.Text = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            COD_CUENTA = dgw_ban.Item(3, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            kl1.Focus()
        End If
    End Sub

    Private Sub REPORTE_CONC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_CONC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑOS()
        cbo_año.Text = AÑO
        cboMes.Text = OBJ.DESC_MES(MES)
        CARGAR_BANCOS()
    End Sub

    Sub SALDOS()
        Dim mes0 As Integer = CInt(Math.Round(CDbl((Decimal.Parse(OBJ.COD_MES(cboMes.Text)) - 1))))
        Dim mes00 As String = ""
        Dim año00 As String = ""
        If (mes0 = 0) Then
            mes00 = "12"
            año00 = (CDbl((Decimal.Parse(cbo_año.Text) - 1)))
        Else
            mes00 = mes0.ToString("00")
            año00 = cbo_año.Text
        End If
        DEBE = New Decimal
        HABER = New Decimal
        Try
            Dim Prog002 As New SqlCommand("HALLAR_SALDOS_BANCOS_CONTABLES", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            Prog002.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año00.ToString
            Prog002.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes00
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DEBE = Decimal.Parse(Rs3.GetValue(0))
                HABER = Decimal.Parse(Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        SALDO = Decimal.Subtract(DEBE, HABER)
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
                        txtNroCuenta.Text = dgw_ban.Item(2, i).Value.ToString
                        COD_CUENTA = dgw_ban.Item(3, i).Value.ToString
                        cboMes.Select()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
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
        If (Strings.Trim(txt_cod_ban.Text) = "") Then MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        'txt_cod_ban.Focus()
        If (cboMes.SelectedIndex = -1) Then MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes.Focus() : Exit Sub
        If (cbo_año.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub

        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                MES0 = (OBJ.COD_MES(cboMes.Text))
                AÑO0 = cbo_año.Text
                DESC_MES0 = cboMes.Text
                CodBanco = txt_cod_ban.Text
                DescBanco = txt_desc_ban.Text
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
            oHoja.Range("A3:C3").Merge()
            oHoja.Range("A3:C3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("BANCO: {0}", DescBanco)

            oHoja.Range("C2:I2").Merge()
            oHoja.Range("C2:I2").Font.Bold = True
            oHoja.Cells(2, 3) = "LIBRO BANCOS"


            oHoja.Range("D3:H3").Merge()
            oHoja.Range("D3:H3").Font.Bold = True
            oHoja.Cells(3, 4) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO0)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:K6"

            oHoja.Range("A5:C5").Merge()
            oHoja.Cells(5, 1) = "Medio de Pago"
            oHoja.Cells(6, 1) = "Codigo" : oHoja.Cells(6, 2) = "Numero"
            oHoja.Cells(6, 3) = "Fecha"
            oHoja.Cells(6, 4) = "Descripción /Operación"
            oHoja.Cells(6, 5) = "Ingreso" : oHoja.Cells(6, 6) = "Egreso"
            oHoja.Cells(6, 7) = "Saldo"
            oHoja.Range("H5:J5").Merge()
            oHoja.Cells(5, 8) = "Comprobante"
            oHoja.Cells(6, 8) = "Aux." : oHoja.Cells(6, 9) = "Cod."
            oHoja.Cells(6, 10) = "Numero"

            oHoja.Cells(5, 11) = "Saldo"
            oHoja.Cells(6, 11) = "Anterior"

            oHoja.Range("A:B,D:D,H:J").NumberFormat = "@"
            oHoja.Range("C:C").NumberFormat = "DD/MM/YYYY"
            oHoja.Range("E:G").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 7
            archivoExcel = "LibroBancos"
            'checkforillegalcrossthreadcalls
            Dim Cmd As New SqlCommand("LIBRO_BANCOS1", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = CodBanco
            Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0

            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader

            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                oHoja.Cells(Fila, 5) = IIf(Rs3.GetValue(5) = "H", "", Rs3.GetValue(4))
                oHoja.Cells(Fila, 6) = IIf(Rs3.GetValue(5) = "D", "", Rs3.GetValue(4))
                oHoja.Cells(Fila, 7) = Rs3.GetValue(11)
                oHoja.Cells(Fila, 8) = Rs3.GetValue(6)
                oHoja.Cells(Fila, 9) = Rs3.GetValue(7)
                oHoja.Cells(Fila, 10) = Rs3.GetValue(8)
                oHoja.Cells(Fila, 11) = Rs3.GetValue(13)
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
            oHoja.Range(String.Format("A7:K{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:K{0}", Fila - 1)).Interior.ColorIndex = 2

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