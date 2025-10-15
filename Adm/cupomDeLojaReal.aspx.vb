Public Class cupomDeLojaReal
    Inherits System.Web.UI.Page
    Public varCPF As String
    Public varLoja As String
    Public varData As String
    Public varPreco As String
    Public varSessao As String
    Public varformaPG As String
    Public varQtdNumeros As String
    Dim labscript As Label
    Public varNivel As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labscript.Visible = False
            labscript.Text = ""


            varSessao = Session.Item("cadId")
            If varSessao = "" Then Response.Redirect("index.aspx")

            varNivel = Session.Item("Nivel")


            If Not IsPostBack Then
                divQRCode.Visible = False
                carregaLojas()
            End If

            'Dim txtLogin As String = tbCPF.Text.Replace(".", "").Replace("-", "")

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

            If IsDate(tbData.Text.Trim) = False Then
                labscript.Text = "Preencha uma Data e Hora válida"
                tbFicha.Text = 0
            End If

            If IsNumeric(tbValor.Text.Trim) = False Then
                labscript.Text = "Preencha uma Data e Hora válida"
                tbFicha.Text = 0
            End If

            If IsNumeric(tbCupom.Text.Trim) = False Then
                labscript.Text = "Preencha um Cupom só com números"
                tbFicha.Text = 0
            End If

            If IsNumeric(tbPDV.Text.Trim) = False Then
                labscript.Text = "Preencha um PDV só com números"
                tbFicha.Text = 0
            End If

            'If IsNumeric(tbOperador.Text.Trim) = False Then
            '    labscript.Text = "Preencha um Operador só com números"
            '    tbFicha.Text = 0
            'End If

            Dim dv As DataView = banco.consultaTorra("select top 1 * from ttv_dados_venda_CPF where pdv = " & tbPDV.Text.Trim & " and codLoja = " & ddlLoja.SelectedValue.ToString & " order by 1 desc")

            If dv.Count = 0 Then
                labscript.Text = "Não foi encontrado PDV informado nessa Loja"
                tbFicha.Text = 0
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
            tbCupom.Text = ""
            tbData.Text = ""
            tbFicha.Text = ""
            'tbOperador.Text = ""
            tbPDV.Text = ""
            tbValor.Text = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    'Private Function verificaSePodeCadastrarMais(cpf As String)
    '    Try
    '        Dim dv As DataView = banco.consulta("select * from cupom where cup_cpf = '" & cpf & "'")
    '        Return dv.Count
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function









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
            If varNivel < 10 Then Response.Redirect("dashboard.aspx")

            If Verificacampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                'ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                'ScriptManager.RegisterStartupScript(Page, GetType(UpdatePanel), "MyScript", "alert('" & labscript.Text & "');", True)
                Exit Sub
            End If



            Dim conteudo As New ArrayList
            Dim campo As New ArrayList

            Dim data As DateTime = tbData.Text.Trim
            Dim valor As Double = tbValor.Text
            'Dim valor As Double = tbValor.Text.ToString.Replace(",", ".")
            Dim Cupom_codigo As Integer = tbCupom.Text.Trim
            Dim TACC As Double = 0
            If cbTACC.Checked = True Then TACC = tbValor.Text.ToString.Replace(",", ".")

            Dim dataTratada As String = funcoes.TransformaDataAnoMesDia(data) & " " & data.ToString("HH:mm:ss") 'data.ToString


            campo.Add("cup_cpf")
            conteudo.Add(tbCPF.Text.Replace(".", "").Replace("-", ""))

            campo.Add("cup_cupom_data")
            conteudo.Add(dataTratada)

            campo.Add("cup_valor")
            conteudo.Add(Replace(valor.ToString, ",", "."))

            campo.Add("cup_cupom_codigo")
            conteudo.Add(Cupom_codigo.ToString & tbPDV.Text.Trim & ddlLoja.SelectedValue.ToString & Year(data) & Month(data) & Day(data))

            campo.Add("loj_id")
            conteudo.Add(ddlLoja.SelectedValue.ToString)

            campo.Add("cam_id")
            conteudo.Add("2")

            campo.Add("Cupom")
            conteudo.Add(Cupom_codigo.ToString)

            campo.Add("PDV")
            conteudo.Add(tbPDV.Text.Trim)

            campo.Add("Operador")
            conteudo.Add("0")

            campo.Add("NomeOperador")
            conteudo.Add("Inserido Manualmente")

            If cbTACC.Checked = True Then
                campo.Add("TACC")
                conteudo.Add(Replace(valor.ToString, ",", "."))
            End If

            ado.incluir("Cupom", campo, conteudo)

            varCPF = tbCPF.Text.Trim
            varData = funcoes.TransformaDataDiaMes(dataTratada) & "/" & Year(dataTratada).ToString
            varLoja = ddlLoja.SelectedItem.ToString
            varPreco = valor
            varformaPG = "Cartão Torra = " & cbTACC.Checked.ToString
            tbFicha.Text = 1
            'varQtdNumeros = VerificaQtdNumeroSorte(valor, strformaPG)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()

            'labscript.Visible = True
            'labscript.Text += ado.erroGeral("Cupom cadastrado com sucesso!!!", True)

            divQRCode.Visible = True

            labscript.Visible = True
            labscript.Text = ado.erroGeral("Cupom inserido com sucesso", False, True)
            'Response.Redirect("admUsers.aspx")

        Catch ex As Exception

            varCPF = ""
            varData = ""
            varLoja = ""
            varPreco = ""
            varformaPG = ""
            tbFicha.Text = 0
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub



End Class