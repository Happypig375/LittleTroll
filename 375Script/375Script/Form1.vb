Public Class Editor
    Friend Reader As System.IO.StreamReader
    Friend Writer As System.IO.StreamWriter
    Private Sub FileNew_Click(sender As Object, e As EventArgs) Handles FileNew.Click
        Edit.Clear()
    End Sub

    Private Sub FileOpen_Click(sender As Object, e As EventArgs) Handles FileOpen.Click
        Open.DereferenceLinks = True
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Reader = New System.IO.StreamReader(Open.FileName)
            Edit.Text = Reader.ReadToEnd
        Else
            Open.FileName = ""
        End If
    End Sub

    Private Sub FileOpenLink_Click(sender As Object, e As EventArgs) Handles FileOpenLink.Click
        Open.DereferenceLinks = False
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Reader = New System.IO.StreamReader(Open.FileName)
            Edit.Text = Reader.ReadToEnd
        Else
            Open.FileName = ""
        End If
    End Sub
End Class
