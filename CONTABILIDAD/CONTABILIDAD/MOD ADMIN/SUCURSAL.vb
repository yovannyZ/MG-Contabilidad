Imports System.Data.SqlClient
Public Class SUCURSAL
    Dim boton As String
    Private Sub SUCURSAL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub SUCURSAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        DATAGRID()
        btn_nuevo.Select()
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (MessageBox.Show(("ELIMINAR " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) = 6 Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_SUCURSAL", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (COD_CLASE)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        DATAGRID()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf (CONTAR_REG() > 0) Then
            MessageBox.Show("El codigo de  SUCURSAL ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("INSERTAR_SUCURSAL", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (txt_cod.Text)
                CMD.Parameters.Add("@DESC_SUCURSAL", SqlDbType.VarChar).Value = (txt_desc.Text)
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = (txt_desc2.Text)
                CMD.Parameters.Add("@NRO_RUC", SqlDbType.VarChar).Value = (txt_ruc.Text)
                CMD.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = (txt_fono.Text)
                CMD.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = (txt_dir.Text)
                CMD.Parameters.Add("@localidad", SqlDbType.VarChar).Value = (txt_localidad.Text)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La SUCURSAL se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
                txt_cod.Focus()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
            SGT_CODIGO()
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.ReadOnly = True
        TabControl1.SelectedTab = (TabPage2)
        txt_desc.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_SUCURSAL", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (txt_cod.Text)
                CMD.Parameters.Add("@DESC_SUCURSAL", SqlDbType.VarChar).Value = (txt_desc.Text)
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = (txt_desc2.Text)
                CMD.Parameters.Add("@NRO_RUC", SqlDbType.VarChar).Value = (txt_ruc.Text)
                CMD.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = (txt_fono.Text)
                CMD.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = (txt_dir.Text)
                CMD.Parameters.Add("@localidad", SqlDbType.VarChar).Value = (txt_localidad.Text)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La SUCURSAL  se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = (TabPage1)
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        SGT_CODIGO()
        TabControl1.SelectedTab = (TabPage2)
        txt_cod.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(20) = 0
        Close()
    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_ruc.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_fono.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        txt_dir.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        txt_localidad.Text = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_SUCURSAL", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (txt_cod.Text)
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_SUCURSAL", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = (dt)
            dgw1.Columns(2).Visible = False
            dgw1.Columns(4).Visible = False
            dgw1.Columns(5).Visible = False
            dgw1.Columns(6).Visible = False
            dgw1.Columns(0).Width = (30)
            dgw1.Columns(3).Width = (110)
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        txt_ruc.Clear()
        txt_fono.Clear()
        txt_dir.Clear()
        txt_localidad.Clear()
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        txt_desc2.ReadOnly = False
        txt_ruc.ReadOnly = False
        txt_fono.ReadOnly = False
        txt_dir.ReadOnly = False
        txt_localidad.ReadOnly = False
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
    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_SUCURSAL", con)
            con.Open()
            SGT = CMD.ExecuteScalar.ToString
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If (SGT = "") Then
            txt_cod.Text = "01"
        Else
            txt_cod.Text = SGT
        End If
    End Sub
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function













    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "NUEVO") Then
                boton = "DETALLES1"
            ElseIf (boton = "MODIFICAR") Then
                boton = "DETALLES2"
            Else
                boton = "DETALLES"
                LIMPIAR()
                If (dgw1.Rows.Count <> 0) Then
                    CARGAR_DATOS()
                End If
                txt_cod.ReadOnly = True
                txt_desc.ReadOnly = True
                txt_desc2.ReadOnly = True
                txt_ruc.ReadOnly = True
                txt_fono.ReadOnly = True
                txt_dir.ReadOnly = True
                txt_localidad.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
            End If
        End If

    End Sub

    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If

    End Sub

    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc2.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If

    End Sub

    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc2.KeyDown
        If (e.KeyData = Keys.Up) Then
            txt_desc.Focus()
        ElseIf (e.KeyData = Keys.Down) Then
            txt_ruc.Focus()
        End If

    End Sub

    Private Sub txt_dir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_dir.KeyDown
        If (e.KeyData = Keys.Up) Then
            txt_fono.Focus()
        ElseIf (e.KeyData = Keys.Down) Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub txt_fono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_fono.KeyDown
        If (e.KeyData = Keys.Up) Then
            txt_ruc.Focus()
        ElseIf (e.KeyData = Keys.Down) Then
            txt_dir.Focus()
        End If

    End Sub

    Private Sub txt_ruc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ruc.KeyDown
        If (e.KeyData = Keys.Up) Then
            txt_desc2.Focus()
        ElseIf (e.KeyData = Keys.Down) Then
            txt_fono.Focus()
        End If

    End Sub

    Private Sub txt_ruc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ruc.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If

    End Sub
End Class