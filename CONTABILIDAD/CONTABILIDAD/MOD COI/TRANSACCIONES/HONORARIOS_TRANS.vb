Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class HONORARIOS_TRANS

#Region "Variables"
    Private CodOrden As String
    Private obj As New Class1
    Private dtCompras As New DataTable
    Dim DT_DOC As New DataTable
#End Region

#Region "Constructor"
    Private Shared instancia As HONORARIOS_TRANS

    Public Shared Function ObtenerInstancia() As HONORARIOS_TRANS
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New HONORARIOS_TRANS
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
    Sub CargarOrden()
        cboOrden.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_ORDEN_COMPRAS", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboOrden.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CargarDatos()
        Dim Cmd As New SqlCommand("MOSTRAR_REGISTRO_COMPRAS_HONORARIOS", con)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@FE_AÑO", AÑO)
        Cmd.Parameters.AddWithValue("@FE_MES", MES)
        Dim da As New SqlDataAdapter(Cmd)
        da.Fill(dtCompras)

    End Sub

    Function GenerarSql(ByVal orden As String)
        Dim sqlQuery As String = ""
        orden = Convert.ToInt32(orden)
        For i As Integer = 1 To 10
            If i = orden Then

            End If
        Next

        sqlQuery += orden
        Return sqlQuery
    End Function

    Sub CrearDataSet()
        DT_DOC.Columns.Add("FE_AÑO")
        DT_DOC.Columns.Add("FE_MES")
        DT_DOC.Columns.Add("COD_DOC")
        DT_DOC.Columns.Add("NRO_DOC")
        DT_DOC.Columns.Add("COD_PER")
        DT_DOC.Columns.Add("NRO_DOC_PER")
        DT_DOC.Columns.Add("COD_AUX")
        DT_DOC.Columns.Add("COD_COMP")
        DT_DOC.Columns.Add("NRO_COMP")
        DT_DOC.Columns.Add("FECHA_COM")
        DT_DOC.Columns.Add("NOMBRE_PER")
        DT_DOC.Columns.Add("FECHA_DOC")
        DT_DOC.Columns.Add("COD_REF")
        DT_DOC.Columns.Add("NRO_REF")
        DT_DOC.Columns.Add("FECHA_REF")
        DT_DOC.Columns.Add("IMP01")
        DT_DOC.Columns.Add("IMP02")
        DT_DOC.Columns.Add("IMP03")
        DT_DOC.Columns.Add("IMP04")
        DT_DOC.Columns.Add("IMP05")
        DT_DOC.Columns.Add("IMP06")
        DT_DOC.Columns.Add("IMP07")
        DT_DOC.Columns.Add("IMP08")
        DT_DOC.Columns.Add("IMP09")
        DT_DOC.Columns.Add("IMP10")
        DT_DOC.Columns.Add("COD_MONEDA")
        DT_DOC.Columns.Add("TIPO_CAMBIO")
        DT_DOC.Columns.Add("COD_D_H")
        DT_DOC.Columns.Add("NRO_DET")
        DT_DOC.Columns.Add("TASA_DET")
        DT_DOC.Columns.Add("FECHA_DET")
        DT_DOC.Columns.Add("FECHA_PAGO")
        DT_DOC.Columns.Add("STATUS_PAGO")
        DT_DOC.Columns.Add("BASE_REF")
        DT_DOC.Columns.Add("NOMBRE_PC")
        DT_DOC.Columns.Add("IMP_TOTAL")
    End Sub
#End Region

    Private Sub HONORARIOS_TRANS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarOrden()
        CargarDatos()
        CrearDataSet()
    End Sub

    Private Sub Salir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub Transferir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboOrden.SelectedIndex <> -1 Then CodOrden = obj.COD_NRO_ORDEN(cboOrden.Text, "C")

        If String.IsNullOrEmpty(CodOrden) Then
            MessageBox.Show("No se cargo la posición.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim imp01 As Decimal
        Dim row As DataRow
        DT_DOC.Rows.Clear()
        For Each row In dtCompras.Rows
            Dim j As Integer = 1
            For i As Integer = 15 To 24
                If j = Convert.ToInt32(CodOrden) Then
                    imp01 = row.Item(i)
                    Exit For
                End If
                j += 1
            Next
            DT_DOC.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), _
            row(8), row(9), row(10), row(11), row(12), row(13), row(14), imp01, 0, 0, 0, 0, _
            0, 0, 0, 0, 0, row(25), row(26), row(27), row(28), row(29), row(30), row(31), _
            row(32), row(33), NOMBRE_PC, row(34))
        Next

        Dim sqlbc As New SqlBulkCopy(con)
        Dim estado As String
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.REGISTRO_HONORARIOS2"
            sqlbc.WriteToServer(DT_DOC)

            Dim comand1 As New SqlCommand("INSERTAR_TRANSFERENCIA_REGISTRO_HONORARIOS", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            estado = (comand1.ExecuteScalar)
            If estado = "EXITO" Then
                MessageBox.Show("Datos transferidos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(estado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

End Class