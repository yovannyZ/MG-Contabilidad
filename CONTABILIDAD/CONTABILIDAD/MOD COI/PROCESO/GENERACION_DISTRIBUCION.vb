Imports System.Data.SqlClient
Imports System.Text
Public Class GENERACION_DISTRIBUCION
    Private obj As New Class1
    Dim DT As New DataTable
    Dim sb As New StringBuilder

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

    Private Sub GENERACION_DISTRIBUCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_AÑO()
        DT.Columns.Add("COD_CC")
    End Sub
    Public Function VERIFICAR_PERIODO_DISTRIBUCION(ByVal TIPO0 As String, ByVal AÑO As String, ByVal MES As String) As Boolean
        Dim ESTADO0 As Boolean = False
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_CIERRE_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            PROG_01.Parameters.Add("@MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO0
            con.Open()
            ESTADO0 = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        'If ESTADO0 = Nothing Then ESTADO0 = True
        Return ESTADO0
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cbo_año.SelectedIndex = -1 OrElse cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Verifique los datos de Mes y Año.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_mov.Rows.Clear()
            Dim i As Integer = -1
            Dim j As Integer = 0
            Try
                'VERIFICAR EL MES SI ESTA CERRADO
                Dim MES As String = obj.COD_MES(cbo_mes.Text)
                If VERIFICAR_PERIODO_DISTRIBUCION("MM", cbo_año.Text, MES) = False Then
                    MessageBox.Show("EL Período se encuentra cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                End If
                'VERIFICAR EXISTENCIA DE CC EN DISTRIBUCION
                DT.Rows.Clear()
                Dim CMD2 As New SqlCommand("SELECT DISTINCT COD_CC FROM T_CON WHERE NOT COD_CC IN (SELECT COD_AREA_ORIGEN FROM M_DISTRIBUCION_CC WHERE FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES) AND FE_AÑO=@FE_AÑO AND FE_MES=@FE_MES AND (SUBSTRING(COD_CUENTA,1,1)='7' OR SUBSTRING(COD_CUENTA,1,1)='9') AND ISNULL(COD_CC,'')<>'' ORDER BY COD_CC", con)
                CMD2.CommandType = CommandType.Text
                CMD2.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                CMD2.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
                con.Open()
                Dim dr2 As SqlDataReader = CMD2.ExecuteReader()
                While dr2.Read
                    DT.Rows.Add(dr2(0))
                End While
                con.Close()
                If DT.Rows.Count > 0 Then
                    'Dim rpta As DialogResult = MessageBox.Show("¿Desea ver el registro de errores?", "Importar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    'If rpta = Windows.Forms.DialogResult.Yes Then
                    Dim frm As New Form
                    frm.Size = New Size(320, 400)
                    frm.Text = "Registros sin insertar"
                    Dim dgv As New DataGridView
                    Dim col1 As New DataGridViewTextBoxColumn
                    col1.HeaderText = "Centro Costos"
                    col1.Name = "Centro_Costos"
                    col1.Width = 200
                    dgv.Columns.Add(col1)
                    dgv.Dock = DockStyle.Fill
                    'dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    dgv.AllowUserToAddRows = False
                    dgv.AllowUserToDeleteRows = False
                    dgv.AllowUserToOrderColumns = True
                    dgv.AllowUserToResizeRows = False
                    dgv.Rows.Clear()
                    Dim entero As Integer = 0
                    For Each row As DataRow In DT.Rows
                        dgv.Rows.Add(DT.Rows(entero).Item("COD_CC").ToString)
                        entero += 1
                    Next
                    frm.Controls.Add(dgv)
                    frm.ShowDialog()
                    If frm.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        Exit Sub
                    End If
                    'Else
                    '    Exit Sub
                    'End If
                End If
                '-----------------------------------------
                Dim Cmd As New SqlCommand("MOSTRAR_GENERAR_DISTRIBUCION", con)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
                Cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes.Text)
                con.Open()
                Dim dr As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.SingleResult)
                If dr IsNot Nothing AndAlso dr.HasRows Then
                    While dr.Read
                        With dgw_mov
                            'If .RowCount = 0 Then
                            .Rows.Add(dr(1), dr(2), dr(3), dr(4))
                            'If dr(4) = "D" Then
                            '    .Rows.Add(dr(1), dr(2), dr(3), dr(4), dr(5), 0, dr(6))
                            'Else
                            '    .Rows.Add(dr(1), dr(2), dr(3), dr(4), 0, dr(5), dr(6))
                            'End If
                            i += 1
                            'Else
                            '    If .Item(0, i).Value = dr(1) AndAlso .Item(1, i).Value = dr(2) Then
                            '        If dr(4) = "D" Then
                            '            .Item(4, i).Value = dr(5)
                            '        Else
                            '            .Item(5, i).Value = dr(5)
                            '        End If
                            '    Else
                            '        If dr(4) = "D" Then
                            '            .Rows.Add(dr(1), dr(2), dr(3), dr(4), dr(5), 0, dr(6))
                            '        Else
                            '            .Rows.Add(dr(1), dr(2), dr(3), dr(4), 0, dr(5), dr(6))
                            '        End If
                            '        i += 1
                            '    End If
                            'End If
                        End With
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            Dim cmd3 As New SqlCommand(String.Format("update maestro_saldos_cc set IM_CREDITO{0}=0,IM_DEBITO{0}=0 where año={1}", obj.COD_MES(cbo_mes.Text), cbo_año.Text), con)
            con.Open()
            cmd3.ExecuteNonQuery()
            con.Close()
            Dim sbCampo As New StringBuilder
            'Dim sbCampo1 As New StringBuilder
            Dim sbValor As New StringBuilder
            'Dim sbValor1 As New StringBuilder
            Dim rows As Integer = 0
            i = 0
            j = 0
            Dim cont As Integer = dgw_mov.RowCount - 1
            Dim trx As SqlTransaction = Nothing
            Try
                con.Open()
                trx = con.BeginTransaction
                For j = 1 To 12
                    sbCampo.Append(String.Format("IM_DEBITO{0}, ", j.ToString("00")))
                Next
                For j = 1 To 12
                    sbCampo.Append(String.Format("IM_CREDITO{0}, ", j.ToString("00")))
                Next
                'For j = 1 To 12
                '    sbCampo1.Append(String.Format("NRO_TRAB{0}, ", j.ToString("00")))
                'Next
                While i <= cont

                    sb.Remove(0, sb.Length)
                    'sbCampo.Remove(0, sbCampo.Length)
                    sbValor.Remove(0, sbValor.Length)

                    With dgw_mov
                        For j = 1 To 12
                            If j = Integer.Parse(obj.COD_MES(cbo_mes.Text)) Then
                                sbValor.Append(String.Format("{0}, ", .Item(2, i).Value))
                            Else
                                sbValor.Append("0, ")
                            End If
                        Next

                        For j = 1 To 12
                            If j = Integer.Parse(obj.COD_MES(cbo_mes.Text)) Then
                                sbValor.Append(String.Format("{0}, ", .Item(3, i).Value))
                            Else
                                sbValor.Append("0, ")
                            End If
                        Next
                        'If sbValor1.ToString <> "" Then sbValor1.Remove(0, sbValor1.Length)
                        'For j = 1 To 12
                        '    If j = Integer.Parse(obj.COD_MES(cbo_mes.Text)) Then
                        '        'Not cadena Is Nothing AndAlso cadena.Length > 0
                        '        sbValor1.Append(String.Format("{0}, ", IIf(Not .Item(4, i).Value Is Nothing AndAlso .Item(4, i).Value.ToString.Length > 0, .Item(4, i).Value, 0)))
                        '    Else
                        '        sbValor1.Append("0, ")
                        '    End If
                        'Next

                        sb.AppendLine(String.Format("SELECT COUNT(COD_CUENTA) FROM MAESTRO_SALDOS_CC WHERE COD_CUENTA='{0}' ", .Item(0, i).Value))
                        sb.Append(String.Format("AND AÑO='{0}' AND COD_CC='{1}'", cbo_año.Text, _
                        .Item(1, i).Value))

                        Dim Cmd As New SqlCommand(sb.ToString, con, trx)
                        Cmd.CommandType = CommandType.Text
                        rows = Cmd.ExecuteScalar

                        sb.Remove(0, sb.Length)
                        Dim cmes As String = "NRO_TRAB" & obj.COD_MES(cbo_mes.Text)
                        If rows = 0 Then

                            sb.AppendLine(String.Format("INSERT INTO MAESTRO_SALDOS_CC(COD_CUENTA, AÑO, COD_CC, {0}) ", sbCampo.ToString.Substring(0, sbCampo.Length - 2), cmes))
                            sb.Append(String.Format("VALUES('{0}', '{1}', '{2}', {3})", .Item(0, i).Value, cbo_año.Text, _
                                .Item(1, i).Value, sbValor.ToString.Substring(0, sbValor.Length - 2)))

                            Cmd = New SqlCommand(sb.ToString, con, trx)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        Else
                            If .Item(2, i).Value > 0 Then
                                sb.AppendLine(String.Format("UPDATE MAESTRO_SALDOS_CC SET IM_DEBITO{0}={1}+IM_DEBITO{0} ", obj.COD_MES(cbo_mes.Text), .Item(2, i).Value))
                                'sb.AppendLine(String.Format("IM_CREDITO{0}={1}", obj.COD_MES(cbo_mes.Text), .Item(3, i).Value))
                                sb.AppendLine(String.Format("WHERE COD_CUENTA={0} AND AÑO='{1}' AND COD_CC='{2}'", _
                                    .Item(0, i).Value, cbo_año.Text, .Item(1, i).Value))

                            Else
                                sb.AppendLine(String.Format("UPDATE MAESTRO_SALDOS_CC SET IM_CREDITO{0}={1}+IM_CREDITO{0} ", obj.COD_MES(cbo_mes.Text), .Item(3, i).Value))
                                'sb.AppendLine(String.Format("IM_CREDITO{0}={1}", obj.COD_MES(cbo_mes.Text), .Item(3, i).Value))
                                sb.AppendLine(String.Format("WHERE COD_CUENTA={0} AND AÑO='{1}' AND COD_CC='{2}'", _
                                    .Item(0, i).Value, cbo_año.Text, .Item(1, i).Value))
                            End If

                            Cmd = New SqlCommand(sb.ToString, con, trx)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()

                        End If
                    End With
                    i += 1
                End While
                trx.Commit()
                btnGrabar.Enabled = False
                MessageBox.Show("Datos generados con éxito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                trx.Rollback()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        main(154) = 0
        Close()
    End Sub
End Class