Imports System.Data.SqlClient
Imports System.Text
Public Class GCO_TRANSF_FFIJO
    Dim COD_AUX, COD_SUC, COD_PER, COD_MONEDA, COD_DOC, COD_DH_DOC, COD_COMP2, COD_COMP, COD_CLASE, COD_AUX2, DESC_MP, COD_MP, MONEDA_PLA, NRO_MP, NRO_MP_PLA, CodigoBienes As String
    Dim cod_suc0, fila1, fila2 As Integer
    Dim CON_GCO As New SqlConnection
    Dim CUENTA_CANC, TIPO_PLA, TIPO_DET, STATUS_PAGO0, ORDEN_TOTAL, ORDEN_IGV, CUENTA_IGV, CUENTA_TOTAL, DESC_PER, DOC_PER, NRO_DOC, NRO_PLA As String
    Dim DT_DET As New DataTable
    Dim DT_DOC As New DataTable
    Dim FECHA_DOC, FECHA_PLA As DateTime
    Dim FECHA_VEN As DateTime
    Dim IGV0, IMP_IGV, COMP_TOTAL, IMP_TOTAL, TCAMBIO, TCAMBIO_CANC As Decimal
    Dim fec_pla As Date
    Dim OBJ As New Class1
    Dim SB As New StringBuilder
    Private ConfigDoc As String
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        TCAMBIO_CANC = OBJ.SACAR_CAMBIO(dtp_com.Value.Year, dtp_com.Value.ToString("MM"), dtp_com.Value.ToString("dd"), "D")
        If TCAMBIO_CANC = 0 Then
            MessageBox.Show("No existe Tipo de Cambio para la fecha del Comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp.Focus()
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (cbo_aux2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux2.Focus()
        ElseIf (cbo_com2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com2.Focus()
        ElseIf (txt_nro_comp2.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp2.Focus()
        ElseIf (ORDEN_IGV Is Nothing) Then
            MessageBox.Show("La cuenta de IGV no tiene Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf String.IsNullOrEmpty(txt_ope.Text) Then
            MessageBox.Show("Verifique el número de operación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            TIPO_DET = "N"
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_PLA.RowCount - 1)
            I = 0
            Do While (I <= CONT)
                If DGW_PLA.Item(11, I).Value.ToString = "True" Then
                    '-------------------------------------------
                    dgw_mov1.Rows.Clear()
                    dgw_det_01.Rows.Clear()
                    dgw_doc_01.Rows.Clear()
                    '-------------------------------------------
                    If OBJ.VERIFICAR_CUENTA(DGW_PLA.Item(10, I).Value.ToString, AÑO) = False Then
                        MessageBox.Show(("La Cuenta Contable : " & DGW_PLA.Item(10, I).Value.ToString & " no existe."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    TIPO_PLA = "F"
                    CUENTA_CANC = DGW_PLA.Item(10, I).Value.ToString
                    If (DGW_PLA.Item(0, I).Value.ToString = "Rendiciones") Then
                        TIPO_PLA = "R"
                    End If
                    NRO_PLA = (DGW_PLA.Item(3, I).Value)
                    NRO_MP_PLA = (DGW_PLA.Item(13, I).Value)
                    COMP_TOTAL = (DGW_PLA.Item(8, I).Value)
                    fec_pla = (DGW_PLA.Item(5, I).Value)
                    CARGAR_DOC_PLANILLA((DGW_PLA.Item(1, I).Value), NRO_PLA, TIPO_PLA)
                    Dim I2 As Integer = 0
                    Dim CONT2 As Integer = (dgw1.Rows.Count - 1)
                    I2 = 0
                    Do While (I2 <= CONT2)
                        COD_DOC = dgw1.Item(4, I2).Value.ToString
                        NRO_DOC = dgw1.Item(5, I2).Value.ToString
                        COD_MONEDA = dgw1.Item(13, I2).Value.ToString
                        COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                        If (COD_DH_DOC = "D") Then
                            COD_DH_DOC = "H"
                        Else
                            COD_DH_DOC = "D"
                        End If
                        COD_PER = dgw1.Item(6, I2).Value.ToString
                        DESC_PER = dgw1.Item(7, I2).Value.ToString
                        DOC_PER = dgw1.Item(8, I2).Value.ToString
                        COD_CLASE = dgw1.Item(2, I2).Value.ToString
                        FECHA_DOC = DateTime.Parse(dgw1.Item(11, I2).Value.ToString)
                        FECHA_VEN = DateTime.Parse(dgw1.Item(12, I2).Value.ToString)
                        IMP_TOTAL = Decimal.Parse(dgw1.Item(9, I2).Value.ToString)
                        IMP_IGV = Decimal.Parse((dgw1.Item(21, I2).Value))
                        TCAMBIO = Decimal.Parse((dgw1.Item(14, I2).Value))
                        If TCAMBIO = 0 Then TCAMBIO = 1
                        STATUS_PAGO0 = dgw1.Item(22, I2).Value.ToString
                        CodigoBienes = dgw1.Item(23, I2).Value

                        ConfigDoc = OBJ.GCO_DIR_TABLA_DESC(COD_DOC, "TCDOC", con)
                        DOC_TRANSFERIR(I2, dgw1.Item(19, I2).Value)
                        If VALIDAR_CUENTA_ORDEN() = False Then
                            Return
                        End If
                        INSERTAR_DOCUMENTO()
                        I2 += 1
                    Loop
                    GENERAR_AUTO()
                    I2 = 0
                    Do While (I2 <= CONT2)
                        COD_PER = dgw1.Item(6, I2).Value.ToString
                        DESC_PER = dgw1.Item(7, I2).Value.ToString
                        DOC_PER = dgw1.Item(8, I2).Value.ToString
                        VERIFICAR_PERSONA()
                        I2 += 1
                    Loop
                    If VERIFICAR_CONFIGURACION() = False Then Exit Sub
                    If VERIFICAR_CUENTA() = False Then Exit Sub
                    If (VERIFICAR_ORDEN() = False) Then Exit Sub
                    If VERIFICAR_CC() = False Then Exit Sub
                    'If VERIFICAR_CONTROL = False Then Exit Sub
                    If VERIFICAR_PROYECTO() = False Then Exit Sub
                    If VERIFICAR_AUTO() = False Then Exit Sub
                    '------------------------
                    If (INSERTAR_TODO() = "EXITO") Then
                        DOC_N_STATUS(I)
                        '------------------------------------------
                        dgw_mov1.Rows.Clear()
                        dgw_det_01.Rows.Clear()
                        dgw_doc_01.Rows.Clear()
                        '------------------------------------------
                    Else
                        OBJ.ELIMINAR_TEMPORAL("PCOMP")
                        MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    '-----------------------
                End If
                I += 1
            Loop
            '------------------------------------------------------------------------------------
            'CANCELACIÓN
            '------------------------------------------------------------------------------------
            TIPO_DET = "N"
            Dim I0 As Integer = 0
            Dim CONT0 As Integer = (DGW_PLA.RowCount - 1)
            I0 = 0
            Do While (I0 <= CONT0)
                If DGW_PLA.Item(11, I0).Value.ToString = "True" Then
                    dgw_mov1.Rows.Clear()
                    dgw_det_01.Rows.Clear()
                    dgw_doc_01.Rows.Clear()
                    dgw_mov_pago.Rows.Clear()
                    If OBJ.VERIFICAR_CUENTA(DGW_PLA.Item(10, I0).Value.ToString, AÑO) = False Then
                        MessageBox.Show(("La Cuenta Contable : " & DGW_PLA.Item(10, I0).Value.ToString & " no existe."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    TIPO_PLA = "F"
                    CUENTA_CANC = (DGW_PLA.Item(10, I0).Value)
                    If (DGW_PLA.Item(0, I0).Value.ToString = "Rendiciones") Then
                        TIPO_PLA = "R"
                    End If
                    NRO_PLA = (DGW_PLA.Item(3, I0).Value)
                    FECHA_PLA = DGW_PLA.Item(5, I0).Value
                    MONEDA_PLA = (DGW_PLA.Item(6, I0).Value)
                    DESC_MP = (DGW_PLA.Item(9, I0).Value)
                    NRO_MP = DGW_PLA.Item(13, I0).Value
                    COD_MP = OBJ.COD_MP(DESC_MP)
                    CARGAR_DOC_PLANILLA((DGW_PLA.Item(1, I0).Value), NRO_PLA, TIPO_PLA)
                    Dim I2 As Integer = 0
                    Dim CONT2 As Integer = (dgw1.Rows.Count - 1)
                    I2 = 0
                    Do While (I2 <= CONT2)
                        COD_DOC = dgw1.Item(4, I2).Value.ToString
                        NRO_DOC = dgw1.Item(5, I2).Value.ToString
                        COD_MONEDA = dgw1.Item(13, I2).Value.ToString
                        COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                        If (COD_DH_DOC = "D") Then
                            COD_DH_DOC = "H"
                        Else
                            COD_DH_DOC = "D"
                        End If
                        COD_PER = dgw1.Item(6, I2).Value.ToString
                        DESC_PER = dgw1.Item(7, I2).Value.ToString
                        DOC_PER = dgw1.Item(8, I2).Value.ToString
                        COD_CLASE = dgw1.Item(2, I2).Value.ToString
                        FECHA_DOC = DateTime.Parse(dgw1.Item(11, I2).Value.ToString)
                        FECHA_VEN = DateTime.Parse(dgw1.Item(12, I2).Value.ToString)
                        IMP_TOTAL = Decimal.Parse(dgw1.Item(9, I2).Value.ToString)
                        IMP_IGV = Decimal.Parse((dgw1.Item(21, I2).Value))
                        TCAMBIO = Decimal.Parse((dgw1.Item(14, I2).Value))
                        If TCAMBIO = 0 Then TCAMBIO = 1
                        STATUS_PAGO0 = dgw1.Item(22, I2).Value.ToString
                        DOC_TRANSFERIR(I2, dgw1.Item(19, I2).Value.ToString)
                        If VALIDAR_CUENTA_ORDEN() = False Then
                            Return
                        End If
                        INSERTAR_DOCUMENTO2()
                        I2 += 1
                    Loop
                    I2 = 0
                    Do While (I2 <= CONT2)
                        COD_PER = dgw1.Item(6, I2).Value.ToString
                        DESC_PER = dgw1.Item(7, I2).Value.ToString
                        DOC_PER = dgw1.Item(8, I2).Value.ToString
                        VERIFICAR_PERSONA()
                        I2 += 1
                    Loop
                    If VERIFICAR_CONFIGURACION() = False Then Exit Sub
                    If VERIFICAR_CUENTA() = False Then Exit Sub
                    If (VERIFICAR_ORDEN() = False) Then Exit Sub
                    If VERIFICAR_CC() = False Then Exit Sub
                    'If VERIFICAR_CONTROL = False Then Exit Sub
                    If VERIFICAR_PROYECTO() = False Then Exit Sub
                    If VERIFICAR_AUTO() = False Then Exit Sub
                    '----------------------------------
                    INSERTAR_DGW_PAGO()
                    If (INSERTAR_TODO2() = "EXITO") Then
                        DOC_N_STATUS(I0)
                        dgw_mov1.Rows.Clear()
                        dgw_det_01.Rows.Clear()
                        dgw_doc_01.Rows.Clear()
                        dgw_mov_pago.Rows.Clear()
                    Else
                        OBJ.ELIMINAR_TEMPORAL("PCOMP")
                        MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    '----------------------------------
                End If
                I0 += 1
            Loop
            '--------------------------------
            'Dim a1, a2 As String
            'a1 = cbo_com.Text
            'a2 = cbo_com2.Text
            'cbo_com.SelectedIndex = -1
            'cbo_com2.SelectedIndex = -1
            'cbo_com.Text = a1
            'cbo_com2.Text = a2
            '--------------------------------
            MessageBox.Show("Los Documentos fueron transferidos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CARGAR_PENDIENTES()
            CARGAR_CERRADAS()
        End If
    End Sub

    Sub INSERTAR_DGW_PAGO()
        Dim TOTAL_PAGO As Decimal = 0
        '--------------------------------
        'DETALLES
        '--------------------------------
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.RowCount - 1)
        For I = 0 To CONT
            Dim IMP As Decimal = dgw_det_01.Item(3, I).Value
            If dgw_det_01.Item(6, I).Value = "D" Then IMP = dgw_det_01.Item(4, I).Value
            '----------------------------------------------------------------------
            dgw_mov_pago.Rows.Add(COD_MP, dgw_det_01.Item(20, I).Value.ToString, dgw_det_01.Item(21, I).Value.ToString, FECHA_PLA, dgw_det_01.Item(22, I).Value, "", dgw_det_01.Item(23, I).Value, dgw_det_01.Item(5, I).Value, IMP, dgw_det_01.Item(6, I).Value, TCAMBIO_CANC, dgw_det_01.Item(2, I).Value, dgw_det_01.Item(1, I).Value, dgw_det_01.Item(8, I).Value, dgw_det_01.Item(9, I).Value, dgw_det_01.Item(10, I).Value, "1", dgw_det_01.Item(12, I).Value, "1", "1", "1", "S", "", "", dgw_det_01.Item(19, I).Value, 1, "0")
            If MONEDA_PLA = "D" Then
                TOTAL_PAGO = TOTAL_PAGO + dgw_det_01.Item(4, I).Value
            Else
                TOTAL_PAGO = TOTAL_PAGO + dgw_det_01.Item(3, I).Value
            End If
        Next
        '--------------------------------
        TOTAL_PAGO = Math.Round(TOTAL_PAGO, 2)
        Dim COD_DOC_EQ As String = OBJ.COD_DOC_EQ_MP(COD_MP)
        Dim ITEM0 As String = 1
        Dim CTE As String = "0"
        Dim GLOSA0 As String = "TRANSFERENCIA DE FONDO FIJO."
        If TIPO_PLA = "R" Then GLOSA0 = "TRANSFERENCIA DE RENDICIONES."
        dgw_mov_pago.Rows.Add(COD_MP, COD_DOC_EQ, txt_ope.Text, FECHA_PLA, Me.txt_cod_per01.Text.ToString, "", "", "H", TOTAL_PAGO, MONEDA_PLA, TCAMBIO_CANC, GLOSA0, CUENTA_CANC, " ", " ", " ", "0", FECHA_PLA, "", "", "", "", "00", NRO_MP_PLA, FECHA_PLA, ITEM0, "1")

    End Sub

    Private Sub btn_buscar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar1.Click
        btn_sgt1.Enabled = True
        txt_letra1.Focus()
        Dim CONT0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw1.Item(8, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_letra1.Text.ToLower = Strings.Mid(dgw1.Item(8, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(8)
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

    Function REGRESAR_I_CON(ByVal FILA As Integer) As String
        Dim estado As String = ""
        Dim COD_SUCURSAL As String = DGW2.Item(0, FILA).Value.ToString
        Dim NRO_PLANILLA As String = DGW2.Item(2, FILA).Value.ToString
        Try
            Dim CMD As New SqlCommand("REGRESAR_I_CON_FFIJO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = CInt(COD_SUCURSAL).ToString("00")
            CMD.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = NRO_PLANILLA
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = "00"
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = "00000"
            CMD.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_PLANILLA
            CMD.Parameters.Add("@TIPO_PLA", SqlDbType.Char).Value = TIPO_PLA
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

    Private Sub BTN_CANCELAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CANCELAR.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If DGW2.Item(9, I).Value.ToString = "True" Then
                TIPO_PLA = "F"
                If (DGW2.Item(16, I).Value.ToString = "Rendiciones") Then
                    TIPO_PLA = "R"
                End If
                If REGRESAR_I_CON(I) = "FALLO" Then
                    MessageBox.Show(("El Nº Planilla :" & DGW2.Item(2, DGW2.CurrentRow.Index).Value.ToString), "Ocurrio un error en:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    CARGAR_PENDIENTES()
                    CARGAR_CERRADAS()
                    Exit Sub
                End If
                If REGRESAR_I_FACT(I) = "FALLO" Then
                    MessageBox.Show(("El Nº Planilla :" & DGW2.Item(2, DGW2.CurrentRow.Index).Value.ToString), "Ocurrio un error en:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    CARGAR_PENDIENTES()
                    CARGAR_CERRADAS()
                    Exit Sub
                End If
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
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = fila1
        Do While (i <= CONT)
            Dim CONT1 As Integer = Strings.Len(dgw1.Item(8, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_letra1.Text.ToLower = Strings.Mid(dgw1.Item(8, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(8)
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

    Sub CARGAR_CERRADAS()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_PLA_CERRADA_COI", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            DGW2.DataSource = DT
            DGW2.Columns.Item(0).Visible = False
            DGW2.Columns.Item(8).Visible = False
            DGW2.Columns.Item(1).Width = &H55
            DGW2.Columns.Item(2).Width = 80
            DGW2.Columns.Item(3).Width = 90
            DGW2.Columns.Item(4).Width = &H4B
            DGW2.Columns.Item(4).DefaultCellStyle.Format = "d"
            DGW2.Columns.Item(5).Width = 25
            DGW2.Columns.Item(6).Width = 90
            DGW2.Columns.Item(6).DefaultCellStyle.Format = "N2"
            DGW2.Columns.Item(7).Width = 90
            DGW2.Columns.Item(7).DefaultCellStyle.Format = "N2"
            DGW2.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW2.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW2.Columns.Item(8).Width = 90
            DGW2.Columns.Item(9).Width = 30
            DGW2.Columns.Item(10).Width = &H55
            DGW2.Columns.Item(11).Width = 80
            DGW2.Columns.Item(12).Width = &H4B
            DGW2.Columns.Item(12).DefaultCellStyle.Format = "d"
            DGW2.Columns.Item(13).Width = &H55
            DGW2.Columns.Item(14).Width = 40
            DGW2.Columns.Item(15).Width = &H5F
            DGW2.Columns.Item(16).Width = 70
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Sub CARGAR_DOC_PLANILLA(ByVal COD_SUC0 As Object, ByVal NRO_PLA0 As Object, ByVal TIPO_PLA0 As Object)
        Try
            Dim PROG_01 As New SqlCommand("COI_MOSTRAR_I_PLA_DETALLES", CON_GCO)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC0
            PROG_01.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = NRO_PLA0
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@TIPO_PLA", SqlDbType.Char).Value = TIPO_PLA0
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            PROG_01.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            Dim ADAP As New SqlDataAdapter(PROG_01)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns.Item(0).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub CARGAR_PENDIENTES()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_PLA_PTE_COI", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = cod_suc0.ToString("0000")
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            DGW_PLA.DataSource = DT
            DGW_PLA.Columns.Item(1).Visible = False
            DGW_PLA.Columns.Item(9).Visible = False
            DGW_PLA.Columns.Item(0).Width = 70
            DGW_PLA.Columns.Item(2).Width = 85
            DGW_PLA.Columns.Item(3).Width = 80
            DGW_PLA.Columns.Item(4).Width = 90
            DGW_PLA.Columns.Item(5).Width = 75
            DGW_PLA.Columns.Item(5).DefaultCellStyle.Format = "d"
            DGW_PLA.Columns.Item(6).Width = 25
            DGW_PLA.Columns.Item(7).Width = 90
            DGW_PLA.Columns.Item(7).DefaultCellStyle.Format = "N2"
            DGW_PLA.Columns.Item(8).Width = 90
            DGW_PLA.Columns.Item(8).DefaultCellStyle.Format = "N2"
            DGW_PLA.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_PLA.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_PLA.Columns.Item(10).Width = 80
            DGW_PLA.Columns.Item(11).Width = 30
            DGW_PLA.Columns.Item(12).Width = 85
            DGW_PLA.Columns.Item(13).Width = 80
            DGW_PLA.Columns.Item(14).Width = 75
            DGW_PLA.Columns.Item(14).DefaultCellStyle.Format = "d"
            DGW_PLA.Columns.Item(15).Width = 85
            DGW_PLA.Columns.Item(16).Width = 40
            DGW_PLA.Columns.Item(17).Width = 95
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
        End If
    End Sub

    Private Sub cbo_aux2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux2.SelectedIndexChanged
        If (cbo_aux2.SelectedIndex <> -1) Then
            COD_AUX2 = OBJ.COD_AUX(cbo_aux2.Text)
            CBO_COMPROBANTE2()
        End If
    End Sub

    Sub CBO_AUXILIAR()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
                cbo_aux2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        If ((cbo_aux.SelectedIndex <> -1) And (cbo_com.SelectedIndex <> -1)) Then
            COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
            COD_COMP = OBJ.COD_COMP(cbo_com.Text, COD_AUX)
            cod_suc0 = Integer.Parse(OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP))
            Dim NUM0 As String = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
            CARGAR_PENDIENTES()
        End If
    End Sub

    Private Sub cbo_com2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com2.SelectedIndexChanged
        If ((cbo_aux2.SelectedIndex <> -1) And (cbo_com2.SelectedIndex <> -1)) Then
            COD_AUX2 = OBJ.COD_AUX(cbo_aux2.Text)
            COD_COMP2 = OBJ.COD_COMP(cbo_com2.Text, COD_AUX2)
            Dim NUM0 As String = OBJ.HALLAR_NRO_COMP(COD_AUX2, COD_COMP2, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp2.Text = NUM0
        End If
    End Sub

    Sub CBO_COMPROBANTE()
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

    Sub CBO_COMPROBANTE2()
        cbo_com2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX2
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (cbo_com2.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Function CERRAR_I_FACT(ByVal FILA As Integer) As Object
        Dim estado As String = ""
        Dim COD_SUCURSAL As String = dgw1.Item(0, FILA).Value.ToString
        Dim NRO_PLANILLA As String = dgw1.Item(2, FILA).Value.ToString
        Try
            Dim CMD As New SqlCommand("TRANSFERIR_I_PLA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
            CMD.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = NRO_PLANILLA
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@FECHA_COI", SqlDbType.DateTime).Value = dtp1.Value.Date
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
            dgw1.Sort(dgw1.Columns.Item(8), System.ComponentModel.ListSortDirection.Ascending)
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
            dgw1.Sort(dgw1.Columns.Item(3), System.ComponentModel.ListSortDirection.Ascending)
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
            dgw1.Sort(dgw1.Columns.Item(8), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
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

    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        If OBJ.VERIFICAR_CUENTA(Me.TXT_CUENTA.Text.ToString, AÑO) = False Then
            MessageBox.Show("La Cuenta no existe en el Plan de Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim i As Integer = 0
        Dim cont As Integer = (Me.DGW_PLA.RowCount - 1)
        i = 0
        Do While (i <= cont)
            Me.DGW_PLA.Item(11, i).Value = Me.ch1.Checked
            If Me.ch1.Checked Then
                Me.DGW_PLA.Item(10, i).Value = Me.TXT_CUENTA.Text.ToString
            Else
                Me.DGW_PLA.Item(10, i).Value = ""
            End If
            i += 1
        Loop
    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        'If ch2.Checked Then
        Dim i As Integer = 0
        Dim cont As Integer = (DGW2.Rows.Count - 1)
        i = 0
        Do While (i <= cont)
            DGW2.Item(9, i).Value = ch2.Checked
            i += 1
        Loop
        'End If
    End Sub

    Sub CREAR_DATASET()
        DT_DOC.Columns.Add("FE_AÑO")
        DT_DOC.Columns.Add("FE_MES")
        DT_DOC.Columns.Add("COD_DOC")
        DT_DOC.Columns.Add("NRO_DOC")
        DT_DOC.Columns.Add("COD_PER")
        DT_DOC.Columns.Add("NRO_DOC_PER")
        DT_DOC.Columns.Add("COD_AUX")
        DT_DOC.Columns.Add("COD_COMP")
        DT_DOC.Columns.Add("NRO_COMP")
        DT_DOC.Columns.Add("FECHA_COM")
        DT_DOC.Columns.Add("NOMBRE_PER")
        DT_DOC.Columns.Add("FECHA_DOC")
        DT_DOC.Columns.Add("COD_REF")
        DT_DOC.Columns.Add("NRO_REF")
        DT_DOC.Columns.Add("FECHA_REF")
        DT_DOC.Columns.Add("IMP01")
        DT_DOC.Columns.Add("IMP02")
        DT_DOC.Columns.Add("IMP03")
        DT_DOC.Columns.Add("IMP04")
        DT_DOC.Columns.Add("IMP05")
        DT_DOC.Columns.Add("IMP06")
        DT_DOC.Columns.Add("IMP07")
        DT_DOC.Columns.Add("IMP08")
        DT_DOC.Columns.Add("IMP09")
        DT_DOC.Columns.Add("IMP10")
        DT_DOC.Columns.Add("COD_MONEDA")
        DT_DOC.Columns.Add("TIPO_CAMBIO")
        DT_DOC.Columns.Add("COD_D_H")
        DT_DOC.Columns.Add("NRO_DET")
        DT_DOC.Columns.Add("TASA_DET")
        DT_DOC.Columns.Add("FECHA_DET")
        DT_DOC.Columns.Add("FECHA_PAGO")
        DT_DOC.Columns.Add("STATUS_PAGO")
        DT_DOC.Columns.Add("BASE_REF")
        DT_DOC.Columns.Add("NOMBRE_PC")
        DT_DOC.Columns.Add("IMP_TOTAL")
        DT_DOC.Columns.Add("STATUS_GASTO")
        DT_DOC.Columns.Add("COD_BIENES")
        'DETALLES
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
        DT_DET.Columns.Add("STATUS_CUENTA")
        DT_DET.Columns.Add("COD_MP")
        DT_DET.Columns.Add("NRO_MP")
        DT_DET.Columns.Add("FECHA_MP")
        DT_DET.Columns.Add("ITEM_PAGO")
        DT_DET.Columns.Add("COD_BANCO_DEST")
        DT_DET.Columns.Add("STATUS_TRANS")
        DT_DET.Columns.Add("FECHA_COM")
        DT_DET.Columns.Add("POR_IGV")
        DT_DET.Columns.Add("NOMBRE_PC")
        DT_DET.Columns.Add("ST_REP")
        DT_DET.Columns.Add("COD_ACTIVIDAD")
    End Sub

    Sub DOC_N_STATUS(ByVal indice As Integer)
        'Dim I As Integer = 0
        'Dim CONT As Integer = (DGW_PLA.Rows.Count - 1)
        'I = 0
        'Do While (I <= CONT)
        If DGW_PLA.Item(11, indice).Value.ToString = "True" Then
            COD_SUC = DGW_PLA.Item(1, indice).Value.ToString
            NRO_PLA = DGW_PLA.Item(3, indice).Value.ToString
            TIPO_PLA = "F"
            If (DGW_PLA.Item(0, indice).Value.ToString = "Rendiciones") Then
                TIPO_PLA = "R"
            End If
            Try
                Dim pro_02 As New SqlCommand("COI_PLA_STATUS", CON_GCO)
                pro_02.CommandType = CommandType.StoredProcedure
                pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = CInt(COD_SUC).ToString("0000")
                pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = NRO_PLA
                pro_02.Parameters.Add("@TIPO_PLA", SqlDbType.VarChar).Value = TIPO_PLA
                CON_GCO.Open()
                pro_02.ExecuteNonQuery()
                CON_GCO.Close()
            Catch ex As Exception
                CON_GCO.Close()
                MsgBox(ex.Message)
            End Try
        End If
        'I += 1
        'Loop
    End Sub

    Sub DOC_TRANSFERIR(ByVal FIla As Integer, ByVal TIPO As String)
        dgw_mov1.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("COI_MOSTRAR_T_PLA_DETALLES", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw1.Item(0, FIla).Value.ToString
            pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
            pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
            pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
            pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            pro_02.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
            pro_02.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
            pro_02.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
            pro_02.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = NRO_PLA
            pro_02.Parameters.Add("@TIPO_PLA", SqlDbType.Char).Value = TIPO_PLA
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_mov1.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), _
                rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), _
                rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), _
                rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20), rs2.GetValue(21), rs2.GetValue(22), _
                rs2.GetValue(24), rs2.GetValue(25), rs2.GetValue(26))
                CUENTA_TOTAL = (rs2.GetValue(23))
            Loop
            CON_GCO.Close()
        Catch ex As Exception
            CON_GCO.Close()
            MsgBox(ex.Message)
        End Try
        If (CUENTA_TOTAL Is Nothing) Then
            CUENTA_TOTAL = ""
        End If
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        I = 0
        Dim OrdenBI As String
        Do While (I <= CONT)
            If (dgw_mov1.Item(1, I).Value.ToString <> "") Then
                If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                    OrdenBI = ConfigDoc.Substring(0, 2)
                Else
                    OrdenBI = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "C", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                End If
                dgw_mov1.Item(11, I).Value = OrdenBI
            End If
            I += 1
        Loop
    End Sub

    Private Sub GEN_FACT_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CREAR_DATASET()
        CBO_AUXILIAR()
        Dim emp00 As String = OBJ.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = String.Concat(New String() {"data source=", nombre_servidor, ";initial catalog=BD_GCO", emp00, ";uid=miguel;pwd=main;"})
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        CARGAR_CERRADAS()
        ORDEN_TOTAL = "00"
        dtp_com.Value = FECHA_GRAL
        CUENTA_IGV = OBJ.GCO_DIR_TABLA_DESC("IGVC", "TCTAS", CON_GCO)
        ORDEN_IGV = OBJ.HALLAR_ORDEN_CUENTA("I", AÑO, "C", CUENTA_IGV.Substring(0, 3))
        IGV0 = Decimal.Parse(OBJ.IMPUESTO("IGV"))
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_PLA.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
    End Sub

    Private Sub GENERACION_COI_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(64) = 0
    End Sub

    Sub GENERAR_AUTO()
        Dim cont_r1 As Integer = dgw_det_01.RowCount
        Dim CONT As Integer = (cont_r1 - 1)
        Dim j As Integer = 0
        Do While (j <= CONT)
            Dim var0 As String = (dgw_det_01.Item(0, j).Value)
            Dim var1 As String = (dgw_det_01.Item(1, j).Value)
            Dim var2 As String = (dgw_det_01.Item(2, j).Value)
            Dim var3 As Decimal = Decimal.Parse(dgw_det_01.Item(3, j).Value)
            Dim var4 As Decimal = Decimal.Parse(dgw_det_01.Item(4, j).Value)
            Dim var5 As String = (dgw_det_01.Item(5, j).Value)
            Dim var6 As String = (dgw_det_01.Item(6, j).Value)
            Dim var7 As Decimal = Decimal.Parse(dgw_det_01.Item(7, j).Value)
            Dim var8 As String = (dgw_det_01.Item(8, j).Value)
            Dim var9 As String = (dgw_det_01.Item(9, j).Value)
            Dim var10 As String = (dgw_det_01.Item(10, j).Value)
            Dim var11 As String = (dgw_det_01.Item(11, j).Value)
            Dim var12 As String = (dgw_det_01.Item(12, j).Value)
            Dim var13 As String = (dgw_det_01.Item(13, j).Value)
            Dim var14 As String = (dgw_det_01.Item(14, j).Value)
            Dim var15 As String = (dgw_det_01.Item(15, j).Value)
            Dim var16 As String = (dgw_det_01.Item(16, j).Value)
            Dim var17 As String = (dgw_det_01.Item(17, j).Value)
            Dim var18 As String = (dgw_det_01.Item(18, j).Value)
            Dim var19 As String = (dgw_det_01.Item(19, j).Value)
            Dim var20 As String = (dgw_det_01.Item(20, j).Value)
            Dim var21 As String = (dgw_det_01.Item(21, j).Value)
            Dim var22 As String = (dgw_det_01.Item(22, j).Value)
            Dim var23 As String = (dgw_det_01.Item(23, j).Value)
            Dim var24 As String = (dgw_det_01.Item(24, j).Value)
            If (var14.Length = 8) Then
                Dim cod_enlace As String = ""
                Dim cod_destino As String = ""
                Select Case var5
                    Case "D"
                        cod_enlace = "H"
                        cod_destino = "D"

                    Case "H"
                        cod_enlace = "D"
                        cod_destino = "H"

                End Select
                dgw_det_01.Rows.Add(var0, var14, var2, var3, var4, cod_enlace, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", "0", "0", var24)
                dgw_det_01.Rows.Add(var0, var15, var2, var3, var4, cod_destino, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", "0", "0", var24)
            End If
            j += 1
        Loop
    End Sub

    Sub INSERTAR_DOCUMENTO()
        Dim imp_d_igv As Decimal
        Dim imp_d_t As Decimal
        Dim imp_igv00 As Decimal
        Dim imp_s_igv As Decimal
        Dim imp_s_t As Decimal
        Dim imp_t00 As Decimal
        Dim I As Integer = 0
        Dim cant01 As New Decimal
        Dim cant02 As New Decimal
        Dim cant03 As New Decimal
        Dim cant04 As New Decimal
        Dim cant05 As New Decimal
        Dim cant06 As New Decimal
        Dim cant07 As New Decimal
        Dim cant08 As New Decimal
        Dim cant09 As New Decimal
        Dim cant10 As New Decimal
        Dim COL As Integer = 3
        'If (COD_MONEDA <> "S") Then
        '    COL = 4
        'End If
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        I = 0
        For I = 0 To CONT
            '-------------------------------------------------------
            'DETERMINO EL SIGNO
            Dim SIGNO As Decimal = 1
            If (dgw_mov1.Item(5, I).Value.ToString = COD_DH_DOC) Then
                SIGNO = -1
            End If
            '-------------------------------------------------------
            Dim CONT002 As Object = dgw_mov1.Item(11, I).Value
            Select Case CONT002
                Case "01" : cant01 = cant01 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "02" : cant02 = cant02 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "03" : cant03 = cant03 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "04" : cant04 = cant04 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "05" : cant05 = cant05 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "06" : cant06 = cant06 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "07" : cant07 = cant07 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "08" : cant08 = cant08 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "09" : cant09 = cant09 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
                Case "10" : cant10 = cant10 + Math.Round(dgw_mov1.Item(COL, I).Value * SIGNO, 2)
            End Select
        Next
        '--------------------------------------
        Dim igv00 As Decimal = IMP_IGV
        If COD_MONEDA = "S" Then
        Else
            igv00 = Math.Round(Decimal.Parse(IMP_IGV * TCAMBIO), 2)
        End If
        If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
            ORDEN_IGV = ConfigDoc.Substring(2, 2)
        Else
            ORDEN_IGV = OBJ.HALLAR_ORDEN_CUENTA("I", AÑO, "C", CUENTA_IGV.Substring(0, 3))
        End If

        Select Case ORDEN_IGV
            Case "01" : cant01 = cant01 + igv00
            Case "02" : cant02 = cant02 + igv00
            Case "03" : cant03 = cant03 + igv00
            Case "04" : cant04 = cant04 + igv00
            Case "05" : cant05 = cant05 + igv00
            Case "06" : cant06 = cant06 + igv00
            Case "07" : cant07 = cant07 + igv00
            Case "08" : cant08 = cant08 + igv00
            Case "09" : cant09 = cant09 + igv00
            Case "10" : cant10 = cant10 + igv00
        End Select
        '-------------------------------------------------------
        Dim cte_03 As String = "0"
        cte_03 = "1"
        If (COD_MONEDA = "S") Then
            imp_s_igv = Math.Round(Decimal.Parse(IMP_IGV), 2)
            imp_s_t = Math.Round(Decimal.Parse((cant01 + cant02 + cant03 + cant04 + cant05 + cant06 + cant07 + cant08 + cant09 + cant10)), 2)
            imp_d_igv = Math.Round(Decimal.Parse(IMP_IGV / TCAMBIO), 2)
            imp_d_t = Math.Round(Decimal.Parse(imp_s_t / TCAMBIO), 2)
            cant01 = Math.Round(cant01, 2)
            cant02 = Math.Round(cant02, 2)
            cant03 = Math.Round(cant03, 2)
            cant04 = Math.Round(cant04, 2)
            cant05 = Math.Round(cant05, 2)
            cant06 = Math.Round(cant06, 2)
            cant07 = Math.Round(cant07, 2)
            cant08 = Math.Round(cant08, 2)
            cant09 = Math.Round(cant09, 2)
            cant10 = Math.Round(cant10, 2)
        Else
            imp_d_igv = Math.Round(Decimal.Parse(IMP_IGV), 2)
            imp_s_igv = Math.Round(Decimal.Parse(IMP_IGV * TCAMBIO), 2)
            imp_s_t = Math.Round(Decimal.Parse((cant01 + cant02 + cant03 + cant04 + cant05 + cant06 + cant07 + cant08 + cant09 + cant10)), 2)
            imp_d_t = Math.Round(Decimal.Parse(imp_s_t / TCAMBIO), 2)
            cant01 = Math.Round(cant01, 2)
            cant02 = Math.Round(cant02, 2)
            cant03 = Math.Round(cant03, 2)
            cant04 = Math.Round(cant04, 2)
            cant05 = Math.Round(cant05, 2)
            cant06 = Math.Round(cant06, 2)
            cant07 = Math.Round(cant07, 2)
            cant08 = Math.Round(cant08, 2)
            cant09 = Math.Round(cant09, 2)
            cant10 = Math.Round(cant10, 2)
        End If
        '-------------------------------------------------------
        dgw_doc_01.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp.Text, COD_DOC, NRO_DOC, COD_PER, DESC_PER, DOC_PER, _
            dtp_com.Value, FECHA_DOC, cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, _
            cant10, COD_MONEDA, TCAMBIO, cte_03, COD_DH_DOC, "", 0, FECHA_DOC, "", "", FECHA_DOC, FECHA_DOC, "0", _
            0, imp_s_t, STATUS_PAGO0, CodigoBienes)

        Dim j As Integer = 0
        j = 0
        Do While (j <= CONT)
            Dim var0 As String = (dgw_mov1.Item(0, j).Value)
            Dim var1 As String = (dgw_mov1.Item(1, j).Value)
            Dim var2 As String = (dgw_mov1.Item(2, j).Value)
            Dim var3 As String = (dgw_mov1.Item(3, j).Value)
            Dim var4 As String = (dgw_mov1.Item(4, j).Value)
            Dim var5 As String = (dgw_mov1.Item(5, j).Value)
            Dim var6 As String = (dgw_mov1.Item(6, j).Value)
            Dim var7 As String = (dgw_mov1.Item(7, j).Value)
            Dim var8 As String = (dgw_mov1.Item(8, j).Value)
            Dim var9 As String = (dgw_mov1.Item(9, j).Value)
            Dim var10 As String = (dgw_mov1.Item(10, j).Value)
            Dim var11 As String = (dgw_mov1.Item(11, j).Value)
            Dim var12 As DateTime = Date.Parse(dgw_mov1.Item(12, j).Value)
            Dim var13 As String = (dgw_mov1.Item(13, j).Value)
            Dim var14 As String = (dgw_mov1.Item(14, j).Value)
            Dim var15 As String = (dgw_mov1.Item(15, j).Value)
            Dim var16 As String = (dgw_mov1.Item(16, j).Value)
            Dim var17 As String = (dgw_mov1.Item(17, j).Value)
            Dim var18 As String = (dgw_mov1.Item(18, j).Value)
            Dim var19 As DateTime = Date.Parse(dgw_mov1.Item(19, j).Value)
            Dim var20 As String = (dgw_mov1.Item(20, j).Value)
            Dim var21 As String = (dgw_mov1.Item(21, j).Value)
            Dim var22 As String = (dgw_mov1.Item(22, j).Value)
            Dim var23 As String = dgw_mov1.Item(23, j).Value.ToString
            Dim var24 As String = dgw_mov1.Item(24, j).Value.ToString
            Dim var26 As String = dgw_mov1.Item(25, j).Value.ToString 'cod_actividad
            Dim imp_doc00 As New Decimal
            imp_doc00 = Decimal.Parse(var3)
            If (var6 <> "S") Then
                imp_doc00 = Decimal.Parse(var4)
            End If
            dgw_det_01.Rows.Add(var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, var15, var16, var17, var18, var19, COD_DOC, NRO_DOC, COD_PER, DOC_PER, "0", "B", var20, var21, "0", " ", " ", FECHA_DOC, 0, " ", var22, imp_doc00, "0", "0", var23, var24, var26)
            j += 1
        Loop
        Dim DH_IGV As String = ""
        Dim DH_T As String = ""
        If (COD_DH_DOC = "D") Then
            DH_IGV = "H"
            DH_T = "D"
        ElseIf (COD_DH_DOC = "H") Then
            DH_IGV = "D"
            DH_T = "H"
        End If
        If (COD_MONEDA = "S") Then
            imp_igv00 = imp_s_igv
            imp_t00 = imp_s_t
        Else
            imp_igv00 = imp_d_igv
            imp_t00 = imp_d_t
        End If
        dgw_det_01.Rows.Add((CONT + 2).ToString("0000"), CUENTA_IGV, DESC_PER, Math.Round(imp_s_igv, 2), _
            Math.Round(imp_d_igv, 2), DH_IGV, COD_MONEDA, TCAMBIO, " ", " ", " ", ORDEN_IGV, FECHA_VEN, 0, _
            " ", " ", " ", " ", " ", FECHA_DOC, COD_DOC, NRO_DOC, COD_PER, DOC_PER, 0, "I", "", "", "0", _
            " ", " ", FECHA_DOC, 0, " ", 0, imp_igv00, "0", "0", "0", DESC_PER)
        dgw_det_01.Rows.Add((CONT + 3).ToString("0000"), CUENTA_TOTAL, DESC_PER, Math.Round(imp_s_t, 2), _
            Math.Round(imp_d_t, 2), DH_T, COD_MONEDA, TCAMBIO, " ", " ", " ", ORDEN_TOTAL, FECHA_VEN, 0, _
            " ", " ", " ", " ", " ", FECHA_DOC, COD_DOC, NRO_DOC, COD_PER, DOC_PER, 0, "T", "", "", "0", _
            " ", " ", FECHA_DOC, 0, " ", 0, imp_t00, "0", "0", "0", DESC_PER)

    End Sub

    Sub INSERTAR_DOCUMENTO2()
        Dim imp_d_t As Decimal
        Dim imp_s_t As Decimal
        Dim imp_t00 As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            imp_s_t = imp_s_t + dgw_mov1.Item(3, I).Value
            imp_d_t = imp_d_t + dgw_mov1.Item(4, I).Value
            I += 1
        Loop
        If COD_MONEDA = "D" Then
            imp_s_t = imp_s_t + (IMP_IGV * TCAMBIO)
            imp_d_t = imp_d_t + IMP_IGV
        Else
            imp_s_t = imp_s_t + IMP_IGV
            imp_d_t = imp_d_t + (IMP_IGV / TCAMBIO)
        End If
        Dim cte_03 As String = "1"
        Dim DH_IGV As String = ""
        Dim DH_T As String = ""
        If (COD_DH_DOC = "D") Then
            DH_T = "H"
        ElseIf (COD_DH_DOC = "H") Then
            DH_T = "D"
        End If
        If (COD_MONEDA = "D") Then
            imp_t00 = imp_d_t
        Else
            imp_t00 = imp_s_t
        End If
        dgw_det_01.Rows.Add((CONT + 3).ToString("0000"), CUENTA_TOTAL, DESC_PER, Math.Round(imp_s_t, 2), _
            Math.Round(imp_d_t, 2), DH_T, COD_MONEDA, TCAMBIO, " ", " ", " ", ORDEN_TOTAL, FECHA_VEN, 0, " ", _
            " ", " ", " ", " ", FECHA_DOC, COD_DOC, NRO_DOC, COD_PER, DOC_PER, 0, "T", "", "", "0", " ", " ", _
            FECHA_DOC, 0, " ", 0, imp_t00, "0", "0", "0", DESC_PER)

    End Sub

    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.Rows.Count - 1)
        DT_DOC.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            DT_DOC.Rows.Add(AÑO, MES, dgw_doc_01.Item(3, I).Value, dgw_doc_01.Item(4, I).Value, dgw_doc_01.Item(5, I).Value, _
            dgw_doc_01.Item(7, I).Value, COD_AUX, COD_COMP, txt_nro_comp.Text, dtp_com.Value, dgw_doc_01.Item(6, I).Value, _
            DateTime.Parse(dgw_doc_01.Item(9, I).Value), "", "", DateTime.Parse(dgw_doc_01.Item(9, I).Value), _
            Decimal.Parse(dgw_doc_01.Item(10, I).Value), Decimal.Parse(dgw_doc_01.Item(11, I).Value), _
            Decimal.Parse(dgw_doc_01.Item(12, I).Value), Decimal.Parse(dgw_doc_01.Item(13, I).Value), _
            Decimal.Parse(dgw_doc_01.Item(14, I).Value), Decimal.Parse(dgw_doc_01.Item(15, I).Value), _
            Decimal.Parse(dgw_doc_01.Item(16, I).Value), Decimal.Parse(dgw_doc_01.Item(17, I).Value), _
            Decimal.Parse(dgw_doc_01.Item(18, I).Value), Decimal.Parse(dgw_doc_01.Item(19, I).Value), _
            dgw_doc_01.Item(20, I).Value, Decimal.Parse(dgw_doc_01.Item(21, I).Value), dgw_doc_01.Item(23, I).Value, _
            dgw_doc_01.Item(24, I).Value, dgw_doc_01.Item(25, I).Value, DateTime.Parse(dgw_doc_01.Item(26, I).Value), _
            DateTime.Parse(dgw_doc_01.Item(30, I).Value), dgw_doc_01.Item(31, I).Value, dgw_doc_01.Item(32, I).Value, _
            NOMBRE_PC, (dgw_doc_01.Item(33, I).Value), dgw_doc_01.Item(34, I).Value, dgw_doc_01.Item(35, I).Value)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.REGISTRO_COMPRAS2"
            sqlbc.WriteToServer(DT_DOC)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
            Return estado
        End Try
        I = 0
        CONT = (dgw_det_01.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            'DateTime.Parse((dgw_det_01.Item(19, I).Value))
            Dim cod_act00 As String
            Try
                cod_act00 = dgw_det_01.Item(40, I).Value.ToString

            Catch ex As Exception
                cod_act00 = ""
            End Try
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "00", NRO_PLA, DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC, dgw_det_01.Item(38, I).Value.ToString, cod_act00)
            I += 1
        Loop
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
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_FFIJO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@TIPO_DET", SqlDbType.VarChar).Value = TIPO_DET
            comand1.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = NRO_PLA
            comand1.Parameters.Add("@TIPO_PLA", SqlDbType.VarChar).Value = TIPO_PLA
            con.Open()
            estado = comand1.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function

    Function INSERTAR_TODO2() As String
        Dim ESTADO As String = "FALLO"
        Dim BULK As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov_pago.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            Dim VAR_PRO00 As String
            If dgw_mov_pago.Item(9, I).Value = "S" Then
                SOLES = Math.Round(Decimal.Parse((dgw_mov_pago.Item(8, I).Value)), 2)
                DOLARES = Math.Round(Decimal.Divide(Decimal.Parse((dgw_mov_pago.Item(8, I).Value)), Decimal.Parse((dgw_mov_pago.Item(10, I).Value))), 2)
            Else
                DOLARES = Math.Round(Decimal.Parse((dgw_mov_pago.Item(8, I).Value)), 2)
                SOLES = Math.Round(Decimal.Multiply(Decimal.Parse((dgw_mov_pago.Item(8, I).Value)), Decimal.Parse((dgw_mov_pago.Item(10, I).Value))), 2)
            End If
            If (dgw_mov_pago.Item(26, I).Value.ToString = "1") Then
                VAR_PRO00 = "0"
            Else
                VAR_PRO00 = dgw_mov_pago.Item(21, I).Value.ToString
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX2, COD_COMP2, txt_nro_comp2.Text, (dgw_mov_pago.Item(1, I).Value), (dgw_mov_pago.Item(2, I).Value), (dgw_mov_pago.Item(4, I).Value), (dgw_mov_pago.Item(6, I).Value), (I + 1).ToString("0000"), (dgw_mov_pago.Item(3, I).Value), (dgw_mov_pago.Item(22, I).Value), (dgw_mov_pago.Item(23, I).Value), (dgw_mov_pago.Item(24, I).Value), (dgw_mov_pago.Item(11, I).Value), (dgw_mov_pago.Item(12, I).Value), SOLES, DOLARES, (dgw_mov_pago.Item(7, I).Value), (dgw_mov_pago.Item(9, I).Value), (dgw_mov_pago.Item(10, I).Value), (dgw_mov_pago.Item(13, I).Value), (dgw_mov_pago.Item(14, I).Value), (dgw_mov_pago.Item(15, I).Value), " ", (dgw_mov_pago.Item(17, I).Value), IIf(ch_control.Checked, "1", "0"), "", "", "0", VAR_PRO00, "0", dgw_mov_pago.Item(26, I).Value.ToString, (dgw_mov_pago.Item(0, I).Value), dgw_mov_pago.Item(23, I).Value.ToString, (dgw_mov_pago.Item(3, I).Value), (dgw_mov_pago.Item(25, I).Value), "", VAR_PRO00, dtp_com.Value, 0, NOMBRE_PC, "0")
            I += 1
        Loop
        Try
            con.Open()
            BULK.DestinationTableName = "DBO.T_CON2"
            BULK.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
            Return ESTADO
        End Try
        Dim control As String = "0"
        If ch_control.Checked = True Then control = "1"
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_FFIJO_CANC", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX2
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP2
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp2.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@TIPO_DET", SqlDbType.VarChar).Value = TIPO_DET
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = CUENTA_CANC
            comand1.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = "00"
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_ope.Text
            comand1.Parameters.Add("@COMP_TOTAL", SqlDbType.Decimal).Value = COMP_TOTAL
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
            comand1.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = NRO_PLA
            comand1.Parameters.Add("@TIPO_PLA", SqlDbType.VarChar).Value = TIPO_PLA
            comand1.Parameters.Add("@COD_PER0", SqlDbType.VarChar).Value = txt_cod_per01.Text
            comand1.Parameters.Add("@c_control", SqlDbType.VarChar).Value = control
            con.Open()
            'comand1.ExecuteNonQuery()
            ESTADO = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Return ESTADO
    End Function

    Function REGRESAR_FFIJO(ByVal FILA As Integer) As Boolean
        Dim NRO_PLA0 As String = ""
        cod_suc0 = Integer.Parse(DGW2.Item(0, FILA).Value.ToString)
        NRO_PLA0 = DGW2.Item(2, FILA).Value.ToString
        Dim ESTADO As String = "EXITO"
        Try
            Dim comand1 As New SqlCommand("REGRESAR_I_CON_FFIJO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = cod_suc0.ToString("00")
            comand1.Parameters.Add("@NRO_PLANILLA", SqlDbType.VarChar).Value = NRO_PLA0
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = "00"
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_PLA0
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = "00000"
            con.Open()
            ESTADO = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Return (ESTADO = "EXITO")
    End Function

    Function REGRESAR_I_FACT(ByVal FILA As Integer) As Object
        Dim estado As String = ""
        Dim COD_SUCURSAL As String = DGW2.Item(0, FILA).Value.ToString
        Dim NRO_PLANILLA As String = DGW2.Item(2, FILA).Value.ToString
        Try
            Dim CMD As New SqlCommand("COI_PLA_STATUS2", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUCURSAL
            CMD.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = NRO_PLANILLA
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@TIPO_PLA", SqlDbType.Char).Value = TIPO_PLA
            CON_GCO.Open()
            estado = (CMD.ExecuteScalar)
            CON_GCO.Close()
        Catch ex As Exception
            CON_GCO.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function

    Private Sub txt_letra1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra1.TextChanged
        Dim i As Integer
        If ch_doc1.Checked Then
            txt_letra1.Focus()
            Dim CONT As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra1.Text.ToLower = Strings.Mid((dgw1.Item(3, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(3)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per1.Checked Then
            txt_letra1.Focus()
            Dim CONT As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra1.Text.ToLower = Strings.Mid((dgw1.Item(8, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(8)
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
                If (txt_letra2.Text.ToLower = Strings.Mid((DGW2.Item(7, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    DGW2.CurrentCell = DGW2.Rows.Item(i).Cells.Item(7)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Function VALIDAR_CUENTA_ORDEN() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If ((dgw_mov1.Item(1, I).Value.ToString <> "") AndAlso (OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "C", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3)) = "0")) Then
                SB.ToString.Trim((dgw_mov1.Item(1, I).Value.ToString))
                SB.AppendLine(dgw_mov1.Item(1, I).Value.ToString)
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen Orden para la Cuenta Contable : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_AUTO() As Boolean
        Dim CTA0 As String = ""
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim destino As String = dgw_det_01.Item(15, I).Value.ToString
            Dim enlace As String = dgw_det_01.Item(14, I).Value.ToString
            CTA0 = dgw_det_01.Item(1, I).Value.ToString
            If ((((dgw_det_01.Item(25, I).Value.ToString = "B") And (destino.Trim <> "")) And (enlace.Trim <> "")) And (CTA0.Trim <> "")) Then
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_AUTO", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = CTA0
                    comand1.Parameters.Add("@CUENTA_ENLACE", SqlDbType.VarChar).Value = enlace
                    comand1.Parameters.Add("@CUENTA_DESTINO", SqlDbType.VarChar).Value = destino
                    comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.AppendLine(String.Concat(New String() {CTA0, " : ", destino, " ", enlace}))
                    Loop
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existe la configuración del Maestro de Automaticas Cuenta:Destino/Enlace : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_CC() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If ((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(8, I).Value.ToString.Trim <> "")) Then
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CC_TRANSF", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = dgw_det_01.Item(8, I).Value.ToString
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.ToString.Trim(Rs3.GetValue(0))
                        SB.AppendLine(Rs3.GetValue(0))
                    Loop
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen en el Maestro de Centro de Costos : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_CONFIGURACION() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim k1 As String = dgw_det_01.Item(1, I).Value.ToString.Trim
            If (k1 = "") Then
                SB.ToString.Trim(k1)
                SB.AppendLine(String.Concat(New String() {k1, " ", dgw_det_01.Item(2, I).Value.ToString, "  -  ", dgw_det_01.Item(39, I).Value.ToString}))
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existe la configuración Gasto/C.Costos : " & vbCrLf & SB.ToString), "No se puede Transferir.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_CONTROL() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If ((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(9, I).Value.ToString.Trim <> "")) Then
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CONTROL_TRANSF", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_CONTROL", SqlDbType.VarChar).Value = dgw_det_01.Item(9, I).Value.ToString
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.ToString.Trim(Rs3.GetValue(0))
                        SB.AppendLine(Rs3.GetValue(0))
                    Loop
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen en el Maestro de Orden de Producción  : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_CUENTA() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw_det_01.Item(1, I).Value.ToString.Trim <> "") Then
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(1, I).Value.ToString
                    comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.ToString.Trim(Rs3.GetValue(0))
                        SB.AppendLine((Rs3.GetValue(0)) & " " & dgw_det_01.Item(39, I).Value.ToString)
                    Loop
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            If (dgw_det_01.Item(25, I).Value.ToString = "B") Then
                If (dgw_det_01.Item(14, I).Value.ToString.Trim = "") Then
                    Dim k2 As String = dgw_det_01.Item(14, I).Value.ToString
                    Try
                        Dim comand2 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                        comand2.CommandType = CommandType.StoredProcedure
                        comand2.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(14, I).Value.ToString
                        comand2.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                        con.Open()
                        comand2.ExecuteNonQuery()
                        Dim Rs4 As SqlDataReader = comand2.ExecuteReader
                        Do While Rs4.Read
                            SB.ToString.Trim((Rs4.GetValue(0)))
                            SB.AppendLine(Rs4.GetValue(0) & " " & dgw_det_01.Item(39, I).Value.ToString)
                        Loop
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        MsgBox(ex.Message)
                    End Try
                End If
                If (dgw_det_01.Item(15, I).Value.ToString.Trim <> "") Then
                    Dim k3 As String = dgw_det_01.Item(15, I).Value.ToString
                    Try
                        Dim comand2 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                        comand2.CommandType = CommandType.StoredProcedure
                        comand2.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(15, I).Value.ToString
                        comand2.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                        con.Open()
                        comand2.ExecuteNonQuery()
                        Dim Rs4 As SqlDataReader = comand2.ExecuteReader
                        Do While Rs4.Read
                            SB.ToString.Trim((Rs4.GetValue(0)))
                            SB.AppendLine(Rs4.GetValue(0) & " " & dgw_det_01.Item(39, I).Value.ToString)
                        Loop
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen en el Plan de cuentas : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_ORDEN() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim TIPO_ORDEN0 As String = dgw_det_01.Item(25, I).Value.ToString
            If (((TIPO_ORDEN0 = "B") Or (TIPO_ORDEN0 = "I")) AndAlso (dgw_det_01.Item(11, I).Value.ToString = "")) Then
                SB.ToString.Trim((dgw_det_01.Item(1, I).Value.ToString))
                SB.AppendLine((dgw_det_01.Item(1, I).Value.ToString & " De tipo : " & TIPO_ORDEN0))
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen Orden para la Cuenta Contable : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_PERSONA() As Boolean
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

    Function VERIFICAR_PROYECTO() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If ((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(10, I).Value.ToString.Trim <> "")) Then
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_PROYECTO_TRANSF", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_PROYECTO", SqlDbType.VarChar).Value = dgw_det_01.Item(10, I).Value.ToString
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.ToString.Trim(Rs3.GetValue(0))
                        SB.AppendLine(Rs3.GetValue(0))
                    Loop
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen en el Maestro de Proyecto : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Private Sub DGW_PLA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_PLA.CellClick
        If OBJ.VERIFICAR_CUENTA(TXT_CUENTA.Text.ToString, AÑO) = False Or TXT_CUENTA.Text.Trim = "" Then
            MessageBox.Show("La Cuenta no existe en el Plan de Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (DGW_PLA.CurrentCellAddress.X = 11) Then
            If DGW_PLA.Item(11, DGW_PLA.CurrentRow.Index).Value.ToString = "False" Then
                DGW_PLA.Item(11, DGW_PLA.CurrentRow.Index).Value = True
                DGW_PLA.Item(10, DGW_PLA.CurrentRow.Index).Value = TXT_CUENTA.Text.ToString
            Else
                DGW_PLA.Item(11, DGW_PLA.CurrentRow.Index).Value = False
                DGW_PLA.Item(10, DGW_PLA.CurrentRow.Index).Value = ""
            End If
        End If
    End Sub

    Private Sub txt_cod_per01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_cod_per01.TextChanged
        If txt_cod_per01.Text.Length = 5 Then
            Label3.Visible = True
            Label3.Text = OBJ.DESC_PERSONA(txt_cod_per01.Text)
        End If
    End Sub
End Class