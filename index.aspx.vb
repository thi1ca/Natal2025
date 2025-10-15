Public Class index1
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim dataInicio As String
    Dim dataFim As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        labscript = Master.FindControl("labscript")
        labscript.Visible = False
        labscript.Text = ""

        Dim varSessao As String = Session.Item("id_user")
        If varSessao <> "" Then Response.Redirect("home.aspx")

        dataInicio = Natal_regradenegocio.dataInicio 'Colocar a data correta do inicio dos cupons
        dataFim = Natal_regradenegocio.dataFim

        'TravaBotaoProximo
        Dim optionsSubmit As PostBackOptions = New PostBackOptions(butProximo)
        butProximo.OnClientClick = "disableButtonOnClick(this, 'AGUARDE...'); "
        butProximo.OnClientClick += ClientScript.GetPostBackEventReference(optionsSubmit)

    End Sub


    Protected Sub butProximo_Click(sender As Object, e As EventArgs) Handles butProximo.Click
        Try
            If tbCPF.Text <> "" Then

                'Se o CPF estiver mal formatado, voltar para default.html
                Dim txtLogin As String = tbCPF.Text.Replace(".", "").Replace("-", "")
                If IsNumeric(txtLogin) = False Then Response.Redirect("default.html") 'Se por um acaso o cpf não for numerico

                txtLogin = Server.HtmlEncode(txtLogin)

                If funcoes.VerificaCPF(txtLogin) = False Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Coloque um CPF válido")
                    Exit Sub
                End If

                Dim tentativas As Integer = Session.Item("tentativas")

                If tentativas > 3 Then
                    Response.Redirect("default.html")
                Else
                    tentativas += 1
                    Session.Add("tentativas", tentativas)
                End If

                Session.Add("CPF", txtLogin)

                'Condigo novo - Usado só para consultar seus numeros da sorte

                Dim dv As DataView = banco.consulta("select * from cliente where cli_cpf = '" & txtLogin & "'")

                If dv.Count = 0 Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Esse CPF não foi cadastrado na campanha")
                Else
                    Session.Add("tentativas", 0) 'Zera tentativas
                    Response.Redirect("accessCode.aspx") '
                End If


                ''-------------CODIGO ANTIGO - ATIVAR PARA RODAR UMA NOVA CAMPANHA-------

                '    'Trazer os dados de cupom do servidor Torra para local
                '    Natal_regradenegocio.carregaCuponsDeLojaPorCPF(txtLogin)


                '    'Verifica se tem cupom para continuar 

                '    Dim dv As DataView = banco.consulta("Select * from cupom  where cup_cpf = '" + txtLogin + "' and cup_valor >= " & Natal_regradenegocio.valor.ToString & " and cup_cupom_data >= '" & dataInicio & "' and cup_cupom_data <= '" & dataFim & "'")
                '    If dv.Count > 0 Then
                '        'Tem Cupom
                '        Session.Add("tentativas", 0) 'Zera tentativas

                '        'Verifica se é o primeiro acesso
                '        Dim dvPrimeiroAcesso As DataView = banco.consulta("Select * from cliente  where cli_cpf = '" + txtLogin + "' ")
                '        If dvPrimeiroAcesso.Count > 0 Then 'Não é primeiro acesso
                '            Response.Redirect("accessCode.aspx")
                '        Else
                '            'Primeiro acesso... ir para pergunta de segurança
                '            Response.Redirect("questions.aspx")
                '        End If
                '    Else
                '        'TODO => Redirecionar para check.aspx onde ele poderá informar seus dados. A inserção na tabela CPF deve ser feita lá
                '        'Insere na tabela CPF a tentativa frustrada
                '        registraCPF(txtLogin)

                '        'Dim msg As String = "Não encontramos compras com este CPF entre " & vbNewLine & ado.formataData(dataInicio) & " e " & ado.formataData(dataFim)

                '        labscript.Visible = True
                '        labscript.Text = ado.erroGeral("Não encontramos compras com este CPF entre " & ado.formataData(dataInicio) & " e " & ado.formataData(dataFim))
                '        Exit Sub
                '    End If



                '    ''Se não quiser liberar para qualquer um se cadastrar, usar o código abaixo
                '    ''Mas tem que alterar o sistema para desconsiderar as perguntas de validação.
                '    'Session.Add("CPF", txtLogin)
                '    'Response.Redirect("questions.aspx")

            Else
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Digite seu CPF")
            End If

        Catch Ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral("Desculpe, o sistema está em manutenção. Por favor volte mais tarde")

        End Try
    End Sub

    Private Sub registraCPF(CPF As String)
        Try
            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cpf_cpf")
            conteudo.Add(CPF)

            campo.Add("cpf_ip")
            conteudo.Add(Request.ServerVariables("remote_addr"))

            Dim funcionario As Integer = 0
            Dim dvFuncionario As DataView = banco.consultaTorra("select cpf from ttv_funcionario where cpf = '" & CPF & "'")
            If dvFuncionario.Count > 0 Then funcionario = 1

            campo.Add("cpf_funcionario")
            conteudo.Add(funcionario.ToString)

            ado.incluir("CPF", campo, conteudo)
            campo.Clear()
            conteudo.Clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub







End Class