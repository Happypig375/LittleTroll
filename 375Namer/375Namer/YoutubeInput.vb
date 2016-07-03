Imports System.Text.RegularExpressions
Public Class YoutubeInput
    Private Sub YoutubeInput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each Item As Match In Regex.Matches(Input.Text, "\w+\s\d{4}(-\d{2}){2}\s(\d{2}-){3}\d{3}(_fixed)?\.(avi|mp4)")
            If Not Form.Names.Contains(Item.Value) Then
                Form.Names.Add("")
                Form.List.Items.Add(Item.Value)
            End If
        Next
    End Sub
End Class