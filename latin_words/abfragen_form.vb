Public Class abfragen_form

    Dim allwords As String
    Dim allwordsar As Array
    Dim goodwords As New ArrayList
    Dim random As New Random()
    'Dim count As String
    'Dim countar As Array
    Dim currentcount As Integer = 0
    Private Sub abfragen_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        allwords = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt")
        allwordsar = allwords.Split(Environment.NewLine)

        'Dim now As Integer = 0
        'For i As Integer = 0 To allwordsar.Length - 1
        'count += Now + ","
        'Now += 1
        'Next

        'countar = count.Split(",")

        RandomizeArray(allwordsar)

        'Dim newar As Array = allwordsar(random.Next(0, allwordsar.Length - 1)).ToString.Split("#")
        Dim newar As Array = allwordsar(currentcount).ToString.Split("#")
        TextBox1.Text = newar(0)
        currentcount += 1

        TextBox2.Focus()

        Label3.Text = goodwords.Count & "/" & allwordsar.Length
    End Sub

    Private Sub RandomizeArray(ByVal items() As String)
        Dim max_index As Integer = items.Length - 1
        Dim rnd As New Random
        For i As Integer = 0 To max_index - 1
            ' Pick an item for position i.
            Dim j As Integer = rnd.Next(i, max_index + 1)

            ' Swap them.
            Dim temp As String = items(i)
            items(i) = items(j)
            items(j) = temp
        Next i
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        Label3.Text = goodwords.Count & "/" & allwordsar.Length
        If e.KeyCode = Keys.Enter Then

            'check for valid goodwords currentcount
            If goodwords.Count = allwordsar.Length - 1 Then
                MsgBox("Finished. Restart?", MsgBoxStyle.YesNo)
                If MsgBoxResult.Yes Then
                    Me.Close()
                    Form1.restart_abfragen_form()
                ElseIf MsgBoxResult.No Then
                    'nothing
                End If
            Else
                'check if the word is right
                For i As Integer = 0 To allwordsar.Length - 1
                    Dim ar_ As Array = allwordsar(i).ToString.Split("#")
                    Dim newar0 As String = ar_(0).ToString
                    If newar0 = TextBox1.Text Then
                        'word found
                        'check word:

                        Dim ar As Array = allwordsar(i).ToString.Split("#")
                        Dim newar1 As Array = ar(1).ToString.Split(",")
                        Dim word_ As Boolean = False
                        For a As Integer = 0 To newar1.Length - 1
                            If TextBox2.Text = newar1(a).ToString Then
                                word_ = True
                            End If
                        Next

                        If word_ Then
                            goodwords.Add(allwords(i).ToString)
                            Dim newword As String = allwordsar(currentcount).ToString
                            currentcount += 1

                            If newar1.Length > 1 Then
                                TextBox4.Text += allwordsar(i).ToString + vbNewLine
                                TextBox4.SelectionStart = TextBox4.Text.Length
                                TextBox4.ScrollToCaret()
                            End If
                            Dim newar As Array = newword.Split("#")
                            TextBox1.Text = newar(0)
                            TextBox2.Text = ""
                            Label3.Text = goodwords.Count & "/" & allwordsar.Length
                        Else
                            TextBox3.Text += allwordsar(i).ToString + vbNewLine
                            TextBox3.SelectionStart = TextBox3.Text.Length
                            TextBox3.ScrollToCaret()
                        End If

                        Return
                    End If
                Next
            End If


        End If
    End Sub


End Class