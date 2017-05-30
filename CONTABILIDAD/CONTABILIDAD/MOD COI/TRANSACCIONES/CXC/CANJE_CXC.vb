Imports System.Data.SqlClient
Public Class CANJE_CXC
    Dim COD_AUX, BOTON, ORIGEN, ESTADO_CTA, COD_COMP, COD_DH_DOC, COD_DH_GRAL, COD_MONEDA, DESTINO As String
    Dim DT_DET As New DataTable
    Dim obj As New Class1
    Dim monto As Decimal
    Private ValidarFicha As Boolean = True

    Private Sub btn_buscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar.Click
        txt_letra.Focus()
        Dim CONT As Integer = dgw1.RowCount - 1
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw1.Item(10, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra.Text.ToLower = Strings.Mid(dgw1.Item(10, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(10)
                    Exit Do
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
        ch_saldo.Enabled = False
        ch_saldo.Checked = False
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
        g_cab.Enabled = False
        BTN_GRABAR.Visible = False
        dgw_det.ReadOnly = True
        DGW_DET2.ReadOnly = True
        gb_doc.Enabled = False
        TabControl1.SelectedTab = TabPage2
        btn_imprimir.Enabled = True
        btn_imprimir.Focus()
        ValidarFicha = True
    End Sub
    Private Sub btn_doc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_doc.Click
        If cbo_aux.SelectedIndex = -1 Then
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
        ElseIf (Strings.Trim(TXT_COD.Text) = "") Then
            MessageBox.Show("Debe elegir al Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_COD.Focus()
        ElseIf Panel_PER.Visible Then
            MessageBox.Show("Debe elegir al Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw_per.Focus()
        ElseIf (CBO_MONEDA.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_MONEDA.Focus()
        ElseIf (txt_nro_ini.Text = "") Then
            MessageBox.Show("Ingreso el Nº de Doc. Inicial", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_ini.Focus()
        ElseIf (txt_cuota.Text = "") Then
            MessageBox.Show("Ingreso el Nº de Cuotas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cuota.Focus()
        ElseIf (txt_dia.Text = "") Then
            MessageBox.Show("Ingreso el Nº de Días", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_dia.Focus()
        ElseIf (Decimal.Parse(obj.VALIDAR_FECHA_DOC(dtp_doc.Value)) = 0) Then
            dtp_doc.Focus()
        ElseIf ((Strings.Trim(TXT_TC2.Text) = "") Or (Decimal.Compare(Decimal.Parse(TXT_TC2.Text), Decimal.Zero) = 0)) Then
            MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_TC2.Focus()
        Else
            Dim l As Long = 1
            Dim ini As Long = Long.Parse(txt_nro_ini.Text)
            Dim nro_cuotas As Long = Long.Parse(txt_cuota.Text)
            Dim nro_doc01 As Long = ini
            Do While (l <> nro_cuotas)
                If obj.VERIFICAR_PCTAS_COBRAR("30", nro_doc01, TXT_COD.Text, txt_doc_per.Text, txt_origen.Text) = False Then
                    MessageBox.Show("El Documento ya existe, eliga otro Nº Inicial", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_nro_ini.Focus()
                    Return
                End If
                nro_doc01 = (nro_doc01 + 1)
                l = (l + 1)
            Loop
            CARGAR_PCTAS_COBRAR()
            If (dgw_det.Rows.Count = 0) Then
                MessageBox.Show("La persona no tiene Ctas. Pendientes con la cuenta de origen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                TXT_COD.Enabled = False
                TXT_DESC.Enabled = False
                txt_doc_per.Enabled = False
                txt_destino.Enabled = False
                CBO_MONEDA.Enabled = False
            End If
        End If
        ch_saldo.Enabled = True
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        CARGAR_COMPROBANTE()
        If VERIFICAR_LETRA() Then
            Dim NRO_PLAN As String = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
            If (Decimal.Parse((CInt(MessageBox.Show(("Esta seguro de eliminar el Comprobante Nº " & NRO_PLAN), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                Dim estado As String = "FALLO"
                Dim cod_aux00 As String = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
                Dim cod_com00 As String = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
                Dim nro_com00 As String = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
                If obj.VERIFICAR_TRANSF_ANALISIS(COD_AUX, COD_COMP, txt_nro_comp.Text, AÑO, MES) = False Then
                    MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                Try
                    Dim cmd As New SqlCommand("ELIMINAR_I_CON_CXC_CANJE", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
                    cmd.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
                    cmd.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
                    cmd.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
                    cmd.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
                    cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                    cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
                    cmd.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
                    con.Open()
                    estado = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    estado = "FALLO"
                End Try
                DATAGRID()
                If (estado = "FALLO") Then
                    MessageBox.Show("Ocurrio un Error Vuelva a Intentarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        End If
    End Sub
    Private Sub btn_generar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_generar.Click
        If txt_nro_ini.Text = "" Then MessageBox.Show("Ingreso el Nº de Doc. Inicial", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ini.Focus() : Exit Sub
        If txt_cuota.Text = "" Then MessageBox.Show("Ingreso el Nº de Cuotas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cuota.Focus() : Exit Sub
        If txt_dia.Text = "" Then MessageBox.Show("Ingreso el Nº de Días", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_dia.Focus() : Exit Sub
        '-----------------------------------------------------
        If (Decimal.Parse(txt_total.Text) = 0) Then
            MessageBox.Show("El Total de Documentos es 0", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl2.SelectedTab = TabPage3
            Exit Sub
        Else
            GENERAR_LETRAS()
            HALLAR_TOTAL_LETRAS()
        End If
        btn_generar.Enabled = False
        ch_saldo.Enabled = False
        ch_saldo.Checked = False
        '-----------------------------------------------------
    End Sub
    Private Sub BTN_GRABAR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_GRABAR.Click
        If (dgw_det.Rows.Count = 0) Then
            MessageBox.Show("Canje de Letras sin detalles de Documentos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (DGW_DET2.Rows.Count = 0) Then
            MessageBox.Show("Canje sin Detalles de Letras", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            HALLAR_TOTAL_LETRAS()
            HALLAR_TOTAL()
            If VERIFICAR_GENERACION_LETRAS() = False Then Exit Sub

            txt_nro_comp.Text = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)

            If (txt_total.Text <> txt_total2.Text) Then
                MessageBox.Show("El importe Total de Letras no coincide con el Total a Pagar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf (Decimal.Parse(TXT_TC2.Text) = 0) Then
                MessageBox.Show("Debe ingresar el Tipo de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_TC2.Focus()
            ElseIf (INSERTAR_TODO() = "FALLO") Then
                txt_nro_comp.Text = obj.HALLAR_NRO_COMP_ACTUAL(COD_AUX, COD_COMP, AÑO, MES)
                obj.ELIMINAR_TEMPORAL("TCON")
                MessageBox.Show("Vuelva a Intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("El Canje de guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
                dgw_det.Enabled = False
                DGW_DET2.Enabled = False
                gb_doc.Enabled = False
                BTN_GRABAR.Enabled = False
                btn_nuevo2.Enabled = True
                btn_imprimir.Enabled = True
                btn_nuevo2.Focus()
            End If
        End If
        ch_saldo.Checked = False
        ch_saldo.Enabled = False
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        BOTON = "NUEVO"
        ValidarFicha = False
        TabControl1.SelectedTab = TabPage2
        LIMPIAR_COMPROBANTE()
        cbo_aux.Focus()
        ValidarFicha = True
    End Sub
    Private Sub btn_nuevo2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo2.Click
        LIMPIAR_COMPROBANTE22()
        cbo_aux.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(125) = 0
        Close()
    End Sub

    Private Sub CANJE_CXC_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = True
        End If
    End Sub

    Private Sub CANJE_CXC_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If TabControl1.SelectedIndex <> 0 Then
            ValidarFicha = False
        End If
    End Sub

    Private Sub CANJE_DOC_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CANJE_DOC_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CBO_AUXILIAR()
        CARGAR_PERSONAS()
        CARGAR_CUENTAS()
        CARGAR_MONEDA()
        CREAR_DATASET()
        COD_DH_GRAL = obj.COD_D_H("LT")
        If (COD_DH_GRAL = "H") Then
            COD_DH_GRAL = "D"
            'Else
            '    COD_DH_GRAL = "D"
        End If
        dgw_det.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_DET2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
    End Sub
    Sub CARGAR_COMPROBANTE()
        COD_AUX = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        COD_COMP = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_com.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        dtp_com.Value = DateTime.Parse((dgw1.Item(5, dgw1.CurrentRow.Index).Value))
        TXT_COD.Text = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        TXT_DESC.Text = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        txt_doc_per.Text = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString
        txt_cuota.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        dgw_det.Rows.Clear()
        DGW_DET2.Rows.Clear()
        Dim ORIGEN0 As String = ""
        Dim DESTINO0 As String = ""
        Dim TC0 As New Decimal
        Dim FECHA0 As DateTime = Now.Date
        Dim VEN0 As DateTime = Now.Date
        Try
            Dim PRO_02 As New SqlCommand("MOSTRAR_T_CON_CXC_CANJE", con)
            PRO_02.CommandType = CommandType.StoredProcedure
            PRO_02.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            PRO_02.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP
            PRO_02.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            PRO_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            PRO_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            con.Open()
            PRO_02.ExecuteNonQuery()
            Dim RS3 As SqlDataReader = PRO_02.ExecuteReader
            Do While RS3.Read
                If RS3.GetValue(10) = "A" Then
                Else
                    If (RS3.GetString(0) = "LT") Then
                        VEN0 = Date.Parse(RS3.GetValue(9))
                        FECHA0 = Date.Parse(RS3.GetValue(3))
                        DGW_DET2.Rows.Add((DGW_DET2.RowCount + 1).ToString("00"), Rs3.GetValue(2), ((DGW_DET2.RowCount + 1).ToString("00") & "/" & txt_cuota.Text), DateDiff("d", FECHA0, VEN0), Rs3.GetValue(9), Rs3.GetValue(6))
                        COD_MONEDA = Rs3.GetValue(10)
                        DESTINO0 = (RS3.GetValue(11))
                        TC0 = Decimal.Parse(RS3.GetValue(12))
                    Else

                        'Buscar Auxiliar, comprobante
                        Dim list As New List(Of String)
                        'con.Open()
                        Dim cmd2 As New SqlCommand("OBTENER_AUXILIAR_COMP_INGRESO", con)
                        cmd2.CommandType = (CommandType.StoredProcedure)
                        Dim codPer As String = TXT_COD.Text
                        Dim nroDoc As String = RS3.GetValue(2)
                        Dim codDoc As String = RS3.GetValue(0)
                        cmd2.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = codPer
                        cmd2.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
                        cmd2.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
                        Dim reader As SqlDataReader = cmd2.ExecuteReader()

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
                        ' con.Close()
                        '''''''''''''''''''''''''''''''

                        dgw_det.Rows.Add((RS3.GetValue(0)), RS3.GetValue(1), RS3.GetValue(2), RS3.GetValue(3), RS3.GetValue(4), RS3.GetValue(5), RS3.GetValue(6), RS3.GetValue(7), RS3.GetValue(8), RS3.GetValue(9), list.Item(0), list.Item(1), list.Item(2), list.Item(3), list.Item(4))
                        ORIGEN0 = (RS3.GetValue(11))
                    End If
                End If
                txt_glosa.Text = RS3.GetString(13)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        dtp_doc.Value = FECHA0
        CBO_MONEDA.SelectedValue = COD_MONEDA
        TXT_TC2.Text = (TC0)
        txt_origen.Text = ORIGEN0
        txt_destino.Text = DESTINO0
        HALLAR_TOTAL()
        HALLAR_TOTAL_LETRAS()
    End Sub
    Sub CARGAR_CUENTAS()
        Try
            Dim pro As New SqlCommand("DGW_CUENTA8_ANA", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            pro.Parameters.Add("@TIPO_CUENTA", SqlDbType.Char).Value = "C"
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt2 As New DataTable("Cuentas")
            Prog00.Fill(dt2)
            dgw_cuenta.DataSource = dt2
            dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cuenta.Columns.Item(0).Width = &H4B
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_MONEDA()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        CBO_MONEDA.DataSource = DT
        CBO_MONEDA.DisplayMember = DT.Columns.Item(0).ToString
        CBO_MONEDA.ValueMember = DT.Columns.Item(1).ToString
        CBO_MONEDA.SelectedIndex = -1
    End Sub
    Sub CARGAR_PCTAS_COBRAR()
        dgw_det.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PCTAS_COBRAR_CANJE", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@cod_per", SqlDbType.Char).Value = TXT_COD.Text
            cmd.Parameters.Add("@nro_doc_per", SqlDbType.Char).Value = txt_doc_per.Text
            cmd.Parameters.Add("@cod_moneda", SqlDbType.Char).Value = COD_MONEDA
            cmd.Parameters.Add("@cUENta_origen", SqlDbType.Char).Value = txt_origen.Text
            cmd.Parameters.Add("@fecha_doc", SqlDbType.DateTime).Value = FECHA_GRAL
            'dtp_doc.Value.AddDays(-30)
            con.Open()
            cmd.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = cmd.ExecuteReader
            Do While Rs3.Read

                'Buscar Auxiliar, comprobante
                Dim list As New List(Of String)


                'con.Open()
                Dim cmd2 As New SqlCommand("OBTENER_AUXILIAR_COMP_INGRESO", con)
                cmd2.CommandType = (CommandType.StoredProcedure)
                Dim codPer As String = TXT_COD.Text
                Dim nroDoc As String = Rs3.GetValue(2)
                Dim codDoc As String = Rs3.GetValue(0)
                cmd2.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = codPer
                cmd2.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = nroDoc
                cmd2.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
                Dim reader As SqlDataReader = cmd2.ExecuteReader()

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
                ' con.Close()


                '''''''''''''''''''''''''''''''

                dgw_det.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), False, Rs3.GetValue(7), Rs3.GetValue(8), list.Item(0), list.Item(1), list.Item(2), list.Item(3), list.Item(4))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        HALLAR_TOTAL()
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            dgw_per.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = &H37
            dgw_per.Columns.Item(1).Width = 240
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
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
    Private Sub CBO_MONEDA_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBO_MONEDA.SelectedIndexChanged
        If (CBO_MONEDA.SelectedIndex <> -1) Then
            COD_MONEDA = CBO_MONEDA.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                TXT_TC2.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                TXT_TC2.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Private Sub ch_ca_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_ca.CheckedChanged
        If ch_ca.Checked Then
            dgw1.Sort(dgw1.Columns.Item(10), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            btn_buscar.Enabled = True
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_cod_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cod.CheckedChanged
        If ch_cod.Checked Then
            dgw1.Sort(dgw1.Columns.Item(4), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            btn_buscar.Enabled = False
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_rs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_rs.CheckedChanged
        If ch_rs.Checked Then
            dgw1.Sort(dgw1.Columns.Item(10), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            btn_buscar.Enabled = False
            txt_letra.Focus()
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
    End Sub
    Sub DATAGRID()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_ICON_CXC_CANJE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("CANJE")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Visible = False
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(9).Visible = False
            dgw1.Columns.Item(10).Visible = False
            dgw1.Columns.Item(5).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cuenta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (ESTADO_CTA = "origen") Then
                txt_origen.Text = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value)
                Panel_cuenta.Visible = False
                kl2.Focus()
            ElseIf (ESTADO_CTA = "destino") Then
                txt_destino.Text = (dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value)
                Panel_cuenta.Visible = False
                kl3.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            If (ESTADO_CTA = "origen") Then
                txt_origen.Clear()
                txt_origen.Focus()
            ElseIf (ESTADO_CTA = "destino") Then
                txt_destino.Clear()
                txt_destino.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_det_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw_det.CellClick
        If (dgw_det.CurrentCellAddress.X = 7) Then
            If dgw_det.Item(7, dgw_det.CurrentRow.Index).Value.ToString = "True" Then
                dgw_det.Item(7, dgw_det.CurrentRow.Index).Value = False
            Else
                dgw_det.Item(7, dgw_det.CurrentRow.Index).Value = True
            End If
            HALLAR_TOTAL()
        End If
        '-------------------------
        monto = dgw_det.Item(5, dgw_det.CurrentRow.Index).Value
    End Sub
    Private Sub DGW_DET2_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles DGW_DET2.CellBeginEdit
        Dim k As Integer = DGW_DET2.CurrentCellAddress.X
        Dim FILA As Integer = DGW_DET2.CurrentRow.Index
        Select Case k
            Case 3
                Try
                    DGW_DET2.Item(4, FILA).Value = dtp_doc.Value.AddDays(Decimal.Parse(DGW_DET2.Item(3, FILA).Value))
                Catch ex As Exception
                    DGW_DET2.Item(4, FILA).Value = dtp_doc.Value
                    DGW_DET2.Item(3, FILA).Value = 0
                End Try
            Case 4
                Try
                    DGW_DET2.Item(3, FILA).Value = DateDiff("d", dtp_doc.Value.Date, Date.Parse(DGW_DET2.Item(4, FILA).Value))
                Catch ex As Exception
                    DGW_DET2.Item(4, FILA).Value = dtp_doc.Value
                    DGW_DET2.Item(3, FILA).Value = 0
                End Try
            Case 5
                Try
                    DGW_DET2.Item(5, FILA).Value = (obj.HACER_DECIMAL((DGW_DET2.Item(5, FILA).Value)))
                Catch ex As Exception
                    DGW_DET2.Item(5, FILA).Value = (obj.HACER_DECIMAL("0.00"))
                End Try
                HALLAR_TOTAL_LETRAS()
        End Select
    End Sub
    Private Sub DGW_DET2_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW_DET2.CellEndEdit
        Dim k As Integer = DGW_DET2.CurrentCellAddress.X
        Dim FILA As Integer = DGW_DET2.CurrentRow.Index
        Select Case k
            Case 3
                Try
                    DGW_DET2.Item(4, FILA).Value = dtp_doc.Value.AddDays(Decimal.Parse(DGW_DET2.Item(3, FILA).Value))
                Catch ex As Exception

                    DGW_DET2.Item(4, FILA).Value = dtp_doc.Value
                    DGW_DET2.Item(3, FILA).Value = 0
                End Try
            Case 4
                Try
                    DGW_DET2.Item(3, FILA).Value = DateDiff("d", dtp_doc.Value.Date, Date.Parse(DGW_DET2.Item(4, FILA).Value))
                Catch ex As Exception
                    DGW_DET2.Item(4, FILA).Value = dtp_doc.Value
                    DGW_DET2.Item(3, FILA).Value = 0
                End Try
            Case 5
                Try
                    DGW_DET2.Item(5, FILA).Value = (obj.HACER_DECIMAL((DGW_DET2.Item(5, FILA).Value)))
                Catch ex As Exception
                    DGW_DET2.Item(5, FILA).Value = (obj.HACER_DECIMAL("0.00"))
                End Try
                HALLAR_TOTAL_LETRAS()
        End Select
    End Sub
    Private Sub DGW_PER_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD.Text = dgw_per.Item(0, dgw_per.CurrentRow.Index).Value.ToString
            TXT_DESC.Text = dgw_per.Item(1, dgw_per.CurrentRow.Index).Value.ToString
            txt_doc_per.Text = dgw_per.Item(2, dgw_per.CurrentRow.Index).Value.ToString
            txt_glosa.Text = TXT_DESC.Text
            kl1.Focus()
            Panel_PER.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER.Visible = False
            TXT_COD.Clear()
            TXT_DESC.Clear()
            txt_glosa.Clear()
            txt_doc_per.Clear()
            TXT_COD.Focus()
        End If
    End Sub
    Sub GENERAR_LETRAS()
        DGW_DET2.Rows.Clear()
        Dim cont As Integer = Integer.Parse(txt_cuota.Text)
        Dim i As Integer = 1
        Dim LETRA As Integer = Integer.Parse(txt_nro_ini.Text)
        Dim DIA As Integer = Integer.Parse(txt_dia.Text)
        Dim TOTAL As Decimal = Decimal.Parse(txt_total.Text)
        i = 1
        Do While (i <= cont)
            If (i = cont) Then
                HALLAR_TOTAL_LETRAS()
                DGW_DET2.Rows.Add(i.ToString("0000"), ((LETRA + i) - 1).ToString("00000000000"), (i.ToString("00") & "/" & cont.ToString("00")), ((i) * DIA), dtp_doc.Value.AddDays(CDbl(((i) * DIA))), (obj.HACER_DECIMAL((Decimal.Parse(txt_total.Text) - Decimal.Parse(txt_total2.Text)))))
            Else
                DGW_DET2.Rows.Add(i.ToString("0000"), ((LETRA + i) - 1).ToString("00000000000"), (i.ToString("00") & "/" & cont.ToString("00")), ((i) * DIA), dtp_doc.Value.AddDays(CDbl(((i) * DIA))), Math.Round(Decimal.Divide(TOTAL, New Decimal(cont)), 2))
            End If
            i += 1
        Loop
    End Sub
    Sub HALLAR_TOTAL()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det.Rows.Count - 1)
        Dim TOTAL As New Decimal
        I = 0
        Do While (I <= CONT)
            If dgw_det.Item(7, I).Value.ToString = "True" Then
                If dgw_det.Item(8, I).Value.ToString = "H" Then
                    TOTAL = TOTAL + dgw_det.Item(5, I).Value
                Else
                    TOTAL = TOTAL - dgw_det.Item(5, I).Value
                End If

            End If
            I += 1
        Loop
        txt_total.Text = (TOTAL)
        txt_total.Text = (obj.HACER_DECIMAL(txt_total.Text))
    End Sub
    Sub HALLAR_TOTAL_LETRAS()
        Dim TOTAL As Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW_DET2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            TOTAL = Decimal.Add(TOTAL, Decimal.Parse((DGW_DET2.Item(5, I).Value)))
            I += 1
        Loop
        txt_total2.Text = (TOTAL)
        txt_total2.Text = (obj.HACER_DECIMAL(txt_total2.Text))
    End Sub
    Function INSERTAR_TODO() As String
        Dim dolar As Decimal
        Dim sol As Decimal
        '-----------------------------------------------------
        Dim soles_debe, soles_haber As Decimal
        soles_debe = 0
        soles_haber = 0
        '-----------------------------------------------------
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        DT_DET.Rows.Clear()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_det.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            If dgw_det.Item(7, I).Value = True Then
                sol = Math.Round(Decimal.Parse(dgw_det.Item(5, I).Value), 2)
                dolar = Math.Round(sol / Decimal.Parse(TXT_TC2.Text), 2)
                If COD_MONEDA <> "S" Then
                    dolar = Math.Round(Decimal.Parse(dgw_det.Item(5, I).Value), 2)
                    sol = Math.Round(dolar * Decimal.Parse(TXT_TC2.Text), 2)
                End If
                '-------------------------------------------------
                If dgw_det.Item(8, I).Value = "D" Then
                    soles_debe = soles_debe + sol
                Else
                    soles_haber = soles_haber + sol
                End If
                '---------------------------------------------
                DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, (dgw_det.Item(0, I).Value), (dgw_det.Item(2, I).Value), TXT_COD.Text, txt_doc_per.Text, (DT_DET.Rows.Count + 1).ToString("0000"), dtp_doc.Value, "", "", dtp_doc.Value, txt_glosa.Text, txt_origen.Text, sol, dolar, (dgw_det.Item(8, I).Value), COD_MONEDA, TXT_TC2.Text, "", "", "", "", dtp_doc.Value, "0", "", "", "0", "", "", "", "", "", dtp_doc.Value, 0, "", "D", dtp_com.Value, 0, NOMBRE_PC)
            End If
            I += 1
        Loop
        I = 0
        CONT = (DGW_DET2.RowCount - 1)
        I = 0
        Do While (I <= CONT)

            sol = Math.Round(Decimal.Parse(DGW_DET2.Item(5, I).Value), 2)
            dolar = Math.Round(sol / Decimal.Parse(TXT_TC2.Text), 2)
            If COD_MONEDA <> "S" Then
                dolar = Math.Round(Decimal.Parse(DGW_DET2.Item(5, I).Value), 2)
                sol = Math.Round(dolar * Decimal.Parse(TXT_TC2.Text), 2)
            End If
            '-------------------------------------------------
            '-------------------------------------------------
            If COD_DH_GRAL = "D" Then
                soles_debe = soles_debe + sol
            Else
                soles_haber = soles_haber + sol
            End If
            '---------------------------------------------
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, "LT", (DGW_DET2.Item(1, I).Value), TXT_COD.Text, txt_doc_per.Text, (DT_DET.Rows.Count + 1).ToString("0000"), dtp_doc.Value, "", "", dtp_doc.Value, txt_glosa.Text, txt_destino.Text, sol, dolar, COD_DH_GRAL, COD_MONEDA, TXT_TC2.Text, "", "", "", "", DateTime.Parse((DGW_DET2.Item(4, I).Value)), "0", "", "", "0", "", "", "", "", "", dtp_doc.Value, 0, "", "L", dtp_com.Value, 0, NOMBRE_PC)
            I += 1
        Loop
        '------------------------------------------------------------------------------------------
        ' REGISTRO DE AJUSTE
        Dim IMP_AJUSTE As Decimal = soles_debe - soles_haber
        If IMP_AJUSTE <> 0 Then
            Dim DH As String = "H"
            Dim CTA As String = obj.DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
            If IMP_AJUSTE < 0 Then
                DH = "D"
                IMP_AJUSTE = IMP_AJUSTE * -1
                CTA = obj.DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
            End If
            DT_DET.Rows.Add(AÑO, MES, COD_AUX, COD_COMP, txt_nro_comp.Text, "00", "", TXT_COD.Text, txt_doc_per.Text, (DT_DET.Rows.Count + 1).ToString("0000"), dtp_doc.Value, "", "", dtp_doc.Value, "REDONDEO", CTA, IMP_AJUSTE, 0, DH, "A", TXT_TC2.Text, "", "", "", "", dtp_doc.Value.Date.AddDays(txt_dia.Text), "0", "", "", "0", "", "", "", "", "", dtp_doc.Value, 0, "", "A", dtp_com.Value, 0, NOMBRE_PC)
            'DT_DET.Colu    AÑO MES COD_AUX COD_COMP        NRO_COMP     COD_DOC NRO COD_PER        NRO_DOC_PER         ITEM                                    FECHA_DOC     REF NRO  FECHA_REF      GLOSA   COD_CTA  IMP_S       D D_H  MON   CAMBIO      CC CONT PROY ORD  FECHA_VEN                                 PV ENL DEST AUTO TRA ANA PAGO MP NRO  FECHA_MP   PAGO  DEST TRANS FECHA_COM POR_IGV NOMBRE_PC")
        End If
        '------------------------------------------------------------------------------------------
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
        Dim NRO_CUOTA As Integer = Integer.Parse(txt_cuota.Text)
        Try
            Dim CMD As New SqlCommand("INSERTAR_I_CON_CXC_CANJE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            CMD.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            CMD.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            CMD.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value
            CMD.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            CMD.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            CMD.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            CMD.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            CMD.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            CMD.Parameters.Add("@COD_PER_CANJE", SqlDbType.VarChar).Value = TXT_COD.Text
            CMD.Parameters.Add("@NRO_DOC_PER_CANJE", SqlDbType.VarChar).Value = txt_doc_per.Text
            CMD.Parameters.Add("@COD_CUENTA_CANJE", SqlDbType.VarChar).Value = txt_origen.Text
            CMD.Parameters.Add("@NRO_LETRAS_CANJE", SqlDbType.VarChar).Value = NRO_CUOTA.ToString("00")
            CMD.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CCCJE"
            con.Open()
            estado = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function
    Function VERIFICAR_GENERACION_LETRAS() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = DGW_DET2.RowCount - 1
        For I = 0 To CONT
            Dim NRO_DOC3 As String = DGW_DET2.Item(1, I).Value.ToString
            If obj.VERIFICAR_PCTAS_COBRAR("LT", NRO_DOC3, TXT_COD.Text, txt_doc_per.Text, txt_destino.Text) = False Then
                MessageBox.Show(("La Letra Nº " & NRO_DOC3 & " ya existe."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Next
        Return True
    End Function
    Sub LIMPIAR_COMPROBANTE()
        g_cab.Enabled = True
        g_cab.Enabled = True
        dgw_det.Enabled = True
        DGW_DET2.Enabled = True
        gb_doc.Enabled = True
        BTN_GRABAR.Visible = True
        BTN_GRABAR.Enabled = True
        btn_nuevo2.Enabled = False
        btn_generar.Enabled = True
        btn_imprimir.Enabled = False
        cbo_aux.SelectedIndex = -1
        cbo_com.SelectedIndex = -1
        txt_nro_comp.Clear()
        txt_glosa.Clear()
        dtp_com.Value = Now.Date
        TabControl2.SelectedTab = TabPage3
        btn_imprimir.Enabled = False
        BTN_GRABAR.Enabled = True
        dgw_det.Rows.Clear()
        DGW_DET2.Rows.Clear()
        btn_generar.Enabled = True
        txt_total.Text = "0.00"
        txt_total2.Text = "0.00"
        For Each text As Object In gb_doc.Controls
            If TypeOf text Is TextBox Then text.text = ""
            If TypeOf text Is TextBox Then text.Enabled = True
            If TypeOf text Is ComboBox Then text.SelectedIndex = -1
            If TypeOf text Is ComboBox Then text.ENABLED = True
        Next
        dgw_det.Enabled = True
        DGW_DET2.ReadOnly = False
        gb_doc.Enabled = True
        dtp_com.Value = FECHA_GRAL
        dtp_doc.Value = FECHA_GRAL
        ch_saldo.Checked = False
        ch_saldo.Enabled = False
    End Sub
    Sub LIMPIAR_COMPROBANTE22()
        g_cab.Enabled = True
        g_cab.Enabled = True
        dgw_det.Enabled = True
        DGW_DET2.Enabled = True
        gb_doc.Enabled = True
        BTN_GRABAR.Visible = True
        BTN_GRABAR.Enabled = True
        btn_nuevo2.Enabled = False
        btn_generar.Enabled = True
        btn_imprimir.Enabled = False
        'cbo_aux.SelectedIndex = -1
        'cbo_com.SelectedIndex = -1
        'txt_nro_comp.Clear()
        txt_glosa.Clear()
        dtp_com.Value = Now.Date
        TabControl2.SelectedTab = TabPage3
        btn_imprimir.Enabled = False
        BTN_GRABAR.Enabled = True
        dgw_det.Rows.Clear()
        DGW_DET2.Rows.Clear()
        btn_generar.Enabled = True
        txt_total.Text = "0.00"
        txt_total2.Text = "0.00"
        For Each text As Object In gb_doc.Controls
            'If TypeOf text Is TextBox Then text.text = ""
            If TypeOf text Is TextBox Then text.Enabled = True
            If TypeOf text Is ComboBox Then text.SelectedIndex = -1
            If TypeOf text Is ComboBox Then text.ENABLED = True
        Next
        '----------------------------------------------------------------------------------------
        TXT_COD.Clear()
        TXT_DESC.Clear()
        txt_doc_per.Clear()
        TXT_TC2.Clear()
        txt_cuota.Clear()
        txt_nro_ini.Clear()
        txt_dia.Clear()
        txt_glosa.Clear()
        '----------------------------------------------------------------------------------------
        dgw_det.Enabled = True
        DGW_DET2.ReadOnly = False
        gb_doc.Enabled = True
        dtp_com.Value = FECHA_GRAL
        dtp_doc.Value = FECHA_GRAL
        If ((cbo_aux.SelectedIndex <> -1) And (cbo_com.SelectedIndex <> -1)) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            COD_COMP = obj.COD_COMP(cbo_com.Text, COD_AUX)
            Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeración para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
        End If
        ch_saldo.Checked = False
        ch_saldo.Enabled = False
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
    Private Sub REFRE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles REFRE.Click
        CARGAR_PERSONAS()
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
    Private Sub txt_cod_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_COD.LostFocus
        If (Strings.Trim(TXT_COD.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (TXT_COD.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD.Text = dgw_per.Item(0, i).Value.ToString
                        TXT_DESC.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        txt_glosa.Text = TXT_DESC.Text
                        txt_origen.Focus()
                        Return
                    End If
                    If (TXT_COD.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(TXT_COD.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_origen_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_origen.LostFocus
        ESTADO_CTA = "origen"
        If (Strings.Trim(txt_origen.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas de Analisis C ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_origen.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_origen.Text = dgw_cuenta.Item(0, i).Value.ToString
                        dtp_doc.Focus()
                        Return
                    End If
                    If (txt_origen.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_origen.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cuenta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_destino.LostFocus
        ESTADO_CTA = "destino"
        If (Strings.Trim(txt_destino.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen cuentas de Analisis C ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_destino.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_destino.Text = dgw_cuenta.Item(0, i).Value.ToString
                        txt_nro_ini.Focus()
                        Return
                    End If
                    If (txt_destino.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_destino.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cuenta.Visible = True
                dgw_cuenta.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cuota_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_cuota.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_DESC.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (TXT_DESC.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(TXT_DESC.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_dia_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_dia.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X COBRAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_per.CurrentCell = dgw_per.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_PER.Visible = True
                dgw_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_letra_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra.TextChanged
        Dim i As Integer
        If ch_cod.Checked Then
            txt_letra.Focus()
            Dim CONT As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra.Text.ToLower = Strings.Mid((dgw1.Item(4, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(4)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_rs.Checked Then
            txt_letra.Focus()
            Dim CONT As Integer = dgw1.RowCount - 1
            i = 0
            Do While (i <= CONT)
                If (txt_letra.Text.ToLower = Strings.Mid((dgw1.Item(10, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(10)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub
    Private Sub txt_nro_ini_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_nro_ini.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TXT_TC2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TXT_TC2.KeyPress
        e.Handled = Numero(e, TXT_TC2)
    End Sub
    Private Sub TXT_TC2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_TC2.LostFocus
        Try
            TXT_TC2.Text = obj.HACER_CAMBIO(TXT_TC2.Text)
        Catch ex As Exception
            TXT_TC2.Text = "0.0000"
        End Try
    End Sub
    Function VERIFICAR_LETRA() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW_DET2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            Dim NRO_DOC3 As String = DGW_DET2.Item(1, I).Value.ToString
            If obj.VERIFICAR_ELIMINAR_PCTAS_COBRAR("LT", NRO_DOC3, TXT_COD.Text, txt_doc_per.Text, txt_destino.Text) = False Then
                MessageBox.Show(("La Letra Nº " & NRO_DOC3 & " se encuentra cancelada."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
    Private Sub dtp_doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_doc.LostFocus
        If CBO_MONEDA.SelectedIndex <> -1 Then
            COD_MONEDA = CBO_MONEDA.SelectedValue.ToString
            If ((COD_MONEDA = "S") Or (COD_MONEDA.ToString = "System.Data.DataRowView")) Then
                TXT_TC2.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), "D")
            Else
                TXT_TC2.Text = obj.SACAR_CAMBIO(dtp_doc.Value.Year, dtp_doc.Value.ToString("MM"), dtp_doc.Value.ToString("dd"), COD_MONEDA)
            End If
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_saldo.CheckedChanged
        If ch_saldo.Checked = True Then
            dgw_det.Columns.Item(5).ReadOnly = False
        Else
            dgw_det.Columns.Item(5).ReadOnly = True
        End If
        monto = dgw_det.Item(5, dgw_det.CurrentRow.Index).Value

    End Sub
    Private Sub dgw_det_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_det.CellEndEdit
        Dim FILA_DET As Integer = dgw_det.CurrentRow.Index
        Select Case dgw_det.CurrentCell.ColumnIndex
            Case 5
                Try
                    If dgw_det.Item(5, FILA_DET).Value < monto Then
                        dgw_det.Item(5, FILA_DET).Value = obj.HACER_DECIMAL(dgw_det.Item(5, FILA_DET).Value)
                    Else
                        dgw_det.Item(5, FILA_DET).Value = monto
                    End If
                Catch ex As Exception
                    dgw_det.Item(5, FILA_DET).Value = obj.HACER_DECIMAL(monto)
                End Try
                Exit Select
        End Select
        HALLAR_TOTAL()
    End Sub
    Private Sub dgw_det_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_det.CellEnter
        monto = dgw_det.Item(5, dgw_det.CurrentRow.Index).Value
    End Sub

    Private Sub ValidarFichas(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter
        If ValidarFicha AndAlso sender.Tag > 0 Then
            TabControl1.SelectedIndex = 0
        End If
    End Sub
End Class