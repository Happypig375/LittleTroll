
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Namespace Gma.System.MouseKeyHook.WinApi
	Friend NotInheritable Class Messages
		Private Sub New()
		End Sub
		'values from Winuser.h in Microsoft SDK.

		''' <summary>
		'''     The WM_MOUSEMOVE message is posted to a window when the cursor moves.
		''' </summary>
		Public Const WM_MOUSEMOVE As Integer = &H200

		''' <summary>
		'''     The WM_LBUTTONDOWN message is posted when the user presses the left mouse button
		''' </summary>
		Public Const WM_LBUTTONDOWN As Integer = &H201

		''' <summary>
		'''     The WM_RBUTTONDOWN message is posted when the user presses the right mouse button
		''' </summary>
		Public Const WM_RBUTTONDOWN As Integer = &H204

		''' <summary>
		'''     The WM_MBUTTONDOWN message is posted when the user presses the middle mouse button
		''' </summary>
		Public Const WM_MBUTTONDOWN As Integer = &H207

		''' <summary>
		'''     The WM_LBUTTONUP message is posted when the user releases the left mouse button
		''' </summary>
		Public Const WM_LBUTTONUP As Integer = &H202

		''' <summary>
		'''     The WM_RBUTTONUP message is posted when the user releases the right mouse button
		''' </summary>
		Public Const WM_RBUTTONUP As Integer = &H205

		''' <summary>
		'''     The WM_MBUTTONUP message is posted when the user releases the middle mouse button
		''' </summary>
		Public Const WM_MBUTTONUP As Integer = &H208

		''' <summary>
		'''     The WM_LBUTTONDBLCLK message is posted when the user double-clicks the left mouse button
		''' </summary>
		Public Const WM_LBUTTONDBLCLK As Integer = &H203

		''' <summary>
		'''     The WM_RBUTTONDBLCLK message is posted when the user double-clicks the right mouse button
		''' </summary>
		Public Const WM_RBUTTONDBLCLK As Integer = &H206

		''' <summary>
		'''     The WM_RBUTTONDOWN message is posted when the user presses the right mouse button
		''' </summary>
		Public Const WM_MBUTTONDBLCLK As Integer = &H209

		''' <summary>
		'''     The WM_MOUSEWHEEL message is posted when the user presses the mouse wheel.
		''' </summary>
		Public Const WM_MOUSEWHEEL As Integer = &H20a

		''' <summary>
		'''     The WM_XBUTTONDOWN message is posted when the user presses the first or second X mouse
		'''     button.
		''' </summary>
		Public Const WM_XBUTTONDOWN As Integer = &H20b

		''' <summary>
		'''     The WM_XBUTTONUP message is posted when the user releases the first or second X  mouse
		'''     button.
		''' </summary>
		Public Const WM_XBUTTONUP As Integer = &H20c

		''' <summary>
		'''     The WM_XBUTTONDBLCLK message is posted when the user double-clicks the first or second
		'''     X mouse button.
		''' </summary>
		''' <remarks>Only windows that have the CS_DBLCLKS style can receive WM_XBUTTONDBLCLK messages.</remarks>
		Public Const WM_XBUTTONDBLCLK As Integer = &H20d

		''' <summary>
		'''     The WM_MOUSEHWHEEL message Sent to the active window when the mouse's horizontal scroll
		'''     wheel is tilted or rotated.
		''' </summary>
		Public Const WM_MOUSEHWHEEL As Integer = &H20e

		''' <summary>
		'''     The WM_KEYDOWN message is posted to the window with the keyboard focus when a non-system
		'''     key is pressed. A non-system key is a key that is pressed when the ALT key is not pressed.
		''' </summary>
		Public Const WM_KEYDOWN As Integer = &H100

		''' <summary>
		'''     The WM_KEYUP message is posted to the window with the keyboard focus when a non-system
		'''     key is released. A non-system key is a key that is pressed when the ALT key is not pressed,
		'''     or a keyboard key that is pressed when a window has the keyboard focus.
		''' </summary>
		Public Const WM_KEYUP As Integer = &H101

		''' <summary>
		'''     The WM_SYSKEYDOWN message is posted to the window with the keyboard focus when the user
		'''     presses the F10 key (which activates the menu bar) or holds down the ALT key and then
		'''     presses another key. It also occurs when no window currently has the keyboard focus;
		'''     in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that
		'''     receives the message can distinguish between these two contexts by checking the context
		'''     code in the lParam parameter.
		''' </summary>
		Public Const WM_SYSKEYDOWN As Integer = &H104

		''' <summary>
		'''     The WM_SYSKEYUP message is posted to the window with the keyboard focus when the user
		'''     releases a key that was pressed while the ALT key was held down. It also occurs when no
		'''     window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent
		'''     to the active window. The window that receives the message can distinguish between
		'''     these two contexts by checking the context code in the lParam parameter.
		''' </summary>
		Public Const WM_SYSKEYUP As Integer = &H105
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
