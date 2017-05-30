Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class PROV_COMPRAS
    Dim COD_AUX, COD_COMP, COD_DOC, COD_DH_DOC, COD_MONEDA, COD_C, COD_CC, COD_P, BOTON, STATUS_CC, STATUS_P, STATUS_PV, TIPO_DET, ST_PLA, ORDEN_BI, ORDEN_IGV, ORDEN_TOTAL, MSN_SALDO, ESTADO_AUTO, ENLACE, DESTINO, COD_ACT, ST_PAGO, STATUS_GASTO, COD_REF00 As String
    Dim con00 As New SqlConnection(("data source=" & nombre_servidor & ";initial catalog=BD_COS" & COD_EMPRESA & ";uid=miguel;pwd=main;"))
    Dim DESCUADRE As New Descuadre_de_Importes
    Dim DT_DET As New DataTable
    Dim DT_DOC As New DataTable
    Dim FILA_DOC, fila2, fila3, INDICE As Integer
    Dim IGV0 As Decimal
    Dim obj As New Class1
    Dim ofr As New CONSULTA_REQ_ORD_PROD
    Dim reporte As New CrystalReport1
    Dim reporte1 As New CrystalComprobante

    Private ValidarFicha As Boolean = True
    Private ConfigDoc As String
    Private CodigoClasificacionBienes As String
    Dim CodigoConvenio As String = String.Empty ', TipoRenta, CodigoMonedaOrigen As String
    Dim TipoRenta As String = String.Empty
    Dim CodigoMonedaOrigen As String = String.Empty
    Private Sub CargarMonedas()
        Dim Gen As New Genericos
        Dim dt As New DataTable
        dt = Gen.CBO_MONEDAS
        cboMonedaOrigen.DataSource = dt
        cboMonedaOrigen.DisplayMember = dt.Columns.Item(0).ToString
        cboMonedaOrigen.ValueMember = dt.Columns.Item(1).ToString
        cboMonedaOrigen.SelectedIndex = -1

        cboMonedaOrigenxNDocumentos.DataSource = dt
        cboMonedaOrigenxNDocumentos.DisplayMember = dt.Columns.Item(0).ToString
        cboMonedaOrigenxNDocumentos.ValueMember = dt.Columns.Item(1).ToString
        cboMonedaOrigenxNDocumentos.SelectedIndex = -1
    End Sub

    Sub ReporteImprimir(ByVal oDatos As Object, ByVal oReporte As Object, ByVal oAuxiliar As String)
        oReporte.SetDataSource(oDatos)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = obj.DESC_MES(MES)
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
            oReporte.PrintOptions.PaperSize = DirectCast(obj.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        Else
            oReporte.PrintOptions.PaperSize = DirectCast(obj.TamañoPapel("IMPRESION1"), CrystalDecisions.Shared.PaperSize)
        End If
        oReporte.PrintToPrinter(1, False, 0, 0)

        'oReporte.PrintOptions.PaperSize = DirectCast(obj.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        'oReporte.PrintToPrinter(1, False, 0, 0)
    End Sub

    Sub MostrarIgv(ByVal dtp As DateTimePicker)
        If dtp.Value.Year.ToString("0000") & dtp.Value.Month.ToString("00") <= "201102" Then
            IGV0 = "19.00"
            'TXT_IGV2.Text = "19.00"
            'txt_igv.Text = "19.00"
        Else
            IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
            'TXT_IGV2.Text = (IGV0)
            'txt_igv.Text = (IGV0)
        End If
    End Sub
    Sub boton3()
        ofr.con0 = con00
        ofr._fecha = dtp_doc01.Value
        ofr.CARGAR_ORD_PROD()
        ofr.ShowDialog()
        If ofr.DialogResult = Windows.Forms.DialogResult.OK Then
            txt_nro_req.Text = ofr.DGW_CAB.Item(0, ofr.DGW_CAB.CurrentRow.Index).Value.ToString
            Try
                COD_ACT = ofr.DGW_DET.Item(0, ofr.DGW_DET.CurrentRow.Index).Value.ToString
                cbo_act01.Text = obj.DESC_ACTIVIDAD(COD_ACT, con00)
            Catch ex As Exception
                COD_ACT = ""
            End Try
            ofr.Hide()
        End If
    End Sub
    Private Sub btn_act_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_act.Click
        DGW_PERSONAS()
    End Sub
    Private Sub btn_act_cta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_act_cta.Click
        DGW_CUENTAS_CONFIG()
    End Sub
    Private Sub btn_ajuste_01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ajuste_01.Click
        If CONTAR_AJUSTE01() = False Then
            MessageBox.Show("Ya existe un registro de AJUSTE", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            LIMPIAR_DETALLES01()
            ch_igv01.Checked = False
            lbl_moneda01.Text = "AJUSTE"
            Panel_det01.Visible = True
            txt_cod_cuenta01.Focus()
        End If
    End Sub
    Private Sub btn_base_ref_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_base_ref.Click
        If (Strings.Trim(txt_base_ref.Text) = "") Then
            MessageBox.Show("La base referencial es incorrecta")
        Else
            Try
                Dim k As Decimal = Decimal.Parse(txt_base_ref.Text)
            Catch ex As Exception
                MessageBox.Show("La base referencial es incorrecta")
                txt_base_ref.Text = (CDbl(0))
                Return
            End Try
            dgw_doc_01.Item(32, FILA_DOC).Value = Decimal.Parse(txt_base_ref.Text)
            Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
        End If
    End Sub
    Private Sub btn_cad_cta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cad_cta.Click
        btn_sgt_cta.Enabled = True
        Dim CONT0 As Integer = (dgw_cta01.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_cta01.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_cuenta01.Text.ToLower = Strings.Mid(dgw_cta01.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cuenta01.Text)).ToLower) Then
                    dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(i).Cells.Item(1)
                    fila3 = (i + 1)
                    dgw_cta01.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        dgw_cta01.Focus()
    End Sub
    Private Sub btn_cad_per_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cad_per.Click
        btn_sgt_per.Enabled = True
        Dim CONT0 As Integer = dgw_per01.RowCount - 1
        Dim i As Integer = 0
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_per01.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_per01.Text.ToLower = Strings.Mid(dgw_per01.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per01.Text)).ToLower) Then
                    dgw_per01.CurrentCell = dgw_per01.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    dgw_per01.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        dgw_per01.Focus()
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
        TXT_GLOSA_IGV.Focus()
        If (BOTON = "NUEVO") Then
            If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                cbo_orden_igv.Text = ConfigDoc.Substring(2, 2)
            End If
        End If
    End Sub
    Private Sub btn_cancelar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_com.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
        Panel2.Enabled = True
    End Sub
    Private Sub btn_cancelar_det01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_det01.Click
        Panel_det01.Visible = False
        txt_glosa_igv01.Focus()
        If (BOTON = "NUEVO") Then
            If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                cBO_orden_igv01.Text = ConfigDoc.Substring(2, 2)
            End If
        End If
    End Sub
    Private Sub btn_cancelar_doc2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_doc2.Click
        Panel_DOC02.Visible = False
        btn_nuevo_doc.Focus()
    End Sub
    Private Sub btn_cancelar01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar01.Click
        TabControl1.SelectedTab = TabPage1
        ch_pago2.Checked = False
        Panel201.Enabled = True
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consultar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        BOTON = "CONSULTA"
        LIMPIAR_COMPROBANTE01()
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = True
        btn_grabar_com01.Visible = True
        btn_grabar_com012.Visible = True
        g_cab.Enabled = False
        btn_grabar_com2.Enabled = True
        g_cab01.Enabled = False
        btn_grabar_com012.Enabled = True
        btn_imprimir.Enabled = False
        btn_imprimir01.Enabled = False

        ValidarFicha = False
        If (dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString = "x Doc.") Then
            '-
            'If (dgw_doc_01.Item(35, 0).Value = "1") Then
            '    cboClasificacionBienesxDocumento.SelectedIndex = 0
            'ElseIf (dgw_doc_01.Item(35, 0).Value = "2") Then
            '    cboClasificacionBienesxDocumento.SelectedIndex = 1
            'ElseIf (dgw_doc_01.Item(35, 0).Value = "3") Then
            '    cboClasificacionBienesxDocumento.SelectedIndex = 2
            'ElseIf (dgw_doc_01.Item(35, 0).Value = "4") Then
            '    cboClasificacionBienesxDocumento.SelectedIndex = 3
            'ElseIf (dgw_doc_01.Item(35, 0).Value = "5") Then
            '    cboClasificacionBienesxDocumento.SelectedIndex = 4
            'End If
            'cboClasificacionBienesxDocumento.Enabled = False
            ValidarCodigoBienes(dgw_doc_01.Item(35, 0).Value, cboClasificacionBienesxDocumento)
            '-
            If CARGAR_DOC01_CONSULTA() = False Then Exit Sub
            TabControl1.SelectedTab = TabPage2
            panel01.Enabled = False
            btn_nuevo_det01.Focus()
            Panel201.Enabled = False
            btn_nuevo_comp01.Enabled = False
            btn_grabar_com01.Enabled = False
            btn_grabar_com012.Enabled = False
            panel01.Enabled = False
            btn_imprimir01.Enabled = True
            btn_imprimir01.Focus()
        Else
            TabControl1.SelectedTab = TabPage3
            btn_imprimir.Enabled = True
            Panel2.Enabled = False
            btn_grabar_com.Enabled = False
            btn_grabar_com2.Enabled = False
            btn_imprimir.Focus()
        End If
        hallar_total()

        ValidarFicha = True
    End Sub
    Private Sub btn_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_det.Click
        If ((Strings.Trim(txt_cod_det.Text) = "") Or (Strings.Trim(txt_tasa_det.Text) = "")) Then
            MessageBox.Show("Inserte los datos", "Faltan datos", MessageBoxButtons.OK)
        Else
            dgw_doc_01.Item(24, FILA_DOC).Value = txt_cod_det.Text
            dgw_doc_01.Item(25, FILA_DOC).Value = txt_tasa_det.Text
            dgw_doc_01.Item(26, FILA_DOC).Value = dtp_det.Value.Date
            MessageBox.Show("Los datos de detracción se guardaron", "Exito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub btn_elim_det01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_elim_det01.Click
        Try
            Dim i As Integer = dgw_mov01.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el detalle", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            dgw_mov01.Rows.RemoveAt(dgw_mov01.CurrentRow.Index)
            HALLAR_TOTAL_DOC01()
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
            ST_PLA = (dgw1.Item(7, dgw1.CurrentRow.Index).Value)
            txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
            If obj.VERIFICAR_TRANSF_PRODUCCION(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Producción", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If VALIDAR_ELIMINAR() = False And ST_PLA = "0" Then
                MessageBox.Show("Ya se han cancelado los documentos del Comprobante", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim ESTADO As String = "FALLO"
                Try
                    Dim comand1 As New SqlCommand("ELIMINAR_I_CON_COMPRAS", con)
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
                    ESTADO = comand1.ExecuteScalar
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    ESTADO = "FALLO"
                End Try
                DATAGRID()
            End If
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
        If obj.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, NRO_DOC0, COD_PER0, DOC_PER0, CUENTA0) = False And BOTON <> "NUEVO" And ST_PLA = "0" Then
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
    Private Sub btn_g10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_g10.Click, btn_g40.Click
        Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
    End Sub
    Private Sub btn_g20_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_g20.Click
        Dim cod_doc007 As String = obj.COD_DOC(cbo_tipo_doc01.Text.ToString)
        'If (cod_doc007 = "07" Or cod_doc007 = "08") Then
        If ((cbo_ref0.SelectedIndex = -1) Or (Strings.Trim(txt_nro_ref0.Text) = "")) Then
            MessageBox.Show("Inserte los datos", "Faltan Datos", MessageBoxButtons.OK)
        Else
            Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
        End If
        'Else
        'MessageBox.Show("El Documento no posee Referencia", "No es Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub
    Private Sub btn_g30_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_g30.Click
        ST_PAGO = "1"
        Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
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
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_doc_01.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_doc.Focus()
        Else
            If (ESTADO_AUTO <> "SI") Then
                GENERAR_AUTO()
            End If
            ESTADO_AUTO = "SI"

            txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)

            If (INSERTAR_TODO() = "EXITO") Then
                txt_nro_comp.Text = obj.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                Panel2.Enabled = False
                btn_grabar_com.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
                Panel2.Enabled = False
            Else
                obj.ELIMINAR_TEMPORAL("PCOMP")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            End If
    End Sub
    Private Sub btn_grabar_com01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com01.Click
        If (dgw_mov01.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det01.Focus()
        ElseIf ((txt_cta_igv01.Text.Trim = "") And (Decimal.Parse(txt_imp_igv01.Text) <> 0)) Then
            MessageBox.Show("Debe elegir la Cuenta de Igv", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_igv01.Focus()
        ElseIf (txt_cta_t01.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_t01.Focus()
        ElseIf (Decimal.Parse(txt_imp_total01.Text) <= 0) Then
            MessageBox.Show("No existe Importe Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_imp_total01.Text) <> Convert.ToDouble(New Decimal((Decimal.Parse(txt_imp_igv01.Text) + Convert.ToDouble(HALLAR_TOTAL_BI_DOC01))))) Then
            MessageBox.Show("Documento con descuadre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        ElseIf ((ORDEN_IGV = "") Or (ORDEN_TOTAL = "")) Then
            MessageBox.Show("No existen Nº de Orden en la cuenta de IGV o Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf VERIFICAR_DATAGRID_DOC(txt_cod_per01.Text, txt_doc_per01.Text, COD_DOC, txt_nro_doc01.Text) = False Then
            MessageBox.Show("Ya guardo el documento.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            COD_MONEDA = cbo_moneda01.SelectedValue.ToString
            If VERIFICAR_SOLES01() = False Then Exit Sub
            If (BOTON = "NUEVO") Then
                If obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text, txt_cta_t01.Text) = False Then
                    MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If obj.VERIFICAR_REG_COMPRAS(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text) = False Then
                    MessageBox.Show("El Documento ya existe en el Registro de Compras.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
            If (COD_MONEDA = "D") Then
                Dim D_DEBE As Decimal
                Dim D_HABER As Decimal
                If (COD_DH_DOC = "H") Then
                    D_HABER = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_total01.Text))
                    D_DEBE = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_igv01.Text))
                Else
                    D_DEBE = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_total01.Text))
                    D_HABER = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_igv01.Text))
                End If
                If VALIDAR_SOLES01(D_DEBE, D_HABER, Decimal.Parse(txt_cambio01.Text)) = False Then
                    DESCUADRE.ShowDialog()
                    Return
                End If
            ElseIf (COD_MONEDA = "S") Then
                Dim S_DEBE As Decimal
                Dim S_HABER As Decimal
                If (COD_DH_DOC = "H") Then
                    S_HABER = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_total01.Text))
                    S_DEBE = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_igv01.Text))
                Else
                    S_DEBE = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_total01.Text))
                    S_HABER = Decimal.Parse(obj.HACER_DECIMAL(txt_imp_igv01.Text))
                End If
                If VALIDAR_DOLARES01(S_DEBE, S_HABER, Decimal.Parse(txt_cambio01.Text)) = False Then
                    DESCUADRE.ShowDialog()
                    Return
                End If
            End If
            'STATUS_GASTO = "0"
            '----------------------------------------
            STATUS_GASTO = "0"
            If ch_pago2.Checked Then
                STATUS_GASTO = "1"
            End If
            '----------------------------------------
            ORDEN_IGV = cBO_orden_igv01.Text
            INSERTAR_DOCUMENTO_DGW01()
            If (cbo_aux01.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_aux01.Focus()
            ElseIf (cbo_comp01.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_comp01.Focus()
            ElseIf (txt_nro_comp01.Text.Trim = "") Then
                MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_nro_comp01.Focus()
            ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_comp01.Value)) = 0) Then
                dtp_comp01.Focus()
            Else
                If (ESTADO_AUTO <> "SI") Then
                    GENERAR_AUTO()
                End If
                txt_nro_comp.Text = txt_nro_comp01.Text
                dtp_com.Value = dtp_comp01.Value
                ESTADO_AUTO = "SI"
                If (INSERTAR_TODO() = "EXITO") Then
                    CambiarEstadoNoEmitidas() 'Para cambiar el estado de las no emitidas del t_con
                    MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DATAGRID()
                    btn_grabar_com01.Enabled = False
                    btn_nuevo_comp01.Enabled = True
                    btn_imprimir01.Enabled = True
                    btn_imprimir01.Focus()
                    Panel201.Enabled = False
                Else
                    obj.ELIMINAR_TEMPORAL("PCOMP")
                    MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
    End Sub

    Private Sub btn_grabar_com012_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com012.Click
        If (dgw_mov01.RowCount = 0) Then MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_det01.Focus() : Exit Sub
        If ((txt_cta_igv01.Text.Trim = "") And (Decimal.Parse(txt_imp_igv01.Text) <> 0)) Then MessageBox.Show("Debe elegir la Cuenta de Igv", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta_igv01.Focus() : Exit Sub
        If (txt_cta_t01.Text.Trim = "") Then MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta_t01.Focus() : Exit Sub
        If (Decimal.Parse(txt_imp_total01.Text) <= 0) Then MessageBox.Show("No existe Importe Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        '------------------------------------------------
        If (Decimal.Parse(txt_imp_total01.Text) <> Convert.ToDouble(New Decimal((Decimal.Parse(txt_imp_igv01.Text) + Convert.ToDouble(HALLAR_TOTAL_BI_DOC01))))) Then
            MessageBox.Show("Documento con descuadre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        Else
            ORDEN_IGV = cBO_orden_igv01.Text
            COD_MONEDA = cbo_moneda01.SelectedValue.ToString
            If VERIFICAR_SOLES01() = False Then Exit Sub
            ELIMINAR_DOCUMENTO_DGW(FILA_DOC)
            'STATUS_GASTO = "0"
            STATUS_GASTO = "0"
            If ch_pago2.Checked Then
                STATUS_GASTO = "1"
            End If
            INSERTAR_DOCUMENTO_DGW01()
            If cbo_aux01.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux01.Focus() : Exit Sub
            If cbo_comp01.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_comp01.Focus() : Exit Sub
            If txt_nro_comp01.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp01.Focus() : Exit Sub
            If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_comp01.Value)) = 0) Then dtp_comp01.Focus() : Exit Sub
            If (ESTADO_AUTO <> "SI") Then
                GENERAR_AUTO()
            End If
            ESTADO_AUTO = "SI"
            txt_nro_comp.Text = txt_nro_comp01.Text
            dtp_com.Value = dtp_comp01.Value
            If (MODIFICAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se actualizó con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                dgw1.CurrentCell = (dgw1.Rows.Item(INDICE).Cells.Item(1))
                btn_grabar_com012.Enabled = False
                btn_nuevo_comp01.Enabled = True
                btn_imprimir01.Enabled = True
                btn_imprimir01.Focus()
                Panel201.Enabled = False
            Else
                obj.ELIMINAR_TEMPORAL("PCOMP")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    Private Sub btn_grabar_com2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_com2.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        If (dgw_doc_01.RowCount = 0) Then MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub
        '-----------------
        If (ESTADO_AUTO <> "SI") Then
            GENERAR_AUTO()
        End If
        '-----------------
        ESTADO_AUTO = "SI"
        If (MODIFICAR_TODO() = "EXITO") Then
            MessageBox.Show("El Comprobante se actualizó con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DATAGRID()
            btn_grabar_com2.Enabled = False
            Panel2.Enabled = False
            btn_nuevo_comp.Enabled = True
            btn_imprimir.Enabled = True
            btn_imprimir.Focus()
            Panel2.Enabled = False
        Else
            obj.ELIMINAR_TEMPORAL("PCOMP")
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub btn_grabar_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_doc.Click
        If (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        ElseIf (txt_cta_igv.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Igv", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_igv.Focus()
        ElseIf (txt_cta_total.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_total.Focus()
        ElseIf (Decimal.Parse(txt_total.Text) <= 0) Then
            MessageBox.Show("No existe Importe Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_total.Text) <> Convert.ToDouble(New Decimal((Decimal.Parse(txt_igv.Text) + Convert.ToDouble(HALLAR_TOTAL_BI_DOC))))) Then
            MessageBox.Show("Documento con descuadre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf ((ORDEN_IGV = "") Or (ORDEN_TOTAL = "")) Then
            MessageBox.Show("No existen Nº de Orden en la cuenta de IGV o Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf VERIFICAR_DATAGRID_DOC(txt_cod_per0.Text, txt_doc_per.Text, COD_DOC, txt_nro_doc.Text) = False Then
            MessageBox.Show("Ya guardo el documento.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If VERIFICAR_SOLES() = False Then Exit Sub
            If (BOTON = "NUEVO") Then
                If obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False Then
                    MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If obj.VERIFICAR_REG_COMPRAS(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text) = False Then
                    MessageBox.Show("El Documento ya existe en Reg. de Compras", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
            STATUS_GASTO = "0"
            If ch_pago.Checked Then
                STATUS_GASTO = "1"
            End If
            ORDEN_IGV = cbo_orden_igv.Text
            INSERTAR_DOCUMENTO_DGW()
            MessageBox.Show("El Documento se ingresó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_DOCUMENTOS()
            cbo_tipo_doc.Focus()
        End If
        hallar_total()
    End Sub
    Sub hallar_total()
        Dim sum As Decimal
        Dim i, cont As Integer
        sum = 0
        cont = dgw_doc_01.RowCount - 1
        For i = 0 To cont
            sum = sum + dgw_doc_01.Item(33, i).Value
        Next
        txt_import_total.Text = obj.HACER_DECIMAL(sum)
    End Sub
    Private Sub btn_grabar_doc2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_doc2.Click
        If (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        ElseIf (txt_cta_igv.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Igv", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_igv.Focus()
        ElseIf (txt_cta_total.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_total.Focus()
        ElseIf (Decimal.Parse(txt_total.Text) <= 0) Then
            MessageBox.Show("No existe Importe Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_total.Text) <> Convert.ToDouble(New Decimal((Decimal.Parse(txt_igv.Text) + Convert.ToDouble(HALLAR_TOTAL_BI_DOC))))) Then
            MessageBox.Show("Documento con descuadre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If VERIFICAR_SOLES() = False Then Exit Sub
            ELIMINAR_DOCUMENTO_DGW(FILA_DOC)
            STATUS_GASTO = "0"
            If ch_pago.Checked Then
                STATUS_GASTO = "1"
            End If
            ORDEN_IGV = cbo_orden_igv.Text
            INSERTAR_DOCUMENTO_DGW()
            MessageBox.Show("El Documento se Actualizó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Panel_DOC02.Visible = False
            btn_nuevo_doc.Focus()
        End If
        hallar_total()
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
            ElseIf ((CBO_CC.SelectedIndex = -1) And CBO_CC.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CBO_CC.Focus()
            ElseIf ((cbo_proyecto.SelectedIndex = -1) And cbo_proyecto.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_proyecto.Focus()
            Else
                COD_REF00 = ""
                If cbo_ref.SelectedIndex <> -1 Then COD_REF00 = obj.COD_DOC(cbo_ref.Text)
                Dim BI_DOL As Decimal
                Dim BI_REAL As Decimal
                Dim BI_SOL As Decimal
                Dim BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA
                Dim rep As String = "0"
                If ch_rep2.Checked Then
                    rep = "1"
                End If
                If (lbl_moneda_det.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 + Decimal.Parse(TXT_IGV0.Text)))), 2))
                Else
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = BI_TEMP
                End If
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio.Text))), 2))
                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio.Text))), 2))
                    Case "A"
                        BI_DOL = New Decimal
                        BI_SOL = BI_REAL
                End Select
                '---------------------------------------------
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
                COD_C = txt_nro_ord_prod.Text
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_P = obj.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (CBO_CC.SelectedIndex <> -1) Then
                    COD_CC = obj.COD_CC(CBO_CC.Text)
                End If
                If (cbo_act.SelectedIndex <> -1) Then
                    COD_ACT = cbo_act.SelectedValue.ToString
                End If
                ORDEN_BI = CBO_ORDEN.Text
                dgw_mov1.Rows.Add(ITEM.ToString("0000"), txt_cta_imp.Text, txt_glosa.Text, BI_SOL, BI_DOL, cbo_d_h.Text, _
                    MON0, txt_cambio.Text, COD_CC, COD_C, COD_P, ORDEN_BI, dtp_vence.Value, STATUS_PV, ENLACE, DESTINO, _
                    STATUS_CC, "1", STATUS_P, dtp_doc.Value, " ", "1", TXT_IGV0.Text, rep, COD_ACT, COD_REF00, txt_ref.Text)
                HALLAR_TOTAL_DOC()
                LIMPIAR_DETALLES()

                txt_cta_imp.Focus()
            End If
        End If
    End Sub
    Private Sub BTN_GUARDAR_DET01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_GUARDAR_DET01.Click
        If (txt_cod_cuenta01.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cuenta01.Focus()
        Else
            If cbo_orden01.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden01.Focus() : Exit Sub

            If (txt_bi01.Text.Trim = "") Then
                txt_bi01.Text = "0.00"
            End If
            If (Decimal.Parse(txt_bi01.Text) = 0) Then
                MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_bi01.Focus()




            ElseIf ((CBO_CC01.SelectedIndex = -1) And CBO_CC01.Enabled) Then
                MessageBox.Show("Debe elegir el Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CBO_CC01.Focus()
            ElseIf ((CBO_PROYECTO01.SelectedIndex = -1) And CBO_PROYECTO01.Enabled) Then
                MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CBO_PROYECTO01.Focus()
            Else
                COD_REF00 = ""
                If cbo_ref00.SelectedIndex <> -1 Then COD_REF00 = obj.COD_DOC(cbo_ref00.Text)
                Dim BI_DOL, BI_REAL, BI_SOL, BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA
                Dim rep As String = "0"
                If ch_rep.Checked Then
                    rep = "1"
                End If
                If (lbl_moneda01.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi01.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 + Decimal.Parse(TXT_IGV01.Text)))), 2))
                Else
                    BI_TEMP = New Decimal(Double.Parse(txt_bi01.Text))
                    BI_REAL = BI_TEMP
                End If
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio01.Text))), 2))

                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio01.Text))), 2))

                    Case "A"
                        BI_DOL = New Decimal
                        BI_SOL = BI_REAL

                End Select
                Dim ITEM As Integer = Integer.Parse(HALLAR_ITEM01)
                ENLACE = ""
                DESTINO = ""
                If cbo_auto01.Visible Then
                    ITEM = (ITEM + 2)
                End If
                DESTINO = Strings.Mid((cbo_auto01.SelectedItem), 1, 8)
                ENLACE = Strings.Mid((cbo_auto01.SelectedItem), 24, 31)
                COD_C = ""
                COD_P = ""
                COD_CC = ""
                COD_ACT = ""
                If (CBO_CC01.SelectedIndex <> -1) Then
                    COD_CC = obj.COD_CC(CBO_CC01.Text)
                End If
                COD_C = txt_nro_req.Text
                If (CBO_PROYECTO01.SelectedIndex <> -1) Then
                    COD_P = obj.COD_PROYECTO(CBO_PROYECTO01.Text)
                End If
                If cbo_act01.SelectedIndex <> -1 Then
                    COD_ACT = cbo_act01.SelectedValue.ToString
                End If
                ORDEN_BI = cbo_orden01.Text
                '-------------------------------
                'If TXT_IGV01.Text = 0 Then ORDEN_BI = obj.HALLAR_ORDEN_CUENTA2("B", AÑO, "C", txt_cod_cuenta01.Text.ToString)
                '-------------------------------
                dgw_mov01.Rows.Add(ITEM.ToString("0000"), txt_cod_cuenta01.Text, TXT_GLOSA01.Text, BI_SOL, BI_DOL, CBO_D_H01.Text, MON0, txt_cambio01.Text, COD_CC, COD_C, COD_P, ORDEN_BI, dtp_vence01.Value, STATUS_PV, ENLACE, DESTINO, STATUS_CC, "1", STATUS_P, dtp_doc01.Value, " ", "1", TXT_IGV01.Text, rep, COD_ACT, COD_REF00, txt_ref00.Text)
                HALLAR_TOTAL_DOC01()
                LIMPIAR_DETALLES01()

                txt_cod_cuenta01.Focus()
            End If
        End If
    End Sub
    Private Sub btn_imprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_imprimir.Click
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw_det_01.Rows.Count - 1
        Dim IMPORTE As Decimal
        Dim IMPORTE_DEBE, IMPORTE_HABER As Decimal
        For I = 0 To cont
            If dgw_det_01.Item(25, I).Value = "T" Or dgw_det_01.Item(25, I).Value = "I" Or dgw_det_01.Item(25, I).Value = "B" Then
                If dgw_det_01.Item(6, I).Value = "S" Then
                    IMPORTE = obj.HACER_DECIMAL(dgw_det_01.Item(3, I).Value / dgw_det_01.Item(7, I).Value)
                ElseIf dgw_det_01.Item(6, I).Value = "D" Then
                    IMPORTE = dgw_det_01.Item(4, I).Value
                End If
                If dgw_det_01.Item(5, I).Value = "D" Then
                    IMPORTE_DEBE = dgw_det_01.Item(3, I).Value : IMPORTE_HABER = "0.00"
                ElseIf dgw_det_01.Item(5, I).Value = "H" Then
                    IMPORTE_DEBE = "0.00" : IMPORTE_HABER = dgw_det_01.Item(3, I).Value
                End If
                Dim COD_REPOR As String
                COD_REPOR = obj.DESC_USUARIO_COMPROBANTE(cbo_aux.SelectedValue.ToString, cbo_com.SelectedValue.ToString, txt_nro_comp.Text, AÑO, MES)
                dt.DataTable1.Rows.Add(dgw_det_01.Item(19, I).Value.ToString.Substring(0, 10), dgw_det_01.Item(21, I).Value, dgw_det_01.Item(20, I).Value, dgw_det_01.Item(22, I).Value, dgw_det_01.Item(8, I).Value, dgw_det_01.Item(1, I).Value, dgw_det_01.Item(2, I).Value, dgw_det_01.Item(6, I).Value, dgw_det_01.Item(7, I).Value, IMPORTE, IMPORTE_DEBE, IMPORTE_HABER, dgw_det_01.Item(5, I).Value, dgw_det_01.Item(39, I).Value, txt_nro_comp01.Text, COD_REPOR, dgw_det_01.Item(2, I).Value, cbo_comp01.Text, dgw_det_01.Item(10, I).Value, dgw_det_01.Item(11, I).Value)
            End If
        Next

        If chkContinuo1.Checked Then
            ReporteImprimir(dt, reporte, cbo_aux.Text)
        Else
            ReporteImprimir(dt, reporte1, cbo_aux.Text)
        End If

        'reporte.SetDataSource(dt)
        'Dim Params As New ParameterValues
        'Dim Par As New ParameterDiscreteValue
        ''======================================================================================
        'Params.Clear()
        'Par.Value = obj.DESC_MES(MES)
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

        'reporte.PrintOptions.PaperSize = DirectCast(obj.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        'reporte.PrintToPrinter(1, False, 0, 0)
    End Sub
    Private Sub btn_Insertar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Insertar.Click
        Try
            Dim i As Integer = dgw_doc_01.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        FILA_DOC = dgw_doc_01.CurrentRow.Index
        CARGAR_DATOS_REF(FILA_DOC)
        TabControl3.Visible = True
    End Sub
    Sub CARGAR_DATOS_REF(ByVal FILA0 As Integer)
        txt_tasa_det.Clear()
        txt_cod_det.Clear()
        cbo_tipo_ref.SelectedIndex = -1
        txt_nro_ref.Clear()
        txt_base_ref.Clear()
        Try
            txt_tasa_det.Text = CInt(dgw_doc_01.Item(25, FILA0).Value)
            txt_cod_det.Text = dgw_doc_01.Item(24, FILA0).Value
            dtp_det.Value = dgw_doc_01.Item(26, FILA0).Value
            cbo_tipo_ref.Text = obj.DESC_DOC(dgw_doc_01.Item(27, FILA0).Value)
            txt_nro_ref.Text = dgw_doc_01.Item(28, FILA0).Value
            dtp_ref.Value = dgw_doc_01.Item(29, FILA0).Value
            dtp_pago.Value = dgw_doc_01.Item(30, FILA0).Value
            txt_base_ref.Text = dgw_doc_01.Item(32, FILA0).Value

            cboMonedaOrigenxNDocumentos.SelectedValue = dgw_doc_01.Item(36, FILA0).Value
            RecuperarDescripcionConvenios(dgw_doc_01.Item(37, FILA0).Value, cboConveniosXNDocumentos)
            RecuperarDescripcionTipoRenta(dgw_doc_01.Item(38, FILA0).Value, cboTipoRentaxNDocumentos)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_mod_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod_det.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        LIMPIAR_DETALLES()
        item0.Text = (dgw_mov1.Item(0, dgw_mov1.CurrentRow.Index).Value)
        CARGAR_DET1()
        '--------------
        txt_cta_imp.Enabled = False
        txt_desc_cta_imp.Enabled = False
        cbo_auto.Enabled = False
        '--------------
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        txt_bi.Focus()
    End Sub
    Private Sub btn_mod_det01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod_det01.Click
        Try
            Dim i As Integer = dgw_mov01.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        LIMPIAR_DETALLES01()
        item01.Text = (dgw_mov01.Item(0, dgw_mov01.CurrentRow.Index).Value)
        CARGAR_DET01()

        txt_cod_cuenta01.Enabled = False
        txt_desc_cuenta01.Enabled = False
        cbo_auto01.Enabled = False
        BTN_GUARDAR_DET01.Visible = False
        btn_mod_det01.Visible = True
        txt_bi01.Focus()
    End Sub
    Private Sub btn_mod_det012_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod_det012.Click
        If (txt_cod_cuenta01.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cuenta01.Focus()
        Else
            If cbo_orden01.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden01.Focus() : Exit Sub
            If (txt_bi01.Text.Trim = "") Then
                txt_bi01.Text = "0.00"
            End If
            If (Decimal.Parse(txt_bi01.Text) = 0) Then
                MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_bi01.Focus()
            Else
                COD_REF00 = ""
                If cbo_ref00.SelectedIndex <> -1 Then COD_REF00 = obj.COD_DOC(cbo_ref00.Text)
                Dim BI_DOL As Decimal
                Dim BI_REAL As Decimal
                Dim BI_SOL As Decimal
                Dim BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA
                Dim rep As String = "0"
                ORDEN_BI = cbo_orden01.Text
                If ch_rep.Checked Then
                    rep = "1"
                End If
                If (lbl_moneda01.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi01.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 + Decimal.Parse(TXT_IGV01.Text)))), 2))
                Else
                    BI_TEMP = New Decimal(Double.Parse(txt_bi01.Text))
                    BI_REAL = BI_TEMP
                End If
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio01.Text))), 2))

                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio01.Text))), 2))

                    Case "A"
                        BI_DOL = New Decimal
                        BI_SOL = BI_REAL

                End Select
                Dim ITEM As Integer = Integer.Parse(HALLAR_ITEM01)
                ENLACE = ""
                DESTINO = ""
                If cbo_auto01.Visible Then
                    ITEM = (ITEM + 2)
                End If
                DESTINO = Strings.Mid((cbo_auto01.SelectedItem), 1, 8)
                ENLACE = Strings.Mid((cbo_auto01.SelectedItem), 24, 31)
                COD_C = ""
                COD_P = ""
                COD_CC = ""
                COD_ACT = ""
                COD_C = txt_nro_req.Text
                If (CBO_PROYECTO01.SelectedIndex <> -1) Then
                    COD_P = obj.COD_PROYECTO(CBO_PROYECTO01.Text)
                End If
                If (CBO_CC01.SelectedIndex <> -1) Then
                    COD_CC = obj.COD_CC(CBO_CC01.Text)
                End If
                If (cbo_act01.SelectedIndex <> -1) Then
                    COD_ACT = cbo_act01.SelectedValue.ToString
                End If
                dgw_mov01.Item(1, dgw_mov01.CurrentRow.Index).Value = txt_cod_cuenta01.Text
                dgw_mov01.Item(2, dgw_mov01.CurrentRow.Index).Value = TXT_GLOSA01.Text
                dgw_mov01.Item(3, dgw_mov01.CurrentRow.Index).Value = BI_SOL
                dgw_mov01.Item(4, dgw_mov01.CurrentRow.Index).Value = BI_DOL
                dgw_mov01.Item(5, dgw_mov01.CurrentRow.Index).Value = CBO_D_H01.Text
                dgw_mov01.Item(6, dgw_mov01.CurrentRow.Index).Value = MON0
                dgw_mov01.Item(7, dgw_mov01.CurrentRow.Index).Value = txt_cambio01.Text
                dgw_mov01.Item(8, dgw_mov01.CurrentRow.Index).Value = COD_CC
                dgw_mov01.Item(9, dgw_mov01.CurrentRow.Index).Value = COD_C
                dgw_mov01.Item(10, dgw_mov01.CurrentRow.Index).Value = COD_P
                dgw_mov01.Item(11, dgw_mov01.CurrentRow.Index).Value = ORDEN_BI
                dgw_mov01.Item(12, dgw_mov01.CurrentRow.Index).Value = dtp_vence01.Value
                dgw_mov01.Item(13, dgw_mov01.CurrentRow.Index).Value = STATUS_PV
                dgw_mov01.Item(14, dgw_mov01.CurrentRow.Index).Value = ENLACE
                dgw_mov01.Item(15, dgw_mov01.CurrentRow.Index).Value = DESTINO
                dgw_mov01.Item(16, dgw_mov01.CurrentRow.Index).Value = STATUS_CC
                dgw_mov01.Item(17, dgw_mov01.CurrentRow.Index).Value = "1"
                dgw_mov01.Item(18, dgw_mov01.CurrentRow.Index).Value = STATUS_P
                dgw_mov01.Item(19, dgw_mov01.CurrentRow.Index).Value = dtp_doc01.Value
                dgw_mov01.Item(20, dgw_mov01.CurrentRow.Index).Value = " "
                dgw_mov01.Item(21, dgw_mov01.CurrentRow.Index).Value = "1"
                dgw_mov01.Item(22, dgw_mov01.CurrentRow.Index).Value = TXT_IGV01.Text
                dgw_mov01.Item(23, dgw_mov01.CurrentRow.Index).Value = rep
                dgw_mov01.Item(24, dgw_mov01.CurrentRow.Index).Value = COD_ACT
                dgw_mov01.Item(25, dgw_mov01.CurrentRow.Index).Value = COD_REF00
                dgw_mov01.Item(26, dgw_mov01.CurrentRow.Index).Value = txt_ref00.Text
                item0.Text = ""
                BTN_GUARDAR_DET01.Visible = True
                btn_mod_det012.Visible = False
                LIMPIAR_DETALLES01()
                txt_cod_cuenta01.Focus()
                HALLAR_TOTAL_DOC01()
                Panel_det01.Visible = False
                btn_nuevo_det01.Focus()
            End If
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        BOTON = "MODIFICAR"
        INDICE = dgw1.CurrentRow.Index
        LIMPIAR_COMPROBANTE01()
        LIMPIAR_COMPROBANTE()

        CARGAR_COMPROBANTE()
        If obj.VERIFICAR_TRANSF_PRODUCCION(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Producción", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = True
        btn_grabar_com01.Visible = False
        btn_grabar_com012.Visible = True
        g_cab.Enabled = False
        btn_grabar_com2.Enabled = True
        g_cab01.Enabled = False
        btn_grabar_com012.Enabled = True
        btn_imprimir.Enabled = False
        btn_imprimir01.Enabled = False

        ValidarFicha = False
        If (dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString = "x Doc.") Then
            ValidarCodigoBienes(dgw_doc_01.Item(35, 0).Value, cboClasificacionBienesxDocumento)
            CodigoMonedaOrigen = dgw_doc_01.Item(36, 0).Value : cboMonedaOrigen.SelectedValue = CodigoMonedaOrigen
            RecuperarDescripcionConvenios(dgw_doc_01.Item(37, 0).Value, cboConvenios)
            RecuperarDescripcionTipoRenta(dgw_doc_01.Item(38, 0).Value, cboTipoRenta)
            '-
            If CARGAR_DOC01() = False Then
                ValidarFicha = True
                Exit Sub
            End If

            '----------------------------------------------------

            TabControl1.SelectedTab = TabPage2
            panel01.Enabled = False
            btn_nuevo_det01.Focus()
            panel01.Enabled = False
            btn_nuevo_det01.Focus()
            ConfigDoc = obj.GCO_DIR_TABLA_DESC(obj.COD_DOC(cbo_tipo_doc01.Text), "TCDOC", con)
        Else
            TabControl1.SelectedTab = TabPage3
            btn_nuevo_doc.Focus()
        End If
        hallar_total()

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
        If (obj.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False And BOTON <> "NUEVO" And ST_PLA = "0") Then
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
                COD_REF00 = ""
                If cbo_ref.SelectedIndex <> -1 Then COD_REF00 = obj.COD_DOC(cbo_ref.Text)
                Dim BI_DOL As Decimal
                Dim BI_REAL As Decimal
                Dim BI_SOL As Decimal
                Dim BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA
                Dim rep As String = "0"
                If ch_rep2.Checked Then
                    rep = "1"
                End If
                If (lbl_moneda_det.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 + Decimal.Parse(TXT_IGV0.Text)))), 2))
                Else
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = BI_TEMP
                End If
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio.Text))), 2))
                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio.Text))), 2))
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
                COD_C = txt_nro_ord_prod.Text
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_P = obj.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (CBO_CC.SelectedIndex <> -1) Then
                    COD_CC = obj.COD_CC(CBO_CC.Text)
                End If
                If (cbo_act.SelectedIndex <> -1) Then COD_ACT = cbo_act.SelectedValue.ToString
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
                dgw_mov1.Item(25, dgw_mov1.CurrentRow.Index).Value = COD_REF00
                dgw_mov1.Item(26, dgw_mov1.CurrentRow.Index).Value = txt_ref.Text
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
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click, btn_nuevo_comp.Click
        BOTON = "NUEVO"
        ValidarFicha = False
        TIPO_DET = "N"
        TabControl1.SelectedTab = TabPage3
        LIMPIAR_COMPROBANTE()
        If cbo_tipo_doc.SelectedIndex > -1 Then
            ConfigDoc = obj.GCO_DIR_TABLA_DESC(obj.COD_DOC(cbo_tipo_doc.Text), "TCDOC", con)
        End If
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
        If (dtp_doc.Value.Date > FECHA_GRAL.Date) Then
            MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_doc.Focus()
            Exit Sub
        End If

        If (cbo_tipo_doc.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc.Focus()
        ElseIf (txt_nro_doc.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc.Focus()
            'ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_DOC(dtp_doc.Value)) = 0) Then
            '    dtp_doc.Focus()
        ElseIf (txt_cod_per0.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
        ElseIf (cbo_moneda.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda.Focus()
            'Puesto de manera temporal para controlar los nuevos códigos que proporciona la SUNAT
        ElseIf (cboClasificacionBienesXnDocumento.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el tipo de Bienes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClasificacionBienesXnDocumento.Focus()
            '------
        Else
            If (txt_cambio.Text = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            Else
                COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
                If (BOTON = "NUEVO") Then
                    If obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False Then
                        MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    If obj.VERIFICAR_REG_COMPRAS(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text) = False Then
                        MessageBox.Show("El Documento ya existe en Reg. de Compras", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If

                    'If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                    '    CH_IGV.Checked = (ConfigDoc.Substring(4, 1) = "S" OrElse ch_pago.Checked)
                    'End If
                End If
                panel1.Enabled = False
                cboClasificacionBienesXnDocumento.Enabled = False
                COD_DH_DOC = obj.COD_D_H(COD_DOC)
                If (COD_DH_DOC = "D") Then
                    COD_DH_DOC = "H"
                Else
                    COD_DH_DOC = "D"
                End If
                STATUS_PV = "0"
                If ch_pv.Checked Then
                    STATUS_PV = "1"
                End If
                LIMPIAR_DETALLES()
                Panel_det02.Visible = True
                txt_cta_imp.Focus()
            End If
        End If
    End Sub
    Private Sub btn_nuevo_det01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_det01.Click
        If (cbo_aux01.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux01.Focus()
        ElseIf (cbo_comp01.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_comp01.Focus()
        ElseIf (txt_nro_comp01.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp01.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_comp01.Value)) = 0) Then
            dtp_comp01.Focus()
            'Puesto de manera temporal para controlar los nuevos códigos que proporciona la SUNAT
        ElseIf (cboClasificacionBienesxDocumento.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el tipo de Bienes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClasificacionBienesxDocumento.Focus()
            '------
        Else
            g_cab01.Enabled = False
            cboClasificacionBienesxDocumento.Enabled = False
            If (cbo_tipo_doc01.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir el Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_tipo_doc01.Focus()
            ElseIf (txt_nro_doc01.Text.Trim = "") Then
                MessageBox.Show("Debe insertar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_nro_doc01.Focus()
            ElseIf (dtp_doc01.Value.Date > FECHA_GRAL.Date) Then
                MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtp_doc01.Focus()
            ElseIf (txt_cod_per01.Text.Trim = "") Then
                MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_per01.Focus()
            ElseIf (cbo_moneda01.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir la MOneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_moneda01.Focus()
            Else
                If (txt_cambio01.Text = "") Then
                    txt_cambio01.Text = "0.0000"
                End If
                If (Decimal.Parse(txt_cambio01.Text) = 0) Then
                    MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_cambio01.Focus()
                Else
                    COD_DOC = obj.COD_DOC(cbo_tipo_doc01.Text)
                    If (BOTON = "NUEVO") Then
                        If obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text, txt_cta_t01.Text) = False Then
                            MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        If obj.VERIFICAR_REG_COMPRAS(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text) = False Then
                            MessageBox.Show("El Documento ya existe en el Registro de Compras.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        'If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                        '    ch_igv01.Checked = (ConfigDoc.Substring(4, 1) = "S" OrElse ch_pago2.Checked)
                        'End If
                    End If
                    panel01.Enabled = False
                    COD_DH_DOC = obj.COD_D_H(COD_DOC)
                    If COD_DH_DOC = "D" Then COD_DH_DOC = "H" Else COD_DH_DOC = "D"
                    STATUS_PV = "0"
                    If ch_pv01.Checked Then STATUS_PV = "1"
                    LIMPIAR_DETALLES01()
                    Panel_det01.Visible = True
                    txt_cod_cuenta01.Focus()
                End If
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
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        Else
            g_cab.Enabled = False
            LIMPIAR_DOCUMENTOS()
            Panel_DOC02.Visible = True
            cbo_tipo_doc.Focus()
        End If
    End Sub
    Private Sub btn_nuevo2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo2.Click, btn_nuevo_comp01.Click
        BOTON = "NUEVO"
        ValidarFicha = False
        TIPO_DET = "1"
        TabControl1.SelectedTab = TabPage2
        LIMPIAR_COMPROBANTE01()
        If cbo_tipo_doc01.SelectedIndex > -1 Then
            ConfigDoc = obj.GCO_DIR_TABLA_DESC(obj.COD_DOC(cbo_tipo_doc01.Text), "TCDOC", con)
        End If
        ch_pago2.Checked = False
        cbo_aux01.Focus()
        Panel201.Enabled = True
        ValidarFicha = True
    End Sub
    Private Sub btn_pago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pago.Click
        If ((dgw_doc_01.Item(3, FILA_DOC).Value) = "14") Then
            dgw_doc_01.Item(30, FILA_DOC).Value = dtp_pago.Value
            dgw_doc_01.Item(31, FILA_DOC).Value = "1"
            Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
        Else
            MessageBox.Show("El Documento no posee fecha de Pago", "No es Documento del Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub btn_ref_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ref.Click
        'Dim cod_doc007 As String = (dgw_doc_01.Item(3, FILA_DOC).Value)
        'If ((cod_doc007 = "07") Or (cod_doc007 = "08")) Then
        If ((cbo_tipo_ref.SelectedIndex = -1) Or (Strings.Trim(txt_nro_ref.Text) = "")) Then
            MessageBox.Show("Inserte los datos", "Faltan Datos", MessageBoxButtons.OK)
        Else
            Dim cod_ref As String = obj.COD_DOC((cbo_tipo_ref.SelectedItem))
            dgw_doc_01.Item(27, FILA_DOC).Value = cod_ref
            dgw_doc_01.Item(28, FILA_DOC).Value = txt_nro_ref.Text
            dgw_doc_01.Item(29, FILA_DOC).Value = dtp_ref.Value
            Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
        End If
        'Else
        'MessageBox.Show("El Documento no posee Referencia", "No es Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub
    Private Sub btn_ref0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ref0.Click
        TabControl2.Visible = True
        TabControl2.SelectedTab = TabPage4
        txt_nro_det0.Focus()
    End Sub
    Private Sub btn_req_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_req.Click
        boton3()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(14) = 0
        Close()
    End Sub
    Private Sub btn_salir8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir8.Click, Button4.Click, Button5.Click, Button6.Click
        TabControl3.Visible = False
    End Sub
    Private Sub btn_sgt_cta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt_cta.Click
        Dim CONT0 As Integer = (dgw_cta01.RowCount - 1)
        Dim i As Integer = fila3
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_cta01.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_cuenta01.Text.ToLower = Strings.Mid(dgw_cta01.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cuenta01.Text)).ToLower) Then
                    dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(i).Cells.Item(1)
                    fila3 = (i + 1)
                    dgw_cta01.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_cta01.Focus()
    End Sub
    Private Sub btn_sgt_per_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt_per.Click
        Dim CONT0 As Integer = (dgw_per01.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= CONT0)
            Dim CONT1 As Integer = Strings.Len(dgw_per01.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT1)
                If (txt_desc_per01.Text.ToLower = Strings.Mid(dgw_per01.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per01.Text)).ToLower) Then
                    dgw_per01.CurrentCell = dgw_per01.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    dgw_per01.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_per01.Focus()
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
    Private Sub Button19_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button19.Click
        DGW_PERSONAS()
    End Sub
    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        cbo_aux01.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        cbo_comp01.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp01.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        ST_PLA = (dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString)
        dtp_comp01.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        'COD_REPOR = (dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString)
        dgw_doc_01.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_REGISTRO_COMPRAS", con)
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
                dgw_doc_01.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)), (rs2.GetValue(20)), (rs2.GetValue(21)), (rs2.GetValue(22)), rs2.GetValue(23), rs2.GetValue(24), (rs2.GetValue(25)), (rs2.GetValue(26)), (rs2.GetValue(27)), (rs2.GetValue(28)), (rs2.GetValue(29)), (rs2.GetValue(30)), (rs2.GetValue(31)), (rs2.GetValue(32)), (rs2.GetValue(33)), (rs2.GetValue(34)), (rs2.GetValue(35)), (rs2.GetValue(36)), (rs2.GetValue(37)), (rs2.GetValue(38)))
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
                'dgw_det_01.Rows.Add(New Object() {(rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)), (rs2.GetValue(20)), (rs2.GetValue(21)), (rs2.GetValue(22)), (rs2.GetValue(23)), (rs2.GetValue(24)), (rs2.GetValue(25)), (rs2.GetValue(26)), (rs2.GetValue(27)), (rs2.GetValue(28)), (rs2.GetValue(29)), (rs2.GetValue(30)), (rs2.GetValue(31)), (rs2.GetValue(32)), (rs2.GetValue(33)), (rs2.GetValue(34)), (rs2.GetValue(35)), (rs2.GetValue(36)), (rs2.GetValue(37)), (rs2.GetValue(&H29)), (rs2.GetValue(&H2A))})
                dgw_det_01.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), _
                rs2.GetValue(4), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), _
                (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), _
                (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), _
                (rs2.GetValue(19)), (rs2.GetValue(20)), (rs2.GetValue(21)), (rs2.GetValue(22)), (rs2.GetValue(23)), _
                (rs2.GetValue(24)), (rs2.GetValue(25)), (rs2.GetValue(26)), (rs2.GetValue(27)), (rs2.GetValue(28)), _
                (rs2.GetValue(29)), (rs2.GetValue(30)), (rs2.GetValue(31)), (rs2.GetValue(32)), (rs2.GetValue(33)), _
                (rs2.GetValue(34)), (rs2.GetValue(35)), (rs2.GetValue(36)), (rs2.GetValue(37)), (rs2.GetValue(41)), _
                rs2.GetValue(42), rs2.GetValue(38), rs2.GetValue(39), rs2.GetValue(43), rs2.GetValue(44))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Dim st_perce, st_detra As String
        Dim I, CONT As Integer
        CONT = dgw_det_01.RowCount - 1
        For I = 0 To CONT
            If dgw_det_01.Item(25, I).Value = "T" Then
                st_perce = dgw_det_01.Item(42, I).Value
                st_detra = dgw_det_01.Item(43, I).Value
            End If
        Next

        If st_perce = "1" Then ch_perce.Checked = True Else ch_perce.Checked = False
        If st_detra = "1" Then ch_detra.Checked = True Else ch_detra.Checked = False
    End Sub
    Sub CARGAR_DET01()
        txt_cod_cuenta01.Text = (dgw_mov01.Item(1, dgw_mov01.CurrentRow.Index).Value)
        txt_desc_cuenta01.Text = obj.DESC_CUENTA(txt_cod_cuenta01.Text, AÑO)
        CBO_AUTOMATICAS01(txt_cod_cuenta01.Text)
        ORDEN_BI = (dgw_mov01.Item(11, dgw_mov01.CurrentRow.Index).Value)
        cbo_orden01.Text = ORDEN_BI
        cbo_auto01.Text = (String.Concat(String.Concat(dgw_mov01.Item(15, dgw_mov01.CurrentRow.Index).Value, "               "), dgw_mov01.Item(14, dgw_mov01.CurrentRow.Index).Value))
        Dim cod_dh As String = dgw_mov01.Item(5, dgw_mov01.CurrentRow.Index).Value.ToString
        CBO_D_H01.Text = cod_dh
        lbl_moneda01.Text = cbo_moneda01.Text
        If (dgw_mov01.Item(6, dgw_mov01.CurrentRow.Index).Value.ToString = "A") Then
            lbl_moneda01.Text = "AJUSTE"
            COD_MONEDA = "A"
        Else
            COD_MONEDA = dgw_mov01.Item(6, dgw_mov01.CurrentRow.Index).Value.ToString
            lbl_moneda01.Text = obj.DESC_MONEDA(COD_MONEDA)
        End If
        Dim igv As Decimal = Decimal.Parse(dgw_mov01.Item(22, dgw_mov01.CurrentRow.Index).Value.ToString)
        Dim rep As String = dgw_mov01.Item(23, dgw_mov01.CurrentRow.Index).Value.ToString
        COD_ACT = dgw_mov01.Item(24, dgw_mov01.CurrentRow.Index).Value.ToString
        COD_REF00 = dgw_mov01.Item(25, dgw_mov01.CurrentRow.Index).Value.ToString
        cbo_ref00.Text = obj.DESC_DOC(COD_REF00)
        txt_ref00.Text = dgw_mov01.Item(26, dgw_mov01.CurrentRow.Index).Value.ToString
        cbo_act01.SelectedValue = COD_ACT
        If (rep = "1") Then
            ch_rep.Checked = True
        End If
        If (STATUS_PV = "1") Then
            If (COD_MONEDA = "D") Then
                txt_bi01.Text = (Math.Round(CDbl((Double.Parse((dgw_mov01.Item(4, dgw_mov01.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 2))
            Else
                txt_bi01.Text = (Math.Round(CDbl((Double.Parse((dgw_mov01.Item(3, dgw_mov01.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 2))
            End If
        ElseIf (COD_MONEDA = "D") Then
            txt_bi01.Text = (dgw_mov01.Item(4, dgw_mov01.CurrentRow.Index).Value)
        Else
            txt_bi01.Text = (dgw_mov01.Item(3, dgw_mov01.CurrentRow.Index).Value)
        End If
        txt_bi01.Text = (obj.HACER_DECIMAL(txt_bi01.Text))
        TXT_GLOSA01.Text = (dgw_mov01.Item(2, dgw_mov01.CurrentRow.Index).Value)
        CBO_CC01.SelectedIndex = -1
        CBO_CC01.Enabled = False
        CBO_PROYECTO01.SelectedIndex = -1
        CBO_PROYECTO01.Enabled = False
        STATUS_CC = (dgw_mov01.Item(16, dgw_mov01.CurrentRow.Index).Value)
        STATUS_P = (dgw_mov01.Item(18, dgw_mov01.CurrentRow.Index).Value)
        If (Decimal.Parse(STATUS_CC) = 1) Then
            CBO_CC01.Enabled = True
            COD_CC = (dgw_mov01.Item(8, dgw_mov01.CurrentRow.Index).Value)
            CBO_CC01.Text = obj.DESC_CC(COD_CC)
        End If
        txt_nro_req.Text = dgw_mov01.Item(9, dgw_mov01.CurrentRow.Index).Value.ToString
        If (Decimal.Parse(STATUS_P) = 1) Then
            CBO_PROYECTO01.Enabled = True
            CBO_PROYECTO01.Text = obj.DESC_PROYECTO((dgw_mov01.Item(10, dgw_mov01.CurrentRow.Index).Value))
        End If
        ch_igv01.Checked = False
        If dgw_mov01.Item(22, dgw_mov01.CurrentRow.Index).Value > 0 Then
            ch_igv01.Checked = True
        End If
        BTN_GUARDAR_DET01.Visible = False
        btn_mod_det012.Visible = True
        Panel_det01.Visible = True
    End Sub
    Sub CARGAR_DET1()
        txt_cta_imp.Text = (dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value)
        txt_desc_cta_imp.Text = obj.DESC_CUENTA(txt_cta_imp.Text, AÑO)
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
        Else
            COD_MONEDA = dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value.ToString
            lbl_moneda_det.Text = obj.DESC_MONEDA(COD_MONEDA)
        End If
        Dim igv As Decimal = Decimal.Parse(dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value.ToString)

        COD_ACT = dgw_mov1.Item(24, dgw_mov1.CurrentRow.Index).Value.ToString
        COD_REF00 = dgw_mov1.Item(25, dgw_mov1.CurrentRow.Index).Value.ToString
        cbo_ref.Text = obj.DESC_DOC(COD_REF00)
        txt_ref.Text = dgw_mov1.Item(26, dgw_mov1.CurrentRow.Index).Value.ToString
        cbo_act.SelectedValue = COD_ACT
        Dim rep As String = dgw_mov1.Item(23, dgw_mov1.CurrentRow.Index).Value.ToString
        If (rep = "1") Then
            ch_rep2.Checked = True
        Else
            ch_rep2.Checked = False
        End If
        CH_IGV.Checked = False
        If igv = 0 Then
            CH_IGV.Checked = False
        End If
        If (STATUS_PV = "1") Then
            If (COD_MONEDA = "D") Then
                txt_bi.Text = (Math.Round(CDbl((Double.Parse((dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 2))
            Else
                txt_bi.Text = (Math.Round(CDbl((Double.Parse((dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 2))
            End If
        ElseIf (COD_MONEDA = "D") Then
            txt_bi.Text = (dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)
        Else
            txt_bi.Text = (dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)
        End If
        txt_bi.Text = (obj.HACER_DECIMAL(txt_bi.Text))
        txt_glosa.Text = (dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value)
        CBO_CC.Enabled = False
        CBO_CC.SelectedIndex = -1
        txt_nro_ord_prod.Clear()
        cbo_proyecto.SelectedIndex = -1
        cbo_proyecto.Enabled = False
        STATUS_CC = (dgw_mov1.Item(16, dgw_mov1.CurrentRow.Index).Value)
        STATUS_P = (dgw_mov1.Item(18, dgw_mov1.CurrentRow.Index).Value)
        If (Decimal.Parse(STATUS_CC) = 1) Then
            CBO_CC.Enabled = True
            COD_CC = (dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value)
            CBO_CC.Text = obj.DESC_CC(COD_CC)
        End If
        txt_nro_ord_prod.Text = dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse(STATUS_P) = 1) Then
            cbo_proyecto.Enabled = True
            cbo_proyecto.Text = obj.DESC_PROYECTO((dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value))
        End If
        CH_IGV.Checked = False
        If dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value > 0 Then
            CH_IGV.Checked = True
        End If
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        Panel_det02.Visible = True
    End Sub
    Sub CARGAR_DOC_REF()
        txt_cod_det.Text = dgw_doc_01.Item(24, dgw_doc_01.CurrentRow.Index).Value.ToString
        Try
            txt_tasa_det.Text = CInt(dgw_doc_01.Item(25, dgw_doc_01.CurrentRow.Index).Value.ToString)
        Catch ex As Exception
        End Try
        dtp_det.Value = Date.Parse(dgw_doc_01.Item(26, dgw_doc_01.CurrentRow.Index).Value.ToString)
        Dim cod_ref00 As String = dgw_doc_01.Item(27, dgw_doc_01.CurrentRow.Index).Value.ToString
        cbo_tipo_ref.Text = obj.DESC_DOC(cod_ref00)
        txt_nro_ref.Text = dgw_doc_01.Item(28, dgw_doc_01.CurrentRow.Index).Value.ToString
        dtp_ref.Value = Date.Parse(dgw_doc_01.Item(29, dgw_doc_01.CurrentRow.Index).Value.ToString)
        dtp_pago.Value = Date.Parse(dgw_doc_01.Item(30, dgw_doc_01.CurrentRow.Index).Value.ToString)
        txt_base_ref.Text = dgw_doc_01.Item(32, dgw_doc_01.CurrentRow.Index).Value.ToString
    End Sub
    Function CARGAR_DOC01() As Boolean
        Try
            Dim I As Integer = dgw_doc_01.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
        FILA_DOC = dgw_doc_01.CurrentRow.Index
        LIMPIAR_DOCUMENTOS()
        CARGAR_DOCUMENTO01(0)
        If obj.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text, txt_cta_t01.Text) = False Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Dim CUENTA0 As String = VALIDAR_TRASNF_CUENTA(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text)
            If ((CUENTA0 <> "") And (BOTON <> "NUEVO")) Then
                MessageBox.Show(("No se puede modificar el Documento la Cuenta " & CUENTA0 & " se encuentra Transferida."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            Else
                Return True
            End If
        End If
    End Function
    Function CARGAR_DOC01_CONSULTA() As Boolean
        Try
            Dim I As Integer = dgw_doc_01.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
        FILA_DOC = dgw_doc_01.CurrentRow.Index
        LIMPIAR_DOCUMENTOS()
        CARGAR_DOCUMENTO01(0)
        Return True
    End Function
    Sub CARGAR_DOCUMENTO(ByVal FILA_DOC0 As Integer)
        COD_DOC = (dgw_doc_01.Item(3, FILA_DOC0).Value)
        txt_nro_doc.Text = (dgw_doc_01.Item(4, FILA_DOC0).Value)
        txt_cod_per0.Text = (dgw_doc_01.Item(5, FILA_DOC0).Value)
        txt_desc_per.Text = (dgw_doc_01.Item(6, FILA_DOC0).Value)
        txt_doc_per.Text = (dgw_doc_01.Item(7, FILA_DOC0).Value)
        dtp_doc.Value = Date.Parse(dgw_doc_01.Item(9, FILA_DOC0).Value)
        COD_MONEDA = (dgw_doc_01.Item(20, FILA_DOC0).Value)
        '------------------------------------------------------
        ch_pago.Checked = False
        If dgw_doc_01.Item(34, FILA_DOC0).Value.ToString = "1" Then
            ch_pago.Checked = True
        End If
        '------------------------------------------------------
        cbo_tipo_doc.Text = obj.DESC_DOC(COD_DOC)
        If (txt_cod_per0.Text <> "00000") Then
            txt_desc_per.Text = obj.DESC_PERSONA(txt_cod_per0.Text)
        End If
        cbo_moneda.Text = obj.DESC_MONEDA(COD_MONEDA)
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
            If dgw_det_01.Item(20, l).Value = COD_DOC And dgw_det_01.Item(21, l).Value = txt_nro_doc.Text And dgw_det_01.Item(22, l).Value = txt_cod_per0.Text And dgw_det_01.Item(23, l).Value = txt_doc_per.Text And (dgw_det_01.Item(25, l).Value = "B" Or dgw_det_01.Item(25, l).Value = "I" Or dgw_det_01.Item(25, l).Value = "T") Then
                Dim TIPO_TRANS As Object = dgw_det_01.Item(25, l).Value
                If TIPO_TRANS = "B" Then
                    dgw_mov1.Rows.Add(New Object() {(dgw_det_01.Item(0, l).Value), (dgw_det_01.Item(1, l).Value), (dgw_det_01.Item(2, l).Value), (obj.HACER_DECIMAL((dgw_det_01.Item(3, l).Value))), (obj.HACER_DECIMAL((dgw_det_01.Item(4, l).Value))), (dgw_det_01.Item(5, l).Value), (dgw_det_01.Item(6, l).Value), (dgw_det_01.Item(7, l).Value), (dgw_det_01.Item(8, l).Value), (dgw_det_01.Item(9, l).Value), (dgw_det_01.Item(10, l).Value), (dgw_det_01.Item(11, l).Value), (dgw_det_01.Item(12, l).Value), (dgw_det_01.Item(13, l).Value), (dgw_det_01.Item(14, l).Value), (dgw_det_01.Item(15, l).Value), (dgw_det_01.Item(16, l).Value), (dgw_det_01.Item(17, l).Value), (dgw_det_01.Item(18, l).Value), (dgw_det_01.Item(19, l).Value), (dgw_det_01.Item(26, l).Value), (dgw_det_01.Item(27, l).Value), (dgw_det_01.Item(34, l).Value), (dgw_det_01.Item(38, l).Value), (dgw_det_01.Item(39, l).Value), (dgw_det_01.Item(40, l).Value), (dgw_det_01.Item(41, l).Value)})
                ElseIf TIPO_TRANS = "I" Then
                    txt_cta_igv.Text = dgw_det_01.Item(1, l).Value
                    txt_igv.Text = Double.Parse(dgw_det_01.Item(3, l).Value)
                    If (COD_MONEDA = "D") Then
                        txt_igv.Text = Double.Parse(dgw_det_01.Item(4, l).Value)
                    End If
                    txt_igv.Text = (obj.HACER_DECIMAL(txt_igv.Text))
                    ORDEN_IGV = (dgw_det_01.Item(11, l).Value)
                    cbo_orden_igv.Text = ORDEN_IGV
                    TXT_GLOSA_IGV.Text = dgw_det_01.Item(2, l).Value
                ElseIf TIPO_TRANS = "T" Then
                    txt_cta_total.Text = dgw_det_01.Item(1, l).Value
                    txt_total.Text = Double.Parse(dgw_det_01.Item(3, l).Value)
                    If (COD_MONEDA = "D") Then
                        txt_total.Text = Double.Parse(dgw_det_01.Item(4, l).Value)
                    End If
                    txt_total.Text = obj.HACER_DECIMAL(txt_total.Text)
                    ORDEN_TOTAL = dgw_det_01.Item(11, l).Value
                    TXT_GLOSA_T.Text = dgw_det_01.Item(2, l).Value
                    dtp_vence.Value = Date.Parse(dgw_det_01.Item(12, l).Value)
                    Dim ST As String = (dgw_det_01.Item(13, l).Value)
                    ch_pv.Checked = False
                    If (ST = "1") Then
                        ch_pv.Checked = True
                    End If
                End If
            End If
            l += 1
        Loop
        Try
            'TXT_DIA1.Text = DateDiff(DateInterval.Day, dtp_doc.Value.Date, dtp_vence.Value.Date.AddDays(1))
            TXT_DIA1.Text = DateDiff(DateInterval.Day, dtp_doc.Value.Date, dtp_vence.Value.Date)
        Catch ex As Exception

            TXT_DIA1.Text = (0)
        End Try
        'HALLAR_TOTAL_DOC()
        txt_igv.Text = (obj.HACER_DECIMAL(txt_igv.Text))
        txt_total.Text = (obj.HACER_DECIMAL(txt_total.Text))
        'If (dgw_doc_01.Item(35, FILA_DOC0).Value = "1") Then
        '    cboClasificacionBienesXnDocumento.SelectedIndex = 0
        'ElseIf (dgw_doc_01.Item(35, FILA_DOC0).Value = "2") Then
        '    cboClasificacionBienesXnDocumento.SelectedIndex = 1
        'ElseIf (dgw_doc_01.Item(35, FILA_DOC0).Value = "3") Then
        '    cboClasificacionBienesXnDocumento.SelectedIndex = 2
        'ElseIf (dgw_doc_01.Item(35, FILA_DOC0).Value = "4") Then
        '    cboClasificacionBienesXnDocumento.SelectedIndex = 3
        'ElseIf (dgw_doc_01.Item(35, FILA_DOC0).Value = "5") Then
        '    cboClasificacionBienesXnDocumento.SelectedIndex = 4
        'End If
        'cboClasificacionBienesXnDocumento.Enabled = False
        ValidarCodigoBienes(dgw_doc_01.Item(35, FILA_DOC0).Value, cboClasificacionBienesXnDocumento)
    End Sub
    Sub CARGAR_DOCUMENTO01(ByVal FILA_DOC0 As Integer)
        COD_DOC = (dgw_doc_01.Item(3, FILA_DOC0).Value)
        txt_nro_doc01.Text = (dgw_doc_01.Item(4, FILA_DOC0).Value)
        txt_cod_per01.Text = (dgw_doc_01.Item(5, FILA_DOC0).Value)
        txt_desc_per01.Text = (dgw_doc_01.Item(6, FILA_DOC0).Value)
        txt_doc_per01.Text = (dgw_doc_01.Item(7, FILA_DOC0).Value)
        dtp_doc01.Value = Date.Parse(dgw_doc_01.Item(9, FILA_DOC0).Value)
        COD_MONEDA = (dgw_doc_01.Item(20, FILA_DOC0).Value)
        '---------------------------------------------------
        '------------------------------------------------------
        ch_pago2.Checked = False
        If dgw_doc_01.Item(34, FILA_DOC0).Value.ToString = "1" Then
            ch_pago2.Checked = True
        End If
        '------------------------------------------------------
        txt_nro_det0.Text = (dgw_doc_01.Item(24, FILA_DOC0).Value)
        Try
            txt_tasa0.Text = CInt(dgw_doc_01.Item(25, FILA_DOC0).Value)
        Catch ex As Exception
        End Try
        dtp_det0.Value = Date.Parse(dgw_doc_01.Item(26, FILA_DOC0).Value)
        Dim cod_ref0 = (dgw_doc_01.Item(27, FILA_DOC0).Value)
        cbo_ref0.Text = obj.DESC_DOC(cod_ref0)
        txt_nro_ref0.Text = (dgw_doc_01.Item(28, FILA_DOC0).Value)
        dtp_ref0.Value = Date.Parse(dgw_doc_01.Item(29, FILA_DOC0).Value)
        dtp_pago0.Value = Date.Parse(dgw_doc_01.Item(30, FILA_DOC0).Value)
        ST_PAGO = (dgw_doc_01.Item(31, FILA_DOC0).Value)
        txt_base_ref0.Text = Decimal.Parse(dgw_doc_01.Item(32, FILA_DOC0).Value)
        '---------------------------------------------
        cbo_tipo_doc01.Text = obj.DESC_DOC(COD_DOC)
        If (txt_cod_per01.Text <> "00000") Then
            txt_desc_per01.Text = obj.DESC_PERSONA(txt_cod_per01.Text)
        End If
        cbo_moneda01.Text = obj.DESC_MONEDA(COD_MONEDA)
        txt_cambio01.Text = dgw_doc_01.Item(21, FILA_DOC0).Value.ToString
        cbo_cte.SelectedIndex = 0
        If dgw_doc_01.Item(19, FILA_DOC0).Value.ToString = "0" Then
            cbo_cte.SelectedIndex = 1
        End If
        COD_DH_DOC = (dgw_doc_01.Item(23, FILA_DOC0).Value)
        dgw_mov01.Rows.Clear()
        Dim cont_r_4 As Integer = dgw_det_01.RowCount
        Dim CONT0 As Integer = (cont_r_4 - 1)
        Dim l As Integer = 0
        Do While (l <= CONT0)
            If dgw_det_01.Item(20, l).Value = COD_DOC And dgw_det_01.Item(21, l).Value = txt_nro_doc01.Text And dgw_det_01.Item(22, l).Value = txt_cod_per01.Text And dgw_det_01.Item(23, l).Value = txt_doc_per01.Text And (dgw_det_01.Item(25, l).Value = "B" Or dgw_det_01.Item(25, l).Value = "I" Or dgw_det_01.Item(25, l).Value = "T") Then

                Dim TIPO_T As Object = dgw_det_01.Item(25, l).Value
                If TIPO_T = "B" Then
                    dgw_mov01.Rows.Add((dgw_det_01.Item(0, l).Value), (dgw_det_01.Item(1, l).Value), (dgw_det_01.Item(2, l).Value), (obj.HACER_DECIMAL((dgw_det_01.Item(3, l).Value))), (obj.HACER_DECIMAL((dgw_det_01.Item(4, l).Value))), (dgw_det_01.Item(5, l).Value), (dgw_det_01.Item(6, l).Value), (dgw_det_01.Item(7, l).Value), (dgw_det_01.Item(8, l).Value), (dgw_det_01.Item(9, l).Value), (dgw_det_01.Item(10, l).Value), (dgw_det_01.Item(11, l).Value), (dgw_det_01.Item(12, l).Value), (dgw_det_01.Item(13, l).Value), (dgw_det_01.Item(14, l).Value), (dgw_det_01.Item(15, l).Value), (dgw_det_01.Item(16, l).Value), (dgw_det_01.Item(17, l).Value), (dgw_det_01.Item(18, l).Value), (dgw_det_01.Item(19, l).Value), (dgw_det_01.Item(26, l).Value), (dgw_det_01.Item(27, l).Value), (dgw_det_01.Item(34, l).Value), (dgw_det_01.Item(38, l).Value), (dgw_det_01.Item(39, l).Value), (dgw_det_01.Item(40, l).Value), (dgw_det_01.Item(41, l).Value))
                ElseIf TIPO_T = "I" Then
                    txt_cta_igv01.Text = dgw_det_01.Item(1, l).Value
                    txt_imp_igv01.Text = Double.Parse(dgw_det_01.Item(3, l).Value)
                    If (COD_MONEDA = "D") Then
                        txt_imp_igv01.Text = Double.Parse(dgw_det_01.Item(4, l).Value)
                    End If
                    txt_imp_igv01.Text = obj.HACER_DECIMAL(txt_imp_igv01.Text)
                    ORDEN_IGV = dgw_det_01.Item(11, l).Value
                    cBO_orden_igv01.Text = ORDEN_IGV
                    txt_glosa_igv01.Text = dgw_det_01.Item(2, l).Value
                ElseIf TIPO_T = "T" Then
                    txt_cta_t01.Text = dgw_det_01.Item(1, l).Value
                    txt_imp_total01.Text = Double.Parse(dgw_det_01.Item(3, l).Value)
                    If (COD_MONEDA = "D") Then
                        txt_imp_total01.Text = Double.Parse(dgw_det_01.Item(4, l).Value)
                    End If
                    txt_imp_total01.Text = obj.HACER_DECIMAL(txt_imp_total01.Text)
                    ORDEN_TOTAL = dgw_det_01.Item(11, l).Value
                    txt_glosa_total01.Text = dgw_det_01.Item(2, l).Value
                    dtp_vence01.Value = Date.Parse(dgw_det_01.Item(12, l).Value)
                    Dim ST As String = dgw_det_01.Item(13, l).Value
                    ch_pv01.Checked = False
                    If (ST = "1") Then
                        ch_pv01.Checked = True
                    End If
                End If
            End If
            l += 1
        Loop
        Try
            txt_dias01.Text = DateDiff(DateInterval.Day, dtp_doc01.Value.Date, dtp_vence01.Value.Date)
            'txt_dias01.Text = DateDiff(DateInterval.Day, dtp_doc01.Value, dtp_vence01.Value)
        Catch ex As Exception
            txt_dias01.Text = (0)
        End Try
        'HALLAR_TOTAL_DOC01()
        txt_imp_igv01.Text = (obj.HACER_DECIMAL(txt_imp_igv01.Text))
        txt_imp_total01.Text = (obj.HACER_DECIMAL(txt_imp_total01.Text))
    End Sub
    Sub CBO_ACTIVIDAD()
        If obj.DIR_TABLA_DESC("COS", "TSIST") = "SI" Then
            Try
                Dim GEN As New Genericos
                Dim DT As New DataTable
                DT = GEN.CBO_ACTIVIDAD(con00)
                cbo_act01.DataSource = DT
                cbo_act01.DisplayMember = DT.Columns.Item(0).ToString
                cbo_act01.ValueMember = DT.Columns.Item(1).ToString
                cbo_act01.SelectedIndex = -1
                Dim DT2 As New DataTable
                DT2 = GEN.CBO_ACTIVIDAD(con00)
                cbo_act.DataSource = DT2
                cbo_act.DisplayMember = DT2.Columns.Item(0).ToString
                cbo_act.ValueMember = DT2.Columns.Item(1).ToString
                cbo_act.SelectedIndex = -1
            Catch ex As Exception
            End Try
        End If
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
            lbl_auto.Text = ""
            cbo_auto.Visible = False
        Else
            lbl_auto.Text = "Automaticas"
            cbo_auto.Visible = True
            cbo_auto.SelectedIndex = 0
        End If
    End Sub
    Sub CBO_AUTOMATICAS01(ByVal cod As Object)
        cbo_auto01.Items.Clear()
        Try
            Dim PRO As New SqlCommand("CBO_AUTO_CUENTA", con)
            PRO.CommandType = CommandType.StoredProcedure
            PRO.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = (cod)
            PRO.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            con.Open()
            PRO.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PRO.ExecuteReader
            Do While Rs3.Read
                cbo_auto01.Items.Add((Rs3.GetString(1) & "               " & Rs3.GetString(0)))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (cbo_auto01.Items.Count = 0) Then
            lbl_auto01.Text = ""
            cbo_auto01.Visible = False
        Else
            lbl_auto01.Text = "Automaticas"
            cbo_auto01.Visible = True
            cbo_auto01.SelectedIndex = 0
        End If
    End Sub
    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = cbo_aux.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                CBO_COMPROBANTE()
            End If
        End If
    End Sub
    Private Sub cbo_aux01_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux01.SelectedIndexChanged
        If (cbo_aux01.SelectedIndex <> -1) Then
            COD_AUX = cbo_aux01.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                CBO_COMPROBANTE01()
            End If
        End If
    End Sub
    Sub CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_aux.DataSource = DT
        cbo_aux.DisplayMember = DT.Columns.Item(0).ToString
        cbo_aux.ValueMember = DT.Columns.Item(1).ToString
        cbo_aux.SelectedIndex = -1
        Dim GEN2 As New Genericos
        Dim DT2 As New DataTable
        DT2 = GEN2.CBO_AUX
        cbo_aux01.DataSource = DT2
        cbo_aux01.DisplayMember = DT2.Columns.Item(0).ToString
        cbo_aux01.ValueMember = DT2.Columns.Item(1).ToString
        cbo_aux01.SelectedIndex = -1
    End Sub
    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1 AndAlso cbo_com.SelectedIndex <> -1 AndAlso TabPage3.Parent IsNot Nothing) Then
            COD_AUX = cbo_aux.SelectedValue.ToString
            COD_COMP = cbo_com.SelectedValue.ToString
            If (COD_COMP <> "System.Data.DataRowView") Then
                Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
                If (NUM0 = "") Then
                    MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
                End If
                txt_nro_comp.Text = NUM0
            End If
        End If
    End Sub
    Private Sub cbo_comp01_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_comp01.SelectedIndexChanged
        If (cbo_aux01.SelectedIndex <> -1 And cbo_comp01.SelectedIndex <> -1 AndAlso TabPage2.Parent IsNot Nothing) Then
            COD_AUX = cbo_aux01.SelectedValue.ToString
            COD_COMP = cbo_comp01.SelectedValue.ToString
            If (COD_COMP <> "System.Data.DataRowView") Then
                Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
                If (NUM0 = "") Then
                    MessageBox.Show("No existe numeración para este Comprobante", "Advertencia")
                End If
                txt_nro_comp01.Text = NUM0
            End If
        End If
    End Sub
    Sub CBO_COMPROBANTE()
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
    End Sub
    Sub CBO_COMPROBANTE01()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_comp01.DataSource = DT
        cbo_comp01.DisplayMember = DT.Columns.Item(0).ToString
        cbo_comp01.ValueMember = DT.Columns.Item(1).ToString
        cbo_comp01.SelectedIndex = -1
        If (cbo_comp01.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub CBO_DOCUMENTO()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_doc.Items.Add(Rs3.GetString(0))
                cbo_tipo_doc01.Items.Add(Rs3.GetString(0))
                cbo_ref.Items.Add(Rs3.GetString(0))
                cbo_ref00.Items.Add(Rs3.GetString(0))
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
            If (COD_MONEDA.ToString <> "System.Data.DataRowView") Then
                If (COD_MONEDA = "S") Then
                    txt_cambio.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
                Else
                    txt_cambio.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
                End If
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
        Dim GEN2 As New Genericos
        Dim DT2 As New DataTable
        DT2 = GEN.CBO_MONEDA_COI
        cbo_moneda01.DataSource = DT2
        cbo_moneda01.DisplayMember = DT2.Columns.Item(0).ToString
        cbo_moneda01.ValueMember = DT2.Columns.Item(1).ToString
        cbo_moneda01.SelectedIndex = -1
    End Sub
    Private Sub cbo_moneda01_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda01.SelectedIndexChanged
        If (cbo_moneda01.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda01.SelectedValue.ToString
            If (COD_MONEDA.ToString <> "System.Data.DataRowView") Then
                If (COD_MONEDA = "S") Then
                    txt_cambio01.Text = obj.SACAR_CAMBIO(dtp_doc01.Value.Year, dtp_doc01.Value.ToString("MM"), dtp_doc01.Value.ToString("dd"), "D")
                Else
                    txt_cambio01.Text = obj.SACAR_CAMBIO(dtp_doc01.Value.Year, dtp_doc01.Value.ToString("MM"), dtp_doc01.Value.ToString("dd"), COD_MONEDA)
                End If
            End If
        End If
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
                CBO_PROYECTO01.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CBO_REFERENCIA()
        cbo_tipo_ref.Items.Clear()
        cbo_ref0.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_REF", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_ref.Items.Add(Rs3.GetString(0))
                cbo_ref0.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CH_IGV_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_IGV.CheckedChanged
        If CH_IGV.Checked Then
            'AGREGADO POR CAMBIO DE IGV
            MostrarIgv(dtp_doc)
            TXT_IGV0.Text = (obj.HACER_DECIMAL(IGV0))
        Else
            TXT_IGV0.Text = "0.00"
        End If
    End Sub
    Private Sub ch_igv01_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_igv01.CheckedChanged
        If ch_igv01.Checked Then
            'AGREGADO POR CAMBIO DE IGV
            MostrarIgv(dtp_doc01)
            TXT_IGV01.Text = (IGV0)
        Else
            TXT_IGV01.Text = "0.00"
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
    Function CONTAR_AJUSTE01() As Boolean
        Dim CONT0 As Integer = (dgw_mov01.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT0)
            If (dgw_mov01.Item(6, i).Value.ToString = "A") Then
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
        DT_DOC.Columns.Add("STATUS_GASTO")
        DT_DOC.Columns.Add("COD_BIENES")
        'Para los no domiciliados
        DT_DOC.Columns.Add("COD_MONEDA_ORIGEN")
        DT_DOC.Columns.Add("COD_CONVENIO_DI")
        DT_DOC.Columns.Add("TIPO_RENTA")
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
        DT_DET.Columns.Add("ST_REP")
        DT_DET.Columns.Add("COD_ACTIVIDAD")
    End Sub
    Sub DATAGRID()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ICON_COMPRAS", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Cuentas")
            Prog02.Fill(dt_02)
            dgw1.DataSource = dt_02
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(7).Visible = False
            'dgw1.Columns.Item(8).Visible = False
            dgw1.Columns.Item(1).Width = 150
            dgw1.Columns.Item(3).Width = 200
            dgw1.Columns.Item(6).Width = 50
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DGW_CC0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        CBO_CC.DataSource = DT
        CBO_CC.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC.SelectedIndex = -1
        Dim GEN2 As New Genericos
        Dim DT2 As New DataTable
        DT2 = GEN2.MOSTRAR_CC
        CBO_CC01.DataSource = DT2
        CBO_CC01.DisplayMember = DT2.Columns.Item(0).ToString
        CBO_CC01.ValueMember = DT2.Columns.Item(1).ToString
        CBO_CC01.SelectedIndex = -1
    End Sub
    Private Sub dgw_cta_igv_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_igv.KeyDown
        If (e.KeyData = Keys.Return) Then
            ORDEN_IGV = dgw_cta_igv.Item(4, dgw_cta_igv.CurrentRow.Index).Value.ToString
            cbo_orden_igv.Text = ORDEN_IGV
            txt_cta_igv.Text = dgw_cta_igv.Item(0, dgw_cta_igv.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta_igv.Item(1, dgw_cta_igv.CurrentRow.Index).Value.ToString
            dgw_cta_igv.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            dgw_cta_igv.Visible = False
            txt_cta_igv.Clear()
            txt_desc_cta.Clear()
            txt_cta_igv.Focus()
        End If
    End Sub
    Private Sub dgw_cta_igv01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_igv01.KeyDown
        If (e.KeyData = Keys.Return) Then
            ORDEN_IGV = dgw_cta_igv01.Item(4, dgw_cta_igv01.CurrentRow.Index).Value.ToString
            cBO_orden_igv01.Text = ORDEN_IGV
            txt_cta_igv01.Text = dgw_cta_igv01.Item(0, dgw_cta_igv01.CurrentRow.Index).Value.ToString
            txt_desc_cta_t01.Text = dgw_cta_igv01.Item(1, dgw_cta_igv01.CurrentRow.Index).Value.ToString
            dgw_cta_igv01.Visible = False
            KL01.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            dgw_cta_igv01.Visible = False
            txt_cta_igv01.Clear()
            txt_desc_cta_t01.Clear()
            txt_cta_igv01.Focus()
        End If
    End Sub
    Private Sub dgw_cta_imp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_imp.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_imp.Text = dgw_cta_imp.Item(0, dgw_cta_imp.CurrentRow.Index).Value.ToString
            txt_desc_cta_imp.Text = dgw_cta_imp.Item(1, dgw_cta_imp.CurrentRow.Index).Value.ToString
            STATUS_CC = dgw_cta_imp.Item(2, dgw_cta_imp.CurrentRow.Index).Value.ToString
            STATUS_P = dgw_cta_imp.Item(3, dgw_cta_imp.CurrentRow.Index).Value.ToString
            'ORDEN_BI = dgw_cta_imp.Item(4, dgw_cta_imp.CurrentRow.Index).Value.ToString
            'CBO_ORDEN.Text = ORDEN_BI
            If (BOTON = "NUEVO") Then
                If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                    ORDEN_BI = ConfigDoc.Substring(0, 2)
                    CBO_ORDEN.Text = ORDEN_BI
                Else
                    ORDEN_BI = dgw_cta_imp.Item(4, dgw_cta_imp.CurrentRow.Index).Value.ToString
                    CBO_ORDEN.Text = ORDEN_BI
                End If
            Else
                ORDEN_BI = dgw_cta_imp.Item(4, dgw_cta_imp.CurrentRow.Index).Value.ToString
                CBO_ORDEN.Text = ORDEN_BI
            End If
            txt_glosa.Text = txt_desc_cta_imp.Text
            CBO_CC.SelectedIndex = -1
            CBO_CC.Enabled = False
            cbo_proyecto.SelectedIndex = -1
            cbo_proyecto.Enabled = False
            If (Decimal.Parse(STATUS_CC) = 1) Then
                CBO_CC.Enabled = True
            End If
            If (Decimal.Parse(STATUS_P) = 1) Then
                cbo_proyecto.Enabled = True
            End If
            CBO_AUTOMATICAS(txt_cta_imp.Text)
            kl2.Focus()
            Panel_cta_det.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta_det.Visible = False
            txt_cta_imp.Clear()
            txt_desc_cta_imp.Clear()
            txt_cta_imp.Focus()
        End If
    End Sub
    Private Sub dgw_cta_t_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_t.KeyDown
        If (e.KeyData = Keys.Return) Then
            ORDEN_TOTAL = dgw_cta_t.Item(4, dgw_cta_t.CurrentRow.Index).Value
            txt_cta_total.Text = dgw_cta_t.Item(0, dgw_cta_t.CurrentRow.Index).Value
            txt_desc_cta.Text = dgw_cta_t.Item(1, dgw_cta_t.CurrentRow.Index).Value
            dgw_cta_t.Visible = False
            k2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            dgw_cta_t.Visible = False
            txt_cta_total.Clear()
            txt_desc_cta.Clear()
            txt_cta_total.Focus()
        End If
    End Sub
    Private Sub dgw_cta_t01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_t01.KeyDown
        If (e.KeyData = Keys.Return) Then
            ORDEN_TOTAL = dgw_cta_t01.Item(4, dgw_cta_t01.CurrentRow.Index).Value
            txt_cta_t01.Text = dgw_cta_t01.Item(0, dgw_cta_t01.CurrentRow.Index).Value
            txt_desc_cta_t01.Text = dgw_cta_t01.Item(1, dgw_cta_t01.CurrentRow.Index).Value
            dgw_cta_t01.Visible = False
            KL02.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            dgw_cta_t01.Visible = False
            txt_cta_t01.Clear()
            txt_desc_cta_t01.Clear()
            txt_cta_t01.Focus()
        End If
    End Sub
    Private Sub dgw_cta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta01.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cuenta01.Text = dgw_cta01.Item(0, dgw_cta01.CurrentRow.Index).Value.ToString
            txt_desc_cuenta01.Text = dgw_cta01.Item(1, dgw_cta01.CurrentRow.Index).Value.ToString
            STATUS_CC = dgw_cta01.Item(2, dgw_cta01.CurrentRow.Index).Value.ToString
            STATUS_P = dgw_cta01.Item(3, dgw_cta01.CurrentRow.Index).Value.ToString
            If (BOTON = "NUEVO") Then
                If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                    cbo_orden01.Text = ConfigDoc.Substring(0, 2)
                Else
                    cbo_orden01.Text = dgw_cta01.Item(4, dgw_cta01.CurrentRow.Index).Value.ToString
                End If
            Else
                cbo_orden01.Text = dgw_cta01.Item(4, dgw_cta01.CurrentRow.Index).Value.ToString
            End If
            TXT_GLOSA01.Text = txt_desc_cuenta01.Text
            CBO_CC01.Enabled = False
            CBO_CC01.SelectedIndex = -1
            CBO_PROYECTO01.Enabled = False
            CBO_PROYECTO01.SelectedIndex = -1
            If (Decimal.Parse(STATUS_CC) = 1) Then
                CBO_CC01.Enabled = True
            End If
            If (Decimal.Parse(STATUS_P) = 1) Then
                CBO_PROYECTO01.Enabled = True
            End If
            CBO_AUTOMATICAS01(txt_cod_cuenta01.Text)
            txt_cta01.Focus()
            Panel_cta01.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta01.Visible = False
            txt_cod_cuenta01.Clear()
            txt_desc_cuenta01.Clear()
            txt_cod_cuenta01.Focus()
        End If
    End Sub
    Sub DGW_CUENTAS_CONFIG()
        Try
            dgw_cta_imp.DataSource = obj.MOSTRAR_CUENTAS_CONFIGURADAS("B", AÑO, "C")
            dgw_cta_imp.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_imp.Columns.Item(2).Visible = False
            dgw_cta_imp.Columns.Item(3).Visible = False
            dgw_cta_imp.Columns.Item(4).Visible = False
            dgw_cta_imp.Columns.Item(0).Width = 70
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_igv.DataSource = obj.MOSTRAR_CUENTAS_CONFIGURADAS("I", AÑO, "C")
            dgw_cta_igv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_igv.Columns.Item(2).Visible = False
            dgw_cta_igv.Columns.Item(3).Visible = False
            dgw_cta_igv.Columns.Item(4).Visible = False
            dgw_cta_igv.Columns.Item(0).Width = 70
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_t.DataSource = obj.MOSTRAR_CUENTAS_CONFIGURADAS("T", AÑO, "C")
            dgw_cta_t.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_t.Columns.Item(2).Visible = False
            dgw_cta_t.Columns.Item(3).Visible = False
            dgw_cta_t.Columns.Item(4).Visible = False
            dgw_cta_t.Columns.Item(0).Width = 70
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta01.DataSource = obj.MOSTRAR_CUENTAS_CONFIGURADAS("B", AÑO, "C")
            dgw_cta01.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta01.Columns.Item(2).Visible = False
            dgw_cta01.Columns.Item(3).Visible = False
            dgw_cta01.Columns.Item(4).Visible = False
            dgw_cta01.Columns.Item(0).Width = 70
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_igv01.DataSource = obj.MOSTRAR_CUENTAS_CONFIGURADAS("I", AÑO, "C")
            dgw_cta_igv01.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_igv01.Columns.Item(2).Visible = False
            dgw_cta_igv01.Columns.Item(3).Visible = False
            dgw_cta_igv01.Columns.Item(4).Visible = False
            dgw_cta_igv01.Columns.Item(0).Width = 70
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_t01.DataSource = obj.MOSTRAR_CUENTAS_CONFIGURADAS("T", AÑO, "C")
            dgw_cta_t01.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta_t01.Columns.Item(2).Visible = False
            dgw_cta_t01.Columns.Item(3).Visible = False
            dgw_cta_t01.Columns.Item(4).Visible = False
            dgw_cta_t01.Columns.Item(0).Width = 70
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
    Private Sub dgw_per01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per01.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per01.Text = dgw_per01.Item(0, dgw_per01.CurrentRow.Index).Value.ToString
            txt_desc_per01.Text = dgw_per01.Item(1, dgw_per01.CurrentRow.Index).Value.ToString
            txt_doc_per01.Text = dgw_per01.Item(2, dgw_per01.CurrentRow.Index).Value.ToString
            txt_glosa_igv01.Text = txt_desc_per01.Text
            txt_glosa_total01.Text = txt_desc_per01.Text
            txt_per01.Focus()
            Panel_per01.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_per01.Visible = False
            txt_cod_per01.Clear()
            txt_desc_per01.Clear()
            txt_doc_per01.Clear()
            txt_cod_per01.Focus()
        End If
    End Sub
    Sub DGW_PERSONAS()
        Try
            dgw_per.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception


            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
        Try
            dgw_per01.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per01.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per01.Columns.Item(0).Width = 50
            dgw_per01.Columns.Item(1).Width = &HEB
        Catch ex As Exception

            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub


    Private Sub dtn_s10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dtn_s10.Click, btn_s20.Click, btn_s30.Click, btn_s40.Click
        TabControl2.Visible = False
        btn_nuevo_det01.Focus()
    End Sub

    Private Sub dtp_doc_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_doc.LostFocus
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
        Try
            dtp_vence.Value = dtp_doc.Value.AddDays((TXT_DIA1.Text))
        Catch ex As Exception


            dtp_vence.Value = dtp_doc.Value
            TXT_DIA1.Text = (0)

        End Try
    End Sub

    Private Sub dtp_doc01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_doc01.LostFocus
        If (cbo_moneda01.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda01.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio01.Text = obj.SACAR_CAMBIO(dtp_doc01.Value.Year, dtp_doc01.Value.ToString("MM"), dtp_doc01.Value.ToString("dd"), "D")
            Else
                txt_cambio01.Text = obj.SACAR_CAMBIO(dtp_doc01.Value.Year, dtp_doc01.Value.ToString("MM"), dtp_doc01.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
        Try
            dtp_vence01.Value = dtp_doc01.Value.AddDays(txt_dias01.Text)
        Catch ex As Exception


            dtp_vence01.Value = dtp_doc01.Value
            txt_dias01.Text = (0)

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
            If dgw_det_01.Item(20, I).Value = cod_doc_05 And dgw_det_01.Item(21, I).Value = nro_doc_05 And dgw_det_01.Item(22, I).Value = cod_per_05 And dgw_det_01.Item(23, I).Value = nro_doc_per_05 Then
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
                dgw_det_01.Rows.Add(var0, var14, var2, var3, var4, cod_enlace, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", dtp_doc.Value, 0, " ", 0, 0, "0", "0", "0", "", "", "")
                dgw_det_01.Rows.Add(var0, var15, var2, var3, var4, cod_destino, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", dtp_doc.Value, 0, " ", 0, 0, "0", "0", "0", "", "", "")
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

    Function HALLAR_ITEM01() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_mov01.Rows.Count - 1)
        Dim CONT0 As Integer = cont
        i = 0
        Do While (i <= CONT0)
            If dgw_mov01.Item(0, i).Value > mayor Then
                mayor = Integer.Parse(dgw_mov01.Item(0, i).Value)
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
        Return Decimal.Parse(obj.HACER_DECIMAL(TOTAL_DOC))
    End Function
    Function HALLAR_TOTAL_BI_DOC01() As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov01.RowCount - 1)
        Dim TOTAL_DOC As New Decimal
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim signo As Double = 1
            If (dgw_mov01.Item(5, I).Value.ToString = COD_DH_DOC) Then
                signo = -1
            End If
            If (COD_MONEDA = "S") Then
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, dgw_mov01.Item(3, I).Value)))
            Else
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, dgw_mov01.Item(4, I).Value)))
            End If
            I += 1
        Loop
        Return Decimal.Parse(obj.HACER_DECIMAL(TOTAL_DOC))
    End Function
    Function VERIFICAR_SOLES01() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = dgw_mov01.RowCount - 1
        Dim SOLESD, SOLESH As Decimal

        For I = 0 To CONT
            Dim ñ As String = dgw_mov01.Item(3, I).Value.ToString
            If dgw_mov01.Item(5, I).Value = "D" Then
                SOLESD = SOLESD + (dgw_mov01.Item(3, I).Value)
            Else
                SOLESH = SOLESH + (dgw_mov01.Item(3, I).Value)
            End If
        Next

        '----------------------------------------------
        ' IGV Y TOTAL
        '----------------------------------------------
        Dim imp_s_igv, imp_s_t As Decimal
        imp_s_igv = 0 : imp_s_t = 0
        If (COD_MONEDA = "S") Then
            imp_s_igv = Math.Round(Decimal.Parse(txt_imp_igv01.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_imp_total01.Text), 2)
        Else
            imp_s_igv = Math.Round(Decimal.Parse(txt_imp_igv01.Text * txt_cambio01.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_imp_total01.Text * txt_cambio01.Text), 2)
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
            SOLESD = SOLESD + imp_s_igv
        Else
            SOLESH = SOLESH + imp_s_igv
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
            'ElseIf -0.01 <= SOLESH - SOLESD <= 0.01 Then
            '    Return True
        Else
            MessageBox.Show("Diferencia en soles de " & obj.HACER_DECIMAL((SOLESH - SOLESD)) & " " & DH00, "Existe descuadre en soles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        '----------------------------------------------
    End Function
    Function VERIFICAR_SOLES() As Boolean
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
            SOLESD = SOLESD + imp_s_igv
        Else
            SOLESH = SOLESH + imp_s_igv
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
        '------------------------------------------------
        If SOLESH = SOLESD Then
            Return True
        Else
            MessageBox.Show("Diferencia de soles de " & obj.HACER_DECIMAL((SOLESH - SOLESD)) & " " & DH00, "Existe descuadre en soles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        '----------------------------------------------
    End Function
    Sub HALLAR_TOTAL_DOC()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim TOTAL_IGV As New Decimal
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
                TOTAL_IGV = Decimal.Parse(Decimal.Add(TOTAL_IGV, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(3, I).Value, igv00), 100))))
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(3, I).Value, Decimal.Add(100, igv00)), 100))))

            Else
                TOTAL_IGV = Decimal.Parse(Decimal.Add(TOTAL_IGV, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(4, I).Value, igv00), 100))))
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov1.Item(4, I).Value, Decimal.Add(100, igv00)), 100))))
            End If
            I += 1
        Loop
        txt_igv.Text = (TOTAL_IGV)
        txt_total.Text = (TOTAL_DOC)
        txt_igv.Text = (obj.HACER_DECIMAL(txt_igv.Text))
        txt_total.Text = (obj.HACER_DECIMAL(txt_total.Text))
    End Sub
    Sub HALLAR_TOTAL_DOC01()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov01.RowCount - 1)
        Dim TOTAL_IGV As New Decimal
        Dim TOTAL_DOC As New Decimal
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim igv00 As Decimal = Decimal.Parse(dgw_mov01.Item(22, I).Value.ToString.ToString)
            Dim signo As Double = 1
            If (dgw_mov01.Item(5, I).Value.ToString = COD_DH_DOC) Then
                signo = -1
            End If
            If (COD_MONEDA = "S") Then
                TOTAL_IGV = Decimal.Parse(Decimal.Add(TOTAL_IGV, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov01.Item(3, I).Value, igv00), 100))))
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov01.Item(3, I).Value, Decimal.Add(100, igv00)), 100))))
            Else
                TOTAL_IGV = Decimal.Parse(Decimal.Add(TOTAL_IGV, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov01.Item(4, I).Value, igv00), 100))))
                TOTAL_DOC = Decimal.Parse(Decimal.Add(TOTAL_DOC, Decimal.Multiply(signo, Decimal.Divide(Decimal.Multiply(dgw_mov01.Item(4, I).Value, Decimal.Add(100, igv00)), 100))))
            End If
            I += 1
        Loop
        txt_imp_igv01.Text = (TOTAL_IGV)
        txt_imp_total01.Text = (TOTAL_DOC)
        txt_imp_igv01.Text = (obj.HACER_DECIMAL(txt_imp_igv01.Text))
        txt_imp_total01.Text = (obj.HACER_DECIMAL(txt_imp_total01.Text))
    End Sub
    Sub INSERTAR_DOCUMENTO_DGW()
        Dim imp_d_igv, imp_d_t, imp_igv00, imp_s_igv, imp_s_t, imp_t00 As Decimal
        Dim I As Integer = 0
        Dim cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10 As Decimal
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
        dgw_doc_01.Rows.Add(New Object() {COD_AUX, COD_COMP, txt_nro_comp.Text, COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_desc_per.Text, txt_doc_per.Text, dtp_com.Value, dtp_doc.Value, cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10, COD_MONEDA, txt_cambio.Text, cte_03, COD_DH_DOC, "", 0, dtp_doc.Value, "", "", dtp_doc.Value, dtp_doc.Value, "0", 0, imp_s_t, STATUS_GASTO, CodigoClasificacionBienes, "", "", ""})
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
            Dim var23 As String = (dgw_mov1.Item(23, j).Value)
            Dim var24 As String = (dgw_mov1.Item(24, j).Value)
            Dim var25 As String = (dgw_mov1.Item(25, j).Value) 'COD REF
            Dim var26 As String = (dgw_mov1.Item(26, j).Value) ' NRO REF
            Dim imp_doc00 As New Decimal
            imp_doc00 = Decimal.Parse(var3)
            If (var6 <> "S") Then
                imp_doc00 = Decimal.Parse(var4)
            End If
            dgw_det_01.Rows.Add(var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), _
                var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, var15, var16, var17, var18, var19, COD_DOC, _
                txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, "0", "B", var20, var21, "0", " ", " ", dtp_doc.Value, _
                0, " ", var22, imp_doc00, "0", "0", var23, var24, var25, var26)
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
        '-----------ojo cambie
        Dim CONT00 As Object() = New Object() {(CONT + 2).ToString("0000"), txt_cta_igv.Text, txt_desc_per.Text, _
            Math.Round(imp_s_igv, 2), Math.Round(imp_d_igv, 2), DH_IGV, COD_MONEDA, txt_cambio.Text, " ", " ", " ", _
            ORDEN_IGV, dtp_vence.Value, 0, " ", " ", " ", " ", " ", dtp_doc.Value, COD_DOC, txt_nro_doc.Text, _
            txt_cod_per0.Text, txt_doc_per.Text, 0, "I", "", "", "0", " ", " ", dtp_doc.Value, 0, " ", 0, imp_igv00, _
            "0", "0", "0", "", "", ""}
        dgw_det_01.Rows.Add(CONT00)
        CONT00 = New Object(42) {}
        CONT00(0) = (CONT + 3).ToString("0000")
        CONT00(1) = txt_cta_total.Text
        CONT00(2) = txt_desc_per.Text
        CONT00(3) = Math.Round(imp_s_t, 2)
        CONT00(4) = Math.Round(imp_d_t, 2)
        CONT00(5) = DH_T
        CONT00(6) = COD_MONEDA
        CONT00(7) = txt_cambio.Text
        CONT00(8) = " "
        CONT00(9) = " "
        CONT00(10) = " "
        CONT00(11) = ORDEN_TOTAL
        CONT00(12) = dtp_vence.Value
        CONT00(13) = 0
        CONT00(14) = " "
        CONT00(15) = " "
        CONT00(16) = " "
        CONT00(17) = " "
        CONT00(18) = " "
        CONT00(19) = dtp_doc.Value
        CONT00(20) = COD_DOC
        CONT00(21) = txt_nro_doc.Text
        CONT00(22) = txt_cod_per0.Text
        CONT00(23) = txt_doc_per.Text
        CONT00(24) = 0
        CONT00(25) = "T"
        CONT00(26) = ""
        CONT00(27) = ""
        CONT00(28) = "0"
        CONT00(29) = " "
        CONT00(30) = " "
        CONT00(31) = dtp_doc.Value
        CONT00(32) = 0
        CONT00(33) = " "
        CONT00(34) = 0
        CONT00(35) = imp_t00
        CONT00(36) = "0"
        CONT00(37) = "0"
        CONT00(38) = "0"
        CONT00(39) = ""
        CONT00(&H28) = ""
        CONT00(&H29) = ""
        dgw_det_01.Rows.Add(CONT00)
    End Sub

    Sub INSERTAR_DOCUMENTO_DGW01()
        Dim imp_d_igv, imp_d_t, imp_igv00, imp_s_igv, imp_s_t, imp_t00 As Decimal
        dgw_doc_01.Rows.Clear()
        dgw_det_01.Rows.Clear()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov01.RowCount - 1)
        Dim cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10 As Decimal
        Dim COL As Integer = 3
        'If (COD_MONEDA <> "S") Then
        '    COL = 4
        'End If
        Dim CONT0 As Integer = CONT
        I = 0
        For I = 0 To CONT
            '-------------------------------------------------------
            'DETERMINO EL SIGNO
            Dim SIGNO As Decimal = 1
            If (dgw_mov01.Item(5, I).Value.ToString = COD_DH_DOC) Then
                SIGNO = -1
            End If
            '-------------------------------------------------------
            Dim CONT002 As Object = dgw_mov01.Item(11, I).Value
            Select Case CONT002
                Case "01" : cant01 = cant01 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "02" : cant02 = cant02 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "03" : cant03 = cant03 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "04" : cant04 = cant04 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "05" : cant05 = cant05 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "06" : cant06 = cant06 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "07" : cant07 = cant07 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "08" : cant08 = cant08 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "09" : cant09 = cant09 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
                Case "10" : cant10 = cant10 + Math.Round(dgw_mov01.Item(COL, I).Value * SIGNO, 2)
            End Select
        Next
        '--------------------------------------
        Dim igv00 As Decimal = txt_imp_igv01.Text
        If COD_MONEDA = "S" Then
        Else
            igv00 = Math.Round(Decimal.Parse(txt_imp_igv01.Text * txt_cambio01.Text), 2)
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
            imp_s_igv = Math.Round(Decimal.Parse(txt_imp_igv01.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_imp_total01.Text), 2)
            imp_d_igv = Math.Round(Decimal.Parse(txt_imp_igv01.Text / txt_cambio01.Text), 2)
            imp_d_t = Math.Round(Decimal.Parse(txt_imp_total01.Text / txt_cambio01.Text), 2)
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
            imp_d_igv = Math.Round(Decimal.Parse(txt_imp_igv01.Text), 2)
            imp_d_t = Math.Round(Decimal.Parse(txt_imp_total01.Text), 2)
            imp_s_igv = Math.Round(Decimal.Parse(txt_imp_igv01.Text * txt_cambio01.Text), 2)
            imp_s_t = Math.Round(Decimal.Parse(txt_imp_total01.Text * txt_cambio01.Text), 2)
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
        Dim cod_ref0 As String = ""
        If cbo_ref0.SelectedIndex <> -1 Then cod_ref0 = obj.COD_DOC(cbo_ref0.Text)
        If cboMonedaOrigen.SelectedValue = Nothing Then
            CodigoMonedaOrigen = ""
        Else
            CodigoMonedaOrigen = cboMonedaOrigen.SelectedValue
        End If
        dgw_doc_01.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp01.Text, COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_desc_per01.Text, txt_doc_per01.Text, dtp_comp01.Value, dtp_doc01.Value, cant01, cant02, cant03, cant04, cant05, cant06, cant07, cant08, cant09, cant10, COD_MONEDA, txt_cambio01.Text, cte_03, COD_DH_DOC, txt_nro_det0.Text.ToString, txt_tasa0.Text, dtp_det0.Value.Date, cod_ref0, txt_nro_ref0.Text.ToString, dtp_ref0.Value.Date, dtp_pago0.Value.Date, ST_PAGO, txt_base_ref0.Text, imp_s_t, STATUS_GASTO, CodigoClasificacionBienes, CodigoMonedaOrigen, CodigoConvenio, TipoRenta) 'cualquier cosa regrese aqui
        Dim j As Integer = 0
        Dim CONT1 As Integer = CONT
        j = 0
        Do While (j <= CONT1)
            Dim var0 As String = (dgw_mov01.Item(0, j).Value)
            Dim var1 As String = (dgw_mov01.Item(1, j).Value)
            Dim var2 As String = (dgw_mov01.Item(2, j).Value)
            Dim var3 As String = (dgw_mov01.Item(3, j).Value)
            Dim var4 As String = (dgw_mov01.Item(4, j).Value)
            Dim var5 As String = (dgw_mov01.Item(5, j).Value)
            Dim var6 As String = (dgw_mov01.Item(6, j).Value)
            Dim var7 As String = (dgw_mov01.Item(7, j).Value)
            Dim var8 As String = (dgw_mov01.Item(8, j).Value)
            Dim var9 As String = (dgw_mov01.Item(9, j).Value)
            Dim var10 As String = (dgw_mov01.Item(10, j).Value)
            Dim var11 As String = (dgw_mov01.Item(11, j).Value)
            Dim var12 As DateTime = Date.Parse(dgw_mov01.Item(12, j).Value)
            Dim var13 As String = (dgw_mov01.Item(13, j).Value)
            Dim var14 As String = (dgw_mov01.Item(14, j).Value)
            Dim var15 As String = (dgw_mov01.Item(15, j).Value)
            Dim var16 As String = (dgw_mov01.Item(16, j).Value)
            Dim var17 As String = (dgw_mov01.Item(17, j).Value)
            Dim var18 As String = (dgw_mov01.Item(18, j).Value)
            Dim var19 As DateTime = Date.Parse(dgw_mov01.Item(19, j).Value)
            Dim var20 As String = (dgw_mov01.Item(20, j).Value)
            Dim var21 As String = (dgw_mov01.Item(21, j).Value)
            Dim var22 As String = (dgw_mov01.Item(22, j).Value)
            Dim var23 As String = (dgw_mov01.Item(23, j).Value)
            Dim var24 As String = (dgw_mov01.Item(24, j).Value)
            Dim var25 As String = (dgw_mov01.Item(25, j).Value)
            Dim var26 As String = (dgw_mov01.Item(26, j).Value)
            Dim imp_doc00 As New Decimal
            imp_doc00 = Decimal.Parse(var3)
            If (var6 <> "S") Then
                imp_doc00 = Decimal.Parse(var4)
            End If
            '---------------------
            Dim ST_DETRA, ST_PERCE As String
            If ch_detra.Checked = True Then ST_DETRA = "1" Else ST_DETRA = "0"
            If ch_perce.Checked = True Then ST_PERCE = "1" Else ST_PERCE = "0"
            '-----------------------
            dgw_det_01.Rows.Add(var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, var15, var16, var17, var18, var19, COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text, "0", "B", var20, var21, "0", " ", " ", dtp_doc01.Value, 0, " ", var22, imp_doc00, "0", "0", var23, var24, var25, var26, ST_PERCE, ST_DETRA)
            'dgw_det_01.Rows.Add(New Object() {var0, var15, var2, var3, var4, cod_destino, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", "0", "0", var24, ""})
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
        Dim CONT00 As Object() = New Object() {(CONT + 2).ToString("0000"), txt_cta_igv01.Text, txt_desc_per01.Text, Math.Round(imp_s_igv, 2), Math.Round(imp_d_igv, 2), DH_IGV, COD_MONEDA, txt_cambio01.Text, " ", " ", " ", ORDEN_IGV, dtp_vence01.Value, 0, " ", " ", " ", " ", " ", dtp_doc01.Value, COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text, 0, "I", "", "", "0", " ", " ", dtp_doc01.Value, 0, " ", 0, imp_igv00, "0", "0", "0", "", "", ""}
        dgw_det_01.Rows.Add(CONT00)
        CONT00 = New Object(41) {}
        CONT00(0) = (CONT + 3).ToString("0000")
        CONT00(1) = txt_cta_t01.Text
        CONT00(2) = txt_desc_per01.Text
        CONT00(3) = Math.Round(imp_s_t, 2)
        CONT00(4) = Math.Round(imp_d_t, 2)
        CONT00(5) = DH_T
        CONT00(6) = COD_MONEDA
        CONT00(7) = txt_cambio01.Text
        CONT00(8) = " "
        CONT00(9) = " "
        CONT00(10) = " "
        CONT00(11) = ORDEN_TOTAL
        CONT00(12) = dtp_vence01.Value
        CONT00(13) = 0
        CONT00(14) = " "
        CONT00(15) = " "
        CONT00(16) = " "
        CONT00(17) = " "
        CONT00(18) = " "
        CONT00(19) = dtp_doc01.Value
        CONT00(20) = COD_DOC
        CONT00(21) = txt_nro_doc01.Text
        CONT00(22) = txt_cod_per01.Text
        CONT00(23) = txt_doc_per01.Text
        CONT00(24) = 0
        CONT00(25) = "T"
        CONT00(26) = ""
        CONT00(27) = ""
        CONT00(28) = "0"
        CONT00(29) = " "
        CONT00(30) = " "
        CONT00(31) = dtp_doc01.Value
        CONT00(32) = 0
        CONT00(33) = " "
        CONT00(34) = 0
        CONT00(35) = imp_t00
        CONT00(36) = "0"
        CONT00(37) = "0"
        CONT00(38) = "0"
        CONT00(39) = ""
        CONT00(&H28) = ""
        CONT00(&H29) = ""
        dgw_det_01.Rows.Add(CONT00)
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
                DT_DOC.Rows.Add(AÑO, MES, .Item(3, I).Value, .Item(4, I).Value, .Item(5, I).Value, .Item(7, I).Value, COD_AUX, _
                    COD_COMP, txt_nro_comp.Text, dtp_com.Value, .Item(6, I).Value, DateTime.Parse(.Item(9, I).Value), _
                    .Item(27, I).Value, .Item(28, I).Value, DateTime.Parse(.Item(29, I).Value), Decimal.Parse(.Item(10, I).Value), _
                    Decimal.Parse(.Item(11, I).Value), Decimal.Parse(.Item(12, I).Value), Decimal.Parse(.Item(13, I).Value), _
                    Decimal.Parse(.Item(14, I).Value), Decimal.Parse(.Item(15, I).Value), Decimal.Parse(.Item(16, I).Value), _
                    Decimal.Parse(.Item(17, I).Value), Decimal.Parse(.Item(18, I).Value), Decimal.Parse(.Item(19, I).Value), _
                    .Item(20, I).Value, Decimal.Parse(.Item(21, I).Value), .Item(23, I).Value, .Item(24, I).Value, .Item(25, I).Value, _
                    DateTime.Parse(.Item(26, I).Value), DateTime.Parse(.Item(30, I).Value), .Item(31, I).Value, .Item(32, I).Value, _
                    NOMBRE_PC, .Item(33, I).Value, .Item(34, I).Value, .Item(35, I).Value, .Item(36, I).Value, .Item(37, I).Value, .Item(38, I).Value)
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
            estado = "FALLO"

            Return estado

        End Try
        I = 0
        CONT = (dgw_det_01.RowCount - 1)
        DT_DET.Rows.Clear()
        Dim CONT1 As Integer = CONT
        I = 0
        Do While (I <= CONT1)
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_det_01.Item(20, I).Value, dgw_det_01.Item(21, I).Value, _
                dgw_det_01.Item(22, I).Value, dgw_det_01.Item(23, I).Value, (I + 1).ToString("0000"), DateTime.Parse(dgw_det_01.Item(19, I).Value), _
                dgw_det_01.Item(40, I).Value, dgw_det_01.Item(41, I).Value, DateTime.Parse(dgw_det_01.Item(19, I).Value), _
                dgw_det_01.Item(2, I).Value, dgw_det_01.Item(1, I).Value, Decimal.Parse(dgw_det_01.Item(3, I).Value), _
                Decimal.Parse(dgw_det_01.Item(4, I).Value), dgw_det_01.Item(5, I).Value, dgw_det_01.Item(6, I).Value, _
                Decimal.Parse(dgw_det_01.Item(7, I).Value), dgw_det_01.Item(8, I).Value, dgw_det_01.Item(9, I).Value, _
                dgw_det_01.Item(10, I).Value, dgw_det_01.Item(11, I).Value, DateTime.Parse(dgw_det_01.Item(12, I).Value), _
                dgw_det_01.Item(13, I).Value, dgw_det_01.Item(14, I).Value, dgw_det_01.Item(15, I).Value, dgw_det_01.Item(24, I).Value, _
                dgw_det_01.Item(25, I).Value, dgw_det_01.Item(37, I).Value, dgw_det_01.Item(28, I).Value, dgw_det_01.Item(29, I).Value, _
                dgw_det_01.Item(30, I).Value, DateTime.Parse(dgw_det_01.Item(31, I).Value), dgw_det_01.Item(32, I).Value, _
                dgw_det_01.Item(33, I).Value, dgw_det_01.Item(36, I).Value, dtp_com.Value, Decimal.Parse(dgw_det_01.Item(34, I).Value), _
                NOMBRE_PC, dgw_det_01.Item(38, I).Value, dgw_det_01.Item(39, I).Value)
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
        Dim ST_DETRA, ST_PERCE As String
        If ch_detra.Checked = True Then ST_DETRA = "1" Else ST_DETRA = "0"
        If ch_perce.Checked = True Then ST_PERCE = "1" Else ST_PERCE = "0"
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_COMPRAS_CAMBIADO", con)
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
            comand1.Parameters.Add("@ST_PERCEPCION", SqlDbType.Char).Value = ST_PERCE
            comand1.Parameters.Add("@ST_DETRACCION", SqlDbType.Char).Value = ST_DETRA
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
        ST_PLA = "0"
        Panel2.Enabled = True
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        Dim DESC0 As String = cbo_com.Text.ToString
        cbo_com.SelectedIndex = -1
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
        TabControl3.Visible = False
        Panel_DOC02.Visible = False
        Panel2.Enabled = True
        '
        cboClasificacionBienesXnDocumento.Enabled = True
        cboClasificacionBienesXnDocumento.SelectedIndex = -1
    End Sub
    Sub LIMPIAR_COMPROBANTE01()
        ch_perce.Checked = False
        ch_detra.Checked = False
        txt_imp_igv01.ReadOnly = True
        ch_mod2.Checked = False
        ST_PLA = "0"
        g_cab01.Enabled = True
        txt_nro_comp01.Clear()
        Dim DESC0 As String = cbo_comp01.Text.ToString
        cbo_comp01.SelectedIndex = -1
        cbo_comp01.Text = DESC0
        dtp_comp01.Value = FECHA_GRAL
        dgw_mov01.Rows.Clear()
        ESTADO_AUTO = "NO"
        btn_imprimir01.Enabled = False
        btn_grabar_com01.Visible = True
        btn_grabar_com012.Visible = False
        dgw_doc_01.Rows.Clear()
        btn_grabar_com01.Enabled = True
        dgw_det_01.Rows.Clear()
        Panel201.Enabled = True
        panel01.Enabled = True
        txt_nro_doc01.Clear()
        txt_cod_per01.Clear()
        txt_desc_per01.Clear()
        txt_doc_per01.Clear()
        txt_dias01.Text = (0)
        ch_pv01.Checked = False
        dgw_mov01.Rows.Clear()
        Panel_det01.Visible = False
        txt_cta_igv01.Clear()
        txt_cta_t01.Clear()
        txt_desc_cta_t01.Clear()
        txt_imp_igv01.Text = "0.00"
        txt_imp_total01.Text = "0.00"
        txt_glosa_igv01.Clear()
        txt_glosa_total01.Clear()
        Panel_per01.Visible = False
        dgw_cta_igv.Visible = False
        dgw_cta_t.Visible = False
        txt_cta_igv01.Text = obj.DIR_TABLA_DESC("PCOM_IGV", "TDCTA")
        ORDEN_IGV = obj.HALLAR_ORDEN_CUENTA("I", AÑO, "C", txt_cta_igv01.Text)
        cBO_orden_igv01.Text = ORDEN_IGV
        txt_cta_t01.Text = obj.DIR_TABLA_DESC("PCOM_TOT", "TDCTA")
        ORDEN_TOTAL = obj.HALLAR_ORDEN_CUENTA("T", AÑO, "C", txt_cta_t01.Text)
        '--------------------------
        ST_PAGO = "0"
        dtp_det0.Value = FECHA_GRAL
        dtp_ref0.Value = FECHA_GRAL
        dtp_pago0.Value = FECHA_GRAL
        txt_tasa0.Text = "0.00"
        txt_base_ref0.Text = "0.00"
        txt_nro_det0.Clear()
        cbo_ref0.SelectedIndex = -1
        txt_nro_ref0.Clear()
        TabControl2.Visible = False
        '--------------------------
        Panel201.Enabled = True
        btn_nuevo_comp01.Enabled = True
        btn_grabar_com01.Enabled = True
        btn_grabar_com012.Enabled = True
        '
        cboClasificacionBienesxDocumento.Enabled = True
        cboClasificacionBienesxDocumento.SelectedIndex = -1
        cboMonedaOrigen.SelectedIndex = -1
        cboConvenios.SelectedIndex = -1
        cboTipoRenta.SelectedIndex = -1
    End Sub
    Sub LIMPIAR_DETALLES()
        txt_cta_imp.Enabled = True
        txt_desc_cta_imp.Enabled = True
        cbo_auto.Enabled = True
        txt_cta_imp.Clear()
        cbo_auto.SelectedIndex = -1
        txt_desc_cta_imp.Clear()
        txt_bi.Clear()
        cbo_d_h.Text = "D"
        ch_rep.Checked = False
        If (COD_DH_DOC = "D") Then
            cbo_d_h.Text = "H"
        End If
        txt_glosa.Clear()
        CH_IGV.Checked = True
        'If (BOTON = "NUEVO") Then
        If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
            CH_IGV.Checked = (ConfigDoc.Substring(4, 1) = "S" AndAlso Not ch_pago.Checked)
        Else
            CH_IGV.Checked = True
        End If
        'Else
        'CH_IGV.Checked = True
        'End If

        'AGREGADO POR CAMBIO DE IGV
        'MostrarIgv(dtp_doc)
        'TXT_IGV0.Text = (obj.HACER_DECIMAL(IGV0))
        ch_rep2.Checked = False

        CBO_CC.Enabled = False
        CBO_CC.SelectedIndex = -1
        cbo_proyecto.Enabled = False
        cbo_proyecto.SelectedIndex = -1
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        Panel_cta_det.Visible = False
        cbo_act.SelectedIndex = -1
        lbl_moneda_det.Text = cbo_moneda.Text
        txt_nro_ord_prod.Clear()
        cbo_act.SelectedIndex = -1
        cbo_ref.SelectedIndex = -1
        txt_ref.Clear()

        'If ch_pago.Checked = True Then
        '    CH_IGV.Checked = False
        '    CH_IGV.Enabled = False
        'Else
        '    CH_IGV.Enabled = True
        'End If
    End Sub
    Sub LIMPIAR_DETALLES01()

        txt_cod_cuenta01.Enabled = True
        txt_desc_cuenta01.Enabled = True
        cbo_auto01.Enabled = True
        txt_cod_cuenta01.Clear()
        cbo_auto01.SelectedIndex = -1
        txt_desc_cuenta01.Clear()
        ch_rep.Checked = False

        txt_bi01.Clear()
        CBO_D_H01.Text = "D"
        If (COD_DH_DOC = "D") Then
            CBO_D_H01.Text = "H"
        End If
        TXT_GLOSA01.Clear()
        'ch_igv01.Checked = True
        'If (BOTON = "NUEVO") Then
        If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
            ch_igv01.Checked = (ConfigDoc.Substring(4, 1) = "S" AndAlso Not ch_pago2.Checked)
        Else
            ch_igv01.Checked = True
        End If
        'Else
        'ch_igv01.Checked = True
        'End If

        'AGREGADO POR CAMBIO DE IGV
        'MostrarIgv(dtp_doc01)

        'TXT_IGV01.Text = (obj.HACER_DECIMAL(IGV0))
        Panel_cta01.Visible = False
        CBO_CC01.Enabled = False
        CBO_CC01.SelectedIndex = -1
        CBO_PROYECTO01.Enabled = False
        CBO_PROYECTO01.SelectedIndex = -1
        txt_nro_req.Clear()
        lbl_moneda01.Text = cbo_moneda01.Text
        BTN_GUARDAR_DET01.Visible = True
        btn_mod_det012.Visible = False
        cbo_act01.SelectedIndex = -1
        cbo_ref00.SelectedIndex = -1
        txt_ref00.Clear()
        'If ch_pago2.Checked = True Then
        '    ch_igv01.Checked = False
        '    ch_igv01.Enabled = False
        'Else
        '    ch_igv01.Enabled = True
        'End If
    End Sub
    Sub LIMPIAR_DOCUMENTOS()
        ch_mod.Checked = False
        txt_igv.ReadOnly = True
        panel1.Enabled = True
        txt_nro_doc.Clear()
        txt_cod_per0.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        ch_pv.Checked = False
        dgw_mov1.Rows.Clear()
        Panel_det02.Visible = False
        txt_cta_igv.Clear()
        txt_cta_total.Clear()
        txt_desc_cta.Clear()
        txt_igv.Text = "0.00"
        txt_total.Text = "0.00"
        TXT_GLOSA_IGV.Clear()
        TXT_GLOSA_T.Clear()
        Panel_per.Visible = False
        btn_grabar_doc.Visible = True
        btn_grabar_doc2.Visible = False
        panel01.Enabled = True
        txt_nro_doc01.Clear()
        txt_cod_per01.Clear()
        txt_desc_per01.Clear()
        txt_doc_per01.Clear()
        txt_dias01.Text = (0)
        dtp_vence01.Value = Now.Date
        ch_pv01.Checked = True
        dgw_mov01.Rows.Clear()
        Panel_det01.Visible = False
        txt_cta_igv01.Clear()
        txt_cta_t01.Clear()
        txt_desc_cta_t01.Clear()
        txt_imp_igv01.Text = "0.00"
        txt_imp_total01.Text = "0.00"
        txt_glosa_igv01.Clear()
        txt_glosa_total01.Clear()
        Panel_per01.Visible = False
        dgw_cta_igv.Visible = False
        dgw_cta_t.Visible = False
        txt_cta_igv.Text = obj.DIR_TABLA_DESC("PCOM_IGV", "TDCTA")
        txt_cta_total.Text = obj.DIR_TABLA_DESC("PCOM_TOT", "TDCTA")
        ORDEN_IGV = obj.HALLAR_ORDEN_CUENTA("I", AÑO, "C", txt_cta_igv.Text)
        cbo_orden_igv.Text = ORDEN_IGV
        ORDEN_TOTAL = obj.HALLAR_ORDEN_CUENTA("T", AÑO, "C", txt_cta_total.Text)
        '--------------------------
        ST_PAGO = "0"
        dtp_det.Value = FECHA_GRAL
        dtp_ref.Value = FECHA_GRAL
        dtp_pago.Value = FECHA_GRAL
        txt_tasa_det.Text = "0.00"
        txt_base_ref.Text = "0.00"
        txt_cod_det.Clear()
        cbo_tipo_ref.SelectedIndex = -1
        txt_nro_ref.Clear()
        ch_pago.Checked = False
        TabControl3.Visible = False
        '--------------------------
        cboClasificacionBienesXnDocumento.SelectedIndex = -1
        cboClasificacionBienesXnDocumento.Enabled = True
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
            DT_DOC.Rows.Add(AÑO, MES, (dgw_doc_01.Item(3, I).Value), (dgw_doc_01.Item(4, I).Value), (dgw_doc_01.Item(5, I).Value), (dgw_doc_01.Item(7, I).Value), COD_AUX, COD_COMP, txt_nro_comp.Text, dtp_com.Value, (dgw_doc_01.Item(6, I).Value), DateTime.Parse((dgw_doc_01.Item(9, I).Value)), dgw_doc_01.Item(27, I).Value.ToString, dgw_doc_01.Item(28, I).Value.ToString, DateTime.Parse((dgw_doc_01.Item(29, I).Value)), Decimal.Parse((dgw_doc_01.Item(10, I).Value)), Decimal.Parse((dgw_doc_01.Item(11, I).Value)), Decimal.Parse((dgw_doc_01.Item(12, I).Value)), Decimal.Parse((dgw_doc_01.Item(13, I).Value)), Decimal.Parse((dgw_doc_01.Item(14, I).Value)), Decimal.Parse((dgw_doc_01.Item(15, I).Value)), Decimal.Parse((dgw_doc_01.Item(16, I).Value)), Decimal.Parse((dgw_doc_01.Item(17, I).Value)), Decimal.Parse((dgw_doc_01.Item(18, I).Value)), Decimal.Parse((dgw_doc_01.Item(19, I).Value)), (dgw_doc_01.Item(20, I).Value), Decimal.Parse((dgw_doc_01.Item(21, I).Value)), (dgw_doc_01.Item(23, I).Value), (dgw_doc_01.Item(24, I).Value), (dgw_doc_01.Item(25, I).Value), DateTime.Parse((dgw_doc_01.Item(26, I).Value)), DateTime.Parse((dgw_doc_01.Item(30, I).Value)), (dgw_doc_01.Item(31, I).Value), (dgw_doc_01.Item(32, I).Value), NOMBRE_PC, (dgw_doc_01.Item(33, I).Value), dgw_doc_01.Item(34, I).Value.ToString, dgw_doc_01.Item(35, I).Value, dgw_doc_01.Item(36, I).Value, dgw_doc_01.Item(37, I).Value,dgw_doc_01.Item(38, I).Value)
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
        Dim CONT1 As Integer = CONT
        I = 0
        Do While (I <= CONT1)
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), dgw_det_01.Item(40, I).Value, dgw_det_01.Item(41, I).Value, DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC, dgw_det_01.Item(38, I).Value.ToString, dgw_det_01.Item(39, I).Value.ToString)
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
        Dim ST_DETRA, ST_PERCE As String
        If ch_detra.Checked = True Then ST_DETRA = "1" Else ST_DETRA = "0"
        If ch_perce.Checked = True Then ST_PERCE = "1" Else ST_PERCE = "0"
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_COMPRAS_CAMBIADO", con)
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
            comand1.Parameters.Add("@ST_PERCEPCION", SqlDbType.Char).Value = ST_PERCE
            comand1.Parameters.Add("@ST_DETRACCION", SqlDbType.Char).Value = ST_DETRA
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

    Private Sub PROV_COMPRAS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub PROV_COMPRAS_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub
    Private Sub PROV_COMPRAS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Sub CARGAR_CBO_ORDEN()
        CBO_ORDEN.Items.Clear()
        cbo_orden01.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_ORDEN00", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "C"
            'PROG_01.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = "B"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                CBO_ORDEN.Items.Add(Rs3.GetString(0))
                cbo_orden01.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        ' CBO IGV

        cbo_orden_igv.Items.Clear()
        cBO_orden_igv01.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_ORDEN00", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "C"
            'PROG_01.Parameters.Add("@TIPO_ORDEN", SqlDbType.Char).Value = "I"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_orden_igv.Items.Add(Rs3.GetString(0))
                cBO_orden_igv01.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PROV_COMPRAS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CREAR_DATASET()
        CBO_AUXILIAR()
        CBO_DOCUMENTO()
        DGW_PERSONAS()
        CBO_MONEDA0()
        CBO_REFERENCIA()
        CBO_ACTIVIDAD()
        CARGAR_CBO_ORDEN()
        DGW_CUENTAS_CONFIG()
        IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
        DGW_CC0()
        CBO_PROYECTO0()
        dgw_doc_01.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw_mov01.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        btn_nuevo2.Select()
        CargarMonedas()
    End Sub
    Private Sub txt_base_ref0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_base_ref0.KeyPress
        e.Handled = Numero(e, txt_base_ref0)
    End Sub
    Private Sub txt_base_ref0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_base_ref0.LostFocus
        Try
            txt_base_ref0.Text = (obj.HACER_DECIMAL(txt_base_ref0.Text))
        Catch ex As Exception
            txt_base_ref0.Text = "0.00"
        End Try
    End Sub
    Private Sub txt_bi_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_bi.KeyPress
        e.Handled = Numero(e, txt_bi)
    End Sub
    Private Sub txt_bi_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_bi.LostFocus
        Try
            txt_bi.Text = obj.HACER_DECIMAL(txt_bi.Text)
        Catch ex As Exception
            txt_bi.Text = "0.00"
        End Try
    End Sub
    Private Sub txt_bi01_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_bi01.KeyPress
        e.Handled = Numero(e, txt_bi01)
    End Sub
    Private Sub txt_bi01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_bi01.LostFocus
        Try
            txt_bi01.Text = obj.HACER_DECIMAL(txt_bi01.Text)
        Catch ex As Exception
            txt_bi01.Text = "0.00"
        End Try
    End Sub
    Private Sub txt_cambio_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio.KeyPress
        e.Handled = Numero(e, txt_cambio)
    End Sub
    Private Sub txt_cambio_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio.LostFocus
        Try
            txt_cambio.Text = obj.HACER_CAMBIO(txt_cambio.Text)
        Catch ex As Exception
            txt_cambio.Text = "0.0000"
        End Try
    End Sub
    Private Sub txt_cambio01_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio01.KeyPress
        e.Handled = Numero(e, txt_cambio01)
    End Sub
    Private Sub txt_cambio01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio01.LostFocus
        Try
            txt_cambio01.Text = obj.HACER_CAMBIO(txt_cambio01.Text)
        Catch ex As Exception
            txt_cambio01.Text = "0.0000"
        End Try
    End Sub
    Private Sub TXT_cod_cuenta01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cuenta01.LostFocus
        If (Strings.Trim(txt_cod_cuenta01.Text) <> "") Then
            If (dgw_cta01.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta01.Sort(dgw_cta01.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cuenta01.Text.ToLower = dgw_cta01.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cuenta01.Text = dgw_cta01.Item(0, i).Value.ToString
                        txt_desc_cuenta01.Text = dgw_cta01.Item(1, i).Value.ToString
                        STATUS_CC = dgw_cta01.Item(2, i).Value.ToString
                        STATUS_P = dgw_cta01.Item(3, i).Value.ToString
                        If (BOTON = "NUEVO") Then
                            If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                                cbo_orden01.Text = ConfigDoc.Substring(0, 2)
                            End If
                        Else
                            cbo_orden01.Text = dgw_cta01.Item(4, dgw_cta01.CurrentRow.Index).Value.ToString
                        End If
                        TXT_GLOSA01.Text = txt_desc_cuenta01.Text
                        CBO_CC01.Enabled = False
                        CBO_CC01.SelectedIndex = -1
                        CBO_PROYECTO01.Enabled = False
                        CBO_PROYECTO01.SelectedIndex = -1
                        If (Decimal.Parse(STATUS_CC) = 1) Then
                            CBO_CC01.Enabled = True
                        End If
                        If (Decimal.Parse(STATUS_P) = 1) Then
                            CBO_PROYECTO01.Enabled = True
                        End If
                        CBO_AUTOMATICAS01(txt_cod_cuenta01.Text)
                        SendKeys.Send("{Tab}")
                        Return
                    End If
                    If (txt_cod_cuenta01.Text.ToLower = Strings.Mid((dgw_cta01.Item(0, i).Value), 1, Strings.Len(txt_cod_cuenta01.Text)).ToLower) Then
                        dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta01.Visible = True
                dgw_cta01.Visible = True
                dgw_cta01.Focus()
            End If
        End If
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
    Private Sub TXT_COD_PER01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per01.LostFocus
        If (Strings.Trim(txt_cod_per01.Text) <> "") Then
            If (dgw_per01.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per01.Sort(dgw_per01.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_per01.Text.ToLower = dgw_per01.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per01.Text = dgw_per01.Item(0, i).Value.ToString
                        txt_desc_per01.Text = dgw_per01.Item(1, i).Value.ToString
                        txt_doc_per01.Text = dgw_per01.Item(2, i).Value.ToString
                        txt_glosa_igv01.Text = txt_desc_per01.Text
                        txt_glosa_total01.Text = txt_desc_per01.Text
                        cbo_moneda01.Focus()
                        Return
                    End If
                    If (txt_cod_per01.Text.ToLower = Strings.Mid((dgw_per01.Item(0, i).Value), 1, Strings.Len(txt_cod_per01.Text)).ToLower) Then
                        dgw_per01.CurrentCell = dgw_per01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per01.CurrentCell = dgw_per01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per01.Visible = True
                dgw_per01.Visible = True
                dgw_per01.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_igv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_igv.Click
        If (txt_cta_igv.Text.Trim <> "") Then
            txt_desc_cta.Text = obj.DESC_CUENTA(txt_cta_igv.Text, AÑO)
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
                    ORDEN_IGV = dgw_cta_igv.Item(4, i).Value.ToString
                    txt_cta_igv.Text = dgw_cta_igv.Item(0, i).Value.ToString
                    txt_desc_cta.Text = dgw_cta_igv.Item(1, i).Value.ToString
                    TXT_GLOSA_IGV.Focus()
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
    Private Sub txt_cta_igv01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_igv01.Click
        If (txt_cta_igv01.Text.Trim <> "") Then
            txt_desc_cta_t01.Text = obj.DESC_CUENTA(txt_cta_igv01.Text, AÑO)
        End If
    End Sub
    Private Sub txt_cta_igv01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_igv01.LostFocus
        If (dgw_cta_igv01.RowCount = 0) Then
            MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cta_igv01.Sort(dgw_cta_igv01.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim CONT0 As Integer = (dgw_cta_igv01.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= CONT0)
                If (txt_cta_igv01.Text.ToLower = dgw_cta_igv01.Item(0, i).Value.ToString.ToLower) Then
                    ORDEN_IGV = dgw_cta_igv01.Item(4, i).Value.ToString
                    txt_cta_igv01.Text = dgw_cta_igv01.Item(0, i).Value.ToString
                    txt_desc_cta_t01.Text = dgw_cta_igv01.Item(1, i).Value.ToString
                    txt_glosa_igv01.Focus()
                    Return
                End If
                If (txt_cta_igv01.Text.ToLower = Strings.Mid((dgw_cta_igv01.Item(0, i).Value), 1, Strings.Len(txt_cta_igv01.Text)).ToLower) Then
                    dgw_cta_igv01.CurrentCell = dgw_cta_igv01.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                dgw_cta_igv01.CurrentCell = dgw_cta_igv01.Rows.Item(0).Cells.Item(0)
                i += 1
            Loop
            dgw_cta_igv01.Visible = True
            dgw_cta_igv01.Focus()
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
                        'ORDEN_BI = dgw_cta_imp.Item(4, i).Value.ToString
                        'CBO_ORDEN.Text = ORDEN_BI
                        If (BOTON = "NUEVO") Then
                            If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                                ORDEN_BI = ConfigDoc.Substring(0, 2)
                                CBO_ORDEN.Text = ORDEN_BI
                            End If
                        Else
                            ORDEN_BI = dgw_cta_imp.Item(4, i).Value
                            CBO_ORDEN.Text = ORDEN_BI
                        End If
                        txt_glosa.Text = txt_desc_cta_imp.Text
                        CBO_CC.SelectedIndex = -1
                        CBO_CC.Enabled = False
                        cbo_proyecto.SelectedIndex = -1
                        cbo_proyecto.Enabled = False
                        If (Decimal.Parse(STATUS_CC) = 1) Then
                            CBO_CC.Enabled = True
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
    Private Sub txt_cta_t01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_t01.Click
        If (txt_cta_t01.Text.Trim <> "") Then
            txt_desc_cta_t01.Text = obj.DESC_CUENTA(txt_cta_t01.Text, AÑO)
        End If
    End Sub
    Private Sub txt_cta_t01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_t01.LostFocus
        If (dgw_cta_t01.RowCount = 0) Then
            MessageBox.Show("No existen Cuentas.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cta_t01.Sort(dgw_cta_t01.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim CONT0 As Integer = (dgw_cta_t01.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= CONT0)
                If (txt_cta_t01.Text.ToLower = dgw_cta_t01.Item(0, i).Value.ToString.ToLower) Then
                    ORDEN_TOTAL = dgw_cta_t01.Item(4, i).Value
                    txt_cta_t01.Text = dgw_cta_t01.Item(0, i).Value
                    txt_desc_cta_t01.Text = dgw_cta_t01.Item(1, i).Value
                    txt_glosa_total01.Focus()
                    Return
                End If
                If (txt_cta_t01.Text.ToLower = Strings.Mid((dgw_cta_t01.Item(0, i).Value), 1, Strings.Len(txt_cta_t01.Text)).ToLower) Then
                    dgw_cta_t01.CurrentCell = dgw_cta_t01.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                dgw_cta_t01.CurrentCell = dgw_cta_t01.Rows.Item(0).Cells.Item(0)
                i += 1
            Loop
            dgw_cta_t01.Visible = True
            dgw_cta_t01.Focus()
        End If
    End Sub
    Private Sub txt_cta_total_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_total.Click
        If (txt_cta_total.Text.Trim <> "") Then
            txt_desc_cta.Text = obj.DESC_CUENTA(txt_cta_total.Text, AÑO)
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
                    ORDEN_TOTAL = dgw_cta_t.Item(4, i).Value.ToString
                    txt_cta_total.Text = dgw_cta_t.Item(0, i).Value
                    txt_desc_cta.Text = dgw_cta_t.Item(1, i).Value
                    TXT_GLOSA_T.Focus()
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
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_imp.Sort(dgw_cta_imp.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta_imp.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
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
    Private Sub TXT_desc_cuenta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cuenta01.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cuenta01.Text) <> "")) Then
            If (dgw_cta01.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta01.Sort(dgw_cta01.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cuenta01.Text.ToLower = Strings.Mid((dgw_cta01.Item(1, i).Value), 1, Strings.Len(txt_desc_cuenta01.Text)).ToLower) Then
                        dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta01.Visible = True
                dgw_cta01.Visible = True
                dgw_cta01.Focus()
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
    Private Sub TXT_DESC_PER01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per01.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per01.Text) <> "")) Then
            If (dgw_per01.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per01.Sort(dgw_per01.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_per01.Text.ToLower = Strings.Mid((dgw_per01.Item(1, i).Value), 1, Strings.Len(txt_desc_per01.Text)).ToLower) Then
                        dgw_per01.CurrentCell = dgw_per01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per01.CurrentCell = dgw_per01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per01.Visible = True
                dgw_per01.Visible = True
                dgw_per01.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DIA1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_DIA1.TextChanged
        Try
            dtp_vence.Value = dtp_doc.Value.AddDays((TXT_DIA1.Text))
        Catch ex As Exception
            dtp_vence.Value = dtp_doc.Value
            TXT_DIA1.Text = (0)
        End Try
    End Sub
    Private Sub txt_dias01_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_dias01.TextChanged
        Try
            dtp_vence01.Value = dtp_doc01.Value.AddDays(txt_dias01.Text)
        Catch ex As Exception


            dtp_vence01.Value = dtp_doc01.Value
            txt_dias01.Text = (0)

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
    Private Sub txt_doc_per01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per01.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per01.Text) <> "")) Then
            If (dgw_per01.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per01.Sort(dgw_per01.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per01.Text.ToLower = Strings.Mid((dgw_per01.Item(2, i).Value), 1, Strings.Len(txt_doc_per01.Text)).ToLower) Then
                        dgw_per01.CurrentCell = dgw_per01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per01.CurrentCell = dgw_per01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_per01.Visible = True
                dgw_per01.Visible = True
                dgw_per01.Focus()
            End If
        End If
    End Sub
    Private Sub txt_igv_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_igv.KeyPress
        e.Handled = Numero(e, txt_igv)
    End Sub
    Private Sub txt_igv_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_igv.LostFocus
        Try
            txt_igv.Text = (obj.HACER_DECIMAL(txt_igv.Text))
            txt_total.Text = txt_igv.Text + HALLAR_TOTAL_BI_DOC()
            txt_total.Text = obj.HACER_DECIMAL(txt_total.Text)
        Catch ex As Exception
            HALLAR_TOTAL_DOC()
        End Try
    End Sub
    Private Sub txt_tasa0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_tasa0.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    'Private Sub txt_tasa0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_tasa0.LostFocus
    '    Try
    '        txt_tasa0.Text = (obj.HACER_DECIMAL(txt_tasa0.Text))
    '    Catch ex As Exception
    '        txt_tasa0.Text = "0.00"
    '    End Try
    'End Sub
    Private Sub txt_total_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_total.KeyPress
        e.Handled = Numero(e, txt_total)
    End Sub
    Private Sub txt_total_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_total.LostFocus
        Try
            txt_total.Text = (obj.HACER_DECIMAL(txt_total.Text))
        Catch ex As Exception
            HALLAR_TOTAL_DOC()
        End Try
    End Sub
    Function VALIDAR_DOLARES01(ByVal S_DEBE0 As Decimal, ByVal S_HABER0 As Decimal, ByVal CAMBIO0 As Decimal) As Boolean
        Dim D_BI_DEBE As Decimal
        Dim D_BI_HABER As Decimal
        Dim D_DEBE As New Decimal
        Dim D_HABER As New Decimal
        Dim D_SALDO As New Decimal
        Dim S_SALDO As New Decimal
        DESCUADRE.DGW.Rows.Clear()
        D_DEBE = Math.Round(Decimal.Divide(S_DEBE0, CAMBIO0), 2)
        D_HABER = Math.Round(Decimal.Divide(S_HABER0, CAMBIO0), 2)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (dgw_mov01.Item(5, I).Value.ToString = "D") Then
                D_BI_DEBE = Decimal.Parse(Decimal.Add(D_BI_DEBE, dgw_mov01.Item(4, I).Value))
            Else
                D_BI_HABER = Decimal.Parse(Decimal.Add(D_BI_HABER, dgw_mov01.Item(4, I).Value))
            End If
            I += 1
        Loop
        D_DEBE = Decimal.Add(D_DEBE, D_BI_DEBE)
        D_HABER = Decimal.Add(D_HABER, D_BI_HABER)
        D_SALDO = Math.Round(Decimal.Subtract(D_DEBE, D_HABER), 2)
        S_DEBE0 = Decimal.Add(S_DEBE0, HALLAR_TOTAL_BI_DOC01)
        S_SALDO = Math.Round(Decimal.Subtract(S_DEBE0, S_HABER0), 2)
        DESCUADRE.DGW.Rows.Add(New Object() {"DEBE", 0, 0})
        DESCUADRE.DGW.Rows.Add(New Object() {"HABER", 0, 0})
        DESCUADRE.DGW.Item(1, 0).Value = obj.HACER_DECIMAL(S_DEBE0)
        DESCUADRE.DGW.Item(2, 0).Value = obj.HACER_DECIMAL(D_DEBE)
        DESCUADRE.DGW.Item(1, 1).Value = obj.HACER_DECIMAL(S_HABER0)
        DESCUADRE.DGW.Item(2, 1).Value = obj.HACER_DECIMAL(D_HABER)
        'DESCUADRE.DGW.Rows.Clear()
        If D_SALDO > -5 And D_SALDO < 0.5 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function VALIDAR_ELIMINAR() As Boolean
        CARGAR_COMPROBANTE()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            COD_DOC = (dgw_doc_01.Item(3, I).Value)
            Dim NRO_DOC0 As String = (dgw_doc_01.Item(4, I).Value)
            Dim COD_PER0 As String = dgw_doc_01.Item(5, I).Value.ToString
            Dim DOC_PER0 As String = dgw_doc_01.Item(7, I).Value.ToString
            Dim I2 As Integer = 0
            Dim CONT2 As Integer = (dgw_det_01.RowCount - 1)
            Dim CUENTA0 As String = ""
            Dim CONT1 As Integer = CONT2
            I2 = 0
            Do While (I2 <= CONT1)
                If dgw_det_01.Item(25, I2).Value = "T" And dgw_det_01.Item(20, I2).Value = COD_DOC And dgw_det_01.Item(21, I2).Value = NRO_DOC0 And dgw_det_01.Item(22, I2).Value = COD_PER0 And dgw_det_01.Item(23, I2).Value = DOC_PER0 And (dgw_det_01.Item(25, I2).Value = "B" Or dgw_det_01.Item(25, I2).Value = "I" Or dgw_det_01.Item(25, I2).Value = "T") Then

                    CUENTA0 = (dgw_det_01.Item(1, I2).Value)
                End If
                I2 += 1
            Loop
            If obj.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, NRO_DOC0, COD_PER0, DOC_PER0, CUENTA0) = False Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
    Function VALIDAR_SOLES01(ByVal D_DEBE0 As Decimal, ByVal D_HABER0 As Decimal, ByVal CAMBIO0 As Decimal) As Boolean
        Dim S_BI_DEBE As Decimal
        Dim S_BI_HABER As Decimal
        Dim S_DEBE As New Decimal
        Dim S_HABER As New Decimal
        Dim S_SALDO As New Decimal
        Dim D_SALDO As New Decimal
        DESCUADRE.DGW.Rows.Clear()
        S_DEBE = Math.Round(Decimal.Multiply(D_DEBE0, CAMBIO0), 2)
        S_HABER = Math.Round(Decimal.Multiply(D_HABER0, CAMBIO0), 2)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov01.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (dgw_mov01.Item(5, I).Value.ToString = "D") Then
                S_BI_DEBE = Decimal.Parse(Decimal.Add(S_BI_DEBE, dgw_mov01.Item(3, I).Value))

            Else
                S_BI_HABER = Decimal.Parse(Decimal.Add(S_BI_HABER, dgw_mov01.Item(3, I).Value))
            End If
            I += 1
        Loop
        S_DEBE = Decimal.Add(S_DEBE, S_BI_DEBE)
        S_HABER = Decimal.Add(S_HABER, S_BI_HABER)
        S_SALDO = Math.Round(Decimal.Subtract(S_DEBE, S_HABER), 2)
        D_DEBE0 = Decimal.Add(D_DEBE0, HALLAR_TOTAL_BI_DOC01)
        D_SALDO = Math.Round(Decimal.Subtract(D_DEBE0, D_HABER0), 2)
        DESCUADRE.DGW.Rows.Add(New Object() {"DEBE", 0, 0})
        DESCUADRE.DGW.Rows.Add(New Object() {"HABER", 0, 0})
        DESCUADRE.DGW.Item(1, 0).Value = (obj.HACER_DECIMAL(S_DEBE))
        DESCUADRE.DGW.Item(2, 0).Value = (obj.HACER_DECIMAL(D_DEBE0))
        DESCUADRE.DGW.Item(1, 1).Value = (obj.HACER_DECIMAL(S_HABER))
        DESCUADRE.DGW.Item(2, 1).Value = (obj.HACER_DECIMAL(D_HABER0))
        'DESCUADRE.DGW.Rows.Clear()
        If S_SALDO = 0 Then
            Return True
        Else
            Return False
        End If
        Return (Decimal.Compare(S_SALDO, Decimal.Zero) = 0)
    End Function
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
    Private Sub btn_req0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_req0.Click
        boton30()
    End Sub
    Sub boton30()
        ofr.con0 = con00
        ofr._fecha = dtp_doc.Value
        ofr.CARGAR_ORD_PROD()
        ofr.ShowDialog()
        If ofr.DialogResult = Windows.Forms.DialogResult.OK Then
            txt_nro_ord_prod.Text = ofr.DGW_CAB.Item(0, ofr.DGW_CAB.CurrentRow.Index).Value.ToString
            Try
                COD_ACT = ofr.DGW_DET.Item(0, ofr.DGW_DET.CurrentRow.Index).Value.ToString
                cbo_act.Text = obj.DESC_ACTIVIDAD(COD_ACT, con00)
            Catch ex As Exception
                COD_ACT = ""
            End Try
            ofr.Hide()
        End If
    End Sub
    Private Sub txt_base_ref_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_base_ref.KeyPress
        e.Handled = Numero(e, txt_base_ref)
    End Sub
    Private Sub txt_base_ref_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_base_ref.LostFocus
        Try
            txt_base_ref.Text = (obj.HACER_DECIMAL(txt_base_ref.Text))
        Catch ex As Exception
            txt_base_ref.Text = "0.00"
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_mod.CheckedChanged
        If ch_mod.Checked = True Then
            txt_igv.ReadOnly = False
        Else
            txt_igv.ReadOnly = True
        End If
    End Sub
    Private Sub ch_mod2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_mod2.CheckedChanged
        If ch_mod2.Checked = True Then
            txt_imp_igv01.ReadOnly = False
        Else
            txt_imp_igv01.ReadOnly = True
        End If
    End Sub
    Private Sub txt_imp_igv01_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_igv01.KeyPress
        e.Handled = Numero(e, txt_imp_igv01)
    End Sub
    Private Sub txt_imp_igv01_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_imp_igv01.LostFocus
        Try
            txt_imp_igv01.Text = (obj.HACER_DECIMAL(txt_imp_igv01.Text))
            txt_imp_total01.Text = txt_imp_igv01.Text + HALLAR_TOTAL_BI_DOC01()
            txt_imp_total01.Text = obj.HACER_DECIMAL(txt_imp_total01.Text)
        Catch ex As Exception
            HALLAR_TOTAL_DOC01()
        End Try
    End Sub
    Private Sub txt_tasa_det_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tasa_det.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function
    'Private Sub txt_tasa_det_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tasa_det.LostFocus
    '    Try
    '        txt_tasa_det.Text = (obj.HACER_DECIMAL(txt_tasa_det.Text))
    '    Catch ex As Exception
    '        txt_tasa_det.Text = "0.00"
    '    End Try
    'End Sub
    Sub HALLAR_DES_NRO_ORDEN()
        desc_orden.Text = ""
        Label84.Text = ""
        Dim nro_or As String = ""
        If CBO_ORDEN.SelectedIndex <> -1 Then
            nro_or = CBO_ORDEN.Text
        End If
        If cbo_orden01.SelectedIndex <> -1 Then
            nro_or = cbo_orden01.Text
        End If
        Try
            Dim PROG_01 As New SqlCommand("DESCRIPCION_CBO_ORDEN00", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = "C"
            PROG_01.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = nro_or
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                If CBO_ORDEN.SelectedIndex <> -1 Then
                    desc_orden.Text = "Desc. : " & "  " & Rs3.GetString(0)
                End If
                If cbo_orden01.SelectedIndex <> -1 Then
                    Label84.Text = "Desc. : " & "  " & Rs3.GetString(0)
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
    Private Sub cbo_orden01_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_orden01.SelectedIndexChanged
        HALLAR_DES_NRO_ORDEN()
    End Sub

    Private Sub btn_imprimir01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir01.Click
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw_det_01.Rows.Count - 1
        Dim IMPORTE As Decimal
        Dim IMPORTE_DEBE, IMPORTE_HABER As Decimal
        For I = 0 To cont
            If dgw_det_01.Item(25, I).Value = "T" Or dgw_det_01.Item(25, I).Value = "I" Or dgw_det_01.Item(25, I).Value = "B" Then
                If dgw_det_01.Item(6, I).Value = "S" Then
                    IMPORTE = obj.HACER_DECIMAL(dgw_det_01.Item(3, I).Value / dgw_det_01.Item(7, I).Value)
                ElseIf dgw_det_01.Item(6, I).Value = "D" Then
                    IMPORTE = dgw_det_01.Item(4, I).Value
                End If
                If dgw_det_01.Item(5, I).Value = "D" Then
                    IMPORTE_DEBE = dgw_det_01.Item(3, I).Value : IMPORTE_HABER = "0.00"
                ElseIf dgw_det_01.Item(5, I).Value = "H" Then
                    IMPORTE_DEBE = "0.00" : IMPORTE_HABER = dgw_det_01.Item(3, I).Value
                End If
                Dim COD_REPOR As String
                COD_REPOR = obj.DESC_USUARIO_COMPROBANTE(cbo_aux01.SelectedValue.ToString, cbo_comp01.SelectedValue.ToString, txt_nro_comp01.Text, AÑO, MES)
                dt.DataTable1.Rows.Add(dgw_det_01.Item(19, I).Value.ToString.Substring(0, 10), dgw_det_01.Item(21, I).Value, dgw_det_01.Item(20, I).Value, dgw_det_01.Item(22, I).Value, dgw_det_01.Item(8, I).Value, dgw_det_01.Item(1, I).Value, dgw_det_01.Item(2, I).Value, dgw_det_01.Item(6, I).Value, dgw_det_01.Item(7, I).Value, IMPORTE, IMPORTE_DEBE, IMPORTE_HABER, dgw_det_01.Item(5, I).Value, dgw_det_01.Item(39, I).Value, txt_nro_comp.Text, COD_REPOR, dgw_det_01.Item(2, I).Value, cbo_com.Text, dgw_det_01.Item(10, I).Value, dgw_det_01.Item(11, I).Value)
            End If
        Next

        If chkContinuo.Checked Then
            ReporteImprimir(dt, reporte, cbo_aux01.Text)
        Else
            ReporteImprimir(dt, reporte1, cbo_aux01.Text)
        End If
        'reporte.SetDataSource(dt)
        'Dim Params As New ParameterValues
        'Dim Par As New ParameterDiscreteValue
        ''======================================================================================
        'Params.Clear()
        'Par.Value = obj.DESC_MES(MES)
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
        'Par.Value = cbo_aux01.Text
        'Params.Add(Par)
        'reporte.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)

        'reporte.PrintOptions.PaperSize = DirectCast(obj.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
        'reporte.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter, TabPage3.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub

    Private Sub cbo_tipo_doc01_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_doc01.SelectionChangeCommitted, cbo_tipo_doc.SelectionChangeCommitted
        ConfigDoc = obj.GCO_DIR_TABLA_DESC(obj.COD_DOC(sender.Text), "TCDOC", con)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As frmConsultaRuc = frmConsultaRuc.ObtenerInstancia
        'frm.MdiParent = Me
        frm.Cargar_Datos(txt_doc_per01.Text, BOTON, "consulta")
        frm.btnConsultar.Focus()
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
        End If
        frm.Close()
    End Sub

    Private Sub cboClasificacionBienes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasificacionBienesXnDocumento.SelectedIndexChanged
        'Validamos el codigo del grupo de clasificación de bienes y servicios
        If (cboClasificacionBienesXnDocumento.SelectedIndex = 0) Then
            CodigoClasificacionBienes = "1"
        ElseIf (cboClasificacionBienesXnDocumento.SelectedIndex = 1) Then
            CodigoClasificacionBienes = "2"
        ElseIf (cboClasificacionBienesXnDocumento.SelectedIndex = 2) Then
            CodigoClasificacionBienes = "3"
        ElseIf (cboClasificacionBienesXnDocumento.SelectedIndex = 3) Then
            CodigoClasificacionBienes = "4"
        ElseIf (cboClasificacionBienesXnDocumento.SelectedIndex = 4) Then
            CodigoClasificacionBienes = "5"
        End If
    End Sub

    Private Sub cboClasificacionBienesxDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasificacionBienesxDocumento.SelectedIndexChanged
        'Validamos el codigo del grupo de clasificación de bienes y servicios
        If (cboClasificacionBienesxDocumento.SelectedIndex = 0) Then
            CodigoClasificacionBienes = "1"
        ElseIf (cboClasificacionBienesxDocumento.SelectedIndex = 1) Then
            CodigoClasificacionBienes = "2"
        ElseIf (cboClasificacionBienesxDocumento.SelectedIndex = 2) Then
            CodigoClasificacionBienes = "3"
        ElseIf (cboClasificacionBienesxDocumento.SelectedIndex = 3) Then
            CodigoClasificacionBienes = "4"
        ElseIf (cboClasificacionBienesxDocumento.SelectedIndex = 4) Then
            CodigoClasificacionBienes = "5"
        End If
    End Sub

    Private Sub ValidarCodigoBienes(ByVal CodigoBien As String, ByVal combo As ComboBox)
        If (CodigoBien = "1") Then
            combo.SelectedIndex = 0
            combo.Enabled = False
        ElseIf (CodigoBien = "2") Then
            combo.SelectedIndex = 1
            combo.Enabled = False
        ElseIf (CodigoBien = "3") Then
            combo.SelectedIndex = 2
            combo.Enabled = False
        ElseIf (CodigoBien = "4") Then
            combo.SelectedIndex = 3
            combo.Enabled = False
        ElseIf (CodigoBien = "5") Then
            combo.SelectedIndex = 4
            combo.Enabled = False
        Else
            combo.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnSalirNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirNoDomiciliados.Click
        TabControl2.Visible = False
        btn_nuevo_det01.Focus()
    End Sub

    Private Sub btnGuardarNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarNoDomiciliados.Click
        Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, "Proviciones Compras")
    End Sub

    Private Sub cboTipoRenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoRenta.SelectedIndexChanged
        If cboTipoRenta.SelectedIndex = 0 Then
            TipoRenta = "00"
        ElseIf cboTipoRenta.SelectedIndex = 1 Then
            TipoRenta = "01"
        ElseIf cboTipoRenta.SelectedIndex = 2 Then
            TipoRenta = "06"
        ElseIf cboTipoRenta.SelectedIndex = 3 Then
            TipoRenta = "07"
        ElseIf cboTipoRenta.SelectedIndex = 4 Then
            TipoRenta = "09"
        ElseIf cboTipoRenta.SelectedIndex = 5 Then
            TipoRenta = "10"
        ElseIf cboTipoRenta.SelectedIndex = 6 Then
            TipoRenta = "18"
        ElseIf cboTipoRenta.SelectedIndex = 7 Then
            TipoRenta = "19"
        ElseIf cboTipoRenta.SelectedIndex = 8 Then
            TipoRenta = "33"
        ElseIf cboTipoRenta.SelectedIndex = 9 Then
            TipoRenta = "35"
        ElseIf cboTipoRenta.SelectedIndex = 10 Then
            TipoRenta = "41"
        Else
            TipoRenta = ""
        End If
    End Sub

    Private Sub RecuperarDescripcionTipoRenta(ByVal Codigo As String, ByVal combo As ComboBox)
        If Codigo = "00" Then
            combo.SelectedIndex = 0
        ElseIf Codigo = "01" Then
            combo.SelectedIndex = 1
        ElseIf Codigo = "06" Then
            combo.SelectedIndex = 2
        ElseIf Codigo = "07" Then
            combo.SelectedIndex = 3
        ElseIf Codigo = "09" Then
            combo.SelectedIndex = 4
        ElseIf Codigo = "10" Then
            combo.SelectedIndex = 5
        ElseIf Codigo = "18" Then
            combo.SelectedIndex = 6
        ElseIf Codigo = "19" Then
            combo.SelectedIndex = 7
        ElseIf Codigo = "33" Then
            combo.SelectedIndex = 8
        ElseIf Codigo = "35" Then
            combo.SelectedIndex = 9
        ElseIf Codigo = "41" Then
            combo.SelectedIndex = 10
        Else
            combo.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboConvenios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConvenios.SelectedIndexChanged
        If cboConvenios.SelectedIndex = 0 Then
            CodigoConvenio = "00"
        ElseIf cboConvenios.SelectedIndex = 1 Then
            CodigoConvenio = "01"
        ElseIf cboConvenios.SelectedIndex = 2 Then
            CodigoConvenio = "02"
        ElseIf cboConvenios.SelectedIndex = 3 Then
            CodigoConvenio = "03"
        ElseIf cboConvenios.SelectedIndex = 4 Then
            CodigoConvenio = "04"
        ElseIf cboConvenios.SelectedIndex = 5 Then
            CodigoConvenio = "05"
        ElseIf cboConvenios.SelectedIndex = 6 Then
            CodigoConvenio = "06"
        ElseIf cboConvenios.SelectedIndex = 7 Then
            CodigoConvenio = "07"
        ElseIf cboConvenios.SelectedIndex = 8 Then
            CodigoConvenio = "08"
        ElseIf cboConvenios.SelectedIndex = 9 Then
            CodigoConvenio = "09"
        Else
            CodigoConvenio = ""
        End If
    End Sub

    Private Sub RecuperarDescripcionConvenios(ByVal Codigo As String, ByVal combo As ComboBox)
        If Codigo = "00" Then
            combo.SelectedIndex = 0
        ElseIf Codigo = "01" Then
            combo.SelectedIndex = 1
        ElseIf Codigo = "02" Then
            combo.SelectedIndex = 2
        ElseIf Codigo = "03" Then
            combo.SelectedIndex = 3
        ElseIf Codigo = "04" Then
            combo.SelectedIndex = 4
        ElseIf Codigo = "05" Then
            combo.SelectedIndex = 5
        ElseIf Codigo = "06" Then
            combo.SelectedIndex = 6
        ElseIf Codigo = "07" Then
            combo.SelectedIndex = 7
        ElseIf Codigo = "08" Then
            combo.SelectedIndex = 8
        ElseIf Codigo = "09" Then
            combo.SelectedIndex = 9
        Else
            combo.SelectedIndex = -1
        End If
    End Sub


    Private Sub cboTipoRentaxNDocumentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoRentaxNDocumentos.SelectedIndexChanged
        If cboTipoRentaxNDocumentos.SelectedIndex = 0 Then
            TipoRenta = "00"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 1 Then
            TipoRenta = "01"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 2 Then
            TipoRenta = "06"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 3 Then
            TipoRenta = "07"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 4 Then
            TipoRenta = "09"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 5 Then
            TipoRenta = "10"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 6 Then
            TipoRenta = "18"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 7 Then
            TipoRenta = "19"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 8 Then
            TipoRenta = "33"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 9 Then
            TipoRenta = "35"
        ElseIf cboTipoRentaxNDocumentos.SelectedIndex = 10 Then
            TipoRenta = "41"
        Else
            TipoRenta = ""
        End If
    End Sub

    Private Sub cboConveniosXNDocumentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConveniosXNDocumentos.SelectedIndexChanged
        If cboConveniosXNDocumentos.SelectedIndex = 0 Then
            CodigoConvenio = "00"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 1 Then
            CodigoConvenio = "01"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 2 Then
            CodigoConvenio = "02"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 3 Then
            CodigoConvenio = "03"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 4 Then
            CodigoConvenio = "04"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 5 Then
            CodigoConvenio = "05"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 6 Then
            CodigoConvenio = "06"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 7 Then
            CodigoConvenio = "07"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 8 Then
            CodigoConvenio = "08"
        ElseIf cboConveniosXNDocumentos.SelectedIndex = 9 Then
            CodigoConvenio = "09"
        Else
            CodigoConvenio = ""
        End If
    End Sub

    Private Sub btnGuardarNoDomiciliadosxNDocumentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarNoDomiciliadosxNDocumentos.Click
        If cboMonedaOrigenxNDocumentos.SelectedValue = Nothing Then
            CodigoMonedaOrigen = String.Empty
        Else
            CodigoMonedaOrigen = cboMonedaOrigenxNDocumentos.SelectedValue
        End If
        dgw_doc_01.Item(36, dgw_doc_01.CurrentRow.Index).Value = CodigoMonedaOrigen
        dgw_doc_01.Item(37, dgw_doc_01.CurrentRow.Index).Value = CodigoConvenio
        dgw_doc_01.Item(38, dgw_doc_01.CurrentRow.Index).Value = TipoRenta
        Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, "Proviciones Compras")
    End Sub

    Private Sub btnSalirNoDomiciliadosxNDocumentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalirNoDomiciliadosxNDocumentos.Click
        cboMonedaOrigenxNDocumentos.SelectedIndex = -1
        cboConveniosXNDocumentos.SelectedIndex = -1
        cboTipoRentaxNDocumentos.SelectedIndex = -1
        TabControl3.Visible = False
        btn_nuevo_det01.Focus()
    End Sub

    Private Sub btnNoEmitidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoEmitidos.Click
        If (cbo_aux01.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux01.Focus()
        ElseIf (cbo_comp01.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_comp01.Focus()
        ElseIf (txt_nro_comp01.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp01.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_comp01.Value)) = 0) Then
            dtp_comp01.Focus()
            'Puesto de manera temporal para controlar los nuevos códigos que proporciona la SUNAT
        ElseIf (cboClasificacionBienesxDocumento.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el tipo de Bienes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClasificacionBienesxDocumento.Focus()
            '------
        Else
            g_cab01.Enabled = False
            cboClasificacionBienesxDocumento.Enabled = False
            If (cbo_tipo_doc01.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir el Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_tipo_doc01.Focus()
            ElseIf (txt_nro_doc01.Text.Trim = "") Then
                MessageBox.Show("Debe insertar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_nro_doc01.Focus()
            ElseIf (dtp_doc01.Value.Date > FECHA_GRAL.Date) Then
                MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtp_doc01.Focus()
            ElseIf (txt_cod_per01.Text.Trim = "") Then
                MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_per01.Focus()
            ElseIf (cbo_moneda01.SelectedIndex = -1) Then
                MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_moneda01.Focus()
            Else
                If (txt_cambio01.Text = "") Then
                    txt_cambio01.Text = "0.0000"
                End If
                If (Decimal.Parse(txt_cambio01.Text) = 0) Then
                    MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_cambio01.Focus()
                Else
                    COD_DOC = obj.COD_DOC(cbo_tipo_doc01.Text)
                    If (BOTON = "NUEVO") Then
                        If obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text, txt_cta_t01.Text) = False Then
                            MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        If obj.VERIFICAR_REG_COMPRAS(COD_DOC, txt_nro_doc01.Text, txt_cod_per01.Text, txt_doc_per01.Text) = False Then
                            MessageBox.Show("El Documento ya existe en el Registro de Compras.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                        'If ConfigDoc IsNot Nothing AndAlso ConfigDoc.Trim.Length > 0 Then
                        '    ch_igv01.Checked = (ConfigDoc.Substring(4, 1) = "S" OrElse ch_pago2.Checked)
                        'End If
                    End If
                    panel01.Enabled = False
                    COD_DH_DOC = obj.COD_D_H(COD_DOC)
                    If COD_DH_DOC = "D" Then COD_DH_DOC = "H" Else COD_DH_DOC = "D"
                    STATUS_PV = "0"
                    If ch_pv01.Checked Then STATUS_PV = "1"
                    LIMPIAR_DETALLES01()
                    'Panel_det01.Visible = True
                    'txt_cod_cuenta01.Focus()
                End If
            End If
        End If
        '-------------
        frmNoEmitidas.Dispose()
        frmNoEmitidas.CodigoPersona = txt_cod_per01.Text
        frmNoEmitidas.Moneda = COD_MONEDA
        frmNoEmitidas.ShowDialog()
        If frmNoEmitidas.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim FilasNoEmitidas As Integer = frmNoEmitidas.dgvNoEmitidas.RowCount
            Dim Indice As Integer = 0
            While Indice < FilasNoEmitidas
                If frmNoEmitidas.dgvNoEmitidas.Item(0, Indice).Value Then
                    'dgw_mov01.Rows.Add(HALLAR_ITEM01(), frmNoEmitidas.dgvNoEmitidas.Item(1, Indice).Value)
                    txt_cod_cuenta01.Text = frmNoEmitidas.dgvNoEmitidas.Item(1, Indice).Value
                    TXT_cod_cuenta01_LostFocus(sender, Nothing)
                    CBO_D_H01.Text = frmNoEmitidas.dgvNoEmitidas.Item(6, Indice).Value
                    txt_bi01.Text = frmNoEmitidas.dgvNoEmitidas.Item(2, Indice).Value
                    TXT_GLOSA01.Text = frmNoEmitidas.dgvNoEmitidas.Item(4, Indice).Value
                    BTN_GUARDAR_DET01_Click(sender, Nothing)
                End If
                Indice += 1
            End While
            'Else
            'frmNoEmitidas.Dispose()
            'CambiarEstadoNoEmitidas()
        End If
    End Sub
    Private Sub CambiarEstadoNoEmitidas()
        Dim FilasNoEmitidas As Integer = frmNoEmitidas.dgvNoEmitidas.RowCount
        Dim Indice As Integer = 0
        While Indice < FilasNoEmitidas
            If frmNoEmitidas.dgvNoEmitidas.Item(0, Indice).Value Then
                Try
                    Dim cmd As New SqlCommand("CAMBIAR_NO_EMITIDAS", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(9, Indice).Value
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(10, Indice).Value
                    cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(11, Indice).Value
                    cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(15, Indice).Value
                    cmd.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = frmNoEmitidas.dgvNoEmitidas.Item(12, Indice).Value
                    cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(13, Indice).Value
                    cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = frmNoEmitidas.dgvNoEmitidas.Item(8, Indice).Value
                    cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(5, Indice).Value
                    cmd.Parameters.Add("@ITEM", SqlDbType.Char).Value = frmNoEmitidas.dgvNoEmitidas.Item(14, Indice).Value
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    con.Close()
                End Try
            End If
            Indice += 1
        End While
    End Sub
End Class
