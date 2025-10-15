Public Class check
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
                labCPF.Text = funcoes.MascaraCPF(CPF)
            End If


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butAvancar_Click(sender As Object, e As EventArgs) Handles butAvancar.Click
        Try
            'TODO Sugestao é inserir pré dados na index e nessa tela efetuar só a alteração com os novos campos
            If validaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                'ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                Exit Sub
            End If

            Dim txtcelular As String = funcoes.limpaCelular(tbCelular.Text)
            If verificaSeExiste(tbEmail.Text, txtcelular) = True Then
                Response.Redirect("404.html")
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cpf_nome")
            conteudo.Add(tbNome.Text.ToString)

            campo.Add("cpf_email")
            conteudo.Add(tbEmail.Text.ToString)

            campo.Add("cpf_celular")
            conteudo.Add(funcoes.limpaCelular(tbCelular.Text))

            campo.Add("cpf_cpf")
            conteudo.Add(CPF)

            'TODO: Adicionar campo cli_ip na tabela Cliente
            campo.Add("cpf_ip")
            conteudo.Add(Request.ServerVariables("remote_addr"))

            'verificar se é funcionario
            Dim funcionario As Integer = 0
            Dim dvFuncionario As DataView = banco.consultaTorra("select cpf from ttv_funcionario where cpf = '" & CPF & "'")
            If dvFuncionario.Count > 0 Then funcionario = 1

            campo.Add("cpf_funcionario")
            conteudo.Add(funcionario.ToString)

            ado.incluir("cpf", campo, conteudo)
            campo.Clear()
            conteudo.Clear()

            Response.Redirect("404.html")


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Function validaCampos()
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
                labscript.Text = "Nome não pode conter caractere especial"
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

    Private Function verificaSeExiste(txtemail As String, txtcelular As String) As Boolean
        Try
            Dim sqlEmail, sqlCelular As String


            sqlEmail = "select * from cpf where cpf_email = '" & txtemail & "'"
            sqlCelular = "select * from cpf where cpf_celular = " & txtcelular


            Dim dv As DataView = banco.consulta(sqlEmail)
            If dv.Count > 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Esse e-mail já está cadastrado. Clique em *Esqueci minha senha* na página inicial")
                Return True
            End If

            dv = banco.consulta(sqlCelular)

            If dv.Count > 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Esse celular já está cadastrado. Clique em *Esqueci minha senha* na página inicial")
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class