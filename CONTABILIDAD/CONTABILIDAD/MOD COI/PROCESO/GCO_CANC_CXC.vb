Imports System.Data.SqlClient
Imports System.Text
Public Class GCO_CANC_CXC
    Private COD_AUX As String
    Private COD_COMP As String
    Private COD_MONEDA As String
    Private COD_MP As String
    Private COD_PER As String
    Private cod_sucursal As String
    Private CON_GCO As SqlConnection
    Private DESC_PER As String
    Private DOC_PER As String
    Private DT As DataTable
    Private fila1 As Integer
    Private fila2 As Integer
    Private IMP_TOTAL As Decimal
    Private MES5 As String
    Private NRO_MP As String
    Private nro_planilla As String
    Private obj As New Class1
    Private SB As StringBuilder
    Private TIPO_CAMBIO As Decimal

    Public Sub BANCOS00()
        Try
            Me.dgw_ban.DataSource = Me.OBJ.MOSTRAR_BANCO_COMP
            Me.dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            Me.dgw_ban.Columns.Item(2).Visible = False
            Me.dgw_ban.Columns.Item(3).Visible = False
            Me.dgw_ban.Columns.Item(0).Width = 50
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If (Me.txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txt_cod_ban.Focus()
        ElseIf Me.panel_bancos.Visible Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.dgw_ban.Focus()
        ElseIf (Me.txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("No existe numeraci" & ChrW(243) & "n del Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(Me.OBJ.VALIDAR_FECHA_COMP(Me.dtp_mp.Value)) = 0) Then
            Me.dtp_mp.Focus()
        Else
            Me.TIPO_CAMBIO = Decimal.Parse(Me.OBJ.SACAR_CAMBIO(Me.dtp_mp.Value.Year, Me.dtp_mp.Value.ToString("MM"), Me.dtp_mp.Value.ToString("dd"), "D"))
            If (Decimal.Compare(Me.TIPO_CAMBIO, Decimal.Zero) = 0) Then
                MessageBox.Show("No existe Tipo de Cambio para la fecha elegida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim I As Integer = 0
                Dim CONT As Integer = (Me.DGW1.RowCount - 1)
                I = 0
                Do While (I <= CONT)
                    If Not String.Compare(Me.DGW1.Item(8, I).Value.ToString, "True", False) Then
                        Me.cod_sucursal = Me.DGW1.Item(0, I).Value.ToString
                        Me.nro_planilla = Me.DGW1.Item(2, I).Value.ToString
                        Me.COD_MP = Me.DGW1.Item(10, I).Value.ToString
                        Me.NRO_MP = Me.DGW1.Item(11, I).Value.ToString
                        If Not Me.obj.VERIFICAR_NRO_MP(Me.COD_MP, Me.NRO_MP, Me.txt_cod_ban.Text) Then
                            MessageBox.Show("Ya se ingres" & ChrW(243) & " ese N" & ChrW(186) & " de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            Me.CARGAR_DETALLES()
                            Me.VERIFICAR_PERSONA()
                            If (Me.INSERTAR_TODO = "EXITO") Then
                                Me.DOC_STATUS()
                                Me.dgw_det2.Rows.Clear()
                                GoTo Label_02E7
                            End If
                            MessageBox.Show("Ocurri" & ChrW(243) & " un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                        Return
Label_02E7:
                    End If
                    I += 1
                Loop
                MessageBox.Show("Los Documentos fueron Transferidos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_buscar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar1.Click
        Me.btn_sgt1.Enabled = True
        Me.txt_letra1.Focus()
        Dim CONT As Integer = (Me.DGW1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(Me.DGW1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (Me.txt_letra1.Text.ToLower = Strings.Mid(Me.DGW1.Item(7, i).Value.ToString, f, Strings.Len(Me.txt_letra1.Text)).ToLower) Then
                    Me.DGW1.CurrentCell = Me.DGW1.Rows.Item(i).Cells.Item(7)
                    Me.fila1 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub

    Private Sub btn_buscar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar2.Click
        Me.btn_sgt2.Enabled = True
        Me.txt_letra2.Focus()
        Dim CONT As Integer = (Me.DGW2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(Me.DGW2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (Me.txt_letra2.Text.ToLower = Strings.Mid(Me.DGW2.Item(7, i).Value.ToString, f, Strings.Len(Me.txt_letra2.Text)).ToLower) Then
                    Me.DGW2.CurrentCell = Me.DGW2.Rows.Item(i).Cells.Item(7)
                    Me.fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub

    Private Sub BTN_CANCELAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CANCELAR.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.DGW2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (String.Compare(Me.DGW2.Item(8, I).Value.ToString, "True", False) AndAlso String.Compare(Me.REGRESAR_I_FACT(I), "FALLO", False)) Then
                MessageBox.Show(("El N" & ChrW(186) & " Planilla :" & Me.DGW2.Item(2, Me.DGW2.CurrentRow.Index).Value.ToString), "Ocurrio un error en:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            I += 1
        Loop
        MessageBox.Show("Las Planillas fueron Des - Transferidas", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Me.CARGAR_PENDIENTES()
        Me.CARGAR_CERRADAS()
    End Sub

    Private Sub btn_sgt1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt1.Click
        Me.btn_sgt1.Enabled = True
        Me.txt_letra1.Focus()
        Dim CONT As Integer = (Me.DGW1.RowCount - 1)
        Dim i As Integer = Me.fila1
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(Me.DGW1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (Me.txt_letra1.Text.ToLower = Strings.Mid(Me.DGW1.Item(7, i).Value.ToString, f, Strings.Len(Me.txt_letra1.Text)).ToLower) Then
                    Me.DGW1.CurrentCell = Me.DGW1.Rows.Item(i).Cells.Item(7)
                    Me.fila1 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen m" & ChrW(225) & "s registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Me.btn_sgt2.Enabled = True
        Me.txt_letra2.Focus()
        Dim CONT As Integer = (Me.DGW2.RowCount - 1)
        Dim i As Integer = Me.fila2
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(Me.DGW2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (Me.txt_letra2.Text.ToLower = Strings.Mid(Me.DGW2.Item(7, i).Value.ToString, f, Strings.Len(Me.txt_letra2.Text)).ToLower) Then
                    Me.DGW2.CurrentCell = Me.DGW2.Rows.Item(i).Cells.Item(7)
                    Me.fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen m" & ChrW(225) & "s registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Sub CARGAR_CERRADAS()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_CXC_CANC_COI2", Me.CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Me.MES5
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            Me.DGW2.DataSource = DT
            Me.DGW2.Columns.Item(0).Visible = False
            Me.DGW2.Columns.Item(1).Width = &H55
            Me.DGW2.Columns.Item(2).Width = 90
            Me.DGW2.Columns.Item(3).Width = &H4B
            Me.DGW2.Columns.Item(4).DefaultCellStyle.Format = "d"
            Me.DGW2.Columns.Item(4).Width = &H37
            Me.DGW2.Columns.Item(5).Width = 200
            Me.DGW2.Columns.Item(6).Width = &H55
            Me.DGW2.Columns.Item(7).Width = 90
            Me.DGW2.Columns.Item(6).DefaultCellStyle.Format = "N2"
            Me.DGW2.Columns.Item(8).Width = 30
            Me.DGW2.Columns.Item(9).Width = &H23
            Me.DGW2.Columns.Item(10).Width = 40
            Me.DGW2.Columns.Item(11).Width = &H41
            Me.DGW2.Columns.Item(12).DefaultCellStyle.Format = "N4"
            Me.DGW2.Columns.Item(12).Width = 180
            Me.DGW2.Columns.Item(13).Width = &H2A
            Me.DGW2.Columns.Item(14).Width = 40
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub CARGAR_DETALLES()
        Me.dgw_det2.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("COI_MOSTRAR_TCXC_CANC_PTE", Me.CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_SUCURSAL", SqlDbType.VarChar).Value = Me.cod_sucursal
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = Me.nro_planilla
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = Me.COD_MONEDA
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = Me.MES5
            Me.CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                Me.dgw_det2.Rows.Add((Me.dgw_det2.RowCount + 1).ToString("00"), (rs3.GetValue(0)), (rs3.GetValue(1)), (rs3.GetValue(2)), (rs3.GetValue(3)), (rs3.GetValue(4)), (rs3.GetValue(5)), (rs3.GetValue(6)), (rs3.GetValue(7)), (rs3.GetValue(8)), (rs3.GetValue(9)), (rs3.GetValue(10)), (rs3.GetValue(11)), (rs3.GetValue(12)), (rs3.GetValue(13)), (rs3.GetValue(14)), "", "", "", "", "", "", "", "S")
            Loop
            Me.CON_GCO.Close()
        Catch ex As Exception


            Me.CON_GCO.Close()
            MsgBox(ex.Message)

        End Try
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.dgw_det2.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Me.dgw_det2.Item(14, I).Value = Me.OBJ.BUSCAR_CUENTA_PCXP(Integer.Parse(Me.cod_sucursal).ToString("00"), Me.dgw_det2.Item(3, I).Value.ToString, Me.dgw_det2.Item(1, I).Value.ToString, Me.dgw_det2.Item(2, I).Value.ToString).ToString
            I += 1
        Loop
    End Sub

    Public Sub CARGAR_PENDIENTES()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_CXC_CANC_PTE_COI", Me.CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Me.MES5
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            Me.DGW1.DataSource = DT
            Me.DGW1.Columns.Item(0).Visible = False
            Me.DGW1.Columns.Item(2).Visible = False
            Me.DGW1.Columns.Item(3).Visible = False
            Me.DGW1.Columns.Item(4).Visible = False
            Me.DGW1.Columns.Item(9).Visible = False
            Me.DGW1.Columns.Item(12).Visible = False
            Me.DGW1.Columns.Item(&H10).Visible = False
            Me.DGW1.Columns.Item(1).Width = &H55
            Me.DGW1.Columns.Item(5).Width = 70
            Me.DGW1.Columns.Item(6).Width = &H55
            Me.DGW1.Columns.Item(6).DefaultCellStyle.Format = "N2"
            Me.DGW1.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.DGW1.Columns.Item(7).Width = &H4B
            Me.DGW1.Columns.Item(7).DefaultCellStyle.Format = "d"
            Me.DGW1.Columns.Item(8).Width = 30
            Me.DGW1.Columns.Item(10).Width = &H23
            Me.DGW1.Columns.Item(11).Width = &H4B
            Me.DGW1.Columns.Item(13).Width = &H23
            Me.DGW1.Columns.Item(14).Width = &H37
            Me.DGW1.Columns.Item(14).DefaultCellStyle.Format = "N4"
            Me.DGW1.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.DGW1.Columns.Item(15).Width = &H4B
            Me.DGW1.Columns.Item(15).DefaultCellStyle.Format = "d"
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        If (Me.cbo_com.SelectedIndex <> -1) Then
            Me.COD_COMP = Me.cbo_com.SelectedValue.ToString
            If (Me.COD_COMP <> "System.Data.DataRowView") Then
                Me.COD_COMP = Me.OBJ.COD_COMP(Me.cbo_com.Text, Me.COD_AUX)
                Me.txt_nro_comp.Text = Me.OBJ.HALLAR_NRO_COMP(Me.COD_AUX, Me.COD_COMP, AÑO, MES)
            End If
        End If
    End Sub

    Public Sub CBO_COMPROBANTE()
        Me.cbo_com.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = Me.COD_AUX
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_com.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (Me.cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Public Sub CBO_COMPROBANTE00()
        Dim desc_comp0 As String = Me.cbo_com.Text.ToString
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(Me.COD_AUX)
        Me.cbo_com.DataSource = DT
        Me.cbo_com.DisplayMember = DT.Columns.Item(0).ToString
        Me.cbo_com.ValueMember = DT.Columns.Item(1).ToString
        Me.cbo_com.SelectedIndex = -1
        If (Me.cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Me.cbo_com.Text = desc_comp0
    End Sub

    Private Sub cbo_mes_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        Select Case Me.cbo_mes.SelectedIndex
            Case 0
                Me.MES5 = "01"
                Exit Select
            Case 1
                Me.MES5 = "02"
                Exit Select
            Case 2
                Me.MES5 = "03"
                Exit Select
            Case 3
                Me.MES5 = "04"
                Exit Select
            Case 4
                Me.MES5 = "05"
                Exit Select
            Case 5
                Me.MES5 = "06"
                Exit Select
            Case 6
                Me.MES5 = "07"
                Exit Select
            Case 7
                Me.MES5 = "08"
                Exit Select
            Case 8
                Me.MES5 = "09"
                Exit Select
            Case 9
                Me.MES5 = "10"
                Exit Select
            Case 10
                Me.MES5 = "11"
                Exit Select
            Case 11
                Me.MES5 = "12"
                Exit Select
        End Select
        Me.CARGAR_PENDIENTES()
    End Sub

    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes2.SelectedIndexChanged
        Select Case Me.cbo_mes2.SelectedIndex
            Case 0
                Me.MES5 = "01"
                Exit Select
            Case 1
                Me.MES5 = "02"
                Exit Select
            Case 2
                Me.MES5 = "03"
                Exit Select
            Case 3
                Me.MES5 = "04"
                Exit Select
            Case 4
                Me.MES5 = "05"
                Exit Select
            Case 5
                Me.MES5 = "06"
                Exit Select
            Case 6
                Me.MES5 = "07"
                Exit Select
            Case 7
                Me.MES5 = "08"
                Exit Select
            Case 8
                Me.MES5 = "09"
                Exit Select
            Case 9
                Me.MES5 = "10"
                Exit Select
            Case 10
                Me.MES5 = "11"
                Exit Select
            Case 11
                Me.MES5 = "12"
                Exit Select
        End Select
        Me.CARGAR_CERRADAS()
    End Sub

    Private Sub ch_cadena1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena1.CheckedChanged
        If Me.ch_cadena1.Checked Then
            Me.DGW1.Sort(Me.DGW1.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            Me.txt_letra1.Clear()
            Me.btn_buscar1.Enabled = True
            Me.btn_sgt1.Enabled = False
            Me.txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_cadena2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena2.CheckedChanged
        If Me.ch_cadena2.Checked Then
            Me.DGW2.Sort(Me.DGW2.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            Me.txt_letra2.Clear()
            Me.btn_buscar2.Enabled = True
            Me.btn_sgt2.Enabled = False
            Me.txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch_doc1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc1.CheckedChanged
        If Me.ch_doc1.Checked Then
            Me.DGW1.Sort(Me.DGW1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
            Me.txt_letra1.Clear()
            Me.btn_buscar1.Enabled = False
            Me.btn_sgt1.Enabled = False
            Me.txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_doc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc2.CheckedChanged
        If Me.ch_doc2.Checked Then
            Me.DGW2.Sort(Me.DGW2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
            Me.txt_letra2.Clear()
            Me.btn_buscar2.Enabled = False
            Me.btn_sgt2.Enabled = False
            Me.txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If Me.ch_per1.Checked Then
            Me.DGW1.Sort(Me.DGW1.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            Me.txt_letra1.Clear()
            Me.btn_buscar1.Enabled = False
            Me.btn_sgt1.Enabled = False
            Me.txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If Me.ch_per2.Checked Then
            Me.DGW2.Sort(Me.DGW2.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            Me.txt_letra2.Clear()
            Me.btn_buscar2.Enabled = False
            Me.btn_sgt2.Enabled = False
            Me.txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        If Me.ch1.Checked Then
            Dim i As Integer = 0
            Dim cont As Integer = (Me.DGW1.Rows.Count - 1)
            i = 0
            Do While (i <= cont)
                Me.DGW1.Item(9, i).Value = True
                i += 1
            Loop
        Else
            Dim i2 As Integer = 0
            Dim cont2 As Integer = (Me.DGW1.Rows.Count - 1)
            Dim CONT0 As Integer = cont2
            i2 = 0
            Do While (i2 <= CONT0)
                Me.DGW1.Item(9, i2).Value = False
                i2 += 1
            Loop
        End If
    End Sub
    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        If Me.ch2.Checked Then
            Dim i As Integer = 0
            Dim cont As Integer = (Me.DGW1.Rows.Count - 1)
            i = 0
            Do While (i <= cont)
                Me.DGW1.Item(9, i).Value = True
                i += 1
            Loop
        Else
            Dim i2 As Integer = 0
            Dim cont2 As Integer = (Me.DGW1.Rows.Count - 1)
            Dim CONT0 As Integer = cont2
            i2 = 0
            Do While (i2 <= CONT0)
                Me.DGW1.Item(9, i2).Value = False
                i2 += 1
            Loop
        End If
    End Sub
    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            Me.txt_cod_ban.Text = Me.dgw_ban.Item(0, Me.dgw_ban.CurrentRow.Index).Value.ToString
            Me.txt_desc_ban.Text = Me.dgw_ban.Item(1, Me.dgw_ban.CurrentRow.Index).Value.ToString
            Me.COD_MONEDA = Me.dgw_ban.Item(2, Me.dgw_ban.CurrentRow.Index).Value.ToString
            Me.COD_AUX = Me.dgw_ban.Item(3, Me.dgw_ban.CurrentRow.Index).Value.ToString
            Me.CBO_COMPROBANTE00()
            Me.panel_bancos.Visible = False
            Me.kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Me.panel_bancos.Visible = False
            Me.txt_cod_ban.Clear()
            Me.txt_desc_ban.Clear()
            Me.txt_cod_ban.Focus()
        End If
    End Sub
    Public Sub DOC_STATUS()
        Try
            Dim pro_02 As New SqlCommand("COI_I_CXC_STATUS", Me.CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_SUCURSAL", SqlDbType.VarChar).Value = Me.cod_sucursal
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = Me.nro_planilla
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = Me.MES5
            pro_02.Parameters.Add("@COD_MODULO", SqlDbType.VarChar).Value = "BCO"
            Me.CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            Me.CON_GCO.Close()
        Catch ex As Exception
            Me.CON_GCO.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GCO_CANC_CXP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GEN_FACT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        Dim emp00 As String = Me.obj.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        Me.CON_GCO.ConnectionString = String.Concat(New String() {"data source=", nombre_servidor, ";initial catalog=BD_GCO", emp00, ";uid=miguel;pwd=main;"})
        Me.DGW1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        Me.DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        Me.cbo_mes.Text = FECHA_GRAL.ToString("MMMM").ToUpper
        Me.BANCOS00()
        Me.DT.Columns.Add("COD_MP")
        Me.DT.Columns.Add("NRO_MP")
        Me.DT.Columns.Add("COD_BANCO")
        Me.DT.Columns.Add("NRO_ITEM")
        Me.DT.Columns.Add("FE_AÑO")
        Me.DT.Columns.Add("FE_MES")
        Me.DT.Columns.Add("COD_DOC")
        Me.DT.Columns.Add("NRO_DOC")
        Me.DT.Columns.Add("COD_PER")
        Me.DT.Columns.Add("NRO_DOC_PER")
        Me.DT.Columns.Add("FECHA_DOC")
        Me.DT.Columns.Add("COD_CPTO")
        Me.DT.Columns.Add("COD_CTA")
        Me.DT.Columns.Add("GLOSA")
        Me.DT.Columns.Add("IMP_DOC")
        Me.DT.Columns.Add("COD_D_H")
        Me.DT.Columns.Add("COD_MONEDA")
        Me.DT.Columns.Add("COD_MONEDA_PRO")
        Me.DT.Columns.Add("TIPO_CAMBIO")
        Me.DT.Columns.Add("TIPO_CAMBIO_PRO")
        Me.DT.Columns.Add("COD_CC")
        Me.DT.Columns.Add("COD_CONTROL")
        Me.DT.Columns.Add("COD_PROYECTO")
        Me.DT.Columns.Add("STATUS_TRANS")
        Me.DT.Columns.Add("FECHA_MP")
        Me.DT.Columns.Add("FECHA_VEN")
        Me.DT.Columns.Add("NOMBRE_PC")
    End Sub

    Private Sub GENERACION_COI_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(&H1D) = 0
    End Sub
    Public Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim sqlbc2 As New SqlBulkCopy(Me.CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.dgw_det2.Rows.Count - 1)
        Me.DT.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            Try
                Me.DT.Rows.Add(Me.COD_MP, Me.NRO_MP, Me.txt_cod_ban.Text, (I + 1).ToString("0000"), AÑO, MES, Me.dgw_det2.Item(1, I).Value.ToString, Me.dgw_det2.Item(2, I).Value.ToString, Me.dgw_det2.Item(3, I).Value.ToString, Me.dgw_det2.Item(5, I).Value.ToString, DateTime.Parse(Me.dgw_det2.Item(11, I).Value.ToString), Me.dgw_det2.Item(13, I).Value.ToString, Me.dgw_det2.Item(14, I).Value.ToString, Me.dgw_det2.Item(12, I).Value.ToString, Decimal.Parse((Me.dgw_det2.Item(6, I).Value)), Me.dgw_det2.Item(9, I).Value.ToString, Me.COD_MONEDA, Me.dgw_det2.Item(8, I).Value.ToString, Me.TIPO_CAMBIO, Decimal.Parse((Me.dgw_det2.Item(10, I).Value)), Me.dgw_det2.Item(&H10, I).Value.ToString, Me.dgw_det2.Item(&H11, I).Value.ToString, Me.dgw_det2.Item(&H12, I).Value.ToString, Me.dgw_det2.Item(&H17, I).Value.ToString, Me.dtp_mp.Value, DateTime.Parse(Me.dgw_det2.Item(11, I).Value.ToString), NOMBRE_PC)
            Catch ex As Exception
            End Try
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.T_BANCO2"
            sqlbc.WriteToServer(Me.DT)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

            Return estado

        End Try
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_BAN_INGRESO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = Me.COD_AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = Me.COD_COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = Me.txt_nro_comp.Text
            comand1.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = Me.dtp_mp.Value.Date
            comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = DateAndTime.Now
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = Me.txt_cod_ban.Text
            comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = Me.COD_MP
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = Me.NRO_MP
            comand1.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = Me.dtp_mp.Value
            comand1.Parameters.Add("@DESC_OPE", SqlDbType.VarChar).Value = "TRANSFERENCIA DE GESTION COMERCIAL"
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = Me.IMP_TOTAL
            comand1.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = "D"
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = Me.COD_MONEDA
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = Me.TIPO_CAMBIO
            comand1.Parameters.Add("@FECHA_DIF", SqlDbType.DateTime).Value = Me.dtp_mp.Value.Date
            comand1.Parameters.Add("@STATUS_DIF", SqlDbType.VarChar).Value = "0"
            con.Open()
            estado = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

            Return estado

        End Try
        Return estado
    End Function

    Public Function REGRESAR_I_FACT(ByVal FILA As Integer) As Object
        Dim estado As String = ""
        Dim COD_SUCURSAL As String = Me.DGW2.Item(0, FILA).Value.ToString
        Dim NRO_PLANILLA As String = Me.DGW2.Item(2, FILA).Value.ToString
        Try
            Dim pro_02 As New SqlCommand("COI_I_CXC_STATUS2", Me.CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_SUCURSAL", SqlDbType.VarChar).Value = COD_SUCURSAL
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = NRO_PLANILLA
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = Me.MES5
            Me.CON_GCO.Open()
            estado = (pro_02.ExecuteScalar)
            Me.CON_GCO.Close()
        Catch ex As Exception


            Me.CON_GCO.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

        End Try
        Return estado
    End Function

    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(Me.txt_cod_ban.Text) <> "") Then
            If (Me.dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban.Sort(Me.dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (Me.dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (Me.txt_cod_ban.Text.ToLower = Me.dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        Me.txt_cod_ban.Text = Me.dgw_ban.Item(0, i).Value.ToString
                        Me.txt_desc_ban.Text = Me.dgw_ban.Item(1, i).Value.ToString
                        Me.COD_MONEDA = Me.dgw_ban.Item(2, i).Value.ToString
                        Me.COD_AUX = Me.dgw_ban.Item(3, i).Value.ToString
                        Me.CBO_COMPROBANTE00()
                        Me.dtp_mp.Focus()
                        Return
                    End If
                    If (Me.txt_cod_ban.Text.ToLower = Strings.Mid((Me.dgw_ban.Item(0, i).Value), 1, Strings.Len(Me.txt_cod_ban.Text)).ToLower) Then
                        Me.dgw_ban.CurrentCell = Me.dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    Me.dgw_ban.CurrentCell = Me.dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Me.panel_bancos.Visible = True
                Me.dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(Me.txt_desc_ban.Text) <> "")) Then
            If (Me.dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban.Sort(Me.dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (Me.dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (Me.txt_desc_ban.Text.ToLower = Strings.Mid((Me.dgw_ban.Item(1, i).Value), 1, Strings.Len(Me.txt_desc_ban.Text)).ToLower) Then
                        Me.dgw_ban.CurrentCell = Me.dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    Me.dgw_ban.CurrentCell = Me.dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Me.panel_bancos.Visible = True
                Me.dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub txt_letra1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra1.TextChanged
        Dim i As Integer
        If Me.ch_doc1.Checked Then
            Me.txt_letra1.Focus()
            Dim CONT As Integer = (Me.DGW1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (Me.txt_letra1.Text.ToLower = Strings.Mid((Me.DGW1.Item(2, i).Value), 1, Strings.Len(Me.txt_letra1.Text)).ToLower) Then
                    Me.DGW1.CurrentCell = Me.DGW1.Rows.Item(i).Cells.Item(2)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf Me.ch_per1.Checked Then
            Me.txt_letra1.Focus()
            Dim CONT0 As Integer = (Me.DGW1.RowCount - 1)
            i = 0
            Do While (i <= CONT0)
                If (Me.txt_letra1.Text.ToLower = Strings.Mid((Me.DGW1.Item(7, i).Value), 1, Strings.Len(Me.txt_letra1.Text)).ToLower) Then
                    Me.DGW1.CurrentCell = Me.DGW1.Rows.Item(i).Cells.Item(7)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Private Sub txt_letra2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra2.TextChanged
        Dim i As Integer
        If Me.ch_doc2.Checked Then
            Me.txt_letra2.Focus()
            Dim CONT As Integer = (Me.DGW2.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (Me.txt_letra2.Text.ToLower = Strings.Mid((Me.DGW2.Item(2, i).Value), 1, Strings.Len(Me.txt_letra2.Text)).ToLower) Then
                    Me.DGW2.CurrentCell = Me.DGW2.Rows.Item(i).Cells.Item(2)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf Me.ch_per2.Checked Then
            Me.txt_letra2.Focus()
            Dim CONT0 As Integer = (Me.DGW2.RowCount - 1)
            i = 0
            Do While (i <= CONT0)
                If (Me.txt_letra2.Text.ToLower = Strings.Mid((Me.DGW2.Item(5, i).Value), 1, Strings.Len(Me.txt_letra2.Text)).ToLower) Then
                    Me.DGW2.CurrentCell = Me.DGW2.Rows.Item(i).Cells.Item(5)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Public Function VERIFICAR_PERSONA() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (Me.dgw_det2.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            Try
                Dim comand1 As New SqlCommand("VERIFICAR_PERSONA_TRANSF", con)
                comand1.CommandType = CommandType.StoredProcedure
                comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = Me.dgw_det2.Item(2, I).Value.ToString
                comand1.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = Me.dgw_det2.Item(3, I).Value.ToString
                comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = Me.dgw_det2.Item(4, I).Value.ToString
                con.Open()
                I = Integer.Parse(comand1.ExecuteScalar)
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            I += 1
        Loop
        Return True
    End Function

    
 
End Class