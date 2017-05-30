Imports System.Data.SqlClient
Public Class SALDO_BANCOS
    Dim boton As String
    Dim obj As New Class1

    Private Sub SALDO_BANCOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub SALDO_BANCOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        dgw_banco.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8, FontStyle.Bold))
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8, FontStyle.Bold))
        CARGAR_BANCOS()
        DATAGRID()
        datagrid_sa()
        cargar_año()
        btn_nuevo.Select()

    End Sub

    Private Sub btn_bloquear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_bloquear.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Exit Sub

        End Try
        Dim ESTADO0 As String = "0"
        Dim COD_CLASE As String = dgw1(0, dgw1.CurrentRow.Index).Value.ToString
        Dim RSPTA As String = (MessageBox.Show("Bloquear (Sí), Des-Bloquear (No) , Salir (Cancelar).", "Eliga la Opción", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
        If (RSPTA = 6 Or RSPTA = 7) Then
            If (RSPTA = 6) Then
                ESTADO0 = "1"
            End If
            Try
                Dim CMD As New SqlCommand("DES_BLOQUEAR_SALDO_BANCOS", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@fe_año", SqlDbType.Char).Value = (dgw1(2, dgw1.CurrentRow.Index).Value.ToString)
                CMD.Parameters.Add("@fe_mes", SqlDbType.Char).Value = (dgw1(3, dgw1.CurrentRow.Index).Value.ToString)
                CMD.Parameters.Add("@COD_banco", SqlDbType.Char).Value = (COD_CLASE)
                CMD.Parameters.Add("@ESTADO", SqlDbType.Char).Value = (ESTADO0)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'ProjectData.SetProjectError(exception2)
                'Dim ex As Exception = exception2
                con.Close()
                MsgBox(ex.Message)
                'MsgBox(ex.Message)

            End Try
        End If
        DATAGRID()
        btn_nuevo.Select()

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()

    End Sub

    Private Sub btn_cancelar_ini_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar_ini.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()

    End Sub

    Private Sub btn_cancelar_sa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar_sa.Click
        Panel2.Visible = False
        btn_nuevo.Select()

    End Sub

    Private Sub btn_cancelar_sa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar_sa2.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()

    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Exit Sub

        End Try
        If dgw1(7, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El período se encuentra cerrado", "No se puede eliminar", MessageBoxButtons.OK)
        Else
            Dim COD_CLASE As String = dgw1(0, dgw1.CurrentRow.Index).Value.ToString
            If VERIFICACION_ELIMINAR(dgw1.CurrentRow.Index) = False Then
                MessageBox.Show("Aún existe saldo en el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If ((MessageBox.Show(("ELIMINAR el Codigo de Banco" & COD_CLASE), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
                    Try
                        Dim CMD As New SqlCommand("ELIMINAR_SALDO_BANCOS", con)
                        CMD.CommandType = (CommandType.StoredProcedure)
                        CMD.Parameters.Add("@fe_año", SqlDbType.Char).Value = (dgw1(2, dgw1.CurrentRow.Index).Value.ToString)
                        CMD.Parameters.Add("@fe_mes", SqlDbType.Char).Value = (dgw1(3, dgw1.CurrentRow.Index).Value.ToString)
                        CMD.Parameters.Add("@COD_banco", SqlDbType.Char).Value = (COD_CLASE)
                        con.Open()
                        CMD.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'ProjectData.SetProjectError(exception2)
                        'Dim ex As Exception = exception2
                        con.Close()
                        MsgBox(ex.Message)
                        'MsgBox(ex.Message)

                    End Try
                End If
                DATAGRID()
                btn_nuevo.Select()
            End If
        End If

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod_banco.Text) = "") Then
            MessageBox.Show("Debe ingresar los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_banco.Focus()
        ElseIf (cbo_ban_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_ban_año.Focus()
        ElseIf (cbo_ban_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_ban_mes.Focus()
        Else
            Try
                txt_debe.Text = obj.HACER_DECIMAL(txt_debe.Text)
            Catch ex As Exception


                txt_debe.Text = "0.00"

            End Try
            Try
                txt_haber.Text = obj.HACER_DECIMAL(txt_haber.Text)
            Catch ex As Exception
                'ProjectData.SetProjectError(exception2)
                'Dim ex As Exception = exception2
                txt_haber.Text = "0.00"

            End Try
            If (txt_debe.Text > 0) And (txt_haber.Text > 0) Then
                MessageBox.Show("Debe ingresar solo un Importe : Debe o Haber", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_debe.Focus()
            ElseIf (CONTAR_REG(cbo_ban_año.Text, cbo_ban_mes.Text, txt_cod_banco.Text) > 0) Then
                MessageBox.Show("El Codigo de Banco ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_banco.Focus()
            Else
                Try
                    Dim pro03 As New SqlCommand("INSERTAR_SALDO_BANCOS", con)
                    pro03.CommandType = (CommandType.StoredProcedure)
                    pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (cbo_ban_año.Text)
                    pro03.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (cbo_ban_mes.Text)
                    pro03.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = (txt_cod_banco.Text)
                    pro03.Parameters.Add("@SALDO_BANCO_D", SqlDbType.Decimal).Value = (txt_debe.Text)
                    pro03.Parameters.Add("@SALDO_BANCO_H", SqlDbType.Decimal).Value = (txt_haber.Text)
                    con.Open()
                    pro03.ExecuteNonQuery()
                    MessageBox.Show(("El Saldo de Bancos: " & txt_cod_ban_ini.Text & " se ha guardado"), "Exito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    con.Close()
                    DATAGRID()
                    limpiar()
                    TabControl1.SelectedTab = (TabPage1)
                    btn_nuevo.Select()
                Catch ex As Exception
                    'ProjectData.SetProjectError(exception3)
                    'Dim ex As Exception = exception3
                    con.Close()
                    MessageBox.Show(ex.Message)
                    'MsgBox(ex.Message)
                    MsgBox("Error", MsgBoxStyle.OkCancel, "Vuelva a Intentarlo")

                End Try
            End If
        End If

    End Sub

    Private Sub btn_guardar_ini_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar_ini.Click
        If (Strings.Trim(txt_cod_ban_ini.Text) = "") Then
            MessageBox.Show("Debe ingresar los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban_ini.Focus()
        ElseIf (cbo_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        ElseIf (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (txt_debe_ini.Text.Trim = "") Then
            MessageBox.Show("Debe ingresar el Importe Debe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_debe_ini.Focus()
        ElseIf (txt_haber_ini.Text.Trim = "") Then
            MessageBox.Show("Debe ingresar el Importe Haber", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_haber_ini.Focus()
        Else
            Try
                Dim pro03 As New SqlCommand("INSERTAR_SALDO_BANCOS_INI", con)
                pro03.CommandType = (CommandType.StoredProcedure)
                pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
                pro03.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = cbo_mes.Text
                pro03.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban_ini.Text
                pro03.Parameters.Add("@SALDO_CONT_D", SqlDbType.Decimal).Value = txt_debe_ini.Text
                pro03.Parameters.Add("@SALDO_CONT_H", SqlDbType.Decimal).Value = txt_haber_ini.Text
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
                DATAGRID()
                TabControl1.SelectedTab = TabPage1
                btn_nuevo.Select()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
                MsgBox("Error:Vuelva a Intentarlo")
            Finally
                con.Close()
            End Try
        End If

    End Sub

    Private Sub btn_guardar_sa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar_sa.Click
        If ((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Then
            MessageBox.Show("Ingrese los Datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_SALDO_AC", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = (txt_cod.Text)
                CMD.Parameters.Add("@DESC_BANCO", SqlDbType.VarChar).Value = (txt_desc.Text)
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (txt_cod_cta.Text)
                CMD.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Decimal, 13).Value = (txt_saldo.Text)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Saldo Actual se modificó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Panel2.Visible = False
                btn_modificar_sa2.Focus()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            datagrid_sa()
        End If

    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Exit Sub

        End Try
        If dgw1(7, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El período se encuentra cerrado", "No se puede eliminar", MessageBoxButtons.OK)
        Else
            boton = "MODIFICAR"
            btn_guardar.Visible = False
            btn_modificar2.Visible = True
            limpiar()
            cargar_datos()
            txt_cod_banco.Enabled = False
            txt_desc_banco.Enabled = False
            cbo_ban_año.Enabled = False
            cbo_ban_mes.Enabled = False
            TabControl1.SelectedTab = (TabPage2)
            txt_debe.Focus()
        End If

    End Sub

    Private Sub btn_modificar_sa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar_sa2.Click
        Try
            Dim I As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub

        End Try
        limpiar()
        cargar_datos_sa()
        Panel2.Visible = True
        txt_saldo.Focus()

    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod_banco.Text) = "") Then
            MessageBox.Show("Debe ingresar los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_banco.Focus()
        ElseIf (cbo_ban_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_ban_año.Focus()
        ElseIf (cbo_ban_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_ban_mes.Focus()
        Else
            Try
                txt_debe.Text = obj.HACER_DECIMAL(txt_debe.Text)
            Catch ex As Exception
                txt_debe.Text = "0.00"
            End Try
            Try
                txt_haber.Text = obj.HACER_DECIMAL(txt_haber.Text)
            Catch ex As Exception
                txt_haber.Text = "0.00"
            End Try
            If (txt_debe.Text > 0 And txt_haber.Text > 0) Then
                MessageBox.Show("Debe ingresar solo un Importe : Debe o Haber", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_debe.Focus()
            Else
                Try
                    Dim pro03 As New SqlCommand("MODIFICAR_SALDO_BANCOS", con)
                    pro03.CommandType = (CommandType.StoredProcedure)
                    pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (cbo_ban_año.Text)
                    pro03.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (cbo_ban_mes.Text)
                    pro03.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = (txt_cod_banco.Text)
                    pro03.Parameters.Add("@SALDO_BANCO_D", SqlDbType.Decimal, 13).Value = (txt_debe.Text)
                    pro03.Parameters.Add("@SALDO_BANCO_H", SqlDbType.Decimal, 13).Value = (txt_haber.Text)
                    con.Open()
                    pro03.ExecuteNonQuery()
                    con.Close()
                    DATAGRID()
                Catch ex As Exception
                    'ProjectData.SetProjectError(exception3)
                    'Dim ex As Exception = exception3
                    con.Close()
                    MessageBox.Show(ex.Message)

                End Try
                TabControl1.SelectedTab = (TabPage1)
                btn_nuevo.Select()
            End If
        End If

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        limpiar()
        TabControl1.SelectedTab = (TabPage2)
        txt_cod_banco.Focus()

    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(3) = 0
        Close()

    End Sub


    Sub cargar_año()
        Try
            Dim pro03 As New SqlCommand("mostrar_año", con)
            pro03.CommandType = (CommandType.StoredProcedure)
            pro03.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "BCO"
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_ban_año.Items.Add(Rs3.GetString(0))
            End While
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub

    Sub CARGAR_BANCOS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_DGW_SALDO_BANCOS", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("BANCOS")
            ADAP.Fill(DT)
            dgw_banco.DataSource = (DT)
            dgw_banco.Columns(2).Visible = (False)
            dgw_banco.Columns(3).Visible = (False)
            dgw_banco.Columns(4).Visible = (False)
            dgw_banco.Columns(5).Visible = (False)
            dgw_banco.Columns(6).Visible = (False)
            dgw_banco.Columns(7).Visible = (False)
            dgw_banco.Columns(8).Visible = (False)
            dgw_banco.Columns(9).Visible = (False)
            dgw_banco.Columns(10).Visible = (False)
            dgw_banco.Columns(0).Width = (50)
        Catch ex As Exception


            MsgBox(ex.Message)
            'MsgBox(ex.Message)

        End Try
    End Sub

    Sub cargar_datos()
        txt_cod_banco.Text = dgw1(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_banco.Text = dgw1(1, dgw1.CurrentRow.Index).Value.ToString
        cbo_ban_año.Text = dgw1(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_ban_mes.Text = dgw1(3, dgw1.CurrentRow.Index).Value.ToString
        txt_debe.Text = dgw1(4, dgw1.CurrentRow.Index).Value.ToString
        txt_haber.Text = dgw1(5, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Sub cargar_datos_sa()
        txt_cod.Text = dgw2(0, dgw2.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw2(1, dgw2.CurrentRow.Index).Value.ToString
        txt_cod_cta.Text = dgw2(4, dgw2.CurrentRow.Index).Value.ToString
        txt_saldo.Text = dgw2(11, dgw2.CurrentRow.Index).Value.ToString
    End Sub




    Function CONTAR_REG(ByVal AÑO0 As Object, ByVal MES0 As Object, ByVal COD_BAN0 As Object) As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_SALDO_BANCOS", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (cbo_ban_año.Text)
            CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (cbo_ban_mes.Text)
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = (txt_cod_banco.Text)
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)

        End Try
        Return CONT
    End Function


    Sub DATAGRID()
        Try
            Dim pro As New SqlCommand("MOSTRAR_SALDO_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Bancos")
            Prog00.Fill(dt)
            dgw1.DataSource = (dt)
            dgw1.Columns(4).Visible = (False)
            dgw1.Columns(5).Visible = (False)
            dgw1.Columns(9).Visible = (False)
            dgw1.Columns(10).Visible = (False)
            dgw1.Columns(0).Width = (60)
            dgw1.Columns(1).Width = (150)
            dgw1.Columns(2).Width = (32)
            dgw1.Columns(3).Width = (32)
            dgw1.Columns(6).Width = (40)
            dgw1.Columns(7).Width = (&H2B)
            dgw1.Columns(8).Width = (80)
            dgw1.Columns(11).Width = (30)
        Catch ex As Exception


            MsgBox(ex.Message)
            'MsgBox(ex.Message)

        End Try
    End Sub


    Sub datagrid_sa()
        Try
            Dim pro As New SqlCommand("MOSTRAR_SALDO_ACT", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Bancos")
            Prog00.Fill(dt)
            dgw2.DataSource = (dt)
            dgw2.Columns(0).Width = 30
            dgw2.Columns(1).Width = 100
            dgw2.Columns(2).Visible = (False)
            dgw2.Columns(3).Visible = (False)
            dgw2.Columns(4).Width = (40)
            dgw2.Columns(5).Visible = (False)
            dgw2.Columns(6).Visible = (False)
            dgw2.Columns(7).Visible = (False)
            dgw2.Columns(8).Visible = (False)
            dgw2.Columns(9).Visible = (False)
            dgw2.Columns(10).Visible = (False)
            dgw2.Columns(11).Width = 70
            dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            dgw2.Columns(11).DefaultCellStyle.Alignment = (&H40)
        Catch ex As Exception


            MsgBox(ex.Message)
            'MsgBox(ex.Message)

        End Try
    End Sub









    Private Sub dgw_banco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_banco.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_banco.Text = dgw_banco(0, dgw_banco.CurrentRow.Index).Value.ToString
            txt_desc_banco.Text = dgw_banco(1, dgw_banco.CurrentRow.Index).Value.ToString
            panel_banco.Visible = False
            txt_kl.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_banco.Visible = False
            txt_cod_banco.Clear()
            txt_desc_banco.Clear()
            txt_cod_banco.Focus()
        End If

    End Sub
    Sub limpiar()
        txt_cod_banco.Clear()
        txt_desc_banco.Clear()
        txt_debe.Clear()
        txt_haber.Clear()
        cbo_ban_año.SelectedIndex = -1
        cbo_ban_mes.SelectedIndex = -1
        txt_cod_banco.Enabled = True
        txt_desc_banco.Enabled = True
        txt_debe.Enabled = True
        txt_haber.Enabled = True
        cbo_ban_año.Enabled = True
        cbo_ban_mes.Enabled = True
    End Sub

    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
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

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "NUEVO") Then
                boton = "DETALLES1"
            ElseIf (boton = "MODIFICAR") Then
                boton = "DETALLES2"
            Else
                boton = "DETALLES"
            End If
        Else
            btn_nuevo.Select()
        End If

    End Sub

    Private Sub txt_cod_banco_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_banco.LostFocus
        If (Strings.Trim(txt_cod_banco.Text) <> "") Then
            If (dgw_banco.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_banco.Sort(dgw_banco.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_banco.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= dgw_banco.RowCount - 1)
                    If (txt_cod_banco.Text.ToLower = dgw_banco(0, i).Value.ToString.ToLower) Then
                        txt_cod_banco.Text = dgw_banco(0, i).Value.ToString
                        txt_desc_banco.Text = dgw_banco(1, i).Value.ToString
                        cbo_ban_año.Select()
                        Return
                    End If
                    If (txt_cod_banco.Text.ToLower = Mid((dgw_banco(0, i).Value), 1, Strings.Len(txt_cod_banco.Text)).ToLower) Then
                        dgw_banco.CurrentCell = (dgw_banco.Rows(i).Cells(0))
                        Exit Do
                    End If
                    dgw_banco.CurrentCell = (dgw_banco.Rows(0).Cells(0))
                    i += 1
                Loop
                panel_banco.Visible = True
                dgw_banco.Visible = True
                dgw_banco.Focus()
            End If
        End If

    End Sub

    Private Sub txt_debe_ini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_debe_ini.KeyPress
        e.Handled = Numero(e, (txt_debe_ini))
    End Sub

    Private Sub txt_debe_ini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_debe_ini.LostFocus
        If (txt_debe_ini.Text.Trim <> "") Then
            Try
                txt_debe_ini.Text = obj.HACER_DECIMAL(txt_debe_ini.Text)
            Catch ex As Exception


                'MsgBox(ex.Message)
                MsgBox(ex.Message)

            End Try
        End If

    End Sub

    Private Sub txt_debe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_debe.KeyPress
        e.Handled = Numero(e, (txt_debe))
    End Sub

    Private Sub txt_debe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_debe.LostFocus
        If (txt_debe.Text.Trim <> "") Then
            Try
                txt_debe.Text = obj.HACER_DECIMAL(txt_debe.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Private Sub txt_desc_banco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_banco.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txt_desc_banco.Text) = "") Then
                cbo_ban_año.Select()
            ElseIf (dgw_banco.RowCount = 0) Then
                MessageBox.Show("No existen BANCOS", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_banco.Focus()
            Else
                dgw_banco.Sort(dgw_banco.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_banco.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= dgw_banco.RowCount - 1)
                    If (txt_desc_banco.Text.ToLower = Mid(dgw_banco(1, i).Value, 1, Len(txt_desc_banco.Text)).ToLower) Then
                        dgw_banco.CurrentCell = (dgw_banco.Rows(i).Cells(0))
                        Exit Do
                    End If
                    dgw_banco.CurrentCell = (dgw_banco.Rows(0).Cells(0))
                    i += 1
                Loop
                panel_banco.Visible = True
                dgw_banco.Focus()
            End If
        End If
    End Sub
    Private Sub txt_haber_ini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_haber_ini.KeyPress
        e.Handled = Numero(e, txt_haber_ini)
    End Sub
    Private Sub txt_haber_ini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_haber_ini.LostFocus
        If (txt_haber_ini.Text.Trim <> "") Then
            Try
                txt_haber_ini.Text = obj.HACER_DECIMAL(txt_haber_ini.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub txt_haber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_haber.KeyPress
        e.Handled = Numero(e, (txt_haber))
    End Sub
    Private Sub txt_haber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_haber.LostFocus
        If (txt_haber.Text.Trim <> "") Then
            Try
                txt_haber.Text = obj.HACER_DECIMAL(txt_haber.Text)
            Catch ex As Exception


                MsgBox(ex.Message)
                'MsgBox(ex.Message)

            End Try
        End If

    End Sub
    Private Sub txt_saldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_saldo.KeyPress
        e.Handled = Numero(e, (txt_saldo))
    End Sub
    Private Sub txt_saldo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_saldo.LostFocus
        If (txt_saldo.Text.Trim <> "") Then
            Try
                txt_saldo.Text = obj.HACER_DECIMAL(txt_saldo.Text)
            Catch ex As Exception


                MsgBox(ex.Message)
                'MsgBox(ex.Message)

            End Try
        End If

    End Sub
    Function VERIFICACION_ELIMINAR(ByVal FILA0 As Integer) As Boolean

        Dim SALDO As Decimal = 0
        SALDO = dgw1.Item(4, FILA0).Value + dgw1.Item(5, FILA0).Value + dgw1.Item(9, FILA0).Value + dgw1.Item(10, FILA0).Value
        If SALDO > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btn_contable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_contable.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Exit Sub

        End Try
        boton = "MODIFICAR"
        txt_cod_ban_ini.Text = dgw1(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_ban_ini.Text = dgw1(1, dgw1.CurrentRow.Index).Value.ToString
        cbo_año.Text = dgw1(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_mes.Text = dgw1(3, dgw1.CurrentRow.Index).Value.ToString
        txt_debe_ini.Text = dgw1(9, dgw1.CurrentRow.Index).Value.ToString
        txt_haber_ini.Text = dgw1(10, dgw1.CurrentRow.Index).Value.ToString
        txt_cod_ban_ini.Enabled = False
        txt_desc_ban_ini.Enabled = False
        cbo_año.Enabled = False
        cbo_mes.Enabled = False
        TabControl1.SelectedTab = (TabPage3)
        txt_debe_ini.Focus()
    End Sub
End Class