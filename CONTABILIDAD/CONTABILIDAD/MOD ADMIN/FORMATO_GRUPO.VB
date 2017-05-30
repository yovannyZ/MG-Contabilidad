Imports System.Data.SqlClient
Public Class FORMATO_GRUPO
    Dim boton, clase, formato As String
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
        Dim COD_CLASE As String = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse(VERIFICACION_ELIMINAR(COD_CLASE)) > 0) Then
            MessageBox.Show("El Grupo tiene detalles", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & COD_CLASE & " " & dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                Try
                    Dim CMD As New SqlCommand("ELIMINAR_GRUPO_FORMATO", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = COD_CLASE
                    CMD.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
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
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (Strings.Trim(txt_desc_total.Text) = "")) Or (cbo_formato.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Select Case cbo_clase.SelectedIndex
                Case 0
                    clase = "A"

                Case 1
                    clase = "P"

                Case 2
                    clase = "R"

                Case Else
                    clase = " "

            End Select
            If (CONTAR_REG > 0) Then
                MessageBox.Show("El codigo de Grupo ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                Try
                    Dim CMD As New SqlCommand("INSERTAR_GRUPO_FORMATO", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = txt_cod.Text
                    CMD.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = formato
                    CMD.Parameters.Add("@DESC_GRUPO", SqlDbType.VarChar).Value = txt_desc.Text
                    CMD.Parameters.Add("@DESC_TOTAL", SqlDbType.VarChar).Value = txt_desc_total.Text
                    CMD.Parameters.Add("@COD_CLASE", SqlDbType.VarChar).Value = clase
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("El Grupo se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LIMPIAR()
                    cbo_formato.Select()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
                datagrid()
                SGT_CODIGO()
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
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.Enabled = False
        cbo_formato.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (Strings.Trim(txt_desc_total.Text) = "")) Or (cbo_formato.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Select Case cbo_clase.SelectedIndex
                Case 0
                    clase = "A"

                Case 1
                    clase = "P"

                Case 2
                    clase = "R"

                Case Else
                    clase = " "

            End Select
            Try
                Dim CMD As New SqlCommand("MODIFICAR_GRUPO_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = formato
                CMD.Parameters.Add("@DESC_GRUPO", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@DESC_TOTAL", SqlDbType.VarChar).Value = txt_desc_total.Text
                CMD.Parameters.Add("@COD_CLASE", SqlDbType.VarChar).Value = clase
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Grupo se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(13) = 0
        Close()
    End Sub

    Sub CARGAR_DATOS()
        formato = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        cbo_formato.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_cod.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_total.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        clase = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        Dim VAR1 As String = clase
        If (VAR1 = "A") Then
            cbo_clase.SelectedIndex = 0
        ElseIf (VAR1 = "P") Then
            cbo_clase.SelectedIndex = 1
        ElseIf (VAR1 = "R") Then
            cbo_clase.SelectedIndex = 2
        Else
            cbo_clase.SelectedIndex = -1
        End If
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

    Private Sub cbo_formato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_formato.SelectedIndexChanged
        If (cbo_formato.SelectedIndex <> -1) Then
            formato = OBJ.COD_FORMATO(cbo_formato.Text)
            If (OBJ.TIPO_FORMATO(formato) = "BA") Then
                cbo_clase.Enabled = True
                cbo_clase.SelectedIndex = -1
            Else
                cbo_clase.Enabled = False
                cbo_clase.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CLASE_ARTICULO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        cargar_formato()
        btn_nuevo.Select()
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_GRUPO_FORMATO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = txt_cod.Text
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = formato
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
            Dim cmd As New SqlCommand("mostrar_GRUPO_FORMATO", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(1).Visible = False
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(0).Width = &H37
            dgw1.Columns.Item(2).Width = 30
            dgw1.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc_total.Clear()
        'cbo_formato.SelectedIndex = -1
        'cbo_clase.SelectedIndex = -1
        txt_cod.Enabled = True
        txt_desc.Enabled = True
        txt_desc_total.Enabled = True
        cbo_formato.Enabled = True
    End Sub

    Private Sub PROYECTO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_GRUPO_FORMATO", con)
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
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
                txt_cod.Enabled = False
                txt_desc.Enabled = False
                txt_desc_total.Enabled = False
                cbo_formato.Enabled = False
                cbo_clase.Enabled = False
            End If
        End If
    End Sub

    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub

    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc_total.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub

    Private Sub txt_desc_total_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_total.KeyDown
        If (e.KeyData = Keys.Down) Then
            cbo_clase.Select()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_desc.Focus()
        End If
    End Sub

    Function VERIFICACION_ELIMINAR(ByVal COD As Object) As String
        Dim CONT As Integer = 0
        Try
            Dim PROG_02 As New SqlCommand("VERIFICAR_ELIMINAR_GRUPO_FORMATO", con)
            PROG_02.CommandType = CommandType.StoredProcedure
            PROG_02.Parameters.Add("@COD_GRUPO", SqlDbType.VarChar).Value = (COD)
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