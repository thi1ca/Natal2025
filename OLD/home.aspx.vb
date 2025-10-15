Public Class home
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim es As container.estrutura
    Dim varsessao, CPF As String
    Dim contador As Integer = 0
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
                banco.executaProcedureCliIdNoCupom(varsessao, cpf)
                carregaCuponsAtivos()
                carregaCuponsRaspados()
                carregaCuponsPremiados()
            End If



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try


    End Sub

    Private Sub carregaCuponsAtivos()
        Try
            Dim sql, sqlCount As String

            'Trás todos os clientes
            sql = "select c.*, loj_nome, cam_nome, cam_prazo from cupom c inner join loja l on c.loj_id = l.loj_id inner join campanha ca on c.cam_id = ca.cam_id  where (cli_id = " & varsessao & " or cup_cpf = '" & CPF & "' ) and cup_id not in (select cup_id from Raspados where cli_id = " & varsessao & ") and cam_inicio <= GETDATE()-1 AND cam_fim >= GETDATE()-1 and cam_ativo = 1"



            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            sql += " order by cup_cupom_data desc "

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 10


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql



            'comentário:executando
            es = container.gerar(Repeater1, es)

            If es.total = 0 Then
                divVazio1.Visible = True
            Else
                divVazio1.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub carregaCuponsRaspados()
        Try
            Dim sql, sqlCount As String

            'Trás todos os clientes
            sql = "select * from raspados where cli_id = " & varsessao



            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            sql += " order by 1 desc"

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 10


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql



            'comentário:executando
            es = container.gerar(Repeater2, es)

            If es.total = 0 Then
                divVazio2.Visible = True
            Else
                divVazio2.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub carregaCuponsPremiados()
        Try
            Dim sql, sqlCount As String

            'Trás todos os clientes
            sql = "select pre_voucher_codigo, ras_data from raspados r inner join calendario c on r.cal_id = c.cal_id inner join premio p on c.pre_id = p.pre_id where cli_id = " & varsessao & " and ras_premiado = 1"



            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            sql += "  order by ras_id desc "

            'Configurando
            es.pagina_atual = 1
            es.registros_por_pagina = 10


            es.contador = "Select count (*) from (" & sqlCount & ") aa"

            es.comando = sql



            'comentário:executando
            es = container.gerar(Repeater3, es)

            If es.total = 0 Then
                divVazio3.Visible = True
            Else
                divVazio3.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function funcFundo(txtcelular As String) As String
        contador += 1

        If contador = 1 Then
            Return "background-raspadinha.png"


        ElseIf contador = 2 Then
            Return "background-raspadinha-azul.png"

        Else
            contador = 0
            Return "background-raspadinha-amarelo.png"
        End If
        Return funcoes.formataCelular(txtcelular)
    End Function

End Class