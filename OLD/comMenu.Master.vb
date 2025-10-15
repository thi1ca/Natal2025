Public Class comMenu
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labScript.Visible = False
            labScript.Text = ""

            Dim varSessao As String = Session.Item("id_user")
            If varSessao = "" Then Response.Redirect("accessCode.aspx")

            If Not IsPostBack Then
                labNome.Text = Session.Item("nome")
            End If



        Catch ex As Exception
            labScript.Visible = True
        labScript.Text = ado.erroGeral(ex.Message)
        End Try

    End Sub

End Class