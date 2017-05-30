Imports System.Data.SqlClient
Public Class REPORTE_FORMATO_EP_PER
    Dim COD_FORMATO, OBS, TEXTO_SELECT, TEXTO_SELECT2 As String
    Private OBJ As New Class1
    Private OFR As New REP_FORMATO_E_P_PER
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (CBO_MES_1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_MES_1.Focus()
        ElseIf (CBO_MES_2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_MES_2.Focus()
        ElseIf (cbo_FORMATO.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Formato", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_FORMATO.Focus()
        Else
            COD_FORMATO = OBJ.COD_FORMATO(cbo_FORMATO.Text)
            OBS = OBJ.HALLAR_OBS_FORMATO(COD_FORMATO)
            CREAR_SELECT()
            CARGAR_SALDOS()
            OFR.CREAR_REPORTE(COD_FORMATO, CBO_MES_2.Text, OBS, dtp1.Value.Date, (Decimal.Parse(cbo_año.Text) - 1).ToString("0000"))
            OFR.ShowDialog()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(68) = 0
        Me.Close()
    End Sub

    Function CARGAR_SALDOS() As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim CMD As New SqlCommand(TEXTO_SELECT2, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = (Decimal.Parse(cbo_año.Text) - 1).ToString
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = False
        End Try
        Try
            Dim CMD As New SqlCommand(TEXTO_SELECT, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = False
        End Try
        Try
            Dim CMD2 As New SqlCommand("ACT_PORCENTAJE_FORMATO_EP", con)
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            CMD2.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = False
        End Try
        Try
            Dim CMD2 As New SqlCommand("ACT_PORCENTAJE_FORMATO_EP2", con)
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            CMD2.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = False
        End Try
        Return False
    End Function
    Sub cargar_tipo()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_FORMATO_TIPO_EP", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_FORMATO.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CREAR_SELECT()
        TEXTO_SELECT = ""
        Dim I As Integer = Integer.Parse(CBO_MES_1.Text)
        Dim CONT As Integer = Integer.Parse(CBO_MES_2.Text)
        I = I
        Do While (I <= CONT)
            If (I = CONT) Then
                TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0)"
            Else
                TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0) + "
            End If
            I += 1
        Loop
        TEXTO_SELECT2 = ("UPDATE RELACION_FORMATO SET IMPORTE2 = (SELECT SUM(" & TEXTO_SELECT & ") FROM MAESTRO_SALDOS M WHERE M.AÑO=@AÑO AND M.COD_CUENTA=RELACION_FORMATO.COD_CUENTA) WHERE COD_FORMATO=@COD_FORMATO")
        TEXTO_SELECT = ("UPDATE RELACION_FORMATO SET IMPORTE = (SELECT SUM(" & TEXTO_SELECT & ") FROM MAESTRO_SALDOS M WHERE M.AÑO=@AÑO AND M.COD_CUENTA=RELACION_FORMATO.COD_CUENTA) WHERE COD_FORMATO=@COD_FORMATO")
    End Sub
    Private Sub REPORTE_BALANCE_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cargar_tipo()
        CARGAR_AÑO()
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
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub REPORTE_FORMATO_EP_PER_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class