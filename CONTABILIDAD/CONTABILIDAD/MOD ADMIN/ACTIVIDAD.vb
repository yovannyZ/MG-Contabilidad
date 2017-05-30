Imports System.Data.SqlClient
Public Class ACTIVIDAD
    Dim boton, cod_tipo As String
    Dim obj As New Class1
    Private Sub ACTIVIDAD_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ACTIVIDAD_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        btn_nuevo.Select()
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub
    Private Sub btn_cancelar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles btn_cancelar.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_ACTIVIDAD", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = COD_CLASE
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
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If ((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Then
            MessageBox.Show("Ingrese los datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (CONTAR_REG() > 0) Then
            MessageBox.Show("El código de la Actividad ya existe", "Ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("INSERTAR_ACTIVIDAD", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_ACTIVIDAD", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La Actividad se guardó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Exit Sub
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
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        txt_desc2.ReadOnly = False
        txt_obs.Clear()
        txt_obs.ReadOnly = False
    End Sub
    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_ACTIVIDAD", con)
            con.Open()
            SGT = CMD.ExecuteScalar.ToString
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (SGT = "") Then
            txt_cod.Text = "00001"
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
                txt_cod.ReadOnly = True
                txt_desc.ReadOnly = True
                txt_desc2.ReadOnly = True
                txt_obs.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
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
            txt_desc2.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If ((e.KeyData <> Keys.Down) AndAlso (e.KeyData = Keys.Up)) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_obs_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_obs.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{TAB}")
        ElseIf (e.KeyData = Keys.Up) Then
            txt_desc2.Focus()
        End If
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Then
            MessageBox.Show("Ingrese los datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            Try
                Dim CMD As New SqlCommand("MODIFICAR_ACTIVIDAD", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_ACTIVIDAD", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La actividad se actualizó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        main(58) = 0
        Close()
    End Sub
    Private Sub btn_transf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_transf.Click
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de realizar la Transferencia de Costos a Gestión Comercial ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim cmd1 As New SqlCommand(("INSERT INTO ACTIVIDAD (COD_ACTIVIDAD,DESC_ACTIVIDAD,DESC_CORTA,OBSERVACION)SELECT B.COD_ACTIVIDAD,B.DESC_ACTIVIDAD,B.DESC_CORTA,B.OBSERVACION  FROM  BD_COS" & COD_EMPRESA & ".dbo.ACTIVIDAD AS B WHERE B.COD_ACTIVIDAD NOT IN (SELECT COD_ACTIVIDAD FROM ACTIVIDAD )"), con)
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        datagrid()
    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_obs.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_ACTIVIDAD", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = txt_cod.Text
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
            Dim cmd As New SqlCommand("MOSTRAR_ACTIVIDAD", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns(0).Width = 80
            dgw1.Columns(1).Width = 150
            dgw1.Columns(2).Width = 100
            dgw1.Columns(3).Visible = False
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class