Imports System.Data.SqlClient
Public Class REPORTE_CXC1
    Dim STATUS_DOC02, STATUS_SUC3, STATUS_SUC2, STATUS_SUC1, STATUS_SUC02, STATUS_PER3, STATUS_DOC1, STATUS_DOC2, STATUS_DOC3, STATUS_PER1, STATUS_PER2, COD_PER2, COD_PER3, COD_SUCURSAL02, COD_SUCURSAL1, COD_SUCURSAL2, COD_SUCURSAL3, COD_PER1, COD_CLASE02, COD_DOC3, COD_DOC2, COD_DOC1, COD_CLASE1, COD_CLASE2, COD_CLASE3, COD_DOC02 As String
    Dim OBJ As New Class1
    Dim ofr1 As New REP_CXC_PTE1
    Dim ofr2 As New REP_CXC_PTE2
    Dim ofr3 As New REP_CXC_PTE3
    Dim ofr4 As New REP_CXC_PTE4
    Private Sub btn_pantalla02_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla02.Click
        If ch_suc02.Checked And cbo_suc02.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_suc02.Focus() : Exit Sub
        If ch_doc02.Checked And cbo_tipo_doc02.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc02.Focus() : Exit Sub
        If (DateTime.Compare(dtp_02.Value.Date, dtp_doc022.Value.Date) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub
        If ch_suc02.Checked Then
            STATUS_SUC02 = "0"
            COD_SUCURSAL02 = cbo_suc02.SelectedValue.ToString
        Else
            STATUS_SUC02 = "1"
            COD_SUCURSAL02 = "  "
        End If
        If ch_doc02.Checked Then
            STATUS_DOC02 = "0"
            COD_DOC02 = OBJ.COD_DOC(cbo_tipo_doc02.Text)
        Else
            STATUS_DOC02 = "1"
            COD_DOC02 = "  "
        End If
        ofr2.CREAR_REPORTE(COD_SUCURSAL02, STATUS_SUC02, dtp_02.Value, dtp_doc022.Value, "1", "", STATUS_DOC02, COD_DOC02, "1", "")
        ofr2.ShowDialog()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If ch_si1.Checked And CBO_SUCURSAL1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_SUCURSAL1.Focus() : Exit Sub
        If ch_per1.Checked And Trim(TXT_COD1.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : TXT_COD1.Focus() : Exit Sub
        If CH_DOC1.Checked And cbo_tipo_doc1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc1.Focus() : Exit Sub
        'If (DateTime.Compare(dtp01.Value.Date, dtp02.Value.Date) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub
        If ch_si1.Checked Then
            STATUS_SUC1 = "0"
            COD_SUCURSAL1 = CBO_SUCURSAL1.SelectedValue.ToString
        Else
            STATUS_SUC1 = "1"
            COD_SUCURSAL1 = "  "
        End If
        If ch_per1.Checked Then
            STATUS_PER1 = "0"
            COD_PER1 = TXT_COD1.Text
        Else
            STATUS_PER1 = "1"
            COD_PER1 = "  "
        End If
        If CH_DOC1.Checked Then
            STATUS_DOC1 = "0"
            COD_DOC1 = OBJ.COD_DOC(cbo_tipo_doc1.Text)
        Else
            STATUS_DOC1 = "1"
            COD_DOC1 = "  "
        End If
        'ofr1.CREAR_REPORTE(COD_SUCURSAL1, STATUS_SUC1, Now.Date, dtp02.Value.Date, STATUS_PER1, COD_PER1, STATUS_DOC1, COD_DOC1, "1", "", Now.Date, "", "CONTABLE")
        ofr1.ShowDialog()
    End Sub
    Private Sub btn_pantalla2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla2.Click
        If ch_si2.Checked And cbo_sucursal2.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_sucursal2.Focus() : Exit Sub
        If ch_per2.Checked And Trim(txt_cod2.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod2.Focus() : Exit Sub
        If CH_DOC2.Checked And cbo_tipo_doc2.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc2.Focus() : Exit Sub
        If (DateTime.Compare(dtp03.Value.Date, dtp04.Value.Date) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub
        If ch_si2.Checked Then
            STATUS_SUC2 = "0"
            COD_SUCURSAL2 = cbo_sucursal2.SelectedValue.ToString
        Else
            STATUS_SUC2 = "1"
            COD_SUCURSAL2 = "  "
        End If
        If ch_per2.Checked Then
            STATUS_PER2 = "0"
            COD_PER2 = txt_cod2.Text
        Else
            STATUS_PER2 = "1"
            COD_PER2 = "  "
        End If
        If CH_DOC2.Checked Then
            STATUS_DOC2 = "0"
            COD_DOC2 = OBJ.COD_DOC(cbo_tipo_doc2.Text)
        Else
            STATUS_DOC2 = "1"
            COD_DOC2 = "  "
        End If
        ofr3.CREAR_REPORTE(COD_SUCURSAL2, STATUS_SUC2, dtp03.Value, dtp04.Value, STATUS_PER2, COD_PER2, STATUS_DOC2, COD_DOC2, "1", "")
        ofr3.ShowDialog()
    End Sub
    Private Sub btn_pantalla3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla3.Click
        Try
            txt_dia.Text = (Integer.Parse(txt_dia.Text))
        Catch ex As Exception
            txt_dia.Text = (0)
        End Try
        If ch_suc3.Checked And cbo_sucursal3.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_sucursal3.Focus() : Exit Sub
        If ch_per3.Checked And Trim(txt_cod3.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod3.Focus() : Exit Sub
        If ch_doc3.Checked And cbo_tipo_doc3.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc3.Focus() : Exit Sub
        If (Integer.Parse(txt_dia.Text) <= 0) Then MessageBox.Show("Debe ingresar el Número de Días", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_dia.Focus() : Exit Sub
        If (DateTime.Compare(dtp05.Value.Date, dtp06.Value.Date) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub

        If ch_suc3.Checked Then
            STATUS_SUC3 = "0"
            COD_SUCURSAL3 = cbo_sucursal3.SelectedValue.ToString
        Else
            STATUS_SUC3 = "1"
            COD_SUCURSAL3 = "  "
        End If

        If ch_per3.Checked Then
            STATUS_PER3 = "0"
            COD_PER3 = txt_cod3.Text
        Else
            STATUS_PER3 = "1"
            COD_PER3 = "  "
        End If

        If ch_doc3.Checked Then
            STATUS_DOC3 = "0"
            COD_DOC3 = OBJ.COD_DOC(cbo_tipo_doc3.Text)
        Else
            STATUS_DOC3 = "1"
            COD_DOC3 = "  "
        End If
        Dim BLOQUE As Integer = 0
        BLOQUE = DateDiff("d", dtp05.Value.Date, dtp06.Value.Date)
        BLOQUE = CInt(Math.Round(CDbl((CDbl(BLOQUE) / Decimal.Parse(txt_dia.Text)))))
        ofr4.CREAR_REPORTE(dtp05.Value.ToString.Substring(0, 10), dtp06.Value.ToString.Substring(0, 10))
        ofr4.parametros(COD_SUCURSAL3, COD_PER3, STATUS_SUC3, STATUS_PER3, dtp05.Value, dtp06.Value.Date, STATUS_DOC3, COD_DOC3, Integer.Parse(txt_dia.Text), BLOQUE, dtp05.Value.Date.AddDays(-1), "1", "")
        ofr4.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click, btn_salir02.Click, btn_salir2.Click, Button2.Click
        main(20) = 0
        Close()
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XCOBRAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            dgw_per1.DataSource = DT
            dgw_per1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per1.Columns.Item(0).Width = &H37
            dgw_per1.Columns.Item(1).Width = 240
            dgw_per2.DataSource = DT
            dgw_per2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per2.Columns.Item(0).Width = &H37
            dgw_per2.Columns.Item(1).Width = 240
            dgw_per3.DataSource = DT
            dgw_per3.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per3.Columns.Item(0).Width = &H37
            dgw_per3.Columns.Item(1).Width = 240
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SUCURSAL()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_SUCURSAL
        CBO_SUCURSAL1.DataSource = DT
        CBO_SUCURSAL1.DisplayMember = DT.Columns.Item(0).ToString
        CBO_SUCURSAL1.ValueMember = DT.Columns.Item(1).ToString
        CBO_SUCURSAL1.SelectedIndex = -1
        cbo_sucursal2.DataSource = DT
        cbo_sucursal2.DisplayMember = DT.Columns.Item(0).ToString
        cbo_sucursal2.ValueMember = DT.Columns.Item(1).ToString
        cbo_sucursal2.SelectedIndex = -1
        cbo_sucursal3.DataSource = DT
        cbo_sucursal3.DisplayMember = DT.Columns.Item(0).ToString
        cbo_sucursal3.ValueMember = DT.Columns.Item(1).ToString
        cbo_sucursal3.SelectedIndex = -1
        cbo_suc02.DataSource = DT
        cbo_suc02.DisplayMember = DT.Columns.Item(0).ToString
        cbo_suc02.ValueMember = DT.Columns.Item(1).ToString
        cbo_suc02.SelectedIndex = -1
    End Sub
    Private Sub ch_doc02_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc02.CheckedChanged
        If ch_doc02.Checked Then
            cbo_tipo_doc02.Enabled = True
        Else
            cbo_tipo_doc02.SelectedIndex = -1
            cbo_tipo_doc02.Enabled = False
        End If
    End Sub
    Private Sub CH_DOC1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_DOC1.CheckedChanged
        If CH_DOC1.Checked Then
            cbo_tipo_doc1.Enabled = True
        Else
            cbo_tipo_doc1.SelectedIndex = -1
            cbo_tipo_doc1.Enabled = False
        End If
    End Sub
    Private Sub CH_DOC2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_DOC2.CheckedChanged
        If CH_DOC2.Checked Then
            cbo_tipo_doc2.Enabled = True
        Else
            cbo_tipo_doc2.SelectedIndex = -1
            cbo_tipo_doc2.Enabled = False
        End If
    End Sub
    Private Sub ch_doc3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc3.CheckedChanged
        If ch_doc3.Checked Then
            cbo_tipo_doc3.Enabled = True
        Else
            cbo_tipo_doc3.SelectedIndex = -1
            cbo_tipo_doc3.Enabled = False
        End If
    End Sub
    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            TXT_COD1.Enabled = True
            TXT_DESC1.Enabled = True
            txt_doc_per1.Enabled = True
        Else
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            txt_doc_per1.Clear()
            TXT_COD1.Enabled = False
            TXT_DESC1.Enabled = False
            txt_doc_per1.Enabled = False
        End If
    End Sub
    Private Sub ch_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ch_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ch_per1.Checked Then
                ch_per1.Checked = False
            Else
                ch_per1.Checked = True
            End If
        End If
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked Then
            txt_cod2.Enabled = True
            txt_desc2.Enabled = True
            txt_doc_per2.Enabled = True
        Else
            txt_cod2.Clear()
            txt_desc2.Clear()
            txt_doc_per2.Clear()
            txt_cod2.Enabled = False
            txt_desc2.Enabled = False
            txt_doc_per2.Enabled = False
        End If
    End Sub
    Private Sub ch_per3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per3.CheckedChanged
        If ch_per3.Checked Then
            txt_cod3.Enabled = True
            txt_desc3.Enabled = True
            txt_doc_per3.Enabled = True
        Else
            txt_cod3.Clear()
            txt_desc3.Clear()
            txt_doc_per3.Clear()
            txt_cod3.Enabled = False
            txt_desc3.Enabled = False
            txt_doc_per3.Enabled = False
        End If
    End Sub
    Private Sub ch_si1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si1.CheckedChanged
        If ch_si1.Checked Then
            CBO_SUCURSAL1.Enabled = True
        Else
            CBO_SUCURSAL1.SelectedIndex = -1
            CBO_SUCURSAL1.Enabled = False
        End If
    End Sub
    Private Sub ch_si1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ch_si1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ch_si1.Checked Then
                ch_si1.Checked = False
            Else
                ch_si1.Checked = True
            End If
        End If
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub ch_suc02_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_suc02.CheckedChanged
        If ch_suc02.Checked Then
            cbo_suc02.Enabled = True
        Else
            cbo_suc02.SelectedIndex = -1
            cbo_suc02.Enabled = False
        End If
    End Sub
    Private Sub ch_suc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si2.CheckedChanged
        If ch_si2.Checked Then
            cbo_sucursal2.Enabled = True
        Else
            cbo_sucursal2.SelectedIndex = -1
            cbo_sucursal2.Enabled = False
        End If
    End Sub
    Private Sub ch_suc3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_suc3.CheckedChanged
        If ch_suc3.Checked Then
            cbo_sucursal3.Enabled = True
        Else
            cbo_sucursal3.SelectedIndex = -1
            cbo_sucursal3.Enabled = False
        End If
    End Sub
    Private Sub dgw_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = dgw_per1.Item(0, dgw_per1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = dgw_per1.Item(1, dgw_per1.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = dgw_per1.Item(2, dgw_per1.CurrentRow.Index).Value.ToString
            Panel_PER1.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER1.Visible = False
            TXT_COD1.Focus()
        End If
    End Sub
    Private Sub dgw_per2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod2.Text = dgw_per2.Item(0, dgw_per2.CurrentRow.Index).Value.ToString
            txt_desc2.Text = dgw_per2.Item(1, dgw_per2.CurrentRow.Index).Value.ToString
            txt_doc_per2.Text = dgw_per2.Item(2, dgw_per2.CurrentRow.Index).Value.ToString
            Panel_per2.Visible = False
            k2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per2.Visible = False
            txt_cod2.Focus()
        End If
    End Sub
    Sub documentos()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_doc1.Items.Add(Rs3.GetString(0))
                cbo_tipo_doc2.Items.Add(Rs3.GetString(0))
                cbo_tipo_doc3.Items.Add(Rs3.GetString(0))
                cbo_tipo_doc02.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub REPORTE_PTE_GRAL_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub REPORTE_PTE_GRAL_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_PERSONAS()
        CARGAR_SUCURSAL()
        documentos()
        'dtp01.Value = FECHA_GRAL
        dtp02.Value = FECHA_GRAL
        ch_si1.Select()
    End Sub
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) <> "") Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (TXT_COD1.Text.ToLower = dgw_per1.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD1.Text = dgw_per1.Item(0, i).Value.ToString
                        TXT_DESC1.Text = dgw_per1.Item(1, i).Value.ToString
                        txt_doc_per1.Text = dgw_per1.Item(2, i).Value.ToString
                        cbo_tipo_doc1.Focus()
                        Return
                    End If
                    If (TXT_COD1.Text.ToLower = Strings.Mid((dgw_per1.Item(0, i).Value), 1, Strings.Len(TXT_COD1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod2.LostFocus
        If (Strings.Trim(txt_cod2.Text) <> "") Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod2.Text.ToLower = dgw_per2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod2.Text = dgw_per2.Item(0, i).Value.ToString
                        txt_desc2.Text = dgw_per2.Item(1, i).Value.ToString
                        txt_doc_per2.Text = dgw_per2.Item(2, i).Value.ToString
                        cbo_tipo_doc2.Focus()
                        Return
                    End If
                    If (txt_cod2.Text.ToLower = Strings.Mid((dgw_per2.Item(0, i).Value), 1, Strings.Len(txt_cod2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod3.LostFocus
        If (Strings.Trim(txt_cod3.Text) <> "") Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per3.Sort(dgw_per3.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod3.Text.ToLower = dgw_per3.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod3.Text = dgw_per3.Item(0, i).Value.ToString
                        txt_desc3.Text = dgw_per3.Item(1, i).Value.ToString
                        txt_doc_per3.Text = dgw_per3.Item(2, i).Value.ToString
                        cbo_tipo_doc3.Focus()
                        Return
                    End If
                    If (txt_cod3.Text.ToLower = Strings.Mid((dgw_per3.Item(0, i).Value), 1, Strings.Len(txt_cod3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_per3.Visible = True
                dgw_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC1.Text) <> "")) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (TXT_DESC1.Text.ToLower = Strings.Mid((dgw_per1.Item(1, i).Value), 1, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc2.Text) <> "")) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc2.Text.ToLower = Strings.Mid((dgw_per2.Item(1, i).Value), 1, Strings.Len(txt_desc2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc3.Text) <> "")) Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per3.Sort(dgw_per3.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc3.Text.ToLower = Strings.Mid((dgw_per3.Item(1, i).Value), 1, Strings.Len(txt_desc3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_per3.Visible = True
                dgw_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_dia_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_dia.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txt_dia_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_dia.LostFocus
        Try
            txt_dia.Text = (Integer.Parse(txt_dia.Text))
        Catch ex As Exception
            txt_dia.Text = (0)
        End Try
    End Sub
    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per1.Text.ToLower = Strings.Mid((dgw_per1.Item(2, i).Value), 1, Strings.Len(txt_doc_per1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per2.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per2.Sort(dgw_per2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per2.Text.ToLower = Strings.Mid((dgw_per2.Item(2, i).Value), 1, Strings.Len(txt_doc_per2.Text)).ToLower) Then
                        dgw_per2.CurrentCell = dgw_per2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per2.Visible = True
                dgw_per2.Visible = True
                dgw_per2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per3.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per3.Sort(dgw_per3.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per3.Text.ToLower = Strings.Mid((dgw_per3.Item(2, i).Value), 1, Strings.Len(txt_doc_per3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                panel_per3.Visible = True
                dgw_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub

   

   
End Class