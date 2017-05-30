Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_CC_SALDO
    Dim COD_CC, COD_MONEDA, ST_CC As String
    Dim OBJ As New Class1
    Dim REP As New REP_CC_SALDO
    Dim P1 As Integer = 0
    Dim P2 As Integer = 0
    Dim P3 As Integer = 0
    Dim P4 As Integer = 0
    Dim P5 As Integer = 0
    Dim P6 As Integer = 0
    Dim P7 As Integer = 0
    Dim P8 As Integer = 0
    Dim P9 As Integer = 0
    Dim P10 As Integer = 0
    Dim P11 As Integer = 0
    Dim P12 As Integer = 0

    Private rutaExcel, archivoExcel As String
    Private Moneda As String
    Private CodMes As Integer
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_cc.SelectedIndex = -1 And ch_cc.Checked Then MessageBox.Show("Debe elegir un Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cc.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_moneda.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda.Focus() : Exit Sub
        If ch_cc.Checked Then
            ST_CC = "0"
            COD_CC = OBJ.COD_CC(cbo_cc.Text)
        Else
            ST_CC = "1"
            COD_CC = " "
        End If
        'Dim DELMES As Integer = cbo_mes1.SelectedIndex
        Dim ALMES As Integer = cbo_mes2.SelectedIndex
       
        Dim CONT0 As Integer = (ALMES + 1)
        Dim I As Integer = ("00" + 1)
        P1 = 0 : P2 = 0 : P3 = 0 : P4 = 0 : P5 = 0 : P6 = 0
        P7 = 0 : P8 = 0 : P9 = 0 : P10 = 0 : P11 = 0 : P12 = 0
        Do While (I <= CONT0)
            Dim VAR1 As Integer = I
            If (VAR1 = Integer.Parse("1")) Then
                P1 = 1
            ElseIf (VAR1 = Integer.Parse("2")) Then
                P2 = 1
            ElseIf (VAR1 = Integer.Parse("3")) Then
                P3 = 1
            ElseIf (VAR1 = Integer.Parse("4")) Then
                P4 = 1
            ElseIf (VAR1 = Integer.Parse("5")) Then
                P5 = 1
            ElseIf (VAR1 = Integer.Parse("6")) Then
                P6 = 1
            ElseIf (VAR1 = Integer.Parse("7")) Then
                P7 = 1
            ElseIf (VAR1 = Integer.Parse("8")) Then
                P8 = 1
            ElseIf (VAR1 = Integer.Parse("9")) Then
                P9 = 1
            ElseIf (VAR1 = Integer.Parse("10")) Then
                P10 = 1
            ElseIf (VAR1 = Integer.Parse("11")) Then
                P11 = 1
            ElseIf (VAR1 = Integer.Parse("12")) Then
                P12 = 1
            End If
            I += 1
        Loop
        If (cbo_moneda.SelectedIndex = 0) Then
            COD_MONEDA = "S"
        ElseIf (cbo_moneda.SelectedIndex = 1) Then
            COD_MONEDA = "D"
        End If
        LLENAR_DATASET()
        REP.CREAR_REPORTE(cbo_mes2.Text, COD_CC, ST_CC, COD_MONEDA, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, cbo_moneda.Text)
        REP.ShowDialog()
        'End If
    End Sub
    Sub LLENAR_DATASET()
        REP.LIMPIAR()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_CC_SALDO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.CommandTimeout = 720
            PROG_01.Parameters.Add("@ST_CC", SqlDbType.Char).Value = ST_CC
            PROG_01.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = COD_CC
            PROG_01.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            Dim TOTAL As Decimal = 0.0
            While Rs3.Read
                '-------------------------------------------------
                If P1 = "1" Then TOTAL = Rs3.GetValue(4)
                If P1 = "1" And P2 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5)
                If P1 = "1" And P2 = "1" And P3 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" And P7 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" And P7 = "1" And P8 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" And P7 = "1" And P8 = "1" And P9 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" And P7 = "1" And P8 = "1" And P9 = "1" And P10 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" And P7 = "1" And P8 = "1" And P9 = "1" And P10 = "1" And P11 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                If P1 = "1" And P2 = "1" And P3 = "1" And P4 = "1" And P5 = "1" And P6 = "1" And P7 = "1" And P8 = "1" And P9 = "1" And P10 = "1" And P11 = "1" And P12 = "1" Then TOTAL = Rs3.GetValue(4) + Rs3.GetValue(5) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15)
                '-------------------------------------------------
                REP.llenar_dt((Rs3.GetValue(0)).ToString, Rs3.GetValue(1).ToString, Rs3.GetValue(2).ToString, Rs3.GetValue(3).ToString, Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), TOTAL)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(115) = 0
        Close()
    End Sub
    Sub CARGAR_CENTRO_COSTOS()
        cbo_cc.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AREA", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_cc.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cc.CheckedChanged
        If ch_cc.Checked = True Then
            cbo_cc.Enabled = True
        Else
            cbo_cc.SelectedIndex = -1
            cbo_cc.Enabled = False
        End If
    End Sub
    Private Sub REPORTE_CC_SALDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_CC_CTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_CENTRO_COSTOS()
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If cbo_cc.SelectedIndex = -1 And ch_cc.Checked Then MessageBox.Show("Debe elegir un Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cc.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_moneda.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda.Focus() : Exit Sub
        If ch_cc.Checked Then
            ST_CC = "0"
            COD_CC = OBJ.COD_CC(cbo_cc.Text)
        Else
            ST_CC = "1"
            COD_CC = " "
        End If
        If (cbo_moneda.SelectedIndex = 0) Then
            COD_MONEDA = "S"
        ElseIf (cbo_moneda.SelectedIndex = 1) Then
            COD_MONEDA = "D"
        End If
        Moneda = cbo_moneda.Text
        CodMes = cbo_mes2.SelectedIndex + 1
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                'MES0 = (OBJ.COD_MES(cboMes.Text))
                'DESC_MES0 = cboMes.Text
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
            oHoja.Cells(3, 1) = String.Format("MONEDA: {0}", Moneda)

            oHoja.Range("C2:L2").Merge()
            oHoja.Range("C2:L2").Font.Bold = True
            oHoja.Cells(2, 3) = "SALDOS CENTRO DE COSTOS / CUENTA"


            oHoja.Range("C3:L3").Merge()
            oHoja.Range("C3:L3").Font.Bold = True
            'oHoja.Cells(3, 3) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:P5"

            oHoja.Cells(5, 1) = "Cod. CC." : oHoja.Cells(6, 2) = "CC"
            oHoja.Cells(5, 3) = "Cod. Cta." : oHoja.Cells(5, 4) = "Cuenta"

            oHoja.Cells(5, 5) = "Enero" : oHoja.Cells(5, 6) = "Febrero"
            oHoja.Cells(5, 7) = "Marzo" : oHoja.Cells(5, 8) = "Abril"
            oHoja.Cells(5, 9) = "Mayo" : oHoja.Cells(5, 10) = "Junio"
            oHoja.Cells(5, 11) = "Julio" : oHoja.Cells(5, 12) = "Agosto"
            oHoja.Cells(5, 13) = "Setiembre" : oHoja.Cells(5, 14) = "Octubre"
            oHoja.Cells(5, 15) = "Noviembre" : oHoja.Cells(5, 16) = "Diciembre"
            'oHoja.Cells(5, 17) = "Total"

            oHoja.Range("A:D").NumberFormat = "@"
            oHoja.Range("E:P").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 6
            archivoExcel = "SaldoCC"

            Dim Cmd As New SqlCommand("REPORTE_CC_SALDO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandTimeout = 720
            Cmd.Parameters.Add("@ST_CC", SqlDbType.Char).Value = ST_CC
            Cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = COD_CC
            Cmd.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                oHoja.Cells(Fila, 3) = Rs3.GetValue(3)
                oHoja.Cells(Fila, 4) = Rs3.GetValue(2)
                oHoja.Cells(Fila, 5) = IIf(1 <= CodMes, Rs3.GetValue(4), 0)
                oHoja.Cells(Fila, 6) = IIf(2 <= CodMes, Rs3.GetValue(5), 0)
                oHoja.Cells(Fila, 7) = IIf(3 <= CodMes, Rs3.GetValue(6), 0)
                oHoja.Cells(Fila, 8) = IIf(4 <= CodMes, Rs3.GetValue(7), 0)
                oHoja.Cells(Fila, 9) = IIf(5 <= CodMes, Rs3.GetValue(8), 0)
                oHoja.Cells(Fila, 10) = IIf(6 <= CodMes, Rs3.GetValue(9), 0)
                oHoja.Cells(Fila, 11) = IIf(7 <= CodMes, Rs3.GetValue(10), 0)
                oHoja.Cells(Fila, 12) = IIf(8 <= CodMes, Rs3.GetValue(11), 0)
                oHoja.Cells(Fila, 13) = IIf(9 <= CodMes, Rs3.GetValue(12), 0)
                oHoja.Cells(Fila, 14) = IIf(10 <= CodMes, Rs3.GetValue(13), 0)
                oHoja.Cells(Fila, 15) = IIf(11 <= CodMes, Rs3.GetValue(14), 0)
                oHoja.Cells(Fila, 16) = IIf(12 <= CodMes, Rs3.GetValue(15), 0)
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
            oHoja.Range(String.Format("A6:P{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A6:P{0}", Fila - 1)).Interior.ColorIndex = 2

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