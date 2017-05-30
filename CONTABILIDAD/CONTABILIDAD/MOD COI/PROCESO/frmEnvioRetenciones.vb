Imports CONTABILIDAD.FacturacionNWS
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text

'Webservices MG-Facturacion
Imports CONTABILIDAD.MG_WSFacturacion

Public Class frmEnvioRetenciones

#Region ". CONSTRUCTOR ."
    Private Shared _instancia As frmEnvioRetenciones

    Public Shared Function ObtenerInstancia() As frmEnvioRetenciones
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New frmEnvioRetenciones
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region " . VARIABLES ."

    Private OBJ As New Class1
    Private PorcentajeRetencion As Decimal = 0
    Private Retencion As STRetencion
    Private Cliente As STCliente
    Private TotalLetras As String
    Private noEnviado As STNoEnviado
    Private Rechazado As STNoEnviado
    Private Observado As STNoEnviado
    Private ListaNoEnviados As List(Of STNoEnviado)
    Private ListaObservados As List(Of STNoEnviado)
    Private ListaRechazados As List(Of STNoEnviado)
    Private Ruta As String
    Private RutaPdf As String
    Private RutaXml As String
    Private RutaCdr As String
    Private RutaImagen As String
    Private sb As New StringBuilder
    Private Emailemisor As String
    Private PassEmisor As String
    Private CertificadoDigital As String
    Private PasswordCertificadoDigital As String
    Private WebEmpresa As String
    Private UsuarioSol As String
    Private ClaveSol As String
    Private Smtp As String
    Private PuertoSmpt As Integer

#End Region

#Region ". ESTRUCTURAS ."
    Structure STRetencion
        Public Auxiliar As String
        Public CodigoComprobante As String
        Public NumeroComprobante As String
        Public Año As String
        Public Mes As String
        Public CodigoDocumento As String
        Public NumeroDocumento As String
        Public FechaEmision As Date
        Public CodigoCliente As String
        Public Regimen As String
        Public Tasa As Decimal
        Public Observacion As String
        Public TotalRetencion As Decimal
        Public TotalPagado As Decimal
        Public CodigoMoneda As String
        Public Moneda As String
        Public TipoCambio As Decimal
        Public Detalle As List(Of STDetalle)
    End Structure

    Structure STDetalle
        Public CodigoDocumento As String
        Public NumeroDocumento As String
        Public FechaDocumento As Date
        Public ImporteDocumento As Decimal
        Public Moneda As String
        Public ImporteRetencion As Decimal
        Public TotalPagado As Decimal
        Public NumeroPago As Integer
        Public ImporteIni As Decimal
    End Structure

    Structure STCliente
        Public RUC As String
        Public TipoDocumento As String
        Public RazonSocial As String
        Public NombreComercial As String
        Public Direccion() As String
        Public Email As String
    End Structure

    Structure STNoEnviado
        Public NumeroDocumento As String
        Public Mensaje As String
    End Structure

#End Region

