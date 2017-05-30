Imports System.Data.SqlClient
Imports System.IO

Public Class frmPleMayor
    Private Obj As New Class1
    Private Config As String
    Private loPleMayor As New List(Of PLE_Mayor)
    Private Item As Integer
    Private Idx As Integer
    Private _fila As Integer
    Private _consultar As Boolean

#Region "Constructor"
    Private Shared instancia As frmPleMayor

    Public Shared Function ObtenerInstancia() As frmPleMayor
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmPleMayor
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

    Public Structure PLE_Mayor
        Public Item As String
        Public Periodo As Integer
        Public Año As String
        Public Mes As String
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
        Public Plan As String
        Public CodigoMoneda As String
        Public FechaContable As Date
        Public FechaVencimiento As Date
        Public TipoDocumentoIdentidadEmisor As String
        Public NumeroDocumentoEmisor As String
        Public TipoComprobantePago As String
        Public SerieComprobantePago As String
        Public NumeroComprobantePago As String

        Public StatusAna As String
    End Structure
    Private Sub ConsultarPle_ANUAL()
        Try
            loPleMayor.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_MAYOR_ANUAL", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@FE_MES1", SqlDbType.Char)
            'par0.Value = cbo_año.Text
            par0.Value = cbo_año_sunat.Text : par1.Value = Obj.COD_MES(cbomes.Text) : par2.Value = Obj.COD_MES(cbomes1.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Mayor
                While drd.Read
                    ObePla = New PLE_Mayor
                    With ObePla
                        i += 1
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .Cuenta = drd(4)
                        .Emision = CDate(drd(5)).ToShortDateString
                        .Glosa = drd(6)
                        .Debe = drd(7)
                        .Haber = drd(8)
                        .Anotacion = drd(9)
                        .AuxiliarOrigen = drd(10)
                        .ComprobanteOrigen = drd(11)
                        .NumeroComprobanteOrigen = drd(12)
                        .Cod_CC = drd(13)
                    End With
                    loPleMayor.Add(ObePla)
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
            loPleMayor.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_MAYOR", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePla As PLE_Mayor
                While drd.Read
                    ObePla = New PLE_Mayor
                    With ObePla
                        i += 1
                        .Item = drd(0)
                        .Periodo = drd(1)
                        .Año = drd(2)
                        .Mes = drd(3)
                        .Cuenta = drd(4)
                        .Emision = CDate(drd(5)).ToShortDateString
                        .Glosa = drd(6)
                        .Debe = drd(7)
                        .Haber = drd(8)
                        .Anotacion = drd(9)
                        .AuxiliarOrigen = drd(10)
                        .ComprobanteOrigen = drd(11)
                        .NumeroComprobanteOrigen = drd(12)
                        .Cod_CC = drd(13)
                        .Plan = drd(14)
                        .FechaContable = CDate(drd(15)).ToShortDateString
                        .FechaVencimiento = CDate(drd(16)).ToShortDateString
                        .TipoDocumentoIdentidadEmisor = drd(17)
                        .NumeroDocumentoEmisor = drd(18)
                        .TipoComprobantePago = drd(19)
                        .SerieComprobantePago = drd(20)
                        .NumeroComprobantePago = drd(21)
                        .CodigoMoneda = drd(22)
                    End With
                    loPleMayor.Add(ObePla)
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

    Private Function CargarDatosGenerar() As List(Of PLE_Mayor)
        Dim loPLE As New List(Of PLE_Mayor)
        Try
            Dim cmd As New SqlCommand("MOSTRAR_GENERAR_PLE_MAYOR", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)
            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)

            Dim I, idx As Integer
            Dim ObePle As PLE_Mayor
            Dim dr As DataRow
            Dim base As Decimal
            For I = 0 To dsPDB.Tables(0).Rows.Count - 1
                dr = dsPDB.Tables(0).Rows(I)
                ObePle = New PLE_Mayor
                base = 0
                With ObePle
                    .Item = (I + 1).ToString("000000")
                    .Periodo = dr(0)
                    .Año = cbo_año.Text
                    .Mes = Obj.COD_MES(cbo_mes.Text)
                    .Cuenta = dr(1)
                    .Emision = dr(2)
                    .Glosa = dr(3)
                    .Debe = dr(4)
                    .Haber = dr(5)
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
                    .AuxiliarOrigen = dr(6)
                    .ComprobanteOrigen = dr(7)
                    .NumeroComprobanteOrigen = dr(8)
                    .Cod_CC = dr(9)
                    .Plan = dr(10)

                    If String.IsNullOrEmpty(dr(11).ToString().Trim) Then
                        .TipoDocumentoIdentidadEmisor = ""
                    Else
                        If (dr(11).ToString.Trim = "-") Then
                            .TipoDocumentoIdentidadEmisor = "0"
                        Else
                            .TipoDocumentoIdentidadEmisor = Integer.Parse(dr(11))
                        End If
                    End If
                    If dr(11).ToString() = "00" And dr(12).ToString().Length = 0 Then
                        .TipoDocumentoIdentidadEmisor = ""
                        .NumeroDocumentoEmisor = ""
                    Else
                        .NumeroDocumentoEmisor = dr(12)
                    End If

                    'Validacion para ver si se pone el numero de documento 
                    'If .TipoDocumentoIdentidadEmisor.Length > 0 AndAlso .NumeroDocumentoEmisor.Length = 0 AndAlso (dr(17) = "B" Or dr(17) = "C" Or dr(17) = "P") Then
                    '    .NumeroDocumentoEmisor = dr(18)
                    '    'ElseIf dr(11).ToString.Length = 0 And dr(12).ToString.Length = 0 And (dr(17) = "B" Or dr(17) = "C" Or dr(17) = "P") Then
                    '    '    .TipoDocumentoIdentidadEmisor = Integer.Parse(dr(20))
                    '    '    .NumeroDocumentoEmisor = dr(18)
                    'End If
                    '--
                    .TipoComprobantePago = dr(13)
                    idx = dr(14).ToString.IndexOf("-")
                    If idx > 0 Then
                        .SerieComprobantePago = dr(14).ToString.Substring(0, idx)
                        .NumeroComprobantePago = dr(14).ToString.Substring(idx + 1)
                    Else
                        .SerieComprobantePago = ""
                        .NumeroComprobantePago = dr(14).ToString()
                    End If
                    '-para completar con ceros las series
                    If .TipoComprobantePago = "01" Or .TipoComprobantePago = "02" Or .TipoComprobantePago = "03" Or .TipoComprobantePago = "07" Or .TipoComprobantePago = "08" Or .TipoComprobantePago = "09" Or .TipoComprobantePago = "20" Then
                        If .SerieComprobantePago.Length = 3 Then
                            .SerieComprobantePago = "0" + .SerieComprobantePago
                        ElseIf .SerieComprobantePago.Length = 2 Then
                            .SerieComprobantePago = "00" + .SerieComprobantePago
                        End If
                    End If
                    '-
                    '--Para las 50
                    If .TipoComprobantePago = "50" Or .TipoComprobantePago = "53" Then
                        .NumeroComprobantePago = .NumeroComprobantePago.Substring(4)
                    End If
                    '--
                    '--Para las 00
                    If .TipoComprobantePago = "00" And dr(14).ToString().Length = 0 Then
                        .NumeroComprobantePago = "00"
                    End If
                    '--
                    '-Para las LT y TF
                    If .TipoComprobantePago = "TF" Or .TipoComprobantePago = "LT" Or .TipoComprobantePago = "PR" Or .TipoComprobantePago = "SU" Or .TipoComprobantePago = "DP" Or .TipoComprobantePago = "CH" Or .TipoComprobantePago = "AN" Or .TipoComprobantePago = "PG" Then
                        .TipoComprobantePago = "00"
                        .SerieComprobantePago = ""
                        .NumeroComprobantePago = dr(14).ToString()
                    End If
                    '-
                    '-Para las RI
                    If .TipoComprobantePago = "RI" Then
                        .TipoComprobantePago = "00"
                    End If
                    '-
                    '-Validación de los inicios y cierres
                    If .ComprobanteOrigen = "INI" Then 'Or .ComprobanteOrigen = "CIE"
                        .TipoComprobantePago = ""
                        .SerieComprobantePago = ""
                        .NumeroComprobantePago = ""
                    End If
                    '-
                    .FechaContable = dr(15)
                    '.FechaVencimiento = dr(16)
                    If String.IsNullOrEmpty(dr(17).ToString) Then
                        .FechaVencimiento = dr(2)
                    Else
                        If (dr(17) = "B" Or dr(17) = "C" Or dr(17) = "P") Then
                            .FechaVencimiento = dr(16)
                        Else
                            .FechaVencimiento = dr(2)
                        End If
                    End If
                    '-Para las monedas
                    If String.IsNullOrEmpty(dr(18).ToString) Or dr(18).ToString.ToString() = "AJU" Then
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

    Private Sub GenerarPleMayor()
        Dim trx As SqlTransaction = Nothing
        Dim loPle As List(Of PLE_Mayor) = CargarDatosGenerar()
        If loPle.Count > 0 Then
            Try
                con.Open()
                trx = con.BeginTransaction
                Dim i As Integer
                For i = 0 To loPle.Count - 1
                    With loPle(i)
                        Dim cmd As New SqlCommand("INSERTAR_PLE_MAYOR", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@ITEM", .Item)
                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                        cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                        cmd.Parameters.AddWithValue("@FE_MES", .Mes)
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
                        cmd.Parameters.AddWithValue("@COD_PLAN", .Plan)

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

    Private Function BUSCAR_ITEM(ByVal OPDB As PLE_Mayor) As Boolean
        Return OPDB.Item = Item
    End Function

    Private Sub CARGAR_DETALLES()
        With loPleMayor(Idx)
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

    Private Sub frmPleMayor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        If loPleMayor.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("¿No existen registros del PLE Mayor desea generarlos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarPleMayor()
                ConsultarPle()
            End If
        End If
        Dim i As Integer
        For i = 0 To loPleMayor.Count - 1
            With loPleMayor.Item(i)
                dgvDatos.Rows.Add(i + 1, .Item, .Periodo, .Cuenta, .Emision.ToShortDateString(), .FechaContable.ToShortDateString, .FechaVencimiento.ToShortDateString, .Glosa, _
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
        Dim pred As New Predicate(Of PLE_Mayor)(AddressOf BUSCAR_ITEM)
        Idx = loPleMayor.FindIndex(pred)
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
        Dim opleVentas As PLE_Mayor = loPleMayor(Idx)
        With opleVentas
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
                Dim cmd As New SqlCommand("ACTUALIZAR_PLE_MAYOR", con)
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
            Dim Archivo As String = String.Format("LE{0}{1}{2}00060100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    For i = 0 To loPleMayor.Count - 1
                        With loPleMayor(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            '.Periodo, .AuxiliarOrigen & .ComprobanteOrigen.Replace("$", "D") & .NumeroComprobanteOrigen, "M" & IIf(.Anotacion = 9, "", aux), .Plan, .Cuenta, .Emision.ToShortDateString(), .Glosa, _
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|", _
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
                Dim cmd As New SqlCommand("ELIMINAR_PLE_MAYOR", con)
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
            Dim Archivo As String = String.Format("LE{0}{1}{2}00060100001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    sw.WriteLine(String.Format("MPERIODO|MNUMSIOPE|MNUMCTACON|MFECOPE|MGLOSA|MDEBE|MHABER|MESTOPE|MCENCOS|MINTKARDEX|MINTVTACOM|MINTREG"))
                    For i = 0 To loPleMayor.Count - 1
                        With loPleMayor(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                            .Periodo, .Item, .Cuenta, .Emision.ToShortDateString(), .Glosa, .Debe, .Haber, IIf(.Anotacion = 9, "", aux), .Cod_CC, .ComprobanteOrigen, .NumeroComprobanteOrigen, .AuxiliarOrigen))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub

    Private Sub btn_consulta_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_año_sunat.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        dgvdata_sunat.Rows.Clear()
        ConsultarPle_ANUAL()
        Dim i As Integer
        For i = 0 To loPleMayor.Count - 1
            With loPleMayor.Item(i)
                dgvdata_sunat.Rows.Add(i + 1, .Item, .Periodo, .Cuenta, .Emision.ToShortDateString(), .Glosa, _
                .Debe, .Haber, .Anotacion, .AuxiliarOrigen, .ComprobanteOrigen, .NumeroComprobanteOrigen, .Cod_CC)
            End With
        Next
    End Sub

    Private Sub btexportar_sunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btexportar_sunat.Click
        If cbo_año_sunat.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbo_año_sunat.Focus() : Exit Sub
        If cbomes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes inicial", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes.Focus() : Exit Sub
        If cbomes1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el mes final", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : cbomes1.Focus() : Exit Sub
        ConsultarPle_ANUAL()
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}00060100001111.txt", RUC_EMPRESA, cbo_año_sunat.Text, Obj.COD_MES(cbomes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    Dim aux As Integer
                    sw.WriteLine(String.Format("MPERIODO|MNUMSIOPE|MNUMCTACON|MFECOPE|MGLOSA|MDEBE|MHABER|MESTOPE|MCENCOS|MINTKARDEX|MINTVTACOM|MINTREG"))
                    For i = 0 To loPleMayor.Count - 1
                        With loPleMayor(i)
                            If .Anotacion <> 9 Then
                                aux += 1
                            End If
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                            .Periodo, .Item, .Cuenta, .Emision.ToShortDateString(), .Glosa, .Debe, .Haber, "1", IIf(Microsoft.VisualBasic.Left(loPleMayor(i).Cuenta, 1) = 9, .Cod_CC, " "), _
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