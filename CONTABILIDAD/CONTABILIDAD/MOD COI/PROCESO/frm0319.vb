Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frm0319
#Region "Variables"
    Dim obj As New Class1
    Dim index As Integer
    Dim item As String
    Dim FechaInicio, FechaFin As DateTime
    Private LoPle0319 As New List(Of Ple_3_19)
    Dim ItemTabla As Integer
    Dim CodigoTipoAccion As String = String.Empty
    Dim CodigoCatalogo As String = String.Empty
    Dim Registros As New ArrayList
#End Region
#Region "Constructor"
    Private Shared instancia As New frm0319
    Public Shared Function ObtenerInstancia() As frm0319
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0319
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region
#Region "Estructura"

    Public Structure Ple_3_19
        Public Periodo As String
        Public Item As String
        Public CodigoCatalogo As String
        Public CodigoRubro As String
        Public Capital As Decimal
        Public AccionesInversion As Decimal
        Public CapitalAdicional As Decimal
        Public ResultadosNoRealizados As Decimal
        Public ReservasLegales As Decimal
        Public OtrasReservas As Decimal
        Public ResultadosAcumulados As Decimal
        Public DiferenciasDeConversion As Decimal
        Public AjustesAlPatrimonio As Decimal
        Public ResultadoNetoDelEjercicio As Decimal
        Public ExcedenteDeRevaluacion As Decimal
        Public ResultadoDelEjercicio As Decimal
        Public EstadoOperacion As String
        Public NombreRubro As String
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
        gbActivos.Visible = True
        TabControl1.SelectedTab = tpDetalles
        PintarGrilla()
        txtPeriodo.Text = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
        btnGuardar.Text = "Guardar"
        dgvActivos.Focus()
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
        If Validar() = False Then
            Exit Sub
        End If
        If btnGuardar.Text = "Guardar" Then
            InsertarPle()
            LimpiarDetalles()
            tpRegistros.Parent = TabControl1
            TabControl1.SelectedTab = tpRegistros
            MostrarDatos()
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
        gbActivos.Visible = False
        tpDetalles.Parent = TabControl1
        TabControl1.SelectedTab = tpDetalles
        txtPeriodo.Text = dgvDatos.Item(0, index).Value
        MostrarCodigoCatalogo(dgvDatos.Item(1, index).Value)
        txtRubroEstadoFinanciero.Text = dgvDatos.Item(2, index).Value
        txtCapital.Text = dgvDatos.Item(3, index).Value
        txtAccionesInversion.Text = dgvDatos.Item(4, index).Value
        txtCapitalAdicional.Text = dgvDatos.Item(5, index).Value
        txtResultadoNoRealizado.Text = dgvDatos.Item(6, index).Value
        txtReservasLegales.Text = dgvDatos.Item(7, index).Value
        txtOtrasReservas.Text = dgvDatos.Item(8, index).Value
        txtResultadoAcumulados.Text = dgvDatos.Item(9, index).Value
        txtDiferenciasConversion.Text = dgvDatos.Item(10, index).Value
        txtAjustesAlPatrimonio.Text = dgvDatos.Item(11, index).Value
        txtResultadoNetoEjercicio.Text = dgvDatos.Item(12, index).Value
        txtExcedenteRevaluacion.Text = dgvDatos.Item(13, index).Value
        txtResultadoEjercicio.Text = dgvDatos.Item(14, index).Value
        txtEstadoOperacion.Text = dgvDatos.Item(15, index).Value
        txtNombreRubro.Text = dgvDatos.Item(16, index).Value
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
            EliminarPle(dgvDatos.Item(0, index).Value, dgvDatos.Item(1, index).Value, dgvDatos.Item(2, index).Value)
            MostrarDatos()
        End If
    End Sub
    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        If LoPle0319.Count <= 0 Then
            MessageBox.Show("No hay registros que exportar")
            Exit Sub
        End If
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}031900011111.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    For i As Integer = 0 To LoPle0319.Count - 1
                        With LoPle0319(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|", _
                             .Periodo _
                           , .CodigoCatalogo _
                           , .CodigoRubro _
                           , .Capital _
                           , .AccionesInversion _
                           , .CapitalAdicional _
                           , .ResultadosNoRealizados _
                           , .ReservasLegales _
                           , .OtrasReservas _
                           , .ResultadosAcumulados _
                           , .DiferenciasDeConversion _
                           , .AjustesAlPatrimonio _
                           , .ResultadoNetoDelEjercicio _
                           , .ExcedenteDeRevaluacion _
                           , .ResultadoDelEjercicio _
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
        If LoPle0319.Count > 0 Then
            Dim i As Integer
            For i = 0 To LoPle0319.Count - 1
                With LoPle0319.Item(i)
                    dgvDatos.Rows.Add(.Periodo _
                    , .CodigoCatalogo _
                    , .CodigoRubro _
                    , .Capital _
                    , .AccionesInversion _
                    , .CapitalAdicional _
                    , .ResultadosNoRealizados _
                    , .ReservasLegales _
                    , .OtrasReservas _
                    , .ResultadosAcumulados _
                    , .DiferenciasDeConversion _
                    , .AjustesAlPatrimonio _
                    , .ResultadoNetoDelEjercicio _
                    , .ExcedenteDeRevaluacion _
                    , .ResultadoDelEjercicio _
                    , .EstadoOperacion _
                    , .NombreRubro _
                    )
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
        LimpiarGrilla()
        txtRubroEstadoFinanciero.Clear()
        txtCapital.Clear()
        txtAccionesInversion.Clear()
        txtCapitalAdicional.Clear()
        txtResultadoNoRealizado.Clear()
        txtReservasLegales.Clear()
        txtOtrasReservas.Clear()
        txtResultadoAcumulados.Clear()
        txtDiferenciasConversion.Clear()
        txtAjustesAlPatrimonio.Clear()
        txtResultadoNetoEjercicio.Clear()
        txtExcedenteRevaluacion.Clear()
        txtResultadoEjercicio.Clear()
        txtNombreRubro.Clear()
        cboCatalogo.Focus()
    End Sub
    Private Sub ConsultarPle()
        LoPle0319.Clear()
        Using cmd As New SqlCommand("MOSTRAR_PLE_03_19", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            con.Open()
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            Try
                If drd IsNot Nothing AndAlso drd.HasRows Then
                    Dim oPle As Ple_3_19
                    While drd.Read
                        oPle = New Ple_3_19
                        With oPle
                            .Periodo = drd(0)
                            .CodigoCatalogo = drd(1)
                            .CodigoRubro = drd(2)
                            .Capital = drd(3)
                            .AccionesInversion = drd(4)
                            .CapitalAdicional = drd(5)
                            .ResultadosNoRealizados = drd(6)
                            .ReservasLegales = drd(7)
                            .OtrasReservas = drd(8)
                            .ResultadosAcumulados = drd(9)
                            .DiferenciasDeConversion = drd(10)
                            .AjustesAlPatrimonio = drd(11)
                            .ResultadoNetoDelEjercicio = drd(12)
                            .ExcedenteDeRevaluacion = drd(13)
                            .ResultadoDelEjercicio = drd(14)
                            .EstadoOperacion = drd(15)
                            .NombreRubro = drd(16)
                        End With
                        LoPle0319.Add(oPle)
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    'Private Sub InsertarPle()
    '    HallarItem()
    '    Using cmd As New SqlCommand("INSERTAR_PLE_3_19", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
    '        cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = (ItemTabla + 1).ToString("00")
    '        cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
    '        cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = txtRubroEstadoFinanciero.Text
    '        cmd.Parameters.Add("@CAPITAL", SqlDbType.Decimal).Value = txtCapital.Text
    '        cmd.Parameters.Add("@ACCIONES_INVERSION", SqlDbType.Decimal).Value = txtAccionesInversion.Text
    '        cmd.Parameters.Add("@CAPITAL_ADICIONAL", SqlDbType.Decimal).Value = txtCapitalAdicional.Text
    '        cmd.Parameters.Add("@RESULTADOS_NO_REALIZADOS", SqlDbType.Decimal).Value = txtResultadoNoRealizado.Text
    '        cmd.Parameters.Add("@RESERVAS_LEGALES", SqlDbType.Decimal).Value = txtReservasLegales.Text
    '        cmd.Parameters.Add("@OTRAS_RESERVAS", SqlDbType.Decimal).Value = txtOtrasReservas.Text
    '        cmd.Parameters.Add("@RESULTADOS_ACUMULADOS", SqlDbType.Decimal).Value = txtResultadoAcumulados.Text
    '        cmd.Parameters.Add("@DIFERENCIAS_CONVERSION", SqlDbType.Decimal).Value = txtDiferenciasConversion.Text
    '        cmd.Parameters.Add("@AJUSTES_PATRIMONIO", SqlDbType.Decimal).Value = txtAjustesAlPatrimonio.Text
    '        cmd.Parameters.Add("@RESULTADO_NETO_EJERCICIO", SqlDbType.Decimal).Value = txtResultadoNetoEjercicio.Text
    '        cmd.Parameters.Add("@EXCEDENTE_REVALUACION", SqlDbType.Decimal).Value = txtExcedenteRevaluacion.Text
    '        cmd.Parameters.Add("@RESULTADO_EJERCICIO", SqlDbType.Decimal).Value = txtResultadoEjercicio.Text
    '        cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Decimal).Value = txtEstadoOperacion.Text
    '        cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = txtNombreRubro.Text
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
    Private Sub InsertarPle()
        Dim tr As SqlTransaction = Nothing
        Dim key As Boolean = True
        Dim CantidadRegistros As Integer = Registros.Count
        Dim z As Integer = 0
        con.Open()
        tr = con.BeginTransaction
        While (z < CantidadRegistros)
            If ValidarRegistros(Registros.Item(z)(1).ToString, tr).ToString.Length > 0 Then
                z += 1
                Continue While
            End If
            Using cmd As New SqlCommand("INSERTAR_PLE_03_19", con, tr)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
                cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
                cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = Registros.Item(z)(1).ToString
                cmd.Parameters.Add("@CAPITAL", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(2).ToString)
                cmd.Parameters.Add("@ACCIONES_INVERSION", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(3).ToString)
                cmd.Parameters.Add("@CAPITAL_ADICIONAL", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(4).ToString)
                cmd.Parameters.Add("@RESULTADOS_NO_REALIZADOS", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(5).ToString)
                cmd.Parameters.Add("@RESERVAS_LEGALES", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(6).ToString)
                cmd.Parameters.Add("@OTRAS_RESERVAS", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(7).ToString)
                cmd.Parameters.Add("@RESULTADOS_ACUMULADOS", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(8).ToString)
                cmd.Parameters.Add("@DIFERENCIAS_CONVERSION", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(9).ToString)
                cmd.Parameters.Add("@AJUSTES_PATRIMONIO", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(10).ToString)
                cmd.Parameters.Add("@RESULTADO_NETO_EJERCICIO", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(11).ToString)
                cmd.Parameters.Add("@EXCEDENTE_REVALUACION", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(12).ToString)
                cmd.Parameters.Add("@RESULTADO_EJERCICIO", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(13).ToString)
                cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Decimal).Value = txtEstadoOperacion.Text
                cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = Registros.Item(z)(0).ToString
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes.Text)
                Try
                    cmd.ExecuteNonQuery()
                Catch Ex As Exception
                    MessageBox.Show(Ex.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    key = False
                    tr.Rollback()
                    con.Close()
                    Exit While
                Finally
                    cmd.Parameters.Clear()
                End Try
            End Using
            z += 1
        End While
        If key = True Then
            tr.Commit()
            MessageBox.Show("Se inserto el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No se pudo insertar los registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        con.Close()
    End Sub
    Private Sub ActualizarPle()
        'If Validar() = False Then
        '    Exit Sub
        'End If
        Using cmd As New SqlCommand("ACTUALIZAR_PLE_03_19", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
            cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = txtRubroEstadoFinanciero.Text
            cmd.Parameters.Add("@CAPITAL", SqlDbType.Decimal).Value = txtCapital.Text
            cmd.Parameters.Add("@ACCIONES_INVERSION", SqlDbType.Decimal).Value = txtAccionesInversion.Text
            cmd.Parameters.Add("@CAPITAL_ADICIONAL", SqlDbType.Decimal).Value = txtCapitalAdicional.Text
            cmd.Parameters.Add("@RESULTADOS_NO_REALIZADOS", SqlDbType.Decimal).Value = txtResultadoNoRealizado.Text
            cmd.Parameters.Add("@RESERVAS_LEGALES", SqlDbType.Decimal).Value = txtReservasLegales.Text
            cmd.Parameters.Add("@OTRAS_RESERVAS", SqlDbType.Decimal).Value = txtOtrasReservas.Text
            cmd.Parameters.Add("@RESULTADOS_ACUMULADOS", SqlDbType.Decimal).Value = txtResultadoAcumulados.Text
            cmd.Parameters.Add("@DIFERENCIAS_CONVERSION", SqlDbType.Decimal).Value = txtDiferenciasConversion.Text
            cmd.Parameters.Add("@AJUSTES_PATRIMONIO", SqlDbType.Decimal).Value = txtAjustesAlPatrimonio.Text
            cmd.Parameters.Add("@RESULTADO_NETO_EJERCICIO", SqlDbType.Decimal).Value = txtResultadoNetoEjercicio.Text
            cmd.Parameters.Add("@EXCEDENTE_REVALUACION", SqlDbType.Decimal).Value = txtExcedenteRevaluacion.Text
            cmd.Parameters.Add("@RESULTADO_EJERCICIO", SqlDbType.Decimal).Value = txtResultadoEjercicio.Text
            'cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Decimal).Value = txtEstadoOperacion.Text
            'cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = txtNombreRubro.Text
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
    Private Sub EliminarPle(ByVal Periodo As String, ByVal CodCatalogo As String, ByVal CodRubro As String)
        Using cmd As New SqlCommand("ELIMINAR_PLE_03_19", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = Periodo
            cmd.Parameters.Add("@COD_CATALOGO", SqlDbType.Char).Value = CodCatalogo
            cmd.Parameters.Add("@COD_RUBRO", SqlDbType.Char).Value = CodRubro
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
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
        Using cmd As New SqlCommand("RECUPERAR_ITEM_PLE_3_19", con)
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
    Private Sub LlenarGrilla()
        'dgvActivos.Rows.Add("Saldos al 1ero. de enero de", "4E0101")
        'dgvActivos.Rows.Add("Ajustes por cambios en políticas contables", "4E0131")
        'dgvActivos.Rows.Add(" Ajustes por corrección de errores", "4E0132")
        'dgvActivos.Rows.Add("Saldo Inicial después de ajustes", "4E0133")
        'dgvActivos.Rows.Add("Cambios en Patrimonio:")
        'dgvActivos.Rows.Add("Resultado(Integral)")
        'dgvActivos.Rows.Add("Resultado del Ejercicio", "4E0111")
        'dgvActivos.Rows.Add("Otro Resultado Integral", "4E0134")
        'dgvActivos.Rows.Add("Resultado Integral Total", "4E0135")
        'dgvActivos.Rows.Add("Cambios en el Patrimonio neto (no incluidos en el Resultado Integral)")
        'dgvActivos.Rows.Add("Transferencia de Resultado del Ejercicio a Resultados acumulados", "4E0136")
        'dgvActivos.Rows.Add("Dividendos en efectivo declarados", "4E0104")
        'dgvActivos.Rows.Add("Emisión de acciones  de Capital (distinto a combinación de negocios)", "4E0137")
        'dgvActivos.Rows.Add("Reducción de Capital (distinto a combinación de negocios)", "4E0138")
        'dgvActivos.Rows.Add("Incremento (disminución) de Combinaciones de Negocios", "4E0139")
        'dgvActivos.Rows.Add("Incremento (disminución) por transacciones de acciones en tesorería", "4E0140")
        'dgvActivos.Rows.Add("Incremento (Disminución) por Transferencia y Otros Cambios", "4E0141")
        'dgvActivos.Rows.Add("Total de cambios en el patrimonio", "4E0142")
        'dgvActivos.Rows.Add("Saldos al 31 de diciembre de", "4E01ST")
        'dgvActivos.Rows.Add("Saldos al 1ero. de enero de", "4E0201")
        'dgvActivos.Rows.Add("Ajustes por cambios en políticas contables", "4E0231")
        'dgvActivos.Rows.Add("Ajustes por corrección de errores", "4E0232")
        'dgvActivos.Rows.Add("Saldo Inicial después de ajustes", "4E0233")
        'dgvActivos.Rows.Add("Cambios en Patrimonio:")
        'dgvActivos.Rows.Add("Resultado(Integral)")
        'dgvActivos.Rows.Add("Resultado del Ejercicio", "4E0211")
        'dgvActivos.Rows.Add("Otro Resultado Integral", "4E0234")
        'dgvActivos.Rows.Add("Resultado Integral Total", "4E0235")
        'dgvActivos.Rows.Add("Cambios en el Patrimonio neto (no incluidos en el Resultado Integral)")
        'dgvActivos.Rows.Add("Transferencia de Resultado del Ejercicio a Resultados acumulados", "4E0236")
        'dgvActivos.Rows.Add("Dividendos en efectivo declarados", "4E0204")
        'dgvActivos.Rows.Add("Emisión de acciones  de Capital (distinto a combinación de negocios)", "4E0237")
        'dgvActivos.Rows.Add("Reducción de Capital (distinto a combinación de negocios)", "4E0238")
        'dgvActivos.Rows.Add("Incremento (disminución) de Combinaciones de Negocios", "4E0239")
        'dgvActivos.Rows.Add("Incremento (disminución) por transacciones de acciones en tesorería", "4E0240")
        'dgvActivos.Rows.Add("Incremento (Disminución) por Transferencia y Otros Cambios", "4E0241")
        'dgvActivos.Rows.Add("Total de cambios en el patrimonio", "4E0242")
        'dgvActivos.Rows.Add("Saldos al 31 de diciembre de", "4E02ST")
        dgvActivos.Rows.Add("Saldos al 1ero. de enero de", "4D0101")
        dgvActivos.Rows.Add("Cambios en Políticas Contables", "4D0126")
        dgvActivos.Rows.Add("Corrección de Errores", "4D0127")
        dgvActivos.Rows.Add("Saldo Inicial Reexpresado", "4D0128")
        dgvActivos.Rows.Add("Cambios en Patrimonio:")
        dgvActivos.Rows.Add("Resultado(Integral)")
        dgvActivos.Rows.Add("Ganancia (Pérdida) Neta del Ejercicio", "4D0129")
        dgvActivos.Rows.Add("Otro Resultado Integral", "4D0130")
        dgvActivos.Rows.Add("Resultado Integral Total del Ejercicio", "4D0131")
        dgvActivos.Rows.Add("Dividendos en Efectivo Declarados", "4D0104")
        dgvActivos.Rows.Add("Emisión (reducción) de patrimonio", "4D0105")
        dgvActivos.Rows.Add("Reducción o Amortización de Acciones de Inversión", "4D0132")
        dgvActivos.Rows.Add("Incremento (Disminución) por otras Aportaciones de los Propietarios", "4D0133")
        dgvActivos.Rows.Add("Disminución (Incremento) por otras Distribuciones a los Propietarios", "4D0134")
        dgvActivos.Rows.Add("Incremento (Disminución) por Cambios en la Participación de Subsidiarias que no impliquen Pérdidas de Control", "4D0135")
        dgvActivos.Rows.Add("Incremento (disminución) por transacciones con acciones propias en cartera", "4D0114")
        dgvActivos.Rows.Add("Incremento (Disminución) por Transferencia y Otros Cambios de patrimonio", "4D0112")
        dgvActivos.Rows.Add("Total incremento (disminución) en el patrimonio", "4D0136")
        dgvActivos.Rows.Add("Saldos al 31 de diciembre de", "4D01ST")
        dgvActivos.Rows.Add("Saldos al 1ero. de enero de", "4D0201")
        dgvActivos.Rows.Add("Cambios en Políticas Contables", "4D0226")
        dgvActivos.Rows.Add("Corrección de Errores", "4D0227")
        dgvActivos.Rows.Add("Saldo Inicial Reexpresado", "4D0228")
        dgvActivos.Rows.Add("Cambios en Patrimonio:	")
        dgvActivos.Rows.Add("Resultado(Integral)")
        dgvActivos.Rows.Add("Ganancia (Pérdida) Neta del Ejercicio", "4D0229")
        dgvActivos.Rows.Add("Otro Resultado Integral", "4D0230")
        dgvActivos.Rows.Add("Resultado Integral Total del Ejercicio", "4D0231")
        dgvActivos.Rows.Add("Dividendos en Efectivo Declarados", "4D0204")
        dgvActivos.Rows.Add("Emisión (reducción) de patrimonio", "4D0205")
        dgvActivos.Rows.Add("Reducción o Amortización de Acciones de Inversión", "4D0232")
        dgvActivos.Rows.Add("Incremento (Disminución) por otras Aportaciones de los Propietarios", "4D0233")
        dgvActivos.Rows.Add("Disminución (Incremento) por otras Distribuciones a los Propietarios", "4D0234")
        dgvActivos.Rows.Add("Incremento (Disminución) por Cambios en la Participación de Subsidiarias que no impliquen Pérdidas de Control", "4D0235")
        dgvActivos.Rows.Add("Incremento (disminución) por transacciones con acciones propias en cartera", "4D0214")
        dgvActivos.Rows.Add("Incremento (Disminución) por Transferencia y Otros Cambios de patrimonio", "4D0212")
        dgvActivos.Rows.Add("Total incremento (disminución) en el patrimonio", "4D0236")
        dgvActivos.Rows.Add("Saldos al 31 de diciembre de", "4D02ST")
        ActivarCeldas()
    End Sub
    Private Sub ActivarCeldas()
        dgvActivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvActivos.DefaultCellStyle.SelectionBackColor = Color.White
        dgvActivos.DefaultCellStyle.SelectionForeColor = Color.Blue
        Dim filas As Integer = dgvActivos.RowCount
        Dim i As Integer = 0
        While i < filas
            If dgvActivos.Item(0, i).Value <> "" And dgvActivos.Item(1, i).Value = "" Then
                dgvActivos.Rows(i).ReadOnly = True
                dgvActivos.Rows(i).DefaultCellStyle.BackColor = Color.Aquamarine
                dgvActivos.Rows(i).DefaultCellStyle.Font = New Font(Font.FontFamily, 10, FontStyle.Bold)
            End If
            i += 1
        End While
    End Sub
    Private Sub PintarGrilla()
        Dim FilasDatos As Integer = dgvDatos.RowCount
        Dim FilasActivos As Integer = dgvActivos.RowCount
        Dim i, z As Integer
        i = 0 : z = 0
        While (i < FilasDatos)
            z = 0
            While (z < FilasActivos)
                If (dgvDatos.Item(2, i).Value = dgvActivos.Item(1, z).Value) Then
                    dgvActivos.Item(2, z).Value = dgvDatos.Item(3, i).Value
                    dgvActivos.Item(3, z).Value = dgvDatos.Item(4, i).Value
                    dgvActivos.Item(4, z).Value = dgvDatos.Item(5, i).Value
                    dgvActivos.Item(5, z).Value = dgvDatos.Item(6, i).Value
                    dgvActivos.Item(6, z).Value = dgvDatos.Item(7, i).Value
                    dgvActivos.Item(7, z).Value = dgvDatos.Item(8, i).Value
                    dgvActivos.Item(8, z).Value = dgvDatos.Item(9, i).Value
                    dgvActivos.Item(9, z).Value = dgvDatos.Item(10, i).Value
                    dgvActivos.Item(10, z).Value = dgvDatos.Item(11, i).Value
                    dgvActivos.Item(11, z).Value = dgvDatos.Item(12, i).Value
                    dgvActivos.Item(12, z).Value = dgvDatos.Item(13, i).Value
                    dgvActivos.Item(13, z).Value = dgvDatos.Item(14, i).Value
                    dgvActivos.Rows(z).ReadOnly = True
                    Exit While
                End If
                z += 1
            End While
            i += 1
        End While
    End Sub
    Private Sub LimpiarGrilla()
        Dim FilasActivos As Integer = dgvActivos.RowCount
        Dim i As Integer = 0
        While (i < FilasActivos)
            If (String.IsNullOrEmpty(dgvActivos.Item(1, i).Value) And String.IsNullOrEmpty(dgvActivos.Item(2, i).Value)) Then
                dgvActivos.Item(3, i).ReadOnly = True
                dgvActivos.Item(4, i).ReadOnly = True
            Else
                dgvActivos.Item(3, i).Value = ""
                dgvActivos.Item(4, i).Value = ""
                dgvActivos.Item(3, i).ReadOnly = False
                dgvActivos.Item(4, i).ReadOnly = False
            End If
            i += 1
        End While
    End Sub
#End Region
#Region "Funciones"
    Private Function Validar() As Boolean
        'If cboCatalogo.SelectedIndex = -1 Then
        '    MessageBox.Show("Debe seleccionar un dato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    cboCatalogo.Focus()
        '    Return False
        'End If
        'If txtRubroEstadoFinanciero.Text.Trim = "" Then
        '    MessageBox.Show("El codigo de rubro financiero es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtRubroEstadoFinanciero.Focus()
        '    Return False
        'End If
        'If txtCapital.Text.Trim = "" Then
        '    MessageBox.Show("Capital es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtCapital.Focus()
        '    Return False
        'End If
        'If txtAccionesInversion.Text.Trim = "" Then
        '    MessageBox.Show("Acciones de Inversion es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtAccionesInversion.Focus()
        '    Return False
        'End If
        'If txtCapitalAdicional.Text.Trim = "" Then
        '    MessageBox.Show("Capital Adicional es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtCapitalAdicional.Focus()
        '    Return False
        'End If
        'If txtResultadoNoRealizado.Text.Trim = "" Then
        '    MessageBox.Show("Resultado No Realizado es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtResultadoNoRealizado.Focus()
        '    Return False
        'End If
        'If txtReservasLegales.Text.Trim = "" Then
        '    MessageBox.Show("Reservas Legales es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtReservasLegales.Focus()
        '    Return False
        'End If
        'If txtOtrasReservas.Text.Trim = "" Then
        '    MessageBox.Show("Otras Reservas es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtOtrasReservas.Focus()
        '    Return False
        'End If
        'If txtResultadoAcumulados.Text.Trim = "" Then
        '    MessageBox.Show("Resultado Acumulado es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtResultadoAcumulados.Focus()
        '    Return False
        'End If
        'If txtDiferenciasConversion.Text.Trim = "" Then
        '    MessageBox.Show("Diferencia de Conversión es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtDiferenciasConversion.Focus()
        '    Return False
        'End If
        'If txtAjustesAlPatrimonio.Text.Trim = "" Then
        '    MessageBox.Show("Ajustes al Patrimonio es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtAjustesAlPatrimonio.Focus()
        '    Return False
        'End If
        'If txtResultadoNetoEjercicio.Text.Trim = "" Then
        '    MessageBox.Show("Resultado Neto Ejercicio obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtResultadoNetoEjercicio.Focus()
        '    Return False
        'End If
        'If txtExcedenteRevaluacion.Text.Trim = "" Then
        '    MessageBox.Show("Excedente Revaluacion es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtExcedenteRevaluacion.Focus()
        '    Return False
        'End If
        'If txtResultadoEjercicio.Text.Trim = "" Then
        '    MessageBox.Show("Resultado Ejercicio es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtResultadoEjercicio.Focus()
        '    Return False
        'End If
        'If (txtEstadoOperacion.Text.Trim = "1" Or txtEstadoOperacion.Text.Trim = "8" Or txtEstadoOperacion.Text.Trim = "9") = False Then
        '    MessageBox.Show("El estado de operación solo puede ser 1, 8 ,9 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtEstadoOperacion.Focus()
        '    Return False
        'End If
        Dim Filas As Integer = dgvActivos.RowCount
        Dim i As Integer = 0
        While (i < Filas)
            If (IsNumeric(dgvActivos.Item(2, i).Value) OrElse IsNumeric(dgvActivos.Item(3, i).Value) OrElse IsNumeric(dgvActivos.Item(4, i).Value) OrElse IsNumeric(dgvActivos.Item(5, i).Value) OrElse IsNumeric(dgvActivos.Item(6, i).Value) OrElse IsNumeric(dgvActivos.Item(7, i).Value) OrElse IsNumeric(dgvActivos.Item(8, i).Value) OrElse IsNumeric(dgvActivos.Item(9, i).Value) OrElse IsNumeric(dgvActivos.Item(10, i).Value) OrElse IsNumeric(dgvActivos.Item(11, i).Value) OrElse IsNumeric(dgvActivos.Item(12, i).Value) OrElse IsNumeric(dgvActivos.Item(13, i).Value)) Then 'AndAlso dgvActivos.Item(3, i).Value > 0
                'La estructura Descripcion|Código|Capital|Acciones de Inversion|Capital Adicional|Resultados no Realizados|Reservas Legales|Otras Reservas|Resultados Acumulados|Diferencias de Conversión|Ajustes al Patrimonio|Resultado Neto del Ejercicio|Excedente de la Revaluación|Resultado del Ejercicio
                Registros.Add(New String() {dgvActivos.Item(0, i).Value, dgvActivos.Item(1, i).Value, IIf(IsNumeric(dgvActivos.Item(2, i).Value), dgvActivos.Item(2, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(3, i).Value), dgvActivos.Item(3, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(4, i).Value), dgvActivos.Item(4, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(5, i).Value), dgvActivos.Item(5, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(6, i).Value), dgvActivos.Item(6, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(7, i).Value), dgvActivos.Item(7, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(8, i).Value), dgvActivos.Item(8, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(9, i).Value), dgvActivos.Item(9, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(10, i).Value), dgvActivos.Item(10, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(11, i).Value), dgvActivos.Item(11, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(12, i).Value), dgvActivos.Item(12, i).Value, 0), IIf(IsNumeric(dgvActivos.Item(13, i).Value), dgvActivos.Item(13, i).Value, 0)})
            End If
            i += 1
        End While
        Return True
    End Function
    Private Function ValidarRegistros(ByVal CodRubro As String, ByVal tr As SqlTransaction) As String
        Dim resul As String = String.Empty
        Try
            Using cmd As New SqlCommand("VALIDAR_03_19", con, tr)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
                cmd.Parameters.Add("@COD_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo ' "01"
                cmd.Parameters.Add("@COD_RUBRO", SqlDbType.VarChar).Value = CodRubro
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
                resul = cmd.ExecuteScalar
                If String.IsNullOrEmpty(resul) Or resul = Nothing Then
                    resul = ""
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        Return resul
    End Function
#End Region
#Region "Eventos"
    Private Sub frm0319_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frm039_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        CargarComboTabla22()
        dgvDatos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        LlenarGrilla()
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
            dgvActivos.Focus()
        Else
            If TabControl1.SelectedTab IsNot tpRegistros Then
                tpRegistros.Parent = TabControl1
                TabControl1.SelectedTab = tpRegistros
                MessageBox.Show("Debe elegir el mes y año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnGuardar.Text = "Guardar"
            End If
        End If
    End Sub
    Private Sub txtCapital_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapital.LostFocus
        If txtCapital.Text.Trim = "" Then
            txtCapital.Text = obj.HACER_DECIMAL(0)
        Else
            txtCapital.Text = obj.HACER_DECIMAL(CDbl(txtCapital.Text))
        End If
    End Sub
    Private Sub txtAccionesInversion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccionesInversion.LostFocus
        If txtAccionesInversion.Text.Trim = "" Then
            txtAccionesInversion.Text = obj.HACER_DECIMAL(0)
        Else
            txtAccionesInversion.Text = obj.HACER_DECIMAL(CDbl(txtAccionesInversion.Text))
        End If
    End Sub
    Private Sub txtCapitalAdicional_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapitalAdicional.LostFocus
        If txtCapitalAdicional.Text.Trim = "" Then
            txtCapitalAdicional.Text = obj.HACER_DECIMAL(0)
        Else
            txtCapitalAdicional.Text = obj.HACER_DECIMAL(CDbl(txtCapitalAdicional.Text))
        End If
    End Sub
    Private Sub txtResultadoNoRealizado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResultadoNoRealizado.LostFocus
        If txtResultadoNoRealizado.Text.Trim = "" Then
            txtResultadoNoRealizado.Text = obj.HACER_DECIMAL(0)
        Else
            txtResultadoNoRealizado.Text = obj.HACER_DECIMAL(CDbl(txtResultadoNoRealizado.Text))
        End If
    End Sub
    Private Sub txtReservasLegales_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReservasLegales.LostFocus
        If txtReservasLegales.Text.Trim = "" Then
            txtReservasLegales.Text = obj.HACER_DECIMAL(0)
        Else
            txtReservasLegales.Text = obj.HACER_DECIMAL(CDbl(txtReservasLegales.Text))
        End If
    End Sub
    Private Sub txtOtrasReservas_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOtrasReservas.LostFocus
        If txtOtrasReservas.Text.Trim = "" Then
            txtOtrasReservas.Text = obj.HACER_DECIMAL(0)
        Else
            txtOtrasReservas.Text = obj.HACER_DECIMAL(CDbl(txtOtrasReservas.Text))
        End If
    End Sub
    Private Sub txtResultadoAcumulados_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResultadoAcumulados.LostFocus
        If txtResultadoAcumulados.Text.Trim = "" Then
            txtResultadoAcumulados.Text = obj.HACER_DECIMAL(0)
        Else
            txtResultadoAcumulados.Text = obj.HACER_DECIMAL(CDbl(txtResultadoAcumulados.Text))
        End If
    End Sub
    Private Sub txtDiferenciasConversion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiferenciasConversion.LostFocus
        If txtDiferenciasConversion.Text.Trim = "" Then
            txtDiferenciasConversion.Text = obj.HACER_DECIMAL(0)
        Else
            txtDiferenciasConversion.Text = obj.HACER_DECIMAL(CDbl(txtDiferenciasConversion.Text))
        End If
    End Sub
    Private Sub txtAjustesAlPatrimonio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAjustesAlPatrimonio.LostFocus
        If txtAjustesAlPatrimonio.Text.Trim = "" Then
            txtAjustesAlPatrimonio.Text = obj.HACER_DECIMAL(0)
        Else
            txtAjustesAlPatrimonio.Text = obj.HACER_DECIMAL(CDbl(txtAjustesAlPatrimonio.Text))
        End If
    End Sub
    Private Sub txtResultadoNetoEjercicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResultadoNetoEjercicio.LostFocus
        If txtResultadoNetoEjercicio.Text.Trim = "" Then
            txtResultadoNetoEjercicio.Text = obj.HACER_DECIMAL(0)
        Else
            txtResultadoNetoEjercicio.Text = obj.HACER_DECIMAL(CDbl(txtResultadoNetoEjercicio.Text))
        End If
    End Sub
    Private Sub txtExcedenteRevaluacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExcedenteRevaluacion.LostFocus
        If txtExcedenteRevaluacion.Text.Trim = "" Then
            txtExcedenteRevaluacion.Text = obj.HACER_DECIMAL(0)
        Else
            txtExcedenteRevaluacion.Text = obj.HACER_DECIMAL(CDbl(txtExcedenteRevaluacion.Text))
        End If
    End Sub
    Private Sub txtResultadoEjercicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResultadoEjercicio.LostFocus
        If txtResultadoEjercicio.Text.Trim = "" Then
            txtResultadoEjercicio.Text = obj.HACER_DECIMAL(0)
        Else
            txtResultadoEjercicio.Text = obj.HACER_DECIMAL(CDbl(txtResultadoEjercicio.Text))
        End If
    End Sub
    Private Sub dgvActivos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvActivos.CellEndEdit
        If e.ColumnIndex.ToString = 2 Then
            If dgvActivos.Item(2, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(2, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(2, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(2, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(2, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 3 Then
            If dgvActivos.Item(3, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(3, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(3, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(3, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(3, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 4 Then
            If dgvActivos.Item(4, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(4, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(4, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(4, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(4, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 5 Then
            If dgvActivos.Item(5, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(5, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(5, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(5, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(5, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 6 Then
            If dgvActivos.Item(6, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(6, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(6, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(6, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(6, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 7 Then
            If dgvActivos.Item(7, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(7, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(7, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(7, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(7, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 8 Then
            If dgvActivos.Item(8, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(8, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(8, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(8, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(8, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 9 Then
            If dgvActivos.Item(9, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(9, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(9, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(9, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(9, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 10 Then
            If dgvActivos.Item(10, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(10, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(10, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(10, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(10, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 11 Then
            If dgvActivos.Item(11, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(11, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(11, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(11, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(11, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 12 Then
            If dgvActivos.Item(12, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(12, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(12, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(12, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(12, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
        If e.ColumnIndex.ToString = 13 Then
            If dgvActivos.Item(13, dgvActivos.CurrentRow.Index).Value <> String.Empty AndAlso IsNumeric(dgvActivos.Item(13, dgvActivos.CurrentRow.Index).Value) Then
                dgvActivos.Item(13, dgvActivos.CurrentRow.Index).Value = obj.HACER_DECIMAL(dgvActivos.Item(13, dgvActivos.CurrentRow.Index).Value)
            Else
                dgvActivos.Item(13, dgvActivos.CurrentRow.Index).Value = Nothing
            End If
        End If
    End Sub
#End Region

End Class