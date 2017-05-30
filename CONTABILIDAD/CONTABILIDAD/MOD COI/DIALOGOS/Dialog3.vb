Imports System.Data.SqlClient
Public Class Dialog3
    Public COD_CTA, NRO_DOC, COD_DOC, COD_PER, AÑO00, MES00, TIPO_CARGA As String

    Private Sub BTN_ACEPTAR_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ACEPTAR.Click
        Dim num As Integer = (DGW_DET.Rows.Count - 1)
        Dim num3 As Integer = num
        Dim i As Integer = 0
        Do While (i <= num3)
            'Dim iTEM As String = (DGW_DET.Item(0, i).Value)
            MessageBox.Show("El Analisis Ctas x Pagar se agregó ", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Do
            i += 1
        Loop
    End Sub
    
    Sub CARGAR_DETALLES_TCON()
        DGW_DET.Rows.Clear()
        Try
            Dim command As New SqlCommand("CONSULTA_FIJO_TCON", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CTA
            command.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = COD_DOC
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            command.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
            command.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO00
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES00

            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW_DET.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), False, reader.GetValue(13), reader.GetValue(14), reader.GetValue(15), reader.GetValue(16), reader.GetValue(17), reader.GetValue(18), reader.GetValue(19), reader.GetValue(20), reader.GetValue(21), reader.GetValue(22))
            Loop
            reader.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Dialog2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        DGW_DET.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        If TIPO_CARGA = "TCON" Then
            CARGAR_DETALLES_TCON()
        End If
        'CARGAR_DETALLES_ANALISIS()
    End Sub
    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CANCELAR.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Hide()
    End Sub
End Class