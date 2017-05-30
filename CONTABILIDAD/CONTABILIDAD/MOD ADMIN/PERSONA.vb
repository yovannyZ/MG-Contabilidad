Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class PERSONA
    Dim BOTON, COD_PRO, COD_DIST, COD_PAIS, COD_DEP, COD_CAT, COD_CLASE As String
    Dim INDICE, fila As Integer
    Dim E1, M, N As Boolean
    Dim OBJ As New Class1
    Dim VARIABLE As String
    Dim TIPO_DIR, TIPO_DOC, TIPO_FONO, TIPO_PER, ST_CONTRIBUYENTE, ST_RETENEDOR, ST_PERCEPTOR, ST_SUSPENDIDO As String
    Private Sub btn_agregar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_agregar1.Click
        btn_guardar2.Visible = True
        btn_mod1.Visible = False
        Panel1.Visible = True
        LIMPIAR_CONTACTO()
        txt_desc_cont.Focus()
    End Sub
    Private Sub btn_agregar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_agregar2.Click
        LIMPIAR_FONO()
        btn_guardar3.Visible = True
        btn_mod2.Visible = False
        Panel2.Visible = True
        cbo_tipo_fono.Focus()
    End Sub
    Private Sub btn_agregar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_agregar3.Click
        LIMPIAR_DIRECCION()
        btn_guardar4.Visible = True
        btn_mod3.Visible = False
        Panel3.Visible = True
        cbo_pais.Focus()
    End Sub
    Private Sub btn_agregar4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_agregar4.Click
        LIMPIAR_CLASE()
        btn_guardar5.Visible = True
        btn_mod4.Visible = False
        Panel4.Visible = True
        cbo_clase.Focus()
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar.Click
        txt_letra.Focus()
        btn_sgt.Enabled = True
        'Dim VB$t_i4$L0 As Integer = (dgw.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(dgw.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= Len(dgw.Item(1, i).Value.ToString))
                If (txt_letra.Text.ToLower = Strings.Mid(dgw.Item(1, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw.CurrentCell = (dgw.Rows.Item(i).Cells.Item(0))
                    fila = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        FOCO_NUEVO_REG()
        TabControl1.SelectedTab = (TabPage1)
    End Sub
    Sub FOCO_NUEVO_REG()
        Dim I, CONT As Integer
        CONT = dgw.RowCount - 1
        Dim COD_ART As String = VARIABLE
        For I = 0 To CONT
            If COD_ART = dgw.Item(0, I).Value.ToString.ToLower Then
                dgw.CurrentCell = (dgw.Rows.Item(I).Cells.Item(0))
                Exit Sub
            End If
        Next
    End Sub
    Private Sub btn_cancelar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar2.Click
        Panel1.Visible = False
    End Sub
    Private Sub btn_cancelar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar3.Click
        Panel2.Visible = False
    End Sub
    Private Sub btn_cancelar4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar4.Click
        Panel3.Visible = False
    End Sub
    Private Sub btn_cancelar5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar5.Click
        Panel4.Visible = False
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim cod As String = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        If (VERIFICAR_ELIM_PERSONA(cod) > 0) Then
            MessageBox.Show("No se puede eliminar , la Persona tiene Movimientos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If VERIFICAR_REGISTRO_MOV(cod) > 0 Then
                MessageBox.Show("No se puede eliminar , la Persona tiene Movimientos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If ((MessageBox.Show(("Eliminar: " & cod & " " & dgw.Item(1, dgw.CurrentRow.Index).Value.ToString), "ESTA SEGURO DE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
                    Try
                        Dim cmd As New SqlCommand("ELIMINAR_PERSONA", con)
                        cmd.CommandType = (CommandType.StoredProcedure)
                        cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = cod
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
            DATAGRID()
            End If
    End Sub
    Private Function VERIFICAR_REGISTRO_MOV(ByVal COD_PER As String) As Integer
        Dim REG_COMPRAS, REG_VENTAS, RSLT As Integer
        REG_COMPRAS = 0 : REG_VENTAS = 0 : RSLT = 0
        con.Open()
        Dim CMD As New SqlCommand("SELECT DISTINCT COD_CLASE FROM PERSONA_CLASE WHERE COD_PER=@COD_PER", con)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
        Dim DR As SqlDataReader = CMD.ExecuteReader
        While DR.Read
            If DR.GetValue(0) = 1 Then
                REG_COMPRAS = 1
            ElseIf DR.GetValue(0) = 2 Then
                REG_VENTAS = 1
            End If
        End While
        CMD.Dispose()
        DR.Close()
        If REG_COMPRAS = 1 Then
            CMD = New SqlCommand("VERIFICAR_REGISTRO_MOV_PER", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_REG", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            REG_COMPRAS = CMD.ExecuteScalar
            CMD.Dispose()
        End If
        If REG_VENTAS = 1 Then
            CMD = New SqlCommand("VERIFICAR_REGISTRO_MOV_PER", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_REG", SqlDbType.Char).Value = "1"
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
            REG_VENTAS = CMD.ExecuteScalar
            CMD.Dispose()
        End If
        con.Close()
        RSLT = REG_COMPRAS + REG_VENTAS
        Return RSLT
    End Function
    Private Sub btn_eliminar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = (dgw1.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((MessageBox.Show("ELIMINAR REGISTRO", "¿ESTA SEGURO DE?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
            dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index)
        End If
    End Sub
    Private Sub btn_eliminar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar3.Click
        Try
            Dim i As Integer = (DGW2.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((MessageBox.Show("ELIMINAR REGISTRO", "¿ESTA SEGURO DE?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
            DGW2.Rows.RemoveAt(DGW2.CurrentRow.Index)
        End If
    End Sub
    Private Sub btn_eliminar4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar4.Click
        Try
            Dim i As Integer = (DGW3.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((MessageBox.Show("ELIMINAR REGISTRO", "¿ESTA SEGURO DE?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
            DGW3.Rows.RemoveAt(DGW3.CurrentRow.Index)
        End If
    End Sub
    Private Sub btn_eliminar5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar5.Click
        Try
            Dim i As Integer = (DGW4.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((MessageBox.Show("ELIMINAR REGISTRO", "¿ESTA SEGURO DE?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
            DGW4.Rows.RemoveAt(DGW4.CurrentRow.Index)
        End If
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click

        Select Case cbo_tipo_doc.Text
            Case "REGISTRO UNICO CONTRIBUYENTE"
                If txt_nro_doc.Text.Trim.Length <> 11 Then
                    MessageBox.Show("Ingrese un N° de Doc. de 11 digitos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_nro_doc.Focus()
                    Exit Sub
                End If
            Case "DOCUMENTO NACIONAL IDENTIDAD"
                If txt_nro_doc.Text.Trim = "" OrElse txt_nro_doc.TextLength = 8 Then
                Else
                    MessageBox.Show("Ingrese un N° de Doc. de 8 digitos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_nro_doc.Focus()
                    Exit Sub
                End If
        End Select

        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_tipo.SelectedIndex = -1)) Or (cbo_tipo_doc.SelectedIndex = -1)) Then
            MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
        If (verificar_persona > 0) Then
            MessageBox.Show("El codigo de Persona ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
            Exit Sub
        End If
        'Else
        '----------------
        If txt_nro_doc.Text <> "" Then
            If VERIFICAR_NRO_RUC() > 0 Then
                Dim rspta As String = MessageBox.Show("Si para Grabar, No Cancelar, ya existe el Nº de Doc.", "El Nº de Doc. ya existe", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If rspta = vbYes Then
                    GRABANDO()
                ElseIf rspta = vbNo Then
                    Exit Sub
                End If
            Else
                GRABANDO()
            End If
        Else
            GRABANDO()
        End If
    End Sub
    Function VERIFICAR_NRO_RUC()
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_NRO_DOC_PERSONA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub GRABANDO()
        VARIABLE = txt_cod.Text
        TIPO_DOC = OBJ.COD_TIPO_DOC_PER(cbo_tipo_doc.Text)
        If ch_retenedor.Checked = True Then ST_RETENEDOR = "1" Else ST_RETENEDOR = "0"
        If ch_contribuyente.Checked = True Then ST_CONTRIBUYENTE = "1" Else ST_CONTRIBUYENTE = "0"
        If chkPerceptor.Checked = True Then ST_PERCEPTOR = "1" Else ST_PERCEPTOR = "0"
        If chkSuspendido.Checked = True Then ST_SUSPENDIDO = "1" Else ST_SUSPENDIDO = "0"
        Try
            Dim CMD As New SqlCommand("INSERTAR_PERSONA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            CMD.Parameters.Add("@TIPO_PER", SqlDbType.Char).Value = (TIPO_PER)
            CMD.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = (txt_desc.Text)
            CMD.Parameters.Add("@NOM", SqlDbType.VarChar).Value = (txt_nom.Text)
            CMD.Parameters.Add("@PAT", SqlDbType.VarChar).Value = (txt_pat.Text)
            CMD.Parameters.Add("@MAT", SqlDbType.VarChar).Value = (txt_mat.Text)
            CMD.Parameters.Add("@NOM_COMERCIAL", SqlDbType.VarChar).Value = (txt_nc.Text)
            CMD.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = (txt_mail.Text)
            CMD.Parameters.Add("@COD_TIPO_DOC", SqlDbType.Char).Value = (TIPO_DOC)
            CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = (txt_nro_doc.Text)
            CMD.Parameters.Add("@NOM_AVAL", SqlDbType.VarChar).Value = (txt_desc_aval.Text)
            CMD.Parameters.Add("@NRO_DOC_AVAL", SqlDbType.VarChar).Value = (txt_doc_aval.Text)
            CMD.Parameters.Add("@DIR_AVAL", SqlDbType.VarChar).Value = txt_dir_aval.Text
            CMD.Parameters.Add("@FONO_AVAL", SqlDbType.VarChar).Value = txt_fono_aval.Text
            CMD.Parameters.Add("@ST_CONTRIBUYENTE", SqlDbType.Char).Value = ST_CONTRIBUYENTE
            CMD.Parameters.Add("@ST_RETENEDOR", SqlDbType.Char).Value = ST_RETENEDOR
            CMD.Parameters.Add("@ST_PERCEPTOR", SqlDbType.Char).Value = ST_PERCEPTOR
            CMD.Parameters.Add("@ST_SUSPENDIDO", SqlDbType.Char).Value = ST_SUSPENDIDO
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            INSERTAR_DETALLES()
            MessageBox.Show("La persona se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LIMPIAR_CABECERA()
            SGT_CODIGO()
            txt_cod.Focus()
        Catch ex As Exception
            MessageBox.Show("Por favor Vuelva a Intentarlo", "FALLO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            con.Close()
            MsgBox(ex.Message)
        End Try
        DATAGRID()

    End Sub
    Private Sub btn_guardar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar2.Click
        If (Strings.Trim(txt_desc_cont.Text) = "") Then
            MessageBox.Show("Ingrese el Nombre", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc_cont.Focus()
        Else
            dgw1.Rows.Add((dgw1.Rows.Count + 1).ToString("00"), txt_desc_cont.Text, txt_mail_cont.Text, txt_obs_cont.Text, IIf(chkCorreoElectronico.Checked, "1", "0"))
            Panel1.Visible = False
            txt_mail.Focus()
        End If
    End Sub
    Private Sub btn_guardar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar3.Click
        If ((Strings.Trim(txt_nro_fono.Text) = "") Or (cbo_tipo_fono.SelectedIndex = -1)) Then
            MessageBox.Show("FALTAN DATOS", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_fono.Focus()
        Else
            TIPO_FONO = OBJ.COD_FONO(cbo_tipo_fono.Text)
            DGW2.Rows.Add((DGW2.RowCount + 1), TIPO_FONO, cbo_tipo_fono.Text, txt_nro_fono.Text)
            Panel2.Visible = False
            txt_mail.Focus()
        End If
    End Sub
    Private Sub btn_guardar4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar4.Click
        If (cbo_tipo_dir.SelectedIndex = -1) Then
            MessageBox.Show("Eliga un tipo de Dirección", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cbo_pais.SelectedIndex = -1) Then
            MessageBox.Show("Eliga un país", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Strings.Trim(txt_dir.Text) = "") Then
            MessageBox.Show("Ingrese una Dirección", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            COD_PAIS = OBJ.COD_PAIS(cbo_pais.Text)
            TIPO_DIR = OBJ.COD_TIPO_DIRECCION(cbo_tipo_dir.Text)
            COD_DEP = OBJ.COD_DEP(cbo_dep.Text)
            COD_PRO = OBJ.COD_PRO(cbo_pro.Text, COD_DEP)
            COD_DIST = OBJ.COD_DIST(cbo_dist.Text, COD_PRO, COD_DEP)
            If validar_direccion = False Then
                MessageBox.Show("Ese tipo de dirección ya existe", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_tipo_dir.Focus()
            Else
                Dim DESC_DEP As String = ""
                Dim DESC_PRO As String = ""
                Dim DESC_DIST As String = ""
                If (cbo_dep.SelectedIndex = -1) Then
                    DESC_DEP = " "
                Else
                    DESC_DEP = cbo_dep.Text
                End If
                If (cbo_pro.SelectedIndex = -1) Then
                    DESC_PRO = " "
                Else
                    DESC_PRO = cbo_pro.Text
                End If
                If (cbo_dist.SelectedIndex = -1) Then
                    DESC_DIST = " "
                Else
                    DESC_DIST = cbo_dist.Text
                End If
                DGW3.Rows.Add(TIPO_DIR, cbo_tipo_dir.Text, txt_dir.Text, txt_ref.Text, COD_PAIS, cbo_pais.Text, COD_DEP, DESC_DEP, COD_PRO, DESC_PRO, COD_DIST, DESC_DIST)
                Panel3.Visible = False
                txt_mail.Focus()
            End If
        End If
    End Sub
    Private Sub btn_guardar5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar5.Click
        If (cbo_clase.SelectedIndex = -1) Then
            MessageBox.Show("Eliga una Clase", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cbo_cat.SelectedIndex = -1) Then
            MessageBox.Show("Eliga una Categoría", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            COD_CLASE = OBJ.COD_CLASE_PER(cbo_clase.Text)
            COD_CAT = OBJ.COD_CAT_PER(cbo_cat.Text)
            If VALIDAR_CLASE_PER() = False Then
                MessageBox.Show("Ese tipo de Clase - Categoría ya existe", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_clase.Focus()
            Else
                DGW4.Rows.Add(COD_CLASE, cbo_clase.Text, COD_CAT, cbo_cat.Text, txt_linea.Text)
                Panel4.Visible = False
                txt_mail.Focus()
            End If
        End If
    End Sub
    Private Sub btn_mod1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod1.Click
        If (Strings.Trim(txt_desc_cont.Text) = "") Then
            MessageBox.Show("Ingrese el Nombre", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc_cont.Focus()
        Else
            Dim FILA As Integer = (item1.Text)
            dgw1.Item(1, FILA).Value = (txt_desc_cont.Text)
            dgw1.Item(2, FILA).Value = (txt_mail_cont.Text)
            dgw1.Item(3, FILA).Value = (txt_obs_cont.Text)
            dgw1.Item(4, FILA).Value = IIf(chkCorreoElectronico.Checked, "1", "0")
            Panel1.Visible = False
        End If
    End Sub
    Private Sub btn_mod2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod2.Click
        If ((Strings.Trim(txt_nro_fono.Text) = "") Or (cbo_tipo_fono.SelectedIndex = -1)) Then
            MessageBox.Show("FALTAN DATOS", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_tipo_fono.Focus()
        Else
            TIPO_FONO = OBJ.COD_FONO(cbo_tipo_fono.Text)
            Dim FILA As Integer = (ITEM2.Text)
            DGW2.Item(1, FILA).Value = (TIPO_FONO)
            DGW2.Item(2, FILA).Value = (cbo_tipo_fono.Text)
            DGW2.Item(3, FILA).Value = (txt_nro_fono.Text)
            Panel2.Visible = False
        End If
    End Sub
    Private Sub btn_mod3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod3.Click
        If (cbo_tipo_dir.SelectedIndex = -1) Then
            MessageBox.Show("Eliga un tipo de Dirección", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (cbo_pais.SelectedIndex = -1) Then
            MessageBox.Show("Eliga un país", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Strings.Trim(txt_dir.Text) = "") Then
            MessageBox.Show("Ingrese una Dirección", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim DESC_DEP As String
            Dim DESC_DIST As String
            Dim DESC_PRO As String
            COD_PAIS = OBJ.COD_PAIS(cbo_pais.Text)
            If (cbo_dep.SelectedIndex = -1) Then
                DESC_DEP = " "
            Else
                DESC_DEP = cbo_dep.Text
            End If
            If (cbo_pro.SelectedIndex = -1) Then
                DESC_PRO = " "
            Else
                DESC_PRO = cbo_pro.Text
            End If
            If (cbo_dist.SelectedIndex = -1) Then
                DESC_DIST = " "
            Else
                DESC_DIST = cbo_dist.Text
            End If
            COD_DIST = OBJ.COD_DIST(cbo_dist.Text, COD_PRO, COD_DEP)
            Dim FILA As Integer = (item3.Text)
            DGW3.Item(1, FILA).Value = cbo_tipo_dir.Text
            DGW3.Item(2, FILA).Value = txt_dir.Text
            DGW3.Item(3, FILA).Value = txt_ref.Text
            DGW3.Item(4, FILA).Value = COD_PAIS
            DGW3.Item(5, FILA).Value = cbo_pais.Text
            DGW3.Item(6, FILA).Value = COD_DEP
            DGW3.Item(7, FILA).Value = DESC_DEP
            DGW3.Item(8, FILA).Value = COD_PRO
            DGW3.Item(9, FILA).Value = DESC_PRO
            DGW3.Item(10, FILA).Value = COD_DIST
            DGW3.Item(11, FILA).Value = DESC_DIST
            Panel3.Visible = False
        End If
    End Sub
    Private Sub btn_mod4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_mod4.Click
        If (cbo_clase.SelectedIndex = -1) Then
            MessageBox.Show("Eliga una Clase", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            COD_CAT = OBJ.COD_CAT_PER(cbo_cat.Text)
            Dim DESC_CAT As String = ""
            If (cbo_cat.SelectedIndex = -1) Then
                DESC_CAT = " "
            Else
                DESC_CAT = cbo_cat.Text
            End If
            Dim FILA As Integer = ITEM4.Text
            DGW4.Item(1, FILA).Value = cbo_clase.Text
            DGW4.Item(2, FILA).Value = COD_CAT
            DGW4.Item(3, FILA).Value = DESC_CAT
            DGW4.Item(4, FILA).Value = txt_linea.Text
            Panel4.Visible = False
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        BOTON = "MODIFICAR"
        INDICE = dgw.CurrentRow.Index

        LIMPIAR_CABECERA()
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        CARGAR_CABECERA()
        CARGAR_DETALLES()
        txt_cod.ReadOnly = True
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ch_retenedor.Checked = True Then ST_RETENEDOR = "1" Else ST_RETENEDOR = "0"
        If ch_contribuyente.Checked = True Then ST_CONTRIBUYENTE = "1" Else ST_CONTRIBUYENTE = "0"
        If chkPerceptor.Checked = True Then ST_PERCEPTOR = "1" Else ST_PERCEPTOR = "0"
        If chkSuspendido.Checked = True Then ST_SUSPENDIDO = "1" Else ST_SUSPENDIDO = "0"
        If ((((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Or (cbo_tipo.SelectedIndex = -1)) Or (cbo_tipo_doc.SelectedIndex = -1)) Then
            MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        Else
            VARIABLE = txt_cod.Text
            TIPO_DOC = OBJ.COD_TIPO_DOC_PER(cbo_tipo_doc.Text)
            Try
                Dim CMD As New SqlCommand("MODIFICAR_PERSONA", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@TIPO_PER", SqlDbType.Char).Value = TIPO_PER
                CMD.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@NOM", SqlDbType.VarChar).Value = txt_nom.Text
                CMD.Parameters.Add("@PAT", SqlDbType.VarChar).Value = txt_pat.Text
                CMD.Parameters.Add("@MAT", SqlDbType.VarChar).Value = txt_mat.Text
                CMD.Parameters.Add("@NOM_COMERCIAL", SqlDbType.VarChar).Value = txt_nc.Text
                CMD.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = txt_mail.Text
                CMD.Parameters.Add("@COD_TIPO_DOC", SqlDbType.Char).Value = TIPO_DOC
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txt_nro_doc.Text
                CMD.Parameters.Add("@NOM_AVAL", SqlDbType.VarChar).Value = txt_desc_aval.Text
                CMD.Parameters.Add("@NRO_DOC_AVAL", SqlDbType.VarChar).Value = txt_doc_aval.Text
                CMD.Parameters.Add("@DIR_AVAL", SqlDbType.VarChar).Value = txt_dir_aval.Text
                CMD.Parameters.Add("@FONO_AVAL", SqlDbType.VarChar).Value = txt_fono_aval.Text
                CMD.Parameters.Add("@ST_CONTRIBUYENTE", SqlDbType.Char).Value = ST_CONTRIBUYENTE
                CMD.Parameters.Add("@ST_RETENEDOR", SqlDbType.Char).Value = ST_RETENEDOR
                CMD.Parameters.Add("@ST_PERCEPTOR", SqlDbType.Char).Value = ST_PERCEPTOR
                CMD.Parameters.Add("@ST_SUSPENDIDO", SqlDbType.Char).Value = ST_SUSPENDIDO
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                INSERTAR_DETALLES()
                MessageBox.Show("La persona se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
            Catch ex As Exception
                MessageBox.Show("Por favor Vuelva a Intentarlo", "FALLO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                con.Close()
                MsgBox(ex.Message)
            End Try
            DATAGRID()
            FOCO_NUEVO_REG()
        End If
    End Sub
    Private Sub btn_modificar3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar3.Click
        Try
            Dim i As Integer = (dgw1.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        btn_guardar2.Visible = False
        btn_mod1.Visible = True
        item1.Text = dgw1.CurrentRow.Index.ToString
        LIMPIAR_CONTACTO()
        CARGAR_CONTACTO()
        Panel1.Visible = True
        txt_desc_cont.Focus()
    End Sub
    Private Sub btn_modificar4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar4.Click
        Try
            Dim i As Integer = (DGW2.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        ITEM2.Text = DGW2.CurrentRow.Index.ToString
        LIMPIAR_FONO()
        CARGAR_FONO()
        btn_guardar3.Visible = False
        btn_mod2.Visible = True
        Panel2.Visible = True
        cbo_tipo_fono.Focus()
    End Sub
    Private Sub btn_modificar5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar5.Click
        Try
            Dim i As Integer = (DGW3.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        item3.Text = DGW3.CurrentRow.Index.ToString
        LIMPIAR_DIRECCION()
        CARGAR_DIRECCION0()
        btn_guardar4.Visible = False
        btn_mod3.Visible = True
        Panel3.Visible = True
        cbo_tipo_dir.Enabled = False
        cbo_pais.Focus()
    End Sub
    Private Sub btn_modificar6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar6.Click
        Try
            Dim i As Integer = (DGW4.CurrentRow.Index.ToString)
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        ITEM4.Text = DGW4.CurrentRow.Index.ToString
        LIMPIAR_CLASE()
        CARGAR_CLASE0()
        btn_guardar5.Visible = False
        btn_mod4.Visible = True
        Panel4.Visible = True
        cbo_clase.Enabled = False
        cbo_cat.Focus()
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        BOTON = "NUEVO"
        LIMPIAR_CABECERA()
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        SGT_CODIGO()
        TabControl1.SelectedTab = (TabPage2)
        txt_cod.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(1) = 0
        Close()
    End Sub
    Private Sub btn_sgt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt.Click
        'Dim VB$t_i4$L0 As Integer = (dgw.RowCount - 1)
        Dim i As Integer = fila
        Do While (i <= (dgw.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(dgw.Item(1, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= Len(dgw.Item(1, i).Value.ToString))
                If (txt_letra.Text.ToLower = Strings.Mid(dgw.Item(1, i).Value.ToString, f, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw.CurrentCell = (dgw.Rows.Item(i).Cells.Item(1))
                    fila = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub btn_transf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_transf.Click
        If ((MessageBox.Show("Esta seguro de realizar la Transferencia de Gestión Comercial a Contabilidad", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))) = 6 Then
            Try
                Dim cmd1 As New SqlCommand(("INSERT INTO MAESTRO_PERSONAS (COD_PER,TIPO_PER,DESC_PER,NOMBRE,PATERNO,MATERNO,NOM_COMERCIAL,COD_TIPO_DOC,NRO_DOC,MAIL,NOM_AVAL,NRO_DOC_AVAL,DIR_AVAL,FONO_AVAL,ST_CONTRIBUYENTE,ST_RETENEDOR,ST_PERCEPTOR,ST_SUSPENDIDO)SELECT B.COD_PER,B.TIPO_PER,B.DESC_PER,B.NOMBRE,B.PATERNO,B.MATERNO,B.NOM_COMERCIAL,B.COD_TIPO_DOC,B.NRO_DOC,B.MAIL,B.NOM_AVAL,B.NRO_DOC_AVAL,B.DIR_AVAL,B.FONO_AVAL,B.ST_CONTRIBUYENTE,B.ST_RETENEDOR,B.ST_PERCEPTOR,B.ST_SUSPENDIDO FROM  BD_GCO" & COD_EMPRESA & ".dbo.MAESTRO_PERSONAS AS B WHERE B.COD_PER NOT IN (SELECT COD_PER FROM MAESTRO_PERSONAS )"), con)
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            Try
                Dim cmd2 As New SqlCommand(("INSERT INTO PERSONA_CLASE (COD_PER,COD_CLASE,COD_CAT,LINEA_CRED) SELECT B.COD_PER,B.COD_CLASE,B.COD_CAT,B.LINEA_CRED FROM  BD_GCO" & COD_EMPRESA & ".dbo.PERSONA_CLASE AS B WHERE B.COD_PER + B.COD_CLASE +B.COD_CAT  NOT IN (SELECT  COD_PER + COD_CLASE +COD_CAT FROM PERSONA_CLASE )"), con)
                con.Open()
                cmd2.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            'persona -contacto
            Try
                Dim cmd2 As New SqlCommand(("INSERT INTO PERSONA_CONTACTO (COD_PER,ITEM,NOMBRE,MAIL,OBSERVACION,STATUS_FE) SELECT B.COD_PER,B.ITEM,B.NOMBRE,B.MAIL,B.OBSERVACION,B.STATUS_FE FROM  BD_GCO" & COD_EMPRESA & ".dbo.PERSONA_CONTACTO AS B WHERE B.COD_PER + B.ITEM  NOT IN (SELECT  COD_PER + ITEM FROM PERSONA_CONTACTO )"), con)
                con.Open()
                cmd2.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            'persona direccion
            Try
                Dim cmd2 As New SqlCommand(("INSERT INTO PERSONA_DIRECCION (COD_PER,COD_TIPO,COD_PAIS,COD_DEP,COD_PRO,COD_DIST,DIRECCION,REFERENCIA) SELECT B.COD_PER,B.COD_TIPO,B.COD_PAIS,B.COD_DEP,B.COD_PRO,B.COD_DIST,B.DIRECCION,B.REFERENCIA FROM  BD_GCO" & COD_EMPRESA & ".dbo.PERSONA_DIRECCION AS B WHERE B.COD_PER + B.COD_TIPO  NOT IN (SELECT  COD_PER + COD_TIPO FROM PERSONA_DIRECCION )"), con)
                con.Open()
                cmd2.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            'persona -fono
            Try
                Dim cmd2 As New SqlCommand(("INSERT INTO PERSONA_FONO (COD_PER,COD_TIPO_FONO,ITEM,NRO_FONO) SELECT B.COD_PER,B.COD_TIPO_FONO,B.ITEM,B.NRO_FONO FROM  BD_GCO" & COD_EMPRESA & ".dbo.PERSONA_FONO AS B WHERE B.COD_PER + B.COD_TIPO_FONO  NOT IN (SELECT  COD_PER + COD_TIPO_FONO  FROM PERSONA_FONO )"), con)
                con.Open()
                cmd2.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        DATAGRID()
    End Sub
    Sub CARGAR_CABECERA()
        txt_cod.Text = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw.Item(1, dgw.CurrentRow.Index).Value.ToString
        txt_nro_doc.Text = dgw.Item(2, dgw.CurrentRow.Index).Value.ToString
        txt_nom.Text = dgw.Item(3, dgw.CurrentRow.Index).Value.ToString
        txt_pat.Text = dgw.Item(4, dgw.CurrentRow.Index).Value.ToString
        txt_mat.Text = dgw.Item(5, dgw.CurrentRow.Index).Value.ToString
        TIPO_DOC = dgw.Item(6, dgw.CurrentRow.Index).Value.ToString
        cbo_tipo.Text = dgw.Item(7, dgw.CurrentRow.Index).Value.ToString
        cbo_tipo_doc.Text = dgw.Item(8, dgw.CurrentRow.Index).Value.ToString
        txt_mail.Text = dgw.Item(9, dgw.CurrentRow.Index).Value.ToString
        txt_nc.Text = dgw.Item(10, dgw.CurrentRow.Index).Value.ToString
        txt_desc_aval.Text = dgw.Item(11, dgw.CurrentRow.Index).Value.ToString
        txt_doc_aval.Text = dgw.Item(12, dgw.CurrentRow.Index).Value.ToString
        txt_dir_aval.Text = dgw.Item(13, dgw.CurrentRow.Index).Value.ToString
        txt_fono_aval.Text = dgw.Item(14, dgw.CurrentRow.Index).Value.ToString
        ST_CONTRIBUYENTE = dgw.Item(15, dgw.CurrentRow.Index).Value.ToString
        ST_RETENEDOR = dgw.Item(16, dgw.CurrentRow.Index).Value.ToString
        ST_PERCEPTOR = dgw.Item(17, dgw.CurrentRow.Index).Value.ToString
        ST_SUSPENDIDO = dgw.Item(18, dgw.CurrentRow.Index).Value.ToString
        If ST_CONTRIBUYENTE = "1" Then ch_contribuyente.Checked = True Else ch_contribuyente.Checked = False
        If ST_RETENEDOR = "1" Then ch_retenedor.Checked = True Else ch_retenedor.Checked = False
        If ST_PERCEPTOR = "1" Then chkPerceptor.Checked = True Else chkPerceptor.Checked = False
        If ST_SUSPENDIDO = "1" Then chkSuspendido.Checked = True Else chkSuspendido.Checked = False
    End Sub
    Sub CARGAR_CATEGORIA()
        cbo_cat.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_CAT_PER", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_cat.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_CLASE()
        cbo_clase.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_CLASE_PER", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_clase.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CLASE0()
        COD_CLASE = DGW4.Item(0, DGW4.CurrentRow.Index).Value.ToString
        cbo_clase.Text = DGW4.Item(1, DGW4.CurrentRow.Index).Value.ToString
        COD_CAT = DGW4.Item(2, DGW4.CurrentRow.Index).Value.ToString
        cbo_cat.Text = DGW4.Item(3, DGW4.CurrentRow.Index).Value.ToString
        txt_linea.Text = DGW4.Item(4, DGW4.CurrentRow.Index).Value.ToString
    End Sub
    Sub CARGAR_CONTACTO()
        txt_desc_cont.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_mail_cont.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        txt_obs_cont.Text = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        chkCorreoElectronico.Checked = IIf(dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString = "1", True, False)
    End Sub
    Sub CARGAR_DEPARTAMENTO()
        cbo_dep.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_DEP", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_dep.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_DETALLES()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONTACTOS", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        DGW2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_FONOS", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW2.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3))
            Loop
            con.Close()
        Catch ex As Exception
            'ProjectData.SetProjectError(exception2)
            'Dim ex As Exception = exception2
            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        DGW3.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_DIRECCIONES", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW3.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        DGW4.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CLASES", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                DGW4.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4))
            Loop
            con.Close()
        Catch ex As Exception
            'ProjectData.SetProjectError(exception4)
            'Dim ex As Exception = exception4
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_DIRECCION()
        cbo_tipo_dir.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_TIPO_DIR", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_dir.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_DIRECCION0()
        TIPO_DIR = DGW3.Item(0, DGW3.CurrentRow.Index).Value.ToString
        cbo_tipo_dir.Text = DGW3.Item(1, DGW3.CurrentRow.Index).Value.ToString
        txt_dir.Text = DGW3.Item(2, DGW3.CurrentRow.Index).Value.ToString
        txt_ref.Text = DGW3.Item(3, DGW3.CurrentRow.Index).Value.ToString
        COD_PAIS = DGW3.Item(4, DGW3.CurrentRow.Index).Value.ToString
        cbo_pais.Text = DGW3.Item(5, DGW3.CurrentRow.Index).Value.ToString
        COD_DEP = DGW3.Item(6, DGW3.CurrentRow.Index).Value.ToString
        cbo_dep.Text = DGW3.Item(7, DGW3.CurrentRow.Index).Value.ToString
        COD_PRO = DGW3.Item(8, DGW3.CurrentRow.Index).Value.ToString
        cbo_pro.Text = DGW3.Item(9, DGW3.CurrentRow.Index).Value.ToString
        COD_DIST = DGW3.Item(10, DGW3.CurrentRow.Index).Value.ToString
        cbo_dist.Text = DGW3.Item(11, DGW3.CurrentRow.Index).Value.ToString
    End Sub
    Sub cargar_distrito()
        cbo_dist.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_DIST_PRO_DEP", con2)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = (COD_DEP)
            PROG_01.Parameters.Add("@COD_PRO", SqlDbType.Char).Value = (COD_PRO)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_dist.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Sub CARGAR_FONO()
        TIPO_FONO = DGW2.Item(1, DGW2.CurrentRow.Index).Value.ToString
        cbo_tipo_fono.Text = DGW2.Item(2, DGW2.CurrentRow.Index).Value.ToString
        txt_nro_fono.Text = DGW2.Item(3, DGW2.CurrentRow.Index).Value.ToString
    End Sub
    Sub CARGAR_PAIS()
        cbo_pais.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PAIS", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_pais.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub
    Sub cargar_provincia()
        cbo_pro.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PRO_DEP", con2)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = (COD_DEP)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_pro.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Sub CARGAR_TIPO_DOC()
        cbo_tipo_doc.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_TIPO_DOC_PERSONAL", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_doc.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_TIPO_FONO()
        cbo_tipo_fono.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_TIPO_FONO", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_fono.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub
    Private Sub cbo_dep_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_dep.SelectedIndexChanged
        If (cbo_dep.SelectedIndex <> -1) Then
            COD_DEP = OBJ.COD_DEP(cbo_dep.Text)
            cargar_provincia()
        End If
    End Sub
    Private Sub cbo_pro_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_pro.SelectedIndexChanged
        If (cbo_pro.SelectedIndex <> -1) Then
            COD_PRO = OBJ.COD_PRO(cbo_pro.Text, COD_DEP)
            cargar_distrito()
        End If
    End Sub
    Private Sub cbo_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_tipo.SelectedIndexChanged
        Select Case cbo_tipo.SelectedIndex
            Case 0
                TIPO_PER = "N"
                txt_nom.Enabled = True
                txt_pat.Enabled = True
                txt_mat.Enabled = True
                txt_desc.Enabled = False

            Case 1
                TIPO_PER = "J"
                txt_nom.Enabled = False
                txt_pat.Enabled = False
                txt_mat.Enabled = False
                txt_desc.Enabled = True
            Case 2
                TIPO_PER = "D"
                txt_nom.Enabled = False
                txt_pat.Enabled = False
                txt_mat.Enabled = False
                txt_desc.Enabled = True
        End Select
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
            dgw.Sort(dgw.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_doc_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc.CheckedChanged
        If ch_doc.Checked Then
            dgw.Sort(dgw.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_nc_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_nc.CheckedChanged
        If ch_nc.Checked Then
            dgw.Sort(dgw.Columns.Item(10), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Private Sub ch_rs_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_rs.CheckedChanged
        If ch_rs.Checked Then
            dgw.Sort(dgw.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar.Enabled = False
            btn_sgt.Enabled = False
            txt_letra.Clear()
            txt_letra.Focus()
        End If
    End Sub
    Sub DATAGRID()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PERSONA", con)
            Dim ADAP As New SqlDataAdapter(cmd)
            Dim DT As New DataTable("PERSONAS")
            ADAP.Fill(DT)
            dgw.DataSource = (DT)
            dgw.Columns.Item(3).Visible = (False)
            dgw.Columns.Item(4).Visible = (False)
            dgw.Columns.Item(5).Visible = (False)
            dgw.Columns.Item(6).Visible = (False)
            dgw.Columns.Item(7).Visible = (False)
            dgw.Columns.Item(8).Visible = (False)
            dgw.Columns.Item(9).Visible = (False)
            dgw.Columns.Item(11).Visible = (False)
            dgw.Columns.Item(12).Visible = (False)
            dgw.Columns.Item(13).Visible = (False)
            dgw.Columns.Item(14).Visible = (False)
            dgw.Columns(15).Visible = False
            dgw.Columns(16).Visible = False
            dgw.Columns.Item(0).Width = (50)
            dgw.Columns.Item(1).Width = (280)
            dgw.Columns.Item(2).Width = (&H7B)
            dgw.Columns.Item(10).Width = (250)
            ch_rs.Checked = True
        Catch ex As Exception


            con.Close()
            'MsgBox(ex.Message)
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub INSERTAR_DETALLES()
        Dim i1 As Integer = 0
        Dim cont1 As Integer = (dgw1.RowCount - 1)
        'Dim VB$t_i4$L0 As Integer = cont1
        i1 = 0
        Do While (i1 <= cont1)
            Dim CMD As New SqlCommand("INSERTAR_CONTACTOS", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = (dgw1.Item(0, i1).Value.ToString)
            CMD.Parameters.Add("@NOMBRE", SqlDbType.Char).Value = (dgw1.Item(1, i1).Value.ToString)
            CMD.Parameters.Add("@MAIL", SqlDbType.Char).Value = (dgw1.Item(2, i1).Value.ToString)
            CMD.Parameters.Add("@OBSERVACION", SqlDbType.Char).Value = (dgw1.Item(3, i1).Value.ToString)
            CMD.Parameters.Add("@STATUS_FE", SqlDbType.Char).Value = dgw1.Item(4, i1).Value
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            i1 += 1
        Loop
        Dim i2 As Integer = 0
        Dim cont2 As Integer = (DGW2.RowCount - 1)
        'Dim VB$t_i4$L1 As Integer = cont2
        i2 = 0
        Do While (i2 <= cont2)
            Dim CMD As New SqlCommand("INSERTAR_FONO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = (DGW2.Item(0, i2).Value.ToString)
            CMD.Parameters.Add("@COD_TIPO", SqlDbType.Char).Value = (DGW2.Item(1, i2).Value.ToString)
            CMD.Parameters.Add("@NRO_FONO", SqlDbType.VarChar).Value = (DGW2.Item(3, i2).Value.ToString)
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            i2 += 1
        Loop
        Dim i3 As Integer = 0
        Dim cont3 As Integer = (DGW3.RowCount - 1)
        'Dim VB$t_i4$L2 As Integer = cont3
        i3 = 0
        Do While (i3 <= cont3)
            Dim k As String = DGW3.Item(6, i3).Value.ToString
            Dim CMD As New SqlCommand("INSERTAR_DIRECCIONES", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            CMD.Parameters.Add("@COD_TIPO", SqlDbType.Char).Value = (DGW3.Item(0, i3).Value.ToString)
            CMD.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = (DGW3.Item(2, i3).Value.ToString)
            CMD.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = (DGW3.Item(3, i3).Value.ToString)
            CMD.Parameters.Add("@COD_PAIS", SqlDbType.Char).Value = (DGW3.Item(4, i3).Value.ToString)
            CMD.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = (DGW3.Item(6, i3).Value.ToString)
            CMD.Parameters.Add("@COD_PRO", SqlDbType.Char).Value = (DGW3.Item(8, i3).Value.ToString)
            CMD.Parameters.Add("@COD_DIST", SqlDbType.Char).Value = (DGW3.Item(10, i3).Value.ToString)
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            i3 += 1
        Loop
        Dim i4 As Integer = 0
        Dim cont4 As Integer = (DGW4.RowCount - 1)
        'Dim VB$t_i4$L3 As Integer = cont4
        i4 = 0
        Do While (i4 <= cont4)
            Dim CMD As New SqlCommand("INSERTAR_CLASES", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            CMD.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = (DGW4.Item(0, i4).Value.ToString)
            CMD.Parameters.Add("@COD_CAT", SqlDbType.Char).Value = (DGW4.Item(2, i4).Value.ToString)
            CMD.Parameters.Add("@linea", SqlDbType.Decimal).Value = (DGW4.Item(4, i4).Value.ToString)
            con.Open()
            CMD.ExecuteNonQuery()
            con.Close()
            i4 += 1
        Loop
    End Sub
    Sub LIMPIAR_CABECERA()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_nom.Clear()
        txt_pat.Clear()
        txt_mat.Clear()
        txt_nro_doc.Clear()
        ch_retenedor.Checked = False
        ch_contribuyente.Checked = False
        txt_mail.Clear()
        cbo_tipo_doc.SelectedIndex = -1
        cbo_tipo.SelectedIndex = -1
        txt_desc_aval.Clear()
        txt_doc_aval.Clear()
        txt_dir_aval.Clear()
        txt_fono_aval.Clear()
        txt_nc.Clear()
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        txt_nom.ReadOnly = False
        txt_pat.ReadOnly = False
        txt_mat.ReadOnly = False
        txt_nro_doc.ReadOnly = False
        txt_mail.ReadOnly = False
        txt_desc_aval.ReadOnly = False
        txt_doc_aval.ReadOnly = False
        txt_dir_aval.ReadOnly = False
        txt_fono_aval.ReadOnly = False
        txt_nc.ReadOnly = False
        cbo_tipo_doc.Enabled = True
        cbo_tipo.Enabled = True
        dgw1.Rows.Clear()
        DGW2.Rows.Clear()
        DGW3.Rows.Clear()
        DGW4.Rows.Clear()
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        chkSuspendido.Checked = False
    End Sub
    Sub LIMPIAR_CLASE()
        cbo_clase.SelectedIndex = -1
        cbo_clase.Enabled = True
        cbo_cat.SelectedIndex = -1
        txt_linea.Text = "0.00"
    End Sub
    Sub LIMPIAR_CONTACTO()
        txt_desc_cont.Clear()
        txt_mail_cont.Clear()
        txt_obs_cont.Clear()
        txt_desc_cont.ReadOnly = False
        txt_mail_cont.ReadOnly = False
        txt_obs_cont.ReadOnly = False
        chkCorreoElectronico.Checked = False
    End Sub
    Sub LIMPIAR_DIRECCION()
        cbo_tipo_dir.SelectedIndex = -1
        cbo_tipo_dir.Enabled = True
        cbo_pais.SelectedIndex = -1
        cbo_dep.SelectedIndex = -1
        cbo_pro.SelectedIndex = -1
        cbo_dist.SelectedIndex = -1
        cbo_pais.Text = "PERÚ"
        txt_dir.Clear()
        txt_ref.Clear()
    End Sub
    Sub LIMPIAR_FONO()
        cbo_tipo_fono.SelectedIndex = -1
        txt_nro_fono.Clear()
        cbo_tipo_fono.Enabled = True
        txt_nro_fono.ReadOnly = False
    End Sub
    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_PERSONA", con)
            con.Open()
            SGT = CMD.ExecuteScalar.ToString
            con.Close()
        Catch ex As Exception


            con.Close()
            'MsgBox(ex.Message)
            MsgBox(ex.Message)
        End Try
        If (SGT = "") Then
            txt_cod.Text = "00001"
        Else
            txt_cod.Text = SGT
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (BOTON = "NUEVO") Then
                BOTON = "DETALLES1"
            ElseIf (BOTON = "MODIFICAR") Then
                BOTON = "DETALLES2"
            Else
                BOTON = "DETALLES"
                LIMPIAR_CABECERA()
                CARGAR_CABECERA()
                CARGAR_DETALLES()
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
                txt_cod.ReadOnly = True
                txt_desc.ReadOnly = True
                txt_nom.ReadOnly = True
                txt_pat.ReadOnly = True
                txt_mat.ReadOnly = True
                txt_nro_doc.ReadOnly = True
                txt_mail.ReadOnly = True
                cbo_tipo_doc.Enabled = False
                cbo_tipo.Enabled = False
                txt_desc_aval.ReadOnly = True
                txt_doc_aval.ReadOnly = True
                txt_dir_aval.ReadOnly = True
                txt_fono_aval.ReadOnly = True
            End If
        End If
    End Sub
    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            cbo_tipo.Focus()
        End If
    End Sub
    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_mail.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_nro_doc.Focus()
        End If
    End Sub
    Private Sub txt_letra_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra.TextChanged
        Dim i As Integer
        If ch_cod.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L0 As Integer = (dgw.RowCount - 1)
            i = 0
            Do While (i <= (dgw.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((dgw.Item(0, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw.CurrentCell = (dgw.Rows.Item(i).Cells.Item(0))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_rs.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L1 As Integer = (dgw.RowCount - 1)
            i = 0
            Do While (i <= (dgw.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid((dgw.Item(1, i).Value), 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw.CurrentCell = (dgw.Rows.Item(i).Cells.Item(1))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_nc.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L2 As Integer = (dgw.RowCount - 1)
            i = 0
            Do While (i <= (dgw.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid(dgw.Item(10, i).Value.ToString, 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw.CurrentCell = (dgw.Rows.Item(i).Cells.Item(10))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_doc.Checked Then
            txt_letra.Focus()
            'Dim VB$t_i4$L3 As Integer = (dgw.RowCount - 1)
            i = 0
            Do While (i <= (dgw.RowCount - 1))
                If (txt_letra.Text.ToLower = Strings.Mid(dgw.Item(2, i).Value.ToString, 1, Strings.Len(txt_letra.Text)).ToLower) Then
                    dgw.CurrentCell = (dgw.Rows.Item(i).Cells.Item(2))
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub
    Private Sub txt_linea_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_linea.LostFocus
        Try
            txt_linea.Text = (OBJ.HACER_DECIMAL(txt_linea.Text))
        Catch ex As Exception


            MessageBox.Show("Error en Línea de Crédito", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_linea.Text = "0.00"
            txt_linea.Focus()

            Exit Sub

        End Try
    End Sub
    Private Sub txt_mat_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_mat.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_mail.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_pat.Focus()
        End If
    End Sub
    Private Sub txt_mat_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_mat.LostFocus
        txt_desc.Text = String.Concat(New String() {txt_pat.Text, " ", txt_mat.Text, " ", txt_nom.Text})
    End Sub
    Private Sub txt_nom_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nom.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_pat.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_nro_doc.Focus()
        End If
    End Sub
    Private Sub txt_nom_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_nom.LostFocus
        txt_desc.Text = String.Concat(New String() {txt_pat.Text, " ", txt_mat.Text, " ", txt_nom.Text})
    End Sub
    Private Sub txt_nro_doc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_doc.KeyDown
        If (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        ElseIf (e.KeyData = Keys.Down) Then
            If (TIPO_PER = "J") Then
                txt_desc.Focus()
            Else
                txt_nom.Focus()
            End If
        End If
    End Sub
    Private Sub txt_pat_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_pat.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_mat.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_nom.Focus()
        End If
    End Sub
    Private Sub txt_pat_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_pat.LostFocus
        txt_desc.Text = String.Concat(New String() {txt_pat.Text, " ", txt_mat.Text, " ", txt_nom.Text})
    End Sub
    Function VALIDAR_CLASE_PER() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW4.RowCount - 1)

        I = 0
        Do While (I <= CONT)
            If ((COD_CLASE = DGW4.Item(0, I).Value.ToString) And (COD_CAT = DGW4.Item(2, I).Value.ToString)) Then
                Return False
            End If
            I += 1
        Loop
        Return True
    End Function
    Function validar_direccion() As Boolean
        Dim i As Integer = 0
        Dim cont As Integer = (DGW3.RowCount - 1)

        i = 0
        Do While (i <= cont)
            If (TIPO_DIR = DGW3.Item(0, i).Value.ToString) Then
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function
    Function VERIFICAR_ELIM_PERSONA(ByVal COD_PER00 As String) As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PERSONA_MOV", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER00)
            con.Open()
            CONT = (CMD.ExecuteScalar.ToString)
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        Return CONT
    End Function
    Function verificar_persona()
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PERSONA", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (txt_cod.Text)
            con.Open()
            CONT = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            'MsgBox(ex.Message)
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Private Sub PERSONA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PERSONA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        DATAGRID()
        CARGAR_TIPO_DOC()
        CARGAR_TIPO_FONO()
        CARGAR_CLASE()
        CARGAR_CATEGORIA()
        CARGAR_PAIS()
        CARGAR_DEPARTAMENTO()
        CARGAR_DIRECCION()
        dgw.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter '(320)
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        DGW2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        DGW3.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        DGW4.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        ''---------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------
        Dim COD_EMPRESA_COI0 As String = OBJ.DIR_TABLA_DESC("GCO", "TRANS")
        If COD_EMPRESA_COI0 = " " Or COD_EMPRESA_COI0 Is Nothing Then
            btn_transf.Enabled = False
            btn_nuevo.Enabled = True
        Else
            btn_transf.Enabled = True
            btn_nuevo.Enabled = False
        End If
    End Sub

    Private Sub btnConsultaSunat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaSunat.Click
        Dim frm As frmConsultaRuc = frmConsultaRuc.ObtenerInstancia
        'frm.MdiParent = Me
        frm.Cargar_Datos(txt_nro_doc.Text, BOTON, "mantenimiento")
        frm.btnConsultar.Focus()
        frm.ShowDialog()
        If frm.DialogResult = Windows.Forms.DialogResult.OK Then
            Try
                txt_nro_doc.Text = frm.txtRuc.Text
                txt_desc.Text = frm.txtNombre.Text
                DGW3.Rows.Add("01", "FISCAL", frm.txtDireccion.Text, "", "", "", "", "", "", "", "", "")
                Dim tipDoc As Integer
                tipDoc = InStr(1, frm.txtTipo.Text, "NATURAL")
                If tipDoc <> 0 Then
                    cbo_tipo.Text = "NATURAL"
                Else
                    cbo_tipo.Text = "JURIDICA"
                End If
                'Nombre Persona Natural
                If tipDoc <> 0 Then
                    Dim words As String = frm.txtNombre.Text
                    Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c, CChar(vbTab)})
                    Dim cont As Integer = 0
                    For Each s As String In split
                        If s.Trim() <> "" Then
                            If cont = 0 Then
                                txt_pat.Text = s
                            ElseIf cont = 1 Then
                                txt_mat.Text = s
                            ElseIf cont > 1 Then
                                txt_nom.Text = txt_nom.Text & s & " "
                            End If
                            'Console.WriteLine(s)
                            cont += 1
                        End If
                    Next s
                    txt_nom.Text = txt_nom.Text.Trim()
                End If
                'Agente Retenedor
                ch_retenedor.Checked = frm.chkAgente.Checked
                cbo_tipo_doc.Text = "REGISTRO UNICO CONTRIBUYENTE"
                If cbo_tipo.Text = "NATURAL" Then
                    txt_nc.Text = frm.txtNombreComercial.Text
                End If
            Catch ex As Exception
                txt_desc.Clear()
            End Try
            frm.Hide()
        End If
        frm.Close()
    End Sub

    Private Sub btnImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click
        Dim rutaArchivo As String = "" 'Variable de la ruta
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Archivos*.xlsx|*.xlsx"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            rutaArchivo = ofd.FileName

            Dim ds As New DataSet
            Dim tr As SqlTransaction = Nothing
            Dim SinError As Boolean = True
            Dim ListaErrores As New Dictionary(Of Integer, String)
            'Cadena de conexión
            Dim conExcel As String = "Provider=Microsoft.ACE.Oledb.12.0;" & _
                        "Extended Properties='TEXT;HDR=Yes';" & _
                        "Data Source=" & rutaArchivo & ";" & _
                        "Extended Properties= Excel 8.0"
            Try
                'Cargamos datos del excel a un  DataSet
                Using cnn As New OleDbConnection(conExcel)

                    Dim cmd As New OleDbCommand("Select * from [Persona$]", cnn)
                    cmd.CommandType = CommandType.Text
                    Dim da As New OleDbDataAdapter(cmd)
                    da.Fill(ds)
                End Using
                'Insertar los registros
                con.Open()
                tr = con.BeginTransaction
                Dim dr As DataRow
                Dim idx As Integer = 1
                Dim fila As Integer = 2
                'Recorremos el datarow 
                Dim cantidad As Integer = ds.Tables(0).Rows.Count
                For Each dr In ds.Tables(0).Rows
                    'Validamos si el registro no existe y tiene campos obligatorios a llenar
                    If dr.Item(1).ToString.Length > 0 And dr.Item(6).ToString.Length > 0 And dr.Item(7).ToString.Length > 0 And (dr.Item(9).ToString.Length > 0 Or dr.Item(13).ToString.Length > 0) Then
                        If EXIST_PERSONA(dr.Item(0), tr) <= 0 Then
                            Dim cmd As New SqlCommand("INSERTAR_PERSONA", con, tr)
                            cmd.CommandType = CommandType.StoredProcedure
                            With cmd.Parameters
                                .AddWithValue("@COD_PER", dr.Item(0))
                                .AddWithValue("@TIPO_PER", dr.Item(1))
                                '.AddWithValue("@DESC_PER", dr.Item(2))
                                'Validamos si el tipo persona es N y llenamos la descripción persona si no lo deja con el valor del excel  
                                If dr.Item(1).ToString.Equals("N") Then
                                    .AddWithValue("@DESC_PER", dr.Item(4) + " " + dr.Item(5) + " " + dr.Item(3))
                                Else
                                    .AddWithValue("@DESC_PER", dr.Item(2))
                                End If
                                .AddWithValue("@NOM", IIf(String.IsNullOrEmpty(dr.Item(3).ToString), "", dr.Item(3)))
                                .AddWithValue("@PAT", IIf(String.IsNullOrEmpty(dr.Item(4).ToString), "", dr.Item(4)))
                                .AddWithValue("@MAT", IIf(String.IsNullOrEmpty(dr.Item(5).ToString), "", dr.Item(5)))
                                .AddWithValue("@COD_TIPO_DOC", dr.Item(6))
                                .AddWithValue("@NRO_DOC", dr.Item(7))
                                .AddWithValue("@MAIL", "")
                                .AddWithValue("@NOM_COMERCIAL", IIf(String.IsNullOrEmpty(dr.Item(8).ToString), "", dr.Item(8)))
                                .AddWithValue("@NOM_AVAL", "")
                                .AddWithValue("@NRO_DOC_AVAL", IIf(String.IsNullOrEmpty(dr.Item(12).ToString), "", dr.Item(12)))
                                .AddWithValue("@DIR_AVAL", "")
                                .AddWithValue("@FONO_AVAL", "")
                                .AddWithValue("@ST_CONTRIBUYENTE", "")
                                .AddWithValue("@ST_RETENEDOR", "")
                                .AddWithValue("@ST_PERCEPTOR", "")
                            End With
                            cmd.ExecuteNonQuery()
                        End If
                        'Verificamos si existe una clase
                        If (dr.Item(9).ToString).Length > 0 Then
                            If EXITS_CLASE(dr.Item(0), dr.Item(9), tr) <= 0 Then
                                Dim cmd As New SqlCommand("INSERTAR_CLASES", con, tr)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@COD_PER", dr.Item(0))
                                cmd.Parameters.AddWithValue("@COD_CLASE", IIf(dr.Item(9) = "C", "2", "1"))
                                cmd.Parameters.AddWithValue("@COD_CAT", "1")
                                cmd.Parameters.AddWithValue("@linea", 0.0)
                                'cmd.Parameters.AddWithValue("@FORMA_PAGO ", "")
                                'cmd.Parameters.AddWithValue("@CONDICION_VENTA", "")
                                'cmd.Parameters.AddWithValue("@NRO_DIAS ", "")
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                        'Verifica si existe un telefono
                        If (dr.Item(11).ToString).Length > 0 Then
                            If EXIST_TELEFONO(dr.Item(0), tr) <= 0 Then
                                Dim cmd As New SqlCommand("INSERTAR_FONO", con, tr)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@COD_PER", dr.Item(0))
                                cmd.Parameters.AddWithValue("@ITEM", 1)
                                cmd.Parameters.AddWithValue("@COD_TIPO", "01")
                                cmd.Parameters.AddWithValue("@NRO_FONO", dr.Item(11))
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                        'Verifica si hay una dirección   
                        If (dr.Item(10).ToString).Length > 0 Then
                            If EXIST_DIRECCION(dr.Item(0), tr) <= 0 Then
                                Dim cmd As New SqlCommand("INSERTAR_DIRECCIONES", con, tr)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@COD_PER", dr.Item(0))
                                cmd.Parameters.AddWithValue("@COD_TIPO", "01")
                                cmd.Parameters.AddWithValue("@DIRECCION", dr.Item(10))
                                cmd.Parameters.AddWithValue("@REFERENCIA", "")
                                cmd.Parameters.AddWithValue("@COD_PAIS", "9589")
                                cmd.Parameters.AddWithValue("@COD_DEP", "")
                                cmd.Parameters.AddWithValue("@COD_PRO", "")
                                cmd.Parameters.AddWithValue("@COD_DIST", "")
                                cmd.ExecuteNonQuery()
                                cmd.Parameters.Clear()
                            End If
                        End If
                        'Verificamos si hay una clase mas 
                        If (dr.Item(13).ToString).Length > 0 Then
                            If EXITS_CLASE(dr.Item(0), dr.Item(13), tr) <= 0 Then
                                Dim cmd As New SqlCommand("INSERTAR_CLASES", con, tr)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@COD_PER", dr.Item(0))
                                cmd.Parameters.AddWithValue("@COD_CLASE", IIf(dr.Item(13) = "C", "2", "1"))
                                cmd.Parameters.AddWithValue("@COD_CAT", "1")
                                cmd.Parameters.AddWithValue("@linea", 0.0)
                                'cmd.Parameters.AddWithValue("@FORMA_PAGO ", "")
                                'cmd.Parameters.AddWithValue("@CONDICION_VENTA", "")
                                'cmd.Parameters.AddWithValue("@NRO_DIAS ", "")
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                    End If
                Next

                'Revisamos el sin error
                If SinError Then
                    tr.Commit()
                    MessageBox.Show("Los Articulos se importaron correctamente", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    tr.Rollback()
                    Dim rpta As DialogResult = MessageBox.Show("¿Desea ver el registro de errores?", "Importar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If rpta = Windows.Forms.DialogResult.Yes Then
                        Dim frm As New Form
                        frm.Text = "Registros sin insertar"
                        Dim dgv As New DataGridView
                        Dim col1 As New DataGridViewButtonColumn
                        Dim col2 As New DataGridViewButtonColumn
                        col1.HeaderText = "Item"
                        col2.HeaderText = "Mensaje"
                        dgv.Columns.Add(col1)
                        dgv.Columns.Add(col2)
                        dgv.Dock = DockStyle.Fill
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                        'Recorremos posibles errores que hayamos encontrado
                        For Each D As KeyValuePair(Of Integer, String) In ListaErrores
                            dgv.Rows.Add(D.Key, D.Value)
                        Next
                        frm.Controls.Add(dgv)
                        frm.ShowDialog()
                    End If
                End If
                DATAGRID()
            Catch ex As Exception
                tr.Rollback()
                MessageBox.Show(ex.ToString)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Function EXIST_PERSONA(ByVal codigo As String, ByVal trx As SqlTransaction) As Integer
        Dim cont As Integer = 0
        Try
            Dim cmd As New SqlCommand("VERIFICAR_PERSONA", con, trx)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigo
            cont = cmd.ExecuteScalar
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return cont
    End Function

    Function EXIST_TELEFONO(ByVal codigo As String, ByVal trx As SqlTransaction) As Integer
        Dim cont As Integer = 0
        Try
            Dim cmd As New SqlCommand("SP_VALIDA_TELEFONO_EXCEL", con, trx)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigo
            cont = cmd.ExecuteScalar
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return cont
    End Function

    Function EXITS_CLASE(ByVal codigo As String, ByVal codclase As String, ByVal trx As SqlTransaction) As Integer
        Dim cont As Integer = 0
        Try
            Dim cmd As New SqlCommand("SP_VERIFICAR_PCLASE", con, trx)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigo
            cmd.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = codclase
            cont = cmd.ExecuteScalar
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return cont
    End Function

    Function EXIST_DIRECCION(ByVal codigo As String, ByVal trx As SqlTransaction) As Integer
        Dim cont As Integer = 0
        Try
            Dim cmd As New SqlCommand("SP_VALIDA_DIRECCION_EXCEL", con, trx)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigo
            cont = cmd.ExecuteScalar
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return cont
    End Function

    Private Sub btnValidarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidarExcel.Click
        Dim rutaArchivo As String = ""
        'Creamos un formulario donde veremos los registros que no existen
        Dim frmVisor As New Form

        frmVisor.Text = "Registros no existentes"
        Dim dgv As New DataGridView
        Dim col1 As New DataGridViewTextBoxColumn
        Dim col2 As New DataGridViewTextBoxColumn
        Dim col3 As New DataGridViewTextBoxColumn
        col1.HeaderText = "Posicion"
        col2.HeaderText = "Nro Documento"
        col3.HeaderText = "Nombre"
        dgv.Columns.Add(col1)
        dgv.Columns.Add(col2)
        dgv.Columns.Add(col3)
        dgv.Dock = DockStyle.Fill
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgv.AllowUserToAddRows = False

        '--------------------------
        Using ofd As New OpenFileDialog
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaArchivo = ofd.FileName

                Dim ds As New DataSet
                'Cadena de conexión
                Dim conExcel As String = "Provider=Microsoft.ACE.Oledb.12.0;" & _
                            "Extended Properties='TEXT;HDR=Yes';" & _
                            "Data Source=" & rutaArchivo & ";" & _
                            "Extended Properties= Excel 8.0"
                Try
                    'Cargamos datos del excel a un  DataSet
                    Using cnn As New OleDbConnection(conExcel)

                        Dim cmd As New OleDbCommand("Select * from [Persona$]", cnn)
                        cmd.CommandType = CommandType.Text
                        Dim da As New OleDbDataAdapter(cmd)
                        da.Fill(ds)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("No existe la hoja Persona o las columnas especificas en el excel", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End Try
                Dim fila As Integer = 2
                'Buscamos los datos del excel en la grilla del documento de las personas
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    'Buscamos en la grilla
                    Dim i As Integer = 0
                    i = 0
                    Do While (i <= (dgw.RowCount - 1))
                        If (dr(7).ToString.Trim = Strings.Mid(dgw.Item(2, i).Value.ToString, 1, Strings.Len(dr(7).ToString.Trim)).ToLower) Then
                            'Si encontramos el documento no hacemos nada
                            Exit Do
                        End If
                        i += 1
                        If i = dgw.RowCount - 1 Then
                            dgv.Rows.Add(fila, dr(7).ToString, dr(2).ToString)
                        End If
                    Loop
                    fila += 1
                Next
                If dgv.Rows.Count > 0 Then
                    frmVisor.Controls.Add(dgv)
                    frmVisor.MdiParent = Me.MdiParent
                    frmVisor.Show()
                End If
            End If
        End Using
    End Sub
End Class