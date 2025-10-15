Public Class home
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim es As container.estrutura
    Dim es2 As container.estrutura
    Dim varsessao, CPF As String
    Dim contador As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            varsessao = Session.Item("id_user")
            CPF = Session.Item("CPF")

            If varsessao = "" Then Response.Redirect("index.aspx")

            'varsessao = 6
            'CPF = "30953173879"

            'varsessao = 1
            'CPF = "21695923855"

            If Not IsPostBack Then

                carregaNumerosDaSorte()
            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try


    End Sub

    Private Sub carregaNumerosDaSorte()
        Try
            Dim sql, sqlCount As String

            'sql = "select sor_numero, cup_cupom_data, cup_valor, loj_nome from sorte s inner join cupom c on s.cup_id = c.cup_id inner join loja l on c.loj_id = l.loj_id where c.cli_id = " & varsessao & "  or c.cup_cpf = '" & CPF & "' "

            sql = "select c.*,l.loj_nome from cupom c inner join loja l on c.loj_id = l.loj_id where (cli_id = " & varsessao & "  or cup_cpf = '" & CPF & "') and cup_valor >= " & Natal_regradenegocio.valor().ToString & "  and cup_cupom_data >= '" & Natal_regradenegocio.dataInicio() & "' and cup_cupom_data <= '" & Natal_regradenegocio.dataFim() & "'"
            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            sql += " order by cup_cupom_data desc, cup_cupom_codigo desc"

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 1000


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql



            'comentário:executando
            es = container.gerar(Repeater1, es)


            If es.total = 0 Then
                divVazio.Visible = True
            Else
                divVazio.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        ' Verifica se o item atual é do tipo data item (não header ou footer)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            ' Obtenha a categoria atual
            Dim cupId As Integer = e.Item.DataItem(0)
            Dim sql2, sqlCount As String

            ' Encontre o repeater interno
            Dim repeaterNumeros As Repeater = CType(e.Item.FindControl("Repeater2"), Repeater)


            sql2 = "select sor_numero from sorte where cup_id = " & cupId.ToString


            'Prepara a query para count (sem ordenação)
            sqlCount = sql2

            'Finaliza com ordenação
            sql2 += " order by 1 asc "

            'Configurando
            es2.pagina_atual = 1
            es2.registros_por_pagina = 100


            es2.contador = "Select count (*) from (" & sqlCount & ") aa"

            es2.comando = sql2



            'comentário:executando
            es2 = container.gerar(repeaterNumeros, es2)

            ' Faça o binding dos produtos dessa categoria no repeater interno
            'repeaterProdutos.DataSource = categoria.Produtos
            'repeaterProdutos.DataBind()
        End If
    End Sub


    Public Function FuncFormata(numero As Integer) As String
        Try
            Return numero.ToString().PadLeft(7, "0"c)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class