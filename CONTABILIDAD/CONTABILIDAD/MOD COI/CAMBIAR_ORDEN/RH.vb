Imports System.Data.SqlClient
Public Class RH
    Dim boton As String
    Dim OBJ As New Class1
    Dim fila As Integer
    Public N, M, E1 As Boolean
    Private Sub RH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGrid()
        dgw_detalle.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
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
            Dim PROG_01 As New SqlCommand("MOSTRAR_TITULOS_RH", con)
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
            Dim pro_02 As New SqlCommand("MOSTRAR_CONSULTA_RH", con)
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
            'dgw1.Columns(7).Visible = False
            'dgw1.Columns(8).Visible = False
            'dgw1.Columns(9).Visible = False
            'dgw1.Columns(10).Visible = False
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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(72) = 0
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
    End Sub
    Sub limpiar()
        gb_cabecera.Enabled = False
        txt_auxiliar.Clear()
        txt_comp.Clear()
        txt_nro_comp.Clear()
        txt_cod_doc.Clear()
        txt_nro_doc.Clear()
        cod_per.Clear()
        nro_doc_per.Clear()
        des_per.Clear()
        txt_importe.Clear()
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
            Dim PROG_01 As New SqlCommand("MOSTRAR_DETALLES_CONSULTA_RH", con)
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
        If SUM = txt_importe.Text Then
            ACTUALIZAR_IMPORTES()
        Else
            MessageBox.Show("Debe ingresar importes acorde al total", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
             Exit Sub
        End If
        '-----------------------
    End Sub
    Sub ACTUALIZAR_IMPORTES()
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
        Try
            Dim CMD As New SqlCommand("MODIFICAR_IMPORTES_RH", con)
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
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Los importes del Registro de Honorarios se actualizaron", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedTab = TabPage1
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()
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
End Class