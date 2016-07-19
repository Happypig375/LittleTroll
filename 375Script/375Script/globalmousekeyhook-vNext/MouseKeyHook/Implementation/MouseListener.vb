
' This code is distributed under MIT license.
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
    ' Because it is a P/Invoke method, 'GetSystemMetrics(int)'
    ' should be defined in a class named NativeMethods, SafeNativeMethods,
    ' or UnsafeNativeMethods.
    ' https://msdn.microsoft.com/en-us/library/windows/desktop/ms724385(v=vs.85).aspx
    Friend NotInheritable Class NativeMethods
        Private Sub New()
        End Sub
        Private Const SM_CXDRAG As Integer = 68
        Private Const SM_CYDRAG As Integer = 69

        <DllImport("user32.dll")>
        Private Shared Function GetSystemMetrics(index As Integer) As Integer
        End Function

        Public Shared Function GetXDragThreshold() As Integer
            Return GetSystemMetrics(SM_CXDRAG)
        End Function

        Public Shared Function GetYDragThreshold() As Integer
            Return GetSystemMetrics(SM_CYDRAG)
        End Function
    End Class

    Friend MustInherit Class MouseListener
        Inherits BaseListener
        Implements IMouseEvents
        Private ReadOnly m_xDragThreshold As Integer
        Private ReadOnly m_yDragThreshold As Integer

        Private ReadOnly m_DoubleDown As ButtonSet
        Private ReadOnly m_SingleDown As ButtonSet

        Private m_IsDragging As Boolean

        Private m_PreviousPosition As WinApi.Point
        Private m_DragStartPosition As WinApi.Point
        Private ReadOnly m_UninitialisedPoint As New WinApi.Point(-1, -1)

        Protected Sub New(subscribe As Subscribe)
            MyBase.New(subscribe)
            m_xDragThreshold = NativeMethods.GetXDragThreshold()
            m_yDragThreshold = NativeMethods.GetYDragThreshold()
            m_IsDragging = False

            m_PreviousPosition = m_UninitialisedPoint
            m_DragStartPosition = m_UninitialisedPoint

            m_DoubleDown = New ButtonSet()
            m_SingleDown = New ButtonSet()
        End Sub

        Protected Overrides Function Callback(data As CallbackData) As Boolean
            Dim e = GetEventArgs(data)

            If e.IsMouseButtonDown Then
                ProcessDown(e)
            End If

            If e.IsMouseButtonUp Then
                ProcessUp(e)
            End If

            If e.WheelScrolled Then
                ProcessWheel(e)
            End If

            If HasMoved(e.Point) Then
                ProcessMove(e)
            End If

            ProcessDrag(e)

            Return Not e.Handled
        End Function

        Protected MustOverride Function GetEventArgs(data As CallbackData) As MouseEventExtArgs

        Protected Overridable Sub ProcessWheel(ByRef e As MouseEventExtArgs)
            OnWheel(e)
            OnWheelExt(e)
        End Sub

        Protected Overridable Sub ProcessDown(ByRef e As MouseEventExtArgs)
            OnDown(e)
            OnDownExt(e)
            If e.Handled Then
                Return
            End If

            If e.Clicks = 2 Then
                m_DoubleDown.Add(e.Button)
            End If

            If e.Clicks = 1 Then
                m_SingleDown.Add(e.Button)
            End If
        End Sub

        Protected Overridable Sub ProcessUp(ByRef e As MouseEventExtArgs)
            If m_SingleDown.Contains(e.Button) Then
                OnUp(e)
                OnUpExt(e)
                If e.Handled Then
                    Return
                End If
                OnClick(e)
                m_SingleDown.Remove(e.Button)
            End If

            If m_DoubleDown.Contains(e.Button) Then
                e = e.ToDoubleClickEventArgs()
                OnUp(e)
                OnUpExt(e)
                OnDoubleClick(e)
                m_DoubleDown.Remove(e.Button)
            End If
        End Sub

        Private Sub ProcessMove(ByRef e As MouseEventExtArgs)
            m_PreviousPosition = e.Point

            OnMove(e)
            OnMoveExt(e)
        End Sub

        Private Sub ProcessDrag(ByRef e As MouseEventExtArgs)
            If m_SingleDown.Contains(MouseButtons.Left) Then
                If m_DragStartPosition.Equals(m_UninitialisedPoint) Then
                    m_DragStartPosition = e.Point
                End If

                ProcessDragStarted(e)
            Else
                m_DragStartPosition = m_UninitialisedPoint
                ProcessDragFinished(e)
            End If
        End Sub

        Private Sub ProcessDragStarted(ByRef e As MouseEventExtArgs)
            If Not m_IsDragging Then
                Dim isXDragging = Math.Abs(e.Point.X - m_DragStartPosition.X) > m_xDragThreshold
                Dim isYDragging = Math.Abs(e.Point.Y - m_DragStartPosition.Y) > m_yDragThreshold
                m_IsDragging = isXDragging OrElse isYDragging

                If m_IsDragging Then
                    OnDragStarted(e)
                    OnDragStartedExt(e)
                End If
            End If
        End Sub

        Private Sub ProcessDragFinished(ByRef e As MouseEventExtArgs)
            If m_IsDragging Then
                OnDragFinished(e)
                OnDragFinishedExt(e)
                m_IsDragging = False
            End If
        End Sub

        Private Function HasMoved(actualPoint As WinApi.Point) As Boolean
            Return m_PreviousPosition <> actualPoint
        End Function

        Public Event MouseMove As MouseEventHandler Implements IMouseEvents.MouseMove
        Public Event MouseMoveExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseMoveExt
        Public Event MouseClick As MouseEventHandler Implements IMouseEvents.MouseClick
        Public Event MouseDown As MouseEventHandler Implements IMouseEvents.MouseDown
        Public Event MouseDownExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseDownExt
        Public Event MouseUp As MouseEventHandler Implements IMouseEvents.MouseUp
        Public Event MouseUpExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseUpExt
        Public Event MouseWheel As MouseEventHandler Implements IMouseEvents.MouseWheel
        Public Event MouseWheelExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseWheelExt
        Public Event MouseDoubleClick As MouseEventHandler Implements IMouseEvents.MouseDoubleClick
        Public Event MouseDragStarted As MouseEventHandler Implements IMouseEvents.MouseDragStarted
        Public Event MouseDragStartedExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseDragStartedExt
        Public Event MouseDragFinished As MouseEventHandler Implements IMouseEvents.MouseDragFinished
        Public Event MouseDragFinishedExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseDragFinishedExt

        Protected Overridable Sub OnMove(e As MouseEventArgs)
            RaiseEvent MouseMove(Me, e)
        End Sub

        Protected Overridable Sub OnMoveExt(e As MouseEventExtArgs)
            RaiseEvent MouseMoveExt(Me, e)
        End Sub

        Protected Overridable Sub OnClick(e As MouseEventArgs)
            RaiseEvent MouseClick(Me, e)
        End Sub

        Protected Overridable Sub OnDown(e As MouseEventArgs)
            RaiseEvent MouseDown(Me, e)
        End Sub

        Protected Overridable Sub OnDownExt(e As MouseEventExtArgs)
            RaiseEvent MouseDownExt(Me, e)
        End Sub

        Protected Overridable Sub OnUp(e As MouseEventArgs)
            RaiseEvent MouseUp(Me, e)
        End Sub

        Protected Overridable Sub OnUpExt(e As MouseEventExtArgs)
            RaiseEvent MouseUpExt(Me, e)
        End Sub

        Protected Overridable Sub OnWheel(e As MouseEventArgs)
            RaiseEvent MouseWheel(Me, e)
        End Sub

        Protected Overridable Sub OnWheelExt(e As MouseEventExtArgs)
            RaiseEvent MouseWheelExt(Me, e)
        End Sub

        Protected Overridable Sub OnDoubleClick(e As MouseEventArgs)
            RaiseEvent MouseDoubleClick(Me, e)
        End Sub

        Protected Overridable Sub OnDragStarted(e As MouseEventArgs)
            RaiseEvent MouseDragStarted(Me, e)
        End Sub

        Protected Overridable Sub OnDragStartedExt(e As MouseEventExtArgs)
            RaiseEvent MouseDragStartedExt(Me, e)
        End Sub

        Protected Overridable Sub OnDragFinished(e As MouseEventArgs)
            RaiseEvent MouseDragFinished(Me, e)
        End Sub

        Protected Overridable Sub OnDragFinishedExt(e As MouseEventExtArgs)
            RaiseEvent MouseDragFinishedExt(Me, e)
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
