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
        End If
    End Sub

    Private Sub FileOpenLink_Click(sender As Object, e As EventArgs) Handles FileOpenLink.Click
        Open.DereferenceLinks = False
        If Open.ShowDialog() = Windows.Forms.DialogResult.OK Then
#If True Then
            Edit.LoadFile(Open.FileName, RichTextBoxStreamType.PlainText)
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
    End Sub

    Private Sub FileSave_Click(sender As Object, e As EventArgs) Handles FileSave.Click
        If Not Changed Then Exit Sub
        If Not (Open.FileName = "" Or Open.FileName = Nothing) Then
#If True Then
            Edit.SaveFile(Open.FileName, RichTextBoxStreamType.PlainText)
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

    Private Sub FileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileExit.Click
        Me.Close()
    End Sub

    Private Sub ViewStatusBar_Click(sender As Object, e As EventArgs) Handles ViewStatusBar.Click
        Status.Visible = Not Status.Visible
        ViewStatusBar.Checked = Status.Visible
    End Sub

    Private Sub FormatWordWrap_Click(sender As Object, e As EventArgs) Handles FormatWordWrap.Click
        Edit.WordWrap = Not Edit.WordWrap
        FormatWordWrap.Checked = Edit.WordWrap
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

    Private Sub EditGoTo_Click(sender As Object, e As EventArgs) Handles EditGoTo.Click
        Do
            Dim Response As String = InputBox("Go to line number:", "Go To Line", Nothing)
            If Response = Nothing Then Exit Sub
            If IsNumeric(Response) Then ' Contains the desired line number
                Dim lineStr As String ' a string which will hold each line
                Dim totLen As Int64   ' the total length
                Dim counter As Integer = 1 ' the current line number

                For Each lineStr In Edit.Lines
                    If counter = CInt(Response) Then Exit For
                    totLen += lineStr.Length
                    counter += 1
                Next

                Edit.SelectionStart = CInt(totLen + Val(Response) - 1)
                Edit.Focus()
            End If
        Loop
    End Sub


    Private Sub EditInsertTimeDate_Click(sender As Object, e As EventArgs)
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
        Dim Factor As Single = CSng(Val(InputBox("Input the zoom factor: " & vbCrLf &
                                            "(Must be between 1/64 (0.015625) and 64.0, not inclusive." &
                                            " A value of 1.0 indicates that no zoom is applied.)", "Set Zoom", Convert.ToString(Edit.ZoomFactor))))
        Edit.ZoomFactor = If(Factor >= 0.0156250019F, If(Factor <= 63.9999962F, Factor, 63.9999962F), 0.0156250019F)
    End Sub

    Private Sub HelpAbout375Script_Click(sender As Object, e As EventArgs) Handles HelpAbout375Script.Click
        'About.Show()
    End Sub
    Private Sub HelpViewHelp_Click(sender As Object, e As EventArgs) Handles HelpViewHelp.Click
        Help.ShowHelp(Me, "375Script.chm")
    End Sub

    Private Sub InsertChar_Click(sender As Object, e As EventArgs) Handles InsertChar.Click
        Edit.SelectedText = SurrogatePair.Chr(InputBox(
        "Input the character's unicode value: ", "Insert Char"))
    End Sub

    Private Sub InsertTimeDate_Click(sender As Object, e As EventArgs) Handles InsertTimeDate.Click
        Edit.SelectedText = Now.ToString
    End Sub

End Class
