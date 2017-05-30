Imports System.Data.SqlClient
Public Class REPORTE_PY
    Dim COD_PY As String
    Dim OBJ As New Class1
    Dim REP As New REP_PY
    Private Sub REPORTE_PY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_PY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_PROYECTO()
    End Sub
    Sub CARGAR_PROYECTO()
        cbo_py.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PROYECTO_FECHA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = FECHA_GRAL
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_py.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If (cbo_py.SelectedIndex = -1) And CH_PY.Checked = True Then MessageBox.Show("Debe elegir el Proyecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_py.Focus() : Exit Sub
        If dtp1.Value > dtp2.Value Then MessageBox.Show("Rango de Fechas Incorrecto", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtp2.Focus() : Exit Sub
        Dim ST_PY As String = "0"
        COD_PY = ""
        If CH_PY.Checked = False Then ST_PY = "1"
        If cbo_py.SelectedIndex <> -1 Then COD_PY = OBJ.COD_PROYECTO(cbo_py.Text)
        REP.CREAR_REPORTE(dtp1.Value.Date, dtp2.Value.Date, COD_PY, cbo_py.Text, ST_PY)
        REP.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(131) = 0
        Me.Close()
    End Sub
    Private Sub CH_PY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH_PY.CheckedChanged
        If CH_PY.Checked = True Then
            cbo_py.Enabled = True
        Else
            cbo_py.SelectedIndex = -1
            cbo_py.Enabled = False
        End If
    End Sub
End Class