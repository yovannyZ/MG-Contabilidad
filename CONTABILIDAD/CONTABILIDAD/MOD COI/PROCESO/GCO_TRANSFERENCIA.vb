Imports System.Data.SqlClient
Imports System.Text
Public Class GCO_TRANSFERENCIA
    Dim COD_CLASE, COD_AUX, STATUS_GASTO, st_pago0, TIPO_DET, ORDEN_TOTAL, ORDEN_IGV, nro_ref0, NRO_DOC, nro_det0, CUENTA_IGV, DOC_PER, DESC_PER, CUENTA_TOTAL, cod_ref0, COD_COMP, COD_DH_DOC, COD_DOC, COD_MONEDA, COD_PER, CodigoBienes As String
    Dim COD_SUC, fila1, fila2 As Integer
    Dim CON_GCO As New SqlConnection
    Dim DT_DET As New DataTable
    Dim DT_DOC As New DataTable
    Dim fecha_det0, FECHA_DOC, fecha_pago0, fecha_ref0, FECHA_VEN As DateTime
    Dim IGV0, IMP_IGV, TCAMBIO, IMP_TOTAL, tasa_det0, AJUSTE0, base_ref0 As Decimal
    Dim OBJ As New Class1
    Dim SB As New StringBuilder
    Private ConfigDoc As String
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If ch1.Checked Then
            If MessageBox.Show("Esta seguro de generar todos los comprobantes", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            Else
                Exit Sub
            End If
        End If
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        If (ORDEN_IGV Is Nothing) Then MessageBox.Show("La cuenta de IGV no tiene Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        '-------------------------------------------------------------------------
        If ch_comp.Checked = False Then
            Dim rspta As String = MessageBox.Show("El Comprobante se está realizando x N documentos.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If rspta = vbNo Then
                Exit Sub
            End If
        End If
        '-------------------------------------------------------------------------
        dgw_mov1.Rows.Clear()
        dgw_det_01.Rows.Clear()
        dgw_doc_01.Rows.Clear()
        If ch_comp.Checked Then
            TIPO_DET = "1"
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw1.RowCount - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                If dgw1.Item(10, I).Value.ToString = "True" Then
                    COD_DOC = dgw1.Item(4, I).Value
                    NRO_DOC = dgw1.Item(5, I).Value
                    COD_MONEDA = dgw1.Item(13, I).Value
                    COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                    If (COD_DH_DOC = "D") Then
                        COD_DH_DOC = "H"
                    Else
                        COD_DH_DOC = "D"
                    End If
                    COD_PER = dgw1.Item(6, I).Value
                    DESC_PER = dgw1.Item(7, I).Value
                    DOC_PER = dgw1.Item(8, I).Value
                    COD_CLASE = dgw1.Item(2, I).Value
                    FECHA_DOC = DateTime.Parse(dgw1.Item(11, I).Value)
                    FECHA_VEN = DateTime.Parse(dgw1.Item(12, I).Value)
                    IMP_TOTAL = Decimal.Parse(dgw1.Item(9, I).Value)
                    IMP_IGV = Decimal.Parse((dgw1.Item(21, I).Value))
                    TCAMBIO = Decimal.Parse((dgw1.Item(14, I).Value))
                    nro_ref0 = dgw1.Item(22, I).Value
                    cod_ref0 = dgw1.Item(23, I).Value
                    nro_det0 = dgw1.Item(24, I).Value
                    fecha_ref0 = Date.Parse(dgw1.Item(25, I).Value)
                    fecha_det0 = Date.Parse(dgw1.Item(26, I).Value)
                    fecha_pago0 = Date.Parse(dgw1.Item(27, I).Value)
                    base_ref0 = Decimal.Parse(dgw1.Item(28, I).Value)
                    tasa_det0 = Decimal.Parse(dgw1.Item(29, I).Value)
                    STATUS_GASTO = dgw1.Item(30, I).Value
                    CodigoBienes = dgw1.Item(31, I).Value
                    Dim rspta0 As String = OBJ.HALLAR_NRO_COMP_PCXP(COD_SUC.ToString("00"), COD_DOC, NRO_DOC, COD_PER)
                    If (rspta0 <> "") Then
                        MessageBox.Show(("El Documento ya se ingresó en la " & rspta0), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf OBJ.VERIFICAR_REG_COMPRAS(COD_DOC, NRO_DOC, COD_PER, DOC_PER) = False Then
                        MessageBox.Show("El Documento ya se ingresó en Registro de Compras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        ConfigDoc = OBJ.GCO_DIR_TABLA_DESC(COD_DOC, "TCDOC", con)
                        DOC_TRANSFERIR(I, dgw1.Item(19, I).Value)
                        'If VALIDAR_IMPORTE() = False Then
                        '    MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'End If
                        If VALIDAR_CUENTA_ORDEN() Then
                            INSERTAR_DOCUMENTO()
                            If VALIDAR_IMPORTE2() = False Then
                                ' MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                            GENERAR_AUTO()
                            If VERIFICAR_PERSONA() Then
                                If VERIFICAR_CUENTA() = False Then
                                    CARGAR_PENDIENTES()
                                ElseIf (((VERIFICAR_ORDEN() AndAlso VERIFICAR_CC()) AndAlso (VERIFICAR_PROYECTO())) AndAlso VERIFICAR_AUTO()) Then
                                    'If VALIDAR_IMPORTE2() = False Then
                                    '    MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    '    'Else
                                    If INSERTAR_TODO() = "EXITO" Then
                                        DOC_STATUS(I)
                                        dgw_mov1.Rows.Clear()
                                        dgw_det_01.Rows.Clear()
                                        dgw_doc_01.Rows.Clear()
                                    Else
                                        OBJ.ELIMINAR_TEMPORAL("PCOMP")
                                        MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If
                                    'End If
                                End If
                            End If
                        End If
                    End If
                End If
                I += 1
            Loop
        Else
            TIPO_DET = "N"
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw1.RowCount - 1)
            I = 0
            Do While (I <= CONT)
                If dgw1.Item(10, I).Value.ToString = "True" Then
                    COD_DOC = dgw1.Item(4, I).Value
                    NRO_DOC = dgw1.Item(5, I).Value
                    COD_MONEDA = dgw1.Item(13, I).Value
                    COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                    If (COD_DH_DOC = "D") Then
                        COD_DH_DOC = "H"
                    Else
                        COD_DH_DOC = "D"
                    End If
                    COD_PER = dgw1.Item(6, I).Value
                    DESC_PER = dgw1.Item(7, I).Value
                    DOC_PER = dgw1.Item(8, I).Value
                    COD_CLASE = dgw1.Item(2, I).Value
                    FECHA_DOC = DateTime.Parse(dgw1.Item(11, I).Value)
                    FECHA_VEN = DateTime.Parse(dgw1.Item(12, I).Value)
                    IMP_TOTAL = Decimal.Parse(dgw1.Item(9, I).Value)
                    IMP_IGV = Decimal.Parse((dgw1.Item(21, I).Value))
                    TCAMBIO = Decimal.Parse((dgw1.Item(14, I).Value))
                    nro_ref0 = dgw1.Item(22, I).Value
                    cod_ref0 = dgw1.Item(23, I).Value
                    nro_det0 = dgw1.Item(24, I).Value
                    fecha_ref0 = Date.Parse(dgw1.Item(25, I).Value)
                    fecha_det0 = Date.Parse(dgw1.Item(26, I).Value)
                    fecha_pago0 = Date.Parse(dgw1.Item(27, I).Value)
                    base_ref0 = Decimal.Parse(dgw1.Item(28, I).Value)
                    tasa_det0 = Decimal.Parse(dgw1.Item(29, I).Value)
                    Dim rspta0 As String = OBJ.HALLAR_NRO_COMP_PCXP(COD_SUC.ToString("00"), COD_DOC, NRO_DOC, COD_PER)
                    If (rspta0 <> "") Then
                        MessageBox.Show(("El Documento ya se ingresó en la " & rspta0), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    If OBJ.VERIFICAR_REG_COMPRAS(COD_DOC, NRO_DOC, COD_PER, DOC_PER) = False Then
                        MessageBox.Show("El Documento ya se ingresó en Registro de Compras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    ConfigDoc = OBJ.GCO_DIR_TABLA_DESC(COD_DOC, "TCDOC", con)
                    DOC_TRANSFERIR(I, dgw1.Item(19, I).Value)
                    If VALIDAR_CUENTA_ORDEN() = False Then
                        Return
                    End If
                    INSERTAR_DOCUMENTO()
                    GENERAR_AUTO()
                    VERIFICAR_PERSONA()
                    If (((VERIFICAR_CUENTA() = False OrElse VERIFICAR_ORDEN() = False) OrElse (VERIFICAR_CC() = False)) OrElse (VERIFICAR_PROYECTO() = False OrElse VERIFICAR_AUTO() = False)) Then
                        Return
                    End If
                End If
                I += 1
            Loop
            If (INSERTAR_TODO() = "EXITO") Then
                DOC_N_STATUS()
            Else
                OBJ.ELIMINAR_TEMPORAL("PCOMP")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
        End If
        Dim desc1 As String = cbo_com.Text
        cbo_com.SelectedIndex = -1
        cbo_com.Text = desc1
        MessageBox.Show("Los Documentos fueron transferidos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CARGAR_PENDIENTES()
        CARGAR_CERRADAS()
    End Sub

    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If dgw2.Item(10, I).Value.ToString = "True" Then
                COD_DOC = dgw2.Item(4, I).Value.ToString
                NRO_DOC = dgw2.Item(5, I).Value.ToString
                COD_MONEDA = dgw2.Item(13, I).Value.ToString
                COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                COD_CLASE = dgw2.Item(2, I).Value.ToString
                COD_PER = dgw2.Item(6, I).Value.ToString
                DESC_PER = dgw2.Item(7, I).Value.ToString
                DOC_PER = dgw2.Item(8, I).Value.ToString
                FECHA_DOC = DateTime.Parse(dgw2.Item(11, I).Value.ToString)
                FECHA_VEN = DateTime.Parse(dgw2.Item(12, I).Value.ToString)
                IMP_TOTAL = Decimal.Parse(dgw2.Item(9, I).Value.ToString)
                IMP_IGV = Decimal.Parse((dgw2.Item(21, I).Value))
                TCAMBIO = Decimal.Parse((dgw2.Item(14, I).Value))
                DES_DOC_STATUS(I)
            End If
            I += 1
        Loop
        If cbo_aux.SelectedIndex <> -1 And cbo_com.SelectedIndex <> -1 Then CARGAR_PENDIENTES()
        CARGAR_CERRADAS()
    End Sub

    Private Sub btn_buscar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar1.Click
        btn_sgt1.Enabled = True
        txt_letra1.Focus()
        Dim CONT0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim VAR11 As Integer = Strings.Len(dgw1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= VAR11)
                If (txt_letra1.Text.ToLower = Strings.Mid(dgw1.Item(7, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(7)
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
        Dim CONT0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim VAR11 As Integer = Strings.Len(dgw2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= VAR11)
                If (txt_letra2.Text.ToLower = Strings.Mid(dgw2.Item(7, i).Value.ToString, f, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = dgw2.Rows.Item(i).Cells.Item(7)
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub

    Private Sub btn_sgt1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt1.Click
        btn_sgt1.Enabled = True
        txt_letra1.Focus()
        Dim CONT0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = fila1
        Do While (i <= CONT0)
            Dim VAR11 As Integer = Strings.Len(dgw1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= VAR11)
                If (txt_letra1.Text.ToLower = Strings.Mid(dgw1.Item(7, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(7)
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
        Dim CONT0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= CONT0)
            Dim VAR11 As Integer = Strings.Len(dgw2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= VAR11)
                If (txt_letra2.Text.ToLower = Strings.Mid(dgw2.Item(7, i).Value.ToString, f, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = dgw2.Rows.Item(i).Cells.Item(7)
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
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_FACT_CERRADA_COI", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw2.DataSource = DT
            dgw2.Columns.Item(0).Visible = False
            dgw2.Columns.Item(2).Visible = False
            dgw2.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw2.Columns.Item(1).Width = 80
            dgw2.Columns.Item(3).Width = 80
            dgw2.Columns.Item(4).Width = 25
            dgw2.Columns.Item(5).Width = 90
            dgw2.Columns.Item(6).Width = &H37
            dgw2.Columns.Item(7).Width = 220
            dgw2.Columns.Item(8).Width = &H37
            dgw2.Columns.Item(9).Width = 80
            dgw2.Columns.Item(10).Width = 25
            dgw2.Columns.Item(11).Width = &H4B
            dgw2.Columns.Item(12).Width = &H4B
            dgw2.Columns.Item(11).DefaultCellStyle.Format = "d"
            dgw2.Columns.Item(12).DefaultCellStyle.Format = "d"
            dgw2.Columns.Item(13).Width = 25
            dgw2.Columns.Item(14).Width = 60
            dgw2.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw2.Columns.Item(16).Width = 25
            dgw2.Columns.Item(17).Width = &H2B
            dgw2.Columns.Item(18).Width = 23
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dgw2.Columns.Item(10).ReadOnly = False

        dgw2.Columns.Item(1).ReadOnly = True
        dgw2.Columns.Item(3).ReadOnly = True
        dgw2.Columns.Item(4).ReadOnly = True
        dgw2.Columns.Item(5).ReadOnly = True
        dgw2.Columns.Item(6).ReadOnly = True
        dgw2.Columns.Item(7).ReadOnly = True
        dgw2.Columns.Item(8).ReadOnly = True
        dgw2.Columns.Item(9).ReadOnly = True
        dgw2.Columns.Item(11).ReadOnly = True
        dgw2.Columns.Item(12).ReadOnly = True
        dgw2.Columns.Item(13).ReadOnly = True
        dgw2.Columns.Item(14).ReadOnly = True
        dgw2.Columns.Item(16).ReadOnly = True
        dgw2.Columns.Item(17).ReadOnly = True
        dgw2.Columns.Item(18).ReadOnly = True
    End Sub

    Sub CARGAR_PENDIENTES()
        Try
            COD_SUC = Integer.Parse(OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP))
        Catch ex As Exception


            COD_SUC = 1

        End Try
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_FACT_PTE_COI", CON_GCO)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@TIPO_USU", SqlDbType.Char).Value = TIPO_USU
            CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUC.ToString("0000")
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(22).Visible = False
            dgw1.Columns.Item(23).Visible = False
            dgw1.Columns.Item(24).Visible = False
            dgw1.Columns.Item(25).Visible = False
            dgw1.Columns.Item(26).Visible = False
            dgw1.Columns.Item(27).Visible = False
            dgw1.Columns.Item(28).Visible = False
            dgw1.Columns.Item(29).Visible = False
            dgw1.Columns.Item(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns.Item(1).Width = 80
            dgw1.Columns.Item(3).Width = 80
            dgw1.Columns.Item(4).Width = 25
            dgw1.Columns.Item(5).Width = 90
            dgw1.Columns.Item(6).Width = &H37
            dgw1.Columns.Item(7).Width = 220
            dgw1.Columns.Item(8).Width = &H37
            dgw1.Columns.Item(9).Width = 80
            dgw1.Columns.Item(10).Width = 25
            dgw1.Columns.Item(11).Width = &H4B
            dgw1.Columns.Item(12).Width = &H4B
            dgw1.Columns.Item(11).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(12).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(13).Width = 25
            dgw1.Columns.Item(14).Width = 60
            dgw1.Columns.Item(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns.Item(16).Width = 25
            dgw1.Columns.Item(17).Width = &H2B
            dgw1.Columns.Item(18).Width = 23
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '-------------------------validando solo lectura
        dgw1.Columns.Item(10).ReadOnly = False
        dgw1.Columns.Item(9).ReadOnly = True
        dgw1.Columns.Item(1).ReadOnly = True
        dgw1.Columns.Item(3).ReadOnly = True
        dgw1.Columns.Item(4).ReadOnly = True
        dgw1.Columns.Item(5).ReadOnly = True
        dgw1.Columns.Item(6).ReadOnly = True
        dgw1.Columns.Item(7).ReadOnly = True
        dgw1.Columns.Item(8).ReadOnly = True
        dgw1.Columns.Item(9).ReadOnly = True
        dgw1.Columns.Item(11).ReadOnly = True
        dgw1.Columns.Item(12).ReadOnly = True
        dgw1.Columns.Item(13).ReadOnly = True
        dgw1.Columns.Item(14).ReadOnly = True
        dgw1.Columns.Item(16).ReadOnly = True
        dgw1.Columns.Item(17).ReadOnly = True
        dgw1.Columns.Item(18).ReadOnly = True
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
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
            Dim NUM0 As String = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
            CARGAR_PENDIENTES()
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

    Private Sub ch_doc1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc1.CheckedChanged
        If ch_doc1.Checked Then
            dgw1.Sort(dgw1.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_doc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc2.CheckedChanged
        If ch_doc2.Checked Then
            dgw2.Sort(dgw2.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            dgw1.Sort(dgw1.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked Then
            dgw2.Sort(dgw2.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        Dim CONT0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            dgw1.Item(10, i).Value = ch1.Checked
            i += 1
        Loop
    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        Dim CONT0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            dgw2.Item(10, i).Value = ch2.Checked
            i += 1
        Loop
    End Sub

    Public Sub CREAR_DATASET()
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
        '------------------------------------
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
        DT_DET.Columns.Add("ACTIVIDAD")
    End Sub

    Public Sub DES_DOC_STATUS(ByVal FIla As Integer)
        Try
            Dim pro_02 As New SqlCommand("COI_DOC_STATUS2", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw2.Item(0, FIla).Value.ToString
            pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
            pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
            pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@COD_CLASE", SqlDbType.VarChar).Value = COD_CLASE
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)

        End Try
    End Sub


    Public Sub DOC_N_STATUS()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If dgw1.Item(10, I).Value.ToString = "True" Then
                COD_DOC = dgw1.Item(4, I).Value.ToString
                NRO_DOC = dgw1.Item(5, I).Value.ToString
                COD_CLASE = dgw1.Item(2, I).Value.ToString
                COD_PER = dgw1.Item(6, I).Value.ToString
                DESC_PER = dgw1.Item(7, I).Value.ToString
                DOC_PER = dgw1.Item(8, I).Value.ToString
                Try
                    Dim pro_02 As New SqlCommand("COI_DOC_STATUS", CON_GCO)
                    pro_02.CommandType = CommandType.StoredProcedure
                    pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                    pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw1.Item(0, I).Value.ToString
                    pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
                    pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
                    pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
                    pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                    pro_02.Parameters.Add("@COD_CLASE", SqlDbType.VarChar).Value = COD_CLASE
                    CON_GCO.Open()
                    pro_02.ExecuteNonQuery()
                    CON_GCO.Close()
                Catch ex As Exception


                    CON_GCO.Close()
                    MsgBox(ex.Message)

                End Try
            End If
            I += 1
        Loop
    End Sub

    Public Sub DOC_STATUS(ByVal FIla As Integer)
        Try
            Dim pro_02 As New SqlCommand("COI_DOC_STATUS", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw1.Item(0, FIla).Value.ToString
            pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
            pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
            pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@COD_CLASE", SqlDbType.VarChar).Value = COD_CLASE
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub DOC_TRANSFERIR(ByVal FIla As Integer, ByVal TIPO As String)
        dgw_mov1.Rows.Clear()
        Select Case TIPO
            Case "GASTO"
                Try
                    Dim pro_02 As New SqlCommand("COI_MOSTRAR_T_GASTO_DETALLES", CON_GCO)
                    pro_02.CommandType = CommandType.StoredProcedure
                    pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                    pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw1.Item(0, FIla).Value
                    pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
                    pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
                    pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
                    pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
                    pro_02.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
                    pro_02.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
                    pro_02.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
                    CON_GCO.Open()
                    pro_02.ExecuteNonQuery()
                    Dim rs2 As SqlDataReader = pro_02.ExecuteReader
                    Do While rs2.Read
                        dgw_mov1.Rows.Add(New Object() {rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), _
                        rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), _
                        rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), _
                        rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20), rs2.GetValue(21), _
                        rs2.GetValue(22), rs2.GetValue(24), rs2.GetValue(25), rs2.GetValue(26)})
                        CUENTA_TOTAL = (rs2.GetValue(23))
                    Loop
                    CON_GCO.Close()
                Catch ex As Exception


                    CON_GCO.Close()
                    MsgBox(ex.Message)

                End Try

            Case "INVENTARIO"
                Try
                    Dim pro_02 As New SqlCommand("COI_MOSTRAR_T_FACT_DETALLES", CON_GCO)
                    pro_02.CommandType = CommandType.StoredProcedure
                    pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                    pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw1.Item(0, FIla).Value
                    pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
                    pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
                    pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
                    pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
                    pro_02.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
                    pro_02.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
                    pro_02.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
                    CON_GCO.Open()
                    pro_02.ExecuteNonQuery()
                    Dim rs2 As SqlDataReader = pro_02.ExecuteReader
                    Do While rs2.Read
                        dgw_mov1.Rows.Add(New Object() {rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), _
                            rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), _
                            rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), _
                            rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20), rs2.GetValue(21), _
                            rs2.GetValue(22), rs2.GetValue(24), rs2.GetValue(25), ""})
                        CUENTA_TOTAL = (rs2.GetValue(23))
                    Loop
                    CON_GCO.Close()
                Catch ex As Exception


                    CON_GCO.Close()
                    MsgBox(ex.Message)

                End Try

        End Select
        If (CUENTA_TOTAL Is Nothing) Then
            CUENTA_TOTAL = ""
        End If
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Dim OrdenBI As String
        Do While (I <= CONT)
            If dgw_mov1.Item(1, I).Value <> "" Then
                If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                    OrdenBI = ConfigDoc.Substring(0, 2)
                Else
                    If dgw_mov1.Item(22, I).Value = 0 Then
                        ' SIN IGV
                        OrdenBI = OBJ.HALLAR_ORDEN_CUENTA2("B", AÑO, "C", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                    Else
                        OrdenBI = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "C", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                    End If
                End If
                dgw_mov1.Item(11, I).Value = OrdenBI
            End If
            I += 1
        Loop
    End Sub
    Private Sub GCO_TRANSFERENCIA_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(28) = 0
    End Sub
    Private Sub GCO_TRANSFERENCIA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CREAR_DATASET()
        CBO_AUXILIAR()
        ORDEN_TOTAL = "00"
        dtp_com.Value = FECHA_GRAL
        Dim emp00 As String = OBJ.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = String.Concat(New String() {"data source=", nombre_servidor, ";initial catalog=BD_GCO", emp00, ";uid=miguel;pwd=main;"})
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        CUENTA_IGV = OBJ.GCO_DIR_TABLA_DESC("IGVC", "TCTAS", CON_GCO)
        ORDEN_IGV = OBJ.HALLAR_ORDEN_CUENTA("I", AÑO, "C", CUENTA_IGV.Substring(0, 3))
        IGV0 = Decimal.Parse(OBJ.IMPUESTO("IGV"))
        CARGAR_CERRADAS()
    End Sub

    Sub GENERAR_AUTO()
        Dim cont_r1 As Integer = dgw_det_01.RowCount
        Dim CONT0 As Integer = (cont_r1 - 1)
        Dim j As Integer = 0
        Do While (j <= CONT0)
            Dim var0 As String = dgw_det_01.Item(0, j).Value
            Dim var1 As String = dgw_det_01.Item(1, j).Value
            Dim var2 As String = dgw_det_01.Item(2, j).Value
            Dim var3 As Decimal = Decimal.Parse(dgw_det_01.Item(3, j).Value)
            Dim var4 As Decimal = Decimal.Parse(dgw_det_01.Item(4, j).Value)
            Dim var5 As String = dgw_det_01.Item(5, j).Value
            Dim var6 As String = dgw_det_01.Item(6, j).Value
            Dim var7 As Decimal = Decimal.Parse(dgw_det_01.Item(7, j).Value)
            Dim var8 As String = dgw_det_01.Item(8, j).Value
            Dim var9 As String = dgw_det_01.Item(9, j).Value
            Dim var10 As String = dgw_det_01.Item(10, j).Value
            Dim var11 As String = dgw_det_01.Item(11, j).Value
            Dim var12 As String = dgw_det_01.Item(12, j).Value
            Dim var13 As String = dgw_det_01.Item(13, j).Value
            Dim var14 As String = dgw_det_01.Item(14, j).Value
            Dim var15 As String = dgw_det_01.Item(15, j).Value
            Dim var16 As String = dgw_det_01.Item(16, j).Value
            Dim var17 As String = dgw_det_01.Item(17, j).Value
            Dim var18 As String = dgw_det_01.Item(18, j).Value
            Dim var19 As String = dgw_det_01.Item(19, j).Value
            Dim var20 As String = dgw_det_01.Item(20, j).Value
            Dim var21 As String = dgw_det_01.Item(21, j).Value
            Dim var22 As String = dgw_det_01.Item(22, j).Value
            Dim var23 As String = dgw_det_01.Item(23, j).Value
            Dim var24 As String = dgw_det_01.Item(24, j).Value
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
                dgw_det_01.Rows.Add(var0, var14, var2, var3, var4, cod_enlace, var6, var7, "", "", "", "", var12, var13, "", "", _
                    "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", _
                    "0", "0", var24, "", "", "")
                dgw_det_01.Rows.Add(var0, var15, var2, var3, var4, cod_destino, var6, var7, "", "", "", "", var12, var13, "", "", _
                    "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", _
                    "0", "0", var24, "", "", "")
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
        st_pago0 = "0"
        If (DateTime.Compare(FECHA_DOC, fecha_pago0) <> 0) Then
            st_pago0 = "1"
        End If
        'Here
        dgw_doc_01.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp.Text, COD_DOC, NRO_DOC, COD_PER, DESC_PER, DOC_PER, dtp_com.Value, FECHA_DOC, cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10, COD_MONEDA, TCAMBIO, cte_03, COD_DH_DOC, nro_det0, tasa_det0, fecha_det0, cod_ref0, nro_ref0, fecha_ref0, fecha_pago0, st_pago0, base_ref0, imp_s_t, STATUS_GASTO, CodigoBienes)
        Dim j As Integer = 0
        j = 0
        Do While (j <= CONT)
            Dim var0 As String = dgw_mov1.Item(0, j).Value
            Dim var1 As String = dgw_mov1.Item(1, j).Value
            Dim var2 As String = dgw_mov1.Item(2, j).Value
            Dim var3 As String = dgw_mov1.Item(3, j).Value
            Dim var4 As String = dgw_mov1.Item(4, j).Value
            Dim var5 As String = dgw_mov1.Item(5, j).Value
            Dim var6 As String = dgw_mov1.Item(6, j).Value
            Dim var7 As String = dgw_mov1.Item(7, j).Value
            Dim var8 As String = dgw_mov1.Item(8, j).Value
            Dim var9 As String = dgw_mov1.Item(9, j).Value
            Dim var10 As String = dgw_mov1.Item(10, j).Value
            Dim var11 As String = dgw_mov1.Item(11, j).Value
            Dim var12 As DateTime = Date.Parse(dgw_mov1.Item(12, j).Value)
            Dim var13 As String = dgw_mov1.Item(13, j).Value
            Dim var14 As String = dgw_mov1.Item(14, j).Value
            Dim var15 As String = dgw_mov1.Item(15, j).Value
            Dim var16 As String = dgw_mov1.Item(16, j).Value
            Dim var17 As String = dgw_mov1.Item(17, j).Value
            Dim var18 As String = dgw_mov1.Item(18, j).Value
            Dim var19 As DateTime = Date.Parse(dgw_mov1.Item(19, j).Value)
            Dim var20 As String = dgw_mov1.Item(20, j).Value
            Dim var21 As String = dgw_mov1.Item(21, j).Value
            Dim var22 As String = dgw_mov1.Item(22, j).Value
            Dim var23 As String = dgw_mov1.Item(23, j).Value
            Dim var24 As String = dgw_mov1.Item(24, j).Value
            Dim var25 As String = dgw_mov1.Item(25, j).Value
            Dim imp_doc00 As New Decimal
            imp_doc00 = Decimal.Parse(var3)
            If (var6 <> "S") Then
                imp_doc00 = Decimal.Parse(var4)
            End If
            dgw_det_01.Rows.Add(New Object() {var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), _
                var5, var6, var7, var8, var9, var10, var11, FECHA_VEN, var13, var14, var15, var16, var17, var18, var19, COD_DOC, _
                NRO_DOC, COD_PER, DOC_PER, "0", "B", var20, var21, "0", " ", " ", FECHA_DOC, 0, " ", var22, imp_doc00, "0", "0", _
                var23, var24, var25, cod_ref0, nro_ref0})
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
        Dim ARRAY1 As Object() = New Object() {(CONT + 2).ToString("0000"), CUENTA_IGV, DESC_PER, Math.Round(imp_s_igv, 2), _
            Math.Round(imp_d_igv, 2), DH_IGV, COD_MONEDA, TCAMBIO, " ", " ", " ", ORDEN_IGV, FECHA_VEN, 0, " ", " ", " ", " ", _
            " ", FECHA_DOC, COD_DOC, NRO_DOC, COD_PER, DOC_PER, 0, "I", "", "", "0", " ", " ", FECHA_DOC, 0, " ", 0, imp_igv00, _
            "0", "0", "0", DESC_PER, "", cod_ref0, nro_ref0}
        dgw_det_01.Rows.Add(ARRAY1)
        ARRAY1 = New Object(42) {}
        ARRAY1(0) = (CONT + 3).ToString("0000")
        ARRAY1(1) = CUENTA_TOTAL
        ARRAY1(2) = DESC_PER
        ARRAY1(3) = Math.Round(imp_s_t, 2)
        ARRAY1(4) = Math.Round(imp_d_t, 2)
        ARRAY1(5) = DH_T
        ARRAY1(6) = COD_MONEDA
        ARRAY1(7) = TCAMBIO
        ARRAY1(8) = " "
        ARRAY1(9) = " "
        ARRAY1(10) = " "
        ARRAY1(11) = ORDEN_TOTAL
        ARRAY1(12) = FECHA_VEN
        ARRAY1(13) = 0
        ARRAY1(14) = " "
        ARRAY1(15) = " "
        ARRAY1(16) = " "
        ARRAY1(17) = " "
        ARRAY1(18) = " "
        ARRAY1(19) = FECHA_DOC
        ARRAY1(20) = COD_DOC
        ARRAY1(21) = NRO_DOC
        ARRAY1(22) = COD_PER
        ARRAY1(23) = DOC_PER
        ARRAY1(24) = 0
        ARRAY1(25) = "T"
        ARRAY1(26) = ""
        ARRAY1(27) = ""
        ARRAY1(28) = "0"
        ARRAY1(29) = " "
        ARRAY1(30) = " "
        ARRAY1(31) = FECHA_DOC
        ARRAY1(32) = 0
        ARRAY1(33) = " "
        ARRAY1(34) = 0
        ARRAY1(35) = imp_t00
        ARRAY1(36) = "0"
        ARRAY1(37) = "0"
        ARRAY1(38) = "0"
        ARRAY1(39) = DESC_PER
        ARRAY1(40) = ""
        ARRAY1(41) = cod_ref0
        ARRAY1(42) = nro_ref0
        dgw_det_01.Rows.Add(ARRAY1)
    End Sub

    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.Rows.Count - 1)
        DT_DOC.Rows.Clear()
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            With dgw_doc_01
                DT_DOC.Rows.Add(AÑO, MES, .Item(3, I).Value, .Item(4, I).Value, .Item(5, I).Value, .Item(7, I).Value, _
                    COD_AUX, COD_COMP, txt_nro_comp.Text, dtp_com.Value, .Item(6, I).Value, DateTime.Parse(.Item(9, I).Value), _
                    .Item(27, I).Value, .Item(28, I).Value, DateTime.Parse(.Item(29, I).Value), Decimal.Parse(.Item(10, I).Value), _
                    Decimal.Parse(.Item(11, I).Value), Decimal.Parse(.Item(12, I).Value), Decimal.Parse(.Item(13, I).Value), _
                    Decimal.Parse(.Item(14, I).Value), Decimal.Parse(.Item(15, I).Value), Decimal.Parse(.Item(16, I).Value), _
                    Decimal.Parse(.Item(17, I).Value), Decimal.Parse(.Item(18, I).Value), Decimal.Parse(.Item(19, I).Value), _
                    .Item(20, I).Value, Decimal.Parse(.Item(21, I).Value), .Item(23, I).Value, .Item(24, I).Value, _
                    .Item(25, I).Value, DateTime.Parse(.Item(26, I).Value), DateTime.Parse(.Item(30, I).Value), _
                    .Item(31, I).Value, .Item(32, I).Value, NOMBRE_PC, .Item(33, I).Value, .Item(34, I).Value, .Item(35, I).Value)
            End With

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

            Return "FALLO"

        End Try
        I = 0
        CONT = (dgw_det_01.Rows.Count - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            With dgw_det_01
                '  DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_det_01.Item(20, I).Value , dgw_det_01.Item(21, I).Value. , dgw_det_01.Item(22, I).Value, dgw_det_01.Item(23, I).Value  (I + 1).ToString("0000"), DateTime.Parse(dgw_det_01.Item(19, I).Value.ToString), "", "", DateTime.Parse(dgw_det_01.Item(19, I).Value , dgw_det_01.Item(2, I).Value , dgw_det_01.Item(1, I).Value , Decimal.Parse(dgw_det_01.Item(3, I).Value ), Decimal.Parse(dgw_det_01.Item(4, I).Value ), dgw_det_01.Item(5, I).Value , dgw_det_01.Item(6, I).Value , Decimal.Parse(dgw_det_01.Item(7, I).Value ), dgw_det_01.Item(8, I).Value.ToString, dgw_det_01.Item(9, I).Value.ToString, dgw_det_01.Item(10, I).Value.ToString, dgw_det_01.Item(11, I).Value.ToString, DateTime.Parse(dgw_det_01.Item(12, I).Value.ToString), dgw_det_01.Item(13, I).Value.ToString, dgw_det_01.Item(14, I).Value.ToString, dgw_det_01.Item(15, I).Value.ToString, dgw_det_01.Item(24, I).Value.ToString, dgw_det_01.Item(25, I).Value.ToString, dgw_det_01.Item(37, I).Value.ToString, dgw_det_01.Item(28, I).Value.ToString, dgw_det_01.Item(29, I).Value.ToString, dgw_det_01.Item(30, I).Value.ToString, DateTime.Parse(dgw_det_01.Item(31, I).Value.ToString), dgw_det_01.Item(32, I).Value.ToString, dgw_det_01.Item(33, I).Value.ToString, dgw_det_01.Item(36, I).Value.ToString, dtp_com.Value.ToString, Decimal.Parse(dgw_det_01.Item(34, I).Value.ToString), NOMBRE_PC, dgw_det_01.Item(38, I).Value.ToString, dgw_det_01.Item(40, I).Value.ToString)
                DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, .Item(20, I).Value, .Item(21, I).Value, _
                    .Item(22, I).Value, .Item(23, I).Value, (I + 1).ToString("0000"), DateTime.Parse(.Item(19, I).Value), _
                    .Item(41, I).Value, .Item(42, I).Value, DateTime.Parse(.Item(19, I).Value), .Item(2, I).Value, .Item(1, I).Value, _
                    Decimal.Parse(.Item(3, I).Value), Decimal.Parse(.Item(4, I).Value), .Item(5, I).Value, .Item(6, I).Value, _
                    Decimal.Parse(.Item(7, I).Value), .Item(8, I).Value, .Item(9, I).Value, .Item(10, I).Value, .Item(11, I).Value, _
                    DateTime.Parse(.Item(12, I).Value), .Item(13, I).Value, .Item(14, I).Value, .Item(15, I).Value, .Item(24, I).Value, _
                    .Item(25, I).Value, .Item(37, I).Value, .Item(28, I).Value, .Item(29, I).Value, .Item(30, I).Value, _
                    DateTime.Parse(.Item(31, I).Value), .Item(32, I).Value, .Item(33, I).Value, .Item(36, I).Value, _
                    dtp_com.Value, Decimal.Parse(.Item(34, I).Value), NOMBRE_PC, .Item(38, I).Value, .Item(40, I).Value)
            End With

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
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_COMPRAS", con)
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
            con.Open()
            'comand1.ExecuteNonQuery()
            estado = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function

    Private Sub txt_letra1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra1.TextChanged
        Dim i As Integer
        If ch_doc1.Checked Then
            txt_letra1.Focus()
            Dim CONT0 As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT0)
                If (txt_letra1.Text.ToLower = Strings.Mid((dgw1.Item(5, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(5)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per1.Checked Then
            txt_letra1.Focus()
            Dim VAR11 As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= VAR11)
                If (txt_letra1.Text.ToLower = Strings.Mid((dgw1.Item(7, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(7)
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
            Dim CONT0 As Integer = (dgw2.RowCount - 1)
            i = 0
            Do While (i <= CONT0)
                If (txt_letra2.Text.ToLower = Strings.Mid((dgw2.Item(5, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = dgw2.Rows.Item(i).Cells.Item(5)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per2.Checked Then
            txt_letra2.Focus()
            Dim VAR11 As Integer = (dgw2.RowCount - 1)
            i = 0
            Do While (i <= VAR11)
                If (txt_letra2.Text.ToLower = Strings.Mid((dgw2.Item(7, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = dgw2.Rows.Item(i).Cells.Item(7)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Public Function VALIDAR_CUENTA_ORDEN() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If ((dgw_mov1.Item(1, I).Value.ToString <> "") AndAlso (OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "C", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3)) = "0")) Then
                SB.ToString.Trim(dgw_mov1.Item(1, I).Value)
                SB.AppendLine(dgw_mov1.Item(1, I).Value)
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen Orden para la Cuenta Contable : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function
    Function VALIDAR_IMPORTE() As Boolean
        Dim SOLESD As New Decimal
        Dim DOLARESD As New Decimal
        Dim SOLESH As New Decimal
        Dim DOLARESH As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        '-----------------------------
        '-- HALLAR D / H DE IGV Y TOTAL
        '-----------------------------
        Dim DH_IGV As String = ""
        Dim DH_T As String = ""
        If (COD_DH_DOC = "D") Then
            DH_IGV = "H"
            DH_T = "D"
        ElseIf (COD_DH_DOC = "H") Then
            DH_IGV = "D"
            DH_T = "H"
        End If
        '-----------------------------
        'ELIMINAR EL AJUSTE
        While I <= CONT0
            If dgw_mov1.Item(6, I).Value = "A" Then
                dgw_mov1.Rows.RemoveAt(I)
                I = 0
                CONT0 = (dgw_mov1.RowCount - 1)
            Else
                I += 1
            End If
        End While
        '-----------------------------
        I = 0
        CONT0 = (dgw_mov1.RowCount - 1)
        Do While (I <= CONT0)
            Dim sol, dol As Decimal
            sol = dgw_mov1.Item(3, I).Value
            dol = dgw_mov1.Item(4, I).Value
            If (dgw_mov1.Item(5, I).Value = "D") Then
                SOLESD = Decimal.Parse(Decimal.Add(SOLESD, Math.Round(Decimal.Parse(dgw_mov1.Item(3, I).Value), 2)))
                DOLARESD = Decimal.Parse(Decimal.Add(DOLARESD, Math.Round(Decimal.Parse(dgw_mov1.Item(4, I).Value), 2)))
            Else
                SOLESH = Decimal.Parse(Decimal.Add(SOLESH, Math.Round(Decimal.Parse(dgw_mov1.Item(3, I).Value), 2)))
                DOLARESH = Decimal.Parse(Decimal.Add(DOLARESH, Math.Round(Decimal.Parse(dgw_mov1.Item(4, I).Value), 2)))
            End If
            I += 1
        Loop
        '--------------------------------------------
        If DH_IGV = "D" Then
            If (COD_MONEDA = "S") Then
                SOLESD = SOLESD + IMP_IGV
                DOLARESD = DOLARESD + Math.Round((IMP_IGV / TCAMBIO), 2)
            Else
                SOLESD = SOLESD + Math.Round((IMP_IGV * TCAMBIO), 2)
                DOLARESD = DOLARESD + IMP_IGV
            End If
        Else
            If (COD_MONEDA = "S") Then
                SOLESH = SOLESH + IMP_IGV
                DOLARESH = DOLARESH + Math.Round((IMP_IGV / TCAMBIO), 2)
            Else
                SOLESH = SOLESH + Math.Round((IMP_IGV * TCAMBIO), 2)
                DOLARESH = DOLARESH + IMP_IGV
            End If
        End If
        '---------------------------------------------
        '--------------------------------------------
        If DH_T = "D" Then
            If (COD_MONEDA = "S") Then
                SOLESD = SOLESD + IMP_TOTAL
                DOLARESD = DOLARESD + Math.Round((IMP_TOTAL / TCAMBIO), 2)
            Else
                SOLESD = SOLESD + Math.Round((IMP_TOTAL * TCAMBIO), 2)
                DOLARESD = DOLARESD + IMP_TOTAL
            End If
        Else
            If (COD_MONEDA = "S") Then
                SOLESH = SOLESH + IMP_TOTAL
                DOLARESH = DOLARESH + Math.Round((IMP_TOTAL / TCAMBIO), 2)
            Else
                SOLESH = SOLESH + Math.Round((IMP_TOTAL * TCAMBIO), 2)
                DOLARESH = DOLARESH + IMP_TOTAL
            End If
        End If
        '---------------------------------------------
        If COD_MONEDA = "S" Then
            If SOLESH = SOLESD Then
                If (DOLARESD - DOLARESH) < 0.5 And (DOLARESD - DOLARESH) > -0.5 Then
                    'ESTA BIEN PERO NO HAY AJUSTE EN DOLARES
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        Else
            'MONEDA DOLARES
            If DOLARESD = DOLARESH Then
                If (SOLESD - SOLESH) < 0.5 And (SOLESD - SOLESH) > -0.5 Then
                    'TIENE QUE HABER AJUSTE
                    Dim AJ As Decimal = SOLESD - SOLESH
                    Dim DH_AJ As String = "H"
                    If AJ < 0 Then DH_AJ = "D" : AJ = AJ * -1
                    Dim CTA_AJ As String = OBJ.DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
                    If DH_AJ = "D" Then CTA_AJ = OBJ.DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
                    Dim ORDEN0 As String = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "C", CTA_AJ)
                    If AJ <> 0 Then
                        dgw_mov1.Rows.Add("0000", CTA_AJ, "AJUSTE DE DOCUMENTO", AJ, 0, DH_AJ, "A", TCAMBIO, "", "", "", "00", FECHA_DOC, "0", "", "", "0", "0", "0", FECHA_DOC, "", "", 0, "0", "", "")
                    End If
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        End If
    End Function
    Public Function VALIDAR_IMPORTE2() As Boolean
        Dim SOLESD As New Decimal
        Dim DOLARESD As New Decimal
        Dim SOLESH As New Decimal
        Dim DOLARESH As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        '-----------------------------
        '-- HALLAR D / H DE IGV Y TOTAL
        '-----------------------------
        Dim DH_IGV As String = ""
        Dim DH_T As String = ""
        If (COD_DH_DOC = "D") Then
            DH_IGV = "H"
            DH_T = "D"
        ElseIf (COD_DH_DOC = "H") Then
            DH_IGV = "D"
            DH_T = "H"
        End If
        '-----------------------------
        'ELIMINAR EL AJUSTE
        While I <= CONT0
            If dgw_mov1.Item(6, I).Value = "A" Then
                dgw_mov1.Rows.RemoveAt(I)
                I = 0
                CONT0 = (dgw_mov1.RowCount - 1)
            Else
                I += 1
            End If
        End While
        '-----------------------------
        I = 0
        CONT0 = (dgw_mov1.RowCount - 1)
        Do While (I <= CONT0)
            Dim sol, dol As Decimal
            sol = Math.Round(dgw_mov1.Item(3, I).Value, 2)
            dol = Math.Round(dgw_mov1.Item(4, I).Value, 2)
            If (dgw_mov1.Item(5, I).Value = "D") Then
                SOLESD = SOLESD + sol
                DOLARESD = DOLARESD + dol
            Else
                SOLESH = SOLESH + sol
                DOLARESH = DOLARESH + dol
            End If
            I += 1
        Loop
        '--------------------------------------------
        'If DH_IGV = "D" Then
        '    If (COD_MONEDA = "S") Then
        '        SOLESD = SOLESD + IMP_IGV
        '        DOLARESD = DOLARESD + Math.Round((IMP_IGV / TCAMBIO), 2)
        '    Else
        '        SOLESD = SOLESD + Math.Round((IMP_IGV * TCAMBIO), 2)
        '        DOLARESD = DOLARESD + IMP_IGV
        '    End If
        'Else
        '    If (COD_MONEDA = "S") Then
        '        SOLESH = SOLESH + IMP_IGV
        '        DOLARESH = DOLARESH + Math.Round((IMP_IGV / TCAMBIO), 2)
        '    Else
        '        SOLESH = SOLESH + Math.Round((IMP_IGV * TCAMBIO), 2)
        '        DOLARESH = DOLARESH + IMP_IGV
        '    End If
        'End If
        ''---------------------------------------------
        ''--------------------------------------------
        'If DH_T = "D" Then
        '    If (COD_MONEDA = "S") Then
        '        SOLESD = SOLESD + IMP_TOTAL
        '        DOLARESD = DOLARESD + Math.Round((IMP_TOTAL / TCAMBIO), 2)
        '    Else
        '        SOLESD = SOLESD + Math.Round((IMP_TOTAL * TCAMBIO), 2)
        '        DOLARESD = DOLARESD + IMP_TOTAL
        '    End If
        'Else
        '    If (COD_MONEDA = "S") Then
        '        SOLESH = SOLESH + IMP_TOTAL
        '        DOLARESH = DOLARESH + Math.Round((IMP_TOTAL / TCAMBIO), 2)
        '    Else
        '        SOLESH = SOLESH + Math.Round((IMP_TOTAL * TCAMBIO), 2)
        '        DOLARESH = DOLARESH + IMP_TOTAL
        '    End If
        'End If
        '---------------------------------------------
        If COD_MONEDA = "S" Then
            If SOLESH = SOLESD Then
                If (DOLARESD - DOLARESH) < 0.5 And (DOLARESD - DOLARESH) > -0.5 Then
                    'ESTA BIEN PERO NO HAY AJUSTE EN DOLARES
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        Else
            'MONEDA DOLARES
            If DOLARESD = DOLARESH Then
                If (SOLESD - SOLESH) < 0.5 And (SOLESD - SOLESH) > -0.5 Then
                    'TIENE QUE HABER AJUSTE
                    Dim AJ As Decimal = SOLESD - SOLESH
                    Dim DH_AJ As String = "H"
                    If AJ < 0 Then DH_AJ = "D" : AJ = AJ * -1
                    Dim CTA_AJ As String = OBJ.DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
                    If DH_AJ = "D" Then CTA_AJ = OBJ.DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
                    Dim ORDEN0 As String = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "C", CTA_AJ)
                    If AJ <> 0 Then
                        dgw_det_01.Rows.Add("0000", CTA_AJ, "AJUSTE DE DOCUMENTO", AJ, 0, DH_AJ, "A", TCAMBIO, "0", "", "", "00", FECHA_DOC, "0", "", "", "0", "0", "0", FECHA_DOC, "", "", "", "", "0", "B", "", "", "", "", "", FECHA_DOC, "", 0, 0, "", "", "", "")
                    End If
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        End If
    End Function

    Public Function VERIFICAR_AUTO() As Boolean
        Dim CTA0 As String = ""
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(14, I).Value.ToString.Trim <> "")) And (dgw_det_01.Item(15, I).Value.ToString.Trim <> "")) Then
                CTA0 = dgw_det_01.Item(1, I).Value.ToString
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_AUTO", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(1, I).Value
                    comand1.Parameters.Add("@CUENTA_ENLACE", SqlDbType.VarChar).Value = dgw_det_01.Item(14, I).Value
                    comand1.Parameters.Add("@CUENTA_DESTINO", SqlDbType.VarChar).Value = dgw_det_01.Item(15, I).Value
                    comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
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
        MessageBox.Show(("No existen en el Maestro de Automaticas  Cuenta : Destino/Enlace : " & vbCrLf & " " & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_CC() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If ((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(8, I).Value.ToString.Trim <> "")) Then
                Dim K As String = dgw_det_01.Item(8, I).Value.ToString
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

    'Public Function VERIFICAR_CONTROL() As Boolean
    '    'SB.Remove(0, SB.Length)
    '    'Dim I As Integer = 0
    '    'Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
    '    'Dim CONT0 As Integer = CONT
    '    'I = 0
    '    'Do While (I <= CONT0)
    '    '    If ((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(9, I).Value.ToString.Trim <> "")) Then
    '    '        Try
    '    '            Dim comand1 As New SqlCommand("VERIFICAR_CONTROL_TRANSF", con)
    '    '            comand1.CommandType = CommandType.StoredProcedure
    '    '            comand1.Parameters.Add("@COD_CONTROL", SqlDbType.VarChar).Value = dgw_det_01.Item(9, I).Value.ToString
    '    '            con.Open()
    '    '            comand1.ExecuteNonQuery()
    '    '            Dim Rs3 As SqlDataReader = comand1.ExecuteReader
    '    '            Do While Rs3.Read
    '    '                SB.ToString.TrimRs3.GetValue(0)
    '    '                SB.AppendLineRs3.GetValue(0)
    '    '            Loop
    '    '            con.Close()
    '    '        Catch ex As Exception


    '    '            con.Close()
    '    '            MsgBox(ex.Message)

    '    '        End Try
    '    '    End If
    '    '    I += 1
    '    'Loop
    '    'If (SB.Length = 0) Then
    '    Return True
    '    'End If
    '    'MessageBox.Show(("No existen en el Maestro de Orden de Producción : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    'Return False
    'End Function

    Public Function VERIFICAR_CUENTA() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim k1 As String = dgw_det_01.Item(1, I).Value.ToString.Trim
            If (k1 = "") Then
                SB.ToString.Trim(k1)
                SB.AppendLine(String.Concat(New String() {k1, " ", dgw_det_01.Item(39, I).Value}))
            Else
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(1, I).Value
                    comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.ToString.Trim(Rs3.GetValue(0))
                        SB.AppendLine((Rs3.GetValue(0)) & " " & dgw_det_01.Item(39, I).Value)
                    Loop
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
            End If
            If (dgw_det_01.Item(25, I).Value = "B") Then
                If (dgw_det_01.Item(14, I).Value.ToString.Trim = "") Then
                    Dim k2 As String = dgw_det_01.Item(14, I).Value
                    Try
                        Dim comand2 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                        comand2.CommandType = CommandType.StoredProcedure
                        comand2.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(14, I).Value
                        comand2.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                        con.Open()
                        comand2.ExecuteNonQuery()
                        Dim Rs4 As SqlDataReader = comand2.ExecuteReader
                        Do While Rs4.Read
                            SB.ToString.Trim(Rs4.GetValue(0))
                            SB.AppendLine(Rs4.GetValue(0) & " " & dgw_det_01.Item(39, I).Value)
                        Loop
                        con.Close()
                    Catch ex As Exception


                        con.Close()
                        MsgBox(ex.Message)

                    End Try
                End If
                If (dgw_det_01.Item(15, I).Value.ToString.Trim <> "") Then
                    Dim k3 As String = dgw_det_01.Item(15, I).Value
                    Try
                        Dim comand2 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                        comand2.CommandType = CommandType.StoredProcedure
                        comand2.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_det_01.Item(15, I).Value
                        comand2.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                        con.Open()
                        comand2.ExecuteNonQuery()
                        Dim Rs4 As SqlDataReader = comand2.ExecuteReader
                        Do While Rs4.Read
                            SB.ToString.Trim(Rs4.GetValue(0))
                            SB.AppendLine(Rs4.GetValue(0) & " " & dgw_det_01.Item(39, I).Value)
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
        MessageBox.Show(String.Concat(New String() {"Documento ", COD_DOC, " - Nº ", NRO_DOC, vbCrLf & "Cta.Cte. ", COD_PER, " ", DESC_PER, " ", DOC_PER, vbCrLf & vbCrLf & "No existen en el Plan de cuentas : " & vbCrLf, SB.ToString}), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Function VERIFICAR_ORDEN() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim TIPO_ORDEN0 As String = dgw_det_01.Item(25, I).Value
            If ((TIPO_ORDEN0 = "B" OrElse TIPO_ORDEN0 = "I") AndAlso dgw_det_01.Item(11, I).Value = "") Then
                SB.ToString.Trim(dgw_det_01.Item(1, I).Value)
                SB.AppendLine((dgw_det_01.Item(1, I).Value & " Tipo : " & TIPO_ORDEN0))
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
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If ((dgw_det_01.Item(25, I).Value.ToString = "B") And (dgw_det_01.Item(10, I).Value.ToString.Trim <> "")) Then
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_PROYECTO_TRANSF", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_PROYECTO", SqlDbType.VarChar).Value = dgw_det_01.Item(10, I).Value
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
End Class