Imports System.Data.SqlClient
Public Class REPORTE_LIBRO_CONTABLE
    Private DEBE, HABER, SALDO As Decimal
    Private REP As New REP_LIBRO_CONTABLE
    Dim obj As New Class1
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (Strings.Trim(txt_cod_ban.Text) = "") Then
            MessageBox.Show("Debe elegir un Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (cbo_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        Else
            SALDOS()
            REP.CREAR_REPORTE(cbo_año.Text, cbo_mes.Text, obj.COD_MES(cbo_mes.Text), txt_cod_ban.Text, SALDO, txt_desc_ban.Text, txt_tc_mes_anterior.Text, txt_tc_mes_actual.Text)
            REP.ShowDialog()
        End If
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click
        main(118) = 0
        Me.Close()
    End Sub
    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS_DOLARES", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            kl1.Focus()
        End If
    End Sub
    Private Sub REPORTE_CONC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_CONC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑOS()
        cbo_año.Text = AÑO
        'cbo_mes.Text = MES
        CARGAR_BANCOS()
    End Sub
    Sub HALLANDO_TIPO_CAMBIO()
        Dim MES00, MES01, AÑO00 As String
        If obj.COD_MES(cbo_mes.Text) = "01" Then
            MES00 = "01"
            MES01 = "12"
            AÑO00 = cbo_año.Text - 1
        Else
            MES00 = obj.COD_MES(cbo_mes.Text)
            MES01 = (Integer.Parse(obj.COD_MES(cbo_mes.Text)) - 1).ToString("00")
            AÑO00 = cbo_año.Text
        End If
       
        Try
            Dim Prog002 As New SqlCommand("HALLAR_ULTIMO_DIA_MES", con2)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO00
            Prog002.Parameters.Add("@MES_ACTUAL", SqlDbType.Char).Value = MES00
            Prog002.Parameters.Add("@MES_ANTERIOR", SqlDbType.Char).Value = MES01
            con2.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                txt_tc_mes_actual.Text = Rs3.GetValue(2)
                txt_tc_mes_anterior.Text = Rs3.GetValue(3)
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub

    Sub SALDOS()
        Dim mes0 As String = (Integer.Parse(obj.COD_MES(cbo_mes.Text)) - 1).ToString("00")
        Dim mes00 As String = ""
        Dim año00 As String = ""
        If (mes0 = "00") Then
            mes00 = "12"
            año00 = cbo_año.Text - 1
        Else
            mes00 = mes0
            año00 = cbo_año.Text
        End If
        DEBE = New Decimal
        HABER = New Decimal
        Try
            Dim Prog002 As New SqlCommand("HALLAR_SALDOS_BANCOS_CONTABLES", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            Prog002.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año00
            Prog002.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes00
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DEBE = Decimal.Parse(Rs3.GetValue(0))
                HABER = Decimal.Parse(Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        SALDO = Decimal.Subtract(DEBE, HABER)
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        cbo_mes.Select()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        If cbo_mes.SelectedIndex <> -1 And cbo_año.Text <> "" Then
            HALLANDO_TIPO_CAMBIO()
        End If
    End Sub
    Private Sub txt_tc_mes_anterior_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tc_mes_anterior.KeyPress
        e.Handled = Numero(e, txt_tc_mes_anterior)
    End Sub
    Function Numero(ByVal e As KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.]" Then
            Return True
        End If
        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Private Sub txt_tc_mes_anterior_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tc_mes_anterior.LostFocus
        If (txt_tc_mes_anterior.Text <> "") Then
            Try
                txt_tc_mes_anterior.Text = (obj.HACER_CAMBIO(txt_tc_mes_anterior.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Venta no es valido", "Ingrese otra vez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_tc_mes_anterior.Text = "0.0000"
            End Try
        End If
    End Sub
    Private Sub txt_tc_mes_actual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tc_mes_actual.KeyPress
        e.Handled = Numero(e, txt_tc_mes_actual)
    End Sub
    Private Sub txt_tc_mes_actual_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tc_mes_actual.LostFocus
        If (txt_tc_mes_actual.Text <> "") Then
            Try
                txt_tc_mes_actual.Text = (obj.HACER_CAMBIO(txt_tc_mes_actual.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Venta no es valido", "Ingrese otra vez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_tc_mes_actual.Text = "0.0000"
            End Try
        End If
    End Sub

    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged

    End Sub
End Class