Imports System.Data.SqlClient
Public Class frmMensajes

#Region "Constructor"
    Private Shared _instancia As frmMensajes

    Public Shared Function ObtenerInstancia() As frmMensajes
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New frmMensajes
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region
    Dim boton As String
    Private Sub MENSAJES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.F1 Then
            Try
                ''Help.ShowHelp( "C:\Documents and Settings\MARIA\Escritorio\PROYECTOS\Manual Comercial v2\HTML\cuentas_por_cobrar3.htm", HelpNavigator.Topic)
                'Help.ShowHelp(manual & "mensajes_de_impresion.htm", HelpNavigator.Topic)
            Catch exc As Exception
                MessageBox.Show(exc.Message, "Error al Cargar ayuda ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
    Private Sub MENSAJES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
    End Sub
    Sub DATAGRID()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_MENSAJES", con)
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("MENSAJES")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns(0).Width = 40
            dgw1.Columns(1).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        ' If M = False And TIPO_USU = "US" Then MessageBox.Show("Ud. no tiene permiso para realizar esta acción", "Sin permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_modificar.Focus() : Exit Sub
        ''txt_cod0.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        ''txt_cod.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        ''txt_desc.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        TabControl1.SelectedTab = TabPage2
        txt_cod0.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_cod.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        TabControl1.SelectedTab = TabPage2
        btn_guardar_n.Visible = False
        btn_guardar.Visible = True
        txt_desc.Focus()
        txt_cod0.ReadOnly = True
        txt_cod.ReadOnly = True
        txt_desc.CharacterCasing = CharacterCasing.Upper
        'txt_desc.Focus()
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Try
            Dim CMD As New SqlCommand("MODIFICAR_MENSAJES", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@CODIGO", SqlDbType.Char).Value = txt_cod0.Text
            CMD.Parameters.Add("@MENSAJE", SqlDbType.Char).Value = txt_desc.Text
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        DATAGRID()
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(25) = 0
        Close()
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedTab Is TabPage2 Then
        '    txt_cod0.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        '    txt_cod.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        '    txt_desc.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        '    TabControl1.SelectedTab = TabPage2
        '    txt_desc.Focus()
        'End If
    End Sub
    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc.KeyDown
        If e.KeyData = Keys.Down Then
            btn_guardar.Focus()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btm_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btm_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim CODIGO As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        Dim RSPTA As String = MessageBox.Show("Eliminar: " & CODIGO & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString, "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If RSPTA = vbYes Then
            'ELIMINAR
            Try
                Dim CMD As New SqlCommand("[ELIMINAR_MENSAJES]", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@CODIGO", SqlDbType.Char).Value = CODIGO
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        DATAGRID()
        btn_nuevo.Select()
    End Sub
    Sub LIMPIAR()
        txt_cod0.Clear()
        txt_cod0.ReadOnly = False
        txt_cod.Clear()
        txt_desc.Clear()
        txt_cod.ReadOnly = False
        txt_cod.CharacterCasing = CharacterCasing.Upper
        txt_cod0.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub btm_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar_n.Visible = True
        btn_guardar.Visible = False
        LIMPIAR()
        TabControl1.SelectedTab = TabPage2
        txt_cod0.Focus()
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_MENSAJE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = txt_cod.Text
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function

    Private Sub btn_guardar_n_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_n.Click
        If Trim(txt_cod0.Text) = "" Or Trim(txt_desc.Text) = "" Or Trim(txt_cod.Text) = "" Then
            MessageBox.Show("Ingrese los datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
        If CONTAR_REG() > 0 Then
            MessageBox.Show("El código de Mensaje ya existe", "Ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
        Try
            Dim CMD As New SqlCommand("INSERTAR_MENSAJES", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = txt_cod0.Text
            CMD.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = txt_cod.Text
            CMD.Parameters.Add("@MENSAJE", SqlDbType.VarChar).Value = txt_desc.Text
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("El Mensaje se guardó", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR()
            txt_cod.Focus()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()
    End Sub
End Class