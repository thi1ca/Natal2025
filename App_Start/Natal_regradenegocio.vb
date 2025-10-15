Public NotInheritable Class Natal_regradenegocio
    Private Sub New()

    End Sub

    Private Shared ReadOnly rndNew As New Random()
    Public Shared Function dataInicio() As String
        'Quando inicia a campanha
        Return "2024-11-20"
    End Function

    Public Shared Function dataFim() As String
        'Quando Finaliza a campanha
        Return "2024-12-25"
    End Function

    Public Shared Function valor() As Double
        'Qual valor multiplo da campanha. A cada x reais...
        Return 50
    End Function

    Public Shared Function multiploTACC() As Integer
        'Quantas vezes multiplica se comprar com TACC
        Return 3
    End Function

    Public Shared Sub executaProcedureCliIdNoCupom(CliId As String, cpf As String)
        Try
            Dim sql As String = "update cupom set cli_id = " & CliId & " where cup_cpf = '" & cpf & "' and cli_id is null"
            banco.executa(sql)
        Catch ex As Exception
            gravarErro("", "executaProcedureCliIdNoCupom", ex.Message, cpf)
            Throw ex
        End Try
    End Sub


#Region "Gera Número da Sorte"

    Public Shared Sub gerarNumeroDaSorte(varSessao As String, varCPF As String)
        Try
            Dim sql As String = "select * from cupom where (cli_id = " & varSessao & " or cup_cpf = '" & varCPF & "') "
            sql += " and cup_valor >= " & valor().ToString & " and cup_cupom_data >= '" & dataInicio() & "' and cup_cupom_data <= '" & dataFim() & "' "
            sql += " and cup_id not in (select distinct cup_id from sorte where cli_id = " & varSessao & " or cli_id is null)"
            Dim dv As DataView = banco.consulta(sql)

            If dv.Count > 0 Then ' Se tiver cupons sem numeros da sorte, executar o numero da sorte
                Dim conteudo As New ArrayList
                Dim campo As New ArrayList

                Dim numeroDaSorte As Integer = 0
                Dim rnd As New Random()
                Dim TACC As Boolean = False
                Dim qtdLoop As Integer = dv.Count - 1
                For f = 0 To dv.Count - 1

                    qtdLoop = qtdDePontos(dv(f)("cup_valor"), dv(f)("TACC"), varSessao, varCPF) - 1 'Verifica qtd de numeros da sorte a serem geradas

                    For x = 0 To qtdLoop 'A cada 50,00, 1 numero da sorte.Se for TACC, ele insere 3x numeros da sorte, senão 1x só
                        'Sorteia um numero da sorte
                        numeroDaSorte = sorteiraUmNumeroDaSorte(varSessao, varCPF)

                        campo.Add("sor_numero")
                        conteudo.Add(numeroDaSorte.ToString)

                        campo.Add("cup_id")
                        conteudo.Add(dv(f)("cup_id").ToString)

                        If IsDBNull(dv(f)("cli_id")) = False Then
                            campo.Add("cli_id")
                            conteudo.Add(dv(f)("cli_id").ToString)
                        End If

                        ado.incluir("Sorte", campo, conteudo)
                        campo.Clear()
                        conteudo.Clear()
                    Next
                Next

            End If
        Catch ex As Exception
            gravarErro("", "gerarNumeroDaSorte", ex.Message, varCPF)
            whatsapp.mensagem("11987040377", "Erro na tela oAuth, função GerarNumeroDaSorte() com cliId=" & varSessao & " e CPF=:" & varCPF & " com erro= " & ex.Message, 0)
            Throw ex
        End Try
    End Sub


    Public Shared Function gerarNumeroDaSorteComplementar(cupId As String) As Integer
        Try
            Dim sql As String = "select cu.*, cli_cpf from cupom cu inner join cliente c on cu.cli_id = c.cli_id where cup_id = " & cupId
            sql += " and cup_valor >= " & valor().ToString & " and cup_cupom_data >= '" & dataInicio() & "' and cup_cupom_data <= '" & dataFim() & "' "

            Dim dv As DataView = banco.consulta(sql)
            Dim qtdLoop As Integer = 0
            Dim qtdTotal As Integer = 0

            If dv.Count > 0 Then ' Se tiver cupons sem numeros da sorte, executar o numero da sorte
                If IsDBNull(dv(0)("cli_id")) = True Then
                    Return 0
                End If

                Dim conteudo As New ArrayList
                Dim campo As New ArrayList

                Dim numeroDaSorte As Integer = 0
                Dim rnd As New Random()
                Dim TACC As Boolean = False

                Dim qtdNumerosJaInseridos = banco.consultaScalar("select count(*) from sorte where cup_id = " & cupId)

                qtdTotal = qtdDePontos(dv(0)("cup_valor"), dv(0)("TACC"), dv(0)("cli_id"), dv(0)("cli_cpf")) - 1 'Verifica qtd de numeros da sorte a serem geradas

                qtdLoop = qtdTotal - qtdNumerosJaInseridos

                For x = 0 To qtdLoop 'A cada 50,00, 1 numero da sorte.Se for TACC, ele insere 3x numeros da sorte, senão 1x só
                    'Sorteia um numero da sorte
                    numeroDaSorte = sorteiraUmNumeroDaSorte(dv(0)("cli_id"), dv(0)("cli_CPF"))

                    campo.Add("sor_numero")
                    conteudo.Add(numeroDaSorte.ToString)

                    campo.Add("cup_id")
                    conteudo.Add(cupId.ToString)

                    If IsDBNull(dv(0)("cli_id")) = False Then
                        campo.Add("cli_id")
                        conteudo.Add(dv(0)("cli_id").ToString)
                    End If

                    ado.incluir("Sorte", campo, conteudo)
                    campo.Clear()
                    conteudo.Clear()
                Next


            End If

            Return qtdLoop + 1
        Catch ex As Exception
            gravarErro("", "gerarNumeroDaSorte", ex.Message, "00000000000")
            whatsapp.mensagem("11987040377", "Erro na tela oAuth, função GerarNumeroDaSorteComplementar()com erro= " & ex.Message, 0)
            Throw ex
        End Try
    End Function



    Public Shared Function qtdDePontos(valorCupom As Double, TACC As Object, varSessao As String, varCPF As String) As Integer
        Try
            Dim ptsTACC As Integer = 0
            'Cartão Torra
            If IsDBNull(TACC) = True Then
                ptsTACC = 1
            ElseIf TACC = 0 Then
                ptsTACC = 1
            Else
                ptsTACC = multiploTACC()
            End If

            valorCupom = valorCupom / valor() 'Qtos multiplos de 50 tem?
            Dim aCada50 As Integer = Math.Floor(valorCupom) 'Pega o valor inteiro

            qtdDePontos = aCada50 * ptsTACC

            Return qtdDePontos

        Catch ex As Exception
            gravarErro("", "qtdDePontos", ex.Message, varCPF)
            whatsapp.mensagem("11987040377", "Erro na tela oAuth, função qtdDePontos() com cliId=" & varSessao & " e CPF=:" & varCPF & " com erro= " & ex.Message, 0)
            Throw ex
        End Try
    End Function

    Public Shared Function sorteiraUmNumeroDaSorte(varSessao As String, varCPF As String) As Integer
        Try
            ' Dim rnd As New Random()
            Dim numeroDaSorte As Integer
            SyncLock rndNew
                numeroDaSorte = rndNew.Next(1, 10000001) ' The upper bound is exclusive, so use 11 instead of 10 for example
            End SyncLock
            ' Verifica se o número já existe no banco de dados
            If ExisteNoBanco(numeroDaSorte, varSessao, varCPF) Then
                If numeroDaSorte <= 5000000 Then
                    ' Incrementa +1 até encontrar um número não existente
                    Do
                        numeroDaSorte += 1
                    Loop While ExisteNoBanco(numeroDaSorte, varSessao, varCPF) AndAlso numeroDaSorte <= 10000000 ' Garante que não ultrapassa o limite superior
                Else
                    ' Decrementa -1 até encontrar um número não existente
                    Do
                        numeroDaSorte -= 1
                    Loop While ExisteNoBanco(numeroDaSorte, varSessao, varCPF) AndAlso numeroDaSorte >= 1 ' Garante que não ultrapassa o limite inferior
                End If
            End If

            Return numeroDaSorte
        Catch ex As Exception
            gravarErro("", "sorteiraUmNumeroDaSorte", ex.Message, varCPF)
            whatsapp.mensagem("11987040377", "Erro na tela oAuth, função sorteiaUmNumeroDaSorte() com cliId=" & varSessao & " e CPF=:" & varCPF & " com erro= " & ex.Message, 0)
            Throw ex
        End Try

    End Function

    Public Shared Function procuraOutroNumeroDaSorte(numeroAtual As Integer) As Integer
        Try
            Dim numeroNovo As Integer

            If numeroAtual <= 5000000 Then
                numeroNovo = numeroAtual + 1
            Else
                numeroNovo = numeroAtual - 1
            End If

            If ExisteNoBanco(numeroNovo, "", "") Then
                If numeroNovo <= 5000000 Then
                    ' Incrementa +1 até encontrar um número não existente
                    Do
                        numeroNovo += 1
                    Loop While ExisteNoBanco(numeroNovo, "", "") AndAlso numeroNovo <= 10000000 ' Garante que não ultrapassa o limite superior
                Else
                    ' Decrementa -1 até encontrar um número não existente
                    Do
                        numeroNovo -= 1
                    Loop While ExisteNoBanco(numeroNovo, "", "") AndAlso numeroNovo >= 1 ' Garante que não ultrapassa o limite inferior
                End If
            End If

            Return numeroNovo

        Catch ex As Exception
            gravarErro("admin", "AjustaUmNumeroDaSorte", ex.Message, "")
            whatsapp.mensagem("11987040377", "Erro na tela Adm Deduplica numero da sorte, função procuraOutroNumeroDaSorte() com erro= " & ex.Message, 0)
            Throw ex
        End Try
    End Function


    Public Shared Function ExisteNoBanco(numeroSugerido As Integer, varSessao As String, varCPF As String) As Boolean
        Try
            ' Aqui você deve implementar a lógica para consultar o banco de dados e verificar se o número existe.
            Dim dv As DataView = banco.consulta("select * from sorte where sor_numero = " & numeroSugerido.ToString)

            If dv.Count = 0 Then 'Não existe
                Return False
            Else                 'Existe
                Return True
            End If

        Catch ex As Exception
            gravarErro("", "ExisteNoBanco", ex.Message, varCPF)
            whatsapp.mensagem("11987040377", "Erro na função ExisteBanco(), possivel tela oAuth com cliId=" & varSessao & " e CPF=:" & varCPF & " com erro= " & ex.Message, 0)
            Throw ex
        End Try
    End Function



