
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Windows.Forms

Namespace Gma.System.MouseKeyHook.Implementation
	Friend MustInherit Class EventFacade
		Implements IKeyboardMouseEvents
		Private m_KeyListenerCache As KeyListener
		Private m_MouseListenerCache As MouseListener

        Public Custom Event KeyDown As KeyEventHandler Implements IKeyboardEvents.KeyDown
            AddHandler(ByVal value As KeyEventHandler)
                AddHandler GetKeyListener().KeyDown, value
            End AddHandler
            RemoveHandler(ByVal value As KeyEventHandler)
                RemoveHandler GetKeyListener().KeyDown, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As KeyEventArgsExt)
            End RaiseEvent
        End Event

        Public Custom Event KeyPress As KeyPressEventHandler Implements IKeyboardEvents.KeyPress
            AddHandler(ByVal value As KeyPressEventHandler)
                AddHandler GetKeyListener().KeyPress, value
            End AddHandler
            RemoveHandler(ByVal value As KeyPressEventHandler)
                RemoveHandler GetKeyListener().KeyPress, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As KeyPressEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event KeyUp As KeyEventHandler Implements IKeyboardEvents.KeyUp
            AddHandler(ByVal value As KeyEventHandler)
                AddHandler GetKeyListener().KeyUp, value
            End AddHandler
            RemoveHandler(ByVal value As KeyEventHandler)
                RemoveHandler GetKeyListener().KeyUp, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As KeyEventArgsExt)
            End RaiseEvent
        End Event

        Public Custom Event MouseMove As MouseEventHandler Implements IMouseEvents.MouseMove
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseMove, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseMove, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseMoveExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseMoveExt
            AddHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                AddHandler GetMouseListener().MouseMoveExt, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                RemoveHandler GetMouseListener().MouseMoveExt, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseClick As MouseEventHandler Implements IMouseEvents.MouseClick
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseClick, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseClick, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDown As MouseEventHandler Implements IMouseEvents.MouseDown
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseDown, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseDown, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDownExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseDownExt
            AddHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                AddHandler GetMouseListener().MouseDownExt, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                RemoveHandler GetMouseListener().MouseDownExt, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseUp As MouseEventHandler Implements IMouseEvents.MouseUp
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseUp, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseUp, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseUpExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseUpExt
            AddHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                AddHandler GetMouseListener().MouseUpExt, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                RemoveHandler GetMouseListener().MouseUpExt, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseWheel As MouseEventHandler Implements IMouseEvents.MouseWheel
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseWheel, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseWheel, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseWheelExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseWheelExt
            AddHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                AddHandler GetMouseListener().MouseWheelExt, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                RemoveHandler GetMouseListener().MouseWheelExt, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDoubleClick As MouseEventHandler Implements IMouseEvents.MouseDoubleClick
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseDoubleClick, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseDoubleClick, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDragStarted As MouseEventHandler Implements IMouseEvents.MouseDragStarted
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseDragStarted, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseDragStarted, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDragStartedExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseDragStartedExt
            AddHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                AddHandler GetMouseListener().MouseDragStartedExt, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                RemoveHandler GetMouseListener().MouseDragStartedExt, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDragFinished As MouseEventHandler Implements IMouseEvents.MouseDragFinished
            AddHandler(ByVal value As MouseEventHandler)
                AddHandler GetMouseListener().MouseDragFinished, value
            End AddHandler
            RemoveHandler(ByVal value As MouseEventHandler)
                RemoveHandler GetMouseListener().MouseDragFinished, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Custom Event MouseDragFinishedExt As EventHandler(Of MouseEventExtArgs) Implements IMouseEvents.MouseDragFinishedExt
            AddHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                AddHandler GetMouseListener().MouseDragFinishedExt, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MouseEventExtArgs))
                RemoveHandler GetMouseListener().MouseDragFinishedExt, value
            End RemoveHandler
            RaiseEvent(sender As Object, e As MouseEventArgs)
            End RaiseEvent
        End Event

        Public Sub Dispose() Implements IDisposable.Dispose
            If m_MouseListenerCache IsNot Nothing Then
                m_MouseListenerCache.Dispose()
            End If
            If m_KeyListenerCache IsNot Nothing Then
                m_KeyListenerCache.Dispose()
            End If
        End Sub

        Private Function GetKeyListener() As KeyListener
            Dim target = m_KeyListenerCache
            If target IsNot Nothing Then
                Return target
            End If
            target = CreateKeyListener()
            m_KeyListenerCache = target
            Return target
        End Function

        Private Function GetMouseListener() As MouseListener
			Dim target = m_MouseListenerCache
			If target IsNot Nothing Then
				Return target
			End If
			target = CreateMouseListener()
			m_MouseListenerCache = target
			Return target
		End Function

		Protected MustOverride Function CreateMouseListener() As MouseListener
		Protected MustOverride Function CreateKeyListener() As KeyListener
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
