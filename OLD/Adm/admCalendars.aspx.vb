Public Class admCalendars
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
            labTitulo.Text = "Calendário de Premiações"
            varSessao = Session.Item("cadId")

            'varSessao = "2"
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaOrdenacao()
                carregaCampanha()
                tbPaginacao.Text = "20"
                'CarregaGrid()
                limpaCampos()
                HabilitarInsercao(True)
            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub


#Region "Funções"
    Public Shared Function funcAtivo(ativo As Boolean, tipo As Integer) As String
        If ativo = True Then
            If tipo = 1 Then Return "Ativo"
            If tipo = 2 Then Return "Sim"
            'Return "Ativo"
        Else
            If tipo = 1 Then Return "Desabilitado"
            If tipo = 2 Then Return "Não"
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


    Public Shared Function FunctionFundo(data As Date) As String
        If Date.Now <= data Then
            Return ""
        Else
            Return "bg-light"
        End If
    End Function
#End Region

#Region "FORMULARIO"

    Private Sub carregaCampanha()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select cam_id, cam_nome from campanha where cam_ativo = 1 order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlCampanha.Items.Clear()
            ddlCampanha.Items.Add("Todas Selecionado")
            ddlCampanha.Items(0).Value = "0"

            ddlFiltroCampanha.Items.Clear()
            ddlFiltroCampanha.Items.Add("Todas Selecionado")
            ddlFiltroCampanha.Items(0).Value = "0"


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlCampanha.Items.Add(arr(1).Item(f))
                    ddlCampanha.Items(f + 1).Value = arr(0).Item(f)

                    ddlFiltroCampanha.Items.Add(arr(1).Item(f))
                    ddlFiltroCampanha.Items(f + 1).Value = arr(0).Item(f)
                Next
            End If


        Catch ex As Exception
            ddlCampanha.Items.Clear()
            ddlCampanha.Items.Add("---ERROR---")
            ddlCampanha.Items(0).Value = "0"

            ddlFiltroCampanha.Items.Clear()
            ddlFiltroCampanha.Items.Add("---ERROR---")
            ddlFiltroCampanha.Items(0).Value = "0"
        End Try
    End Sub

    Private Sub carregaPremio(tipo As Integer)
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList

            Dim camId As Integer

            If tipo = 1 Then 'vem do formulario
                camId = ddlCampanha.SelectedValue
            Else 'vem do filtro
                camId = ddlFiltroCampanha.SelectedValue
            End If


            Dim sql As String = "Select pre_id, pre_nome from premio where pre_ativo = 1 and cam_id = " & camId.ToString & " order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlPremio.Items.Clear()
            ddlPremio.Items.Add("Todos Selecionados")
            ddlPremio.Items(0).Value = "0"

            ddlFiltroPremio.Items.Clear()
            ddlFiltroPremio.Items.Add("Todos Selecionados")
            ddlFiltroPremio.Items(0).Value = "0"


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlPremio.Items.Add(arr(1).Item(f))
                    ddlPremio.Items(f + 1).Value = arr(0).Item(f)

                    ddlFiltroPremio.Items.Add(arr(1).Item(f))
                    ddlFiltroPremio.Items(f + 1).Value = arr(0).Item(f)
                Next
            End If
        Catch ex As Exception
            ddlPremio.Items.Clear()
            ddlPremio.Items.Add("---ERROR---")
            ddlPremio.Items(0).Value = "0"

            ddlFiltroPremio.Items.Clear()
            ddlFiltroPremio.Items.Add("---ERROR---")
            ddlFiltroPremio.Items(0).Value = "0"
        End Try
    End Sub



    Private Sub butCadastrar_Click(sender As Object, e As EventArgs) Handles butCadastrar.Click
        Try
            If verificaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList


            Dim dataTratada As String = funcoes.TransformaDataAnoMesDia(tbDataPremio.Text.Trim) & " " & time.Text.Trim

            campo.Add("pre_id")
            conteudo.Add(ddlPremio.SelectedValue.ToString)

            campo.Add("cal_data_premio")
            conteudo.Add(dataTratada)

            campo.Add("cal_voucher")
            conteudo.Add(tbVoucher.Text)

            campo.Add("cad_id")
            conteudo.Add(varSessao)

            ado.incluir("Calendario", campo, conteudo)

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

            Dim dataTratada As String = funcoes.TransformaDataAnoMesDia(tbDataPremio.Text.Trim) & " " & time.Text.Trim

            campo.Add("pre_id")
            conteudo.Add(ddlPremio.SelectedValue.ToString)

            campo.Add("cal_data_premio")
            conteudo.Add(dataTratada)

            campo.Add("cal_voucher")
            conteudo.Add(tbVoucher.Text)

            campo.Add("cad_id")
            conteudo.Add(varSessao)

            ado.alterar("Calendario", campo, conteudo, "cal_id", tbID.Text)

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
            tbDataPremio.Text = ""
            tbVoucher.Text = ""
            ddlCampanha.SelectedIndex = 0
            time.Text = ""
            carregaPremio(1)
            'cbVoucher.Checked = False
            divFormulario.Visible = False
            tbID.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try

            If ddlPremio.SelectedIndex = 0 Then
                'labscript.Text = Ado.erroGeral("Selecione uma Categoria")
                labscript.Text = "Selecione um Prêmio"
                'labscript.Visible = True
                Return False
            End If

            If tbDataPremio.Text.Trim = "" Then
                labscript.Text = "Preencha a data de início da campanha"
                ' labscript.Visible = True
                Return False
            ElseIf IsDate(tbDataPremio.Text) = False Then
                'labscript.Text = Ado.erroGeral("Preencha corretamente o campo DATA")
                labscript.Text = "Preencha corretamente a data de início da campanha"
                ' labscript.Visible = True
                Return False
                'TODO: Elseif se a data for maior ou igual da data fim da campanha
            End If

            If time.Text.Trim = "" Then
                labscript.Text = "Preencha a hora de início da campanha"
                Return False
            Else
                Dim formato As String = "HH:mm:ss"
                Dim resultado As Boolean = DateTime.TryParseExact(time.Text, formato, Nothing, Globalization.DateTimeStyles.None, Nothing)
                If resultado = False Then
                    labscript.Text = "Preencha a hora de início da campanha corrretamente"
                    Return False
                End If
            End If

            'If IsNumeric(tbValorEntrada.Text) = False Then
            '    'labscript.Text = Ado.erroGeral("Preencha corretamente o campo Valor")
            '    labscript.Text = "Preencha corretamente o campo Valor"
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

    Private Sub ddlCampanha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCampanha.SelectedIndexChanged
        Try
            carregaPremio(1)
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
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

            ddlOrdenacao.Items.Add("Data ASC")
            ddlOrdenacao.Items(0).Value = "cal_data_premio desc"

            ddlOrdenacao.Items.Add("Data DESC")
            ddlOrdenacao.Items(1).Value = "cal_data_premio asc"

            ddlOrdenacao.Items.Add("Cadastrado ASC")
            ddlOrdenacao.Items(2).Value = "cal_id asc"

            ddlOrdenacao.Items.Add("Cadastrado DESC")
            ddlOrdenacao.Items(3).Value = "cal_id desc"


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
            sql = "select c.*, p.cam_id, cam_nome, cad_nome, ras_id, cli_nome from calendario c inner join premio p on c.pre_id = p.pre_id inner join campanha ca on p.cam_id = ca.cam_id inner join cadastro cd on c.cad_id = cd.cad_id left join raspados r on r.cal_id = c.cal_id left join cliente cl on r.cli_id = cl.cli_id where 1 = 1 "

            If ddlCampanha.SelectedIndex > 0 Then
                sql += " and p.cam_id = " & ddlCampanha.SelectedValue.ToString
            End If

            If ddlPremio.SelectedIndex > 0 Then
                sql += " and c.pre_id = " & ddlPremio.SelectedValue.ToString
            End If

            'Se tiver filtro no campo Nome
            If tbFiltroInicio.Text.Trim <> "" Then
                sql += " and cal_data_premio >= '" & funcoes.TransformaDataAnoMesDia(tbFiltroInicio.Text.Trim) & "' "
            End If

            If tbFiltroFim.Text.Trim <> "" Then
                sql += " and cal_data_premio <= '" & funcoes.TransformaDataAnoMesDia(tbFiltroFim.Text.Trim) & "' "
            End If

            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cli_ativo desc, cli_nome asc"
            sql += "  order by " & ddlOrdenacao.SelectedValue.ToString

            'Configurando
            es.pagina_atual = 1
            'Qtd de registros por pagina
            Dim qtdPorPagina As Integer = 20
            If IsNumeric(tbPaginacao.Text) = True Then qtdPorPagina = CInt(tbPaginacao.Text)
            es.registros_por_pagina = qtdPorPagina


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql

            'comentário:executando
            es = container.gerar(Repeater1, es)

            'Esconde botão de carregar + se não tiver mais registros
            If es.total <= qtdPorPagina Then butCarregar.Visible = False

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
            tbPaginacao.Text = "20"
            butCarregar.Visible = True
            CarregaGrid()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Protected Sub butCarregar_Click(sender As Object, e As EventArgs) Handles butCarregar.Click
        Try
            Dim qtdPorPagina As Integer = 20
            If IsNumeric(tbPaginacao.Text) = True Then qtdPorPagina = CInt(tbPaginacao.Text)
            qtdPorPagina += 20
            tbPaginacao.Text = qtdPorPagina.ToString
            CarregaGrid()

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
        End Try
    End Sub




    Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
                Dim btnExcluir As LinkButton = CType(e.Item.FindControl("butExcluir"), LinkButton)
                Dim btnEditar As LinkButton = CType(e.Item.FindControl("butEditar"), LinkButton)

                'Se rasId estiver nulo, é que não foi sortado
                If IsDBNull(DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(11)) = True Then
                    'If IsDBNull(DirectCast(e.Item.DataItem, System.Data.DataRowView)datarow("")) = True Then
                    btnExcluir.CommandName = "Excluir"
                    'btnExcluir.CommandArgument = "Excluir"

                    btnEditar.CommandName = "Editar"
                    'btnEditar.CommandArgument = "Editar"
                Else
                    btnEditar.Visible = False
                    btnExcluir.Visible = False
                End If



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
                banco.executa("delete calendario where cal_id = " & e.CommandArgument.ToString)
                CarregaGrid()
            ElseIf e.CommandName = "Editar" Then
                limpaCampos()
                divFormulario.Visible = True

                Dim dv As DataView = banco.consulta("select * from calendario c inner join premio p on c.pre_id = p.pre_id where cal_id = " & e.CommandArgument.ToString)
                tbID.Text = e.CommandArgument.ToString
                ddlCampanha.SelectedIndex = ddlCampanha.Items.IndexOf(ddlCampanha.Items.FindByValue(dv(0)("cam_id")))
                carregaPremio(1)
                ddlPremio.SelectedIndex = ddlPremio.Items.IndexOf(ddlPremio.Items.FindByValue(dv(0)("pre_id")))

                Dim dataHora As DateTime = dv(0)("cal_data_premio")
                tbDataPremio.Text = funcoes.TransformaDataDiaMes(dataHora) & "/" & Year(dataHora).ToString
                time.Text = dataHora.ToString("HH:mm:ss")
                tbVoucher.Text = dv(0)("cal_voucher")

                'carregaPremio(2)


            End If

            HabilitarInsercao(False)

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butNew_Click(sender As Object, e As EventArgs) Handles butNew.Click
        Try
            carregaPremio(1)
            'limpaCampos()
            divFormulario.Visible = True
            HabilitarInsercao(True)
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub ddlFiltroCampanha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFiltroCampanha.SelectedIndexChanged
        Try
            carregaPremio(2)
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butSmart_Click(sender As Object, e As EventArgs) Handles butSmart.Click
        Response.Redirect("smartDate.aspx")
    End Sub



#End Region



End Class