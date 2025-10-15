Public Class index1
    Inherits System.Web.UI.Page
    Dim labscript As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        labscript = Master.FindControl("labscript")
        labscript.Visible = False
        labscript.Text = ""

        Dim varSessao As String = Session.Item("id_user")
        If varSessao <> "" Then Response.Redirect("home.aspx")

    End Sub


    Protected Sub butProximo_Click(sender As Object, e As EventArgs) Handles butProximo.Click
        Try
            If tbCPF.Text <> "" Then
                If funcoes.VerificaCPF(tbCPF.Text) = False Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Coloque um CPF válido")
                    Exit Sub
                End If

                Dim conexao As New SqlClient.SqlConnection(ado.caminho)
                Dim comando As New SqlClient.SqlCommand("", conexao)
                'Dim dr As SqlClient.SqlDataReader

                Dim txtLogin As String = tbCPF.Text.Replace(".", "").Replace("-", "")
                txtLogin = Server.HtmlEncode(txtLogin)

                Dim dvPrimeiroAcesso As DataView = banco.consulta("Select * from cliente  where cli_cpf = '" + txtLogin + "' ")

                If dvPrimeiroAcesso.Count > 0 Then
                    'Não é primeiro acesso
                    Session.Add("CPF", txtLogin)
                    Response.Redirect("accessCode.aspx")
                End If

                Dim dv As DataView = banco.consulta("Select * from cupom  where cup_cpf = '" + txtLogin + "' ")

                If dv.Count > 0 Then
                    Session.Add("CPF", txtLogin)
                    Response.Redirect("questions.aspx")
                Else
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Não encontramos compras com este CPF. Entre em contato com o SAC com seu Cupom Fiscal em mãos")
                    Exit Sub
                End If

            Else
                labscript.Visible = True
                labscript.Text = ado.erroGeral("Digite seu CPF")
            End If

        Catch Ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(Ex.Message)

        End Try
    End Sub










End Class