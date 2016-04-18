Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Partial Friend Class MyModes
            Public Class MediaEmitMode
                Private EArgs As StartEventArgs = Nothing
                Sub New(EArgs As StartEventArgs)
                    Me.EArgs = EArgs
                End Sub
                Sub Main()
                    If EArgs = Nothing Then Throw New NullReferenceException("New instance method must be used.")
                    Select Case EArgs.RunMode
                        Case RunMode.Schoolbell
                        Case RunMode.TrollSong
                        Case RunMode.Trollface
                        Case RunMode.TrollSongAndface
                        Case Else
                    End Select
                End Sub
            End Class
        End Class
    End Class
End Namespace