Imports System.Data.SqlClient
Public Class CXC_TRANSF_ANA
    Dim OBJ As New Class1
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs)Handles btn_aceptar.Click
        If ((MES = "00") Or (MES = "13")) Then
            MessageBox.Show("No se puede transferir en Inicio ni en Cierre de Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If (OBJ.ValidarCierreCuentas("CC", AÑO, OBJ.COD_MES(cbo_mes.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim j As Integer = 0
        Dim k As Integer = (dgw1.RowCount - 1)
        Dim FECHA0 As DateTime = FECHA_GRAL
        FECHA0 = DateTime.Parse("01/" + OBJ.COD_MES(cbo_mes.Text) + "/" + AÑO)
        j = 0
        Do While (j <= k)
            Dim estado As String = "FALLO"
            If dgw1.Item(2, j).Value = True Then
                Dim ls As String = (dgw1.Item(0, j).Value)
                If OBJ.VERIFICAR_CIERRE_CUENTAS(ls, AÑO, OBJ.COD_MES(cbo_mes.Text)) = False Then Exit Sub
                Try
                    Dim cmd As New SqlCommand("TRANSFERIR_CTAS_CXC", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = dgw1.Item(0, j).Value
                    cmd.Parameters.Add("@fecha_concILIADO", SqlDbType.DateTime).Value = FECHA0
                    cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                    cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = OBJ.COD_MES(cbo_mes.Text)
                    con.Open()
                    '-----------------------------
                    '-------para el tiempo de espera caducado
                    cmd.CommandTimeout = 5000
                    '-----------------------------

                    estado = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If (estado = "FALLO") Then
                    MessageBox.Show((("Al tranferir la cuenta: " & dgw1.Item(0, j).Value)), "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
            j += 1
        Loop
        MessageBox.Show("Conciliación Exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If (OBJ.ValidarCierreCuentas("CC", AÑO, OBJ.COD_MES(cbo_mes2.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)
        'Dim VB$t_i4$L0 As Integer = I
        I = 0
        Do While (I <= CONT)
            If dgw2.Item(2, I).Value = True Then
                If OBJ.VERIFICAR_CIERRE_CUENTAS(dgw2.Item(0, I).Value, AÑO, OBJ.COD_MES(cbo_mes2.Text)) = False Then Exit Sub
                DESCONCILIAR_CUENTA(dgw2.Item(0, I).Value.ToString)
            End If
            I += 1
        Loop
        MessageBox.Show("Des-conciliación Exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click
        main(93) = 0
        Close()
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        'Dim VB$t_i4$L0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw1.RowCount - 1))
            dgw1.Item(2, i).Value = (ch1.Checked)
            i += 1
        Loop
    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        'Dim VB$t_i4$L0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw2.RowCount - 1))
            dgw2.Item(2, i).Value = (ch2.Checked)
            i += 1
        Loop
    End Sub
    Sub DESCONCILIAR_CUENTA(ByVal cod_cta As String)
        Try
            Dim cmd As New SqlCommand("DESTRANSFERIR_CTAS_CXC", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@fe_año", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
            cmd.Parameters.Add("@COD_cuenta", SqlDbType.VarChar).Value = cod_cta
            con.Open()
            '-----------------------------
            '-------para el tiempo de espera caducado
            cmd.CommandTimeout = 5000
            '-----------------------------
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub DGW_CUENTAS00()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = ("C")
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(New Object() {dr.GetString(0), dr.GetString(1), False})
                dgw2.Rows.Add(New Object() {dr.GetString(0), dr.GetString(1), False})
            Loop
            con.Close()
            dgw1.Columns.Item(0).ReadOnly = (True)
            dgw1.Columns.Item(1).ReadOnly = (True)
            dgw2.Columns.Item(0).ReadOnly = (True)
            dgw2.Columns.Item(1).ReadOnly = (True)
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub CXC_TRANSF_ANA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub CXC_TRANSF_ANA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGW_CUENTAS00()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        cbo_mes.Text = OBJ.DESC_MES(MES)
        cbo_mes2.Text = OBJ.DESC_MES(MES)
        btn_aceptar.Select()
    End Sub
End Class