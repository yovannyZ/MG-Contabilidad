Imports System.Data.SqlClient
Public Class NIVEL_CUENTA
    Dim boton As String
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
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse(VERIFICACION_ELIMINAR(COD_CLASE)) > 0) Then
            MessageBox.Show("El Nivel de Cuenta esta en Maestro de Cuentas", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                Try
                    Dim CMD As New SqlCommand("ELIMINAR_NIVEL_CUENTA", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_NIVEL", SqlDbType.Char).Value = COD_CLASE
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            DATAGRID()
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If Trim(txt_cod.Text) = "" Then MessageBox.Show("Debe insertar el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod.Focus() : Exit Sub
        If Trim(txt_desc.Text) = "" Then MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_desc.Focus() : Exit Sub
        If CONTAR_REG() > 0 Then
            MessageBox.Show("El codigo de Nivel de Cuenta ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
            Try
                Dim CMD As New SqlCommand("INSERTAR_NIVEL_CUENTA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_NIVEL", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_NIVEL", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@NRO_DIGITOS", SqlDbType.Int).Value = nup_digitos.Value
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Nivel de Cuenta se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
                txt_cod.Focus()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()

    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.ReadOnly = True
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_NIVEL_CUENTA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_NIVEL", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_NIVEL", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@NRO_DIGITOS", SqlDbType.Int).Value = nup_digitos.Value
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Nivel de Cuenta se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        TabControl1.SelectedTab = TabPage2
        txt_cod.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(12) = 0
        Close()
    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        nup_digitos.Value = Decimal.Parse(dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString)
    End Sub

    Private Sub CLASE_ARTICULO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        btn_nuevo.Select()
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_NIVEL_CUENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_NIVEL", SqlDbType.Char).Value = txt_cod.Text
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_NIVEL_CUENTA", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("NIVEL_CUENTA")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(0).Width = 30
            dgw1.Columns.Item(2).Width = 25
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        nup_digitos.Value = Decimal.Parse("0")
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        nup_digitos.ReadOnly = False
    End Sub
    Private Sub mant_estado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage2 Then
            If boton = "NUEVO" Then
                boton = "DETALLES1"
            ElseIf boton = "MODIFICAR" Then
                boton = "DETALLES2"
            Else
                boton = "DETALLES"
                LIMPIAR()
                If (dgw1.Rows.Count <> 0) Then
                    CARGAR_DATOS()
                End If
                txt_cod.ReadOnly = True
                txt_desc.ReadOnly = True
                nup_digitos.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub txt_cod_KeyDown1(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_desc_KeyDown1(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If e.KeyData = Keys.Down Then
            nup_digitos.Focus()
        ElseIf e.KeyData = Keys.Up Then
            txt_cod.Focus()
        End If
    End Sub
    Function VERIFICACION_ELIMINAR(ByVal COD As Object) As String
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_ELIMINAR_NIVEL_CUENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_NIVEL", SqlDbType.Char).Value = COD
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return (CONT)
    End Function
End Class