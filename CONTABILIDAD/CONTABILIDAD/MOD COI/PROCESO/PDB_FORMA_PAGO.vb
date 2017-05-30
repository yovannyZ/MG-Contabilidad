Imports System.Data.SqlClient
Imports System.IO
Public Class PDB_FORMA_PAGO
    Private Obj As New Class1
    Private Config As String
    Private loPDBFormaPago As New List(Of PDB_FormaPago)
    Private Item As Integer
    Private Idx As Integer
    Private _consultar As Boolean

    Public Structure PDB_FormaPago        
        Public Item As Integer
        Public Año As String
        Public Mes As String
        Public TCompra As String
        Public TComprobante As String
        Public NroDoc As String
        Public SerieComprobante As String
        Public NroComprobante As String
        Public TipoPersona As String
        Public CodPersona As String
        Public TipoDocumento As String
        Public NroDocumento As String
        Public MedioPago As String
        Public Banco As String
        Public NroOp As String
        Public FechaOp As Date
        Public MontoOp As Decimal
    End Structure

    Private Sub ConsultarPDB()
        Try
            loPDBFormaPago.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PDB_FORMA_PAGO", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObePDB As PDB_FormaPago
                While drd.Read
                    ObePDB = New PDB_FormaPago
                    With ObePDB
                        i += 1
                        .Item = drd(0)
                        .Año = drd(1)
                        .Mes = drd(2)
                        .TCompra = drd(3)
                        .TComprobante = drd(4)
                        .NroDoc = drd(5)
                        .SerieComprobante = drd(6)
                        .NroComprobante = drd(7)
                        .TipoPersona = drd(8)
                        .CodPersona = drd(9)
                        .TipoDocumento = drd(10)
                        .NroDocumento = drd(11)
                        .MedioPago = drd(12)
                        .Banco = drd(13)
                        .NroOp = drd(14)
                        .FechaOp = CDate(drd(15)).ToShortDateString
                        .MontoOp = drd(16)
                    End With
                    loPDBFormaPago.Add(ObePDB)
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

    Private Sub GenerarPDB()
        Try
            con.Open()
            Dim cmd As New SqlCommand("INSERTAR_PDB_FORMA_PAGO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FE_AÑO", cbo_año.Text)
            cmd.Parameters.AddWithValue("@FE_MES", Obj.COD_MES(cbo_mes.Text))
            cmd.ExecuteNonQuery()
            MessageBox.Show("Datos generados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error de Aplicación.{0}{1}", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub PDB_FORMA_PAGO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(151) = 0
        Close()
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Seleccione el año", "Aviso", MessageBoxButtons.OK) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Seleccione el mes", "Aviso", MessageBoxButtons.OK) : cbo_mes.Focus() : Exit Sub

        ConsultarPDB()
        If loPDBFormaPago.Count = 0 AndAlso _consultar Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("¿No existen registros del PDB Ventas desea generarlos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarPDB()
                ConsultarPDB()
            End If
        End If
        dgvDatos.Rows.Clear()

        Dim i As Integer
        For i = 0 To loPDBFormaPago.Count - 1
            With loPDBFormaPago.Item(i)
                dgvDatos.Rows.Add(.TCompra, .TComprobante, .SerieComprobante, .NroComprobante, _
                .TipoPersona, .TipoDocumento, .NroDocumento, .MedioPago, .Banco, .NroOp, _
                IIf(.FechaOp = New Date(1900, 1, 1), "", CDate(.FechaOp).ToShortDateString), _
                .MontoOp)
            End With
        Next

    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("F{0}{1}{2}.txt", RUC_EMPRESA, cbo_año.Text, Obj.COD_MES(cbo_mes.Text))
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs)
                    Dim i As Integer
                    'sw.WriteLine("Tipo Compra|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombres|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To dgvDatos.RowCount - 1
                        With loPDBFormaPago(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|", _
                            .TCompra, .TComprobante, .SerieComprobante, .NroComprobante, .TipoPersona, _
                            .TipoDocumento, .NroDocumento, .MedioPago, .Banco, .NroOp.Replace("*", ""), _
                             IIf(.FechaOp = New Date(1900, 1, 1), "", CDate(.FechaOp).ToShortDateString), _
                            .MontoOp))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub
End Class