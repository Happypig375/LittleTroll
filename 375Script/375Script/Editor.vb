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
            Writer.Write(Edit.Text)
            Writer.Flush()
            Writer.Close()
        End If
    End Sub
    Private printFont As Font
    Private streamToPrint As IO.StringReader
    ' The Click event is raised when the user clicks the Print button.
    Private Sub printButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FilePrint.Click
        Try
            streamToPrint = New IO.StringReader(Edit.Text)
            Try
                printFont = New Font("Arial", 10)
                Dim pd As New Printing.PrintDocument()
                AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As Printing.PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Print each line of the file.
        While count < linesPerPage
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub

End Class
