Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frm0302

#Region "Variables"
    Dim obj As New Class1
    Dim index As Integer
    Dim item As String
    Dim FechaInicio, FechaFin As DateTime
    Private LoPle0302 As New List(Of Ple_3_02)
    Dim ItemTabla As Integer
    Dim CodigoTipoAccion As String = String.Empty
    Dim CodigoCatalogo As String = String.Empty

#End Region

#Region "Constructor"
    Private Shared instancia As New frm0302
    Public Shared Function ObtenerInstancia() As frm0302
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0302
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

#Region "Estructura"

    Public Structure Ple_3_02
        Public Periodo As String
        Public Item As String
        Public CodigoCuentaContable As String
        Public CodigoEntidadFinanciera As String
        Public CuentaEntidadFinanciera As String
        Public TipoMoneda As String
        Public SaldoDeudor As String
        Public SaldoAcreedor As String
        Public EstadoOperacion As String
        Public NombreBanco As String
        Public MontoMonedaExtranjera As String
    End Structure

    Public Structure Tabla22
        Public Codigo As String
        Public Descripcion As String
        Sub New(ByVal c As String, ByVal d As String)
            Codigo = c
            Descripcion = d
        End Sub
        Public Overrides Function ToString() As String
            Return Me.Descripcion
        End Function
    End Structure

#End Region

#Region "Botones"

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If cbo_año.SelectedIndex = -1 Or cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el año y el mes ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        TabControl1.SelectedTab = tpDetalles
        txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
        btnGuardar.Text = "Guardar"
        cboCatalogo.Focus()
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_mes.SelectedIndex = -1 Or cbo_año.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el mes y año a consultar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
        FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
        MostrarDatos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarDetalles()
        tpRegistros.Parent = TabControl1
        TabControl1.SelectedTab = tpRegistros
        MostrarDatos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'If Validar() = False Then
        '    Exit Sub
        'End If
        'If btnGuardar.Text = "Guardar" Then
        '    InsertarPle()
        '    LimpiarDetalles()
        'Else
        '    ActualizarPle()
        '    LimpiarDetalles()
        '    tpRegistros.Parent = TabControl1
        '    TabControl1.SelectedTab = tpRegistros
        '    btnGuardar.Text = "Guardar"
        '    MostrarDatos()
        'End If
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            index = dgvDatos.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar una fila", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
        tpDetalles.Parent = TabControl1
        TabControl1.SelectedTab = tpDetalles
        txtPeriodo.Text = dgvDatos.Item(0, index).Value
        item = dgvDatos.Item(1, index).Value
        MostrarCodigoCatalogo(dgvDatos.Item(2, index).Value)
        txtRubroEstadoFinanciero.Text = dgvDatos.Item(3, index).Value
        txtSaldoContable.Text = (dgvDatos.Item(4, index).Value)
        txtEstadoOperacion.Text = dgvDatos.Item(5, index).Value
        txtNombreRubro.Text = dgvDatos.Item(6, index).Value
        txtTipo.Text = dgvDatos.Item(7, index).Value
        txtNota.Text = dgvDatos.Item(8, index).Value
        btnGuardar.Text = "Actualizar"
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            index = dgvDatos.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

        Dim rpta As DialogResult = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If rpta = Windows.Forms.DialogResult.Yes Then
            EliminarPle(cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day)
            MostrarDatos()
        End If
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        If LoPle0302.Count <= 0 Then
            MessageBox.Show("No hay registros que exportar")
            Exit Sub
        End If
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}030200011111.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    For i As Integer = 0 To LoPle0302.Count - 1
                        With LoPle0302(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|", _
                              .Periodo _
                            , .CodigoCuentaContable _
                            , .CodigoEntidadFinanciera _
                            , .CuentaEntidadFinanciera _
                            , .TipoMoneda _
                            , .SaldoDeudor _
                            , .SaldoAcreedor _
                            , .EstadoOperacion _
                             ))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

#End Region

