Imports System.Data.SqlClient
Imports system.Text
Public Class ASIENTO_DIARIO_prueba
    Dim BOTON, STATUS_P, STATUS_CC, ENLACE, ESTADO_PER, ESTADO_AUTO, COD_DH_DOC, DESTINO, COD_REF, COD_PROYECTO, COD_DOC, COD_MONEDA, COD_CONTROL, COD_AUX, COD_CC, COD_COMP As String
    Dim DT_DET As New DataTable
    Dim FILA_DOC, fila2 As Integer
    Private obj As New Class1
    Private Sub Asiento_Diario_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Asiento_Diario_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CREAR_DATASET()
        CBO_AUXILIAR()
        dgw_mov1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw_mov12.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
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
            'BTN_NUEVO_DOC.Focus()
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
            If (INSERTAR_TODO() = "EXITO") Then
                ELIMINAR_AUTO()
                MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'DATAGRID()
                btn_grabar_com.Enabled = False
                'btn_nuevo_comp.Enabled = True
                'btn_imprimir.Enabled = True
                'btn_imprimir.Focus()
            Else
                obj.ELIMINAR_TEMPORAL("TCON")
                ELIMINAR_AUTO()
                MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
   Sub validar()
        Dim i, cont1 As Integer
        cont1 = dgw_mov1.RowCount - 1
        For i = 0 To cont1
            If dgw_mov1.Item(0, i).Value <> "" And dgw_mov1.Item(5, i).Value <> "" And dgw_mov1.Item(28, i).Value = AÑO And dgw_mov1.Item(29, i).Value = MES Then
                If dgw_mov1.Item(26, i).Value = "1" Then ESTADO_PER = "N"
                If obj.VERIFICAR_CUENTA(dgw_mov1.Item(0, i).Value, AÑO) = True Then
                    If dgw_mov1.Item(10, i).Value.ToString <> "" Then
                        If obj.VERIFICAR_PERSONA(dgw_mov1.Item(10, i).Value) = True Then
                            dgw_mov12.Rows.Add(dgw_mov1.Item(0, i).Value, dgw_mov1.Item(1, i).Value, dgw_mov1.Item(2, i).Value, dgw_mov1.Item(3, i).Value, dgw_mov1.Item(4, i).Value, dgw_mov1.Item(5, i).Value, dgw_mov1.Item(6, i).Value, dgw_mov1.Item(7, i).Value, dgw_mov1.Item(8, i).Value, dgw_mov1.Item(9, i).Value, dgw_mov1.Item(10, i).Value, dgw_mov1.Item(11, i).Value, dgw_mov1.Item(12, i).Value, dgw_mov1.Item(13, i).Value, dgw_mov1.Item(14, i).Value, dgw_mov1.Item(15, i).Value, dgw_mov1.Item(16, i).Value, dgw_mov1.Item(17, i).Value, dgw_mov1.Item(18, i).Value, dgw_mov1.Item(19, i).Value, dgw_mov1.Item(20, i).Value, dgw_mov1.Item(21, i).Value, dgw_mov1.Item(22, i).Value, dgw_mov1.Item(23, i).Value, dgw_mov1.Item(24, i).Value, dgw_mov1.Item(25, i).Value, dgw_mov1.Item(26, i).Value, dgw_mov1.Item(27, i).Value, dgw_mov1.Item(28, i).Value, dgw_mov1.Item(29, i).Value)
                        End If
                    End If
                End If
            End If
        Next
        'ElseIf ((cbo_tipo_doc0.SelectedIndex = -1) And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
        '    MessageBox.Show("Debe de elegir el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cbo_tipo_doc0.Focus()

        'ElseIf ((txt_nro_doc0.Text.Trim = "") And ((ESTADO_PER = "P") Or (ESTADO_PER = "C"))) Then
        '    MessageBox.Show("Debe ingresar el Nº de Doc.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_nro_doc0.Focus()
        'ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_DOC(dtp_doc0.Value)) = 0) Then
        '    dtp_doc0.Focus()
        'ElseIf (Decimal.Parse(txt_imp_soles0.Text) = 0) Then
        '    MessageBox.Show("Debe insertar el Importe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_imp_soles0.Focus()
        'ElseIf (Strings.Trim(txt_cod_per0.Text) = "") And ((ESTADO_PER = "P") Or (ESTADO_PER = "C")) And (MES <> "00" And MES <> "13") Then
        '    MessageBox.Show("Debe de elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_cod_per0.Focus()
        'ElseIf (Strings.Trim(txt_glosa0.Text) = "") Then
        '    MessageBox.Show("Debe ingresar una glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_glosa0.Focus()
        'ElseIf (((ESTADO_PER = "P") Or (ESTADO_PER = "C")) And VERIFICAR_DGW(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) Then
        '    MessageBox.Show("Documento ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'ElseIf (Decimal.Parse(txt_cambio0.Text) = 0) Then
        '    MessageBox.Show("Debe ingresar un Tipo de Cambio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_cambio0.Focus()
        'Else
        '    Dim st_rep As String = "0"
        '    If ch_rep.Checked = True Then st_rep = "1"
        '    '-----------------------------------------
        '    Dim DH As String = ""
        '    If ESTADO_PER = "P" Then
        '        DH = obj.COD_D_H(COD_DOC)
        '        If DH = "D" Then
        '            DH = "H"
        '        Else
        '            DH = "D"
        '        End If
        '    ElseIf ESTADO_PER = "C" Then
        '        DH = obj.COD_D_H(COD_DOC)
        '    End If
        '    '-----------------------------------------
        '    If (MES <> "00" And MES <> "13") And (txt_cod_per0.Text.Trim <> "") Then
        '        If (ESTADO_PER = "P") And DH = cbo_d_h.Text And obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False Then
        '            MessageBox.Show("El Documento  ya existe de Cuentas por Pagar.", "No se puede guardar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        ElseIf (ESTADO_PER = "C") And DH = cbo_d_h.Text And (obj.VERIFICAR_PCTAS_COBRAR(COD_DOC, txt_nro_doc0.Text, txt_cod_per0.Text, txt_nro_doc_per0.Text, txt_cod_cta0.Text) = False) Then
        '            MessageBox.Show("El Documento  ya existe de Cuentas por Cobrar.", "No se puede guardar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '    End If
        '    Dim DOLARES As Decimal
        '    Dim SOLES As Decimal
        '    '------------------------------------------------------
        '    If (cbo_tipo_doc0.SelectedIndex = -1) Then
        '        COD_DOC = ""
        '    End If
        '    COD_CONTROL = ""
        '    COD_PROYECTO = ""
        '    COD_REF = ""
        '    COD_CC = ""
        '    If (CBO_CC.SelectedIndex <> -1) Then
        '        COD_CC = obj.COD_CC(CBO_CC.Text)
        '    End If
        '    If (cbo_proyecto0.SelectedIndex <> -1) Then
        '        COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto0.Text)
        '    End If
        '    If (cbo_tipo_ref0.SelectedIndex <> -1) Then
        '        COD_REF = obj.COD_DOC(cbo_tipo_ref0.Text)
        '    End If
        '    '------------------------------------------------------
        '    If (COD_MONEDA = "S") Then
        '        SOLES = Decimal.Parse(txt_imp_soles0.Text)
        '        DOLARES = New Decimal(Math.Round(CDbl((Decimal.Parse(txt_imp_soles0.Text) / Decimal.Parse(txt_cambio0.Text))), 2))
        '    Else
        '        SOLES = New Decimal(Math.Round(CDbl((Decimal.Parse(txt_imp_soles0.Text) * Decimal.Parse(txt_cambio0.Text))), 2))
        '        DOLARES = Decimal.Parse(txt_imp_soles0.Text)
        '    End If
        '    If COD_MONEDA = "A" Then
        '        SOLES = txt_imp_soles0.Text
        '        DOLARES = "0.00"
        '    End If

        '    ENLACE = ""
        '    DESTINO = ""
        '    DESTINO = Strings.Mid((cbo_auto.SelectedItem), 1, 8)
        '    ENLACE = Strings.Mid((cbo_auto.SelectedItem), 24, 31)
        'dgw_mov1.Rows.Add(txt_cod_cta0.Text, txt_glosa0.Text, SOLES, DOLARES, cbo_d_h.Text, COD_MONEDA, txt_cambio0.Text, COD_DOC, txt_nro_doc0.Text, dtp_doc0.Value, txt_cod_per0.Text, txt_desc_per0.Text, txt_nro_doc_per0.Text, COD_REF, txt_nro_ref0.Text, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, ESTADO_PER, "0", ENLACE, DESTINO, st_rep)

        'HALLAR_TOTAL()
        'LIMPIAR_DOCUMENTO()
        'txt_cod_cta0.Focus()
        'End If
    End Sub
    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
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
    End Sub
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
            If (var23.Length = 8) Then
                Dim cod_enlace As String = ""
                Dim cod_destino As String = ""
                If (var4 = "D") Then
                    cod_enlace = "H"
                    cod_destino = "D"
                ElseIf (var5 = "H") Then
                    cod_enlace = "D"
                    cod_destino = "H"
                End If
                dgw_mov1.Rows.Add(var23, var1, var2, var3, cod_enlace, var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, "", "", "", "", "", "", "", "1", "", "")
                dgw_mov1.Rows.Add(var24, var1, var2, var3, cod_destino, var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, "", "", "", "", "", "", "", "1", "", "")
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
        txt_debe.Text = (debe)
        txt_haber.Text = (haber)
        txt_debe2.Text = (debe2)
        txt_haber2.Text = (haber2)
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
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_mov1.Item(7, I).Value), (dgw_mov1.Item(8, I).Value), (dgw_mov1.Item(10, I).Value), (dgw_mov1.Item(12, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), "", "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(0, I).Value), Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), Decimal.Parse((dgw_mov1.Item(6, I).Value)), (dgw_mov1.Item(15, I).Value), (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), "0", dgw_mov1.Item(23, I).Value.ToString, dgw_mov1.Item(24, I).Value.ToString, dgw_mov1.Item(22, I).Value.ToString, "", "0", "0", "", "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), 0, "", dgw_mov1.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, dgw_mov1.Item(25, I).Value)
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
        'btn_imprimir.Enabled = False
        btn_grabar_com.Visible = True
        'btn_grabar_com2.Visible = False
        btn_grabar_com.Enabled = True

        'Panel_doc2.Enabled = True
        txt_debe.Text = "0.00"
        txt_haber.Text = "0.00"
        txt_debe2.Text = "0.00"
        txt_haber2.Text = "0.00"
        ESTADO_AUTO = "NO"

    End Sub

    Function MODIFICAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_mov1.RowCount - 1
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov1.Item(7, I).Value, dgw_mov1.Item(8, I).Value, (dgw_mov1.Item(10, I).Value), (dgw_mov1.Item(12, I).Value), (I + 1).ToString("0000"), DateTime.Parse((dgw_mov1.Item(9, I).Value)), "", "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), (dgw_mov1.Item(1, I).Value), (dgw_mov1.Item(0, I).Value), Decimal.Parse((dgw_mov1.Item(2, I).Value)), Decimal.Parse((dgw_mov1.Item(3, I).Value)), (dgw_mov1.Item(4, I).Value), (dgw_mov1.Item(5, I).Value), Decimal.Parse((dgw_mov1.Item(6, I).Value)), (dgw_mov1.Item(15, I).Value), (dgw_mov1.Item(16, I).Value), (dgw_mov1.Item(17, I).Value), "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), "0", dgw_mov1.Item(23, I).Value.ToString, dgw_mov1.Item(24, I).Value.ToString, dgw_mov1.Item(22, I).Value.ToString, "", "0", "0", "", "", DateTime.Parse((dgw_mov1.Item(9, I).Value)), 0, "", dgw_mov1.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, dgw_mov1.Item(25, I).Value)
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
   Sub TEMPORAL_INICIO(ByVal TC As Decimal)
        Try
            Dim PROG_01 As New SqlCommand("TEMPORAL_INICIO_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = CInt(AÑO - 1).ToString("0000")
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = "12"
            PROG_01.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TC
            PROG_01.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtp_com.Value.Date
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_mov1.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8).ToString.Substring(0, 10), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '---------------------------------------------------------------
        'MI BLOQUE DE CODIGO
        Dim lista As New List(Of String)
        Dim fila As DataRow
        Dim tabla As New DataTable
        '---------------------------------------------------------------
        'obtengo los datos del fichero.
        '---------------------------------------------------------------

        'Dim fic As New IO.StreamReader("C:\Documents and Settings\MARIA\Escritorio\prueba.txt")
        Dim fic As New IO.StreamReader(txtRutaSave.Text)
        Dim linea As String = Nothing
        linea = fic.ReadLine()
        While (linea <> Nothing)
            lista.Add(linea)
            linea = fic.ReadLine()
        End While
        '---------------------------------------------------------------
        ' Añado las columnas a la tabla antes
        For col As Integer = 0 To lista(0).Split(New Char(), ";").Length - 1
            tabla.Columns.Add(col.ToString())
        Next
        tabla.Columns.Item(0).ColumnName = "Cuenta"
        tabla.Columns.Item(1).ColumnName = "Glosa"
        tabla.Columns.Item(2).ColumnName = "Soles"
        tabla.Columns.Item(3).ColumnName = "Dolares"
        tabla.Columns.Item(4).ColumnName = "D/H"
        tabla.Columns.Item(5).ColumnName = "Mon"
        tabla.Columns.Item(6).ColumnName = "T.C."
        tabla.Columns.Item(7).ColumnName = "Doc"
        tabla.Columns.Item(8).ColumnName = "NºDoc"
        tabla.Columns.Item(9).ColumnName = "Fecha"
        tabla.Columns.Item(10).ColumnName = "C.Cte"
        tabla.Columns.Item(11).ColumnName = "Razon Social"
        tabla.Columns.Item(12).ColumnName = "Ruc/Dni"
        tabla.Columns.Item(13).ColumnName = "Ref"
        tabla.Columns.Item(14).ColumnName = "NºRef"
        tabla.Columns.Item(15).ColumnName = "C.Costos"
        tabla.Columns.Item(16).ColumnName = "Control"
        tabla.Columns.Item(17).ColumnName = "Proyecto"
        tabla.Columns.Item(18).ColumnName = "Status_cc"
        tabla.Columns.Item(19).ColumnName = "Status_cont"
        tabla.Columns.Item(20).ColumnName = "Status_pro"
        tabla.Columns.Item(21).ColumnName = "Status"
        tabla.Columns.Item(22).ColumnName = "Au."
        tabla.Columns.Item(23).ColumnName = "Enlace"
        tabla.Columns.Item(24).ColumnName = "Destino"
        tabla.Columns.Item(25).ColumnName = "Rep"
        tabla.Columns.Item(26).ColumnName = "No Cta. Cte."
        tabla.Columns.Item(27).ColumnName = "Estado Per"
        tabla.Columns.Item(28).ColumnName = "Año"
        tabla.Columns.Item(29).ColumnName = "Mes"
        '---------------------------------------------------------------
        'Creo el array para meter los campos.
        Dim Datos() As String
        For i As Integer = 0 To lista.Count - 1
            Datos = lista(i).Split(New Char(), ";")
            fila = tabla.NewRow()
            For j As Integer = 0 To Datos.Length - 1
                fila(j) = Datos(j)
            Next
            tabla.Rows.Add(fila)
        Next
        '---------------------------------------------------------------
        ' La asigno a mi tabla.
        Me.dgw_mov1.DataSource = tabla
        '---------------------------------------------------------------
        validar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.sfdArchivos.FileName = ""
        Me.sfdArchivos.Filter = "Archivos de texto (*.*)|*.*"
        Me.sfdArchivos.ShowDialog()
        '---------------------------------------------------------
        If Me.sfdArchivos.FileName = "" Then
            Exit Sub
        Else
            txtRutaSave.Text = sfdArchivos.FileName
        End If
        '----------------------------------------------
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        main(119) = 0
        Close()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        validar()
    End Sub
End Class