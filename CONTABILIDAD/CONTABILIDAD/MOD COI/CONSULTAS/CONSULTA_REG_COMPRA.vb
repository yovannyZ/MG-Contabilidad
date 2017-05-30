Public Class CONSULTA_REG_COMPRA
    Private COD_AUX As String
    Dim obj As New Class1

#Region "Constructor"
    Private Shared instancia As New CONSULTA_REG_COMPRA
    Public Shared Function ObtenerInstancia() As CONSULTA_REG_COMPRA
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New CONSULTA_REG_COMPRA
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

    Private Sub CONSULTA_REG_COMPRA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTipoDoc()
        CargarPersonas()
    End Sub


    Sub CargarTipoDoc()

        Try
            Dim dt As New DataTable
            Dim cmd As New SqlCommand("CBO_TIPO_DOC_COI", con2)
            con2.Open()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            cboComprobante.DataSource = dt
            cboComprobante.DisplayMember = dt.Columns(1).ToString
            cboComprobante.ValueMember = dt.Columns(0).ToString
            cboComprobante.SelectedIndex = -1
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CargarPersonas()
        Try
            Dim command As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable("PERSONAS")
            adapter.Fill(dataTable)
            dgw_per.DataSource = (dataTable)
            dgw_per.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_per.Columns(0).Width = (55)
            dgw_per.Columns(1).Width = (230)
            dgw_per.Columns(2).Width = (100)
            dgw_per.Columns(3).Width = (0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub txtCodCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCliente.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txtCodCliente.Text) = "") Then
                Return
            End If
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            dgw_per.Sort(dgw_per.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim num2 As Integer = (dgw_per.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (txtCodCliente.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txtCodCliente.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                i += 1
            Loop
            Panel_PER.Visible = True
            dgw_per.Visible = True
            dgw_per.Focus()
        End If
    End Sub

    Private Sub txtRuc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRuc.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txtRuc.Text) = "") Then
                Return
            End If
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            dgw_per.Sort(dgw_per.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
            Dim num2 As Integer = (dgw_per.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (txtRuc.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txtRuc.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                i += 1
            Loop
            Panel_PER.Visible = True
            dgw_per.Visible = True
            dgw_per.Focus()
        End If
    End Sub

   

    Private Sub dgw_per_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodCliente.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txtDescripcion.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txtRuc.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            Panel_PER.Visible = False
            txtRuc.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER.Visible = False
            txtCodCliente.Focus()
            txtCodCliente.Clear()
            txtDescripcion.Clear()
            txtRuc.Clear()
        End If
    End Sub

    Private Sub btnConsultar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If cboComprobante.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un tipo de comprobante", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboComprobante.Focus()
        ElseIf txtNroComprobante.Text.Trim = "" And chkNroDocumento.Checked Then
            MessageBox.Show("Ingrese el nro de comprobante", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNroComprobante.Focus()
        ElseIf txtCodCliente.Text.Trim = "" Then
            MessageBox.Show("Seleccione una persona", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodCliente.Focus()
        Else
            If chkNroDocumento.Checked = False Then
                Dim frmConsulta As New CONSULTA_DOCUMENTO_COMPRA
                frmConsulta.codPer = txtCodCliente.Text
                frmConsulta.codDoc = cboComprobante.SelectedValue
                frmConsulta.fechaIni = dtpDe.Value.ToShortDateString
                frmConsulta.fechaFin = dptHasta.Value.ToShortDateString
                frmConsulta.ShowDialog()

                If frmConsulta.seleccion Then
                    dgw2.Columns.Clear()
                    Consultar(frmConsulta.codDoc, frmConsulta.codPer, frmConsulta.nroDoc, frmConsulta.fechaIni, frmConsulta.fechaFin)

                    If dgw1.Rows.Count > 0 Then
                        dgw1.Focus()
                    End If

                Else
                    dgw2.Columns.Clear()
                    dgw1.Rows.Clear()
                    MessageBox.Show("No seleeciono ningun registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Else
                dgw2.Columns.Clear()
                Consultar(cboComprobante.SelectedValue, txtCodCliente.Text, txtNroComprobante.Text, dtpDe.Value.ToShortDateString, dptHasta.Value.ToShortDateString)
                If dgw1.Rows.Count > 0 Then
                    dgw1.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Consultar(ByVal codDoc As String, ByVal codPer As String, ByVal nroDoc As String, ByVal feIni As Date, ByVal feFin As Date)

        dgw1.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("OBTENER_REGISTRO_COMPRAS", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codPer
            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
            cmd.Parameters.Add("@FE_INICIO", SqlDbType.Date).Value = feIni
            cmd.Parameters.Add("@FE_FIN", SqlDbType.Date).Value = feFin
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(6), _
                dr.GetValue(7), dr.GetValue(8), dr.GetValue(9), dr.GetValue(10), dr.GetValue(11), dr.GetValue(12), dr.GetValue(13), dr.GetValue(14), _
                dr.GetValue(15), dr.GetValue(16), dr.GetValue(17), dr.GetValue(18))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (Strings.Trim(txtDescripcion.Text) = "") Then
                Return
            End If
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            dgw_per.Sort(dgw_per.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            Dim num2 As Integer = (dgw_per.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (txtDescripcion.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txtDescripcion.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                i += 1
            Loop
            Panel_PER.Visible = True
            dgw_per.Visible = True
            dgw_per.Focus()
        End If
    End Sub

    Private Sub dgw1_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (dgw1.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            t_con()
            HALLAR_TOTALES()
        End If
    End Sub

    Sub t_con()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_TCON_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw2.DataSource = (DT)
            '------------tamaños
            dgw2.Columns(0).Width = 60 : dgw2.Columns(1).Width = 200
            dgw2.Columns(2).Width = 70 : dgw2.Columns(3).Width = 70
            dgw2.Columns(4).Width = 70 : dgw2.Columns(5).Width = 70
            dgw2.Columns(6).Width = 35 : dgw2.Columns(7).Width = 60
            dgw2.Columns(8).Width = 60 : dgw2.Columns(9).Width = 80
            dgw2.Columns(10).Width = 70 : dgw2.Columns(11).Width = &H37
            dgw2.Columns(12).Width = &H37 : dgw2.Columns(13).Width = &H2D
            dgw2.Columns(14).Width = &H37 : dgw2.Columns(15).Width = &H37
            dgw2.Columns(16).Width = &H37 : dgw2.Columns(17).Width = &H37
            dgw2.Columns(20).Width = 180
            dgw2.Columns(23).Width = 44
            dgw2.Columns(24).Width = 45
            dgw2.Columns(25).Width = 33
            '------------alineaciones
            dgw2.Columns(2).DefaultCellStyle.Alignment = &H40 : dgw2.Columns(3).DefaultCellStyle.Alignment = &H40
            dgw2.Columns(4).DefaultCellStyle.Alignment = &H40 : dgw2.Columns(5).DefaultCellStyle.Alignment = &H40
            dgw2.Columns(7).DefaultCellStyle.Alignment = &H40 : dgw2.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter : dgw2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '------------formatos
            dgw2.Columns(2).DefaultCellStyle.Format = "N2" : dgw2.Columns(3).DefaultCellStyle.Format = "N2"
            dgw2.Columns(4).DefaultCellStyle.Format = "N2" : dgw2.Columns(5).DefaultCellStyle.Format = "N2"
            dgw2.Columns(10).DefaultCellStyle.Format = "d"
            '------------visibles
            dgw2.Columns(18).Visible = False : dgw2.Columns(19).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub HALLAR_TOTALES()
        Dim sum0, sum1, sum2, sum3 As Decimal
        Dim i, cont As Integer
        cont = dgw2.Rows.Count - 1
        sum0 = 0 : sum1 = 0 : sum2 = 0 : sum3 = 0
        For i = 0 To cont
            sum0 = sum0 + dgw2.Item(2, i).Value
            sum1 = sum1 + dgw2.Item(3, i).Value
            sum2 = sum2 + dgw2.Item(4, i).Value
            sum3 = sum3 + dgw2.Item(5, i).Value
        Next
        txt_debe_soles.Text = OBJ.HACER_DECIMAL(sum0)
        txt_haber_soles.Text = OBJ.HACER_DECIMAL(sum1)
        txt_debe_dolares.Text = OBJ.HACER_DECIMAL(sum2)
        txt_haber_dolares.Text = OBJ.HACER_DECIMAL(sum3)

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Close()
    End Sub

    Private Sub CONSULTA_REG_COMPRA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cboComprobante.SelectedIndex = 1
        txtNroComprobante.Text = ""
        txtCodCliente.Text = ""
        txtDescripcion.Text = ""
        txtRuc.Text = ""
        txt_debe_dolares.Text = ""
        txt_debe_soles.Text = ""
        txt_haber_dolares.Text = ""
        txt_haber_soles.Text = ""
        dgw1.Rows.Clear()
        cboComprobante.Focus()
    End Sub

    Private Sub chkNroDocumento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNroDocumento.CheckedChanged
        txtNroComprobante.Enabled = chkNroDocumento.Checked
    End Sub
End Class