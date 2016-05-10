Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Friend Sub Application_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Count = 0 Then Exit Sub
            'System.Text.RegularExpressions.Regex.IsMatch(e.CommandLine(0), "\A(?:[A-Z]|[a-z]):(?:/|\\).*")
            If My.Computer.FileSystem.FileExists(e.CommandLine(0)) Then
                Dim Reader As New IO.StreamReader(e.CommandLine(0))
                e.Cancel = True
                ExecuteScript(Reader.ReadToEnd)
            End If
        End Sub
        Friend Sub ExecuteScript(Input As String)
            For Each Line As String In Input.Split(Chr(10), Chr(13))
                Line = Trim(Line)
                If Line = "" Then Continue For
                Dim Content As String = Line.Substring(Line.IndexOf(" "c) + 1)
                Select Case Line.Split({" "c}, 2)(0).ToLower
                    Case "message"
                        MsgBox(Content)
                End Select
            Next
        End Sub
    End Class


End Namespace

