Imports System.Data.SqlClient
Public Class GENERACION_CXC
    Dim BOTON, STATUS_PV, STATUS_P, STATUS_CC, DESTINO, ENLACE, COD_P, COD_MONEDA, COD_DOC, COD_DH_DOC, COD_COMP, COD_AUX, COD_C, COD_CC As String
    Dim DT_DET As New DataTable
    Dim FILA_DOC, fila2, fila3 As Integer
    Dim IGV0 As Decimal
    Dim OBJ As New Class1
    Private ValidarFicha As Boolean = True

    Private Sub btn_act_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_act.Click
        DGW_PERSONAS()
    End Sub
    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim i As Integer = 0
        Do While (i <= (dgw_per.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(dgw_per.Item(1, i).Value.ToString))
                If (txt_desc_per.Text.ToLower = Strings.Mid(dgw_per.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(1))
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
    Sub HALLANDO_SALDOS()
        Dim sd, sh, dd, dh As Decimal
        Dim cont, i As Integer
        cont = dgw_doc_01.RowCount - 1
        sd = 0 : sh = 0 : dd = 0 : dh = 0
        For i = 0 To cont
            If dgw_doc_01.Item(7, i).Value = "D" Then
                If dgw_doc_01.Item(9, i).Value = "D" Then
                    dd = dd + dgw_doc_01.Item(6, i).Value
                ElseIf dgw_doc_01.Item(9, i).Value = "H" Then
                    dh = dh + dgw_doc_01.Item(6, i).Value
                End If
            ElseIf dgw_doc_01.Item(7, i).Value = "S" Then
                If dgw_doc_01.Item(9, i).Value = "D" Then
                    sd = sd + dgw_doc_01.Item(6, i).Value
                ElseIf dgw_doc_01.Item(9, i).Value = "H" Then
                    sh = sh + dgw_doc_01.Item(6, i).Value
                End If
            End If
        Next
        txt_sd.Text = OBJ.HACER_DECIMAL(Math.Round(sd, 3, MidpointRounding.AwayFromZero))
        txt_sh.Text = OBJ.HACER_DECIMAL(Math.Round(sh, 3, MidpointRounding.AwayFromZero))
        txt_dd.Text = OBJ.HACER_DECIMAL(Math.Round(dd, 3, MidpointRounding.AwayFromZero))
        txt_dh.Text = OBJ.HACER_DECIMAL(Math.Round(dh, 3, MidpointRounding.AwayFromZero))
    End Sub
    Private Sub btn_cadena3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena3.Click
        btn_sgt3.Enabled = True
        Dim i As Integer = 0
        Do While (i <= (dgw_cta_imp.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(dgw_cta_imp.Item(1, i).Value.ToString))
                If (txt_desc_cta_imp.Text.ToLower = Strings.Mid(dgw_cta_imp.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cta_imp.Text)).ToLower) Then
                    dgw_cta_imp.CurrentCell = (dgw_cta_imp.Rows.Item(i).Cells.Item(1))
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
        txt_cta_total.Focus()
    End Sub
    Private Sub btn_cancelar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_com.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()
    End Sub
    Private Sub btn_cancelar_doc2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_doc2.Click
        Panel_DOC02.Visible = False
        HALLANDO_SALDOS()
        btn_nuevo_doc.Focus()
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consultar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

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
        HALLANDO_SALDOS()
        ValidarFicha = True
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If MessageBox.Show("Desea borrar el Comprobante", " Borrar Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = 6 Then
            COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
            txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
            If OBJ.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_VENTAS", con)
                comand1.CommandType = (CommandType.StoredProcedure)
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
        COD_DOC = (dgw_doc_01.Item(0, FILA_DOC).Value)
        Dim NRO_DOC0 As String = (dgw_doc_01.Item(1, FILA_DOC).Value)
        Dim COD_PER0 As String = dgw_doc_01.Item(2, FILA_DOC).Value.ToString
        Dim DOC_PER0 As String = dgw_doc_01.Item(4, FILA_DOC).Value.ToString
        Dim CUENTA0 As String = dgw_doc_01.Item(14, FILA_DOC).Value.ToString
        If OBJ.VERIFICAR_ELIMINAR_PCTAS_COBRAR(COD_DOC, NRO_DOC0, COD_PER0, DOC_PER0, CUENTA0) = False Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf MessageBox.Show("Desea borrar el documento", " Borrar Documento?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = 6 Then
            FILA_DOC = dgw_doc_01.CurrentRow.Index
            ELIMINAR_DOCUMENTO_DGW(FILA_DOC)
            HALLANDO_SALDOS()
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
        ElseIf ((OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_doc_01.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_doc.Focus()
        Else

            txt_nro_comp.Text = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (INSERTAR_TODO() = "EXITO") Then
                txt_nro_comp.Text = OBJ.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                OBJ.ELIMINAR_TEMPORAL("TCON")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            DATAGRID()
            btn_grabar_com.Enabled = False
            btn_nuevo_comp.Enabled = True
            btn_imprimir.Enabled = True
            btn_imprimir.Focus()
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
        ElseIf ((OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        Else
            If (MODIFICAR_TODO() = "EXITO") Then
                MessageBox.Show("El Comprobante se actualizó con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                OBJ.ELIMINAR_TEMPORAL("TCON")
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            DATAGRID()
            btn_grabar_com2.Enabled = False
            btn_nuevo_comp.Enabled = True
            btn_imprimir.Enabled = True
            btn_imprimir.Focus()
        End If
    End Sub
    Private Sub btn_grabar_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_doc.Click
        If (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        ElseIf (txt_cta_total.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_total.Focus()
            'ElseIf ((txt_saldo_soles.Text) <> 0) Then
            '    MessageBox.Show("El Saldo debe ser 0, ingrese detalle de ajuste.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    BTNAJUSTE.Focus()
            'ElseIf ((txt_saldo_dolares.Text) <> 0) Then
            '    If ((txt_saldo_dolares.Text) <= 0.5) And ((txt_saldo_dolares.Text) >= -0.5) Then
            '    Else
            '        MessageBox.Show("El Saldo de dólares debe estar en +-0.5.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    End If
        ElseIf VERIFICAR_DATAGRID_DOC(txt_cod_per0.Text, txt_doc_per.Text, COD_DOC, txt_nro_doc.Text) = False Then
            MessageBox.Show("Ya guardo el documento.", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf OBJ.VERIFICAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False Then
            MessageBox.Show("El Documento ya existe en Ctas. x Cobrar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            INSERTAR_DOCUMENTO_DGW()
            MessageBox.Show("El Documento se ingresó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_DOCUMENTOS()
            cbo_tipo_doc.Focus()
        End If
    End Sub
    Private Sub btn_grabar_doc2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_doc2.Click
        If (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Documento sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        ElseIf (txt_cta_total.Text.Trim = "") Then
            MessageBox.Show("Debe elegir la Cuenta de Total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cta_total.Focus()
            'ElseIf ((txt_saldo_soles.Text) <> 0) Then
            '    MessageBox.Show("El Saldo debe ser 0, ingrese detalle de ajuste.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    BTNAJUSTE.Focus()
            'ElseIf ((txt_saldo_dolares.Text) <> 0) Then
            '    If ((txt_saldo_dolares.Text) <= 0.5) And ((txt_saldo_dolares.Text) >= -0.5) Then
            '    Else
            '        MessageBox.Show("El Saldo de dólares debe estar en +-0.5.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    End If
        Else
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
            If (txt_bi.Text.Trim = "") Then
                txt_bi.Text = "0.00"
            End If
            If ((txt_bi.Text) = 0) Then
                MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_bi.Focus()
            Else
                Dim BI_DOL As Decimal
                Dim BI_SOL As Decimal
                Dim MON0 As String = COD_MONEDA
                If (lbl_moneda_det.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                Dim BI_TEMP As New Decimal(Double.Parse(txt_bi.Text))
                Dim BI_REAL As Decimal = BI_TEMP
                Select Case MON0
                    Case "S"
                        BI_SOL = BI_REAL
                        BI_DOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) / Double.Parse(txt_cambio.Text))), 2))

                    Case "D"
                        BI_DOL = BI_REAL
                        BI_SOL = New Decimal(Math.Round(CDbl((Convert.ToDouble(BI_REAL) * Double.Parse(txt_cambio.Text))), 2))

                    Case "A"
                        BI_DOL = 0
                        BI_SOL = BI_REAL

                End Select
                Dim ITEM As Integer = (HALLAR_ITEM())
                ENLACE = ""
                DESTINO = ""
                COD_C = ""
                COD_P = ""
                COD_CC = ""
                If (cbo_control.SelectedIndex <> -1) Then
                    COD_C = OBJ.COD_CONTROL(cbo_control.Text)
                End If
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_P = OBJ.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (CBO_CC.SelectedIndex <> -1) Then
                    COD_CC = OBJ.COD_CC(CBO_CC.Text)
                End If
                dgw_mov1.Rows.Add(ITEM.ToString("0000"), txt_cta_imp.Text, txt_glosa.Text, BI_SOL, BI_DOL, cbo_d_h.Text, MON0, txt_cambio.Text, COD_CC, COD_C, COD_P, "", dtp_vence.Value, STATUS_PV, ENLACE, DESTINO, STATUS_CC, "1", STATUS_P, dtp_doc.Value, " ", "1", "0.00")
                HALLAR_TOTAL_DOC()
                LIMPIAR_DETALLES()
                txt_cta_imp.Focus()
            End If
        End If
    End Sub
    Private Sub btn_Insertar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Insertar.Click
        Try
            Dim i As Integer = dgw_doc_01.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        FILA_DOC = dgw_doc_01.CurrentRow.Index
        TabControl3.Visible = True
    End Sub
    Private Sub btn_mod_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod_det.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub

        End Try
        LIMPIAR_DETALLES()
        item0.Text = (dgw_mov1.Item(0, dgw_mov1.CurrentRow.Index).Value)
        CARGAR_DET1()
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        txt_cta_imp.Focus()
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
   
        BOTON = "MODIFICAR"
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()

        '-----------------------------------------------------------------------
        If OBJ.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '-----------------------------------------------------------------------
        ValidarFicha = False
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = True
        g_cab.Enabled = False
        btn_grabar_com2.Enabled = True
        btn_imprimir.Enabled = False
        TabControl1.SelectedTab = (TabPage3)
        btn_nuevo_doc.Focus()
        HALLANDO_SALDOS()
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
        If (OBJ.VERIFICAR_ELIMINAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, txt_cta_total.Text) = False And (BOTON <> "NUEVO")) Then
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
            If (txt_bi.Text.Trim = "") Then
                txt_bi.Text = "0.00"
            End If
            If ((txt_bi.Text) = 0) Then
                MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_bi.Focus()
            Else
                Dim BI_DOL As Decimal
                Dim BI_REAL As Decimal
                Dim BI_SOL As Decimal
                Dim BI_TEMP As Decimal
                Dim MON0 As String = COD_MONEDA
                If (lbl_moneda_det.Text = "AJUSTE") Then
                    MON0 = "A"
                End If
                If (STATUS_PV = "1") Then
                    BI_TEMP = New Decimal(Double.Parse(txt_bi.Text))
                    BI_REAL = New Decimal(Math.Round(CDbl((Convert.ToDouble(Decimal.Multiply(BI_TEMP, 100)) / (100 + ("0.00")))), 2))
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
                        BI_DOL = 0
                        BI_SOL = BI_REAL

                End Select
                Dim ITEM As Integer = (HALLAR_ITEM())
                ENLACE = ""
                DESTINO = ""
                COD_C = ""
                COD_P = ""
                COD_CC = ""
                If (cbo_control.SelectedIndex <> -1) Then
                    COD_C = OBJ.COD_CONTROL(cbo_control.Text)
                End If
                If (cbo_proyecto.SelectedIndex <> -1) Then
                    COD_P = OBJ.COD_PROYECTO(cbo_proyecto.Text)
                End If
                If (CBO_CC.SelectedIndex <> -1) Then
                    COD_CC = OBJ.COD_CC(CBO_CC.Text)
                End If
                dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value = (txt_cta_imp.Text)
                dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value = (txt_glosa.Text)
                dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value = (BI_SOL)
                dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value = (BI_DOL)
                dgw_mov1.Item(5, dgw_mov1.CurrentRow.Index).Value = (cbo_d_h.Text)
                dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value = (MON0)
                dgw_mov1.Item(7, dgw_mov1.CurrentRow.Index).Value = (txt_cambio.Text)
                dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value = (COD_CC)
                dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value = (COD_C)
                dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value = (COD_P)
                dgw_mov1.Item(11, dgw_mov1.CurrentRow.Index).Value = ("")
                dgw_mov1.Item(12, dgw_mov1.CurrentRow.Index).Value = (dtp_vence.Value)
                dgw_mov1.Item(13, dgw_mov1.CurrentRow.Index).Value = (STATUS_PV)
                dgw_mov1.Item(14, dgw_mov1.CurrentRow.Index).Value = (ENLACE)
                dgw_mov1.Item(15, dgw_mov1.CurrentRow.Index).Value = (DESTINO)
                dgw_mov1.Item(16, dgw_mov1.CurrentRow.Index).Value = (STATUS_CC)
                dgw_mov1.Item(17, dgw_mov1.CurrentRow.Index).Value = ("1")
                dgw_mov1.Item(18, dgw_mov1.CurrentRow.Index).Value = (STATUS_P)
                dgw_mov1.Item(19, dgw_mov1.CurrentRow.Index).Value = (dtp_doc.Value)
                dgw_mov1.Item(20, dgw_mov1.CurrentRow.Index).Value = (" ")
                dgw_mov1.Item(21, dgw_mov1.CurrentRow.Index).Value = ("1")
                dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value = "0.00"
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
        TabControl1.SelectedTab = (TabPage3)
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
        ValidarFicha = True
    End Sub
    Private Sub btn_nuevo_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_det.Click
        If (cbo_tipo_doc.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc.Focus()
        ElseIf (txt_nro_doc.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc.Focus()
        ElseIf ((OBJ.VALIDAR_FECHA_DOC(dtp_doc.Value)) = 0) Then
            dtp_doc.Focus()
        ElseIf (txt_cod_per0.Text.Trim = "") Then
            MessageBox.Show("Debe elegir el Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
        ElseIf (cbo_moneda.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda.Focus()
        Else
            If (txt_cambio.Text = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If ((txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe insertar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            Else
                panel1.Enabled = False
                COD_DOC = OBJ.COD_DOC(cbo_tipo_doc.Text)
                COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                'If (COD_DH_DOC = "D") Then
                '    COD_DH_DOC = "H"
                'Else
                '    COD_DH_DOC = "D"
                'End If
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
        ElseIf ((OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        Else
            g_cab.Enabled = False
            LIMPIAR_DOCUMENTOS()
            Panel_DOC02.Visible = True
            cbo_tipo_doc.Focus()
        End If
    End Sub
    Private Sub btn_ref_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ref.Click
        Dim cod_doc007 As String = (dgw_doc_01.Item(3, FILA_DOC).Value)
        If ((cod_doc007 = "07") Or (cod_doc007 = "08")) Then
            If ((cbo_tipo_ref.SelectedIndex = -1) Or (Strings.Trim(txt_nro_ref.Text) = "")) Then
                MessageBox.Show("Inserte los datos", "Faltan Datos", MessageBoxButtons.OK)
            Else
                Dim cod_ref As String = OBJ.COD_DOC(cbo_tipo_ref.SelectedItem)
                dgw_doc_01.Item(27, FILA_DOC).Value = (cod_ref)
                dgw_doc_01.Item(28, FILA_DOC).Value = (txt_nro_ref.Text)
                dgw_doc_01.Item(29, FILA_DOC).Value = (dtp_ref.Value)
                Interaction.MsgBox("Datos Guardados", MsgBoxStyle.OkOnly, Nothing)
            End If
        Else
            MessageBox.Show("El Documento no posee Referencia", "No es Nota de Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(124) = 0
        Close()
    End Sub
    Private Sub btn_salir8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        TabControl3.Visible = False
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim i As Integer = fila2
        Do While (i <= (dgw_per.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(dgw_per.Item(1, i).Value.ToString))
                If (txt_desc_per.Text.ToLower = Strings.Mid(dgw_per.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_per.Text)).ToLower) Then
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(1))
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
        Dim i As Integer = fila3
        Do While (i <= (dgw_cta_imp.RowCount - 1))
            Dim f As Integer = 1
            Do While (f <= Len(dgw_cta_imp.Item(1, i).Value.ToString))
                If (txt_desc_cta_imp.Text.ToLower = Strings.Mid(dgw_cta_imp.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cta_imp.Text)).ToLower) Then
                    dgw_cta_imp.CurrentCell = (dgw_cta_imp.Rows.Item(i).Cells.Item(1))
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
        dgw_det_01.Rows.Clear()
        Try
            Dim PRO_02 As New SqlCommand("MOSTRAR_T_CON_CXC_GENERACION", con)
            PRO_02.CommandType = (CommandType.StoredProcedure)
            PRO_02.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX)
            PRO_02.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = (COD_COMP)
            PRO_02.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = (txt_nro_comp.Text)
            PRO_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            PRO_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            con.Open()
            PRO_02.ExecuteNonQuery()
            Dim RS2 As SqlDataReader = PRO_02.ExecuteReader
            Do While RS2.Read
                If (RS2.GetValue(25) = "T") Then
                    dgw_doc_01.Rows.Add((RS2.GetValue(20)), (RS2.GetValue(21)), (RS2.GetValue(22)), (RS2.GetValue(&H29)), (RS2.GetValue(23)), (RS2.GetValue(19)), (RS2.GetValue(35)), (RS2.GetValue(6)), (RS2.GetValue(7)), (RS2.GetValue(5)), (RS2.GetValue(38)), (RS2.GetValue(39)), (RS2.GetValue(40)), (RS2.GetValue(12)), (RS2.GetValue(1)), (RS2.GetValue(2)))
                End If
                dgw_det_01.Rows.Add((RS2.GetValue(0)), (RS2.GetValue(1)), (RS2.GetValue(2)), (RS2.GetValue(3)), (RS2.GetValue(4)), (RS2.GetValue(5)), (RS2.GetValue(6)), (RS2.GetValue(7)), (RS2.GetValue(8)), (RS2.GetValue(9)), (RS2.GetValue(10)), (RS2.GetValue(11)), (RS2.GetValue(12)), (RS2.GetValue(13)), (RS2.GetValue(14)), (RS2.GetValue(15)), (RS2.GetValue(16)), (RS2.GetValue(17)), (RS2.GetValue(18)), (RS2.GetValue(19)), (RS2.GetValue(20)), (RS2.GetValue(21)), (RS2.GetValue(22)), (RS2.GetValue(23)), (RS2.GetValue(24)), (RS2.GetValue(25)), (RS2.GetValue(26)), (RS2.GetValue(27)), (RS2.GetValue(28)), (RS2.GetValue(29)), (RS2.GetValue(30)), (RS2.GetValue(31)), (RS2.GetValue(32)), (RS2.GetValue(33)), (RS2.GetValue(34)), (RS2.GetValue(35)), (RS2.GetValue(36)), (RS2.GetValue(37)))
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
        Dim cod_dh As String = dgw_mov1.Item(5, dgw_mov1.CurrentRow.Index).Value.ToString
        cbo_d_h.Text = cod_dh
        lbl_moneda_det.Text = cbo_moneda.Text
        Dim MON0 As String = COD_MONEDA
        If (dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value.ToString = "A") Then
            lbl_moneda_det.Text = "AJUSTE"
            MON0 = "A"
        End If
        Dim igv As Decimal = (dgw_mov1.Item(22, dgw_mov1.CurrentRow.Index).Value.ToString)
        If (STATUS_PV = "1") Then
            If (MON0 = "D") Then
                txt_bi.Text = (Math.Round(CDbl((Double.Parse((dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 3))
            Else
                txt_bi.Text = (Math.Round(CDbl((Double.Parse((dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)) * Convert.ToDouble(Decimal.Divide(Decimal.Add(IGV0, 100), 100)))), 3))
            End If
        ElseIf (MON0 = "D") Then
            txt_bi.Text = (dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)
        Else
            txt_bi.Text = (dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)
        End If
        txt_bi.Text = (OBJ.HACER_DECIMAL(txt_bi.Text))
        txt_glosa.Text = (dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value)
        CBO_CC.Enabled = False
        CBO_CC.SelectedIndex = -1
        cbo_proyecto.SelectedIndex = -1
        cbo_proyecto.Enabled = False
        STATUS_CC = (dgw_mov1.Item(16, dgw_mov1.CurrentRow.Index).Value)
        STATUS_P = (dgw_mov1.Item(18, dgw_mov1.CurrentRow.Index).Value)
        If ((STATUS_CC) = 1) Then
            CBO_CC.Enabled = True
            CBO_CC.Text = OBJ.DESC_CC(dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value.ToString)
        End If
        cbo_control.Text = OBJ.DESC_CONTROL((dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value))
        If ((STATUS_P) = 1) Then
            cbo_proyecto.Enabled = True
            cbo_proyecto.Text = OBJ.DESC_PROYECTO((dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value))
        End If
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        Panel_det02.Visible = True
    End Sub
    Sub CARGAR_DOC_REF()
        Dim cod_ref00 As String = dgw_doc_01.Item(27, dgw_doc_01.CurrentRow.Index).Value.ToString
        cbo_tipo_ref.Text = OBJ.DESC_DOC(cod_ref00)
        txt_nro_ref.Text = dgw_doc_01.Item(28, dgw_doc_01.CurrentRow.Index).Value.ToString
        dtp_ref.Value = (dgw_doc_01.Item(29, dgw_doc_01.CurrentRow.Index).Value.ToString)
    End Sub
    Sub CARGAR_DOCUMENTO(ByVal FILA_DOC0 As Integer)
        COD_DOC = (dgw_doc_01.Item(0, FILA_DOC0).Value)
        txt_nro_doc.Text = (dgw_doc_01.Item(1, FILA_DOC0).Value)
        txt_cod_per0.Text = (dgw_doc_01.Item(2, FILA_DOC0).Value)
        txt_desc_per.Text = (dgw_doc_01.Item(3, FILA_DOC0).Value)
        txt_doc_per.Text = (dgw_doc_01.Item(4, FILA_DOC0).Value)
        dtp_doc.Value = (dgw_doc_01.Item(5, FILA_DOC0).Value)
        COD_MONEDA = (dgw_doc_01.Item(7, FILA_DOC0).Value)
        cbo_moneda.Text = OBJ.DESC_MONEDA(COD_MONEDA)
        cbo_tipo_doc.Text = OBJ.DESC_DOC(COD_DOC)
        If (txt_cod_per0.Text <> "00000") Then
            txt_desc_per.Text = OBJ.DESC_PERSONA(txt_cod_per0.Text)
        End If
        txt_cambio.Text = dgw_doc_01.Item(8, FILA_DOC0).Value.ToString
        cbo_cte.SelectedIndex = 0
        txt_cta_total.Text = dgw_doc_01.Item(14, FILA_DOC0).Value.ToString
        txt_desc_cta.Text = OBJ.DESC_CUENTA(txt_cta_total.Text, AÑO)
        TXT_GLOSA_T.Text = dgw_doc_01.Item(15, FILA_DOC0).Value.ToString
        COD_DH_DOC = (dgw_doc_01.Item(9, FILA_DOC0).Value)
        dtp_vence.Value = (dgw_doc_01.Item(13, FILA_DOC0).Value)
        dgw_mov1.Rows.Clear()
        Dim cont_r_4 As Integer = dgw_det_01.RowCount
        'Dim VB$t_i4$L0 As Integer = (cont_r_4 - 1)
        Dim l As Integer = 0
        Do While (l <= (cont_r_4 - 1))
            'If Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dgw_det_01.Item(20, l).Value, COD_DOC, False), Operators.CompareObjectEqual(dgw_det_01.Item(21, l).Value, txt_nro_doc.Text, False)), Operators.CompareObjectEqual(dgw_det_01.Item(22, l).Value, txt_cod_per0.Text, False)), Operators.CompareObjectEqual(dgw_det_01.Item(23, l).Value, txt_doc_per.Text, False)), Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(dgw_det_01.Item(25, l).Value, "B", False), Operators.CompareObjectEqual(dgw_det_01.Item(25, l).Value, "I", False)), Operators.CompareObjectEqual(dgw_det_01.Item(25, l).Value, "T", False)))) Then
            If dgw_det_01.Item(20, l).Value = COD_DOC And dgw_det_01.Item(21, l).Value = txt_nro_doc.Text And dgw_det_01.Item(22, l).Value = txt_cod_per0.Text And dgw_det_01.Item(23, l).Value = txt_doc_per.Text And (dgw_det_01.Item(25, l).Value = "B" Or dgw_det_01.Item(25, l).Value = "I" Or dgw_det_01.Item(25, l).Value = "T") Then
                'Dim VB$t_ref$L0 As Object = dgw_det_01.Item(25, l).Value
                If dgw_det_01.Item(25, l).Value = "B" Then
                    dgw_mov1.Rows.Add((dgw_det_01.Item(0, l).Value), (dgw_det_01.Item(1, l).Value), (dgw_det_01.Item(2, l).Value), (OBJ.HACER_DECIMAL((dgw_det_01.Item(3, l).Value))), (OBJ.HACER_DECIMAL((dgw_det_01.Item(4, l).Value))), (dgw_det_01.Item(5, l).Value), (dgw_det_01.Item(6, l).Value), (dgw_det_01.Item(7, l).Value), (dgw_det_01.Item(8, l).Value), (dgw_det_01.Item(9, l).Value), (dgw_det_01.Item(10, l).Value), (dgw_det_01.Item(11, l).Value), (dgw_det_01.Item(12, l).Value), (dgw_det_01.Item(13, l).Value), (dgw_det_01.Item(14, l).Value), (dgw_det_01.Item(15, l).Value), (dgw_det_01.Item(16, l).Value), (dgw_det_01.Item(17, l).Value), (dgw_det_01.Item(18, l).Value), (dgw_det_01.Item(19, l).Value), (dgw_det_01.Item(26, l).Value), (dgw_det_01.Item(27, l).Value), (dgw_det_01.Item(34, l).Value))
                End If
            End If
            l += 1
        Loop
        Try
            Dim A1 As Integer = dtp_doc.Value.Day
            Dim A2 As Integer = dtp_vence.Value.Day
            TXT_DIA1.Text = (CInt((A2 - A1)))
        Catch ex As Exception


            TXT_DIA1.Text = (0)

        End Try
        HALLAR_TOTAL_DOC()
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
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX)
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
        Try
            Dim PROG_01 As New SqlCommand("CBO_CONTROL_FECHA", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = (FECHA_GRAL)
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
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
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
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = (FECHA_GRAL)
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
    Sub CBO_REFERENCIA()
        cbo_tipo_ref.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_REF", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_ref.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub
    Function CONTAR_AJUSTE() As Boolean
        'Dim VB$t_i4$L0 As Integer = (dgw_mov1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw_mov1.RowCount - 1))
            If (dgw_mov1.Item(6, i).Value.ToString = "A") Then
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function
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
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@tipo", SqlDbType.VarChar).Value = "CCGEN"
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Cuentas")
            Prog02.Fill(dt_02)
            dgw1.DataSource = (dt_02)
            dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw1.Columns.Item(0).Visible = (False)
            dgw1.Columns.Item(2).Visible = (False)
            dgw1.Columns.Item(2).Visible = (False)
            'dgw1.Columns.Item(6).Visible = (False)
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
    End Sub
    Private Sub dgw_cta_imp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_imp.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_imp.Text = dgw_cta_imp.Item(0, dgw_cta_imp.CurrentRow.Index).Value.ToString
            txt_desc_cta_imp.Text = dgw_cta_imp.Item(1, dgw_cta_imp.CurrentRow.Index).Value.ToString
            STATUS_CC = dgw_cta_imp.Item(2, dgw_cta_imp.CurrentRow.Index).Value.ToString
            STATUS_P = dgw_cta_imp.Item(3, dgw_cta_imp.CurrentRow.Index).Value.ToString
            txt_glosa.Text = txt_desc_cta_imp.Text
            CBO_CC.Enabled = False
            cbo_proyecto.Enabled = False
            If ((STATUS_CC) = 1) Then
                CBO_CC.Enabled = True
            End If
            If ((STATUS_P) = 1) Then
                cbo_proyecto.Enabled = True
            End If
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
            txt_cta_total.Text = dgw_cta_t.Item(0, dgw_cta_t.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta_t.Item(1, dgw_cta_t.CurrentRow.Index).Value.ToString
            txt_cta0.Focus()
            Panel_CTA.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_CTA.Visible = False
            txt_cta_total.Focus()
            txt_desc_cta.Clear()
            txt_cta_total.Focus()
        End If
    End Sub
    Sub DGW_CUENTAS()
        Try
            dgw_cta_imp.DataSource = OBJ.MOSTRAR_CUENTAS_STATUS(AÑO)
            dgw_cta_imp.ColumnHeadersDefaultCellStyle.Font = (New Font("Arial", 8.0!, FontStyle.Bold))
            dgw_cta_imp.Columns.Item(2).Visible = (False)
            dgw_cta_imp.Columns.Item(3).Visible = (False)
            dgw_cta_imp.Columns.Item(4).Visible = (False)
            dgw_cta_imp.Columns.Item(0).Width = (70)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Try
            dgw_cta_t.DataSource = OBJ.MOSTRAR_CUENTAS_STATUS(AÑO)
            dgw_cta_t.ColumnHeadersDefaultCellStyle.Font = (New Font("Arial", 8.0!, FontStyle.Bold))
            dgw_cta_t.Columns.Item(2).Visible = (False)
            dgw_cta_t.Columns.Item(3).Visible = (False)
            dgw_cta_t.Columns.Item(4).Visible = (False)
            dgw_cta_t.Columns.Item(0).Width = (70)
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txt_desc_per.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
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
            dgw_per.DataSource = (OBJ.MOSTRAR_PERSONAS_COBRAR)
            dgw_per.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw_per.Columns.Item(0).Width = (50)
            dgw_per.Columns.Item(1).Width = (&HEB)
        Catch ex As Exception


            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub
    Private Sub dtp_doc_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_doc.LostFocus
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = OBJ.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
        Try
            dtp_vence.Value = dtp_doc.Value.AddDays((TXT_DIA1.Text))
        Catch ex As Exception


            TXT_DIA1.Text = (0)
            dtp_vence.Value = dtp_doc.Value

        End Try
    End Sub

    Sub ELIMINAR_DOCUMENTO_DGW(ByVal fila_doc0 As Integer)
        Dim cod_doc_05 As String = (dgw_doc_01.Item(0, fila_doc0).Value)
        Dim nro_doc_05 As String = (dgw_doc_01.Item(1, fila_doc0).Value)
        Dim cod_per_05 As String = (dgw_doc_01.Item(2, fila_doc0).Value)
        Dim nro_doc_per_05 As String = (dgw_doc_01.Item(4, fila_doc0).Value)
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

    Function HALLAR_ITEM() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_mov1.Rows.Count - 1)

        i = 0
        Do While (i <= cont)
            If (dgw_mov1.Item(0, i).Value > mayor) Then
                mayor = (dgw_mov1.Item(0, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("00")
    End Function
    Sub HALLAR_TOTAL_DOC()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim DEBE_SOLES As Decimal = 0
        Dim DEBE_DOLARES As Decimal = 0
        Dim HABER_SOLES As Decimal = 0
        Dim HABER_DOLARES As Decimal = 0

        I = 0
        Do While (I <= CONT)
            If (dgw_mov1.Item(5, I).Value.ToString.ToString = "D") Then
                DEBE_SOLES = Decimal.Add(DEBE_SOLES, Decimal.Parse((dgw_mov1.Item(3, I).Value)))
                DEBE_DOLARES = Decimal.Add(DEBE_DOLARES, Decimal.Parse((dgw_mov1.Item(4, I).Value)))
            Else
                HABER_SOLES = Decimal.Add(HABER_SOLES, Decimal.Parse((dgw_mov1.Item(3, I).Value)))
                HABER_DOLARES = Decimal.Add(HABER_DOLARES, Decimal.Parse((dgw_mov1.Item(4, I).Value)))
            End If
            I += 1
        Loop
        ' ''DEBE_SOLES = HABER_SOLES
        ' ''DEBE_DOLARES = HABER_DOLARES
        txt_debe_soles.Text = (DEBE_SOLES)
        txt_debe_dolares.Text = (DEBE_DOLARES)
        txt_haber_soles.Text = (HABER_SOLES)
        txt_haber_dolares.Text = (HABER_DOLARES)
        txt_saldo_soles.Text = (Decimal.Subtract(HABER_SOLES, DEBE_SOLES))
        txt_saldo_dolares.Text = (Decimal.Subtract(HABER_DOLARES, DEBE_DOLARES))
        txt_debe_soles.Text = (OBJ.HACER_DECIMAL(txt_debe_soles.Text))
        txt_debe_dolares.Text = (OBJ.HACER_DECIMAL(txt_debe_dolares.Text))
        txt_haber_soles.Text = (OBJ.HACER_DECIMAL(txt_haber_soles.Text))
        txt_haber_dolares.Text = (OBJ.HACER_DECIMAL(txt_haber_dolares.Text))
        txt_saldo_soles.Text = (OBJ.HACER_DECIMAL(txt_saldo_soles.Text))
        txt_saldo_dolares.Text = (OBJ.HACER_DECIMAL(txt_saldo_dolares.Text))
    End Sub
    Sub INSERTAR_DOCUMENTO_DGW()
        Dim imp_d_t As Decimal
        Dim imp_s_t As Decimal
        Dim imp_t00 As Decimal
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        If (cbo_cte.SelectedIndex = 0) Then
        End If
        Dim j As Integer = 0

        j = 0
        Do While (j <= CONT)
            Dim var0 As String = dgw_mov1.Item(0, j).Value
            Dim var1 As String = dgw_mov1.Item(1, j).Value
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
            Dim var12 As DateTime = (dgw_mov1.Item(12, j).Value)
            Dim var13 As String = (dgw_mov1.Item(13, j).Value)
            Dim var14 As String = (dgw_mov1.Item(14, j).Value)
            Dim var15 As String = (dgw_mov1.Item(15, j).Value)
            Dim var16 As String = (dgw_mov1.Item(16, j).Value)
            Dim var17 As String = (dgw_mov1.Item(17, j).Value)
            Dim var18 As String = (dgw_mov1.Item(18, j).Value)
            Dim var19 As DateTime = (dgw_mov1.Item(19, j).Value)
            Dim var20 As String = (dgw_mov1.Item(20, j).Value)
            Dim var21 As String = (dgw_mov1.Item(21, j).Value)
            Dim var22 As String = (dgw_mov1.Item(22, j).Value)
            Dim imp_doc00 As New Decimal
            imp_doc00 = (var3)
            If (var6 <> "S") Then
                imp_doc00 = (var4)
            End If
            dgw_det_01.Rows.Add(var0, var1, var2, Math.Round(Decimal.Parse(var3), 2), Math.Round(Decimal.Parse(var4), 2), var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, var15, var16, var17, var18, var19, COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, "0", "B", var20, var21, "0", " ", " ", dtp_doc.Value, 0, " ", var22, imp_doc00, "0", "0")
            j += 1
        Loop
        '----------------------------------------
        imp_s_t = New Decimal(Double.Parse(txt_saldo_soles.Text))
        imp_d_t = New Decimal(Double.Parse(txt_saldo_dolares.Text))
        '----------------------------------------
        COD_DH_DOC = "D"
        If imp_s_t < 0 Then
            COD_DH_DOC = "H"
        End If
        If (COD_MONEDA = "S") Then
            imp_t00 = imp_s_t
        Else
            imp_t00 = imp_d_t
        End If
        dgw_det_01.Rows.Add((CONT + 2).ToString("0000"), txt_cta_total.Text, TXT_GLOSA_T.Text, imp_s_t, imp_d_t, COD_DH_DOC, COD_MONEDA, txt_cambio.Text, " ", " ", " ", "", dtp_vence.Value, 0, " ", " ", " ", " ", " ", dtp_doc.Value, COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_doc_per.Text, 0, "T", "", "", "0", " ", " ", dtp_doc.Value, 0, " ", 0, imp_t00, "0", "0")
        Dim IMP_DOC As New Decimal
        IMP_DOC = imp_s_t
        If (COD_MONEDA = "D") Then
            IMP_DOC = imp_d_t
        End If
        dgw_doc_01.Rows.Add(New Object() {COD_DOC, txt_nro_doc.Text, txt_cod_per0.Text, txt_desc_per.Text, txt_doc_per.Text, dtp_doc.Value, IMP_DOC, COD_MONEDA, txt_cambio.Text, COD_DH_DOC, "", "", dtp_doc.Value, dtp_vence.Value, txt_cta_total.Text, TXT_GLOSA_T.Text})
    End Sub
    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det_01.RowCount - 1)
        DT_DET.Rows.Clear()

        I = 0
        Do While (I <= CONT)
            'Dim VB$t_array$S0 As Object() = New Object() { AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "", "", DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC }
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "", "", DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.T_CON2")
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'Dim INSERTAR_TODO As String = estado
            Return estado
        End Try
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_CXC_GENERACION", con)
            comand1.CommandType = (CommandType.StoredProcedure)
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
        cbo_aux.SelectedIndex = -1
        cbo_com.SelectedIndex = -1
        txt_nro_comp.Clear()
        dtp_com.Value = FECHA_GRAL
        dgw_doc_01.Rows.Clear()
        btn_imprimir.Enabled = False
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = False
        dgw_doc_01.Rows.Clear()
        btn_grabar_com.Enabled = True
        dgw_det_01.Rows.Clear()
        TabControl3.Visible = False
        Panel_DOC02.Visible = False
        Panel2.Enabled = True
    End Sub
    Sub LIMPIAR_DETALLES()
        txt_cta_imp.Clear()
        txt_desc_cta_imp.Clear()
        txt_bi.Clear()
        cbo_d_h.Text = "H"
        If (COD_DH_DOC = "H") Then
            cbo_d_h.Text = "D"
        End If
        txt_glosa.Clear()
        CBO_CC.SelectedIndex = -1
        cbo_control.SelectedIndex = -1
        cbo_proyecto.SelectedIndex = -1
        'TXT_IGV0.Text = (OBJ.HACER_DECIMAL(IGV0))
        CBO_CC.Enabled = False
        cbo_control.Enabled = False
        cbo_proyecto.Enabled = True
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        Panel_cta_det.Visible = False
        lbl_moneda_det.Text = cbo_moneda.Text
    End Sub
    Sub LIMPIAR_DOCUMENTOS()
        panel1.Enabled = True
        cbo_tipo_doc.SelectedIndex = -1
        txt_nro_doc.Clear()
        TXT_DIA1.Text = (0)
        dtp_doc.Value = Now.Date
        dtp_vence.Value = Now.Date
        txt_cod_per0.Clear()
        txt_desc_per.Clear()
        txt_doc_per.Clear()
        cbo_moneda.SelectedIndex = -1
        txt_cambio.Clear()
        dgw_mov1.Rows.Clear()
        Panel_det02.Visible = False
        txt_cta_total.Clear()
        txt_desc_cta.Clear()
        txt_debe_soles.Text = "0.00"
        txt_debe_dolares.Text = "0.00"
        txt_haber_soles.Text = "0.00"
        txt_haber_dolares.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        txt_saldo_dolares.Text = "0.00"
        TXT_GLOSA_T.Clear()
        Panel_per.Visible = False
        btn_grabar_doc.Visible = True
        btn_grabar_doc2.Visible = False
    End Sub
    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_doc_01.Rows.Count - 1)
        I = 0
        CONT = (dgw_det_01.RowCount - 1)
        DT_DET.Rows.Clear()

        I = 0
        Do While (I <= CONT)
            'Dim VB$t_array$S0 As Object() = New Object() { AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "", "", DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC }
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det_01.Item(20, I).Value), (dgw_det_01.Item(21, I).Value), (dgw_det_01.Item(22, I).Value), (dgw_det_01.Item(23, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_det_01.Item(19, I).Value)), "", "", DateTime.Parse((dgw_det_01.Item(19, I).Value)), (dgw_det_01.Item(2, I).Value), (dgw_det_01.Item(1, I).Value), Decimal.Parse((dgw_det_01.Item(3, I).Value)), Decimal.Parse((dgw_det_01.Item(4, I).Value)), (dgw_det_01.Item(5, I).Value), (dgw_det_01.Item(6, I).Value), Decimal.Parse((dgw_det_01.Item(7, I).Value)), (dgw_det_01.Item(8, I).Value), (dgw_det_01.Item(9, I).Value), (dgw_det_01.Item(10, I).Value), (dgw_det_01.Item(11, I).Value), DateTime.Parse((dgw_det_01.Item(12, I).Value)), (dgw_det_01.Item(13, I).Value), (dgw_det_01.Item(14, I).Value), (dgw_det_01.Item(15, I).Value), (dgw_det_01.Item(24, I).Value), (dgw_det_01.Item(25, I).Value), (dgw_det_01.Item(37, I).Value), (dgw_det_01.Item(28, I).Value), (dgw_det_01.Item(29, I).Value), (dgw_det_01.Item(30, I).Value), DateTime.Parse((dgw_det_01.Item(31, I).Value)), (dgw_det_01.Item(32, I).Value), (dgw_det_01.Item(33, I).Value), (dgw_det_01.Item(36, I).Value), dtp_com.Value, Decimal.Parse((dgw_det_01.Item(34, I).Value)), NOMBRE_PC)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.T_CON2")
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'Dim MODIFICAR_TODO As String = estado
            Return estado
        End Try
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_CXC_GENERACION", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = (COD_AUX)
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = (COD_COMP)
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = (txt_nro_comp.Text)
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = (dtp_com.Value)
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = (COD_USU)
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = (Now.Date)
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = (NOMBRE_PC)
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
        If Asc(e.KeyChar) = 8 Then
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
    Private Sub txt_bi_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_bi.KeyPress
        e.Handled = Numero(e, (txt_bi))
    End Sub
    Private Sub txt_bi_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_bi.LostFocus
        Try
            txt_bi.Text = (OBJ.HACER_DECIMAL(txt_bi.Text))
        Catch ex As Exception
            txt_bi.Text = "0.00"
        End Try
    End Sub
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
    Private Sub TXT_COD_PER0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per0.LostFocus
        If (Strings.Trim(txt_cod_per0.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_cod_per0.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per0.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        TXT_GLOSA_T.Text = txt_desc_per.Text
                        cbo_moneda.Focus()
                        Return
                    End If
                    If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_cta_imp_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_imp.LostFocus
        If (Strings.Trim(txt_cta_imp.Text) <> "") Then
            If (dgw_cta_imp.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_imp.Sort(dgw_cta_imp.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_imp.RowCount - 1))
                    If (txt_cta_imp.Text.ToLower = dgw_cta_imp.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta_imp.Text = dgw_cta_imp.Item(0, i).Value.ToString
                        txt_desc_cta_imp.Text = dgw_cta_imp.Item(1, i).Value.ToString
                        STATUS_CC = dgw_cta_imp.Item(2, i).Value.ToString
                        STATUS_P = dgw_cta_imp.Item(3, i).Value.ToString
                        CBO_CC.Enabled = False
                        cbo_proyecto.Enabled = False
                        txt_glosa.Text = txt_desc_cta_imp.Text
                        If ((STATUS_CC) = 1) Then
                            CBO_CC.Enabled = True
                        End If
                        If ((STATUS_P) = 1) Then
                            cbo_proyecto.Enabled = True
                        End If
                        SendKeys.Send("{Tab}")
                        Return
                    End If
                    If (txt_cta_imp.Text.ToLower = Strings.Mid((dgw_cta_imp.Item(0, i).Value), 1, Strings.Len(txt_cta_imp.Text)).ToLower) Then
                        dgw_cta_imp.CurrentCell = (dgw_cta_imp.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cta_imp.CurrentCell = (dgw_cta_imp.Rows.Item(0).Cells.Item(0))
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
            Dim i As Integer = 20
            Do While (i <= (dgw_cta_t.RowCount - 1))
                If (txt_cta_total.Text.ToLower = dgw_cta_t.Item(0, i).Value.ToString.ToLower) Then
                    txt_cta_total.Text = dgw_cta_t.Item(0, i).Value.ToString
                    txt_desc_cta.Text = dgw_cta_t.Item(1, i).Value.ToString
                    cbo_moneda.Focus()
                    Return
                End If
                If (txt_cta_total.Text.ToLower = Strings.Mid((dgw_cta_t.Item(0, i).Value), 1, Strings.Len(txt_cta_total.Text)).ToLower) Then
                    dgw_cta_t.CurrentCell = (dgw_cta_t.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                dgw_cta_t.CurrentCell = (dgw_cta_t.Rows.Item(0).Cells.Item(0))
                i += 1
            Loop
            Panel_CTA.Visible = True
            dgw_cta_t.Focus()
        End If
    End Sub
    Private Sub TXT_DESC_cta_imp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta_imp.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_imp.Text) <> "")) Then
            If (dgw_cta_imp.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_imp.Sort(dgw_cta_imp.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_imp.RowCount - 1))
                    If (txt_desc_cta_imp.Text.ToLower = Strings.Mid(dgw_cta_imp.Item(1, i).Value, 1, txt_desc_cta_imp.TextLength).ToLower) Then
                        dgw_cta_imp.CurrentCell = (dgw_cta_imp.Rows.Item(i).Cells.Item(1))
                        Exit Do
                    End If
                    dgw_cta_imp.CurrentCell = (dgw_cta_imp.Rows.Item(0).Cells.Item(1))
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
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DIA1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TXT_DIA1.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TXT_DIA1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_DIA1.TextChanged
        Try
            dtp_vence.Value = dtp_doc.Value.AddDays((TXT_DIA1.Text))
        Catch ex As Exception


            TXT_DIA1.Text = (0)
            dtp_vence.Value = dtp_doc.Value

        End Try
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Function VALIDAR_TRASNF_CUENTA(ByVal cod_doc As String, ByVal nro_doc As String, ByVal cod_per As String, ByVal doc_per As String) As String
        Dim i As Integer = 0
        Dim CUENTA As String = ""
        i = 0
        Do While (i <= (dgw_det_01.RowCount - 1))
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
        I = 0
        Do While (I <= CONT)
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

    Private Sub GENERACION_CXC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub GENERACION_CXC_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub

    Private Sub GENERACION_CXP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub GENERACION_CXP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CREAR_DATASET()
        CBO_AUXILIAR()
        CBO_DOCUMENTO()
        DGW_PERSONAS()
        CBO_MONEDA0()
        CBO_REFERENCIA()
        DGW_CUENTAS()
        IGV0 = (OBJ.IMPUESTO("IGV"))
        DGW_CC0()
        CBO_CONTROL0()
        CBO_PROYECTO0()
        dgw_doc_01.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        btn_nuevo.Select()
    End Sub
    Private Sub txt_desc_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta_t.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_t.Sort(dgw_cta_t.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim i As Integer = 0
                Do While (i <= (dgw_cta_t.RowCount - 1))
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta_t.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta_t.CurrentCell = (dgw_cta_t.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cta_t.CurrentCell = (dgw_cta_t.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_CTA.Visible = True
                dgw_cta_t.Visible = True
                dgw_cta_t.Focus()
            End If
        End If
    End Sub
    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim RSPTA As String = MessageBox.Show("Está seguro de eliminar el detalles?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If RSPTA = vbYes Then
            dgw_mov1.Rows.RemoveAt(dgw_mov1.CurrentRow.Index)
            HALLAR_TOTAL_DOC()
            btn_nuevo_det.Focus()
        End If
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage3.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub
End Class