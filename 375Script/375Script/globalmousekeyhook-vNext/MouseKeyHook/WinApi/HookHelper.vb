
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports _375Script.Gma.System.MouseKeyHook.Implementation

Namespace Gma.System.MouseKeyHook.WinApi
	Friend NotInheritable Class HookHelper
		Private Sub New()
		End Sub
		Shared _appHookProc As HookProcedure
		Shared _globalHookProc As HookProcedure

		Public Shared Function HookAppMouse(callback As Callback) As HookResult
			Return HookApp(HookIds.WH_MOUSE, callback)
		End Function

		Public Shared Function HookAppKeyboard(callback As Callback) As HookResult
			Return HookApp(HookIds.WH_KEYBOARD, callback)
		End Function

		Public Shared Function HookGlobalMouse(callback As Callback) As HookResult
			Return HookGlobal(HookIds.WH_MOUSE_LL, callback)
		End Function

		Public Shared Function HookGlobalKeyboard(callback As Callback) As HookResult
			Return HookGlobal(HookIds.WH_KEYBOARD_LL, callback)
		End Function

		Private Shared Function HookApp(hookId As Integer, callback As Callback) As HookResult
			_appHookProc = Function(code, param, lParam) HookProcedure(code, param, lParam, callback)

			Dim hookHandle = HookNativeMethods.SetWindowsHookEx(hookId, _appHookProc, IntPtr.Zero, ThreadNativeMethods.GetCurrentThreadId())

			If hookHandle.IsInvalid Then
				ThrowLastUnmanagedErrorAsException()
			End If

			Return New HookResult(hookHandle, _appHookProc)
		End Function

		Private Shared Function HookGlobal(hookId As Integer, callback As Callback) As HookResult
			_globalHookProc = Function(code, param, lParam) HookProcedure(code, param, lParam, callback)

			Dim hookHandle = HookNativeMethods.SetWindowsHookEx(hookId, _globalHookProc, Process.GetCurrentProcess().MainModule.BaseAddress, 0)

			If hookHandle.IsInvalid Then
				ThrowLastUnmanagedErrorAsException()
			End If

			Return New HookResult(hookHandle, _globalHookProc)
		End Function

		Private Shared Function HookProcedure(nCode As Integer, wParam As IntPtr, lParam As IntPtr, callback As Callback) As IntPtr
			Dim passThrough = nCode <> 0
			If passThrough Then
				Return CallNextHookEx(nCode, wParam, lParam)
			End If

			Dim callbackData = New CallbackData(wParam, lParam)
			Dim continueProcessing = callback(callbackData)

			If Not continueProcessing Then
				Return New IntPtr(-1)
			End If

			Return CallNextHookEx(nCode, wParam, lParam)
		End Function

		Private Shared Function CallNextHookEx(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
			Return HookNativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
		End Function

		Private Shared Sub ThrowLastUnmanagedErrorAsException()
			Dim errorCode = Marshal.GetLastWin32Error()
			Throw New Win32Exception(errorCode)
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
