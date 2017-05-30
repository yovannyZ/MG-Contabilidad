Imports System.Data.SqlClient

Public Class PERIODO_CIERRE
    Dim obj As New Class1
    Sub DATAGRID()
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        Try
            Dim CMD As New SqlCommand("MOSTRAR_PERIODO1", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable
            ADAP.Fill(DT)
            dgw1.DataSource = (DT)
            dgw1.Columns.Item(0).Width = (40)
            dgw1.Columns.Item(2).DefaultCellStyle.Format = ("d")
            dgw1.Columns.Item(3).DefaultCellStyle.Format = ("d")
            dgw1.Columns.Item(4).Visible = False
            'dgw1.Columns.Item(5).Width = (25)
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Sub CARGAR_MODULO()
        dgvModulos.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_MODULO", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("COD_SISTEMA", SqlDbType.Char).Value = "COI"
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                dgvModulos.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), False)
            End While
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CARGAR_DATOS()
        Dim I, CONT As Integer
        I = 0
        CONT = dgvModulos.Rows.Count - 1
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_MODULO_CIERRE", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = nudAño.Value
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text.ToUpper)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                For I = 0 To CONT
                    If dgvModulos.Item(0, I).Value.ToString = Rs3.GetValue(0) AndAlso Rs3.GetValue(1) = 1 Then
                        dgvModulos.Item(2, I).Value = True
                    End If
                Next
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PERIODO_CIERRE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        DATAGRID()
        tpDetalles.Parent = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(46) = 0
        Close()
    End Sub

    Private Sub btn_cierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cierre.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim Año As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        Dim Mes As String = obj.COD_MES(dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString.ToUpper)
        nudAño.Value = Año
        cboMes.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        dtp1.Value = dgw1.Item(2, dgw1.CurrentRow.Index).Value
        dtp2.Value = dgw1.Item(3, dgw1.CurrentRow.Index).Value
        CARGAR_MODULO()
        CARGAR_DATOS()
        nudAño.Enabled = False : cboMes.Enabled = False
        dtp1.Enabled = False : dtp2.Enabled = False
        tpDetalles.Parent = tcPeriodo
        tcPeriodo.SelectedTab = tpDetalles
    End Sub

    Private Sub tcPeriodo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcPeriodo.SelectedIndexChanged
        If sender.SelectedIndex = 0 Then
            tpDetalles.Parent = Nothing
        End If
    End Sub

    Private Sub CerrarPeriodo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim I As Integer
        Dim trx As SqlTransaction
        Try
            con.Open()
            trx = con.BeginTransaction
            Dim Cmd As SqlCommand
            For I = 0 To dgvModulos.Rows.Count - 1
                Cmd = New SqlCommand("MODIFICAR_CIERRE_PERIODO", con, trx)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = dgvModulos.Item(0, I).Value
                Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = nudAño.Value
                Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text.ToUpper)
                Cmd.Parameters.Add("@ESTADO", SqlDbType.Char).Value = dgvModulos.Item(2, I).Value
                Cmd.ExecuteNonQuery()
            Next
            trx.Commit()
            MessageBox.Show("Se Actualizó el cierre de perido", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            trx.Rollback()
            MessageBox.Show(String.Format("Error al actualizar el cierre de periodo.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Cancelar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        tpDetalles.Parent = Nothing
        tcPeriodo.SelectedTab = tpLista
    End Sub
End Class