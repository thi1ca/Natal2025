Public Class logoff
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Application.Lock()
            Dim x As New ArrayList()
            x = Application.Item("onLine")
            'x.Remove(x.Item(x.IndexOf(Session.Item("logado"))))
            If Not Session.Item("logado") Is Nothing Then
                x.RemoveAt(x.IndexOf(Session.Item("logado")))
            End If
            Application.Item("onLine") = x
            Application.UnLock()
            Session.Remove("logado")
            Session.RemoveAll()
            Session.Abandon()
            Response.Redirect("index.aspx")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

End Class