Imports System.Data.SqlClient
Public Class CONSULTA_PARA_COSTOS
    Dim COD_ACT, ST_COMP, ST_AUX, NRO_COMP0, ITEM0, COD_PROY, COD_AUX, COD_MES, COD_CONT, COD_AUX0, COD_CC, COD_COMP, COD_COMP0 As String
    Dim con00 As New SqlConnection("data source=" & nombre_servidor & ";initial catalog=BD_COS" & COD_EMPRESA & ";uid=miguel;pwd=main;")
    Dim OBJ As New Class1
    Dim ofr As New CONSULTA_REQ_ORD_PROD
    Sub boton3()
        ofr.con0 = con00
        ofr.CARGAR_ORD_PROD()
        ofr.ShowDialog()
        If (ofr.DialogResult = Windows.Forms.DialogResult.OK) Then
            txt_nro_req.Text = ofr.DGW_CAB.Item(0, ofr.DGW_CAB.CurrentRow.Index).Value.ToString
            Try
                COD_ACT = ofr.DGW_DET.Item(0, ofr.DGW_DET.CurrentRow.Index).Value.ToString
            Catch ex As Exception
                COD_ACT = ""
            End Try
            cbo_act01.SelectedIndex = -1
            cbo_act01.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
            ofr.Hide()
        End If
    End Sub
    Private Sub btn_consulta1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If txt_cta.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta.Focus() : Exit Sub
        COD_MES = OBJ.COD_MES(cbo_mes.Text)
        'MOSTRAR_CONSULTA()
        'GroupBox2.Enabled = False
        '---------------------------------------------------------------------------------
        If OBJ.VERIFICAR_CIERRE_PERIODO(cbo_año.Text, OBJ.COD_MES(cbo_mes.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        ElseIf OBJ.VERIFICAR_BLOKEO_PERIODO(cbo_año.Text, OBJ.COD_MES(cbo_mes.Text), "COI") = "1" Then
            MessageBox.Show("El Periodo está bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw1.Rows.Clear()
            cbo_mes.Focus()
            Exit Sub
        Else
            MOSTRAR_CONSULTA()
            GroupBox2.Enabled = False
            'BTN_MOD.Focus()
        End If
    End Sub
    Private Sub btn_lim_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_lim.Click
        CBO_CC01.SelectedIndex = -1
        CBO_PROYECTO01.SelectedIndex = -1
        txt_nro_req.Clear()
        cbo_act01.SelectedIndex = -1
    End Sub
    Private Sub btn_mod2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod2.Click
        COD_CC = "" : COD_PROY = "" : COD_CONT = "" : COD_ACT = ""
        If CBO_CC01.SelectedIndex <> -1 Then
            COD_CC = OBJ.COD_CC(CBO_CC01.Text)
        End If
        If CBO_PROYECTO01.SelectedIndex <> -1 Then
            COD_PROY = OBJ.COD_PROYECTO(CBO_PROYECTO01.Text)
        End If
        COD_CONT = txt_nro_req.Text
        If cbo_act01.SelectedIndex <> -1 Then
            COD_ACT = cbo_act01.SelectedValue.ToString
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_T_CON2", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP0
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP0
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = OBJ.COD_MES(cbo_mes.Text)
            comand1.Parameters.Add("@ITEM", SqlDbType.VarChar).Value = ITEM0
            comand1.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = COD_CC
            comand1.Parameters.Add("@COD_CONTROL", SqlDbType.VarChar).Value = COD_CONT
            comand1.Parameters.Add("@COD_PROYECTO", SqlDbType.VarChar).Value = COD_PROY
            comand1.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.VarChar).Value = COD_ACT
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cta01.Text
            con.Open()
            comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw2.Item(11, dgw2.CurrentRow.Index).Value = COD_CC
        dgw2.Item(9, dgw2.CurrentRow.Index).Value = COD_CONT
        dgw2.Item(12, dgw2.CurrentRow.Index).Value = COD_PROY
        dgw2.Item(10, dgw2.CurrentRow.Index).Value = COD_ACT
        T_CON_DETALLE()
        Panel1.Visible = False
        BTN_MOD.Focus()
    End Sub
    Private Sub btn_req_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_req.Click
        boton3()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Panel1.Visible = False
        BTN_MOD.Focus()
    End Sub
    Sub CARGAR_CUENTA()
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año.Text)
            dgw_cta.DataSource = (DT)
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '-------------------------------------------------------------------------
        Try
            Dim DT As New DataTable
            DT = OBJ.MOSTRAR_CUENTAS_TODAS_DETALLE(cbo_año.Text)
            dgw_cta01.DataSource = (DT)
            dgw_cta01.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_cta01.Columns.Item(0).Width = (80)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

      
    End Sub
    Sub CARGAR_DET()
        txt_cta01.Text = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
        txt_desc_cta01.Text = dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString
        CBO_CC01.Text = OBJ.DESC_CC(dgw2.Item(11, dgw2.CurrentRow.Index).Value.ToString)
        txt_nro_req.Text = dgw2.Item(9, dgw2.CurrentRow.Index).Value.ToString
        CBO_PROYECTO01.Text = OBJ.DESC_PROYECTO(dgw2.Item(12, dgw2.CurrentRow.Index).Value.ToString)
        COD_ACT = dgw2.Item(10, dgw2.CurrentRow.Index).Value.ToString
        cbo_act01.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
        COD_AUX0 = dgw2.Item(16, dgw2.CurrentRow.Index).Value.ToString
        COD_COMP0 = dgw2.Item(17, dgw2.CurrentRow.Index).Value.ToString
        NRO_COMP0 = dgw2.Item(18, dgw2.CurrentRow.Index).Value.ToString
        ITEM0 = dgw2.Item(15, dgw2.CurrentRow.Index).Value.ToString
    End Sub
    Sub CBO_ACTIVIDAD()

        Dim RPTA As String
        RPTA = OBJ.DIR_TABLA_DESC("COS", "TSIST")

        If RPTA = "SI" Then
            Dim GEN As New Genericos
            Dim DT As New DataTable
            DT = GEN.CBO_ACTIVIDAD(con00)
            cbo_act01.DataSource = DT
            cbo_act01.DisplayMember = DT.Columns.Item(0).ToString
            cbo_act01.ValueMember = DT.Columns.Item(1).ToString
            cbo_act01.SelectedIndex = -1
        End If
        
    End Sub
   Sub CBO_PROYECTO0()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PROYECTO_FECHA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = (FECHA_GRAL)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_PROYECTO01.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cta.CheckedChanged
        txt_cta01.Enabled = ch_cta.Checked
        txt_desc_cta01.Enabled = ch_cta.Checked
        If txt_cta01.Enabled Then
            txt_cta01.Focus()
        End If
    End Sub
    Sub DGW_CC0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        CBO_CC01.DataSource = DT
        CBO_CC01.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC01.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC01.SelectedIndex = -1
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            Panel_cta.Visible = False
            KL1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_cta.Clear()
            txt_desc_cta.Clear()
            txt_cta.Focus()
        End If
    End Sub
    Private Sub dgw_cta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta01.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta01.Text = (dgw_cta01.Item(0, dgw_cta01.CurrentRow.Index).Value)
            txt_desc_cta01.Text = (dgw_cta01.Item(1, dgw_cta01.CurrentRow.Index).Value)
            Panel_cta01.Visible = False
            KL01.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta01.Visible = False
            txt_cta01.Clear()
            txt_desc_cta01.Clear()
            txt_cta01.Focus()
        End If
    End Sub
    Sub LIMPIAR_DET()
        txt_cta01.Clear()
        txt_cta01.Enabled = False
        txt_desc_cta01.Clear()
        txt_desc_cta01.Enabled = False
        CBO_CC01.SelectedIndex = -1
        CBO_PROYECTO01.SelectedIndex = -1
        txt_nro_req.Clear()
        cbo_act01.SelectedIndex = -1
        ch_cta.Checked = False
    End Sub
  Sub MOSTRAR_CONSULTA()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_T_CON_ACTUALIZA2", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (txt_cta.Text)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txt_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta.LostFocus
        If (Strings.Trim(txt_cta.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta.RowCount - 1))
                    If (txt_cta.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta.Item(1, i).Value.ToString
                        btn_consulta1.Focus()
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
    Private Sub txt_cta01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta01.LostFocus
        If (Strings.Trim(txt_cta01.Text) <> "") Then
            If (dgw_cta01.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_cta01.Sort(dgw_cta01.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta01.RowCount - 1))
                    If (txt_cta01.Text.ToLower = dgw_cta01.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta01.Text = dgw_cta01.Item(0, i).Value.ToString
                        txt_desc_cta01.Text = dgw_cta01.Item(1, i).Value.ToString
                        KL01.Focus()
                        Return
                    End If
                    If (txt_cta01.Text.ToLower = Strings.Mid((dgw_cta01.Item(0, i).Value), 1, Strings.Len(txt_cta01.Text)).ToLower) Then
                        dgw_cta01.CurrentCell = (dgw_cta01.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta01.Visible = True
                dgw_cta01.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
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
    Private Sub txt_desc_cta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta01.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta01.Text) <> "")) Then
            If (dgw_cta01.RowCount = 0) Then
                MessageBox.Show("No existen cuentas para el año elegido", "Aviso:")
            Else
                dgw_cta01.Sort(dgw_cta01.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta01.RowCount - 1))
                    If (txt_desc_cta01.Text.ToLower = Strings.Mid((dgw_cta01.Item(1, i).Value), 1, Strings.Len(txt_desc_cta01.Text)).ToLower) Then
                        dgw_cta01.CurrentCell = (dgw_cta01.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_cta01.Visible = True
                dgw_cta01.Focus()
            End If
        End If
    End Sub
    Private Sub CONSULTA_PARA_COSTOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Sub CBO_CONTROL0()
    End Sub
    Sub CARGAR_AÑO()

        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_PARA_COSTOS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_mes.Text = OBJ.DESC_MES(MES)
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_AÑO()
        DGW_CC0()
        CBO_PROYECTO0()
        CBO_CONTROL0()
        CBO_ACTIVIDAD()
        txt_cta.Focus()
    End Sub
    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged
        CARGAR_CUENTA()
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        main(45) = 0
        Close()
    End Sub
    Private Sub BTN_LIMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP.Click
        cbo_año.SelectedIndex = -1
        cbo_mes.SelectedIndex = -1
        txt_cta.Clear()
        txt_desc_cta.Clear()
        dgw1.Rows.Clear()
        dgw2.Rows.Clear()
        GroupBox2.Enabled = True
        cbo_mes.Focus()
    End Sub
    Private Sub BTN_MOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MOD.Click

        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If dgw1.Item(10, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("No se puede Modificar porque ha sido Transferido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            LIMPIAR_DET()
            CARGAR_DET()
            Panel1.Visible = True
            CBO_CC01.Focus()
        End If
    End Sub
    Sub T_CON_DETALLE()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_T_CON_ACTUALIZA2_DET", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(6, dgw1.CurrentRow.Index).Value
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(7, dgw1.CurrentRow.Index).Value
            PROG_01.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(8, dgw1.CurrentRow.Index).Value
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw1.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            T_CON_DETALLE()
        End If
    End Sub
End Class