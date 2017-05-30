Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CIERRE_ANUAL
#Region "CONSTRUCTOR"
    Private Shared INSTANCIA As CIERRE_ANUAL
    Public Shared Function OBTENERINSTANCIA() As CIERRE_ANUAL
        If INSTANCIA Is Nothing OrElse INSTANCIA.IsDisposed Then
            INSTANCIA = New CIERRE_ANUAL
        End If
        INSTANCIA.BringToFront()
        Return INSTANCIA
    End Function
    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region
#Region "VARIABLES"
    Dim BOTON, BOTON_DETALLE, STATUS_P, ST_TRANS, ESTADO_PRECIO, STATUS_CC As String
    Private ST_NUEVO, COD_ACT, ENLACE, ESTADO_PER, ESTADO_AUTO As String
    Private COD_DH_DOC, DESTINO, COD_REF, COD_PROYECTO, COD_DOC As String
    Private COD_MONEDA, COD_CONTROL, COD_AUX, COD_CC, COD_COMP As String
    Dim DT_DET As New DataTable
    Dim FILA_DOC, fila2 As Integer
    Private obj As New Class1
    Dim reporte As New CrystalReport1
    Dim reporte1 As New CrystalComprobante
    Dim TEMP2 As New CONSULTA_CIERRE_TEMPORAL
    Dim ofr As New CONSULTA_REQ_ORD_PROD
    Dim fec_ven As Date
    Dim con00 As New SqlConnection(("data source=" & nombre_servidor & ";initial catalog=BD_COS" & COD_EMPRESA & ";uid=miguel;pwd=main;"))
    Private MODIFICA As Boolean = False
    Private ValidarFicha As Boolean = True
    Public ACTIVIDAD As String = ""
