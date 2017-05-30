Imports System.Data.SqlClient
Public Class REPORTE_CUADRE_TCON_TCTAS_COBRAR
    Dim OBJ As New Class1
    Private CADENA_CUENTA As String
    Private Ofrm As New REP_CUADRE_TCON_TCTAS

    Sub SUB_CADENA_CUENTA()
        CADENA_CUENTA = ""
        Dim Cant As Integer = dgw1.Rows.Count
        Dim i As Integer = 0
        While i < Cant
            If dgw1.Item(2, i).Value Then
                If String.IsNullOrEmpty(CADENA_CUENTA) Then
                    CADENA_CUENTA = dgw1.Item(0, i).Value
                Else
                    CADENA_CUENTA = CADENA_CUENTA & "," & dgw1.Item(0, i).Value
                End If
            End If
            i += 1
        End While
    End Sub

    Sub DGW_CUENTAS00()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = "C"
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), False)
            Loop
            con.Close()
            dgw1.Columns.Item(0).ReadOnly = True
            dgw1.Columns.Item(1).ReadOnly = True
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub

        SUB_CADENA_CUENTA()

        Dim marca As Boolean = String.IsNullOrEmpty(CADENA_CUENTA)

        If marca Then
            MessageBox.Show("Seleccione al menos un registro para visualizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Ofrm.op = 0
        Ofrm.Text = "Cuadre Contable - Ctas x Cobrar"
        Ofrm.CREAR_REPORTE(cbo_año.Text, OBJ.COD_MES(cbo_mes.Text), cbo_mes.Text, CADENA_CUENTA)
        Ofrm.ShowDialog()
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch1.CheckedChanged
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        If ch1.Checked = True Then
            For I = 0 To CONT
                dgw1.Item(2, I).Value = True
            Next
        Else
            For I = 0 To CONT
                dgw1.Item(2, I).Value = False
            Next
        End If
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(51) = (0)
        Close()
    End Sub

    Private Sub REPORTE_CUADRE_TP1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        CARGAR_AÑOS()
        DGW_CUENTAS00()
        cbo_mes.Text = OBJ.DESC_MES(MES)
        cbo_año.Text = AÑO
    End Sub
End Class