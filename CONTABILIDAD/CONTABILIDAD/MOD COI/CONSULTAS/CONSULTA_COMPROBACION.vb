Imports System.Data.SqlClient
Public Class CONSULTA_COMPROBACION
    Dim obj As New Class1
    Dim COUNT_MES As Integer = 0
    Private TXT_MOV_DEBE As String
    Private TXT_MOV_HABER As String
    Private TXT_SALDO_DEBE As String
    Private TXT_SALDO_HABER As String
    Private TXT_SELECT As String
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(158) = main(0)
        Me.Close()
    End Sub
    Private Sub btn_consulta_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub

        End Try

        'TabControl1.SelectedTab = (TabPage2)
        'cbo_mes_ana.Text = (obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString))
        CARGAR_ANALISIS_DEFECTO()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim a As Integer
        a = Integer.Parse(dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString.Length)
        If a <> 8 Then
            MessageBox.Show("La Consulta Contable es solo a nivel de detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Button1.Focus()
        Else
            TabControl1.SelectedTab = (TabPage4)
            'cbo_mes_con.Text = (obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString))
            CARGAR_CONTABLE()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = (TabPage1)
        dgw_con.Rows.Clear()
        dgw4.DataSource = Nothing
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btm_detalle.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim a As Integer
        a = Integer.Parse(dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString.Length)
        If a <> 8 Then
            MessageBox.Show("La Consulta Contable es solo a nivel de detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Button1.Focus()
        Else
            TabControl1.SelectedTab = (TabPage4)
            cbo_mes_con.Text = cboMes1.Text '(obj.DESC_MES(dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString))
            CARGAR_CONTABLE()
            lblcuenta.Text = "Cuenta: " & (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            lbldesc.Text = "Descripcion: " & (dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString)
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
        TabControl1.SelectedTab = (TabPage1)
    End Sub
    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
        TabControl1.SelectedTab = (TabPage1)
    End Sub
    Sub CARGAR_ANALISIS()
        'dgw_ana.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_ANALISIS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            'pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (obj.COD_MES(cbo_mes_ana.Text))
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                'dgw_ana.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_ANALISIS_DEFECTO()
        'dgw_ana.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_ANALISIS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            'pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = ((obj.COD_MES(cbo_mes_ana.Text)))
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                'dgw_ana.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONTABLE()
        COUNT_MES = 0
        dgw_con.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE_MES", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES_INI", SqlDbType.Char).Value = ((obj.COD_MES(cboMes1.Text)))
            pro_02.Parameters.Add("@FE_MES_FIN", SqlDbType.Char).Value = ((obj.COD_MES(cboMes1.Text)))
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
        'dgw4.Rows.Clear()
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
                    'dgw3.Item(4, I).Value = (NUM)
                    I += 1
                    'VB$CG$t_i4$S0 = 13
                Loop While (I <= 13)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = (rs2.GetValue((J + 14)))
                    If (NUM2 = "0.00") Then
                        NUM2 = " "
                    End If
                    'dgw3.Item(5, J).Value = (NUM2)
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
                    'dgw3.Item(1, I).Value = (NUM)
                    I += 1
                    'VB$CG$t_i4$S0 = 13
                Loop While (I <= 13)
                Dim J As Integer = 0
                Do
                    Dim NUM2 As String = (rs2.GetValue((J + 14)))
                    If (NUM2 = "0.00") Then
                        NUM2 = " "
                    End If
                    'dgw3.Item(2, J).Value = (NUM2)
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
    Private Sub cbo_mes_ana_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        CARGAR_CONTABLE2()
    End Sub
    Private Sub cbo_mes_con_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes_con.SelectedIndexChanged
        COUNT_MES = 1
        CARGAR_CONTABLE2()
        dgw4.DataSource = Nothing
        'dgw4.Rows.Clear()
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
            'JCON()
        Else
            t_con()
        End If
    End Sub
    Sub JCON()
        MessageBox.Show("NO PASO")
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
            'CUENTAS_TODOS_NIVELES()

            CREAR_SELECT_DEMAS_CUENTAS()
            CARGAR_DATASET_DEMAS_CUENTAS()
        End If
    End Sub
    Sub t_con()
        'dgw4.Rows.Clear()
        If COUNT_MES = 1 Then
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
                dgw4.Columns.Item(1).Width = (225)
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
                CMD.Dispose()
                ADAP.Dispose()
                'FORMATO_MONEDA 2-5
                'dgw4.Columns.Item(2).DefaultCellStyle.Format = ("C2")
                'dgw4.Columns.Item(3).DefaultCellStyle.Format = ("C2")
                'dgw4.Columns.Item(4).DefaultCellStyle.Format = ("C2")
                'dgw4.Columns.Item(5).DefaultCellStyle.Format = ("C2")
            Catch ex As Exception
                MsgBox(ex.Message)
                'MsgBox(ex.Message)
            End Try
        Else
            Try
                Dim CMD As New SqlCommand("MOSTRAR_TCON_CONSULTA_MES", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                CMD.Parameters.Add("@FE_MES_INI", SqlDbType.Char).Value = ((obj.COD_MES(cboMes1.Text)))
                CMD.Parameters.Add("@FE_MES_FIN", SqlDbType.Char).Value = ((obj.COD_MES(cboMes1.Text)))
                CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = (dgw_con.Item(16, dgw_con.CurrentRow.Index).Value.ToString)
                CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = (dgw_con.Item(17, dgw_con.CurrentRow.Index).Value.ToString)
                CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = (dgw_con.Item(18, dgw_con.CurrentRow.Index).Value.ToString)
                Dim ADAP As New SqlDataAdapter(CMD)
                Dim DT As New DataTable("SD")
                ADAP.Fill(DT)
                dgw4.DataSource = (DT)
                dgw4.Columns.Item(0).Width = (60)
                dgw4.Columns.Item(1).Width = (225)
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
                dgw4.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
                'FORMATO_MONEDA 2-5
                'dgw4.Columns.Item(2).DefaultCellStyle.Format = ("C2")
                'dgw4.Columns.Item(3).DefaultCellStyle.Format = ("C2")
                'dgw4.Columns.Item(4).DefaultCellStyle.Format = ("C2")
                'dgw4.Columns.Item(5).DefaultCellStyle.Format = ("C2")
            Catch ex As Exception
                MsgBox(ex.Message)
                'MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub CONSULTA_CUENTAS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_AÑO()
        'CUENTAS_NIVEL_1()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        'dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw4.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        'dgw_ana.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_con.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_AÑO.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btm_consulta.Click
        If cboMes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes.Focus() : Exit Sub
        If cboMes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes1.Focus() : Exit Sub
        If CBO_AÑO.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_AÑO.Focus() : Exit Sub
        dgw1.Rows.Clear()
        CREAR_SELECT()
        CARGAR_DATASET()
        'OFR.UBICAR_REPORTE()
        'OFR.CREAR_REPORTE(cboMes1.Text, dtp1.Value.Date, obj.HALLAR_NRO_DIGITOS(obj.COD_NIVEL(cbo_nivel.Text)))
        'OFR.ShowDialog()
    End Sub
    Sub CREAR_SELECT()
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
        Dim I2 As Integer = Integer.Parse(obj.COD_MES(cboMes.Text))
        If (I2 = 0) Then
            I2 = 1
        End If
        Dim CONT2 As Integer = Integer.Parse(obj.COD_MES(cboMes1.Text))
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
        TXT_SELECT = ("SELECT  A.COD_CUENTA, A.DESC_CUENTA,(" & TXT_SALDO_DEBE & "),(" & TXT_SALDO_HABER & "),(" & TXT_MOV_DEBE & "),(" & TXT_MOV_HABER & ") ,CASE WHEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )>(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") THEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )-(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") ELSE 0 END, CASE WHEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")>(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") THEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")-(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") ELSE 0 END ,(SELECT ISNULL((" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " ), 0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PERDIDAS, (SELECT ISNULL(( " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS GANANCIAS,CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)='2'")
    End Sub
    Sub CREAR_SELECT_DEMAS_CUENTAS()
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
        Dim I2 As Integer = Integer.Parse(obj.COD_MES(cboMes.Text))
        If (I2 = 0) Then
            I2 = 1
        End If
        Dim CONT2 As Integer = Integer.Parse(obj.COD_MES(cboMes1.Text))
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
        TXT_SELECT = ("SELECT  A.COD_CUENTA, A.DESC_CUENTA,(" & TXT_SALDO_DEBE & "),(" & TXT_SALDO_HABER & "),(" & TXT_MOV_DEBE & "),(" & TXT_MOV_HABER & ") ,CASE WHEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )>(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") THEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )-(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") ELSE 0 END, CASE WHEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")>(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") THEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")-(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") ELSE 0 END ,(SELECT ISNULL((" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " ), 0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PERDIDAS, (SELECT ISNULL(( " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS GANANCIAS,CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND SUBSTRING(A.COD_CUENTA,0,3)=@NIVEL  and A.COD_CUENTA<>@NIVEL")
    End Sub


    Sub CARGAR_DATASET_DEMAS_CUENTAS()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand(TXT_SELECT, con)
            PROG_01.UpdatedRowSource = UpdateRowSource.Both
            PROG_01.Parameters.Add("@NIVEL", SqlDbType.Char).Value = (dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString)
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            'nivel siempre sera cuentas
            'PROG_01.Parameters.Add("@NIVEL", SqlDbType.Char).Value = obj.HALLAR_NRO_DIGITOS(obj.COD_NIVEL(cbo_nivel.Text))
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
                If Rs3.GetValue(2) <> 0 Or Rs3.GetValue(3) <> 0 Or Rs3.GetValue(4) <> 0 Or Rs3.GetValue(5) <> 0 Or Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7) <> 0 Then 'Or (Decimal.Parse(colum8) <> 0) Or (Decimal.Parse(colum9) <> 0) Or (Decimal.Parse(colum10) <> 0) Or (Decimal.Parse(colum11) <> 0) Then
                    dgw2.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7)) ', Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)))
                    'OFR.DT_REP_COMPROBACION.DataTable1.Rows.Add(New Object() {(Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15))})
                End If
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_DATASET()
        Try
            Dim PROG_01 As New SqlCommand(TXT_SELECT, con)
            PROG_01.UpdatedRowSource = UpdateRowSource.Both
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            'nivel siempre sera cuentas
            'PROG_01.Parameters.Add("@NIVEL", SqlDbType.Char).Value = obj.HALLAR_NRO_DIGITOS(obj.COD_NIVEL(cbo_nivel.Text))
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
                    dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7)) ', Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)))
                    'OFR.DT_REP_COMPROBACION.DataTable1.Rows.Add(New Object() {(Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15))})
                End If
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dgw1.Rows.Clear()
        dgw2.Rows.Clear()
    End Sub
End Class