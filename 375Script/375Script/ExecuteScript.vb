Partial Public Class Editor
    Private Sub Editor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With RTBWrapper
            .bind(Edit)
            .rtfSyntax.add("^\s*?close\b", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("^\s*?hide\b", True, True, Color.Blue.ToArgb)
            '.rtfSyntax.add("^\s*?play(:l(oop)?|:stop|:x|:s(ystem(sound)?)?|:w(ait(tocomplete)?)?)\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("^\s*?loop\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=play:l)oop\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play):l\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play:s)top\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play):x\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play:system)sound\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play:s)ystem\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play):s\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play:wait)tocomplete\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play:w)ait\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=play):w\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("^\s*?play\b", True, True, Color.DarkCyan.ToArgb)
            .rtfSyntax.add("(?<=message:c)ritical\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):c\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):x\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message:q)uestion\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):q\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):?\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message:e)xclamation\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):e\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):!\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message:q)uestion\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):q\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):?\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message:info)rmation\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message:i)nfo\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("(?<=message):i\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("^\s*?message\b", True, True, Color.Orange.ToArgb)
            .rtfSyntax.add("^\s*?show\b", True, True, Color.Blue.ToArgb)
            .rtfSyntax.add("(?<=stop:a)ll\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=stop):a\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=stop:o)thers\b", True, True, Color.Red.ToArgb)
            .rtfSyntax.add("(?<=stop):o\b", True, True, Color.Red.ToArgb)
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

    Friend Sub Execute(Input As String, ScriptName As String, Optional Debug As Boolean = False)
        If Debug Then _375Script.Debug.Show()
Reloop: Dim LineNum As ULong = 0
        For Each Line As String In Input.Split(Chr(10), Chr(13))
            LineNum += 1
            If StopLoop Then Exit For
            Line = Trim(Line)
            If Line = "" Then Continue For
            Dim Content As String = Line.Substring(Line.IndexOf(" "c) + 1)
            Try
                Select Case Line.Split({" "c}, 2)(0).ToLower
                    Case "close"
                        Me.Close()
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
                    Case "show"
                        Me.Show()
                    Case "stop"
                        Exit For
                    Case "stop:all", "stop:a"
                        StopLoop = True
                        Exit For
                    Case "stop:others", "stop:o"
                        StopLoop = True
                    Case "wait"
                        System.Threading.Thread.Sleep(Val(Content) * 1000)
                        My.Application.DoEvents()
                    Case "waituntil"
                        System.Threading.Thread.Sleep(Convert.ToDateTime(Content) - Now)
                        My.Application.DoEvents()
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
End Class
