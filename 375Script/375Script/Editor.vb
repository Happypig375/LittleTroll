Public Class Editor
    Friend Reader As System.IO.StreamReader
    Friend Writer As System.IO.StreamWriter
    Friend Changed As Boolean
    Friend Sub CheckSave(ByRef sender As Object, ByRef e As FormClosingEventArgs)
        If Changed Then
            Select Case MsgBox("There are unsaved changes. Do you want to save now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    FileSave_Click(sender, e)
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    e.Cancel = True
            End Select
        End If
    End Sub
    Private Sub Edit_TextChanged(sender As Object, e As EventArgs) Handles Edit.TextChanged
        Changed = True
        EditUndo.Enabled = Edit.CanUndo
    End Sub
    Private Sub FileNew_Click(sender As Object, e As EventArgs) Handles FileNew.Click
        Dim EArgs As New FormClosingEventArgs(CloseReason.None, False)
        CheckSave(sender, EArgs)
        If EArgs.Cancel Then Exit Sub
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
        If Open.FileName = Nothing Then Exit Sub
        Edit.LoadFile(Open.FileName, RichTextBoxStreamType.PlainText)
        RTBWrapper.colorDocument()
    End Sub

    Private Sub FileSave_Click(sender As Object, e As EventArgs) Handles FileSave.Click
        If Not Changed Then Exit Sub
        If Not Open.FileName = "" Or Open.FileName = Nothing Then
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
                printFont = SetFont.Font
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
            .rtfSyntax.add("close", False, True, Color.Blue.ToArgb)
            .rtfSyntax.add("hide", False, True, Color.Blue.ToArgb)
            .rtfSyntax.add("play:loop", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("loop", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("play:l", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:stop", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:x", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:systemsound", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:system", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:s", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:waittocomplete", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:wait", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play:w", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("play", False, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("message:critical", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:c", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:x", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:question", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:q", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:?", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:exclamation", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:e", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:!", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:question", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:q", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:?", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:information", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:info", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message:i", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("message", False, True, Color.Orange.ToArgb)
            .rtfSyntax.add("show", False, True, Color.Blue.ToArgb)
            .rtfSyntax.add("stop:all", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("stop:a", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("stop:others", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("stop:o", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("stop", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("waituntil", False, True, Color.Red.ToArgb)
            .rtfSyntax.add("wait", False, True, Color.Red.ToArgb)
#If False Then
            .rtfSyntax.add("<span.*?>", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("<p.*>", True, True, Color.Darkdarkcyan.ToArgb)
            .rtfSyntax.add("<a.*?>", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("<table.*?>", True, True, Color.Tan.ToArgb)
            .rtfSyntax.add("<tr.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<td.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<img.*?>", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("not regex and case sensitive", False, False, Color.Red.ToArgb)

#End If
        End With
    End Sub

    Private Sub RTBWrapper_position(ByVal PositionInfo As cRTBWrapper.cPosition) Handles RTBWrapper.position
        Status.Text = "Cursor: " & PositionInfo.Cursor & "  |  Line: " & PositionInfo.CurrentLine & "  | Position: " & PositionInfo.LinePosition
    End Sub

    Private Sub DebugMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugMode.Click
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

    Private Sub ExecuteScript_Click(sender As Object, e As EventArgs) Handles ExecuteScript.Click
        Execute(Edit.Text, If(Open.FileName, "Untitled"))
    End Sub

    Private Sub EditUndo_Click(sender As Object, e As EventArgs) Handles EditUndo.Click
        If Edit.CanUndo Then Edit.Undo()
        EditUndo.Enabled = Edit.CanUndo
    End Sub

    Private Sub EditUndo_MouseEnter(sender As Object, e As EventArgs) Handles EditUndo.MouseEnter
        EditUndo.Enabled = Edit.CanUndo
    End Sub

    Private Sub Editor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CheckSave(sender, e)
    End Sub

    Private Sub EditCut_Click(sender As Object, e As EventArgs) Handles EditCut.Click
        Edit.Cut()
    End Sub

    Private Sub EditCopy_Click(sender As Object, e As EventArgs) Handles EditCopy.Click
        Edit.Copy()
    End Sub

    Private Sub EditPaste_Click(sender As Object, e As EventArgs) Handles EditPaste.Click
        Edit.Paste()
    End Sub

    Private Sub DebugTestSelectedText_Click(sender As Object, e As EventArgs) Handles DebugTestSelectedText.Click
        ' Clear all text from the RichTextBox;
        Edit.Clear()
        ' Set the font for the opening text to a larger Arial font;
        Edit.SelectionFont = New Font("Arial", 16)
        ' Assign the introduction text to the RichTextBox control.
        Edit.SelectedText = "The following is a list of bulleted items:" + ControlChars.Cr
        ' Set the Font for the first item to a smaller size Arial font.
        Edit.SelectionFont = New Font("Arial", 12)
        ' Specify that the following items are to be added to a bulleted list.
        Edit.SelectionBullet = True
        ' Set the color of the item text.
        Edit.SelectionColor = Color.Red
        ' Assign the text to the bulleted item.
        Edit.SelectedText = "Apples" + ControlChars.Cr
        ' Apply same font since font settings do not carry to next line.
        Edit.SelectionFont = New Font("Arial", 12)
        Edit.SelectionColor = Color.Orange
        Edit.SelectedText = "Oranges" + ControlChars.Cr
        Edit.SelectionFont = New Font("Arial", 12)
        Edit.SelectionColor = Color.Purple
        Edit.SelectedText = "Grapes" + ControlChars.Cr
        ' End the bulleted list.
        Edit.SelectionBullet = False
        ' Specify the font size and string for text displayed below bulleted list.
        Edit.SelectionFont = New Font("Arial", 16)
        Edit.SelectedText = "Bulleted Text Complete!"
    End Sub
    Private FindWord As String
    Private Sub EditFind_Click(sender As Object, e As EventArgs) Handles EditFind.Click
        Dim Find As New Find(Find.FindMode.Find)
        If Find.ShowDialog() = Windows.Forms.DialogResult.OK Then Edit.
                      Find(Find.Settings.FindText, If(Edit.SelectedText = "", 0, Edit.SelectionStart),
                      If(Edit.SelectedText = "", -1, Edit.SelectionStart + Edit.SelectionLength),
                      If(Find.Settings.MatchCase, RichTextBoxFinds.MatchCase, RichTextBoxFinds.None) Or
                      If(Find.Settings.Highlight, RichTextBoxFinds.None, RichTextBoxFinds.NoHighlight) Or
                      If(Find.Settings.WholeWord, RichTextBoxFinds.WholeWord, RichTextBoxFinds.None) Or
                      If(Find.Settings.StartBottom, RichTextBoxFinds.Reverse, RichTextBoxFinds.None))
        EditFindNext.Enabled = True
    End Sub

    Private Sub EditFindNext_Click(sender As Object, e As EventArgs) Handles EditFindNext.Click

    End Sub

    Private Sub EditReplace_Click(sender As Object, e As EventArgs) Handles EditReplace.Click
        Dim Find As New Find(Find.FindMode.Replace)
        Dim WhiteSpaces As New List(Of String)
        WhiteSpaces.Add(Chr(&H9)) : WhiteSpaces.Add(Chr(&HA)) : WhiteSpaces.Add(Chr(&HB))
        WhiteSpaces.Add(Chr(&HC)) : WhiteSpaces.Add(Chr(&HE)) : WhiteSpaces.Add(Chr(&H20))
        WhiteSpaces.Add(Chr(&H85)) : WhiteSpaces.Add(Chr(&HA0)) : WhiteSpaces.Add(Chr(&H1680))
        WhiteSpaces.Add(Chr(&H2000)) : WhiteSpaces.Add(Chr(&H2001)) : WhiteSpaces.Add(Chr(&H2002))
        WhiteSpaces.Add(Chr(&H2003)) : WhiteSpaces.Add(Chr(&H2004)) : WhiteSpaces.Add(Chr(&H2005))
        WhiteSpaces.Add(Chr(&H2006)) : WhiteSpaces.Add(Chr(&H2007)) : WhiteSpaces.Add(Chr(&H2008))
        WhiteSpaces.Add(Chr(&H2009)) : WhiteSpaces.Add(Chr(&H200A)) : WhiteSpaces.Add(Chr(&H2028))
        WhiteSpaces.Add(Chr(&H2029)) : WhiteSpaces.Add(Chr(&H202F)) : WhiteSpaces.Add(Chr(&H205F))
        WhiteSpaces.Add(Chr(&H3000))
#If False Then
    Members of the SpaceSeparator category, which includes the characters 
SPACE (U+0020), NO-BREAK SPACE (U+00A0), OGHAM SPACE MARK (U+1680), EN QUAD (U+2000), EM QUAD (U+2001),
        EN SPACE (U+2002), EM SPACE (U+2003), THREE-PER-EM SPACE (U+2004), FOUR-PER-EM SPACE (U+2005), SIX-PER-EM SPACE (U+2006),
        FIGURE SPACE (U+2007), PUNCTUATION SPACE (U+2008), THIN SPACE (U+2009), HAIR SPACE (U+200A), NARROW NO-BREAK SPACE (U+202F)
, MEDIUM MATHEMATICAL SPACE (U+205F), and IDEOGRAPHIC SPACE (U+3000).

Members of the LineSeparator category, which consists solely of the LINE SEPARATOR character (U+2028).

Members of the ParagraphSeparator category, which consists solely of the PARAGRAPH SEPARATOR character (U+2029).

The characters CHARACTER TABULATION (U+0009), LINE FEED (U+000A), LINE TABULATION (U+000B), FORM FEED (U+000C), CARRIAGE RETURN (U+000D), and NEXT LINE (U+0085). 
#End If
        If Find.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Find.Settings.WholeWord Then
                For Each Char1 As Char In WhiteSpaces
                    For Each Char2 As Char In WhiteSpaces
                        Edit.Text.Replace(Char1 & Find.Settings.FindText & Char2, Char1 & Find.Settings.ReplaceText & Char2)
                    Next
                Next
            Else
                Edit.Text.Replace(Find.Settings.FindText, Find.Settings.ReplaceText)
            End If
        End If
    End Sub

    Private Sub EditGoTo_Click(sender As Object, e As EventArgs) Handles EditGoTo.Click
        Do
            Dim Response As String = InputBox("Go to line number:", "Go To Line", Nothing)
            If Response = Nothing Then Exit Sub
            If IsNumeric(Response) Then' Contains the desired line number
                Dim lineStr As String ' a string which will hold each line
                Dim totLen As Int64   ' the total length
                Dim counter As Integer = 1 ' the current line number

                For Each lineStr In Edit.Lines
                    If counter = Response Then Exit For
                    totLen += lineStr.Length
                    counter += 1
                Next

                Edit.SelectionStart = totLen + Response - 1
                Edit.Focus()
            End If
        Loop
    End Sub

    Private Sub EditSelectAll_Click(sender As Object, e As EventArgs) Handles EditSelectAll.Click
        Edit.SelectAll()
    End Sub

    Private Sub EditInsertTimeDate_Click(sender As Object, e As EventArgs) Handles EditInsertTimeDate.Click
        Edit.AppendText(Now.ToString)
    End Sub

    Private Sub FormatFont_Click(sender As Object, e As EventArgs) Handles FormatFont.Click
        If SetFont.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Edit.Font = SetFont.Font
            Edit.ForeColor = SetFont.Color
        End If
    End Sub

    Private Sub FormatBackground_Click(sender As Object, e As EventArgs) Handles FormatBackground.Click
        If Background.ShowDialog() = Windows.Forms.DialogResult.OK Then Edit.BackColor = Background.Color
    End Sub

    Private Sub ViewZoomIn_Click(sender As Object, e As EventArgs) Handles ViewZoomIn.Click
        Dim Factor As Single = Edit.ZoomFactor * 2
        Edit.ZoomFactor = If(Factor <= 63.9999962F, Factor, 63.9999962F)
    End Sub

    Private Sub ViewZoomOut_Click(sender As Object, e As EventArgs) Handles ViewZoomOut.Click
        Dim Factor As Single = Edit.ZoomFactor / 2
        Edit.ZoomFactor = If(Factor >= 0.0156250019F, Factor, 0.0156250019F)
    End Sub

    Private Sub ViewZoomReset_Click(sender As Object, e As EventArgs) Handles ViewZoomReset.Click
        Edit.ZoomFactor = 1
    End Sub

    Private Sub ViewZoomSet_Click(sender As Object, e As EventArgs) Handles ViewZoomSet.Click
        Dim Factor As Single = Val(InputBox("Input the zoom factor: " & vbCrLf &
                                            "(Must be between 1/64 (0.015625) and 64.0, not inclusive." &
                                            " A value of 1.0 indicates that no zoom is applied.)", "Set Zoom", Edit.ZoomFactor))
        Edit.ZoomFactor = If(Factor >= 0.0156250019F, If(Factor <= 63.9999962F, Factor, 63.9999962F), 0.0156250019F)
    End Sub

    Private Sub HelpAbout375Script_Click(sender As Object, e As EventArgs) Handles HelpAbout375Script.Click
        About.Show()
    End Sub

    Private Sub StartDebugging_Click(sender As Object, e As EventArgs) Handles StartDebugging.Click
        Execute(Edit.Text, If(Open.FileName, "Untitled"), True)
    End Sub

    Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Pause And e.Control Then StopLoop = True
    End Sub

    Private Sub HelpViewHelp_Click(sender As Object, e As EventArgs) Handles HelpViewHelp.Click
        Help.ShowHelp(Me, "375Script.chm")
    End Sub
End Class
