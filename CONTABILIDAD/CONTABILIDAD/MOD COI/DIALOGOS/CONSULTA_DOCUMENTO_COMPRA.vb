Public Class CONSULTA_DOCUMENTO_COMPRA
    Public codPer, codDoc, nroDoc As String
    Public fechaIni, fechaFin As Date

    Public seleccion As Boolean



    Private Sub CONSULTA_DOCUMENTO_CLIENTE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Consultar()
    End Sub

    Private Sub Consultar()

        dgw1.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("OBTENER_DOCUMENTOS_COMPRA", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codPer
            cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codDoc
            cmd.Parameters.Add("@FE_INICIO", SqlDbType.Date).Value = fechaIni
            cmd.Parameters.Add("@FE_FIN", SqlDbType.Date).Value = fechaFin
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetValue(0), dr.GetValue(1), dr.GetValue(2), dr.GetValue(3), dr.GetValue(4), dr.GetValue(5), dr.GetValue(6), _
                dr.GetValue(7), dr.GetValue(8), dr.GetValue(9), dr.GetValue(10), dr.GetValue(11), dr.GetValue(12), dr.GetValue(13), dr.GetValue(14), _
                dr.GetValue(15), dr.GetValue(16), dr.GetValue(17), dr.GetValue(18))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If dgw1.CurrentRow IsNot Nothing Then
            codDoc = dgw1.Item(3, dgw1.CurrentRow.Index).Value
            nroDoc = dgw1.Item(4, dgw1.CurrentRow.Index).Value
            seleccion = True
            Close()
        Else
            MessageBox.Show("Seleccione un  registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        seleccion = False
        Close()
    End Sub
End Class