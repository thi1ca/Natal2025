Public Class container

    Structure estrutura
        Dim contador As String
        Dim comando As String
        Dim pagina_atual As Integer
        Dim registros_por_pagina As Integer
        Dim btn_primeiro As Boolean
        Dim btn_anterior As Boolean
        Dim btn_proximo As Boolean
        Dim btn_ultimo As Boolean
        Dim qtd_paginas As Integer
        Dim total As Integer
    End Structure

    Public Shared Function gerar(ByRef rpt As Repeater, ByVal es As estrutura) As estrutura
        Try
            Dim dv As New DataView()
            es.total = banco.consultaScalar(es.contador)
            dv = banco.consulta(es.comando, (es.pagina_atual - 1) * es.registros_por_pagina, es.registros_por_pagina) '* es.pagina_atual)
            rpt.DataSource = dv
            rpt.DataBind()
            Dim x As Decimal
            Dim x1 As Integer
            x = es.total / es.registros_por_pagina
            x1 = Decimal.Truncate(x)
            If x > x1 Then
                x1 += 1
            End If
            es.qtd_paginas = x1
            If es.pagina_atual = 1 Then
                es.btn_anterior = False
                es.btn_primeiro = False
            Else
                es.btn_anterior = True
                es.btn_primeiro = True
            End If
            If es.pagina_atual = es.qtd_paginas Then
                es.btn_proximo = False
                es.btn_ultimo = False
            Else
                es.btn_proximo = True
                es.btn_ultimo = True
            End If
            If es.total = 0 Then
                es.btn_anterior = False
                es.btn_primeiro = False
                es.btn_proximo = False
                es.btn_ultimo = False
                es.pagina_atual = 0
            End If
            Return es
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Shared Function primeiro(ByRef rpt As Repeater, ByVal es As estrutura) As estrutura
        Try
            es.pagina_atual = 1
            es = container.gerar(rpt, es)
            Return es
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function anterior(ByRef rpt As Repeater, ByVal es As estrutura) As estrutura
        Try
            es.pagina_atual -= 1
            es = container.gerar(rpt, es)
            Return es
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function proximo(ByRef rpt As Repeater, ByVal es As estrutura) As estrutura
        Try
            es.pagina_atual += 1
            es = container.gerar(rpt, es)
            Return es
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function ultimo(ByRef rpt As Repeater, ByVal es As estrutura) As estrutura
        Try
            es.pagina_atual = es.qtd_paginas
            es = container.gerar(rpt, es)
            Return es
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
