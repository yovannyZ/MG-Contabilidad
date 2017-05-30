Imports System.Data.SqlClient
Public Class INICIO_AÑO
    Public Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub INICIO_AÑO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_AÑO()
        cbo_año.Text = AÑO
    End Sub
    Private Sub btn_aceptar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar1.Click
        Dim ESTADO As String = "EXITO"
        Try
            Dim CMD As New SqlCommand("INICIAR_AÑO_CONTABLE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@AÑO_ACTUAL", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text
            con.Open()
            ESTADO = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = "FALLO"
        End Try
        Select Case ESTADO
            Case "EXITO"
                MessageBox.Show("El nuevo año contable se ha creado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case "EXISTE"
                MessageBox.Show("El nuevo año contable  ya tiene cuentas contables o saldos o numeración de comprobante, elimine y vuelva a realizar el proceso.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case "FALLO"
                MessageBox.Show("Ocurrio un error.", "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Select
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main(120) = 0
        Close()
    End Sub
End Class