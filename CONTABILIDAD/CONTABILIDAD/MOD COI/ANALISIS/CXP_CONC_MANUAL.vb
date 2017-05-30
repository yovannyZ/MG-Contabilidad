Imports System.Data.SqlClient
Public Class CXP_CONC_MANUAL
    Dim COD_MONEDA, ST_MONEDA, MES00, DIA_FINAL As String
    Dim OBJ As New Class1
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If txt_cod_cuenta.Text = "" Then MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cuenta.Focus() : Exit Sub
        If cbo_moneda.SelectedIndex = -1 And ch_moneda.Checked Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda.Focus() : Exit Sub
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        MES00 = OBJ.COD_MES(cbo_mes1.Text)
        If OBJ.VERIFICAR_CIERRE_CUENTAS(txt_cod_cuenta.Text, AÑO, MES00) = False Then Exit Sub
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If OBJ.VERIFICAR_CIERRE_CUENTAS(txt_cod_cuenta.Text, AÑO, MES00) = False Then Exit Sub
        If (OBJ.ValidarCierreCuentas("CP", AÑO, OBJ.COD_MES(cbo_mes1.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If ch_moneda.Checked = False Then
            ST_MONEDA = "1"
            COD_MONEDA = ""
        Else
            ST_MONEDA = "0"
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
        End If
        MOSTRAR_ATCXP()
        g_com.Enabled = False
        '------------------------------------------------
        btn_grabar.Enabled = True
        btn_des.Enabled = True
        btn_cancelar.Enabled = True
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        LIMPIAR()
        MOSTRAR_ATCXP()
        btn_grabar.Enabled = False
        btn_des.Enabled = False
        btn_cancelar.Enabled = False
    End Sub
    Private Sub btn_des_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_des.Click
        If validacion_mes_destransferir() = True Then Exit Sub
        Dim i As Integer = 0
        Dim j As Integer = (DGW_IE.RowCount - 1)
        i = 0
        Do While (i <= j)
            If DGW_IE.Item(10, i).Value = True Then
                Dim cod_doc0 As String = DGW_IE.Item(0, i).Value
                Dim nro_doc0 As String = DGW_IE.Item(1, i).Value
                Dim cod_per0 As String = DGW_IE.Item(2, i).Value
                Dim nro_doc_per0 As String = DGW_IE.Item(4, i).Value
                Dim cod_aux0 As String = DGW_IE.Item(12, i).Value
                Dim cod_com0 As String = DGW_IE.Item(13, i).Value
                Dim nro_com0 As String = DGW_IE.Item(14, i).Value
                DESTRANSFERIR(cod_aux0, cod_com0, nro_com0, cod_doc0, nro_doc0, cod_per0, nro_doc_per0)
            End If
            i += 1
        Loop
        MessageBox.Show("Des-Transferencia", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        MOSTRAR_ATCXP()
    End Sub
    Function validacion_mes_destransferir() As Boolean
        Dim i, cont As Integer
        cont = DGW_IE.Rows.Count - 1
        For i = 0 To cont
            If DGW_IE.Item(10, i).Value = True Then
                If OBJ.COD_MES(cbo_mes1.Text) <> DGW_IE.Item(16, i).Value Then
                    MessageBox.Show("No se realizo la Des-Transferencia : debe coincidir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                   Return True
                End If
            End If
        Next
    End Function
    Sub limpiar_check()
        Dim i, cont As Integer
        cont = DGW_IE.Rows.Count - 1
        For i = 0 To cont
            DGW_IE.Item(10, i).Value = False
        Next
    End Sub
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar.Click
        HALLAR_MONTO()
        HALLANDO_ULTIMO_DIA()
        If (ch_des.Checked = False AndAlso (Decimal.Compare(Decimal.Parse(txt_saldo.Text), Decimal.Zero) <> 0)) Then
            MessageBox.Show("El Saldo debe ser 0.00", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_IE.RowCount - 1)

            I = 0
            Do While (I <= CONT)
                If DGW_IE.Item(9, I).Value = True Then
                    Dim cod_doc0 As String = DGW_IE.Item(0, I).Value
                    Dim nro_doc0 As String = DGW_IE.Item(1, I).Value
                    Dim cod_per0 As String = DGW_IE.Item(2, I).Value
                    Dim nro_doc_per0 As String = DGW_IE.Item(4, I).Value
                    Dim cod_aux0 As String = DGW_IE.Item(12, I).Value
                    Dim cod_com0 As String = DGW_IE.Item(13, I).Value
                    Dim nro_com0 As String = DGW_IE.Item(14, I).Value
                    Dim ITEM0 As String = DGW_IE.Item(17, I).Value
                    CONCILIAR(cod_aux0, cod_com0, nro_com0, cod_doc0, nro_doc0, cod_per0, nro_doc_per0, ITEM0)
                End If
                I += 1
            Loop
            MessageBox.Show("Documentos Conciliados", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_GRABAR()
            MOSTRAR_ATCXP()
        End If
    End Sub
    Sub HALLANDO_ULTIMO_DIA()
        Try
            Dim Prog002 As New SqlCommand("HALLAR_ULTIMO_DIA_MES", con2)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Prog002.Parameters.Add("@MES_ACTUAL", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes1.Text)
            Prog002.Parameters.Add("@MES_ANTERIOR", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes1.Text)
            con2.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DIA_FINAL = (Rs3.GetValue(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(33) = 0
        Close()
    End Sub
    Private Sub cbo_moneda_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cbo_moneda.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (cbo_moneda.SelectedIndex = -1) Then
                cbo_moneda.Focus()
            Else
                btn_aceptar.Focus()
            End If
        End If
    End Sub
    Sub CBO_MONEDA00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT
        cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
    End Sub
    Private Sub ch_moneda_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_moneda.CheckedChanged
        If ch_moneda.Checked Then
            cbo_moneda.Enabled = True
        Else
            cbo_moneda.SelectedIndex = -1
            cbo_moneda.Enabled = False
        End If
    End Sub
    Sub CONCILIAR(ByVal cod_aux1 As Object, ByVal cod_com1 As Object, ByVal nro_com1 As Object, ByVal cod_doc1 As Object, ByVal nro_doc1 As Object, ByVal cod_per1 As Object, ByVal nro_doc_per1 As Object, ByVal ITEM0 As Object)
        Try
            Dim cmd As New SqlCommand("CONCILIAR_DOC_A_TCXP", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = cod_aux1
            cmd.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = cod_com1
            cmd.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = nro_com1
            cmd.Parameters.Add("@cod_doc", SqlDbType.VarChar).Value = cod_doc1
            cmd.Parameters.Add("@nro_doc", SqlDbType.VarChar).Value = nro_doc1
            cmd.Parameters.Add("@cod_per", SqlDbType.VarChar).Value = cod_per1
            cmd.Parameters.Add("@nro_doc_per", SqlDbType.VarChar).Value = nro_doc_per1
            cmd.Parameters.Add("@COD_cuenta", SqlDbType.VarChar).Value = txt_cod_cuenta.Text
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES00
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Date.Parse(DIA_FINAL & "/" & MES00 & "/" & AÑO)
            cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = ITEM0
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            MessageBox.Show("Vuelva a Intentarlo", "Ocurrió un Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Sub DESTRANSFERIR(ByVal cod_aux1 As Object, ByVal cod_com1 As Object, ByVal nro_com1 As Object, ByVal cod_doc1 As Object, ByVal nro_doc1 As Object, ByVal cod_per1 As Object, ByVal nro_doc_per1 As Object)
        Try
            Dim cmd As New SqlCommand("DESTRANSFERIR_DOC_A_TCXP", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = cod_aux1
            cmd.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = cod_com1
            cmd.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = nro_com1
            cmd.Parameters.Add("@cod_doc", SqlDbType.VarChar).Value = cod_doc1
            cmd.Parameters.Add("@nro_doc", SqlDbType.VarChar).Value = nro_doc1
            cmd.Parameters.Add("@cod_per", SqlDbType.VarChar).Value = cod_per1
            cmd.Parameters.Add("@nro_doc_per", SqlDbType.VarChar).Value = nro_doc_per1
            cmd.Parameters.Add("@COD_cuenta", SqlDbType.VarChar).Value = txt_cod_cuenta.Text
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES00
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            MessageBox.Show("Vuelva a Intentarlo", "Ocurrió un Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cuenta.Text = dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value
            txt_desc_cuenta.Text = dgw_cuenta.Item(1, dgw_cuenta.CurrentRow.Index).Value
            Panel_cuenta.Visible = False
            K1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cuenta.Visible = False
            txt_cod_cuenta.Clear()
            txt_desc_cuenta.Clear()
            txt_cod_cuenta.Focus()
        End If
    End Sub
    Sub DGW_CUENTAS00()
        Try
            dgw_cuenta.DataSource = OBJ.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "P")
            dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = (New Font("Arial", 8.0!, FontStyle.Bold))
            dgw_cuenta.Columns.Item(2).Visible = False
            dgw_cuenta.Columns.Item(3).Visible = False
            dgw_cuenta.Columns.Item(4).Visible = False
            dgw_cuenta.Columns.Item(0).Width = 70
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGW_IE_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW_IE.CellClick
        If (DGW_IE.CurrentCellAddress.X = 9) Then
            If DGW_IE.Item(9, DGW_IE.CurrentRow.Index).Value = False Then
                DGW_IE.Item(9, DGW_IE.CurrentRow.Index).Value = True
            Else
                DGW_IE.Item(9, DGW_IE.CurrentRow.Index).Value = False
            End If
            HALLAR_MONTO()
        ElseIf (DGW_IE.CurrentCellAddress.X = 10) Then
            If DGW_IE.Item(10, DGW_IE.CurrentRow.Index).Value = False Then
                DGW_IE.Item(10, DGW_IE.CurrentRow.Index).Value = True
            Else
                DGW_IE.Item(10, DGW_IE.CurrentRow.Index).Value = False
            End If
            HALLAR_MONTO()
        End If
    End Sub
    Sub HALLAR_MONTO()
        Dim DEBE As Double = 0
        Dim HABER As Double = 0
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW_IE.RowCount - 1)
        If ch_moneda.Checked Then
            I = 0
            Do While (I <= CONT)
                If DGW_IE.Item(9, I).Value = True Then
                    If DGW_IE.Item(5, I).Value = "D" Then
                        If (DGW_IE.Item(8, I).Value.ToString = "S") Then
                            DEBE = Decimal.Add(DEBE, DGW_IE.Item(6, I).Value)
                        Else
                            DEBE = Decimal.Add(DEBE, DGW_IE.Item(7, I).Value)
                        End If
                    ElseIf DGW_IE.Item(5, I).Value = "H" Then
                        If (DGW_IE.Item(8, I).Value.ToString = "S") Then
                            HABER = Decimal.Add(HABER, DGW_IE.Item(6, I).Value)
                        Else
                            HABER = Decimal.Add(HABER, DGW_IE.Item(7, I).Value)
                        End If
                    End If
                End If
                I += 1
            Loop
        Else
            I = 0
            Do While (I <= CONT)
                If (DGW_IE.Item(9, I).Value.ToString = "True") Then
                    If DGW_IE.Item(5, I).Value = "D" Then
                        If (COD_MONEDA = "S") Then
                            DEBE = Decimal.Add(DEBE, DGW_IE.Item(6, I).Value)
                        Else
                            DEBE = Decimal.Add(DEBE, DGW_IE.Item(7, I).Value)
                        End If
                    ElseIf DGW_IE.Item(5, I).Value = "H" Then
                        If (COD_MONEDA = "S") Then
                            HABER = Decimal.Add(HABER, DGW_IE.Item(6, I).Value)
                        Else
                            HABER = Decimal.Add(HABER, DGW_IE.Item(7, I).Value)
                        End If
                    End If
                End If
                I += 1
            Loop
        End If
        txt_debe.Text = DEBE
        txt_haber.Text = HABER
        txt_saldo.Text = CDbl(DEBE - HABER)
        txt_debe.Text = OBJ.HACER_DECIMAL(txt_debe.Text)
        txt_haber.Text = OBJ.HACER_DECIMAL(txt_haber.Text)
        txt_saldo.Text = OBJ.HACER_DECIMAL(txt_saldo.Text)
    End Sub
    Sub LIMPIAR()
        g_com.Enabled = True
        txt_cod_cuenta.Clear()
        txt_desc_cuenta.Clear()
        cbo_mes1.SelectedIndex = -1
        cbo_moneda.SelectedIndex = -1
        ch_moneda.Checked = False
        ch_des.Checked = False
        txt_debe.Text = (0)
        txt_haber.Text = (0)
        txt_saldo.Text = (0)
    End Sub
    Sub LIMPIAR_GRABAR()
        g_com.Enabled = True
        ch_des.Checked = False
        txt_debe.Text = (0)
        txt_haber.Text = (0)
        txt_saldo.Text = (0)
    End Sub
    Sub MOSTRAR_ATCXP()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_A_TCXP_PTE_CONC", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@COD_cuenta ", SqlDbType.VarChar).Value = txt_cod_cuenta.Text
            cmd.Parameters.Add("@cod_moneda", SqlDbType.VarChar).Value = COD_MONEDA
            cmd.Parameters.Add("@status_moneda", SqlDbType.VarChar).Value = ST_MONEDA
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES00
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("Pendientes")
            adap.Fill(dt)
            DGW_IE.DataSource = (dt)
            DGW_IE.Columns(0).Width = 30
            DGW_IE.Columns(1).Width = &H55
            DGW_IE.Columns(2).Width = 50
            DGW_IE.Columns(3).Width = 180
            DGW_IE.Columns(4).Width = &H4B
            DGW_IE.Columns(5).Width = 30
            DGW_IE.Columns(6).Width = &H5F
            DGW_IE.Columns(7).Width = &H5F
            DGW_IE.Columns(6).DefaultCellStyle.Alignment = &H400
            DGW_IE.Columns(7).DefaultCellStyle.Alignment = &H400
            DGW_IE.Columns(8).Width = 20
            DGW_IE.Columns(9).Width = 35
            DGW_IE.Columns(10).Width = &H2D
            DGW_IE.Columns(11).Width = &H4B
            DGW_IE.Columns(12).Width = 30
            DGW_IE.Columns(13).Width = 35
            DGW_IE.Columns(14).Width = &H2D
            DGW_IE.Columns(15).Width = 70
            DGW_IE.Columns(16).Width = 35
            DGW_IE.Columns(17).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Vuelva a Intentarlo", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub txt_cod_cuenta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cuenta.LostFocus
        If (Trim(txt_cod_cuenta.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas de Tipo Pagar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cuenta.RowCount - 1))
                    If (txt_cod_cuenta.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cuenta.Text = dgw_cuenta.Item(0, i).Value.ToString
                        txt_desc_cuenta.Text = dgw_cuenta.Item(1, i).Value.ToString
                        cbo_moneda.Select()
                        Return
                    End If
                    If (txt_cod_cuenta.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_cod_cuenta.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cuenta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cuenta.Text) <> "")) Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas de tipo P", "Mensaje")
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cuenta.RowCount - 1))
                    If (txt_desc_cuenta.Text.ToLower = Strings.Mid((dgw_cuenta.Item(1, i).Value), 1, Strings.Len(txt_desc_cuenta.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub CXP_CONC_MANUAL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CXP_CONC_MANUAL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DGW_CUENTAS00()
        CBO_MONEDA00()
        DGW_IE.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        txt_cod_cuenta.Focus()
    End Sub
End Class