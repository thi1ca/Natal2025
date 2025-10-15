Public Class teste
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        labscript.Visible = False
        labscript.Text = ""
    End Sub

    Protected Sub butWhatsapp_Click(sender As Object, e As EventArgs) Handles butWhatsapp.Click
        Try

            Dim msg As String = "Teste whatsapp. " & vbCrLf
            msg += " Blablabla " & vbCrLf & vbCrLf
            msg += "Raspadinha torra."

            whatsapp.mensagem(tbValor.Text, msg)
        Catch ex As Exception
            labscript.Text = ado.erroGeral(ex.Message)
            labscript.Visible = True
        End Try
    End Sub

    Private Sub montaPergunta3()
        Try
            '2 - Ver qual a data da última compra
            Dim cupomQtdPecas As Integer = tbValor.Text

            'Randomizar as datas
            Dim valorMinimo1, valorMaximo1, valorMinimo2, valorMaximo2 As Integer


            If cupomQtdPecas = 1 Then
                valorMinimo1 = 2
                valorMaximo1 = 3
                valorMinimo2 = 4
                valorMaximo2 = 6
            ElseIf cupomQtdPecas > 1 And cupomQtdPecas < 4 Then
                '2 ou 3 peças
                valorMinimo1 = 1
                valorMaximo1 = 1
                valorMinimo2 = 3
                valorMaximo2 = 6
            ElseIf cupomQtdPecas > 3 And cupomQtdPecas < 6 Then
                '4 ou 5 peças
                valorMinimo1 = 1
                valorMaximo1 = 1
                valorMinimo2 = 2
                valorMaximo2 = 3
            Else 'acima de 6 peças
                valorMinimo1 = 1
                valorMaximo1 = 2
                valorMinimo2 = 3
                valorMaximo2 = 5
            End If


            Dim rnd As New Random()
            Dim randomPecas As Integer = rnd.Next(valorMinimo1, valorMaximo1 + 1) ' The upper bound is exclusive, so use 8 instead of 7
            Dim randomPecas2 As Integer = rnd.Next(valorMinimo2, valorMaximo2 + 1) ' The upper bound is exclusive, so use 8 instead of 7


            Dim qtdArray As Double() = {cupomQtdPecas, randomPecas, randomPecas2}

            ' Sort the array in ascending order
            Array.Sort(qtdArray)

            labResposta1.Text = qtdArray(0).ToString
            labResposta2.Text = qtdArray(1).ToString
            labResposta3.Text = qtdArray(2).ToString


            labCorreto.Text = cupomQtdPecas.ToString


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function sorteiaAddDays(dataReferencia As Date, numeroProibido As String) As Integer
        Try

            Dim diffDatacompraDataHoje As Integer = (Date.Today - dataReferencia).Days

            'Randomizar as datas
            Dim DataMinimo, DataMaximo As Double

            If numeroProibido = "" Then
                If diffDatacompraDataHoje < 7 Then
                    DataMinimo = -14
                    DataMaximo = -7
                ElseIf diffDatacompraDataHoje > 40 Then
                    DataMinimo = 33
                    DataMaximo = 38
                ElseIf diffDatacompraDataHoje > 40 And diffDatacompraDataHoje < 20 Then
                    DataMinimo = 15
                    DataMaximo = 7
                Else 'cupomValor > 20 And cupomValor < 5 Then
                    DataMinimo = 2
                    DataMaximo = 5
                End If
            Else
                If diffDatacompraDataHoje < 7 Then
                    DataMinimo = -27
                    DataMaximo = -20
                ElseIf diffDatacompraDataHoje > 40 Then
                    DataMinimo = 20
                    DataMaximo = 27
                ElseIf diffDatacompraDataHoje > 40 And diffDatacompraDataHoje < 20 Then
                    DataMinimo = -7
                    DataMaximo = -2
                Else 'cupomValor > 20 And cupomValor < 5 Then
                    DataMinimo = -14
                    DataMaximo = -7
                End If
            End If

            'VB.NET code to pick a random number between an interval (-34 And 7)
            Dim rnd As New Random()
            Dim randomNumber As Integer = rnd.Next(DataMinimo, DataMaximo) ' The upper bound is exclusive, so use 8 instead of 7
            If numeroProibido = "" Then
                Return randomNumber
            Else
                If CInt(numeroProibido) <> randomNumber Then
                    Return randomNumber
                Else
                    Return randomNumber - 7
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub butSimular_Click(sender As Object, e As EventArgs) Handles butSimular.Click



        Dim cupomData As Date = tbValor.Text

        'Randomizar as datas
        Dim specificDate As Date = New Date(Year(cupomData), Month(cupomData), Day(cupomData))

        ' Add ramdom days to the specific date
        Dim qtdDias1 As Integer = sorteiaAddDays(specificDate, "")
        Dim qtdDias2 As Integer = sorteiaAddDays(specificDate, qtdDias1.ToString)

        Dim RandomDate1 As Date = specificDate.AddDays(qtdDias1)
        Dim RandomDate2 As Date = specificDate.AddDays(qtdDias2)

        ' Create an array of dates
        Dim datesArray As Date() = {specificDate, RandomDate1, RandomDate2}

        ' Shuffle the array to show dates in different orders every time it is loaded
        Dim rnd As New Random()
        For i As Integer = datesArray.Length - 1 To 0 Step -1
            Dim j As Integer = rnd.Next(0, i + 1)
            Dim temp As Date = datesArray(i)
            datesArray(i) = datesArray(j)
            datesArray(j) = temp
        Next

        labResposta1.Text = funcoes.formataData(datesArray(0)).ToString
        labResposta2.Text = funcoes.formataData(datesArray(1)).ToString
        labResposta3.Text = funcoes.formataData(datesArray(2)).ToString
    End Sub

    Protected Sub butEmail_Click(sender As Object, e As EventArgs) Handles butEmail.Click
        Try
            eMail.enviaCodigoAcesso("", tbEmail.Text, "Codigo teste")

        Catch ex As Exception
            labscript.Visible = True
            labscript.Text = ado.erroGeral(ex.Message)
        End Try
    End Sub
End Class