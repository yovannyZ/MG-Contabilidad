Imports System.Data.SqlClient
Imports System.IO
Public Class PDB_TIPO_CAMBIO
    Private Obj As New Class1
    Private loTipoCambio As New List(Of TipoCambio)

    Public Structure TipoCambio
        Public Año As String
        Public Mes As String
        Public Fecha As Date
        Public TipoCompra As Decimal
        Public TipoVenta As Decimal
    End Structure

    Private Sub ConsultarTipoCambio()
        Try
            loTipoCambio.Clear()
            con.Open()
            Dim cmd As New SqlCommand("MOSTRAR_PDB_TIPO_CAMBIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par0 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            par0.Value = cbo_año.Text
            par1.Value = Obj.COD_MES(cbo_mes.Text)

            Dim i As Integer
            Dim drd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleResult)
            If drd IsNot Nothing AndAlso drd.HasRows Then
                Dim ObeTipoCambio As TipoCambio
                While drd.Read
                    ObeTipoCambio = New TipoCambio
                    With ObeTipoCambio
                        .Año = drd(0)
                        .Mes = drd(1)
                        .Fecha = CDate(drd(2)).ToShortDateString
                        .TipoCompra = drd(3)
                        .TipoVenta = drd(4)
                    End With
                    loTipoCambio.Add(ObeTipoCambio)
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub GenerarTipoCambio()
        Try
            con.Open()
            Dim i As Integer

            Dim cmd As New SqlCommand("GENERAR_PDB_TIPO_CAMBIO", con)
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

    Private Sub LIMPIAR(ByVal Contenedor As Object)
        Dim x As Control
        For Each x In Contenedor.Controls
            If TypeOf x Is TextBox Then CType(x, TextBox).Clear()
            If TypeOf x Is ListBox Or TypeOf x Is ComboBox Then CType(x, ListControl).SelectedIndex = -1
            If TypeOf x Is CheckBox Then CType(x, CheckBox).Checked = False
        Next
    End Sub

    Private Sub PDB_TIPO_CAMBIO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PDB_TIPO_CAMBIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabPage2.Parent = Nothing
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub

    Private Sub btn_consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consultar.Click
        ConsultarTipoCambio()
        If loTipoCambio.Count = 0 Then
            Dim rpta As DialogResult = Windows.Forms.DialogResult.Yes
            rpta = MessageBox.Show("¿No existen registros del PDB Compras desea generarlos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                GenerarTipoCambio()
                ConsultarTipoCambio()
            End If
        End If
        dgvDatos.Rows.Clear()
        Dim i As Integer
        For i = 0 To loTipoCambio.Count - 1
            With loTipoCambio.Item(i)
                dgvDatos.Rows.Add(.Fecha, .TipoCompra, .TipoVenta)
            End With
        Next
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(152) = 0
        Close()
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("{0}.tc", RUC_EMPRESA)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs)
                    Dim i As Integer
                    'sw.WriteLine("Tipo Compra|Tipo Comp.|Fecha Emi.|Serie|Numero|Tipo Per.|Tipo Doc.|Num.Doc.|Rz.Social|Ape.Pat|Ape.Mat|Nombre1|Nombre2|Tipo Mon.|Cod.Dest.|Num.Dest.|Base Imp.|ISC|IGV|Otros|Det.|Cod.Det.|Nro.Det.|Ret.|Tipo Comp.Ref|Serie Ref.|Nro.Comp.Ref|Fecha Emi.Ref.|Base Imp.Ref|IGV Ref.")
                    For i = 0 To loTipoCambio.Count - 1
                        With loTipoCambio(i)
                            sw.WriteLine(String.Format("{0}|{1}|{2}|", _
                            CDate(.Fecha).ToShortDateString, .TipoCompra, .TipoVenta))
                        End With
                    Next
                    MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        End If
    End Sub
End Class