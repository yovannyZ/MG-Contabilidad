Imports System.Data
Imports System.Data.SqlClient
Public Class frmConceptoFujoEfectivo
#Region "Constructor"
    Private Shared _instancia As frmConceptoFujoEfectivo
    Public Shared Function ObtenerInstancia() As frmConceptoFujoEfectivo
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New frmConceptoFujoEfectivo
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub frmConceptoFujoEfectivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmConceptoFujoEfectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tpDetalle.Parent = Nothing
        DataGrid()
        CargarCuentas()
    End Sub
#End Region

#Region "Variables"
    Private EsNuevo As Boolean
    Private Lista As New List(Of DataRow)
    Private ListaCuentas As New List(Of String)
    Private obj As New Class1
#End Region

#Region "Funciones"

    Private Function Actualizar(ByVal codigo As String) As Boolean
        Dim Grabo As Boolean = False
        Try
            Using trx As New TransactionScope()
                Dim cmd As New SqlCommand("MODIFICAR_CONCEPTO_FLUJO_EFECTIVO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@DESC_CPTO", SqlDbType.VarChar).Value = txtDescripcion.Text
                cmd.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txtAbreviado.Text
                cmd.Parameters.Add("@ST_FLUJO", SqlDbType.Char).Value = IIf(chkFlujo.Checked, "1", "0")
                cmd.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = codigo
                con.Open()
                Grabo = (cmd.ExecuteNonQuery() > 0)

                If Grabo AndAlso tgvCuentas.Visible Then
                    InsertarDetalles()
                End If

                If Grabo Then
                    trx.Complete()
                    Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, "El nuevo concepto ha sido actualizado", LogUsuario.TipoLog.Informacion)
                    obj.SerializarLog(log)
                Else
                    MessageBox.Show("No se pudo modificar el concepto", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        Return Grabo
    End Function

    Private Function Eliminar(ByVal codigo As String) As Boolean
        Dim Grabo As Boolean = False
        Try
            Dim cmd As New SqlCommand("ELIMINAR_CONCEPTO_FLUJO_EFECTIVO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = codigo
            con.Open()
            Grabo = (cmd.ExecuteNonQuery() > 0)
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, "El concepto ha sido eliminado", LogUsuario.TipoLog.Informacion)
            obj.SerializarLog(log)
            con.Close()
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        Return Grabo
    End Function

    Private Function Insertar(ByVal codigo As String) As Boolean
        Dim Grabo As Boolean = False
        Try
            Using trx As New TransactionScope()
                Dim cmd As New SqlCommand("INSERTAR_CONCEPTO_FLUJO_EFECTIVO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = codigo
                cmd.Parameters.Add("@DESC_CPTO", SqlDbType.VarChar).Value = txtDescripcion.Text
                cmd.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txtAbreviado.Text
                cmd.Parameters.Add("@ST_FLUJO", SqlDbType.Char).Value = IIf(chkFlujo.Checked, "1", "0")
                cmd.Parameters.Add("@COD_CPTO_PADRE", SqlDbType.Char).Value = txtCodConceptoSuperior.Text
                cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = txtNivel.Text
                con.Open()
                Grabo = (cmd.ExecuteNonQuery() > 0)

                If Grabo AndAlso tgvCuentas.Visible Then
                    InsertarDetalles()
                End If

                If Grabo Then
                    trx.Complete()
                    Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, "El nuevo concepto ha sido registrado", LogUsuario.TipoLog.Informacion)
                    obj.SerializarLog(log)
                Else
                    MessageBox.Show("No se pudo agregar el concepto", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End Using

        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            Grabo = False
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        Return Grabo
    End Function

    Private Sub InsertarDetalles()
        Try
            For Each nodo As TreeGridNode In tgvCuentas.Nodes
                If tgvCuentas.Item(2, nodo.RowIndex).Value Then
                    Using cmd As New SqlCommand("INSERTAR_CUENTAS_CONCEPTO_FLUJO_EFECTIVO", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = txtCodigo.Text
                        cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = tgvCuentas.Item(0, nodo.RowIndex).Value
                        cmd.CommandTimeout = 720
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            Next
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
        End Try
    End Sub

    Private Function VerificarConcepto(ByVal codigo As String)
        Dim existe As Boolean = False
        Try
            Dim cmd As New SqlCommand("VERIFICAR_COD_CONCEPTO_FLUJO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = codigo
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.HasRows Then
                existe = True
            End If
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        Return existe
    End Function

#End Region

#Region "Procedimientos"
    Private Sub CargarCuentas()
        tgvCuentas.Nodes.Clear()
        Dim coleccion As New AutoCompleteStringCollection
        Try
            Dim cmd As New SqlCommand("CARGAR_CUENTAS_AÑO_FLUJO_EFECTIVO", con)
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 720
            con.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    While reader.Read
                        tgvCuentas.Nodes.Add(reader(0), reader(1), False)
                        coleccion.Add(reader(0))
                    End While
                End If
            End Using
            txtCuenta.AutoCompleteMode = AutoCompleteMode.Suggest
            txtCuenta.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtCuenta.AutoCompleteCustomSource = coleccion
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CargarCuentasConcepto()
        Try
            Dim cmd As New SqlCommand("CARGAR_CUENTAS_CONCEPTO_FLUJO_EFECTIVO", con)
            cmd.Parameters.Add("@COD_CPTO", SqlDbType.Char).Value = txtCodigo.Text
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 720
            con.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    While reader.Read
                        ListaCuentas.Add(reader(0))
                    End While
                End If
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Administracion, ex.Message, LogUsuario.TipoLog.Critico)
            obj.SerializarLog(log)
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGrid()
        tgvDetalle.Nodes.Clear()
        Lista.Clear()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_CONCEPTOS_FLUJO_EFECTIVO", con)
            cmd.CommandType = CommandType.StoredProcedure
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
            tgvDetalle.Nodes.Clear()
            con.Close()
        End Try
        Dim nodo As TreeGridNode
        For Each row As DataRow In Lista
            If row(4) = "0" Then
                nodo = tgvDetalle.Nodes.Add(row(0), row(1), row(2), row(3), row(4), row(5))
                AgregarNodos(row, nodo)
            End If
        Next

        For Each node As TreeGridNode In tgvDetalle.Nodes
            ExpandirNodo(node)
        Next
    End Sub

    Private Sub AgregarNodos(ByVal dr As DataRow, ByVal nodo As TreeGridNode)
        Dim nodoHijo As TreeGridNode
        For Each row As DataRow In Lista
            If row(4) = dr(0) Then
                nodoHijo = nodo.Nodes.Add(row(0), row(1), row(2), row(3), row(4), row(5))
                AgregarNodos(row, nodoHijo)
            End If
        Next
    End Sub

    Private Sub ExpandirNodo(ByVal nodo As TreeGridNode)
        nodo.Expand()
        For Each node As TreeGridNode In nodo.Nodes
            ExpandirNodo(node)
        Next
    End Sub

    Private Sub Limpiar()
        For Each c As Control In gbDatos.Controls
            If TypeOf c Is TextBox Then
                DirectCast(c, TextBox).Clear()
            End If
        Next
        For Each nodo As TreeGridNode In tgvCuentas.Nodes
            tgvCuentas.Item(2, nodo.RowIndex).Value = False
        Next

        txtCuenta.Clear()
        ListaCuentas.Clear()
    End Sub
#End Region

#Region "Botones"

    Private Sub CancelarConcepto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        tcConceptos.SelectedTab = tpListado
    End Sub

    Private Sub EliminarConcepto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If tgvDetalle.RowCount > 0 Then
            Dim nodo As TreeGridNode = tgvDetalle.CurrentNode
            If Not nodo Is Nothing Then
                Dim codigo As String = tgvDetalle.Item(0, nodo.RowIndex).Value
                Dim concepto As String = String.Format("{0} - {1}", codigo, tgvDetalle.Item(1, nodo.RowIndex).Value)
                If nodo.Nodes.Count > 0 Then
                    MessageBox.Show(String.Format("No se puede eliminar el concepto {0}, verifíque los niveles inferiores", concepto), _
                        My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If MessageBox.Show(String.Format("Está seguro de eliminar el concepto {0}", concepto), My.Application.Info.Title, _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If Eliminar(codigo) Then
                        MessageBox.Show("El concepto ha sido eliminado", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DataGrid()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GrabarConcepto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If String.IsNullOrEmpty(txtCodigo.Text.ToString.Trim) OrElse String.IsNullOrEmpty(txtDescripcion.Text.Trim) Then
            MessageBox.Show("Debe ingresar todos los datos", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim codigo As String = txtCodigo.Text
        If EsNuevo Then
            If VerificarConcepto(codigo) Then
                MessageBox.Show("El Código de concepto ya existe", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Insertar(codigo) Then
                MessageBox.Show("El nuevo concepto ha sido registrado", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DataGrid()
                tcConceptos.SelectedTab = tpListado
            End If
        Else
            If Actualizar(codigo) Then
                MessageBox.Show("El concepto ha sido actualizado", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DataGrid()
                tcConceptos.SelectedTab = tpListado
            End If
        End If
    End Sub

    Private Sub ModificarConcepto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Modificar.Click
        If tgvDetalle.RowCount > 0 Then
            Dim nodo As TreeGridNode = tgvDetalle.CurrentNode
            If Not nodo Is Nothing Then
                tpDetalle.Parent = tcConceptos
                tcConceptos.SelectedTab = tpDetalle
                Limpiar()
                EsNuevo = False
                txtCodigo.Text = tgvDetalle.Item(0, nodo.RowIndex).Value
                txtDescripcion.Text = tgvDetalle.Item(1, nodo.RowIndex).Value
                txtAbreviado.Text = tgvDetalle.Item(2, nodo.RowIndex).Value
                chkFlujo.Checked = tgvDetalle.Item(3, nodo.RowIndex).Value
                txtCodConceptoSuperior.Text = tgvDetalle.Item(4, nodo.RowIndex).Value
                txtNivel.Text = tgvDetalle.Item(5, nodo.RowIndex).Value
                tgvCuentas.Visible = tgvDetalle.Item(5, nodo.RowIndex).Value > 2
                gbBuscar.Visible = tgvDetalle.Item(5, nodo.RowIndex).Value > 2
                If Not nodo.Parent Is Nothing AndAlso nodo.Parent.RowIndex <> -1 Then
                    txtDescConceptoSuper.Text = tgvDetalle.Item(1, nodo.Parent.RowIndex).Value
                Else
                    txtDescConceptoSuper.Text = "<<-->>"
                End If
                txtDescripcion.Focus()
                txtCodigo.ReadOnly = True
                CargarCuentasConcepto()
                Dim i, j As Integer
                For i = 0 To ListaCuentas.Count - 1
                    For j = 0 To tgvCuentas.RowCount - 1
                        If ListaCuentas(i) = tgvCuentas.Item(0, j).Value Then
                            tgvCuentas.Item(2, j).Value = True
                            Exit For
                        End If
                    Next
                Next

            End If
        End If
    End Sub

    Private Sub NuevoConcepto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        tpDetalle.Parent = tcConceptos
        tcConceptos.SelectedTab = tpDetalle
        Limpiar()
        EsNuevo = True
        txtCodConceptoSuperior.Text = "0" : txtDescConceptoSuper.Text = "<<-->>"
        txtNivel.Text = "1"
        txtCodigo.ReadOnly = False
        tgvCuentas.Visible = False
        gbBuscar.Visible = False
        txtCodigo.Focus()
    End Sub

    Private Sub Salir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

#End Region

#Region "Menu"
    Private Sub mnuAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAgregar.Click
        Dim nodo As TreeGridNode = tgvDetalle.CurrentNode
        If Not nodo Is Nothing Then
            NuevoConcepto(sender, e)
            txtCodConceptoSuperior.Text = tgvDetalle.Item(0, nodo.RowIndex).Value
            txtDescConceptoSuper.Text = tgvDetalle.Item(1, nodo.RowIndex).Value
            txtNivel.Text = (nodo.Level + 1)
            tgvCuentas.Visible = txtNivel.Text > 2
            gbBuscar.Visible = txtNivel.Text > 2
            txtCodigo.Focus()
        Else
            NuevoConcepto(sender, e)
        End If
    End Sub

    Private Sub mnuEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        EliminarConcepto(sender, e)
    End Sub

    Private Sub mnuModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificar.Click
        ModificarConcepto(sender, e)
    End Sub
#End Region

    Private Sub tcConceptos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcConceptos.SelectedIndexChanged
        If tcConceptos.SelectedIndex = 0 Then
            tpDetalle.Parent = Nothing
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text.Length = 2 Then
            Dim codigo As String = Strings.Mid(txtCodigo.Text, 1, 1)
            If Not VerificarConcepto(codigo) Then
                MessageBox.Show(("No existe nivel 1 para el concepto " & txtCodigo.Text), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf txtCodigo.Text.Length = 3 Then
            Dim codigo As String = Strings.Mid(txtCodigo.Text, 1, 2)
            If Not VerificarConcepto(codigo) Then
                MessageBox.Show(("No existe nivel 2 para el concepto " & txtCodigo.Text), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub tgvDetalle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tgvDetalle.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo = tgvDetalle.HitTest(e.X, e.Y)
            tgvDetalle.CurrentCell = tgvDetalle.Rows.Item(ht.RowIndex).Cells.Item(0)
        End If
    End Sub

    Private Sub tgvCuentas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgvCuentas.Click
        If tgvCuentas.RowCount > 0 Then
            If tgvCuentas.CurrentCell.ColumnIndex = 2 Then
                tgvCuentas.BeginEdit(True)
            End If
        End If

    End Sub

    Private Sub txtCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuenta.TextChanged
        Dim FilasEnGrid As Integer = tgvCuentas.RowCount - 1
        Dim num As Integer
        txtCuenta.Focus()
        num = 0
        Do While num <= FilasEnGrid
            With tgvCuentas
                If (txtCuenta.Text.ToLower = Strings.Mid(.Item(0, num).Value, 1, Strings.Len(txtCuenta.Text)).ToLower) Then
                    .CurrentCell = .Rows.Item(num).Cells.Item(0)
                    Exit Do
                End If
            End With
            num += 1
        Loop
    End Sub

    Private Sub llblVerCuentas_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblVerCuentas.LinkClicked
        Dim frm As New frmTexto("Concepto:", txtDescripcion.Text)
        Dim sb As New StringBuilder
        Dim i, j As Integer
        With tgvCuentas
            j = 0
            For i = 0 To .RowCount - 1
                If .Item(2, i).Value Then
                    j += 1
                    sb.AppendLine(String.Format("{0}.{1}  {2}", j, .Item(0, i).Value.ToString.PadLeft(14 - (j.ToString.Length - 1), " "), .Item(1, i).Value))
                End If
            Next
        End With
        frm.rtbTexto.Text = sb.ToString
        frm.Text = "Cuentas agregadas"
        frm.ShowDialog()

    End Sub
End Class