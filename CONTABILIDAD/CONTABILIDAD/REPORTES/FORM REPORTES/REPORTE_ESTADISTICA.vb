Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_ESTADISTICA
    Dim MES0, DESC_MES0, mes2, NIVEL As String
    Private OBJ As New Class1
    Private OFR As New REP_ESTADISTICA
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private bwExportar2 As New BackgroundWorker
    Private Exito As Boolean

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (cbo_nivel.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_nivel.Focus()
        ElseIf txt_cod_cta0.Text > txt_cod_cta1.Text Then
            MessageBox.Show("Debe ingresar una cuenta mayor a la ingresada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta1.Focus()
        ElseIf (txt_cod_cta0.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
        ElseIf (txt_cod_cta1.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta1.Focus()
        Else
            OFR.TIPOK = "01"
            OFR.UBICAR_REPORTE()
            NIVEL = OBJ.COD_NIVEL(cbo_nivel.Text)
            MES0 = OBJ.COD_MES(cbo_mes.Text)
            CARGAR_DATASET()
            OFR.CREAR_REPORTE(cbo_mes.Text, OBJ.COD_NIVEL(cbo_nivel.Text))
            OFR.ShowDialog()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, Button4.Click
        main(63) = 0
        Close()
    End Sub

    Sub CARGAR_CUENTA()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTA_NIVEL2", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("CUENTA")
            ADAP.Fill(DT)
            dgw_cta.DataSource = DT
            dgw_cta1.DataSource = DT
            dgw_cta.Columns.Item(0).Width = 50
            dgw_cta1.Columns.Item(0).Width = 50
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            '---------------------------------------------------------------------------------------
            dgw_cta2.DataSource = DT
            dgw_cta12.DataSource = DT
            dgw_cta2.Columns.Item(0).Width = 50
            dgw_cta12.Columns.Item(0).Width = 50
            dgw_cta2.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw_cta12.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGAR_DATASET()
        OFR.DT_ESTADISTICA.DataTable1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_ESTADISTICA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_CUENTA1", SqlDbType.VarChar).Value = txt_cod_cta0.Text
            PROG_01.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = txt_cod_cta1.Text
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@NIVEL", SqlDbType.Char).Value = NIVEL
            PROG_01.Parameters.Add("@DIGITOS_CUENTA", SqlDbType.Int).Value = txt_digitos.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Dim SUM As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = MES0
                Select Case CONT0
                    Case "00"
                        If (Rs3.GetValue(6) <> "0.00") Then
                            SUM = Decimal.Parse(Rs3.GetValue(6))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "01"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "02"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add(Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "03"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "04"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add(Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "05"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "06"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "07"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "08"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "09"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "10"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "11"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "12"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), (Rs3.GetValue(18)), "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "13"
                        If (Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7) <> 0 Or Rs3.GetValue(8) <> 0 Or Rs3.GetValue(9) <> 0 Or Rs3.GetValue(10) <> 0 Or Rs3.GetValue(11) <> 0 Or Rs3.GetValue(12) <> 0 Or Rs3.GetValue(13) <> 0 Or Rs3.GetValue(14) <> 0 Or Rs3.GetValue(15) <> 0 Or Rs3.GetValue(16) <> 0 Or Rs3.GetValue(17) <> 0 Or Rs3.GetValue(18) <> 0 Or Rs3.GetValue(19) <> 0) Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), (Rs3.GetValue(11)), (Rs3.GetValue(12)), (Rs3.GetValue(13)), (Rs3.GetValue(14)), (Rs3.GetValue(15)), (Rs3.GetValue(16)), (Rs3.GetValue(17)), (Rs3.GetValue(18)), Rs3.GetValue(19), (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                End Select
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub CARGAR_NIVEL()
        Try
            Dim PROG_01 As New SqlCommand("CBO_NIVEL", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_nivel.Items.Add(Rs3.GetString(0))
                cbo_nivel2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cbo_nivel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_nivel.SelectedIndexChanged
        If (cbo_nivel.SelectedIndex <> -1) Then
            NIVEL = OBJ.COD_NIVEL(cbo_nivel.Text)
            txt_digitos.Text = OBJ.HALLAR_NRO_DIGITOS(NIVEL)
            txt_cod_cta0.MaxLength = Integer.Parse(txt_digitos.Text)
            txt_cod_cta1.MaxLength = Integer.Parse(txt_digitos.Text)
        End If
    End Sub

    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            Dim cta00 As String = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            PaneL_CTA.Visible = False
            KL.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

    Private Sub dgw_cta1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta1.KeyDown
        If (e.KeyData = Keys.Return) Then
            Dim cta00 As String = (dgw_cta1.Item(0, dgw_cta1.CurrentRow.Index).Value)
            txt_cod_cta1.Text = (dgw_cta1.Item(0, dgw_cta1.CurrentRow.Index).Value)
            txt_desc_cta1.Text = (dgw_cta1.Item(1, dgw_cta1.CurrentRow.Index).Value)
            PaneL_CTA1.Visible = False
            TextBox1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta1.Clear()
            txt_desc_cta1.Clear()
            PaneL_CTA1.Visible = False
            txt_cod_cta1.Focus()
        End If
    End Sub

    Private Sub REPORTE_ESTADISTICA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_ESTADISTICA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CARGAR_NIVEL()
        CARGAR_CUENTA()
        cbo_nivel.Text = OBJ.DESC_NIVEL_DIGITOS(txt_digitos.Text.Length)
        cbo_nivel.Focus()

        cbo_nivel2.Text = OBJ.DESC_NIVEL_DIGITOS(txt_digitos2.Text.Length)
        cbo_nivel2.Focus()
    End Sub

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        Dim cta00 As String = dgw_cta.Item(0, i).Value.ToString
                        txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                        txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        txt_cod_cta1.Focus()
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod_cta1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta1.LostFocus
        If (Strings.Trim(txt_cod_cta1.Text) <> "") Then
            If (dgw_cta1.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta1.Sort(dgw_cta1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta1.Text.ToLower = dgw_cta1.Item(0, i).Value.ToString.ToLower) Then
                        Dim cta00 As String = dgw_cta1.Item(0, i).Value.ToString
                        txt_cod_cta1.Text = dgw_cta1.Item(0, i).Value.ToString
                        txt_desc_cta1.Text = dgw_cta1.Item(1, i).Value.ToString
                        cbo_mes.Focus()
                        Return
                    End If
                    If (txt_cod_cta1.Text.ToLower = Strings.Mid((dgw_cta1.Item(0, i).Value), 1, Strings.Len(txt_cod_cta1.Text)).ToLower) Then
                        dgw_cta1.CurrentCell = dgw_cta1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta1.CurrentCell = dgw_cta1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA1.Visible = True
                dgw_cta1.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
            End If
        End If
    End Sub

    Private Sub txt_desc_cta1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta1.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta1.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta1.Sort(dgw_cta1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta1.Text.ToLower = Strings.Mid((dgw_cta1.Item(1, i).Value), 1, Strings.Len(txt_desc_cta1.Text)).ToLower) Then
                        dgw_cta1.CurrentCell = dgw_cta1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta1.CurrentCell = dgw_cta1.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA1.Visible = True
            End If
        End If
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (cbo_nivel.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_nivel.Focus()
        ElseIf txt_cod_cta0.Text > txt_cod_cta1.Text Then
            MessageBox.Show("Debe ingresar una cuenta mayor a la ingresada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta1.Focus()
        ElseIf (txt_cod_cta0.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
        ElseIf (txt_cod_cta1.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta1.Focus()
        Else
            If Not bwExportar.IsBusy Then
                Dim fbd As New FolderBrowserDialog
                If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    rutaExcel = fbd.SelectedPath
                    tslblMensaje.Text = "Generando Archivo"
                    stEstado.Visible = True
                    MES0 = (OBJ.COD_MES(cbo_mes.Text))
                    DESC_MES0 = cbo_mes.Text
                    bwExportar.RunWorkerAsync()
                End If
                'NIVEL = OBJ.COD_NIVEL(cbo_nivel.Text)
                'MES0 = (OBJ.COD_MES(cbo_mes.Text))
                'CARGAR_DATASET()
                'OFR.CREAR_REPORTE(cbo_mes.Text, OBJ.COD_NIVEL(cbo_nivel.Text))
                'OFR.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ExportarWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet
        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"

            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA
            oHoja.Range("A3:B3").Merge()
            oHoja.Range("A3:B3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("NIVEL: {0}", NIVEL)

            oHoja.Range("C2:L2").Merge()
            oHoja.Range("C2:L2").Font.Bold = True
            oHoja.Cells(2, 3) = "ESTADISTICAS DE CUENTAS"


            oHoja.Range("C3:L3").Merge()
            oHoja.Range("C3:L3").Font.Bold = True
            oHoja.Cells(3, 3) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:Q5"

            oHoja.Cells(5, 1) = "Cod. Cta." : oHoja.Cells(5, 2) = "Desc. Cuenta"
            oHoja.Cells(5, 3) = "Inicial" : oHoja.Cells(5, 4) = "Enero" : oHoja.Cells(5, 5) = "Febrero"
            oHoja.Cells(5, 6) = "Marzo" : oHoja.Cells(5, 7) = "Abril"
            oHoja.Cells(5, 8) = "Mayo" : oHoja.Cells(5, 9) = "Junio" : oHoja.Cells(5, 10) = "Julio"
            oHoja.Cells(5, 11) = "Agosto" : oHoja.Cells(5, 12) = "Setiembre"
            oHoja.Cells(5, 13) = "Octubre" : oHoja.Cells(5, 14) = "Noviembre"
            oHoja.Cells(5, 15) = "Diciembre" : oHoja.Cells(5, 16) = "Cierre"
            oHoja.Cells(5, 17) = "Total"


            oHoja.Range("A:B").NumberFormat = "@"
            oHoja.Range("C:Q").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 6
            Dim stCon As Integer
            archivoExcel = "ReporteEstadistica"

            Dim Cmd As New SqlCommand("REPORTE_ESTADISTICA", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_CUENTA1", SqlDbType.VarChar).Value = txt_cod_cta0.Text
            Cmd.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = txt_cod_cta1.Text
            Cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = NIVEL
            Cmd.Parameters.Add("@DIGITOS_CUENTA", SqlDbType.Int).Value = txt_digitos.Text
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            Dim SUM As New Decimal
            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                Select Case MES0
                    Case "00"
                        If (Rs3.GetValue(6) <> "0.00") Then
                            SUM = Decimal.Parse(Rs3.GetValue(6))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "01"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "02"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "03"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "04"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "05"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "06"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "07"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "08"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "09"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "10"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "11"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(17)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "12"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" OrElse Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(17)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(18)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "13"
                        If (Rs3.GetValue(6) <> 0 OrElse Rs3.GetValue(7) <> 0 OrElse Rs3.GetValue(8) <> 0 OrElse Rs3.GetValue(9) <> 0 OrElse Rs3.GetValue(10) <> 0 OrElse Rs3.GetValue(11) <> 0 OrElse Rs3.GetValue(12) <> 0 OrElse Rs3.GetValue(13) <> 0 OrElse Rs3.GetValue(14) <> 0 OrElse Rs3.GetValue(15) <> 0 OrElse Rs3.GetValue(16) <> 0 OrElse Rs3.GetValue(17) <> 0 OrElse Rs3.GetValue(18) <> 0 OrElse Rs3.GetValue(19) <> 0) Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(17)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(18)
                            oHoja.Cells(Fila, 16) = Rs3.GetValue(19)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                End Select
                Fila += 1
            Loop
            Rs3.Close()
            con.Close()

            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A6:Q{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A6:Q{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try
    End Sub
    Private Sub ExportarProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        tspbExportar.Value = e.ProgressPercentage
        tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub
    Private Sub ExportarComplete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls ", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tspbExportar.Value = 0
        stEstado.Visible = False
    End Sub

    Private Sub btn_pantalla2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla2.Click
        If (cbo_mes2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes2.Focus()
        ElseIf (cbo_nivel2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_nivel2.Focus()
        ElseIf txt_cod_cta02.Text > txt_cod_cta12.Text Then
            MessageBox.Show("Debe ingresar una cuenta mayor a la ingresada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta12.Focus()
        ElseIf (txt_cod_cta02.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta02.Focus()
        ElseIf (txt_cod_cta12.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta12.Focus()
        Else
            OFR.TIPOK = "02"
            OFR.UBICAR_REPORTE()

            CARGAR_DATASET2()
            OFR.CREAR_REPORTE(cbo_mes2.Text, OBJ.COD_NIVEL(cbo_nivel2.Text))
            OFR.ShowDialog()
        End If
    End Sub
    Private Sub txt_desc_cta12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta12.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta12.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta12.Sort(dgw_cta12.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta12.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta12.Text.ToLower = Strings.Mid((dgw_cta12.Item(1, i).Value), 1, Strings.Len(txt_desc_cta12.Text)).ToLower) Then
                        dgw_cta12.CurrentCell = dgw_cta12.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta12.CurrentCell = dgw_cta12.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA12.Visible = True
            End If
        End If
    End Sub
    Private Sub cbo_nivel2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nivel2.SelectedIndexChanged
        If (cbo_nivel2.SelectedIndex <> -1) Then
            NIVEL = OBJ.COD_NIVEL(cbo_nivel2.Text)
            txt_digitos2.Text = OBJ.HALLAR_NRO_DIGITOS(NIVEL)
            txt_cod_cta02.MaxLength = Integer.Parse(txt_digitos2.Text)
            txt_cod_cta12.MaxLength = Integer.Parse(txt_digitos2.Text)
        End If
    End Sub
    Private Sub dgw_cta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta2.KeyDown
        If (e.KeyData = Keys.Return) Then
            Dim cta00 As String = (dgw_cta2.Item(0, dgw_cta2.CurrentRow.Index).Value)
            txt_cod_cta02.Text = (dgw_cta2.Item(0, dgw_cta2.CurrentRow.Index).Value)
            txt_desc_cta02.Text = (dgw_cta2.Item(1, dgw_cta2.CurrentRow.Index).Value)
            PaneL_CTA2.Visible = False
            KL2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta02.Clear()
            txt_desc_cta02.Clear()
            PaneL_CTA2.Visible = False
            txt_cod_cta02.Focus()
        End If
    End Sub
    Private Sub dgw_cta12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta12.KeyDown
        If (e.KeyData = Keys.Return) Then
            Dim cta00 As String = (dgw_cta12.Item(0, dgw_cta12.CurrentRow.Index).Value)
            txt_cod_cta12.Text = (dgw_cta12.Item(0, dgw_cta12.CurrentRow.Index).Value)
            txt_desc_cta12.Text = (dgw_cta12.Item(1, dgw_cta12.CurrentRow.Index).Value)
            PaneL_CTA12.Visible = False
            TextBox8.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta12.Clear()
            txt_desc_cta12.Clear()
            PaneL_CTA12.Visible = False
            txt_cod_cta12.Focus()
        End If
    End Sub
    Private Sub txt_desc_cta02_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_desc_cta02.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_desc_cta02.Text.ToLower = Strings.Mid((dgw_cta2.Item(1, i).Value), 1, Strings.Len(txt_desc_cta02.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA2.Visible = True
            End If
        End If

    End Sub
    Private Sub txt_cod_cta02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta02.LostFocus
        If (Strings.Trim(txt_cod_cta02.Text) <> "") Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta02.Text.ToLower = dgw_cta2.Item(0, i).Value.ToString.ToLower) Then
                        Dim cta00 As String = dgw_cta2.Item(0, i).Value.ToString
                        txt_cod_cta02.Text = dgw_cta2.Item(0, i).Value.ToString
                        txt_desc_cta02.Text = dgw_cta2.Item(1, i).Value.ToString
                        txt_cod_cta12.Focus()
                        Return
                    End If
                    If (txt_cod_cta02.Text.ToLower = Strings.Mid((dgw_cta2.Item(0, i).Value), 1, Strings.Len(txt_cod_cta02.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA2.Visible = True
                dgw_cta2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_cod_cta12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cod_cta12.LostFocus
        If (Strings.Trim(txt_cod_cta12.Text) <> "") Then
            If (dgw_cta12.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta12.Sort(dgw_cta12.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta12.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_cod_cta12.Text.ToLower = dgw_cta12.Item(0, i).Value.ToString.ToLower) Then
                        Dim cta00 As String = dgw_cta12.Item(0, i).Value.ToString
                        txt_cod_cta12.Text = dgw_cta12.Item(0, i).Value.ToString
                        txt_desc_cta12.Text = dgw_cta12.Item(1, i).Value.ToString
                        cbo_mes2.Focus()
                        Return
                    End If
                    If (txt_cod_cta12.Text.ToLower = Strings.Mid((dgw_cta12.Item(0, i).Value), 1, Strings.Len(txt_cod_cta12.Text)).ToLower) Then
                        dgw_cta12.CurrentCell = dgw_cta12.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta12.CurrentCell = dgw_cta12.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA12.Visible = True
                dgw_cta12.Focus()
            End If
        End If
    End Sub
    Sub CARGAR_DATASET2()

        OFR.DT_ESTADISTICA.DataTable1.Rows.Clear()
        NIVEL = OBJ.COD_NIVEL(cbo_nivel2.Text)
        MES0 = OBJ.COD_MES(cbo_mes2.Text)
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_ESTADISTICA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.CommandTimeout = 720
            PROG_01.Parameters.Add("@COD_CUENTA1", SqlDbType.VarChar).Value = txt_cod_cta02.Text
            PROG_01.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = txt_cod_cta12.Text
            PROG_01.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@NIVEL", SqlDbType.Char).Value = NIVEL
            PROG_01.Parameters.Add("@DIGITOS_CUENTA", SqlDbType.Int).Value = txt_digitos2.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Dim SUM As Decimal = 0
            Do While Rs3.Read
                Dim CONT0 As String = OBJ.COD_MES(cbo_mes2.Text)
                Select Case CONT0
                    Case "00"
                        If (Rs3.GetValue(6) <> "0.00") Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "01"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "02"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add(Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "03"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7), Rs3.GetValue(9) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "04"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add(Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7), Rs3.GetValue(10) + Rs3.GetValue(8) + Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "05"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), (Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6)), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "06"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "07"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), (Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6)), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "08"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "09"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), SUM)
                        End If
                    Case "10"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), 0)
                        End If
                    Case "11"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6)  <> "0.00" Or Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6)  <> "0.00" Or Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6)  <> "0.00" Or Rs3.GetValue(16)+Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(17)+Rs3.GetValue(16)+Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(17) + Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), 0)
                        End If
                    Case "12"
                        If Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(15) +Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6)<> "0.00" Or Rs3.GetValue(16)+Rs3.GetValue(15) +Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(17)+Rs3.GetValue(16)+Rs3.GetValue(15) +Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Or Rs3.GetValue(18)+Rs3.GetValue(17)+Rs3.GetValue(16)+Rs3.GetValue(15) +Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> "0.00" Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(17) + Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(18) + Rs3.GetValue(17) + Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), "0.00", (Rs3.GetValue(0)), Rs3.GetValue(1), 0)
                        End If
                    Case "13"
                        If (Rs3.GetValue(6) <> 0 Or Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6)  <> 0 Or Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(16)+Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(17)+Rs3.GetValue(16)+Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(18)+Rs3.GetValue(17)+Rs3.GetValue(16)+Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6) <> 0 Or Rs3.GetValue(19)+Rs3.GetValue(18)+Rs3.GetValue(17)+Rs3.GetValue(16)+Rs3.GetValue(15)+Rs3.GetValue(14)+Rs3.GetValue(13)+Rs3.GetValue(12)+Rs3.GetValue(11)+Rs3.GetValue(10)+Rs3.GetValue(9)+Rs3.GetValue(8)+Rs3.GetValue(7)+Rs3.GetValue(6)  <> 0) Then
                            OFR.DT_ESTADISTICA.DataTable1.Rows.Add((Rs3.GetValue(2)), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(17) + Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(18) + Rs3.GetValue(17) + Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), Rs3.GetValue(19) + Rs3.GetValue(18) + Rs3.GetValue(17) + Rs3.GetValue(16) + Rs3.GetValue(15) + Rs3.GetValue(14) + Rs3.GetValue(13) + Rs3.GetValue(12) + Rs3.GetValue(11) + Rs3.GetValue(10) + Rs3.GetValue(9) + Rs3.GetValue(8) + Rs3.GetValue(7) + Rs3.GetValue(6), (Rs3.GetValue(0)), Rs3.GetValue(1), 0)
                        End If

                End Select
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_archivo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo2.Click
        If (cbo_mes2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes2.Focus()
        ElseIf (cbo_nivel2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Nivel", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_nivel2.Focus()
        ElseIf txt_cod_cta02.Text > txt_cod_cta12.Text Then
            MessageBox.Show("Debe ingresar una cuenta mayor a la ingresada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta12.Focus()
        ElseIf (txt_cod_cta02.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta02.Focus()
        ElseIf (txt_cod_cta12.Text = "") Then
            MessageBox.Show("Debe elegir la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta12.Focus()
        Else
            mes2 = OBJ.COD_MES(cbo_mes2.Text)
            If Not bwExportar2.IsBusy Then
                Dim fbd As New FolderBrowserDialog
                If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    rutaExcel = fbd.SelectedPath
                    tslblMensaje.Text = "Generando Archivo"
                    stEstado.Visible = True
                    MES0 = (OBJ.COD_MES(cbo_mes2.Text))
                    DESC_MES0 = cbo_mes2.Text
                    bwExportar2.RunWorkerAsync()
                End If
            End If
        End If
    End Sub
    Private Sub ExportarWork2(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet
        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"

            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA
            oHoja.Range("A3:B3").Merge()
            oHoja.Range("A3:B3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("NIVEL: {0}", NIVEL)

            oHoja.Range("C2:L2").Merge()
            oHoja.Range("C2:L2").Font.Bold = True
            oHoja.Cells(2, 3) = "ESTADISTICAS DE CUENTAS ACUMULADAS"


            oHoja.Range("C3:L3").Merge()
            oHoja.Range("C3:L3").Font.Bold = True
            oHoja.Cells(3, 3) = String.Format("PERIODO A: {0} DE {1}", DESC_MES0, AÑO)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:P5"

            oHoja.Cells(5, 1) = "Cod. Cta." : oHoja.Cells(5, 2) = "Desc. Cuenta"
            oHoja.Cells(5, 3) = "Inicial" : oHoja.Cells(5, 4) = "Enero" : oHoja.Cells(5, 5) = "Febrero"
            oHoja.Cells(5, 6) = "Marzo" : oHoja.Cells(5, 7) = "Abril"
            oHoja.Cells(5, 8) = "Mayo" : oHoja.Cells(5, 9) = "Junio" : oHoja.Cells(5, 10) = "Julio"
            oHoja.Cells(5, 11) = "Agosto" : oHoja.Cells(5, 12) = "Setiembre"
            oHoja.Cells(5, 13) = "Octubre" : oHoja.Cells(5, 14) = "Noviembre"
            oHoja.Cells(5, 15) = "Diciembre" : oHoja.Cells(5, 16) = "Cierre"


            oHoja.Range("A:B").NumberFormat = "@"
            oHoja.Range("C:P").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 6
            Dim stCon As Integer
            archivoExcel = "ReporteEstadisticaAcumulada"

            Dim Cmd As New SqlCommand("REPORTE_ESTADISTICA", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_CUENTA1", SqlDbType.VarChar).Value = txt_cod_cta02.Text
            Cmd.Parameters.Add("@COD_CUENTA2", SqlDbType.VarChar).Value = txt_cod_cta12.Text
            Cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            Cmd.Parameters.Add("@NIVEL", SqlDbType.Char).Value = NIVEL
            Cmd.Parameters.Add("@DIGITOS_CUENTA", SqlDbType.Int).Value = txt_digitos2.Text
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            Dim SUM As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = mes2
                oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                Select Case CONT0
                    Case "00"
                        If (Rs3.GetValue(6) <> "0.00") Then
                            'SUM = Decimal.Parse(Rs3.GetValue(6))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "01"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "02"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "03"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "04"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "05"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "06"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "07"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "08"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "09"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "10"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "11"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16) + Rs3.GetValue(17)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "12"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" OrElse Rs3.GetValue(18) <> "0.00" Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16) + Rs3.GetValue(17)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16) + Rs3.GetValue(17) + Rs3.GetValue(18)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "13"
                        If (Rs3.GetValue(6) <> 0 OrElse Rs3.GetValue(7) <> 0 OrElse Rs3.GetValue(8) <> 0 OrElse Rs3.GetValue(9) <> 0 OrElse Rs3.GetValue(10) <> 0 OrElse Rs3.GetValue(11) <> 0 OrElse Rs3.GetValue(12) <> 0 OrElse Rs3.GetValue(13) <> 0 OrElse Rs3.GetValue(14) <> 0 OrElse Rs3.GetValue(15) <> 0 OrElse Rs3.GetValue(16) <> 0 OrElse Rs3.GetValue(17) <> 0 OrElse Rs3.GetValue(18) <> 0 OrElse Rs3.GetValue(19) <> 0) Then
                            'SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(6) + Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16) + Rs3.GetValue(17)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16) + Rs3.GetValue(17) + Rs3.GetValue(18)
                            oHoja.Cells(Fila, 16) = Rs3.GetValue(6) + Rs3.GetValue(7) + Rs3.GetValue(8) + Rs3.GetValue(9) + Rs3.GetValue(10) + Rs3.GetValue(11) + Rs3.GetValue(12) + Rs3.GetValue(13) + Rs3.GetValue(14) + Rs3.GetValue(15) + Rs3.GetValue(16) + Rs3.GetValue(17) + Rs3.GetValue(18) + Rs3.GetValue(19)
                            'oHoja.Cells(Fila, 17) = SUM
                        End If
                End Select
                Fila += 1
            Loop
            Rs3.Close()
            con.Close()

            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A6:P{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A6:P{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try
    End Sub
End Class