Imports System.Collections
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Public Class GUI

    <DllImport("user32.dll")> _
    Public Shared Function GetDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")> _
    Public Shared Function GetDeviceGammaRamp(ByVal hDC As IntPtr, ByRef lpRamp As RAMP) As Boolean
    End Function

    <DllImport("gdi32.dll")> _
    Public Shared Function SetDeviceGammaRamp(ByVal hDC As IntPtr, ByRef lpRamp As RAMP) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure RAMP
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)> _
        Public Red As UInt16()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)> _
        Public Green As UInt16()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=256)> _
        Public Blue As UInt16()
    End Structure

    Public Shared Sub SetGamma(ByVal gamma As Integer)
        If gamma <= 256 AndAlso gamma >= 1 Then
            Dim ramp As New RAMP()
            ramp.Red = New UShort(255) {}
            ramp.Green = New UShort(255) {}
            ramp.Blue = New UShort(255) {}
            For i As Integer = 1 To 255
                Dim iArrayValue As Integer = i * (gamma + 128)

                If iArrayValue > 65535 Then
                    iArrayValue = 65535
                End If
                ramp.Red(i) = InlineAssignHelper(ramp.Blue(i), InlineAssignHelper(ramp.Green(i), CUShort(iArrayValue)))
            Next
            SetDeviceGammaRamp(GetDC(IntPtr.Zero), ramp)
        End If
    End Sub

    Public Shared Sub Main(ByVal args As String())
        Dim ent As String = ""
        Dim g As Integer = 0
        While ent <> "EXIT"
            Console.WriteLine("Enter new Gamma (or 'EXIT' to quit):")
            ent = Console.ReadLine()
            Try
                g = Integer.Parse(ent)
                SetGamma(g)
                'Here only to catch errors where input is not a number (EXIT, for example, is a string)        
            Catch
            End Try
        End While
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Private Sub Brightness_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brightness.ValueChanged,
        MyBase.Shown
        SetGamma(Brightness.Value)
        BrightnessLabel.Text = Brightness.Value.ToString
    End Sub

    Private Sub GUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ramp As New RAMP()
        ramp.Red = New UShort(255) {}
        ramp.Green = New UShort(255) {}
        ramp.Blue = New UShort(255) {}
        GetDeviceGammaRamp(GetDC(IntPtr.Zero), ramp)
        BrightnessLabel.Text = ramp.Red(0).ToString
        For i As Integer = 1 To 255
            Dim iArrayValue As Integer ' = i * (gamma + 128)

            If iArrayValue > 65535 Then
                iArrayValue = 65535
            End If
            ramp.Red(i) = InlineAssignHelper(ramp.Blue(i), InlineAssignHelper(ramp.Green(i), CUShort(iArrayValue)))
        Next

        ImgStyle.Items.AddRange([Enum].GetValues(GetType(ImageLayout)).Cast(Of Object).ToArray)
        ImgStyle.SelectedIndex = 2
    End Sub
    Dim Filter As Overlay
    Private Sub ColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorButton.Click
        If ColorSel.ShowDialog = DialogResult.OK Then
#If False Then
            Using Bmp As New Bitmap(ColorDisplay.Width, ColorDisplay.Height)
                For i = 0 To ColorDisplay.Width - 1
                    For j = 0 To ColorDisplay.Height - 1
                        Bmp.SetPixel(i, j, ColorSel.Color)
                    Next
                Next
                ColorDisplay.Image = Bmp
            End Using
#Else
            ColorDisplay.BackgroundImage = Nothing
            ColorDisplay.BackColor = ColorSel.Color
            Filter = New Overlay(False, ColorSel.Color, FilterOpacity.Value / 100D, , , HideCursor.Checked)
            Filter.Show()
            Filter.Opacity = FilterOpacity.Value
