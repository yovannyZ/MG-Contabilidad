Imports System.Data.SqlClient
Public Class REPORTE_DETRACCION
    Dim OBJ As New Class1
    Dim REP As New REP_DETRACCION
    Private Sub REPORTE_DETRACCION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_DETRACCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_A�O()
        cbo_a�o.Text = A�O
        cbo_mes.Text = OBJ.DESC_MES(MES)
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(132) = 0
        Close()
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

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If (cbo_mes.SelectedIndex = -1) Then MessageBox.Show("Debe elegir un Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If (cbo_a�o.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el A�o", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_a�o.Focus() : Exit Sub
        Dim MES0 As String = OBJ.COD_MES(cbo_mes.Text)
        REP.CREAR_REPORTE(cbo_a�o.Text, cbo_mes.Text, MES0)
        REP.ShowDialog()
    End Sub
End Class