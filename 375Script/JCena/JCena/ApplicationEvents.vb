Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Public ReadOnly File As Lazy(Of String) = New Lazy(Of String)(Function() IO.Path.Combine(My.Application.Info.DirectoryPath, "..\halo.txt"))
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Not My.Computer.FileSystem.FileExists(File.Value) Then IO.File.Create(File.Value)
            Dim A As String = My.Computer.FileSystem.ReadAllText(File.Value)
            If Not My.Application.CommandLineArgs.Contains("-s") Then
                If Not String.IsNullOrWhiteSpace(A) AndAlso IO.File.Exists(A) Then
                    Dim Player As New WMPLib.WindowsMediaPlayer()
                    Player.windowlessVideo = True
                    Player.URL = A
                    Player.controls.play()
                    While Player.playState = WMPLib.WMPPlayState.wmppsPlaying OrElse
                         Player.playState = WMPLib.WMPPlayState.wmppsTransitioning
                        My.Application.DoEvents()
                    End While
                End If
                End
            End If
        End Sub
    End Class


End Namespace

