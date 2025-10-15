Public Class winners
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim es As container.estrutura
    Dim varsessao, CPF As String
    Dim contador As Integer = 0
    Public qtdVencedores As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            varsessao = Session.Item("id_user")
            CPF = Session.Item("CPF")

            'varsessao = 6
            'CPF = "30953173879"

            'varsessao = 1
            'CPF = "21695923855"

            If Not IsPostBack Then
                carregaQtdVencedores()
                CarregaGrid()
            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try


    End Sub

    Private Sub carregaQtdVencedores()
        Try
            qtdVencedores = banco.consultaScalar("select count(*) from raspados where ras_premiado = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaGrid()
        Try
            Dim IntCont As Integer = 0
            Dim sql, sqlCount As String

            'Trás todos os itens do período sem ser cartão (só débito, transf, entradas)
            sql = "select top 8 ras_id, LEFT(cli_nome, CHARINDEX(' ', cli_nome + ' ') - 1) AS cli_nome, loj_nome, cup_cupom_data "
            sql += "from raspados r "
            sql += "inner join cliente c on r.cli_id = c.cli_id "
            sql += "inner join cupom cu on r.cup_id = cu.cup_id "
            sql += "Inner join loja l on cu.loj_id = l.loj_id "
            sql += "where ras_premiado = 1 "

            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            sql += " order by ras_id desc"

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 8


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql

            'comentário:executando
            es = container.gerar(Repeater1, es)

            'Dim dv As New DataView
            'dv = (datagrid1.table
            'dv.Sort = "Sobrenome Desc";


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class