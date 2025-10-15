Imports System.Threading.Tasks
Imports System.Net.Http.Headers
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class admWhatsapp
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Dim es As container.estrutura
    Public Shared dv As DataView
    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Verificar Chips de Whatsapp"

            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then

                Await carregaStatus()
                dv = Session.Item("dvStatus")
                CarregaGrid()
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Public Sub CarregaGrid()
        Try
            Dim IntCont As Integer = 0
            Dim sql, sqlCount As String

            'Trás todos os clientes
            sql = "select * from chip  "

            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cli_ativo desc, cli_nome asc"


            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 100


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql

            'comentário:executando
            es = container.gerar(Repeater1, es)


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Function funcCelular(celular As String) As String

        Return funcoes.formataCelular(celular)

    End Function

    Public Shared Function funcAtivo(ativo As Boolean) As String
        If ativo = True Then
            Return "Sim"
        Else
            Return "Desativado"
        End If
    End Function

    Public Shared Function funcCor(ativo As Boolean) As String
        If ativo = True Then
            Return ""
        Else
            Return "text-danger"
        End If
    End Function

    Public Shared Function funcStatus(autonotify As Object) As String
        Try
            If IsDBNull(autonotify) = True Then
                Return "Sem autonotify cadastrado"
            Else
                Return verificaTesteDV(autonotify)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function verificaTesteDV(autonotify As String) As String
        Try
            Dim f As Integer
            For f = 0 To dv.Count - 1
                If autonotify = dv(f)("key") Then
                    Return dv(f)("status")
                End If
            Next
            Return "Não encontrado"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Status do Whatsapp"

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


    Public Async Function carregaStatus() As Task
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
                apiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(responseBody)

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

                        'Adiciona Dataview na sessao
                        Session.Add("dvStatus", dataView)

                        ' Exibir os dados do DataView
                        'DisplayDataView(dataView)
                        'GridView1.DataSource = apiResponse.instances
                        'GridView1.DataBind()
                    End If
                Else
                    ' Exibe a mensagem de erro
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Erro na API: " & apiResponse.message)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Using
    End Function

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



#End Region

End Class