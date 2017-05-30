Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_DIARIO_CAJA_BANCO
    Private OBJ As New Class1
    Private REP As New REP_DIARIO_CAJA_BANCO
    Dim HOJA As String

    Private cod_aux, status_aux As String
    Private MES0, DESC_MES0, TITULO As String

    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_aux.SelectedIndex = -1 And ch_aux.Checked Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If txt_rep.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Título del Reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_rep.Focus() : Exit Sub
        If cboMes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes.Focus() : Exit Sub
        If cbo_hoja.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Hoja a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub

        If ch_aux.Checked = False Then
            status_aux = "1"
            cod_aux = " "
        Else
            status_aux = "0"
            cod_aux = OBJ.COD_AUX(cbo_aux.Text)
        End If

        Select Case cbo_hoja.SelectedIndex
            Case "0"
                HOJA = "01"
            Case "1"
                HOJA = "02"
        End Select

        REP.HOJA = HOJA
        REP.UBICAR_REPORTE()
        REP.CREAR_REPORTE(dtp01.Value, OBJ.COD_MES(cboMes.Text), cboMes.Text, cod_aux, status_aux, txt_rep.Text, ch_aux.Checked)
        REP.ShowDialog()

    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(57) = 0
        Close()
    End Sub
    Sub cargar_aux()
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
    Private Sub ch_aux_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_aux.CheckedChanged
        If ch_aux.Checked Then
            cbo_aux.Enabled = True
        Else
            cbo_aux.SelectedIndex = -1
            cbo_aux.Enabled = False
        End If
    End Sub
    Private Sub REPORTE_DIARIO_DET_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub REPORTE_DIARIO_DET_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cargar_aux()
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If cbo_aux.SelectedIndex = -1 And ch_aux.Checked Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If txt_rep.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Título del Reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_rep.Focus() : Exit Sub
        If cboMes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes.Focus() : Exit Sub
        If cbo_hoja.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Hoja a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub

        If ch_aux.Checked = False Then
            status_aux = "1"
            cod_aux = " "
        Else
            status_aux = "0"
            cod_aux = OBJ.COD_AUX(cbo_aux.Text)
        End If
        TITULO = txt_rep.Text
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                'tslblMensaje.Text = "Generando Archivo"
                'stEstado.Visible = True
                MES0 = (OBJ.COD_MES(cboMes.Text))
                DESC_MES0 = cboMes.Text
                'NIVEL = OBJ.HALLAR_NRO_DIGITOS(OBJ.COD_NIVEL(cbo_nivel.Text))
                'CREAR_SELECT()
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
            oHoja.Range("A3:B3").Merge()
            oHoja.Range("A3:B3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO)

            oHoja.Range("C2:K2").Merge()
            oHoja.Range("C2:K2").Font.Bold = True
            oHoja.Cells(2, 3) = TITULO


            oHoja.Range("C3:L3").Merge()
            oHoja.Range("C3:L3").Font.Bold = True
            'oHoja.Cells(3, 3) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:M6"

            oHoja.Range("A5:B5").Merge()
            oHoja.Cells(5, 1) = "AUXILIAR"
            oHoja.Cells(6, 1) = "Codigo" : oHoja.Cells(6, 2) = "Desc."

            oHoja.Range("C5:E5").Merge()
            oHoja.Cells(5, 3) = "DOCUMENTO"
            oHoja.Cells(6, 3) = "Cod." : oHoja.Cells(6, 4) = "Numero"
            oHoja.Cells(6, 5) = "Numero"

            oHoja.Range("F5:G5").Merge()
            oHoja.Cells(5, 6) = "COMPROBANTE"
            oHoja.Cells(6, 6) = "Codigo" : oHoja.Cells(6, 7) = "Numero"

            oHoja.Cells(5, 8) = "CTA"

            oHoja.Cells(5, 9) = "GLOSA" : oHoja.Cells(5, 10) = "REF"
            oHoja.Cells(5, 11) = "IMP $"

            oHoja.Range("L5:M5").Merge()
            oHoja.Cells(5, 12) = "IMPORTE S/."
            oHoja.Cells(6, 12) = "Debe" : oHoja.Cells(6, 13) = "Haber"

            oHoja.Range("A:D,F:J").NumberFormat = "@"
            oHoja.Range("E:E").NumberFormat = "dd/mm/yyyy"
            oHoja.Range("K:M").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 7
            Dim stCon As Integer
            archivoExcel = "ReporteDiario"

            Dim Cmd As New SqlCommand("REPORTE_DIARIO_DET", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            Cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cod_aux
            Cmd.Parameters.Add("@STATUS_AUX", SqlDbType.Char).Value = status_aux
            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(5)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 3) = Rs3.GetValue(8)
                oHoja.Cells(Fila, 4) = Rs3.GetValue(9)
                oHoja.Cells(Fila, 5) = Rs3.GetValue(13)
                oHoja.Cells(Fila, 6) = Rs3.GetValue(6)
                oHoja.Cells(Fila, 7) = Rs3.GetValue(7)
                oHoja.Cells(Fila, 8) = Rs3.GetValue(19)
                oHoja.Cells(Fila, 9) = Rs3.GetValue(17)
                oHoja.Cells(Fila, 10) = Rs3.GetValue(15)
                oHoja.Cells(Fila, 11) = Rs3.GetValue(20)
                oHoja.Cells(Fila, 12) = IIf(Rs3.GetValue(21) = "D", Rs3.GetValue(18), "")
                oHoja.Cells(Fila, 13) = IIf(Rs3.GetValue(21) = "H", Rs3.GetValue(18), "")
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
            oHoja.Range(String.Format("A7:M{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:M{0}", Fila - 1)).Interior.ColorIndex = 2

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
        'tspbExportar.Value = e.ProgressPercentage
        'tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub

    Private Sub ExportarComplete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls ", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'tspbExportar.Value = 0
        'stEstado.Visible = False
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