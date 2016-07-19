
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices

Namespace Gma.System.MouseKeyHook.WinApi
	Friend NotInheritable Class ThreadNativeMethods
		Private Sub New()
		End Sub
		''' <summary>
		'''     Retrieves the unmanaged thread identifier of the calling thread.
		''' </summary>
		''' <returns></returns>
		<DllImport("kernel32")> _
		Friend Shared Function GetCurrentThreadId() As Integer
		End Function

		''' <summary>
		'''     Retrieves a handle to the foreground window (the window with which the user is currently working).
		'''     The system assigns a slightly higher priority to the thread that creates the foreground window than it does to
		'''     other threads.
		''' </summary>
		''' <returns></returns>
		<DllImport("user32.dll", CharSet := CharSet.Auto)> _
		Friend Shared Function GetForegroundWindow() As IntPtr
		End Function

		''' <summary>
		'''     Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the
		'''     process that
		'''     created the window.
		''' </summary>
		''' <param name="handle">A handle to the window. </param>
		''' <param name="processId">
		'''     A pointer to a variable that receives the process identifier. If this parameter is not NULL,
		'''     GetWindowThreadProcessId copies the identifier of the process to the variable; otherwise, it does not.
		''' </param>
		''' <returns>The return value is the identifier of the thread that created the window. </returns>
		<DllImport("user32.dll", CharSet := CharSet.Auto, SetLastError := True)> _
		Friend Shared Function GetWindowThreadProcessId(handle As IntPtr, ByRef processId As Integer) As Integer
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
