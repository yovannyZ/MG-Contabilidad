Imports System.Data.SqlClient
Public Class CERTIFICADO_4TA
    Dim TIPO_MOV, W1, W2 As String
    Dim obj As New Class1
    Dim REP As New REP_CERTIFICADO_4TA
    Dim cRet As Decimal
    Dim sRet As Decimal

    Private Sub CERTIFICADO_4TA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CERTIFICADO_4TA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        DGW_DETALLE.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
    End Sub

    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(148) = 0
        Close()
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
        If cbo_prov.SelectedIndex = 0 Then
            TIPO_MOV = "C"
            CARGAR_ORDEN1()
            CARGAR_ORDEN2()
        ElseIf cbo_prov.SelectedIndex = 1 Then
            TIPO_MOV = "H"
            CARGAR_ORDEN1()
            CARGAR_ORDEN2()
        End If
    End Sub

    Sub CARGAR_ORDEN1()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_ORDEN_CUENTA(TIPO_MOV)
        cbo_bi.DataSource = DT
        cbo_bi.DisplayMember = DT.Columns.Item(0).ToString
        cbo_bi.ValueMember = DT.Columns.Item(1).ToString
        cbo_bi.SelectedIndex = -1
    End Sub

    Sub CARGAR_ORDEN2()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_ORDEN_CUENTA(TIPO_MOV)
        cbo_indicador.DataSource = DT
        cbo_indicador.DisplayMember = DT.Columns.Item(0).ToString
        cbo_indicador.ValueMember = DT.Columns.Item(1).ToString
        cbo_indicador.SelectedIndex = -1
    End Sub

    Private Sub btn_consulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_consulta.Click
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la provision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_bi.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Orden B.I", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_bi.Focus() : Exit Sub
        If cbo_indicador.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Orden Renta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_indicador.Focus() : Exit Sub
        LLENAR_DGW()
    End Sub

    Function HALLAR_ITEM() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (DGW_DETALLE.Rows.Count - 1)
        i = 0
        Do While (i <= cont)
            If (DGW_DETALLE.Item(0, i).Value > mayor) Then
                mayor = (DGW_DETALLE.Item(0, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("00")
    End Function

    Sub LLENAR_DGW()
        If cbo_prov.SelectedIndex = 0 Then
            TIPO_MOV = "C"
        ElseIf cbo_prov.SelectedIndex = 1 Then
            TIPO_MOV = "H"
        Else
            TIPO_MOV = ""
        End If
        '-----------------------------------------------------------------------------------------
        DGW_DETALLE.Rows.Clear()

        W1 = cbo_bi.SelectedValue.ToString
        W2 = cbo_indicador.SelectedValue.ToString
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_CAB_CERTIFICADO_4TA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO_MOV
            PROG_01.Parameters.Add("@ORDEN_BI", SqlDbType.Char).Value = W1
            PROG_01.Parameters.Add("@ORDEN_RENTA", SqlDbType.Char).Value = W2
            con.Open()
            '-----------------------------
            '-------para el tiempo de espera caducado
            PROG_01.CommandTimeout = 5000
            '-----------------------------
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW_DETALLE.Rows.Add(HALLAR_ITEM, Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        '-----------------------------------------------------------------------------------------
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer = DGW_DETALLE.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_consulta.Select()
            Return
        End Try
        Dim DIR_PER, SERVICIO_PRES As String
        DIR_PER = obj.HALLAR_DIRECCION_PERSONA(DGW_DETALLE.Item(1, DGW_DETALLE.CurrentRow.Index).Value.ToString)
        SERVICIO_PRES = obj.HALLAR_SERVICIO_PRESTADO(DGW_DETALLE.Item(1, DGW_DETALLE.CurrentRow.Index).Value.ToString)

        REP.DT_CONFIG.DataTable1.Rows.Clear()
        With dgvDetalleRenta
            For idx As Integer = 0 To .Rows.Count - 1
                REP.LlenarDT(.Item(0, idx).Value, .Item(1, idx).Value, .Item(2, idx).Value, .Item(3, idx).Value, .Item(4, idx).Value, .Item(5, idx).Value)
            Next
        End With
        REP.CREAR_REPORTE(cbo_año.Text, obj.COD_MES(cbo_mes.Text), DGW_DETALLE.Item(1, DGW_DETALLE.CurrentRow.Index).Value.ToString, W1, W2, TIPO_MOV, dtp_emision.Value.Date, txt_funcionario.Text, txt_cargo.Text, txt_dni.Text, DIR_PER, SERVICIO_PRES, DGW_DETALLE.Item(2, DGW_DETALLE.CurrentRow.Index).Value.ToString, DGW_DETALLE.Item(3, DGW_DETALLE.CurrentRow.Index).Value.ToString, DGW_DETALLE.Item(4, DGW_DETALLE.CurrentRow.Index).Value.ToString, DGW_DETALLE.Item(5, DGW_DETALLE.CurrentRow.Index).Value.ToString, DGW_DETALLE.Item(6, DGW_DETALLE.CurrentRow.Index).Value.ToString, cRet, sRet)
        REP.ShowDialog()
    End Sub

    Private Sub CargarDetalles(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGW_DETALLE.CellEnter
        Try
            Dim i As Integer = DGW_DETALLE.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (DGW_DETALLE.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            Detalles()

            'For idx As Integer = 0 To DGW_DETALLE.Rows.Count - 1
            '    DGW_DETALLE.Item(5, idx).Value = 0
            'Next
            Total()
        End If
    End Sub

    Sub Detalles()
        dgvDetalleRenta.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_DET_CERTIFICADO_4TA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = DGW_DETALLE.Item(1, DGW_DETALLE.CurrentRow.Index).Value.ToString
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO_MOV
            PROG_01.Parameters.Add("@ORDEN_BI", SqlDbType.Char).Value = W1
            PROG_01.Parameters.Add("@ORDEN_RENTA", SqlDbType.Char).Value = W2
            con.Open()
            '-----------------------------
            '-------para el tiempo de espera caducado
            PROG_01.CommandTimeout = 5000
            '-----------------------------
            'PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgvDetalleRenta.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), _
                Rs3.GetValue(3), IIf(Rs3.GetValue(5) = 0, 0, Rs3.GetValue(4)), Rs3.GetValue(5), _
                IIf(Rs3.GetValue(5) > 0, 1, 0), Rs3.GetValue(4))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Seleccionar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalleRenta.CurrentCellDirtyStateChanged
        If dgvDetalleRenta.IsCurrentCellDirty Then
            dgvDetalleRenta.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
        With dgvDetalleRenta
            If .Item(6, .CurrentRow.Index).Value Then
                .Item(4, .CurrentRow.Index).Value = .Item(7, .CurrentRow.Index).Value
            Else
                .Item(4, .CurrentRow.Index).Value = 0
            End If
            .Item(5, .CurrentRow.Index).Value = Math.Round(.Item(3, _
                .CurrentRow.Index).Value * (.Item(4, .CurrentRow.Index).Value / 100), 2)
            Total()
        End With
    End Sub

    Sub Total()
        Dim total As Decimal = 0
        cRet = 0
        sRet = 0
        For idx As Integer = 0 To dgvDetalleRenta.Rows.Count - 1
            total += dgvDetalleRenta.Item(5, idx).Value

            If dgvDetalleRenta.Item(6, idx).Value Then
                cRet += dgvDetalleRenta.Item(3, idx).Value
            Else
                sRet += dgvDetalleRenta.Item(3, idx).Value
            End If

        Next
        DGW_DETALLE.Item(5, DGW_DETALLE.CurrentRow.Index).Value = total
    End Sub
End Class