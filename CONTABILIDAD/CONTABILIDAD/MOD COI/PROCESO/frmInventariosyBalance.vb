Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Public Class frmInventariosyBalance

#Region "Variables"
    Private OBJ As New Class1
    Private OFR As New REP_COMP_GRAL
    Private TXT_MOV_DEBE As String
    Private TXT_MOV_HABER As String
    Private TXT_SALDO_DEBE As String
    Private TXT_SALDO_HABER As String
    Private TXT_SELECT As String

    Private MES0, DESC_MES0, DESC_MES1, NIVEL As String
    Private bwExportar As New BackgroundWorker
    Private Sql As String = String.Empty
    Private Exito As Boolean
    'Lista para el ple
    Private LoPleComprobación As New List(Of Comprobacion)
#End Region

#Region "Estructura"
    Public Structure Comprobacion
        Public Periodo As String
        Public CodigoCuentaContable As String
        Public SaldoInicialesDebe As Decimal
        Public SaldoInicialesHaber As Decimal
        Public MovimientosDebe As Decimal
        Public MovimientosHaber As Decimal
        Public SumaMayorDebe As Decimal
        Public SumaMayorHaber As Decimal
        Public Deudor As Decimal
        Public Acreedor As Decimal
        Public CancelacionesDebe As Decimal
        Public CancelacionesHaber As Decimal
        Public BalanceActivo As Decimal
        Public BalancePasivo As Decimal
        Public NaturalezaPerdidas As Decimal
        Public NaturalezaGanancias As Decimal
        Public Adicciones As Decimal
        Public Deducciones As Decimal
        Public EstadoOperacion As String
    End Structure
#End Region

#Region "Constructor"
    Private Shared instancia As New frmInventariosyBalance
    Public Shared Function ObtenerInstancia() As frmInventariosyBalance
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmInventariosyBalance
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

