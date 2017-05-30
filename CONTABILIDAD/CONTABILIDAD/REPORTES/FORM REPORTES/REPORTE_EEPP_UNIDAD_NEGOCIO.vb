Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_EEPP_UNIDAD_NEGOCIO
    Private OBJ As New Class1
    Dim OFR As New REP_EPP_UNEGOCIO
#Region "Constructor"
    Private Shared instancia As REPORTE_EEPP_UNIDAD_NEGOCIO
    Public Shared Function ObtenerInstancia() As REPORTE_EEPP_UNIDAD_NEGOCIO
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New REPORTE_EEPP_UNIDAD_NEGOCIO
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region
#Region "Procedimientos"
    Private Sub CARGAR_AÑO()
        cboAño.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cboAño.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub CargarUnidadesNegocio()
        OFR.dtEstadisticaPerdidasGanancia.NEGOCIO.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("select CODIGO,DESCRIPCION from DIRECTORIO where TABLA_COD='TNEGO' AND TIPO='D' AND SUBSTRING(OBSERVACION,1,1)='O' ORDER BY CODIGO", con)
            cmd.CommandType = CommandType.Text
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                OFR.dtEstadisticaPerdidasGanancia.NEGOCIO.Rows.Add(dr(0), dr(1))
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
    Sub GenerarNroTrabajadores_Unegocio()
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Clear()
        Dim cmd As New SqlCommand("[CONSULTAR_NROTRABAJADORES]", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAño.Text
        con.Open()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        Dim filtro As String
        If rbMensual.Checked Then filtro = "M" Else filtro = "A"
        While DR.Read
            Select Case OBJ.COD_MES(cboMes.Text)
                Case "01"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "02"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, DR(4), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    End If
                Case "03"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, DR(5), 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    End If
                Case "04"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), 0, 0, 0, 0, 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, DR(6), 0, 0, 0, 0, 0, 0, 0, 0)
                    End If
                Case "05"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), 0, 0, 0, 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, DR(7), 0, 0, 0, 0, 0, 0, 0)
                    End If
                Case "06"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), 0, 0, 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, DR(8), 0, 0, 0, 0, 0, 0)
                    End If
                Case "07"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), 0, 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, 0, DR(9), 0, 0, 0, 0, 0)
                    End If
                Case "08"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), 0, 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, 0, 0, DR(10), 0, 0, 0, 0)
                    End If
                Case "09"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), 0, 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, 0, 0, 0, DR(11), 0, 0, 0)
                    End If
                Case "10"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), 0, 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, 0, 0, 0, 0, DR(12), 0, 0)
                    End If
                Case "11"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), 0)
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DR(13), 0)
                    End If
                Case "12"
                    If filtro = "A" Then
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), DR(14))
                    Else
                        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DR(14))
                    End If
            End Select
        End While
        con.Close()
        GenerarDescripciones()
    End Sub
    Sub GenerarDescripciones()
        Dim num As Integer = 0
        For Each row As DataRow In OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows
            OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).NEGOCIO = OBJ.DIR_TABLA_DESC(OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).COD_NEGOCIO, "TNEGO")
            OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).CCOSTO = OBJ.DESC_CC(OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).COD_CC)
            'OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).ZONA = OBJ.DIR_TABLA_DESC(OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).COD_ZONA, "TNEGZ")
            num += 1
        Next
    End Sub
