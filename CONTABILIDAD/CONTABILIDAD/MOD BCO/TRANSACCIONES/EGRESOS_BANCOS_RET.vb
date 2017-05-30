Imports System.Data.SqlClient
Public Class EGRESOS_BANCOS_RET
    Dim BOTON, COD_AUX, VAR_PRO, STATUS_PER, STATUS_P, STATUS_CC, CPTO_RET, COD_CC, COD_SUC0, COD_COMP, COD_CONTROL, COD_CUENTA, COD_D_H, COD_DH_GRAL, COD_DOC, COD_MON_DOC, COD_MONEDA, COD_MP, COD_PROYECTO As String
    Private CON_GCO As New SqlConnection
    Private DT As New DataTable
    Private fila2 As Integer
    Private IGV0, IMP_INICIAL, IMP_S, POR_RET As Decimal
    Private OBJ As New Class1
    Private OFR As New CONSULTA_PCTAS_PAGAR
    Sub BANCOS00()
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

    Sub BOTON3()
        OFR.COD_SUC = OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        OFR.COD_CPTO00 = txt_cod_cta.Text
        OFR.COD_PER00 = txt_cod1.Text
        OFR.CARGAR_PCTAS_PAGAR_PERSONA()
        OFR.ShowDialog()
        If (OFR.DialogResult = Windows.Forms.DialogResult.OK) Then
            If (OFR.LBL.Text = "NO") Then
                BOTON3()
            Else
                INSERTAR_DE_DAILOG()
                OFR.Hide()
                HALLAR_TOTAL()
            End If
            Panel_det.Visible = False
            btn_nuevo_doc.Focus()
        End If
    End Sub

    Private Sub btn_anular_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_anular.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        Dim respuesta As String = (CInt(MessageBox.Show("Eliga SI(anular),NO(cancelar anulación),CANCELAR para salir.", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)))
        If (Decimal.Parse(respuesta) = 6) Then
            CARGAR_DATOS()
            Dim estado0 As String = "0"
            If (Decimal.Parse(respuesta) = 6) Then
                estado0 = "1"
            End If
            txt_cod_ban.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            txt_desc_ban.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            COD_MP = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            cbo_mp.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
            txt_num_mp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
            TXT_IMP_ANT.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
            If (REGRESAR_GCO() = "FALLO") Then
                MessageBox.Show("Ocurrió un error.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            Else
                Dim ESTADO As String = "FALLO"
                Try
                    Dim comand1 As New SqlCommand("ANULAR_I_BAN_INGRESO", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
                    comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
                    comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
                    comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = TXT_IMP_ANT.Text
                    comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                    comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                    comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                    comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    comand1.Parameters.Add("@ESTADO0", SqlDbType.VarChar).Value = estado0
                    con.Open()
                    ESTADO = (comand1.ExecuteScalar)
                    con.Close()
                Catch ex As Exception

                    con.Close()
                    MsgBox(ex.Message)
                    ESTADO = "FALLO"

                End Try
                If (ESTADO = "FALLO") Then
                    MessageBox.Show("Ocurrió un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                DATAGRID()
            End If
        ElseIf (Decimal.Parse(respuesta) = 7) Then
            txt_cod_ban.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            txt_desc_ban.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            COD_MP = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            cbo_mp.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
            txt_num_mp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
            TXT_IMP_ANT.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("DES_ANULAR_I_BAN_INGRESO", con)
                comand1.CommandType = CommandType.StoredProcedure
                comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
                comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
                comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
                comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = TXT_IMP_ANT.Text
                comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                comand1.Parameters.Add("@ESTADO0", SqlDbType.VarChar).Value = "0"
                con.Open()
                ESTADO = (comand1.ExecuteScalar)
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
                ESTADO = "FALLO"

            End Try
            If (ESTADO = "FALLO") Then
                MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            DATAGRID()
        End If
    End Sub

    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim CONT0 As Integer = (DGW_PER2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(DGW_PER2.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_per.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    DGW_PER2.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        DGW_PER2.Focus()
    End Sub

    Private Sub btn_cancelar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_com.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar1.Click
        Panel_det.Visible = False
        btn_nuevo_doc.Focus()
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consultar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        BOTON = "MODIFICAR"
        LIMPIAR_COMPROBANTE()
        CARGAR_DATOS()
        btn_grabar_com.Visible = False
        g_com.Enabled = False
        btn_imprimir.Enabled = True
        TabControl1.SelectedTab = TabPage2
        btn_imprimir.Focus()
    End Sub

    Private Sub btn_doc_pte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_doc_pte.Click
        If (txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (txt_num_mp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            ElseIf (txt_cod1.Text.Trim = "") Then
                MessageBox.Show("Debe elegir la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod1.Focus()
            ElseIf (cbo_com.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir el comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_com.Focus()
            ElseIf (txt_cod_cta.Text.Trim = "") Then
                MessageBox.Show("Debe elegir el concepto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta.Focus()
            Else
                BOTON3()
            End If
        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Desea eliminar el Comprobante", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            CARGAR_DATOS()
            TXT_IMP_ANT.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
            If dgw1.Item(14, dgw1.CurrentRow.Index).Value.ToString = "True" Then
                TXT_IMP_ANT.Text = (0)
            End If
            txt_cod_ban.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            txt_desc_ban.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            COD_MP = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            cbo_mp.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
            txt_num_mp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
            If (REGRESAR_GCO() = "FALLO") Then
                MessageBox.Show("Ocurrió un error.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            Else
                Dim ESTADO As String = "FALLO"
                Try
                    Dim comand1 As New SqlCommand("ELIMINAR_I_BAN_INGRESO", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
                    comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
                    comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
                    comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = TXT_IMP_ANT.Text
                    comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                    comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                    comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                    comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    con.Open()
                    ESTADO = (comand1.ExecuteScalar)
                    con.Close()
                Catch ex As Exception

                    con.Close()
                    MsgBox(ex.Message)
                    ESTADO = "FALLO"

                End Try
                If (ESTADO = "FALLO") Then
                    MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                DATAGRID()
            End If
        End If
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el Detalle.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            dgw_mov1.Rows.RemoveAt(dgw_mov1.CurrentRow.Index)
        End If
        HALLAR_TOTAL()
    End Sub

    Private Sub btn_grabar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com.Click
        If (txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (txt_num_mp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            ElseIf (dgw_mov1.RowCount = 0) Then
                MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btn_nuevo_doc.Focus()
            ElseIf (INSERTAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                btn_grabar_com.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
            Else
                OBJ.ELIMINAR_TEMPORAL("TBAN")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_grabar_com2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com2.Click
        If (txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (txt_num_mp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            ElseIf (dgw_mov1.RowCount = 0) Then
                MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btn_nuevo_doc.Focus()
            ElseIf (REGRESAR_GCO() = "FALLO") Then
                MessageBox.Show("Ocurrió un error.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            ElseIf (MODIFICAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                btn_grabar_com2.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
            Else
                OBJ.ELIMINAR_TEMPORAL("TBAN")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (txt_cod1.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod1.Focus()
        ElseIf (cbo_tipo_doc.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc.Focus()
        ElseIf (txt_nro_doc.Text.Trim = "") Then
            MessageBox.Show("Debe ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc.Focus()
        ElseIf (cbo_moneda1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda1.Focus()
        Else
            If (txt_imp_soles.Text.Trim = "") Then
                txt_imp_soles.Text = "0.00"
            End If
            If (Decimal.Parse(txt_imp_soles.Text) = 0) Then
                MessageBox.Show("Debe ingresar el importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_imp_soles.Focus()
            ElseIf (txt_cod_cta.Text.Trim = "") Then
                MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta.Focus()
            ElseIf ((cbo_cc.SelectedIndex = -1) And cbo_cc.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_cc.Focus()
            ElseIf ((cbo_proyecto.SelectedIndex = -1) And cbo_proyecto.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_proyecto.Focus()
            Else
                COD_DOC = OBJ.COD_DOC(cbo_tipo_doc.Text)
                COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
                STATUS_PER = "1"
                VAR_PRO = "N"
                IMP_S = Decimal.Parse(txt_imp_soles.Text)
                Dim imp_pago As New Decimal
                If (COD_MON_DOC = COD_MONEDA) Then
                    imp_pago = IMP_S
                ElseIf (COD_MON_DOC = "D") Then
                    imp_pago = New Decimal((Convert.ToDouble(IMP_S) / Decimal.Parse(txt_cambio.Text)))
                Else
                    imp_pago = New Decimal((Convert.ToDouble(IMP_S) * Decimal.Parse(txt_cambio.Text)))
                End If
                COD_CONTROL = ""
                COD_PROYECTO = ""
                COD_CC = ""
                'If (cbo_control.SelectedIndex <> -1) Then
                '    COD_CONTROL = OBJ.COD_CONTROL(cbo_control.Text)
                'End If
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_PROYECTO = OBJ.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (cbo_cc.SelectedIndex <> -1) Then
                    COD_CC = OBJ.COD_CC(cbo_cc.Text)
                End If
                If VALIDAR_DET(COD_DOC, txt_nro_doc.Text, txt_cod1.Text) = False Then
                    MessageBox.Show("El documento ya se ingresó.", "No se puede ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim VAR4 As Object() = New Object() {(dgw_mov1.RowCount + 1).ToString("0000"), COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, IMP_S, imp_pago, COD_MON_DOC, COD_D_H, txt_cambio.Text, dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, "", dtp_mp.Value, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, STATUS_PER, VAR_PRO}
                    dgw_mov1.Rows.Add(VAR4)
                    HALLAR_TOTAL()
                    LIMPIAR_DETALLES()
                    txt_cod1.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btn_mod_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod_doc.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        LIMPIAR_DETALLES()
        btn_doc_pte.Enabled = False
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        TXT_ITEM0.Text = (dgw_mov1.CurrentRow.Index)
        CARGAR_DETALLES(TXT_ITEM0.Text)
        Panel_det.Visible = True
        txt_imp_soles.Focus()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        If dgw1.Item(14, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            MessageBox.Show("El Comprobante esta anulado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            BOTON = "MODIFICAR"
            LIMPIAR_COMPROBANTE()
            CARGAR_DATOS()
            btn_grabar_com.Visible = False
            btn_grabar_com2.Visible = True
            g_com.Enabled = False
            btn_grabar_com2.Enabled = True
            btn_imprimir.Enabled = False
            TabControl1.SelectedTab = TabPage2
            btn_nuevo_doc.Focus()
        End If
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (txt_cod1.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Documento Pendiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod1.Focus()
        ElseIf (cbo_tipo_doc.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc.Focus()
        ElseIf (txt_nro_doc.Text.Trim = "") Then
            MessageBox.Show("Debe ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc.Focus()
        ElseIf (cbo_moneda1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda1.Focus()
        Else
            If (txt_imp_soles.Text.Trim = "") Then
                txt_imp_soles.Text = "0.00"
            End If
            If (Decimal.Parse(txt_imp_soles.Text) = 0) Then
                MessageBox.Show("Debe ingresar el importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_imp_soles.Focus()
            ElseIf (txt_cod_cta.Text.Trim = "") Then
                MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta.Focus()
            ElseIf ((cbo_cc.SelectedIndex <> -1) And cbo_cc.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_cc.Focus()
            ElseIf ((cbo_proyecto.SelectedIndex <> -1) And cbo_proyecto.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_proyecto.Focus()
            Else
                COD_DOC = OBJ.COD_DOC(cbo_tipo_doc.Text)
                COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
                STATUS_PER = "1"
                VAR_PRO = "N"
                IMP_S = Decimal.Parse(txt_imp_soles.Text)
                Dim imp_pago As New Decimal
                If (COD_MON_DOC = COD_MONEDA) Then
                    imp_pago = IMP_S
                ElseIf (COD_MONEDA = "D") Then
                    imp_pago = New Decimal((Convert.ToDouble(IMP_S) / Decimal.Parse(txt_cambio.Text)))
                Else
                    imp_pago = New Decimal((Convert.ToDouble(IMP_S) * Decimal.Parse(txt_cambio.Text)))
                End If
                If (COD_MON_DOC = "D") Then
                    IMP_S = Decimal.Parse(txt_imp_soles.Text)
                End If
                COD_CONTROL = ""
                COD_PROYECTO = ""
                COD_CC = ""
                If (cbo_cc.SelectedIndex <> -1) Then
                    COD_CC = OBJ.COD_CC(cbo_cc.Text)
                End If
                'If (cbo_control.SelectedIndex <> -1) Then
                '    COD_CONTROL = OBJ.COD_CONTROL(cbo_control.Text)
                'End If
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_PROYECTO = OBJ.COD_PROYECTO(cbo_proyecto.Text)
                End If
                Dim FILA0 As Integer = Integer.Parse(TXT_ITEM0.Text)
                dgw_mov1.Item(6, FILA0).Value = IMP_S
                dgw_mov1.Item(7, FILA0).Value = imp_pago
                dgw_mov1.Item(8, FILA0).Value = COD_MON_DOC
                dgw_mov1.Item(12, FILA0).Value = txt_glosa.Text
                dgw_mov1.Item(13, FILA0).Value = txt_cod_cta.Text
                dgw_mov1.Item(14, FILA0).Value = COD_CUENTA
                dgw_mov1.Item(16, FILA0).Value = COD_CC
                dgw_mov1.Item(17, FILA0).Value = COD_CONTROL
                dgw_mov1.Item(18, FILA0).Value = COD_PROYECTO
                HALLAR_TOTAL()
                Panel_det.Visible = False
                btn_nuevo_doc.Focus()
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        LIMPIAR_COMPROBANTE()
        BOTON = "NUEVO"
        TabControl1.SelectedTab = TabPage2
        txt_cod_ban.Focus()
    End Sub

    Private Sub btn_nuevo_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_doc.Click
        If (txt_cod_ban.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Focus()
        ElseIf panel_bancos.Visible Then
            MessageBox.Show("Debe elegir el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_ban.Focus()
        ElseIf (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (txt_num_mp.Text.Trim = "") Then
            MessageBox.Show("No existe numeración del Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            ElseIf (txt_desc_giro.Text.Trim = "") Then
                MessageBox.Show("Debe insertar la descripción de operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_desc_giro.Focus()
            ElseIf OBJ.VERIFICAR_NRO_MP_BANCO(txt_cod_ban.Text, COD_MP, txt_num_mp.Text) Then
                g_com.Enabled = False
                LIMPIAR_DETALLES()
                Panel_det.Visible = True
                txt_cod1.Focus()
            End If
        End If
    End Sub

    Private Sub Btn_Ret_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Ret.Click
        GENERAR_AUTO()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(28) = 0
        Close()
    End Sub

    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim CONT0 As Integer = (DGW_PER2.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(DGW_PER2.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_per.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    DGW_PER2.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        DGW_PER2.Focus()
    End Sub

    Sub CARGAR_CONCEPTO()
        DGW_CTA1.DataSource = OBJ.MOSTRAR_CONCEPTOS_STATUS("E")
        DGW_CTA1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_CTA1.Columns.Item(2).Visible = False
        DGW_CTA1.Columns.Item(3).Visible = False
        DGW_CTA1.Columns.Item(4).Visible = False
        DGW_CTA1.Columns.Item(0).Width = 50
    End Sub

    Sub CARGAR_DATOS()
        txt_cod_ban.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        txt_desc_ban.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_MP = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        cbo_mp.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_num_mp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_giro.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        dtp_mp.Value = Date.Parse(dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString)
        TXT_IMP_ANT.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        COD_MONEDA = dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString
        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
        COD_AUX = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        CBO_COMPROBANTE00()
        COD_COMP = dgw1.Item(12, dgw1.CurrentRow.Index).Value.ToString
        cbo_com.Text = OBJ.DESC_COMPROBANTE(COD_AUX, COD_COMP)
        txt_nro_comp.Text = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        txt_cambio.Text = dgw1.Item(13, dgw1.CurrentRow.Index).Value.ToString
        txt_saldo.Text = dgw1.Item(15, dgw1.CurrentRow.Index).Value.ToString
        dtp_dif.Value = Date.Parse(dgw1.Item(16, dgw1.CurrentRow.Index).Value.ToString)
        dgw_mov1.Rows.Clear()
        dgw_det2.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_BAN_EGRESO", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            pro_02.Parameters.Add("@cod_mP", SqlDbType.VarChar).Value = COD_MP
            pro_02.Parameters.Add("@nro_mP", SqlDbType.VarChar).Value = txt_num_mp.Text
            pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                If rs3.GetValue(23) = "R " Then
                    dgw_ret.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetValue(15), rs3.GetValue(16), rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), rs3.GetValue(23))
                Else
                    dgw_mov1.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetValue(15), rs3.GetValue(16), rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), rs3.GetValue(23))
                    dgw_det2.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetValue(15), rs3.GetValue(16), rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), rs3.GetValue(23))
                End If
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        HALLAR_TOTAL()
    End Sub

    Sub CARGAR_DETALLES(ByVal FILA0 As Object)
        VAR_PRO = dgw_mov1.Item(23, Integer.Parse(FILA0)).Value.ToString
        COD_DOC = dgw_mov1.Item(1, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc.Text = dgw_mov1.Item(2, Integer.Parse(FILA0)).Value.ToString
        txt_cod1.Text = dgw_mov1.Item(3, Integer.Parse(FILA0)).Value.ToString
        txt_desc_per.Text = dgw_mov1.Item(4, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc_per.Text = dgw_mov1.Item(5, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = dgw_mov1.Item(6, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = (OBJ.HACER_DECIMAL(txt_imp_soles.Text))
        COD_MON_DOC = dgw_mov1.Item(8, Integer.Parse(FILA0)).Value.ToString
        COD_D_H = dgw_mov1.Item(9, Integer.Parse(FILA0)).Value.ToString
        txt_glosa.Text = dgw_mov1.Item(12, Integer.Parse(FILA0)).Value.ToString
        txt_cod_cta.Text = dgw_mov1.Item(13, Integer.Parse(FILA0)).Value.ToString
        txt_desc_cta.Text = OBJ.DESC_CPTO(txt_cod_cta.Text)
        COD_CUENTA = dgw_mov1.Item(14, Integer.Parse(FILA0)).Value.ToString
        COD_CC = dgw_mov1.Item(16, Integer.Parse(FILA0)).Value.ToString
        COD_CONTROL = dgw_mov1.Item(17, Integer.Parse(FILA0)).Value.ToString
        COD_PROYECTO = dgw_mov1.Item(18, Integer.Parse(FILA0)).Value.ToString
        STATUS_CC = dgw_mov1.Item(19, Integer.Parse(FILA0)).Value.ToString
        STATUS_P = dgw_mov1.Item(21, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_doc.Text = OBJ.DESC_DOC(COD_DOC)
        cbo_moneda1.Text = OBJ.DESC_MONEDA(COD_MON_DOC)
        cbo_cc.Text = OBJ.DESC_CC(COD_CC)
        'cbo_control.Text = OBJ.DESC_CONTROL(COD_CONTROL)
        cbo_proyecto.Text = OBJ.DESC_PROYECTO(COD_PROYECTO)
        If (VAR_PRO = "S") Then
            txt_cod1.Enabled = False
            txt_desc_per.Enabled = False
            txt_nro_doc_per.Enabled = False
            cbo_tipo_doc.Enabled = False
            txt_nro_doc.Enabled = False
            cbo_moneda.Enabled = False
        Else
            txt_cod1.Enabled = True
            txt_desc_per.Enabled = True
            txt_nro_doc_per.Enabled = True
            cbo_tipo_doc.Enabled = True
            txt_nro_doc.Enabled = True
            cbo_moneda.Enabled = True
        End If
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        If (cbo_com.SelectedIndex <> -1) Then
            COD_COMP = cbo_com.SelectedValue.ToString
            If (COD_COMP <> "System.Data.DataRowView") Then
                COD_COMP = OBJ.COD_COMP(cbo_com.Text, COD_AUX)
                txt_nro_comp.Text = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            End If
        End If
    End Sub

    Sub CBO_COMPROBANTE00()
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

    Sub CBO_CONTROL00()
        'Try
        '    Dim PROG_01 As New SqlCommand("CBO_CONTROL_FECHA", con)
        '    PROG_01.CommandType = CommandType.StoredProcedure
        '    PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA_GRAL
        '    con.Open()
        '    PROG_01.ExecuteNonQuery()
        '    Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
        '    Do While Rs3.Read
        '        cbo_control.Items.Add(Rs3.GetString(0))
        '    Loop
        '    con.Close()
        'Catch ex As Exception


        '    con.Close()
        '    MessageBox.Show(ex.Message)

        'End Try
    End Sub

    Private Sub cbo_moneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda.SelectedIndexChanged
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub

    Sub CBO_MONEDA00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda1.DataSource = DT
        cbo_moneda1.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda1.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda1.SelectedIndex = -1
        Dim GEN2 As New Genericos
        Dim DT2 As New DataTable
        DT2 = GEN2.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT2
        cbo_moneda.DisplayMember = DT2.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT2.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
    End Sub

    Private Sub cbo_mp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mp.SelectedIndexChanged
        If ((cbo_mp.SelectedIndex <> -1) And (txt_cod_ban.Text.Trim <> "")) Then
            COD_MP = OBJ.COD_MP(cbo_mp.Text)
        End If
    End Sub

    Sub CBO_MP00()
        cbo_mp.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_MP", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_mp.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Sub CBO_PROYECTO00()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PROYECTO_FECHA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA_GRAL
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_proyecto.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Sub CBO_TIPO_DOC00()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_doc.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub

    Sub CC00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        cbo_cc.DataSource = DT
        cbo_cc.DisplayMember = DT.Columns.Item(0).ToString
        cbo_cc.ValueMember = DT.Columns.Item(1).ToString
        cbo_cc.SelectedIndex = -1
    End Sub

    Sub DATAGRID()
        Try
            Dim pro As New SqlCommand("MOSTRAR_I_BAN_RETENCION", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(12).Visible = False
            dgw1.Columns.Item(13).Visible = False
            dgw1.Columns.Item(15).Visible = False
            dgw1.Columns.Item(16).Visible = False
            dgw1.Columns.Item(1).Width = 120
            dgw1.Columns.Item(3).Width = &H9B
            dgw1.Columns.Item(4).Width = 100
            dgw1.Columns.Item(5).Width = 110
            dgw1.Columns.Item(6).Width = 35
            dgw1.Columns.Item(7).Width = 100
            dgw1.Columns.Item(8).Width = &H4B
            dgw1.Columns.Item(8).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(9).Width = 80
            dgw1.Columns.Item(9).DefaultCellStyle.Format = "N2"
            dgw1.Columns.Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns.Item(10).Width = 35
            dgw1.Columns.Item(11).Width = &H2C
            dgw1.Columns.Item(14).Width = 35
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            COD_MONEDA = dgw_ban.Item(2, dgw_ban.CurrentRow.Index).Value.ToString
            cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
            COD_AUX = dgw_ban.Item(3, dgw_ban.CurrentRow.Index).Value.ToString
            CBO_COMPROBANTE00()
            txt_saldo.Text = (OBJ.HALLAR_SALDO_BANCOS(txt_cod_ban.Text))
            panel_bancos.Visible = False
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_bancos.Visible = False
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
        End If
    End Sub

    Private Sub DGW_CTA1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_CTA1.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = DGW_CTA1.Item(0, DGW_CTA1.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = DGW_CTA1.Item(1, DGW_CTA1.CurrentRow.Index).Value.ToString
            STATUS_CC = DGW_CTA1.Item(2, DGW_CTA1.CurrentRow.Index).Value.ToString
            STATUS_P = DGW_CTA1.Item(3, DGW_CTA1.CurrentRow.Index).Value.ToString
            COD_D_H = DGW_CTA1.Item(4, DGW_CTA1.CurrentRow.Index).Value.ToString
            cbo_cc.SelectedIndex = -1
            cbo_cc.Enabled = False
            cbo_proyecto.SelectedIndex = -1
            cbo_proyecto.Enabled = False
            If (STATUS_CC = "1") Then
                cbo_cc.Enabled = True
            End If
            If (STATUS_P = "1") Then
                cbo_proyecto.Enabled = True
            End If
            Panel_CTA1.Visible = False
            kl4.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_CTA1.Visible = False
            txt_cod_cta.Clear()
            txt_desc_cta.Clear()
            txt_cod_cta.Focus()
        End If
    End Sub

    Private Sub DGW_PER2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod1.Text = DGW_PER2.Item(0, DGW_PER2.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = DGW_PER2.Item(1, DGW_PER2.CurrentRow.Index).Value.ToString
            txt_nro_doc_per.Text = DGW_PER2.Item(2, DGW_PER2.CurrentRow.Index).Value.ToString
            txt_glosa.Text = txt_desc_per.Text
            Panel_PER2.Visible = False
            KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER2.Visible = False
            txt_cod1.Clear()
            txt_desc_per.Clear()
            txt_nro_doc_per.Clear()
            txt_cod1.Focus()
        End If
    End Sub


    Private Sub dtp_mp_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_mp.LostFocus
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub

    Sub GENERAR_AUTO()
        dgw_ret.Rows.Clear()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim ORIGEN As Decimal = Decimal.Parse(Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(6, I).Value, POR_RET), 100))
            Dim PAGO As Decimal = Decimal.Parse(Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(7, I).Value, POR_RET), 100))
            dgw_ret.Rows.Add(New Object() {(dgw_mov1.Item(0, I).Value), (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(2, I).Value), (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), ORIGEN, PAGO, (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(9, I).Value), (dgw_mov1.Item(10, I).Value), (dgw_mov1.Item(11, I).Value), (dgw_mov1.Item(12, I).Value), CPTO_RET, (dgw_mov1.Item(14, I).Value), (dgw_mov1.Item(15, I).Value), "", "", "", (dgw_mov1.Item(19, I).Value), (dgw_mov1.Item(20, I).Value), (dgw_mov1.Item(21, I).Value), (dgw_mov1.Item(22, I).Value), "R"})
            I += 1
        Loop
    End Sub

    Sub HALLAR_TOTAL()
        Dim total As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim SIGNO As Double = 1
            If (dgw_mov1.Item(9, I).Value.ToString = "H") Then
                SIGNO = -1
            End If
            If (COD_MONEDA = "S") Then
                If (dgw_mov1.Item(8, I).Value.ToString = "S") Then
                    total = New Decimal((Convert.ToDouble(total) + (SIGNO * Convert.ToDouble(Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)))))
                Else
                    total = New Decimal((Convert.ToDouble(total) + ((SIGNO * Convert.ToDouble(Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString))) * Convert.ToDouble(Decimal.Parse(txt_cambio.Text)))))
                End If
            ElseIf (dgw_mov1.Item(8, I).Value.ToString = "S") Then
                total = New Decimal((Convert.ToDouble(total) + ((SIGNO * Convert.ToDouble(Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString))) / Convert.ToDouble(Decimal.Parse(txt_cambio.Text)))))
            Else
                total = New Decimal((Convert.ToDouble(total) + (SIGNO * Convert.ToDouble(Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)))))
            End If
            I += 1
        Loop
        CONT = (dgw_ret.Rows.Count - 1)
        Dim CONT1 As Integer = CONT
        I = 0
        Do While (I <= CONT1)
            If (COD_MONEDA = "S") Then
                If (dgw_ret.Item(8, I).Value.ToString = "S") Then
                    total = Decimal.Subtract(total, Decimal.Parse(dgw_ret.Item(6, I).Value.ToString))
                Else
                    total = Decimal.Subtract(total, Decimal.Multiply(Decimal.Parse(dgw_ret.Item(6, I).Value.ToString), Decimal.Parse(txt_cambio.Text)))
                End If
            ElseIf (dgw_ret.Item(8, I).Value.ToString = "S") Then
                total = Decimal.Subtract(total, Decimal.Divide(Decimal.Parse(dgw_ret.Item(6, I).Value.ToString), Decimal.Parse(txt_cambio.Text)))
            Else
                total = Decimal.Subtract(total, Decimal.Parse(dgw_ret.Item(6, I).Value.ToString))
            End If
            I += 1
        Loop
        COD_DH_GRAL = "H"
        If (Decimal.Compare(total, Decimal.Zero) < 0) Then
            total = Decimal.Multiply(total, Decimal.MinusOne)
            COD_DH_GRAL = "H"
        End If
        txt_saldo_soles.Text = (total)
        txt_saldo_soles.Text = (OBJ.HACER_DECIMAL(txt_saldo_soles.Text))
    End Sub

    Private Sub INGRESOS_BANCOS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub INGRESOS_BANCOS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        Dim EMP00 As String = ""
        EMP00 = OBJ.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = String.Concat(New String() {"data source=", nombre_servidor, ";initial catalog=BD_GCO", COD_EMPRESA, ";uid=miguel;pwd=main;"})
        DATAGRID()
        CBO_TIPO_DOC00()
        CBO_CONTROL00()
        CBO_PROYECTO00()
        CBO_MONEDA00()
        CBO_MP00()
        CARGAR_CONCEPTO()
        CC00()
        BANCOS00()
        PERSONAS()
        dtp_mp.Value = FECHA_GRAL
        dtp_dif.Value = FECHA_GRAL
        COD_DH_GRAL = "D"
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_ret.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        POR_RET = OBJ.PORC_TIPO_CANC("01")
        CPTO_RET = "RET01"
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
        DT.Columns.Add("TIPO_CAMBIO")
        DT.Columns.Add("TIPO_CAMBIO_PRO")
        DT.Columns.Add("COD_CC")
        DT.Columns.Add("COD_CONTROL")
        DT.Columns.Add("COD_PROYECTO")
        DT.Columns.Add("STATUS_TRANS")
        DT.Columns.Add("FECHA_MP")
        DT.Columns.Add("FECHA_VEN")
        DT.Columns.Add("NOMBRE_PC")
        btn_nuevo.Select()
    End Sub
    Sub INSERTAR_DE_DAILOG()
        COD_CONTROL = ""
        COD_PROYECTO = ""
        COD_CC = ""
        'If (cbo_control.SelectedIndex <> -1) Then
        '    COD_CONTROL = OBJ.COD_CONTROL(cbo_control.Text)
        'End If
        If (cbo_proyecto.SelectedIndex <> -1) Then
            COD_PROYECTO = OBJ.COD_PROYECTO(cbo_proyecto.Text)
        End If
        If (cbo_cc.SelectedIndex <> -1) Then
            COD_CC = OBJ.COD_CC(cbo_cc.Text)
        End If
        Dim CONT As Integer = (OFR.DGW_CAB.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        Dim K As Integer = 0
        Do While (K <= CONT0)
            If OFR.DGW_CAB.Item(9, K).Value.ToString = "True" Then
                Dim imp_pago As Decimal
                If (OFR.DGW_CAB.Item(6, K).Value.ToString = COD_MONEDA) Then
                    imp_pago = Decimal.Parse(OFR.DGW_CAB.Item(8, K).Value)
                ElseIf ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                    imp_pago = Decimal.Parse(OBJ.HACER_DECIMAL(Decimal.Multiply(OFR.DGW_CAB.Item(8, K).Value, txt_cambio.Text)))
                Else
                    imp_pago = Decimal.Parse(OBJ.HACER_DECIMAL(Decimal.Divide(OFR.DGW_CAB.Item(8, K).Value, txt_cambio.Text)))
                End If
                Dim VAR3 As Object() = New Object() {(dgw_mov1.RowCount + 1).ToString("0000"), OFR.DGW_CAB.Item(0, K).Value.ToString, OFR.DGW_CAB.Item(2, K).Value.ToString, OFR.DGW_CAB.Item(3, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(11, K).Value.ToString, OFR.DGW_CAB.Item(8, K).Value.ToString, imp_pago, OFR.DGW_CAB.Item(6, K).Value.ToString, OFR.DGW_CAB.Item(10, K).Value.ToString, txt_cambio.Text, OFR.DGW_CAB.Item(5, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, txt_cod_cta.Text, OFR.DGW_CAB.Item(14, K).Value.ToString, OFR.DGW_CAB.Item(5, K).Value.ToString, COD_CC, COD_CONTROL, COD_PROYECTO, OFR.DGW_CAB.Item(15, K).Value.ToString, OFR.DGW_CAB.Item(16, K).Value.ToString, OFR.DGW_CAB.Item(17, K).Value.ToString, "0", "S"}
                dgw_mov1.Rows.Add(VAR3)
            End If
            K += 1
        Loop
    End Sub

    Function INSERTAR_TODO() As String
        Dim VAR1 As Object()
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim sqlbc2 As New SqlBulkCopy(CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        DT.Rows.Clear()
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            VAR1 = New Object(26 - 1) {}
            VAR1(0) = COD_MP
            VAR1(1) = txt_num_mp.Text
            VAR1(2) = txt_cod_ban.Text
            Dim VARRR As Integer = ((2 * I) + 1)
            VAR1(3) = VARRR.ToString("0000")
            VAR1(4) = AÑO
            VAR1(5) = MES
            VAR1(6) = dgw_mov1.Item(1, I).Value.ToString
            VAR1(7) = dgw_mov1.Item(2, I).Value.ToString
            VAR1(8) = dgw_mov1.Item(3, I).Value.ToString
            VAR1(9) = dgw_mov1.Item(5, I).Value.ToString
            VAR1(10) = DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString)
            VAR1(11) = dgw_mov1.Item(13, I).Value.ToString
            VAR1(12) = dgw_mov1.Item(14, I).Value.ToString
            VAR1(13) = dgw_mov1.Item(12, I).Value.ToString
            VAR1(14) = Decimal.Parse((dgw_mov1.Item(6, I).Value))
            VAR1(15) = dgw_mov1.Item(9, I).Value.ToString
            VAR1(16) = dgw_mov1.Item(8, I).Value.ToString
            VAR1(17) = txt_cambio.Text
            VAR1(18) = Decimal.Parse((dgw_mov1.Item(10, I).Value))
            VAR1(19) = dgw_mov1.Item(16, I).Value.ToString
            VAR1(20) = dgw_mov1.Item(17, I).Value.ToString
            VAR1(21) = dgw_mov1.Item(18, I).Value.ToString
            VAR1(22) = dgw_mov1.Item(23, I).Value.ToString
            VAR1(23) = dtp_mp.Value
            VAR1(24) = DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString)
            VAR1(25) = NOMBRE_PC
            DT.Rows.Add(VAR1)
            I += 1
        Loop
        I = 0
        Do While (I <= CONT0)
            VAR1 = New Object() {COD_MP, txt_num_mp.Text, txt_cod_ban.Text, ((2 * I) + 2).ToString("0000"), AÑO, MES, dgw_ret.Item(1, I).Value.ToString, dgw_ret.Item(2, I).Value.ToString, dgw_ret.Item(3, I).Value.ToString, dgw_ret.Item(5, I).Value.ToString, DateTime.Parse(dgw_ret.Item(11, I).Value.ToString), dgw_ret.Item(13, I).Value.ToString, dgw_ret.Item(14, I).Value.ToString, dgw_ret.Item(12, I).Value.ToString, Decimal.Parse((dgw_ret.Item(6, I).Value)), dgw_ret.Item(9, I).Value.ToString, dgw_ret.Item(8, I).Value.ToString, txt_cambio.Text, Decimal.Parse((dgw_ret.Item(10, I).Value)), dgw_ret.Item(16, I).Value.ToString, dgw_ret.Item(17, I).Value.ToString, dgw_ret.Item(18, I).Value.ToString, dgw_ret.Item(23, I).Value.ToString, dtp_mp.Value, DateTime.Parse(dgw_ret.Item(11, I).Value.ToString), NOMBRE_PC}
            DT.Rows.Add(VAR1)
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
            Dim comand1 As New SqlCommand("INSERTAR_I_BAN_RETENCION", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtp_mp.Value
            comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
            comand1.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_mp.Value
            comand1.Parameters.Add("@DESC_OPE", SqlDbType.VarChar).Value = txt_desc_giro.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_saldo_soles.Text
            comand1.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = "D"
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio.Text
            comand1.Parameters.Add("@FECHA_DIF", SqlDbType.DateTime).Value = dtp_dif.Value
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

    Sub LIMPIAR_COMPROBANTE()
        Dim desc00 As String = cbo_com.Text
        cbo_com.Text = desc00
        g_com.Enabled = True
        Dim desc01 As String = cbo_mp.Text
        cbo_mp.Text = desc01
        txt_num_mp.Clear()
        g_com.Enabled = True
        txt_desc_giro.Clear()
        panel_bancos.Visible = False
        txt_saldo.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        txt_cambio.Text = "0.0000"
        dgw_mov1.Rows.Clear()
        dgw_ret.Rows.Clear()
        Panel_det.Visible = False
        Panel_doc00.Enabled = True
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = False
        btn_grabar_com.Enabled = True
        btn_grabar_com2.Enabled = True
    End Sub

    Sub LIMPIAR_DETALLES()
        btn_doc_pte.Enabled = True
        For Each text As Object In GroupBox2.Controls
            If TypeOf text Is ComboBox Then text.SelectedIndex = -1
        Next
        txt_imp_soles.Text = "0.00"
        txt_nro_doc.Clear()
        txt_cod1.Enabled = True
        txt_desc_per.Enabled = True
        txt_nro_doc_per.Enabled = True
        cbo_tipo_doc.Enabled = True
        txt_nro_doc.Enabled = True
        txt_cod_cta.Enabled = True
        txt_desc_cta.Enabled = True
        cbo_moneda1.Text = cbo_moneda.Text
        cbo_moneda1.Enabled = True
        txt_imp_soles.Text = "0.00"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
    End Sub

    Function MODIFICAR_TODO() As String
        Dim VAR1 As Object()
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim sqlbc2 As New SqlBulkCopy(CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        DT.Rows.Clear()
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            VAR1 = New Object(26 - 1) {}
            VAR1(0) = COD_MP
            VAR1(1) = txt_num_mp.Text
            VAR1(2) = txt_cod_ban.Text
            Dim VAR11 As Integer = ((2 * I) + 1)
            VAR1(3) = VAR11.ToString("0000")
            VAR1(4) = AÑO
            VAR1(5) = MES
            VAR1(6) = dgw_mov1.Item(1, I).Value.ToString
            VAR1(7) = dgw_mov1.Item(2, I).Value.ToString
            VAR1(8) = dgw_mov1.Item(3, I).Value.ToString
            VAR1(9) = dgw_mov1.Item(5, I).Value.ToString
            VAR1(10) = DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString)
            VAR1(11) = dgw_mov1.Item(13, I).Value.ToString
            VAR1(12) = dgw_mov1.Item(14, I).Value.ToString
            VAR1(13) = dgw_mov1.Item(12, I).Value.ToString
            VAR1(14) = Decimal.Parse((dgw_mov1.Item(6, I).Value))
            VAR1(15) = dgw_mov1.Item(9, I).Value.ToString
            VAR1(16) = dgw_mov1.Item(8, I).Value.ToString
            VAR1(17) = txt_cambio.Text
            VAR1(18) = Decimal.Parse((dgw_mov1.Item(10, I).Value))
            VAR1(19) = dgw_mov1.Item(16, I).Value.ToString
            VAR1(20) = dgw_mov1.Item(17, I).Value.ToString
            VAR1(21) = dgw_mov1.Item(18, I).Value.ToString
            VAR1(22) = dgw_mov1.Item(23, I).Value.ToString
            VAR1(23) = dtp_mp.Value
            VAR1(24) = DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString)
            VAR1(25) = NOMBRE_PC
            DT.Rows.Add(VAR1)
            I += 1
        Loop
        I = 0
        Do While (I <= CONT)
            VAR1 = New Object() {COD_MP, txt_num_mp.Text, txt_cod_ban.Text, ((2 * I) + 2).ToString("0000"), AÑO, MES, dgw_ret.Item(1, I).Value.ToString, dgw_ret.Item(2, I).Value.ToString, dgw_ret.Item(3, I).Value.ToString, dgw_ret.Item(5, I).Value.ToString, DateTime.Parse(dgw_ret.Item(11, I).Value.ToString), dgw_ret.Item(13, I).Value.ToString, dgw_ret.Item(14, I).Value.ToString, dgw_ret.Item(12, I).Value.ToString, Decimal.Parse((dgw_ret.Item(6, I).Value)), dgw_ret.Item(9, I).Value.ToString, dgw_ret.Item(8, I).Value.ToString, txt_cambio.Text, Decimal.Parse((dgw_ret.Item(10, I).Value)), dgw_ret.Item(16, I).Value.ToString, dgw_ret.Item(17, I).Value.ToString, dgw_ret.Item(18, I).Value.ToString, dgw_ret.Item(23, I).Value.ToString, dtp_mp.Value, DateTime.Parse(dgw_ret.Item(11, I).Value.ToString), NOMBRE_PC}
            DT.Rows.Add(VAR1)
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
            Dim comand1 As New SqlCommand("MODIFICAR_I_BAN_EGRESO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtp_mp.Value
            comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
            comand1.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_mp.Value
            comand1.Parameters.Add("@DESC_OPE", SqlDbType.VarChar).Value = txt_desc_giro.Text
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = txt_saldo_soles.Text
            comand1.Parameters.Add("@IMP_ANT", SqlDbType.Decimal).Value = TXT_IMP_ANT.Text
            comand1.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = "D"
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio.Text
            comand1.Parameters.Add("@FECHA_DIF", SqlDbType.DateTime).Value = dtp_dif.Value
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

    Sub PERSONAS()
        Try
            DGW_PER2.DataSource = OBJ.MOSTRAR_PERSONAS_PAGAR
            DGW_PER2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER2.Columns.Item(0).Width = &H37
            DGW_PER2.Columns.Item(1).Width = 330
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Function REGRESAR_GCO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det2.Rows.Count - 1)
        DT.Rows.Clear()
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim VAR2 As Object() = New Object() {COD_MP, txt_num_mp.Text, txt_cod_ban.Text, (I + 1).ToString("00"), AÑO, MES, dgw_det2.Item(1, I).Value.ToString, dgw_det2.Item(2, I).Value.ToString, dgw_det2.Item(3, I).Value.ToString, dgw_det2.Item(5, I).Value.ToString, DateTime.Parse(dgw_det2.Item(11, I).Value.ToString), dgw_det2.Item(13, I).Value.ToString, dgw_det2.Item(14, I).Value.ToString, dgw_det2.Item(12, I).Value.ToString, Decimal.Parse((dgw_det2.Item(6, I).Value)), dgw_det2.Item(9, I).Value.ToString, dgw_det2.Item(8, I).Value.ToString, txt_cambio.Text, Decimal.Parse((dgw_det2.Item(10, I).Value)), dgw_det2.Item(16, I).Value.ToString, dgw_det2.Item(17, I).Value.ToString, dgw_det2.Item(18, I).Value.ToString, dgw_det2.Item(23, I).Value.ToString, dtp_mp.Value, DateTime.Parse(dgw_det2.Item(11, I).Value.ToString), NOMBRE_PC}
            DT.Rows.Add(VAR2)
            I += 1
        Loop
        COD_SUC0 = OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        Dim K As Integer = Integer.Parse(COD_SUC0)
        Try
            CON_GCO.Open()
            sqlbc.DestinationTableName = "dbo.COI_T_BANCO2"
            sqlbc.WriteToServer(DT)
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)
            REGRESAR_GCO = estado

            Return REGRESAR_GCO

        End Try
        Try
            Dim comand As New SqlCommand("COI_REGRESAR_T_BAN_EGRESO", CON_GCO)
            comand.CommandType = CommandType.StoredProcedure
            comand.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            comand.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            comand.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_mp.Value
            comand.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
            comand.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
            comand.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            comand.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            comand.Parameters.Add("@COD_SUCURSAL0", SqlDbType.VarChar).Value = K.ToString("0000")
            comand.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            comand.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
            comand.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            comand.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio.Text
            CON_GCO.Open()
            estado = (comand.ExecuteScalar)
            CON_GCO.Close()
        Catch ex As Exception

            CON_GCO.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
            REGRESAR_GCO = estado

            Return REGRESAR_GCO

        End Try
        Return estado
    End Function

    Private Sub txt_cambio_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio.KeyPress
        e.Handled = Numero(e, txt_cambio)
    End Sub

    Private Sub txt_cambio_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio.LostFocus
        Try
            txt_cambio.Text = (OBJ.HACER_CAMBIO(txt_cambio.Text))
        Catch ex As Exception


            txt_cambio.Text = "0.0000"

        End Try
    End Sub

    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        COD_MONEDA = dgw_ban.Item(2, i).Value.ToString
                        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
                        COD_AUX = dgw_ban.Item(3, i).Value.ToString
                        CBO_COMPROBANTE00()
                        txt_saldo.Text = (OBJ.HALLAR_SALDO_BANCOS(txt_cod_ban.Text))
                        cbo_mp.Focus()
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

    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) <> "") Then
            If (DGW_CTA1.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_CTA1.Sort(DGW_CTA1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (DGW_CTA1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta.Text.ToLower = DGW_CTA1.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = DGW_CTA1.Item(0, i).Value.ToString
                        txt_desc_cta.Text = DGW_CTA1.Item(1, i).Value.ToString
                        STATUS_CC = DGW_CTA1.Item(2, i).Value.ToString
                        STATUS_P = DGW_CTA1.Item(3, i).Value.ToString
                        COD_D_H = DGW_CTA1.Item(4, i).Value.ToString
                        cbo_cc.SelectedIndex = -1
                        cbo_cc.Enabled = False
                        cbo_proyecto.SelectedIndex = -1
                        cbo_proyecto.Enabled = False
                        If (STATUS_CC = "1") Then
                            cbo_cc.Enabled = True
                        End If
                        If (STATUS_P = "1") Then
                            cbo_proyecto.Enabled = True
                        End If
                        txt_glosa.Focus()
                        Return
                    End If
                    If (txt_cod_cta.Text.ToLower = Strings.Mid((DGW_CTA1.Item(0, i).Value), 1, Strings.Len(txt_cod_cta.Text)).ToLower) Then
                        DGW_CTA1.CurrentCell = DGW_CTA1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_CTA1.CurrentCell = DGW_CTA1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_CTA1.Visible = True
                DGW_CTA1.Visible = True
                DGW_CTA1.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod1.LostFocus
        If (Strings.Trim(txt_cod1.Text) <> "") Then
            If (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod1.Text.ToLower = DGW_PER2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod1.Text = DGW_PER2.Item(0, i).Value.ToString
                        txt_desc_per.Text = DGW_PER2.Item(1, i).Value.ToString
                        txt_nro_doc_per.Text = DGW_PER2.Item(2, i).Value.ToString
                        txt_glosa.Text = txt_desc_per.Text
                        cbo_tipo_doc.Focus()
                        Return
                    End If
                    If (txt_cod1.Text.ToLower = Strings.Mid((DGW_PER2.Item(0, i).Value), 1, Strings.Len(txt_cod1.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
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

    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (DGW_CTA1.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_CTA1.Sort(DGW_CTA1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (DGW_CTA1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((DGW_CTA1.Item(0, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        DGW_CTA1.CurrentCell = DGW_CTA1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_CTA1.CurrentCell = DGW_CTA1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_CTA1.Visible = True
                DGW_CTA1.Visible = True
                DGW_CTA1.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_giro_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_giro.KeyDown
        If (e.KeyCode = Keys.Return) Then
            Panel_doc00.Focus()
        End If
    End Sub

    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((DGW_PER2.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_imp_soles_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_soles.KeyPress
        e.Handled = Numero(e, txt_imp_soles)
    End Sub

    Private Sub txt_imp_soles_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_imp_soles.LostFocus
        Try
            txt_imp_soles.Text = (OBJ.HACER_DECIMAL(txt_imp_soles.Text))
        Catch ex As Exception


            txt_imp_soles.Text = "0.0000"

        End Try
    End Sub

    Private Sub txt_nro_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_nro_doc_per.Text) <> "")) Then
            If (DGW_PER2.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER2.Sort(DGW_PER2.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_nro_doc_per.Text.ToLower = Strings.Mid((DGW_PER2.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER2.CurrentCell = DGW_PER2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub

    Function VALIDAR_DET(ByVal COD_DOC0 As String, ByVal NRO_DOC0 As String, ByVal COD_PER0 As String) As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (((COD_DOC0 = dgw_mov1.Item(1, I).Value.ToString) And (NRO_DOC0 = dgw_mov1.Item(2, I).Value.ToString)) And (COD_PER0 = dgw_mov1.Item(3, I).Value.ToString)) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function


End Class