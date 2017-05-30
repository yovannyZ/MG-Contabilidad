Imports System.Data.SqlClient
Public Class AREA
    Dim BOTON, cod_tipo_dist, ST_SUMARIO, TIPO_DIST, COD_AREA, ST_SUSPENDIDO As String
    Private fila, INDICE As Integer
 Private Sub AREA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
        If (e.KeyCode = Keys.F1) Then
            Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub AREA_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CARGAR_ZONA()
        CARGAR_NEGOCIO()
        ch_cod.Checked = True
        btn_nuevo.Select()
    End Sub
    Sub CARGAR_NEGOCIO()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_DIRECTORIO_DATO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = "TNEGO"
            Dim da As New SqlDataAdapter(Cmd)
            Dim dt As New DataTable("Negocio")
            da.Fill(dt)
            cboUnidadNegocio.DataSource = dt
            cboUnidadNegocio.DisplayMember = dt.Columns.Item(1).ToString
            cboUnidadNegocio.ValueMember = dt.Columns.Item(0).ToString
            cboUnidadNegocio.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_ZONA()
        Dim dt As New DataTable
        Dim sqlda As New SqlDataAdapter("SELECT CODIGO,DESCRIPCION FROM DIRECTORIO WHERE TABLA_COD='TNEGZ' AND TIPO='D'", con)
        con.Open()
        sqlda.Fill(dt)
        cboZona.DataSource = dt
        cboZona.ValueMember = dt.Columns(0).ToString
        cboZona.DisplayMember = dt.Columns(1).ToString
        cboZona.SelectedIndex = -1
        con.Close()
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar.Click
        btn_sgt.Enabled = True
        txt_letra.Focus()
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw1.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra.Text.ToLower = Strings.Mid(dgw1.Item(1, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(1)
                    fila = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        LIMPIAR()
        GB.Enabled = False
        btn_guardar.Visible = False
        btn_modificar2.Visible = False
        f1.Visible = True
        btn_nuevo.Select()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Eliga un detalle", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Exit Sub
        End Try
        Dim cd As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (cd.Length < 5) Then
            Select Case verificacion1(cd)
                Case "MAL5"
                    MessageBox.Show("Existe Nivel 5", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                Case "MAL3"
                    MessageBox.Show("Existe Nivel 3", "Imposible Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
            End Select
        End If
        If (Decimal.Parse((CInt(MessageBox.Show(("Esta seguro de eliminar el Area " & cd), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_AREA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_AREA", SqlDbType.Char).Value = cd
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
        End If
        btn_nuevo.Select()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf (((txt_cod.Text.Length <> 1) And (txt_cod.Text.Length <> 3)) And (txt_cod.Text.Length <> 5)) Then
            MessageBox.Show("Solo puede ser de Nivel 1, 3 ó 5", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            ST_SUMARIO = "0"
            If ch_sumario.Checked Then
                ST_SUMARIO = "1"
            End If
            ST_SUSPENDIDO = "0"
            If chkSuspendido.Checked Then
                ST_SUSPENDIDO = "1"
            End If
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("El Código de Centro de Costos ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                Select Case cbo_tipo.SelectedIndex
                    Case -1
                        cod_tipo_dist = " "
                    Case 0
                        cod_tipo_dist = "P"
                    Case 1
                        cod_tipo_dist = "S"
                    Case 2
                        cod_tipo_dist = "I"
                End Select
                COD_AREA = txt_cod.Text
                Dim CNEG, CZONA As String
                If cboUnidadNegocio.SelectedIndex <> -1 Then CNEG = cboUnidadNegocio.SelectedValue.ToString Else CNEG = ""
                If cboZona.SelectedIndex <> -1 Then CZONA = cboZona.SelectedValue.ToString Else CZONA = ""
                Try
                    Dim CMD As New SqlCommand("INSERTAR_AREA", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@COD_AREA", SqlDbType.Char).Value = txt_cod.Text
                    CMD.Parameters.Add("@DESC_AREA", SqlDbType.VarChar).Value = txt_desc.Text
                    CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                    CMD.Parameters.Add("@CTA_ANA", SqlDbType.Char).Value = TXT_CTA_ANA.Text
                    CMD.Parameters.Add("@ST_SUMARIO", SqlDbType.Char).Value = ST_SUMARIO
                    CMD.Parameters.Add("@TIPO_DIST", SqlDbType.Char).Value = cod_tipo_dist
                    CMD.Parameters.Add("@CODNEGOCIO", SqlDbType.Char).Value = CNEG
                    CMD.Parameters.Add("@CODZONA", SqlDbType.Char).Value = CZONA
                    CMD.Parameters.Add("@ST_SUSPENDIDO", SqlDbType.Char).Value = ST_SUSPENDIDO
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                    LIMPIAR()
                    GB.Enabled = False
                    btn_guardar.Visible = False
                    f1.Visible = True
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                DATAGRID()
                FOCO_NUEVO_REG()
                btn_nuevo.Select()
            End If
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        'INDICE = dgw1.CurrentRow.Index
        LIMPIAR()
        txt_cod.Enabled = False
        cargar_dato()
        dgw1.Enabled = False
        f1.Visible = False
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        GB.Enabled = True
        txt_desc.Focus()

    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe ingresar el Código", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        Else
            ST_SUMARIO = "0"
            If ch_sumario.Checked Then
                ST_SUMARIO = "1"
            End If
            ST_SUSPENDIDO = "0"
            If chkSuspendido.Checked Then
                ST_SUSPENDIDO = "1"
            End If
            Select Case cbo_tipo.SelectedIndex
                Case -1
                    cod_tipo_dist = " "
                Case 0
                    cod_tipo_dist = "P"
                Case 1
                    cod_tipo_dist = "S"
                Case 2
                    cod_tipo_dist = "I"
            End Select
            COD_AREA = txt_cod.Text
            Dim CNEG, CZONA As String
            If cboUnidadNegocio.SelectedIndex <> -1 Then CNEG = cboUnidadNegocio.SelectedValue.ToString Else CNEG = ""
            If cboZona.SelectedIndex <> -1 Then CZONA = cboZona.SelectedValue.ToString Else CZONA = ""
            Try
                Dim CMD As New SqlCommand("MODIFICAR_AREA", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_AREA", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_AREA", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                CMD.Parameters.Add("@CTA_ANA", SqlDbType.Char).Value = TXT_CTA_ANA.Text
                CMD.Parameters.Add("@ST_SUMARIO", SqlDbType.Char).Value = ST_SUMARIO
                CMD.Parameters.Add("@TIPO_DIST", SqlDbType.Char).Value = cod_tipo_dist
                CMD.Parameters.Add("@CODNEGOCIO", SqlDbType.Char).Value = CNEG
                CMD.Parameters.Add("@CODZONA", SqlDbType.Char).Value = CZONA
                CMD.Parameters.Add("@ST_SUSPENDIDO", SqlDbType.Char).Value = ST_SUSPENDIDO
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                LIMPIAR()
                GB.Enabled = False
                btn_modificar2.Visible = False
                f1.Visible = True
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
            FOCO_NUEVO_REG()
            'dgw1.CurrentCell = (dgw1.Rows.Item(INDICE).Cells.Item(1))
            btn_nuevo.Select()
        End If
    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        'Dim COD_AREA As String = txt_cod.Text
        For I = 0 To CONT
            If COD_AREA = dgw1.Item(0, I).Value.ToString.ToLower Then
                dgw1.CurrentCell = (dgw1.Rows.Item(I).Cells.Item(0))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        LIMPIAR()
        f1.Visible = False
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        GB.Enabled = True
        txt_cod.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(2) = 0
        Close()
    End Sub
    Private Sub btn_sgt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt.Click
        txt_letra.Focus()
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = fila
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw1.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra.Text.ToLower = Strings.Mid(dgw1.Item(1, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(1)
                    fila = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Sub cargar_dato()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (txt_cod.Text.Length = Decimal.Parse("5")) Then
            TXT_CTA_ANA.Enabled = True
            ch_sumario.Enabled = True
            cbo_tipo.Enabled = True
        Else
            TXT_CTA_ANA.Enabled = False
            ch_sumario.Enabled = False
            cbo_tipo.Enabled = False
        End If
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        TXT_CTA_ANA.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        ch_sumario.Checked = Boolean.Parse(dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        TIPO_DIST = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        Select Case TIPO_DIST
            Case "P"
                cbo_tipo.SelectedIndex = 0
            Case "S"
                cbo_tipo.SelectedIndex = 1
            Case "I"
                cbo_tipo.SelectedIndex = 2
            Case " "
                cbo_tipo.SelectedIndex = -1
        End Select
        cboUnidadNegocio.Text = dgw1.Item(7, dgw1.CurrentRow.Index).Value.ToString
        cboZona.Text = dgw1.Item(9, dgw1.CurrentRow.Index).Value.ToString
        chkSuspendido.Checked = Boolean.Parse(dgw1.Item(10, dgw1.CurrentRow.Index).Value)
    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (txt_cod.Text.Length = Decimal.Parse("5")) Then
            TXT_CTA_ANA.Enabled = True
        Else
            TXT_CTA_ANA.Enabled = False
        End If
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        TXT_CTA_ANA.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Private Sub ch_ca_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_ca.CheckedChanged
        If ch_ca.Checked Then
            btn_buscar.Enabled = True
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_cod_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cod.CheckedChanged
        If ch_cod.Checked Then
            dgw1.Sort(dgw1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_rs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_rs.CheckedChanged
        If ch_rs.Checked Then
            dgw1.Sort(dgw1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_AREA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AREA", SqlDbType.Char).Value = txt_cod.Text
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_AREA", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(0).Width = 50
            dgw1.Columns.Item(1).Width = 230
            dgw1.Columns.Item(2).Width = 80
            dgw1.Columns.Item(3).Width = 40
            dgw1.Columns.Item(4).Width = 30
            dgw1.Columns.Item(5).Width = 35
            dgw1.Columns.Item(7).Width = 120
            dgw1.Columns.Item(9).Width = 85
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(8).Visible = False
            ch_rs.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub LIMPIAR()
        ST_SUMARIO = "0"
        dgw1.Enabled = True
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        cbo_tipo.SelectedIndex = -1
        TXT_CTA_ANA.Clear()
        TXT_CTA_ANA.Enabled = False
        txt_cod.Enabled = True
        ch_sumario.Checked = False
        ch_sumario.Enabled = False
        cbo_tipo.Enabled = True
        cboUnidadNegocio.SelectedIndex = -1
        cboZona.SelectedIndex = -1
        chkSuspendido.Checked = False
    End Sub
    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_cod_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod.TextChanged
        Select Case txt_cod.Text.Length
            Case 3
                If VALIDAR_NIVEL(Strings.Mid(txt_cod.Text, 1, 1)) = False Then
                    MessageBox.Show("No existe el nivel anterior (1) ", "No existe Nivel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_cod.Clear()
                    txt_cod.Focus()
                End If
                Exit Select
            Case 5
                If VALIDAR_NIVEL(Strings.Mid(txt_cod.Text, 1, 3)) Then
                    TXT_CTA_ANA.Enabled = True
                    ch_sumario.Enabled = True
                    Exit Select
                End If
                MessageBox.Show("No existe el nivel anterior (3) ", "No existe Nivel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Text = Strings.Mid(txt_cod.Text, 1, 3)
                txt_cod.Focus()
                Exit Select
        End Select
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim I As Integer = 0
        Do While (I <= CONT)
            If (txt_cod.Text.ToLower = Strings.Mid((dgw1.Item(0, I).Value), 1, Strings.Len(txt_cod.Text)).ToLower) Then
                dgw1.CurrentCell = dgw1.Rows.Item(I).Cells.Item(0)
                Exit Do
            End If
            I += 1
        Loop
    End Sub
    Private Sub TXT_CTA_ANA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TXT_CTA_ANA.KeyDown
        If (e.KeyData = Keys.Down) Then
            btn_guardar.Focus()
            btn_modificar2.Focus()
        End If
        If (e.KeyData = Keys.Up) Then
            txt_desc2.Focus()
        End If
    End Sub
    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc2.Focus()
        End If
        If (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If (e.KeyData = Keys.Down) Then
            TXT_CTA_ANA.Focus()
        End If
        If (e.KeyData = Keys.Up) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_letra_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra.TextChanged
        Dim i As Integer
        If ch_cod.Checked Then
            txt_letra.Focus()
            Dim CONT As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra.Text.ToLower = Strings.Mid((dgw1.Item(0, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_rs.Checked Then
            txt_letra.Focus()
            Dim CONT As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT)
                If (txt_letra.Text.ToLower = Strings.Mid((dgw1.Item(1, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub
    Function VALIDAR_NIVEL(ByVal COD As Object) As Boolean
        Dim A As Boolean
        Try
            Dim PROG_01 As New SqlCommand("Verificar_Nivel_AREA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@cod_AREA", SqlDbType.VarChar).Value = (COD)
            con.Open()
            PROG_01.ExecuteNonQuery()
            A = PROG_01.ExecuteReader.HasRows
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If A = False Then
            Return False
        End If
        Return True
    End Function
    Function verificacion1(ByVal COD As Object) As String
        Dim cont As Integer
        Dim verificacion10 As String = ""
        Try
            Dim PROG_02 As New SqlCommand("VERIFICAR_NIVEL_AREA2", con)
            PROG_02.CommandType = CommandType.StoredProcedure
            PROG_02.Parameters.Add("@cod_AREA", SqlDbType.VarChar).Value = (COD)
            con.Open()
            PROG_02.ExecuteNonQuery()
            Dim Rs4 As SqlDataReader = PROG_02.ExecuteReader
            Do While Rs4.Read
                cont += 1
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If (cont = 1) Then
            Return "BIEN"
        End If
        If COD.ToString.Length = 3 Then
            Return "MAL5"
        End If
        Return "MAL3"
        con.Close()
        Return verificacion10
    End Function
End Class