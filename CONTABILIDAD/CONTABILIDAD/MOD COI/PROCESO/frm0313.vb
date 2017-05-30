Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frm0313
#Region "Variables"
    Private obj As New Class1
    Private LoPleCuentaCorriente As New List(Of CuentaCorriente)
    Public Cuenta() As Integer
    Dim Ruta As String = String.Empty
#End Region
#Region "Métodos"
    Private Sub CargarAño()
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
    Private Sub CargarCuentas()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_NIVEL(AÑO, "1")
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(4).Visible = False
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CargarPlecuentaCorriente()
        Try
            LoPleCuentaCorriente.Clear()
            Using cmd As New SqlCommand("REPORTE_CONCILIADAS_PLE", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = CInt(cboAño.Text) + 1
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = "00" '"12"
                cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = txt_cod_cta0.Text
                cmd.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char).Value = "0"
                cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = ""
                cmd.Parameters.Add("@S_PER", SqlDbType.Char).Value = "1"
                cmd.Parameters.Add("@FECHA_CONC", SqlDbType.DateTime).Value = "31/12/" + cboAño.Text.ToString '(CInt(cboAño.Text) - 1).ToString
                'Para el calculo de los agrupados
                Dim dsPDB As New DataSet
                Dim DA_PDB As New SqlDataAdapter(cmd)
                DA_PDB.Fill(dsPDB)
                Dim drd, drds As DataRow
                Dim OCuentaCorriente As CuentaCorriente
                Dim I, J, x As Integer
                Dim z, filas As Integer
                Dim key As Boolean = False
                Dim idx As Short = 0
                z = 0
                filas = dsPDB.Tables(0).Rows.Count - 1
                'Cuando la cta es diferente de 42,43 factor* algo
                Dim factor As Short
                'Variables para retener el principal
                Dim CodigoUnicoOperacion, TipoDocIdentidad, NroDocIdentidad, RazonSocial, FechaEmision, CuentaContable, DescCuenta, TipoComprobante, NroComprobante, FechaVencimientoComprobante, TipoMoneda As String
                Dim MontoCobrar, MontoMonedaExtranjera, TipoCambio As Decimal
                MontoCobrar = 0 : MontoMonedaExtranjera = 0 : TipoCambio = 0
                CodigoUnicoOperacion = "" : TipoDocIdentidad = "" : NroDocIdentidad = "" : RazonSocial = "" : FechaEmision = "" : CuentaContable = "" : DescCuenta = "" : TipoComprobante = "" : NroComprobante = "" : FechaVencimientoComprobante = "" : TipoMoneda = ""
                '----
                'Recorremos el dataset
                For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                    drd = dsPDB.Tables(0).Rows(I)
                    drds = dsPDB.Tables(0).Rows(IIf(filas = I, I, I + 1))
                    OCuentaCorriente = New CuentaCorriente
                    With OCuentaCorriente
                        'Validamos si los dos ultimos tienen relacion o no.
                        If I = dsPDB.Tables(0).Rows.Count - 1 Then
                            drd = dsPDB.Tables(0).Rows(I)
                            drds = dsPDB.Tables(0).Rows(I - 1)
                            If drd("NRO_DOC") = drds("NRO_DOC") And drd("COD_DOC") = drds("COD_DOC") And drd("COD_PER") = drds("COD_PER") Then
                                z += 1
                                .Periodo = cboAño.Text + "1231"
                                .CodigoUnicoOperacion = CodigoUnicoOperacion
                                .NumeroAsiento = "M" + z.ToString()
                                .TipoDocIdentidad = TipoDocIdentidad
                                .NroDocIdentidad = NroDocIdentidad
                                .RazonSocial = RazonSocial
                                .FechaEmision = CDate(FechaEmision).ToShortDateString
                                'Para los documentos similares
                                factor = RecuperarFactor(txt_cod_cta0.Text, drd("COD_CUENTA").ToString, drd("COD_DOC").ToString, drd("COD_D_H").ToString)
                                '--
                                .MontoCobrar = MontoCobrar + (CDbl(drd("IMP_S")) * factor)
                                .EstadoOperacion = "1"
                                .CuentaContable = CuentaContable
                                .DescCuenta = DescCuenta
                                .TipoComprobante = TipoComprobante
                                '--Here
                                idx = drd("NRO_DOC").ToString.IndexOf("-")
                                If txt_cod_cta0.Text = "19" And idx > 0 Then
                                    .SerieComprobante = drd("NRO_DOC").ToString.Substring(0, idx)
                                    .NroComprobante = drd("NRO_DOC").ToString.Substring(idx + 1, drd("NRO_DOC").ToString.Length - idx - 1)
                                Else
                                    .SerieComprobante = ""
                                    .NroComprobante = drd("NRO_DOC")
                                End If
                                '--
                                .FechaVencimientoComprobante = CDate(FechaVencimientoComprobante).ToShortDateString
                                If (TipoMoneda = "D") Then
                                    .TipoMoneda = TipoMoneda
                                    .MontoMonedaExtranjera = MontoMonedaExtranjera + (CDbl(drd("IMP_D")) * factor)
                                Else
                                    .TipoMoneda = TipoMoneda
                                    .MontoMonedaExtranjera = 0
                                End If
                                .TipoCambio = TipoCambio
                                .CodigoPersona = drd("COD_PER")
                                LoPleCuentaCorriente.Add(OCuentaCorriente)
                                Continue For
                            Else
                                z += 1
                                .Periodo = cboAño.Text + "1231"
                                .CodigoUnicoOperacion = drd("COD_AUX").ToString + drd("COD_COMP").ToString + drd("NRO_COMP").ToString
                                .NumeroAsiento = "M" + z.ToString()
                                .TipoDocIdentidad = IIf(IsNumeric(drd("COD_TIPO_DOC")), drd("COD_TIPO_DOC"), "0") 'drd("COD_TIPO_DOC")
                                .NroDocIdentidad = drd("NRO_DOC_PER")
                                .RazonSocial = drd("DESC_PER")
                                .FechaEmision = CDate(drd("FECHA_DOC")).ToShortDateString

                                factor = RecuperarFactor(txt_cod_cta0.Text, drd("COD_CUENTA").ToString, drd("COD_DOC").ToString, drd("COD_D_H").ToString)
                                '--
                                .MontoCobrar = (CDbl(drd("IMP_S")) * factor)
                                .EstadoOperacion = "1"
                                .CuentaContable = drd("COD_CUENTA")
                                .DescCuenta = drd("DESC_CUENTA")
                                .TipoComprobante = drd("COD_DOC")

                                idx = drd("NRO_DOC").ToString.IndexOf("-")
                                If txt_cod_cta0.Text = "19" And idx > 0 Then
                                    .SerieComprobante = drd("NRO_DOC").ToString.Substring(0, idx)
                                    .NroComprobante = drd("NRO_DOC").ToString.Substring(idx + 1, drd("NRO_DOC").ToString.Length - idx - 1)
                                Else
                                    'Este es el original
                                    .SerieComprobante = ""
                                    .NroComprobante = drd("NRO_DOC")
                                End If


                                .FechaVencimientoComprobante = CDate(drd("FECHA_VEN")).ToShortDateString
                                If (drd("COD_MONEDA") = "D") Then
                                    .TipoMoneda = drd("COD_MONEDA")
                                    .MontoMonedaExtranjera = drd("IMP_D")
                                Else
                                    .TipoMoneda = drd("COD_MONEDA")
                                    .MontoMonedaExtranjera = 0
                                End If
                                .TipoCambio = drd("TIPO_CAMBIO")
                                .CodigoPersona = drd("COD_PER")
                                LoPleCuentaCorriente.Add(OCuentaCorriente)
                                Continue For
                            End If
                        End If
                        'Si el documento,numero y persona son iguales las sumamos
                        If drd("NRO_DOC") = drds("NRO_DOC") And drd("COD_DOC") = drds("COD_DOC") And drd("COD_PER") = drds("COD_PER") Then
                            'Validamos para que no entre dos veces a tomar los datos del principal por el tema de los documentos que se repiten continuamente
                            If key = False Then
                                CodigoUnicoOperacion = drd("COD_AUX").ToString + drd("COD_COMP").ToString + drd("NRO_COMP").ToString
                                TipoDocIdentidad = IIf(IsNumeric(drd("COD_TIPO_DOC")), drd("COD_TIPO_DOC"), "0") 'drd("COD_TIPO_DOC")
                                NroDocIdentidad = drd("NRO_DOC_PER")
                                RazonSocial = drd("DESC_PER")
                                FechaEmision = CDate(drd("FECHA_DOC")).ToShortDateString
                                CuentaContable = drd("COD_CUENTA")
                                DescCuenta = drd("DESC_CUENTA")
                                TipoComprobante = drd("COD_DOC")
                                ' NroComprobante = drd("NRO_DOC")

                                idx = drd("NRO_DOC").ToString.IndexOf("-")
                                If txt_cod_cta0.Text = "19" And idx > 0 Then
                                    .SerieComprobante = drd("NRO_DOC").ToString.Substring(0, idx)
                                    .NroComprobante = drd("NRO_DOC").ToString.Substring(idx + 1, drd("NRO_DOC").ToString.Length - idx - 1)
                                Else
                                    .SerieComprobante = ""
                                    .NroComprobante = drd("NRO_DOC")
                                End If

                                FechaVencimientoComprobante = CDate(drd("FECHA_VEN")).ToShortDateString
                                TipoCambio = drd("TIPO_CAMBIO")
                                .CodigoPersona = drd("COD_PER")
                            End If
                            key = True
                            factor = RecuperarFactor(txt_cod_cta0.Text, drd("COD_CUENTA").ToString, drd("COD_DOC").ToString, drd("COD_D_H").ToString)
                            '--
                            'Por el monto y la moneda
                            MontoCobrar += CDbl(drd("IMP_S")) * factor
                            If drd("COD_MONEDA") = "D" Then
                                TipoMoneda = drd("COD_MONEDA")
                                MontoMonedaExtranjera += CDbl(drd("IMP_D")) * factor
                            Else
                                TipoMoneda = drd("COD_MONEDA")
                                MontoMonedaExtranjera = 0 '+= CDbl(drd("IMP_D")) * factor
                            End If
                            Continue For
                        Else
                            If key Then
                                z += 1
                                .Periodo = cboAño.Text + "1231"
                                .CodigoUnicoOperacion = CodigoUnicoOperacion
                                .NumeroAsiento = "M" + z.ToString()
                                .TipoDocIdentidad = TipoDocIdentidad
                                .NroDocIdentidad = NroDocIdentidad
                                .RazonSocial = RazonSocial
                                .FechaEmision = CDate(FechaEmision).ToShortDateString

                                'Probamos el la rutina encapsulado
                                factor = RecuperarFactor(txt_cod_cta0.Text, drd("COD_CUENTA").ToString, drd("COD_DOC").ToString, drd("COD_D_H").ToString)
                                '--
                                .MontoCobrar = MontoCobrar + (CDbl(drd("IMP_S")) * factor)
                                .EstadoOperacion = "1"
                                .CuentaContable = CuentaContable
                                .DescCuenta = DescCuenta
                                .TipoComprobante = TipoComprobante
                                '--Here
                                idx = drd("NRO_DOC").ToString.IndexOf("-")
                                If txt_cod_cta0.Text = "19" And idx > 0 Then
                                    .SerieComprobante = drd("NRO_DOC").ToString.Substring(0, idx)
                                    .NroComprobante = drd("NRO_DOC").ToString.Substring(idx + 1, drd("NRO_DOC").ToString.Length - idx - 1)
                                Else
                                    .SerieComprobante = ""
                                    .NroComprobante = drd("NRO_DOC")
                                End If
                                '--
                                .FechaVencimientoComprobante = CDate(FechaVencimientoComprobante).ToShortDateString
                                If TipoMoneda = "D" Then
                                    .TipoMoneda = TipoMoneda
                                    .MontoMonedaExtranjera = MontoMonedaExtranjera + (CDbl(drd("IMP_D")) * factor)
                                Else
                                    .TipoMoneda = TipoMoneda
                                    .MontoMonedaExtranjera = 0
                                End If
                                .TipoCambio = TipoCambio
                                .CodigoPersona = drd("COD_PER")
                                key = False

                            Else
                                z += 1
                                .Periodo = cboAño.Text + "1231"
                                .CodigoUnicoOperacion = drd("COD_AUX").ToString + drd("COD_COMP").ToString + drd("NRO_COMP").ToString
                                .NumeroAsiento = "M" + z.ToString()
                                .TipoDocIdentidad = IIf(IsNumeric(drd("COD_TIPO_DOC")), drd("COD_TIPO_DOC"), "0")
                                .NroDocIdentidad = drd("NRO_DOC_PER")
                                .RazonSocial = drd("DESC_PER")
                                .FechaEmision = CDate(drd("FECHA_DOC")).ToShortDateString
                                '--
                                factor = RecuperarFactor(txt_cod_cta0.Text, drd("COD_CUENTA").ToString, drd("COD_DOC").ToString, drd("COD_D_H").ToString)
                                '--
                                .MontoCobrar = CDbl(drd("IMP_S")) * factor
                                .EstadoOperacion = "1"
                                .CuentaContable = drd("COD_CUENTA")
                                .DescCuenta = drd("DESC_CUENTA")
                                .TipoComprobante = drd("COD_DOC")
                                '--Here
                                idx = drd("NRO_DOC").ToString.IndexOf("-")
                                If txt_cod_cta0.Text = "19" And idx > 0 Then
                                    .SerieComprobante = drd("NRO_DOC").ToString.Substring(0, idx)
                                    .NroComprobante = drd("NRO_DOC").ToString.Substring(idx + 1, drd("NRO_DOC").ToString.Length - idx - 1)
                                Else
                                    .SerieComprobante = ""
                                    .NroComprobante = drd("NRO_DOC")
                                End If
                                '--
                                .FechaVencimientoComprobante = CDate(drd("FECHA_VEN")).ToShortDateString
                                If (drd("COD_MONEDA") = "D") Then
                                    .TipoMoneda = drd("COD_MONEDA")
                                    .MontoMonedaExtranjera = drd("IMP_D")
                                Else
                                    .TipoMoneda = drd("COD_MONEDA")
                                    .MontoMonedaExtranjera = 0
                                End If
                                .TipoCambio = drd("TIPO_CAMBIO")
                                .CodigoPersona = drd("COD_PER")
                            End If
                        End If
                    End With
                    LoPleCuentaCorriente.Add(OCuentaCorriente)
                    'Limpiamos las variables
                    MontoCobrar = 0 : MontoMonedaExtranjera = 0 : TipoCambio = 0
                    CodigoUnicoOperacion = "" : TipoDocIdentidad = "" : NroDocIdentidad = "" : RazonSocial = "" : FechaEmision = "" : CuentaContable = "" : DescCuenta = "" : TipoComprobante = "" : NroComprobante = "" : FechaVencimientoComprobante = "" : TipoMoneda = ""
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub SumarMontos()
        Dim Monto As Decimal
        For i As Integer = 0 To dgvCuentaCorriente.RowCount - 1
            Monto += CDbl(dgvCuentaCorriente.Item(7, i).Value)
        Next
        txtSumaMontos.Text = Monto
    End Sub
    Private Sub CargarDatosExcel()
        Ruta = String.Empty
        'Recuperamos el ultimo numero de asiento
        Dim NAsiento As Integer
        If chkContinuo.Checked Then
            NAsiento = CInt(LoPleCuentaCorriente.Item(LoPleCuentaCorriente.Count - 1).NumeroAsiento.Replace("M", ""))
        End If
        '--
        Using ofd As New OpenFileDialog
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Ruta = ofd.FileName
            End If
        End Using
        If String.IsNullOrEmpty(Ruta) Then
            MessageBox.Show("La ruta para el archivo esta vacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Iniciamos la lectura del excel
        Dim ds As New DataSet
        Dim conExcel As String = "Provider=Microsoft.ACE.Oledb.12.0;" & _
                "Extended Properties='TEXT;HDR=Yes';" & _
                "Data Source=" & Ruta & ";" & _
                "Extended Properties= Excel 8.0"
        Try
            Using cnn As New OleDbConnection(conExcel)
                Using cmd As New OleDbCommand("Select * from [3.13$]", cnn)
                    cmd.CommandType = CommandType.Text
                    Using Da As New OleDbDataAdapter(cmd)
                        Da.Fill(ds)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        'Recorremos el dataset y lo asignamos a un datarow
        'LoPleCuentaCorriente.Clear()
        Dim dr As DataRow
        Dim OCuentaCorriente As CuentaCorriente
        If chkContinuo.Checked Then
            For Each dr In ds.Tables(0).Rows
                OCuentaCorriente = New CuentaCorriente
                With OCuentaCorriente
                    NAsiento += 1
                    .Periodo = dr(0)
                    .CodigoUnicoOperacion = dr(1)
                    .NumeroAsiento = "M" & NAsiento.ToString
                    .TipoDocIdentidad = dr(3)
                    .NroDocIdentidad = dr(4)
                    .RazonSocial = dr(6)
                    .FechaEmision = dr(5)
                    .MontoCobrar = dr(8)
                    .EstadoOperacion = dr(9)
                    .CuentaContable = dr(7)
                    .DescCuenta = ""
                    .TipoComprobante = ""
                    .SerieComprobante = ""
                    .NroComprobante = ""
                    .FechaVencimientoComprobante = ""
                    .TipoMoneda = ""
                    .MontoMonedaExtranjera = ""
                    .TipoCambio = 0
                    '
                    .CodigoPersona = ""
                End With
                LoPleCuentaCorriente.Add(OCuentaCorriente)
            Next
        Else
            LoPleCuentaCorriente.Clear()
            For Each dr In ds.Tables(0).Rows
                OCuentaCorriente = New CuentaCorriente
                With OCuentaCorriente
                    .Periodo = dr(0)
                    .CodigoUnicoOperacion = dr(1)
                    .NumeroAsiento = dr(2)
                    .TipoDocIdentidad = dr(3)
                    .NroDocIdentidad = dr(4)
                    .RazonSocial = dr(6)
                    .FechaEmision = dr(5)
                    .MontoCobrar = dr(8)
                    .EstadoOperacion = dr(9)
                    .CuentaContable = dr(7)
                    .DescCuenta = ""
                    .TipoComprobante = ""
                    .SerieComprobante = ""
                    .NroComprobante = ""
                    .FechaVencimientoComprobante = ""
                    .TipoMoneda = ""
                    .MontoMonedaExtranjera = ""
                    .TipoCambio = 0
                    '
                    .CodigoPersona = ""
                End With
                LoPleCuentaCorriente.Add(OCuentaCorriente)
            Next
        End If
    End Sub

#End Region
#Region "Funciones"
    Private Function ValidarDocumento(ByVal CodigoDocumento As String) As Boolean
        Dim Mensaje As String = String.Empty
        'Dim Cuenta() As Integer = {12, 13, 14, 16, 17, 42, 43}
        Dim x As Integer = 0
        For x = 0 To Cuenta.Length - 1
            If Cuenta(x) = CodigoDocumento Then
                Return True
            Else
                Mensaje += Cuenta(x) & " "
            End If
        Next
        MessageBox.Show("No pueden ver cuentas que sea diferente de  " & Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
    End Function
    'Encapsulamos la rutina para el factor
    Private Function RecuperarFactor(ByVal Cta As String, ByVal CtaNivel As String, ByVal Documento As String, ByVal DH As String)
        Dim Valor As Integer = 0
        If (Cta = "12" Or Cta = "13" Or Cta = "14" Or Cta = "16" Or Cta = "17" Or Cta = "19") Then
            If (CtaNivel.ToString.Substring(0, 3) = "122") Then
                If Documento = "07" Or Documento = "97" Then
                    If DH = "D" Then
                        Valor = -1
                    Else
                        Valor = 1
                    End If
                Else
                    If DH = "H" Then
                        Valor = -1
                    Else
                        Valor = 1
                    End If
                End If
            Else
                If Documento = "07" Or Documento = "97" Then
                    If DH = "H" Then
                        Valor = -1
                    Else
                        Valor = 1
                    End If
                Else
                    If DH = "D" Then
                        Valor = 1
                    Else
                        Valor = -1
                    End If
                End If
            End If
        ElseIf (Cta = "41" OrElse Cta = "42" OrElse Cta = "43" OrElse Cta = "46") Then
            If (CtaNivel.ToString.Substring(0, 3) = "422" Or CtaNivel.ToString.Substring(0, 3) = "432") Then
                If Documento = "07" Then
                    If DH = "H" Then
                        Valor = 1
                    Else
                        Valor = -1
                    End If
                Else
                    If DH = "D" Then
                        Valor = -1
                    Else
                        Valor = 1
                    End If
                End If
            Else
                If Documento = "07" Then
                    If DH = "D" Then
                        Valor = -1
                    Else
                        Valor = 1
                    End If
                Else
                    If DH = "H" Then
                        Valor = 1
                    Else
                        Valor = -1
                    End If
                End If
            End If
        End If
        Return Valor
    End Function
    Private Function AsignarDocumentos(ByVal Documento As String) As String
        Dim Doc As String = "00"
        Dim DocumentosSunat() As String = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "40", "41", "42", "43", "44", "45", "46", "48", "49", "50", "51", "52", "53", "54", "55", "56", "87", "88", "89", "91", "96", "97", "98"}
        Dim i, Registros As Integer
        i = 0 : Registros = DocumentosSunat.Length
        While (i < Registros)
            If (DocumentosSunat(i).Equals(Documento)) Then
                Doc = Documento
                Exit While
            End If
            i += 1
        End While
        Return Doc
    End Function

#End Region
#Region "Estructura"

    Public Structure CuentaCorriente
        Public Periodo As String
        Public CodigoUnicoOperacion As String
        Public NumeroAsiento As String
        Public TipoDocIdentidad As String
        Public NroDocIdentidad As String
        Public RazonSocial As String
        Public FechaEmision As String
        Public MontoCobrar As Decimal
        Public EstadoOperacion As String
        Public CuentaContable As String
        Public DescCuenta As String
        Public TipoComprobante As String
        Public SerieComprobante As String
        Public NroComprobante As String
        Public FechaVencimientoComprobante As String
        Public TipoMoneda As String
        Public MontoMonedaExtranjera As String
        Public TipoCambio As Decimal
        '
        Public CodigoPersona As String
    End Structure

#End Region
#Region "Eventos"

    Private Sub frmPleCuentaCorriente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPleCuentaCorriente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarAño()
        CargarCuentas()
        KeyPreview = True
        txt_cod_cta0.Text = Cuenta(0).ToString
    End Sub

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        If (dgw_cta.Item(0, i).Value.ToString.Length = 0) Then
                            MessageBox.Show("El Cuenta debe ser de Nivel 1", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_cta0.Clear()
                            txt_desc_cta0.Clear()
                            txt_cod_cta0.Focus()
                        Else
                            txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                            txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        End If
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
            End If
        End If
    End Sub

    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value).Length <> 2) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 1", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta0.Clear()
                txt_desc_cta0.Clear()
            Else
                txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                PaneL_CTA.Visible = False
                'KL.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

