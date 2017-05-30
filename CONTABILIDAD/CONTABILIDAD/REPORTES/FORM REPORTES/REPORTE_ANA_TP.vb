Imports System.Data.SqlClient
Public Class REPORTE_ANA_TP
    Dim OBJ As New Class1
    Dim ofr1 As New REP_ANA_TP
    Private Sub REPORTE_ANA_TP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        CARGAR_AÑOS()
        DGW_CUENTAS00()
        cbo_mes.Text = OBJ.DESC_MES(MES)
        cbo_año.Text = AÑO
    End Sub
    Sub DGW_CUENTAS00()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = "P"
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), False)
            Loop
            con.Close()
            dgw1.Columns.Item(0).ReadOnly = True
            dgw1.Columns.Item(1).ReadOnly = True
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(105) = (0)
        Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        Dim TITULO As String
        ofr1.LIMPIAR()
        If rb1.Checked = True Then
            REPORTE1()
            TITULO = " AL MES DE " & " " & cbo_mes.Text & " " & " DEL " & " " & cbo_año.Text
        ElseIf rb2.Checked = True Then
            REPORTE2()
            TITULO = " DEL MES DE " & " " & cbo_mes.Text & " " & " DEL " & " " & cbo_año.Text
        ElseIf rb3.Checked = True Then
            REPORTE3()
            TITULO = " AL MES DE " & " " & cbo_mes.Text & " " & " DEL " & " " & cbo_año.Text
        Else
            MessageBox.Show("Debe elegir una de las opciones", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ofr1.CREAR_REPORTE(TITULO)
        ofr1.ShowDialog()
    End Sub
    Sub REPORTE1()
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(2, I).Value = True Then
                Try
                    Dim PROG_01 As New SqlCommand("REPORTE_ANALISIS_VS_TCTAS", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                    PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw1.Item(0, I).Value
                    PROG_01.Parameters.Add("@TIPO_REPORTE", SqlDbType.Char).Value = "1"
                    con.Open()
                    '-----------------------------
                    '-------para el tiempo de espera caducado
                    PROG_01.CommandTimeout = 5000
                    '-----------------------------
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    While Rs3.Read
                        ofr1.llenar_dt((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), _
                        Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), _
                        Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub
    Sub REPORTE2()
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(2, I).Value = True Then
                Try
                    Dim PROG_01 As New SqlCommand("REPORTE_ANALISIS_VS_TCTAS", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                    PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw1.Item(0, I).Value
                    PROG_01.Parameters.Add("@TIPO_REPORTE", SqlDbType.Char).Value = "2"
                    con.Open()
                    '--------------------------------------------
                    '-------para el tiempo de espera caducado
                    PROG_01.CommandTimeout = 5000
                    '--------------------------------------------
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    While Rs3.Read
                        ofr1.llenar_dt((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), _
                        Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), _
                        Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub
    Sub REPORTE3()
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(2, I).Value = True Then
                Try
                    Dim PROG_01 As New SqlCommand("REPORTE_ANALISIS_VS_TCTAS", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                    PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgw1.Item(0, I).Value
                    PROG_01.Parameters.Add("@TIPO_REPORTE", SqlDbType.Char).Value = "3"
                    con.Open()
                    '------------------------------------------
                    '-------para el tiempo de espera caducado
                    PROG_01.CommandTimeout = 5000
                    '------------------------------------------
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    While Rs3.Read
                        ofr1.llenar_dt((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), _
                        Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), _
                        Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub
    Private Sub ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch1.CheckedChanged
        If ch1.Checked = True Then
            Dim I, CONT As Integer
            CONT = dgw1.RowCount - 1
            For I = 0 To CONT
                dgw1.Item(2, I).Value = True
            Next
        Else
            Dim I, CONT As Integer
            CONT = dgw1.RowCount - 1
            For I = 0 To CONT
                dgw1.Item(2, I).Value = False
            Next
        End If
    End Sub
End Class