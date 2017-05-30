Imports System.Data.SqlClient
Public Class PERSONA_RENTA
    Dim obj As New Class1
    Dim boton As String

    Private Sub PERSONA_RENTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PERSONA_RENTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        DataGrid()
        DGW_PERSONAS()
        btn_nuevo.Select()
    End Sub
    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONA_RENTA", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("persona_renta")
            adap.Fill(dt)
            dgw1.DataSource = dt
            'dgw1.Columns(2).Visible = False
            dgw1.Columns(3).Visible = False
            dgw1.Columns(4).Visible = False
            dgw1.Columns(5).Visible = False
            dgw1.Columns(6).Visible = False
            dgw1.Columns(7).Visible = False
            dgw1.Columns(8).Visible = False
            dgw1.Columns(0).Width = 60
            dgw1.Columns(1).Width = 270
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DGW_PERSONAS()
        Try
            dgw_per.DataSource = obj.MOSTRAR_PERSONAS_TODAS
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub txt_cod_per0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per0.LostFocus
        If (Strings.Trim(txt_cod_per0.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_per0.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per0.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        dtp_ini.Focus()
                        Return
                    End If
                    If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            TXT_KLP.Focus()
            Panel_per.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per.Visible = False
            txt_cod_per0.Focus()
            txt_cod_per0.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per0.Focus()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(39) = 0
        Me.Close()
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        LIMPIAR()
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        TabControl1.SelectedTab = TabPage2
        txt_cod_per0.Focus()
    End Sub
    Sub LIMPIAR()
        txt_cod_per0.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        txt_servicio.Clear()
        Panel_per.Visible = False
        R1.Checked = False
        R2.Checked = False
        A1.Checked = False
        A2.Checked = False
        S1.Checked = False
        S2.Checked = False
        ch_s.Checked = False
        txt_cod_per0.Enabled = True
        txt_desc_per.Enabled = True
        txt_doc_per.Enabled = True
        txt_servicio.Enabled = True
    End Sub
    Private Sub btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Modificar.Click
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
        txt_cod_per0.Enabled = False
        txt_desc_per.Enabled = False
        txt_doc_per.Enabled = False
        Panel_per.Visible = False
        TabControl1.SelectedTab = TabPage2
        dtp_ini.Focus()
    End Sub
    Sub CARGAR_DATOS()
        txt_cod_per0.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_per.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_doc_per.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        dtp_ini.Value = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_servicio.Text = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString

        Dim SEXO, DOMICILIADO, ESSALUD, SUS As String
        '------------------------------------------------------------------------------
        SEXO = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        If SEXO = "1" Then S1.Checked = True Else S2.Checked = True
        '------------------------------------------------------------------------------
        ESSALUD = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        If ESSALUD = "1" Then A1.Checked = True Else A2.Checked = True
        '------------------------------------------------------------------------------
        DOMICILIADO = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        If DOMICILIADO = "1" Then R1.Checked = True Else R2.Checked = True
        '------------------------------------------------------------------------------
        SUS = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        If SUS = "1" Then ch_s.Checked = True Else ch_s.Checked = False
        '------------------------------------------------------------------------------
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Trim(txt_cod_per0.Text) = "" Then MessageBox.Show("Debe elegir la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per0.Focus() : Exit Sub
        If S1.Checked = False And S2.Checked = False Then MessageBox.Show("Debe elegir el sexo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : S1.Focus() : Exit Sub
        If A1.Checked = False And A2.Checked = False Then MessageBox.Show("Debe elegir la afiliacion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : A1.Focus() : Exit Sub
        If R1.Checked = False And R2.Checked = False Then MessageBox.Show("Debe elegir la condicion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : R1.Focus() : Exit Sub
        If CONTAR_REG() > 0 Then
            MessageBox.Show("El código de Persona ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
            Exit Sub
        End If
        Dim SEXO, DOMICILIADO, ESSALUD, SUS As String
        If S1.Checked = True Then SEXO = "1" Else SEXO = "2"
        If A1.Checked = True Then ESSALUD = "1" Else ESSALUD = "0"
        If R1.Checked = True Then DOMICILIADO = "1" Else DOMICILIADO = "2"
        If ch_s.Checked = True Then SUS = "1" Else SUS = "0"
        Try
            Dim CMD As New SqlCommand("MANTENIMIENTO_PERSONA_RENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST", SqlDbType.Char).Value = "1"
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per0.Text
            CMD.Parameters.Add("@FEC_NAC", SqlDbType.DateTime).Value = dtp_ini.Value
            CMD.Parameters.Add("@SEXO", SqlDbType.Char).Value = SEXO
            CMD.Parameters.Add("@IND_ESSALUD", SqlDbType.Char).Value = ESSALUD
            CMD.Parameters.Add("@IND_DOMICILIADO", SqlDbType.Char).Value = DOMICILIADO
            CMD.Parameters.Add("@IND_SUSPENCION", SqlDbType.Char).Value = SUS
            CMD.Parameters.Add("@SERVICIO_PRESTADO", SqlDbType.VarChar).Value = txt_servicio.Text
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("La persona - renta se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR()
            txt_cod_per0.Focus()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PERSONA_RENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per0.Text
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        Dim SEXO, DOMICILIADO, ESSALUD, SUS As String
        If S1.Checked = True Then SEXO = "1" Else SEXO = "2"
        If A1.Checked = True Then ESSALUD = "1" Else ESSALUD = "0"
        If R1.Checked = True Then DOMICILIADO = "1" Else DOMICILIADO = "2"
        If ch_s.Checked = True Then SUS = "1" Else SUS = "0"
        Try
            Dim CMD As New SqlCommand("MANTENIMIENTO_PERSONA_RENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST", SqlDbType.Char).Value = "2"
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod_per0.Text
            CMD.Parameters.Add("@FEC_NAC", SqlDbType.DateTime).Value = dtp_ini.Value
            CMD.Parameters.Add("@SEXO", SqlDbType.Char).Value = SEXO
            CMD.Parameters.Add("@IND_ESSALUD", SqlDbType.Char).Value = ESSALUD
            CMD.Parameters.Add("@IND_DOMICILIADO", SqlDbType.Char).Value = DOMICILIADO
            CMD.Parameters.Add("@IND_SUSPENCION", SqlDbType.Char).Value = SUS
            CMD.Parameters.Add("@SERVICIO_PRESTADO", SqlDbType.VarChar).Value = txt_servicio.Text
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("La Persona - Renta se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedTab = TabPage1
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()
        btn_nuevo.Select()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Exit Sub
        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString

        Dim RSPTA As String = MessageBox.Show("ELIMINAR " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString, "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If RSPTA = vbYes Then
            'ELIMINAR
            Try
                Dim CMD As New SqlCommand("ELIMINAR_PERSONA_RENTA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_CLASE
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
End Class