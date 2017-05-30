Imports System.Data.SqlClient
Imports System.IO

Public Class frmPleCuenta

    Private Obj As New Class1
    Private Config As String
    Private loPleDiario As New List(Of PLE_Diario)
    Private Item As Integer
    Private Idx As Integer
    Private _fila As Integer
    Private _consultar As Boolean

#Region "Constructor"
    Private Shared instancia As frmPleCuenta

    Public Shared Function ObtenerInstancia() As frmPleCuenta
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frmPleCuenta
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
        'Public Emision As Date
        Public Glosa As String
        'Public Debe As Decimal
        'Public Haber As Decimal
        Public Anotacion As String
        'Public AuxiliarOrigen As String
        'Public ComprobanteOrigen As String
        'Public NumeroComprobanteOrigen As String
        'Public Cod_CC As String
        Public Desc_Plan As String
    End Structure
    Private Sub ConsultarPle()
        Try
            loPleDiario.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PLE_CUENTAS", con)
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
                        .Periodo = drd(0)
                        .Año = drd(1)
                        .Mes = drd(2)
                        .Cuenta = drd(3)
                        .Glosa = drd(4)
                        .Plan = drd(5)
                        .Desc_Plan = drd(6)
                        .Anotacion = drd(7)
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
            Dim cmd As New SqlCommand("[MOSTRAR_GENERAR_PLE_CUENTAS]", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)
            Dim dsPDB As New DataSet
            Dim DA_PDB As New SqlDataAdapter(cmd)
            DA_PDB.Fill(dsPDB)

            Dim I As Integer
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
                    .Cuenta = dr(1)
                    .Glosa = dr(2)
                    .Plan = dr(3)
                    .Desc_Plan = dr(4)
                    Dim mes0 As String
                    If cbo_mes.SelectedIndex = 0 Then
                        mes0 = "1"
                    ElseIf cbo_mes.SelectedIndex >= 1 And cbo_mes.SelectedIndex <= 12 Then
                        mes0 = cbo_mes.SelectedIndex - 1
                    Else
                        mes0 = "11"
                    End If
                    .Anotacion = 1
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
                        Dim cmd As New SqlCommand("INSERTAR_PLE_CUENTAS", con, trx)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@PERIODO", .Periodo)
                        cmd.Parameters.AddWithValue("@FE_AÑO", .Año)
                        cmd.Parameters.AddWithValue("@FE_MES", .Mes)
                        cmd.Parameters.AddWithValue("@COD_CUENTA", .Cuenta)
                        cmd.Parameters.AddWithValue("@GLOSA", .Glosa)
                        cmd.Parameters.AddWithValue("@COD_PLAN", .Plan)
                        cmd.Parameters.AddWithValue("@DESC_PLAN", .Desc_Plan)
                        cmd.Parameters.AddWithValue("@ANOTACION", .Anotacion)
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
                'cbo_año_sunat.Items.Add(Rs3.GetString(0))
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
            'txtPlan.Text = .Plan
            'txtCuenta.Text = .Cuenta
            'dtpFechaOperacion.Value = .Emision
            'txtGlosa.Text = .Glosa
            'txtDebe.Text = Obj.HACER_DECIMAL(.Debe)
            'txtHaber.Text = Obj.HACER_DECIMAL(.Haber)
            'txtAnotacion.Text = .Anotacion
        End With
    End Sub

    Private Sub frmPleDiario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_AÑO()
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
                dgvDatos.Rows.Add(i + 1, .Item, .Periodo, .Cuenta, .Glosa, .Plan, .Desc_Plan, _
                .Anotacion)
            End With
        Next
    End Sub
    Private Sub Exportar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Dim Archivo As String = String.Format("LE{0}{1}{2}00050300001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Dim Archivo As String
            If (loPleDiario.Count = 0) Then
                Archivo = String.Format("LE{0}{1}{2}00050300001011.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Else
                Archivo = String.Format("LE{0}{1}{2}00050300001111.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            End If

            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                    Dim i As Integer
                    For i = 0 To loPleDiario.Count - 1
                        With loPleDiario(i)
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|", _
                            '.Periodo, .Cuenta, .Glosa, .Plan, .Desc_Plan, .Anotacion))
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|", _
                            .Periodo, .Cuenta.Trim, .Glosa, .Plan, "", "", "", .Anotacion))
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
                Dim cmd As New SqlCommand("ELIMINAR_PLE_CUENTAS", con)
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
                            'sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                            '.Periodo, .Item, .Cuenta, .Plan, .Emision, .Glosa, .Debe, .Haber, IIf(.Anotacion = 9, "", aux), .Cod_CC, _
                            '.AuxiliarOrigen, .ComprobanteOrigen))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub
End Class