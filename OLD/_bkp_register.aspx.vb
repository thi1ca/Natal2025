Public Class _bkp_register
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



            If CPF = "" Then Response.Redirect("firstAcess.aspx")

            If Not IsPostBack Then
                labCPF.Text = funcoes.MascaraCPF(CPF)
                If varSessao <> "" Then
                    carregaDados()
                End If
            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try

    End Sub

    Private Sub carregaDados()
        Try
            Dim dv As DataView = banco.consulta("select * from cliente where cli_id = " & varSessao)

            If dv.Count > 0 Then
                If CPF = dv(0)("cli_cpf") Then
                    tbNome.Text = dv(0)("cli_nome")
                    tbEmail.Text = dv(0)("cli_email")
                    tbCelular.Text = dv(0)("cli_celular")
                    tbSenha.Text = dv(0)("cli_senha")
                    tbSenha2.Text = dv(0)("cli_senha")
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

            If varSessao = "" Then
                tipo = 1
            Else
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

            campo.Add("cli_senha")
            conteudo.Add(tbSenha.Text.ToString)

            campo.Add("cli_cpf")
            conteudo.Add(CPF)

            'If txtArquivo.PostedFile.FileName <> "" Then
            '    Dim filename As String = Path.GetFileName(txtArquivo.PostedFile.FileName)
            '    Path.GetFileName(filename)
            '    Dim arquivo As String = System.IO.Path.GetFileName(txtArquivo.PostedFile.FileName)
            '    txtArquivo.PostedFile.SaveAs("~\" + arquivo)

            '    campo.Add("cad_imagem")
            '    conteudo.Add(filename)
            'End If

            'If tbFoto.HasFile Then
            '    Try
            '        Dim nomeUser As String = Replace(tbNome.Text, " ", "")
            '        Dim extensao As String = System.IO.Path.GetExtension(tbFoto.FileName)
            '        'Dim filename As String = Path.GetFileName(tbFoto.FileName)
            '        Dim filename As String = nomeUser & extensao

            '        Path.GetFileName(tbFoto.FileName)
            '        tbFoto.SaveAs(Server.MapPath("~/assets/Avatar/") & filename)

            '        campo.Add("cad_imagem")
            '        conteudo.Add(filename)

            '    Catch ex As Exception
            '        ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('Upload status: The file could Not be uploaded. The following error occurred:  " & ex.Message & "');", True)

            '    End Try
            'End If

            If tipo = 1 Then
                ado.incluir("cliente", campo, conteudo)
                campo.Clear()
                conteudo.Clear()
                Response.Redirect("terms.aspx")
            Else
                ado.alterar("cliente", campo, conteudo, "cli_id", varSessao)
                campo.Clear()
                conteudo.Clear()
                Response.Redirect("myTickets.aspx")
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

            If tipo = 1 Then 'Do tipo Insert

                If tbSenha.Text.Trim = "" Then
                    labscript.Text = "Preencha o campo 'Senha'"
                    Return False
                ElseIf Len(ado.FncStrSpace(tbSenha.Text)) < 6 Then
                    labscript.Text = "Coloque ao menos 6 dígitos na senha"
                    Return False
                ElseIf Len(ado.FncStrSpace(tbSenha.Text)) > 20 Then
                    labscript.Text = "Coloque menos de 20 caracteres na senha"
                    Return False
                End If

                If tbSenha.Text.Trim <> tbSenha2.Text.Trim Then
                    labscript.Text = "As senhas não são iguais. Por favor, digite a mesma senha nos 2 campos."
                    Return False
                End If



                'If tbFoto.HasFile Then

                '    If UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".EXE" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".COM" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".DLL" Then
                '        labscript.Text = "Extensão proibida"
                '        Return False
                '    End If

                '    If UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".JPG" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".JPEG" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".GIF" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".PNG" Then

                '    Else
                '        labscript.Text = "Selecione uma imagem com extensão: jpg, jpeg, gif ou png"
                '        Return False
                '    End If

                '    Dim size As Integer = tbFoto.PostedFile.ContentLength / 1024
                '    size = Decimal.Round(size, 2)
                '    Dim tamanho As String = Replace(size.ToString, ",", ".")

                '    If size > 501 Then
                '        labscript.Text = "Selecione uma imagem com tamanho menor que 500kb"
                '        Return False
                '    End If


                'End If
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

            ElseIf tipo = 2 Then 'se for update
                sqlEmail = "select * from cliente where cli_email = '" & txtemail & "' and cli_id <> " & varSessao
                sqlCelular = "select * from cliente where cli_celular = " & txtcelular & " and cli_id <> " & varSessao
            End If

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