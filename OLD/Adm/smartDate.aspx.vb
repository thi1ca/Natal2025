Public Class smartDate
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Dim es2 As container.estrutura

    Private Const HORA_INICIO As String = "07:00:00"
    Private Const HORA_FIM As String = "23:59:30"
    Private Const DATA_INICIO As Date = #2023-06-01#
    Private Const DATA_FIM As Date = #2023-06-30#

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Smart Dates "


            'Session.Add("id_user", 1)
            'Session.Add("cadId", 1)
            'varSessao = "2"

            varSessao = Session.Item("cadId")

            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaCampanha()
                tbPaginacao.Text = "20"
                'CarregaGrid()
                limpaCampos()
            End If
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

#Region "FORMULARIO"

    Private Sub carregaCampanha()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select cam_id, cam_nome from campanha where cam_ativo = 1 order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            'ddlCampanha.Items.Clear()
            'ddlCampanha.Items.Add("Todas Selecionado")
            'ddlCampanha.Items(0).Value = "0"

            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlCampanha.Items.Add(arr(1).Item(f))
                    ddlCampanha.Items(f).Value = arr(0).Item(f)
                    'ddlCampanha.Items(f + 1).Value = arr(0).Item(f)
                Next
            End If

        Catch ex As Exception
            ddlCampanha.Items.Clear()
            ddlCampanha.Items.Add("---ERROR---")
            ddlCampanha.Items(0).Value = "0"
        End Try
    End Sub

    Private Sub carregaPremio()
        Try
            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList

            Dim sql As String = "Select pre_id, pre_nome from premio where pre_ativo = 1 and cam_id = " & ddlCampanha.SelectedValue.ToString & " order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlPremio.Items.Clear()
            ddlPremio.Items.Add("Todos Selecionados")
            ddlPremio.Items(0).Value = "0"

            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlPremio.Items.Add(arr(1).Item(f))
                    ddlPremio.Items(f + 1).Value = arr(0).Item(f)
                Next
            End If
        Catch ex As Exception
            ddlPremio.Items.Clear()
            ddlPremio.Items.Add("---ERROR---")
            ddlPremio.Items(0).Value = "0"
        End Try
    End Sub



    'Private Sub butCadastrar_Click(sender As Object, e As EventArgs) Handles butCadastrar.Click
    '    Try
    '        If verificaCampos() = False Then
    '            labscript.Visible = True
    '            labscript.Text = ado.erroGeral(labscript.Text)
    '            Exit Sub
    '        End If

    '        Dim conteudo As New ArrayList
    '        Dim campo As New ArrayList


    '        Dim dataTratada As String = funcoes.TransformaDataAnoMesDia(tbDataPremio.Text.Trim) & " " & time.Text.Trim

    '        campo.Add("pre_id")
    '        conteudo.Add(ddlPremio.SelectedValue.ToString)

    '        campo.Add("cal_data_premio")
    '        conteudo.Add(dataTratada)

    '        campo.Add("cal_voucher")
    '        conteudo.Add(tbVoucher.Text)

    '        campo.Add("cad_id")
    '        conteudo.Add(varSessao)

    '        ado.incluir("Calendario", campo, conteudo)

    '        campo.Clear()
    '        conteudo.Clear()

    '        limpaCampos()
    '        CarregaGrid()

    '    Catch ex As Exception
    '        labscript.Visible = True
    '        labscript.Text += ado.erroGeral(ex.Message)
    '    End Try
    'End Sub

    Private Sub butSugerir_Click(sender As Object, e As EventArgs) Handles butSugerir.Click
        Try
            If verificaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Exit Sub
            End If







        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub


    Private Sub limpaCampos()
        Try
            tbDataPremio.Text = ""
            tbQtdVoucher.Text = ""
            ddlCampanha.SelectedIndex = 0
            carregaPremio()
            tbID.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try

            If ddlPremio.SelectedIndex = 0 Then
                labscript.Text = "Selecione um Prêmio"
                Return False
            End If

            If tbDataPremio.Text.Trim = "" Then
                labscript.Text = "Preencha a data de início da campanha"
                Return False
            ElseIf IsDate(tbDataPremio.Text) = False Then
                labscript.Text = "Preencha corretamente a data de início da campanha"
                Return False
                'TODO: Elseif se a data for maior ou igual da data fim da campanha
            End If


            If IsNumeric(tbQtdVoucher.Text) = False Then
                labscript.Text = "Preencha corretamente a qtd de cupons"
                Return False
            ElseIf CInt(tbQtdVoucher.Text.trim) = 0 Then
                labscript.Text = "Qtd de vouchers tem que ser maior que 0"
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Private Sub ddlCampanha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCampanha.SelectedIndexChanged
        Try
            carregaPremio()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub


#End Region

#Region "Funções"

    Public Shared Function funcAtivo(ativo As Boolean, tipo As Integer) As String
        If ativo = True Then
            If tipo = 1 Then Return "Ativo"
            If tipo = 2 Then Return "Sim"
            'Return "Ativo"
        Else
            If tipo = 1 Then Return "Desabilitado"
            If tipo = 2 Then Return "Não"
        End If
    End Function


    Public Shared Function funcAtivar(ativo As Boolean) As String
        If ativo = True Then
            Return "Desativar"
        Else
            Return "Ativar"
        End If
    End Function

    Public Shared Function funcCPF(cpf As String) As String
        Try
            Dim cpfTratado As String = funcoes.MascaraCPF(cpf)
            Return cpfTratado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function funcCelular(celular As String) As String
        Try
            Dim celularTratado As String = funcoes.formataCelular(celular)
            Return celularTratado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function funcEnviado(enviado As Object) As String
        Try
            Dim txtEnviado As String = ""
            If IsDBNull(enviado) = True Then
                txtEnviado = "esperando"
            ElseIf enviado = 0 Then
                txtEnviado = "pendente"
            ElseIf enviado = 1 Then
                txtEnviado = "enviado"
            End If

            Return txtEnviado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FunctionFundo(ativo As Boolean) As String
        If ativo = True Then
            Return ""
        Else
            Return "bg-light"
        End If
    End Function

    Public Shared Function funcdata(data As Date) As String
        Return funcoes.formataData(data)
    End Function



#End Region

End Class