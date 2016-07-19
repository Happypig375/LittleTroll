
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices

Namespace Gma.System.MouseKeyHook.WinApi
	''' <summary>
	'''     The KeyboardHookStruct structure contains information about a low-level keyboard input event.
	''' </summary>
	''' <remarks>
	'''     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookstructures/cwpstruct.asp
	''' </remarks>
	<StructLayout(LayoutKind.Sequential)> _
	Friend Structure KeyboardHookStruct
		''' <summary>
		'''     Specifies a virtual-key code. The code must be a value in the range 1 to 254.
		''' </summary>
		Public VirtualKeyCode As Integer

		''' <summary>
		'''     Specifies a hardware scan code for the key.
		''' </summary>
		Public ScanCode As Integer

		''' <summary>
		'''     Specifies the extended-key flag, event-injected flag, context code, and transition-state flag.
		''' </summary>
		Public Flags As Integer

		''' <summary>
		'''     Specifies the Time stamp for this message.
		''' </summary>
		Public Time As Integer

		''' <summary>
		'''     Specifies extra information associated with the message.
		''' </summary>
		Public ExtraInfo As Integer
	End Structure
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
