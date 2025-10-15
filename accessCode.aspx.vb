Public Class accessCode
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim CPF As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            Dim varSessao As String = Session.Item("id_user")
            If varSessao <> "" Then Response.Redirect("home.aspx")

            CPF = Session.Item("CPF")
            If CPF = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                tbCPF.Text = funcoes.MascaraCPF(CPF)
                carregaOpcoes()
            End If

            'TravaBotaoProximo
            Dim optionsSubmit As PostBackOptions = New PostBackOptions(butProximo)
            butProximo.OnClientClick = "disableButtonOnClick(this, 'AGUARDE...'); "
            butProximo.OnClientClick += ClientScript.GetPostBackEventReference(optionsSubmit)

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try




    End Sub

    Private Sub carregaOpcoes()
        Try
            Dim dv As DataView = banco.consulta("select cli_id, cli_nome, cli_email, cli_celular, cli_ativo, chi_id from cliente where cli_cpf = '" & CPF & "'")
            If dv.Count = 0 Then
                Response.Redirect("index.aspx")
            ElseIf dv(0)("cli_ativo") = False Then
                whatsapp.mensagem("5511987040377", "Cliente do CPF " & CPF & " tentou se logar mas ele está desativado na raspadinha Torra", 0)
                Response.Redirect("sac.aspx")
            Else
                labCelular.Text = dv(0)("cli_celular")
                labEmail.Text = dv(0)("cli_email")
                Dim chiId As Integer = 0
                If IsDBNull(dv(0)("chi_id")) = False Then chiId = dv(0)("chi_id")
                'Veja se tem algum whatsapp disponível para disparar mensagem, de acordo com o delay
                divWhatsapp.Visible = whatsapp.verificaDisponibilidadeWhatsapp(chiId)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub butProximo_Click(sender As Object, e As EventArgs) Handles butProximo.Click
        Try
            If tbControle.Text = "" Then
                If rbOpcao1.Checked = False And rbOpcao2.Checked = False Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Selecione 1 das 2 opções para receber seu código")
                    Exit Sub
                ElseIf rbOpcao1.Checked = True Then
                    'enviar código por Whatsapp
                    enviaCodigo(1)
                    tbControle.Text = 1
                    divCodigo.Visible = True
                ElseIf rbOpcao2.Checked = True Then
                    'Email
                    enviaCodigo(2)
                    tbControle.Text = 1
                    divCodigo.Visible = True
                End If
            Else
                If tbNumAcesso1.Text.Trim = "" Or tbNumAcesso2.Text.Trim = "" Or tbNumAcesso3.Text.Trim = "" Or tbNumAcesso4.Text.Trim = "" Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Preencha o código de acesso corretamente")
                    Exit Sub
                ElseIf IsNumeric(tbNumAcesso1.Text.Trim) = False Or IsNumeric(tbNumAcesso2.Text.Trim) = False Or IsNumeric(tbNumAcesso3.Text.Trim) = False Or IsNumeric(tbNumAcesso4.Text.Trim) = False Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("O código só aceita números")
                    Exit Sub
                Else
                    'Código preenchido corretamente. Precisa validar
                    Dim dv As DataView = banco.consulta("select top 1 * from access where cli_id = (select cli_id from cliente where cli_cpf = '" & CPF & "') order by 1 desc")

                    If dv.Count = 0 Then
                        tbControle.Text = ""
                        divCodigo.Visible = False
                        butProximo_Click(sender, e)
                    Else
                        Dim tempoCodigo As Date = dv(0)("acc_date")
                        Dim CodigoBanco As String = dv(0)("acc_code")
                        Dim horaAgora As Date = Date.Now
                        Dim codigoDigitado As String = tbNumAcesso1.Text.Trim & tbNumAcesso2.Text.Trim & tbNumAcesso3.Text.Trim & tbNumAcesso4.Text.Trim
                        If horaAgora > tempoCodigo.AddMinutes(5) Then
                            labscript.Visible = True
                            labscript.Text = ado.erroGeral("O código expirou. Tente novamente")
                            tbControle.Text = ""
                            divCodigo.Visible = False
                            Exit Sub
                        ElseIf codigoDigitado <> CodigoBanco Then

                            Dim contador As Integer = 0
                            If tbContador.Text = "" Then tbContador.Text = 0
                            If IsNumeric(tbContador.Text) = False Then tbContador.Text = 0
                            contador = contador + CInt(tbContador.Text.Trim) + 1

                            If contador < 4 Then
                                labscript.Visible = True
                                labscript.Text = ado.erroGeral("O código está incorreto. Tente novamente!")
                            ElseIf contador = 4 Then
                                labscript.Visible = True
                                labscript.Text = ado.erroGeral("O código está incorreto novamente. Você tem apenas mais uma chance. Caso contrário, contate nosso SAC")
                            Else
                                Response.Redirect("sac.aspx")
                            End If

                            tbContador.Text = contador.ToString

                        Else
                            autenticar()
                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub enviaCodigo(opcao As Integer)
        Try

            If opcao = 1 Then
                'Whatsapp
                enviaWhatsapp()
            ElseIf opcao = 2 Then
                enviaEmail()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub enviaWhatsapp()
        Try
            Dim dv As DataView = banco.consulta("select cli_id, cli_nome, cli_email, cli_celular from cliente where cli_cpf = '" & CPF & "'")

            Dim celular As String = dv(0)("cli_celular")
            Dim mensagem As String = "Código *" & codigoAcesso(1, CPF) & "* para acessar seus números da sorte da Campanha Natal Torra. Para sua segurança, não o compartilhe."
            mensagem += vbCrLf & "Esse código expira em 5 minutos."

            whatsapp.mensagem(celular, mensagem, dv(0)("cli_id"))

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub enviaEmail()
        Try
            Dim dv As DataView = banco.consulta("select cli_id, cli_nome, cli_email, cli_celular from cliente where cli_cpf = '" & CPF & "'")

            Dim strEmail As String = dv(0)("cli_email")
            Dim strNome As String = dv(0)("cli_nome")
            Dim strCodigo As String = codigoAcesso(0, CPF)
            Dim mensagem As String = "Código *" & strCodigo & "* para acessar o Raspe & Ganhe. Para sua segurança, não o compartilhe."
            mensagem += vbCrLf & "Esse código expira em 5 minutos."

            eMail.enviaCodigoAcesso(strNome, strEmail, strCodigo)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Function codigoAcesso(tipoDeEnvio As Boolean, cpf As String) As String
        Try
            Dim strRandomNumber As String = ""

            Dim dv As DataView = banco.consulta("select * from access a inner join cliente c on a.cli_id = c.cli_id where DATEADD(second, 270, acc_date) > getdate() and c.cli_cpf = '" & cpf & "' order by 1 desc")

            If dv.Count = 0 Then
                'VB.NET code to pick a random number between an interval (-34 And 7)
                Dim rnd As New Random()
                Dim randomNumber As Integer = rnd.Next(1, 9999) ' The upper bound is exclusive, so use 8 instead of 7

                If randomNumber < 10 Then
                    strRandomNumber = "000" & randomNumber.ToString
                ElseIf randomNumber < 100 Then
                    strRandomNumber = "00" & randomNumber.ToString
                ElseIf randomNumber < 1000 Then
                    strRandomNumber = "0" & randomNumber.ToString
                Else
                    strRandomNumber = randomNumber.ToString
                End If

                gravaAccessCode(strRandomNumber, tipoDeEnvio)
            Else
                strRandomNumber = dv(0)("acc_code").ToString
            End If

            Return strRandomNumber

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub gravaAccessCode(randomCode As String, tipoDeEnvio As Boolean)
        Try

            Dim cliId As String = banco.consultaScalar("select cli_id from cliente where cli_cpf = '" & CPF & "'")

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cli_id")
            conteudo.Add(cliId)

            campo.Add("acc_code")
            conteudo.Add(randomCode)

            campo.Add("acc_whatsapp")
            If tipoDeEnvio = True Then
                conteudo.Add("1")
            Else
                conteudo.Add("0")
            End If

            campo.Add("acc_ip")
            conteudo.Add(Request.ServerVariables("remote_addr"))


            ado.incluir("Access", campo, conteudo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub autenticar()
        Try
            Dim dv As DataView = banco.consulta("select top 1 * from cliente where cli_cpf = '" & CPF & "' order by 1 desc ")

            'emaiu = dr("cli_email")
            Session.Add("email", dv(0)("cli_email"))
            Session.Add("nome", dv(0)("cli_nome"))
            Session.Add("id_user", dv(0)("cli_id"))
            Session.Add("ip", Request.ServerVariables("remote_addr"))
            Session.Add("cpf", CPF)

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



            'If cblembrar.Checked = True Then Session.Timeout = 10000

            Application.UnLock()

            ' adicionaCookie()

            'TODO: Código somente para leitura de numeros da sorte
            Response.Redirect("home.aspx", False)

            'TODO - Quando voltar nova campanha, adicionar esse código
            ''Redirecionar
            'If IsDBNull(dv(0)("cli_nascimento")) = True Then
            '    Response.Redirect("register.aspx")
            'ElseIf dv(0)("cli_termos") = True Then
            '    Response.Redirect("oAuth.aspx")
            'Else
            '    Response.Redirect("terms.aspx")
            'End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class