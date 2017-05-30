Imports System.Data.SqlClient
Public Class FORMATO
    Private boton As String
    Private OBJ As New Class1
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
            MessageBox.Show("El Formato tiene Grupo", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                Try
                    Dim CMD As New SqlCommand("ELIMINAR_FORMATO", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_CLASE
                    con.Open()
                    CMD.ExecuteNonQuery()
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
        If (((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_tipo.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (CONTAR_REG > 0) Then
            MessageBox.Show("El codigo de Formato ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("INSERTAR_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_FORMATO", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = cbo_tipo.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Formato de guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
                txt_cod.Focus()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            datagrid()
            SGT_CODIGO()
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
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_tipo.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_FORMATO", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = cbo_tipo.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Formato se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        SGT_CODIGO()
        TabControl1.SelectedTab = TabPage2
        txt_cod.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(15) = 0
        Close()
    End Sub

    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        cbo_tipo.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_obs.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Private Sub CLASE_ARTICULO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        btn_nuevo.Select()
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_FORMATO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = txt_cod.Text
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
            Dim cmd As New SqlCommand("MOSTRAR_FORMATO", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(0).Width = 30
            dgw1.Columns.Item(3).Width = 35
            dgw1.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_obs.Clear()
        cbo_tipo.SelectedIndex = -1
        txt_cod.Enabled = True
        txt_desc.Enabled = True
        txt_obs.Enabled = True
        cbo_tipo.Enabled = True
    End Sub

    Private Sub PROYECTO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_FORMATO", con)
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

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
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
                txt_cod.Enabled = False
                txt_desc.Enabled = False
                txt_obs.Enabled = False
                cbo_tipo.Enabled = False
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
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
            cbo_tipo.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub

    Private Sub txt_obs_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_obs.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{TAB}")
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_tipo.Select()
        End If
    End Sub

    Function VERIFICACION_ELIMINAR(ByVal COD As Object) As String
        Dim CONT As Integer = 0
        Try
            Dim PROG_02 As New SqlCommand("VERIFICAR_ELIMINAR_FORMATO", con)
            PROG_02.CommandType = CommandType.StoredProcedure
            PROG_02.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = (COD)
            con.Open()
            CONT = PROG_02.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return (CONT)
    End Function


End Class