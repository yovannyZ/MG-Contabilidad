Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frm031602
#Region "Variables"
    Dim obj As New Class1
    Dim index As Integer
    Dim item As String
    Dim FechaInicio, FechaFin As DateTime
    Private LoPle031601 As New List(Of Ple_3_16_2)
    Dim ItemTabla As Integer
    Dim CodigoTipoAccion As String = String.Empty

#End Region

#Region "Constructor"
    Private Shared instancia As New frm031602
    Public Shared Function ObtenerInstancia() As frm031602
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm031602
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

#Region "Estructura"

    Public Structure Ple_3_16_2
        Public Periodo As String
        Public Item As String
        Public TipoDocumento As String
        Public NumeroDocumento As String
        Public TipoAcciones As String
        Public Descripcion As String
        Public NumeroAcciones As Decimal
        Public PorcentajeAcciones As String
        Public EstadoOperacion As String
        Public ValorAcciones As Decimal
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
        cboTipoDocumento.Focus()
        txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
        btnGuardar.Text = "Guardar"
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
        btnGuardar.Text = "Guardar"
        MostrarDatos()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidarRegistros() = False Then
            Exit Sub
        End If
        If btnGuardar.Text = "Guardar" Then
            InsertarPle()
            LimpiarDetalles()
        Else
            ActualizarPle()
            LimpiarDetalles()
            tpRegistros.Parent = TabControl1
            TabControl1.SelectedTab = tpRegistros
            btnGuardar.Text = "Guardar"
            MostrarDatos()
        End If
        
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
        RecuperarTipoDocPersonas(dgvDatos.Item(2, index).Value)
        txtNroDocumento.Text = dgvDatos.Item(3, index).Value
        RecuperarTipoAcciones(dgvDatos.Item(4, index).Value)
        txtDescripcion.Text = dgvDatos.Item(5, index).Value
        txtNroAcciones.Text = dgvDatos.Item(6, index).Value
        txtPorcentajeAcciones.Text = dgvDatos.Item(7, index).Value
        txtEstadoOperacion.Text = dgvDatos.Item(8, index).Value
        txtValorAcciones.Text = dgvDatos.Item(9, index).Value
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
            EliminarPle(dgvDatos.Item(0, index).Value, dgvDatos.Item(1, index).Value)
            MostrarDatos()
        End If
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        If LoPle031601.Count <= 0 Then
            MessageBox.Show("No hay registros que exportar")
            Exit Sub
        End If
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}031602011111.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    For i As Integer = 0 To LoPle031601.Count - 1
                        With LoPle031601(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|", _
                            .Periodo, _
                            .TipoDocumento, _
                            .NumeroDocumento, _
                            .TipoAcciones, _
                            .Descripcion, _
                            .NumeroAcciones, _
                            .PorcentajeAcciones, _
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

    Private Sub CARGAR_TIPO_DOC()
        cboTipoDocumento.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_TIPO_DOC_PERSONAL", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboTipoDocumento.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub MostrarDatos()
        dgvDatos.Rows.Clear()
        ConsultarPle()
        If LoPle031601.Count > 0 Then
            Dim i As Integer
            For i = 0 To LoPle031601.Count - 1
                With LoPle031601.Item(i)
                    dgvDatos.Rows.Add(.Periodo, _
                                      .Item, _
                                      .TipoDocumento, _
                                      .NumeroDocumento, _
                                      .TipoAcciones, _
                                      .Descripcion, _
                                      .NumeroAcciones, _
                                      .PorcentajeAcciones, _
                                      .EstadoOperacion, _
                                      .ValorAcciones)
                End With
            Next
        Else
            MessageBox.Show("No hay registros por mostrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
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
        txtNroDocumento.Clear()
        txtDescripcion.Clear()
        txtNroAcciones.Clear()
        txtPorcentajeAcciones.Clear()
        txtValorAcciones.Clear()
        cboTipoDocumento.Focus()
    End Sub

    Private Sub ConsultarPle()
        LoPle031601.Clear()
        Using cmd As New SqlCommand("MOSTRAR_PLE_3_16_2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            con.Open()
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            Try
                If drd IsNot Nothing AndAlso drd.HasRows Then
                    Dim oPle As Ple_3_16_2
                    While drd.Read
                        oPle = New Ple_3_16_2
                        With oPle
                            .Periodo = drd(0)
                            .Item = drd(1)
                            .TipoDocumento = drd(2)
                            .NumeroDocumento = drd(3)
                            .TipoAcciones = drd(4)
                            .Descripcion = drd(5)
                            .NumeroAcciones = drd(6)
                            .PorcentajeAcciones = drd(7)
                            .EstadoOperacion = drd(8)
                            .ValorAcciones = drd(9)
                        End With
                        LoPle031601.Add(oPle)
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub InsertarPle()
        HallarItem()
        Using cmd As New SqlCommand("INSERTAR_PLE_3_16_2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = (ItemTabla + 1).ToString("00")
            cmd.Parameters.Add("@TIPO_DOCUMENTO", SqlDbType.Char).Value = CInt(obj.COD_TIPO_DOC_PER(cboTipoDocumento.Text))
            cmd.Parameters.Add("@NRO_DOCUMENTO", SqlDbType.VarChar).Value = txtNroDocumento.Text
            cmd.Parameters.Add("@COD_TIPO_ACCION", SqlDbType.Char).Value = CodigoTipoAccion
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = txtDescripcion.Text
            cmd.Parameters.Add("@NUMERO_ACCIONES", SqlDbType.Int).Value = txtNroAcciones.Text
            cmd.Parameters.Add("@PORCENTAJE_ACCIONES", SqlDbType.Decimal).Value = txtPorcentajeAcciones.Text
            cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
            cmd.Parameters.Add("@VALOR_ACCIONES", SqlDbType.Decimal).Value = txtValorAcciones.Text
            Try
                con.Open()
                Dim i As Integer = cmd.ExecuteNonQuery()
                con.Close()
                If i > 0 Then
                    MessageBox.Show("Se inserto el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se pudo insertar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString, "No se pudo insertar el registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
                cmd.Parameters.Clear()
            End Try
        End Using
    End Sub

    Private Sub ActualizarPle()
        Using cmd As New SqlCommand("ACTUALIZAR_PLE_3_16_2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = item
            cmd.Parameters.Add("@TIPO_DOCUMENTO", SqlDbType.Char).Value = CInt(obj.COD_TIPO_DOC_PER(cboTipoDocumento.Text))
            cmd.Parameters.Add("@NRO_DOCUMENTO", SqlDbType.VarChar).Value = txtNroDocumento.Text
            cmd.Parameters.Add("@COD_TIPO_ACCION", SqlDbType.Char).Value = CodigoTipoAccion
            cmd.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = txtDescripcion.Text
            cmd.Parameters.Add("@NUMERO_ACCIONES", SqlDbType.Int).Value = txtNroAcciones.Text
            cmd.Parameters.Add("@PORCENTAJE_ACCIONES", SqlDbType.Decimal).Value = txtPorcentajeAcciones.Text
            cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
            cmd.Parameters.Add("@VALOR_ACCIONES", SqlDbType.Decimal).Value = txtValorAcciones.Text
            Try
                con.Open()
                Dim i As Integer = cmd.ExecuteNonQuery()
                con.Close()
                If i > 0 Then
                    MessageBox.Show("Se actualizo el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se pudo actualizar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch Ex As Exception
                MessageBox.Show("No se pudo actualizar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
                cmd.Parameters.Clear()
            End Try
        End Using
    End Sub

    Private Sub EliminarPle(ByVal Periodo As String, ByVal NroItem As String)
        Using cmd As New SqlCommand("ELIMINAR_PLE_3_16_2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = Periodo
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = NroItem
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

    Private Sub HallarItem()
        Dim TItem As Integer
        Using cmd As New SqlCommand("RECUPERAR_ITEM_PLE_3_16_2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            Try
                con.Open()
                TItem = cmd.ExecuteScalar()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            If String.IsNullOrEmpty(TItem) Then
                TItem = 0
            End If
        End Using
        ItemTabla = TItem
    End Sub

    Private Sub RecuperarTipoDocPersonas(ByVal Codigo As String)
        If Codigo = "0" Then
            cboTipoDocumento.SelectedIndex = 1
        ElseIf Codigo = "1" Then
            cboTipoDocumento.SelectedIndex = 2
        ElseIf Codigo = "6" Then
            cboTipoDocumento.SelectedIndex = 3
        Else
            cboTipoDocumento.SelectedIndex = -1
        End If
    End Sub

    Private Sub RecuperarTipoAcciones(ByVal CodigoAccion As String)
        If CodigoAccion = "01" Then
            cboTipoAcciones.SelectedIndex = 0
        ElseIf CodigoAccion = "02" Then
            cboTipoAcciones.SelectedIndex = 1
        ElseIf CodigoAccion = "03" Then
            cboTipoAcciones.SelectedIndex = 2
        ElseIf CodigoAccion = "04" Then
            cboTipoAcciones.SelectedIndex = 3
        Else
            cboTipoAcciones.SelectedIndex = -1
        End If
    End Sub


#End Region

#Region "Funciones"

    Private Function ValidarRegistros() As Boolean
        Dim Key As Boolean = True
        If (txtPeriodo.Text.Trim.Length <> 8) Then
            MessageBox.Show("Debe poner un periodo en formato AAAA/MM/DD", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPeriodo.Focus()
            Return False
        End If
        If cboTipoDocumento.SelectedIndex = -1 Then
            MessageBox.Show("Debe Seleccionar el tipo de documento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTipoDocumento.Focus()
            Return False
        End If
        If cboTipoAcciones.SelectedIndex = -1 Then
            MessageBox.Show("El valor nominal debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTipoAcciones.Focus()
            Return False
        End If
        If txtDescripcion.Text.Trim.Length = 0 Then
            MessageBox.Show("El debe insertar una descripción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescripcion.Focus()
            Return False
        End If
        If txtNroAcciones.Text.Trim.Length = 0 Then
            MessageBox.Show("El número de acciones debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroAcciones.Focus()
            Return False
        End If
        If txtPorcentajeAcciones.Text.Trim.Length = 0 AndAlso CDbl(txtPorcentajeAcciones.Text) > 100 Then
            MessageBox.Show("El porcentaje de acciones debe ser positivo o menor que 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroAcciones.Focus()
            Return False
        End If
        If (txtEstadoOperacion.Text.Trim = "1" Or txtEstadoOperacion.Text.Trim = "8" Or txtEstadoOperacion.Text.Trim = "9") = False Then
            MessageBox.Show("El estado de operación solo puede ser 1, 8 ,9 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEstadoOperacion.Focus()
            Return False
        End If
        If cboTipoDocumento.SelectedIndex = 2 Then
            If txtNroDocumento.Text.Trim.Length <> 8 Then
                MessageBox.Show("Este numero de documento debe tener 8 números", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroDocumento.Focus()
                Return False
            End If
        ElseIf cboTipoDocumento.SelectedIndex = 3 Then
            If txtNroDocumento.Text.Trim.Length <> 11 Then
                MessageBox.Show("Este numero de documento debe tener  11 números", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroDocumento.Focus()
                Return False
            End If
        ElseIf txtNroDocumento.Text.Trim.Length > 15 Then
            MessageBox.Show("El numero de documento solo puede tener  15 números", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroDocumento.Focus()
            Return False
        End If
        Return True
    End Function

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
        CARGAR_TIPO_DOC()
        dgvDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub cboTipoAcciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoAcciones.SelectedIndexChanged
        If cboTipoAcciones.SelectedIndex = -1 Then
            CodigoTipoAccion = ""
        ElseIf cboTipoAcciones.SelectedIndex = 0 Then
            CodigoTipoAccion = "01"
        ElseIf cboTipoAcciones.SelectedIndex = 1 Then
            CodigoTipoAccion = "02"
        ElseIf cboTipoAcciones.SelectedIndex = 2 Then
            CodigoTipoAccion = "03"
        Else
            CodigoTipoAccion = "04"
        End If
    End Sub

    Private Sub txtValorAcciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorAcciones.LostFocus
        If txtValorAcciones.Text.Trim = "" Then
            txtValorAcciones.Text = obj.HACER_DECIMAL("0")
        Else
            txtValorAcciones.Text = obj.HACER_DECIMAL(txtValorAcciones.Text)
        End If
    End Sub

    Private Sub txtPorcentajeAcciones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcentajeAcciones.LostFocus
        If txtPorcentajeAcciones.Text.Trim = "" Then
            txtPorcentajeAcciones.Text = Strings.Format(0, "###,###,###,##0.00000000")
        Else
            txtPorcentajeAcciones.Text = Strings.Format(CDec(txtPorcentajeAcciones.Text), "###,###,###,##0.00000000")
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If ((TabControl1.SelectedTab Is tpDetalles And cbo_año.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1)) Then
            LimpiarDetalles()
            FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
            FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
            txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            cboTipoDocumento.Focus()
        Else
            If TabControl1.SelectedTab IsNot tpRegistros Then
                tpRegistros.Parent = TabControl1
                TabControl1.SelectedTab = tpRegistros
                MessageBox.Show("Debe elegir el mes y año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnGuardar.Text = "Guardar"
                cboTipoDocumento.Focus()
            End If
        End If
    End Sub

    Private Sub txtNroDocumento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroDocumento.LostFocus
        If cboTipoDocumento.SelectedIndex = 2 Then
            If txtNroDocumento.Text.Trim.Length <> 8 Then
                MessageBox.Show("Este nro de documento debe tener 8 números", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroDocumento.Focus()
            End If
        ElseIf cboTipoDocumento.SelectedIndex = 3 Then
            If txtNroDocumento.Text.Trim.Length <> 11 Then
                MessageBox.Show("Este nro de documento debe tener  11 números", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNroDocumento.Focus()
            End If
        ElseIf txtNroDocumento.Text.Trim.Length > 15 Then
            MessageBox.Show("El numero de documento solo puede tener  15 números", "Documento", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroDocumento.Focus()
        End If
    End Sub

#End Region

End Class