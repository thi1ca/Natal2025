Imports System.IO
Public Class admUsers_edit
    Inherits System.Web.UI.Page


    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Adicionar Usuários"
            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                'Dim form1 As HtmlForm = Master.FindControl("form1")
                'If form1 IsNot Nothing Then
                '    form1.Attributes.Add("enctype", "multipart/form-data")
                'End If
                carregaPerfil()
                HabilitarInsercao(True)

                If Request.Item("cadId") <> "" Then
                    If IsNumeric(Request.Item("cadId")) = True Then
                        editarCadastro(Request.Item("cadId"))
                    End If
                End If
            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    'Protected Sub btnEnviarArquivo_Click(sender As Object, e As EventArgs) Handles btnEnviarArquivo.Click
    '    If FileUpload1.HasFile Then
    '        Dim nomeArquivo As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
    '        Dim tamanhoArquivo As Long = FileUpload1.PostedFile.ContentLength
    '        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Imagens/" + nomeArquivo))
    '        lblmsg.Text = "Arquivo enviado com sucesso." & vbCrLf & "Tamanho do Arquivo = " & tamanhoArquivo.ToString() & "bytes"
    '    Else
    '        lblmsg.Text = "Por Favor, selecione um arquivo a enviar."
    '    End If
    'End Sub



    Private Sub carregaPerfil()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select per_id, per_nome from perfil where per_ativo = 1 order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlPerfil.Items.Clear()
            ddlPerfil.Items.Add("--- Selecione um perfil ---")
            ddlPerfil.Items(0).Value = "0"


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlPerfil.Items.Add(arr(1).Item(f))
                    ddlPerfil.Items(f + 1).Value = arr(0).Item(f)


                Next
            End If
        Catch ex As Exception
            ddlPerfil.Items.Clear()
            ddlPerfil.Items.Add("---ERROR---")
            ddlPerfil.Items(0).Value = "0"
        End Try
    End Sub

    Private Function Verificacampos(tipo As Integer) As Boolean
        Try
            If tbNome.Text.Trim = "" Then
                labscript.Text = "Preencha o campo Nome"
                Return False
            ElseIf Len(ado.FncStrSpace(tbNome.Text)) < 2 Then
                labscript.Text = "Esse não parece ser seu primeiro nome!"
                Return False
            ElseIf Len(ado.FncStrSpace(tbNome.Text)) > 60 Then
                labscript.Text = "Que nome grande!!! Por favor, abrevie o seu nome"
                Return False
            ElseIf ado.verificaSeTemCaractereEspecial(tbNome.Text.Trim) = False Then
                labscript.Text = "Nome não pode conter caractere especial"
                Return False
            End If

            If tbEmail.Text.Trim = "" Then
                labscript.Text = "Preencha o campo 'e-mail'"
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

            If tipo = 1 Then

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



                If tbFoto.HasFile Then

                    If UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".EXE" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".COM" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".DLL" Then
                        labscript.Text = "Extensão proibida"
                        Return False
                    End If

                    If UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".JPG" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".JPEG" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".GIF" Or UCase(System.IO.Path.GetExtension(tbFoto.FileName)) = ".PNG" Then

                    Else
                        labscript.Text = "Selecione uma imagem com extensão: jpg, jpeg, gif ou png"
                        Return False
                    End If

                    Dim size As Integer = tbFoto.PostedFile.ContentLength / 1024
                    size = Decimal.Round(size, 2)
                    Dim tamanho As String = Replace(size.ToString, ",", ".")

                    If size > 501 Then
                        labscript.Text = "Selecione uma imagem com tamanho menor que 500kb"
                        Return False
                    End If


                End If
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

            If tipo = 1 Then 'Se for include
                sqlEmail = "select * from cadastro where cad_email = '" & txtemail & "'"
                sqlCelular = "select * from cadastro where cad_celular = " & txtcelular

            ElseIf tipo = 2 Then 'se for Alter
                sqlEmail = "select * from cadastro where cad_email = '" & txtemail & "' and cad_id <> " & Request.Item("cadId")
                sqlCelular = "select * from cadastro where cad_celular = " & txtcelular & " and cad_id <> " & Request.Item("cadId")
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

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            limpaCampos()
            HabilitarInsercao(True)

        Catch ex As Exception
            'labscript.Visible = True
            'labscript.Text += ado.erroGeral(ex.Message)
            ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & ex.Message & "');", True)
        End Try
    End Sub

    Private Sub limpaCampos()
        Try
            tbNome.Text = ""
            tbEmail.Text = ""
            tbCelular.Text = ""
            ddlPerfil.SelectedIndex = 0
            tbSenha.Text = ""
            tbSenha2.Text = ""
            cbAtivo2.Checked = True
            tbFoto.Visible = True
            tbSenha.Visible = True
            tbSenha2.Visible = True

            divAvatar.Visible = True
            divSenha.Visible = True
            divSenha2.Visible = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub butCadastrar_Click(sender As Object, e As EventArgs) Handles butCadastrar.Click
        Try
            If Verificacampos(1) = False Then
                'labscript.Visible = True
                'labscript.Text = ado.erroGeral(labscript.Text)
                ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cad_nome")
            conteudo.Add(tbNome.Text.ToString)

            campo.Add("cad_email")
            conteudo.Add(tbEmail.Text.ToString)

            campo.Add("cad_celular")
            conteudo.Add(funcoes.limpaCelular(tbCelular.Text))

            campo.Add("cad_senha")
            conteudo.Add(tbSenha.Text.ToString)

            campo.Add("per_id")
            conteudo.Add(ddlPerfil.SelectedValue.ToString)

            'If txtArquivo.PostedFile.FileName <> "" Then
            '    Dim filename As String = Path.GetFileName(txtArquivo.PostedFile.FileName)
            '    Path.GetFileName(filename)
            '    Dim arquivo As String = System.IO.Path.GetFileName(txtArquivo.PostedFile.FileName)
            '    txtArquivo.PostedFile.SaveAs("~\" + arquivo)

            '    campo.Add("cad_imagem")
            '    conteudo.Add(filename)
            'End If

            If tbFoto.HasFile Then
                Try
                    Dim nomeUser As String = Replace(tbNome.Text, " ", "")
                    Dim extensao As String = System.IO.Path.GetExtension(tbFoto.FileName)
                    'Dim filename As String = Path.GetFileName(tbFoto.FileName)
                    Dim filename As String = nomeUser & extensao

                    Path.GetFileName(tbFoto.FileName)
                    tbFoto.SaveAs(Server.MapPath("~/assets/Avatar/") & filename)

                    campo.Add("cad_imagem")
                    conteudo.Add(filename)

                Catch ex As Exception
                    ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('Upload status: The file could Not be uploaded. The following error occurred:  " & ex.Message & "');", True)

                End Try
            End If

            ado.incluir("cadastro", campo, conteudo)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()

            Response.Redirect("admUsers.aspx")

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub editarCadastro(cadId As String)
        Try
            Dim dv As DataView = banco.consulta("select * from cadastro where cad_id = " & cadId)
            If dv.Count = 0 Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Dados não encontrados")
                Exit Sub
            End If

            tbNome.Text = dv(0)("cad_nome")
            tbEmail.Text = dv(0)("cad_email")
            tbCelular.Text = funcoes.formataCelular(dv(0)("cad_celular"))
            ddlPerfil.SelectedIndex = ddlPerfil.Items.IndexOf(ddlPerfil.Items.FindByValue(dv(0)("per_id")))
            tbSenha.Text = ""
            tbSenha2.Text = ""

            cbAtivo2.Checked = dv(0)("cad_ativo")

            divAvatar.Visible = False
            divSenha.Visible = False
            divSenha2.Visible = False

            HabilitarInsercao(False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HabilitarInsercao(ByVal Flag As Boolean)

        butCadastrar.Visible = Flag
        butConfirmar.Visible = Not Flag

    End Sub

    Private Sub butConfirmar_Click(sender As Object, e As EventArgs) Handles butConfirmar.Click
        Try
            If Verificacampos(2) = False Then
                'labscript.Visible = True
                'labscript.Text = ado.erroGeral(labscript.Text)
                ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cad_nome")
            conteudo.Add(tbNome.Text.ToString)

            campo.Add("cad_email")
            conteudo.Add(tbEmail.Text.ToString)

            campo.Add("cad_celular")
            conteudo.Add(funcoes.limpaCelular(tbCelular.Text))

            campo.Add("per_id")
            conteudo.Add(ddlPerfil.SelectedValue.ToString)

            ado.alterar("cadastro", campo, conteudo, "cad_id", Request.Item("cadId"))

            campo.Clear()
            conteudo.Clear()

            limpaCampos()

            Response.Redirect("admUsers.aspx")
        Catch ex As Exception
            labscript.Text = ex.Message
            ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
        End Try
    End Sub
End Class