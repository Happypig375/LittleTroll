Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Friend ProcessList As Process()
        Friend WithEvents Timer As New Timer
        Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            e.Cancel = True
            ProcessList = Process.GetProcesses
            Timer.Enabled = True
            Timer.Interval = 100
            Timer.Start()
        End Sub
        Sub ProcessList_Update(sender As Object, e As EventArgs) Handles Timer.Tick
            For Each Process As Process In Process.GetProcesses
                If Not ProcessList.Contains(Process) Then
                    Process.Kill()
                    MsgBox("Application failed to start.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
                End If
            Next
        End Sub
    End Class


End Namespace

