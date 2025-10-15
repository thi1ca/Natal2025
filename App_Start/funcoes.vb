Imports System.Object
Imports System.Web
Imports System.Web.Util
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.IO



Public Class funcoes

#Region "Funções CPF/CNPJ"

    Public Shared Function CarregaUF2() As ArrayList
        Dim arrUF As New ArrayList
        With arrUF
            .Insert(0, New ListItem("CE", "CE"))
            .Insert(0, New ListItem("AC", "AC"))
            .Insert(0, New ListItem("AL", "AL"))
            .Insert(0, New ListItem("AM", "AM"))
            .Insert(0, New ListItem("AP", "AP"))
            .Insert(0, New ListItem("BA", "BA"))
            .Insert(0, New ListItem("CE", "CE"))
            .Insert(0, New ListItem("DF", "DF"))
            .Insert(0, New ListItem("ES", "ES"))
            .Insert(0, New ListItem("GO", "GO"))
            .Insert(0, New ListItem("MA", "MA"))
            .Insert(0, New ListItem("MG", "MG"))
            .Insert(0, New ListItem("MS", "MS"))
            .Insert(0, New ListItem("MT", "MT"))
            .Insert(0, New ListItem("PA", "PA"))
            .Insert(0, New ListItem("PB", "PB"))
            .Insert(0, New ListItem("PE", "PE"))
            .Insert(0, New ListItem("PI", "PI"))
            .Insert(0, New ListItem("PR", "PR"))
            .Insert(0, New ListItem("RJ", "RJ"))
            .Insert(0, New ListItem("RN", "RN"))
            .Insert(0, New ListItem("RO", "RO"))
            .Insert(0, New ListItem("RR", "RR"))
            .Insert(0, New ListItem("RS", "RS"))
            .Insert(0, New ListItem("SC", "SC"))
            .Insert(0, New ListItem("SE", "SE"))
            .Insert(0, New ListItem("SP", "SP"))
            .Insert(0, New ListItem("TO", "TO"))
        End With
        Return arrUF
    End Function

    Public Shared Function VerificaCPF(ByVal strCPFCliente As String) As Boolean

        '--Declaração das Variáveis
        Dim strCPFOriginal As String = strCPFCliente.Replace(".", "").Replace("-", "")
        Dim strCPF As String = Mid(strCPFOriginal, 1, 9)
        Dim strCPFTemp As String
        Dim intSoma As Integer
        Dim intResto As Integer
        Dim strDigito As String
        Dim intMultiplicador As Integer = 10
        Const constIntMultiplicador As Integer = 11
        Dim i As Integer
        '--------------------------

        'Se não for numero
        If IsNumeric(strCPFOriginal) = False Then Return False

        If strCPFOriginal.Count <> 11 Then Return False

        For i = 0 To strCPF.ToString.Length - 1
            intSoma += CInt(strCPF.ToString.Chars(i).ToString) * intMultiplicador
            intMultiplicador -= 1
        Next

        If (intSoma Mod constIntMultiplicador) < 2 Then
            intResto = 0
        Else
            intResto = constIntMultiplicador - (intSoma Mod constIntMultiplicador)
        End If

        strDigito = intResto
        intSoma = 0

        strCPFTemp = strCPF & strDigito
        intMultiplicador = 11

        For i = 0 To strCPFTemp.Length - 1
            intSoma += CInt(strCPFTemp.Chars(i).ToString) * intMultiplicador
            intMultiplicador -= 1
        Next

        If (intSoma Mod constIntMultiplicador) < 2 Then
            intResto = 0
        Else
            intResto = constIntMultiplicador - (intSoma Mod constIntMultiplicador)
        End If

        strDigito &= intResto

        If strDigito = Mid(strCPFOriginal, 10, strCPFOriginal.Length) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function MaskaraCNPJ(ByVal str As String) As String
        Dim intPosicao() As Integer = {2, 5, 8, 12}
        Dim intSeparador() As String = {".", ".", "/", "-"}
        Dim cnpj As String
        For i As Integer = 0 To str.Length - 1
            For x As Integer = 0 To intPosicao.Length - 1
                If i = intPosicao(x) Then
                    cnpj &= intSeparador(x)
                End If
            Next
            cnpj &= str.Chars(i)
        Next
        Return cnpj
    End Function



    Public Shared Function MascaraCPF(ByVal str As String) As String
        Dim intPosicao() As Integer = {3, 6, 9}
        Dim intSeparador() As String = {".", ".", "-"}
        Dim CPF As String
        For i As Integer = 0 To str.Length - 1
            For x As Integer = 0 To intPosicao.Length - 1
                If i = intPosicao(x) Then
                    CPF &= intSeparador(x)
                End If
            Next
            CPF &= str.Chars(i)
        Next
        Return CPF
    End Function
    Public Function VerificaCNPJ(ByVal intNumero) As Boolean
        'Validando a sequencia números
        Dim CNPJ_temp
        Dim CNPJ_Digito_temp
        Dim soma
        Dim resto
        Dim digitoHum
        Dim digitoDois
        Dim digitoCNPJ
        Dim retorno

        CNPJ_temp = intNumero
        CNPJ_temp = Replace(CNPJ_temp, ".", "")
        CNPJ_temp = Replace(CNPJ_temp, "/", "")
        CNPJ_temp = Replace(CNPJ_temp, "-", "")
        CNPJ_Digito_temp = Right(CNPJ_temp, 2)

        'Somando os 12 primeiros digitos do CNPJ 
        soma = (CLng(Mid(CNPJ_temp, 1, 1)) * 5) + (CLng(Mid(CNPJ_temp, 2, 1)) * 4) + (CLng(Mid(CNPJ_temp, 3, 1)) * 3) + (CLng(Mid(CNPJ_temp, 4, 1)) * 2) + (CLng(Mid(CNPJ_temp, 5, 1)) * 9) + (CLng(Mid(CNPJ_temp, 6, 1)) * 8) + (CLng(Mid(CNPJ_temp, 7, 1)) * 7) + (CLng(Mid(CNPJ_temp, 8, 1)) * 6) + (CLng(Mid(CNPJ_temp, 9, 1)) * 5) + (CLng(Mid(CNPJ_temp, 10, 1)) * 4) + (CLng(Mid(CNPJ_temp, 11, 1)) * 3) + (CLng(Mid(CNPJ_temp, 12, 1)) * 2)
        '----------------------------------
        'Calculando o 1º dígito verificador
        '----------------------------------
        'Pegando o resto da divisão por 11
        resto = (soma Mod 11)
        If resto < 2 Then
            digitoHum = 0
        Else
            digitoHum = CStr(11 - resto)
        End If
        '----------------------------------
        '----------------------------------
        'Calculando o 2º dígito verificador
        '----------------------------------
        'Somando os 12 primeiros digitos do CNPJ mais o 1º dígito
        soma = (CLng(Mid(CNPJ_temp, 1, 1)) * 6) + (CLng(Mid(CNPJ_temp, 2, 1)) * 5) + (CLng(Mid(CNPJ_temp, 3, 1)) * 4) + (CLng(Mid(CNPJ_temp, 4, 1)) * 3) + (CLng(Mid(CNPJ_temp, 5, 1)) * 2) + (CLng(Mid(CNPJ_temp, 6, 1)) * 9) + (CLng(Mid(CNPJ_temp, 7, 1)) * 8) + (CLng(Mid(CNPJ_temp, 8, 1)) * 7) + (CLng(Mid(CNPJ_temp, 9, 1)) * 6) + (CLng(Mid(CNPJ_temp, 10, 1)) * 5) + (CLng(Mid(CNPJ_temp, 11, 1)) * 4) + (CLng(Mid(CNPJ_temp, 12, 1)) * 3) + (CLng(CInt(digitoHum) * 2))
        'Pegando o resto da divisão por 11
        resto = (soma Mod 11)
        If resto < 2 Then
            digitoDois = 0
        Else
            digitoDois = CStr(11 - resto)
        End If
        '----------------------------------
        'Verificando se os digitos são iguais aos digítados.
        digitoCNPJ = CStr(digitoHum) & CStr(digitoDois)
        If CStr(CNPJ_Digito_temp) = CStr(digitoCNPJ) Then
            retorno = True
        Else
            retorno = False
        End If

        Return retorno

    End Function


