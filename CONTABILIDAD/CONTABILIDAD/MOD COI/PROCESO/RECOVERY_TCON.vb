Imports System.Data.SqlClient
Public Class RECOVERY_TCON
    Dim AÑO0, MES0 As String
    Dim OBJ As New Class1

    Function VERIFICA_CTAS() As Boolean
        Dim _existe As Boolean = True
        Try
            Dim CMD As New SqlCommand("VERIFICA_CTA_RECOVERY", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            con.Open()
            Dim DR As SqlDataReader = CMD.ExecuteReader()
            While DR.Read
                MessageBox.Show("Puede que la cuenta del comprobante no exista, por favor verifique!!!" & vbNewLine & "Comp.: " & DR.GetValue(0) & _
                vbNewLine & " Nro. " & DR.GetValue(1), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                _existe = False
            End While
        Catch ex As Exception
            MessageBox.Show("Error al consultar:" & vbNewLine & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _existe = False
        Finally
            con.Close()
        End Try
        Return _existe
    End Function

    Function VERIFICA_CTAS_MAESTRO() As Boolean
        Dim _existe As Boolean = True
        Try
            Dim CMD As New SqlCommand("VERIFICA_CTA_RECOVERY_MAESTRO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            con.Open()
            Dim DR As SqlDataReader = CMD.ExecuteReader()
            While DR.Read
                MessageBox.Show(String.Format("No existe la cuenta en el maestro, por favor verifique.{0}Cta: {1}  Año: {2}  Aux: {3} Comp: {4} Nro: {5}", _
                Environment.NewLine, DR.GetValue(0), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4)), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                _existe = False
            End While
        Catch ex As Exception
            MessageBox.Show("Error al consultar:" & vbNewLine & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _existe = False
        Finally
            con.Close()
        End Try
        Return _existe
    End Function

    Private Sub btn_aceptar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar1.Click
        Dim ESTADO As String = "FALLO"
        AÑO0 = cbo_año.Text
        MES0 = (OBJ.COD_MES(cbo_mes.Text))

        If Not VERIFICA_CTAS() Then
            Exit Sub
        End If
        If Not VERIFICA_CTAS_MAESTRO() Then
            Exit Sub
        End If
        Try
            Dim CMD As New SqlCommand("RECOVERY_SALDOS", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES0
            CMD.CommandTimeout = 720
            con.Open()
            ESTADO = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        If (ESTADO = "FALLO") Then
            MessageBox.Show("Ocurrió un error.", "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("El recovery se realizó.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        Dim ESTADO As String = "FALLO"
        AÑO0 = cbo_año2.Text
        MES0 = (OBJ.COD_MES(cbo_mes2.Text))
        Try
            Dim CMD As New SqlCommand("RECOVERY_AUTOMATICAS", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES0
            CMD.CommandTimeout = 720
            con.Open()
            ESTADO = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"

        End Try
        If (ESTADO = "FALLO") Then
            MessageBox.Show("Ocurrió un error.", "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("El recovery se realizó.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click, btn_salir2.Click
        main(85) = 0
        Close()
    End Sub

    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_año2.Items.Add(Rs3.GetString(0))
                'cbo_año3.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub RECOVERY_TCON_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub RECOVERY_TCON_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_año2.Text = AÑO
    End Sub
End Class