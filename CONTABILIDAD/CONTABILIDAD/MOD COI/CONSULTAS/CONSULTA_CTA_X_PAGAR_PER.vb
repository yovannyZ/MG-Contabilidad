Imports System.Data.SqlClient
Public Class CONSULTA_CTA_X_PAGAR_PER
    Dim obj As New Class1
    Dim INDICE, INDICE2, INDICE3 As Integer
    Private ofr As New Dialog2
    Dim COD_MES3, COD_MES, DOC_PER03, SUCURSAL03, BOTON_CONTA, BOTON_ANA As String
    Private Sub CONSULTA_ANA_PENDIENT_COBRAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CONSULTA_ANA_PENDIENT_COBRAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        dgw3.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw4.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw_mov.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        CARGAR_AÑO()
        BOTON_CONTA = "0"
        BOTON_ANA = "0"
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año3.Items.Add(Rs3.GetString(0))
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTA3()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año3.Text)
            dgw_cta3.DataSource = (DT)
            dgw_cta3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta3.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir3.Click, Button9.Click
        main(44) = 0
        Close()
    End Sub
    Private Sub txt_cta3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta3.LostFocus
        If (Strings.Trim(txt_cta3.Text) <> "") Then
            If (dgw_cta3.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta3.Sort(dgw_cta3.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta3.RowCount - 1))
                    If (txt_cta3.Text.ToLower = dgw_cta3.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta3.Text = dgw_cta3.Item(0, i).Value.ToString
                        txt_desc_cta3.Text = dgw_cta3.Item(1, i).Value.ToString
                        btn_consulta3.Focus()
                        Return
                    End If
                    If (txt_cta3.Text.ToLower = Strings.Mid((dgw_cta3.Item(0, i).Value), 1, Strings.Len(txt_cta3.Text)).ToLower) Then
                        dgw_cta3.CurrentCell = (dgw_cta3.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta3.Visible = True
                dgw_cta3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta3.Text) <> "")) Then
            If (dgw_cta3.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta3.Sort(dgw_cta3.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta3.RowCount - 1))
                    If (txt_desc_cta3.Text.ToLower = Strings.Mid((dgw_cta3.Item(1, i).Value), 1, Strings.Len(txt_desc_cta3.Text)).ToLower) Then
                        dgw_cta3.CurrentCell = (dgw_cta3.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta3.Visible = True
                dgw_cta3.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta3.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta3.Text = dgw_cta3.Item(0, dgw_cta3.CurrentRow.Index).Value
            txt_desc_cta3.Text = dgw_cta3.Item(1, dgw_cta3.CurrentRow.Index).Value
            Panel_cta3.Visible = False
            TextBox3.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta3.Visible = False
            txt_cta3.Clear()
            txt_desc_cta3.Clear()
            txt_cta3.Focus()
        End If
    End Sub
    Private Sub btn_consulta3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta3.Click
        If txt_cta3.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta3.Focus() : Exit Sub
        COD_MES3 = obj.COD_MES(cbo_mes3.Text)
        'MOSTRAR_CONSULTA3()
        'G3.Enabled = False
        'BTN_MOD_GESTION.Focus()
        '---------------------------------------------------------------------------------
        If obj.VERIFICAR_CIERRE_PERIODO(cbo_año3.Text, obj.COD_MES(cbo_mes3.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw3.Rows.Clear()
            cbo_mes3.Focus()
            Exit Sub
        ElseIf obj.VERIFICAR_BLOKEO_PERIODO(cbo_año3.Text, obj.COD_MES(cbo_mes3.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw3.Rows.Clear()
            cbo_mes3.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA3()
            G3.Enabled = False
            BTN_MOD_GESTION.Focus()
        End If
    End Sub
    Sub MOSTRAR_CONSULTA3()
        dgw3.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_PAGAR_X_PERSONA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw3.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_MOD_GESTION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MOD_GESTION.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE3 = dgw3.CurrentRow.Index
        LIMPIAR_DET3()
        CARGAR_DET3()
        Panel4.Visible = True
        GroupBox5.Visible = True
        GroupBox1.Visible = False
        txt_im_doc.Focus()
    End Sub
    Sub LIMPIAR_DET3()
        btn_mod23.Enabled = True
        txt_nro_doc3.Clear()
        txt_im_inicial.Clear()
        txt_im_doc.Clear()
    End Sub
    Sub CARGAR_DET3()
        txt_nro_doc3.Text = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
        txt_im_inicial.Text = dgw3.Item(5, dgw3.CurrentRow.Index).Value.ToString
        txt_im_doc.Text = dgw3.Item(6, dgw3.CurrentRow.Index).Value.ToString
        '----------------------------------------------------------------
        DOC_PER03 = dgw3.Item(9, dgw3.CurrentRow.Index).Value.ToString
        SUCURSAL03 = dgw3.Item(8, dgw3.CurrentRow.Index).Value.ToString
    End Sub
    Private Sub BTN_LIMP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP3.Click
        txt_cta3.Clear()
        txt_desc_cta3.Clear()
        dgw3.Rows.Clear()
        dgw4.Rows.Clear()
        G3.Enabled = True
        txt_cta3.Focus()
    End Sub
    Private Sub cancel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancel3.Click
        Panel4.Visible = False
        BTN_MOD_GESTION.Focus()
    End Sub
    Private Sub btn_mod23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mod23.Click
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_PAGAR_CONSULTA_X_PERSONA", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = SUCURSAL03
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw3.Item(2, dgw3.CurrentRow.Index).Value.ToString
            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DOC_PER03
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            comand1.Parameters.Add("@IMP_INI", SqlDbType.Decimal).Value = txt_im_inicial.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_im_doc.Text
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        'dgw3.Item(7, dgw3.CurrentRow.Index).Value = cod_mon3
        dgw3.Item(5, dgw3.CurrentRow.Index).Value = txt_im_inicial.Text
        dgw3.Item(6, dgw3.CurrentRow.Index).Value = txt_im_doc.Text
        MOSTRAR_CONSULTA3()
        FOCO_NUEVO_REG3()
        Panel4.Visible = False
        BTN_MOD_GESTION.Focus()

    End Sub
    Sub FOCO_NUEVO_REG3()
        Dim I, CONT As Integer
        CONT = dgw3.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc3.Text
        For I = 0 To CONT
            If NRO_OC = dgw3.Item(1, I).Value.ToString.ToLower Then
                dgw3.CurrentCell = (dgw3.Rows.Item(I).Cells.Item(1))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub cbo_año3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_año3.SelectedIndexChanged
        CARGAR_CUENTA3()
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim NRO_DOC00 As String = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR: " & NRO_DOC00 & " " & dgw3.Item(3, dgw3.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_PAGAR_X_PER", con)
                CMD.CommandType = CommandType.StoredProcedure

                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw3.Item(8, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw3.Item(2, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw3.Item(0, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw3.Item(1, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw3.Item(9, dgw3.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA3()
            Panel4.Visible = False
            BTN_MOD_GESTION.Select()
        Else
        End If
        dgw4.Rows.Clear()
    End Sub
    Private Sub dgw3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw3.CellEnter
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        ''If (dgw4.RowCount = 0 Or con.State = ConnectionState.Open) Then
        If (con.State = ConnectionState.Open) Then
        Else
            HISTORIAL()
        End If
    End Sub
    Sub HISTORIAL()
        dgw4.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_PAGAR_X_PERSONA_DETALLE", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)

            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw3.Item(2, dgw3.CurrentRow.Index).Value.ToString
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw4.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), _
                Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), _
                Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), _
                Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), _
                Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), _
                Rs3.GetValue(24))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer = dgw4.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        INDICE3 = dgw4.CurrentRow.Index
        Button6.Enabled = True
        txt_im_doc_det.Clear()
        txt_nro_doc32.Clear()
        txt_nro_doc32.Text = dgw4.Item(2, dgw4.CurrentRow.Index).Value.ToString
        txt_im_doc_det.Text = dgw4.Item(8, dgw4.CurrentRow.Index).Value.ToString
        '----------------------------------------------------------------
        DOC_PER03 = dgw4.Item(7, dgw4.CurrentRow.Index).Value.ToString
        SUCURSAL03 = dgw4.Item(10, dgw4.CurrentRow.Index).Value.ToString
        '---------------------------------------------------------------
        Panel4.Visible = True
        GroupBox5.Visible = False
        GroupBox1.Visible = True
        txt_im_doc_det.Focus()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_PAGAR_CONSULTA_X_PERSONA2", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw4.Item(3, dgw4.CurrentRow.Index).Value.ToString
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw4.Item(4, dgw4.CurrentRow.Index).Value.ToString
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw4.Item(5, dgw4.CurrentRow.Index).Value.ToString
            comand1.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = SUCURSAL03
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DOC_PER03
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_im_doc_det.Text
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw4.Item(8, dgw4.CurrentRow.Index).Value = txt_im_doc_det.Text
        HISTORIAL()
        FOCO_NUEVO_REG4()
        Panel4.Visible = False
        BTN_MOD_GESTION.Focus()
    End Sub
    Sub FOCO_NUEVO_REG4()
        Dim I, CONT As Integer
        CONT = dgw4.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc32.Text
        For I = 0 To CONT
            If NRO_OC = dgw4.Item(2, I).Value.ToString.ToLower Then
                dgw4.CurrentCell = (dgw4.Rows.Item(I).Cells.Item(2))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim NRO_DOC00 As String = dgw4.Item(2, dgw4.CurrentRow.Index).Value.ToString
        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR COMPROBANTE: " & NRO_DOC00 & " " & dgw4.Item(6, dgw4.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_PAGAR_X_PER2", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw4.Item(10, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw4.Item(5, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw4.Item(3, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw4.Item(4, dgw4.CurrentRow.Index).Value
                'CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw4.Item(7, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
                'CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
                'CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes3.Text)
                CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw4.Item(0, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw4.Item(1, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw4.Item(2, dgw4.CurrentRow.Index).Value
                CMD.Parameters.Add("@INDICE", SqlDbType.VarChar).Value = dgw4.Item(24, dgw4.CurrentRow.Index).Value
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            Panel4.Visible = False
            BTN_MOD_GESTION.Select()
        Else
        End If
        HISTORIAL()
        'dgw4.Rows.Clear()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        VERIFICAR_IMPORTES()
    End Sub
    Sub INSERTAR()
        Try
            Dim CMD As New SqlCommand("MODIFICAR_PAGAR_CONSULTA_X_PERSONA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw3.Item(8, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw3.Item(2, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw3.Item(4, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            CMD.Parameters.Add("@IMP_INI", SqlDbType.Decimal).Value = dgw3.Item(5, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = dgw3.Item(6, dgw3.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            INSERTAR_DETALLES()
            MessageBox.Show("La Cta x Pagar se guardó ", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'TabControl1.SelectedTab = TabPage1
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        'DataGrid()
        'dgw1.CurrentCell = (dgw1.Rows.Item(INDICE).Cells.Item(1))
    End Sub
    Sub INSERTAR_DETALLES()
        'If BOT = "ANA" Then
        Dim I, CONT As Integer
        I = 0
        CONT = dgw4.Rows.Count - 1
        For I = 0 To CONT
            Dim GLOS As String = dgw4.Item(20, I).Value
            If GLOS <> "" Then GLOS = dgw4.Item(20, I).Value.ToString Else GLOS = ""


            Dim CMD As New SqlCommand("MODIFICAR_PAGAR_CONSULTA_X_PERSONA2", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw4.Item(3, I).Value.ToString
            CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw4.Item(4, I).Value.ToString
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw4.Item(5, I).Value.ToString
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw4.Item(23, I).Value.ToString
            CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw4.Item(11, I).Value.ToString
            CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta3.Text
            CMD.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = dgw4.Item(8, I).Value.ToString
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = dgw4.Item(21, I).Value.ToString
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = dgw4.Item(22, I).Value.ToString
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw4.Item(0, I).Value.ToString
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw4.Item(1, I).Value.ToString
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw4.Item(2, I).Value.ToString
            CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = dgw4.Item(9, I).Value.ToString
            CMD.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = dgw4.Item(12, I).Value.ToString
            CMD.Parameters.Add("@COD_REF", SqlDbType.Char).Value = dgw4.Item(16, I).Value
            CMD.Parameters.Add("@NRO_REF", SqlDbType.VarChar).Value = dgw4.Item(17, I).Value
            CMD.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = dgw4.Item(13, I).Value
            CMD.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = dgw4.Item(14, I).Value
            CMD.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = dgw4.Item(15, I).Value.ToString
            CMD.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = dgw4.Item(18, I).Value.ToString
            CMD.Parameters.Add("@TIPO_OPE", SqlDbType.Char).Value = dgw4.Item(19, I).Value.ToString
            CMD.Parameters.Add("@GLOSA", SqlDbType.VarChar).Value = GLOS
            CMD.Parameters.Add("@INDICE", SqlDbType.VarChar).Value = dgw4.Item(24, I).Value.ToString
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Sub VERIFICAR_IMPORTES()
        Dim IMP_TOTAL As Decimal
        If dgw3.Item(10, dgw3.CurrentRow.Index).Value = "D" Then
            IMP_TOTAL = dgw3.Item(6, dgw3.CurrentRow.Index).Value
        Else
            IMP_TOTAL = dgw3.Item(6, dgw3.CurrentRow.Index).Value * -1
        End If

        Dim I, CONT As Integer
        Dim SUM As Decimal
        CONT = dgw4.Rows.Count - 1
        SUM = 0
        For I = 0 To CONT
            If dgw4.Item(12, I).Value = "D" Then
                SUM = SUM + dgw4.Item(8, I).Value
            ElseIf dgw4.Item(12, I).Value = "H" Then
                SUM = SUM - dgw4.Item(8, I).Value
            Else
            End If
        Next
        If IMP_TOTAL <> obj.HACER_DECIMAL(SUM) Then
            MessageBox.Show(("No cuadra los detalles con el importe :  " & dgw3.Item(6, dgw3.CurrentRow.Index).Value), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            INSERTAR()
            HISTORIAL()
            'MessageBox.Show("La Cta x Cobrar se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
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
    Private Sub txt_im_inicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_im_inicial.KeyPress
        e.Handled = Numero(e, txt_im_inicial)
    End Sub
    Private Sub txt_im_inicial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_im_inicial.LostFocus
        If (txt_im_inicial.Text <> "") Then
            Try
                txt_im_inicial.Text = (obj.HACER_DECIMAL(txt_im_inicial.Text))
            Catch ex As Exception
                'MessageBox.Show("El tipo de Compra no es valido", "Ingrese otra vez")
                txt_im_inicial.Text = "0.00"
            End Try
        End If
    End Sub
    Private Sub txt_im_doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_im_doc.KeyPress
        e.Handled = Numero(e, txt_im_doc)
    End Sub
    Private Sub txt_im_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_im_doc.LostFocus
        If (txt_im_doc.Text <> "") Then
            Try
                txt_im_doc.Text = (obj.HACER_DECIMAL(txt_im_doc.Text))
            Catch ex As Exception
                txt_im_doc.Text = "0.00"
            End Try
        End If
    End Sub
    Private Sub txt_im_doc_det_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_im_doc_det.KeyPress
        e.Handled = Numero(e, txt_im_doc_det)
    End Sub
    Private Sub txt_im_doc_det_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_im_doc_det.LostFocus
        If (txt_im_doc_det.Text <> "") Then
            Try
                txt_im_doc_det.Text = (obj.HACER_DECIMAL(txt_im_doc_det.Text))
            Catch ex As Exception
                txt_im_doc_det.Text = "0.00"
            End Try
        End If
    End Sub
    Private Sub btn_oc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_oc.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        BOTON_ANA = "1"
        BOTON_CONTA = "0"
        ofr.COD_CTA = txt_cta3.Text
        ofr.NRO_DOC = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
        ofr.COD_DOC = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
        ofr.COD_PER = dgw3.Item(2, dgw3.CurrentRow.Index).Value.ToString
        ofr.TIPO = "P"
        ofr.TIPO_CARGA = "ANALISIS"
        ofr.ShowDialog()
        If (ofr.DialogResult = Windows.Forms.DialogResult.OK) Then
            INSERTAR_DE_DAILOG()
            ofr.Hide()
        End If
    End Sub
    Sub INSERTAR_DE_DAILOG()
        Dim num As Integer = (ofr.DGW_DET.Rows.Count - 1)
        Dim num3 As Integer = num
        Dim i As Integer = 0
        Do While (i <= num3)
            'Dim IGV_CERO As Boolean = True
            If (ofr.DGW_DET.Item(13, i).Value) = True Then
                If BOTON_CONTA = "1" Then
                    Dim suc_traida As String
                    suc_traida = obj.HALLAR_SUCURSAL(ofr.DGW_DET.Item(0, i).Value, ofr.DGW_DET.Item(1, i).Value)
                    dgw4.Rows.Add((ofr.DGW_DET.Item(0, i).Value), (ofr.DGW_DET.Item(1, i).Value), _
                    (ofr.DGW_DET.Item(2, i).Value), (ofr.DGW_DET.Item(3, i).Value), (ofr.DGW_DET.Item(4, i).Value), _
                    (ofr.DGW_DET.Item(5, i).Value), (ofr.DGW_DET.Item(6, i).Value), (ofr.DGW_DET.Item(7, i).Value), _
                    (ofr.DGW_DET.Item(8, i).Value), (ofr.DGW_DET.Item(9, i).Value), (ofr.DGW_DET.Item(10, i).Value), _
                    (ofr.DGW_DET.Item(11, i).Value), (ofr.DGW_DET.Item(12, i).Value), (ofr.DGW_DET.Item(14, i).Value), _
                    (ofr.DGW_DET.Item(15, i).Value), (ofr.DGW_DET.Item(16, i).Value), (ofr.DGW_DET.Item(17, i).Value), _
                    (ofr.DGW_DET.Item(18, i).Value), (ofr.DGW_DET.Item(19, i).Value), (ofr.DGW_DET.Item(20, i).Value), _
                    (ofr.DGW_DET.Item(21, i).Value), (ofr.DGW_DET.Item(22, i).Value), (ofr.DGW_DET.Item(23, i).Value), _
                    suc_traida, "")
                ElseIf BOTON_ANA = "1" Then
                    dgw4.Rows.Add((ofr.DGW_DET.Item(0, i).Value), (ofr.DGW_DET.Item(1, i).Value), _
                    (ofr.DGW_DET.Item(2, i).Value), (ofr.DGW_DET.Item(3, i).Value), (ofr.DGW_DET.Item(4, i).Value), _
                    (ofr.DGW_DET.Item(5, i).Value), (ofr.DGW_DET.Item(6, i).Value), (ofr.DGW_DET.Item(7, i).Value), _
                    (ofr.DGW_DET.Item(8, i).Value), (ofr.DGW_DET.Item(9, i).Value), (ofr.DGW_DET.Item(10, i).Value), _
                    (ofr.DGW_DET.Item(11, i).Value), (ofr.DGW_DET.Item(12, i).Value), (ofr.DGW_DET.Item(14, i).Value), _
                    (ofr.DGW_DET.Item(15, i).Value), (ofr.DGW_DET.Item(16, i).Value), (ofr.DGW_DET.Item(17, i).Value), _
                    (ofr.DGW_DET.Item(18, i).Value), (ofr.DGW_DET.Item(19, i).Value), (ofr.DGW_DET.Item(20, i).Value), _
                    (ofr.DGW_DET.Item(21, i).Value), (ofr.DGW_DET.Item(22, i).Value), (ofr.DGW_DET.Item(23, i).Value), _
                    ofr.DGW_DET.Item(10, i).Value, "")
                End If
            End If
            i += 1
        Loop
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim i As Integer = dgw3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        BOTON_CONTA = "1"
        BOTON_ANA = "0"
        ofr.COD_CTA = txt_cta3.Text
        ofr.NRO_DOC = dgw3.Item(1, dgw3.CurrentRow.Index).Value.ToString
        ofr.COD_DOC = dgw3.Item(0, dgw3.CurrentRow.Index).Value.ToString
        ofr.COD_PER = dgw3.Item(2, dgw3.CurrentRow.Index).Value.ToString
        ofr.TIPO = "P"
        ofr.TIPO_CARGA = "TCON"
        ofr.AÑO00 = cbo_año3.Text
        'ofr.CARGAR_DETALLES_TCON()
        ofr.ShowDialog()
        If (ofr.DialogResult = Windows.Forms.DialogResult.OK) Then
            INSERTAR_DE_DAILOG()
            ofr.Hide()
        End If
    End Sub

    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged
        CARGAR_CUENTA()
    End Sub
    Sub CARGAR_CUENTA()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año.Text)
            dgw_cta.DataSource = (DT)
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cta.LostFocus
        If (Strings.Trim(txt_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        btn_consulta.Focus()
                        Return
                    End If
                    If (txt_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta.CurrentCell = (dgw_cta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta.Text = dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value
            txt_desc_cta.Text = dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value
            Panel_cta.Visible = False
            TextBox4.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_cta.Clear()
            txt_desc_cta.Clear()
            txt_cta.Focus()
        End If
    End Sub
    Private Sub btn_consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta.Click
        If txt_cta.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub
        COD_MES = obj.COD_MES(cbo_mes.Text)
        'FALTA CREAR EL PROCEDIMIENTO
        'MOSTRAR_CONSULTA()
        'G1.Enabled = False
        'btn_eliminar.Focus()
        '---------------------------------------------------------------------------------
        If obj.VERIFICAR_CIERRE_PERIODO(cbo_año.Text, obj.COD_MES(cbo_mes.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_mov.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        ElseIf obj.VERIFICAR_BLOKEO_PERIODO(cbo_año.Text, obj.COD_MES(cbo_mes.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_mov.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA()
            G1.Enabled = False
            btn_eliminar.Focus()
        End If
    End Sub
    Sub MOSTRAR_CONSULTA()
        'FALTA CREAR EL PROCEDIMIENTO
        dgw_mov.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_PAGAR_X_PERSONA_MOV", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_mov.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_LIMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP.Click
        txt_cta.Clear()
        txt_desc_cta.Clear()
        dgw_mov.Rows.Clear()
        G1.Enabled = True
        txt_cta.Focus()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim NRO_DOC00 As String = dgw_mov.Item(1, dgw_mov.CurrentRow.Index).Value.ToString
        '-------------------------------------------------------------------------------
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR: " & NRO_DOC00 & " " & dgw_mov.Item(3, dgw_mov.CurrentRow.Index).Value), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_CONSULTA_PAGAR_X_PER_MOV", con)
                CMD.CommandType = CommandType.StoredProcedure

                CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = dgw_mov.Item(7, dgw_mov.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgw_mov.Item(2, dgw_mov.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgw_mov.Item(0, dgw_mov.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw_mov.Item(1, dgw_mov.CurrentRow.Index).Value
                CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = dgw_mov.Item(8, dgw_mov.CurrentRow.Index).Value
                CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta.Text
                'CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
                'CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES3
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            MOSTRAR_CONSULTA()
        Else
        End If
    End Sub

    Private Sub ch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch.CheckedChanged
        If ch.Checked = True Then
            txt_im_inicial.Enabled = True
        Else
            'txt_im_inicial.Clear()
            txt_im_inicial.Enabled = False
        End If
    End Sub

    Private Sub dgw3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw3.CellContentClick

    End Sub
End Class