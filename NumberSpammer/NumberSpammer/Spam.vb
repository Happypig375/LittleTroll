Public Class Spam
    Private Sub Generate_Click(sender As Object, e As EventArgs) Handles Generate.Click
        Out.Text = Min.Value
        For i = Min.Value + Freq.Value To Max.Value Step Freq.Value
            Out.Text &= Betw.Text & i
        Next
        Length.Text = Out.Text.Length
    End Sub
End Class
