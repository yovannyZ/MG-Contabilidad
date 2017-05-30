Imports System.Data.SqlClient
Public Class PROYECTO
    Dim boton As String
    Dim CIE As SqlTypes.SqlDateTime
    Dim cod_tipo As String
    Dim OBJ As New Class1
    Private Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cancelar.Click
        TabControl1.SelectedTab = (TabPage1)
        btn_nuevo.Select()
    End Sub
    Private Sub btn_cancelar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles btn_cancelar.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Dim COD_CLASE As String = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        If (MessageBox.Show(("ELIMINAR " & COD_CLASE & " " & dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) = 6 Then
            Try
                Dim CMD As New SqlCommand("ELIMINAR_PROYECTO", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_PROYECTO", SqlDbType.Char).Value = COD_CLASE
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        datagrid()
        btn_nuevo.Select()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If ((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Then
            MessageBox.Show("Ingrese los datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (dtp_cie.Checked AndAlso (DateTime.Compare(dtp_cie.Value, dtp_ini.Value) < 0)) Then
            MessageBox.Show("Rango de fechas incorrecto", "Error en Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_ini.Focus()
        Else
            If dtp_cie.Checked Then
                CIE = dtp_cie.Value
            Else
                CIE = SqlTypes.SqlDateTime.Null
            End If
            If (CONTAR_REG > 0) Then
                MessageBox.Show("El código de Proyecto ya existe", "Ya existe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod.Focus()
            Else
                Try
                    Dim CMD As New SqlCommand("INSERTAR_PROYECTO", con)
                    CMD.CommandType = (CommandType.StoredProcedure)
                    CMD.Parameters.Add("@COD_PROYECTO", SqlDbType.Char).Value = txt_cod.Text
                    CMD.Parameters.Add("@DESC_PROYECTO", SqlDbType.VarChar).Value = txt_desc.Text
                    CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                    CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp_ini.Value
                    CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = CIE
                    CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                    con.Open()
                    CMD.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("El Proyecto de guardó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LIMPIAR()
                    txt_cod.Focus()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                End Try
                datagrid()
                SGT_CODIGO()
            End If
        End If
    End Sub
    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        boton = "MODIFICAR"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        LIMPIAR()
        dtp_cie.Enabled = True
        dtp_cie.Checked = (False)
        CARGAR_DATOS()
        txt_cod.ReadOnly = True
        TabControl1.SelectedTab = (TabPage2)
        txt_desc.Focus()
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((Strings.Trim(txt_cod.Text) = "") Or (Strings.Trim(txt_desc.Text) = "")) Then
            MessageBox.Show("Ingrese los datos", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod.Focus()
        ElseIf (dtp_cie.Checked AndAlso (DateTime.Compare(dtp_cie.Value, dtp_ini.Value) < 0)) Then
            MessageBox.Show("Rango de fechas incorrecto", "Error en fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp_ini.Focus()
        Else
            If dtp_cie.Checked Then
                CIE = dtp_cie.Value
            Else
                CIE = SqlTypes.SqlDateTime.Null
            End If
            Try
                Dim CMD As New SqlCommand("MODIFICAR_PROYECTO", con)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@COD_PROYECTO", SqlDbType.Char).Value = txt_cod.Text
                CMD.Parameters.Add("@DESC_PROYECTO", SqlDbType.VarChar).Value = txt_desc.Text
                CMD.Parameters.Add("@DESC_CORTA", SqlDbType.VarChar).Value = txt_desc2.Text
                CMD.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = dtp_ini.Value
                CMD.Parameters.Add("@FECHA_CIERRE", SqlDbType.DateTime).Value = CIE
                CMD.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = txt_obs.Text
                con.Open()
                CMD.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("El Proyecto se actualizó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = (TabPage1)
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            datagrid()
            btn_nuevo.Select()
        End If
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "NUEVO"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        LIMPIAR()
        dtp_cie.Enabled = True
        dtp_cie.Checked = False
        SGT_CODIGO()
        TabControl1.SelectedTab = (TabPage2)
        txt_cod.Focus()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(4) = 0
        Close()
    End Sub
    Private Sub btn_transf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_transf.Click
        If (MessageBox.Show("Esta seguro de realizar la Transferencia de Gestión Comercial a Contabilidad", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)) = 6 Then
            Try
                Dim cmd1 As New SqlCommand(("INSERT INTO PROYECTO (COD_PROYECTO,DESC_PROYECTO,DESC_CORTA,FECHA_INICIO,FECHA_CIERRE,OBSERVACION) SELECT B.COD_PROYECTO,B.DESC_PROYECTO,B.DESC_CORTA,B.FECHA_INICIO,B.FECHA_CIERRE,B.OBSERVACION FROM  BD_GCO" & COD_EMPRESA & ".dbo.PROYECTO AS B WHERE  B.COD_PROYECTO NOT IN (SELECT COD_PROYECTO FROM PROYECTO)"), con)
                'Dim cmd2 As New SqlCommand(("UPDATE PROYECTO SET FECHA_CIERRE=B.FECHA_CIERRE FROM  BD_GCO" & COD_EMPRESA & ".dbo.PROYECTO AS B WHERE  B.COD_PROYECTO  IN (SELECT COD_PROYECTO FROM PROYECTO)"), con)

                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try

            Try
                'Dim cmd2 As New SqlCommand(("INSERT INTO PROYECTO (COD_PROYECTO,DESC_PROYECTO,DESC_CORTA,FECHA_INICIO,FECHA_CIERRE,OBSERVACION) SELECT B.COD_PROYECTO,B.DESC_PROYECTO,B.DESC_CORTA,B.FECHA_INICIO,B.FECHA_CIERRE,B.OBSERVACION FROM  BD_GCO" & COD_EMPRESA & ".dbo.PROYECTO AS B WHERE  B.COD_PROYECTO NOT IN (SELECT COD_PROYECTO FROM PROYECTO)"), con)
                Dim cmd2 As New SqlCommand(("UPDATE PROYECTO SET FECHA_CIERRE=B.FECHA_CIERRE FROM  BD_GCO" & COD_EMPRESA & ".dbo.PROYECTO AS B   INNER JOIN  PROYECTO A ON A.COD_PROYECTO=B.COD_PROYECTO                         WHERE  B.FECHA_CIERRE IS NOT NULL  AND B.COD_PROYECTO  =A.COD_PROYECTO  "), con)

                con.Open()
                cmd2.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        datagrid()

       
    End Sub
    Sub CARGAR_DATOS()
        txt_cod.Text = dgw1.Item(0, dgw1.CurrentRow.Index).Value.ToString
        txt_desc.Text = dgw1.Item(1, dgw1.CurrentRow.Index).Value.ToString
        txt_desc2.Text = dgw1.Item(2, dgw1.CurrentRow.Index).Value.ToString
        dtp_ini.Value = dgw1.Item(3, dgw1.CurrentRow.Index).Value.ToString
        If (dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString = "") Then
            dtp_cie.Checked = False
            dtp_cie.Value = FECHA_GRAL
        Else
            dtp_cie.Checked = True
            dtp_cie.Value = dgw1.Item(4, dgw1.CurrentRow.Index).Value.ToString
        End If
        txt_obs.Text = dgw1.Item(5, dgw1.CurrentRow.Index).Value.ToString
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_PROYECTO", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@COD_PROYECTO", SqlDbType.Char).Value = txt_cod.Text
            con.Open()
            CONT = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Sub datagrid()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_PROYECTO", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("clase")
            adap.Fill(dt)
            dgw1.DataSource = (dt)
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(3).Visible = False
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(0).Width = (80)
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("ARIAL", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub LIMPIAR()
        txt_cod.Clear()
        txt_desc.Clear()
        txt_desc2.Clear()
        txt_cod.ReadOnly = False
        txt_desc.ReadOnly = False
        txt_desc2.ReadOnly = False
        txt_obs.Clear()
        txt_obs.ReadOnly = False
        dtp_ini.Enabled = True
        dtp_cie.Enabled = True
        dtp_cie.Checked = False
        dtp_ini.Value = FECHA_GRAL
        dtp_cie.Value = FECHA_GRAL
    End Sub
    Sub SGT_CODIGO()
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_PROYECTO", con)
            con.Open()
            SGT = CMD.ExecuteScalar.ToString
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        If (SGT = "") Then
            txt_cod.Text = "00001"
        Else
            txt_cod.Text = SGT
        End If
    End Sub
    Private Sub txt_cod_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cod.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_desc_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_desc2.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_cod.Focus()
        End If
    End Sub
    Private Sub txt_desc2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc2.KeyDown
        If (e.KeyData = Keys.Down) Then
            dtp_ini.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            txt_desc.Focus()
        End If
    End Sub
    Private Sub txt_obs_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_obs.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{TAB}")
        ElseIf (e.KeyData = Keys.Up) Then
            txt_desc2.Focus()
        End If
    End Sub
    Private Sub PROYECTO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PROYECTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        dtp_ini.Value = FECHA_GRAL
        dtp_cie.Value = FECHA_GRAL
        datagrid()
        '---------------------------------------------------------------------------------------
        Dim CU As String = OBJ.DIR_TABLA_DESC("GCO", "TSIST")
        If CU = "SI" Then
            btn_transf.Enabled = True
        Else
            btn_transf.Enabled = False
        End If
        '---------------------------------------------------------------------------------------
        btn_nuevo.Select()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
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
                dtp_ini.Enabled = False
                dtp_cie.Enabled = False
                txt_obs.ReadOnly = True
                btn_guardar.Visible = False
                btn_modificar2.Visible = False
            End If
        End If
    End Sub
End Class