#End If
        End If
    End Sub

    Private Sub ColorClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorClr.Click
        If Filter IsNot Nothing Then
            Filter.Dispose()
            Filter = Nothing
        End If
        ColorDisplay.BackgroundImage = Nothing
        ColorDisplay.BackColor = Nothing
        Cursor.Show()
    End Sub

    Private Sub ColorRbw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorRbw.Click
        Filter = New Overlay(True, Nothing, FilterOpacity.Value / 100D, , , HideCursor.Checked)
        ColorDisplay.BackColor = Nothing
        ColorDisplay.BackgroundImage = My.Resources.Icon_fw
        Filter.Show()
    End Sub

    Private Sub GUI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = "~"c Then ColorClr_Click(sender, e)
    End Sub

    Private Sub ColorRdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorRdm.Click
        Dim Random As Color = Overlay.RandomColour
        Filter = New Overlay(False, Random, FilterOpacity.Value / 100D, , , HideCursor.Checked)
        ColorDisplay.BackgroundImage = Nothing
        ColorDisplay.BackColor = Random
        Filter.Show()
    End Sub
#Region "HotKeys"
#Region "HotKey Processing"
    Enum HotkeyModifier As UShort
        None = &H0
        Alt = &H1 'Alt key
        Control = &H2
        Shift = &H4
        Windows = &H8
        WM_HOTKEY = &H312
        Norepeat = &H4000
    End Enum
    <Runtime.InteropServices.DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer, _
                                    ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    End Function
    Public Enum VirtualKeyCode As UInteger
        '''<summary>Left mouse button</summary>
        VK_LBUTTON = &H1
        '''<summary>Right mouse button</summary>
        VK_RBUTTON = &H2
        '''<summary>Control-break processing</summary>
        VK_CANCEL = &H3
        '''<summary>Middle mouse button (three-button mouse)</summary>
        VK_MBUTTON = &H4
        '''<summary>X1 mouse button</summary>
        VK_XBUTTON1 = &H5
        '''<summary>X2 mouse button</summary>
        VK_XBUTTON2 = &H6
        '''<summary>BACKSPACE key</summary>
        VK_BACK = &H8
        '''<summary>TAB key</summary>
        VK_TAB = &H9
        '''<summary>CLEAR key</summary>
        VK_CLEAR = &HC
        '''<summary>ENTER key</summary>
        VK_RETURN = &HD
        '''<summary>SHIFT key</summary>
        VK_SHIFT = &H10
        '''<summary>CTRL key</summary>
        VK_CONTROL = &H11
        '''<summary>ALT key</summary>
        VK_MENU = &H12
        '''<summary>PAUSE key</summary>
        VK_PAUSE = &H13
        '''<summary>CAPS LOCK key</summary>
        VK_CAPITAL = &H14
        '''<summary>IME Kana mode</summary>
        VK_KANA = &H15
        '''<summary>IME Hanguel mode (maintained for compatibility; use VK_HANGUL)</summary>
        VK_HANGUEL = &H15
        '''<summary>IME Hangul mode</summary>
        VK_HANGUL = &H15
        '''<summary>IME Junja mode</summary>
        VK_JUNJA = &H17
        '''<summary>IME final mode</summary>
        VK_FINAL = &H18
        '''<summary>IME Hanja mode</summary>
        VK_HANJA = &H19
        '''<summary>IME Kanji mode</summary>
        VK_KANJI = &H19
        '''<summary>ESC key</summary>
        VK_ESCAPE = &H1B
        '''<summary>IME convert</summary>
        VK_CONVERT = &H1C
        '''<summary>IME nonconvert</summary>
        VK_NONCONVERT = &H1D
        '''<summary>IME accept</summary>
        VK_ACCEPT = &H1E
        '''<summary>IME mode change request</summary>
        VK_MODECHANGE = &H1F
        '''<summary>SPACEBAR</summary>
        VK_SPACE = &H20
        '''<summary>PAGE UP key</summary>
        VK_PRIOR = &H21
        '''<summary>PAGE DOWN key</summary>
        VK_NEXT = &H22
        '''<summary>END key</summary>
        VK_END = &H23
        '''<summary>HOME key</summary>
        VK_HOME = &H24
        '''<summary>LEFT ARROW key</summary>
        VK_LEFT = &H25
        '''<summary>UP ARROW key</summary>
        VK_UP = &H26
        '''<summary>RIGHT ARROW key</summary>
        VK_RIGHT = &H27
        '''<summary>DOWN ARROW key</summary>
        VK_DOWN = &H28
        '''<summary>SELECT key</summary>
        VK_SELECT = &H29
        '''<summary>PRINT key</summary>
        VK_PRINT = &H2A
        '''<summary>EXECUTE key</summary>
        VK_EXECUTE = &H2B
        '''<summary>PRINT SCREEN key</summary>
        VK_SNAPSHOT = &H2C
        '''<summary>INS key</summary>
        VK_INSERT = &H2D
        '''<summary>DEL key</summary>
        VK_DELETE = &H2E
        '''<summary>HELP key</summary>
        VK_HELP = &H2F
        '''<summary>0 key</summary>
        K_0 = &H30
        '''<summary>1 key</summary>
        K_1 = &H31
        '''<summary>2 key</summary>
        K_2 = &H32
        '''<summary>3 key</summary>
        K_3 = &H33
        '''<summary>4 key</summary>
        K_4 = &H34
        '''<summary>5 key</summary>
        K_5 = &H35
        '''<summary>6 key</summary>
        K_6 = &H36
        '''<summary>7 key</summary>
        K_7 = &H37
        '''<summary>8 key</summary>
        K_8 = &H38
        '''<summary>9 key</summary>
        K_9 = &H39
        '''<summary>A key</summary>
        K_A = &H41
        '''<summary>B key</summary>
        K_B = &H42
        '''<summary>C key</summary>
        K_C = &H43
        '''<summary>D key</summary>
        K_D = &H44
        '''<summary>E key</summary>
        K_E = &H45
        '''<summary>F key</summary>
        K_F = &H46
        '''<summary>G key</summary>
        K_G = &H47
        '''<summary>H key</summary>
        K_H = &H48
        '''<summary>I key</summary>
        K_I = &H49
        '''<summary>J key</summary>
        K_J = &H4A
        '''<summary>K key</summary>
        K_K = &H4B
        '''<summary>L key</summary>
        K_L = &H4C
        '''<summary>M key</summary>
        K_M = &H4D
        '''<summary>N key</summary>
        K_N = &H4E
        '''<summary>O key</summary>
        K_O = &H4F
        '''<summary>P key</summary>
        K_P = &H50
        '''<summary>Q key</summary>
        K_Q = &H51
        '''<summary>R key</summary>
        K_R = &H52
        '''<summary>S key</summary>
        K_S = &H53
        '''<summary>T key</summary>
        K_T = &H54
        '''<summary>U key</summary>
        K_U = &H55
        '''<summary>V key</summary>
        K_V = &H56
        '''<summary>W key</summary>
        K_W = &H57
        '''<summary>X key</summary>
        K_X = &H58
        '''<summary>Y key</summary>
        K_Y = &H59
        '''<summary>Z key</summary>
        K_Z = &H5A
        '''<summary>Left Windows key (Natural keyboard)</summary>
        VK_LWIN = &H5B
        '''<summary>Right Windows key (Natural keyboard)</summary>
        VK_RWIN = &H5C
        '''<summary>Applications key (Natural keyboard)</summary>
        VK_APPS = &H5D
        '''<summary>Computer Sleep key</summary>
        VK_SLEEP = &H5F
        '''<summary>Numeric keypad 0 key</summary>
        VK_NUMPAD0 = &H60
        '''<summary>Numeric keypad 1 key</summary>
        VK_NUMPAD1 = &H61
        '''<summary>Numeric keypad 2 key</summary>
        VK_NUMPAD2 = &H62
        '''<summary>Numeric keypad 3 key</summary>
        VK_NUMPAD3 = &H63
        '''<summary>Numeric keypad 4 key</summary>
        VK_NUMPAD4 = &H64
        '''<summary>Numeric keypad 5 key</summary>
        VK_NUMPAD5 = &H65
        '''<summary>Numeric keypad 6 key</summary>
        VK_NUMPAD6 = &H66
        '''<summary>Numeric keypad 7 key</summary>
        VK_NUMPAD7 = &H67
        '''<summary>Numeric keypad 8 key</summary>
        VK_NUMPAD8 = &H68
        '''<summary>Numeric keypad 9 key</summary>
        VK_NUMPAD9 = &H69
        '''<summary>Multiply key</summary>
        VK_MULTIPLY = &H6A
        '''<summary>Add key</summary>
        VK_ADD = &H6B
        '''<summary>Separator key</summary>
        VK_SEPARATOR = &H6C
        '''<summary>Subtract key</summary>
        VK_SUBTRACT = &H6D
        '''<summary>Decimal key</summary>
        VK_DECIMAL = &H6E
        '''<summary>Divide key</summary>
        VK_DIVIDE = &H6F
        '''<summary>F1 key</summary>
        VK_F1 = &H70
        '''<summary>F2 key</summary>
        VK_F2 = &H71
        '''<summary>F3 key</summary>
        VK_F3 = &H72
        '''<summary>F4 key</summary>
        VK_F4 = &H73
        '''<summary>F5 key</summary>
        VK_F5 = &H74
        '''<summary>F6 key</summary>
        VK_F6 = &H75
        '''<summary>F7 key</summary>
        VK_F7 = &H76
        '''<summary>F8 key</summary>
        VK_F8 = &H77
        '''<summary>F9 key</summary>
        VK_F9 = &H78
        '''<summary>F10 key</summary>
        VK_F10 = &H79
        '''<summary>F11 key</summary>
        VK_F11 = &H7A
        '''<summary>F12 key</summary>
        VK_F12 = &H7B
        '''<summary>F13 key</summary>
        VK_F13 = &H7C
        '''<summary>F14 key</summary>
        VK_F14 = &H7D
        '''<summary>F15 key</summary>
        VK_F15 = &H7E
        '''<summary>F16 key</summary>
        VK_F16 = &H7F
        '''<summary>F17 key</summary>
        VK_F17 = &H80
        '''<summary>F18 key</summary>
        VK_F18 = &H81
        '''<summary>F19 key</summary>
        VK_F19 = &H82
        '''<summary>F20 key</summary>
        VK_F20 = &H83
        '''<summary>F21 key</summary>
        VK_F21 = &H84
        '''<summary>F22 key</summary>
        VK_F22 = &H85
        '''<summary>F23 key</summary>
        VK_F23 = &H86
        '''<summary>F24 key</summary>
        VK_F24 = &H87
        '''<summary>NUM LOCK key</summary>
        VK_NUMLOCK = &H90
        '''<summary>SCROLL LOCK key</summary>
        VK_SCROLL = &H91
        '''<summary>Left SHIFT key</summary>
        VK_LSHIFT = &HA0
        '''<summary>Right SHIFT key</summary>
        VK_RSHIFT = &HA1
        '''<summary>Left CONTROL key</summary>
        VK_LCONTROL = &HA2
        '''<summary>Right CONTROL key</summary>
        VK_RCONTROL = &HA3
        '''<summary>Left MENU key</summary>
        VK_LMENU = &HA4
        '''<summary>Right MENU key</summary>
        VK_RMENU = &HA5
        '''<summary>Browser Back key</summary>
        VK_BROWSER_BACK = &HA6
        '''<summary>Browser Forward key</summary>
        VK_BROWSER_FORWARD = &HA7
        '''<summary>Browser Refresh key</summary>
        VK_BROWSER_REFRESH = &HA8
        '''<summary>Browser Stop key</summary>
        VK_BROWSER_STOP = &HA9
        '''<summary>Browser Search key</summary>
        VK_BROWSER_SEARCH = &HAA
        '''<summary>Browser Favorites key</summary>
        VK_BROWSER_FAVORITES = &HAB
        '''<summary>Browser Start and Home key</summary>
        VK_BROWSER_HOME = &HAC
        '''<summary>Volume Mute key</summary>
        VK_VOLUME_MUTE = &HAD
        '''<summary>Volume Down key</summary>
        VK_VOLUME_DOWN = &HAE
        '''<summary>Volume Up key</summary>
        VK_VOLUME_UP = &HAF
        '''<summary>Next Track key</summary>
        VK_MEDIA_NEXT_TRACK = &HB0
        '''<summary>Previous Track key</summary>
        VK_MEDIA_PREV_TRACK = &HB1
        '''<summary>Stop Media key</summary>
        VK_MEDIA_STOP = &HB2
        '''<summary>Play/Pause Media key</summary>
        VK_MEDIA_PLAY_PAUSE = &HB3
        '''<summary>Start Mail key</summary>
        VK_LAUNCH_MAIL = &HB4
        '''<summary>Select Media key</summary>
        VK_LAUNCH_MEDIA_SELECT = &HB5
        '''<summary>Start Application 1 key</summary>
        VK_LAUNCH_APP1 = &HB6
        '''<summary>Start Application 2 key</summary>
        VK_LAUNCH_APP2 = &HB7
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key</summary>
        VK_OEM_1 = &HBA
        '''<summary>For any country/region, the '+' key</summary>
        VK_OEM_PLUS = &HBB
        '''<summary>For any country/region, the ',' key</summary>
        VK_OEM_COMMA = &HBC
        '''<summary>For any country/region, the '-' key</summary>
        VK_OEM_MINUS = &HBD
        '''<summary>For any country/region, the '.' key</summary>
        VK_OEM_PERIOD = &HBE
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key</summary>
        VK_OEM_2 = &HBF
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key</summary>
        VK_OEM_3 = &HC0
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key</summary>
        VK_OEM_4 = &HDB
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key</summary>
        VK_OEM_5 = &HDC
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key</summary>
        VK_OEM_6 = &HDD
        '''<summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key</summary>
        VK_OEM_7 = &HDE
        '''<summary>Used for miscellaneous characters; it can vary by keyboard.</summary>
        VK_OEM_8 = &HDF
        '''<summary>Either the angle bracket key or the backslash key on the RT 102-key keyboard</summary>
        VK_OEM_102 = &HE2
        '''<summary>IME PROCESS key</summary>
        VK_PROCESSKEY = &HE5
        '''<summary>Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP</summary>
        VK_PACKET = &HE7
        '''<summary>Attn key</summary>
        VK_ATTN = &HF6
        '''<summary>CrSel key</summary>
        VK_CRSEL = &HF7
        '''<summary>ExSel key</summary>
        VK_EXSEL = &HF8
        '''<summary>Erase EOF key</summary>
        VK_EREOF = &HF9
        '''<summary>Play key</summary>
        VK_PLAY = &HFA
        '''<summary>Zoom key</summary>
        VK_ZOOM = &HFB
        '''<summary>PA1 key</summary>
        VK_PA1 = &HFD
        '''<summary>Clear key</summary>
        VK_OEM_CLEAR = &HFE
    End Enum
    <Runtime.InteropServices.DllImport("User32.dll")> _
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, ExactSpelling:=True)>
    Public Shared Function GetAsyncKeyState(ByVal vkey As Integer) As Short
    End Function
    Public Shared ReadOnly Property KeyStatus(ByVal Key As Keys) As Boolean
        Get
            If Key = Keys.LButton AndAlso My.Computer.Mouse.ButtonsSwapped Then
                Key = Keys.RButton
            ElseIf Key = Keys.RButton AndAlso My.Computer.Mouse.ButtonsSwapped Then
                Key = Keys.LButton
            End If
            Return CBool(GetAsyncKeyState(Key) And &H8000US)
        End Get
    End Property
    Dim EnteringCtrlWinKey As Boolean
    Dim EnteringCtrlWinKeyCode As Integer
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = HotkeyModifier.WM_HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToInt32)
                Case 100
                    If Filter IsNot Nothing Then Filter.ForceClose()
                    ImgDisplay.Image = Nothing
                    Cursor.Show()
                Case 101
                    If Brightness.Value < 255 Then Brightness.Value += 1
                Case 102
                    If Brightness.Value > 1 Then Brightness.Value -= 1
                Case 111
                    If FilterOpacity.Value < 100 Then FilterOpacity.Value += 1
                Case 112
                    If FilterOpacity.Value > 0 Then FilterOpacity.Value -= 1
                Case 118
                    Brightness.Value = 100
                Case 119
                    FilterOpacity.Value = 40
                Case 400
                    If Not EnteringCtrlWinKey Then
                        RegisterHotKey(Me.Handle, 401, HotkeyModifier.None, Keys.D1)
                        RegisterHotKey(Me.Handle, 402, HotkeyModifier.None, Keys.D2)
                        RegisterHotKey(Me.Handle, 403, HotkeyModifier.None, Keys.D3)
                        RegisterHotKey(Me.Handle, 404, HotkeyModifier.None, Keys.D4)
                        RegisterHotKey(Me.Handle, 405, HotkeyModifier.None, Keys.D5)
                        RegisterHotKey(Me.Handle, 406, HotkeyModifier.None, Keys.D6)
                        RegisterHotKey(Me.Handle, 407, HotkeyModifier.None, Keys.D7)
                        RegisterHotKey(Me.Handle, 408, HotkeyModifier.None, Keys.D8)
                        RegisterHotKey(Me.Handle, 409, HotkeyModifier.None, Keys.D9)
                        RegisterHotKey(Me.Handle, 410, HotkeyModifier.None, Keys.D0)
                        RegisterHotKey(Me.Handle, 411, HotkeyModifier.None, Keys.NumPad1)
                        RegisterHotKey(Me.Handle, 412, HotkeyModifier.None, Keys.NumPad2)
                        RegisterHotKey(Me.Handle, 413, HotkeyModifier.None, Keys.NumPad3)
                        RegisterHotKey(Me.Handle, 414, HotkeyModifier.None, Keys.NumPad4)
                        RegisterHotKey(Me.Handle, 415, HotkeyModifier.None, Keys.NumPad5)
                        RegisterHotKey(Me.Handle, 416, HotkeyModifier.None, Keys.NumPad6)
                        RegisterHotKey(Me.Handle, 417, HotkeyModifier.None, Keys.NumPad7)
                        RegisterHotKey(Me.Handle, 418, HotkeyModifier.None, Keys.NumPad8)
                        RegisterHotKey(Me.Handle, 419, HotkeyModifier.None, Keys.NumPad9)
                        RegisterHotKey(Me.Handle, 420, HotkeyModifier.None, Keys.NumPad0)
                        RegisterHotKey(Me.Handle, 421, HotkeyModifier.None, Keys.Back)
                        RegisterHotKey(Me.Handle, 422, HotkeyModifier.None, Keys.Enter)
                        RegisterHotKey(Me.Handle, 423, HotkeyModifier.None, Keys.Escape)
                        RegisterHotKey(Me.Handle, 424, HotkeyModifier.None, Keys.OemMinus)
                        RegisterHotKey(Me.Handle, 425, HotkeyModifier.None, Keys.Subtract)
                    End If
                    EnteringCtrlWinKey = True
                    EnteringCtrlWinKeyCode = 0
                Case 401 To 409
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode) & Str(id.ToInt32 - 400))
                Case 410 To 419
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode) & Str(id.ToInt32 - 410))
                Case 420
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode) & "0")
                Case 421
                    EnteringCtrlWinKeyCode = CInt(Str(EnteringCtrlWinKeyCode).Reverse.ToString.Remove(0).Reverse.ToString)
                Case 422
                    UnregisterInputHotKey()
                Case 423
                    UnregisterInputHotKey()
                    EnteringCtrlWinKeyCode = 0
                Case 424, 425
                    EnteringCtrlWinKeyCode = -EnteringCtrlWinKeyCode
                Case 399
                    ShowHide()
            End Select
        End If
        MyBase.WndProc(m)

    End Sub
    Friend Sub UnregisterInputHotKey()
        EnteringCtrlWinKey = False
        For i As Integer = 401 To 425
            UnregisterHotKey(Me.Handle, i)
        Next
    End Sub

