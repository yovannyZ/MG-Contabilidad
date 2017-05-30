Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Public Class Inicio
    Dim clave, codigo, estado As String
    Private obj As New Class1

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar1.Click
        If (cbo_empresa.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la empresa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_empresa.Focus()
        ElseIf (cbo_usuario.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir la Usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_usuario.Focus()
        ElseIf (Strings.Trim(txt_c.Text) = "") Then
            MessageBox.Show("Debe ingresar la contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_c.Focus()
        Else
            'Hacemos la validación de la fecha de licencia
            Dim Licencia As String = RecuperarFechaLicencia(cbo_empresa.Text)
            'Validamos si tiene licencia
            If Licencia.ToString.Length > 0 Then
                Dim FechaLicencia As Date = Convert.ToDateTime(obj.DesencriptarFecha(Licencia)).Date
                Dim FechaSistema As Date = Date.Now.Date
                Dim Dias As Integer = DateDiff(DateInterval.Day, FechaSistema, FechaLicencia)
                If FechaSistema <= FechaLicencia Then
                    If Dias <= 10 Then
                        If Dias = 0 Then
                            MessageBox.Show("La licencia expira mañana", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            MessageBox.Show("Le quedan " & Dias.ToString & " días de licencia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    MessageBox.Show("Licencia Expirada" + Chr(13) + "Consulte con su Proveedor", "Gestión Comercial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Close()
                End If
            Else
                MessageBox.Show("El aplicativo no tiene una licencia activa", "Mensaje")
                Close()
            End If
            '--------------------------------------------------
            DESC_EMPRESA = cbo_empresa.Text
            COD_EMPRESA = obj.COD_EMPRESA(cbo_empresa.SelectedItem)
            Dim datosEmpresa As ArrayList = obj.DATOS_EMPRESA(COD_EMPRESA)
            RUC_EMPRESA = datosEmpresa(0)
            FONO_EMPRESA = datosEmpresa(1)
            EMAIL_EMPRESA = datosEmpresa(2)
            DIR_EMPRESA = datosEmpresa(3)
            DESC_CORTA_EMPRESA = datosEmpresa(4)
            DireccionEmpresa = obj.HallarDireccionEmpresa(COD_EMPRESA)
            WEB_EMPRESA = ""
            TIPO_USU = obj.TIPO_USU(cbo_usuario.Text)
            COD_USU = lbl_codigo.Text
            DESC_USU = cbo_usuario.Text
            Try
                Dim PROG_01 As New SqlCommand("clave_usuario", con2)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@codigo", SqlDbType.Char).Value = lbl_codigo.Text
                con2.Open()
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    clave = Rs3.GetString(0)
                Loop
                con2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                con2.Close()
            End Try
            'VALIDAR CONTRASEÑA
            If clave <> obj.Encriptar(txt_c.Text) Then
                MessageBox.Show("La contraseña es incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_c.Focus()
                txt_c.SelectAll()
                Exit Sub
            End If
            'VALIDAR EMPRESA
            '--------------------
            If (TIPO_USU = "MS") Then
                INSERTAR_CONECTADOS()
            ElseIf (validar_usuario() = "SI") Then
                INSERTAR_CONECTADOS()
            ElseIf (TIPO_USU = "AD") Then
                MessageBox.Show(("No se encuentra autorizado para la empresa " & cbo_empresa.Text), "Tipo de Usuario : Administrador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If HALLAR_SERIE() = CREAR_SERIE() Then
            Else
                MessageBox.Show("El Nº de Serie es incorrecto", "No puede ingresar al Programa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If chkRecordar.Checked Then
                My.Settings.EMPRESA = cbo_empresa.Text
                My.Settings.USUARIO = cbo_usuario.Text
            Else
                My.Settings.EMPRESA = ""
                My.Settings.USUARIO = ""
            End If
            My.Settings.Save()
            My.Settings.Reload()
            con.ConnectionString = "data source=" & nombre_servidor & ";initial catalog=BD_COI" & COD_EMPRESA & ";uid=miguel;pwd=main;Connection Timeout=0;Asynchronous Processing=true;MultipleActiveResultSets=True"
            Hide()
            My.Forms.Iconos.Text = ("Empresa : " & DESC_EMPRESA)
            My.Forms.Iconos.Show()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Close()
        obj.ELIMINAR_CONECTADO()
        End
    End Sub

    Public Sub cargar_usuario()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_usuario2", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_usuario.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub
    Private Sub cbo_usuario_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_usuario.SelectedIndexChanged
        txt_c.Clear()
        If (cbo_usuario.SelectedIndex <> -1) Then
            txt_c.Enabled = True
            Try
                Dim PROG_01 As New SqlCommand("cod_usuario", con2)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@nick", SqlDbType.VarChar).Value = (cbo_usuario.SelectedItem)
                con2.Open()
                lbl_codigo.Text = (PROG_01.ExecuteScalar)
                codigo = lbl_codigo.Text
                con2.Close()
            Catch ex As Exception


                MessageBox.Show(ex.Message)

            Finally
                con2.Close()
            End Try
        End If
    End Sub

    Public Function CREAR_SERIE() As String
        Dim COD_EMP0 As String = COD_EMPRESA
        Dim DESC_EMP0 As String = cbo_empresa.Text
        Dim COD_SIS0 As String = "COI"
        Dim DESC_SIS0 As String = "CONTABILIDAD"
        Return String.Concat(New String() {COD_EMP0, COD_SIS0, COD_EMP0, (DESC_EMP0.Length), (DESC_SIS0.Length), (CInt((DESC_EMP0.Length - DESC_SIS0.Length))), (CInt((DESC_SIS0.Length - DESC_EMP0.Length)))})
    End Function



    Public Sub HALLAR_BASE()
        Try
        Catch ex As Exception



        End Try
    End Sub

    Public Function HALLAR_SERIE() As String
        Dim SERIE As String = ""
        Try
            Dim CMD As New SqlCommand("HALLAR_SERIE_EMPRESA", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MODULO", SqlDbType.VarChar).Value = "COI"
            CMD.Parameters.Add("@COD_EMPRESA", SqlDbType.NVarChar).Value = COD_EMPRESA
            con2.Open()
            SERIE = (CMD.ExecuteScalar)
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        Return SERIE
    End Function

    Private Sub Inicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Inicio_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        COD_MOD = "GCO"
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-PE", False)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-PE", False)
        cargar_usuario()
        Try
            Dim PROG_01 As New SqlCommand("Mostrar_Empresa", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_empresa.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try

        cbo_empresa.Text = My.Settings.EMPRESA
        cbo_usuario.Text = My.Settings.USUARIO
        If String.IsNullOrEmpty(My.Settings.USUARIO.Trim) Then
            chkRecordar.Checked = False
            cbo_empresa.Focus()
        Else
            chkRecordar.Checked = True
            txt_c.Select()
        End If
    End Sub
    Public Sub INSERTAR_CONECTADOS()
        ALEATORIO = (Now.Date.Ticks)
        Try
            Dim CMD As New SqlCommand("INSERTAR_CONECTADO", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@NICK", SqlDbType.VarChar).Value = DESC_USU
            CMD.Parameters.Add("@pc", SqlDbType.VarChar).Value = NOMBRE_PC
            CMD.Parameters.Add("@COD_MODULO", SqlDbType.VarChar).Value = "GCO"
            CMD.Parameters.Add("@ALEATORIO", SqlDbType.NVarChar).Value = ALEATORIO
            con2.Open()
            CMD.ExecuteNonQuery()
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_c_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_c.TextChanged
        If (txt_c.Text.Length = 12) Then
            btn_aceptar1.Enabled = True
            btn_aceptar1.Focus()
        End If
    End Sub

    Public Function validar_usuario() As String
        Dim validar As String = ""
        Try
            Dim cmd As New SqlCommand("validar_ingreso_usuario", con2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@cod_empresa", SqlDbType.Char).Value = COD_EMPRESA
            cmd.Parameters.Add("@cod_usuario", SqlDbType.Char).Value = COD_USU
            cmd.Parameters.Add("@tipo", SqlDbType.Char).Value = TIPO_USU
            cmd.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = TIPO_USU
            con2.Open()
            validar = (cmd.ExecuteScalar)
            con2.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return validar
    End Function
    Private Function RecuperarFechaLicencia(ByVal Empresa As String) As String
        Dim Licencia As String = String.Empty
        Using cmd As New SqlCommand("RECUPERAR_LICENCIA", con2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@RAZON_SOCIAL", SqlDbType.VarChar).Value = Empresa
            Try
                con2.Open()
                Licencia = cmd.ExecuteScalar
                con2.Close()
            Catch ex As Exception
                con2.Close()
                MsgBox(ex.Message)
            End Try
        End Using
        If String.IsNullOrEmpty(Licencia) Then
            Licencia = String.Empty
        End If
        Return Licencia
    End Function
End Class