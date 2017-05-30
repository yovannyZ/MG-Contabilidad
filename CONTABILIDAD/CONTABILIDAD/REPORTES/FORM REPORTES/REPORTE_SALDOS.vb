Imports System.Data.SqlClient
Public Class REPORTE_SALDOS
    Dim COD_NIVEL As String
    Dim OBJ As New Class1
    Dim REP As New REP_SALDOS
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        COD_NIVEL = OBJ.COD_NIVEL(cbo_nivel.Text)
        Dim DELMES As Integer = cbo_mes1.SelectedIndex
        Dim ALMES As Integer = cbo_mes2.SelectedIndex
        Dim P0 As Integer = 0
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
        Dim P13 As Integer = 0
        Dim SUM As New Decimal
        Dim VAR0 As Integer = ALMES
        Dim I As Integer = DELMES
        Do While (I <= VAR0)
            Dim VAR1 As Integer = I
            If (VAR1 = Integer.Parse("0")) Then
                P0 = 1
            ElseIf (VAR1 = Integer.Parse("1")) Then
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
            ElseIf (VAR1 = Integer.Parse("13")) Then
                P13 = 1
            End If
            I += 1
        Loop
        REP.CREAR_REPORTE(cbo_mes1.Text, cbo_mes2.Text, COD_NIVEL, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, SUM)
        REP.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(11) = 0
        Me.Close()
    End Sub
    Sub CARGAR_NIVEL()
        cbo_nivel.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_NIVEL", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_nivel.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub REPORTE_SALDOS_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_SALDOS_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_NIVEL()
    End Sub
End Class