#End Region
#Region "Funciones"
    Function GenerarTemporalUnidadNegocio() As Boolean
        Dim rslt As Boolean = False
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Clear()
        Try
            Dim CMD As New SqlCommand("[REPORTE_EPP_UNEGOCIO]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            con.Open()
            Dim DR As SqlDataReader = CMD.ExecuteReader
            Dim filtro As String
            If rbMensual.Checked Then filtro = "M" Else filtro = "A"
            While DR.Read
                'DT.Rows.Add(DR(0), DR(1), DR(2), DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), DR(14), DR(15), DR(16), DR(17), DR(18), DR(19), DR(20), DR(21), DR(22), DR(23), DR(24), DR(25), DR(26), DR(27), DR(28), DR(29), DR(30), DR(31), DR(32), DR(33), DR(34))
                Dim SUM As New Decimal
                Dim SUMTRA As New Decimal
                Dim CONT0 As String = OBJ.COD_MES(cboMes.Text)
                Select Case CONT0
                    Case "01"
                        If DR.GetValue(7) <> "0.00" Then
                            SUM = Decimal.Parse(DR.GetValue(7))
                            'SUMTRA = Decimal.Parse(DR.GetValue(19))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                        End If
                    Case "02"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(DR.GetValue(7), DR.GetValue(8)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(DR.GetValue(19), DR.GetValue(20)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(8) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(8))
                                'SUMTRA = Decimal.Parse(DR.GetValue(20))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", DR.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "03"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(9) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(9))
                                'SUMTRA = Decimal.Parse(DR.GetValue(21))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", DR.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "04"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(10) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(10))
                                'SUMTRA = Decimal.Parse(DR.GetValue(22))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", DR.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "05"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(11) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(11))
                                'SUMTRA = Decimal.Parse(DR.GetValue(23))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", DR.GetValue(11), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "06"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(12) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(12))
                                'SUMTRA = Decimal.Parse(DR.GetValue(24))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(12), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "07"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Or DR.GetValue(13) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)), DR.GetValue(13)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)), DR.GetValue(25)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), DR.GetValue(13), "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(13) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(13))
                                'SUMTRA = Decimal.Parse(DR.GetValue(25))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(13), "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "08"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Or DR.GetValue(13) <> "0.00" Or DR.GetValue(14) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)), DR.GetValue(13)), DR.GetValue(14)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)), DR.GetValue(25)), DR.GetValue(26)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), DR.GetValue(13), DR.GetValue(14), "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(14) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(14))
                                'SUMTRA = Decimal.Parse(DR.GetValue(26))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add(DR.GetValue(0), DR.GetValue(1), DR.GetValue(2), _
                                    DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", _
                                    "0.00", DR.GetValue(14), "0.00", "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), _
                                    DR.GetValue(22), SUM, "25")
                            End If
                        End If
                    Case "09"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Or DR.GetValue(13) <> "0.00" Or DR.GetValue(14) <> "0.00" Or DR.GetValue(15) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)), DR.GetValue(13)), DR.GetValue(14)), DR.GetValue(15)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)), DR.GetValue(25)), DR.GetValue(26)), DR.GetValue(27)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), DR.GetValue(13), DR.GetValue(14), DR.GetValue(15), "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(15) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(15))
                                'SUMTRA = Decimal.Parse(DR.GetValue(27))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(15), "0.00", "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "10"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Or DR.GetValue(13) <> "0.00" Or DR.GetValue(14) <> "0.00" Or DR.GetValue(15) <> "0.00" Or DR.GetValue(16) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)), DR.GetValue(13)), DR.GetValue(14)), DR.GetValue(15)), DR.GetValue(16)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)), DR.GetValue(25)), DR.GetValue(26)), DR.GetValue(27)), DR.GetValue(28)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), DR.GetValue(13), DR.GetValue(14), DR.GetValue(15), DR.GetValue(16), "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(16) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(16))
                                'SUMTRA = Decimal.Parse(DR.GetValue(28))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(16), "0.00", "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "11"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Or DR.GetValue(13) <> "0.00" Or DR.GetValue(14) <> "0.00" Or DR.GetValue(15) <> "0.00" Or DR.GetValue(16) <> "0.00" Or DR.GetValue(17) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)), DR.GetValue(13)), DR.GetValue(14)), DR.GetValue(15)), DR.GetValue(16)), DR.GetValue(17)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)), DR.GetValue(25)), DR.GetValue(26)), DR.GetValue(27)), DR.GetValue(28)), DR.GetValue(29)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), DR.GetValue(13), DR.GetValue(14), DR.GetValue(15), DR.GetValue(16), DR.GetValue(17), "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(17) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(17))
                                'SUMTRA = Decimal.Parse(DR.GetValue(29))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(17), "0.00", DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                    Case "12"
                        If filtro = "A" Then
                            If DR.GetValue(7) <> "0.00" Or DR.GetValue(8) <> "0.00" Or DR.GetValue(9) <> "0.00" Or DR.GetValue(10) <> "0.00" Or DR.GetValue(11) <> "0.00" Or DR.GetValue(12) <> "0.00" Or DR.GetValue(13) <> "0.00" Or DR.GetValue(14) <> "0.00" Or DR.GetValue(15) <> "0.00" Or DR.GetValue(16) <> "0.00" Or DR.GetValue(17) <> "0.00" Or DR.GetValue(18) <> "0.00" Then
                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(7), DR.GetValue(8)), DR.GetValue(9)), DR.GetValue(10)), DR.GetValue(11)), DR.GetValue(12)), DR.GetValue(13)), DR.GetValue(14)), DR.GetValue(15)), DR.GetValue(16)), DR.GetValue(17)), DR.GetValue(18)))
                                'SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(DR.GetValue(19), DR.GetValue(20)), DR.GetValue(21)), DR.GetValue(22)), DR.GetValue(23)), DR.GetValue(24)), DR.GetValue(25)), DR.GetValue(26)), DR.GetValue(27)), DR.GetValue(28)), DR.GetValue(29)), DR.GetValue(30)))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), DR.GetValue(7), DR.GetValue(8), DR.GetValue(9), DR.GetValue(10), DR.GetValue(11), DR.GetValue(12), DR.GetValue(13), DR.GetValue(14), DR.GetValue(15), DR.GetValue(16), DR.GetValue(17), DR.GetValue(18), DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        Else
                            If DR.GetValue(18) <> "0.00" Then
                                SUM = Decimal.Parse(DR.GetValue(18))
                                'SUMTRA = Decimal.Parse(DR.GetValue(30))
                                OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO.Rows.Add((DR.GetValue(0)), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4), DR.GetValue(5), DR.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", DR.GetValue(18), DR.GetValue(19), DR.GetValue(20), DR.GetValue(21), DR.GetValue(22), SUM)
                            End If
                        End If
                End Select
            End While
            con.Close()
            'dg.DataSource = OFR.dtEstadisticaPerdidasGanancia.REPORTE_EPP_UNEGOCIO
            GenerarNroTrabajadores_Unegocio()
            rslt = True
        Catch ex As Exception
            con.Close()
        End Try
        Return rslt
    End Function
