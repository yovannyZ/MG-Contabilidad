Imports System.Data.SqlClient
Public Class REPORTE_BALANCE_ANUAL
    Private COD_FORMATO, OBS, MES0, MES1 As String
    Private OBJ As New Class1
    Private OFR As New REP_BALANCE_ANUAL
    Private TEXTO_SELECT As String
#Region "Constructor"
    Private Shared instancia As REPORTE_BALANCE_ANUAL

    Public Shared Function ObtenerInstancia() As REPORTE_BALANCE_ANUAL
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New REPORTE_BALANCE_ANUAL
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
            'If ch_hor.Checked Then
            '    OFRH.CREAR_REPORTE(COD_FORMATO, CBO_MES_2.Text, OBS, dtp1.Value.Date)
            '    OFRH.ShowDialog()
            'Else
            CARGAR_DATASET()
            OFR.CREAR_REPORTE(COD_FORMATO, CBO_MES_2.Text, OBS, dtp1.Value.Date)
            OFR.ShowDialog()
            'End If
        End If
    End Sub
    Sub CARGAR_DATASET()
        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_BALANCE_ANUAL", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = COD_FORMATO
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Dim SUM As New Decimal
            Dim TOTAL As New Decimal
            Do While Rs3.Read
                Dim CONT0 As Integer = MES0 + 0
                Dim CONT1 As Integer = MES1 + 0

                If 0 >= CONT0 And 0 <= CONT1 Then
                    If (Rs3.GetValue(0) <> "0.00") Then
                        SUM = Decimal.Parse(Rs3.GetValue(0))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add((Rs3.GetValue(0)), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 1 >= CONT0 And 1 <= CONT1 Then
                    If Rs3.GetValue(1) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(1))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", Rs3.GetValue(1), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 2 >= CONT0 And 2 <= CONT1 Then
                    If Rs3.GetValue(2) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(2))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", Rs3.GetValue(2), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 3 >= CONT0 And 3 <= CONT1 Then
                    If Rs3.GetValue(3) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(3))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", Rs3.GetValue(3), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 4 >= CONT0 And 4 <= CONT1 Then
                    If Rs3.GetValue(4) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(4))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", Rs3.GetValue(4), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 5 >= CONT0 And 5 <= CONT1 Then
                    If Rs3.GetValue(5) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(5))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(5), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 6 >= CONT0 And 6 <= CONT1 Then
                    If Rs3.GetValue(6) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(6))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 7 >= CONT0 And 7 <= CONT1 Then
                    If Rs3.GetValue(7) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(7))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(7), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 8 >= CONT0 And 8 <= CONT1 Then
                    If Rs3.GetValue(8) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(8))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 9 >= CONT0 And 9 <= CONT1 Then
                    If Rs3.GetValue(9) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(9))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 10 >= CONT0 And 10 <= CONT1 Then
                    If Rs3.GetValue(10) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(10))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(10), "0.00", "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 11 >= CONT0 And 11 <= CONT1 Then
                    If Rs3.GetValue(11) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(11))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(11)), "0.00", "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 12 >= CONT0 And 12 <= CONT1 Then
                    If Rs3.GetValue(12) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(12))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(12)), "0.00", SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

                If 13 >= CONT0 And 13 <= CONT1 Then
                    If Rs3.GetValue(13) <> "0.00" Then
                        SUM = Decimal.Parse(Rs3.GetValue(13))
                        'TOTAL = SUM + TOTAL
                        OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add("0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(13)), SUM, Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22))
                    End If
                End If

            Loop
            con.Close()
            '------------------
            Dim CONT2 As Integer = MES0 + 0
            Dim CONT3 As Integer = MES1 + 0
            '------------------
            Dim I As Integer = 0
            Dim CONT As Integer = (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Count - 1)
            I = 0
            Dim INI_A As Decimal = 0 : Dim INI_P As Decimal = 0
            Dim ENE_A As Decimal = 0 : Dim ENE_P As Decimal = 0
            Dim FEB_A As Decimal = 0 : Dim FEB_P As Decimal = 0
            Dim MAR_A As Decimal = 0 : Dim MAR_P As Decimal = 0
            Dim ABR_A As Decimal = 0 : Dim ABR_P As Decimal = 0
            Dim MAY_A As Decimal = 0 : Dim MAY_P As Decimal = 0
            Dim JUN_A As Decimal = 0 : Dim JUN_P As Decimal = 0
            Dim JUL_A As Decimal = 0 : Dim JUL_P As Decimal = 0
            Dim AGO_A As Decimal = 0 : Dim AGO_P As Decimal = 0
            Dim SEP_A As Decimal = 0 : Dim SEP_P As Decimal = 0
            Dim OCT_A As Decimal = 0 : Dim OCT_P As Decimal = 0
            Dim NOV_A As Decimal = 0 : Dim NOV_P As Decimal = 0
            Dim DIC_A As Decimal = 0 : Dim DIC_P As Decimal = 0
            Dim CIE_A As Decimal = 0 : Dim CIE_P As Decimal = 0
            Dim ACTIVO, PASIVO, IMP0, TOT0 As Decimal
            ACTIVO = 0 : PASIVO = 0 : IMP0 = 0 : TOT0 = 0
            Do While (I <= CONT)
                If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                    ACTIVO = ACTIVO + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(14)
                Else
                    PASIVO = PASIVO + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(14)
                    TOT0 = OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(21)
                End If
                '-------------------------
                If 0 >= CONT2 And 0 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        INI_A = INI_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(0)
                    Else
                        INI_P = INI_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(0)
                    End If
                End If
                If 1 >= CONT2 And 1 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        ENE_A = ENE_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(1)
                    Else
                        ENE_P = ENE_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(1)
                    End If
                End If
                If 2 >= CONT2 And 2 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        FEB_A = FEB_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(2)
                    Else
                        FEB_P = FEB_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(2)
                    End If
                End If
                If 3 >= CONT2 And 3 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        MAR_A = MAR_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(3)
                    Else
                        MAR_P = MAR_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(3)
                    End If
                End If
                If 4 >= CONT2 And 4 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        ABR_A = ABR_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(4)
                    Else
                        ABR_P = ABR_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(4)
                    End If
                End If
                If 5 >= CONT2 And 5 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        MAY_A = MAY_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(5)
                    Else
                        MAY_P = MAY_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(5)
                    End If
                End If
                If 6 >= CONT2 And 6 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        JUN_A = JUN_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(6)
                    Else
                        JUN_P = JUN_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(6)
                    End If
                End If
                If 7 >= CONT2 And 7 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        JUL_A = JUL_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(7)
                    Else
                        JUL_P = JUL_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(7)
                    End If
                End If
                If 8 >= CONT2 And 8 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        AGO_A = AGO_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(8)
                    Else
                        AGO_P = AGO_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(8)
                    End If
                End If
                If 9 >= CONT2 And 9 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        SEP_A = SEP_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(9)
                    Else
                        SEP_P = SEP_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(9)
                    End If
                End If
                If 10 >= CONT2 And 10 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        OCT_A = OCT_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(10)
                    Else
                        OCT_P = OCT_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(10)
                    End If
                End If
                If 11 >= CONT2 And 11 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        NOV_A = NOV_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(11)
                    Else
                        NOV_P = NOV_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(11)
                    End If
                End If
                If 12 >= CONT2 And 12 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        DIC_A = DIC_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(12)
                    Else
                        DIC_P = DIC_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(12)
                    End If
                End If
                If 13 >= CONT2 And 13 <= CONT3 Then
                    If (OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(16).ToString = "A") Then
                        CIE_A = CIE_A + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(13)
                    Else
                        CIE_P = CIE_P + OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Item(I).Item(13)
                    End If
                End If
                '-------------------------
                I += 1
            Loop
            IMP0 = (PASIVO * -1) - ACTIVO
            INI_A = (INI_P * -1) - INI_A
            ENE_A = (ENE_P * -1) - ENE_A
            FEB_A = (FEB_P * -1) - FEB_A
            MAR_A = (MAR_P * -1) - MAR_A
            ABR_A = (ABR_A * -1) - ABR_A
            MAY_A = (MAY_P * -1) - MAY_A
            JUN_A = (JUN_P * -1) - JUN_A
            JUL_A = (JUL_P * -1) - JUL_A
            AGO_A = (AGO_P * -1) - AGO_A
            SEP_A = (SEP_P * -1) - SEP_A
            OCT_A = (OCT_P * -1) - OCT_A
            NOV_A = (NOV_P * -1) - NOV_A
            DIC_A = (DIC_P * -1) - DIC_A
            CIE_A = (CIE_P * -1) - CIE_A
            Dim DESC As String = "GANANCIA DEL EJERCICIO"
            If IMP0 > 0 Then DESC = "PERDIDA DEL EJERCICIO"
            OFR.DT_REP_FORMATO.REPORTE_BALANCE_ANUAL.Rows.Add(INI_A, ENE_A, FEB_A, MAR_A, ABR_A, MAY_A, JUN_A, JUL_A, AGO_A, SEP_A, OCT_A, NOV_A, DIC_A, CIE_A, IMP0, COD_FORMATO, "X", "99", "", "", DESC, TOT0, "")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(65) = 0
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
            Dim CMD2 As New SqlCommand("ACT_PORCENTAJE_FORMATO", con)
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
            Dim PROG_01 As New SqlCommand("CARGAR_FORMATO_TIPO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = "BA"
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
        Dim CONT0 As Integer = CONT
        I = I
        Do While (I <= CONT0)
            If (I = CONT) Then
                TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0)"
            Else
                TEXTO_SELECT = TEXTO_SELECT & " ISNULL(IM_DEBITO" & I.ToString("00") & ",0) - ISNULL(IM_CREDITO" & I.ToString("00") & ",0) + "
            End If
            I += 1
        Loop
        TEXTO_SELECT = ("UPDATE RELACION_FORMATO SET IMPORTE = (SELECT SUM(" & TEXTO_SELECT & ") FROM MAESTRO_SALDOS M WHERE M.AÑO=@AÑO AND M.COD_CUENTA=RELACION_FORMATO.COD_CUENTA) WHERE COD_FORMATO=@COD_FORMATO")
    End Sub

    Private Sub REPORTE_BALANCE_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_BALANCE_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cargar_tipo()
        CARGAR_AÑO()
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