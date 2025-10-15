Imports Microsoft.VisualBasic
Imports System.Net.Http
Imports Newtonsoft.Json




Public NotInheritable Class whatsapp 'NotInheritable

        Private Sub New()
            'private para nao instanciar
        End Sub

        Public Class MessageData
            <JsonProperty("to")>
            Public Property [To] As String

            <JsonProperty("text")>
            Public Property Text As String
        End Class

        Public Class Payload
            <JsonProperty("messageData")>
            Public Property MessageData As MessageData
        End Class

    Public Shared Sub mensagem(numero As String, mensagem As String, cliId As Integer)
        Try

            'ORIENTAÇÃO SE EXPIRAR
            '1) https://wpp.sourei.com.br/docs/
            '2) Clica em AUTHORIZE, coloca o token, que é o código depois do Bearer
            '3) CRTRL + F e procure por QRCODE. Expanda o normal (não o base64)
            '4) Clique em Try it out
            '5) Coloque autonotify-58f432a45c
            '6) Clique em execute.
            '7) Copie a tag gigante dentro do scr e cole no navegador. Vai gerar QRCode. Escaneie no whats para conectar.


            'Dim url As String = https://rube.megaapi.com.br/rest/sendMessage/autonotify-58f432a45c/text


            '1- autonotify-58f432a45c
            '2- autonotify-xO092c
            '3- autonotify-4kc4x5


            'autonotify = "autonotify-58f432a45c"
            'autonotify = "autonotify-xO092c"
            'autonotify = "autonotify-4kc4x5"

            Dim notificacao As String = ""
            notificacao = Autonotify(cliId)

            If notificacao = "" Then Throw New Exception("Erro ao tentar enviar a mensagem por whatsapp")

            Dim url As String = "https://wpp.sourei.com.br/rest/sendMessage/" & notificacao & "/text"

            Dim toAddress As String = "55" & numero
            toAddress += "@s.whatsapp.net"

            Dim messageData As New MessageData With {.To = toAddress, .Text = mensagem}
            Dim payload As New Payload With {.MessageData = messageData}
            Dim jsonPayload As String = JsonConvert.SerializeObject(payload)

            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Dim client As New HttpClient()

            ' Adicionando os headers
            'client.DefaultRequestHeaders.Add("Content-Type", "application/json")
            'client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiUnViZSJ9.PfhDZ2MpY0flKGLSxdTwOL-XIDog0222uw2J_FjIFr53N-fuEHG2rzb6-mvsRyr7IHIKclSe-WmLMrdYSCsoCw")
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiV1BQIFNPVVJFSSJ9.ydKDUr3hpLYW_8v6nVQFMnU_oeU0D5P6i_Yc67tFVLQMPksg0IGdn7FsBDWiQDuNIbP_2PkPjfkMrqbIqoR07A")


            Dim response As HttpResponseMessage = client.PostAsync(url, content).Result


            'If response.IsSuccessStatusCode Then
            '    labTexto.Text = "Message sent successfully!"
            'Else
            '    Dim errorContent As String = response.Content.ReadAsStringAsync().Result
            '    labTexto.Text = $"Failed to send message: {response.StatusCode.ToString()} - {errorContent}"

            '    ' labTexto.Text = "Failed to send message: " + response.StatusCode.ToString()
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function Autonotify(cliId As Integer) As String
        Try
            If cliId = 0 Then
                Dim notify As String = ""
                notify = banco.consultaScalar("select top 1 chi_autonotify from chip where chi_ativo = 1")
                Return notify
            End If

            Dim dv As DataView = banco.consulta("select * from cliente c inner join chip cc on c.chi_id = cc.chi_id  where chi_ativo = 1 and cli_id = " & cliId.ToString)

            If dv.Count = 0 Then ' Se não tiver chip_id definido para esse cliente

                'Verificar qual é o proximo chip para ser usado
                Dim dvChip As DataView = banco.consulta("select top 1 chi.*, cli_data from chip chi left join (SELECT chi_id, MAX(cli_data) AS cli_data FROM cliente where chi_id is not null GROUP BY chi_id) cli on chi.chi_id = cli.chi_id where chi_ativo = 1 order by cli_data asc")
                If dvChip.Count = 0 Then
                    Return "" 'Não tem chips ativos disponiveis
                Else
                    'Atualiza o chip_id que este cliente estará usando
                    banco.executa("update cliente set chi_id = " & dvChip(0)("chi_id").ToString & " where cli_id = " & cliId.ToString)
                    Return dvChip(0)("chi_autonotify") 'Retorna o Autonotify desse chip
                End If
            Else
                Return dv(0)("chi_autonotify")

            End If

            Return ""

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Function verificaDisponibilidadeWhatsapp(chiId As Integer) As Boolean
        Try
            Dim dv As DataView
            If chiId = 0 Then
                dv = banco.consulta("select top 1 chi.*, acc_date from chip chi left join (select chi_id, max(acc_date) acc_date from access a inner join cliente c on a.cli_id = c.cli_id where acc_whatsapp = 1 and chi_id is not null group by chi_id) acc on chi.chi_id = acc.chi_id where chi.chi_ativo = 1 and (DATEADD(SECOND, chi.chi_delay, acc_date) <= GETDATE() or acc_date is null)")
            Else
                dv = banco.consulta("select top 1 chi.*, acc_date from chip chi left join (select chi_id, max(acc_date) acc_date from access a inner join cliente c on a.cli_id = c.cli_id where acc_whatsapp = 1 and chi_id is not null group by chi_id) acc on chi.chi_id = acc.chi_id where chi.chi_ativo = 1 and chi.chi_id = " & chiId.ToString & " and (DATEADD(SECOND, chi.chi_delay, acc_date) <= GETDATE() or acc_date is null)")
            End If

            If dv.Count = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub mensagemPorUmChipEspecifico(numero As String, mensagem As String, chiId As Integer)
        Try

            Dim notificacao As String = ""
            notificacao = banco.consultaScalar("Select chi_autonotify from chip where chi_id = " & chiId.ToString)

            If notificacao = "" Then Throw New Exception("Erro ao tentar enviar a mensagem por whatsapp")

            Dim url As String = "https://wpp.sourei.com.br/rest/sendMessage/" & notificacao & "/text"

            Dim toAddress As String = "55" & numero
            toAddress += "@s.whatsapp.net"

            Dim messageData As New MessageData With {.To = toAddress, .Text = mensagem}
            Dim payload As New Payload With {.MessageData = messageData}
            Dim jsonPayload As String = JsonConvert.SerializeObject(payload)

            Dim content As New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Dim client As New HttpClient()

            ' Adicionando os headers
            'client.DefaultRequestHeaders.Add("Content-Type", "application/json")
            'client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiUnViZSJ9.PfhDZ2MpY0flKGLSxdTwOL-XIDog0222uw2J_FjIFr53N-fuEHG2rzb6-mvsRyr7IHIKclSe-WmLMrdYSCsoCw")
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiV1BQIFNPVVJFSSJ9.ydKDUr3hpLYW_8v6nVQFMnU_oeU0D5P6i_Yc67tFVLQMPksg0IGdn7FsBDWiQDuNIbP_2PkPjfkMrqbIqoR07A")


            Dim response As HttpResponseMessage = client.PostAsync(url, content).Result


            'If response.IsSuccessStatusCode Then
            '    Return "Aparentemente foi com sucessso"
            'Else
            '    Dim errorContent As String = response.Content.ReadAsStringAsync().Result
            '    Return "Failed to send message: " & response.StatusCode.ToString() & " - " & errorContent
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub






End Class


