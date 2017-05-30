Imports System.Data.SqlClient
Imports System.Text
Public Class GCO_CANC_CXP
    Private COD_AUX As String
    Private COD_COMP As String
    Private COD_MONEDA As String
    Private COD_MP As String
    Private COD_PER As String
    Private cod_sucursal As String
    Private CON_GCO As New SqlConnection
    Private DESC_PER As String
    Private DOC_PER As String
    Private DT As New DataTable
    Private fila1 As Integer
    Private fila2 As Integer
    Private IMP_TOTAL As Decimal
    Private MES5 As String
    Private NRO_MP As String
    Private nro_planilla As String
    Private obj As New Class1
    Private SB As New StringBuilder
    Private TIPO_CAMBIO As Decimal

    Public Sub BANCOS00()
        Try
            dgw_ban.DataSource = OBJ.MOSTRAR_BANCO_COMP
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(2).Visible = False
            dgw_ban.Columns.Item(3).Visible = False
            dgw_ban.Columns.Item(0).Width = 50
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If (txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            TIPO_CAMBIO = Decimal.Parse(OBJ.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D"))
            If (Decimal.Compare(TIPO_CAMBIO, Decimal.Zero) = 0) Then
                MessageBox.Show("No existe Tipo de Cambio para la fecha elegida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim I As Integer = 0
                Dim CONT As Integer = (DGW1.RowCount - 1)
                I = 0
                Do While (I <= CONT)
                    If DGW1.Item(8, I).Value.ToString = "True" Then
                        cod_sucursal = DGW1.Item(0, I).Value.ToString
                        nro_planilla = DGW1.Item(2, I).Value.ToString
                        COD_MP = DGW1.Item(10, I).Value.ToString
                        NRO_MP = DGW1.Item(11, I).Value.ToString
                        If obj.VERIFICAR_NRO_MP(COD_MP, NRO_MP, txt_cod_ban.Text) = False Then
                            MessageBox.Show("Ya se ingresó ese Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            CARGAR_DETALLES()
                            VERIFICAR_PERSONA()
                            If (INSERTAR_TODO = "EXITO") Then
                                DOC_STATUS()
                                dgw_det2.Rows.Clear()
                            Else
                                MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Return
                            End If
                        End If


                    End If
                    I += 1
                Loop
                MessageBox.Show("Los Documentos fueron Transferidos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_buscar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar1.Click
        btn_sgt1.Enabled = True
        txt_letra1.Focus()
        Dim CONT As Integer = (DGW1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(DGW1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra1.Text.ToLower = Strings.Mid(DGW1.Item(7, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    DGW1.CurrentCell = DGW1.Rows.Item(i).Cells.Item(7)
                    fila1 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub

    Private Sub btn_buscar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar2.Click
        btn_sgt2.Enabled = True
        txt_letra2.Focus()
        Dim CONT As Integer = (DGW2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(DGW2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra2.Text.ToLower = Strings.Mid(DGW2.Item(7, i).Value.ToString, f, Strings.Len(txt_letra2.Text)).ToLower) Then
                    DGW2.CurrentCell = DGW2.Rows.Item(i).Cells.Item(7)
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub

    Private Sub BTN_CANCELAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CANCELAR.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If DGW2.Item(8, I).Value.ToString = "True" AndAlso REGRESAR_I_FACT(I) = "FALLO" Then
                MessageBox.Show(("El Nº Planilla :" & DGW2.Item(2, DGW2.CurrentRow.Index).Value.ToString), "Ocurrio un error en:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            I += 1
        Loop
        MessageBox.Show("Las Planillas fueron Des - Transferidas", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CARGAR_PENDIENTES()
        CARGAR_CERRADAS()
    End Sub

    Private Sub btn_sgt1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt1.Click
        btn_sgt1.Enabled = True
        txt_letra1.Focus()
        Dim CONT As Integer = (DGW1.RowCount - 1)
        Dim i As Integer = fila1
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(DGW1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra1.Text.ToLower = Strings.Mid(DGW1.Item(7, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    DGW1.CurrentCell = DGW1.Rows.Item(i).Cells.Item(7)
                    fila1 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        btn_sgt2.Enabled = True
        txt_letra2.Focus()
        Dim CONT As Integer = (DGW2.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(DGW2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra2.Text.ToLower = Strings.Mid(DGW2.Item(7, i).Value.ToString, f, Strings.Len(txt_letra2.Text)).ToLower) Then
                    DGW2.CurrentCell = DGW2.Rows.Item(i).Cells.Item(7)
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Sub CARGAR_CERRADAS()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_CXP_CANC_BCO2", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES5
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            DGW2.DataSource = DT
            DGW2.Columns.Item(0).Visible = False
            DGW2.Columns.Item(1).Width = &H55
            DGW2.Columns.Item(2).Width = 90
            DGW2.Columns.Item(3).Width = &H4B
            DGW2.Columns.Item(4).DefaultCellStyle.Format = "d"
            DGW2.Columns.Item(4).Width = &H37
            DGW2.Columns.Item(5).Width = 200
            DGW2.Columns.Item(6).Width = &H55
            DGW2.Columns.Item(7).Width = 90
            DGW2.Columns.Item(6).DefaultCellStyle.Format = "N2"
            DGW2.Columns.Item(8).Width = 30
            DGW2.Columns.Item(9).Width = 35
            DGW2.Columns.Item(10).Width = 40
            DGW2.Columns.Item(11).Width = &H41
            DGW2.Columns.Item(12).DefaultCellStyle.Format = "N4"
            DGW2.Columns.Item(12).Width = 180
            DGW2.Columns.Item(13).Width = &H2A
            DGW2.Columns.Item(14).Width = 40
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub CARGAR_DETALLES()
        dgw_det2.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("COI_MOSTRAR_TCXP_CANC_PTE", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_SUCURSAL", SqlDbType.VarChar).Value = cod_sucursal
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = nro_planilla
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES5
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                dgw_det2.Rows.Add((dgw_det2.RowCount + 1).ToString("00"), (rs3.GetValue(0)), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), (rs3.GetValue(11)), (rs3.GetValue(12)), (rs3.GetValue(13)), (rs3.GetValue(14)), "", "", "", "", "", "", "", "S")
            Loop
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)

        End Try
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det2.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            dgw_det2.Item(14, I).Value = obj.BUSCAR_CUENTA_PCXP(Integer.Parse(cod_sucursal).ToString("00"), dgw_det2.Item(3, I).Value.ToString, dgw_det2.Item(1, I).Value.ToString, dgw_det2.Item(2, I).Value.ToString).ToString
            I += 1
        Loop
    End Sub

    Public Sub CARGAR_PENDIENTES()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_CXP_CANC_PTE_COI", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES5
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            DGW1.DataSource = DT
            DGW1.Columns.Item(0).Visible = False
            DGW1.Columns.Item(9).Visible = False
            DGW1.Columns.Item(12).Visible = False
            DGW1.Columns.Item(16).Visible = False
            DGW1.Columns.Item(1).Width = &H55
            DGW1.Columns.Item(2).Width = 50
            DGW1.Columns.Item(3).Width = 150
            DGW1.Columns.Item(4).Width = &H55
            DGW1.Columns.Item(5).Width = 70
            DGW1.Columns.Item(6).Width = &H55
            DGW1.Columns.Item(6).DefaultCellStyle.Format = "N2"
            DGW1.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW1.Columns.Item(7).Width = &H4B
            DGW1.Columns.Item(7).DefaultCellStyle.Format = "d"
            DGW1.Columns.Item(8).Width = 30
            DGW1.Columns.Item(10).Width = 35
            DGW1.Columns.Item(11).Width = &H4B
            DGW1.Columns.Item(13).Width = 35
            DGW1.Columns.Item(14).Width = &H37
            DGW1.Columns.Item(14).DefaultCellStyle.Format = "N4"
            DGW1.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW1.Columns.Item(15).Width = &H4B
            DGW1.Columns.Item(15).DefaultCellStyle.Format = "d"
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        If (cbo_com.SelectedIndex <> -1) Then
            COD_COMP = cbo_com.SelectedValue.ToString
            If (COD_COMP <> "System.Data.DataRowView") Then
                COD_COMP = obj.COD_COMP(cbo_com.Text, COD_AUX)
                txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            End If
        End If
    End Sub

    Public Sub CBO_COMPROBANTE()
        cbo_com.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Public Sub CBO_COMPROBANTE00()
        Dim desc_comp0 As String = cbo_com.Text.ToString
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_com.DataSource = DT
        cbo_com.DisplayMember = DT.Columns.Item(0).ToString
        cbo_com.ValueMember = DT.Columns.Item(1).ToString
        cbo_com.SelectedIndex = -1
        If (cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        cbo_com.Text = desc_comp0
    End Sub



    Public Function CERRAR_I_FACT(ByVal FILA As Integer) As Object
        Dim estado As String = ""
        Dim COD_SUCURSAL As String = DGW1.Item(0, FILA).Value.ToString
        Dim NRO_PLANILLA As String = DGW1.Item(2, FILA).Value.ToString
        Try
            Dim CMD As New SqlCommand("TRANSFERIR_I_PLA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
            CMD.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = NRO_PLANILLA
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES5
            CMD.Parameters.Add("@FECHA_COI", SqlDbType.DateTime).Value = Now.Date.Date
            con.Open()
            estado = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

        End Try
        Return estado
    End Function

    Private Sub ch_cadena1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena1.CheckedChanged
        If ch_cadena1.Checked Then
            DGW1.Sort(DGW1.Columns.Item(3), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = True
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_cadena2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena2.CheckedChanged
        If ch_cadena2.Checked Then
            DGW2.Sort(DGW2.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = True
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch_doc1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc1.CheckedChanged
        If ch_doc1.Checked Then
            DGW1.Sort(DGW1.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_doc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc2.CheckedChanged
        If ch_doc2.Checked Then
            DGW2.Sort(DGW2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            DGW1.Sort(DGW1.Columns.Item(3), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked Then
            DGW2.Sort(DGW2.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        If ch1.Checked Then
            Dim i As Integer = 0
            Dim cont As Integer = (DGW1.Rows.Count - 1)
            i = 0
            Do While (i <= cont)
                DGW1.Item(9, i).Value = True
                i += 1
            Loop
        Else
            Dim i2 As Integer = 0
            Dim cont2 As Integer = (DGW1.Rows.Count - 1)
            i2 = 0
            Do While (i2 <= cont2)
                DGW1.Item(9, i2).Value = False
                i2 += 1
            Loop
        End If
    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        If ch2.Checked Then
            Dim i As Integer = 0
            Dim cont As Integer = (DGW1.Rows.Count - 1)
            i = 0
            Do While (i <= cont)
                DGW1.Item(9, i).Value = True
                i += 1
            Loop
        Else
            Dim i2 As Integer = 0
            Dim cont2 As Integer = (DGW1.Rows.Count - 1)
            i2 = 0
            Do While (i2 <= cont2)
                DGW1.Item(9, i2).Value = False
                i2 += 1
            Loop
        End If
    End Sub

    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            COD_MONEDA = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            COD_AUX = dgw_ban.Item(3, dgw_ban.CurrentRow.Index).Value.ToString
            CBO_COMPROBANTE00()
            panel_bancos.Visible = False
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_bancos.Visible = False
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
        End If
    End Sub


    Public Sub DOC_STATUS()
        Try
            Dim pro_02 As New SqlCommand("COI_I_CXP_STATUS", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_SUCURSAL", SqlDbType.VarChar).Value = cod_sucursal
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = nro_planilla
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES5
            pro_02.Parameters.Add("@COD_MODULO", SqlDbType.VarChar).Value = "BCO"
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub GCO_CANC_CXP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GEN_FACT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        Dim emp00 As String = obj.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = String.Concat(New String() {"data source=", nombre_servidor, ";initial catalog=BD_GCO", emp00, ";uid=miguel;pwd=main;"})
        DGW1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        MES5 = MES
        dtp_mp.Value = FECHA_GRAL
        BANCOS00()
        DT.Columns.Add("COD_MP")
        DT.Columns.Add("NRO_MP")
        DT.Columns.Add("COD_BANCO")
        DT.Columns.Add("NRO_ITEM")
        DT.Columns.Add("FE_AÑO")
        DT.Columns.Add("FE_MES")
        DT.Columns.Add("COD_DOC")
        DT.Columns.Add("NRO_DOC")
        DT.Columns.Add("COD_PER")
        DT.Columns.Add("NRO_DOC_PER")
        DT.Columns.Add("FECHA_DOC")
        DT.Columns.Add("COD_CPTO")
        DT.Columns.Add("COD_CTA")
        DT.Columns.Add("GLOSA")
        DT.Columns.Add("IMP_DOC")
        DT.Columns.Add("COD_D_H")
        DT.Columns.Add("COD_MONEDA")
        DT.Columns.Add("COD_MONEDA_PRO")
        DT.Columns.Add("TIPO_CAMBIO")
        DT.Columns.Add("TIPO_CAMBIO_PRO")
        DT.Columns.Add("COD_CC")
        DT.Columns.Add("COD_CONTROL")
        DT.Columns.Add("COD_PROYECTO")
        DT.Columns.Add("STATUS_TRANS")
        DT.Columns.Add("FECHA_MP")
        DT.Columns.Add("FECHA_VEN")
        DT.Columns.Add("NOMBRE_PC")
    End Sub

    Private Sub GENERACION_COI_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(14) = 0
    End Sub
    Public Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim sqlbc2 As New SqlBulkCopy(CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det2.Rows.Count - 1)
        DT.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            Try
                DT.Rows.Add(COD_MP, NRO_MP, txt_cod_ban.Text, (I + 1).ToString("0000"), AÑO, MES, dgw_det2.Item(1, I).Value.ToString, dgw_det2.Item(2, I).Value.ToString, dgw_det2.Item(3, I).Value.ToString, dgw_det2.Item(5, I).Value.ToString, DateTime.Parse(dgw_det2.Item(11, I).Value.ToString), dgw_det2.Item(13, I).Value.ToString, dgw_det2.Item(14, I).Value.ToString, dgw_det2.Item(12, I).Value.ToString, Decimal.Parse((dgw_det2.Item(6, I).Value)), dgw_det2.Item(9, I).Value.ToString, COD_MONEDA, dgw_det2.Item(8, I).Value.ToString, TIPO_CAMBIO, Decimal.Parse((dgw_det2.Item(10, I).Value)), dgw_det2.Item(16, I).Value.ToString, dgw_det2.Item(17, I).Value.ToString, dgw_det2.Item(18, I).Value.ToString, dgw_det2.Item(23, I).Value.ToString, dtp_mp.Value, DateTime.Parse(dgw_det2.Item(11, I).Value.ToString), NOMBRE_PC)
            Catch ex As Exception



            End Try
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.T_BANCO2"
            sqlbc.WriteToServer(DT)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

            Return estado

        End Try
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_BAN_EGRESO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtp_mp.Value.Date
            comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = NRO_MP
            comand1.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_mp.Value
            comand1.Parameters.Add("@DESC_OPE", SqlDbType.VarChar).Value = "TRANSAFRENCIA DE GESTION COMERCIAL"
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = IMP_TOTAL
            comand1.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = "D"
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TIPO_CAMBIO
            comand1.Parameters.Add("@FECHA_DIF", SqlDbType.DateTime).Value = dtp_mp.Value.Date
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
        Dim COD_SUCURSAL As String = DGW2.Item(0, FILA).Value.ToString
        Dim NRO_PLANILLA As String = DGW2.Item(2, FILA).Value.ToString
        Try
            Dim pro_02 As New SqlCommand("COI_I_CXP_STATUS2", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_SUCURSAL", SqlDbType.VarChar).Value = COD_SUCURSAL
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = NRO_PLANILLA
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES5
            CON_GCO.Open()
            estado = (pro_02.ExecuteScalar)
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

        End Try
        Return estado
    End Function

    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        COD_MONEDA = dgw_ban.Item(2, i).Value.ToString
                        COD_AUX = dgw_ban.Item(3, i).Value.ToString
                        CBO_COMPROBANTE00()
                        dtp_mp.Focus()
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
                dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
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

    Private Sub txt_letra1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra1.TextChanged
        Dim i As Integer
        If ch_doc1.Checked Then
            txt_letra1.Focus()
            Dim CONT As Integer = (DGW1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra1.Text.ToLower = Strings.Mid((DGW1.Item(5, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    DGW1.CurrentCell = DGW1.Rows.Item(i).Cells.Item(5)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per1.Checked Then
            txt_letra1.Focus()
            Dim CONT As Integer = (DGW1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra1.Text.ToLower = Strings.Mid((DGW1.Item(3, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    DGW1.CurrentCell = DGW1.Rows.Item(i).Cells.Item(3)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Private Sub txt_letra2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra2.TextChanged
        Dim i As Integer
        If ch_doc2.Checked Then
            txt_letra2.Focus()
            Dim CONT As Integer = (DGW2.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra2.Text.ToLower = Strings.Mid((DGW2.Item(2, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    DGW2.CurrentCell = DGW2.Rows.Item(i).Cells.Item(2)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per2.Checked Then
            txt_letra2.Focus()
            Dim CONT As Integer = (DGW2.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra2.Text.ToLower = Strings.Mid((DGW2.Item(5, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    DGW2.CurrentCell = DGW2.Rows.Item(i).Cells.Item(5)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Public Function VERIFICAR_PERSONA() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det2.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            Try
                Dim comand1 As New SqlCommand("VERIFICAR_PERSONA_TRANSF", con)
                comand1.CommandType = CommandType.StoredProcedure
                comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = dgw_det2.Item(2, I).Value.ToString
                comand1.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = dgw_det2.Item(3, I).Value.ToString
                comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgw_det2.Item(4, I).Value.ToString
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