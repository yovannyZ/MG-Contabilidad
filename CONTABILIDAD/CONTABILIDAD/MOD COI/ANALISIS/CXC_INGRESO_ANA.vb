Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class CXC_INGRESO_ANA
    Dim BOTON, COD_AUX, COD_COMP, MES00, COD_DOC, COD_MONEDA, COD_REF, DOLAR, SOL As String
    Dim DT_DET As New DataTable
    Dim IGV0 As Decimal
    Dim OBJ As New Class1
    Private Sub btn_cancelar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_com.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()
    End Sub
    Private Sub btn_consultar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consultar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        BOTON = "CONSULTA"
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = False
        btn_imprimir.Enabled = True
        TabControl1.SelectedTab = TabPage2
        btn_imprimir.Focus()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If MessageBox.Show("Desea borrar el Comprobante", " Borrar Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = 6 Then
            COD_AUX = dgw1.Item(0, dgw1.CurrentRow.Index).Value
            COD_COMP = dgw1.Item(2, dgw1.CurrentRow.Index).Value
            txt_nro_comp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_A_TCXC", con)
                comand1.CommandType = (CommandType.StoredProcedure)
                comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
                comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
                comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
                comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES00
                con.Open()
                ESTADO = comand1.ExecuteScalar
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
                ESTADO = "FALLO"
            End Try
            If (ESTADO = "FALLO") Then
                MessageBox.Show("Vuelva a Intentarlo", "Ocurrió un error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            DATAGRID()
        End If
    End Sub
    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        COD_DOC = dgw_mov1.Item(7, dgw_mov1.CurrentRow.Index).Value
        txt_nro_doc0.Text = dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value
        txt_cod_per0.Text = dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value
        txt_nro_doc_per0.Text = dgw_mov1.Item(12, dgw_mov1.CurrentRow.Index).Value
        txt_cod_cta0.Text = dgw_mov1.Item(0, dgw_mov1.CurrentRow.Index).Value
        If OBJ.VERIFICAR_ELIMINAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False Then
            MessageBox.Show("El Documento ha sido cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf MessageBox.Show("Esta seguro de eliminar el detalles", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = 6 Then
            dgw_mov1.Rows.RemoveAt(dgw_mov1.CurrentRow.Index)
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
        ElseIf (OBJ.VALIDAR_FECHA_COMP(dtp_com.Value) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        Else
            If (INSERTAR_TODO = "EXITO") Then
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
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
        ElseIf (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo_det.Focus()
        Else
            If (MODIFICAR_TODO = "EXITO") Then
                MessageBox.Show("El Comprobante se actualizó con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
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
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If OBJ.VERIFICAR_CIERRE_CUENTAS(txt_cod_cta0.Text, AÑO, MES00) = False Then Exit Sub
        If (Panel_CXP.Visible Or (Strings.Trim(txt_cod_per0.Text) = "")) Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
        ElseIf ((Strings.Trim(txt_cod_cta0.Text) = "") Or Panel_cta.Visible) Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
        ElseIf (cbo_tipo_doc0.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc0.Focus()
        ElseIf ((Strings.Trim(txt_nro_doc0.Text) = "") Or Panel_cta.Visible) Then
            MessageBox.Show("Debe ingresar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc0.Focus()
        ElseIf ((Strings.Trim(txt_glosa0.Text) = "")) Then
            MessageBox.Show("Debe ingresar la Glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_glosa0.Focus()
        ElseIf (cbo_moneda1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda1.Focus()
        ElseIf ((txt_cambio0.Text.Trim = "") Or (txt_cambio0.Text.Trim = "0.0000")) Then
            MessageBox.Show("Debe ingresar el  Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio0.Focus()
        ElseIf ((txt_imp_soles0.Text.Trim = "") Or (txt_imp_soles0.Text.Trim = "0.0000")) Then
            MessageBox.Show("Debe ingresar el  Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_imp_soles0.Focus()
        Else
            COD_DOC = OBJ.COD_DOC(cbo_tipo_doc0.Text)
            COD_REF = ""
            If (cbo_tipo_ref0.SelectedIndex <> -1) Then
                COD_REF = OBJ.COD_DOC(cbo_tipo_ref0.Text)
            End If
            If VALIDAR_DGW(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_cod_cta0.Text) = False Then
                MessageBox.Show("El Documento ya se ingresó .", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_nro_doc0.Focus()
            ElseIf OBJ.VERIFICAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False Then
                MessageBox.Show("El Documento ya existe en Ctas. x Cobrar", "El documento ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Select Case COD_MONEDA
                    Case "S"
                        SOL = txt_imp_soles0.Text
                        DOLAR = (OBJ.HACER_DECIMAL(((txt_imp_soles0.Text) / (txt_cambio0.Text))))
                    Case "D"
                        SOL = (OBJ.HACER_DECIMAL(((txt_imp_soles0.Text) * (txt_cambio0.Text))))
                        DOLAR = txt_imp_soles0.Text

                    Case "A"
                        SOL = txt_imp_soles0.Text
                        DOLAR = 0
                End Select

                dgw_mov1.Rows.Add(txt_cod_cta0.Text, txt_glosa0.Text, SOL, DOLAR, cbo_d_h.Text, COD_MONEDA, txt_cambio0.Text, COD_DOC, txt_nro_doc0.Text, dtp_doc0.Value, txt_cod_per0.Text, txt_desc_per0.Text, txt_nro_doc_per0.Text, COD_REF, txt_nro_ref0.Text, txt_imp_soles0.Text, dtpFechaVen.Value)
                HALLAR_TOTAL()
                LIMPIAR_DOCUMENTO()
                txt_cod_per0.Focus()
            End If
        End If
    End Sub
    Private Sub btn_mod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod.Click
        Try
            Dim i As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End Try
        LIMPIAR_DOCUMENTO()
        item.Text = (dgw_mov1.CurrentRow.Index)
        CARGAR_DETALLE1()
        If OBJ.VERIFICAR_ELIMINAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False Then
            MessageBox.Show("El Documento ha sido cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            btn_guardar.Visible = False
            btn_modificar2.Visible = True
            item.Text = (dgw_mov1.CurrentRow.Index)
            txt_cod_cta0.Enabled = False
            txt_desc_cta0.Enabled = False
            txt_cod_per0.Enabled = False
            txt_desc_per0.Enabled = False
            txt_desc_per0.Enabled = False
            cbo_tipo_doc0.Enabled = False
            txt_nro_doc0.Enabled = False
            Panel_doc.Visible = True
            cbo_moneda1.Focus()
        End If
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
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = True
        g_cab.Enabled = False
        btn_grabar_com2.Enabled = True
        btn_imprimir.Enabled = False
        TabControl1.SelectedTab = (TabPage2)
        btn_nuevo_det.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (Panel_CXP.Visible Or (Strings.Trim(txt_cod_per0.Text) = "")) Then
            MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
        ElseIf ((Strings.Trim(txt_cod_cta0.Text) = "") Or Panel_cta.Visible) Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
        ElseIf (cbo_tipo_doc0.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc0.Focus()
        ElseIf ((Strings.Trim(txt_nro_doc0.Text) = "") Or Panel_cta.Visible) Then
            MessageBox.Show("Debe ingresar el Nº de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc0.Focus()
        ElseIf (cbo_moneda1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda1.Focus()
        ElseIf ((txt_cambio0.Text.Trim = "") Or (txt_cambio0.Text.Trim = "0.0000")) Then
            MessageBox.Show("Debe ingresar el  Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio0.Focus()
        ElseIf ((txt_imp_soles0.Text.Trim = "") Or (txt_imp_soles0.Text.Trim = "0.0000")) Then
            MessageBox.Show("Debe ingresar el  Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_imp_soles0.Focus()
        Else
            COD_DOC = OBJ.COD_DOC(cbo_tipo_doc0.Text)
            COD_REF = ""
            If (cbo_tipo_ref0.SelectedIndex <> -1) Then
                COD_REF = OBJ.COD_DOC(cbo_tipo_ref0.Text)
            End If
            Select Case COD_MONEDA
                Case "S"
                    SOL = txt_imp_soles0.Text
                    DOLAR = (OBJ.HACER_DECIMAL(((txt_imp_soles0.Text) / (txt_cambio0.Text))))
                Case "D"
                    SOL = (OBJ.HACER_DECIMAL(((txt_imp_soles0.Text) * (txt_cambio0.Text))))
                    DOLAR = txt_imp_soles0.Text

                Case "A"
                    SOL = txt_imp_soles0.Text
                    DOLAR = 0
            End Select

            dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value = (txt_glosa0.Text)
            dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value = (SOL)
            dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value = (DOLAR)
            dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value = (cbo_d_h.Text)
            dgw_mov1.Item(5, dgw_mov1.CurrentRow.Index).Value = (COD_MONEDA)
            dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value = (dtp_doc0.Value)
            dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value = (txt_cambio0.Text)
            dgw_mov1.Item(7, dgw_mov1.CurrentRow.Index).Value = (COD_DOC)
            dgw_mov1.Item(13, dgw_mov1.CurrentRow.Index).Value = (COD_REF)
            dgw_mov1.Item(14, dgw_mov1.CurrentRow.Index).Value = (txt_nro_ref0.Text)
            dgw_mov1.Item(15, dgw_mov1.CurrentRow.Index).Value = (txt_imp_soles0.Text)
            dgw_mov1.Item(16, dgw_mov1.CurrentRow.Index).Value = dtpFechaVen.Value
            Panel_doc.Visible = False
            Me.HALLAR_TOTAL()
            btn_nuevo_det.Focus()
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If (OBJ.ValidarCierreCuentas("CC", AÑO, OBJ.COD_MES(cbo_mes1.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        BOTON = "NUEVO"
        TabControl1.SelectedTab = (TabPage2)
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
    End Sub
    Private Sub btn_nuevo_det_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_det.Click
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
            LIMPIAR_DOCUMENTO()
            Panel_doc.Visible = True
            txt_cod_per0.Focus()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(77) = 0
        Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Panel_doc.Visible = False
        btn_nuevo_det.Focus()
    End Sub
    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        dgw_mov1.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_A_TCXC", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = (COD_AUX)
            pro_02.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = (COD_COMP)
            pro_02.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = (txt_nro_comp.Text)
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = (MES00)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_mov1.Rows.Add((rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(17)))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        HALLAR_TOTAL()
    End Sub
    Sub CARGAR_DETALLE1()
        txt_cod_cta0.Text = (dgw_mov1.Item(0, dgw_mov1.CurrentRow.Index).Value)
        txt_desc_cta0.Text = OBJ.DESC_CUENTA(txt_cod_cta0.Text, AÑO)
        txt_glosa0.Text = (dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value)
        SOL = (dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value)
        DOLAR = (dgw_mov1.Item(3, dgw_mov1.CurrentRow.Index).Value)
        COD_MONEDA = (dgw_mov1.Item(5, dgw_mov1.CurrentRow.Index).Value)
        cbo_moneda1.Text = OBJ.DESC_MONEDA(COD_MONEDA)
        dtp_doc0.Value = (dgw_mov1.Item(9, dgw_mov1.CurrentRow.Index).Value)
        txt_cambio0.Text = (dgw_mov1.Item(6, dgw_mov1.CurrentRow.Index).Value)
        COD_DOC = (dgw_mov1.Item(7, dgw_mov1.CurrentRow.Index).Value)
        cbo_tipo_doc0.Text = OBJ.DESC_DOC(COD_DOC)
        txt_nro_doc0.Text = (dgw_mov1.Item(8, dgw_mov1.CurrentRow.Index).Value)
        cbo_d_h.Text = (dgw_mov1.Item(4, dgw_mov1.CurrentRow.Index).Value)
        txt_cod_per0.Text = (dgw_mov1.Item(10, dgw_mov1.CurrentRow.Index).Value)
        txt_desc_per0.Text = (dgw_mov1.Item(11, dgw_mov1.CurrentRow.Index).Value)
        txt_nro_doc_per0.Text = (dgw_mov1.Item(12, dgw_mov1.CurrentRow.Index).Value)
        COD_REF = (dgw_mov1.Item(13, dgw_mov1.CurrentRow.Index).Value)
        cbo_tipo_ref0.Text = OBJ.DESC_DOC(COD_REF)
        txt_nro_ref0.Text = (dgw_mov1.Item(14, dgw_mov1.CurrentRow.Index).Value)
        If (COD_MONEDA = "S") Or COD_MONEDA = "A" Then
            txt_imp_soles0.Text = SOL
        Else
            txt_imp_soles0.Text = DOLAR
        End If
        dtpFechaVen.Value = dgw_mov1(16, dgw_mov1.CurrentRow.Index).Value

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
            Dim NUM0 As String = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES00)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
        End If
    End Sub
    Sub CBO_COMPROBANTE()
        cbo_com.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX_EXT", con)
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
    Sub CBO_DOCUMENTO()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_doc0.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub
    Sub CBO_MONEDA0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda1.DataSource = DT
        cbo_moneda1.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda1.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda1.SelectedIndex = -1
    End Sub
    Private Sub cbo_moneda1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda1.SelectedIndexChanged
        If (cbo_moneda1.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda1.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio0.Text = OBJ.SACAR_CAMBIO(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), dtp_doc0.Value.ToString("dd"), "D")
            Else
                txt_cambio0.Text = OBJ.SACAR_CAMBIO(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), dtp_doc0.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Sub CBO_REFERENCIA()
        cbo_tipo_ref0.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_REF", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_ref0.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub
    Private Sub cbo_tipo_doc0_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_tipo_doc0.SelectedIndexChanged
        If (cbo_tipo_doc0.SelectedIndex <> -1) Then
            COD_DOC = OBJ.COD_DOC(cbo_tipo_doc0.Text)
            cbo_d_h.Text = OBJ.COD_D_H(COD_DOC)
        End If
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
        DT_DET.Columns.Add("COD_CUENTA")
        DT_DET.Columns.Add("IMP_S")
        DT_DET.Columns.Add("IMP_D")
        DT_DET.Columns.Add("COD_D_H")
        DT_DET.Columns.Add("COD_MONEDA")
        DT_DET.Columns.Add("TIPO_CAMBIO")
        DT_DET.Columns.Add("FECHA_COM")
        DT_DET.Columns.Add("FECHA_VEN")
        DT_DET.Columns.Add("STATUS_CONCILIADO")
        DT_DET.Columns.Add("FECHA_CONTABLE")
        DT_DET.Columns.Add("STATUS_EXT_CONT")
        DT_DET.Columns.Add("STATUS_DIF_CAMBIO")
        DT_DET.Columns.Add("STATUS_DOC")
        DT_DET.Columns.Add("STATUS_ORIGEN")
        DT_DET.Columns.Add("NOMBRE_PC")
    End Sub
    Sub DATAGRID()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_A_TCXC", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = (MES00)
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Cuentas")
            Prog02.Fill(dt_02)
            dgw1.DataSource = (dt_02)
            dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
            dgw1.Columns.Item(0).Visible = (False)
            dgw1.Columns.Item(2).Visible = (False)
            dgw1.Columns.Item(1).Width = 140
            dgw1.Columns.Item(3).Width = 200
            dgw1.Columns.Item(4).Width = 100
            dgw1.Columns.Item(5).Width = 100
            dgw1.Columns.Item(5).DefaultCellStyle.Format = ("d")
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString
            txt_desc_cta0.Text = dgw_cuenta.Item(1, dgw_cuenta.CurrentRow.Index).Value.ToString
            kl1.Focus()
            Panel_cta.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_desc_cta0.Clear()
            txt_cod_cta0.Clear()
            txt_cod_cta0.Focus()
        End If
    End Sub
    Sub DGW_CUENTAS()
        Try
            dgw_cuenta.DataSource = (OBJ.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "C"))
            dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = (New Font("Arial", 8.0!, FontStyle.Bold))
            dgw_cuenta.Columns.Item(2).Visible = (False)
            dgw_cuenta.Columns.Item(3).Visible = (False)
            dgw_cuenta.Columns.Item(4).Visible = (False)
            dgw_cuenta.Columns.Item(0).Width = (70)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            txt_desc_per0.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_nro_doc_per0.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            kl2.Focus()
            Panel_CXP.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_CXP.Visible = False
            txt_cod_per0.Focus()
            txt_cod_per0.Clear()
            txt_desc_per0.Clear()
            txt_nro_doc_per0.Clear()
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
    Private Sub dtp_doc0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_doc0.LostFocus
        If (cbo_moneda1.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda1.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio0.Text = OBJ.SACAR_CAMBIO(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), dtp_doc0.Value.ToString("dd"), "D")
            Else
                txt_cambio0.Text = OBJ.SACAR_CAMBIO(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), dtp_doc0.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Sub HALLAR_TOTAL()
        Dim i As Integer = 0
        Dim cont As Integer = (dgw_mov1.Rows.Count - 1)
        Dim debe As New Decimal
        Dim haber As New Decimal
        Dim debe2 As New Decimal
        Dim haber2 As New Decimal

        i = 0
        Do While (i <= cont)
            If dgw_mov1.Item(4, i).Value = "D" Then
                debe = Decimal.Add(debe, dgw_mov1.Item(2, i).Value)
                debe2 = Decimal.Add(debe2, dgw_mov1.Item(3, i).Value)
            Else
                haber = Decimal.Add(haber, dgw_mov1.Item(2, i).Value)
                haber2 = Decimal.Add(haber2, dgw_mov1.Item(3, i).Value)
            End If
            i += 1
        Loop
        txt_debe.Text = (debe)
        txt_haber.Text = (haber)
        txt_debe2.Text = (debe2)
        txt_haber2.Text = (haber2)
        txt_debe.Text = (OBJ.HACER_DECIMAL(txt_debe.Text))
        txt_haber.Text = (OBJ.HACER_DECIMAL(txt_haber.Text))
        txt_debe2.Text = (OBJ.HACER_DECIMAL(txt_debe2.Text))
        txt_haber2.Text = (OBJ.HACER_DECIMAL(txt_haber2.Text))
    End Sub
    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        DT_DET.Rows.Clear()

        I = 0
        Do While (I <= CONT)
            'Dim VB$t_array$S0 As Object() = New Object() { AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value.ToString, (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(10, I).Value), dgw_mov1.Item(12, I).Value.ToString, (I + 1).ToString("00"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(13, I).Value.ToString, dgw_mov1.Item(14, I).Value.ToString, DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(1, I).Value.ToString, dgw_mov1.Item(0, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), dgw_mov1.Item(4, I).Value.ToString, dgw_mov1.Item(5, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(6, I).Value)), dtp_com.Value.Date, DateTime.Parse((dgw_mov1.Item(9, I).Value)), "0", Now.Date, "1", "0", "0", "0", NOMBRE_PC }
            DT_DET.Rows.Add(AÑO, MES00, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value.ToString, (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(10, I).Value), dgw_mov1.Item(12, I).Value.ToString, (I + 1).ToString("00"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(13, I).Value.ToString, dgw_mov1.Item(14, I).Value.ToString, DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(1, I).Value.ToString, dgw_mov1.Item(0, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), dgw_mov1.Item(4, I).Value.ToString, dgw_mov1.Item(5, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(6, I).Value)), dtp_com.Value.Date, DateTime.Parse((dgw_mov1.Item(16, I).Value)), "0", Now.Date, "1", "0", "0", "0", NOMBRE_PC)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.ANALISIS_TCXC2")
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'Dim INSERTAR_TODO As String = estado
            Return estado
        End Try
        Try
            Dim comand1 As New SqlCommand("INSERTAR_A_TCXC", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = (COD_AUX)
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = (COD_COMP)
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = (txt_nro_comp.Text)
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = (dtp_com.Value)
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = (COD_USU)
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = (Now.Date)
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = (MES00)
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
        If (cbo_com.SelectedIndex <> -1) Then
            Dim SA As String = cbo_com.Text
            cbo_com.SelectedIndex = -1
            cbo_com.Text = SA
        End If
        dtp_com.Value = FECHA_GRAL
        dgw_mov1.Rows.Clear()
        btn_imprimir.Enabled = False
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = False
        btn_grabar_com.Enabled = True
        Panel_doc.Visible = False
        Panel_doc2.Enabled = True
        txt_debe.Text = "0.00"
        txt_haber.Text = "0.00"
        txt_debe2.Text = "0.00"
        txt_haber2.Text = "0.00"
    End Sub
    Sub LIMPIAR_DOCUMENTO()
        'Dim VB$t_ref$L0 As IEnumerator
        'Try
        '    VB$t_ref$L0 = g_doc.Controls.GetEnumerator
        '    Do While VB$t_ref$L0.MoveNext
        '        Dim text As Object = (VB$t_ref$L0.Current)
        '        If TypeOf [Text] Is TextBox Then
        '            NewLateBinding.LateSet([Text], Nothing, "text", New Object() {""}, Nothing, Nothing)
        '            NewLateBinding.LateSet([Text], Nothing, "ENABLED", New Object() {True}, Nothing, Nothing)
        '        End If
        '        If TypeOf [Text] Is ComboBox Then
        '            NewLateBinding.LateSet([Text], Nothing, "SelectedIndex", New Object() {-1}, Nothing, Nothing)
        '            NewLateBinding.LateSet([Text], Nothing, "ENABLED", New Object() {True}, Nothing, Nothing)
        '        End If
        '    Loop
        'Finally
        '    If TypeOf VB$t_ref$L0 Is IDisposable Then
        '        TryCast(VB$t_ref$L0,IDisposable).Dispose
        '    End If
        'End Try
        '------------------------------------------------------
        For Each text As Object In g_doc.Controls
            If TypeOf text Is TextBox Then text.text = "" : text.ENABLED = True
            If TypeOf text Is ComboBox Then text.SelectedIndex = -1 : text.ENABLED = True
        Next
        '------------------------------------------------------
        dtp_doc0.Value = FECHA_GRAL
        Panel_CXP.Visible = False
        Panel_cta.Visible = False
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        txt_imp_soles0.Text = "0.00"
        txt_cambio0.Text = "0.0000"
    End Sub

    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        DT_DET.Rows.Clear()

        I = 0
        Do While (I <= CONT)
            'Dim VB$t_array$S0 As Object() = New Object() { AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value.ToString, (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(10, I).Value), dgw_mov1.Item(12, I).Value.ToString, (I + 1).ToString("00"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(13, I).Value.ToString, dgw_mov1.Item(14, I).Value.ToString, DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(1, I).Value.ToString, dgw_mov1.Item(0, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), dgw_mov1.Item(4, I).Value.ToString, dgw_mov1.Item(5, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(6, I).Value)), dtp_com.Value.Date, DateTime.Parse((dgw_mov1.Item(9, I).Value)), "0", Now.Date, "1", "0", "0", "0", NOMBRE_PC }
            DT_DET.Rows.Add(AÑO, MES00, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value.ToString, (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(10, I).Value), dgw_mov1.Item(12, I).Value.ToString, (I + 1).ToString("00"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(13, I).Value.ToString, dgw_mov1.Item(14, I).Value.ToString, DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(1, I).Value.ToString, dgw_mov1.Item(0, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), dgw_mov1.Item(4, I).Value.ToString, dgw_mov1.Item(5, I).Value.ToString, Decimal.Parse((dgw_mov1.Item(6, I).Value)), dtp_com.Value.Date, DateTime.Parse((dgw_mov1.Item(16, I).Value)), "0", Now.Date, "1", "0", "0", "0", NOMBRE_PC)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.ANALISIS_TCXC2")
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)
            'Dim MODIFICAR_TODO As String = estado

            Return estado

        End Try
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_A_TCXC", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = (COD_AUX)
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = (COD_COMP)
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = (txt_nro_comp.Text)
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = (dtp_com.Value)
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = (COD_USU)
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = (Now.Date)
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = (MES00)
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
    Private Sub txt_cambio0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio0.KeyPress
        'Dim VB$t_ref$S0 As TextBox = txt_cambio0
        'txt_cambio0 = VB$t_ref$S0
        e.Handled = Numero(e, (txt_cambio0))
    End Sub
    Private Sub txt_cambio0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio0.LostFocus
        Try
            txt_cambio0.Text = (OBJ.HACER_CAMBIO(txt_cambio0.Text))
        Catch ex As Exception


            txt_cambio0.Text = "0.0000"

        End Try
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cuenta.RowCount - 1))
                    If (txt_cod_cta0.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta0.Text = dgw_cuenta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cuenta.Item(1, i).Value.ToString
                        SendKeys.Send("{Tab}")
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_COD_PER0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per0.LostFocus
        If (Strings.Trim(txt_cod_per0.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_cod_per0.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per0.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per0.Text = dgw_per.Item(1, i).Value.ToString
                        txt_nro_doc_per0.Text = dgw_per.Item(2, i).Value.ToString
                        txt_cod_cta0.Focus()
                        Return
                    End If
                    If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_CXP.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta0.Text) <> "")) Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_cuenta.RowCount - 1))
                    If (txt_desc_cta0.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = (dgw_cuenta.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_cta.Visible = True
                dgw_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC_PER_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per0.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per0.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_desc_per0.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_CXP.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_doc_per0.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_nro_doc_per0.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                'Dim VB$t_i4$L0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= (dgw_per.RowCount - 1))
                    If (txt_nro_doc_per0.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per0.Text)).ToLower) Then
                        dgw_per.CurrentCell = (dgw_per.Rows.Item(i).Cells.Item(0))
                        Exit Do
                    End If
                    dgw_per.CurrentCell = (dgw_per.Rows.Item(0).Cells.Item(0))
                    i += 1
                Loop
                Panel_CXP.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_imp_soles0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_soles0.KeyPress
        'Dim VB$t_ref$S0 As TextBox = txt_imp_soles0
        'txt_imp_soles0 = VB$t_ref$S0
        e.Handled = Numero(e, (txt_imp_soles0))
    End Sub
    Private Sub txt_imp_soles0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_imp_soles0.LostFocus
        Try
            txt_imp_soles0.Text = (OBJ.HACER_DECIMAL(txt_imp_soles0.Text))
        Catch ex As Exception


            txt_imp_soles0.Text = "0.00"

        End Try
    End Sub
    Function VALIDAR_DGW(ByVal cod_doc_03 As String, ByVal nro_doc_03 As String, ByVal cod_per_03 As String, ByVal COD_CTA_03 As String) As Boolean
        Dim k4 As Integer = dgw_mov1.RowCount
        'Dim VB$t_i4$L0 As Integer = (k4 - 1)
        Dim l1 As Integer = 0
        Do While (l1 <= (k4 - 1))
            Dim cod_CTA_05 As String = dgw_mov1.Item(0, l1).Value.ToString
            Dim cod_doc_05 As String = dgw_mov1.Item(7, l1).Value.ToString
            Dim nro_doc_05 As String = dgw_mov1.Item(8, l1).Value.ToString
            Dim cod_per_05 As String = dgw_mov1.Item(10, l1).Value.ToString
            Dim nro_doc_per_05 As String = dgw_mov1.Item(6, l1).Value.ToString
            If ((((cod_CTA_05 = COD_CTA_03) And (cod_doc_05 = cod_doc_03)) And (nro_doc_05 = nro_doc_03)) And (cod_per_05 = cod_per_03)) Then
                Return False
            End If
            l1 += 1
        Loop
        Return True
    End Function
    Private Sub CXC_INGRESO_ANA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CXC_INGRESO_ANA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        'DATAGRID()
        cbo_mes1.Text = OBJ.DESC_MES(MES)
        CREAR_DATASET()
        CBO_AUXILIAR()
        CBO_DOCUMENTO()
        DGW_PERSONAS()
        CBO_DOCUMENTO()
        CBO_MONEDA0()
        CBO_REFERENCIA()
        DGW_CUENTAS()
        dtp_com.Value = FECHA_GRAL
        IGV0 = OBJ.IMPUESTO("IGV")
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        btn_nuevo.Select()
    End Sub

    Private Sub cbo_mes1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes1.SelectedIndexChanged
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        MES00 = OBJ.COD_MES(cbo_mes1.Text)
        DATAGRID()
    End Sub

    Private Sub btnImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click
        '-------------------Creacion del formulario a mostrar los registros que no pasaron----
        Dim frm As New Form
        frm.Text = "Lista de registros no admitidos"
        Dim dgv As New DataGridView
        Dim col1, col2, col3, col4 As New DataGridViewTextBoxColumn
        col1.HeaderText = "COD_DOC"
        col2.HeaderText = "NRO_DOC"
        col3.HeaderText = "RUC/DNI"
        col4.HeaderText = "TIPO DE ERROR"
        dgv.Columns.Add(col1)
        dgv.Columns.Add(col2)
        dgv.Columns.Add(col3)
        dgv.Columns.Add(col4)
        dgv.Dock = DockStyle.Fill
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '------------------------------
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
            Dim rutaArchivo As String = ""
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Archivos*.xlsx|*.xlsx"
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaArchivo = ofd.FileName
                Dim ds As New DataSet
                'Cadena de conexión
                Dim conExcel As String = "Provider=Microsoft.ACE.Oledb.12.0;" & _
                            "Extended Properties='TEXT;HDR=Yes';" & _
                            "Data Source=" & rutaArchivo & ";" & _
                            "Extended Properties= Excel 8.0"
                Try
                    'Cargamos datos del excel a un  DataSet
                    Using cnn As New OleDbConnection(conExcel)
                        Dim cmd As New OleDbCommand("Select * from [CXC$]", cnn)
                        cmd.CommandType = CommandType.Text
                        Dim da As New OleDbDataAdapter(cmd)
                        da.Fill(ds)
                    End Using
                    'Insertar los registros
                    Dim dr As DataRow
                    'Recorremos el datarow 
                    Dim cantidad As Integer = ds.Tables(0).Rows.Count
                    Dim dolares, soles As Double
                    For Each dr In ds.Tables(0).Rows
                        Dim DesCuenta As String = OBJ.DESC_CUENTA(dr.Item(5).ToString(), AÑO)
                        Dim CodigoPersona As String = OBJ.HALLAR_CODIGO_PERSONA(dr.Item(2).ToString())
                        Dim DescDocumento As String = OBJ.DESC_DOC(dr.Item(0).ToString)
                        Dim fechaDOC As Date = CDate(dr.Item(3).ToString)
                        'Hacemos las validaciones
                        If (DesCuenta <> "") Then
                            If (CodigoPersona <> "") Then
                                If (dr.Item(0).ToString.Length = 2 AndAlso DescDocumento <> "") Then
                                    If (ValidarTipoMoneda(dr.Item(6))) Then
                                        If (ValidarDH(dr.Item(7))) Then
                                            If (fechaDOC <= FECHA_GRAL) Then
                                                Select Case dr.Item(6).ToString()
                                                    Case "S"
                                                        soles = dr.Item(9)
                                                        dolares = dr.Item(9) / dr.Item(8)
                                                    Case "D"
                                                        dolares = dr.Item(9)
                                                        soles = dr.Item(9) * dr.Item(8)
                                                    Case "A"
                                                        soles = dr.Item(9)
                                                        dolares = 0
                                                End Select
                                                SOL = OBJ.HACER_DECIMAL(soles)
                                                DOLAR = OBJ.HACER_DECIMAL(dolares)
                                                'Agregamos a la grilla la fila del excel
                                                Dim DescPersona As String = OBJ.DESC_PERSONA(CodigoPersona)
                                                'dgw_mov1.Rows.Add(dr.Item(4), DescPersona, SOL, DOLAR, dr.Item(6), _
                                                '                  dr.Item(5), dr.Item(7), dr.Item(0), dr.Item(1), dr.Item(3), _
                                                '                  CodigoPersona, DescPersona, dr.Item(2), "", "", dr.Item(8))
                                                dgw_mov1.Rows.Add(dr.Item(5), DescPersona, SOL, DOLAR, dr.Item(7), _
                                                                  dr.Item(6), dr.Item(8), dr.Item(0), dr.Item(1), dr.Item(3), _
                                                                  CodigoPersona, DescPersona, dr.Item(2), "", "", dr.Item(8), _
                                                                  dr.Item(4))
                                            Else
                                                dgv.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), "Fecha no valida")
                                            End If
                                        Else
                                            dgv.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), "Código D/H Incorrecto")
                                        End If
                                    Else
                                        dgv.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), "Tipo de moneda incorrecto")
                                    End If
                                Else
                                    dgv.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), "Código documento incorrecto")
                                End If
                            Else
                                dgv.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), "RUC/DNI inexistente")
                            End If
                        Else
                            dgv.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), "Código de cuenta inexistente")
                        End If
                    Next
                Catch ex As Exception
                    MessageBox.Show("VERIFIQUE EL FORMATO", "ERROR EN LA HOJA DE EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If
        End If
        HALLAR_TOTAL()
        frm.Controls.Add(dgv)

        If ((dgv.Rows.Count - 1) > 0) Then
            frm.ShowDialog()
        End If

    End Sub

    Public Function ValidarTipoMoneda(ByVal Moneda As String) As Boolean
        Dim key As Boolean = False
        If Moneda = "S" OrElse Moneda = "D" OrElse Moneda = "A" Then
            key = True
        End If
        Return key
    End Function

    Public Function ValidarDH(ByVal codigo As String) As Boolean
        Dim key As Boolean = False
        If codigo = "D" OrElse codigo = "H" Then
            key = True
        End If
        Return key
    End Function
End Class