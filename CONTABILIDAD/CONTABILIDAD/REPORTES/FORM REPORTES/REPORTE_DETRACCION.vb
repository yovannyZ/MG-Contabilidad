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
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Text = OBJ.DESC_MES(MES)
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(132) = 0
        Close()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_aÑo", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
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
        If (cbo_año.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el AÑo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        Dim MES0 As String = OBJ.COD_MES(cbo_mes.Text)
        REP.CREAR_REPORTE(cbo_año.Text, cbo_mes.Text, MES0)
        REP.ShowDialog()
    End Sub
End Class