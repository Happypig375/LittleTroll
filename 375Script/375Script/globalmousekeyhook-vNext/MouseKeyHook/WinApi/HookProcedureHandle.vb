
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Windows.Forms
Imports Microsoft.Win32.SafeHandles

Namespace Gma.System.MouseKeyHook.WinApi
	Friend Class HookProcedureHandle
		Inherits SafeHandleZeroOrMinusOneIsInvalid
		Private Shared _closing As Boolean

		Shared Sub New()
            AddHandler Application.ApplicationExit, Sub(sender, e)
                                                        _closing = True
                                                    End Sub
        End Sub

		Public Sub New()
			MyBase.New(True)
		End Sub

		Protected Overrides Function ReleaseHandle() As Boolean
			'NOTE Calling Unhook during processexit causes deley
			If _closing Then
				Return True
			End If
			Return HookNativeMethods.UnhookWindowsHookEx(handle) <> 0
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