#Region ". RUTINAS ."

    Sub CargarRetencionesPendientes()
        Me.dgvRetencionesPendiente.Rows.Clear()
        Try
            con.Open()
            'FACTURAS PENDIENTES
            Using command As New SqlCommand("MOSTRAR_I_RETENCIONES_FE_PENDIENTE", con)
                command.CommandType = (CommandType.StoredProcedure)
                Using reader As SqlDataReader = command.ExecuteReader()
                    If Not IsNothing(reader) AndAlso reader.HasRows Then
                        While reader.Read
                            dgvRetencionesPendiente.Rows.Add(reader("Aux."), reader("Cod. Comp."), reader("Nro. Comp."), _
                            reader("Año"), reader("Mes"), reader("Cod. Ret."), reader("Nro. Ret."), reader("Fecha Ret."), _
                            reader("Cod. Per."), reader("Desc. Per."), reader("Doc. Per."), reader("Total Ret."), _
                            reader("CodigoMoneda"), reader("Moneda"), reader("T.C."), False)
                        End While
                    End If
                End Using
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Finally
            con.Close()
        End Try
    End Sub

    Sub CargarRetencionesEnviadas()
        Me.dgvRetencionesEnviada.Rows.Clear()
        Try
            con.Open()
            'FACTURAS PENDIENTES
            Using command As New SqlCommand("MOSTRAR_I_RETENCIONES_FE_ENVIADO", con)
                command.CommandType = (CommandType.StoredProcedure)
                Using reader As SqlDataReader = command.ExecuteReader()
                    If Not IsNothing(reader) AndAlso reader.HasRows Then
                        While reader.Read
                            dgvRetencionesEnviada.Rows.Add(reader("Aux."), reader("Cod. Comp."), reader("Nro. Comp."), _
                            reader("Año"), reader("Mes"), reader("Cod. Ret."), reader("Nro. Ret."), reader("Fecha Ret."), _
                            reader("Cod. Per."), reader("Desc. Per."), reader("Doc. Per."), reader("Total Ret."), _
                            reader("CodigoMoneda"), reader("Moneda"), reader("T.C."), False, "Consultar")
                        End While
                    End If
                End Using
            End Using
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Finally
            con.Close()
        End Try
    End Sub

    'Sub CargarFacturasEnviadas()
    '    Me.dgvFacturaEnviada.Rows.Clear()
    '    Try
    '        con.Open()
    '        'FACTURAS ENVIADAS
    '        Using command As New SqlCommand("MOSTRAR_IFACT_VTA_FE_ENVIADO", con)
    '            command.CommandType = (CommandType.StoredProcedure)
    '            Using reader As SqlDataReader = command.ExecuteReader()
    '                If Not IsNothing(reader) AndAlso reader.HasRows Then
    '                    While reader.Read
    '                        dgvFacturaEnviada.Rows.Add(reader("COD_SUCURSAL"), reader("Sucursal"), reader("cod_clase"), reader("Clase"), reader("Doc"), _
    '                        reader("NumeroDoc"), reader("Fecha"), reader("cod_per"), reader("Cliente"), reader("nro_doc_per"), _
    '                        reader("observacion"), reader("CodigoMoneda"))
    '                    End While
    '                End If
    '            End Using
    '        End Using
    '        Dim codigoDocumento As Integer
    '        Dim numeroDocumento As String
    '        Dim respuesta As transactionResult
    '        Using cliente As New FacturacionService
    '            For i As Integer = 0 To Me.dgvFacturaEnviada.RowCount - 1
    '                codigoDocumento = CInt(Me.dgvFacturaEnviada.Rows(i).Cells(4).Value)
    '                numeroDocumento = String.Format("{0}", Me.dgvFacturaEnviada.Rows(i).Cells(5).Value)
    '                respuesta = cliente.ConsultarEstado(codigoDocumento, True, numeroDocumento)
    '                If respuesta.messageField.ToLower().Contains("error") Then
    '                    Me.dgvFacturaEnviada.Rows(i).Cells(10).Value = String.Format("{0} - {1}", respuesta.messageField, respuesta.outStringField)
    '                Else
    '                    Me.dgvFacturaEnviada.Rows(i).Cells(10).Value = respuesta.messageField
    '                End If

    '            Next
    '        End Using
    '    Catch ex As WebException
    '        MessageBox.Show(ex.Message, "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Compras, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
    '        OBJ.SerializarLog(log)
    '    Catch ex As Exception
    '        Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Compras, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
    '        OBJ.SerializarLog(log)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    Function CargarDetalles(ByVal auxiliar As String, ByVal codigoComprobante As String, ByVal numeroComprobante As String, _
    ByVal añoConsulta As String, ByVal mesConsulta As String) As List(Of STDetalle)
        Dim listaDetalle As New List(Of STDetalle)
        Try
            con.Open()
            Dim command As New SqlCommand("MOSTRAR_T_RETENCIONES_FE", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = auxiliar
            command.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = codigoComprobante
            command.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = numeroComprobante
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = añoConsulta
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesConsulta
            Dim reader As SqlDataReader = command.ExecuteReader()
            If Not IsNothing(reader) AndAlso reader.HasRows Then
                Dim detalle As STDetalle
                Dim i As Integer = 0
                While reader.Read
                    i += 1
                    detalle = New STDetalle
                    detalle.CodigoDocumento = CInt(reader("Cod. Doc."))
                    detalle.NumeroDocumento = reader("Nro. Doc.")
                    detalle.FechaDocumento = reader("Fecha Doc.")
                    detalle.ImporteDocumento = reader("Importe Doc.")
                    detalle.Moneda = reader("CodigoMoneda")
                    detalle.ImporteRetencion = reader("Importe Ret.")
                    detalle.TotalPagado = reader("Total Pagado")
                    detalle.NumeroPago = reader("Nro. Pago")
                    detalle.ImporteIni = reader("Importe Ini.")
                    listaDetalle.Add(detalle)
                End While
            End If
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return listaDetalle
    End Function

    'Function CargarDatosDeAnticipo(ByVal añoConsulta As String, ByVal mesConsulta As String, ByVal codigoSucursal As String, ByVal codigoClase As String, _
    'ByVal codigoCliente As String, ByVal codigoDocumento As String, ByVal numeroDocumento As String) As String()
    '    Dim datosAnticipo() As String
    '    Try
    '        con.Open()
    '        Dim command As New SqlCommand("MOSTRAR_DETALLE_ANTICIPO", con)
    '        command.CommandType = CommandType.StoredProcedure
    '        command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = añoConsulta
    '        command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesConsulta
    '        command.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = codigoSucursal
    '        command.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = codigoClase
    '        command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigoCliente
    '        command.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = numeroDocumento
    '        command.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = codigoDocumento
    '        Dim reader As SqlDataReader = command.ExecuteReader()
    '        If Not IsNothing(reader) AndAlso reader.HasRows Then
    '            ReDim datosAnticipo(1)
    '            reader.Read()
    '            datosAnticipo(0) = reader("Monto")
    '            datosAnticipo(1) = reader("NumeroAnticipo")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    '    Return datosAnticipo
    'End Function

    Function CargarDatosDelCliente(ByVal codigoCliente As String) As STCliente
        Dim cliente As STCliente = Nothing
        Try
            con.Open()
            Dim command As New SqlCommand("MOSTRAR_DATOS_CLIENTE", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigoCliente
            Dim reader As SqlDataReader = command.ExecuteReader()
            If Not IsNothing(reader) AndAlso reader.HasRows Then
                reader.Read()
                cliente = New STCliente()
                cliente.TipoDocumento = CInt(reader("TipoDocumento"))
                cliente.RUC = reader("Ruc")
                cliente.RazonSocial = reader("RazonSocial")
                cliente.NombreComercial = reader("NombreComercial")
            End If
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return cliente
    End Function

    Function CargarEmailDelCliente(ByVal codigoCliente As String) As List(Of String)
        Dim lista As List(Of String) = Nothing
        Try
            con.Open()
            Dim command As New SqlCommand("MOSTRAR_EMAIL_FE_CLIENTE", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigoCliente
            Dim reader As SqlDataReader = command.ExecuteReader()
            If Not IsNothing(reader) AndAlso reader.HasRows Then
                lista = New List(Of String)
                While reader.Read()
                    lista.Add(reader("Email"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("Ocurrió un error al cargar los datos del cliente.{0}{1}", Environment.NewLine, ex.Message), "Gestión Comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return lista
    End Function

    Function ActualizarEstadoDeEnvio(ByVal auxiliar As String, ByVal codigoComprobante As String, ByVal numeroComprobante As String, _
    ByVal añoConsulta As String, ByVal mesConsulta As String) As Boolean
        Dim enviado As Boolean = False
        Try
            con.Open()
            Dim command As New SqlCommand("ACTUALIZAR_I_RETENCIONES_ENVIO_FE", con)
            command.CommandType = (CommandType.StoredProcedure)
            command.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = auxiliar
            command.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = codigoComprobante
            command.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = numeroComprobante
            command.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = añoConsulta
            command.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesConsulta
            enviado = command.ExecuteNonQuery() > 0
        Catch ex As Exception
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Finally
            con.Close()
        End Try
        Return enviado
    End Function

    Function EnviarArchivo(ByVal rutaArchivo As String) As transactionResponse()
        Dim respuesta As transactionResponse()
        If File.Exists(rutaArchivo) Then
            Dim archivoEnBytes As Byte()
            archivoEnBytes = File.ReadAllBytes(rutaArchivo)
            Using cliente As New FacturacionNService
                respuesta = cliente.EnviarRetencion(archivoEnBytes)
            End Using
        End If
        Return respuesta
    End Function

    Function TotalEnLetras(ByVal moneda As String, ByVal montoTotal As Decimal) As String
        Dim total As String
        Dim largo = Len(CStr(Format(CDbl(montoTotal), "##,###,###,##0.00")))
        Dim decimales = Mid(CStr(Format(CDbl(montoTotal), "##,###,###,##0.00")), largo - 2)
        Dim num As Integer = (Decimal.Subtract(montoTotal, decimales))
        total = OBJ.NumText(num) & "  CON " & Mid(decimales, Len(decimales) - 1) & "/100 " & moneda & "."
        Return total
    End Function

#End Region

    Private Sub frmEnvioRetenciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PorcentajeRetencion = OBJ.IMPUESTO("RET")
        Ruta = OBJ.DIR_TABLA_DESC("DIREFE", "TDEFA")
        CargarRetencionesPendientes()
        CargarRetencionesEnviadas()
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        ListaNoEnviados = New List(Of STNoEnviado)
        Try
            Dim estado As Boolean

            If IsNothing(DireccionEmpresa) Then
                MessageBox.Show("No se encontró la dirección de la empresa", "Gestión Comercial", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            For i As Integer = 0 To Me.dgvRetencionesPendiente.RowCount - 1
                estado = Me.dgvRetencionesPendiente.Rows(i).Cells(15).Value
                If estado Then
                    EscribirDocumentoCSV(Ruta, i)
                End If
            Next
            Me.llblNoEnviado.Visible = ListaNoEnviados.Count > 0
            If ListaNoEnviados.Count > 0 Then
                MessageBox.Show("Algunos documentos no pudieron ser enviados.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Datos exportados", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            CargarRetencionesPendientes()
            CargarRetencionesEnviadas()
        Catch ex As WebException
            MessageBox.Show(ex.Message, "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al enviar los archivos", "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        End Try
    End Sub

    ''' <summary>
    ''' Método para el envío de Retenciones Electrónicas
    ''' </summary>
    ''' <param name="ruta">Ubicación de almacenamiento de los csv generados</param>
    ''' <param name="fila">Fila actual, dentro del DataGridView, del registro que se está enviando</param>
    ''' <remarks></remarks>
    Private Sub EscribirDocumentoCSV(ByVal ruta As String, ByVal fila As Integer)
        Dim archivo As String = String.Empty
        Dim moneda As String
        Dim emailContacto As String
        Dim emailCliente As List(Of String)
        Dim serie As String = String.Empty
        Dim numeroDocumento As String = String.Empty
        moneda = Me.dgvRetencionesPendiente.Rows(fila).Cells(15).Value

        Retencion = New STRetencion()
        With Retencion
            .Auxiliar = Me.dgvRetencionesPendiente.Rows(fila).Cells(0).Value
            .CodigoComprobante = Me.dgvRetencionesPendiente.Rows(fila).Cells(1).Value
            .NumeroComprobante = Me.dgvRetencionesPendiente.Rows(fila).Cells(2).Value
            .Año = Me.dgvRetencionesPendiente.Rows(fila).Cells(3).Value
            .Mes = Me.dgvRetencionesPendiente.Rows(fila).Cells(4).Value
            .CodigoDocumento = Me.dgvRetencionesPendiente.Rows(fila).Cells(5).Value
            .NumeroDocumento = Me.dgvRetencionesPendiente.Rows(fila).Cells(6).Value
            .FechaEmision = Me.dgvRetencionesPendiente.Rows(fila).Cells(7).Value
            .CodigoCliente = Me.dgvRetencionesPendiente.Rows(fila).Cells(8).Value
            .Regimen = "01"
            .Tasa = PorcentajeRetencion
            .Observacion = ""
            .TotalRetencion = Me.dgvRetencionesPendiente.Rows(fila).Cells(11).Value
            .TotalPagado = 0
            .CodigoMoneda = Me.dgvRetencionesPendiente.Rows(fila).Cells(12).Value
            .Moneda = Me.dgvRetencionesPendiente.Rows(fila).Cells(13).Value
            .TipoCambio = Me.dgvRetencionesPendiente.Rows(fila).Cells(14).Value
            .Detalle = CargarDetalles(.Auxiliar, .CodigoComprobante, .NumeroComprobante, .Año, .Mes)

            If IsNothing(.Detalle) OrElse .Detalle.Count = 0 Then
                Dim noEnviado As New STNoEnviado
                noEnviado.NumeroDocumento = .NumeroDocumento
                noEnviado.Mensaje = "No se encontró detalles para el documento"
                ListaNoEnviados.Add(noEnviado)
                Return
            Else
                For Each item As STDetalle In .Detalle
                    If item.CodigoDocumento = 7 Then
                        .TotalPagado -= item.TotalPagado
                    Else
                        .TotalPagado += item.TotalPagado
                    End If
                Next
            End If
        End With

        emailContacto = OBJ.DIR_TABLA_DESC("CONTFE", "TDEFA")

        Cliente = CargarDatosDelCliente(Retencion.CodigoCliente)
        If My.Settings.IsDev Then
            Cliente.Email = My.Settings.EmailPrueba
        Else
            emailCliente = CargarEmailDelCliente(Retencion.CodigoCliente)
            If (IsNothing(emailCliente) OrElse emailCliente.Count = 0) Then
                noEnviado = New STNoEnviado
                noEnviado.NumeroDocumento = Retencion.NumeroDocumento
                noEnviado.Mensaje = "No se encontró el email del cliente."
                ListaNoEnviados.Add(noEnviado)
                Return
            ElseIf emailCliente.Count > 2 Then
                noEnviado = New STNoEnviado
                noEnviado.NumeroDocumento = Retencion.NumeroDocumento
                noEnviado.Mensaje = "No se puede enviar el correo a mas de 2 destinatarios por cliente."
                ListaNoEnviados.Add(noEnviado)
                Return
            Else
                emailCliente.Add(emailContacto)
                Cliente.Email = String.Join(";", emailCliente.ToArray())
            End If
        End If


        Cliente.Direccion = OBJ.HallarDireccionPersona(Retencion.CodigoCliente, "01")
        If IsNothing(Cliente.Direccion) Then
            noEnviado = New STNoEnviado
            noEnviado.NumeroDocumento = Retencion.NumeroDocumento
            noEnviado.Mensaje = "No se encontró información de la dirección del cliente."
            ListaNoEnviados.Add(noEnviado)
            Return
        End If


        TotalLetras = TotalEnLetras(Retencion.Moneda, Retencion.TotalRetencion)

        archivo = String.Format("{0}\{1}.csv", ruta, Retencion.NumeroDocumento)
        Using fs As New FileStream(archivo, FileMode.Create, FileAccess.Write)
            Using sw As New StreamWriter(fs, System.Text.Encoding.UTF8)

                'DATOS DEL DOCUMENTO
                With Retencion
                    sw.WriteLine(String.Format("{0}|{1}", .FechaEmision.ToShortDateString(), .NumeroDocumento))
                End With


                'DATOS DEL EMISOR
                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}", DESC_EMPRESA, DESC_CORTA_EMPRESA, RUC_EMPRESA, 6, DireccionEmpresa(0), _
                DireccionEmpresa(1), "", DireccionEmpresa(2), DireccionEmpresa(3), DireccionEmpresa(4), "PE", "MODDATOS", "moddatos"))


                'DATOS DEL PROVEEDOR
                With Cliente
                    sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", .RazonSocial, _
                    IIf(String.IsNullOrEmpty(.NombreComercial.Trim), .RazonSocial, .NombreComercial), .RUC, .TipoDocumento, _
                    .Direccion(0), .Direccion(1).Replace(",", ";"), "", .Direccion(2), .Direccion(3), .Direccion(4), _
                    .Direccion(5), .Email))
                End With

                'DATOS DE LA RETENCIÓN
                With Retencion
                    sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", .Regimen, .Tasa, .Observacion, .TotalRetencion, _
                    .CodigoMoneda, .TotalPagado, .CodigoMoneda))
                End With

                'LEYENDAS SUNAT
                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|" & _
                                    "{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}|{31}|{32}|{33}|{34}|{35}|{36}", _
                                    TotalLetras, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", _
                                    "", "", "", "", "", "", "", "", "", "", "", ""))

                'INFORMACIÓN ADICIONAL
                sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|" & _
                                    "{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}", "", "", "", "", "", "", "", "", _
                                    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""))

                'DATOS DEL COMPROBANTE RELACIONADO

                Dim idx As Integer
                For Each Item As STDetalle In Retencion.Detalle
                    sb.Remove(0, sb.Length)
                    With Item
                        idx = .NumeroDocumento.IndexOf("-")
                        If idx > -1 Then
                            serie = .NumeroDocumento.Substring(0, idx)
                            If serie.Length < 4 Then
                                serie = serie.PadLeft(4, "0")
                            End If
                            numeroDocumento = .NumeroDocumento.Substring(idx + 1)
                            .NumeroDocumento = String.Concat(serie, "-", numeroDocumento)
                        End If
                        sb.Append(String.Format("{0}|{1}|", .CodigoDocumento, .NumeroDocumento)) '8A - 8B
                        sb.Append(String.Format("{0}|{1}|", .FechaDocumento.ToShortDateString(), .ImporteIni)) '8C - 8D
                        sb.Append(String.Format("{0}|{1}|", .Moneda, Retencion.FechaEmision.ToShortDateString())) '8E - 8F
                        sb.Append(String.Format("{0}|{1}|", .NumeroPago, .ImporteDocumento)) '8G - 8H
                        sb.Append(String.Format("{0}|{1}|", .Moneda, .ImporteRetencion)) '8I - 8J
                        sb.Append(String.Format("{0}|{1}|", "PEN", Retencion.FechaEmision.ToShortDateString())) '8K - 8L
                        sb.Append(String.Format("{0}|{1}|", .TotalPagado, "PEN")) '8M - 8N
                        sb.Append(String.Format("{0}|{1}|", IIf(.Moneda <> "PEN", .Moneda, ""), IIf(.Moneda <> "PEN", "PEN", ""))) '8O - 8P
                        sb.Append(String.Format("{0}|{1}|", IIf(.Moneda <> "PEN", Retencion.TipoCambio, ""), IIf(.Moneda <> "PEN", Retencion.FechaEmision.ToShortDateString(), ""))) '8Q - 8R
                        sb.Append(String.Format("{0}|", .NumeroPago)) '8S

                        sw.WriteLine(sb.ToString)
                    End With
                Next

                'FIN DE ARCHIVO
                sw.WriteLine("FF00FF")
            End Using
        End Using
        Dim respuesta As transactionResponse() = EnviarArchivo(archivo)
        If Not IsNothing(respuesta) AndAlso Not IsNothing(respuesta(0).pdfFile) Then
            With Retencion
                Dim enviado As Boolean = ActualizarEstadoDeEnvio(.Auxiliar, .CodigoComprobante, .NumeroComprobante, .Año, .Mes)
            End With
        Else
            Dim noEnviado As New STNoEnviado
            noEnviado.NumeroDocumento = Retencion.NumeroDocumento
            noEnviado.Mensaje = respuesta(0).outString
            ListaNoEnviados.Add(noEnviado)
        End If
    End Sub

    Private Sub llblNoEnviado_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblNoEnviado.LinkClicked
        Dim frm As New Form
        frm.Text = "Lista de retenciones no enviadas"
        Dim dgv As New DataGridView
        Dim col1, col2 As New DataGridViewTextBoxColumn
        col1.HeaderText = "N° Doc."
        col1.Width = 90
        col2.HeaderText = "Mensaje"
        col2.Width = 300
        dgv.Columns.Add(col1)
        dgv.Columns.Add(col2)
        dgv.Dock = DockStyle.Fill
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.RowHeadersVisible = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For Each item As STNoEnviado In ListaNoEnviados
            dgv.Rows.Add(item.NumeroDocumento, item.Mensaje)
        Next
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.Size = New Size(516, 300)
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Controls.Add(dgv)

        frm.ShowDialog()
    End Sub

    Private Sub btnEnviarSunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarSunat.Click
        ListaNoEnviados = New List(Of STNoEnviado)
        ListaRechazados = New List(Of STNoEnviado)
        ListaObservados = New List(Of STNoEnviado)

        RutaPdf = OBJ.DIR_TABLA_DESC("FILPDF", "TDEFA")
        RutaCdr = OBJ.DIR_TABLA_DESC("FILCDR", "TDEFA")
        RutaXml = OBJ.DIR_TABLA_DESC("FILXML", "TDEFA")
        RutaImagen = OBJ.DIR_TABLA_DESC("IMPLOG", "TDEFA")
        Emailemisor = OBJ.DIR_TABLA_DESC("CORRFE", "TDEFA")
        CertificadoDigital = OBJ.DIR_TABLA_DESC("FIRDIG", "TDEFA")
        PasswordCertificadoDigital = OBJ.DIR_TABLA_DESC("PASSFD", "TDEFA")
        WebEmpresa = OBJ.HallarWebEmpresa(COD_EMPRESA)
        PassEmisor = OBJ.DIR_TABLA_DESC("PASSFE", "TDEFA")

        Try
            Dim estado As Boolean


            If String.IsNullOrEmpty(Emailemisor.Trim()) Then
                MessageBox.Show("No se encontró el correo del Emisor", "Gestión Comercial", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If String.IsNullOrEmpty(PassEmisor.Trim()) Then
                MessageBox.Show("No se encontró la contraseña del correo del Emisor", "Gestión Comercial", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If String.IsNullOrEmpty(RutaPdf.Trim()) Then
                MessageBox.Show("No se encontró la dirección para guardar los archivos .pdf", "Gestión Comercial", _
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If String.IsNullOrEmpty(RutaXml.Trim()) Then
                MessageBox.Show("No se encontró la dirección para guardar los archivos .xml", "Gestión Comercial", _
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If String.IsNullOrEmpty(RutaCdr.Trim()) Then
                MessageBox.Show("No se encontró la dirección para guardar los archivos  CDR", "Gestión Comercial", _
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If String.IsNullOrEmpty(RutaImagen.Trim()) Then
                MessageBox.Show("No se encontró la ruta para la imagén del correo", "Gestión Comercial", _
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If


            For i As Integer = 0 To Me.dgvRetencionesPendiente.RowCount - 1
                estado = Me.dgvRetencionesPendiente.Rows(i).Cells(15).Value
                If estado Then
                    EscribirXmlRetencion(RutaPdf, i)
                End If
            Next

            Me.llblNoEnviado.Visible = ListaNoEnviados.Count > 0
            Me.lblRechazados.Visible = ListaRechazados.Count > 0
            Me.lblObservados.Visible = ListaObservados.Count > 0

            If ListaNoEnviados.Count > 0 Then
                MessageBox.Show("Algunos documentos no pudieron ser enviados", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf ListaRechazados.Count > 0 Or ListaObservados.Count > 0 Then
                MessageBox.Show("Datos enviados a sunat correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show("Fueron rechazados o tienen observaciones", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Datos enviados a sunat correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            CargarRetencionesPendientes()
            CargarRetencionesEnviadas()
        Catch ex As WebException
            MessageBox.Show(ex.Message, "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al enviar los archivos", "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim log As New LogUsuario(LogUsuario.ModuloOrigen.Contabilidad, "Facturación electrónica: " & ex.Message, LogUsuario.TipoLog.Critico)
            OBJ.SerializarLog(log)
        End Try
    End Sub

    ''' <summary>
    ''' Método para el envío de Retenciones Electrónicas
    ''' </summary>
    ''' <param name="ruta">Ubicación de almacenamiento de los csv generados</param>
    ''' <param name="fila">Fila actual, dentro del DataGridView, del registro que se está enviando</param>
    ''' <remarks></remarks>
    Private Sub EscribirXmlRetencion(ByVal RutaPdf As String, ByVal fila As Integer)
        Dim archivo As String = String.Empty
        Dim moneda As String
        Dim emailContacto As String
        Dim emailCliente As List(Of String)
        Dim serie As String = String.Empty
        Dim numeroDocumento As String = String.Empty
        moneda = Me.dgvRetencionesPendiente.Rows(fila).Cells(15).Value

        Dim documentoRetencion As New DocumentoRetencion()

        Retencion = New STRetencion()
        With Retencion
            .Auxiliar = Me.dgvRetencionesPendiente.Rows(fila).Cells(0).Value
            .CodigoComprobante = Me.dgvRetencionesPendiente.Rows(fila).Cells(1).Value
            .NumeroComprobante = Me.dgvRetencionesPendiente.Rows(fila).Cells(2).Value
            .Año = Me.dgvRetencionesPendiente.Rows(fila).Cells(3).Value
            .Mes = Me.dgvRetencionesPendiente.Rows(fila).Cells(4).Value
            .CodigoDocumento = Me.dgvRetencionesPendiente.Rows(fila).Cells(5).Value
            .NumeroDocumento = Me.dgvRetencionesPendiente.Rows(fila).Cells(6).Value
            .FechaEmision = Me.dgvRetencionesPendiente.Rows(fila).Cells(7).Value
            .CodigoCliente = Me.dgvRetencionesPendiente.Rows(fila).Cells(8).Value
            .Regimen = "01"
            .Tasa = PorcentajeRetencion
            .Observacion = ""
            .TotalRetencion = Me.dgvRetencionesPendiente.Rows(fila).Cells(11).Value
            .TotalPagado = 0
            .CodigoMoneda = Me.dgvRetencionesPendiente.Rows(fila).Cells(12).Value
            .Moneda = Me.dgvRetencionesPendiente.Rows(fila).Cells(13).Value
            .TipoCambio = Me.dgvRetencionesPendiente.Rows(fila).Cells(14).Value
            .Detalle = CargarDetalles(.Auxiliar, .CodigoComprobante, .NumeroComprobante, .Año, .Mes)

            Dim archivoPdf As String = String.Format("{0}\{1}-{2}.pdf", RutaPdf, .NumeroDocumento, "20")
            If Not File.Exists(archivoPdf) Then
                noEnviado = New STNoEnviado
                noEnviado.NumeroDocumento = .NumeroDocumento
                noEnviado.Mensaje = "No se encontro el archivo pdf"
                ListaNoEnviados.Add(noEnviado)
                Return
            End If

            If IsNothing(.Detalle) OrElse .Detalle.Count = 0 Then
                Dim noEnviado As New STNoEnviado
                noEnviado.NumeroDocumento = .NumeroDocumento
                noEnviado.Mensaje = "No se encontró detalles para el documento"
                ListaNoEnviados.Add(noEnviado)
                Return
            Else
                For Each item As STDetalle In .Detalle
                    If item.CodigoDocumento = 7 Then
                        .TotalPagado -= item.TotalPagado
                    Else
                        .TotalPagado += item.TotalPagado
                    End If
                Next
            End If
        End With

        emailContacto = OBJ.DIR_TABLA_DESC("CONTFE", "TDEFA")

        Cliente = CargarDatosDelCliente(Retencion.CodigoCliente)

        If My.Settings.PruebaFE Then
            Cliente.Email = My.Settings.EmailPrueba
        Else
            emailCliente = CargarEmailDelCliente(Retencion.CodigoCliente)
            If (IsNothing(emailCliente) OrElse emailCliente.Count = 0) Then
                noEnviado = New STNoEnviado
                noEnviado.NumeroDocumento = Retencion.NumeroDocumento
                noEnviado.Mensaje = "No se encontró el email del cliente."
                ListaNoEnviados.Add(noEnviado)
                Return
            ElseIf emailCliente.Count > 2 Then
                noEnviado = New STNoEnviado
                noEnviado.NumeroDocumento = Retencion.NumeroDocumento
                noEnviado.Mensaje = "No se puede enviar el correo a mas de 2 destinatarios por cliente."
                ListaNoEnviados.Add(noEnviado)
                Return
            Else
                emailCliente.Add(emailContacto)
                Cliente.Email = String.Join(",", emailCliente.ToArray())
            End If
        End If


        Cliente.Direccion = OBJ.HallarDireccionPersona(Retencion.CodigoCliente, "01")
        If IsNothing(Cliente.Direccion) Then
            noEnviado = New STNoEnviado
            noEnviado.NumeroDocumento = Retencion.NumeroDocumento
            noEnviado.Mensaje = "No se encontró información de la dirección del cliente."
            ListaNoEnviados.Add(noEnviado)
            Return
        End If


        TotalLetras = TotalEnLetras(Retencion.Moneda, Retencion.TotalRetencion)



        'DATOS DEL DOCUMENTO
        With Retencion
            documentoRetencion.FechaEmision = .FechaEmision.ToShortDateString()
            documentoRetencion.IdDocumento = .NumeroDocumento
        End With


        'DATOS DEL EMISOR
        Dim Emisor As New Contribuyente()
        Emisor.NombreLegal = DESC_EMPRESA
        Emisor.NombreComercial = DESC_CORTA_EMPRESA
        Emisor.NroDocumento = RUC_EMPRESA
        Emisor.TipoDocumento = "6"
        Emisor.Ubigeo = DireccionEmpresa(0)
        Emisor.Direccion = DireccionEmpresa(1)
        Emisor.Urbanizacion = ""
        Emisor.Departamento = DireccionEmpresa(2)
        Emisor.Provincia = DireccionEmpresa(3)
        Emisor.Distrito = DireccionEmpresa(4)
        documentoRetencion.Emisor = Emisor


        'DATOS DEL PROVEEDOR
        With Cliente
            Dim Receptor As New Contribuyente()
            Receptor.NroDocumento = .RUC
            Receptor.TipoDocumento = .TipoDocumento
            Receptor.NombreLegal = .RazonSocial
            Receptor.NombreComercial = IIf(String.IsNullOrEmpty(.NombreComercial.Trim), .RazonSocial, .NombreComercial)
            documentoRetencion.Receptor = Receptor
        End With

        'DATOS DE LA RETENCIÓN
        With Retencion
            documentoRetencion.RegimenRetencion = .Regimen
            documentoRetencion.TasaRetencion = .Tasa
            documentoRetencion.Observaciones = .Observacion
            documentoRetencion.ImporteTotalRetenido = .TotalRetencion
            documentoRetencion.Moneda = .CodigoMoneda
            documentoRetencion.ImporteTotalPagado = .TotalPagado
        End With

        'DATOS DEL COMPROBANTE RELACIONADO

        Dim idx As Integer
        Dim documentosRelacionados(Retencion.Detalle.Count - 1) As ItemRetencion
        Dim count As Integer = 0
        For Each Item As STDetalle In Retencion.Detalle
            sb.Remove(0, sb.Length)
            With Item
                idx = .NumeroDocumento.IndexOf("-")
                If idx > -1 Then
                    serie = .NumeroDocumento.Substring(0, idx)
                    If serie.Length < 4 Then
                        serie = serie.PadLeft(4, "0")
                    End If
                    numeroDocumento = .NumeroDocumento.Substring(idx + 1)
                    .NumeroDocumento = String.Concat(serie, "-", numeroDocumento)
                End If


                Dim documentoRelacionado As New ItemRetencion()
                documentoRelacionado.TipoDocumento = Integer.Parse(.CodigoDocumento).ToString("00")
                documentoRelacionado.NroDocumento = .NumeroDocumento
                documentoRelacionado.FechaEmision = .FechaDocumento.ToShortDateString()
                documentoRelacionado.ImporteTotal = .ImporteIni
                documentoRelacionado.MonedaDocumentoRelacionado = .Moneda
                documentoRelacionado.FechaPago = Retencion.FechaEmision.ToShortDateString()
                documentoRelacionado.NumeroPago = .NumeroPago
                documentoRelacionado.ImporteSinRetencion = .ImporteDocumento
                documentoRelacionado.ImporteRetenido = .ImporteRetencion
                documentoRelacionado.FechaRetencion = Retencion.FechaEmision.ToShortDateString()
                documentoRelacionado.ImporteTotalNeto = .TotalPagado
                documentoRelacionado.FechaTipoCambio = Retencion.FechaEmision.ToShortDateString()
                documentoRelacionado.TipoCambio = Retencion.TipoCambio
                documentosRelacionados(count) = documentoRelacionado
                count += 1

            End With
        Next

        documentoRetencion.DocumentosRelacionados = documentosRelacionados

        'Enviar a sunat
        Dim response As EnviarDocumentoResponse = EnviarDocumentoSunat(documentoRetencion, ruta, Cliente.Email, emailContacto)

        If response.Exito And Not String.IsNullOrEmpty(response.TramaZipCdr) Then
            If response.CodigoRespuesta = 0 Then
                With Retencion
                    ActualizarEstadoDeEnvio(.Auxiliar, .CodigoComprobante, .NumeroComprobante, .Año, .Mes)
                End With
            ElseIf response.CodigoRespuesta >= 4000 Then
                With Retencion
                    ActualizarEstadoDeEnvio(.Auxiliar, .CodigoComprobante, .NumeroComprobante, .Año, .Mes)
                End With

                Observado = New STNoEnviado

                Observado.NumeroDocumento = Retencion.NumeroDocumento
                Observado.Mensaje = "Codigo: " & response.CodigoRespuesta & "  Mensaje: " & response.MensajeError
                ListaObservados.Add(Observado)
            ElseIf response.CodigoRespuesta >= 2000 And response.CodigoRespuesta <= 3999 Then
                Rechazado = New STNoEnviado
                Rechazado.NumeroDocumento = Retencion.NumeroDocumento
                Rechazado.Mensaje = "Codigo: " & response.CodigoRespuesta & "  Mensaje: " & response.MensajeError
                ListaRechazados.Add(Rechazado)
            End If
        Else
            noEnviado = New STNoEnviado
            noEnviado.NumeroDocumento = Retencion.NumeroDocumento
            noEnviado.Mensaje = "Codigo: " & response.CodigoRespuesta & "  Mensaje: " & response.MensajeError
            ListaNoEnviados.Add(noEnviado)
        End If

    End Sub

    ''' <summary>
    ''' Método para el envío de Documentos a Sunat
    ''' </summary>
    ''' <param name="documentoRetencion">Documento a enviar a Sunat</param>
    ''' <param name="ruta">Ubicación de almacenamiento de los xml generados</param>
    ''' <remarks></remarks>
    Function EnviarDocumentoSunat(ByVal documentoRetencion As DocumentoRetencion, ByVal ruta As String, ByVal emailCliente As String, ByVal emailContacto As String) As EnviarDocumentoResponse

        Dim client As New FacturacionServices
        Dim documentoResponse As New DocumentoResponse
        Dim rpta As New EnviarDocumentoResponse

        If My.Settings.PruebaFE = False Then
            UsuarioSol = OBJ.DIR_TABLA_DESC("USUSOL", "TDEFA")
            ClaveSol = OBJ.DIR_TABLA_DESC("PASSOL", "TDEFA")
        Else
            UsuarioSol = "MODDATOS"
            ClaveSol = "MODDATOS"
        End If

        Smtp = OBJ.DIR_TABLA_DESC("SMTPCO", "TDEFA")
        PuertoSmpt = Integer.Parse(OBJ.DIR_TABLA_DESC("SMTPPT", "TDEFA"))

        documentoResponse = client.GenerarRetencion(documentoRetencion)

        If documentoResponse.Exito Then
            Dim firmaRequest As New FirmadoRequest()
            With firmaRequest
                .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma
                .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(CertificadoDigital))
                .PasswordCertificado = PasswordCertificadoDigital
                .UnSoloNodoExtension = True

            End With

            Dim firmaResponse As FirmadoResponse = client.Firmar(firmaRequest)
            If firmaResponse.Exito Then
                Dim enviarDocumentoRequest As New EnviarDocumentoRequest()

                With enviarDocumentoRequest
                    .Ruc = documentoRetencion.Emisor.NroDocumento
                    .UsuarioSol = UsuarioSol
                    .ClaveSol = ClaveSol
                    .EndPointUrl = My.Settings.UrlEnvioRetencion
                    .IdDocumento = documentoRetencion.IdDocumento
                    .TipoDocumento = "20"
                    .TramaXmlFirmado = firmaResponse.TramaXmlFirmado
                    .RutaCdr = RutaCdr
                    .RutaXml = RutaXml
                    .RutaPdf = RutaPdf
                    .RutaImagen = RutaImagen
                    .EmailEmisor = EmailEmisor
                    .PasswordEmisor = PassEmisor
                    .EmailCliente = String.Format("{0},{1}", emailCliente, emailContacto) 'Falta el correo del contacto
                    .NombreEmpresa = DESC_EMPRESA
                    .WebEmpresa = WebEmpresa
                    .FechaEmision = documentoRetencion.FechaEmision
                    .TotalDocumento = documentoRetencion.ImporteTotalPagado
                    .Moneda = documentoRetencion.Moneda
                    .Smpt = Smtp
                    .PuertoSmtp = PuertoSmpt
                End With

                

                Dim respuestaEnvio As RespuestaComunConArchivo = client.EnviarDocumento(enviarDocumentoRequest)

                rpta = CType(respuestaEnvio, EnviarDocumentoResponse)

                If rpta.Exito And Not String.IsNullOrEmpty(rpta.TramaZipCdr) Then
                    If rpta.CodigoRespuesta = 0 Or rpta.CodigoRespuesta >= 4000 Then
                        If GenerarCodigoBarras(documentoRetencion, firmaResponse) = False Then
                            Observado = New STNoEnviado
                            Observado.NumeroDocumento = documentoRetencion.IdDocumento
                            Observado.Mensaje = "No se pudo generar el codigo de barras - No se enviaron los correos"
                            ListaObservados.Add(Observado)
                            'MessageBox.Show("No se pudo generar el codigo de barras - No se enviaron los correos", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Dim responseEmail As ResponseGenerador = client.EnviarMail(enviarDocumentoRequest)
                            If Not responseEmail.Exito Then
                                Observado = New STNoEnviado
                                Observado.NumeroDocumento = documentoRetencion.IdDocumento
                                Observado.Mensaje = "No se enviaron los correos"
                                ListaObservados.Add(Observado)
                                'MessageBox.Show("No se enviaron los correos", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End If
                    End If
                End If

            Else
                rpta.MensajeError = firmaResponse.MensajeError
            End If
        Else
            rpta.MensajeError = documentoResponse.MensajeError
        End If

        Return rpta

    End Function

    Public Function GenerarCodigoBarras(ByVal documento As DocumentoRetencion, ByVal firmaResponse As FirmadoResponse) As Boolean
        Try
            Dim client As New FacturacionServices
            Dim codigoTexto As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", documento.Emisor.NroDocumento, _
            "20", documento.IdDocumento, documento.ImporteTotalPagado, documento.FechaEmision, _
            documento.Receptor.TipoDocumento, documento.Receptor.NroDocumento, firmaResponse.ResumenFirma, firmaResponse.ValorFirma)

            Dim codigoBarrasrequest As New CodigoBarrasRequest()
            codigoBarrasrequest.TextoCodigo = codigoTexto
            codigoBarrasrequest.PathArchivoPdf = String.Format("{0}/{1}-{2}.pdf", RutaPdf, documento.IdDocumento, "20")
            codigoBarrasrequest.ValorResumen = firmaResponse.ResumenFirma
            codigoBarrasrequest.IdDocumento = documento.IdDocumento

            Dim response As CodigoBarrasResponse = client.GenerarCodigoBarrasPDF417(codigoBarrasrequest)

            Return response.Exito
        Catch ex As Exception
            Return False
        End Try


    End Function

    Private Sub lblRechazados_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblRechazados.LinkClicked
        Dim frm As New Form
        frm.Text = "Lista de documentos rechazados"
        Dim dgv As New DataGridView
        Dim col2, col3, col4 As New DataGridViewTextBoxColumn

        col2.HeaderText = "N° Doc."
        col2.Width = 90
        col3.HeaderText = "Mensaje"
        col3.Width = 300

        dgv.Columns.Add(col2)
        dgv.Columns.Add(col3)
        dgv.Dock = DockStyle.Fill
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.RowHeadersVisible = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For Each item As STNoEnviado In ListaRechazados
            dgv.Rows.Add(item.NumeroDocumento, item.Mensaje)
        Next
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.Size = New Size(516, 300)
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Controls.Add(dgv)

        frm.ShowDialog()
    End Sub

    Private Sub lblObservados_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblObservados.LinkClicked
        Dim frm As New Form
        frm.Text = "Lista de documentos observados"
        Dim dgv As New DataGridView
        Dim col2, col3, col4 As New DataGridViewTextBoxColumn

        col2.HeaderText = "N° Doc."
        col2.Width = 90
        col3.HeaderText = "Mensaje"
        col3.Width = 300

        dgv.Columns.Add(col2)
        dgv.Columns.Add(col3)
        dgv.Dock = DockStyle.Fill
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.RowHeadersVisible = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For Each item As STNoEnviado In ListaObservados
            dgv.Rows.Add(item.NumeroDocumento, item.Mensaje)
        Next
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.Size = New Size(516, 300)
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Controls.Add(dgv)

        frm.ShowDialog()
    End Sub

    Private Sub dgvRetencionesEnviada_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetencionesEnviada.CellContentClick
        If e.ColumnIndex = 16 Then
            Dim codigoDocumento As Integer
            Dim numeroDocumento As String
            codigoDocumento = "20"
            numeroDocumento = String.Format("{0}", Me.dgvRetencionesEnviada.Rows(e.RowIndex).Cells(6).Value)
            RutaPdf = OBJ.DIR_TABLA_DESC("FILPDF", "TDEFA")
            UsuarioSol = OBJ.DIR_TABLA_DESC("USUSOL", "TDEFA")
            ClaveSol = OBJ.DIR_TABLA_DESC("PASSOL", "TDEFA")
            Try
                Dim client As New FacturacionServices

                Dim constanciaRequest As New ConsultaConstanciaRequest()
                With constanciaRequest
                    .Ruc = RUC_EMPRESA
                    .UsuarioSol = UsuarioSol
                    .ClaveSol = ClaveSol
                    .EndPointUrl = "https://www.sunat.gob.pe:443/ol-it-wsconscpegem/billConsultService"
                    .TipoDocumento = codigoDocumento
                    .Serie = numeroDocumento.Substring(0, 4)
                    .Numero = numeroDocumento.Substring(5, 8)
                End With

                Dim response As EnviarDocumentoResponse = client.ConsultarCDR(constanciaRequest)

                If response.Exito And Not String.IsNullOrEmpty(response.MensajeRespuesta) Then
                    If response.MensajeRespuesta.Equals("Aun en proceso") Then
                        MessageBox.Show("El pdf aun no ha sido generado, el documento de encuentra en proceso", "Gestion Comercial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        RutaCdr = OBJ.DIR_TABLA_DESC("FILCDR", "TDEFA")

                        Dim dialog As DialogResult = MessageBox.Show(String.Format("{0}{1} ¿Desea abrir el documento?", response.MensajeRespuesta, Environment.NewLine), "Gestion Comercial", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                        File.WriteAllBytes(String.Format("{0}\CDR-{1}-{2}.zip", RutaCdr, numeroDocumento, codigoDocumento), Convert.FromBase64String(response.TramaZipCdr))
                        If dialog = Windows.Forms.DialogResult.Yes Then
                            RutaPdf = OBJ.DIR_TABLA_DESC("FILPDF", "TDEFA")
                            Using frm As New Form
                                Dim archivo As String = String.Format("{0}\{1}-{2}.pdf", RutaPdf, numeroDocumento, codigoDocumento)

                                If File.Exists(archivo) Then
                                    Dim wb As New WebBrowser
                                    ' System.Diagnostics.Process.Start(String.Format("{0}\{1}-{2}.pdf", RutaPdf, numeroDocumento, codigoDocumento))
                                    wb.Dock = DockStyle.Fill
                                    wb.Url = New Uri(archivo)
                                    frm.Controls.Add(wb)
                                    frm.WindowState = FormWindowState.Maximized
                                    frm.ShowDialog()
                                Else
                                    MessageBox.Show("El pdf del documento no existe", "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                            End Using
                        End If
                    End If
                Else
                    MessageBox.Show(response.MensajeRespuesta, "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnEstadoEnviado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstadoEnviado.Click
        Dim algunSeleccionado As Boolean = False
        For Each row As DataGridViewRow In dgvRetencionesPendiente.Rows
            If row.Cells(16).Value = True Then
                algunSeleccionado = True
                Exit For
            End If
        Next

        If algunSeleccionado Then
            Dim dialog As DialogResult = MessageBox.Show("¿Está seguro de actualizar el estado de envío?", "Gestión comercial", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = Windows.Forms.DialogResult.Yes Then
                For Each row As DataGridViewRow In dgvRetencionesPendiente.Rows
                    If row.Cells(16).Value = True Then
                        ActualizarEstadoDeEnvio(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, _
                        row.Cells(4).Value)
                    End If
                Next
                MessageBox.Show("Status enviado actualizado correctamente", "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarRetencionesEnviadas()
                CargarRetencionesPendientes()
            End If

        Else
            MessageBox.Show("No seleccionó ningún registro", "Gestión comercial", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class