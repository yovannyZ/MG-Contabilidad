Imports System.Data.SqlClient
Public Class DIRECTORIO
    Dim boton, btn, MONEDA As String
    Private Sub ART_PROV_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ART_PROV_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
        DATAGRID()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CANCELAR.Click
        TabControl1.SelectedTab = TabPage1
        DATAGRID()
        btn_nuevo.Select()
    End Sub

    Private Sub btn_cancelar2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar2.Click
        Panel2.Visible = False
        Panel1.Visible = True
        BTN_CANCELAR.Visible = True
        BTN_CANCELAR.Text = "&Salir"
        btn_nuevo2.Select()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        Dim cod As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & cod & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim cmd As New SqlCommand("ELIMINAR_DIRECTORIO_TABLA", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = cod
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                DATAGRID()
                btn_nuevo.Select()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
        End If
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = Integer.Parse(dgw.CurrentRow.Index.ToString)
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        Dim cod As String = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & cod & " " & dgw.Item(1, dgw.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            dgw.Rows.RemoveAt(dgw.CurrentRow.Index)
            Try
                Dim CMD As New SqlCommand("ELIMINAR_DIRECTORIO_TABLA_DET", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@tabla_cod", SqlDbType.VarChar).Value = txt_cod.Text
                CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = cod
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
        End If
        btn_nuevo2.Select()
    End Sub

    Private Sub btn_guardar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar2.Click
        If ((Strings.Trim(TXT_COD_det.Text) = "") Or (Strings.Trim(TXT_DESC_det.Text) = "")) Then
            MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD_det.Focus()
        Else
            Dim i1 As Integer = 0
            Dim cont1 As Integer = (dgw.RowCount - 1)
            Dim CONT0 As Integer = cont1
            i1 = 0
            Do While (i1 <= CONT0)
                If (dgw.Item(0, i1).Value.ToString = TXT_COD_det.Text) Then
                    MessageBox.Show("El codigo de Dato ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TXT_COD_det.Focus()
                    Return
                End If
                i1 += 1
            Loop
            dgw.Rows.Add(TXT_COD_det.Text, TXT_DESC_det.Text, txt_obs_det.Text)
            Try
                Dim CMD As New SqlCommand("INSERTAR_DIRECTORIO_DATO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@tabla_cod", SqlDbType.VarChar).Value = txt_cod.Text
                CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = dgw.Item(0, i1).Value.ToString
                CMD.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = dgw.Item(1, i1).Value.ToString
                CMD.Parameters.Add("@observacion", SqlDbType.VarChar).Value = dgw.Item(2, i1).Value.ToString
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            MessageBox.Show("Exito al guardar", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_detalle()
            Panel2.Visible = False
            Panel1.Visible = True
            BTN_CANCELAR.Visible = True
            BTN_CANCELAR.Text = "&Salir"
            btn_nuevo2.Select()
        End If
    End Sub

    Private Sub btn_mod2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod2.Click
        Try
            Dim i As Integer = Integer.Parse(dgw.CurrentRow.Index.ToString)
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        btn = "MODIFICAR"
        LIMPIAR_detalle()
        btn_guardar2.Visible = False
        BTN_CANCELAR.Visible = False
        btn_modificar2.Visible = True
        item1.Text = dgw.CurrentRow.Index.ToString
        Panel1.Visible = False
        Panel2.Visible = True
        CARGAR_detalle()
        TXT_COD_det.ReadOnly = True
        TXT_DESC_det.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        boton = "MODIFICAR"
        LIMPIAR_CABECERA()
        CARGAR_CABECERA()
        datagrid1()
        TabControl1.SelectedTab = TabPage2
        Panel1.Visible = True
        Panel2.Visible = False
        j1.Enabled = False
        BTN_CANCELAR.Visible = True
        BTN_CANCELAR.Text = "&Cancelar"
        btn_nuevo2.Select()
    End Sub

    Private Sub btn_modificar2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((Strings.Trim(TXT_COD_det.Text) = "") Or (Strings.Trim(TXT_DESC_det.Text) = "")) Then
            MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD_det.Focus()
        Else
            Dim FILA As Integer = Integer.Parse(item1.Text)
            dgw.Item(0, FILA).Value = TXT_COD_det.Text
            dgw.Item(1, FILA).Value = TXT_DESC_det.Text
            dgw.Item(2, FILA).Value = txt_obs_det.Text
            Try
                Dim CMD As New SqlCommand("MODIFICAR_DIRECTORIO_TABLA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@tabla_cod", SqlDbType.VarChar).Value = txt_cod.Text
                CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = TXT_COD_det.Text
                CMD.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = TXT_DESC_det.Text
                CMD.Parameters.Add("@observacion", SqlDbType.VarChar).Value = txt_obs_det.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            MessageBox.Show("Exito al guardar", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_detalle()
            Panel2.Visible = False
            Panel1.Visible = True
            BTN_CANCELAR.Visible = True
            BTN_CANCELAR.Text = "&Salir"
            btn_nuevo2.Select()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        LIMPIAR_CABECERA()
        LIMPIAR_detalle()
        TabControl1.SelectedTab = TabPage2
        Panel1.Visible = True
        Panel2.Visible = False
        BTN_CANCELAR.Visible = True
        BTN_CANCELAR.Text = "&Cancelar"
        txt_cod.Focus()
    End Sub

    Private Sub btn_nuevo2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo2.Click
        If (((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("0"))) Then
            MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            If (((boton = "NUEVO") And (dgw.Rows.Count = 0)) And j1.Enabled) Then
                If verificar_TABLA() > 0 Then
                    MessageBox.Show("El Codigo de Tabla ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_cod.Focus()
                    Return
                End If
                Try
                    Dim CMD As New SqlCommand("INSERTAR_DIRECTORIO_TABLA", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@tabla_cod", SqlDbType.VarChar).Value = txt_cod.Text
                    CMD.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = txt_desc.Text
                    CMD.Parameters.Add("@observacion", SqlDbType.VarChar).Value = nup_obs.Value
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
            End If
            btn = "NUEVO"
            LIMPIAR_detalle()
            btn_guardar2.Visible = True
            btn_modificar2.Visible = False
            BTN_CANCELAR.Visible = False
            Panel1.Visible = False
            Panel2.Visible = True
            j1.Enabled = False
            TXT_COD_det.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(22) = 0
        Close()
    End Sub

    Sub CARGAR_CABECERA()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        nup_obs.Value = Decimal.Parse(dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString)
    End Sub

    Sub CARGAR_detalle()
        TXT_COD_det.Text = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        TXT_DESC_det.Text = dgw.Item(1, dgw.CurrentRow.Index).Value.ToString
        txt_obs_det.Text = dgw.Item(2, dgw.CurrentRow.Index).Value.ToString
    End Sub

    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_DIRECTORIO_TABLA", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("DIR")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns.Item(1).Visible = False
            dgw1.Columns.Item(3).Visible = False
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Width = 50
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Sub datagrid1()
        dgw.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_DIRECTORIO_DATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = txt_cod.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Sub LIMPIAR_CABECERA()
        txt_cod.Clear()
        txt_desc.Clear()
        nup_obs.Value = Decimal.Parse("0")
        j1.Enabled = True
        BTN_CANCELAR.Visible = True
        BTN_CANCELAR.Visible = True
        Panel1.Enabled = True
        dgw.Rows.Clear()
    End Sub

    Sub LIMPIAR_detalle()
        TXT_COD_det.Clear()
        TXT_DESC_det.Clear()
        txt_obs_det.Clear()
        btn_modificar2.Visible = True
        btn_guardar2.Visible = True
        btn_cancelar2.Visible = True
        TXT_COD_det.ReadOnly = False
        TXT_DESC_det.ReadOnly = False
        txt_obs_det.ReadOnly = False
    End Sub

    Private Sub nup_obs_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nup_obs.ValueChanged
        If (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("1")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("1")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("2")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("2")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("3")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("3")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("4")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("4")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("5")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("5")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("6")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("6")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("7")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("7")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("8")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("8")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("9")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("9")
        ElseIf (Convert.ToDouble(nup_obs.Value) = Decimal.Parse("10")) Then
            TXT_COD_det.Clear()
            TXT_COD_det.MaxLength = Integer.Parse("10")
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If ((boton <> "NUEVO") AndAlso (boton <> "MODIFICAR")) Then
                boton = "DETALLES"
                If (dgw1.RowCount <> 0) Then
                    LIMPIAR_CABECERA()
                    CARGAR_CABECERA()
                    LIMPIAR_detalle()
                    datagrid1()
                End If
                Panel1.Visible = True
                Panel1.Enabled = False
                Panel2.Visible = False
                j1.Enabled = False
                BTN_CANCELAR.Visible = True
                BTN_CANCELAR.Text = "&Cancelar"
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub

    Function verificar_TABLA() As Object
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_DIRECTORIO_TABLA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = txt_cod.Text
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return CONT
    End Function





    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents btn_cancelar2 As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents btn_eliminar2 As Button
    Friend WithEvents btn_guardar2 As Button
    Friend WithEvents btn_mod2 As Button
    Friend WithEvents btn_modificar As Button
    Friend WithEvents btn_modificar2 As Button
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_nuevo2 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents dgw As DataGridView
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents item1 As TextBox
    Friend WithEvents j1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents nup_obs As NumericUpDown
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txt_cod As TextBox
    Friend WithEvents TXT_COD_det As TextBox
    Friend WithEvents txt_desc As TextBox
    Friend WithEvents TXT_DESC_det As TextBox
    Friend WithEvents txt_obs_det As TextBox

End Class