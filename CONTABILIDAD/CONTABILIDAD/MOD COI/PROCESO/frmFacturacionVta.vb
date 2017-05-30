Imports System.Data.SqlClient
Imports System.IO

Public Class frmFacturacionVta
#Region "Variables"
    Private loPleFactVentas As New List(Of pleFactVentas)
    Private _consultar As Boolean
    Private Obj As New Class1
#End Region

#Region "Estructura"

    Public Structure pleFactVentas
        Public MotivoContingencia As String
        Public FechaEmision As Date
        Public TipoPago As String
        Public NroSerieComprobante As String
        Public NroComprobante As String
        Public Ticket As String
        Public TipoDocPersona As String
        Public NroDocPersona As String
        Public DescPersona As String
        Public TotalValorVentaGravada As Decimal
        Public TotalValorVentaExonerada As Decimal
        Public TotalValorVentaInafecta As Decimal
        Public Isc As Decimal
        Public Igv As Decimal
        Public Otros As Decimal
        Public ImporteTotal As Decimal
        Public TipoComprobanteModifica As String
        Public SerieComprobanteModifica As String
        Public NroComprobanteModifica As String
    End Structure

#End Region

#Region "Constructor"
    Private Shared instancia As New frmFacturacionVta
    Public Shared Function ObtenerInstancia() As frmFacturacionVta
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmFacturacionVta
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

