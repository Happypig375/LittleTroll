
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Windows.Forms

Namespace Gma.System.MouseKeyHook
	''' <summary>
	'''     Provides all mouse events.
	''' </summary>
	Public Interface IMouseEvents
		''' <summary>
		'''     Occurs when the mouse pointer is moved.
		''' </summary>
		Event MouseMove As MouseEventHandler

		''' <summary>
		'''     Occurs when the mouse pointer is moved.
		''' </summary>
		''' <remarks>
		'''     This event provides extended arguments of type <see cref="MouseEventArgs" /> enabling you to
		'''     suppress further processing of mouse movement in other applications.
		''' </remarks>
		Event MouseMoveExt As EventHandler(Of MouseEventExtArgs)

		''' <summary>
		'''     Occurs when a click was performed by the mouse.
		''' </summary>
		Event MouseClick As MouseEventHandler

		''' <summary>
		'''     Occurs when the mouse a mouse button is pressed.
		''' </summary>
		Event MouseDown As MouseEventHandler

		''' <summary>
		'''     Occurs when the mouse a mouse button is pressed.
		''' </summary>
		''' <remarks>
		'''     This event provides extended arguments of type <see cref="MouseEventArgs" /> enabling you to
		'''     suppress further processing of mouse click in other applications.
		''' </remarks>
		Event MouseDownExt As EventHandler(Of MouseEventExtArgs)

		''' <summary>
		'''     Occurs when a mouse button is released.
		''' </summary>
		Event MouseUp As MouseEventHandler

		''' <summary>
		''' Occurs when a mouse button is released.
		''' </summary>
		''' <remarks>
		'''     This event provides extended arguments of type <see cref="MouseEventArgs" /> enabling you to
		'''     suppress further processing of mouse click in other applications.
		''' </remarks>
		Event MouseUpExt As EventHandler(Of MouseEventExtArgs)


		''' <summary>
		'''     Occurs when the mouse wheel moves.
		''' </summary>
		Event MouseWheel As MouseEventHandler

		''' <summary>
		'''     Occurs when the mouse wheel moves.
		''' </summary>
		''' <remarks>
		'''     This event provides extended arguments of type <see cref="MouseEventArgs" /> enabling you to
		'''     suppress further processing of mouse wheel moves in other applications.
		''' </remarks>
		Event MouseWheelExt As EventHandler(Of MouseEventExtArgs)

		''' <summary>
		'''     Occurs when a mouse button is double-clicked.
		''' </summary>
		Event MouseDoubleClick As MouseEventHandler

		''' <summary>
		'''     Occurs when a drag event has started (left button held down whilst moving more than the system drag threshold).
		''' </summary>
		Event MouseDragStarted As MouseEventHandler

		''' <summary>
		'''     Occurs when a drag event has started (left button held down whilst moving more than the system drag threshold).
		''' </summary>
		''' <remarks>
		'''     This event provides extended arguments of type <see cref="MouseEventArgs" /> enabling you to
		'''     suppress further processing of mouse movement in other applications.
		''' </remarks>
		Event MouseDragStartedExt As EventHandler(Of MouseEventExtArgs)

		''' <summary>
		'''     Occurs when a drag event has completed.
		''' </summary>
		Event MouseDragFinished As MouseEventHandler

		''' <summary>
		'''     Occurs when a drag event has completed.
		''' </summary>
		''' <remarks>
		'''     This event provides extended arguments of type <see cref="MouseEventArgs" /> enabling you to
		'''     suppress further processing of mouse movement in other applications.
		''' </remarks>
		Event MouseDragFinishedExt As EventHandler(Of MouseEventExtArgs)
	End Interface
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
