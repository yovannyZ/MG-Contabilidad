Imports System.Data.SqlClient
Public Class FORMATO_DETALLE
    Dim boton, formato, grupo As String
    Private OBJ As New Class1

    Private Sub btn_cancelar_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
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
        Dim COD_CLASE As String = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse(VERIFICACION_ELIMINAR(COD_CLASE)) > 0) Then
            MessageBox.Show("El Formato Detalle tiene relación", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & COD_CLASE & " " & dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                Try
                    Dim pro04 As New SqlCommand("ELIMINAR_DETALLE_FORMATO", con)
                    pro04.CommandType = CommandType.StoredProcedure
                    pro04.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
                    pro04.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
                    pro04.Parameters.Add("@COD_DETALLE", SqlDbType.Char).Value = COD_CLASE
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

    Private Sub btn_guardar_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_formato.SelectedIndex = -1)) Or (cbo_grupo.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (CONTAR_REG > 0) Then
            MessageBox.Show("El codigo de Detalle ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("INSERTAR_DETALLE_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_DETALLE", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
                CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
                CMD.Parameters.Add("@DESC_DETALLE", SqlDbType.VarChar).Value = txt_desc.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Detalle se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
                cbo_formato.Select()
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
        cargar_datos()
        txt_cod.Enabled = False
        cbo_formato.Enabled = False
        cbo_grupo.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub

    Private Sub btn_modificar2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_formato.SelectedIndex = -1)) Or (cbo_grupo.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_DETALLE_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_DETALLE", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
                CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
                CMD.Parameters.Add("@DESC_DETALLE", SqlDbType.VarChar).Value = txt_desc.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Detalle se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        cbo_formato.Select()
    End Sub

    Private Sub btn_Salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(16) = 0
        Close()
    End Sub

    Sub cargar_datos()
        formato = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        cbo_formato.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        grupo = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_grupo.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_cod.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Sub cargar_formato()
        cbo_formato.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_FORMATO", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_formato.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Sub cargar_grupo()
        cbo_grupo.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_GRUPO_FORMATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_grupo.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cbo_formato_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_formato.SelectedIndexChanged
        If (cbo_formato.SelectedIndex = -1) Then
            cbo_grupo.Items.Clear()
        Else
            formato = OBJ.COD_FORMATO(cbo_formato.Text)
            cargar_grupo()
        End If
    End Sub

    Private Sub cbo_grupo_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_grupo.SelectedIndexChanged
        If (cbo_grupo.SelectedIndex <> -1) Then
            grupo = OBJ.COD_GRUPO_FORMATO(cbo_grupo.Text, formato)
        End If
    End Sub

    Private Sub Comprobante_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Comprobante_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        cargar_formato()
        btn_nuevo.Select()
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_DETALLE_FORMATO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_DETALLE", SqlDbType.Char).Value = txt_cod.Text
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
            CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
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
            Dim pro As New SqlCommand("MOSTRAR_DETALLE_FORMATO", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(1).Visible = False
            'dgw1.Columns.Item(3).Visible = False
            dgw1.Columns.Item(0).Width = &H37
            dgw1.Columns.Item(2).Width = &H2D
            dgw1.Columns.Item(4).Width = 30
            dgw1.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        'cbo_formato.SelectedIndex = -1
        'cbo_grupo.SelectedIndex = -1
        txt_cod.Enabled = True
        txt_desc.Enabled = True
        cbo_formato.Enabled = True
        cbo_grupo.Enabled = True
    End Sub

    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_DETALLE_FORMATO", con)
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
                    cargar_datos()
                End If
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
                txt_cod.Enabled = False
                txt_desc.Enabled = False
                cbo_formato.Enabled = False
                cbo_grupo.Enabled = False
            End If
        End If
    End Sub

    Private Sub txt_cod_KeyDown1(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub

    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{TAB}")
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub

    Function VERIFICACION_ELIMINAR(ByVal COD As Object) As String
        Dim CONT As Integer = 0
        Try
            Dim PROG_02 As New SqlCommand("VERIFICAR_ELIMINAR_DETALLE_FORMATO", con)
            PROG_02.CommandType = CommandType.StoredProcedure
            PROG_02.Parameters.Add("@COD_DETALLE", SqlDbType.VarChar).Value = (COD)
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