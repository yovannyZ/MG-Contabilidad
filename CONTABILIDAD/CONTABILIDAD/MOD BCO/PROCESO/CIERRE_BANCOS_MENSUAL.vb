Imports System.Data.SqlClient
Public Class CIERRE_BANCOS_MENSUAL
    Dim AÑO0, COD_BAN0, MES0, STATUS_B As String
    Dim obj As New Class1
    Dim SALDO_REP_CONC, SALDO_REP_LIBRO, SALDO1, SALDO2 As Decimal
    Private Sub btn_contable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_contable.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        AÑO0 = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        MES0 = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        COD_BAN0 = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If REGRESAR_CONCILIACION_MES() = "EXITO" Then
            MessageBox.Show("Se regresó el cierre de la cuenta", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DATAGRID()
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString = "False" Then
            MessageBox.Show("La Cuenta no se encuentra bloqueada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            AÑO0 = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
            MES0 = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
            COD_BAN0 = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
            HALLAR_ESTADO_BANCO()
            HALLAR_SALDO_LIBRO()
            HALLAR_SALDO_CONC()
            If CIERRE_CONCILIACION_MES() = "EXITO" Then
                MessageBox.Show("La Cuenta se cerró", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                DATAGRID()
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        main(7) = 0
        Close()
    End Sub
    Function CIERRE_CONCILIACION_MES() As Object
        Dim AÑO1 As Integer
        Dim MES1 As Integer
        If (MES0 = "01") Then
            MES1 = 12
            AÑO1 = CInt(Math.Round(CDbl((Decimal.Parse(AÑO0) - 1))))
        Else
            MES1 = CInt(Math.Round(CDbl((Decimal.Parse(MES0) - 1))))
            AÑO1 = Integer.Parse(AÑO0)
        End If
        Dim ESTADO As String = "FALLO"
        SALDO1 = New Decimal
        SALDO2 = New Decimal
        Try
            Dim CMD As New SqlCommand("CIERRE_CONCILIACION_MES", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            CMD.Parameters.Add("@FE_MES_ANT", SqlDbType.Char).Value = MES1.ToString("00")
            CMD.Parameters.Add("@FE_AÑO_ANT", SqlDbType.Char).Value = AÑO1.ToString("0000")
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BAN0
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                If Rs3.GetValue(0) = "EXITO" Then
                    ESTADO = "EXITO"
                ElseIf (Rs3.GetValue(0)) = "EXCEPCION" Then
                    SALDO1 = Decimal.Parse(Rs3.GetValue(1))
                    SALDO2 = Decimal.Parse(Rs3.GetValue(2))
                    ESTADO = "FALLO"
                    MessageBox.Show(("Saldo Contable :                          " & (SALDO1) & vbCrLf & vbCrLf & "Saldo Estado de Cuenta :         " & (SALDO2)), "No se puede cerrar Banco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    ESTADO = "FALLO"
                    MessageBox.Show("Vuelva a intentarlo", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Loop
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
            ESTADO = "FALLO"
        End Try
        Return ESTADO
    End Function
    Private Sub CIERRE_MENSUAL_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CIERRE_MENSUAL_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DATAGRID()
    End Sub
    Sub DATAGRID()
        Try
            Dim pro As New SqlCommand("MOSTRAR_SALDO_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Bancos")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(9).Visible = False
            dgw1.Columns.Item(10).Visible = False
            dgw1.Columns.Item(0).Width = 60
            dgw1.Columns.Item(1).Width = 150
            dgw1.Columns.Item(2).Width = 32
            dgw1.Columns.Item(3).Width = 32
            dgw1.Columns.Item(6).Width = 40
            dgw1.Columns.Item(7).Width = &H2B
            dgw1.Columns.Item(8).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub HALLAR_ESTADO_BANCO()
        STATUS_B = "0"
        Try
            Dim CMD As New SqlCommand("HALLAR_ESTADO_BANCO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BAN0
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                STATUS_B = Rs3.GetString(0)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Sub HALLAR_SALDO_CONC()
        SALDO_REP_CONC = New Decimal
        Try
            Dim pro As New SqlCommand("HALLAR_SALDO_REPORTE_CONC", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            pro.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            pro.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BAN0
            con.Open()
            SALDO_REP_CONC = Decimal.Parse(pro.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub HALLAR_SALDO_LIBRO()
        SALDO_REP_LIBRO = New Decimal
        Dim MES_ANT00 As Integer = CInt(Math.Round(CDbl((Decimal.Parse(MES0) - 1))))
        Try
            Dim pro As New SqlCommand("HALLAR_SALDO_REPORTE_LIBRO", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@MES_ANTERIOR", SqlDbType.Char).Value = MES_ANT00.ToString("00")
            pro.Parameters.Add("@MES_ACTUAL", SqlDbType.Char).Value = MES0
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO0
            pro.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BAN0
            con.Open()
            SALDO_REP_LIBRO = Decimal.Parse(pro.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Function REGRESAR_CONCILIACION_MES() As Object
        Dim ESTADO As String = "FALLO"
        Try
            Dim CMD As New SqlCommand("REGRESAR_CIERRE_CONCILIACION_MES", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BAN0
            con.Open()
            ESTADO = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
            ESTADO = "FALLO"
        End Try
        Return ESTADO
    End Function
End Class