Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class REPORTE_BCO_TRANS
    Dim OBJ As New Class1
    Public N, M, E1, C, P As Boolean
    Dim fila2, fila1 As Integer
    Dim CON_COI As New SqlConnection
    Dim CUENTA_IGV, CUENTA_TOTAL, mes5, mes6, COD_AUX, COD_COMP, TITULO As String
    Dim repor As New BANCO_CONT_TRANS
    Dim REPOR2 As New BANCO_HOR_TRANS
    Dim I_E As New REP_BANCO_CON
    Dim I_E_HOR As New REP_BANCO_TRANS_HOR
    Private Sub REPORTE_BANCO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(26) = 0
    End Sub
    Private Sub REPORTE_BANCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
        mes5 = MES : mes6 = MES
        cbo_mes.SelectedIndex = -1
        LLENAR_CBO_AUXILIAR()
        CARGAR_AÑO()
        cbo_año.Text = AÑO
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_COMPROBANTES_CABECERA()
        Try
            Dim CMD As New SqlCommand("REPORTE_MOSTRAR_I_BANCO_TRANS", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns(0).Width = 55
            dgw1.Columns(2).Width = 35
            dgw1.Columns(3).Width = 120
            dgw1.Columns(4).Width = 45
            dgw1.Columns(5).Width = 38
            dgw1.Columns(6).Width = 68
            dgw1.Columns(7).Width = 50
            dgw1.Columns(8).Width = 50
            dgw1.Columns(9).Width = 70
            dgw1.Columns(10).Width = 70
            dgw1.Columns(11).Width = 35
            dgw1.Columns(12).Width = 60
            dgw1.Columns(13).Width = 25
            dgw1.Columns(1).Visible = False
            dgw1.Columns(15).Visible = False
            dgw1.Columns(16).Visible = False
            dgw1.Columns(10).DefaultCellStyle.Format = "d"
            dgw1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgw1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch1.CheckedChanged
        Dim i, cont As Integer
        i = 0
        cont = dgw1.Rows.Count - 1
        If ch1.Checked = True Then
            For i = 0 To cont
                dgw1.Item(13, i).Value = True
            Next
        Else
            For i = 0 To cont
                dgw1.Item(13, i).Value = False
            Next
        End If
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 And cbo_comprobante.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 And cbo_año.SelectedIndex <> -1 Then
            mes5 = OBJ.COD_MES(cbo_mes.Text)
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
    Private Sub ch_doc1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_comp.CheckedChanged
        If ch_comp.Checked = True And dgw1.Rows.Count <> 0 Then
            dgw1.Sort(dgw1.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub
    Private Sub ch_per1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_aux.CheckedChanged
        If ch_aux.Checked = True And dgw1.Rows.Count <> 0 Then
            dgw1.Sort(dgw1.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub
    Private Sub ch_cadena1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_cadena1.CheckedChanged
        If ch_cadena1.Checked = True And dgw1.Rows.Count <> 0 Then
            dgw1.Sort(dgw1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = True
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub
    Private Sub btn_buscar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar1.Click
        'buscar por cadena
        btn_sgt1.Enabled = True
        Dim i, f As Integer
        txt_letra1.Focus()
        For i = 0 To dgw1.RowCount() - 1
            'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
            For f = 1 To Len(dgw1.Item(1, i).Value.ToString)
                If txt_letra1.Text.ToLower = Mid(dgw1.Item(1, i).Value.ToString, f, Len(txt_letra1.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(1)
                    fila1 = i + 1
                    Exit Sub
                End If
            Next
        Next
    End Sub
    Private Sub btn_sgt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sgt1.Click
        btn_sgt1.Enabled = True
        Dim i, f As Integer
        txt_letra1.Focus()
        For i = fila1 To dgw1.RowCount() - 1
            'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
            For f = 1 To Len(dgw1.Item(1, i).Value.ToString)
                If txt_letra1.Text.ToLower = Mid(dgw1.Item(1, i).Value.ToString, f, Len(txt_letra1.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(1)
                    fila1 = i + 1
                    Exit Sub
                End If
            Next
        Next
        MessageBox.Show("Ya no existen más registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub txt_letra1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_letra1.TextChanged
        Dim i As Integer
        If ch_comp.Checked Then
            txt_letra1.Focus()
            'para el codigo (0)
            For i = 0 To dgw1.RowCount() - 1
                'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
                If txt_letra1.Text.ToLower = Mid(dgw1.Item(4, i).Value, 1, Len(txt_letra1.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(4)
                    Exit For
                End If
            Next
        ElseIf ch_aux.Checked Then
            txt_letra1.Focus()
            'buscar por descripcion(1)
            For i = 0 To dgw1.RowCount() - 1
                'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
                If txt_letra1.Text.ToLower = Mid(dgw1.Item(2, i).Value, 1, Len(txt_letra1.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(2)
                    Exit For
                End If
            Next
        End If
    End Sub
    Sub LLENAR_CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar.DataSource = DT
        cbo_auxiliar.DisplayMember = DT.Columns(0).ToString
        cbo_auxiliar.ValueMember = DT.Columns(1).ToString : cbo_auxiliar.SelectedIndex = -1
    End Sub
    Sub LLENAR_CBO_COMPROBANTE()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_comprobante.DataSource = DT
        cbo_comprobante.DisplayMember = DT.Columns(0).ToString
        cbo_comprobante.ValueMember = DT.Columns(1).ToString : cbo_comprobante.SelectedIndex = -1
        If cbo_comprobante.Items.Count = 0 Then MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If CheckBox1.Checked = True Then
            IMPRESION_CONTINUO()
            I_E.CrystalReportViewer1.ReportSource = repor
            I_E.ShowDialog()
        Else
            IMPRESION_HORIZONTAL()
            I_E_HOR.CrystalReportViewer1.ReportSource = REPOR2
            I_E_HOR.ShowDialog()
        End If
    End Sub
    Sub IMPRESION_HORIZONTAL()
        Dim dt As New DT_BANCO_IMPR
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(13, I).Value = True Then
                Try
                    Dim cod_mp, cod_banco, nro_mp As String
                    cod_mp = dgw1.Item(2, I).Value.ToString
                    cod_banco = dgw1.Item(4, I).Value.ToString
                    nro_mp = dgw1.Item(3, I).Value.ToString
                    Dim PROG_01 As New SqlCommand("REPORTE_MOSTRAR_DETALLE_TRANS", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
                    PROG_01.Parameters.Add("@COD_MP", SqlDbType.Char).Value = cod_mp
                    PROG_01.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = cod_banco
                    PROG_01.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    While Rs3.Read
                        Dim IMP_PAGAR As Decimal
                        Dim MON_CAB, MON_DET As String
                        MON_CAB = Rs3.GetValue(20)
                        MON_DET = Rs3.GetValue(10)
                        If MON_CAB <> MON_DET Then
                            If MON_CAB = "D" Then
                                IMP_PAGAR = Rs3.GetValue(14) / Rs3.GetValue(19)
                            ElseIf MON_CAB = "S" Then
                                IMP_PAGAR = Rs3.GetValue(14) * Rs3.GetValue(19)
                            End If
                        Else
                            IMP_PAGAR = Rs3.GetValue(14)
                        End If
                        dt.DataTable1.Rows.Add((Rs3.GetValue(6).ToString.Substring(0, 10)), Rs3.GetValue(5), Rs3.GetValue(3), Rs3.GetValue(1), Rs3.GetValue(0), Rs3.GetValue(8), Rs3.GetValue(4), dgw1.Item(14, I).Value.ToString, Rs3.GetValue(11), Rs3.GetValue(14), IMP_PAGAR, Rs3.GetValue(15), Rs3.GetValue(16), dgw1.Item(9, I).Value.ToString, Rs3.GetValue(13), Rs3.GetValue(25), Rs3.GetValue(10), Rs3.GetValue(21), dgw1.Item(15, I).Value.ToString, dgw1.Item(16, I).Value.ToString, dgw1.Item(3, I).Value.ToString, "", 0, (Rs3.GetValue(26)))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
        'SOLO PRUEBA PARA VER DATOS
        'DGWX.DataSource = dt.Tables(0)


        'Dim COD_REPOR As String
        'COD_REPOR = OBJ.DESC_USUARIO_BANCO(dgw1.Item(2, I).Value.ToString, dgw1.Item(3, I).Value.ToString, dgw1.Item(4, I).Value.ToString)
        REPOR2.SetDataSource(dt)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_mes.Text
        Params.Add(Par)
        REPOR2.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_año.Text
        Params.Add(Par)
        REPOR2.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        REPOR2.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        REPOR2.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_auxiliar.Text
        Params.Add(Par)
        REPOR2.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_comprobante.Text
        Params.Add(Par)
        REPOR2.DataDefinition.ParameterFields("COMP").ApplyCurrentValues(Params)
    End Sub
    Sub IMPRESION_CONTINUO()
        Dim dt As New DT_BANCO_IMPR
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(13, I).Value = True Then
                Try
                    Dim cod_mp, cod_banco, nro_mp As String
                    cod_mp = dgw1.Item(2, I).Value.ToString
                    cod_banco = dgw1.Item(4, I).Value.ToString
                    nro_mp = dgw1.Item(3, I).Value.ToString
                    Dim PROG_01 As New SqlCommand("REPORTE_MOSTRAR_DETALLE_TRANS", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
                    PROG_01.Parameters.Add("@COD_MP", SqlDbType.Char).Value = cod_mp
                    PROG_01.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = cod_banco
                    PROG_01.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    While Rs3.Read
                        Dim IMP_PAGAR As Decimal
                        Dim MON_CAB, MON_DET As String
                        MON_CAB = Rs3.GetValue(20)
                        MON_DET = Rs3.GetValue(10)
                        If MON_CAB <> MON_DET Then
                            If MON_CAB = "D" Then
                                IMP_PAGAR = Rs3.GetValue(14) / Rs3.GetValue(19)
                            ElseIf MON_CAB = "S" Then
                                IMP_PAGAR = Rs3.GetValue(14) * Rs3.GetValue(19)
                            End If
                        Else
                            IMP_PAGAR = Rs3.GetValue(14)
                        End If
                        dt.DataTable1.Rows.Add((Rs3.GetValue(6).ToString.Substring(0, 10)), Rs3.GetValue(5), Rs3.GetValue(3), Rs3.GetValue(1), Rs3.GetValue(0), Rs3.GetValue(8), Rs3.GetValue(4), dgw1.Item(14, I).Value.ToString, Rs3.GetValue(11), Rs3.GetValue(14), IMP_PAGAR, Rs3.GetValue(15), Rs3.GetValue(16), dgw1.Item(9, I).Value.ToString, Rs3.GetValue(13), Rs3.GetValue(25), Rs3.GetValue(10), Rs3.GetValue(21), dgw1.Item(15, I).Value.ToString, dgw1.Item(16, I).Value.ToString, dgw1.Item(3, I).Value.ToString, "", 0, (Rs3.GetValue(26)))
                        'dt.DataTable1.Rows.Add(Rs3.GetValue(6).ToString.Substring(0, 10), Rs3.GetValue(5), Rs3.GetValue(3), Rs3.GetValue(1), (Rs3.GetValue(0)), Rs3.GetValue(8), Rs3.GetValue(4), Rs3.GetValue(20), Rs3.GetValue(11), Rs3.GetValue(19), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(13), Rs3.GetValue(18), Rs3.GetValue(10), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next

        'Dim COD_REPOR As String
        'COD_REPOR = OBJ.DESC_USUARIO_BANCO(dgw1.Item(2, I).Value.ToString, dgw1.Item(3, I).Value.ToString, dgw1.Item(4, I).Value.ToString)

        repor.SetDataSource(dt)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_mes.Text
        Params.Add(Par)
        repor.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_año.Text
        Params.Add(Par)
        repor.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        repor.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        repor.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_auxiliar.Text
        Params.Add(Par)
        repor.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_comprobante.Text
        Params.Add(Par)
        repor.DataDefinition.ParameterFields("COMP").ApplyCurrentValues(Params)
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            If COD_AUX = "System.Data.DataRowView" Then Exit Sub
            LLENAR_CBO_COMPROBANTE()
        End If
    End Sub
    Private Sub cbo_comprobante_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_comprobante.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 And cbo_comprobante.SelectedIndex <> -1 Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            COD_COMP = cbo_comprobante.SelectedValue.ToString
            If COD_COMP = "System.Data.DataRowView" Then Exit Sub
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        main(33) = 0
        Close()
    End Sub
    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_año.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 And cbo_comprobante.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 And cbo_año.SelectedIndex <> -1 Then
            mes5 = OBJ.COD_MES(cbo_mes.Text)
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
End Class