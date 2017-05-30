Imports System.Data.SqlClient
Public Class AUTOMATICAS
    Private boton As String
    Private cod_cta As String
    Private desc_cta As String

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Return

        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (VERIFICAR_REG(COD_CLASE) > 0) Then
            MessageBox.Show("Existen cuentas de Automaticas", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If (Decimal.Parse((CInt(MessageBox.Show(("Eliminar: " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                Try
                    Dim CMD As New SqlCommand("ELIMINAR_AUTOMATICAS", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_AUTO", SqlDbType.Char).Value = COD_CLASE
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
            End If
            datagrid()
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception
            MsgBox(ex.Message)

            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw2.Select()

            Return

        End Try
        cod_cta = dgw2.Item(0, dgw2.CurrentRow.Index).Value.ToString
        desc_cta = dgw2.Item(1, dgw2.CurrentRow.Index).Value.ToString
        If (CONTAR_REG > 0) Then
            MessageBox.Show("El codigo de Cuenta Automatica ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dgw2.Select()
        Else
            Try
                Dim CMD As New SqlCommand("INSERTAR_AUTOMATICAS", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_AUTO", SqlDbType.Char).Value = cod_cta
                CMD.Parameters.Add("@DESC_AUTO", SqlDbType.VarChar).Value = desc_cta
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La Cuenta Automatica se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            datagrid()
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        TabControl1.SelectedTab = TabPage2
        btn_guardar.Visible = True
        dgw2.Select()
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(2) = 0
        Close()
    End Sub

    Public Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_AUTOMATICAS", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AUTO", SqlDbType.Char).Value = cod_cta
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            con.Close()
            MsgBox(ex.Message)

        End Try
        Return CONT
    End Function

    Public Sub datagrid()
        Try
            Dim prog01 As New SqlDataAdapter("MOSTRAR_AUTOMATICAS", con)
            Dim dt As New DataTable("AUTO")
            prog01.Fill(dt)
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.DataSource = dt
            dgw1.Columns.Item(0).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub datagrid2()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTA_NIVEL3", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
            Dim prog01 As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("AUTO")
            prog01.Fill(dt)
            dgw2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw2.DataSource = dt
            dgw2.Columns.Item(0).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)

            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub Maestro_auto_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Maestro_auto_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        datagrid2()
        btn_nuevo.Select()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "NUEVO") Then
                boton = "DETALLES1"
            Else
                boton = "DETALLES"
                btn_guardar.Visible = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub

    Public Function VERIFICAR_REG(ByVal cod_cta0 As Object) As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_ELIM_AUTOMATICAS", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AUTO", SqlDbType.Char).Value = (cod_cta0)
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        Return CONT
    End Function

End Class