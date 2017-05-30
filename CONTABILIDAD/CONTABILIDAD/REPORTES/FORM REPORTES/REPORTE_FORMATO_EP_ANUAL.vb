Imports System.Data.SqlClient
Public Class REPORTE_FORMATO_EP_ANUAL
    Private COD_FORMATO, OBS, MES0, MES1 As String
    Private OBJ As New Class1
    Private OFR As New REP_FORMATO_E_P
    Private OFR1 As New REP_FORMATO_EP_ANUAL
    Private TEXTO_SELECT As String
#Region "Constructor"
    Private Shared instancia As REPORTE_FORMATO_EP_ANUAL

    Public Shared Function ObtenerInstancia() As REPORTE_FORMATO_EP_ANUAL
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New REPORTE_FORMATO_EP_ANUAL
        End If
        instancia.BringToFront()
        Return instancia
    End Function

    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#End Region

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (CBO_MES_1.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_MES_1.Focus()
        ElseIf (CBO_MES_2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CBO_MES_2.Focus()
        ElseIf (cbo_FORMATO.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Formato", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_FORMATO.Focus()
        Else
            COD_FORMATO = OBJ.COD_FORMATO(cbo_FORMATO.Text)
            OBS = OBJ.HALLAR_OBS_FORMATO(COD_FORMATO)
            MES0 = OBJ.COD_MES(CBO_MES_1.Text)
            MES1 = OBJ.COD_MES(CBO_MES_2.Text)
            CREAR_SELECT()
            CARGAR_SALDOS()
            CARGAR_DATASET()
            OFR1.CREAR_REPORTE(COD_FORMATO, CBO_MES_2.Text, OBS, dtp1.Value.Date)
            OFR1.ShowDialog()
        End If
    End Sub
    Sub CARGAR_DATASET()
        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_BALANCE_ANUAL", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Dim SUM As New Decimal
            Do While Rs3.Read
                Dim CONT0 As Integer = MES0 + 0
                Dim CONT1 As Integer = MES1 + 0

                If 0 >= CONT0 And 0 <= CONT1 Then
                    If (Rs3.GetValue(0) <> "0.00") Then
                        SUM = Decimal.Parse(Rs3.GetValue(0))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add((Rs3.GetValue(0)), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 1 >= CONT0 And 1 <= CONT1 Then
                    If Rs3.GetValue(1) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(1))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", Rs3.GetValue(1), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 2 >= CONT0 And 2 <= CONT1 Then
                    If Rs3.GetValue(2) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(2))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", Rs3.GetValue(2), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 3 >= CONT0 And 3 <= CONT1 Then
                    If Rs3.GetValue(3) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(3))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", Rs3.GetValue(3), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 4 >= CONT0 And 4 <= CONT1 Then
                    If Rs3.GetValue(4) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(4))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", Rs3.GetValue(4), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 5 >= CONT0 And 5 <= CONT1 Then
                    If Rs3.GetValue(5) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(5))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(5), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 6 >= CONT0 And 6 <= CONT1 Then
                    If Rs3.GetValue(6) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(6))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 7 >= CONT0 And 7 <= CONT1 Then
                    If Rs3.GetValue(7) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(7))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(7), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 8 >= CONT0 And 8 <= CONT1 Then
                    If Rs3.GetValue(8) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(8))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 9 >= CONT0 And 9 <= CONT1 Then
                    If Rs3.GetValue(9) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(9))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 10 >= CONT0 And 10 <= CONT1 Then
                    If Rs3.GetValue(10) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(10))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(10), "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 11 >= CONT0 And 11 <= CONT1 Then
                    If Rs3.GetValue(11) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(11))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00"(Rs3.GetValue(11)), "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 12 >= CONT0 And 12 <= CONT1 Then
                    If Rs3.GetValue(12) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(12))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(12)), "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 13 >= CONT0 And 13 <= CONT1 Then
                    If Rs3.GetValue(13) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(13))
                        OFR1.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(13)), SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(66) = 0
        Close()
    End Sub
    Public Function CARGAR_SALDOS() As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim CMD As New SqlCommand(TEXTO_SELECT, con)
            CMD.UpdatedRowSource = UpdateRowSource.Both
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = False
        End Try
        Try
            Dim CMD2 As New SqlCommand("ACT_PORCENTAJE_FORMATO_EP", con)
            CMD2.CommandType = CommandType.StoredProcedure
            CMD2.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            CMD2.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            ESTADO = False
        End Try
        Return False
    End Function

    Public Sub cargar_tipo()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_FORMATO_TIPO_EP", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_FORMATO.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub CREAR_SELECT()
        TEXTO_SELECT = ""
        Dim I As Integer = Integer.Parse(OBJ.COD_MES(CBO_MES_1.Text))
        Dim CONT As Integer = Integer.Parse(OBJ.COD_MES(CBO_MES_2.Text))
        I = I
        Do While (I <= CONT)
            If (I = CONT) Then
                TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0)"
            Else
                TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0) + "
            End If
            I += 1
        Loop
        TEXTO_SELECT = ("UPDATE RELACION_FORMATO SET IMPORTE = (SELECT SUM(" & TEXTO_SELECT & ") FROM MAESTRO_SALDOS M WHERE M.AÑO=@AÑO AND M.COD_CUENTA=RELACION_FORMATO.COD_CUENTA) WHERE COD_FORMATO=@COD_FORMATO")
    End Sub
    Private Sub REPORTE_BALANCE_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cargar_tipo()
        CARGAR_AÑO()
    End Sub
    Private Sub REPORTE_FORMATO_EP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class