Imports System.Data.SqlClient
Public Class CONSULTA_FORMULARIO_SEGURIDAD
    Dim REP As New REP_FORMULARIO_SEGURIDAD
#Region "CONSTRUCTOR"
    Private Shared _instancia As CONSULTA_FORMULARIO_SEGURIDAD
    Public Shared Function ObtenerInstancia() As CONSULTA_FORMULARIO_SEGURIDAD
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New CONSULTA_FORMULARIO_SEGURIDAD
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
    Private Sub CONSULTA_FORMULARIO_SEGURIDAD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_MODULO()
        cbo_menu.Enabled = False
    End Sub
    Sub CARGAR_MODULO()
        cbo_mod.DataSource = Nothing
        Dim CMD As New SqlCommand("SELECT COD_MODULO,DESC_MODULO FROM FORMULARIO_MODULO", con)
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim dt As New DataTable("MODULO")
        ADAP.Fill(dt)
        cbo_mod.DataSource = dt
        cbo_mod.DisplayMember = dt.Columns(1).ToString
        cbo_mod.ValueMember = dt.Columns(0).ToString : cbo_mod.SelectedIndex = -1
    End Sub

    Private Sub cbo_mod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mod.SelectedIndexChanged
        If cbo_mod.SelectedIndex <> -1 Then
            Dim COD As String = cbo_mod.SelectedValue.ToString
            cargar_menu(COD)
        End If
    End Sub
    Sub cargar_menu(ByVal MODULO As String)
        cbo_menu.DataSource = Nothing
        Dim CMD As New SqlCommand("SELECT COD_MENU,DESC_MENU FROM FORMULARIO_MENU WHERE COD_MODULO='" & MODULO & "'", con)
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim dt As New DataTable("MENU")
        ADAP.Fill(dt)
        cbo_menu.DataSource = dt
        cbo_menu.DisplayMember = dt.Columns(1).ToString
        cbo_menu.ValueMember = dt.Columns(0).ToString : cbo_menu.SelectedIndex = -1
    End Sub

    Private Sub chk_menu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_menu.CheckedChanged
        cbo_menu.Enabled = chk_menu.Checked
        cbo_menu.SelectedIndex = -1
    End Sub

    Private Sub BTN_CONSULTA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CONSULTA1.Click
        If cbo_mod.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Modulo", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_mod.Focus() : Exit Sub
        If (chk_menu.Checked And cbo_menu.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Menu", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_menu.Focus() : Exit Sub
        Dim MODULO, MENU, ST_MENU As String
        MODULO = cbo_mod.SelectedValue.ToString
        If chk_menu.Checked Then
            ST_MENU = "1"
            MENU = cbo_menu.SelectedValue.ToString
        Else
            ST_MENU = "0"
            MENU = ""
        End If
        CONSULTA_FORMULARIO_SEGURIDAD(MODULO, MENU, ST_MENU)
    End Sub
    Sub CONSULTA_FORMULARIO_SEGURIDAD(ByVal MODULO As String, ByVal MENU As String, ByVal ST_MENU As String)
        Dim CMD As New SqlCommand("CONSULTA_FORMULARIO_SEGURIDAD", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = MODULO
        CMD.Parameters.Add("@COD_MENU", SqlDbType.Char).Value = MENU
        CMD.Parameters.Add("@ST_MENU", SqlDbType.Char).Value = ST_MENU
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim DT As New DataTable("CONSULTA")
        ADAP.Fill(DT)
        DGW1.DataSource = DT
        DGW1.Columns(0).Width = 90
        DGW1.Columns(1).Width = 90
        DGW1.Columns(2).Width = 360
        DGW1.Columns(3).Width = 240
        DGW1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8, FontStyle.Bold)
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        If cbo_mod.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Modulo", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_mod.Focus() : Exit Sub
        If (chk_menu.Checked And cbo_menu.SelectedIndex = -1) Then MessageBox.Show("Debe seleccionar el Menu", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_menu.Focus() : Exit Sub
        'If DGW1.Rows.Count = 0 Then MessageBox.Show("No hay registros", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim MODULO As String = cbo_mod.SelectedValue
        Dim ST_MENU, MENU As String
        If chk_menu.Checked Then
            ST_MENU = "1"
            Menu = cbo_menu.SelectedValue.ToString
        Else
            ST_MENU = "0"
            Menu = ""
        End If
        REP.CREAR_REPORTE(MODULO, ST_MENU, MENU, cbo_mod.Text)
        REP.ShowDialog()
    End Sub
End Class