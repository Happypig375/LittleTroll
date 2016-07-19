
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.Implementation

Namespace Gma.System.MouseKeyHook.WinApi
	Friend NotInheritable Class KeyboardNativeMethods
		Private Sub New()
		End Sub
		'values from Winuser.h in Microsoft SDK.
		Public Const VK_SHIFT As Byte = &H10
		Public Const VK_CAPITAL As Byte = &H14
		Public Const VK_NUMLOCK As Byte = &H90
		Public Const VK_LSHIFT As Byte = &Ha0
		Public Const VK_RSHIFT As Byte = &Ha1
		Public Const VK_LCONTROL As Byte = &Ha2
		Public Const VK_RCONTROL As Byte = &Ha3
		Public Const VK_LMENU As Byte = &Ha4
		Public Const VK_RMENU As Byte = &Ha5
		Public Const VK_LWIN As Byte = &H5b
		Public Const VK_RWIN As Byte = &H5c
		Public Const VK_SCROLL As Byte = &H91
		Public Const VK_INSERT As Byte = &H2d
		'may be possible to use these aggregates instead of L and R separately (untested)
		Public Const VK_CONTROL As Byte = &H11
		Public Const VK_MENU As Byte = &H12
		Public Const VK_PACKET As Byte = &He7
		'Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods
		Private Shared lastVirtualKeyCode As Integer = 0
		Private Shared lastScanCode As Integer = 0
		Private Shared lastKeyState As Byte() = New Byte(254) {}
		Private Shared lastIsDead As Boolean = False

        ''' <summary>
        '''     Translates a virtual key to its character equivalent using the current keyboard layout without knowing the
        '''     scancode in advance.
        ''' </summary>
        ''' <param name="virtualKeyCode"></param>
        ''' <param name="fuState"></param>
        ''' <param name="chars"></param>
        Friend Shared Sub TryGetCharFromKeyboardState(virtualKeyCode As Integer, fuState As Integer, ByRef chars As Char())
			Dim dwhkl = GetActiveKeyboard()
			Dim scanCode As Integer = MapVirtualKeyEx(virtualKeyCode, CInt(MapType.MAPVK_VK_TO_VSC), dwhkl)
			TryGetCharFromKeyboardState(virtualKeyCode, scanCode, fuState, dwhkl, chars)
		End Sub

        ''' <summary>
        '''     Translates a virtual key to its character equivalent using the current keyboard layout
        ''' </summary>
        ''' <param name="virtualKeyCode"></param>
        ''' <param name="scanCode"></param>
        ''' <param name="fuState"></param>
        ''' <param name="chars"></param>
        Friend Shared Sub TryGetCharFromKeyboardState(virtualKeyCode As Integer, scanCode As Integer, fuState As Integer, ByRef chars As Char())
			Dim dwhkl = GetActiveKeyboard()
			'get the active keyboard layout
			TryGetCharFromKeyboardState(virtualKeyCode, scanCode, fuState, dwhkl, chars)
		End Sub

        ''' <summary>
        '''     Translates a virtual key to its character equivalent using a specified keyboard layout
        ''' </summary>
        ''' <param name="virtualKeyCode"></param>
        ''' <param name="scanCode"></param>
        ''' <param name="fuState"></param>
        ''' <param name="dwhkl"></param>
        ''' <param name="chars"></param>
        Friend Shared Sub TryGetCharFromKeyboardState(virtualKeyCode As Integer, scanCode As Integer, fuState As Integer, dwhkl As IntPtr, ByRef chars As Char())
			Dim pwszBuff As New StringBuilder(64)
			Dim keyboardState__1 As KeyboardState = KeyboardState.GetCurrent()
			Dim currentKeyboardState As Byte() = keyboardState__1.GetNativeState()
			Dim isDead As Boolean = False

			If keyboardState__1.IsDown(Keys.ShiftKey) Then
				currentKeyboardState(CByte(Keys.ShiftKey)) = &H80
			End If

			If keyboardState__1.IsToggled(Keys.CapsLock) Then
				currentKeyboardState(CByte(Keys.CapsLock)) = &H1
			End If

			Dim relevantChars = ToUnicodeEx(virtualKeyCode, scanCode, currentKeyboardState, pwszBuff, pwszBuff.Capacity, fuState, _
				dwhkl)

			Select Case relevantChars
				Case -1
					isDead = True
					ClearKeyboardBuffer(virtualKeyCode, scanCode, dwhkl)
					chars = Nothing
					Exit Select

				Case 0
					chars = Nothing
					Exit Select

				Case 1
					If pwszBuff.Length > 0 Then
                        chars = New Char() {pwszBuff(0)}
                    Else
						chars = Nothing
					End If
					Exit Select
				Case Else

					' Two or more (only two of them is relevant)
					If pwszBuff.Length > 1 Then
                        chars = New Char() {pwszBuff(0), pwszBuff(1)}
                    Else
                        chars = New Char() {pwszBuff(0)}
                    End If
					Exit Select
			End Select

			If lastVirtualKeyCode <> 0 AndAlso lastIsDead Then
				If chars IsNot Nothing Then
					Dim sbTemp As New StringBuilder(5)
					ToUnicodeEx(lastVirtualKeyCode, lastScanCode, lastKeyState, sbTemp, sbTemp.Capacity, 0, _
						dwhkl)
					lastIsDead = False
					lastVirtualKeyCode = 0
				End If

				Return
			End If

			lastScanCode = scanCode
			lastVirtualKeyCode = virtualKeyCode
			lastIsDead = isDead
			lastKeyState = DirectCast(currentKeyboardState.Clone(), Byte())
		End Sub


		Private Shared Sub ClearKeyboardBuffer(vk As Integer, sc As Integer, hkl As IntPtr)
			Dim sb = New StringBuilder(10)

			Dim rc As Integer
			Do
				Dim lpKeyStateNull As Byte() = New [Byte](254) {}
				rc = ToUnicodeEx(vk, sc, lpKeyStateNull, sb, sb.Capacity, 0, _
					hkl)
			Loop While rc < 0
		End Sub

		''' <summary>
		'''     Gets the input locale identifier for the active application's thread.  Using this combined with the ToUnicodeEx and
		'''     MapVirtualKeyEx enables Windows to properly translate keys based on the keyboard layout designated for the
		'''     application.
		''' </summary>
		''' <returns>HKL</returns>
		Private Shared Function GetActiveKeyboard() As IntPtr
			Dim hActiveWnd As IntPtr = ThreadNativeMethods.GetForegroundWindow()
			'handle to focused window
			Dim dwProcessId As Integer
			Dim hCurrentWnd As Integer = ThreadNativeMethods.GetWindowThreadProcessId(hActiveWnd, dwProcessId)
			'thread of focused window
			Return GetKeyboardLayout(hCurrentWnd)
			'get the layout identifier for the thread whose window is focused
		End Function

		''' <summary>
		'''     The ToAscii function translates the specified virtual-key code and keyboard
		'''     state to the corresponding character or characters. The function translates the code
		'''     using the input language and physical keyboard layout identified by the keyboard layout handle.
		''' </summary>
		''' <param name="uVirtKey">
		'''     [in] Specifies the virtual-key code to be translated.
		''' </param>
		''' <param name="uScanCode">
		'''     [in] Specifies the hardware scan code of the key to be translated.
		'''     The high-order bit of this value is set if the key is up (not pressed).
		''' </param>
		''' <param name="lpbKeyState">
		'''     [in] Pointer to a 256-byte array that contains the current keyboard state.
		'''     Each element (byte) in the array contains the state of one key.
		'''     If the high-order bit of a byte is set, the key is down (pressed).
		'''     The low bit, if set, indicates that the key is toggled on. In this function,
		'''     only the toggle bit of the CAPS LOCK key is relevant. The toggle state
		'''     of the NUM LOCK and SCROLL LOCK keys is ignored.
		''' </param>
		''' <param name="lpwTransKey">
		'''     [out] Pointer to the buffer that receives the translated character or characters.
		''' </param>
		''' <param name="fuState">
		'''     [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.
		''' </param>
		''' <returns>
		'''     If the specified key is a dead key, the return value is negative. Otherwise, it is one of the following values.
		'''     Value Meaning
		'''     0 The specified virtual key has no translation for the current state of the keyboard.
		'''     1 One character was copied to the buffer.
		'''     2 Two characters were copied to the buffer. This usually happens when a dead-key character
		'''     (accent or diacritic) stored in the keyboard layout cannot be composed with the specified
		'''     virtual key to form a single character.
		''' </returns>
		''' <remarks>
		'''     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/userinput/keyboardinput/keyboardinputreference/keyboardinputfunctions/toascii.asp
		''' </remarks>
		<Obsolete("Use ToUnicodeEx instead")> _
		<DllImport("user32.dll")> _
		Public Shared Function ToAscii(uVirtKey As Integer, uScanCode As Integer, lpbKeyState As Byte(), lpwTransKey As Byte(), fuState As Integer) As Integer
		End Function

		''' <summary>
		'''     Translates the specified virtual-key code and keyboard state to the corresponding Unicode character or characters.
		''' </summary>
		''' <param name="wVirtKey">[in] The virtual-key code to be translated.</param>
		''' <param name="wScanCode">
		'''     [in] The hardware scan code of the key to be translated. The high-order bit of this value is
		'''     set if the key is up.
		''' </param>
		''' <param name="lpKeyState">
		'''     [in, optional] A pointer to a 256-byte array that contains the current keyboard state. Each
		'''     element (byte) in the array contains the state of one key. If the high-order bit of a byte is set, the key is down.
		''' </param>
		''' <param name="pwszBuff">
		'''     [out] The buffer that receives the translated Unicode character or characters. However, this
		'''     buffer may be returned without being null-terminated even though the variable name suggests that it is
		'''     null-terminated.
		''' </param>
		''' <param name="cchBuff">[in] The size, in characters, of the buffer pointed to by the pwszBuff parameter.</param>
		''' <param name="wFlags">
		'''     [in] The behavior of the function. If bit 0 is set, a menu is active. Bits 1 through 31 are
		'''     reserved.
		''' </param>
		''' <param name="dwhkl">The input locale identifier used to translate the specified code.</param>
		''' <returns>
		'''     -1 &lt;= return &lt;= n
		'''     <list type="bullet">
		'''         <item>
		'''             -1    = The specified virtual key is a dead-key character (accent or diacritic). This value is returned
		'''             regardless of the keyboard layout, even if several characters have been typed and are stored in the
		'''             keyboard state. If possible, even with Unicode keyboard layouts, the function has written a spacing version
		'''             of the dead-key character to the buffer specified by pwszBuff. For example, the function writes the
		'''             character SPACING ACUTE (0x00B4), rather than the character NON_SPACING ACUTE (0x0301).
		'''         </item>
		'''         <item>
		'''             0    = The specified virtual key has no translation for the current state of the keyboard. Nothing was
		'''             written to the buffer specified by pwszBuff.
		'''         </item>
		'''         <item> 1    = One character was written to the buffer specified by pwszBuff.</item>
		'''         <item>
		'''             n    = Two or more characters were written to the buffer specified by pwszBuff. The most common cause
		'''             for this is that a dead-key character (accent or diacritic) stored in the keyboard layout could not be
		'''             combined with the specified virtual key to form a single character. However, the buffer may contain more
		'''             characters than the return value specifies. When this happens, any extra characters are invalid and should
		'''             be ignored.
		'''         </item>
		'''     </list>
		''' </returns>
		<DllImport("user32.dll")> _
		Public Shared Function ToUnicodeEx(wVirtKey As Integer, wScanCode As Integer, lpKeyState As Byte(), <Out, MarshalAs(UnmanagedType.LPWStr, SizeConst := 64)> pwszBuff As StringBuilder, cchBuff As Integer, wFlags As Integer, _
			dwhkl As IntPtr) As Integer
		End Function

		''' <summary>
		'''     The GetKeyboardState function copies the status of the 256 virtual keys to the
		'''     specified buffer.
		''' </summary>
		''' <param name="pbKeyState">
		'''     [in] Pointer to a 256-byte array that contains keyboard key states.
		''' </param>
		''' <returns>
		'''     If the function succeeds, the return value is nonzero.
		'''     If the function fails, the return value is zero. To get extended error information, call GetLastError.
		''' </returns>
		''' <remarks>
		'''     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/userinput/keyboardinput/keyboardinputreference/keyboardinputfunctions/toascii.asp
		''' </remarks>
		<DllImport("user32.dll")> _
		Public Shared Function GetKeyboardState(pbKeyState As Byte()) As Integer
		End Function

		''' <summary>
		'''     The GetKeyState function retrieves the status of the specified virtual key. The status specifies whether the key is
		'''     up, down, or toggled
		'''     (on, off—alternating each time the key is pressed).
		''' </summary>
		''' <param name="vKey">
		'''     [in] Specifies a virtual key. If the desired virtual key is a letter or digit (A through Z, a through z, or 0
		'''     through 9), nVirtKey must be set to the ASCII value of that character. For other keys, it must be a virtual-key
		'''     code.
		''' </param>
		''' <returns>
		'''     The return value specifies the status of the specified virtual key, as follows:
		'''     If the high-order bit is 1, the key is down; otherwise, it is up.
		'''     If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on. The
		'''     key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be
		'''     on when the key is toggled, and off when the key is untoggled.
		''' </returns>
		''' <remarks>http://msdn.microsoft.com/en-us/library/ms646301.aspx</remarks>
		<DllImport("user32.dll", CharSet := CharSet.Auto, CallingConvention := CallingConvention.StdCall)> _
		Public Shared Function GetKeyState(vKey As Integer) As Short
		End Function

		''' <summary>
		'''     Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a
		'''     virtual-key code.
		''' </summary>
		''' <param name="uCode">
		'''     [in] The virtual key code or scan code for a key. How this value is interpreted depends on the
		'''     value of the uMapType parameter.
		''' </param>
		''' <param name="uMapType">
		'''     [in] The translation to be performed. The value of this parameter depends on the value of the
		'''     uCode parameter.
		''' </param>
		''' <param name="dwhkl">[in] The input locale identifier used to translate the specified code.</param>
		''' <returns></returns>
		<DllImport("user32.dll", CharSet := CharSet.Auto)> _
		Friend Shared Function MapVirtualKeyEx(uCode As Integer, uMapType As Integer, dwhkl As IntPtr) As Integer
		End Function

		''' <summary>
		'''     Retrieves the active input locale identifier (formerly called the keyboard layout) for the specified thread.
		'''     If the idThread parameter is zero, the input locale identifier for the active thread is returned.
		''' </summary>
		''' <param name="dwLayout">[in] The identifier of the thread to query, or 0 for the current thread. </param>
		''' <returns>
		'''     The return value is the input locale identifier for the thread. The low word contains a Language Identifier for the
		'''     input
		'''     language and the high word contains a device handle to the physical layout of the keyboard.
		''' </returns>
		<DllImport("user32.dll", CharSet := CharSet.Auto)> _
		Friend Shared Function GetKeyboardLayout(dwLayout As Integer) As IntPtr
		End Function

		''' <summary>
		'''     MapVirtualKeys uMapType
		''' </summary>
		Friend Enum MapType
			''' <summary>
			'''     uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return
			'''     value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation,
			'''     the function returns 0.
			''' </summary>
			MAPVK_VK_TO_VSC

			''' <summary>
			'''     uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not
			'''     distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the
			'''     function returns 0.
			''' </summary>
			MAPVK_VSC_TO_VK

			''' <summary>
			'''     uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and
			'''     right-hand keys. If there is no translation, the function returns 0.
			''' </summary>
			MAPVK_VK_TO_CHAR

			''' <summary>
			'''     uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand
			'''     keys. If there is no translation, the function returns 0.
			''' </summary>
			MAPVK_VSC_TO_VK_EX
		End Enum
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
