Imports System.Data.SqlClient
Imports System.Text
Public Class REPORTE_FORMATO_EP_CC
    Private COD_FORMATO, OBS As String
    Private OBJ As New Class1
    Private OFR As New REP_FORMATO_E_P
    Private TEXTO_SELECT As String

    Public Sub CARGAR_TIPO()
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

    Public Function CARGAR_SALDOS() As Boolean
        Dim ESTADO As Boolean = True
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
        Return False
    End Function

    Public Sub CREAR_SELECT()

        Dim SQL As New StringBuilder
        Dim I As Integer = Integer.Parse(CBO_MES_1.Text)
        Dim CONT As Integer = Integer.Parse(CBO_MES_2.Text)
        I = I
        Dim Campo As String
        If COD_FORMATO = "02" Then
            Campo = "COD_CUENTA"
        Else
            Campo = "COD_DESTINO"
        End If
        Do While (I <= CONT)
            If (I = CONT) Then
                SQL.AppendLine(String.Format("ISNULL(IM_DEBITO{0},0) - ISNULL(IM_CREDITO{0},0)", I.ToString("00")))
                'TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0)"
            Else
                SQL.AppendLine(String.Format("ISNULL(IM_DEBITO{0},0) - ISNULL(IM_CREDITO{0},0) + ", I.ToString("00")))
                'TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0) + "
            End If
            I += 1
        Loop
        TEXTO_SELECT = String.Format(("UPDATE RELACION_FORMATO SET IMPORTE = ISNULL((SELECT SUM({0}) FROM MAESTRO_SALDOS_CC M " & _
            "WHERE M.AÑO=@AÑO AND SUBSTRING(M.{1},1,LEN(RELACION_FORMATO.COD_CUENTA))=RELACION_FORMATO.COD_CUENTA),0) " & _
            "WHERE COD_FORMATO=@COD_FORMATO"), SQL.ToString, Campo)

    End Sub

    Private Sub REPORTE_FORMATO_EP_CC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_TIPO()
        CARGAR_AÑO()
    End Sub

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
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
            OFR.CREAR_REPORTE(COD_FORMATO, CBO_MES_2.Text, OBS, dtp1.Value.Date)
            OFR.ShowDialog()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(157) = 0
        Close()
    End Sub
End Class