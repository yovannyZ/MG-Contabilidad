Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class PERCEPCION_CXC
#Region "Constructor"
    Private Shared _instancia As PERCEPCION_CXC
    Public Shared Function ObtenerInstancia() As PERCEPCION_CXC
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New PERCEPCION_CXC
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function
    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region
    Dim BOTON, VARIABLE, cod_ref, COD_AUX_ANUL, STATUS_ANA_anul, COD_COMP_ANUL, COD_OPE_ANUL, STATUS_ANA, ITEM_PAGO, VAR_PRO, STATUS_PER, STATUS_P, STATUS_CC, STATUS_DOC, COD_RET, COD_PROYECTO, COD_MP, COD_RET_ANUL, COD_MONEDA, COD_MONEDA_ANUL, COD_MON_DOC, COD_DOC, COD_D_H_PAGO, COD_AUX, COD_OPE, COD_CC, COD_COMP, COD_CONTROL, COD_D_H As String
    Dim DT_DET, DT_RET As New DataTable
    Dim IGV0, IMP_D, IMP_INICIAL, IMP_S As Decimal
    Dim obj As New Class1
    Dim OFR As New CONSULTA_PCTAS_COBRAR_PER
    Dim OFR_RET As New REFERENCIA_PERCEPCION
    Dim reporte As New CrystalReport1
    Dim REP As New REP_PER
    Dim RET As Decimal
    Private ValidarFicha As Boolean = True


    Sub BOTON3()
        OFR.COD_SUC = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        OFR.COD_CPTO00 = ""
        OFR.COD_PER00 = txt_cod1.Text
        OFR.CARGAR_PCTAS_COBRAR_PERSONA()
        OFR.ShowDialog()
        If (OFR.DialogResult = Windows.Forms.DialogResult.OK) Then
            If (OFR.LBL.Text = "NO") Then
                BOTON3()
                'ElseIf OFR.im2 > OFR.im1 Then
                '    'If im2 > im1 Then
                '    '    '    'MessageBox.Show("El importe Nuevo no debe ser mayor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    '    '    MessageBox.Show("El importe Nuevo no debe ser mayor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    '    '    Exit Sub
                '    MsgBox("El importe Nuevo no debe ser mayor", MsgBoxStyle.Question, "Advertencia")
                '    '    Exit Sub
                '    'OFR.DGW_CAB.CurrentCell = (OFR.DGW_CAB.Rows.Item(OFR.indice).Cells.Item(1))
                '    FOCO_NUEVO_REG()
                '    BOTON3()

            Else
                INSERTAR_DE_DAILOG()
                OFR.Hide()
                HALLAR_TOTAL()
            End If
            txt_imp_soles.Focus()
            'Panel_det.Visible = False
            'btn_nuevo_doc.Focus()
        End If
    End Sub

    'Sub FOCO_NUEVO_REG()
    '    Dim I, CONT As Integer
    '    CONT = OFR.DGW_CAB.RowCount - 1
    '    Dim NRO_DOC As String = OFR.indice
    '    '= cbo_ni.Text.Substring(0, 3) & "-" & txt_numero.Text
    '    For I = 0 To CONT
    '        If NRO_DOC = OFR.DGW_CAB.Item(2, I).Value.ToString.ToLower Then
    '            OFR.DGW_CAB.CurrentCell = (OFR.DGW_CAB.Rows.Item(I).Cells.Item(2))
    '            Exit Sub
    '        End If
    '    Next
    'End Sub

    Private Sub btn_cancelar_pago_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_pago.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Focus()
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
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        '--------------------------------------------------------------
        btn_grabar.Visible = False
        btn_grabar2.Visible = False
        g_cab.Enabled = False
        btn_grabar2.Enabled = True
        btn_nuevo2.Enabled = False
        Panel_doc00.Enabled = False
        btn_imprimir.Enabled = True
        '--------------------------------------------------------------
        ValidarFicha = False
        CARGAR_PAGO()
        HALLAR_TOTAL()
        Panel_det.Visible = False
        btn_nuevo_doc.Focus()
        GroupBox1.Enabled = False
        TabControl1.SelectedTab = TabPage2
        btn_nuevo_doc.Focus()
        ValidarFicha = True
    End Sub

    Private Sub btn_doc_pte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_doc_pte.Click
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_ret.Value)) = 0) Then
            dtp_ret.Focus()
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
        Dim BAN0 As String
        BAN0 = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        If obj.VERIFICAR_CIERRE_BANCOS(BAN0, AÑO, MES) = True Then
            MessageBox.Show("No se puede eliminar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (Decimal.Parse((CInt(MessageBox.Show("Desea borrar el Comprobante", " Borrar Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
            Dim NRO_COMP000 As String = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)

            If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, NRO_COMP000, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_CXC_PERCEPCION", con)
                comand1.CommandType = CommandType.StoredProcedure
                comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
                comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
                comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = NRO_COMP000
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
            If ESTADO = "FALLO" Then
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
            ELIMINAR_DIALOG(dgw_mov1.Item(1, dgw_mov1.CurrentRow.Index).Value.ToString, dgw_mov1.Item(2, dgw_mov1.CurrentRow.Index).Value.ToString)
            dgw_mov1.Rows.RemoveAt(dgw_mov1.CurrentRow.Index)
        End If

        HALLAR_TOTAL()
    End Sub

    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_NRO_RET", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@NRO_RET", SqlDbType.VarChar).Value = txt_nro_ret.Text
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function

    Private Sub btn_grabar_pago01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        If dgw_mov1.RowCount = 0 Then MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dgw_mov1.Focus() : Exit Sub
        If dgw_mov1.Rows.Count = 0 Then MessageBox.Show("Pago sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub
        If txt_cod_cta_pago.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta del Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp_ret.Focus() : Exit Sub
        If cbo_ret.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret.Focus() : Exit Sub
        If txt_nro_ret.Text.Trim = "" Then MessageBox.Show("Debe elegir el Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret.Focus() : Exit Sub
        If cbo_ret.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el documento de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret.Focus() : Exit Sub
        If txt_nro_ret.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret.Focus() : Exit Sub
        If cbo_tipo.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
        '---------------------------------------------------------
        COD_OPE = (cbo_tipo.SelectedIndex + 1).ToString("00")
        txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)

        INSERTAR_DGW_PAGO()
        '---------------------------------------------------------
        If (INSERTAR_TODO() = "EXITO") Then
            txt_nro_comp.Text = obj.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
            MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            obj.ELIMINAR_TEMPORAL("TCON")
            obj.ELIMINAR_TEMPORAL("TPER")
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        '---------------------------------------------------------
        DATAGRID()
        Panel_doc00.Enabled = False
        btn_grabar.Enabled = False
        btn_imprimir.Enabled = True
        btn_nuevo2.Enabled = True
        btn_imprimir.Focus()
    End Sub

    Private Sub btn_grabar_pago02_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar2.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        If dgw_mov1.RowCount = 0 Then MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub
        If dgw_mov1.Rows.Count = 0 Then MessageBox.Show("Pago sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub
        If txt_cod_cta_pago.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta del Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp_ret.Focus() : Exit Sub
        If txt_nro_ret.Text.Trim = "" Then MessageBox.Show("Debe elegir el Nº de Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret.Focus() : Exit Sub
        If cbo_ret.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el documento de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret.Focus() : Exit Sub
        If txt_nro_ret.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret.Focus() : Exit Sub
        If cbo_tipo.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
        '----------------------------------------------------
        COD_OPE = (cbo_tipo.SelectedIndex + 1).ToString("00")
        ELIMINAR_PAGO(ITEM_PAGO)
        INSERTAR_DGW_PAGO()
        '----------------------------------------------------
        If (MODIFICAR_TODO() = "EXITO") Then
            MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            obj.ELIMINAR_TEMPORAL("TCON")
            obj.ELIMINAR_TEMPORAL("TPER")
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        '----------------------------------------------------
        DATAGRID()
        Panel_doc00.Enabled = False
        btn_grabar2.Enabled = False
        btn_imprimir.Enabled = True
        btn_nuevo2.Enabled = True
        btn_nuevo2.Focus()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If txt_cod1.Text.Trim = "" Then MessageBox.Show("Debe elegir la persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod1.Focus() : Exit Sub
        If cbo_tipo_doc.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc.Focus() : Exit Sub
        If txt_nro_doc.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_doc.Focus() : Exit Sub
        If cbo_moneda1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda1.Focus() : Exit Sub
        If txt_imp_soles.Text.Trim = "" Then txt_imp_soles.Text = "0.00"
        If Decimal.Parse(txt_imp_soles.Text) = 0 Then MessageBox.Show("Debe ingresar el importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_imp_soles.Focus() : Exit Sub
        If txt_cod_cta.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta.Focus() : Exit Sub

        If CBO_CC.SelectedIndex = -1 And CBO_CC.Enabled = True Then
            MessageBox.Show("Debe elegir el Centro de Costos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_CC.Focus()
            Exit Sub
        End If

        COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
        cod_ref = ""
        COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
        STATUS_PER = "1"
        IMP_S = Decimal.Parse(txt_imp_soles.Text)
        Dim imp_pago As New Decimal
        If COD_MON_DOC = COD_MONEDA Then
            imp_pago = IMP_S
        ElseIf COD_MON_DOC = "D" Then
            imp_pago = New Decimal((Convert.ToDouble(IMP_S) * Decimal.Parse(txt_cambio_pago.Text)))
            'imp_pago = obj.HACER_DECIMAL(IMP_S * txt_cambio_pago.Text)
        Else
            imp_pago = New Decimal((Convert.ToDouble(IMP_S) / Decimal.Parse(txt_cambio_pago.Text)))
            'imp_pago = obj.HACER_DECIMAL(IMP_S / txt_cambio_pago.Text)
        End If
        COD_CONTROL = ""
        COD_PROYECTO = ""
        COD_CC = ""
        If (CBO_CC.SelectedIndex <> -1) Then
            COD_CC = obj.COD_CC(CBO_CC.Text)
        End If
        '--------------------------------------------------------------
        INSERTAR_DIALOG((dgw_mov1.RowCount + 1).ToString("0000"))
        If VALIDAR_DET(COD_DOC, txt_nro_doc.Text, txt_cod1.Text) = False Then
            MessageBox.Show("EL documento ya se ingresó.", "No se puede ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1).ToString("0000"), COD_DOC, txt_nro_doc.Text, Decimal.Parse(imp_pago), IMP_S, COD_MON_DOC, _
                cbo_dh.Text, txt_cambio_pago.Text, dtp_ret.Value, txt_glosa.Text, txt_cod_cta.Text, dtp_ret.Value, COD_CC, COD_CONTROL, _
                COD_PROYECTO, STATUS_CC, "1", STATUS_P, STATUS_PER, VAR_PRO, cod_ref, "", dtp_ret.Value.Date)
            HALLAR_TOTAL()
            LIMPIAR_DETALLES()
            txt_cod1.Focus()
        End If
        '---------------------------------------------------------------
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
        TXT_ITEM0.Text = dgw_mov1.CurrentRow.Index
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
        Dim BAN0 As String
        BAN0 = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        If obj.VERIFICAR_CIERRE_BANCOS(BAN0, AÑO, MES) = True Then
            MessageBox.Show("No se puede modificar el Período : " & AÑO & " - " & MES & "  se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        BOTON = "MODIFICAR"
        VARIABLE = "0"
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ValidarFicha = False
        btn_grabar.Visible = False
        btn_grabar2.Visible = True
        g_cab.Enabled = False
        btn_grabar2.Enabled = True
        CARGAR_PAGO()
        HALLAR_TOTAL()
        Panel_det.Visible = False
        btn_nuevo_doc.Focus()
        GroupBox1.Enabled = False
        TabControl1.SelectedTab = TabPage2
        btn_nuevo_doc.Focus()
        ValidarFicha = True
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If txt_cod1.Text.Trim = "" Then MessageBox.Show("Debe elegir el Documento Pendiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod1.Focus() : Exit Sub
        If cbo_tipo_doc.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Tipo de Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc.Focus() : Exit Sub
        If txt_nro_doc.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_doc.Focus() : Exit Sub
        If cbo_moneda1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda1.Focus() : Exit Sub
        If txt_imp_soles.Text.Trim = "" Then txt_imp_soles.Text = "0.00"
        '-----------------------------------------------------------------------------
        If Decimal.Parse(txt_imp_soles.Text) = 0 Then MessageBox.Show("Debe ingresar el importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_imp_soles.Focus() : Exit Sub
        If txt_cod_cta.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta.Focus() : Exit Sub

        If CBO_CC.SelectedIndex = -1 And CBO_CC.Enabled = True Then
            MessageBox.Show("Debe elegir el Centro de Costos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_CC.Focus()
            Exit Sub
        End If

        COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
        cod_ref = ""
        COD_MON_DOC = cbo_moneda1.SelectedValue.ToString
        STATUS_PER = "1"
        VAR_PRO = "N"
        IMP_S = Decimal.Parse(txt_imp_soles.Text)
        Dim imp_pago As New Decimal
        '-----------------------------------------------------------------------------
        If COD_MON_DOC = COD_MONEDA Then
            imp_pago = IMP_S
        ElseIf COD_MONEDA = "D" AndAlso COD_MON_DOC = "A" Then
            imp_pago = 0
        ElseIf COD_MON_DOC = "D" Then
            imp_pago = New Decimal((Convert.ToDouble(IMP_S) * Decimal.Parse(txt_cambio_pago.Text)))
        Else
            imp_pago = New Decimal((Convert.ToDouble(IMP_S) / Decimal.Parse(txt_cambio_pago.Text)))
        End If
        '-----------------------------------------------------------------------------
        If COD_MON_DOC = "D" Then IMP_D = Decimal.Parse(txt_imp_soles.Text)
        COD_CONTROL = ""
        COD_PROYECTO = ""

        If (CBO_CC.SelectedIndex <> -1) Then
            COD_CC = obj.COD_CC(CBO_CC.Text)
        End If
        '-----------------------------------------------------------------------------
        Dim FILA0 As Integer = dgw_mov1.CurrentRow.Index
        dgw_mov1.Item(3, FILA0).Value = imp_pago
        dgw_mov1.Item(4, FILA0).Value = IMP_S
        dgw_mov1.Item(5, FILA0).Value = COD_MON_DOC
        dgw_mov1.Item(8, FILA0).Value = dtp_ret.Value.Date
        dgw_mov1.Item(9, FILA0).Value = txt_glosa.Text
        dgw_mov1.Item(10, FILA0).Value = txt_cod_cta.Text
        dgw_mov1.Item(12, FILA0).Value = COD_CC
        dgw_mov1.Item(13, FILA0).Value = COD_CONTROL
        dgw_mov1.Item(14, FILA0).Value = COD_PROYECTO
        dgw_mov1.Item(20, FILA0).Value = cod_ref
        dgw_mov1.Item(15, dgw_mov1.CurrentRow.Index).Value = STATUS_CC
        ELIMINAR_DIALOG(COD_DOC, txt_nro_doc.Text)
        INSERTAR_DIALOG(TXT_ITEM0.Text)
        HALLAR_TOTAL()
        Panel_det.Visible = False
        btn_nuevo_doc.Focus()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click, btn_nuevo2.Click
        BOTON = "NUEVO"
        ValidarFicha = False
        VARIABLE = "1"
        LIMPIAR_COMPROBANTE()
        TabControl1.SelectedTab = TabPage2
        cbo_aux.Focus()
        ValidarFicha = True
    End Sub

    Private Sub btn_nuevo_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_doc.Click
        If VARIABLE = "1" Then
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("El Número de Retención ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_nro_ret.Focus() : Exit Sub
            End If
        End If
        'VARIABLE = ""
        If txt_cod1.Text.Trim = "" Then MessageBox.Show("Debe elegir al Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod1.Focus() : Exit Sub
        If txt_cod_cta_pago.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta_pago.Focus() : Exit Sub
        If (cbo_moneda_pago.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda_pago.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_ret.Value)) = 0) Then
            dtp_ret.Focus()
        ElseIf (cbo_aux.SelectedIndex = -1) Then
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
            If cbo_ret.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el documento de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret.Focus() : Exit Sub
            If txt_nro_ret.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret.Focus() : Exit Sub
            If cbo_tipo.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo.Focus() : Exit Sub
            g_cab.Enabled = False
            COD_RET = obj.COD_DOC(cbo_ret.Text)
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
                GroupBox1.Enabled = False
                Panel_det.Visible = True
                cbo_tipo_doc.Focus()
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir_anul.Click
        main(25) = 0
        Close()
    End Sub

    Private Sub RETENCION_CXP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub RETENCION_CXP_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
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
        CBO_PROYECTO00()
        CBO_CONTROL00()
        PERSONAS()
        CC00()
        CC()
        CBO_TIPO_DOC00()
        CBO_AUXILIAR()
        CARGAR_CUENTAS()
        CREAR_DATASET()
        VARIABLE = ""
        LIMPIAR_COMPROBANTE()
        IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        RET = obj.IMPUESTO("PR1")
        btn_nuevo.Select()
    End Sub

    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        dgw_mov1.Rows.Clear()
        dgw_mov.Rows.Clear()
        DGW_RET2.Rows.Clear()
        'DataGridView1.Rows.Clear()
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
                dgw_mov.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), _
                    rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), _
                    rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetString(15), rs3.GetValue(16), _
                    rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), _
                    rs3.GetValue(23), rs3.GetValue(24), rs3.GetValue(25), rs3.GetValue(26))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        '--------------------------------------------------------
        ' I RETENCIONES
        Try
            Dim pro_02 As New SqlCommand("CARGAR_I_PERCEPCIONES", con)
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
                COD_MP = (rs3.GetValue(0))
                cbo_tipo.Text = rs3.GetValue(3)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        '--------------------------------------------------------
        ' T RETENCIONES
        Try
            Dim pro_02 As New SqlCommand("CARGAR_T_PERCEPCIONES", con)
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
                DGW_RET2.Rows.Add((rs3.GetValue(0)), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), _
                    rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), _
                    rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13))
                'DataGridView1.Rows.Add((Rs3.GetValue(0)), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        '------------------
        '------------------
    End Sub

    Sub CC()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC
        CBO_CC.DataSource = DT
        CBO_CC.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC.SelectedIndex = -1
    End Sub

    Sub CARGAR_CUENTAS()
        Try
            Dim pro As New SqlCommand("DGW_CUENTA_40", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt2 As New DataTable("Cuentas")
            Prog00.Fill(dt2)
            dgw_cta_pago.DataSource = dt2
            dgw_cta_pago_anul.DataSource = dt2
            dgw_cta_pago.Columns.Item(2).Visible = False
            dgw_cta_pago_anul.Columns.Item(2).Visible = False
            dgw_cta_pago.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta_pago_anul.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta_pago.Columns.Item(0).Width = &H4B
            dgw_cta_pago_anul.Columns.Item(0).Width = &H4B
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

    Sub CARGAR_DETALLES(ByVal FILA0 As Integer)
        VAR_PRO = dgw_mov1.Item(19, FILA0).Value.ToString 'FILA0
        COD_DOC = dgw_mov1.Item(1, FILA0).Value.ToString
        txt_nro_doc.Text = dgw_mov1.Item(2, FILA0).Value.ToString
        'txt_cod1.Text = dgw_mov1.Item(3, Integer.Parse(FILA0)).Value.ToString
        'txt_desc_per.Text = dgw_mov1.Item(4, Integer.Parse(FILA0)).Value.ToString
        'txt_nro_doc_per.Text = dgw_mov1.Item(5, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = dgw_mov1.Item(4, FILA0).Value.ToString
        txt_imp_soles.Text = (obj.HACER_DECIMAL(txt_imp_soles.Text))
        COD_MON_DOC = dgw_mov1.Item(5, FILA0).Value.ToString
        txt_glosa.Text = dgw_mov1.Item(9, FILA0).Value.ToString
        txt_cod_cta.Text = dgw_mov1.Item(10, FILA0).Value.ToString
        txt_desc_cta.Text = obj.DESC_CUENTA(txt_cod_cta.Text, AÑO)
        COD_CC = dgw_mov1.Item(12, FILA0).Value.ToString
        COD_CONTROL = dgw_mov1.Item(13, FILA0).Value.ToString
        COD_PROYECTO = dgw_mov1.Item(14, FILA0).Value.ToString
        STATUS_CC = dgw_mov1.Item(15, FILA0).Value.ToString
        STATUS_P = dgw_mov1.Item(17, FILA0).Value.ToString
        cbo_tipo_doc.Text = obj.DESC_DOC(COD_DOC)
        COD_D_H = dgw_mov1.Item(6, FILA0).Value.ToString
        cbo_dh.Text = COD_D_H
        cbo_moneda1.Text = obj.DESC_MONEDA(COD_MON_DOC)
        'CBO_CC.Text = obj.DESC_CC(COD_CC)
        'cbo_control.Text = obj.DESC_CONTROL(COD_CONTROL)
        'cbo_proyecto.Text = obj.DESC_PROYECTO(COD_PROYECTO)
        cod_ref = dgw_mov1.Item(20, FILA0).Value.ToString
        'cbo_tipo_ref.Text = obj.DESC_DOC(cod_ref)
        'txt_nro_ref.Text = dgw_mov1.Item(21, FILA0).Value.ToString
        'Try
        '    dtp_ref.Value = dgw_mov1.Item(22, FILA0).Value.ToString
        'Catch ex As Exception
        'End Try
        CARGAR_DIALOG()
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

        CBO_CC.Enabled = False
        CBO_CC.SelectedIndex = -1

        STATUS_CC = (dgw_mov1.Item(15, dgw_mov1.CurrentRow.Index).Value)

        If (Decimal.Parse(STATUS_CC) = 1) Then
            CBO_CC.Enabled = True
            COD_CC = (dgw_mov1.Item(12, dgw_mov1.CurrentRow.Index).Value)
            CBO_CC.Text = obj.DESC_CC(COD_CC)
        End If


    End Sub

    Sub CARGAR_PAGO()
        dgw_mov1.Rows.Clear()
        Dim I, CONT As Integer
        I = 0 : CONT = (dgw_mov.RowCount - 1)
        'HALLAR EL PAGO
        For I = 0 To CONT
            If dgw_mov.Item(26, I).Value.ToString = "1" Then
                ITEM_PAGO = dgw_mov.Item(25, I).Value.ToString
                COD_MP = ""
                txt_cod_cta_pago.Text = dgw_mov.Item(12, I).Value.ToString
                txt_desc_cta_pago.Text = obj.DESC_CUENTA(txt_cod_cta_pago.Text, AÑO)
                COD_RET = dgw_mov.Item(1, I).Value.ToString
                cbo_ret.Text = obj.DESC_DOC(COD_RET)
                txt_nro_ret.Text = dgw_mov.Item(2, I).Value.ToString
                dtp_ret.Value = dgw_mov.Item(3, I).Value.ToString
                txt_cod1.Text = dgw_mov.Item(4, I).Value.ToString
                txt_desc_per.Text = dgw_mov.Item(5, I).Value.ToString
                txt_nro_doc_per.Text = dgw_mov.Item(6, I).Value.ToString
                COD_MONEDA = dgw_mov.Item(9, I).Value.ToString
                cbo_moneda_pago.Text = obj.DESC_MONEDA(COD_MONEDA)
                txt_cambio_pago.Text = dgw_mov.Item(10, I).Value.ToString
                txt_glosa_pago.Text = dgw_mov.Item(11, I).Value.ToString
            End If
        Next
        '-----------------------------------
        'ES UN DETALLE
        For I = 0 To CONT
            If dgw_mov.Item(26, I).Value.ToString = "0" Then
                Dim PAGO As New Decimal
                If (COD_MONEDA = dgw_mov.Item(9, I).Value.ToString) Then
                    PAGO = Decimal.Parse(dgw_mov.Item(8, I).Value)
                ElseIf (COD_MONEDA = "D") AndAlso dgw_mov.Item(9, I).Value.ToString <> "A" Then
                    PAGO = Math.Round(Decimal.Parse(Decimal.Divide(dgw_mov.Item(8, I).Value, txt_cambio_pago.Text)), 2)
                ElseIf (COD_MONEDA = "D") AndAlso dgw_mov.Item(9, I).Value.ToString = "A" Then
                    PAGO = 0
                ElseIf dgw_mov.Item(9, I).Value.ToString = "A" Then
                    PAGO = Decimal.Parse(dgw_mov.Item(8, I).Value)
                Else
                    PAGO = Math.Round(Decimal.Parse(Decimal.Multiply(dgw_mov.Item(8, I).Value, txt_cambio_pago.Text)), 2)
                End If
                With dgw_mov
                    dgw_mov1.Rows.Add((dgw_mov1.RowCount + 1), .Item(1, I).Value, .Item(2, I).Value, PAGO, .Item(8, I).Value, _
                    .Item(9, I).Value, .Item(7, I).Value, .Item(10, I).Value, .Item(3, I).Value, .Item(11, I).Value, .Item(12, I).Value, _
                    .Item(17, I).Value, .Item(13, I).Value, .Item(14, I).Value, .Item(15, I).Value, .Item(18, I).Value, .Item(19, I).Value, _
                    .Item(20, I).Value, .Item(16, I).Value, .Item(21, I).Value, .Item(22, I).Value, .Item(23, I).Value, .Item(24, I).Value)
                End With

            End If
        Next
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If cbo_aux.SelectedIndex <> -1 Then
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
                cbo_aux_anul.Items.Add(Rs3.GetString(0))
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
                'cbo_control.Items.Add(Rs3.GetString(0))
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
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_ret.Value.Year, dtp_ret.Value.ToString("MM"), dtp_ret.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_ret.Value.Year, dtp_ret.Value.ToString("MM"), dtp_ret.Value.ToString("dd"), COD_MONEDA)
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
        '--------------------------------------------------------------
        Dim GEN3 As New Genericos
        Dim DT3 As New DataTable
        DT3 = GEN3.CBO_MONEDA_COI
        cbo_moneda_pago_anul.DataSource = DT3
        cbo_moneda_pago_anul.DisplayMember = DT3.Columns.Item(0).ToString
        cbo_moneda_pago_anul.ValueMember = DT3.Columns.Item(1).ToString
        cbo_moneda_pago_anul.SelectedIndex = -1
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
                'cbo_proyecto.Items.Add(Rs3.GetString(0))
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
                'cbo_tipo_ref.Items.Add(Rs3.GetString(0))
                cbo_ret.Items.Add(Rs3.GetString(0))
                cbo_ret_anul.Items.Add(Rs3.GetString(0))
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
        'CBO_CC.DataSource = DT
        'CBO_CC.DisplayMember = DT.Columns.Item(0).ToString
        'CBO_CC.ValueMember = DT.Columns.Item(1).ToString
        'CBO_CC.SelectedIndex = -1
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
        '-------------------------------
        DT_RET.Columns.Add("COD_AUX")
        DT_RET.Columns.Add("COD_COMP")
        DT_RET.Columns.Add("NRO_COMP")
        DT_RET.Columns.Add("FE_AÑO")
        DT_RET.Columns.Add("FE_MES")
        DT_RET.Columns.Add("ITEM")
        DT_RET.Columns.Add("COD_DOC")
        DT_RET.Columns.Add("NRO_DOC")
        DT_RET.Columns.Add("FECHA_DOC")
        DT_RET.Columns.Add("COD_REF")
        DT_RET.Columns.Add("NRO_REF")
        DT_RET.Columns.Add("FECHA_REF")
        DT_RET.Columns.Add("IMPORTE")
        DT_RET.Columns.Add("BASE_IMP")
        DT_RET.Columns.Add("NOMBRE_PC")
        DT_RET.Columns.Add("COD_D_H")
        DT_RET.Columns.Add("COD_PER")
        DT_RET.Columns.Add("COD_MONEDA")

        DT_RET.Columns.Add("BASE_INI")
        DT_RET.Columns.Add("BASE_PEN")
    End Sub

    Sub DATAGRID()
        Try
            Dim pro_02 As New SqlCommand("[MOSTRAR_ICON_CXC_PERC]", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CPPER"
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
        '---------------------------anuladas
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_ICON_CXC_PERC_ANUL2", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CPPER"
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Cuentas")
            Prog02.Fill(dt_02)
            dgw_anul.DataSource = dt_02
            dgw_anul.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_anul.Columns(0).Visible = False
            dgw_anul.Columns(2).Visible = False
            dgw_anul.Columns(6).Visible = False
            dgw_anul.Columns(7).Visible = False
            dgw_anul.Columns(8).Visible = False
            dgw_anul.Columns(9).Visible = False
            dgw_anul.Columns(10).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dgw_cta_pago_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta_pago.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta_pago.Text = dgw_cta_pago.Item(0, dgw_cta_pago.CurrentRow.Index).Value.ToString
            txt_desc_cta_pago.Text = dgw_cta_pago.Item(1, dgw_cta_pago.CurrentRow.Index).Value.ToString
            STATUS_ANA = dgw_cta_pago.Item(2, dgw_cta_pago.CurrentRow.Index).Value.ToString
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
            'cbo_proyecto.SelectedIndex = -1
            'cbo_proyecto.Enabled = False
            If (STATUS_CC = "1") Then
                CBO_CC.Enabled = True
            End If
            'If (STATUS_P = "1") Then
            '    cbo_proyecto.Enabled = True
            'End If
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
            txt_glosa_pago.Text = txt_desc_per.Text
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

    Private Sub dtp_mp_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_ret.LostFocus
        If (cbo_moneda_pago.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_ret.Value.Year, dtp_ret.Value.ToString("MM"), dtp_ret.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_ret.Value.Year, dtp_ret.Value.ToString("MM"), dtp_ret.Value.ToString("dd"), COD_MONEDA)
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
        'dgw_pago0.Rows.RemoveAt(dgw_pago0.CurrentRow.Index)
    End Sub

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
            If (dgw_mov1.Item(6, I).Value.ToString = "D") Then
                If (dgw_mov1.Item(5, I).Value.ToString <> "A") Then
                    If (COD_MONEDA = "D") Then
                        D_DOLARES = Math.Round(Decimal.Add(D_DOLARES, Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString)), 2)
                        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString) * Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                    ElseIf COD_MONEDA = "S" Then
                        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString)), 2)
                        D_DOLARES = Math.Round(Decimal.Add(D_DOLARES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString) / Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                    Else
                        D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString)), 2)
                        D_DOLARES = D_DOLARES + 0
                    End If
                Else
                    D_DOLARES = Math.Round(Decimal.Add(D_DOLARES, 0), 2)
                    D_SOLES = Math.Round(Decimal.Add(D_SOLES, Decimal.Parse(CDbl((dgw_mov1.Item(4, I).Value.ToString)))), 2)
                End If
            Else
                If (dgw_mov1.Item(5, I).Value.ToString <> "A") Then
                    If (COD_MONEDA = "D") Then
                        H_DOLARES = Math.Round(Decimal.Add(H_DOLARES, Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString)), 2)
                        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString) * Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                    ElseIf COD_MONEDA = "S" Then
                        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString)), 2)
                        H_DOLARES = Math.Round(Decimal.Add(H_DOLARES, Decimal.Parse((CDbl((Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString) / Decimal.Parse(txt_cambio_pago.Text)))))), 2)
                    Else
                        H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse(dgw_mov1.Item(3, I).Value.ToString)), 2)
                        H_DOLARES = H_DOLARES + 0
                    End If
                Else
                    H_DOLARES = Math.Round(Decimal.Add(H_DOLARES, 0), 2)
                    H_SOLES = Math.Round(Decimal.Add(H_SOLES, Decimal.Parse((CDbl(Decimal.Parse(dgw_mov1.Item(4, I).Value.ToString))))), 2)
                End If
            End If
            I += 1
        Loop
        txt_debe_soles.Text = (obj.HACER_DECIMAL(D_SOLES))
        txt_debe_dolares.Text = (obj.HACER_DECIMAL(D_DOLARES))
        txt_haber_soles.Text = (obj.HACER_DECIMAL(H_SOLES))
        txt_haber_dolares.Text = (obj.HACER_DECIMAL(H_DOLARES))
        txt_saldo_soles.Text = obj.HACER_DECIMAL(Math.Round(D_SOLES - H_SOLES, 2))
        txt_saldo_dolares.Text = obj.HACER_DECIMAL(Math.Round(D_DOLARES - H_DOLARES, 2))
        COD_D_H_PAGO = "H"
        If (COD_MONEDA = "S") Then
            total = Decimal.Parse(txt_saldo_soles.Text)
        Else
            total = Decimal.Parse(txt_saldo_dolares.Text)
        End If
        If (Decimal.Compare(total, Decimal.Zero) < 0) Then
            total = Decimal.Multiply(total, Decimal.MinusOne)
            COD_D_H_PAGO = "D"
        End If
        TXT_PAGO.Text = (total)
        TXT_PAGO.Text = (obj.HACER_DECIMAL(TXT_PAGO.Text))
    End Sub

    Sub INSERTAR_DE_DAILOG()
        Dim ITEM0 As Integer = OFR.DGW_CAB.CurrentRow.Index
        VAR_PRO = "S"
        COD_DOC = OFR.DGW_CAB.Item(0, ITEM0).Value
        cbo_tipo_doc.Text = OFR.DGW_CAB.Item(1, ITEM0).Value
        txt_nro_doc.Text = OFR.DGW_CAB.Item(2, ITEM0).Value
        COD_MON_DOC = OFR.DGW_CAB.Item(6, ITEM0).Value
        cbo_moneda1.Text = obj.DESC_MONEDA(COD_MON_DOC)
        '---------------------------------------------
        txt_imp_soles.Text = ((OFR.DGW_CAB.Item(17, ITEM0).Value * RET) / 100)
        txt_imp_doc.Text = OFR.DGW_CAB.Item(17, ITEM0).Value
        '---------------------------------------------
        txt_cod_cta.Text = obj.DIR_TABLA_DESC("CTAP_C", "TDEFA") ' OFR.DGW_CAB.Item(13, ITEM0).Value
        txt_desc_cta.Text = obj.DESC_CUENTA(txt_cod_cta.Text, AÑO)
        txt_glosa.Text = txt_desc_per.Text
        STATUS_CC = OFR.DGW_CAB.Item(14, ITEM0).Value
        STATUS_P = OFR.DGW_CAB.Item(16, ITEM0).Value
        txt_cod_cta.Focus()
        txt_imp_soles.Focus()
    End Sub

    Sub INSERTAR_DGW_PAGO()
        Dim ITEM0 As String = "01"
        Dim CTE As String = "0"
        'INSERTAR EL DETALLE DEL PAGO
        dgw_mov.Rows.Clear()
        dgw_mov.Rows.Add("", COD_RET, txt_nro_ret.Text, dtp_ret.Value, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, COD_D_H_PAGO, TXT_PAGO.Text, COD_MONEDA, txt_cambio_pago.Text, txt_glosa_pago.Text, txt_cod_cta_pago.Text, " ", " ", " ", "0", dtp_ret.Value, "", "", "", "", "", "", dtp_ret.Value, ITEM0, "1")
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        I = 0
        'INSERTAR LOS DETALLES 
        Do While (I <= CONT)
            dgw_mov.Rows.Add("", (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(2, I).Value), dtp_ret.Value, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, (dgw_mov1.Item(6, I).Value), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), txt_cambio_pago.Text, (dgw_mov1.Item(9, I).Value), (dgw_mov1.Item(10, I).Value), (dgw_mov1.Item(12, I).Value), (dgw_mov1.Item(13, I).Value), (dgw_mov1.Item(14, I).Value), CTE, (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(15, I).Value), (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), (dgw_mov1.Item(19, I).Value), (dgw_mov1.Item(20, I).Value), (dgw_mov1.Item(21, I).Value), (dgw_mov1.Item(22, I).Value), ITEM0, "0")
            I += 1
        Loop
    End Sub

    Function INSERTAR_TODO() As String
        Dim ESTADO As String = "FALLO"
        Dim BULK As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_mov.RowCount - 1
        DT_DET.Rows.Clear()
        I = 0
        Dim DOLARES As Decimal
        Dim SOLES As Decimal
        Dim VAR_PRO00 As String
        Do While (I <= CONT)
            With dgw_mov
                If .Item(9, I).Value = "S" Then
                    SOLES = Math.Round(Decimal.Parse(.Item(8, I).Value), 2)
                    DOLARES = Math.Round(Decimal.Divide(Decimal.Parse(.Item(8, I).Value), Decimal.Parse(.Item(10, I).Value)), 2)
                Else
                    DOLARES = Math.Round(Decimal.Parse(.Item(8, I).Value), 2)
                    SOLES = Math.Round(Decimal.Multiply(Decimal.Parse(.Item(8, I).Value), Decimal.Parse(.Item(10, I).Value)), 2)
                End If
                If (.Item(26, I).Value.ToString = "1") Then
                    VAR_PRO00 = "0"
                Else
                    VAR_PRO00 = .Item(21, I).Value.ToString
                End If
                DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, .Item(1, I).Value, _
                    .Item(2, I).Value, .Item(4, I).Value, .Item(6, I).Value, (I + 1).ToString("0000"), _
                    .Item(3, I).Value, .Item(22, I).Value, .Item(23, I).Value, .Item(24, I).Value, .Item(11, I).Value, _
                    .Item(12, I).Value, SOLES, DOLARES, .Item(7, I).Value, .Item(9, I).Value, .Item(10, I).Value, _
                    .Item(13, I).Value, .Item(14, I).Value, .Item(15, I).Value, " ", .Item(17, I).Value, "0", "", _
                    "", "0", VAR_PRO00, "0", .Item(26, I).Value, COD_MP, 0, dtp_com.Value.Date, .Item(25, I).Value, "", _
                    VAR_PRO00, dtp_com.Value, 0, NOMBRE_PC)
            End With
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
        '------------------------------------
        ' RETENCION

        I = 0
        CONT = DGW_RET2.RowCount - 1
        DT_RET.Rows.Clear()
        Do While I <= CONT
            With DGW_RET2
                DT_RET.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES, (I + 1).ToString("0000"), .Item(1, I).Value, _
                    .Item(2, I).Value, DGW_RET2.Item(3, I).Value, .Item(4, I).Value, .Item(5, I).Value, .Item(6, I).Value, _
                    Decimal.Parse(.Item(7, I).Value), Decimal.Parse(.Item(8, I).Value), NOMBRE_PC, .Item(9, I).Value, _
                    txt_cod1.Text, .Item(11, I).Value, Decimal.Parse(.Item(12, I).Value), Decimal.Parse(IIf(.Item(13, I).Value = "", 0, .Item(13, I).Value)))
            End With
            I += 1
        Loop

        'For I = 0 To CONT
        '    DT_RET.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES, (I + 1).ToString("0000"), _
        '    DGW_RET2.Item(1, I).Value, DGW_RET2.Item(2, I).Value, DGW_RET2.Item(3, I).Value, _
        '    DGW_RET2.Item(4, I).Value, DGW_RET2.Item(5, I).Value, DGW_RET2.Item(6, I).Value, _
        '    Decimal.Parse(DGW_RET2.Item(7, I).Value), Decimal.Parse(DGW_RET2.Item(8, I).Value), NOMBRE_PC, DGW_RET2.Item(9, I).Value, _
        '    txt_cod1.Text, DGW_RET2.Item(11, I).Value, Decimal.Parse(DGW_RET2.Item(12, I).Value), Decimal.Parse(IIf(DGW_RET2.Item(13, I).Value = "", 0, DGW_RET2.Item(13, I).Value)))
        'Next
        Try
            con.Open()
            BULK.DestinationTableName = "DBO.T_PERCEPCIONES2"
            BULK.WriteToServer(DT_RET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
            Return ESTADO
        End Try
        '------------------------------------
        Dim IMP0 As Decimal = txt_saldo_dolares.Text
        If COD_MONEDA = "S" Then
            IMP0 = txt_saldo_soles.Text
        End If
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_CXC_PERCEPCION", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.Char).Value = COD_AUX
            comand1.Parameters.Add("@cod_comP", SqlDbType.Char).Value = COD_COMP
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.Char).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.Char).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.Char).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_PERC", SqlDbType.Char).Value = COD_RET
            comand1.Parameters.Add("@NRO_PERC", SqlDbType.VarChar).Value = txt_nro_ret.Text
            comand1.Parameters.Add("@FECHA_PERC", SqlDbType.DateTime).Value = dtp_ret.Value
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
            '-------------------------------------------------------------------------
            comand1.Parameters.Add("@TOTAL_IMP", SqlDbType.Decimal).Value = IMP0
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = txt_cod1.Text
            comand1.Parameters.Add("@COD_OPERACION", SqlDbType.Char).Value = COD_OPE
            comand1.Parameters.Add("@COD_MP", SqlDbType.Char).Value = "000"
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = "0"
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = Decimal.Parse(txt_cambio_pago.Text)
            comand1.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_com.Value.Date
            comand1.Parameters.Add("@TASA", SqlDbType.Decimal).Value = RET
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
        txt_cod1.Enabled = True
        txt_desc_per.Enabled = True
        txt_nro_doc_per.Enabled = True
        '-------------------------------
        Panel_pago00.Enabled = True
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        Dim DESC_COM As String = cbo_com.Text
        cbo_com.SelectedIndex = -1
        cbo_com.Text = DESC_COM
        btn_grabar.Visible = True
        btn_grabar2.Visible = False
        dgw_mov1.Rows.Clear()
        btn_grabar.Enabled = True
        dgw_mov.Rows.Clear()
        DGW_RET2.Rows.Clear()
        Panel_det.Visible = False
        dtp_com.Value = FECHA_GRAL
        txt_cod1.Clear()
        txt_desc_per.Clear()
        txt_nro_doc_per.Clear()
        txt_cod_cta.Clear()
        txt_desc_cta.Clear()
        txt_cod_cta_pago.Clear()
        txt_desc_cta_pago.Clear()
        txt_nro_ret.Clear()
        txt_cambio_pago.Text = "0.0000"
        txt_glosa_pago.Clear()
        GroupBox1.Enabled = True
        TXT_PAGO.Text = "0.00"
        dgw_mov1.Rows.Clear()
        GroupBox1.Enabled = True
        dtp_ret.Value = FECHA_GRAL
        txt_nro_ret.Clear()
        Panel_doc00.Enabled = True
        Panel_det.Visible = False
        STATUS_DOC = "CP"
        btn_grabar.Visible = True
        btn_grabar2.Visible = False
        txt_debe_soles.Text = "0.00"
        txt_debe_dolares.Text = "0.00"
        txt_haber_soles.Text = "0.00"
        txt_haber_dolares.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        txt_saldo_dolares.Text = "0.00"
        btn_imprimir.Enabled = False
        '--
        TabControl2.SelectedTab = TabPage3
        'DEFAULTS
        COD_RET = obj.DIR_TABLA_DESC("DOCPER", "TDEFA") : cbo_ret.Text = obj.DESC_DOC(COD_RET)
        COD_MONEDA = obj.DIR_TABLA_DESC("MONPER", "TDEFA") : cbo_moneda_pago.Text = obj.DESC_MONEDA(COD_MONEDA)
        txt_cod_cta_pago.Text = obj.DIR_TABLA_DESC("CTAPER", "TDEFA") : txt_desc_cta_pago.Text = obj.DESC_CUENTA(txt_cod_cta_pago.Text, AÑO)
    End Sub

    Sub LIMPIAR_DETALLES()
        OFR_RET.DGW_CAB.Rows.Clear()
        OFR_RET.txt_total.Text = "0.00"
        OFR_RET.txt_total2.Text = "0.00"
        TabControl2.SelectedTab = TabPage3
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
        txt_imp_soles.Text = "0.00"
        CheckBox1.Checked = False
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
        btn_guardar.Enabled = False
        btn_modificar2.Visible = False
        'cbo_tipo_ref.SelectedIndex = -1
        VAR_PRO = "N"
        CBO_CC.Enabled = False
        CBO_CC.SelectedIndex = -1
        'txt_nro_ref.Clear()
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
            If dgw_mov.Item(9, I).Value = "S" OrElse dgw_mov.Item(9, I).Value = "A" Then
                SOLES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
                DOLARES = Math.Round(Decimal.Divide(Decimal.Parse((dgw_mov.Item(8, I).Value)), Decimal.Parse((dgw_mov.Item(10, I).Value))), 2)
            Else
                DOLARES = Math.Round(Decimal.Parse((dgw_mov.Item(8, I).Value)), 2)
                SOLES = Math.Round(Decimal.Multiply(Decimal.Parse((dgw_mov.Item(8, I).Value)), Decimal.Parse((dgw_mov.Item(10, I).Value))), 2)
            End If
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
        '------------------------------------
        ' RETENCION
        DT_RET.Rows.Clear()
        I = 0
        CONT = (DGW_RET2.RowCount - 1)
        For I = 0 To CONT
            'If dgw_mov1.Item(1, I).Value = "01" Then
            DT_RET.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES, (I + 1).ToString("0000"), DGW_RET2.Item(1, I).Value, DGW_RET2.Item(2, I).Value, DGW_RET2.Item(3, I).Value, DGW_RET2.Item(4, I).Value, DGW_RET2.Item(5, I).Value, DGW_RET2.Item(6, I).Value, DGW_RET2.Item(7, I).Value, (DGW_RET2.Item(8, I).Value), NOMBRE_PC, DGW_RET2.Item(9, I).Value, txt_cod1.Text, DGW_RET2.Item(11, I).Value, _
            Decimal.Parse(DGW_RET2.Item(12, I).Value), Decimal.Parse(IIf(CStr(DGW_RET2.Item(13, I).Value) = "", 0, DGW_RET2.Item(13, I).Value)))
            'DT_RET.Colu COD_AUX     COD_COMP    NRO_COMP         AÑO  MES          ITEM                  COD_DOC                      NRO_DOC                FECHA_DOC               COD_REF                        NRO_REF                       FECHA_REF                       IMPORTE                          BASE_IMP                 NOMBRE_PC,   COD_D_H")
            'Else
            'DT_RET.Rows.Add(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES, (I + 1).ToString("0000"), dgw_mov1.Item(20, I).Value, dgw_mov1.Item(21, I).Value, dgw_mov1.Item(22, I).Value, dgw_mov1.Item(1, I).Value, dgw_mov1.Item(2, I).Value, dgw_mov1.Item(8, I).Value, dgw_mov1.Item(3, I).Value, (dgw_mov1.Item(3, I).Value * 100 / 6), NOMBRE_PC, dgw_mov1.Item(6, I).Value, txt_cod1.Text)
            '    DT_RET.Colu COD_AUX     COD_COMP    NRO_COMP         AÑO  MES          ITEM                  COD_DOC                      NRO_DOC                FECHA_DOC                    COD_REF                        NRO_REF                       FECHA_REF                       IMPORTE                          BASE_IMP                 NOMBRE_PC,   COD_D_H")
            'End If
        Next
        Try
            con.Open()
            BULK.DestinationTableName = "DBO.T_PERCEPCIONES2"
            BULK.WriteToServer(DT_RET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
            Return ESTADO
        End Try
        '------------------------------------
        Dim IMP0 As Decimal = txt_saldo_dolares.Text
        If COD_MONEDA = "S" Then
            IMP0 = txt_saldo_soles.Text
        End If
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_CXC_PERCEPCION", con)
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
            comand1.Parameters.Add("@COD_RET", SqlDbType.VarChar).Value = COD_RET
            comand1.Parameters.Add("@NRO_RET", SqlDbType.VarChar).Value = txt_nro_ret.Text
            comand1.Parameters.Add("@FECHA_RET", SqlDbType.DateTime).Value = dtp_ret.Value
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            '-------------------------------------------------------------------------
            comand1.Parameters.Add("@TOTAL_IMP", SqlDbType.Decimal).Value = IMP0
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = txt_cod1.Text
            comand1.Parameters.Add("@COD_OPERACION", SqlDbType.Char).Value = COD_OPE
            comand1.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = ""
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio_pago.Text
            comand1.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = dtp_com.Value.Date
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
            DGW_PER_anul.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            DGW_PER.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER_anul.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER.Columns.Item(0).Width = &H37
            DGW_PER.Columns.Item(1).Width = 330
            '-------------------------------------
            DGW_PER_anul.Columns.Item(0).Width = &H37
            DGW_PER_anul.Columns.Item(1).Width = 330
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
                    If (txt_cod_cta.Text.ToLower = DGW_CTA1.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta.Text = DGW_CTA1.Item(0, i).Value.ToString
                        txt_desc_cta.Text = DGW_CTA1.Item(1, i).Value.ToString
                        STATUS_CC = DGW_CTA1.Item(2, i).Value.ToString
                        STATUS_P = DGW_CTA1.Item(3, i).Value.ToString
                        CBO_CC.SelectedIndex = -1
                        CBO_CC.Enabled = False
                        'cbo_proyecto.SelectedIndex = -1
                        'cbo_proyecto.Enabled = False
                        If STATUS_CC = "1" Then
                            CBO_CC.Enabled = True
                        End If
                        'If (STATUS_P = "1") Then
                        '    cbo_proyecto.Enabled = True
                        'End If
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
                        cbo_tipo.Focus()
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
                MessageBox.Show("No existen PERSONAS X Cobrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER.Sort(DGW_PER.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod1.Text.ToLower = DGW_PER.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod1.Text = DGW_PER.Item(0, i).Value.ToString
                        txt_desc_per.Text = DGW_PER.Item(1, i).Value.ToString
                        txt_nro_doc_per.Text = DGW_PER.Item(2, i).Value.ToString
                        txt_glosa_pago.Text = txt_desc_per.Text
                        txt_cod_cta_pago.Focus()
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
                    If (txt_desc_cta.Text.ToLower = Strings.Mid((DGW_CTA1.Item(1, i).Value), 1, Strings.Len(txt_desc_cta.Text)).ToLower) Then
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

    Private Sub txt_imp_soles_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_soles.KeyPress, txt_imp_doc.KeyPress
        e.Handled = Numero(e, txt_imp_soles)
    End Sub

    Private Sub txt_imp_soles_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_imp_soles.LostFocus, txt_imp_doc.LostFocus
        If (Strings.Trim(txt_imp_soles.Text) <> "") Then
            Try
                txt_imp_soles.Text = obj.HACER_DECIMAL(txt_imp_soles.Text)
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

    'Private Sub btn_fec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cbo_tipo_ref.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el documento de referencia") : cbo_tipo_ref.Focus() : Exit Sub
    '    If txt_nro_ref.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de referencia") : txt_nro_ref.Focus() : Exit Sub
    '    Try
    '        Dim COD_SUC As String = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
    '        cod_ref = obj.COD_DOC(cbo_tipo_ref.Text)
    '        dtp_ref.Value = obj.HALLAR_FECHA_REF(cod_ref, txt_nro_ref.Text, txt_cod1.Text, txt_cod_cta.Text, COD_SUC)
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub btn_ref0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ref0.Click
        '---------------------------------------------------------------
        Dim COD_SUC As String = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        '---------------------------------------------------------------
        OFR_RET.COD_PER = txt_cod1.Text
        OFR_RET.COD_SUC = COD_SUC
        OFR_RET.TC = txt_cambio_pago.Text
        OFR_RET.FECHA0 = dtp_ret.Value
        OFR_RET.CBO_MONEDA00()
        OFR_RET.cbo_moneda.Text = cbo_moneda1.Text
        '-------------------------------------------validando importe x nuevo y modificar
        If btn_doc_pte.Enabled = True Then
            OFR_RET.txt_doc_total.Text = obj.HACER_DECIMAL(OFR.IMPORTE0)
        Else
            OFR_RET.txt_doc_total.Text = OFR_RET.txt_total.Text
        End If
        OFR_RET.HALLAR_TOTAL2()
        '----------------------------------------------------------------
        OFR_RET.CBO_TIPO_DOC00()
        OFR_RET.cbo_tipo_ref.Text = cbo_tipo_doc.Text
        If obj.COD_DOC(cbo_tipo_doc.Text) = "01" OrElse _
        obj.COD_DOC(cbo_tipo_doc.Text) = "07" OrElse _
        obj.COD_DOC(cbo_tipo_doc.Text) = "08" OrElse _
        obj.COD_DOC(cbo_tipo_doc.Text) = "12" Then

            OFR_RET.cbo_tipo_ref.Enabled = False
            OFR_RET.dgw_doc.Rows.Clear()
            OFR_RET.dgw_doc.Rows.Add(txt_nro_doc.Text, "", "", txt_imp_doc.Text)
            OFR_RET.txt_ini.Text = txt_imp_doc.Text
            OFR_RET.TXT_INI_2DO.Text = txt_imp_doc.Text
        Else
            OFR_RET.cbo_tipo_ref.Enabled = True
        End If
        'OFR_RET.txt_nro_ref.Text = txt_nro_doc.Text
        '----------------------------------------------------------------
        OFR_RET.ShowDialog()
        '----------------------------------------------------------------
        If OFR_RET.DialogResult = Windows.Forms.DialogResult.OK Then
            btn_guardar.Enabled = True
        End If
        '----------------------------------------------------------------
    End Sub

    Sub CARGAR_DIALOG()
        OFR_RET.DGW_CAB.Rows.Clear()
        Dim I, CONT As Integer
        I = 0 : CONT = DGW_RET2.RowCount - 1
        For I = 0 To CONT
            If DGW_RET2.Item(1, I).Value = COD_DOC And DGW_RET2.Item(2, I).Value = txt_nro_doc.Text Then
                Dim IMP As Decimal = DGW_RET2.Item(8, I).Value
                If DGW_RET2.Item(11, I).Value.ToString = "D" Then
                    IMP = Math.Round(Decimal.Parse(DGW_RET2.Item(8, I).Value / txt_cambio_pago.Text), 2)
                End If
                OFR_RET.DGW_CAB.Rows.Add(DGW_RET2.Item(4, I).Value, DGW_RET2.Item(5, I).Value, DGW_RET2.Item(6, I).Value, DGW_RET2.Item(11, I).Value, IMP, DGW_RET2.Item(8, I).Value, DGW_RET2.Item(7, I).Value, DGW_RET2.Item(9, I).Value)
            End If
        Next
        OFR_RET.HALLAR_TOTAL()
    End Sub

    Sub INSERTAR_DIALOG(ByVal ITEM0 As String)
        With OFR_RET.DGW_CAB
            Dim I, CONT As Integer
            I = 0 : CONT = .RowCount - 1
            For I = 0 To CONT
                DGW_RET2.Rows.Add(ITEM0, COD_DOC, txt_nro_doc.Text, dtp_ret.Value.Date, .Item(0, I).Value, _
                    .Item(1, I).Value, .Item(2, I).Value, .Item(6, I).Value, .Item(5, I).Value, .Item(7, I).Value, _
                    txt_cod1.Text, .Item(3, I).Value, .Item(8, I).Value, .Item(9, I).Value)
            Next
        End With

    End Sub

    Sub ELIMINAR_DIALOG(ByVal COD_DOC0 As String, ByVal NRO_DOC0 As String)
        Dim I, CONT As Integer
        I = 0 : CONT = DGW_RET2.RowCount - 1
        While I <= CONT
            If COD_DOC0 = DGW_RET2.Item(1, I).Value And NRO_DOC0 = DGW_RET2.Item(2, I).Value Then
                DGW_RET2.Rows.RemoveAt(I)
                I = 0 : CONT = DGW_RET2.RowCount - 1
            Else
                I += 1
            End If
        End While
    End Sub

    Private Sub cbo_tipo_doc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo_doc.SelectedIndexChanged
        If cbo_tipo_doc.SelectedIndex <> -1 Then
            COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
            cbo_dh.Text = obj.COD_D_H(COD_DOC)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            btn_guardar.Enabled = True
        Else
            btn_guardar.Enabled = False
        End If
    End Sub

    Private Sub btn_nuevo_anul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_anul.Click
        BOTON = "NUEVO"
        LIMPIAR_ANULADAS()
        TabControl3.SelectedTab = TabPage7
        cbo_aux_anul.Focus()
    End Sub

    Sub LIMPIAR_ANULADAS()
        txt_cod1_anul.Enabled = True
        txt_desc_per_anul.Enabled = True
        txt_nro_doc_per_anul.Enabled = True
        '-------------------------------
        g_cab_anul.Enabled = True
        txt_nro_comp_anul.Clear()
        cbo_com_anul.SelectedIndex = -1
        btn_grabar_anul.Visible = True
        btn_grabar2_anul.Visible = False
        btn_grabar_anul.Enabled = True
        dtp_com_anul.Value = FECHA_GRAL
        txt_cod1_anul.Clear()
        txt_desc_per_anul.Clear()
        txt_nro_doc_per_anul.Clear()
        txt_cod_cta_pago_anul.Clear()
        txt_desc_cta_pago_anul.Clear()
        txt_nro_ret_anul.Clear()
        txt_cambio_pago_anul.Text = "0.0000"
        GroupBox1_anul.Enabled = True
        GroupBox1_anul.Enabled = True
        dtp_ret_anul.Value = FECHA_GRAL
        txt_nro_ret_anul.Clear()
        txt_nro_comp_anul.Clear()
        btn_grabar_anul.Visible = True
        btn_grabar2_anul.Visible = False
        cbo_aux_anul.SelectedIndex = -1
        '----------------------------------------------------------------------
        'DEFAULTS
        COD_RET_ANUL = obj.DIR_TABLA_DESC("DOCPER", "TDEFA") : cbo_ret_anul.Text = obj.DESC_DOC(COD_RET_ANUL)
        COD_MONEDA_ANUL = obj.DIR_TABLA_DESC("MONPER", "TDEFA") : cbo_moneda_pago_anul.Text = obj.DESC_MONEDA(COD_MONEDA_ANUL)
        txt_cod_cta_pago_anul.Text = obj.DIR_TABLA_DESC("CTAPER", "TDEFA") : txt_desc_cta_pago_anul.Text = obj.DESC_CUENTA(txt_cod_cta_pago_anul.Text, AÑO)
        '----------------------------------------------------------------------
    End Sub

    Private Sub btn_grabar_anul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar_anul.Click
        If cbo_aux_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux_anul.Focus() : Exit Sub
        If txt_cod1_anul.Text.Trim = "" Then MessageBox.Show("Debe elegir al proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod1_anul.Focus() : Exit Sub
        If cbo_com_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com_anul.Focus() : Exit Sub
        If txt_nro_comp_anul.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp_anul.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com_anul.Value)) = 0) Then dtp_com_anul.Focus() : Exit Sub
        If txt_cod_cta_pago_anul.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta del Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp_ret_anul.Focus() : Exit Sub
        If cbo_ret_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Medio de Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret_anul.Focus() : Exit Sub
        If txt_nro_ret_anul.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de Retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret_anul.Focus() : Exit Sub
        If cbo_ret_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el documento de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret_anul.Focus() : Exit Sub
        If txt_nro_ret_anul.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret_anul.Focus() : Exit Sub
        If cbo_tipo_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_anul.Focus() : Exit Sub
        COD_OPE_ANUL = (cbo_tipo_anul.SelectedIndex + 1).ToString("00")
        If INSERTAR_TODO_ANULADOS() = "EXITO" Then
            MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        DATAGRID()
        btn_grabar_anul.Enabled = False
    End Sub

    Function INSERTAR_TODO_ANULADOS() As String
        Dim ESTADO As String = "FALLO"
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_CXC_PERCEPCION_ANUL", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX_ANUL
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP_ANUL
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp_anul.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com_anul.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_RET", SqlDbType.VarChar).Value = COD_RET_ANUL
            comand1.Parameters.Add("@NRO_RET", SqlDbType.VarChar).Value = txt_nro_ret_anul.Text
            comand1.Parameters.Add("@FECHA_RET", SqlDbType.DateTime).Value = dtp_ret_anul.Value
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA_ANUL
            comand1.Parameters.Add("@TOTAL_IMP", SqlDbType.Decimal).Value = "0.00"
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = txt_cod1_anul.Text
            comand1.Parameters.Add("@COD_OPERACION", SqlDbType.Char).Value = COD_OPE_ANUL
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio_pago_anul.Text
            comand1.Parameters.Add("@ST_ANULADO", SqlDbType.Char).Value = "1"
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

    Private Sub cbo_aux_anul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_aux_anul.SelectedIndexChanged
        If cbo_aux_anul.SelectedIndex <> -1 Then
            COD_AUX_ANUL = obj.COD_AUX(cbo_aux_anul.Text)
            CBO_COMPROBANTE_ANUL()
        End If
    End Sub

    Sub CBO_COMPROBANTE_ANUL()
        cbo_com_anul.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX_ANUL
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com_anul.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try

        If (cbo_com_anul.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub cbo_com_anul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_com_anul.SelectedIndexChanged
        If cbo_aux_anul.SelectedIndex <> -1 And cbo_com_anul.SelectedIndex <> -1 Then
            COD_AUX_ANUL = obj.COD_AUX(cbo_aux_anul.Text)
            COD_COMP_ANUL = obj.COD_COMP(cbo_com_anul.Text, COD_AUX_ANUL)
            Dim NUM01 As String = obj.HALLAR_NRO_COMP(COD_AUX_ANUL, COD_COMP_ANUL, AÑO, MES)
            If NUM01 = "" Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp_anul.Text = NUM01
        End If
    End Sub

    Private Sub dtp_ret_anul_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_ret_anul.LostFocus
        If (cbo_moneda_pago_anul.SelectedIndex <> -1) Then
            COD_MONEDA_ANUL = cbo_moneda_pago_anul.SelectedValue.ToString
            If ((COD_MONEDA_ANUL = "S") Or (COD_MONEDA_ANUL.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago_anul.Text = obj.SACAR_CAMBIO(dtp_ret_anul.Value.Year, dtp_ret_anul.Value.ToString("MM"), dtp_ret_anul.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago_anul.Text = obj.SACAR_CAMBIO(dtp_ret_anul.Value.Year, dtp_ret_anul.Value.ToString("MM"), dtp_ret_anul.Value.ToString("dd"), COD_MONEDA_ANUL)
            End If
        End If
    End Sub

    Private Sub cbo_moneda_pago_anul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_moneda_pago_anul.SelectedIndexChanged
        If (cbo_moneda_pago_anul.SelectedIndex <> -1) Then
            COD_MONEDA_ANUL = cbo_moneda_pago_anul.SelectedValue.ToString
            If ((COD_MONEDA_ANUL = "S") Or (COD_MONEDA_ANUL.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago_anul.Text = obj.SACAR_CAMBIO(dtp_ret_anul.Value.Year, dtp_ret_anul.Value.ToString("MM"), dtp_ret_anul.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago_anul.Text = obj.SACAR_CAMBIO(dtp_ret_anul.Value.Year, dtp_ret_anul.Value.ToString("MM"), dtp_ret_anul.Value.ToString("dd"), COD_MONEDA_ANUL)
            End If
        End If
    End Sub

    Private Sub txt_cod1_anul_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod1_anul.LostFocus
        If (txt_cod1_anul.Text.Trim <> "") Then
            If (DGW_PER_anul.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER_anul.Sort(DGW_PER_anul.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER_anul.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod1_anul.Text.ToLower = DGW_PER_anul.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod1_anul.Text = DGW_PER_anul.Item(0, i).Value.ToString
                        txt_desc_per_anul.Text = DGW_PER_anul.Item(1, i).Value.ToString
                        txt_nro_doc_per_anul.Text = DGW_PER_anul.Item(2, i).Value.ToString
                        'txt_glosa_pago_anul.Text = txt_desc_per_anul.Text
                        txt_cod_cta_pago_anul.Focus()
                        Return
                    End If
                    If (txt_cod1_anul.Text.ToLower = Strings.Mid((DGW_PER_anul.Item(0, i).Value), 1, Strings.Len(txt_cod1_anul.Text)).ToLower) Then
                        DGW_PER_anul.CurrentCell = DGW_PER_anul.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER_anul.CurrentCell = DGW_PER_anul.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER_anul.Visible = True
                DGW_PER_anul.Visible = True
                DGW_PER_anul.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_per_anul_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_per_anul.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per_anul.Text) <> "")) Then
            If (DGW_PER_anul.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER_anul.Sort(DGW_PER_anul.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER_anul.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_per_anul.Text.ToLower = Strings.Mid((DGW_PER_anul.Item(1, i).Value), 1, Strings.Len(txt_desc_per_anul.Text)).ToLower) Then
                        DGW_PER_anul.CurrentCell = DGW_PER_anul.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER_anul.CurrentCell = DGW_PER_anul.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER_anul.Visible = True
                DGW_PER_anul.Visible = True
                DGW_PER_anul.Focus()
            End If
        End If
    End Sub

    Private Sub txt_nro_doc_per_anul_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nro_doc_per_anul.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_nro_doc_per_anul.Text) <> "")) Then
            If (DGW_PER_anul.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                DGW_PER_anul.Sort(DGW_PER_anul.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (DGW_PER_anul.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_nro_doc_per_anul.Text.ToLower = Strings.Mid((DGW_PER_anul.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per_anul.Text)).ToLower) Then
                        DGW_PER_anul.CurrentCell = DGW_PER_anul.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    DGW_PER_anul.CurrentCell = DGW_PER_anul.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER_anul.Visible = True
                DGW_PER_anul.Visible = True
                DGW_PER_anul.Focus()
            End If
        End If
    End Sub

    Private Sub DGW_PER_anul_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGW_PER_anul.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod1_anul.Text = DGW_PER_anul.Item(0, DGW_PER_anul.CurrentRow.Index).Value.ToString
            txt_desc_per_anul.Text = DGW_PER_anul.Item(1, DGW_PER_anul.CurrentRow.Index).Value.ToString
            txt_nro_doc_per_anul.Text = DGW_PER_anul.Item(2, DGW_PER_anul.CurrentRow.Index).Value.ToString
            'txt_glosa_pago_anul.Text = txt_desc_per_anul.Text
            Panel_PER_anul.Visible = False
            KL22.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER_anul.Visible = False
            txt_cod1_anul.Clear()
            txt_desc_per_anul.Clear()
            txt_nro_doc_per_anul.Clear()
            txt_cod1_anul.Focus()
        End If
    End Sub

    Private Sub txt_cod_cta_pago_anul_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta_pago_anul.LostFocus
        If (Strings.Trim(txt_cod_cta_pago_anul.Text) <> "") Then
            If (dgw_cta_pago_anul.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago_anul.Sort(dgw_cta_pago_anul.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago_anul.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta_pago_anul.Text.ToLower = dgw_cta_pago_anul.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta_pago_anul.Text = dgw_cta_pago_anul.Item(0, i).Value.ToString
                        txt_desc_cta_pago_anul.Text = dgw_cta_pago_anul.Item(1, i).Value.ToString
                        STATUS_ANA_anul = dgw_cta_pago_anul.Item(2, i).Value.ToString
                        cbo_tipo_anul.Focus()
                        Return
                    End If
                    If (txt_cod_cta_pago_anul.Text.ToLower = Strings.Mid((dgw_cta_pago_anul.Item(0, i).Value), 1, Strings.Len(txt_cod_cta_pago_anul.Text)).ToLower) Then
                        dgw_cta_pago_anul.CurrentCell = dgw_cta_pago_anul.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago_anul.CurrentCell = dgw_cta_pago_anul.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta_pago_anul.Visible = True
                dgw_cta_pago_anul.Visible = True
                dgw_cta_pago_anul.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta_pago_anul_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta_pago_anul.KeyDown
        If ((e.KeyCode = Keys.Return) AndAlso (Strings.Trim(txt_desc_cta_pago_anul.Text) <> "")) Then
            If (dgw_cta_pago_anul.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta_pago_anul.Sort(dgw_cta_pago_anul.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta_pago_anul.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta_pago_anul.Text.ToLower = Strings.Mid((dgw_cta_pago_anul.Item(1, i).Value), 1, Strings.Len(txt_desc_cta_pago_anul.Text)).ToLower) Then
                        dgw_cta_pago_anul.CurrentCell = dgw_cta_pago_anul.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta_pago_anul.CurrentCell = dgw_cta_pago_anul.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta_pago_anul.Visible = True
                dgw_cta_pago_anul.Visible = True
                dgw_cta_pago_anul.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_cta_pago_anul_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta_pago_anul.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta_pago_anul.Text = dgw_cta_pago_anul.Item(0, dgw_cta_pago_anul.CurrentRow.Index).Value.ToString
            txt_desc_cta_pago_anul.Text = dgw_cta_pago_anul.Item(1, dgw_cta_pago_anul.CurrentRow.Index).Value.ToString
            STATUS_ANA_anul = dgw_cta_pago_anul.Item(2, dgw_cta_pago_anul.CurrentRow.Index).Value.ToString
            kl_pago2.Focus()
            Panel_cta_pago_anul.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta_pago_anul.Visible = False
            txt_cod_cta_pago_anul.Clear()
            txt_desc_cta_pago_anul.Clear()
            txt_cod_cta_pago_anul.Focus()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TabControl3.SelectedTab = TabPage6
        btn_nuevo_anul.Focus()
    End Sub

    Private Sub btn_modificar_anul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar_anul.Click
        Try
            Dim I As Integer = dgw_anul.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        BOTON = "MODIFICAR"
        LIMPIAR_ANULADAS()
        CARGAR_ANULADAS()
        btn_grabar_anul.Visible = False
        btn_grabar2_anul.Visible = True
        g_cab_anul.Enabled = False
        btn_grabar2_anul.Enabled = True
        GroupBox1_anul.Enabled = False
        TabControl3.SelectedTab = TabPage7
    End Sub

    Sub CARGAR_ANULADAS()
        COD_AUX_ANUL = (dgw_anul.Item(0, dgw_anul.CurrentRow.Index).Value)
        cbo_aux_anul.Text = dgw_anul.Item(1, dgw_anul.CurrentRow.Index).Value.ToString
        COD_COMP_ANUL = (dgw_anul.Item(2, dgw_anul.CurrentRow.Index).Value)
        cbo_com_anul.Text = dgw_anul.Item(3, dgw_anul.CurrentRow.Index).Value.ToString
        txt_nro_comp_anul.Text = (dgw_anul.Item(4, dgw_anul.CurrentRow.Index).Value)
        dtp_com_anul.Value = DateTime.Parse((dgw_anul.Item(5, dgw_anul.CurrentRow.Index).Value))
        txt_cod1_anul.Text = (dgw_anul.Item(6, dgw_anul.CurrentRow.Index).Value)
        txt_desc_per_anul.Text = (dgw_anul.Item(7, dgw_anul.CurrentRow.Index).Value)
        txt_nro_doc_per_anul.Text = (dgw_anul.Item(8, dgw_anul.CurrentRow.Index).Value)
        txt_nro_ret_anul.Text = (dgw_anul.Item(9, dgw_anul.CurrentRow.Index).Value)
        txt_cambio_pago_anul.Text = (dgw_anul.Item(10, dgw_anul.CurrentRow.Index).Value)
        '--------------------------------------------------------------------------------------------
        ' I RETENCIONES
        Try
            Dim pro_02 As New SqlCommand("CARGAR_I_PERCEPCIONES", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX_ANUL
            pro_02.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP_ANUL
            pro_02.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp_anul.Text
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = pro_02.ExecuteReader
            Do While rs3.Read
                'COD_MP_ANUL = (Rs3.GetValue(0))
                'txt_nro_mp_anul.Text = rs3.GetValue(1)
                'dtp_mp_anul.Value = rs3.GetValue(2)
                cbo_tipo_anul.Text = rs3.GetValue(3)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        '--------------------------------------------------------
        'cbo_mp_anul.Text = obj.DESC_MP(COD_MP_ANUL)
        '--------------------------------------------------------
    End Sub

    Private Sub btn_grabar2_anul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar2_anul.Click
        If cbo_aux_anul.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux_anul.Focus()
        ElseIf cbo_com_anul.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com_anul.Focus()
        ElseIf txt_nro_comp_anul.Text.Trim = "" Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp_anul.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com_anul.Value)) = 0) Then
            dtp_com_anul.Focus()
        ElseIf txt_cod_cta_pago_anul.Text.Trim = "" Then
            MessageBox.Show("Debe elegir la Cuenta del Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_ret_anul.Focus()
        ElseIf txt_nro_ret_anul.Text.Trim = "" Then
            MessageBox.Show("Debe ingresar el Nº de Retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_ret_anul.Focus()
        Else
            If cbo_ret_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el documento de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_ret_anul.Focus() : Exit Sub
            If txt_nro_ret_anul.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de retención", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ret_anul.Focus() : Exit Sub
            If cbo_tipo_anul.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_anul.Focus() : Exit Sub
            COD_OPE_ANUL = (cbo_tipo_anul.SelectedIndex + 1).ToString("00")
            If MODIFICAR_TODO_ANULADOS() = "EXITO" Then
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            DATAGRID()
            btn_grabar2_anul.Enabled = False
        End If
    End Sub

    Function MODIFICAR_TODO_ANULADOS() As String
        Dim ESTADO As String = "FALLO"
        Try
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_CXC_PERCEPCION_ANUL", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX_ANUL
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP_ANUL
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp_anul.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com_anul.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            comand1.Parameters.Add("@COD_RET", SqlDbType.VarChar).Value = COD_RET_ANUL
            comand1.Parameters.Add("@NRO_RET", SqlDbType.VarChar).Value = txt_nro_ret_anul.Text
            comand1.Parameters.Add("@FECHA_RET", SqlDbType.DateTime).Value = dtp_ret_anul.Value
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA_ANUL
            '-------------------------------------------------------------------------
            comand1.Parameters.Add("@TOTAL_IMP", SqlDbType.Decimal).Value = "0.00"
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = txt_cod1_anul.Text
            comand1.Parameters.Add("@COD_OPERACION", SqlDbType.Char).Value = COD_OPE_ANUL
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = txt_cambio_pago_anul.Text
            comand1.Parameters.Add("@ST_ANULADO", SqlDbType.Char).Value = "1"
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

    Private Sub btn_eliminar_anul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_anul.Click
        Try
            Dim I As Integer = dgw_anul.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Desea borrar el Comprobante", " Borrar Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            COD_AUX_ANUL = (dgw_anul.Item(0, dgw_anul.CurrentRow.Index).Value)
            COD_COMP_ANUL = (dgw_anul.Item(2, dgw_anul.CurrentRow.Index).Value)
            Dim nro_comp_anul00 As String = (dgw_anul.Item(4, dgw_anul.CurrentRow.Index).Value)
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_CXC_PERCEPCION2", con)
                comand1.CommandType = CommandType.StoredProcedure
                comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX_ANUL
                comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP_ANUL
                comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = nro_comp_anul00
                comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
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

    Private Sub btn_imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        LLENAR_DATASET()
        '-------------------------------------------------------------
        '-----------HALLANDO TOTAL DE IMPORTE RETENIDO----------------

        Dim I, CONT As Integer
        CONT = DGW_RET2.Rows.Count - 1
        Dim SUM, SUM2 As Decimal
        SUM = 0
        For I = 0 To CONT
            If DGW_RET2.Item(9, I).Value.ToString = "D" And DGW_RET2.Item(9, I).Value.ToString <> "" Then
                SUM = SUM + DGW_RET2.Item(7, I).Value
                SUM2 = SUM2 + DGW_RET2.Item(8, I).Value
            Else
                SUM = SUM - DGW_RET2.Item(7, I).Value
                SUM2 = SUM2 - DGW_RET2.Item(8, I).Value
            End If
        Next
        '-------------------------------------------------------------
        '---------------------HALLANDO LAS LETRAS---------------------

        Dim largo = Len(CStr(Format(CDbl(SUM), "##,###,###,##0.00")))
        Dim decimales = Mid(CStr(Format(CDbl(SUM), "##,###,###,##0.00")), largo - 2)
        Dim L As String
        Dim NUM0 As Integer = SUM - decimales
        L = obj.NumText(NUM0) & "  CON " & Mid(decimales, Len(decimales) - 1) & "/100 "
        REP.TipoImpresion = obj.DIR_TABLA_DESC("IMPPER", "TDEFA")
        Dim rutaLogo As String = obj.DIR_TABLA_DESC("IMPLOG", "TDEFA")
        '-------------------------------------------------------------
        REP.CREAR_REPORTE(dtp_ret.Value, txt_desc_per.Text, txt_nro_doc_per.Text, txt_cambio_pago.Text, Decimal.Parse(SUM2), _
            Decimal.Parse(SUM), L, txt_nro_ret.Text, rutaLogo)
        REP.ShowDialog()
    End Sub

    Sub LLENAR_DATASET()
        REP.LIMPIAR()
        Dim I, CONT As Integer
        CONT = DGW_RET2.Rows.Count - 1
        Dim ListaCopia As New List(Of String)
        ListaCopia.Add("CLIENTE")
        ListaCopia.Add("EMISOR - AGENTE DE PERCEPCION")
        ListaCopia.Add("SUNAT")
        ListaCopia.Add("CONTROL ADMINISTRATIVO")
        For I = 0 To CONT
            '-------------------------------------------------------------------
            '---------------HALLANDO SERIE Y NUMERO CORRELATIVO-----------------

            Dim SERIE, CORRELATIVO, NUMERO_COMPLETO, GUION As String
            Dim TAMAÑO As Integer
            NUMERO_COMPLETO = DGW_RET2.Item(5, I).Value.ToString
            TAMAÑO = NUMERO_COMPLETO.Length
            GUION = NUMERO_COMPLETO.LastIndexOf("-")
            SERIE = NUMERO_COMPLETO.Substring(0, GUION)
            CORRELATIVO = NUMERO_COMPLETO.Substring((GUION + 1), (TAMAÑO - GUION - 1))
            '-------------------------------------------------------------------
            Dim IMP As Decimal = DGW_RET2.Item(8, I).Value
            If DGW_RET2.Item(11, I).Value.ToString = "D" Then
                IMP = Math.Round(Decimal.Parse(DGW_RET2.Item(8, I).Value / txt_cambio_pago.Text), 2)
            End If
            '-------------------------------------------------------------------
            Dim BASE_I, IMPORTE As Decimal
            If DGW_RET2.Item(9, I).Value.ToString = "H" Then
                BASE_I = DGW_RET2.Item(8, I).Value * -1
                IMPORTE = DGW_RET2.Item(7, I).Value * -1
            Else
                BASE_I = DGW_RET2.Item(8, I).Value
                IMPORTE = DGW_RET2.Item(7, I).Value
            End If
            If obj.DIR_TABLA_DESC("IMPPER", "TDEFA") = "V" Then
                For Each s As String In ListaCopia
                    REP.llenar_dt(DGW_RET2.Item(4, I).Value.ToString, SERIE.ToString, CORRELATIVO.ToString, Date.Parse(DGW_RET2.Item(6, I).Value), BASE_I, IMPORTE, DGW_RET2.Item(9, I).Value, s)
                Next
            Else
                REP.llenar_dt(DGW_RET2.Item(4, I).Value.ToString, SERIE.ToString, CORRELATIVO.ToString, Date.Parse(DGW_RET2.Item(6, I).Value), BASE_I, IMPORTE, DGW_RET2.Item(9, I).Value, "")
            End If

        Next
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub

End Class