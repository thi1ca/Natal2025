Public Class admUsers
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Dim esP As container.estrutura
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Usuários"
            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaOrdenacao()
                CarregaGrid()
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
            ddlOrdenacao.Items(0).Value = "cad_ativo desc, cad_nome asc"

            ddlOrdenacao.Items.Add("Ativos DESC")
            ddlOrdenacao.Items(1).Value = "cad_ativo asc, cad_nome asc"

            ddlOrdenacao.Items.Add("Nome ASC")
            ddlOrdenacao.Items(2).Value = "cad_nome asc"

            ddlOrdenacao.Items.Add("Nome DESC")
            ddlOrdenacao.Items(3).Value = "cad_nome desc"


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

            'Trás todos os itens do período sem ser cartão (só débito, transf, entradas)
            sql = "select c.*, per_nome from cadastro c inner join perfil p on c.per_id = p.per_id "

            'Se tiver filtro no campo Nome
            If tbNome.Text.Trim <> "" Then
                sql += " where cad_nome like '%" & tbNome.Text.Trim & "%' "
            End If

            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cad_ativo desc, cad_nome asc"
            sql += "  order by " & ddlOrdenacao.SelectedValue.ToString

            'Configurando
            esP.pagina_atual = 1
            esP.registros_por_pagina = 100


            esP.contador = "Select count (*) from (" & sqlCount & ") aa"

            esP.comando = sql

            'comentário:executando
            esP = container.gerar(Repeater1, esP)

            'Dim dv As New DataView
            'dv = (datagrid1.table
            'dv.Sort = "Sobrenome Desc";


        Catch ex As Exception
            Throw ex
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

    Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then

                Dim butExcluir As LinkButton = CType(e.Item.FindControl("butExcluir"), LinkButton)

                Dim cadAtivo As Boolean = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(6)

                If cadAtivo = True Then
                    butExcluir.CommandName = "excluir"
                    butExcluir.Text = "Desativar <img src='../assets/image/trash.svg'>"
                Else
                    butExcluir.CommandName = "ativar"
                    butExcluir.Text = "Ativar  <img src='../assets/image/trash.svg'>"
                End If
                butExcluir.CommandArgument = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(0)

                    'If DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(7) = True Then
                    '    btnConciliado.CssClass = "fab fa-cuttlefish  text-black"
                    '    btnConciliado.CommandName = "Conciliado"
                    'Else
                    '    btnConciliado.CssClass = "far fa-window-minimize text-black"
                    '    btnConciliado.CommandName = "NaoConciliado"
                    'End If

                    'If IsDBNull(DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(8)) = True Then
                    '    'Se não for cartão de crédito
                    '    btnConciliado.CommandArgument = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(0)
                    '    btnExcluir.CommandArgument = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(0)
                    '    btnExcluir.CommandName = "Excluir"
                    '    btnEditar.CommandArgument = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(0)
                    '    btnEditar.CommandName = "Editar"
                    'Else
                    '    'Se for cartão de crédito
                    '    btnConciliado.Visible = False
                    '    btnExcluir.Visible = False
                    '    btnEditar.Visible = False
                    '    btnDetalhes.Visible = True
                    '    btnDetalhes.CommandArgument = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(8)
                    '    btnDetalhes.CommandName = "Detalhes"
                    '    '<a href="#" class="btn btn-inverse width-100 btn-sm">Detalhes</a>


                    'End If


                    'myButton.CommandName = "Conciliado"
                    'myButton.CommandArgument = "Some Identifying Argument"
                    'myButton.Text = "ABC"
                End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Try
            If e.CommandName = "excluir" Then
                banco.executa("update cadastro set cad_ativo = 0 where cad_id = " & e.CommandArgument.ToString)

            End If
            'CarregaGrid(labConId.Text)
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub


End Class