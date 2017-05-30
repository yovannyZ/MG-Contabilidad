Imports System.Data.SqlClient
Public Class CONSULTA_ICON
    Dim COD_AUX, COD_COMP, CUENTA_IGV, CUENTA_TOTAL, mes5, mes6 As String
    Dim E1, M, N, P, C As Boolean
    Dim OBJ As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        main(32) = 0
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
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        TabControl1.SelectedTab = TabPage3
        cbo_mes3.Text = cbo_mes.Text
        CARGAR_CONTABLE()
    End Sub
    Sub CARGAR_ANALISIS()
        dgw3.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_ANALISIS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw3.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_ANALISIS_DEFECTO()
        dgw3.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_ANALISIS", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw3.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_COMPROBANTES_CABECERA()
        Try
            Dim CMD As New SqlCommand("REPORTE_MOSTRAR_I_CON_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = (DT)
            dgw1.Columns(0).Width = 60 : dgw1.Columns(1).Width = 70 : dgw1.Columns(2).Width = 70 : dgw1.Columns(3).Width = &H55
            dgw1.Columns(4).Width = &H69 : dgw1.Columns(5).Width = 60 : dgw1.Columns(6).Width = 150
            dgw1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw1.Columns(3).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONTABLE()
        dgw4.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw4.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15), rs2.GetValue(16), rs2.GetValue(17), rs2.GetValue(18), rs2.GetValue(19))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CONTABLE2()
        dgw4.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_T_CON_CONTABLE", con)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año3.Text
            pro_02.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes3.Text)
            pro_02.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString)
            con.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw4.Rows.Add(rs2.GetValue(0), rs2.GetValue(1), rs2.GetValue(2), rs2.GetValue(3), rs2.GetValue(4), rs2.GetValue(5), rs2.GetValue(6), rs2.GetValue(7), rs2.GetValue(8), rs2.GetValue(9), rs2.GetValue(10), rs2.GetValue(11), rs2.GetValue(12), rs2.GetValue(13), rs2.GetValue(14), rs2.GetValue(15))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cbo_auxiliar_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_auxiliar.SelectedIndexChanged
        If (cbo_auxiliar.SelectedIndex <> -1) Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            If (COD_AUX <> "System.Data.DataRowView") Then
                LLENAR_CBO_COMPROBANTE()
            End If
        End If
        If cbo_comprobante.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 Then
            mes5 = OBJ.COD_MES(cbo_mes.Text)
            dgw2.Columns.Clear()
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
    Private Sub cbo_comprobante_SelectedIndexChanged_1(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_comprobante.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex <> -1 And cbo_comprobante.SelectedIndex <> -1 Then
            COD_AUX = cbo_auxiliar.SelectedValue.ToString
            COD_COMP = cbo_comprobante.SelectedValue.ToString
            If (COD_COMP = "System.Data.DataRowView") Then
            End If
        End If
        If cbo_comprobante.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 Then
            mes5 = OBJ.COD_MES(cbo_mes.Text)
            dgw2.Columns.Clear()
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If cbo_auxiliar.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_auxiliar.Focus()
        ElseIf cbo_comprobante.SelectedIndex = -1 Then
            MessageBox.Show("Debe elegir el comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_comprobante.Focus()
        Else
            mes5 = OBJ.COD_MES(cbo_mes.Text)
            dgw2.Columns.Clear()
            CARGAR_COMPROBANTES_CABECERA()
        End If
    End Sub
    Private Sub cbo_mes3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes3.SelectedIndexChanged
        CARGAR_CONTABLE2()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes2.SelectedIndexChanged
        CARGAR_ANALISIS()
    End Sub
    Private Sub dgw1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellEnter
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (dgw1.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            t_con()
            HALLAR_TOTALES()
        End If
    End Sub
    Sub HALLAR_TOTALES()
        Dim sum0, sum1, sum2, sum3 As Decimal
        Dim i, cont As Integer
        cont = dgw2.Rows.Count - 1
        sum0 = 0 : sum1 = 0 : sum2 = 0 : sum3 = 0
        For i = 0 To cont
            sum0 = sum0 + dgw2.Item(2, i).Value
            sum1 = sum1 + dgw2.Item(3, i).Value
            sum2 = sum2 + dgw2.Item(4, i).Value
            sum3 = sum3 + dgw2.Item(5, i).Value
        Next
        txt_debe_soles.Text = OBJ.HACER_DECIMAL(sum0)
        txt_haber_soles.Text = OBJ.HACER_DECIMAL(sum1)
        txt_debe_dolares.Text = OBJ.HACER_DECIMAL(sum2)
        txt_haber_dolares.Text = OBJ.HACER_DECIMAL(sum3)

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
            Dim CMD As New SqlCommand("MOSTRAR_TCON_CONSULTA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes5
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw2.DataSource = (DT)
            '------------tamaños
            dgw2.Columns(0).Width = 60 : dgw2.Columns(1).Width = 200
            dgw2.Columns(2).Width = 70 : dgw2.Columns(3).Width = 70
            dgw2.Columns(4).Width = 70 : dgw2.Columns(5).Width = 70
            dgw2.Columns(6).Width = 35 : dgw2.Columns(7).Width = 60
            dgw2.Columns(8).Width = 60 : dgw2.Columns(9).Width = 80
            dgw2.Columns(10).Width = 70 : dgw2.Columns(11).Width = &H37
            dgw2.Columns(12).Width = &H37 : dgw2.Columns(13).Width = &H2D
            dgw2.Columns(14).Width = &H37 : dgw2.Columns(15).Width = &H37
            dgw2.Columns(16).Width = &H37 : dgw2.Columns(17).Width = &H37
            dgw2.Columns(20).Width = 180
            dgw2.Columns(23).Width = 44
            dgw2.Columns(24).Width = 45
            dgw2.Columns(25).Width = 33
            '------------alineaciones
            dgw2.Columns(2).DefaultCellStyle.Alignment = &H40 : dgw2.Columns(3).DefaultCellStyle.Alignment = &H40
            dgw2.Columns(4).DefaultCellStyle.Alignment = &H40 : dgw2.Columns(5).DefaultCellStyle.Alignment = &H40
            dgw2.Columns(7).DefaultCellStyle.Alignment = &H40 : dgw2.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter : dgw2.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgw2.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '------------formatos
            dgw2.Columns(2).DefaultCellStyle.Format = "N2" : dgw2.Columns(3).DefaultCellStyle.Format = "N2"
            dgw2.Columns(4).DefaultCellStyle.Format = "N2" : dgw2.Columns(5).DefaultCellStyle.Format = "N2"
            dgw2.Columns(10).DefaultCellStyle.Format = "d"
            '------------visibles
            dgw2.Columns(18).Visible = False : dgw2.Columns(19).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CONSULTA_ICON_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(24) = 0
    End Sub
    Private Sub CONSULTA_ICON_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw3.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw4.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        mes5 = MES
        mes6 = MES
        cbo_mes.SelectedIndex = -1
        LLENAR_CBO_AUXILIAR()
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_año2.Text = AÑO
        cbo_año3.Text = AÑO
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        cbo_año2.Items.Clear()
        cbo_año3.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_año2.Items.Add(Rs3.GetString(0))
                cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class