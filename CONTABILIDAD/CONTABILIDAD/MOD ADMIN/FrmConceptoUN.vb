Imports System.Data.SqlClient
Public Class FrmConceptoUN
    Dim _opcion As String
    Dim _esIngreso As Boolean
    Dim _esCosto As Boolean
    Dim _esGasto As Boolean
    Dim concepto As String = ""
    Dim tip As String = ""

    Private Shared _instancia As FrmConceptoUN

    Public Shared Function ObtenerInstancia() As FrmConceptoUN
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmConceptoUN
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function



    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        _opcion = "Nuevo"
        _esGasto = True
        tabConcepto.SelectedIndex = 1
        Limpiar()
        txtCodigo.Text = ObtenerCodigoGasto()
        cboTipo.SelectedIndex = 1
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text.Equals("") Then
            MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescripcion.Focus()
        ElseIf txtDescripcionCorta.Text.Equals("") Then
            MessageBox.Show("Ingrese una descripción corta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescripcionCorta.Focus()
        ElseIf cboNivel.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboNivel.Focus()
        Else
            If _opcion = "Nuevo" Then
                Insertar()
                Limpiar()

                If _esIngreso Then
                    txtCodigo.Text = ObtenerCodigoIngreso()
                ElseIf _esGasto Then
                    txtCodigo.Text = ObtenerCodigoGasto()
                ElseIf _esCosto Then
                    txtCodigo.Text = ObtenerCodigoCosto()
                End If

            ElseIf _opcion = "Editar" Then
                Actualizar()
                tabConcepto.SelectedIndex = 0
                Limpiar()
            End If

            Listar()

        End If    
    End Sub

    Private Sub Insertar()
        Dim codigo As String = txtCodigo.Text
        Dim descripcion As String = txtDescripcion.Text
        Dim descripcionCorta As String = txtDescripcionCorta.Text
        Dim tipo As String
        Select Case cboTipo.Text
            Case "INGRESO"
                tipo = "I"
            Case "GASTO"
                tipo = "G"
            Case "COSTO"
                tipo = "C"
        End Select

        Dim nivel As String = cboNivel.SelectedValue

        Try
            Dim cmd As New SqlCommand("INSERTAR_CONCEPTO_UN", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@DESC_CONCEPTO_U_N", SqlDbType.VarChar).Value = descripcion
            cmd.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = descripcionCorta
            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
            cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = nivel
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("El concepto se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function ObtenerCodigoGasto() As String
        Dim codigo As String = ""

        Try
            Dim cmd As New SqlCommand("SELECT DBO.CORRELATIVO_CONCEPTO_UN_GASTO()", con)
            cmd.CommandType = (CommandType.Text)
            con.Open()
            codigo = cmd.ExecuteScalar()
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            con.Close()
        End Try

        Return codigo

    End Function

    Private Function ObtenerCodigoIngreso() As String
        Dim codigo As String = ""

        Try
            Dim cmd As New SqlCommand("SELECT DBO.CORRELATIVO_CONCEPTO_UN_INGRESO()", con)
            cmd.CommandType = (CommandType.Text)
            con.Open()
            codigo = cmd.ExecuteScalar()
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            con.Close()
        End Try

        Return codigo

    End Function

    Private Sub Actualizar()
        Dim codigo As String = txtCodigo.Text
        Dim descripcion As String = txtDescripcion.Text
        Dim descripcionCorta As String = txtDescripcionCorta.Text
        Dim tipo As String

        Select Case cboTipo.Text
            Case "INGRESO"
                tipo = "I"
            Case "GASTO"
                tipo = "G"
            Case "COSTO"
                tipo = "C"
        End Select

        Try
            Dim cmd As New SqlCommand("ACTUALIZAR_CONCEPTO_UN", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CONCEPT0_U_N", SqlDbType.VarChar).Value = codigo
            cmd.Parameters.Add("@DESC_CONCEPTO_U_N", SqlDbType.VarChar).Value = descripcion
            cmd.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = descripcionCorta
            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
            cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = cboNivel.SelectedValue
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("El concepto se actualizó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar()
        txtCodigo.Clear()
        txtDescripcion.Clear()
        txtDescripcionCorta.Clear()
        ' cboTipo.SelectedIndex = 0
        txtDescripcion.Focus()
    End Sub

    Private Sub Listar()
        dgwListado.DataSource = Nothing
        Dim count As Integer = 0
        Try
            Dim cmd As New SqlCommand("LISTAR_CONCEPTO_UN", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgwListado.DataSource = dt
            dgwListado.Columns(0).Width = 30
            dgwListado.Columns(1).Width = 250
            dgwListado.Columns(2).Width = 150
            dgwListado.Columns(3).Width = 70
            dgwListado.Columns(4).Visible = False
            dgwListado.Columns(5).Width = 150

            If dgwListado.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgwListado.Rows

                    If concepto = row.Cells(0).Value And tip = row.Cells(3).Value Then
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

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        _opcion = "Editar"

        Try
            Dim I As Integer = dgwListado.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

        Dim codigo As String = (dgwListado.Item(0, dgwListado.CurrentRow.Index).Value)
        Dim descripcion As String = (dgwListado.Item(1, dgwListado.CurrentRow.Index).Value)
        Dim descripcionCorta As String = (dgwListado.Item(2, dgwListado.CurrentRow.Index).Value)
        Dim tipo As String = dgwListado.Item(3, dgwListado.CurrentRow.Index).Value
        Dim nivel As String = dgwListado.Item(4, dgwListado.CurrentRow.Index).Value
        concepto = codigo
        tip = tipo

        txtCodigo.Text = codigo
        txtDescripcion.Text = descripcion
        txtDescripcionCorta.Text = descripcionCorta
        cboTipo.Text = tipo
        cboNivel.SelectedValue = nivel
        tabConcepto.SelectedIndex = 1


    End Sub

    Private Sub FrmConceptoUN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Listar()
        LlenarComboNivel()
        cboTipo.SelectedIndex = 0
    End Sub

    Sub LlenarComboNivel()
        cboNivel.DataSource = Nothing
        Try
            Dim cmd As New SqlCommand("LISTAR_NIVEL_CONCEPTO_UN", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("nivel")
            da.Fill(dt)
            cboNivel.DataSource = dt
            cboNivel.ValueMember = dt.Columns(0).Caption.ToString()
            cboNivel.DisplayMember = dt.Columns(1).Caption.ToString()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
        tabConcepto.SelectedIndex = 0
    End Sub

    Private Sub btnNuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo2.Click
        _opcion = "Nuevo"
        Limpiar()

        If _esIngreso Then
            txtCodigo.Text = ObtenerCodigoIngreso()
        ElseIf _esGasto Then
            txtCodigo.Text = ObtenerCodigoGasto()
        ElseIf _esCosto Then
            txtCodigo.Text = ObtenerCodigoCosto()
        End If

    End Sub

    Private Sub FrmConceptoUN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnNuevoIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevoIngreso.Click
        _opcion = "Nuevo"
        _esIngreso = True
        tabConcepto.SelectedIndex = 1
        Limpiar()
        txtCodigo.Text = ObtenerCodigoIngreso()
        cboTipo.SelectedIndex = 0
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        _opcion = "Nuevo"
        _esCosto = True
        tabConcepto.SelectedIndex = 1
        Limpiar()
        txtCodigo.Text = ObtenerCodigoCosto()
        cboTipo.SelectedIndex = 2
    End Sub

    Private Function ObtenerCodigoCosto() As String
        Dim codigo As String = ""

        Try
            Dim cmd As New SqlCommand("SELECT DBO.CORRELATIVO_CONCEPTO_UN_COSTO()", con)
            cmd.CommandType = (CommandType.Text)
            con.Open()
            codigo = cmd.ExecuteScalar()
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            con.Close()
        End Try

        Return codigo

    End Function

End Class