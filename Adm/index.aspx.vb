Public Class index
    Inherits System.Web.UI.Page
    'Dim labscript As Label
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'labscript = Master.FindControl("labscript")
        labscript.Visible = False
        labscript.Text = ""


        If Not IsPostBack Then
            'checaSessao()
            GravaPagina()
            VerificaCookie()
            ' checkSession()
        End If
        'Response.Flush()
    End Sub

    Protected Sub btlogin_Click(sender As Object, e As EventArgs) Handles btlogin.Click
        Try
            If tbEmail.Text <> "" And tbSenha.Text <> "" Then
                If ado.ValidaMail(tbEmail.Text) = False Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Coloque um e-mail válido")
                    Exit Sub
                End If
                Dim conexao As New SqlClient.SqlConnection(ado.caminho)
                Dim comando As New SqlClient.SqlCommand("", conexao)
                Dim dr As SqlClient.SqlDataReader
                Dim txtLogin As String = Server.HtmlEncode(tbEmail.Text)
                Dim txtSenha As String = Server.HtmlEncode(tbSenha.Text)
                Dim emaiu As String

                comando.CommandText = "Select * from cadastro c  where cad_email = '" + txtLogin + "' and cad_senha = '" + txtSenha + "'"
                conexao.Open()
                dr = comando.ExecuteReader

                'Se cadastro estiver desativado, avise o usuário
                If dr.Read Then
                    If dr("cad_ativo") = False Then
                        labscript.Visible = True
                        labscript.Text = ado.erroGeral("O seu acesso está desativado. Contate o administrador do sistema.")
                        Exit Sub
                    End If

                    'Grava Sessão
                    emaiu = dr("cad_email")
                    Session.Add("email", dr("cad_email"))
                    Session.Add("nivel", dr("per_id"))
                    Session.Add("nome", dr("cad_nome"))
                    Session.Add("cadId", dr("cad_id"))
                    Session.Add("ip", Request.ServerVariables("remote_addr"))


                    ' checkSession()

                    'Grava Log
                    Dim ct As New banco.s_conteudo
                    ct.campo = New ArrayList
                    ct.conteudo = New ArrayList
                    ct.campo.Add("cad_id")
                    ct.conteudo.Add(Session.Item("cadId").ToString)
                    ct.campo.Add("log_ip")
                    ct.conteudo.Add(Session.Item("ip").ToString)
                    banco.incluir("log", ct)

                    'gustavo 18/8/03
                    Dim x As New ArrayList
                    Dim y As New ArrayList
                    Dim z As New ArrayList
                    Dim a As New ArrayList
                    Dim b As New ArrayList
                    Application.Lock()

                    Try
                        If IsNothing(Application.Item("online")) = True Then
                            x.Add(txtLogin)
                            y.Add(Session.Item("ip"))
                            z.Add("Realizando Autenticação")
                            a.Add(Session.Item("nome"))
                            b.Add(Session.Item("cadId"))

                            Session.Item("logado") = txtLogin
                            Session.Item("pagina") = "Realizando Autenticação"
                            Application.Item("online") = x
                            Application.Item("ip") = y
                            Application.Item("pagina") = z
                            Application.Item("nome") = a
                            Application.Item("cadId") = b
                        Else
                            x = Application.Item("online")
                            y = Application.Item("ip")
                            z = Application.Item("pagina")
                            a = Application.Item("nome")
                            b = Application.Item("cadId")

                            If x.IndexOf(txtLogin) > -1 Then
                                Dim posicao As Integer = x.IndexOf(txtLogin)
                                If Session.Item("ip") <> y.Item(posicao) Then
                                    Session.Item("logado") = "logado"
                                    'Application.UnLock()
                                    'conexao.Close()
                                    'Response.Redirect("Logado.aspx")
                                    'Exit Sub
                                End If
                            Else
                                x.Add(txtLogin)
                                y.Add(Session.Item("ip"))
                                z.Add("Realizando Autenticação")
                                a.Add(Session.Item("nome"))
                                b.Add(Session.Item("cadId"))

                                Session.Item("logado") = txtLogin
                                Session.Item("pagina") = "Realizando Autenticação"
                                Application.Item("online") = x
                                Application.Item("ip") = y
                                Application.Item("pagina") = z
                                Application.Item("nome") = a
                                Application.Item("cadId") = b
                            End If
                        End If
                    Catch ex As Exception

                    End Try


                    'Se tiver habilitado o Manter conectado
                    'If cblembrar.Checked = True Then Session.Timeout = 10000

                    Application.UnLock()
                    conexao.Close()
                    adicionaCookie()

                    'Redirecionar
                    Dim variavel As String = Request.Item("pagina")

                    Dim pagina As String
                    If variavel <> "" Then
                        pagina = variavel
                    Else
                        pagina = "dashboard.aspx"
                    End If

                    Response.Redirect(pagina)

                Else
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Dados incorretos. Tente novamente.")
                    conexao.Close()
                End If
            Else
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Digite seu email e senha")
            End If

        Catch Ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(Ex.Message)

        End Try
    End Sub

    Private Sub adicionaCookie()
        Try
            If Not Request.Cookies("torra") Is Nothing Then
                Response.Cookies("torra").Item("email") = tbEmail.Text
            Else
                Dim _Cookie As HttpCookie = New HttpCookie("torra")
                _Cookie.Values("email") = tbEmail.Text
                _Cookie.Expires = DateTime.Now.AddYears(10)
                Response.Cookies.Add(_Cookie)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VerificaCookie()
        Try
            If Not Request.Cookies("torra") Is Nothing Then
                tbEmail.Text = Request.Cookies("torra").Item("email")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub checaSessao()
    '    If Session.Item("xmlModulo") = Nothing Then
    '        Dim ds As New DataSet
    '        ds.ReadXml(ado.xml)
    '        Dim caminho As String = ds.Tables("caminho").Select("id='diretorio'")(0).Item("url")
    '        Dim url As String = ds.Tables("sistema").Select("id='1'")(0).Item("url")
    '        Dim dir As String = ds.Tables("caminho").Select("id='diretorio'")(0).Item("dir")
    '        Session.Add("caminho", caminho)
    '        Session.Add("url", url)
    '        Session.Add("dir", dir)
    '        'Session.Add("moduloDefault", moduloDefault)
    '        Session.Add("xmlModulo", True)

    '        If Not Request.Cookies("torra") Is Nothing Then
    '            Dim meuModulo As String = Request.Cookies("torra")("modulo")
    '            Session.Item("modulo") = meuModulo
    '        End If

    '    End If
    'End Sub

    Private Sub GravaPagina()
        Application.Lock()
        Dim x As New ArrayList
        Dim z As New ArrayList
        Dim posicao As Integer

        x = Application.Item("onLine")
        z = Application.Item("pagina")

        'posicao = x.IndexOf(Session.Item("logado"))
        If Not Session.Item("logado") Is Nothing And posicao > -1 Then
            posicao = x.IndexOf(Session.Item("logado"))
            z(posicao) = Request.ServerVariables("PATH_INFO")
        End If

        Application.Item("pagina") = z
        Application.UnLock()
    End Sub


End Class