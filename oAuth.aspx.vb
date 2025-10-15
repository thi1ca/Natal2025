Public Class oAuth
    Inherits System.Web.UI.Page
    Dim CPF As String
    Dim varSessao As String
    Dim varTerms As String
    Dim nascimento As Boolean
    Dim terms As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript.Visible = False
            labscript.Text = ""
            nascimento = False
            terms = False

            'Se estiver logado
            varSessao = Session.Item("id_user")

            'Se veio da pagina de Terms.aspx (normalmente primeiro acesso)
            varTerms = Session.Item("terms")

            'Se tem CPF mas pulou direto pra cá
            CPF = Session.Item("CPF")

            If Not IsPostBack Then

                'Verifica se está tendo tentativas demais nessa sessão
                Dim tentativas As Integer = Session.Item("tentativas")
                If tentativas > 3 Then
                    Response.Redirect("default.html")
                Else
                    tentativas += 1
                    Session.Add("tentativas", tentativas)
                End If



                If varSessao <> "" Then    'Se está logado, só busca novos cupons
                    '    buscaNovosCupons()    'Não precisa buscar, já faz isso na index.aspx
                    Natal_regradenegocio.executaProcedureCliIdNoCupom(varSessao, CPF) 'Verifica se tem algum cupom sem cli_id
                    Natal_regradenegocio.gerarNumeroDaSorte(varSessao, CPF)
                    Response.Redirect("home.aspx")
                ElseIf varTerms = "1" Then 'Se veio de terms - Autentica e busca cupons
                    Autentica()
                    Natal_regradenegocio.executaProcedureCliIdNoCupom(varSessao, CPF) 'Verifica se tem algum cupom sem cli_id
                    Natal_regradenegocio.gerarNumeroDaSorte(varSessao, CPF)

                    If nascimento = False Then
                        Response.Redirect("register.aspx")
                    ElseIf terms = False Then
                        Response.Redirect("terms.aspx")
                    Else
                        Response.Redirect("home.aspx")
                    End If

                    'buscaNovosCupons()

                Else
                    'Retorna para index
                    whatsapp.mensagem("11987040377", "Erro na pagina de oAuth, cpf=" & CPF, 0)
                    Response.Redirect("index.aspx")
                End If

            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try

    End Sub

    Private Sub Autentica()
        Try
            Dim dv As DataView = banco.consulta("select top 1 * from cliente where cli_cpf = '" & CPF & "' order by 1 desc ")

            If dv.Count = 0 Then
                whatsapp.mensagem("11987040377", "Erro na tentantiva de autenticação oAuth.aspx com cpf=" & CPF, 0)
                Response.Redirect("index.aspx")
            End If

            'emaiu = dr("cli_email")
            Session.Add("email", dv(0)("cli_email"))
            Session.Add("nome", dv(0)("cli_nome"))
            Session.Add("id_user", dv(0)("cli_id"))
            Session.Add("ip", Request.ServerVariables("remote_addr"))
            Session.Add("cpf", CPF)
            varSessao = Session.Item("id_user")
            ' checkSession()

            Dim ct As New banco.s_conteudo
            ct.campo = New ArrayList
            ct.conteudo = New ArrayList

            ct.campo.Add("cli_id")
            ct.conteudo.Add(Session.Item("id_user").ToString)

            ct.campo.Add("log_ip")
            ct.conteudo.Add(Session.Item("ip").ToString)

            banco.incluir("log", ct)

            'gustavo 18/8/03
            Dim x As New ArrayList
            Dim y As New ArrayList
            Dim z As New ArrayList
            Dim a As New ArrayList
            Dim b As New ArrayList
            Dim c As New ArrayList
            Application.Lock()

            Try
                If IsNothing(Application.Item("online")) = True Then
                    x.Add(Session.Item("email"))
                    y.Add(Session.Item("ip"))
                    z.Add("Realizando Autenticação")
                    a.Add(Session.Item("nome"))
                    b.Add(Session.Item("id_user"))
                    c.Add(Session.Item("cpf"))

                    Session.Item("email") = dv(0)("cli_email")
                    Session.Item("pagina") = "Realizando Autenticação"
                    Application.Item("email") = x
                    Application.Item("ip") = y
                    Application.Item("pagina") = z
                    Application.Item("nome") = a
                    Application.Item("cliId") = b
                    Application.Item("cpf") = c
                Else
                    x = Application.Item("email")
                    y = Application.Item("ip")
                    z = Application.Item("pagina")
                    a = Application.Item("nome")
                    b = Application.Item("cliId")
                    c = Application.Item("cpf")

                    If c.IndexOf(CPF) > -1 Then
                        Dim posicao As Integer = c.IndexOf(CPF)
                        If Session.Item("ip") <> y.Item(posicao) Then
                            Session.Item("logado") = "logado"
                            'Application.UnLock()
                            'conexao.Close()
                            'Response.Redirect("Logado.aspx")
                            'Exit Sub
                        End If
                    Else
                        x.Add(Session.Item("email"))
                        y.Add(Session.Item("ip"))
                        z.Add("Realizando Autenticação")
                        a.Add(Session.Item("nome"))
                        b.Add(Session.Item("id_user"))
                        c.Add(Session.Item("cpf"))

                        Session.Item("email") = dv(0)("cli_email")
                        Session.Item("pagina") = "Realizando Autenticação"
                        Application.Item("email") = x
                        Application.Item("ip") = y
                        Application.Item("pagina") = z
                        Application.Item("nome") = a
                        Application.Item("cliId") = b
                        Application.Item("cpf") = c
                    End If
                End If
            Catch ex As Exception

            End Try


            Application.UnLock()

            ' adicionaCookie()

            'Redirecionar

            If IsDBNull(dv(0)("cli_nascimento")) = True Then
                nascimento = False
            Else
                nascimento = True
            End If

            If dv(0)("cli_termos") = False Then
                terms = False
            Else
                terms = True
            End If




        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class