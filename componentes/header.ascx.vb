Public Class header
    Inherits System.Web.UI.UserControl

    Public Titulo As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = RetornaTitulo(Titulo)
        verificaSessao()
    End Sub

    Private Function RetornaTitulo(ByVal StrTitulo As String) As String
        Dim ds As New DataSet()
        ds.ReadXml(ado.xml)
        Return ds.Tables("sistema").Select("id='1'")(0).Item("title")
    End Function

    Private Sub verificaSessao()
        Dim ip As String = Session.Item("ip")
        If ip = "" Then
            Dim ende As String = Request.UserHostAddress
            Session.Add("ip", ende)
        End If
    End Sub

End Class