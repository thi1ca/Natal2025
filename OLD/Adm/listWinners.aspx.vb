Public Class listWinners
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
            labTitulo.Text = "Lista Premiados "


            'Session.Add("id_user", 1)
            'Session.Add("cadId", 1)

            varSessao = Session.Item("cadId")
            'varSessao = "2"
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaCampanha()
                carregaOrdenacao()
                CarregaGrid()
                limpaCampos()
                'HabilitarInsercao(True)
            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

#Region "FORMULARIO"

    Private Sub carregaCampanha()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select cam_id, cam_nome from campanha where cam_ativo = 1 order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            'ddlCampanha.Items.Clear()
            'ddlCampanha.Items.Add("--- Selecione uma campanha ---")
            'ddlCampanha.Items(0).Value = "0"


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlCampanha.Items.Add(arr(1).Item(f))
                    ddlCampanha.Items(f).Value = arr(0).Item(f)


                Next
            End If
        Catch ex As Exception
            ddlCampanha.Items.Clear()
            ddlCampanha.Items.Add("---ERROR---")
            ddlCampanha.Items(0).Value = "0"
        End Try
    End Sub





    Private Sub limpaCampos()
        Try

            'tbVoucher.Text = ""
            'tbTexto.Text = ""

            'cbAtivo.Checked = True
            ddlCampanha.SelectedIndex = 0

            'tbID.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try

            'If tbNome.Text = "" Then
            '    'labscript.Text = Ado.erroGeral("Preencha o campo descrição")
            '    labscript.Text = "Preencha o nome do prêmio"
            '    'labscript.Visible = True
            '    Return False
            'ElseIf tbNome.Text.Length > 100 Then
            '    labscript.Text = "O nome do prêmio está muito extenso. Por favor, reduza"
            '    'labscript.Visible = True
            '    Return False
            'End If

            If ddlCampanha.SelectedIndex = 0 Then
                'labscript.Text = Ado.erroGeral("Selecione uma Categoria")
                labscript.Text = "Selecione uma Campanha"
                'labscript.Visible = True
                Return False
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

            ddlOrdenacao.Items.Add("Raspados ASC")
            ddlOrdenacao.Items(0).Value = "ras_id asc"

            ddlOrdenacao.Items.Add("Raspados DESC")
            ddlOrdenacao.Items(1).Value = "ras_id desc"

            ddlOrdenacao.Items.Add("Ativos ASC")
            ddlOrdenacao.Items(2).Value = "pre_ativo asc, ras_id asc"

            ddlOrdenacao.Items.Add("Ativos DESC")
            ddlOrdenacao.Items(3).Value = "pre_ativo desc, ras_id desc"




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

            'Trás todos os premiados que FORAM notificados

            sql = "select r.*, cli_nome, cli_cpf, cli_celular, cli_email, pre_nome, pre_voucher_codigo, pre_ativo, cal_data_premio, cal_notificado_email, cal_notificado_whatsapp, ca.pre_id  "
            sql += "from raspados r "
            sql += "inner join cliente c on r.cli_id = c.cli_id "
            sql += "inner join calendario ca on r.cal_id = ca.cal_id "
            sql += "inner join premio p on ca.pre_id = p.pre_id "
            sql += "where ras_premiado = 1 and cam_id = " & ddlCampanha.SelectedValue.ToString & " and cal_notificado_whatsapp = 1 and cal_notificado_email = 1 "




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

    Public Shared Function funcCPF(cpf As String) As String
        Try
            Dim cpfTratado As String = funcoes.MascaraCPF(cpf)
            Return cpfTratado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function funcCelular(celular As String) As String
        Try
            Dim celularTratado As String = funcoes.formataCelular(celular)
            Return celularTratado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function funcEnviado(enviado As Object) As String
        Try
            Dim txtEnviado As String = ""
            If IsDBNull(enviado) = True Then
                txtEnviado = "esperando"
            ElseIf enviado = 0 Then
                txtEnviado = "pendente"
            ElseIf enviado = 1 Then
                txtEnviado = "enviado"
            End If

            Return txtEnviado
        Catch ex As Exception
            Throw ex
        End Try
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
                banco.executa("Update premio set pre_ativo = 0 where pre_id = " & e.CommandArgument.ToString)
                CarregaGrid()
            ElseIf e.CommandName = "Editar" Then
                limpaCampos()


                Dim dv As DataView = banco.consulta("select * from premio where pre_id = " & e.CommandArgument.ToString)

                'tbVoucher.Text = dv(0)("pre_voucher_codigo")

                'tbTexto.Text = dv(0)("pre_texto")
                ' cbAtivo.Checked = dv(0)("pre_ativo")
                ddlCampanha.SelectedIndex = ddlCampanha.Items.IndexOf(ddlCampanha.Items.FindByValue(dv(0)("cam_id")))
                'tbID.Text = e.CommandArgument.ToString
            End If

            'HabilitarInsercao(False)

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub




#End Region


End Class