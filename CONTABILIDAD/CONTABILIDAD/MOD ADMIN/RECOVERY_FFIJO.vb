Imports System.Data.SqlClient
Public Class RECOVERY_FFIJO
    Private obj As New Class1
    Private Fila As Integer
    Private Estado As Boolean

    Sub CARGAR_AÑO()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_AÑO_PERIODO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim drd As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing Then
                While drd.Read
                    cboAño.Items.Add(drd.GetString(0))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Sub HISTORIAL(ByVal idx As Integer)
        Try
            Dim Cmd As New SqlCommand("CTA_X_PAGAR_FFIJO_DETALLE", con)
            Cmd.CommandType = (CommandType.StoredProcedure)
            Cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = dgvDatos.Item(0, idx).Value.ToString
            Cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgvDatos.Item(1, idx).Value.ToString
            Cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgvDatos.Item(2, idx).Value.ToString
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAño.Text
            Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text)
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim drd As SqlDataReader = Cmd.ExecuteReader
            Do While drd.Read
                With drd
                    dgvDetalle.Rows.Add(.GetValue(0), .GetValue(1), .GetValue(2), .GetValue(3), _
                    .GetValue(4), .GetValue(5), .GetValue(6), .GetValue(7), .GetValue(8), _
                    .GetValue(9), .GetValue(10), .GetValue(11), .GetValue(12), .GetValue(13), _
                    .GetValue(14), .GetValue(15), .GetValue(16), .GetValue(17), .GetValue(18), _
                    .GetValue(19), .GetValue(20), .GetValue(21), .GetValue(22), .GetValue(23), _
                    .GetValue(24))
                End With
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub RECOVERY_FFIJO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(47) = 0
    End Sub

    Private Sub RECOVERY_FFIJO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_AÑO()
    End Sub

    Private Sub Salir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        main(47) = 0
        Close()
    End Sub

    Private Sub Consultar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta3.Click
        dgvDatos.Rows.Clear()
        dgvDetalle.Rows.Clear()
        Try
            con.Open()
            Dim cmd As New SqlCommand("CTA_X_PAGAR_FFIJO", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Direction = ParameterDirection.Input : par0.Value = cboAño.Text
            par1.Direction = ParameterDirection.Input : par1.Value = obj.COD_MES(cboMes.Text)
            Dim drd As SqlDataReader = cmd.ExecuteReader()
            If drd IsNot Nothing Then
                If drd.HasRows Then
                    While drd.Read
                        With drd
                            dgvDatos.Rows.Add(.GetValue(0), .GetValue(1), .GetValue(2), _
                            .GetValue(3), .GetValue(4), .GetValue(5), .GetValue(6), True, _
                            .GetValue(7), .GetValue(8), .GetValue(9), .GetValue(10))
                        End With
                    End While
                Else
                    MessageBox.Show("No existen datos a mostrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("No se pudo cargar los datos. {0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub MostrarDetalle(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellEnter
        If dgvDatos.CurrentRow IsNot Nothing Then
            dgvDetalle.Rows.Clear()
            Fila = dgvDatos.CurrentRow.Index
            If con.State <> ConnectionState.Open Then
                HISTORIAL(Fila)
            End If
        End If
    End Sub

    Private Sub Limpiar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_LIMP3.Click
        dgvDatos.Rows.Clear()
        dgvDetalle.Rows.Clear()
    End Sub

    Private Sub Eliminar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim rpta As MsgBoxResult = MessageBox.Show("Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If rpta = MsgBoxResult.Yes Then
            Dim trx As SqlTransaction
            Try
                con.Open()
                trx = con.BeginTransaction
                For i As Integer = 0 To dgvDatos.Rows.Count - 1
                    If dgvDatos.Item(7, i).Value.Equals(True) Then
                        Dim cmd As New SqlCommand("ELIMINAR_CTA_X_PAGAR_FFIJO", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim par0 As SqlParameter = cmd.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char)
                        Dim par1 As SqlParameter = cmd.Parameters.Add("@COD_PER", SqlDbType.Char)
                        Dim par2 As SqlParameter = cmd.Parameters.Add("@COD_DOC", SqlDbType.Char)
                        Dim par3 As SqlParameter = cmd.Parameters.Add("@NRO_DOC", SqlDbType.Char)
                        Dim par4 As SqlParameter = cmd.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char)
                        Dim par5 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
                        Dim par6 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
                        par0.Direction = ParameterDirection.Input : par0.Value = dgvDatos.Item(9, i).Value
                        par1.Direction = ParameterDirection.Input : par1.Value = dgvDatos.Item(2, i).Value
                        par2.Direction = ParameterDirection.Input : par2.Value = dgvDatos.Item(0, i).Value
                        par3.Direction = ParameterDirection.Input : par3.Value = dgvDatos.Item(1, i).Value
                        par4.Direction = ParameterDirection.Input : par4.Value = dgvDatos.Item(10, i).Value
                        par5.Direction = ParameterDirection.Input : par5.Value = cboAño.Text
                        par6.Direction = ParameterDirection.Input : par6.Value = obj.COD_MES(cboMes.Text)
                        cmd.ExecuteNonQuery()

                        cmd = New SqlCommand("ELIMINAR_CTA_X_PAGAR_FFIJO_DETALLE", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        par0 = cmd.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char)
                        par1 = cmd.Parameters.Add("@COD_PER", SqlDbType.Char)
                        par2 = cmd.Parameters.Add("@COD_DOC", SqlDbType.Char)
                        par3 = cmd.Parameters.Add("@NRO_DOC", SqlDbType.Char)
                        par4 = cmd.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char)
                        par0.Direction = ParameterDirection.Input : par0.Value = dgvDatos.Item(9, i).Value
                        par1.Direction = ParameterDirection.Input : par1.Value = dgvDatos.Item(2, i).Value
                        par2.Direction = ParameterDirection.Input : par2.Value = dgvDatos.Item(0, i).Value
                        par3.Direction = ParameterDirection.Input : par3.Value = dgvDatos.Item(1, i).Value
                        par4.Direction = ParameterDirection.Input : par4.Value = dgvDatos.Item(10, i).Value
                        cmd.ExecuteNonQuery()
                    End If
                Next
                trx.Commit()
                MessageBox.Show("Registro eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                trx.Rollback()
                MessageBox.Show(String.Format("Error al eliminar el registro. {0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            Consultar(Nothing, Nothing)
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim i As Integer = dgvDetalle.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim ofr As New Dialog3
        ofr.COD_CTA = dgvDetalle.Item(24, dgvDetalle.CurrentRow.Index).Value.ToString
        ofr.COD_DOC = dgvDetalle.Item(3, dgvDetalle.CurrentRow.Index).Value.ToString
        ofr.NRO_DOC = dgvDetalle.Item(4, dgvDetalle.CurrentRow.Index).Value.ToString
        ofr.COD_PER = dgvDetalle.Item(5, dgvDetalle.CurrentRow.Index).Value.ToString
        ofr.AÑO00 = cboAño.Text
        ofr.MES00 = obj.COD_MES(cboMes.Text)
        'ofr.TIPO = "P"
        ofr.TIPO_CARGA = "TCON"
        'ofr.CARGAR_DETALLES_TCON()
        ofr.ShowDialog()
    End Sub
End Class