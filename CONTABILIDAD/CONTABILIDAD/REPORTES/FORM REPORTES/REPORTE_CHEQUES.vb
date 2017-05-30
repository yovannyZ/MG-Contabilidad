Imports System.Data.SqlClient
Imports system.Drawing.Printing
Imports System.IO
Imports System.Xml
Public Class REPORTE_CHEQUES
    Public Structure Referencia
        Public Cheque, Documento, Numero, Fecha, MonedaCheque, Moneda As String
        Public Importe, TipoCambio As Decimal
    End Structure

    Private OBJ As New Class1
    Private WithEvents oImpresion As New PrintDocument
    Private WithEvents oImpresionRef As New PrintDocument
    Private NroMp, Persona, Importe, ImporteText As String
    Private Fecha, FechaPago As Date
    Private lReferencia As New List(Of Referencia)
    Private Fila As Integer = 0
    Private oXML As New XmlDocument
    Private Nodo As XmlNode
    Private oAltoCheque, oAnchoPapel, oAnchoCheque As Integer
    Private Archivo As String = String.Format("{0}/servidor/Cheques.xml", Application.StartupPath)
    Private vPlg As Double = 0.0394  '1 milimetro = 0.0393700787".
    Private p1, p2, p3, p4, p5, p6, p7, p8, p9 As String
    Private Diferido As Boolean

    Sub CARGAR_AÑO()
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
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    ' Convierte a Centecimas d pulgada
    Private Function CentPlg(ByVal valor As Double) As Integer
        Return Math.Ceiling(valor * vPlg * 100)
    End Function
    Private Function ObtenerConfiguracion(ByVal Formato00 As String) As Boolean
        Dim Formato As String = Formato00
        If Diferido Then
            Formato = String.Format("{0}1", Formato)
        End If
        Dim nodoResultado As XmlNode = _
                oXML.DocumentElement.SelectSingleNode( _
                String.Format("//Banco[Formato={0}]", Formato))
        If nodoResultado IsNot Nothing Then
            Nodo = nodoResultado
            If Formato = Nodo.ChildNodes(0).FirstChild.Value Then
                oAnchoPapel = CentPlg(Nodo.ChildNodes(1).FirstChild.Value)
                oAnchoCheque = CentPlg(Nodo.ChildNodes(2).FirstChild.Value)
                oAltoCheque = CentPlg(Nodo.ChildNodes(3).FirstChild.Value)
                p1 = Nodo.ChildNodes(4).FirstChild.Value
                p2 = Nodo.ChildNodes(5).FirstChild.Value
                p3 = Nodo.ChildNodes(6).FirstChild.Value
                p4 = Nodo.ChildNodes(7).FirstChild.Value
                p5 = Nodo.ChildNodes(8).FirstChild.Value
                p6 = Nodo.ChildNodes(9).FirstChild.Value
                If Diferido Then
                    If Nodo.ChildNodes(10) IsNot Nothing _
                    AndAlso Nodo.ChildNodes(11) IsNot Nothing _
                    AndAlso Nodo.ChildNodes(12) IsNot Nothing Then
                        p7 = Nodo.ChildNodes(10).FirstChild.Value
                        p8 = Nodo.ChildNodes(11).FirstChild.Value
                        p9 = Nodo.ChildNodes(12).FirstChild.Value
                    Else
                        MessageBox.Show("Verifique el archivo de configuración del formato de impresión. No existe la posición para la fecha de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                End If
                Return True
            End If
        Else
            MessageBox.Show("No se encontró la configuración del formato de impresión", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
    End Function
    Private Function ObtenerFormato() As String
        Dim strFormato As String = ""
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_FORMATO_CHEQUE", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = txt_cod_ban.Text
            con.Open()
            Dim drd As SqlDataReader = Cmd.ExecuteReader
            If drd IsNot Nothing AndAlso drd.HasRows Then
                drd.Read()
                strFormato = drd.GetValue(0)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        Return strFormato
    End Function

    Sub CARGAR_BANCOS()
        Try
            Dim pro As New SqlCommand("DGW_BANCOS", con)
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Personas")
            Prog00.Fill(dt)
            dgw_ban.DataSource = dt
            dgw_ban.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_ban.Columns.Item(0).Width = &H37
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub REPORTE_CHEQUES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub REPORTE_CHEQUES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        If Not File.Exists(Archivo) Then
            MessageBox.Show("No existe el archivo de configuración de formatos, para cheques.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_imprimir.Enabled = False
        Else
            oXML.Load(Archivo)
        End If
        CARGAR_BANCOS()
        CARGAR_AÑO()
    End Sub

    Private Sub txt_cod_ban_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_ban.LostFocus
        If (Strings.Trim(txt_cod_ban.Text) <> "") Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me.dgw_ban.Sort(dgw_ban.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_ban.Text.ToLower = dgw_ban.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_ban.Text = dgw_ban.Item(0, i).Value.ToString
                        txt_desc_ban.Text = dgw_ban.Item(1, i).Value.ToString
                        cbo_año.Focus()
                        Return
                    End If
                    If (txt_cod_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(0, i).Value), 1, Strings.Len(Me.txt_cod_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    Me.dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_ban.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(Me.txt_desc_ban.Text) <> "")) Then
            If (dgw_ban.RowCount = 0) Then
                MessageBox.Show("No existen Bancos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_ban.Sort(dgw_ban.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_ban.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_ban.Text.ToLower = Strings.Mid((dgw_ban.Item(1, i).Value), 1, Strings.Len(txt_desc_ban.Text)).ToLower) Then
                        dgw_ban.CurrentCell = dgw_ban.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_ban.CurrentCell = dgw_ban.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                panel_bancos.Visible = True
                dgw_ban.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_ban_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_ban.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_ban.Text = dgw_ban.Item(0, dgw_ban.CurrentRow.Index).Value.ToString
            txt_desc_ban.Text = dgw_ban.Item(1, dgw_ban.CurrentRow.Index).Value.ToString
            panel_bancos.Visible = False
            KL1.Focus()
        End If
    End Sub

    Private Sub btn_consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta.Click
        dgvDetalle.Rows.Clear()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_I_BANCO_CHEQUE", con)
            Cmd.CommandType = (CommandType.StoredProcedure)
            Cmd.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim drd As SqlDataReader = Cmd.ExecuteReader
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Do While drd.Read
                    dgvDetalle.Rows.Add(drd.GetValue(0), drd.GetValue(1), _
                    drd.GetValue(2), drd.GetValue(3), drd.GetValue(4), _
                    drd.GetValue(5), 0, drd.GetValue(6), drd.GetValue(7), _
                    drd.GetValue(8), drd.GetValue(9))
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(40) = 0
        Close()
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim idx As Integer
        Dim oImpresora As New Printing.PrinterSettings
        oImpresora.PrinterName = "Cheque"

        oImpresion.PrinterSettings = oImpresora

        If Not oImpresion.PrinterSettings.IsValid Then
            MessageBox.Show("verifique el nombre de la impresora", "Error en la impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        oImpresion.OriginAtMargins = False

        Dim Formato As String = ObtenerFormato()
        If Formato.Trim = "" Then
            MessageBox.Show("Verifique el codigo de formato para este banco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        For idx = 0 To dgvDetalle.RowCount - 1

            With dgvDetalle
                If .Item(6, idx).Value Then
                    Diferido = .Item(9, idx).Value
                    If Not ObtenerConfiguracion(Formato) Then
                        Exit For
                    End If
                    oImpresion.DefaultPageSettings.PaperSize = New Printing.PaperSize("Cheque", oAnchoPapel, oAltoCheque)
                    NroMp = .Item(1, idx).Value
                    Persona = .Item(3, idx).Value
                    Importe = .Item(4, idx).Value

                    If IsDate(.Item(2, idx).Value) Then
                        Fecha = .Item(2, idx).Value
                    ElseIf Diferido Then
                        MessageBox.Show("Verifique la fecha del cheque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If

                    If Diferido AndAlso IsDate(.Item(10, idx).Value) Then
                        FechaPago = Date.Parse(.Item(10, idx).Value)
                    ElseIf Diferido Then
                        MessageBox.Show("Verifique la fecha de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If

                    Dim largo = Len(CStr(Format(CDbl(Importe), "##,###,###,##0.00")))
                    Dim decimales = Mid(CStr(Format(CDbl(Importe), "##,###,###,##0.00")), largo - 2)
                    Dim NUM0 As Integer = Importe - decimales
                    ImporteText = String.Format("{0} CON {1}/100", OBJ.NumText(NUM0), Mid(decimales, Len(decimales) - 1))
                    oImpresion.Print()
                    ImprimirDetalles(.Item(0, idx).Value, NroMp, .Item(5, idx).Value)
                    'Dim ppd As New PrintPreviewDialog
                    'ppd.Document = oImpresion
                    'ppd.WindowState = FormWindowState.Maximized
                    'ppd.ShowDialog()
                End If
            End With
        Next
    End Sub

    Private Sub ImprimirDetalles(ByVal COD_MP00 As String, ByVal NRO_MP00 As String, ByVal COD_MON00 As String)
        Dim oTamaño As New Printing.PaperSize
        Dim oMargen As New Printing.Margins
        Dim oImpresora As New Printing.PrinterSettings
        If rbVoucher.Checked Then
            oImpresora.PrinterName = "Voucher"
        Else
            oImpresora.PrinterName = "Validadora"
        End If

        oImpresionRef.PrinterSettings = oImpresora

        If Not oImpresion.PrinterSettings.IsValid Then
            MessageBox.Show("verifique el nombre de la impresora", "Error en la impresión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        oTamaño.Width = 300
        oTamaño.Height = 150
        oMargen = New Printing.Margins(14, 14, 0, 0)
        oImpresionRef.DefaultPageSettings.PaperSize = oTamaño
        oImpresionRef.DefaultPageSettings.Margins = oMargen

        Try
            Dim Cmd As New SqlCommand("MOSTRAR_T_BANCO_CHEQUE", con)
            Cmd.CommandType = (CommandType.StoredProcedure)
            Cmd.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = txt_cod_ban.Text
            Cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            Cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            Cmd.Parameters.Add("@COD_MP ", SqlDbType.Char).Value = COD_MP00
            Cmd.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = NRO_MP00

            con.Open()
            Cmd.ExecuteNonQuery()
            Dim drd As SqlDataReader = Cmd.ExecuteReader
            If drd IsNot Nothing AndAlso drd.HasRows Then
                lReferencia.Clear()
                Dim nRefrencia As Referencia
                Do While drd.Read
                    nRefrencia = New Referencia
                    nRefrencia.Cheque = NRO_MP00
                    nRefrencia.Documento = drd.GetValue(0)
                    nRefrencia.Numero = drd.GetValue(1)
                    nRefrencia.Fecha = drd.GetValue(2)
                    nRefrencia.MonedaCheque = OBJ.DESC_MONEDA(COD_MON00)
                    nRefrencia.Moneda = drd.GetValue(3)
                    nRefrencia.Importe = drd.GetValue(4)
                    nRefrencia.TipoCambio = drd.GetValue(5)
                    lReferencia.Add(nRefrencia)
                Loop

                Dim I As Integer
                For I = 0 To lReferencia.Count - 1
                    Fila = I
                    oImpresionRef.Print()
                Next
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub oImpresion_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles oImpresion.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Display
        Dim MargenTop As Integer = CentPlg(5)
        Dim MargenBottom As Integer = CentPlg(18.4)
        Dim MargenLeft As Integer = oAnchoPapel - oAnchoCheque
        Dim MargenRight As Integer = CentPlg(5.6)
        Dim PosX As Integer = MargenLeft + MargenRight
        Dim PosY As Integer = oAltoCheque - MargenTop

        Dim oFont As New Font("Verdana", 9)
        Dim drwFormat As New StringFormat
        drwFormat.FormatFlags = StringFormatFlags.DirectionVertical

        Dim pntLugar As Point '= New Point(120, 130)
        Dim puntos() As String
        puntos = p1.Split(",")
        pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
        Dim trnTransforma As Drawing2D.Matrix = e.Graphics.Transform
        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma
        e.Graphics.DrawString(String.Format("{0}{1:N2}", New String("*", 13 - Len(Importe)), Double.Parse(Importe, Globalization.NumberStyles.AllowDecimalPoint)), oFont, Brushes.Black, pntLugar, drwFormat)

        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma

        Array.Clear(puntos, 0, puntos.Length)
        puntos = p2.Split(",")
        pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
        trnTransforma = e.Graphics.Transform
        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma
        e.Graphics.DrawString(Persona, oFont, Brushes.Black, pntLugar, drwFormat)

        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma

        Array.Clear(puntos, 0, puntos.Length)
        puntos = p3.Split(",")
        pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
        trnTransforma = e.Graphics.Transform
        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma
        e.Graphics.DrawString(ImporteText, oFont, Brushes.Black, pntLugar, drwFormat)

        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma

        Array.Clear(puntos, 0, puntos.Length)
        puntos = p4.Split(",")
        pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
        trnTransforma = e.Graphics.Transform
        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma
        e.Graphics.DrawString(Fecha.Day.ToString("00"), oFont, Brushes.Black, pntLugar, drwFormat)

        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma

        Array.Clear(puntos, 0, puntos.Length)
        puntos = p5.Split(",")
        pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
        trnTransforma = e.Graphics.Transform
        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma
        e.Graphics.DrawString(Fecha.Month.ToString("00"), oFont, Brushes.Black, pntLugar, drwFormat)

        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma

        Array.Clear(puntos, 0, puntos.Length)
        puntos = p6.Split(",")
        pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
        trnTransforma = e.Graphics.Transform
        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma
        e.Graphics.DrawString(Fecha.Year, oFont, Brushes.Black, pntLugar, drwFormat)

        trnTransforma.RotateAt(180, pntLugar)
        e.Graphics.Transform = trnTransforma

        If Diferido Then

            Array.Clear(puntos, 0, puntos.Length)
            puntos = p7.Split(",")
            pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
            trnTransforma = e.Graphics.Transform
            trnTransforma.RotateAt(180, pntLugar)
            e.Graphics.Transform = trnTransforma
            e.Graphics.DrawString(FechaPago.Day.ToString("00"), oFont, Brushes.Black, pntLugar, drwFormat)

            trnTransforma.RotateAt(180, pntLugar)
            e.Graphics.Transform = trnTransforma

            Array.Clear(puntos, 0, puntos.Length)
            puntos = p8.Split(",")
            pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
            trnTransforma = e.Graphics.Transform
            trnTransforma.RotateAt(180, pntLugar)
            e.Graphics.Transform = trnTransforma
            e.Graphics.DrawString(FechaPago.Month.ToString("00"), oFont, Brushes.Black, pntLugar, drwFormat)

            trnTransforma.RotateAt(180, pntLugar)
            e.Graphics.Transform = trnTransforma

            Array.Clear(puntos, 0, puntos.Length)
            puntos = p9.Split(",")
            pntLugar = New Point(PosX + CentPlg(puntos(0)), (PosY) - CentPlg(puntos(1)))
            trnTransforma = e.Graphics.Transform
            trnTransforma.RotateAt(180, pntLugar)
            e.Graphics.Transform = trnTransforma
            e.Graphics.DrawString(FechaPago.Year, oFont, Brushes.Black, pntLugar, drwFormat)

            trnTransforma.RotateAt(180, pntLugar)
            e.Graphics.Transform = trnTransforma
        End If

    End Sub

    Private Sub oImpresionRef_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles oImpresionRef.PrintPage
        Dim oAnchoVoucher As Integer = e.PageSettings.PaperSize.Width
        Dim oAltoVoucher As Integer = e.PageSettings.PaperSize.Height
        Dim oFont As New Font("Verdana", 8)
        Dim drwFormat As New StringFormat
        Dim rec As Rectangle = New Rectangle(0, 0, oAnchoVoucher, oAltoVoucher)
        drwFormat.Alignment = StringAlignment.Center
        e.Graphics.DrawString("***PAGADO***", oFont, Brushes.Black, rec, drwFormat)
        Dim posY As Integer = 10
        Dim posX As Integer = 0
        Dim incremento As Integer = 15
        posY += 10
        With lReferencia(Fila)
            e.Graphics.DrawString(String.Format("CHQ. Nro.: {0}", .Cheque), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("Moneda.: {0}", .MonedaCheque), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("L. Pago: {0}", txt_desc_ban.Text), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("{0} Nro.: {1}", .Documento, .Numero), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("Fecha: {0}", .Fecha), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("Moneda: {0}", .Moneda), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("T.C.: {0:N4}", .TipoCambio), oFont, Brushes.Black, posX, posY)
            posY += incremento
            e.Graphics.DrawString(String.Format("Importe: {0:N2}", .Importe), oFont, Brushes.Black, posX, posY)
            posY += incremento
        End With
        e.Graphics.DrawString(New String("-", 4), oFont, Brushes.Black, posX, posY)
    End Sub
End Class