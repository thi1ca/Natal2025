Public Class register
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim CPF As String
    Dim varSessao As String
    Dim varConfirm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            varSessao = Session.Item("id_user")
            CPF = Session.Item("CPF")
            varConfirm = Session.Item("confirm") 'Verifica se veio da pagina confirm.register.aspx

            If CPF = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                labCPF.Text = funcoes.MascaraCPF(CPF)
                carregaGenero()
                If varSessao <> "" Or varConfirm <> "" Then
                    carregaDados()

                Else
                    verificaRespostas() 'Verifica se ele executou com sucesso os passos anteriores
                End If
            End If

            'TravaBotaoProximo
            Dim optionsSubmit As PostBackOptions = New PostBackOptions(butAvancar)
            butAvancar.OnClientClick = "disableButtonOnClick(this, 'AGUARDE...'); "
            butAvancar.OnClientClick += ClientScript.GetPostBackEventReference(optionsSubmit)

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try

    End Sub

    Private Sub verificaRespostas()
        Try
            Dim dv As DataView = banco.consulta("select res_id, res_acerto from resposta  where res_acerto = 1 and res_cpf = '" & CPF & "' order by 1 desc")

            If dv.Count = 0 Then
                Response.Redirect("questions.aspx")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub carregaDados()
        Try
            Dim dv As DataView
            If varSessao <> "" Then
                dv = banco.consulta("select * from cliente where cli_id = " & varSessao)
            ElseIf varConfirm <> "" Then
                dv = banco.consulta("select * from cliente where cli_cpf = '" & CPF & "'")
            Else
                Response.Redirect("logoff.aspx")
            End If


            If dv.Count > 0 Then
                If CPF = dv(0)("cli_cpf") Then
                    tbNome.Text = dv(0)("cli_nome")
                    tbEmail.Text = dv(0)("cli_email")
                    tbCelular.Text = dv(0)("cli_celular")
                    If IsDBNull(dv(0)("cli_nascimento")) = False Then
                        data.Text = funcoes.TransformaData(dv(0)("cli_nascimento"))
                    Else
                        'Desabilita o botão voltar
                        butVoltar.Visible = False
                    End If
                    If IsDBNull(dv(0)("gen_id")) = False Then
                        ddlGenero.SelectedIndex = ddlGenero.Items.IndexOf(ddlGenero.Items.FindByValue(dv(0)("gen_id")))
                    Else
                        'Desabilita o botão voltar
                        butVoltar.Visible = False
                    End If
                    'tbSenha.Text = dv(0)("cli_senha")
                    'tbSenha2.Text = dv(0)("cli_senha")
                Else
                    Response.Redirect("logoff.aspx")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub butAvancar_Click(sender As Object, e As EventArgs) Handles butAvancar.Click
        Try
            Dim tipo As Integer

            If varSessao = "" And varConfirm = "" Then 'Inclusão
                tipo = 1
            ElseIf varConfirm <> "" Then 'Veio da pagina de confirmação, então altera via CPF
                tipo = 3
            Else 'Tem sessão, então altera via varSessao
                tipo = 2
            End If
            If validaCampos(tipo) = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                'ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                Exit Sub
            End If


            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cli_nome")
            conteudo.Add(tbNome.Text.ToString)

            campo.Add("cli_email")
            conteudo.Add(tbEmail.Text.ToString)

            campo.Add("cli_celular")
            conteudo.Add(funcoes.limpaCelular(tbCelular.Text))

            campo.Add("cli_cpf")
            conteudo.Add(CPF)

            campo.Add("cli_nascimento")
            conteudo.Add(funcoes.TransformaDataAnoMesDia(data.Text))

            campo.Add("gen_id")
            conteudo.Add(ddlGenero.SelectedValue.ToString)

            'Adicionar campo cli_ip na tabela Cliente
            campo.Add("cli_ip")
            conteudo.Add(Request.ServerVariables("remote_addr"))

            'verificar se é funcionario
            Dim funcionario As Integer = 0
            Dim dvFuncionario As DataView = banco.consultaTorra("select cpf from ttv_funcionario where cpf = '" & CPF & "'")
            If dvFuncionario.Count > 0 Then funcionario = 1

            campo.Add("cli_funcionario")
            conteudo.Add(funcionario.tostring)


            If tipo = 1 Then 'Inclusão, sem varsessao ou varConfirm
                ado.incluir("cliente", campo, conteudo)
                campo.Clear()
                conteudo.Clear()
                Dim varCliId As Integer = banco.consultaScalar("select cli_id from cliente where cli_cpf = '" & CPF & "'")
                Natal_regradenegocio.executaProcedureCliIdNoCupom(varCliId.ToString, CPF)

                Response.Redirect("confirm-register.aspx")
            ElseIf tipo = 2 Then 'Tem varSessao
                ado.alterar("cliente", campo, conteudo, "cli_id", varSessao)
                campo.Clear()
                conteudo.Clear()
                Session.Add("nome", tbNome.Text.Trim)
                Response.Redirect("oAuth.aspx")
            ElseIf tipo = 3 Then 'Veio de confirm-register
                ado.alterarIdString("cliente", campo, conteudo, "cli_cpf", CPF)
                campo.Clear()
                conteudo.Clear()
                Response.Redirect("confirm-register.aspx")
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Function validaCampos(tipo As Integer)
        Try
            If tbNome.Text.Trim = "" Then
                labscript.Text = "Preencha o campo Nome"
                Return False
            ElseIf Len(ado.FncStrSpace(tbNome.Text)) < 2 Then
                labscript.Text = "Esse não parece ser seu nome!"
                Return False
            ElseIf Len(ado.FncStrSpace(tbNome.Text)) > 60 Then
                labscript.Text = "Que nome grande!!! Por favor, abrevie o seu nome"
                Return False
            ElseIf ado.verificaSeTemCaractereEspecial(tbNome.Text.Trim) = False Then
                labscript.Text = "Nome não pode ter caractere especial"
                Return False
            ElseIf tbNome.Text.Any(Function(c) Char.IsDigit(c)) Then
                labscript.Text = "Nome não pode conter números"
                Return False
            End If

            If tbEmail.Text.Trim = "" Then
                labscript.Text = "Preencha o campo E-MAIL"
                Return False
            ElseIf Len(ado.FncStrSpace(tbEmail.Text)) > 60 Then
                labscript.Text = "Que email grande!!! Por favor, revise seu email"
                Return False
            ElseIf ado.ValidaMail(tbEmail.Text) = False Then
                labscript.Text = "Esse não parece ser um email válido"
                Return False
            End If

            Dim txtcelular As String = funcoes.limpaCelular(tbCelular.Text)
            'Dim txtcelular As String = Replace(tbCelular.Text, "(", "")
            'txtcelular = Replace(txtcelular, ")", "")
            'txtcelular = Replace(txtcelular, "-", "")
            'txtcelular = Replace(txtcelular, " ", "")

            If txtcelular.Trim = "" Then
                labscript.Text = "Preencha o campo Celular"
                Return False
            ElseIf IsNumeric(txtcelular.Trim) = False Then
                labscript.Text = "O campo Celular só aceita números"
                Return False
            ElseIf Len(ado.FncStrSpace(txtcelular.Trim)) < 11 Then
                labscript.Text = "Preencha o campo Celular com 11 dígitos (DDD + Número do celular. Ex: 11 + celular"
                Return False
            ElseIf Len(ado.FncStrSpace(txtcelular.Trim)) > 13 Then
                labscript.Text = "Esse celular parece conter muitos números. Por favor revise"
                Return False
            End If

            If verificaSeExiste(tbEmail.Text, txtcelular, tipo) = True Then
                labscript.Text = "Esse e-mail ou celular já está/estão cadastrados"
                Return False
            End If

            If ddlGenero.SelectedIndex = 0 Then
                labscript.Text = "Selecione o gênero"
                Return False
            End If

            If data.Text = "" Then
                labscript.Text = "Informe a data do seu nascimento"
                Return False
            ElseIf IsDate(data.text) = False Then
                labscript.Text = "A data deve estar no formato dd/mm/aaaa"
                Return False
            ElseIf CDate(data.text) > Date.Today.AddYears(-14) Then
                labscript.Text = "Essa campanha é restrita para maiores de 14 anos"
                Return False
            ElseIf CDate(data.text) < Date.Today.AddYears(-110) Then
                labscript.Text = "Revise a data de seu nascimento"
                Return False
            End If



            If labscript.Text.Trim <> "" Then
                labscript.Visible = True
                Return False
            Else
                labscript.Text = ""
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function verificaSeExiste(txtemail As String, txtcelular As String, tipo As Integer) As Boolean
        Try
            Dim sqlEmail, sqlCelular As String

            If tipo = 1 Then 'Se for insert
                sqlEmail = "select * from cliente where cli_email = '" & txtemail & "'"
                sqlCelular = "select * from cliente where cli_celular = " & txtcelular

            ElseIf tipo = 3 Then 'Se for via confirm-register.aspx
                sqlEmail = "select * from cliente where cli_email = '" & txtemail & "' and cli_cpf <> '" & CPF & "'"
                sqlCelular = "select * from cliente where cli_celular = " & txtcelular & " and cli_cpf <> '" & CPF & "'"

            ElseIf tipo = 2 Then 'se for update
                sqlEmail = "select * from cliente where cli_email = '" & txtemail & "' and cli_id <> " & varSessao
                sqlCelular = "select * from cliente where cli_celular = " & txtcelular & " and cli_id <> " & varSessao
            End If

            Dim dv As DataView = banco.consulta(sqlEmail)
            If dv.Count > 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Esse e-mail já está cadastrado.")
                Return True
            End If

            dv = banco.consulta(sqlCelular)
            If dv.Count > 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Esse celular já está cadastrado.")
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub carregaGenero()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select gen_id, gen_nome from genero"
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlGenero.Items.Clear()
            ddlGenero.Items.Add("--| Selecione seu gênero |--")
            ddlGenero.Items(0).Value = "0"

            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlGenero.Items.Add(arr(1).Item(f))
                    ddlGenero.Items(f + 1).Value = arr(0).Item(f)
                Next
            End If


        Catch ex As Exception
            ddlGenero.Items.Clear()
            ddlGenero.Items.Add("---ERROR---")
            ddlGenero.Items(0).Value = "0"
        End Try
    End Sub

End Class