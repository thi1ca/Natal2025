Public Class admGraphs
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Text = ""
            labscript.Visible = False
            labTitulo.Text = "Info & Estatísticas"

            If Not IsPostBack Then
                carregaCampanha()
                carregaDados()
                BindChartData()
            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Private Sub carregaCampanha()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select cam_id, cam_nome from campanha where cam_ativo = 1 order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            'ddlCampanha.Items.Clear()
            'ddlCampanha.Items.Add("--- Selecione uma campanha ---")
            'ddlCampanha.Items(0).Value = "0"


            If arr(0).Count > 0 Then
                For f = 0 To arr(0).Count - 1
                    ddlCampanha.Items.Add(arr(1).Item(f))
                    ddlCampanha.Items(f).Value = arr(0).Item(f)


                Next
            End If
        Catch ex As Exception
            ddlCampanha.Items.Clear()
            ddlCampanha.Items.Add("---ERROR---")
            ddlCampanha.Items(0).Value = "0"
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try

            If tbDataInicio.Text <> "" Then
                If IsDate(tbDataInicio.Text) = False Then
                    labscript.Text = "Informe uma data válida no filtro"
                End If
            End If

            If tbDataFim.Text <> "" Then
                If IsDate(tbDataFim.Text) = False Then
                    labscript.Text = "Informe uma data válida no filtro"
                End If
            End If

            If tbDataInicio.Text <> "" And tbDataFim.Text <> "" Then
                Dim datai As Date = funcoes.TransformaDataAnoMesDia(tbDataInicio.Text)
                Dim dataf As Date = funcoes.TransformaDataAnoMesDia(tbDataFim.Text)
                If datai > dataf Then
                    labscript.Text = "Data fim não pode ser menor que a data inicio"
                End If
            End If

            'If tbNome.Text = "" Then
            '    'labscript.Text = Ado.erroGeral("Preencha o campo descrição")
            '    labscript.Text = "Preencha o nome do prêmio"
            '    'labscript.Visible = True
            '    Return False
            'ElseIf tbNome.Text.Length > 100 Then
            '    labscript.Text = "O nome do prêmio está muito extenso. Por favor, reduza"
            '    'labscript.Visible = True
            '    Return False
            'End If

            'If ddlCampanha.SelectedIndex = 0 Then
            '    'labscript.Text = Ado.erroGeral("Selecione uma Categoria")
            '    labscript.Text = "Selecione uma Campanha"
            '    'labscript.Visible = True
            '    Return False
            'End If



            'If IsNumeric(tbValorEntrada.Text) = False Then
            '    'labscript.Text = Ado.erroGeral("Preencha corretamente o campo Valor")
            '    labscript.Text = "Preencha corretamente o campo Valor"
            '    'labscript.Visible = True
            '    Return False
            'End If

            If labscript.Text <> "" Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub butFiltrar_Click(sender As Object, e As EventArgs) Handles butFiltrar.Click
        Try
            If verificaCampos() = False Then
                Exit Sub
            End If

            carregaDados()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Private Sub carregaDados()
        Try
            'select count(*) from raspados where ras_data > '2024-04-11' and ras_data < '2024-04-12'
            Dim datai, dataf As String
            Dim dataiCliente, datafCliente As String
            Dim datah As String = funcoes.TransformaDataAnoMesDia(Date.Today)
            Dim datahCliente As String = funcoes.TransformaDataAnoMesDia(Date.Today)

            If IsDate(tbDataInicio.Text) = True Then
                datai = " and ras_data > '" & funcoes.TransformaDataAnoMesDia(tbDataInicio.Text) & "' "
                dataiCliente = " and cli_data > '" & funcoes.TransformaDataAnoMesDia(tbDataInicio.Text) & "' "
            End If

            If IsDate(tbDataFim.Text) = True Then
                Dim dataFim As Date = tbDataFim.Text
                dataFim = DateAdd(DateInterval.Day, 1, dataFim)
                dataf = " and ras_data < '" & funcoes.TransformaDataAnoMesDia(dataFim) & "' "
                datafCliente = " and cli_data < '" & funcoes.TransformaDataAnoMesDia(dataFim) & "' "
            End If
            datah = " and ras_data > '" & datah & "' "
            datahCliente = " and cli_data > '" & datahCliente & "' "

            Dim sql As String = "select count(*) from raspados where 1=1 "

            'Raspadinhas
            labRaspadosTotal.Text = banco.consultaScalar(sql & datai & dataf)
            labRaspadosHoje.Text = banco.consultaScalar(sql & datah)
            labRaspadosPremiados.Text = banco.consultaScalar(sql & datai & dataf & " and ras_premiado = 1")

            'Clientes
            sql = "select count(*) from cliente where 1=1 "

            labClientestotais.Text = banco.consultaScalar(sql & dataiCliente & datafCliente)
            labClientesHoje.Text = banco.consultaScalar(sql & datahCliente)
            labCupons.Text = banco.consultaScalar("select count(*) from Cupom where cup_id not in (select cup_id from raspados)")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub BindChartData()
        Dim raspadinhaTotal As Integer = 400
        Dim raspadinhaPremiadas As Integer = 200
        Dim raspadinhaNaoUsada As Integer = 400

        Dim chartData As New StringBuilder()
        chartData.Append("[" & raspadinhaTotal & ", " & raspadinhaPremiadas & ", " & raspadinhaNaoUsada & "]")

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ChartData", "var chartData = " & chartData.ToString() & ";", True)
    End Sub

End Class