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
            'System.Text.RegularExpressions.Regex.IsMatch(e.CommandLine(0), "\A(?:[A-Z]|[a-z]):(?:/|\\).*")
            If e.CommandLine.Count <> 0 AndAlso My.Computer.FileSystem.FileExists(e.CommandLine(0)) Then
                Dim Reader As New IO.StreamReader(e.CommandLine(0))
                e.Cancel = True
                Editor.Execute(Reader.ReadToEnd, System.IO.Path.GetFileNameWithoutExtension(e.CommandLine(0)))
            End If
        End Sub

    End Class


End Namespace

