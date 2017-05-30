Public Class FrmConceptoCCUN
    Private Shared _instancia As FrmConceptoCCUN
    Dim concepto As String = ""
    Dim centroCosto As String = ""

    Public Shared Function ObtenerInstancia() As FrmConceptoCCUN
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmConceptoCCUN
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function



    Private Sub FrmConceptoCCUN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Listar()
        ListarUnidadesNegocio()
    End Sub

    Private Sub ListarUnidadesNegocio()
        dgwListaUnidadesNegocio.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("LISTAR_UNIDAD_NEGOCIO", con)
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                dgwListaUnidadesNegocio.Rows.Add(dr(0), dr(1), 0)
            End While

            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Listar()
        dgwListado.DataSource = Nothing
        Dim count As Integer = 0
        Try
            Dim cmd As New SqlCommand("LISTAR_CONCEPTO_CUENTA_U_N", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgwListado.DataSource = dt
            dgwListado.Columns(0).Width = 30
            dgwListado.Columns(1).Width = 220
            dgwListado.Columns(2).Width = 60
            dgwListado.Columns(3).Width = 230
            dgwListado.Columns(5).Width = 80
            dgwListado.Columns(5).Width = 30

            If dgwListado.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgwListado.Rows
                   
                    If concepto = row.Cells(0).Value And centroCosto = row.Cells(2).Value Then
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

    Private Function ValidarPorcentaje(ByVal codigoConcepto As String, ByVal codigoCentroCosto As String) As Boolean
        Dim esValido As Boolean = False
        Try
            Dim cmd As New SqlCommand("VALIDAR_PORCENTAJE_CONCEPTO_CC_U_N", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CONCEPTO", SqlDbType.Char).Value = codigoConcepto
            cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = codigoCentroCosto
            esValido = cmd.ExecuteScalar > 0
            con.Open()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            Return esValido
        End Try
    End Function



    Private Sub btnAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsociar.Click
        Try
            Dim I As Integer = dgwListado.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

        Dim codigoConcepto As String = (dgwListado.Item(0, dgwListado.CurrentRow.Index).Value)
        Dim descripcionConcepto As String = (dgwListado.Item(1, dgwListado.CurrentRow.Index).Value)
        Dim codigoCentroCosto As String = (dgwListado.Item(2, dgwListado.CurrentRow.Index).Value)
        Dim descripcionCentroCosto As String = (dgwListado.Item(3, dgwListado.CurrentRow.Index).Value)

        Dim tipo As String = ""

        Select Case (dgwListado.Item(4, dgwListado.CurrentRow.Index).Value)
            Case "INGRESO"
                tipo = "I"
            Case "GASTO"
                tipo = "G"

            Case "COSTO"
                tipo = "C"
        End Select

        txtCodConcepto.Text = codigoConcepto
        txtDescConcepto.Text = descripcionConcepto
        txtCentroCosto.Text = codigoCentroCosto
        txtDesCentroCosto.Text = descripcionCentroCosto
        concepto = codigoConcepto
        centroCosto = codigoCentroCosto
        ObtenerConceptoCC(codigoConcepto, codigoCentroCosto, tipo)
        cboTipo.Text = (dgwListado.Item(4, dgwListado.CurrentRow.Index).Value)
        tabConcepto.SelectedIndex = 1

    End Sub

    Private Sub ObtenerConceptoCC(ByVal codigoConcepto As String, ByVal codigoCentroCosto As String, ByVal tipo As String)
        Try
            Dim cmd As New SqlCommand("OBTENER_PORCENTAJE_CONCEPTO_CC_U_N", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CONCEPTO", SqlDbType.Char).Value = codigoConcepto
            cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = codigoCentroCosto
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = tipo
            con.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read
                For Each row As DataGridViewRow In dgwListaUnidadesNegocio.Rows
                    If row.Cells(0).Value = dr(0) Then
                        row.Cells(2).Value = dr(2)
                    End If
                Next
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Insertar()
        Dim codigoConcepto As String = txtCodConcepto.Text
        Dim codigoCentroCosto As String = txtCentroCosto.Text
        Dim tipo As String = ""

        Select Case cboTipo.Text
            Case "INGRESO"
                tipo = "I"
            Case "GASTO"
                tipo = "G"
            Case "COSTO"
                tipo = "C"
        End Select

        If dgwListaUnidadesNegocio.Rows.Count > 0 Then

            ' Validar suma de porcentaje = 100
            Dim total As Decimal = 0
            For Each row As DataGridViewRow In dgwListaUnidadesNegocio.Rows
                total = total + row.Cells(2).Value
            Next

            If total < 100 Or total > 100 Then
                MessageBox.Show("El total del Porcentaje debe sumar 100.00", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim opcion As Boolean = True
                'Eliminar
                Try
                    Dim cmd As New SqlCommand("ELIMINAR_CONCEPTO_CC_U_N", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CONCEPTO", SqlDbType.Char).Value = codigoConcepto
                    cmd.Parameters.Add("@COD_CC", SqlDbType.Char).Value = codigoCentroCosto
                    cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    opcion = False
                    MsgBox(ex.Message)
                End Try

                If opcion = True Then
                    'Insertar
                    For Each row As DataGridViewRow In dgwListaUnidadesNegocio.Rows
                        If row.Cells(2).Value <> 0 Then
                            Dim cmd As New SqlCommand("INSERTAR_CONCEPTO_CC_UN", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Add("@COD_CONCEPTO_U_N", SqlDbType.Char).Value = codigoConcepto
                            cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = codigoCentroCosto
                            cmd.Parameters.Add("@COD_U_N", SqlDbType.Char).Value = row.Cells(0).Value
                            cmd.Parameters.Add("@POR_U_N", SqlDbType.Decimal).Value = row.Cells(2).Value
                            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = tipo
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next
                    MessageBox.Show("Conceptos Asociados correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Listar()
                    ResetearPorcentaje()
                    tabConcepto.SelectedIndex = 0
                End If
            End If

        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Insertar()
    End Sub

    Private Sub Limpiar()
        txtCodConcepto.Clear()
        txtDescConcepto.Clear()
        txtCentroCosto.Clear()
        txtDesCentroCosto.Clear()
        cboTipo.SelectedIndex = -1
    End Sub

    Private Sub ResetearPorcentaje()
        For Each row As DataGridViewRow In dgwListaUnidadesNegocio.Rows
            row.Cells(2).Value = 0
        Next
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        tabConcepto.SelectedIndex = 0
        Limpiar()
        ResetearPorcentaje()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub


End Class