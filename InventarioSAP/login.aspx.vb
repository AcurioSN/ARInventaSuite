Imports System.Collections.Generic
Imports System.Diagnostics.Eventing.Reader
Imports System.DirectoryServices
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Negocio
Imports Newtonsoft.Json.Linq

Public Class login
    Inherits System.Web.UI.Page
    Dim obj As New Negocio.NLogin
    Dim obj1 As New Negocio.NInventario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            '1. Capturo el token desde la Suite: Token de usuario y clave y token de activacion general (DE BD)
            Dim token As String = Request.QueryString("t")
            Dim tokenGlobal As String = Request.QueryString("tg")
            Session("ACTIVACION_GENERAL") = tokenGlobal


            '2. Registro de Logs en el sistema ARRECETAS
            UtilLog.EscribirLog(
                "Ingreso Login ARinventa. URL=" &
                Request.Url.ToString())

            UtilLog.EscribirLog(
                "Host=" &
                Request.Url.Host)

            UtilLog.EscribirLog(
                "token recibido=" &
                If(token, "(NULL)"))

            UtilLog.EscribirLog(
                "TokenGlobal recibido=" &
                If(tokenGlobal, "(NULL)"))



            If Not String.IsNullOrEmpty(token) Then

                Dim datos As String = Desencriptar(token)

                Dim partes() As String = datos.Split("|")

                Dim usuario As String = partes(0)
                Dim clave As String = partes(1)

                '3.Registros de Ingreso al sistema ARRECETAS y Acceso
                Session("SistemaAcceso") = "ARINV"
                obj1.Registro_SesionSistema(tokenGlobal, usuario, Session("SistemaAcceso").ToString(), "login.aspx")

                '4.================ PROCESO COOKIE =================
                Dim resultado_cookie As Boolean
                resultado_cookie = CargarActivacionGeneral()

                '5.================ PROCESO COOKIE =================
                If resultado_cookie Then
                    validar_ingreso_sistema_suite(usuario, clave) 'Proceso del boton Login (El de antes)
                End If

                'Proceso Normal
                txtusuario.Focus()
                Dim ds As DataSet
                ds = obj.configuracion_recaptcha()
                Session("clave_sitio") = ds.Tables(0).Rows(0)(0).ToString()
                Session("clave_secreta") = ds.Tables(0).Rows(0)(1).ToString()

            Else
                Response.Redirect("~/SesionExpirada.aspx")
            End If


        End If


    End Sub
    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click

        Try
            Dim user As String
            Dim pwd As String
            Dim ds As New DataSet
            Dim dsUnidades As New DataSet
            Dim permite As String
            Dim Id_perfil As String
            Dim Nombre_perfil As String
            Dim Nombre_usuario As String
            Dim email_usuario As String
            Dim local As String
            Dim email_jefe As String

            user = txtusuario.Text.ToString()
            pwd = txtcontraseña.Text.ToString()

            '------------------reCaptcha-------------------

            Dim respuestaRecaptcha As String = Request.Form("g-recaptcha-response")
            Dim secretKey As String = Session("clave_secreta")
            Dim client As New WebClient()

            Dim result As String = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={respuestaRecaptcha}")

            Dim jsonResult As JObject = JObject.Parse(result)
            Dim success As Boolean = jsonResult.Value(Of Boolean)("success")

            '------------------AD-------------------
            Dim resultado As Boolean
            Dim usuario As String
            Dim clave As String

            usuario = user
            clave = pwd

            resultado = IsAuthenticated("acurio.net", usuario, clave)

            'resultado = True
            'success = True

            If success Then
                If resultado = True Then ' Existe en el AD

                    Dim can As Integer
                    Dim i As Integer = 6

                    ds = obj.valida_credenciales(user)
                    can = ds.Tables(0).Rows.Count


                    If can > 0 Then

                        Session("unidad") = ds.Tables(2).Rows(0)(0).ToString()
                        Session("usuario") = ds.Tables(0).Rows(0)(1).ToString()
                        Id_perfil = ds.Tables(1).Rows(0)(0).ToString()
                        Session("id_perfil") = Id_perfil

                        Session("indicador_fec_vencim") = ds.Tables(0).Rows(0)(4).ToString()

                        Dim strRedirect As String
                        strRedirect = Request("ReturnUrl")
                        If strRedirect Is Nothing Then
                            strRedirect = "main.aspx"
                        End If

                        Dim vRecuerdame = False 'cuando pongas tu chek de recordar tu pagina 
                        Dim tkt = New FormsAuthenticationTicket(1, user, DateTime.Now, DateTime.Now.AddMinutes(30), vRecuerdame, user)
                        Dim cookiestr = FormsAuthentication.Encrypt(tkt)
                        Dim ck = New HttpCookie("appNameAuth", cookiestr)
                        If vRecuerdame Then
                            ck.Expires = tkt.Expiration
                        End If
                        ck.Path = FormsAuthentication.FormsCookiePath
                        Response.Cookies.Add(ck)
                        Response.Redirect(strRedirect, True)

                        '--------antes-------------
                        'FormsAuthentication.RedirectFromLoginPage(user, False)
                    End If
                Else

                    'Response.Redirect("login.aspx")
                    lblMensajeError.Visible = True
                    lblMensajeError2.Visible = True
                    lblMensajeError.Text = "Usuario no se encuentra registrado dentro del AD."
                    lblMensajeError2.Text = "Contraseña o nombre de usuario incorrecto."

                End If
                '-------------------------------------


            Else
                ' Mostrar un mensaje de error indicando que el reCAPTCHA no se ha completado correctamente.
                lblMensajeError.Text = "Por favor, completa la verificación reCAPTCHA."
                lblMensajeError.Visible = True
                lblMensajeError2.Visible = False
            End If



        Catch ex As Exception

        End Try
    End Sub
    Public Function IsAuthenticated(ByVal Domain As String, ByVal username As String, ByVal pwd As String) As Boolean
        Dim Success As Boolean = False
        Dim Entry As New System.DirectoryServices.DirectoryEntry("LDAP://" & Domain, username, pwd)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
        Try
            Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
            Success = Not (Results Is Nothing)
        Catch
            Success = False
        End Try
        Return Success
    End Function

    Public Sub validar_ingreso_sistema_suite(ByVal user As String, ByVal pwd As String)

        Dim ds As New DataSet
        Dim dsUnidades As New DataSet
        Dim permite As String
        Dim Id_perfil As String
        Dim Nombre_perfil As String
        Dim Nombre_usuario As String
        Dim email_usuario As String
        Dim local As String
        Dim email_jefe As String

        'user = txtusuario.Text.ToString()
        'pwd = txtcontraseña.Text.ToString()

        '------------------reCaptcha-------------------

        'Dim respuestaRecaptcha As String = Request.Form("g-recaptcha-response")
        '    Dim secretKey As String = Session("clave_secreta")
        '    Dim client As New WebClient()

        '    Dim result As String = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={respuestaRecaptcha}")

        '    Dim jsonResult As JObject = JObject.Parse(result)
        '    Dim success As Boolean = jsonResult.Value(Of Boolean)("success")

        '    '------------------AD-------------------
        '    Dim resultado As Boolean
        '    Dim usuario As String
        '    Dim clave As String

        '    usuario = user
        '    clave = pwd

        '    resultado = IsAuthenticated("acurio.net", usuario, clave)

        Dim resultado As Boolean
        Dim success As Boolean

        resultado = True
        success = True

        If success Then
            If resultado = True Then ' Existe en el AD

                Dim can As Integer
                Dim i As Integer = 6

                ds = obj.valida_credenciales(user)
                can = ds.Tables(0).Rows.Count


                If can > 0 Then
                    Session("user") = user '"imartinez"

                    Session("unidad") = ds.Tables(2).Rows(0)(0).ToString()
                    Session("usuario") = ds.Tables(0).Rows(0)(1).ToString()
                    Id_perfil = ds.Tables(1).Rows(0)(0).ToString()
                    Session("id_perfil") = Id_perfil

                    Session("indicador_fec_vencim") = ds.Tables(0).Rows(0)(4).ToString()

                    Dim strRedirect As String
                    strRedirect = Request("ReturnUrl")
                    If strRedirect Is Nothing Then
                        strRedirect = "main.aspx"
                    End If

                    Dim vRecuerdame = False 'cuando pongas tu chek de recordar tu pagina 
                    Dim tkt = New FormsAuthenticationTicket(1, user, DateTime.Now, DateTime.Now.AddMinutes(30), vRecuerdame, user)
                    Dim cookiestr = FormsAuthentication.Encrypt(tkt)
                    Dim ck = New HttpCookie("appNameAuth", cookiestr)
                    If vRecuerdame Then
                        ck.Expires = tkt.Expiration
                    End If
                    ck.Path = FormsAuthentication.FormsCookiePath
                    Response.Cookies.Add(ck)
                    Response.Redirect(strRedirect, True)

                    '--------antes-------------
                    'FormsAuthentication.RedirectFromLoginPage(user, False)
                End If
            Else

                'Response.Redirect("login.aspx")
                lblMensajeError.Visible = True
                lblMensajeError2.Visible = True
                lblMensajeError.Text = "Usuario no se encuentra registrado dentro del AD."
                lblMensajeError2.Text = "Contraseña o nombre de usuario incorrecto."

            End If
            '-------------------------------------


        Else
            ' Mostrar un mensaje de error indicando que el reCAPTCHA no se ha completado correctamente.
            lblMensajeError.Text = "Por favor, completa la verificación reCAPTCHA."
            lblMensajeError.Visible = True
            lblMensajeError2.Visible = False
        End If



    End Sub

    Private Function Desencriptar(textoEncriptado As String) As String

        Dim clave As String = "ACURIO2026SUPERKEY"

        Dim aes As New AesManaged()

        Dim pdb As New Rfc2898DeriveBytes(
        clave,
        New Byte() {
            &H49, &H76, &H61, &H6E,
            &H20, &H4D, &H65, &H64,
            &H76, &H65, &H64, &H65,
            &H76
        })

        aes.Key = pdb.GetBytes(32)
        aes.IV = pdb.GetBytes(16)

        Dim bytes As Byte() =
        Convert.FromBase64String(textoEncriptado)

        Dim ms As New MemoryStream(bytes)

        Dim cs As New CryptoStream(
        ms,
        aes.CreateDecryptor(),
        CryptoStreamMode.Read)

        Dim sr As New StreamReader(cs, Encoding.UTF8)

        Return sr.ReadToEnd()

    End Function

    Public Function CargarActivacionGeneral() As Boolean

        Dim token As String = Session("ACTIVACION_GENERAL")
        Dim ds As New DataSet
        ds = obj1.ExisteTokenActivo(token)

        If ds.Tables(0).Rows.Count > 0 Then

            Return True
        Else
            Response.Redirect("~/SesionExpirada.aspx", False)
            Return False
        End If

        'Dim cookie As HttpCookie = Request.Cookies("ACTIVACION_GENERAL")

        'If cookie IsNot Nothing AndAlso Not String.IsNullOrEmpty(cookie.Value) Then

        '    Session("ACTIVACION_GENERAL") = cookie.Value
        '    UtilLog.EscribirLog(
        '        "login.aspx: COOKIE OK. Valor=" & cookie.Value)

        '    Return True

        'Else
        '    UtilLog.EscribirLog(
        '        "login.aspx: COOKIE NO EXISTE")
        '    Session.Clear()
        '    Session.Abandon()

        '    Response.Redirect("~/SesionExpirada.aspx", False)
        '    HttpContext.Current.ApplicationInstance.CompleteRequest()

        '    Return False
        'End If

    End Function

End Class