#End Region
    Friend Sub ShowHide()
        Me.TopMost = Not Me.TopMost
        If Me.TopMost Then
            Me.Show()
            Me.ClientSize = New Size(Me.RestoreBounds.X, Me.RestoreBounds.Y)
            'Me.ClientSize = RestoreSize
        Else : Me.Hide()
        End If
    End Sub
    Friend Sub Unregister(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UnregisterHotKey(Me.Handle, 100)
        UnregisterHotKey(Me.Handle, 101)
        UnregisterHotKey(Me.Handle, 102)
        UnregisterHotKey(Me.Handle, 111)
        UnregisterHotKey(Me.Handle, 112)
        UnregisterHotKey(Me.Handle, 118)
        UnregisterHotKey(Me.Handle, 119)
        UnregisterHotKey(Me.Handle, 399)
        UnregisterHotKey(Me.Handle, 400)
    End Sub


    Friend Sub Register(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RegisterHotKey(Me.Handle, 100, HotkeyModifier.Control Or HotkeyModifier.Alt, Keys.End)
        RegisterHotKey(Me.Handle, 101, HotkeyModifier.Control, Keys.Add)
        RegisterHotKey(Me.Handle, 102, HotkeyModifier.Control, Keys.Subtract)
        RegisterHotKey(Me.Handle, 111, HotkeyModifier.Control, Keys.Oemplus)
        RegisterHotKey(Me.Handle, 112, HotkeyModifier.Control Or HotkeyModifier.Shift, Keys.OemMinus)
        RegisterHotKey(Me.Handle, 118, HotkeyModifier.Control, Keys.D0)
        RegisterHotKey(Me.Handle, 119, HotkeyModifier.Control, Keys.NumPad0)
        'Experimenter^
        RegisterHotKey(Me.Handle, 400, HotkeyModifier.Control Or HotkeyModifier.Windows, Keys.None)
        RegisterHotKey(Me.Handle, 399, HotkeyModifier.Alt, Keys.None)
    End Sub

#End Region
    Private Sub FilterOpacity_ValueChanged(ByVal sender As System.Object,
                                           ByVal e As System.EventArgs) Handles FilterOpacity.ValueChanged,
                                       MyBase.Shown
        If FilterUsable Then Filter.Opacity = FilterOpacity.Value / 100
        OpacityLabel.Text = FilterOpacity.Value & "%"c
    End Sub

    Private Sub ImgButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImgButton.Click
        If ImgSel.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Filter Is Nothing Then
                Filter = New Overlay(False, Nothing,
                                     FilterOpacity.Value \ 100, New Bitmap(ImgSel.FileName),
                                     CType(ImgStyle.SelectedItem, ImageLayout), HideCursor.Checked)
                Else
                Filter = New Overlay(Filter.IsRandom, Filter.ChosenColor,
                                     CLng(Filter.Opacity) \ 100, New Bitmap(ImgSel.FileName),
                                     CType(ImgStyle.SelectedItem, ImageLayout), HideCursor.Checked)
                End If
            ImgDisplay.Image =
                New Bitmap(ImgSel.FileName).GetThumbnailImage(ImgDisplay.Width,
                                      ImgDisplay.Height,
                                      New Image.GetThumbnailImageAbort(Function() False),
                                      IntPtr.Zero)
                Filter.Show()
        End If
    End Sub

    Private ReadOnly Property FilterUsable() As Boolean
        Get
            Return Filter IsNot Nothing AndAlso Not Filter.IsDisposed
        End Get
    End Property

    Private Sub ShowFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowFilter.Click
        If Filter Is Nothing Then
            Filter = New Overlay(False, Nothing,
                                 CDec(FilterOpacity.Value / 100), If(ImgSel.FileName = "", Nothing, New Bitmap(ImgSel.FileName)),
                                 CType(ImgStyle.SelectedItem, ImageLayout), HideCursor.Checked)
        Else
            Filter = New Overlay(Filter.IsRandom, Filter.ChosenColor,
                                 CDec(Filter.Opacity / 100), If(ImgSel.FileName = "", Nothing, New Bitmap(ImgSel.FileName)),
                                 CType(ImgStyle.SelectedItem, ImageLayout), HideCursor.Checked)
        End If
        Filter.Show()
    End Sub
End Class
