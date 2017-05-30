Imports System.Data.SqlClient
Imports System.IO
Public Class PDB_VENTAS
    Private Obj As New Class1
    Private Config As String
    Private loPDBVentas As New List(Of PDB_Venta)
    Private Item As Integer
    Private Idx As Integer
    Private _fila As Integer
    Private _consultar As Boolean

    Public Structure PDB_Venta
        Public Item As Integer
        Public Año As String
        Public Mes As String
        Public TipoVenta As String
        Public TipoComprobante As String
        Public FechaEmision As Date
        Public NroDoc As String
        Public SerieComprobante As String
        Public NroComprobante As String
        Public TipoPersona As String
        Public CodPersona As String
        Public TipoDocumento As String
        Public NroDocumento As String
        Public RazonSocial As String
        Public Nombre1 As String
        Public Nombre2 As String
        Public ApellidoPaterno As String
        Public ApellidoMaterno As String
        Public TipoMoneda As String
        Public CodigoDestino As String
        Public NumeroDestino As String
        Public BaseImponible As Decimal
        Public MontoISC As Decimal
        Public MontoIGV As Decimal
        Public MontoOtros As Decimal
        Public IndicadorDet As String
        Public CodigoDet As String
        Public NumeroDet As String
        Public IndicadorRet As String
        Public TipoComprobanteRef As String
        Public SerieComprobanteRef As String
        Public NroComprobanteRef As String
        Public FechaEmisionRef As Date
        Public BaseImponibleRef As Decimal
        Public MontoIGVRef As Decimal
    End Structure

    Private Sub ConsultarPDB()
        Try
            loPDBVentas.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PDB_VENTAS", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePDB As PDB_Venta
                While drd.Read
                    ObePDB = New PDB_Venta
                    With ObePDB
                        i += 1
                        .TipoVenta = drd(0)
                        .TipoComprobante = drd(1)
                        .FechaEmision = CDate(drd(2)).ToShortDateString
                        .SerieComprobante = drd(3)
                        .NroComprobante = drd(4)
                        .TipoPersona = drd(5)
                        .TipoDocumento = drd(6)
                        'If drd(6) = "-" Then .TipoDocumento = "0" Else .TipoDocumento = drd(6)
                        If drd(6) = "-" Then .NroDocumento = "" Else .NroDocumento = drd(7)
                        .RazonSocial = drd(8)
                        .ApellidoPaterno = drd(9)
                        .ApellidoMaterno = drd(10)
                        .Nombre1 = drd(11)
                        .Nombre2 = drd(12)
                        .TipoMoneda = drd(13)
                        .CodigoDestino = drd(14)
                        .NumeroDestino = drd(15)
                        .BaseImponible = drd(16)
                        .MontoISC = drd(17)
                        .MontoIGV = drd(18)
                        .MontoOtros = drd(19)
                        .IndicadorDet = drd(20)
                        .CodigoDet = drd(21)
                        .NumeroDet = drd(22)
                        .IndicadorRet = drd(23)
                        .TipoComprobanteRef = drd(24)
                        .SerieComprobanteRef = drd(25)
                        .NroComprobanteRef = drd(26)
                        .FechaEmisionRef = IIf(IsDBNull(drd(27)), New Date(1900, 1, 1), CDate(drd(27)).ToShortDateString)
                        .BaseImponibleRef = drd(28)
                        .MontoIGVRef = drd(29)
                        .Año = drd(30)
                        .Mes = drd(31)
                        .Item = drd(32)
                        .CodPersona = drd(33)
                        .NroDoc = drd(34)
                    End With
                    loPDBVentas.Add(ObePDB)
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

    Private Function CargarDatosGenerar() As List(Of PDB_Venta)
        Dim cmd As New SqlCommand("GENERAR_PDB_VENTAS", con)
        cmd.CommandType = CommandType.StoredProcedure
        Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
        Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
        par0.Value = cbo_año.Text
        par1.Value = Obj.COD_MES(cbo_mes.Text)
        Dim dsPDB As New DataSet
        Dim DA_PDB As New SqlDataAdapter(cmd)
        DA_PDB.Fill(dsPDB)
        dgw1.DataSource = dsPDB.Tables(0)
        'loPDBVENTAs = PDBVENTA_LISTAR()

        Dim I, J, x As Integer
        Dim ObePDB As PDB_Venta
        Dim loPDB As New List(Of PDB_Venta)
        Dim dr As DataRow
        Dim pos As String
        Dim idx As Integer
        Dim base As Decimal
        Dim igv As Decimal
        For I = 0 To dsPDB.Tables(0).Rows.Count - 1
            dr = dsPDB.Tables(0).Rows(I)
            ObePDB = New PDB_Venta
            base = 0
            With ObePDB
                .Año = cbo_año.Text
                .Mes = Obj.COD_MES(cbo_mes.Text)
                If (dr(0) = "01" OrElse dr(0) = "03" OrElse dr(0) = "07" _
                 OrElse dr(0) = "08" OrElse dr(0) = "12" OrElse dr(0) = "34" _
                 OrElse dr(0) = "35" OrElse dr(0) = "36" OrElse dr(0) = "37") _
                 AndAlso dr(3) = "03" Then
                    .TipoVenta = "02"
                Else
                    .TipoVenta = "01"
                End If
                .TipoComprobante = dr(0)
                .FechaEmision = dr(1)
                .NroDoc = dr(2)
                idx = dr(2).ToString.IndexOf("-")
                If idx > 0 Then
                    .SerieComprobante = dr(2).ToString.Substring(0, idx)
                    .NroComprobante = dr(2).ToString.Substring(idx + 1)
                Else
                    .NroComprobante = dr(2)
                End If
                'If (dr(0) = "01" OrElse dr(0) = "03" OrElse dr(0) = "07" _
                ' OrElse dr(0) = "08" OrElse dr(0) = "34" OrElse dr(0) = "35" _
                ' OrElse dr(0) = "36" OrElse dr(0) = "37") Then
                '    idx = dr(2).ToString.IndexOf("-")
                '    If idx > 0 Then
                '        .SerieComprobante = dr(2).ToString.Substring(0, idx)
                '        .NroComprobante = dr(2).ToString.Substring(idx + 1)
                '    End If
                'ElseIf (dr(0) = "10" OrElse dr(0) = "12") Then
                '    .SerieComprobante = ""
                '    .NroComprobante = ""
                'Else
                '    .SerieComprobante = dr(2)
                '    .NroComprobante = ""
                'End If
                .TipoPersona = dr(3)
                .CodPersona = dr(32)
                'If dr(4) <> 0 Then
                '    .TipoDocumento = Integer.Parse(dr(4))
                'Else
                '    .TipoDocumento = "-"
                'End If

                If dr(4).ToString.Trim <> "-" Then
                    .TipoDocumento = Integer.Parse(dr(4))
                Else
                    .TipoDocumento = "-"
                End If
                .NroDocumento = dr(5)
                If dr(3) = "02" OrElse dr(3) = "03" Then
                    .RazonSocial = dr(6)
                    .Nombre1 = ""
                    .Nombre2 = ""
                    .ApellidoPaterno = ""
                    .ApellidoMaterno = ""
                Else
                    .RazonSocial = ""
                    .Nombre1 = dr(7)
                    .Nombre2 = dr(8)
                    .ApellidoPaterno = dr(9)
                    .ApellidoMaterno = dr(10)
                End If
                .TipoMoneda = dr(11)
                x = 0
                For J = 12 To 21
                    x += 1
                    If dr(J) > 0 Then
                        pos = Obj.DIR_TABLA_DESC(String.Format("V{0}", x.ToString("00")), "TPDB")
                        If pos <> "IGV" AndAlso pos <> "5" Then
                            .BaseImponible = dr(J)
                            base += .BaseImponible
                            .CodigoDestino = pos
                            .NumeroDestino = 1
                        ElseIf pos = "IGV" Then
                            .MontoIGV = dr(J)
                            igv = .MontoIGV
                        End If
                    End If
                    If (x = 5) AndAlso .BaseImponible = 0 AndAlso dr(31) > 0 Then
                        .BaseImponible = dr(31)
                        .CodigoDestino = Obj.DIR_TABLA_DESC("V01", "TPDB")
                        .NumeroDestino = 1
                    End If
                Next
                .IndicadorDet = dr(22)
                .CodigoDet = dr(23)
                .NumeroDet = dr(24)
                If (dr(26) = "0" AndAlso dr(27) = "0") AndAlso dr(22) = "0" AndAlso dr(25) > 700 Then
                    .IndicadorRet = "1"
                Else
                    .IndicadorRet = "0"
                End If
                If (dr(0) = "07" OrElse dr(0) = "08" OrElse dr(0) = "87" OrElse dr(0) = "88") Then
                    .TipoComprobanteRef = dr(28)
                    idx = dr(29).ToString.IndexOf("-")
                    If idx > 0 Then
                        .SerieComprobanteRef = dr(29).ToString.Substring(0, idx)
                        .NroComprobanteRef = dr(29).ToString.Substring(idx + 1)
                        .FechaEmisionRef = dr(30)
                        .BaseImponibleRef = base
                        .MontoIGVRef = igv
                    End If
                ElseIf (dr(0) = "91" OrElse dr(0) = "97" OrElse dr(0) = "98") Then
                    .SerieComprobanteRef = ""
                    .TipoComprobanteRef = dr(28)
                    .NroComprobanteRef = dr(29)
                    .FechaEmisionRef = dr(30)
                    .BaseImponibleRef = base
                    .MontoIGVRef = igv
                Else
                    .SerieComprobanteRef = ""
                    .TipoComprobanteRef = ""
                    .NroComprobanteRef = ""
                    .FechaEmisionRef = New Date(1900, 1, 1)
                    .BaseImponibleRef = 0
                    .MontoIGVRef = 0
                End If
            End With
            loPDB.Add(ObePDB)
        Next
        Return loPDB
    End Function

    Private Sub GenerarPDB()
        Dim trx As SqlTransaction = Nothing
        Dim loPdb As List(Of PDB_Venta) = CargarDatosGenerar()
        Try
            con.Open()
            trx = con.BeginTransaction

            Dim i As Integer
            For i = 0 To loPdb.Count - 1
                With loPdb(i)
                    Dim cmd As New SqlCommand("INSERTAR_PDB_VENTAS", con, trx)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                    cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                    cmd.Parameters.AddWithValue("@TIPO_VENTA", .TipoVENTA)
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", .TipoComprobante)
                    cmd.Parameters.AddWithValue("@FECHA_EMISION", .FechaEmision)
                    cmd.Parameters.AddWithValue("@NRO_DOC", .NroDoc)
                    cmd.Parameters.AddWithValue("@SERIE", IIf(IsNothing(.SerieComprobante), System.DBNull.Value, .SerieComprobante))
                    cmd.Parameters.AddWithValue("@NRO_COMPROBANTE", IIf(IsNothing(.NroComprobante), System.DBNull.Value, .NroComprobante))
                    cmd.Parameters.AddWithValue("@TIPO_PERSONA", .TipoPersona)
                    cmd.Parameters.AddWithValue("@COD_PER", .CodPersona)
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", .TipoDocumento)
                    cmd.Parameters.AddWithValue("@NUMERO_DOCUMENTO", .NroDocumento)
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", .RazonSocial)
                    cmd.Parameters.AddWithValue("@APELLIDO_PATERNO", .ApellidoPaterno)
                    cmd.Parameters.AddWithValue("@APELLIDO_MATERNO", .ApellidoMaterno)
                    cmd.Parameters.AddWithValue("@NOMBRE1", .Nombre1)
                    cmd.Parameters.AddWithValue("@NOMBRE2", .Nombre2)
                    cmd.Parameters.AddWithValue("@COD_MONEDA", .TipoMoneda)
                    cmd.Parameters.AddWithValue("@COD_DESTINO", IIf(IsNothing(.CodigoDestino), System.DBNull.Value, .CodigoDestino))
                    cmd.Parameters.AddWithValue("@NUMERO_DESTINO", IIf(IsNothing(.NumeroDestino), System.DBNull.Value, .NumeroDestino))
                    cmd.Parameters.AddWithValue("@BASE_IMP", .BaseImponible)
                    cmd.Parameters.AddWithValue("@MONTO_ISC", .MontoISC)
                    cmd.Parameters.AddWithValue("@MONTO_IGV", .MontoIGV)
                    cmd.Parameters.AddWithValue("@MONTO_OTROS", .MontoOtros)
                    cmd.Parameters.AddWithValue("@INDICADOR_DET", .IndicadorDet)
                    cmd.Parameters.AddWithValue("@CODIGO_DET", .CodigoDet)
                    cmd.Parameters.AddWithValue("@NUMERO_DET", .NumeroDet)
                    cmd.Parameters.AddWithValue("@INDICADOR_RET", .IndicadorRet)
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE_REF", IIf(IsNothing(.TipoComprobanteRef), System.DBNull.Value, .TipoComprobanteRef))
                    cmd.Parameters.AddWithValue("@SERIE_REF", IIf(IsNothing(.SerieComprobanteRef), System.DBNull.Value, .SerieComprobanteRef))
                    cmd.Parameters.AddWithValue("@NRO_COMPROBANTE_REF", IIf(IsNothing(.NroComprobanteRef), System.DBNull.Value, .NroComprobanteRef))
                    cmd.Parameters.AddWithValue("@FECHA_EMISION_REF", IIf(IsNothing(.FechaEmisionRef), System.DBNull.Value, .FechaEmisionRef))
                    cmd.Parameters.AddWithValue("@BASE_IMP_REF", .BaseImponibleRef)
                    cmd.Parameters.AddWithValue("@MONTO_IGV_REF", .MontoIGVRef)
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

    Sub CBO_MONEDA0()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cboMoneda.DataSource = DT
        cboMoneda.DisplayMember = DT.Columns.Item(0).ToString
        cboMoneda.ValueMember = DT.Columns.Item(1).ToString
        cboMoneda.SelectedIndex = -1
    End Sub

    Private Sub LIMPIAR(ByVal Contenedor As Object)
        Dim x As Control
        For Each x In Contenedor.Controls
            If TypeOf x Is TextBox Then CType(x, TextBox).Clear()
            If TypeOf x Is ListBox Or TypeOf x Is ComboBox Then CType(x, ListControl).SelectedIndex = -1
            If TypeOf x Is CheckBox Then CType(x, CheckBox).Checked = False
        Next
    End Sub

    Private Function BUSCAR_ITEM(ByVal OPDB As PDB_Venta) As Boolean
        Return OPDB.Item = Item
    End Function

    Private Sub CARGAR_DETALLES()
        With loPDBVentas(Idx)
            If .TipoPersona = "01" Then
                cboTipoPersona.SelectedIndex = 0
            ElseIf .TipoPersona = "02" Then
                cboTipoPersona.SelectedIndex = 1
            ElseIf .TipoPersona = "03" Then
                cboTipoPersona.SelectedIndex = 2
            End If

            If .TipoDocumento = "-" Then
                cboTipoDocumento.SelectedIndex = 0
            ElseIf .TipoDocumento = "0" Then
                cboTipoDocumento.SelectedIndex = 1
            ElseIf .TipoDocumento = "1" Then
                cboTipoDocumento.SelectedIndex = 2
            ElseIf .TipoDocumento = "6" Then
                cboTipoDocumento.SelectedIndex = 3
            End If
            If .TipoVenta = "01" Then
                cboTipoVenta.SelectedIndex = 0
            Else
                cboTipoVenta.SelectedIndex = 1
            End If
            If .TipoMoneda = "1" Then
                cboMoneda.SelectedIndex = 2
            ElseIf .TipoMoneda = "2" Then
                cboMoneda.SelectedIndex = 1
            End If
            txtNroDocumento.Text = .NroDocumento
            txtRazonSocial.Text = .RazonSocial
            txtNombres.Text = .Nombre1
            txtApellidoPaterno.Text = .ApellidoPaterno
            txtApellidoMaterno.Text = .ApellidoMaterno
            cboComprobante.Text = Obj.DESC_DOC(.TipoComprobante)
            txtSerie.Text = .SerieComprobante
            txtNroComprobante.Text = .NroComprobante
            dtpFechaEmision.Value = .FechaEmision
            txtCodDestino.Text = .CodigoDestino
            txtNroDestino.Text = .NumeroDestino
            txtBaseImp.Text = .BaseImponible
            txtIsc.Text = .MontoISC
            txtIgv.Text = .MontoIGV
            txtOtros.Text = .MontoOtros
            chkDetraccion.Checked = IIf(.IndicadorDet = "1", True, False)
            txtCodDetraccion.Text = .CodigoDet
            txtNroDetraccion.Text = .NumeroDet
            chkRetencion.Checked = IIf(.IndicadorRet = "1", True, False)
            cboComprobanteRef.Text = Obj.DESC_DOC(.TipoComprobanteRef)
            txtSerieRef.Text = .SerieComprobanteRef
            txtNroComprobanteRef.Text = .NroComprobanteRef
            dtpFechaEmisionRef.Value = .FechaEmisionRef
            txtBaseImpRef.Text = .BaseImponibleRef
            txtIgvRef.Text = .MontoIGVRef
        End With
    End Sub

    Private Sub PDB_VENTAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PDB_VENTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabPage2.Parent = Nothing
        KeyPreview = True
        CARGAR_AÑO()
        CBO_DOCUMENTO()
        CBO_TIPO_DOC()
        CBO_MONEDA0()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cbo_mes.Focus() : Exit Sub

        ConsultarPDB()
        If loPDBVentas.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("¿No existen registros del PDB Ventas desea generarlos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarPDB()
                ConsultarPDB()
            End If
        End If
        dgvDatos.Rows.Clear()

        Dim i As Integer
        For i = 0 To loPDBVentas.Count - 1
            With loPDBVentas.Item(i)
                dgvDatos.Rows.Add(.Item, .TipoVenta, .TipoComprobante, .FechaEmision, .NroDoc, .SerieComprobante, _
                .NroComprobante, .TipoPersona, .TipoDocumento, .NroDocumento, .RazonSocial, .Nombre1, _
                .ApellidoPaterno, .ApellidoMaterno, .TipoMoneda, .CodigoDestino, .NumeroDestino, .BaseImponible, _
                .MontoISC, .MontoIGV, .MontoOtros, .IndicadorDet, .CodigoDet, .NumeroDet, .IndicadorRet, _
                .TipoComprobanteRef, .SerieComprobanteRef, .NroComprobanteRef, .FechaEmisionRef, _
                .BaseImponibleRef, .MontoIGVRef)
            End With
        Next

        'Dim i As Integer
        'For i = 0 To loPDBVENTAs.Count - 1
        '    With loPDBVENTAs.Item(i)
        '        dgvDatos.Rows.Add(.Item, .TipoVenta, .TipoComprobante, .FechaEmision, .SerieComprobante, _
        '        .NroComprobante, .TipoPersona, .TipoDocumento, .NroDocumento, .RazonSocial, .Nombre1, _
        '        .ApellidoPaterno, .ApellidoMaterno, .TipoMoneda, .CodigoDestino, .NumeroDestino, .BaseImponible, _
        '        .MontoISC, .MontoIGV, .MontoOtros, .IndicadorDet, .CodigoDet, .NumeroDet, .IndicadorRet, _
        '        .TipoComprobanteRef, .SerieComprobanteRef, .NroComprobanteRef, .FechaEmisionRef, _
        '        .BaseImponibleRef, .MontoIGVRef)
        '    End With
        'Next
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(150) = 0
        Close()
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        TabPage2.Parent = TabControl1
        TabControl1.SelectedTab = TabPage2
        _fila = dgvDatos.CurrentRow.Index
        Item = dgvDatos.Item(0, dgvDatos.CurrentRow.Index).Value
        Dim pred As New Predicate(Of PDB_Venta)(AddressOf BUSCAR_ITEM)
        Idx = loPDBVENTAs.FindIndex(pred)
        If Idx > -1 Then
            LIMPIAR(gbPersona)
            LIMPIAR(gbComprobante)
            LIMPIAR(gbReferencia)
            CARGAR_DETALLES()
        Else
            MessageBox.Show("No se cargaron los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        TabPage2.Parent = Nothing
        TabControl1.SelectedTab = TabPage1
        dgvDatos.CurrentCell = dgvDatos.Rows.Item(_fila).Cells.Item(1)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim opdbVENTAS As PDB_Venta = loPDBVentas(Idx)
        If cboTipoDocumento.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione el tipo de documento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        With opdbVENTAS
            If Obj.COD_TIPO_DOC_PER(cboTipoDocumento.Text).Trim <> "-" Then
                .TipoDocumento = Integer.Parse(Obj.COD_TIPO_DOC_PER(cboTipoDocumento.Text))
            Else
                .TipoDocumento = "-"
            End If
            .RazonSocial = txtRazonSocial.Text
            '.TipoDocumento = Obj.COD_TIPO_DOC_PER(cboTipoDocumento.Text)
            If .TipoDocumento = "-" Then
                .NroDocumento = ""
            Else
                .NroDocumento = txtNroDocumento.Text
            End If
            '.NroDocumento = txtNroDocumento.Text
            .TipoComprobante = Obj.COD_DOC(cboComprobante.Text)
            .SerieComprobante = txtSerie.Text
            .NroComprobante = txtNroComprobante.Text
            'dtpFechaEmision.Value = .FechaEmision
            .CodigoDestino = txtCodDestino.Text
            .NumeroDestino = txtNroDestino.Text
            .BaseImponible = txtBaseImp.Text
            .MontoISC = txtIsc.Text
            .MontoIGV = txtIgv.Text
            .MontoOtros = txtOtros.Text
            .CodigoDet = txtCodDetraccion.Text
            .NumeroDet = txtNroDetraccion.Text
            .TipoComprobanteRef = Obj.COD_DOC(cboComprobanteRef.Text)
            .SerieComprobanteRef = txtSerieRef.Text
            .NroComprobanteRef = txtNroComprobanteRef.Text
            'dtpFechaEmisionRef.Value = .FechaEmisionRef
            .BaseImponibleRef = txtBaseImpRef.Text
            .MontoIGVRef = txtIgvRef.Text
            Try
                con.Open()
                Dim cmd As New SqlCommand("ACTUALIZAR_PDB_VENTAS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@ITEM", SqlDbType.Int).Value = .Item
                cmd.Parameters.Add("@TIPO_COMPROBANTE", SqlDbType.Char).Value = .TipoComprobante
                cmd.Parameters.Add("@RAZON_SOCIAL", SqlDbType.Char).Value = .RazonSocial
                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = .SerieComprobante
                cmd.Parameters.Add("@NRO_COMPROBANTE", SqlDbType.VarChar).Value = .NroComprobante
                cmd.Parameters.Add("@TIPO_DOCUMENTO", SqlDbType.Char).Value = .TipoDocumento
                cmd.Parameters.Add("@NUMERO_DOCUMENTO", SqlDbType.VarChar).Value = .NroDocumento
                cmd.Parameters.Add("@COD_DESTINO", SqlDbType.Char).Value = .CodigoDestino
                cmd.Parameters.Add("@NUMERO_DESTINO", SqlDbType.Char).Value = .NumeroDestino
                cmd.Parameters.Add("@BASE_IMP", SqlDbType.Decimal).Value = .BaseImponible
                cmd.Parameters.Add("@MONTO_ISC", SqlDbType.Decimal).Value = .MontoISC
                cmd.Parameters.Add("@MONTO_IGV", SqlDbType.Decimal).Value = .MontoIGV
                cmd.Parameters.Add("@MONTO_OTROS", SqlDbType.Decimal).Value = .MontoOtros
                cmd.Parameters.Add("@CODIGO_DET", SqlDbType.VarChar).Value = .CodigoDet
                cmd.Parameters.Add("@NUMERO_DET", SqlDbType.VarChar).Value = .NumeroDet
                cmd.Parameters.Add("@TIPO_COMPROBANTE_REF", SqlDbType.Char).Value = IIf(IsNothing(.TipoComprobanteRef), System.DBNull.Value, .TipoComprobanteRef)
                cmd.Parameters.Add("@SERIE_REF", SqlDbType.VarChar).Value = IIf(IsNothing(.SerieComprobanteRef), System.DBNull.Value, .SerieComprobanteRef)
                cmd.Parameters.Add("@NRO_COMPROBANTE_REF", SqlDbType.VarChar).Value = IIf(IsNothing(.NroComprobanteRef), System.DBNull.Value, .NroComprobanteRef)
                cmd.Parameters.Add("@BASE_IMP_REF", SqlDbType.Decimal).Value = .BaseImponibleRef
                cmd.Parameters.Add("@MONTO_IGV_REF", SqlDbType.Decimal).Value = .MontoIGVRef
                cmd.ExecuteNonQuery()
                MessageBox.Show("Datos actualizados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            btn_consultar_Click(sender, e)
            btn_cancelar_Click(Nothing, Nothing)
        End With
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("V{0}{1}{2}.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs)
                    Dim i As Integer
                    'sw.WriteLine("Tipo Venta|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombres|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loPDBVentas.Count - 1
                        With loPDBVentas(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|", _
                            .TipoVenta, .TipoComprobante, CDate(.FechaEmision).ToShortDateString, .SerieComprobante, .NroComprobante, .TipoPersona, IIf(.TipoPersona = "03", "-", .TipoDocumento), IIf(.TipoPersona = "03", "", .NroDocumento), _
                            .RazonSocial.Replace("ñ", "n"), .ApellidoPaterno, .ApellidoMaterno, .Nombre1, .Nombre2, .TipoMoneda, .CodigoDestino, .NumeroDestino, _
                            IIf(.BaseImponible = 0, "", .BaseImponible), IIf(.MontoISC = 0, "", .MontoISC), IIf(.MontoIGV = 0, "", .MontoIGV), _
                            IIf(.MontoOtros = 0, "", .MontoOtros), .IndicadorDet, .CodigoDet, .NumeroDet, .IndicadorRet, .TipoComprobanteRef, .SerieComprobanteRef, _
                            .NroComprobanteRef, IIf(.FechaEmisionRef = New Date(1900, 1, 1), "", CDate(.FechaEmisionRef).ToShortDateString), _
                            IIf(.BaseImponibleRef = 0, "", .BaseImponibleRef), IIf(.MontoIGVRef = 0, "", .MontoIGVRef)))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Try
            Dim idx As Integer = dgvDatos.CurrentRow.Index
            Dim rpta As DialogResult = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If rpta = Windows.Forms.DialogResult.Yes Then
                Dim item As Integer = dgvDatos.Item(0, idx).Value
                con.Open()
                Dim cmd As New SqlCommand("ELIMINAR_PDB_VENTAS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@ITEM", SqlDbType.Int).Value = item
                cmd.ExecuteNonQuery()
                MessageBox.Show("Registro eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar un registro.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            con.Close()
        End Try
        btn_consultar_Click(Nothing, Nothing)
    End Sub

    Private Sub txtBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusca.TextChanged
        Dim num As Integer
        If chkComprobante.Checked Then
            txtBusca.Focus()
            Dim num2 As Integer = (dgvDatos.RowCount - 1)
            num = 0
            Do While (num <= num2)
                If (txtBusca.Text.ToLower = Strings.Mid((dgvDatos.Item(4, num).Value), 1, Strings.Len(txtBusca.Text)).ToLower) Then
                    dgvDatos.CurrentCell = dgvDatos.Rows.Item(num).Cells.Item(4)
                    Exit Do
                End If
                num += 1
            Loop
        End If
    End Sub

    Private Sub chkComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComprobante.CheckedChanged
        If chkComprobante.Checked Then
            dgvDatos.Sort(dgvDatos.Columns(4), System.ComponentModel.ListSortDirection.Ascending)
            txtBusca.Clear()
            'btn_buscar.Enabled = False
            'btn_sgt.Enabled = False
            txtBusca.Focus()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            LIMPIAR(gbPersona)
            LIMPIAR(gbComprobante)
            LIMPIAR(gbReferencia)
            TabPage2.Parent = Nothing
        End If
    End Sub

    Private Sub btm_eleminar_mes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btm_eleminar_mes.Click
        Try
            Dim rpta As DialogResult = MessageBox.Show(String.Format("¿Desea eliminar los registros de PDT Ventas para el periodo {0}-{1}?", _
                cbo_mes.Text, cbo_año.Text), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If rpta = Windows.Forms.DialogResult.Yes Then
                con.Open()
                Dim cmd As New SqlCommand("ELIMINAR_PDB_VENTAS_MES", con)
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
        dgvDatos.Rows.Clear()
        btn_consultar_Click(Nothing, Nothing)
    End Sub
End Class