Imports System.Data.SqlClient
Public Class CUENTA_HONORARIOS
    Dim boton, COD_ORDEN, COD_ORDEN2, TIPO_ORDEN As String
    Dim OBJ As New Class1
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
            Exit Sub
        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If MessageBox.Show(("ELIMINAR " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = 6 Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONFIG_CUENTA", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CLASE
                CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
                CMD.Parameters.Add("@TIPO_MOV ", SqlDbType.Char).Value = "H"
                CMD.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
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
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod_cuenta.Text) = "") Then
            MessageBox.Show("Debe insertar el codigo  de cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cuenta.Focus()
        ElseIf (cbo_tipo.SelectedIndex = -1) Then
            MessageBox.Show("Debe seleccionar el Tipo de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_des_cuenta.Focus()
        ElseIf (cbo_orden.SelectedIndex = -1) Then
            MessageBox.Show("Debe seleccionar el Nro de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_des_cuenta.Focus()
        Else
            If (cbo_tipo.Text = "TOTAL") Then
                TIPO_ORDEN = "T"
            ElseIf (cbo_tipo.Text = "RENTA") Then
                TIPO_ORDEN = "R"
            ElseIf (cbo_tipo.Text = "BASE IMPONIBLE") Then
                TIPO_ORDEN = "B"
            End If
            COD_ORDEN2 = ""
            If cbo_orden2.SelectedIndex <> -1 Then COD_ORDEN2 = OBJ.COD_NRO_ORDEN(cbo_orden2.Text, "H")
            COD_ORDEN = OBJ.COD_NRO_ORDEN(cbo_orden.Text, "H")
            If (CONTAR_REG > 0) Then
                MessageBox.Show("El codigo de Cuenta Honorario ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cuenta.Focus()
            Else
                Try
                    Dim CMD As New SqlCommand("INSERTAR_CONFIG_CUENTAS", con)
                    CMD.CommandType = (CommandType.StoredProcedure)
                    CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cuenta.Text
                    CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = COD_ORDEN
                    CMD.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = TIPO_ORDEN
                    CMD.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "H"
                    CMD.Parameters.Add("@NRO_ORDEN2", SqlDbType.Char).Value = COD_ORDEN2
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("La Configuración de Cuenta Honorario se guardo", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LIMPIAR()
                    TabControl1.SelectedTab = TabPage1
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                DATAGRID()
                btn_nuevo.Select()
            End If
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        TabControl1.SelectedTab = TabPage2
        txt_cod_cuenta.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(6) = 0
        Close()
    End Sub
    Sub CARGAR_CUENTA()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTA_NIVEL3", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("CUENTA")
            ADAP.Fill(DT)
            dgw_cuenta.DataSource = (DT)
            dgw_cuenta.Columns.Item(0).Width = (50)
            dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_DATOS()
        txt_cod_cuenta.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_des_cuenta.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_ORDEN = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_orden.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        TIPO_ORDEN = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        If (TIPO_ORDEN = "T") Then
            cbo_tipo.Text = "TOTAL"
        ElseIf (TIPO_ORDEN = "R") Then
            cbo_tipo.Text = "RENTA"
        ElseIf (TIPO_ORDEN = "B") Then
            cbo_tipo.Text = "BASE IMPONIBLE"
        End If
    End Sub
    Sub CBO_ORDEN_COMPRAS()
        cbo_orden.Items.Clear()
        cbo_orden2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_ORDEN_HONORARIOS", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_orden.Items.Add(Rs3.GetString(0))
                cbo_orden2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_CONFIG_CUENTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = txt_cod_cuenta.Text
            CMD.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = TIPO_ORDEN
            CMD.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "H"
            con.Open()
            CONT = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_CONFIG_CUENTAS", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "H"
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("COMPRAS")
            ADAP.Fill(dt)
            dgw1.DataSource = (dt)
            'dgw1.Columns.Item(5).Visible = False
            'dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(0).Width = (31)
            dgw1.Columns.Item(1).Width = (250)
            dgw1.Columns.Item(2).Width = (29)
            dgw1.Columns.Item(3).Width = (200)
            dgw1.Columns.Item(4).Width = (35)
            dgw1.Columns.Item(5).Width = (29)
            dgw1.Columns.Item(6).Width = (200)
            dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cuenta.Text = dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString
            txt_des_cuenta.Text = dgw_cuenta.Item(1, dgw_cuenta.CurrentRow.Index).Value.ToString
            Panel3.Visible = False
            txt.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel3.Visible = False
            txt_cod_cuenta.Clear()
            txt_des_cuenta.Clear()
            txt_cod_cuenta.Focus()
        End If
    End Sub
    Sub LIMPIAR()
        txt_cod_cuenta.Clear()
        txt_des_cuenta.Clear()
        txt_cod_cuenta.ReadOnly = False
        txt_des_cuenta.ReadOnly = False
        cbo_tipo.SelectedIndex = -1
        cbo_orden.SelectedIndex = -1
        '---------------------
        txt_cod_cuenta.Enabled = True
        txt_des_cuenta.Enabled = True
        cbo_tipo.Enabled = True
        cbo_orden.Enabled = True
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
                txt_cod_cuenta.ReadOnly = True
                txt_des_cuenta.ReadOnly = True
                cbo_tipo.Enabled = False
                cbo_orden.Enabled = False
                btn_guardar.Visible = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub txt_cod_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod_cuenta.KeyDown
        If (e.KeyData = Keys.Down) Then
            cbo_tipo.Focus()
        End If
    End Sub
    Private Sub txt_cod_cuenta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cuenta.LostFocus
        If (Strings.Trim(txt_cod_cuenta.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cuenta.RowCount - 1))
                    If (txt_cod_cuenta.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cuenta.Text = dgw_cuenta.Item(0, i).Value.ToString
                        txt_des_cuenta.Text = dgw_cuenta.Item(1, i).Value.ToString
                        cbo_tipo.Focus()
                        Return
                    End If
                    If (txt_cod_cuenta.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_cod_cuenta.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel3.Visible = True
                dgw_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_des_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_des_cuenta.KeyDown
        If (e.KeyData <> Keys.Return) Then
            If (e.KeyData = Keys.Escape) Then
                Panel3.Visible = False
                txt_cod_cuenta.Clear()
                txt_des_cuenta.Clear()
                txt_cod_cuenta.Focus()
            End If
        Else
            If (Strings.Trim(txt_des_cuenta.Text) = "") Then
                Return
            End If
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            dgw_cuenta.Sort(dgw_cuenta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
            'Dim VB$t_i4$L0 As Integer = (dgw_cuenta.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= (dgw_cuenta.RowCount - 1))
                If (txt_des_cuenta.Text.ToLower = Strings.Mid((dgw_cuenta.Item(1, i).Value), 1, Strings.Len(txt_des_cuenta.Text)).ToLower) Then
                    dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                i += 1
            Loop
            Panel3.Visible = True
            dgw_cuenta.Visible = True
            dgw_cuenta.Focus()
        End If
        If (e.KeyData = Keys.Left) Then
            txt_cod_cuenta.Focus()
        ElseIf (e.KeyData = Keys.Down) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_orden.Focus()
        End If
    End Sub
    Private Sub CUENTA_HONORARIOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CUENTA_HONORARIOS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        btn_nuevo.Select()
        CARGAR_CUENTA()
        CBO_ORDEN_COMPRAS()
    End Sub
    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged
        If cbo_tipo.Text.ToString = "BASE IMPONIBLE" Then
            'cbo_orden2.SelectedIndex = -1
            cbo_orden2.Visible = True
            Label3.Visible = True
        Else
            cbo_orden2.SelectedIndex = -1
            cbo_orden2.Visible = False
            Label3.Visible = False
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod_cuenta.Enabled = False
        txt_des_cuenta.Enabled = False
        cbo_tipo.Enabled = False
        cbo_orden.Enabled = False
        TabControl1.SelectedTab = TabPage2
        cbo_orden2.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod_cuenta.Text) = "") Then MessageBox.Show("Debe insertar el codigo  de cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cuenta.Focus() : Exit Sub
        If (cbo_tipo.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Tipo de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_des_cuenta.Focus() : Exit Sub
        If (cbo_orden.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Nro de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden.Focus() : Exit Sub
        If (cbo_orden2.SelectedIndex = -1) And cbo_orden2.Visible = True Then MessageBox.Show("Debe seleccionar el Nro de Orden (Sin Igv).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden2.Focus() : Exit Sub
        If (cbo_tipo.Text = "TOTAL") Then
            TIPO_ORDEN = "T"
        ElseIf (cbo_tipo.Text = "IGV") Then
            TIPO_ORDEN = "I"
        ElseIf (cbo_tipo.Text = "BASE IMPONIBLE") Then
            TIPO_ORDEN = "B"
        End If
        COD_ORDEN2 = ""
        If cbo_orden2.SelectedIndex <> -1 Then COD_ORDEN2 = OBJ.COD_NRO_ORDEN(cbo_orden2.Text, "H")
        COD_ORDEN = OBJ.COD_NRO_ORDEN(cbo_orden.Text, "H")
        Try
            Dim CMD As New SqlCommand("MODIFICAR_CONFIGURACION_CUENTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cuenta.Text
            CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = COD_ORDEN
            CMD.Parameters.Add("@NRO_ORDEN2", SqlDbType.Char).Value = COD_ORDEN2
            CMD.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = TIPO_ORDEN
            CMD.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "H"
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("La Configuración de Cuenta Honorarios se guardo", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedTab = TabPage1
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()
        btn_nuevo.Select()
    End Sub
End Class