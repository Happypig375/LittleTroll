Public Class DateTest
    Private Sub Input_TextChanged(sender As Object, e As EventArgs) Handles Input.TextChanged
        Dim Out As Date
        If Date.TryParse(Input.Text, Out) Then
            Output.Text = Out.ToString(Editor.DateTimeFormat)
        Else Output.ResetText()
        End If
    End Sub
End Class