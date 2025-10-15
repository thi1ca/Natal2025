Public Class admWinners
    Inherits System.Web.UI.Page
    Dim labscript As Label
    Dim labTitulo As Label
    Public varSessao As String
    Dim es2 As container.estrutura
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            labscript = Master.FindControl("labscript")
            labTitulo = Master.FindControl("labTitulo")
            labscript.Visible = False
            labscript.Text = ""
            labTitulo.Text = "Notificação de Premiação "


            'Session.Add("id_user", 1)
            'Session.Add("cadId", 1)
            'varSessao = "2"

            varSessao = Session.Item("cadId")

            If varSessao = "" Then Response.Redirect("index.aspx")

            If Not IsPostBack Then
                carregaCampanha()
                carregaPremio()
                carregaOrdenacao()
                CarregaGrid2()

                limpaCampos()
                'HabilitarInsercao(True)
            End If

            'customSwitch1.Checked = True

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
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

    Private Sub carregaPremio()
        Try

            Dim arr(1) As ArrayList
            arr(0) = New ArrayList
            arr(1) = New ArrayList
            Dim sql As String = "Select pre_id, pre_nome from premio where pre_ativo = 1 and cam_id = " & ddlCampanha.SelectedValue.ToString & " order by 1 asc "
            arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlPremio.Items.Clear()
            ddlPremio.Items.Add("Todos os prêmios")
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


    'TODO: Ver se faz sentido cadastrar Auditoria
    Private Sub butCadastrar_Click(sender As Object, e As EventArgs) 'Handles butCadastrar.Click
        Try
            If verificaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList



            'campo.Add("pre_voucher_codigo")
            'conteudo.Add(tbVoucher.Text)



            campo.Add("cam_id")
            conteudo.Add(ddlCampanha.SelectedValue.ToString)



            campo.Add("cad_id")
            conteudo.Add(varSessao.ToString)



            ado.incluir("premio", campo, conteudo)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()
            CarregaGrid2()

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text += ado.erroGeral(ex.Message)
        End Try
    End Sub

    'TODO: Ver se faz sentido Editar e atualizar algo
    Private Sub butConfirmar_Click(sender As Object, e As EventArgs) 'Handles butConfirmar.Click
        Try
            If verificaCampos() = False Then
                labscript.Visible = True
                labscript.Text = ado.erroGeral(labscript.Text)
                Exit Sub
            End If

            Dim conteudo As New ArrayList
            Dim campo As New ArrayList



            'campo.Add("pre_voucher_codigo")
            'conteudo.Add(tbVoucher.Text)



            campo.Add("cam_id")
            conteudo.Add(ddlCampanha.SelectedValue.ToString)



            campo.Add("cad_id")
            conteudo.Add(varSessao.ToString)

            'campo.Add("pre_ativo")
            'If cbAtivo.Checked = True Then
            '    conteudo.Add("1")
            'Else
            '    conteudo.Add("0")
            'End If

            ado.alterar("premio", campo, conteudo, "pre_id", "") ')tbID.Text)

            campo.Clear()
            conteudo.Clear()

            limpaCampos()
            CarregaGrid2()




        Catch ex As Exception
            labscript.Text = ado.erroGeral(ex.Message)
            labscript.Visible = True
        End Try
    End Sub






    Private Sub limpaCampos()
        Try

            'tbVoucher.Text = ""
            'tbTexto.Text = ""

            'cbAtivo.Checked = True
            ddlCampanha.SelectedIndex = 0

            'tbID.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function verificaCampos() As Boolean
        Try

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

            If ddlCampanha.SelectedIndex = 0 Then
                'labscript.Text = Ado.erroGeral("Selecione uma Categoria")
                labscript.Text = "Selecione uma Campanha"
                'labscript.Visible = True
                Return False
            End If



            'If IsNumeric(tbValorEntrada.Text) = False Then
            '    'labscript.Text = Ado.erroGeral("Preencha corretamente o campo Valor")
            '    labscript.Text = "Preencha corretamente o campo Valor"
            '    'labscript.Visible = True
            '    Return False
            'End If



            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function





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