#Region "Metodos"
    Private Sub ConsultarPle()
        Try
            loPleFactVentas.Clear()
            Using cmd As New SqlCommand("MOSTRAR_PLE_FACTURAS_DIARIO", con)
                cmd.CommandType = CommandType.StoredProcedure
                Dim par0 As SqlParameter = cmd.Parameters.Add("@DIADEL", SqlDbType.Date)
                Dim par1 As SqlParameter = cmd.Parameters.Add("@DIAHASTA", SqlDbType.Date)
                par0.Value = dtpFechaDel.Value.Date
                par1.Value = dtpFechaAl.Value.Date
                '--
                Dim dsPDB As New DataSet
                Dim DA_PDB As New SqlDataAdapter(cmd)
                DA_PDB.Fill(dsPDB)
                Dim drd As DataRow
                Dim ObePla As pleFactVentas
                Dim I, J, x As Integer
                Dim idx As Integer = 0
                Dim pos As String
                '--
                'Recorremos el datadapter
                For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                    drd = dsPDB.Tables(0).Rows(I)
                    ObePla = New pleFactVentas
                    With ObePla
                        .MotivoContingencia = "7"
                        .FechaEmision = drd("FECHA_DOC")
                        .TipoPago = drd("COD_DOC")
                        'Para la serie del comprobante
                        idx = drd("NRO_DOC").ToString.IndexOf("-")
                        If idx > 0 Then
                            '.NroSerieComprobante = Convert.ToInt32(drd("NRO_DOC").ToString.Substring(0, idx)).ToString("0000")
                            If (IsNumeric(drd("NRO_DOC").ToString.Substring(0, 1))) Then
                                .NroSerieComprobante = Convert.ToInt32(drd("NRO_DOC").ToString.Substring(0, idx)).ToString("0000")
                            Else
                                .NroSerieComprobante = drd("NRO_DOC").ToString.Substring(0, idx)
                            End If
                            .NroComprobante = drd("NRO_DOC").ToString.Substring(idx + 1)
                        Else
                            .NroComprobante = drd("NRO_DOC")
                            .NroSerieComprobante = "-"
                        End If
                        idx = 0
                        .Ticket = ""
                        .TipoDocPersona = IIf(drd("COD_DOC_PER").ToString.Trim = "-", "0", Integer.Parse(drd("COD_DOC_PER")))
                        If drd("COD_DOC_PER").ToString.Trim = "-" Then
                            .TipoDocPersona = "0"
                        Else

                            .TipoDocPersona = Integer.Parse(drd("COD_DOC_PER"))
                        End If
                        .NroDocPersona = drd("NRO_DOC_PER")
                        .DescPersona = drd("DESC_PER")
                        x = 0
                        Dim valor As Integer = 1
                        'If drd("COD_DOC") = "07" OrElse drd("COD_DOC") = "87" OrElse drd("COD_DOC") = "97" Then
                        '    valor = -1
                        'End If
                        For J = 8 To 17
                            x += 1
                            If drd(J) > 0 Then
                                pos = Obj.DIR_TABLA_DESC(String.Format("V{0}", x.ToString("00")), "TPLE")
                                If pos = "BASE1" Then
                                    .TotalValorVentaGravada += drd(J) * valor
                                ElseIf pos = "EXPORTACION" Then
                                    .TotalValorVentaInafecta += drd(J) * valor
                                ElseIf pos = "EXONERADA" Then
                                    .TotalValorVentaExonerada += drd(J) * valor
                                ElseIf pos = "IGV" Then
                                    .Igv += drd(J) * valor
                                ElseIf pos = "OTROS" Then
                                    .Otros += drd(J) * valor
                                End If
                            End If
                        Next

                        '.TotalValorVentaGravada = 0
                        '.TotalValorVentaExonerada = 0
                        '.TotalValorVentaInafecta = 0
                        '.Isc = 0
                        '.Igv = 0 '
                        '.Otros = 0
                        '-------------
                        '-------------
                        .ImporteTotal = .TotalValorVentaInafecta + .TotalValorVentaGravada + .TotalValorVentaExonerada + .Isc + +.Otros + .Igv
                        'drd(15)
                        If .TipoPago = "07" And .DescPersona <> "ANULADO" Then
                            idx = drd("NRO_REF").ToString.IndexOf("-")
                            If idx > 0 Then
                                .TipoComprobanteModifica = drd("COD_REF")
                                '.SerieComprobanteModifica = Convert.ToInt32(drd("NRO_REF").ToString.Substring(0, idx)).ToString("0000")
                                If (IsNumeric(drd("NRO_REF").ToString.Substring(0, 1))) Then
                                    .SerieComprobanteModifica = Convert.ToInt32(drd("NRO_REF").ToString.Substring(0, idx)).ToString("0000")
                                Else
                                    .SerieComprobanteModifica = drd("NRO_REF").ToString.Substring(0, idx)
                                End If
                                .NroComprobanteModifica = drd("NRO_REF").ToString.Substring(idx + 1)
                            Else
                                MessageBox.Show("Hay una inconsistencia en el documento : " + drd("NRO_DOC"))
                            End If
                        Else
                            .TipoComprobanteModifica = ""
                            .SerieComprobanteModifica = ""
                            .NroComprobanteModifica = ""
                        End If
                        idx = 0
                    End With
                    loPleFactVentas.Add(ObePla)
                Next

            End Using
            _consultar = True
        Catch ex As Exception
            _consultar = False
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
#End Region

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If dtpFechaDel.Value.Date > FECHA_GRAL Or dtpFechaAl.Value.Date > FECHA_GRAL Then
            MessageBox.Show("El rango de fechas no puede ser mayor a la fecha de proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        dgvDatos.Rows.Clear()
        ConsultarPle()
        If loPleFactVentas.Count = 0 AndAlso _consultar Then
            MessageBox.Show("No existen registros de la fecha selecionada", "Aviso")
        End If
        Dim i As Integer
        For i = 0 To loPleFactVentas.Count - 1
            With loPleFactVentas.Item(i)
                dgvDatos.Rows.Add(.MotivoContingencia, _
                                  .FechaEmision.ToShortDateString(), _
                                  .TipoPago, _
                                  .NroSerieComprobante, _
                                  .NroComprobante, _
                                  .Ticket, _
                                  .TipoDocPersona, _
                                  .NroDocPersona, _
                                  .DescPersona, _
                                  .TotalValorVentaGravada, _
                                  .TotalValorVentaExonerada, _
                                  .TotalValorVentaInafecta, _
                                  .Isc, _
                                  .Igv, _
                                  .Otros, _
                                  .ImporteTotal, _
                                  .TipoComprobanteModifica, _
                                  .SerieComprobanteModifica, _
                                  .NroComprobanteModifica)
            End With
        Next
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("{0}-RF-{1}-01.txt", RUC_EMPRESA, dtpFechaDel.Value.Date.Day.ToString("00") & dtpFechaDel.Value.Date.Month.ToString("00") & dtpFechaDel.Value.Date.Year) '= String.Format("LE{0}{1}{2}00140100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    ' Dim aux As Integer
                    ''sw.WriteLine("Tipo Venta|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPleFactVentas.Count - 1
                        With loPleFactVentas(i)

                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|", _
                            .MotivoContingencia, _
                            .FechaEmision.ToShortDateString(), _
                            .TipoPago, _
                            .NroSerieComprobante, _
                            .NroComprobante, _
                            .Ticket, _
                            .TipoDocPersona, _
                            .NroDocPersona, _
                            .DescPersona, _
                            .TotalValorVentaGravada, _
                            .TotalValorVentaExonerada, _
                            .TotalValorVentaInafecta, _
                            .Isc, _
                            .Igv, _
                            .Otros, _
                            .ImporteTotal, _
                            .TipoComprobanteModifica, _
                            .SerieComprobanteModifica, _
                            .NroComprobanteModifica _
                        ))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class