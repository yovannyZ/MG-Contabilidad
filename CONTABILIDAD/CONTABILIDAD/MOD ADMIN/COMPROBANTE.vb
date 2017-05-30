Imports System.Data.SqlClient
Public Class COMPROBANTE
    Private aux As String
    Private boton As String
    Private obj As New Class1
    Private status_extra As String
    Private suc As String
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        Dim cod_eliminar As String = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & cod_eliminar & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo)))) = 6) Then
            Try
                Dim pro04 As New SqlCommand("ELIMINAR_COMPROBANTE", con)
                pro04.CommandType = CommandType.StoredProcedure
                pro04.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = cod_eliminar
                pro04.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
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
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_aux.SelectedIndex = -1)) Or (cbo_sucursal.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Fatan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            status_extra = "0"
            If ch_extra.Checked Then
                status_extra = "1"
            End If
            If (cbo_aux.SelectedIndex = -1) Then
                aux = " "
            Else
                aux = obj.COD_AUX(cbo_aux.Text)
            End If
            If (cbo_sucursal.SelectedIndex = -1) Then
                suc = " "
            Else
                suc = obj.COD_SUCURSAL(cbo_sucursal.Text)
            End If
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("El codigo de Comprobante ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                Try
                    Dim pro03 As New SqlCommand("INSERTAR_COMPROBANTE", con)
                    pro03.CommandType = CommandType.StoredProcedure
                    pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = txt_cod.Text
                    pro03.Parameters.Add("@DESC_COMP", SqlDbType.VarChar).Value = txt_desc.Text
                    pro03.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                    pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = aux
                    pro03.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = suc
                    pro03.Parameters.Add("@STATUS_EXT_CONT", SqlDbType.Char).Value = status_extra
                    con.Open()
                    pro03.ExecuteNonQuery()
                    MessageBox.Show("El Comprobante se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    con.Close()
                    limpiar()
                    txt_cod.Focus()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                Finally
                    con.Close()
                End Try
                datagrid()
            End If
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        boton = "modificar"
        TabControl1.SelectedTab = TabPage2
        limpiar()
        cargar_datos()
        txt_cod.Enabled = False
        cbo_aux.Enabled = False
        btn_modificar2.Visible = True
        btn_guardar.Visible = False
        cbo_sucursal.Select()
    End Sub
    Private Sub btn_Modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_aux.SelectedIndex = -1)) Or (cbo_sucursal.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Fatan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            status_extra = "0"
            If ch_extra.Checked Then
                status_extra = "1"
            End If
            If (cbo_aux.SelectedIndex = -1) Then
                aux = " "
            Else
                aux = obj.COD_AUX(cbo_aux.Text)
            End If
            If (cbo_sucursal.SelectedIndex = -1) Then
                suc = " "
            Else
                suc = obj.COD_SUCURSAL(cbo_sucursal.Text)
            End If
            Try
                Dim pro03 As New SqlCommand("MODIFICAR_COMPROBANTE", con)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = txt_cod.Text
                pro03.Parameters.Add("@DESC_COMP", SqlDbType.VarChar).Value = txt_desc.Text
                pro03.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = aux
                pro03.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = suc
                pro03.Parameters.Add("@STATUS_EXT_CONT", SqlDbType.Char).Value = status_extra
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
                datagrid()
                MessageBox.Show("El Comprobante se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
                btn_nuevo.Select()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "nuevo"
        TabControl1.SelectedTab = TabPage2
        limpiar()
        btn_modificar2.Visible = False
        btn_guardar.Visible = True
        txt_cod.Focus()
    End Sub
    Private Sub btn_Salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(6) = 0
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
        txt_cod.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString)
        aux = (dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString)
        cbo_aux.Text = (dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString)
        suc = (dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString)
        cbo_sucursal.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString)
        txt_desc.Text = (dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString)
        txt_desc2.Text = (dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString)
        status_extra = (dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString)
        If (status_extra = "1") Then
            ch_extra.Checked = True
        End If
    End Sub
    Sub cargar_sucursal()
        cbo_sucursal.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("cbo_sucursal", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_sucursal.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Comprobante_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub Comprobante_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        cargar_aux()
        cargar_sucursal()
        btn_nuevo.Select()
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_COMPROBANTE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = txt_cod.Text
            CMD.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = aux
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
            Dim pro As New SqlCommand("MOSTRAR_COMPROBANTE", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(1).Visible = False
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(7).Visible = False
            dgw1.Columns.Item(0).Width = 40
            dgw1.Columns.Item(2).Width = 180
            dgw1.Columns.Item(3).Width = 30
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub limpiar()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        txt_cod.Enabled = True
        txt_desc.Enabled = True
        txt_desc2.Enabled = True
        cbo_aux.SelectedIndex = -1
        cbo_sucursal.SelectedIndex = -1
        cbo_sucursal.Enabled = True
        cbo_aux.Enabled = True
        ch_extra.Enabled = True
        ch_extra.Checked = False
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "nuevo") Then
                boton = "detalles1"
            ElseIf (boton = "modificar") Then
                boton = "detalles2"
            Else
                boton = "detalles"
                If (dgw1.RowCount <> 0) Then
                    cargar_datos()
                End If
                txt_cod.Enabled = False
                txt_desc.Enabled = False
                txt_desc2.Enabled = False
                cbo_sucursal.Enabled = False
                cbo_aux.Enabled = False
                btn_modificar2.Visible = False
                btn_guardar.Visible = False
                ch_extra.Enabled = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            cbo_aux.Select()
        End If
    End Sub
    Private Sub txt_nom_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc2.Focus()
        End If
        If (e.KeyData = Keys.Up) Then
            cbo_sucursal.Focus()
        End If
    End Sub
    Private Sub txt_nom2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{tab}")
        End If
        If (e.KeyData = Keys.Up) Then
            txt_desc.Focus()
        End If
    End Sub
End Class