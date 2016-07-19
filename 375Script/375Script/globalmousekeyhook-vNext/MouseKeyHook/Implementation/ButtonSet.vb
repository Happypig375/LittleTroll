
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Windows.Forms

Namespace Gma.System.MouseKeyHook.Implementation
	Friend Class ButtonSet
		Private m_Set As MouseButtons

		Public Sub New()
			m_Set = MouseButtons.None
		End Sub

		Public Sub Add(element As MouseButtons)
			m_Set = m_Set Or element
		End Sub

		Public Sub Remove(element As MouseButtons)
			m_Set = m_Set And Not element
		End Sub

		Public Function Contains(element As MouseButtons) As Boolean
			Return (m_Set And element) <> MouseButtons.None
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
