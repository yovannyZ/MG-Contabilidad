Imports System.Net
Imports System.Web
Public Class frmConsultaRuc
    Private objCookie As CookieContainer
    Private Delegate Sub ConsultarRuc(ByVal numeroRuc As String, ByVal codigoCaptcha As String)
    Dim ruc As String = String.Empty
    Dim nombre As String = String.Empty
    Dim nombreComercial As String = String.Empty
    Dim direccion As String = String.Empty
    Dim tipo As String = String.Empty
    Dim estado As String = String.Empty
    Dim situacion As String = String.Empty
    Dim agenteRetencion As String = String.Empty

#Region "CONSTRUCTOR"
    Private Shared _instancia As frmConsultaRuc
    Public Shared Function ObtenerInstancia() As frmConsultaRuc
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New frmConsultaRuc
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

    Private Function LeerCaptcha() As Image
        Dim captcha As Image
        Try
            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2"), HttpWebRequest)
            myWebRequest.CookieContainer = objCookie
            myWebRequest.Proxy = Nothing
            myWebRequest.Credentials = CredentialCache.DefaultCredentials
            Dim myWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
            Dim myImgStream As IO.Stream = myWebResponse.GetResponseStream()
            captcha = Image.FromStream(myImgStream)
        Catch ex As Exception

        End Try
        Return captcha
    End Function

    Private Function ValidarCertificado(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, _
    ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean

        Return True

    End Function

    Private Sub Consultar(ByVal sender As Object, ByVal e As EventArgs) Handles btnConsultar.Click
        If CheckForInternetConnection() Then
            If txtRuc.Text.Length = 11 Then
                Dim oConsulta As ConsultarRuc = AddressOf BuscaRuc
                oConsulta.BeginInvoke(txtRuc.Text, txtCodigoCaptcha.Text, AddressOf FinConsulta, Nothing)
                tsslMensaje.Text = "Consultando datos ..."
                btnConsultar.Enabled = False
            End If
        Else
            MessageBox.Show("Verifíque la conexión a internet", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub FinConsulta(ByVal iar As IAsyncResult)
        If iar.IsCompleted Then
            Dim mi As New MethodInvoker(AddressOf MostrarDatos)
            Me.Invoke(mi)
        End If
    End Sub

    Private Sub MostrarDatos()
        If Not String.IsNullOrEmpty(nombre) Then
            txtNombre.Text = nombre.Trim()
            txtNombreComercial.Text = nombreComercial.Trim()
            txtDireccion.Text = direccion.Trim()
            txtTipo.Text = tipo.Trim()
            txtEstado.Text = estado.Trim()
            txtSituacion.Text = situacion.Trim()
            'chkAgente.Checked = (agenteRetencion.ToUpper = "SI")
        Else
            MessageBox.Show("La consulta no devolvío ningún resultado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        btnConsultar.Enabled = True
        tsslMensaje.Text = String.Empty
    End Sub

    Sub BuscaRuc(ByVal numeroRuc As String, ByVal codigoCaptcha As String)
        ruc = String.Empty
        nombre = String.Empty
        nombreComercial = String.Empty
        direccion = String.Empty
        tipo = String.Empty
        estado = String.Empty
        situacion = String.Empty
        Try
            ''A este link le pasamos los datos , RUC y valor del captcha
            Dim myUrl As String = String.Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}", _
                                        numeroRuc, codigoCaptcha)
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
            If xDat.Length <= 635 Then
                Return
            End If
            Dim tabla As String()
            xDat = xDat.Replace("     ", " ")
            xDat = xDat.Replace("    ", " ")
            xDat = xDat.Replace("   ", " ")
            xDat = xDat.Replace("  ", " ")
            xDat = xDat.Replace("( ", "(")
            xDat = xDat.Replace(" )", ")")

            'Lo convertimos a tabla o mejor dicho a un arreglo de string como se ve declarado arriba
            tabla = Regex.Split(xDat, "<td class")
            Dim builder As StringBuilder = New StringBuilder()

            For index As Integer = 1 To tabla.Length - 1
                builder.Append(tabla(index))
            Next

            Dim texto As String = builder.ToString()
            texto = texto.Replace(vbNewLine, "")
            Dim principio As String
            Dim final As String
            Dim posicion1 As Integer
            Dim posicion2 As Integer

            '======================= Buscar Nombre =======================
            principio = numeroRuc
            final = "</td>"
            posicion1 = InStr(texto, principio)
            posicion2 = InStr(posicion1, texto, final)
            posicion1 += 14
            nombre = Mid(texto, posicion1, posicion2 - posicion1)
            '======================= Buscar Nombre Comercial =======================
            principio = "Nombre Comercial: </td> =""bg"" colspan=1>"
            final = "</td>"
            posicion1 = InStr(texto, principio)
            posicion2 = InStr(posicion1 + 41, texto, final)
            posicion1 += 40
            nombreComercial = Mid(texto, posicion1, (posicion2 - posicion1))
            '======================= Buscar Dirección =======================
            principio = "Domicilio Fiscal:</td> =""bg"" colspan=3>"
            final = "</td>"
            posicion1 = InStr(texto, principio)
            posicion2 = InStr(posicion1 + 40, texto, final)
            posicion1 += 39
            direccion = Mid(texto, posicion1, (posicion2 - posicion1))
            '======================= Buscar Tipo =======================
            principio = "Tipo Contribuyente: </td> =""bg"" colspan=3>"
            final = "</td>"
            posicion1 = InStr(texto, principio)
            posicion2 = InStr(posicion1 + 43, texto, final)
            posicion1 += 42
            tipo = Mid(texto, posicion1, (posicion2 - posicion1))
            '======================= Buscar Estado =======================
            principio = "Estado del Contribuyente: </td> =""bg"" colspan=1>"
            final = "</td>"
            posicion1 = InStr(texto, principio)
            posicion2 = InStr(posicion1 + 49, texto, final)
            posicion1 += 48
            estado = Mid(texto, posicion1, (posicion2 - posicion1))

            '======================= Buscar Situación =======================
            If Not estado.Contains("SUSPENSION") Then
                principio = "Condición del Contribuyente:</td> =""bg"" colspan=3>"
                final = "</td>"
                posicion1 = InStr(texto, principio)
                posicion2 = InStr(posicion1 + 51, texto, final)
                posicion1 += 50
                situacion = Mid(texto, posicion1, (posicion2 - posicion1))
            End If
        Catch ex As Exception
            'MessageBox.Show("Error al consultar: " & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function CheckForInternetConnection() As Boolean
        Dim IsConnected As Boolean = False
        Try
            Using client As New WebClient()
                Using stream As IO.Stream = client.OpenRead("http://www.google.com")
                    IsConnected = True
                End Using
            End Using
        Catch ex As Exception
            IsConnected = False
        End Try
        Return IsConnected
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrasladar.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Hide()
    End Sub

    Sub Cargar_Datos(ByVal setRuc As String, Optional ByVal setEstado As String = "NUEVO", Optional ByVal actividad As String = "consulta")
        If actividad = "mantenimiento" Then btnTrasladar.Enabled = True Else btnTrasladar.Enabled = False
        If (setEstado = "MODIFICAR" Or setEstado = "DETALLES2") Then btnTrasladar.Enabled = False
        ruc = setRuc
        estado = setEstado
        txtRuc.Text = setRuc
        btnConsultar.Focus()
    End Sub

    Private Sub frmConsultaRuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objCookie = Nothing
        objCookie = New CookieContainer()
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
        Me.pbCaptcha.Image = LeerCaptcha()
    End Sub

End Class