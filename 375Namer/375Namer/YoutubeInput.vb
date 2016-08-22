Imports System.Text.RegularExpressions
Public Class YoutubeInput
    Private Sub YoutubeInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form.AddFiles(Items)
    End Sub
    Private Iterator Function Items() As IEnumerable(Of String)
        For Each Item As Match In Regex.Matches(Input.Text, "\w+\s\d{4}(-\d{2}){2}\s(\d{2}-){3}\d{3}(_fixed)?\.(avi|mp4)")
            Yield Item.Value
        Next
    End Function
End Class