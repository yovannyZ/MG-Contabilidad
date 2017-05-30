Imports System.Data.SqlClient
Public Class RC
    Dim boton, CodigoBienes, CodigoConvenio, TipoRenta As String
    Dim OBJ As New Class1
    Dim fila As Integer
    Public N, M, E1 As Boolean

    Private Sub RC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub RC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        DATAGRID()
        CargarMonedas()
        dgw_detalle.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
    End Sub
    Private Sub CargarMonedas()
        Dim Gen As New Genericos
        Dim dt As New DataTable
        dt = Gen.CBO_MONEDAS
        cboMonedaOrigen.DataSource = dt
        cboMonedaOrigen.DisplayMember = dt.Columns.Item(0).ToString
        cboMonedaOrigen.ValueMember = dt.Columns.Item(1).ToString
        cboMonedaOrigen.SelectedIndex = -1
    End Sub
    Sub CBO_REFERENCIA()
        cbo_ref.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_REF", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_ref.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CARGAR_TITULOS()
        dgw_detalle.Item(0, 0).Value = "01"
        dgw_detalle.Item(0, 1).Value = "02"
        dgw_detalle.Item(0, 2).Value = "03"
        dgw_detalle.Item(0, 3).Value = "04"
        dgw_detalle.Item(0, 4).Value = "05"
        dgw_detalle.Item(0, 5).Value = "06"
        dgw_detalle.Item(0, 6).Value = "07"
        dgw_detalle.Item(0, 7).Value = "08"
        dgw_detalle.Item(0, 8).Value = "09"
        dgw_detalle.Item(0, 9).Value = "10"
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_TITULOS_RC", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                dgw_detalle.Item(1, 0).Value = (Rs3.GetValue(0))
                dgw_detalle.Item(1, 1).Value = Rs3.GetValue(1)
                dgw_detalle.Item(1, 2).Value = Rs3.GetValue(2)
                dgw_detalle.Item(1, 3).Value = Rs3.GetValue(3)
                dgw_detalle.Item(1, 4).Value = Rs3.GetValue(4)
                dgw_detalle.Item(1, 5).Value = Rs3.GetValue(5)
                dgw_detalle.Item(1, 6).Value = Rs3.GetValue(6)
                dgw_detalle.Item(1, 7).Value = Rs3.GetValue(7)
                dgw_detalle.Item(1, 8).Value = Rs3.GetValue(8)
                dgw_detalle.Item(1, 9).Value = Rs3.GetValue(9)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub DATAGRID()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_CONSULTA_RC", con)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
            pro_02.Parameters.Add("@TIPO_USU", SqlDbType.VarChar).Value = TIPO_USU
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("RC")
            Prog02.Fill(dt_02)
            dgw1.DataSource = dt_02
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
            dgw1.Columns(0).Width = 30
            dgw1.Columns(1).Width = 70
            dgw1.Columns(2).Width = 30
            dgw1.Columns(3).Width = 70
            dgw1.Columns(4).Width = 45
            dgw1.Columns(5).Width = 25
            dgw1.Columns(7).Width = 55
            dgw1.Columns(8).Width = 180
            dgw1.Columns(9).Width = 80
            dgw1.Columns(10).Width = 80 : dgw1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns(11).Width = 45
            dgw1.Columns(12).Visible = False
            dgw1.Columns(13).Visible = False
            dgw1.Columns(14).Visible = False
            dgw1.Columns(15).Visible = False
            dgw1.Columns(16).Visible = False
            dgw1.Columns(17).Visible = False
            dgw1.Columns(18).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(27) = 0
        Close()
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_modificar.Select()
            Exit Sub
        End Try
        boton = "MODIFICAR"
        limpiar()
        CARGAR_TITULOS()
        CBO_REFERENCIA()
        TabControl1.SelectedTab = TabPage2
        CARGAR_DATOS_CABECERA()
        CARGAR_DETALLES_DGW()
        btn_guardar.Focus()
        btn_guardar.Visible = True
    End Sub
    Sub CARGAR_DATOS_CABECERA()
        txt_auxiliar.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_comp.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        txt_nro_comp.Text = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        txt_cod_doc.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        txt_desc_doc.Text = OBJ.DESC_DOC(txt_cod_doc.Text)
        txt_nro_doc.Text = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        cod_per.Text = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        nro_doc_per.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        des_per.Text = dgw1.Item(8, dgw1.CurrentRow.Index).Value.ToString
        txt_importe.Text = dgw1.Item(10, dgw1.CurrentRow.Index).Value.ToString
        txt_importe.Text = OBJ.HACER_DECIMAL(txt_importe.Text)
        ch_gasto.Checked = dgw1.Item(11, dgw1.CurrentRow.Index).Value
        '---------------------------------------------------------------------------------
        txt_nro_det.Text = dgw1.Item(12, dgw1.CurrentRow.Index).Value
        txt_tasa_det.Text = CInt(dgw1.Item(13, dgw1.CurrentRow.Index).Value).ToString("00000") 'dgw1.Item(13, dgw1.CurrentRow.Index).Value
        dtp_det.Value = dgw1.Item(14, dgw1.CurrentRow.Index).Value
        '---------------------------------------------------------------------------------
        cbo_ref.Text = OBJ.DESC_DOC(dgw1.Item(15, dgw1.CurrentRow.Index).Value)
        txt_nro_ref.Text = dgw1.Item(16, dgw1.CurrentRow.Index).Value
        dtp_ref.Value = dgw1.Item(17, dgw1.CurrentRow.Index).Value
        '---------------------------------------------------------------------------------
        dtp_pago.Value = dgw1.Item(18, dgw1.CurrentRow.Index).Value
        RecuperarDescripcionCodigoBienes(dgw1.Item(19, dgw1.CurrentRow.Index).Value)
        cboMonedaOrigen.Text = OBJ.DESC_MONEDA(dgw1.Item(20, dgw1.CurrentRow.Index).Value)
        RecuperarDescripcionConvenios(dgw1.Item(21, dgw1.CurrentRow.Index).Value)
        RecuperarDescripcionTipoRenta(dgw1.Item(22, dgw1.CurrentRow.Index).Value)
    End Sub
    Sub limpiar()
        gb_cabecera.Enabled = False
        txt_nro_det.Clear()
        txt_tasa_det.Clear()
        txt_auxiliar.Clear()
        txt_comp.Clear()
        txt_nro_comp.Clear()
        txt_cod_doc.Clear()
        txt_nro_doc.Clear()
        cod_per.Clear()
        nro_doc_per.Clear()
        des_per.Clear()
        txt_importe.Clear()
        cbo_ref.SelectedIndex = -1
        txt_nro_ref.Clear()
        dgw_detalle.Rows.Clear()
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
        dgw_detalle.Rows.Add(" ", " ")
    End Sub
    Sub CARGAR_DETALLES_DGW()
        'dgw_detalle.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_DETALLES_CONSULTA_RC", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_cod_doc.Text
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = cod_per.Text
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = nro_doc_per.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                If dgw_detalle.Item(1, 0).Value <> "" Then
                    dgw_detalle.Item(2, 0).Value = (Rs3.GetValue(0))
                Else
                    dgw_detalle.Item(2, 0).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 1).Value <> "" Then
                    dgw_detalle.Item(2, 1).Value = Rs3.GetValue(1)
                Else
                    dgw_detalle.Item(2, 1).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 2).Value <> "" Then
                    dgw_detalle.Item(2, 2).Value = Rs3.GetValue(2)
                Else
                    dgw_detalle.Item(2, 2).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 3).Value <> "" Then
                    dgw_detalle.Item(2, 3).Value = Rs3.GetValue(3)
                Else
                    dgw_detalle.Item(2, 3).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 4).Value <> "" Then
                    dgw_detalle.Item(2, 4).Value = Rs3.GetValue(4)
                Else
                    dgw_detalle.Item(2, 4).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 5).Value <> "" Then
                    dgw_detalle.Item(2, 5).Value = Rs3.GetValue(5)
                Else
                    dgw_detalle.Item(2, 5).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 6).Value <> "" Then
                    dgw_detalle.Item(2, 6).Value = Rs3.GetValue(6)
                Else
                    dgw_detalle.Item(2, 6).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 7).Value <> "" Then
                    dgw_detalle.Item(2, 7).Value = Rs3.GetValue(7)
                Else
                    dgw_detalle.Item(2, 7).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 8).Value <> "" Then
                    dgw_detalle.Item(2, 8).Value = Rs3.GetValue(8)
                Else
                    dgw_detalle.Item(2, 8).Value = " "
                End If
                '---------------------------------------------
                If dgw_detalle.Item(1, 9).Value <> "" Then
                    dgw_detalle.Item(2, 9).Value = Rs3.GetValue(9)
                Else
                    dgw_detalle.Item(2, 9).Value = " "
                End If
                '---------------------------------------------
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        '---------------------------------------------
        Dim I, CONT As Integer
        I = 0 : CONT = dgw_detalle.RowCount - 1
        While I <= CONT
            If dgw_detalle.Item(1, I).Value.ToString = "" Then
                dgw_detalle.Rows.RemoveAt(I)
                I = 0 : CONT = dgw_detalle.RowCount - 1
            Else
                I = I + 1
            End If
        End While
        '---------------------------------------------
    End Sub
    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        TabControl1.SelectedTab = TabPage1
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'If Trim(txt_nro.Text) = "" Then MessageBox.Show("Debe insertar el Nro Parte Diario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro.Focus() : Exit Sub
        '-----------------------
        Dim I, CONT As Integer
        Dim SUM As Decimal
        I = 0
        CONT = dgw_detalle.Rows.Count - 1
        SUM = 0.0
        For I = 0 To CONT
            If dgw_detalle.Item(2, I).Value.ToString.Trim = "" Then
                dgw_detalle.Item(2, I).Value = "0.00"
            End If
            SUM = SUM + dgw_detalle.Item(2, I).Value
        Next
        Dim st_gasto As String = "0"
        If ch_gasto.Checked = True Then st_gasto = "1"

        Dim rpta As DialogResult


        If SUM = txt_importe.Text Then
            ACTUALIZAR_IMPORTES(st_gasto)
            FOCO_NUEVO_REG()
            TabControl1.SelectedTab = TabPage1
        Else
            rpta = MessageBox.Show("La suma de los importes no coincide con el total. ¿Realmente desea grabar los documentos?", _
                 "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If rpta = Windows.Forms.DialogResult.Yes Then
                ACTUALIZAR_IMPORTES(st_gasto)
                FOCO_NUEVO_REG()
                TabControl1.SelectedTab = TabPage1
            End If
            'MessageBox.Show("Debe ingresar importes acorde al total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ''txt_nro.Focus()
            'Exit Sub
        End If
        '-----------------------
    End Sub
    Sub ACTUALIZAR_IMPORTES(ByVal GASTO0 As String)
        Dim IMP01, IMP02, IMP03, IMP04, IMP05, IMP06, IMP07, IMP08, IMP09, IMP10 As Decimal
        IMP01 = 0 : IMP02 = 0 : IMP03 = 0 : IMP04 = 0 : IMP05 = 0 : IMP06 = 0
        IMP07 = 0 : IMP08 = 0 : IMP09 = 0 : IMP10 = 0
        Dim I, CONT As Integer
        I = 0 : CONT = dgw_detalle.RowCount - 1
        For I = 0 To CONT
            Select Case dgw_detalle.Item(0, I).Value.ToString
                Case "01" : IMP01 = dgw_detalle.Item(2, I).Value
                Case "02" : IMP02 = dgw_detalle.Item(2, I).Value
                Case "03" : IMP03 = dgw_detalle.Item(2, I).Value
                Case "04" : IMP04 = dgw_detalle.Item(2, I).Value
                Case "05" : IMP05 = dgw_detalle.Item(2, I).Value
                Case "06" : IMP06 = dgw_detalle.Item(2, I).Value
                Case "07" : IMP07 = dgw_detalle.Item(2, I).Value
                Case "08" : IMP08 = dgw_detalle.Item(2, I).Value
                Case "09" : IMP09 = dgw_detalle.Item(2, I).Value
                Case "10" : IMP10 = dgw_detalle.Item(2, I).Value
            End Select
        Next
        '----------------------------------------------------------------------------------------
        Try
            Dim CMD As New SqlCommand("MODIFICAR_IMPORTES_RC", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txt_cod_doc.Text
            CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = cod_per.Text
            CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = nro_doc_per.Text
            CMD.Parameters.Add("@IMP01", SqlDbType.Decimal).Value = IMP01
            CMD.Parameters.Add("@IMP02", SqlDbType.Decimal).Value = IMP02
            CMD.Parameters.Add("@IMP03", SqlDbType.Decimal).Value = IMP03
            CMD.Parameters.Add("@IMP04", SqlDbType.Decimal).Value = IMP04
            CMD.Parameters.Add("@IMP05", SqlDbType.Decimal).Value = IMP05
            CMD.Parameters.Add("@IMP06", SqlDbType.Decimal).Value = IMP06
            CMD.Parameters.Add("@IMP07", SqlDbType.Decimal).Value = IMP07
            CMD.Parameters.Add("@IMP08", SqlDbType.Decimal).Value = IMP08
            CMD.Parameters.Add("@IMP09", SqlDbType.Decimal).Value = IMP09
            CMD.Parameters.Add("@IMP10", SqlDbType.Decimal).Value = IMP10
            CMD.Parameters.Add("@STATUS_GASTO", SqlDbType.Char).Value = GASTO0
            CMD.Parameters.Add("@NRO_DET", SqlDbType.VarChar).Value = txt_nro_det.Text
            CMD.Parameters.Add("@TASA_DET", SqlDbType.Decimal).Value = txt_tasa_det.Text
            CMD.Parameters.Add("@FECHA_DET", SqlDbType.DateTime).Value = dtp_det.Value
            CMD.Parameters.Add("@COD_REF", SqlDbType.VarChar).Value = IIf(String.IsNullOrEmpty(OBJ.COD_DOC(cbo_ref.Text)), "", OBJ.COD_DOC(cbo_ref.Text))
            CMD.Parameters.Add("@NRO_REF", SqlDbType.VarChar).Value = txt_nro_ref.Text
            CMD.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = dtp_ref.Value
            CMD.Parameters.Add("@FECHA_PAGO", SqlDbType.DateTime).Value = dtp_pago.Value
            CMD.Parameters.Add("@COD_BIENES", SqlDbType.Char).Value = CodigoBienes
            If cboMonedaOrigen.SelectedValue = Nothing Then
                CMD.Parameters.Add("@COD_MONEDA_ORIGEN", SqlDbType.Char).Value = ""
            Else
                CMD.Parameters.Add("@COD_MONEDA_ORIGEN", SqlDbType.Char).Value = cboMonedaOrigen.SelectedValue
            End If
            If CodigoConvenio = Nothing Then
                CMD.Parameters.Add("@COD_CONVENIO_DI", SqlDbType.Char).Value = ""
            Else
                CMD.Parameters.Add("@COD_CONVENIO_DI", SqlDbType.Char).Value = CodigoConvenio
            End If
            If TipoRenta = Nothing Then
                CMD.Parameters.Add("@TIPO_RENTA", SqlDbType.Char).Value = ""
            Else
                CMD.Parameters.Add("@TIPO_RENTA", SqlDbType.Char).Value = TipoRenta
            End If
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("El registro se actualizó correctamente.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'TabControl1.SelectedTab = TabPage1
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()

    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        Dim NRO_OC As String = txt_nro_doc.Text.Trim
        Dim PER As String = cod_per.Text.Trim
        Dim GRID1, GRID2 As String
        'Dim  As String
        For I = 0 To CONT
            If NRO_OC = dgw1.Item(6, I).Value And PER = dgw1.Item(7, I).Value Then
                dgw1.CurrentCell = (dgw1.Rows.Item(I).Cells.Item(6))
                Exit Sub
            End If
            GRID1 = dgw1.Item(6, I).Value
            GRID2 = dgw1.Item(7, I).Value
        Next
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        btn_sgt.Enabled = True
        Dim i, f As Integer
        txt_letra.Focus()
        For i = 0 To dgw1.RowCount() - 1
            For f = 1 To Len(dgw1.Item(8, i).Value.ToString)
                If txt_letra.Text.ToLower = Mid(dgw1.Item(8, i).Value.ToString, f, Len(txt_letra.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(1)
                    fila = i + 1
                    Exit Sub
                End If
            Next
        Next
    End Sub
    Private Sub btn_sgt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sgt.Click
         Dim i, f As Integer
        txt_letra.Focus()
        For i = fila To dgw1.RowCount() - 1
            For f = 1 To Len(dgw1.Item(8, i).Value.ToString)
                If txt_letra.Text.ToLower = Mid(dgw1.Item(8, i).Value.ToString, f, Len(txt_letra.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(1)
                    fila = i + 1
                    Exit Sub
                End If
            Next
        Next
        MessageBox.Show("Ya no existen más registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub txt_letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_letra.TextChanged
        Dim i As Integer
        If ch_cod_aux.Checked Then
            txt_letra.Focus()
            For i = 0 To dgw1.RowCount() - 1
                If txt_letra.Text.ToLower = Mid(dgw1.Item(1, i).Value, 1, Len(txt_letra.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(1)
                    Exit For
                End If
            Next
        ElseIf ch_nro_doc.Checked Then
            txt_letra.Focus()
            For i = 0 To dgw1.RowCount() - 1
                If txt_letra.Text.ToLower = Mid(dgw1.Item(6, i).Value, 1, Len(txt_letra.Text)).ToLower Then
                    dgw1.CurrentCell = dgw1.Rows(i).Cells(6)
                    Exit For
                End If
            Next

        End If
    End Sub
    Private Sub ch_cod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_cod_aux.CheckedChanged
        If ch_cod_aux.Checked = True Then
            dgw1.Sort(dgw1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_ca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_ca.CheckedChanged
        If ch_ca.Checked = True Then
            dgw1.Sort(dgw1.Columns(8), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            btn_buscar.Enabled = True
            btn_sgt.Enabled = False
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_nro_doc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_nro_doc.CheckedChanged
        If ch_nro_doc.Checked = True Then
            dgw1.Sort(dgw1.Columns(6), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra.Clear()
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Focus()
        End If
    End Sub
    Private Sub dgw_detalle_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgw_detalle.CellBeginEdit
        If dgw_detalle.CurrentCellAddress.X = 2 Then
            Try
                dgw_detalle.Item(2, dgw_detalle.CurrentRow.Index).Value = OBJ.HACER_DECIMAL(dgw_detalle.Item(2, dgw_detalle.CurrentRow.Index).Value)
            Catch ex As Exception
                dgw_detalle.Item(2, dgw_detalle.CurrentRow.Index).Value = "0.00"
            End Try
        End If
    End Sub
    Private Sub dgw_detalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_detalle.CellEndEdit
        If dgw_detalle.CurrentCellAddress.X = 2 Then
            Try
                dgw_detalle.Item(2, dgw_detalle.CurrentRow.Index).Value = OBJ.HACER_DECIMAL(dgw_detalle.Item(2, dgw_detalle.CurrentRow.Index).Value)
            Catch ex As Exception
                dgw_detalle.Item(2, dgw_detalle.CurrentRow.Index).Value = "0.00"
            End Try
        End If
    End Sub
    Private Sub txt_tasa_det_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = Numero(e, (txt_tasa_det))
    End Sub
    Private Sub txt_tasa_det_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            txt_tasa_det.Text = (OBJ.HACER_DECIMAL(txt_tasa_det.Text))
        Catch ex As Exception
            txt_tasa_det.Text = "0.00"
        End Try
    End Sub
    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.]" Then
            Return True
        End If
        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub cboCodigoBienes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCodigoBienes.SelectedIndexChanged
        If cboCodigoBienes.SelectedIndex = 0 Then
            CodigoBienes = "1"
        ElseIf (cboCodigoBienes.SelectedIndex = 1) Then
            CodigoBienes = "2"
        ElseIf (cboCodigoBienes.SelectedIndex = 2) Then
            CodigoBienes = "3"
        ElseIf (cboCodigoBienes.SelectedIndex = 3) Then
            CodigoBienes = "4"
        ElseIf (cboCodigoBienes.SelectedIndex = 4) Then
            CodigoBienes = "5"
        Else
            CodigoBienes = ""
        End If
    End Sub
    Private Sub RecuperarDescripcionCodigoBienes(ByVal Codigo As String)
        If Codigo = "1" Then
            cboCodigoBienes.SelectedIndex = 0
        ElseIf Codigo = "2" Then
            cboCodigoBienes.SelectedIndex = 1
        ElseIf Codigo = "3" Then
            cboCodigoBienes.SelectedIndex = 2
        ElseIf Codigo = "4" Then
            cboCodigoBienes.SelectedIndex = 3
        ElseIf Codigo = "5" Then
            cboCodigoBienes.SelectedIndex = 4
        Else
            cboCodigoBienes.SelectedIndex = -1
        End If
    End Sub


    Private Sub cboTipoRenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoRenta.SelectedIndexChanged
        If cboTipoRenta.SelectedIndex = 0 Then
            TipoRenta = "00"
        ElseIf cboTipoRenta.SelectedIndex = 1 Then
            TipoRenta = "01"
        ElseIf cboTipoRenta.SelectedIndex = 2 Then
            TipoRenta = "06"
        ElseIf cboTipoRenta.SelectedIndex = 3 Then
            TipoRenta = "07"
        ElseIf cboTipoRenta.SelectedIndex = 4 Then
            TipoRenta = "09"
        ElseIf cboTipoRenta.SelectedIndex = 5 Then
            TipoRenta = "10"
        ElseIf cboTipoRenta.SelectedIndex = 6 Then
            TipoRenta = "18"
        ElseIf cboTipoRenta.SelectedIndex = 7 Then
            TipoRenta = "19"
        ElseIf cboTipoRenta.SelectedIndex = 8 Then
            TipoRenta = "33"
        ElseIf cboTipoRenta.SelectedIndex = 9 Then
            TipoRenta = "35"
        ElseIf cboTipoRenta.SelectedIndex = 10 Then
            TipoRenta = "41"
        Else
            TipoRenta = ""
        End If
    End Sub
    Private Sub RecuperarDescripcionTipoRenta(ByVal Codigo As String)
        If Codigo = "00" Then
            cboTipoRenta.SelectedIndex = 0
        ElseIf Codigo = "01" Then
            cboTipoRenta.SelectedIndex = 1
        ElseIf Codigo = "06" Then
            cboTipoRenta.SelectedIndex = 2
        ElseIf Codigo = "07" Then
            cboTipoRenta.SelectedIndex = 3
        ElseIf Codigo = "09" Then
            cboTipoRenta.SelectedIndex = 4
        ElseIf Codigo = "10" Then
            cboTipoRenta.SelectedIndex = 5
        ElseIf Codigo = "18" Then
            cboTipoRenta.SelectedIndex = 6
        ElseIf Codigo = "19" Then
            cboTipoRenta.SelectedIndex = 7
        ElseIf Codigo = "33" Then
            cboTipoRenta.SelectedIndex = 8
        ElseIf Codigo = "35" Then
            cboTipoRenta.SelectedIndex = 9
        ElseIf Codigo = "41" Then
            cboTipoRenta.SelectedIndex = 10
        Else
            cboTipoRenta.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboConvenios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboConvenios.SelectedIndexChanged
        If cboConvenios.SelectedIndex = 0 Then
            CodigoConvenio = "00"
        ElseIf cboConvenios.SelectedIndex = 1 Then
            CodigoConvenio = "01"
        ElseIf cboConvenios.SelectedIndex = 2 Then
            CodigoConvenio = "02"
        ElseIf cboConvenios.SelectedIndex = 3 Then
            CodigoConvenio = "03"
        ElseIf cboConvenios.SelectedIndex = 4 Then
            CodigoConvenio = "04"
        ElseIf cboConvenios.SelectedIndex = 5 Then
            CodigoConvenio = "05"
        ElseIf cboConvenios.SelectedIndex = 6 Then
            CodigoConvenio = "06"
        ElseIf cboConvenios.SelectedIndex = 7 Then
            CodigoConvenio = "07"
        ElseIf cboConvenios.SelectedIndex = 8 Then
            CodigoConvenio = "08"
        ElseIf cboConvenios.SelectedIndex = 9 Then
            CodigoConvenio = "09"
        Else
            CodigoConvenio = ""
        End If
    End Sub
    Private Sub RecuperarDescripcionConvenios(ByVal Codigo As String)
        If Codigo = "00" Then
            cboConvenios.SelectedIndex = 0
        ElseIf Codigo = "01" Then
            cboConvenios.SelectedIndex = 1
        ElseIf Codigo = "02" Then
            cboConvenios.SelectedIndex = 2
        ElseIf Codigo = "03" Then
            cboConvenios.SelectedIndex = 3
        ElseIf Codigo = "04" Then
            cboConvenios.SelectedIndex = 4
        ElseIf Codigo = "05" Then
            cboConvenios.SelectedIndex = 5
        ElseIf Codigo = "06" Then
            cboConvenios.SelectedIndex = 6
        ElseIf Codigo = "07" Then
            cboConvenios.SelectedIndex = 7
        ElseIf Codigo = "08" Then
            cboConvenios.SelectedIndex = 8
        ElseIf Codigo = "09" Then
            cboConvenios.SelectedIndex = 9
        Else
            cboConvenios.SelectedIndex = -1
        End If
    End Sub
End Class