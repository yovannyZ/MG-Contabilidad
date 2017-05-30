Imports System.Data.SqlClient
Public Class CONSULTA_IBANCO
    Dim COD_AUX, mes6, mes5, COD_COMP, CUENTA_IGV, CUENTA_TOTAL As String
    Dim OBJ As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(17) = 0
        Close()
    End Sub
    Private Sub btn_consulta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_consulta.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl1.SelectedTab = TabPage2
        cbo_mes2.Text = cbo_mes.Text
        CARGAR_ANALISIS_DEFECTO()
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Sub CARGAR_ANALISIS()
        dgw3.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_BANCO_CONSULTA2", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
            pro_02.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw3.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_ANALISIS_DEFECTO()
        dgw3.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_BANCO_CONSULTA2", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            pro_02.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw3.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        cbo_año2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_año2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_COMPROBANTES_CABECERA()
        Try
            Dim CMD As New SqlCommand("REPORTE_MOSTRAR_I_BANCO_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = (DT)
            dgw1.Columns.Item(0).Width = 35
            dgw1.Columns.Item(1).Width = 50
            dgw1.Columns.Item(2).Width = 40
            dgw1.Columns.Item(3).Width = 180
            dgw1.Columns.Item(4).Width = 35
            dgw1.Columns.Item(5).Width = &H2D
            dgw1.Columns.Item(6).Width = 70
            dgw1.Columns.Item(7).Width = 70
            dgw1.Columns.Item(8).Width = 50
            dgw1.Columns.Item(7).DefaultCellStyle.Format = "d"
            dgw1.Columns.Item(10).Width = 40
            dgw1.Columns.Item(11).Width = 70
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_año.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex = -1) Then
            cbo_auxiliar.Focus()
        ElseIf (cbo_comprobante.SelectedIndex = -1) Then
            cbo_comprobante.Focus()
        Else
            mes5 = (OBJ.COD_MES(cbo_mes.Text))
            dgw2.Columns.Clear()
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex <> -1) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                LLENAR_CBO_COMPROBANTE()
            End If
        End If
    End Sub
    Private Sub cbo_comprobante_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_comprobante.SelectedIndexChanged
        If ((cbo_auxiliar.SelectedIndex <> -1) And (cbo_comprobante.SelectedIndex <> -1)) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            COD_COMP = cbo_comprobante.SelectedValue.ToString
            If (COD_COMP = "System.Data.DataRowView") Then
            End If
        End If
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex = -1 Then
            cbo_auxiliar.Focus()
        ElseIf cbo_comprobante.SelectedIndex = -1 Then
            cbo_comprobante.Focus()
        Else
            mes5 = OBJ.COD_MES(cbo_mes.Text)
            dgw2.Columns.Clear()
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes2.SelectedIndexChanged
        CARGAR_ANALISIS()
    End Sub
    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((dgw1.RowCount = 0) Or (con.State = ConnectionState.Open)) Then
        Else
            t_con()
        End If
    End Sub
    Sub LLENAR_CBO_AUXILIAR()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_AUX
        cbo_auxiliar.DataSource = DT
        cbo_auxiliar.DisplayMember = DT.Columns.Item(0).ToString
        cbo_auxiliar.ValueMember = DT.Columns.Item(1).ToString
        cbo_auxiliar.SelectedIndex = -1
    End Sub
    Sub LLENAR_CBO_COMPROBANTE()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        cbo_comprobante.DataSource = DT
        cbo_comprobante.DisplayMember = DT.Columns.Item(0).ToString
        cbo_comprobante.ValueMember = DT.Columns.Item(1).ToString
        cbo_comprobante.SelectedIndex = -1
        If (cbo_comprobante.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub t_con()
        Try
            Dim CMD As New SqlCommand("MOSTRAR_T_BANCO_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw2.DataSource = (DT)
            dgw2.Columns.Item(0).Width = &H30
            dgw2.Columns.Item(1).Width = 200
            dgw2.Columns.Item(2).Width = 70
            dgw2.Columns.Item(3).Width = 70
            dgw2.Columns.Item(4).Width = 40
            dgw2.Columns.Item(5).Width = 70
            dgw2.Columns.Item(6).Width = 35
            dgw2.Columns.Item(7).Width = 80
            dgw2.Columns.Item(8).Width = 70
            dgw2.Columns.Item(9).Width = 50
            dgw2.Columns.Item(10).Width = 60
            dgw2.Columns.Item(11).Width = 150
            dgw2.Columns.Item(2).DefaultCellStyle.Alignment = &H40
            dgw2.Columns.Item(3).DefaultCellStyle.Alignment = &H40
            dgw2.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns.Item(5).DefaultCellStyle.Alignment = &H40
            dgw2.Columns.Item(8).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_IBANCO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(30) = 0
    End Sub
    Private Sub CONSULTA_IBANCO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        mes5 = MES
        mes6 = MES
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_año2.Text = AÑO
        cbo_mes.SelectedIndex = -1
        LLENAR_CBO_AUXILIAR()
    End Sub

    Private Sub dgw1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellContentClick

    End Sub
End Class