#Region "Metodos"
    Private Sub CargarComboTabla22()
        Dim Lista As New List(Of Tabla22)
        Lista.Add(New Tabla22("01", "SECTOR DIVERSAS - INDIVIDUAL"))
        Lista.Add(New Tabla22("02", "SECTOR SEGUROS - INDIVIDUAL"))
        Lista.Add(New Tabla22("03", "SECTOR BANCOS Y FINANCIERAS - INDIVIDUAL"))
        Lista.Add(New Tabla22("04", "ADMINISTRADORAS DE FONDOS DE PENSIONES (AFP)"))
        Lista.Add(New Tabla22("05", "AGENTES DE INTERMEDIACIÓN"))
        Lista.Add(New Tabla22("06", "FONDOS DE INVERSIÓN"))
        Lista.Add(New Tabla22("07", "PATRIMONIO EN FIDEICOMISOS"))
        Lista.Add(New Tabla22("08", "ICLV"))
        Lista.Add(New Tabla22("09", "OTROS NO CONSIDERADOS EN LOS ANTERIORES"))
        cboCatalogo.DataSource = Lista
    End Sub

    Private Sub MostrarCodigoCatalogo(ByVal CodigoCatalogo As String)
        If CodigoCatalogo = "01" Then
            cboCatalogo.SelectedIndex = 0
        ElseIf CodigoCatalogo = "02" Then
            cboCatalogo.SelectedIndex = 1
        ElseIf CodigoCatalogo = "03" Then
            cboCatalogo.SelectedIndex = 2
        ElseIf CodigoCatalogo = "04" Then
            cboCatalogo.SelectedIndex = 3
        ElseIf CodigoCatalogo = "05" Then
            cboCatalogo.SelectedIndex = 4
        ElseIf CodigoCatalogo = "06" Then
            cboCatalogo.SelectedIndex = 5
        ElseIf CodigoCatalogo = "07" Then
            cboCatalogo.SelectedIndex = 6
        ElseIf CodigoCatalogo = "08" Then
            cboCatalogo.SelectedIndex = 7
        ElseIf CodigoCatalogo = "09" Then
            cboCatalogo.SelectedIndex = 8
        Else
            cboCatalogo.SelectedIndex = -1
        End If

    End Sub

    Private Sub MostrarDatos()
        dgvDatos.Rows.Clear()
        ConsultarPle()
        If LoPle0302.Count = 0 Then
            'Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            'rpta = MessageBox.Show("No existen registros del libro electronico, Desea Generarlos ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If (rpta = Windows.Forms.DialogResult.Yes) Then
            '    GenerarPle302(cbo_año.Text, obj.COD_MES(cbo_mes.Text))
            '    ConsultarPle()
            'End If
            MessageBox.Show("No existen registros que mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim i As Integer
        For i = 0 To LoPle0302.Count - 1
            With LoPle0302.Item(i)
                dgvDatos.Rows.Add( _
                                  .Periodo _
                                , .Item _
                                , .CodigoCuentaContable _
                                , .CodigoEntidadFinanciera _
                                , .CuentaEntidadFinanciera _
                                , .TipoMoneda _
                                , .SaldoDeudor _
                                , .SaldoAcreedor _
                                , .EstadoOperacion _
                                , .NombreBanco _
                                , .MontoMonedaExtranjera _
                                 )
            End With
        Next
    End Sub

    Private Sub CARGAR_AÑO()
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

    Private Sub LimpiarDetalles()
        txtRubroEstadoFinanciero.Clear()
        txtSaldoContable.Clear()
        txtNombreRubro.Clear()
        txtTipo.Clear()
        txtNota.Clear()
        cboCatalogo.Focus()
    End Sub

    Private Sub ConsultarPle()
        Dim i As Integer = 0
        LoPle0302.Clear()
        Using cmd As New SqlCommand("MOSTRAR_PLE_3_02", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text 'cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            con.Open()
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            Try
                If drd IsNot Nothing AndAlso drd.HasRows Then
                    Dim oPle As Ple_3_02
                    While drd.Read
                        oPle = New Ple_3_02
                        With oPle
                            .Periodo = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
                            .Item = i + 1
                            .CodigoCuentaContable = drd("COD_CUENTA")
                            .CodigoEntidadFinanciera = drd("COD_BANCO")
                            .CuentaEntidadFinanciera = drd("NRO_CUENTA")
                            .TipoMoneda = drd("COD_INTERNACIONAL")
                            .SaldoDeudor = drd("DEBE")
                            .SaldoAcreedor = drd("HABER")
                            .EstadoOperacion = 1
                            .NombreBanco = drd("DESC_BANCO")
                            .MontoMonedaExtranjera = drd("MONTO_MONEDA_EXTRANJERA")
                            If .SaldoDeudor = 0 And .SaldoAcreedor = 0 Then
                                Continue While
                            End If
                        End With
                        LoPle0302.Add(oPle)
                        i += 1
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    'Private Sub GenerarPle302(ByVal Año As String, ByVal Mes As String)
    '    Dim trx As SqlTransaction = Nothing
    '    Dim loPle302 As List(Of Ple_3_02) = CargarDatosGenerar(Año, Mes)
    '    If LoPle0302.Count > 0 Then
    '        Try
    '            con.Open()
    '            trx = con.BeginTransaction
    '            Dim i As Integer
    '            For i = 0 To LoPle0302.Count - 1
    '                With loPle302(i)
    '                    Using cmd As New SqlCommand("INSERTAR_PLE_3_02", con, trx)
    '                        cmd.CommandType = CommandType.StoredProcedure
    '                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
    '                        cmd.Parameters.AddWithValue("@ITEM", .Item)
    '                        cmd.Parameters.AddWithValue("@COD_CTA_CBLE", .CodigoCuentaContable)
    '                        cmd.Parameters.AddWithValue("@COD_ENT_FINAN", .CodigoEntidadFinanciera)
    '                        cmd.Parameters.AddWithValue("@NRO_CTA", .CuentaEntidadFinanciera)
    '                        cmd.Parameters.AddWithValue("@TIPO_MONEDA", .TipoMoneda)
    '                        cmd.Parameters.AddWithValue("@SALDO_DEUDOR", .SaldoDeudor)
    '                        cmd.Parameters.AddWithValue("@SALDO_ACREEDOR", .SaldoAcreedor)
    '                        cmd.Parameters.AddWithValue("@EST_OPERACION", .EstadoOperacion)
    '                        cmd.Parameters.AddWithValue("@NOMBRE_BANCO", .NombreBanco)
    '                        cmd.Parameters.AddWithValue("@MONTO_MONEDA_EXT", .MontoMonedaExtranjera)
    '                        cmd.CommandTimeout = 720
    '                        cmd.ExecuteNonQuery()
    '                    End Using
    '                End With
    '            Next
    '            MessageBox.Show("Datos generados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            trx.Commit()
    '        Catch ex As Exception
    '            MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            trx.Rollback()
    '        Finally
    '            con.Close()
    '        End Try
    '    End If
    'End Sub

    'Private Sub InsertarPle()
    '    HallarItem()
    '    Using cmd As New SqlCommand("INSERTAR_PLE_3_01", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
    '        cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = (ItemTabla + 1).ToString("00")
    '        cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
    '        cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = txtRubroEstadoFinanciero.Text
    '        cmd.Parameters.Add("@SALDO_CONTABLE", SqlDbType.Decimal).Value = txtSaldoContable.Text
    '        cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
    '        cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = txtNombreRubro.Text
    '        cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = txtTipo.Text
    '        cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = txtNota.Text
    '        Try
    '            con.Open()
    '            Dim i As Integer = cmd.ExecuteNonQuery()
    '            con.Close()
    '            If i > 0 Then
    '                MessageBox.Show("Se inserto el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Else
    '                MessageBox.Show("No se pudo insertar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        Catch Ex As Exception
    '            MessageBox.Show(Ex.ToString, "No se pudo insertar el registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            con.Close()
    '            cmd.Parameters.Clear()
    '        End Try
    '    End Using
    'End Sub

    'Private Sub ActualizarPle()
    '    If Validar() = False Then
    '        Exit Sub
    '    End If
    '    Using cmd As New SqlCommand("ACTUALIZAR_PLE_3_01", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
    '        cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = item
    '        cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
    '        cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = txtRubroEstadoFinanciero.Text
    '        cmd.Parameters.Add("@SALDO_CONTABLE", SqlDbType.Decimal).Value = txtSaldoContable.Text
    '        cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
    '        cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = txtNombreRubro.Text
    '        cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = txtTipo.Text
    '        cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = txtNota.Text
    '        Try
    '            con.Open()
    '            Dim i As Integer = cmd.ExecuteNonQuery()
    '            con.Close()
    '            If i > 0 Then
    '                MessageBox.Show("Se actualizo el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Else
    '                MessageBox.Show("No se pudo actualizar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        Catch Ex As Exception
    '            MessageBox.Show("No se pudo actualizar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            con.Close()
    '            cmd.Parameters.Clear()
    '        End Try
    '    End Using
    'End Sub

    Private Sub EliminarPle(ByVal Periodo As String)
        Using cmd As New SqlCommand("ELIMINAR_PLE_3_02", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = Periodo
            Try
                con.Open()
                Dim i As Integer = cmd.ExecuteNonQuery
                con.Close()
                If i > 0 Then
                    MessageBox.Show("Se elimino el registro", "Eliminación de registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se puedo completar la operación", "Eliminación de registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "No se pudo completar la operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
                cmd.Parameters.Clear()
            End Try
        End Using
    End Sub

    'Private Sub HallarItem()
    '    Dim TItem As Integer
    '    Using cmd As New SqlCommand("RECUPERAR_ITEM_PLE_3_01", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
    '        Try
    '            con.Open()
    '            TItem = cmd.ExecuteScalar()
    '            con.Close()
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End Try
    '        If String.IsNullOrEmpty(TItem) Then
    '            TItem = 0
    '        End If
    '    End Using
    '    ItemTabla = TItem
    'End Sub

#End Region

#Region "Funciones"
    'Private Function Validar() As Boolean
    '    If cboCatalogo.SelectedIndex = -1 Then
    '        MessageBox.Show("Debe seleccionar un dato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        cboCatalogo.Focus()
    '        Return False
    '    End If
    '    If txtRubroEstadoFinanciero.Text.Trim = "" Then
    '        MessageBox.Show("Este dato es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        txtRubroEstadoFinanciero.Focus()
    '        Return False
    '    End If
    '    If txtSaldoContable.Text.Trim = "" Then
    '        MessageBox.Show("Este dato es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        txtSaldoContable.Focus()
    '        Return False
    '    End If
    '    If (txtEstadoOperacion.Text.Trim = "1" Or txtEstadoOperacion.Text.Trim = "8" Or txtEstadoOperacion.Text.Trim = "9") = False Then
    '        MessageBox.Show("El estado de operación solo puede ser 1, 8 ,9 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        txtEstadoOperacion.Focus()
    '        Return False
    '    End If

    '    Return True
    'End Function

    'Private Function CargarDatosGenerar(ByVal AñoProceso As String, ByVal MesProceso As String) As List(Of Ple_3_02)
    '    Dim loPle302 As New List(Of Ple_3_02)
    '    Dim oPle302 As Ple_3_02
    '    Using cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_3_02", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AñoProceso
    '        cmd.Parameters.Add("@MES", SqlDbType.Char).Value = MesProceso
    '        Using DsPle302 As New DataSet
    '            Using DaPle302 As New SqlDataAdapter(cmd)
    '                DaPle302.Fill(DsPle302)
    '                'Asignamos el datarow y el dataadapter
    '                Dim Dr As DataRow
    '                'Recorremos el DaPle302
    '                For i As Integer = 0 To DsPle302.Tables(0).Rows.Count - 1
    '                    Dr = DsPle302.Tables(0).Rows(i)
    '                    oPle302 = New Ple_3_02
    '                    With oPle302
    '                        .Periodo = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
    '                        .Item = (i + 1).ToString("000000")
    '                        .CodigoCuentaContable = Dr("COD_CUENTA")
    '                        .CodigoEntidadFinanciera = Dr("COD_BANCO")
    '                        .CuentaEntidadFinanciera = Dr("NRO_CUENTA")
    '                        .TipoMoneda = Dr("COD_INTERNACIONAL")
    '                        .SaldoDeudor = Dr("DEBE")
    '                        .SaldoAcreedor = Dr("HABER")
    '                        .EstadoOperacion = "1"
    '                        .NombreBanco = Dr("DESC_BANCO")
    '                        .MontoMonedaExtranjera = Dr("MONTO_MONEDA_EXTRANJERA")
    '                    End With
    '                    LoPle0302.Add(oPle302)
    '                Next
    '            End Using
    '        End Using
    '    End Using
    '    Return LoPle0302
    'End Function
#End Region

#Region "Eventos"

    Private Sub frm031601_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frm031601_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        CargarComboTabla22()
        dgvDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        tpDetalles.Parent = Nothing
    End Sub

    Private Sub cboCatalogo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatalogo.SelectedIndexChanged
        CodigoCatalogo = IIf(String.IsNullOrEmpty(cboCatalogo.SelectedValue.Codigo), "", cboCatalogo.SelectedValue.Codigo)
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If ((TabControl1.SelectedTab Is tpDetalles And cbo_año.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1)) Then
            LimpiarDetalles()
            FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
            FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
            txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            cboCatalogo.Focus()
        Else
            If TabControl1.SelectedTab IsNot tpRegistros Then
                tpRegistros.Parent = TabControl1
                TabControl1.SelectedTab = tpRegistros
                MessageBox.Show("Debe elegir el mes y año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnGuardar.Text = "Guardar"
            End If
        End If
    End Sub

    Private Sub txtSaldoContable_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaldoContable.LostFocus
        If txtSaldoContable.Text.Trim = "" Then
            txtSaldoContable.Text = obj.HACER_DECIMAL(0)
        Else
            txtSaldoContable.Text = obj.HACER_DECIMAL(CDbl(txtSaldoContable.Text))
        End If
    End Sub
#End Region

End Class