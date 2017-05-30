Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_COMP_GRAL
    Private OBJ As New Class1
    Private OFR As New REP_COMP_GRAL
    Private TXT_MOV_DEBE As String
    Private TXT_MOV_HABER As String
    Private TXT_SALDO_DEBE As String
    Private TXT_SALDO_HABER As String
    Private TXT_SELECT As String

    Private MES0, DESC_MES0, DESC_MES1, NIVEL As String
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cboMes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes.Focus() : Exit Sub
        If cboMes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes1.Focus() : Exit Sub
        If cbo_nivel.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_nivel.Focus() : Exit Sub
        If cbo_hoja.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Hoja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub
        Dim HOJA As String
        Select Case cbo_hoja.SelectedIndex
            Case 0 : HOJA = "01"
            Case 1 : HOJA = "02"
        End Select
        CREAR_SELECT()
        CARGAR_DATASET()
        OFR.HOJA = HOJA
        OFR.UBICAR_REPORTE()
        OFR.CREAR_REPORTE(cboMes1.Text, dtp1.Value.Date, OBJ.HALLAR_NRO_DIGITOS(OBJ.COD_NIVEL(cbo_nivel.Text)))
        OFR.ShowDialog()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(70) = 0
        Close()
    End Sub

    Public Sub CARGAR_DATASET()
        OFR.DT_REP_COMPROBACION.DataTable1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand(TXT_SELECT, con)
            PROG_01.UpdatedRowSource = UpdateRowSource.Both
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@NIVEL", SqlDbType.Char).Value = OBJ.HALLAR_NRO_DIGITOS(OBJ.COD_NIVEL(cbo_nivel.Text))
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Dim colum8 As String = Rs3.GetValue(8).ToString
                Dim colum9 As String = Rs3.GetValue(9).ToString
                Dim colum10 As String = Rs3.GetValue(10).ToString
                Dim colum11 As String = Rs3.GetValue(11).ToString
                If (colum8 = "") Then
                    colum8 = (CDbl(0))
                End If
                If (colum9 = "") Then
                    colum9 = (CDbl(0))
                End If
                If (colum10 = "") Then
                    colum10 = (CDbl(0))
                End If
                If (colum11 = "") Then
                    colum11 = (CDbl(0))
                End If
                If Rs3.GetValue(2) <> 0 Or Rs3.GetValue(3) <> 0 Or Rs3.GetValue(4) <> 0 Or Rs3.GetValue(5) <> 0 Or Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7) <> 0 Or (Decimal.Parse(colum8) <> 0) Or (Decimal.Parse(colum9) <> 0) Or (Decimal.Parse(colum10) <> 0) Or (Decimal.Parse(colum11) <> 0) Then
                    OFR.DT_REP_COMPROBACION.DataTable1.Rows.Add(New Object() {(Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15))})
                End If
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub CARGAR_NIVEL()
        cbo_nivel.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_NIVEL", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_nivel.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub
    Private Sub REPORTE_COMP_GRAL_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_COMP_GRAL_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_NIVEL()
    End Sub

    Public Sub CREAR_SELECT()
        TXT_SALDO_DEBE = ""
        TXT_SALDO_HABER = ""
        If (cboMes.SelectedIndex = 0) Then
            TXT_SALDO_DEBE = "IM_DEBITO00"
            TXT_SALDO_HABER = "IM_CREDITO00"
        Else
            TXT_SALDO_DEBE = "0.00"
            TXT_SALDO_HABER = "0.00"
        End If
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        Dim I2 As Integer = Integer.Parse(OBJ.COD_MES(cboMes.Text))
        If (I2 = 0) Then
            I2 = 1
        End If
        Dim CONT2 As Integer = Integer.Parse(OBJ.COD_MES(cboMes1.Text))
        Dim VAR0 As Integer = CONT2
        I2 = I2
        Do While (I2 <= VAR0)
            If (I2 = CONT2) Then
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00"))
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00"))
            Else
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00") & " + ")
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00") & " + ")
            End If
            I2 += 1
        Loop
        If (TXT_MOV_DEBE.Trim = "") Then
            TXT_MOV_DEBE = "0.00"
        End If
        If (TXT_MOV_HABER.Trim = "") Then
            TXT_MOV_HABER = "0.00"
        End If
        TXT_SELECT = ("SELECT  A.COD_CUENTA, A.DESC_CUENTA,(" & TXT_SALDO_DEBE & "),(" & TXT_SALDO_HABER & "),(" & TXT_MOV_DEBE & "),(" & TXT_MOV_HABER & ") ,CASE WHEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )>(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") THEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )-(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") ELSE 0 END, CASE WHEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")>(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") THEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")-(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") ELSE 0 END ,(SELECT ISNULL((" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " ), 0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PERDIDAS, (SELECT ISNULL(( " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS GANANCIAS,CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=@NIVEL")
    End Sub
    Public Sub CREAR_SELECT_EXCEL()
        TXT_SALDO_DEBE = ""
        TXT_SALDO_HABER = ""
        If (cboMes.SelectedIndex = 0) Then
            TXT_SALDO_DEBE = "IM_DEBITO00"
            TXT_SALDO_HABER = "IM_CREDITO00"
        Else
            TXT_SALDO_DEBE = "0.00"
            TXT_SALDO_HABER = "0.00"
        End If
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        Dim I2 As Integer = Integer.Parse(OBJ.COD_MES(cboMes.Text))
        If (I2 = 0) Then
            I2 = 1
        End If
        Dim CONT2 As Integer = Integer.Parse(OBJ.COD_MES(cboMes1.Text))
        Dim VAR0 As Integer = CONT2
        I2 = I2
        Do While (I2 <= VAR0)
            If (I2 = CONT2) Then
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00"))
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00"))
            Else
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00") & " + ")
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00") & " + ")
            End If
            I2 += 1
        Loop
        If (TXT_MOV_DEBE.Trim = "") Then
            TXT_MOV_DEBE = "0.00"
        End If
        If (TXT_MOV_HABER.Trim = "") Then
            TXT_MOV_HABER = "0.00"
        End If
        TXT_SELECT = ("SELECT  A.COD_CUENTA, A.DESC_CUENTA,(" & TXT_SALDO_DEBE & "),(" & TXT_SALDO_HABER & "),(" & TXT_MOV_DEBE & "),(" & TXT_MOV_HABER & ") ,CASE WHEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )>(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") THEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )-(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") ELSE 0 END, CASE WHEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")>(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") THEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")-(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") ELSE 0 END ,(SELECT ISNULL((" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " ), 0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PERDIDAS, (SELECT ISNULL(( " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS GANANCIAS,(SELECT ISNULL((  " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('E','G','N')) AS PERDIDAS_NAT,(SELECT ISNULL((  " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('E','G','N')) AS GANANCIAS_NAT,CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=@NIVEL")
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                MES0 = (OBJ.COD_MES(cboMes.Text))
                DESC_MES0 = cboMes.Text
                DESC_MES1 = cboMes1.Text
                NIVEL = OBJ.HALLAR_NRO_DIGITOS(OBJ.COD_NIVEL(cbo_nivel.Text))
                CREAR_SELECT_EXCEL()
                bwExportar.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub ExportarWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet
        Dim Activo, Pasivo As Decimal
        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"
22:
            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA
            oHoja.Range("A3:B3").Merge()
            oHoja.Range("A3:B3").Font.Bold = True
            'oHoja.Cells(3, 1) = String.Format("NIVEL: {0}", NIVEL)

            oHoja.Range("C2:N2").Merge()
            oHoja.Range("C2:N2").Font.Bold = True
            oHoja.Cells(2, 3) = "BALANCE DE COMPROBACIÓN"


            oHoja.Range("C3:N3").Merge()
            oHoja.Range("C3:N3").Font.Bold = True
            oHoja.Cells(3, 3) = String.Format("PERIODO: {0} A {1} DEL {2}", DESC_MES0, DESC_MES1, AÑO)
            Dim strRango As String = "C2:N3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:N6"

            oHoja.Range("A5:B5").Merge()
            oHoja.Cells(5, 1) = "CTA Y SUBCTA"
            oHoja.Cells(6, 1) = "Codigo" : oHoja.Cells(6, 2) = "Denominacion"

            oHoja.Range("C5:D5").Merge()
            oHoja.Cells(5, 3) = "SALDO INICIAL"
            oHoja.Cells(6, 3) = "Deudor" : oHoja.Cells(6, 4) = "Acreedor"

            oHoja.Range("E5:F5").Merge()
            oHoja.Cells(5, 5) = "MOVIMIENTO"
            oHoja.Cells(6, 5) = "Debe" : oHoja.Cells(6, 6) = "Haber"

            oHoja.Range("G5:H5").Merge()
            oHoja.Cells(5, 7) = "SALDOS FINALES"
            oHoja.Cells(6, 7) = "Deudor" : oHoja.Cells(6, 8) = "Acreedor"

            oHoja.Range("I5:J5").Merge()
            oHoja.Cells(5, 9) = "SALDOS FINALES BAL.GRAL."
            oHoja.Cells(6, 9) = "Activo" : oHoja.Cells(6, 10) = "Pasivo"

            oHoja.Range("K5:L5").Merge()
            oHoja.Cells(5, 11) = "PER. Y GAN. X FUNCION"
            oHoja.Cells(6, 11) = "Perdidas" : oHoja.Cells(6, 12) = "Ganancias"

            oHoja.Range("M5:N5").Merge()
            oHoja.Cells(5, 13) = "PER. Y GAN. X NAT"
            oHoja.Cells(6, 13) = "Perdidas" : oHoja.Cells(6, 14) = "Ganancias"

            oHoja.Range("A:B").NumberFormat = "@"
            oHoja.Range("C:Q").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 7
            Dim stCon As Integer
            archivoExcel = "ComprobacionGeneral"

            Dim Cmd As New SqlCommand(TXT_SELECT, con)
            Cmd.UpdatedRowSource = UpdateRowSource.Both
            Cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = NIVEL
            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            Dim colum8 As String
            Dim colum9 As String
            Dim colum10 As String
            Dim colum11 As String
            Dim colum12 As String
            Dim colum13 As String
            Do While Rs3.Read
                colum8 = Rs3.GetValue(8).ToString
                colum9 = Rs3.GetValue(9).ToString
                colum10 = Rs3.GetValue(10).ToString
                colum11 = Rs3.GetValue(11).ToString
                colum12 = Rs3.GetValue(12).ToString
                colum13 = Rs3.GetValue(13).ToString
                If (colum8 = "") Then
                    colum8 = (CDbl(0))
                End If
                If (colum9 = "") Then
                    colum9 = (CDbl(0))
                End If
                If (colum10 = "") Then
                    colum10 = (CDbl(0))
                End If
                If (colum11 = "") Then
                    colum11 = (CDbl(0))
                End If
                If (colum12 = "") Then
                    colum12 = (CDbl(0))
                End If
                If (colum13 = "") Then
                    colum13 = (CDbl(0))
                End If
                If Rs3.GetValue(2) <> 0 Or Rs3.GetValue(3) <> 0 Or Rs3.GetValue(4) <> 0 Or Rs3.GetValue(5) <> 0 Or Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7) <> 0 Or (Decimal.Parse(colum8) <> 0) Or (Decimal.Parse(colum9) <> 0) Or (Decimal.Parse(colum10) <> 0) Or (Decimal.Parse(colum11) <> 0) Or (Decimal.Parse(colum12) <> 0) Or (Decimal.Parse(colum13) <> 0) Then
                    oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                    oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                    oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                    oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                    oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                    oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                    oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                    oHoja.Cells(Fila, 8) = Rs3.GetValue(7)
                    Activo = 0 : Pasivo = 0
                    If (IsNumeric(Rs3.GetValue(8))) = False Then
                        Activo = 0
                    Else
                        Activo = Rs3.GetValue(8)
                    End If
                    If (IsNumeric(Rs3.GetValue(9))) = False Then
                        Pasivo = 0
                    Else
                        Pasivo = Rs3.GetValue(9)
                    End If
                    oHoja.Cells(Fila, 9) = IIf(Activo - Pasivo > 0, Activo - Pasivo, 0.0) 'Rs3.GetValue(8) 'Rs3.GetValue(8) 
                    oHoja.Cells(Fila, 10) = IIf(Pasivo - Activo > 0, Pasivo - Activo, 0.0) 'Rs3.GetValue(9)  'Rs3.GetValue(9)
                    oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                    oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                    oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                    oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                    Fila += 1
                End If
            Loop
            Rs3.Close()
            con.Close()


            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A7:N{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:N{0}", Fila - 1)).Interior.ColorIndex = 2

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

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete

    End Sub
End Class