#End Region

#Region "Funções de Alerta em JavaScript Para ASCX "
    ' esta versão é Para ASPX
    Public Overloads Shared Sub Tesssssste(ByVal strMSG As String)
        With HttpContext.Current.Response
            .Write("<script language='JavaScript'>")
            .Write("    alert('" & strMSG & "');")
            .Write("</script>")
        End With
    End Sub
    ' esta versão é para ASPX
    'Public Overloads Shared Sub alerta(ByVal strMSG As String, ByVal Pagina As String)
    '    With HttpContext.Current.Response
    '        .Write("<script language='JavaScript'>")
    '        .Write("    alert('" & strMSG & "');")
    '        .Write("    window.location.href = ('" & Pagina & "');")
    '        .Write("</script>")
    '    End With
    'End Sub
    Public Overloads Shared Function alerta(ByVal strMSG As String) As String
        Dim script As String
        script = "<script language='JavaScript'>" &
        "alert('" & strMSG & "');" &
        "</script>"
        Return script
    End Function

    Public Overloads Shared Function alerta(ByVal strMSG As String, ByVal Pagina As String) As String
        Dim script As String
        script = "<script language='JavaScript'>" &
        "alert('" & strMSG & "');" &
        "window.location.href = ('" & Pagina & "');" &
        "</script>"
        Return script
    End Function

    Public Shared Function Confirma(ByVal strMSG As String) As Integer
        With HttpContext.Current.Response
            .Write("<script language='JavaScript'>")
            .Write("if (Confirm('" & strMSG & "'));")
            .Write("    {")
            .Write("        return 1;")
            .Write("    }")
            .Write("else{")
            .Write("    return 0;")
            .Write("    }")
            .Write("</script>")
        End With
    End Function
