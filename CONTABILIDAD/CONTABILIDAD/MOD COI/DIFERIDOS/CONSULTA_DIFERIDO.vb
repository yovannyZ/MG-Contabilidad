Imports System.Data.SqlClient
Public Class CONSULTA_DIFERIDO
    Dim obj As New Class1
#Region "Métodos"

    Sub CARGAR_AÑO()
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

    Sub CARGAR_LISTA_DIFERIDOS_MES()
        Dim dt As New DataTable("Diferidos")
        Try
            Dim cmd As New SqlCommand("MOSTRAR_LISTA_DIFERIDOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cboAño.Text
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            dgvListaDiferidos.DataSource = dt
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Sub ELIMINAR_DIFERIDOS_MES()
    '    Try
    '        Dim cmd As New SqlCommand("ELIMINAR_T_DIFERIDO", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cboAño.Text
    '        cmd.Parameters.Add("@MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text)
    '        con.Open()
    '        Dim i As Integer = cmd.ExecuteNonQuery()
    '        con.Close()
    '        If i > 0 Then
    '            MessageBox.Show("Se eliminaron todos los diferidos del mes " & cboMes.Text & _
    '                              "del Año " & cboAño.Text, "Elimación Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Else
    '            MessageBox.Show("No hay diferidos en el mes por eliminar", "Elimación Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Catch ex As SqlException
    '        Dim er As SqlError
    '        For Each er In ex.Errors
    '            MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub

    'Sub REGRESAR_NRO_SECUENCIA()
    '    Dim dt As New DataTable("ListaADestransferir")
    '    Try
    '        'CARGAMOS LAS CUENTAS A REGRESAR
    '        Dim PRO As New SqlCommand("CUENTAS_A_REGRESAR", con)
    '        PRO.CommandType = CommandType.StoredProcedure
    '        PRO.Parameters.Add("@AÑO", SqlDbType.Char).Value = cboAño.Text
    '        PRO.Parameters.Add("@MES", SqlDbType.Char).Value = obj.COD_MES(cboMes.Text)
    '        Dim da As New SqlDataAdapter(PRO)
    '        da.Fill(dt)

    '        For Each row As DataRow In dt.Rows

    '            'REGRESAMOS EL NUMERO DE TRANSFERENCIA

    '            Dim cmd As New SqlCommand("REGRESA_NRO_TRANSFERIDO", con)
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = row(0)
    '            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = row(1)
    '            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = row(2)
    '            con.Open()
    '            cmd.ExecuteNonQuery()
    '            con.Close()

    '        Next



    '    Catch ex As Exception


    '    End Try
    'End Sub

    'Function CONSULTAR_EXISTENCIA() As Boolean
    '    Dim dato As String
    '    Dim key As Boolean
    '    Try
    '        Dim cmd As New SqlCommand("VERIFICAR_DIFERIDO", con)
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Month(FECHA_GRAL.AddMonths(1))
    '        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = Year(FECHA_GRAL.AddMonths(1))
    '        con.Open()
    '        dato = CInt(cmd.ExecuteScalar)
    '        con.Close()
    '        If dato = Nothing Then dato = 0
    '        If dato = 0 Then key = True
    '    Catch ex As SqlException
    '        Dim er As SqlError
    '        For Each er In ex.Errors
    '            MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    '    Return key
    'End Function

#End Region

#Region "Botones"

    Private Sub btnConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        CARGAR_LISTA_DIFERIDOS_MES()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub


#End Region

#Region "Eventos"

    Private Sub CONSULTA_DIFERIDO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_AÑO()
        cboAño.Text = AÑO
        cboMes.Text = obj.DESC_MES(MES)
    End Sub

#End Region


End Class