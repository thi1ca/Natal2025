Public Class _bkp_questions
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim CPF As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            Dim varSessao As String = Session.Item("id_user")
            If varSessao <> "" Then Response.Redirect("myTickets.aspx")

            CPF = Session.Item("CPF")
            If CPF = "" Then Response.Redirect("firstAcess.aspx")

            If Not IsPostBack Then
                carregaPerguntas()
            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try



    End Sub

    Private Sub carregaPerguntas()
        Try
            'Ordem das perguntas:
            '1 - Loja
            '2 - Data
            '3 - Valor
            '4 - Qtd de peças

            Dim dv As DataView = banco.consulta("select r.*, que_questao from resposta r inner join questao q on r.que_id = q.que_id where res_cpf = '" & CPF & "' order by 1 desc")

            If dv.Count = 0 Then
                'Primeiro acesso, primeira pergunta
                montaPergunta1()
            ElseIf IsDBNull(dv(0)("res_cliente")) = True Then
                'Deixou em aberto a ultima resposta
                recuperaUltimaPergunta(dv)
            ElseIf dv.Count = 1 Then
                montaPergunta2()
            ElseIf dv.Count = 2 Then
                montaPergunta3()
            ElseIf dv.Count = 3 Then
                'Verifica se todas estão corretas
                If dv(0)("res_acerto") = True And dv(1)("res_acerto") = True And dv(2)("res_acerto") = True Then
                    'Se sim, direciona para cadastro
                    Response.Redirect("register.aspx")
                Else
                    'Se não, abre mais uma pergunta
                    montaPergunta4()
                End If
            ElseIf dv.Count = 4 Then
                'Verifica se teve 3 perguntas certas
                Dim acertos As Integer = 0
                If dv(0)("res_acerto") = True Then acertos += 1
                If dv(1)("res_acerto") = True Then acertos += 1
                If dv(2)("res_acerto") = True Then acertos += 1
                If dv(3)("res_acerto") = True Then acertos += 1

                If acertos >= 3 Then
                    'Se sim, direciona para cadastro
                    Response.Redirect("register.aspx")
                Else
                    'Se não, direciona para uma tela pedindo para ligar para SAC
                    Response.Redirect("sac.aspx")
                End If
            ElseIf dv.Count > 4 Then
                'Se tiver + de 4 respostas, temos um problema
                'Dispara whatsapp para admin
                whatsapp.mensagem("5511987040377", "Raspadinha - O CPF " & CPF & " respondeu mais do que 4x as perguntas de validação.")
                'Redireciona para tela do SAC
                Response.Redirect("sac.aspx")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub recuperaUltimaPergunta(dv As DataView)
        Try
            labPergunta.Text = dv(0)("que_questao")

            If dv(0)("que_id") = 1 Then
                labResposta1.Text = banco.consultaScalar("select loj_nome from loja where loj_id = " & dv(0)("res_opcao1").ToString)
                labResposta2.Text = banco.consultaScalar("select loj_nome from loja where loj_id = " & dv(0)("res_opcao2").ToString)
                labResposta3.Text = banco.consultaScalar("select loj_nome from loja where loj_id = " & dv(0)("res_opcao3").ToString)

            ElseIf dv(0)("que_id") = 2 Then 'Tratar Datas
                labResposta1.Text = funcoes.formataData(dv(0)("res_opcao1"))
                labResposta2.Text = funcoes.formataData(dv(0)("res_opcao2"))
                labResposta3.Text = funcoes.formataData(dv(0)("res_opcao3"))

            ElseIf dv(0)("que_id") = 3 Then
                labResposta1.Text = FormatNumber(dv(0)("res_opcao1"))
                labResposta2.Text = FormatNumber(dv(0)("res_opcao2"))
                labResposta3.Text = FormatNumber(dv(0)("res_opcao3"))

            Else
                labResposta1.Text = dv(0)("res_opcao1")
                labResposta2.Text = dv(0)("res_opcao2")
                labResposta3.Text = dv(0)("res_opcao3")

            End If

            tbResposta1.Text = dv(0)("res_opcao1")
            tbResposta2.Text = dv(0)("res_opcao2")
            tbResposta3.Text = dv(0)("res_opcao3")

            tbCorreto.Text = dv(0)("res_correta")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub montaPergunta1()
        Try
            labPergunta.Text = banco.consultaScalar("Select top 1 que_questao from Questao where que_id = 1")


            '1 - Ver qual loja foi a ultima compra
            Dim lojId As Integer = banco.consultaScalar("select top 1 loj_id from cupom where cup_cpf = '" & CPF & "' order by cup_cupom_data desc")

            Dim dv As DataView = banco.consulta("select * from (SELECT TOP 3 * FROM Loja ORDER BY CASE WHEN loj_id = " & lojId.ToString & " THEN 0 ELSE 1 END, newid()) a order by newid()")

            labResposta1.Text = dv(0)("loj_nome")
            labResposta2.Text = dv(1)("loj_nome")
            labResposta3.Text = dv(2)("loj_nome")

            tbResposta1.Text = dv(0)("loj_id")
            tbResposta2.Text = dv(1)("loj_id")
            tbResposta3.Text = dv(2)("loj_id")

            tbCorreto.Text = lojId.ToString

            gravaOpcoesDeResposta(CPF, 1, dv(0)("loj_id").ToString, dv(1)("loj_id").ToString, dv(2)("loj_id").ToString, lojId.ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub montaPergunta2()
        Try
            labPergunta.Text = banco.consultaScalar("Select top 1 que_questao from Questao where que_id = 2")

            '2 - Ver qual a data da última compra
            Dim cupomData As Date = banco.consultaScalar("select top 1 cup_cupom_data from cupom where cup_cpf = '" & CPF & "' order by cup_cupom_data desc")

            'Randomizar as datas
            Dim specificDate As Date = New Date(Year(cupomData), Month(cupomData), Day(cupomData))

            ' Add ramdom days to the specific date
            Dim qtdDias1 As Integer = sorteiaAddDays(specificDate, "")
            Dim qtdDias2 As Integer = sorteiaAddDays(specificDate, qtdDias1.ToString)

            Dim RandomDate1 As Date = specificDate.AddDays(qtdDias1)
            Dim RandomDate2 As Date = specificDate.AddDays(qtdDias2)

            ' Create an array of dates
            Dim datesArray As Date() = {specificDate, RandomDate1, RandomDate2}

            Array.Sort(datesArray)

            ' Shuffle the array to show dates in different orders every time it is loaded
            'Dim rnd As New Random()
            'For i As Integer = datesArray.Length - 1 To 0 Step -1
            '    Dim j As Integer = rnd.Next(0, i + 1)
            '    Dim temp As Date = datesArray(i)
            '    datesArray(i) = datesArray(j)
            '    datesArray(j) = temp
            'Next

            labResposta1.Text = funcoes.formataData(datesArray(0)).ToString
            labResposta2.Text = funcoes.formataData(datesArray(1)).ToString
            labResposta3.Text = funcoes.formataData(datesArray(2)).ToString
            tbResposta1.Text = datesArray(0).ToString
            tbResposta2.Text = datesArray(1).ToString
            tbResposta3.Text = datesArray(2).ToString

            tbCorreto.Text = cupomData.ToString

            gravaOpcoesDeResposta(CPF, 2, datesArray(0).ToString, datesArray(1).ToString, datesArray(2).ToString, cupomData.ToString)

            '' Display the shuffled dates
            'For Each dateItem As Date In datesArray
            '    Console.WriteLine(dateItem.ToString("MM/dd/yyyy"))
            'Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub montaPergunta3()
        Try
            labPergunta.Text = banco.consultaScalar("Select top 1 que_questao from Questao where que_id = 3")

            '3 - Ver qual o valor da última compra
            Dim cupomValor As Double = banco.consultaScalar("select top 1 cup_valor from cupom where cup_cpf = '" & CPF & "' order by cup_cupom_data desc")

            'Randomizar as datas
            Dim valorMinimo1, valorMaximo1, valorMinimo2, valorMaximo2 As Double


            If cupomValor < 40 Then
                valorMinimo1 = 75
                valorMaximo1 = 110
                valorMinimo2 = 140
                valorMaximo2 = 230
            ElseIf cupomValor > 120 Then
                valorMinimo1 = 29
                valorMaximo1 = 50
                valorMinimo2 = 80
                valorMaximo2 = 100
            ElseIf cupomValor > 40 And cupomValor < 70 Then
                valorMinimo1 = 19
                valorMaximo1 = 29
                valorMinimo2 = 140
                valorMaximo2 = 230
            Else 'cupomValor > 71 And cupomValor < 119 Then
                valorMinimo1 = 29
                valorMaximo1 = 49
                valorMinimo2 = 160
                valorMaximo2 = 230
            End If


            Dim rnd As New Random()
            Dim randomPrice2 As Integer = rnd.Next(valorMinimo1, valorMaximo1) ' The upper bound is exclusive, so use 8 instead of 7
            Dim randomPrice3 As Integer = rnd.Next(valorMinimo2, valorMaximo2) ' The upper bound is exclusive, so use 8 instead of 7

            Dim cupomValor2 As Double = randomPrice2 + 0.99
            Dim cupomValor3 As Double = randomPrice3 + 0.99


            Dim pricesArray As Double() = {cupomValor, cupomValor2, cupomValor3}

            ' Sort the array in ascending order
            Array.Sort(pricesArray)

            labResposta1.Text = FormatCurrency(pricesArray(0)).ToString
            labResposta2.Text = FormatCurrency(pricesArray(1)).ToString
            labResposta3.Text = FormatCurrency(pricesArray(2)).ToString
            tbResposta1.Text = pricesArray(0).ToString
            tbResposta2.Text = pricesArray(1).ToString
            tbResposta3.Text = pricesArray(2).ToString

            tbCorreto.Text = cupomValor.ToString

            gravaOpcoesDeResposta(CPF, 3, pricesArray(0).ToString, pricesArray(1).ToString, pricesArray(2).ToString, cupomValor.ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub montaPergunta4()
        Try
            labPergunta.Text = banco.consultaScalar("Select top 1 que_questao from Questao where que_id = 4")

            '3 - Ver qual o valor da última compra
            Dim cupomQtdPecas As Integer = banco.consultaScalar("select top 1 cup_qtd_pecas from cupom where cup_cpf = '" & CPF & "' order by cup_cupom_data desc")

            'Randomizar as datas
            Dim valorMinimo1, valorMaximo1, valorMinimo2, valorMaximo2 As Integer


            If cupomQtdPecas = 1 Then
                valorMinimo1 = 2
                valorMaximo1 = 3
                valorMinimo2 = 4
                valorMaximo2 = 6
            ElseIf cupomQtdPecas > 1 And cupomQtdPecas < 4 Then
                '2 ou 3 peças
                valorMinimo1 = 1
                valorMaximo1 = 1
                valorMinimo2 = 4
                valorMaximo2 = 6
            ElseIf cupomQtdPecas > 3 And cupomQtdPecas < 6 Then
                '4 ou 5 peças
                valorMinimo1 = 1
                valorMaximo1 = 1
                valorMinimo2 = 2
                valorMaximo2 = 3
            Else 'acima de 6 peças
                valorMinimo1 = 1
                valorMaximo1 = 2
                valorMinimo2 = 3
                valorMaximo2 = 5
            End If


            Dim rnd As New Random()
            Dim randomPecas As Integer = rnd.Next(valorMinimo1, valorMaximo1 + 1) ' The upper bound is exclusive, so use 8 instead of 7
            Dim randomPecas2 As Integer = rnd.Next(valorMinimo2, valorMaximo2 + 1) ' The upper bound is exclusive, so use 8 instead of 7


            Dim qtdArray As Double() = {cupomQtdPecas, randomPecas, randomPecas2}

            ' Sort the array in ascending order
            Array.Sort(qtdArray)

            labResposta1.Text = qtdArray(0).ToString
            labResposta2.Text = qtdArray(1).ToString
            labResposta3.Text = qtdArray(2).ToString
            tbResposta1.Text = qtdArray(0).ToString
            tbResposta2.Text = qtdArray(1).ToString
            tbResposta3.Text = qtdArray(2).ToString

            tbCorreto.Text = cupomQtdPecas.ToString

            gravaOpcoesDeResposta(CPF, 3, qtdArray(0).ToString, qtdArray(1).ToString, qtdArray(2).ToString, cupomQtdPecas.ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Function sorteiaAddDays(dataReferencia As Date, numeroProibido As String) As Integer
        Try

            Dim diffDatacompraDataHoje As Integer = (Date.Today - dataReferencia).Days

            'Randomizar as datas
            Dim DataMinimo, DataMaximo As Double

            If numeroProibido = "" Then
                If diffDatacompraDataHoje < 7 Then
                    DataMinimo = -14
                    DataMaximo = -7
                ElseIf diffDatacompraDataHoje > 40 Then
                    DataMinimo = 33
                    DataMaximo = 38
                ElseIf diffDatacompraDataHoje > 40 And diffDatacompraDataHoje < 20 Then
                    DataMinimo = 15
                    DataMaximo = 7
                Else 'cupomValor > 20 And cupomValor < 5 Then
                    DataMinimo = 2
                    DataMaximo = 5
                End If
            Else
                If diffDatacompraDataHoje < 7 Then
                    DataMinimo = -27
                    DataMaximo = -20
                ElseIf diffDatacompraDataHoje > 40 Then
                    DataMinimo = 20
                    DataMaximo = 27
                ElseIf diffDatacompraDataHoje > 40 And diffDatacompraDataHoje < 20 Then
                    DataMinimo = -7
                    DataMaximo = -2
                Else 'cupomValor > 20 And cupomValor < 5 Then
                    DataMinimo = -14
                    DataMaximo = -7
                End If
            End If

            'VB.NET code to pick a random number between an interval (-34 And 7)
            Dim rnd As New Random()
            Dim randomNumber As Integer = rnd.Next(DataMinimo, DataMaximo) ' The upper bound is exclusive, so use 8 instead of 7
            If numeroProibido = "" Then
                Return randomNumber
            Else
                If CInt(numeroProibido) <> randomNumber Then
                    Return randomNumber
                Else
                    Return randomNumber - 1
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub gravaOpcoesDeResposta(cpf As String, queId As Integer, opcao1 As String, opcao2 As String, opcao3 As String, resCorreta As String)
        Try

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("res_cpf")
            conteudo.Add(cpf)
            campo.Add("que_id")
            conteudo.Add(queId.ToString)
            campo.Add("res_opcao1")
            conteudo.Add(opcao1.ToString)
            campo.Add("res_opcao2")
            conteudo.Add(opcao2.ToString)
            campo.Add("res_opcao3")
            conteudo.Add(opcao3.ToString)
            campo.Add("res_correta")
            conteudo.Add(resCorreta.ToString)

            ado.incluir("Resposta", campo, conteudo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub butProximo_Click(sender As Object, e As EventArgs) Handles butProximo.Click
        Try
            If validaOpcoes() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Selecione uma Resposta")
                Exit Sub
            End If

            Dim dv As DataView = banco.consulta("Select * from resposta where res_cpf = '" & CPF & "' and res_cliente is null order by 1 desc")

            If dv.Count > 0 Then

                Dim conteudo As New ArrayList
                Dim campo As New ArrayList

                Dim acerto As Boolean = False

                campo.Add("res_cliente")
                If rbResposta1.Checked = True Then
                    conteudo.Add(tbResposta1.Text)
                    If tbCorreto.Text = tbResposta1.Text Then acerto = True
                ElseIf rbResposta2.Checked = True Then
                    conteudo.Add(tbResposta2.Text)
                    If tbCorreto.Text = tbResposta2.Text Then acerto = True
                ElseIf rbResposta3.Checked = True Then
                    conteudo.Add(tbResposta3.Text)
                    If tbCorreto.Text = tbResposta3.Text Then acerto = True
                End If

                campo.Add("res_acerto")
                If acerto = True Then
                    conteudo.Add("1")
                Else
                    conteudo.Add("0")
                End If

                ado.alterar("Resposta", campo, conteudo, "res_id", dv(0)("res_id"))

                limpaCampos()
                carregaPerguntas()

            Else

                carregaPerguntas()
                'Se não tiver pergunta sem resposta no BD, pode ser que clicou em VOLTAR

                'Dim dv2 As DataView = banco.consulta("Select * from resposta where res_cpf = '" & CPF & "' and res_acerto = 1")

                'If dv2.Count >= 3 Then
                '    'Nesse caso ele já acertou 3 perguntas
                '    Dim dvCadastro As DataView = banco.consulta("Select * from cliente where cli_cpf = '" & CPF & "'")

                '    If dvCadastro.Count = 0 Then
                '        'Ainda não tem cadastro
                '        Response.Redirect("register.aspx")
                '    Else
                '        'Já tem cadastro, redirecione para login
                '        Response.Redirect("index.aspx")
                '    End If

                'Else

                'End If


            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Function validaOpcoes() As Boolean
        Try
            If rbResposta1.Checked = False And rbResposta2.Checked = False And rbResposta3.Checked = False Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub limpaCampos()
        rbResposta1.Checked = False
        rbResposta2.Checked = False
        rbResposta3.Checked = False
        tbResposta1.Text = ""
        tbResposta2.Text = ""
        tbResposta3.Text = ""
        tbCorreto.Text = ""
    End Sub
End Class