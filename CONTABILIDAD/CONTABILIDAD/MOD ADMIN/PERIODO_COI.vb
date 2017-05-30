Imports System.Data.SqlClient
Public Class PERIODO_COI
    Private mes5 As String
    Private Sub btn_activar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        Dim año2 As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        cbo_mes.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        Dim mes2 As String = mes5
        If (Decimal.Parse((CInt(MessageBox.Show(("Activar Periodo " & año2 & " - " & mes2), "Esta seguro de:", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("BLOQUEAR PERIODO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
                CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = año2
                CMD.Parameters.Add("@MES", SqlDbType.Char).Value = mes2
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        DATAGRID()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Falta elegir el Mes de Proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (Decimal.Compare(cbo_año.Value, New Decimal(dtp1.Value.Year)) <> 0) Then
            MessageBox.Show("La fecha de inicio no coincide con el año ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp1.Focus()
        ElseIf (Decimal.Compare(cbo_año.Value, New Decimal(dtp2.Value.Year)) <> 0) Then
            MessageBox.Show("La fecha de cierre no coincide con el año ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp2.Focus()
        ElseIf (mes5 <> dtp1.Value.ToString("MM")) Then
            MessageBox.Show("La fecha de inicio no coincide con el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp1.Focus()
        ElseIf (mes5 <> dtp2.Value.ToString("MM")) Then
            MessageBox.Show("La fecha de cierre no coincide con el mes ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp2.Focus()
        Else
            HALLAR_MES()
            If VERIFICAR() = False Then
                MessageBox.Show("Ese Período ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_año.Focus()
            Else
                Try
                    Dim CMD As New SqlCommand("INSERTAR_PERIODO", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
                    CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Value
                    CMD.Parameters.Add("@MES", SqlDbType.Char).Value = mes5
                    CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp1.Value
                    CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = dtp2.Value
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
                TabControl1.SelectedTab = TabPage1
                DATAGRID()
            End If
        End If
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegirmun registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try

        If dgw1.Item(8, dgw1.CurrentRow.Index).Value = True Then MessageBox.Show("El Periodo se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

        limpiar()
        CARGAR_DATOS()
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        TabControl1.SelectedTab = TabPage2
        cbo_año.Enabled = False
        cbo_mes.Enabled = False
    End Sub

    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (Decimal.Compare(cbo_año.Value, New Decimal(dtp1.Value.Year)) <> 0) Then
            MessageBox.Show("La fecha de inicio no coincide con el año ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp1.Focus()
        ElseIf (Decimal.Compare(cbo_año.Value, New Decimal(dtp2.Value.Year)) <> 0) Then
            MessageBox.Show("La fecha de cierre no coincide con el año ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp2.Focus()
        ElseIf (mes5 <> dtp1.Value.ToString("MM")) Then
            MessageBox.Show("La fecha de inicio no coincide con el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp1.Focus()
        ElseIf (mes5 <> dtp2.Value.ToString("MM")) Then
            MessageBox.Show("La fecha de cierre no coincide con el mes ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp2.Focus()
        Else
            HALLAR_MES()
            Dim ST_RC As String = "0"
            Dim ST_RV As String = "0"
            Dim ST_RH As String = "0"
            Dim ST_BL As String = "0"
            Dim ST_BCP As String = "0"
            Dim ST_BCC As String = "0"
            Dim ST_BOC As String = "0"

            If CH_RC.Checked Then
                ST_RC = "1"
            End If
            If CH_RV.Checked Then
                ST_RV = "1"
            End If
            If CH_RH.Checked Then
                ST_RH = "1"
            End If
            If CH_BL.Checked Then
                ST_BL = "1"
            End If
            If chkCtasCobrar.Checked Then
                ST_BCC = "1"
            End If
            If chkCtasPagar.Checked Then
                ST_BCP = "1"
            End If
            If chkOtrasCtas.Checked Then
                ST_BOC = "1"
            End If
            Try
                Dim CMD As New SqlCommand("MODIFICAR_PERIODO2", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
                CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Value
                CMD.Parameters.Add("@MES", SqlDbType.Char).Value = mes5
                CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp1.Value
                CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = dtp2.Value
                CMD.Parameters.Add("@STATUS_B_RCOMPRA", SqlDbType.VarChar).Value = ST_RC
                CMD.Parameters.Add("@STATUS_B_RVENTA", SqlDbType.VarChar).Value = ST_RV
                CMD.Parameters.Add("@STATUS_B_RHONORARIO", SqlDbType.VarChar).Value = ST_RH
                CMD.Parameters.Add("@STATUS_BLOQUEO", SqlDbType.VarChar).Value = ST_BL

                CMD.Parameters.Add("@STATUS_BCP", SqlDbType.VarChar).Value = ST_BCP
                CMD.Parameters.Add("@STATUS_BCC", SqlDbType.VarChar).Value = ST_BCC
                CMD.Parameters.Add("@STATUS_BOC", SqlDbType.VarChar).Value = ST_BOC
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La fecha de Período se actualizó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            TabControl1.SelectedTab = TabPage1
            DATAGRID()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        limpiar()
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        TabControl1.SelectedTab = TabPage2
        cbo_año.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(24) = 0
        Close()
    End Sub

    Sub CARGAR_DATOS()
        cbo_año.Value = Decimal.Parse(dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString)
        cbo_mes.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        dtp1.Value = Date.Parse(dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString)
        dtp2.Value = Date.Parse(dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString)
        If dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            CH_BL.Checked = True
        End If
        If dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            CH_RC.Checked = True
        End If
        If dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            CH_RV.Checked = True
        End If
        If dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            CH_RH.Checked = True
        End If
        If dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            chkCtasPagar.Checked = True
        End If
        If dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            chkCtasCobrar.Checked = True
        End If
        If dgw1.Item(11, dgw1.CurrentRow.Index).Value.ToString = "True" Then
            chkOtrasCtas.Checked = True
        End If
    End Sub

    Private Sub cbo_mes_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.LostFocus
    End Sub

    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        Select Case cbo_mes.SelectedIndex
            Case 0
                mes5 = "01"

            Case 1
                mes5 = "01"

            Case 2
                mes5 = "02"

            Case 3
                mes5 = "03"

            Case 4
                mes5 = "04"

            Case 5
                mes5 = "05"

            Case 6
                mes5 = "06"

            Case 7
                mes5 = "07"

            Case 8
                mes5 = "08"

            Case 9
                mes5 = "09"

            Case 10
                mes5 = "10"

            Case 11
                mes5 = "11"

            Case 12
                mes5 = "12"

            Case 13
                mes5 = "12"

        End Select
    End Sub

    Sub DATAGRID()
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Try
            Dim CMD As New SqlCommand("MOSTRAR_PERIODO2", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MODULO".ToString, SqlDbType.Char).Value = COD_MOD
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns.Item(0).Width = 35
            dgw1.Columns.Item(2).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(3).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(4).Width = 30
            dgw1.Columns.Item(5).Width = 30
            dgw1.Columns.Item(6).Width = 30
            dgw1.Columns.Item(7).Width = 30
            dgw1.Columns.Item(8).Visible = False
            dgw1.Columns.Item(9).Width = 45
            dgw1.Columns.Item(10).Width = 45
            dgw1.Columns.Item(11).Width = 45
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Sub HALLAR_MES()
        Select Case cbo_mes.SelectedIndex
            Case 0
                mes5 = "00"
            Case 1
                mes5 = "01"
            Case 2
                mes5 = "02"
            Case 3
                mes5 = "03"
            Case 4
                mes5 = "04"
            Case 5
                mes5 = "05"
            Case 6
                mes5 = "06"
            Case 7
                mes5 = "07"

            Case 8
                mes5 = "08"

            Case 9
                mes5 = "09"

            Case 10
                mes5 = "10"

            Case 11
                mes5 = "11"

            Case 12
                mes5 = "12"

            Case 13
                mes5 = "13"

        End Select
    End Sub
    Sub limpiar()
        cbo_mes.SelectedIndex = -1
        cbo_año.Enabled = True
        cbo_mes.Enabled = True
        CH_RC.Checked = False
        CH_RV.Checked = False
        CH_RH.Checked = False
        CH_BL.Checked = False
        chkCtasCobrar.Checked = False
        chkCtasPagar.Checked = False
        chkOtrasCtas.Checked = False
    End Sub

    Private Sub PERIODO_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PERIODO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
    End Sub
    Function VERIFICAR() As Boolean
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PERIODO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Value
            CMD.Parameters.Add("@MES", SqlDbType.Char).Value = mes5
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (CONT > 0) Then
            Return False
        End If
        Return True
    End Function
End Class