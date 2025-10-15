Public Class dashboard
    Inherits System.Web.UI.Page

    'Dim labscript As Label = Master.FindControl("labMin")
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Dashboard"
            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")
            labNome.Text = Session.Item("Nome")



        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

End Class