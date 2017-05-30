Imports System.Data.SqlClient
Public Class CONSULTA_LETRAS_CXP
    Private COD_SUC1, STATUS_SUC4, STATUS_SUC3, STATUS_SUC2, STATUS_SUC1, COD_UBI4, COD_SUC2, COD_SUC3, COD_SUC4 As String
    Private fila1, fila2, fila3 As Integer
    Private OBJ As New Class1
   Private Sub btn_cadena1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena1.Click
        btn_sgt1.Enabled = True
        Dim num3 As Integer = (DGW_PER1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(DGW_PER1.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC1.Text.ToLower = Strings.Mid(DGW_PER1.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                    DGW_PER1.CurrentCell = DGW_PER1.Rows.Item(i).Cells.Item(1)
                    fila1 = (i + 1)
                    DGW_PER1.Focus()
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        DGW_PER1.Focus()
    End Sub
    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim num3 As Integer = (DGW_PER2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(DGW_PER2.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC2.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC2.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    DGW_PER2.Focus()
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        DGW_PER2.Focus()
    End Sub
    Private Sub btn_cadena3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena3.Click
        btn_sgt3.Enabled = True
        Dim num3 As Integer = (dgw_per3.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(dgw_per3.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC3.Text.ToLower = Strings.Mid(dgw_per3.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC3.Text)).ToLower) Then
                    dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(1)
                    fila3 = (i + 1)
                    dgw_per3.Focus()
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        dgw_per3.Focus()
    End Sub
    Private Sub BTN_CONSULTA1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA1.Click
        If (CH_SI1.Checked And (CBO_SUCURSAL1.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL1.Focus()
        ElseIf (TXT_COD1.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD1.Focus()
        ElseIf (DateTime.Compare(DTP_DOC1.Value, DTP_DOC12.Value) > 0) Then
            MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DTP_DOC1.Focus()
        ElseIf PANEL_PER1.Visible Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DGW_PER1.Focus()
        Else
            If CH_SI1.Checked = False Then
                STATUS_SUC1 = "1"
                COD_SUC1 = ""
            Else
                STATUS_SUC1 = "0"
                COD_SUC1 = CBO_SUCURSAL1.SelectedValue.ToString
            End If
            CARGAR_CONSULTA_PTE()
        End If
    End Sub
    Private Sub BTN_CONSULTA2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA2.Click
        If (CH_SI2.Checked And (CBO_SUCURSAL2.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL2.Focus()
        ElseIf (TXT_COD2.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD2.Focus()
        ElseIf (DateTime.Compare(DTP_DOC2.Value, DTP_DOC22.Value) > 0) Then
            MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DTP_DOC2.Focus()
        ElseIf PANEL_PER2.Visible Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DGW_PER2.Focus()
        Else
            If CH_SI2.Checked = False Then
                STATUS_SUC2 = "1"
                COD_SUC2 = ""
            Else
                STATUS_SUC2 = "0"
                COD_SUC2 = CBO_SUCURSAL2.SelectedValue.ToString
            End If
            CARGAR_CONSULTA_CANC()
        End If
    End Sub
    Private Sub BTN_CONSULTA4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA4.Click
        If (ch_si4.Checked And (CBO_SUCURSAL4.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL4.Focus()
        ElseIf (TXT_COD4.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD4.Focus()
        ElseIf (DateTime.Compare(DTP_DOC4.Value, DTP_DOC42.Value) > 0) Then
            MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DTP_DOC4.Focus()
        ElseIf PANEL_PER4.Visible Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            DGW_PER4.Focus()
        Else
            If ch_si4.Checked = False Then
                STATUS_SUC4 = "1"
                COD_SUC4 = ""
            Else
                STATUS_SUC4 = "0"
                COD_SUC4 = CBO_SUCURSAL4.SelectedValue.ToString
            End If
            CARGAR_MOD_UBICACION_NRO_BANCO()
        End If
    End Sub
    Private Sub btn_consultar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consultar3.Click
        If (ch_si3.Checked And (CBO_SUCURSAL3.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL3.Focus()
        ElseIf (TXT_COD3.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD3.Focus()
        ElseIf (DateTime.Compare(dtp_doc3.Value, dtp_doc32.Value) > 0) Then
            MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            dtp_doc3.Focus()
        ElseIf Panel_PER3.Visible Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            dgw_per3.Focus()
        Else
            If ch_si3.Checked = False Then
                STATUS_SUC3 = "1"
                COD_SUC3 = ""
            Else
                STATUS_SUC3 = "0"
                COD_SUC3 = CBO_SUCURSAL3.SelectedValue.ToString
            End If
            CARGAR_MOD_ACEPTACION()
        End If
    End Sub
    Private Sub btn_sgt1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt1.Click
        Dim num3 As Integer = (DGW_PER1.RowCount - 1)
        Dim i As Integer = fila1
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(DGW_PER1.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC1.Text.ToLower = Strings.Mid(DGW_PER1.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                    DGW_PER1.CurrentCell = DGW_PER1.Rows.Item(i).Cells.Item(1)
                    fila1 = (i + 1)
                    DGW_PER1.Focus()
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen más registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        DGW_PER1.Focus()
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim num3 As Integer = (DGW_PER2.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(DGW_PER2.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC2.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC2.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    DGW_PER2.Focus()
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen más registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        DGW_PER2.Focus()
    End Sub
    Private Sub btn_sgt3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt3.Click
        Dim num3 As Integer = (dgw_per3.RowCount - 1)
        Dim i As Integer = fila3
        Do While (i <= num3)
            Dim num4 As Integer = Strings.Len(dgw_per3.Item(1, i).Value.ToString)
            Dim j As Integer = 1
            Do While (j <= num4)
                If (TXT_DESC3.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, j, Strings.Len(TXT_DESC3.Text)).ToLower) Then
                    dgw_per3.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(1)
                    fila3 = (i + 1)
                    dgw_per3.Focus()
                    Return
                End If
                j += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen más registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_per3.Focus()
    End Sub
    Sub BTN_UBICACION_NRO_BANCO()
        Dim num2 As Integer = 0
        Dim num As Integer = (DGW_DET4.Rows.Count - 1)
        Dim num3 As Integer = num
        num2 = 0
        Do While (num2 <= num3)
            If DGW_DET4.Item(4, num2).Value = True Then
                Try
                    Dim command As New SqlCommand("ACEPTAR_UBICACION_NRO_BANCO", con)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = DGW_DET4.Item(9, num2).Value.ToString
                    command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD4.Text
                    command.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_DET4.Item(0, num2).Value.ToString
                    command.Parameters.Add("@NRO_BANCO", SqlDbType.VarChar).Value = DGW_DET4.Item(5, num2).Value.ToString
                    command.Parameters.Add("@COD_UBI", SqlDbType.VarChar).Value = COD_UBI4
                    con.Open()
                    command.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
            num2 += 1
        Loop
    End Sub
    Sub CARGAR_CONSULTA_CANC()
        DGW_DET2.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_CONSULTA_CANC", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC2
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC2
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD2.Text
            command.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = DTP_DOC2.Value
            command.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = DTP_DOC22.Value
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW_DET2.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), reader.GetValue(13))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONSULTA_PTE()
        DGW_DET1.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_CONSULTA_PTES", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC1
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC1
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD1.Text
            command.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = DTP_DOC1.Value
            command.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = DTP_DOC12.Value
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW_DET1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), reader.GetValue(13))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_MOD_ACEPTACION()
        dgw_det3.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_PARA_ACEP", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC3
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC3
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD3.Text
            command.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = dtp_doc3.Value
            command.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = dtp_doc32.Value
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                dgw_det3.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_MOD_UBICACION_NRO_BANCO()
        DGW_DET4.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_PARA_UBI_BAN", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC4
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC4
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = TXT_COD4.Text
            command.Parameters.Add("@FECHA1", SqlDbType.DateTime).Value = DTP_DOC4.Value
            command.Parameters.Add("@FECHA2", SqlDbType.DateTime).Value = DTP_DOC42.Value
            command.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = cbo_banco.SelectedValue.ToString
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW_DET4.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim selectCommand As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim adapter As New SqlDataAdapter(selectCommand)
            Dim dataTable As New DataTable("PERSONAS")
            adapter.Fill(dataTable)
            DGW_PER1.DataSource = dataTable
            DGW_PER1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            DGW_PER1.Columns(0).Width = &H37
            DGW_PER1.Columns(1).Width = 240
            DGW_PER2.DataSource = dataTable
            DGW_PER2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            DGW_PER2.Columns(0).Width = &H37
            DGW_PER2.Columns(1).Width = 240
            dgw_per3.DataSource = dataTable
            dgw_per3.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per3.Columns(0).Width = &H37
            dgw_per3.Columns(1).Width = 240
            DGW_PER4.DataSource = dataTable
            DGW_PER4.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            DGW_PER4.Columns(0).Width = &H37
            DGW_PER4.Columns(1).Width = 240
        Catch ex As Exception
            Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
        End Try
    End Sub
    Sub CARGAR_SUCURSAL()
        Dim genericos As New Genericos
        Dim table As New DataTable
        table = genericos.CBO_SUCURSAL
        CBO_SUCURSAL1.DataSource = table
        CBO_SUCURSAL1.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL1.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL1.SelectedIndex = -1
        CBO_SUCURSAL2.DataSource = table
        CBO_SUCURSAL2.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL2.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL2.SelectedIndex = -1
        CBO_SUCURSAL3.DataSource = table
        CBO_SUCURSAL3.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL3.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL3.SelectedIndex = -1
        CBO_SUCURSAL4.DataSource = table
        CBO_SUCURSAL4.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL4.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL4.SelectedIndex = -1
    End Sub
    Private Sub CH_SI1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_SI1.CheckedChanged
        If CH_SI1.Checked Then
            CBO_SUCURSAL1.Enabled = True
        Else
            CBO_SUCURSAL1.SelectedIndex = -1
            CBO_SUCURSAL1.Enabled = False
        End If
    End Sub
    Private Sub CH_SI2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_SI2.CheckedChanged
        If CH_SI2.Checked Then
            CBO_SUCURSAL2.Enabled = True
        Else
            CBO_SUCURSAL2.SelectedIndex = -1
            CBO_SUCURSAL2.Enabled = False
        End If
    End Sub
    Private Sub ch_si3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si3.CheckedChanged
        If ch_si3.Checked Then
            CBO_SUCURSAL3.Enabled = True
        Else
            CBO_SUCURSAL3.SelectedIndex = -1
            CBO_SUCURSAL3.Enabled = False
        End If
    End Sub
    Private Sub ch_si4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_si4.CheckedChanged
        If ch_si4.Checked Then
            CBO_SUCURSAL4.Enabled = True
        Else
            CBO_SUCURSAL4.SelectedIndex = -1
            CBO_SUCURSAL4.Enabled = False
        End If
    End Sub
    Private Sub CONTROL_LETRAS_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(38) = (0)
    End Sub
    Private Sub CONTROL_LETRAS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
        If (e.KeyCode = Keys.F1) Then
            Try
                'Help.ShowHelp((manual & "letra.htm"), HelpNavigator.Topic)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al Cargar ayuda ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End If
    End Sub
    Private Sub CONTROL_LETRAS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_PERSONAS()
        CARGAR_SUCURSAL()
        CARGAR_BCO()
        DGW_DET1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_det3.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET4.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
    End Sub
    Sub CARGAR_BCO()
        Dim genericos As New Genericos
        Dim table As New DataTable
        table = genericos.CBO_BCO
        cbo_banco.DataSource = table
        cbo_banco.DisplayMember = table.Columns(0).ToString
        cbo_banco.ValueMember = table.Columns(1).ToString
        cbo_banco.SelectedIndex = -1
    End Sub
    Private Sub dgw_det3_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw_det3.CellClick
        If (dgw_det3.CurrentCellAddress.X = 4) Then
            If dgw_det3.Item(4, dgw_det3.CurrentRow.Index).Value = True Then
                dgw_det3.Item(4, dgw_det3.CurrentRow.Index).Value = False
            Else
                If (dgw_det3.Item(5, dgw_det3.CurrentRow.Index).Value.ToString <> "") Then
                    MessageBox.Show("La Letra elegida ya fue Aceptada", "Mensaje: Cambiar Fecha de Aceptación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                dgw_det3.Item(4, dgw_det3.CurrentRow.Index).Value = True
            End If
        End If
    End Sub
    Private Sub DGW_DET4_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW_DET4.CellClick
        If (DGW_DET4.CurrentCellAddress.X = 4) Then
            If DGW_DET4.Item(4, DGW_DET4.CurrentRow.Index).Value = True Then
                DGW_DET4.Item(4, DGW_DET4.CurrentRow.Index).Value = False
            Else
                If (DGW_DET4.Item(5, DGW_DET4.CurrentRow.Index).Value.ToString <> "") Then
                    MessageBox.Show("La Letra elegida ya tiene Nº de Banco", "Mensaje: Cambiar Nº Banco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If
                DGW_DET4.Item(4, DGW_DET4.CurrentRow.Index).Value = True
            End If
        End If
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per3.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD3.Text = dgw_per3.Item(0, dgw_per3.CurrentRow.Index).Value.ToString
            TXT_DESC3.Text = dgw_per3.Item(1, dgw_per3.CurrentRow.Index).Value.ToString
            txt_doc_per3.Text = dgw_per3.Item(2, dgw_per3.CurrentRow.Index).Value.ToString
            Panel_PER3.Visible = False
            kl3.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER3.Visible = False
            TXT_COD3.Focus()
            TXT_COD3.Clear()
            TXT_DESC3.Clear()
            txt_doc_per3.Clear()
        End If
    End Sub
    Private Sub dgw_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = DGW_PER1.Item(0, DGW_PER1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = DGW_PER1.Item(1, DGW_PER1.CurrentRow.Index).Value.ToString
            TXT_DOC_PER1.Text = DGW_PER1.Item(2, DGW_PER1.CurrentRow.Index).Value.ToString
            PANEL_PER1.Visible = False
            KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER3.Visible = False
            TXT_COD1.Focus()
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            TXT_DOC_PER1.Clear()
        End If
    End Sub
    Private Sub dgw_per2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER2.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD2.Text = DGW_PER2.Item(0, DGW_PER2.CurrentRow.Index).Value.ToString
            TXT_DESC2.Text = DGW_PER2.Item(1, DGW_PER2.CurrentRow.Index).Value.ToString
            TXT_DOC_PER2.Text = DGW_PER2.Item(2, DGW_PER2.CurrentRow.Index).Value.ToString
            PANEL_PER2.Visible = False
            KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER2.Visible = False
            TXT_COD2.Focus()
            TXT_COD2.Clear()
            TXT_DESC2.Clear()
            TXT_DOC_PER2.Clear()
        End If
    End Sub
    Private Sub dgw_per4_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER4.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD4.Text = DGW_PER4.Item(0, DGW_PER4.CurrentRow.Index).Value.ToString
            TXT_DESC4.Text = DGW_PER4.Item(1, DGW_PER4.CurrentRow.Index).Value.ToString
            TXT_DOC_PER4.Text = DGW_PER4.Item(2, DGW_PER4.CurrentRow.Index).Value.ToString
            PANEL_PER4.Visible = False
            KL4.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER4.Visible = False
            TXT_COD4.Focus()
            TXT_COD4.Clear()
            TXT_DESC4.Clear()
            TXT_DOC_PER4.Clear()
        End If
    End Sub
    Private Sub TXT_COD_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD3.LostFocus
        If (Strings.Trim(TXT_COD3.Text) <> "") Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per3.Sort(dgw_per3.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_COD3.Text.ToLower = dgw_per3.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD3.Text = dgw_per3.Item(0, i).Value.ToString
                        TXT_DESC3.Text = dgw_per3.Item(1, i).Value.ToString
                        txt_doc_per3.Text = dgw_per3.Item(2, i).Value.ToString
                        dtp_doc3.Focus()
                        Return
                    End If
                    If (TXT_COD3.Text.ToLower = Strings.Mid((dgw_per3.Item(0, i).Value), 1, Strings.Len(TXT_COD3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER3.Visible = True
                dgw_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) <> "") Then
            If (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_COD1.Text.ToLower = DGW_PER1.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD1.Text = DGW_PER1.Item(0, i).Value.ToString
                        TXT_DESC1.Text = DGW_PER1.Item(1, i).Value.ToString
                        TXT_DOC_PER1.Text = DGW_PER1.Item(2, i).Value.ToString
                        DTP_DOC1.Focus()
                        Return
                    End If
                    If (TXT_COD1.Text.ToLower = Strings.Mid((DGW_PER1.Item(0, i).Value), 1, Strings.Len(TXT_COD1.Text)).ToLower) Then
                        DGW_PER1.CurrentCell = DGW_PER1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER1.Visible = True
                DGW_PER1.Visible = True
                DGW_PER1.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_COD2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD2.LostFocus
        If (Strings.Trim(TXT_COD2.Text) <> "") Then
            If (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_COD2.Text.ToLower = DGW_PER2.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD2.Text = DGW_PER2.Item(0, i).Value.ToString
                        TXT_DESC2.Text = DGW_PER2.Item(1, i).Value.ToString
                        TXT_DOC_PER2.Text = DGW_PER2.Item(2, i).Value.ToString
                        DTP_DOC2.Focus()
                        Return
                    End If
                    If (TXT_COD2.Text.ToLower = Strings.Mid((DGW_PER2.Item(0, i).Value), 1, Strings.Len(TXT_COD2.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_COD4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD4.LostFocus
        If (Strings.Trim(TXT_COD4.Text) <> "") Then
            If (DGW_PER4.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER4.Sort(DGW_PER4.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER4.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_COD4.Text.ToLower = DGW_PER4.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD4.Text = DGW_PER4.Item(0, i).Value.ToString
                        TXT_DESC4.Text = DGW_PER4.Item(1, i).Value.ToString
                        TXT_DOC_PER4.Text = DGW_PER4.Item(2, i).Value.ToString
                        DTP_DOC4.Focus()
                        Return
                    End If
                    If (TXT_COD4.Text.ToLower = Strings.Mid((DGW_PER4.Item(0, i).Value), 1, Strings.Len(TXT_COD4.Text)).ToLower) Then
                        DGW_PER4.CurrentCell = DGW_PER4.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER4.Visible = True
                DGW_PER4.Visible = True
                DGW_PER4.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC3.Text) <> "")) Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per3.Sort(dgw_per3.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DESC3.Text.ToLower = Strings.Mid((dgw_per3.Item(1, i).Value), 1, Strings.Len(TXT_DESC3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER3.Visible = True
                dgw_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC1.Text) <> "")) Then
            If (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DESC1.Text.ToLower = Strings.Mid((DGW_PER1.Item(1, i).Value), 1, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                        DGW_PER1.CurrentCell = DGW_PER1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER1.Visible = True
                DGW_PER1.Visible = True
                DGW_PER1.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC2.Text) <> "")) Then
            If (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DESC2.Text.ToLower = Strings.Mid((DGW_PER2.Item(1, i).Value), 1, Strings.Len(TXT_DESC2.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC4_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC4.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC4.Text) <> "")) Then
            If (DGW_PER4.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER4.Sort(DGW_PER4.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER4.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DESC4.Text.ToLower = Strings.Mid((DGW_PER4.Item(1, i).Value), 1, Strings.Len(TXT_DESC4.Text)).ToLower) Then
                        DGW_PER4.CurrentCell = DGW_PER4.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER4.Visible = True
                DGW_PER4.Visible = True
                DGW_PER4.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per3.Text) <> "")) Then
            If (dgw_per3.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per3.Sort(dgw_per3.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (txt_doc_per3.Text.ToLower = Strings.Mid((dgw_per3.Item(2, i).Value), 1, Strings.Len(txt_doc_per3.Text)).ToLower) Then
                        dgw_per3.CurrentCell = dgw_per3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER3.Visible = True
                dgw_per3.Visible = True
                dgw_per3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DOC_PER1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DOC_PER1.Text) <> "")) Then
            If (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (dgw_per3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DOC_PER1.Text.ToLower = Strings.Mid((DGW_PER1.Item(2, i).Value), 1, Strings.Len(TXT_DOC_PER1.Text)).ToLower) Then
                        DGW_PER1.CurrentCell = DGW_PER1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER1.Visible = True
                DGW_PER1.Visible = True
                DGW_PER1.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DOC_PER2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DOC_PER2.Text) <> "")) Then
            If (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DOC_PER2.Text.ToLower = Strings.Mid((DGW_PER2.Item(2, i).Value), 1, Strings.Len(TXT_DOC_PER2.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per4_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DOC_PER4.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DOC_PER4.Text) <> "")) Then
            If (DGW_PER4.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER4.Sort(DGW_PER4.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER4.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DOC_PER4.Text.ToLower = Strings.Mid((DGW_PER4.Item(2, i).Value), 1, Strings.Len(TXT_DOC_PER4.Text)).ToLower) Then
                        DGW_PER4.CurrentCell = DGW_PER4.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER4.Visible = True
                DGW_PER4.Visible = True
                DGW_PER4.Focus()
            End If
        End If
    End Sub
End Class