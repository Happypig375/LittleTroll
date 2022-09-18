Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        ReadOnly TempIcon As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "MyCross.cur")
        ReadOnly TempBackground As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "MyBG.bmp")
        Dim OriginalBackground As String
        Dim SavedBackground As String
        Sub MyApplication_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim A As String() = IO.Directory.EnumerateFiles(IO.Path.Combine(Environment.GetEnvironmentVariable("AppData"),
                                                                "Microsoft\Windows\Themes")).ToArray
            Array.ForEach(A, Sub(s As String)
                                 If s.Contains("TranscodedWallpaper") Then
                                     OriginalBackground = s
                                     SavedBackground = New String(s.Take(s.LastIndexOf("."c)).ToArray) & "2" & IO.Path.GetExtension(s)
                                 End If
                             End Sub)
            SavedCursor1 = Icon.FromHandle(Cursors.Arrow.CopyHandle)
            SavedCursor2 = Icon.FromHandle(Cursors.AppStarting.CopyHandle)
            SavedCursor3 = Icon.FromHandle(Cursors.IBeam.CopyHandle)
            If CommandLineArgs.Contains("-c") Then
                SetCursor(My.Resources.Aero_Arrow)
            End If
            If CommandLineArgs.Contains("-b") Then
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, SavedBackground, SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)
            End If
            If CommandLineArgs.Contains("-bg") Then ResetBG()
            If CommandLineArgs.Count <> 0 Then End
            Try
                My.Computer.FileSystem.DeleteFile(SavedBackground)
            Catch
            End Try
            My.Computer.FileSystem.CopyFile(OriginalBackground, SavedBackground)
            SetCursor(Choose(Rnd(1, 2), My.Resources.Untitled_4, My.Resources.未命名_1__1_))
            SetBG()
        End Sub
        Sub SetBG()
            My.Computer.FileSystem.WriteAllBytes(TempBackground, ImageToByteArray(My.Resources.__2_png__1_), False)
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, TempBackground, SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)
        End Sub
        Sub ResetBG()
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, IO.Path.Combine(Environment.GetEnvironmentVariable("AppData"),
                                                            "Microsoft\Windows\Themes\XPWallpaper.jpg"),
                                                        SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)
        End Sub
        Sub SetCursor(ByVal Cursor As Byte())
            My.Computer.FileSystem.WriteAllBytes(TempIcon, Cursor, False)
            'Change arrow cursor to mine
            Dim NewCursor As IntPtr = LoadCursorFromFile(TempIcon)
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
            NewCursor = LoadCursorFromFile(TempIcon)
            'Set the system cursor
            If SetSystemCursor(NewCursor, IDC_APPSTARTING) = 0 Then
                'Error setting system cursor
                Debug.WriteLine("Error setting system cursor.")
                Return
            End If
        End Sub
        Private Function Rnd(ByVal Min As Byte, ByVal Max As Byte) As Byte
            Return (New Random).Next(Min, Max)
        End Function
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
        Dim SavedCursor1 As Icon
        Dim SavedCursor2 As Icon
        Dim SavedCursor3 As Icon
        Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shutdown, Me.UnhandledException

            'Get old cursor
            Dim OldCursor As IntPtr = SavedCursor1.Handle

            'Set the system cursor
            SetSystemCursor(OldCursor, IDC_ARROW)

            OldCursor = SavedCursor2.Handle

            'Set the system cursor
            SetSystemCursor(OldCursor, IDC_APPSTARTING)

            OldCursor = SavedCursor3.Handle

            'Set the system cursor
            SetSystemCursor(OldCursor, IDC_IBEAM)

            SavedCursor1.Dispose()
            SavedCursor2.Dispose()
            SavedCursor3.Dispose()
            My.Computer.FileSystem.CopyFile(SavedBackground, OriginalBackground)
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, OriginalBackground, SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)
        End Sub

        Public Const SPI_SETDESKWALLPAPER As Integer = 20
        Public Const SPIF_UPDATEINIFILE As Integer = 1
        Public Const SPIF_SENDCHANGE As Integer = 2

        <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, SetLastError:=True)> _
        Public Shared Function SystemParametersInfo(ByVal uAction As Integer, ByVal uParam As Integer,
                                                    ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
        End Function

        Private Sub SetWallPaper()
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, "filename.bmp", SPIF_UPDATEINIFILE Or SPIF_SENDCHANGE)
        End Sub

        Public Shared Function ImageToByte(ByVal img As Image) As Byte()
            Dim byteArray As Byte() = New Byte(-1) {}
            Using stream As New IO.MemoryStream()
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
                stream.Close()

                byteArray = stream.ToArray()
            End Using
            Return byteArray
        End Function

        Public Shared Function ImageToByteArray(ByVal x As Image) As Byte()
            Dim _imageConverter As New ImageConverter()
            Dim xByte As Byte() = DirectCast(_imageConverter.ConvertTo(x, GetType(Byte())), Byte())
            Return xByte
        End Function
    End Class


End Namespace

