Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Mail

Public Class ado


    Public Shared Function xml() As String
        ' Return "C:\Inetpub\wwwroot\Natal.xml"
        Return "C:\Inetpub\wwwroot\XML\Natal.xml"
        'Return "torra.xml"
        'Return "pw_dev.xml"
    End Function

    Public Shared Function caminho() As String
        Dim varCaminho As String = banco.caminho()
        Return varCaminho
        'Return "data source=.;initial catalog=PalestraWeb04;persist security info=False;user id=sa; password=wertyu;"
        'Return "data source=.;initial catalog=Raspadinha;persist security info=False;user id=sa; password=wertyu;"
        'Return "data source=ec2-3-137-191-244.us-east-2.compute.amazonaws.com; initial catalog=Raspadinha; persist security info=False; user id=sa; password=wertyu"

    End Function

    Public Shared Sub incluir(ByVal tabela As String, ByVal campo As ArrayList, ByVal conteudo As ArrayList)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "insert into " + tabela + " ( "
            Dim f As Integer
            For f = 0 To campo.Count - 1
                comando.CommandText += campo.Item(f)
                If f < campo.Count - 1 Then
                    comando.CommandText += " , "
                Else
                    comando.CommandText += " ) values ( "
                End If
            Next
            For f = 0 To conteudo.Count - 1
                comando.CommandText += "'" + conteudo.Item(f) + "'"
                If f < campo.Count - 1 Then
                    comando.CommandText += " , "
                Else
                    comando.CommandText += " ) "
                End If
            Next
            conexao.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Dim a As String = ex.Message
            Throw ex
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Sub

    Public Shared Function ValidaMail(ByVal StrMail As String) As Boolean
        ' Função que verifica validação de preenchimento de E-Mail.

        ' Se há espaço vazio, então...
        If InStr(1, StrMail, " ") > 0 Then
            ValidaMail = False
            Exit Function
        End If

        ' Verifica tamanho da String, pois o menor endereço válido é x@x.xx.
        If Len(FncStrSpace(StrMail)) < 6 Then
            ValidaMail = False
            Exit Function
        End If
        ' Verifica se se há um "@" no endereço.
        If InStr(FncStrSpace(StrMail), "@") = 0 Then
            ValidaMail = False
            Exit Function
        End If
        ' Verifica se há um "." no endereço.
        If InStr(FncStrSpace(StrMail), ".") = 0 Then
            ValidaMail = False
            Exit Function
        End If
        ' Verifica se há a quantidade mínima de caracteres é igual ou maior que 3.
        If Len(FncStrSpace(StrMail)) - InStrRev(FncStrSpace(StrMail), ".") > 3 Then
            ValidaMail = False
            Exit Function
        End If

        ' Verifica se há "_" após o "@".
        If InStr(FncStrSpace(StrMail), "_") <> 0 And InStrRev(StrMail, "_") > InStrRev(FncStrSpace(StrMail), "@") Then
            ValidaMail = False
            Exit Function
        Else
            Dim IntCounter
            Dim IntF
            IntCounter = 0
            For IntF = 1 To Len(FncStrSpace(StrMail))
                If Mid(StrMail, IntF, 1) = "@" Then
                    IntCounter = IntCounter + 1
                End If
            Next
            If IntCounter > 1 Then
                ValidaMail = True
            End If
            ' Valida cada caracter do endereço.
            IntF = 0
            For IntF = 1 To Len(FncStrSpace(StrMail))
                If IsNumeric(Mid(FncStrSpace(StrMail), IntF, 1)) = False And
                    (LCase(Mid(FncStrSpace(StrMail), IntF, 1)) < "a" Or
                    LCase(Mid(FncStrSpace(StrMail), IntF, 1)) > "z") And
                    Mid(FncStrSpace(StrMail), IntF, 1) <> "_" And
                    Mid(FncStrSpace(StrMail), IntF, 1) <> "." And
                    Mid(FncStrSpace(StrMail), IntF, 1) <> "-" Then
                    ValidaMail = True
                End If
            Next
        End If

        ' Verifica se o email está no formato básico de sintaxe
        If Not Regex.IsMatch(StrMail, "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$") Then
            ValidaMail = False
            Exit Function
        End If

        ' Lista de domínios que FINALIZA com isso
        Dim invalidEndings As String() = {"@com", "@org", "@gov", "@com.br", ".cm", ".be", ".cpm", ".cpm.br", ".om", ".om.br", ".cim", ".cim.br", ".vom", ".vom.br", ".vr", ".xom", ".xom.br", ".comm", ".comm.br", ".ccom", ".ccom.br", ".cok", ".cok.br", ".com.", ".", ".bt", ".con", ".con.br", ".bf", "@bol.com", ".com.com", ".co.com"}

        For Each ending In invalidEndings ' Verifica se o email termina com um dos domínios indesejados
            If StrMail.ToLower().EndsWith(ending) Then
                Return False
            End If
        Next

        ' Lista de caracteres que CONTÉM strings abaixo
        Dim invalidContains As String() = {"@.", ".@", "...", "..", "@@", ".cm", ".cm."}

        For Each contains In invalidContains ' Verifica se o email CONTÉM um dos domínios indesejados
            If StrMail.ToLower().Contains(contains) Then
                Return False
            End If
        Next

        ' Lista de dominios proibidos
        Dim invalidDomains As String() = {"@hotmail.com.br", "@hotamil", "@gmail.com.br", "@gamil.", "@gmal.c", "@gamail.c", "@gmai.c", "@gmai.c", "@gail.com", "@gmali.c", "@gml.c", "@gmil.c", "@gnail.c", "@gmaill.c", "@gmial.c", "@gmeil.c", "@gmal.c", "@gmsil.c", "@g.mail.c", "@gimail.c", "@homail.c", "@rotimail.c", "@hot.mail.c", "@gotmail.c", "@hotmai.c", "hotimail.c", "@hormail.c", "@hotmal.c", "@htmail.c", "@hotmil.c", "@hotmsil.c", "@rotmail.c", "@hitmail.c", "@hmail.c", "@hotmailc", "@hotnail.c", "@ymail.c", "@gamail.c", "@yhaoo.c", "@gma.c", "@iclod.c", "gemail.c", "@hotamail.c", "gmaim.c", "gmaol.c", "hotma.c", "hotmmail.c", "iclou.c", "outlok.c", "yahooo.c", "gmaul.c", "gmel.c", "gmqil.c", "hotemail.c", "outloo.c", "yahho.c", "yaoo.c", "25gmail.c", "jmail.c", "gami.c", "gmauil.c", "hotmaill.c", "@otmail.c", "@hotmaim", "@hotail.c"}

        ' Verifica se o email termina com um dos domínios indesejados
        For Each domains In invalidDomains
            If StrMail.ToLower().Contains(domains) Then
                Return False
            End If
        Next

        ' Verifica se o email termina com ".com.br" e sem nada após
        If StrMail.ToLower().Contains(".com.br") AndAlso StrMail.Length <> StrMail.LastIndexOf(".com.br") + 7 Then
            Return False
        End If

        Return ValidaMail

    End Function

    Public Shared Function FncStrSpace(ByVal StrAddress)
        ' Reduz os espaços em branco.
        FncStrSpace = Trim(LTrim(RTrim(StrAddress)))
    End Function

    Public Shared Function verificaSeTemCaractereEspecial(str As String) As Boolean
        Try
            If str.Contains("'") Then Return False
            If str.Contains("""") Then Return False
            If str.Contains("!") Then Return False
            If str.Contains("@") Then Return False
            If str.Contains("#") Then Return False
            If str.Contains("$") Then Return False
            If str.Contains("%") Then Return False
            If str.Contains("¨") Then Return False
            If str.Contains("&") Then Return False
            If str.Contains("*") Then Return False
            If str.Contains("(") Then Return False
            If str.Contains(")") Then Return False
            If str.Contains("-") Then Return False
            If str.Contains("_") Then Return False
            If str.Contains("+") Then Return False
            If str.Contains(".") Then Return False
            If str.Contains(",") Then Return False
            If str.Contains("=") Then Return False
            If str.Contains("{") Then Return False
            If str.Contains("}") Then Return False
            If str.Contains("[") Then Return False
            If str.Contains("]") Then Return False
            If str.Contains("/") Then Return False
            If str.Contains("?") Then Return False
            If str.Contains("º") Then Return False
            If str.Contains("|") Then Return False
            If str.Contains("\") Then Return False
            If str.Contains(">") Then Return False
            If str.Contains("<") Then Return False
            If str.Contains("§") Then Return False
            If str.Contains("¬") Then Return False
            If str.Contains("£") Then Return False
            If str.Contains("¢") Then Return False

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Sub excluir(ByVal tabela As String, ByVal where As String, ByVal id As Integer)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "delete from " + tabela + " where " + where + " = " + CStr(id)
            conexao.Open()
            comando.ExecuteNonQuery()
        Catch z As Exception
            Dim a As String = z.Message
            Throw z
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Sub

    Public Shared Sub alterar(ByVal tabela As String, ByVal campo As ArrayList, ByVal conteudo As ArrayList, ByVal nomeId As String, ByVal valorId As Integer)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "update " + tabela + " set "
            Dim f As Integer
            For f = 0 To campo.Count - 1
                comando.CommandText += campo.Item(f)
                comando.CommandText += " = "
                If conteudo.Item(f) <> "isdbnull" Then
                    comando.CommandText += "'" + conteudo.Item(f) + "'"
                Else
                    comando.CommandText += " null "
                End If
                If f < campo.Count - 1 Then
                    comando.CommandText += " , "
                End If
            Next
            comando.CommandText += " where " + nomeId + " = " + CStr(valorId)
            conexao.Open()
            comando.ExecuteNonQuery()
        Catch z As Exception
            Dim a As String = z.Message
            Throw z
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Sub

    Public Shared Sub alterarIdString(ByVal tabela As String, ByVal campo As ArrayList, ByVal conteudo As ArrayList, ByVal nomeId As String, ByVal valorId As String)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "update " + tabela + " set "
            Dim f As Integer
            For f = 0 To campo.Count - 1
                comando.CommandText += campo.Item(f)
                comando.CommandText += " = "
                If conteudo.Item(f) <> "isdbnull" Then
                    comando.CommandText += "'" + conteudo.Item(f) + "'"
                Else
                    comando.CommandText += " null "
                End If
                If f < campo.Count - 1 Then
                    comando.CommandText += " , "
                End If
            Next
            comando.CommandText += " where " + nomeId + " = '" + CStr(valorId) + "'"
            conexao.Open()
            comando.ExecuteNonQuery()
        Catch z As Exception
            Dim a As String = z.Message
            Throw z
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Sub

    Public Shared Function ConsultaSQL(ByVal comandoSQL As String, Optional ByVal qtdCampos As Integer = 2) As ArrayList()
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            Dim arr(qtdCampos - 1) As ArrayList
            Dim dr As SqlDataReader
            arr(0) = New ArrayList()
            arr(1) = New ArrayList()

            If qtdCampos = 3 Then
                arr(qtdCampos - 1) = New ArrayList()
            End If


            comando.CommandText = comandoSQL
            conexao.Open()
            dr = comando.ExecuteReader
            While dr.Read
                arr(0).Add(dr(0))
                arr(1).Add(dr(1))
                If qtdCampos = 3 Then
                    arr(qtdCampos - 1).Add(dr(qtdCampos - 1))
                End If
            End While
            dr.Close()
            Return arr
        Catch ex As Exception
            Throw ex
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Function

    Public Shared Function ConsultaSQL2(ByVal comandoSQL As String) As ArrayList()
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            Dim arr(2) As ArrayList
            Dim dr As SqlDataReader
            arr(0) = New ArrayList()
            arr(1) = New ArrayList()
            arr(2) = New ArrayList()
            comando.CommandText = comandoSQL
            conexao.Open()
            dr = comando.ExecuteReader
            While dr.Read
                arr(0).Add(dr(0))
                arr(1).Add(dr(1))
                arr(2).Add(dr(2))
            End While
            dr.Close()
            Return arr
        Catch ex As Exception
            Throw ex
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Function


    Function FuncMontaPalavraParaMenuDaPaginaPrincipal(ByVal StrPalavraDoMenu As String, ByVal IntNumeroCaracteres As Integer) As String
        If (StrPalavraDoMenu.Length > IntNumeroCaracteres - 1) Then

            Dim IntCV As Integer = 0
            Dim IntConta As Integer = 0
            Dim StrAux = StrPalavraDoMenu
            StrPalavraDoMenu = ""
            Dim BooTestaPalavra As Boolean = False

            For IntCV = 0 To StrAux.Length - 1
                IntConta = IntConta + 1
                StrPalavraDoMenu += StrAux.Substring(IntCV, 1)
                If IntConta <= IntNumeroCaracteres - 1 And StrPalavraDoMenu.Substring(IntCV).Equals(" ") Then
                    BooTestaPalavra = True
                    IntConta = 0
                ElseIf IntConta > IntNumeroCaracteres Then
                    BooTestaPalavra = False
                    Exit For
                End If
            Next
            If Not BooTestaPalavra Then
                StrPalavraDoMenu = ""
                IntConta = 0
                For IntCV = 0 To StrAux.Length - 1
                    IntConta = IntConta + 1
                    If IntConta < IntNumeroCaracteres - 1 Then
                        If Not StrAux.Substring(IntCV, 1).Equals(" ") Then
                            StrPalavraDoMenu += StrAux.Substring(IntCV, 1)
                        Else
                            StrPalavraDoMenu += StrAux.Substring(IntCV, 1)
                        End If
                    Else
                        StrPalavraDoMenu += StrAux.Substring(IntCV, 1) + " "
                        IntConta = 0
                    End If
                Next
            End If

        End If
        Return StrPalavraDoMenu
    End Function



    Public Shared Function SelecionarDS(ByVal QueryText As String) As DataSet
        Dim conexao As New SqlConnection(ado.caminho)
        Try
            Dim comando As New SqlCommand(QueryText, conexao)
            Dim da As New SqlDataAdapter(comando)
            Dim ds As New DataSet()
            conexao.Open()
            da.Fill(ds)
            'conexao.Close()
            Return ds
        Catch Ex As Exception
            Dim a As String = Ex.Message
            Throw Ex
        Finally
            conexao.Close()
        End Try
    End Function




    Public Shared Function dsAdapterPaging(ByVal QueryText As String, ByVal NomeTabela As String, ByVal intCurr As Integer, ByVal intPageSize As Integer) As DataSet
        Dim conexao As New SqlConnection(ado.caminho)
        Try
            Dim comando As New SqlCommand(QueryText, conexao)
            Dim da As New SqlDataAdapter(comando)
            Dim ds As New DataSet()

            conexao.Open()
            da.Fill(ds, intCurr, intPageSize, NomeTabela)
            'conexao.Close()
            Return ds
        Catch Ex As Exception
            Dim a As String = Ex.Message
            Throw Ex
        Finally
            conexao.Close()
        End Try
    End Function

    Public Shared Function erroGeral(ByVal msg As String, Optional Tipo As Boolean = False, Optional ajax As Boolean = False)
        msg = Replace(msg, """", " ")
        msg = Replace(msg, "'", " ")
        Dim titulo, icon, script As String

        If Tipo = False Then
            titulo = "ATENÇÃO"
            icon = "error"
        Else
            titulo = "SUCESSO"
            icon = "success"
        End If

        If ajax = True Then
            script = "Swal.fire({title: '" & titulo & "!',text: '" + msg + ".',icon: '" & icon & "',confirmButtonText: 'Fechar'});"
        Else
            script = "<script>Swal.fire({title: '" & titulo & "!',text: '" + msg + ".',icon: '" & icon & "',confirmButtonText: 'Fechar'});</script>"
        End If



        Return script

        ' Return "<script>window.alert('" + msg + ".'); </script>"
        'Return "<script>Swal.fire({title: 'Good job!',text: '" + msg + ".',icon: 'success',confirmButtonText: 'Fechar'});</script>"
        ' Return "<script>Swal.fire({title: 'Raspe & Ganhe',text: '" + msg + ".',icon: 'error',confirmButtonText: 'Fechar'});</script>"
    End Function

    Public Shared Sub EnviaEmail(ByVal para As String, ByVal titulo As String, ByVal corpo As String)
        Try
            Dim varFromNome As String
            Dim varFromEmail As String
            Dim varSmtp As String
            Dim varUrl As String
            Dim varNomeSistema As String
            Dim varEmpresa As String

            Dim ds As New DataSet()
            ds.ReadXml(ado.xml)
            If ds.Tables("email").Select("id='1'")(0).Item("FromNome") = "" Then
                varFromNome = ""
            Else
                varFromNome = "[" + ds.Tables("email").Select("id='1'")(0).Item("FromNome") + "]"
            End If
            varFromEmail = ds.Tables("email").Select("id='1'")(0).Item("FromEmail")
            varSmtp = ds.Tables("email").Select("id='1'")(0).Item("smtp")
            varUrl = ds.Tables("sistema").Select("id='1'")(0).Item("url")
            varNomeSistema = ds.Tables("sistema").Select("id='1'")(0).Item("nome")
            varEmpresa = ds.Tables("sistema").Select("id='1'")(0).Item("empresa")
            Dim email As New MailMessage
            With email
                .From = varFromNome & varFromEmail
                .To = para
                .Subject = titulo
                .Body = corpo
                .BodyFormat = MailFormat.Html
                .Priority = MailPriority.Normal
            End With
            SmtpMail.SmtpServer = varSmtp
            SmtpMail.Send(email)
        Catch Ex As Exception
            Throw Ex
        End Try
    End Sub

    Public Shared Function formataData(ByVal data As Date)
        Try
            Dim dia As String
            Dim mes As String
            Dim ano As String
            dia = Day(data)
            mes = Month(data)
            ano = Year(data)
            If CInt(dia) < 10 Then dia = "0" + dia
            If CInt(mes) < 10 Then mes = "0" + mes
            Return dia + "/" + mes + "/" + ano
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function formataSegundoEmHora(ByVal segundos As Integer)
        Try
            Dim zeroSeg As String = ""
            Dim zeroMin As String = ""
            Dim zeroHor As String = ""
            If segundos < 60 Then
                If segundos < 10 Then zeroSeg = "0"
                Return "00:00:" + zeroSeg + segundos.ToString
            ElseIf segundos >= 60 And segundos < 3600 Then
                Dim varMinutos As Integer = Int(segundos / 60)
                Dim varSegundos As Integer = segundos Mod 60
                If varMinutos < 10 Then zeroMin = "0"
                If varSegundos < 10 Then zeroSeg = "0"
                Return "00:" + zeroMin + varMinutos.ToString + ":" + zeroSeg + varSegundos.ToString
            Else
                Dim varHoras As Integer = segundos / 3600
                Dim varminutos As Integer = (segundos Mod 3600) / 60
                Dim varSegundos As Integer = (segundos Mod 3600) Mod 60
                If varHoras < 10 Then zeroHor = "0"
                If varminutos < 10 Then zeroMin = "0"
                If varSegundos < 10 Then zeroSeg = "0"
                Return zeroHor + varHoras.ToString + ":" + zeroMin + varminutos.ToString + ":" + zeroSeg + varSegundos.ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function VerificaArquivo(ByVal nomeDoArquivo As String, ByVal extensaoDoArquivo As String, ByVal extensaoDeveSer As String)
        Try
            If nomeDoArquivo = "" Then
                Throw New Exception("O arquivo precisa de um nome")
            End If

            Dim xx As String = nomeDoArquivo
            Dim z As Integer = xx.Length
            Dim a As Integer
            For a = 0 To z - 1
                If xx.Chars(a) = " " Then
                    Throw New Exception("O arquivo SWF não pode conter espaços...")
                End If
            Next

            If extensaoDoArquivo <> extensaoDeveSer Then
                Throw New Exception("O arquivo não possui extensão " + extensaoDeveSer + ". Por favor selecione um arquivo com extensão " + extensaoDeveSer)
            End If
            Return ""

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function TrataData(ByVal pData As String) As String
        Try
            If Not pData = String.Empty Then
                Dim dt() As String = Split(pData, "/", 3)
                Return dt(2) & "-" & dt(1) & "-" & dt(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub LimpaCampos(ByVal pControle As Control)
        Dim ctl As Control
        For Each ctl In pControle.Controls
            If TypeOf ctl Is TextBox Then
                DirectCast(ctl, TextBox).Text = String.Empty
            ElseIf TypeOf ctl Is DropDownList Then
                DirectCast(ctl, DropDownList).SelectedIndex = 0
            ElseIf TypeOf ctl Is CheckBox Then
                DirectCast(ctl, CheckBox).Checked = False
            End If
        Next
    End Sub

    Public Shared Function TransformaHoraEmSegundos(ByVal strHHMMSS As String) As Integer
        Try
            Dim strHoras() As String = Split(strHHMMSS, ":", 3) 'strHHMMSS.Split(":", 3)
            Return (Convert.ToInt32(strHoras(0)) * 3600) + (Convert.ToInt32(strHoras(1)) * 60) + Convert.ToInt32(strHoras(2))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Shared Sub incluir2(ByVal tabela As String, ByVal campo As ArrayList, ByVal conteudo As ArrayList)
    '    Dim conexao As New SqlConnection(caminho)
    '    Dim comando As New SqlCommand("", conexao)
    '    Try
    '        comando.CommandText = "insert into " + tabela + " ( "
    '        Dim f As Integer
    '        For f = 0 To campo.Count - 1
    '            comando.CommandText += campo.Item(f)
    '            If f < campo.Count - 1 Then
    '                comando.CommandText += " , "
    '            Else
    '                comando.CommandText += " ) values ( "
    '            End If
    '        Next
    '        For f = 0 To conteudo.Count - 1
    '            If conteudo.Item(f) = "<null>" Or conteudo.Item(f) = "isdbnull" Then
    '                comando.CommandText += "null"
    '            Else
    '                comando.CommandText += "'" + conteudo.Item(f) + "'"
    '            End If
    '            If f < campo.Count - 1 Then
    '                comando.CommandText += " , "
    '            Else
    '                comando.CommandText += " ) "
    '            End If
    '        Next
    '        'HttpContext.Current.Response.Write(comando.CommandText & "<br>")
    '        conexao.Open()
    '        comando.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Dim a As String = ex.Message
    '        Throw ex
    '    Finally
    '        If conexao.State = ConnectionState.Open Then
    '            conexao.Close()
    '        Else
    '            conexao.Dispose()
    '        End If
    '    End Try
    'End Sub
    '-----------------------------------------------------------------
    ' Overload implementado por Lucas Henrique Vicente
    ' permite passar varios campos e seus valores na clausula where
    '--------------------------------------------------
    Public Shared Sub alterar(ByVal tabela As String,
                                  ByVal campo As ArrayList,
                                  ByVal conteudo As ArrayList,
                                  ByVal campochave As ArrayList,
                                  ByVal valorchave As ArrayList)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "update " + tabela + " set "
            Dim f As Integer
            For f = 0 To campo.Count - 1
                comando.CommandText += campo.Item(f)
                comando.CommandText += " = "
                If conteudo.Item(f) <> "isdbnull" Then
                    comando.CommandText += "'" + conteudo.Item(f) + "'"
                Else
                    comando.CommandText += " null "
                End If
                If f < campo.Count - 1 Then
                    comando.CommandText += " , "
                End If
            Next
            comando.CommandText += " where "
            For f = 0 To campochave.Count - 1
                comando.CommandText += campochave.Item(f) + " = '" + Convert.ToString(valorchave.Item(f)) + "'"
                If f < campochave.Count - 1 Then
                    comando.CommandText += " and "
                End If
            Next
            conexao.Open()
            comando.ExecuteNonQuery()
        Catch z As Exception
            Dim a As String = z.Message
            Throw z
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Sub

End Class
