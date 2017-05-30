Imports System.Data.SqlClient
Public Class ANALISIS_CONTABILIDAD
    Dim OBJ As New Class1
    Dim cod_mes, ST_CUENTA As String
#Region "Constructor"
    Private Shared _instancia As ANALISIS_CONTABILIDAD

    Public Shared Function ObtenerInstancia() As ANALISIS_CONTABILIDAD
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New ANALISIS_CONTABILIDAD
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
    Private Sub ANALISIS_CTAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub ANALISIS_CTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        cbo_año_v.Text = Year(Today.Date)
        dgw_v.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        cbo_mes_v.Focus()
        cbo_mes_v.SelectedIndex = 0
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año_v.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTA()
        '-----------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año_v.Text)
            dgw_cta_v.DataSource = (DT)
            dgw_cta_v.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta_v.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub MOSTRAR_CONSULTA_DUPLICADAS()
        dgw_v.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTAR_CTA_DUPLICADA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta_v.Text
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año_v.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes_v.Text)
            PROG_01.Parameters.Add("@ST_CUENTA", SqlDbType.Char).Value = ST_CUENTA
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_v.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta2_v.Click
        If cbo_tcuenta.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tcuenta.Focus() : Exit Sub
        If txt_cod_cta_v.Text.Trim = "" Then MessageBox.Show("Debe elgir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta_v.Focus() : Exit Sub
        If cbo_año_v.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año_v.Focus() : Exit Sub
        If cbo_mes_v.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes_v.Focus() : Exit Sub
        MOSTRAR_CONSULTA_DUPLICADAS()
        G2_v.Enabled = False
        'BTN_MOD_ANA.Focus()
    End Sub

    Private Sub txt_desc_cta_v_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta_v.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_v.Text) <> "")) Then
            If (dgw_cta_v.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta_v.Sort(dgw_cta_v.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_v.RowCount - 1))
                    If (txt_desc_cta_v.Text.ToLower = Strings.Mid((dgw_cta_v.Item(1, i).Value), 1, Strings.Len(txt_desc_cta_v.Text)).ToLower) Then
                        dgw_cta_v.CurrentCell = (dgw_cta_v.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_cta_v.Visible = True
                dgw_cta_v.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod_cta_v_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta_v.LostFocus
        If (Strings.Trim(txt_cod_cta_v.Text) <> "") Then
            If (dgw_cta_v.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta_v.Sort(dgw_cta_v.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_v.RowCount - 1))
                    If (txt_cod_cta_v.Text.ToLower = dgw_cta_v.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta_v.Text = dgw_cta_v.Item(0, i).Value.ToString
                        txt_desc_cta_v.Text = dgw_cta_v.Item(1, i).Value.ToString
                        btn_consulta2_v.Focus()
                        Return
                    End If
                    If (txt_cod_cta_v.Text.ToLower = Strings.Mid((dgw_cta_v.Item(0, i).Value), 1, Strings.Len(txt_cod_cta_v.Text)).ToLower) Then
                        dgw_cta_v.CurrentCell = (dgw_cta_v.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_cta_v.Visible = True
                dgw_cta_v.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_cta_v_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta_v.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta_v.Text = (dgw_cta_v.Item(0, dgw_cta_v.CurrentRow.Index).Value)
            txt_desc_cta_v.Text = (dgw_cta_v.Item(1, dgw_cta_v.CurrentRow.Index).Value)
            panel_cta_v.Visible = False
            Label24.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_cta_v.Visible = False
            txt_cod_cta_v.Clear()
            txt_desc_cta_v.Clear()
            txt_cod_cta_v.Focus()
        End If
    End Sub
    Sub limpiar_verificacion()
        txt_cod_cta_v.Clear()
        txt_desc_cta_v.Clear()
        G2_v.Enabled = True
        dgw_v.Rows.Clear()
        txt_cod_cta_v.Focus()
    End Sub
    Private Sub btn_limpiar_v_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar_v.Click
        limpiar_verificacion()
    End Sub

    Private Sub btn_salir_v_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_v.Click
        Close()
    End Sub

    Private Sub cbo_tcuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tcuenta.SelectedIndexChanged
        Select Case cbo_tcuenta.Text
            Case "Cobrar" : ST_CUENTA = "C"
            Case "Pagar" : ST_CUENTA = "P"
            Case "Otros" : ST_CUENTA = "O"
        End Select
    End Sub

    Private Sub cbo_año_v_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año_v.SelectedIndexChanged
        CARGAR_CUENTA()
    End Sub

    Private Sub cbo_mes_v_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes_v.SelectedIndexChanged
        CARGAR_CUENTA()
    End Sub
End Class