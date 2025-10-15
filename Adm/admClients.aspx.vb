Public Class admClients
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
            labTitulo.Text = "Clientes"
            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaOrdenacao()
                butAnterior.Visible = False
                butProximo.Visible = False
                ' CarregaGrid()
            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub



    Private Sub carregaOrdenacao()
        Try

            'Dim arr(1) As ArrayList
            'arr(0) = New ArrayList
            'arr(1) = New ArrayList
            'Dim sql As String = "Select per_id, per_nome from perfil where per_ativo = 1 order by 1 asc "
            'arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlOrdenacao.Items.Clear()

            ddlOrdenacao.Items.Add("Ativos ASC")
            ddlOrdenacao.Items(0).Value = "cli_ativo desc, cli_nome asc"

            ddlOrdenacao.Items.Add("Ativos DESC")
            ddlOrdenacao.Items(1).Value = "cli_ativo asc, cli_nome asc"

            ddlOrdenacao.Items.Add("Nome ASC")
            ddlOrdenacao.Items(2).Value = "cli_nome asc"

            ddlOrdenacao.Items.Add("Nome DESC")
            ddlOrdenacao.Items(3).Value = "cli_nome desc"


            'If arr(0).Count > 0 Then
            '    For f = 0 To arr(0).Count - 1
            '        ddlOrdenacao.Items.Add(arr(1).Item(f))
            '        ddlOrdenacao.Items(f + 1).Value = arr(0).Item(f)


            '    Next
            'End If
        Catch ex As Exception
            ddlOrdenacao.Items.Clear()
            ddlOrdenacao.Items.Add("---ERROR---")
            ddlOrdenacao.Items(0).Value = "0"
        End Try
    End Sub


    Public Sub CarregaGrid()
        Try
            Dim IntCont As Integer = 0
            Dim sql, sqlCount As String

            'Trás todos os clientes
            'sql = "select * from cliente  "
            sql = "select c.*, gen_nome, respostas, cupons, sorte, acertos from cliente c "
            sql += "inner join genero g on c.gen_id = g.gen_id "
            sql += "left join (select res_cpf, count(*) respostas, MAX(CAST(res_acerto AS INT)) AS acertos from resposta  group by res_cpf) r on c.cli_cpf = r.res_cpf "
            sql += "left join (select cli_id, count(*) cupons from cupom where cli_id in(select cli_id from cliente ) group by cli_id) cu on c.cli_id = cu.cli_id "
            sql += "left join (select cli_id, count(*) sorte from sorte where cli_id in( select cli_id from cliente) group by cli_id)  s on c.cli_id = s.cli_id "
            sql += " where 1 = 1 "


            If tbNome.Text.Trim = "" And tbCPF.Text.Trim = "" Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Preencha o nome ou CPF")
                Session.Remove("es")
                Exit Sub
            End If

            'Se tiver filtro no campo Nome
            If tbNome.Text.Trim <> "" Then
                sql += " and cli_nome like '%" & tbNome.Text.Trim & "%' "
            End If

            'Se tiver filtro no campo CPF
            If IsNumeric(tbCPF.Text.Replace(".", "").Replace("-", "")) = True Then
                sql += " and cli_cpf like '%" & tbCPF.Text.Replace(".", "").Replace("-", "") & "%' "
            End If

            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cli_ativo desc, cli_nome asc"
            sql += "  order by " & ddlOrdenacao.SelectedValue.ToString

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 50


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql

            'comentário:executando
            es = container.gerar(Repeater1, es)


            'Mostrando 1 a 10 de 50 cadastrado
            labTotal.Text = "Encontrado total de " & es.total.ToString & " registros"
            'Label2.Text = "Total de Registros: <font color='red'>" + es.total.ToString + "</font>"
            'Label1.Text = "Página Atual:  <font color='red'>" + (es.pagina_atual).ToString
            'Label1.Text += "</font> de  <font color='red'>" + es.qtd_paginas.ToString + "</font>"
            carregaBotao()

            Session.Add("es", es)


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub carregaBotao()
        Try
            butAnterior.Visible = es.btn_anterior
            butProximo.Visible = es.btn_proximo
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub butAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAnterior.Click
        Try
            es = Session.Item("es")
            es = container.anterior(Repeater1, es)
            Session.Item("es") = es
            'manipulando resultado
            labTotal.Text = "Encontrado total de " & es.total.ToString & " registros"
            'Label2.Text = "Total de Registros: <font color='red'>" + es.total.ToString + "</font>"
            'Label1.Text = "Página Atual: <font color='red'>" + (es.pagina_atual).ToString
            'Label1.Text += "</font> de <font color='red'>" + es.qtd_paginas.ToString + "</font>"
            carregaBotao()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral("Erro de paginação")
        End Try
    End Sub

    Private Sub butProximo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butProximo.Click
        Try
            es = Session.Item("es")
            es = container.proximo(Repeater1, es)
            Session.Item("es") = es
            'manipulando resultado
            labTotal.Text = "Encontrado total de " & es.total.ToString & " registros"
            carregaBotao()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral("Erro de paginação")
        End Try
    End Sub

    Public Shared Function funcCel(txtcelular As String) As String
        Return funcoes.formataCelular(txtcelular)
    End Function

    Public Shared Function funcAtivo(ativo As Boolean) As String
        If ativo = True Then
            Return "Ativo"
        Else
            Return "Desabilitado"
        End If
    End Function

    'Public Shared Function funcImagem(imagem As Object) As String
    '    If imagem = "" Then
    '        Return "padrao.gif"
    '    ElseIf imagem.Contains(".") = False Then
    '        Return "padrao.gif"
    '    Else
    '        Return imagem
    '    End If
    'End Function

    Public Shared Function funcAtivar(ativo As Boolean) As String
        If ativo = True Then
            Return "Desativar"
        Else
            Return "Ativar"
        End If
    End Function

    Public Shared Function funcFundo(ativo As Boolean) As String
        If ativo = True Then
            Return ""
        Else
            Return "bg-light"
        End If
    End Function

    Protected Sub ddlOrdenacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrdenacao.SelectedIndexChanged
        Try
            CarregaGrid()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            CarregaGrid()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Public Shared Function FuncCPF(cpf As String) As String
        Try
            Return funcoes.MascaraCPF(cpf)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FuncAcertos(acertos As Object, respostas As Object) As String
        Try
            If IsDBNull(acertos) = True And IsDBNull(respostas) = True Then
                'Não teve perguntas
                Return "--"
            ElseIf IsDBNull(acertos) = True Then
                'Teve perguntas, mas sem respostas
                Return "Não respondeu"
            ElseIf IsDBNull(respostas) = True Then
                'Sem perguntas mas com resposta
                Return "Conflito"
            ElseIf acertos > 0 Then
                If respostas = 1 Then
                    Return "Acertou"
                Else
                    Return "Acertou pelo menos 1"
                End If
            Else
                Return "Errou"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class