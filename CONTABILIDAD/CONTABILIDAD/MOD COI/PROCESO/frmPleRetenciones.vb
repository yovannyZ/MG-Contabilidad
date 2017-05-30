Imports System.Data.SqlClient
Imports System.IO
Public Class frmPleRetenciones
    Dim obj As New Class1
    Private LoPleRetenciones As New List(Of PLERetenciones)
    Private LoPleRetencionesFinal As New List(Of PLERetenciones)
    Dim _consultar As Boolean

#Region "Singleton"

    Private Shared instancia As frmPleRetenciones

    Public Shared Function ObtenerInstancia() As frmPleRetenciones
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmPleRetenciones
        End If
        instancia.BringToFront()
        Return instancia
    End Function

#End Region
#Region "Estructura"

    Public Structure PLERetenciones
        Public MotivoContingencia As String
        Public SerieComprobanteRetencion As String
        Public NumeroComprobanteRetencion As String
        Public FechaEmisionComprobante As Date
        '--
        Public RucProveedor As String
        Public TipoDocumentoProveedor As String
        Public DescripcionProveedor As String
        '--
        Public RegimenRetencion As String
        Public TasaRetencion As String
        Public ImporteTotalRetenido As Double
        Public ImporteTotalPagado As Double
        '--
        Public TipoDocumentoRelacionado As String
        Public SerieDocumentoRelacionado As String
        Public NumeroDocumentoRelacionado As String
        Public FechaEmisionDocumentoRelacionado As Date
        Public ImporteTotalDocumentoRelacionado As String
        Public MonedaTotalImporteDocumentoRelacionado As String
        '--
        Public FechaPago As Date
        Public NumeroPago As String
        Public ImportePago As Double
        Public MonedaImportePago As String
        '--
        Public ImporteRetenido As String
        Public FechaRetencion As Date
        Public ImporteTotalNeto As String
        '--
        Public MonedaExtranjera As String
        Public TipoCambio As String
        Public FechaTipoCambio As Date
        '--
        Public CodigoAuxiliar As String
        Public CodigoComprobante As String
        Public NumeroComprobante As String
    End Structure

