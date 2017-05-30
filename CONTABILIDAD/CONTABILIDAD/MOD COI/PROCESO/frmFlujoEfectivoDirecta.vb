Public Class frmFlujoEfectivoDirecta

#Region "Constructor"
    Private Shared _instancia As frmFlujoEfectivoDirecta
    Public Shared Function ObtenerIntancia() As frmFlujoEfectivoDirecta
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New frmFlujoEfectivoDirecta()
        End If
        Return _instancia
    End Function

    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().       
    End Sub

    Private Sub frmFlujoEfectivoGeneracionDirecta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAuxiliar()
    End Sub

#End Region

#Region "Variables"
    Private codigoAuxiliar, mesGenerar, mesActualizar As String
    Private ImporteTotal, ImporteComp As Decimal
    Private EnModificacion As Boolean
    Private Lista As New List(Of DataRow)
    Private REP As New REP_FLUJO_EFECTIVO
    Private obj As New Class1
#End Region

#Region "Procedimientos"
    Private Sub AgregarNodos(ByVal dr As DataRow, ByVal nodo As TreeGridNode, ByVal importeAcumulado As Boolean)
        nodo.Expand()
        Dim nodoHijo As TreeGridNode
        For Each row As DataRow In Lista
            If row(3) = dr(0) Then
                'nodoHijo = nodo.Nodes.Add(row(0), row(1), "", "", "", "")
                If nodo.Level = 2 Then
                    Dim Importe As Decimal = 0
                    Importe = ObtenerTotalConcepto(row(0), importeAcumulado)
                    nodoHijo = nodo.Nodes.Add(row(0), row(1), row(2), Importe)
                Else
                    nodoHijo = nodo.Nodes.Add(row(0), row(1), row(2), "")
                    Dim boldFont As New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Bold)
                    nodoHijo.DefaultCellStyle.Font = boldFont
                End If
                AgregarNodos(row, nodoHijo, importeAcumulado)
            End If
        Next
    End Sub

    Private Sub ExpandirNodo(ByVal nodo As TreeGridNode)
        nodo.Expand()
        For Each node As TreeGridNode In nodo.Nodes
            ExpandirNodo(node)
        Next
    End Sub

    Private Sub ContraerNodo(ByVal nodo As TreeGridNode)
        For Each node As TreeGridNode In nodo.Nodes
            ContraerNodo(node)
        Next
        nodo.Collapse()
    End Sub

    Private Sub CargarAuxiliar()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar.DataSource = DT
        cbo_auxiliar.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar.SelectedIndex = -1
    End Sub

    Private Sub CargarComprobante(ByVal auxiliar As String, ByVal mesProceso As String)
        tgvComprobantes.Nodes.Clear()
        Try
            con.Open()
            Using cmd As New SqlCommand("MOSTRAR_CONSULTA_I_CON", con)
                cmd.CommandType = (CommandType.StoredProcedure)
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesProceso
                cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = auxiliar
                Using reader As SqlDataReader = cmd.ExecuteReader
                    If Not reader Is Nothing AndAlso reader.HasRows Then
                        While reader.Read
                            tgvComprobantes.Nodes.Add(reader(0), reader(1), reader(2), reader(3), reader(4), reader(5), reader(6), False)
                        End While
                    End If
                End Using
            End Using
            For Each nodo As TreeGridNode In tgvComprobantes.Nodes
                Using cmd As New SqlCommand("MOSTRAR_CONSULTA_T_CON", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesProceso
                    cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = auxiliar
                    cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = tgvComprobantes.Item(1, nodo.RowIndex).Value
                    cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = tgvComprobantes.Item(2, nodo.RowIndex).Value
                    Using reader As SqlDataReader = cmd.ExecuteReader
                        If Not reader Is Nothing AndAlso reader.HasRows Then
                            While reader.Read
                                nodo.Nodes.Add("", "", "", "", reader(0), "", reader(1), False, reader(2), reader(3), reader(4), _
                                    reader(5), reader(6), reader(7), reader(8), reader(9), reader(10), reader(11), reader(12), _
                                    reader(13), reader(14), reader(15))
                                tgvComprobantes.Item(8, nodo.RowIndex).Value += reader(2)
                                tgvComprobantes.Item(9, nodo.RowIndex).Value += reader(3)
                                tgvComprobantes.Item(10, nodo.RowIndex).Value += reader(4)
                                tgvComprobantes.Item(11, nodo.RowIndex).Value += reader(5)
                            End While
                        End If
                    End Using
                End Using
            Next

        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CargarFlujoEfectivo(ByVal strMesProceso As String)
        tgvFlujoEfectivo.Nodes.Clear()
        Try
            con.Open()
            Using cmd As New SqlCommand("MOSTRAR_T_FLUJO_EFECTIVO", con)
                cmd.CommandType = (CommandType.StoredProcedure)
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = strMesProceso
                Using reader As SqlDataReader = cmd.ExecuteReader
                    If Not reader Is Nothing AndAlso reader.HasRows Then
                        Dim Codigo As String = ""
                        Dim nodoPadre As New TreeGridNode
                        Dim boldFont As New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Bold)
                        While reader.Read
                            If Codigo <> reader(0) Then
                                Codigo = reader(0)
                                nodoPadre = tgvFlujoEfectivo.Nodes.Add(Codigo, reader(1), False, "", "", "", "", "", _
                                    "", "", "", "", "", "", False, "")
                                nodoPadre.DefaultCellStyle.Font = boldFont
                                nodoPadre.Nodes.Add(reader(2), reader(3), False, reader(4), reader(5), reader(6), reader(7), _
                                     reader(8), reader(9), reader(10), reader(11), reader(12), reader(13), "", False, reader(14))
                                nodoPadre.Expand()
                            Else
                                nodoPadre.Nodes.Add(reader(2), reader(3), False, reader(4), reader(5), reader(6), reader(7), _
                                     reader(8), reader(9), reader(10), reader(11), reader(12), reader(13), "", False, reader(14))
                            End If

                        End While
                    End If
                End Using
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CargarFlujoEfectivoReporte()
        tgvFlujoEfectivoMensual.Nodes.Clear()
        tgvFlujoEfectivoAcumulado.Nodes.Clear()
        Lista.Clear()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_CONCEPTOS_FLUJO_EFECTIVO_REPORTE", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@ST_FLUJO", SqlDbType.Char).Value = "1"
            cmd.CommandTimeout = 720
            con.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    Dim dt As New DataTable
                    dt.Load(reader)
                    For Each row As DataRow In dt.Rows
                        Lista.Add(row)
                    Next
                End If
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tgvFlujoEfectivoMensual.Nodes.Clear()
            con.Close()
        End Try
        Dim nodo As TreeGridNode
        For Each row As DataRow In Lista
            If row(3) = "0" Then
                Dim boldFont As New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Bold)
                nodo = tgvFlujoEfectivoMensual.Nodes.Add(row(0), row(1), row(2), "")
                nodo.DefaultCellStyle.Font = boldFont
                AgregarNodos(row, nodo, False)

                nodo = tgvFlujoEfectivoAcumulado.Nodes.Add(row(0), row(1), row(2), "")
                nodo.DefaultCellStyle.Font = boldFont
                AgregarNodos(row, nodo, True)
            End If
        Next

        'For Each node As TreeGridNode In tgvFlujoEfectivoReporte.Nodes
        '    'ConfigurarFlujoReporte(node)
        'Next
    End Sub

    'Private Sub ConfigurarFlujoReporte(ByVal nodo As TreeGridNode)
    '    nodo.Expand()
    '    Dim boldFont As New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Bold)
    '    With tgvFlujoEfectivoReporte
    '        If nodo.Level = 1 Then
    '            nodo.DefaultCellStyle.Font = boldFont
    '            .Item(4, nodo.RowIndex).Value = .Item(0, nodo.RowIndex).Value
    '            .Item(5, nodo.RowIndex).Value = 0
    '        ElseIf nodo.Level = 2 Then
    '            nodo.DefaultCellStyle.Font = boldFont
    '            .Item(4, nodo.RowIndex).Value = .Item(0, nodo.Parent.RowIndex).Value
    '            .Item(5, nodo.RowIndex).Value = .Item(0, nodo.RowIndex).Value
    '        ElseIf nodo.Level = 3 Then
    '            Dim Importe As Decimal = 0
    '            Importe = ObtenerTotalConcepto(.Item(0, nodo.RowIndex).Value)
    '            .Item(3, nodo.RowIndex).Value = Importe
    '            .Item(4, nodo.RowIndex).Value = .Item(0, nodo.Parent.Parent.RowIndex).Value
    '            .Item(5, nodo.RowIndex).Value = .Item(0, nodo.Parent.RowIndex).Value
    '        End If
    '        For Each node As TreeGridNode In nodo.Nodes
    '            ConfigurarFlujoReporte(node)
    '        Next
    '    End With


    'End Sub

    Private Sub LlenarDataSet(ByVal nodo As TreeGridNode, ByVal dgv As DataGridView)
        Try
            If nodo.Level = 3 Then
                With dgv
                    REP.llenar_dt(.Item(0, nodo.RowIndex).Value, .Item(1, nodo.RowIndex).Value, .Item(3, nodo.RowIndex).Value, _
                        .Item(0, nodo.Parent.Parent.RowIndex).Value, .Item(1, nodo.Parent.Parent.RowIndex).Value, _
                        .Item(0, nodo.Parent.RowIndex).Value, .Item(1, nodo.Parent.RowIndex).Value)
                End With
            End If
            For Each node As TreeGridNode In nodo.Nodes
                LlenarDataSet(node, dgv)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Funciones"
    Private Function ObtenerItem(ByVal strAuxiliar As String, ByVal strComprobante As String, ByVal strNroComprobante As String) As String
        Dim item As String = "0000"
        Try
            con.Open()
            Using cmd As New SqlCommand("ITEM_FLUJO_EFECTIVO_COMPROBANTE", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesActualizar
                cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = strAuxiliar
                cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = strComprobante
                cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = strNroComprobante
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    reader.Read()
                    item = reader(0)
                End If
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return item
    End Function

    Private Function ObtenerTotalConcepto(ByVal strCodigoConcepto As String, ByVal importeAcumulado As Boolean) As Decimal
        Dim total As Decimal = 0
        Try
            con.Open()
            Using cmd As New SqlCommand("OBTENER_TOTAL_CONCEPTO_FLUJO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@COD_CONCEPTO_FLUJO", SqlDbType.Char).Value = strCodigoConcepto
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesActualizar
                cmd.Parameters.Add("@ST_ACUMULADO", SqlDbType.Char).Value = IIf(importeAcumulado, "1", "0")
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    reader.Read()
                    total = reader(0)
                End If
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return total

    End Function

    Private Function ObtenerSaldoInicial() As Decimal
        Dim total As Decimal = 0
        Try
            con.Open()
            Using cmd As New SqlCommand("OBTENER_SALDO_INICIAL_CONCEPTO_FLUJO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    reader.Read()
                    total = reader(0)
                End If
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return total

    End Function

    Private Function InsetarFlujoEfectivo(ByVal fila As Integer, ByVal filaPadre As Integer) As Boolean
        Dim Grabo As Boolean = False
        Try
            con.Open()
            Using cmd As New SqlCommand("INSERTAR_T_FLUJO_EFECTIVO", con)
                cmd.CommandType = CommandType.StoredProcedure
                With tgvFlujoEfectivo
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesActualizar
                    cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = .Item(10, fila).Value
                    cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = .Item(11, fila).Value
                    cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = .Item(12, fila).Value
                    cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = .Item(15, fila).Value
                    cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = .Item(4, fila).Value
                    cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = .Item(5, fila).Value
                    cmd.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = .Item(6, fila).Value
                    cmd.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = .Item(7, fila).Value
                    cmd.Parameters.Add("@GLOSA", SqlDbType.VarChar).Value = .Item(1, fila).Value
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = .Item(0, fila).Value
                    cmd.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = .Item(3, fila).Value
                    cmd.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = .Item(8, fila).Value
                    cmd.Parameters.Add("@COD_CONCEPTO_FLUJO", SqlDbType.Char).Value = .Item(0, filaPadre).Value
                End With
                Grabo = cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            Grabo = False
        Finally
            con.Close()
        End Try
        Return Grabo
    End Function

    Private Function EliminarFlujoEfectivo(ByVal fila As Integer) As Boolean
        Dim Elimino As Boolean = False
        Try
            con.Open()
            Using cmd As New SqlCommand("ELIMINAR_T_FLUJO_EFECTIVO", con)
                cmd.CommandType = CommandType.StoredProcedure
                With tgvFlujoEfectivo
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesActualizar
                    cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = .Item(10, fila).Value
                    cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = .Item(11, fila).Value
                    cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = .Item(12, fila).Value
                    cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = .Item(15, fila).Value
                End With
                Elimino = cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            Elimino = False
        Finally
            con.Close()
        End Try
        Return Elimino
    End Function

    Private Function ActualizarFlujoEfectivo(ByVal fila As Integer, ByVal filaNuevoConcepto As Integer) As Boolean
        Dim Actualizo As Boolean = False
        Try
            con.Open()
            Using cmd As New SqlCommand("ACTUALIZAR_T_FLUJO_EFECTIVO", con)
                cmd.CommandType = CommandType.StoredProcedure
                With tgvFlujoEfectivo
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesActualizar
                    cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = .Item(10, fila).Value
                    cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = .Item(11, fila).Value
                    cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = .Item(12, fila).Value
                    cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = .Item(15, fila).Value
                    cmd.Parameters.Add("@COD_CONCEPTO_FLUJO", SqlDbType.VarChar).Value = .Item(0, filaNuevoConcepto).Value
                    cmd.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = .Item(3, fila).Value
                End With
                Actualizo = cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            Actualizo = False
        Finally
            con.Close()
        End Try
        Return Actualizo
    End Function

    Private Sub ActualizarFlujoEfectivoAcumulado(ByVal nodo As TreeGridNode)
        Dim Actualizo As Boolean = False
        Try
            For Each nodoHijo As TreeGridNode In nodo.Nodes
                If nodoHijo.Level = 3 Then
                    With tgvFlujoEfectivoMensual
                        Using cmd As New SqlCommand("INSERTAR_SALDO_FLUJO_EFECTIVO", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.Add("@COD_CPTO_FLUJO", SqlDbType.Char).Value = .Item(0, nodoHijo.RowIndex).Value
                            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesActualizar
                            cmd.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = .Item(3, nodoHijo.RowIndex).Value
                            cmd.ExecuteNonQuery()
                        End Using
                    End With
                End If
                ActualizarFlujoEfectivoAcumulado(nodoHijo)
            Next
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerarSaldoInicial() As Boolean
        Dim Generado As Boolean = False
        Try
            con.Open()
            Using cmd As New SqlCommand("SALDO_INICIAL_FLUJO_EFECTIVO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                cmd.Parameters.Add("@ST_FLUJO", SqlDbType.Char).Value = "1"
                Generado = cmd.ExecuteNonQuery() > 0
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            Generado = False
        Finally
            con.Close()
        End Try
        Return Generado
    End Function

#End Region

#Region "Menu Contextual"
    Private Sub ContraerTodo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraerTodoToolStripMenuItem.Click
        For Each node As TreeGridNode In tgvFlujoEfectivo.Nodes
            node.Collapse()
            'ContraerNodo(node)
        Next
    End Sub

    Private Sub DuplicarItem(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiar.Click
        Dim nodo As TreeGridNode = tgvFlujoEfectivo.CurrentNode
        If EnModificacion AndAlso Not tgvFlujoEfectivo.Item(16, nodo.RowIndex).Value Then
            Exit Sub
        End If
        Dim nodoPadre As TreeGridNode = nodo.Parent
        Dim nuevoNodo As New TreeGridNode
        Try
            With tgvFlujoEfectivo
                Dim idx As Integer = nodo.RowIndex
                Dim underFont As New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Underline)
                Dim item As String = ObtenerItem(.Item(10, idx).Value, .Item(11, idx).Value, .Item(12, idx).Value)
                If item = "0000" Then
                    MessageBox.Show("Error al generar el nuevo item. No se puede generar la nueva fila.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ImporteTotal = tgvFlujoEfectivo.Item(3, nodo.RowIndex).Value
                EnModificacion = True
                tgvFlujoEfectivo.Item(16, nodo.RowIndex).Value = True
                nuevoNodo = nodoPadre.Nodes.Add(.Item(0, idx).Value, .Item(1, idx).Value, .Item(2, idx).Value, _
                    .Item(3, idx).Value, .Item(4, idx).Value, .Item(5, idx).Value, .Item(6, idx).Value, .Item(7, idx).Value, _
                    .Item(8, idx).Value, .Item(9, idx).Value, .Item(10, idx).Value, .Item(11, idx).Value, .Item(12, idx).Value, _
                    .Item(13, idx).Value, True, item, True)
                nuevoNodo.DefaultCellStyle.Font = underFont
                nuevoNodo.DefaultCellStyle.ForeColor = Color.Green
                nodo.DefaultCellStyle.Font = underFont
                nodo.DefaultCellStyle.ForeColor = Color.Green
                tgvFlujoEfectivo.CurrentCell = tgvFlujoEfectivo.Rows(nuevoNodo.RowIndex).Cells.Item(0)
                Dim Grabo As Boolean = InsetarFlujoEfectivo(nuevoNodo.RowIndex, nodoPadre.RowIndex)
                If Not Grabo Then
                    nodoPadre.Nodes.Remove(nuevoNodo)
                    MessageBox.Show("No se pudo duplicar el registro.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                CargarFlujoEfectivoReporte()
            End With
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            nodoPadre.Nodes.Remove(nuevoNodo)
        End Try

    End Sub

    Private Sub EliminarItem(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        Dim nodo As TreeGridNode = tgvFlujoEfectivo.CurrentNode
        If EnModificacion AndAlso Not tgvFlujoEfectivo.Item(16, nodo.RowIndex).Value Then
            Exit Sub
        End If
        Dim nodoPadre As TreeGridNode = nodo.Parent
        With tgvFlujoEfectivo
            If MessageBox.Show(String.Format("¿Realmente dese quitar el item {0} - {1}?", .Item(0, nodo.RowIndex).Value, _
                .Item(1, nodo.RowIndex).Value), My.Application.Info.Title, MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim Elimino As Boolean = EliminarFlujoEfectivo(nodo.RowIndex)
                If Not Elimino Then
                    MessageBox.Show("No se pudo eliminar el regitro.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                nodoPadre.Nodes.Remove(nodo)

                Dim SaldoActualizado As Decimal
                For Each nodoHijo As TreeGridNode In nodoPadre.Nodes
                    If tgvFlujoEfectivo.Item(16, nodoHijo.RowIndex).Value Then
                        SaldoActualizado += tgvFlujoEfectivo.Item(3, nodoHijo.RowIndex).Value
                    End If
                Next

                If Decimal.Compare(ImporteTotal, SaldoActualizado) = 0 Then
                    For Each nodoHijo As TreeGridNode In nodoPadre.Nodes
                        If tgvFlujoEfectivo.Item(16, nodoHijo.RowIndex).Value Then
                            tgvFlujoEfectivo.Item(16, nodoHijo.RowIndex).Value = False
                            nodoHijo.DefaultCellStyle.Font = New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Regular)
                            nodoHijo.DefaultCellStyle.ForeColor = Color.Black
                        End If
                    Next
                    ImporteTotal = 0
                    EnModificacion = False
                End If

                CargarFlujoEfectivoReporte()
            End If
            'If .Item(14, nodo.RowIndex).Value Then
            '    If MessageBox.Show(String.Format("¿Realmente dese quitar el item {0} - {1}?", .Item(0, nodo.RowIndex).Value, _
            '    .Item(1, nodo.RowIndex).Value), My.Application.Info.Title, MessageBoxButtons.YesNo, _
            '    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        nodoPadre.Nodes.Remove(nodo)
            '    End If
            'Else
            '    If MessageBox.Show(String.Format("Si elimima el item {0} - {1} se eliminarán los item asociados al comprobante Aux: {2} Comp.: {3} Nro. Comp.: {4} ¿Desea continuar la operación?", _
            '    .Item(0, nodo.RowIndex).Value, .Item(1, nodo.RowIndex).Value, .Item(10, nodo.RowIndex).Value, _
            '    .Item(11, nodo.RowIndex).Value, .Item(12, nodo.RowIndex).Value), My.Application.Info.Title, MessageBoxButtons.YesNo, _
            '    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            '        nodoPadre.Nodes.Remove(nodo)
            '    End If
            'End If
        End With
    End Sub

    Private Sub ExpandirTodo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandirTodoToolStripMenuItem.Click
        For Each node As TreeGridNode In tgvFlujoEfectivo.Nodes
            ExpandirNodo(node)
        Next
    End Sub

    Private Sub MostrarMenu(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsGrid.Opening
        If tgvFlujoEfectivo.RowCount = 0 Then
            e.Cancel = True
        Else
            Dim nodo As TreeGridNode = tgvFlujoEfectivo.CurrentNode
            mnuCopiar.Enabled = nodo.Level > 1
            mnuMover.Enabled = (nodo.Level > 1 AndAlso Not EnModificacion)
            mnuEliminar.Enabled = nodo.Level > 1
        End If
    End Sub

    Private Sub MoverItem(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMover.Click
        Dim HijoActual As TreeGridNode = tgvFlujoEfectivo.CurrentNode
        Dim PadreAnterior As TreeGridNode = HijoActual.Parent
        Dim NuevoPadre As New TreeGridNode
        Dim NuevoHijo As New TreeGridNode
        Dim Actualizo As Boolean = False
        Try
            Dim Lista As New Dictionary(Of String, String)
            For Each nodo As TreeGridNode In tgvFlujoEfectivo.Nodes
                With tgvFlujoEfectivo
                    Lista.Add(.Item(0, nodo.RowIndex).Value, .Item(1, nodo.RowIndex).Value)
                End With
            Next
            Dim frm As New frmSeleccionarItem(Lista)
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each node As TreeGridNode In tgvFlujoEfectivo.Nodes
                    With tgvFlujoEfectivo
                        If .Item(0, node.RowIndex).Value = frm.tgvItem.Item(0, frm.tgvItem.CurrentNode.RowIndex).Value Then
                            NuevoPadre = node
                            NuevoPadre.Expand()
                            Dim idx As Integer = HijoActual.RowIndex
                            NuevoHijo = node.Nodes.Add(.Item(0, idx).Value, .Item(1, idx).Value, .Item(2, idx).Value, _
                            .Item(3, idx).Value, .Item(4, idx).Value, .Item(5, idx).Value, .Item(6, idx).Value, _
                            .Item(7, idx).Value, .Item(8, idx).Value, .Item(9, idx).Value, .Item(10, idx).Value, _
                            .Item(11, idx).Value, .Item(12, idx).Value, .Item(13, idx).Value, .Item(14, idx).Value, _
                            .Item(15, idx).Value, .Item(16, idx).Value)
                            NuevoHijo.DefaultCellStyle.Font = HijoActual.DefaultCellStyle.Font
                            NuevoHijo.DefaultCellStyle.ForeColor = HijoActual.DefaultCellStyle.ForeColor
                            tgvFlujoEfectivo.CurrentCell = tgvFlujoEfectivo.Rows(NuevoHijo.RowIndex).Cells.Item(0)
                            Actualizo = ActualizarFlujoEfectivo(NuevoHijo.RowIndex, NuevoPadre.RowIndex)
                            Exit For
                        End If
                    End With
                Next
                If Not Actualizo Then
                    NuevoPadre.Nodes.Remove(NuevoHijo)
                    MessageBox.Show("No se pudo mover el registro.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                PadreAnterior.Nodes.Remove(HijoActual)
                CargarFlujoEfectivoReporte()
            End If
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            NuevoPadre.Nodes.Remove(NuevoHijo)
        End Try

    End Sub
#End Region

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        If cbo_auxiliar.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el auxiliar", "Advertencia", _
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_auxiliar.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", _
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        chkTodos.Checked = False
        CargarComprobante(codigoAuxiliar, mesGenerar)
    End Sub

    Private Sub cbo_auxiliar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 AndAlso Not TypeOf cbo_auxiliar.SelectedValue Is DataRowView Then
            codigoAuxiliar = cbo_auxiliar.SelectedValue
        End If
    End Sub

    Private Sub SeleccionarMesGenerar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        If cbo_mes.SelectedIndex <> -1 Then
            mesGenerar = obj.COD_MES(cbo_mes.Text)
        End If
    End Sub

    Private Sub SeleccionarMesActualizar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMes1.SelectedIndexChanged
        If cboMes1.SelectedIndex <> -1 Then
            mesActualizar = obj.COD_MES(cboMes1.Text)
        End If
    End Sub

    Private Sub EditarGrid(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgvComprobantes.Click
        If tgvComprobantes.RowCount > 0 Then
            Dim nodoPadre As TreeGridNode = tgvComprobantes.CurrentNode
            If tgvComprobantes.CurrentCell.ColumnIndex = 7 AndAlso nodoPadre.Level = 1 Then
                tgvComprobantes.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub ActualizarCambiosEnGrid(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgvComprobantes.CurrentCellDirtyStateChanged
        If tgvComprobantes.IsCurrentCellDirty Then
            tgvComprobantes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
        For Each nodo As TreeGridNode In tgvComprobantes.Nodes
            'nodo.Expand()
            tgvComprobantes.Item(7, nodo.RowIndex).Value = chkTodos.Checked
        Next
    End Sub

    Private Sub Generar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim Generado As Boolean = False
        Using trx As New TransactionScope()
            Try
                con.Open()
                Dim debeHaber As String
                Dim importe As Decimal
                Dim item As Integer
                For Each nodoPadre As TreeGridNode In tgvComprobantes.Nodes
                    item = 0
                    If tgvComprobantes.Item(7, nodoPadre.RowIndex).Value Then
                        nodoPadre.Expand()
                        For Each nodoHijo As TreeGridNode In nodoPadre.Nodes
                            With tgvComprobantes
                                item += 1
                                If String.IsNullOrEmpty(.Item(20, nodoHijo.RowIndex).Value) Then
                                    .CurrentCell = .Rows.Item(nodoHijo.RowIndex).Cells.Item(0)
                                    Throw New Exception("El concepto no puede estar vacio.")
                                End If
                                Using cmd As New SqlCommand("INSERTAR_T_FLUJO_EFECTIVO", con)
                                    cmd.CommandType = CommandType.StoredProcedure
                                    debeHaber = .Item(18, nodoHijo.RowIndex).Value
                                    importe = .Item(IIf(debeHaber = "D", 8, 9), nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesGenerar
                                    cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = .Item(0, nodoPadre.RowIndex).Value
                                    cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = .Item(1, nodoPadre.RowIndex).Value
                                    cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = .Item(2, nodoPadre.RowIndex).Value
                                    cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = item.ToString("0000")
                                    cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = .Item(14, nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = .Item(15, nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = .Item(16, nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = .Item(17, nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@GLOSA", SqlDbType.VarChar).Value = .Item(6, nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = .Item(4, nodoHijo.RowIndex).Value
                                    cmd.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = importe
                                    cmd.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = debeHaber
                                    cmd.Parameters.Add("@COD_CONCEPTO_FLUJO", SqlDbType.Char).Value = .Item(20, nodoHijo.RowIndex).Value
                                    cmd.ExecuteNonQuery()
                                End Using
                            End With
                        Next
                        nodoPadre.Collapse()
                    End If
                Next
                Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Datos generados correctamente.", LogUsuario.TipoLog.Informacion)
                obj.SerializarLog(log)
                MessageBox.Show("Datos generados correctamente.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                trx.Complete()
                Generado = True
            Catch ex As Exception
                Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
                obj.SerializarLog(log)
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Generado = False
            Finally
                con.Close()
            End Try
        End Using
        If Generado Then
            CargarComprobante(codigoAuxiliar, mesGenerar)
        End If
    End Sub

    Private Sub tgvFlujoEfectivo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles tgvFlujoEfectivo.CellBeginEdit
        Try
            Dim nodo As TreeGridNode = tgvFlujoEfectivo.CurrentNode
            ImporteComp = tgvFlujoEfectivo.Item(3, nodo.RowIndex).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tgvFlujoEfectivo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles tgvFlujoEfectivo.CellEndEdit
        Dim nodo As TreeGridNode = tgvFlujoEfectivo.CurrentNode
        Try
            Dim NuevoImporte As Decimal = tgvFlujoEfectivo.Item(3, nodo.RowIndex).Value
            tgvFlujoEfectivo.Item(3, nodo.RowIndex).Value = obj.HACER_DECIMAL(NuevoImporte)
            If Decimal.Compare(ImporteComp, NuevoImporte) <> 0 Then

                Dim SaldoActualizado As Decimal
                For Each nodoHijo As TreeGridNode In nodo.Parent.Nodes
                    If tgvFlujoEfectivo.Item(16, nodoHijo.RowIndex).Value Then
                        SaldoActualizado += tgvFlujoEfectivo.Item(3, nodoHijo.RowIndex).Value
                    End If
                Next

                Dim Actualizo As Boolean = ActualizarFlujoEfectivo(nodo.RowIndex, nodo.Parent.RowIndex)
                If Not Actualizo Then
                    tgvFlujoEfectivo.Item(3, nodo.RowIndex).Value = ImporteComp
                    MessageBox.Show("No se puedo actualizar el registro", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If Decimal.Compare(ImporteTotal, SaldoActualizado) = 0 Then
                    For Each nodoHijo As TreeGridNode In nodo.Parent.Nodes
                        If tgvFlujoEfectivo.Item(16, nodoHijo.RowIndex).Value Then
                            tgvFlujoEfectivo.Item(16, nodoHijo.RowIndex).Value = False
                            nodoHijo.DefaultCellStyle.Font = New Font(tgvFlujoEfectivo.DefaultCellStyle.Font, FontStyle.Regular)
                            nodoHijo.DefaultCellStyle.ForeColor = Color.Black
                        End If
                    Next
                    ImporteTotal = 0
                    EnModificacion = False
                End If
                CargarFlujoEfectivoReporte()
            End If
        Catch ex As Exception
            MessageBox.Show("No se puedo actualizar el registro", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            tgvFlujoEfectivo.Item(3, nodo.RowIndex).Value = ImporteComp
        End Try
    End Sub

    Private Sub tgvFlujoEfectivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgvFlujoEfectivo.Click
        If tgvFlujoEfectivo.RowCount > 0 Then
            Dim nodo As TreeGridNode = tgvFlujoEfectivo.CurrentNode
            If nodo.Level > 1 AndAlso tgvFlujoEfectivo.CurrentCell.ColumnIndex = 3 AndAlso tgvFlujoEfectivo.Item(16, nodo.RowIndex).Value Then
                tgvFlujoEfectivo.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub tgvFlujoEfectivo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tgvFlujoEfectivo.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo = tgvFlujoEfectivo.HitTest(e.X, e.Y)
            If ht.RowIndex > -1 Then
                tgvFlujoEfectivo.CurrentCell = tgvFlujoEfectivo.Rows(ht.RowIndex).Cells.Item(0)
            End If
        End If
    End Sub

    Private Sub btnConsulta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta1.Click
        If cboMes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", _
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes1.Focus() : Exit Sub
        CargarFlujoEfectivo(mesActualizar)
        CargarFlujoEfectivoReporte()
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        REP.LIMPIAR()
        For Each nodo As TreeGridNode In tgvFlujoEfectivoMensual.Nodes
            LlenarDataSet(nodo, tgvFlujoEfectivoMensual)
        Next

        Dim UltimoDiaMes As String = obj.UltimoDiaDelMes(AÑO, Integer.Parse(mesActualizar))
        Dim SaldoInicial As Decimal = ObtenerSaldoInicial()
        REP.CREAR_REPORTE(AÑO, obj.DESC_MES(mesActualizar), UltimoDiaMes, SaldoInicial, "100")
        REP.ShowDialog()
    End Sub

    Private Sub GenerarSaldoInicial(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaldoInicial.Click
        If MessageBox.Show("Se va a actualizar el saldo inicial ¿Seguro de continuar?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim Generado As Boolean = GenerarSaldoInicial()
            If Generado Then
                MessageBox.Show("Saldo inicial generado.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No se pudo generar el saldo inicial.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub

    Private Sub ActualizarAcumulado(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarAcumulado.Click
        Try

            Using trx As New TransactionScope
                con.Open()
                For Each nodo As TreeGridNode In tgvFlujoEfectivoMensual.Nodes
                    ActualizarFlujoEfectivoAcumulado(nodo)
                Next
                Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Datos actualizados correctamente.", LogUsuario.TipoLog.Informacion)
                obj.SerializarLog(log)
                MessageBox.Show("Datos actualizados correctamente.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                trx.Complete()
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        CargarFlujoEfectivoReporte()
    End Sub

    Private Sub btnPantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla1.Click
        REP.LIMPIAR()
        For Each nodo As TreeGridNode In tgvFlujoEfectivoAcumulado.Nodes
            LlenarDataSet(nodo, tgvFlujoEfectivoAcumulado)
        Next

        Dim UltimoDiaMes As String = obj.UltimoDiaDelMes(AÑO, Integer.Parse(mesActualizar))
        Dim SaldoInicial As Decimal = ObtenerSaldoInicial()
        REP.CREAR_REPORTE(AÑO, obj.DESC_MES(mesActualizar), UltimoDiaMes, SaldoInicial, "100")
        REP.ShowDialog()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, btnSalir1.Click
        Close()
    End Sub
End Class