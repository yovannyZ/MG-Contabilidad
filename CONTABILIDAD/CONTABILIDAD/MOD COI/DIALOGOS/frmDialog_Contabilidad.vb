Imports System.Data.SqlClient
Public Class frmDialog_Contabilidad
    Public Sub CargarDocumentos(ByVal Año As String, ByVal Mes As String, ByVal Codcuenta As String)
        dgvTCon.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_T_CON_DIFERIDO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = Año
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Mes
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = Codcuenta
            con.Open()
            Dim iar As IAsyncResult = cmd.BeginExecuteReader()
            Using Rs As SqlDataReader = cmd.EndExecuteReader(iar)
                While (Rs.Read)
                    dgvTCon.Rows.Add(Rs.GetValue(0), Rs.GetValue(1), Rs.GetValue(2), Rs.GetValue(3), _
                                     Rs.GetValue(4), Rs.GetValue(5), Rs.GetValue(6), Rs.GetValue(7), _
                                     Rs.GetValue(8), Rs.GetValue(9), Rs.GetValue(10), Rs.GetValue(11), _
                                     Rs.GetValue(12), Rs.GetValue(13), Rs.GetValue(14), Rs.GetValue(15), _
                                     Rs.GetValue(16), Rs.GetValue(17))
                End While
            End Using
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub
End Class