Imports System.Data.SqlClient
Public Class CONCILIACION_BANCOS
    Private COD_MONEDA As String
    Private COD_MP As String
    Private OBJ As New Class1

    Private Sub Bancos_Conciliaion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_aÑo", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Bancos_Conciliaion_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_mes.Text = MES
        CARGAR_AÑOS()
        cbo_año.Text = AÑO
        CARGAR_DGW_BANCOS()
        CBO_MONEDA00()
        CBO_MP00()
        txt_cambio.Text = "0.0000"
        dtp_mp.Value = FECHA_GRAL
        DGW_PTE.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_CONC.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_EXTRA.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        Panel1.Visible = False
        btn_nuevo.Select()
    End Sub
    Private Sub btn_con_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_con.Click
        If (Strings.Trim(txt_cod_ban.Text) = "") Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        Else
            Dim AÑO0, MES0 As String
            AÑO0 = DGW_PTE.Item(15, DGW_PTE.CurrentRow.Index).Value.ToString
            MES0 = DGW_PTE.Item(16, DGW_PTE.CurrentRow.Index).Value.ToString
            If OBJ.VERIFICAR_CIERRE_BANCOS(txt_cod_ban.Text, cbo_año.Text, cbo_mes.Text) = True Then
                MessageBox.Show("No se puede conciliar el Período : " & AÑO & " - " & cbo_mes.Text & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_PTE.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If DGW_PTE.Item(6, I).Value.ToString = "True" Then
                    Dim COD_MP00 As String = DGW_PTE.Item(0, I).Value.ToString
                    Dim NRO_MP00 As String = DGW_PTE.Item(2, I).Value.ToString
                    CONCILIAR(COD_MP00, NRO_MP00)
                End If
                I += 1
            Loop
            MOSTRAR_I_BANCO()
            MessageBox.Show("Los Documentos se conciliaron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = DGW_EXTRA.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Desea eliminar registro", "Esta seguro de :", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Dim IMP_DOC As New Decimal
            Dim cod_mp00 As String = DGW_EXTRA.Item(0, DGW_EXTRA.CurrentRow.Index).Value.ToString
            Dim nro_mp00 As String = DGW_EXTRA.Item(2, DGW_EXTRA.CurrentRow.Index).Value.ToString
            Dim D_H00 As String = DGW_EXTRA.Item(4, DGW_EXTRA.CurrentRow.Index).Value.ToString
            IMP_DOC = Decimal.Parse(DGW_EXTRA.Item(5, DGW_EXTRA.CurrentRow.Index).Value.ToString)
            Dim ESTADO As String = "FALLO"
            Try
                Dim PROG_01 As New SqlCommand("ELIMINAR_I_BANCO_EXTRA", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@cod_mp", SqlDbType.VarChar).Value = cod_mp00
                PROG_01.Parameters.Add("@nro_mp", SqlDbType.VarChar).Value = nro_mp00
                PROG_01.Parameters.Add("@cod_banco", SqlDbType.VarChar).Value = txt_cod_ban.Text
                PROG_01.Parameters.Add("@cod_D_H", SqlDbType.VarChar).Value = D_H00
                PROG_01.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = Decimal.Parse((IMP_DOC))
                con.Open()
                ESTADO = (PROG_01.ExecuteScalar)
                con.Close()
            Catch ex As Exception


                con.Close()
                MessageBox.Show(ex.Message)

            End Try
            If (ESTADO = "EXITO") Then
                MOSTRAR_EXTRAS()
            Else
                MessageBox.Show("Ocurrió un error ", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (Strings.Trim(txt_num_mp.Text) = "") Then
            MessageBox.Show("Debe insertar un Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_num_mp.Focus()
        ElseIf (Decimal.Compare(Decimal.Parse(txt_cambio.Text), Decimal.Zero) = 0) Then
            MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio.Focus()
        ElseIf (Decimal.Compare(Decimal.Parse(txt_saldo_soles.Text), Decimal.Zero) = 0) Then
            MessageBox.Show("Debe ingresar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_saldo_soles.Focus()
        ElseIf (CBO_DH.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir D/H", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_DH.Focus()
        Else
            If (dtp_mp.Value.ToString("MM") <> cbo_mes.Text Or dtp_mp.Value.Year <> cbo_año.Text) Then
                MessageBox.Show("La fecha debe ser del mes y año elegidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtp_mp.Focus()
            End If
            If OBJ.VERIFICAR_NRO_MP_BANCO(txt_cod_ban.Text, COD_MP, txt_num_mp.Text) Then
                If (INSERTAR_TODO() = "EXITO") Then
                    MOSTRAR_EXTRAS()
                Else
                    MessageBox.Show("Ocurrió un error ", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                LIMPIAR_EXT()
                cbo_mp.Focus()
            End If
        End If
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = DGW_EXTRA.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        LIMPIAR_EXT()
        CARGAR_EXTRA()
        cbo_mp.Enabled = False
        txt_num_mp.Enabled = False
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        Panel1.Visible = True
        txt_cambio.Focus()
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (Strings.Trim(txt_num_mp.Text) = "") Then
            MessageBox.Show("Debe insertar un Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_num_mp.Focus()
        ElseIf (Decimal.Compare(Decimal.Parse(txt_cambio.Text), Decimal.Zero) = 0) Then
            MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio.Focus()
        ElseIf (Decimal.Compare(Decimal.Parse(txt_saldo_soles.Text), Decimal.Zero) = 0) Then
            MessageBox.Show("Debe ingresar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_saldo_soles.Focus()
        ElseIf (CBO_DH.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir D/H", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_DH.Focus()
        Else
            If (dtp_mp.Value.ToString("MM") <> cbo_mes.Text Or dtp_mp.Value.Year <> cbo_año.Text) Then
                MessageBox.Show("La fecha debe ser del mes y año elegidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtp_mp.Focus()
            End If
            If (MODIFICAR_TODO() = "EXITO") Then
                MOSTRAR_EXTRAS()
            Else
                MessageBox.Show("Ocurrió un error ", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Panel1.Visible = False
            btn_nuevo.Focus()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        If (txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        Else
            LIMPIAR_EXT()
            btn_guardar.Visible = True
            btn_modificar2.Visible = False
            Panel1.Visible = True
            cbo_mp.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(6) = 0
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If (Strings.Trim(txt_cod_ban.Text) = "") Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        Else
            Dim AÑO0, MES0 As String
            AÑO0 = cbo_año.Text
            MES0 = cbo_mes.Text
            If OBJ.VERIFICAR_CIERRE_BANCOS(txt_cod_ban.Text, cbo_año.Text, cbo_mes.Text) = True Then
                MessageBox.Show("No se puede des-conciliar el Período : " & AÑO & " - " & cbo_mes.Text & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_CONC.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If DGW_CONC.Item(6, I).Value.ToString = "True" Then
                    Dim COD_MP00 As String = DGW_CONC.Item(0, I).Value.ToString
                    Dim NRO_MP00 As String = DGW_CONC.Item(2, I).Value.ToString
                    DESCONCILIAR(COD_MP00, NRO_MP00)
                End If
                I += 1
            Loop
            MOSTRAR_I_BANCO()
            MessageBox.Show("Los Documentos se Des - Conciliaron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub CARGAR_DGW_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS_COMPROBANTE", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.Columns.Item(2).Visible = False
            dgw_ban.Columns.Item(3).Visible = False
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H34
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_EXTRA()
        COD_MP = DGW_EXTRA.Item(0, DGW_EXTRA.CurrentRow.Index).Value.ToString
        cbo_mp.Text = DGW_EXTRA.Item(1, DGW_EXTRA.CurrentRow.Index).Value.ToString
        txt_num_mp.Text = DGW_EXTRA.Item(2, DGW_EXTRA.CurrentRow.Index).Value.ToString
        dtp_mp.Value = Date.Parse(DGW_EXTRA.Item(3, DGW_EXTRA.CurrentRow.Index).Value.ToString)
        CBO_DH.Text = DGW_EXTRA.Item(4, DGW_EXTRA.CurrentRow.Index).Value.ToString
        txt_saldo_soles.Text = DGW_EXTRA.Item(5, DGW_EXTRA.CurrentRow.Index).Value.ToString
        COD_MONEDA = DGW_EXTRA.Item(6, DGW_EXTRA.CurrentRow.Index).Value.ToString
        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
        txt_cambio.Text = DGW_EXTRA.Item(7, DGW_EXTRA.CurrentRow.Index).Value.ToString
        txt_desc_giro.Text = DGW_EXTRA.Item(11, DGW_EXTRA.CurrentRow.Index).Value.ToString
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If ((Strings.Trim(txt_cod_ban.Text) <> "") And (cbo_mes.SelectedIndex <> -1) And (cbo_año.SelectedIndex <> -1)) Then
            MOSTRAR_I_BANCO()
        End If
    End Sub
    Private Sub cbo_moneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda.SelectedIndexChanged
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Sub CBO_MONEDA00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT
        cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
    End Sub
    Private Sub cbo_mp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mp.SelectedIndexChanged
        If ((cbo_mp.SelectedIndex <> -1) And (txt_cod_ban.Text.Trim <> "")) Then
            COD_MP = OBJ.COD_MP(cbo_mp.Text)
            txt_num_mp.Text = OBJ.HALLAR_NRO_MP(COD_MP, txt_cod_ban.Text)
        End If
    End Sub
    Sub CBO_MP00()
        Try
            Dim PROG_01 As New SqlCommand("cbo_mp", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_mp.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub
    Sub CONCILIAR(ByVal COD_MP As String, ByVal NRO_MP As String)
        Dim FECHA_CONC As DateTime
        FECHA_CONC = FECHA_GRAL
        FECHA_CONC = Date.Parse("01/" & cbo_mes.Text & "/" & cbo_año.Text)
        Try
            Dim CMD As New SqlCommand("CONCILIAR_I_BANCO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = cbo_mes.Text
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            CMD.Parameters.Add("@NRO_MP", SqlDbType.Char).Value = NRO_MP
            CMD.Parameters.Add("@FECHA_CONC", SqlDbType.DateTime).Value = FECHA_CONC
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub
    Sub DESCONCILIAR(ByVal COD_MP As String, ByVal NRO_MP As String)
        Try
            Dim CMD As New SqlCommand("DESCONCILIAR_I_BANCO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            CMD.Parameters.Add("@NRO_MP", SqlDbType.Char).Value = NRO_MP
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = (dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value)
            txt_desc_ban.Text = (dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value)
            COD_MONEDA = (dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value)
            cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
            panel_bancos.Visible = False
            If (cbo_mes.SelectedIndex <> -1) Then
                MOSTRAR_I_BANCO()
            End If
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            panel_bancos.Visible = False
            txt_cod_ban.Focus()
        End If
    End Sub
    Private Sub dtp_mp_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_mp.LostFocus
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Try
            Dim PROG_01 As New SqlCommand("INSERTAR_I_BANCO_EXTRA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@cod_mp", SqlDbType.VarChar).Value = COD_MP
            PROG_01.Parameters.Add("@nro_mp", SqlDbType.VarChar).Value = txt_num_mp.Text
            PROG_01.Parameters.Add("@cod_banco", SqlDbType.VarChar).Value = txt_cod_ban.Text
            PROG_01.Parameters.Add("@fecha_mp", SqlDbType.DateTime).Value = dtp_mp.Value
            PROG_01.Parameters.Add("@desc_ope", SqlDbType.VarChar).Value = txt_desc_giro.Text
            PROG_01.Parameters.Add("@imp_doc", SqlDbType.Decimal).Value = txt_saldo_soles.Text
            PROG_01.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = COD_MONEDA
            PROG_01.Parameters.Add("@tipo_cambio", SqlDbType.Decimal).Value = Double.Parse(txt_cambio.Text)
            PROG_01.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = " "
            PROG_01.Parameters.Add("@cod_comp", SqlDbType.VarChar).Value = " "
            PROG_01.Parameters.Add("@NRO_comp", SqlDbType.VarChar).Value = " "
            PROG_01.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            PROG_01.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            PROG_01.Parameters.Add("@cod_d_h", SqlDbType.VarChar).Value = CBO_DH.Text
            PROG_01.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = cbo_año.Text
            PROG_01.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = cbo_mes.Text
            con.Open()
            estado = (PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function
    Sub LIMPIAR_EXT()
        cbo_mp.SelectedIndex = -1
        txt_num_mp.Clear()
        txt_desc_giro.Clear()
        txt_saldo_soles.Text = "0.00"
        Dim DESC_MON0 As String = cbo_moneda.Text
        cbo_moneda.SelectedIndex = -1
        cbo_moneda.Text = DESC_MON0
        dtp_mp.Value = FECHA_GRAL
        cbo_mp.Enabled = True
        txt_num_mp.Enabled = True
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
    End Sub
    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Try
            Dim PROG_01 As New SqlCommand("MODIFICAR_I_BANCO_EXTRA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@cod_mp", SqlDbType.VarChar).Value = COD_MP
            PROG_01.Parameters.Add("@nro_mp", SqlDbType.VarChar).Value = txt_num_mp.Text
            PROG_01.Parameters.Add("@cod_banco", SqlDbType.VarChar).Value = txt_cod_ban.Text
            PROG_01.Parameters.Add("@fecha_mp", SqlDbType.DateTime).Value = dtp_mp.Value
            PROG_01.Parameters.Add("@desc_ope", SqlDbType.VarChar).Value = txt_desc_giro.Text
            PROG_01.Parameters.Add("@imp_doc", SqlDbType.Decimal).Value = txt_saldo_soles.Text
            PROG_01.Parameters.Add("@tipo_cambio", SqlDbType.Decimal).Value = Double.Parse(txt_cambio.Text)
            PROG_01.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            PROG_01.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            PROG_01.Parameters.Add("@cod_d_h", SqlDbType.VarChar).Value = CBO_DH.Text
            con.Open()
            estado = (PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            estado = "FALLO"
            MessageBox.Show(ex.Message)
        End Try
        Return estado
    End Function

    Sub MOSTRAR_EXTRAS()
        DGW_EXTRA.Rows.Clear()
        Try
            Dim CMD1 As New SqlCommand("MOSTRAR_I_BANCO_EXTRA", con)
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = cbo_mes.Text
            CMD1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            con.Open()
            CMD1.ExecuteNonQuery()
            Dim RS1 As SqlDataReader = CMD1.ExecuteReader
            Do While RS1.Read
                DGW_EXTRA.Rows.Add(RS1.GetValue(0), RS1.GetValue(1), RS1.GetValue(2), RS1.GetValue(3), RS1.GetValue(4), RS1.GetValue(5), RS1.GetValue(6), RS1.GetValue(7), RS1.GetValue(8), RS1.GetValue(9), RS1.GetValue(10), RS1.GetValue(11))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Sub MOSTRAR_I_BANCO()
        DGW_PTE.Rows.Clear()
        Try
            Dim CMD1 As New SqlCommand("MOSTRAR_I_BANCO_PENDIENTES", con)
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = cbo_mes.Text
            CMD1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            con.Open()
            CMD1.ExecuteNonQuery()
            Dim RS1 As SqlDataReader = CMD1.ExecuteReader
            Do While RS1.Read
                DGW_PTE.Rows.Add((RS1.GetValue(0)), (RS1.GetValue(1)), (RS1.GetValue(2)), (RS1.GetValue(3)), RS1.GetValue(4), RS1.GetValue(5), False, RS1.GetValue(6), RS1.GetValue(7), RS1.GetValue(8), RS1.GetValue(9), RS1.GetValue(10), RS1.GetValue(11), RS1.GetValue(12), RS1.GetValue(13), RS1.GetValue(14), RS1.GetValue(15))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        DGW_CONC.Rows.Clear()
        Try
            Dim CMD1 As New SqlCommand("MOSTRAR_I_BANCO_CONCILIADAS", con)
            CMD1.CommandType = CommandType.StoredProcedure
            CMD1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = cbo_mes.Text
            CMD1.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            con.Open()
            CMD1.ExecuteNonQuery()
            Dim RS1 As SqlDataReader = CMD1.ExecuteReader
            Do While RS1.Read
                DGW_CONC.Rows.Add(New Object() {(RS1.GetValue(0)), (RS1.GetValue(1)), (RS1.GetValue(2)), (RS1.GetValue(3)), (RS1.GetValue(4)), (RS1.GetValue(5)), False, (RS1.GetValue(6)), (RS1.GetValue(7)), (RS1.GetValue(8)), (RS1.GetValue(9)), (RS1.GetValue(10)), (RS1.GetValue(11)), (RS1.GetValue(12)), (RS1.GetValue(13))})
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        MOSTRAR_EXTRAS()
        HALLAR_TOTAL()
    End Sub

    Function Numero(ByVal e As KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.]" Then
            Return True
        End If
        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub txt_cambio_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio.KeyPress
        e.Handled = Numero(e, txt_cambio)
    End Sub

    Private Sub txt_cambio_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio.LostFocus
        Try
            txt_cambio.Text = (OBJ.HACER_CAMBIO(txt_cambio.Text))
        Catch ex As Exception


            txt_cambio.Text = "0.0000"

        End Try
    End Sub

    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        COD_MONEDA = dgw_ban.Item(2, i).Value.ToString
                        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
                        If (cbo_mes.SelectedIndex <> -1) Then
                            MOSTRAR_I_BANCO()
                        End If
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
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub txt_saldo_soles_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_saldo_soles.KeyPress
        e.Handled = Numero(e, txt_saldo_soles)
    End Sub

    Private Sub txt_saldo_soles_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_saldo_soles.LostFocus
        Try
            txt_saldo_soles.Text = (OBJ.HACER_DECIMAL(txt_saldo_soles.Text))
        Catch ex As Exception


            txt_saldo_soles.Text = "0.00"

        End Try
    End Sub
    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged
        If ((Strings.Trim(txt_cod_ban.Text) <> "") And (cbo_mes.SelectedIndex <> -1) And (cbo_año.SelectedIndex <> -1)) Then
            MOSTRAR_I_BANCO()
        End If
    End Sub

    Sub HALLAR_TOTAL()
        Dim DH As String
        Dim S As Decimal
        Dim I, CONT As Integer
        CONT = DGW_CONC.Rows.Count - 1
        S = 0
        For I = 0 To CONT
            DH = DGW_CONC.Item(4, I).Value
            If DH = "D" Then
                S = S + DGW_CONC.Item(5, I).Value
            Else
                S = S - DGW_CONC.Item(5, I).Value
            End If
        Next
        TextBox1.Text = OBJ.HACER_DECIMAL(S)
    End Sub
End Class