#End Region
#Region "Metodos"

    Private Function CargarRetenciones() As List(Of PLERetenciones)
        LoPleRetenciones.Clear()
        Dim loPle As New List(Of PLERetenciones)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PLE_RETENCIONES", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = dtpFecha.Value.Date
            'Parametros para leer los datos
            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)
            '---------------------
            Dim I As Integer
            Dim ObePle As PLERetenciones
            Dim dr, dra As DataRow
            Dim indice As Integer
            Dim sec As Integer
            For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                dr = dsPDB.Tables(0).Rows(I) 'Fila del registro actual
                If (I = 0) Then
                    dra = dsPDB.Tables(0).Rows(I) 'Fila del registro siguiente
                Else
                    dra = dsPDB.Tables(0).Rows(I - 1) 'Fila del registro siguiente
                End If
                ObePle = New PLERetenciones
                With ObePle
                    indice = dr(0).ToString.IndexOf("-")
                    .MotivoContingencia = "6"
                    .SerieComprobanteRetencion = "0" + dr(0).ToString.Substring(0, indice)
                    .NumeroComprobanteRetencion = dr(0).ToString.Substring(indice + 1)
                    .FechaEmisionComprobante = CDate(dr(1)).ToShortDateString

                    .RucProveedor = dr(2)
                    .TipoDocumentoProveedor = dr(3)
                    .DescripcionProveedor = dr(4)

                    .RegimenRetencion = dr(5)
                    .TasaRetencion = obj.HACER_DECIMAL(dr(6))
                    .ImporteTotalRetenido = CDbl(dr(7))
                    .ImporteTotalPagado = CDbl(dr(8))

                    .TipoDocumentoRelacionado = dr(9)
                    indice = dr(10).ToString.IndexOf("-")
                    '.SerieDocumentoRelacionado =  dr(10).ToString.Substring(0, indice)
                    If (dr(9) = "01" Or dr(9) = "03" Or dr(9) = "07" Or dr(9) = "08") Then
                        If (dr(10).ToString.Substring(0, indice).Length = 3) Then
                            .SerieDocumentoRelacionado = "0" + dr(10).ToString.Substring(0, indice)
                        ElseIf (dr(10).ToString.Substring(0, indice).Length = 2) Then
                            .SerieDocumentoRelacionado = "00" + dr(10).ToString.Substring(0, indice)
                        Else
                            .SerieDocumentoRelacionado = dr(10).ToString.Substring(0, indice)
                        End If
                    Else
                        .SerieDocumentoRelacionado = dr(10).ToString.Substring(0, indice)
                    End If
                    .NumeroDocumentoRelacionado = dr(10).ToString.Substring(indice + 1)
                    .FechaEmisionDocumentoRelacionado = CDate(dr(11)).ToShortDateString
                    .ImporteTotalDocumentoRelacionado = CDbl(dr(12))
                    If (dr(13).ToString.ToUpper = "S") Then
                        .MonedaTotalImporteDocumentoRelacionado = "PEN"
                    Else
                        .MonedaTotalImporteDocumentoRelacionado = "USD"
                    End If

                    .FechaPago = CDate(dr(14)).ToShortDateString
                    If (I = 0) Then
                        sec = 1
                        .NumeroPago = sec
                    Else
                        If (dr(0).ToString = dra(0).ToString) Then
                            sec += 1
                            .NumeroPago = sec
                        Else
                            sec = 1
                            .NumeroPago = sec
                        End If
                    End If
                    .ImportePago = dr(15)
                    If (dr(16).ToString.ToUpper = "S") Then
                        .MonedaImportePago = "PEN"
                    Else
                        .MonedaImportePago = "USD"
                    End If

                    .ImporteRetenido = dr(17)
                    .FechaRetencion = CDate(dr(18)).ToShortDateString
                    .ImporteTotalNeto = obj.HACER_DECIMAL(dr(19))

                    If (dr(20).ToString.ToUpper = "S") Then
                        .MonedaExtranjera = "PEN"
                    Else
                        .MonedaExtranjera = "USD"
                    End If
                    .TipoCambio = dr(21)
                    .FechaTipoCambio = CDate(dr(22)).ToShortDateString
                    .CodigoAuxiliar = dr(23)
                    .CodigoComprobante = dr(24)
                    .NumeroComprobante = dr(25)
                    indice = 0
                End With
                LoPleRetenciones.Add(ObePle)
            Next
            _consultar = True
        Catch ex As Exception
            _consultar = False
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        Return LoPleRetenciones
    End Function

    Private Sub CargarRetencionesDiarias()
        LoPleRetencionesFinal.Clear()
        Dim loPle As List(Of PLERetenciones) = CargarRetenciones()
        If loPle.Count > 0 Then
            Dim i As Integer
            Dim obPle As PLERetenciones
            For i = 0 To loPle.Count - 1
                obPle = New PLERetenciones
                With obPle
                    .MotivoContingencia = loPle.Item(i).MotivoContingencia
                    .SerieComprobanteRetencion = loPle.Item(i).SerieComprobanteRetencion
                    .NumeroComprobanteRetencion = loPle.Item(i).NumeroComprobanteRetencion
                    .FechaEmisionComprobante = loPle.Item(i).FechaEmisionComprobante
                    .RucProveedor = loPle.Item(i).RucProveedor
                    .TipoDocumentoProveedor = "6"
                    .DescripcionProveedor = loPle.Item(i).DescripcionProveedor
                    .RegimenRetencion = loPle.Item(i).RegimenRetencion
                    .TasaRetencion = loPle.Item(i).TasaRetencion
                    .ImporteTotalRetenido = loPle.Item(i).ImporteTotalRetenido
                    .ImporteTotalPagado = loPle.Item(i).ImporteTotalPagado
                    .TipoDocumentoRelacionado = loPle.Item(i).TipoDocumentoRelacionado
                    .SerieDocumentoRelacionado = loPle.Item(i).SerieDocumentoRelacionado
                    .NumeroDocumentoRelacionado = loPle.Item(i).NumeroDocumentoRelacionado
                    .FechaEmisionDocumentoRelacionado = loPle.Item(i).FechaEmisionDocumentoRelacionado
                    .ImporteTotalDocumentoRelacionado = loPle.Item(i).ImporteTotalDocumentoRelacionado
                    .MonedaTotalImporteDocumentoRelacionado = loPle.Item(i).MonedaTotalImporteDocumentoRelacionado
                    .FechaPago = loPle.Item(i).FechaPago
                    .NumeroPago = loPle.Item(i).NumeroPago
                    .ImportePago = loPle.Item(i).ImportePago
                    .MonedaImportePago = loPle.Item(i).MonedaImportePago
                    .ImporteRetenido = loPle.Item(i).ImporteRetenido
                    .FechaRetencion = loPle.Item(i).FechaRetencion
                    .ImporteTotalNeto = loPle.Item(i).ImporteTotalNeto.ToString.Replace(",", "")
                    .MonedaExtranjera = loPle.Item(i).MonedaExtranjera
                    .TipoCambio = loPle.Item(i).TipoCambio
                    .FechaTipoCambio = loPle.Item(i).FechaTipoCambio
                    .CodigoAuxiliar = loPle.Item(i).CodigoAuxiliar
                    .CodigoComprobante = loPle.Item(i).CodigoComprobante
                    .NumeroComprobante = loPle.Item(i).NumeroComprobante
                End With
                LoPleRetencionesFinal.Add(obPle)
            Next
        End If
        _consultar = True
    End Sub
