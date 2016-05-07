Public Class Editor
    Friend Reader As System.IO.StreamReader
    Friend Writer As System.IO.StreamWriter
    Friend Changed As Boolean

    Private Sub Edit_TextChanged(sender As Object, e As EventArgs) Handles Edit.TextChanged
        Changed = True
    End Sub
    Private Sub FileNew_Click(sender As Object, e As EventArgs) Handles FileNew.Click
        Edit.Clear()
    End Sub

    Private Sub FileOpen_Click(sender As Object, e As EventArgs) Handles FileOpen.Click
        Open.DereferenceLinks = True
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Reader = New System.IO.StreamReader(Open.FileName)
            Edit.Text = Reader.ReadToEnd
            Reader.Close()
        End If
    End Sub

    Private Sub FileOpenLink_Click(sender As Object, e As EventArgs) Handles FileOpenLink.Click
        Open.DereferenceLinks = False
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Reader = New System.IO.StreamReader(Open.FileName)
            Edit.Text = Reader.ReadToEnd
            Reader.Close()
        End If
    End Sub

    Private Sub FileReload_Click(sender As Object, e As EventArgs) Handles FileReload.Click
        Reader = New System.IO.StreamReader(Open.OpenFile)
        Edit.Text = Reader.ReadToEnd
        Reader.Close()
    End Sub

    Private Sub FileSave_Click(sender As Object, e As EventArgs) Handles FileSave.Click
        If Not Changed Then Exit Sub
        If Not Open.FileName = "" Then
            Writer = New System.IO.StreamWriter(Open.FileName, False)
            Writer.Write(Edit.Text)
            Writer.Flush()
            Writer.Close()
        Else
            FileSaveAs_Click(sender, e)
        End If
    End Sub

    Private Sub FileSaveAs_Click(sender As Object, e As EventArgs) Handles FileSaveAs.Click
        If Not Changed Then Exit Sub
        If Save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Open.FileName = Save.FileName
            Writer = New System.IO.StreamWriter(Open.FileName, False)
        End If
    End Sub
End Class
