Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class TRANSFERENCIA_CXC2
    Dim BOTON, VAR_PRO, STATUS_PER, STATUS_P, COD_COMP2, COD_AUX2, STATUS_DOC, STATUS_CC, STATUS_ANA, ITEM_PAGO, cod_ref, COD_PROYECTO, COD_MONEDA, COD_MON_DOC, COD_AUX, COD_CC, COD_COMP, COD_CONTROL, COD_D_H, COD_D_H_PAGO, COD_DOC As String
    Dim DT_DET As New DataTable
    Dim IGV0, IMP_D, IMP_INICIAL, IMP_S As Decimal
    Dim obj As New Class1
    Dim OFR As New CONSULTA_PCTAS_COBRAR
    Sub BOTON3()
        OFR.COD_SUC = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        OFR.COD_CPTO00 = ""
        OFR.COD_PER00 = txt_cod1.Text
        OFR.COD_CTA00 = txt_cod_cta.Text
        OFR.CARGAR_PCTAS_COBRAR_CUENTA()
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
    Private Sub btn_cancelar_pago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_pago.Click
        TabControl1.SelectedTab = TabPage1
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
        g_cab.Enabled = False
        TabControl1.SelectedTab = TabPage2
        Panel_doc.Visible = True
        Panel_det.Visible = False
        btn_grabar_pago01.Enabled = False
        btn_cancelar_pago.Focus()
        HALLAR_TOTAL()
    End Sub

    Private Sub btn_doc_pte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_doc_pte.Click
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
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
            ElseIf txt_cod_cta.Text.Trim = "" Then
                MessageBox.Show("Debe elegir la cuenta origen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_CXC_TRANSFERENCIA", con)
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
            If (ESTADO = "FALLO") Then
                MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            DATAGRID()
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

    Private Sub btn_grabar_pago01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_pago01.Click
        If dgw_mov1.Rows.Count = 0 Then MessageBox.Show("Sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub

        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        'If dgw_pago0.RowCount = 0 Then MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_pago0.Focus() : Exit Sub

        txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
        If INSERTAR_TODO() = "EXITO" Then
            txt_nro_comp.Text = obj.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
            MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            obj.ELIMINAR_TEMPORAL("TCON")
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        DATAGRID()
        btn_grabar_pago01.Enabled = False
        btn_cancelar_pago.Focus()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        BOTON = "NUEVO"
        LIMPIAR_COMPROBANTE()
        TabControl1.SelectedTab = TabPage2
        Panel_doc.Visible = True
        Panel_det.Visible = False
        cbo_aux.Focus()
    End Sub

    Private Sub btn_nuevo_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_doc.Click
        If txt_cod_cta.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta de origen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta.Focus() : Exit Sub
        If txt_cod_cta2.Text.Trim = "" Then MessageBox.Show("Debe elegir la cuenta de destino.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta2.Focus() : Exit Sub
        If (cbo_moneda.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_mp.Value)) = 0) Then
            dtp_mp.Focus()
        Else
            If (txt_cambio.Text.Trim = "") Then
                txt_cambio.Text = "0.0000"
            End If
            If (Decimal.Parse(txt_cambio.Text) = 0) Then
                MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cambio.Focus()
            ElseIf (txt_glosa.Text.Trim = "") Then
                MessageBox.Show("Debe ingresar la glosa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_glosa.Focus()
            Else
                LIMPIAR_DETALLES()
                GroupBox1.Enabled = False
                Panel_det.Visible = True
                txt_cod1.Focus()
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(141) = 0
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
        PERSONAS()
        CBO_AUXILIAR()
        CARGAR_CUENTAS()
        CREAR_DATASET()
        IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
        dtp_mp.Value = FECHA_GRAL
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
    End Sub

    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        'dgw_pago0.Rows.Clear()
        dgw_mov1.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CXC_TRANSFERENCIA", con)
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
                dgw_mov1.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetString(15), rs3.GetValue(16), rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), rs3.GetValue(23), rs3.GetValue(24))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If dgw_mov1.Rows.Count <> 0 Then
            cbo_moneda.Text = obj.DESC_MONEDA(dgw_mov1.Item(8, 0).Value)
            dtp_mp.Value = dgw_mov1.Item(11, 0).Value
            txt_cambio.Text = dgw_mov1.Item(10, 0).Value
            txt_glosa.Text = dgw_mov1.Item(12, 0).Value.ToString
            txt_cod_cta.Text = dgw_mov1.Item(13, 0).Value.ToString
            txt_desc_cta.Text = dgw_mov1.Item(25, 0).Value.ToString
        End If
        txt_cod_cta2.Text = obj.HALLAR_CTA_DESTINO_TRANSFERENCIA(AÑO, COD_AUX, COD_COMP, txt_nro_comp.Text, MES)
        txt_desc_cta_pago2.Text = obj.DESC_CUENTA(txt_cod_cta2.Text, AÑO)
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
            dgw_cta_pago.Columns(2).Visible = False
            dgw_cta_pago.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta_pago.Columns(0).Width = &H4B
            '----------------------------------------------------------------------------------------------
            dgw_cta_pago2.DataSource = dt2
            dgw_cta_pago2.Columns(2).Visible = False
            dgw_cta_pago2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta_pago2.Columns(0).Width = &H4B
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub cbo_moneda_pago_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_moneda.SelectedIndexChanged
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub

    Sub CBO_MONEDA00()
        Dim GEN2 As New Genericos
        Dim DT2 As New DataTable
        DT2 = GEN2.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT2
        cbo_moneda.DisplayMember = DT2.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT2.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
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
            pro_02.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CCTRA"
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
            txt_cod_cta.Text = dgw_cta_pago.Item(0, dgw_cta_pago.CurrentRow.Index).Value.ToString
            txt_desc_cta.Text = dgw_cta_pago.Item(1, dgw_cta_pago.CurrentRow.Index).Value.ToString
            STATUS_ANA = dgw_cta_pago.Item(2, dgw_cta_pago.CurrentRow.Index).Value.ToString
            kl_pago.Focus()
            Panel_cta.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
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
            'txt_glosa.Text = txt_desc_per.Text
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
        If (cbo_moneda.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub

    Sub HALLAR_TOTAL()
        Dim D_IMPORTE, H_IMPORTE As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        I = 0
        CONT = (dgw_mov1.Rows.Count - 1)
        I = 0
        D_IMPORTE = 0 : H_IMPORTE = 0
        Do While (I <= CONT)
            If (dgw_mov1.Item(9, I).Value.ToString = "D") Then
                D_IMPORTE = D_IMPORTE + Math.Round(Decimal.Parse(dgw_mov1.Item(6, I).Value), 2)
            ElseIf (dgw_mov1.Item(9, I).Value.ToString = "H") Then
                H_IMPORTE = H_IMPORTE + Math.Round(Decimal.Parse(dgw_mov1.Item(6, I).Value), 2)
            End If
            I += 1
        Loop
        txt_debe.Text = obj.HACER_DECIMAL(D_IMPORTE)
        txt_haber.Text = obj.HACER_DECIMAL(H_IMPORTE)
        txt_saldo.Text = obj.HACER_DECIMAL(Decimal.Subtract(D_IMPORTE, H_IMPORTE))
    End Sub

    Sub INSERTAR_DE_DAILOG()
        COD_CONTROL = ""
        COD_PROYECTO = ""
        COD_CC = ""

        Dim CONT As Integer = (OFR.DGW_CAB.Rows.Count - 1)
        Dim K As Integer = 0
        Do While (K <= CONT)
            If OFR.DGW_CAB.Item(9, K).Value.ToString = "True" Then
                Dim imp_pago As Decimal
                If (OFR.DGW_CAB.Item(6, K).Value.ToString = COD_MONEDA) Then
                    imp_pago = Decimal.Parse(OFR.DGW_CAB.Item(8, K).Value)
                ElseIf ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Multiply(OFR.DGW_CAB.Item(8, K).Value, txt_cambio.Text)))
                Else
                    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Divide(OFR.DGW_CAB.Item(8, K).Value, txt_cambio.Text)))
                End If
                dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1).ToString("0000"), OFR.DGW_CAB.Item(0, K).Value.ToString, OFR.DGW_CAB.Item(2, K).Value.ToString, OFR.DGW_CAB.Item(3, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(11, K).Value.ToString, imp_pago, OFR.DGW_CAB.Item(8, K).Value.ToString, OFR.DGW_CAB.Item(6, K).Value.ToString, OFR.DGW_CAB.Item(10, K).Value.ToString, txt_cambio.Text, OFR.DGW_CAB.Item(5, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(14, K).Value.ToString, OFR.DGW_CAB.Item(5, K).Value.ToString, COD_CC, COD_CONTROL, COD_PROYECTO, OFR.DGW_CAB.Item(15, K).Value.ToString, OFR.DGW_CAB.Item(16, K).Value.ToString, OFR.DGW_CAB.Item(17, K).Value.ToString, "0", "S", "", "")
            End If
            K += 1
        Loop
    End Sub

    Function INSERTAR_TODO() As String
        Dim NEW_COD_D_H As String
        Dim ESTADO As String = "FALLO"
        Dim BULK As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            Dim DOLARES, SOLES As Decimal
            If dgw_mov1.Item(8, I).Value = "S" Then
                SOLES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value)
                DOLARES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value / dgw_mov1.Item(10, I).Value)
            ElseIf dgw_mov1.Item(8, I).Value = "D" Then
                SOLES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value * dgw_mov1.Item(10, I).Value)
                DOLARES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value)
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(2, I).Value), (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(5, I).Value), (I + 1).ToString("0000"), dtp_mp.Value, "", "", dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, SOLES, DOLARES, (dgw_mov1.Item(9, I).Value), (dgw_mov1.Item(8, I).Value), txt_cambio.Text, "", "", "", "", (dgw_mov1.Item(11, I).Value), "0", "", "", "0", "", "0", "0", "", "", dtp_com.Value, (dgw_mov1.Item(0, I).Value), "", "S", dtp_com.Value, "0.00", NOMBRE_PC)
            'If dgw_mov1.Item(9, I).Value = "D" Then NEW_COD_D_H = "H" Else NEW_COD_D_H = "D"
            'DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(2, I).Value), (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(5, I).Value), (I + 1).ToString("0000"), dtp_mp.Value, "", "", dtp_mp.Value, txt_glosa.Text, txt_cod_cta2.Text, SOLES, DOLARES, NEW_COD_D_H, (dgw_mov1.Item(8, I).Value), txt_cambio.Text, "", "", "", "", (dgw_mov1.Item(11, I).Value), "0", "", "", "0", "", "0", "0", "", "", dtp_com.Value, (dgw_mov1.Item(0, I).Value), "", "S", dtp_com.Value, "0.00", NOMBRE_PC)
            I += 1
        Loop
        I = 0
        CONT = dgw_mov1.RowCount - 1
        '----------------------------------------------------------
        Do While (I <= CONT)
            Dim DOLARES, SOLES As Decimal
            If dgw_mov1.Item(8, I).Value = "S" Then
                SOLES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value)
                DOLARES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value / dgw_mov1.Item(10, I).Value)
            ElseIf dgw_mov1.Item(8, I).Value = "D" Then
                SOLES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value * dgw_mov1.Item(10, I).Value)
                DOLARES = obj.HACER_DECIMAL(dgw_mov1.Item(6, I).Value)
            End If
            'DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(2, I).Value), (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(5, I).Value), (dgw_mov1.Item(0, I).Value), dtp_mp.Value, "", "", dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, SOLES, DOLARES, (dgw_mov1.Item(9, I).Value), (dgw_mov1.Item(8, I).Value), txt_cambio.Text, "", "", "", "", (dgw_mov1.Item(11, I).Value), "0", "", "", "0", "", "0", "0", "", "", dtp_com.Value, (dgw_mov1.Item(0, I).Value), "", "S", dtp_com.Value, "0.00", NOMBRE_PC)
            If dgw_mov1.Item(9, I).Value = "D" Then NEW_COD_D_H = "H" Else NEW_COD_D_H = "D"
            Dim ITEM00 As String = (CONT + I + 2).ToString("0000")
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(2, I).Value), (dgw_mov1.Item(3, I).Value), (dgw_mov1.Item(5, I).Value), ITEM00, dtp_mp.Value, "", "", dtp_mp.Value, txt_glosa.Text, txt_cod_cta2.Text, SOLES, DOLARES, NEW_COD_D_H, (dgw_mov1.Item(8, I).Value), txt_cambio.Text, "", "", "", "", (dgw_mov1.Item(11, I).Value), "0", "", "", "0", "", "0", "1", "", "", dtp_com.Value, "0", "", "S", dtp_com.Value, "0.00", NOMBRE_PC)
            I += 1
        Loop
        '--------------------------------------------------------------
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
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_CXC_TRANSFERENCIA", con)
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
            comand1.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = txt_cod_cta2.Text
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

    Sub LIMPIAR_COMPROBANTE()
        GroupBox1.Enabled = True
        dgw_mov1.Rows.Clear()
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        btn_grabar_pago01.Enabled = True
        Dim DESC_COM As String = cbo_com.Text
        cbo_com.SelectedIndex = -1
        cbo_com.Text = DESC_COM
        Panel_doc.Visible = False
        dtp_com.Value = FECHA_GRAL
        txt_cod1.Clear()
        txt_desc_per.Clear()
        txt_nro_doc_per.Clear()
        txt_cambio.Text = "0.0000"
        txt_glosa.Clear()
        Panel_cta.Visible = False
        Panel_cta2.Visible = False
        txt_debe.Text = "0.00"
        txt_haber.Text = "0.00"
        txt_saldo.Text = "0.00"
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
        txt_cod1.Enabled = True
        txt_desc_per.Enabled = True
        txt_nro_doc_per.Enabled = True
    End Sub

    Sub LIMPIAR_PAGO()
        GroupBox1.Enabled = True
        TXT_PAGO.Text = "0.00"
        dgw_mov1.Rows.Clear()
        GroupBox1.Enabled = True
        dtp_mp.Value = FECHA_GRAL
        'txt_nro_mp.Clear()
        Panel_doc.Enabled = True
        Panel_det.Visible = False
        STATUS_DOC = "CP"
        btn_grabar_pago01.Visible = True
        txt_debe.Text = "0.00"
        'txt_debe_dolares.Text = "0.00"
        txt_haber.Text = "0.00"
        txt_saldo.Text = "0.00"
        'txt_saldo_dolares.Text = "0.00"
        '------------------------------------------------
    End Sub

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
            DGW_PER.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER.Columns.Item(0).Width = &H37
            DGW_PER.Columns.Item(1).Width = 330
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_cambio_pago_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio.LostFocus
        If (Strings.Trim(txt_cambio.Text) <> "") Then
            Try
                txt_cambio.Text = (obj.HACER_CAMBIO(txt_cambio.Text))
            Catch ex As Exception
                txt_cambio.Text = "0.0000"
            End Try
        End If
    End Sub

    Private Sub txt_cod_cta_pago_LostFocus1(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta.LostFocus
        If (Strings.Trim(txt_cod_cta.Text) <> "") Then
            If (dgw_cta_pago.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago.Sort(dgw_cta_pago.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta.Text.ToLower = dgw_cta_pago.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = dgw_cta_pago.Item(0, i).Value.ToString
                        txt_desc_cta.Text = dgw_cta_pago.Item(1, i).Value.ToString
                        STATUS_ANA = dgw_cta_pago.Item(2, i).Value.ToString
                        txt_cod_cta2.Focus()
                        Return
                    End If
                    If (txt_cod_cta.Text.ToLower = Strings.Mid((dgw_cta_pago.Item(0, i).Value), 1, Strings.Len(txt_cod_cta.Text)).ToLower) Then
                        dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta.Visible = True
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
                        btn_doc_pte.Focus()
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

    Private Sub txt_desc_cta_pago_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta.Text) <> "")) Then
            If (dgw_cta_pago.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago.Sort(dgw_cta_pago.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((dgw_cta_pago.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
                        dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago.CurrentCell = dgw_cta_pago.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta.Visible = True
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

    Private Sub txt_cod_cta_pago2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta2.LostFocus
        If (Strings.Trim(txt_cod_cta2.Text) <> "") Then
            If (dgw_cta_pago2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago2.Sort(dgw_cta_pago2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta2.Text.ToLower = dgw_cta_pago2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta2.Text = dgw_cta_pago2.Item(0, i).Value.ToString
                        txt_desc_cta_pago2.Text = dgw_cta_pago2.Item(1, i).Value.ToString
                        STATUS_ANA = dgw_cta_pago2.Item(2, i).Value.ToString
                        dtp_mp.Focus()
                        Return
                    End If
                    If (txt_cod_cta2.Text.ToLower = Strings.Mid((dgw_cta_pago2.Item(0, i).Value), 1, Strings.Len(txt_cod_cta2.Text)).ToLower) Then
                        dgw_cta_pago2.CurrentCell = dgw_cta_pago2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago2.CurrentCell = dgw_cta_pago2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta2.Visible = True
                dgw_cta_pago2.Visible = True
                dgw_cta_pago2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta_pago2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta_pago2.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_pago2.Text) <> "")) Then
            If (dgw_cta_pago2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago2.Sort(dgw_cta_pago2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta_pago2.Text.ToLower = Strings.Mid((dgw_cta_pago2.Item(1, i).Value), 1, Strings.Len(txt_desc_cta_pago2.Text)).ToLower) Then
                        dgw_cta_pago2.CurrentCell = dgw_cta_pago2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago2.CurrentCell = dgw_cta_pago2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta2.Visible = True
                dgw_cta_pago2.Visible = True
                dgw_cta_pago2.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_cta_pago2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta_pago2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta2.Text = dgw_cta_pago2.Item(0, dgw_cta_pago2.CurrentRow.Index).Value.ToString
            txt_desc_cta_pago2.Text = dgw_cta_pago2.Item(1, dgw_cta_pago2.CurrentRow.Index).Value.ToString
            STATUS_ANA = dgw_cta_pago2.Item(2, dgw_cta_pago2.CurrentRow.Index).Value.ToString
            '----------------------------------------------
            kl_pago.Focus()
            Panel_cta2.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta2.Visible = False
            txt_cod_cta2.Clear()
            txt_desc_cta_pago2.Clear()
            txt_cod_cta2.Focus()
        End If
    End Sub
End Class