#End Region
#Region "CargaInicial"
    Private Sub REPORTE_EEPP_UNIDAD_NEGOCIO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_EEPP_UNIDAD_NEGOCIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        rbMensual.Checked = True
        CARGAR_AÑO()
        'DT.Columns.Add("COD_DETALLE")
        'DT.Columns.Add("DESC_DETALLE_CAB")
        'DT.Columns.Add("DESC_DETALLE_TOT")
        'DT.Columns.Add("COD_CUENTA")
        'DT.Columns.Add("DESC_CUENTA")
        'DT.Columns.Add("COD_NEGOCIO")
        'DT.Columns.Add("NEGOCIO")
        'DT.Columns.Add("IMPORTE01")
        'DT.Columns.Add("IMPORTE02")
        'DT.Columns.Add("IMPORTE03")
        'DT.Columns.Add("IMPORTE04")
        'DT.Columns.Add("IMPORTE05")
        'DT.Columns.Add("IMPORTE06")
        'DT.Columns.Add("IMPORTE07")
        'DT.Columns.Add("IMPORTE08")
        'DT.Columns.Add("IMPORTE09")
        'DT.Columns.Add("IMPORTE10")
        'DT.Columns.Add("IMPORTE11")
        'DT.Columns.Add("IMPORTE12")
        'DT.Columns.Add("TRAB01")
        'DT.Columns.Add("TRAB02")
        'DT.Columns.Add("TRAB03")
        'DT.Columns.Add("TRAB04")
        'DT.Columns.Add("TRAB05")
        'DT.Columns.Add("TRAB06")
        'DT.Columns.Add("TRAB07")
        'DT.Columns.Add("TRAB08")
        'DT.Columns.Add("TRAB09")
        'DT.Columns.Add("TRAB10")
        'DT.Columns.Add("TRAB11")
        'DT.Columns.Add("TRAB12")
        'DT.Columns.Add("NIVEL1_CAB")
        'DT.Columns.Add("NIVEL1_TOT")
        'DT.Columns.Add("NIVEL2_CAB")
        'DT.Columns.Add("NIVEL2_TOT")
    End Sub
#End Region
#Region "Botones"
    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        'Validar Paramatros
        If cboMes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMes.Focus() : Exit Sub
        If cboAño.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboAño.Focus() : Exit Sub
        '--------------------------
        If GenerarTemporalUnidadNegocio() = True Then
            CargarUnidadesNegocio()
            If chkResumen.Checked Then OFR.TIPOK = "03" Else OFR.TIPOK = "04"
            OFR.UBICAR_REPORTE()
            OFR.CREAR_REPORTE(cboMes.Text)
            OFR.ShowDialog()
        Else
            MessageBox.Show("Ocurrio un error, vuelva intentarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
#End Region

End Class