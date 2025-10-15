Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class banco

#Region "Estruturas"

    Public Structure s_conteudo
        Dim campo As ArrayList
        Dim conteudo As ArrayList
    End Structure





    'Public Structure Aula
    '    Dim idTema As Integer
    '    Dim idSlide As Integer
    '    Dim play As Boolean
    '    Dim acao As String
    '    Dim tavaTocando As Boolean
    '    Dim gratis As Boolean
    '    Dim selId As Integer
    '    Dim Legenda As Boolean
    '    Dim iniciaTema As Boolean
    'End Structure


#End Region

#Region "Caminho"

    Public Shared Function caminho() As String
        Dim ds As New DataSet
        ds.ReadXml(ado.xml)
        Dim cam As String
        cam = ds.Tables("sistema").Select("id='1'")(0).Item("banco")
        'cam = ".; initial catalog=fluxa; persist security info=False; user id=sa; password=wertyu"
        'C:\Program Files (x86)\IIS Express


        'cam = "data source=INTERNETTRADE;"
        'cam += "initial catalog=DetranMS;"
        'cam += "persist security info=False;"
        'cam += "user id=sa;"
        'cam += "password=wertyu"
        Return cam
    End Function


#End Region

#Region "Métodos Consulta"

    Public Shared Function consultaScalar(ByVal comando As String) As Object
        Dim conexao As New SqlConnection(caminho)
        Dim comando1 As New SqlCommand("", conexao)
        Try
            comando1.CommandText = comando
            conexao.Open()
            If IsDBNull(comando1.ExecuteScalar) Then
                Return 0
            End If
            Return comando1.ExecuteScalar
        Catch ex As Exception
            Throw ex
        Finally
            conexao.Close()
        End Try
    End Function


    Public Shared Function consulta(ByVal tabela As String, ByVal ordem As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "select * from " + tabela + " order by " + ordem
            Dim da As New SqlDataAdapter(comando)
            Dim ds As New DataSet
            Dim dv As New DataView
            da.Fill(ds, "tabela")
            dv = ds.Tables("tabela").DefaultView
            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function consulta(ByVal comando As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando1 As New SqlCommand("", conexao)
        Try
            comando1.CommandText = comando
            Dim da As New SqlDataAdapter(comando1)
            Dim ds As New DataSet
            Dim dv As New DataView
            da.Fill(ds, "tabela")
            dv = ds.Tables("tabela").DefaultView
            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function consulta(ByVal tabelaMaster As String, ByVal campoIdMaster As String, ByVal conteudoIdDetail As String, ByVal campoTelaMaster As String) As String
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            Dim conteudo As String = "0"
            comando.CommandText = "select " + campoTelaMaster + " from " + tabelaMaster + " where " + campoIdMaster + " = '" + conteudoIdDetail + "'"
            conexao.Open()
            If IsDBNull(comando.ExecuteScalar) Then
                conteudo = ""
            Else
                conteudo = comando.ExecuteScalar
            End If
            conexao.Close()
            Return conteudo
        Catch z As Exception
            Throw z
        Finally
            conexao.Close()
        End Try
    End Function

    Public Shared Function consulta(ByVal comando As String, ByVal pag_atual As Integer, ByVal registros_por_pagina As Integer) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando1 As New SqlCommand("", conexao)
        Try
            comando1.CommandText = comando
            Dim da As New SqlDataAdapter(comando1)
            Dim ds As New DataSet
            Dim dv As New DataView
            da.Fill(ds, pag_atual, registros_por_pagina, "tabela")
            dv = ds.Tables("tabela").DefaultView
            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function




#End Region

#Region "Métodos Executar"

    Public Shared Sub executa(ByVal comando As String)
        Dim conexao As New SqlConnection(caminho)
        Dim commando As New SqlCommand(comando, conexao)
        Try
            conexao.Open()
            commando.ExecuteNonQuery()
            conexao.Close()
        Catch ex As Exception
            Throw ex
        Finally
            If conexao.State = ConnectionState.Open Then
                conexao.Close()
            Else
                conexao.Dispose()
            End If
        End Try
    End Sub

#End Region

#Region "Métodos Senha"

    Public Shared Function consultaSenha(ByVal strLogin As String, ByVal strSenha As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            strSenha = criptografaSenha(strSenha)

            comando.CommandText = "select * from usuario where usu_login='" + strLogin + "' and usu_senha='" + strSenha + "'"
            Dim da As New SqlDataAdapter(comando)
            Dim ds As New DataSet()
            Dim dv As New DataView()
            da.Fill(ds, "tabela")
            dv = ds.Tables("tabela").DefaultView
            Return dv
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

    Public Shared Function criptografaSenha(ByVal Mensagem As String) As String
        'A documentação oficial (RFC1321) do algoritmo MD5 pode ser encontrada em http://
        'Estamos utilizando a implementação oferecida pelo .Net FrameWork da Microsoft

        Dim MD As New MD5CryptoServiceProvider()
        Return BitConverter.ToString(MD.ComputeHash(New ASCIIEncoding().GetBytes(Mensagem)))

    End Function

#End Region

#Region "Métodos Combo"

    'simples
    Public Shared Function carregaCombo(ByVal tabela As String, ByVal id As String, ByVal texto As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Dim ds As New DataSet()

        Try
            comando.CommandText = "select " + id + " as 'value' , " + texto + " as 'text' from " + tabela + " order by " + texto
            Dim da As New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds, "x")
            Return ds.Tables("x").DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Relacionado
    Public Shared Function carregaCombo(ByVal tbDetail As String, ByVal idDetail As String, ByVal textoDetail As String, ByVal campoRelacionamento As String, ByVal valorRelacionamento As Integer) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Dim ds As New DataSet()
        Try
            comando.CommandText = "select " + idDetail + " as 'value' , " + textoDetail + " as 'text' from " + tbDetail + " where " + campoRelacionamento + " = " + valorRelacionamento.ToString + " order by " + textoDetail
            Dim da As New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds, "x")
            Return ds.Tables("x").DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function carregaCombo(ByVal tbDetail As String, ByVal idDetail As String, ByVal textoDetail As String, ByVal campoRelacionamento As String, ByVal valorRelacionamento As Integer, ByVal orderby As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Dim ds As New DataSet
        Try
            comando.CommandText = "select " + idDetail + " as 'value' , " + textoDetail + " as 'text' from " + tbDetail + " where " + campoRelacionamento + " = " + valorRelacionamento.ToString + " order by " + orderby
            Dim da As New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds, "x")
            Return ds.Tables("x").DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'com condicao
    Public Shared Function carregaCombo(ByVal tabela As String, ByVal id As String, ByVal texto As String, ByVal where As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Dim ds As New DataSet
        Try
            comando.CommandText = "select " + id + " as 'value' , " + texto + " as 'text' from " + tabela + " where " + where + " order by " + texto
            Dim da As New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds, "x")
            Return ds.Tables("x").DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'com condicao
    Public Shared Function carregaCombo(ByVal tabela As String, ByVal id As String, ByVal texto As String, ByVal where As String, ByVal ordem As String) As DataView
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Dim ds As New DataSet
        Try
            comando.CommandText = "select " + id + " as 'value' , " + texto + " as 'text' from " + tabela + " where " + where + " order by " + ordem
            Dim da As New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds, "x")
            Return ds.Tables("x").DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Métodos Cadastro"

    Public Shared Sub incluir(ByVal tabela As String, ByVal conteudo As s_conteudo)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "insert into " + tabela + " ( "
            Dim f As Integer
            For f = 0 To conteudo.campo.Count - 1
                comando.CommandText += conteudo.campo.Item(f)
                If f < conteudo.campo.Count - 1 Then
                    comando.CommandText += " , "
                Else
                    comando.CommandText += " ) values ( "
                End If
            Next
            For f = 0 To conteudo.conteudo.Count - 1
                comando.CommandText += "'" + conteudo.conteudo.Item(f) + "'"
                If f < conteudo.campo.Count - 1 Then
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

    Public Shared Sub excluir(ByVal tabela As String, ByVal where As String, ByVal id As String)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "delete from " + tabela + " where " + where + "'" + id + "'"
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

    Public Shared Sub alterar(ByVal tabela As String, ByVal conteudo As s_conteudo, ByVal nomeId As String, ByVal valorId As Integer)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "update " + tabela + " set "
            Dim f As Integer
            For f = 0 To conteudo.campo.Count - 1
                comando.CommandText += conteudo.campo.Item(f)
                comando.CommandText += " = "
                comando.CommandText += "'" + conteudo.conteudo.Item(f) + "'"
                If f < conteudo.campo.Count - 1 Then
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

    Public Shared Sub alterar(ByVal tabela As String, ByVal conteudo As s_conteudo, ByVal nomeId As String, ByVal valorId As String)
        Dim conexao As New SqlConnection(caminho)
        Dim comando As New SqlCommand("", conexao)
        Try
            comando.CommandText = "update " + tabela + " set "
            Dim f As Integer
            For f = 0 To conteudo.campo.Count - 1
                comando.CommandText += conteudo.campo.Item(f)
                comando.CommandText += " = "
                comando.CommandText += "'" + conteudo.conteudo.Item(f) + "'"
                If f < conteudo.campo.Count - 1 Then
                    comando.CommandText += " , "
                End If
            Next
            comando.CommandText += " where " + nomeId + " = '" + valorId + "'"
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

#End Region

    Public Shared Sub executaProcedureCliIdNoCupom(CliId As String, cpf As String)
        Try
            executa("update cupom set cli_id = " & CliId & " where cup_cpf = '" & cpf & "' and cli_id is null")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
