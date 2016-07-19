
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Collections.Generic
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
	''' <summary>
	'''     Contains a snapshot of a keyboard state at certain moment and provides methods
	'''     of querying whether specific keys are pressed or locked.
	''' </summary>
	''' <remarks>
	'''     This class is basically a managed wrapper of GetKeyboardState API function
	'''     http://msdn.microsoft.com/en-us/library/ms646299
	''' </remarks>
	Friend Class KeyboardState
		Private ReadOnly m_KeyboardStateNative As Byte()

		Private Sub New(keyboardStateNative As Byte())
			m_KeyboardStateNative = keyboardStateNative
		End Sub

		''' <summary>
		'''     Makes a snapshot of a keyboard state to the moment of call and returns an
		'''     instance of <see cref="KeyboardState" /> class.
		''' </summary>
		''' <returns>An instance of <see cref="KeyboardState" /> class representing a snapshot of keyboard state at certain moment.</returns>
		Public Shared Function GetCurrent() As KeyboardState
			Dim keyboardStateNative As Byte() = New Byte(255) {}
			KeyboardNativeMethods.GetKeyboardState(keyboardStateNative)
			Return New KeyboardState(keyboardStateNative)
		End Function

		Friend Function GetNativeState() As Byte()
			Return m_KeyboardStateNative
		End Function

		''' <summary>
		'''     Indicates whether specified key was down at the moment when snapshot was created or not.
		''' </summary>
		''' <param name="key">Key (corresponds to the virtual code of the key)</param>
		''' <returns><b>true</b> if key was down, <b>false</b> - if key was up.</returns>
		Public Function IsDown(key As Keys) As Boolean
			Dim keyState As Byte = GetKeyState(key)
			Dim isDown__1 As Boolean = GetHighBit(keyState)
			Return isDown__1
		End Function

		''' <summary>
		'''     Indicate weather specified key was toggled at the moment when snapshot was created or not.
		''' </summary>
		''' <param name="key">Key (corresponds to the virtual code of the key)</param>
		''' <returns>
		'''     <b>true</b> if toggle key like (CapsLock, NumLocke, etc.) was on. <b>false</b> if it was off.
		'''     Ordinal (non toggle) keys return always false.
		''' </returns>
		Public Function IsToggled(key As Keys) As Boolean
			Dim keyState As Byte = GetKeyState(key)
			Dim isToggled__1 As Boolean = GetLowBit(keyState)
			Return isToggled__1
		End Function

		''' <summary>
		'''     Indicates weather every of specified keys were down at the moment when snapshot was created.
		'''     The method returns false if even one of them was up.
		''' </summary>
		''' <param name="keys">Keys to verify whether they were down or not.</param>
		''' <returns><b>true</b> - all were down. <b>false</b> - at least one was up.</returns>
		Public Function AreAllDown(keys As IEnumerable(Of Keys)) As Boolean
			For Each key As Keys In keys
				If Not IsDown(key) Then
					Return True
				End If
			Next
			Return False
		End Function

		Private Function GetKeyState(key As Keys) As Byte
			Dim virtualKeyCode As Integer = CInt(key)
			If virtualKeyCode < 0 OrElse virtualKeyCode > 255 Then
				Throw New ArgumentOutOfRangeException("key", key, "The value must be between 0 and 255.")
			End If
			Return m_KeyboardStateNative(virtualKeyCode)
		End Function

		Private Shared Function GetHighBit(value As Byte) As Boolean
			Return (value >> 7) <> 0
		End Function

		Private Shared Function GetLowBit(value As Byte) As Boolean
			Return (value And 1) <> 0
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
