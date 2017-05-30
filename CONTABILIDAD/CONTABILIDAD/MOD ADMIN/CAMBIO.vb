Imports System.Data.SqlClient
Imports System.Net
Imports System.Web
Imports System.Text
Imports System.Text.RegularExpressions
Public Class CAMBIO
    Private año2, dia2, mes5, mes2, año5, boton, COD_MES2, cod_tipo As String
    Private k As Double
    Private obj As New Class1
    Dim REP As New REP_CAMBIO
    Private objCookie As CookieContainer
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        Try
            Dim PROG_01 As New SqlCommand("MODIFICAR_CAMBIO_MENSUAL", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año2.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = COD_MES2
            PROG_01.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = "D"
            PROG_01.Parameters.Add("@TIPO_VENTA", SqlDbType.Decimal).Value = txt_venta2.Text
            PROG_01.Parameters.Add("@TIPO_COMPRA", SqlDbType.Decimal).Value = txt_compra2.Text
            con2.Open()
            PROG_01.ExecuteNonQuery()
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        MessageBox.Show("El Tipo de Cambio Mensual se actualizó.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub btn_canc3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_canc3.Click
        TabControl1.SelectedTab = TabPage1
        btn_Nuevo.Select()
    End Sub
    Private Sub btn_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Cancelar.Click
        TabControl1.SelectedTab = TabPage1
        btn_Nuevo.Select()
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_eliminar.Click
        Try
            Dim i As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        Dim cod_eliminar As String = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        Dim cod_moneda As String = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
        If (Decimal.Parse((CInt(MessageBox.Show(("Desea eliminar del Dia : " & cod_eliminar & " el Tipo de Cambio: " & cod_moneda), "Borrar Tipo de Cambio?", MessageBoxButtons.YesNo)))) = 6) Then
            Try
                Dim pro04 As New SqlCommand("Eliminar_cambio", con2)
                pro04.CommandType = CommandType.StoredProcedure
                pro04.Parameters.Add("@dia", SqlDbType.VarChar).Value = cod_eliminar
                pro04.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes5
                pro04.Parameters.Add("@año", SqlDbType.VarChar).Value = año5
                pro04.Parameters.Add("@cod_tipo", SqlDbType.VarChar).Value = cod_moneda
                con2.Open()
                pro04.ExecuteNonQuery()
                con2.Close()
                datagrid()
                MessageBox.Show("El tipo de cambio ha sido eliminado", "Eliminar Tipo de Cambio", MessageBoxButtons.OK)
            Catch ex As Exception
                con.Close()
                MessageBox.Show("Error al eliminar, vuelva a intentarlo", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End If
    End Sub
    Function CONTAR_REG() As Integer
        Dim CONT As Integer = 0
        Try
            Dim CMD As New SqlCommand("VERIFICAR_TC", con2)
            CMD.CommandType = CommandType.StoredProcedure
            'CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = 
            CMD.Parameters.Add("@AÑO", SqlDbType.Char).Value = dtp1.Value.Year
            CMD.Parameters.Add("@MES", SqlDbType.Char).Value = dtp1.Value.Month
            CMD.Parameters.Add("@DIA", SqlDbType.Char).Value = dtp1.Value.Day
            CMD.Parameters.Add("@DESC_TIPO", SqlDbType.VarChar).Value = cbo_tipo.SelectedItem
            con2.Open()
            CONT = Integer.Parse(CMD.ExecuteScalar)
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        Return CONT
    End Function
    Private Sub btn_guardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_guardar.Click
        If (((dtp1.Checked = False Or (cbo_tipo.SelectedIndex = -1)) Or (Strings.Trim(txt_venta.Text) = "")) Or (Strings.Trim(txt_compra.Text) = "")) Then
            MessageBox.Show("Debe ingresar los datos importantes:*", "Ingresar datos:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        'If (CONTAR_REG() > 0) Then
        '    MessageBox.Show("El Tipo de Cambio para esa fecha ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    dtp1.Focus() : Exit Sub
        'End If
        año2 = (dtp1.Value.Year) : mes2 = dtp1.Value.ToString("MM") : dia2 = dtp1.Value.ToString("dd")
        Dim c As Integer = 0
        Dim prog03 As New SqlCommand("codigo_cambio", con2)
        prog03.CommandType = CommandType.StoredProcedure
        prog03.Parameters.Add("@año", SqlDbType.VarChar).Value = año2
        prog03.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes2
        prog03.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia2
        prog03.Parameters.Add("@desc_tipo", SqlDbType.VarChar).Value = (cbo_tipo.SelectedItem)
        con2.Open()
        c = Integer.Parse(prog03.ExecuteScalar)
        con2.Close()
        If (c = 0) Then
            Try
                Dim pro03 As New SqlCommand("insertar_cambio", con2)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@año", SqlDbType.VarChar).Value = año2
                pro03.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes2
                pro03.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia2
                pro03.Parameters.Add("@desc_tipo", SqlDbType.VarChar).Value = (cbo_tipo.SelectedItem)
                pro03.Parameters.Add("@compra", SqlDbType.VarChar).Value = txt_compra.Text
                pro03.Parameters.Add("@venta", SqlDbType.VarChar).Value = txt_venta.Text
                con2.Open()
                pro03.ExecuteNonQuery()
                MessageBox.Show("El tipo de cambio se ha guardado", "Guardar Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                con2.Close()
                datagrid()
                limpiar()
                dtp1.Value = dtp1.Value.AddDays(1)
            Catch ex As Exception
                con2.Close()
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("El Tipo de Cambio para esa fecha ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtp1.Focus()
            Exit Sub
        End If
        TabControl1.SelectedTab = TabPage1

    End Sub
    Private Sub btn_Modificar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Modificar.Click
        Try
            Dim I As Integer = dgw1.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        boton = "modificar"
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub btn_modificar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_modificar2.Click
        If (((dtp1.Checked = False Or (cbo_tipo.SelectedIndex = -1)) Or (Strings.Trim(txt_venta.Text) = "")) Or (Strings.Trim(txt_compra.Text) = "")) Then
            MessageBox.Show("Debe ingresar los datos importantes:*", "Ingresar datos:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            año2 = (dtp1.Value.Year)
            mes2 = dtp1.Value.ToString("MM")
            dia2 = dtp1.Value.ToString("dd")
            Try
                Dim pro03 As New SqlCommand("modificar_cambio", con2)
                pro03.CommandType = CommandType.StoredProcedure
                pro03.Parameters.Add("@año", SqlDbType.VarChar).Value = año2
                pro03.Parameters.Add("@mes", SqlDbType.VarChar).Value = mes2
                pro03.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia2
                pro03.Parameters.Add("@desc_tipo", SqlDbType.VarChar).Value = (cbo_tipo.SelectedItem)
                pro03.Parameters.Add("@compra", SqlDbType.Float).Value = txt_compra.Text
                pro03.Parameters.Add("@venta", SqlDbType.Float).Value = txt_venta.Text
                con2.Open()
                pro03.ExecuteNonQuery()
                MessageBox.Show("El tipo de cambio se ha actualizado", "Actualizar Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                con2.Close()
                datagrid()
                TabControl1.SelectedTab = TabPage1
                btn_Nuevo.Select()
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btn_Nuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Nuevo.Click
        limpiar()
        boton = "nuevo"
        TabControl1.SelectedTab = TabPage2
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (cbo_moneda2.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_moneda2.Focus()
        Else
            If (DateTime.Compare(dtp_del.Value, dtp_al.Value) > 0) Then
                MessageBox.Show("El Rango es incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dtp_del.Focus()
            End If
            Dim COD_MON As String = obj.COD_MONEDA(cbo_moneda2.Text)
        End If
        '-------------------------------
        REP.cod_mon = obj.COD_MONEDA(cbo_moneda2.Text)
        REP.DESC_MON = cbo_moneda2.Text
        REP.del = dtp_del.Value.Date
        REP.al = dtp_al.Value.Date
        REP.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(89) = 0
        Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabPage1
        btn_Nuevo.Select()
    End Sub
    Private Sub Cambio_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cambio_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        dgw_tc_mensual.Visible = False
        cargar_monedas()
        CARGAR_AÑO()
        mes5 = FECHA_INI.ToString("MM")
        año5 = FECHA_INI.Year
        cbo_año.Text = FECHA_INI.Year
        cbo_año2.Text = FECHA_INI.Year
        cbo_mes.Text = FECHA_INI.ToString("MM")
        cbo_mes2.Text = FECHA_INI.ToString("MMMM").ToUpper
        Dim COD_MES2 As String = obj.COD_MES(cbo_mes2.Text)
        HALLAR_CIERRE(cbo_año2.Text, COD_MES2)
        Dim FEC As DateTime = DateTime.Parse(("01/" & FECHA_INI.ToString("MM") & "/" & (FECHA_INI.Year)))
        dtp1.Value = FEC
        dgw_tc_mensual.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        btn_Nuevo.Select()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        cbo_año2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_AÑO_TODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            'PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
                cbo_año2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cargar_datos()
        Dim dia3 As String = (dgw1.Item(0, dgw1.CurrentRow.Index).Value)
        Dim tipo As String = (dgw1.Item(1, dgw1.CurrentRow.Index).Value)
        cbo_tipo.Text = (dgw1.Item(2, dgw1.CurrentRow.Index).Value)
        txt_venta.Text = (dgw1.Item(3, dgw1.CurrentRow.Index).Value)
        txt_compra.Text = (dgw1.Item(4, dgw1.CurrentRow.Index).Value)
        Dim año3 As String = (dgw1.Item(5, dgw1.CurrentRow.Index).Value)
        Dim mes3 As String = (dgw1.Item(6, dgw1.CurrentRow.Index).Value)
        Dim d As DateTime = DateTime.Parse(String.Concat(New String() {dia3, "/", mes3, "/", año3}))
        dtp1.Text = (d)
    End Sub
    Sub cargar_monedas()
        Try
            Dim PROG_01 As New SqlCommand("cargar_moneda2", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo.Items.Add(Rs3.GetString(0))
                cbo_moneda2.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub cbo_año_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_año.SelectedIndexChanged
        If (cbo_año.SelectedIndex <> -1) Then
            año5 = (cbo_año.SelectedItem)
            datagrid()
            If (dgw1.RowCount = 0) Then
                MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "No existen registro:", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub
    Private Sub cbo_año2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_año2.SelectedIndexChanged
        If ((cbo_año2.SelectedIndex <> -1) And (cbo_mes2.SelectedIndex <> -1)) Then
            COD_MES2 = (obj.COD_MES(cbo_mes2.Text))
            HALLAR_CIERRE(cbo_año2.Text, COD_MES2)
        End If
    End Sub
    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If (cbo_año.SelectedIndex <> -1) Then
            mes5 = cbo_mes.Text
            datagrid()
            If (dgw1.RowCount = 0) Then
                MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "No existen registros:", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
    End Sub
    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes2.SelectedIndexChanged
        If (cbo_año2.SelectedIndex <> -1 And cbo_mes2.SelectedIndex <> -1) Then
            COD_MES2 = (obj.COD_MES(cbo_mes2.Text))
            HALLAR_CIERRE(cbo_año2.Text, COD_MES2)
        End If
    End Sub
    Sub datagrid()
        Try
            Dim pro As New SqlCommand("Mostrar_cambio", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.Char).Value = año5
            pro.Parameters.Add("@mes", SqlDbType.Char).Value = mes5
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(1).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(0).Width = 40
            dgw1.Columns.Item(2).Width = 140
            dgw1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dtp1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dtp1.ValueChanged
        año2 = (dtp1.Value.Year)
        mes2 = dtp1.Value.ToString("MM")
        dia2 = dtp1.Value.ToString("dd")
    End Sub
    Sub HALLAR_CIERRE(ByVal AÑO0 As Object, ByVal MES0 As Object)
        txt_venta2.Text = "0.0000"
        txt_compra2.Text = "0.0000"
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_CAMBIO_MENSUAL", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (MES0)
            PROG_01.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = "D"
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                txt_venta2.Text = Rs3.GetValue(0)
                txt_compra2.Text = Rs3.GetValue(1)
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub limpiar()
        dtp1.Enabled = True
        cbo_tipo.SelectedIndex = -1
        txt_compra.Clear()
        txt_venta.Clear()
        cbo_tipo.Enabled = True
        txt_compra.ReadOnly = False
        txt_venta.ReadOnly = False
        cbo_tipo.Focus()
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
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If (TabControl1.SelectedTab Is TabPage2) Then
            If (boton = "nuevo") Then
                boton = "detalles1"
                limpiar()
                btn_modificar2.Visible = False
                btn_guardar.Visible = True
                cbo_tipo.Focus()
            ElseIf (boton = "modificar") Then
                boton = "detalles2"
                limpiar()
                cargar_datos()
                dtp1.Enabled = False
                cbo_tipo.Enabled = False
                btn_modificar2.Visible = True
                btn_guardar.Visible = False
            Else
                boton = "detalles"
                limpiar()
                If (dgw1.RowCount <> 0) Then
                    cargar_datos()
                End If
                dtp1.Enabled = False
                cbo_tipo.Enabled = False
                txt_compra.ReadOnly = True
                txt_venta.ReadOnly = True
            End If
        End If
    End Sub
    Private Sub txt_compra_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_compra.KeyDown
        If (e.KeyData = Keys.Down) Then
            txt_venta.Focus()
        ElseIf (e.KeyData = Keys.Up) Then
            cbo_tipo.Focus()
        End If
    End Sub
    Private Sub txt_compra_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_compra.KeyPress
        e.Handled = Numero(e, txt_compra)
    End Sub
    Private Sub txt_compra_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_compra.LostFocus
        If (txt_compra.Text <> "") Then
            Try
                txt_compra.Text = (obj.HACER_CAMBIO(txt_compra.Text))
            Catch ex As Exception


                MessageBox.Show("El tipo de Compra no es valido", "Ingrese otra vez")
                txt_compra.Text = "0.0000"

            End Try
        End If
    End Sub
    Private Sub txt_compra2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_compra2.KeyPress
        e.Handled = Numero(e, txt_compra2)
    End Sub
    Private Sub txt_compra2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_compra2.LostFocus
        If (txt_compra2.Text <> "") Then
            Try
                txt_compra2.Text = (obj.HACER_CAMBIO(txt_compra2.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Compra no es valido", "Ingrese otra vez")
                txt_compra2.Text = "0.0000"
            End Try
        End If
    End Sub
    Private Sub txt_venta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_venta.KeyDown
        If (e.KeyData = Keys.Down) Then
            SendKeys.Send("{TAB}")
        ElseIf (e.KeyData = Keys.Up) Then
            txt_compra.Focus()
        End If
    End Sub
    Private Sub txt_venta_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_venta.KeyPress
        e.Handled = Numero(e, txt_venta)
    End Sub
    Private Sub txt_venta_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_venta.LostFocus
        If (txt_venta.Text <> "") Then
            Try
                txt_venta.Text = (obj.HACER_CAMBIO(txt_venta.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Venta no es valido", "Ingrese otra vez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_venta.Text = "0.0000"
            End Try
        End If
    End Sub
    Private Sub txt_venta2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txt_venta2.KeyPress
        e.Handled = Numero(e, txt_venta2)
    End Sub
    Private Sub txt_venta2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_venta2.LostFocus
        If (txt_venta2.Text <> "") Then
            Try
                txt_venta2.Text = (obj.HACER_CAMBIO(txt_venta2.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Venta no es valido", "Ingrese otra vez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_venta2.Text = "0.0000"
            End Try
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        dgw_tc_mensual.Visible = True
        dgw_tc_mensual.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CONSULTA_TC_MENSUAL", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año2.Text
            PROG_01.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = "D"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_tc_mensual.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        cbo_tipo.Text = "DOLARES AMERICANOS"
        dtp1.Value = Date.Now

        If cbo_tipo.Text <> "DOLARES AMERICANOS" Then
            MessageBox.Show("Seleccione DOLARES AMERICANOS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbo_tipo.Focus()
        ElseIf Date.Now.Date <> dtp1.Value.Date Then
            MessageBox.Show("Seleccione la fecha de hoy", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtp1.Focus()
        Else
            Try

                Dim myUrl As String = "http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias"
                Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(myUrl), HttpWebRequest)
                myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0"
                myWebRequest.CookieContainer = objCookie

                myWebRequest.Credentials = CredentialCache.DefaultCredentials
                myWebRequest.Proxy = Nothing
                Dim myHttpWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
                Dim myStream As IO.Stream = myHttpWebResponse.GetResponseStream()
                Dim myStreamReader As IO.StreamReader = New IO.StreamReader(myStream)
                'Leemos los datos
                Dim xDat As String = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd())
                Dim tabla As String()
                xDat = xDat.Replace("     ", " ")
                xDat = xDat.Replace("    ", " ")
                xDat = xDat.Replace("   ", " ")
                xDat = xDat.Replace("  ", " ")
                xDat = xDat.Replace("( ", "(")
                xDat = xDat.Replace(" )", ")")

                tabla = Regex.Split(xDat, "<td")
                Dim builder As StringBuilder = New StringBuilder()
                Dim listaTipoCambio As New List(Of String)
                For index As Integer = 14 To tabla.Length
                    Dim principio As String
                    Dim final As String
                    Dim posicion1 As Integer
                    Dim posicion2 As Integer


                    '======================= Buscar Tipo Cambio =======================
                    Dim tamaño As Integer = Len(tabla(index))

                    If tamaño > 600 Then
                        Exit For
                    End If
                    principio = ">"
                    final = "</td>"
                    posicion1 = InStr(tabla(index), principio)
                    posicion1 += 1
                    posicion2 = InStr(posicion1, tabla(index), final)
                    Dim dato As String = Mid(tabla(index), posicion1, posicion2 - posicion1)

                    Select Case index
                        Case 14, 17, 20, 23, 26, 29, 32, 35, 38, 41, 44, 47, 50, 53, 56, 59, 62, 65, 68, 71, 74, 77, 80
                            principio = ">"
                            final = "</strong>"
                            posicion1 = InStr(dato, principio)
                            posicion1 += 1
                            posicion2 = InStr(posicion1, dato, final)
                            dato = Mid(dato, posicion1, posicion2 - posicion1)
                    End Select

                    listaTipoCambio.Add(dato)
                Next
                MessageBox.Show("Ha obtenido el tipo de cambio para: " & Date.Now.Date, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_compra.Text = Decimal.Parse(listaTipoCambio.Item(listaTipoCambio.Count() - 2))
                txt_venta.Text = Decimal.Parse(listaTipoCambio.Item(listaTipoCambio.Count() - 1))
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


    End Sub
End Class