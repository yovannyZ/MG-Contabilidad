Imports System.Data.SqlClient
Public Class REPORTE_CTA_CTACTE
    Dim OBJ As New Class1
    Dim OFR As New REP_CTA_CTA_CTE
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If Trim(txt_cta.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub
        If Trim(txt_cod_per.Text) = "" And CH_PER.Checked Then MessageBox.Show("Debe elegir una Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per.Focus() : Exit Sub
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        If CBO_MES2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES2.Focus() : Exit Sub
        If CBO_ORDEN.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
        If (Integer.Parse(CBO_MES.Text) > Integer.Parse(CBO_MES2.Text)) Then MessageBox.Show("Rango Incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        Dim COD_PER, STATUS_PER As String
        If CH_PER.Checked = False Then
            STATUS_PER = "1"
            COD_PER = " "
        Else
            STATUS_PER = "0"
            COD_PER = txt_cod_per.Text
        End If
        OFR.CREAR_REPORTE(txt_cta.Text, txt_desc_cta.Text, CBO_MES.Text, CBO_MES2.Text, CBO_ORDEN.Text, STATUS_PER, COD_PER)
        OFR.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(36) = 0
        Close()
    End Sub
    Sub CARGAR_CUENTA()
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CH_PER_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_PER.CheckedChanged
        If CH_PER.Checked Then
            txt_cod_per.Enabled = True
            txt_desc_per.Enabled = True
            txt_doc_per.Enabled = True
        Else
            txt_cod_per.Enabled = False
            txt_desc_per.Enabled = False
            txt_doc_per.Enabled = False
        End If
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value.ToString.Length <> 8) Then
                MessageBox.Show("El cuenta tiene que ser nivel 8", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                txt_cta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                Panel_cta.Visible = False
                KL1.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_cta.Clear()
            txt_desc_cta.Clear()
            txt_cta.Focus()
        End If
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per.Text = (dgw_per.Item(0, dgw_per.CurrentRow.Index).Value)
            txt_desc_per.Text = (dgw_per.Item(1, dgw_per.CurrentRow.Index).Value)
            txt_doc_per.Text = (dgw_per.Item(2, dgw_per.CurrentRow.Index).Value)
            Panel_per.Visible = False
            KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            Panel_per.Visible = False
            txt_cod_per.Focus()
        End If
    End Sub
    Sub PERSONAS()
        Try
            dgw_per.DataSource = OBJ.MOSTRAR_PERSONAS_TODAS
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub REPORTE_CTA_CTACTE_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub REPORTE_CTA_CTACTE_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_CUENTA()
        PERSONAS()
    End Sub
    Private Sub txt_cod_per_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per.LostFocus
        If (Strings.Trim(txt_cod_per.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_per.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        CBO_MES.Focus()
                        Return
                    End If
                    If (txt_cod_per.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta.LostFocus
        If (Strings.Trim(txt_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        txt_cod_per.Focus()
                        Return
                    End If
                    If (txt_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla pendientes por cobrar", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
End Class