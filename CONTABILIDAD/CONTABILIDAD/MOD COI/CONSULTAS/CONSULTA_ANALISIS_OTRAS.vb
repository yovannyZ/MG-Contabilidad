Imports System.Data.SqlClient
Public Class CONSULTA_ANALISIS_OTRAS
    Dim OBJ As New Class1
    Dim MES0 As String
    Dim FECHA_CONC As DateTime
    Private Sub btn_consulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta.Click
        Try
            Dim i As Integer = dgw_cuenta.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        dgw_kardex.Rows.Clear()
        cbo_mes.Text = OBJ.DESC_MES(MES)
        TabControl1.SelectedTab = TabPage2
        'CARGAR_PENDIENTE_DEFECTO()
        'CARGAR_PENDIENTE_DEFECTO_CONCILIADO()
        'CARGAR_MAESTRO()
        'CARGAR_MOV()
        'CARGAR_CONCILIADO()
        'OBTENER_SALDO_SOLES_DOLARES()
        'OBTENER_SALDO_CONTABLE_SOLES()
    End Sub
    'Sub OBTENER_SALDO_CONTABLE_SOLES()
    '    Dim fill As New DataGridViewRow
    '    Dim contfill As Integer = 0
    '    Dim D_H As String = ""
    '    Dim tdebe, thaber As Decimal
    '    tdebe = 0.0 : thaber = 0.0
    '    For Each fill In dgw_conciliado.Rows
    '        D_H = dgw_conciliado.Item(8, contfill).Value
    '        If D_H = "D" Then
    '            tdebe += dgw_conciliado.Item(6, contfill).Value
    '        Else
    '            thaber += dgw_conciliado.Item(6, contfill).Value
    '        End If
    '        contfill += 1
    '    Next
    '    txtcon_d.Text = Format(tdebe, "0,000.00")
    '    txtcon_h.Text = Format(thaber, "0,000.00")
    'End Sub
    Sub OBTENER_SALDO_SOLES_DOLARES()
        Dim fill As New DataGridViewRow
        Dim contfill As Integer = 0
        Dim mon As String = ""
        Dim D_H As String = ""
        Dim tsoles, tdolares As Decimal
        tsoles = 0.0 : tdolares = 0.0
        For Each fill In dgw_pendiente.Rows
            mon = dgw_pendiente.Item(4, contfill).Value
            D_H = dgw_pendiente.Item(8, contfill).Value
            If (mon = "S" Or mon = "A") Then
                If D_H = "H" Then
                    tsoles += dgw_pendiente.Item(6, contfill).Value
                Else
                    tsoles -= dgw_pendiente.Item(6, contfill).Value
                End If
            Else
                If D_H = "H" Then
                    tdolares += dgw_pendiente.Item(7, contfill).Value
                Else
                    tdolares -= dgw_pendiente.Item(7, contfill).Value
                End If
            End If
            contfill += 1
        Next
        txt_soles.Text = Format(tsoles, "0,000.00")
        txt_dolares.Text = Format(tdolares, "0,000.00")
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(84) = 0
        Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabPage1
        btn_consulta.Select()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = TabPage1
        btn_consulta.Select()
    End Sub
    'Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)Handles Button3.
    '    TabControl1.SelectedTab(TabPage1)
    '    btn_consulta.Select()
    'End Sub
    'Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    limpiar_kardex()
    '    txt_cod_per0.Focus()
    'End Sub
    Sub CARGAR_CONCILIADO()
        dgw_conciliado.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ANALISIS_CONCILIADO_OTROS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            pro_02.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per2.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_conciliado.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), (rs2.GetValue(17)), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Dim DEBES, DEBED, HABERS, HABERD As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_conciliado.RowCount - 1)

        I = 0
        Do While (I <= CONT)
            If (dgw_conciliado.Item(8, I).Value = "D") Then
                If (dgw_conciliado.Item(4, I).Value = "S") Then
                    DEBES = Decimal.Add(DEBES, dgw_conciliado.Item(6, I).Value)
                Else
                    DEBED = Decimal.Add(DEBED, dgw_conciliado.Item(7, I).Value)
                End If
            ElseIf (dgw_conciliado.Item(4, I).Value = "S") Then
                HABERS = Decimal.Add(HABERS, dgw_conciliado.Item(6, I).Value)
            Else
                HABERD = Decimal.Add(HABERD, dgw_conciliado.Item(7, I).Value)
            End If
            I += 1
        Loop
        txt_debe.Text = OBJ.HACER_DECIMAL(DEBES)
        txt_haber.Text = OBJ.HACER_DECIMAL(HABERS)
        txt_debed.Text = OBJ.HACER_DECIMAL(DEBED)
        txt_haberd.Text = OBJ.HACER_DECIMAL(HABERD)
    End Sub
    Sub CARGAR_KARDEX_CONCILIADO()
        dgw_kardex.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ANALISIS_KARDEX_CONCILIADO_OTROS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per0.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_kardex.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_KARDEX_NO_CONCILIADO()
        Dim MES6 As String = (OBJ.COD_MES(cbo_mes3.Text) + 1).ToString("00")
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ANALISIS_KARDEX_NO_CONCILIADO_OTROS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per0.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES6
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_kardex.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Dim DEBES, DEBED, HABERS, HABERD As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_kardex.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw_kardex.Item(8, I).Value = "D") Then
                If (dgw_kardex.Item(4, I).Value = "S") Then
                    DEBES = Decimal.Add(DEBES, dgw_kardex.Item(6, I).Value)
                Else
                    DEBED = Decimal.Add(DEBED, dgw_kardex.Item(7, I).Value)
                End If
            ElseIf (dgw_kardex.Item(4, I).Value = "S") Then
                HABERS = Decimal.Add(HABERS, dgw_kardex.Item(6, I).Value)
            Else
                HABERD = Decimal.Add(HABERD, dgw_kardex.Item(7, I).Value)
            End If
            I += 1
        Loop
        'txt_debe2.Text = OBJ.HACER_DECIMAL(DEBES)
        'txt_haber2.Text = OBJ.HACER_DECIMAL(HABERS)
        'txt_debed2.Text = OBJ.HACER_DECIMAL(DEBED)
        'txt_haberd2.Text = OBJ.HACER_DECIMAL(HABERD)
    End Sub
    'Sub CARGAR_MAESTRO()
    '    txt_maestro.Clear()
    '    Try
    '        Dim pro_02 As New SqlCommand("MOSTRAR_SALDO_MAESTRO", con)
    '        pro_02.CommandType = (CommandType.StoredProcedure)
    '        pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
    '        pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString)
    '        con.Open()
    '        pro_02.ExecuteNonQuery()
    '        Dim rs2 As SqlDataReader = pro_02.ExecuteReader
    '        Do While rs2.Read
    '            'Dim VB$t_ref$L0 As Object = OBJ.COD_MES(cbo_mes.Text)
    '            If (OBJ.COD_MES(cbo_mes.Text) = "00") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(0))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "01") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(1))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "02") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(2))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "03") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(3))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "04") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(4))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "05") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(5))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "06") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(6))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "07") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(7))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "08") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(8))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "09") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(9))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "10") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(10))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "11") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(11))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "12") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(12))
    '            ElseIf (OBJ.COD_MES(cbo_mes.Text) = "13") Then
    '                txt_maestro.Text = OBJ.HACER_DECIMAL(rs2.GetValue(13))
    '            End If
    '        Loop
    '        con.Close()
    '    Catch ex As Exception
    '        con.Close()
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Sub CARGAR_MAESTROS_CUENTAS()
        dgw_cuenta.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = ("O")
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_cuenta.Rows.Add(rs2.GetValue(0), rs2.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    'Sub CARGAR_MOV()
    '    txt_mov.Clear()
    '    Try
    '        Dim pro_02 As New SqlCommand("MOSTRAR_SALDO_MOV_OTROS", con)
    '        pro_02.CommandType = (CommandType.StoredProcedure)
    '        pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
    '        pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString)
    '        pro_02.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char).Value = "0"
    '        pro_02.Parameters.Add("@FECHA_CONC", SqlDbType.DateTime).Value = FECHA_CONC
    '        pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
    '        con.Open()
    '        pro_02.ExecuteNonQuery()
    '        Dim rs2 As SqlDataReader = pro_02.ExecuteReader
    '        Do While rs2.Read
    '            txt_mov.Text = OBJ.HACER_DECIMAL(rs2.GetValue(0))
    '        Loop
    '        con.Close()
    '    Catch ex As Exception
    '        con.Close()
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Sub CARGAR_PENDIENTE_DEFECTO()
        dgw_pendiente.Rows.Clear()
        Dim MES0 As String = (OBJ.COD_MES(cbo_mes.Text))
        prueba()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ANALISIS_TOTROS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            pro_02.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per1.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (MES0)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString)
            pro_02.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char).Value = "0"
            pro_02.Parameters.Add("@FECHA_CONC", SqlDbType.DateTime).Value = FECHA_CONC
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_pendiente.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub prueba()
        MES0 = (obj.COD_MES(cbo_mes.Text))

        If MES0 <> "00" Then
            FECHA_CONC = DateTime.Parse(("01/" & MES0 & "/" & cbo_año.Text))
        End If
        Dim CONT0 As String = MES0
        If ((((CONT0 = "01") Or (CONT0 = "03")) Or (CONT0 = "05")) Or (((CONT0 = "07") Or (CONT0 = "08")) Or (CONT0 = "10"))) Then
        End If
        If CONT0 = "12" Then
            FECHA_CONC = DateTime.Parse(("31/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
        Else
            If (((CONT0 = "04") OrElse (CONT0 = "06")) OrElse (CONT0 = "09")) Then
            End If
            If CONT0 = "11" Then
                FECHA_CONC = DateTime.Parse(("30/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
            ElseIf (CONT0 = "02") Then
                If ((Integer.Parse(cbo_año.Text) Mod 4) = 0) Then
                    FECHA_CONC = DateTime.Parse(("29/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                Else
                    FECHA_CONC = DateTime.Parse(("28/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                End If
            End If
        End If
        If MES0 = "00" Then
            FECHA_CONC = DateTime.Parse(("12/12/" & (cbo_año.Text - 1)))
        End If
    End Sub
    Sub CARGAR_PENDIENTE_DEFECTO_CONCILIADO()
        Dim MES1 As String = (((OBJ.COD_MES(cbo_mes.Text))) + 1).ToString("00")
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ANALISIS_TOTROS2", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (MES1)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_pendiente.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)), (rs2.GetValue(20)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        CARGAR_PENDIENTE_DEFECTO()
        'CARGAR_PENDIENTE_DEFECTO_CONCILIADO()
        'CARGAR_MAESTRO()
        'CARGAR_MOV()
        OBTENER_SALDO_SOLES_DOLARES()
    End Sub
    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes2.SelectedIndexChanged
        CARGAR_CONCILIADO()
        'OBTENER_SALDO_CONTABLE_SOLES()
    End Sub
    Private Sub cbo_mes3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes3.SelectedIndexChanged
        CARGAR_KARDEX_CONCILIADO()
        'CARGAR_KARDEX_NO_CONCILIADO()
        OBTENER_SALDO_KARDEX_SOLES_DOLARES()
        'OBTENER_SALDO_MOVIMIENTO()
    End Sub
    'Sub OBTENER_SALDO_MOVIMIENTO()
    '    Dim fill As New DataGridViewRow
    '    Dim contfill As Integer = 0
    '    Dim D_H As String = ""
    '    Dim total As Decimal
    '    total = 0.0
    '    For Each fill In dgw_kardex.Rows
    '        D_H = dgw_kardex.Item(8, contfill).Value
    '        If (D_H = "D") Then
    '            total += dgw_kardex.Item(6, contfill).Value
    '        Else
    '            total -= dgw_kardex.Item(6, contfill).Value
    '        End If
    '        contfill += 1
    '    Next
    '    txtmov_k.Text = Format(total, "0,000.00")
    'End Sub
    Sub OBTENER_SALDO_KARDEX_SOLES_DOLARES()
        Dim fill As New DataGridViewRow
        Dim contfill As Integer = 0
        Dim mon As String = ""
        Dim D_H As String = ""
        Dim tsoles, tdolares As Decimal
        tsoles = 0.0 : tdolares = 0.0
        For Each fill In dgw_kardex.Rows
            mon = dgw_kardex.Item(4, contfill).Value
            D_H = dgw_kardex.Item(8, contfill).Value
            If (mon = "S") Then
                If D_H = "D" Then
                    tsoles += dgw_kardex.Item(6, contfill).Value
                Else
                    tsoles -= dgw_kardex.Item(6, contfill).Value
                End If
                'tsoles += dgw_kardex.Item(6, contfill).Value
            ElseIf (mon = "D") Then
                If D_H = "D" Then
                    tdolares += dgw_kardex.Item(7, contfill).Value
                Else
                    tdolares -= dgw_kardex.Item(7, contfill).Value
                End If
                'tdolares += dgw_kardex.Item(7, contfill).Value
            End If
            contfill += 1
        Next
        txtsoles_k.Text = Format(tsoles, "0,000.00")
        txtdolar_k.Text = Format(tdolares, "0,000.00")
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            Panel_per.Visible = False
            Label17.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per.Visible = False
            txt_cod_per0.Focus()
            txt_cod_per0.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per0.Focus()
        End If
    End Sub
    Sub DGW_PERSONAS()
        Try
            dgw_per.DataSource = (OBJ.MOSTRAR_PERSONAS_COBRAR)
            dgw_per.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_per.Columns.Item(0).Width = (50) : dgw_per.Columns.Item(1).Width = (&HEB)
            dgw_per1.DataSource = OBJ.MOSTRAR_PERSONAS_COBRAR
            dgw_per1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per1.Columns.Item(0).Width = 50
            dgw_per1.Columns.Item(1).Width = &HEB
            dgw_per2.DataSource = OBJ.MOSTRAR_PERSONAS_COBRAR
            dgw_per2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per2.Columns.Item(0).Width = 50
            dgw_per2.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrió un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Sub limpiar_kardex()
        txt_cod_per0.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        dgw_kardex.Rows.Clear()
    End Sub
    Sub limpiar_pendiente()
        'txt_mov.Clear()
        'txt_maestro.Clear()
        cbo_mes.SelectedIndex = -1
    End Sub
    Private Sub txt_cod_per0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per0.LostFocus
        If (Strings.Trim(txt_cod_per0.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_cod_per0.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per0.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        Label17.Focus()
                        Return
                    End If
                    If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_consulta.Select()
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        limpiar_kardex()
        txt_cod_per0.Focus()
    End Sub
    Private Sub CONSULTA_ANALISIS_OTRAS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(&H56) = 0
    End Sub
    Private Sub CONSULTA_ANALISIS_OTRAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        cbo_año2.Items.Clear()
        cbo_año3.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_año2.Items.Add(Rs3.GetString(0))
                cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub CONSULTA_ANALISIS_OTRAS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_año2.Text = AÑO
        cbo_año3.Text = AÑO
        dgw_pendiente.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_kardex.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_conciliado.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_MAESTROS_CUENTAS()
        DGW_PERSONAS()
        cbo_mes.Text = OBJ.DESC_MES(MES)
        cbo_mes2.Text = OBJ.DESC_MES(MES)
        cbo_mes3.Text = OBJ.DESC_MES(MES)
    End Sub
    Private Sub txt_cod_per1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per1.LostFocus
        If (Strings.Trim(txt_cod_per1.Text) <> "") Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_per1.Text.ToLower = dgw_per1.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per1.Text = dgw_per1.Item(0, i).Value.ToString
                        txt_desc_per1.Text = dgw_per1.Item(1, i).Value.ToString
                        txt_doc_per1.Text = dgw_per1.Item(2, i).Value.ToString
                        Label15.Focus()
                        Return
                    End If
                    If (txt_cod_per1.Text.ToLower = Strings.Mid((dgw_per1.Item(0, i).Value), 1, Strings.Len(txt_cod_per1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per1.CurrentCell = dgw_per1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per1.Text) <> "")) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_per1.Text.ToLower = Strings.Mid((dgw_per1.Item(1, i).Value), 1, Strings.Len(txt_desc_per1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per1.CurrentCell = dgw_per1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub

    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per1.Text) <> "")) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_doc_per1.Text.ToLower = Strings.Mid((dgw_per1.Item(2, i).Value), 1, Strings.Len(txt_doc_per1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per1.CurrentCell = dgw_per1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per1.Text = dgw_per1.Item(0, dgw_per1.CurrentRow.Index).Value.ToString
            txt_desc_per1.Text = dgw_per1.Item(1, dgw_per1.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = dgw_per1.Item(2, dgw_per1.CurrentRow.Index).Value.ToString
            panel1.Visible = False
            Label15.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel1.Visible = False
            txt_cod_per1.Focus()
            txt_cod_per1.Clear()
            txt_desc_per1.Clear()
            txt_doc_per1.Clear()
            txt_cod_per1.Focus()
        End If
    End Sub

    Private Sub txt_cod_per2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per2.LostFocus
        If (Strings.Trim(txt_cod_per2.Text) <> "") Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_per2.Text.ToLower = dgw_per2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per2.Text = dgw_per2.Item(0, i).Value.ToString
                        txt_desc_per2.Text = dgw_per2.Item(1, i).Value.ToString
                        txt_doc_per2.Text = dgw_per2.Item(2, i).Value.ToString
                        Label16.Focus()
                        Return
                    End If
                    If (txt_cod_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(0, i).Value), 1, Strings.Len(txt_cod_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per2.CurrentCell = dgw_per2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_per2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per2.Text) <> "")) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(1, i).Value), 1, Strings.Len(txt_desc_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per2.CurrentCell = dgw_per2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_doc_per2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per2.Text) <> "")) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_doc_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(2, i).Value), 1, Strings.Len(txt_doc_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per2.CurrentCell = dgw_per2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop

                Panel2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_per2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per2.Text = dgw_per2.Item(0, dgw_per2.CurrentRow.Index).Value.ToString
            txt_desc_per2.Text = dgw_per2.Item(1, dgw_per2.CurrentRow.Index).Value.ToString
            txt_doc_per2.Text = dgw_per2.Item(2, dgw_per2.CurrentRow.Index).Value.ToString
            Panel2.Visible = False
            Label16.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel2.Visible = False
            txt_cod_per2.Focus()
            txt_cod_per2.Clear()
            txt_desc_per2.Clear()
            txt_doc_per2.Clear()
            txt_cod_per2.Focus()
        End If
    End Sub
End Class