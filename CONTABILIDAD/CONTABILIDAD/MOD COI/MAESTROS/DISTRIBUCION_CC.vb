Imports System.Data.SqlClient
Public Class DISTRIBUCION_CC
    Private obj As New Class1
    Dim codZona, FILA_DET As String
    Private FlagConsulta As Boolean = False
    Dim temp As Integer

    Sub CARGAR_AREAS()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_AREA2", con)
            pro_02.CommandType = CommandType.StoredProcedure
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Origen")
            Prog02.Fill(dt_02)
            dgw_Origen.DataSource = dt_02
            dgw_Origen.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_Destino.DataSource = dt_02
            dgw_Destino.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_origen2.DataSource = dt_02
            dgw_origen2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgwCCostos.DataSource = dt_02
            dgwCCostos.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_Origen.Columns(2).Visible = False
            dgw_Origen.Columns(4).Visible = False
            dgw_Origen.Columns(5).Visible = False
            dgw_origen2.Columns(2).Visible = False
            dgw_origen2.Columns(4).Visible = False
            dgw_origen2.Columns(5).Visible = False
            dgw_Destino.Columns(2).Visible = False
            dgw_Destino.Columns(4).Visible = False
            dgw_Destino.Columns(5).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGAR_NEGOCIO()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_DIRECTORIO_DATO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = "TNEGO"
            Dim da As New SqlDataAdapter(Cmd)
            Dim dt As New DataTable("Negocio")
            da.Fill(dt)
            cboNegocio.DataSource = dt
            cboNegocio.DisplayMember = dt.Columns.Item(1).ToString
            cboNegocio.ValueMember = dt.Columns.Item(0).ToString
            cboNegocio.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub LIMPIAR()
        txtCodAreaOrigen.Clear()
        txtAreaOrigen.Clear()
        txtCodAreaDestino.Clear()
        txtAreaDestino.Clear()
        txtDistribucion.Clear()
        txtTotal.Clear()
        cboNegocio.SelectedIndex = -1
        dgw_mov.Rows.Clear()
        txtCodAreaOrigen.Focus()
    End Sub

    Function OBTENER_TOTAL() As Double
        Dim i As Integer = 0
        Dim cont As Integer = dgw_mov.RowCount - 1
        Dim total As Double = 0
        While i <= cont
            total += dgw_mov.Item(6, i).Value
            i += 1
        End While
        Return total
    End Function
    Function OBTENER_TOTAL2() As Double
        Dim i As Integer = 0
        Dim cont As Integer = dgw_mov2.RowCount - 1
        Dim total As Double = 0
        While i <= cont
            total += dgw_mov2.Item(6, i).Value
            i += 1
        End While
        Return total
    End Function

    Private Sub DISTRIBUCION_CC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DISTRIBUCION_CC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_AREAS()
        CARGAR_NEGOCIO()
        CARGAR_ZONA()
        CARGAR_AÑO()
        GenerarPeriodoTrab()
        cboZona.SelectedIndex = -1
    End Sub
    Sub GenerarPeriodoTrab()
        Dim cmd As New SqlCommand("[CONSULTAR_NROTRAB]", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        con.Open()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        While DR.Read
            dgwNroTrabajadores.Rows.Add(DR(0), DR(1), DR(2), DR(3), DR(4))
        End While
        con.Close()
    End Sub
    Private Sub CARGAR_AÑO()
        cboAño.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cboAño.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_ZONA()
        Dim dt As New DataTable
        Dim sqlda As New SqlDataAdapter("SELECT CODIGO,DESCRIPCION FROM DIRECTORIO WHERE TABLA_COD='TNEGZ' AND TIPO='D'", con)
        con.Open()
        sqlda.Fill(dt)
        cboZona.DataSource = dt
        cboZona.ValueMember = dt.Columns(0).ToString
        cboZona.DisplayMember = dt.Columns(1).ToString
        con.Close()

        'CMD.CommandType = CommandType.Text
        'Dim dt As New DataTable
        'Dim adap As New SqlDataAdapter(dt)
        'Dim DR As SqlDataReader = CMD.ExecuteReader
        'While DR.Read OrElse DR.HasRows
        '    cboZona.Items.Add(DR(0))
        'End While
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        main(153) = 0
        Close()
    End Sub

    Private Sub txtCodAreaOrigen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodAreaOrigen.LostFocus
        If (Strings.Trim(txtCodAreaOrigen.Text) <> "") Then
            If (dgw_Origen.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_Origen.Sort(dgw_Origen.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_Origen.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtCodAreaOrigen.Text.ToLower = dgw_Origen.Item(0, i).Value.ToString.ToLower) Then
                        txtCodAreaOrigen.Text = dgw_Origen.Item(0, i).Value.ToString
                        txtAreaOrigen.Text = dgw_Origen.Item(1, i).Value.ToString
                        dgw_mov.Rows.Clear()
                        FlagConsulta = False
                        'txtCodAreaDestino.Focus()
                        btnConsultar.Focus()
                        Return
                    End If
                    If (txtCodAreaOrigen.Text.ToLower = Strings.Mid((dgw_Origen.Item(0, i).Value), 1, Strings.Len(txtCodAreaOrigen.Text)).ToLower) Then
                        dgw_Origen.CurrentCell = dgw_Origen.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_Origen.CurrentCell = dgw_Origen.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_Origen.Visible = True
                dgw_Origen.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodAreaDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodAreaDestino.LostFocus
        If (Strings.Trim(txtCodAreaDestino.Text) <> "") Then
            If (dgw_Destino.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_Destino.Sort(dgw_Destino.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_Destino.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtCodAreaDestino.Text.ToLower = dgw_Destino.Item(0, i).Value.ToString.ToLower) Then
                        txtCodAreaDestino.Text = dgw_Destino.Item(0, i).Value.ToString
                        txtAreaDestino.Text = dgw_Destino.Item(1, i).Value.ToString
                        cboNegocio.Text = dgw_Destino.Item(3, i).Value.ToString
                        cboZona.Text = dgw_Destino.Item(5, i).Value.ToString
                        CargarNroTrabajadores()
                        txtDistribucion.Focus()
                        Return
                    End If
                    If (txtCodAreaDestino.Text.ToLower = Strings.Mid((dgw_Destino.Item(0, i).Value), 1, Strings.Len(txtCodAreaDestino.Text)).ToLower) Then
                        dgw_Destino.CurrentCell = dgw_Destino.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_Destino.CurrentCell = dgw_Destino.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_Destino.Visible = True
                dgw_Destino.Focus()
            End If
        End If
    End Sub

    Private Sub txtAreaOrigen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAreaOrigen.KeyDown
        If ((Strings.Trim(txtAreaOrigen.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_Origen.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_Origen.Sort(dgw_Origen.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_Origen.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtAreaOrigen.Text.ToLower = Strings.Mid((dgw_Origen.Item(1, i).Value), 1, Strings.Len(txtAreaOrigen.Text)).ToLower) Then
                        dgw_Origen.CurrentCell = dgw_Origen.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_Origen.CurrentCell = dgw_Origen.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_Origen.Visible = True
                dgw_Origen.Focus()
            End If
        End If
    End Sub

    Private Sub txtAreaDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAreaDestino.KeyDown
        If ((Strings.Trim(txtAreaDestino.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_Destino.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_Destino.Sort(dgw_Destino.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_Destino.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtAreaDestino.Text.ToLower = Strings.Mid((dgw_Destino.Item(1, i).Value), 1, Strings.Len(txtAreaDestino.Text)).ToLower) Then
                        dgw_Destino.CurrentCell = dgw_Destino.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_Destino.CurrentCell = dgw_Destino.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_Destino.Visible = True
                dgw_Destino.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_Origen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_Origen.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodAreaOrigen.Text = (dgw_Origen.Item(0, dgw_Origen.CurrentRow.Index).Value)
            txtAreaOrigen.Text = (dgw_Origen.Item(1, dgw_Origen.CurrentRow.Index).Value)
            dgw_mov.Rows.Clear
            FlagConsulta = False
            Panel_Origen.Visible = False
            txtAreaOrigen.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodAreaOrigen.Clear()
            txtAreaOrigen.Clear()
            Panel_Origen.Visible = False
            txtCodAreaOrigen.Focus()
        End If
    End Sub

    Private Sub dgw_Destino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_Destino.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodAreaDestino.Text = (dgw_Destino.Item(0, dgw_Destino.CurrentRow.Index).Value)
            txtAreaDestino.Text = (dgw_Destino.Item(1, dgw_Destino.CurrentRow.Index).Value)
            cboNegocio.Text = (dgw_Destino.Item(3, dgw_Destino.CurrentRow.Index).Value)
            cboZona.Text = (dgw_Destino.Item(5, dgw_Destino.CurrentRow.Index).Value)
            Panel_Destino.Visible = False
            CargarNroTrabajadores()
            txtAreaDestino.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodAreaDestino.Clear()
            txtAreaDestino.Clear()
            Panel_Destino.Visible = False
            txtCodAreaDestino.Focus()
        End If
    End Sub
    Sub CargarNroTrabajadores()
        Dim cmd As New SqlCommand("SELECT NRO_TRABAJADORES from AREA_DISTRIBUCION WHERE COD_AREA=@COD_AREA AND FE_MES=@FE_MES AND FE_AÑO=@FE_AÑO", con)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = txtCodAreaDestino.Text
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        con.Open()
        Dim RSLT As Object = cmd.ExecuteScalar()
        con.Close()
        If RSLT = 0 Then
            MessageBox.Show("No existe trabajadores", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            numTrab.Value = RSLT
        End If
    End Sub

    Private Sub txtDistribucion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDistribucion.KeyPress
        e.Handled = (Not Char.IsDigit(e.KeyChar) AndAlso Not Asc(e.KeyChar) = Keys.Back AndAlso Not e.KeyChar = ".")
    End Sub

    Private Sub txtDistribucion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDistribucion.LostFocus
        If txtDistribucion.TextLength > 0 Then txtDistribucion.Text = obj.HACER_DECIMAL(txtDistribucion.Text)
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If txtCodAreaOrigen.TextLength > 0 Then
            dgw_mov.Rows.Clear()
            Try
                con.Open()
                Dim Cmd As New SqlCommand("[MOSTRAR_DISTRIBUCION_CC]", con)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@COD_AREA_ORIGEN", SqlDbType.VarChar).Value = txtCodAreaOrigen.Text
                Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                Dim dr As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.SingleResult)
                If dr IsNot Nothing AndAlso dr.HasRows Then
                    While dr.Read
                        'ZONAL = obj.DIR_TABLA_DESC(dr(8), "TNEGZ")
                        dgw_mov.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(11), dr(8), dr(7), dr(9), dr(10))
                    End While
                End If
                txtTotal.Text = obj.HACER_DECIMAL(OBTENER_TOTAL())
                FlagConsulta = True
                txtCodAreaDestino.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            For Each ROW As DataGridViewRow In dgw_mov.Rows
                dgw_mov.Item(8, ROW.Index).Value = obj.DIR_TABLA_DESC(dgw_mov.Item(9, ROW.Index).Value.ToString, "TNEGZ")
            Next
        Else
            MessageBox.Show("Seleccione el centro de costos de origen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        btnAgregar.Enabled = True
        txtCodAreaOrigen.Enabled = False
        txtAreaOrigen.Enabled = False

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Not FlagConsulta Then
            MessageBox.Show("Consulte la base de datos para buscar registros relacionados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtCodAreaDestino.TextLength = 0 Then
            MessageBox.Show("Seleccione el centro de costos de destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cboNegocio.SelectedValue = -1 Then
            MessageBox.Show("Seleccione el tipo de negocio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtDistribucion.TextLength = 0 OrElse txtDistribucion.Text = 0 Then
            MessageBox.Show("Ingrese el % de distribución.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cboZona.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione la Zona", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboZona.Focus()
            Exit Sub
        End If
        'If numTrab.Value = 0 Then
        '    MessageBox.Show("Agrege la cantidad de trabajadores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : numTrab.Focus()
        '    Exit Sub
        'End If
        'If txtCodAreaOrigen.Text = txtCodAreaDestino.Text Then
        '    MessageBox.Show("El destino no puede ser igual al origen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        Dim i As Integer = 0
        Dim cont As Integer = dgw_mov.RowCount - 1
        While i <= cont
            If txtCodAreaOrigen.Text = dgw_mov.Item(0, i).Value AndAlso _
            txtCodAreaDestino.Text = dgw_mov.Item(2, i).Value AndAlso _
            cboNegocio.Text = dgw_mov.Item(5, i).Value Then
                MessageBox.Show("El destino seleccionado se encuentra agregado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            i += 1
        End While
        Dim total As Double = obj.HACER_DECIMAL(OBTENER_TOTAL())
        If (total + txtDistribucion.Text) > 100 Then
            MessageBox.Show("El importe de distribución supera el 100%.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        dgw_mov.Rows.Add(txtCodAreaOrigen.Text, txtAreaOrigen.Text, txtCodAreaDestino.Text, _
            txtAreaDestino.Text, cboNegocio.SelectedValue, cboNegocio.Text, txtDistribucion.Text, _
            numTrab.Value, cboZona.Text, codZona, AÑO, MES)

        txtCodAreaDestino.Clear()
        txtAreaDestino.Clear()
        txtDistribucion.Clear()
        txtCodAreaDestino.Focus()
        'numTrab.Value = 0 : cboZona.SelectedIndex = -1
        txtTotal.Text = obj.HACER_DECIMAL(OBTENER_TOTAL())

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If dgw_mov.RowCount = 0 Then
            MessageBox.Show("No existen datos a grabar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtTotal.Text < 100 Then
            MessageBox.Show("Verifique los datos, la distribución actual no llega al 100%.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim i As Integer = 0
        Dim cont As Integer = dgw_mov.RowCount - 1
        Dim trx As SqlTransaction = Nothing
        Try
            con.Open()
            trx = con.BeginTransaction
            Dim Cmd As New SqlCommand("ELIMINAR_DISTRIBUCION_CC", con, trx)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_AREA_ORIGEN", SqlDbType.VarChar).Value = txtCodAreaOrigen.Text
            Cmd.ExecuteNonQuery()
            While i <= cont
                cmd = New SqlCommand("INSERTAR_DISTRIBUCION_CC", con, trx)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@COD_AREA_ORIGEN", SqlDbType.VarChar).Value = dgw_mov.Item(0, i).Value
                Cmd.Parameters.Add("@COD_AREA_DESTINO", SqlDbType.VarChar).Value = dgw_mov.Item(2, i).Value
                'Cmd.Parameters.Add("@COD_NEGOCIO", SqlDbType.Char).Value = dgw_mov.Item(4, i).Value
                Cmd.Parameters.Add("@PORCENTAJE", SqlDbType.Decimal).Value = dgw_mov.Item(6, i).Value
                'Cmd.Parameters.Add("@NUMTRAB", SqlDbType.Int).Value = dgw_mov.Item(7, i).Value
                'Cmd.Parameters.Add("@COD_ZONA", SqlDbType.Char).Value = dgw_mov.Item(9, i).Value
                Cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = dgw_mov.Item(10, i).Value
                Cmd.Parameters.Add("@MES", SqlDbType.Char).Value = dgw_mov.Item(11, i).Value
                Cmd.ExecuteNonQuery()
                i += 1
            End While
            trx.Commit()
            MessageBox.Show("Los datos se ingresaron correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCodAreaDestino.Focus()
            LIMPIAR()
        Catch ex As Exception
            trx.Rollback()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        numTrab.Value = 0
        cboZona.SelectedIndex = -1
        txtCodAreaOrigen.Enabled = True
        txtAreaOrigen.Enabled = True
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If dgw_mov.RowCount = 0 Then
            MessageBox.Show("No existen datos a eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim idx As Integer = dgw_mov.CurrentRow.Index
        dgw_mov.Rows.RemoveAt(idx)
        txtTotal.Text = obj.HACER_DECIMAL(OBTENER_TOTAL())
    End Sub

    Private Sub numTrab_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles numTrab.GotFocus
        numTrab.Select(0, numTrab.ToString().Length)
    End Sub

    Private Sub cboZona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZona.SelectedIndexChanged
        If cboZona.SelectedIndex <> -1 Then
            codZona = ""
            codZona = cboZona.SelectedValue.ToString
        End If
    End Sub
    Private Sub btnconsultar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconsultar2.Click
        If txtcodareaorigen2.TextLength > 0 Then
            dgw_mov2.Rows.Clear()
            Try
                con.Open()
                Dim Cmd As New SqlCommand("MOSTRAR_DISTRIBUCION_CC", con)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@COD_AREA_ORIGEN", SqlDbType.VarChar).Value = txtcodareaorigen2.Text
                Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                Dim dr As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.SingleResult)
                If dr IsNot Nothing AndAlso dr.HasRows Then
                    While dr.Read
                        'ZONAL = obj.DIR_TABLA_DESC(dr(8), "TNEGZ")
                        dgw_mov2.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(11), dr(8), dr(7), dr(9), dr(10))
                    End While
                End If
                txttotal2.Text = obj.HACER_DECIMAL(OBTENER_TOTAL2())
                FlagConsulta = True
                btngrabar2.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            'For Each ROW As DataGridViewRow In dgw_mov2.Rows
            '    dgw_mov2.Item(8, ROW.Index).Value = obj.DIR_TABLA_DESC(dgw_mov2.Item(8, ROW.Index).Value.ToString, "TNEGZ")
            'Next
        Else
            MessageBox.Show("Seleccione el centro de costos de origen.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub txtareaorigen2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtareaorigen2.KeyDown
        If ((Strings.Trim(txtareaorigen2.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_origen2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_origen2.Sort(dgw_origen2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_origen2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtareaorigen2.Text.ToLower = Strings.Mid((dgw_origen2.Item(1, i).Value), 1, Strings.Len(txtareaorigen2.Text)).ToLower) Then
                        dgw_origen2.CurrentCell = dgw_origen2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_origen2.CurrentCell = dgw_origen2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_origen2.Visible = True
                dgw_origen2.Focus()
            End If
        End If
    End Sub

    Private Sub txtcodareaorigen2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodareaorigen2.LostFocus
        If (Strings.Trim(txtcodareaorigen2.Text) <> "") Then
            If (dgw_origen2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_origen2.Sort(dgw_origen2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_origen2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtcodareaorigen2.Text.ToLower = dgw_origen2.Item(0, i).Value.ToString.ToLower) Then
                        txtcodareaorigen2.Text = dgw_origen2.Item(0, i).Value.ToString
                        txtareaorigen2.Text = dgw_origen2.Item(1, i).Value.ToString
                        dgw_mov2.Rows.Clear()
                        FlagConsulta = False
                        'txtCodAreaDestino.Focus()
                        btnconsultar2.Focus()
                        Return
                    End If
                    If (txtcodareaorigen2.Text.ToLower = Strings.Mid((dgw_origen2.Item(0, i).Value), 1, Strings.Len(txtcodareaorigen2.Text)).ToLower) Then
                        dgw_origen2.CurrentCell = dgw_origen2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_origen2.CurrentCell = dgw_origen2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_origen2.Visible = True
                dgw_origen2.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_origen2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_origen2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtcodareaorigen2.Text = (dgw_origen2.Item(0, dgw_origen2.CurrentRow.Index).Value)
            txtareaorigen2.Text = (dgw_origen2.Item(1, dgw_origen2.CurrentRow.Index).Value)
            dgw_mov2.Rows.Clear()
            FlagConsulta = False
            panel_origen2.Visible = False
            txtareaorigen2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtcodareaorigen2.Clear()
            txtareaorigen2.Clear()
            panel_origen2.Visible = False
            txtcodareaorigen2.Focus()
        End If
    End Sub

    Private Sub dgw_mov2_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_mov2.CellEndEdit
        If e.ColumnIndex <> 6 Then Return
        If dgw_mov2.CurrentCell.Value.ToString = "" OrElse Not IsNumeric(dgw_mov2.CurrentCell.Value) Then dgw_mov2.CurrentCell.Value = 0
        Dim value As String = dgw_mov2.CurrentCell.Value.ToString
        Dim row As DataGridViewRow = dgw_mov2.CurrentRow
        dgw_mov2.Item(6, dgw_mov2.CurrentRow.Index).Value = (obj.PRECIO_UNITARIO((dgw_mov2.Item(6, dgw_mov2.CurrentRow.Index).Value)))
        Dim total As Integer = obj.HACER_DECIMAL(OBTENER_TOTAL2())
        If total > 100 Then MessageBox.Show("Supero el 100%", "Information") : dgw_mov2.Item(6, dgw_mov2.CurrentRow.Index).Value = temp : total = obj.HACER_DECIMAL(OBTENER_TOTAL2()) : Exit Sub
        txttotal2.Text = Format(total, "###,###,###,##0.00")
    End Sub

    Private Sub dgw_mov_CellDoubleClick_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_mov2.CellDoubleClick
        temp = dgw_mov2.Item(6, dgw_mov2.CurrentRow.Index).Value
    End Sub

    Private Sub btnsalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir2.Click
        main(153) = 0
        Close()
    End Sub

    Private Sub btngrabar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar2.Click
        If dgw_mov2.Rows.Count = 0 Then MessageBox.Show("No hay registro para actualizar") : Exit Sub
        If CDec(txttotal2.Text) <> 100 Then MessageBox.Show("El valor total no es igual al 100%") : Exit Sub
        For Each row As DataGridViewRow In dgw_mov2.Rows
            Dim cmd As New SqlCommand("ACTUALIZAR_DISTRIBUCION", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_AREA_ORIGEN", SqlDbType.VarChar).Value = dgw_mov2.Item(0, row.Index).Value
            cmd.Parameters.Add("@COD_AREA_DESTINO", SqlDbType.VarChar).Value = dgw_mov2.Item(2, row.Index).Value
            'cmd.Parameters.Add("@COD_NEGOCIO", SqlDbType.Char).Value = dgw_mov2.Item(4, row.Index).Value
            'cmd.Parameters.Add("@COD_ZONA", SqlDbType.Char).Value = dgw_mov2.Item(9, row.Index).Value
            cmd.Parameters.Add("@PORCENTAJE", SqlDbType.Decimal).Value = dgw_mov2.Item(6, row.Index).Value
            'cmd.Parameters.Add("@NRO_TRABAJADORES", SqlDbType.Int).Value = dgw_mov2.Item(7, row.Index).Value
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
        dgw_mov2.Rows.Clear()
    End Sub

    Private Sub btnCargarPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarPeriodo.Click
        If obj.VERIFICAR_CIERRE_PERIODO(AÑO, MES, "COI") = "0" Then
            If ExisteRegistros() = False Then
                If MessageBox.Show("No existen registros en ese periodo ¿Desea generarlos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
                    CARGAR_DISTRIBUCION_CC()
                End If
            Else
                If MessageBox.Show("Se a encontrado registros en ese periodo ¿Desea Eliminarlos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
                    If LimpiarPeriodo() = True Then
                        If MessageBox.Show("No existen registros en ese periodo ¿Desea generarlos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
                            CARGAR_DISTRIBUCION_CC()
                        End If
                    End If
                End If
            End If
        Else
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Function CARGAR_DISTRIBUCION_CC() As Boolean
        dgwDetalle.Rows.Clear()
        Dim RSLT As Boolean = False
        Try
            Dim CMD As New SqlCommand("CONSULTAR_DISTRIBUCION_PERIODO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAño.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text)
            con.Open()
            Dim DR As SqlDataReader = CMD.ExecuteReader
            While DR.Read
                dgwDetalle.Rows.Add(DR(0), DR(1), DR(2), DR(3), AÑO, MES, DR(6), DR(7), DR(8), DR(9))
            End While
            con.Close()
            RSLT = True
        Catch ex As Exception
            con.Close()
        End Try
        Return RSLT
    End Function

    Private Sub btnGrabarModelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarModelo.Click
        If dgwDetalle.Rows.Count > 0 Then
            'If obj.VERIFICAR_CIERRE_PERIODO(AÑO, MES, "COI") = "0" Then
            'If ExisteRegistros() = False Then
            'GrabarModelo()
            'Else
            'If MessageBox.Show("Se a encontrado registros en ese periodo ¿Desea Eliminarlos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            'If LimpiarPeriodo() = True Then
            If GrabarModelo() = True Then
                MessageBox.Show("Operacion Completada", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Disculpe. Se genero un error en el Proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            'End If
            'End If
            'End If
            'Else
            '    MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
        Else
            MessageBox.Show("No hay registros que insertar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Function LimpiarPeriodo() As Boolean
        Dim rslt As Boolean = False
        Try
            Dim CMD As New SqlCommand("DELETE FROM M_DISTRIBUCION_CC WHERE FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES", con)
            CMD.CommandType = CommandType.Text
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            rslt = True
        Catch ex As Exception
            con.Close()
        End Try
        Return rslt
    End Function
    Function ExisteRegistros() As Boolean
        Dim rslt As Boolean = False
        Dim CMD As New SqlCommand("SELECT COUNT(*) FROM M_DISTRIBUCION_CC WHERE FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES", con)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        con.Open()
        Dim NUM As Integer = CMD.ExecuteScalar
        con.Close()
        If NUM > 0 Then rslt = True
        Return rslt
    End Function
    Function GrabarModelo() As Boolean
        Dim rslt As Boolean = False
        Try
            For Each ROW As DataGridViewRow In dgwDetalle.Rows
                Dim CMD As New SqlCommand("INSERT INTO M_DISTRIBUCION_CC VALUES(@COD_AREA_ORIGEN,@COD_AREA_DESTINO,@FE_AÑO,@FE_MES,@PORCENTAJE)", con)
                CMD.CommandType = CommandType.Text
                If con.State = ConnectionState.Closed Then con.Open()

                CMD.Parameters.Add("@COD_AREA_ORIGEN", SqlDbType.VarChar).Value = dgwDetalle.Item(0, ROW.Index).Value
                CMD.Parameters.Add("@COD_AREA_DESTINO", SqlDbType.VarChar).Value = dgwDetalle.Item(1, ROW.Index).Value
                'CMD.Parameters.Add("@COD_NEGOCIO", SqlDbType.Char).Value = dgwDetalle.Item(2, ROW.Index).Value
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                CMD.Parameters.Add("@PORCENTAJE", SqlDbType.Decimal).Value = dgwDetalle.Item(6, ROW.Index).Value
                'CMD.Parameters.Add("@COD_ZONA", SqlDbType.Char).Value = dgwDetalle.Item(7, ROW.Index).Value
                'CMD.Parameters.Add("@NRO_TRABAJADORES", SqlDbType.Int).Value = dgwDetalle.Item(9, ROW.Index).Value
                CMD.ExecuteReader()
            Next
            'LIMPIARMODELO
            con.Close()
            rslt = True
            dgwDetalle.Rows.Clear()
        Catch ex As Exception
            con.Close()
        End Try
        Return rslt
    End Function
    Private Sub btnSalirModelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirModelo.Click
        main(153) = 0
        Close()
    End Sub

    Private Sub dgwCCostos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgwCCostos.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodCCostoDestino.Text = (dgwCCostos.Item(0, dgwCCostos.CurrentRow.Index).Value)
            txtDescCCostoDestino.Text = (dgwCCostos.Item(1, dgwCCostos.CurrentRow.Index).Value)
            'dgwNroTrabajadores.Rows.Clear()
            panCentroCostos.Visible = False
            txtDescCCostoDestino.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodCCostoDestino.Clear()
            txtDescCCostoDestino.Clear()
            panCentroCostos.Visible = False
            txtCodCCostoDestino.Focus()
        End If
    End Sub

    Private Sub btnAgregarTrab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarTrab.Click
        If dgwNroTrabajadores.Rows.Count > 0 Then
            If ExisteCCosto() = False Then
                dgwNroTrabajadores.Rows.Add(txtCodCCostoDestino.Text, txtDescCCostoDestino.Text, AÑO, MES, numTrab1.Value)
            End If
        Else
            dgwNroTrabajadores.Rows.Add(txtCodCCostoDestino.Text, txtDescCCostoDestino.Text, AÑO, MES, numTrab1.Value)
        End If
        'limpiar
        txtCodCCostoDestino.Clear()
        txtDescCCostoDestino.Clear()
        numTrab1.Value = 0
    End Sub
    Function ExisteCCosto() As Boolean
        Dim rslt As Boolean = False
        For Each row As DataGridViewRow In dgwNroTrabajadores.Rows
            If dgwNroTrabajadores.Item(0, row.Index).Value = txtCodCCostoDestino.Text Then MessageBox.Show("Ya se ingreso el Centro Costos") : rslt = True
        Next
        Return rslt
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgwNroTrabajadores.RowCount = 0 Then
            MessageBox.Show("No existen datos para almacenar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            For Each row As DataGridViewRow In dgwNroTrabajadores.Rows
                If EliminarArea(dgwNroTrabajadores.Item(0, row.Index).Value) = True Then
                    If InsertarAreaNroTrab(dgwNroTrabajadores.Item(0, row.Index).Value, dgwNroTrabajadores.Item(4, row.Index).Value) = True Then
                        txtCodCCostoDestino.Clear()
                        txtDescCCostoDestino.Clear()
                        numTrab1.Value = 0
                        Button1.Focus()
                    End If
                End If
            Next
            MessageBox.Show("Se grabo correctamente", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Function InsertarAreaNroTrab(ByVal codArea As String, ByVal nroTrab As Integer) As Boolean
        Dim RSLT As Boolean = False
        Try
            Dim cmd As New SqlCommand("insert into AREA_DISTRIBUCION VALUES(@COD_AREA,@FE_AÑO,@FE_MES,@NROTRAB)", con)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = codArea
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            cmd.Parameters.Add("@NROTRAB", SqlDbType.Char).Value = nroTrab
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            RSLT = True
        Catch ex As Exception
            con.Close()
        End Try
        Return RSLT
    End Function
    Function EliminarArea(ByVal codArea As String) As Boolean
        Dim rslt As Boolean = False
        Try
            Dim cmd As New SqlCommand("DELETE AREA_DISTRIBUCION WHERE COD_AREA=@COD_AREA AND FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES", con)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = codArea
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            rslt = True
        Catch ex As Exception
            con.Close()
        End Try
        Return rslt
    End Function
    Private Sub btnQuitarTrab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarTrab.Click
        If dgwNroTrabajadores.RowCount = 0 Then
            MessageBox.Show("No existen datos a eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim idx As Integer = dgwNroTrabajadores.CurrentRow.Index
        dgwNroTrabajadores.Rows.RemoveAt(idx)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        main(153) = 0
        Close()
    End Sub

    Private Sub txtCodCCostoDestino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCCostoDestino.LostFocus
        If (Strings.Trim(txtCodCCostoDestino.Text) <> "") Then
            If (dgwCCostos.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgwCCostos.Sort(dgwCCostos.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgwCCostos.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtCodCCostoDestino.Text.ToLower = dgwCCostos.Item(0, i).Value.ToString.ToLower) Then
                        txtCodCCostoDestino.Text = dgwCCostos.Item(0, i).Value.ToString
                        txtDescCCostoDestino.Text = dgw_origen2.Item(1, i).Value.ToString
                        Label13.Focus()
                        Return
                    End If
                    If (txtCodCCostoDestino.Text.ToLower = Strings.Mid((dgwCCostos.Item(0, i).Value), 1, Strings.Len(txtCodCCostoDestino.Text)).ToLower) Then
                        dgwCCostos.CurrentCell = dgwCCostos.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgwCCostos.CurrentCell = dgwCCostos.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panCentroCostos.Visible = True
                dgwCCostos.Focus()
            End If
        End If
    End Sub

    Private Sub txtDescCCostoDestino_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescCCostoDestino.KeyDown
        If ((Strings.Trim(txtDescCCostoDestino.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgwCCostos.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgwCCostos.Sort(dgwCCostos.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgwCCostos.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtDescCCostoDestino.Text.ToLower = Strings.Mid((dgwCCostos.Item(1, i).Value), 1, Strings.Len(txtDescCCostoDestino.Text)).ToLower) Then
                        dgwCCostos.CurrentCell = dgwCCostos.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgwCCostos.CurrentCell = dgwCCostos.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panCentroCostos.Visible = True
                dgwCCostos.Focus()
            End If
        End If
    End Sub

    Private Sub numTrab1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles numTrab1.GotFocus
        numTrab1.Select(0, numTrab1.ToString().Length)
    End Sub
End Class