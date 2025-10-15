Public Class top
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'labscript.Visible = False
        'labscript.Text = ""
        If Not IsPostBack Then
            carregaNome()
            checaSessao()
            GravaPagina()
            'MontaModulo()
        End If
        'Response.Flush()
    End Sub

    Private Sub checaSessao()
        If Session.Item("xmlModulo") = Nothing Then
            Dim ds As New DataSet
            ds.ReadXml(ado.xml)
            Dim caminho As String = ds.Tables("caminho").Select("id='diretorio'")(0).Item("url")
            Dim url As String = ds.Tables("sistema").Select("id='1'")(0).Item("url")
            Dim dir As String = ds.Tables("caminho").Select("id='diretorio'")(0).Item("dir")
            Session.Add("caminho", caminho)
            Session.Add("url", url)
            Session.Add("dir", dir)
            'Session.Add("moduloDefault", moduloDefault)
            Session.Add("xmlModulo", True)

            If Not Request.Cookies("detranEAD") Is Nothing Then
                Dim meuModulo As String = Request.Cookies("retry")("modulo")
                Session.Item("modulo") = meuModulo
            End If

        End If
    End Sub

    Private Sub GravaPagina()
        'Application.Lock()
        'Dim x As New ArrayList
        'Dim z As New ArrayList
        'Dim posicao As Integer

        'x = Application.Item("onLine")
        'z = Application.Item("pagina")
        'posicao = x.IndexOf(Session.Item("logado"))
        'If Not Session.Item("logado") Is Nothing And posicao > -1 Then
        '    z(posicao) = Request.ServerVariables("PATH_INFO")
        'End If
        'Application.Item("pagina") = z
        'Application.UnLock()
    End Sub

    Private Sub carregaNome()
        Try
            Dim varNome As String = Session.Item("nome")
            labNome.Text = varNome
        Catch ex As Exception

        End Try
    End Sub

End Class