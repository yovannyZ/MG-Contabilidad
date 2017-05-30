Imports System.Data.SqlClient
Public Class CONSULTA_RETENCIONES
    Dim MES00 As String
    Dim fila2, fila3 As Integer
    Dim OBJ As New Class1
    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim num3 As Integer = (dgw_per.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(dgw_per.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC1.Text.ToLower = Strings.Mid(dgw_per.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(1))
                    fila2 = (i + 1)
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        dgw_per.Focus()
    End Sub
    Private Sub btn_consulta1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta1.Click
        If (Strings.Trim(TXT_COD1.Text) = "") Then
            MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD1.Focus()
        ElseIf Panel_PER.Visible Then
            MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_per.Focus()
        ElseIf (DateTime.Compare(dtp_p1.Value, dtp_p2.Value) > 0) Then
            MessageBox.Show("Rango de fechas incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            CARGAR_CONSULTA_PER()
        End If
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SALIR.Click, Button2.Click
        main(26) = (0)
        Close()
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim num3 As Integer = (dgw_per.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(dgw_per.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC1.Text.ToLower = Strings.Mid(dgw_per.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(1))
                    fila2 = (i + 1)
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen más registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_per.Focus()
    End Sub
    Private Sub BTN_CONSULTA3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA3.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir un ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (Strings.Trim(txt_nro.Text) = "") Then
            MessageBox.Show("Debe elegir el Nº de Orden de Compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro.Focus()
        ElseIf Panel_OC.Visible Then
            MessageBox.Show("Debe elegir el Nº de Orden de Compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DGW_RET.Focus()
        Else
            CARGAR_CONSULTA_MOV()
        End If
    End Sub
    Sub CARGAR_CONSULTA_MOV()
        dgw3.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_CONSULTA_RETENCION_DET2", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (txt_cod2.Text)
            command.Parameters.Add("@NRO_RET", SqlDbType.VarChar).Value = (txt_nro.Text)
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = (CBO_AÑO.Text)
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = (MES00)
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                dgw3.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONSULTA_PER()
        DGW1.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_CONSULTA_RETENCION", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (TXT_COD1.Text)
            command.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = (dtp_p1.Value.AddDays(-1))
            command.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = dtp_p2.Value
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        dgw11.Rows.Clear()
    End Sub
    Sub CARGAR_DET(ByVal NRO_RET001 As Object)
        dgw11.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_CONSULTA_RETENCION_DET", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (TXT_COD1.Text)
            command.Parameters.Add("@NRO_RET", SqlDbType.VarChar).Value = NRO_RET001
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                dgw11.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_RETENCIONES(ByVal MES10 As Object)
        Try
            Dim command As New SqlCommand("MOSTRAR_NRO_RETENCION_AÑO_MES", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = CBO_AÑO.Text
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES10
            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable("ORDENES")
            adapter.Fill(dataTable)
            DGW_RET.DataSource = (dataTable)
            DGW_RET.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            DGW_RET.Columns(0).Visible = False
            DGW_RET.Columns(1).Width = 160
            DGW_RET.Columns(3).Width = &H4B
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim command As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable("PERSONAS")
            adapter.Fill(dataTable)
            dgw_per.DataSource = (dataTable)
            dgw_per.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_per.Columns(0).Width = &H37
            dgw_per.Columns(1).Width = 240
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        Select Case cbo_mes.SelectedIndex
            Case 0
                MES00 = "01"
                Exit Select
            Case 1
                MES00 = "02"
                Exit Select
            Case 2
                MES00 = "03"
                Exit Select
            Case 3
                MES00 = "04"
                Exit Select
            Case 4
                MES00 = "05"
                Exit Select
            Case 5
                MES00 = "06"
                Exit Select
            Case 6
                MES00 = "07"
                Exit Select
            Case 7
                MES00 = "08"
                Exit Select
            Case 8
                MES00 = "09"
                Exit Select
            Case 9
                MES00 = "10"
                Exit Select
            Case 10
                MES00 = "11"
                Exit Select
            Case 11
                MES00 = "12"
                Exit Select
        End Select
        If (cbo_mes.SelectedIndex <> -1) Then
            CARGAR_RETENCIONES(MES00)
        End If
    End Sub
    Private Sub CONSULTA_OC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    'Sub CARGAR_AÑO()
    '    Try
    '        Dim command As New SqlCommand("CARGAR_AÑO", con)
    '        command.CommandType = CommandType.StoredProcedure
    '        command.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COM"
    '        con.Open()
    '        command.ExecuteNonQuery()
    '        Dim reader As SqlDataReader = command.ExecuteReader
    '        Do While reader.Read
    '            CBO_AÑO.Items.Add(reader.GetString(0))
    '        Loop
    '        con.Close()
    '    Catch ex As Exception
    '        con.Close()
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub CONSULTA_OC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        'CARGAR_AÑO()
        DGW1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw11.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_PERSONAS()
        CBO_AÑO.Text = AÑO
        cbo_mes.Text = OBJ.DESC_MES(MES)
        dtp_p1.Value = FECHA_GRAL
        dtp_p2.Value = FECHA_GRAL
    End Sub
    Private Sub DGW_OC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_RET.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod2.Text = DGW_RET.Item(0, DGW_RET.CurrentRow.Index).Value.ToString
            txt_desc2.Text = DGW_RET.Item(1, DGW_RET.CurrentRow.Index).Value.ToString
            txt_nro_doc2.Text = DGW_RET.Item(2, DGW_RET.CurrentRow.Index).Value.ToString
            txt_nro.Text = DGW_RET.Item(4, DGW_RET.CurrentRow.Index).Value.ToString
            Panel_OC.Visible = False
            k3.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_OC.Visible = False
            txt_nro.Focus()
        End If
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            Panel_PER.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER.Visible = False
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            txt_doc_per1.Clear()
            TXT_COD1.Focus()
        End If
    End Sub
    Private Sub DGW1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW1.CellEnter
        Try
            Dim num As Integer = DGW1.CurrentRow.Index
        Catch ex As Exception
            Exit Sub
        End Try
        If (con.State <> ConnectionState.Open) Then
            'Dim AÑO01 As String = DGW1.Item(8, DGW1.CurrentRow.Index).Value.ToString
            Dim NRO_RET01 As String = DGW1.Item(0, DGW1.CurrentRow.Index).Value.ToString
            'Dim MES01 As String = DGW1.Item(9, DGW1.CurrentRow.Index).Value.ToString
            CARGAR_DET(NRO_RET01)
        End If
    End Sub
    Private Sub TXT_COD_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_COD1.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD1.Text = dgw_per.Item(0, i).Value.ToString
                        TXT_DESC1.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per1.Text = dgw_per.Item(2, i).Value.ToString
                        dtp_p1.Focus()
                        Return
                    End If
                    If (TXT_COD1.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(TXT_COD1.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_PER.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (TXT_DESC1.Text.Trim <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DESC1.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_PER.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (txt_doc_per1.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per1.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_PER.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_nro_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_nro.LostFocus
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir elme de Proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (Strings.Trim(txt_nro.Text) = "") Then
            txt_cod2.Focus()
        ElseIf (DGW_RET.Rows.Count = 0) Then
            MessageBox.Show("No existen Ordenes de Compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            DGW_RET.Sort(DGW_RET.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
            Dim num2 As Integer = (DGW_RET.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (txt_nro.Text.ToLower = DGW_RET.Item(4, i).Value.ToString.ToLower) Then
                    txt_cod2.Text = DGW_RET.Item(0, i).Value.ToString
                    txt_desc2.Text = DGW_RET.Item(1, i).Value.ToString
                    txt_nro_doc2.Text = DGW_RET.Item(2, i).Value.ToString
                    txt_nro.Text = DGW_RET.Item(4, i).Value.ToString
                    BTN_CONSULTA3.Select()
                    Return
                End If
                If (txt_nro.Text.ToLower = Strings.Mid((DGW_RET.Item(4, i).Value), 1, Strings.Len(txt_nro.Text)).ToLower) Then
                    DGW_RET.CurrentCell = (DGW_RET.Rows.Item(i).Cells.Item(4))
                    Exit Do
                End If
                i += 1
            Loop
            Panel_OC.Visible = True
            DGW_RET.Visible = True
            DGW_RET.Focus()
        End If
    End Sub


    Private Sub DGW1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW1.CellContentClick

    End Sub
End Class