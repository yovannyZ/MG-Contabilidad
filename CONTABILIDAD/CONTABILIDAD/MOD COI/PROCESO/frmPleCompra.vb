Imports System.Data.SqlClient
Imports System.IO

Public Class frmPleCompra
    Private Obj As New Class1
    Private Config As String
    Private loPleCompras As New List(Of PLE_Compra)
    Private Item As Integer
    Private Idx As Integer
    Private _fila As Integer
    Private _consultar As Boolean
    Private loPleComprasNoDomiciliadas As New List(Of PleCompraNoDomiciliado)

#Region "Constructor"
    Private Shared instancia As frmPleCompra
    Public Shared Function ObtenerInstancia() As frmPleCompra
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmPleCompra
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

    Public Structure PLE_Compra
        Public Item As String
        Public Periodo As Integer
        Public Año As String
        Public Mes As String
        Public Emision As Date
        Public Vencimiento As Date
        Public TipoComprobante As String
        Public SerieComprobante As String
        Public AñoEmision As Integer
        Public NroComprobante As String
        Public TotalConsolidado As Integer
        Public TipoDocumento As String
        Public NroDocumento As String
        Public RazonSocial As String
        Public Base1 As Decimal
        Public Igv1 As Decimal
        Public Base2 As Decimal
        Public Igv2 As Decimal
        Public Base3 As Decimal
        Public Igv3 As Decimal
        Public NoGravadas As Decimal
        Public MontoISC As Decimal
        Public MontoOtros As Decimal
        Public ImporteComprobante As Decimal
        Public TipoCambio As Decimal
        Public EmisionRef As Date
        Public TipoComprobanteRef As String
        Public SerieComprobanteRef As String
        Public NroComprobanteRef As String
        Public NroComprobanteExt As String
        Public EmisionDet As Date
        Public NumeroDet As String
        Public IndicadorRet As String
        Public ComprobanteRet As String
        Public Anotacion As String
        Public AuxiliarOrigen As String
        Public ComprobanteOrigen As String
        Public NumeroComprobanteOrigen As String
        '
        Public CodigoMoneda As String
        Public IndicadorComprobante As String
        Public CodigoBienes As String
    End Structure

    Public Structure PleCompraNoDomiciliado
        Public Item As String
        Public Periodo As String
        Public Año As String
        Public Mes As String
        Public FechaEmision As Date
        Public TipoComprobante As String
        Public SerieComprobante As String
        Public NumeroComprobante As String
        Public ValorAdquirido As Decimal
        Public ValorOtros As Decimal
        Public TotalAdquirido As Decimal
        Public CodigoMoneda As String
        Public TipoCambio As String
        Public CodigoPais As String
        Public NombreSujeto As String
        Public DireccionSujeto As String
        Public NumeroDocumentoSujeto As String
        Public CodigoDobleImposicion As String
        Public Anotacion As String
        Public CodigoAuxiliarOrigen As String
        Public CodigoComprobanteOrigen As String
        Public NumeroComprobanteOrigen As String

        'Public ConveniosDobleImposicion As String
        Public TipoRenta As String
    End Structure

    Private Sub ConsultarPle_Anual()
        Try
            loPleCompras.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_COMPRAS_ANUAL", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@FE_MES1", SqlDbType.Char)
            'par0.Value = cbo_año.Text
            par0.Value = cbo_año_sunat.Text : par1.Value = Obj.COD_MES(cbomes.Text) : par2.Value = Obj.COD_MES(cbomes1.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Compra
                While drd.Read
                    ObePla = New PLE_Compra
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
                        .AñoEmision = drd(8)
                        .NroComprobante = drd(9)
                        .TotalConsolidado = drd(10)
                        .TipoDocumento = drd(11)
                        If drd(11) = "0" Then .NroDocumento = "-" Else .NroDocumento = drd(12)
                        .RazonSocial = drd(13)
                        .Base1 = drd(14)
                        .Igv1 = drd(15)
                        .Base2 = drd(16)
                        .Igv2 = drd(17)
                        .Base3 = drd(18)
                        .Igv3 = drd(19)
                        .NoGravadas = drd(20)
                        .MontoISC = drd(21)
                        .MontoOtros = drd(22)
                        .ImporteComprobante = drd(23)
                        .TipoCambio = drd(24)
                        .EmisionRef = IIf(CDate(drd(25)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(25)).ToShortDateString)
                        .TipoComprobanteRef = drd(26)
                        .SerieComprobanteRef = drd(27)
                        .NroComprobanteRef = drd(28)
                        .NroComprobanteExt = drd(29)
                        .EmisionDet = IIf(CDate(drd(30)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(30)).ToShortDateString)
                        .NumeroDet = drd(31)
                        .IndicadorRet = drd(32)
                        .Anotacion = drd(33)
                        .AuxiliarOrigen = drd(34)
                        .ComprobanteOrigen = drd(35)
                        .NumeroComprobanteOrigen = drd(36)
                    End With
                    loPleCompras.Add(ObePla)
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
            loPleCompras.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_COMPRAS", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Compra
                While drd.Read
                    ObePla = New PLE_Compra
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
                        .AñoEmision = drd(8)
                        .NroComprobante = drd(9)
                        .TotalConsolidado = drd(10)
                        .TipoDocumento = drd(11)
                        .NroDocumento = drd(12) 'If drd(11) = "0" Then .NroDocumento = "-" Else .NroDocumento = drd(12)
                        .RazonSocial = drd(13)
                        .Base1 = drd(14)
                        .Igv1 = drd(15)
                        .Base2 = drd(16)
                        .Igv2 = drd(17)
                        .Base3 = drd(18)
                        .Igv3 = drd(19)
                        .NoGravadas = drd(20)
                        .MontoISC = drd(21)
                        .MontoOtros = drd(22)
                        .ImporteComprobante = drd(23)
                        .TipoCambio = drd(24)
                        .EmisionRef = IIf(CDate(drd(25)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(25)).ToShortDateString)
                        .TipoComprobanteRef = drd(26)
                        .SerieComprobanteRef = drd(27)
                        .NroComprobanteRef = drd(28)
                        .NroComprobanteExt = drd(29)
                        .EmisionDet = IIf(CDate(drd(30)).CompareTo(New Date(1900, 1, 1)) = 0, New Date(1, 1, 1), CDate(drd(30)).ToShortDateString)
                        .NumeroDet = drd(31)
                        .IndicadorRet = drd(32)
                        .Anotacion = drd(33)
                        .AuxiliarOrigen = drd(34)
                        .ComprobanteOrigen = drd(35)
                        .NumeroComprobanteOrigen = drd(36)
                        .CodigoMoneda = drd(37)
                        .IndicadorComprobante = drd(38)
                        .CodigoBienes = drd(39)
                    End With
                    loPleCompras.Add(ObePla)
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

    Private Function CargarDatosGenerar(ByVal añoProceso As String, ByVal mesProceso As String) As List(Of PLE_Compra)
        Dim loPLE As New List(Of PLE_Compra)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_COMPRAS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = añoProceso
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesProceso
            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)
            'dgw1.DataSource = dsPDB.Tables(0)
            'loPDBCompras = PDBCOMPRA_LISTAR()

            Dim I, J, x, item As Integer ', item1 As Integer
            Dim ObePle As PLE_Compra
            Dim dr As DataRow
            Dim pos As String
            Dim idx As Integer
            Dim base As Decimal
            Dim igv As Decimal
            Dim BaseRef As Decimal
            item = 0
            'item1 = 0
            For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                dr = dsPDB.Tables(0).Rows(I)
                ObePle = New PLE_Compra
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
                    'If (dr(3) = "05" And Len(dr(4)) <> 1) Then MessageBox.Show(String.Format("La serie del Nro.Doc. {0} sobrepaso los caracteres permitidos", dr(4)), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Function
                    idx = dr(4).ToString.IndexOf("-")
                    If idx > 0 Then
                        If dr(3) = "50" OrElse dr(3) = "52" Then
                            .SerieComprobante = dr(4).ToString.Substring(0, idx)
                            .AñoEmision = dr(4).ToString.Substring(idx + 1, 4)
                            .NroComprobante = dr(4).ToString.Substring(idx + 5)
                        ElseIf dr(3) = "53" OrElse dr(3) = "54" Then
                            .AñoEmision = 0
                            .SerieComprobante = dr(4).ToString.Substring(0, idx)
                            '.NroComprobante = dr(4).ToString.Substring(idx + 1)
                            If dr(3) = "53" Then
                                .NroComprobante = dr(4).ToString.Substring(idx + 5)
                            Else
                                .NroComprobante = dr(4).ToString.Substring(idx + 1)
                            End If
                        ElseIf dr(3) = "05" Then
                            .AñoEmision = 0
                            If Integer.TryParse(dr(4).ToString.Substring(0, idx), .SerieComprobante) Then
                                .SerieComprobante = Convert.ToInt32(.SerieComprobante).ToString("0")
                            Else
                                .SerieComprobante = dr(4).ToString.Substring(0, idx)
                            End If
                            .NroComprobante = dr(4).ToString.Substring(idx + 1)
                        Else
                            .AñoEmision = 0
                            If Integer.TryParse(dr(4).ToString.Substring(0, idx), .SerieComprobante) Then
                                .SerieComprobante = Convert.ToInt32(.SerieComprobante).ToString("0000")
                            Else
                                .SerieComprobante = dr(4).ToString.Substring(0, idx)
                            End If
                            '.SerieComprobante = Convert.ToInt32(dr(4).ToString.Substring(0, idx)).ToString("0000")
                            .NroComprobante = dr(4).ToString.Substring(idx + 1)
                        End If
                    Else
                        .NroComprobante = dr(4)
                        .SerieComprobante = "-"
                        .AñoEmision = 0
                    End If

                    .TotalConsolidado = 0
                    If dr(5).ToString.Trim <> "-" Then
                        .TipoDocumento = Integer.Parse(dr(5))
                    Else
                        .TipoDocumento = "0"
                    End If
                    .NroDocumento = dr(6)
                    .RazonSocial = dr(7)
                    If dr(3) = "21" Then
                        .TipoDocumento = "6"
                        .NroDocumento = RUC_EMPRESA
                    End If
                    x = 0
                    Dim _BaseImponible As Boolean
                    _BaseImponible = False
                    Dim valor As Integer = 1
                    If dr(3) = "07" OrElse dr(3) = "87" OrElse dr(3) = "97" Or dr(3) = "96" Then
                        valor = -1
                    End If
                    For J = 8 To 17
                        x += 1
                        'If dr(J) > 0 Then
                        pos = Obj.DIR_TABLA_DESC(String.Format("C{0}", x.ToString("00")), "TPLE")
                        If pos = "BASE1" Then
                            .Base1 += dr(J) * valor
                        ElseIf pos = "BASE2" Then
                            .Base2 += dr(J) * valor
                        ElseIf pos = "BASE3" Then
                            .Base3 += dr(J) * valor
                        ElseIf pos = "IGV1" Then
                            .Igv1 += dr(J) * valor
                        ElseIf pos = "IGV2" Then
                            .Igv2 += dr(J) * valor
                        ElseIf pos = "IGV3" Then
                            .Igv3 += dr(J) * valor
                        ElseIf pos = "NOGRAVADAS" Then
                            .NoGravadas += dr(J) * valor
                        ElseIf pos = "OTROS" Then
                            .MontoOtros += dr(J) * valor
                        End If
                        'End If
                    Next
                    .TipoCambio = dr(19)
                    'If dr(25) > 0 Then
                    '    If dr(26) = "D" Then
                    '        .Base1 += (dr(25) * .TipoCambio)
                    '    Else
                    '        .Base1 += dr(25)
                    '    End If
                    'End If
                    'Para las bases referenciales
                    BaseRef = 0
                    If dr(3) = "07" OrElse dr(3) = "87" OrElse dr(3) = "97" OrElse dr(3) = "96" Then
                        BaseRef = dr(25) * -1
                    Else
                        BaseRef = dr(25)
                    End If

                    If dr(26) = "D" Then
                        .Base1 += (BaseRef * .TipoCambio)
                    Else
                        .Base1 += BaseRef
                    End If

                    .ImporteComprobante = .Base1 + .Base2 + .Base3 + .Igv1 + .Igv2 + .Igv3 + .NoGravadas + .MontoISC + .MontoOtros
                    If (dr(3) = "07" OrElse dr(3) = "08" OrElse dr(3) = "87" OrElse dr(3) = "88" OrElse dr(3) = "97" OrElse dr(3) = "96") Then
                        .TipoComprobanteRef = dr(21)
                        idx = dr(22).ToString.IndexOf("-")
                        If idx > 0 Then
                            '.SerieComprobanteRef = dr(22).ToString.Substring(0, idx)
                            If (dr(22).ToString.Substring(0, idx)).Length = 3 Then
                                .SerieComprobanteRef = "0" + dr(22).ToString.Substring(0, idx)
                            ElseIf (dr(22).ToString.Substring(0, idx)).Length = 2 Then
                                .SerieComprobanteRef = "00" + dr(22).ToString.Substring(0, idx)
                            Else
                                .SerieComprobanteRef = dr(22).ToString.Substring(0, idx)
                            End If
                            .NroComprobanteRef = dr(22).ToString.Substring(idx + 1)
                            .EmisionRef = dr(20)
                            'ElseIf dr(22).ToString.Length > 0 Then
                            '    .SerieComprobanteRef = ""
                            '    .NroComprobanteRef = dr(22)
                            '    .EmisionRef = dr(20)
                        Else
                            'Regresar desde aqui
                            .TipoComprobanteRef = "00"
                            .SerieComprobanteRef = "-"
                            .NroComprobanteRef = "-"
                            .EmisionRef = New Date(1900, 1, 1)
                            MessageBox.Show(String.Format("Verifique la referencia del documento {0}-{1} del proveedor {2}", _
                                .SerieComprobante, .NroComprobante, .RazonSocial), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'loPLE.Clear()
                            'Exit For
                        End If
                    Else
                        .TipoComprobanteRef = "00"
                        .SerieComprobanteRef = "-"
                        .NroComprobanteRef = "-"
                        .EmisionRef = New Date(1900, 1, 1)
                    End If
                    .NroComprobanteExt = "-"
                    If dr(3) = "91" OrElse dr(3) = "97" OrElse dr(3) = "98" Then
                        '.NroComprobanteExt = dr(22)
                        .NroComprobanteExt = .NroComprobante
                    End If
                    .NumeroDet = IIf(dr(23) = "", "0", dr(23))
                    .EmisionDet = IIf(dr(23) = "", New Date(1900, 1, 1), dr(24))
                    .IndicadorRet = "" '"0"

                    Dim dif As Integer = DateDiff(DateInterval.Month, .Emision, New Date(cbo_año.Text, cbo_mes.SelectedIndex + 1, 1))
                    If dif = 0 Then
                        .Anotacion = 1
                        If dr(3) = "02" Or dr(3) = "03" Or dr(3) = "10" Or dr(3) = "19" Or dr(3) = "21" Or dr(3) = "22" Then 'Or dr(3) = "15" Or dr(3) = "16"
                            .Anotacion = 0
                        End If
                    ElseIf dif <= 12 Then
                        If dr(3) = "02" Or dr(3) = "03" Or dr(3) = "10" Or dr(3) = "19" Or dr(3) = "21" Or dr(3) = "22" Then
                            .Anotacion = 0
                        Else
                            .Anotacion = 6
                        End If
                    Else
                        .Anotacion = 7
                    End If
                    .AuxiliarOrigen = dr(27)
                    .ComprobanteOrigen = dr(28)
                    .NumeroComprobanteOrigen = dr(29)
                    '
                    .CodigoMoneda = dr(30)
                    .IndicadorComprobante = IIf(dr(31) Is DBNull.Value, "", "1")
                    .CodigoBienes = dr(32)
                End With
                loPLE.Add(ObePle)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al generar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            loPLE.Clear()
        End Try
        Return loPLE
    End Function

    

    Private Sub GenerarPleCompras(ByVal añoProceso As String, ByVal mesProceso As String)
        Dim trx As SqlTransaction = Nothing
        Dim loPle As List(Of PLE_Compra) = CargarDatosGenerar(añoProceso, mesProceso)
        If loPle.Count > 0 Then
            Try
                con.Open()
                trx = con.BeginTransaction
                Dim i As Integer
                For i = 0 To loPle.Count - 1
                    With loPle(i)
                        Dim cmd As New SqlCommand("INSERTAR_PLE_COMPRAS", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ITEM", .Item)
                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                        cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                        cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                        cmd.Parameters.AddWithValue("@FECHA_EMI", .Emision)
                        cmd.Parameters.AddWithValue("@FECHA_VEN", .Vencimiento)
                        cmd.Parameters.AddWithValue("@TIPO_COMP", .TipoComprobante)
                        cmd.Parameters.AddWithValue("@SERIE_COMP", .SerieComprobante)
                        cmd.Parameters.AddWithValue("@FE_AÑO_EMISION", .AñoEmision)
                        cmd.Parameters.AddWithValue("@NRO_COMP", .NroComprobante)
                        cmd.Parameters.AddWithValue("@TOTAL_CONSOL", .TotalConsolidado)
                        cmd.Parameters.AddWithValue("@TIPO_DOC_PROV", .TipoDocumento)
                        cmd.Parameters.AddWithValue("@NRO_DOC_PROV", .NroDocumento)
                        cmd.Parameters.AddWithValue("@DESC_PROV", .RazonSocial)
                        cmd.Parameters.AddWithValue("@BASE_IMP1", .Base1)
                        cmd.Parameters.AddWithValue("@IGV_1", .Igv1)
                        cmd.Parameters.AddWithValue("@BASE_IMP2", .Base2)
                        cmd.Parameters.AddWithValue("@IGV_2", .Igv2)
                        cmd.Parameters.AddWithValue("@BASE_IMP3", .Base3)
                        cmd.Parameters.AddWithValue("@IGV_3", .Igv3)
                        cmd.Parameters.AddWithValue("@NO_GRAVADAS", .NoGravadas)
                        cmd.Parameters.AddWithValue("@MONTO_ISC", .MontoISC)
                        cmd.Parameters.AddWithValue("@MONTO_OTROS", .MontoOtros)
                        cmd.Parameters.AddWithValue("@IMPORTE_COMP", .ImporteComprobante)
                        cmd.Parameters.AddWithValue("@TIPO_CAMBIO", .TipoCambio)
                        cmd.Parameters.AddWithValue("@FECHA_EMI_REF", .EmisionRef)
                        cmd.Parameters.AddWithValue("@TIPO_COMP_REF", .TipoComprobanteRef)
                        cmd.Parameters.AddWithValue("@SERIE_COMP_REF", .SerieComprobanteRef)
                        cmd.Parameters.AddWithValue("@NRO_COMP_REF", .NroComprobanteRef)
                        cmd.Parameters.AddWithValue("@NRO_COMP_EXT", .NroComprobanteExt)
                        cmd.Parameters.AddWithValue("@FECHA_EMI_DEP_DET", .EmisionDet)
                        cmd.Parameters.AddWithValue("@NRO_DEP_DET", .NumeroDet)
                        cmd.Parameters.AddWithValue("@INDICADOR_RET", .IndicadorRet)
                        cmd.Parameters.AddWithValue("@ANOTACION_AJUSTE", .Anotacion)
                        cmd.Parameters.AddWithValue("@COD_AUX_ORIG", .AuxiliarOrigen)
                        cmd.Parameters.AddWithValue("@COD_COMP_ORIG", .ComprobanteOrigen)
                        cmd.Parameters.AddWithValue("@NRO_COMP_ORIG", .NumeroComprobanteOrigen)
                        '
                        cmd.Parameters.AddWithValue("@CODIGO_MONEDA", .CodigoMoneda)
                        cmd.Parameters.AddWithValue("@INDICADOR_COMPROBANTE", .IndicadorComprobante)
                        cmd.Parameters.AddWithValue("@COD_BIENES", .CodigoBienes)
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
                cboAñoNoDomiciliados.Items.Add(Rs3.GetString(0))
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

    Private Sub LIMPIAR(ByVal Contenedor As Object)
        Dim x As Control
        For Each x In Contenedor.Controls
            If TypeOf x Is TextBox Then CType(x, TextBox).Clear()
            If TypeOf x Is ListBox Or TypeOf x Is ComboBox Then CType(x, ListControl).SelectedIndex = -1
            If TypeOf x Is CheckBox Then CType(x, CheckBox).Checked = False
        Next
    End Sub

    Private Function BUSCAR_ITEM(ByVal OPDB As PLE_Compra) As Boolean
        Return OPDB.Item = Item
    End Function

    Private Sub CARGAR_DETALLES()
        With loPleCompras(Idx)
            If  .TipoDocumento = "0" Then
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
            txtAñoEmision.Text = .AñoEmision
            txtNroComprobante.Text = .NroComprobante
            dtpFechaEmision.Value = .Emision
            dtpVencimiento.Value = IIf(.Vencimiento.CompareTo(New Date(1, 1, 1)) = 0, New Date(1900, 1, 1), .Vencimiento)
            txtConsolidado.Text = Obj.HACER_DECIMAL(.TotalConsolidado)
            txtBase1.Text = Obj.HACER_DECIMAL(.Base1)
            txtIgv1.Text = Obj.HACER_DECIMAL(.Igv1)
            txtBase2.Text = Obj.HACER_DECIMAL(.Base2)
            txtIgv2.Text = Obj.HACER_DECIMAL(.Igv2)
            txtBase3.Text = Obj.HACER_DECIMAL(.Base3)
            txtIgv3.Text = Obj.HACER_DECIMAL(.Igv3)
            txtNoGravadas.Text = Obj.HACER_DECIMAL(.NoGravadas)
            txtIsc.Text = Obj.HACER_DECIMAL(.MontoISC)
            txtOtros.Text = Obj.HACER_DECIMAL(.MontoOtros)
            txtTotalComprobante.Text = .ImporteComprobante
            txtTipoCambio.Text = Obj.HACER_CAMBIO(.TipoCambio)
            txtCompNoDomiciliado.Text = .NroComprobanteExt
            dtpDetraccion.Value = IIf(.EmisionDet.CompareTo(New Date(1, 1, 1)) = 0, New Date(1900, 1, 1), .EmisionDet)
            txtNroDetraccion.Text = .NumeroDet
            chkRetencion.Checked = IIf(.IndicadorRet = "1", True, False)
            cboComprobanteRef.Text = Obj.DESC_DOC(.TipoComprobanteRef)
            txtSerieRef.Text = .SerieComprobanteRef
            txtNroComprobanteRef.Text = .NroComprobanteRef
            txtAnotacion.Text = .Anotacion
            dtpFechaEmisionRef.Value = IIf(.EmisionRef.CompareTo(New Date(1, 1, 1)) = 0, New Date(1900, 1, 1), .EmisionRef)
            
        End With
    End Sub

    Private Sub frmPleCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmPleCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabPage2.Parent = Nothing
        KeyPreview = True
        CARGAR_AÑO()
        CBO_DOCUMENTO()
        CBO_TIPO_DOC()
        cbo_año.Text = AÑO
        cboAñoNoDomiciliados.Text = AÑO
        cbo_mes.Focus()
    End Sub

    Private Sub Consultar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cbo_mes.Focus() : Exit Sub

        dgvDatos.Rows.Clear()
        ConsultarPle()
        If loPleCompras.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("No existen registros del Libro Electrónico - Compras. ¿Desea generarlos?", "Aviso", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then

                GenerarPleCompras(cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
                ConsultarPle()
            End If
        End If
        Dim i As Integer
        For i = 0 To loPleCompras.Count - 1
            With loPleCompras.Item(i)
                dgvDatos.Rows.Add(i + 1, .Item, .Periodo, .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                .TipoComprobante, .SerieComprobante, .NroComprobante, .AñoEmision, .TotalConsolidado, .TipoDocumento, _
                .NroDocumento, .RazonSocial, .Base1, .Igv1, .Base2, .Igv2, .Base3, .Igv3, .NoGravadas, .MontoISC, _
                .MontoOtros, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, _
                .SerieComprobanteRef, .NroComprobanteRef, .NroComprobanteExt, .EmisionDet.ToShortDateString(), _
                .NumeroDet, .IndicadorRet, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen, _
                .CodigoMoneda, .IndicadorComprobante, .CodigoBienes)
            End With
        Next
    End Sub

    Private Sub Modificar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        TabPage2.Parent = TabControl1
        TabControl1.SelectedTab = TabPage2
        _fila = dgvDatos.CurrentRow.Index
        Item = dgvDatos.Item(1, dgvDatos.CurrentRow.Index).Value
        Dim pred As New Predicate(Of PLE_Compra)(AddressOf BUSCAR_ITEM)
        Idx = loPleCompras.FindIndex(pred)
        If Idx > -1 Then
            'LIMPIAR(gbPersona)
            LIMPIAR(gbComprobante)
            LIMPIAR(gbReferencia)
            CARGAR_DETALLES()
        Else
            MessageBox.Show("No se cargaron los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        txtRazonSocial.ReadOnly = False
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
        Dim opleCompras As PLE_Compra = loPleCompras(Idx)
        If cboTipoDocumento.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el tipo de documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        With opleCompras
            .TipoComprobante = Obj.COD_DOC(cboComprobante.Text)
            .SerieComprobante = txtSerie.Text
            .AñoEmision = txtAñoEmision.Text
            .NroComprobante = txtNroComprobante.Text
            .TotalConsolidado = txtConsolidado.Text
            .Base1 = txtBase1.Text
            .Igv1 = txtIgv1.Text
            .Base2 = txtBase2.Text
            .Igv2 = txtIgv2.Text
            .Base3 = txtBase3.Text
            .Igv3 = txtIgv3.Text
            .NoGravadas = txtNoGravadas.Text
            .MontoISC = txtIsc.Text
            .MontoOtros = txtOtros.Text
            .ImporteComprobante = txtTotalComprobante.Text
            .Anotacion = txtAnotacion.Text
            .RazonSocial = txtRazonSocial.Text
            Try
                con.Open()
                Dim cmd As New SqlCommand("ACTUALIZAR_PLE_COMPRAS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ITEM", .Item)
                cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                cmd.Parameters.AddWithValue("@TIPO_COMP", .TipoComprobante)
                cmd.Parameters.AddWithValue("@SERIE_COMP", .SerieComprobante)
                cmd.Parameters.AddWithValue("@FE_AÑO_EMISION", .AñoEmision)
                cmd.Parameters.AddWithValue("@NRO_COMP", .NroComprobante)
                cmd.Parameters.AddWithValue("@TOTAL_CONSOL", .TotalConsolidado)
                cmd.Parameters.AddWithValue("@BASE_IMP1", .Base1)
                cmd.Parameters.AddWithValue("@IGV_1", .Igv1)
                cmd.Parameters.AddWithValue("@BASE_IMP2", .Base2)
                cmd.Parameters.AddWithValue("@IGV_2", .Igv2)
                cmd.Parameters.AddWithValue("@BASE_IMP3", .Base3)
                cmd.Parameters.AddWithValue("@IGV_3", .Igv3)
                cmd.Parameters.AddWithValue("@NO_GRAVADAS", .NoGravadas)
                cmd.Parameters.AddWithValue("@MONTO_ISC", .MontoISC)
                cmd.Parameters.AddWithValue("@MONTO_OTROS", .MontoOtros)
                cmd.Parameters.AddWithValue("@IMPORTE_COMP", .ImporteComprobante)
                cmd.Parameters.AddWithValue("@ANOTACION_AJUSTE", .Anotacion)
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
            Dim Archivo As String = String.Format("LE{0}{1}{2}00080100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    'sw.WriteLine("Tipo Compra|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPleCompras.Count - 1
                        With loPleCompras(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}| " & _
                            '"{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|", _
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                            '.TipoComprobante, .SerieComprobante, IIf(.AñoEmision = 0, "", .AñoEmision), .NroComprobante, .TotalConsolidado, .TipoDocumento, _
                            '.NroDocumento, .RazonSocial, .Base1, .Igv1, .Base2, .Igv2, .Base3, .Igv3, .NoGravadas, .MontoISC, _
                            '.MontoOtros, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, _
                            '.SerieComprobanteRef, "", .NroComprobanteRef, .NroComprobanteExt, .EmisionDet.ToShortDateString(), .NumeroDet, _
                            '.IndicadorRet, .Anotacion)) Se reemplazo pos 10 .TotalConsolidado por ""
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|" & _
                            "{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}|{37}|{38}|{39}|{40}|", _
                            .Periodo, _
                            .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, _
                             "M" & IIf(.Anotacion = 9, "", aux), _
                             .Emision.ToShortDateString(), _
                             .Vencimiento.ToShortDateString(), _
                            .TipoComprobante, _
                            .SerieComprobante, _
                            IIf(.AñoEmision = 0, "", .AñoEmision), _
                            .NroComprobante, _
                            "", _
                            .TipoDocumento, _
                            .NroDocumento, _
                            .RazonSocial, _
                            .Base1, _
                            .Igv1, _
                            .Base2, _
                            .Igv2, _
                            .Base3, _
                            .Igv3, _
                            .NoGravadas, _
                            .MontoISC, _
                            .MontoOtros, _
                            .ImporteComprobante, _
                            .CodigoMoneda, _
                            .TipoCambio, _
                            .EmisionRef.ToShortDateString(), _
                            .TipoComprobanteRef, _
                            .SerieComprobanteRef, _
                             "", _
                             .NroComprobanteRef, _
                             .EmisionDet.ToShortDateString(), _
                             .NumeroDet, _
                             .IndicadorRet, _
                             .CodigoBienes, _
                             "", _
                             "", _
                             "", _
                             "", _
                             "", _
                             .IndicadorComprobante, _
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
                Dim cmd As New SqlCommand("ELIMINAR_PLE_COMPRAS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Obj.COD_MES(cbo_mes.Text)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Registros eliminados correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar los registros.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            con.Close()
        End Try
        Consultar(Nothing, Nothing)
    End Sub

    Private Sub Salir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub MontoDecimal(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBase1.LostFocus, txtBase2.LostFocus, _
        txtBase3.LostFocus, txtIgv1.LostFocus, txtIgv2.LostFocus, txtIgv3.LostFocus, txtNoGravadas.LostFocus, txtIsc.LostFocus, _
        txtOtros.LostFocus, txtTotalComprobante.LostFocus
        Try
            CType(sender, TextBox).Text = Obj.HACER_DECIMAL(CType(sender, TextBox).Text)
        Catch ex As Exception
            CType(sender, TextBox).Text = "0.00"
        End Try
    End Sub

    Private Sub MontoTipoCambio(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoCambio.LostFocus
        Try
            CType(sender, TextBox).Text = Obj.HACER_CAMBIO(CType(sender, TextBox).Text)
        Catch ex As Exception
            CType(sender, TextBox).Text = "0.0000"
        End Try
    End Sub

    Private Sub btn_consultar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año_sunat.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        dgvDatos_sunat.Rows.Clear()
        ConsultarPle_Anual()
        Dim i As Integer
        For i = 0 To loPleCompras.Count - 1
            With loPleCompras.Item(i)
                dgvDatos_sunat.Rows.Add(i + 1, .Item, .Periodo, .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                .TipoComprobante, .SerieComprobante, .NroComprobante, .AñoEmision, .TotalConsolidado, .TipoDocumento, _
                .NroDocumento, .RazonSocial, .Base1, .Igv1, .Base2, .Igv2, .Base3, .Igv3, .NoGravadas, .MontoISC, _
                .MontoOtros, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, _
                .SerieComprobanteRef, .NroComprobanteRef, .NroComprobanteExt, .EmisionDet.ToShortDateString(), _
                .NumeroDet, .IndicadorRet, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen)
            End With
        Next
    End Sub

    Private Sub btn_exportar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año_sunat.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        ConsultarPle_Anual()
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}00080100001111.txt", RUC_EMPRESA, cbo_año_sunat.Text, Obj.COD_MES(cbomes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    sw.WriteLine(String.Format("CPERIODO|CNUMREGOPE|CFECCOM|CFECVENPAG|CTIPDOCCOM|CNUMSER|CEMIDUADSI|CNUMDCOFV|COSDCREFIS|" & _
                    "CTIPDIDPRO|CNUMDIDPRO|CNOMRSOPRO|CBASIMPGRA|CIGVGRA|CBASIMPGNG|CIGVGRANGV|CBASIMPSCF|CIGVSCF|CIMPTOTNGV|CISC|COTRTRIOGO|" & _
                    "CIMPTOTCOM|CTIPCAM|CFECCOMMOD|CTIPCOMMOD|CNUMSERMOD|CNUMCOMMOD|CCOMNODOMI|CEMIDEPDET|CNUMDEPDET|CCOMPGRET|CESTOPE|" & _
                    "CINTDIAMAY|CINTKARDEX|CINTREG"))
                    'sw.WriteLine("Tipo Compra|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPleCompras.Count - 1
                        With loPleCompras(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}| " & _
                            "{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|", _
                            .Periodo, IIf(.Anotacion = 9, "", aux), .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                            .TipoComprobante, .SerieComprobante, .AñoEmision, .NroComprobante, .TotalConsolidado, .TipoDocumento, _
                            .NroDocumento, .RazonSocial, .Base1, .Igv1, .Base2, .Igv2, .Base3, .Igv3, .NoGravadas, .MontoISC, _
                            .MontoOtros, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, _
                            .SerieComprobanteRef, .NroComprobanteRef, .NroComprobanteExt, .EmisionDet.ToShortDateString(), .NumeroDet, _
                            .IndicadorRet, .Anotacion, .AuxiliarOrigen & "-" & .ComprobanteOrigen & "-" & .NumeroComprobanteOrigen, " ", .AuxiliarOrigen & "-" & .ComprobanteOrigen & "-" & .NumeroComprobanteOrigen))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btn_salir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir2.Click
        Close()
    End Sub

#Region "NoDomiciliados"

    Private Sub ConsultarPleNoDomiciliados()
        loPleComprasNoDomiciliadas.Clear()
        Try
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_COMPRAS_NO_DOMICILIADOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FE_AÑO", SqlDbType.VarChar).Value = cboAñoNoDomiciliados.Text
            cmd.Parameters.AddWithValue("@FE_MES", SqlDbType.Char).Value = Obj.COD_MES(cboMesNoDomiciliados.Text)
            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePlaNoDomiciliados As PleCompraNoDomiciliado
                While drd.Read
                    ObePlaNoDomiciliados = New PleCompraNoDomiciliado
                    With ObePlaNoDomiciliados
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .FechaEmision = drd(4)
                        .TipoComprobante = drd(5)
                        .SerieComprobante = drd(6)
                        .NumeroComprobante = drd(7)
                        .ValorAdquirido = drd(8)
                        .ValorOtros = drd(9)
                        .TotalAdquirido = drd(10)
                        .CodigoMoneda = drd(11)
                        .TipoCambio = drd(12)
                        .CodigoPais = drd(13)
                        .NombreSujeto = drd(14)
                        .DireccionSujeto = drd(15)
                        .NumeroDocumentoSujeto = drd(16)
                        .CodigoDobleImposicion = drd(17)
                        .Anotacion = drd(18)
                        .CodigoAuxiliarOrigen = drd(19)
                        .CodigoComprobanteOrigen = drd(20)
                        .NumeroComprobanteOrigen = drd(21)
                        .TipoRenta = drd(22)
                    End With
                    loPleComprasNoDomiciliadas.Add(ObePlaNoDomiciliados)
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

    Private Sub GenerarPleComprasNoDomiciliadas(ByVal Año As String, ByVal Mes As String)
        Dim trx As SqlTransaction = Nothing
        Dim loPleNoDomiciliadas As List(Of PleCompraNoDomiciliado) = CargarDatosGenerarPleComprasNoDomiciliados(Año, Mes)

        If loPleNoDomiciliadas.Count > 0 Then
            Try
                con.Open()
                trx = con.BeginTransaction
                Dim i As Integer
                For i = 0 To loPleNoDomiciliadas.Count - 1
                    With loPleNoDomiciliadas(i)
                        Dim cmd As New SqlCommand("INSERTAR_PLE_COMPRAS_NO_DOMICILIADOS", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ITEM", .Item)
                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                        cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                        cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                        cmd.Parameters.AddWithValue("@FECHA_EMI", .FechaEmision)
                        cmd.Parameters.AddWithValue("@TIPO_COMP", .TipoComprobante)
                        cmd.Parameters.AddWithValue("@SERIE_COMP", .SerieComprobante)
                        cmd.Parameters.AddWithValue("@NRO_COMP", .NumeroComprobante)
                        cmd.Parameters.AddWithValue("@VALOR_ADQ", .ValorAdquirido)
                        cmd.Parameters.AddWithValue("@VALOR_OTROS", .ValorOtros)
                        cmd.Parameters.AddWithValue("@TOTAL_ADQ", .TotalAdquirido)
                        cmd.Parameters.AddWithValue("@COD_MONEDA", .CodigoMoneda)
                        cmd.Parameters.AddWithValue("@TIPO_CAMBIO", .TipoCambio)
                        cmd.Parameters.AddWithValue("@COD_PAIS", .CodigoPais)
                        cmd.Parameters.AddWithValue("@NOMBRE_SUJETO", .NombreSujeto)
                        cmd.Parameters.AddWithValue("@DIRECCION_SUJETO", .DireccionSujeto)
                        cmd.Parameters.AddWithValue("@NRO_DOC_SUJETO", .NumeroDocumentoSujeto)
                        cmd.Parameters.AddWithValue("@COD_DOBLE_IMPOSICION", .CodigoDobleImposicion)
                        cmd.Parameters.AddWithValue("@ANOTACION", .Anotacion)
                        cmd.Parameters.AddWithValue("@COD_AUX_ORIGEN", .CodigoAuxiliarOrigen)
                        cmd.Parameters.AddWithValue("@COD_COMP_ORIG", .CodigoComprobanteOrigen)
                        cmd.Parameters.AddWithValue("@NRO_COMP_ORIG", .NumeroComprobanteOrigen)
                        cmd.Parameters.AddWithValue("@TIPO_RENTA", .TipoRenta)
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

    Private Function CargarDatosGenerarPleComprasNoDomiciliados(ByVal Año As String, ByVal Mes As String) As List(Of PleCompraNoDomiciliado)
        Dim loPleNoDomiciliado As New List(Of PleCompraNoDomiciliado)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_COMPRAS_NO_DOMICILIADOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FE_AÑO", SqlDbType.Char).Value = Año
            cmd.Parameters.AddWithValue("@FE_MES", SqlDbType.Char).Value = Mes
            Dim dsND As New DataSet
            Dim daND As New SqlDataAdapter(cmd)
            daND.Fill(dsND)
            '-------------------------
            Dim I, item As Integer ',
            Dim ObePleNoDomiciliado As PleCompraNoDomiciliado
            Dim dr As DataRow
            item = 0
            '-------------
            For I = 0 To dsND.Tables(0).Rows.Count - 1
                dr = dsND.Tables(0).Rows(I)
                ObePleNoDomiciliado = New PleCompraNoDomiciliado
                With ObePleNoDomiciliado
                    .Item = (I + 1).ToString("000000")
                    .Periodo = dr(0)
                    .Año = cboAñoNoDomiciliados.Text
                    .Mes = Obj.COD_MES(cboMesNoDomiciliados.Text)
                    .FechaEmision = dr(1)
                    .TipoComprobante = dr(2)
                    idx = dr(3).ToString.IndexOf("-")
                    If idx > 0 Then
                        .SerieComprobante = dr(3).ToString.Substring(0, idx)
                        .NumeroComprobante = dr(3).ToString.Substring(idx + 1)
                    Else
                        .SerieComprobante = ""
                        .NumeroComprobante = dr(3)
                    End If

                    .ValorAdquirido = (dr(4))
                    .ValorOtros = 0.0
                    .TotalAdquirido = (dr(4))
                    .CodigoMoneda = dr(5)
                    .TipoCambio = 0.0
                    .CodigoPais = dr(6)
                    .NombreSujeto = dr(7)
                    .DireccionSujeto = ""
                    .NumeroDocumentoSujeto = dr(8)
                    '--Calculamos la anotación
                    Dim dif As Integer = DateDiff(DateInterval.Month, .FechaEmision, New Date(cboAñoNoDomiciliados.Text, cboMesNoDomiciliados.SelectedIndex + 1, 1))
                    If dif = 0 Then
                        .Anotacion = "0"
                    Else
                        .Anotacion = "9"
                    End If

                    .CodigoAuxiliarOrigen = dr(9)
                    .CodigoComprobanteOrigen = dr(10)
                    .NumeroComprobanteOrigen = dr(11)
                    'nuevos campos
                    '.ConveniosDobleImposicion = dr(12)
                    .CodigoDobleImposicion = dr(12)
                    .TipoRenta = dr(13)
                    'Para las notas de credito
                    If .TipoComprobante = "97" Then
                        .ValorAdquirido = .ValorAdquirido * -1
                        .TotalAdquirido = .TotalAdquirido * -1
                    End If
                End With
                loPleNoDomiciliado.Add(ObePleNoDomiciliado)
            Next

        Catch ex As Exception
            MessageBox.Show("Error al generar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            loPleNoDomiciliado.Clear()
        End Try
        Return loPleNoDomiciliado
    End Function

    Private Sub btnConsultaPleNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaPleNoDomiciliados.Click
        If cboAñoNoDomiciliados.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cboAñoNoDomiciliados.Focus() : Exit Sub
        If cboMesNoDomiciliados.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cboMesNoDomiciliados.Focus() : Exit Sub

        dgvDatosNoDomiciliados.Rows.Clear()
        ConsultarPleNoDomiciliados()
        If loPleComprasNoDomiciliadas.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("No existen registros del Libro Electrónico - Compras. ¿Desea generarlos?", "Aviso", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarPleComprasNoDomiciliadas(cboAñoNoDomiciliados.Text, Obj.COD_MES(cboMesNoDomiciliados.Text))
                ConsultarPleNoDomiciliados()
            End If
        End If
        Dim i As Integer
        For i = 0 To loPleComprasNoDomiciliadas.Count - 1
            With loPleComprasNoDomiciliadas.Item(i)
                dgvDatosNoDomiciliados.Rows.Add(i + 1, .Item, .Periodo, .FechaEmision.ToShortDateString(), .TipoComprobante, .SerieComprobante, _
                                  .NumeroComprobante, .ValorAdquirido, .ValorOtros, .TotalAdquirido, .CodigoMoneda, .TipoCambio, _
                                  .CodigoPais, .NombreSujeto, .DireccionSujeto, .NumeroDocumentoSujeto, .CodigoDobleImposicion, .Anotacion, _
                                  .CodigoAuxiliarOrigen, .CodigoComprobanteOrigen, .NumeroComprobanteOrigen, .TipoRenta)
            End With
        Next
    End Sub

    Private Sub btnSalirNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirNoDomiciliados.Click
        Close()
    End Sub

    Private Sub btnExportarNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarNoDomiciliados.Click
        Using fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Dim Archivo As String = String.Format("LE{0}{1}{2}00080200001011.txt", RUC_EMPRESA, cboAñoNoDomiciliados.Text, Obj.COD_MES(cboMesNoDomiciliados.Text)) '00080100001111
                Dim Archivo As String
                If loPleComprasNoDomiciliadas.Count = 0 Then
                    Archivo = String.Format("LE{0}{1}{2}00080200001011.txt", RUC_EMPRESA, cboAñoNoDomiciliados.Text, Obj.COD_MES(cboMesNoDomiciliados.Text))
                Else
                    Archivo = String.Format("LE{0}{1}{2}00080200001111.txt", RUC_EMPRESA, cboAñoNoDomiciliados.Text, Obj.COD_MES(cboMesNoDomiciliados.Text))
                End If
                Using fs As New FileStream(String.Format("{0}\{1}", fbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                    Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                        Dim i As Integer
                        Dim aux As Integer
                        'sw.WriteLine("Tipo Compra|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                        For i = 0 To loPleComprasNoDomiciliadas.Count - 1
                            With loPleComprasNoDomiciliadas(i)
                                If .Anotacion <> 9 Then
                                    aux += 1
                                End If
                                'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}| " & _
                                '"{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|", _
                                '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Emision.ToShortDateString(), .Vencimiento.ToShortDateString(), _
                                '.TipoComprobante, .SerieComprobante, IIf(.AñoEmision = 0, "", .AñoEmision), .NroComprobante, .TotalConsolidado, .TipoDocumento, _
                                '.NroDocumento, .RazonSocial, .Base1, .Igv1, .Base2, .Igv2, .Base3, .Igv3, .NoGravadas, .MontoISC, _
                                '.MontoOtros, .ImporteComprobante, .TipoCambio, .EmisionRef.ToShortDateString(), .TipoComprobanteRef, _
                                '.SerieComprobanteRef, "", .NroComprobanteRef, .NroComprobanteExt, .EmisionDet.ToShortDateString(), .NumeroDet, _
                                '.IndicadorRet, .Anotacion))
                                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|" & _
                                "{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|", _
                                .Periodo, _
                                (.CodigoAuxiliarOrigen.Trim & .CodigoComprobanteOrigen & .NumeroComprobanteOrigen).Trim, _
                                "M" & IIf(.Anotacion = 9, "", aux), _
                                .FechaEmision.ToShortDateString(), _
                                .TipoComprobante, _
                                .SerieComprobante, _
                                .NumeroComprobante, _
                                "0.00", _
                                "0.00", _
                                .ValorAdquirido, _
                                "00", _
                                "", _
                                "", _
                                "-", _
                                "0.00", _
                                .CodigoMoneda.Trim, _
                                "0.000", _
                                .CodigoPais.Trim, _
                                .NombreSujeto, _
                                "", _
                                .NumeroDocumentoSujeto, _
                                "", _
                                "", _
                                "", _
                                "", _
                                "0.00", _
                                "0.00", _
                                "0.00", _
                                "0.00", _
                                "0.00", _
                                .CodigoDobleImposicion, _
                                "", _
                                .TipoRenta, _
                                "", _
                                "", _
                                .Anotacion))
                            End With
                        Next
                        MessageBox.Show(String.Format("Datos exportados en: {0}", fbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                End Using
            End If
        End Using
    End Sub

    Private Sub btnEliminarNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarNoDomiciliados.Click
        Try
            Dim rpta As DialogResult = MessageBox.Show(String.Format("¿Desea eliminar los registros del Libro Electrónico para el periodo {0}-{1}?", _
                cboMesNoDomiciliados.Text, cboAñoNoDomiciliados.Text), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If rpta = Windows.Forms.DialogResult.Yes Then
                con.Open()
                Dim cmd As New SqlCommand("ELIMINAR_PLE_COMPRAS_NO_DOMICILIADOS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAñoNoDomiciliados.Text
                cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Obj.COD_MES(cboMesNoDomiciliados.Text)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Registros eliminados correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar los registros.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            con.Close()
        End Try
        btnConsultaPleNoDomiciliados_Click(Nothing, Nothing)
    End Sub
#End Region
End Class