#End Region
#Region "Constructor"
    Private Shared instancia As New frm0313
    Public Shared Function ObtenerInstancia() As frm0313
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0313
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region
#Region "Botones"

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If ValidarDocumento(txt_cod_cta0.Text) = False Then
            dgvCuentaCorriente.Rows.Clear()
            Exit Sub
        End If
        dgvCuentaCorriente.Rows.Clear()
        txtSumaMontos.Clear()
        CargarPlecuentaCorriente()
        If LoPleCuentaCorriente.Count = 0 Then
            MessageBox.Show("No existen registros de la fecha selecionada", "Aviso")
            Exit Sub
        End If
        Dim i As Integer
        For i = 0 To LoPleCuentaCorriente.Count - 1
            With LoPleCuentaCorriente.Item(i)
                dgvCuentaCorriente.Rows.Add( _
                .Periodo, _
                .CodigoUnicoOperacion, _
                .NumeroAsiento, _
                .TipoDocIdentidad, _
                .NroDocIdentidad.Trim, _
                .RazonSocial, _
                .FechaEmision, _
                .MontoCobrar, _
                .EstadoOperacion, _
                .CuentaContable, _
                .DescCuenta, _
                .TipoComprobante, _
                .SerieComprobante, _
                .NroComprobante.Trim, _
                .FechaVencimientoComprobante, _
                .TipoMoneda, _
                .MontoMonedaExtranjera, _
                .TipoCambio)
            End With
        Next
        SumarMontos()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        If dgvCuentaCorriente.Rows.Count = 0 Then
            MessageBox.Show("No hay registros a importar")
            Exit Sub
        End If
        Dim Archivo As String = String.Empty
        Dim ofbd As New FolderBrowserDialog
        Dim Cta As String = txt_cod_cta0.Text.ToString
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            If (Cta = "12" Or Cta = "13") Then
                Archivo = String.Format("LE{0}{1}1231030300011111.txt", RUC_EMPRESA, cboAño.Text)
            ElseIf (Cta = "14") Then
                Archivo = String.Format("LE{0}{1}1231030400011111.txt", RUC_EMPRESA, cboAño.Text)
            ElseIf (Cta = "16" Or Cta = "17") Then
                Archivo = String.Format("LE{0}{1}1231030500011111.txt", RUC_EMPRESA, cboAño.Text)
            ElseIf (Cta = "19") Then
                Archivo = String.Format("LE{0}{1}1231030600011111.txt", RUC_EMPRESA, cboAño.Text)
            ElseIf (Cta = "41") Then
                Archivo = String.Format("LE{0}{1}1231031100011111.txt", RUC_EMPRESA, cboAño.Text)
            ElseIf (Cta = "42" Or Cta = "43") Then
                Archivo = String.Format("LE{0}{1}1231031200011111.txt", RUC_EMPRESA, cboAño.Text)
            ElseIf (Cta = "46" Or Cta = "47") Then
                Archivo = String.Format("LE{0}{1}1231031300011111.txt", RUC_EMPRESA, cboAño.Text)
                'ElseIf (Cta = "37" Or Cta = "49") Then
                '    Archivo = String.Format("LE{0}{1}1231031500CCOIM1.txt", RUC_EMPRESA, cboAño.Text)
            End If
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    'Para los libros  3.12 
                    If (Cta = "42" OrElse Cta = "43") Then
                        For i = 0 To LoPleCuentaCorriente.Count - 1
                            With LoPleCuentaCorriente(i)
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|", _
                                .Periodo, _
                                .CodigoUnicoOperacion.Replace("_", "-"), _
                                .NumeroAsiento, _
                                 CInt(.TipoDocIdentidad), _
                                .NroDocIdentidad.Trim, _
                                .FechaEmision, _
                                .RazonSocial.Trim, _
                                .MontoCobrar.ToString("0.00"), _
                                .EstadoOperacion _
                                ))
                            End With
                        Next
                        'libro 3.3 3.4 3.5
                    ElseIf (Cta = "12" OrElse Cta = "13" OrElse Cta = "14" OrElse Cta = "16" OrElse Cta = "17") Then
                        For i = 0 To LoPleCuentaCorriente.Count - 1
                            With LoPleCuentaCorriente(i)
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|", _
                                .Periodo, _
                                .CodigoUnicoOperacion.Replace("_", "-"), _
                                .NumeroAsiento, _
                                 CInt(.TipoDocIdentidad), _
                                .NroDocIdentidad.Trim, _
                                .RazonSocial.Trim, _
                                .FechaEmision, _
                                .MontoCobrar.ToString("0.00"), _
                                .EstadoOperacion _
                                ))
                            End With
                        Next
                    ElseIf (Cta = "19") Then
                        'Para la 3.6
                        For i = 0 To LoPleCuentaCorriente.Count - 1
                            With LoPleCuentaCorriente(i)
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                                .Periodo, _
                                .CodigoUnicoOperacion.Replace("_", "-"), _
                                .NumeroAsiento, _
                                 CInt(.TipoDocIdentidad), _
                                .NroDocIdentidad.Trim _
                                , .RazonSocial.Trim _
                                , AsignarDocumentos(.TipoComprobante) _
                                , .SerieComprobante _
                                , .NroComprobante _
                                , .FechaEmision _
                                , .MontoCobrar.ToString("0.00") _
                                , .EstadoOperacion))
                            End With
                        Next
                        'Para la 3.11
                    ElseIf (Cta = "41") Then
                        For i = 0 To LoPleCuentaCorriente.Count - 1
                            With LoPleCuentaCorriente(i)
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", _
                                .Periodo _
                                , .CodigoUnicoOperacion.Replace("_", "-") _
                                , .NumeroAsiento _
                                , .CuentaContable _
                                , CInt(.TipoDocIdentidad) _
                                , .NroDocIdentidad.Trim _
                                , .CodigoPersona _
                                , .RazonSocial.Trim _
                                , .MontoCobrar.ToString("0.00") _
                                , .EstadoOperacion _
                                ))
                            End With
                        Next
                        'Para la 3.13
                    ElseIf Cta = "46" Or Cta = "47" Then
                        For i = 0 To LoPleCuentaCorriente.Count - 1
                            With LoPleCuentaCorriente(i)
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|", _
                                .Periodo _
                                , .CodigoUnicoOperacion.Replace("_", "-") _
                                , .NumeroAsiento _
                                , CInt(.TipoDocIdentidad) _
                                , .NroDocIdentidad.Trim _
                                , .FechaEmision _
                                , .RazonSocial.Trim _
                                , .CuentaContable _
                                , .MontoCobrar.ToString("0.00") _
                                , .EstadoOperacion _
                                ))
                            End With
                        Next
                    End If
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub
#End Region

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        CargarDatosExcel()
        If LoPleCuentaCorriente.Count = 0 Then
            MessageBox.Show("No existen registros de la fecha selecionada", "Aviso")
            Exit Sub
        End If
        Dim i As Integer
        dgvCuentaCorriente.Rows.Clear()
        For i = 0 To LoPleCuentaCorriente.Count - 1
            With LoPleCuentaCorriente.Item(i)
                dgvCuentaCorriente.Rows.Add( _
                .Periodo, _
                .CodigoUnicoOperacion, _
                .NumeroAsiento, _
                .TipoDocIdentidad, _
                .NroDocIdentidad.Trim, _
                .RazonSocial, _
                .FechaEmision, _
                .MontoCobrar, _
                .EstadoOperacion, _
                .CuentaContable, _
                .DescCuenta, _
                .TipoComprobante, _
                .SerieComprobante, _
                .NroComprobante.Trim, _
                .FechaVencimientoComprobante, _
                .TipoMoneda, _
                .MontoMonedaExtranjera, _
                .TipoCambio)
            End With
        Next
        txtSumaMontos.Clear()
        SumarMontos()
    End Sub
End Class