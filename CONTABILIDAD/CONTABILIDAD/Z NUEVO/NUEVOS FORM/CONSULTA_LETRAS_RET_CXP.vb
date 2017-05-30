Imports System.Data.SqlClient
Public Class CONSULTA_LETRAS_RET_CXP
    Private OBJ As New Class1
    Private STATUS_SUC, COD_SUC, STATUS_PER, COD_PER, STATUS_CONF, AÑO00, MES00 As String

    Sub CARGAR_SUCURSAL()
        Dim genericos As New Genericos
        Dim table As New DataTable
        table = genericos.CBO_SUCURSAL
        CBO_SUCURSAL.DataSource = table
        CBO_SUCURSAL.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL.SelectedIndex = -1

        CBO_SUCURSAL1.DataSource = table
        CBO_SUCURSAL1.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL1.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL1.SelectedIndex = -1
    End Sub

    Sub CARGAR_PERSONAS()
        Try
            Dim selectCommand As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim adapter As New SqlDataAdapter(selectCommand)
            Dim dataTable As New DataTable("PERSONAS")
            adapter.Fill(dataTable)
            DGW_PER.DataSource = dataTable
            DGW_PER.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            DGW_PER.Columns(0).Width = &H37
            DGW_PER.Columns(1).Width = 240

            DGW_PER1.DataSource = dataTable
            DGW_PER1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            DGW_PER1.Columns(0).Width = &H37
            DGW_PER1.Columns(1).Width = 240
        Catch ex As Exception
            Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
        End Try
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
                Me.cbo_año1.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub CARGAR_LETRAS_RETENCION(ByVal dgw00 As DataGridView)
        dgw00.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_CONFIRMAR", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC
            command.Parameters.Add("@ST_PERSONA", SqlDbType.Char).Value = STATUS_PER
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO00
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES00
            command.Parameters.Add("@ST_CONFIRMADO", SqlDbType.Char).Value = STATUS_CONF
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                dgw00.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), _
                reader.GetValue(4), reader.GetValue(5), OBJ.HACER_DECIMAL(reader.GetValue(6)), OBJ.HACER_DECIMAL(reader.GetValue(7)), _
                reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), _
                reader.GetValue(13), reader.GetValue(14), reader.GetValue(15), reader.GetValue(16), reader.GetValue(17), _
                reader.GetValue(18), reader.GetValue(19))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CONSULTA_LETRAS_RET_CXP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CONSULTA_LETRAS_RET_CXP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_SUCURSAL()
        CARGAR_PERSONAS()
        CARGAR_AÑOS()
    End Sub

    Private Sub TXT_COD_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD.LostFocus
        If (Strings.Trim(TXT_COD.Text) <> "") Then
            If (DGW_PER.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_COD.Text.ToLower = DGW_PER.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD.Text = DGW_PER.Item(0, i).Value.ToString
                        TXT_DESC.Text = DGW_PER.Item(1, i).Value.ToString
                        TXT_DOC_PER.Text = DGW_PER.Item(2, i).Value.ToString
                        cbo_mes.Focus()
                        Return
                    End If
                    If (TXT_COD.Text.ToLower = Strings.Mid((DGW_PER.Item(0, i).Value), 1, Strings.Len(TXT_COD.Text)).ToLower) Then
                        DGW_PER.CurrentCell = DGW_PER.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER.Visible = True
                DGW_PER.Visible = True
                DGW_PER.Focus()
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
                        cbo_mes1.Focus()
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

    Private Sub TXT_DESC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC.Text) <> "")) Then
            If (DGW_PER.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DESC.Text.ToLower = Strings.Mid((DGW_PER.Item(1, i).Value), 1, Strings.Len(TXT_DESC.Text)).ToLower) Then
                        DGW_PER.CurrentCell = DGW_PER.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER.Visible = True
                DGW_PER.Visible = True
                DGW_PER.Focus()
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

    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DOC_PER.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DOC_PER.Text) <> "")) Then
            If (DGW_PER.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    If (TXT_DOC_PER.Text.ToLower = Strings.Mid((DGW_PER.Item(2, i).Value), 1, Strings.Len(TXT_DOC_PER.Text)).ToLower) Then
                        DGW_PER.CurrentCell = DGW_PER.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                PANEL_PER.Visible = True
                DGW_PER.Visible = True
                DGW_PER.Focus()
            End If
        End If
    End Sub

    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DOC_PER1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DOC_PER1.Text) <> "")) Then
            If (DGW_PER1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER1.Sort(DGW_PER1.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim num2 As Integer = (DGW_PER1.RowCount - 1)
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

    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD.Text = DGW_PER.Item(0, DGW_PER.CurrentRow.Index).Value.ToString
            TXT_DESC.Text = DGW_PER.Item(1, DGW_PER.CurrentRow.Index).Value.ToString
            TXT_DOC_PER.Text = DGW_PER.Item(2, DGW_PER.CurrentRow.Index).Value.ToString
            PANEL_PER.Visible = False
            cbo_mes.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER.Visible = False
            TXT_COD.Focus()
            TXT_COD.Clear()
            TXT_DESC.Clear()
            TXT_DOC_PER.Clear()
        End If
    End Sub

    Private Sub dgw_per1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = DGW_PER1.Item(0, DGW_PER1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = DGW_PER1.Item(1, DGW_PER1.CurrentRow.Index).Value.ToString
            TXT_DOC_PER1.Text = DGW_PER1.Item(2, DGW_PER1.CurrentRow.Index).Value.ToString
            PANEL_PER1.Visible = False
            cbo_mes1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PANEL_PER1.Visible = False
            TXT_COD1.Focus()
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            TXT_DOC_PER1.Clear()
        End If
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If (CH.Checked AndAlso (CBO_SUCURSAL.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL.Focus()
        ElseIf (chkProveedor.Checked AndAlso TXT_COD.TextLength = 0) Then
            MessageBox.Show("Debe seleccionar la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD.Focus()
        ElseIf cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Elija el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_mes.Focus()
        ElseIf cbo_año.SelectedIndex = -1 Then
            MessageBox.Show("Elija el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_año.Focus()
        Else
            If CH.Checked = False Then
                STATUS_SUC = "1"
                COD_SUC = ""
            Else
                STATUS_SUC = "0"
                COD_SUC = CBO_SUCURSAL.SelectedValue.ToString
            End If

            If chkProveedor.Checked = False Then
                STATUS_PER = "1"
                COD_PER = ""
            Else
                STATUS_PER = "0"
                COD_PER = TXT_COD.Text
            End If

            AÑO00 = cbo_año.Text
            MES00 = OBJ.COD_MES(cbo_mes.Text)

            If chkSinConfirmar.Checked Then STATUS_CONF = "1" Else STATUS_CONF = "0"

            CARGAR_LETRAS_RETENCION(DGW_DET)
        End If
    End Sub

    Private Sub btn_consultar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Consultar1.Click
        If (CH1.Checked And (CBO_SUCURSAL1.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL1.Focus()
        ElseIf (chkProveedor1.Checked AndAlso TXT_COD.TextLength = 0) Then
            MessageBox.Show("Debe seleccionar la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD1.Focus()
        ElseIf cbo_mes1.SelectedIndex = -1 Then
            MessageBox.Show("Elija el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_mes1.Focus()
        ElseIf cbo_año1.SelectedIndex = -1 Then
            MessageBox.Show("Elija el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_año1.Focus()
        Else
            If CH1.Checked = False Then
                STATUS_SUC = "1"
                COD_SUC = ""
            Else
                STATUS_SUC = "0"
                COD_SUC = CBO_SUCURSAL1.SelectedValue.ToString
            End If

            If chkProveedor1.Checked = False Then
                STATUS_PER = "1"
                COD_PER = ""
            Else
                STATUS_PER = "0"
                COD_PER = TXT_COD1.Text
            End If

            AÑO00 = cbo_año1.Text
            MES00 = OBJ.COD_MES(cbo_mes1.Text)

            STATUS_CONF = "0"
            CARGAR_LETRAS_RETENCION(DGW_DET1)
        End If
    End Sub

    Private Sub CH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH.CheckedChanged, chkProveedor.CheckedChanged
        If CH.Checked Then
            CBO_SUCURSAL.Enabled = True
        Else
            CBO_SUCURSAL.SelectedIndex = -1
            CBO_SUCURSAL.Enabled = False
        End If
    End Sub

    Private Sub CH1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH1.CheckedChanged
        If CH1.Checked Then
            CBO_SUCURSAL1.Enabled = True
        Else
            CBO_SUCURSAL1.SelectedIndex = -1
            CBO_SUCURSAL1.Enabled = False
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click, btn_salir1.Click
        main(41) = 0
        Close()
    End Sub

    Private Sub BTN_GRABAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_GRABAR.Click
        Dim i, cont As Integer
        cont = DGW_DET.Rows.Count - 1
        For i = 0 To cont
            If DGW_DET.Item(8, i).Value = True Then
                Try
                    Dim command As New SqlCommand("CONFIRMAR_LETRA", con)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = DGW_DET.Item(12, i).Value
                    command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = DGW_DET.Item(0, i).Value
                    command.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_DET.Item(3, i).Value
                    command.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DGW_DET.Item(2, i).Value
                    command.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = DGW_DET.Item(18, i).Value
                    command.Parameters.Add("@ST_CONFIRMAR", SqlDbType.Char).Value = IIf(chkSinConfirmar.Checked, 1, 0)
                    command.Parameters.Add("@FECHA_CONFIRMAR", SqlDbType.DateTime).Value = IIf(chkSinConfirmar.Checked, dtp1.Value.ToShortDateString, System.DBNull.Value)
                    con.Open()
                    command.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
        CARGAR_LETRAS_RETENCION(DGW_DET)
        MessageBox.Show("Registros actualizados", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub chkSinConfirmar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSinConfirmar.CheckedChanged
        DGW_DET.Rows.Clear()
    End Sub
End Class