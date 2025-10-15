Public Class menu
    Inherits System.Web.UI.UserControl

    Public varSessao As String
    Dim NivelPermitido As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        varSessao = Session.Item("id_user")
        labScript.Visible = False
        labScript.Text = ""
        'labMsgLogin.Text = ""
        If Not IsPostBack Then
            checkSession()
        End If
        'Response.Flush()
    End Sub

    Private Sub checkSession()

        labNome.Visible = True
        labNome.Text = Session.Item("Nome")

        Dim varnivel As String = Session.Item("nivel")
        If varnivel = "1" Then
            varnivel = "Usuário"
            menuAdm.Visible = False
        ElseIf varnivel = "2" Then
            varnivel = "Algum outro nivel"
        Else
            varnivel = "Administrador"
            menuAdm.Visible = True
        End If

    End Sub

End Class