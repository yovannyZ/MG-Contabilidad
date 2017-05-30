Imports System.Data.SqlClient
Public Class REPORTE_CTA_AUX
    Dim OBJ As New Class1
    Dim OFR As New REP_CTA_AUX
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        If CBO_MES2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES2.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir ula Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If CBO_ORDEN.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
        If txt_cod_cta0.Text.Length <> 8 Then
            MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
            Exit Sub
        End If

        Dim COD_AUX As String = OBJ.COD_AUX(cbo_aux.Text)
        Dim COD_CTA As String = txt_cod_cta0.Text
        Dim MES1 As String = CBO_MES.Text
        Dim MES2 As String = CBO_MES2.Text
        Dim ORDEN As String = CBO_ORDEN.Text
        OFR.CREAR_REPORTE(COD_AUX, COD_CTA, txt_desc_cta0.Text, MES1, MES2, ORDEN)
        OFR.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(16) = 0
        Close()
    End Sub
    Sub CBO_AUX00()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CUENTAS()
        Try
            Dim DT As New DataTable
            'DT = OBJ.MOSTRAR_CUENTAS_TODAS(AÑO)
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value).Length <> 8) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta0.Clear()
                txt_desc_cta0.Clear()
            Else
                txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                PaneL_CTA.Visible = False
                KL.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CBO_AUX00()
        CUENTAS()
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        'If (dgw_cta.Item(0, i).Value.ToString.Length <> 8) Then
                        '    MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '    txt_cod_cta0.Clear()
                        '    txt_desc_cta0.Clear()
                        '    txt_cod_cta0.Focus()
                        'Else
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        CBO_ORDEN.Focus()
                        'End If
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
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
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

    Private Sub txt_cod_cta0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.TextChanged

    End Sub

    Private Sub dgw_cta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cta.CellContentClick

    End Sub
End Class