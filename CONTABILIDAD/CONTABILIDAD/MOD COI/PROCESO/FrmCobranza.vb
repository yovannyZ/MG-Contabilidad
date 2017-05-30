Imports System.Data.SqlClient
Imports System.Text
Public Class FrmCobranza
#Region "Variables"
    Private COD_AUX As String
    Private COD_AUX0 As String
    Private COD_BANCO As String
    Private COD_COMP As String
    Private COD_COMP0 As String
    Private COD_CUENTA As String
    Private COD_MONEDA As String
    Private COD_MP As String
    Private COD_PER As String
    Private COD_SUC As Integer
    Private COD_SUCURSAL As String
    Private CON_GCO As New SqlConnection
    Private DESC_PER As String
    Private DESTINO0 As String
    Private DOC_PER As String
    Private DT_DET As New DataTable
    Private FECHA_PLA As DateTime
    Private FECHA0 As DateTime
    Private fila0 As Integer
    Private fila1 As Integer
    Private fila2 As Integer
    Private IGV0 As Decimal
    Private IMP_TOTAL As Decimal
    Private NRO_CUOTA As String
    Private NRO_MP As String
    Private NRO_PLANILLA As String
    Private obj As New Class1
    Private SB As New StringBuilder
    Private TIPO_CAMBIO As Decimal
    Private VEN0 As DateTime
    Private NRO_DOC As String
    Private CONTGC, CONTGS As Integer
    Private RPTA As String
    Private Imp_Final As Decimal
