Public Class scratch
    Inherits System.Web.UI.Page
    Dim cupId As String
    Dim varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labScript.Visible = False
            labScript.Text = ""

            varSessao = Session.Item("id_user")
            cupId = Request.Item("cupId")

            If varSessao = "" Then Response.Redirect("accessCode.aspx")
            If cupId = "" Then Response.Redirect("home.aspx")

            'varSessao = 6
            'cupId = 1

            If IsNumeric(cupId) = False Then Response.Redirect("home.aspx")

            verificaRaspado()


            If Not IsPostBack Then



            End If



        Catch ex As Exception
            labScript.Visible = True
            labScript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub verificaRaspado()

        Dim dv As DataView = banco.consulta("select * from cupom c  left join raspados r on r.cup_id = c.cup_id  where c.cli_id = " & varsessao & " and c.cup_id = " & cupId)

        If dv.Count = 0 Then
            'Esse cliId com esse CupId não foram encontrados na tebala cupom (divergentes). Possível manipulação de parametro na URL
            whatsapp.mensagem("11987040377", "Erro ao tentar raspar cliId=" & varSessao & " e cupId = " & cupId)
            Response.Redirect("home.aspx")
        Else
            If IsDBNull(dv(0)("ras_id")) = True Then
                'Não raspou
                raspar()
            Else
                'Já raspou
                If dv(0)("ras_premiado") = 1 Then
                    'Raspou e Está premiado
                    carregaBilhetePremiado(dv(0)("cal_id").ToString)
                Else
                    'Raspou e não está premiado
                    carregaBilheteRaspado()
                End If
            End If

            If dv.Count > 1 Then
                whatsapp.mensagem("11987040377", "Registro duplicado na tabela Raspados, com cliId=" & varSessao & " e cupId = " & cupId)
            End If
        End If

    End Sub

    Private Sub carregaBilhetePremiado(calId As String)
        Try
            divPremio.Visible = True
            divRaspado.Visible = False
            secretCode.Visible = True
            secretCode.Text = banco.consultaScalar("select cal_voucher from calendario c inner join raspados r on r.cal_id = c.cal_id where r.cal_id = " & calId & " and r.cli_id = " & varSessao & " and ras_premiado = 1")

            'Não dá´pra usar notificação abaixo, pq se não tiver cadastrado o voucher, o código vem vazio
            'If secretCode.Text = "" Then whatsapp.mensagem("11987040377", "Erro ao carregar bilherte premiado, com calID=" & calId & " e cliId=" & varSessao)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub carregaBilheteRaspado()
        Try
            divPremio.Visible = False
            divRaspado.Visible = True
            secretCode.Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub raspar()
        Try
            Dim dv As DataView = banco.consulta("select top 1 * from calendario where cal_data_premio < getdate() and cal_id not in (select cal_id from raspados where ras_premiado = 1) order by cal_data_premio asc")

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            campo.Add("cup_id")
            conteudo.Add(cupId)

            campo.Add("cli_id")
            conteudo.Add(varSessao.ToString)

            If dv.Count = 0 Then
                'Não foi sorteado

                campo.Add("ras_premiado")
                conteudo.Add("0")


                ado.incluir("Raspados", campo, conteudo)

                carregaBilheteRaspado()
            Else
                'Foi sorteado

                campo.Add("ras_premiado")
                conteudo.Add("1")

                campo.Add("cal_id")
                conteudo.Add(dv(0)("cal_id").ToString)


                ado.incluir("Raspados", campo, conteudo)

                carregaBilhetePremiado(dv(0)("cal_id"))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub







End Class