﻿Partial Public Class Editor
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
    Class ForceStoppedException
        Inherits ApplicationException
        Public Property LineNumber As ULong
        Sub New(Message As String, Line As ULong, Optional InnerException As Exception = Nothing)
            MyBase.New(Message, InnerException)
            LineNumber = Line
        End Sub
    End Class
    Class ForceStopper
        Inherits ApplicationException
        Sub New(Message As String)
            MyBase.New(Message)
        End Sub
        Function Stopped(Line As ULong) As ForceStoppedException
            Return New ForceStoppedException(Message, Line, Me)
        End Function
    End Class
    Friend Sub Execute(Input As String, ScriptName As String, Optional Debug As Boolean = False)
        Try
            If Debug Then _375Script.Debug.Show()
Reloop:     Dim Variables As New Dictionary(Of String, String)
            Dim LineNum As ULong = 0
            Process = New Process
            For Each Line As String In Input.Split({Chr(10), Chr(13), New SurrogatePair(8232).ToString,
                                               New SurrogatePair(8233).ToString}, StringSplitOptions.RemoveEmptyEntries)
                LineNum += 1
                If StopLoop Then Exit For
                Line = Trim(Line)
                If Line = "" Then Continue For
                Dim Content As String = Line.Substring(Line.IndexOf(" "c) + 1)
                Try
                    Content = System.Text.RegularExpressions.Regex.Replace(Content, "(?<=[\s\n\r])*\$[^\s\r\n]+(?=[\s\n\r]|$)", New System.Text.
                RegularExpressions.MatchEvaluator(Function(M As System.Text.RegularExpressions.Match) (
                If(M.Value(1) = "$"c, GetPredefinedVariable(M.Value.Substring(2)), Variables(M.Value.Substring(1))))))
                    'New Regex("cc").Replace("aabbccddeeffcccgghhcccciijjcccckkcc", New MatchEvaluator(AddressOf ReplaceCC))
                    Select Case Line.Split({" "c}, 2)(0).ToLower
                        Case "append"
                            Edit.AppendText(vbCrLf & "stop" & vbCrLf & "===Output (as of " & Now.ToString & ")===" & vbCrLf)
                            Edit.AppendText(Content)
                        Case "beep"
                            Beep()
                        Case "close"
                            Me.Close()
                        Case "define"
                            Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                            Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                            Variables.Add(Var, Content)
                        Case "display"
                            InputBox("Displaying text...", "Display", Content)
                        Case "execute"
                            Execute(My.Computer.FileSystem.ReadAllText(Content), IO.Path.GetFileNameWithoutExtension(Content))
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
                        Case "opacity"
                            Me.Opacity = Val(Content) / 100
                        Case "process"
                            Process.Start(Content)
                        Case "redefine"
                            Dim Var As New String(Content.TakeWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                            Content = New String(Content.SkipWhile(Function(c As Char) (Not Char.IsWhiteSpace(c))).ToArray)
                            Try
                                Variables(Var) = ExecuteLine(Content, ScriptName, Variables)
                            Catch Stopper As ForceStopper
                                Throw Stopper.Stopped(LineNum)
                            End Try
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
                            MsgBox(GetMessage(Content))
                    End Select
                Catch ex As Exception When TypeOf ex IsNot ForceStoppedException
                    If Debug Then
                        _375Script.Debug.Console.AppendText(String.Format("An error ({0}) occured at line {1} of {2}. ",
                                                                      ex.Message, LineNum, ScriptName))
                        _375Script.Debug.Console.AppendText("The line: " & Line)
                    End If
                End Try
            Next
        Catch [Stop] As ForceStoppedException
            If Debug Then
                _375Script.Debug.Console.AppendText("Stopped at line number " & [Stop].LineNumber & " because " & [Stop].Message)
            End If
        End Try
        If Debug Then
            _375Script.Debug.Console.AppendText("The script has ended.")
            _375Script.Debug.Console.AppendText("===============================")
            _375Script.Debug.ReadKey()
            _375Script.Debug.Close()
        End If
    End Sub

    Friend Function ExecuteLine(Line As String, ScriptName As String, ByRef Variables As Dictionary(Of String, String)) As String
        Dim ReadOnlyVariables As New ReadOnlyDictionary(Of String, String)(Variables)
        Line = Trim(Line)
        If Line = "" Then Return Nothing
        Dim Content As String = Line.Substring(Line.IndexOf(" "c) + 1)
        Content = System.Text.RegularExpressions.Regex.Replace(Content, "\s*\$\S+\b", New System.Text.RegularExpressions.MatchEvaluator(
                                   Function(M As System.Text.RegularExpressions.Match) (
                                   If(M.Value(1) = "$"c, GetPredefinedVariable(M.Value.Substring(2)), ReadOnlyVariables(M.Value.Substring(1))))))
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
                    Throw New ForceStopper("Stop instruction executed.")
                    Return "Success"
                Catch ex As Exception
                    Return "Failed"
                End Try
            Case "stop:all", "stop:a"
                Try
                    StopLoop = True
                    End
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
        Return Nothing
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
#If False Then
    ''' <summary>
    ''' Class for manipulating the brightness of the screen
    ''' </summary>
    Public NotInheritable Class Brightness
        Private Sub New()
        End Sub
        <Runtime.InteropServices.DllImport("gdi32.dll")> _
        Private Shared Function SetDeviceGammaRamp(hdc As Int32, ramp As Pointer(Of System.Void)) As Boolean
        End Function

        Private Shared initialized As Boolean = False
        Private Shared hdc As Int32


        Private Shared Sub InitializeClass()
            If initialized Then
                Return
            End If

            'Get the hardware device context of the screen, we can do
            'this by getting the graphics object of null (IntPtr.Zero)
            'then getting the HDC and converting that to an Int32.
            hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc().ToInt32()

            initialized = True
        End Sub

        Public Shared Function SetBrightness(brightness As Short) As Boolean
            InitializeClass()

            If brightness > 255 Then
                brightness = 255
            End If

            If brightness < 0 Then
                brightness = 0
            End If
            Dim gArray As Pointer(Of Short) = stackalloc
            Dim idx As Pointer(Of Short) = gArray

            For j As Integer = 0 To 2
                For i As Integer = 0 To 255
                    Dim arrayVal As Integer = i * (brightness + 128)

                    If arrayVal > 65535 Then
                        arrayVal = 65535
                    End If

                    idx.Target = CShort(arrayVal)
                    idx += 1
                Next
            Next

            'For some reason, this always returns false?
            Dim retVal As Boolean = SetDeviceGammaRamp(hdc, gArray)

            'Memory allocated through stackalloc is automatically free'd
            'by the CLR.

            Return retVal

        End Function
End Class
#End If