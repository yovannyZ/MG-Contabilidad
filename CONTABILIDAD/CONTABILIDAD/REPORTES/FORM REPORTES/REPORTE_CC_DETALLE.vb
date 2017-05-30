Imports System.Data.SqlClient
Public Class REPORTE_CC_DETALLE
    Dim OBJ As New Class1
    Dim REP1 As New REP_CC_DETALLE1
    Dim REP2 As New REP_CC_DETALLE2
    Dim ST_CC, COD_CC, ST_CTA, COD_CTA, TITULO, ORD As String
    Private Sub REPORTE_CC_DETALLE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_CC_DETALLE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_CENTRO_COSTOS()
        CUENTAS()
    End Sub
    Sub CARGAR_CENTRO_COSTOS()
        cbo_cc.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AREA", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_cc.Items.Add(Rs3.GetString(0))
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
            DT = OBJ.MOSTRAR_CUENTAS_CC(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
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
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
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
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            PaneL_CTA.Visible = False
            Label2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(114) = 0
        Close()
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_cta.CheckedChanged
        If ch_cta.Checked = True Then
            txt_cod_cta0.Enabled = True
            txt_desc_cta0.Enabled = True
        Else
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            txt_cod_cta0.Enabled = False
            txt_desc_cta0.Enabled = False
        End If
    End Sub
    Private Sub ch_cc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_cc.CheckedChanged
        If ch_cc.Checked = True Then
            cbo_cc.Enabled = True
            ch_cta.Checked = False
        Else
            ch_cta.Checked = True
            cbo_cc.SelectedIndex = -1
            cbo_cc.Enabled = False
        End If
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        'If cbo_nivel.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_nivel.Focus() : Exit Sub
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_orden.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden.Focus() : Exit Sub
        If ch_cc.Checked = True And cbo_cc.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cc.Focus() : Exit Sub
        If ch_cta.Checked = True And txt_cod_cta0.Text = "" Then MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cc.Focus() : Exit Sub
        If cbo_cc.SelectedIndex = -1 And txt_cod_cta0.Text = "" Then MessageBox.Show("Debe elegir el Centro de Costos o la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cc.Focus() : Exit Sub

        If ch_cc.Checked = True Then
            ST_CC = "0"
            COD_CC = OBJ.COD_CC(cbo_cc.Text)
        Else
            ST_CC = "1"
            COD_CC = " "
        End If

        If ch_cta.Checked = False Then
            ST_CTA = "1"
            COD_CTA = " "
        Else
            ST_CTA = "0"
            COD_CTA = txt_cod_cta0.Text
        End If
        If ch_cc.Checked = True Then
            TITULO = " CENTRO DE COSTOS " & " " & cbo_cc.Text
        Else
            TITULO = " CUENTA " & " " & txt_cod_cta0.Text & " " & txt_desc_cta0.Text
        End If
        '-------------------------
        Select Case cbo_orden.SelectedIndex
            Case "0" : ORD = "0"
            Case "1" : ORD = "1"
            Case "2" : ORD = "2"
            Case "3" : ORD = "3"
            Case "4" : ORD = "4"
            Case "5" : ORD = "5"
        End Select
        '------------------------------
        Dim dig_nivel As String
        Select Case CBO_NIVEL.Text
            Case "1" : dig_nivel = "2"
            Case "2" : dig_nivel = "3"
            Case "5" : dig_nivel = "8"
        End Select
        If ch_cc.Checked = True Then
            REP1.CREAR_REPORTE(TITULO, COD_CTA, ST_CTA, COD_CC, ST_CC, AÑO, OBJ.COD_MES(cbo_mes1.Text), OBJ.COD_MES(cbo_mes2.Text), ORD)
            REP1.ShowDialog()
        Else
            REP2.CREAR_REPORTE(TITULO, COD_CTA, ST_CTA, COD_CC, ST_CC, AÑO, OBJ.COD_MES(cbo_mes1.Text), OBJ.COD_MES(cbo_mes2.Text), ORD)
            REP2.ShowDialog()
        End If
    End Sub

    Private Sub CBO_NIVEL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBO_NIVEL.SelectedIndexChanged

        'If CBO_NIVEL.SelectedIndex <> -1 Then
        '    'dgw_cta.Rows.Clear()
        '    txt_cod_cta0.Clear()
        '    txt_desc_cta0.Clear()
        '    txt_cod_cta0.Focus()
        '    CUENTAS()
        'End If

    End Sub
End Class