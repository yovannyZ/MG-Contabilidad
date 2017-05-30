Imports System.Data.SqlClient
Public Class REPORTE_DIFERIDO
    Dim rep As New REP_DIFERIDO
    Dim obj As New Class1

#Region "Metodos y Funciones"

    Private Sub CargarAño()
        cboAño.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_AÑO_TODO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            con.Open()
            Using Rs3 As SqlDataReader = PROG_01.ExecuteReader()
                Do While Rs3.Read
                    cboAño.Items.Add(Rs3.GetString(0))
                Loop
            End Using
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CargarCuentas()
        Try
            Dim cmd As New SqlCommand("A_COD_TABLA_DIR", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@T_COD", SqlDbType.VarChar).Value = "T_DIF"
            con.Open()
            Dim iar As IAsyncResult = cmd.BeginExecuteReader
            Using Rs As SqlDataReader = cmd.EndExecuteReader(iar)
                While (Rs.Read)
                    cboCuenta.Items.Add(Rs.GetValue(0))
                End While
            End Using
            con.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

#End Region

#Region "Botones"

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantalla.Click
        If cboCuenta.SelectedIndex = -1 Then MessageBox.Show("Debe elegir una Cuenta", "Reporte Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If cboAño.SelectedIndex = -1 Then MessageBox.Show("Debe elegir un año", "Reporte Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If cboMes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir un mes", "Reporte Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Dim mes = obj.COD_MES(cboMes.SelectedItem.ToString)
        rep.CREAR_REPORTE(cboAño.Text, mes, cboCuenta.Text)
        rep.ShowDialog()
    End Sub

#End Region

#Region "Eventos"

    Private Sub REPORTE_DIFERIDO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAño()
        CargarCuentas()
    End Sub

#End Region


End Class