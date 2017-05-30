Imports System.Data.SqlClient
Public Class CXP_TRANSF_AÑO
    Dim OBJ As New Class1
    Dim TC_ACT As Decimal
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If MES <> "12" Then
            MessageBox.Show("Solo se puede transferir en el mes de Diciembre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If VERIFICAR_CIERRE() = False Then Exit Sub
        If rbCompra.Checked Then
            TC_ACT = OBJ.SACAR_CAMBIO_MENSUAL(AÑO, MES, "D", "C")
        Else
            TC_ACT = OBJ.SACAR_CAMBIO_MENSUAL(AÑO, MES, "D", "V")
        End If
        'TC_ACT = OBJ.SACAR_CAMBIO_MENSUAL(AÑO, MES, "D", "V")
        If TC_ACT = 0 Or TC_ACT = Nothing Then
            MessageBox.Show("Debe cargar el Tipo de Cambio Mensual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim j As Integer = 0
        Dim k As Integer = (dgw1.RowCount - 1)
        j = 0
        Do While (j <= k)
            Dim estado As String = "FALLO"
            If dgw1.Item(2, j).Value = True Then
                Dim st_aj As String = "0"
                If dgw1.Item(3, j).Value = True Then st_aj = "1"
                Dim ls As String = (dgw1.Item(0, j).Value)
                Try
                    Dim cmd As New SqlCommand("TRANSFERIR_CTAS_CXP_AÑO", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = (dgw1.Item(0, j).Value)
                    cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
                    cmd.Parameters.Add("@fe_año2", SqlDbType.VarChar).Value = CInt(AÑO + 1).ToString("0000")
                    cmd.Parameters.Add("@ST_AJUSTE", SqlDbType.VarChar).Value = st_aj
                    cmd.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TC_ACT
                    con.Open()
                    estado = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If (estado = "FALLO") Then
                    MessageBox.Show("Al tranferir la cuenta: " & dgw1.Item(0, j).Value & vbCrLf & "Regrese y vuelva a transferir.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            j += 1
        Loop
        If VERIFICAR_TRANSF_AÑO() = False Then Exit Sub
        MessageBox.Show("Transferencia Exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Function VERIFICAR_TRANSF_AÑO() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = (dgw1.RowCount - 1)
        For I = 0 To CONT
            If dgw1.Item(2, I).Value = True Then
                Dim ESTADO = "FALLO"
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_TRANSF_AÑO", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = (dgw1.Item(0, I).Value)
                    cmd.Parameters.Add("@fe_año1", SqlDbType.VarChar).Value = AÑO
                    cmd.Parameters.Add("@fe_año2", SqlDbType.VarChar).Value = CInt(AÑO + 1).ToString("0000")
                    con.Open()
                    ESTADO = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If ESTADO = "FALLO" Then
                    MessageBox.Show("Existe diferencia de ajuste en la actualización en la Cuenta Contable " & dgw1.Item(0, I).Value.ToString, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        If MES <> "12" Then
            MessageBox.Show("Solo se puede Des-Transferir en el mes de Diciembre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            If dgw2.Item(2, I).Value = True Then
                DESCONCILIAR_CUENTA(dgw2.Item(0, I).Value.ToString)
            End If
            I += 1
        Loop
        MessageBox.Show("Des-Transferencia Exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click
        main(127) = 0
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
            Dim cmd As New SqlCommand("DESTRANSFERIR_CTAS_CXP_AÑO", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@fe_año2", SqlDbType.Char).Value = CInt(AÑO + 1).ToString("0000")
            cmd.Parameters.Add("@COD_cuenta", SqlDbType.VarChar).Value = (cod_cta)
            cmd.CommandTimeout = 720
            con.Open()
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
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = ("P")
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), False)
                dgw2.Rows.Add(dr.GetString(0), dr.GetString(1), False)
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
    Private Sub CXP_TRANSF_ANA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub CXP_TRANSF_ANA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGW_CUENTAS00()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        btn_aceptar.Select()
    End Sub
    Function VERIFICAR_CIERRE() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = dgw1.RowCount - 1
        For I = 0 To CONT
            If dgw1.Item(2, I).Value = True Then
                Dim RSPTA As Integer = 0
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_CIERRE_CTAS", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@fe_año", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@COD_cuenta", SqlDbType.VarChar).Value = dgw1.Item(0, I).Value.ToString
                    cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                    con.Open()
                    RSPTA = cmd.ExecuteScalar
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If RSPTA = 0 Then
                    MessageBox.Show("Debe cerrar la cuenta " & dgw1.Item(0, I).Value.ToString & " para el Mes de Diciembre. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub ch_ajuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_ajuste.CheckedChanged
        Dim i As Integer = 0
        Do While (i <= (dgw1.RowCount - 1))
            dgw1.Item(3, i).Value = (ch_ajuste.Checked)
            i += 1
        Loop
    End Sub

    Private Sub dgw1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw1.CellClick
        If e.ColumnIndex = 2 Then
            With dgw1
                .Item(3, e.RowIndex).ReadOnly = .Item(2, e.RowIndex).Value
            End With
        End If
    End Sub

    Private Sub dgw1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgw1.CurrentCellDirtyStateChanged
        With dgw1
            If dgw1.IsCurrentCellDirty Then
                dgw1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If Not .Item(2, .CurrentRow.Index).Value Then
                .Item(3, .CurrentRow.Index).Value = False
            End If
        End With
    End Sub
End Class