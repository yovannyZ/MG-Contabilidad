Imports System.Data.SqlClient
Public Class PERIODO_BANCO
    Private mes5 As String
    Private Sub btn_activar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_activar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If dgw1.Item(5, dgw1.CurrentRow.Index).Value = True Then MessageBox.Show("El Periodo se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        Dim año2 As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        cbo_mes.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        Dim mes2 As String = mes5
        If (Decimal.Parse((CInt(MessageBox.Show(("Activar Periodo " & año2 & " - " & mes2), "Esta seguro de:", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ACTIVAR_PERIODO", con)
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
        ElseIf VERIFICAR() = False Then
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
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegirmun registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try

        If dgw1.Item(5, dgw1.CurrentRow.Index).Value = True Then MessageBox.Show("El Periodo se encuentra cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

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
            Try
                Dim CMD As New SqlCommand("MODIFICAR_PERIODO", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
                CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Value
                CMD.Parameters.Add("@MES", SqlDbType.Char).Value = mes5
                CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp1.Value
                CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = dtp2.Value
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
        main(17) = 0
        Close()
    End Sub

    Sub CARGAR_DATOS()
        cbo_año.Value = Decimal.Parse(dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString)
        cbo_mes.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        dtp1.Value = Date.Parse(dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString)
        dtp2.Value = Date.Parse(dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString)
    End Sub

    Private Sub cbo_mes_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.LostFocus
        If VERIFICAR() = False Then
            MessageBox.Show("Ese Período ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        End If
    End Sub

    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        Select Case cbo_mes.SelectedIndex
            Case 0
                mes5 = "01"

            Case 1
                mes5 = "02"

            Case 2
                mes5 = "03"

            Case 3
                mes5 = "04"

            Case 4
                mes5 = "05"

            Case 5
                mes5 = "06"

            Case 6
                mes5 = "07"

            Case 7
                mes5 = "08"

            Case 8
                mes5 = "09"

            Case 9
                mes5 = "10"

            Case 10
                mes5 = "11"

            Case 11
                mes5 = "12"

        End Select
    End Sub

    Sub DATAGRID()
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Try
            Dim CMD As New SqlCommand("MOSTRAR_PERIODO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MODULO".ToString, SqlDbType.Char).Value = COD_MOD
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns.Item(0).Width = 35
            dgw1.Columns.Item(2).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(3).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(4).Width = 25
            dgw1.Columns.Item(5).Visible = False
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Sub limpiar()
        cbo_mes.SelectedIndex = -1
        cbo_año.Enabled = True
        cbo_mes.Enabled = True
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