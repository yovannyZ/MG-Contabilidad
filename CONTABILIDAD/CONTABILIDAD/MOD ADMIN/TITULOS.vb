Imports System.Data.SqlClient
Public Class TITULOS
    Dim boton As String
    Dim E1 As Boolean
    Dim item As String
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
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
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (MessageBox.Show(("ELIMINAR " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) = 6 Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_TITULO", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = (COD_CLASE)
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

    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        GRABAR()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Exit Sub
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.ReadOnly = True
        TabControl1.SelectedTab = (TabPage2)
        txt_linea1.Focus()

    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        modificar()

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        TabControl1.SelectedTab = (TabPage2)
        txt_cod.Focus()

    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(8) = 0
        Close()

    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_linea1.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_linea2.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_des.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_TITULO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = (txt_cod.Text)
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
            Dim cmd As New SqlCommand("MOSTRAR_TITULOS", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("TITULOS")
            adap.Fill(dt)
            dgw1.DataSource = (dt)
            dgw1.Columns(0).Width = (35)
            dgw1.Columns(1).Width = (200)
            dgw1.Columns(2).Width = (300)
            dgw1.Columns(3).Width = (300)
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
        Catch ex As Exception


            'MsgBox(ex.Message)
            MsgBox(ex.Message)

        End Try
    End Sub

    Sub GRABAR()
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_linea1.Text) = "") Then
            MessageBox.Show("Debe insertar al menos una línea", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_linea1.Focus()
        ElseIf (CONTAR_REG() > 0) Then
            MessageBox.Show("El código de Reporte ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("INSERTAR_TITULO", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = (txt_cod.Text)
                CMD.Parameters.Add("@LINEA1", SqlDbType.VarChar).Value = (txt_linea1.Text)
                CMD.Parameters.Add("@LINEA2", SqlDbType.VarChar).Value = (txt_linea2.Text)
                CMD.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = (txt_des.Text)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Título se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR()
                TabControl1.SelectedTab = (TabPage1)
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)
                'MsgBox(ex.Message)

            End Try
            DATAGRID()
            btn_nuevo.Select()
        End If
    End Sub

    Sub LIMPIAR()
        txt_cod.Clear()
        txt_des.Clear()
        txt_linea1.Clear()
        txt_linea2.Clear()
        txt_cod.ReadOnly = False
        txt_des.ReadOnly = False
        txt_linea1.ReadOnly = False
        txt_linea2.ReadOnly = False
    End Sub

    Sub modificar()
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el codigo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_linea1.Text) = "") Then
            MessageBox.Show("Debe insertar al menos una línea", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_linea1.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_TITULO", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_REPORTE", SqlDbType.VarChar).Value = (txt_cod.Text)
                CMD.Parameters.Add("@LINEA1", SqlDbType.VarChar).Value = (txt_linea1.Text)
                CMD.Parameters.Add("@LINEA2", SqlDbType.VarChar).Value = (txt_linea2.Text)
                CMD.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = (txt_des.Text)
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Título se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = (TabPage1)
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
            btn_nuevo.Select()
        End If
    End Sub
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
                txt_des.ReadOnly = True
                txt_linea1.ReadOnly = True
                txt_linea2.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub TITULOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub TITULOS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        btn_nuevo.Select()
    End Sub
End Class