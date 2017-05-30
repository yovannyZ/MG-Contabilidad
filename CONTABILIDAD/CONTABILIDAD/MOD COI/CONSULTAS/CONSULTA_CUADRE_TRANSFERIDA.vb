Imports System.Data.SqlClient
Imports System.Data
Public Class CONSULTA_CUADRE_TRANSFERIDA
    Public ST_CUADRE As String
    Dim obj As New Class1
#Region "CONSTRUCTOR"
    Private Shared INSTANCIA As CONSULTA_CUADRE_TRANSFERIDA
    Public Shared Function OBTENERINSTANCIA() As CONSULTA_CUADRE_TRANSFERIDA
        If INSTANCIA Is Nothing OrElse INSTANCIA.IsDisposed Then
            INSTANCIA = New CONSULTA_CUADRE_TRANSFERIDA
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
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Close()
    End Sub

    Private Sub CONSULTA_CUADRE_TRANSFERIDA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CONSULTA_CUADRE_TRANSFERIDA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        CARGAR_CUENTAS()
        Select Case ST_CUADRE
            Case "P"
                Me.Text = "CONSULTA CUADRE CONCILIADO POR PAGAR"
            Case "C"
                Me.Text = "CONSULTA CUADRE CONCILIADO POR COBRAR"
            Case "O"
                Me.Text = "CONSULTA CUADRE CONCILIADO OTROS"
        End Select
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
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If txt_cod_cta0.Text = "" Then MessageBox.Show("Debe ingresar la Cuenta", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Año", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        'Inicio Verificacion
        dgw1.Rows.Clear()
        dgw2.Rows.Clear()
        con.Open()
        Dim cmd As New SqlCommand("VERIFICAR_CXP_TRANSFERIDA", con)
        cmd.CommandTimeout = 720
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
        cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
        cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
        cmd.Parameters.Add("@ST_CUADRE", SqlDbType.Char).Value = ST_CUADRE
        Dim DR As SqlDataReader = cmd.ExecuteReader
        Dim DEBE_1, HABER_1 As Decimal
        While DR.Read
            dgw1.Rows.Add(DR(0), DR(1), DR(2), DR(3), DR(4), DR(5), DR(6), DR(7))
            DEBE_1 = DEBE_1 + DR(6)
            HABER_1 = HABER_1 + DR(7)
        End While
        txt_debe.Text = Format(DEBE_1, "0.00")
        txt_haber.Text = Format(HABER_1, "0.00")
        con.Close()
        VERIFICAR_TRANSFERIDAS_INVERSA()
    End Sub

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.LostFocus
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
                        Label1.Focus()
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

    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta0.KeyDown
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

    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            '---------------------------------------------------

            '---------------------------------------------------
            Panel_cuenta.Visible = False
            Label1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            Panel_cuenta.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

    Sub VERIFICAR_TRANSFERIDAS_INVERSA()
        con.Open()
        Dim cmd As New SqlCommand("VERIFICAR_CXP_TRANSFERIDA_INVERSA", con)
        cmd.CommandTimeout = 720
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
        cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
        cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
        cmd.Parameters.Add("@ST_CUADRE", SqlDbType.Char).Value = ST_CUADRE
        Dim DR As SqlDataReader = cmd.ExecuteReader
        Dim DEBE_1, HABER_1 As Decimal
        While DR.Read
            dgw2.Rows.Add(DR(0), DR(1), DR(2), DR(3), DR(4), DR(5), DR(6), DR(7))
            DEBE_1 = DEBE_1 + DR(6)
            HABER_1 = HABER_1 + DR(7)
        End While
        txt_debe2.Text = Format(DEBE_1, "0.00")
        txt_haber2.Text = Format(HABER_1, "0.00")
        con.Close()
    End Sub

    Private Sub btn_limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_limpiar.Click
        dgw1.Rows.Clear()
        dgw2.Rows.Clear()
        txt_debe.Clear()
        txt_haber.Clear()
        txt_debe2.Clear()
        txt_haber2.Clear()
    End Sub
End Class