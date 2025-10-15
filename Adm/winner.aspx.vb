Public Class winner
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Procurar Vencedor"

            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                'Dim form1 As HtmlForm = Master.FindControl("form1")
                'If form1 IsNot Nothing Then
                '    form1.Attributes.Add("enctype", "multipart/form-data")
                'End If
                'carregaPerfil()
                ' HabilitarInsercao(True)


            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Protected Sub butBuscar_Click(sender As Object, e As EventArgs) Handles butBuscar.Click
        Try
            'Verificar se campos estão preenchidos
            If verificaCampos() = False Then
                labscript.Visible = True
                Exit Sub
            End If

            Dim numeroPremiado As String
            numeroPremiado = tbPremio1.Text.Substring(4, 1)
            numeroPremiado += tbPremio2.Text.Substring(4, 1)
            numeroPremiado += tbPremio1.Text.Substring(5, 1)
            numeroPremiado += tbPremio2.Text.Substring(5, 1)
            numeroPremiado += tbPremio3.Text.Substring(5, 1)
            numeroPremiado += tbPremio4.Text.Substring(5, 1)
            numeroPremiado += tbPremio5.Text.Substring(5, 1)

            labResultado.Text = "<h5>O número premiado é <b>" & numeroPremiado & "</b></h5>"

            Dim sql As String = "select * from sorte s inner join cupom c on s.cup_id = c.cup_id inner join cliente cl on c.cli_id = cl.cli_id inner join loja l on c.loj_id = l.loj_id inner join genero g on cl.gen_id = g.gen_id where sor_numero = " & CInt(numeroPremiado).ToString

            ''Excluir depois do sorteio na empresa
            'sql += " and cli_funcionario = 1 and  cup_data >= '2024-11-01' and cup_data < '2024-11-20'"

            Dim dv As DataView = banco.consulta(sql)




            If dv.Count = 0 Then
                'Não tem ninguem com esse numero
                'Vamos procurar um novo
                Dim sqlMaior As String = "select min(sor_numero) from sorte where sor_numero > " & CInt(numeroPremiado).ToString
                ''Excluir após teste na empresa
                'sqlMaior += "  and cup_id in (select cup_id from cupom where cli_id in (select cli_id from cliente where cli_funcionario = 1 and  cup_data >= '2024-11-01' and cup_data < '2024-11-20'))"


                Dim sqlMenor As String = "select max(sor_numero) from sorte where sor_numero < " & CInt(numeroPremiado).ToString
                ''Excluir após teste na empresa
                'sqlMenor += "  and cup_id in (select cup_id from cupom where cli_id in (select cli_id from cliente where cli_funcionario = 1 and  cup_data >= '2024-11-01' and cup_data < '2024-11-20'))"

                Dim numeroMaior As Integer = banco.consultaScalar(sqlMaior)
                Dim numeroMenor As Integer = banco.consultaScalar(sqlMenor)
                Dim intNumeroPremiado As Integer = CInt(numeroPremiado)

                labResultado.Text += "</br>"
                labResultado.Text += "</br>"
                labResultado.Text += "O menor número da sorte depois do número sorteado é " & numeroMaior.ToString
                labResultado.Text += "</br>"
                labResultado.Text += "O maior número da sorte antes do número sorteado é " & numeroMenor.ToString
                labResultado.Text += "</br>"

                Dim resultadoMaior As Integer = numeroMaior - intNumeroPremiado
                Dim resultadomenor As Integer = intNumeroPremiado - numeroMenor
                Dim novoNumeroPremiado As Integer

                labResultado.Text += numeroMaior.ToString & " - " & numeroPremiado & " = " & resultadoMaior.ToString("N0")
                labResultado.Text += "</br>"
                labResultado.Text += numeroPremiado.ToString & " - " & numeroMenor & " = " & resultadomenor.ToString("N0")
                labResultado.Text += "</br>"

                If resultadoMaior <= resultadomenor Then
                    novoNumeroPremiado = numeroMaior
                Else
                    novoNumeroPremiado = numeroMenor
                End If

                labResultado.Text += "O número mais próximo é: " & novoNumeroPremiado.ToString

                Dim dvNovo As DataView = banco.consulta("select * from sorte s inner join cupom c on s.cup_id = c.cup_id inner join cliente cl on c.cli_id = cl.cli_id inner join loja l on c.loj_id = l.loj_id inner join genero g on cl.gen_id = g.gen_id where sor_numero = " & novoNumeroPremiado.ToString)

                preencheDadosVencedor(dvNovo)
            Else
                'ENcontrou um um vencedor
                preencheDadosVencedor(dv)
            End If


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub preencheDadosVencedor(dv As DataView)
        Try
            'ENcontrou um um vencedor
            labResultado.Text += "</br>"
            labResultado.Text += "</br>"
            labResultado.Text += "<b>TEMOS UM VENCEDOR!!!!</b>"
            labResultado.Text += "</br>"
            labResultado.Text += "</br>"
            labResultado.Text += "</br>"
            labResultado.Text += UCase(dv(0)("cli_nome"))
            labResultado.Text += "</br>"
            labResultado.Text += funcoes.MascaraCPF(dv(0)("cli_cpf"))
            labResultado.Text += "</br>"
            labResultado.Text += dv(0)("cli_email")
            labResultado.Text += "</br>"
            labResultado.Text += funcoes.formataCelular(dv(0)("cli_celular"))
            labResultado.Text += "</br>Nascimento: "
            labResultado.Text += funcoes.formataNascimento(dv(0)("cli_nascimento"))
            labResultado.Text += "</br> É funcionário? "
            labResultado.Text += IIf(dv(0)("cli_funcionario"), "Sim", "Não")
            labResultado.Text += "</br>"
            labResultado.Text += dv(0)("gen_nome")
            labResultado.Text += "</br>Comprou na loja "
            labResultado.Text += dv(0)("loj_nome")
            labResultado.Text += "</br>"
            labResultado.Text += funcoes.formataData(dv(0)("cup_cupom_data")) & " " & Hour(dv(0)("cup_cupom_data")).ToString("00") & ":" & Minute(dv(0)("cup_cupom_data")).ToString("00")
            labResultado.Text += "</br>"
            labResultado.Text += "R$" & dv(0)("cup_valor")
            labResultado.Text += "</br>Cupom: "
            labResultado.Text += dv(0)("cupom").ToString
            labResultado.Text += "</br>PDV: "
            labResultado.Text += dv(0)("PDV").ToString
            labResultado.Text += "</br> Operador: "
            labResultado.Text += dv(0)("Operador").ToString & " - " & dv(0)("NomeOperador")
            labResultado.Text += "</br>"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try
            If tbPremio1.Text.Trim = "" Or tbPremio2.Text.Trim = "" Or tbPremio3.Text.Trim = "" Or tbPremio4.Text.Trim = "" Or tbPremio5.Text.Trim = "" Then
                labscript.Text = "Você precisa preencher todos os 5 prêmios"
                Return False
            ElseIf IsNumeric(tbPremio1.Text.trim) = False Or IsNumeric(tbPremio2.Text.trim) = False Or IsNumeric(tbPremio3.Text.trim) = False Or IsNumeric(tbPremio4.Text.trim) = False Or IsNumeric(tbPremio5.Text.trim) = False Then
                labscript.Text = "Os campos precisam ser somente numéricos"
                Return False
            ElseIf tbPremio1.Text.Trim.Length <> 6 Or tbPremio2.Text.Trim.Length <> 6 Or tbPremio3.Text.Trim.Length <> 6 Or tbPremio4.Text.Trim.Length <> 6 Or tbPremio5.Text.Trim.Length <> 6 Then
                labscript.Text = "Os prêmios precisam possuir 6 números cada um"
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class