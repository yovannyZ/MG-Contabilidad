Public Class CONSULTA_CONTROL_COMP


#Region "Variables"
    Dim CodAux As String
    Dim obj As New Class1
    Dim Accion As String
#End Region

#Region "Constructor"
    Private Shared instancia As New CONSULTA_CONTROL_COMP
    Public Shared Function ObtenerInstancia() As CONSULTA_CONTROL_COMP
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New CONSULTA_CONTROL_COMP
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

    Private Sub CONSULTA_CONTROL_COMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarAuxiliar()
        CargarAño()
    End Sub

    Sub LlenarAuxiliar()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar.DataSource = DT
        cbo_auxiliar.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar.SelectedIndex = -1
    End Sub

    Private Sub cbo_auxiliar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex <> -1) Then
            CodAux = cbo_auxiliar.SelectedValue.ToString
            If (CodAux <> "System.Data.DataRowView") Then
                LlenarComprobante()
            End If
        End If
    End Sub

    Sub LlenarComprobante()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(CodAux)
        cbo_comprobante.DataSource = DT
        cbo_comprobante.DisplayMember = DT.Columns.Item(0).ToString
        cbo_comprobante.ValueMember = DT.Columns.Item(1).ToString
        cbo_comprobante.SelectedIndex = -1
        If (cbo_comprobante.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Sub CargarAño()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_auxiliar.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_auxiliar.Focus()
        ElseIf cbo_comprobante.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_comprobante.Focus()
        ElseIf cbo_año.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        ElseIf cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        Else
            chkTodos.Enabled = True
            ConsultarICon()
            ConsultarIConControl()
            dgw2.Columns.Clear()
            If dgw1.Rows.Count > 0 Then
                dgw1.Focus()
            End If

        End If

    End Sub

    Private Function ConsultarIConControl() As Boolean
        'dgw1.Rows.Clear()
        Dim _contieneDatos As Boolean = False
        Dim contador As Integer = 1
        Try
            Dim cmd As New SqlCommand("OBTENER_I_CON_CONTROL", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cbo_auxiliar.SelectedValue
            cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = cbo_comprobante.SelectedValue
            con.Open()
            cmd.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = cmd.ExecuteReader
            Do While rs2.Read

                If dgw1.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In dgw1.Rows
                        If rs2.GetValue(1) = row.Cells(2).Value Then
                            row.Cells(1).Value = rs2.GetValue(0)
                            row.Cells(3).Value = Convert.ToBoolean(rs2.GetValue(2))
                            row.Cells(4).Value = rs2.GetValue(3)
                            row.Cells(5).Value = rs2.GetValue(4)
                            Exit For
                        End If
                    Next
                End If

                'dgw1.Rows.Add(contador, rs2.GetValue(0), rs2.GetValue(1), IIf(rs2.GetValue(2) = 0, False, True), rs2.GetValue(3), rs2.GetValue(4))
                _contieneDatos = True

                contador = contador + 1
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return _contieneDatos
    End Function

    Private Sub ConsultarICon()
        dgw1.Rows.Clear()
        Dim contador As Integer = 1
        Try
            Dim cmd As New SqlCommand("OBTENER_I_CON", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cbo_auxiliar.SelectedValue
            cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = cbo_comprobante.SelectedValue
            con.Open()
            cmd.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = cmd.ExecuteReader
            Do While rs2.Read
                dgw1.Rows.Add(contador, rs2.GetValue(0), rs2.GetValue(1), IIf(rs2.GetValue(2) = 0, False, True), rs2.GetValue(3), rs2.GetValue(4))
                contador = contador + 1
            Loop
            Accion = "Insertar"
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cbo_auxiliar.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_auxiliar.Focus()
        ElseIf cbo_comprobante.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_comprobante.Focus()
        ElseIf cbo_año.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        ElseIf cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        Else
            'If ValidarGrid() Then
            If Accion = "Insertar" Then
                InsertarIConControl()

           
            End If
            dgw2.DataSource = Nothing
            dgw2.Refresh()
            chkTodos.Enabled = False
            chkTodos.Checked = False
            'Else
            '    MessageBox.Show("Debe ingresar todos los Nro de File", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If


        End If
    End Sub

    Private Sub InsertarIConControl()
        Dim trx As SqlTransaction = Nothing

        Try
            con.Open()
            trx = con.BeginTransaction
            Dim cmd As SqlCommand
            cmd = New SqlCommand("ELIMINAR_I_CONTROL", con, trx)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cbo_auxiliar.SelectedValue
            cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = cbo_comprobante.SelectedValue
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.CommandTimeout = 720
            cmd.ExecuteNonQuery()


            For Each row As DataGridViewRow In dgw1.Rows
                cmd = New SqlCommand("INSERTAR_I_CON_CONTROL", con, trx)
                cmd.CommandType = (CommandType.StoredProcedure)
                cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cbo_auxiliar.SelectedValue
                cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = cbo_comprobante.SelectedValue
                cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = row.Cells(2).Value
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
                cmd.Parameters.Add("@NRO_FILE", SqlDbType.VarChar).Value = IIf(row.Cells(1).Value = Nothing, "", row.Cells(1).Value)
                cmd.Parameters.Add("@STATUS_SITU", SqlDbType.Char).Value = IIf(row.Cells(3).Value = True, "1", "0")
                cmd.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = IIf(row.Cells(4).Value = Nothing, "", row.Cells(4).Value)
                cmd.Parameters.Add("@MOTIVO_OBSERVACION", SqlDbType.VarChar).Value = IIf(row.Cells(5).Value = Nothing, "", row.Cells(5).Value)
                cmd.CommandTimeout = 720
                cmd.ExecuteNonQuery()
            Next
            trx.Commit()
            MessageBox.Show("Datos Grabados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dgw1.Rows.Clear()

        Catch ex As Exception
            trx.Rollback()
            MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub ActualizarIConControl()
        Dim trx As SqlTransaction = Nothing

        Try
            con.Open()
            trx = con.BeginTransaction
            For Each row As DataGridViewRow In dgw1.Rows
                Dim cmd As New SqlCommand("ACTUALIZAR_I_CON_CONTROL", con, trx)
                cmd.CommandType = (CommandType.StoredProcedure)
                cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cbo_auxiliar.SelectedValue
                cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = cbo_comprobante.SelectedValue
                cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = row.Cells(2).Value
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
                cmd.Parameters.Add("@NRO_FILE", SqlDbType.VarChar).Value = IIf(row.Cells(1).Value = Nothing, "", row.Cells(1).Value)
                cmd.Parameters.Add("@STATUS_SITU", SqlDbType.Char).Value = IIf(row.Cells(3).Value = True, "1", "0")
                cmd.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = IIf(row.Cells(4).Value = Nothing, "", row.Cells(4).Value)
                cmd.Parameters.Add("@MOTIVO_OBSERVACION", SqlDbType.VarChar).Value = IIf(row.Cells(5).Value = Nothing, "", row.Cells(5).Value)
                cmd.CommandTimeout = 720
                cmd.ExecuteNonQuery()
            Next
            trx.Commit()
            MessageBox.Show("Datos Actualizados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            dgw1.Rows.Clear()

        Catch ex As Exception
            trx.Rollback()
            MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub CONSULTA_CONTROL_COMP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Close()
    End Sub

    Private Function ValidarGrid() As Boolean
        Dim esValido As Boolean = True
        For Each row As DataGridViewRow In dgw1.Rows
            If String.IsNullOrEmpty(row.Cells(1).Value) Then
                esValido = False
            End If
        Next
        Return esValido
    End Function

    Private Sub btnIngresarFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresarFile.Click

        If txtNrofile.Text.Trim = "" Then
            MessageBox.Show("Ingrese el Nro. de file", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNrofile.Focus()
        ElseIf numInicio.Value > numFin.Value Then
            MessageBox.Show("El inicio tiene que ser menor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            numInicio.Focus()
        Else

            Dim inicio As Integer = numInicio.Value
            Dim final As Integer = numFin.Value
            Dim cantidadFilas As Integer = dgw1.Rows.Count()
            Dim nrofile As String = txtNrofile.Text

            For Each row As DataGridViewRow In dgw1.Rows
                If Integer.Parse(row.Cells(2).Value) >= inicio And Integer.Parse(row.Cells(2).Value) <= final Then
                    row.Cells(1).Value = nrofile
                End If
            Next

        End If
       
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then
            For Each row As DataGridViewRow In dgw1.Rows
                row.Cells(3).Value = True
            Next
        Else
            For Each row As DataGridViewRow In dgw1.Rows
                row.Cells(3).Value = False
            Next
        End If
    End Sub

    Private Sub dgw1_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellEnter
        t_con()
    End Sub

    Sub t_con()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_TCON_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = cbo_auxiliar.SelectedValue
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = cbo_comprobante.SelectedValue
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
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
End Class