#End Region

#Region "Funções para carregar e popular o componente Grid"


    Public Shared Function GridRdoPopRedeLojas(ByVal Procedure As String, ByVal items As String, ByVal retorno As String, ByVal Autoclose As Boolean, Optional ByVal mostra As String = "Codigo", Optional ByVal RetornoSelect As String = "InserirItem") As String
        Dim NomeJanela As String =
        Convert.ToString(Date.Today.Day) &
        Convert.ToString(Date.Today.Month) &
        Convert.ToString(Date.Today.Year) &
        Convert.ToString(Date.Today.Hour) &
        Convert.ToString(Date.Today.Minute) &
        Convert.ToString(Date.Today.Second) &
        Convert.ToString(Date.Today.Millisecond)
        Try
            Dim script As String
            script = "<script Language='JavaScript'>" &
            "popUpWindow('" & ("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") &
            (HttpContext.Current.Request.ApplicationPath)) &
            "/Sistema/Controls/Conteudo/Retail/PopUp/RedeLojaPop.aspx?Items=" & items &
            "&Autoclose=" & Autoclose &
            "&Procedure=" & Procedure &
            "&Janela=" & NomeJanela &
            "&Retorno=" & retorno &
            "&Mostra=" & mostra &
            "&RetornoSelect=" & RetornoSelect &
            "','','scrollbars=1,resizable=1,width=500,height=400');" &
            "</script>"
            Return script
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GridRdoPopDistribuidores(ByVal Procedure As String, ByVal IDCampoTexto As String, ByVal IDCampoHidden As String, ByVal items As String, ByVal retorno As String, ByVal Autoclose As Boolean, Optional ByVal mostra As String = "Codigo", Optional ByVal RetornoSelect As String = "InserirItem") As String
        Dim NomeJanela As String =
        Convert.ToString(Date.Today.Day) &
        Convert.ToString(Date.Today.Month) &
        Convert.ToString(Date.Today.Year) &
        Convert.ToString(Date.Today.Hour) &
        Convert.ToString(Date.Today.Minute) &
        Convert.ToString(Date.Today.Second) &
        Convert.ToString(Date.Today.Millisecond)
        Try
            Dim script As String
            script = "<script Language='JavaScript'>" &
            "popUpWindow('" & ("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") &
            (HttpContext.Current.Request.ApplicationPath)) &
            "/Sistema/Controls/Conteudo/Retail/PopUp/DistribuidorPopUp.aspx?Items=" & items &
            "&IDCampoHidden=" & IDCampoHidden &
            "&IDCampoTexto=" & IDCampoTexto &
            "&Autoclose=" & Autoclose &
            "&Procedure=" & Procedure &
            "&Janela=" & NomeJanela &
            "&Retorno=" & retorno &
            "&Mostra=" & mostra &
            "&RetornoSelect=" & RetornoSelect &
            "','','scrollbars=1,resizable=1,width=500,height=400');" &
            "</script>"
            Return script
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Shared Function GridRdoPopMatColocado(ByVal items As String, ByVal retorno As String, ByVal Autoclose As Boolean) As String
    '    Dim NomeJanela As String = _
    '    Convert.ToString(Date.Today.Day) & _
    '    Convert.ToString(Date.Today.Month) & _
    '    Convert.ToString(Date.Today.Year) & _
    '    Convert.ToString(Date.Today.Hour) & _
    '    Convert.ToString(Date.Today.Minute) & _
    '    Convert.ToString(Date.Today.Second) & _
    '    Convert.ToString(Date.Today.Millisecond)
    '    Try
    '        Dim script As String
    '        script = "<script Language='JavaScript'>" & _
    '        "popUpWindow('" & ("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") & _
    '        (HttpContext.Current.Request.ApplicationPath)) & _
    '        "/controls/conteudo/PopUp/MatColocadoPop.aspx?Items=" & items & _
    '        "&Autoclose=" & Autoclose & _
    '        "&Janela=" & NomeJanela & _
    '        "&Retorno=" & retorno & _
    '        "','','scrollbars=1,resizable=1,width=500,height=400');" & _
    '        "</script>"
    '        Return script
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Shared Function GridRdoPopCidades(ByVal Procedure As String, ByVal items As String, ByVal Autoclose As Boolean, ByVal UF As String) As String
        Dim NomeJanela As String =
        Convert.ToString(Date.Today.Day) &
        Convert.ToString(Date.Today.Month) &
        Convert.ToString(Date.Today.Year) &
        Convert.ToString(Date.Today.Hour) &
        Convert.ToString(Date.Today.Minute) &
        Convert.ToString(Date.Today.Second) &
        Convert.ToString(Date.Today.Millisecond)
        Try
            Dim script As String
            script = "<script Language='JavaScript'>" &
            "popUpWindow('" & ("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") &
            (HttpContext.Current.Request.ApplicationPath)) &
            "/Sistema/controls/conteudo/Retail/PopUp/CidadesPop.aspx?Items=" & items &
            "&Autoclose=" & Autoclose &
            "&UF=" & UF &
            "&Procedure=" & Procedure &
            "&Janela=" & NomeJanela &
            "','','scrollbars=1,resizable=1,width=500,height=400');" &
            "</script>"
            Return script
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function GridRdoPopUp2(ByVal Procedure As String, ByVal items As String, ByVal retorno As String, ByVal Autoclose As Boolean, Optional ByVal mostra As String = "Codigo", Optional ByVal RetornoSelect As String = "InserirItem") As String
        Dim NomeJanela As String =
        Convert.ToString(Date.Today.Day) &
        Convert.ToString(Date.Today.Month) &
        Convert.ToString(Date.Today.Year) &
        Convert.ToString(Date.Today.Hour) &
        Convert.ToString(Date.Today.Minute) &
        Convert.ToString(Date.Today.Second) &
        Convert.ToString(Date.Today.Millisecond)
        Try
            Dim script As String
            script = "<script Language='JavaScript'>" &
            "popUpWindow('" & ("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") &
            (HttpContext.Current.Request.ApplicationPath)) &
            "/lnkPopUp.aspx?Items=" & items &
            "&Autoclose=" & Autoclose &
            "&Procedure=" & Procedure &
            "&Janela=" & NomeJanela &
            "&Retorno=" & retorno &
            "&Mostra=" & mostra &
            "&RetornoSelect=" & RetornoSelect &
            "','','scrollbars=1,resizable=1,width=500,height=400');" &
            "</script>"
            Return script
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub GridRdoPopUp(ByVal Procedure As String, ByVal items As String, ByVal retorno As String, ByVal Autoclose As Boolean, Optional ByVal mostra As String = "Codigo", Optional ByVal RetornoSelect As String = "InserirItem")
        Dim NomeJanela As String =
        Convert.ToString(Date.Today.Day) &
        Convert.ToString(Date.Today.Month) &
        Convert.ToString(Date.Today.Year) &
        Convert.ToString(Date.Today.Hour) &
        Convert.ToString(Date.Today.Minute) &
        Convert.ToString(Date.Today.Second) &
        Convert.ToString(Date.Today.Millisecond)

        Try
            With HttpContext.Current.Response
                .Write("<script Language='JavaScript'>")
                .Write("window.open('" & ("http://" & HttpContext.Current.Request.ServerVariables("SERVER_NAME") & (HttpContext.Current.Request.ApplicationPath)) & "/lnkPopUp.aspx?Items=" & items & "&Autoclose=" & Autoclose & "&Procedure=" & Procedure & "&Janela=" & NomeJanela & "&Retorno=" & retorno & "&Mostra=" & mostra & "&RetornoSelect=" & RetornoSelect & "','','scrollbars=1,resizable=1,width=500,height=400');")
                .Write("</script>")

            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub






    'Esta Sub recebe a página que será aplicado a Picuinha.
    'Além dela, receberá também o botão default que receberá disparará o evento Click
    'ao pressionar ENTER e submeterá o formulário.
    Public Sub SubmitForm(ByRef Page As System.Web.UI.Page, ByRef objButton As Button)
        Dim JSScript As New System.Text.StringBuilder
        Dim scriptAttribute As String

        With JSScript
            .Append("<SCRIPT language=""javascript"">" & Environment.NewLine)
            .Append("function SubmitForm(btn){" & Environment.NewLine)
            .Append(" if (document.all){" & Environment.NewLine)
            .Append("   if (event.keyCode == 13)" & Environment.NewLine)
            .Append("   { " & Environment.NewLine)
            .Append("     event.returnValue=false;" & Environment.NewLine)
            .Append("     event.cancel = true;" & Environment.NewLine)
            .Append("     btn.click();" & Environment.NewLine)
            .Append("   } " & Environment.NewLine)
            .Append(" } " & Environment.NewLine)
            .Append("}" & Environment.NewLine)
            .Append("</SCRIPT>" & Environment.NewLine)
        End With

        scriptAttribute = "SubmitForm(document.all." & objButton.ClientID & ")"
        SerchControls(Page, scriptAttribute)
        Page.RegisterStartupScript("SubmitFormScript", JSScript.ToString)
    End Sub

    'Esta Sub percorre os controles existem na página ou em outros controles
    'e atribui ao Evento OnKeyDown do TextBox o script gerada na Sub acima
    'que submeter o Form quando o ENTER for pressionado
    'A função é recursiva, pois podem haver controles que contenham controles.
    'Apenas fiz a verificação para TextBox, o ideal é fazer para ChckBox, DropDown, etc...
    Private Sub SerchControls(ByRef control As System.Web.UI.Control, ByVal script As String)
        Dim ctl As System.Web.UI.Control
        For Each ctl In control.Controls
            If TypeOf ctl Is TextBox Then
                DirectCast(ctl, TextBox).Attributes.Add("onKeyDown", script)
            ElseIf ctl.Controls.Count > 0 Then
                SerchControls(ctl, script)
            End If
        Next
    End Sub
