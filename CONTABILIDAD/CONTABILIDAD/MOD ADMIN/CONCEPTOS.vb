Imports System.Data.SqlClient
Public Class CONCEPTOS
    Dim obj As New Class1
    Dim st_cc, st_p, boton, st_vcto As String
    Private Sub Bancos2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
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
        Dim cod3 As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        Dim desc3 As String = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        If ((cod3.Length <> 5) AndAlso (Decimal.Parse(VERIFICACION_ELIMINAR(cod3)) <> 1)) Then
            MessageBox.Show("Existe Nivel 5", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & cod3 & " " & desc3), "ESTA SEGURO DE", MessageBoxButtons.YesNo)))) = 6) Then
                Try
                    Dim pro04 As New SqlCommand("Eliminar_concepto", con)
                    pro04.CommandType = CommandType.StoredProcedure
                    pro04.Parameters.Add("@cod_cpto", SqlDbType.VarChar).Value = cod3
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
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe ingresar la Descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf ((cbo_dh.SelectedIndex = -1) And gb_det.Visible) Then
            MessageBox.Show("Debe elegir D/H", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_dh.Focus()
        ElseIf ((cbo_ie.SelectedIndex = -1) And gb_det.Visible) Then
            MessageBox.Show("Debe elegir : Ingreso/Egreso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_ie.Focus()
        ElseIf ((txt_cod.Text.Length <> Decimal.Parse("3")) And (txt_cod.Text.Length <> Decimal.Parse("5"))) Then
            MessageBox.Show("El código solo puede ser de nivel 3 ó 5", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            If ch_cc.Checked Then
                st_cc = "1"
            Else
                st_cc = "0"
            End If
            If ch_p.Checked Then
                st_p = "1"
            Else
                st_p = "0"
            End If
            If ch_vcto.Checked Then
                st_vcto = "1"
            Else
                st_vcto = "0"
            End If
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("El codigo de Concepto ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                Try
                    Dim pro03 As New SqlCommand("INSERTAR_CONCEPTO", con)
                    pro03.CommandType = CommandType.StoredProcedure
                    pro03.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod.Text
                    pro03.Parameters.Add("@DESC_CPTO", SqlDbType.VarChar).Value = txt_desc.Text
                    pro03.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                    pro03.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = cbo_dh.Text.ToString
                    pro03.Parameters.Add("@TIPO_I_E", SqlDbType.VarChar).Value = cbo_ie.Text.ToString
                    pro03.Parameters.Add("@STATUS_CC", SqlDbType.VarChar).Value = st_cc
                    pro03.Parameters.Add("@STATUS_P", SqlDbType.VarChar).Value = st_p
                    pro03.Parameters.Add("@COD_FLUJO", SqlDbType.VarChar).Value = txt_flujo.Text
                    pro03.Parameters.Add("@ST_VCTO", SqlDbType.Char).Value = st_vcto
                    con.Open()
                    pro03.ExecuteNonQuery()
                    con.Close()
                    datagrid()
                    MessageBox.Show("El concepto se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TabControl1.SelectedTab = TabPage1
                    btn_nuevo.Select()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub
    Sub limpiar()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        txt_cod.Enabled = True
        txt_desc.Enabled = True
        txt_desc2.Enabled = True
        txt_flujo.Clear()
        txt_flujo.Enabled = True
        cbo_dh.SelectedIndex = -1
        cbo_dh.Enabled = True
        cbo_ie.SelectedIndex = -1
        cbo_ie.Enabled = True
        ch_cc.Checked = False
        ch_cc.Enabled = True
        ch_p.Checked = False
        ch_p.Enabled = True
        '--------------------------
        ch_vcto.Checked = False
        ch_vcto.Enabled = True
        gb_det.Visible = False
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Modificar.Click
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
        ElseIf ((cbo_dh.SelectedIndex = -1) And gb_det.Visible) Then
            MessageBox.Show("Debe elegir D/H", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_dh.Focus()
        ElseIf ((cbo_ie.SelectedIndex = -1) And gb_det.Visible) Then
            MessageBox.Show("Debe elegir : Ingreso/Egreso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_ie.Focus()
        Else
            If ch_cc.Checked Then
                st_cc = "1"
            Else
                st_cc = "0"
            End If
            If ch_p.Checked Then
                st_p = "1"
            Else
                st_p = "0"
            End If
            If ch_vcto.Checked Then
                st_vcto = "1"
            Else
                st_vcto = "0"
            End If
            Try
                Dim pro03 As New SqlCommand("MODIFICAR_CONCEPTO", con)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod.Text
                pro03.Parameters.Add("@DESC_CPTO", SqlDbType.VarChar).Value = txt_desc.Text
                pro03.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                pro03.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = cbo_dh.Text
                pro03.Parameters.Add("@TIPO_I_E", SqlDbType.VarChar).Value = cbo_ie.Text
                pro03.Parameters.Add("@STATUS_CC", SqlDbType.VarChar).Value = st_cc
                pro03.Parameters.Add("@STATUS_P", SqlDbType.VarChar).Value = st_p
                pro03.Parameters.Add("@COD_FLUJO", SqlDbType.VarChar).Value = txt_flujo.Text
                pro03.Parameters.Add("@ST_VCTO", SqlDbType.Char).Value = st_vcto
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
                datagrid()
                MessageBox.Show("El Concepto se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
                btn_nuevo.Select()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
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
        main(18) = 0
        Close()
    End Sub
    Sub cargar_datos()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_dh.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        cbo_ie.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        '--------------------------------------------------------------
        st_cc = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        If (st_cc = "1") Then
            ch_cc.Checked = True
        Else
            ch_cc.Checked = False
        End If
        '--------------------------------------------------------------
        st_p = (dgw1.Item(6, dgw1.CurrentRow.Index).Value)
        If (st_p = "1") Then
            ch_p.Checked = True
        Else
            ch_p.Checked = False
        End If
        '--------------------------------------------------------------
        st_vcto = (dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString)
        If (st_vcto = "1") Then
            ch_vcto.Checked = True
        Else
            ch_vcto.Checked = False
        End If
        '--------------------------------------------------------------
        txt_flujo.Text = (dgw1.Item(7, dgw1.CurrentRow.Index).Value)
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_CONCEPTO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod.Text
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
            Dim pro As New SqlCommand("MOSTRAR_CONCEPTO", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(7).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(8).Visible = False
            dgw1.Columns.Item(0).Width = 50
            dgw1.Columns.Item(3).Width = 28
            dgw1.Columns.Item(4).Width = 28
            dgw1.Columns.Item(1).Width = 180
            dgw1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Maestro_Conceptos_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
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
                If (dgw1.Rows.Count <> 0) Then
                    cargar_datos()
                End If
                btn_modificar2.Visible = False
                btn_guardar.Visible = False
                txt_cod.Enabled = False
                txt_desc.Enabled = False
                txt_desc2.Enabled = False
                txt_flujo.Enabled = False
                cbo_dh.Enabled = False
                cbo_ie.Enabled = False
                ch_cc.Enabled = False
                ch_vcto.Enabled = False
                ch_p.Enabled = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyCode = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_cod_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod.TextChanged
        If (txt_cod.Text.Length = 5) Then
            Dim codigo As String = Strings.Mid(txt_cod.Text, 1, 3)
            Try
                Dim PROG_01 As New SqlCommand("VERIFICAR_EXISTE_NIVEL03", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = codigo
                con.Open()
                PROG_01.ExecuteNonQuery()
                If (PROG_01.ExecuteReader.HasRows = False) Then
                    MessageBox.Show(("No existe nivel 3 para el codigo: " & txt_cod.Text), "No existe Nivel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    gb_det.Visible = False
                    txt_cod.Clear()
                Else
                    gb_det.Visible = True
                End If
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub txt_flujo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_flujo.KeyDown
        If (e.KeyCode = Keys.Down) Then
            ch_cc.Focus()
        ElseIf (e.KeyCode = Keys.Up) Then
            cbo_ie.Select()
        End If
    End Sub
    Private Sub txt_nom_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyCode = Keys.Down) Then
            txt_desc2.Focus()
        ElseIf (e.KeyCode = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub txt_nom2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If (e.KeyCode = Keys.Down) Then
            cbo_dh.Focus()
        ElseIf (e.KeyCode = Keys.Up) Then
            txt_desc.Focus()
        End If
    End Sub
    Function VERIFICACION_ELIMINAR(ByVal COD As Object) As String
        Dim CONT As Integer = 0
        Try
            Dim PROG_02 As New SqlCommand("VERIFICAR_ELIMINAR_NIVEL03", con)
            PROG_02.CommandType = CommandType.StoredProcedure
            PROG_02.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = (COD)
            con.Open()
            PROG_02.ExecuteNonQuery()
            Dim Rs4 As SqlDataReader = PROG_02.ExecuteReader
            Do While Rs4.Read
                CONT += 1
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return (CONT)
    End Function
End Class