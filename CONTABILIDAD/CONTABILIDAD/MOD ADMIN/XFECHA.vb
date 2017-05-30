Imports System.Data.SqlClient
Public Class XFECHA
    Dim fecha_proceso2 As Date
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        Try
            Dim PROG_01 As New SqlCommand("modificar_x_fecha_fin", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@modulo", SqlDbType.VarChar).Value = COD_MOD
            PROG_01.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dtp1.Value
            con.Open()
            PROG_01.ExecuteNonQuery()
            con.Close()
            FECHA_GRAL = dtp1.Value
            AÑO = FECHA_GRAL.Year
            MES = FECHA_GRAL.ToString("MM")
            DIA = FECHA_GRAL.ToString("dd")
            MessageBox.Show("La fecha de proceso se ha modificado", "Mensaje:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            main(8) = 0
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(8) = 0
        Close()
    End Sub
    Private Sub XFECHA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp1.Value = FECHA_GRAL
    End Sub
End Class