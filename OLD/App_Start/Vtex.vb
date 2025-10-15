Imports Microsoft.VisualBasic
Imports System.Web.Script.Serialization
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Vtex

    Public Shared Function caminhoAPIVtex(tipo As Integer) As String
        Try
            Dim caminho As String = ""

            If tipo = 1 Then 'Trás varios pedidos
                caminho = "https://torratorra.vtexcommercestable.com.br/api/oms/pvt/orders?page=1&per_page=5&f_creationDate=creationDate%3A%5B2023-08-20T02%3A00%3A00.000Z%20TO%202023-08-21T01%3A59%3A59.999Z%5D"
                'caminho = "https://torratorra.vtexcommercestable.com.br/api/oms/pvt/orders"
            ElseIf tipo = 2 Then 'Trás 1 pedido
                caminho = "https://torratorra.vtexcommercestable.com.br/api/oms/pvt/orders/" 'Todo: Colocar o caminho para trazer detalhes de 1 pedido
            Else
                caminho = "" 'Todo: Colocar outros caminhos

            End If

            Return caminho
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function chaves(chave As String) As String
        Try

            If chave = "token" Then
                Return "SGBTPQEGHZUBGKCEYNPFICKMUUIOHLACZOPAJFRYCRSDMLJSXOQWFQSKYOCMAVRPCEJWPTBMNZPGJOGJNEDVJNPDYGWIWAAOBOZDFBBNBHYSXTAFAXGKCFOKIOBJQNNH"
            ElseIf chave = "key" Then
                Return "vtexappkey-torratorra-XHUUDR"
            End If

            Return ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function vtexVariosPedidos() As String

        Dim urlEndpoint As String = caminhoAPIVtex(1)
        'urlEndpoint += "?"
        'urlEndpoint += "orderBy=creationDate%2Casc"
        'urlEndpoint += "&per_page=5&page=2"
        'urlEndpoint += "&f_creationDate=creationDate%3A%5B"
        'urlEndpoint += "2016-01-01"
        'urlEndpoint += "T02%3A00%3A00.000Z%20"
        'urlEndpoint += "TO20%"
        'urlEndpoint += "2021-01-01"
        'urlEndpoint += "T01%3A59%3A59.999Z%5D"

        'https://torratorra.vtexcommercestable.com.br/api/oms/pvt/orders?orderBy=creationDate%2Casc&per_page=5&page=2&f_creationDate=creationDate%3A%5B2016-01-01T02%3A00%3A00.000Z%20TO%202021-01-01T01%3A59%3A59.999Z%5D

        Dim client As New HttpClient()



        ' Adiciona os headers
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        client.DefaultRequestHeaders.Add("X-VTEX-API-AppKey", chaves("key"))
        client.DefaultRequestHeaders.Add("X-VTEX-API-AppToken", chaves("token"))

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

                'E depois enfia essa merda na BASE!
                campo.Add("vtex_nome")
                conteudo.Add(cliente)

                campo.Add("vtex_pedido")
                conteudo.Add(idPedidos)

                ado.incluir("vtex_teste", campo, conteudo)

                campo.Clear()
                conteudo.Clear()

            Next

            'Dim orders As Dynamic = JsonConvert.DeserializeObject(content)
            ''Dim orders As List(Of Content) = JsonConvert.DeserializeObject(Of List(Of Content))(JsonConvert)


            'For Each order As Dynamic.DynamicObject In orders

            'Next

            'Dim json As Object = JsonConvert.DeserializeObject(Of Object)(content)

            'Dim x As String = json("orderId")


            Dim json As JObject = JObject.Parse(content)

            ' Dim x As String = json("clientName")

            ''Teste sem sucesso
            'Dim labtexto As String
            'For f = 0 To json.Count - 1
            '    labtexto = json.SelectToken("clientName")
            'Next

            'Dim clientProfileData As JObject = json("clientProfileData")
            'Dim firstName As String = clientProfileData("firstName").ToString()

            Dim formattedJson As String = json.ToString(Newtonsoft.Json.Formatting.Indented)

            Return formattedJson



            'Dim totals As JArray = json("totals")
            'Dim value As Integer

            'For Each total As JObject In totals
            '    If total("id").ToString() = "Items" Then
            '        value = CInt(total("value"))
            '        Exit For
            '    End If
            'Next




            '    If json.Property("sequence") IsNot Nothing Then
            '        Dim sequence As String = json("sequence").ToString()
            '        labTexto.Text = sequence
            '        labTexto.Visible = True
            '    Else
            '        labTexto.Text = "A propriedade 'sequence' não foi encontrada na resposta JSON."
            '        labTexto.Visible = True
            '    End If
        Else
            Return "Failed to fetch order: " + response.StatusCode.ToString()
        End If



        'If response.IsSuccessStatusCode Then

        '    ' Busca as informações da order
        '    Dim response1 As HttpResponseMessage = client.GetAsync(urlEndpoint).Result
        '    If response1.IsSuccessStatusCode Then
        '        Dim content As String = response1.Content.ReadAsStringAsync().Result
        '        Dim json As JObject = JObject.Parse(content)
        '        Dim formattedJson As String = json.ToString(Newtonsoft.Json.Formatting.Indented)


        '        labTexto.Text = formattedJson
        '        labTexto.Text = json(0)("sequence")
        '        labTexto.Visible = True
        '    Else
        '        labTexto.Text = "Failed to fetch order: " + response.StatusCode.ToString()
        '        labTexto.Visible = True
        '    End If






        '    'Dim content = response.Content.ReadAsStringAsync().Result

        '    'labTexto.Text = content
        '    'Dim fulano = JsonConvert.DeserializeObject(Of List(Of IbgeMun))(json)

        '    'labTexto.Text = content
        '    labTexto.Visible = True
        'Else
        '    Console.WriteLine("Failed to fetch order: " + response.StatusCode.ToString())

        'End If


    End Function

    Public Shared Function vtexDetalhePedido(pedido As String) As String
        Dim orderId As String = pedido
        Dim urlEndpoint As String = caminhoAPIVtex(2) & orderId

        Dim client As New HttpClient()

        ' Adiciona os headers
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        client.DefaultRequestHeaders.Add("X-VTEX-API-AppKey", chaves("key"))
        client.DefaultRequestHeaders.Add("X-VTEX-API-AppToken", chaves("token"))

        ' Busca as informações da ordem
        Dim response As HttpResponseMessage = client.GetAsync(urlEndpoint).Result


        If response.IsSuccessStatusCode Then

            Dim content As String = response.Content.ReadAsStringAsync().Result




            Dim json As JObject = JObject.Parse(content)

            'For Each total As JObject In json
            '    If total("id").ToString() = "Items" Then
            '        value = CInt(total("value"))
            '        Exit For
            '    End If
            'Next



            Dim formattedJson As String = json.ToString(Newtonsoft.Json.Formatting.Indented)

            Return formattedJson

        Else
            Return "Failed to fetch order: " + response.StatusCode.ToString()
        End If

    End Function

    'Private Sub LogLargeResponse(content As String)
    '    Dim maxLength As Integer = 5000
    '    Dim length As Integer = content.Length
    '    Dim startIndex As Integer = 0

    '    While startIndex < length
    '        Dim endIndex As Integer = startIndex + maxLength
    '        If endIndex > length Then
    '            endIndex = length
    '        End If
    '        Dim part As String = content.Substring(startIndex, endIndex - startIndex)
    '        Console.WriteLine(part)
    '        startIndex = endIndex
    '    End While

    'End Sub

    Private Sub inserePedidosVtex(dados As JObject)
        Try
            Dim conteudo As New ArrayList
            Dim campo As New ArrayList




            campo.Add("vtex_nome")
            conteudo.Add(dados.SelectToken("clientName"))

            campo.Add("vtex_pedido")
            conteudo.Add(dados.SelectToken("orderId"))

            ado.incluir("vtex_teste", campo, conteudo)

            campo.Clear()
            conteudo.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function Mola() As String

        Dim urlEndpoint As String = "https://torratorra.vtexcommercestable.com.br/api/oms/pvt/orders?page=1&per_page=5&f_creationDate=creationDate%3A%5B2023-08-20T02%3A00%3A00.000Z%20TO%202023-08-21T01%3A59%3A59.999Z%5D"

        Dim client As New HttpClient()

        ' Adiciona os headers
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        client.DefaultRequestHeaders.Add("X-VTEX-API-AppKey", chaves("key"))
        client.DefaultRequestHeaders.Add("X-VTEX-API-AppToken", chaves("token"))

        ' Busca as informações da ordem
        Dim response As HttpResponseMessage = client.GetAsync(urlEndpoint).Result

        If response.IsSuccessStatusCode Then

            Dim content As String = response.Content.ReadAsStringAsync().Result

            '                Dim orders As Dynamic = JsonConvert.DeserializeObject(content)
            ''Dim orders As List(Of Content) = JsonConvert.DeserializeObject(Of List(Of Content))(JsonConvert)


            'For Each order As Dynamic.DynamicObject In orders

            'Next

            'Dim json As Object = JsonConvert.DeserializeObject(Of Object)(content)

            'Dim x As String = json("orderId")


            Dim json As JObject = JObject.Parse(content)

            Dim x As String = json("clientName")

            ''Teste sem sucesso
            'Dim labtexto As String
            'For f = 0 To json.Count - 1
            '    labtexto = json.SelectToken("clientName")
            'Next

            'Dim clientProfileData As JObject = json("clientProfileData")
            'Dim firstName As String = clientProfileData("firstName").ToString()

            Dim formattedJson As String = json.ToString(Newtonsoft.Json.Formatting.Indented)

            Return formattedJson



            'Dim totals As JArray = json("totals")
            'Dim value As Integer

            'For Each total As JObject In totals
            '    If total("id").ToString() = "Items" Then
            '        value = CInt(total("value"))
            '        Exit For
            '    End If
            'Next




            '    If json.Property("sequence") IsNot Nothing Then
            '        Dim sequence As String = json("sequence").ToString()
            '        labTexto.Text = sequence
            '        labTexto.Visible = True
            '    Else
            '        labTexto.Text = "A propriedade 'sequence' não foi encontrada na resposta JSON."
            '        labTexto.Visible = True
            '    End If
        Else
            Return "Failed to fetch order: " + response.StatusCode.ToString()
        End If



        'If response.IsSuccessStatusCode Then

        '    ' Busca as informações da order
        '    Dim response1 As HttpResponseMessage = client.GetAsync(urlEndpoint).Result
        '    If response1.IsSuccessStatusCode Then
        '        Dim content As String = response1.Content.ReadAsStringAsync().Result
        '        Dim json As JObject = JObject.Parse(content)
        '        Dim formattedJson As String = json.ToString(Newtonsoft.Json.Formatting.Indented)


        '        labTexto.Text = formattedJson
        '        labTexto.Text = json(0)("sequence")
        '        labTexto.Visible = True
        '    Else
        '        labTexto.Text = "Failed to fetch order: " + response.StatusCode.ToString()
        '        labTexto.Visible = True
        '    End If






        '    'Dim content = response.Content.ReadAsStringAsync().Result

        '    'labTexto.Text = content
        '    'Dim fulano = JsonConvert.DeserializeObject(Of List(Of IbgeMun))(json)

        '    'labTexto.Text = content
        '    labTexto.Visible = True
        'Else
        '    Console.WriteLine("Failed to fetch order: " + response.StatusCode.ToString())

        'End If


    End Function

End Class
