Public Class cupomDeLoja
    Inherits System.Web.UI.Page
    Public varCPF As String
    Public varLoja As String
    Public varData As String
    Public varPreco As String
    Public varSessao As String
    Public varformaPG As String
    Public varQtdNumeros As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript.Visible = False
            labscript.Text = ""


            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            Dim varNivel As Integer = Session.Item("Nivel")
            If varNivel < 10 Then Response.Redirect("dashboard.aspx")

            If Not IsPostBack Then
                divQRCode.Visible = False
                carregaLojas()
            End If

            Dim txtLogin As String = tbCPF.Text.Replace(".", "").Replace("-", "")

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Sub carregaLojas()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select loj_id, loj_nome from Loja order by 2 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlLoja.Items.Clear()
            ddlLoja.Items.Add("--- Selecione uma loja ---")
            ddlLoja.Items(0).Value = ""


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlLoja.Items.Add(arr(1).Item(f))
                    ddlLoja.Items(f + 1).Value = arr(0).Item(f)


                Next
            End If
        Catch ex As Exception
            ddlLoja.Items.Clear()
            ddlLoja.Items.Add("---ERROR---")
            ddlLoja.Items(0).Value = "0"
        End Try
    End Sub

    Private Function Verificacampos() As Boolean
        Try
            If tbCPF.Text.Trim = "" Then
                labscript.Text = "Preencha o campo CPF"
                tbFicha.Text = 0
                Return False
            ElseIf IsNumeric(tbCPF.Text.Replace(".", "").Replace("-", "")) = False Then
                labscript.Text = "Esse não parece ser um CPF!"
                tbFicha.Text = 0
                Return False
            ElseIf funcoes.VerificaCPF(tbCPF.Text) = False Then
                labscript.Text = "Esse não parece ser um CPF válido"
                tbFicha.Text = 0
                Return False
            End If

            If ddlLoja.SelectedIndex = 0 Then
                labscript.Text = "Você precisa selecionar uma loja"
                tbFicha.Text = 0
                Return False
            End If

            'Ativar trava quando for teste para empresa toda.
            If verificaSePodeCadastrarMais(tbCPF.Text.Replace(".", "").Replace("-", "")) > 2 Then
                labscript.Text = "Você já cadastrou 3 cupons. Esse é o limite"
                tbFicha.Text = 0
                Return False
            End If

            If labscript.Text.Trim <> "" Then
                labscript.Visible = True
                tbFicha.Text = 0
                Return False
            Else
                labscript.Text = ""
                Return True
            End If



        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub limpaCampos()
        Try
            tbCPF.Text = ""
            ddlLoja.SelectedIndex = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Private Function verificaSePodeCadastrarMais(cpf As String)
        Try
            Dim dv As DataView = banco.consulta("select * from cupom where cup_cpf = '" & cpf & "'")
            Return dv.Count
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SorteiaData() As DateTime
        Dim hoje As Date = Date.Today
        Dim startDate As New DateTime(2024, 11, 20) ' Start date
        Dim endDate As New DateTime(hoje.Year, hoje.Month, hoje.Day) ' End date

        Dim random As New Random()
        Dim range As TimeSpan = endDate - startDate ' Calculate the total time span between the two dates

        ' Generate a random number of seconds within the total time span
        Dim randomTotalSeconds As Long = CLng(range.TotalSeconds)
        Dim randomSeconds As Long = random.Next(0, randomTotalSeconds)

        ' Add the random number of seconds to the start date to get the random date and time
        Dim randomDate As DateTime = startDate.AddSeconds(randomSeconds)

        Return randomDate
    End Function

    Private Function Preco() As Double
        Try
            Dim rnd As New Random()
            Dim randomPrice As Integer = rnd.Next(50, 260) ' The upper bound is exclusive, so use 8 instead of 7

            Dim cupomValor As Double = randomPrice + 0.99

            Return cupomValor

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function formaPG() As String
        Try
            ' Define as 5 strings
            Dim opcoes As String() = {"Cartão Torra", "PIX", "Cartão de Crédito VISA"}

            ' Inicializa o gerador de números aleatórios
            Dim rnd As New Random()

            ' Sorteia um índice entre 0 e 4
            Dim indice As Integer = rnd.Next(0, opcoes.Length)

            ' Retorna a string correspondente ao índice sorteado
            Return opcoes(indice)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CodigoCupom() As Double
        Try
            Dim rnd As New Random()
            Dim codigo As Integer = rnd.Next(123123, 9898789) ' The upper bound is exclusive, so use 8 instead of 7

            Return codigo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Private Function TACC(formaPG As String) As Double
    '    Try
    '        If formaPG = "Cartão Torra" Then
    '            Dim rnd As New Random()
    '            Dim randomPrice As Integer = rnd.Next(50, 260) ' The upper bound is exclusive, so use 8 instead of 7

    '            Dim cupomValor As Double = randomPrice + 0.99

    '            Return cupomValor
    '        Else
    '            Return 0
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Sub butCadastrar_Click(sender As Object, e As EventArgs) Handles butCadastrar.Click
        Try
            If Verificacampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                'ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                'ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                Exit Sub
            End If



            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            Dim data As DateTime = SorteiaData()
            Dim valor As Double = Preco()
            Dim Cupom_codigo As Integer = CodigoCupom()
            Dim strformaPG As String = formaPG()
            'Dim strTACC As Double = TACC(strformaPG)

            Dim dataTratada As String = funcoes.TransformaDataAnoMesDia(data) & " " & data.ToString("hh:mm:ss") 'data.ToString


            campo.Add("cup_cpf")
            conteudo.Add(tbCPF.Text.Replace(".", "").Replace("-", ""))

            campo.Add("cup_cupom_data")
            conteudo.Add(dataTratada)

            campo.Add("cup_valor")
            conteudo.Add(Replace(valor.ToString, ",", "."))

            campo.Add("cup_cupom_codigo")
            conteudo.Add(Cupom_codigo.ToString)

            campo.Add("loj_id")
            conteudo.Add(ddlLoja.SelectedValue.ToString)

            campo.Add("cam_id")
            conteudo.Add("2")

            If strformaPG = "Cartão Torra" Then
                campo.Add("TACC")
                conteudo.Add(Replace(valor.ToString, ",", "."))
            End If

            ado.incluir("Cupom", campo, conteudo)

            varCPF = tbCPF.Text.Trim
            varData = funcoes.TransformaDataDiaMes(dataTratada) & "/" & Year(dataTratada).ToString
            varLoja = ddlLoja.SelectedItem.ToString
            varPreco = valor
            varformaPG = strformaPG
            tbFicha.Text = 1
            varQtdNumeros = VerificaQtdNumeroSorte(valor, strformaPG)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()

            'labscript.Visible = True
            'labscript.Text += ado.erroGeral("Cupom cadastrado com sucesso!!!", True)

            divQRCode.Visible = True

            'Response.Redirect("admUsers.aspx")

        Catch ex As Exception

            varCPF = ""
            varData = ""
            varLoja = ""
            varPreco = ""
            tbFicha.Text = 0
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub

    Private Function VerificaQtdNumeroSorte(valor As Double, formaPG As String) As Integer
        Try
            Dim qtd As Integer
            qtd = Math.Floor(valor / 50)

            If formaPG = "Cartão Torra" Then qtd = qtd * 3

            Return qtd

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class