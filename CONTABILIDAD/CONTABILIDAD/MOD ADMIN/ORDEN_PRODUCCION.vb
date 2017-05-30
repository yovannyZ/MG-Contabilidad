Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class ORDEN_PRODUCCION
    Private boton As String
    Private CIE As SqlDateTime
    Private cod_tipo As String
    Private obj As New Class1
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        txt_obs.Clear()
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        txt_desc2.ReadOnly = False
        txt_obs.ReadOnly = False
        dtp_ini.Enabled = True
        dtp_cie.Enabled = True
        dtp_cie.Checked = True
        dtp_ini.Value = FECHA_GRAL
        dtp_cie.Value = FECHA_GRAL
        cbo_tipo.SelectedIndex = -1
        cbo_tipo.Enabled = True
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_nuevo.Select()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (Decimal.Parse((CInt(MessageBox.Show(("ELIMINAR " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_OP", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.VarChar).Value = COD_CLASE
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        DATAGRID()
        btn_nuevo.Select()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el Nº de Orden de Producción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf (dtp_cie.Checked AndAlso (DateTime.Compare(dtp_cie.Value, dtp_ini.Value) < 0)) Then
            MessageBox.Show("Rango de Fechas Incorrecto", "Error en Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_ini.Focus()
        Else
            If dtp_cie.Checked Then
                CIE = dtp_cie.Value
            Else
                CIE = SqlDateTime.Null
            End If
            If (CONTAR_REG() > 0) Then
                MessageBox.Show("La Orden de Producción ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                cod_tipo = obj.DIR_TABLA_COD(cbo_tipo.Text, "TCONT")
                Try
                    Dim CMD As New SqlCommand("INSERTAR_OP", con)
                    CMD.CommandType = CommandType.StoredProcedure
                    CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.VarChar).Value = txt_cod.Text
                    CMD.Parameters.Add("@DESC_ORDEN", SqlDbType.VarChar).Value = txt_desc.Text
                    CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                    CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp_ini.Value
                    CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = CIE
                    CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                    CMD.Parameters.Add("@COD_TIPO", SqlDbType.Char).Value = cod_tipo
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("La Orden de Producción se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LIMPIAR()
                    txt_cod.Focus()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                DATAGRID()
                SGT_CODIGO()
            End If
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()
            Return
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        CARGAR_DATOS()
        txt_cod.ReadOnly = True
        TabControl1.SelectedTab = TabPage2
        txt_desc.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (Strings.Trim(txt_cod.Text) = "") Then
            MessageBox.Show("Debe insertar el Nº de Orden de Producción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (Strings.Trim(txt_desc.Text) = "") Then
            MessageBox.Show("Debe insertar la descripción", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_desc.Focus()
        ElseIf (dtp_cie.Checked AndAlso (DateTime.Compare(dtp_cie.Value, dtp_ini.Value) < 0)) Then
            MessageBox.Show("Rango de Fechas Incorrecto", "Error en Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_ini.Focus()
        Else
            If dtp_cie.Checked Then
                CIE = dtp_cie.Value
            Else
                CIE = SqlDateTime.Null
            End If
            cod_tipo = obj.DIR_TABLA_COD(cbo_tipo.Text, "TCONT")
            Try
                Dim CMD As New SqlCommand("MODIFICAR_OP", con)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.VarChar).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_ORDEN", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp_ini.Value
                CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = CIE
                CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                CMD.Parameters.Add("@COD_TIPO", SqlDbType.Char).Value = cod_tipo
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La Orden de Producción se guardó", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
                DATAGRID()
                btn_nuevo.Select()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        SGT_CODIGO()
        TabControl1.SelectedTab = TabPage2
        txt_cod.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(3) = 0
        Close()
    End Sub
    Private Sub btn_transf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_transf.Click
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de realizar la Transferencia de Gestión Comercial a Contabilidad", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim cmd1 As New SqlCommand(("INSERT INTO ORDEN_PRODUCCION (NRO_ORDEN,DESC_ORDEN,DESC_CORTA,FECHA_INICIO,FECHA_CIERRE,OBSERVACION,COD_TIPO) SELECT B.NRO_ORDEN,B.DESC_ORDEN,B.DESC_CORTA,B.FECHA_INICIO,B.FECHA_CIERRE,B.OBSERVACION,B.COD_TIPO FROM  BD_GCO" & COD_EMPRESA & ".dbo.ORDEN_PRODUCCION AS B WHERE  B.NRO_ORDEN NOT IN (SELECT NRO_ORDEN FROM ORDEN_PRODUCCION)"), con)
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        DATAGRID()
    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        dtp_ini.Value = Date.Parse(dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString)
        If (dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString = "") Then
            dtp_cie.Checked = False
            dtp_cie.Value = FECHA_GRAL
        Else
            dtp_cie.Checked = True
            dtp_cie.Value = Date.Parse(dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString)
        End If
        txt_obs.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
        cod_tipo = dgw1.Item(6, dgw1.CurrentRow.Index).Value.ToString
        cbo_tipo.Text = obj.DIR_TABLA_DESC(cod_tipo, "TCONT")
    End Sub
    Sub CARGAR_TIPO()
        cbo_tipo.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_DIR_TABLA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TABLA_COD", SqlDbType.Char).Value = "TCONT"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CLASE_ARTICULO_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        DATAGRID()
        CARGAR_TIPO()
        dtp_ini.Value = FECHA_GRAL
        dtp_cie.Value = FECHA_GRAL
        btn_nuevo.Select()
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_OP", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.VarChar).Value = txt_cod.Text
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
            Dim cmd As New SqlCommand("MOSTRAR_op", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = dt
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(3).Visible = False
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(0).Width = 70
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub mant_estado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Function Numero(ByVal e As KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
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
    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_OP", con)
            con.Open()
            SGT = CMD.ExecuteScalar.ToString
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If (SGT = "") Then
            txt_cod.Text = "0000001"
        Else
            txt_cod.Text = SGT
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "NUEVO") Then
                boton = "DETALLES1"
            ElseIf (boton = "MODIFICAR") Then
                boton = "DETALLES2"
            Else
                boton = "DETALLES"
                LIMPIAR()
                If (dgw1.Rows.Count <> 0) Then
                    CARGAR_DATOS()
                End If
                txt_cod.ReadOnly = True
                txt_desc.ReadOnly = True
                txt_desc2.ReadOnly = True
                txt_obs.ReadOnly = True
                dtp_ini.Enabled = False
                dtp_cie.Enabled = False
                cbo_tipo.Enabled = False
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub
End Class