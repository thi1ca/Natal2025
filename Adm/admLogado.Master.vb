Public Class admLogado
    Inherits System.Web.UI.MasterPage

    Public varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            varSessao = ""
            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

End Class