Imports System.Data.SqlClient
Public Class TRANSFERENCIA_BANCOS
    Dim boton, COD_AUX, STATUS_C, STATUS_B, COD_COMP, COD_MP, MON_CAMBIO, MON_DESTINO, MON_ORIGEN As String
    Dim obj As New Class1
    Private ValidarFicha As Boolean = True

    Private Sub TRANSFERENCIA_BANCOS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub TRANSFERENCIA_BANCOS_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub

 Private Sub TRANSFERENCIA_BANCOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub TRANSFERENCIA_BANCOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        DATAGRID()
        medios_pago()
        CBO_MONEDA00()
        CARGAR_BANCOS()
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
        btn_nuevo.Select()
    End Sub
    Private Sub btn_anular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_anular.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If dgw1.Item(16, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Conciliado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        ElseIf dgw1.Item(17, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Contabilizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim BAN0 As String
        BAN0 = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        If obj.VERIFICAR_CIERRE_BANCOS(BAN0, AÑO, MES) = True Then
            MessageBox.Show("No se puede anular el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim respuesta As String = (MessageBox.Show("Esta seguro de anular el comprobante ", "Anular Comprobante?", MessageBoxButtons.YesNo))
        If dgw1.Item(14, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El comprobante ya se encuentra anulado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If (respuesta) = 6 Then
                Dim saldo As Decimal = (dgw1.Item(7, dgw1.CurrentRow.Index).Value)
                If dgw1.Item(14, dgw1.CurrentRow.Index).Value = True Then
                    saldo = New Decimal
                End If
                Dim estado As String = "FALLO"
                Dim cod_mp00 As String = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
                Dim nro_mp00 As String = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
                Dim cod_ban00 As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
                Dim nro_comp00 As String = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
                Dim cod_comp00 As String = dgw1.Item(11, dgw1.CurrentRow.Index).Value.ToString
                Try
                    Dim PROG_01 As New SqlCommand("ANULAR_I_BAN_TRANS", con)
                    PROG_01.CommandType = (CommandType.StoredProcedure)
                    PROG_01.Parameters.Add("@cod_mp", SqlDbType.VarChar).Value = cod_mp00
                    PROG_01.Parameters.Add("@nro_mp", SqlDbType.VarChar).Value = nro_mp00
                    PROG_01.Parameters.Add("@cod_banco", SqlDbType.VarChar).Value = cod_ban00
                    PROG_01.Parameters.Add("@imp", SqlDbType.Decimal).Value = saldo
                    PROG_01.Parameters.Add("@nro_comp", SqlDbType.VarChar).Value = nro_comp00
                    PROG_01.Parameters.Add("@cod_comp", SqlDbType.VarChar).Value = cod_comp00
                    PROG_01.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                    PROG_01.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
                    con.Open()
                    estado = PROG_01.ExecuteScalar
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If (estado = "FALLO") Then
                    MessageBox.Show("Ocurrió un error.", "Intentelo otra vez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
            DATAGRID()
            CARGAR_BANCOS()
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If dgw1.Item(16, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Conciliado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        ElseIf dgw1.Item(17, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Contabilizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim BAN0 As String
        BAN0 = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        If obj.VERIFICAR_CIERRE_BANCOS(BAN0, AÑO, MES) = True Then
            MessageBox.Show("No se puede eliminar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MessageBox.Show("Esta seguro de borrar el Comprobante", "Borrar Comprobante?", MessageBoxButtons.YesNo)) = 6 Then
            Dim saldo As Decimal = dgw1.Item(7, dgw1.CurrentRow.Index).Value
            If dgw1.Item(14, dgw1.CurrentRow.Index).Value = True Then
                saldo = New Decimal
            End If
            Dim estado As String = "FALLO"
            Dim cod_mp00 As String = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            Dim nro_mp00 As String = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
            Dim cod_ban00 As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            Dim nro_comp00 As String = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
            Dim cod_comp00 As String = dgw1.Item(11, dgw1.CurrentRow.Index).Value.ToString
            Try
                Dim PROG_01 As New SqlCommand("ELIMINAR_I_BAN_TRANS", con)
                PROG_01.CommandType = (CommandType.StoredProcedure)
                PROG_01.Parameters.Add("@cod_mp", SqlDbType.VarChar).Value = cod_mp00
                PROG_01.Parameters.Add("@nro_mp", SqlDbType.VarChar).Value = nro_mp00
                PROG_01.Parameters.Add("@cod_banco", SqlDbType.VarChar).Value = cod_ban00
                PROG_01.Parameters.Add("@imp", SqlDbType.Decimal).Value = saldo
                PROG_01.Parameters.Add("@nro_comp", SqlDbType.VarChar).Value = nro_comp00
                PROG_01.Parameters.Add("@cod_comp", SqlDbType.VarChar).Value = cod_comp00
                PROG_01.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                PROG_01.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
                con.Open()
                estado = PROG_01.ExecuteScalar
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            If (estado = "FALLO") Then
                MessageBox.Show("Ocurrió un error.", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
        DATAGRID()
        CARGAR_BANCOS()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_cod_ban.Text = "" Then MessageBox.Show("Debe elegir el banco de Origen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        If Panel_ban1.Visible Then MessageBox.Show("Debe elegir el banco de Origen ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dgw_ban.Focus() : Exit Sub
        If txt_cod_ban2.Text = "" Then MessageBox.Show("Debe elegir el banco de Destino", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban2.Focus() : Exit Sub
        If Panel_ban2.Visible Then MessageBox.Show("Debe elegir el banco de Destino ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dgw_ban2.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("El Banco no tiene comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If cbo_mp.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mp.Focus() : Exit Sub
        If txt_nro_comp.Text = "" Then MessageBox.Show("El Comprobante no tiene Numeración", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Compare(Decimal.Parse(txt_cambio.Text), Decimal.Zero) = 0) Then MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cambio.Focus() : Exit Sub
        If (Decimal.Compare(Decimal.Parse(txt_imp_soles.Text), Decimal.Zero) = 0) Then MessageBox.Show("Debe ingresar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_imp_soles.Focus() : Exit Sub
        If obj.VERIFICAR_NRO_MP(COD_MP, txt_num_mp.Text, txt_cod_ban.Text) = False Then MessageBox.Show("La Numeración del Banco de Origen ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_num_mp.Focus() : Exit Sub
        If obj.VERIFICAR_NRO_MP(COD_MP, txt_num_mp.Text, txt_cod_ban2.Text) = False Then MessageBox.Show("La Numeración del Banco de Destino ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_num_mp.Focus() : Exit Sub
        If obj.VALIDAR_FECHA_COMP(dtp1.Value) = 0 Then dtp1.Focus() : Exit Sub
        If INSERTAR_TODO() = "EXITO" Then
            MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DATAGRID()
            btn_guardar.Enabled = False
        Else
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Button1.Enabled = False
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click

        boton = "NUEVO"
        ValidarFicha = False
        LIMPIAR_COMPROBANTE()
        TabControl1.SelectedTab = TabPage2
        txt_cod_ban.Focus()
        ValidarFicha = True
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(5) = 0
        Close()
    End Sub
    Sub CARGAR_BANCOS()
        Try
            dgw_ban.DataSource = obj.MOSTRAR_BANCO_COMP
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
            dgw_ban.Columns(2).Visible = False
            dgw_ban.Columns(3).Visible = False
            dgw_ban.Columns(0).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '--------------------------------------------------------
        Try
            dgw_ban2.DataSource = obj.MOSTRAR_BANCO_COMP
            dgw_ban2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
            dgw_ban2.Columns(2).Visible = False
            dgw_ban2.Columns(3).Visible = False
            dgw_ban2.Columns(0).Width = 50
            dgw_ban2.Columns(1).Width = 210
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_com.SelectedIndexChanged
        If (cbo_com.SelectedIndex <> -1) Then
            COD_COMP = cbo_com.SelectedValue.ToString
            If (COD_COMP <> "System.Data.DataRowView") Then
                COD_COMP = obj.COD_COMP(cbo_com.Text, COD_AUX)
                txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            End If
        End If
    End Sub
    Sub CBO_COMPROBANTE00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_com.DataSource = DT
        cbo_com.DisplayMember = DT.Columns.Item(0).ToString
        cbo_com.ValueMember = DT.Columns.Item(1).ToString
        cbo_com.SelectedIndex = -1
        If (cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub CBO_MONEDA00()
        Try
            Dim PROG_01 As New SqlCommand("cargar_moneda2", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_moneda.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub
    Private Sub cbo_mp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_mp.SelectedIndexChanged
        If ((cbo_mp.SelectedIndex <> -1) And (txt_cod_ban.Text.Trim <> "")) Then
            COD_MP = obj.COD_MP(cbo_mp.Text)
        End If
    End Sub
    Sub DATAGRID()
        Try
            Dim pro As New SqlCommand("MOSTRAR_I_BANCO_TRANS", con)
            pro.CommandType = (CommandType.StoredProcedure)
            pro.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw1.DataSource = (dt)
            dgw1.Columns(0).Visible = False
            dgw1.Columns(2).Visible = False
            dgw1.Columns(10).Visible = False
            dgw1.Columns(11).Visible = False
            dgw1.Columns(13).Visible = False
            dgw1.Columns(15).Visible = False
            dgw1.Columns(1).Width = 120
            dgw1.Columns(3).Width = 120
            dgw1.Columns(4).Width = 100
            dgw1.Columns(5).Width = &H2D
            dgw1.Columns(6).Width = 30
            dgw1.Columns(7).Width = 80
            dgw1.Columns(7).DefaultCellStyle.Alignment = &H400
            dgw1.Columns(8).Width = 30
            dgw1.Columns(9).Width = &H4B
            dgw1.Columns(9).DefaultCellStyle.Format = "d"
            dgw1.Columns(12).Width = 110
            dgw1.Columns(14).Width = 35
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            MON_ORIGEN = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            COD_AUX = dgw_ban.Item(3, dgw_ban.CurrentRow.Index).Value.ToString
            CBO_COMPROBANTE00()
            cbo_com.Text = obj.HALLAR_COMP_X_BANCO(txt_cod_ban.Text)
            cbo_moneda_origen.Text = obj.DESC_MONEDA(MON_ORIGEN)
            txt_saldo_origen.Text = obj.HALLAR_SALDO_BANCOS(txt_cod_ban.Text)
            If (txt_cod_ban.Text = txt_cod_ban2.Text) Then
                MessageBox.Show("No puede elegir el mismo banco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_ban.Clear()
                txt_desc_ban.Clear()
                cbo_moneda_origen.Clear()
                txt_saldo_origen.Clear()
                txt_cod_ban.Focus()
            Else
                If (cbo_mp.SelectedIndex = -1 Or txt_cod_ban.Text = "" Or txt_cod_ban2.Text = "") Then
                Else
                    COD_MP = obj.COD_MP(cbo_mp.SelectedItem)
                End If
                MON_CAMBIO = MON_ORIGEN
                cbo_moneda.Text = cbo_moneda_origen.Text
                Panel_ban1.Visible = False
                kl1.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_ban1.Visible = False
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
        End If
        If obj.VERIFICAR_CIERRE_BANCOS(txt_cod_ban.Text, AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub dgw_ban2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban2.Text = dgw_ban2.Item(0, dgw_ban2.CurrentRow.Index).Value.ToString
            txt_desc_ban2.Text = dgw_ban2.Item(1, dgw_ban2.CurrentRow.Index).Value.ToString
            MON_DESTINO = dgw_ban2.Item(2, dgw_ban2.CurrentRow.Index).Value.ToString
            cbo_moneda_destino.Text = obj.DESC_MONEDA(MON_DESTINO)
            txt_saldo_destino.Text = obj.HALLAR_SALDO_BANCOS(txt_cod_ban2.Text)
            If (txt_cod_ban.Text = txt_cod_ban2.Text) Then
                MessageBox.Show("No puede elegir el mismo banco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_ban2.Clear()
                txt_desc_ban2.Clear()
                cbo_moneda_destino.Clear()
                txt_saldo_destino.Clear()
                txt_cod_ban2.Focus()
            Else
                If ((cbo_mp.SelectedIndex = -1 Or txt_cod_ban.Text = "") Or (txt_cod_ban2.Text = "")) Then
                Else
                    COD_MP = obj.COD_MP(cbo_mp.SelectedItem)
                End If
                HALLAR_ESTADO2()
                Panel_ban2.Visible = False
                kl2.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_ban2.Visible = False
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
            txt_cod_ban2.Focus()
        End If
        If obj.VERIFICAR_CIERRE_BANCOS(txt_cod_ban2.Text, AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
            txt_cod_ban2.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub dtp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp1.LostFocus
        If (cbo_moneda.SelectedIndex <> -1) Then
            txt_cambio.Text = obj.SACAR_CAMBIO2(dtp1.Value.Year, dtp1.Value.ToString("MM"), dtp1.Value.ToString("dd"), "D")
        End If
    End Sub
    Sub HALLAR_ESTADO()
        STATUS_B = "0"
        STATUS_C = "0"
        Try
            Dim CMD As New SqlCommand("HALLAR_ESTADO_BANCOS", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                STATUS_B = Rs3.GetString(0)
                STATUS_C = Rs3.GetString(1)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If STATUS_C = "1" Then
            MessageBox.Show("El Banco elegido de Origen se encuentra Cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
        ElseIf (STATUS_B = "1") Then
            MessageBox.Show("El Banco elegido de Origen  se encuentra Bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
        End If
    End Sub
    Sub HALLAR_ESTADO2()
        STATUS_B = "0"
        STATUS_C = "0"
        Try
            Dim CMD As New SqlCommand("HALLAR_ESTADO_BANCOS", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban2.Text
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                STATUS_B = Rs3.GetString(0)
                STATUS_C = Rs3.GetString(1)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If (STATUS_C = "1") Then
            MessageBox.Show("El Banco elegido de Destino se encuentra Cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
        ElseIf (STATUS_B = "1") Then
            MessageBox.Show("El Banco elegido de Destino se encuentra Bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
        End If
    End Sub
    Function INSERTAR_TODO() As String
        'Dim IMP_DESTINO As Decimal
        Dim ESTADO As String = "FALLO"
        Dim IMP_ORIGEN As Decimal = Decimal.Parse(txt_imp_soles.Text)

        'If (MON_DESTINO = MON_ORIGEN) Then
        '    IMP_DESTINO = Decimal.Parse(txt_imp_soles.Text)

        'ElseIf (MON_ORIGEN = "S") Then
        '    IMP_DESTINO = Decimal.Divide(Decimal.Parse(txt_imp_soles.Text), Decimal.Parse(txt_cambio.Text))
        'Else
        '    IMP_DESTINO = Decimal.Multiply(Decimal.Parse(txt_imp_soles.Text), Decimal.Parse(txt_cambio.Text))
        'End If

        Try
            Dim prog As New SqlCommand("INSERTAR_I_BAN_TRANS", con)
            prog.CommandType = (CommandType.StoredProcedure)
            prog.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
            prog.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
            prog.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            prog.Parameters.Add("@COD_BANCO2", SqlDbType.VarChar).Value = txt_cod_ban2.Text
            prog.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = IMP_ORIGEN
            prog.Parameters.Add("@IMP_DOC2", SqlDbType.Decimal).Value = txt_imp_destino.Text
            prog.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = "H"
            prog.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = MON_ORIGEN
            prog.Parameters.Add("@COD_D_H2", SqlDbType.VarChar).Value = "D"
            prog.Parameters.Add("@COD_MONEDA2", SqlDbType.VarChar).Value = MON_DESTINO
            prog.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp1.Value.Date
            prog.Parameters.Add("@DESC_OPE", SqlDbType.VarChar).Value = txt_desc_ope.Text
            prog.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio.Text
            prog.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            prog.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP
            prog.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            prog.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            prog.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            prog.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            prog.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now
            con.Open()
            ESTADO = prog.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Return ESTADO
    End Function
    Sub LIMPIAR_COMPROBANTE()
        txt_nro_comp.Clear()
        '----------------------------------------
        txt_cod_ban.Clear()
        txt_desc_ban.Clear()
        cbo_mp.SelectedIndex = -1
        cbo_moneda_origen.Clear()
        txt_num_mp.Clear()
        txt_saldo_origen.Clear()
        txt_cod_ban2.Clear()
        txt_desc_ban2.Clear()
        cbo_moneda_destino.Clear()
        txt_saldo_destino.Clear()
        MON_CAMBIO = "no"
        dtp1.Value = FECHA_GRAL
        txt_cambio.Clear()
        cbo_moneda.SelectedIndex = -1
        cbo_com.SelectedIndex = -1
        txt_imp_soles.Clear()
        MON_ORIGEN = ""
        MON_DESTINO = ""
        txt_cambio.Enabled = True
        Button1.Enabled = True
        txt_cambio.Text = "0.0000"
        txt_imp_soles.Text = "0.00"
        btn_guardar.Enabled = True
        txt_ajuste.Clear()
        txt_imp_destino.Clear()
        txt_ajuste.Enabled = False
        CARGAR_BANCOS()
    End Sub
    Sub medios_pago()
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
            MsgBox(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub
    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.]" Then
            Return True
        End If
        If Asc(e.KeyChar) = 8 Then
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
    Private Sub txt_cambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_cambio.KeyPress
        e.Handled = Numero(e, txt_cambio)
    End Sub
    Private Sub txt_cambio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cambio.LostFocus
        Try
            txt_cambio.Text = obj.HACER_CAMBIO(txt_cambio.Text)
        Catch ex As Exception
            txt_cambio.Text = "0.0000"
        End Try
        '--------------------------------------------------------
        If (MON_DESTINO = MON_ORIGEN) Then
            txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_soles.Text)

        ElseIf (MON_ORIGEN = "S") Then
            txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_soles.Text / txt_cambio.Text)
        Else
            txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_soles.Text * txt_cambio.Text)
        End If

        'txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_soles.Text * txt_cambio.Text)
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban.RowCount - 1)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        MON_ORIGEN = dgw_ban.Item(2, i).Value.ToString
                        COD_AUX = dgw_ban.Item(3, i).Value.ToString
                        CBO_COMPROBANTE00()
                        cbo_com.Text = obj.HALLAR_COMP_X_BANCO(txt_cod_ban.Text)
                        cbo_moneda_origen.Text = obj.DESC_MONEDA(MON_ORIGEN)
                        txt_saldo_origen.Text = obj.HALLAR_SALDO_BANCOS(txt_cod_ban.Text)
                        If (txt_cod_ban.Text = txt_cod_ban2.Text) Then
                            MessageBox.Show("No puede elegir el mismo banco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_ban.Clear()
                            txt_desc_ban.Clear()
                            cbo_moneda_origen.Clear()
                            txt_saldo_origen.Clear()
                            txt_cod_ban.Focus()
                        Else
                            If (((cbo_mp.SelectedIndex = -1) Or (txt_cod_ban.Text = "")) Or (txt_cod_ban2.Text = "")) Then
                            Else
                                COD_MP = obj.COD_MP(cbo_mp.SelectedItem)
                            End If
                            MON_CAMBIO = MON_ORIGEN
                            cbo_moneda.Text = cbo_moneda_origen.Text
                            txt_cod_ban2.Focus()
                        End If
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Mid(dgw_ban.Item(0, i).Value, 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban1.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
        If obj.VERIFICAR_CIERRE_BANCOS(txt_cod_ban.Text, AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txt_cod_ban2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban2.LostFocus
        If (Strings.Trim(txt_cod_ban2.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban2.RowCount - 1)
                    If (txt_cod_ban2.Text.ToLower = dgw_ban2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban2.Text = dgw_ban2.Item(0, i).Value.ToString
                        txt_desc_ban2.Text = dgw_ban2.Item(1, i).Value.ToString
                        MON_DESTINO = dgw_ban2.Item(2, i).Value.ToString
                        cbo_moneda_destino.Text = obj.DESC_MONEDA(MON_DESTINO)
                        txt_saldo_destino.Text = obj.HALLAR_SALDO_BANCOS(txt_cod_ban2.Text)
                        If (txt_cod_ban.Text = txt_cod_ban2.Text) Then
                            MessageBox.Show("No puede elegir el mismo banco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_ban2.Clear()
                            txt_desc_ban2.Clear()
                            cbo_moneda_destino.Clear()
                            txt_saldo_destino.Clear()
                            txt_cod_ban2.Focus()
                        Else
                            If (((cbo_mp.SelectedIndex = -1) Or (txt_cod_ban.Text = "")) Or (txt_cod_ban2.Text = "")) Then
                            Else
                                COD_MP = obj.COD_MP(cbo_mp.SelectedItem)
                            End If
                            HALLAR_ESTADO2()
                            cbo_com.Focus()
                        End If
                        Return
                    End If
                    If (txt_cod_ban2.Text.ToLower = Mid(dgw_ban2.Item(0, i).Value, 1, Strings.Len(txt_cod_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban2.Visible = True
                dgw_ban2.Visible = True
                dgw_ban2.Focus()
            End If
        End If
        If obj.VERIFICAR_CIERRE_BANCOS(txt_cod_ban2.Text, AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
            txt_cod_ban2.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban.RowCount - 1)
                    If (txt_desc_ban.Text.ToLower = Mid(dgw_ban.Item(1, i).Value, 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban1.Visible = True
                Panel_ban1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban2.Text) <> "")) Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= dgw_ban2.RowCount - 1)
                    If (txt_desc_ban2.Text.ToLower = Mid((dgw_ban2.Item(1, i).Value), 1, Strings.Len(txt_desc_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = (dgw_ban2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_ban2.Visible = True
                Panel_ban2.Focus()
            End If
        End If

    End Sub
    Private Sub txt_imp_origen_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = Numero(e, (txt_imp_soles))
    End Sub
    Private Sub txt_imp_soles_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_imp_soles.LostFocus
        Try
            txt_imp_soles.Text = obj.HACER_DECIMAL(txt_imp_soles.Text)
        Catch ex As Exception
            txt_imp_soles.Text = "0.00"
        End Try
        If (MON_DESTINO = MON_ORIGEN) Then
            txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_soles.Text)

        ElseIf (MON_ORIGEN = "S") Then
            txt_imp_destino.Text = obj.HACER_DECIMAL(Math.Round((txt_imp_soles.Text / txt_cambio.Text), 2))
        Else
            txt_imp_destino.Text = obj.HACER_DECIMAL(Math.Round((txt_imp_soles.Text * txt_cambio.Text), 2))
        End If
        'txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_soles.Text * txt_cambio.Text)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_ajuste.Clear()
        txt_ajuste.Enabled = True
        txt_ajuste.Focus()
    End Sub

    Private Sub txt_ajuste_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ajuste.KeyDown
        'If (e.KeyData = Keys.Enter) Then
        '    Dim T As Integer
        '    T = txt_ajuste.Text.Length
        '    Dim VAR As String
        '    VAR = txt_ajuste.Text.Substring(0, 1)
        '    If VAR = "-" Then
        '        txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_destino.Text - txt_ajuste.Text.Substring(1, T - 1))
        '    Else
        '        txt_imp_destino.Text = obj.HACER_DECIMAL(txt_imp_destino.Text + txt_ajuste.Text)
        '    End If

        '    btn_guardar.Focus()
        '    txt_ajuste.Enabled = False
        'End If
    End Sub
    Private Sub txt_ajuste_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ajuste.LostFocus
        If txt_ajuste.Text = "" Then txt_ajuste.Text = "0.00"
        txt_ajuste.Text = obj.HACER_DECIMAL(txt_ajuste.Text)
        Dim T As Integer
        T = txt_ajuste.Text.Length
        Dim VAR As String
        VAR = txt_ajuste.Text.Substring(0, 1)
        If VAR = "-" Then
            'DEC = txt_imp_destino.Text - txt_ajuste.Text.Substring(1, T - 1)
            txt_imp_destino.Text = obj.HACER_DECIMAL(Decimal.Parse(txt_imp_destino.Text) - Decimal.Parse(txt_ajuste.Text.Substring(1, T - 1)))
            'txt_imp_destino.Text = obj.HACER_DECIMAL(DEC)
        Else
            txt_imp_destino.Text = obj.HACER_DECIMAL(Decimal.Parse(txt_imp_destino.Text) + Decimal.Parse(txt_ajuste.Text))
            'txt_imp_destino.Text = obj.HACER_DECIMAL(DEC)
        End If
        btn_guardar.Focus()
        txt_ajuste.Enabled = False
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub
End Class