Public Class FrmConceptoCuentaUN
    Dim Concepto As String = ""
    Dim Cuenta As String = ""
    Private Shared _instancia As FrmConceptoCuentaUN

    Public Shared Function ObtenerInstancia() As FrmConceptoCuentaUN
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmConceptoCuentaUN
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub FrmConceptoCuentaUN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Listar()
        'ListarCuentas()
        'ListarCentroCosto()
    End Sub

    Private Sub Listar()
        dgwListado.DataSource = Nothing
        Dim count As Integer = 0
        Try
            Dim cmd As New SqlCommand("LISTAR_CONCEPTO_CUENTA_U_N_2", con)
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgwListado.DataSource = dt
            dgwListado.Columns(0).Width = 30
            dgwListado.Columns(1).Width = 230
            dgwListado.Columns(2).Width = 60
            dgwListado.Columns(3).Width = 250
            dgwListado.Columns(4).Width = 90

            If dgwListado.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgwListado.Rows
                    Dim codConcepto2 As String = row.Cells(0).Value
                    Dim codCuenta2 As String = row.Cells(2).Value
                    If Concepto = row.Cells(0).Value And Cuenta = row.Cells(2).Value Then
                        dgwListado.Rows(count).Selected = True
                        dgwListado.CurrentCell = dgwListado.Rows(count).Cells(0)
                        Exit For
                    End If
                    count += 1
                Next
            End If

            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListarConceptos(ByVal tipo As String)
        dgwConcepto.DataSource = Nothing
        Try
            Dim cmd As New SqlCommand("OBTENER_CONCEPTO_UN_X_TIPO", con)
            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgwConcepto.DataSource = dt
            dgwConcepto.Columns(0).Width = 30
            dgwConcepto.Columns(1).Width = 250
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsociar.Click
        Try
            Dim I As Integer = dgwListado.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        Limpiar()

        Dim codConcepto As String = (dgwListado.Item(0, dgwListado.CurrentRow.Index).Value)
        Dim desConcepto As String = (dgwListado.Item(1, dgwListado.CurrentRow.Index).Value)
        Dim codCuenta As String = (dgwListado.Item(2, dgwListado.CurrentRow.Index).Value)
        Dim desCuenta As String = (dgwListado.Item(3, dgwListado.CurrentRow.Index).Value)
        Concepto = (dgwListado.Item(0, dgwListado.CurrentRow.Index).Value)
        Cuenta = (dgwListado.Item(2, dgwListado.CurrentRow.Index).Value)

        cboTipo.Text = (dgwListado.Item(4, dgwListado.CurrentRow.Index).Value)
        txtCodConcepto.Enabled = False
        txtDescConcepto.Enabled = False
        txtCodCuenta.Enabled = False
        txtDescCuenta.Enabled = False
        cboTipo.Enabled = False
        txtCodConcepto.Text = codConcepto
        txtDescConcepto.Text = desConcepto
        txtCodCuenta.Text = codCuenta
        txtDescCuenta.Text = desCuenta
        ListarCentroCosto(codCuenta.Substring(0, 2))
        Dim tipo As String = ""

        Select Case cboTipo.Text
            Case "INGRESO"
                tipo = "I"
            Case "GASTO"
                tipo = "G"
            Case "COSTO"
                tipo = "C"
        End Select

        ObtenerConceptoCuenta(codCuenta, codConcepto, tipo)
        tabConcepto.SelectedIndex = 1
        ListarCuentas()
    End Sub


    Private Sub ObtenerConceptoCuenta(ByVal codCuenta As String, ByVal codConcepto As String, ByVal tipo As String)
        dgwConceptoCuenta.DataSource = Nothing

        Try
            Dim cmd As New SqlCommand("OBTENER_CONCEPTO_CUENTA_U_N", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = codCuenta
            cmd.Parameters.Add("@COD_CONCEPTO", SqlDbType.Char).Value = codConcepto
            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                If dgwConceptoCuenta.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In dgwConceptoCuenta.Rows
                        If row.Cells(0).Value = dr(0) Then
                            row.Cells(2).Value = True
                        End If
                    Next
                End If
            End While

            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListarCuentas()
        dgw_cta.DataSource = Nothing

        Try
            Dim cmd As New SqlCommand("LISTAR_CUENTAS_UN", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@OPCION", SqlDbType.VarChar).Value = "08"
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgw_cta.DataSource = dt
            dgw_cta.Columns(0).Width = 100
            dgw_cta.Columns(1).Width = 250
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListarCentroCosto(ByVal codCuenta As String)
        dgwConceptoCuenta.DataSource = Nothing
        dgwConceptoCuenta.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("OBTENER_CENTRO_COSTO_X_CUENTA", con)
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = codCuenta
            cmd.CommandType = CommandType.StoredProcedure
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                dgwConceptoCuenta.Rows.Add(dr(0), dr(1), False)
            End While

            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtCodCuenta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existe Cuenta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim codigo As String = txtCodCuenta.Text
                dgw_cta.Sort(dgw_cta.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (txtCodCuenta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        txtCodCuenta.Text = dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value.ToString
                        txtDescCuenta.Text = dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value.ToString
                        Dim codCuenta As String = txtCodCuenta.Text
                        ListarCentroCosto(codCuenta.Substring(0, 2))
                        dgwConceptoCuenta.Focus()
                        Exit Sub
                    End If
                    If (txtCodCuenta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txtCodCuenta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If

                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Visible = True
                dgw_cta.Focus()
            End If
        ElseIf ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtCodCuenta.Text) = "")) Then
            PaneL_CTA.Visible = True
            dgw_cta.Visible = True
            dgw_cta.Focus()
        End If
    End Sub

    Private Sub txtDescCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescCuenta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtDescCuenta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existe Cuenta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim desc As String = txtDescCuenta.Text
                dgw_cta.Sort(dgw_cta.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (desc.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(desc)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))

                    End If
                    dgw_cta.CurrentCell = (dgw_cta.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

  

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        tabConcepto.SelectedIndex = 0
        txtCodConcepto.Enabled = False
        txtDescConcepto.Enabled = False
        chkTodos.Checked = False
    End Sub

    Private Sub dgw_cta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then

            txtCodCuenta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txtDescCuenta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            PaneL_CTA.Visible = False
            Dim codCuenta As String = txtCodCuenta.Text
            ListarCentroCosto(codCuenta.Substring(0, 2))
            dgwConceptoCuenta.Focus()

        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodCuenta.Clear()
            txtDescCuenta.Clear()
            PaneL_CTA.Visible = False
            txtDescCuenta.Focus()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Insertar()

    End Sub

    Private Sub Insertar()
        Dim codigoConcepto As String = txtCodConcepto.Text

        If dgwConceptoCuenta.Rows.Count > 0 Then
            Dim seleccionoCentroCosto As Boolean = False
            For Each row As DataGridViewRow In dgwConceptoCuenta.Rows
                If row.Cells(2).Value = True Then
                    seleccionoCentroCosto = True
                End If
            Next

            If seleccionoCentroCosto = False Then
                MessageBox.Show("Debe seleccionar un centro de costo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If dgwConceptoCuenta.Rows.Count = 0 Then
            MessageBox.Show("Debe seleccionar un centro de costo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim opcion As Boolean = True
        Dim tipo As String = ""

        Select Case cboTipo.Text
            Case "INGRESO"
                tipo = "I"
            Case "GASTO"
                tipo = "G"
            Case "COSTO"
                tipo = "C"
        End Select


        Try
            Dim cmd2 As New SqlCommand("ELIMINAR_CONCEPTO_CUENTA_UN", con)
            cmd2.CommandType = CommandType.StoredProcedure
            cmd2.Parameters.Add("@COD_CONCEPTO_U_N", SqlDbType.Char).Value = codigoConcepto
            cmd2.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = txtCodCuenta.Text
            cmd2.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
            con.Open()
            cmd2.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            opcion = False
            MsgBox(ex.Message)
        End Try

        If opcion = True Then
            If dgwConceptoCuenta.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgwConceptoCuenta.Rows
                    If row.Cells(2).Value = True Then
                        Dim codCuenta As String = txtCodCuenta.Text
                        Dim codCentroCosto As String = row.Cells(0).Value
                        Try
                            Dim cmd As New SqlCommand("INSERTAR_CONCEPTO_CUENTA_UN", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Add("@COD_CONCEPTO_U_N", SqlDbType.Char).Value = codigoConcepto
                            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = codCuenta
                            cmd.Parameters.Add("@COD_CC", SqlDbType.Char).Value = codCentroCosto
                            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            con.Close()
                            MsgBox(ex.Message)
                        End Try
                    End If
                    
                Next

                MessageBox.Show("Conceptos Asociados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar()
                Listar()
                tabConcepto.SelectedIndex = 0
                chkTodos.Checked = False
            End If
        End If




    End Sub


    Private Sub Limpiar()
        txtCodConcepto.Clear()
        txtDescConcepto.Clear()
        txtCodCuenta.Clear()
        txtDescCuenta.Clear()
        dgwConceptoCuenta.Rows.Clear()
        txtCodConcepto.Focus()
    End Sub

    Private Sub FrmConceptoCuentaUN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Limpiar()
        tabConcepto.SelectedIndex = 1
        txtCodConcepto.Enabled = True
        txtDescConcepto.Enabled = True
        txtCodCuenta.Enabled = True
        txtDescCuenta.Enabled = True
        cboTipo.Enabled = True

        ListarCuentas()
        txtCodConcepto.Focus()
        chkTodos.Checked = False
    End Sub

    Private Sub txtCodConcepto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodConcepto.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtCodConcepto.Text) <> "")) Then
            If (dgwConcepto.RowCount = 0) Then
                MessageBox.Show("Seleccione un tipo de concepto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboTipo.Focus()
            Else
                Dim codigo As String = txtCodConcepto.Text
                codigo = codigo.PadLeft(2, "0"c)
                dgwConcepto.Sort(dgwConcepto.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgwConcepto.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (codigo.ToLower = Strings.Mid((dgwConcepto.Item(0, i).Value), 1, Strings.Len(codigo)).ToLower) Then
                        dgwConcepto.CurrentCell = (dgwConcepto.Rows.Item(i).Cells.Item(0))
                        txtCodConcepto.Text = dgwConcepto.Item(0, dgwConcepto.CurrentRow.Index).Value.ToString
                        txtDescConcepto.Text = dgwConcepto.Item(1, dgwConcepto.CurrentRow.Index).Value.ToString

                        txtCodCuenta.Focus()
                        Exit Sub
                    End If
                    dgwConcepto.CurrentCell = (dgwConcepto.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                PanelConcepto.Visible = True
                dgwConcepto.Visible = True
                dgwConcepto.Focus()
            End If
        ElseIf ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtCodConcepto.Text) = "")) Then
            PanelConcepto.Visible = True
            dgwConcepto.Visible = True
            dgwConcepto.Focus()
        End If
    End Sub

    Private Sub txtDescConcepto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescConcepto.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtDescConcepto.Text) <> "")) Then
            If (dgwConcepto.RowCount = 0) Then
                MessageBox.Show("No existe PERSONAL", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim codigo As String = txtDescConcepto.Text
                codigo = txtDescConcepto.Text
                dgwConcepto.Sort(dgwConcepto.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgwConcepto.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (codigo.ToLower = Strings.Mid((dgwConcepto.Item(1, i).Value), 1, Strings.Len(codigo)).ToLower) Then
                        dgwConcepto.CurrentCell = (dgwConcepto.Rows.Item(i).Cells.Item(0))
                    End If
                    dgwConcepto.CurrentCell = (dgwConcepto.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                PanelConcepto.Visible = True
                dgwConcepto.Visible = True
                dgwConcepto.Focus()
            End If
        End If
    End Sub

    Private Sub dgwConcepto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgwConcepto.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodConcepto.Text = (dgwConcepto.Item(0, dgwConcepto.CurrentRow.Index).Value)
            txtDescConcepto.Text = (dgwConcepto.Item(1, dgwConcepto.CurrentRow.Index).Value)
            PanelConcepto.Visible = False
            txtCodCuenta.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodConcepto.Clear()
            txtDescConcepto.Clear()
            PanelConcepto.Visible = False
            txtDescConcepto.Focus()
        End If
    End Sub


    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If dgwConceptoCuenta.Rows.Count > 0 Then
            If chkTodos.Checked = True Then
                For Each row As DataGridViewRow In dgwConceptoCuenta.Rows
                    row.Cells(2).Value = True
                Next
            Else
                For Each row As DataGridViewRow In dgwConceptoCuenta.Rows
                    row.Cells(2).Value = False
                Next
            End If
            
        End If
    End Sub

 

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If cboTipo.SelectedIndex <> -1 Then
            Dim tipo As String

            If cboTipo.Text = "INGRESO" Then
                tipo = "I"
            ElseIf cboTipo.Text = "GASTO" Then
                tipo = "G"
            Else
                tipo = "C"
            End If

            ListarConceptos(tipo)
        End If

    End Sub
End Class