#End Region




    Public Shared Sub carregaCuponsDeLojaPorCPF(CPF As String)
        Try
            Dim sql As String

            'Apaga dados deste CPF na tabela temporária
            sql = "delete from Torra_cupons where cpf = '" & CPF & "'"
            banco.executa(sql)


            Dim dvTorra As DataView = banco.consultaTorra("select * from TTV_DADOS_VENDA_CPF where cpf = '" & CPF & "' and (codLoja < 2000 or codLoja >= 6000) and data >= '" & dataInicio() & "' and data <= '" & dataFim() & "' and valorCompra >= " & valor().ToString & " order by data desc, HoraMinuto desc")

            If dvTorra.Count > 0 Then
                Dim conteudo As New ArrayList
                Dim campo As New ArrayList

                'Dim varData As Date 'Verificava quando tinha regra de limitação de datas antes de 01-05-2024 (teste Penha)
                'Nessa época: A partir do dia 01/05/2024, cliente pode ter quantas raspadinhas quiser. Se tiver, não puxar compras antes disso
                'Se não tiver nenhuma compra a partir do dia 01/05, pegar apenas 1 antes disso
                'Agora, pega tudo a partir do dia 01/08/2024

                For f = 0 To dvTorra.Count - 1

                    'Regra desativada por conta do inicio oficial da campanha
                    'varData = dvTorra(f)("Data")
                    'If f > 0 Then
                    '    If varData < CDate("2024-5-1") Then
                    '        Exit For
                    '    End If
                    'End If

                    campo.Add("Cupom")
                    conteudo.Add(dvTorra(f)("Cupom").ToString)

                    campo.Add("PDV")
                    conteudo.Add(dvTorra(f)("PDV").ToString)

                    campo.Add("CodLoja")
                    conteudo.Add(dvTorra(f)("CodLoja").ToString)

                    campo.Add("NomeLoja")
                    conteudo.Add(dvTorra(f)("NomeLoja"))

                    campo.Add("Data")
                    conteudo.Add(funcoes.TransformaDataAnoMesDia(dvTorra(f)("Data")))

                    campo.Add("HoraMinuto")
                    conteudo.Add(dvTorra(f)("HoraMinuto").ToString)
                    'conteudo.Add(Minute(dvTorra(f)("HoraMinuto")).ToString & ":" & Second(dvTorra(f)("HoraMinuto")).ToString & ":00")

                    campo.Add("ValorCompra")
                    conteudo.Add(dvTorra(f)("ValorCompra").ToString.Replace(",", "."))

                    campo.Add("CPF")
                    conteudo.Add(dvTorra(f)("CPF").ToString)

                    campo.Add("Operador")
                    conteudo.Add(dvTorra(f)("Operador").ToString)

                    campo.Add("Nome")
                    conteudo.Add(dvTorra(f)("Nome"))

                    'Novo campo Valor gasto com Cartão Torra
                    If IsDBNull(dvTorra(f)("vlrCartaoTorra")) = False Then
                        campo.Add("TACC")
                        conteudo.Add(dvTorra(f)("vlrCartaoTorra").ToString.Replace(",", "."))
                    End If

                    ado.incluir("Torra_cupons", campo, conteudo)

                    campo.Clear()
                    conteudo.Clear()
                Next


                'Insere dados buscados da tabela temp para tabela cupom
                sql = "insert into Cupom ( [cup_cpf] "
                sql += " ,[cup_cupom_codigo] "
                sql += " ,[cup_cupom_data] "
                sql += " ,[cup_valor] "
                sql += " ,[loj_id] "
                sql += " ,[cam_id] "
                sql += " ,[cli_id] "
                sql += " ,[Cupom] "
                sql += " ,[PDV] "
                sql += " ,[Operador] "
                sql += " ,[TACC] "
                sql += " ,[NomeOperador]) "

                sql += " select "
                sql += " CPF, "
                sql += " CONCAT(Cupom, PDV, CodLoja, FORMAT([data], 'yyyyMMdd')) AS cupom, "
                sql += " CAST(Data AS DATETIME) + CAST(HoraMinuto AS DATETIME), "
                sql += " ValorCompra, "
                sql += " CodLoja, "
                sql += " 2, "
                sql += " null, "
                sql += " Cupom, "
                sql += " PDV, "
                sql += " Operador, "
                sql += " TACC, "
                sql += " Nome "
                sql += " from Torra_cupons "
                sql += " where cpf = '" & CPF & "' "
                sql += " and [Data] >= '" & dataInicio() & "' "
                sql += " and [Data] <= '" & dataFim() & "' "
                sql += " And Not Exists ( "
                sql += " Select 1 from Cupom "
                sql += " where Torra_cupons.CodLoja = Cupom.loj_id "
                sql += " And Torra_cupons.PDV = Cupom.PDV "
                sql += " and Torra_cupons.cpf = cupom.cup_cpf "
                sql += " And torra_cupons.Cupom = cupom.Cupom )"

                banco.executa(sql)

                'Apaga dados deste CPF na tabela temporária
                sql = "delete from Torra_cupons where cpf = '" & CPF & "'"
                banco.executa(sql)

            Else
                'Não encontrou cupons no periodo da ação

            End If
        Catch ex As Exception
            gravarErro("", "carregaCuponsDeLojaPorCPF", ex.Message, CPF)
            Throw ex
        End Try
    End Sub

    Public Shared Sub gravarErro(pagina As String, funcao As String, erro As String, cpf As String)
        Try
            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("err_cpf")
            conteudo.Add(cpf)

            'campo.Add("err_pagina")
            'conteudo.Add(pagina)

            campo.Add("err_funcao")
            conteudo.Add(funcao)

            Dim msg As String = erro
            msg = erro.Replace("'", " ").Replace(vbCrLf, " ").Replace("""", " ")

            campo.Add("err_erro")
            conteudo.Add(msg)

            ado.incluir("erro", campo, conteudo)
            campo.Clear()
            conteudo.Clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
