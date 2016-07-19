
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook
    ''' <summary>
    '''     Provides extended data for the <see cref='KeyListener.KeyPress' /> event.
    ''' </summary>
    Public Class KeyPressEventArgsExt
        Inherits KeyPressEventArgs
        Friend Sub New(keyChar As Char, timestamp__1 As Integer)
            MyBase.New(keyChar)
            IsNonChar = keyChar = Chr(&H0)
            Timestamp = timestamp__1
        End Sub

        ''' <summary>
        '''     Initializes a new instance of the <see cref='KeyPressEventArgsExt' /> class.
        ''' </summary>
        ''' <param name="keyChar">
        '''     Character corresponding to the key pressed. 0 char if represents a system or functional non char
        '''     key.
        ''' </param>
        Public Sub New(keyChar As Char)
            Me.New(keyChar, Environment.TickCount)
        End Sub

        ''' <summary>
        '''     True if represents a system or functional non char key.
        ''' </summary>
        Public Property IsNonChar() As Boolean
            Get
                Return m_IsNonChar
            End Get
            Private Set
                m_IsNonChar = Value
            End Set
        End Property
        Private m_IsNonChar As Boolean

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

        Friend Shared Function FromRawDataApp(data As CallbackData) As IEnumerable(Of KeyPressEventArgsExt)
            Dim wParam = data.WParam
            Dim lParam = data.LParam

            'http://msdn.microsoft.com/en-us/library/ms644984(v=VS.85).aspx

            Const maskKeydown As UInteger = &H40000000
            ' for bit 30
            Const maskKeyup As UInteger = &H80000000UI
            ' for bit 31
            Const maskScanCode As UInteger = &HFF0000
            ' for bit 23-16
            Dim flags = CUInt(lParam.ToInt64())

            'bit 30 Specifies the previous key state. The value is 1 if the key is down before the message is sent; it is 0 if the key is up.
            Dim wasKeyDown = (flags And maskKeydown) > 0
            'bit 31 Specifies the transition state. The value is 0 if the key is being pressed and 1 if it is being released.
            Dim isKeyReleased = (flags And maskKeyup) > 0

            If Not wasKeyDown AndAlso Not isKeyReleased Then
                Exit Function
            End If

            Dim virtualKeyCode = CInt(wParam)
            Dim scanCode = CInt(flags And maskScanCode)
            Const fuState As Integer = 0

            Dim chars As Char()

            KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, scanCode, fuState, chars)
            If chars Is Nothing Then
                Exit Function
            End If
            For Each ch As Char In chars
                Return New KeyPressEventArgsExt(ch)
            Next
        End Function

        Friend Shared Function FromRawDataGlobal(data As CallbackData) As IEnumerable(Of KeyPressEventArgsExt)
            Dim wParam = data.WParam
            Dim lParam = data.LParam

            If CInt(wParam) <> Messages.WM_KEYDOWN AndAlso CInt(wParam) <> Messages.WM_SYSKEYDOWN Then
                Exit Function
            End If

            Dim keyboardHookStruct As KeyboardHookStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(KeyboardHookStruct)), KeyboardHookStruct)

            Dim virtualKeyCode = keyboardHookStruct.VirtualKeyCode
            Dim scanCode = keyboardHookStruct.ScanCode
            Dim fuState = keyboardHookStruct.Flags

            If virtualKeyCode = KeyboardNativeMethods.VK_PACKET Then
                Dim ch = Chr(scanCode)
                Return New KeyPressEventArgsExt(ch, keyboardHookStruct.Time)
            Else
                Dim chars As Char()
                KeyboardNativeMethods.TryGetCharFromKeyboardState(virtualKeyCode, scanCode, fuState, chars)
                If chars Is Nothing Then
                    Exit Function
                End If
                For Each current As Char In chars
                    Return New KeyPressEventArgsExt(current, keyboardHookStruct.Time)
                Next
            End If
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
