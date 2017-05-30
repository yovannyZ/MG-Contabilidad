Imports System.Data.SqlClient
Public Class CPTO_CUENTA
    Dim COD_AREA, COD_SUCURSAL, status_cc, TIPO As String
    Private obj As New Class1
 Private Sub BTN_ACEPTAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ACEPTAR.Click
        If (txt_cod.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf Panel_cpto.Visible Then
            MessageBox.Show("Debe elegir el Concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_cpto.Focus()
        Else
            txt_cod.ReadOnly = True
            txt_des.ReadOnly = True
            Panel1.Enabled = True
            CARGAR_DETALLES()
            btn_nuevo2.Select()
        End If
    End Sub
    Private Sub BTN_CANCELAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar2.Click
        LIMPIAR_CAB()
        btn_salir.Visible = True
        Panel1.Visible = True
        Panel2.Visible = False
        Panel1.Enabled = False
        txt_cod.Focus()
    End Sub
    Private Sub btn_cancelar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar2.Click
        Panel1.Visible = True
        Panel2.Visible = False
        btn_salir.Visible = True
        btn_nuevo2.Select()
    End Sub
    Private Sub btn_eliminar2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Eliminar el registro", "Esta seguro de :", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim PROG_01 As New SqlCommand("ELIMINAR_CPTO_CUENTA", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod.Text
                PROG_01.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
                PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = dgw.Item(5, dgw.CurrentRow.Index).Value.ToString
                con.Open()
                PROG_01.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            dgw.Rows.RemoveAt(dgw.CurrentRow.Index)
        End If
    End Sub

    Private Sub btn_guardar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar2.Click
        If (cbo_tipo.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo.Focus()
        ElseIf VERIFICAR_DETALLES = False Then
            MessageBox.Show("El Area ya se ingresó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If (cbo_tipo.Text = "CTAS GASTO/INGRESO CON CC.") Then
                TIPO = "G"
            ElseIf (cbo_tipo.Text = "CTAS DE BALANCE") Then
                TIPO = "O"
            ElseIf (cbo_tipo.Text = "CTAS DE INGRESO") Then
                TIPO = "I"
            ElseIf (cbo_tipo.Text = "") Then
                cbo_tipo.SelectedIndex = -1
            End If
            txt_area.Text = OBJ.COD_CC(CBO_AREA.Text.ToString)
            dgw.Rows.Add(txt_area.Text, CBO_AREA.Text, txt_origen.Text, txt_destino.Text, txt_enlace.Text, TIPO)
            Try
                Dim PROG_01 As New SqlCommand("INSERTAR_CONCEPTO_CUENTA", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@COD_CONCEPTO", SqlDbType.VarChar).Value = txt_cod.Text
                PROG_01.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = txt_area.Text
                PROG_01.Parameters.Add("@CUENTA_ENLACE", SqlDbType.Char).Value = txt_enlace.Text
                PROG_01.Parameters.Add("@CUENTA_DESTINO", SqlDbType.VarChar).Value = txt_destino.Text
                PROG_01.Parameters.Add("@CUENTA_ORIGEN", SqlDbType.VarChar).Value = txt_origen.Text
                PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO
                con.Open()
                PROG_01.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MessageBox.Show(ex.Message)

            End Try
            limpiar_detalles()
            btn_salir.Visible = True
            cbo_tipo.Select()
        End If
    End Sub

    Private Sub BTN_LIMPIAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_LIMPIAR.Click
        LIMPIAR_CAB()
        txt_cod.Focus()
    End Sub

    Private Sub btn_mod2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod2.Click
        Try
            Dim i As Integer = dgw.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        Panel1.Visible = False
        Panel2.Visible = True
        btn_modificar2.Visible = True
        btn_guardar2.Visible = False
        txt_item.Text = (dgw.CurrentRow.Index)
        txt_area.Text = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        CBO_AREA.Text = dgw.Item(1, dgw.CurrentRow.Index).Value.ToString
        txt_origen.Text = dgw.Item(2, dgw.CurrentRow.Index).Value.ToString
        txt_destino.Text = dgw.Item(3, dgw.CurrentRow.Index).Value.ToString
        txt_enlace.Text = dgw.Item(4, dgw.CurrentRow.Index).Value.ToString
        If (dgw.Item(5, dgw.CurrentRow.Index).Value.ToString = "O") Then
            cbo_tipo.Enabled = False
            cbo_tipo.Text = "CTAS DE BALANCE"
        ElseIf (dgw.Item(5, dgw.CurrentRow.Index).Value.ToString = "G") Then
            cbo_tipo.Enabled = False
            cbo_tipo.Text = "CTAS GASTO/INGRESO CON CC."
        ElseIf (dgw.Item(5, dgw.CurrentRow.Index).Value.ToString = "I") Then
            cbo_tipo.Enabled = False
            cbo_tipo.Text = "CTAS DE INGRESO"
        End If
        CBO_AREA.Enabled = False
        btn_salir.Visible = False
        txt_origen.Focus()
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        Dim item0 As Integer = Integer.Parse(txt_item.Text)
        txt_area.Text = obj.COD_CC(CBO_AREA.Text.ToString)
        If (cbo_tipo.Text = "CTAS GASTO/INGRESO CON CC.") Then
            TIPO = "G"
        ElseIf (cbo_tipo.Text = "CTAS DE BALANCE") Then
            TIPO = "O"
        ElseIf (cbo_tipo.Text = "CTAS DE INGRESO") Then
            TIPO = "I"
        ElseIf (cbo_tipo.Text = "") Then
            cbo_tipo.SelectedIndex = -1
        End If
        dgw.Item(2, item0).Value = txt_origen.Text
        dgw.Item(3, item0).Value = txt_destino.Text
        dgw.Item(4, item0).Value = txt_enlace.Text
        dgw.Item(5, item0).Value = TIPO
        Try
            Dim PROG_01 As New SqlCommand("MODIFICAR_CONCEPTO_CUENTA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_CONCEPTO", SqlDbType.VarChar).Value = txt_cod.Text
            PROG_01.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = txt_area.Text
            PROG_01.Parameters.Add("@CUENTA_ENLACE", SqlDbType.VarChar).Value = txt_enlace.Text
            PROG_01.Parameters.Add("@CUENTA_DESTINO", SqlDbType.VarChar).Value = txt_destino.Text
            PROG_01.Parameters.Add("@CUENTA_ORIGEN", SqlDbType.VarChar).Value = txt_origen.Text
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO
            con.Open()
            PROG_01.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Panel1.Visible = True
        Panel2.Visible = False
        btn_salir.Visible = True
        btn_nuevo2.Select()
    End Sub
    Private Sub btn_nuevo2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo2.Click
        limpiar_detalles()
        Panel1.Visible = False
        Panel2.Visible = True
        btn_modificar2.Visible = False
        btn_guardar2.Visible = True
        cbo_tipo.Select()
        btn_salir.Visible = False
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(28) = 0
        Close()
    End Sub
    Sub CARGAR_CC()
        CBO_AREA.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AREA", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_AREA.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONCEPTOS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_CPTO5", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PRODUCTOS")
            ADAP.Fill(DT)
            dgw_cpto.DataSource = DT
            dgw_cpto.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cpto.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_DETALLES()
        dgw.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CPTO_CUENTA_DETALLES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txt_cod.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CBO_AREA_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBO_AREA.SelectedIndexChanged
        If (CBO_AREA.SelectedIndex <> -1) Then
            txt_area.Text = obj.COD_CC(CBO_AREA.Text)
        End If
    End Sub
    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_tipo.SelectedIndexChanged
        If (cbo_tipo.Text = "CTAS GASTO/INGRESO CON CC.") Then
            CBO_AREA.Enabled = True
        Else
            CBO_AREA.SelectedIndex = -1
            CBO_AREA.Enabled = False
        End If
    End Sub
    Private Sub CTA_GASTOS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub CTA_INVENTARIO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        txt_cod.Focus()
        CARGAR_CONCEPTOS()
        CARGAR_CC()
        dgw.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
    End Sub
    Private Sub DGW_PRO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cpto.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod.Text = dgw_cpto.Item(0, dgw_cpto.CurrentRow.Index).Value.ToString
            txt_des.Text = dgw_cpto.Item(1, dgw_cpto.CurrentRow.Index).Value.ToString
            Panel_cpto.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cpto.Visible = False
            txt_cod.Clear()
            txt_des.Clear()
            txt_cod.Focus()
        End If
    End Sub
    Sub LIMPIAR_CAB()
        txt_cod.Clear()
        txt_des.Clear()
        txt_cod.ReadOnly = False
        txt_des.ReadOnly = False
        Panel_cpto.Visible = False
        dgw.Rows.Clear()
    End Sub
    Sub limpiar_detalles()
        CBO_AREA.SelectedIndex = -1
        CBO_AREA.Enabled = True
        txt_area.Clear()
        txt_destino.Clear()
        txt_origen.Clear()
        txt_enlace.Clear()
        cbo_tipo.SelectedIndex = -1
        cbo_tipo.Enabled = True
    End Sub
    Private Sub TXT_COD_PRO_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod.LostFocus
        If (Strings.Trim(txt_cod.Text) <> "") Then
            If (dgw_cpto.RowCount = 0) Then
                MessageBox.Show("No existen conceptos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cpto.Sort(dgw_cpto.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cpto.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod.Text.ToLower = dgw_cpto.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod.Text = dgw_cpto.Item(0, i).Value.ToString
                        txt_des.Text = dgw_cpto.Item(1, i).Value.ToString
                        BTN_ACEPTAR.Select()
                        Return
                    End If
                    If (txt_cod.Text.ToLower = Strings.Mid((dgw_cpto.Item(0, i).Value), 1, Strings.Len(txt_cod.Text)).ToLower) Then
                        dgw_cpto.CurrentCell = dgw_cpto.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cpto.CurrentCell = dgw_cpto.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cpto.Visible = True
                dgw_cpto.Visible = True
                dgw_cpto.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC_PRO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_des.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_des.Text) <> "")) Then
            If (dgw_cpto.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cpto.Sort(dgw_cpto.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cpto.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_des.Text.ToLower = Strings.Mid((dgw_cpto.Item(1, i).Value), 1, Strings.Len(txt_des.Text)).ToLower) Then
                        dgw_cpto.CurrentCell = dgw_cpto.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cpto.Visible = True
                Panel_cpto.Focus()
            End If
        End If
    End Sub
    Function VERIFICAR_DETALLES() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw.Item(0, I).Value.ToString = txt_area.Text) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
End Class