Imports System.Data.SqlClient
Public Class REPORTE_MAYOR
    Dim OBJ As New Class1
    Dim REP As New REP_MAYOR
    Dim TXT_ANT_DEBE, HOJA, TXT_ANT_HABER, TXT_MOV_DEBE, TXT_MOV_HABER, TXT_SELECT, TXT_WHERE As String
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If ch_gral.Checked = False And ch_saldo.Checked = False And ch_ana.Checked = False Then MessageBox.Show("Debe elegir una opción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : ch_gral.Focus() : Exit Sub
        If CBO_MES_1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_1.Focus() : Exit Sub
        If cbo_hoja.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Hoja a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub
        '-----------------------------------------------------------------------
        If ch_gral.Checked Then
            If txt_cod_cta0.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
            If txt_cod_cuenta2.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cuenta2.Focus() : Exit Sub
            CREAR_SELECT_SALDO_GRAL()
            EJECUTAR_SELECT_SALDO_GRAL()
            CREAR_SELECT_GRAL()
            EJECUTAR_SELECT_GRAL()
            '------------validando impresion hoja
            Select Case cbo_hoja.SelectedIndex
                Case "0"
                    HOJA = "01"
                Case "1"
                    HOJA = "02"
            End Select
            REP.HOJA = HOJA
            REP.OCULTAR_TOTAL = True
            REP.UBICAR_REPORTE()
            '------------
            REP.CREAR_REPORTE(CBO_MES_1.Text, dtp01.Value)
            REP.ShowDialog()
        End If
        '-----------------------------------------------------------------------
        If ch_saldo.Checked Then
            If cbo_nivel.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_nivel.Focus() : Exit Sub
            CREAR_SELECT_SALDO()
            EJECUTAR_SELECT_SALDO()
            '------------validando impresion hoja
            Select Case cbo_hoja.SelectedIndex
                Case "0"
                    HOJA = "01"
                Case "1"
                    HOJA = "02"
            End Select

            REP.HOJA = HOJA
            REP.OCULTAR_TOTAL = True
            REP.UBICAR_REPORTE()
            '------------
            REP.CREAR_REPORTE(CBO_MES_1.Text, dtp01.Value)
            REP.ShowDialog()
        End If
        '-----------------------------------------------------------------------
        If ch_ana.Checked Then
            CREAR_SELECT_ANA()
            EJECUTAR_SELECT_ANA()
            '------------validando impresion hoja
            Select Case cbo_hoja.SelectedIndex
                Case "0"
                    HOJA = "01"
                Case "1"
                    HOJA = "02"
            End Select
            REP.HOJA = HOJA
            REP.OCULTAR_TOTAL = False
            REP.UBICAR_REPORTE()
            '------------
            REP.CREAR_REPORTE(CBO_MES_1.Text, dtp01.Value)
            REP.ShowDialog()
        End If
        '-----------------------------------------------------------------------
    End Sub
    Sub EJECUTAR_SELECT_ANA()
        REP.DT_REP_MAYOR.DataTable1.Rows.Clear()
        Try
            Dim CMD As New SqlCommand(TXT_SELECT, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = CBO_MES_1.Text
            CMD.Parameters.Add("@COD_CTA1", SqlDbType.Char).Value = txt_cod_cta0.Text
            CMD.Parameters.Add("@COD_CTA2", SqlDbType.Char).Value = txt_cod_cuenta2.Text
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                REP.DT_REP_MAYOR.DataTable1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub EJECUTAR_SELECT_GRAL()
        'REP.DT_REP_MAYOR.DataTable1.Rows.Clear()
        Try
            Dim CMD As New SqlCommand(TXT_SELECT, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = CBO_MES_1.Text
            CMD.Parameters.Add("@COD_CTA1", SqlDbType.Char).Value = txt_cod_cta0.Text
            CMD.Parameters.Add("@COD_CTA2", SqlDbType.Char).Value = txt_cod_cuenta2.Text
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                REP.DT_REP_MAYOR.DataTable1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub EJECUTAR_SELECT_SALDO_GRAL()
        REP.DT_REP_MAYOR.DataTable1.Rows.Clear()
        Try
            Dim CMD As New SqlCommand(TXT_SELECT, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@NIVEL", SqlDbType.Char).Value = "8"
            CMD.Parameters.Add("@COD_CTA1", SqlDbType.Char).Value = txt_cod_cta0.Text
            CMD.Parameters.Add("@COD_CTA2", SqlDbType.Char).Value = txt_cod_cuenta2.Text
            con.Open()
            CMD.CommandTimeout = 720
            CMD.ExecuteNonQuery()

            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                REP.DT_REP_MAYOR.DataTable1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), "", "", "", "", "", "", "01/01/1900", "", "", "", "", "", "", 0, 0, 0, Rs3.GetValue(4), "", Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub EJECUTAR_SELECT_SALDO()
        REP.DT_REP_MAYOR.DataTable1.Rows.Clear()
        Try
            Dim CMD As New SqlCommand(TXT_SELECT, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@NIVEL", SqlDbType.Char).Value = cbo_nivel.Text
            CMD.Parameters.Add("@COD_CTA1", SqlDbType.Char).Value = txt_cod_cta0.Text
            CMD.Parameters.Add("@COD_CTA2", SqlDbType.Char).Value = txt_cod_cuenta2.Text
            con.Open()
            CMD.CommandTimeout = 720
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                REP.DT_REP_MAYOR.DataTable1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), "", "", "", "", "", "", "01/01/1900", "", "", "", "", "", "", 0, 0, 0, Rs3.GetValue(4), "", Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(91) = 0
        Close()
    End Sub
    Private Sub ch_ana_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_ana.CheckedChanged
        If ch_ana.Checked Then
            ch_gral.Enabled = False
            ch_saldo.Enabled = False
            cbo_nivel.Enabled = False

            'txt_cod_cta0.Clear()
            'txt_desc_cta0.Clear()
            'txt_cod_cuenta2.Clear()
            'txt_desc_cuenta2.Clear()

            'txt_cod_cta0.Enabled = False
            'txt_desc_cta0.Enabled = False
            'txt_cod_cuenta2.Enabled = False
            'txt_desc_cuenta2.Enabled = False
        Else
            ch_gral.Enabled = True
            ch_saldo.Enabled = True
        End If
    End Sub
    Private Sub ch_gral_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_gral.CheckedChanged
        If ch_gral.Checked Then
            txt_cod_cta0.Enabled = True
            txt_desc_cta0.Enabled = True
            txt_cod_cuenta2.Enabled = True
            txt_desc_cuenta2.Enabled = True
            ch_saldo.Enabled = False
            ch_ana.Enabled = False
            cbo_nivel.Enabled = False
        Else
            ch_saldo.Enabled = True
            ch_ana.Enabled = True
        End If
    End Sub
    Private Sub ch_saldo_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_saldo.CheckedChanged
        If ch_saldo.Checked Then
            ch_gral.Enabled = False
            ch_ana.Enabled = False
            cbo_nivel.Enabled = True
            'txt_cod_cta0.Clear()
            'txt_desc_cta0.Clear()
            'txt_cod_cuenta2.Clear()
            'txt_desc_cuenta2.Clear()
            'txt_cod_cta0.Enabled = False
            'txt_desc_cta0.Enabled = False
            'txt_cod_cuenta2.Enabled = False
            'txt_desc_cuenta2.Enabled = False
        Else
            ch_gral.Enabled = True
            ch_ana.Enabled = True
        End If
    End Sub
    Sub CREAR_SELECT_ANA()
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        TXT_MOV_DEBE = ("IM_DEBITO" & CBO_MES_1.Text)
        TXT_MOV_HABER = ("IM_CREDITO" & CBO_MES_1.Text)
        TXT_ANT_DEBE = ""
        TXT_ANT_HABER = ""
        Dim I As Integer = 0
        Dim CONT As Integer = CInt(Math.Round(CDbl((Decimal.Parse(CBO_MES_1.Text) - 1))))
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (I = CONT) Then
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00"))
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00"))
            Else
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00") & " + ")
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00") & " + ")
            End If
            I += 1
        Loop
        If (CBO_MES_1.Text = "00") Then
            TXT_ANT_DEBE = (CDbl(0))
            TXT_ANT_HABER = (CDbl(0))
        End If
        TXT_WHERE = ""
        Dim I2 As Integer = 0
        Dim CONT2 As Integer = Integer.Parse(CBO_MES_1.Text)
        I2 = 0
        Do While (I2 <= CONT2)
            If (I2 = CONT2) Then
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00")})
            Else
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00"), " + "})
            End If
            I2 += 1
        Loop
        TXT_SELECT = String.Concat(New String() {"SELECT (", TXT_ANT_DEBE, "),(", TXT_ANT_HABER, "),(", TXT_MOV_DEBE, "),(", TXT_MOV_HABER, "), ISNULL(T.COD_AUX,''),T.COD_COMP,T.NRO_COMP,T.FECHA_COMP,T.COD_DOC,T.NRO_DOC,ISNULL(T.FECHA_DOC,''),T.COD_PER,T.COD_CC,T.GLOSA,T.COD_REF, T.NRO_REF,T.COD_MONEDA,T.IMP_D,CASE WHEN T.COD_D_H='D' THEN IMP_S ELSE 0 END AS DEBE, CASE WHEN T.COD_D_H='H' THEN IMP_S ELSE 0 END AS HABER,M.COD_CUENTA,DAY(T.FECHA_COMP),D.DESC_CUENTA FROM MAESTRO_SALDOS M LEFT JOIN T_CON AS T ON M.AÑO=T.FE_AÑO AND M.COD_CUENTA=T.COD_CUENTA INNER JOIN MAESTRO_CUENTAS AS D ON M.COD_CUENTA=D.COD_CUENTA AND M.AÑO=D.AÑO WHERE M.AÑO =@FE_AÑO AND  LEN(M.COD_CUENTA)=8 AND (", TXT_WHERE, ") <> 0 AND T.FE_MES=@FE_MES and CAST(SUBSTRING(M.COD_CUENTA,0,3) AS INT) BETWEEN @COD_CTA1 AND @COD_CTA2"})
        'and CAST(SUBSTRING(M.COD_CUENTA,0,3) AS INT) BETWEEN @COD_CTA1 AND @COD_CTA2"
    End Sub
    Sub CREAR_SELECT_GRAL()
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        TXT_MOV_DEBE = ("IM_DEBITO" & CBO_MES_1.Text)
        TXT_MOV_HABER = ("IM_CREDITO" & CBO_MES_1.Text)
        TXT_ANT_DEBE = ""
        TXT_ANT_HABER = ""
        Dim I As Integer = 0
        Dim CONT As Integer = CInt(Math.Round(CDbl((Decimal.Parse(CBO_MES_1.Text) - 1))))
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (I = CONT) Then
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00"))
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00"))
            Else
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00") & " + ")
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00") & " + ")
            End If
            I += 1
        Loop
        If (CBO_MES_1.Text = "00") Then
            TXT_ANT_DEBE = (CDbl(0))
            TXT_ANT_HABER = (CDbl(0))
        End If
        TXT_WHERE = ""
        Dim I2 As Integer = 0
        Dim CONT2 As Integer = Integer.Parse(CBO_MES_1.Text)
        I2 = 0
        Do While (I2 <= CONT2)
            If (I2 = CONT2) Then
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00")})
            Else
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00"), " + "})
            End If
            I2 += 1
        Loop
        TXT_SELECT = String.Concat(New String() {"SELECT (", TXT_ANT_DEBE, "),(", TXT_ANT_HABER, "),(", TXT_MOV_DEBE, "),(", TXT_MOV_HABER, "), ISNULL(T.COD_AUX,''),T.COD_COMP,T.NRO_COMP,T.FECHA_COMP,T.COD_DOC,T.NRO_DOC,ISNULL(T.FECHA_DOC,''),T.COD_PER,T.COD_CC,T.GLOSA,T.COD_REF, T.NRO_REF,T.COD_MONEDA,T.IMP_D,CASE WHEN T.COD_D_H='D' THEN IMP_S ELSE 0 END AS DEBE, CASE WHEN T.COD_D_H='H' THEN IMP_S ELSE 0 END AS HABER,M.COD_CUENTA,DAY(T.FECHA_COMP),D.DESC_CUENTA FROM MAESTRO_SALDOS M LEFT JOIN T_CON AS T ON M.AÑO=T.FE_AÑO AND M.COD_CUENTA=T.COD_CUENTA INNER JOIN MAESTRO_CUENTAS AS D ON M.COD_CUENTA=D.COD_CUENTA AND M.AÑO=D.AÑO WHERE M.AÑO =@FE_AÑO AND CAST(SUBSTRING(M.COD_CUENTA,0,3) AS INT) BETWEEN @COD_CTA1 AND @COD_CTA2 AND (", TXT_WHERE, ") <> 0 AND T.FE_MES=@FE_MES "})
    End Sub
   Sub CREAR_SELECT_SALDO()
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        TXT_MOV_DEBE = ("IM_DEBITO" & CBO_MES_1.Text)
        TXT_MOV_HABER = ("IM_CREDITO" & CBO_MES_1.Text)
        TXT_ANT_DEBE = ""
        TXT_ANT_HABER = ""
        Dim I As Integer = 0
        Dim CONT As Integer = CInt(Math.Round(CDbl((Decimal.Parse(CBO_MES_1.Text) - 1))))
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (I = CONT) Then
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00"))
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00"))
            Else
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00") & " + ")
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00") & " + ")
            End If
            I += 1
        Loop
        If (CBO_MES_1.Text = "00") Then
            TXT_ANT_DEBE = (CDbl(0))
            TXT_ANT_HABER = (CDbl(0))
        End If
        TXT_WHERE = ""
        Dim I2 As Integer = 0
        Dim CONT2 As Integer = Integer.Parse(CBO_MES_1.Text)
        I2 = 0
        Do While (I2 <= CONT2)
            If (I2 = CONT2) Then
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00")})
            Else
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00"), " + "})
            End If
            I2 += 1
        Loop
        TXT_SELECT = String.Concat(New String() {"SELECT (", TXT_ANT_DEBE, "),(", TXT_ANT_HABER, "),(", TXT_MOV_DEBE, "),(", TXT_MOV_HABER, "),M.COD_CUENTA,D.DESC_CUENTA  FROM MAESTRO_SALDOS M  INNER JOIN MAESTRO_CUENTAS AS D  ON M.COD_CUENTA=D.COD_CUENTA AND M.AÑO=D.AÑO WHERE M.AÑO =@FE_AÑO   AND (", TXT_WHERE, ") <> 0 AND LEN(M.COD_CUENTA)<= @NIVEL AND CAST(SUBSTRING(M.COD_CUENTA,0,3) AS INT) BETWEEN @COD_CTA1 AND @COD_CTA2"})
        'AND CAST(SUBSTRING(M.COD_CUENTA,0,3) AS INT) BETWEEN @COD_CTA1 AND @COD_CTA2"})
    End Sub
    Sub CREAR_SELECT_SALDO_GRAL()
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        TXT_MOV_DEBE = ("IM_DEBITO" & CBO_MES_1.Text)
        TXT_MOV_HABER = ("IM_CREDITO" & CBO_MES_1.Text)
        TXT_ANT_DEBE = ""
        TXT_ANT_HABER = ""
        Dim I As Integer = 0
        Dim CONT As Integer = CInt(Math.Round(CDbl((Decimal.Parse(CBO_MES_1.Text) - 1))))
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (I = CONT) Then
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00"))
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00"))
            Else
                TXT_ANT_DEBE = (TXT_ANT_DEBE & " IM_DEBITO" & I.ToString("00") & " + ")
                TXT_ANT_HABER = (TXT_ANT_HABER & " IM_CREDITO" & I.ToString("00") & " + ")
            End If
            I += 1
        Loop
        If (CBO_MES_1.Text = "00") Then
            TXT_ANT_DEBE = (CDbl(0))
            TXT_ANT_HABER = (CDbl(0))
        End If
        TXT_WHERE = ""
        Dim I2 As Integer = 0
        Dim CONT2 As Integer = Integer.Parse(CBO_MES_1.Text)
        I2 = 0
        Do While (I2 <= CONT2)
            If (I2 = CONT2) Then
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00")})
            Else
                TXT_WHERE = String.Concat(New String() {TXT_WHERE, " IM_DEBITO", I2.ToString("00"), " + IM_CREDITO", I2.ToString("00"), " + "})
            End If
            I2 += 1
        Loop
        TXT_SELECT = String.Concat(New String() {"SELECT (", TXT_ANT_DEBE, "),(", TXT_ANT_HABER, "),(", TXT_MOV_DEBE, "),(", TXT_MOV_HABER, "),M.COD_CUENTA,D.DESC_CUENTA  FROM MAESTRO_SALDOS M  INNER JOIN MAESTRO_CUENTAS AS D  ON M.COD_CUENTA=D.COD_CUENTA AND M.AÑO=D.AÑO WHERE M.AÑO =@FE_AÑO   AND (", TXT_WHERE, ") <> 0 AND LEN(M.COD_CUENTA)<=@NIVEL  AND CAST(SUBSTRING(M.COD_CUENTA,0,3) AS INT) BETWEEN @COD_CTA1 AND @COD_CTA2"})
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cuenta.Item(1, dgw_cuenta.CurrentRow.Index).Value)
            Panel_cuenta.Visible = False
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            Panel_cuenta.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub
    Private Sub dgw_cuenta2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cuenta2.Text = (dgw_cuenta2.Item(0, dgw_cuenta2.CurrentRow.Index).Value)
            txt_desc_cuenta2.Text = (dgw_cuenta2.Item(1, dgw_cuenta2.CurrentRow.Index).Value)
            Panel_cuenta2.Visible = False
            kl2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cuenta2.Clear()
            txt_desc_cuenta2.Clear()
            Panel_cuenta2.Visible = False
            txt_cod_cuenta2.Focus()
        End If
    End Sub
    Sub MOSTRAR_CUENTAS()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTA_NIVEL2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("CUENTA")
            ADAP.Fill(DT)
            dgw_cuenta.DataSource = DT
            dgw_cuenta2.DataSource = DT
            dgw_cuenta.Columns.Item(0).Width = 50
            dgw_cuenta2.Columns.Item(0).Width = 50
            dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cuenta2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub REPORTE_MAYOR_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_MAYOR_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        MOSTRAR_CUENTAS()
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta0.Text = dgw_cuenta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cuenta.Item(1, i).Value.ToString
                        txt_cod_cuenta2.Focus()
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod_cUENTA2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cuenta2.LostFocus
        If (Strings.Trim(txt_cod_cuenta2.Text) <> "") Then
            If (dgw_cuenta2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta2.Sort(dgw_cuenta2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cuenta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cuenta2.Text.ToLower = dgw_cuenta2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cuenta2.Text = dgw_cuenta2.Item(0, i).Value.ToString
                        txt_desc_cuenta2.Text = dgw_cuenta2.Item(1, i).Value.ToString
                        CBO_MES_1.Focus()
                        Return
                    End If
                    If (txt_cod_cuenta2.Text.ToLower = Strings.Mid((dgw_cuenta2.Item(0, i).Value), 1, Strings.Len(txt_cod_cuenta2.Text)).ToLower) Then
                        dgw_cuenta2.CurrentCell = dgw_cuenta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta2.CurrentCell = dgw_cuenta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta2.Visible = True
                dgw_cuenta2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cuenta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = dgw_cuenta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cuenta2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cuenta2.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cuenta2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta2.Sort(dgw_cuenta2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                If (e.KeyData = Keys.Return) Then
                    Dim CONT0 As Integer = (dgw_cuenta2.RowCount - 1)
                    Dim i As Integer = 0
                    Do While (i <= CONT0)
                        If (txt_desc_cuenta2.Text.ToLower = Strings.Mid((dgw_cuenta2.Item(1, i).Value), 1, Strings.Len(txt_desc_cuenta2.Text)).ToLower) Then
                            dgw_cuenta2.CurrentCell = dgw_cuenta2.Rows.Item(i).Cells.Item(0)
                            Exit Do
                        End If
                        dgw_cuenta2.CurrentCell = dgw_cuenta2.Rows.Item(0).Cells.Item(0)
                        i += 1
                    Loop
                    Panel_cuenta2.Visible = True
                    dgw_cuenta2.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub cbo_nivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_nivel.SelectedIndexChanged

    End Sub
End Class