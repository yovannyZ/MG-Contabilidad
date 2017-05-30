Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Text
Public Class TRANS_ENTRE_CTAS
    Dim BOTON, VAR_PRO, STATUS_PER, DH_GRID, STATUS_P, COD_COMP2, COD_AUX2, STATUS_DOC, STATUS_CC, STATUS_ANA, ITEM_PAGO, cod_ref, COD_PROYECTO, COD_MP, COD_MONEDA, COD_MON_DOC, COD_AUX, COD_CC, COD_COMP, COD_CONTROL, COD_D_H, COD_D_H_PAGO, COD_DOC As String
    Dim DT_DET As New DataTable
    Dim IGV0, IMP_D, IMP_INICIAL, IMP_S As Decimal
    Dim obj As New Class1
    Dim OFR As New CONSULTA_PCTAS_PAGAR
    Private OFR2 As New CONSULTA_PCTAS_COBRAR
    Dim reporte As New CrystalReport1
    Dim S_TIPO As String
    Dim monto As Decimal
    Dim SB As New StringBuilder
    Sub BOTON3()
        OFR.COD_SUC = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        OFR.COD_CPTO00 = ""
        OFR.COD_PER00 = txt_cod1.Text
        'OFR.MON00 = cbo_moneda_pago.SelectedValue.ToString
        OFR.CARGAR_PCTAS_PAGAR_PERSONA_MONEDA()
        OFR.limpiar()
        OFR.ShowDialog()
        If (OFR.DialogResult = Windows.Forms.DialogResult.OK) Then
            If (OFR.LBL.Text = "NO") Then
                BOTON3()
            Else
                INSERTAR_DIALOGO_PAGAR()
                OFR.Hide()
            End If
            Panel_det.Visible = False
            btn_nuevo_doc.Focus()
        End If
    End Sub
    Function VERIFICAR(ByVal COD_PER As Object, ByVal COD_DOC As Object, ByVal NRO_DOC As Object) As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_pagar.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If COD_PER = dgw_pagar.Item(3, I).Value.ToString And COD_DOC = dgw_pagar.Item(1, I).Value.ToString And NRO_DOC = dgw_pagar.Item(2, I).Value.ToString Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
    Function VERIFICAR_COBRAR(ByVal COD_PER As Object, ByVal COD_DOC As Object, ByVal NRO_DOC As Object) As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_cobrar.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If COD_PER = dgw_cobrar.Item(3, I).Value.ToString And COD_DOC = dgw_cobrar.Item(1, I).Value.ToString And NRO_DOC = dgw_cobrar.Item(2, I).Value.ToString Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
    Private Sub btn_Cancelar_comp_Click(ByVal sender As Object, ByVal e As EventArgs)
        TabControl1.SelectedTab = TabPage1
    End Sub
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
        BOTON = "MODIFICAR"
        LIMPIAR_COMPROBANTE()
        CARGAR_COMPROBANTE()
        CARGAR_DETALLES()
        HALLAR_TOTAL()
        TabControl1.SelectedTab = TabPage2
        Panel_doc00.Enabled = False
        btn_grabar_pago01.Enabled = False
        'Panel_pago00.Enabled = False
    End Sub
    Sub CARGAR_DETALLES()

        dgw_pagar.Rows.Clear()
        Dim k1 As Integer = 0
        Dim k2 As Integer = (dgw_mov.RowCount - 1)
        k1 = 0
        Do While (k1 <= k2)
            Dim PAGO As New Decimal
            COD_MONEDA = dgw_mov.Item(9, k1).Value.ToString
            If (COD_MONEDA = "S") Then
                PAGO = Math.Round(Decimal.Parse(dgw_mov.Item(27, k1).Value), 2)
            ElseIf (COD_MONEDA = "D") Then
                PAGO = Math.Round(Decimal.Parse(dgw_mov.Item(28, k1).Value), 2)
            End If
            'Dim st_ana As String = obj.HALLAR_ST_ANA_CTA(AÑO, dgw_mov.Item(12, k1).Value)
            Dim st_ana As String = dgw_mov.Item(29, k1).Value
            If st_ana = "P" Then

                'Buscar Auxiliar, comprobante
                Dim list As New List(Of String)

                Try
                    con.Open()
                    Dim cmd As New SqlCommand("OBTENER_AUXILIAR_COMP_EGRESO", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    Dim codPer As String = dgw_mov.Item(4, k1).Value.ToString
                    Dim nroDoc As String = dgw_mov.Item(2, k1).Value.ToString
                    Dim codDoc As String = dgw_mov.Item(1, k1).Value.ToString
                    cmd.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = codPer
                    cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
                    cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.HasRows Then
                        Do While reader.Read()
                            list.Add(reader.GetString(0))
                            list.Add(reader.GetString(1))
                            list.Add(reader.GetString(2))
                            list.Add(reader.GetString(3))
                            list.Add(reader.GetString(4))
                        Loop
                    Else
                        list.Add("")
                        list.Add("")
                        list.Add("")
                        list.Add("")
                        list.Add("")
                    End If
                    reader.Close()
                    con.Close()
                Catch ex As SqlException
                    con.Close()
                    Dim er As SqlError
                    For Each er In ex.Errors
                        MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Next
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

                '''''''''''''''''''''''''''''''

                dgw_pagar.Rows.Add((dgw_pagar.RowCount + 1).ToString("0000"), (dgw_mov.Item(1, k1).Value), (dgw_mov.Item(2, k1).Value), (dgw_mov.Item(4, k1).Value), (dgw_mov.Item(5, k1).Value), (dgw_mov.Item(6, k1).Value), PAGO, (dgw_mov.Item(8, k1).Value), (dgw_mov.Item(9, k1).Value), (dgw_mov.Item(7, k1).Value), (dgw_mov.Item(10, k1).Value), (dgw_mov.Item(3, k1).Value), (dgw_mov.Item(11, k1).Value), (dgw_mov.Item(12, k1).Value), (dgw_mov.Item(17, k1).Value), (dgw_mov.Item(13, k1).Value), (dgw_mov.Item(14, k1).Value), (dgw_mov.Item(15, k1).Value), (dgw_mov.Item(18, k1).Value), (dgw_mov.Item(19, k1).Value), (dgw_mov.Item(20, k1).Value), (dgw_mov.Item(16, k1).Value), (dgw_mov.Item(21, k1).Value), (dgw_mov.Item(22, k1).Value), (dgw_mov.Item(23, k1).Value), "", list.Item(0), list.Item(1), list.Item(2), list.Item(3), list.Item(4))
            ElseIf st_ana = "C" Then

                'Buscar Auxiliar, comprobante
                Dim list As New List(Of String)

                Try
                    con.Open()
                    Dim cmd As New SqlCommand("OBTENER_AUXILIAR_COMP_INGRESO", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    Dim codPer As String = dgw_mov.Item(4, k1).Value.ToString
                    Dim nroDoc As String = dgw_mov.Item(2, k1).Value.ToString
                    Dim codDoc As String = dgw_mov.Item(1, k1).Value.ToString
                    cmd.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = codPer
                    cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
                    cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    If reader.HasRows Then
                        Do While reader.Read()
                            list.Add(reader.GetString(0))
                            list.Add(reader.GetString(1))
                            list.Add(reader.GetString(2))
                            list.Add(reader.GetString(3))
                            list.Add(reader.GetString(4))
                        Loop
                    Else
                        list.Add("")
                        list.Add("")
                        list.Add("")
                        list.Add("")
                        list.Add("")
                    End If
                    reader.Close()
                    con.Close()
                Catch ex As SqlException
                    con.Close()
                    Dim er As SqlError
                    For Each er In ex.Errors
                        MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Next
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

                '''''''''''''''''''''''''''''''
                dgw_cobrar.Rows.Add((dgw_cobrar.RowCount + 1).ToString("0000"), (dgw_mov.Item(1, k1).Value), (dgw_mov.Item(2, k1).Value), (dgw_mov.Item(4, k1).Value), (dgw_mov.Item(5, k1).Value), (dgw_mov.Item(6, k1).Value), PAGO, (dgw_mov.Item(8, k1).Value), (dgw_mov.Item(9, k1).Value), (dgw_mov.Item(7, k1).Value), (dgw_mov.Item(10, k1).Value), (dgw_mov.Item(3, k1).Value), (dgw_mov.Item(11, k1).Value), (dgw_mov.Item(12, k1).Value), (dgw_mov.Item(17, k1).Value), (dgw_mov.Item(13, k1).Value), (dgw_mov.Item(14, k1).Value), (dgw_mov.Item(15, k1).Value), (dgw_mov.Item(18, k1).Value), (dgw_mov.Item(19, k1).Value), (dgw_mov.Item(20, k1).Value), (dgw_mov.Item(16, k1).Value), (dgw_mov.Item(21, k1).Value), (dgw_mov.Item(22, k1).Value), (dgw_mov.Item(23, k1).Value), "", list.Item(0), list.Item(1), list.Item(2), list.Item(3), list.Item(4))
            End If
            k1 += 1
        Loop
        '-------------------------------------------------------------------------
        cbo_moneda_pago.Text = obj.DESC_MONEDA(dgw_mov.Item(9, 0).Value)
        txt_cambio_pago.Text = dgw_mov.Item(10, 0).Value
        dtp_mp.Value = dgw_mov.Item(30, 0).Value
        '-------------------------------------------------------------------------
    End Sub
    Private Sub btn_doc_pte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_doc_pte.Click

        If txt_cod1.Text = "" Then MessageBox.Show("Debe elegir la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod1.Focus() : Exit Sub
        If S_TIPO = "P" Then
            BOTON3()
        ElseIf S_TIPO = "C" Then
            BOTON3_COBRAR()
        End If
    End Sub
    Sub BOTON3_COBRAR()
        OFR2.COD_SUC = obj.HALLAR_SUCURSAL(COD_AUX, COD_COMP)
        OFR2.COD_PER00 = txt_cod1.Text
        'OFR2.MON00 = cbo_moneda_pago.SelectedValue.ToString
        OFR2.CARGAR_PCTAS_COBRAR_PERSONA_MONEDA()
        OFR2.limpiar()
        OFR2.ShowDialog()
        If (OFR2.DialogResult = Windows.Forms.DialogResult.OK) Then
            If (OFR2.LBL.Text = "NO") Then
                BOTON3_COBRAR()
            Else
                INSERTAR_DIALOGO_COBRAR()
                OFR2.Hide()
            End If
            Panel_det.Visible = False
            btn_nuevo_doc.Focus()
        End If
    End Sub
    Sub INSERTAR_DIALOGO_COBRAR()
        COD_CONTROL = "" : COD_PROYECTO = "" : COD_CC = ""
        If cbo_control.SelectedIndex <> -1 Then COD_CONTROL = obj.COD_CONTROL(cbo_control.Text)
        If cbo_proyecto.SelectedIndex <> -1 Then COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto.Text)
        If CBO_CC.SelectedIndex <> -1 Then COD_CC = obj.COD_CC(CBO_CC.Text)
        Dim CONT As Integer = (OFR2.DGW_CAB.Rows.Count - 1)
        Dim K As Integer = 0
        Do While (K <= CONT)
            If OFR2.DGW_CAB.Item(9, K).Value.ToString = "True" Then
                Dim imp_pago As Decimal
                'If (OFR2.DGW_CAB.Item(6, K).Value.ToString = COD_MONEDA) Then
                imp_pago = Decimal.Parse(OFR2.DGW_CAB.Item(8, K).Value)
                'ElseIf ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                '    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Multiply(OFR2.DGW_CAB.Item(8, K).Value, txt_cambio_pago.Text)))
                'Else
                '    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Divide(OFR2.DGW_CAB.Item(8, K).Value, txt_cambio_pago.Text)))
                'End If
                If VERIFICAR_COBRAR(OFR2.DGW_CAB.Item(3, K).Value.ToString, OFR2.DGW_CAB.Item(0, K).Value.ToString, OFR2.DGW_CAB.Item(2, K).Value.ToString) = False Then
                    MessageBox.Show("El Documento ya se ingresó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else

                    'Buscar Auxiliar, comprobante
                    Dim list As New List(Of String)

                    Try
                        con.Open()
                        Dim cmd As New SqlCommand("OBTENER_AUXILIAR_COMP_INGRESO", con)
                        cmd.CommandType = (CommandType.StoredProcedure)
                        Dim codPer As String = OFR2.DGW_CAB.Item(3, K).Value.ToString
                        Dim nroDoc As String = OFR2.DGW_CAB.Item(2, K).Value.ToString
                        Dim codDoc As String = OFR2.DGW_CAB.Item(0, K).Value.ToString
                        cmd.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = codPer
                        cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
                        cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
                        Dim reader As SqlDataReader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            Do While reader.Read()
                                list.Add(reader.GetString(0))
                                list.Add(reader.GetString(1))
                                list.Add(reader.GetString(2))
                                list.Add(reader.GetString(3))
                                list.Add(reader.GetString(4))
                            Loop
                        Else
                            list.Add("")
                            list.Add("")
                            list.Add("")
                            list.Add("")
                            list.Add("")
                        End If
                        reader.Close()
                        con.Close()
                    Catch ex As SqlException
                        con.Close()
                        Dim er As SqlError
                        For Each er In ex.Errors
                            MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Next
                    Catch ex As Exception
                        con.Close()
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try

                    '''''''''''''''''''''''''''''''

                    dgw_cobrar.Rows.Add((dgw_cobrar.RowCount + 1).ToString("0000"), OFR2.DGW_CAB.Item(0, K).Value.ToString, OFR2.DGW_CAB.Item(2, K).Value.ToString, OFR2.DGW_CAB.Item(3, K).Value.ToString, OFR2.DGW_CAB.Item(4, K).Value.ToString, OFR2.DGW_CAB.Item(11, K).Value.ToString, imp_pago, OFR2.DGW_CAB.Item(8, K).Value.ToString, OFR2.DGW_CAB.Item(6, K).Value.ToString, OFR2.DGW_CAB.Item(10, K).Value.ToString, txt_cambio_pago.Text, OFR2.DGW_CAB.Item(5, K).Value.ToString, OFR2.DGW_CAB.Item(4, K).Value.ToString, OFR2.DGW_CAB.Item(14, K).Value.ToString, OFR2.DGW_CAB.Item(5, K).Value.ToString, COD_CC, COD_CONTROL, COD_PROYECTO, OFR2.DGW_CAB.Item(15, K).Value.ToString, OFR2.DGW_CAB.Item(16, K).Value.ToString, OFR2.DGW_CAB.Item(17, K).Value.ToString, "0", "S", "", "", "C", list.Item(0), list.Item(1), list.Item(2), list.Item(3), list.Item(4))
                End If
            End If
            K += 1
        Loop
        HALLAR_TOTAL()
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

            'If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
            '    MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            Dim ESTADO As String = "FALLO"
            'OJO FALTA ESTO EN SCRIPT
            Try
                Dim comand1 As New SqlCommand("ELIMINAR_I_CON_TRANSFERENCIA_CTAS", con)
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
    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        If TabControl2.SelectedIndex = 0 Then
            Try
                Dim i As Integer = dgw_pagar.CurrentRow.Index
            Catch ex As Exception
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
            If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el Detalle.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                dgw_pagar.Rows.RemoveAt(dgw_pagar.CurrentRow.Index)
            End If
        ElseIf TabControl2.SelectedIndex = 1 Then
            Try
                Dim i As Integer = dgw_cobrar.CurrentRow.Index
            Catch ex As Exception
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
            If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el Detalle.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                dgw_cobrar.Rows.RemoveAt(dgw_cobrar.CurrentRow.Index)
            End If
        End If

        HALLAR_TOTAL()
    End Sub
    Private Sub btn_grabar_pago01_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_grabar_pago01.Click
        'If txt_saldo_soles.Text = "0.00" Then
        'If dgw_pagar.Rows.Count = 0 Then MessageBox.Show("Ctas x Pagar sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub
        'If dgw_cobrar.Rows.Count = 0 Then MessageBox.Show("Ctas x Cobrar sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_doc.Focus() : Exit Sub
        INSERTAR_DGW_PAGO()
        INSERTAR_DGW_PAGO_cobrar()
        'LIMPIAR_PAGO()
        '----------------------
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If (Decimal.Parse(obj.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then dtp_com.Focus() : Exit Sub
        'If dgw_pago0.RowCount = 0 Then MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_nuevo_pago0.Focus() : Exit Sub
        '--------------------------------------------------------------------------------------
        If txt_saldo_soles.Text <> "0.00" Then
            If VALIDAR_IMPORTE2() = False Then
                '   MessageBox.Show("El importe debe y haber deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If

        GENERAR_AUTO()
        '--------------------------------------------------------------------------------------
        'If VERIFICAR_AUTO() Then
        If INSERTAR_TODO() = "EXITO" Then
            MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            obj.ELIMINAR_TEMPORAL("TCON")
            MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        DATAGRID()
        Button1.Enabled = True
        btn_grabar_pago01.Enabled = False
        Panel_doc00.Enabled = False
        'End If
    End Sub
    Sub GENERAR_AUTO()
        Dim cont_r1 As Integer = DGW_MOV.RowCount
        Dim CONT0 As Integer = (cont_r1 - 1)
        Dim j As Integer = 0
        Do While (j <= CONT0)

            Dim var5 As String = (dgw_mov.Item(7, j).Value)
            Dim var14 As String = (dgw_mov.Item(32, j).Value)
            If var14 Is Nothing Then
                var14 = " "
            End If
            Dim var15 As String = (dgw_mov.Item(33, j).Value)
            If var15 Is Nothing Then
                var15 = " "
            End If
            Dim var16 As String = (dgw_mov.Item(27, j).Value)

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
                'dgw_mov.Rows.Add(var0, var14, var2, var3, var4, cod_enlace, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", "0", "0", var24, "", "", "")
                'dgw_mov.Rows.Add(var0, var15, var2, var3, var4, cod_destino, var6, var7, "", "", "", "", var12, var13, "", "", "", "", "", var19, var20, var21, var22, var23, "1", "0", " ", "0", "0", " ", " ", Now.Date, 0, " ", 0, 0, "0", "0", "0", var24, "", "", "")


                dgw_mov.Rows.Add("", "", "", dtp_mp.Value, "", "", "", cod_enlace, "0", "A", txt_cambio_pago.Text, "AJUSTE DE DOCUMENTO", var14, "", "", "", "", dtp_mp.Value, "", "", "", "", "", "", dtp_mp.Value, "0000", "", var16, "0", "", dtp_com.Value)
                dgw_mov.Rows.Add("", "", "", dtp_mp.Value, "", "", "", cod_destino, "0", "A", txt_cambio_pago.Text, "AJUSTE DE DOCUMENTO", var15, "", "", "", "", dtp_mp.Value, "", "", "", "", "", "", dtp_mp.Value, "0000", "", var16, "0", "", dtp_com.Value)
            End If
            j += 1
        Loop
    End Sub
    Function VERIFICAR_AUTO() As Boolean
        Dim CTA0 As String = ""
        SB.Remove(0, SB.Length)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            Dim E, D, AJUSTE As String
            E = dgw_mov.Item(32, I).Value
            D = dgw_mov.Item(33, I).Value
            AJUSTE = dgw_mov.Item(31, I).Value
            If E Is Nothing Then
                E = " "
            End If
            If D Is Nothing Then
                D = " "
            End If
            If AJUSTE Is Nothing Then
                AJUSTE = " "
            End If
            If (AJUSTE = "B" And (E <> " ") And (D <> " ")) Then
                CTA0 = dgw_mov.Item(12, I).Value.ToString
                Try
                    Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_AUTO", con)
                    comand1.CommandType = CommandType.StoredProcedure
                    comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw_mov.Item(12, I).Value
                    comand1.Parameters.Add("@CUENTA_ENLACE", SqlDbType.VarChar).Value = dgw_mov.Item(32, I).Value
                    comand1.Parameters.Add("@CUENTA_DESTINO", SqlDbType.VarChar).Value = dgw_mov.Item(33, I).Value
                    comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                    con.Open()
                    comand1.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                    Do While Rs3.Read
                        SB.ToString.Trim(Rs3.GetValue(0))
                        SB.AppendLine(Rs3.GetValue(0))
                    Loop
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
            End If
            I += 1
        Loop
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen en el Maestro de Automaticas  Cuenta : Destino/Enlace : " & vbCrLf & " " & SB.ToString), "No se puede Insertar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function
    Function VALIDAR_IMPORTE2() As Boolean
        Dim SOLESD As New Decimal
        Dim DOLARESD As New Decimal
        Dim SOLESH As New Decimal
        Dim DOLARESH As New Decimal
        Dim I As Integer = 0
        'Dim CONT As Integer = (dgw_det_01.RowCount - 1)
        'Dim CONT0 As Integer = CONT
        I = 0

        SOLESH = txt_haber_soles.Text
        SOLESD = txt_debe_soles.Text
        DOLARESD = txt_debe_dolares.Text
        DOLARESH = txt_haber_dolares.Text

        If cbo_moneda_pago.SelectedValue.ToString = "S" Then
            If SOLESH = SOLESD Then
                If (DOLARESD - DOLARESH) < 0.5 And (DOLARESD - DOLARESH) > -0.5 Then
                    'ESTA BIEN PERO NO HAY AJUSTE EN DOLARES
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        Else
            'MONEDA DOLARES
            If DOLARESD = DOLARESH Then
                If (SOLESD - SOLESH) < 0.5 And (SOLESD - SOLESH) > -0.5 Then
                    'TIENE QUE HABER AJUSTE
                    Dim AJ As Decimal = SOLESD - SOLESH
                    Dim DH_AJ As String = "H"
                    If AJ < 0 Then DH_AJ = "D" : AJ = AJ * -1
                    Dim CTA_AJ As String = obj.DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
                    If DH_AJ = "D" Then CTA_AJ = obj.DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
                    Dim ORDEN0 As String = obj.HALLAR_ORDEN_CUENTA("B", AÑO, "V", CTA_AJ)
                    Dim E, D As String
                    E = obj.HALLAR_CTA_ENLACE(AÑO, CTA_AJ)
                    D = obj.HALLAR_CTA_DESTINO(AÑO, CTA_AJ)
                    If E Is Nothing Or E = "" And D Is Nothing Or D = "" Then
                        dgw_mov.Rows.Add("", "00", AÑO & "-" & MES, dtp_mp.Value, "", "", "", DH_AJ, "0", "A", txt_cambio_pago.Text, "AJUSTE DE DOCUMENTO", CTA_AJ, "", "", "", "", dtp_mp.Value, "", "", "", "", "", "", dtp_mp.Value, "0000", "", AJ, "0", "", dtp_com.Value, "B", "", "")
                    Else
                        '--------------------------
                        If AJ <> 0 Then
                            dgw_mov.Rows.Add("", "00", AÑO & "-" & MES, dtp_mp.Value, "", "", "", DH_AJ, "0", "A", txt_cambio_pago.Text, "AJUSTE DE DOCUMENTO", CTA_AJ, "", "", "", "", dtp_mp.Value, "", "", "", "", "", "", dtp_mp.Value, "0000", "", AJ, "0", "", dtp_com.Value, "B", E, D)
                            '("0000" ,  CTA_AJ, "AJUSTE DE DOCUMENTO", AJ, 0, DH_AJ, "A", TCAMBIO, "0", "", "", "00", FECHA_DOC, "0", "", "", "0", "0", "0", FECHA_DOC, "", "", "", "", "0", "B", "", "", "", "", "", FECHA_DOC, "", 0, 0, "", "", "", "")
                        End If
                        '--------------------------
                    End If

                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        End If
    End Function
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If S_TIPO = "P" Then
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
            ElseIf txt_glosa.Text.Trim = "" Then
                MessageBox.Show("Debe insertar la Glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_glosa.Focus()
            Else
                '------------------------------------------------
                If (txt_imp_soles.Text.Trim = "") Then
                    txt_imp_soles.Text = "0.00"
                End If
                '------------------------------------------------
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
                    'If obj.VERIFICAR_PCTAS_PAGAR(COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_nro_doc_per.Text, txt_cod_cta.Text) = False Then
                    '    MessageBox.Show("EL documento ya existe en Cuentas por Pagar", "No se puede ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Else
                    If VALIDAR_DET(COD_DOC, txt_nro_doc.Text, txt_cod1.Text) = False Then
                        MessageBox.Show("EL documento ya se ingresó.", "No se puede ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        dgw_pagar.Rows.Add((dgw_pagar.RowCount + 1).ToString("0000"), COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, imp_pago, IMP_S, COD_MON_DOC, DH_GRID, txt_cambio_pago.Text, dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, dtp_mp.Value, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, STATUS_PER, VAR_PRO, cod_ref, txt_nro_ref.Text, "P")
                        HALLAR_TOTAL()
                        LIMPIAR_DETALLES()
                        txt_cod1.Focus()
                    End If
                End If
            End If
        End If
        If S_TIPO = "C" Then
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
            ElseIf txt_glosa.Text.Trim = "" Then
                MessageBox.Show("Debe insertar la Glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_glosa.Focus()
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
                        dgw_cobrar.Rows.Add((dgw_cobrar.RowCount + 1).ToString("0000"), COD_DOC, txt_nro_doc.Text, txt_cod1.Text, txt_desc_per.Text, txt_nro_doc_per.Text, imp_pago, IMP_S, COD_MON_DOC, DH_GRID, txt_cambio_pago.Text, dtp_mp.Value, txt_glosa.Text, txt_cod_cta.Text, dtp_mp.Value, COD_CC, COD_CONTROL, COD_PROYECTO, STATUS_CC, "1", STATUS_P, STATUS_PER, VAR_PRO, cod_ref, txt_nro_ref.Text, "C")
                        HALLAR_TOTAL()
                        LIMPIAR_DETALLES()
                        txt_cod1.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        BOTON = "NUEVO"
        LIMPIAR_COMPROBANTE()
        TabControl1.SelectedTab = TabPage2
        cbo_aux.Focus()
    End Sub
    Sub PERSONAS_cobrar()
        Try
            DGW_PER.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            DGW_PER.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER.Columns.Item(0).Width = &H37
            DGW_PER.Columns.Item(1).Width = 330
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_nuevo_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo_doc.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        '------------------------------------------------------------------------------------------------------------
        If cbo_moneda_pago.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda_pago.Focus() : Exit Sub
        If dtp_mp.Value.Date > FECHA_GRAL.Date Then MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information) : dtp_mp.Focus() : Exit Sub
        If (txt_cambio_pago.Text.Trim = "") Then txt_cambio_pago.Text = "0.0000"

        If (Decimal.Parse(txt_cambio_pago.Text) = 0) Then
            MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cambio_pago.Focus() : Exit Sub
        End If
        LIMPIAR_DETALLES()
        Button3.Visible = False
        btn_guardar.Visible = True

        GroupBox1.Enabled = False
        Panel_det.Visible = True
        txt_cod1.Focus()
        '------------------------------------------------------------------------------------------------------------
        If TabControl2.SelectedIndex = 0 Then
            PERSONAS()
            S_TIPO = "P"
            Label11.Text = "Proveedor"
        ElseIf TabControl2.SelectedIndex = 1 Then
            PERSONAS_cobrar()
            S_TIPO = "C"
            Label11.Text = "Cliente"
        End If
        '------------------------------------------------------------------------------------------------------------
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(142) = 0
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
        CBO_PROYECTO00()
        CBO_CONTROL00()
        CC00()
        CBO_TIPO_DOC00()
        CBO_AUXILIAR()
        CARGAR_CUENTAS()
        CREAR_DATASET()
        dtp_mp.Value = FECHA_GRAL
        IGV0 = Decimal.Parse(obj.IMPUESTO("IGV"))
        dgw_pagar.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        dgw_cobrar.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Panel_doc.Visible = True
        Panel_det.Visible = False
        btn_nuevo.Select()
    End Sub
    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        dgw_mov.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_TRANSFERENCIA_CTAS", con)
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
                dgw_mov.Rows.Add(rs3.GetValue(0), rs3.GetValue(1), rs3.GetValue(2), rs3.GetValue(3), rs3.GetValue(4), rs3.GetValue(5), rs3.GetValue(6), rs3.GetValue(7), rs3.GetValue(8), rs3.GetValue(9), rs3.GetValue(10), rs3.GetValue(11), rs3.GetValue(12), rs3.GetValue(13), rs3.GetValue(14), rs3.GetString(15), rs3.GetValue(16), rs3.GetValue(17), rs3.GetValue(18), rs3.GetValue(19), rs3.GetValue(20), rs3.GetValue(21), rs3.GetValue(22), rs3.GetValue(23), rs3.GetValue(24), rs3.GetValue(25), rs3.GetValue(26), rs3.GetValue(31), rs3.GetValue(32), rs3.GetValue(33), rs3.GetValue(3))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CUENTAS()

        DGW_CTA1.DataSource = obj.MOSTRAR_CUENTAS_STATUS(AÑO)
        DGW_CTA1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_CTA1.Columns.Item(2).Visible = False
        DGW_CTA1.Columns.Item(3).Visible = False
        DGW_CTA1.Columns.Item(4).Visible = False
        DGW_CTA1.Columns.Item(0).Width = 80
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
        numeracion()
    End Sub
    Sub numeracion()
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
            Dim pro_02 As New SqlCommand("MOSTRAR_ICON_CTCAN", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CTCAN"
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
    Sub HALLAR_TOTAL()
        Dim D_DOLARES, D_SOLES, H_DOLARES, H_SOLES, total As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_pagar.Rows.Count - 1)
        CONT = (dgw_pagar.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (dgw_pagar.Item(9, I).Value.ToString = "D") Then
                '----moneda es 8
                Select Case dgw_pagar.Item(8, I).Value.ToString
                    Case "D"
                        D_DOLARES = D_DOLARES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value), 2)
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value) * txt_cambio_pago.Text, 2)
                    Case "S"
                        D_DOLARES = D_DOLARES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value) / txt_cambio_pago.Text, 2)
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value), 2)
                    Case "A"
                        D_DOLARES = D_DOLARES + 0
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value), 2)
                End Select
            Else
                Select Case dgw_pagar.Item(8, I).Value.ToString
                    Case "D"
                        H_DOLARES = H_DOLARES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value), 2)
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value * txt_cambio_pago.Text), 2)
                    Case "S"
                        H_DOLARES = H_DOLARES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value / txt_cambio_pago.Text), 2)
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value), 2)
                    Case "A"
                        H_DOLARES = H_DOLARES + 0
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_pagar.Item(6, I).Value), 2)
                End Select
            End If
            I += 1
        Loop
        '---------------------------------------------------------------------------------------------
        Dim J As Integer = 0
        Dim CONT2 As Integer = (dgw_cobrar.Rows.Count - 1)
        CONT2 = (dgw_cobrar.Rows.Count - 1)
        I = 0
        Do While (J <= CONT2)
            If (dgw_cobrar.Item(9, J).Value.ToString = "D") Then
                Select Case dgw_cobrar.Item(8, J).Value.ToString
                    Case "D"
                        D_DOLARES = D_DOLARES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value), 2)
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value) * txt_cambio_pago.Text, 2)
                    Case "S"
                        D_DOLARES = D_DOLARES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value) / txt_cambio_pago.Text, 2)
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value), 2)
                    Case "A"
                        D_DOLARES = D_DOLARES + 0
                        D_SOLES = D_SOLES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value), 2)
                End Select
            Else
                Select Case dgw_cobrar.Item(8, J).Value.ToString
                    Case "D"
                        H_DOLARES = H_DOLARES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value), 2)
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value * txt_cambio_pago.Text), 2)
                    Case "S"
                        H_DOLARES = H_DOLARES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value / txt_cambio_pago.Text), 2)
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value), 2)
                    Case "A"
                        H_DOLARES = H_DOLARES + 0
                        H_SOLES = H_SOLES + Math.Round(Decimal.Parse(dgw_cobrar.Item(6, J).Value), 2)
                End Select
            End If
            J += 1
        Loop
        ' ---------------------------------------------------------------------------------------------
        txt_debe_soles.Text = obj.HACER_DECIMAL(D_SOLES)
        txt_debe_dolares.Text = obj.HACER_DECIMAL(D_DOLARES)
        txt_haber_soles.Text = obj.HACER_DECIMAL(H_SOLES)
        txt_haber_dolares.Text = obj.HACER_DECIMAL(H_DOLARES)
        txt_saldo_soles.Text = obj.HACER_DECIMAL(Decimal.Subtract(D_SOLES, H_SOLES))
        txt_saldo_dolares.Text = obj.HACER_DECIMAL(Decimal.Subtract(D_DOLARES, H_DOLARES))
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
    Sub INSERTAR_DIALOGO_PAGAR()
        COD_CONTROL = "" : COD_PROYECTO = "" : COD_CC = ""
        If cbo_control.SelectedIndex <> -1 Then COD_CONTROL = obj.COD_CONTROL(cbo_control.Text)
        If cbo_proyecto.SelectedIndex <> -1 Then COD_PROYECTO = obj.COD_PROYECTO(cbo_proyecto.Text)
        If CBO_CC.SelectedIndex <> -1 Then COD_CC = obj.COD_CC(CBO_CC.Text)
        Dim CONT As Integer = OFR.DGW_CAB.Rows.Count - 1
        Dim K As Integer = 0
        Do While (K <= CONT)
            If OFR.DGW_CAB.Item(9, K).Value.ToString = "True" Then
                Dim imp_pago As Decimal
                'If (OFR.DGW_CAB.Item(6, K).Value.ToString = COD_MONEDA) Then
                imp_pago = Decimal.Parse(OFR.DGW_CAB.Item(8, K).Value)
                'ElseIf ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                '    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Multiply(OFR.DGW_CAB.Item(8, K).Value, txt_cambio_pago.Text)))
                'Else
                '    imp_pago = Decimal.Parse(obj.HACER_DECIMAL(Decimal.Divide(OFR.DGW_CAB.Item(8, K).Value, txt_cambio_pago.Text)))
                'End If
                '-----------------------------------------------------------
                If VERIFICAR(OFR.DGW_CAB.Item(3, K).Value.ToString, OFR.DGW_CAB.Item(0, K).Value.ToString, OFR.DGW_CAB.Item(2, K).Value.ToString) = False Then
                    MessageBox.Show("El Documento ya se ingresó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else

                    'Buscar Auxiliar, comprobante
                    Dim list As New List(Of String)

                    Try
                        con.Open()
                        Dim cmd As New SqlCommand("OBTENER_AUXILIAR_COMP_EGRESO", con)
                        cmd.CommandType = (CommandType.StoredProcedure)
                        Dim codPer As String = OFR.DGW_CAB.Item(3, K).Value.ToString
                        Dim nroDoc As String = OFR.DGW_CAB.Item(2, K).Value.ToString
                        Dim codDoc As String = OFR.DGW_CAB.Item(0, K).Value.ToString
                        cmd.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = codPer
                        cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
                        cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
                        Dim reader As SqlDataReader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            Do While reader.Read()
                                list.Add(reader.GetString(0))
                                list.Add(reader.GetString(1))
                                list.Add(reader.GetString(2))
                                list.Add(reader.GetString(3))
                                list.Add(reader.GetString(4))
                            Loop
                        Else
                            list.Add("")
                            list.Add("")
                            list.Add("")
                            list.Add("")
                            list.Add("")
                        End If
                        reader.Close()
                        con.Close()
                    Catch ex As SqlException
                        con.Close()
                        Dim er As SqlError
                        For Each er In ex.Errors
                            MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Next
                    Catch ex As Exception
                        con.Close()
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End Try

                    '''''''''''''''''''''''''''''''

                    dgw_pagar.Rows.Add((dgw_pagar.RowCount + 1).ToString("0000"), OFR.DGW_CAB.Item(0, K).Value.ToString, OFR.DGW_CAB.Item(2, K).Value.ToString, OFR.DGW_CAB.Item(3, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(11, K).Value.ToString, imp_pago, OFR.DGW_CAB.Item(8, K).Value.ToString, OFR.DGW_CAB.Item(6, K).Value.ToString, OFR.DGW_CAB.Item(10, K).Value.ToString, txt_cambio_pago.Text, OFR.DGW_CAB.Item(5, K).Value.ToString, OFR.DGW_CAB.Item(4, K).Value.ToString, OFR.DGW_CAB.Item(14, K).Value.ToString, OFR.DGW_CAB.Item(5, K).Value.ToString, COD_CC, COD_CONTROL, COD_PROYECTO, OFR.DGW_CAB.Item(15, K).Value.ToString, OFR.DGW_CAB.Item(16, K).Value.ToString, OFR.DGW_CAB.Item(17, K).Value.ToString, "0", "S", "", "", "P", list.Item(0), list.Item(1), list.Item(2), list.Item(3), list.Item(4))
                End If
            End If
            K += 1
        Loop
        HALLAR_TOTAL()
    End Sub
    Sub INSERTAR_DGW_PAGO()
        Dim ITEM0 As String
        Dim CTE As String = "0"
        Dim impsoles, impdolares As Decimal
        Dim impsolesT, impdolaresT As Decimal
        cod_ref = obj.COD_DOC(cbo_tipo_ref.Text)
        '-------------------llena detalles
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_pagar.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            Dim cod_doc22 As String = (dgw_pagar.Item(1, I).Value)

            Select Case dgw_pagar.Item(8, I).Value.ToString
                Case "D"
                    impdolares = Math.Round(Double.Parse(dgw_pagar.Item(6, I).Value), 2)
                    impsoles = Math.Round(Double.Parse(dgw_pagar.Item(6, I).Value * txt_cambio_pago.Text), 2)
                Case "S"
                    impdolares = Math.Round(Double.Parse(dgw_pagar.Item(6, I).Value / txt_cambio_pago.Text), 2)
                    impsoles = Math.Round(Double.Parse(dgw_pagar.Item(6, I).Value), 2)
                Case "A"
                    impdolares = 0
                    impsoles = Math.Round(Double.Parse(dgw_pagar.Item(6, I).Value), 2)
            End Select
            impdolaresT = impdolaresT + impdolares
            impsolesT = impsolesT + impsoles
            dgw_mov.Rows.Add(COD_MP, cod_doc22, (dgw_pagar.Item(2, I).Value), dtp_mp.Value, (dgw_pagar.Item(3, I).Value), (dgw_pagar.Item(4, I).Value), (dgw_pagar.Item(5, I).Value), (dgw_pagar.Item(9, I).Value), (dgw_pagar.Item(7, I).Value), (dgw_pagar.Item(8, I).Value), txt_cambio_pago.Text, (dgw_pagar.Item(12, I).Value), (dgw_pagar.Item(13, I).Value), (dgw_pagar.Item(15, I).Value), (dgw_pagar.Item(16, I).Value), (dgw_pagar.Item(17, I).Value), CTE, (dgw_pagar.Item(14, I).Value), dgw_pagar.Item(18, I).Value, (dgw_pagar.Item(19, I).Value), (dgw_pagar.Item(20, I).Value), (dgw_pagar.Item(22, I).Value), (dgw_pagar.Item(23, I).Value), (dgw_pagar.Item(24, I).Value), dtp_mp.Value, "", "0", impsoles, impdolares, dgw_pagar.Item(25, I).Value.ToString)
            I += 1
        Loop
    End Sub
    Sub INSERTAR_DGW_PAGO_cobrar()
        Dim ITEM0 As String
        Dim CTE As String = "0"
        cod_ref = obj.COD_DOC(cbo_tipo_ref.Text)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_cobrar.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            Dim cod_doc22 As String = (dgw_cobrar.Item(1, I).Value)
            Dim impsoles, impdolares As Decimal
            Select Case dgw_cobrar.Item(8, I).Value.ToString
                Case "D"
                    impdolares = dgw_cobrar.Item(6, I).Value
                    impsoles = Math.Round(Double.Parse(dgw_cobrar.Item(6, I).Value * txt_cambio_pago.Text), 2)
                Case "S"
                    impdolares = Math.Round(Double.Parse(dgw_cobrar.Item(6, I).Value / txt_cambio_pago.Text), 2)
                    impsoles = dgw_cobrar.Item(6, I).Value
                Case "A"
                    impdolares = 0
                    impsoles = dgw_cobrar.Item(6, I).Value
            End Select
            dgw_mov.Rows.Add(COD_MP, cod_doc22, (dgw_cobrar.Item(2, I).Value), dtp_mp.Value, (dgw_cobrar.Item(3, I).Value), (dgw_cobrar.Item(4, I).Value), (dgw_cobrar.Item(5, I).Value), (dgw_cobrar.Item(9, I).Value), (dgw_cobrar.Item(7, I).Value), (dgw_cobrar.Item(8, I).Value), txt_cambio_pago.Text, (dgw_cobrar.Item(12, I).Value), (dgw_cobrar.Item(13, I).Value), (dgw_cobrar.Item(15, I).Value), (dgw_cobrar.Item(16, I).Value), (dgw_cobrar.Item(17, I).Value), CTE, (dgw_cobrar.Item(14, I).Value), (dgw_cobrar.Item(18, I).Value), (dgw_cobrar.Item(19, I).Value), (dgw_cobrar.Item(20, I).Value), (dgw_cobrar.Item(22, I).Value), (dgw_cobrar.Item(23, I).Value), (dgw_cobrar.Item(24, I).Value), dtp_mp.Value, ITEM0, "0", impsoles, impdolares, dgw_cobrar.Item(25, I).Value.ToString)
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
            '-----------------------------------------------------------------------
            If (dgw_mov.Item(26, I).Value.ToString = "1") Then
                VAR_PRO00 = "0"
            Else
                VAR_PRO00 = dgw_mov.Item(21, I).Value.ToString
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, dgw_mov.Item(1, I).Value, dgw_mov.Item(2, I).Value, dgw_mov.Item(4, I).Value, dgw_mov.Item(6, I).Value, (I + 1).ToString("0000"), (dgw_mov.Item(3, I).Value), (dgw_mov.Item(22, I).Value), (dgw_mov.Item(23, I).Value), (dgw_mov.Item(24, I).Value), (dgw_mov.Item(11, I).Value), (dgw_mov.Item(12, I).Value), SOLES, DOLARES, (dgw_mov.Item(7, I).Value), (dgw_mov.Item(9, I).Value), (dgw_mov.Item(10, I).Value), (dgw_mov.Item(13, I).Value), (dgw_mov.Item(14, I).Value), (dgw_mov.Item(15, I).Value), " ", (dgw_mov.Item(17, I).Value), "0", "", "", "0", dgw_mov.Item(29, I).Value, "0", dgw_mov.Item(26, I).Value.ToString, "", dgw_mov.Item(23, I).Value.ToString, (dgw_mov.Item(3, I).Value), (I + 1).ToString("0000"), "", "N", dtp_com.Value, 0, NOMBRE_PC)
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
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_TRANSFERENCIA_CTAS", con)
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
            'comand1.ExecuteNonQuery()
            ESTADO = comand1.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Return ESTADO
    End Function
    Sub LIMPIAR_COMPROBANTE()
        Panel_doc00.Enabled = True
        btn_grabar_pago01.Enabled = True
        GroupBox1.Enabled = True
        g_cab.Enabled = True
        txt_nro_comp.Clear()
        Dim DESC_COM As String = cbo_com.Text
        cbo_com.SelectedIndex = -1
        cbo_com.Text = DESC_COM
        dgw_mov.Rows.Clear()
        dgw_pagar.Rows.Clear()
        dgw_cobrar.Rows.Clear()
        Button1.Enabled = False
        Panel_doc.Visible = True
        Panel_det.Visible = False
        dtp_com.Value = FECHA_GRAL
        txt_cod1.Clear()
        txt_desc_per.Clear()
        txt_nro_doc_per.Clear()
        txt_cod_cta.Clear()
        txt_desc_cta.Clear()
        'txt_cambio_pago.Text = "0.0000"
        '----------------------------------------
        txt_debe_soles.Text = "0.00"
        txt_debe_dolares.Text = "0.00"
        txt_haber_soles.Text = "0.00"
        txt_haber_dolares.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        txt_saldo_dolares.Text = "0.00"
    End Sub
    Sub LIMPIAR_DETALLES()
        btn_doc_pte.Enabled = True
        Dim CONT As IEnumerator
        Try
            CONT = GroupBox3.Controls.GetEnumerator
            Do While CONT.MoveNext
                Dim text As Object = (CONT.Current)
                If TypeOf [text] Is TextBox Then
                    text.text = ""
                    'text.ENABLED = True
                End If
                If TypeOf [text] Is ComboBox Then
                    text.SelectedIndex = -1
                    'text.ENABLED = True
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
        cbo_moneda1.Text = cbo_moneda_pago.Text
        txt_imp_soles.Text = "0.00"
        btn_guardar.Visible = True
        cbo_tipo_ref.SelectedIndex = -1
        txt_cod1.Enabled = True
        txt_desc_per.Enabled = True
        txt_nro_doc_per.Enabled = True
        txt_nro_ref.Clear()
    End Sub
    Sub LIMPIAR_PAGO()
        dtp_mp.Value = FECHA_GRAL
        TXT_PAGO.Text = "0.00"
        'dgw_pagar.Rows.Clear()
        Panel_doc.Enabled = True
        Panel_det.Visible = False
        STATUS_DOC = "CP"
        btn_grabar_pago01.Visible = True
        txt_debe_soles.Text = "0.00"
        txt_debe_dolares.Text = "0.00"
        txt_haber_soles.Text = "0.00"
        txt_haber_dolares.Text = "0.00"
        txt_saldo_soles.Text = "0.00"
        txt_saldo_dolares.Text = "0.00"
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
            DGW_PER.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            DGW_PER.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            DGW_PER.Columns.Item(0).Width = &H37
            DGW_PER.Columns.Item(1).Width = 330
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        txt_glosa.Focus()
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
        Dim CONT As Integer = (dgw_pagar.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If (((COD_DOC0 = dgw_pagar.Item(1, I).Value.ToString) And (NRO_DOC0 = dgw_pagar.Item(2, I).Value.ToString)) And (COD_PER0 = dgw_pagar.Item(3, I).Value.ToString)) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
    Private Sub cbo_tipo_doc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_tipo_doc.SelectedIndexChanged
        If S_TIPO = "P" Then
            If cbo_tipo_doc.SelectedIndex <> -1 Then
                COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
                DH_GRID = obj.COD_D_H(COD_DOC)
            End If
        ElseIf S_TIPO = "C" Then
            If cbo_tipo_doc.SelectedIndex <> -1 Then
                COD_DOC = obj.COD_DOC(cbo_tipo_doc.Text)
                COD_D_H = obj.COD_D_H(COD_DOC)
                If COD_D_H = "D" Then
                    DH_GRID = "H"
                Else
                    DH_GRID = "D"
                End If
            End If
        End If
    End Sub
    Private Sub cbo_moneda_pago_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_moneda_pago.SelectedIndexChanged
        If (cbo_moneda_pago.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Private Sub txt_cambio_pago_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cambio_pago.LostFocus
        If (Strings.Trim(txt_cambio_pago.Text) <> "") Then
            Try
                txt_cambio_pago.Text = (obj.HACER_CAMBIO(txt_cambio_pago.Text))
            Catch ex As Exception
                txt_cambio_pago.Text = "0.0000"
            End Try
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dgw_mov.Rows.Clear()
        dgw_pagar.Rows.Clear()
        dgw_cobrar.Rows.Clear()
        GroupBox1.Enabled = True
        numeracion()
        Panel_doc00.Enabled = True
        Button1.Enabled = False
        btn_grabar_pago01.Enabled = True
        btn_nuevo_doc.Focus()
    End Sub
    Private Sub dgw_pagar_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_pagar.CellClick
        monto = dgw_pagar.Item(6, dgw_pagar.CurrentRow.Index).Value
    End Sub
    Private Sub dgw_pagar_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_pagar.CellEndEdit
        Dim FILA_DET As Integer = dgw_pagar.CurrentRow.Index
        Select Case dgw_pagar.CurrentCell.ColumnIndex
            Case 6
                Try
                    If dgw_pagar.Item(6, FILA_DET).Value < monto Then
                        dgw_pagar.Item(6, FILA_DET).Value = obj.HACER_DECIMAL(dgw_pagar.Item(6, FILA_DET).Value)
                    Else
                        dgw_pagar.Item(6, FILA_DET).Value = monto
                    End If
                Catch ex As Exception
                    dgw_pagar.Item(6, FILA_DET).Value = obj.HACER_DECIMAL(monto)
                End Try
                Exit Select
        End Select
        HALLAR_TOTAL()
    End Sub
    Private Sub dgw_cobrar_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cobrar.CellClick
        monto = dgw_cobrar.Item(6, dgw_cobrar.CurrentRow.Index).Value
    End Sub
    Private Sub dgw_cobrar_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cobrar.CellEndEdit
        Dim FILA_DET As Integer = dgw_cobrar.CurrentRow.Index
        Select Case dgw_cobrar.CurrentCell.ColumnIndex
            Case 6
                Try
                    If dgw_cobrar.Item(6, FILA_DET).Value < monto Then
                        dgw_cobrar.Item(6, FILA_DET).Value = obj.HACER_DECIMAL(dgw_cobrar.Item(6, FILA_DET).Value)
                    Else
                        dgw_cobrar.Item(6, FILA_DET).Value = monto
                    End If
                Catch ex As Exception
                    dgw_cobrar.Item(6, FILA_DET).Value = obj.HACER_DECIMAL(monto)
                End Try
                Exit Select
        End Select
        HALLAR_TOTAL()
    End Sub
    Private Sub dgw_pagar_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_pagar.CellEnter
        monto = dgw_pagar.Item(6, dgw_pagar.CurrentRow.Index).Value
    End Sub
    Private Sub dgw_cobrar_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_cobrar.CellEnter
        monto = dgw_cobrar.Item(6, dgw_cobrar.CurrentRow.Index).Value
    End Sub
    Private Sub dtp_mp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_mp.LostFocus
        If (cbo_moneda_pago.SelectedIndex <> -1) Then
            COD_MONEDA = cbo_moneda_pago.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), "D")
            Else
                txt_cambio_pago.Text = obj.SACAR_CAMBIO(dtp_mp.Value.Year, dtp_mp.Value.ToString("MM"), dtp_mp.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ''------------------------------------------------------------------------------------------------------------
        If TabControl2.SelectedIndex = 0 Then
            PERSONAS()
            S_TIPO = "P"
            Label11.Text = "Proveedor"

            Try
                Dim i As Integer = dgw_pagar.CurrentRow.Index
            Catch ex As Exception
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
            LIMPIAR_DETALLES()
            txt_cod1.Enabled = False
            txt_desc_per.Enabled = False
            txt_nro_doc_per.Enabled = False
            btn_guardar.Visible = False
            Button3.Visible = True
            btn_doc_pte.Enabled = False

            TXT_ITEM0.Text = (dgw_pagar.CurrentRow.Index)
            CARGAR_DETALLES00(TXT_ITEM0.Text)
            Panel_det.Visible = True
            txt_imp_soles.Focus()



        ElseIf TabControl2.SelectedIndex = 1 Then
            PERSONAS_cobrar()
            S_TIPO = "C"
            Label11.Text = "Cliente"
            Try
                Dim i As Integer = dgw_cobrar.CurrentRow.Index
            Catch ex As Exception
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
            LIMPIAR_DETALLES()
            txt_cod1.Enabled = False
            txt_desc_per.Enabled = False
            txt_nro_doc_per.Enabled = False
            btn_guardar.Visible = False
            Button3.Visible = True
            btn_doc_pte.Enabled = False

            TXT_ITEM0.Text = (dgw_cobrar.CurrentRow.Index)
            CARGAR_DETALLES01(TXT_ITEM0.Text)
            Panel_det.Visible = True
            txt_imp_soles.Focus()

        End If
        '------------------------------------------------------------------------------------------------------------

    End Sub
    Sub CARGAR_DETALLES00(ByVal FILA0 As Object)
        VAR_PRO = dgw_pagar.Item(22, Integer.Parse(FILA0)).Value.ToString
        COD_DOC = dgw_pagar.Item(1, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc.Text = dgw_pagar.Item(2, Integer.Parse(FILA0)).Value.ToString
        txt_cod1.Text = dgw_pagar.Item(3, Integer.Parse(FILA0)).Value.ToString
        txt_desc_per.Text = dgw_pagar.Item(4, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc_per.Text = dgw_pagar.Item(5, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = dgw_pagar.Item(7, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = (obj.HACER_DECIMAL(txt_imp_soles.Text))
        COD_MON_DOC = dgw_pagar.Item(8, Integer.Parse(FILA0)).Value.ToString
        txt_glosa.Text = dgw_pagar.Item(12, Integer.Parse(FILA0)).Value.ToString
        txt_cod_cta.Text = dgw_pagar.Item(13, Integer.Parse(FILA0)).Value.ToString
        txt_desc_cta.Text = obj.DESC_CUENTA(txt_cod_cta.Text, AÑO)
        COD_CC = dgw_pagar.Item(15, Integer.Parse(FILA0)).Value.ToString
        COD_CONTROL = dgw_pagar.Item(16, Integer.Parse(FILA0)).Value.ToString
        COD_PROYECTO = dgw_pagar.Item(17, Integer.Parse(FILA0)).Value.ToString
        STATUS_CC = dgw_pagar.Item(18, Integer.Parse(FILA0)).Value.ToString
        STATUS_P = dgw_pagar.Item(20, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_doc.Text = obj.DESC_DOC(COD_DOC)
        'CBO_D_H.Text = dgw_pagar.Item(9, Integer.Parse(FILA0)).Value.ToString
        cbo_moneda1.Text = obj.DESC_MONEDA(COD_MON_DOC)
        CBO_CC.Text = obj.DESC_CC(COD_CC)
        cbo_control.Text = obj.DESC_CONTROL(COD_CONTROL)
        cbo_proyecto.Text = obj.DESC_PROYECTO(COD_PROYECTO)
        cod_ref = dgw_pagar.Item(23, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_ref.Text = obj.DESC_DOC(cod_ref)
        txt_nro_ref.Text = dgw_pagar.Item(24, Integer.Parse(FILA0)).Value.ToString
    End Sub
    Sub CARGAR_DETALLES01(ByVal FILA0 As Object)
        VAR_PRO = dgw_cobrar.Item(22, Integer.Parse(FILA0)).Value.ToString
        COD_DOC = dgw_cobrar.Item(1, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc.Text = dgw_cobrar.Item(2, Integer.Parse(FILA0)).Value.ToString
        txt_cod1.Text = dgw_cobrar.Item(3, Integer.Parse(FILA0)).Value.ToString
        txt_desc_per.Text = dgw_cobrar.Item(4, Integer.Parse(FILA0)).Value.ToString
        txt_nro_doc_per.Text = dgw_cobrar.Item(5, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = dgw_cobrar.Item(7, Integer.Parse(FILA0)).Value.ToString
        txt_imp_soles.Text = (obj.HACER_DECIMAL(txt_imp_soles.Text))
        COD_MON_DOC = dgw_cobrar.Item(8, Integer.Parse(FILA0)).Value.ToString
        txt_glosa.Text = dgw_cobrar.Item(12, Integer.Parse(FILA0)).Value.ToString
        txt_cod_cta.Text = dgw_cobrar.Item(13, Integer.Parse(FILA0)).Value.ToString
        txt_desc_cta.Text = obj.DESC_CUENTA(txt_cod_cta.Text, AÑO)
        COD_CC = dgw_cobrar.Item(15, Integer.Parse(FILA0)).Value.ToString
        COD_CONTROL = dgw_cobrar.Item(16, Integer.Parse(FILA0)).Value.ToString
        COD_PROYECTO = dgw_cobrar.Item(17, Integer.Parse(FILA0)).Value.ToString
        STATUS_CC = dgw_cobrar.Item(18, Integer.Parse(FILA0)).Value.ToString
        STATUS_P = dgw_cobrar.Item(20, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_doc.Text = obj.DESC_DOC(COD_DOC)
        'CBO_D_H.Text = dgw_cobrar.Item(9, Integer.Parse(FILA0)).Value.ToString
        cbo_moneda1.Text = obj.DESC_MONEDA(COD_MON_DOC)
        CBO_CC.Text = obj.DESC_CC(COD_CC)
        cbo_control.Text = obj.DESC_CONTROL(COD_CONTROL)
        cbo_proyecto.Text = obj.DESC_PROYECTO(COD_PROYECTO)
        cod_ref = dgw_cobrar.Item(23, Integer.Parse(FILA0)).Value.ToString
        cbo_tipo_ref.Text = obj.DESC_DOC(cod_ref)
        txt_nro_ref.Text = dgw_cobrar.Item(24, Integer.Parse(FILA0)).Value.ToString
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txt_cod1.Text.Trim = "" Then
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
        ElseIf txt_glosa.Text.Trim = "" Then
            MessageBox.Show("Debe insertar la Glosa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_glosa.Focus()
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
                If cbo_tipo_ref.SelectedIndex <> -1 Then
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
                '---------------------------------------------------------------------
                If TabControl2.SelectedIndex = 0 Then

                    dgw_pagar.Item(6, FILA0).Value = txt_imp_soles.Text
                    dgw_pagar.Item(7, FILA0).Value = IMP_S
                    dgw_pagar.Item(8, FILA0).Value = COD_MON_DOC
                    'dgw_pagar.Item(9, FILA0).Value = CBO_D_H.Text
                    dgw_pagar.Item(11, FILA0).Value = dtp_mp.Value.Date
                    dgw_pagar.Item(12, FILA0).Value = txt_glosa.Text
                    dgw_pagar.Item(13, FILA0).Value = txt_cod_cta.Text
                    dgw_pagar.Item(15, FILA0).Value = COD_CC
                    dgw_pagar.Item(16, FILA0).Value = COD_CONTROL
                    dgw_pagar.Item(17, FILA0).Value = COD_PROYECTO
                    dgw_pagar.Item(23, FILA0).Value = cod_ref
                    dgw_pagar.Item(24, FILA0).Value = txt_nro_ref.Text
                    '---------------------------------------------------------------------
                ElseIf TabControl2.SelectedIndex = 1 Then
                    dgw_cobrar.Item(6, FILA0).Value = txt_imp_soles.Text
                    dgw_cobrar.Item(7, FILA0).Value = IMP_S
                    dgw_cobrar.Item(8, FILA0).Value = COD_MON_DOC
                    'dgw_cobrar.Item(9, FILA0).Value = CBO_D_H.Text
                    dgw_cobrar.Item(11, FILA0).Value = dtp_mp.Value.Date
                    dgw_cobrar.Item(12, FILA0).Value = txt_glosa.Text
                    dgw_cobrar.Item(13, FILA0).Value = txt_cod_cta.Text
                    dgw_cobrar.Item(15, FILA0).Value = COD_CC
                    dgw_cobrar.Item(16, FILA0).Value = COD_CONTROL
                    dgw_cobrar.Item(17, FILA0).Value = COD_PROYECTO
                    dgw_cobrar.Item(23, FILA0).Value = cod_ref
                    dgw_cobrar.Item(24, FILA0).Value = txt_nro_ref.Text
                End If
                '---------------------------------------------------------------------
                HALLAR_TOTAL()
                Panel_det.Visible = False
                btn_nuevo_doc.Focus()
            End If
        End If
    End Sub


    Private Sub txt_glosa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_glosa.LostFocus
        If btn_guardar.Visible = True Then
            btn_guardar.Focus()
        ElseIf Button3.Visible = True Then
            Button3.Focus()
        End If

    End Sub
End Class