
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
    Friend Class GlobalMouseListener
        Inherits MouseListener
        Private ReadOnly m_SystemDoubleClickTime As Integer
        Private m_PreviousClicked As MouseButtons
        Private m_PreviousClickedPosition As Point
        Private m_PreviousClickedTime As Integer

        Public Sub New()
            MyBase.New(HookHelper.HookGlobalMouse)
            m_SystemDoubleClickTime = MouseNativeMethods.GetDoubleClickTime()
        End Sub

        Protected Overrides Sub ProcessDown(ByRef e As MouseEventExtArgs)
            If IsDoubleClick(e) Then
                e = e.ToDoubleClickEventArgs()
            End If
            MyBase.ProcessDown(e)
        End Sub

        Protected Overrides Sub ProcessUp(ByRef e As MouseEventExtArgs)
            MyBase.ProcessUp(e)
            If e.Clicks = 2 Then
                StopDoubleClickWaiting()
            End If

            If e.Clicks = 1 Then
                StartDoubleClickWaiting(e)
            End If
        End Sub

        Private Sub StartDoubleClickWaiting(e As MouseEventExtArgs)
            m_PreviousClicked = e.Button
            m_PreviousClickedTime = e.Timestamp
            m_PreviousClickedPosition = e.Point
        End Sub

        Private Sub StopDoubleClickWaiting()
            m_PreviousClicked = MouseButtons.None
            m_PreviousClickedTime = 0
            m_PreviousClickedPosition = New Point(0, 0)
        End Sub

        Private Function IsDoubleClick(e As MouseEventExtArgs) As Boolean
            ' Click-move-click exception, see Patch 11222
            Return e.Button = m_PreviousClicked AndAlso e.Point = m_PreviousClickedPosition AndAlso e.Timestamp - m_PreviousClickedTime <= m_SystemDoubleClickTime
        End Function

        Protected Overrides Function GetEventArgs(data As CallbackData) As MouseEventExtArgs
            Return MouseEventExtArgs.FromRawDataGlobal(data)
        End Function

        Protected Overrides Function Callback(data As CallbackData) As Boolean
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
