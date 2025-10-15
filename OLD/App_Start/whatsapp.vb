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

        Public Shared Sub mensagem(numero As String, mensagem As String)
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
            Dim url As String = "https://wpp.sourei.com.br/rest/sendMessage/autonotify-58f432a45c/text"

            Dim toAddress As String = numero
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

    End Class


