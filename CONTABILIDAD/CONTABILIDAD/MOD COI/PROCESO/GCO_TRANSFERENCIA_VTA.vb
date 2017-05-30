Imports System.Data.SqlClient
Imports System.Text
Public Class GCO_TRANSFERENCIA_VTA
    Private COD_AUX As String
    Private COD_CLASE As String
    Private COD_COMP As String
    Private COD_DH_DOC As String
    Private COD_DOC As String
    Private COD_MONEDA As String
    Private COD_PER As String
    Private COD_SUC As Integer
    Private CON_GCO As New SqlConnection
    Private CUENTA_IGV As String
    Private CUENTA_TOTAL As String
    Private DESC_PER As String
    Private DOC_PER As String
    Private DT_DET As New DataTable
    Private DT_DOC As New DataTable
    Private FECHA_DOC As DateTime
    Private FECHA_VEN As DateTime
    Private fila1 As Integer
    Private fila2 As Integer
    Private IGV0 As Decimal
    Private IMP_IGV As Decimal
    Private IMP_TOTAL As Decimal
    Private NRO_DOC As String
    Private OBJ As New Class1
    Private ORDEN_IGV As String
    Private ORDEN_TOTAL As String
    Private SB As New StringBuilder
    Private TCAMBIO As Decimal
    Private TIPO_DET As String
    Private STATUS_ANUL As String

    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If ch1.Checked Then
            If MessageBox.Show("Esta seguro de generar todos los comprobantes", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            Else
                Exit Sub
            End If
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
        ElseIf (ORDEN_IGV Is Nothing) Then
            MessageBox.Show("La cuenta de IGV no tiene Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        Else
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
                        COD_DOC = dgw1.Item(4, I).Value.ToString
                        NRO_DOC = dgw1.Item(5, I).Value.ToString
                        COD_MONEDA = dgw1.Item(13, I).Value.ToString
                        COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                        COD_PER = dgw1.Item(6, I).Value.ToString
                        DESC_PER = dgw1.Item(7, I).Value.ToString
                        DOC_PER = dgw1.Item(8, I).Value.ToString
                        COD_CLASE = dgw1.Item(2, I).Value.ToString
                        FECHA_DOC = DateTime.Parse(dgw1.Item(11, I).Value.ToString)
                        FECHA_VEN = DateTime.Parse(dgw1.Item(12, I).Value.ToString)
                        IMP_TOTAL = Decimal.Parse(dgw1.Item(9, I).Value.ToString)
                        IMP_IGV = Decimal.Parse((dgw1.Item(21, I).Value))
                        TCAMBIO = Decimal.Parse((dgw1.Item(14, I).Value))
                        STATUS_ANUL = dgw1.Item(22, I).Value.ToString
                        Dim rspta0 As String = OBJ.HALLAR_NRO_COMP_PCXC(COD_SUC.ToString("00"), COD_DOC, NRO_DOC, COD_PER)
                        If (rspta0 <> "") Then
                            MessageBox.Show(("El Documento ya se ingresó en la " & rspta0), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ElseIf OBJ.VERIFICAR_REG_VENTAS(COD_DOC, NRO_DOC, COD_PER, DOC_PER) = False Then
                            MessageBox.Show("El Documento ya se ingresó en Registro de Ventas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            DOC_TRANSFERIR(I, dgw1.Item(19, I).Value.ToString)
                            'If VALIDAR_IMPORTE() = False Then
                            'MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'End If
                            If VALIDAR_CUENTA_ORDEN() Then
                                INSERTAR_DOCUMENTO()
                                If VALIDAR_IMPORTE2() = False Then
                                    '   MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                                If VERIFICAR_PERSONA() Then
                                    If VERIFICAR_CUENTA() = False Then
                                        CARGAR_PENDIENTES()
                                    ElseIf ((VERIFICAR_ORDEN() AndAlso VERIFICAR_CC()) AndAlso (VERIFICAR_PROYECTO())) Then
                                        If (INSERTAR_TODO() = "EXITO") Then
                                            DOC_STATUS(I)
                                            dgw_mov1.Rows.Clear()
                                            dgw_det_01.Rows.Clear()
                                            dgw_doc_01.Rows.Clear()
                                        Else
                                            OBJ.ELIMINAR_TEMPORAL("PVTA")
                                            MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                            Exit Sub
                                        End If
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
                Dim CONT1 As Integer = CONT
                I = 0
                Do While (I <= CONT1)
                    If dgw1.Item(10, I).Value.ToString = "True" Then
                        COD_DOC = dgw1.Item(4, I).Value.ToString
                        NRO_DOC = dgw1.Item(5, I).Value.ToString
                        COD_MONEDA = dgw1.Item(13, I).Value.ToString
                        COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                        COD_PER = dgw1.Item(6, I).Value.ToString
                        DESC_PER = dgw1.Item(7, I).Value.ToString
                        DOC_PER = dgw1.Item(8, I).Value.ToString
                        COD_CLASE = dgw1.Item(2, I).Value.ToString
                        FECHA_DOC = DateTime.Parse(dgw1.Item(11, I).Value.ToString)
                        FECHA_VEN = DateTime.Parse(dgw1.Item(12, I).Value.ToString)
                        IMP_TOTAL = Decimal.Parse(dgw1.Item(9, I).Value.ToString)
                        IMP_IGV = Decimal.Parse((dgw1.Item(21, I).Value))
                        TCAMBIO = Decimal.Parse((dgw1.Item(14, I).Value))
                        Dim rspta0 As String = OBJ.HALLAR_NRO_COMP_PCXC(COD_SUC.ToString("00"), COD_DOC, NRO_DOC, COD_PER)
                        If (rspta0 <> "") Then
                            MessageBox.Show(("El Documento ya se ingresó en la " & rspta0), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        DOC_TRANSFERIR(I, dgw1.Item(19, I).Value.ToString)
                        If VALIDAR_CUENTA_ORDEN() = False Then
                            Return
                        End If
                        INSERTAR_DOCUMENTO()
                        VERIFICAR_PERSONA()
                        If (((VERIFICAR_CUENTA() = False OrElse VERIFICAR_ORDEN() = False) OrElse (VERIFICAR_CC() = False)) OrElse VERIFICAR_PROYECTO() = False) Then
                            Return
                        End If
                    End If
                    I += 1
                Loop
                If (INSERTAR_TODO() = "EXITO") Then
                    DOC_N_STATUS()
                Else
                    OBJ.ELIMINAR_TEMPORAL("PVTA")
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
        End If
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
            Dim CONT1 As Integer = Strings.Len(dgw1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
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
            Dim CONT1 As Integer = Strings.Len(dgw2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
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
            Dim CONT1 As Integer = Strings.Len(dgw1.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
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
            Dim CONT1 As Integer = Strings.Len(dgw2.Item(7, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
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

    Public Sub CARGAR_CERRADAS()
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_FACT_CERRADA_COI_VTA", CON_GCO)
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



        dgw2.Columns.Item(19).ReadOnly = True
        dgw2.Columns.Item(20).ReadOnly = True
        dgw2.Columns.Item(21).ReadOnly = True
        'dgw2.Columns.Item(22).ReadOnly = True
    End Sub

    Sub CARGAR_PENDIENTES()
        Try
            COD_SUC = Integer.Parse(OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP))
        Catch ex As Exception


            COD_SUC = 1
        End Try
        Try
            Dim CMD As New SqlCommand("COI_MOSTRAR_I_FACT_PTE_COI_VTA", CON_GCO)
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
            dgw1.Columns.Item(22).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dgw1.Columns.Item(10).ReadOnly = False
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
        dgw1.Columns.Item(22).ReadOnly = True

        dgw1.Columns.Item(19).ReadOnly = True
        dgw1.Columns.Item(20).ReadOnly = True
        dgw1.Columns.Item(21).ReadOnly = True
        dgw1.Columns.Item(22).ReadOnly = True
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

        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            dgw1.Item(10, I).Value = ch1.Checked
            I += 1
        Loop

    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        If ch2.Checked Then
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw2.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                dgw2.Item(10, I).Value = True
                I += 1
            Loop
        End If
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
    End Sub

    Public Sub DES_DOC_STATUS(ByVal FIla As Integer)
        Try
            Dim pro_02 As New SqlCommand("COI_DOC_STATUS2_VTA", CON_GCO)
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
                    Dim pro_02 As New SqlCommand("COI_DOC_STATUS_VTA", CON_GCO)
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
            Dim pro_02 As New SqlCommand("COI_DOC_STATUS_VTA", CON_GCO)
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
        Try
            Dim pro_02 As New SqlCommand("COI_MOSTRAR_T_FACT_DETALLES_VTA", CON_GCO)
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
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_mov1.Rows.Add(New Object() {(rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)), (rs2.GetValue(20)), (rs2.GetValue(21)), (rs2.GetValue(22)), (rs2.GetValue(24)), (rs2.GetValue(25))})
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
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (dgw_mov1.Item(1, I).Value.ToString <> "") Then
                If dgw_mov1.Item(22, I).Value = 0 Then
                    'SIN IGV
                    dgw_mov1.Item(11, I).Value = OBJ.HALLAR_ORDEN_CUENTA2("B", AÑO, "V", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                Else
                    dgw_mov1.Item(11, I).Value = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "V", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                End If
            End If
            I += 1
        Loop
    End Sub
    Private Sub GCO_TRANSFERENCIA_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(95) = 0
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
        CUENTA_IGV = OBJ.GCO_DIR_TABLA_DESC("IGVV", "TCTAS", CON_GCO)
        ORDEN_IGV = OBJ.HALLAR_ORDEN_CUENTA("I", AÑO, "V", CUENTA_IGV.Substring(0, 3))
        IGV0 = Decimal.Parse(OBJ.IMPUESTO("IGV"))
        CARGAR_CERRADAS()
    End Sub

    Public Sub INSERTAR_DOCUMENTO()
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
        Dim COD_PERX, DESC_PERX, DOC_PERX As String
        COD_PERX = COD_PER
        DESC_PERX = DESC_PER
        DOC_PERX = DOC_PER
        If STATUS_ANUL = "1" Then
            COD_PERX = "00000"
            DESC_PERX = "ANULADO"
            DOC_PERX = ""
        End If
        dgw_doc_01.Rows.Add(New Object() {COD_AUX, COD_COMP, txt_nro_comp.Text, COD_DOC, NRO_DOC, COD_PERX, DESC_PERX, DOC_PERX, dtp_com.Value, FECHA_DOC, cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10, COD_MONEDA, TCAMBIO, cte_03, COD_DH_DOC, "", 0, FECHA_DOC, "", "", FECHA_DOC, FECHA_DOC, "0", 0, imp_s_t})
        Dim j As Integer = 0
        Dim CONT1 As Integer = CONT
        j = 0
        Do While (j <= CONT1)
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
            Dim imp_doc00 As New Decimal
            imp_doc00 = Decimal.Parse(var3)
            If (var6 <> "S") Then
                imp_doc00 = Decimal.Parse(var4)
            End If
            dgw_det_01.Rows.Add(New Object() {var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, var15, var16, var17, var18, var19, COD_DOC, NRO_DOC, COD_PER, DOC_PER, "0", "B", var20, var21, "0", " ", " ", FECHA_DOC, 0, " ", var22, imp_doc00, "0", "0", var23, var24})
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
        Dim ARRAY01 As Object() = New Object() {(CONT + 2).ToString("0000"), CUENTA_IGV, DESC_PER, Math.Round(imp_s_igv, 2), Math.Round(imp_d_igv, 2), DH_IGV, COD_MONEDA, TCAMBIO, " ", " ", " ", ORDEN_IGV, FECHA_VEN, 0, " ", " ", " ", " ", " ", FECHA_DOC, COD_DOC, NRO_DOC, COD_PER, DOC_PER, 0, "I", "", "", "0", " ", " ", FECHA_DOC, 0, " ", 0, imp_igv00, "0", "0", "0", DESC_PER}
        dgw_det_01.Rows.Add(ARRAY01)
        ARRAY01 = New Object(40 - 1) {}
        ARRAY01(0) = (CONT + 3).ToString("0000")
        ARRAY01(1) = CUENTA_TOTAL
        ARRAY01(2) = DESC_PER
        ARRAY01(3) = Math.Round(imp_s_t, 2)
        ARRAY01(4) = Math.Round(imp_d_t, 2)
        ARRAY01(5) = DH_T
        ARRAY01(6) = COD_MONEDA
        ARRAY01(7) = TCAMBIO
        ARRAY01(8) = " "
        ARRAY01(9) = " "
        ARRAY01(10) = " "
        ARRAY01(11) = ORDEN_TOTAL
        ARRAY01(12) = FECHA_VEN
        ARRAY01(13) = 0
        ARRAY01(14) = " "
        ARRAY01(15) = " "
        ARRAY01(16) = " "
        ARRAY01(17) = " "
        ARRAY01(18) = " "
        ARRAY01(19) = FECHA_DOC
        ARRAY01(20) = COD_DOC
        ARRAY01(21) = NRO_DOC
        ARRAY01(22) = COD_PER
        ARRAY01(23) = DOC_PER
        ARRAY01(24) = 0
        ARRAY01(25) = "T"
        ARRAY01(26) = ""
        ARRAY01(27) = ""
        ARRAY01(28) = "0"
        ARRAY01(29) = " "
        ARRAY01(30) = " "
        ARRAY01(31) = FECHA_DOC
        ARRAY01(32) = 0
        ARRAY01(33) = " "
        ARRAY01(34) = 0
        ARRAY01(35) = imp_t00
        ARRAY01(36) = "0"
        ARRAY01(37) = "0"
        ARRAY01(38) = "0"
        ARRAY01(39) = DESC_PER
        dgw_det_01.Rows.Add(ARRAY01)
    End Sub

    Public Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.Rows.Count - 1)
        DT_DOC.Rows.Clear()
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            DT_DOC.Rows.Add(New Object() {AÑO, MES, (dgw_doc_01.Item(3, I).Value), (dgw_doc_01.Item(4, I).Value), (dgw_doc_01.Item(5, I).Value), (dgw_doc_01.Item(7, I).Value), COD_AUX, COD_COMP, txt_nro_comp.Text, dtp_com.Value, (dgw_doc_01.Item(6, I).Value), DateTime.Parse((dgw_doc_01.Item(9, I).Value)), "", "", DateTime.Parse((dgw_doc_01.Item(9, I).Value)), Decimal.Parse((dgw_doc_01.Item(10, I).Value)), Decimal.Parse((dgw_doc_01.Item(11, I).Value)), Decimal.Parse((dgw_doc_01.Item(12, I).Value)), Decimal.Parse((dgw_doc_01.Item(13, I).Value)), Decimal.Parse((dgw_doc_01.Item(14, I).Value)), Decimal.Parse((dgw_doc_01.Item(15, I).Value)), Decimal.Parse((dgw_doc_01.Item(16, I).Value)), Decimal.Parse((dgw_doc_01.Item(17, I).Value)), Decimal.Parse((dgw_doc_01.Item(18, I).Value)), Decimal.Parse((dgw_doc_01.Item(19, I).Value)), (dgw_doc_01.Item(20, I).Value), Decimal.Parse((dgw_doc_01.Item(21, I).Value)), (dgw_doc_01.Item(23, I).Value), (dgw_doc_01.Item(24, I).Value), (dgw_doc_01.Item(25, I).Value), DateTime.Parse((dgw_doc_01.Item(26, I).Value)), DateTime.Parse((dgw_doc_01.Item(30, I).Value)), (dgw_doc_01.Item(31, I).Value), (dgw_doc_01.Item(32, I).Value), NOMBRE_PC, (dgw_doc_01.Item(33, I).Value)})
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.REGISTRO_VENTAS2"
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
        Dim CONT1 As Integer = CONT
        I = 0
        Do While (I <= CONT1)
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "", "", DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC, "0")
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
            INSERTAR_TODO = estado

            Return INSERTAR_TODO

        End Try
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_VENTAS", con)
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
            Dim CONT1 As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT1)
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
            Dim CONT1 As Integer = (dgw2.RowCount - 1)
            i = 0
            Do While (i <= CONT1)
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
            If ((dgw_mov1.Item(1, I).Value.ToString <> "") AndAlso (OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "V", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3)) = "0")) Then
                SB.ToString.Trim(dgw_mov1.Item(1, I).Value.ToString)
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

    Public Function VALIDAR_IMPORTE() As Boolean
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
            If dgw_mov1.Item(6, I).Value.ToString = "A" Then
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
            If (dgw_mov1.Item(5, I).Value.ToString = "D") Then
                SOLESD = SOLESD + sol
                DOLARESD = DOLARESD + dol
            Else
                SOLESH = SOLESH + sol
                DOLARESH = DOLARESH + dol
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
                    Dim ORDEN0 As String = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "V", CTA_AJ)
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
        Dim CONT As Integer = (dgw_det_01.RowCount - 1)
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
            If dgw_det_01.Item(6, I).Value.ToString = "A" Then
                dgw_det_01.Rows.RemoveAt(I)
                I = 0
                CONT0 = (dgw_det_01.RowCount - 1)
            Else
                I += 1
            End If
        End While
        '-----------------------------
        I = 0
        CONT0 = (dgw_det_01.RowCount - 1)
        Do While (I <= CONT0)
            Dim sol, dol As Decimal
            sol = dgw_det_01.Item(3, I).Value
            dol = dgw_det_01.Item(4, I).Value
            If (dgw_det_01.Item(5, I).Value.ToString = "D") Then
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
        '---------------------------------------------
        '--------------------------------------------
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
                    Dim ORDEN0 As String = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "V", CTA_AJ)
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

    Public Function VERIFICAR_CC() As Boolean
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
    Public Function VERIFICAR_CUENTA() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim k1 As String = dgw_det_01.Item(1, I).Value.ToString.Trim
            If (k1 = "") And dgw_det_01.Item(3, I).Value > 0 Then
                SB.ToString.Trim(k1)
                SB.AppendLine(String.Concat(New String() {k1, " ", dgw_det_01.Item(2, I).Value.ToString, "  -  ", dgw_det_01.Item(39, I).Value.ToString}))
            Else
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
                        SB.AppendLine((String.Concat(String.Concat(String.Concat(String.Concat((Rs3.GetValue(0)), " "), dgw_det_01.Item(2, I).Value.ToString), "  -  "), dgw_det_01.Item(39, I).Value.ToString)))
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
        MessageBox.Show(String.Concat(New String() {"Documento ", COD_DOC, " - Nº ", NRO_DOC, vbCrLf & "Cta.Cte. ", COD_PER, " ", DESC_PER, " ", DOC_PER, vbCrLf & vbCrLf & "No existen en el Plan de cuentas : " & vbCrLf, SB.ToString}), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Public Function VERIFICAR_ORDEN() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim TIPO_ORDEN0 As String = dgw_det_01.Item(25, I).Value.ToString
            If (((TIPO_ORDEN0 = "B") Or (TIPO_ORDEN0 = "I")) AndAlso (dgw_det_01.Item(11, I).Value.ToString = "")) Then
                SB.ToString.Trim(dgw_det_01.Item(1, I).Value.ToString)
                SB.AppendLine((dgw_det_01.Item(1, I).Value.ToString & " Tipo : " & TIPO_ORDEN0))
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen Orden para la Cuenta Contable : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
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

    Public Function VERIFICAR_PROYECTO() As Boolean
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

    Friend WithEvents base_ref As DataGridViewTextBoxColumn
    Friend WithEvents btn_aceptar As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents btn_buscar1 As Button
    Friend WithEvents btn_buscar2 As Button
    Friend WithEvents btn_sgt1 As Button
    Friend WithEvents btn_sgt2 As Button
    Friend WithEvents cbo_aux As ComboBox
    Friend WithEvents cbo_com As ComboBox
    Friend WithEvents ch_cadena1 As RadioButton
    Friend WithEvents ch_cadena2 As RadioButton
    Friend WithEvents ch_comp As CheckBox
    Friend WithEvents ch_doc1 As RadioButton
    Friend WithEvents ch_doc2 As RadioButton
    Friend WithEvents ch_per1 As RadioButton
    Friend WithEvents ch_per2 As RadioButton
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents ch2 As CheckBox
    Friend WithEvents cod_cc_dg As DataGridViewTextBoxColumn
    Friend WithEvents cod_cc_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_contro_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_control As DataGridViewTextBoxColumn
    Friend WithEvents cod_cpto_dg As DataGridViewTextBoxColumn
    Friend WithEvents cod_cpto_dg2 As DataGridViewTextBoxColumn
    Friend WithEvents Cod_cta As DataGridViewTextBoxColumn
    Friend WithEvents cod_d_h As DataGridViewTextBoxColumn
    Friend WithEvents cod_d_h_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_doc_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_moneda_dg As DataGridViewTextBoxColumn
    Friend WithEvents cod_moneda_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_per_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_proyecto As DataGridViewTextBoxColumn
    Friend WithEvents cod_proyecto_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents cod_ref_dg As DataGridViewTextBoxColumn
    Friend WithEvents cod_tasa_det As DataGridViewTextBoxColumn
    Friend WithEvents codigo_dh As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents COLUUMNStatus_pv As DataGridViewTextBoxColumn
    Friend WithEvents cta_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta_Destino As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta_Enlace As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents destino_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents dgw_det_01 As DataGridView
    Friend WithEvents dgw_doc_01 As DataGridView
    Friend WithEvents dgw_mov1 As DataGridView
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents dgw2 As DataGridView
    Friend WithEvents dtp_com As DateTimePicker
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents enlace_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents fecha_det As DataGridViewTextBoxColumn
    Friend WithEvents fecha_doc_dg_0 As DataGridViewTextBoxColumn
    Friend WithEvents fecha_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_pago As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_ref_dg As DataGridViewTextBoxColumn
    Friend WithEvents Glosa As DataGridViewTextBoxColumn
    Friend WithEvents glosa_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents IGV As DataGridViewTextBoxColumn
    Friend WithEvents imp_d_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Imp_Dolares As DataGridViewTextBoxColumn
    Friend WithEvents imp_s_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Imp_Soles As DataGridViewTextBoxColumn
    Friend WithEvents imp09 As DataGridViewTextBoxColumn
    Friend WithEvents imp10 As DataGridViewTextBoxColumn
    Friend WithEvents item As DataGridViewTextBoxColumn
    Friend WithEvents item_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Nombre_per As DataGridViewTextBoxColumn
    Friend WithEvents nro_det As DataGridViewTextBoxColumn
    Friend WithEvents nro_doc_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents nro_doc_per_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents nro_orden_dg As DataGridViewTextBoxColumn
    Friend WithEvents nro_orden_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Nro_ref_dg As DataGridViewTextBoxColumn
    Friend WithEvents Num_dias As DataGridViewTextBoxColumn
    Friend WithEvents num_dias_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents pv_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents status_auto_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents status_c_dg As DataGridViewTextBoxColumn
    Friend WithEvents status_c_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents status_cc_dg As DataGridViewTextBoxColumn
    Friend WithEvents status_cc_doc As DataGridViewTextBoxColumn
    Friend WithEvents status_cta_dg As DataGridViewTextBoxColumn
    Friend WithEvents status_p_dg As DataGridViewTextBoxColumn
    Friend WithEvents status_p_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents status_pago As DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tc_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Cambio As DataGridViewTextBoxColumn
    Friend WithEvents tipo_t_doc2 As DataGridViewTextBoxColumn
    Friend WithEvents txt_letra1 As TextBox
    Friend WithEvents txt_letra2 As TextBox
    Friend WithEvents txt_nro_comp As TextBox
    Friend WithEvents var_cuenta_dg As DataGridViewTextBoxColumn

    Private Sub ch_comp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_comp.CheckedChanged

    End Sub
End Class