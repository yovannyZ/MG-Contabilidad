Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class PROV_HONORARIOS
    Dim con00 As New SqlConnection(("data source=" & nombre_servidor & ";initial catalog=BD_COS" & COD_EMPRESA & ";uid=miguel;pwd=main;"))
    Dim BOTON, COD_AUX, COD_MONEDA, COD_P, COD_C, COD_CC, COD_COMP, COD_DH_DOC, COD_DOC, COD_ACT As String
    Dim DESTINO, ORDEN_BI, ESTADO_AUTO, ENLACE, ORDEN_IGV, ORDEN_TOTAL, STATUS_CC, STATUS_P, STATUS_PV As String
    Dim DT_DET As New DataTable
    Dim DT_DOC As New DataTable
    Dim FILA_DOC, fila2, fila3 As Integer
    Dim IGV0 As Decimal
    Dim OBJ As New Class1
    Dim reporte As New CrystalReport1
    Dim reporte1 As New CrystalComprobante
    Dim ofr As New CONSULTA_REQ_ORD_PROD

    Private ValidarFicha As Boolean = True

    Sub ReporteImprimir(ByVal oDatos As Object, ByVal oReporte As Object, ByVal oAuxiliar As String)
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

        If TypeOf oReporte Is CrystalReport1 Then
            oReporte.PrintOptions.PaperSize = DirectCast(OBJ.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        Else
            oReporte.PrintOptions.PaperSize = DirectCast(OBJ.TamañoPapel("IMPRESION1"), CrystalDecisions.Shared.PaperSize)
        End If
        oReporte.PrintToPrinter(1, False, 0, 0)

        'oReporte.PrintOptions.PaperSize = DirectCast(obj.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        'oReporte.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub btn_act_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_act.Click
        DGW_PERSONAS()
    End Sub

    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim CONT0 As Integer = (dgw_per.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_per.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_per.Text.ToLower = Strings.Mid(dgw_per.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    dgw_per.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        dgw_per.Focus()
    End Sub

    Private Sub btn_cadena3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena3.Click
        btn_sgt3.Enabled = True
        Dim CONT0 As Integer = (dgw_cta_imp.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_cta_imp.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_cta_imp.Text.ToLower = Strings.Mid(dgw_cta_imp.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cta_imp.Text)).ToLower) Then
                    dgw_cta_imp.CurrentCell = dgw_cta_imp.Rows.Item(i).Cells.Item(1)
                    fila3 = (i + 1)
                    dgw_cta_imp.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        dgw_cta_imp.Focus()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        Panel_det02.Visible = False
        btn_nuevo_det.Focus()
    End Sub

    Private Sub btn_cancelar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_com.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub

    Private Sub btn_cancelar_doc2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_doc2.Click
        Panel_DOC02.Visible = False
        btn_nuevo_doc.Focus()
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consultar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        BOTON = "CONSULTA"
        ValidarFicha = False

        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = False
        Panel2.Enabled = False
        btn_imprimir.Enabled = True
        TabControl1.SelectedTab = TabPage3
        btn_imprimir.Focus()
        ValidarFicha = True
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
            If OBJ.VERIFICAR_TRANSF_PRODUCCION(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Producción", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If OBJ.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_HONORARIOS", con)
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
            DATAGRID()
        End If
    End Sub

    Private Sub btn_eliminar_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar_doc.Click
        FILA_DOC = dgw_doc_01.CurrentRow.Index
        COD_DOC = (dgw_doc_01.Item(3, FILA_DOC).Value)
        Dim NRO_DOC0 As String = (dgw_doc_01.Item(4, FILA_DOC).Value)
        Dim COD_PER0 As String = dgw_doc_01.Item(5, FILA_DOC).Value.ToString
        Dim DOC_PER0 As String = dgw_doc_01.Item(7, FILA_DOC).Value.ToString
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.RowCount - 1)
        Dim CUENTA0 As String = ""
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If dgw_det_01.Item(25, I).Value = "T" And dgw_det_01.Item(20, I).Value = COD_DOC And dgw_det_01.Item(21, I).Value = NRO_DOC0 And dgw_det_01.Item(22, I).Value = COD_PER0 And dgw_det_01.Item(23, I).Value = DOC_PER0 And (dgw_det_01.Item(25, I).Value = "B" Or dgw_det_01.Item(25, I).Value = "I" Or dgw_det_01.Item(25, I).Value = "T") Then
                CUENTA0 = (dgw_det_01.Item(1, I).Value)
            End If
            I += 1
        Loop
        If OBJ.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, NRO_DOC0, COD_PER0, DOC_PER0, CUENTA0) = False Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse((CInt(MessageBox.Show("Desea borrar el documento", " Borrar Documento?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            FILA_DOC = dgw_doc_01.CurrentRow.Index
            ELIMINAR_DOCUMENTO_DGW(FILA_DOC)
        End If
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el detalle", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            dgw_mov1.Rows.RemoveAt(dgw_mov1.CurrentRow.Index)
            HALLAR_TOTAL_DOC()
        End If
    End Sub

    Private Sub btn_grabar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com.Click
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
        ElseIf (dgw_doc_01.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_doc.Focus()
        Else
            If (ESTADO_AUTO <> "SI") Then
                GENERAR_AUTO()
            End If
            ESTADO_AUTO = "SI"

            txt_nro_comp.Text = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (INSERTAR_TODO() = "EXITO") Then
                txt_nro_comp.Text = OBJ.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                Panel2.Enabled = False
                btn_grabar_com.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
                Panel2.Enabled = False
            Else
                OBJ.ELIMINAR_TEMPORAL("PHON")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_grabar_com2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com2.Click
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
        ElseIf (dgw_doc_01.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_doc.Focus()
        Else
            If (ESTADO_AUTO <> "SI") Then
                GENERAR_AUTO()
            End If
            ESTADO_AUTO = "SI"
            If (MODIFICAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se actualizó con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                Panel2.Enabled = False
                btn_grabar_com2.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
                Panel2.Enabled = False
            Else
                OBJ.ELIMINAR_TEMPORAL("PHON")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub

    Private Sub btn_grabar_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_doc.Click
        If (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        ElseIf (txt_cta_igv.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Renta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_igv.Focus()
        ElseIf (txt_cta_total.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_total.Focus()
        ElseIf (Decimal.Parse(txt_total.Text) <= 0) Then
            MessageBox.Show("No existe Importe Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_total.Text) <> Convert.ToDouble(New Decimal((Convert.ToDouble(HALLAR_TOTAL_BI_DOC) - Decimal.Parse(txt_igv.Text))))) Then
            MessageBox.Show("Documento con descuadre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        ElseIf VERIFICAR_DATAGRID_DOC(txt_cod_per0.Text, txt_doc_per.Text, COD_DOC, txt_nro_doc.Text) = False Then
            MessageBox.Show("Ya guardo el documento.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf OBJ.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False Then
            MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            '-----------------
            'If (COD_MONEDA = "D") Then
            '    Dim D_DEBE As Decimal
            '    Dim D_HABER As Decimal
            '    If (COD_DH_DOC = "H") Then
            '        D_HABER = Decimal.Parse(OBJ.HACER_DECIMAL(txt_total.Text))
            '        D_DEBE = Decimal.Parse(OBJ.HACER_DECIMAL(txt_igv.Text))
            '    Else
            '        D_DEBE = Decimal.Parse(OBJ.HACER_DECIMAL(txt_total.Text))
            '        D_HABER = Decimal.Parse(OBJ.HACER_DECIMAL(txt_igv.Text))
            '    End If
            '    'If VALIDAR_SOLES01(D_DEBE, D_HABER, Decimal.Parse(txt_cambio01.Text)) = False Then
            '    '    DESCUADRE.ShowDialog()
            '    '    Return
            '    'End If
            'ElseIf (COD_MONEDA = "S") Then
            '    Dim S_DEBE As Decimal
            '    Dim S_HABER As Decimal
            '    If (COD_DH_DOC = "H") Then
            '        S_HABER = Decimal.Parse(OBJ.HACER_DECIMAL(txt_total.Text))
            '        S_DEBE = Decimal.Parse(OBJ.HACER_DECIMAL(txt_igv.Text))
            '    Else
            '        S_DEBE = Decimal.Parse(OBJ.HACER_DECIMAL(txt_total.Text))
            '        S_HABER = Decimal.Parse(OBJ.HACER_DECIMAL(txt_igv.Text))
            '    End If
            '    'If VALIDAR_DOLARES01(S_DEBE, S_HABER, Decimal.Parse(txt_cambio01.Text)) = False Then
            '    '    DESCUADRE.ShowDialog()
            '    '    Return
            '    'End If
            'End If

            '---------------
            If VERIFICAR_SOLES01() = False Then Exit Sub
            INSERTAR_DOCUMENTO_DGW()
            MessageBox.Show("El Documento se ingresó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_DOCUMENTOS()
            cbo_tipo_doc.Focus()
        End If
    End Sub
    Function VERIFICAR_SOLES01() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = dgw_mov1.RowCount - 1
        Dim SOLESD, SOLESH As Decimal
        '----------------------------------------------
        For I = 0 To CONT
            If dgw_mov1.Item(5, I).Value = "D" Then
                SOLESD = SOLESD + dgw_mov1.Item(3, I).Value
            Else
                SOLESH = SOLESH + dgw_mov1.Item(3, I).Value
            End If
        Next
        '----------------------------------------------
        ' IGV Y TOTAL
        '----------------------------------------------
        Dim imp_s_igv, imp_s_t As Decimal
        imp_s_igv = 0 : imp_s_t = 0
        If (COD_MONEDA = "S") Then
            imp_s_igv = Math.Round(Decimal.Parse(txt_igv.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_total.Text), 2)
        Else
            imp_s_igv = Math.Round(Decimal.Parse(txt_igv.Text * txt_cambio.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_total.Text * txt_cambio.Text), 2)
        End If
        Dim DH_IGV, DH_T As String
        DH_IGV = "" : DH_T = ""
        If (COD_DH_DOC = "D") Then
            DH_IGV = "H"
            DH_T = "D"
        ElseIf (COD_DH_DOC = "H") Then
            DH_IGV = "D"
            DH_T = "H"
        End If
        'IGV
        If DH_IGV = "D" Then
            SOLESD = SOLESD - imp_s_igv
        Else
            SOLESH = SOLESH - imp_s_igv
        End If
        'TOTAL
        If DH_T = "D" Then
            SOLESD = SOLESD + imp_s_t
        Else
            SOLESH = SOLESH + imp_s_t
        End If
        SOLESD = Math.Round(SOLESD, 2)
        SOLESH = Math.Round(SOLESH, 2)
        'Dim DH00 As String = "D"
        'If SOLESD < SOLESH Then DH00 = "H"

        Dim DH00 As String = "H"
        If SOLESD < SOLESH Then DH00 = "D"

        If SOLESH = SOLESD Then
            Return True
        Else
            MessageBox.Show("Diferencia en soles de " & obj.HACER_DECIMAL((SOLESH - SOLESD)) & "" & DH00, "Existe descuadre en soles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        '----------------------------------------------
    End Function
    Private Sub btn_grabar_doc2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_doc2.Click
        If (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        ElseIf (txt_cta_igv.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Renta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_igv.Focus()
        ElseIf (txt_cta_total.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_total.Focus()
        ElseIf (Decimal.Parse(txt_total.Text) <= 0) Then
            MessageBox.Show("No existe Importe Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_total.Text) <> Convert.ToDouble(New Decimal((Convert.ToDouble(HALLAR_TOTAL_BI_DOC) - Decimal.Parse(txt_igv.Text))))) Then
            MessageBox.Show("Documento con descuadre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If VERIFICAR_SOLES01() = False Then Exit Sub
            ELIMINAR_DOCUMENTO_DGW(FILA_DOC)
            INSERTAR_DOCUMENTO_DGW()
            MessageBox.Show("El Documento se Actualizó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Panel_DOC02.Visible = False
            btn_nuevo_doc.Focus()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (txt_cta_imp.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_imp.Focus()
        Else
            If CBO_ORDEN.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
            If (txt_bi.Text.Trim = "") Then
                txt_bi.Text = "0.00"
            End If
            If (Decimal.Parse(txt_bi.Text) = 0) Then
                MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_bi.Focus()
            ElseIf ((cbo_cc.SelectedIndex = -1) And cbo_cc.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_cc.Focus()
            ElseIf ((cbo_proyecto.SelectedIndex = -1) And cbo_proyecto.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_proyecto.Focus()
            Else
                Dim BI_DOL As Decimal
                Dim BI_REAL As Decimal
                Dim BI_SOL As Decimal
                Dim BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA
                Dim rep As String = "0"
                If ch_rep.Checked Then
                    rep = "1"
                End If
                If (lbl_moneda_det.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 - Decimal.Parse(TXT_IGV0.Text)))), 3))
                Else
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = BI_TEMP
                End If
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio.Text))), 3))

                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio.Text))), 3))

                    Case "A"
                        BI_DOL = New Decimal
                        BI_SOL = BI_REAL
                End Select
                Dim ITEM As Integer = Integer.Parse(HALLAR_ITEM)
                ENLACE = ""
                DESTINO = ""
                If cbo_auto.Visible Then
                    ITEM = (ITEM + 2)
                End If
                DESTINO = Strings.Mid((cbo_auto.SelectedItem), 1, 8)
                ENLACE = Strings.Mid((cbo_auto.SelectedItem), 24, 31)
                COD_C = ""
                COD_P = ""
                COD_CC = ""
                COD_ACT = ""
                ORDEN_BI = CBO_ORDEN.Text
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_P = OBJ.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (cbo_cc.SelectedIndex <> -1) Then
                    COD_CC = OBJ.COD_CC(cbo_cc.Text)
                End If

                If cbo_act01.SelectedIndex <> -1 Then
                    COD_ACT = cbo_act01.SelectedValue.ToString
                End If

                COD_C = txt_nro_req.Text
                dgw_mov1.Rows.Add(New Object() {ITEM.ToString("0000"), txt_cta_imp.Text, txt_glosa.Text, BI_SOL, BI_DOL, _
                    cbo_d_h.Text, MON0, txt_cambio.Text, COD_CC, COD_C, COD_P, ORDEN_BI, dtp_vence.Value, STATUS_PV, ENLACE, _
                    DESTINO, STATUS_CC, "1", STATUS_P, dtp_doc.Value, " ", "1", TXT_IGV0.Text, rep, COD_ACT})
                HALLAR_TOTAL_DOC()
                LIMPIAR_DETALLES()
                txt_cta_imp.Focus()
            End If
        End If
    End Sub

    Private Sub btn_mod_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod_det.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        LIMPIAR_DETALLES()
        txt_cta_imp.Enabled = False
        txt_desc_cta_imp.Enabled = False
        item0.Text = (dgw_mov1.Item(0, dgw_mov1.CurrentRow.Index).Value)
        CARGAR_DET1()
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        txt_bi.Focus()
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
        If OBJ.VERIFICAR_TRANSF_PRODUCCION(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Producción", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If OBJ.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ValidarFicha = False

        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = True
        g_cab.Enabled = False
        btn_grabar_com2.Enabled = True
        btn_imprimir.Enabled = False
        TabControl1.SelectedTab = TabPage3
        btn_nuevo_doc.Focus()
        ValidarFicha = True
    End Sub

    Private Sub btn_modificar_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar_doc.Click
        Try
            Dim I As Integer = dgw_doc_01.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        FILA_DOC = dgw_doc_01.CurrentRow.Index
        LIMPIAR_DOCUMENTOS()
        CARGAR_DOCUMENTO(FILA_DOC)
        If (OBJ.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False And (BOTON <> "NUEVO")) Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim CUENTA0 As String = VALIDAR_TRASNF_CUENTA(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text)
            If ((CUENTA0 <> "") And (BOTON <> "NUEVO")) Then
                MessageBox.Show(("No se puede modificar el Documento la Cuenta " & CUENTA0 & " se encuentra Transferida."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                panel1.Enabled = False
                Panel_DOC02.Visible = True
                btn_grabar_doc.Visible = False
                btn_grabar_doc2.Visible = True
                btn_nuevo_det.Focus()
            End If
        End If
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (txt_cta_imp.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_imp.Focus()
        Else
            If CBO_ORDEN.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
            If (txt_bi.Text.Trim = "") Then
                txt_bi.Text = "0.00"
            End If
            If (Decimal.Parse(txt_bi.Text) = 0) Then
                MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_bi.Focus()
            Else
                Dim BI_DOL As Decimal
                Dim BI_REAL As Decimal
                Dim BI_SOL As Decimal
                Dim BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA

                Dim rep As String = "0"
                If ch_rep.Checked Then
                    rep = "1"
                End If

                If (lbl_moneda_det.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 - Decimal.Parse(TXT_IGV0.Text)))), 3))
                Else
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = BI_TEMP
                End If
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio.Text))), 3))
                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio.Text))), 3))

                    Case "A"
                        BI_DOL = New Decimal
                        BI_SOL = BI_REAL
                End Select
                Dim ITEM As Integer = Integer.Parse(HALLAR_ITEM)
                ENLACE = ""
                DESTINO = ""
                If cbo_auto.Visible Then
                    ITEM = (ITEM + 2)
                End If
                DESTINO = Strings.Mid((cbo_auto.SelectedItem), 1, 8)
                ENLACE = Strings.Mid((cbo_auto.SelectedItem), 24, 31)
                COD_C = ""
                COD_P = ""
                COD_CC = ""
                COD_C = txt_nro_req.Text
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_P = OBJ.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (cbo_cc.SelectedIndex <> -1) Then
                    COD_CC = OBJ.COD_CC(cbo_cc.Text)
                End If
                COD_C = txt_nro_req.Text
                ORDEN_BI = CBO_ORDEN.Text
                dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value = txt_cta_imp.Text
                dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value = txt_glosa.Text
                dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value = BI_SOL
                dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value = BI_DOL
                dgw_mov1.Item(5, dgw_mov1.CurrentRow.Index).Value = cbo_d_h.Text
                dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value = MON0
                dgw_mov1.Item(7, dgw_mov1.CurrentRow.Index).Value = txt_cambio.Text
                dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value = COD_CC
                dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value = COD_C
                dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value = COD_P
                dgw_mov1.Item(11, dgw_mov1.CurrentRow.Index).Value = ORDEN_BI
                dgw_mov1.Item(12, dgw_mov1.CurrentRow.Index).Value = dtp_vence.Value
                dgw_mov1.Item(13, dgw_mov1.CurrentRow.Index).Value = STATUS_PV
                dgw_mov1.Item(14, dgw_mov1.CurrentRow.Index).Value = ENLACE
                dgw_mov1.Item(15, dgw_mov1.CurrentRow.Index).Value = DESTINO
                dgw_mov1.Item(16, dgw_mov1.CurrentRow.Index).Value = STATUS_CC
                dgw_mov1.Item(17, dgw_mov1.CurrentRow.Index).Value = "1"
                dgw_mov1.Item(18, dgw_mov1.CurrentRow.Index).Value = STATUS_P
                dgw_mov1.Item(19, dgw_mov1.CurrentRow.Index).Value = dtp_doc.Value
                dgw_mov1.Item(20, dgw_mov1.CurrentRow.Index).Value = " "
                dgw_mov1.Item(21, dgw_mov1.CurrentRow.Index).Value = "1"
                dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value = TXT_IGV0.Text
                dgw_mov1.Item(23, dgw_mov1.CurrentRow.Index).Value = rep
                dgw_mov1.Item(24, dgw_mov1.CurrentRow.Index).Value = COD_ACT
                item0.Text = ""
                btn_guardar.Visible = True
                btn_modificar2.Visible = False
                LIMPIAR_DETALLES()
                txt_cta_imp.Focus()
                HALLAR_TOTAL_DOC()
                Panel_det02.Visible = False
                btn_nuevo_det.Focus()
            End If
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        BOTON = "NUEVO"
        ValidarFicha = False
        TabControl1.SelectedTab = TabPage3
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
        Panel2.Enabled = True
        ValidarFicha = True
    End Sub

    Private Sub btn_nuevo_comp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_comp.Click
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
        Panel2.Enabled = True
    End Sub

    Private Sub btn_nuevo_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_det.Click
        If (cbo_tipo_doc.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc.Focus()
        ElseIf (txt_nro_doc.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc.Focus()
        ElseIf (dtp_doc.Value.Date > FECHA_GRAL.Date) Then
            MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_doc.Focus()
        ElseIf (txt_cod_per0.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
        ElseIf (cbo_moneda.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la MOneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda.Focus()
        Else
            If (txt_cambio.Text = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            Else
                panel1.Enabled = False
                COD_DOC = OBJ.COD_DOC(cbo_tipo_doc.Text)
                COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                If (COD_DH_DOC = "D") Then
                    COD_DH_DOC = "H"
                Else
                    COD_DH_DOC = "D"
                End If
                STATUS_PV = "0"
                LIMPIAR_DETALLES()
                Panel_det02.Visible = True
                txt_cta_imp.Focus()
            End If
        End If
    End Sub

    Private Sub btn_nuevo_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_doc.Click
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
        Else
            g_cab.Enabled = False
            LIMPIAR_DOCUMENTOS()
            Panel_DOC02.Visible = True
            cbo_tipo_doc.Focus()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(71) = 0
        Close()
    End Sub

    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim CONT0 As Integer = (dgw_per.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_per.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_per.Text.ToLower = Strings.Mid(dgw_per.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    dgw_per.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_per.Focus()
    End Sub

    Private Sub btn_sgt3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt3.Click
        Dim CONT0 As Integer = (dgw_cta_imp.RowCount - 1)
        Dim i As Integer = fila3
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_cta_imp.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_cta_imp.Text.ToLower = Strings.Mid(dgw_cta_imp.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cta_imp.Text)).ToLower) Then
                    dgw_cta_imp.CurrentCell = dgw_cta_imp.Rows.Item(i).Cells.Item(1)
                    fila3 = (i + 1)
                    dgw_cta_imp.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_cta_imp.Focus()
    End Sub

    Private Sub BTNAJUSTE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTNAJUSTE.Click
        If CONTAR_AJUSTE() = False Then
            MessageBox.Show("Ya existe un registro de AJUSTE", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            LIMPIAR_DETALLES()
            CH_IGV.Checked = False
            lbl_moneda_det.Text = "AJUSTE"
            Panel_det02.Visible = True
            txt_cta_imp.Focus()
        End If
    End Sub

    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        dgw_doc_01.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_REGISTRO_HONORARIOS", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            pro_02.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            pro_02.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_doc_01.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), _
                rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), _
                rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), _
                rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), _
                rs2.GetValue(19), rs2.GetValue(20), rs2.GetValue(21), rs2.GetValue(22), rs2.GetValue(23), _
                rs2.GetValue(24), rs2.GetValue(25), rs2.GetValue(26), rs2.GetValue(27), rs2.GetValue(28), _
                rs2.GetValue(29), rs2.GetValue(30), rs2.GetValue(31), rs2.GetValue(32), rs2.GetValue(33))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        dgw_det_01.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_COMPRAS", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            pro_02.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            pro_02.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_det_01.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), _
                rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), _
                rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), _
                rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), _
                rs2.GetValue(19), rs2.GetValue(20), rs2.GetValue(21), rs2.GetValue(22), rs2.GetValue(23), _
                rs2.GetValue(24), rs2.GetValue(25), rs2.GetValue(26), rs2.GetValue(27), rs2.GetValue(28), _
                rs2.GetValue(29), rs2.GetValue(30), rs2.GetValue(31), rs2.GetValue(32), rs2.GetValue(33), _
                rs2.GetValue(34), rs2.GetValue(35), rs2.GetValue(36), rs2.GetValue(37), rs2.GetValue(41), _
                rs2.GetValue(42))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGAR_DET1()
        txt_cta_imp.Text = (dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value)
        txt_desc_cta_imp.Text = OBJ.DESC_CUENTA(txt_cta_imp.Text, AÑO)
        CBO_AUTOMATICAS(txt_cta_imp.Text)
        ORDEN_BI = (dgw_mov1.Item(11, dgw_mov1.CurrentRow.Index).Value)
        CBO_ORDEN.Text = ORDEN_BI
        cbo_auto.Text = (String.Concat(String.Concat(dgw_mov1.Item(15, dgw_mov1.CurrentRow.Index).Value, "               "), dgw_mov1.Item(14, dgw_mov1.CurrentRow.Index).Value))
        Dim cod_dh As String = dgw_mov1.Item(5, dgw_mov1.CurrentRow.Index).Value.ToString
        cbo_d_h.Text = cod_dh
        lbl_moneda_det.Text = cbo_moneda.Text
        If (dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value.ToString = "A") Then
            lbl_moneda_det.Text = "AJUSTE"
            COD_MONEDA = "A"
        End If
        Dim igv As Decimal = Decimal.Parse(dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value.ToString)
        CH_IGV.Checked = False
        If (Decimal.Compare(igv, Decimal.One) = 0) Then
            CH_IGV.Checked = False
        End If

        Dim rep As String = dgw_mov1.Item(23, dgw_mov1.CurrentRow.Index).Value
        COD_ACT = dgw_mov1.Item(24, dgw_mov1.CurrentRow.Index).Value
        cbo_act01.SelectedValue = COD_ACT
        If (rep = "1") Then
            ch_rep.Checked = True
        End If
        txt_nro_req.Text = dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value

        If (STATUS_PV = "1") Then
            If (COD_MONEDA = "D") Then
                txt_bi.Text = (Math.Round(CDbl((Double.Parse((dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 3))
            Else
                txt_bi.Text = (Math.Round(CDbl((Double.Parse((dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 3))
            End If
        ElseIf (COD_MONEDA = "D") Then
            txt_bi.Text = (dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)
        Else
            txt_bi.Text = (dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)
        End If
        txt_bi.Text = (OBJ.HACER_DECIMAL(txt_bi.Text))
        txt_glosa.Text = (dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value)
        cbo_cc.Enabled = False
        cbo_cc.SelectedIndex = -1
        'cbo_control.SelectedIndex = -1
        cbo_proyecto.SelectedIndex = -1
        cbo_proyecto.Enabled = False
        STATUS_CC = (dgw_mov1.Item(16, dgw_mov1.CurrentRow.Index).Value)
        STATUS_P = (dgw_mov1.Item(18, dgw_mov1.CurrentRow.Index).Value)
        If (Decimal.Parse(STATUS_CC) = 1) Then
            cbo_cc.Enabled = True
            cbo_cc.Text = OBJ.DESC_CC((dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value))
        End If
        'cbo_control.Text = OBJ.DESC_CONTROL((dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value))
        If (Decimal.Parse(STATUS_P) = 1) Then
            cbo_proyecto.Enabled = True
            cbo_proyecto.Text = OBJ.DESC_PROYECTO((dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value))
        End If
        CH_IGV.Checked = False
        If dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value.ToString <> "0" Then
            CH_IGV.Checked = True
        End If
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        Panel_det02.Visible = True
    End Sub

    Sub CARGAR_DOCUMENTO(ByVal FILA_DOC0 As Integer)
        COD_DOC = (dgw_doc_01.Item(3, FILA_DOC0).Value)
        txt_nro_doc.Text = (dgw_doc_01.Item(4, FILA_DOC0).Value)
        txt_cod_per0.Text = (dgw_doc_01.Item(5, FILA_DOC0).Value)
        txt_desc_per.Text = (dgw_doc_01.Item(6, FILA_DOC0).Value)
        txt_doc_per.Text = (dgw_doc_01.Item(7, FILA_DOC0).Value)
        dtp_doc.Value = Date.Parse(dgw_doc_01.Item(9, FILA_DOC0).Value)
        COD_MONEDA = (dgw_doc_01.Item(20, FILA_DOC0).Value)
        cbo_tipo_doc.Text = OBJ.DESC_DOC(COD_DOC)
        If (txt_cod_per0.Text <> "00000") Then
            txt_desc_per.Text = OBJ.DESC_PERSONA(txt_cod_per0.Text)
        End If
        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
        txt_cambio.Text = dgw_doc_01.Item(21, FILA_DOC0).Value.ToString
        cbo_cte.SelectedIndex = 0
        If dgw_doc_01.Item(19, FILA_DOC0).Value.ToString = "0" Then
            cbo_cte.SelectedIndex = 1
        End If
        COD_DH_DOC = (dgw_doc_01.Item(23, FILA_DOC0).Value)
        dgw_mov1.Rows.Clear()
        Dim cont_r_4 As Integer = dgw_det_01.RowCount
        Dim CONT0 As Integer = (cont_r_4 - 1)
        Dim l As Integer = 0
        Do While (l <= CONT0)
            With dgw_det_01
                If .Item(20, l).Value = COD_DOC AndAlso .Item(21, l).Value = txt_nro_doc.Text AndAlso .Item(22, l).Value = txt_cod_per0.Text _
                AndAlso .Item(23, l).Value = txt_doc_per.Text AndAlso (.Item(25, l).Value = "B" OrElse .Item(25, l).Value = "I" OrElse _
                .Item(25, l).Value = "T") Then
                    Dim TIPO_T As Object = .Item(25, l).Value
                    If TIPO_T = "B" Then
                        dgw_mov1.Rows.Add(New Object() {.Item(0, l).Value, .Item(1, l).Value, .Item(2, l).Value, OBJ.HACER_DECIMAL(.Item(3, l).Value), _
                            OBJ.HACER_DECIMAL(dgw_det_01.Item(4, l).Value), .Item(5, l).Value, .Item(6, l).Value, .Item(7, l).Value, _
                            .Item(8, l).Value, .Item(9, l).Value, .Item(10, l).Value, .Item(11, l).Value, .Item(12, l).Value, .Item(13, l).Value, _
                            .Item(14, l).Value, .Item(15, l).Value, .Item(16, l).Value, .Item(17, l).Value, .Item(18, l).Value, .Item(19, l).Value, _
                            .Item(26, l).Value, .Item(27, l).Value, .Item(34, l).Value, .Item(38, l).Value, .Item(39, l).Value})
                    ElseIf TIPO_T = "I" Then
                        txt_cta_igv.Text = (dgw_det_01.Item(1, l).Value)
                        txt_igv.Text = (Double.Parse((dgw_det_01.Item(3, l).Value)))
                        If (COD_MONEDA = "D") Then
                            txt_igv.Text = (Double.Parse((dgw_det_01.Item(4, l).Value)))
                        End If
                        txt_igv.Text = (OBJ.HACER_DECIMAL(txt_igv.Text))
                        ORDEN_IGV = (dgw_det_01.Item(11, l).Value)
                        TXT_GLOSA_IGV.Text = dgw_det_01.Item(2, l).Value.ToString
                    ElseIf TIPO_T = "T" Then
                        txt_cta_total.Text = (dgw_det_01.Item(1, l).Value)
                        txt_total.Text = (Double.Parse((dgw_det_01.Item(3, l).Value)))
                        If (COD_MONEDA = "D") Then
                            txt_total.Text = (Double.Parse((dgw_det_01.Item(4, l).Value)))
                        End If
                        txt_total.Text = (OBJ.HACER_DECIMAL(txt_total.Text))
                        ORDEN_TOTAL = (dgw_det_01.Item(11, l).Value)
                        TXT_GLOSA_T.Text = dgw_det_01.Item(2, l).Value.ToString
                        dtp_vence.Value = Date.Parse(dgw_det_01.Item(12, l).Value)
                        Dim ST As String = (dgw_det_01.Item(13, l).Value)
                    End If
                End If
            End With

            l += 1
        Loop
        Try
            Dim A1 As Integer = dtp_doc.Value.Day
            Dim A2 As Integer = dtp_vence.Value.Day
            TXT_DIA1.Text = (CInt((A2 - A1)))
        Catch ex As Exception
            TXT_DIA1.Text = (0)
        End Try
        'HALLAR_TOTAL_DOC()
        txt_igv.Text = (OBJ.HACER_DECIMAL(txt_igv.Text))
        txt_total.Text = (OBJ.HACER_DECIMAL(txt_total.Text))
    End Sub

    Sub CBO_AUTOMATICAS(ByVal cod As Object)
        cbo_auto.Items.Clear()
        Try
            Dim PRO As New SqlCommand("CBO_AUTO_CUENTA", con)
            PRO.CommandType = CommandType.StoredProcedure
            PRO.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = (cod)
            PRO.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            con.Open()
            PRO.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PRO.ExecuteReader
            Do While Rs3.Read
                cbo_auto.Items.Add((Rs3.GetString(1) & "               " & Rs3.GetString(0)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (cbo_auto.Items.Count = 0) Then
            lbl_auto.Text = "No existen Automaticas"
            cbo_auto.Visible = False
        Else
            lbl_auto.Text = "Automaticas"
            cbo_auto.Visible = True
            cbo_auto.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
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

    Sub CBO_CONTROL0()
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

    Sub CBO_DOCUMENTO()
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

    Private Sub cbo_moneda_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda.SelectedIndexChanged
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub

    Sub CBO_MONEDA0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT
        cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
    End Sub

    Sub CBO_PROYECTO0()
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

    Private Sub CH_IGV_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_IGV.CheckedChanged
        If CH_IGV.Checked Then
            TXT_IGV0.Text = (OBJ.HACER_DECIMAL(IGV0))
        Else
            TXT_IGV0.Text = "0.00"
        End If
    End Sub

    Function CONTAR_AJUSTE() As Boolean
        Dim CONT0 As Integer = (dgw_mov1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            If (dgw_mov1.Item(6, i).Value.ToString = "A") Then
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function

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
        '----------
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
        DT_DET.Columns.Add("STATUS_REP")
        DT_DET.Columns.Add("COD_ACTIVIDAD")

    End Sub

    Sub DATAGRID()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ICON_HONORARIOS", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Cuentas")
            Prog02.Fill(dt_02)
            dgw1.DataSource = dt_02
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(2).Visible = False
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Sub DGW_CC0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        cbo_cc.DataSource = DT
        cbo_cc.DisplayMember = DT.Columns.Item(0).ToString
        cbo_cc.ValueMember = DT.Columns.Item(1).ToString
        cbo_cc.SelectedIndex = -1
    End Sub

    Private Sub dgw_cta_igv_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_igv.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_igv.Text = dgw_cta_igv.Item(0, dgw_cta_igv.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta_igv.Item(1, dgw_cta_igv.CurrentRow.Index).Value.ToString
            ORDEN_IGV = dgw_cta_igv.Item(4, dgw_cta_igv.CurrentRow.Index).Value.ToString
            TXT_GLOSA_IGV.Focus()
            dgw_cta_igv.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            dgw_cta_igv.Visible = False
            txt_cta_igv.Focus()
            txt_desc_cta.Clear()
            txt_cta_igv.Focus()
        End If
    End Sub

    Private Sub dgw_cta_imp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_imp.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_imp.Text = dgw_cta_imp.Item(0, dgw_cta_imp.CurrentRow.Index).Value.ToString
            txt_desc_cta_imp.Text = dgw_cta_imp.Item(1, dgw_cta_imp.CurrentRow.Index).Value.ToString
            STATUS_CC = dgw_cta_imp.Item(2, dgw_cta_imp.CurrentRow.Index).Value.ToString
            STATUS_P = dgw_cta_imp.Item(3, dgw_cta_imp.CurrentRow.Index).Value.ToString
            ORDEN_BI = dgw_cta_imp.Item(4, dgw_cta_imp.CurrentRow.Index).Value.ToString
            CBO_ORDEN.Text = ORDEN_BI
            txt_glosa.Text = txt_desc_cta_imp.Text
            cbo_cc.SelectedIndex = -1
            cbo_cc.Enabled = False
            cbo_proyecto.Enabled = False
            If (Decimal.Parse(STATUS_CC) = 1) Then
                cbo_cc.Enabled = True
            End If
            If (Decimal.Parse(STATUS_P) = 1) Then
                cbo_proyecto.Enabled = True
            End If
            CBO_AUTOMATICAS(txt_cta_imp.Text)
            kl2.Focus()
            Panel_cta_det.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta_det.Visible = False
            txt_cta_imp.Focus()
            txt_desc_cta_imp.Clear()
            txt_cta_imp.Focus()
        End If
    End Sub

    Private Sub dgw_cta_t_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_t.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_total.Text = dgw_cta_t.Item(0, dgw_cta_t.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta_t.Item(1, dgw_cta_t.CurrentRow.Index).Value.ToString
            ORDEN_TOTAL = dgw_cta_t.Item(4, dgw_cta_t.CurrentRow.Index).Value.ToString
            Panel4.Focus()
            dgw_cta_t.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            dgw_cta_t.Visible = False
            txt_cta_total.Focus()
            txt_desc_cta.Clear()
            txt_cta_total.Focus()
        End If
    End Sub

    Sub DGW_CUENTAS_CONFIG()
        Try
            dgw_cta_imp.DataSource = OBJ.MOSTRAR_CUENTAS_CONFIGURADAS("B", AÑO, "H")
            dgw_cta_imp.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_imp.Columns.Item(2).Visible = False
            dgw_cta_imp.Columns.Item(3).Visible = False
            dgw_cta_imp.Columns.Item(4).Visible = False
            dgw_cta_imp.Columns.Item(0).Width = 70
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_igv.DataSource = OBJ.MOSTRAR_CUENTAS_CONFIGURADAS("R", AÑO, "H")
            dgw_cta_igv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_igv.Columns.Item(2).Visible = False
            dgw_cta_igv.Columns.Item(3).Visible = False
            dgw_cta_igv.Columns.Item(4).Visible = False
            dgw_cta_igv.Columns.Item(0).Width = 70
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_t.DataSource = OBJ.MOSTRAR_CUENTAS_CONFIGURADAS("T", AÑO, "H")
            dgw_cta_t.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_t.Columns.Item(2).Visible = False
            dgw_cta_t.Columns.Item(3).Visible = False
            dgw_cta_t.Columns.Item(4).Visible = False
            dgw_cta_t.Columns.Item(0).Width = 70
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            TXT_GLOSA_IGV.Text = txt_desc_per.Text
            TXT_GLOSA_T.Text = txt_desc_per.Text
            TXT_KLP.Focus()
            Panel_per.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per.Visible = False
            txt_cod_per0.Focus()
            txt_cod_per0.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per0.Focus()
        End If
    End Sub

    Sub DGW_PERSONAS()
        Try
            dgw_per.DataSource = OBJ.MOSTRAR_PERSONAS_PAGAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception


            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    Private Sub dtp_doc_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_doc.LostFocus
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO2(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
        Try
            dtp_vence.Value = dtp_doc.Value.AddDays(Decimal.Parse(TXT_DIA1.Text))
        Catch ex As Exception


            dtp_vence.Value = dtp_doc.Value
            TXT_DIA1.Text = (0)

        End Try
    End Sub

    Sub ELIMINAR_DOCUMENTO_DGW(ByVal fila_doc0 As Integer)
        Dim cod_doc_05 As String = (dgw_doc_01.Item(3, fila_doc0).Value)
        Dim nro_doc_05 As String = (dgw_doc_01.Item(4, fila_doc0).Value)
        Dim cod_per_05 As String = (dgw_doc_01.Item(5, fila_doc0).Value)
        Dim nro_doc_per_05 As String = (dgw_doc_01.Item(7, fila_doc0).Value)
        dgw_doc_01.Rows.RemoveAt(fila_doc0)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_det_01.RowCount
        Do While (I < CONT)
            If dgw_det_01.Item(20, I).Value = cod_doc_05 AndAlso dgw_det_01.Item(21, I).Value = nro_doc_05 _
            AndAlso dgw_det_01.Item(22, I).Value = cod_per_05 AndAlso dgw_det_01.Item(23, I).Value = nro_doc_per_05 Then
                dgw_det_01.Rows.RemoveAt(I)
                I = 0
                CONT -= 1
            Else
                I += 1
            End If
        Loop
    End Sub

    Sub GENERAR_AUTO()
        Dim cont_r1 As Integer = dgw_det_01.RowCount
        Dim CONT0 As Integer = (cont_r1 - 1)
        Dim j As Integer = 0
        Do While (j <= CONT0)
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
                dgw_det_01.Rows.Add(New Object() {var0, var14, var2, var3, var4, cod_enlace, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", dtp_doc.Value, 0, " ", 0, 0, "0", "0", "0", ""})
                dgw_det_01.Rows.Add(New Object() {var0, var15, var2, var3, var4, cod_destino, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", dtp_doc.Value, 0, " ", 0, 0, "0", "0", "0", ""})
            End If
            j += 1
        Loop
    End Sub

    Function HALLAR_ITEM() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_mov1.Rows.Count - 1)
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            If dgw_mov1.Item(0, i).Value > mayor Then
                mayor = Integer.Parse(dgw_mov1.Item(0, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("00")
    End Function

    Function HALLAR_TOTAL_BI_DOC() As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim TOTAL_DOC As New Decimal
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim signo As Double = 1
            If (dgw_mov1.Item(5, I).Value.ToString = COD_DH_DOC) Then
                signo = -1
            End If
            If (COD_MONEDA = "S") Then
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, dgw_mov1.Item(3, I).Value)))
            Else
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, dgw_mov1.Item(4, I).Value)))
            End If
            I += 1
        Loop
        Return Decimal.Parse(OBJ.HACER_DECIMAL(TOTAL_DOC))
    End Function

    Sub HALLAR_TOTAL_DOC()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim TOTAL_REN As New Decimal
        Dim TOTAL_DOC As New Decimal
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim igv00 As Decimal = Decimal.Parse(dgw_mov1.Item(22, I).Value.ToString.ToString)
            Dim signo As Double = 1
            If (dgw_mov1.Item(5, I).Value.ToString = COD_DH_DOC) Then
                signo = -1
            End If
            If (COD_MONEDA = "S") Then
                TOTAL_REN = Decimal.Parse(Decimal.Add(TOTAL_REN, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(3, I).Value, igv00), 100))))
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, dgw_mov1.Item(3, I).Value)))
            Else
                TOTAL_REN = Decimal.Parse(Decimal.Add(TOTAL_REN, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(4, I).Value, igv00), 100))))
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, dgw_mov1.Item(4, I).Value)))
            End If
            I += 1
        Loop
        txt_igv.Text = (TOTAL_REN)
        txt_total.Text = (Decimal.Subtract(TOTAL_DOC, TOTAL_REN))
        txt_igv.Text = (OBJ.HACER_DECIMAL(txt_igv.Text))
        txt_total.Text = (OBJ.HACER_DECIMAL(txt_total.Text))
    End Sub

    Sub CBO_ACTIVIDAD()
        If OBJ.DIR_TABLA_DESC("COS", "TSIST") = "SI" Then
            Try
                Dim GEN As New Genericos
                Dim DT As New DataTable
                DT = GEN.CBO_ACTIVIDAD(con00)
                cbo_act01.DataSource = DT
                cbo_act01.DisplayMember = DT.Columns.Item(0).ToString
                cbo_act01.ValueMember = DT.Columns.Item(1).ToString
                cbo_act01.SelectedIndex = -1
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub INSERTAR_DOCUMENTO_DGW()
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
        Dim igv00 As Decimal = txt_igv.Text
        If COD_MONEDA = "S" Then
        Else
            igv00 = Math.Round(Decimal.Parse(txt_igv.Text * txt_cambio.Text), 2)
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
        If (cbo_cte.SelectedIndex = 0) Then
            cte_03 = "1"
        End If
        If (COD_MONEDA = "S") Then
            imp_s_igv = Math.Round(Decimal.Parse(txt_igv.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_total.Text), 2)
            imp_d_igv = Math.Round(Decimal.Parse(txt_igv.Text / txt_cambio.Text), 2)
            imp_d_t = Math.Round(Decimal.Parse(txt_total.Text / txt_cambio.Text), 2)
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
            imp_d_igv = Math.Round(Decimal.Parse(txt_igv.Text), 2)
            imp_d_t = Math.Round(Decimal.Parse(txt_total.Text), 2)
            imp_s_igv = Math.Round(Decimal.Parse(txt_igv.Text * txt_cambio.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_total.Text * txt_cambio.Text), 2)
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

        dgw_doc_01.Rows.Add(New Object() {COD_AUX, COD_COMP, txt_nro_comp.Text, COD_DOC, txt_nro_doc.Text, _
            txt_cod_per0.Text, txt_desc_per.Text, txt_doc_per.Text, dtp_com.Value, dtp_doc.Value, cant01, _
            cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10, COD_MONEDA, txt_cambio.Text, _
            cte_03, COD_DH_DOC, "", 0, dtp_doc.Value, "", "", dtp_doc.Value, dtp_doc.Value, "0", 0, imp_s_t})
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
            Dim var23 As String = (dgw_mov1.Item(23, j).Value)
            Dim var24 As String = (dgw_mov1.Item(24, j).Value)
            Dim imp_doc00 As New Decimal
            imp_doc00 = Decimal.Parse(var3)
            If (var6 <> "S") Then
                imp_doc00 = Decimal.Parse(var4)
            End If
            dgw_det_01.Rows.Add(New Object() {var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), _
                var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, var15, var16, var17, var18, var19, COD_DOC, _
                txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, "0", "B", var20, var21, "0", " ", " ", dtp_doc.Value, 0, _
                " ", var22, imp_doc00, "0", "0", var23, var24})
            j += 1
        Loop
        Dim DH_IGV As String = ""
        Dim DH_T As String = ""
        If (COD_DH_DOC = "D") Then
            DH_IGV = "D"
            DH_T = "D"
        ElseIf (COD_DH_DOC = "H") Then
            DH_IGV = "H"
            DH_T = "H"
        End If
        If (COD_MONEDA = "S") Then
            imp_igv00 = imp_s_igv
            imp_t00 = imp_s_t
        Else
            imp_igv00 = imp_d_igv
            imp_t00 = imp_d_t
        End If
        Dim CONT001 As Object() = New Object() {(CONT + 2).ToString("0000"), txt_cta_igv.Text, txt_desc_per.Text, Math.Round(imp_s_igv, 2), Math.Round(imp_d_igv, 2), DH_IGV, COD_MONEDA, txt_cambio.Text, " ", " ", " ", ORDEN_IGV, dtp_vence.Value, 0, " ", " ", " ", " ", " ", dtp_doc.Value, COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, 0, "I", "", "", "0", " ", " ", dtp_doc.Value, 0, " ", 0, imp_igv00, "0", "0"}
        dgw_det_01.Rows.Add(CONT001)
        CONT001 = New Object(38 - 1) {}
        CONT001(0) = (CONT + 3).ToString("0000")
        CONT001(1) = txt_cta_total.Text
        CONT001(2) = txt_desc_per.Text
        CONT001(3) = Math.Round(imp_s_t, 2)
        CONT001(4) = Math.Round(imp_d_t, 2)
        CONT001(5) = DH_T
        CONT001(6) = COD_MONEDA
        CONT001(7) = txt_cambio.Text
        CONT001(8) = " "
        CONT001(9) = " "
        CONT001(10) = " "
        CONT001(11) = ORDEN_TOTAL
        CONT001(12) = dtp_vence.Value
        CONT001(13) = 0
        CONT001(14) = " "
        CONT001(15) = " "
        CONT001(16) = " "
        CONT001(17) = " "
        CONT001(18) = " "
        CONT001(19) = dtp_doc.Value
        CONT001(20) = COD_DOC
        CONT001(21) = txt_nro_doc.Text
        CONT001(22) = txt_cod_per0.Text
        CONT001(23) = txt_doc_per.Text
        CONT001(24) = 0
        CONT001(25) = "T"
        CONT001(26) = ""
        CONT001(27) = ""
        CONT001(28) = "0"
        CONT001(29) = " "
        CONT001(30) = " "
        CONT001(31) = dtp_doc.Value
        CONT001(32) = 0
        CONT001(33) = " "
        CONT001(34) = 0
        CONT001(35) = imp_t00
        CONT001(36) = "0"
        CONT001(37) = "0"
        dgw_det_01.Rows.Add(CONT001)
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
                DT_DOC.Rows.Add(New Object() {AÑO, MES, .Item(3, I).Value, .Item(4, I).Value, .Item(5, I).Value, _
                    .Item(7, I).Value, COD_AUX, COD_COMP, txt_nro_comp.Text, dtp_com.Value, .Item(6, I).Value, _
                    DateTime.Parse(.Item(9, I).Value), "", "", DateTime.Parse(.Item(9, I).Value), Decimal.Parse(.Item(10, I).Value), _
                    Decimal.Parse(.Item(11, I).Value), Decimal.Parse(.Item(12, I).Value * -1), Decimal.Parse(.Item(13, I).Value), _
                    Decimal.Parse(.Item(14, I).Value), Decimal.Parse(.Item(15, I).Value), Decimal.Parse(.Item(16, I).Value), _
                    Decimal.Parse(.Item(17, I).Value), Decimal.Parse(.Item(18, I).Value), Decimal.Parse(.Item(19, I).Value), _
                    .Item(20, I).Value, Decimal.Parse(.Item(21, I).Value), .Item(23, I).Value, .Item(24, I).Value, _
                    .Item(25, I).Value, DateTime.Parse(.Item(26, I).Value), DateTime.Parse(.Item(30, I).Value), _
                    .Item(31, I).Value, .Item(32, I).Value, NOMBRE_PC, .Item(33, I).Value})
            End With
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.REGISTRO_HONORARIOS2"
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
            Dim CONT00 As Object() = New Object() {AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_det_01.Item(20, I).Value, _
                dgw_det_01.Item(21, I).Value, dgw_det_01.Item(22, I).Value, dgw_det_01.Item(23, I).Value, (I + 1).ToString("0000"), _
                DateTime.Parse(dgw_det_01.Item(19, I).Value), "", "", DateTime.Parse(dgw_det_01.Item(19, I).Value), _
                dgw_det_01.Item(2, I).Value, dgw_det_01.Item(1, I).Value, Decimal.Parse(dgw_det_01.Item(3, I).Value), _
                Decimal.Parse(dgw_det_01.Item(4, I).Value), dgw_det_01.Item(5, I).Value, dgw_det_01.Item(6, I).Value, _
                Decimal.Parse(dgw_det_01.Item(7, I).Value), dgw_det_01.Item(8, I).Value, dgw_det_01.Item(9, I).Value, _
                dgw_det_01.Item(10, I).Value, dgw_det_01.Item(11, I).Value, DateTime.Parse(dgw_det_01.Item(12, I).Value), _
                dgw_det_01.Item(13, I).Value, dgw_det_01.Item(14, I).Value, dgw_det_01.Item(15, I).Value, dgw_det_01.Item(24, I).Value, _
                dgw_det_01.Item(25, I).Value, dgw_det_01.Item(37, I).Value, dgw_det_01.Item(28, I).Value, dgw_det_01.Item(29, I).Value, _
                dgw_det_01.Item(30, I).Value, DateTime.Parse(dgw_det_01.Item(31, I).Value), dgw_det_01.Item(32, I).Value, _
                dgw_det_01.Item(33, I).Value, dgw_det_01.Item(36, I).Value, dtp_com.Value, Decimal.Parse(dgw_det_01.Item(34, I).Value), _
                NOMBRE_PC, dgw_det_01.Item(38, I).Value, dgw_det_01.Item(39, I).Value}
            DT_DET.Rows.Add(CONT00)
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
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_HONORARIOS", con)
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
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        Dim DESC0 As String = cbo_com.Text.ToString
        cbo_com.SelectedIndex = -1
        ch_mod2.Checked = False
        cbo_com.Text = DESC0
        dtp_com.Value = FECHA_GRAL
        dgw_doc_01.Rows.Clear()
        ESTADO_AUTO = "NO"
        btn_imprimir.Enabled = False
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = False
        dgw_doc_01.Rows.Clear()
        btn_grabar_com.Enabled = True
        dgw_det_01.Rows.Clear()
        Panel_DOC02.Visible = False
        Panel2.Enabled = True
        txt_cta_igv.Text = OBJ.DIR_TABLA_DESC("PHON_REN", "TDCTA")
        txt_cta_total.Text = OBJ.DIR_TABLA_DESC("PHON_TOT", "TDCTA")
        ORDEN_IGV = OBJ.HALLAR_ORDEN_CUENTA("R", AÑO, "H", txt_cta_igv.Text)
        ORDEN_TOTAL = OBJ.HALLAR_ORDEN_CUENTA("T", AÑO, "H", txt_cta_total.Text)
    End Sub

    Sub LIMPIAR_DETALLES()
        txt_cta_imp.Clear()
        cbo_auto.SelectedIndex = -1
        txt_desc_cta_imp.Clear()
        txt_bi.Clear()
        cbo_d_h.Text = "D"
        If (COD_DH_DOC = "D") Then
            cbo_d_h.Text = "H"
        End If
        txt_glosa.Clear()
        STATUS_PV = "0"
        cbo_cc.SelectedIndex = -1
        'cbo_control.SelectedIndex = -1
        cbo_proyecto.SelectedIndex = -1
        CH_IGV.Checked = True
        TXT_IGV0.Text = (OBJ.HACER_DECIMAL(IGV0))
        cbo_cc.Enabled = False
        cbo_proyecto.Enabled = True
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        Panel_cta_det.Visible = False
        lbl_moneda_det.Text = cbo_moneda.Text
        txt_cta_imp.Enabled = True
        txt_desc_cta_imp.Enabled = True
        txt_nro_req.Clear()
        cbo_act01.SelectedIndex = -1
        ch_rep.Checked = False
    End Sub

    Sub LIMPIAR_DOCUMENTOS()
        panel1.Enabled = True
        cbo_tipo_doc.SelectedIndex = -1
        txt_nro_doc.Clear()
        'dtp_doc.Value = Now.Date
        txt_cod_per0.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        cbo_moneda.SelectedIndex = -1
        txt_cambio.Clear()
        TXT_DIA1.Text = (0)
        dtp_vence.Value = Now.Date
        dgw_mov1.Rows.Clear()
        Panel_det02.Visible = False
        txt_cta_igv.Clear()
        txt_cta_total.Clear()
        txt_desc_cta.Clear()
        txt_igv.Text = "0.00"
        txt_total.Text = "0.00"
        TXT_GLOSA_IGV.Clear()
        TXT_GLOSA_T.Clear()
        txt_cta_igv.Text = OBJ.DIR_TABLA_DESC("PHON_REN", "TDCTA")
        txt_cta_total.Text = OBJ.DIR_TABLA_DESC("PHON_TOT", "TDCTA")
        Panel_per.Visible = False
        btn_grabar_doc.Visible = True
        btn_grabar_doc2.Visible = False
    End Sub

    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.Rows.Count - 1)
        DT_DOC.Rows.Clear()
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            DT_DOC.Rows.Add(New Object() {AÑO, MES, (dgw_doc_01.Item(3, I).Value), (dgw_doc_01.Item(4, I).Value), (dgw_doc_01.Item(5, I).Value), (dgw_doc_01.Item(7, I).Value), COD_AUX, COD_COMP, txt_nro_comp.Text, dtp_com.Value, (dgw_doc_01.Item(6, I).Value), DateTime.Parse((dgw_doc_01.Item(9, I).Value)), "", "", DateTime.Parse((dgw_doc_01.Item(9, I).Value)), Decimal.Parse((dgw_doc_01.Item(10, I).Value)), Decimal.Parse((dgw_doc_01.Item(11, I).Value)), Decimal.Parse((dgw_doc_01.Item(12, I).Value * -1)), Decimal.Parse((dgw_doc_01.Item(13, I).Value)), Decimal.Parse((dgw_doc_01.Item(14, I).Value)), Decimal.Parse((dgw_doc_01.Item(15, I).Value)), Decimal.Parse((dgw_doc_01.Item(16, I).Value)), Decimal.Parse((dgw_doc_01.Item(17, I).Value)), Decimal.Parse((dgw_doc_01.Item(18, I).Value)), Decimal.Parse((dgw_doc_01.Item(19, I).Value)), (dgw_doc_01.Item(20, I).Value), Decimal.Parse((dgw_doc_01.Item(21, I).Value)), (dgw_doc_01.Item(23, I).Value), (dgw_doc_01.Item(24, I).Value), (dgw_doc_01.Item(25, I).Value), DateTime.Parse((dgw_doc_01.Item(26, I).Value)), DateTime.Parse((dgw_doc_01.Item(30, I).Value)), (dgw_doc_01.Item(31, I).Value), (dgw_doc_01.Item(32, I).Value), NOMBRE_PC, (dgw_doc_01.Item(33, I).Value)})
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.REGISTRO_HONORARIOS2"
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
            Dim CONT00 As Object() = New Object() {AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "", "", DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC}
            DT_DET.Rows.Add(CONT00)
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
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_HONORARIOS", con)
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

    Sub CARGAR_CBO_ORDEN()
        CBO_ORDEN.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_ORDEN00", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "H"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_ORDEN.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_req_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_req.Click
        boton30()
    End Sub
    Sub boton30()
        ofr.con0 = con00
        ofr._fecha = dtp_doc.Value
        ofr.CARGAR_ORD_PROD()
        ofr.ShowDialog()
        If ofr.DialogResult = Windows.Forms.DialogResult.OK Then
            txt_nro_req.Text = ofr.DGW_CAB.Item(0, ofr.DGW_CAB.CurrentRow.Index).Value.ToString
            Try
                COD_ACT = ofr.DGW_DET.Item(0, ofr.DGW_DET.CurrentRow.Index).Value.ToString
                cbo_act01.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
            Catch ex As Exception
                COD_ACT = ""
            End Try
            ofr.Hide()
        End If
    End Sub

    Private Sub PROV_HONORARIOS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub PROV_HONORARIOS_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub

    Private Sub PROV_COMPRAS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PROV_COMPRAS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_CBO_ORDEN()
        DATAGRID()
        CREAR_DATASET()
        CBO_AUXILIAR()
        CBO_ACTIVIDAD()
        CBO_DOCUMENTO()
        DGW_PERSONAS()
        CBO_MONEDA0()
        DGW_CUENTAS_CONFIG()
        IGV0 = Decimal.Parse(OBJ.IMPUESTO("REN"))
        TXT_IGV0.Text = IGV0
        DGW_CC0()
        CBO_CONTROL0()
        CBO_PROYECTO0()
        dgw_doc_01.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
    End Sub

    Private Sub txt_bi_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_bi.KeyPress
        e.Handled = Numero(e, txt_bi)
    End Sub

    Private Sub txt_bi_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_bi.LostFocus
        Try
            txt_bi.Text = OBJ.HACER_DECIMAL(txt_bi.Text)
        Catch ex As Exception
            txt_bi.Text = "0.00"
        End Try
    End Sub

    Private Sub txt_cambio_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio.KeyPress
        e.Handled = Numero(e, txt_cambio)
    End Sub

    Private Sub txt_cambio_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio.LostFocus
        Try
            txt_cambio.Text = OBJ.HACER_CAMBIO(txt_cambio.Text)
        Catch ex As Exception
            txt_cambio.Text = "0.0000"
        End Try
    End Sub

    Private Sub TXT_COD_PER_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per0.LostFocus
        If (Strings.Trim(txt_cod_per0.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_per0.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per0.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        TXT_GLOSA_IGV.Text = txt_desc_per.Text
                        TXT_GLOSA_T.Text = txt_desc_per.Text
                        cbo_moneda.Focus()
                        Return
                    End If
                    If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cta_igv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_igv.Click
        If (txt_cta_igv.Text.Trim <> "") Then
            txt_desc_cta.Text = OBJ.DESC_CUENTA(txt_cta_igv.Text, AÑO)
        End If
    End Sub

    Private Sub txt_cta_igv_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_igv.LostFocus
        If (dgw_cta_igv.RowCount = 0) Then
            MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cta_igv.Sort(dgw_cta_igv.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim CONT0 As Integer = (dgw_cta_igv.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= CONT0)
                If (txt_cta_igv.Text.ToLower = dgw_cta_igv.Item(0, i).Value.ToString.ToLower) Then
                    txt_cta_igv.Text = dgw_cta_igv.Item(0, i).Value.ToString
                    txt_desc_cta.Text = dgw_cta_igv.Item(1, i).Value.ToString
                    ORDEN_IGV = dgw_cta_igv.Item(4, i).Value.ToString
                    txt_cta_total.Focus()
                    Return
                End If
                If (txt_cta_igv.Text.ToLower = Strings.Mid((dgw_cta_igv.Item(0, i).Value), 1, Strings.Len(txt_cta_igv.Text)).ToLower) Then
                    dgw_cta_igv.CurrentCell = dgw_cta_igv.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                dgw_cta_igv.CurrentCell = dgw_cta_igv.Rows.Item(0).Cells.Item(0)
                i += 1
            Loop
            dgw_cta_igv.Visible = True
            dgw_cta_igv.Focus()
        End If
    End Sub

    Private Sub TXT_cta_imp_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_imp.LostFocus
        If (Strings.Trim(txt_cta_imp.Text) <> "") Then
            If (dgw_cta_imp.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_imp.Sort(dgw_cta_imp.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta_imp.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cta_imp.Text.ToLower = dgw_cta_imp.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta_imp.Text = dgw_cta_imp.Item(0, i).Value.ToString
                        txt_desc_cta_imp.Text = dgw_cta_imp.Item(1, i).Value.ToString
                        STATUS_CC = dgw_cta_imp.Item(2, i).Value.ToString
                        STATUS_P = dgw_cta_imp.Item(3, i).Value.ToString
                        ORDEN_BI = dgw_cta_imp.Item(4, i).Value.ToString
                        CBO_ORDEN.Text = ORDEN_BI
                        txt_glosa.Text = txt_desc_cta_imp.Text
                        cbo_cc.Enabled = False
                        cbo_proyecto.Enabled = False
                        If (Decimal.Parse(STATUS_CC) = 1) Then
                            cbo_cc.Enabled = True
                        End If
                        If (Decimal.Parse(STATUS_P) = 1) Then
                            cbo_proyecto.Enabled = True
                        End If
                        CBO_AUTOMATICAS(txt_cta_imp.Text)
                        SendKeys.Send("{Tab}")
                        Return
                    End If
                    If (txt_cta_imp.Text.ToLower = Strings.Mid((dgw_cta_imp.Item(0, i).Value), 1, Strings.Len(txt_cta_imp.Text)).ToLower) Then
                        dgw_cta_imp.CurrentCell = dgw_cta_imp.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_imp.CurrentCell = dgw_cta_imp.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta_det.Visible = True
                dgw_cta_imp.Visible = True
                dgw_cta_imp.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cta_total_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_total.Click
        If (txt_cta_total.Text.Trim <> "") Then
            txt_desc_cta.Text = OBJ.DESC_CUENTA(txt_cta_total.Text, AÑO)
        End If
    End Sub

    Private Sub txt_cta_total_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_total.LostFocus
        If (dgw_cta_t.RowCount = 0) Then
            MessageBox.Show("No existen Cuentas.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cta_t.Sort(dgw_cta_t.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim CONT0 As Integer = (dgw_cta_t.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= CONT0)
                If (txt_cta_total.Text.ToLower = dgw_cta_t.Item(0, i).Value.ToString.ToLower) Then
                    txt_cta_total.Text = dgw_cta_t.Item(0, i).Value.ToString
                    txt_desc_cta.Text = dgw_cta_t.Item(1, i).Value.ToString
                    ORDEN_TOTAL = dgw_cta_t.Item(4, i).Value.ToString
                    Panel4.Focus()
                    Return
                End If
                If (txt_cta_total.Text.ToLower = Strings.Mid((dgw_cta_t.Item(0, i).Value), 1, Strings.Len(txt_cta_total.Text)).ToLower) Then
                    dgw_cta_t.CurrentCell = dgw_cta_t.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                dgw_cta_t.CurrentCell = dgw_cta_t.Rows.Item(0).Cells.Item(0)
                i += 1
            Loop
            dgw_cta_t.Visible = True
            dgw_cta_t.Focus()
        End If
    End Sub

    Private Sub TXT_DESC_cta_imp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta_imp.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_imp.Text) <> "")) Then
            If (dgw_cta_imp.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_imp.Sort(dgw_cta_imp.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta_imp.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    'If (txt_desc_cta_imp.Text.ToLower = dgw_cta_imp.Item(1, i).Value.ToString.ToLower) Then
                    If (txt_desc_cta_imp.Text.ToLower = Strings.Mid((dgw_cta_imp.Item(1, i).Value), 1, Strings.Len(txt_desc_cta_imp.Text)).ToLower) Then
                        dgw_cta_imp.CurrentCell = dgw_cta_imp.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_imp.CurrentCell = dgw_cta_imp.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta_det.Visible = True
                dgw_cta_imp.Visible = True
                dgw_cta_imp.Focus()
            End If
        End If
    End Sub

    Private Sub TXT_DESC_PER_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub

    Private Sub TXT_DIA1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_DIA1.TextChanged
        Try
            dtp_vence.Value = dtp_doc.Value.AddDays(Decimal.Parse(TXT_DIA1.Text))
        Catch ex As Exception


            dtp_vence.Value = dtp_doc.Value
            TXT_DIA1.Text = (0)

        End Try
    End Sub

    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub

    Private Sub txt_igv_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_igv.KeyPress
        e.Handled = Numero(e, txt_igv)
    End Sub

    Private Sub txt_igv_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_igv.LostFocus
        'Try
        '    txt_igv.Text = (OBJ.HACER_DECIMAL(txt_igv.Text))
        'Catch ex As Exception
        '    HALLAR_TOTAL_DOC()
        'End Try
        Try
            txt_igv.Text = (OBJ.HACER_DECIMAL(txt_igv.Text))
            txt_total.Text = HALLAR_TOTAL_BI_DOC() - txt_igv.Text
            txt_total.Text = OBJ.HACER_DECIMAL(txt_total.Text)
        Catch ex As Exception
            HALLAR_TOTAL_DOC()
        End Try
    End Sub

    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_total.KeyPress
        e.Handled = Numero(e, txt_total)
    End Sub

    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total.LostFocus
        Try
            txt_total.Text = (OBJ.HACER_DECIMAL(txt_total.Text))
        Catch ex As Exception


            HALLAR_TOTAL_DOC()

        End Try
    End Sub

    Function VALIDAR_TRASNF_CUENTA(ByVal cod_doc As String, ByVal nro_doc As String, ByVal cod_per As String, ByVal doc_per As String) As String
        Dim i As Integer = 0
        Dim CUENTA As String = ""
        Dim CONT0 As Integer = (dgw_det_01.RowCount - 1)
        i = 0
        Do While (i <= CONT0)
            If (((((cod_doc = dgw_det_01.Item(20, i).Value.ToString) And (nro_doc = dgw_det_01.Item(21, i).Value.ToString)) And (cod_per = dgw_det_01.Item(22, i).Value.ToString)) And (doc_per = dgw_det_01.Item(23, i).Value.ToString)) And (dgw_det_01.Item(29, i).Value.ToString = "1")) Then
                CUENTA = dgw_det_01.Item(1, i).Value.ToString
            End If
            i += 1
        Loop
        Return CUENTA
    End Function

    Function VERIFICAR_DATAGRID_DOC(ByVal cod_per05 As String, ByVal nro_doc_per05 As String, ByVal cod_doc05 As String, ByVal nro_doc05 As String) As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim cod_doc04 As String = dgw_doc_01.Item(3, I).Value.ToString
            Dim nro_doc04 As String = dgw_doc_01.Item(4, I).Value.ToString
            Dim cod_per04 As String = dgw_doc_01.Item(5, I).Value.ToString
            Dim nro_doc_per04 As String = dgw_doc_01.Item(6, I).Value.ToString
            If ((((cod_doc04 = cod_doc05) And (cod_per04 = cod_per05)) And (nro_doc04 = nro_doc05)) And (nro_doc_per04 = nro_doc_per05)) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function

    Sub HALLAR_DES_NRO_ORDEN()
        desc_orden.Text = ""
        Dim nro_or As String = ""
        If CBO_ORDEN.SelectedIndex <> -1 Then
            nro_or = CBO_ORDEN.Text
        End If
        Try
            Dim PROG_01 As New SqlCommand("DESCRIPCION_CBO_ORDEN00", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "H"
            PROG_01.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = nro_or
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                If CBO_ORDEN.SelectedIndex <> -1 Then
                    desc_orden.Text = "Desc. : " & "  " & Rs3.GetString(0)
                End If

            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CBO_ORDEN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBO_ORDEN.SelectedIndexChanged
        HALLAR_DES_NRO_ORDEN()
    End Sub

    Private Sub ch_mod2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_mod2.CheckedChanged
        If ch_mod2.Checked = True Then
            txt_igv.ReadOnly = False
        Else
            txt_igv.ReadOnly = True
        End If
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw_det_01.Rows.Count - 1
        Dim IMPORTE As Decimal
        Dim IMPORTE_DEBE, IMPORTE_HABER As Decimal
        For I = 0 To cont
            If dgw_det_01.Item(25, I).Value = "T" Or dgw_det_01.Item(25, I).Value = "I" Or dgw_det_01.Item(25, I).Value = "B" Then
                If dgw_det_01.Item(6, I).Value = "S" Then
                    IMPORTE = OBJ.HACER_DECIMAL(dgw_det_01.Item(3, I).Value / dgw_det_01.Item(7, I).Value)
                ElseIf dgw_det_01.Item(6, I).Value = "D" Then
                    IMPORTE = dgw_det_01.Item(4, I).Value
                End If
                If dgw_det_01.Item(5, I).Value = "D" Then
                    IMPORTE_DEBE = dgw_det_01.Item(3, I).Value : IMPORTE_HABER = "0.00"
                ElseIf dgw_det_01.Item(5, I).Value = "H" Then
                    IMPORTE_DEBE = "0.00" : IMPORTE_HABER = dgw_det_01.Item(3, I).Value
                End If
                Dim COD_REPOR As String
                COD_REPOR = OBJ.DESC_USUARIO_COMPROBANTE(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES)
                dt.DataTable1.Rows.Add(dgw_det_01.Item(19, I).Value.ToString.Substring(0, 10), _
                dgw_det_01.Item(21, I).Value, dgw_det_01.Item(20, I).Value, _
                dgw_det_01.Item(22, I).Value, dgw_det_01.Item(8, I).Value, _
                dgw_det_01.Item(1, I).Value, dgw_det_01.Item(2, I).Value, _
                dgw_det_01.Item(6, I).Value, dgw_det_01.Item(7, I).Value, _
                IMPORTE, IMPORTE_DEBE, IMPORTE_HABER, dgw_det_01.Item(5, I).Value, _
                dgw_det_01.Item(37, I).Value, txt_nro_comp.Text, COD_REPOR, _
                dgw_det_01.Item(2, I).Value, cbo_com.Text, dgw_det_01.Item(10, I).Value, _
                dgw_det_01.Item(11, I).Value)
            End If
        Next
        If chkContinuo.Checked Then
            ReporteImprimir(dt, reporte, cbo_aux.Text)
        Else
            ReporteImprimir(dt, reporte1, cbo_aux.Text)
        End If
        'reporte.SetDataSource(dt)
        'Dim Params As New ParameterValues
        'Dim Par As New ParameterDiscreteValue
        ''======================================================================================
        'Params.Clear()
        'Par.Value = OBJ.DESC_MES(MES)
        'Params.Add(Par)
        'reporte.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = AÑO
        'Params.Add(Par)
        'reporte.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = DESC_EMPRESA
        'Params.Add(Par)
        'reporte.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = RUC_EMPRESA
        'Params.Add(Par)
        'reporte.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = cbo_aux.Text
        'Params.Add(Par)
        'reporte.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)

        'reporte.PrintOptions.PaperSize = DirectCast(OBJ.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        'reporte.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage3.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnConsultaSunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaSunat.Click
        Dim frm As frmConsultaRuc = frmConsultaRuc.ObtenerInstancia
        'frm.MdiParent = Me
        frm.Cargar_Datos(txt_doc_per.Text, BOTON, "consulta")
        frm.btnConsultar.Focus()
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
        End If
        frm.Close()
    End Sub
End Class