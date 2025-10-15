Public Class terms1
    Inherits System.Web.UI.UserControl

    Dim CPF As String
    Dim varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript.Visible = False
            labscript.Text = ""

            varSessao = Session.Item("id_user")
            CPF = Session.Item("CPF")

            If Not IsPostBack Then
                If funcoes.VerificaCPF(CPF) = True Then
                    verificaCheckbox()
                End If
            End If


        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try



    End Sub


    Private Sub verificaCheckbox()
        Try
            Dim dv As DataView = banco.consulta("select top 1 * from cliente where cli_cpf = '" & CPF & "' order by 1 desc ")

            If dv.Count = 0 Then
                cbAceite.Checked = False
                butVoltar.Visible = False
            ElseIf dv(0)("cli_termos") = True And varSessao <> "" Then
                cbAceite.Checked = True
                cbAceite.Enabled = False
                butProximo.Visible = False
            ElseIf dv(0)("cli_termos") = True And varSessao = "" Then
                Response.Redirect("accessCode.aspx")
            Else
                cbAceite.Checked = False
                butVoltar.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub butProximo_Click(sender As Object, e As EventArgs) Handles butProximo.Click
        Try
            If cbAceite.Checked = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Você precisa aceitar os termos")
                Exit Sub
            End If

            banco.executa("update cliente set cli_termos = 1 where cli_cpf = '" & CPF & "'")

            Session.Add("terms", "1")

            Response.Redirect("oAuth.aspx")
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub butVoltar_Click(sender As Object, e As EventArgs) Handles butVoltar.Click
        Try

            If varSessao = "" Then
                Response.Redirect("confirm-register.aspx")
            Else
                Response.Redirect("home.aspx")
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub
End Class