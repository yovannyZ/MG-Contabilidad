Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class REP_COMP
    Dim OBJ As New Class1
    Public N, M, E1, C, P As Boolean
    Dim fila2, fila1 As Integer
    Dim CUENTA_IGV, CUENTA_TOTAL, mes5, mes6, COD_AUX, COD_COMP As String
    Dim reporte As New CrystalReport1
    Dim reporte2 As New REP_COMP_HORIZONTAL
    Dim REP As New REPORTE_COMP
    Dim rep2 As New REP_COMP_HOR
    Private Sub GENERACION_COI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(39) = 0
    End Sub
    Private Sub GEN_FACT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
        mes5 = MES : mes6 = MES
        cbo_mes.SelectedIndex = -1
        LLENAR_CBO_AUXILIAR()
    End Sub
    Sub CARGAR_COMPROBANTES_CABECERA()
        Try
            Dim CMD As New SqlCommand("REPORTE_MOSTRAR_I_CON", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns(0).Width = 60
            dgw1.Columns(1).Width = 80
            dgw1.Columns(2).Width = 80
            dgw1.Columns(3).Width = 90
            dgw1.Columns(4).Width = 105
            dgw1.Columns(5).Width = 35
            dgw1.Columns(6).Width = 80
            dgw1.Columns(7).Width = 150
            dgw1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns(3).DefaultCellStyle.Format = "d"
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
                dgw1.Item(5, i).Value = True
            Next
        Else
            For i = 0 To cont
                dgw1.Item(5, i).Value = False
            Next
        End If
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 And cbo_comprobante.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 Then
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
        For i = 0 To Me.dgw1.RowCount() - 1
            'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
            For f = 1 To Len(dgw1.Item(1, i).Value.ToString)
                If Me.txt_letra1.Text.ToLower = Mid(Me.dgw1.Item(1, i).Value.ToString, f, Len(Me.txt_letra1.Text)).ToLower Then
                    Me.dgw1.CurrentCell = Me.dgw1.Rows(i).Cells(1)
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
        For i = fila1 To Me.dgw1.RowCount() - 1
            'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
            For f = 1 To Len(dgw1.Item(1, i).Value.ToString)
                If Me.txt_letra1.Text.ToLower = Mid(Me.dgw1.Item(1, i).Value.ToString, f, Len(Me.txt_letra1.Text)).ToLower Then
                    Me.dgw1.CurrentCell = Me.dgw1.Rows(i).Cells(1)
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
            For i = 0 To Me.dgw1.RowCount() - 1
                'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
                If Me.txt_letra1.Text.ToLower = Mid(dgw1.Item(4, i).Value, 1, Len(Me.txt_letra1.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(4)
                    Exit For
                End If
            Next
        ElseIf ch_aux.Checked Then
            txt_letra1.Focus()
            'buscar por descripcion(1)
            For i = 0 To dgw1.RowCount() - 1
                'en item(0,i) el 0 indica la columna con la que va comparar en este caso el por lastname
                If Me.txt_letra1.Text.ToLower = Mid(dgw1.Item(2, i).Value, 1, Len(Me.txt_letra1.Text)).ToLower Then
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
    Sub impresion_continuo()
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(5, I).Value = True Then
                Try
                    Dim PROG_01 As New SqlCommand("REPORTE_MOSTRAR_T_CON", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(0, I).Value
                    PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(1, I).Value
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
                    PROG_01.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(2, I).Value
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    Dim COD_D_H As String
                    Dim IMPORTE, IMP_D, IMP_H As Decimal
                    While Rs3.Read
                        IMPORTE = Rs3.GetValue(7)
                        COD_D_H = Rs3.GetValue(5)
                        If COD_D_H = "D" Then
                            IMP_D = IMPORTE
                            IMP_H = "0.00"
                        Else
                            IMP_D = "0.00"
                            IMP_H = IMPORTE
                        End If
                        dt.DataTable1.Rows.Add(Rs3.GetValue(4).ToString.Substring(0, 10), Rs3.GetValue(3), Rs3.GetValue(2), (Rs3.GetValue(0)), Rs3.GetValue(11), Rs3.GetValue(6), Rs3.GetValue(1), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(14), (IMP_D), (IMP_H), Rs3.GetValue(5), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(19), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
        reporte.SetDataSource(dt)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_mes.Text
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = AÑO
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_auxiliar.Text
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)

        reporte.PrintOptions.PaperSize = DirectCast(OBJ.TamañoPapel("IMPRESION"), CrystalDecisions.Shared.PaperSize)
    End Sub
    Sub impresion_horizontal()
        Dim dt As New DT_COMP_IMP
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(5, I).Value = True Then
                Try
                    Dim PROG_01 As New SqlCommand("REPORTE_MOSTRAR_T_CON", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(0, I).Value
                    PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(1, I).Value
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
                    PROG_01.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(2, I).Value
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    Dim COD_D_H As String
                    Dim IMPORTE, IMP_D, IMP_H As Decimal
                    While Rs3.Read
                        IMPORTE = Rs3.GetValue(7)
                        COD_D_H = Rs3.GetValue(5)
                        If COD_D_H = "D" Then
                            IMP_D = IMPORTE
                            IMP_H = "0.00"
                        Else
                            IMP_D = "0.00"
                            IMP_H = IMPORTE
                        End If
                        dt.DataTable1.Rows.Add(Rs3.GetValue(4).ToString.Substring(0, 10), Rs3.GetValue(3), Rs3.GetValue(2), Rs3.GetValue(0), Rs3.GetValue(11), Rs3.GetValue(6), Rs3.GetValue(1), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(14), (IMP_D), (IMP_H), Rs3.GetValue(5), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(19), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
       
        reporte2.SetDataSource(dt)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_mes.Text
        Params.Add(Par)
        reporte2.DataDefinition.ParameterFields("DES_MES").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = AÑO
        Params.Add(Par)
        reporte2.DataDefinition.ParameterFields("AÑO").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        reporte2.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        reporte2.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = cbo_auxiliar.Text
        Params.Add(Par)
        reporte2.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)

    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
       If CheckBox1.Checked = True Then
            impresion_continuo()
            REP.CrystalReportViewer1.ReportSource = reporte
            REP.ShowDialog()
        Else
            impresion_horizontal()
            rep2.CrystalReportViewer1.ReportSource = reporte2
            rep2.ShowDialog()
        End If
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
        main(24) = 0
        Me.Close()
    End Sub
End Class