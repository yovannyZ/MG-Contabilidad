Imports System.Data.SqlClient
Public Class DEPURAR_TCTAS_PAGAR

#Region "Variables"
    Private Delegate Sub ProcesarDepuracion()
    Private ODepurar As New ProcesarDepuracion(AddressOf Procesar)
    Private añoProceso As String

#End Region

    Sub CargarAños()
        cboAño.Items.Clear()
        Try
            Dim Cmd As New SqlCommand("Mostrar_año", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim drd As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.SingleResult)
            Do While drd.Read
                Me.cboAño.Items.Add(drd.GetString(0))
            Loop
        Catch ex As Exception
            MessageBox.Show(String.Format("Error al cargar los años.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function VALIDAR_CIERRE() As Integer
        Dim N As Integer = -1
        Try
            con.Open()
            Dim CMD As New SqlCommand("VALIDAR_CIERRE_PERIODO", con)
            CMD.CommandType = CommandType.StoredProcedure
            Dim PAR0 As SqlParameter = CMD.Parameters.Add("FE_AÑO", SqlDbType.Char)
            PAR0.Direction = ParameterDirection.Input : PAR0.Value = añoProceso
            N = CMD.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show(String.Format("Error al validar el cierre de años.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        Return (N)
    End Function

    Private Sub Procesar()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_PCTAS_PAGAR_CANCELADAS", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            par0.Direction = ParameterDirection.Input : par0.Value = añoProceso
            Dim dtDatos As New DataTable
            Dim da As New SqlDataAdapter(Cmd)
            da.Fill(dtDatos)

            If dtDatos.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In dtDatos.Rows

                    Cmd = New SqlCommand("ELIMINAR_PCTAS_PAGAR", con)
                    Cmd.CommandType = CommandType.StoredProcedure
                    Dim par1 As SqlParameter = Cmd.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char)
                    Dim par2 As SqlParameter = Cmd.Parameters.Add("@COD_PER", SqlDbType.Char)
                    Dim par3 As SqlParameter = Cmd.Parameters.Add("@COD_DOC", SqlDbType.Char)
                    Dim par4 As SqlParameter = Cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar)
                    Dim par5 As SqlParameter = Cmd.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar)
                    Dim par6 As SqlParameter = Cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar)

                    par1.Direction = ParameterDirection.Input : par1.Value = dr.Item(0)
                    par2.Direction = ParameterDirection.Input : par2.Value = dr.Item(1)
                    par3.Direction = ParameterDirection.Input : par3.Value = dr.Item(2)
                    par4.Direction = ParameterDirection.Input : par4.Value = dr.Item(3)
                    par5.Direction = ParameterDirection.Input : par5.Value = dr.Item(4)
                    par6.Direction = ParameterDirection.Input : par6.Value = dr.Item(9)

                    con.Open()
                    Cmd.ExecuteNonQuery()
                    con.Close()
                Next
                MessageBox.Show("Depuración exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvDatos.Rows.Clear()
            Else
                MessageBox.Show("No existen registros a depurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Cmd = New SqlCommand("ELIMINAR_TCTAS_PAGAR_NO_PCTAS_PAGAR", con)
            Cmd.CommandType = CommandType.StoredProcedure

            con.Open()
            Cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error al depurar.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FinalizarProcesar(ByVal iar As IAsyncResult)
        Dim mi As New MethodInvoker(AddressOf Activar)
        Me.Invoke(mi)
    End Sub

    Private Sub Activar()
        GroupBox1.Enabled = True
    End Sub

    Private Sub DEPURAR_TCTAS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(52) = 0
    End Sub

    Private Sub DEPURAR_TCTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAños()
    End Sub

    Private Sub Depurar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepurar.Click
        If cboAño.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        añoProceso = cboAño.Text
        If VALIDAR_CIERRE() = 0 Then
            dgvDatos.Rows.Clear()
            GroupBox1.Enabled = False
            Dim oCallback As New AsyncCallback(AddressOf FinalizarProcesar)
            ODepurar.BeginInvoke(oCallback, Nothing)
        Else
            MessageBox.Show("No se puede depurar, existen periodos no cerrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class