#Region "Métodos"
    Private Sub CargarPleComprobacion()
        Dim Activo, Pasivo, Perdidas, Ganancias As Decimal
        Activo = 0 : Pasivo = 0 : Perdidas = 0 : Ganancias = 0
        Try
            LoPleComprobación.Clear()
            Using cmd As New SqlCommand(TXT_SELECT, con)
                cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cboAño.Text
                cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = OBJ.HALLAR_NRO_DIGITOS(OBJ.COD_NIVEL("DETALLE"))
                Dim OComprobacion As Comprobacion
                con.Open()
                Dim Rs3 As SqlDataReader = cmd.ExecuteReader
                'Recorremos el dataadapter
                Do While Rs3.Read
                    OComprobacion = New Comprobacion
                    With OComprobacion
                        .Periodo = cboAño.Text + "1231"
                        .CodigoCuentaContable = Rs3.GetValue(0)

                        .SaldoInicialesDebe = IIf(IsNumeric(Rs3.GetValue(2)), Rs3.GetValue(2), 0) 'IIf(Rs3.GetValue(2) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(2)), 0, Rs3.GetValue(2))
                        .SaldoInicialesHaber = IIf(IsNumeric(Rs3.GetValue(3)), Rs3.GetValue(3), 0) 'IIf(Rs3.GetValue(3) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(3)), 0, Rs3.GetValue(3))

                        .MovimientosDebe = IIf(IsNumeric(Rs3.GetValue(4)), Rs3.GetValue(4), 0) 'IIf(Rs3.GetValue(4) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(4)), 0, Rs3.GetValue(4))
                        .MovimientosHaber = IIf(IsNumeric(Rs3.GetValue(5)), Rs3.GetValue(5), 0) 'IIf(Rs3.GetValue(5) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(5)), 0, Rs3.GetValue(5))

                        .SumaMayorDebe = .SaldoInicialesDebe + .MovimientosDebe 'IIf(((.SaldoInicialesDebe + .MovimientosDebe) - (.SaldoInicialesHaber + .MovimientosHaber)) > 0, (.SaldoInicialesDebe + .MovimientosDebe) - (.SaldoInicialesHaber + .MovimientosHaber), 0.0) '0.0
                        .SumaMayorHaber = .SaldoInicialesHaber + .MovimientosHaber 'IIf(((.SaldoInicialesHaber + .MovimientosHaber) - (.SaldoInicialesDebe + .MovimientosHaber)) > 0, (.SaldoInicialesHaber + .MovimientosHaber) - (.SaldoInicialesDebe + .MovimientosHaber), 0.0) '0.0

                        .Deudor = IIf(IsNumeric(Rs3.GetValue(6)), Rs3.GetValue(6), 0) 'IIf(Rs3.GetValue(6) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(6)), 0, Rs3.GetValue(6))
                        .Acreedor = IIf(IsNumeric(Rs3.GetValue(7)), Rs3.GetValue(7), 0) 'IIf(Rs3.GetValue(7) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(7)), 0, Rs3.GetValue(7))

                        .CancelacionesDebe = 0.0
                        .CancelacionesHaber = 0.0

                        .BalanceActivo = IIf(IsNumeric(Rs3.GetValue(8)), Rs3.GetValue(8), 0) 'IIf(Rs3.GetValue(8) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(8)), 0, Rs3.GetValue(8))
                        .BalancePasivo = IIf(IsNumeric(Rs3.GetValue(9)), Rs3.GetValue(9), 0) 'IIf(Rs3.GetValue(9) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(9)), 0, Rs3.GetValue(9))
                        'Para tratar los activos
                        Activo = .BalanceActivo
                        Pasivo = .BalancePasivo
                        .BalanceActivo = IIf(Activo - Pasivo > 0, Activo - Pasivo, 0.0)
                        .BalancePasivo = IIf(Pasivo - Activo > 0, Pasivo - Activo, 0.0)
                        '---
                        If IsNothing(Rs3.GetValue(12)) Then
                            Perdidas = 0
                        Else
                            Perdidas = IIf(IsNumeric(Rs3.GetValue(12)), Rs3.GetValue(12), 0) '10 '12 'IIf(Rs3.GetValue(12) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(12)), 0, Rs3.GetValue(12))
                        End If
                        If IsNothing(Rs3.GetValue(13)) Then
                            Ganancias = 0
                        Else
                            Ganancias = IIf(IsNumeric(Rs3.GetValue(13)), Rs3.GetValue(13), 0) '11 '13 'IIf(Rs3.GetValue(13) = "-" Or String.IsNullOrEmpty(Rs3.GetValue(13)), 0, Rs3.GetValue(13))
                        End If
                        'Para el perdidas y ganancias
                        .NaturalezaPerdidas = IIf(Perdidas - Ganancias > 0, Perdidas - Ganancias, 0)
                        .NaturalezaGanancias = IIf(Ganancias - Perdidas > 0, Ganancias - Perdidas, 0)

                        .Adicciones = 0.0
                        .Deducciones = 0.0

                        .EstadoOperacion = "1"
                        If .SaldoInicialesDebe = 0 And .SaldoInicialesHaber = 0 And _
                           .MovimientosDebe = 0 And .MovimientosHaber = 0 And _
                           .Deudor = 0 And .Acreedor = 0 And _
                           .BalanceActivo = 0 And .BalancePasivo = 0 And _
                           .NaturalezaPerdidas = 0 And .NaturalezaGanancias = 0 Then
                            Continue Do
                        End If
                    End With
                    LoPleComprobación.Add(OComprobacion)
                    Activo = 0 : Pasivo = 0 : Perdidas = 0 : Ganancias = 0
                Loop
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    'Private Sub ExportarProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
    '    tspbExportar.Value = e.ProgressPercentage
    '    tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    'End Sub

    'Private Sub ExportarWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
    '    Dim loPleComprobacion As New List(Of Comprobacion)
    '    Exito = True
    '    Using cmd As New SqlCommand(TXT_SELECT, con)
    '        cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
    '        cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = NIVEL
    '        cmd.ExecuteNonQuery()
    '        con.Open()
    '        Dim reader As SqlDataReader = cmd.ExecuteReader
    '        Dim oPleComprobacion As Comprobacion
    '        Do While reader.Read
    '            oPleComprobacion = New Comprobacion
    '            With oplecomprobacion
    '                .Periodo = drd(0)
    '            End With
    '            loPleComprobacion.Add(OPleComprobacion)
    '        Loop
    '        con.Close()

    '    End Using

    'End Sub

    'Public Sub New()

    'End Sub

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
                'cbo_año_sunat.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub CREAR_SELECT_EXCEL()
        TXT_SALDO_DEBE = ""
        TXT_SALDO_HABER = ""
        ' If (cboMes.SelectedIndex = 0) Then
        TXT_SALDO_DEBE = "IM_DEBITO00"
        TXT_SALDO_HABER = "IM_CREDITO00"
        'Else
        '    TXT_SALDO_DEBE = "0.00"
        '    TXT_SALDO_HABER = "0.00"
        'End If
        TXT_MOV_DEBE = ""
        TXT_MOV_HABER = ""
        Dim I2 As Integer = Integer.Parse(OBJ.COD_MES("INICIO"))
        If (I2 = 0) Then
            I2 = 1
        End If
        Dim CONT2 As Integer = Integer.Parse(OBJ.COD_MES("DICIEMBRE"))
        Dim VAR0 As Integer = CONT2
        I2 = I2
        Do While (I2 <= VAR0)
            If (I2 = CONT2) Then
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00"))
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00"))
            Else
                TXT_MOV_DEBE = (TXT_MOV_DEBE & " IM_DEBITO" & I2.ToString("00") & " + ")
                TXT_MOV_HABER = (TXT_MOV_HABER & " IM_CREDITO" & I2.ToString("00") & " + ")
            End If
            I2 += 1
        Loop
        If (TXT_MOV_DEBE.Trim = "") Then
            TXT_MOV_DEBE = "0.00"
        End If
        If (TXT_MOV_HABER.Trim = "") Then
            TXT_MOV_HABER = "0.00"
        End If
        TXT_SELECT = ("SELECT  A.COD_CUENTA, A.DESC_CUENTA,(" & TXT_SALDO_DEBE & "),(" & TXT_SALDO_HABER & "),(" & TXT_MOV_DEBE & "),(" & TXT_MOV_HABER & ") ,CASE WHEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )>(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") THEN (" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " )-(" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ") ELSE 0 END, CASE WHEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")>(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") THEN (" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & ")-(" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & ") ELSE 0 END ,(SELECT ISNULL((" & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & " ), 0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')) ,  (SELECT ISNULL((" & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & " ),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN  MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND M1.TIPO_CUENTA IN ('A','B','C','D','O')),(SELECT ISNULL(( " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS PERDIDAS, (SELECT ISNULL(( " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO  WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('F','G','N')) AS GANANCIAS,(SELECT ISNULL((  " & TXT_MOV_DEBE & " + " & TXT_SALDO_DEBE & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('E','G','N')) AS PERDIDAS_NAT,(SELECT ISNULL((  " & TXT_MOV_HABER & " + " & TXT_SALDO_HABER & "),0.00) FROM MAESTRO_SALDOS S1 INNER JOIN MAESTRO_CUENTAS M1 ON  M1.COD_CUENTA=S1.COD_CUENTA AND M1.AÑO=S1.AÑO WHERE M1.COD_CUENTA=A.COD_CUENTA AND M1.AÑO=A.AÑO AND  M1.TIPO_CUENTA IN ('E','G','N')) AS GANANCIAS_NAT,CASE WHEN LEN(B.COD_CUENTA) >=3 THEN SUBSTRING(B.COD_CUENTA,0,3) ELSE '' END AS NIVEL2,CASE WHEN LEN(B.COD_CUENTA)=8 THEN SUBSTRING(B.COD_CUENTA,0,4) ELSE '' END AS NIVEL3 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,3)) AS DESC_NIVEL2 ,(SELECT DESC_CUENTA FROM MAESTRO_CUENTAS WHERE AÑO=B.AÑO AND COD_CUENTA=SUBSTRING(B.COD_CUENTA,0,4)) AS DESC_NIVEL3  FROM MAESTRO_SALDOS AS B INNER JOIN MAESTRO_CUENTAS A  ON A.COD_CUENTA =B.COD_CUENTA  AND A.AÑO=B.AÑO WHERE A.AÑO=@AÑO  AND LEN(A.COD_CUENTA)=@NIVEL")
    End Sub

#End Region

#Region "Funciones"

#End Region

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If cboAño.SelectedIndex = -1 Then
            MessageBox.Show("Debe cargara el Año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        dgvBalance.Rows.Clear()
        CREAR_SELECT_EXCEL()
        CargarPleComprobacion()
        If LoPleComprobación.Count = 0 Then
            MessageBox.Show("No hay registros que mostrar!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim i As Integer
        For i = 0 To LoPleComprobación.Count - 1
            With LoPleComprobación.Item(i)
                dgvBalance.Rows.Add(.Periodo, _
                                    .CodigoCuentaContable, _
                                    .SaldoInicialesDebe, _
                                    .SaldoInicialesHaber, _
                                    .MovimientosDebe, _
                                    .MovimientosHaber, _
                                    .SumaMayorDebe, _
                                    .SumaMayorHaber, _
                                    .Deudor, _
                                    .Acreedor, _
                                    .CancelacionesDebe, _
                                    .CancelacionesHaber, _
                                    .BalanceActivo, _
                                    .BalancePasivo, _
                                    .NaturalezaPerdidas, _
                                    .NaturalezaGanancias, _
                                    .Adicciones, _
                                    .Deducciones, _
                                    .EstadoOperacion)
            End With

        Next
    End Sub

    Private Sub frmInventariosyBalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_AÑO()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}1231031700011111.txt", RUC_EMPRESA, cboAño.Text) '= String.Format("LE{0}{1}{2}00140100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    ' Dim aux As Integer
                    ''sw.WriteLine("Tipo Venta|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To LoPleComprobación.Count - 1
                        With LoPleComprobación(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|", _
                                    .Periodo, _
                                    .CodigoCuentaContable, _
                                    .SaldoInicialesDebe.ToString("0.00"), _
                                    .SaldoInicialesHaber.ToString("0.00"), _
                                    .MovimientosDebe.ToString("0.00"), _
                                    .MovimientosHaber.ToString("0.00"), _
                                    .SumaMayorDebe.ToString("0.00"), _
                                    .SumaMayorHaber.ToString("0.00"), _
                                    .Deudor.ToString("0.00"), _
                                    .Acreedor.ToString("0.00"), _
                                    .CancelacionesDebe.ToString("0.00"), _
                                    .CancelacionesHaber.ToString("0.00"), _
                                    .BalanceActivo.ToString("0.00"), _
                                    .BalancePasivo.ToString("0.00"), _
                                    .NaturalezaPerdidas.ToString("0.00"), _
                                    .NaturalezaGanancias.ToString("0.00"), _
                                    .Adicciones.ToString("0.00"), _
                                    .Deducciones.ToString("0.00"), _
                                    .EstadoOperacion _
                        ))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub
End Class
