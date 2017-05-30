Imports System.Data.SqlClient
Public Class REPORTE_ESTADISTICA_GASTO
    Private OBJ As New Class1
    Private OFR As New REP_ESTADISTICA_GASTO
    Dim MES0, AÑO0, ST_AREA As String
    Private Sub CARGAR_CENTRO_COSTOS()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_AREA2", con)
            pro_02.CommandType = CommandType.StoredProcedure
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Origen")
            Prog02.Fill(dt_02)
            dgwArea.DataSource = dt_02
            dgwArea.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Sub CARGAR_DATASET()
        OFR.DT_ESTADISTICA.ESTADISTICA_GASTO.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_ESTADISTICA_GASTO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("ST_AREA", SqlDbType.VarChar).Value = ST_AREA
            PROG_01.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = txtCodArea.Text
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO0
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Dim SUM As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = MES0
                With OFR.DT_ESTADISTICA.ESTADISTICA_GASTO.Rows
                    Select Case CONT0
                        Case "01"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", _
                                "0.00", SUM)
                            End If
                        Case "02"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", _
                                "0.00", "0.00", SUM)
                            End If
                        Case "03"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), _
                                    Rs3.GetValue(8)), Rs3.GetValue(9)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", _
                                "0.00", "0.00", "0.00", SUM)
                            End If
                        Case "04"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), _
                                    Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), "0.00", "0.00", "0.00", _
                                "0.00", "0.00", "0.00", "0.00", SUM)
                            End If
                        Case "05"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), _
                                    Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", SUM)
                            End If
                        Case "06"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), _
                                Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                (Rs3.GetValue(12)), "0.00", "0.00", "0.00", "0.00", "0.00", SUM)
                            End If
                        Case "07"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add( _
                                Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), _
                                Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                (Rs3.GetValue(12)), (Rs3.GetValue(13)), "0.00", "0.00", "0.00", "0.00", SUM)
                            End If
                        Case "08"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add( _
                                Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), _
                                Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), "0.00", "0.00", "0.00", SUM)
                            End If
                        Case "09"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" _
                                OrElse Rs3.GetValue(15) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add( _
                                Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), _
                                Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), _
                                Rs3.GetValue(14)), Rs3.GetValue(15)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), _
                                (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), "0.00", "0.00", SUM)
                            End If
                        Case "10"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" _
                                OrElse Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add( _
                                Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), _
                                Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), _
                                Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), "0.00", SUM)
                            End If
                        Case "11"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" _
                                OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add( _
                                Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), _
                                Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), _
                                Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), SUM)
                            End If
                        Case "12"
                            If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" _
                                OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" _
                                OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" _
                                OrElse Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" Then

                                SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add( _
                                Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), _
                                Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), _
                                Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), _
                                Rs3.GetValue(17)))

                                .Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), _
                                Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), _
                                (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), SUM)
                            End If
                    End Select
                End With
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(155) = 0
        Close()
    End Sub

    Private Sub REPORTE_ESTADISTICA_GASTO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_ESTADISTICA_GASTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_CENTRO_COSTOS()
        CARGAR_AÑO()
    End Sub

    Private Sub txtCodArea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodArea.LostFocus
        If (Strings.Trim(txtCodArea.Text) <> "") Then
            If (dgwArea.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgwArea.Sort(dgwArea.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgwArea.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtCodArea.Text.ToLower = dgwArea.Item(0, i).Value.ToString.ToLower) Then
                        txtCodArea.Text = dgwArea.Item(0, i).Value.ToString
                        txtArea.Text = dgwArea.Item(1, i).Value.ToString
                        cbo_año.Focus()
                        Return
                    End If
                    If (txtCodArea.Text.ToLower = Strings.Mid((dgwArea.Item(0, i).Value), 1, Strings.Len(txtCodArea.Text)).ToLower) Then
                        dgwArea.CurrentCell = dgwArea.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgwArea.CurrentCell = dgwArea.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PanelArea.Visible = True
                dgwArea.Focus()
            End If
        End If
    End Sub

    Private Sub txtArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArea.KeyDown
        If ((Strings.Trim(txtArea.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgwArea.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgwArea.Sort(dgwArea.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgwArea.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtArea.Text.ToLower = Strings.Mid((dgwArea.Item(1, i).Value), 1, Strings.Len(txtArea.Text)).ToLower) Then
                        dgwArea.CurrentCell = dgwArea.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgwArea.CurrentCell = dgwArea.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PanelArea.Visible = True
                dgwArea.Focus()
            End If
        End If
    End Sub

    Private Sub dgwArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgwArea.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodArea.Text = (dgwArea.Item(0, dgwArea.CurrentRow.Index).Value)
            txtArea.Text = (dgwArea.Item(1, dgwArea.CurrentRow.Index).Value)
            PanelArea.Visible = False
            txtArea.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodArea.Clear()
            txtArea.Clear()
            PanelArea.Visible = False
            txtCodArea.Focus()
        End If
    End Sub

    Private Sub chkCentroCostos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCentroCostos.CheckedChanged
        txtCodArea.Enabled = chkCentroCostos.Checked
        txtArea.Enabled = chkCentroCostos.Checked
        txtCodArea.Clear()
        txtArea.Clear()
    End Sub

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (chkCentroCostos.Checked AndAlso txtCodArea.Text = "") Then
            MessageBox.Show("Debe elegir el centro de costos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodArea.Focus()
        Else
            'OFR.TIPOK = "01"
            'OFR.UBICAR_REPORTE()
            'NIVEL = OBJ.COD_NIVEL(cbo_nivel.Text)
            ST_AREA = "1"
            If chkCentroCostos.Checked Then
                ST_AREA = "0"
            End If
            AÑO0 = cbo_año.Text
            MES0 = OBJ.COD_MES(cbo_mes.Text)
            CARGAR_DATASET()
            OFR.CREAR_REPORTE(cbo_mes.Text, AÑO0)
            OFR.ShowDialog()
        End If
    End Sub
End Class