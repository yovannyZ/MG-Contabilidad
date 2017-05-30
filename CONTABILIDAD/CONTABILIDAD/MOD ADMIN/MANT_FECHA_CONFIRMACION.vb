Imports System.Data.SqlClient
Public Class MANT_FECHA_CONFIRMACION
    Dim OBJ As New Class1
    Dim COD_MP, COD_MP2 As String
    Private Sub MANT_FECHA_CONFIRMACION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub MANT_FECHA_CONFIRMACION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        DGW_DET.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET22.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET23.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET24.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET3.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        CARGAR_AÑOS()
        cbo_año.Text = AÑO
        CARGAR_BANCOS()
        CBO_MP00()

    End Sub
    Sub CBO_MP00()
        cbo_mp.Items.Clear()
        cbo_mp2.Items.Clear()
        cbo_mp3.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_MP", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_mp.Items.Add(Rs3.GetString(0))
                cbo_mp2.Items.Add(Rs3.GetString(0))
                cbo_mp3.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        cbo_año2.Items.Clear()
        cbo_año3.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
                Me.cbo_año2.Items.Add(Rs3.GetString(0))
                Me.cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H37

            dgw_ban2.DataSource = dt
            dgw_ban2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban2.Columns.Item(0).Width = &H37

            dgw_ban3.DataSource = dt
            dgw_ban3.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban3.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cod_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_cod_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        'cboMes.Select()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            kl1.Focus()
        End If
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If CH1.Checked = True And txt_cod_ban.Text = "" Then MessageBox.Show("Debe ingresar el Banco", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_mp.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Medio de Pago", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mp.Focus() : Exit Sub
        Dim mm As String
        mm = dtp1.Value.Month.ToString("00")
        If mm < OBJ.COD_MES(cbo_mes.Text) Then MessageBox.Show("El mes de la fecha debe ser mayor y/o igual al mes elegido", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp1.Focus() : Exit Sub
        If dtp1.Value.Year.ToString < cbo_año.Text Then MessageBox.Show("El año de la fecha debe ser mayor y/o igual al mes elegido", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp1.Focus() : Exit Sub

        'DGW_DET22.Rows.Clear()
        CARGAR_DETALLES_NULOS()
        COD_MP = OBJ.COD_MP(cbo_mp.Text)
    End Sub
    Sub CARGAR_DETALLES_NULOS()
        Dim ST, CB As String
        If CH1.Checked = True Then
            ST = "0" : CB = txt_cod_ban.Text
        Else
            ST = "1" : CB = " "
        End If
        COD_MP = OBJ.COD_MP(cbo_mp.Text)
        DGW_DET.Rows.Clear()
        DGW_DET22.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_EGRESO_FEC_CONF_NULAS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = cbo_año.Text
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = OBJ.COD_MES(cbo_mes.Text)
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = CB
            pro_02.Parameters.Add("@ST_BCO", SqlDbType.Char).Value = ST
            pro_02.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                DGW_DET.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click, btn_salir2.Click, Button2.Click
        main(35) = 0
        Close()
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Dim i, cont As Integer
        cont = DGW_DET.RowCount - 1
        For i = 0 To cont
            If DGW_DET.Item(7, i).Value = True Then
                Dim CMD As New SqlCommand("MODIFICAR_EGRESO_FEC_CONF_NULAS", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = DGW_DET.Item(0, i).Value.ToString
                CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = DGW_DET.Item(2, i).Value.ToString
                CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = DGW_DET.Item(4, i).Value.ToString
                CMD.Parameters.Add("@FECHA_CONFIRMACION", SqlDbType.DateTime).Value = dtp1.Value
                CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = "1"
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            End If
        Next
        MessageBox.Show("La fecha de confirmación se actualizo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CARGAR_DETALLES_NULOS()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH1.CheckedChanged
        If CH1.Checked = True Then
            txt_cod_ban.Enabled = True
            txt_desc_ban.Enabled = True
        Else
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Enabled = False
            txt_desc_ban.Enabled = False
        End If
    End Sub
    Private Sub ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch2.CheckedChanged
        If ch2.Checked = True Then
            txt_cod_ban2.Enabled = True
            txt_desc_ban2.Enabled = True
        Else
            txt_cod_ban2.Clear()
            txt_desc_ban2.Clear()
            txt_cod_ban2.Enabled = False
            txt_desc_ban2.Enabled = False
        End If
    End Sub
    Private Sub txt_cod_ban2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban2.LostFocus
        If (Strings.Trim(txt_cod_ban2.Text) <> "") Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban2.Sort(dgw_ban2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban2.Text.ToLower = dgw_ban2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban2.Text = dgw_ban2.Item(0, i).Value.ToString
                        txt_desc_ban2.Text = dgw_ban2.Item(1, i).Value.ToString
                        'cboMes.Select()
                        Return
                    End If
                    If (txt_cod_ban2.Text.ToLower = Strings.Mid((dgw_ban2.Item(0, i).Value), 1, Strings.Len(txt_cod_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = dgw_ban2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = dgw_ban2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos2.Visible = True
                dgw_ban2.Visible = True
                dgw_ban2.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_ban2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban2.Text = dgw_ban2.Item(0, dgw_ban2.CurrentRow.Index).Value.ToString
            txt_desc_ban2.Text = dgw_ban2.Item(1, dgw_ban2.CurrentRow.Index).Value.ToString
            panel_bancos2.Visible = False
            kl2.Focus()
        End If
    End Sub
    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban2.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban2.Text) <> "")) Then
            If (dgw_ban2.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban2.Sort(dgw_ban2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban2.Text.ToLower = Strings.Mid((dgw_ban2.Item(1, i).Value), 1, Strings.Len(txt_desc_ban2.Text)).ToLower) Then
                        dgw_ban2.CurrentCell = dgw_ban2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban2.CurrentCell = dgw_ban2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos2.Visible = True
                dgw_ban2.Focus()
            End If
        End If
    End Sub
    Private Sub btn_consultar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar2.Click
        If ch2.Checked = True And txt_cod_ban2.Text = "" Then MessageBox.Show("Debe ingresar el Banco", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban2.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If cbo_año2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año2.Focus() : Exit Sub
        'DGW_DET23.Rows.Clear()
        CARGAR_DETALLES_NO_NULOS()
        'COD_MP = OBJ.COD_MP(cbo_mp2.Text)
    End Sub
    Sub CARGAR_DETALLES_NO_NULOS()
        Dim ST, CB As String
        If ch2.Checked = True Then
            ST = "0" : CB = txt_cod_ban2.Text
        Else
            ST = "1" : CB = " "
        End If
        COD_MP2 = OBJ.COD_MP(cbo_mp2.Text)
        DGW_DET2.Rows.Clear()
        DGW_DET23.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_EGRESO_FEC_CONF_NO_NULAS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = cbo_año2.Text
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = OBJ.COD_MES(cbo_mes2.Text)
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = CB
            pro_02.Parameters.Add("@ST_BCO", SqlDbType.Char).Value = ST
            pro_02.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP2
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                DGW_DET2.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar2.Click
        Dim i, cont As Integer
        cont = DGW_DET2.RowCount - 1
        For i = 0 To cont
            If DGW_DET2.Item(7, i).Value = True Then
                Dim CMD As New SqlCommand("MODIFICAR_EGRESO_FEC_CONF_NULAS", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
                CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = DGW_DET2.Item(0, i).Value.ToString
                CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = DGW_DET2.Item(2, i).Value.ToString
                CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = DGW_DET2.Item(4, i).Value.ToString
                CMD.Parameters.Add("@FECHA_CONFIRMACION", SqlDbType.DateTime).Value = Now
                CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = "2"
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            End If
        Next
        MessageBox.Show("La fecha de confirmación se actualizo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CARGAR_DETALLES_NO_NULOS()
    End Sub

    Private Sub ch3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch3.CheckedChanged
        If ch3.Checked = True Then
            txt_cod_ban3.Enabled = True
            txt_desc_ban3.Enabled = True
        Else
            txt_cod_ban3.Clear()
            txt_desc_ban3.Clear()
            txt_cod_ban3.Enabled = False
            txt_desc_ban3.Enabled = False
        End If
    End Sub


    Private Sub txt_cod_ban3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_ban3.LostFocus
        If (Strings.Trim(txt_cod_ban3.Text) <> "") Then
            If (dgw_ban3.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban3.Sort(dgw_ban3.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban3.Text.ToLower = dgw_ban3.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban3.Text = dgw_ban3.Item(0, i).Value.ToString
                        txt_desc_ban3.Text = dgw_ban3.Item(1, i).Value.ToString
                        'cboMes.Select()
                        Return
                    End If
                    If (txt_cod_ban3.Text.ToLower = Strings.Mid((dgw_ban3.Item(0, i).Value), 1, Strings.Len(txt_cod_ban3.Text)).ToLower) Then
                        dgw_ban3.CurrentCell = dgw_ban3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban3.CurrentCell = dgw_ban3.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos3.Visible = True
                dgw_ban3.Visible = True
                dgw_ban3.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_ban3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_ban3.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban3.Text) <> "")) Then
            If (dgw_ban3.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban3.Sort(dgw_ban3.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban3.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban3.Text.ToLower = Strings.Mid((dgw_ban3.Item(1, i).Value), 1, Strings.Len(txt_desc_ban3.Text)).ToLower) Then
                        dgw_ban3.CurrentCell = dgw_ban3.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban3.CurrentCell = dgw_ban3.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos3.Visible = True
                dgw_ban3.Focus()
            End If
        End If
    End Sub


    Private Sub dgw_ban3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_ban3.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban3.Text = dgw_ban3.Item(0, dgw_ban3.CurrentRow.Index).Value.ToString
            txt_desc_ban3.Text = dgw_ban3.Item(1, dgw_ban3.CurrentRow.Index).Value.ToString
            panel_bancos3.Visible = False
            kl3.Focus()
        End If
    End Sub

    Private Sub btn_consultar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar3.Click
        If ch3.Checked = True And txt_cod_ban3.Text = "" Then MessageBox.Show("Debe ingresar el Banco", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_ban3.Focus() : Exit Sub
        If cbo_mes3.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes3.Focus() : Exit Sub
        If cbo_año3.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año3.Focus() : Exit Sub

        'DGW_DET24.Rows.Clear()
        CARGAR_CONSULTA()
    End Sub
    Sub CARGAR_CONSULTA()
        Dim ST, CB As String
        If ch3.Checked = True Then
            ST = "0" : CB = txt_cod_ban3.Text
        Else
            ST = "1" : CB = " "
        End If
        COD_MP = OBJ.COD_MP(cbo_mp3.Text)
        DGW_DET3.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_EGRESO_FEC_CONF_CONSULTA", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = cbo_año3.Text
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = CB
            pro_02.Parameters.Add("@ST_BCO", SqlDbType.Char).Value = ST
            pro_02.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                DGW_DET3.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGW_DET_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_DET.CellEnter
        Try
            Dim i As Integer = DGW_DET.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (DGW_DET.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            T_BANCO()
        End If
    End Sub
    Sub T_BANCO2()
        DGW_DET23.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_EGRESO_FEC_CONF_NULAS_DETALLES", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_MP", SqlDbType.Char).Value = DGW_DET2.Item(2, DGW_DET2.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = DGW_DET2.Item(4, DGW_DET2.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = DGW_DET2.Item(0, DGW_DET2.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                DGW_DET23.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub T_BANCO()
        DGW_DET22.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_EGRESO_FEC_CONF_NULAS_DETALLES", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP
            pro_02.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = DGW_DET.Item(4, DGW_DET.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = DGW_DET.Item(0, DGW_DET.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                DGW_DET22.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGW_DET2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_DET2.CellEnter
        Try
            Dim i As Integer = DGW_DET2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (DGW_DET2.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            T_BANCO2()
        End If
    End Sub
    Private Sub DGW_DET3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_DET3.CellEnter
        Try
            Dim i As Integer = DGW_DET3.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (DGW_DET3.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            T_BANCO3()
        End If
    End Sub
    Sub T_BANCO3()
        DGW_DET24.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_EGRESO_FEC_CONF_NULAS_DETALLES", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_MP", SqlDbType.Char).Value = DGW_DET3.Item(2, DGW_DET3.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = DGW_DET3.Item(4, DGW_DET3.CurrentRow.Index).Value.ToString
            pro_02.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = DGW_DET3.Item(0, DGW_DET3.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                DGW_DET24.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_cod_ban_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_ban.TextChanged

    End Sub
End Class