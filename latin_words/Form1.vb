Public Class Form1

    Public Function restart_abfragen_form()
        abfragen_form.Show()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        einfügen_form.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        abfragen_form.Show()
    End Sub
End Class
