Imports System.Data.SqlClient
Public Class NRO_MEDIO_PAGO
    Dim boton, mp, st_auto As String
    Dim obj As New Class1
    Sub bancos()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_banco.DataSource = dt
            dgw_banco.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_banco.Columns.Item(0).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub
    Private Sub btn_Eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        Dim cod_mp As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        Dim cod_ban As String = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: el Medio de Pago " & cod_mp), "ESTA SEGURO DE", MessageBoxButtons.YesNo)))) = 6) Then
            Try
                Dim pro04 As New SqlCommand("Eliminar_NRO_MEDIO_PAGO", con)
                pro04.CommandType = CommandType.StoredProcedure
                pro04.Parameters.Add("@cod_mp", SqlDbType.Char).Value = cod_mp
                pro04.Parameters.Add("@cod_banco", SqlDbType.Char).Value = cod_ban
                con.Open()
                pro04.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        datagrid()
        btn_nuevo.Select()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If ((((Strings.Trim(txt_num.Text) = "") Or (Strings.Trim(txt_cod_banco.Text) = "")) Or panel_banco.Visible) Or (cbo_mp.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_banco.Focus()
        Else
            mp = obj.COD_MP(cbo_mp.Text)
            If ch_auto.Checked Then
                st_auto = "1"
            Else
                st_auto = "0"
            End If
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("El inicio de la numeración ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_banco.Focus()
            Else
                Try
                    Dim pro03 As New SqlCommand("insertar_NRO_MEDIO_PAGO", con)
                    pro03.CommandType = CommandType.StoredProcedure
                    pro03.Parameters.Add("@COD_MP", SqlDbType.Char).Value = mp
                    pro03.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_banco.Text
                    pro03.Parameters.Add("@NUMERACION", SqlDbType.VarChar).Value = txt_num.Text
                    pro03.Parameters.Add("@LONG_CAMPO", SqlDbType.VarChar).Value = cbo_long.Value
                    pro03.Parameters.Add("@STATUS_AUTOMATICO", SqlDbType.VarChar).Value = st_auto
                    con.Open()
                    pro03.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("El inicio de la numeración se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    limpiar()
                    TabControl1.SelectedTab = TabPage1
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                datagrid()
                btn_nuevo.Select()
            End If
        End If
    End Sub
    Private Sub btn_Modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        boton = "modificar"
        TabControl1.SelectedTab = TabPage2
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        limpiar()
        cargar_datos()
        txt_cod_banco.Enabled = False
        txt_desc_banco.Enabled = False
        panel_banco.Visible = False
        cbo_mp.Enabled = False
        txt_num.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((((Strings.Trim(txt_num.Text) = "") Or (Strings.Trim(txt_cod_banco.Text) = "")) Or panel_banco.Visible) Or (cbo_mp.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_banco.Focus()
        Else
            mp = obj.COD_MP(cbo_mp.Text)
            If ch_auto.Checked Then
                st_auto = "1"
            Else
                st_auto = "0"
            End If
            Try
                Dim pro03 As New SqlCommand("modificar_NRO_MEDIO_PAGO", con)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@COD_MP", SqlDbType.Char).Value = mp
                pro03.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_banco.Text
                pro03.Parameters.Add("@NUMERACION", SqlDbType.VarChar).Value = txt_num.Text
                pro03.Parameters.Add("@LONG_CAMPO", SqlDbType.VarChar).Value = cbo_long.Value
                pro03.Parameters.Add("@STATUS_AUTOMATICO", SqlDbType.VarChar).Value = st_auto
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El inicio de la numeración se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            datagrid()
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "nuevo"
        TabControl1.SelectedTab = TabPage2
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        limpiar()
        txt_cod_banco.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(23) = 0
        Close()
    End Sub
    Sub cargar_datos()
        mp = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        cbo_mp.Text = obj.DESC_MP(mp)
        txt_cod_banco.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_banco.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_num.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        cbo_long.Value = Decimal.Parse(dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString)
        st_auto = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        If (st_auto = "1") Then
            ch_auto.Checked = True
        Else
            ch_auto.Checked = False
        End If
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_NRO_MEDIO_PAGO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = mp
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_banco.Text
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub datagrid()
        Try
            Dim prog01 As New SqlDataAdapter("MOSTRAR_NRO_MEDIO_PAGO", con)
            Dim dt As New DataTable("MP")
            prog01.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(1).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(0).Width = 30
            dgw1.Columns.Item(3).Width = 100
            dgw1.Columns.Item(4).Width = 40
            dgw1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_banco_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_banco.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_banco.Text = (dgw_banco.Item(0, dgw_banco.CurrentRow.Index).Value)
            txt_desc_banco.Text = (dgw_banco.Item(1, dgw_banco.CurrentRow.Index).Value)
            panel_banco.Visible = False
            k1.Focus()
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
        cbo_mp.SelectedIndex = -1
        txt_num.Clear()
        cbo_long.Value = Decimal.Parse("2")
        ch_auto.Checked = False
        txt_cod_banco.Enabled = True
        txt_desc_banco.Enabled = True
        cbo_mp.Enabled = True
        txt_num.Enabled = True
        cbo_long.Enabled = True
        ch_auto.Enabled = True
    End Sub
    Sub medios_pago()
        cbo_mp.Items.Clear()
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
    Private Sub Num_mp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_num.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub NRO_MEDIO_PAGO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Num_mp_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        datagrid()
        bancos()
        medios_pago()
        btn_nuevo.Select()
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "nuevo") Then
                boton = "detalles1"
            ElseIf (boton = "modificar") Then
                boton = "detalles2"
            Else
                boton = "detalles"
                limpiar()
                If (dgw1.RowCount <> 0) Then
                    cargar_datos()
                End If
                btn_modificar2.Visible = False
                btn_guardar.Visible = False
                txt_cod_banco.Enabled = False
                txt_desc_banco.Enabled = False
                cbo_mp.Enabled = False
                txt_num.Enabled = False
                cbo_long.Enabled = False
                ch_auto.Enabled = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_banco.LostFocus
        If (Strings.Trim(txt_cod_banco.Text) <> "") Then
            If (dgw_banco.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_banco.Sort(dgw_banco.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAr0 As Integer = (dgw_banco.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAr0)
                    If (txt_cod_banco.Text.ToLower = dgw_banco.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_banco.Text = dgw_banco.Item(0, i).Value.ToString
                        txt_desc_banco.Text = dgw_banco.Item(1, i).Value.ToString
                        cbo_mp.Select()
                        Return
                    End If
                    If (txt_cod_banco.Text.ToLower = Strings.Mid((dgw_banco.Item(0, i).Value), 1, Strings.Len(txt_cod_banco.Text)).ToLower) Then
                        dgw_banco.CurrentCell = dgw_banco.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_banco.CurrentCell = dgw_banco.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_banco.Visible = True
                dgw_banco.Visible = True
                dgw_banco.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_banco.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txt_desc_banco.Text) = "") Then
                cbo_mp.Select()
            ElseIf (dgw_banco.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_banco.Sort(dgw_banco.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim cont As Integer = (dgw_banco.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= cont)
                    If (txt_desc_banco.Text.ToLower = Strings.Mid((dgw_banco.Item(1, i).Value), 1, Strings.Len(txt_desc_banco.Text)).ToLower) Then
                        dgw_banco.CurrentCell = dgw_banco.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_banco.Visible = True
                dgw_banco.Focus()
            End If
        End If
    End Sub
    Private Sub txt_num_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_num.KeyDown
        If (e.KeyData = Keys.Down) Then
            cbo_long.Select()
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_mp.Select()
        End If
    End Sub
    Private Sub txt_num_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_num.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
            Exit Sub
        Else
            e.KeyChar = ChrW(0)
        End If
    End Sub
End Class