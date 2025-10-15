Public Class simulaCliente
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Dim es As container.estrutura
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Simula Navegação de Cliente"

            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            Dim varNivel As Integer = Session.Item("Nivel")
            If varNivel < 10 Then Response.Redirect("dashboard.aspx")

            If Not IsPostBack Then

            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            If IsNumeric(tbCliId.Text.Trim) = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("cli_id precisa ser só numero")
                Exit Sub
            End If
            autenticar()


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub autenticar()
        Try

            If IsNumeric(tbCliId.Text.Trim) = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("cli_id precisa ser só numero")
                Exit Sub
            End If

            Dim dv As DataView = banco.consulta("select top 1 * from cliente where cli_id = " & tbCliId.Text.Trim & " order by 1 desc ")

            'emaiu = dr("cli_email")
            Session.Add("email", dv(0)("cli_email"))
            Session.Add("nome", dv(0)("cli_nome"))
            Session.Add("id_user", dv(0)("cli_id"))
            Session.Add("ip", Request.ServerVariables("remote_addr"))
            Session.Add("cpf", dv(0)("cli_cpf"))

            ' checkSession()




            ' adicionaCookie()

            'Redirecionar

            If IsDBNull(dv(0)("cli_nascimento")) = True Then
                Response.Redirect("../register.aspx")
            ElseIf dv(0)("cli_termos") = True Then
                Response.Redirect("../oAuth.aspx")
            Else
                Response.Redirect("../terms.aspx")
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub butEmail_Click(sender As Object, e As EventArgs) Handles butEmail.Click
        Try
            If TbEmail.Text.Trim = "" Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Insira o texto de email a ser enviado")
                Exit Sub
            ElseIf IsNumeric(tbCliId.text) = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Preencha o ID do cliente")
                Exit Sub
            End If

            Dim dv As DataView = banco.consulta("select * from cliente where cli_id = " & tbCliId.Text.Trim)

            If dv.Count = 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Cliente não encontrado")
                Exit Sub
            Else
                Dim nome As String = dv(0)("cli_nome")
                Dim varEmail As String = dv(0)("cli_email")

                eMail.enviaEmailPersonalizadoCliente(nome, varEmail, TbEmail.Text.Trim)

                labscript.Visible = True
                labscript.Text += ado.erroGeral("Email enviado com sucesso para " & nome, True)

            End If


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butWhatsapp_Click(sender As Object, e As EventArgs) Handles butWhatsapp.Click
        Try
            If tbWhatsapp.Text.Trim = "" Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Insira o texto de whatsapp a ser enviado")
                Exit Sub
            ElseIf IsNumeric(tbCliId.Text) = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Preencha o ID do cliente")
                Exit Sub
            End If

            Dim dv As DataView = banco.consulta("select * from cliente where cli_id = " & tbCliId.Text.Trim)

            If dv.Count = 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Cliente não encontrado")
                Exit Sub
            Else
                banco.executa("update cliente set chi_id = 1 where cli_id = " & tbCliId.Text.Trim)
                Dim nome As String = dv(0)("cli_nome")
                Dim varCelular As String = dv(0)("cli_celular")

                whatsapp.mensagem(varCelular, tbWhatsapp.Text.Trim, tbCliId.Text.Trim)

                labscript.Visible = True
                labscript.Text += ado.erroGeral("Whatsapp enviado com sucesso para " & nome, True)

            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butGerar_Click(sender As Object, e As EventArgs) Handles butGerar.Click
        Try
            If IsNumeric(tbCupId.Text.Trim) = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("cup_id precisa ser só numero")
                Exit Sub
            End If

            Dim cpf As String
            Dim novosNumeros As Integer = 0
            Dim dv As DataView = banco.consulta("select cu.*, cli_cpf, cli_nome, cli_email from cupom cu inner join cliente c on cu.cli_id = c.cli_id where cup_id = " & tbCupId.Text)

            If dv.Count > 0 Then
                cpf = dv(0)("cli_cpf")

                Natal_regradenegocio.executaProcedureCliIdNoCupom(dv(0)("cli_id"), cpf) 'Verifica se tem algum cupom sem cli_id
                novosNumeros = Natal_regradenegocio.gerarNumeroDaSorteComplementar(tbCupId.Text.Trim)
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Foram cadastrados " & novosNumeros.ToString & " novos numeros da sorte para o cupom " & tbCupId.Text, True)

                Dim texto As String = ""
                If novosNumeros > 0 Then
                    texto = "Novos números da sorte foram gerados na sua conta. Para visualizá-los, siga os passos abaixo: <br><br><br>"
                    texto += "1. Acesse o APP Lojas Torra<br><br>"
                    texto += "2. Clique no banner da Campanha de Natal<br><br>"
                    texto += "3. Informe seu CPF<br><br>"
                    texto += "4. Escolha onde deseja receber seu código de segurança.<br><br>"
                    texto += "5. Informe o código de segurança<br><br>"
                    texto += "6. Pronto! Você irá visualizar todos seus números da sorte.<br><br>"

                    eMail.enviaEmailClienteNumerosAdicionados(dv(0)("cli_nome"), dv(0)("cli_email"), texto)
                End If

                tbCupId.Text = ""
            Else
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Cupom não encontrado ou cliente não encontrado")
            End If







        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub





End Class