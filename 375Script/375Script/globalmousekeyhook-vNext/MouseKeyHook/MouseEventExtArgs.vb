
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook
    ''' <summary>
    '''     Provides extended data for the MouseClickExt and MouseMoveExt events.
    ''' </summary>
    Public Class MouseEventExtArgs
        Inherits MouseEventArgs
        ''' <summary>
        '''     Initializes a new instance of the <see cref="MouseEventExtArgs" /> class.
        ''' </summary>
        ''' <param name="buttons">One of the MouseButtons values indicating which mouse button was pressed.</param>
        ''' <param name="clicks">The number of times a mouse button was pressed.</param>
        ''' <param name="point">The x and y coordinate of a mouse click, in pixels.</param>
        ''' <param name="delta">A signed count of the number of detents the wheel has rotated.</param>
        ''' <param name="timestamp__1">The system tick count when the event occurred.</param>
        ''' <param name="isMouseButtonDown__2">True if event signals mouse button down.</param>
        ''' <param name="isMouseButtonUp__3">True if event signals mouse button up.</param>
        Friend Sub New(buttons As MouseButtons, clicks As Integer, point As WinApi.Point, delta As Integer, timestamp__1 As Integer, isMouseButtonDown__2 As Boolean,
            isMouseButtonUp__3 As Boolean)
            MyBase.New(buttons, clicks, point.X, point.Y, delta)
            IsMouseButtonDown = isMouseButtonDown__2
            IsMouseButtonUp = isMouseButtonUp__3
            Timestamp = timestamp__1
        End Sub

        ''' <summary>
        '''     Set this property to <b>true</b> inside your event handler to prevent further processing of the event in other
        '''     applications.
        ''' </summary>
        Public Property Handled() As Boolean
            Get
                Return m_Handled
            End Get
            Set
                m_Handled = Value
            End Set
        End Property
        Private m_Handled As Boolean

        ''' <summary>
        '''     True if event contains information about wheel scroll.
        ''' </summary>
        Public ReadOnly Property WheelScrolled() As Boolean
            Get
                Return Delta <> 0
            End Get
        End Property

        ''' <summary>
        '''     True if event signals a click. False if it was only a move or wheel scroll.
        ''' </summary>
        Public ReadOnly Property Clicked() As Boolean
            Get
                Return Clicks > 0
            End Get
        End Property

        ''' <summary>
        '''     True if event signals mouse button down.
        ''' </summary>
        Public Property IsMouseButtonDown() As Boolean
            Get
                Return m_IsMouseButtonDown
            End Get
            Private Set
                m_IsMouseButtonDown = Value
            End Set
        End Property
        Private m_IsMouseButtonDown As Boolean

        ''' <summary>
        '''     True if event signals mouse button up.
        ''' </summary>
        Public Property IsMouseButtonUp() As Boolean
            Get
                Return m_IsMouseButtonUp
            End Get
            Private Set
                m_IsMouseButtonUp = Value
            End Set
        End Property
        Private m_IsMouseButtonUp As Boolean

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
        ''' </summary>
        Friend ReadOnly Property Point() As WinApi.Point
            Get
                Return New WinApi.Point(X, Y)
            End Get
        End Property

        Friend Shared Function FromRawDataApp(data As CallbackData) As MouseEventExtArgs
            Dim wParam = data.WParam
            Dim lParam = data.LParam

            Dim marshalledMouseStruct As AppMouseStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(AppMouseStruct)), AppMouseStruct)
            Return FromRawDataUniversal(wParam, marshalledMouseStruct.ToMouseStruct())
        End Function

        Friend Shared Function FromRawDataGlobal(data As CallbackData) As MouseEventExtArgs
            Dim wParam = data.WParam
            Dim lParam = data.LParam

            Dim marshalledMouseStruct As MouseStruct = DirectCast(Marshal.PtrToStructure(lParam, GetType(MouseStruct)), MouseStruct)
            Return FromRawDataUniversal(wParam, marshalledMouseStruct)
        End Function

        ''' <summary>
        '''     Creates <see cref="MouseEventExtArgs" /> from relevant mouse data.
        ''' </summary>
        ''' <param name="wParam">First Windows Message parameter.</param>
        ''' <param name="mouseInfo">A MouseStruct containing information from which to construct MouseEventExtArgs.</param>
        ''' <returns>A new MouseEventExtArgs object.</returns>
        Private Shared Function FromRawDataUniversal(wParam As IntPtr, mouseInfo As MouseStruct) As MouseEventExtArgs
            Dim button As MouseButtons = MouseButtons.None
            Dim mouseDelta As Short = 0
            Dim clickCount As Integer = 0

            Dim isMouseButtonDown As Boolean = False
            Dim isMouseButtonUp As Boolean = False


            Select Case CLng(wParam)
                Case Messages.WM_LBUTTONDOWN
                    isMouseButtonDown = True
                    button = MouseButtons.Left
                    clickCount = 1
                    Exit Select
                Case Messages.WM_LBUTTONUP
                    isMouseButtonUp = True
                    button = MouseButtons.Left
                    clickCount = 1
                    Exit Select
                Case Messages.WM_LBUTTONDBLCLK
                    isMouseButtonDown = True
                    button = MouseButtons.Left
                    clickCount = 2
                    Exit Select
                Case Messages.WM_RBUTTONDOWN
                    isMouseButtonDown = True
                    button = MouseButtons.Right
                    clickCount = 1
                    Exit Select
                Case Messages.WM_RBUTTONUP
                    isMouseButtonUp = True
                    button = MouseButtons.Right
                    clickCount = 1
                    Exit Select
                Case Messages.WM_RBUTTONDBLCLK
                    isMouseButtonDown = True
                    button = MouseButtons.Right
                    clickCount = 2
                    Exit Select
                Case Messages.WM_MBUTTONDOWN
                    isMouseButtonDown = True
                    button = MouseButtons.Middle
                    clickCount = 1
                    Exit Select
                Case Messages.WM_MBUTTONUP
                    isMouseButtonUp = True
                    button = MouseButtons.Middle
                    clickCount = 1
                    Exit Select
                Case Messages.WM_MBUTTONDBLCLK
                    isMouseButtonDown = True
                    button = MouseButtons.Middle
                    clickCount = 2
                    Exit Select
                Case Messages.WM_MOUSEWHEEL
                    mouseDelta = mouseInfo.MouseData
                    Exit Select
                Case Messages.WM_XBUTTONDOWN
                    button = If(mouseInfo.MouseData = 1, MouseButtons.XButton1, MouseButtons.XButton2)
                    isMouseButtonDown = True
                    clickCount = 1
                    Exit Select

                Case Messages.WM_XBUTTONUP
                    button = If(mouseInfo.MouseData = 1, MouseButtons.XButton1, MouseButtons.XButton2)
                    isMouseButtonUp = True
                    clickCount = 1
                    Exit Select

                Case Messages.WM_XBUTTONDBLCLK
                    isMouseButtonDown = True
                    button = If(mouseInfo.MouseData = 1, MouseButtons.XButton1, MouseButtons.XButton2)
                    clickCount = 2
                    Exit Select

                Case Messages.WM_MOUSEHWHEEL
                    mouseDelta = mouseInfo.MouseData
                    Exit Select
            End Select

            Dim e = New MouseEventExtArgs(button, clickCount, mouseInfo.Point, mouseDelta, mouseInfo.Timestamp, isMouseButtonDown,
                isMouseButtonUp)

            Return e
        End Function

        Friend Function ToDoubleClickEventArgs() As MouseEventExtArgs
            Return New MouseEventExtArgs(Button, 2, Point, Delta, Timestamp, IsMouseButtonDown,
                IsMouseButtonUp)
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
