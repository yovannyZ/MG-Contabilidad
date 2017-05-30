Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CANCELACION_CXC2
    Private COD_MONEDA, VAR_PRO, COD_COMP2, STATUS_PER, COD_AUX2, STATUS_P, STATUS_DOC, STATUS_CC, STATUS_ANA, ITEM_PAGO, cod_ref, COD_PROYECTO, COD_MP, BOTON, COD_DOC, COD_MON_DOC, COD_D_H_PAGO, COD_AUX, COD_CC, COD_COMP, COD_CONTROL, COD_D_H As String
    Private DT_DET As New DataTable
    Private IGV0, IMP_D, IMP_INICIAL, IMP_S As Decimal
    Dim reporte As New CrystalReport1
    Private obj As New Class1
    Private OFR As New CONSULTA_PCTAS_COBRAR
    Sub BOTON3()
        OFR.COD_SUC = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        OFR.COD_PER00 = txt_cod1.Text
        OFR.CARGAR_PCTAS_PAGAR_PERSONA()
        OFR.limpiar()
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
    Private Sub btn_Cancelar_comp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancelar_comp.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub btn_cancelar_pago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_pago.Click
        Panel_doc.Visible = False
        btn_nuevo_doc.Focus()
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
        CARGAR_COMPROBANTE()
        Panel_pago0.Enabled = False
        btn_grabar.Visible = False
        btn_grabar2.Visible = False
        g_cab.Enabled = False
        btn_imprimir.Enabled = True
        TabControl1.SelectedTab = TabPage2
        btn_imprimir.Focus()
    End Sub
    Private Sub btn_doc_pte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_doc_pte.Click
        If dtp_mp.Value.Date > FECHA_GRAL.Date Then
            MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtp_mp.Focus()
        Else
            If (txt_cambio_pago.Text.Trim = "") Then
                txt_cambio_pago.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio_pago.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio_pago.Focus()
            ElseIf (txt_cod1.Text.Trim = "") Then
                MessageBox.Show("Debe elegir la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod1.Focus()
            ElseIf (cbo_com.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir el comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_com.Focus()
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
        If (Decimal.Parse((CInt(MessageBox.Show("Desea borrar el Comprobante", " Borrar Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
            txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
            If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_CXC_CANCELACION", con)
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
    Private Sub btn_eliminar_pago0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar_pago0.Click
        Try
            Dim i As Integer = dgw_pago0.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el Pago.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            ELIMINAR_PAGO(dgw_pago0.Item(9, dgw_pago0.CurrentRow.Index).Value.ToString)
        End If
        btn_nuevo_pago0.Focus()
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
    Private Sub btn_grabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar.Click
        If (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_pago0.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_pago0.Focus()
        Else
            If (INSERTAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                obj.ELIMINAR_TEMPORAL("TCON")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            DATAGRID()
            Panel_pago0.Enabled = False
            btn_grabar.Enabled = False
            btn_nuevo_comp.Enabled = True
            btn_imprimir.Enabled = True
            btn_imprimir.Focus()
        End If
    End Sub
    Private Sub btn_grabar_pago01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_pago01.Click
        If (dgw_mov1.Rows.Count = 0) Then
            MessageBox.Show("Pago sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_doc.Focus()
        ElseIf (txt_cod_cta_pago.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta del Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_mp.Focus()
        ElseIf (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (txt_nro_mp.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_mp.Focus()
        Else
            COD_MP = obj.COD_MP(cbo_mp.Text)
            INSERTAR_DGW_PAGO()
            LIMPIAR_PAGO()
            txt_cod_cta_pago.Focus()
        End If
    End Sub
    Private Sub btn_grabar_pago02_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_pago02.Click
        If (dgw_mov1.Rows.Count = 0) Then
            MessageBox.Show("Pago sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_doc.Focus()
        ElseIf (txt_cod_cta_pago.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta del Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_mp.Focus()
        ElseIf (cbo_mp.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mp.Focus()
        ElseIf (txt_nro_mp.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_mp.Focus()
        Else
            ELIMINAR_PAGO(ITEM_PAGO)
            INSERTAR_DGW_PAGO()
            Panel_doc.Visible = False
            btn_nuevo_pago0.Focus()
        End If
    End Sub
    Private Sub btn_grabar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar2.Click
        If (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_pago0.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_pago0.Focus()
        Else
            If (MODIFICAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                obj.ELIMINAR_TEMPORAL("TCON")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            DATAGRID()
            Panel_pago0.Enabled = False
            btn_grabar2.Enabled = False
            btn_nuevo_comp.Enabled = True
            btn_imprimir.Enabled = True
            btn_imprimir.Focus()
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
            ElseIf ((CBO_CC.Text.Trim = "") And CBO_CC.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CBO_CC.Focus()
            ElseIf ((cbo_proyecto.SelectedIndex <> -1) And cbo_proyecto.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_proyecto.Focus()
            Else
                COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
                cod_ref = ""
                If (cbo_tipo_ref.SelectedIndex <> -1) Then
                    cod_ref = obj.COD_DOC(cbo_tipo_ref.Text)
                End If
                COD_D_H = obj.COD_D_H(COD_DOC)
                If COD_D_H = "D" Then
                    COD_D_H = "H"
                Else
                    COD_D_H = "D"
                End If
                COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
                COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
                STATUS_PER = "1"
                VAR_PRO = "N"
                IMP_S = Decimal.Parse(txt_imp_soles.Text)
                Dim imp_pago As New Decimal
                If (COD_MON_DOC = COD_MONEDA) Then
                    imp_pago = IMP_S
                ElseIf (COD_MON_DOC = "D") Then
                    imp_pago = New Decimal((Convert.ToDouble(IMP_S) * Decimal.Parse(txt_cambio_pago.Text)))
                Else
                    'SOLES O AJUSTE
                    If COD_MON_DOC = "S" Then
                        imp_pago = New Decimal((Convert.ToDouble(IMP_S) / Decimal.Parse(txt_cambio_pago.Text)))
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
                If (cbo_control.SelectedIndex <> -1) Then
                    COD_CONTROL = obj.COD_CONTROL(cbo_control.Text)
                End If
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (CBO_CC.SelectedIndex <> -1) Then
                    COD_CC = obj.COD_CC(CBO_CC.Text)
                End If
                'If obj.VERIFICAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_nro_doc_per.Text, txt_cod_cta.Text) = False Then
                '    MessageBox.Show("EL documento ya existe en Cuentas por Pagar", "No se puede ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Else
                If VALIDAR_DET(COD_DOC, txt_nro_doc.Text, txt_cod1.Text) = False Then
                    MessageBox.Show("EL documento ya se ingresó.", "No se puede ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1).ToString("0000"), COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, imp_pago, IMP_S, COD_MON_DOC, CBO_D_H.Text, txt_cambio_pago.Text, dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, dtp_mp.Value, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, STATUS_PER, VAR_PRO, cod_ref, txt_nro_ref.Text)
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
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        btn_doc_pte.Enabled = False
        btn_doc_pte2.Enabled = False
        cbo_aux2.Enabled = False
        cbo_com2.Enabled = False
        txt_nro_comp2.Enabled = False
        txt_nro_comp22.Enabled = False
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
        BOTON = "MODIFICAR"
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        btn_grabar.Visible = False
        btn_grabar2.Visible = True
        g_cab.Enabled = False
        btn_grabar2.Enabled = True
        btn_imprimir.Enabled = False
        TabControl1.SelectedTab = TabPage2
        btn_nuevo_doc.Focus()
    End Sub
    Private Sub btn_modificar_pago0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar_pago0.Click
        Try
            Dim i As Integer = dgw_pago0.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        LIMPIAR_PAGO()
        GroupBox1.Enabled = False
        btn_grabar_pago01.Visible = False
        btn_grabar_pago02.Visible = True
        txt_item00.Text = (dgw_pago0.CurrentRow.Index)
        CARGAR_PAGO(txt_item00.Text)
        HALLAR_TOTAL()
        Panel_doc.Visible = True
        btn_nuevo_doc.Focus()
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
            Else
                COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
                cod_ref = ""
                If (cbo_tipo_ref.SelectedIndex <> -1) Then
                    cod_ref = obj.COD_DOC(cbo_tipo_ref.Text)
                End If
                COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
                COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
                STATUS_PER = "1"
                VAR_PRO = "N"
                IMP_S = Decimal.Parse(txt_imp_soles.Text)
                Dim imp_pago As New Decimal
                If (COD_MON_DOC = COD_MONEDA) Then
                    imp_pago = IMP_S
                ElseIf (COD_MON_DOC = "D") Then
                    imp_pago = New Decimal((Convert.ToDouble(IMP_S) * Decimal.Parse(txt_cambio_pago.Text)))
                Else
                    'SOLES O AJUSTE
                    If COD_MON_DOC = "S" Then
                        imp_pago = New Decimal((Convert.ToDouble(IMP_S) / Decimal.Parse(txt_cambio_pago.Text)))
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
                If (cbo_control.SelectedIndex <> -1) Then
                    COD_CONTROL = obj.COD_CONTROL(cbo_control.Text)
                End If
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto.Text)
                End If
                Dim FILA0 As Integer = Integer.Parse(TXT_ITEM0.Text)
                dgw_mov1.Item(6, FILA0).Value = imp_pago
                dgw_mov1.Item(7, FILA0).Value = IMP_S
                dgw_mov1.Item(8, FILA0).Value = COD_MON_DOC
                dgw_mov1.Item(9, FILA0).Value = CBO_D_H.Text
                dgw_mov1.Item(11, FILA0).Value = dtp_mp.Value.Date
                dgw_mov1.Item(12, FILA0).Value = txt_glosa.Text
                dgw_mov1.Item(13, FILA0).Value = txt_cod_cta.Text
                dgw_mov1.Item(15, FILA0).Value = COD_CC
                dgw_mov1.Item(16, FILA0).Value = COD_CONTROL
                dgw_mov1.Item(17, FILA0).Value = COD_PROYECTO
                dgw_mov1.Item(23, FILA0).Value = cod_ref
                dgw_mov1.Item(24, FILA0).Value = txt_nro_ref.Text
                HALLAR_TOTAL()
                Panel_det.Visible = False
                btn_nuevo_doc.Focus()
            End If
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        BOTON = "NUEVO"
        LIMPIAR_COMPROBANTE()
        TabControl1.SelectedTab = TabPage2
        cbo_aux.Focus()
    End Sub
    Private Sub btn_nuevo_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_doc.Click
        If txt_cod_cta_pago.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta_pago.Focus() : Exit Sub
        'If txt_cod_cta_pago.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta_pago.Focus() : Exit Sub
        If txt_nro_mp.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_mp.Focus() : Exit Sub
        If STATUS_ANA = "C" Then
            If txt_cod_per_cab.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per_cab.Focus() : Exit Sub
        End If
        If (cbo_moneda_pago.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda_pago.Focus()
        ElseIf dtp_mp.Value.Date > FECHA_GRAL.Date Then
            MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtp_mp.Focus()
        Else
            If (txt_cambio_pago.Text.Trim = "") Then
                txt_cambio_pago.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio_pago.Text) = 0) Then
                MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio_pago.Focus()
            ElseIf (txt_glosa_pago.Text.Trim = "") Then
                MessageBox.Show("Debe ingresar la glosa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_glosa_pago.Focus()
            Else
                LIMPIAR_DETALLES()
                btn_doc_pte2.Enabled = True
                cbo_aux2.Enabled = True
                cbo_com2.Enabled = True
                txt_nro_comp2.Enabled = True
                txt_nro_comp22.Enabled = True
                GroupBox1.Enabled = False
                Panel_det.Visible = True
                txt_cod1.Focus()
            End If
        End If
    End Sub
    Private Sub btn_nuevo_pago0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_pago0.Click
        If (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        Else
            g_cab.Enabled = False
            LIMPIAR_PAGO()
            Panel_doc.Visible = True
            txt_cod_cta_pago.Focus()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(18) = 0
        Close()
    End Sub
    Private Sub CANCELACION_CXP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CANCELACION_CXP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CBO_MONEDA00()
        CBO_MP00()
        CBO_PROYECTO00()
        CBO_CONTROL00()
        PERSONAS()
        CC00()
        CBO_TIPO_DOC00()
        CBO_AUXILIAR()
        CARGAR_CUENTAS()
        CREAR_DATASET()
        IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_pago0.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
    End Sub
    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        dgw_pago0.Rows.Clear()
        dgw_mov.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CXC_CANCELACION", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            pro_02.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            pro_02.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                If (rs3.GetValue(26)) = "1" Then
                    dgw_pago0.Rows.Add(rs3.GetValue(0), rs3.GetValue(28), rs3.GetValue(12), rs3.GetValue(27), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(25), (rs3.GetValue(22)), (rs3.GetValue(23)), (rs3.GetValue(24)), (rs3.GetValue(11)), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6))
                End If
                dgw_mov.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), (rs3.GetValue(11)), (rs3.GetValue(12)), (rs3.GetValue(13)), (rs3.GetValue(14)), rs3.GetString(15), (rs3.GetValue(16)), (rs3.GetValue(17)), (rs3.GetValue(18)), rs3.GetValue(19), (rs3.GetValue(20)), (rs3.GetValue(21)), (rs3.GetValue(22)), rs3.GetValue(23), rs3.GetValue(24), rs3.GetValue(25), rs3.GetValue(26), rs3.GetValue(31), rs3.GetValue(32))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTAS()
        Try
            Dim pro As New SqlCommand("DGW_CUENTA_PAGO_CXC", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt2 As New DataTable("Cuentas")
            Prog00.Fill(dt2)
            dgw_cta_pago.DataSource = dt2
            dgw_cta_pago.Columns.Item(2).Visible = False
            dgw_cta_pago.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta_pago.Columns.Item(0).Width = &H4B
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        DGW_CTA1.DataSource = obj.MOSTRAR_CUENTAS_STATUS(AÑO)
        DGW_CTA1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_CTA1.Columns.Item(2).Visible = False
        DGW_CTA1.Columns.Item(3).Visible = False
        DGW_CTA1.Columns.Item(4).Visible = False
        DGW_CTA1.Columns.Item(0).Width = 80
    End Sub
    Sub CARGAR_DETALLES(ByVal FILA0 As Object)
        VAR_PRO = dgw_mov1.Item(22, Integer.Parse(FILA0)).Value.ToString
        COD_DOC = dgw_mov1.Item(1, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc.Text = dgw_mov1.Item(2, Integer.Parse(FILA0)).Value.ToString
        txt_cod1.Text = dgw_mov1.Item(3, Integer.Parse(FILA0)).Value.ToString
        txt_desc_per.Text = dgw_mov1.Item(4, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc_per.Text = dgw_mov1.Item(5, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = dgw_mov1.Item(7, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = (obj.HACER_DECIMAL(txt_imp_soles.Text))
        COD_MON_DOC = dgw_mov1.Item(8, Integer.Parse(FILA0)).Value.ToString
        COD_D_H = dgw_mov1.Item(9, Integer.Parse(FILA0)).Value.ToString
        txt_glosa.Text = dgw_mov1.Item(12, Integer.Parse(FILA0)).Value.ToString
        txt_cod_cta.Text = dgw_mov1.Item(13, Integer.Parse(FILA0)).Value.ToString
        txt_desc_cta.Text = obj.DESC_CUENTA(txt_cod_cta.Text, AÑO)
        COD_CC = dgw_mov1.Item(15, Integer.Parse(FILA0)).Value.ToString
        COD_CONTROL = dgw_mov1.Item(16, Integer.Parse(FILA0)).Value.ToString
        COD_PROYECTO = dgw_mov1.Item(17, Integer.Parse(FILA0)).Value.ToString
        STATUS_CC = dgw_mov1.Item(8, Integer.Parse(FILA0)).Value.ToString
        STATUS_P = dgw_mov1.Item(20, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_doc.Text = obj.DESC_DOC(COD_DOC)
        CBO_D_H.Text = dgw_mov1.Item(9, Integer.Parse(FILA0)).Value.ToString
        cbo_moneda1.Text = obj.DESC_MONEDA(COD_MON_DOC)
        CBO_CC.Text = obj.DESC_CC(COD_CC)
        cbo_control.Text = obj.DESC_CONTROL(COD_CONTROL)
        cbo_proyecto.Text = obj.DESC_PROYECTO(COD_PROYECTO)
        cod_ref = dgw_mov1.Item(23, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_ref.Text = obj.DESC_DOC(cod_ref)
        txt_nro_ref.Text = dgw_mov1.Item(24, Integer.Parse(FILA0)).Value.ToString
        If (VAR_PRO = "S") Then
            txt_cod1.Enabled = False
            txt_desc_per.Enabled = False
            txt_nro_doc_per.Enabled = False
            cbo_tipo_doc.Enabled = False
            txt_nro_doc.Enabled = False
            txt_cod_cta.Enabled = False
            txt_desc_cta.Enabled = False
            cbo_moneda1.Enabled = False
        Else
            txt_cod1.Enabled = True
            txt_desc_per.Enabled = True
            txt_nro_doc_per.Enabled = True
            cbo_tipo_doc.Enabled = True
            txt_nro_doc.Enabled = True
            cbo_moneda1.Enabled = True
            txt_cod_cta.Enabled = True
            txt_desc_cta.Enabled = True
        End If
    End Sub
    Sub CARGAR_PAGO(ByVal FILA0 As Object)
        ITEM_PAGO = dgw_pago0.Item(9, Integer.Parse(FILA0)).Value.ToString
        COD_MP = dgw_pago0.Item(0, Integer.Parse(FILA0)).Value.ToString
        cbo_mp.Text = dgw_pago0.Item(1, Integer.Parse(FILA0)).Value.ToString
        txt_cod_cta_pago.Text = dgw_pago0.Item(2, Integer.Parse(FILA0)).Value.ToString
        txt_desc_cta_pago.Text = dgw_pago0.Item(3, Integer.Parse(FILA0)).Value.ToString
        txt_nro_mp.Text = dgw_pago0.Item(4, Integer.Parse(FILA0)).Value.ToString
        dtp_mp.Value = DateTime.Parse(dgw_pago0.Item(5, Integer.Parse(FILA0)).Value.ToString)
        TXT_PAGO.Text = dgw_pago0.Item(6, Integer.Parse(FILA0)).Value.ToString
        COD_MONEDA = dgw_pago0.Item(7, Integer.Parse(FILA0)).Value.ToString
        cbo_moneda_pago.Text = obj.DESC_MONEDA(COD_MONEDA)
        txt_cambio_pago.Text = dgw_pago0.Item(8, Integer.Parse(FILA0)).Value.ToString
        txt_glosa_pago.Text = dgw_pago0.Item(13, Integer.Parse(FILA0)).Value.ToString
        txt_cod_per_cab.Text = dgw_pago0.Item(16, Integer.Parse(FILA0)).Value.ToString
        txt_des_per_cab.Text = dgw_pago0.Item(17, Integer.Parse(FILA0)).Value.ToString
        txt_doc_per_cab.Text = dgw_pago0.Item(18, Integer.Parse(FILA0)).Value.ToString
        dgw_mov1.Rows.Clear()
        Dim k1 As Integer = 0
        Dim k2 As Integer = (dgw_mov.RowCount - 1)
        k1 = 0
        Do While (k1 <= k2)
            If dgw_mov.Item(25, k1).Value = ITEM_PAGO And dgw_mov.Item(26, k1).Value.ToString = "0" Then
                Dim PAGO As New Decimal
                If (COD_MONEDA = dgw_mov.Item(9, k1).Value.ToString) Then
                    PAGO = Decimal.Parse(dgw_mov.Item(8, k1).Value)
                ElseIf (COD_MONEDA = "D") Then
                    If dgw_mov.Item(9, k1).Value.ToString = "A" Then
                        PAGO = 0
                    Else
                        PAGO = Math.Round(Decimal.Parse(dgw_mov.Item(8, k1).Value / txt_cambio_pago.Text), 2)
                    End If
                Else
                    If dgw_mov.Item(9, k1).Value.ToString = "A" Then
                        PAGO = dgw_mov.Item(8, k1).Value
                    Else
                        PAGO = Math.Round(Decimal.Parse(dgw_mov.Item(8, k1).Value * txt_cambio_pago.Text), 2)
                    End If
                End If
                dgw_mov1.Rows.Add(New Object() {(dgw_mov1.RowCount + 1), (dgw_mov.Item(1, k1).Value), (dgw_mov.Item(2, k1).Value), (dgw_mov.Item(4, k1).Value), (dgw_mov.Item(5, k1).Value), (dgw_mov.Item(6, k1).Value), PAGO, (dgw_mov.Item(8, k1).Value), (dgw_mov.Item(9, k1).Value), (dgw_mov.Item(7, k1).Value), (dgw_mov.Item(10, k1).Value), (dgw_mov.Item(3, k1).Value), (dgw_mov.Item(11, k1).Value), (dgw_mov.Item(12, k1).Value), (dgw_mov.Item(17, k1).Value), (dgw_mov.Item(13, k1).Value), (dgw_mov.Item(14, k1).Value), (dgw_mov.Item(15, k1).Value), (dgw_mov.Item(18, k1).Value), (dgw_mov.Item(19, k1).Value), (dgw_mov.Item(20, k1).Value), (dgw_mov.Item(16, k1).Value), (dgw_mov.Item(21, k1).Value), (dgw_mov.Item(22, k1).Value), (dgw_mov.Item(23, k1).Value)})
            End If
            k1 += 1
        Loop
    End Sub
    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
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
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            COD_COMP = obj.COD_COMP(cbo_com.Text, COD_AUX)
            Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
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
    Sub CBO_CONTROL00()
        Try
            Dim PROG_01 As New SqlCommand("CBO_CONTROL_FECHA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA_GRAL
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_control.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cbo_moneda_pago_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda_pago.SelectedIndexChanged
        If (cbo_moneda_pago.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
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
        cbo_moneda_pago.DataSource = DT2
        cbo_moneda_pago.DisplayMember = DT2.Columns.Item(0).ToString
        cbo_moneda_pago.ValueMember = DT2.Columns.Item(1).ToString
        cbo_moneda_pago.SelectedIndex = -1
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
                cbo_tipo_ref.Items.Add(Rs3.GetString(0))
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
        CBO_CC.DataSource = DT
        CBO_CC.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC.SelectedIndex = -1
    End Sub
    Sub CREAR_DATASET()
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
    Sub DATAGRID()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ICON_CXC", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CCCAN"
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Cuentas")
            Prog02.Fill(dt_02)
            dgw1.DataSource = dt_02
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cta_pago_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_pago.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta_pago.Text = dgw_cta_pago.Item(0, dgw_cta_pago.CurrentRow.Index).Value.ToString
            txt_desc_cta_pago.Text = dgw_cta_pago.Item(1, dgw_cta_pago.CurrentRow.Index).Value.ToString
            STATUS_ANA = dgw_cta_pago.Item(2, dgw_cta_pago.CurrentRow.Index).Value.ToString
            '-----------------------------------------------------------------------------------------------
            If STATUS_ANA = "C" Then
                txt_cod_per_cab.Enabled = True
                txt_des_per_cab.Enabled = True
                txt_doc_per_cab.Enabled = True
            Else
                txt_cod_per_cab.Enabled = False
                txt_des_per_cab.Enabled = False
                txt_doc_per_cab.Enabled = False
            End If
            kl_pago.Focus()
            Panel_cta_pago.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta_pago.Visible = False
            txt_cod_cta_pago.Clear()
            txt_desc_cta_pago.Clear()
            txt_cod_cta_pago.Focus()
        End If
    End Sub
    Private Sub DGW_CTA1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_CTA1.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta.Text = DGW_CTA1.Item(0, DGW_CTA1.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = DGW_CTA1.Item(1, DGW_CTA1.CurrentRow.Index).Value.ToString
            STATUS_CC = DGW_CTA1.Item(2, DGW_CTA1.CurrentRow.Index).Value.ToString
            STATUS_P = DGW_CTA1.Item(3, DGW_CTA1.CurrentRow.Index).Value.ToString
            CBO_CC.SelectedIndex = -1
            CBO_CC.Enabled = False
            cbo_proyecto.SelectedIndex = -1
            cbo_proyecto.Enabled = False
            If (STATUS_CC = "1") Then
                CBO_CC.Enabled = True
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
    Private Sub DGW_PER_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DGW_PER.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod1.Text = DGW_PER.Item(0, DGW_PER.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = DGW_PER.Item(1, DGW_PER.CurrentRow.Index).Value.ToString
            txt_nro_doc_per.Text = DGW_PER.Item(2, DGW_PER.CurrentRow.Index).Value.ToString
            txt_glosa.Text = txt_desc_per.Text
            Panel_PER.Visible = False
            KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER.Visible = False
            txt_cod1.Clear()
            txt_desc_per.Clear()
            txt_nro_doc_per.Clear()
            txt_cod1.Focus()
        End If
    End Sub
    Private Sub dtp_mp_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_mp.LostFocus
        If (cbo_moneda_pago.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Sub ELIMINAR_PAGO(ByVal ITEM0 As Object)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_mov.RowCount
        Do While (I < CONT)
            If dgw_mov.Item(25, I).Value = ITEM0 Then
                dgw_mov.Rows.RemoveAt(I)
                I = 0
                CONT -= 1
            Else
                I += 1
            End If
        Loop
        dgw_pago0.Rows.RemoveAt(dgw_pago0.CurrentRow.Index)
    End Sub
    Function HALLAR_ITEM_PAGO() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_pago0.Rows.Count - 1)
        i = 0
        Do While (i <= cont)
            'If Operators.ConditionalCompareObjectGreater(dgw_pago0.Item(9, i).Value, mayor, False) Then
            If dgw_pago0.Item(9, i).Value > mayor Then
                mayor = Integer.Parse(dgw_pago0.Item(9, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("0000")
    End Function
    Sub HALLAR_TOTAL()
        Dim D_DOLARES As Decimal
        Dim D_SOLES As Decimal
        Dim H_DOLARES As Decimal
        Dim H_SOLES As Decimal
        Dim total As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        I = 0
        CONT = (dgw_mov1.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw_mov1.Item(9, I).Value.ToString = "D") Then
                'If (COD_MONEDA = "D") Then
                '    If dgw_mov1.Item(8, I).Value.ToString = "A" Then
                '        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(7, I).Value.ToString)))))), 2)
                '    Else
                '        D_DOLARES = Math.Round(Decimal.Add(D_DOLARES, Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                '        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString) * Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                '    End If
                'Else
                '    If dgw_mov1.Item(8, I).Value.ToString = "A" Then
                '        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                '    Else
                '        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                '        D_DOLARES = Math.Round(Decimal.Add(D_DOLARES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString) / Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                '    End If
                'End If
                Select Case dgw_mov1.Item(8, I).Value.ToString
                    Case "D"
                        D_DOLARES = D_DOLARES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value), 2)
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value * txt_cambio_pago.Text), 2)
                    Case "S"
                        D_DOLARES = D_DOLARES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value / txt_cambio_pago.Text), 2)
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value), 2)
                    Case "A"
                        D_DOLARES = D_DOLARES + 0
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value), 2)
                End Select
            Else
                'If (COD_MONEDA = "D") Then
                '    If dgw_mov1.Item(8, I).Value.ToString = "A" Then
                '        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(7, I).Value.ToString)))))), 2)
                '    Else
                '        H_DOLARES = Math.Round(Decimal.Add(H_DOLARES, Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                '        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString) * Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                '    End If
                'Else
                '    If dgw_mov1.Item(8, I).Value.ToString = "A" Then
                '        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                '    Else
                '        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString)), 2)
                '        H_DOLARES = Math.Round(Decimal.Add(H_DOLARES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(6, I).Value.ToString) / Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                '    End If
                'End If
                Select Case dgw_mov1.Item(8, I).Value.ToString
                    Case "D"
                        H_DOLARES = H_DOLARES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value), 2)
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value * txt_cambio_pago.Text), 2)
                    Case "S"
                        H_DOLARES = H_DOLARES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value / txt_cambio_pago.Text), 2)
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value), 2)
                    Case "A"
                        H_DOLARES = H_DOLARES + 0
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_mov1.Item(7, I).Value), 2)
                End Select
            End If
            I += 1
        Loop
        txt_debe_soles.Text = (obj.HACER_DECIMAL(D_SOLES))
        txt_debe_dolares.Text = (obj.HACER_DECIMAL(D_DOLARES))
        txt_haber_soles.Text = (obj.HACER_DECIMAL(H_SOLES))
        txt_haber_dolares.Text = (obj.HACER_DECIMAL(H_DOLARES))
        txt_saldo_soles.Text = (obj.HACER_DECIMAL(Decimal.Subtract(H_SOLES, D_SOLES)))
        txt_saldo_dolares.Text = (obj.HACER_DECIMAL(Decimal.Subtract(H_DOLARES, D_DOLARES)))
        COD_D_H_PAGO = "D"
        If (COD_MONEDA = "S") Then
            total = Decimal.Parse(txt_saldo_soles.Text)
        Else
            total = Decimal.Parse(txt_saldo_dolares.Text)
        End If
        If (Decimal.Compare(total, Decimal.Zero) < 0) Then
            total = Decimal.Multiply(total, Decimal.MinusOne)
            COD_D_H_PAGO = "H"
        End If
        TXT_PAGO.Text = (total)
        TXT_PAGO.Text = (obj.HACER_DECIMAL(TXT_PAGO.Text))
    End Sub
    Sub INSERTAR_DE_DAILOG()
        COD_CONTROL = ""
        COD_PROYECTO = ""
        COD_CC = ""
        If (cbo_control.SelectedIndex <> -1) Then
            COD_CONTROL = obj.COD_CONTROL(cbo_control.Text)
        End If
        If (cbo_proyecto.SelectedIndex <> -1) Then
            COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto.Text)
        End If
        If (CBO_CC.SelectedIndex <> -1) Then
            COD_CC = obj.COD_CC(CBO_CC.Text)
        End If
        Dim CONT As Integer = (OFR.DGW_CAB.Rows.Count - 1)
        Dim K As Integer = 0
        Do While (K <= CONT)
            If OFR.DGW_CAB.Item(9, K).Value.ToString = "True" Then
                Dim imp_pago As Decimal
                If (OFR.DGW_CAB.Item(6, K).Value.ToString = COD_MONEDA) Then
                    imp_pago = Decimal.Parse(OFR.DGW_CAB.Item(8, K).Value)
                ElseIf ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Multiply(OFR.DGW_CAB.Item(8, K).Value, txt_cambio_pago.Text)))
                Else
                    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Divide(OFR.DGW_CAB.Item(8, K).Value, txt_cambio_pago.Text)))
                End If
                dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1).ToString("0000"), OFR.DGW_CAB.Item(0, K).Value.ToString, OFR.DGW_CAB.Item(2, K).Value.ToString, OFR.DGW_CAB.Item(3, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(11, K).Value.ToString, imp_pago, OFR.DGW_CAB.Item(8, K).Value.ToString, OFR.DGW_CAB.Item(6, K).Value.ToString, OFR.DGW_CAB.Item(10, K).Value.ToString, txt_cambio_pago.Text, OFR.DGW_CAB.Item(5, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(14, K).Value.ToString, OFR.DGW_CAB.Item(5, K).Value.ToString, COD_CC, COD_CONTROL, COD_PROYECTO, OFR.DGW_CAB.Item(15, K).Value.ToString, OFR.DGW_CAB.Item(16, K).Value.ToString, OFR.DGW_CAB.Item(17, K).Value.ToString, "0", "S", "", "")
            End If
            K += 1
        Loop
    End Sub
    Sub INSERTAR_DGW_PAGO()
        Dim COD_DOC_EQ As String = obj.COD_DOC_EQ_MP(COD_MP)
        Dim ITEM0 As String = HALLAR_ITEM_PAGO()
        Dim CTE As String = "0"
        cod_ref = obj.COD_DOC(cbo_tipo_ref.Text)
        dgw_pago0.Rows.Add(COD_MP, cbo_mp.Text, txt_cod_cta_pago.Text, txt_desc_cta_pago.Text, txt_nro_mp.Text, dtp_mp.Value, TXT_PAGO.Text, COD_MONEDA, txt_cambio_pago.Text, ITEM0, COD_DOC_EQ, txt_nro_mp.Text, dtp_mp.Value, txt_glosa_pago.Text, COD_DOC_EQ, "", txt_cod_per_cab.Text, txt_des_per_cab.Text, txt_doc_per_cab.Text)
        dgw_mov.Rows.Add(COD_MP, COD_DOC_EQ, txt_nro_mp.Text, dtp_mp.Value, txt_cod_per_cab.Text, txt_des_per_cab.Text, txt_doc_per_cab.Text, COD_D_H_PAGO, TXT_PAGO.Text, COD_MONEDA, txt_cambio_pago.Text, txt_glosa_pago.Text, txt_cod_cta_pago.Text, " ", " ", " ", "0", dtp_mp.Value, "", "", "", "", cod_ref, txt_nro_ref.Text, dtp_mp.Value, ITEM0, "1", txt_saldo_soles.Text, txt_saldo_dolares.Text)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            Dim cod_doc22 As String = (dgw_mov1.Item(1, I).Value)
            Dim impsoles, impdolares As Decimal
            Select Case dgw_mov1.Item(8, I).Value.ToString
                Case "D"
                    impdolares = dgw_mov1.Item(7, I).Value
                    impsoles = Math.Round(Double.Parse(dgw_mov1.Item(7, I).Value * txt_cambio_pago.Text), 2)
                Case "S"
                    impdolares = Math.Round(Double.Parse(dgw_mov1.Item(7, I).Value / txt_cambio_pago.Text), 2)
                    impsoles = dgw_mov1.Item(7, I).Value
                Case "A"
                    impdolares = 0
                    impsoles = dgw_mov1.Item(7, I).Value
            End Select
            dgw_mov.Rows.Add(COD_MP, cod_doc22, (dgw_mov1.Item(2, I).Value), dtp_mp.Value, (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), (dgw_mov1.Item(9, I).Value), (dgw_mov1.Item(7, I).Value), (dgw_mov1.Item(8, I).Value), txt_cambio_pago.Text, (dgw_mov1.Item(12, I).Value), (dgw_mov1.Item(13, I).Value), (dgw_mov1.Item(15, I).Value), (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), CTE, (dgw_mov1.Item(14, I).Value), (dgw_mov1.Item(18, I).Value), (dgw_mov1.Item(19, I).Value), (dgw_mov1.Item(20, I).Value), (dgw_mov1.Item(22, I).Value), (dgw_mov1.Item(23, I).Value), (dgw_mov1.Item(24, I).Value), dtp_mp.Value, ITEM0, "0", impsoles, impdolares)
            I += 1
        Loop
    End Sub
    Function INSERTAR_TODO() As String
        Dim ESTADO As String = "FALLO"
        Dim BULK As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            Dim VAR_PRO00 As String
            SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(27, I).Value)), 2)
            DOLARES = Math.Round(Decimal.Parse((dgw_mov.Item(28, I).Value)), 2)
            'If dgw_mov.Item(9, I).Value = "S" Then
            '    SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
            '    DOLARES = Math.Round(Decimal.Divide(Decimal.Parse((dgw_mov.Item(8, I).Value)), Decimal.Parse((dgw_mov.Item(10, I).Value))), 2)
            'ElseIf dgw_mov.Item(9, I).Value = "A" Then
            '    SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
            '    DOLARES = 0
            'Else
            '    DOLARES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
            '    SOLES = Math.Round(Decimal.Multiply(Decimal.Parse((dgw_mov.Item(8, I).Value)), Decimal.Parse((dgw_mov.Item(10, I).Value))), 2)
            'End If
            If (dgw_mov.Item(26, I).Value.ToString = "1") Then
                VAR_PRO00 = "0"
            Else
                VAR_PRO00 = dgw_mov.Item(21, I).Value.ToString
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov.Item(1, I).Value), (dgw_mov.Item(2, I).Value), (dgw_mov.Item(4, I).Value), (dgw_mov.Item(6, I).Value), (I + 1).ToString("0000"), (dgw_mov.Item(3, I).Value), (dgw_mov.Item(22, I).Value), (dgw_mov.Item(23, I).Value), (dgw_mov.Item(24, I).Value), (dgw_mov.Item(11, I).Value), (dgw_mov.Item(12, I).Value), SOLES, DOLARES, (dgw_mov.Item(7, I).Value), (dgw_mov.Item(9, I).Value), (dgw_mov.Item(10, I).Value), (dgw_mov.Item(13, I).Value), (dgw_mov.Item(14, I).Value), (dgw_mov.Item(15, I).Value), " ", (dgw_mov.Item(17, I).Value), "0", "", "", "0", VAR_PRO00, "0", dgw_mov.Item(26, I).Value.ToString, (dgw_mov.Item(0, I).Value), dgw_mov.Item(23, I).Value.ToString, (dgw_mov.Item(3, I).Value), (dgw_mov.Item(25, I).Value), "", VAR_PRO00, dtp_com.Value, 0, NOMBRE_PC)
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
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_CXC_CANCELACION", con)
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
            con.Open()
            ESTADO = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Return ESTADO
    End Function
    Sub LIMPIAR_COMPROBANTE()
        Panel_pago0.Enabled = True
        Panel_pago0.Enabled = True
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        Dim DESC_COM As String = cbo_com.Text
        cbo_com.SelectedIndex = -1
        cbo_com.Text = DESC_COM
        btn_grabar.Visible = True
        btn_grabar2.Visible = False
        dgw_pago0.Rows.Clear()
        btn_grabar.Enabled = True
        dgw_mov.Rows.Clear()
        Panel_doc.Visible = False
        Panel_pago0.Enabled = True
        dtp_com.Value = FECHA_GRAL
        txt_cod1.Clear()
        txt_desc_per.Clear()
        txt_nro_doc_per.Clear()
        txt_cod_cta.Clear()
        txt_desc_cta.Clear()
        txt_cod_cta_pago.Clear()
        txt_desc_cta_pago.Clear()
        txt_cambio_pago.Text = "0.0000"
        txt_glosa_pago.Clear()
    End Sub
    Sub LIMPIAR_DETALLES()
        btn_doc_pte.Enabled = True
        Dim CONT As IEnumerator
        Try
            CONT = GroupBox3.Controls.GetEnumerator
            Do While CONT.MoveNext
                Dim text As Object = (CONT.Current)
                If TypeOf [text] Is TextBox Then
                    text.text = "" : text.ENABLED = True
                End If
                If TypeOf [text] Is ComboBox Then
                    text.SelectedIndex = -1 : text.ENABLED = True
                End If
            Loop
        Catch ex As Exception
        End Try
        Panel_PER.Visible = False
        txt_imp_soles.Text = "0.00"
        txt_nro_doc.Clear()
        txt_cod1.Enabled = True
        txt_desc_per.Enabled = True
        txt_nro_doc_per.Enabled = True
        cbo_tipo_doc.Enabled = True
        txt_nro_doc.Enabled = True
        txt_cod_cta.Enabled = True
        txt_desc_cta.Enabled = True
        cbo_moneda1.Text = cbo_moneda_pago.Text
        cbo_moneda1.Enabled = True
        txt_imp_soles.Text = "0.00"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        cbo_tipo_ref.SelectedIndex = -1
        txt_nro_ref.Clear()
    End Sub
    Sub LIMPIAR_PAGO()
        GroupBox1.Enabled = True
        TXT_PAGO.Text = "0.00"
        dgw_mov1.Rows.Clear()
        GroupBox1.Enabled = True
        dtp_mp.Value = FECHA_GRAL
        txt_nro_mp.Clear()
        Panel_doc.Enabled = True
        Panel_det.Visible = False
        STATUS_DOC = "CP"
        btn_grabar_pago01.Visible = True
        btn_grabar_pago02.Visible = False
        txt_debe_soles.Text = "0.00"
        txt_debe_dolares.Text = "0.00"
        txt_haber_soles.Text = "0.00"
        txt_haber_dolares.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        txt_saldo_dolares.Text = "0.00"
        '------------------------------------------------
        txt_cod_per_cab.Clear()
        txt_des_per_cab.Clear()
        txt_doc_per_cab.Clear()
        'If STATUS_ANA = "P" Then
        txt_cod_per_cab.Enabled = True
        txt_des_per_cab.Enabled = True
        txt_doc_per_cab.Enabled = True
        'Else
        '    txt_cod_per_cab.Enabled = False
        '    txt_des_per_cab.Enabled = False
        '    txt_doc_per_cab.Enabled = False
        'End If
    End Sub
    Function MODIFICAR_TODO() As String
        Dim ESTADO As String = "FALLO"
        Dim BULK As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            Dim VAR_PRO00 As String
            SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(27, I).Value)), 2)
            DOLARES = Math.Round(Decimal.Parse((dgw_mov.Item(28, I).Value)), 2)
            'If dgw_mov.Item(9, I).Value = "S" Then
            '    SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
            '    DOLARES = Math.Round(Decimal.Divide(Decimal.Parse((dgw_mov.Item(8, I).Value)), Decimal.Parse((dgw_mov.Item(10, I).Value))), 2)
            'ElseIf dgw_mov.Item(9, I).Value = "A" Then
            '    SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
            '    DOLARES = 0
            'Else
            '    DOLARES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
            '    SOLES = Math.Round(Decimal.Multiply(Decimal.Parse((dgw_mov.Item(8, I).Value)), Decimal.Parse((dgw_mov.Item(10, I).Value))), 2)
            'End If
            If (dgw_mov.Item(26, I).Value.ToString = "1") Then
                VAR_PRO00 = "0"
            Else
                VAR_PRO00 = dgw_mov.Item(21, I).Value.ToString
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov.Item(1, I).Value), (dgw_mov.Item(2, I).Value), (dgw_mov.Item(4, I).Value), (dgw_mov.Item(6, I).Value), (I + 1).ToString("0000"), (dgw_mov.Item(3, I).Value), (dgw_mov.Item(22, I).Value), (dgw_mov.Item(23, I).Value), (dgw_mov.Item(24, I).Value), (dgw_mov.Item(11, I).Value), (dgw_mov.Item(12, I).Value), SOLES, DOLARES, (dgw_mov.Item(7, I).Value), (dgw_mov.Item(9, I).Value), (dgw_mov.Item(10, I).Value), (dgw_mov.Item(13, I).Value), (dgw_mov.Item(14, I).Value), (dgw_mov.Item(15, I).Value), " ", (dgw_mov.Item(17, I).Value), "0", "", "", "0", VAR_PRO00, "0", dgw_mov.Item(26, I).Value.ToString, (dgw_mov.Item(0, I).Value), dgw_mov.Item(23, I).Value.ToString, (dgw_mov.Item(3, I).Value), (dgw_mov.Item(25, I).Value), "", VAR_PRO00, dtp_com.Value, 0, NOMBRE_PC)
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
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_CXC_CANCELACION", con)
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
            con.Open()
            ESTADO = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Return ESTADO
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
            DGW_PER.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            DGW_PER_CAB.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            DGW_PER.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER_CAB.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER.Columns.Item(0).Width = &H37
            DGW_PER_CAB.Columns.Item(0).Width = &H37
            DGW_PER.Columns.Item(1).Width = 330
            DGW_PER_CAB.Columns.Item(1).Width = 330
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cambio_pago_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio_pago.LostFocus
        If (Strings.Trim(txt_cambio_pago.Text) <> "") Then
            Try
                txt_cambio_pago.Text = (obj.HACER_CAMBIO(txt_cambio_pago.Text))
            Catch ex As Exception
                txt_cambio_pago.Text = "0.0000"
            End Try
        End If
    End Sub
    Private Sub txt_cod_cta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) <> "") Then
            If (DGW_CTA1.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_CTA1.Sort(DGW_CTA1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_CTA1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta.Text.ToLower = DGW_CTA1.Item(1, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = DGW_CTA1.Item(0, i).Value.ToString
                        txt_desc_cta.Text = DGW_CTA1.Item(1, i).Value.ToString
                        STATUS_CC = DGW_CTA1.Item(2, i).Value.ToString
                        STATUS_P = DGW_CTA1.Item(3, i).Value.ToString
                        CBO_CC.SelectedIndex = -1
                        CBO_CC.Enabled = False
                        cbo_proyecto.SelectedIndex = -1
                        cbo_proyecto.Enabled = False
                        If (STATUS_CC = "1") Then
                            CBO_CC.Enabled = True
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
    Private Sub txt_cod_cta_pago_LostFocus1(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta_pago.LostFocus
        If (Strings.Trim(txt_cod_cta_pago.Text) <> "") Then
            If (dgw_cta_pago.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago.Sort(dgw_cta_pago.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta_pago.Text.ToLower = dgw_cta_pago.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta_pago.Text = dgw_cta_pago.Item(0, i).Value.ToString
                        txt_desc_cta_pago.Text = dgw_cta_pago.Item(1, i).Value.ToString
                        STATUS_ANA = dgw_cta_pago.Item(2, i).Value.ToString
                        cbo_mp.Focus()
                        Return
                    End If
                    If (txt_cod_cta_pago.Text.ToLower = Strings.Mid((dgw_cta_pago.Item(0, i).Value), 1, Strings.Len(txt_cod_cta_pago.Text)).ToLower) Then
                        dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta_pago.Visible = True
                dgw_cta_pago.Visible = True
                dgw_cta_pago.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cod1_LostFocus1(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod1.LostFocus
        If (txt_cod1.Text.Trim <> "") Then
            If (DGW_PER.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod1.Text.ToLower = DGW_PER.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod1.Text = DGW_PER.Item(0, i).Value.ToString
                        txt_desc_per.Text = DGW_PER.Item(1, i).Value.ToString
                        txt_nro_doc_per.Text = DGW_PER.Item(2, i).Value.ToString
                        cbo_tipo_doc.Focus()
                        Return
                    End If
                    If (txt_cod1.Text.ToLower = Strings.Mid((DGW_PER.Item(0, i).Value), 1, Strings.Len(txt_cod1.Text)).ToLower) Then
                        DGW_PER.CurrentCell = DGW_PER.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER.CurrentCell = DGW_PER.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER.Visible = True
                DGW_PER.Visible = True
                DGW_PER.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (DGW_CTA1.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_CTA1.Sort(DGW_CTA1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_CTA1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
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
    Private Sub txt_desc_cta_pago_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta_pago.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_pago.Text) <> "")) Then
            If (dgw_cta_pago.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago.Sort(dgw_cta_pago.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta_pago.Text.ToLower = Strings.Mid((dgw_cta_pago.Item(1, i).Value), 1, Strings.Len(txt_desc_cta_pago.Text)).ToLower) Then
                        dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta_pago.Visible = True
                dgw_cta_pago.Visible = True
                dgw_cta_pago.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (DGW_PER.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((DGW_PER.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        DGW_PER.CurrentCell = DGW_PER.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER.CurrentCell = DGW_PER.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER.Visible = True
                DGW_PER.Visible = True
                DGW_PER.Focus()
            End If
        End If
    End Sub
    Private Sub txt_imp_soles_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_soles.KeyPress
        e.Handled = Numero(e, txt_imp_soles)
    End Sub
    Private Sub txt_imp_soles_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_imp_soles.LostFocus
        If (Strings.Trim(txt_imp_soles.Text) <> "") Then
            Try
                txt_imp_soles.Text = (obj.HACER_DECIMAL(txt_imp_soles.Text))
            Catch ex As Exception
                txt_imp_soles.Text = "0.00"
            End Try
        End If
    End Sub
    Private Sub txt_nro_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_nro_doc_per.Text) <> "")) Then
            If (DGW_PER.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_nro_doc_per.Text.ToLower = Strings.Mid((DGW_PER.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per.Text)).ToLower) Then
                        DGW_PER.CurrentCell = DGW_PER.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER.CurrentCell = DGW_PER.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER.Visible = True
                DGW_PER.Visible = True
                DGW_PER.Focus()
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
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw_mov.Rows.Count - 1
        Dim IMPORTE As Decimal
        Dim IMPORTE_DEBE, IMPORTE_HABER, COLUM_DOL As Decimal
        For I = 0 To cont
            IMPORTE = dgw_mov.Item(8, I).Value
            '----------------------------------------------------------------------------------
            If (dgw_mov.Item(9, I).Value) = "S" Then
                COLUM_DOL = obj.HACER_DECIMAL(IMPORTE / dgw_mov.Item(10, I).Value)
            ElseIf (dgw_mov.Item(9, I).Value) = "D" Then
                COLUM_DOL = obj.HACER_DECIMAL(IMPORTE)
            End If
            If dgw_mov.Item(7, I).Value = "D" Then
                If dgw_mov.Item(9, I).Value = "D" Then
                    IMPORTE_DEBE = obj.HACER_DECIMAL(IMPORTE * dgw_mov.Item(10, I).Value)
                    IMPORTE_HABER = "0.00"
                ElseIf dgw_mov.Item(9, I).Value = "S" Then
                    IMPORTE_DEBE = obj.HACER_DECIMAL(IMPORTE)
                    IMPORTE_HABER = "0.00"
                End If
            ElseIf dgw_mov.Item(7, I).Value = "H" Then
                If dgw_mov.Item(9, I).Value = "D" Then
                    IMPORTE_HABER = obj.HACER_DECIMAL(IMPORTE * dgw_mov.Item(10, I).Value)
                    IMPORTE_DEBE = "0.00"
                ElseIf dgw_mov.Item(9, I).Value = "S" Then
                    IMPORTE_HABER = obj.HACER_DECIMAL(IMPORTE)
                    IMPORTE_DEBE = "0.00"
                End If
            End If
            Dim COD_REPOR As String
            COD_REPOR = obj.DESC_USUARIO_COMPROBANTE(cbo_aux.SelectedValue.ToString, cbo_com.SelectedValue.ToString, txt_nro_comp.Text, AÑO, MES)
            dt.DataTable1.Rows.Add(dgw_mov.Item(3, I).Value.ToString.Substring(0, 10),dgw_mov.Item(2, I).Value, dgw_mov.Item(1, I).Value, dgw_mov.Item(4, I).Value, dgw_mov.Item(13, I).Value,dgw_mov.Item(12, I).Value,dgw_mov.Item(5, I).Value, dgw_mov.Item(9, I).Value,dgw_mov.Item(10, I).Value,COLUM_DOL, IMPORTE_DEBE, IMPORTE_HABER, dgw_mov.Item(7, I).Value, dgw_mov.Item(23, I).Value, txt_nro_comp.Text, COD_REPOR, dgw_mov.Item(11, I).Value, cbo_com.Text)
        Next

        reporte.SetDataSource(dt)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = obj.DESC_MES(MES)
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = AÑO
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_aux.Text
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)
        '======================================================================================



        reporte.PrintToPrinter(1, False, 0, 0)
    End Sub
    Private Sub cbo_tipo_doc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo_doc.SelectedIndexChanged
        If cbo_tipo_doc.SelectedIndex <> -1 Then
            COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
            COD_D_H = obj.COD_D_H(COD_DOC)
            If COD_D_H = "D" Then
                CBO_D_H.Text = "H"
            Else
                CBO_D_H.Text = "D"
            End If
        End If
    End Sub
    Private Sub txt_cod_per_cab_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_per_cab.LostFocus
        If (txt_cod_per_cab.Text.Trim <> "") Then
            If (DGW_PER_CAB.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER_CAB.Sort(DGW_PER_CAB.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER_CAB.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_per_cab.Text.ToLower = DGW_PER_CAB.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per_cab.Text = DGW_PER_CAB.Item(0, i).Value.ToString
                        txt_des_per_cab.Text = DGW_PER_CAB.Item(1, i).Value.ToString
                        txt_doc_per_cab.Text = DGW_PER_CAB.Item(2, i).Value.ToString
                        btn_nuevo_doc.Focus()
                        Return
                    End If
                    If (txt_cod_per_cab.Text.ToLower = Strings.Mid((DGW_PER_CAB.Item(0, i).Value), 1, Strings.Len(txt_cod_per_cab.Text)).ToLower) Then
                        DGW_PER_CAB.CurrentCell = DGW_PER_CAB.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER_CAB.CurrentCell = DGW_PER_CAB.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel1.Visible = True
                DGW_PER_CAB.Visible = True
                DGW_PER_CAB.Focus()
            End If
        End If
    End Sub
    Private Sub txt_des_per_cab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_des_per_cab.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_des_per_cab.Text) <> "")) Then
            If (DGW_PER_CAB.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER_CAB.Sort(DGW_PER_CAB.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER_CAB.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_des_per_cab.Text.ToLower = Strings.Mid((DGW_PER_CAB.Item(1, i).Value), 1, Strings.Len(txt_des_per_cab.Text)).ToLower) Then
                        DGW_PER_CAB.CurrentCell = DGW_PER_CAB.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER_CAB.CurrentCell = DGW_PER_CAB.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel1.Visible = True
                DGW_PER_CAB.Visible = True
                DGW_PER_CAB.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_cab_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per_cab.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per_cab.Text) <> "")) Then
            If (DGW_PER_CAB.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER_CAB.Sort(DGW_PER_CAB.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER_CAB.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_doc_per_cab.Text.ToLower = Strings.Mid((DGW_PER_CAB.Item(2, i).Value), 1, Strings.Len(txt_doc_per_cab.Text)).ToLower) Then
                        DGW_PER_CAB.CurrentCell = DGW_PER_CAB.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER_CAB.CurrentCell = DGW_PER_CAB.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel1.Visible = True
                DGW_PER_CAB.Visible = True
                DGW_PER_CAB.Focus()
            End If
        End If
    End Sub
    Private Sub DGW_PER_CAB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGW_PER_CAB.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per_cab.Text = DGW_PER_CAB.Item(0, DGW_PER_CAB.CurrentRow.Index).Value.ToString
            txt_des_per_cab.Text = DGW_PER_CAB.Item(1, DGW_PER_CAB.CurrentRow.Index).Value.ToString
            txt_doc_per_cab.Text = DGW_PER_CAB.Item(2, DGW_PER_CAB.CurrentRow.Index).Value.ToString
            'txt_glosa.Text = txt_desc_per.Text
            Panel1.Visible = False
            KL5.Focus()
            'btn_nuevo_doc.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel1.Visible = False
            txt_cod_per_cab.Clear()
            txt_des_per_cab.Clear()
            txt_doc_per_cab.Clear()
            txt_cod_per_cab.Focus()
        End If
    End Sub
    Private Sub btn_nuevo_comp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_comp.Click
        BOTON = "NUEVO"
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
    End Sub
    Private Sub cbo_aux2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_aux2.SelectedIndexChanged
        If (cbo_aux2.SelectedIndex <> -1) Then
            COD_AUX2 = obj.COD_AUX(cbo_aux2.Text)
            CBO_COMPROBANTE2()
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
    Private Sub cbo_com2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_com2.SelectedIndexChanged
        If ((cbo_aux2.SelectedIndex <> -1) And (cbo_com2.SelectedIndex <> -1)) Then
            COD_AUX2 = obj.COD_AUX(cbo_aux2.Text)
            COD_COMP2 = obj.COD_COMP(cbo_com2.Text, COD_AUX2)
        End If
    End Sub
    Private Sub btn_doc_pte2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_doc_pte2.Click
        If cbo_aux2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux2.Focus() : Exit Sub
        If cbo_com2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com2.Focus() : Exit Sub
        If txt_nro_comp2.Text = " " Then MessageBox.Show("Debe ingresar el N° de comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp2.Focus() : Exit Sub
        If txt_nro_comp22.Text = " " Then MessageBox.Show("Debe ingresar el N° de comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp22.Focus() : Exit Sub
        BOTON4()
    End Sub
    Sub BOTON4()
        OFR.COD_SUC = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        'OFR.COD_CPTO00 = ""
        OFR.COD_AUX00 = COD_AUX2
        OFR.COD_COMP00 = COD_COMP2
        OFR.NRO_COMP00 = txt_nro_comp2.Text
        OFR.NRO_COMP01 = txt_nro_comp22.Text
        OFR.CARGAR_PCTAS_COBRAR_X_COMPROBANTE()
        OFR.limpiar()
        OFR.ShowDialog()
        If (OFR.DialogResult = Windows.Forms.DialogResult.OK) Then
            If (OFR.LBL.Text = "NO") Then
                BOTON4()
            Else
                INSERTAR_DE_DAILOG()
                OFR.Hide()
                HALLAR_TOTAL()
            End If
            Panel_det.Visible = False
            btn_nuevo_doc.Focus()
        End If
    End Sub
    Private Sub txt_glosa_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_glosa_pago.LostFocus
        If STATUS_ANA = "C" Then
            txt_cod_per_cab.Focus()
        Else
            btn_nuevo_doc.Focus()
        End If
    End Sub
End Class