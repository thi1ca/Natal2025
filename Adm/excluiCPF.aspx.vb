Public Class excluiCPF
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
            labTitulo.Text = "EXCLUI HISTÓRICO DE CPF"

            varSessao = Session.Item("cadId")
            'varSessao = "2"
            If varSessao = "" Then Response.Redirect("index.aspx")

            Dim varNivel As Integer = Session.Item("Nivel")
            If varNivel < 10 Then Response.Redirect("dashboard.aspx")



            If Not IsPostBack Then

            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butExcluir_Click(sender As Object, e As EventArgs) Handles butExcluir.Click
        Try
            If funcoes.VerificaCPF(tbCPF.Text) = True Then
                Dim cpf As String = Replace(tbCPF.Text, ".", "")
                cpf = Replace(cpf, "-", "")

                Dim sql As String

                'Apaga Access Code do Cliente
                banco.executa("Delete From access Where cli_id = (Select cli_id From cliente Where cli_cpf = '" & cpf & "')")

                'Apaga Log
                banco.executa("Delete From log Where cli_id = (Select cli_id From cliente Where cli_cpf = '" & cpf & "')")

                ''Guarda possíveis Cal_id na tabela raspados caso tenha sido sorteado, para apagar o premio junto, senão ficará disponível para outro raspar e ganhar
                'Dim calIds As String = ""
                'Dim dv As DataView = banco.consulta("select cal_id from raspados where cli_id = (select cli_id from cliente where cli_cpf = '" & cpf & "')  and cal_id is not null")
                'If dv.Count > 0 Then
                '    For f = 0 To dv.Count - 1
                '        If calIds <> "" Then calIds += ", "
                '        calIds += dv(f)("cal_id").ToString
                '    Next
                'End If

                'Apaga Sorte
                banco.executa("Delete From sorte Where cli_id = (Select cli_id From cliente Where cli_cpf = '" & cpf & "') or cup_id in (select distinct cup_id from cupom where cli_id = (Select cli_id From cliente Where cli_cpf = '" & cpf & "'))")

                ''Apaga Premio sorteado para esse cliente, se tiver CalId sorteado
                'If calIds <> "" Then
                '    sql = "delete from calendario where cal_id in (" & calIds & ")"
                '    banco.executa(sql)
                'End If

                'Apaga Cupom
                banco.executa("Delete From cupom Where cup_cpf = '" & cpf & "'")

                'Apaga Cupom_Torra
                banco.executa("Delete From Torra_Cupons Where cpf = '" & cpf & "'")

                If cbCliente.Checked = True Then
                    'Apaga Resposta
                    banco.executa("Delete From resposta Where res_CPF = '" & cpf & "'")

                    'Apaga Cliente
                    banco.executa("Delete From cliente Where cli_cpf = '" & cpf & "'")
                Else


                End If


                labscript.Visible = True
                labscript.Text += ado.erroGeral("Histórico apagado do CPF " & tbCPF.Text, True)

                tbCPF.Text = ""

            Else
                labscript.Visible = True
                labscript.Text += ado.erroGeral("Coloque um CPF válido")
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub
End Class