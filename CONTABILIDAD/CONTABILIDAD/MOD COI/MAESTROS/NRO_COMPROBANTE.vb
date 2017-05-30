Imports System.Data.SqlClient
Public Class NRO_COMPROBANTE
    Private AUX As String
    Private boton As String
    Private COMP As String
    Private mes3 As String
    Private obj As New Class1

    Private Sub Bancos2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        datagrid()
        cargar_aux()
        btn_nuevo.Select()
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
        Dim mes2 As String = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
        Dim aux2 As String = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        Dim comp2 As String = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        If (Decimal.Parse((CInt(MessageBox.Show("Desea eliminar el Nro. de Comprobante ", "Borrar Nro. de Comprobante?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            Try
                Dim pro04 As New SqlCommand("Eliminar_NRO_COMPROBANTE", con)
                pro04.CommandType = CommandType.StoredProcedure
                pro04.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
                pro04.Parameters.Add("@mes", SqlDbType.Char).Value = mes2
                pro04.Parameters.Add("@cod_aux", SqlDbType.Char).Value = aux2
                pro04.Parameters.Add("@cod_comp", SqlDbType.Char).Value = comp2
                con.Open()
                pro04.ExecuteNonQuery()
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
        If ((((cbo_aux.SelectedIndex = -1) Or (cbo_comp.SelectedIndex = -1)) Or (cbo_mes.SelectedIndex = -1)) Or (Strings.Trim(txt_nro_comp.Text) = "")) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Select()
        Else
            mes3 = (OBJ.COD_MES(cbo_mes.Text))
            AUX = OBJ.COD_AUX(cbo_aux.Text)
            COMP = OBJ.COD_COMP(cbo_comp.Text, AUX)
            If (CONTAR_REG > 0) Then
                MessageBox.Show("El codigo de Nº de Comprobante ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cbo_mes.Select()
            Else
                Dim I As Integer = Integer.Parse(txt_nro_comp.Text)
                Try
                    Dim pro03 As New SqlCommand("insertar_NRO_COMPROBANTE", con)
                    pro03.CommandType = CommandType.StoredProcedure
                    pro03.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
                    pro03.Parameters.Add("@mes", SqlDbType.Char).Value = mes3
                    pro03.Parameters.Add("@cod_aux", SqlDbType.Char).Value = AUX
                    pro03.Parameters.Add("@cod_comp", SqlDbType.Char).Value = COMP
                    pro03.Parameters.Add("@NUMERACION", SqlDbType.VarChar).Value = I.ToString("0000")
                    con.Open()
                    pro03.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show("La Numeración del comprobante se ha guardado", "Exito al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    limpiar()
                    TabControl1.SelectedTab = TabPage1
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)

                End Try
                datagrid()
                btn_nuevo.Select()
            End If
        End If
    End Sub

    Private Sub btn_modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Modificar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception


            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn_nuevo.Select()

            Return

        End Try
        boton = "modificar"
        btn_guardar.Visible = False
        btn_modificar2.Visible = True
        limpiar()
        cargar_datos()
        cbo_aux.Enabled = False
        cbo_comp.Enabled = False
        cbo_mes.Enabled = False
        TabControl1.SelectedTab = TabPage2
        txt_nro_comp.Focus()
    End Sub

    Private Sub btn_Modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If ((((cbo_aux.SelectedIndex = -1) Or (cbo_comp.SelectedIndex = -1)) Or (cbo_mes.SelectedIndex = -1)) Or (Strings.Trim(txt_nro_comp.Text) = "")) Then
            MessageBox.Show("Debe ingresar todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Select()
        Else
            mes3 = (obj.COD_MES(cbo_mes.Text))
            AUX = obj.COD_AUX(cbo_aux.Text)
            COMP = obj.COD_COMP(cbo_comp.Text, AUX)
            Dim I As Integer = Integer.Parse(txt_nro_comp.Text)
            Try
                Dim pro03 As New SqlCommand("modificar_NRO_COMPROBANTE", con)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
                pro03.Parameters.Add("@mes", SqlDbType.Char).Value = mes3
                pro03.Parameters.Add("@cod_aux", SqlDbType.Char).Value = AUX
                pro03.Parameters.Add("@cod_comp", SqlDbType.Char).Value = COMP
                pro03.Parameters.Add("@NUMERACION", SqlDbType.VarChar).Value = I.ToString("0000")
                con.Open()
                pro03.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("La Numeración del comprobante  se ha Actualizado", "Exito al Modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedTab = TabPage1
            Catch ex As Exception


                con.Close()
                MsgBox(ex.Message)

            End Try
            datagrid()
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_nuevo.Click
        boton = "nuevo"
        btn_guardar.Visible = True
        btn_modificar2.Visible = False
        limpiar()
        TabControl1.SelectedTab = TabPage2
        cbo_mes.Select()
    End Sub

    Private Sub btn_Salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(3) = 0
        Close()
    End Sub

    Public Sub cargar_aux()
        cbo_aux.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub cargar_comp()
        cbo_comp.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX_TODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@cod_aux", SqlDbType.Char).Value = AUX
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_comp.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub cargar_datos()
        mes3 = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
        AUX = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        cbo_aux.Text = (dgw1.Item(3, dgw1.CurrentRow.Index).Value)
        COMP = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        cbo_comp.Text = (dgw1.Item(5, dgw1.CurrentRow.Index).Value)
        txt_nro_comp.Text = (dgw1.Item(6, dgw1.CurrentRow.Index).Value)
        cbo_mes.Text = (obj.DESC_MES(mes3))
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex = -1) Then
            cbo_comp.Items.Clear()
        Else
            AUX = obj.COD_AUX(cbo_aux.Text)
            cargar_comp()
        End If
    End Sub

    Public Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_NRO_COMPROBANTE", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@año", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@mes", SqlDbType.Char).Value = mes3
            CMD.Parameters.Add("@cod_aux", SqlDbType.Char).Value = AUX
            CMD.Parameters.Add("@cod_comp", SqlDbType.Char).Value = COMP
            con.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return CONT
    End Function

    Public Sub datagrid()
        Try
            Dim pro As New SqlCommand("Mostrar_NRO_COMPROBANTE", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(2).Visible = False
            dgw1.Columns.Item(4).Visible = False
            dgw1.Columns.Item(0).Width = 40
            dgw1.Columns.Item(1).Width = 40
            dgw1.Columns.Item(6).Width = 40
            dgw1.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
    End Sub
    Public Sub limpiar()
        txt_nro_comp.Clear()
        txt_nro_comp.Enabled = True
        cbo_aux.SelectedIndex = -1
        cbo_aux.Enabled = True
        cbo_comp.SelectedIndex = -1
        cbo_comp.Enabled = True
        cbo_mes.SelectedIndex = -1
        cbo_mes.Enabled = True
    End Sub

    Private Sub Nro_Comp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_comp.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Public Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "nuevo") Then
                boton = "detalles1"
            ElseIf (boton = "modificar") Then
                boton = "detalles2"
            Else
                boton = "detalles"
                limpiar()
                If (dgw1.RowCount <> 0) Then
                    cargar_datos()
                End If
                cbo_mes.Enabled = False
                cbo_comp.Enabled = False
                cbo_aux.Enabled = False
                btn_modificar2.Visible = False
                btn_guardar.Visible = False
                txt_nro_comp.Enabled = False
            End If
        Else
            btn_nuevo.Select()
        End If
    End Sub

    Private Sub txt_nro_comp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_nro_comp.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{tab}")
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_comp.Select()
        End If
    End Sub

    Private Sub txt_nro_comp_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_nro_comp.KeyPress
        Dim KeyAscii As Short = CShort(Strings.Asc(e.KeyChar))
        If (SoloNumeros(KeyAscii) = 0) Then
            e.Handled = True
        End If
    End Sub

End Class