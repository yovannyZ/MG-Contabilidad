Imports System.Data.SqlClient
Public Class CONTROL_LETRAS_CXC
    Dim COD_SUC1, COD_BCO, STATUS_SUC6, STATUS_SUC5, STATUS_SUC4, STATUS_SUC3, STATUS_SUC2, STATUS_SUC1, COD_SUC2, COD_SUC3, COD_SUC4, COD_SUC5, COD_SUC6, COD_UBI4 As String
    Private OBJ As New Class1
    Sub BTN_ACEPTAR_LETRAS()
        Dim i, cont As Integer
        cont = DGW_DET2.Rows.Count - 1
        For i = 0 To cont
            If DGW_DET2.Item(6, i).Value = True Then
                Try
                    Dim command As New SqlCommand("ACEPTAR_UBICACION_NRO_BANCO_CXC2", con)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = DGW_DET2.Item(13, i).Value
                    command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = DGW_DET2.Item(0, i).Value
                    command.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_DET2.Item(2, i).Value
                    command.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DGW_DET2.Item(17, i).Value
                    command.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = DGW_DET2.Item(15, i).Value
                    command.Parameters.Add("@FECHA_ACEP", SqlDbType.DateTime).Value = dtp_acep.Value
                    command.Parameters.Add("@NRO_BANCO", SqlDbType.VarChar).Value = DGW_DET2.Item(8, i).Value
                    con.Open()
                    command.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub
    Private Sub BTN_CONSULTA4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA.Click
        If (ch1.Checked And (CBO_SUCURSAL.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL.Focus()
        ElseIf cbo_año.SelectedIndex = -1 Then
            MessageBox.Show("Elija el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_año.Focus()
        ElseIf cbo_mes.SelectedIndex = -1 Then
            MessageBox.Show("Elija el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_mes.Focus()
        Else
            If ch1.Checked = False Then
                STATUS_SUC4 = "1"
                COD_SUC4 = ""
            Else
                STATUS_SUC4 = "0"
                COD_SUC4 = CBO_SUCURSAL.SelectedValue.ToString
            End If
            CARGAR_MOD_UBICACION_NRO_BANCO()
        End If
    End Sub
    Private Sub btn_consultar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_CONSULTA2.Click
        If (ch2.Checked And (CBO_SUCURSAL2.SelectedIndex = -1)) Then
            MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_SUCURSAL.Focus()
        ElseIf cbo_año2.SelectedIndex = -1 Then
            MessageBox.Show("Elija el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_año2.Focus()
        ElseIf cbo_mes2.SelectedIndex = -1 Then
            MessageBox.Show("Elija el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_mes2.Focus()
        ElseIf cbo_banco2.SelectedIndex = -1 Then
            MessageBox.Show("Elija el Banco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            cbo_banco2.Focus()
        Else
            If ch2.Checked = False Then
                STATUS_SUC3 = "1"
                COD_SUC3 = ""
            Else
                STATUS_SUC3 = "0"
                COD_SUC3 = CBO_SUCURSAL2.SelectedValue.ToString
            End If
            CARGAR_MOD_ACEPTACION()
        End If
    End Sub
    Private Sub BTN_GRABAR3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_GRABAR3.Click
        Dim wa As Date
        wa = "01 / " & OBJ.COD_MES(cbo_mes2.Text) & "/ " & cbo_año2.Text
        If dtp_acep.Value.Date < wa Then
            MessageBox.Show("La fecha debe ser mayor y/o igual al mes y año elegido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        BTN_ACEPTAR_LETRAS()
        CARGAR_MOD_ACEPTACION()
        MessageBox.Show("Las Letras elegidas fueron Actualizadas", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub BTN_GRABAR4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_GRABAR4.Click
        If cbo_banco.SelectedIndex <> -1 Then
            If VERIFICAR_MON_BCO() = True Then
                MessageBox.Show("La moneda del Banco debe coincidir con la elegida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If (CBO_UBICACION.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Ubicación de las Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_UBICACION.Focus()
        Else
            BTN_UBICACION_NRO_BANCO()
            CARGAR_MOD_UBICACION_NRO_BANCO()
            MessageBox.Show("Las Letras elegidas fueron Actualizadas", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Function VERIFICAR_MON_BCO() As Boolean
        'If cbo_banco.SelectedIndex <> -1 Then
        Dim BCO0 As String = OBJ.HALLAR_MON_BCO(cbo_banco.SelectedValue.ToString)
        'End If
        Dim i, cont As Integer
        cont = DGW_DET.Rows.Count - 1
        For i = 0 To cont
            If DGW_DET.Item(6, i).Value = True Then
                If BCO0 <> DGW_DET.Item(11, i).Value Then
                    'MessageBox.Show("La moneda del Banco debe coincidir con la elegida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return True
                    Exit Function
                End If
            End If
        Next
    End Function
    Sub BTN_UBICACION_NRO_BANCO()
        'COD_UBI4 = OBJ.COD_UBICACION(CBO_UBICACION.Text)
        'COD_BCO = cbo_banco.SelectedValue.ToString
        COD_UBI4 = CBO_UBICACION.Text.ToString.Substring(0, 3)
        If cbo_banco.SelectedIndex = -1 Then
            COD_BCO = ""
        Else
            COD_BCO = cbo_banco.SelectedValue.ToString
        End If
        Dim i, cont As Integer
        cont = DGW_DET.Rows.Count - 1
        For i = 0 To cont
            If DGW_DET.Item(6, i).Value = True Then
                Try
                    Dim command As New SqlCommand("ACEPTAR_UBICACION_NRO_BANCO_CXC", con)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = DGW_DET.Item(13, i).Value
                    command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = DGW_DET.Item(0, i).Value
                    command.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGW_DET.Item(2, i).Value
                    command.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DGW_DET.Item(17, i).Value
                    command.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = DGW_DET.Item(15, i).Value
                    command.Parameters.Add("@COD_UBI", SqlDbType.VarChar).Value = COD_UBI4
                    command.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BCO
                    command.Parameters.Add("@NRO_BANCO", SqlDbType.VarChar).Value = DGW_DET.Item(8, i).Value
                    con.Open()
                    command.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub
    Sub CARGAR_MOD_ACEPTACION()
        DGW_DET2.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_PARA_UBI_BAN_CXC2", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC3
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC3
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año2.Text
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes2.Text)
            command.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = cbo_banco2.SelectedValue.ToString
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW_DET2.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), reader.GetValue(13), reader.GetValue(14), reader.GetValue(15), reader.GetValue(16), reader.GetValue(17))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_MOD_UBICACION_NRO_BANCO()
        DGW_DET.Rows.Clear()
        Try
            Dim command As New SqlCommand("MOSTRAR_LETRAS_PARA_UBI_BAN_CXC", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@STATUS_SUC", SqlDbType.Char).Value = STATUS_SUC4
            command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = COD_SUC4
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                DGW_DET.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11), reader.GetValue(12), reader.GetValue(13), reader.GetValue(14), reader.GetValue(15), reader.GetValue(16), reader.GetValue(17))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SUCURSAL()
        Dim genericos As New Genericos
        Dim table As New DataTable
        table = genericos.CBO_SUCURSAL
        CBO_SUCURSAL2.DataSource = table
        CBO_SUCURSAL2.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL2.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL2.SelectedIndex = -1
        CBO_SUCURSAL.DataSource = table
        CBO_SUCURSAL.DisplayMember = table.Columns(0).ToString
        CBO_SUCURSAL.ValueMember = table.Columns(1).ToString
        CBO_SUCURSAL.SelectedIndex = -1
    End Sub
    Sub CARGAR_BCO()
        Dim genericos As New Genericos
        Dim table As New DataTable
        table = genericos.CBO_BCO
        cbo_banco.DataSource = table
        cbo_banco.DisplayMember = table.Columns(0).ToString
        cbo_banco.ValueMember = table.Columns(1).ToString
        cbo_banco.SelectedIndex = -1

        cbo_banco2.DataSource = table
        cbo_banco2.DisplayMember = table.Columns(0).ToString
        cbo_banco2.ValueMember = table.Columns(1).ToString
        cbo_banco2.SelectedIndex = -1
    End Sub
    Sub CARGAR_UBICACION()
        CBO_UBICACION.Items.Clear()
        Try
            Dim command As New SqlCommand("CBO_UBICACION", con)
            con.Open()
            command.ExecuteNonQuery()
            Dim reader As SqlDataReader = command.ExecuteReader
            Do While reader.Read
                CBO_UBICACION.Items.Add(reader.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ch_si3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        If ch2.Checked Then
            CBO_SUCURSAL2.Enabled = True
        Else
            CBO_SUCURSAL2.SelectedIndex = -1
            CBO_SUCURSAL2.Enabled = False
        End If
    End Sub
    Private Sub ch_si4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        If ch1.Checked Then
            CBO_SUCURSAL.Enabled = True
        Else
            CBO_SUCURSAL.SelectedIndex = -1
            CBO_SUCURSAL.Enabled = False
        End If
    End Sub
    Private Sub CONTROL_LETRAS_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(36) = (0)
    End Sub
    Private Sub CONTROL_LETRAS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
        If (e.KeyCode = Keys.F1) Then
            Try
                'Help.ShowHelp((manual & "control_letra.htm"), HelpNavigator.Topic)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error al Cargar ayuda ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End If
    End Sub
    Private Sub CONTROL_LETRAS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_SUCURSAL()
        CARGAR_AÑOS()
        CARGAR_UBICACION()
        CARGAR_BCO()
        DGW_DET2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        DGW_DET.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
    End Sub
    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        cbo_año2.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
                Me.cbo_año2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, btn_salir.Click
        main(36) = 0
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        limpiar_bco(DGW_DET)
    End Sub
    Sub limpiar_bco(ByVal DGW0 As DataGridView)
        Dim i, cont As Integer
        cont = DGW0.Rows.Count - 1
        For i = 0 To cont
            If DGW0.Item(6, i).Value = True Then
                DGW0.Item(7, i).Value = ""
                DGW0.Item(8, i).Value = ""
            End If
        Next
        cbo_banco.SelectedIndex = -1
    End Sub
End Class