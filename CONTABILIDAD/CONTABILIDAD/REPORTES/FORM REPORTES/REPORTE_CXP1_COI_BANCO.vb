Imports System.Data.SqlClient
Public Class REPORTE_CXP1_COI_BANCO
    Dim COD_DOC1, STATUS_SUC1, STATUS_PER1, STATUS_DOC1, COD_SUCURSAL1, COD_PER1, COD_DOC2, COD_CLASE1 As String
    Dim OBJ As New Class1
    Dim ofr1 As New REP_CXP_PTE1_COI
    Dim DIA_FINAL As String
    Dim CADENA_CUENTA As String



    Private Procesando As Boolean
    Private Delegate Sub oExportarExcel(ByVal dgv As DataGridView)
    Private oExportar As New oExportarExcel(AddressOf Exportar)

    Private Sub Exportar(ByVal dgv As DataGridView)
        Dim ofrmExcel As New PARAMETROS_EXCEL
        ofrmExcel.ObtenerColumnas(dgv)
        If ofrmExcel.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim columnas As List(Of String) = ofrmExcel.Columnas
            If columnas.Count > 0 AndAlso dgv.RowCount > 0 Then
                OBJ.ExportarExcel(dgv, columnas)
            End If
        End If
    End Sub

    Private Delegate Sub mostrar(ByVal iar As IAsyncResult)
    Private Sub MostrarResultado(ByVal iar As IAsyncResult)
        Procesando = Not iar.IsCompleted
        If Me.InvokeRequired Then
            Me.Invoke(New mostrar(AddressOf MostrarResultado), iar)
        Else
            tspbExportar.Visible = False
            tslMensaje.Visible = False
        End If
    End Sub

    Private Sub REPORTE_CXP1_COI_BANCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub REPORTE_CXP1_COI_BANCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_PERSONAS()
        CARGAR_SUCURSAL()
        CARGAR_AÑOS()
        CARGAR_DOC_PERMITIDOS()
        documentos()
        ch_si1.Select()
    End Sub
    Sub CARGAR_DOC_PERMITIDOS()
        Try
            Dim cmd As New SqlCommand("FILTRO_REPORTE_DOC", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = "TDOC"
            cmd.Parameters.Add("@TIPO_CTA", SqlDbType.VarChar).Value = "P"
            cmd.Parameters.Add("@TIPO_MOD", SqlDbType.VarChar).Value = "BAN"
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), dr.GetString(2))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_PERSONAS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            dgw_per1.DataSource = DT
            dgw_per1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per1.Columns.Item(0).Width = &H37
            dgw_per1.Columns.Item(1).Width = 240
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_SUCURSAL()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_SUCURSAL
        CBO_SUCURSAL1.DataSource = DT
        CBO_SUCURSAL1.DisplayMember = DT.Columns.Item(0).ToString
        CBO_SUCURSAL1.ValueMember = DT.Columns.Item(1).ToString
        CBO_SUCURSAL1.SelectedIndex = -1
    End Sub
    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub documentos()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_doc1.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_COD1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_COD1.LostFocus
        If (Strings.Trim(TXT_COD1.Text) <> "") Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (TXT_COD1.Text.ToLower = dgw_per1.Item(0, i).Value.ToString.ToLower) Then
                        TXT_COD1.Text = dgw_per1.Item(0, i).Value.ToString
                        TXT_DESC1.Text = dgw_per1.Item(1, i).Value.ToString
                        txt_doc_per1.Text = dgw_per1.Item(2, i).Value.ToString
                        cbo_tipo_doc1.Focus()
                        Return
                    End If
                    If (TXT_COD1.Text.ToLower = Strings.Mid((dgw_per1.Item(0, i).Value), 1, Strings.Len(TXT_COD1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub TXT_DESC1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_DESC1.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(TXT_DESC1.Text) <> "")) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (TXT_DESC1.Text.ToLower = Strings.Mid((dgw_per1.Item(1, i).Value), 1, Strings.Len(TXT_DESC1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub

    Private Sub txt_doc_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_doc_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_per1.RowCount = 0) Then
                MessageBox.Show("No existen PERSONAS X PAGAR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_per1.Sort(dgw_per1.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_per1.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
                    If (txt_doc_per1.Text.ToLower = Strings.Mid((dgw_per1.Item(2, i).Value), 1, Strings.Len(txt_doc_per1.Text)).ToLower) Then
                        dgw_per1.CurrentCell = dgw_per1.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_PER1.Visible = True
                dgw_per1.Visible = True
                dgw_per1.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_per1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_per1.KeyDown
        If (e.KeyData = Keys.Return) Then
            TXT_COD1.Text = dgw_per1.Item(0, dgw_per1.CurrentRow.Index).Value.ToString
            TXT_DESC1.Text = dgw_per1.Item(1, dgw_per1.CurrentRow.Index).Value.ToString
            txt_doc_per1.Text = dgw_per1.Item(2, dgw_per1.CurrentRow.Index).Value.ToString
            Panel_PER1.Visible = False
            k1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_PER1.Visible = False
            TXT_COD1.Focus()
        End If
    End Sub

    Private Sub ch_per1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            TXT_COD1.Enabled = True
            TXT_DESC1.Enabled = True
            txt_doc_per1.Enabled = True
        Else
            TXT_COD1.Clear()
            TXT_DESC1.Clear()
            txt_doc_per1.Clear()
            TXT_COD1.Enabled = False
            TXT_DESC1.Enabled = False
            txt_doc_per1.Enabled = False
        End If
    End Sub

    Private Sub ch_si1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_si1.CheckedChanged
        If ch_si1.Checked Then
            CBO_SUCURSAL1.Enabled = True
        Else
            CBO_SUCURSAL1.SelectedIndex = -1
            CBO_SUCURSAL1.Enabled = False
        End If
    End Sub

    Private Sub CH_DOC1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CH_DOC1.CheckedChanged
        If CH_DOC1.Checked Then
            cbo_tipo_doc1.Enabled = True
        Else
            cbo_tipo_doc1.SelectedIndex = -1
            cbo_tipo_doc1.Enabled = False
        End If
    End Sub
    Sub SUB_CADENA_CUENTA()
        CADENA_CUENTA = ""
        Dim Cant As Integer = dgw1.Rows.Count
        Dim i As Integer = 0
        While i < Cant
            'If dgw1.Item(2, i).Value.ToString Then
            'If String.IsNullOrEmpty(CADENA_CUENTA) Then
            '    CADENA_CUENTA = dgw1.Item(2, i).Value.ToString
            'Else
            CADENA_CUENTA = CADENA_CUENTA & "," & dgw1.Item(2, i).Value.ToString
            'End If
            'End If
            i += 1
        End While
    End Sub

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If ch_si1.Checked And CBO_SUCURSAL1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_SUCURSAL1.Focus() : Exit Sub
        If ch_per1.Checked And Trim(TXT_COD1.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : TXT_COD1.Focus() : Exit Sub
        If CH_DOC1.Checked And cbo_tipo_doc1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc1.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Elija el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Elija el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cbo_mes.Focus() : Exit Sub

        '-----------------------------------------
        If ch_si1.Checked Then
            STATUS_SUC1 = "0"
            COD_SUCURSAL1 = CBO_SUCURSAL1.SelectedValue.ToString
        Else
            STATUS_SUC1 = "1"
            COD_SUCURSAL1 = "  "
        End If
        '-----------------------------------------
        If ch_per1.Checked Then
            STATUS_PER1 = "0"
            COD_PER1 = TXT_COD1.Text
        Else
            STATUS_PER1 = "1"
            COD_PER1 = "  "
        End If
        '------------------------------------------
        Dim TIPO_REPORTE As String
        If CH_DOC1.Checked Then
            TIPO_REPORTE = "1"
            STATUS_DOC1 = "0"
            COD_DOC1 = OBJ.COD_DOC(cbo_tipo_doc1.Text)
        Else
            STATUS_DOC1 = "1"
            COD_DOC1 = "  "
        End If
        '----------------------------------------
        Dim STATUS_CTA, NRO_CTA As String

        STATUS_CTA = "1"
        NRO_CTA = "  "
        '--------------------------------------------------------
        HALLANDO_ULTIMO_DIA()
        Dim fecha00 As Date
        fecha00 = Date.Parse(DIA_FINAL & "/" & OBJ.COD_MES(cbo_mes.Text) & "/" & cbo_año.Text)
        If Format(fecha00, "MM/yyyy") = Format(Now(), "MM/yyyy") Then
            fecha00 = Format(Now(), "dd/MM/yyyy")
        End If
        '--------------------------------------------------------
        SUB_CADENA_CUENTA()

        If CH_DOC1.Checked = False Then
            If dgw1.RowCount = 0 Then
                TIPO_REPORTE = "1"
            Else
                TIPO_REPORTE = "2"
            End If
        End If
      
        ofr1.CREAR_REPORTE(COD_SUCURSAL1, STATUS_SUC1, cbo_año.Text, OBJ.COD_MES(cbo_mes.Text), STATUS_PER1, COD_PER1, STATUS_DOC1, COD_DOC1, STATUS_CTA, NRO_CTA, fecha00, cbo_mes.Text, "BANCO", CADENA_CUENTA, TIPO_REPORTE)
        ofr1.ShowDialog()
    End Sub
    Sub HALLANDO_ULTIMO_DIA()
        Try
            Dim Prog002 As New SqlCommand("HALLAR_ULTIMO_DIA_MES", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text
            Prog002.Parameters.Add("@MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DIA_FINAL = (Rs3.GetValue(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(31) = 0
        Close()
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If Not Procesando Then
            If ch_si1.Checked And CBO_SUCURSAL1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la Sucursal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_SUCURSAL1.Focus() : Exit Sub
            If ch_per1.Checked And Trim(TXT_COD1.Text) = "" Then MessageBox.Show("Debe seleccionar la Persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : TXT_COD1.Focus() : Exit Sub
            If CH_DOC1.Checked And cbo_tipo_doc1.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_doc1.Focus() : Exit Sub
            'If (DateTime.Compare(dtp01.Value.Date, dtp02.Value.Date) > 0) Then MessageBox.Show("El Rango de fechas es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtp02.Focus() : Exit Sub
            If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Elija el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cbo_año.Focus() : Exit Sub
            If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Elija el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cbo_mes.Focus() : Exit Sub
            '---------------------------------------------------

            Procesando = True
            If ch_si1.Checked Then
                STATUS_SUC1 = "0"
                COD_SUCURSAL1 = CBO_SUCURSAL1.SelectedValue.ToString
            Else
                STATUS_SUC1 = "1"
                COD_SUCURSAL1 = "  "
            End If
            '----------------------------------------------------
            If ch_per1.Checked Then
                STATUS_PER1 = "0"
                COD_PER1 = TXT_COD1.Text
            Else
                STATUS_PER1 = "1"
                COD_PER1 = "  "
            End If
            '-----------------------------------------------------
            Dim TIPO_REPORTE As String = ""
            If CH_DOC1.Checked Then
                TIPO_REPORTE = "1"
                STATUS_DOC1 = "0"
                COD_DOC1 = OBJ.COD_DOC(cbo_tipo_doc1.Text)
            Else
                STATUS_DOC1 = "1"
                COD_DOC1 = "  "
            End If
            '-------------------------------------------------------
            Dim STATUS_CTA, NRO_CTA As String
            STATUS_CTA = "1"
            NRO_CTA = "  "
            '-------------------------------------------------------
            HALLANDO_ULTIMO_DIA()
            Dim fecha00 As Date

            fecha00 = Date.Parse(DIA_FINAL & "/" & OBJ.COD_MES(cbo_mes.Text) & "/" & cbo_año.Text)
            If Format(fecha00, "MM/yyyy") = Format(Now(), "MM/yyyy") Then
                fecha00 = Format(Now(), "dd/MM/yyyy")
            End If
            SUB_CADENA_CUENTA()

            If CH_DOC1.Checked = False Then
                If dgw1.RowCount = 0 Then
                    TIPO_REPORTE = "1"
                Else
                    TIPO_REPORTE = "2"
                End If
            End If
            '--------------------------------
            'COD_SUCURSAL1, STATUS_SUC1, cbo_año.Text, OBJ.COD_MES(cbo_mes.Text), STATUS_PER1, COD_PER1, STATUS_DOC1, COD_DOC1, STATUS_CTA, NRO_CTA, fecha00, cbo_mes.Text, "BANCO", CADENA_CUENTA, TIPO_REPORTE
            '--------------------------------
            'mes y año del formulario
            OBJ.frm_año = cbo_año.Text
            OBJ.frm_mes = cbo_mes.Text
            '-------------
            DGW2.Rows.Clear()
            Try
                Dim CMD As New SqlCommand("REPORTE_CXP_PTES1", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.AddWithValue("@COD_SUCURSAL", COD_SUCURSAL1)
                CMD.Parameters.AddWithValue("@ST_SUC", STATUS_SUC1)
                CMD.Parameters.AddWithValue("@FE_AÑO", cbo_año.Text)
                CMD.Parameters.AddWithValue("@FE_MES", OBJ.COD_MES(cbo_mes.Text))
                CMD.Parameters.AddWithValue("@ST_PER", STATUS_PER1)
                CMD.Parameters.AddWithValue("@COD_PER", COD_PER1)
                CMD.Parameters.AddWithValue("@ST_DOC", STATUS_DOC1)
                CMD.Parameters.AddWithValue("@COD_DOC", COD_DOC1)
                CMD.Parameters.AddWithValue("@ST_CUENTA", STATUS_CTA)
                CMD.Parameters.AddWithValue("@COD_CUENTA", NRO_CTA)
                CMD.Parameters.AddWithValue("@COD_DOC_FILTRO", CADENA_CUENTA)
                CMD.Parameters.AddWithValue("@TIPO_REPORTE", TIPO_REPORTE)
                con.Open()
                Dim reader As SqlDataReader = CMD.ExecuteReader
                Dim DifferenceInDays As Long
                If Not reader Is Nothing AndAlso reader.HasRows Then
                    While reader.Read
                        'Dim OldDate As Date = #1/1/2002#
                        'Dim NewDate As Date = Now
                        DifferenceInDays = DateDiff(DateInterval.Day, reader(9), fecha00)
                        DGW2.Rows.Add(reader(5), reader(6), reader(7), reader(11), reader(2), reader(3), _
                        reader(4), Format(reader(8), "dd/MM/yyyy"), Format(reader(9), "dd/MM/yyyy"), DifferenceInDays, reader(10) _
                        , reader(14), reader(15), reader(16), reader(17))
                    End While
                End If
                con.Close()
            Catch ex As Exception
                MessageBox.Show("No se pudo generar los datos a exportar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Procesando = False
                con.Close()
                Return
            End Try
            If DGW2.RowCount = 0 Then
                MessageBox.Show("No existen registros para mostrar." & vbNewLine & "Aviso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Procesando = False
                Exit Sub
            End If

            tspbExportar.Visible = True
            tslMensaje.Visible = True
            Dim oCallBack As New AsyncCallback(AddressOf MostrarResultado)
            oExportar.BeginInvoke(DGW2, oCallBack, Nothing)
        End If
    End Sub
End Class