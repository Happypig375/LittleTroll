
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php


Namespace Gma.System.MouseKeyHook.WinApi
	Friend Structure CallbackData
		Private ReadOnly m_LParam As IntPtr
		Private ReadOnly m_WParam As IntPtr

		Public Sub New(wParam As IntPtr, lParam As IntPtr)
			m_WParam = wParam
			m_LParam = lParam
		End Sub

		Public ReadOnly Property WParam() As IntPtr
			Get
				Return m_WParam
			End Get
		End Property

		Public ReadOnly Property LParam() As IntPtr
			Get
				Return m_LParam
			End Get
		End Property
	End Structure
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