#End Region



    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        'If cboAño.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cboAño.Focus() : Exit Sub
        'If cboMes.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cboMes.Focus() : Exit Sub

        dgvDatos.Rows.Clear()
        'CargarRetenciones(dtpFecha.Value) '(cboAño.Text, cboMes.Text)
        CargarRetencionesDiarias()
        If LoPleRetencionesFinal.Count = 0 AndAlso _consultar Then
            MessageBox.Show("No hay registros a mostrar", "Aviso", MessageBoxButtons.OK)
        Else
            Dim i As Integer

            For i = 0 To LoPleRetencionesFinal.Count - 1
                With LoPleRetencionesFinal.Item(i)
                    dgvDatos.Rows.Add(.MotivoContingencia, .SerieComprobanteRetencion, .NumeroComprobanteRetencion, .FechaEmisionComprobante.ToShortDateString, _
                                      .RucProveedor, .TipoDocumentoProveedor, .DescripcionProveedor, _
                                      .RegimenRetencion, .TasaRetencion, .ImporteTotalRetenido, .ImporteTotalPagado, _
                                      .TipoDocumentoRelacionado, .SerieDocumentoRelacionado, .NumeroDocumentoRelacionado, .FechaEmisionDocumentoRelacionado.ToShortDateString, .ImporteTotalDocumentoRelacionado, .MonedaTotalImporteDocumentoRelacionado, _
                                      .FechaPago.ToShortDateString, .NumeroPago, .ImportePago, .MonedaImportePago, _
                                      .ImporteRetenido, .FechaRetencion.ToShortDateString, .ImporteTotalNeto, _
                                      .MonedaExtranjera, .TipoCambio, .FechaTipoCambio.ToShortDateString, _
                                      .CodigoAuxiliar, .CodigoComprobante, .NumeroComprobante)
                End With
            Next
        End If
    End Sub

    Private Sub frmPleRetenciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CargarAño()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("{0}-20-{1}-1.txt", RUC_EMPRESA, dtpFecha.Value.Year & dtpFecha.Value.Month.ToString("00") & dtpFecha.Value.Day.ToString("00")) 'cboAño.Text, obj.COD_MES(cboMes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", fbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    For i = 0 To LoPleRetenciones.Count - 1
                        With LoPleRetenciones(i)
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen.Replace("$", "D") & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Plan, .Cuenta, .Emision.ToShortDateString(), .Glosa, _
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|", _
                                      .MotivoContingencia, _
                                      .SerieComprobanteRetencion, _
                                      .NumeroComprobanteRetencion, _
                                      .FechaEmisionComprobante.ToShortDateString, _
                                      .RucProveedor, _
                                      .TipoDocumentoProveedor, _
                                      .DescripcionProveedor, _
                                      .RegimenRetencion, _
                                      .TasaRetencion, _
                                      obj.HACER_DECIMAL(.ImporteTotalRetenido).ToString.Replace(",", ""), _
                                      obj.HACER_DECIMAL(.ImporteTotalPagado).ToString.Replace(",", ""), _
                                      .TipoDocumentoRelacionado, _
                                      .SerieDocumentoRelacionado, _
                                      .NumeroDocumentoRelacionado, _
                                      .FechaEmisionDocumentoRelacionado.ToShortDateString, _
                                      obj.HACER_DECIMAL(.ImporteTotalDocumentoRelacionado).Replace(",", ""), _
                                      .MonedaTotalImporteDocumentoRelacionado, _
                                      .FechaPago.ToShortDateString, _
                                      .NumeroPago, _
                                      obj.HACER_DECIMAL(.ImportePago).ToString.Replace(",", ""), _
                                      .MonedaImportePago, _
                                      obj.HACER_DECIMAL(.ImporteRetenido).Replace(",", ""), _
                                      .FechaRetencion.ToShortDateString, _
                                      obj.HACER_DECIMAL(.ImporteTotalNeto).Replace(",", ""), _
                                     IIf(.MonedaExtranjera = "PEN", "", .MonedaExtranjera), _
                                      IIf(.MonedaExtranjera = "PEN", "", .TipoCambio), _
                                      IIf(.MonedaExtranjera = "PEN", "", .FechaTipoCambio.ToShortDateString)))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", fbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub
End Class