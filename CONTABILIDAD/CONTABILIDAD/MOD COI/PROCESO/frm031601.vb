Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frm031601
#Region "Variables"
    Dim obj As New Class1
    Dim index As Integer
    Dim item As String
    Dim FechaInicio, FechaFin As DateTime
    Private LoPle031601 As New List(Of Ple_3_16_1)
    Dim ItemTabla As Integer

#End Region

#Region "Constructor"
    Private Shared instancia As New frm031601
    Public Shared Function ObtenerInstancia() As frm031601
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm031601
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

#Region "Estructura"

    Public Structure Ple_3_16_1
        Public Periodo As String
        Public Item As String
        Public ImporteCapital As Decimal
        Public ValorNominal As Decimal
        Public NumeroAccionesSuscritas As Decimal
        Public NumeroAccionesPagadas As Decimal
        Public EstadoOperacion As String
        Public NumeroAccionistas As String
        Public AumentoCapital As Decimal
        Public FechaAumento As String
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
        txtImporteCapital.Focus()
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
        txtImporteCapital.Text = dgvDatos.Item(2, index).Value
        txtValorNominal.Text = dgvDatos.Item(3, index).Value
        txtNroAccionesSuscritas.Text = dgvDatos.Item(4, index).Value
        txtNroAccionesPagadas.Text = dgvDatos.Item(5, index).Value
        txtEstadoOperacion.Text = dgvDatos.Item(6, index).Value
        txtNroAccionistas.Text = dgvDatos.Item(7, index).Value
        txtAumentoCapital.Text = dgvDatos.Item(8, index).Value
        dtpFechaAumentoCapital.Value = dgvDatos.Item(9, index).Value
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
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}031601011111.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    For i As Integer = 0 To LoPle031601.Count - 1
                        With LoPle031601(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|", _
                            .Periodo, _
                            .ImporteCapital, _
                            .ValorNominal, _
                            .NumeroAccionesSuscritas, _
                            .NumeroAccionesPagadas, _
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

    Private Sub MostrarDatos()
        dgvDatos.Rows.Clear()
        ConsultarPle()
        If LoPle031601.Count > 0 Then
            Dim i As Integer
            For i = 0 To LoPle031601.Count - 1
                With LoPle031601.Item(i)
                    dgvDatos.Rows.Add(.Periodo, _
                                      .Item, _
                                      .ImporteCapital, _
                                      .ValorNominal, _
                                      .NumeroAccionesSuscritas, _
                                      .NumeroAccionesPagadas, _
                                      .EstadoOperacion, _
                                      .NumeroAccionistas, _
                                      .AumentoCapital, _
                                      .FechaAumento)
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
        txtAumentoCapital.Clear()
        txtImporteCapital.Clear()
        txtNroAccionesPagadas.Clear()
        txtNroAccionesSuscritas.Clear()
        txtNroAccionistas.Clear()
        txtValorNominal.Clear()
        txtImporteCapital.Focus()
    End Sub

    Private Sub ConsultarPle()
        LoPle031601.Clear()
        Using cmd As New SqlCommand("MOSTRAR_PLE_3_16_1", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            con.Open()
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            Try
                If drd IsNot Nothing AndAlso drd.HasRows Then
                    Dim oPle As Ple_3_16_1
                    While drd.Read
                        oPle = New Ple_3_16_1
                        With oPle
                            .Periodo = drd(0)
                            .Item = drd(1)
                            .ImporteCapital = drd(2)
                            .ValorNominal = drd(3)
                            .NumeroAccionesSuscritas = drd(4)
                            .NumeroAccionesPagadas = drd(5)
                            .EstadoOperacion = drd(6)
                            .NumeroAccionistas = drd(7)
                            .AumentoCapital = drd(8)
                            .FechaAumento = drd(9)
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
        Using cmd As New SqlCommand("INSERTAR_PLE_3_16_1", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = (ItemTabla + 1).ToString("00")
            cmd.Parameters.Add("@IMPORTE_CAPITAL", SqlDbType.Decimal).Value = txtImporteCapital.Text
            cmd.Parameters.Add("@VALOR_NOMINAL", SqlDbType.Decimal).Value = txtValorNominal.Text
            cmd.Parameters.Add("@NUMERO_ACCIONES_SUSCRITAS", SqlDbType.Decimal).Value = txtNroAccionesSuscritas.Text
            cmd.Parameters.Add("@NUMERO_ACCIONES_PAGADAS", SqlDbType.Decimal).Value = txtNroAccionesPagadas.Text
            cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
            cmd.Parameters.Add("@NUMERO_ACCIONISTAS", SqlDbType.Int).Value = txtNroAccionistas.Text
            cmd.Parameters.Add("@AUMENTO_CAPITAL", SqlDbType.Decimal).Value = txtAumentoCapital.Text
            cmd.Parameters.Add("@FECHA_AUMENTO_CAPITAL", SqlDbType.Date).Value = dtpFechaAumentoCapital.Value.Date
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
        Using cmd As New SqlCommand("ACTUALIZAR_PLE_3_16_1", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = item
            cmd.Parameters.Add("@IMPORTE_CAPITAL", SqlDbType.Decimal).Value = txtImporteCapital.Text
            cmd.Parameters.Add("@VALOR_NOMINAL", SqlDbType.Decimal).Value = txtValorNominal.Text
            cmd.Parameters.Add("@NUMERO_ACCIONES_SUSCRITAS", SqlDbType.Decimal).Value = txtNroAccionesSuscritas.Text
            cmd.Parameters.Add("@NUMERO_ACCIONES_PAGADAS", SqlDbType.Decimal).Value = txtNroAccionesPagadas.Text
            cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
            cmd.Parameters.Add("@NUMERO_ACCIONISTAS", SqlDbType.Int).Value = txtNroAccionistas.Text
            cmd.Parameters.Add("@AUMENTO_CAPITAL", SqlDbType.Decimal).Value = txtAumentoCapital.Text
            cmd.Parameters.Add("@FECHA_AUMENTO_CAPITAL", SqlDbType.Date).Value = dtpFechaAumentoCapital.Value.Date
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
        Using cmd As New SqlCommand("ELIMINAR_PLE_3_16_1", con)
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
        Using cmd As New SqlCommand("RECUPERAR_ITEM_PLE_3_16_1", con)
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

#End Region

#Region "Funciones"

    Private Function ValidarRegistros() As Boolean
        Dim Key As Boolean = True
        If (txtPeriodo.Text.Trim.Length <> 8) Then
            MessageBox.Show("Debe poner un periodo en formato AAAA/MM/DD", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPeriodo.Focus()
            Return False
        End If
        If txtImporteCapital.Text.Trim.Length = 0 OrElse CDbl(txtImporteCapital.Text) < 0 Then
            MessageBox.Show("El importe capital debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtImporteCapital.Focus()
            Return False
        End If
        If txtValorNominal.Text.Trim.Length = 0 OrElse CDbl(txtValorNominal.Text) < 0 Then
            MessageBox.Show("El valor nominal debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtValorNominal.Focus()
            Return False
        End If
        If txtNroAccionesSuscritas.Text.Trim.Length = 0 OrElse CDbl(txtNroAccionesSuscritas.Text) < 0 Then
            MessageBox.Show("El número de acciones suscritas debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroAccionesSuscritas.Focus()
            Return False
        End If
        If txtNroAccionesPagadas.Text.Trim.Length = 0 OrElse CDbl(txtNroAccionesPagadas.Text) < 0 Then
            MessageBox.Show("El número de pagadas suscritas debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroAccionesPagadas.Focus()
            Return False
        End If
        If (txtEstadoOperacion.Text.Trim = "1" Or txtEstadoOperacion.Text.Trim = "8" Or txtEstadoOperacion.Text.Trim = "9") = False Then
            MessageBox.Show("El estado de operación solo puede ser 1, 8 ,9 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEstadoOperacion.Focus()
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
        dgvDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txtImporteCapital_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporteCapital.LostFocus
        If txtImporteCapital.Text.Trim = "" Then
            txtImporteCapital.Text = obj.HACER_DECIMAL("0")
        Else
            txtImporteCapital.Text = obj.HACER_DECIMAL(txtImporteCapital.Text)
        End If
    End Sub

    Private Sub txtValorNominal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorNominal.LostFocus
        If txtValorNominal.Text.Trim = "" Then
            txtValorNominal.Text = obj.HACER_DECIMAL("0")
        Else
            txtValorNominal.Text = obj.HACER_DECIMAL(txtValorNominal.Text)
        End If
    End Sub

    Private Sub txtNroAccionesSuscritas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroAccionesSuscritas.LostFocus
        If txtNroAccionesSuscritas.Text.Trim = "" Then
            txtNroAccionesSuscritas.Text = obj.HACER_DECIMAL("0")
        Else
            txtNroAccionesSuscritas.Text = obj.HACER_DECIMAL(txtNroAccionesSuscritas.Text)
        End If
    End Sub

    Private Sub txtNroAccionesPagadas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNroAccionesPagadas.LostFocus
        If txtNroAccionesPagadas.Text.Trim = "" Then
            txtNroAccionesPagadas.Text = obj.HACER_DECIMAL("0")
        Else
            txtNroAccionesPagadas.Text = obj.HACER_DECIMAL(txtNroAccionesPagadas.Text)
        End If
    End Sub

    Private Sub txtAumentoCapital_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAumentoCapital.LostFocus
        If txtAumentoCapital.Text.Trim = "" Then
            txtAumentoCapital.Text = obj.HACER_DECIMAL("0")
        Else
            txtAumentoCapital.Text = obj.HACER_DECIMAL(txtAumentoCapital.Text)
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If ((TabControl1.SelectedTab Is tpDetalles And cbo_año.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1)) Then
            LimpiarDetalles()
            FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
            FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
            txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            txtImporteCapital.Focus()
        Else
            If TabControl1.SelectedTab IsNot tpRegistros Then
                tpRegistros.Parent = TabControl1
                TabControl1.SelectedTab = tpRegistros
                MessageBox.Show("Debe elegir el mes y año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnGuardar.Text = "Guardar"
            End If
        End If
    End Sub

#End Region

End Class