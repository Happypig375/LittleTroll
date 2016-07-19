Option Strict On
Option Explicit On
Imports System.Threading
Imports System.Reflection
Imports System.Runtime.InteropServices
Public Class HookTest
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HookKeyboardS()
        apiSystemParametersInfoA(SPI_SETKEYBOARDDELAY, -1, 0, 0)
        apiSystemParametersInfoA(SPI_SETKEYBOARDSPEED, 1, 0, 0)
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        UnhookKeyboardS()
        apiSystemParametersInfoA(SPI_SETKEYBOARDDELAY, 20, 0, 0)
        apiSystemParametersInfoA(SPI_SETKEYBOARDSPEED, 20, 0, 0)
    End Sub

    Public Function IsHooked(ByRef Hookstruct As KBDLLHOOKSTRUCT) As Boolean
        On Error Resume Next

        ' block task manager from the ctrl alt delete combo
        If (Hookstruct.vkCode = Keys.Delete OrElse CBool(apiGetAsyncKeyState(Keys.Delete) And &H8000) = True) AndAlso (Hookstruct.vkCode = VK_CONTROL OrElse CBool(apiGetAsyncKeyState(VK_CONTROL) And &H8000) = True) AndAlso (Hookstruct.vkCode = Keys.Menu OrElse CBool(apiGetAsyncKeyState(Keys.Menu) And &H8000) = True) Then Return KillTaskMgr()

        'block task manager from the control alt escape combo
        If (Hookstruct.vkCode = Keys.Escape OrElse CBool(apiGetAsyncKeyState(Keys.Escape) And &H8000) = True) AndAlso CBool(apiGetAsyncKeyState(VK_CONTROL) And &H8000) AndAlso CBool(apiGetAsyncKeyState(Keys.Shift) And &H8000) Then Return KillTaskMgr()

        If (Hookstruct.vkCode = Keys.RWin) Then Return True 'block right win key

        If (Hookstruct.vkCode = Keys.LWin) Then Return True 'block left win key   

        'Block ctrl escape  Stops from opening the start menu, as above with win keys.
        If CBool(apiGetAsyncKeyState(VK_CONTROL) And &H8000) = True AndAlso Hookstruct.vkCode = Keys.Escape Then Return True

        'Block control F4  Stops the closing of a window within an application without closing the main application
        If CBool(apiGetAsyncKeyState(VK_CONTROL) And &H8000) = True AndAlso Hookstruct.vkCode = Keys.F4 Then Return True

        'Block Alt F4 from directly closing this the application
        If CBool(apiGetAsyncKeyState(Keys.Menu) And &H8000) = True AndAlso Hookstruct.vkCode = Keys.F4 Then Return True

        'Block Alt Space Stops the opening of the titlebar menu, that can close the alt+f4 combo above
        If CBool(apiGetAsyncKeyState(Keys.Menu) And &H8000) = True AndAlso Hookstruct.vkCode = Keys.Space Then Return True

        'Stop from switching focus to previous application
        If CBool(apiGetAsyncKeyState(Keys.Menu) And &H8000) = True AndAlso Hookstruct.vkCode = Keys.Tab Then Return True

        'Stop from switching focus to previous application
        If CBool(apiGetAsyncKeyState(Keys.Menu) And &H8000) = True AndAlso Hookstruct.vkCode = Keys.Escape Then Return True

        'block any keys you like here, ie a.
        '  If Hookstruct.vkCode = Keys.A Then Return True


        Return False
    End Function
    Public Function KillTaskMgr() As Boolean
        On Error Resume Next
        Dim i As Int32
        Do
            Dim clt() As Process = Process.GetProcessesByName("taskmgr")
            For Each p As Process In clt
                p.Kill()
            Next
            Thread.Sleep(1)
            i += 1
            If i = 200 Then Exit Do 'Set this no larger then the registry's timeout for keyboard hooks.  TODO
        Loop
    End Function

    Const VK_CONTROL As Int32 = &H11
    Const SPI_SETKEYBOARDDELAY As Int32 = 23
    Const SPI_SETKEYBOARDSPEED As Int32 = 11
    Public Structure KBDLLHOOKSTRUCT
        Public vkCode, scanCode, flags, time, dwExtraInfo As Int32
    End Structure
    Public Delegate Function KeyboardHookDelegate(ByVal Code As Int32, ByVal wParam As Int32, ByRef lParam As KBDLLHOOKSTRUCT) As Int32
    <MarshalAs(UnmanagedType.FunctionPtr)> Private callback As KeyboardHookDelegate
    Public KeyboardHandle As Int32
    Private Declare Function apiGetAsyncKeyState Lib "user32" Alias "GetAsyncKeyState" (ByVal vKey As Int32) As Int32
    Private Declare Function apiSetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Int32, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Int32, ByVal dwThreadId As Int32) As Int32
    Private Declare Function apiCallNextHookEx Lib "user32" Alias "CallNextHookEx" (ByVal hHook As Int32, ByVal nCode As Int32, ByVal wParam As Int32, ByVal lParam As KBDLLHOOKSTRUCT) As Int32
    Private Declare Function apiUnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal hHook As Int32) As Int32
    Private Declare Function apiSystemParametersInfoA Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Int32, ByVal uParam As Int32, ByVal lpvParam As Int32, ByVal fuWinIni As Int32) As Int32
    Dim clt() As Process = Process.GetProcessesByName("taskmgr")
    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        KeyboardHandle = apiSetWindowsHookEx(13&, callback, Marshal.GetHINSTANCE([Assembly].GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
    End Sub
    Public Sub UnhookKeyboard()
        If Hooked() = True Then Call apiUnhookWindowsHookEx(KeyboardHandle)
    End Sub
    Private Function Hooked() As Boolean
        Return KeyboardHandle <> 0
    End Function


    Public Function KeyboardCallback(ByVal Code As Int32, ByVal wParam As Int32, ByRef lParam As KBDLLHOOKSTRUCT) As Int32
        If Code = HC_ACTION AndAlso IsHooked(lParam) = True Then Return 1
        Return apiCallNextHookEx(KeyboardHandle, Code, wParam, lParam)
    End Function




    Public Function IsHookedS(ByRef Hookstruct As KBDLLHOOKSTRUCT) As Boolean
        On Error Resume Next

        If Hookstruct.flags <> 128 Then 'Do this on key down only.  the flag for key up is 0.
            If Hookstruct.vkCode = Keys.A Then 'If a key is pressed
                apikeybd_event(CByte(Keys.Z), 0, 0, 0) 'press any key. (z in this example)
                Return True
            End If

            'Repeat this skeleton for any key, or combo!!!  
            'If Hookstruct.vkCode = Keys.A Then
            '    apikeybd_event(Keys.Z, 0, 0, 0)
            '    Return True
            'End If
        End If

        Return False
    End Function
    Const HC_ACTION As Int32 = 0
    Const WH_KEYBOARD_LL As Int32 = 13
    Public Declare Sub apikeybd_event Lib "user32.dll" Alias "keybd_event" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Int32, ByVal dwExtraInfo As Int32)
    Public Sub HookKeyboardS()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        KeyboardHandle = apiSetWindowsHookEx(WH_KEYBOARD_LL, callback, Marshal.GetHINSTANCE([Assembly].GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
    End Sub
    Public Sub UnhookKeyboardS()
        If KeyboardHandle <> 0 Then apiUnhookWindowsHookEx(KeyboardHandle)
    End Sub
End Class