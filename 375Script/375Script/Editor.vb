Public Class Editor
    Friend Reader As System.IO.StreamReader
    Friend Writer As System.IO.StreamWriter
    Friend Changed As Boolean

    Private Sub Edit_TextChanged(sender As Object, e As EventArgs)
        Changed = True
    End Sub
    Private Sub FileNew_Click(sender As Object, e As EventArgs) Handles FileNew.Click
        Edit.Text = ""
        Edit.Rtf = ""
        Edit.Clear()
    End Sub

    Private Sub FileOpen_Click(sender As Object, e As EventArgs) Handles FileOpen.Click
        Open.DereferenceLinks = True
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Edit.LoadFile(Open.FileName, RichTextBoxStreamType.PlainText)
            RTBWrapper.colorDocument()
        End If
    End Sub

    Private Sub FileOpenLink_Click(sender As Object, e As EventArgs) Handles FileOpenLink.Click
        Open.DereferenceLinks = False
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
#If True Then
            Edit.LoadFile(Open.FileName, RichTextBoxStreamType.PlainText)
            RTBWrapper.colorDocument()
#Else
            Reader = New System.IO.StreamReader(Open.FileName)
            Edit.Text = Reader.ReadToEnd
            Reader.Close()
#End If
        End If
    End Sub

    Private Sub FileReload_Click(sender As Object, e As EventArgs) Handles FileReload.Click
            Edit.LoadFile(Open.FileName, RichTextBoxStreamType.PlainText)
        RTBWrapper.colorDocument()
    End Sub

    Private Sub FileSave_Click(sender As Object, e As EventArgs) Handles FileSave.Click
        If Not Changed Then Exit Sub
        If Not Open.FileName = "" Then
#If True Then
            Edit.SaveFile(Save.FileName, RichTextBoxStreamType.PlainText)
#Else
            Writer = New System.IO.StreamWriter(Open.FileName, False)
            Writer.Write(Edit.Text)
            Writer.Flush()
            Writer.Close()
#End If
        Else
            FileSaveAs_Click(sender, e)
        End If
    End Sub

    Private Sub FileSaveAs_Click(sender As Object, e As EventArgs) Handles FileSaveAs.Click
        If Not Changed Then Exit Sub
        If Save.ShowDialog = Windows.Forms.DialogResult.OK Then
            Open.FileName = Save.FileName
           Edit.SaveFile(Save.FileName, RichTextBoxStreamType.PlainText)
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

    Private Sub FilePageSetup_Click(sender As Object, e As EventArgs) Handles FilePageSetup.Click

    End Sub

    Private Sub OpenCRTFSyntaxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugOpenCRTFSyntax.Click
        cRTFSyntax.Show()
    End Sub

    Private Sub OpenRTFDebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugOpenRTFDebug.Click
        cRTFDebug.Show()
    End Sub

    Private Sub OpenForm1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebugOpenForm1.Click
        Form1.Show()
    End Sub
    Private WithEvents RTBWrapper As New cRTBWrapper

    Private Sub Editor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With RTBWrapper
            .bind(Edit)
            .rtfSyntax.add("<span.*?>", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("<p.*>", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("<a.*?>", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("<table.*?>", True, True, Color.Tan.ToArgb)
            .rtfSyntax.add("<tr.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<td.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<img.*?>", True, True, Color.Red.ToArgb)
        End With
    End Sub

    Private Sub RTBWrapper_position(ByVal PositionInfo As cRTBWrapper.cPosition) Handles RTBWrapper.position
        Status.Text = "Cursor: " & PositionInfo.Cursor & "  |  Line: " & PositionInfo.CurrentLine & "  | Position: " & PositionInfo.LinePosition
    End Sub

    Private Sub DebugMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.checked = RTBWrapper.toggleDebug()
    End Sub

    Private Sub FileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileExit.Click
        Me.Close()
    End Sub

    Private Sub SyntaxMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyntaxMode.Click
        Dim syntaxView As New cRTFSyntax
        syntaxView.colSyntax = RTBWrapper.rtfSyntax

        If syntaxView.ShowDialog = DialogResult.OK Then
            RTBWrapper.rtfSyntax = syntaxView.colSyntax
        End If

        RTBWrapper.colorDocument()
    End Sub

    Private Sub FormatRehilight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormatRehilight.Click
        RTBWrapper.colorDocument()
    End Sub

    Private Sub ViewStatusBar_Click(sender As Object, e As EventArgs) Handles ViewStatusBar.Click
        Status.Visible = Not Status.Visible
        sender.checked = Status.Visible
    End Sub

    Private Sub FormatWordWrap_Click(sender As Object, e As EventArgs) Handles FormatWordWrap.Click
        Edit.WordWrap = Not Edit.WordWrap
        sender.checked = Edit.WordWrap
    End Sub
End Class
