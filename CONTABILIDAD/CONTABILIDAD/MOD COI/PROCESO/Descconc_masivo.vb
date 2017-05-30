
Imports System.Data.SqlClient
Public Class Descconc_masivo

    Sub cargar_cuentas()
        Try
            Dim cmd As New SqlCommand("Cuentas_p", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), False)
            Loop
            con.Close()
            'dgw1.Columns.Item(0).SortMode = (0)
            'dgw1.Columns.Item(1).SortMode = (0)
            'dgw1.Columns.Item(2).SortMode = (0)
            'dgw1.Columns.Item(0).ReadOnly = (True)
            'dgw1.Columns.Item(1).ReadOnly = (True)
            '----------------------------------------------
            dgw1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            dgw1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            dgw1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            dgw1.Columns(0).ReadOnly = True
            dgw1.Columns(1).ReadOnly = True
            '-----------------------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Descconc_masivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargar_cuentas()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click

    End Sub
End Class