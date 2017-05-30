Imports System.Data.SqlClient
Public Class CUENTAS
    Private accion, accion2, boton, cc, VARIABLE As String
    Private cc2 As String
    Private codigo As String
    Private control As String
    Private control2 As String
    Private cuenta02 As String
    Private d As String
    Private destino As String
    Private DT1 As New DataTable
    Private enlace As String
    Private f As Integer
    Private fila As Integer
    Private i As Integer
    Private INDICE As Integer
    Private instancia As String
    Private nivel As String
    Private obj As New Class1
    Private proyecto As String
    Private proyecto2 As String
    Private STATUS_ANA As String
    Private verificacion, verificacion03 As String
    Public Sub LIMPIAR()
        cbo_nivel.Enabled = True
        cc = "0"
        control = "0"
        proyecto = "0"
        txt_cod.Enabled = True
        txt_cod.Clear()
        txt_desc.Clear()
        gb2.Enabled = True
        co_tipo.SelectedIndex = -1
        txt_ana.SelectedIndex = -1
        c_cc.Checked = False
        c_proyecto.Checked = False
        BTN_GUARDAR.Visible = True
        BTN_MODIFICAR2.Visible = False
        Panel1.Visible = False
    End Sub

    Public Sub MOSTRAR_AUTO()
        dgw2.Rows.Clear()
        Try
            Dim PROG As New SqlCommand("MOSTRAR_AUTOMATICAS_CUENTA", con)
            PROG.CommandType = CommandType.StoredProcedure
            PROG.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            PROG.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            con.Open()
            PROG.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add(New Object() {(Rs3.GetValue(2)), Rs3.GetValue(1), Rs3.GetValue(3)})
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If (TabControl2.SelectedTab Is TabPage6) Then
            If (boton = "AUTO") Then
                boton = "AUTO2"
                lbl.Text = ""
                lbl_cuenta0.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
                lbl_cuenta.Text = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
                lbl.Visible = True
                Label3.Visible = True
                txt_enlace.Clear()
                txt_destino.Clear()
                dgw2.Visible = True
                txt_enlace.Enabled = True
                txt_destino.Enabled = True
                lbl_cuenta.Visible = True
                lbl_enlace.Visible = True
                lbl_destino.Visible = True
                btn_nuevo2.Visible = True
                btn_guardar2.Visible = True
                btn_eliminar2.Visible = True
            Else
                boton = "AUTOS"
                lbl.Text = "La cuenta tiene que ser de Nivel 8"
                lbl_cuenta0.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
                lbl_cuenta.Text = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
                lbl.Visible = True
                Label3.Visible = False
                txt_enlace.Clear()
                txt_destino.Clear()
                dgw2.Visible = False
                txt_enlace.Enabled = False
                txt_destino.Enabled = False
                lbl_cuenta.Visible = False
                lbl_enlace.Visible = False
                lbl_destino.Visible = False
                btn_nuevo2.Visible = False
                btn_guardar2.Visible = False
                btn_eliminar2.Visible = False
            End If
        ElseIf (TabControl2.SelectedTab Is TabPage5) Then
            If (boton = "NUEVO") Then
                boton = "DETALLES1"
            ElseIf (boton = "MODIFICAR") Then
                boton = "DETALLES2"
            Else
                boton = "DETALLES"
                LIMPIAR()
                CARGAR_DATOS()
                BTN_GUARDAR.Visible = False
                BTN_MODIFICAR2.Visible = False
                gb2.Enabled = False
            End If
        End If
    End Sub

    Private Sub txt_ana_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_ana.SelectedIndexChanged
        Select Case txt_ana.SelectedIndex
            Case 0
                STATUS_ANA = "C"

            Case 1
                STATUS_ANA = "P"

            Case 2
                STATUS_ANA = "B"

            Case 3
                STATUS_ANA = "O"

            Case 4
                STATUS_ANA = "N"

        End Select
    End Sub

    Private Sub txt_cod_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod.LostFocus
    End Sub

    Private Sub txt_cod_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod.TextChanged
        If (txt_cod.Text.Length = 3) Then
            Dim cuenta As String = Strings.Mid(txt_cod.Text, 1, 2)
            Dim C0 As Integer = 0
            If (boton = "DETALLES1") Then
                Try
                    Dim PROG_01 As New SqlCommand("VERIFICAR_NIVEL", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = cuenta
                    PROG_01.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    If (PROG_01.ExecuteReader.HasRows = False) Then
                        C0 = 0
                    Else
                        C0 = Integer.Parse("1")
                    End If
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
                If (C0 = 0) Then
                    MessageBox.Show(("No existe nivel 2 para la cuenta " & txt_cod.Text), "No existe Nivel")
                    txt_cod.Clear()
                End If
            End If
        ElseIf (((txt_cod.Text.Length = 8) Or (txt_cod.Text.Length > 3)) AndAlso (txt_cod.Text.Length >= txt_cod.MaxLength)) Then
            Dim cuenta As String = Strings.Mid(txt_cod.Text, 1, 3)
            Dim C0 As Integer = 0
            If (boton = "DETALLES1") Then
                Try
                    Dim PROG_01 As New SqlCommand("VERIFICAR_NIVEL", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = cuenta
                    PROG_01.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    If (PROG_01.ExecuteReader.HasRows = False) Then
                        C0 = 0
                    Else
                        C0 = Integer.Parse("1")
                    End If
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
                If (C0 = 0) Then
                    MessageBox.Show(("No existe nivel 3 para la cuenta " & txt_cod.Text), "No existe Nivel")
                    Panel1.Visible = False
                    txt_cod.Clear()
                Else
                    If (txt_cod.Text.Length = 8) Then
                        Panel1.Visible = True
                    End If
                    txt_desc.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txt_destino_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_destino.KeyDown
        If (e.KeyData = Keys.Return) Then
            If (dgw_cta2.RowCount = 0) Then
                MessageBox.Show("No existen cuentas aun.", "Advertencia")
            Else
                dgw_cta2.Sort(dgw_cta2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_destino.Text.ToLower = Strings.Mid((dgw_cta2.Item(0, i).Value), 1, Strings.Len(txt_destino.Text)).ToLower) Then
                        dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta2.CurrentCell = dgw_cta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta2.Visible = True
                dgw_cta2.Focus()
            End If
        End If
    End Sub

    Private Sub txt_destino_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_destino.TextChanged
        If (txt_destino.Text.Length = 8) Then
            lbl_destino.Visible = True
            lbl_destino.Text = OBJ.DESC_CUENTA(txt_destino.Text, AÑO)
        End If
    End Sub

    Private Sub txt_enlace_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_enlace.KeyDown
        instancia = "enlace"
        If (e.KeyData <> Keys.Return) Then
            If (e.KeyData = Keys.Escape) Then
                Panel_cta.Visible = False
                txt_enlace.Clear()
                txt_enlace.Focus()
            End If
        ElseIf (dgw_cta.RowCount = 0) Then
            MessageBox.Show("No existen cuentas  aun.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            Dim CONT As Integer = (dgw_cta.RowCount - 1)
            Dim i As Integer = 0
            Do While (i <= CONT)
                If (txt_enlace.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_enlace.Text)).ToLower) Then
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                    Exit Do
                End If
                dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                i += 1
            Loop
            Panel_cta.Visible = True
            dgw_cta.Focus()
        End If
    End Sub

    Private Sub txt_enlace_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_enlace.TextChanged
        If (txt_enlace.Text.Length = 8) Then
            lbl_enlace.Visible = True
            lbl_enlace.Text = OBJ.DESC_CUENTA(txt_enlace.Text, AÑO)
            con.Close()
        End If
    End Sub

    Private Sub txt_letra_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_letra.KeyDown
        If (e.KeyCode = Keys.Return) Then
            dgw1.Focus()
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
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(1)
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_rs.Checked Then
            txt_letra.Focus()
            Dim CONT0 As Integer = (dgw1.RowCount - 1)
            i = 0
            Do While (i <= CONT0)
                If (txt_letra.Text.ToLower = Strings.Mid((dgw1.Item(1, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(1)
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub

    Sub VERIFICACION1()
        Dim cont As Integer = 0
        Dim cuenta00 As String = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        If (cuenta00.Length = 8) Then
            verificacion = "bien1"
        Else
            Try
                Dim PROG_02 As New SqlCommand("VERIFICAR_NIVEL2", con)
                PROG_02.CommandType = CommandType.StoredProcedure
                PROG_02.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = cuenta00
                PROG_02.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
                con.Open()
                PROG_02.ExecuteNonQuery()
                Dim Rs4 As SqlDataReader = PROG_02.ExecuteReader
                Do While Rs4.Read
                    cont += 1
                Loop
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            If (cont = 1) Then
                verificacion = "bien1"
            Else
                verificacion = "mal1"
                If (cuenta00.Length = 3) Then
                    nivel = (8)
                Else
                    nivel = (3)
                End If
            End If
        End If
    End Sub
    Sub VERIFICACION3()
        Dim credito(14), credito_saldo(15) As Integer
        Dim s As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value
        '------------------------
        Dim i, j, c As Integer
        Try
            Dim PROG02 As New SqlCommand("VERIFICAR_SALDO_CUENTA2", con)
            PROG02.CommandType = CommandType.StoredProcedure
            PROG02.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value
            PROG02.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            con.Open()
            PROG02.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG02.ExecuteReader
            While Rs3.Read
                For i = 0 To 13
                    credito(i) = Rs3.GetValue(i)
                Next
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        '------------------------------
        For j = 0 To 13
            If credito(j) <> 0 Then
                credito_saldo(j) = j + 1
            End If
        Next
        For j = 0 To 13
            If credito_saldo(j) = 0 Then
            Else
                c = c + 1
            End If
        Next
        '----------------------------
        If c = 0 Then
            verificacion03 = "bien2"
        Else
            verificacion03 = "mal2"
            Dim mes As String
            mes = ""
            For j = 0 To 13
                Select Case credito_saldo(j)
                    Case 0
                    Case 1 : mes = mes + " Apertura "
                    Case 2 : mes = mes + " Enero "
                    Case 3 : mes = mes + " Febrero "
                    Case 4 : mes = mes + " Marzo "
                    Case 5 : mes = mes + " Abril "
                    Case 6 : mes = mes + " Mayo "
                    Case 7 : mes = mes + " Junio "
                    Case 8 : mes = mes + " Julio "
                    Case 9 : mes = mes + " Agosto "
                    Case 10 : mes = mes + " Setiembre "
                    Case 11 : mes = mes + " Octubre "
                    Case 12 : mes = mes + " Noviembre "
                    Case 13 : mes = mes + " Diciembre "
                    Case 14 : mes = mes + " Cierre "
                End Select
            Next
            MessageBox.Show("Existe movimiento de Crédito en el mes(es)" + vbCrLf + MES, "No se puede Eliminar ")
            Exit Sub
        End If
    End Sub
    Public Sub VERIFICACION2()
        Dim debito(14), debito_saldo(15) As Integer
        Dim s As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value
        '------------------------
        Dim i, j, c As Integer
        Try
            Dim PROG02 As New SqlCommand("VERIFICAR_SALDO_CUENTA", con)
            PROG02.CommandType = CommandType.StoredProcedure
            PROG02.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = dgw1.Item(0, dgw1.CurrentRow.Index).Value
            PROG02.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            con.Open()
            PROG02.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG02.ExecuteReader
            While Rs3.Read
                For i = 0 To 13
                    debito(i) = Rs3.GetValue(i)
                Next
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        '------------------------------
        For j = 0 To 13
            If debito(j) <> 0 Then
                debito_saldo(j) = j + 1
            End If
        Next
        For j = 0 To 13
            If debito_saldo(j) = 0 Then
            Else
                c = c + 1
            End If
        Next
        '----------------------------
        If c = 0 Then
            verificacion = "bien2"
        Else
            verificacion = "mal2"
            Dim mes As String
            mes = ""
            For j = 0 To 13
                Select Case debito_saldo(j)
                    Case 0
                    Case 1 : mes = mes + " Apertura "
                    Case 2 : mes = mes + " Enero "
                    Case 3 : mes = mes + " Febrero "
                    Case 4 : mes = mes + " Marzo "
                    Case 5 : mes = mes + " Abril "
                    Case 6 : mes = mes + " Mayo "
                    Case 7 : mes = mes + " Junio "
                    Case 8 : mes = mes + " Julio "
                    Case 9 : mes = mes + " Agosto "
                    Case 10 : mes = mes + " Setiembre "
                    Case 11 : mes = mes + " Octubre "
                    Case 12 : mes = mes + " Noviembre "
                    Case 13 : mes = mes + " Diciembre "
                    Case 14 : mes = mes + " Cierre "
                End Select
            Next
            MessageBox.Show("Existe movimiento de Debito en el mes(es)" + vbCrLf + mes, "No se puede Eliminar ")
            Exit Sub
        End If
    End Sub

    Public Function VERIFICAR_AUTO(ByVal cuenta0 As Object) As Boolean
        Dim OPCION As Integer
        Try
            Dim PROG03 As New SqlCommand("VERIFICAR_AUTOMATICAS", con)
            PROG03.CommandType = CommandType.StoredProcedure
            PROG03.Parameters.Add(New SqlParameter("@COD_AUTO", SqlDbType.VarChar)).Value = (cuenta0)
            con.Open()
            OPCION = Integer.PARSE(PROG03.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return (OPCION > 0)
    End Function

    Public Function VERIFICAR_CUENTA() As Boolean
        Dim C2 As Integer = 0
        Try
            Dim prog04 As New SqlCommand("VERIFICAR_CUENTA", con)
            prog04.CommandType = CommandType.StoredProcedure
            prog04.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = txt_cod.Text
            prog04.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            con.Open()
            C2 = Integer.Parse(prog04.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            MsgBox(ex.Message)
            con.Close()

        End Try
        Return (C2 = 0)
    End Function
    Private Sub BTN_AUTO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_AUTO.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        If (dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString.Length <> 8) Then
            MessageBox.Show("La Cuenta debe ser de Nivel 8", "La Cuenta no tiene Automaticas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf VERIFICAR_AUTO(dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString) = False Then
            MessageBox.Show("No existe automatica para esta cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            boton = "AUTO"
            lbl.Text = ""
            lbl_enlace.Text = ""
            lbl_destino.Text = ""
            Panel02.Visible = False
            lbl_cuenta0.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
            lbl_cuenta.Text = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
            MOSTRAR_AUTO()
            txt_enlace.Enabled = True
            txt_destino.Enabled = True
            TabControl2.SelectedTab = TabPage6
            btn_nuevo2.Focus()
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar.Click
        txt_letra.Focus()
        BTN_SGT.Enabled = True
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw1.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra.Text.ToLower = Strings.Mid(dgw1.Item(1, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(0)
                    fila = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub

    Private Sub btn_cancelar03_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar03.Click
        Panel02.Visible = False
        btn_nuevo2.Focus()
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = dgw2.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        Dim cuenta3 As String = lbl_cuenta0.Text
        Dim pos As String = (dgw2.Item(2, dgw2.CurrentRow.Index).Value)
        If (Decimal.Parse((CInt(MessageBox.Show(("Esta seguro de borrar la cuenta:  " & cuenta3), "Borrar Cuenta?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim PROG_02 As New SqlCommand("ELIMINAR_M_AUTOMATICAS", con)
                PROG_02.CommandType = CommandType.StoredProcedure
                PROG_02.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = cuenta3
                PROG_02.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
                PROG_02.Parameters.Add("@posicion", SqlDbType.VarChar).Value = pos
                con.Open()
                PROG_02.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            MOSTRAR_AUTO()
            txt_enlace.Clear()
            txt_destino.Clear()
        End If
    End Sub

    Private Sub BTN_MODIFICAR2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_MODIFICAR2.Click
        If (((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (co_tipo.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos")
        Else
            If (txt_ana.SelectedIndex = -1) Then
                STATUS_ANA = "N"
            End If
            Dim digitos As Integer = txt_cod.Text.Length
            Dim status_subnivel As String = ""
            'Select Case digitos
            '    Case 2
            '        nivel = (1)
            '        status_subnivel = "0"

            '    Case 3
            '        nivel = (2)
            '        status_subnivel = "0"

            '    Case 8
            '        nivel = (3)
            '        status_subnivel = "0"

            '    Case Else
            '        status_subnivel = "1"

            'End Select
            Select Case digitos
                Case 2
                    nivel = 1
                    status_subnivel = "0"
                Case 3
                    nivel = 2
                    status_subnivel = "0"
                Case 4
                    nivel = 3
                    status_subnivel = "1"
                Case 5
                    nivel = 4
                    status_subnivel = "1"
                Case 8
                    nivel = 5
                    status_subnivel = "0"
                Case Else
                    status_subnivel = "1"
            End Select
            cc = "0"
            control = "1"
            proyecto = "0"
            If c_cc.Checked Then
                cc = "1"
            End If
            If c_proyecto.Checked Then
                proyecto = "1"
            End If
            Dim tipo As String = ""
            If (co_tipo.SelectedIndex <> -1) Then
                tipo = obj.COD_TIPO_CUENTA(co_tipo.Text)
            End If
            Try
                Dim pro03 As New SqlCommand("MODIFICAR_CUENTA", con)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod.Text
                pro03.Parameters.Add("@AÑO ", SqlDbType.VarChar).Value = AÑO
                pro03.Parameters.Add("@DESC_CUENTA", SqlDbType.VarChar).Value = txt_desc.Text
                pro03.Parameters.Add("@TIPO_CUENTA", SqlDbType.Char).Value = tipo
                pro03.Parameters.Add("@STATUS_ANA", SqlDbType.Char).Value = STATUS_ANA
                pro03.Parameters.Add("@NIVEL", SqlDbType.Char).Value = nivel
                pro03.Parameters.Add("@STATUS_CC", SqlDbType.Char).Value = cc
                pro03.Parameters.Add("@STATUS_C", SqlDbType.Char).Value = control
                pro03.Parameters.Add("@STATUS_P", SqlDbType.Char).Value = proyecto
                pro03.Parameters.Add("@STATUS_SUBNIVEL", SqlDbType.Char).Value = status_subnivel
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            MessageBox.Show("La  Cuenta ha sido Modificada", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DATAGRID()
            dgw1.CurrentCell = dgw1.Rows.Item(INDICE).Cells.Item(0)
            TabControl2.SelectedTab = TabPage4
        End If
    End Sub

    Private Sub btn_nuevo2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo2.Click
        txt_enlace.Clear()
        txt_destino.Clear()
        txt_enlace.Focus()
        btn_guardar2.Enabled = True
        lbl_enlace.Text = ""
        lbl_destino.Text = ""
        Panel02.Visible = True
        txt_destino.Focus()
    End Sub

    Private Sub btn_salir1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir1.Click
        main(1) = 0
        Close()
    End Sub

    Private Sub BTN_SGT_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_SGT.Click
        txt_letra.Focus()
        Dim CONT As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = fila
        Do While (i <= CONT)
            Dim CONT0 As Integer = Strings.Len(dgw1.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= CONT0)
                If (txt_letra.Text.ToLower = Strings.Mid(dgw1.Item(1, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw1.CurrentCell = dgw1.Rows.Item(i).Cells.Item(0)
                    fila = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        LIMPIAR()
        TabControl2.SelectedTab = TabPage5
        cbo_nivel.Focus()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar2.Click
        If ((Strings.Trim(txt_enlace.Text) = "") Or (Strings.Trim(txt_destino.Text) = "")) Then
            MessageBox.Show("Debe ingresar la cuenta enlace y destino si la desea guardar", "Completar los datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                Dim PROG_02 As New SqlCommand("INSERTAR_M_AUTOMATICAS", con)
                PROG_02.CommandType = CommandType.StoredProcedure
                PROG_02.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = lbl_cuenta0.Text
                PROG_02.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
                PROG_02.Parameters.Add("@CUENTA_enlace", SqlDbType.VarChar).Value = txt_enlace.Text
                PROG_02.Parameters.Add("@CUENTA_destino", SqlDbType.VarChar).Value = txt_destino.Text
                con.Open()
                PROG_02.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            MessageBox.Show(("La cuenta: " & lbl_cuenta0.Text & " ha sido guardada"), "Exito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MOSTRAR_AUTO()
            Panel02.Visible = False
            btn_nuevo2.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return

        End Try
        boton = "MODIFICAR"
        LIMPIAR()
        INDICE = dgw1.CurrentRow.Index
        cbo_nivel.Enabled = False
        BTN_GUARDAR.Visible = False
        BTN_MODIFICAR2.Visible = True
        CARGAR_DATOS()
        txt_cod.Enabled = False
        TabControl2.SelectedTab = TabPage5
        txt_desc.Focus()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        TabControl2.SelectedTab = TabPage4
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        INDICE = dgw1.CurrentRow.Index
        Dim cuenta00 As String = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        Dim desc As String = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
        VERIFICACION1()
        If (verificacion = "mal1") Then
            MessageBox.Show(("Existe Nivel " & nivel), "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            verificacion = "verificacion"
            nivel = (0)
        Else
            verificacion = "verificacion"
            VERIFICACION2()
            VERIFICACION3()
            '----------------------------------------------------------------
            If (verificacion = "bien2" And VERIFICACION03 = "bien2") Then
                verificacion = "verificacion"
                If (Decimal.Parse((CInt(MessageBox.Show(("Borrar Cuenta:  " & desc), "Borrar Registro", MessageBoxButtons.YesNo)))) = 6) Then
                    Try
                        Dim pro04 As New SqlCommand("ELIMINAR_CUENTA", con)
                        pro04.CommandType = CommandType.StoredProcedure
                        pro04.Parameters.Add("@cod_cuenta", SqlDbType.VarChar).Value = cuenta00
                        pro04.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
                        con.Open()
                        pro04.ExecuteNonQuery()
                        con.Close()
                        MessageBox.Show("La cuenta ha sido eliminada", "Cuenta Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Catch ex As Exception
                        con.Close()
                        MsgBox(ex.Message)
                    End Try
                    DATAGRID()
                    'dgw1.CurrentCell = dgw1.Rows.Item(INDICE).Cells.Item(0)
                End If
            End If
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_GUARDAR.Click
        If (((txt_cod.Text.ToString.Trim = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (co_tipo.SelectedIndex = -1)) Then
            MessageBox.Show("Debe ingresar todos los datos")
        Else
            If (txt_ana.SelectedIndex = -1) Then
                STATUS_ANA = "N"
            End If
            Dim digitos As Integer = txt_cod.Text.Length
            Dim status_subnivel As String = ""
            Select Case digitos
                Case 2
                    nivel = 1
                    status_subnivel = "0"
                Case 3
                    nivel = 2
                    status_subnivel = "0"
                Case 4
                    nivel = 3
                    status_subnivel = "1"
                Case 5
                    nivel = 4
                    status_subnivel = "1"
                Case 8
                    nivel = 5
                    status_subnivel = "0"
                Case Else
                    status_subnivel = "1"
            End Select
            Dim i0 As Integer = 1
            Dim cont0 As Integer = (txt_cod.MaxLength - txt_cod.Text.Trim.Length)
            Dim str As String = txt_cod.Text.Trim
            i0 = 1
            Do While (i0 <= cont0)
                str = (str & "0")
                i0 += 1
            Loop
            txt_cod.Text = str
            cc = "0"
            control = "1"
            proyecto = "0"
            If c_cc.Checked Then
                cc = "1"
            End If
            If c_proyecto.Checked Then
                proyecto = "1"
            End If
            Dim tipo As String = ""
            If (co_tipo.SelectedIndex <> -1) Then
                tipo = obj.COD_TIPO_CUENTA(co_tipo.Text)
            End If
            If VERIFICAR_CUENTA = False Then
                MessageBox.Show("El Código de Cuenta ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                VARIABLE = txt_cod.Text
                Try
                    Dim pro03 As New SqlCommand("INSERTAR_CUENTA", con)
                    pro03.CommandType = CommandType.StoredProcedure
                    pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod.Text
                    pro03.Parameters.Add("@AÑO ", SqlDbType.VarChar).Value = AÑO
                    pro03.Parameters.Add("@DESC_CUENTA", SqlDbType.VarChar).Value = txt_desc.Text
                    pro03.Parameters.Add("@TIPO_CUENTA", SqlDbType.Char).Value = tipo
                    pro03.Parameters.Add("@STATUS_ANA", SqlDbType.Char).Value = STATUS_ANA
                    pro03.Parameters.Add("@NIVEL", SqlDbType.Char).Value = nivel
                    pro03.Parameters.Add("@STATUS_CC", SqlDbType.Char).Value = cc
                    pro03.Parameters.Add("@STATUS_C", SqlDbType.Char).Value = control
                    pro03.Parameters.Add("@STATUS_P", SqlDbType.Char).Value = proyecto
                    pro03.Parameters.Add("@STATUS_SUBNIVEL", SqlDbType.Char).Value = status_subnivel
                    con.Open()
                    pro03.ExecuteNonQuery()
                    MessageBox.Show("La nueva cuenta ha sido registrada", "Guardar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    con.Close()
                    DATAGRID()
                    LIMPIAR()
                    txt_cod.Focus()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                cbo_nivel.Focus()
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        LIMPIAR()
        FOCO_NUEVO_REG()
        TabControl2.SelectedTab = TabPage4
    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        Dim CTA_FOCO As String = VARIABLE
        For I = 0 To CONT
            If CTA_FOCO = dgw1.Item(0, I).Value.ToString.ToLower Then
                dgw1.CurrentCell = (dgw1.Rows.Item(I).Cells.Item(0))
                Exit Sub
            End If
        Next
    End Sub

    Private Sub c_cc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles c_cc.KeyDown
        If (e.KeyData = Keys.Return) Then
            If c_cc.Checked Then
                c_cc.Checked = False
            Else
                c_cc.Checked = True
            End If
        End If
    End Sub

    Private Sub c_proyecto_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles c_proyecto.KeyDown
        If (e.KeyData = Keys.Return) Then
            If c_proyecto.Checked Then
                c_proyecto.Checked = False
            Else
                c_proyecto.Checked = True
            End If
        End If
    End Sub

    Public Sub CARGAR_CUENTAS()
        Try
            Dim pro As New SqlCommand("CARGAR_CUENTAS_AÑO", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw_cta.DataSource = dt
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(0).Width = 80
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Try
            Dim pro As New SqlCommand("CARGAR_CUENTAS_AÑO", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw_cta2.DataSource = dt
            dgw_cta2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta2.Columns.Item(0).Width = 80
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Public Sub CARGAR_DATOS()
        txt_cod.Text = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        txt_desc.Text = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
        co_tipo.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        STATUS_ANA = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        Select Case STATUS_ANA
            Case "C"
                txt_ana.Text = "Cuentas x Cobrar"

            Case "P"
                txt_ana.Text = "Cuentas x Pagar"

            Case "B"
                txt_ana.Text = "Bancos"

            Case "N"
                txt_ana.Text = "Ninguno"

            Case "O"
                txt_ana.Text = "Otras Cuentas"

        End Select
        If (txt_cod.Text.Length = 8) Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
        cc2 = (dgw1.Item(5, dgw1.CurrentRow.Index).Value)
        proyecto2 = (dgw1.Item(6, dgw1.CurrentRow.Index).Value)
        c_cc.Checked = False
        c_proyecto.Checked = False
        If (cc2 = "True") Then
            c_cc.Checked = True
        End If
        If (proyecto2 = "True") Then
            c_proyecto.Checked = True
        End If
        nivel = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        cbo_nivel.Text = obj.DESC_NIVEL_DIGITOS(txt_cod.Text.Length)
    End Sub

    Public Sub CARGAR_NIVEL()
        Try
            Dim PROG_01 As New SqlCommand("CBO_NIVEL", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_nivel.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub CARGAR_TIPOS()
        Try
            co_tipo.Items.Clear()
            Dim PROG_01 As New SqlCommand("CBO_TIPO_CUENTA", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                co_tipo.Items.Add(Rs3.GetString(0))
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
            nivel = obj.COD_NIVEL(cbo_nivel.Text)
            txt_cod.MaxLength = Integer.Parse(obj.HALLAR_NRO_DIGITOS(nivel))
        End If
    End Sub

    Private Sub ch_ca_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_ca.CheckedChanged
        If ch_ca.Checked Then
            btn_buscar.Enabled = True
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub

    Private Sub ch_cod_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cod.CheckedChanged
        If ch_cod.Checked Then
            dgw1.Sort(dgw1.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub

    Private Sub ch_rs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_rs.CheckedChanged
        If ch_rs.Checked Then
            dgw1.Sort(dgw1.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub

    Private Sub Cuentasvb_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cuentasvb_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CARGAR_TIPOS()
        CARGAR_CUENTAS()
        CARGAR_NIVEL()
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        btn_nuevo.Select()
    End Sub

    Sub DATAGRID()
        Try
            Dim pro As New SqlCommand("MOSTRAR_CUENTAS", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("f")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(7).Visible = False
            dgw1.Columns.Item(0).Width = 70
            dgw1.Columns.Item(1).Width = 230
            dgw1.Columns.Item(2).Width = 100
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_enlace.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
            lbl_enlace.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
            If (txt_enlace.Text.Length <> 8) Then
                MessageBox.Show("El cuenta tiene que ser nivel 8", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ElseIf (txt_enlace.Text = txt_destino.Text) Then
                MessageBox.Show("El cuenta de enlace y destino no pueden ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                Panel_cta.Visible = False
                kl2.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta.Visible = False
            txt_enlace.Clear()
            lbl_enlace.Text = ""
            txt_enlace.Focus()
        End If
    End Sub

    Private Sub dgw_cta2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_destino.Text = (dgw_cta2.Item(0, dgw_cta2.CurrentRow.Index).Value)
            lbl_destino.Text = (dgw_cta2.Item(1, dgw_cta2.CurrentRow.Index).Value)
            If (txt_destino.Text.Length <> 8) Then
                MessageBox.Show("El cuenta tiene que ser nivel 8", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ElseIf (txt_enlace.Text = txt_destino.Text) Then
                MessageBox.Show("El cuenta de enlace y destino no pueden ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                Panel_cta2.Visible = False
                kl1.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            Panel_cta2.Visible = False
            txt_destino.Clear()
            lbl_destino.Text = ""
            txt_destino.Focus()
        End If
    End Sub

    Private Sub dgw2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dgw2.Click
        If (dgw2.RowCount <> 0) Then
            txt_enlace.Text = (dgw2.Item(1, dgw2.CurrentRow.Index).Value)
            txt_destino.Text = (dgw2.Item(2, dgw2.CurrentRow.Index).Value)
            txt_enlace.Focus()
            btn_guardar2.Enabled = False
        End If
    End Sub
End Class