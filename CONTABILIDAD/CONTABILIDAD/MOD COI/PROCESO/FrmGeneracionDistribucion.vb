Public Class FrmGeneracionDistribucion
    Private obj As New Class1
    Private listaCuentaCC As New List(Of CuentaCentroCosto)
    Private Shared _instancia As FrmGeneracionDistribucion

    Public Shared Function ObtenerInstancia() As FrmGeneracionDistribucion
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmGeneracionDistribucion
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Structure CuentaCentroCosto
        Public CodCuenta As String
        Public CodCentrocosto As String
        Public Importe As Decimal
        Public DH As String
    End Structure

    Public Structure Saldos
        Public CodCuenta As String
        Public CodCC As String
        Public ImporteDebe As Decimal
        Public ImporteHaber As Decimal
    End Structure
    Private Sub FrmGeneracionDistribucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListarCuentas()
        CargarAño()

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

    Private Sub ListarCuentas()
        dgw_cta.DataSource = Nothing

        Try
            Dim cmd As New SqlCommand("LISTAR_CUENTAS_UN", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@OPCION", SqlDbType.Char).Value = "02"
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgw_cta.DataSource = dt
            dgw_cta.Columns(0).Width = 60
            dgw_cta.Columns(1).Width = 250
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtCodCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuenta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txtCodCuenta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existe PERSONAL", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim codigo As String = txtCodCuenta.Text
                dgw_cta.Sort(dgw_cta.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (codigo.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(codigo)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        txtCodCuenta.Text = dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value.ToString
                        txtDescCuenta.Text = dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value.ToString
                        btnGrabar.Focus()
                        Exit Sub
                    End If
                    dgw_cta.CurrentCell = (dgw_cta.Rows.Item(0).Cells.Item(0))
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

    Private Sub dgw_cta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodCuenta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txtDescCuenta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            PaneL_CTA.Visible = False
            btnGrabar.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodCuenta.Clear()
            txtDescCuenta.Clear()
            PaneL_CTA.Visible = False
            txtDescCuenta.Focus()
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cbo_año.SelectedIndex = -1 OrElse cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Verifique los datos de Mes y Año.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        ElseIf txtCodCuenta.Text = "" Then
            MessageBox.Show("Elija una cuenta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodCuenta.Focus()
        ElseIf VERIFICAR_PERIODO_DISTRIBUCION("MM", cbo_año.Text, obj.COD_MES(cbo_mes.Text)) = False Then
            MessageBox.Show("EL Período se encuentra cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Mostrar()
            Dim mess As String = obj.COD_MES(cbo_mes.Text)
            If ValidarCC() = False Then
                MessageBox.Show("No se pudo Generar los datos, verifique los centros de costo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If BlanquearMaestroSaldos(cbo_año.Text, mess, txtCodCuenta.Text) = True Then
                If ConsultarMaestroSaldosCCAnio() = False Then
                    InsertarMaestroSaldosCC()
                Else
                    ActualizarMaestroSaldosCC()
                End If
            End If
            
        End If


    End Sub

    Function BlanquearMaestroSaldos(ByVal anio As String, ByVal mes As String, ByVal cuenta As String) As Boolean
        Dim exito As Boolean = False
        Try
            con.Open()
            Dim cmd As New SqlCommand("BLANQUEAR_MASTRO_SALDOS_CC", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = cuenta
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = anio
            cmd.Parameters.Add("@MES", SqlDbType.VarChar).Value = mes
            cmd.ExecuteNonQuery()
            exito = True
            con.Close()
        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)
        End Try

        Return exito
    End Function

    Function ValidarCC() As Boolean
        For Each row As DataGridViewRow In dgw_mov.Rows
            If String.IsNullOrEmpty(row.Cells(1).Value) Then
                Return False
            End If
        Next
        Return True
    End Function


    Private Sub Mostrar()
        dgw_mov.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_MAESTRO_SALDOS_CC", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txtCodCuenta.Text
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.Parameters.Add("@OPCION", SqlDbType.Char).Value = "D"
            con.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim haber As Decimal = 0
            While dr.Read
                dgw_mov.Rows.Add(dr(0), dr(1), dr(2), haber)
            End While
            dr.Close()

            Dim cmd2 As New SqlCommand("MOSTRAR_GENERAR_MAESTRO_SALDOS_CC", con)
            cmd2.CommandType = CommandType.StoredProcedure
            cmd2.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txtCodCuenta.Text
            cmd2.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd2.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd2.Parameters.Add("@OPCION", SqlDbType.Char).Value = "H"
            'con.Open()

            Dim listaSaldos As New List(Of Saldos)

            Dim dr2 As SqlDataReader = cmd2.ExecuteReader
            
            Dim opcion As Boolean
            While dr2.Read
                opcion = True
                For Each row As DataGridViewRow In dgw_mov.Rows
                    If dr2(0) = row.Cells(0).Value And dr2(1) = row.Cells(1).Value Then
                        haber = dr2(2)
                        row.Cells(3).Value = haber
                        opcion = False
                    End If
                Next

                If opcion = True Then
                    Dim saldo As New Saldos
                    saldo.CodCuenta = dr2(0)
                    saldo.CodCC = dr2(1)
                    saldo.ImporteHaber = dr2(2)
                    listaSaldos.Add(saldo)

                End If

            End While

            For i As Integer = 0 To listaSaldos.Count - 1
                With listaSaldos.Item(i)
                    dgw_mov.Rows.Add(.CodCuenta, .CodCC, 0, .ImporteHaber)
                End With
            Next

            dr2.Close()

            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub InsertarMaestroSaldosCC()

        Dim anio As String = cbo_año.Text
        Dim mess As String = obj.COD_MES(cbo_mes.Text)
        Dim esValido As Boolean = True

        If dgw_mov.Rows.Count > 0 Then
            'Insertar importe Debito
            Dim trx As SqlTransaction = Nothing
            con.Open()
            trx = con.BeginTransaction
            For Each row As DataGridViewRow In dgw_mov.Rows
                With row
                    Try
                        Dim cmd As New SqlCommand("INSERTAR_MAESTRO_SALDOS_CC", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = .Cells(0).Value
                        cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = .Cells(1).Value
                        cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = anio
                        cmd.Parameters.Add("@MES", SqlDbType.VarChar).Value = mess
                        cmd.Parameters.Add("@IM_DEBITO", SqlDbType.VarChar).Value = .Cells(2).Value
                        cmd.Parameters.Add("@IM_CREDITO", SqlDbType.VarChar).Value = .Cells(3).Value
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        trx.Rollback()
                        con.Close()
                        esValido = False
                        MsgBox(ex.Message)
                    End Try
                End With

            Next
            MessageBox.Show("Datos generados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            trx.Commit()
            con.Close()
        End If

    End Sub

    Private Sub ActualizarMaestroSaldosCC()

        Dim anio As String = cbo_año.Text
        Dim mess As String = obj.COD_MES(cbo_mes.Text)
        Dim esValido As Boolean = True

        If dgw_mov.Rows.Count > 0 Then

            Dim trx As SqlTransaction = Nothing
            con.Open()
            trx = con.BeginTransaction
            For Each row As DataGridViewRow In dgw_mov.Rows
                With row
                    Dim query As String
                    If ConsultarMaestroSaldosCC(anio, .Cells(0).Value, .Cells(1).Value) = False Then
                        query = "INSERTAR_MAESTRO_SALDOS_CC"
                    Else
                        query = "ACTUALIZAR_MAESTRO_SALDOS_CC"
                    End If

                    Try
                        Dim cmd As New SqlCommand(query, con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = .Cells(0).Value
                        cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = .Cells(1).Value
                        cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = anio
                        cmd.Parameters.Add("@MES", SqlDbType.VarChar).Value = mess
                        cmd.Parameters.Add("@IM_DEBITO", SqlDbType.VarChar).Value = .Cells(2).Value
                        cmd.Parameters.Add("@IM_CREDITO", SqlDbType.VarChar).Value = .Cells(3).Value
                        cmd.CommandTimeout = 720
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        trx.Rollback()
                        con.Close()
                        esValido = False
                        MsgBox(ex.Message)
                        Exit Sub
                    End Try
                End With

            Next
            MessageBox.Show("Datos generados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            trx.Commit()
            con.Close()
        End If

    End Sub

    Private Function ConsultarMaestroSaldosCCAnio() As Boolean
        Dim existeAño As Boolean = False
        Try
            Dim cmd As New SqlCommand("CONSULTAR_MAESTRO_SALDOS_CC_ANIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = cbo_año.Text
            cmd.CommandTimeout = 720
            con.Open()
            existeAño = cmd.ExecuteScalar > 0
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return existeAño
    End Function

    Private Function ConsultarMaestroSaldosCC(ByVal anio As String, ByVal codCuenta As String, ByVal codCC As String) As Boolean
        Dim existe As Boolean = False
        Try
            Dim con2 As New SqlConnection("data source=" & nombre_servidor & ";initial catalog=BD_COI01;uid=miguel;pwd=main;")
            Dim cmd As New SqlCommand("CONSULTAR_MAESTRO_SALDOS_CC", con2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = anio
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = codCuenta
            cmd.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = codCC
            cmd.CommandTimeout = 720
            con2.Open()
            existe = cmd.ExecuteScalar > 0
            con2.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return existe
    End Function

    Public Function VERIFICAR_PERIODO_DISTRIBUCION(ByVal TIPO0 As String, ByVal AÑO As String, ByVal MES As String) As Boolean
        Dim ESTADO0 As Boolean = False
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_CIERRE_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            PROG_01.Parameters.Add("@MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO0
            con.Open()
            ESTADO0 = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        'If ESTADO0 = Nothing Then ESTADO0 = True
        Return ESTADO0
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class