#End Region

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


    Private Sub ASIENTO_DIARIO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub ASIENTO_DIARIO_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub


    Private Sub Asiento_Diario_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Asiento_Diario_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CBO_DOCUMENTO()
        CREAR_DATASET()
        CARGAR_CUENTAS()
        Me.CBO_ACTIVIDAD()
        CBO_AUXILIAR()
        DGW_CC00()
        CBO_MONEDA0()
        DGW_PERSONAS()
        CBO_CONTROL00()
        CBO_PROYECTO00()
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
        ESTADO_PRECIO = "0"
        'If ACTIVIDAD = "CIERRE_CUENTA" Then Panel1.Visible = True
    End Sub

    Private Sub btn_cadena2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cadena2.Click
        btn_sgt2.Enabled = True
        Dim CONT As Integer = dgw_cta.RowCount - 1
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw_cta.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_desc_cta0.Text.ToLower = Strings.Mid(dgw_cta.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    dgw_cta.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        dgw_cta.Focus()
    End Sub

    Private Sub btn_cancelar_com_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar_com.Click
        TabControl1.SelectedTab = TabPage1
        Panel_doc2.Enabled = True
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
        HALLAR_TOTAL()
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = False
        Panel_doc2.Enabled = False
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
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Desea borrar el Comprobante", " Borrar Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            COD_AUX = dgw1.Item(0, dgw1.CurrentRow.Index).Value
            COD_COMP = dgw1.Item(2, dgw1.CurrentRow.Index).Value
            txt_nro_comp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value
            If obj.VERIFICAR_TRANSF_PRODUCCION(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Producción", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim ESTADO As String = "FALLO"
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_DIARIO", con)
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
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim I As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        FILA_DOC = dgw_mov1.CurrentRow.Index
        LIMPIAR_DOCUMENTO()
        CARGAR_DOCUMENTO(FILA_DOC)
        '------------------------------------------
        Dim DH As String = ""
        If ESTADO_PER = "P" Then
            DH = obj.COD_D_H(COD_DOC)
            If DH = "D" Then
                DH = "H"
            Else
                DH = "D"
            End If
        ElseIf ESTADO_PER = "C" Then
            DH = obj.COD_D_H(COD_DOC)
        End If
        '------------------------------------------
        If (MES <> "00" And MES <> "13") And DH = cbo_d_h.Text And (ESTADO_PER = "C") And (txt_cod_per0.Text.Trim <> "") And (obj.VERIFICAR_ELIMINAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) And (BOTON <> "NUEVO") Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MES <> "00" And MES <> "13") And DH = cbo_d_h.Text And (ESTADO_PER = "P") And (txt_cod_per0.Text.Trim <> "") And (obj.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) And (BOTON <> "NUEVO") Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el detalle", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            dgw_mov1.Rows.RemoveAt(dgw_mov1.CurrentRow.Index)
            HALLAR_TOTAL()
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
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_NUEVO_DOC.Focus()
        ElseIf (txt_debe.Text <> txt_haber.Text) Then
            MessageBox.Show("El debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If -0.5 < txt_debe2.Text - txt_haber2.Text And txt_debe2.Text - txt_haber2.Text < 0.5 Then
            Else
                MessageBox.Show("El Saldo de dólares es + - 0.5.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            '--------------------------------------------------------
            'If (ESTADO_AUTO <> "SI") Then
            '    GENERAR_AUTO()
            'End If
            'ESTADO_AUTO = "SI"

            txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)

            If (INSERTAR_TODO() = "EXITO") Then
                txt_nro_comp.Text = obj.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
                'ELIMINAR_AUTO()
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                btn_grabar_com.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
                Panel_doc2.Enabled = False
            Else
                obj.ELIMINAR_TEMPORAL("TCON")
                'ELIMINAR_AUTO()
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
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf (dgw_mov1.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_NUEVO_DOC.Focus()
        ElseIf (txt_debe.Text <> txt_haber.Text) Then
            MessageBox.Show("El debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If -0.5 < txt_debe2.Text - txt_haber2.Text And txt_debe2.Text - txt_haber2.Text < 0.5 Then
            Else
                MessageBox.Show("El Saldo de dólares es + - 0.5.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '--------------------------------------------------------
            If (ESTADO_AUTO <> "SI") Then
                GENERAR_AUTO()
            End If
            ESTADO_AUTO = "SI"
            If (MODIFICAR_TODO() = "EXITO") Then
                ELIMINAR_AUTO()
                MessageBox.Show("El Comprobante se actualizó con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                btn_grabar_com2.Enabled = False
                btn_nuevo_comp.Enabled = True
                btn_imprimir.Enabled = True
                btn_imprimir.Focus()
                Panel_doc2.Enabled = False
            Else
                obj.ELIMINAR_TEMPORAL("TCON")
                ELIMINAR_AUTO()
                MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        'If CH_CTACTE.Checked = True Then ESTADO_PER = "N"
        If Not CH_CTACTE.Checked = True Then ESTADO_PER = "N"
        'If CH_NUEVO.Checked = True Then ESTADO_PRECIO = "1"
        ESTADO_PRECIO = IIf(CH_CTACTE.Checked, 1, 0)
        If ((Strings.Trim(txt_cod_cta0.Text) = "") Or dgw_cta.Visible) Then
            MessageBox.Show("Debe elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
            'ElseIf ((cbo_tipo_doc0.SelectedIndex = -1) And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
            '    MessageBox.Show("Debe de elegir el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    cbo_tipo_doc0.Focus()
            'ElseIf ((txt_nro_doc0.Text.Trim = "") And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
            '    MessageBox.Show("Debe ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_nro_doc0.Focus()
        ElseIf (dtp_doc0.Value.Date > FECHA_GRAL.Date) Then
            MessageBox.Show("La fecha elegida es mayor a la fecha de proces", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_doc0.Focus()
        ElseIf (cbo_moneda1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda1.Focus()
        ElseIf (Decimal.Parse(txt_imp_soles0.Text) = 0) Then
            MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_imp_soles0.Focus()
            'ElseIf (Strings.Trim(txt_cod_per0.Text) = "") And ((ESTADO_PER = "P") Or (ESTADO_PER = "C")) And (MES <> "00" And MES <> "13") Then
            '    MessageBox.Show("Debe de elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_cod_per0.Focus()
        ElseIf (Strings.Trim(txt_glosa0.Text) = "") Then
            MessageBox.Show("Debe ingresar una glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_glosa0.Focus()
            'ElseIf (((ESTADO_PER = "P") Or (ESTADO_PER = "C")) And VERIFICAR_DGW(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) Then
            '    MessageBox.Show("Documento ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_cambio0.Text) = 0) Then
            MessageBox.Show("Debe ingresar un Tipo de Cambio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio0.Focus()
            'ElseIf CBO_CC.SelectedIndex = -1 And CBO_CC.Enabled = True Then
            '    MessageBox.Show("Debe elegir el Centro de Costos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    CBO_CC.Focus()
        Else
            Dim st_rep As String = "0"
            If ch_rep.Checked = True Then st_rep = "1"
            '-----------------------------------------
            Dim DH As String = ""
            If ESTADO_PER = "P" Then
                DH = obj.COD_D_H(COD_DOC)
                If DH = "D" Then
                    DH = "H"
                Else
                    DH = "D"
                End If
            ElseIf ESTADO_PER = "C" Then
                DH = obj.COD_D_H(COD_DOC)
            End If
            COD_ACT = ""
            If (cbo_act01.SelectedIndex <> -1) Then
                COD_ACT = cbo_act01.SelectedValue.ToString
            End If
            '-----------------------------------------
            'If (MES <> "00" And MES <> "13") And (txt_cod_per0.Text.Trim <> "") Then
            '    If (ESTADO_PER = "P") And DH = cbo_d_h.Text And obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False Then
            '        MessageBox.Show("El Documento  ya existe de Cuentas por Pagar.", "No se puede guardar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    ElseIf (ESTADO_PER = "C") And DH = cbo_d_h.Text And (obj.VERIFICAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) Then
            '        MessageBox.Show("El Documento  ya existe de Cuentas por Cobrar.", "No se puede guardar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            If (cbo_tipo_doc0.SelectedIndex = -1) Then
                COD_DOC = ""
            End If
            COD_CONTROL = txt_nro_req.Text
            COD_PROYECTO = ""
            COD_REF = ""
            COD_CC = ""
            If CBO_CC.SelectedIndex <> -1 Then
                COD_CC = obj.COD_CC(CBO_CC.Text)
            End If
            If cbo_proyecto0.SelectedIndex <> -1 Then
                COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto0.Text)
            End If
            If cbo_tipo_ref0.SelectedIndex <> -1 Then
                COD_REF = obj.COD_DOC(cbo_tipo_ref0.Text)
            End If
            If COD_MONEDA = "S" Then
                SOLES = Decimal.Parse(txt_imp_soles0.Text)
                DOLARES = New Decimal(Math.Round(CDbl((Decimal.Parse(txt_imp_soles0.Text) / Decimal.Parse(txt_cambio0.Text))), 2))
            Else
                SOLES = New Decimal(Math.Round(CDbl((Decimal.Parse(txt_imp_soles0.Text) * Decimal.Parse(txt_cambio0.Text))), 2))
                DOLARES = Decimal.Parse(txt_imp_soles0.Text)
            End If
            If COD_MONEDA = "A" Then
                SOLES = txt_imp_soles0.Text
                DOLARES = "0.00"
            End If

            ENLACE = ""
            DESTINO = ""
            DESTINO = Strings.Mid((cbo_auto.SelectedItem), 1, 8)
            ENLACE = Strings.Mid((cbo_auto.SelectedItem), 24, 31)
            If txt_cod_per0.Text.Trim <> "" Then
                dgw_mov1.Rows.Add(txt_cod_cta0.Text, txt_glosa0.Text, SOLES, DOLARES, cbo_d_h.Text, COD_MONEDA, txt_cambio0.Text, COD_DOC, txt_nro_doc0.Text, dtp_doc0.Value, txt_cod_per0.Text, txt_desc_per0.Text, txt_nro_doc_per0.Text, COD_REF, txt_nro_ref0.Text, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, ESTADO_PER, "0", ENLACE, DESTINO, st_rep, COD_ACT, dtp_vence.Value, ESTADO_PRECIO, "", "", 1)
            Else
                dgw_mov1.Rows.Add(txt_cod_cta0.Text, txt_glosa0.Text, SOLES, DOLARES, cbo_d_h.Text, COD_MONEDA, txt_cambio0.Text, COD_DOC, txt_nro_doc0.Text, dtp_doc0.Value, txt_cod_per0.Text, txt_desc_per0.Text, txt_nro_doc_per0.Text, COD_REF, txt_nro_ref0.Text, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, ESTADO_PER, "0", ENLACE, DESTINO, st_rep, COD_ACT, dtp_doc0.Value, ESTADO_PRECIO, "", "", 1)
            End If
            HALLAR_TOTAL()
            LIMPIAR_DOCUMENTO()
            If txt_cod_per0.Text.Trim = "" Or txt_cod_per0.Enabled = False Then
                txt_glosa0.Clear()
            End If
            txt_cod_cta0.Focus()
        End If

    End Sub

    Private Sub btn_mod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod.Click
        Try
            Dim I As Integer = dgw_mov1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        'ST_TRANS = "0"
        FILA_DOC = dgw_mov1.CurrentRow.Index
        MODIFICA = True
        '------------------------------------------
        If dgw_mov1.Item(31, FILA_DOC).Value <> 1 Then
            If obj.VERIFICAR_TRANSF_ANALISIS_DETALLE(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES, dgw_mov1.Item(29, FILA_DOC).Value) = False Then
                MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        '------------------------------------------
        LIMPIAR_DOCUMENTO()
        CARGAR_DOCUMENTO(FILA_DOC)
        '------------------------------------------
        Dim DH As String = ""
        If ESTADO_PER = "P" Then
            DH = obj.COD_D_H(COD_DOC)
            If DH = "D" Then
                DH = "H"
            Else
                DH = "D"
            End If
        ElseIf ESTADO_PER = "C" Then
            DH = obj.COD_D_H(COD_DOC)
        End If
        '------------------------------------------
        If (MES <> "00" And MES <> "13") And DH = cbo_d_h.Text And (ESTADO_PER = "C") And (txt_cod_per0.Text.Trim <> "") And (obj.VERIFICAR_ELIMINAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) And (BOTON <> "NUEVO") Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If (MES <> "00" And MES <> "13") And DH = cbo_d_h.Text And (ESTADO_PER = "P") And (txt_cod_per0.Text.Trim <> "") And (obj.VERIFICAR_ELIMINAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) And (BOTON <> "NUEVO") Then
            MessageBox.Show("El Documento se encuentra cancelado", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim CUENTA0 As String = VALIDAR_TRASNF_CUENTA(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text)
        If ((CUENTA0 <> "") And (BOTON <> "NUEVO")) Then
            MessageBox.Show(("No se puede modificar el Documento la Cuenta " & CUENTA0 & " se encuentra Transferida."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            btn_guardar.Visible = False
            btn_modificar2.Visible = True
            txt_cod_cta0.Enabled = False
            txt_desc_cta0.Enabled = False
            Panel_DOC.Visible = True
            If cbo_tipo_doc0.Enabled Then
                cbo_tipo_doc0.Focus()
            Else
                dtp_doc0.Focus()
            End If
        End If
        If txt_cod_per0.Text = "" Then TXT_DIA1.Enabled = False Else TXT_DIA1.Enabled = True
        BOTON_DETALLE = ""
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
        If obj.VERIFICAR_TRANSF_PRODUCCION(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            MessageBox.Show("Los detalles se han transferido a Producción", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
        '    MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        ValidarFicha = False
        btn_grabar_com.Visible = False
        btn_grabar_com2.Visible = True
        g_cab.Enabled = False
        btn_grabar_com2.Enabled = True
        btn_imprimir.Enabled = False
        TabControl1.SelectedTab = TabPage2
        HALLAR_TOTAL()
        BTN_NUEVO_DOC.Focus()
        Panel_doc2.Enabled = True
        ValidarFicha = True
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        'If CH_CTACTE.Checked = True Then ESTADO_PER = "N"
        If Not CH_CTACTE.Checked = True Then ESTADO_PER = "N"
        ESTADO_PRECIO = IIf(CH_CTACTE.Checked, 1, 0)
        'If CH_NUEVO.Checked = True Then ESTADO_PRECIO = "1"
        If ((Strings.Trim(txt_cod_cta0.Text) = "") Or dgw_cta.Visible) Then
            MessageBox.Show("Debe de elegir la Cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
        ElseIf ((cbo_tipo_doc0.SelectedIndex = -1) And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
            MessageBox.Show("Debe de elegir el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_doc0.Focus()
        ElseIf ((txt_nro_doc0.Text.Trim = "") And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
            MessageBox.Show("Debe de ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_doc0.Focus()
        ElseIf (dtp_doc0.Value.Date > FECHA_GRAL.Date) Then
            MessageBox.Show("La fecha elegida es mayor a la fecha de proces", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_doc0.Focus()
        ElseIf (cbo_moneda1.SelectedIndex = -1) Then
            MessageBox.Show("Debe de elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda1.Focus()
        ElseIf (Decimal.Parse(txt_imp_soles0.Text) = 0) Then
            MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_imp_soles0.Focus()
        ElseIf (MES <> "00" And MES <> "13") And ((Strings.Trim(txt_cod_per0.Text) = "") And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
            MessageBox.Show("Debe de elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per0.Focus()
        ElseIf (Strings.Trim(txt_glosa0.Text) = "") Then
            MessageBox.Show("Debe ingresar una glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_glosa0.Focus()
            'ElseIf VERIFICAR_DGW(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False Then
            '    MessageBox.Show("Documento ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(txt_cambio0.Text) = 0) Then
            MessageBox.Show("Debe ingresar un Tipo de Cambio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio0.Focus()
        ElseIf CBO_CC.SelectedIndex = -1 And CBO_CC.Enabled = True Then
            MessageBox.Show("Debe elegir el Centro de Costos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_CC.Focus()
        Else
            Dim st_rep As String = "0"
            If ch_rep.Checked = True Then st_rep = "1"
            Dim DOLARES As Decimal
            Dim SOLES As Decimal
            COD_CONTROL = txt_nro_req.Text
            COD_PROYECTO = ""
            COD_REF = ""
            COD_CC = ""
            If (cbo_tipo_doc0.SelectedIndex = -1) Then
                COD_DOC = ""
            End If
            'If (cbo_control0.SelectedIndex <> -1) Then
            '    COD_CONTROL = obj.COD_CONTROL(cbo_control0.Text)
            'End If
            If (CBO_CC.SelectedIndex <> -1) Then
                COD_CC = obj.COD_CC(CBO_CC.Text)
            End If
            If (cbo_proyecto0.SelectedIndex <> -1) Then
                COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto0.Text)
            End If
            If (cbo_tipo_ref0.SelectedIndex <> -1) Then
                COD_REF = obj.COD_DOC(cbo_tipo_ref0.Text)
            End If
            If (COD_MONEDA = "S") Then
                SOLES = Decimal.Parse(txt_imp_soles0.Text)
                DOLARES = New Decimal(Math.Round(CDbl((Decimal.Parse(txt_imp_soles0.Text) / Decimal.Parse(txt_cambio0.Text))), 2))
            Else
                SOLES = New Decimal(Math.Round(CDbl((Decimal.Parse(txt_imp_soles0.Text) * Decimal.Parse(txt_cambio0.Text))), 2))
                DOLARES = Decimal.Parse(txt_imp_soles0.Text)
            End If
            If COD_MONEDA = "A" Then
                SOLES = txt_imp_soles0.Text
                DOLARES = "0.00"
            End If
            COD_ACT = ""
            If (cbo_act01.SelectedIndex <> -1) Then
                COD_ACT = cbo_act01.SelectedValue.ToString
            End If
            ENLACE = ""
            DESTINO = ""
            DESTINO = Strings.Mid((cbo_auto.SelectedItem), 1, 8)
            ENLACE = Strings.Mid((cbo_auto.SelectedItem), 24, 31)
            dgw_mov1.Item(1, FILA_DOC).Value = txt_glosa0.Text
            dgw_mov1.Item(2, FILA_DOC).Value = SOLES
            dgw_mov1.Item(3, FILA_DOC).Value = DOLARES
            dgw_mov1.Item(4, FILA_DOC).Value = cbo_d_h.Text
            dgw_mov1.Item(5, FILA_DOC).Value = COD_MONEDA
            dgw_mov1.Item(6, FILA_DOC).Value = txt_cambio0.Text
            dgw_mov1.Item(7, FILA_DOC).Value = COD_DOC
            dgw_mov1.Item(8, FILA_DOC).Value = txt_nro_doc0.Text
            dgw_mov1.Item(9, FILA_DOC).Value = dtp_doc0.Value
            dgw_mov1.Item(13, FILA_DOC).Value = COD_REF
            dgw_mov1.Item(14, FILA_DOC).Value = txt_nro_ref0.Text
            dgw_mov1.Item(15, FILA_DOC).Value = COD_CC
            dgw_mov1.Item(16, FILA_DOC).Value = COD_CONTROL
            dgw_mov1.Item(17, FILA_DOC).Value = COD_PROYECTO
            dgw_mov1.Item(18, FILA_DOC).Value = STATUS_CC
            dgw_mov1.Item(19, FILA_DOC).Value = "1"
            dgw_mov1.Item(20, FILA_DOC).Value = STATUS_P
            dgw_mov1.Item(21, FILA_DOC).Value = ESTADO_PER
            dgw_mov1.Item(23, FILA_DOC).Value = ENLACE
            dgw_mov1.Item(24, FILA_DOC).Value = DESTINO
            dgw_mov1.Item(25, FILA_DOC).Value = st_rep
            dgw_mov1.Item(26, FILA_DOC).Value = COD_ACT
            dgw_mov1.Item(27, FILA_DOC).Value = dtp_vence.Value
            dgw_mov1.Item(28, FILA_DOC).Value = ESTADO_PRECIO

            'dgw_mov1.Item(30, FILA_DOC).Value = ST_TRANS
            LIMPIAR_DOCUMENTO()
            HALLAR_TOTAL()
            txt_cod_cta0.Focus()
        End If
        If MODIFICA Then Panel_DOC.Visible = False : MODIFICA = False
    End Sub

    Private Sub btn_nuevo_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click, btn_nuevo_comp.Click
        'If MES = "00" Or MES = "13" Then
        '    'Panel1.Visible = True
        'Else
        '    'Panel1.Visible = False
        'End If
        cbo_mes.Enabled = False
        BOTON = "NUEVO"
        ValidarFicha = False
        TabControl1.SelectedTab = TabPage2
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
        Panel_doc2.Enabled = True
        ValidarFicha = True
    End Sub

    Private Sub BTN_NUEVO_DOC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_NUEVO_DOC.Click
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
            If dgw_mov1.Rows.Count <> 0 Then
                txt_cambio0.Text = dgw_mov1.Item(6, 0).Value '0
                txt_glosa0.Text = dgw_mov1.Item(1, 0).Value '0
            End If
            g_cab.Enabled = False
            LIMPIAR_DOCUMENTO()
            dtp_doc0.Value = dtp_com.Value
            Panel_DOC.Visible = True
            txt_cod_cta0.Focus()
            End If
            BOTON_DETALLE = "NUEVO"
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(13) = 0
        Close()
    End Sub

    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        Dim CONT As Integer = (dgw_cta.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw_cta.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_desc_cta0.Text.ToLower = Strings.Mid(dgw_cta.Item(1, i).Value.ToString, f, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(1)
                    fila2 = (i + 1)
                    dgw_cta.Focus()
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        dgw_cta.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Panel_DOC.Visible = False
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
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_DIARIO", con)
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
                dgw_mov1.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19), rs2.GetValue(20), rs2.GetValue(21), rs2.GetValue(22), rs2.GetValue(23), rs2.GetValue(24), rs2.GetValue(25), rs2.GetValue(26), rs2.GetValue(27), rs2.GetValue(28), rs2.GetValue(29), rs2.GetValue(30))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Sub CARGAR_CUENTAS()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_STATUS(AÑO)
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(4).Visible = False
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGAR_DOCUMENTO(ByVal FILA_DOC0 As Integer)
        txt_cod_cta0.Text = (dgw_mov1.Item(0, FILA_DOC0).Value)
        txt_desc_cta0.Text = obj.DESC_CUENTA(txt_cod_cta0.Text, AÑO)
        CBO_AUTOMATICAS(txt_cod_cta0.Text)
        cbo_auto.Text = (String.Concat(String.Concat(dgw_mov1.Item(24, FILA_DOC0).Value, "               "), dgw_mov1.Item(23, FILA_DOC0).Value))
        txt_glosa0.Text = (dgw_mov1.Item(1, FILA_DOC0).Value)
        Dim SOLES As Decimal = Decimal.Parse(dgw_mov1.Item(2, FILA_DOC0).Value)
        Dim DOLARES As Decimal = Decimal.Parse(dgw_mov1.Item(3, FILA_DOC0).Value)
        COD_MONEDA = (dgw_mov1.Item(5, FILA_DOC0).Value)
        Dim TC0 As Decimal = Decimal.Parse(dgw_mov1.Item(6, FILA_DOC0).Value)
        COD_DOC = (dgw_mov1.Item(7, FILA_DOC0).Value)
        ESTADO_PER = (dgw_mov1.Item(21, FILA_DOC0).Value)
        txt_nro_doc0.Text = (dgw_mov1.Item(8, FILA_DOC0).Value)
        txt_cod_per0.Text = (dgw_mov1.Item(10, FILA_DOC0).Value)
        txt_desc_per0.Text = (dgw_mov1.Item(11, FILA_DOC0).Value)
        txt_nro_doc_per0.Text = (dgw_mov1.Item(12, FILA_DOC0).Value)
        COD_REF = (dgw_mov1.Item(13, FILA_DOC0).Value)
        txt_nro_ref0.Text = (dgw_mov1.Item(14, FILA_DOC0).Value)
        cbo_tipo_doc0.Text = obj.DESC_DOC(COD_DOC)
        cbo_tipo_ref0.Text = obj.DESC_DOC(COD_REF)
        COD_DH_DOC = (dgw_mov1.Item(4, FILA_DOC0).Value)
        cbo_d_h.Text = COD_DH_DOC
        'cbo_d_h.Text = (dgw_mov1.Item(4, FILA_DOC0).Value)

        ch_rep.Checked = False
        Dim sss As String
        sss = dgw_mov1.Item(25, FILA_DOC0).Value
        If sss = "1" Then ch_rep.Checked = True Else ch_rep.Checked = False
        cbo_moneda1.Text = obj.DESC_MONEDA(COD_MONEDA)
        If (COD_MONEDA = "S") Then
            txt_imp_soles0.Text = (SOLES)
        Else
            txt_imp_soles0.Text = (DOLARES)
        End If
        If (COD_MONEDA = "A") Then txt_imp_soles0.Text = (SOLES)
        txt_cambio0.Text = (TC0)
        STATUS_CC = (dgw_mov1.Item(18, FILA_DOC0).Value)
        STATUS_P = (dgw_mov1.Item(20, FILA_DOC0).Value)
        If (STATUS_CC = "1") Then
            CBO_CC.Enabled = True
            COD_CC = (dgw_mov1.Item(15, FILA_DOC0).Value)
            CBO_CC.Text = obj.DESC_CC(COD_CC)
        End If
        COD_CONTROL = dgw_mov1.Item(16, FILA_DOC0).Value.ToString
        txt_nro_req.Text = COD_CONTROL
        If (STATUS_P = "1") Then
            cbo_proyecto0.Enabled = True
            COD_PROYECTO = (dgw_mov1.Item(17, FILA_DOC0).Value)
            cbo_proyecto0.Text = obj.DESC_PROYECTO(COD_PROYECTO)
        End If
        COD_ACT = dgw_mov1.Item(26, FILA_DOC0).Value
        If COD_ACT <> "" Then
            cbo_act01.SelectedValue = COD_ACT
        Else
            cbo_act01.SelectedIndex = -1
        End If
        ESTADO_PRECIO = (dgw_mov1.Item(28, FILA_DOC0).Value)
        If ESTADO_PRECIO = "1" Then CH_CTACTE.Checked = True Else CH_CTACTE.Checked = False
        'If ESTADO_PER = "N" Then CH_CTACTE.Checked = True
        If ((ESTADO_PER = "C") Or (ESTADO_PER = "P") Or (ESTADO_PER = "N")) Then
            'cbo_tipo_doc0.Enabled = False
            'txt_nro_doc0.Enabled = False
            txt_cod_per0.Enabled = False
            txt_desc_per0.Enabled = False
            txt_nro_doc_per0.Enabled = False
        End If

        cbo_tipo_doc0.Enabled = Not CH_CTACTE.Checked
        txt_nro_doc0.Enabled = Not CH_CTACTE.Checked

        kl2.Enabled = False
        '---------------------
        dtp_doc0.Value = DateTime.Parse(dgw_mov1.Item(9, FILA_DOC0).Value)
        dtp_vence.Value = (dgw_mov1.Item(27, FILA_DOC0).Value)
        Try
            'Dim A1 As Integer = dtp_doc0.Value
            'Dim A2 As Integer = dtp_vence.Value
            TXT_DIA1.Text = CInt((dtp_vence.Value - dtp_doc0.Value).Days)
            '(CInt((A2 - A1)))
        Catch ex As Exception
            TXT_DIA1.Text = (0)
        End Try

        'ModificarControl()
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

    Sub CBO_AUXILIAR()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX_DIA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@MES", SqlDbType.Char).Value = MES
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
        End If
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        If ((cbo_aux.SelectedIndex <> -1) And (cbo_com.SelectedIndex <> -1)) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            COD_COMP = obj.COD_COMP(cbo_com.Text, COD_AUX)
            Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeración para este Comprobante", "Advertencia")
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

    Public Sub CBO_CONTROL00()
        'Try
        '    Dim PROG_01 As New SqlCommand("CBO_CONTROL_FECHA", con)
        '    PROG_01.CommandType = CommandType.StoredProcedure
        '    PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA_GRAL
        '    con.Open()
        '    PROG_01.ExecuteNonQuery()
        '    Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
        '    Do While Rs3.Read
        '        cbo_control0.Items.Add(Rs3.GetString(0))
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
                cbo_tipo_doc0.Items.Add(Rs3.GetString(0))
                cbo_tipo_ref0.Items.Add(Rs3.GetString(0))
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
            If ((COD_MONEDA = "A") Or (COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio0.Text = obj.SACAR_CAMBIO2(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), dtp_doc0.Value.ToString("dd"), "D")
            Else
                txt_cambio0.Text = obj.SACAR_CAMBIO2(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), dtp_doc0.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
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
                cbo_proyecto0.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbo_tipo_doc0_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_tipo_doc0.SelectedIndexChanged
        If (cbo_tipo_doc0.SelectedIndex <> -1) Then
            COD_DOC = obj.COD_DOC(cbo_tipo_doc0.Text)
            COD_DH_DOC = obj.COD_D_H(COD_DOC)
            If (ESTADO_PER = "P") Then
                If (COD_DH_DOC = "D") Then
                    COD_DH_DOC = "H"
                Else
                    COD_DH_DOC = "D"
                End If
                'cbo_d_h.Enabled = False
            End If
            cbo_d_h.Text = COD_DH_DOC
            ModificarControl()
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
            Dim pro_02 As New SqlCommand("MOSTRAR_ICON_DIARIO", con)
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
            dgw1.Columns.Item(3).Width = 250
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DGW_CC00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.MOSTRAR_CC()
        CBO_CC.DataSource = DT
        CBO_CC.DisplayMember = DT.Columns.Item(0).ToString
        CBO_CC.ValueMember = DT.Columns.Item(1).ToString
        CBO_CC.SelectedIndex = -1
    End Sub

    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            STATUS_CC = dgw_cta.Item(2, dgw_cta.CurrentRow.Index).Value.ToString
            STATUS_P = dgw_cta.Item(3, dgw_cta.CurrentRow.Index).Value.ToString
            ESTADO_PER = dgw_cta.Item(4, dgw_cta.CurrentRow.Index).Value.ToString
            ModificarControl()
            '---------------------------------------------------
            If (cbo_tipo_doc0.SelectedIndex <> -1) Then
                COD_DOC = obj.COD_DOC(cbo_tipo_doc0.Text)
                COD_DH_DOC = obj.COD_D_H(COD_DOC)
                If (ESTADO_PER = "P") Then
                    If (COD_DH_DOC = "D") Then
                        COD_DH_DOC = "H"
                    Else
                        COD_DH_DOC = "D"
                    End If
                    'cbo_d_h.Enabled = False
                End If
                cbo_d_h.Text = COD_DH_DOC
            End If
            '---------------------------------------------------
            If (STATUS_CC = "1") Then
                CBO_CC.Enabled = True
            End If
            If (STATUS_P = "1") Then
                cbo_proyecto0.Enabled = True
            End If
            CBO_AUTOMATICAS(txt_cod_cta0.Text)
            cbo_d_h.Enabled = True
            If ((ESTADO_PER = "C") Or (ESTADO_PER = "P")) And (MES <> "00" And MES <> "13") Then
                'cbo_d_h.Enabled = False
                txt_cod_per0.Enabled = True
                txt_desc_per0.Enabled = True
                txt_nro_doc_per0.Enabled = True
                TXT_DIA1.Enabled = True
                kl2.Enabled = True
            Else
                txt_cod_per0.Clear()
                txt_desc_per0.Clear()
                txt_nro_doc_per0.Clear()
                txt_cod_per0.Enabled = False
                txt_desc_per0.Enabled = False
                txt_nro_doc_per0.Enabled = False
                TXT_DIA1.Enabled = False
                kl2.Enabled = False
            End If
            Panel_cuenta.Visible = False
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            Panel_cuenta.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

    Private Sub dgw_per_cobrar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per_cobrar.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = (dgw_per_cobrar.Item(0, dgw_per_cobrar.CurrentRow.Index).Value)
            txt_desc_per0.Text = (dgw_per_cobrar.Item(1, dgw_per_cobrar.CurrentRow.Index).Value)
            txt_nro_doc_per0.Text = (dgw_per_cobrar.Item(2, dgw_per_cobrar.CurrentRow.Index).Value)
            txt_glosa0.Text = txt_desc_per0.Text
            Panel_CXC.Visible = False
            kl2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per0.Clear()
            txt_desc_per0.Clear()
            txt_nro_doc_per0.Clear()
            Panel_CXC.Visible = False
            txt_cod_per0.Focus()
        End If
    End Sub

    Private Sub dgw_per_pagar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per_pagar.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per0.Text = (dgw_per_pagar.Item(0, dgw_per_pagar.CurrentRow.Index).Value)
            txt_desc_per0.Text = (dgw_per_pagar.Item(1, dgw_per_pagar.CurrentRow.Index).Value)
            txt_nro_doc_per0.Text = (dgw_per_pagar.Item(2, dgw_per_pagar.CurrentRow.Index).Value)
            Panel_CXP.Visible = False
            kl2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per0.Clear()
            txt_desc_per0.Clear()
            txt_nro_doc_per0.Clear()
            Panel_CXP.Visible = False
            txt_cod_per0.Focus()
        End If
    End Sub

    Sub DGW_PERSONAS()
        Try
            dgw_per_pagar.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per_pagar.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per_pagar.Columns.Item(0).Width = 50
            dgw_per_pagar.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Try
            dgw_per_cobrar.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            dgw_per_cobrar.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per_cobrar.Columns.Item(0).Width = 50
            dgw_per_cobrar.Columns.Item(1).Width = &HEB
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Ocurrio un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub dtp_doc0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles dtp_doc0.LostFocus
        If (cbo_moneda1.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda1.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio0.Text = SACAR_CAMBIO_MENSUAL(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), "D", "V")
            Else
                txt_cambio0.Text = SACAR_CAMBIO_MENSUAL(dtp_doc0.Value.Year, dtp_doc0.Value.ToString("MM"), "D", "V")
            End If
        End If
        '--------------
    End Sub
    Private Function SACAR_CAMBIO_MENSUAL(ByVal AÑO00 As Object, ByVal MES00 As Object, ByVal TIPO00 As Object, ByVal CV00 As String) As String
        If MES00 = "12" Or MES00 = "13" Then MES00 = "12"
        Dim cambio As String = ""
        Try
            Dim prog As New SqlCommand("SACAR_CAMBIO_MENSUAL", con2)
            prog.CommandType = CommandType.StoredProcedure
            prog.Parameters.Add("@año", SqlDbType.VarChar).Value = (AÑO00)
            prog.Parameters.Add("@mes", SqlDbType.VarChar).Value = (MES00)
            prog.Parameters.Add("@tipo", SqlDbType.VarChar).Value = (TIPO00)
            prog.Parameters.Add("@C_V", SqlDbType.VarChar).Value = (CV00)
            con2.Open()
            cambio = prog.ExecuteScalar
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        Return cambio
    End Function
    Sub ELIMINAR_AUTO()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Do While (I <= CONT)
            If dgw_mov1.Item(22, I).Value = "1" Then
                dgw_mov1.Rows.RemoveAt(I)
                I = 0
                CONT = (dgw_mov1.RowCount - 1)
            Else
                I += 1
            End If
        Loop
    End Sub

    Sub GENERAR_AUTO()
        Dim cont_r1 As Integer = dgw_mov1.RowCount
        Dim CONT As Integer = (cont_r1 - 1)
        Dim j As Integer = 0
        Do While (j <= CONT)
            Dim var0 As String = (dgw_mov1.Item(0, j).Value)
            Dim var1 As String = (dgw_mov1.Item(1, j).Value)
            Dim var2 As Decimal = Decimal.Parse(dgw_mov1.Item(2, j).Value)
            Dim var3 As Decimal = Decimal.Parse(dgw_mov1.Item(3, j).Value)
            Dim var4 As String = (dgw_mov1.Item(4, j).Value)
            Dim var5 As String = (dgw_mov1.Item(5, j).Value)
            Dim var6 As Decimal = Decimal.Parse(dgw_mov1.Item(6, j).Value)
            Dim var7 As String = (dgw_mov1.Item(7, j).Value)
            Dim var8 As String = (dgw_mov1.Item(8, j).Value)
            Dim var9 As String = (dgw_mov1.Item(9, j).Value)
            Dim var10 As String = (dgw_mov1.Item(10, j).Value)
            Dim var11 As String = (dgw_mov1.Item(11, j).Value)
            Dim var12 As String = (dgw_mov1.Item(12, j).Value)
            Dim var13 As String = (dgw_mov1.Item(13, j).Value)
            Dim var14 As String = (dgw_mov1.Item(14, j).Value)
            Dim var23 As String = (dgw_mov1.Item(23, j).Value)
            Dim var24 As String = (dgw_mov1.Item(24, j).Value)
            Dim var27 As String = (dgw_mov1.Item(27, j).Value)
            If (var23.Length = 8) Then
                Dim cod_enlace As String = ""
                Dim cod_destino As String = ""
                If (var4 = "D") Then
                    cod_enlace = "H"
                    cod_destino = "D"
                ElseIf (var4 = "H") Then
                    cod_enlace = "D"
                    cod_destino = "H"
                End If
                dgw_mov1.Rows.Add(var23, var1, var2, var3, cod_enlace, var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, "", "", "", "", "", "", "", "1", "", "", "", "", var27, "")
                dgw_mov1.Rows.Add(var24, var1, var2, var3, cod_destino, var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, "", "", "", "", "", "", "", "1", "", "", "", "", var27, "")
            End If
            j += 1
        Loop
    End Sub

    Sub HALLAR_TOTAL()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.Rows.Count - 1)
        Dim debe As New Decimal
        Dim haber As New Decimal
        Dim debe2 As New Decimal
        Dim haber2 As New Decimal
        I = 0
        Do While (I <= CONT)
            If dgw_mov1.Item(4, I).Value = "D" Then
                debe = Decimal.Parse(Decimal.Add(debe, dgw_mov1.Item(2, I).Value))
                debe2 = Decimal.Parse(Decimal.Add(debe2, dgw_mov1.Item(3, I).Value))
            Else
                haber = Decimal.Parse(Decimal.Add(haber, dgw_mov1.Item(2, I).Value))
                haber2 = Decimal.Parse(Decimal.Add(haber2, dgw_mov1.Item(3, I).Value))
            End If
            I += 1
        Loop
        txt_debe.Text = debe
        txt_haber.Text = haber
        txt_debe2.Text = debe2
        txt_haber2.Text = haber2
        txt_debe.Text = (obj.HACER_DECIMAL(txt_debe.Text))
        txt_haber.Text = (obj.HACER_DECIMAL(txt_haber.Text))
        txt_debe2.Text = (obj.HACER_DECIMAL(txt_debe2.Text))
        txt_haber2.Text = (obj.HACER_DECIMAL(txt_haber2.Text))
    End Sub

    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            'If txt_cod_per0.Text.Trim <> "" Or txt_cod_per0.Text.Trim <> " " Then
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value, _
            dgw_mov1.Item(8, I).Value, dgw_mov1.Item(10, I).Value, dgw_mov1.Item(12, I).Value, _
            (I + 1).ToString("0000"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), "", "", _
            DateTime.Parse(dgw_mov1.Item(9, I).Value), dgw_mov1.Item(1, I).Value, dgw_mov1.Item(0, I).Value, _
            Decimal.Parse(Math.Round(dgw_mov1.Item(2, I).Value, 2)), Decimal.Parse(Math.Round(dgw_mov1.Item(3, I).Value, 2)), _
            dgw_mov1.Item(4, I).Value, dgw_mov1.Item(5, I).Value, Decimal.Parse(dgw_mov1.Item(6, I).Value), _
            dgw_mov1.Item(15, I).Value, (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), "", _
            DateTime.Parse((dgw_mov1.Item(27, I).Value)), dgw_mov1.Item(28, I).Value.ToString, _
            dgw_mov1.Item(23, I).Value.ToString, dgw_mov1.Item(24, I).Value.ToString, _
            dgw_mov1.Item(22, I).Value.ToString, "", "0", "0", "", "", DateTime.Parse(dgw_mov1.Item(9, I).Value), _
            0, "", dgw_mov1.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, dgw_mov1.Item(25, I).Value, dgw_mov1.Item(26, I).Value)
            'Else
            'DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value, dgw_mov1.Item(8, I).Value, dgw_mov1.Item(10, I).Value, dgw_mov1.Item(12, I).Value, (I + 1).ToString("0000"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), "", "", DateTime.Parse(dgw_mov1.Item(9, I).Value), dgw_mov1.Item(1, I).Value, dgw_mov1.Item(0, I).Value, Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), dgw_mov1.Item(4, I).Value, dgw_mov1.Item(5, I).Value, Decimal.Parse(dgw_mov1.Item(6, I).Value), dgw_mov1.Item(15, I).Value, (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(28, I).Value.ToString, dgw_mov1.Item(23, I).Value.ToString, dgw_mov1.Item(24, I).Value.ToString, dgw_mov1.Item(22, I).Value.ToString, "", "0", "0", "", "", DateTime.Parse(dgw_mov1.Item(9, I).Value), 0, "", dgw_mov1.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, dgw_mov1.Item(25, I).Value, dgw_mov1.Item(26, I).Value)
            'End If
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
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_DIARIO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            con.Open()
            estado = (comand1.ExecuteScalar)
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
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        Dim DESC0 As String = cbo_com.Text.ToString
        cbo_com.SelectedIndex = -1
        cbo_com.Text = DESC0
        dtp_com.Value = FECHA_GRAL
        dgw_mov1.Rows.Clear()
        btn_imprimir.Enabled = False
        btn_grabar_com.Visible = True
        btn_grabar_com2.Visible = False
        btn_grabar_com.Enabled = True
        Panel_DOC.Visible = False
        Panel_doc2.Enabled = True
        txt_debe.Text = "0.00"
        txt_haber.Text = "0.00"
        txt_debe2.Text = "0.00"
        txt_haber2.Text = "0.00"
        ESTADO_AUTO = "NO"
        txt_glosa0.Clear()
        txt_nro_doc0.Clear()
        cbo_tipo_doc0.SelectedIndex = -1
    End Sub

    Sub LIMPIAR_DOCUMENTO()
        Dim GLOS As String = txt_glosa0.Text
        Dim ndoc As String = txt_nro_doc0.Text
        Dim cdoc As String = cbo_tipo_doc0.Text.ToString
        Dim CONT As IEnumerator
        Dim desc_mon As String = cbo_moneda1.Text.ToString
        Try
            CONT = g_doc.Controls.GetEnumerator
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
        txt_glosa0.Text = GLOS
        txt_nro_doc0.Text = ndoc
        cbo_tipo_doc0.Text = cdoc
        ch_rep.Checked = False
        '-----------------------
        cbo_moneda1.Text = desc_mon
        txt_cod_per0.Enabled = False
        txt_desc_per0.Enabled = False
        txt_nro_doc_per0.Enabled = False
        'If txt_cod_per0.Text.Trim = "" Or txt_cod_per0.Enabled = False Then
        '    txt_glosa0.Clear()
        'End If
        CBO_CC.Enabled = False
        cbo_proyecto0.Enabled = False
        ESTADO_PER = ""
        STATUS_CC = "0"
        STATUS_P = "0"
        Panel_CXC.Visible = False
        Panel_CXP.Visible = False
        dgw_cta.VirtualMode = False
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        COD_ACT = ""
        txt_nro_req.Clear()
        'CH_CTACTE.Checked = False
        CH_NUEVO.Checked = False
        txt_imp_soles0.Text = "0.00"
        '--------------------------------------
        TXT_DIA1.Text = (0)
        TXT_DIA1.Enabled = False
        'dtp_doc0.Value = Now.Date
        dtp_vence.Value = Now.Date
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

    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_mov1.RowCount - 1
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            'If txt_cod_per0.Text.Trim <> "" Then
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value, _
            dgw_mov1.Item(8, I).Value, (dgw_mov1.Item(10, I).Value), dgw_mov1.Item(12, I).Value, _
            (I + 1).ToString("0000"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(13, I).Value, _
            dgw_mov1.Item(14, I).Value, DateTime.Parse(dgw_mov1.Item(9, I).Value), dgw_mov1.Item(1, I).Value, _
            dgw_mov1.Item(0, I).Value, Decimal.Parse(dgw_mov1.Item(2, I).Value), Decimal.Parse(dgw_mov1.Item(3, I).Value), _
            dgw_mov1.Item(4, I).Value, dgw_mov1.Item(5, I).Value, Decimal.Parse(dgw_mov1.Item(6, I).Value), _
            dgw_mov1.Item(15, I).Value, dgw_mov1.Item(16, I).Value, dgw_mov1.Item(17, I).Value, "", _
            DateTime.Parse(dgw_mov1.Item(27, I).Value), dgw_mov1.Item(28, I).Value.ToString, dgw_mov1.Item(23, I).Value.ToString, _
            dgw_mov1.Item(24, I).Value.ToString, dgw_mov1.Item(22, I).Value.ToString, "", dgw_mov1.Item(30, I).Value, "0", "", "", _
            DateTime.Parse(dgw_mov1.Item(9, I).Value), 0, "", dgw_mov1.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, _
            dgw_mov1.Item(25, I).Value, dgw_mov1.Item(26, I).Value)
            'Else
            'DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value, dgw_mov1.Item(8, I).Value, (dgw_mov1.Item(10, I).Value), (dgw_mov1.Item(12, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), "", "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(0, I).Value), Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), Decimal.Parse((dgw_mov1.Item(6, I).Value)), (dgw_mov1.Item(15, I).Value), (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), dgw_mov1.Item(28, I).Value.ToString, dgw_mov1.Item(23, I).Value.ToString, dgw_mov1.Item(24, I).Value.ToString, dgw_mov1.Item(22, I).Value.ToString, "", dgw_mov1.Item(30, I).Value, "0", "", "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), 0, "", dgw_mov1.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, dgw_mov1.Item(25, I).Value, dgw_mov1.Item(26, I).Value)
            'End If
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
            Dim comand1 As New SqlCommand("MODIFICAR_I_CON_DIARIO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
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

    Private Sub txt_cambio0_KeyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cambio0.KeyPress
        e.Handled = Numero(e, txt_cambio0)
    End Sub

    Private Sub txt_cambio0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cambio0.LostFocus
        Try
            txt_cambio0.Text = obj.HACER_CAMBIO(txt_cambio0.Text)
        Catch ex As Exception
            txt_cambio0.Text = "0.0000"
        End Try
    End Sub

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        STATUS_CC = dgw_cta.Item(2, i).Value.ToString
                        STATUS_P = dgw_cta.Item(3, i).Value.ToString
                        ESTADO_PER = dgw_cta.Item(4, i).Value.ToString
                        ModificarControl()
                        '---------------------------------------------------
                        If (cbo_tipo_doc0.SelectedIndex <> -1) Then
                            COD_DOC = obj.COD_DOC(cbo_tipo_doc0.Text)
                            COD_DH_DOC = obj.COD_D_H(COD_DOC)
                            If (ESTADO_PER = "P") Then
                                If (COD_DH_DOC = "D") Then
                                    COD_DH_DOC = "H"
                                Else
                                    COD_DH_DOC = "D"
                                End If
                                'cbo_d_h.Enabled = False
                            End If
                            cbo_d_h.Text = COD_DH_DOC
                        End If

                        '---------------------------------------------------
                        If (STATUS_CC = "1") Then
                            CBO_CC.Enabled = True
                        End If
                        If (STATUS_P = "1") Then
                            cbo_proyecto0.Enabled = True
                        End If
                        CBO_AUTOMATICAS(txt_cod_cta0.Text)
                        cbo_d_h.Enabled = True
                        If ((ESTADO_PER = "C") Or (ESTADO_PER = "P")) Then
                            'cbo_d_h.Enabled = False
                            txt_cod_per0.Enabled = True
                            txt_desc_per0.Enabled = True
                            txt_nro_doc_per0.Enabled = True
                            TXT_DIA1.Enabled = True
                            kl2.Enabled = True
                        Else
                            txt_cod_per0.Clear()
                            txt_desc_per0.Clear()
                            txt_nro_doc_per0.Clear()
                            txt_cod_per0.Enabled = False
                            txt_desc_per0.Enabled = False
                            txt_nro_doc_per0.Enabled = False
                            TXT_DIA1.Enabled = False
                            kl2.Enabled = False
                        End If
                        cbo_tipo_doc0.Focus()
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod_per0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per0.LostFocus
        If (Strings.Trim(txt_cod_per0.Text) <> "") Then
            Dim i As Integer
            Select Case ESTADO_PER
                Case "P"
                    If (dgw_per_pagar.RowCount = 0) Then
                        MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_per_pagar.Sort(dgw_per_pagar.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                        Dim CONT As Integer = (dgw_per_pagar.RowCount - 1)
                        i = 0
                        Do While (i <= CONT)
                            If (txt_cod_per0.Text.ToLower = dgw_per_pagar.Item(0, i).Value.ToString.ToLower) Then
                                txt_cod_per0.Text = dgw_per_pagar.Item(0, i).Value.ToString
                                txt_desc_per0.Text = dgw_per_pagar.Item(1, i).Value.ToString
                                txt_nro_doc_per0.Text = dgw_per_pagar.Item(2, i).Value.ToString
                                txt_glosa0.Text = txt_desc_per0.Text
                                'txt_cambio0.Focus()
                                cbo_moneda1.Focus()
                                Return
                            End If
                            If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per_pagar.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                                dgw_per_pagar.CurrentCell = dgw_per_pagar.Rows.Item(i).Cells.Item(0)
                                Exit Do
                            End If
                            dgw_per_pagar.CurrentCell = dgw_per_pagar.Rows.Item(0).Cells.Item(0)
                            i += 1
                        Loop
                        Panel_CXP.Visible = True
                        dgw_per_pagar.Focus()
                    End If

                Case "C"
                    If (dgw_per_cobrar.RowCount = 0) Then
                        MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_per_cobrar.Sort(dgw_per_cobrar.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                        Dim CONT0 As Integer = (dgw_per_cobrar.RowCount - 1)
                        i = 0
                        Do While (i <= CONT0)
                            If (txt_cod_per0.Text.ToLower = dgw_per_cobrar.Item(0, i).Value.ToString.ToLower) Then
                                txt_cod_per0.Text = dgw_per_cobrar.Item(0, i).Value.ToString
                                txt_desc_per0.Text = dgw_per_cobrar.Item(1, i).Value.ToString
                                txt_nro_doc_per0.Text = dgw_per_cobrar.Item(2, i).Value.ToString
                                txt_glosa0.Text = txt_desc_per0.Text
                                txt_cambio0.Focus()
                                Return
                            End If
                            If (txt_cod_per0.Text.ToLower = Strings.Mid((dgw_per_cobrar.Item(0, i).Value), 1, Strings.Len(txt_cod_per0.Text)).ToLower) Then
                                dgw_per_cobrar.CurrentCell = dgw_per_cobrar.Rows.Item(i).Cells.Item(0)
                                Exit Do
                            End If
                            dgw_per_cobrar.CurrentCell = dgw_per_cobrar.Rows.Item(0).Cells.Item(0)
                            i += 1
                        Loop
                        Panel_CXC.Visible = True
                        dgw_per_cobrar.Focus()
                    End If

            End Select
        End If
    End Sub

    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If ((Strings.Trim(txt_desc_cta0.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_per0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per0.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per0.Text) <> "")) Then
            Select Case ESTADO_PER
                Case "P"
                    If (dgw_per_pagar.RowCount = 0) Then
                        MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_per_pagar.Sort(dgw_per_pagar.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                        Dim CONT As Integer = (dgw_per_pagar.RowCount - 1)
                        Dim i As Integer = 0
                        Do While (i <= CONT)
                            If (txt_desc_per0.Text.ToLower = Strings.Mid((dgw_per_pagar.Item(1, i).Value), 1, Strings.Len(txt_desc_per0.Text)).ToLower) Then
                                dgw_per_pagar.CurrentCell = dgw_per_pagar.Rows.Item(i).Cells.Item(0)
                                Exit Do
                            End If
                            dgw_per_pagar.CurrentCell = dgw_per_pagar.Rows.Item(0).Cells.Item(0)
                            i += 1
                        Loop
                        Panel_CXP.Visible = True
                        dgw_per_pagar.Visible = True
                        dgw_per_pagar.Focus()
                    End If

                Case "C"
                    If (dgw_per_cobrar.RowCount = 0) Then
                        MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_per_cobrar.Sort(dgw_per_cobrar.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                        Dim CONT0 As Integer = (dgw_per_cobrar.RowCount - 1)
                        Dim i As Integer = 0
                        Do While (i <= CONT0)
                            If (txt_desc_per0.Text.ToLower = Strings.Mid((dgw_per_cobrar.Item(1, i).Value), 1, Strings.Len(txt_desc_per0.Text)).ToLower) Then
                                dgw_per_cobrar.CurrentCell = dgw_per_cobrar.Rows.Item(i).Cells.Item(0)
                                Exit Do
                            End If
                            dgw_per_cobrar.CurrentCell = dgw_per_cobrar.Rows.Item(0).Cells.Item(0)
                            i += 1
                        Loop
                        Panel_CXC.Visible = True
                        dgw_per_cobrar.Visible = True
                        dgw_per_cobrar.Focus()
                    End If
            End Select
        End If

    End Sub

    Private Sub txt_imp_soles0_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_imp_soles0.KeyPress
        e.Handled = Numero(e, txt_imp_soles0)
    End Sub

    Private Sub txt_imp_soles0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_imp_soles0.LostFocus
        Try
            txt_imp_soles0.Text = (obj.HACER_DECIMAL(txt_imp_soles0.Text))
        Catch ex As Exception
            txt_imp_soles0.Text = "0.00"
        End Try
    End Sub

    Private Sub txt_nro_doc_per0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_doc_per0.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_nro_doc_per0.Text) <> "")) Then
            Select Case ESTADO_PER
                Case "P"
                    If (dgw_per_pagar.RowCount = 0) Then
                        MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_per_pagar.Sort(dgw_per_pagar.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                        Dim CONT As Integer = (dgw_per_pagar.RowCount - 1)
                        Dim i As Integer = 0
                        Do While (i <= CONT)
                            If (txt_nro_doc_per0.Text.ToLower = Strings.Mid((dgw_per_pagar.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per0.Text)).ToLower) Then
                                dgw_per_pagar.CurrentCell = dgw_per_pagar.Rows.Item(i).Cells.Item(0)
                                Exit Do
                            End If
                            dgw_per_pagar.CurrentCell = dgw_per_pagar.Rows.Item(0).Cells.Item(0)
                            i += 1
                        Loop
                        Panel_CXP.Visible = True
                        dgw_per_pagar.Visible = True
                        dgw_per_pagar.Focus()
                    End If

                Case "C"
                    If (dgw_per_cobrar.RowCount = 0) Then
                        MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_per_cobrar.Sort(dgw_per_cobrar.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                        Dim CONT0 As Integer = (dgw_per_cobrar.RowCount - 1)
                        Dim i As Integer = 0
                        Do While (i <= CONT0)
                            If (txt_nro_doc_per0.Text.ToLower = Strings.Mid((dgw_per_cobrar.Item(2, i).Value), 1, Strings.Len(txt_nro_doc_per0.Text)).ToLower) Then
                                dgw_per_cobrar.CurrentCell = dgw_per_cobrar.Rows.Item(i).Cells.Item(0)
                                Exit Do
                            End If
                            dgw_per_cobrar.CurrentCell = dgw_per_cobrar.Rows.Item(0).Cells.Item(0)
                            i += 1
                        Loop
                        Panel_CXC.Visible = True
                        dgw_per_cobrar.Visible = True
                        dgw_per_cobrar.Focus()
                    End If

            End Select
        End If

    End Sub

    Function VALIDAR_TRASNF_CUENTA(ByVal cod_doc As String, ByVal nro_doc As String, ByVal cod_per As String, ByVal doc_per As String) As String
        Dim i As Integer = 0
        Dim CUENTA As String = ""
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        i = 0
        Do While (i <= CONT)
            If (((((cod_doc = dgw_mov1.Item(7, i).Value.ToString) And (nro_doc = dgw_mov1.Item(8, i).Value.ToString)) And (cod_per = dgw_mov1.Item(10, i).Value.ToString)) And (doc_per = dgw_mov1.Item(12, i).Value.ToString)) And (dgw_mov1.Item(21, i).Value.ToString = "1")) Then
                CUENTA = dgw_mov1.Item(0, i).Value.ToString
            End If
            i += 1
        Loop
        Return CUENTA
    End Function

    Function VERIFICAR_DGW(ByVal cod_doc_03 As String, ByVal nro_doc_03 As String, ByVal cod_per_03 As String, ByVal nro_doc_per_03 As String, ByVal cta As String) As Boolean
        Dim k4 As Integer = dgw_mov1.RowCount
        Dim CONT As Integer = (k4 - 1)
        Dim l1 As Integer = 0
        Do While (l1 <= CONT)
            Dim cod_doc_05 As String = dgw_mov1.Item(7, l1).Value.ToString
            Dim nro_doc_05 As String = dgw_mov1.Item(8, l1).Value.ToString
            Dim cod_per_05 As String = dgw_mov1.Item(10, l1).Value.ToString
            Dim nro_doc_per_05 As String = dgw_mov1.Item(12, l1).Value.ToString
            If (cod_doc_05 = cod_doc_03) And (nro_doc_05 = nro_doc_03) And (cod_per_05 = cod_per_03) And (cta = dgw_mov1.Item(0, l1).Value.ToString) Then
                Return False
            End If
            l1 += 1
        Loop
        Return True
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw_mov1.Rows.Count - 1
        Dim IMPORTE As Decimal
        Dim IMPORTE_DEBE, IMPORTE_HABER As Decimal
        For I = 0 To cont
            If dgw_mov1.Item(22, I).Value <> "1" Then
                If dgw_mov1.Item(5, I).Value = "D" Then IMPORTE = dgw_mov1.Item(3, I).Value Else IMPORTE = obj.HACER_DECIMAL(dgw_mov1.Item(2, I).Value / dgw_mov1.Item(6, I).Value)
                If dgw_mov1.Item(4, I).Value = "D" Then
                    IMPORTE_DEBE = dgw_mov1.Item(2, I).Value
                    IMPORTE_HABER = "0.00"
                ElseIf dgw_mov1.Item(4, I).Value = "H" Then
                    IMPORTE_DEBE = "0.00"
                    IMPORTE_HABER = dgw_mov1.Item(2, I).Value
                End If
                '------------------------------------------------------------------------------------
                Dim COD_REPOR As String
                Dim WA1, WA2, WA3 As String
                WA1 = COD_AUX
                If COD_AUX = " " Then
                    WA1 = cbo_aux.SelectedValue.ToString
                End If
                WA2 = COD_COMP
                If COD_COMP = " " Then
                    WA2 = cbo_com.SelectedValue.ToString
                End If
                WA3 = txt_nro_comp.Text
                COD_REPOR = obj.DESC_USUARIO_COMPROBANTE(WA1, WA2, WA3, AÑO, MES)
                '------------------------------------------------------------------------------------
                dt.DataTable1.Rows.Add(dgw_mov1.Item(9, I).Value.ToString.Substring(0, 10), dgw_mov1.Item(8, I).Value, dgw_mov1.Item(7, I).Value, dgw_mov1.Item(10, I).Value, dgw_mov1.Item(15, I).Value, dgw_mov1.Item(0, I).Value, dgw_mov1.Item(11, I).Value, dgw_mov1.Item(5, I).Value, dgw_mov1.Item(6, I).Value, IMPORTE, IMPORTE_DEBE, IMPORTE_HABER, dgw_mov1.Item(4, I).Value, dgw_mov1.Item(14, I).Value, txt_nro_comp.Text, COD_REPOR, dgw_mov1.Item(1, I).Value, cbo_com.Text)
            End If
        Next

        If ch_print.Checked Then
            ReporteImprimir(dt, reporte, cbo_aux.Text)
        Else
            ReporteImprimir(dt, reporte1, cbo_aux.Text)
        End If
    End Sub

    Private Sub btn_det_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_det.Click
        If (cbo_aux.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If (cbo_com.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If (txt_nro_comp.Text.Trim = "") Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        'If txt_tc.Text = "" Then MessageBox.Show("Debe insertar el tipo cambio", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_tc.Focus() : Exit Sub
        If MES = "13" Or MES = "12" Then
            'Panel1.Visible = True
            'If (cbo_mes.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
            'If (txt_tc.Text = "0.0000" Or txt_tc.Text = "") Then MessageBox.Show("Debe ingresar el tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_tc.Focus() : Exit Sub
            BOTON_TEMPORAL_CIERRE()
        End If
        HALLAR_TOTAL()
    End Sub
    Sub BOTON_TEMPORAL_CIERRE()
        TEMP2.HOY = dtp_com.Value.Date
        TEMP2.ShowDialog()
        If TEMP2.DialogResult = Windows.Forms.DialogResult.OK Then
            LLENAR_DATASET()
        End If
    End Sub

    Sub LLENAR_DATASET()
        Dim I, CONT As Integer
        I = 0 : CONT = TEMP2.dgw_det.RowCount - 1
        For I = 0 To CONT
            With TEMP2.dgw_det
                dgw_mov1.Rows.Add(.Item(0, I).Value, .Item(1, I).Value, Math.Round(.Item(2, I).Value, 2), Math.Round(.Item(3, I).Value, 2), .Item(4, I).Value, _
                .Item(5, I).Value, .Item(6, I).Value, "00", "00", dtp_com.Value.Date, .Item(10, I).Value, _
                .Item(11, I).Value, .Item(12, I).Value, .Item(13, I).Value, .Item(14, I).Value, .Item(15, I).Value, .Item(16, I).Value, _
                .Item(17, I).Value, .Item(18, I).Value, .Item(19, I).Value, .Item(20, I).Value, .Item(21, I).Value, .Item(22, I).Value, _
                .Item(23, I).Value, .Item(24, I).Value, .Item(25, I).Value, .Item(26, I).Value, .Item(27, I).Value, .Item(28, I).Value, _
                 .Item(29, I).Value)
            End With
            '.Item(7, I).Value, .Item(8, I).Value por "00","00"
        Next
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
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btn_req_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_req.Click
        boton3()
    End Sub

    Sub boton3()
        ofr.con0 = con00
        ofr._fecha = dtp_com.Value
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

    Private Sub txt_tc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_tc.KeyPress
        e.Handled = Numero(e, txt_tc)
    End Sub

    Private Sub txt_tc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tc.LostFocus
        If (txt_tc.Text <> "") Then
            Try
                txt_tc.Text = (obj.HACER_CAMBIO(txt_tc.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Compra no es valido", "Ingrese otra vez")
                txt_tc.Text = "0.0000"
            End Try
        End If
    End Sub

    Private Sub TXT_DIA1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_DIA1.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXT_DIA1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_DIA1.TextChanged
        Try
            dtp_vence.Value = dtp_doc0.Value.AddDays((TXT_DIA1.Text))
        Catch ex As Exception
            TXT_DIA1.Text = (0)
            dtp_vence.Value = dtp_doc0.Value
        End Try
    End Sub

    Private Sub ModificarControl()
        If (ESTADO_PER = "P" And COD_DH_DOC = "H") Or (ESTADO_PER = "C" And COD_DH_DOC = "D") Then
            CH_CTACTE.Checked = True
            CH_CTACTE.Enabled = True
            fec_ven = dtp_vence.Value
            Try
                dtp_vence.Value = dtp_doc0.Value.AddDays((TXT_DIA1.Text))
            Catch ex As Exception
                TXT_DIA1.Text = (0)
                dtp_vence.Value = dtp_doc0.Value
            End Try
        ElseIf ESTADO_PER = "P" Or ESTADO_PER = "C" Then
            CH_CTACTE.Checked = False
            CH_CTACTE.Enabled = True
            fec_ven = dtp_doc0.Value
        Else
            fec_ven = dtp_doc0.Value
            CH_CTACTE.Checked = False
            CH_CTACTE.Enabled = (obj.HALLAR_ST_ANA_CTA(AÑO, txt_cod_cta0.Text) = "C" OrElse obj.HALLAR_ST_ANA_CTA(AÑO, txt_cod_cta0.Text) = "P")
        End If
    End Sub

    Private Sub cbo_d_h_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_d_h.SelectedIndexChanged
        ModificarControl()
    End Sub

    Private Sub ActivarControl(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_d_h.SelectedValueChanged
        COD_DH_DOC = cbo_d_h.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CARGAR_CUENTAS()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DGW_PERSONAS()
    End Sub

    Private Sub txt_desc_per0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_desc_per0.TextChanged
        If BOTON_DETALLE = "NUEVO" Then
            txt_glosa0.Text = txt_desc_per0.Text
        Else
        End If
    End Sub

    Private Sub txt_nro_doc_per0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_nro_doc_per0.TextChanged
        If BOTON_DETALLE = "NUEVO" Then
            txt_glosa0.Text = txt_desc_per0.Text
        Else
        End If
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub
End Class