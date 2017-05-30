Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text
Public Class EGRESOS_BANCOS_GENERACION
    Dim BOTON, COD_DOC, ST_CONTROL, COD_AUX, COD_CC, COD_COMP, COD_CONTROL, COD_CUENTA, COD_DH_GRAL, COD_D_H, COD_MON_DOC, VAR_PRO, STATUS_PER, STATUS_P, STATUS_CC, ST_DIF, COD_MONEDA, COD_MP, COD_SUC0, COD_PROYECTO As String
    Dim CON_GCO As New SqlConnection
    Dim DT As New DataTable
    Dim fila2 As Integer
    Dim IMP_INICIAL, IMP_S, IGV0 As Decimal
    Dim OBJ As New Class1
    Dim repor As New CrystalReport2
    Dim repor1 As New CrystalComprobante2
    Dim SB As New StringBuilder
    Private ValidarFicha As Boolean = True

    Sub ReporteImprimir(ByVal oDatos As Object, ByVal oReporte As Object, ByVal oComprobante As String, ByVal oAuxiliar As String)
        oReporte.SetDataSource(oDatos)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = OBJ.DESC_MES(MES)
        Params.Add(Par)
        oReporte.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = AÑO
        Params.Add(Par)
        oReporte.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        oReporte.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        oReporte.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = oAuxiliar
        Params.Add(Par)
        oReporte.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = oComprobante
        Params.Add(Par)
        oReporte.DataDefinition.ParameterFields("COMP").ApplyCurrentValues(Params)

        If TypeOf oReporte Is CrystalReport2 Then
            oReporte.PrintOptions.PaperSize = DirectCast(OBJ.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        Else
            oReporte.PrintOptions.PaperSize = DirectCast(OBJ.TamañoPapel("IMPRESION1"), CrystalDecisions.Shared.PaperSize)
        End If
        oReporte.PrintToPrinter(1, False, 0, 0)
    End Sub

    Sub BANCOS00()
        Try
            dgw_ban.DataSource = OBJ.MOSTRAR_BANCO_COMP
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns(2).Visible = False
            dgw_ban.Columns(3).Visible = False
            dgw_ban.Columns(0).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim i As Integer = 0
        Do While (i <= (DGW_PER2.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(DGW_PER2.Item(1, i).Value.ToString))
                If (txt_desc_per.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(1))
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
            Exit Sub
        End Try
        BOTON = "MODIFICAR"
        ValidarFicha = False
        LIMPIAR_COMPROBANTE()
        CARGAR_DATOS()
        Panel_doc00.Enabled = False
        btn_grabar_com.Visible = False
        g_com.Enabled = False
        btn_imprimir.Enabled = True
        TabControl1.SelectedTab = TabPage2
        btn_imprimir.Focus()
        ValidarFicha = True
    End Sub
   Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If dgw1.Item(14, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Conciliado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf dgw1.Item(15, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Contabilizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf dgw1.Item(16, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Anulado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (((CInt(MessageBox.Show("Desea eliminar el Comprobante", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Dim BAN0 As String
            BAN0 = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            If OBJ.VERIFICAR_CIERRE_BANCOS(BAN0, AÑO, MES) = True Then
                MessageBox.Show("No se puede eliminar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            CARGAR_DATOS()
            TXT_IMP_ANT.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
            If dgw1.Item(14, dgw1.CurrentRow.Index).Value = True Then
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
                    Dim comand1 As New SqlCommand("ELIMINAR_I_BAN_EGRESO2", con)
                    comand1.CommandType = (CommandType.StoredProcedure)
                    comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
                    comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
                    comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
                    comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = TXT_IMP_ANT.Text
                    comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                    comand1.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                    comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                    comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    comand1.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
                    comand1.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
                    comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
                    comand1.Parameters.Add("@ST_CONTROL", SqlDbType.VarChar).Value = dgw1.Item(21, dgw1.CurrentRow.Index).Value.ToString
                    con.Open()
                    ESTADO = comand1.ExecuteScalar
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
            Exit Sub
        End Try
        If (((CInt(MessageBox.Show("Esta seguro de eliminar el Detalle.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
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
        ElseIf ((OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        ElseIf Not VALIDAR_DOCUMENTO() Then
            If SB.Length > 0 Then
                MessageBox.Show(String.Format("Algunos documentos se encuentran registrados.{0}{1}", Environment.NewLine, SB.ToString), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            If txt_saldo_soles.Text < 0 Then MessageBox.Show("EL total del Comprobante no puede ser negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
            ST_DIF = "0"
            If ch_dif.Checked = True Then ST_DIF = "1"
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If ((txt_cambio.Text) = 0) Then
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
        ElseIf ((OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        ElseIf Not VALIDAR_DOCUMENTO() Then
            If SB.Length > 0 Then
                MessageBox.Show(String.Format("Algunos documentos se encuentran registrados.{0}{1}", Environment.NewLine, SB.ToString), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            If txt_saldo_soles.Text < 0 Then MessageBox.Show("EL total del Comprobante no puede ser negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
            ST_DIF = "0"
            If ch_dif.Checked = True Then ST_DIF = "1"
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If ((txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
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
            If ((txt_imp_soles.Text) = 0) Then
                MessageBox.Show("Debe ingresar el importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_imp_soles.Focus()
            ElseIf (txt_cod_cta.Text.Trim = "") Then
                MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta.Focus()
            ElseIf OBJ.VERIFICAR_CTA_ORIGEN_CPTO(txt_cod_cta.Text) = "" Or OBJ.VERIFICAR_CTA_ORIGEN_CPTO(txt_cod_cta.Text) Is Nothing Then
                MessageBox.Show("El Concepto no tiene Cuenta de Origen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta.Focus()
            ElseIf ((cbo_cc.SelectedIndex = -1) And cbo_cc.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_cc.Focus()
            ElseIf ((cbo_proyecto.SelectedIndex = -1) And cbo_proyecto.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_proyecto.Focus()
            Else
                COD_DOC = OBJ.COD_DOC(cbo_tipo_doc.Text)
                COD_MONEDA = cbo_moneda.SelectedValue.ToString
                COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
                STATUS_PER = "1"
                VAR_PRO = "N"
                IMP_S = (txt_imp_soles.Text)
                Dim imp_pago As New Decimal
                If (COD_MON_DOC = COD_MONEDA) Then
                    imp_pago = IMP_S
                ElseIf (COD_MON_DOC = "D") Then
                    imp_pago = Math.Round((IMP_S * Decimal.Parse(txt_cambio.Text)), 2)
                Else
                    'SOLES O AJUSTE
                    If COD_MON_DOC = "S" Then
                        imp_pago = Math.Round((IMP_S / Decimal.Parse(txt_cambio.Text)), 2)
                    Else
                        If COD_MONEDA = "S" Then
                            imp_pago = IMP_S
                        Else
                            imp_pago = 0
                        End If
                    End If
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
                    dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1).ToString("0000"), COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, IMP_S, imp_pago, COD_MON_DOC, COD_D_H, txt_cambio.Text, dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, TXT_CTA.Text, dtp_mp.Value, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, STATUS_PER, VAR_PRO)
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
            Exit Sub
        End Try
        LIMPIAR_DETALLES()
        txt_cod1.ReadOnly = True
        txt_desc_per.ReadOnly = True
        txt_nro_doc_per.ReadOnly = True
        'btn_doc_pte.Enabled = False
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        TXT_ITEM0.Text = (dgw_mov1.CurrentRow.Index)
        CARGAR_DETALLES(TXT_ITEM0.Text)
        txt_cod1.Enabled = False
        txt_desc_per.Enabled = False
        txt_nro_doc_per.Enabled = False
        cbo_tipo_doc.Enabled = False
        txt_nro_doc.Enabled = False
        Panel_det.Visible = True
        txt_imp_soles.Focus()
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If dgw1.Item(14, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Conciliado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf dgw1.Item(15, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Contabilizado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf dgw1.Item(16, dgw1.CurrentRow.Index).Value = True Then
            MessageBox.Show("El Comprobante esta Anulado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim BAN0 As String
            BAN0 = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            If OBJ.VERIFICAR_CIERRE_BANCOS(BAN0, AÑO, MES) = True Then
                MessageBox.Show("No se puede modificar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            BOTON = "MODIFICAR"
            ValidarFicha = False
            LIMPIAR_COMPROBANTE()
            CARGAR_DATOS()
            btn_grabar_com.Visible = False
            btn_grabar_com2.Visible = True
            g_com.Enabled = False
            btn_grabar_com2.Enabled = True
            btn_imprimir.Enabled = False
            TabControl1.SelectedTab = TabPage2
            btn_nuevo_doc.Focus()
            ValidarFicha = True
        End If
        If OBJ.VERIFICAR_CIERRE_BANCOS((dgw1.Item(0, dgw1.CurrentRow.Index).Value), AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Focus()
            ValidarFicha = True
            Exit Sub
        End If
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        Dim WA As String
        WA = OBJ.HALLAR_CPTO(txt_cod_cta.Text, "E")
        If WA = "" Then
            MessageBox.Show("Debe elegir un Concepto Válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta.Focus()
            Panel_CTA1.Visible = False
            Exit Sub
        End If
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
            If ((txt_imp_soles.Text) = 0) Then
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
                COD_MONEDA = cbo_moneda.SelectedValue.ToString
                COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
                STATUS_PER = "1"
                ' VAR_PRO = "N"
                IMP_S = (txt_imp_soles.Text)
                Dim imp_pago As New Decimal
                If (COD_MON_DOC = COD_MONEDA) Then
                    imp_pago = IMP_S
                ElseIf (COD_MON_DOC = "D") Then
                    imp_pago = Math.Round(IMP_S * Decimal.Parse(txt_cambio.Text), 2)
                Else
                    'SOLES O AJUSTE
                    If COD_MON_DOC = "S" Then
                        imp_pago = Math.Round((IMP_S / Decimal.Parse(txt_cambio.Text)), 2)
                    Else
                        If COD_MONEDA = "S" Then
                            imp_pago = IMP_S
                        Else
                            imp_pago = 0
                        End If
                    End If
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
                Dim FILA0 As Integer = TXT_ITEM0.Text
                dgw_mov1.Item(6, FILA0).Value = IMP_S
                dgw_mov1.Item(7, FILA0).Value = imp_pago
                dgw_mov1.Item(8, FILA0).Value = COD_MON_DOC
                If VAR_PRO <> "S" Then dgw_mov1.Item(9, FILA0).Value = COD_D_H
                dgw_mov1.Item(12, FILA0).Value = txt_glosa.Text
                dgw_mov1.Item(13, FILA0).Value = txt_cod_cta.Text

                dgw_mov1.Item(16, FILA0).Value = COD_CC
                dgw_mov1.Item(17, FILA0).Value = COD_CONTROL
                dgw_mov1.Item(18, FILA0).Value = COD_PROYECTO
                dgw_mov1.Item(14, FILA0).Value = TXT_CTA.Text
                HALLAR_TOTAL()
                Panel_det.Visible = False
                btn_nuevo_doc.Focus()
            End If
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click, btn_nuevo_comp.Click
        LIMPIAR_COMPROBANTE()
        nro_comp()
        num_mp()
        BOTON = "NUEVO"
        ValidarFicha = False
        TabControl1.SelectedTab = TabPage2
        txt_cod_ban.Focus()
        ValidarFicha = True
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
        ElseIf ((OBJ.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If ((txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            ElseIf BOTON = "NUEVO" And OBJ.VERIFICAR_NRO_MP_BANCO(txt_cod_ban.Text, COD_MP, txt_num_mp.Text) = False Then
            Else
                g_com.Enabled = False
                LIMPIAR_DETALLES()
                Panel_det.Visible = True
                txt_cod1.Focus()
            End If
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(32) = 0
        Close()
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim i As Integer = fila2
        Do While (i <= (DGW_PER2.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(DGW_PER2.Item(1, i).Value.ToString))
                If (txt_desc_per.Text.ToLower = Strings.Mid(DGW_PER2.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(1))
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
        DGW_CTA1.DataSource = (OBJ.MOSTRAR_CONCEPTOS_STATUS("E"))
        DGW_CTA1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
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
        dtp_mp.Value = (dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString)
        TXT_IMP_ANT.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        COD_MONEDA = dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString
        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
        COD_AUX = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        CBO_COMPROBANTE00()
        COD_COMP = dgw1.Item(12, dgw1.CurrentRow.Index).Value.ToString
        cbo_com.Text = OBJ.DESC_COMPROBANTE(COD_AUX, COD_COMP)
        txt_nro_comp.Text = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        txt_cambio.Text = dgw1.Item(13, dgw1.CurrentRow.Index).Value.ToString
        txt_saldo.Text = dgw1.Item(17, dgw1.CurrentRow.Index).Value.ToString
        dtp_dif.Value = (dgw1.Item(18, dgw1.CurrentRow.Index).Value.ToString)
        ST_DIF = dgw1.Item(19, dgw1.CurrentRow.Index).Value.ToString
        If (ST_DIF = "1") Then
            ch_dif.Checked = True
        End If
        ST_CONTROL = dgw1.Item(21, dgw1.CurrentRow.Index).Value.ToString
        If ST_CONTROL = "1" Then ch_control.Checked = True Else ch_control.Checked = False
        dgw_mov1.Rows.Clear()
        dgw_det2.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_BAN_EGRESO", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@cod_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            pro_02.Parameters.Add("@cod_mP", SqlDbType.VarChar).Value = COD_MP
            pro_02.Parameters.Add("@nro_mP", SqlDbType.VarChar).Value = txt_num_mp.Text
            pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                dgw_mov1.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), _
                    rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), Math.Round(rs3.GetValue(7), 2), _
                    rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), _
                    rs3.GetValue(13), rs3.GetValue(14), rs3.GetValue(15), rs3.GetValue(16), rs3.GetValue(17), _
                    rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), _
                    rs3.GetValue(23), rs3.GetValue(24), rs3.GetValue(25), rs3.GetValue(26), "M")

                dgw_det2.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), _
                    rs3.GetValue(5), rs3.GetValue(6), Math.Round(rs3.GetValue(7), 2), rs3.GetValue(8), rs3.GetValue(9), _
                    rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetValue(15), _
                    rs3.GetValue(16), rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), _
                    rs3.GetValue(21), rs3.GetValue(22), rs3.GetValue(23), rs3.GetValue(24), rs3.GetValue(25), rs3.GetValue(26))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        HALLAR_TOTAL()
    End Sub
    Sub CARGAR_DETALLES(ByVal FILA0 As Object)
        VAR_PRO = dgw_mov1.Item(23, (FILA0)).Value.ToString
        COD_DOC = dgw_mov1.Item(1, (FILA0)).Value.ToString
        txt_nro_doc.Text = dgw_mov1.Item(2, (FILA0)).Value.ToString
        txt_cod1.Text = dgw_mov1.Item(3, (FILA0)).Value.ToString
        txt_desc_per.Text = dgw_mov1.Item(4, (FILA0)).Value.ToString
        txt_nro_doc_per.Text = dgw_mov1.Item(5, (FILA0)).Value.ToString
        txt_imp_soles.Text = dgw_mov1.Item(6, (FILA0)).Value.ToString
        txt_imp_soles.Text = (OBJ.HACER_DECIMAL(txt_imp_soles.Text))
        COD_MON_DOC = dgw_mov1.Item(8, (FILA0)).Value.ToString
        txt_glosa.Text = dgw_mov1.Item(12, (FILA0)).Value.ToString
        txt_cod_cta.Text = dgw_mov1.Item(13, (FILA0)).Value.ToString
        txt_desc_cta.Text = OBJ.DESC_CPTO(txt_cod_cta.Text)
        COD_D_H = dgw_mov1.Item(9, (FILA0)).Value.ToString
        COD_CUENTA = dgw_mov1.Item(14, (FILA0)).Value.ToString
        TXT_CTA.Text = COD_CUENTA
        COD_CC = dgw_mov1.Item(16, (FILA0)).Value.ToString
        COD_CONTROL = dgw_mov1.Item(17, (FILA0)).Value.ToString
        COD_PROYECTO = dgw_mov1.Item(18, (FILA0)).Value.ToString
        STATUS_CC = dgw_mov1.Item(19, (FILA0)).Value.ToString
        STATUS_P = dgw_mov1.Item(21, (FILA0)).Value.ToString
        cbo_tipo_doc.Text = OBJ.DESC_DOC(COD_DOC)
        COD_D_H = dgw_mov1.Item(9, (FILA0)).Value.ToString
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
        nro_comp()
    End Sub
    Sub nro_comp()
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
        '    PROG_01.CommandType = (CommandType.StoredProcedure)
        '    PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = (FECHA_GRAL)
        '    con.Open()
        '    PROG_01.ExecuteNonQuery()
        '    Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
        '    Do While Rs3.Read
        '        cbo_control.Items.Add(Rs3.GetString(0))
        '    Loop
        '    con.Close()
        'Catch ex As Exception

        '    ' 
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
        num_mp()
    End Sub
    Sub num_mp()
        If ((cbo_mp.SelectedIndex <> -1) And (txt_cod_ban.Text.Trim <> "")) Then
            COD_MP = OBJ.COD_MP(cbo_mp.Text)
            txt_num_mp.Text = OBJ.HALLAR_NRO_MP(COD_MP, txt_cod_ban.Text)
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
            PROG_01.CommandType = (CommandType.StoredProcedure)
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
    Private Sub ch_dif_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_dif.CheckedChanged
        If ch_dif.Checked Then
            dtp_dif.Enabled = True
            ST_DIF = "1"
        Else
            dtp_dif.Enabled = False
            ST_DIF = "0"
        End If
    End Sub
    Sub DATAGRID()
        Try
            Dim pro As New SqlCommand("MOSTRAR_I_BAN_EGRESO2", con)
            pro.CommandType = (CommandType.StoredProcedure)
            pro.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw1.DataSource = (dt)
            dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            dgw1.Columns(0).Visible = False
            dgw1.Columns(2).Visible = False
            dgw1.Columns(12).Visible = False
            dgw1.Columns(13).Visible = False
            dgw1.Columns(17).Visible = False
            dgw1.Columns(18).Visible = False
            dgw1.Columns(19).Visible = False
            dgw1.Columns.Item(20).Visible = False
            dgw1.Columns.Item(21).Visible = False
            dgw1.Columns(1).Width = 120
            dgw1.Columns(3).Width = &H9B
            dgw1.Columns(4).Width = 100
            dgw1.Columns(5).Width = 110
            dgw1.Columns(6).Width = 35
            dgw1.Columns(7).Width = 100
            dgw1.Columns(8).Width = &H4B
            dgw1.Columns(8).DefaultCellStyle.Format = "d"
            dgw1.Columns(9).Width = 80
            dgw1.Columns(9).DefaultCellStyle.Format = "N2"
            dgw1.Columns(8).DefaultCellStyle.Alignment = &H400
            dgw1.Columns(10).Width = 35
            dgw1.Columns(11).Width = &H2C
            dgw1.Columns(13).DefaultCellStyle.Format = "N4"
            dgw1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns(14).Width = 35
            dgw1.Columns(15).Width = 35
            dgw1.Columns(16).Width = 35
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
            cbo_com.Text = OBJ.HALLAR_COMP_X_BANCO(txt_cod_ban.Text)
            txt_saldo.Text = (OBJ.HALLAR_SALDO_BANCOS(txt_cod_ban.Text))
            panel_bancos.Visible = False
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            panel_bancos.Visible = False
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
        End If
        If OBJ.VERIFICAR_CIERRE_BANCOS(txt_cod_ban.Text, AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub DGW_CTA1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_CTA1.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = DGW_CTA1.Item(0, DGW_CTA1.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = DGW_CTA1.Item(1, DGW_CTA1.CurrentRow.Index).Value.ToString
            STATUS_CC = DGW_CTA1.Item(2, DGW_CTA1.CurrentRow.Index).Value.ToString
            STATUS_P = DGW_CTA1.Item(3, DGW_CTA1.CurrentRow.Index).Value.ToString
            COD_D_H = DGW_CTA1.Item(4, DGW_CTA1.CurrentRow.Index).Value.ToString
            TXT_CTA.Text = OBJ.HALLAR_CTA_CPTO(txt_cod_cta.Text)
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
            If (txt_desc_giro.Text.ToString.ToString = "") Then
                txt_desc_giro.Text = txt_desc_per.Text
            End If
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
    Sub HALLAR_TOTAL()
        Dim total As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim SIGNO As Double = 1
            If (dgw_mov1.Item(9, I).Value.ToString = "H") Then
                SIGNO = -1
            End If
            If (COD_MONEDA = "S") Then
                If (dgw_mov1.Item(8, I).Value.ToString <> "D") Then
                    total = total + Math.Round((SIGNO * Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                Else
                    total = total + Math.Round((SIGNO * Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString) * Decimal.Parse(txt_cambio.Text)), 2)
                End If
            ElseIf (dgw_mov1.Item(8, I).Value.ToString = "S") Then
                total = total + Math.Round((SIGNO * Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString) / Decimal.Parse(txt_cambio.Text)), 2)
            Else
                If dgw_mov1.Item(8, I).Value.ToString = "A" Then
                    total = total + 0
                Else
                    total = total + Math.Round((SIGNO * Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                End If
            End If
            I += 1
        Loop
        COD_DH_GRAL = "H"
        'If (Decimal.Compare(total, Decimal.Zero) < 0) Then
        '    total = Decimal.Multiply(total, Decimal.MinusOne)
        '    COD_DH_GRAL = "D"
        'End If
        txt_saldo_soles.Text = total
        txt_saldo_soles.Text = OBJ.HACER_DECIMAL(txt_saldo_soles.Text)
    End Sub
    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim sqlbc2 As New SqlBulkCopy(CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_mov1.Rows.Count - 1
        DT.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            DT.Rows.Add(COD_MP, txt_num_mp.Text, txt_cod_ban.Text, (I + 1).ToString("0000"), AÑO, MES, dgw_mov1.Item(1, I).Value.ToString, dgw_mov1.Item(2, I).Value.ToString, dgw_mov1.Item(3, I).Value.ToString, dgw_mov1.Item(5, I).Value.ToString, DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString), dgw_mov1.Item(13, I).Value.ToString, dgw_mov1.Item(14, I).Value.ToString, dgw_mov1.Item(12, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(6, I).Value)), dgw_mov1.Item(9, I).Value.ToString, dgw_mov1.Item(8, I).Value.ToString, txt_cambio.Text, Decimal.Parse((dgw_mov1.Item(10, I).Value)), dgw_mov1.Item(16, I).Value.ToString, dgw_mov1.Item(17, I).Value.ToString, dgw_mov1.Item(18, I).Value.ToString, "S", dtp_mp.Value, DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString), NOMBRE_PC)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.T_BANCO2")
            sqlbc.WriteToServer(DT)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            INSERTAR_TODO = estado
            Return INSERTAR_TODO
        End Try
        COD_SUC0 = OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        Dim K As Integer = (COD_SUC0)
        If OBJ.DIR_TABLA_DESC("GCO", "TSIST") = "SI" Then
            Try
                CON_GCO.Open()
                sqlbc2.DestinationTableName = "dbo.COI_T_BANCO2"
                sqlbc2.WriteToServer(DT)
                CON_GCO.Close()
            Catch ex As Exception
                CON_GCO.Close()
                MsgBox(ex.Message)
                INSERTAR_TODO = estado
                Return INSERTAR_TODO
            End Try
            Try
                Dim comand As New SqlCommand("COI_INSERTAR_T_BAN_EGRESO2", CON_GCO)
                comand.CommandType = (CommandType.StoredProcedure)
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
                estado = comand.ExecuteScalar
                CON_GCO.Close()
            Catch ex As Exception
                CON_GCO.Close()
                MsgBox(ex.Message)
                estado = "FALLO"
                INSERTAR_TODO = estado
                Return INSERTAR_TODO
            End Try
        End If
        If ch_control.Checked = True Then ST_CONTROL = "1" Else ST_CONTROL = "0"
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_BAN_EGRESO2", con)
            comand1.CommandType = (CommandType.StoredProcedure)
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
            comand1.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = "H"
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio.Text
            comand1.Parameters.Add("@FECHA_DIF", SqlDbType.DateTime).Value = dtp_dif.Value
            comand1.Parameters.Add("@STATUS_DIF", SqlDbType.VarChar).Value = ST_DIF
            comand1.Parameters.Add("@STATUS_CONTROL", SqlDbType.Char).Value = ST_CONTROL
            con.Open()
            estado = comand1.ExecuteScalar
            'comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function
    Sub LIMPIAR_COMPROBANTE()
        txt_cod_cta.Focus()
        cbo_mp.Focus()
        txt_cod_cta.Focus()
        Dim desc00 As String = cbo_com.Text
        cbo_com.SelectedIndex = -1
        cbo_com.Text = desc00
        g_com.Enabled = True
        Dim desc01 As String = cbo_mp.Text
        cbo_mp.SelectedIndex = -1
        cbo_mp.Text = desc01
        txt_num_mp.Clear()
        txt_desc_giro.Clear()
        g_com.Enabled = True
        panel_bancos.Visible = False
        txt_saldo.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        dgw_mov1.Rows.Clear()
        Panel_det.Visible = False
        Panel_doc00.Enabled = True
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = False
        btn_grabar_com.Enabled = True
        btn_grabar_com2.Enabled = True
        ST_DIF = "0"
        ch_dif.Checked = False
        txt_cod1.Clear()
        txt_desc_per.Clear()
        txt_nro_doc_per.Clear()
        txt_glosa.Clear()
        Panel_doc00.Enabled = True
        ch_control.Checked = False
    End Sub
    Sub LIMPIAR_DETALLES()
        'Dim VB$t_ref$L0 As IEnumerator
        'btn_doc_pte.Enabled = True
        For Each text As Object In GroupBox2.Controls
            If TypeOf text Is ComboBox Then text.SelectedIndex = -1
        Next
        'btn_doc_pte.Enabled = True
        'For Each text As Object In GroupBox2.Controls
        '    If TypeOf text Is ComboBox Then text.SelectedIndex = -1
        'Next
        txt_imp_soles.Text = "0.00"
        txt_nro_doc.Clear()
        txt_cod1.Enabled = True
        txt_desc_per.Enabled = True
        txt_nro_doc_per.Enabled = True
        TXT_CTA.Clear()
        cbo_tipo_doc.Enabled = True
        txt_nro_doc.Enabled = True
        txt_cod_cta.Enabled = True
        txt_desc_cta.Enabled = True
        cbo_moneda1.Text = cbo_moneda.Text
        cbo_moneda1.Enabled = True
        txt_imp_soles.Text = "0.00"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        txt_cod1.ReadOnly = False
        txt_desc_per.ReadOnly = False
        txt_nro_doc_per.ReadOnly = False
        Panel_PER2.Visible = False
        Panel_CTA1.Visible = False
    End Sub
    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim sqlbc2 As New SqlBulkCopy(CON_GCO)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_mov1.Rows.Count - 1
        DT.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            DT.Rows.Add(COD_MP, txt_num_mp.Text, txt_cod_ban.Text, (I + 1).ToString("0000"), AÑO, MES, dgw_mov1.Item(1, I).Value.ToString, dgw_mov1.Item(2, I).Value.ToString, dgw_mov1.Item(3, I).Value.ToString, dgw_mov1.Item(5, I).Value.ToString, DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString), dgw_mov1.Item(13, I).Value.ToString, dgw_mov1.Item(14, I).Value.ToString, dgw_mov1.Item(12, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(6, I).Value)), dgw_mov1.Item(9, I).Value.ToString, dgw_mov1.Item(8, I).Value.ToString, txt_cambio.Text, Decimal.Parse((dgw_mov1.Item(10, I).Value)), dgw_mov1.Item(16, I).Value.ToString, dgw_mov1.Item(17, I).Value.ToString, dgw_mov1.Item(18, I).Value.ToString, "S", dtp_mp.Value, DateTime.Parse(dgw_mov1.Item(11, I).Value.ToString), NOMBRE_PC)
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
            MODIFICAR_TODO = estado
            Return MODIFICAR_TODO
        End Try
        COD_SUC0 = OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        Dim K As Integer = (COD_SUC0)
        If OBJ.DIR_TABLA_DESC("GCO", "TSIST") = "SI" Then
            Try
                CON_GCO.Open()
                sqlbc2.DestinationTableName = ("dbo.COI_T_BANCO2")
                sqlbc2.WriteToServer(DT)
                CON_GCO.Close()
            Catch ex As Exception
                CON_GCO.Close()
                MsgBox(ex.Message)
                MODIFICAR_TODO = estado
                Return MODIFICAR_TODO
            End Try
            Try
                Dim comand As New SqlCommand("COI_INSERTAR_T_BAN_EGRESO2", CON_GCO)
                comand.CommandType = (CommandType.StoredProcedure)
                comand.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                comand.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                comand.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_mp.Value
                comand.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
                comand.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = txt_num_mp.Text
                comand.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
                comand.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
                comand.Parameters.Add("@COD_SUCURSAL0", SqlDbType.VarChar).Value = (K.ToString("0000"))
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
                MODIFICAR_TODO = estado
                Return MODIFICAR_TODO
            End Try
        End If
        If ch_control.Checked = True Then ST_CONTROL = "1" Else ST_CONTROL = "0"
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_I_BAN_EGRESO2", con)
            comand1.CommandType = (CommandType.StoredProcedure)
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
            comand1.Parameters.Add("@STATUS_CONTROL", SqlDbType.Char).Value = ST_CONTROL
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
    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
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
            DGW_PER2.DataSource = (OBJ.MOSTRAR_PERSONAS_PAGAR)
            DGW_PER2.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
            DGW_PER2.Columns.Item(0).Width = &H37
            DGW_PER2.Columns.Item(1).Width = 330
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub PERSONAS2()
        Try
            DGW_PER2.DataSource = (OBJ.MOSTRAR_PERSONAS_COBRAR)
            DGW_PER2.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
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
        If OBJ.DIR_TABLA_DESC("GCO", "TSIST") = "SI" Then
            I = 0
            Do While (I <= CONT)
                DT.Rows.Add(COD_MP, txt_num_mp.Text, txt_cod_ban.Text, (I + 1).ToString("00"), AÑO, MES, dgw_det2.Item(1, I).Value.ToString, dgw_det2.Item(2, I).Value.ToString, dgw_det2.Item(3, I).Value.ToString, dgw_det2.Item(5, I).Value.ToString, DateTime.Parse(dgw_det2.Item(11, I).Value.ToString), dgw_det2.Item(13, I).Value.ToString, dgw_det2.Item(14, I).Value.ToString, dgw_det2.Item(12, I).Value.ToString, Decimal.Parse((dgw_det2.Item(6, I).Value)), dgw_det2.Item(9, I).Value.ToString, dgw_det2.Item(8, I).Value.ToString, txt_cambio.Text, Decimal.Parse((dgw_det2.Item(10, I).Value)), dgw_det2.Item(16, I).Value.ToString, dgw_det2.Item(17, I).Value.ToString, dgw_det2.Item(18, I).Value.ToString, dgw_det2.Item(23, I).Value.ToString, dtp_mp.Value, DateTime.Parse(dgw_det2.Item(11, I).Value.ToString), NOMBRE_PC)
                I += 1
            Loop
            COD_SUC0 = OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
            Dim K As Integer = COD_SUC0
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
                comand.CommandType = (CommandType.StoredProcedure)
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
        Else
            estado = "EXITO"
        End If
        Return estado
    End Function
    Private Sub txt_cambio_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio.KeyPress
        e.Handled = Numero(e, (txt_cambio))
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
                'Dim VB$t_i4$L0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban.RowCount - 1))
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        COD_MONEDA = dgw_ban.Item(2, i).Value.ToString
                        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
                        COD_AUX = dgw_ban.Item(3, i).Value.ToString
                        CBO_COMPROBANTE00()
                        cbo_com.Text = OBJ.HALLAR_COMP_X_BANCO(txt_cod_ban.Text)
                        txt_saldo.Text = OBJ.HALLAR_SALDO_BANCOS(txt_cod_ban.Text)
                        cbo_mp.Focus()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
        If OBJ.VERIFICAR_CIERRE_BANCOS(txt_cod_ban.Text, AÑO, MES) = True Then
            MessageBox.Show("No se puede ingresar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_ban.Clear()
            txt_desc_ban.Clear()
            txt_cod_ban.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) <> "") Then
            If (DGW_CTA1.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_CTA1.Sort(DGW_CTA1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (DGW_CTA1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_CTA1.RowCount - 1))
                    If (txt_cod_cta.Text.ToLower = DGW_CTA1.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = DGW_CTA1.Item(0, i).Value.ToString
                        txt_desc_cta.Text = DGW_CTA1.Item(1, i).Value.ToString
                        STATUS_CC = DGW_CTA1.Item(2, i).Value.ToString
                        STATUS_P = DGW_CTA1.Item(3, i).Value.ToString
                        COD_D_H = DGW_CTA1.Item(4, i).Value.ToString
                        TXT_CTA.Text = OBJ.HALLAR_CTA_CPTO(txt_cod_cta.Text)
                        cbo_cc.SelectedIndex = -1
                        cbo_cc.Enabled = False
                        cbo_proyecto.SelectedIndex = -1
                        cbo_proyecto.Enabled = False
                        If STATUS_CC = "1" Then
                            cbo_cc.Enabled = True
                        End If
                        If (STATUS_P = "1") Then
                            cbo_proyecto.Enabled = True
                        End If
                        txt_glosa.Focus()
                        Return
                    End If
                    If (txt_cod_cta.Text.ToLower = Strings.Mid((DGW_CTA1.Item(0, i).Value), 1, Strings.Len(txt_cod_cta.Text)).ToLower) Then
                        DGW_CTA1.CurrentCell = (DGW_CTA1.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    DGW_CTA1.CurrentCell = (DGW_CTA1.Rows.Item(0).Cells.Item(0))
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
                'Dim VB$t_i4$L0 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER2.RowCount - 1))
                    If (txt_cod1.Text.ToLower = DGW_PER2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod1.Text = DGW_PER2.Item(0, i).Value.ToString
                        txt_desc_per.Text = DGW_PER2.Item(1, i).Value.ToString
                        txt_nro_doc_per.Text = DGW_PER2.Item(2, i).Value.ToString
                        txt_glosa.Text = txt_desc_per.Text
                        If (txt_desc_giro.Text.ToString.ToString = "") Then
                            txt_desc_giro.Text = txt_desc_per.Text
                        End If
                        cbo_tipo_doc.Focus()
                        Return
                    End If
                    If (txt_cod1.Text.ToLower = Strings.Mid((DGW_PER2.Item(0, i).Value), 1, Strings.Len(txt_cod1.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(0).Cells.Item(0))
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
                'Dim VB$t_i4$L0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_ban.RowCount - 1))
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = (dgw_ban.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = (dgw_ban.Rows.Item(0).Cells.Item(0))
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
                'Dim VB$t_i4$L0 As Integer = (DGW_CTA1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_CTA1.RowCount - 1))
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((DGW_CTA1.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        DGW_CTA1.CurrentCell = (DGW_CTA1.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    DGW_CTA1.CurrentCell = (DGW_CTA1.Rows.Item(0).Cells.Item(0))
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
                'Dim VB$t_i4$L0 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER2.RowCount - 1))
                    If (txt_desc_per.Text.ToLower = Strings.Mid((DGW_PER2.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_PER2.Visible = True
                DGW_PER2.Visible = True
                DGW_PER2.Focus()
            End If
        End If
    End Sub
    Private Sub txt_imp_soles_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_soles.KeyPress
        e.Handled = Numero(e, (txt_imp_soles))
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
                'Dim VB$t_i4$L0 As Integer = (DGW_PER2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (DGW_PER2.RowCount - 1))
                    If (txt_nro_doc_per.Text.ToLower = Strings.Mid((DGW_PER2.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per.Text)).ToLower) Then
                        DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    DGW_PER2.CurrentCell = (DGW_PER2.Rows.Item(0).Cells.Item(0))
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
        I = 0
        Do While (I <= CONT)
            If (((COD_DOC0 = dgw_mov1.Item(1, I).Value.ToString) And (NRO_DOC0 = dgw_mov1.Item(2, I).Value.ToString)) And (COD_PER0 = dgw_mov1.Item(3, I).Value.ToString)) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function

    Private Function VALIDAR_DOCUMENTO() As Boolean
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim Total As Integer
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Try
                If dgw_mov1.Item(27, I).Value <> "M" Then
                    Dim Cmd As New SqlCommand("VERIFICAR_DOCUMENTO_PCTAS", con)
                    Cmd.CommandType = CommandType.StoredProcedure
                    Dim par0 As SqlParameter = Cmd.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char)
                    Dim par1 As SqlParameter = Cmd.Parameters.Add("@COD_PER", SqlDbType.Char)
                    Dim par2 As SqlParameter = Cmd.Parameters.Add("@COD_DOC", SqlDbType.Char)
                    Dim par3 As SqlParameter = Cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar)
                    Dim par4 As SqlParameter = Cmd.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar)
                    Dim par5 As SqlParameter = Cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar)
                    Dim par6 As SqlParameter = Cmd.Parameters.Add("@TIPO", SqlDbType.Int)

                    par0.Value = OBJ.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
                    par1.Value = dgw_mov1.Item(3, I).Value : par2.Value = dgw_mov1.Item(1, I).Value
                    par3.Value = dgw_mov1.Item(2, I).Value : par4.Value = dgw_mov1.Item(5, I).Value
                    par5.Value = dgw_mov1.Item(14, I).Value : par6.Value = 1

                    con.Open()
                    Total = Cmd.ExecuteScalar
                    con.Close()
                    If Total > 0 Then
                        SB.AppendLine(String.Format("Doc: {0} Nro: {1} Cta. Cte.: {2}", dgw_mov1.Item(1, I).Value, dgw_mov1.Item(2, I).Value, dgw_mov1.Item(3, I).Value))
                    End If
                End If
            Catch ex As Exception
                con.Close()
                MessageBox.Show(String.Format("No se puede validar el documento.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
            I += 1
        Loop
        If SB.Length > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub EGRESOS_BANCOS_GENERACION_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub EGRESOS_BANCOS_GENERACION_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub

    Private Sub EGRESOS_BANCOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Private Sub EGRESOS_BANCOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        Dim EMP00 As String = ""
        EMP00 = OBJ.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = "data source=" & nombre_servidor & ";initial catalog=BD_GCO" & COD_EMPRESA & ";uid=miguel;pwd=main;"
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
        COD_DH_GRAL = "H"
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
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
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim dt As New DT_BANCO_IMPR
        Dim I, cont As Integer
        cont = dgw_mov1.Rows.Count - 1
        For I = 0 To cont

            Dim imptt_doc As Decimal
            Dim objeto As String

            If COD_MONEDA = "S" Then
                objeto = dgw_mov1.Item(26, I).Value
                If objeto = "" Then
                    imptt_doc = "0.00"
                Else
                    imptt_doc = OBJ.HACER_DECIMAL((dgw_mov1.Item(26, I).Value))
                End If
            ElseIf COD_MONEDA = "D" Then
                objeto = dgw_mov1.Item(26, I).Value
                If objeto = "" Then
                    imptt_doc = "0.00"
                Else
                    imptt_doc = OBJ.HACER_DECIMAL((dgw_mov1.Item(26, I).Value) * txt_cambio.Text)
                End If
            End If
            Dim COD_REPOR As String
            COD_REPOR = OBJ.DESC_USUARIO_BANCO(OBJ.COD_MP(cbo_mp.Text), txt_num_mp.Text, txt_cod_ban.Text)
            dt.DataTable1.Rows.Add(dgw_mov1.Item(11, I).Value.ToString.Substring(0, 10), dgw_mov1.Item(2, I).Value, dgw_mov1.Item(1, I).Value, dgw_mov1.Item(3, I).Value, dgw_mov1.Item(13, I).Value, dgw_mov1.Item(14, I).Value, dgw_mov1.Item(12, I).Value, COD_MONEDA, dgw_mov1.Item(10, I).Value, imptt_doc, dgw_mov1.Item(7, I).Value, cbo_com.Text, dgw_mov1.Item(24, I).Value, txt_nro_comp.Text, dgw_mov1.Item(25, I).Value, COD_REPOR, dgw_mov1.Item(8, I).Value, "EGRESO", txt_desc_ban.Text, cbo_mp.Text, txt_num_mp.Text)
        Next

        If chkContinuo.Checked Then
            ReporteImprimir(dt, repor, cbo_com.Text, dgw1.Item(20, dgw1.CurrentRow.Index).Value)
        Else
            ReporteImprimir(dt, repor1, cbo_com.Text, dgw1.Item(20, dgw1.CurrentRow.Index).Value)
        End If

        'repor.SetDataSource(dt)
        'Dim Params As New ParameterValues
        'Dim Par As New ParameterDiscreteValue
        ''======================================================================================
        'Params.Clear()
        'Par.Value = OBJ.DESC_MES(MES)
        'Params.Add(Par)
        'repor.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = AÑO
        'Params.Add(Par)
        'repor.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = DESC_EMPRESA
        'Params.Add(Par)
        'repor.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = RUC_EMPRESA
        'Params.Add(Par)
        'repor.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = dgw1.Item(20, dgw1.CurrentRow.Index).Value
        'Params.Add(Par)
        'repor.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = cbo_com.Text
        'Params.Add(Par)
        'repor.DataDefinition.ParameterFields("COMP").ApplyCurrentValues(Params)
        'repor.PrintToPrinter(1, False, 0, 0)
    End Sub
    Private Sub ch_control_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_control.CheckedChanged
        If ch_control.Checked = True Then
            PERSONAS2()
        Else
            PERSONAS()
        End If
    End Sub
    Private Sub ch_dif_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ch_dif.LostFocus
        txt_desc_giro.Focus()
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub
End Class