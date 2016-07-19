
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices

Namespace Gma.System.MouseKeyHook.WinApi
	''' <summary>
	'''     The AppMouseStruct structure contains information about a application-level mouse input event.
	''' </summary>
	''' <remarks>
	'''     See full documentation at http://globalmousekeyhook.codeplex.com/wikipage?title=MouseStruct
	''' </remarks>
	<StructLayout(LayoutKind.Explicit)> _
	Friend Structure AppMouseStruct
		''' <summary>
		'''     Specifies a Point structure that contains the X- and Y-coordinates of the cursor, in screen coordinates.
		''' </summary>
		<FieldOffset(&H0)> _
		Public Point As Point

		''' <summary>
		'''     Specifies information associated with the message.
		''' </summary>
		''' <remarks>
		'''     The possible values are:
		'''     <list type="bullet">
		'''         <item>
		'''             <description>0 - No Information</description>
		'''         </item>
		'''         <item>
		'''             <description>1 - X-Button1 Click</description>
		'''         </item>
		'''         <item>
		'''             <description>2 - X-Button2 Click</description>
		'''         </item>
		'''         <item>
		'''             <description>120 - Mouse Scroll Away from User</description>
		'''         </item>
		'''         <item>
		'''             <description>-120 - Mouse Scroll Toward User</description>
		'''         </item>
		'''     </list>
		''' </remarks>
		<FieldOffset(&H16)> _
		Public MouseData_x86 As Int16
		<FieldOffset(&H22)> _
		Public MouseData_x64 As Int16

		''' <summary>
		'''     Converts the current <see cref="AppMouseStruct" /> into a <see cref="MouseStruct" />.
		''' </summary>
		''' <returns></returns>
		''' <remarks>
		'''     The AppMouseStruct does not have a timestamp, thus one is generated at the time of this call.
		''' </remarks>
		Public Function ToMouseStruct() As MouseStruct
			Dim tmp As New MouseStruct()
			tmp.Point = Point
			tmp.MouseData = If((IntPtr.Size = 4), MouseData_x86, MouseData_x64)
			tmp.Timestamp = Environment.TickCount
			Return tmp
		End Function
	End Structure
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
