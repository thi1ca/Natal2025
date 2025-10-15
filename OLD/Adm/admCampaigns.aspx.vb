Public Class admCampaigns
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
            labTitulo.Text = "Campanhas"
            varSessao = Session.Item("cadId")
            'varSessao = "2"
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaOrdenacao()
                CarregaGrid()
                limpaCampos()
                HabilitarInsercao(True)
            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

#Region "FORMULARIO"

    Private Sub butCadastrar_Click(sender As Object, e As EventArgs) Handles butCadastrar.Click
        Try
            If verificaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cam_nome")
            conteudo.Add(tbCampanha.Text)

            campo.Add("cam_inicio")
            conteudo.Add(tbDataInicio.Text)

            campo.Add("cam_fim")
            conteudo.Add(tbDataFinal.Text)

            campo.Add("cam_prazo")
            conteudo.Add(tbLimite.Text)

            campo.Add("cad_id")
            conteudo.Add(varSessao.ToString)

            campo.Add("cam_ativo")
            If cbAtivo.Checked = True Then
                conteudo.Add("1")
            Else
                conteudo.Add("0")
            End If

            ado.incluir("campanha", campo, conteudo)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()
            CarregaGrid()

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub


    Private Sub butConfirmar_Click(sender As Object, e As EventArgs) Handles butConfirmar.Click
        Try
            If verificaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cam_nome")
            conteudo.Add(tbCampanha.Text)

            campo.Add("cam_inicio")
            conteudo.Add(tbDataInicio.Text)

            campo.Add("cam_fim")
            conteudo.Add(tbDataFinal.Text)

            campo.Add("cam_prazo")
            conteudo.Add(tbLimite.Text)

            campo.Add("cad_id")
            conteudo.Add(varSessao.ToString)

            campo.Add("cam_ativo")
            If cbAtivo.Checked = True Then
                conteudo.Add("1")
            Else
                conteudo.Add("0")
            End If

            ado.alterar("campanha", campo, conteudo, "cam_id", tbID.Text)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()
            CarregaGrid()




        Catch ex As Exception
            labscript.Text = ado.erroGeral(ex.Message)
            labscript.Visible = True
        End Try
    End Sub



    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Try
            limpaCampos()

        Catch ex As Exception
            labscript.Text = ado.erroGeral(ex.Message)
            labscript.Visible = True
        End Try
    End Sub


    Private Sub limpaCampos()
        Try
            tbCampanha.Text = ""
            tbDataFinal.Text = ""
            tbDataInicio.Text = ""
            tbLimite.Text = ""
            divFormulario.Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try

            If tbCampanha.Text = "" Then
                'labscript.Text = Ado.erroGeral("Preencha o campo descrição")
                labscript.Text = "Preencha o nome da campanha"
                'labscript.Visible = True
                Return False
            ElseIf tbCampanha.Text.Length > 100 Then
                labscript.Text = "O nome da campanha está muito extenso. Por favor, reduza"
                'labscript.Visible = True
                Return False
            End If

            If tbDataInicio.Text = "" Then
                labscript.Text = "Preencha a data de início da campanha"
                ' labscript.Visible = True
                Return False
            ElseIf IsDate(tbDataInicio.Text) = False Then
                'labscript.Text = Ado.erroGeral("Preencha corretamente o campo DATA")
                labscript.Text = "Preencha corretamente a data de início da campanha"
                ' labscript.Visible = True
                Return False
            End If

            If tbDataFinal.Text = "" Then
                labscript.Text = "Preencha a data final da campanha"
                ' labscript.Visible = True
                Return False
            ElseIf IsDate(tbDataFinal.Text) = False Then
                'labscript.Text = Ado.erroGeral("Preencha corretamente o campo DATA")
                labscript.Text = "Preencha corretamente a data final da campanha"
                ' labscript.Visible = True
                Return False
            End If

            If tbLimite.Text = "" Then
                labscript.Text = "Preencha a data limite para raspar desta campanha"
                ' labscript.Visible = True
                Return False
            ElseIf IsDate(tbDataFinal.Text) = False Then
                'labscript.Text = Ado.erroGeral("Preencha corretamente o campo DATA")
                labscript.Text = "Preencha corretamente a data limite para raspar desta campanha"
                ' labscript.Visible = True
                Return False
            End If



            'If IsNumeric(tbValorEntrada.Text) = False Then
            '    'labscript.Text = Ado.erroGeral("Preencha corretamente o campo Valor")
            '    labscript.Text = "Preencha corretamente o campo Valor"
            '    'labscript.Visible = True
            '    Return False
            'End If

            'If ddlcategoriaEntrada.SelectedIndex = 0 Then
            '    'labscript.Text = Ado.erroGeral("Selecione uma Categoria")
            '    labscript.Text = "Selecione uma Categoria"
            '    'labscript.Visible = True
            '    Return False
            'End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub HabilitarInsercao(ByVal Flag As Boolean)

        butCadastrar.Visible = Flag
        butConfirmar.Visible = Not Flag
        butCancel.Visible = Not Flag

    End Sub