#End Region

    Private Sub btn_aceptar0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar0.Click

        If (cbo_aux0.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux0.Focus()
        ElseIf (cbo_com0.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com0.Focus()
        ElseIf (txt_nro_comp0.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp0.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com0.Value)) = 0) Then
            dtp_com0.Focus()
        ElseIf obj.VERIFICAR_CUENTA(TXT_CUENTA.Text, AÑO) = False Then
            TXT_CUENTA.Focus()
            MessageBox.Show("La Cuenta no existe en el Plan de Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            ch0.Checked = True
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_CANC.RowCount - 1)
            I = 0
            For I = 0 To CONT
                If DGW_CANC.Item(8, I).Value.ToString = "True" Then
                    If ((DGW_CANC.Item(9, I).Value.ToString = "") Or (DGW_CANC.Item(9, I).Value.ToString.Length <> 8)) Then
                        MessageBox.Show("Debe ingresar la Cuenta Contable correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf obj.VERIFICAR_CUENTA(DGW_CANC.Item(9, I).Value.ToString, AÑO) = False Then
                        MessageBox.Show(("La Cuenta Contable : " & DGW_CANC.Item(9, I).Value.ToString & " no existe."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        COD_SUCURSAL = (DGW_CANC.Item(0, I).Value)
                        COD_PER = (DGW_CANC.Item(2, I).Value)
                        DESC_PER = (DGW_CANC.Item(3, I).Value)
                        DOC_PER = (DGW_CANC.Item(4, I).Value)
                        NRO_PLANILLA = (DGW_CANC.Item(5, I).Value)
                        IMP_TOTAL = Decimal.Parse(DGW_CANC.Item(6, I).Value)
                        FECHA_PLA = DateTime.Parse((DGW_CANC.Item(7, I).Value))
                        COD_CUENTA = DGW_CANC.Item(9, I).Value.ToString
                        COD_MP = DGW_CANC.Item(10, I).Value.ToString
                        NRO_MP = DGW_CANC.Item(11, I).Value.ToString
                        COD_BANCO = DGW_CANC.Item(12, I).Value.ToString
                        COD_MONEDA = (DGW_CANC.Item(13, I).Value)
                        TIPO_CAMBIO = Decimal.Parse((DGW_CANC.Item(14, I).Value))
                        NRO_DOC = DGW_CANC.Item(18, I).Value.ToString
                        RPTA = CARGAR_DOC_PLANILLA0(COD_SUCURSAL, NRO_PLANILLA, NRO_DOC)
                    End If
                End If
            Next

            If (RPTA <> "") Then
                MessageBox.Show(("El importe del documento de Cta.Cte. / Nº Doc.: " & RPTA & " tiene importe menor al que se desea cancelar."), "No se puede transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf VALIDAR_IMPORTE0() = False Then
                MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If (INSERTAR_TODO0() = "EXITO") Then
                    DOC_STATUS()
                Else
                    obj.ELIMINAR_TEMPORAL("TCON")
                    MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            Dim desc1 As String = cbo_com0.Text
            cbo_com0.SelectedIndex = -1
            cbo_com0.Text = desc1
            MessageBox.Show("Los Documentos fueron transferidos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CARGAR_PENDIENTES0()
            CARGAR_CERRADAS(dtpCancelarTrans.Value.Year, dtpCancelarTrans.Value.Month, dtpCancelarTrans.Value.Day)
        End If
    End Sub

    Private Sub btn_buscar0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar0.Click
        btn_sgt0.Enabled = True
        txt_letra0.Focus()
        Dim CONT As Integer = (DGW_CANC.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT1 As Integer = Strings.Len(DGW_CANC.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_letra0.Text.ToLower = Strings.Mid(DGW_CANC.Item(7, i).Value.ToString, f, Strings.Len(txt_letra0.Text)).ToLower) Then
                    DGW_CANC.CurrentCell = DGW_CANC.Rows.Item(i).Cells.Item(7)
                    fila0 = (i + 1)
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
            Dim CONT1 As Integer = Strings.Len(DGW2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
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

    Private Sub btn_sgt0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt0.Click
        btn_sgt0.Enabled = True
        txt_letra0.Focus()
        Dim CONT As Integer = (DGW_CANC.RowCount - 1)
        Dim i As Integer = fila0
        Do While (i <= CONT)
            Dim CONT1 As Integer = Strings.Len(DGW_CANC.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_letra0.Text.ToLower = Strings.Mid(DGW_CANC.Item(7, i).Value.ToString, f, Strings.Len(txt_letra0.Text)).ToLower) Then
                    DGW_CANC.CurrentCell = DGW_CANC.Rows.Item(i).Cells.Item(7)
                    fila0 = (i + 1)
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
            Dim CONT1 As Integer = Strings.Len(DGW2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
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

    'Public Sub CARGAR_CERRADAS()
    Public Sub CARGAR_CERRADAS(ByVal año As String, ByVal mes As String, ByVal dia As String)
        Try
            Dim CMD As New SqlCommand("MOSTRAR_I_COBRANZA_CANCELADAS", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año
            CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = mes

            CMD.Parameters.Add("@FE_DIA", SqlDbType.VarChar).Value = dia
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
            DGW2.Columns.Item(5).Visible = False 'DGW2.Columns.Item(5).Width = 200
            DGW2.Columns.Item(6).Width = &H55
            DGW2.Columns.Item(7).Width = 90
            'DGW2.Columns.Item(6).DefaultCellStyle.Format = "N4"
            'DGW2.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW2.Columns.Item(7).DefaultCellStyle.Format = "d"
            DGW2.Columns.Item(8).Visible = False 'DGW2.Columns.Item(8).Width = 30
            DGW2.Columns.Item(9).Visible = False 'DGW2.Columns.Item(9).Width = 35
            DGW2.Columns.Item(10).Visible = False 'DGW2.Columns.Item(10).Width = 40
            DGW2.Columns.Item(11).Visible = False 'DGW2.Columns.Item(11).Width = &H41
            DGW2.Columns.Item(12).Visible = False 'DGW2.Columns.Item(12).DefaultCellStyle.Format = "N4"
            'DGW2.Columns.Item(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW2.Columns.Item(12).Width = 180
            DGW2.Columns.Item(13).Width = &H2A
            DGW2.Columns.Item(14).Width = 40
            DGW2.Columns.Item(15).Visible = False 'DGW2.Columns.Item(15).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Function CARGAR_DOC_PLANILLA0(ByVal COD_SUC0 As Object, ByVal NRO_PLA0 As Object, ByVal NRO_DOC As String) As String
        dgw_mov1.Rows.Clear()
        'dgw_canc2.Rows.Clear()
        Try
            'Mostramos los detalles del documento
            Dim PRO_02 As New SqlCommand("COI_MOSTRAR_TCOB_CANC_PTE", CON_GCO)
            PRO_02.CommandType = CommandType.StoredProcedure
            PRO_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUCURSAL
            PRO_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC    'COD_MP + "-" + NRO_MP 'NRO_PLANILLA
            PRO_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            PRO_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            PRO_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            CON_GCO.Open()
            PRO_02.ExecuteNonQuery()
            Dim RS3 As SqlDataReader = PRO_02.ExecuteReader
            Do While RS3.Read
                'Carga los detalles a la grilla
                dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1).ToString("0000"), (RS3.GetValue(0)), RS3.GetValue(1), RS3.GetValue(2), RS3.GetValue(3), RS3.GetValue(4), RS3.GetValue(5), RS3.GetValue(6), RS3.GetValue(7), RS3.GetValue(8), RS3.GetValue(9), RS3.GetValue(10), (RS3.GetValue(11)), (RS3.GetValue(12)), (RS3.GetValue(13)), "", "", "", "", "", "", "", "S", (RS3.GetValue(16)))
            Loop
            CON_GCO.Close()
        Catch ex As Exception

            CON_GCO.Close()
            MessageBox.Show(ex.Message)

        End Try

        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1) 'DGW_CANC.RowCount - 1 '
        Dim CONT1 As Integer = CONT
        I = 0
        Do While (I <= CONT1)
            Dim cod_doc22 As String = (dgw_mov1.Item(1, I).Value)
            'Recupera el número de la cuenta en PCTAS_PAGAR
            dgw_mov1.Item(13, I).Value = obj.BUSCAR_CUENTA_COB(dgw_mov1.Item(23, I).Value.ToString)
            'Leemos la grilla DGW_canc
            dgw_canc2.Rows.Add(New Object() {"", cod_doc22, (dgw_mov1.Item(2, I).Value), dtp_com0.Value, (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), (dgw_mov1.Item(9, I).Value), (dgw_mov1.Item(6, I).Value), (dgw_mov1.Item(8, I).Value), TIPO_CAMBIO, (dgw_mov1.Item(12, I).Value), (dgw_mov1.Item(13, I).Value), (dgw_mov1.Item(15, I).Value), (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), "", (dgw_mov1.Item(14, I).Value), (dgw_mov1.Item(18, I).Value), (dgw_mov1.Item(19, I).Value), (dgw_mov1.Item(20, I).Value), (dgw_mov1.Item(22, I).Value), "", NRO_MP, dtp_com0.Value, 1})
            I += 1
        Loop
        dgw_canc2.Rows.Add(New Object() {COD_MP, "", NRO_MP, dtp_com0.Value, "", "", "", "H", IMP_TOTAL, COD_MONEDA, TIPO_CAMBIO, "COBRANZA DE DOCUMENTO", COD_CUENTA, " ", " ", " ", "0", dtp_com0.Value, "", "", "", "", "", NRO_PLANILLA, dtp_com0.Value, 1})

        Return ""
    End Function

    Public Sub CARGAR_PENDIENTES0()
        Try
            COD_SUC = Integer.Parse(obj.HALLAR_SUCURSAL(COD_AUX0, COD_COMP0))
        Catch ex As Exception
            COD_SUC = 1
        End Try
        Try
            Dim CMD As New SqlCommand("MOSTRAR_I_COBRANZA_CANC", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUC.ToString("0000")
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            DGW_CANC.DataSource = DT
            DGW_CANC.Columns.Item(0).Visible = False
            DGW_CANC.Columns.Item(12).Visible = False
            DGW_CANC.Columns.Item(16).Visible = False
            DGW_CANC.Columns.Item(17).Visible = False
            DGW_CANC.Columns.Item(1).Width = &H55
            DGW_CANC.Columns.Item(2).Width = &H34
            DGW_CANC.Columns.Item(3).Width = 180
            DGW_CANC.Columns.Item(4).Width = &H5F
            DGW_CANC.Columns.Item(5).Visible = False   'DGW_CANC.Columns.Item(5).Width = &H55
            DGW_CANC.Columns.Item(6).Width = 80
            DGW_CANC.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_CANC.Columns.Item(6).DefaultCellStyle.Format = "N2"
            DGW_CANC.Columns.Item(7).Width = 70
            DGW_CANC.Columns.Item(7).DefaultCellStyle.Format = "d"
            DGW_CANC.Columns.Item(8).Visible = False    'DGW_CANC.Columns.Item(8).Width = 30
            DGW_CANC.Columns.Item(9).Visible = False 'DGW_CANC.Columns.Item(9).Width = 80
            DGW_CANC.Columns.Item(10).Visible = False 'DGW_CANC.Columns.Item(10).Width = 30
            DGW_CANC.Columns.Item(11).Visible = False 'DGW_CANC.Columns.Item(11).Width = &H55
            DGW_CANC.Columns.Item(13).Width = 35
            DGW_CANC.Columns.Item(14).Width = &H4B
            DGW_CANC.Columns.Item(15).Width = &H4B
            DGW_CANC.Columns.Item(15).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
        End If
    End Sub

    Private Sub cbo_aux0_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux0.SelectedIndexChanged
        If (cbo_aux0.SelectedIndex <> -1) Then
            COD_AUX0 = obj.COD_AUX(cbo_aux0.Text)
            CBO_COMPROBANTE0()
        End If
    End Sub

    Public Sub CBO_AUXILIAR()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
                cbo_aux0.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cbo_com0_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com0.SelectedIndexChanged
        If ((cbo_aux0.SelectedIndex <> -1) And (cbo_com0.SelectedIndex <> -1)) Then
            COD_AUX0 = obj.COD_AUX(cbo_aux0.Text)
            COD_COMP0 = obj.COD_COMP(cbo_com0.Text, COD_AUX0)
            Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX0, COD_COMP0, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp0.Text = NUM0
            CARGAR_PENDIENTES0()
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

    Public Sub CBO_COMPROBANTE0()
        cbo_com0.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com0.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception

            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (cbo_com0.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ch_cadena0_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena0.CheckedChanged
        If ch_cadena0.Checked Then
            DGW_CANC.Sort(DGW_CANC.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra0.Clear()
            btn_buscar0.Enabled = True
            btn_sgt0.Enabled = False
            txt_letra0.Focus()
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

    Private Sub ch_doc0_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc0.CheckedChanged
        If ch_doc0.Checked Then
            DGW_CANC.Sort(DGW_CANC.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra0.Clear()
            btn_buscar0.Enabled = False
            btn_sgt0.Enabled = False
            txt_letra0.Focus()
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

    Private Sub ch_per0_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per0.CheckedChanged
        If ch_per0.Checked Then
            DGW_CANC.Sort(DGW_CANC.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra0.Clear()
            btn_buscar0.Enabled = False
            btn_sgt0.Enabled = False
            txt_letra0.Focus()
        End If
    End Sub

    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked Then
            DGW2.Sort(DGW2.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch0_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch0.CheckedChanged

        If ((TXT_CUENTA.Text.Trim <> "") AndAlso obj.VERIFICAR_CUENTA(TXT_CUENTA.Text, AÑO) = False) Then
            MessageBox.Show("La Cuenta no existe en el Plan de Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim i As Integer = 0
            Dim cont As Integer = (DGW_CANC.RowCount - 1)
            i = 0
            Do While (i <= cont)
                DGW_CANC.Item(8, i).Value = ch0.Checked
                If ch0.Checked Then
                    DGW_CANC.Item(9, i).Value = TXT_CUENTA.Text.ToString
                Else
                    DGW_CANC.Item(9, i).Value = ""
                End If
                i += 1
            Loop
        End If
    End Sub

    Public Sub CREAR_DATASET()
        DT_DET.Columns.Add("FE_AÑO")
        DT_DET.Columns.Add("FE_MES")
        DT_DET.Columns.Add("COD_AUX")
        DT_DET.Columns.Add("COD_COMP")
        DT_DET.Columns.Add("NRO_COMP")
        DT_DET.Columns.Add("COD_DOC")
        DT_DET.Columns.Add("NRO_DOC")
        DT_DET.Columns.Add("COD_PER")
        DT_DET.Columns.Add("NRO_DOC_PER")
        DT_DET.Columns.Add("ITEM")
        DT_DET.Columns.Add("FECHA_DOC")
        DT_DET.Columns.Add("COD_REF")
        DT_DET.Columns.Add("NRO_REF")
        DT_DET.Columns.Add("FECHA_REF")
        DT_DET.Columns.Add("GLOSA")
        DT_DET.Columns.Add("COD_CTA")
        DT_DET.Columns.Add("IMP_S")
        DT_DET.Columns.Add("IMP_D")
        DT_DET.Columns.Add("COD_D_H")
        DT_DET.Columns.Add("COD_MONEDA")
        DT_DET.Columns.Add("TIPO_CAMBIO")
        DT_DET.Columns.Add("COD_CC")
        DT_DET.Columns.Add("COD_CONTROL")
        DT_DET.Columns.Add("COD_PROYECTO")
        DT_DET.Columns.Add("NRO_ORDEN")
        DT_DET.Columns.Add("FECHA_VEN")
        DT_DET.Columns.Add("STATUS_PRECIO")
        DT_DET.Columns.Add("CUENTA_ENLACE")
        DT_DET.Columns.Add("CUENTA_DESTINO")
        DT_DET.Columns.Add("STATUS_AUTO")
        DT_DET.Columns.Add("TIPO_TRANS")
        DT_DET.Columns.Add("STATUS_ANALISIS")
        DT_DET.Columns.Add("STATUS_PAGO")
        DT_DET.Columns.Add("COD_MP")
        DT_DET.Columns.Add("NRO_MP")
        DT_DET.Columns.Add("FECHA_MP")
        DT_DET.Columns.Add("ITEM_PAGO")
        DT_DET.Columns.Add("COD_BANCO_DEST")
        DT_DET.Columns.Add("STATUS_TRANS")
        DT_DET.Columns.Add("FECHA_COM")
        DT_DET.Columns.Add("POR_IGV")
        DT_DET.Columns.Add("NOMBRE_PC")
    End Sub

    Private Sub DGW_CANC_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW_CANC.CellClick
        If (DGW_CANC.CurrentCellAddress.X = 8) Then
            If DGW_CANC.Item(8, DGW_CANC.CurrentRow.Index).Value.ToString = "False" Then
                DGW_CANC.Item(8, DGW_CANC.CurrentRow.Index).Value = True
                DGW_CANC.Item(9, DGW_CANC.CurrentRow.Index).Value = TXT_CUENTA.Text.ToString
            Else
                DGW_CANC.Item(8, DGW_CANC.CurrentRow.Index).Value = False
                DGW_CANC.Item(9, DGW_CANC.CurrentRow.Index).Value = ""
            End If
        End If
    End Sub

    Public Sub DOC_STATUS()
        Try
            Dim pro_02 As New SqlCommand("CAMBIAR_STATUS_COBRANZA", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            CON_GCO.Open()
            Dim I As Integer
            For I = 0 To DGW_CANC.RowCount - 1
                pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_CANC.Item(18, I).Value.ToString
                pro_02.Parameters.Add("@FECHA_CAMBIO", SqlDbType.DateTime).Value = Date.Now
                pro_02.Parameters.Add("@ST", SqlDbType.Char).Value = "1"
                pro_02.ExecuteNonQuery()
                pro_02.Parameters.Clear()
            Next
            CON_GCO.Close()
        Catch ex As Exception
            CON_GCO.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GENERACION_COI_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(44) = 0
    End Sub

    Public Function INSERTAR_TODO0() As String
        Dim estado As String = "FALLO"
        '----------------------------------------------------------
        Dim SOLES_DEBE, SOLES_HABER, SOLESC, DOLARESC As Decimal
        SOLES_DEBE = 0 : SOLES_HABER = 0
        '----------------------------------------------------------
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_canc2.RowCount - 1)
        CONTGC = CONT
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            CONTGS = I
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            Dim STATUS00 As String
            Dim VAR_PRO00 As String
            If dgw_canc2.Item(9, I).Value.ToString = "S" Then
                SOLES = Math.Round(Decimal.Parse((dgw_canc2.Item(8, I).Value)), 2)
                DOLARES = Math.Round(Decimal.Divide(Decimal.Parse((dgw_canc2.Item(8, I).Value)), Decimal.Parse((dgw_canc2.Item(10, I).Value))), 2)
            Else
                DOLARES = Math.Round(Decimal.Parse((dgw_canc2.Item(8, I).Value)), 2)
                SOLES = Math.Round(Decimal.Multiply(Decimal.Parse((dgw_canc2.Item(8, I).Value)), Decimal.Parse((dgw_canc2.Item(10, I).Value))), 2)
            End If
            '----------------------------------------------------------
            If dgw_canc2.Item(7, I).Value = "D" Then
                SOLES_DEBE = SOLES_DEBE + SOLES
            Else
                SOLES_HABER = SOLES_HABER + SOLES
            End If
            '----------------------------------------------------------
            If (Strings.Trim(dgw_canc2.Item(0, I).Value.ToString) <> "") Then
                STATUS00 = "1"
                VAR_PRO00 = "0"
            Else
                STATUS00 = "0"
                VAR_PRO00 = dgw_canc2.Item(21, I).Value.ToString
            End If
            If dgw_canc2.Item(11, I).Value = "COBRANZA DE DOCUMENTO" Then
                SOLESC += SOLES
                DOLARESC += DOLARES
            End If
            If CONTGC = CONTGS Then
                DT_DET.Rows.Add(AÑO, MES, COD_AUX0, COD_COMP0, txt_nro_comp0.Text, (dgw_canc2.Item(1, I).Value), (dgw_canc2.Item(2, I).Value), (dgw_canc2.Item(4, I).Value), (dgw_canc2.Item(6, I).Value), (I + 1).ToString("0000"), (dgw_canc2.Item(3, I).Value), (dgw_canc2.Item(22, I).Value), (dgw_canc2.Item(23, I).Value), (dgw_canc2.Item(24, I).Value), (dgw_canc2.Item(11, I).Value), (dgw_canc2.Item(12, I).Value), SOLESC, DOLARESC, (dgw_canc2.Item(7, I).Value), (dgw_canc2.Item(9, I).Value), (dgw_canc2.Item(10, I).Value), (dgw_canc2.Item(13, I).Value), (dgw_canc2.Item(14, I).Value), (dgw_canc2.Item(15, I).Value), " ", (dgw_canc2.Item(17, I).Value), "0", "", "", "0", VAR_PRO00, "0", STATUS00, (dgw_canc2.Item(0, I).Value), "", (dgw_canc2.Item(3, I).Value), (dgw_canc2.Item(25, I).Value), "", VAR_PRO00, dtp_com0.Value, 0, NOMBRE_PC)
            ElseIf dgw_canc2.Item(11, I).Value <> "COBRANZA DE DOCUMENTO" Then
                DT_DET.Rows.Add(AÑO, MES, COD_AUX0, COD_COMP0, txt_nro_comp0.Text, (dgw_canc2.Item(1, I).Value), (dgw_canc2.Item(2, I).Value), (dgw_canc2.Item(4, I).Value), (dgw_canc2.Item(6, I).Value), (I + 1).ToString("0000"), (dgw_canc2.Item(3, I).Value), (dgw_canc2.Item(22, I).Value), (dgw_canc2.Item(23, I).Value), (dgw_canc2.Item(24, I).Value), (dgw_canc2.Item(11, I).Value), (dgw_canc2.Item(12, I).Value), SOLES, DOLARES, (dgw_canc2.Item(7, I).Value), (dgw_canc2.Item(9, I).Value), (dgw_canc2.Item(10, I).Value), (dgw_canc2.Item(13, I).Value), (dgw_canc2.Item(14, I).Value), (dgw_canc2.Item(15, I).Value), " ", (dgw_canc2.Item(17, I).Value), "0", "", "", "0", VAR_PRO00, "0", STATUS00, (dgw_canc2.Item(0, I).Value), "", (dgw_canc2.Item(3, I).Value), (dgw_canc2.Item(25, I).Value), "", VAR_PRO00, dtp_com0.Value, 0, NOMBRE_PC)
            Else

            End If
            I += 1
        Loop
        '------------------------------------------------------------------------------------------
        ' REGISTRO DE AJUSTE
        Dim IMP_AJUSTE As Decimal = SOLES_DEBE - SOLES_HABER
        If IMP_AJUSTE <> 0 Then
            Dim DH As String = "H"
            Dim CTA As String = obj.DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
            If IMP_AJUSTE < 0 Then
                DH = "D"
                IMP_AJUSTE = IMP_AJUSTE * -1
                CTA = obj.DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX0, COD_COMP0, txt_nro_comp0.Text, "00", "", COD_PER, DOC_PER, (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_PLA, "", "", FECHA_PLA, "REDONDEO", CTA, IMP_AJUSTE, 0, DH, "A", TIPO_CAMBIO, "", "", "", "", FECHA_PLA, "0", "", "", "0", "", "", "", "", "", FECHA_PLA, 0, "", "A", dtp_com.Value, 0, NOMBRE_PC)
            'DT_DET.Colu    AÑO MES COD_AUX COD_COMP        NRO_COMP     COD_DOC NRO COD_PER NRO_DOC_PER         ITEM                             FECHA_DOC     REF NRO  FECHA_REF      GLOSA   COD_CTA  IMP_S       D D_H  MON   CAMBIO      CC CONT PROY ORD VEN PV ENL DEST AUTO TRA ANA PAGO MP NRO FECHA_MP   PAGO  DEST TRANS FECHA_COM POR_IGV NOMBRE_PC")
        End If
        '------------------------------------------------------------------------------------------
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.T_CON2"
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
            Return estado
        End Try

        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_CXP_COBRANZA", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX0
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP0
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp0.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com0.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            con.Open()
            estado = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
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
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
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
            Dim CONT1 As Integer = (DGW2.RowCount - 1)
            i = 0
            Do While (i <= CONT1)
                If (txt_letra2.Text.ToLower = Strings.Mid((DGW2.Item(7, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    DGW2.CurrentCell = DGW2.Rows.Item(i).Cells.Item(7)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Public Function VALIDAR_IMPORTE0() As Boolean
        Dim SOLESD As New Decimal
        Dim DOLARESD As New Decimal
        Dim SOLESH As New Decimal
        Dim DOLARESH As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_canc2.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            If dgw_canc2.Item(9, I).Value = "S" Then
                SOLES = Math.Round(Decimal.Parse((dgw_canc2.Item(8, I).Value)), 2)
                DOLARES = Math.Round(Decimal.Divide(Decimal.Parse((dgw_canc2.Item(8, I).Value)), Decimal.Parse((dgw_canc2.Item(10, I).Value))), 2)
            Else
                DOLARES = Math.Round(Decimal.Parse((dgw_canc2.Item(8, I).Value)), 2)
                SOLES = Math.Round(Decimal.Multiply(Decimal.Parse((dgw_canc2.Item(8, I).Value)), Decimal.Parse((dgw_canc2.Item(10, I).Value))), 2)
            End If
            If (dgw_canc2.Item(7, I).Value.ToString = "D") Then
                SOLESD = Decimal.Add(SOLESD, SOLES)
                DOLARESD = Decimal.Add(DOLARESD, DOLARES)
            Else
                SOLESH = Decimal.Add(SOLESH, SOLES)
                DOLARESH = Decimal.Add(DOLARESH, DOLARES)
            End If
            I += 1
        Loop
        If SOLESH = SOLESD Then
            Return True
        Else
            If DOLARESD = DOLARESH Then
                Return True
            ElseIf -0.5 <= (DOLARESD - DOLARESH) <= 0.5 Then
                Return True
            Else
                Return False
            End If
        End If
        'Return ((Decimal.Compare(SOLESH, SOLESD) = 0) AndAlso ((Decimal.Compare(DOLARESD, DOLARESH) = 0) OrElse (CDbl(-((-0.5 <= Convert.ToDouble(Decimal.Subtract(DOLARESD, DOLARESH))) > False)) <= 0.5)))
    End Function

    Public Function VERIFICAR_PERSONA() As Boolean
        Dim I As Integer = 0
        Try
            Dim comand1 As New SqlCommand("VERIFICAR_PERSONA_TRANSF", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
            comand1.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = DESC_PER
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DOC_PER
            con.Open()
            I = Integer.Parse(comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (I > 0) Then
            Return True
        End If
        MessageBox.Show(String.Concat(New String() {"No existen en el Maestro de Personas: " & vbCrLf, COD_PER, " ", DESC_PER, " ", DOC_PER}), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Private Sub FrmCobranza_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CREAR_DATASET()
        CBO_AUXILIAR()
        dtp_com0.Value = FECHA_GRAL
        dtp_com.Value = FECHA_GRAL
        Dim emp00 As String = obj.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = String.Concat(New String() {"data source=", nombre_servidor, ";initial catalog=BD_GCO", emp00, ";uid=miguel;pwd=main;"})
        'DGW1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
        CARGAR_CERRADAS(Now.Date.Year, Now.Date.Month, Now.Date.Day)
        DGW_CANC.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        'DGW1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        TXT_CUENTA.Text = obj.DIR_TABLA_DESC("CTACOB", "TDEFA")
    End Sub

    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        Try
            Dim pro_02 As New SqlCommand("CAMBIAR_STATUS_COBRANZA", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            CON_GCO.Open()
            Dim I As Integer
            For I = 0 To DGW2.RowCount - 1
                pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW2.Item(18, I).Value.ToString
                pro_02.Parameters.Add("@FECHA_CAMBIO", SqlDbType.DateTime).Value = Date.Now
                pro_02.Parameters.Add("@ST", SqlDbType.Char).Value = "0"
                pro_02.ExecuteNonQuery()
                pro_02.Parameters.Clear()
            Next
            CON_GCO.Close()
        Catch ex As Exception
            CON_GCO.Close()
            MsgBox(ex.Message)
        End Try
        MessageBox.Show("Las Facturas fueron destransferidas con Éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CARGAR_CERRADAS(dtpCancelarTrans.Value.Year, dtpCancelarTrans.Value.Month, dtpCancelarTrans.Value.Day)
    End Sub

    Private Sub dtpCancelarTrans_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCancelarTrans.ValueChanged
        CARGAR_CERRADAS(dtpCancelarTrans.Value.Year, dtpCancelarTrans.Value.Month, dtpCancelarTrans.Value.Day)
    End Sub
End Class