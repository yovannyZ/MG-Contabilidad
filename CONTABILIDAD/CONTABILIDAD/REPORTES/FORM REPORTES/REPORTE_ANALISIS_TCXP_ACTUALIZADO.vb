Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_ANALISIS_TCXP_ACTUALIZADO
    Private MES0, HOJA As String
    Private obj As New Class1
    'Private REP1 As New REP_CONCILIADO
    Private REP2 As New REP_PENDIENTE_ACTUALIZADO
    Private SALDOS_IMPORTE As Decimal
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_hoja.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Tipo de Hoja a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_hoja.Focus() : Exit Sub
        If CH_PER.Checked And txt_cod_per.Text = "" Then MessageBox.Show("Debe insertar el código de persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        Dim COD_PER, VISIBLE As String
        Dim STATUS_PER As String
        If CH_PER.Checked = False Then
            STATUS_PER = "1"
            COD_PER = " "
            VISIBLE = "1"
        Else
            STATUS_PER = "0"
            COD_PER = txt_cod_per.Text
            VISIBLE = "0"
        End If
        MES0 = obj.COD_MES(cbo_mes.Text)
        Dim FECHA_CONC As DateTime
        If MES0 <> "00" Then
            FECHA_CONC = DateTime.Parse(("01/" & MES0 & "/" & cbo_año.Text))
        End If
        Dim CONT0 As String = MES0
        If ((((CONT0 = "01") Or (CONT0 = "03")) Or (CONT0 = "05")) Or (((CONT0 = "07") Or (CONT0 = "08")) Or (CONT0 = "10"))) Then
        End If
        If CONT0 = "12" Then
            FECHA_CONC = DateTime.Parse(("31/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
        Else
            If (((CONT0 = "04") OrElse (CONT0 = "06")) OrElse (CONT0 = "09")) Then
            End If
            If CONT0 = "11" Then
                FECHA_CONC = DateTime.Parse(("30/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
            ElseIf (CONT0 = "02") Then
                If ((Integer.Parse(cbo_año.Text) Mod 4) = 0) Then
                    FECHA_CONC = DateTime.Parse(("29/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                Else
                    FECHA_CONC = DateTime.Parse(("28/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                End If
            End If
        End If
        If MES0 = "00" Then
            FECHA_CONC = DateTime.Parse(("12/12/" & (cbo_año.Text - 1)))
        End If
        SALDOS()
        '-----------------------------------
        Select Case cbo_hoja.SelectedIndex
            Case "0"
                HOJA = "01"
            Case "1"
                HOJA = "02"
        End Select
        'If ch_p.Checked = False Then
        '    '------------------------
        '    REP1.HOJA = HOJA
        '    REP1.UBICAR_REPORTE()
        '    '------------------------
        '    REP1.CREAR_REPORTE(cbo_mes.Text, txt_desc_cta0.Text, txt_cod_cta0.Text, cbo_año.Text, MES0, "1", COD_PER, STATUS_PER, FECHA_CONC)
        '    REP1.ShowDialog()
        'Else
        '------------------------
        REP2.HOJA = HOJA
        REP2.UBICAR_REPORTE()
        '------------------------
        REP2.LimpiarDt()
        'CargarDatos()
        Dim ds As New DataSet
        Try
            Dim cmd As New SqlCommand("REPORTE_CONCILIADAS_ACTUALIZADA", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
            cmd.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char).Value = "0"
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            cmd.Parameters.Add("@S_PER", SqlDbType.Char).Value = STATUS_PER
            cmd.Parameters.Add("@FECHA_CONC", SqlDbType.DateTime).Value = FECHA_CONC
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim dr, drs, dra As DataRow
        'Logica a tratar
        Dim filas As Integer = ds.Tables(0).Rows.Count - 1
        'Si el documento actual es igual al que viene se agrega si no se inserta
        Dim i As Integer = 0
        Dim DocActual, DocSiguiente, CodActual, CodSiguiente, DebeHaber As String
        Dim DebeSoles, HaberSoles, DebeDolares, HaberDolares, ImporteSoles, ImporteDolares As Decimal
        DebeHaber = String.Empty : DocSiguiente = String.Empty
        While i <= filas
            dr = ds.Tables(0).Rows(i)
            CodActual = dr(8)
            DocActual = dr(7)
            If i = filas Then
                drs = ds.Tables(0).Rows(i)
            Else
                drs = ds.Tables(0).Rows(i + 1)
            End If
            CodSiguiente = drs(8)
            DocSiguiente = drs(7)
            If (DocActual = DocSiguiente And CodActual = CodSiguiente) Then
                'acumulamos
                If (dr(11) = "D") Then
                    DebeSoles += CDec(dr(12))
                    DebeDolares += CDec(dr(13))
                Else
                    HaberSoles += CDec(dr(12))
                    HaberDolares += CDec(dr(13))
                End If

                If i = filas Then
                    If DebeSoles > HaberSoles Then
                        DebeHaber = "D"
                        ImporteSoles = DebeSoles - HaberSoles
                        ImporteDolares = DebeDolares - HaberSoles
                    Else
                        DebeHaber = "H"
                        ImporteSoles = HaberSoles - DebeSoles
                        ImporteDolares = HaberDolares - DebeDolares
                    End If
                    REP2.LlenarDt(dr(0), dr(1), CDate(dr(2)), dr(3), dr(4), dr(5), CDate(dr(6)), dr(7), dr(8), dr(9), dr(10), DebeHaber, ImporteSoles, ImporteDolares, dr(14), dr(15), CDec(dr(16)), dr(17), CDate(dr(18)), dr(19))
                End If
            Else
                'insertamos       
                'Preguntamos si el actual es igual al anterior
                If i <> 0 Then
                    dra = ds.Tables(0).Rows(i - 1)
                    If CodActual = dra(8) And DocActual = dra(7) Then
                        If (dr(11) = "D") Then
                            DebeSoles += CDec(dr(12))
                            DebeDolares += CDec(dr(13))
                        Else
                            HaberSoles += CDec(dr(12))
                            HaberDolares += CDec(dr(13))
                        End If

                        If DebeSoles > HaberSoles Then
                            DebeHaber = "D"
                            ImporteSoles = DebeSoles - HaberSoles
                            ImporteDolares = DebeDolares - HaberDolares
                        Else
                            DebeHaber = "H"
                            ImporteSoles = HaberSoles - DebeSoles
                            ImporteDolares = HaberDolares - DebeDolares
                        End If
                        REP2.LlenarDt(dr(0), dr(1), CDate(dr(2)), dr(3), dr(4), dr(5), CDate(dr(6)), dr(7), dr(8), dr(9), dr(10), DebeHaber, ImporteSoles, ImporteDolares, dr(14), dr(15), CDec(dr(16)), dr(17), CDate(dr(18)), dr(19))
                    Else
                        REP2.LlenarDt(dr(0), dr(1), CDate(dr(2)), dr(3), dr(4), dr(5), CDate(dr(6)), dr(7), dr(8), dr(9), dr(10), dr(11), CDec(dr(12)), CDec(dr(13)), dr(14), dr(15), CDec(dr(16)), dr(17), CDate(dr(18)), dr(19))
                    End If
                Else
                    REP2.LlenarDt(dr(0), dr(1), CDate(dr(2)), dr(3), dr(4), dr(5), CDate(dr(6)), dr(7), dr(8), dr(9), dr(10), dr(11), CDec(dr(12)), CDec(dr(13)), dr(14), dr(15), CDec(dr(16)), dr(17), CDate(dr(18)), dr(19))
                End If
                DebeSoles = 0 : HaberSoles = 0 : DebeDolares = 0 : HaberDolares = 0
            End If
            i += 1
        End While
        '------------------------------
        REP2.CREAR_REPORTE(cbo_mes.Text, txt_desc_cta0.Text, txt_cod_cta0.Text, cbo_año.Text, MES0, "0", COD_PER, STATUS_PER, SALDOS_IMPORTE, FECHA_CONC, VISIBLE)
        REP2.ShowDialog()
        'End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        'main(97) = 0
        Close()
    End Sub
    Private Sub CH_PER_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_PER.CheckedChanged
        If CH_PER.Checked Then
            txt_cod_per.Enabled = True
            txt_desc_per.Enabled = True
            txt_doc_per.Enabled = True
        Else
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per.Enabled = False
            txt_desc_per.Enabled = False
            txt_doc_per.Enabled = False
        End If
    End Sub
    Sub CUENTAS()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "P")
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(4).Visible = False
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value).Length <> 8) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta0.Clear()
                txt_desc_cta0.Clear()
            Else
                txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                PaneL_CTA.Visible = False
                KL.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per.Text = (dgw_per.Item(0, dgw_per.CurrentRow.Index).Value)
            txt_desc_per.Text = (dgw_per.Item(1, dgw_per.CurrentRow.Index).Value)
            txt_doc_per.Text = (dgw_per.Item(2, dgw_per.CurrentRow.Index).Value)
            Panel_per.Visible = False
            TextBox1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            Panel_per.Visible = False
            txt_cod_per.Focus()
        End If
    End Sub

    Public Sub PERSONAS()
        Try
            dgw_per.DataSource = obj.MOSTRAR_PERSONAS_PAGAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception


            MsgBox(ex.Message)
            MessageBox.Show("Ocurrió un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub
    Private Sub REPORTE_ANALISIS_TCXP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_ANALISIS_TCXP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        KeyPreview = True
        CUENTAS()
        PERSONAS()
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Text = obj.DESC_MES(MES)
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SALDOS()
        Try
            Dim cmd As New SqlCommand("HALLAR_MAESTRO_SALDOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES0
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                SALDOS_IMPORTE = Decimal.Parse(dr.GetValue(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        If (dgw_cta.Item(0, i).Value.ToString.Length <> 8) Then
                            MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_cta0.Clear()
                            txt_desc_cta0.Clear()
                            txt_cod_cta0.Focus()
                        Else
                            txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                            txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        End If
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

    Private Sub txt_cod_per_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per.LostFocus
        If (Strings.Trim(txt_cod_per.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        Return
                    End If
                    If (txt_cod_per.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
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

    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla pendientes por cobrar", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub

    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub

    Private Sub ExportarWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True
        Dim COD_PER As String
        'Dim VISIBLE As String
        Dim STATUS_PER As String
        If CH_PER.Checked = False Then
            STATUS_PER = "1"
            COD_PER = " "
            'VISIBLE = "1"
        Else
            STATUS_PER = "0"
            COD_PER = txt_cod_per.Text
            'VISIBLE = "0"
        End If
        MES0 = obj.COD_MES(cbo_mes.Text)
        Dim FECHA_CONC As DateTime
        If MES0 <> "00" Then
            FECHA_CONC = DateTime.Parse(("01/" & MES0 & "/" & cbo_año.Text))
        End If
        Dim CONT0 As String = MES0
        If ((((CONT0 = "01") Or (CONT0 = "03")) Or (CONT0 = "05")) Or (((CONT0 = "07") Or (CONT0 = "08")) Or (CONT0 = "10"))) Then
        End If
        If CONT0 = "12" Then
            FECHA_CONC = DateTime.Parse(("31/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
        Else
            If (((CONT0 = "04") OrElse (CONT0 = "06")) OrElse (CONT0 = "09")) Then
            End If
            If CONT0 = "11" Then
                FECHA_CONC = DateTime.Parse(("30/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
            ElseIf (CONT0 = "02") Then
                If ((Integer.Parse(cbo_año.Text) Mod 4) = 0) Then
                    FECHA_CONC = DateTime.Parse(("29/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                Else
                    FECHA_CONC = DateTime.Parse(("28/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                End If
            End If
        End If
        If MES0 = "00" Then
            FECHA_CONC = DateTime.Parse(("12/12/" & (cbo_año.Text - 1)))
        End If
        'SALDOS()
        '-----------------------------------

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
            oHoja.Range("A3:C3").Merge()
            oHoja.Range("A3:C3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("CUENTA: {0} {1}", txt_cod_cta0.Text, txt_desc_cta0.Text)

            Dim strRango As String = "A5:R6"
            oHoja.Cells(5, 1) = "MONEDA" : oHoja.Cells(5, 2) = "COMPROBANTE"
            oHoja.Cells(6, 2) = "FECHA" : oHoja.Cells(6, 3) = "AUX"
            oHoja.Cells(6, 4) = "COD." : oHoja.Cells(6, 5) = "NUMERO"
            oHoja.Cells(5, 6) = "DOCUMENTO" : oHoja.Cells(6, 6) = "FECHA"
            oHoja.Cells(6, 7) = "NUMERO" : oHoja.Cells(6, 8) = "COD."
            oHoja.Cells(6, 9) = "VCTO." : oHoja.Cells(5, 10) = "CTA. CTE."
            oHoja.Cells(5, 11) = "NOMBRE" : oHoja.Cells(5, 12) = "RUC/DNI"
            oHoja.Cells(5, 13) = "S/.IMPORTE" : oHoja.Cells(6, 13) = "DEBE"
            oHoja.Cells(6, 14) = "HABER" : oHoja.Cells(5, 14) = "$/IMPORTE"
            oHoja.Cells(6, 15) = "DEBE" : oHoja.Cells(6, 16) = "HABER"
            oHoja.Cells(5, 17) = "GLOSA" : oHoja.Cells(5, 18) = "T.C."

            oHoja.Range("B5:E5").Merge() : oHoja.Range("F5:I5").Merge()
            oHoja.Range("M5:N5").Merge() : oHoja.Range("O5:P5").Merge()

            oHoja.Range("A:A,C:E,G:H,J:L,P:P").NumberFormat = "@"
            oHoja.Range("B:B,F:F,I:I").NumberFormat = "dd/mm/yyyy"

            oHoja.Range("M:P").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"
            oHoja.Range("R:R").NumberFormat = "_(* #,##0.0000_);_(* (#,##0.0000);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 7
            Dim stCon As Integer
            If ch_p.Checked Then
                stCon = 0
                archivoExcel = "AnalisisCXPPendientes"
            Else
                stCon = 1
                archivoExcel = "AnalisisCXPConciliadas"
            End If
            Dim cmd As New SqlCommand("REPORTE_CONCILIADAS", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim par1 As SqlParameter = cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char)
            Dim par2 As SqlParameter = cmd.Parameters.Add("@FE_MES", SqlDbType.Char)
            Dim par3 As SqlParameter = cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar)
            Dim par4 As SqlParameter = cmd.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char)
            Dim par5 As SqlParameter = cmd.Parameters.Add("@COD_PER", SqlDbType.Char)
            Dim par6 As SqlParameter = cmd.Parameters.Add("@S_PER", SqlDbType.Char)
            Dim par7 As SqlParameter = cmd.Parameters.Add("@FECHA_CONC", SqlDbType.DateTime)
            par1.Value = AÑO : par2.Value = MES0 : par3.Value = txt_cod_cta0.Text : par4.Value = stCon
            par5.Value = COD_PER : par6.Value = STATUS_PER : par7.Value = FECHA_CONC

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dtrOrden As DataRow

            Dim tReg As Integer = dt.Rows.Count
            Dim fAct As Integer = 0
            For Each dtrOrden In dt.Rows
                oHoja.Cells(Fila, 1) = dtrOrden(1)
                oHoja.Cells(Fila, 2) = dtrOrden(2)
                oHoja.Cells(Fila, 3) = dtrOrden(3)
                oHoja.Cells(Fila, 4) = dtrOrden(4)
                oHoja.Cells(Fila, 5) = dtrOrden(5)
                oHoja.Cells(Fila, 6) = dtrOrden(6)
                oHoja.Cells(Fila, 7) = dtrOrden(7)
                oHoja.Cells(Fila, 8) = dtrOrden(8)
                oHoja.Cells(Fila, 9) = dtrOrden(18)
                oHoja.Cells(Fila, 10) = dtrOrden(9)
                oHoja.Cells(Fila, 11) = dtrOrden(10)
                oHoja.Cells(Fila, 12) = dtrOrden(19)
                oHoja.Cells(Fila, 13) = IIf(dtrOrden(11) = "D", dtrOrden(12), 0)
                oHoja.Cells(Fila, 14) = IIf(dtrOrden(11) = "H", dtrOrden(12), 0)
                oHoja.Cells(Fila, 15) = IIf(dtrOrden(11) = "D", dtrOrden(13), 0)
                oHoja.Cells(Fila, 16) = IIf(dtrOrden(11) = "H", dtrOrden(13), 0)
                oHoja.Cells(Fila, 17) = dtrOrden(14)
                oHoja.Cells(Fila, 18) = dtrOrden(16)
                Fila += 1
                fAct += 1
                bwExportar.ReportProgress((fAct / tReg) * 100)
            Next
            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A7:R{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A7:R{0}", Fila - 1)).Interior.ColorIndex = 2

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

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If CH_PER.Checked And txt_cod_per.Text = "" Then MessageBox.Show("Debe insertar el código de persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_per.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub

        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                bwExportar.RunWorkerAsync()
            End If
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
End Class