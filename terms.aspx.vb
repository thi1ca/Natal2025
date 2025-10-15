Public Class terms
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

            'If varSessao IsNot Nothing Then Response.Redirect("termsandprivacy.aspx")

            If Not IsPostBack Then
                'verificaSeJaAceitou()
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try



    End Sub


    'Private Sub verificaSeJaAceitou()
    '    Try
    '        Dim dv As DataView = banco.consulta("select top 1 * from cliente where cli_cpf = '" & CPF & "' order by 1 desc ")

    '        If dv.Count = 0 Then Response.Redirect("register.aspx")
    '        If dv(0)("cli_termos") = True Then
    '            If varSessao <> "" Then
    '                Response.Redirect("home.aspx")
    '            Else
    '                Response.Redirect("accessCode.aspx")
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class