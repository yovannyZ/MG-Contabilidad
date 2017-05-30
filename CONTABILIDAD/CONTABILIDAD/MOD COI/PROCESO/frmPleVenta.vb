Imports System.Data.SqlClient
Imports System.IO

Public Class frmPleVenta
    Private Obj As New Class1
    Private Config As String
    Private loPleVentas As New List(Of PLE_Venta)
    Private Item As Integer
    Private Idx As Integer
    Private _fila As Integer
    Private _consultar As Boolean

#Region "Constructor"
    Private Shared instancia As frmPleVenta

    Public Shared Function ObtenerInstancia() As frmPleVenta
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmPleVenta
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

    Public Structure PLE_Venta
        Public Item As String
        Public Periodo As Integer
        Public Año As String
        Public Mes As String
        Public Emision As Date
        Public Vencimiento As Date
        Public TipoComprobante As String
        Public SerieComprobante As String
        Public NroComprobante As String
        Public TotalConsolidado As Integer
        Public TipoDocumento As String
        Public NroDocumento As String
        Public RazonSocial As String
        Public Exportacion As Decimal
        Public Base1 As Decimal
        Public Exonerado As Decimal
        Public Inafecto As Decimal
        Public MontoISC As Decimal
        Public Igv1 As Decimal
        Public Base2 As Decimal
        Public Igv2 As Decimal
        Public MontoOtros As Decimal
        Public ImporteComprobante As Decimal
        Public TipoCambio As Decimal
        Public EmisionRef As Date
        Public TipoComprobanteRef As String
        Public SerieComprobanteRef As String
        Public NroComprobanteRef As String
        Public Anotacion As String
        Public AuxiliarOrigen As String
        Public ComprobanteOrigen As String
        Public NumeroComprobanteOrigen As String
        Public CodigoMoneda As String
        Public IndicadorComprobante As String
        Public BaseDes As Decimal
        Public IgvDes As Decimal
    End Structure
    Private Sub ConsultarPle_Anual()
        Try
            loPleVentas.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_VENTAS_ANUAL", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@FE_MES1", SqlDbType.Char)
            'par0.Value = cbo_año.Text
            par0.Value = cbo_año_sunat.Text : par1.Value = Obj.COD_MES(cbomes.Text) : par2.Value = Obj.COD_MES(cbomes1.Text)
            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Venta
                While drd.Read
                    ObePla = New PLE_Venta
                    With ObePla
                        i += 1
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .Emision = CDate(drd(4)).ToShortDateString
                        .Vencimiento = IIf(CDate(drd(5)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(5)).ToShortDateString)
                        .TipoComprobante = drd(6)
                        .SerieComprobante = drd(7)
                        .NroComprobante = drd(8)
                        .TotalConsolidado = drd(9)
                        .TipoDocumento = drd(10)
                        If drd(10) = "0" Then .NroDocumento = "-" Else .NroDocumento = drd(11)
                        .RazonSocial = drd(12)
                        .Exportacion = drd(13)
                        .Base1 = drd(14)
                        .Exonerado = drd(15)
                        .Inafecto = drd(16)
                        .MontoISC = drd(17)
                        .Igv1 = drd(18)
                        .Base2 = drd(19)
                        .Igv2 = drd(20)
                        .MontoOtros = drd(21)
                        .ImporteComprobante = drd(22)
                        .TipoCambio = drd(23)
                        .EmisionRef = IIf(CDate(drd(24)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(24)).ToShortDateString)
                        .TipoComprobanteRef = drd(25)
                        .SerieComprobanteRef = drd(26)
                        .NroComprobanteRef = drd(27)
                        .Anotacion = drd(28)
                        .AuxiliarOrigen = drd(29)
                        .ComprobanteOrigen = drd(30)
                        .NumeroComprobanteOrigen = drd(31)
                    End With
                    loPleVentas.Add(ObePla)
                End While
            End If
            _consultar = True
        Catch ex As Exception
            _consultar = False
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultarPle()
        Try
            loPleVentas.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_VENTAS", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Venta
                While drd.Read
                    ObePla = New PLE_Venta
                    With ObePla
                        i += 1
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .Emision = CDate(drd(4)).ToShortDateString
                        .Vencimiento = IIf(CDate(drd(5)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(5)).ToShortDateString)
                        .TipoComprobante = drd(6)
                        .SerieComprobante = drd(7)
                        .NroComprobante = drd(8)
                        .TotalConsolidado = drd(9)
                        .TipoDocumento = drd(10)
                        .NroDocumento = drd(11)
                        .RazonSocial = drd(12)
                        .Exportacion = drd(13)
                        .Base1 = drd(14)
                        .Exonerado = drd(15)
                        .Inafecto = drd(16)
                        .MontoISC = drd(17)
                        .Igv1 = drd(18)
                        .Base2 = drd(19)
                        .Igv2 = drd(20)
                        .MontoOtros = drd(21)
                        .ImporteComprobante = drd(22)
                        .TipoCambio = drd(23)
                        .EmisionRef = IIf(CDate(drd(24)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(24)).ToShortDateString)
                        .TipoComprobanteRef = drd(25)
                        .SerieComprobanteRef = drd(26)
                        .NroComprobanteRef = drd(27)
                        .Anotacion = drd(28)
                        .AuxiliarOrigen = drd(29)
                        .ComprobanteOrigen = drd(30)
                        .NumeroComprobanteOrigen = drd(31)
                        .CodigoMoneda = drd(32)
                        .IndicadorComprobante = drd(33)

                        .BaseDes = drd(34)
                        .IgvDes = drd(35)
                    End With
                    loPleVentas.Add(ObePla)
                End While
            End If
            _consultar = True
        Catch ex As Exception
            _consultar = False
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Function CargarDatosGenerar() As List(Of PLE_Venta)
        Dim loPLE As New List(Of PLE_Venta)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_VENTAS", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)
            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)
            'dgw1.DataSource = dsPDB.Tables(0)
            'loPDBVentas = PDBVenta_LISTAR()

            Dim I, J, x As Integer ', item, item1 As Integer
            Dim ObePle As PLE_Venta
            Dim dr As DataRow
            Dim pos As String
            Dim idx As Integer
            Dim base As Decimal
            Dim igv As Decimal
            Dim item, item1 As Integer
            item = 0
            item1 = 0
            For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                dr = dsPDB.Tables(0).Rows(I)
                ObePle = New PLE_Venta
                base = 0
                With ObePle
                    .Item = (I + 1).ToString("000000")
                    .Periodo = dr(0)
                    .Año = cbo_año.Text
                    .Mes = Obj.COD_MES(cbo_mes.Text)
                    .Emision = dr(1)
                    If dr(3) = "14" Then
                        .Vencimiento = dr(2)
                    Else
                        .Vencimiento = New Date(1900, 1, 1)
                    End If
                    .TipoComprobante = dr(3)
                    idx = dr(4).ToString.IndexOf("-")
                    If idx > 0 Then
                        '.SerieComprobante = Convert.ToInt32(dr(4).ToString.Substring(0, idx)).ToString("0000")
                        If (IsNumeric(dr(4).ToString.Substring(0, 1))) Then
                            .SerieComprobante = Convert.ToInt32(dr(4).ToString.Substring(0, idx)).ToString("0000")
                        Else
                            .SerieComprobante = dr(4).ToString.Substring(0, idx)
                        End If
                        .NroComprobante = dr(4).ToString.Substring(idx + 1)
                    Else
                        .NroComprobante = dr(4)
                        .SerieComprobante = "-"
                    End If
                    .TotalConsolidado = 0

                    If dr(3) <> "03" Then
                        If dr(5).ToString.Trim <> "-" Then
                            .TipoDocumento = Integer.Parse(dr(5))
                            .NroDocumento = dr(6)
                        Else
                            .TipoDocumento = "6"
                            .NroDocumento = RUC_EMPRESA
                        End If
                    ElseIf dr(3) = "03" Then
                        .TipoDocumento = "0"
                        .NroDocumento = "0" '-
                    End If
                    .RazonSocial = dr(7)

                    'If dr(3) <> "03" Then
                    '    If dr(5).ToString.Trim <> "-" Then
                    '        .TipoDocumento = Integer.Parse(dr(5))
                    '    Else
                    '        .TipoDocumento = "0"
                    '    End If
                    '    .NroDocumento = dr(6)
                    '    .RazonSocial = dr(7)
                    'End If
                    x = 0
                    Dim _BaseImponible As Boolean
                    _BaseImponible = False
                    Dim valor As Integer = 1
                    If dr(3) = "07" OrElse dr(3) = "87" OrElse dr(3) = "97" Then
                        valor = -1
                    End If
                    For J = 8 To 17
                        x += 1
                        If dr(J) > 0 Then
                            pos = Obj.DIR_TABLA_DESC(String.Format("V{0}", x.ToString("00")), "TPLE")
                            If pos = "BASE1" Then
                                .Base1 += dr(J) * valor
                            ElseIf pos = "EXPORTACION" Then
                                .Exportacion += dr(J) * valor
                            ElseIf pos = "EXONERADA" Then
                                .Exonerado += dr(J) * valor
                            ElseIf pos = "IGV" Then
                                .Igv1 += dr(J) * valor
                            ElseIf pos = "OTROS" Then
                                .MontoOtros += dr(J) * valor
                            End If
                        End If
                    Next
                    If (.TipoComprobante = "07") Then
                        '.BaseDes = .Base1
                        '.IgvDes = .Igv1
                        '.Base1 = 0.0
                        '.Igv1 = 0.0
                        If CInt(Year(dr(20)) & Month(dr(20)).ToString("00")) < CInt(.Año & .Mes) Then
                            .BaseDes = .Base1
                            .IgvDes = .Igv1
                            .Base1 = 0.0
                            .Igv1 = 0.0
                        Else
                            .BaseDes = 0.0
                            .IgvDes = 0.0
                            .Base1 = .Base1
                            .Igv1 = .Igv1
                        End If

                    End If
                    '--
                    .ImporteComprobante = .Exportacion + .Base1 + .Exonerado + .Inafecto + .MontoISC + .Igv1 + .Base2 + .Igv2 + .MontoOtros + .BaseDes + .IgvDes
                    '--

                    '--
                    If dr(3) = "03" Or dr(3) = "12" And .ImporteComprobante < 700 Then
                        If dr(6).ToString.Trim <> "" Then
                            .TipoDocumento = Integer.Parse(dr(5))
                            .NroDocumento = dr(6)
                        Else
                            .TipoDocumento = ""
                            .NroDocumento = ""
                        End If
                    ElseIf dr(3) = "03" Or dr(3) = "12" And .ImporteComprobante > 700 Then
                        '-- validamos la persona y el codigo doc
                        If dr(3) <> "01" And (dr(5).ToString.Trim = "-" Or dr(5).ToString.Trim = "00") And dr(6).ToString.Trim = "" Then
                            MessageBox.Show("Verifique el tipo de  persona de " & .RazonSocial & vbCrLf & "Nro Documento: " & dr(6), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            loPLE.Clear()
                            Return loPLE
                        End If
                        .TipoDocumento = Integer.Parse(dr(5))
                        .NroDocumento = dr(6)
                    End If
                    '---
                    .TipoCambio = dr(19)

                    If (dr(3) = "07" OrElse dr(3) = "08" OrElse dr(3) = "87" OrElse dr(3) = "88") Then
                        .TipoComprobanteRef = dr(21)
                        idx = dr(22).ToString.IndexOf("-")
                        If idx > 0 Then
                            '.SerieComprobanteRef = Convert.ToInt32(dr(22).ToString.Substring(0, idx)).ToString("0000")
                            If (IsNumeric(dr(22).ToString.Substring(0, 1))) Then
                                .SerieComprobanteRef = Convert.ToInt32(dr(22).ToString.Substring(0, idx)).ToString("0000")
                            Else
                                .SerieComprobanteRef = dr(22).ToString.Substring(0, idx)
                            End If
                            .NroComprobanteRef = dr(22).ToString.Substring(idx + 1)
                            .EmisionRef = dr(20)
                        Else
                            .TipoComprobanteRef = "00"
                            .SerieComprobanteRef = "-"
                            .NroComprobanteRef = "-"
                            .EmisionRef = New Date(1900, 1, 1)
                        End If
                    Else
                        .TipoComprobanteRef = "00"
                        .SerieComprobanteRef = "-"
                        .NroComprobanteRef = "-"
                        .EmisionRef = New Date(1900, 1, 1)
                    End If
                    Dim dif As Integer = DateDiff(DateInterval.Month, .Emision, New Date(cbo_año.Text, cbo_mes.SelectedIndex + 1, 1))

                    If .RazonSocial.Trim = "ANULADO" Then
                        .Anotacion = 2
                        '
                        .TipoDocumento = ""
                    ElseIf dif = 0 Then
                        .Anotacion = 1
                        'Validación  'dr(3) = "03" Or
                        'If dr(3) = "12" Then
                        '    .Anotacion = 0
                        'End If
                    ElseIf dif <= 12 Then
                        .Anotacion = 8
                    Else


                        .Anotacion = 9
                    End If
                    .AuxiliarOrigen = dr(25)
                    .ComprobanteOrigen = dr(26)
                    .NumeroComprobanteOrigen = dr(27)
                    'agregado 
                    .CodigoMoneda = dr(28)
                    .IndicadorComprobante = IIf(dr(29) Is DBNull.Value, "", "1")
                End With
                loPLE.Add(ObePle)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al generar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            loPLE.Clear()
        End Try
        Return loPLE
    End Function

    Private Sub GenerarPleVentas()
        Dim trx As SqlTransaction = Nothing
        Dim loPle As List(Of PLE_Venta) = CargarDatosGenerar()
        If loPle.Count > 0 Then
            Try
                con.Open()
                trx = con.BeginTransaction
                Dim i As Integer
                For i = 0 To loPle.Count - 1
                    With loPle(i)
                        Dim cmd As New SqlCommand("INSERTAR_PLE_VENTAS", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ITEM", .Item)
                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                        cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                        cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                        cmd.Parameters.AddWithValue("@FECHA_EMI", .Emision)
                        cmd.Parameters.AddWithValue("@FECHA_VEN", .Vencimiento)
                        cmd.Parameters.AddWithValue("@TIPO_COMP", .TipoComprobante)
                        cmd.Parameters.AddWithValue("@SERIE_COMP", .SerieComprobante)
                        cmd.Parameters.AddWithValue("@NRO_COMP", .NroComprobante)
                        cmd.Parameters.AddWithValue("@TOTAL_CONSOL", .TotalConsolidado)
                        cmd.Parameters.AddWithValue("@TIPO_DOC_CLI", .TipoDocumento)
                        cmd.Parameters.AddWithValue("@NRO_DOC_CLI", .NroDocumento)
                        cmd.Parameters.AddWithValue("@DESC_CLI", .RazonSocial)
                        cmd.Parameters.AddWithValue("@TOTAL_EXPORT", .Exportacion)
                        cmd.Parameters.AddWithValue("@BASE_IMP1", .Base1)
                        cmd.Parameters.AddWithValue("@TOTAL_EXO", .Exonerado)
                        cmd.Parameters.AddWithValue("@TOTAL_INAFECTO", .Inafecto)
                        cmd.Parameters.AddWithValue("@MONTO_ISC", .MontoISC)
                        cmd.Parameters.AddWithValue("@IGV1", .Igv1)
                        cmd.Parameters.AddWithValue("@BASE_IMP2", .Base2)
                        cmd.Parameters.AddWithValue("@IGV2", .Igv2)
                        cmd.Parameters.AddWithValue("@MONTO_OTROS", .MontoOtros)
                        cmd.Parameters.AddWithValue("@IMPORTE_COMP", .ImporteComprobante)
                        cmd.Parameters.AddWithValue("@TIPO_CAMBIO", .TipoCambio)
                        cmd.Parameters.AddWithValue("@FECHA_EMI_REF", .EmisionRef)
                        cmd.Parameters.AddWithValue("@TIPO_COMP_REF", .TipoComprobanteRef)
                        cmd.Parameters.AddWithValue("@SERIE_COMP_REF", .SerieComprobanteRef)
                        cmd.Parameters.AddWithValue("@NRO_COMP_REF", .NroComprobanteRef)
                        cmd.Parameters.AddWithValue("@ANOTACION", .Anotacion)
                        cmd.Parameters.AddWithValue("@COD_AUX_ORIG", .AuxiliarOrigen)
                        cmd.Parameters.AddWithValue("@COD_COMP_ORIG", .ComprobanteOrigen)
                        cmd.Parameters.AddWithValue("@NRO_COMP_ORIG", .NumeroComprobanteOrigen)
                        'add
                        cmd.Parameters.AddWithValue("@CODIGO_MONEDA", .CodigoMoneda)
                        cmd.Parameters.AddWithValue("@INDICADOR_COMPROBANTE", .IndicadorComprobante)
                        cmd.Parameters.AddWithValue("@BASE_DES", .BaseDes)
                        cmd.Parameters.AddWithValue("@IGV_DES", .IgvDes)
                        cmd.CommandTimeout = 720
                        cmd.ExecuteNonQuery()
                    End With
                Next
                MessageBox.Show("Datos generados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                trx.Commit()
            Catch ex As Exception
                MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                trx.Rollback()
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_año_sunat.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CBO_DOCUMENTO()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboComprobante.Items.Add(Rs3.GetString(0))
                cboComprobanteRef.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub

    Sub CBO_TIPO_DOC()
        cboTipoDocumento.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_TIPO_DOC_PERSONAL", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboTipoDocumento.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
#Region "Resumen Ventas-Diarios"

    Private Function CargarDatosGenerarResumen() As List(Of PLE_Venta)
        Dim loPLE As New List(Of PLE_Venta)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_VENTAS_RESUMEN", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@DIA", SqlDbType.Int)
            par0.Value = dtpRegistroDiario.Value.Year
            par1.Value = dtpRegistroDiario.Value.Month.ToString("00")
            par2.Value = dtpRegistroDiario.Value.Day

            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)
            'dgw1.DataSource = dsPDB.Tables(0)
            'loPDBVentas = PDBVenta_LISTAR()

            Dim I, J, x As Integer ', item, item1 As Integer
            Dim ObePle As PLE_Venta
            Dim dr As DataRow
            Dim pos As String
            Dim idx As Integer
            Dim base As Decimal
            Dim igv As Decimal
            Dim item, item1 As Integer
            item = 0
            item1 = 0
            For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                dr = dsPDB.Tables(0).Rows(I)
                ObePle = New PLE_Venta
                base = 0
                With ObePle
                    .Item = (I + 1).ToString("000000")
                    .Periodo = dr(0)
                    .Año = cbo_año.Text
                    .Mes = Obj.COD_MES(cbo_mes.Text)
                    .Emision = dr(1)
                    If dr(3) = "14" Then
                        .Vencimiento = dr(2)
                    Else
                        .Vencimiento = New Date(1900, 1, 1)
                    End If
                    .TipoComprobante = dr(3)
                    idx = dr(4).ToString.IndexOf("-")
                    If idx > 0 Then
                        .SerieComprobante = Convert.ToInt32(dr(4).ToString.Substring(0, idx)).ToString("0000")
                        .NroComprobante = dr(4).ToString.Substring(idx + 1)
                    Else
                        .NroComprobante = dr(4)
                        .SerieComprobante = "-"
                    End If
                    .TotalConsolidado = 0

                    If dr(3) <> "03" Then
                        If dr(5).ToString.Trim <> "-" Then
                            .TipoDocumento = Integer.Parse(dr(5))
                            .NroDocumento = dr(6)
                        Else
                            .TipoDocumento = "6"
                            .NroDocumento = RUC_EMPRESA
                        End If
                    ElseIf dr(3) = "03" Then
                        .TipoDocumento = "0"
                        .NroDocumento = "0" '-
                    End If
                    .RazonSocial = dr(7)

                    'If dr(3) <> "03" Then
                    '    If dr(5).ToString.Trim <> "-" Then
                    '        .TipoDocumento = Integer.Parse(dr(5))
                    '    Else
                    '        .TipoDocumento = "0"
                    '    End If
                    '    .NroDocumento = dr(6)
                    '    .RazonSocial = dr(7)
                    'End If
                    x = 0
                    Dim _BaseImponible As Boolean
                    _BaseImponible = False
                    Dim valor As Integer = 1
                    If dr(3) = "07" OrElse dr(3) = "87" OrElse dr(3) = "97" Then
                        valor = -1
                    End If
                    For J = 8 To 17
                        x += 1
                        If dr(J) > 0 Then
                            pos = Obj.DIR_TABLA_DESC(String.Format("V{0}", x.ToString("00")), "TPLE")
                            If pos = "BASE1" Then
                                .Base1 += dr(J) * valor
                            ElseIf pos = "EXPORTACION" Then
                                .Exportacion += dr(J) * valor
                            ElseIf pos = "EXONERADA" Then
                                .Exonerado += dr(J) * valor
                            ElseIf pos = "IGV" Then
                                .Igv1 += dr(J) * valor
                            ElseIf pos = "OTROS" Then
                                .MontoOtros += dr(J) * valor
                            End If
                        End If
                    Next
                    If (.TipoComprobante = "07") Then
                        '.BaseDes = .Base1
                        '.IgvDes = .Igv1
                        '.Base1 = 0.0
                        '.Igv1 = 0.0
                        If CInt(Year(dr(20)) & Month(dr(20)).ToString("00")) < CInt(.Año & .Mes) Then
                            .BaseDes = .Base1
                            .IgvDes = .Igv1
                            .Base1 = 0.0
                            .Igv1 = 0.0
                        Else
                            .BaseDes = 0.0
                            .IgvDes = 0.0
                            .Base1 = .Base1
                            .Igv1 = .Igv1
                        End If

                    End If
                    '--
                    .ImporteComprobante = .Exportacion + .Base1 + .Exonerado + .Inafecto + .MontoISC + .Igv1 + .Base2 + .Igv2 + .MontoOtros + .BaseDes + .IgvDes
                    '--

                    '--
                    If dr(3) = "03" And .ImporteComprobante < 700 Then
                        .TipoDocumento = ""
                        .NroDocumento = ""
                    ElseIf dr(3) = "03" And .ImporteComprobante > 700 Then
                        '-- validamos la persona y el codigo doc
                        If dr(3) <> "01" And dr(5).ToString.Trim = "-" Then
                            MessageBox.Show("Verifique el tipo de  persona de " & .RazonSocial & vbCrLf & "Nro Documento: " & dr(6), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            loPLE.Clear()
                            Return loPLE
                        End If
                        .TipoDocumento = Integer.Parse(dr(5))
                        .NroDocumento = dr(6)
                    End If
                    '---
                    .TipoCambio = dr(19)

                    If (dr(3) = "07" OrElse dr(3) = "08" OrElse dr(3) = "87" OrElse dr(3) = "88") Then
                        .TipoComprobanteRef = dr(21)
                        idx = dr(22).ToString.IndexOf("-")
                        If idx > 0 Then
                            .SerieComprobanteRef = Convert.ToInt32(dr(22).ToString.Substring(0, idx)).ToString("0000")
                            .NroComprobanteRef = dr(22).ToString.Substring(idx + 1)
                            .EmisionRef = dr(20)
                        Else
                            .TipoComprobanteRef = "-" '00
                            .SerieComprobanteRef = "-"
                            .NroComprobanteRef = "-"
                            .EmisionRef = New Date(1900, 1, 1)
                        End If
                    Else
                        .TipoComprobanteRef = "-" '00
                        .SerieComprobanteRef = "-"
                        .NroComprobanteRef = "-"
                        .EmisionRef = New Date(1900, 1, 1)
                    End If
                    Dim dif As Integer = DateDiff(DateInterval.Month, .Emision, New Date(dtpRegistroDiario.Value.Year, dtpRegistroDiario.Value.Month, 1)) 'New Date(cbo_año.Text, cbo_mes.SelectedIndex + 1, 1)

                    If .RazonSocial.Trim = "ANULADO" Then
                        .Anotacion = 2
                        '
                        .TipoDocumento = ""
                    ElseIf dif = 0 Then
                        .Anotacion = 1
                    ElseIf dif <= 12 Then
                        .Anotacion = 8
                    Else
                        .Anotacion = 9
                    End If
                    .AuxiliarOrigen = dr(25)
                    .ComprobanteOrigen = dr(26)
                    .NumeroComprobanteOrigen = dr(27)
                    'agregado 
                    .CodigoMoneda = dr(28)
                    .IndicadorComprobante = IIf(dr(29) Is DBNull.Value, "", "1")
                End With
                loPLE.Add(ObePle)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al generar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            loPLE.Clear()
        End Try
        Return loPLE
    End Function

    Private Sub CargarVentasDiarias()

    End Sub

#End Region

    Private Sub LIMPIAR(ByVal Contenedor As Object)
        Dim x As Control
        For Each x In Contenedor.Controls
            If TypeOf x Is TextBox Then CType(x, TextBox).Clear()
            If TypeOf x Is ListBox Or TypeOf x Is ComboBox Then CType(x, ListControl).SelectedIndex = -1
            If TypeOf x Is CheckBox Then CType(x, CheckBox).Checked = False
        Next
    End Sub

    Private Function BUSCAR_ITEM(ByVal OPDB As PLE_Venta) As Boolean
        Return OPDB.Item = Item
    End Function

    Private Sub CARGAR_DETALLES()
        With loPleVentas(Idx)
            If .TipoDocumento = "0" Then
                cboTipoDocumento.SelectedIndex = 1
            ElseIf .TipoDocumento = "1" Then
                cboTipoDocumento.SelectedIndex = 2
            ElseIf .TipoDocumento = "6" Then
                cboTipoDocumento.SelectedIndex = 3
            End If

            txtNroDocumento.Text = .NroDocumento
            txtRazonSocial.Text = .RazonSocial
            cboComprobante.Text = Obj.DESC_DOC(.TipoComprobante)
            txtSerie.Text = .SerieComprobante

            txtNroComprobante.Text = .NroComprobante
            dtpFechaEmision.Value = .Emision
            dtpVencimiento.Value = IIf(.Vencimiento.CompareTo(New Date(1, 1, 1)) = 0, New Date(1900, 1, 1), .Vencimiento)
            txtConsolidado.Text = Obj.HACER_DECIMAL(.TotalConsolidado)
            txtExportacion.Text = Obj.HACER_DECIMAL(.Exportacion)
            txtGravada.Text = Obj.HACER_DECIMAL(.Base1)
            txtExonerada.Text = Obj.HACER_DECIMAL(.Exonerado)
            txtInafecta.Text = Obj.HACER_DECIMAL(.Inafecto)
            txtIsc.Text = Obj.HACER_DECIMAL(.MontoISC)
            txtIgv1.Text = Obj.HACER_DECIMAL(.Igv1)
            txtBaseOtras.Text = Obj.HACER_DECIMAL(.Base2)
            txtIgvOtras.Text = Obj.HACER_DECIMAL(.Igv2)
            txtOtros.Text = Obj.HACER_DECIMAL(.MontoOtros)
            txtTotalComprobante.Text = .ImporteComprobante
            txtTipoCambio.Text = Obj.HACER_CAMBIO(.TipoCambio)
            cboComprobanteRef.Text = Obj.DESC_DOC(.TipoComprobanteRef)
            txtSerieRef.Text = .SerieComprobanteRef
            txtNroComprobanteRef.Text = .NroComprobanteRef
            dtpFechaEmisionRef.Value = IIf(.EmisionRef.CompareTo(New Date(1, 1, 1)) = 0, New Date(1900, 1, 1), .EmisionRef)
            txtAnotacion.Text = .Anotacion
        End With
    End Sub

    Private Sub frmPleVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPleVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabPage2.Parent = Nothing
        KeyPreview = True
        CARGAR_AÑO()
        CBO_DOCUMENTO()
        CBO_TIPO_DOC()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub

    Private Sub Consultar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cbo_mes.Focus() : Exit Sub

        dgvDatos.Rows.Clear()
        ConsultarPle()
        If loPleVentas.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("No existen registros del Libro Electrónico - Ventas. ¿Desea generarlos?", "Aviso", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarPleVentas()
                ConsultarPle()
            End If
        End If
        Dim i As Integer
        For i = 0 To loPleVentas.Count - 1
            With loPleVentas.Item(i)
                dgvDatos.Rows.Add(i + 1, .Item, .Periodo, .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), .TipoComprobante, _
                .SerieComprobante, .NroComprobante, .TotalConsolidado, .TipoDocumento, .NroDocumento, .RazonSocial, .Exportacion, .Base1, _
                .Exonerado, .Inafecto, .MontoISC, .Igv1, .Base2, .Igv2, .MontoOtros, .BaseDes, .IgvDes, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), _
                .TipoComprobanteRef, .SerieComprobanteRef, .NroComprobanteRef, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen, _
                .CodigoMoneda, .IndicadorComprobante)
            End With
        Next
    End Sub

    Private Sub Modificar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        TabPage2.Parent = TabControl1
        TabControl1.SelectedTab = TabPage2
        _fila = dgvDatos.CurrentRow.Index
        Item = dgvDatos.Item(1, dgvDatos.CurrentRow.Index).Value
        Dim pred As New Predicate(Of PLE_Venta)(AddressOf BUSCAR_ITEM)
        Idx = loPleVentas.FindIndex(pred)
        If Idx > -1 Then
            'LIMPIAR(gbPersona)
            LIMPIAR(gbComprobante)
            LIMPIAR(gbReferencia)
            CARGAR_DETALLES()
        Else
            MessageBox.Show("No se cargaron los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Cancelar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabPage2.Parent = Nothing
        TabControl1.SelectedTab = TabPage1
        dgvDatos.CurrentCell = dgvDatos.Rows.Item(_fila).Cells.Item(0)
    End Sub

    Private Sub CambiarFicha(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            'LIMPIAR(gbPersona)
            LIMPIAR(gbComprobante)
            LIMPIAR(gbReferencia)
            TabPage2.Parent = Nothing
        End If
    End Sub

    Private Sub Grabar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim opleVentas As PLE_Venta = loPleVentas(Idx)
        If cboTipoDocumento.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el tipo de documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        With opleVentas
            .TipoComprobante = Obj.COD_DOC(cboComprobante.Text)
            .SerieComprobante = txtSerie.Text
            .NroComprobante = txtNroComprobante.Text
            .TotalConsolidado = txtConsolidado.Text
            .Exportacion = txtExportacion.Text
            .Base1 = txtGravada.Text
            .Exonerado = txtExonerada.Text
            .Inafecto = txtInafecta.Text
            .MontoISC = txtIsc.Text
            .Igv1 = txtIgv1.Text
            .Base2 = txtBaseOtras.Text
            .Igv2 = txtIgvOtras.Text
            .MontoOtros = txtOtros.Text
            .ImporteComprobante = txtTotalComprobante.Text
            .Anotacion = txtAnotacion.Text
            .RazonSocial = txtRazonSocial.Text
            Try
                con.Open()
                Dim cmd As New SqlCommand("ACTUALIZAR_PLE_VentaS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ITEM", .Item)
                cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                cmd.Parameters.AddWithValue("@TIPO_COMP", .TipoComprobante)
                cmd.Parameters.AddWithValue("@SERIE_COMP", .SerieComprobante)
                cmd.Parameters.AddWithValue("@NRO_COMP", .NroComprobante)
                cmd.Parameters.AddWithValue("@TOTAL_CONSOL", .TotalConsolidado)
                cmd.Parameters.AddWithValue("@TOTAL_EXPORT", .Exportacion)
                cmd.Parameters.AddWithValue("@BASE_IMP1", .Base1)
                cmd.Parameters.AddWithValue("@TOTAL_EXO", .Exonerado)
                cmd.Parameters.AddWithValue("@TOTAL_INAFECTO", .Inafecto)
                cmd.Parameters.AddWithValue("@MONTO_ISC", .MontoISC)
                cmd.Parameters.AddWithValue("@IGV1", .Igv1)
                cmd.Parameters.AddWithValue("@BASE_IMP2", .Base2)
                cmd.Parameters.AddWithValue("@IGV2", .Igv2)
                cmd.Parameters.AddWithValue("@MONTO_OTROS", .MontoOtros)
                cmd.Parameters.AddWithValue("@IMPORTE_COMP", .ImporteComprobante)
                cmd.Parameters.AddWithValue("@ANOTACION", .Anotacion)
                cmd.Parameters.AddWithValue("@RAZON_SOCIAL", .RazonSocial)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Datos actualizados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End With
        Consultar(sender, e)
        Cancelar(Nothing, Nothing)
    End Sub

    Private Sub Exportar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}00140100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    'sw.WriteLine("Tipo Venta|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPleVentas.Count - 1
                        With loPleVentas(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}| " & _
                            '"{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|", _
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                            '.TipoComprobante, .SerieComprobante, .NroComprobante, .TotalConsolidado, .TipoDocumento, .NroDocumento, _
                            '.RazonSocial, .Exportacion, .Base1, .Exonerado, .Inafecto, .MontoISC, .Igv1, .Base2, .Igv2, .MontoOtros, _
                            '.ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, .SerieComprobanteRef, _
                            '.NroComprobanteRef, "0.00", .Anotacion))
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|" & _
                        "{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|", _
                        .Periodo, _
                        .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, _
                        "M" & IIf(.Anotacion = 9, "", aux), _
                        .Emision.ToShortDateString(), _
                        .Vencimiento.ToShortDateString(), _
                        .TipoComprobante, _
                        .SerieComprobante, _
                        .NroComprobante, _
                        "", _
                        .TipoDocumento, _
                        .NroDocumento, _
                        .RazonSocial, _
                        .Exportacion, _
                        .Base1, _
                        .BaseDes, _
                        .Igv1, _
                        .IgvDes, _
                        .Exonerado, _
                        .Inafecto, _
                        .MontoISC, _
                        .Base2, _
                        .Igv2, _
                        .MontoOtros, _
                        .ImporteComprobante, _
                        .CodigoMoneda, _
                        .TipoCambio, _
                        .EmisionRef.ToShortDateString(), _
                        .TipoComprobanteRef, _
                        .SerieComprobanteRef, _
                        .NroComprobanteRef, _
                        "", _
                        "", _
                        .IndicadorComprobante.Trim(), _
                        .Anotacion))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub Eliminar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim rpta As DialogResult = MessageBox.Show(String.Format("¿Desea eliminar los registros del Libro Electrónico para el periodo {0}-{1}?", _
                cbo_mes.Text, cbo_año.Text), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If rpta = Windows.Forms.DialogResult.Yes Then
                con.Open()
                Dim cmd As New SqlCommand("ELIMINAR_PLE_VENTAS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Obj.COD_MES(cbo_mes.Text)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Registro eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar un registro.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            con.Close()
        End Try
        Consultar(Nothing, Nothing)
    End Sub

    Private Sub Salir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub MontoDecimal(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsolidado.LostFocus, txtExportacion.LostFocus, _
        txtGravada.LostFocus, txtExonerada.LostFocus, txtInafecta.LostFocus, txtIsc.LostFocus, txtIgv1.LostFocus, txtBaseOtras.LostFocus, _
        txtIgvOtras.LostFocus, txtOtros.LostFocus, txtTotalComprobante.LostFocus
        Try
            CType(sender, TextBox).Text = Obj.HACER_DECIMAL(CType(sender, TextBox).Text)
        Catch ex As Exception
            CType(sender, TextBox).Text = "0.00"
        End Try
    End Sub

    Private Sub txtTipoCambio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoCambio.LostFocus
        Try
            CType(sender, TextBox).Text = Obj.HACER_CAMBIO(CType(sender, TextBox).Text)
        Catch ex As Exception
            CType(sender, TextBox).Text = "0.000"
        End Try
    End Sub

    Private Sub btn_salir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir2.Click
        Close()
    End Sub

    Private Sub btn_consultar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        dgvDatos_sunat.Rows.Clear()
        ConsultarPle_Anual()
        Dim i As Integer
        For i = 0 To loPleVentas.Count - 1
            With loPleVentas.Item(i)
                dgvDatos_sunat.Rows.Add(i + 1, .Item, .Periodo, .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), .TipoComprobante, _
                .SerieComprobante, .NroComprobante, .TotalConsolidado, .TipoDocumento, .NroDocumento, .RazonSocial, .Exportacion, .Base1, _
                .Exonerado, .Inafecto, .MontoISC, .Igv1, .Base2, .Igv2, .MontoOtros, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), _
                .TipoComprobanteRef, .SerieComprobanteRef, .NroComprobanteRef, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen)
            End With
        Next
    End Sub

    Private Sub btn_exportar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        ConsultarPle_Anual()
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}00140100001111.txt", RUC_EMPRESA, cbo_año_sunat.Text, Obj.COD_MES(cbomes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    sw.WriteLine(String.Format("VPERIODO|VNUMREGOPE|VFECCOM|VFECVENPAG|VTIPDOCCOM|VNUMSER|VNUMDOCCOI|VNUMDOCCOF|" & _
                    "VTIPDIDCLI|VNUMDIDCLI|VAPENOMRSO|VVALFACEXP|VBASIMPGRA|VIMPTOTEXTO|VIMPTOTINA|VISC|VIGVIPM|VBASIMVAP|VIVAP|" & _
                    "VOTRTRICGO|VIMPTOTCOM|VTIPCAM|VFECCOMMOD|VTIPCCOMMOD|VNUMSERMOD|VNUMCOMMOD|VESTOPE|VINTDIAMAY|VINTKARDEX|VINTREG|"))
                    'sw.WriteLine("Tipo Venta|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPleVentas.Count - 1
                        With loPleVentas(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}| " & _
                            "{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|", _
                            .Periodo, IIf(.Anotacion = 9, "", aux), .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                            .TipoComprobante, .SerieComprobante, .NroComprobante, .TotalConsolidado, .TipoDocumento, .NroDocumento, _
                            .RazonSocial, .Exportacion, .Base1, .Exonerado, .Inafecto, .MontoISC, .Igv1, .Base2, .Igv2, .MontoOtros, _
                            .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, .SerieComprobanteRef, _
                            .NroComprobanteRef, .Anotacion, .AuxiliarOrigen & "-" & .ComprobanteOrigen & "-" & .NumeroComprobanteOrigen, " ", .AuxiliarOrigen & "-" & .ComprobanteOrigen & "-" & .NumeroComprobanteOrigen))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btnRegistroDiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistroDiario.Click
        If FECHA_GRAL.Year <> dtpRegistroDiario.Value.Year Or FECHA_GRAL.Month <> dtpRegistroDiario.Value.Month Then
            MessageBox.Show("No puede hacer una consulta fuera de la fecha de proceso", "Registro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        dgvRegistroDiario.Rows.Clear()
        loPleVentas = CargarDatosGenerarResumen()
        Dim i As Integer
        If loPleVentas.Count = 0 Then
            MsgBox("No hay registros que mostrar")
        End If
        For i = 0 To loPleVentas.Count - 1
            With loPleVentas.Item(i)
                dgvRegistroDiario.Rows.Add(i + 1, .Item, .Periodo, .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), .TipoComprobante, _
                .SerieComprobante, .NroComprobante, .TotalConsolidado, .TipoDocumento, .NroDocumento, .RazonSocial, .Exportacion, .Base1, _
                .Exonerado, .Inafecto, .MontoISC, .Igv1, .Base2, .Igv2, .MontoOtros, .BaseDes, .IgvDes, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), _
                .TipoComprobanteRef, .SerieComprobanteRef, .NroComprobanteRef, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen, _
                .CodigoMoneda, .IndicadorComprobante)
            End With
        Next
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Dim Archivo As String = String.Format("LE{0}{1}{2}00140100001111.txt", RUC_EMPRESA, dtpRegistroDiario.Value.Year.ToString, dtpRegistroDiario.Value.Month.ToString("00"))
            Dim Archivo As String = String.Format("{0}{1}{2}{3}.txt", RUC_EMPRESA, "-RF-", dtpRegistroDiario.Value.Day.ToString("00") & dtpRegistroDiario.Value.Month.ToString("00") & dtpRegistroDiario.Value.Year.ToString, "-01")
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    'sw.WriteLine("Tipo Venta|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPleVentas.Count - 1
                        With loPleVentas(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}| " & _
                            '"{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|", _
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                            '.TipoComprobante, .SerieComprobante, .NroComprobante, .TotalConsolidado, .TipoDocumento, .NroDocumento, _
                            '.RazonSocial, .Exportacion, .Base1, .Exonerado, .Inafecto, .MontoISC, .Igv1, .Base2, .Igv2, .MontoOtros, _
                            '.ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, .SerieComprobanteRef, _
                            '.NroComprobanteRef, "0.00", .Anotacion))
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|" & _
                        "{15}|{16}|{17}|{18}|", _
                        "7", _
                        .Emision.ToShortDateString(), _
                        .TipoComprobante, _
                        .SerieComprobante, _
                        .NroComprobante, _
                        "", _
                        .TipoDocumento, _
                        .NroDocumento, _
                        .RazonSocial, _
                        .Base1, _
                        .Exonerado, _
                        .Exportacion, _
                        .Base2, _
                        .Igv1, _
                        .MontoOtros, _
                        .ImporteComprobante, _
                        .TipoComprobanteRef, _
                        .SerieComprobanteRef, _
                        .NroComprobanteRef))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class