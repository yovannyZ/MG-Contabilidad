Imports System.Data.SqlClient
Public Class FORMATO_RELACION
    Dim boton, detalle, formato, grupo, st_por As String
    Private obj As New Class1
    Private Sub btn_agregar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_agregar.Click
        If (cbo_formato.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Formato", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_formato.Select()
        ElseIf (cbo_grupo.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Grupo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_grupo.Select()
        ElseIf ((boton = "NUEVO") AndAlso (CONTAR_REG() > 0)) Then
            MessageBox.Show("La Releción de Formato ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_formato.Select()
        Else
            LIMPIAR_DETALLES()
            cbo_formato.Enabled = False
            cbo_grupo.Enabled = False
            Panel1.Visible = False
            Panel2.Visible = True
            cargar_detalle()
            cbo_detalle.Select()
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
        LIMPIAR_CABECERA()
    End Sub

    Private Sub btn_cancelar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar2.Click
        Panel1.Visible = True
        Panel2.Visible = False
        btn_agregar.Select()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Return

        End Try
        Dim COD_FOR0 As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        Dim COD_GRU0 As String = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show("Eliminar la Releción de Formato", "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_RELACION_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FOR0
                CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = COD_GRU0
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

    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw_det.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_agregar.Select()

            Return

        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Eliminar el detalle de la Releción de Formato", "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index)
        End If
        btn_agregar.Select()
    End Sub

    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar.Click
        If (dgw_det.Rows.Count = 0) Then
            MessageBox.Show("No existen detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_agregar.Select()
        ElseIf (INSERTAR_TODO = "FALLO") Then
            MessageBox.Show("Vuelva a Intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_grabar.Focus()
        Else
            MessageBox.Show("La Relación del Formato se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DATAGRID()
            TabControl1.SelectedTab = TabPage1
            LIMPIAR_CABECERA()
            Panel2.Visible = False
            Panel1.Visible = True
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub btn_grabar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar2.Click
        If (dgw_det.Rows.Count = 0) Then
            MessageBox.Show("No existen detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_agregar.Select()
        ElseIf (MODIFICAR_TODO = "FALLO") Then
            MessageBox.Show("Vuelva a Intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_grabar.Focus()
        Else
            MessageBox.Show("La Relación del Formato se actualizó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DATAGRID()
            TabControl1.SelectedTab = TabPage1
            LIMPIAR_CABECERA()
            Panel2.Visible = False
            Panel1.Visible = True
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub btn_guardar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar2.Click
        If (cbo_detalle.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_detalle.Select()
        ElseIf (Strings.Trim(txt_cod_cta.Text) = "") Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta.Focus()
        Else
            If ch_por.Checked Then
                st_por = "1"
            Else
                st_por = "0"
            End If
            If VALIDAR_DET = False Then
                MessageBox.Show("El detalle de Releción de Formato ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_detalle.Select()
            Else
                dgw_det.Rows.Add(detalle, cbo_detalle.Text, txt_cod_cta.Text, txt_desc_cta.Text, ch_por.Checked)
                Panel1.Visible = True
                Panel2.Visible = False
                btn_agregar.Select()
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
        btn_grabar.Visible = False
        btn_grabar2.Visible = True
        LIMPIAR_CABECERA()
        CARGAR_DATOS()
        DATAGRID1()
        cbo_formato.Enabled = False
        cbo_grupo.Enabled = False
        TabControl1.SelectedTab = TabPage2
        btn_agregar.Select()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click, btn_nuevo2.Click
        boton = "NUEVO"
        LIMPIAR_CABECERA()
        btn_grabar.Visible = True
        btn_grabar2.Visible = False
        TabControl1.SelectedTab = TabPage2
        Panel1.Visible = True
        Panel2.Visible = False
        cbo_formato.Select()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(19) = 0
        Close()
    End Sub

    Sub cargar_cuentas()
        Try
            Dim pro As New SqlCommand("DGW_CUENTAS", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw_cta.DataSource = dt
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = &H4B
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Sub CARGAR_DATOS()
        formato = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        cbo_formato.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        grupo = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_grupo.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Sub cargar_detalle()
        cbo_detalle.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_DETALLE_FORMATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
            PROG_01.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_detalle.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
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

    Private Sub cbo_formato_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_formato.SelectedIndexChanged
        If (cbo_formato.SelectedIndex = -1) Then
            cbo_grupo.Items.Clear()
        Else
            formato = OBJ.COD_FORMATO(cbo_formato.Text)
            cargar_grupo()
        End If
    End Sub

    Private Sub cbo_grupo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_grupo.SelectedIndexChanged
        If (cbo_grupo.SelectedIndex <> -1) Then
            grupo = OBJ.COD_GRUPO_FORMATO(cbo_grupo.Text, formato)
        End If
    End Sub

    Private Sub cbo_ORDEN_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_detalle.SelectedIndexChanged
        If (cbo_detalle.SelectedIndex <> -1) Then
            detalle = OBJ.COD_DETALLE_FORMATO(cbo_detalle.Text, formato, grupo)
        End If
    End Sub

    Private Sub COMPONENTES_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub COMPONENTES_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw_det.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DATAGRID()
        cargar_formato()
        cargar_cuentas()
        btn_nuevo.Select()
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_RELACION_FORMATO", con)
            CMD.CommandType = CommandType.StoredProcedure
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

    Sub DATAGRID()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_RELACION_FORMATO", con)
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("formato")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Sub DATAGRID1()
        dgw_det.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_RELACION_FORMATO_DETALLES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
            PROG_01.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_det.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub dgw2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            panel_cta.Visible = False
            K1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cta.Visible = False
            txt_cod_cta.Clear()
            txt_desc_cta.Clear()
            txt_cod_cta.Focus()
        End If
    End Sub
    Function INSERTAR_TODO() As String
        Dim ESTADO As String = "FALLO"
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw_det.Item(4, I).Value.ToString = "True") Then
                st_por = "1"
            Else
                st_por = "0"
            End If
            Try
                Dim CMD As New SqlCommand("INSERTAR_RELACION_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
                CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
                CMD.Parameters.Add("@COD_DETALLE", SqlDbType.Char).Value = dgw_det.Item(0, I).Value.ToString
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = dgw_det.Item(2, I).Value.ToString
                CMD.Parameters.Add("@STATUS_POR", SqlDbType.Char).Value = st_por
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)
                ESTADO = "FALLO"

            End Try
            I += 1
        Loop
        Return "EXITO"
    End Function

    Sub LIMPIAR_CABECERA()
        'cbo_formato.SelectedIndex = -1
        cbo_grupo.SelectedIndex = -1
        cbo_formato.Enabled = True
        cbo_grupo.Enabled = True
        Panel1.Visible = True
        Panel2.Visible = False
        dgw_det.Rows.Clear()
    End Sub

    Sub LIMPIAR_DETALLES()
        cbo_detalle.SelectedIndex = -1
        txt_cod_cta.Clear()
        txt_desc_cta.Clear()
        ch_por.Checked = False
    End Sub

    Function MODIFICAR_TODO() As String
        Try
            Dim CMD As New SqlCommand("ELIMINAR_RELACION_FORMATO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
            CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Dim ESTADO As String = "FALLO"
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw_det.Item(4, I).Value.ToString = "True") Then
                st_por = "1"
            Else
                st_por = "0"
            End If
            Try
                Dim CMD As New SqlCommand("INSERTAR_RELACION_FORMATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = formato
                CMD.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = grupo
                CMD.Parameters.Add("@COD_DETALLE", SqlDbType.Char).Value = dgw_det.Item(0, I).Value.ToString
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = dgw_det.Item(2, I).Value.ToString
                CMD.Parameters.Add("@STATUS_POR", SqlDbType.Char).Value = st_por
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
                ESTADO = "FALLO"
            End Try
            I += 1
        Loop
        Return "EXITO"
    End Function

    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) = "") Then
            txt_desc_cta.Focus()
        ElseIf (dgw_cta.RowCount = 0) Then
            MessageBox.Show("No existen cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim CONT As Integer = (dgw_cta.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= CONT)
                'If (txt_cod_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                '    txt_cod_cta.Text = dgw_cta.Item(0, i).Value.ToString
                '    txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                '    ch_por.Focus()
                '    Return
                'End If
                If (txt_cod_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta.Text)).ToLower) Then
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                i += 1
            Loop
            panel_cta.Visible = True
            dgw_cta.Focus()
        End If
    End Sub

    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txt_desc_cta.Text) = "") Then
                ch_por.Select()
            ElseIf (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Function VALIDAR_DET() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If ((detalle = dgw_det.Item(0, I).Value.ToString) And (txt_cod_cta.Text = dgw_det.Item(2, I).Value.ToString)) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function

    Private Sub txt_cod_cta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cta.TextChanged

    End Sub
End Class