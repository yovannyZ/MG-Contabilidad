Imports System.Data.SqlClient
Public Class FrmNivelConceptoUN
    Dim _opcion As String
    Private Shared _instancia As FrmNivelConceptoUN

    Public Shared Function ObtenerInstancia() As FrmNivelConceptoUN
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmNivelConceptoUN
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub btnNuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo2.Click
        _opcion = "Nuevo"
        Limpiar()
        txtCodigo.Text = ObtenerCodigo()
    End Sub

    Sub Limpiar()
        txtCodigo.Clear()
        txtDescripcion.Clear()
        txtDescripcion.Focus()
    End Sub


    Private Function ObtenerCodigo() As String
        Dim codigo As String = ""

        Try
            Dim cmd As New SqlCommand("SELECT DBO.CORRELATIVO_NIVEL_CONCEPTO_UN()", con)
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text.Equals("") Then
            MessageBox.Show("Ingrese una descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescripcion.Focus()
        Else
            If _opcion = "Nuevo" Then
                Insertar()
                Limpiar()
                txtCodigo.Text = ObtenerCodigo()
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
        Try
            Dim cmd As New SqlCommand("INSERTAR_NIVEL_CONCEPTO_UN", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = descripcion
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("El nivel se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = txtCodigo.Text
        Dim descripcion As String = txtDescripcion.Text
        Try
            Dim cmd As New SqlCommand("ACTUALIZAR_NIVEL_CONCEPTO_UN", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = codigo
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = descripcion
            con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("El nivel se actualizó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Listar()
        dgwListado.DataSource = Nothing

        Try
            Dim cmd As New SqlCommand("LISTAR_NIVEL_CONCEPTO_UN", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgwListado.DataSource = dt
            dgwListado.Columns(0).Width = 30
            dgwListado.Columns(1).Width = 400
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        _opcion = "Nuevo"
        tabConcepto.SelectedIndex = 1
        Limpiar()
        txtCodigo.Text = ObtenerCodigo()
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

        txtCodigo.Text = codigo
        txtDescripcion.Text = descripcion
        tabConcepto.SelectedIndex = 1
    End Sub

    Private Sub FrmNivelConceptoUN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Listar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Limpiar()
        tabConcepto.SelectedIndex = 0
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class