Imports System.IO

Public Class einfügen_form

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt", vbNewLine + TextBox1.Text)
            Label2.Text = "Saved at " & Now
            TextBox2.Text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt")
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub einfügen_form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control Then
            'strg + s
            If TextBox1.Text <> "" Then
                File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt", vbNewLine + TextBox1.Text)
                Label2.Text = "Saved at " & Now
                TextBox2.Text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt")
                TextBox1.Text = ""
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub einfügen_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            Me.Close()
            Form1.Show()
        Else
            Dim Result As DialogResult
            Result = MessageBox.Show(Me, "Do you want to save your current text?", "Save current text", MessageBoxButtons.YesNoCancel)
            If Result = DialogResult.Yes Then
                If TextBox1.Text <> "" Then
                    File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\latin_words.txt", vbNewLine + TextBox1.Text)
                    Label2.Text = "Saved at " & Now
                    TextBox1.Text = ""
                    Me.Close()
                End If
            ElseIf Result = DialogResult.No Then
                Me.Close()
                Form1.Show()
            ElseIf Result = DialogResult.Cancel Then
                'nothing
            End If
        End If

    End Sub
End Class