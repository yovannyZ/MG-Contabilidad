Imports System.Data.SqlClient
Public Class OTROS_CIERRE_CTAS
    Dim COD_CUENTA, COD_SUCURSAL, cuenta_debe, cuenta_haber As String
    Private obj As New Class1
    Private TC_ACT As Decimal
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If (obj.ValidarCierreCuentas("OC", A�O, obj.COD_MES(cbo_mes1.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '----------------------------
        If obj.COD_MES(cbo_mes1.Text) <> "01" Then
            If VERIFICAR_CIERRE_MES_ANTERIOR() = True Then
                If ((VERIFICAR_CIERRE() And VERIFICAR_CONCILIACION()) And VERIFICAR_MSALDO_CUENTA_PTES()) Then
                    TC_ACT = obj.SACAR_CAMBIO_MENSUAL(A�O, obj.COD_MES(cbo_mes1.Text), "D", "V")
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
                                If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA, A�O, obj.COD_MES(cbo_mes1.Text)) = False Then Exit Sub
                                If CERRAR() = False Then
                                    MessageBox.Show(("Ocurri� un error con la cuenta " & COD_CUENTA), "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Return
                                End If
                            End If
                            I += 1
                        Loop
                        MessageBox.Show("En cierre mensual", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGW_CUENTAS00()
                    End If
                End If
            End If
            '----------------------------
        Else
            If ((VERIFICAR_CIERRE() And VERIFICAR_CONCILIACION()) And VERIFICAR_MSALDO_CUENTA_PTES()) Then
                TC_ACT = obj.SACAR_CAMBIO_MENSUAL(A�O, obj.COD_MES(cbo_mes1.Text), "D", "V")
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
                            If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA, A�O, obj.COD_MES(cbo_mes1.Text)) = False Then Exit Sub
                            If CERRAR() = False Then
                                MessageBox.Show(("Ocurri� un error con la cuenta " & COD_CUENTA), "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Return
                            End If
                        End If
                        I += 1
                    Loop
                    MessageBox.Show("En cierre mensual", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DGW_CUENTAS00()
                End If
            End If
        End If
    End Sub
    Function VERIFICAR_CIERRE_MES_ANTERIOR() As Boolean
        Dim RSPTA As String = "NO"
        Dim i As Integer = 0
        Dim l As Integer = (dgw1.Rows.Count - 1)
        i = 0
        Do While (i <= l)
            If dgw1.Item(2, i).Value = True Then
                Dim cod_cuenta0 As Object = dgw1.Item(0, i).Value.ToString
                Dim MES_ANT As String = (Integer.Parse(obj.COD_MES(cbo_mes1.Text) - 1)).ToString("00")
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_PROCESO_CIERRE", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = cod_cuenta0
                    cmd.Parameters.Add("@FE_A�O", SqlDbType.Char).Value = A�O
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES_ANT
                    con.Open()
                    RSPTA = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If RSPTA = "SI" Then
                Else
                    MessageBox.Show("Falta cerrar la Cuenta " & cod_cuenta0 & " del mes anterior y a�o de proceso.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
            i += 1
        Loop
        Return True
    End Function
    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        If (obj.ValidarCierreCuentas("OC", A�O, obj.COD_MES(cbo_mes2.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW2.Rows.Count - 1)
        I = 0
        Do While (I <= CONT)
            If DGW2.Item(2, I).Value.ToString = "True" Then
                COD_CUENTA = (DGW2.Item(0, I).Value)
                'If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA, A�O, MES) = False Then Exit Sub
                If REGRESAR_CERRAR() = False Then
                    MessageBox.Show(("Ocurri� un error con la cuenta " & COD_CUENTA), "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
            I += 1
        Loop
        MessageBox.Show("Se regres� el cierre mensual.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        DGW_CUENTAS00()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click
        main(23) = 0
        Close()
    End Sub
    Function CERRAR() As Boolean
        Dim RSPTA As Object = "FALLO"
        Try
            Dim cmd As New SqlCommand("CIERRE_CTAS_PAGAR", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
            cmd.Parameters.Add("@FE_A�O", SqlDbType.Char).Value = A�O
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes1.Text)
            con.Open()
            RSPTA = (cmd.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            Return False
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
        cbo_mes1.Text = obj.DESC_MES(MES)
        cbo_mes2.Text = obj.DESC_MES(MES)
    End Sub
    Sub DGW_CUENTAS00()
        dgw1.Rows.Clear()
        DGW2.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_CIERRE", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@FE_A�O", SqlDbType.VarChar).Value = A�O
            cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes1.Text)
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = "O"
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
            cmd.Parameters.Add("@FE_A�O", SqlDbType.VarChar).Value = A�O
            cmd.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes2.Text)
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = ("O")
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
            Dim cmd As New SqlCommand("REGRESAR_CIERRE_CTAS_PAGAR", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA
            cmd.Parameters.Add("@FE_A�O", SqlDbType.Char).Value = A�O
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes2.Text)
            con.Open()
            RSPTA = (cmd.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
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
        i = 0
        Do While (i <= l)
            If dgw1.Item(2, i).Value.ToString = "True" Then
                Dim cod_cuenta0 As Object = dgw1.Item(0, i).Value.ToString
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_PROCESO_CIERRE", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = cod_cuenta0
                    cmd.Parameters.Add("@FE_A�O", SqlDbType.Char).Value = A�O
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes1.Text)
                    con.Open()
                    RSPTA = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                If (RSPTA = "SI") Then
                    MessageBox.Show((String.Concat(String.Concat("La Cuenta ", cod_cuenta0), " ya se encuentra cerrada para el a�o y mes de proceso.")), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    Dim cmd As New SqlCommand("VERIFICAR_CONCILIACION_OTROS", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA0
                    cmd.Parameters.Add("@FE_A�O", SqlDbType.Char).Value = A�O
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes1.Text)
                    con.Open()
                    IMP = Decimal.Parse(cmd.ExecuteScalar)
                    con.Close()
                    If (Decimal.Compare(IMP, Decimal.Zero) > 0) Then
                        MessageBox.Show(("Las cuenta " & COD_CUENTA0 & " tiene descuadre en la Conciliaci�n."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    Dim cmd As New SqlCommand("VERIFICAR_SALDOS_MAESTROS_OTROS_PTES", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = COD_CUENTA0
                    cmd.Parameters.Add("@FE_A�O", SqlDbType.Char).Value = A�O
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes1.Text)
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

    Friend WithEvents btn_aceptar As Button
    Friend WithEvents btn_aceptar2 As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_salir2 As Button
    Friend WithEvents ch1 As CheckBox
    Friend WithEvents ch2 As CheckBox
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents desc As DataGridViewTextBoxColumn
    Friend WithEvents dgw_doc As DataGridView
    Friend WithEvents dgw1 As DataGridView
    Friend WithEvents DGW2 As DataGridView
    Friend WithEvents Elegir As DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Private Sub cbo_mes1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes1.SelectedIndexChanged
        DGW_CUENTAS00()
    End Sub
    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes2.SelectedIndexChanged
        DGW_CUENTAS00()
    End Sub
End Class