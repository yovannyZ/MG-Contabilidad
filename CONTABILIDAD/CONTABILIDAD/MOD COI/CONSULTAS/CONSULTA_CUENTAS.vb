Imports System.Data.SqlClient
Public Class CONSULTA_CUENTAS
    Dim obj As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(47) = 0
        Close()
    End Sub
    Private Sub btn_consulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub

        End Try
        TabControl1.SelectedTab = (TabPage2)
        cbo_mes_ana.Text = (obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString))
        CARGAR_ANALISIS_DEFECTO()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim a As Integer
        a = Integer.Parse(dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString.Length)
        If a <> 8 Then
            MessageBox.Show("La Consulta Contable es solo a nivel de detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Button1.Focus()
        Else
            TabControl1.SelectedTab = (TabPage4)
            cbo_mes_con.Text = (obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString))
            CARGAR_CONTABLE()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = (TabPage1)
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Label1.Text = String.Format("Consulta de Saldos Cuenta: {0} - {1}", dgw2.Item(0, dgw2.CurrentRow.Index).Value, dgw2.Item(1, dgw2.CurrentRow.Index).Value)
        TabControl1.SelectedTab = (TabPage3)
        dgw3.Rows.Clear()
        MESES()
        CARGAR_SALDOS_MES()
        CARGAR_SALDOS_ACUMULADO()
        HALLAR_SALDOS()
    End Sub
    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        TabControl1.SelectedTab = (TabPage1)
    End Sub
    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        TabControl1.SelectedTab = (TabPage1)
    End Sub
    Sub CARGAR_ANALISIS()
        dgw_ana.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_ANALISIS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (obj.COD_MES(cbo_mes_ana.Text))
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_ana.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_ANALISIS_DEFECTO()
        dgw_ana.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_ANALISIS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = ((obj.COD_MES(cbo_mes_ana.Text)))
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_ana.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONTABLE()
        dgw_con.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = ((obj.COD_MES(cbo_mes_con.Text)))
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_con.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONTABLE2()
        dgw_con.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = ((obj.COD_MES(cbo_mes_con.Text)))
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_con.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SALDOS_ACUMULADO()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_SALDOS_DEBE_HABER_ACUMULADO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_CUENTA ", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            pro_02.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                'Dim VB$CG$t_i4$S0 As Integer
                Dim I As Integer = 0
                Do
                    Dim NUM As String = (rs2.GetValue(I))
                    If (NUM = "0.00") Then
                        NUM = " "
                    End If
                    dgw3.Item(4, I).Value = (NUM)
                    I += 1
                    'VB$CG$t_i4$S0 = 13
                Loop While (I <= 13)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = (rs2.GetValue((J + 14)))
                    If (NUM2 = "0.00") Then
                        NUM2 = " "
                    End If
                    dgw3.Item(5, J).Value = (NUM2)
                    J += 1
                    'VB$CG$t_i4$S0 = 13
                Loop While (J <= 13)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)

        End Try
    End Sub
    Sub CARGAR_SALDOS_MES()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_SALDOS_DEBE_HABER_MES", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_CUENTA ", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            pro_02.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                'Dim VB$CG$t_i4$S0 As Integer
                Dim I As Integer = 0
                Do
                    Dim NUM As String = (rs2.GetValue(I))
                    If (NUM = "0.00") Then
                        NUM = " "
                    End If
                    dgw3.Item(1, I).Value = (NUM)
                    I += 1
                    'VB$CG$t_i4$S0 = 13
                Loop While (I <= 13)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = (rs2.GetValue((J + 14)))
                    If (NUM2 = "0.00") Then
                        NUM2 = " "
                    End If
                    dgw3.Item(2, J).Value = (NUM2)
                    J += 1
                    'VB$CG$t_i4$S0 = 13
                Loop While (J <= 13)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_mes_ana_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_ana.SelectedIndexChanged
        CARGAR_CONTABLE2()
    End Sub
    Private Sub cbo_mes_con_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_con.SelectedIndexChanged
        CARGAR_CONTABLE2()
        dgw4.DataSource = Nothing
    End Sub
    Sub CUENTAS_NIVEL_1()
        dgw1.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("DGW_CUENTA_NIVEL1", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw1.Rows.Add(rs2.GetValue(0), rs2.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            'MsgBox(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CUENTAS_TODOS_NIVELES()
        dgw2.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("CONSULTA_CUENTAS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@NIVEL", SqlDbType.Char).Value = (dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString)
            pro_02.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw2.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_con_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw_con.CellEnter
        Try
            Dim i As Integer = dgw_con.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw_con.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            t_con()
        End If
    End Sub
    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub

        End Try
        If ((dgw1.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            CUENTAS_TODOS_NIVELES()
        End If
    End Sub
    Sub HALLAR_SALDOS()
        'Dim VB$CG$t_i4$S0 As Integer
        Dim I As Integer = 0
        Do
            Dim UNO As String = (dgw3.Item(1, I).Value)
            Dim DOS As String = (dgw3.Item(2, I).Value)
            Dim CUATRO As String = (dgw3.Item(4, I).Value)
            Dim CINCO As String = (dgw3.Item(5, I).Value)
            If (UNO = " ") Then
                UNO = (Decimal.Parse("0.00"))
            Else
                UNO = (dgw3.Item(1, I).Value)
            End If
            If (DOS = " ") Then
                DOS = (Decimal.Parse("0.00"))
            Else
                DOS = (dgw3.Item(2, I).Value)
            End If
            If (CUATRO = " ") Then
                CUATRO = (Decimal.Parse("0.00"))
            Else
                CUATRO = (dgw3.Item(4, I).Value)
            End If
            If (CINCO = " ") Then
                CINCO = (Decimal.Parse("0.00"))
            Else
                CINCO = (dgw3.Item(5, I).Value)
            End If
            Dim SALDO_MES As Decimal = Decimal.Subtract(Decimal.Parse(UNO), Decimal.Parse(DOS))
            Dim SALDO_ACUM As Decimal = Decimal.Subtract(Decimal.Parse(CUATRO), Decimal.Parse(CINCO))
            If (Convert.ToDouble(SALDO_MES) = 0) Then
                dgw3.Item(3, I).Value = (" ")
            Else
                dgw3.Item(3, I).Value = (SALDO_MES)
            End If
            If (Convert.ToDouble(SALDO_ACUM) = 0) Then
                dgw3.Item(6, I).Value = (" ")
            Else
                dgw3.Item(6, I).Value = (SALDO_ACUM)
            End If
            I += 1
            'VB$CG$t_i4$S0 = 13
        Loop While (I <= 13)
    End Sub
    Sub MESES()
        dgw3.Rows.Add("00")
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
        dgw3.Rows.Add("13")
    End Sub
    Sub t_con()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_TCON_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = ((obj.COD_MES(cbo_mes_con.Text)))
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = (dgw_con.Item(16, dgw_con.CurrentRow.Index).Value.ToString)
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = (dgw_con.Item(17, dgw_con.CurrentRow.Index).Value.ToString)
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = (dgw_con.Item(18, dgw_con.CurrentRow.Index).Value.ToString)
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw4.DataSource = (DT)
            dgw4.Columns.Item(0).Width = (60)
            dgw4.Columns.Item(1).Width = (200)
            dgw4.Columns.Item(2).Width = (70)
            dgw4.Columns.Item(3).Width = (70)
            dgw4.Columns.Item(4).Width = (70)
            dgw4.Columns.Item(5).Width = (70)
            dgw4.Columns.Item(6).Width = (35)
            dgw4.Columns.Item(7).Width = (60)
            dgw4.Columns.Item(8).Width = (60)
            dgw4.Columns.Item(9).Width = (80)
            dgw4.Columns.Item(10).Width = (70)
            dgw4.Columns.Item(11).Width = (&H37)
            dgw4.Columns.Item(12).Width = (&H37)
            dgw4.Columns.Item(13).Width = (&H2D)
            dgw4.Columns.Item(14).Width = (&H37)
            dgw4.Columns.Item(15).Width = (&H37)
            dgw4.Columns.Item(16).Width = (&H37)
            dgw4.Columns.Item(17).Width = (&H37)
            dgw4.Columns.Item(2).DefaultCellStyle.Alignment = (&H40)
            dgw4.Columns.Item(3).DefaultCellStyle.Alignment = (&H40)
            dgw4.Columns.Item(4).DefaultCellStyle.Alignment = (&H40)
            dgw4.Columns.Item(5).DefaultCellStyle.Alignment = (&H40)
            dgw4.Columns.Item(7).DefaultCellStyle.Alignment = (&H40)
            dgw4.Columns.Item(17).DefaultCellStyle.Alignment = (32)
            dgw4.Columns.Item(6).DefaultCellStyle.Alignment = (32)
            dgw4.Columns.Item(8).DefaultCellStyle.Alignment = (32)
            dgw4.Columns.Item(2).DefaultCellStyle.Format = ("N2")
            dgw4.Columns.Item(3).DefaultCellStyle.Format = ("N2")
            dgw4.Columns.Item(4).DefaultCellStyle.Format = ("N2")
            dgw4.Columns.Item(5).DefaultCellStyle.Format = ("N2")
            dgw4.Columns.Item(10).DefaultCellStyle.Format = ("d")
            dgw4.Columns.Item(18).Visible = (False)
            dgw4.Columns.Item(19).Visible = (False)
            dgw4.Columns.Item(20).Width = (180)
        Catch ex As Exception
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_CUENTAS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CUENTAS_NIVEL_1()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw4.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_ana.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_con.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
    End Sub
End Class