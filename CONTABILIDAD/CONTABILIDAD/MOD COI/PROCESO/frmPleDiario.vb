Imports System.Data.SqlClient
Imports System.IO

Public Class frmPleDiario

    Private Obj As New Class1
    Private Config As String
    Private loPleDiario As New List(Of PLE_Diario)
    Private Item As Integer
    Private Idx As Integer
    Private _fila As Integer
    Private _consultar As Boolean

#Region "Constructor"
    Private Shared instancia As frmPleDiario

    Public Shared Function ObtenerInstancia() As frmPleDiario
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmPleDiario
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

    Public Structure PLE_Diario
        Public Item As String
        Public Periodo As Integer
        Public Año As String
        Public Mes As String
        Public Plan As String
        Public Cuenta As String
        Public Emision As Date
        Public Glosa As String
        Public Debe As Decimal
        Public Haber As Decimal
        Public Anotacion As String
        Public AuxiliarOrigen As String
        Public ComprobanteOrigen As String
        Public NumeroComprobanteOrigen As String
        Public Cod_CC As String
        Public FechaContable As Date
        Public FechaVencimiento As Date
        Public TipoDocumentoIdentidadEmisor As String
        Public NumeroDocumentoEmisor As String
        Public TipoComprobantePago As String
        Public SerieComprobantePago As String
        Public NumeroComprobantePago As String
        Public CodigoMoneda As String
        Public StatusAna As String
    End Structure
    Private Sub ConsultarPle_ANUAL()
        Try
            loPleDiario.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_ANUAL", con)
            cmd.CommandTimeout = 720
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@FE_MES1", SqlDbType.Char)
            'par0.Value = cbo_año.Text
            par0.Value = cbo_año_sunat.Text : par1.Value = Obj.COD_MES(cbomes.Text) : par2.Value = Obj.COD_MES(cbomes1.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Diario
                While drd.Read
                    ObePla = New PLE_Diario
                    With ObePla
                        i += 1
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .Plan = drd(4)
                        .Cuenta = drd(5)
                        .Emision = CDate(drd(6)).ToShortDateString
                        .Glosa = drd(7)
                        .Debe = drd(8)
                        .Haber = drd(9)
                        .Anotacion = drd(10)
                        .AuxiliarOrigen = drd(11)
                        .ComprobanteOrigen = drd(12)
                        .NumeroComprobanteOrigen = drd(13)
                        .Cod_CC = drd(14)
                    End With
                    loPleDiario.Add(ObePla)
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
            loPleDiario.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_DIARIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Diario
                While drd.Read
                    ObePla = New PLE_Diario
                    With ObePla
                        i += 1
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .Plan = drd(4)
                        .Cuenta = drd(5)
                        .Emision = CDate(drd(6)).ToShortDateString
                        .Glosa = drd(7)
                        .Debe = drd(8)
                        .Haber = drd(9)
                        .Anotacion = drd(10)
                        .AuxiliarOrigen = drd(11)
                        .ComprobanteOrigen = drd(12)
                        .NumeroComprobanteOrigen = drd(13)
                        .Cod_CC = drd(14)
                        .FechaContable = CDate(drd(15))
                        .FechaVencimiento = CDate(drd(16))
                        .TipoDocumentoIdentidadEmisor = drd(17)
                        .NumeroDocumentoEmisor = drd(18)
                        .TipoComprobantePago = drd(19)
                        .SerieComprobantePago = drd(20)
                        .NumeroComprobantePago = drd(21)
                        .CodigoMoneda = drd(22)
                    End With
                    loPleDiario.Add(ObePla)
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

    Private Function CargarDatosGenerar() As List(Of PLE_Diario)
        Dim loPLE As New List(Of PLE_Diario)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_DIARIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)
            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)

            Dim I, idx As Integer
            Dim ObePle As PLE_Diario
            Dim dr As DataRow
            Dim base As Decimal
            For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                dr = dsPDB.Tables(0).Rows(I)
                ObePle = New PLE_Diario
                base = 0
                With ObePle
                    .Item = (I + 1).ToString("000000")
                    .Periodo = dr(0)
                    .Año = cbo_año.Text
                    .Mes = Obj.COD_MES(cbo_mes.Text)
                    .Plan = dr(1)
                    .Cuenta = dr(2)
                    .Emision = dr(3)
                    .Glosa = dr(4)
                    .Debe = dr(5)
                    .Haber = dr(6)
                    Dim mes0 As String
                    If cbo_mes.SelectedIndex = 0 Then
                        mes0 = "1"
                    ElseIf cbo_mes.SelectedIndex >= 1 And cbo_mes.SelectedIndex <= 12 Then
                        mes0 = cbo_mes.SelectedIndex - 1
                    Else
                        mes0 = "11"
                    End If
                    Dim dif As Integer = DateDiff(DateInterval.Month, .Emision, New Date(cbo_año.Text, mes0 + 1, 1))
                    If dif = 0 Then
                        .Anotacion = 1
                    ElseIf dif <= 12 Then
                        '.Anotacion = 8
                        .Anotacion = 1
                    Else
                        .Anotacion = 9
                    End If
                    .AuxiliarOrigen = dr(7)
                    .ComprobanteOrigen = dr(8)
                    .NumeroComprobanteOrigen = dr(9)
                    .Cod_CC = dr(10)
                    .FechaContable = dr(11)
                    If (dr(17) = "B" Or dr(17) = "C" Or dr(17) = "P") Then
                        .FechaVencimiento = dr(12)
                    Else
                        .FechaVencimiento = dr(3)
                    End If

                    If String.IsNullOrEmpty(dr(13).ToString().Trim) Then
                        .TipoDocumentoIdentidadEmisor = ""
                    Else
                        If (dr(13).ToString.Trim = "-") Then
                            .TipoDocumentoIdentidadEmisor = "0"
                        Else
                            .TipoDocumentoIdentidadEmisor = Integer.Parse(dr(13))
                        End If
                    End If
                    If dr(14).ToString().Length = 0 Then
                        .TipoDocumentoIdentidadEmisor = ""
                        .NumeroDocumentoEmisor = ""
                    Else
                        .NumeroDocumentoEmisor = dr(14)
                    End If
                    ''Validacion para ver si se pone el numero de documento
                    'If .TipoDocumentoIdentidadEmisor.Length > 0 AndAlso .NumeroDocumentoEmisor.Length = 0 AndAlso (dr(17) = "B" Or dr(17) = "C" Or dr(17) = "P") Then
                    '    .NumeroDocumentoEmisor = dr(18)
                    '    'ElseIf dr(13).ToString.Length = 0 And dr(14).ToString.Length = 0 And (dr(17) = "B" Or dr(17) = "C" Or dr(17) = "P") Then
                    '    '    .TipoDocumentoIdentidadEmisor = Integer.Parse(dr(20))
                    '    '    .NumeroDocumentoEmisor = dr(18)
                    'End If
                    '----
                    .TipoComprobantePago = dr(15)
                    idx = dr(16).ToString.IndexOf("-")
                    If idx > 0 Then
                        .SerieComprobantePago = dr(16).ToString.Substring(0, idx)
                        .NumeroComprobantePago = dr(16).ToString.Substring(idx + 1)
                    Else
                        .SerieComprobantePago = ""
                        .NumeroComprobantePago = dr(16)
                    End If
                    '-Para completar con ceros las series
                    If .TipoComprobantePago = "01" Or .TipoComprobantePago = "02" Or .TipoComprobantePago = "03" Or .TipoComprobantePago = "07" Or .TipoComprobantePago = "08" Or .TipoComprobantePago = "09" Or .TipoComprobantePago = "20" Then
                        If .SerieComprobantePago.Length = 3 Then
                            .SerieComprobantePago = "0" + .SerieComprobantePago
                        ElseIf .SerieComprobantePago.Length = 2 Then
                            .SerieComprobantePago = "00" + .SerieComprobantePago
                        End If
                    End If
                    '--Para las 50
                    If .TipoComprobantePago = "50" Or .TipoComprobantePago = "53" Then
                        .NumeroComprobantePago = .NumeroComprobantePago.Substring(4)
                    End If
                    '--
                    '--Para las 00
                    If .TipoComprobantePago = "00" And dr(16).ToString().Length = 0 Then
                        .NumeroComprobantePago = "00"
                    End If
                    '--
                    '-Para las LT y TF
                    If .TipoComprobantePago = "TF" Or .TipoComprobantePago = "LT" Or .TipoComprobantePago = "PR" Or .TipoComprobantePago = "SU" Or .TipoComprobantePago = "CH" Or .TipoComprobantePago = "DP" Or .TipoComprobantePago = "AN" Or .TipoComprobantePago = "PG" Then
                        .TipoComprobantePago = "00"
                        .SerieComprobantePago = ""
                        .NumeroComprobantePago = dr(16).ToString()
                    End If
                    '-
                    '-Para las RI
                    If .TipoComprobantePago = "RI" Then
                        .TipoComprobantePago = "00"
                    End If
                    '-
                    '-Validación de los inicios y cierres
                    If .ComprobanteOrigen = "INI" Then ' Or .ComprobanteOrigen = "CIE"
                        .TipoComprobantePago = ""
                        .SerieComprobantePago = ""
                        .NumeroComprobantePago = ""
                    End If
                    '-Para las monedas
                    If String.IsNullOrEmpty(dr(18).ToString) Or dr(18).ToString().ToUpper = "AJU" Then
                        .CodigoMoneda = "PEN"
                    Else
                        .CodigoMoneda = dr(18)
                    End If

                End With
                loPLE.Add(ObePle)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al generar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            loPLE.Clear()
        End Try
        Return loPLE
    End Function

    Private Sub GenerarPleDiario()
        Dim trx As SqlTransaction = Nothing
        Dim loPle As List(Of PLE_Diario) = CargarDatosGenerar()
        If loPle.Count > 0 Then
            Try
                con.Open()
                trx = con.BeginTransaction
                Dim i As Integer
                For i = 0 To loPle.Count - 1
                    With loPle(i)
                        Dim cmd As New SqlCommand("INSERTAR_PLE_DIARIO", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ITEM", .Item)
                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                        cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                        cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                        cmd.Parameters.AddWithValue("@COD_PLAN", .Plan)
                        cmd.Parameters.AddWithValue("@COD_CUENTA", .Cuenta)
                        cmd.Parameters.AddWithValue("@FECHA_OPE", .Emision)
                        cmd.Parameters.AddWithValue("@GLOSA", .Glosa)
                        cmd.Parameters.AddWithValue("@DEBE", .Debe)
                        cmd.Parameters.AddWithValue("@HABER", .Haber)
                        cmd.Parameters.AddWithValue("@ANOTACION", .Anotacion)

                        cmd.Parameters.AddWithValue("@COD_AUX_ORIG", .AuxiliarOrigen)
                        cmd.Parameters.AddWithValue("@COD_COMP_ORIG", .ComprobanteOrigen)
                        cmd.Parameters.AddWithValue("@NRO_COMP_ORIG", .NumeroComprobanteOrigen)
                        cmd.Parameters.AddWithValue("@COD_CC", .Cod_CC)
                        cmd.Parameters.AddWithValue("@FECHA_CONTABLE", .FechaContable)
                        cmd.Parameters.AddWithValue("@FECHA_VENCIMIENTO", .FechaVencimiento)
                        cmd.Parameters.AddWithValue("@TIPO_DOC_EMISOR", .TipoDocumentoIdentidadEmisor)
                        cmd.Parameters.AddWithValue("@NRO_DOC_EMISOR", .NumeroDocumentoEmisor)
                        cmd.Parameters.AddWithValue("@TIPO_COMP_PAGO", .TipoComprobantePago)
                        cmd.Parameters.AddWithValue("@SERIE_COMP_PAGO", .SerieComprobantePago)
                        cmd.Parameters.AddWithValue("@NRO_COMP_PAGO", .NumeroComprobantePago)
                        cmd.Parameters.AddWithValue("@COD_MONEDA", .CodigoMoneda)
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

    Private Sub LIMPIAR(ByVal Contenedor As Object)
        Dim x As Control
        For Each x In Contenedor.Controls
            If TypeOf x Is TextBox Then CType(x, TextBox).Clear()
            If TypeOf x Is ListBox Or TypeOf x Is ComboBox Then CType(x, ListControl).SelectedIndex = -1
            If TypeOf x Is CheckBox Then CType(x, CheckBox).Checked = False
        Next
    End Sub

    Private Function BUSCAR_ITEM(ByVal OPDB As PLE_Diario) As Boolean
        Return OPDB.Item = Item
    End Function

    Private Sub CARGAR_DETALLES()
        With loPleDiario(Idx)
            txtPlan.Text = .Plan
            txtCuenta.Text = .Cuenta
            dtpFechaOperacion.Value = .Emision
            txtGlosa.Text = .Glosa
            txtDebe.Text = Obj.HACER_DECIMAL(.Debe)
            txtHaber.Text = Obj.HACER_DECIMAL(.Haber)
            txtAnotacion.Text = .Anotacion

            cboComprobante.Text = Obj.DESC_DOC(.TipoComprobantePago)
            txtSerie.Text = .SerieComprobantePago
            txtNroComprobante.Text = .NumeroComprobantePago
        End With
    End Sub

    Private Sub frmPleDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabPage2.Parent = Nothing
        KeyPreview = True
        CARGAR_AÑO()
        CBO_DOCUMENTO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub

    Private Sub Consultar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cbo_mes.Focus() : Exit Sub

        dgvDatos.Rows.Clear()
        ConsultarPle()
        If loPleDiario.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("¿No existen registros del PLE Diario desea generarlos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarPleDiario()
                ConsultarPle()
            End If
        End If
        Dim i As Integer
        For i = 0 To loPleDiario.Count - 1
            With loPleDiario.Item(i)
                dgvDatos.Rows.Add(i + 1, .Item, .Periodo, .Plan, .Cuenta, .Emision.ToShortDateString(), _
                .FechaContable.ToShortDateString(), .FechaVencimiento.ToShortDateString(), .Glosa, _
                .Debe, .Haber, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen, .Cod_CC, _
                .CodigoMoneda, .TipoDocumentoIdentidadEmisor, .NumeroDocumentoEmisor, .TipoComprobantePago, .SerieComprobantePago, .NumeroComprobantePago)
            End With
        Next
    End Sub

    Private Sub Modificar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        TabPage2.Parent = TabControl1
        TabControl1.SelectedTab = TabPage2
        _fila = dgvDatos.CurrentRow.Index
        Item = dgvDatos.Item(1, dgvDatos.CurrentRow.Index).Value
        Dim pred As New Predicate(Of PLE_Diario)(AddressOf BUSCAR_ITEM)
        Idx = loPleDiario.FindIndex(pred)
        If Idx > -1 Then
            'LIMPIAR(gbComprobante)
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
            'LIMPIAR(gbComprobante)
            TabPage2.Parent = Nothing
        End If
    End Sub

    Private Sub Grabar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim opleVentas As PLE_Diario = loPleDiario(Idx)
        With opleVentas
            .Plan = txtPlan.Text
            .Cuenta = txtCuenta.Text
            .Debe = txtDebe.Text
            .Haber = txtHaber.Text
            .Anotacion = txtAnotacion.Text
            .Glosa = txtGlosa.Text

            .TipoComprobantePago = Obj.COD_DOC(cboComprobante.Text)
            .SerieComprobantePago = txtSerie.Text
            .NumeroComprobantePago = txtNroComprobante.Text
            Try
                con.Open()
                Dim cmd As New SqlCommand("ACTUALIZAR_PLE_DIARIO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ITEM", .Item)
                cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                cmd.Parameters.AddWithValue("@ANOTACION", .Anotacion)
                cmd.Parameters.AddWithValue("@GLOSA", .Glosa)
                '---------------------
                cmd.Parameters.AddWithValue("@TIPO_COMP_PAGO", .TipoComprobantePago)
                cmd.Parameters.AddWithValue("@SERIE_COMP_PAGO", .SerieComprobantePago)
                cmd.Parameters.AddWithValue("@NRO_COMP_PAGO", .NumeroComprobantePago)
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
            Dim Archivo As String = String.Format("LE{0}{1}{2}00050100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    For i = 0 To loPleDiario.Count - 1
                        With loPleDiario(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen.Replace("$", "D") & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Plan, .Cuenta, .Emision.ToShortDateString(), .Glosa, _
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}", _
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, IIf(.AuxiliarOrigen = 99, IIf(.ComprobanteOrigen = "INI", "A" & aux, "C" & aux), "M" & aux), .Plan, .Cuenta, .Emision.ToShortDateString(), .Glosa, _
                            '.Debe, .Haber, "", "", "", .Anotacion))
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|", _
                            .Periodo, _
                            .AuxiliarOrigen & .ComprobanteOrigen & .NumeroComprobanteOrigen, _
                            IIf(.AuxiliarOrigen = 99, IIf(.ComprobanteOrigen = "INI", "A" & aux, "C" & aux), "M" & aux), _
                            .Cuenta, _
                            "", _
                            .Cod_CC.Trim(), _
                            .CodigoMoneda, _
                            .TipoDocumentoIdentidadEmisor.Trim(), _
                            .NumeroDocumentoEmisor.Trim(), _
                            .TipoComprobantePago, _
                            .SerieComprobantePago, _
                            .NumeroComprobantePago, _
                            .FechaContable.ToShortDateString(), _
                            .FechaVencimiento.ToShortDateString(), _
                            .Emision.ToShortDateString(), _
                            .Glosa.Replace("/", "-"), _
                            "", _
                            .Debe, _
                            .Haber, _
                            "", _
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
            Dim rpta As DialogResult = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If rpta = Windows.Forms.DialogResult.Yes Then
                con.Open()
                Dim cmd As New SqlCommand("ELIMINAR_PLE_DIARIO", con)
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

    Private Sub btn_exportar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}00050100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    'TITULOS
                    sw.WriteLine(String.Format("DPERIODO|DNUMSIOPE|DCODCUE|DNUMCTACON|DFECOPE|DGLOSA|DDEBE|DHABER|DESTOPE|DCENCOS|DINTKARDEX|DINTVTACOM|DINTREG"))
                    For i = 0 To loPleDiario.Count - 1
                        With loPleDiario(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                            .Periodo, .Item, .Cuenta, .Plan, .Emision, .Glosa, .Debe, .Haber, IIf(.Anotacion = 9, "", aux), .Cod_CC, _
                            .AuxiliarOrigen, .ComprobanteOrigen))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btn_consultar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_año_sunat.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        dgvdatos_sunat.Rows.Clear()
        ConsultarPle_ANUAL()
        Dim i As Integer
        For i = 0 To loPleDiario.Count - 1
            With loPleDiario.Item(i)
                dgvdatos_sunat.Rows.Add(i + 1, .Item, .Periodo, .Plan, .Cuenta, .Emision.ToShortDateString(), .Glosa, _
                .Debe, .Haber, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen, .Cod_CC)
            End With
        Next
    End Sub

    Private Sub btnexportar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_año_sunat.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        ConsultarPle_ANUAL()
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}00050100001111.txt", RUC_EMPRESA, cbo_año_sunat.Text, Obj.COD_MES(cbomes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    'TITULOS
                    sw.WriteLine(String.Format("DPERIODO|DNUMSIOPE|DCODCUE|DNUMCTACON|DFECOPE|DGLOSA|DDEBE|DHABER|DESTOPE|DCENCOS|DINTKARDEX|DINTVTACOM|DINTREG"))
                    For i = 0 To loPleDiario.Count - 1
                        With loPleDiario(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}", _
                            .Periodo, .Item, .Plan, .Cuenta, Format(.Emision, "dd/MM/yyyy"), .Glosa, .Debe, .Haber, "1", IIf(Microsoft.VisualBasic.Left(loPleDiario(i).Cuenta, 1) = 9, .Cod_CC, " "), _
                            " ", IIf(.AuxiliarOrigen = "04" Or .AuxiliarOrigen = "05", .AuxiliarOrigen & "-" & .ComprobanteOrigen & "-" & .NumeroComprobanteOrigen, " "), .AuxiliarOrigen & "-" & .ComprobanteOrigen & "-" & .NumeroComprobanteOrigen))
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
    Private Sub CBO_DOCUMENTO()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboComprobante.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub
End Class