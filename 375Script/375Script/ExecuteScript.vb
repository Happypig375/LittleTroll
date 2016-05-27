Partial Public Class Editor
    Private Sub Editor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With RTBWrapper
            .bind(Edit)
            .rtfSyntax.add("^\s*?close\b", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("^\s*?execute\b", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("^\s*?hide\b", True, True, Color.Blue.ToArgb)
            '.rtfSyntax.add("^\s*?play(:l(oop)?|:stop|:x|:s(ystem(sound)?)?|:w(ait(tocomplete)?)?)\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("^\s*?loop\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play:l)oop\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play):l\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play:s)top\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play):x\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play:system)sound\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play:s)ystem\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play):s\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play:wait)tocomplete\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play:w)ait\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?play):w\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("^\s*?play\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message:c)ritical\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):c\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):x\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message:q)uestion\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):q\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):?\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message:e)xclamation\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):e\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):!\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message:q)uestion\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):q\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):?\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message:info)rmation\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message:i)nfo\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=^\s*?message):i\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("^\s*?message\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("^\s*?repeat\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("^\s*?show\b", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("(?<=^\s*?stop:a)ll\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=^\s*?stop):a\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=^\s*?stop:o)thers\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=^\s*?stop):o\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("^\s*?stop\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("^\s*?waituntil\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("^\s*?wait\b", True, True, Color.Red.ToArgb)
#If False Then
            .rtfSyntax.add("<span.*?>", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("<p.*>", True, True, Color.Darkdarkcyan.ToArgb)
            .rtfSyntax.add("<a.*?>", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("<table.*?>", True, True, Color.Tan.ToArgb)
            .rtfSyntax.add("<tr.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<td.*?>", True, True, Color.Brown.ToArgb)
            .rtfSyntax.add("<img.*?>", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("not regex and case sensitive", False, False, Color.Red.ToArgb)
            .rtfSyntax.add("not regex and case insensitive", False, True, Color.Red.ToArgb)
#End If
        End With
    End Sub
    'Declare Function AttachConsole Lib "kernel32.dll" (dwProcessId As UInt32) As Boolean
    Declare Function AllocConsole Lib "kernel32" () As Int32
    Declare Function FreeConsole Lib "kernel32" () As Int32

    '''' <summary>Identifies the console of the parent of the current process as the console to be attached.</summary>
    'Const ATTACH_PARENT_PROCESS As UInteger = &HFFFFFFFFUI

    '''' <summary>
    '''' calling process is already attached to a console
    '''' </summary>
    'Const ERROR_ACCESS_DENIED As Integer = 5
    Dim _StopLoop As Boolean
    Friend Process As System.Diagnostics.Process
    Friend Property StopLoop As Boolean
        Get
            Return _StopLoop
        End Get
        Set(value As Boolean)
            If value Then
                _StopLoop = True
                System.Threading.Thread.Sleep(500)
                My.Application.DoEvents()
            End If
            _StopLoop = False
        End Set
    End Property
#If False Then
       Public Sub Main()
      ' Write out the original string.
      Console.WriteLine("aabbccddeeffcccgghhcccciijjcccckkcc")
      ' Write out the modified string.
      Console.WriteLine(New Regex("cc").Replace("aabbccddeeffcccgghhcccciijjcccckkcc", New MatchEvaluator(AddressOf ReplaceCC)))
   End Sub

   Public Function ReplaceCC(ByVal m As Match) As String
      ' Replace each Regex match with the number of the match occurrence.
      static i as integer

      i = i + 1
      Return i.ToString() & i.ToString()
   End Function
#End If
    Private Function msg(M As String) As String
        MsgBox(M)
        Return M
    End Function
    Friend Sub Execute(Input As String, ScriptName As String, Optional Debug As Boolean = False)
        If Debug Then _375Script.Debug.Show()
Reloop: Dim Variables As New Dictionary(Of String, String)
        Dim LineNum As ULong = 0
        Process = New Process
        For Each Line As String In Input.Split(Chr(10), Chr(13), Chr(8232), Chr(8233))
            LineNum += 1
            If StopLoop Then Exit For
            Line = Trim(Line)
            If Line = "" Then Continue For
            Dim Content As String = Line.Substring(Line.IndexOf(" "c) + 1)
            Try
                Content = System.Text.RegularExpressions.Regex.Replace(Content, "\s*\$\S+\b", New System.Text.RegularExpressions.MatchEvaluator(
                                                             Function(M As System.Text.RegularExpressions.Match) (Variables(M.Value.Substring(1)))))
                'New Regex("cc").Replace("aabbccddeeffcccgghhcccciijjcccckkcc", New MatchEvaluator(AddressOf ReplaceCC))
                Select Case Line.Split({" "c}, 2)(0).ToLower
                    Case "close"
                        Me.Close()
                    Case "define"
                        Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                        Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                        Variables.Add(Var, Content)
                    Case "execute"
                        Execute(New System.IO.StreamReader(Content).ReadToEnd, System.IO.Path.GetFileNameWithoutExtension(Content))
                    Case "hide"
                        Me.Hide()
                    Case "loop"
                        GoTo Reloop
                    Case "play"
                        My.Computer.Audio.Play(Content, AudioPlayMode.Background)
                    Case "play:loop", "play:l"
                        My.Computer.Audio.Play(Content, AudioPlayMode.BackgroundLoop)
                    Case "play:stop", "play:x"
                        My.Computer.Audio.Stop()
                    Case "play:systemsound", "play:system", "play:s"
                        Select Case Content
                            Case "asterisk", "a", "*"
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                            Case "beep", "b"
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
                            Case "exclamation", "e", "!"
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                            Case "hand", "h"
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                            Case "question", "q", "?"
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Question)
                        End Select
                    Case "play:waittocomplete", "play:wait", "play:w"
                        My.Computer.Audio.Play(Content, AudioPlayMode.WaitToComplete)
                    Case "message"
                        MsgBox(Content, , ScriptName)
                    Case "message:critical", "message:c", "message:x"
                        MsgBox(Content, MsgBoxStyle.Critical, ScriptName)
                    Case "message:question", "message:q", "message:?"
                        MsgBox(Content, MsgBoxStyle.Question, ScriptName)
                    Case "message:exclamation", "message:e", "message:!"
                        MsgBox(Content, MsgBoxStyle.Exclamation, ScriptName)
                    Case "message:information", "message:info", "message:i"
                        MsgBox(Content, MsgBoxStyle.Information, ScriptName)
                    Case "process"
                        Process.Start()
                    Case "redefine"
                        Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                        Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                        Variables(Var) = ExecuteLine(Content, ScriptName, Variables)
                    Case "redefine:exact", "redefine:e"
                        Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                        Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                        Variables(Var) = Content
                    Case "repeat"
                        Static Counter As Integer
                        If Counter = Nothing Then
                            Counter = 1
                            GoTo Reloop
                        ElseIf Counter < Val(Content) - 1 Then
                            Counter += 1
                            GoTo Reloop
                        Else
                            Counter = Nothing
                        End If
                    Case "show"
                        Me.Show()
                    Case "stop"
                        Exit For
                    Case "stop:all", "stop:a"
                        StopLoop = True
                        Exit For
                    Case "stop:others", "stop:o"
                        StopLoop = True
                    Case "undefine"
                        Variables.Remove(Content)
                    Case "wait"
                        System.Threading.Thread.Sleep(TimeSpan.Parse(Content))
                        My.Application.DoEvents()
                    Case "waituntil"
                        System.Threading.Thread.Sleep(Convert.ToDateTime(Content) - Now)
                        My.Application.DoEvents()
                    Case "win32error"
                        MsgBox(GetMessage(Val("&H" & Content)))
                End Select
            Catch ex As Exception
                If Debug Then
                    _375Script.Debug.Console.AppendText(String.Format("An error ({0}) occured at line {1} of {2}. ", ex.Message, LineNum, ScriptName))
                    _375Script.Debug.Console.AppendText(String.Format("The line: " & Line))
                End If
            End Try
        Next
        If Debug Then
            _375Script.Debug.Console.AppendText(String.Format("The script has ended."))
            _375Script.Debug.Console.AppendText(String.Format("==============================="))
            _375Script.Debug.ReadKey()
            _375Script.Debug.Close()
        End If
    End Sub

    Friend Function ExecuteLine(Line As String, ScriptName As String, ByRef Variables As Dictionary(Of String, String)) As String
        Dim ReadOnlyVariables As New Dictionary(Of String, String)(Variables)
        Line = Trim(Line)
        If Line = "" Then Exit Function
        Dim Content As String = Line.Substring(Line.IndexOf(" "c) + 1)
        Content = System.Text.RegularExpressions.Regex.Replace(Content, "\s*\$\S+\b", New System.Text.RegularExpressions.MatchEvaluator(
                                                     Function(M As System.Text.RegularExpressions.Match) (ReadOnlyVariables(M.Value.Substring(1)))))
        'New Regex("cc").Replace("aabbccddeeffcccgghhcccciijjcccckkcc", New MatchEvaluator(AddressOf ReplaceCC))
        Select Case Line.Split({" "c}, 2)(0).ToLower
            Case "close"
                Try
                    Me.Close()
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "define"
                Try
                    Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                    Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                    Variables.Add(Var, Content)
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "execute"
                Try
                    Execute(New System.IO.StreamReader(Content).ReadToEnd, System.IO.Path.GetFileNameWithoutExtension(Content))
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "hide"
                Try
                    Me.Hide()
                    'Case "loop"
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "play"
                Try
                    My.Computer.Audio.Play(Content, AudioPlayMode.Background)
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "play:loop", "play:l"
                Try
                    My.Computer.Audio.Play(Content, AudioPlayMode.BackgroundLoop)
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "play:stop", "play:x"
                Try
                    My.Computer.Audio.Stop()
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "play:systemsound", "play:system", "play:s"
                Select Case Content
                    Case "asterisk", "a", "*"
                        Try
                            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                            Return "Success"
                        Catch ex As Exception
                            Return "Failed"
                        End Try
                    Case "beep", "b"
                        Try
                            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
                            Return "Success"
                        Catch ex As Exception
                            Return "Failed"
                        End Try
                    Case "exclamation", "e", "!"
                        Try
                            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                            Return "Success"
                        Catch ex As Exception
                            Return "Failed"
                        End Try
                    Case "hand", "h"
                        Try
                            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                            Return "Success"
                        Catch ex As Exception
                            Return "Failed"
                        End Try
                    Case "question", "q", "?"
                        Try
                            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Question)
                            Return "Success"
                        Catch ex As Exception
                            Return "Failed"
                        End Try
                End Select
            Case "play:waittocomplete", "play:wait", "play:w"
                Try
                    My.Computer.Audio.Play(Content, AudioPlayMode.WaitToComplete)
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "message"
                [Enum].GetName(GetType(MsgBoxResult), MsgBox(Content, , ScriptName))
            Case "message:critical", "message:c", "message:x"
                [Enum].GetName(GetType(MsgBoxResult), MsgBox(Content, MsgBoxStyle.Critical, ScriptName))
            Case "message:question", "message:q", "message:?"
                [Enum].GetName(GetType(MsgBoxResult), MsgBox(Content, MsgBoxStyle.Question, ScriptName))
            Case "message:exclamation", "message:e", "message:!"
                [Enum].GetName(GetType(MsgBoxResult), MsgBox(Content, MsgBoxStyle.Exclamation, ScriptName))
            Case "message:information", "message:info", "message:i"
                [Enum].GetName(GetType(MsgBoxResult), MsgBox(Content, MsgBoxStyle.Information, ScriptName))
            Case "process"
                Try
                    Process.Start()
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
                'Case "redefine"
            Case "redefine:exact", "redefine:e"
                Try
                    Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                    Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                    Variables(Var) = Content
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
                'Case "repeat"
            Case "show"
                Try
                    Me.Show()
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "stop"
                Try
                    Exit Function
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "stop:all", "stop:a"
                Try
                    StopLoop = True
                    Exit Function
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "stop:others", "stop:o"
                Try
                    StopLoop = True
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "undefine"
                Try
                    Variables.Remove(Content)
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "wait"
                Try
                    System.Threading.Thread.Sleep(TimeSpan.Parse(Content))
                    My.Application.DoEvents()
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "waituntil"
                Try
                    System.Threading.Thread.Sleep(Convert.ToDateTime(Content) - Now)
                    My.Application.DoEvents()
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "win32error"
                Return GetMessage(Val("&H" & Content))
        End Select
    End Function

    Friend Enum FORMAT_MESSAGE As UShort
        ALLOCATE_BUFFER = &H100
        ARGUMENT_ARRAY = &H2000
        FROM_HMODULE = &H800
        FROM_STRING = &H400
        FROM_SYSTEM = &H1000
        IGNORE_INSERTS = &H200
        MAX_WIDTH_MASK = &HFF
    End Enum

    <Runtime.InteropServices.DllImport("KERNEL32", CharSet:=Runtime.InteropServices.CharSet.Auto, BestFitMapping:=True)>
    <Runtime.Versioning.ResourceExposure(Runtime.Versioning.ResourceScope.None)>
    Friend Shared Function FormatMessage(dwFlags As Integer, lpSource As IntPtr,
    dwMessageId As Integer, dwLanguageId As Integer, lpBuffer As System.Text.StringBuilder,
    nSize As Integer, va_list_arguments As IntPtr) As Integer
    End Function

    ' Gets an error message for a Win32 error code.
    Friend Shared Function GetMessage(errorCode As Integer) As String
        Dim sb As New System.Text.StringBuilder(512)
        Dim result As Integer = FormatMessage(FORMAT_MESSAGE.IGNORE_INSERTS Or
                                              FORMAT_MESSAGE.FROM_SYSTEM Or FORMAT_MESSAGE.ARGUMENT_ARRAY,
                                              IntPtr.Zero, errorCode, 0, sb, sb.Capacity, IntPtr.Zero)
        If result <> 0 Then
            ' result is the # of characters copied to the StringBuilder.
            Return sb.ToString()
        Else
            Return String.Format("Unknown Win32 error code {0:x}", errorCode)
        End If
    End Function
End Class
