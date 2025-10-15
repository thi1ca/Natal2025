Public Class termsandprivacy
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim CPF As String
    Dim varSessao As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Cliente pode visualizar a tela após aceite, mas não pode deschecar. Essa pg pode ser acessada by menu

            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""

            varSessao = Session.Item("id_user")

            CPF = Session.Item("CPF")
            If CPF = "" Then Response.Redirect("index.aspx")

            If varSessao = "" Then Response.Redirect("terms.aspx")

            If Not IsPostBack Then
                'verificaSeJaAceitou()
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try



    End Sub

End Class