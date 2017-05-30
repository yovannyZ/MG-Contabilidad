Imports System.Data.SqlClient
Public Class REPORTE_COMP_MASK
    Dim OFR As New REP_COMP_MASK
    Dim OFR2 As New REP_COMP_MASK_SALDO
    Dim OBJ As New Class1
    Dim TXT_MOV_DEBE0, TXT_MOV_HABER0, TXT_MOV_DEBE, TXT_MOV_DEBE2, TXT_MOV_HABER2, TXT_MOV_HABER, MES_ANT, MES_ACTUAL, TXT_SALDO_DEBE, TXT_SALDO_HABER, TXT_SELECT, SALDO_MES_ANTERIOR, SALDO_MES, SALDO_AL_MES As String
    Private Sub btn_pantalla1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (txt_mask.Text.Trim = "") Then MessageBox.Show("Debe ingresar la Mascara", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mask.Focus() : Exit Sub
        If (CBO_MES1.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES1.Focus() : Exit Sub
        If (CBO_MES2.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES2.Focus() : Exit Sub
        If Len(Trim(txt_mask.Text)) <> 8 Then MessageBox.Show("Ingresar una Cuenta Contable de 8 digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mask.Focus() : Exit Sub
        CREAR_SELECT()
        CARGAR_DATASET()
        OFR.CREAR_REPORTE(CBO_MES1.Text, dtp1.Value.Date, txt_mask.Text, CBO_MES2.Text)
        OFR.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click
        main(83) = 0
        Close()
    End Sub
    Sub CARGAR_DATASET()
        OFR.DT_REP_COMPROBACION.DataTable1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand(TXT_SELECT, con)
            PROG_01.UpdatedRowSource = UpdateRowSource.Both
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@MASK", SqlDbType.Char).Value = txt_mask.Text.Replace("X", "_")
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
                If Rs3.GetValue(2) <> 0 Or Rs3.GetValue(3) <> 0 Or Rs3.GetValue(4) <> 0 Or Rs3.GetValue(5) <> 0 Or Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7) <> 0 Or Decimal.Parse(colum8) <> 0 Or Decimal.Parse(colum9) <> 0 Or Decimal.Parse(colum10) <> 0 Or Decimal.Parse(colum11) <> 0 Then
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
    Sub CREAR_SELECT()
        '-------------------------------------------------------
        Me.TXT_SALDO_DEBE = ""
        Me.TXT_SALDO_HABER = ""
        If (Me.CBO_MES1.SelectedIndex = 0) Then
            Me.TXT_SALDO_DEBE = "IM_DEBITO00"
            Me.TXT_SALDO_HABER = "IM_CREDITO00"
        Else
            Me.TXT_SALDO_DEBE = "0.00"
            Me.TXT_SALDO_HABER = "0.00"
        End If

        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        Dim MOV_D As String = ""
        Dim MOV_H As String = ""
        Dim I2 As Integer = Integer.Parse(CBO_MES1.Text)
        Dim I3 As Integer
        Dim CONT2 As Integer = Integer.Parse(CBO_MES2.Text)
        I2 = I2
        I3 = I2
        If I3 = 0 Then I3 += 1

        Do While (I3 <= CONT2)
            If (I3 = CONT2) Then
                MOV_D = (MOV_D & " IM_DEBITO" & I3.ToString("00"))
                MOV_H = (MOV_H & " IM_CREDITO" & I3.ToString("00"))
            Else
                MOV_D = (MOV_D & " IM_DEBITO" & I3.ToString("00") & " + ")
                MOV_H = (MOV_H & " IM_CREDITO" & I3.ToString("00") & " + ")
            End If
            I3 += 1
        Loop

        Do While (I2 <= CONT2)
            If (I2 = CONT2) Then
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00"))
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00"))
            Else
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00") & " + ")
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00") & " + ")
            End If
            I2 += 1
        Loop
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        TXT_SELECT = String.Concat(New String() {"SELECT A.COD_CUENTA, A.DESC_CUENTA,(", TXT_SALDO_DEBE, "),(", TXT_SALDO_HABER, "),(", MOV_D, "),(", MOV_H, ") ,CASE WHEN (", TXT_MOV_DEBE, " )>(", TXT_MOV_HABER, ") THEN (", TXT_MOV_DEBE, " )-(", TXT_MOV_HABER, ") ELSE 0 END, CASE WHEN (", TXT_MOV_HABER, ")>(", TXT_MOV_DEBE, ") THEN (", TXT_MOV_HABER, ")-(", TXT_MOV_DEBE, ") ELSE 0 END ,(SELECT ISNULL((", TXT_MOV_DEBE, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((", TXT_MOV_HABER, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( ", TXT_MOV_DEBE, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PASIVO, (SELECT ISNULL(( ", TXT_MOV_HABER, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')),CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=8 AND A.COD_CUENTA LIKE @MASK"})
        'TXT_SELECT = String.Concat(New String() {"SELECT A.COD_CUENTA, A.DESC_CUENTA,(", TXT_SALDO_DEBE, "),(", TXT_SALDO_HABER, "),(", TXT_MOV_DEBE, "),(", TXT_MOV_HABER, ") ,CASE WHEN (", TXT_MOV_DEBE, " )>(", TXT_MOV_HABER, ") THEN (", TXT_MOV_DEBE, " )-(", TXT_MOV_HABER, ") ELSE 0 END, CASE WHEN (", TXT_MOV_HABER, ")>(", TXT_MOV_DEBE, ") THEN (", TXT_MOV_HABER, ")-(", TXT_MOV_DEBE, ") ELSE 0 END ,(SELECT ISNULL((", TXT_MOV_DEBE, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((", TXT_MOV_HABER, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( ", TXT_MOV_DEBE, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PASIVO, (SELECT ISNULL(( ", TXT_MOV_HABER, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')),CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=8 AND A.COD_CUENTA LIKE @MASK"})
    End Sub
    Private Sub REPORTE_COMP_MASK_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_COMP_MASK_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
    End Sub
    Private Sub btn_pantalla2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla2.Click
        If (txt_mask2.Text.Trim = "") Then MessageBox.Show("Debe ingresar la Mascara", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mask2.Focus() : Exit Sub
        If (CBO_MES22.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES22.Focus() : Exit Sub
        If Len(Trim(txt_mask2.Text)) <> 8 Then MessageBox.Show("Ingresar una Cuenta Contable de 8 digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mask2.Focus() : Exit Sub
        CREAR_SELECT2()
        CARGAR_DATASET2()
        OFR2.CREAR_REPORTE(CBO_MES22.Text, dtp2.Value.Date, txt_mask2.Text, CBO_MES22.Text)
        OFR2.ShowDialog()
    End Sub
    Sub CREAR_SELECT2()
        MES_ACTUAL = CBO_MES22.Text
        MES_ANT = (CBO_MES22.Text - 1).ToString("00")
        '-------------------------------------------------------
        TXT_MOV_DEBE0 = ""
        TXT_MOV_HABER0 = ""
        Select Case MES_ACTUAL
            Case "00" : TXT_MOV_DEBE0 = "IM_DEBITO00" : TXT_MOV_HABER0 = "IM_CREDITO00"
            Case "01" : TXT_MOV_DEBE0 = "IM_DEBITO01" : TXT_MOV_HABER0 = "IM_CREDITO01"
            Case "02" : TXT_MOV_DEBE0 = "IM_DEBITO02" : TXT_MOV_HABER0 = "IM_CREDITO02"
            Case "03" : TXT_MOV_DEBE0 = "IM_DEBITO03" : TXT_MOV_HABER0 = "IM_CREDITO03"
            Case "04" : TXT_MOV_DEBE0 = "IM_DEBITO04" : TXT_MOV_HABER0 = "IM_CREDITO04"
            Case "05" : TXT_MOV_DEBE0 = "IM_DEBITO05" : TXT_MOV_HABER0 = "IM_CREDITO05"
            Case "06" : TXT_MOV_DEBE0 = "IM_DEBITO06" : TXT_MOV_HABER0 = "IM_CREDITO06"
            Case "07" : TXT_MOV_DEBE0 = "IM_DEBITO07" : TXT_MOV_HABER0 = "IM_CREDITO07"
            Case "08" : TXT_MOV_DEBE0 = "IM_DEBITO08" : TXT_MOV_HABER0 = "IM_CREDITO08"
            Case "09" : TXT_MOV_DEBE0 = "IM_DEBITO09" : TXT_MOV_HABER0 = "IM_CREDITO09"
            Case "10" : TXT_MOV_DEBE0 = "IM_DEBITO10" : TXT_MOV_HABER0 = "IM_CREDITO10"
            Case "11" : TXT_MOV_DEBE0 = "IM_DEBITO11" : TXT_MOV_HABER0 = "IM_CREDITO11"
            Case "12" : TXT_MOV_DEBE0 = "IM_DEBITO12" : TXT_MOV_HABER0 = "IM_CREDITO12"
            Case "13" : TXT_MOV_DEBE0 = "IM_DEBITO13" : TXT_MOV_HABER0 = "IM_CREDITO13"
        End Select
        'SALDO_MES = TXT_MOV_DEBE0 - TXT_MOV_HABER0
        '------------------------------------------------------------------
        'Me.TXT_SALDO_DEBE = ""
        'Me.TXT_SALDO_HABER = ""
        'If (Me.CBO_MES1.SelectedIndex = 0) Then
        '    Me.TXT_SALDO_DEBE = "IM_DEBITO00"
        '    Me.TXT_SALDO_HABER = "IM_CREDITO00"
        'Else
        '    Me.TXT_SALDO_DEBE = "0.00"
        '    Me.TXT_SALDO_HABER = "0.00"
        'End If

        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        Dim I2 As Integer = Integer.Parse("00")
        Dim CONT2 As Integer = Integer.Parse(MES_ANT)
        I2 = I2
        Do While (I2 <= CONT2)
            If (I2 = CONT2) Then
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00"))
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00"))
            Else
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00") & " + ")
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00") & " + ")
            End If
            I2 += 1
        Loop
        'SALDO_MES_ANTERIOR = TXT_MOV_DEBE - TXT_MOV_HABER
        '-----------------------------------------------------------------------------------------
        TXT_MOV_DEBE2 = ""
        TXT_MOV_HABER2 = ""
        Dim I3 As Integer = Integer.Parse("00")
        Dim CONT3 As Integer = Integer.Parse(MES_ACTUAL)
        I2 = I2
        Do While (I3 <= CONT3)
            If (I3 = CONT3) Then
                TXT_MOV_DEBE2 = (TXT_MOV_DEBE2 & " IM_DEBITO" & I3.ToString("00"))
                TXT_MOV_HABER2 = (TXT_MOV_HABER2 & " IM_CREDITO" & I3.ToString("00"))
            Else
                TXT_MOV_DEBE2 = (TXT_MOV_DEBE2 & " IM_DEBITO" & I3.ToString("00") & " + ")
                TXT_MOV_HABER2 = (TXT_MOV_HABER2 & " IM_CREDITO" & I3.ToString("00") & " + ")
            End If
            I3 += 1
        Loop
        'SALDO_AL_MES = TXT_MOV_DEBE2 - TXT_MOV_HABER2
        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'TXT_SELECT = String.Concat(New String() {"SELECT A.COD_CUENTA, A.DESC_CUENTA,(", TXT_SALDO_DEBE, "),(", TXT_SALDO_HABER, "),(", TXT_MOV_DEBE, "),(", TXT_MOV_HABER, ") ,CASE WHEN (", TXT_MOV_DEBE, " )>(", TXT_MOV_HABER, ") THEN (", TXT_MOV_DEBE, " )-(", TXT_MOV_HABER, ") ELSE 0 END, CASE WHEN (", TXT_MOV_HABER, ")>(", TXT_MOV_DEBE, ") THEN (", TXT_MOV_HABER, ")-(", TXT_MOV_DEBE, ") ELSE 0 END ,(SELECT ISNULL((", TXT_MOV_DEBE, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D')) ,  (SELECT ISNULL((", TXT_MOV_HABER, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D')),(SELECT ISNULL(( ", TXT_MOV_DEBE, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('E','F','G')) AS PASIVO, (SELECT ISNULL(( ", TXT_MOV_HABER, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('E','F','G')),CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=8 AND A.COD_CUENTA LIKE @MASK"})

        TXT_SELECT = String.Concat(New String() {"SELECT A.COD_CUENTA, A.DESC_CUENTA,(SELECT ISNULL((", TXT_MOV_DEBE, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO ) AS DEBE_AL_MES_ANTERIOR , (SELECT ISNULL((", TXT_MOV_HABER, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO )AS HABER_AL_MES_ANTERIOR,(SELECT ISNULL((", TXT_MOV_DEBE0, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO ) AS DEBE_DEL_MES , (SELECT ISNULL((", TXT_MOV_HABER0, " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO )AS HABER_DEL_MES,(SELECT ISNULL(( ", TXT_MOV_DEBE2, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE(M1.COD_CUENTA = A.COD_CUENTA And M1.AÑO = A.AÑO))  AS DEBE_AL_MES_ACTUAL , (SELECT ISNULL(( ", TXT_MOV_HABER2, "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO ) AS HABER_AL_MES_ACTUAL ,CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=8 AND A.COD_CUENTA LIKE @MASK"})

    End Sub
    Sub CARGAR_DATASET2()
        OFR2.DT_REP_COMPROBACION.SALDO.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand(TXT_SELECT, con)
            PROG_01.UpdatedRowSource = UpdateRowSource.Both
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@MASK", SqlDbType.Char).Value = txt_mask2.Text.Replace("X", "_")
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                'Dim colum8 As String = Rs3.GetValue(8).ToString
                'Dim colum9 As String = Rs3.GetValue(9).ToString
                'Dim colum10 As String = Rs3.GetValue(10).ToString
                'Dim colum11 As String = Rs3.GetValue(11).ToString
                'If (colum8 = "") Then
                '    colum8 = (CDbl(0))
                'End If
                'If (colum9 = "") Then
                '    colum9 = (CDbl(0))
                'End If
                'If (colum10 = "") Then
                '    colum10 = (CDbl(0))
                'End If
                'If (colum11 = "") Then
                '    colum11 = (CDbl(0))
                'End If
                If Rs3.GetValue(2) <> 0 Or Rs3.GetValue(3) <> 0 Or Rs3.GetValue(4) <> 0 Or Rs3.GetValue(5) <> 0 Or Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7) <> 0 Then
                    OFR2.DT_REP_COMPROBACION.SALDO.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)))
                End If
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class