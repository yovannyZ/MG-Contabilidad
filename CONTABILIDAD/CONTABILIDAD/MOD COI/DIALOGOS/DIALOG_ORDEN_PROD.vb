Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class DIALOG_ORDEN_PROD
    Dim obj As New Class1
    Dim gen As New Genericos
    Dim TFCuentas As Integer

#Region "Eventos Formulario"

    Private Sub DIALOG_ORDEN_PROD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFaltante.Text = 100 - CDbl(txtTIngreso.Text)
        txtTotal.Text = 0
        CARGAR_CC()
        CARGARCUENTAS()
    End Sub

#End Region

#Region "Eventos Controles"

#End Region

#Region "Botones"

    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        Close()
    End Sub

    Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
        'If (ValidarDuplicadoCC(txtCC.Text) = False) Then
        '    MessageBox.Show("No se puede ingresar 2 veces el mismo centro de costos", "Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCC.Focus() : Exit Sub
        'End If
        'dgvListaDiferidos.Rows.Add(txtCC.Text, txtCta.Text, obj.HACER_DECIMAL(txtPorcentaje.Text))
        'limpiar()

        'Validamos que no se repita el duplicado de CC
        If (ValidarDuplicadoCC(txtCC.Text) = False) Then
            txtCta.Clear()
            MessageBox.Show("No se puede ingresar 2 veces el mismo centro de costos", "Centro de Costos", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtCC.Focus() : Exit Sub
        End If
        'Prevalidamos la suma (totales + porcentaje)
        If CDbl(txtTotal.Text) + CDbl(txtPorcentaje.Text) > 100 Then
            txtPorcentaje.Text = (100 - CDbl(txtTotal.Text))
            MessageBox.Show("El porcentaje ingresado excede el total permitido", "Porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtPorcentaje.Focus() : Exit Sub
        End If
        dgvListaDiferidos.Rows.Add(txtCC.Text, txtCta.Text, obj.HACER_DECIMAL(txtPorcentaje.Text))
        limpiar()
    End Sub

#End Region

#Region "Métodos"


    Private Sub CARGARCUENTAS()
        dgvCta.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("CARGAR_CUENTAS_AÑO", con) 'CARGAR_CUENTAS_5
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO 'FE_AÑO
            con.Open()
            cmd.ExecuteNonQuery()
            Using Rs As SqlDataReader = cmd.ExecuteReader()
                While (Rs.Read())
                    If (Rs.GetString(0).Length = 8) Then
                        dgvCta.Rows.Add(Rs.GetValue(0), Rs.GetValue(1))
                    End If
                End While
            End Using
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CargarCuentasAna(ByVal IndiceCuenta As String)
        dgvCta.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("CARGAR_CUENTAS_5", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            cmd.ExecuteNonQuery()
            Using Rs As SqlDataReader = cmd.ExecuteReader()
                While (Rs.Read())
                    If (Rs.GetValue(0).ToString.Substring(0, 2) = IndiceCuenta) Then
                        dgvCta.Rows.Add(Rs.GetValue(0), Rs.GetValue(1))
                    End If
                End While
            End Using
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub SumarPorcentajes()
        Dim SumaTotalesPorcentaje As Double = 0
        Dim i As Integer = 0
        Dim tord = dgvListaDiferidos.RowCount - 1
        'Do While (i <= tord)
        '    If (dgvListaDiferidos.Item(2, i).Value = True) Then
        '        SumaTotalesPorcentaje += obj.HACER_DECIMAL(CDbl(dgvListaDiferidos.Item(3, i).Value))
        '        txtTotal.Text = obj.HACER_DECIMAL(SumaTotalesPorcentaje)
        '    End If
        '    i += 1
        'Loop

        Do While (i <= tord)
            SumaTotalesPorcentaje += obj.HACER_DECIMAL(CDbl(dgvListaDiferidos.Item(2, i).Value))
            i += 1
        Loop
        txtTotal.Text = obj.HACER_DECIMAL(SumaTotalesPorcentaje)
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim i As Integer = dgvListaDiferidos.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Try
            If (((CInt(MessageBox.Show(("Eliminar el Centro de Costo " & dgvListaDiferidos.Item(0, dgvListaDiferidos.CurrentRow.Index).Value.ToString), "ESTA SEGURO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                dgvListaDiferidos.Rows.RemoveAt(dgvListaDiferidos.CurrentRow.Index)
                SumarPorcentajes()
            End If
        Catch ex As Exception
            MessageBox.Show("No se puede quitar el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

#End Region

    Private Sub dgvCuentas_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Revisamos la cebecera de la columna
        Dim Cabecera As String = dgvListaDiferidos.Columns(e.ColumnIndex).HeaderText
        'Dim nroCuenta As String = String.Empty
        'Dim descCuenta As String = String.Empty
        Select Case Cabecera
            Case "Porcentaje"
                SumarPorcentajes()
                Exit Select
            Case Else
                Return
        End Select
    End Sub

    Private Sub limpiar()
        txtCC.Clear()
        txtCta.Clear()
        txtPorcentaje.Clear()
        SumarPorcentajes()
        txtCC.Focus()
    End Sub

    Private Sub CARGAR_CC()
        dgw_cc.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("DGW_CC", con)
            cmd.CommandType = CommandType.StoredProcedure
            con.Open()
            cmd.ExecuteNonQuery()
            Using rs As SqlDataReader = cmd.ExecuteReader
                While (rs.Read)
                    dgw_cc.Rows.Add(rs.GetValue(0), rs.GetValue(1), rs.GetValue(2))
                End While
            End Using
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()

        End Try
    End Sub

    Private Sub dgw_cc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cc.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCC.Text = dgw_cc.Item(0, dgw_cc.CurrentRow.Index).Value.ToString
            'Aqui hago la consulta del de la cta_ana del centro de costos
            CargarCuentasAna(dgw_cc.Item(2, dgw_cc.CurrentRow.Index).Value)
            'Pregunto si cargo alguna cuenta de ser lo contrario cargo todas las cuentas
            If (dgvCta.Rows.Count = 0) Then
                CARGARCUENTAS()
            End If
            panel_cc.Visible = False
            txtCta.Focus()
            '---------------------------
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cc.Visible = False
            txtCC.Clear()

        End If
    End Sub

    Private Sub txtCC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCC.LostFocus
        If ((Strings.Trim(txtCC.Text) <> "") AndAlso (dgw_cc.RowCount <> 0)) Then
            dgw_cc.Sort(dgw_cc.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim i As Integer = 0
            Do While (i <= (dgw_cc.RowCount - 1))
                If txtCC.Text.ToLower = (dgw_cc.Item(0, i).Value).ToLower Then
                    txtCC.Text = dgw_cc.Item(0, i).Value.ToString
                    'txt_desc_cc.Text = dgw_cc.Item(1, i).Value.ToString
                    panel_cc.Visible = False
                    'btn_aceptar1.Focus()
                    Return
                End If
                If (txtCC.Text.ToLower = Strings.Mid((dgw_cc.Item(0, i).Value), 1, Strings.Len(txtCC.Text)).ToLower) Then
                    dgw_cc.CurrentCell = (dgw_cc.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                dgw_cc.CurrentCell = (dgw_cc.Rows.Item(0).Cells.Item(0))
                i += 1
            Loop
            panel_cc.Visible = True
            dgw_cc.Visible = True
            dgw_cc.Focus()
        End If
    End Sub

    Private Sub txtCC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCC.KeyDown
        If (e.KeyCode = Keys.Return) Then
            txtCta.Focus()
        End If
    End Sub

    Private Sub txtCta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCta.LostFocus
        If ((Strings.Trim(txtCta.Text) <> "") AndAlso (dgvCta.RowCount <> 0)) Then
            dgvCta.Sort(dgvCta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim i As Integer = 0
            Do While (i <= (dgvCta.RowCount - 1))
                If txtCta.Text.ToLower = (dgvCta.Item(0, i).Value).ToLower Then
                    txtCta.Text = dgvCta.Item(0, i).Value.ToString
                    'txt_desc_cc.Text = dgw_cc.Item(1, i).Value.ToString
                    panelCta.Visible = False
                    'btn_aceptar1.Focus()
                    Return
                End If
                If (txtCta.Text.ToLower = Strings.Mid((dgvCta.Item(0, i).Value), 1, Strings.Len(txtCta.Text)).ToLower) Then
                    dgvCta.CurrentCell = (dgvCta.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                dgvCta.CurrentCell = (dgvCta.Rows.Item(0).Cells.Item(0))
                i += 1
            Loop
            panelCta.Visible = True
            dgvCta.Visible = True
            dgvCta.Focus()
        End If
    End Sub

    Private Sub dgvCta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCta.Text = dgvCta.Item(0, dgvCta.CurrentRow.Index).Value.ToString
            panelCta.Visible = False
            txtPorcentaje.Focus()
            '---------------------------
        ElseIf (e.KeyData = Keys.Escape) Then
            panelCta.Visible = False
            txtCta.Clear()

        End If
    End Sub

    Private Sub txtCta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCta.KeyDown
        If (e.KeyCode = Keys.Return) Then
            txtPorcentaje.Focus()
        End If
    End Sub

    Private Sub txtPorcentaje_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentaje.KeyDown
        If (e.KeyCode = Keys.Return) Then
            btnInsertar.Focus()
        End If
    End Sub

    Private Function ValidarDuplicadoCC(ByVal CodCC As String) As Boolean
        Dim estado As Boolean = True
        Dim cont As Integer = dgvListaDiferidos.Rows.Count - 1
        Dim i As Integer = 0
        While (i <= cont)
            If (txtCC.Text = dgvListaDiferidos.Item(0, i).Value) Then
                estado = False
                Exit While
            End If
            i += 1
        End While
        Return estado
    End Function

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        If txtTotal.Text = "" Then BTN_ACEPTAR.Enabled = False : Exit Sub

        If CDbl(txtTotal.Text) = CDbl(txtFaltante.Text) Then
            BTN_ACEPTAR.Enabled = True
        Else
            BTN_ACEPTAR.Enabled = False
        End If
    End Sub
    
End Class