#Region "GRID"



    Private Sub carregaOrdenacao()
        Try

            'Dim arr(1) As ArrayList
            'arr(0) = New ArrayList
            'arr(1) = New ArrayList
            'Dim sql As String = "Select per_id, per_nome from perfil where per_ativo = 1 order by 1 asc "
            'arr = ado.ConsultaSQL(sql)

            Dim f As Integer = 0
            ddlOrdenacao.Items.Clear()

            ddlOrdenacao.Items.Add("Raspados ASC")
            ddlOrdenacao.Items(0).Value = "ras_id asc"

            ddlOrdenacao.Items.Add("Raspados DESC")
            ddlOrdenacao.Items(1).Value = "ras_id desc"

            ddlOrdenacao.Items.Add("Ativos ASC")
            ddlOrdenacao.Items(2).Value = "pre_ativo asc, ras_id asc"

            ddlOrdenacao.Items.Add("Ativos DESC")
            ddlOrdenacao.Items(3).Value = "pre_ativo desc, ras_id desc"




            'If arr(0).Count > 0 Then
            '    For f = 0 To arr(0).Count - 1
            '        ddlOrdenacao.Items.Add(arr(1).Item(f))
            '        ddlOrdenacao.Items(f + 1).Value = arr(0).Item(f)


            '    Next
            'End If
        Catch ex As Exception
            ddlOrdenacao.Items.Clear()
            ddlOrdenacao.Items.Add("---ERROR---")
            ddlOrdenacao.Items(0).Value = "0"
        End Try
    End Sub




    Public Sub CarregaGrid2()
        Try
            Dim IntCont As Integer = 0
            Dim sql, sqlCount As String

            'Trás todos os premiados que não foram notificados

            sql = "select r.*, cli_nome, cli_cpf, cli_celular, cli_email, pre_nome, pre_voucher_codigo, pre_ativo, cal_data_premio, cal_voucher, cal_notificado_email, cal_notificado_whatsapp, ca.pre_id  "
            sql += "from raspados r "
            sql += "inner join cliente c on r.cli_id = c.cli_id "
            sql += "inner join calendario ca on r.cal_id = ca.cal_id "
            sql += "inner join premio p on ca.pre_id = p.pre_id "
            sql += "where ras_premiado = 1 "
            sql += " And cam_id =  " & ddlCampanha.SelectedValue.ToString

            If ddlPremio.SelectedIndex > 0 Then sql += "and ca.pre_id = " & ddlPremio.SelectedValue.ToString

            If IsDate(tbDataInicio.Text.Trim) = True Then sql += " And ras_data >= '" & funcoes.TransformaDataAnoMesDia(tbDataInicio.Text.Trim) & "' "

            If IsDate(tbDataFim.Text.Trim) = True Then
                Dim dataFim As Date = funcoes.TransformaDataAnoMesDia(tbDataFim.Text.Trim)
                dataFim = dataFim.AddDays(1)
                sql += " And ras_data <= '" & funcoes.TransformaDataAnoMesDia(dataFim) & "' "

            End If

            If cbPendentes.Checked = True Then sql += "And ((cal_notificado_whatsapp Is null Or cal_notificado_whatsapp = 0) Or (cal_notificado_email Is null Or cal_notificado_email = 0)) "


            'Prepara a query para count (sem ordenação)
            sqlCount = sql

            'Finaliza com ordenação
            'sql += "  order by cli_ativo desc, cli_nome asc"
            sql += "  order by " & ddlOrdenacao.SelectedValue.ToString

            'Configurando
            es2.pagina_atual = 1

            'Qtd de registros por pagina
            Dim qtdPorPagina As Integer = 20
            If IsNumeric(tbPaginacao.Text) = True Then qtdPorPagina = CInt(tbPaginacao.Text)
            es2.registros_por_pagina = qtdPorPagina


            es2.contador = "Select count (*) from (" & sqlCount & ") aa"

            es2.comando = sql

            'comentário:executando
            es2 = container.gerar(Repeater2, es2)

            'Esconde botão de carregar + se não tiver mais registros
            If es2.total <= qtdPorPagina Then butCarregar.Visible = False

            'Mostrando 1 a 10 de 50 cadastrado
            'labTotal.Text = "Encontrado total de " & es.total.ToString & " registros"
            'Label2.Text = "Total de Registros: <font color='red'>" + es.total.ToString + "</font>"
            'Label1.Text = "Página Atual:  <font color='red'>" + (es.pagina_atual).ToString
            'Label1.Text += "</font> de  <font color='red'>" + es.qtd_paginas.ToString + "</font>"
            'carregaBotao()

            Session.Add("es2", es2)


        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub Repeater2_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater2.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.AlternatingItem OrElse e.Item.ItemType = ListItemType.Item Then
                Dim butEnviar As Button = CType(e.Item.FindControl("butEnviar"), Button)
                Dim cbEmail As CheckBox = CType(e.Item.FindControl("cbEmail"), CheckBox)
                Dim cbWhatsapp As CheckBox = CType(e.Item.FindControl("cbWhatsapp"), CheckBox)
                Dim tbCupom As TextBox = CType(e.Item.FindControl("tbCupom"), TextBox)
                Dim divMenuzinho As HtmlGenericControl = CType(e.Item.FindControl("divMenuzinho"), HtmlGenericControl)
                Dim butReenviarEmail As LinkButton = CType(e.Item.FindControl("butReenviarEmail"), LinkButton)
                Dim butReenviarWhatsapp As LinkButton = CType(e.Item.FindControl("butReenviarWhatsapp"), LinkButton)

                butEnviar.CommandName = "enviar"
                butReenviarEmail.CommandName = "email"
                butReenviarWhatsapp.CommandName = "whatsapp"

                'Dim btnDetalhes As LinkButton = CType(e.Item.FindControl("linkDetalhes"), LinkButton)

                If IsDBNull(DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(15)) = True Then
                    cbEmail.Checked = False
                ElseIf DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(15) = True Then
                    cbEmail.Checked = True
                    cbEmail.Enabled = False
                Else
                    cbEmail.Checked = False
                End If

                If IsDBNull(DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(16)) = True Then
                    cbWhatsapp.Checked = False
                ElseIf DirectCast(e.Item.DataItem, System.Data.DataRowView).Row.ItemArray(16) = True Then
                    cbWhatsapp.Checked = True
                    cbWhatsapp.Enabled = False
                Else
                    cbWhatsapp.Checked = False
                End If

                If cbEmail.Enabled = False And cbWhatsapp.Enabled = False Then
                    butEnviar.Visible = False
                    tbCupom.Enabled = False
                    divMenuzinho.Visible = True
                Else
                    divMenuzinho.Visible = False
                End If

            End If

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Private Sub Repeater2_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles Repeater2.ItemCommand
        Try
            Dim cbEmail As CheckBox = CType(e.Item.FindControl("cbemail"), CheckBox)
            Dim cbWhatsapp As CheckBox = CType(e.Item.FindControl("cbWhatsapp"), CheckBox)
            Dim tbCupom As TextBox = CType(e.Item.FindControl("tbCupom"), TextBox)
            Dim rasId As Integer = e.CommandArgument

            Dim sql As String = "select cli_nome, cli_cpf, cli_celular, cli_email, pre_nome, r.cal_id, cal_voucher, cal_notificado_email, cal_notificado_whatsapp, ca.pre_id  from raspados r inner join cliente c on r.cli_id = c.cli_id inner join calendario ca on r.cal_id = ca.cal_id inner join premio p on ca.pre_id = p.pre_id where ras_id =  " & rasId.ToString

            Dim dv As DataView = banco.consulta(sql)

            Dim nomeCliente As String = funcoes.ExtraiPrimeiroNome(dv(0)("cli_nome"))
            Dim emailCliente As String = dv(0)("cli_email")
            Dim celularCliente As String = dv(0)("cli_celular")
            Dim nomePremio As String = dv(0)("pre_nome")
            Dim Voucher As String = tbCupom.Text.Trim
            Dim sucesso As Boolean = True
            Dim calId As Integer = dv(0)("cal_id")

            If e.CommandName = "enviar" Then

                If tbCupom.Text.Trim = "" Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Preencha o código do voucher", False, True)
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
                    Exit Sub
                End If

                If cbEmail.Checked = False And cbWhatsapp.Checked = False Then
                    labscript.Visible = True
                    labscript.Text = ado.erroGeral("Selecione Email e/ou Whatsapp", False, True)
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
                    Exit Sub
                End If


                banco.executa("update calendario set cal_voucher = '" & Voucher & "' where cal_id = " & calId.ToString)

                If cbEmail.Checked = True And cbEmail.Enabled = True Then
                    Try
                        eMail.enviaEmailPremioCliente(nomeCliente, emailCliente, nomePremio, Voucher)
                        banco.executa("update calendario set cal_notificado_email = '1' where cal_id = " & calId.ToString)

                        labscript.Text += "Email enviado com sucesso!!!"
                    Catch ex As Exception
                        labscript.Text += "Erro ao enviar Email"
                        sucesso = False
                    End Try
                End If

                If cbWhatsapp.Checked = True And cbWhatsapp.Enabled = True Then
                    Try
                        Dim mensagem As String = "Parabéns " & nomeCliente & "!!! Você foi premiado com um " & nomePremio & ". "
                        mensagem += vbCrLf & "Acesse o APP ou site das Lojas Torra e utilize o código " & Voucher & " no campo VALE COMPRAS."
                        whatsapp.mensagem("55" & celularCliente, mensagem)
                        banco.executa("update calendario set cal_notificado_whatsapp = '1' where cal_id = " & calId.ToString)

                        If labscript.Text <> "" Then labscript.Text += "<br><br>"
                        labscript.Text += "Whatsapp enviado com sucesso!!!"
                        sucesso = True
                    Catch ex As Exception
                        labscript.Text += "Erro ao enviar whatsapp"
                        sucesso = False
                    End Try
                End If



            ElseIf e.CommandName = "email" Then
                Try
                    eMail.enviaEmailPremioCliente(nomeCliente, emailCliente, nomePremio, Voucher)
                    'banco.executa("update calendario set cal_notificado_email = '1' where cal_id = " & calId.ToString)
                    labscript.Text += "Email enviado com sucesso!!!"
                Catch ex As Exception
                    labscript.Text += "Erro ao enviar Email"
                    sucesso = False
                End Try

            ElseIf e.CommandName = "whatsapp" Then
                Try
                    Dim mensagem As String = "Parabéns " & nomeCliente & "!!! Você foi premiado com um " & nomePremio & ". "
                    mensagem += vbCrLf & "Acesse o APP ou site das Lojas Torra e utilize o código " & Voucher & " no campo VALE COMPRAS."
                    whatsapp.mensagem("55" & celularCliente, mensagem)
                    'banco.executa("update calendario set cal_notificado_whatsapp = '1' where cal_id = " & calId.ToString)

                    labscript.Text += "Whatsapp enviado com sucesso!!!"
                    sucesso = True
                Catch ex As Exception
                    labscript.Text += "Erro ao enviar whatsapp"
                    sucesso = False
                End Try

            End If

            If labscript.Text <> "" Then labscript.Visible = True
            labscript.Text = ado.erroGeral(labscript.Text, sucesso, True)

            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)

            CarregaGrid2()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub






    'Private Sub butProximo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butProximo.Click
    '    Try
    '        es = Session.Item("es")
    '        es = container.proximo(Repeater1, es)
    '        Session.Item("es") = es
    '        'manipulando resultado
    '        labTotal.Text = "Encontrado total de " & es.total.ToString & " registros"
    '        carregaBotao()
    '    Catch ex As Exception
    '        labscript.Visible = True
    '        labscript.Text += ado.erroGeral("Erro de paginação")
    '    End Try
    'End Sub





    Protected Sub ddlOrdenacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrdenacao.SelectedIndexChanged
        Try
            CarregaGrid2()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Private Sub ddlCampanha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCampanha.SelectedIndexChanged
        Try
            carregaPremio()
            CarregaGrid2()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Private Sub ddlPremio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPremio.SelectedIndexChanged
        Try
            CarregaGrid2()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Private Sub butFiltrar_Click(sender As Object, e As EventArgs) Handles butFiltrar.Click
        Try
            tbPaginacao.Text = "20"
            butCarregar.Visible = True
            CarregaGrid2()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub

    Protected Sub butCarregar_Click(sender As Object, e As EventArgs) Handles butCarregar.Click
        Try
            Dim qtdPorPagina As Integer = 20
            If IsNumeric(tbPaginacao.Text) = True Then qtdPorPagina = CInt(tbPaginacao.Text)
            qtdPorPagina += 20
            tbPaginacao.Text = qtdPorPagina.ToString
            CarregaGrid2()
            'es = Session.Item("es")
            '        es = container.proximo(Repeater1, es)
            '        Session.Item("es") = es
            '        'manipulando resultado
            '        labTotal.Text = "Encontrado total de " & es.total.ToString & " registros"
            '        carregaBotao()
        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message, False, True)
            ScriptManager.RegisterStartupScript(Me, GetType(Page), "SweetAlert", labscript.Text, True)
        End Try
    End Sub



#End Region


End Class