
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi
Imports _375Script.Gma.System.MouseKeyHook.Implementation

Namespace Gma.System.MouseKeyHook
    ''' <summary>
    '''     Provides extended argument data for the <see cref='KeyListener.KeyDown' /> or
    '''     <see cref='KeyListener.KeyUp' /> event.
    ''' </summary>
    Public Class KeyEventArgsExt
        Inherits KeyEventArgs
        ''' <summary>
        '''     Initializes a new instance of the <see cref="KeyEventArgsExt" /> class.
        ''' </summary>
        ''' <param name="keyData"></param>
        Public Sub New(keyData As Keys)
            MyBase.New(keyData)
        End Sub

        Friend Sub New(keyData As Keys, timestamp__1 As Integer, isKeyDown__2 As Boolean, isKeyUp__3 As Boolean)
            Me.New(keyData)
            Timestamp = timestamp__1
            IsKeyDown = isKeyDown__2
            IsKeyUp = isKeyUp__3
        End Sub

        ''' <summary>
        '''     The system tick count of when the event occurred.
        ''' </summary>
        Public Property Timestamp() As Integer
            Get
                Return m_Timestamp
            End Get
            Private Set
                m_Timestamp = Value
            End Set
        End Property
        Private m_Timestamp As Integer

        ''' <summary>
        '''     True if event signals key down..
        ''' </summary>
        Public Property IsKeyDown() As Boolean
            Get
                Return m_IsKeyDown
            End Get
            Private Set
                m_IsKeyDown = Value
            End Set
        End Property
        Private m_IsKeyDown As Boolean

        ''' <summary>
        '''     True if event signals key up.
        ''' </summary>
        Public Property IsKeyUp() As Boolean
            Get
                Return m_IsKeyUp
            End Get
            Private Set
                m_IsKeyUp = Value
            End Set
        End Property
        Private m_IsKeyUp As Boolean

        Friend Shared Function FromRawDataApp(data As CallbackData) As KeyEventArgsExt
            Dim wParam = data.WParam
            Dim lParam = data.LParam

            'http://msdn.microsoft.com/en-us/library/ms644984(v=VS.85).aspx

            Const maskKeydown As UInteger = &H40000000
            ' for bit 30
            Const maskKeyup As UInteger = &H80000000UI
            ' for bit 31
            Dim timestamp As Integer = Environment.TickCount

            Dim flags = CUInt(lParam.ToInt64())

            'bit 30 Specifies the previous key state. The value is 1 if the key is down before the message is sent; it is 0 if the key is up.
            Dim wasKeyDown As Boolean = (flags And maskKeydown) > 0
            'bit 31 Specifies the transition state. The value is 0 if the key is being pressed and 1 if it is being released.
            Dim isKeyReleased As Boolean = (flags And maskKeyup) > 0

            Dim keyData As Keys = AppendModifierStates(CType(wParam, Keys))

            Dim isKeyDown As Boolean = Not isKeyReleased
            Dim isKeyUp As Boolean = wasKeyDown AndAlso isKeyReleased

            Return New KeyEventArgsExt(keyData, timestamp, isKeyDown, isKeyUp)
        End Function

        Friend Shared Function FromRawDataGlobal(data As CallbackData) As KeyEventArgsExt
            Dim wParam = data.WParam
            Dim lParam = data.LParam
            Dim keyboardHookStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(KeyboardHookStruct)), KeyboardHookStruct)
            Dim keyData = AppendModifierStates(DirectCast(keyboardHookStruct.VirtualKeyCode, Keys))

            Dim keyCode = CInt(wParam)
            Dim isKeyDown As Boolean = (keyCode = Messages.WM_KEYDOWN OrElse keyCode = Messages.WM_SYSKEYDOWN)
            Dim isKeyUp As Boolean = (keyCode = Messages.WM_KEYUP OrElse keyCode = Messages.WM_SYSKEYUP)

            Return New KeyEventArgsExt(keyData, keyboardHookStruct.Time, isKeyDown, isKeyUp)
        End Function

        ' # It is not possible to distinguish Keys.LControlKey and Keys.RControlKey when they are modifiers
        ' Check for Keys.Control instead
        ' Same for Shift and Alt(Menu)
        ' See more at http://www.tech-archive.net/Archive/DotNet/microsoft.public.dotnet.framework.windowsforms/2008-04/msg00127.html #

        ' A shortcut to make life easier
        Private Shared Function CheckModifier(vKey As Integer) As Boolean
            Return (KeyboardNativeMethods.GetKeyState(vKey) And &H8000) > 0
        End Function

        Private Shared Function AppendModifierStates(keyData As Keys) As Keys
            ' Is Control being held down?
            Dim control As Boolean = CheckModifier(KeyboardNativeMethods.VK_CONTROL)
            ' Is Shift being held down?
            Dim shift As Boolean = CheckModifier(KeyboardNativeMethods.VK_SHIFT)
            ' Is Alt being held down?
            Dim alt As Boolean = CheckModifier(KeyboardNativeMethods.VK_MENU)

            ' Windows keys
            ' # combine LWin and RWin key with other keys will potentially corrupt the data
            ' notable F5 | Keys.LWin == F12, see https://globalmousekeyhook.codeplex.com/workitem/1188
            ' and the KeyEventArgs.KeyData don't recognize combined data either

            ' Function (Fn) key
            ' # CANNOT determine state due to conversion inside keyboard
            ' See http://en.wikipedia.org/wiki/Fn_key#Technical_details #

            Return keyData Or (If(control, Keys.Control, Keys.None)) Or (If(shift, Keys.Shift, Keys.None)) Or (If(alt, Keys.Alt, Keys.None))
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
