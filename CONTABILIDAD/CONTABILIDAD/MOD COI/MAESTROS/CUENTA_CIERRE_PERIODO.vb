Imports System.Data.SqlClient
Public Class CUENTA_CIERRE_PERIODO
#Region "CONSTRUCTOR"
    Private Shared INSTANCIA As CUENTA_CIERRE_PERIODO
    Public Shared Function OBTENERINSTANCIA() As CUENTA_CIERRE_PERIODO
        If INSTANCIA Is Nothing OrElse INSTANCIA.IsDisposed Then
            INSTANCIA = New CUENTA_CIERRE_PERIODO
        End If
        INSTANCIA.BringToFront()
        Return INSTANCIA
    End Function
    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

    Dim ESTADO As String = ""

    Private Sub CUENTA_CIERRE_PERIODO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub CUENTA_CIERRE_PERIODO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        MANT_CIERRE_CUENTA()
    End Sub
    Sub MANT_CIERRE_CUENTA()
        Dim CMD As New SqlCommand("MANT_CUENTA_CIERRE", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim DT As New DataTable("CIERRE_CUENTA")
        ADAP.Fill(DT)
        dgw.DataSource = (DT)
        dgw.Columns.Item(0).Width = 40
        dgw.Columns.Item(0).HeaderText = "Sec."
        dgw.Columns.Item(1).Width = 470
        dgw.Columns.Item(2).Width = 60
        dgw.Columns.Item(2).HeaderText = "Cuenta"
        dgw.Columns.Item(3).Visible = False
        dgw.Columns.Item(4).Visible = False
        dgw.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        ESTADO = "NUEVO"
        limpiar()
        BUSCAR_CUENTA()
        BUSCAR_CUENTA1()
        GENERAR_SEC()
        TabControl1.SelectedTab = TabPage2
        PAN_CUENTA.Visible = False
        txt_desc_cuenta.ReadOnly = True
        btn_imprimir.Enabled = False
        btn_guardar.Enabled = True
        panel_det.Enabled = True
        GroupBox1.Enabled = True
        Panel0.Enabled = True
        dgw_det.Enabled = True
        txt_cuenta.Enabled = True
        txt_glosa.Enabled = True
        txt_nro_comp.Enabled = True
        txt_glosa.Focus()
        'txt_nro_comp.ReadOnly = False
        chk_mod.Enabled = False
        chk_mod.Checked = False
        txt_cuenta.Enabled = True
        txt_glosa.Enabled = True
    End Sub
    Sub GENERAR_SEC()
        Dim cmd As New SqlCommand("SELECT MAX(NRO_SECUENCIA) FROM CUENTA_CIERRE", con)
        cmd.CommandType = CommandType.Text
        con.Open()
        Dim n As Object = cmd.ExecuteScalar
        If dgw.Rows.Count = 0 Then
            txt_nro_comp.Text = "01"
        Else
            txt_nro_comp.Text = Format(n + 1, "00")
        End If
        con.Close()
    End Sub
    Sub limpiar()
        dgw_cuenta.DataSource = Nothing
        dgw_det.Rows.Clear()
        txt_cuenta.Clear()
        txt_glosa.Clear()
        txt_nro_comp.Clear()
        txt_desc_cuenta.Clear()
        btn_imprimir.Enabled = False
        BUSCAR_CUENTA()
    End Sub
    Sub BUSCAR_CUENTA()
        dgw_cuenta.DataSource = Nothing
        Dim CMD As New SqlCommand("MOSTRAR_CUENTA_AÑO", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@ST_NIVEL", SqlDbType.Char).Value = "0"
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim DT As New DataTable("MOSTRAR_CUENTA")
        ADAP.Fill(DT)
        dgw_cuenta.DataSource = (DT)
        dgw_cuenta.Columns.Item(0).Width = 100
        dgw_cuenta.Columns.Item(1).Width = 250
        dgw_cuenta.Columns.Item(2).Width = 40
        dgw_cuenta.Columns.Item(2).HeaderText = "Nivel"
        dgw_cuenta.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
    End Sub
    Sub BUSCAR_CUENTA1()
        dgw_cuenta2.DataSource = Nothing
        Dim CMD As New SqlCommand("MOSTRAR_CUENTA_AÑO", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@ST_NIVEL", SqlDbType.Char).Value = "1"
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim DT As New DataTable("MOSTRAR_CUENTA")
        ADAP.Fill(DT)
        dgw_cuenta2.DataSource = (DT)
        dgw_cuenta2.Columns.Item(0).Width = 100
        dgw_cuenta2.Columns.Item(1).Width = 250
        dgw_cuenta2.Columns.Item(2).Width = 60
        dgw_cuenta2.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
    End Sub

    Private Sub txt_cuenta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cuenta.LostFocus
        If (Strings.Trim(txt_cuenta.Text) <> "") Then
            If (dgw_cuenta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta.Sort(dgw_cuenta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cuenta.Text.ToLower = dgw_cuenta.Item(0, i).Value.ToString.ToLower) Then
                        txt_cuenta.Text = dgw_cuenta.Item(0, i).Value.ToString
                        txt_desc_cuenta.Text = dgw_cuenta.Item(1, i).Value.ToString
                        TXT_NIVEL_CAB.Text = dgw_cuenta.Item(2, i).Value.ToString
                        '---------------------------------------------------
                        btn_agregar.Focus()
                        Return
                    End If
                    If (txt_cuenta.Text.ToLower = Strings.Mid((dgw_cuenta.Item(0, i).Value), 1, Strings.Len(txt_cuenta.Text)).ToLower) Then
                        dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta.CurrentCell = dgw_cuenta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PAN_CUENTA.Visible = True
                dgw_cuenta.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_cuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cuenta.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cuenta.Text = dgw_cuenta.Item(0, dgw_cuenta.CurrentRow.Index).Value.ToString
            txt_desc_cuenta.Text = dgw_cuenta.Item(1, dgw_cuenta.CurrentRow.Index).Value.ToString
            TXT_NIVEL_CAB.Text = dgw_cuenta.Item(2, dgw_cuenta.CurrentRow.Index).Value.ToString
            PAN_CUENTA.Visible = False
            Panel0.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            PAN_CUENTA.Visible = False
            txt_cuenta.Clear()
            txt_desc_cuenta.Clear()
        End If
    End Sub

    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        limpiar()
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_nuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo2.Click
        limpiar()
        ESTADO = "NUEVO"
        BUSCAR_CUENTA()
        BUSCAR_CUENTA1()
        PAN_CUENTA.Visible = False
        TabControl1.SelectedTab = TabPage2
        txt_desc_cuenta.ReadOnly = True
        btn_imprimir.Enabled = False
        btn_guardar.Enabled = True
        panel_det.Enabled = True
        GroupBox1.Enabled = True
        Panel0.Enabled = True
        dgw_det.Enabled = True
        txt_cuenta.Enabled = True
        txt_glosa.Enabled = True
        txt_nro_comp.Enabled = True
        GENERAR_SEC()
        txt_glosa.Focus()
        chk_mod.Enabled = False
        chk_mod.Checked = False
        txt_cuenta.Enabled = True
        txt_glosa.Enabled = True
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        Dim NRO_SEC, COD_CUENTA As String
        If dgw.Rows.Count = 0 Then MessageBox.Show("No hay registros para eliminar", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If dgw.CurrentRow.Index < 0 Then MessageBox.Show("Debe selecionar un registro", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : dgw.Focus() : Exit Sub
        Dim CONT As Integer = dgw.Rows.Count - 1
        If dgw.Item(0, dgw.CurrentRow.Index).Value = dgw.Item(0, CONT).Value Then
            NRO_SEC = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
            COD_CUENTA = dgw.Item(2, dgw.CurrentRow.Index).Value.ToString
            ELIMINAR_CUENTA_CIERRE(NRO_SEC, COD_CUENTA)
            MANT_CIERRE_CUENTA()
        Else
            MessageBox.Show("No se puede eliminar la secuencia", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : btn_modificar.Focus() : Exit Sub
        End If
    End Sub
    Sub ELIMINAR_CUENTA_CIERRE(ByVal NRO_SECUENCIA As String, ByVal COD_CUENTA As String)
        Dim CMD As New SqlCommand("DELETE_CUENTA_CIERRRE", con)
        con.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@NRO_SECUENCIA", SqlDbType.Char).Value = NRO_SECUENCIA
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CUENTA
        CMD.ExecuteNonQuery()
        con.Close()
        '------
        CMD = New SqlCommand("DELETE_CUENTA_CIERRRE_DET", con)
        con.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@NRO_SECUENCIA", SqlDbType.Char).Value = NRO_SECUENCIA
        CMD.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Registro eliminado correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btn_cancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar2.Click
        Panel_new_det.Visible = False
        panel_det.Visible = True
        btn_agregar.Focus()
        txt_cuenta2.Clear()
        txt_nivel.Clear()
        txt_des_cuenta2.Clear()
    End Sub

    Private Sub btn_agregar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar2.Click
        If txt_cuenta2.Text = "" Then MessageBox.Show("Debe ingresar la Cuenta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cuenta2.Focus() : Exit Sub
        If txt_cuenta.Text = txt_cuenta2.Text Then MessageBox.Show("La cuenta no puede ser igual a la cuenta de cabecera", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cuenta2.Focus() : Exit Sub
        If VERIFICAR_CUENTA() = True Then
            dgw_det.Rows.Add(txt_cuenta2.Text, txt_des_cuenta2.Text, txt_nivel.Text)
        End If
        txt_cuenta2.Clear()
        txt_nivel.Clear()
        txt_des_cuenta2.Clear()
        txt_cuenta2.Focus()
    End Sub
    Function VERIFICAR_CUENTA()
        Dim CONT As Integer = dgw_det.Rows.Count
        Dim I As Integer = 0
        Dim RSLT As Boolean = True
        If CONT > 0 Then
            While I <> CONT
                If dgw_det.Item(0, I).Value = txt_cuenta2.Text Then
                    MessageBox.Show("La cuenta ya existe.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cuenta2.Focus() : Exit Function
                    RSLT = False
                End If
                I += 1
            End While
        End If
        Return RSLT
    End Function

    Private Sub dgw_cuenta2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cuenta2.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cuenta2.Text = dgw_cuenta2.Item(0, dgw_cuenta2.CurrentRow.Index).Value.ToString
            txt_des_cuenta2.Text = dgw_cuenta2.Item(1, dgw_cuenta2.CurrentRow.Index).Value.ToString
            txt_nivel.Text = dgw_cuenta2.Item(2, dgw_cuenta2.CurrentRow.Index).Value.ToString
            pan_cuenta_2.Visible = False
            txt_des_cuenta2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            pan_cuenta_2.Visible = False
            txt_cuenta2.Clear()
            txt_des_cuenta2.Clear()
        End If
    End Sub

    Private Sub txt_cuenta2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cuenta2.LostFocus
        If (Strings.Trim(txt_cuenta2.Text) <> "") Then
            If (dgw_cuenta2.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta2.Sort(dgw_cuenta2.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta2.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cuenta2.Text.ToLower = dgw_cuenta2.Item(0, i).Value.ToString.ToLower) Then
                        txt_cuenta2.Text = dgw_cuenta2.Item(0, i).Value.ToString
                        txt_des_cuenta2.Text = dgw_cuenta2.Item(1, i).Value.ToString
                        txt_nivel.Text = dgw_cuenta2.Item(2, i).Value.ToString
                        '---------------------------------------------------
                        txt_des_cuenta2.Focus()
                        Return
                    End If
                    If (txt_cuenta2.Text.ToLower = Strings.Mid((dgw_cuenta2.Item(0, i).Value), 1, Strings.Len(txt_cuenta2.Text)).ToLower) Then
                        dgw_cuenta2.CurrentCell = dgw_cuenta2.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta2.CurrentCell = dgw_cuenta2.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                pan_cuenta_2.Visible = True
                dgw_cuenta2.Focus()
            End If
        End If
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If txt_nro_comp.Text = "" Then MessageBox.Show("Debe ingresar NºComprobante", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_nro_comp.Focus() : Exit Sub
        If txt_glosa.Text = "" Then MessageBox.Show("Debe ingresar Glosa", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_glosa.Focus() : Exit Sub
        If txt_cuenta.Text = "" Then MessageBox.Show("Debe ingresar Cuenta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cuenta.Focus() : Exit Sub
        btn_agregar2.Visible = True
        panel_det.Visible = False
        Panel_new_det.Visible = True
        txt_cuenta2.Focus()
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar2.Click
        Try
            Dim num As Integer = dgw_det.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If ((CInt(MessageBox.Show("Eliminar Detalle", "ESTA SEGURO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6 Then
            dgw_det.Rows.RemoveAt(dgw_det.CurrentRow.Index)
        End If
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If txt_nro_comp.Text = "" Then MessageBox.Show("Debe ingresar NºComprobante", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_nro_comp.Focus() : Exit Sub
        If txt_glosa.Text = "" Then MessageBox.Show("Debe ingresar Glosa", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_glosa.Focus() : Exit Sub
        If txt_cuenta.Text = "" Then MessageBox.Show("Debe ingresar Cuenta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cuenta.Focus() : Exit Sub
        If TXT_NIVEL_CAB.Text <> "5" Or txt_cuenta.TextLength <> 8 Then MessageBox.Show("El nivel de la Cuenta en Cabecera no es Correcto", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : txt_cuenta.Focus() : Exit Sub
        If ESTADO = "NUEVO" Then
            If VERIFICAR_EXISTS_CUENTA() = True Then Exit Sub
            INSERT_CAB()
            INSERT_DET()
            MANT_CIERRE_CUENTA()
        Else
            ELIMINAR(txt_nro_comp.Text, dgw.Item(2, dgw.CurrentRow.Index).Value)
            INSERT_CAB()
            INSERT_DET()
            MANT_CIERRE_CUENTA()
        End If
        GroupBox1.Enabled = False
        dgw_det.Enabled = False
        Panel0.Enabled = False
        Panel5.Enabled = True
        btn_imprimir.Enabled = True
        btn_guardar.Enabled = False
    End Sub
    Sub ELIMINAR(ByVal NRO_SECUENCIA As String, ByVal COD_CUENTA As String)
        Dim CMD As New SqlCommand("DELETE_CUENTA_CIERRRE", con)
        con.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@NRO_SECUENCIA", SqlDbType.Char).Value = NRO_SECUENCIA
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CUENTA
        CMD.ExecuteNonQuery()
        con.Close()
        '------
        CMD = New SqlCommand("DELETE_CUENTA_CIERRRE_DET", con)
        con.Open()
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@NRO_SECUENCIA", SqlDbType.Char).Value = NRO_SECUENCIA
        CMD.ExecuteNonQuery()
        con.Close()
    End Sub
    Sub INSERT_CAB()
        Dim CMD As New SqlCommand("INSERT_CUENTA_CIERRE", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@NRO_SEC", SqlDbType.Char).Value = txt_nro_comp.Text
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = txt_cuenta.Text
        CMD.Parameters.Add("@GLOSA", SqlDbType.Char).Value = txt_glosa.Text
        CMD.Parameters.Add("@NIVEL", SqlDbType.Char).Value = TXT_NIVEL_CAB.Text
        con.Open()
        CMD.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Se Guardo el Cierre de Cuenta", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : BTN_CANCELAR.Focus() : Exit Sub
    End Sub
    Function VERIFICAR_EXISTS_CUENTA() As Boolean
        Dim RSLT As Boolean
        con.Open()
        Dim CMD As New SqlCommand("[VERIFICAR_EXISTS_CUENTA_CIERRE]", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@NRO_SEC", SqlDbType.Char).Value = txt_nro_comp.Text
        Dim CONT As Integer
        CONT = CMD.ExecuteScalar
        con.Close()
        If CONT <> 0 Then MessageBox.Show(String.Format("Ya ha sido cerrado una cuenta con el NºComprobante {0}", txt_nro_comp.Text), "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If CONT <> 0 Then
            RSLT = True
        Else
            RSLT = False
        End If
        Return RSLT
    End Function
    Sub INSERT_DET()
        Dim DT00 As New DataTable
        DT00.Columns.Add("NRO_SEC")
        DT00.Columns.Add("COD_CUENTA")
        Dim str2 As String
        Dim str As String = "FALLO"
        Dim copy As New SqlBulkCopy(con)
        Dim CantidadFilas As Integer = dgw_det.Rows.Count - 1
        Dim ListaSerie As New ArrayList
        DT00.Rows.Clear()
        Dim i As Integer = 0
        Do While (i <= CantidadFilas)
            DT00.Rows.Add(txt_nro_comp.Text, dgw_det.Item(0, i).Value)
            i += 1
        Loop

        Try
            con.Open()
            copy.DestinationTableName = ("[dbo].[CUENTA_CIERRE_DETALLE]")
            copy.WriteToServer(DT00)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            DT00.Rows.Clear()
        End Try
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar.Click
        ESTADO = "MODIFICAR"
        Try
            Dim index As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        limpiar()
        GroupBox1.Enabled = True
        txt_cuenta.Enabled = False
        txt_desc_cuenta.Enabled = False
        txt_nro_comp.Enabled = False
        chk_mod.Checked = False
        chk_mod.Enabled = True
        txt_glosa.Enabled = False
        panel_det.Enabled = True
        Panel0.Enabled = True
        dgw_det.Enabled = True
        btn_guardar.Enabled = True
        CARGAR_CABECERA()
        CARGAR_DET()
        BUSCAR_CUENTA()
        BUSCAR_CUENTA1()
        TabControl1.SelectedTab = TabPage2
        btn_agregar.Focus()
    End Sub
    Sub CARGAR_CABECERA()
        txt_nro_comp.Text = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        TXT_NIVEL_CAB.Text = dgw.Item(3, dgw.CurrentRow.Index).Value.ToString
        txt_cuenta.Text = dgw.Item(2, dgw.CurrentRow.Index).Value.ToString
        txt_glosa.Text = dgw.Item(1, dgw.CurrentRow.Index).Value.ToString
        txt_desc_cuenta.Text = dgw.Item(4, dgw.CurrentRow.Index).Value.ToString
    End Sub
    Sub CARGAR_DET()
        Dim CMD As New SqlCommand("MOSTRAR_CUENTA_CIERRE_DET", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@NRO_SEC", SqlDbType.Char).Value = dgw.Item(0, dgw.CurrentRow.Index).Value.ToString
        con.Open()
        Dim DR As SqlDataReader = CMD.ExecuteReader
        While DR.Read
            dgw_det.Rows.Add(DR.GetValue(0), DR.GetValue(1), DR.GetValue(2))
        End While
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim index As Integer = dgw.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        limpiar()
        GroupBox1.Enabled = False
        panel_det.Enabled = True
        Panel0.Enabled = True
        dgw_det.Enabled = True
        btn_guardar.Enabled = True
        btn_guardar.Enabled = False
        CARGAR_CABECERA()
        CARGAR_DET()
        TabControl1.SelectedTab = TabPage2
        btn_agregar.Focus()
    End Sub

    Private Sub chk_mod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_mod.CheckedChanged
        If chk_mod.Checked = False Then
            txt_cuenta.Enabled = False
            txt_glosa.Enabled = False
        Else
            txt_cuenta.Enabled = True
            txt_glosa.Enabled = True
        End If
    End Sub
End Class