#End Region

#Region "Funções de XML"

    Public Shared Function VerificaArq(ByVal Arquivo As String) As Boolean
        Dim f As System.IO.File
        If f.Exists(Arquivo) Then
            If (f.GetCreationTime(Arquivo).ToShortDateString) = Date.Today.ToShortDateString Then
                Return True
            End If
        Else
            Return False
        End If
    End Function
#End Region

#Region "Função Global que lista qq Coisa de QQ Tabela"

    Public Enum ListaFilial
        ID
        Nome
    End Enum



#End Region

#Region "Funções de Data"
    Public Shared Function TrataData(ByVal data As String) As Boolean
        Dim strData() As String = Split(data, "/")
        If IsDate(strData(1) & "/" & strData(0) & "/" & strData(2)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function TransformaData(ByVal data As String) As String
        ' Dim strData() As String = Split(data, "/")
        'Return strData(1) & "/" & strData(0) & "/" & strData(2)
        Dim strData() As String = Split(data, "/")
        Return strData(0) & "/" & strData(1) & "/" & strData(2)
    End Function

    Public Shared Function TransformaDataDiaMes(ByVal data As Date) As String

        Dim dia, mes As String
        If Day(data) < 10 Then
            dia = "0" & Day(data)
        Else
            dia = Day(data)
        End If

        If Month(data) < 10 Then
            mes = "0" & Month(data)
        Else
            mes = Month(data)
        End If

        Return dia & "/" & mes
    End Function

    Public Shared Function TransformaDataAnoMesDia(ByVal data As Date) As String

        Dim dia, mes, ano As String
        If Day(data) < 10 Then
            dia = "0" & Day(data)
        Else
            dia = Day(data)
        End If

        If Month(data) < 10 Then
            mes = "0" & Month(data)
        Else
            mes = Month(data)
        End If

        Return Year(data).ToString & "-" & mes & "-" & dia
    End Function

    Public Shared Function RetornaDataPadrao(ByVal data As String) As String
        If Not data = String.Empty Then
            Dim strData() As String = Split(data, "/")
            Return strData(2) & "-" & strData(1) & "-" & strData(0)
        Else
            Return ""
        End If
    End Function

    Public Shared Function verificaSeOPeriodoEhMesCheio(datai As Date, dataf As Date) As Boolean
        If datai.Day <> 1 Then Return False

        If datai.Month <> dataf.Month Then Return False

        Dim days As Long = DateDiff(DateInterval.Day, datai, dataf) + 1
        If days > 31 Then Return False 'Qtd de dias maior que 1 mes
        If days < 28 Then Return False 'Qtd de dias menor que a de fevereiro
        If (days = 28 Or days = 29) And datai.Month <> 2 Then Return False 'Apenas fevereiro pode ser 28 dias
        If days = 30 And (datai.Month = 1 Or datai.Month = 2 Or datai.Month = 3 Or datai.Month = 5 Or datai.Month = 7 Or datai.Month = 8 Or datai.Month = 10 Or datai.Month = 12) Then Return False
        If days = 31 And (datai.Month = 2 Or datai.Month = 4 Or datai.Month = 6 Or datai.Month = 9 Or datai.Month = 11) Then Return False

        Return True

    End Function
#End Region



#Region "Funções de Grid"

    Public Shared Function formataLinhaGrid(gData As Date, gDescricao As String, gValor As Double, gSaldo As Double, gConciliado As Boolean, gObs As String, iCartaoCredito As Boolean, gAlert As Boolean, gEstorno As Boolean, gDebitoAut As Boolean) As String
        Try
            'Recebe Data, descricao, valor, saldo, c, obs, se é cartão de crédito para mostrar icone, se tem alert, se tem estorno, se é débito automatico

            'Formata data



            Dim linhaGrid As String
            'linhaGrid = "<tr>                   "
            'linhaGrid += "   <td>                 "
            'linhaGrid += "		<label title = '" & funcoes.diaDaSemana(gData.DayOfWeek.ToString("d"), 2) & "' data-toggle='tooltip'>" & diaDaSemana & "</label>"
            'linhaGrid += "	</td>                 "
            linhaGrid += "  <td> <i Class='fas fa-arrow-alt-circle-down' style='font-size: 1.3em;'></i>&nbsp;&nbsp;<label title='' data-toggle='tooltip'>Netflix (Of cobrança aut)</label></td>"
            linhaGrid += "	<td Class='text-right'>60,00</td>         "
            linhaGrid += "	<td Class='text-right'>                   "
            linhaGrid += "  <Label>1.000,00</label>	                  "
            linhaGrid += "	</td>                                     "
            linhaGrid += "	<td Class='text-center'><a href='excluir' class='text-black'><i class='fab fa-cuttlefish'></i></a></td>"
            linhaGrid += "	<td Class='with-btn' nowrap>              "
            linhaGrid += "	<a href = '#' Class='btn btn-yellow width-60 btn-sm'>Editar</a> "
            linhaGrid += "	<a href = '#' Class='btn btn-danger width-60 btn-sm'>Excluir</a> "
            linhaGrid += "	</td>               "
            linhaGrid += "  </tr>                         "

            Return linhaGrid
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function formataTootipData(gData As Date) As String
        Try
            Return funcoes.diaDaSemana(gData.DayOfWeek.ToString("d"), 2)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function formataData(gData As Date) As String
        Try
            Dim diaDaSemana As String

            If gData.DayOfWeek = 0 Then
                diaDaSemana = " Domingo - "
            ElseIf gData.DayOfWeek = 1 Then
                diaDaSemana = " Segunda -  "
            ElseIf gData.DayOfWeek = 2 Then
                diaDaSemana = " Terça - "
            ElseIf gData.DayOfWeek = 3 Then
                diaDaSemana = " Quarta - "
            ElseIf gData.DayOfWeek = 4 Then
                diaDaSemana = " Quinta - "
            ElseIf gData.DayOfWeek = 5 Then
                diaDaSemana = " Sexta - "
            Else
                diaDaSemana = " Sábado - "
            End If

            ' = funcoes.diaDaSemana(gData.DayOfWeek.ToString("d"), 1)

            'diaDaSemana += " " & gData.Day.ToString & "/" & gData.Month.ToString & "/" & gData.ToString("yy")
            diaDaSemana += " " & gData.ToString("dd/MM/yy")

            Return diaDaSemana
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function formataNascimento(gData As Date) As String
        Try
            Dim diaDaSemana As String

            diaDaSemana = " " & gData.ToString("dd/MM/yy")

            Return diaDaSemana
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function diaDaSemana(dia As Integer, tipo As Integer) As String
        Try
            Dim varDiadaSemana As String
            'If dia = 0 Then
            '    varDiadaSemana = "Dom"
            'ElseIf dia = 1 Then
            '    varDiadaSemana = "Seg"
            'ElseIf dia = 2 Then
            '    varDiadaSemana = "Ter"
            'ElseIf dia = 3 Then
            '    varDiadaSemana = "Qua"
            'ElseIf dia = 4 Then
            '    varDiadaSemana = "Qui"
            'ElseIf dia = 5 Then
            '    varDiadaSemana = "Sex"
            'ElseIf dia = 6 Then
            '    varDiadaSemana = "Sab"
            'Else
            '    varDiadaSemana = "Erro"
            'End If
            If tipo = 1 Then
                If dia = 0 Then
                    varDiadaSemana = "D"
                ElseIf dia = 1 Then
                    varDiadaSemana = "S"
                ElseIf dia = 2 Then
                    varDiadaSemana = "T"
                ElseIf dia = 3 Then
                    varDiadaSemana = "Q"
                ElseIf dia = 4 Then
                    varDiadaSemana = "Q"
                ElseIf dia = 5 Then
                    varDiadaSemana = "S"
                ElseIf dia = 6 Then
                    varDiadaSemana = "S"
                Else
                    varDiadaSemana = "Erro"
                End If
            ElseIf tipo = 2 Then
                If dia = 0 Then
                    varDiadaSemana = "Domingo"
                ElseIf dia = 1 Then
                    varDiadaSemana = "Segunda"
                ElseIf dia = 2 Then
                    varDiadaSemana = "Terça"
                ElseIf dia = 3 Then
                    varDiadaSemana = "Quarta"
                ElseIf dia = 4 Then
                    varDiadaSemana = "Quinta"
                ElseIf dia = 5 Then
                    varDiadaSemana = "Sexta"
                ElseIf dia = 6 Then
                    varDiadaSemana = "Sábado"
                Else
                    varDiadaSemana = "Erro"
                End If
            Else
                varDiadaSemana = "X"
            End If

            Return varDiadaSemana

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function funcIcone(debitoAut As Boolean, carId As Integer, alert As Boolean, valor As Double, fatura As Boolean, cor As Boolean) As String
        Try
            Dim gIcone As String
            If carId > 0 Then ' Se for cartão de crédito 
                gIcone = funcoes.icone(4, 1, False)
            ElseIf valor < 0 And fatura = True Then 'Se for estorno
                gIcone = funcoes.icone(2, 1, cor)
            ElseIf alert = True Then 'Se tiver alerta
                gIcone = funcoes.icone(3, 1, cor)
            ElseIf debitoAut = True Then 'Se for debito automatico
                gIcone = funcoes.icone(1, 1, False)
            Else
                gIcone = ""
            End If

            Return gIcone

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function icone(tipo As Integer, fatura As Boolean, cor As Boolean) As String
        Try

            If tipo = 1 Then 'Tipo 1 - Cobrança automática
                Return "fas fa-arrow-alt-circle-down"

            ElseIf tipo = 2 And fatura = True Then 'Tipo 2 - Estorno
                If cor = False Then
                    Return "fas fa-arrow-alt-circle-up"
                Else
                    Return "color: blue;"
                End If

            ElseIf tipo = 3 Then 'Tipo 3 - Alert
                If cor = False Then
                    Return "fas fa-exclamation-triangle"
                Else
                    Return "color: Tomato;"
                End If

            ElseIf tipo = 4 Then
                'Tipo 4 - Cartão de crédito
                Return "fa fa-credit-card"

            Else
                Return ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Shared Function funcTranf(conId As Object, EntradaSaida As Boolean) As String
        Try
            Dim strConta As String = ""
            If IsDBNull(conId) = False Then
                If IsNumeric(CInt(conId)) Then
                    Dim dv As System.Data.DataView = banco.consulta("select con_nome from m_conta where con_id = " & conId)
                    If dv.Count > 0 Then
                        If EntradaSaida = False Then
                            strConta = "</br>Transf para conta "
                        Else
                            strConta = "</br>Transf da conta "
                        End If
                        strConta += dv(0)("con_nome")
                    End If
                End If
            End If

            Return strConta

        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

    Public Shared Function limpaCelular(txtCelular As String) As String
        'Entra string (11) 98704-0375 e sai 11987040375
        Try
            txtCelular = Replace(txtCelular, "(", "")
            txtCelular = Replace(txtCelular, ")", "")
            txtCelular = Replace(txtCelular, "-", "")
            txtCelular = Replace(txtCelular, " ", "")

            If txtCelular Is Nothing Then txtCelular = ""

            Return txtCelular
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function formataCelular(txtCelular As String) As String
        'Entra string 11987040375 e sai (11) 98704-0375 
        Try
            If txtCelular.Length = 11 Then
                txtCelular = String.Format("({0}) {1}-{2}", txtCelular.Substring(0, 2), txtCelular.Substring(2, 5), txtCelular.Substring(7, 4))
                'txtCelular = Replace(txtCelular, "(", "")
            End If

            Return txtCelular
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ExtraiPrimeiroNome(nomeCompleto As String) As String
        ' Divide o nome completo em partes usando o espaço como separador
        Dim partes As String() = nomeCompleto.Split(" ")

        ' Retorna apenas a primeira parte, que é o primeiro nome
        Return partes(0)
    End Function

End Class

'End Namespace
