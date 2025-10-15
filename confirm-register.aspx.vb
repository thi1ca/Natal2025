Public Class confirm_register
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim CPF As String
    Dim varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            varSessao = Session.Item("id_user")
            CPF = Session.Item("CPF")

            If CPF = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaDados()
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

    Private Sub carregaDados()
        Try
            Dim dv As DataView = banco.consulta("select c.*, gen_nome from cliente c inner join genero g on c.gen_id = g.gen_id where cli_cpf = '" & CPF & "'")

            If dv.Count > 0 Then
                labCPF.Text = funcoes.MascaraCPF(CPF)
                labNome.Text = dv(0)("cli_nome")
                labEmail.Text = dv(0)("cli_email")
                labCelular.Text = funcoes.formataCelular(dv(0)("cli_celular"))
                If IsDBNull(dv(0)("cli_nascimento")) = False Then
                    labNascimento.Text = funcoes.TransformaData(dv(0)("cli_nascimento"))
                End If
                If IsDBNull(dv(0)("gen_id")) = False Then
                    labGenero.Text = dv(0)("gen_nome")
                End If
            Else
                Response.Redirect("register.aspx")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub butAvancar_Click(sender As Object, e As EventArgs) Handles butAvancar.Click
        Try
            If varSessao = "" Then
                Response.Redirect("terms.aspx")
            Else
                Session.Add("nome", labNome.Text)
                Response.Redirect("oAuth.aspx")
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Protected Sub butEdit_Click(sender As Object, e As EventArgs) Handles butEdit.Click
        Try
            Session.Add("confirm", "True")
            Response.Redirect("register.aspx")
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub
End Class