Imports System.Data.SqlClient
Imports System.Data
Public Class CONSULTA_CUADRE_CONCILIADO
    Private obj As New Class1
    Public ST_CUADRE As String
#Region "CONSTRUCTOR"
    Private Shared INSTANCIA As CONSULTA_CUADRE_CONCILIADO
    Public Shared Function OBTENERINSTANCIA() As CONSULTA_CUADRE_CONCILIADO
        If INSTANCIA Is Nothing OrElse INSTANCIA.IsDisposed Then
            INSTANCIA = New CONSULTA_CUADRE_CONCILIADO
        End If
        INSTANCIA.BringToFront()
        Return INSTANCIA
    End Function
    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub CONSULTA_CUADRE_CONCILIADO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CONSULTA_CUADRE_CONCILIADO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case ST_CUADRE
            Case "P"
                Me.Text = "CONSULTA CUADRE CONCILIADO POR PAGAR"
            Case "C"
                Me.Text = "CONSULTA CUADRE CONCILIADO POR COBRAR"
            Case "O"
                Me.Text = "CONSULTA CUADRE CONCILIADO OTROS"
        End Select
        KeyPreview = True
        CARGAR_MONEDA()
        CARGAR_AÑO()
        CARGAR_CUENTAS()
    End Sub
    Sub CARGAR_CUENTAS()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_STATUS(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(4).Visible = False
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_MONEDA()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda1.DataSource = DT
        cbo_moneda1.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda1.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda1.SelectedIndex = -1
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año1.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txt_cod_cta1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString

                        '---------------------------------------------------
                        'Panel_cuenta.Visible = True
                        '---------------------------------------------------
                        Label2.Focus()
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_des_cta0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If ((Strings.Trim(txt_desc_cta0.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_cta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            '---------------------------------------------------

            '---------------------------------------------------
            Panel_cuenta.Visible = False
            Label2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            Panel_cuenta.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        '---validar
        If txt_cod_cta0.Text = "" Then MessageBox.Show("Debe ingresar el numero de cuenta", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If cbo_moneda1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la moneda", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda1.Focus() : Exit Sub
        If cbo_año1.SelectedIndex = -1 Then MessageBox.Show("Debe ingresar el año", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año1.Focus() : Exit Sub
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe ingresar el mes", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        '----verificar cuenta no cuadradas
        dgw1.Rows.Clear()
        dgw1_det.Rows.Clear()
        txt_debe.Clear()
        txt_haber.Clear()
        con.Open()
        Dim CMD As SqlCommand
        CMD = New SqlCommand("VERIFICAR_CXP_CONCILIADA", con)
        CMD.CommandTimeout = 720
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
        CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cbo_moneda1.SelectedValue
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes1.Text)
        CMD.Parameters.Add("@ST_CUADRE", SqlDbType.Char).Value = ST_CUADRE
        Dim DR As SqlDataReader = CMD.ExecuteReader
        Dim total_d, total_h As Decimal
        While DR.Read
            If DR(5) <> DR(6) Then
                dgw1.Rows.Add(DR(0), DR(1), DR(2), DR(3).ToString, DR(4), DR(5), DR(6), DR(7))
                total_d = total_d + DR(5)
                total_h = total_h + DR(6)
            End If
        End While
        txt_debe.Text = Format(total_d, "0,000.00")
        txt_haber.Text = Format(total_h, "0,000.00")
        con.Close()
    End Sub

    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Dim COD_DOC, NRO_DOC, COD_PER As Object
        dgw1_det.Rows.Clear()
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw1.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            COD_DOC = dgw1.Item(0, dgw1.CurrentRow.Index).Value
            NRO_DOC = dgw1.Item(1, dgw1.CurrentRow.Index).Value
            COD_PER = dgw1.Item(2, dgw1.CurrentRow.Index).Value
            MOSTRAR_DETALLE(COD_DOC, NRO_DOC, COD_PER)
        End If
    End Sub
    Function MOSTRAR_DETALLE(ByVal COD_DOC As Object, ByVal NRO_DOC As Object, ByVal COD_PER As Object) As Boolean
        con.Open()
        Dim cmd As New SqlCommand("VERIFICAR_CXP_CONCILIADA_DET", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
        cmd.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = cbo_moneda1.SelectedValue
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
        cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = COD_DOC
        cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
        cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
        cmd.Parameters.Add("@ST_CUADRE", SqlDbType.Char).Value = ST_CUADRE
        Dim DR As SqlDataReader = cmd.ExecuteReader
        While DR.Read
            dgw1_det.Rows.Add(DR(0), DR(1), DR(2), Format(DR(3), "dd/MM/yyyy"), DR(4), DR(5), IIf(DR(6) = "1", True, False))
        End While
        con.Close()
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        dgw1.Rows.Clear()
        dgw1_det.Rows.Clear()
        txt_debe.Clear()
        txt_haber.Clear()
    End Sub

    Private Sub dgw1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellClick
        If e.RowIndex <> -1 Then
            If e.ColumnIndex = 8 Then
                If dgw1.Item(8, e.RowIndex).Value = True Then
                    dgw1.Item(8, e.RowIndex).Value = False
                Else
                    dgw1.Item(8, e.RowIndex).Value = True
                End If
                'With dgw1
                '    .Item(8, e.RowIndex).Value = .Item(8, e.RowIndex).Value
                'End With
            End If
            '----------------------------------------------------
            '----------------------------------------------------
            If e.ColumnIndex = 8 Then
                Dim valchk As Boolean = dgw1.Item(8, dgw1.CurrentRow.Index).Value
                Dim valdif As Decimal = dgw1.Item(7, dgw1.CurrentRow.Index).Value
                If txt_completar.Text = "" Then txt_completar.Text = "0.00"
                Dim total As Decimal = Decimal.Parse(txt_completar.Text)
                If valchk = True Then
                    'If valdif > 0 Then
                    total += valdif
                    'Else
                    '    total += valdif
                    'End If
                Else
                    'If valdif > 0 Then
                    total -= valdif
                    'Else
                    '    total += valdif
                    'End If
                End If
                txt_completar.Text = total
                Format(txt_completar.Text, "0,000.00")
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_visible.CheckedChanged
        Dim fill As New DataGridViewRow
        Dim contfill As Integer = 0
        If ch_visible.Checked = True Then
            ch_visible.Text = "Mostrar"
            contfill = 0
            For Each fill In dgw1.Rows
                If Me.dgw1.Item(8, contfill).Value = True Then
                    'Me.dgw1.Rows.Remove(Me.dgw1.CurrentRow)
                    Me.dgw1.Rows(contfill).Visible = False
                    Me.dgw1.Refresh()
                End If
                contfill += 1
            Next
        Else
            ch_visible.Text = "Ocultar"
            contfill = 0
            For Each fill In dgw1.Rows
                If Me.dgw1.Item(8, contfill).Value = True Then
                    'Me.dgw1.Rows.Remove(Me.dgw1.CurrentRow)
                    Me.dgw1.Rows(contfill).Visible = True
                    Me.dgw1.Refresh()
                End If
                contfill += 1
            Next
        End If
    End Sub
End Class
