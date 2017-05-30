Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frm0324
#Region "Variables"
    Dim obj As New Class1
    Dim index As Integer
    Dim item As String
    Dim FechaInicio, FechaFin As DateTime
    Private LoPle0324 As New List(Of Ple_3_24)
    Dim ItemTabla As Integer
    Dim CodigoTipoAccion As String = String.Empty
    Dim CodigoCatalogo As String = String.Empty
    Dim Registros As New ArrayList
#End Region
#Region "Constructor"
    Private Shared instancia As New frm0324
    Public Shared Function ObtenerInstancia() As frm0324
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0324
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region
#Region "Estructura"

    Public Structure Ple_3_24
        Public Periodo As String
        Public Item As String
        Public CodigoCatalogo As String
        Public CodigoRubro As String
        Public SaldoRubro As Decimal
        Public EstadoOperacion As String
        Public NombreRubro As String
        Public Nota As String
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
        'Por si no presiona el boton y se tienen que ver los registros
        If dgvDatos.RowCount = 0 Then
            FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
            FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
            dgvDatos.Rows.Clear()
            ConsultarPle()
            If LoPle0324.Count > 0 Then
                Dim i As Integer
                For i = 0 To LoPle0324.Count - 1
                    With LoPle0324.Item(i)
                        dgvDatos.Rows.Add(.Periodo, _
                                          .CodigoCatalogo, _
                                          .CodigoRubro, _
                                          .SaldoRubro, _
                                          .EstadoOperacion, _
                                          .NombreRubro, _
                                          .Nota)
                    End With
                Next
            End If
        End If
        PintarGrilla()
        '--
        TabControl1.SelectedTab = tpDetalles
        'cboTipoDocumento.Focus()
        gbActivos.Visible = True
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
        btnGuardar.Text = "Guardar"
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
        'cboCatalogo.SelectedValue.Codigo = IIf(String.IsNullOrEmpty(dgvDatos.Item(2, index).Value), cboCatalogo.SelectedIndex = -1, dgvDatos.Item(2, index).Value)
        txtRubroEstadoFinanciero.Text = dgvDatos.Item(2, index).Value
        txtSaldoContable.Text = (dgvDatos.Item(3, index).Value)
        txtEstadoOperacion.Text = dgvDatos.Item(4, index).Value
        txtNombreRubro.Text = dgvDatos.Item(5, index).Value
        txtNota.Text = dgvDatos.Item(6, index).Value
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
        If LoPle0324.Count <= 0 Then
            MessageBox.Show("No hay registros que exportar")
            Exit Sub
        End If
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}032400011111.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    For i As Integer = 0 To LoPle0324.Count - 1
                        With LoPle0324(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|", _
                            .Periodo, _
                            .CodigoCatalogo, _
                            .CodigoRubro, _
                            .SaldoRubro, _
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
        If LoPle0324.Count > 0 Then
            Dim i As Integer
            For i = 0 To LoPle0324.Count - 1
                With LoPle0324.Item(i)
                    dgvDatos.Rows.Add(.Periodo, _
                                      .CodigoCatalogo, _
                                      .CodigoRubro, _
                                      .SaldoRubro, _
                                      .EstadoOperacion, _
                                      .NombreRubro, _
                                      .Nota)
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
        'txtPeriodo.Clear()
        'cboCatalogo.SelectedIndex = 0
        txtRubroEstadoFinanciero.Clear()
        txtSaldoContable.Clear()
        txtNombreRubro.Clear()
        txtNota.Clear()
        cboCatalogo.Focus()
        LimpiarGrilla()
    End Sub
    Private Sub ConsultarPle()
        LoPle0324.Clear()
        Using cmd As New SqlCommand("MOSTRAR_PLE_03_24", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = cbo_año.Text & obj.COD_MES(cbo_mes.Text) & FechaFin.Date.Day
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes.Text)
            con.Open()
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            Try
                If drd IsNot Nothing AndAlso drd.HasRows Then
                    Dim oPle As Ple_3_24
                    While drd.Read
                        oPle = New Ple_3_24
                        With oPle
                            .Periodo = drd(0)
                            '.Item = drd(1)
                            .CodigoCatalogo = drd(1)
                            .CodigoRubro = drd(2)
                            .SaldoRubro = drd(3)
                            .EstadoOperacion = drd(4)
                            .NombreRubro = drd(5)
                            .Nota = drd(6)
                        End With
                        LoPle0324.Add(oPle)
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
    '    'HallarItem()
    '    Using cmd As New SqlCommand("INSERTAR_PLE_03_24", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
    '        cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = (ItemTabla + 1).ToString("00")
    '        cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
    '        cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = txtRubroEstadoFinanciero.Text
    '        cmd.Parameters.Add("@SALDO_RUBRO", SqlDbType.Decimal).Value = txtSaldoContable.Text
    '        cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
    '        cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = txtNombreRubro.Text
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
            Using cmd As New SqlCommand("INSERTAR_PLE_03_24", con, tr)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
                cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
                cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = Registros.Item(z)(1).ToString 'txtRubroEstadoFinanciero.Text
                cmd.Parameters.Add("@SALDO_RUBRO", SqlDbType.Decimal).Value = CDec(Registros.Item(z)(2).ToString) 'txtSaldoContable.Text
                cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
                cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = Registros.Item(z)(0).ToString 'txtNombreRubro.Text
                cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = Registros.Item(z)(3).ToString 'txtNota.Text
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
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
        Using cmd As New SqlCommand("ACTUALIZAR_PLE_03_24", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = txtPeriodo.Text
            cmd.Parameters.Add("@CODIGO_CATALOGO", SqlDbType.Char).Value = CodigoCatalogo
            cmd.Parameters.Add("@CODIGO_RUBRO", SqlDbType.VarChar).Value = txtRubroEstadoFinanciero.Text
            cmd.Parameters.Add("@SALDO_RUBRO", SqlDbType.Decimal).Value = txtSaldoContable.Text
            'cmd.Parameters.Add("@ESTADO_OPERACION", SqlDbType.Char).Value = txtEstadoOperacion.Text
            'cmd.Parameters.Add("@NOMBRE_RUBRO", SqlDbType.VarChar).Value = txtNombreRubro.Text
            cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = txtNota.Text
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
        Using cmd As New SqlCommand("ELIMINAR_PLE_03_24", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@PERIODO", SqlDbType.Char).Value = Periodo
            cmd.Parameters.Add("@COD_CATALOGO", SqlDbType.Char).Value = CodCatalogo
            cmd.Parameters.Add("@COD_RUBRO", SqlDbType.Char).Value = CodRubro
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes.Text)
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
    '    Using cmd As New SqlCommand("RECUPERAR_ITEM_PLE_3_24", con)
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
    Private Sub LlenarGrilla()
        dgvActivos.Rows.Add("Ganancia (Pérdida)  Neta del Ejercicio", "5D0101")
        dgvActivos.Rows.Add("Componentes de Otro Resultado Integral:")
        dgvActivos.Rows.Add("Variación Neta por Coberturas del Flujo de Efectivo", "5D0103")
        dgvActivos.Rows.Add("Coberturas de inversión neta de negocios en el extranjero", "5D0109")
        dgvActivos.Rows.Add("Ganancias (Pérdidas) de Inversiones en Instrumentos de Patrimonio al valor razonable", "5D0104")
        dgvActivos.Rows.Add("Diferencia de Cambio  por Conversión de Operaciones en el Extranjero", "5D0105")
        dgvActivos.Rows.Add("Variación neta de activos no corrientes o grupos de activos mantenidos para la venta", "5D0110")
        dgvActivos.Rows.Add("Superávit de Revaluación", "5D0107")
        dgvActivos.Rows.Add("Ganancia (pérdida) actuariales en plan de beneficios definidos", "5D0111")
        dgvActivos.Rows.Add("Cambios en el valor razonable de pasivos financieros atribuibles a cambios en el riesgo de crédito del pasivo", "5D0112")
        dgvActivos.Rows.Add("Otro Resultado Integral antes de Impuestos", "5D01ST")
        dgvActivos.Rows.Add("Impuesto  a las Ganancias relacionado con Componentes de Otro Resultado Integral")
        dgvActivos.Rows.Add("Variación Neta por Coberturas del Flujo de Efectivo", "5D0202")
        dgvActivos.Rows.Add("Coberturas de inversión neta de negocios en el extranjero", "5D0208")
        dgvActivos.Rows.Add("Ganancias (Pérdidas) de Inversiones en Instrumentos de Patrimonio al valor razonable", "5D0203")
        dgvActivos.Rows.Add("Diferencia de Cambio  por Conversión de Operaciones en el Extranjero", "5D0204")
        dgvActivos.Rows.Add("Variación neta de activos no corrientes o grupos de activos mantenidos para la venta", "5D0209")
        dgvActivos.Rows.Add("Superávit de Revaluación", "5D0206")
        dgvActivos.Rows.Add("Ganancia (pérdida) actuariales en plan de beneficios definidos", "5D0210")
        dgvActivos.Rows.Add("Cambios en el valor razonable de pasivos financieros atribuibles a cambios en el riesgo de crédito del pasivo", "5D0211")
        dgvActivos.Rows.Add("Suma de Impuestos a las Ganancias Relacionados con Componentes de Otro Resultado Integral", "5D02ST")
        dgvActivos.Rows.Add("Otros Resultado Integral", "5D03ST")
        dgvActivos.Rows.Add("Resultado  Integral Total del Ejercicio, neto del Impuesto a las Ganancias", "5D04ST")
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
                    dgvActivos.Item(3, z).Value = dgvDatos.Item(6, i).Value
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
            If (IsNumeric(dgvActivos.Item(2, i).Value) Or (String.IsNullOrEmpty(dgvActivos.Item(1, i).Value) And String.IsNullOrEmpty(dgvActivos.Item(2, i).Value))) Then
                dgvActivos.Item(2, i).ReadOnly = True
                dgvActivos.Item(3, i).ReadOnly = True
            Else
                dgvActivos.Item(2, i).Value = ""
                dgvActivos.Item(3, i).Value = ""
                dgvActivos.Item(2, i).ReadOnly = False
                dgvActivos.Item(3, i).ReadOnly = False
            End If
            i += 1
        End While
    End Sub
#End Region
#Region "Funciones"
    Private Function Validar() As Boolean
        'If cboCatalogo.SelectedIndex = -1 Then
        '    MessageBox.Show("Debe selecionar el catalog", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    cboCatalogo.Focus()
        '    Return False
        'End If
        'If txtRubroEstadoFinanciero.Text.Trim = "" Then
        '    MessageBox.Show("Debe poner el codigo del rubro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    cboCatalogo.Focus()
        '    Return False
        'End If
        'If txtSaldoContable.Text.Trim = "" Then
        '    MessageBox.Show("El saldo es obligatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtSaldoContable.Focus()
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
            If (IsNumeric(dgvActivos.Item(2, i).Value)) Then 'AndAlso dgvActivos.Item(3, i).Value > 0
                'La estructura Descripcion|Código|Monto|Nota
                Registros.Add(New String() {dgvActivos.Item(0, i).Value, dgvActivos.Item(1, i).Value, IIf(IsNumeric(dgvActivos.Item(2, i).Value), dgvActivos.Item(2, i).Value, 0), IIf(IsNothing(dgvActivos.Item(3, i).Value), "", dgvActivos.Item(3, i).Value)})
            End If
            i += 1
        End While
        Return True
    End Function
    Private Function ValidarRegistros(ByVal CodRubro As String, ByVal tr As SqlTransaction) As String
        Dim resul As String = String.Empty
        Try
            Using cmd As New SqlCommand("VALIDAR_03_24", con, tr)
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
    Private Sub frm0324_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frm0324_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarGrilla()
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        CargarComboTabla22()
        dgvDatos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvActivos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub cboCatalogo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCatalogo.SelectedIndexChanged
        CodigoCatalogo = IIf(String.IsNullOrEmpty(cboCatalogo.SelectedValue.Codigo), "", cboCatalogo.SelectedValue.Codigo)
    End Sub
    Private Sub txtSaldoContable_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaldoContable.LostFocus
        If txtSaldoContable.Text.Trim = "" Then
            txtSaldoContable.Text = obj.HACER_DECIMAL(0)
        Else
            txtSaldoContable.Text = obj.HACER_DECIMAL(txtSaldoContable.Text)
        End If
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
                cboCatalogo.Focus()
            End If
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
    End Sub
#End Region
End Class