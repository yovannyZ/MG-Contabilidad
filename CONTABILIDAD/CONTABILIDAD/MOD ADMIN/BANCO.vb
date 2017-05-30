Imports System.Data.SqlClient
Public Class BANCO
    Dim aux, boton, comp, eq, moneda, st_ban, st_sus As String
    Private obj As New Class1

    Private Sub Bancos2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        cargar_moneda()
        cargar_aux()
        cargar_eq()
        btn_nuevo.Select()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        Dim cod_eliminar As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse(VERIFICACION_ELIMINAR(cod_eliminar)) > 0) Then
            MessageBox.Show("El Banco tiene numeración", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & cod_eliminar & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo)))) = 6) Then
                Try
                    Dim pro04 As New SqlCommand("Eliminar_banco", con)
                    pro04.CommandType = CommandType.StoredProcedure
                    pro04.Parameters.Add("@cod_banco", SqlDbType.VarChar).Value = cod_eliminar
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
        End If
    End Sub
    Sub limpiar()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        cbo_moneda.SelectedIndex = -1
        txt_cod_cta.Clear()
        cbo_aux.SelectedIndex = -1
        txt_formato.Clear()
        ch_ban.Checked = False
        ch_sus.Checked = False
        cbo_eq.SelectedIndex = -1
        cbo_com.SelectedIndex = -1
        txt_nro_cta.Clear()
        txt_cod.Enabled = True
        txt_desc.Enabled = True
        txt_desc2.Enabled = True
        cbo_moneda.Enabled = True
        txt_cod_cta.Enabled = True
        cbo_aux.Enabled = True
        txt_formato.Enabled = True
        ch_ban.Enabled = True
        ch_sus.Enabled = True
        cbo_eq.Enabled = True
        txt_nro_cta.Enabled = True
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe ingresar la Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf (Strings.Trim(txt_cod_cta.Text) = "") Then
            MessageBox.Show("Debe ingresar la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta.Focus()
        ElseIf (cbo_moneda.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda.Focus()
        ElseIf (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir : Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir : Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        Else
            aux = obj.COD_AUX(cbo_aux.Text)
            comp = obj.COD_COMP(cbo_com.Text, aux)
            If (cbo_eq.SelectedIndex = -1) Then
                eq = " "
            Else
                eq = obj.COD_BANCO_EQ(cbo_eq.Text)
            End If
            moneda = cbo_moneda.SelectedValue.ToString
            If ch_ban.Checked Then
                st_ban = "1"
            Else
                st_ban = "0"
            End If
            If ch_sus.Checked Then
                st_sus = "1"
            Else
                st_sus = "0"
            End If
            If (CONTAR_REG > 0) Then
                MessageBox.Show("El codigo de Banco ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                Try
                    Dim pro03 As New SqlCommand("insertar_banco", con)
                    pro03.CommandType = CommandType.StoredProcedure
                    pro03.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod.Text
                    pro03.Parameters.Add("@DESC_BANCO", SqlDbType.VarChar).Value = txt_desc.Text
                    pro03.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                    pro03.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = moneda
                    pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta.Text
                    pro03.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = aux
                    pro03.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = txt_formato.Text
                    pro03.Parameters.Add("@STATUS_BAN", SqlDbType.Char).Value = st_ban
                    pro03.Parameters.Add("@STATUS_SUS", SqlDbType.Char).Value = st_sus
                    pro03.Parameters.Add("@COD_BANCO_EQ", SqlDbType.Char).Value = eq
                    pro03.Parameters.Add("@NRO_CUENTA", SqlDbType.VarChar).Value = txt_nro_cta.Text
                    pro03.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Decimal).Value = 0
                    pro03.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = comp
                    con.Open()
                    pro03.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("El Banco se guardó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Return

        End Try
        boton = "modificar"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        limpiar()
        cargar_datos()
        txt_cod.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub

    Private Sub btn_Modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe ingresar la Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf (Strings.Trim(txt_cod_cta.Text) = "") Then
            MessageBox.Show("Debe ingresar la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta.Focus()
        ElseIf (cbo_moneda.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda.Focus()
        ElseIf (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir : Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir : Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        Else
            aux = obj.COD_AUX(cbo_aux.Text)
            comp = obj.COD_COMP(cbo_com.Text, aux)
            If (cbo_eq.SelectedIndex = -1) Then
                eq = " "
            Else
                eq = obj.COD_BANCO_EQ(cbo_eq.Text)
            End If
            moneda = cbo_moneda.SelectedValue.ToString
            If ch_ban.Checked Then
                st_ban = "1"
            Else
                st_ban = "0"
            End If
            If ch_sus.Checked Then
                st_sus = "1"
            Else
                st_sus = "0"
            End If
            Try
                Dim pro03 As New SqlCommand("modificar_banco", con)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod.Text
                pro03.Parameters.Add("@DESC_BANCO", SqlDbType.VarChar).Value = txt_desc.Text
                pro03.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                pro03.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = moneda
                pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta.Text
                pro03.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = aux
                pro03.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = txt_formato.Text
                pro03.Parameters.Add("@STATUS_BAN", SqlDbType.Char).Value = st_ban
                pro03.Parameters.Add("@STATUS_SUS", SqlDbType.Char).Value = st_sus
                pro03.Parameters.Add("@COD_BANCO_EQ", SqlDbType.Char).Value = eq
                pro03.Parameters.Add("@NRO_CUENTA", SqlDbType.VarChar).Value = txt_nro_cta.Text
                pro03.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = comp
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Banco se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        txt_cod.Focus()
    End Sub

    Private Sub btn_Salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(29) = 0
        Close()
    End Sub

    Sub cargar_aux()
        cbo_aux.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Sub cargar_datos()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        moneda = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        cbo_moneda.Text = obj.DESC_MONEDA(moneda)
        txt_cod_cta.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        aux = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        cbo_aux.Text = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        comp = (dgw1.Item(13, dgw1.CurrentRow.Index).Value.ToString)
        cbo_com.Text = dgw1.Item(14, dgw1.CurrentRow.Index).Value.ToString
        txt_formato.Text = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        st_ban = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString
        st_sus = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        If (st_ban = "1") Then
            ch_ban.Checked = True
        Else
            ch_ban.Checked = False
        End If
        If (st_sus = "1") Then
            ch_sus.Checked = True
        Else
            ch_sus.Checked = False
        End If
        eq = dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString
        cbo_eq.Text = DESC_BAN_EQ(eq)
        txt_nro_cta.Text = dgw1.Item(11, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Sub cargar_eq()
        cbo_eq.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("cargar_banco2", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_eq.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub

    Sub cargar_moneda()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT
        cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        'If (cbo_aux.SelectedIndex <> -1) Then
        '    aux = obj.COD_AUX(cbo_aux.Text)
        'End If
        If (cbo_aux.SelectedIndex <> -1) Then
            aux = obj.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
        End If
    End Sub
    Sub CBO_COMPROBANTE()
        cbo_com.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = aux
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_banco", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@cod_banco", SqlDbType.Char).Value = txt_cod.Text
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
            Dim pro As New SqlCommand("MOSTRAR_banco", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("banco")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(3).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(7).Visible = False
            dgw1.Columns.Item(8).Visible = False
            dgw1.Columns.Item(9).Visible = False
            dgw1.Columns.Item(10).Visible = False
            dgw1.Columns.Item(11).Visible = False
            dgw1.Columns.Item(12).Visible = False
            dgw1.Columns.Item(13).Visible = False
            dgw1.Columns.Item(14).Visible = False
            dgw1.Columns.Item(0).Width = &H2D
            dgw1.Columns.Item(4).Width = &H41
       
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Function DESC_BAN_EQ(ByVal cod As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_02 As New SqlCommand("desc_eq", con2)
            PROG_02.CommandType = CommandType.StoredProcedure
            PROG_02.Parameters.Add("@cod_eq", SqlDbType.VarChar).Value = (cod)
            con2.Open()
            desc = (PROG_02.ExecuteScalar)
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MessageBox.Show(ex.Message)

        End Try
        Return desc
    End Function
    Private Sub Maestro_Bancos_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
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
                txt_cod.Enabled = False
                txt_desc.Enabled = False
                txt_desc2.Enabled = False
                cbo_moneda.Enabled = False
                txt_cod_cta.Enabled = False
                cbo_aux.Enabled = False
                txt_formato.Enabled = False
                ch_ban.Enabled = False
                ch_sus.Enabled = False
                cbo_eq.Enabled = False
                txt_nro_cta.Enabled = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub

    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc2.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub

    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_cod_cta.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_desc.Focus()
        End If
    End Sub

    Private Sub txt_formato_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_formato.KeyDown
        If (e.KeyData = Keys.Down) Then
            ch_ban.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_aux.Select()
        End If
    End Sub

    Private Sub txt_nro_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_cta.KeyDown
        If (e.KeyData = Keys.Down) Then
            cbo_eq.Select()
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_moneda.Select()
        End If
    End Sub

    Function VERIFICACION_ELIMINAR(ByVal COD As Object) As String
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_ELIMINAR_BANCO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@cod_banco", SqlDbType.Char).Value = (COD)
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return (CONT)
    End Function
    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_com.SelectedIndexChanged
        If ((cbo_aux.SelectedIndex <> -1) And (cbo_com.SelectedIndex <> -1)) Then
            aux = obj.COD_AUX(cbo_aux.Text)
            comp = obj.COD_COMP(cbo_com.Text, aux)
        End If
    End Sub
End Class