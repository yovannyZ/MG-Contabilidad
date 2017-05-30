Imports System.Data.SqlClient
Public Class ORDEN_CUENTA
    Dim boton, COD_MOV, COD_SUC, TIPO_ORDEN As String
    Dim obj As New Class1
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
        Dim COD_CLASE As String = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar " & COD_CLASE & " " & dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_ORDEN_CUENTA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = COD_CLASE
                CMD.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
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
        If (cbo_tipo.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Tipo de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
        If (Strings.Trim(txt_nro_orden.Text) = "") Then
            MessageBox.Show("Debe insertar el número de orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_orden.Focus()
        ElseIf (Strings.Trim(txt_desc_orden.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc_orden.Focus()
        Else
            If (cbo_tipo_mov.Text = "COMPRAS") Then
                COD_MOV = "C"
            ElseIf (cbo_tipo_mov.Text = "VENTAS") Then
                COD_MOV = "V"
            ElseIf (cbo_tipo_mov.Text = "HONORARIOS") Then
                COD_MOV = "H"
            End If
            If (cbo_tipo.Text = "TOTAL") Then
                TIPO_ORDEN = "T"
            ElseIf (cbo_tipo.Text = "IGV") Then
                TIPO_ORDEN = "I"
            ElseIf (cbo_tipo.Text = "BASE IMPONIBLE") Then
                TIPO_ORDEN = "B"
            End If
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("El número de orden ya existe", "Ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_nro_orden.Focus()
            Else
                Try
                    Dim CMD As New SqlCommand("INSERTAR_ORDEN_CUENTA", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = txt_nro_orden.Text
                    CMD.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = COD_MOV
                    CMD.Parameters.Add("@DESC_ORDEN", SqlDbType.VarChar).Value = txt_desc_orden.Text
                    CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc_corta.Text
                    CMD.Parameters.Add("@TIPO_ORDEN", SqlDbType.VarChar).Value = TIPO_ORDEN
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("La orden se guardó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        txt_nro_orden.ReadOnly = True
        cbo_tipo_mov.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_desc_orden.Focus()
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (cbo_tipo.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Tipo de Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
        If (Strings.Trim(txt_nro_orden.Text) = "") Then
            MessageBox.Show("Debe insertar el número de la orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_orden.Focus()
        ElseIf (Strings.Trim(txt_desc_orden.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc_orden.Focus()
        Else
            If (cbo_tipo_mov.Text = "COMPRAS") Then
                COD_MOV = "C"
            ElseIf (cbo_tipo_mov.Text = "VENTAS") Then
                COD_MOV = "V"
            ElseIf (cbo_tipo_mov.Text = "HONORARIOS") Then
                COD_MOV = "H"
            End If
            If (cbo_tipo.Text = "TOTAL") Then
                TIPO_ORDEN = "T"
            ElseIf (cbo_tipo.Text = "IGV") Then
                TIPO_ORDEN = "I"
            ElseIf (cbo_tipo.Text = "BASE IMPONIBLE") Then
                TIPO_ORDEN = "B"
            End If
            Try
                Dim CMD As New SqlCommand("MODIFICAR_ORDEN_CUENTA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = txt_nro_orden.Text
                CMD.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = COD_MOV
                CMD.Parameters.Add("@DESC_ORDEN", SqlDbType.VarChar).Value = txt_desc_orden.Text
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc_corta.Text
                CMD.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = TIPO_ORDEN
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La orden se guardó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        txt_nro_orden.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(7) = 0
        Close()
    End Sub

    Sub CARGAR_DATOS()
        cbo_tipo_mov.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_orden.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_orden.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_corta.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        cbo_tipo.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_ORDEN_CUENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = txt_nro_orden.Text
            CMD.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = COD_MOV
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
            Dim cmd As New SqlCommand("MOSTRAR_ORDEN_CUENTA", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(0).Width = 90
            dgw1.Columns.Item(1).Width = 40
            dgw1.Columns.Item(2).Width = 350
            dgw1.Columns.Item(4).Visible = False
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Function DESC_SUCURSAL(ByVal COD_CLASE As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_SUCURSAL", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@SUCURSAL_cod", SqlDbType.Char).Value = (COD_CLASE)
            con.Open()
            DESC = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return DESC
    End Function
    Sub LIMPIAR()
        txt_nro_orden.Clear()
        cbo_tipo_mov.SelectedIndex = -1
        cbo_tipo.SelectedIndex = -1
        txt_desc_orden.Clear()
        txt_nro_orden.ReadOnly = False
        cbo_tipo_mov.Enabled = True
        txt_desc_orden.ReadOnly = False
        txt_desc_corta.Clear()
        txt_desc_corta.ReadOnly = False
    End Sub

    Private Sub ORDEN_CUENTA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ORDEN_CUENTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        btn_nuevo.Select()
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
                txt_nro_orden.ReadOnly = True
                cbo_tipo_mov.Enabled = True
                txt_desc_orden.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub


End Class