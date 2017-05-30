Imports System.Data.SqlClient
Public Class BAN_CIERRE_CTAS
    Dim COD_CUENTA, COD_SUCURSAL, cuenta_debe, cuenta_haber As String
    Dim obj As New Class1
    Dim TC_ACT As Decimal
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If ((VERIFICAR_CIERRE() And VERIFICAR_CONCILIACION()) And VERIFICAR_MSALDO_CUENTA_PTES()) Then
            TC_ACT = obj.SACAR_CAMBIO_MENSUAL(AÑO, MES, "D", "V")
            If TC_ACT = 0 Or TC_ACT = Nothing Then
                MessageBox.Show("Debe cargar el Tipo de Cambio Mensual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If (Decimal.Compare(TC_ACT, Decimal.Zero) <> 0) Then
                Dim I As Integer = 0
                Dim CONT As Integer = (dgw1.Rows.Count - 1)
                I = 0
                Do While (I <= CONT)
                    If dgw1.Item(2, I).Value.ToString = "True" Then
                        COD_CUENTA = (dgw1.Item(0, I).Value)
                        If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA, AÑO, MES) = False Then Exit Sub
                        If CERRAR() = False Then
                            MessageBox.Show(("Ocurrió un error con la cuenta " & COD_CUENTA), "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                    End If
                    I += 1
                Loop
                MessageBox.Show("En cierre mensual", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DGW_CUENTAS00()
            End If
        End If
    End Sub
    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If DGW2.Item(2, I).Value.ToString = "True" Then
                COD_CUENTA = (DGW2.Item(0, I).Value)
                'If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA, AÑO, MES) = False Then Exit Sub
                If REGRESAR_CERRAR() = False Then
                    MessageBox.Show(("Ocurrió un error con la cuenta " & COD_CUENTA), "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
            I += 1
        Loop
        MessageBox.Show("Se regresó el cierre mensual.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        DGW_CUENTAS00()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click
        main(22) = 0
        Close()
    End Sub
    Function CERRAR() As Boolean
        Dim RSPTA As Object = "FALLO"
        Try
            Dim cmd As New SqlCommand("CIERRE_CTAS_BANCOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            RSPTA = (cmd.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            RSPTA = "FALLO"
            Return RSPTA
        End Try
        If RSPTA = "EXITO" Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            dgw1.Item(2, i).Value = ch1.Checked
            i += 1
        Loop
    End Sub
    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        Dim CONT As Integer = (DGW2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            DGW2.Item(2, i).Value = ch2.Checked
            i += 1
        Loop
    End Sub
    Private Sub Cierre_Cuentas_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        SendKeys.Send("{tab}")
    End Sub
    Private Sub Cierre_Cuentas_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_CUENTAS00()
        btn_aceptar.Select()
    End Sub
    Sub DGW_CUENTAS00()
        dgw1.Rows.Clear()
        DGW2.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_CIERRE", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = "B"
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
        '------------------------------------------------------------------
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_CIERRE_PTE", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = "B"
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                DGW2.Rows.Add(dr.GetString(0), dr.GetString(1), False)
            Loop
            con.Close()
            DGW2.Columns.Item(0).ReadOnly = True
            DGW2.Columns.Item(1).ReadOnly = True
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Function REGRESAR_CERRAR() As Boolean
        Dim RSPTA As Object = "FALLO"
        Try
            Dim cmd As New SqlCommand("REGRESAR_CIERRE_CTAS_BANCOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            RSPTA = (cmd.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            RSPTA = "FALLO"
            Return False
        End Try
        If RSPTA = "EXITO" Then
            Return True
        Else
            Return False
        End If
    End Function
    Function VERIFICAR_CIERRE() As Boolean
        Dim RSPTA As String = "NO"
        Dim i As Integer = 0
        Dim l As Integer = (dgw1.Rows.Count - 1)
        Dim CONT As Integer = l
        i = 0
        Do While (i <= CONT)
            If dgw1.Item(2, i).Value.ToString = "True" Then
                Dim cod_cuenta0 As Object = dgw1.Item(0, i).Value.ToString
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_PROCESO_CIERRE", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = cod_cuenta0
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                    con.Open()
                    RSPTA = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If (RSPTA = "SI") Then
                    MessageBox.Show((String.Concat(String.Concat("La Cuenta ", cod_cuenta0), " ya se encuentra cerrada para el año y mes de proceso.")), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
            i += 1
        Loop
        Return True
    End Function
    Function VERIFICAR_CONCILIACION() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            If dgw1.Item(2, I).Value.ToString = "True" Then
                Dim COD_CUENTA0 As String = dgw1.Item(0, I).Value.ToString
                Dim IMP As New Decimal
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_CONCILIACION", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA0
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                    con.Open()
                    IMP = Decimal.Parse(cmd.ExecuteScalar)
                    con.Close()
                    If (Decimal.Compare(IMP, Decimal.Zero) > 0) Then
                        MessageBox.Show(("Las cuenta " & COD_CUENTA0 & " tiene descuadre en la Conciliación."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    Return False
                End Try
            End If
            I += 1
        Loop
        Return True
    End Function
    Function VERIFICAR_MSALDO_CUENTA_PTES() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            If dgw1.Item(2, I).Value.ToString = "True" Then

                Dim COD_CUENTA0 As String = dgw1.Item(0, I).Value.ToString
                Dim IMP As New Decimal
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_SALDOS_MAESTROS_BAN_PTES", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA0
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                    con.Open()
                    IMP = Decimal.Parse(cmd.ExecuteScalar)
                    con.Close()
                    If (Decimal.Compare(IMP, Decimal.Zero) <> 0) Then
                        MessageBox.Show(("Las cuenta " & COD_CUENTA0 & " tienes errores en Saldos."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    Return False
                End Try
            End If
            I += 1
        Loop
        Return True
    End Function
End Class