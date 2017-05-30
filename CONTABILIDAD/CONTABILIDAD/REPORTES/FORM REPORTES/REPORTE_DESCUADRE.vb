Imports System.Data.SqlClient
Public Class REPORTE_DESCUADRE
    Private OBJ As New Class1

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        Else
            Dim REP As New REP_DESCUADRE_COMP
            Dim TIPO As String = "C"
            If ch_comp.Checked = True Then
                TIPO = "C"
            End If
            If ch_descuadre.Checked Then
                TIPO = "D"
            End If
            If ch_destino.Checked Then
                TIPO = "A"
            End If
            REP.CREAR_REPORTE(TIPO, cbo_a�o.Text, OBJ.COD_MES(cbo_mes.Text), cbo_mes.Text)
            'REP.CREAR_REPORTE(TIPO, A�O, MES, OBJ.DESC_MESMES)
            REP.ShowDialog()
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(54) = 0
        Me.Close()
    End Sub
    Private Sub REPORTE_DESCUADRE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_A�O()
        cbo_a�o.Text = A�O
    End Sub
    Sub CARGAR_A�O()
        cbo_a�o.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_a�o", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_a�o.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class