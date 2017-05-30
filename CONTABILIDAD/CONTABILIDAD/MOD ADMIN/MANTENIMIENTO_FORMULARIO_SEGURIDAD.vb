Imports System.Data.SqlClient
Public Class MANTENIMIENTO_FORMULARIO_SEGURIDAD
    Dim boton As String
    Dim obj As New Class1
    Dim COD_TIPO As String
    Dim REP As New REP_MANT_FORMULARIO_SEGURIDAD
    Dim COD_FORM, COD_MODULO, COD_MENU As String
#Region "CONSTRUCTOR"
    Private Shared _instancia As MANTENIMIENTO_FORMULARIO_SEGURIDAD
    Public Shared Function ObtenerInstancia() As MANTENIMIENTO_FORMULARIO_SEGURIDAD
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New MANTENIMIENTO_FORMULARIO_SEGURIDAD
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region
    Private Sub CLASE_ARTICULO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.F1 Then
            Try
                'Help.ShowHelp(manual & "clase.htm", HelpNavigator.Topic)
            Catch exc As Exception
                MessageBox.Show(exc.Message, "Error al Cargar ayuda ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
    Private Sub CLASE_ARTICULO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles me.Load
        KeyPreview = True
        datagrid()
        'cargar_menu()
        cargar_modulo()
        btn_nuevo.Select()
        cbo_tipo.SelectedIndex = -1
    End Sub
    Sub cargar_menu(ByVal MODULO As String)
        cbo_menu.DataSource = Nothing
        Dim CMD As New SqlCommand("SELECT COD_MENU,DESC_MENU FROM FORMULARIO_MENU WHERE COD_MODULO='" & MODULO & "'", con)
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim dt As New DataTable("MENU")
        ADAP.Fill(dt)
        cbo_menu.DataSource = dt
        cbo_menu.DisplayMember = dt.Columns(1).ToString
        cbo_menu.ValueMember = dt.Columns(0).ToString 'cbo_menu.SelectedIndex = -1
    End Sub
    Sub cargar_modulo()
        cbo_mod.DataSource = Nothing
        Dim CMD As New SqlCommand("SELECT COD_MODULO,DESC_MODULO FROM FORMULARIO_MODULO", con)
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim dt As New DataTable("MODULO")
        ADAP.Fill(dt)
        cbo_mod.DataSource = dt
        cbo_mod.DisplayMember = dt.Columns(1).ToString
        cbo_mod.ValueMember = dt.Columns(0).ToString : cbo_mod.SelectedIndex = -1
    End Sub
    Sub datagrid()
        Try
            Dim cmd As New SqlCommand("[MOSTRAR_FORMULARIO_SEGURIDAD]", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns(0).Width = 40
            dgw1.Columns(1).Width = 330
            dgw1.Columns(2).Width = 60
            dgw1.Columns(3).Width = 60
            dgw1.Columns(4).Width = 40
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        cbo_tipo.SelectedIndex = -1
        cbo_mod.SelectedIndex = -1
        cbo_menu.SelectedIndex = -1
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        cbo_tipo.Enabled = True
        cbo_mod.Enabled = True
        cbo_menu.Enabled = True
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        'LIMPIAR()

        txt_desc.Clear()
        cbo_mod.Enabled = True
        cbo_menu.Enabled = True
        cbo_tipo.SelectedIndex = -1
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        cbo_tipo.Enabled = True
        If cbo_mod.SelectedIndex <> -1 Then
            txt_cod.Text = txt_cod.Text.Substring(0, 1)
        End If
        TabControl1.SelectedTab = TabPage2
        cbo_mod.Focus()
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Exit Sub
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.ReadOnly = True
        cbo_menu.Enabled = False
        cbo_mod.Enabled = False
        cbo_tipo.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub
    Function OBTENER_DESC_MOD(ByVal COD_MOD As String) As String
        Dim RSLT As String = ""
        Dim CMD As New SqlCommand("SELECT DESC_MODULO FROM FORMULARIO_MODULO WHERE COD_MODULO='" & COD_MOD & "'", con)
        CMD.CommandType = CommandType.Text
        con.Open()
        RSLT = CMD.ExecuteScalar()
        con.Close()
        Return RSLT
    End Function
    Function OBTENER_DESC_MENU(ByVal COD_MENU As String, ByVal COD_MOD As String) As String
        Dim RSLT As String = ""
        Dim CMD As New SqlCommand("SELECT DESC_MENU FROM FORMULARIO_MENU WHERE COD_MENU='" & COD_MENU & "' AND COD_MODULO='" & COD_MOD & "'", con)
        CMD.CommandType = CommandType.Text
        con.Open()
        RSLT = CMD.ExecuteScalar()
        con.Close()
        Return RSLT
    End Function
    Sub CARGAR_DATOS()
        cbo_mod.Text = OBTENER_DESC_MOD(dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_menu.Text = OBTENER_DESC_MENU(dgw1.Item(3, dgw1.CurrentRow.Index).Value, dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        'cbo_tipo.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value
        Select Case dgw1.Item(4, dgw1.CurrentRow.Index).Value
            Case "M" : cbo_tipo.Text = "MANTENIMIENTO"
            Case "C" : cbo_tipo.Text = "CONSULTA"
            Case "R" : cbo_tipo.Text = "REPORTES"
        End Select
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage2 Then
            If boton = "NUEVO" Then
                boton = "DETALLES1"
            ElseIf boton = "MODIFICAR" Then
                boton = "DETALLES2"
            Else
                boton = "DETALLES"
                LIMPIAR()
                If dgw1.Rows.Count = 0 Then
                Else
                    CARGAR_DATOS()
                End If
                txt_cod.ReadOnly = True
                txt_desc.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
                cbo_tipo.Enabled = False
                cbo_menu.Enabled = False
                cbo_mod.Enabled = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
    Function VALIDAR_MODULO_MENU() As String
        Dim V As String = ""
        '--------------
        Select Case cbo_mod.Text
            Case "ADMINISTRACION"
                Select Case cbo_menu.Text
                    Case "MAESTRO" : V = "M"
                    Case "PERIODO" : V = "M"
                    Case "SEGURIDAD" : V = "M"
                    Case "PROCESO" : V = "M"
                    Case "TABLAS" : V = "M"
                End Select
            Case "BANCO"
                Select Case cbo_menu.Text
                    Case "MAESTRO" : V = "B"
                    Case "PROCESO" : V = "B"
                    Case "TRANSACCION" : V = "B"
                End Select
            Case "CONTABILIDAD"
                Select Case cbo_menu.Text
                    Case "ANALISIS" : V = "A"
                    Case "MAESTRO" : V = "M"
                    Case "PROCESO" : V = "M"
                    Case "TRANSACCION" : V = "T"
                    Case "TIPO CAMBIO" : V = "M"
                End Select
        End Select
        '---------------
        Return V
    End Function
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Trim(txt_cod.Text) = "" Or Trim(txt_desc.Text) = "" Or cbo_menu.SelectedIndex = -1 Or cbo_mod.SelectedIndex = -1 Then
            MessageBox.Show("INGRESE LOS DATOS", "FALTAN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
        If CONTAR_REG(txt_cod.Text) > 0 Then
            MessageBox.Show("EL CODIGO DE FORMULARIO YA EXISTE", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
        '--------------------------validar primera letra del codigo
        Dim LETRA As String = txt_cod.Text.Substring(0, 1)
        Dim V As String = VALIDAR_MODULO_MENU()
        'Select Case cbo_mod.Text
        '    Case "ADMINISTRACION" : V = "A"
        '    Case "CONTABILIDAD" : V = "C"
        '    Case "BANCO" : V = "B"
        'End Select
        If LETRA <> V Then MessageBox.Show("El Codigo es incorrecto", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cod.Focus() : Exit Sub
        '--------------------------
        Try
            Dim CMD As New SqlCommand("[INSERTAR_FORMULARIO_SEGURIDAD]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_FORM", SqlDbType.Char).Value = txt_cod.Text
            CMD.Parameters.Add("@DESC_FORM", SqlDbType.VarChar).Value = txt_desc.Text
            CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = cbo_mod.SelectedValue
            CMD.Parameters.Add("@COD_MENU", SqlDbType.Char).Value = cbo_menu.SelectedValue
            CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = COD_TIPO
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("EL FORMULARIO SE GUARDÓ", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '----
            COD_FORM = txt_cod.Text : COD_MENU = cbo_menu.SelectedValue : COD_MODULO = cbo_mod.SelectedValue
            '----
            'LIMPIAR()
            txt_cod.Focus()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        txt_desc.Clear()
        cbo_tipo.SelectedIndex = -1
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        cbo_tipo.Enabled = True
        txt_cod.Text = txt_cod.Text.Substring(0, 1)
        cbo_mod.Focus()
        datagrid()
        ENCONTRAR_FILA()
    End Sub
    Sub ENCONTRAR_FILA()
        For Each ROW As DataGridViewRow In dgw1.Rows
            If dgw1.Item(0, ROW.Index).Value = COD_FORM Then
                dgw1.CurrentCell = (dgw1.Rows.Item(ROW.Index).Cells.Item(0))
            End If
        Next
    End Sub
    Function CONTAR_REG(ByVal COD As String) As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VALIDAR_CODIGO_FORMULARIO_SEGURIDAD", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_FORM", SqlDbType.Char).Value = COD
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        If Trim(txt_cod.Text) = "" Or Trim(txt_desc.Text) = "" Or cbo_menu.SelectedIndex = -1 Or cbo_mod.SelectedIndex = -1 Then
            MessageBox.Show("INGRESE LOS DATOS", "FALTAN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
            Exit Sub
        End If
        Try
            Dim CMD As New SqlCommand("[MODIFICAR_FORMULARIO_SEGURIDAD]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_FORM", SqlDbType.Char).Value = txt_cod.Text
            CMD.Parameters.Add("@DESC_FORM", SqlDbType.VarChar).Value = txt_desc.Text
            CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = cbo_mod.SelectedValue
            CMD.Parameters.Add("@COD_MENU", SqlDbType.Char).Value = cbo_menu.SelectedValue
            CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = COD_TIPO
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("EL FORMULARIO SE GUARDÓ", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '----
            COD_FORM = txt_cod.Text : COD_MENU = cbo_menu.SelectedValue : COD_MODULO = cbo_mod.SelectedValue
            '----
            'LIMPIAR()
            txt_cod.Focus()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        txt_desc.Clear()
        cbo_tipo.SelectedIndex = -1
        cbo_menu.Enabled = True
        cbo_mod.Enabled = True
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        cbo_tipo.Enabled = True
        txt_cod.Text = txt_cod.Text.Substring(0, 1)
        cbo_mod.Focus()
        datagrid()
        ENCONTRAR_FILA()
        btn_nuevo.Select()
        TabControl1.SelectedIndex = 0
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Exit Sub
        End Try
        Dim COD As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value
        Dim MODULO As String = dgw1.Item(2, dgw1.CurrentRow.Index).Value
        Dim MENU As String = dgw1.Item(3, dgw1.CurrentRow.Index).Value
        Dim RSPTA As String = MessageBox.Show("Eliminar " & COD & "", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If RSPTA = vbYes Then
            Try
                Dim CMD As New SqlCommand("[ELIMINAR_FORMULARIO_SEGURIDAD]", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_FORM", SqlDbType.Char).Value = COD
                CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = MODULO
                CMD.Parameters.Add("@COD_MENU", SqlDbType.Char).Value = MENU
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        datagrid()
        btn_nuevo.Select()
    End Sub
    Function VALIDAR_E(ByVal COD_CLASE As String) As Boolean
        Dim CONT As String = ""
        Try
            Dim CMD As New SqlCommand("VALIDAR_ELIMINAR_CLASE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = COD_CLASE
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If CONT = "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(45) = 0
        Close()
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        '----
        'COD_FORM = txt_cod.Text : COD_MENU = cbo_menu.SelectedValue : COD_MODULO = cbo_mod.SelectedValue
        '----
        For Each ROWS As DataGridViewRow In dgw1.Rows
            If dgw1.Item(0, ROWS.Index).Value = COD_FORM Then
                If dgw1.Item(2, ROWS.Index).Value = COD_MODULO Then
                    If dgw1.Item(3, ROWS.Index).Value = COD_MENU Then
                        If dgw1.Item(4, ROWS.Index).Value = COD_TIPO Then
                            dgw1.CurrentCell = (dgw1.Rows.Item(ROWS.Index).Cells.Item(4))
                        End If
                    End If
                End If
            End If
        Next
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub
    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod.KeyDown
        If e.KeyData = Keys.Down Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc.KeyDown
        If e.KeyData = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyData = Keys.Up Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Down Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyData = Keys.Up Then
            txt_desc.Focus()
        End If
    End Sub

    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo.SelectedIndexChanged
        Select Case cbo_tipo.Text
            Case "MANTENIMIENTO"
                COD_TIPO = "M"
            Case "CONSULTA"
                COD_TIPO = "C"
            Case "REPORTES"
                COD_TIPO = "R"
        End Select
    End Sub

    Private Sub cbo_mod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mod.SelectedIndexChanged
        
        If cbo_mod.SelectedIndex <> -1 Then
            Dim COD As String = cbo_mod.SelectedValue.ToString
            cargar_menu(COD)
            'Select Case cbo_mod.Text
            '    Case "ADMINISTRACION" : txt_cod.Text = "A"
            '    Case "CONTABILIDAD" : txt_cod.Text = "C"
            '    Case "BANCO" : txt_cod.Text = "B"
            'End Select
            'txt_cod.Text = (cbo_mod.Text.ToUpper.Substring(0, 1))
        End If
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        'If cbo_mod.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Modulo", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_mod.Focus() : Exit Sub
        'If (chk_menu.Checked And cbo_menu.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Menu", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_menu.Focus() : Exit Sub
        If dgw1.Rows.Count = 0 Then MessageBox.Show("No hay registros", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim MODULO As String = cbo_mod.SelectedValue
        Dim ST_MENU, MENU As String
        REP.CREAR_REPORTE()
        REP.ShowDialog()
    End Sub

    Private Sub cbo_menu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_menu.SelectedIndexChanged
        If cbo_menu.SelectedIndex <> -1 And cbo_mod.SelectedIndex <> -1 Then
            'If cbo_menu.ValueMember <> "" Then
            Select Case cbo_mod.Text
                Case "ADMINISTRACION"
                    Select Case cbo_menu.Text
                        Case "MAESTRO" : txt_cod.Text = "M"
                        Case "PERIODO" : txt_cod.Text = "M"
                        Case "SEGURIDAD" : txt_cod.Text = "M"
                        Case "PROCESO" : txt_cod.Text = "M"
                        Case "TABLAS" : txt_cod.Text = "M"
                    End Select
                Case "BANCO"
                    Select Case cbo_menu.Text
                        Case "MAESTRO" : txt_cod.Text = "B"
                        Case "PROCESO" : txt_cod.Text = "B"
                        Case "TRANSACCION" : txt_cod.Text = "B"
                    End Select
                Case "CONTABILIDAD"
                    Select Case cbo_menu.Text
                        Case "ANALISIS" : txt_cod.Text = "A"
                        Case "MAESTRO" : txt_cod.Text = "M"
                        Case "PROCESO" : txt_cod.Text = "M"
                        Case "TRANSACCION" : txt_cod.Text = "T"
                        Case "TIPO CAMBIO" : txt_cod.Text = "M"
                    End Select
            End Select
            'End If
        End If
    End Sub
End Class