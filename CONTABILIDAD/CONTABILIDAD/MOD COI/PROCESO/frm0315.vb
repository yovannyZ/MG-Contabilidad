Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.ComponentModel
Public Class frm0315
#Region "Constructor"
    Private Shared instancia As New frm0315
    Public Shared Function ObtenerInstancia() As frm0315
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0315
        End If
        instancia.BringToFront()
        Return instancia
    End Function

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete
    End Sub
#End Region
#Region "Variables"
    Private obj As New Class1
    Private LoPle0315 As New List(Of Ple0315)
    Public Cuenta() As Integer
    Dim Ruta As String = String.Empty
    Dim rutaExcel As String = String.Empty
    Dim archivoExcel As String = String.Empty
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
#End Region
#Region "Estructura"
    Public Structure Ple0315
        Public Periodo As String
        Public CodigoUnicoOperacion As String
        Public NumeroAsiento As String
        Public TipoComprobante As String
        Public SerieComprobante As String
        Public NroComprobante As String
        Public CuentaContable As String
        Public DescCuenta As String
        Public MontoCobrar As Decimal
        Public Adiciones As Decimal
        Public Deducciones As Decimal
        Public EstadoOperacion As String
        Public TipoDocIdentidad As String
        Public NroDocIdentidad As String
        Public RazonSocial As String
        Public FechaEmision As String
        Public FechaVencimientoComprobante As String
        Public TipoMoneda As String
        Public MontoMonedaExtranjera As String
        Public TipoCambio As Decimal
        '
        Public CodigoPersona As String
    End Structure
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
    Private Sub CargarPlecuentaCorriente()
        Try
            LoPle0315.Clear()
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
                Dim OCuentaCorriente As Ple0315
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
                    OCuentaCorriente = New Ple0315
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
                                If (txt_cod_cta0.Text = "19" Or txt_cod_cta0.Text = "37" Or txt_cod_cta0.Text = "49") And idx > 0 Then
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
                                LoPle0315.Add(OCuentaCorriente)
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
                                If (txt_cod_cta0.Text = "19" Or txt_cod_cta0.Text = "37" Or txt_cod_cta0.Text = "49") And idx > 0 Then
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
                                LoPle0315.Add(OCuentaCorriente)
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
                                If (txt_cod_cta0.Text = "19" Or txt_cod_cta0.Text = "37" Or txt_cod_cta0.Text = "49") And idx > 0 Then
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
                                If (txt_cod_cta0.Text = "19" Or txt_cod_cta0.Text = "37" Or txt_cod_cta0.Text = "49") And idx > 0 Then
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
                                If (txt_cod_cta0.Text = "19" Or txt_cod_cta0.Text = "37" Or txt_cod_cta0.Text = "49") And idx > 0 Then
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
                    LoPle0315.Add(OCuentaCorriente)
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
            NAsiento = CInt(LoPle0315.Item(LoPle0315.Count - 1).NumeroAsiento.Replace("M", ""))
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
                Using cmd As New OleDbCommand("Select * from [3.15$]", cnn)
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
        Dim OCuentaCorriente As Ple0315
        If chkContinuo.Checked Then
            For Each dr In ds.Tables(0).Rows
                OCuentaCorriente = New Ple0315
                With OCuentaCorriente
                    NAsiento += 1
                    .Periodo = dr(0)
                    .CodigoUnicoOperacion = dr(1)
                    .NumeroAsiento = "M" & NAsiento.ToString
                    .TipoComprobante = dr(3)
                    .SerieComprobante = dr(4)
                    .NroComprobante = dr(5)
                    .CuentaContable = dr(6)
                    .DescCuenta = dr(7)
                    .MontoCobrar = dr(8)
                    .Adiciones = dr(9)
                    .Deducciones = dr(10)
                    .EstadoOperacion = dr(11)
                    .TipoDocIdentidad = ""
                    .NroDocIdentidad = ""
                    .RazonSocial = ""
                    .FechaEmision = ""
                    .FechaVencimientoComprobante = ""
                    .TipoMoneda = ""
                    .MontoMonedaExtranjera = ""
                    .TipoCambio = 0
                    .CodigoPersona = ""
                End With
                LoPle0315.Add(OCuentaCorriente)
            Next
        Else
            LoPle0315.Clear()
            For Each dr In ds.Tables(0).Rows
                OCuentaCorriente = New Ple0315
                With OCuentaCorriente
                    .Periodo = dr(0)
                    .CodigoUnicoOperacion = dr(1)
                    .NumeroAsiento = dr(2)
                    .TipoComprobante = dr(3)
                    .SerieComprobante = dr(4)
                    .NroComprobante = dr(5)
                    .CuentaContable = dr(6)
                    .DescCuenta = dr(7)
                    .MontoCobrar = dr(8)
                    .Adiciones = dr(9)
                    .Deducciones = dr(10)
                    .EstadoOperacion = dr(11)
                    .TipoDocIdentidad = ""
                    .NroDocIdentidad = ""
                    .RazonSocial = ""
                    .FechaEmision = ""
                    .FechaVencimientoComprobante = ""
                    .TipoMoneda = ""
                    .MontoMonedaExtranjera = ""
                    .TipoCambio = 0
                    .CodigoPersona = ""
                End With
                LoPle0315.Add(OCuentaCorriente)
            Next
        End If
    End Sub

    Private Sub ExportarWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet
        Try
            oExcel.DisplayAlerts = False
            oHoja = oLibro.Worksheets(1)
            oHoja.Name = "3.15"

            'oHoja.Cells.Font.Name = "Arial Narrow"
            'oHoja.Cells.Font.Size = "9"

            'oHoja.Range("A1:L1").Merge()
            'oHoja.Range("A1:L1").Font.Bold = True
            'oHoja.Cells(1, 1) = DESC_EMPRESA
            'oHoja.Range("A2:B2").Merge()
            'oHoja.Range("A2:B2").NumberFormat = "@"
            'oHoja.Range("A2:B2").Font.Bold = True
            'oHoja.Cells(2, 1) = RUC_EMPRESA
            'oHoja.Range("A3:B3").Merge()
            'oHoja.Range("A3:B3").Font.Bold = True
            'oHoja.Cells(3, 1) = String.Format("MONEDA: {0}", Moneda)

            'oHoja.Range("C2:L2").Merge()
            'oHoja.Range("C2:L2").Font.Bold = True
            'oHoja.Cells(2, 3) = "SALDOS CUENTA / CENTRO DE COSTOS"


            'oHoja.Range("C3:L3").Merge()
            'oHoja.Range("C3:L3").Font.Bold = True
            'oHoja.Cells(3, 3) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO)
            'Dim strRango As String = "A2:A3"
            'oHoja.Range(strRango).VerticalAlignment = -4108
            ' oHoja.Range(strRango).HorizontalAlignment = -4108

            'strRango = "A5:P5"

            oHoja.Cells(1, 1) = "Periodo" : oHoja.Cells(1, 2) = "Código Único Operación"
            oHoja.Cells(1, 3) = "Correlativo" : oHoja.Cells(1, 4) = "Tipo Comprobante"
            oHoja.Cells(1, 5) = "Nro Serie" : oHoja.Cells(1, 6) = "Nro Comprobante"
            oHoja.Cells(1, 7) = "Cuenta Contable" : oHoja.Cells(1, 8) = "Descripción Cta."
            oHoja.Cells(1, 9) = "Saldo Final" : oHoja.Cells(1, 10) = "Adiciones"
            oHoja.Cells(1, 11) = "Deducciones" : oHoja.Cells(1, 12) = "Estado Ope."
            'oHoja.Cells(5, 17) = "Total"

            oHoja.Range("A:H").NumberFormat = "@"
            oHoja.Range("I:K").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""0.00""??_);_(@_)"
            oHoja.Range("L:L").NumberFormat = "@"
            oHoja.Range("A1:L1").Font.Bold = True
            oHoja.Range("A1:L1").Interior.Color = RGB(65, 126, 168)

            Dim Fila As Integer = 2
            archivoExcel = "Ple 3.15"

            'Dim Cmd As New SqlCommand("REPORTE_CC_CTAS", con)
            'Cmd.CommandType = CommandType.StoredProcedure
            'Cmd.CommandTimeout = 720
            'Cmd.Parameters.Add("@ST_CTA", SqlDbType.Char).Value = ST_CTA
            'Cmd.Parameters.Add("@COD_CTA", SqlDbType.VarChar).Value = COD_CTA
            'Cmd.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
            'Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            'con.Open()
            'Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            'Do While Rs3.Read
            '    oHoja.Cells(Fila, 1) = Rs3.GetValue(3)
            '    oHoja.Cells(Fila, 2) = Rs3.GetValue(2)
            '    oHoja.Cells(Fila, 3) = Rs3.GetValue(0)
            '    oHoja.Cells(Fila, 4) = Rs3.GetValue(1)
            '    oHoja.Cells(Fila, 5) = IIf(1 <= CodMes, Rs3.GetValue(4), 0)
            '    oHoja.Cells(Fila, 6) = IIf(2 <= CodMes, Rs3.GetValue(5), 0)
            '    oHoja.Cells(Fila, 7) = IIf(3 <= CodMes, Rs3.GetValue(6), 0)
            '    oHoja.Cells(Fila, 8) = IIf(4 <= CodMes, Rs3.GetValue(7), 0)
            '    oHoja.Cells(Fila, 9) = IIf(5 <= CodMes, Rs3.GetValue(8), 0)
            '    oHoja.Cells(Fila, 10) = IIf(6 <= CodMes, Rs3.GetValue(9), 0)
            '    oHoja.Cells(Fila, 11) = IIf(7 <= CodMes, Rs3.GetValue(10), 0)
            '    oHoja.Cells(Fila, 12) = IIf(8 <= CodMes, Rs3.GetValue(11), 0)
            '    oHoja.Cells(Fila, 13) = IIf(9 <= CodMes, Rs3.GetValue(12), 0)
            '    oHoja.Cells(Fila, 14) = IIf(10 <= CodMes, Rs3.GetValue(13), 0)
            '    oHoja.Cells(Fila, 15) = IIf(11 <= CodMes, Rs3.GetValue(14), 0)
            '    oHoja.Cells(Fila, 16) = IIf(12 <= CodMes, Rs3.GetValue(15), 0)
            '    Fila += 1
            'Loop
            'Rs3.Close()
            Dim i As Integer = 0
            For i = 0 To LoPle0315.Count - 1
                With LoPle0315.Item(i)
                    oHoja.Cells(Fila, 1) = .Periodo
                    oHoja.Cells(Fila, 2) = .CodigoUnicoOperacion
                    oHoja.Cells(Fila, 3) = .NumeroAsiento
                    oHoja.Cells(Fila, 4) = .TipoComprobante
                    oHoja.Cells(Fila, 5) = .SerieComprobante
                    oHoja.Cells(Fila, 6) = .NroComprobante
                    oHoja.Cells(Fila, 7) = .CuentaContable
                    oHoja.Cells(Fila, 8) = .DescCuenta
                    oHoja.Cells(Fila, 9) = .MontoCobrar
                    oHoja.Cells(Fila, 10) = .Adiciones
                    oHoja.Cells(Fila, 11) = .Deducciones
                    oHoja.Cells(Fila, 12) = .EstadoOperacion
                End With
                Fila += 1
            Next

            'oHoja.Range(strRango).Cells.BorderAround(1, 2)
            'oHoja.Range(strRango).Interior.Pattern = 1
            'oHoja.Range(strRango).Interior.ColorIndex = 49
            'oHoja.Range(strRango).Font.Bold = True
            'oHoja.Range(strRango).Font.ColorIndex = 2
            'oHoja.Range(strRango).VerticalAlignment = -4108
            'oHoja.Range(strRango).HorizontalAlignment = -4108
            'oHoja.Range(String.Format("A6:P{0}", Fila - 1)).Cells.BorderAround(1, 2)
            'oHoja.Range(String.Format("A6:P{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub ExportarProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        tspbExportar.Value = e.ProgressPercentage
        tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub

    Private Sub ExportarComplete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls ", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tspbExportar.Value = 0
        stEstado.Visible = False
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
        If (Cta = "12" Or Cta = "13" Or Cta = "14" Or Cta = "16" Or Cta = "17" Or Cta = "19" Or Cta = "37") Then
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
        ElseIf (Cta = "41" OrElse Cta = "42" OrElse Cta = "43" OrElse Cta = "46" OrElse Cta = "49") Then
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
#Region "Eventos"
    Private Sub frm0315_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarAño()
        KeyPreview = True
        txt_cod_cta0.Text = Cuenta(0).ToString
    End Sub
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
        If LoPle0315.Count = 0 Then
            MessageBox.Show("No existen registros de la fecha selecionada", "Aviso")
            Exit Sub
        End If
        Dim i As Integer
        For i = 0 To LoPle0315.Count - 1
            With LoPle0315.Item(i)
                dgvCuentaCorriente.Rows.Add( _
                .Periodo, _
                .CodigoUnicoOperacion, _
                .NumeroAsiento, _
                .TipoDocIdentidad, _
                .NroDocIdentidad.Trim, _
                .RazonSocial, _
                .FechaEmision, _
                .MontoCobrar, _
                .Adiciones, _
                .Deducciones, _
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
            ElseIf (Cta = "37" Or Cta = "49") Then
                Archivo = String.Format("LE{0}{1}1231031500011111.txt", RUC_EMPRESA, cboAño.Text)
            End If
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    'Para los libros  3.12 
                    If (Cta = "42" OrElse Cta = "43") Then
                        For i = 0 To LoPle0315.Count - 1
                            With LoPle0315(i)
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
                        For i = 0 To LoPle0315.Count - 1
                            With LoPle0315(i)
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
                        For i = 0 To LoPle0315.Count - 1
                            With LoPle0315(i)
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
                        For i = 0 To LoPle0315.Count - 1
                            With LoPle0315(i)
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
                        For i = 0 To LoPle0315.Count - 1
                            With LoPle0315(i)
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
                        'Para la 3.15
                    ElseIf Cta = "37" Or Cta = "49" Then
                        For i = 0 To LoPle0315.Count - 1
                            With LoPle0315(i)
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                                .Periodo _
                                , .CodigoUnicoOperacion.Replace("_", "-") _
                                , .NumeroAsiento _
                                , .TipoComprobante _
                                , .SerieComprobante _
                                , .NroComprobante _
                                , .CuentaContable _
                                , .DescCuenta _
                                , .MontoCobrar.ToString("0.00") _
                                , .Adiciones.ToString("0.00") _
                                , .Deducciones.ToString("0.00") _
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
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        CargarDatosExcel()
        If LoPle0315.Count = 0 Then
            MessageBox.Show("No existen registros de la fecha selecionada", "Aviso")
            Exit Sub
        End If
        Dim i As Integer
        dgvCuentaCorriente.Rows.Clear()
        For i = 0 To LoPle0315.Count - 1
            With LoPle0315.Item(i)
                dgvCuentaCorriente.Rows.Add( _
                .Periodo, _
                .CodigoUnicoOperacion, _
                .NumeroAsiento, _
                .TipoDocIdentidad, _
                .NroDocIdentidad.Trim, _
                .RazonSocial, _
                .FechaEmision, _
                .MontoCobrar, _
                .Adiciones, _
                .Deducciones, _
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
    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        If dgvCuentaCorriente.RowCount <= 0 Then
            MessageBox.Show("No hay datos por exportar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                bwExportar.RunWorkerAsync()
            End If
        End If
    End Sub
#End Region
End Class