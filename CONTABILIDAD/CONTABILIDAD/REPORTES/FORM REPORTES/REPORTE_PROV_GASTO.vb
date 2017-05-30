Imports System.Data.SqlClient
Public Class REPORTE_PROV_GASTO
    Dim OBJ As New Class1
    Dim MES00, ord As String
    Dim REP1 As New REP_PROV_GASTO
    Dim REP2 As New REP_PROV_VENTAS_GASTO
    Private Sub btn_cancelar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar1.Click
        main(136) = 0
        Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_orden.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_orden.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        MES00 = OBJ.COD_MES(cbo_mes.Text)
        If cbo_orden.SelectedIndex = 0 Then
            ord = "0"
        Else
            ord = "1"
        End If
        Dim TITULO, TITULO_CLIENTE As String
        TITULO = "" : TITULO_CLIENTE = ""
        Select Case cbo_prov.SelectedIndex
            Case "0"
                TITULO = "Compras"
                TITULO_CLIENTE = "Proveedor"
            Case "1"
                TITULO = "Ventas"
                TITULO_CLIENTE = "Cliente"
        End Select
        '------------------------------------------------------------------------
        Select Case cbo_prov.SelectedIndex
            Case "0"
                importes_compras()
                LLENAR_DATASET()
                REP1.CREAR_REPORTE(ord, TITULO, cbo_mes.Text, TITULO_CLIENTE)
                REP1.ShowDialog()
            Case "1"
                importes_ventas()
                HALLAR_FALTANTE()
                LLENAR_DATASET_VENTAS()
                REP2.CREAR_REPORTE(ord, TITULO, cbo_mes.Text, TITULO_CLIENTE)
                REP2.ShowDialog()
        End Select
    End Sub
    Sub HALLAR_FALTANTE()
        Dim FALTANTE As String = ""
        Dim I, CONT As Integer
        CONT = dgw_importe.RowCount - 1
        For I = 1 To CONT
            If dgw_importe.Item(11, I).Value = dgw_importe.Item(11, I - 1).Value And dgw_importe.Item(8, I).Value = dgw_importe.Item(8, I - 1).Value Then
                If dgw_importe.Item(15, I).Value - 1 = dgw_importe.Item(15, I - 1).Value Then
                    FALTANTE = ""
                    dgw_importe.Item(16, I - 1).Value = FALTANTE
                Else
                    FALTANTE = "*"
                    dgw_importe.Item(16, I - 1).Value = FALTANTE
                End If
            Else
                FALTANTE = ""
                dgw_importe.Item(16, I - 1).Value = FALTANTE
            End If
        Next
    End Sub
   Sub importes_compras()
        dgw_importe.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_REGISTRO_COMPRAS_GASTOS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@fe_año", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@fe_mes", SqlDbType.Char).Value = MES00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Dim PROV As String
                PROV = Rs3.GetValue(13)
                If PROV <> "0" Then PROV = "1"
                dgw_importe.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), PROV, Rs3.GetValue(14))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_ventas()
        dgw_importe.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_REGISTRO_VENTAS_GASTO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@fe_año", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@fe_mes", SqlDbType.Char).Value = MES00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Dim PROV As String
                PROV = Rs3.GetValue(13)
                If PROV <> "0" Then PROV = "1"
                dgw_importe.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), PROV, "", Rs3.GetValue(14))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LLENAR_DATASET()
        REP1.LIMPIAR()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            REP1.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, dgw_importe.Item(9, I).Value.ToString, dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, (dgw_importe.Item(12, I).Value), dgw_importe.Item(13, I).Value.ToString, dgw_importe.Item(16, I).Value, dgw_importe.Item(14, I).Value.ToString)
            I += 1
        Loop
    End Sub
    Sub LLENAR_DATASET_VENTAS()
        REP2.LIMPIAR()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_importe.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            'REP2.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, Decimal.Parse(dgw_importe.Item(9, I).Value), dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value.ToString, (dgw_importe.Item(13, I).Value), Decimal.Parse((dgw_importe.Item(32, I).Value)), Decimal.Parse((dgw_importe.Item(33, I).Value)), Decimal.Parse((dgw_importe.Item(34, I).Value)), Decimal.Parse((dgw_importe.Item(35, I).Value)), Decimal.Parse((dgw_importe.Item(36, I).Value)), Decimal.Parse((dgw_importe.Item(37, I).Value)), Decimal.Parse((dgw_importe.Item(38, I).Value)), Decimal.Parse((dgw_importe.Item(39, I).Value)), dgw_importe.Item(40, I).Value)
            REP2.llenar_dt(dgw_importe.Item(0, I).Value.ToString, dgw_importe.Item(1, I).Value.ToString, dgw_importe.Item(2, I).Value.ToString, Date.Parse(dgw_importe.Item(3, I).Value.ToString), Date.Parse(dgw_importe.Item(4, I).Value.ToString), dgw_importe.Item(5, I).Value.ToString, dgw_importe.Item(6, I).Value.ToString, dgw_importe.Item(7, I).Value.ToString, dgw_importe.Item(8, I).Value.ToString, dgw_importe.Item(9, I).Value.ToString, dgw_importe.Item(10, I).Value.ToString, dgw_importe.Item(11, I).Value.ToString, dgw_importe.Item(12, I).Value, dgw_importe.Item(13, I).Value.ToString, dgw_importe.Item(16, I).Value, dgw_importe.Item(14, I).Value.ToString)
            I += 1
        Loop
    End Sub
    Private Sub REPORTE_PROV1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_PROV1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        cbo_orden.SelectedIndex = 2
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub
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
    Private Sub cbo_prov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_prov.SelectedIndexChanged
        If cbo_prov.SelectedIndex = 1 Then
            cbo_orden.Enabled = False
        Else
            cbo_orden.Enabled = True
        End If
    End Sub
End Class