#End Region


#Region "GRID"



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
            ddlOrdenacao.Items(0).Value = "cam_ativo desc, cam_nome asc"

            ddlOrdenacao.Items.Add("Ativos DESC")
            ddlOrdenacao.Items(1).Value = "cam_ativo asc, cam_nome asc"

            ddlOrdenacao.Items.Add("Nome ASC")
            ddlOrdenacao.Items(2).Value = "cam_nome asc"

            ddlOrdenacao.Items.Add("Nome DESC")
            ddlOrdenacao.Items(3).Value = "cam_nome desc"


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
            sql = "select c.*, cad_nome from Campanha c inner join cadastro ca on c.cad_id = ca.cad_id  "

            'Se tiver filtro no campo Nome
            If tbNome.Text.Trim <> "" Then
                sql += " where cam_nome like '%" & tbNome.Text.Trim & "%' "
            End If

            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cli_ativo desc, cli_nome asc"
            sql += "  order by " & ddlOrdenacao.SelectedValue.ToString

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 10


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



    Public Shared Function funcAtivo(ativo As Boolean) As String
        If ativo = True Then
            Return "Ativo"
        Else
            Return "Desabilitado"
        End If
    End Function


    Public Shared Function funcAtivar(ativo As Boolean) As String
        If ativo = True Then
            Return "Desativar"
        Else
            Return "Ativar"
        End If
    End Function



    Public Shared Function funcdata(data As Date) As String
        Return funcoes.formataData(data)
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



    Public Shared Function FunctionFundo(ativo As Boolean) As String
        If ativo = True Then
            Return ""
        Else
            Return "bg-light"
        End If
    End Function



    Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
                Dim btnExcluir As LinkButton = CType(e.Item.FindControl("butExcluir"), LinkButton)
                Dim btnEditar As LinkButton = CType(e.Item.FindControl("butEditar"), LinkButton)


                btnExcluir.CommandName = "Excluir"
                'btnExcluir.CommandArgument = "Excluir"

                btnEditar.CommandName = "Editar"
                'btnEditar.CommandArgument = "Editar"

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



            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub Repeater1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater1.ItemCommand
        Try
            If e.CommandName = "Excluir" Then
                banco.executa("Update campanha set cam_ativo = 0 where cam_id = " & e.CommandArgument.ToString)
                CarregaGrid()
            ElseIf e.CommandName = "Editar" Then
                limpaCampos()
                divFormulario.Visible = True

                Dim dv As DataView = banco.consulta("select * from campanha where cam_id = " & e.CommandArgument.ToString)
                tbCampanha.Text = dv(0)("cam_nome")
                tbDataInicio.Text = funcoes.TransformaDataAnoMesDia(dv(0)("cam_inicio"))
                tbDataFinal.Text = funcoes.TransformaDataAnoMesDia(dv(0)("cam_fim"))
                tbLimite.Text = funcoes.TransformaDataAnoMesDia(dv(0)("cam_prazo"))
                cbAtivo.Checked = dv(0)("cam_ativo")
                tbID.Text = e.CommandArgument.ToString
            End If

            HabilitarInsercao(False)

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butNew_Click(sender As Object, e As EventArgs) Handles butNew.Click
        Try
            limpaCampos()
            divFormulario.Visible = True
            HabilitarInsercao(True)
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub


#End Region
End Class