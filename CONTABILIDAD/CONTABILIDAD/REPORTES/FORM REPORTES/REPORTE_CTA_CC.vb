Imports System.Data.SqlClient
Public Class REPORTE_CTA_CC
    Dim COD_CC, COD_CUENTA, COD_MONEDA, cuentas_string, STATUS_CC, STATUS_CTA As String
    Dim OBJ As New Class1
    Dim REP As New REP_CTA_CC
 Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_cc.SelectedIndex = -1 And ch_cc.Checked Then MessageBox.Show("Debe elegir un Centro de Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cc.Focus() : Exit Sub
        SELECT_CONCEPTO()

        If ch_cta.Checked Then
            STATUS_CTA = "1"
            COD_CUENTA = " "
        Else
            STATUS_CTA = "0"
            COD_CUENTA = cuentas_string
        End If

        If ch_cc.Checked Then
            STATUS_CC = "0"
            COD_CC = OBJ.COD_CC(cbo_cc.Text)
        Else
            STATUS_CC = "1"
            COD_CC = " "
        End If

        Dim DELMES As Integer = cbo_mes1.SelectedIndex
        Dim ALMES As Integer = cbo_mes2.SelectedIndex
        Dim P1 As Integer = 0
        Dim P2 As Integer = 0
        Dim P3 As Integer = 0
        Dim P4 As Integer = 0
        Dim P5 As Integer = 0
        Dim P6 As Integer = 0
        Dim P7 As Integer = 0
        Dim P8 As Integer = 0
        Dim P9 As Integer = 0
        Dim P10 As Integer = 0
        Dim P11 As Integer = 0
        Dim P12 As Integer = 0
        Dim CONT0 As Integer = (ALMES + 1)
        Dim I As Integer = (DELMES + 1)
        Do While (I <= CONT0)
            Dim VAR1 As Integer = I
            If (VAR1 = Integer.Parse("1")) Then
                P1 = 1
            ElseIf (VAR1 = Integer.Parse("2")) Then
                P2 = 1
            ElseIf (VAR1 = Integer.Parse("3")) Then
                P3 = 1
            ElseIf (VAR1 = Integer.Parse("4")) Then
                P4 = 1
            ElseIf (VAR1 = Integer.Parse("5")) Then
                P5 = 1
            ElseIf (VAR1 = Integer.Parse("6")) Then
                P6 = 1
            ElseIf (VAR1 = Integer.Parse("7")) Then
                P7 = 1
            ElseIf (VAR1 = Integer.Parse("8")) Then
                P8 = 1
            ElseIf (VAR1 = Integer.Parse("9")) Then
                P9 = 1
            ElseIf (VAR1 = Integer.Parse("10")) Then
                P10 = 1
            ElseIf (VAR1 = Integer.Parse("11")) Then
                P11 = 1
            ElseIf (VAR1 = Integer.Parse("12")) Then
                P12 = 1
            End If
            I += 1
        Loop

        If cbo_moneda.SelectedIndex = 0 Then
            COD_MONEDA = "S"
        ElseIf (cbo_moneda.SelectedIndex = 1) Then
            COD_MONEDA = "D"
        End If

        REP.CREAR_REPORTE(cbo_mes1.Text, cbo_mes2.Text, COD_CUENTA, COD_CC, STATUS_CC, COD_MONEDA, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, STATUS_CTA)
        REP.ShowDialog()

    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(17) = 0
        Close()
    End Sub
    Sub CARGAR_CENTRO_COSTOS()
        cbo_cc.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AREA", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_cc.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_MAESTRO_CTAS()
        dgw_cuenta.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_MAESTRO_CUENTAS", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_cuenta.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), False)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ch_cpto_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cta.CheckedChanged
        If ch_cta.Checked Then
            btn_pantalla1.Select()
        Else
            LBL_CPTO.Select()
        End If
    End Sub
    Private Sub ch_cta_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cc.CheckedChanged
        If ch_cc.Checked = False Then
            cbo_cc.SelectedIndex = -1
        End If
    End Sub
    Private Sub dgw_cc_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw_cuenta.CellClick
        If (dgw_cuenta.CurrentCellAddress.X = 2) Then
            If dgw_cuenta.Item(2, dgw_cuenta.CurrentRow.Index).Value.ToString = "True" Then
                dgw_cuenta.Item(2, dgw_cuenta.CurrentRow.Index).Value = False
            Else
                dgw_cuenta.Item(2, dgw_cuenta.CurrentRow.Index).Value = True
            End If
        End If
    End Sub
    Private Sub dgw_cc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            Panel_cpto.Visible = False
            KL.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cpto.Visible = False
            LBL_CPTO.Focus()
        End If
    End Sub
    Private Sub LBL_CPTO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LBL_CPTO.Click
        ch_cta.Checked = False
        If (dgw_cuenta.RowCount = 0) Then
            MessageBox.Show("No existen Cuentas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Panel_cpto.Visible = True
            dgw_cuenta.Visible = True
            dgw_cuenta.Focus()
        End If
    End Sub
    Private Sub REPORTE_CC_CTA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CARGAR_MAESTRO_CTAS()
        CARGAR_CENTRO_COSTOS()
        dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
    End Sub
    Sub SELECT_CONCEPTO()
        cuentas_string = ""
        Dim I As Integer = 0
        Dim CONT As Integer = dgw_cuenta.Rows.Count - 1
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If dgw_cuenta.Item(2, I).Value.ToString = "True" Then
                If (cuentas_string = "") Then
                    cuentas_string = dgw_cuenta.Item(0, I).Value.ToString
                Else
                    cuentas_string = (cuentas_string & "," & dgw_cuenta.Item(0, I).Value.ToString)
                End If
            End If
            I += 1
        Loop
    End Sub
End Class