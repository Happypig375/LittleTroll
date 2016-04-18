Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Friend Enum RunMode As Byte
            QuestionMark = 0
            Normal = 1
            Batch = 2
            Interfer = 4
            Schoolbell = 8
            TrollSong = 24
            Trollface = 40
            TrollSongAndface = 56
        End Enum
        Public Class StartEventArgs
            Inherits System.EventArgs
            Public ReadOnly RunMode As RunMode
            Private NullArguments As Boolean
            Friend Sub New(_RunMode As RunMode, Optional NullArguments As Boolean = False)
                RunMode = _RunMode
                Me.NullArguments = NullArguments
            End Sub
            Friend SpecifiedArguments As New List(Of String)
            Friend Function RunModeHasFlag(Flag As Byte) As Boolean
                Return (Flag And RunMode) = RunMode
            End Function
            Public Shared Operator =(A As StartEventArgs, B As StartEventArgs)
                If A.NullArguments Or B.NullArguments Then
                    Return A.RunMode = B.RunMode
                Else
                    Return A.RunMode = B.RunMode And A.SpecifiedArguments.Equals(B.SpecifiedArguments)
                End If
            End Operator
            Public Shared Operator <>(A As StartEventArgs, B As StartEventArgs)
                If A.NullArguments Or B.NullArguments Then
                    Return A.RunMode <> B.RunMode
                Else
                    Return A.RunMode = B.RunMode And Not A.SpecifiedArguments.Equals(B.SpecifiedArguments)
                End If
            End Operator
        End Class
        Public Event CommandLineRead(sender As Object, e As StartEventArgs)
        Private Sub ReadCommandLine(ByVal sender As Object,
        ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim EArgs As New StartEventArgs(RunMode.Normal)
            My.Application.Log.WriteEntry("Application started at " &
                My.Computer.Clock.GmtTime.ToString)
            For Each s As String In My.Application.CommandLineArgs
                Select Case s.ToLower()
                    Case "/?"
                        'WriteLogEntry("Displayed application parameter help.",
                        '             TraceEventType.Information)
                        ' Stop the start form from loading.
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.QuestionMark)
                    Case "/batch"
                        'WriteLogEntry("Loaded batch mode.", TraceEventType.Information)
                        ' Stop the start form from loading.
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.Batch)
                    Case "/interfer"
                        'WriteLogEntry("Application started with interference.",
                        '             TraceEventType.Information)
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.Interfer)
                    Case "/troll:1"
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.Schoolbell)
                    Case "/troll:2"
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.TrollSong)
                    Case "/troll:3"
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.Trollface)
                    Case "/troll:4"
                        e.Cancel = True
                        EArgs = New StartEventArgs(EArgs.RunMode Or RunMode.TrollSongAndface)
                End Select
            Next
            If e.Cancel And EArgs.RunModeHasFlag(RunMode.Batch) Then
                ' Call the main routine for windowless operation.
                Dim c As New MyModes.BatchMode
                RaiseEvent CommandLineRead(sender, EArgs)
                c.Main()
            ElseIf e.Cancel And (EArgs.RunMode = RunMode.QuestionMark Or
                                 EArgs.RunMode - RunMode.QuestionMark = RunMode.Interfer) Then
                Dim c As New MyModes.BatchMode
                c.DisplayHelp(EArgs.RunModeHasFlag(RunMode.Interfer))
            ElseIf e.Cancel And EArgs.RunModeHasFlag(RunMode.Schoolbell) Then
                Dim Mode As New MyModes.MediaEmitMode(EArgs)
                RaiseEvent CommandLineRead(sender, EArgs)
                Mode.Main()
            Else
                RaiseEvent CommandLineRead(sender, EArgs)
            End If
        End Sub

    End Class


End Namespace

