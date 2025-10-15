Public Class regularizaNumeroDaSorte
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
            labTitulo.Text = "Regulariza Números da Sorte"

            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            Dim varNivel As Integer = Session.Item("Nivel")
            'If varNivel < 10 Then Response.Redirect("dashboard.aspx")

            If Not IsPostBack Then

            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub







    Private Sub butGerar_Click(sender As Object, e As EventArgs) Handles butSemNumeros.Click
        Try
            'If IsNumeric(tbCliId.Text.Trim) = False Then
            '    labscript.Visible = True
            '    labscript.Text = ado.erroGeral("cli_id precisa ser só numero")
            '    Exit Sub
            'End If
            'Dim cliId As String = tbCliId.Text.Trim
            'Dim msg, cpf, nome, Celular As String

            CarregaGrid()



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub


    Private Sub CarregaGrid()
        Try
            Dim IntCont As Integer = 0
            Dim sql, sqlCount As String

            Dim dataFinal As Date = Date.Today.AddDays(-1) 'Não pegar clientes que estão em processo de cadastramento 

            sql = "select cu.cup_id, cup_cpf, cup_cupom_codigo, cup_cupom_data, cup_valor, loj_id, c.cli_id, tacc, cli_cpf, cli_nome, cli_celular, cli_email, cli_nascimento, gen_id, cli_termos, cli_funcionario  from cupom cu inner join cliente c on cu.cli_id = c.cli_id where cli_nascimento is not null and gen_id is not null and cli_termos = 1 and cli_funcionario = 0 and cu.cup_valor >= 50 and cu.cup_cupom_data >= '2024-11-20' and cu.cup_cupom_data <= '" & funcoes.TransformaDataAnoMesDia(dataFinal).ToString & "' and cup_id not in (select distinct cup_id from sorte)"




            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cli_ativo desc, cli_nome asc"
            sql += "   order by cup_valor asc "

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 10


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql

            'comentário:executando
            es = container.gerar(Repeater1, es)

            Session.Add("es", es)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
                Dim btnGerarNumeros As Button = CType(e.Item.FindControl("butGerarNumeros"), Button)
                btnGerarNumeros.CommandName = "semNumeros"
                btnGerarNumeros.CommandArgument = DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(0)

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
            If e.CommandName = "semNumeros" Then
                Dim cupId As String = e.CommandArgument

                Dim dv As DataView = banco.consulta("select * from cliente where cli_id = (select cli_id from cupom where cup_id = " & cupId & ")")

                ' Dim dv As DataView = banco.consulta("select ")
                Dim cliId As String = dv(0)("cli_id")
                Dim CPF As String = dv(0)("cli_cpf")
                Dim nome As String = dv(0)("cli_nome")
                Dim varEmail As String = dv(0)("cli_email")
                Natal_regradenegocio.executaProcedureCliIdNoCupom(cliId, CPF) 'Verifica se tem algum cupom sem cli_id
                Natal_regradenegocio.gerarNumeroDaSorte(cliId, CPF)

                eMail.enviaEmailClienteNumerosGerados(nome, varEmail, "Seus números da sorte foram gerados. Acesse o APP caso queira visualizá-los.")

                'labscript.Text = ado.erroGeral("Números Gerados para o CPF " & funcoes.MascaraCPF(CPF), True)
                'labscript.Visible = True

                CarregaGrid()

            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Public Shared Function funcAtivo(ativo As Boolean) As String
        If ativo = True Then
            Return "Ativo"
        Else
            Return "Desabilitado"
        End If
    End Function

    Public Shared Function FuncCPF(cpf As String) As String
        Try
            Return funcoes.MascaraCPF(cpf)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function funcTACC(TACC As Object) As String
        Try
            If IsDBNull(TACC) = True Then
                Return ""
            ElseIf TACC = 0 Then
                Return ""
            Else
                Return "CT"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FuncCalendario(data As Date) As String
        Try
            Return funcoes.formataNascimento(data)


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub butDeduplicar_Click(sender As Object, e As EventArgs) Handles butDeduplicar.Click
        Try
            'Vamos pegar os 5 primeiros números da sorte duplicados e fazer um loop
            Dim dv As DataView = banco.consulta("select top 10 sor_numero, count(sor_numero)total, max(sor_data) dataConflito from sorte group by sor_numero having count(sor_numero) > 1 order by 3 desc")

            If dv.Count > 0 Then

                For f = 0 To dv.Count - 1 'Loop para cada número da sorte duplicado.
                    Dim numeroSorteAtual As Integer = dv(f)("sor_numero")

                    Dim dv2 As DataView = banco.consulta("select cup_id, count(cup_id), cli_id from sorte where cup_id in (select cup_id from sorte where sor_numero = " & numeroSorteAtual.ToString & ") group by cup_id, cli_id order by 2 desc")


                    'Aqui irá fazer o looping deixando 1 sem fazer
                    'Irá priorizar quem tem mais numero da sorte para realizar a troca
                    For a = 0 To dv2.Count - 2
                        Dim numeroSorteNovo As Integer = Natal_regradenegocio.procuraOutroNumeroDaSorte(numeroSorteAtual)
                        Dim sorId As Integer = banco.consultaScalar("select sor_id from sorte where cup_id = " & dv2(a)("cup_id").ToString & " and cli_id = " & dv2(a)("cli_id").ToString & " and sor_numero = " & numeroSorteAtual.ToString)

                        Dim sorData As DateTime = dv(f)("dataConflito")

                        'Inserir dados na tabela Sorte_erro
                        Dim conteudo As New ArrayList
                        Dim campo As New ArrayList

                        campo.Add("sor_numero")
                        conteudo.Add(numeroSorteAtual.ToString)

                        campo.Add("cup_id")
                        conteudo.Add(dv2(a)("cup_id").ToString)

                        If IsDBNull(dv2(a)("cli_id")) = False Then
                            campo.Add("cli_id")
                            conteudo.Add(dv2(a)("cli_id").ToString)
                        End If

                        campo.Add("sor_data")
                        conteudo.Add(funcoes.TransformaDataAnoMesDia(sorData).ToString & " " & sorData.Hour.ToString & ":" & sorData.Minute.ToString & ":" & sorData.Second.ToString & "." & sorData.Millisecond.ToString)

                        campo.Add("ser_obs")
                        conteudo.Add("Deduplicado via admin")

                        campo.Add("sor_id")
                        conteudo.Add(sorId.ToString)


                        ado.incluir("Sorte_erro", campo, conteudo)

                        campo.Clear()
                        conteudo.Clear()


                        banco.executa("update sorte set sor_numero = " & numeroSorteNovo.ToString & " where sor_id = " & sorId.ToString & " and sor_numero = " & numeroSorteAtual.ToString & " and cli_id = " & dv2(a)("cli_id").ToString & " and cup_id = " & dv2(a)("cup_id").ToString)

                    Next

                Next

                labscript.Visible = True
                labscript.Text = ado.erroGeral("Foram realizados " & dv.Count.ToString & " Deduplicações com sucesso", True)

            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub
End Class