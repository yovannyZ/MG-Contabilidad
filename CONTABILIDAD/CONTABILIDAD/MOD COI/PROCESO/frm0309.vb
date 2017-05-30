Imports System.Data.SqlClient
Imports System.IO
Public Class frm0309
#Region "Estructura"
    Public Structure Ple0309
        Public Periodo As String
        Public CodigoUnicoOperacion As String
        Public Correlativo As String
        Public Fecha As String
        Public Cuenta As String
        Public Descripcion As String
        Public Valor As Decimal
        Public Amortizacion As Decimal
        Public EstadoOperacion As String
        Public VidaUtil As String
        Public Tasa As String
        Public CodigoInterno As String
        Public Año As String
        Public Mes As String
        Public Item As String
    End Structure
#End Region
#Region "Constructor"
    Private Shared instancia As New frm0309
    Public Shared Function ObtenerInstancia() As frm0309
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0309
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region
#Region "Variables"
    Private LoPle0309 As New List(Of Ple0309)
    Dim obj As New Class1
    Dim FechaInicio, FechaFin As DateTime
    Dim Item As String
    Dim Resul As Short
    Dim index As Integer
#End Region
#Region "Botones"
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
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
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If cbo_año.SelectedIndex = -1 Or cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el año y el mes ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'para el tema de la fecha
        FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
        FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
        '
        'MostrarDatos()
        MostrarDatosSinMensaje()
        'LlenarDgv()
        TabControl1.SelectedTab = tpDetalles
        txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
        btnGuardar.Text = "Guardar"
        txtCorrelativo.Text = "M" & HallarItem()
        txtCUO.Focus()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        LimpiarDetalles()
        tpRegistros.Parent = TabControl1
        TabControl1.SelectedTab = tpRegistros
        MostrarDatosSinMensaje()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidarRegistros() = False Then
            Exit Sub
        End If
        If btnGuardar.Text = "Guardar" Then
            If InsertarRegistroPle() Then
                LimpiarDetalles()
                txtCorrelativo.Text = "M" & HallarItem()
            End If
        End If
        If btnGuardar.Text = "Actualizar" Then
            If ActualizarRegistroPle() Then
                btnCancelar.PerformClick()
            End If
        End If
    End Sub
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Try
            index = dgvDatos.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar una fila", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
        tpDetalles.Parent = TabControl1
        TabControl1.SelectedTab = tpDetalles
        CargarDetalles(index)
        btnGuardar.Text = "Actualizar"
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            index = dgvDatos.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar una fila", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
        Dim rpta As DialogResult = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If rpta = Windows.Forms.DialogResult.Yes Then
            If EliminarRegistroPle(dgvDatos.Item(0, index).Value, dgvDatos.Item(12, index).Value, dgvDatos.Item(13, index).Value, dgvDatos.Item(4, index).Value, dgvDatos.Item(14, index).Value) Then
                btn_consultar.PerformClick()
            End If
        End If
    End Sub
    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If LoPle0309.Count <= 0 Then
            MessageBox.Show("No hay registros que exportar")
            Exit Sub
        End If
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}030900011111.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    For i As Integer = 0 To LoPle0309.Count - 1
                        With LoPle0309(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|", _
                            .Periodo, _
                            .CodigoUnicoOperacion, _
                            .Correlativo, _
                            .Fecha, _
                            .Cuenta, _
                            .Descripcion, _
                            .Valor, _
                            .Amortizacion, _
                            .EstadoOperacion _
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
    Private Sub ConsultarPle()
        LoPle0309.Clear()
        Using Cmd As New SqlCommand("MOSTRAR_PLE_03_09", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            con.Open()
            Try
                Dim drd As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.SingleResult)
                If drd IsNot Nothing AndAlso drd.HasRows Then
                    Dim oPle As Ple0309
                    While drd.Read
                        oPle = New Ple0309
                        With oPle
                            .Periodo = drd("PERIODO")
                            .CodigoUnicoOperacion = drd("CUO")
                            .Correlativo = drd("CORRELATIVO")
                            .Fecha = drd("FECHA_OPE")
                            .Cuenta = drd("COD_CUENTA")
                            .Descripcion = drd("DESCRIPCION")
                            .Valor = drd("VALOR")
                            .Amortizacion = drd("AMORTIZACION")
                            .EstadoOperacion = drd("EST_OPE")
                            .VidaUtil = drd("VIDA_UTIL")
                            .Tasa = drd("TASA")
                            .CodigoInterno = drd("COD_INTERNO_INTAN")
                            .Año = drd("FE_AÑO")
                            .Mes = drd("FE_MES")
                            .Item = drd("ITEM")
                        End With
                        LoPle0309.Add(oPle)
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Private Sub MostrarDatos()
        dgvDatos.Rows.Clear()
        ConsultarPle()
        LlenarDgv()
    End Sub
    Private Sub MostrarDatosSinMensaje()
        dgvDatos.Rows.Clear()
        ConsultarPle()
        If LoPle0309.Count > 0 Then
            Dim i As Integer
            For i = 0 To LoPle0309.Count - 1
                With LoPle0309.Item(i)
                    dgvDatos.Rows.Add( _
                      .Periodo _
                    , .CodigoUnicoOperacion _
                    , .Correlativo _
                    , .Fecha _
                    , .Cuenta _
                    , .Descripcion _
                    , .Valor _
                    , .Amortizacion _
                    , .EstadoOperacion _
                    , .VidaUtil _
                    , .Tasa _
                    , .CodigoInterno _
                    , .Año _
                    , .Mes _
                    , .Item _
                    )
                End With
            Next
        End If
    End Sub
    Private Sub LlenarDgv()
        If LoPle0309.Count > 0 Then
            Dim i As Integer
            For i = 0 To LoPle0309.Count - 1
                With LoPle0309.Item(i)
                    dgvDatos.Rows.Add( _
                      .Periodo _
                    , .CodigoUnicoOperacion _
                    , .Correlativo _
                    , .Fecha _
                    , .Cuenta _
                    , .Descripcion _
                    , .Valor _
                    , .Amortizacion _
                    , .EstadoOperacion _
                    , .VidaUtil _
                    , .Tasa _
                    , .CodigoInterno _
                    , .Año _
                    , .Mes _
                    , .Item _
                    )
                End With
            Next
        Else
            MessageBox.Show("No hay registros por mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub LimpiarDetalles()
        txtCUO.Clear()
        txtCorrelativo.Clear()
        txtCodigoCuentaContable.Clear()
        txtDescripcion.Clear()
        txtValorDelIntangible.Clear()
        txtAmortizacion.Clear()
        txtVidaUtil.Clear()
        txtTasa.Clear()
        txtCodigoInterno.Clear()
    End Sub
    Private Sub CargarDetalles(ByVal indice As Integer)
        txtPeriodo.Text = dgvDatos.Item(0, indice).Value
        txtCUO.Text = dgvDatos.Item(1, indice).Value
        txtCorrelativo.Text = dgvDatos.Item(2, indice).Value
        dtpFechaOperacion.Value = dgvDatos.Item(3, indice).Value
        txtCodigoCuentaContable.Text = dgvDatos.Item(4, indice).Value
        txtDescripcion.Text = dgvDatos.Item(5, indice).Value
        txtValorDelIntangible.Text = dgvDatos.Item(6, indice).Value
        txtAmortizacion.Text = dgvDatos.Item(7, indice).Value
        txtEstadoOperacion.Text = dgvDatos.Item(8, indice).Value
        txtVidaUtil.Text = dgvDatos.Item(9, indice).Value
        txtTasa.Text = dgvDatos.Item(10, indice).Value
        txtCodigoInterno.Text = dgvDatos.Item(11, indice).Value
        Item = dgvDatos.Item(14, indice).Value
    End Sub
#End Region
#Region "Funciones"
    Private Function HallarItem() As String
        Dim it As String = String.Empty
        Using cmd As New SqlCommand("RECUPERAR_ITEM_PLE_03_09", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            Try
                con.Open()
                it = cmd.ExecuteScalar()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            If String.IsNullOrEmpty(it) Or it = Nothing Then
                it = "1"
            Else
                it = CInt(it) + 1
            End If
        End Using
        Item = CInt(it).ToString("000")
        Return it
    End Function
    Private Function InsertarRegistroPle()
        Using cmd As New SqlCommand("INSERTAR_PLE_03_09", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@CUO", SqlDbType.VarChar).Value = txtCUO.Text
            cmd.Parameters.Add("@CORRELATIVO", SqlDbType.VarChar).Value = txtCorrelativo.Text
            cmd.Parameters.Add("@FECHA_OPE", SqlDbType.Date).Value = dtpFechaOperacion.Value
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txtCodigoCuentaContable.Text
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = txtDescripcion.Text
            cmd.Parameters.Add("@VALOR", SqlDbType.Decimal).Value = CDec(txtValorDelIntangible.Text)
            cmd.Parameters.Add("@AMORTIZACION", SqlDbType.Decimal).Value = CDec(txtAmortizacion.Text)
            cmd.Parameters.Add("@EST_OPE", SqlDbType.Char).Value = txtEstadoOperacion.Text
            cmd.Parameters.Add("@VIDA_UTIL", SqlDbType.Text).Value = txtVidaUtil.Text
            cmd.Parameters.Add("@TASA", SqlDbType.VarChar).Value = txtTasa.Text
            cmd.Parameters.Add("@COD_INTERNO_INTAN", SqlDbType.VarChar).Value = txtCodigoInterno.Text
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = Item
            Try
                con.Open()
                Resul = cmd.ExecuteNonQuery
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                con.Close()
            End Try
            If Resul > 0 Then
                MessageBox.Show("Se inserto el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            Else
                MessageBox.Show("No se pudo insertar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End Using
    End Function
    Private Function ActualizarRegistroPle()
        Using cmd As New SqlCommand("ACTUALIZAR_PLE_03_09", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@FECHA_OPE", SqlDbType.Date).Value = dtpFechaOperacion.Value
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txtCodigoCuentaContable.Text
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = txtDescripcion.Text
            cmd.Parameters.Add("@VALOR", SqlDbType.Decimal).Value = CDec(txtValorDelIntangible.Text)
            cmd.Parameters.Add("@AMORTIZACION", SqlDbType.Decimal).Value = CDec(txtAmortizacion.Text)
            cmd.Parameters.Add("@EST_OPE", SqlDbType.Char).Value = txtEstadoOperacion.Text
            cmd.Parameters.Add("@VIDA_UTIL", SqlDbType.Text).Value = txtVidaUtil.Text
            cmd.Parameters.Add("@TASA", SqlDbType.VarChar).Value = txtTasa.Text
            cmd.Parameters.Add("@COD_INTERNO_INTAN", SqlDbType.VarChar).Value = txtCodigoInterno.Text
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = Item
            Try
                con.Open()
                Resul = cmd.ExecuteNonQuery
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                con.Close()
            End Try
            If Resul > 0 Then
                MessageBox.Show("Se actualizo el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            Else
                MessageBox.Show("No se pudo actualizar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End Using
    End Function
    Private Function EliminarRegistroPle(ByVal Periodo As String, ByVal Año As String, ByVal Mes As String, ByVal Cuenta As String, ByVal ItemDoc As String)
        Using cmd As New SqlCommand("ELIMINAR_PLE_03_09", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = Periodo
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = Año
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Mes
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = Cuenta
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = ItemDoc
            Try
                con.Open()
                Resul = cmd.ExecuteNonQuery
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                con.Close()
            End Try
            If Resul > 0 Then
                MessageBox.Show("Se elimino el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return True
            Else
                MessageBox.Show("No se pudo eliminar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End Using
    End Function
    Private Function ValidarRegistros()
        If txtCUO.Text.Trim = "" Then
            MessageBox.Show("Este dato es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCUO.Focus()
            Return False
        End If
        If txtCodigoCuentaContable.Text.Trim = "" AndAlso txtCodigoCuentaContable.Text.Length < 8 Then
            MessageBox.Show("Es necesario un minimo de 8 caracteres para el numero de cuenta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCodigoCuentaContable.Focus()
            Return False
        End If
        If txtDescripcion.Text.Trim = "" Then
            MessageBox.Show("Este campo es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescripcion.Focus()
            Return False
        End If
        If txtValorDelIntangible.Text.Trim = "" Or (IsNumeric(txtValorDelIntangible.Text) = False) Then
            MessageBox.Show("Este campo es obligatorio y debe ser numerico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtValorDelIntangible.Focus()
            Return False
        End If
        If txtAmortizacion.Text.Trim = "" Or (IsNumeric(txtAmortizacion.Text) = False) Then
            MessageBox.Show("Este campo es obligatorio y debe ser numerico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAmortizacion.Focus()
            Return False
        End If
        Return True
    End Function
#End Region
#Region "Eventos"
    Private Sub frm0309_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_AÑO()
    End Sub
    Private Sub frm0309_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtValorDelIntangible_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorDelIntangible.LostFocus
        If txtValorDelIntangible.Text <> "" And IsNumeric(txtValorDelIntangible.Text) Then
            txtValorDelIntangible.Text = obj.HACER_DECIMAL(txtValorDelIntangible.Text)
        End If
    End Sub
    Private Sub txtAmortizacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmortizacion.LostFocus
        If txtAmortizacion.Text <> "" And IsNumeric(txtAmortizacion.Text) Then
            txtAmortizacion.Text = obj.HACER_DECIMAL(txtAmortizacion.Text)
        End If
    End Sub
#End Region    

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If ((TabControl1.SelectedTab Is tpDetalles And cbo_año.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1)) Then
            LimpiarDetalles()
            FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
            FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
            txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            btnGuardar.Text = "Guardar"
            txtCorrelativo.Text = "M" & HallarItem()
            MostrarDatosSinMensaje()
        Else
            If TabControl1.SelectedTab IsNot tpRegistros Then
                tpRegistros.Parent = TabControl1
                TabControl1.SelectedTab = tpRegistros
                MessageBox.Show("Debe elegir el mes y año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnGuardar.Text = "Guardar"
            End If
        End If
    End Sub
End Class