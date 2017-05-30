Imports System.Data.SqlClient
Public Class REPORTE_REPARABLE
    Dim OBJ As New Class1
    Dim OFR As New REP_REPARABLE
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES.Focus() : Exit Sub
        If ch_cta.Checked And Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        Dim COD_CTA, ST_CTA As String
        Dim MES0 As String = OBJ.COD_MES(CBO_MES.Text)
        Dim MES2 As String = OBJ.COD_MES(CBO_MES2.Text)
        If ch_cta.Checked Then
            ST_CTA = "0"
            COD_CTA = txt_cod_cta0.Text
        Else
            ST_CTA = "1"
            COD_CTA = " "
        End If
        OFR.CREAR_REPORTE(MES0, CBO_MES.Text, MES2, CBO_MES2.Text, ST_CTA, COD_CTA)
        OFR.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(86) = 0
        Close()
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cta.CheckedChanged
        If ch_cta.Checked Then
            txt_cod_cta0.Enabled = True
            txt_desc_cta0.Enabled = True
        Else
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            txt_cod_cta0.Enabled = False
            txt_desc_cta0.Enabled = False
            PaneL_CTA.Visible = False
        End If
    End Sub
    Sub CUENTA_REPARABLE()
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_REPARABLES(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            PaneL_CTA.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            PaneL_CTA.Visible = False
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            txt_cod_cta0.Focus()
        End If
    End Sub
    Private Sub REPORTE_REPARABLE_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_REPARABLE_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CUENTA_REPARABLE()
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        CBO_MES.Focus()
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta0.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod_cta0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.TextChanged

    End Sub

    Private Sub dgw_cta_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cta.CellContentClick

    End Sub
End Class