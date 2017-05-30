Imports System.Data.SqlClient
Public Class CAMBIO_DE_CUENTA
    Dim AÑO0, MES0 As String
    Dim OBJ As New Class1
    Private Sub CAMBIO_DE_CUENTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CAMBIO_DE_CUENTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_AÑO()
        cbo_año3.Text = AÑO
        CUENTAS()
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CUENTAS()
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(AÑO)
            dgw_cta2.DataSource = DT
            dgw_cta2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta2.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        If (dgw_cta.Item(0, i).Value.ToString.Length <> 8) Then
                            MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_cta0.Clear()
                            txt_desc_cta0.Clear()
                            txt_cod_cta0.Focus()
                        Else
                            txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                            txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                            txt_cod_cta1.Focus()
                        End If
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
            End If
        End If
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value).Length <> 8) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta0.Clear()
                txt_desc_cta0.Clear()
            Else
                txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                PaneL_CTA.Visible = False
                txt1.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub
    Private Sub txt_cod_cta1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta1.LostFocus
        If (Strings.Trim(txt_cod_cta1.Text) <> "") Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta1.Text.ToLower = dgw_cta2.Item(0, i).Value.ToString.ToLower) Then
                        If (dgw_cta2.Item(0, i).Value.ToString.Length <> 8) Then
                            MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_cta1.Clear()
                            txt_desc_cta1.Clear()
                            txt_cod_cta1.Focus()
                        Else
                            txt_cod_cta1.Text = dgw_cta2.Item(0, i).Value.ToString
                            txt_desc_cta1.Text = dgw_cta2.Item(1, i).Value.ToString
                            btn_consulta1.Focus()
                        End If
                        Return
                    End If
                    If (txt_cod_cta1.Text.ToLower = Strings.Mid((dgw_cta2.Item(0, i).Value), 1, Strings.Len(txt_cod_cta1.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA2.Visible = True
                dgw_cta2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta1.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta1.Text.ToLower = Strings.Mid((dgw_cta2.Item(1, i).Value), 1, Strings.Len(txt_desc_cta1.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA2.Visible = True
            End If
        End If
    End Sub
    Private Sub dgw_cta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta2.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta2.Item(0, dgw_cta2.CurrentRow.Index).Value).Length <> 8) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta1.Clear()
                txt_desc_cta1.Clear()
            Else
                txt_cod_cta1.Text = (dgw_cta2.Item(0, dgw_cta2.CurrentRow.Index).Value)
                txt_desc_cta1.Text = (dgw_cta2.Item(1, dgw_cta2.CurrentRow.Index).Value)
                PaneL_CTA2.Visible = False
                TextBox1.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta1.Clear()
            txt_desc_cta1.Clear()
            PaneL_CTA2.Visible = False
            txt_cod_cta1.Focus()
        End If
    End Sub
    Private Sub btn_aceptar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar3.Click
        If txt_cod_cta0.Text.ToString = "" Then MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        Dim ESTADO As String = "FALLO"
        AÑO0 = cbo_año3.Text
        MES0 = (OBJ.COD_MES(cbo_mes3.Text))
        '-----------------------------------------------------------------------------------
        Dim I, CONT As Integer : CONT = dgw1.RowCount - 1
        For I = 0 To CONT
            If dgw1.Item(8, I).Value = True Then
                '-----------------------------------------------------------------------------------
                Try
                    Dim CMD As New SqlCommand("RECOVERY_CAMBIO_CUENTA2", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
                    CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES0
                    CMD.Parameters.Add("@COD_CUENTA1", SqlDbType.VarChar).Value = txt_cod_cta0.Text
                    CMD.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = txt_cod_cta1.Text
                    CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = dgw1.Item(24, I).Value
                    CMD.Parameters.Add("@COD_AUX ", SqlDbType.Char).Value = dgw1.Item(20, I).Value
                    CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(21, I).Value
                    CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(22, I).Value
                    con.Open()
                    ESTADO = CMD.ExecuteScalar
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    ESTADO = "FALLO"
                End Try
            End If
        Next
        If (ESTADO = "FALLO") Then
            MessageBox.Show("Ocurrió un error.", "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("El recovery se realizó.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        MOSTRAR_CONSULTA()
        CH_AUX.Checked = False
        btn_aceptar3.Enabled = False
    End Sub
    Private Sub btn_salir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir3.Click
        main(40) = 0
        Close()
    End Sub
    Private Sub btn_consulta1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta1.Click
        If cbo_año3.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año3.Focus() : Exit Sub
        If cbo_mes3.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes3.Focus() : Exit Sub
        If txt_cod_cta0.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If txt_cod_cta1.Text.ToString = "" Then MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta1.Focus() : Exit Sub
        '---------------------------------------------------------------------------------
        If OBJ.VERIFICAR_CIERRE_PERIODO(cbo_año3.Text, OBJ.COD_MES(cbo_mes3.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes3.Focus()
            Exit Sub
        ElseIf OBJ.VERIFICAR_BLOKEO_PERIODO(cbo_año3.Text, OBJ.COD_MES(cbo_mes3.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes3.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA()
        End If
        btn_aceptar3.Enabled = True
    End Sub
    Sub MOSTRAR_CONSULTA()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_CAMBIO_CUENTA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), False, Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), Rs3.GetValue(31), Rs3.GetValue(32))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CH_AUX_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH_AUX.CheckedChanged
        If CH_AUX.Checked = True Then
            Dim CONT, I As Integer
            CONT = dgw1.RowCount - 1
            For I = 0 To CONT
                dgw1.Item(8, I).Value = True
            Next
        Else
            Dim CONT, I As Integer
            CONT = dgw1.RowCount - 1
            For I = 0 To CONT
                dgw1.Item(8, I).Value = False
            Next
        End If
    End Sub

    Private Sub dgw_cta2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cta2.CellContentClick

    End Sub

    Private Sub txt_cod_cta1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cta1.TextChanged

    End Sub
End Class