Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Web.UI.WebControls
Imports System.Web.Script.Serialization
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.IO
Imports System.Threading.Tasks

Public Class teste
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        labscript.Visible = False
        labscript.Text = ""

        'TravaBotaoProximo
        Dim optionsSubmit As PostBackOptions = New PostBackOptions(Button1)
        Button1.OnClientClick = "disableButtonOnClick(this, 'Aguarde...'); "
        Button1.OnClientClick += ClientScript.GetPostBackEventReference(optionsSubmit)

        If Not IsPostBack Then
            carregaChip()
        End If

        'carregaGrafico()
    End Sub

    Private Sub carregaChip()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select chi_id, CONCAT(chi_celular, ' (', CASE WHEN chi_ativo = 1 THEN 'ativo' ELSE 'inativo' END, ')') AS chi_nome_com_status from chip order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlChip.Items.Clear()
            ddlChip.Items.Add("--- Selecione um Chip ---")
            ddlChip.Items(0).Value = "0"


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlChip.Items.Add(arr(1).Item(f))
                    ddlChip.Items(f + 1).Value = arr(0).Item(f)


                Next
            End If
        Catch ex As Exception
            ddlChip.Items.Clear()
            ddlChip.Items.Add("---ERROR---")
            ddlChip.Items(0).Value = "0"
        End Try
    End Sub

    Protected Sub butWhatsapp_Click(sender As Object, e As EventArgs) Handles butWhatsapp.Click
        Try



            Dim msg As String = "Opa. " & vbCrLf
            msg += " E aí? " & vbCrLf & vbCrLf
            msg += "Tudo bem?"

            whatsapp.mensagemPorUmChipEspecifico(tbCelular.Text, msg, ddlChip.SelectedValue.ToString)


        Catch ex As Exception
            labscript.Text = ado.erroGeral(ex.Message)
            labscript.Visible = True
        End Try
    End Sub

    Private Sub carregaGrafico()
        Dim valor1 As Integer = 400
        Dim valor2 As Integer = 200
        Dim valor3 As Integer = 400

        Dim chartData As New StringBuilder()
        chartData.Append("[" & valor1 & ", " & valor2 & ", " & valor3 & "]")

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ChartData", "var chartData = " & chartData.ToString() & ";", True)
    End Sub



    'Private Sub montaPergunta3()
    '    Try
    '        '2 - Ver qual a data da última compra
    '        Dim cupomQtdPecas As Integer = tbValor.Text

    '        'Randomizar as datas
    '        Dim valorMinimo1, valorMaximo1, valorMinimo2, valorMaximo2 As Integer


    '        If cupomQtdPecas = 1 Then
    '            valorMinimo1 = 2
    '            valorMaximo1 = 3
    '            valorMinimo2 = 4
    '            valorMaximo2 = 6
    '        ElseIf cupomQtdPecas > 1 And cupomQtdPecas < 4 Then
    '            '2 ou 3 peças
    '            valorMinimo1 = 1
    '            valorMaximo1 = 1
    '            valorMinimo2 = 3
    '            valorMaximo2 = 6
    '        ElseIf cupomQtdPecas > 3 And cupomQtdPecas < 6 Then
    '            '4 ou 5 peças
    '            valorMinimo1 = 1
    '            valorMaximo1 = 1
    '            valorMinimo2 = 2
    '            valorMaximo2 = 3
    '        Else 'acima de 6 peças
    '            valorMinimo1 = 1
    '            valorMaximo1 = 2
    '            valorMinimo2 = 3
    '            valorMaximo2 = 5
    '        End If


    '        Dim rnd As New Random()
    '        Dim randomPecas As Integer = rnd.Next(valorMinimo1, valorMaximo1 + 1) ' The upper bound is exclusive, so use 8 instead of 7
    '        Dim randomPecas2 As Integer = rnd.Next(valorMinimo2, valorMaximo2 + 1) ' The upper bound is exclusive, so use 8 instead of 7


    '        Dim qtdArray As Double() = {cupomQtdPecas, randomPecas, randomPecas2}

    '        ' Sort the array in ascending order
    '        Array.Sort(qtdArray)

    '        labResposta1.Text = qtdArray(0).ToString
    '        labResposta2.Text = qtdArray(1).ToString
    '        labResposta3.Text = qtdArray(2).ToString


    '        labCorreto.Text = cupomQtdPecas.ToString


    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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
                    Return randomNumber - 7
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Protected Sub butSimular_Click(sender As Object, e As EventArgs) Handles butSimular.Click



    '    Dim cupomData As Date = tbValor.Text

    '    'Randomizar as datas
    '    Dim specificDate As Date = New Date(Year(cupomData), Month(cupomData), Day(cupomData))

    '    ' Add ramdom days to the specific date
    '    Dim qtdDias1 As Integer = sorteiaAddDays(specificDate, "")
    '    Dim qtdDias2 As Integer = sorteiaAddDays(specificDate, qtdDias1.ToString)

    '    Dim RandomDate1 As Date = specificDate.AddDays(qtdDias1)
    '    Dim RandomDate2 As Date = specificDate.AddDays(qtdDias2)

    '    ' Create an array of dates
    '    Dim datesArray As Date() = {specificDate, RandomDate1, RandomDate2}

    '    ' Shuffle the array to show dates in different orders every time it is loaded
    '    Dim rnd As New Random()
    '    For i As Integer = datesArray.Length - 1 To 0 Step -1
    '        Dim j As Integer = rnd.Next(0, i + 1)
    '        Dim temp As Date = datesArray(i)
    '        datesArray(i) = datesArray(j)
    '        datesArray(j) = temp
    '    Next

    '    labResposta1.Text = funcoes.formataData(datesArray(0)).ToString
    '    labResposta2.Text = funcoes.formataData(datesArray(1)).ToString
    '    labResposta3.Text = funcoes.formataData(datesArray(2)).ToString
    'End Sub

    Protected Sub butEmail_Click(sender As Object, e As EventArgs) Handles butEmail.Click
        Try
            'eMail.enviaCodigoAcesso("", tbEmail.Text, "Codigo teste")

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Protected Sub butBancos_Click(sender As Object, e As EventArgs) Handles butBancos.Click
        Try
            Dim connectionStringDB2 As String = "Data source = 1.1.1.1;Initial Catalog=BD1;User ID=a;Password=b"
            Dim connectionStringDB1 As String = "data source=ec2-2.2.2.2.us-east-2.compute.amazonaws.com; initial catalog=BD2; persist security info=False; user id=x; password=y"

            Using conn1 As New SqlConnection(connectionStringDB1)
                conn1.Open()

                Using conn2 As New SqlConnection(connectionStringDB2)
                    conn2.Open()

                    Dim query As String = "
            INSERT INTO Torra_cupons ([Cupom]
           ,[PDV]
           ,[CodLoja]
           ,[NomeLoja]
           ,[Data]
           ,[HoraMinuto]
           ,[ValorCompra]
           ,[CPF]
           ,[Operador]
           ,[Nome])
            SELECT  [Cupom]
           ,[PDV]
           ,[CodLoja]
           ,[NomeLoja]
           ,[Data]
           ,[HoraMinuto]
           ,[ValorCompra]
           ,[CPF]
           ,[Operador]
           ,[Nome]
            FROM Torra_cupons
            WHERE NOT EXISTS (
                SELECT 1
                FROM TTV_DADOS_VENDA_CPF
                WHERE Torra_cupons.CPF = TTV_DADOS_VENDA_CPF.CPF
                  AND Torra_cupons.Cupom = TTV_DADOS_VENDA_CPF.Cupom
                  AND Torra_cupons.PDV = TTV_DADOS_VENDA_CPF.PDV
                  AND Torra_cupons.CodLoja = TTV_DADOS_VENDA_CPF.CodLoja
                  and CPF = '52439085847'
            )"

                    Using cmd As New SqlCommand(query, conn1)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End Using


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Thread.Sleep(7 * 1000) ' Aguarda 10 segundos
        'Response.Redirect("default.html")
    End Sub

    Protected Sub butFuncionario_Click(sender As Object, e As EventArgs) Handles butFuncionario.Click
        Try
            'Busca clientes que não foram analisados se são funcionarios
            Dim dv As DataView = banco.consulta("select top 100 cli_id, cli_cpf, cli_funcionario from cliente where cli_funcionario is null order by 1 desc")

            Dim whereCPF As String = ""
            Dim whereFunc0 As String = ""
            Dim whereFunc1 As String = ""

            Dim sql As String = ""
            If dv.Count > 0 Then
                For f = 0 To dv.Count - 1
                    If whereCPF <> "" Then whereCPF += ", "
                    whereCPF += "'" & dv(f)("cli_cpf") & "' "
                    If dv(f)("cli_cpf") = "12345678955" Then
                        Exit Sub 'Chegou no final
                    End If
                Next

                sql = "select c.cpf, matricula from [TTV_DADOS_VENDA_CPF] c left join ttv_funcionario f on c.cpf = f.cpf where c.cpf in (" & whereCPF & ") group by c.cpf, matricula"
                Dim DVTorra = banco.consultaTorra(sql)

                If DVTorra.Count > 0 Then
                    For T = 0 To DVTorra.Count - 1


                        If IsDBNull(DVTorra(T)("matricula")) = True Then
                            If whereFunc0 <> "" Then whereFunc0 += ", "
                            whereFunc0 += "'" & DVTorra(T)("cpf") & "' "
                        Else
                            If whereFunc1 <> "" Then whereFunc1 += ", "
                            whereFunc1 += "'" & DVTorra(T)("cpf") & "' "
                        End If
                    Next

                    If whereFunc0 <> "" Then
                        sql = "update cliente set cli_funcionario = 0 where cli_cpf in (" & whereFunc0 & ")"
                        banco.executa(sql)
                    End If

                    If whereFunc1 <> "" Then
                        sql = "update cliente set cli_funcionario = 1 where cli_cpf in (" & whereFunc1 & ")"
                        banco.executa(sql)
                    End If
                End If
                Thread.Sleep(5 * 1000) ' Aguarda 5 segundos

                'Roda a funcao de novo
                butFuncionario_Click(sender, e)
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Protected Sub butFuncionario2_Click(sender As Object, e As EventArgs) Handles butFuncionario2.Click
        Try
            'Busca clientes que não foram analisados se são funcionarios, sem compras, atualiza um a um
            Dim dv As DataView = banco.consulta("select cli_id, cli_cpf, cli_funcionario from cliente where cli_funcionario is null order by 1 desc")

            Dim whereCPF As String = ""
            Dim whereFunc0 As String = ""
            Dim whereFunc1 As String = ""

            Dim sql As String = ""
            If dv.Count > 0 Then
                For f = 0 To dv.Count - 1
                    Dim dvTorra As DataView = banco.consultaTorra("select * from ttv_funcionario where cpf = '" & dv(f)("cli_cpf") & "'")
                    If dvTorra.Count > 0 Then
                        banco.executa("update cliente set cli_funcionario = 1 where cli_cpf = '" & dv(f)("cli_cpf") & "'")
                    Else
                        banco.executa("update cliente set cli_funcionario = 0 where cli_cpf = '" & dv(f)("cli_cpf") & "'")
                    End If
                Next
            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Protected Sub butAPIClinte_Click(sender As Object, e As EventArgs) Handles butAPIClinte.Click
        Try
            Dim urlEndpoint As String = "https://api.torratorra.com.br:5703/Auth/v1/Autenticacao" ' Colocar endereço do Endpoint
            'Dim client As New HttpClient
            'Dim url = $"https://api.torratorra.com.br:5703/Auth/v1/Autenticacao"
            'Dim data2 = "{""login"": ""usr_api_raspadinha"", ""senha"":""T_@X#7SNYSFqomR""}"

            'Dim payload = Newtonsoft.Json.JsonConvert.SerializeObject(data2)
            'Dim buffer = Encoding.UTF8.GetBytes(payload)
            'Dim bytes = New Net.Http.ByteArrayContent(buffer)
            'bytes.Headers.ContentType = New Net.Http.Headers.MediaTypeHeaderValue("application/json")

            'Dim request = client.PostAsync(url, bytes)


            Dim login As String = "usr_api_raspadinha"
            Dim senha As String = "T_@X#7SNYSFqomR"
            Dim endpoint As String = "https://api.torratorra.com.br:5703/Auth/v1/Autenticacao"

            Dim token As String = GetToken(endpoint, login, senha)

            Console.WriteLine("Token: " & token)






            Dim client As New HttpClient()

            ' Adiciona os headers
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            client.DefaultRequestHeaders.Add("X-VTEX-API-AppKey", "Coloque aqui a chave") ' Colocar a Chave KEY
            client.DefaultRequestHeaders.Add("X-VTEX-API-AppToken", "coloque aqui o token") 'Colocar o Token

            ' Busca as informações da ordem
            Dim response As HttpResponseMessage = client.GetAsync(urlEndpoint).Result


            If response.IsSuccessStatusCode Then

                Dim content As String = response.Content.ReadAsStringAsync().Result

                'Código mola
                Dim lista As Object = New JavaScriptSerializer().Deserialize(Of Object)(content)


                'presta atencao no tipo de dados que eu pego da collection, é o "list"!!
                Dim idPedidos As String
                Dim cliente As String
                Dim conteudo As New ArrayList
                Dim campo As New ArrayList

                For Each registro As Object In lista("list")

                    'Pega os itens de dentro da collection e poe nas variaveis
                    idPedidos = registro("orderId")
                    cliente = registro("clientName")

                Next

                Dim json As JObject = JObject.Parse(content)

                Dim formattedJson As String = json.ToString(Newtonsoft.Json.Formatting.Indented)

                labAPICliente.Text = formattedJson


            Else
                labAPICliente.Text = "Failed to fetch order: " + response.StatusCode.ToString()
            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Function GetToken(ByVal url As String, ByVal login As String, ByVal senha As String) As String
        Using client As New HttpClient()
            Dim requestBody As New Dictionary(Of String, String) From {
                {"login", login},
                {"senha", senha}
            }

            Dim json As String = JsonConvert.SerializeObject(requestBody)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = client.PostAsync(url, content).Result

            If response.IsSuccessStatusCode Then
                Dim responseBody As String = response.Content.ReadAsStringAsync().Result
                Dim tokenResponse As Autenticacao = JsonConvert.DeserializeObject(Of Autenticacao)(responseBody)

                Return tokenResponse.AccessToken
            Else
                Throw New Exception("Erro ao obter o token: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Public Class Autenticacao
        Public Property Autenticado As Boolean
        Public Property ExpiraEm As Nullable(Of Date)
        Public Property AccessToken As String
        Public Property RefreshToken As String
        Public Property OTP As String
    End Class

    Protected Async Sub butGiftCard_Click(sender As Object, e As EventArgs) Handles butGiftCard.Click
        Try
            Await CriarGiftCard()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try

    End Sub


    Public Async Function CriarGiftCard() As Task
        Try
            ' URL da API VTEX
            Dim url As String = "https://torratorra.vtexcommercestable.com.br/api/giftcards"

            ' Dados da solicitação em JSON
            Dim jsonData As String = "{ ""valor"": 100, ""expiraEm"": ""2024-12-31T23:59:59"" }"

            ' Configurar o cliente HTTP
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Add("X-VTEX-API-AppKey", "vtexappkey-torratorra-XGLGIR")
                client.DefaultRequestHeaders.Add("X-VTEX-API-AppToken", "WQUFMPYATGSOMTNGRYJXMDVCIKROSCTBGZYQLYHXQEHULJJHILGKKLQCDTQQGEDEKUOOCBALVMKZWAKNRKLQXAYGQGRISUYTVEYOCQCNCXBNAMICTXZCZJMYZNOHJAOI")

                ' Preparar o conteúdo da solicitação
                Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

                ' Enviar a solicitação POST e aguardar a resposta
                Dim response As HttpResponseMessage = Await client.PostAsync(url, content).ConfigureAwait(False)

                ' Ler a resposta
                Dim responseText As String = Await response.Content.ReadAsStringAsync().ConfigureAwait(False)
                If response.IsSuccessStatusCode Then
                    ' Exibir a resposta no console (ou manipular conforme necessário)
                    Console.WriteLine("Resposta da API: " & responseText)
                Else
                    ' Tratar o erro da solicitação
                    Console.WriteLine("Erro na solicitação: " & response.StatusCode.ToString())
                    Console.WriteLine("Detalhes do erro: " & responseText)
                End If
            End Using
        Catch ex As Exception
            ' Tratar exceções e exibir a mensagem de erro
            Console.WriteLine("Exceção: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Console.WriteLine("Exceção Interna: " & ex.InnerException.Message)
            End If
        End Try
    End Function


    ' Classe que reflete a estrutura do JSON retornado pela API
    Public Class ApiResponse
        Public Property erro As Boolean
        Public Property createdInstances As Integer
        Public Property maxNumberInstances As Integer
        Public Property message As String
        Public Property instances As List(Of Instance)
    End Class

    Public Class Instance
        Public Property key As String
        Public Property status As String
        Public Property user As User
    End Class

    Public Class User
        Public Property id As String
        Public Property name As String
        Public Property lid As String
    End Class
    Protected Async Sub butConexões_Click(sender As Object, e As EventArgs) Handles butConexões.Click
        Try
            Await LoadDataAsync()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ex.Message
        End Try
    End Sub

    ' Método que faz a requisição assíncrona
    Private Async Function LoadDataAsync() As Task
        Dim apiUrl As String = "https://wpp.sourei.com.br/rest/instance/list"
        Dim token As String = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiV1BQIFNPVVJFSSJ9.ydKDUr3hpLYW_8v6nVQFMnU_oeU0D5P6i_Yc67tFVLQMPksg0IGdn7FsBDWiQDuNIbP_2PkPjfkMrqbIqoR07A"
        Dim apiResponse As ApiResponse = Nothing
        Dim instances As List(Of Instance) = Nothing

        ' Cria um cliente HTTP
        Using client As New HttpClient()
            Try
                ' Adiciona o cabeçalho Authorization com o Bearer Token
                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", token)

                ' Faz a requisição GET
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                ' Lê o conteúdo da resposta como string
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                ' Desserializa o JSON para o objeto ApiResponse
                ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(responseBody)

                ' Verifica se há erro na resposta
                If apiResponse IsNot Nothing AndAlso Not apiResponse.erro Then
                    ' Exibe os dados no GridView
                    If apiResponse.instances IsNot Nothing Then
                        ' Converte a lista de instâncias para um DataTable
                        Dim table As DataTable = ConvertToDataTable(apiResponse.instances)

                        ' Cria um DataView a partir do DataTable
                        Dim dataView As DataView = New DataView(table)

                        ' Filtra os dados, se necessário (exemplo: filtrar por status 'connected')
                        'dataView.RowFilter = "status = 'connected'"

                        ' Exibir os dados do DataView
                        DisplayDataView(dataView)
                        'GridView1.DataSource = apiResponse.instances
                        'GridView1.DataBind()
                    End If
                Else
                    ' Exibe a mensagem de erro
                    labscript.Visible = True
                    labscript.Text = "Erro na API: " & apiResponse.message
                End If

            Catch ex As Exception
                ' Tratar erros
                Response.Write("Erro: " & ex.Message)
            End Try
        End Using
    End Function

    ' Método que converte a lista de instâncias para um DataTable
    Private Function ConvertToDataTable(ByVal instances As List(Of Instance)) As DataTable
        Dim table As New DataTable()

        ' Adiciona as colunas ao DataTable
        table.Columns.Add("key", GetType(String))
        table.Columns.Add("status", GetType(String))
        table.Columns.Add("userId", GetType(String))
        table.Columns.Add("userName", GetType(String))
        table.Columns.Add("userLid", GetType(String))

        ' Adiciona as linhas
        For Each instance As Instance In instances
            Dim userId As String = If(instance.user IsNot Nothing, instance.user.id, String.Empty)
            Dim userName As String = If(instance.user IsNot Nothing, instance.user.name, String.Empty)
            Dim userLid As String = If(instance.user IsNot Nothing, instance.user.lid, String.Empty)

            table.Rows.Add(instance.key, instance.status, userId, userName, userLid)
        Next

        Return table
    End Function

    ' Método para exibir os dados do DataView
    Private Sub DisplayDataView(ByVal dataView As DataView)
        For Each rowView As DataRowView In dataView
            Dim row As DataRow = rowView.Row
            Response.Write("Key: " & row("key") & "<br/>")
            Response.Write("Status: " & row("status") & "<br/>")
            Response.Write("User ID: " & row("userId") & "<br/>")
            Response.Write("User Name: " & row("userName") & "<br/>")
            Response.Write("User LID: " & row("userLid") & "<br/><br/>")
        Next
    End Sub

    'Protected Sub butWhatsappFeedback_Click(sender As Object, e As EventArgs) Handles butWhatsappFeedback.Click
    '    Try
    '        Dim dv As DataView = banco.consulta("select cli_data, * from cliente where cli_data > '2024-04-11' order by 1 desc")

    '        Dim mensagem As String = ""
    '        Dim celular As String = ""
    '        Dim nomeCliente As String = ""

    '        Dim tempo As Integer = 15
    '        For f = 0 To dv.Count - 1
    '            celular = dv(f)("cli_celular")
    '            nomeCliente = funcoes.ExtraiPrimeiroNome(dv(f)("cli_nome"))
    '            mensagem = "Olá " & nomeCliente & ", tudo bem? Aqui é o Thiago Pereira do eComm Torra. " & vbCrLf & vbCrLf & " Vi que você participou do teste do Raspe & Ganhe que iremos lançar em breve nas lojas da Torra. Você teria algum ponto de atenção ou algum feedback sobre a experiência? Pode gravar áudio tbm se preferir."
    '            'celular = "11987040377"

    '            whatsapp.mensagem(celular, mensagem)
    '            'labStatus.Text = dv(f)("cli_nome")
    '            'Console.WriteLine(dv(f)("cli_nome"))
    '            'Response.Flush()
    '            labStatus.Text += dv(f)("cli_nome") & " - OK<br>"
    '            Thread.Sleep(tempo * 1000) ' Aguarda 10 segundos

    '            If tempo = 15 Then
    '                tempo = 20
    '            ElseIf tempo = 20 Then
    '                tempo = 15
    '            Else
    '                tempo = 20
    '            End If


    '        Next

    '    Catch ex As Exception
    '        labscript.Visible = True
    '        labscript.Text = ado.erroGeral(ex.Message)
    '    End Try
    'End Sub
End Class