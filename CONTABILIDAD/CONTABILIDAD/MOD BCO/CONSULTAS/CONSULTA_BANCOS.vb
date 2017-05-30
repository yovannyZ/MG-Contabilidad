Imports System.Data.SqlClient
Public Class CONSULTA_BANCOS
    Dim obj As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(24) = 0
        Close()
    End Sub
   Sub CARGAR_BANCOS()
        dgw1.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_BANCOS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            'pro_02.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw1.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_CUENTAS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_BANCOS()
        cargar_año()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_ctas.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_tbanco.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        DGW_CONC.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
    End Sub
    Sub CARGAR_AÑO()
        cbo_año1.Items.Clear()
        cbo_año2.Items.Clear()
        cbo_año3.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año1.Items.Add(Rs3.GetString(0))
                cbo_año2.Items.Add(Rs3.GetString(0))
                cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_saldos_ctas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_saldos_ctas.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl1.SelectedTab = TabPage4
        TabControl2.SelectedTab = TabPage5
        dgw2.Rows.Clear()
        Label6.Text = " Banco : " & " " & (dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString) & " " & (dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString)
        MESES1()
        CARGAR_SALDOS_MES1()
        'CARGAR_SALDOS_ACUMULADO1()
        HALLAR_SALDOS1()
    End Sub
    Sub MESES1()
        'dgw2.Rows.Add("00")
        dgw2.Rows.Add("01")
        dgw2.Rows.Add("02")
        dgw2.Rows.Add("03")
        dgw2.Rows.Add("04")
        dgw2.Rows.Add("05")
        dgw2.Rows.Add("06")
        dgw2.Rows.Add("07")
        dgw2.Rows.Add("08")
        dgw2.Rows.Add("09")
        dgw2.Rows.Add("10")
        dgw2.Rows.Add("11")
        dgw2.Rows.Add("12")
        'dgw2.Rows.Add("13")
    End Sub
    Sub CARGAR_SALDOS_MES1()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_SALDOS_ESTADO_CTA", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                Dim I As Integer = 0
                Do
                    Dim NUM As String = rs2.GetValue(I)
                    If NUM = "0.00" Then
                        NUM = " "
                    End If
                    dgw2.Item(1, I).Value = NUM
                    I += 1
                Loop While (I <= 11)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = rs2.GetValue(J + 12)
                    If NUM2 = "0.00" Then
                        NUM2 = " "
                    End If
                    dgw2.Item(2, J).Value = NUM2
                    J += 1
                Loop While (J <= 11)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SALDOS_ACUMULADO1()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_SALDOS_ESTADO_CTA_ACUMULADO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                Dim I As Integer = 0
                Do
                    Dim NUM As String = rs2.GetValue(I)
                    If NUM = "0.00" Then
                        NUM = " "
                    End If
                    dgw2.Item(4, I).Value = NUM
                    I += 1
                Loop While (I <= 13)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = rs2.GetValue(J + 14)
                    If NUM2 = "0.00" Then
                        NUM2 = " "
                    End If
                    dgw2.Item(5, J).Value = NUM2
                    J += 1
                Loop While (J <= 13)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub HALLAR_SALDOS1()
        Dim I As Integer = 0
        Do
            Dim UNO As String = dgw2.Item(1, I).Value
            Dim DOS As String = dgw2.Item(2, I).Value
            'Dim CUATRO As String = (dgw2.Item(4, I).Value)
            'Dim CINCO As String = (dgw2.Item(5, I).Value)
            If UNO = " " Then
                UNO = Decimal.Parse("0.00")
            Else
                UNO = dgw2.Item(1, I).Value
            End If
            If DOS = " " Then
                DOS = Decimal.Parse("0.00")
            Else
                DOS = dgw2.Item(2, I).Value
            End If
            'If (CUATRO = " ") Then
            '    CUATRO = (Decimal.Parse("0.00"))
            'Else
            '    CUATRO = (dgw2.Item(4, I).Value)
            'End If
            'If (CINCO = " ") Then
            '    CINCO = (Decimal.Parse("0.00"))
            'Else
            '    CINCO = (dgw2.Item(5, I).Value)
            'End If
            'Dim SALDO_MES As Decimal = Decimal.Subtract(Decimal.Parse(UNO), Decimal.Parse(DOS))
            'Dim SALDO_ACUM As Decimal = Decimal.Subtract(Decimal.Parse(CUATRO), Decimal.Parse(CINCO))
            'If (Convert.ToDouble(SALDO_MES) = 0) Then
            '    dgw2.Item(3, I).Value = (" ")
            'Else
            '    dgw2.Item(3, I).Value = (SALDO_MES)
            'End If
            'If (Convert.ToDouble(SALDO_ACUM) = 0) Then
            '    dgw2.Item(6, I).Value = (" ")
            'Else
            '    dgw2.Item(6, I).Value = (SALDO_ACUM)
            'End If
            I += 1
        Loop While (I <= 11)
    End Sub
    Sub BANCO_CONCILIADAS()
        DGW_CONC.Rows.Clear()
        Try
            Dim CMD1 As New SqlCommand("CONSULTA_I_BANCO_CONCILIADAS", con)
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
            CMD1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes_con.Text)
            CMD1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            con.Open()
            CMD1.ExecuteNonQuery()
            Dim RS1 As SqlDataReader = CMD1.ExecuteReader
            Do While RS1.Read
                DGW_CONC.Rows.Add(RS1.GetValue(0), RS1.GetValue(1), RS1.GetValue(2), RS1.GetValue(3), RS1.GetValue(4), RS1.GetValue(5), RS1.GetValue(6), RS1.GetValue(7), RS1.GetValue(8), RS1.GetValue(9), RS1.GetValue(10), RS1.GetValue(11), RS1.GetValue(12), RS1.GetValue(13))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_conciliacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_conciliacion.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl2.SelectedTab = TabPage6
        cbo_mes_con.Text = (obj.DESC_MES(dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString))
        cbo_año1.Text = AÑO
        Label10.Text = Label6.Text
        BANCO_CONCILIADAS()
    End Sub
    Private Sub cbo_mes_con_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes_con.SelectedIndexChanged
        If cbo_mes_con.SelectedIndex <> -1 And cbo_año1.SelectedIndex <> -1 Then
            BANCO_CONCILIADAS()
        Else
        End If
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click, btn_cancelar2.Click, btn_cancelar3.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub btn_saldos_cont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_saldos_cont.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl1.SelectedTab = TabPage3
        TabControl3.SelectedTab = TabPage2
        dgw3.Rows.Clear()
        Label11.Text = " Banco : " & " " & (dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString) & " " & (dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString)
        MESES2()
        CARGAR_SALDOS_MES2()
        'CARGAR_SALDOS_ACUMULADO2()
        HALLAR_SALDOS2()
    End Sub
    Sub MESES2()
        'dgw3.Rows.Add("00")
        dgw3.Rows.Add("01")
        dgw3.Rows.Add("02")
        dgw3.Rows.Add("03")
        dgw3.Rows.Add("04")
        dgw3.Rows.Add("05")
        dgw3.Rows.Add("06")
        dgw3.Rows.Add("07")
        dgw3.Rows.Add("08")
        dgw3.Rows.Add("09")
        dgw3.Rows.Add("10")
        dgw3.Rows.Add("11")
        dgw3.Rows.Add("12")
        'dgw3.Rows.Add("13")
    End Sub
    Sub CARGAR_SALDOS_MES2()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_SALDOS_CONTABLE_CTA", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                Dim I As Integer = 0
                Do
                    Dim NUM As String = rs2.GetValue(I)
                    If NUM = "0.00" Then
                        NUM = " "
                    End If
                    dgw3.Item(1, I).Value = NUM
                    I += 1
                Loop While (I <= 11)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = rs2.GetValue(J + 12)
                    If NUM2 = "0.00" Then
                        NUM2 = " "
                    End If
                    dgw3.Item(2, J).Value = NUM2
                    J += 1
                Loop While (J <= 11)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SALDOS_ACUMULADO2()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_SALDOS_CONTABLE_CTA_ACUMULADO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                Dim I As Integer = 0
                Do
                    Dim NUM As String = rs2.GetValue(I)
                    If NUM = "0.00" Then
                        NUM = " "
                    End If
                    dgw3.Item(4, I).Value = NUM
                    I += 1
                Loop While (I <= 13)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = rs2.GetValue(J + 14)
                    If NUM2 = "0.00" Then
                        NUM2 = " "
                    End If
                    dgw3.Item(5, J).Value = NUM2
                    J += 1
                Loop While (J <= 13)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub HALLAR_SALDOS2()
        Dim I As Integer = 0
        Do
            Dim UNO As String = dgw3.Item(1, I).Value
            Dim DOS As String = dgw3.Item(2, I).Value
            'Dim CUATRO As String = (dgw3.Item(4, I).Value)
            'Dim CINCO As String = (dgw3.Item(5, I).Value)
            If UNO = " " Then
                UNO = Decimal.Parse("0.00")
            Else
                UNO = dgw3.Item(1, I).Value
            End If
            If DOS = " " Then
                DOS = Decimal.Parse("0.00")
            Else
                DOS = dgw3.Item(2, I).Value
            End If
            'If (CUATRO = " ") Then
            '    CUATRO = (Decimal.Parse("0.00"))
            'Else
            '    CUATRO = (dgw3.Item(4, I).Value)
            'End If
            'If (CINCO = " ") Then
            '    CINCO = (Decimal.Parse("0.00"))
            'Else
            '    CINCO = (dgw3.Item(5, I).Value)
            'End If
            Dim SALDO_MES As Decimal = Decimal.Subtract(Decimal.Parse(UNO), Decimal.Parse(DOS))
            'Dim SALDO_ACUM As Decimal = Decimal.Subtract(Decimal.Parse(CUATRO), Decimal.Parse(CINCO))
            If (Convert.ToDouble(SALDO_MES) = 0) Then
                dgw3.Item(3, I).Value = " "
            Else
                dgw3.Item(3, I).Value = SALDO_MES
            End If
            'If (Convert.ToDouble(SALDO_ACUM) = 0) Then
            '    dgw3.Item(6, I).Value = (" ")
            'Else
            '    dgw3.Item(6, I).Value = (SALDO_ACUM)
            'End If
            I += 1
        Loop While (I <= 11)
    End Sub
    Private Sub btn_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cuenta.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl3.SelectedTab = TabPage7
        cbo_mes_cta.Text = (obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString))
        cbo_año2.Text = AÑO
        Label12.Text = Label11.Text
        BANCO_TODOS()
    End Sub
    Sub BANCO_TODOS()
        dgw_ctas.Rows.Clear()
        Try
            Dim CMD1 As New SqlCommand("CONSULTA_I_BANCO_TODOS", con)
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            CMD1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes_cta.Text)
            CMD1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            con.Open()
            CMD1.ExecuteNonQuery()
            Dim RS1 As SqlDataReader = CMD1.ExecuteReader
            Do While RS1.Read
                dgw_ctas.Rows.Add(RS1.GetValue(0), RS1.GetValue(1), RS1.GetValue(2), RS1.GetValue(3), RS1.GetValue(4), RS1.GetValue(5), RS1.GetValue(6), RS1.GetValue(7), RS1.GetValue(8), RS1.GetValue(9), RS1.GetValue(10), RS1.GetValue(11), RS1.GetValue(12), RS1.GetValue(13))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_mes_cta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes_cta.SelectedIndexChanged
        If cbo_mes_cta.SelectedIndex <> -1 And cbo_año2.SelectedIndex <> -1 Then
            BANCO_TODOS()
        Else
        End If
    End Sub
    Private Sub btn_cpto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cpto.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl3.SelectedTab = TabPage8
        Label13.Text = Label11.Text
        cbo_mes_cpto.Text = obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString)
        cbo_año3.Text = AÑO
        T_BANCO()
    End Sub
    Sub T_BANCO()
        dgw_tbanco.Rows.Clear()
        Try
            Dim CMD1 As New SqlCommand("CONSULTA_T_BAN_CPTOS", con)
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            CMD1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes_cpto.Text)
            CMD1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            CMD1.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            con.Open()
            CMD1.ExecuteNonQuery()
            Dim RS1 As SqlDataReader = CMD1.ExecuteReader
            Do While RS1.Read
                dgw_tbanco.Rows.Add(RS1.GetValue(0), RS1.GetValue(1), RS1.GetValue(2), RS1.GetValue(3), RS1.GetValue(4), RS1.GetValue(5), RS1.GetValue(6), RS1.GetValue(7), RS1.GetValue(8), RS1.GetValue(9), RS1.GetValue(10), RS1.GetValue(11), RS1.GetValue(12), RS1.GetValue(13), RS1.GetValue(14), RS1.GetValue(15), RS1.GetValue(16), RS1.GetValue(17), RS1.GetValue(18), RS1.GetValue(19), RS1.GetValue(20), RS1.GetValue(21), RS1.GetValue(22), RS1.GetValue(23))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_mes_cpto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes_cpto.SelectedIndexChanged
        If cbo_mes_cpto.SelectedIndex <> -1 And cbo_año3.SelectedIndex <> -1 Then
            T_BANCO()
        Else
        End If
    End Sub
    Private Sub btn_cancelar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar4.Click, btn_cancelar5.Click
        TabControl3.SelectedTab = TabPage2
    End Sub
    Private Sub cbo_año1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año1.SelectedIndexChanged
        If cbo_mes_con.SelectedIndex <> -1 And cbo_año1.SelectedIndex <> -1 Then
            BANCO_CONCILIADAS()
        Else
        End If
    End Sub
    Private Sub cbo_año2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año2.SelectedIndexChanged
        If cbo_mes_cta.SelectedIndex <> -1 And cbo_año2.SelectedIndex <> -1 Then
            BANCO_TODOS()
        Else
        End If
    End Sub
    Private Sub cbo_año3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año3.SelectedIndexChanged
        If cbo_mes_cpto.SelectedIndex <> -1 And cbo_año3.SelectedIndex <> -1 Then
            T_BANCO()
        Else
        End If
    End Sub
End Class