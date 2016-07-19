
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php


Namespace Gma.System.MouseKeyHook.HotKeys
	''' <summary>
	'''     The event arguments passed when a HotKeySet's OnHotKeysDownHold event is triggered.
	''' </summary>
	Public NotInheritable Class HotKeyArgs
		Inherits EventArgs
		Private ReadOnly m_TimeOfExecution As DateTime

		''' <summary>
		'''     Creates an instance of the HotKeyArgs.
		'''     <param name="triggeredAt">Time when the event was triggered</param>
		''' </summary>
		Public Sub New(triggeredAt As DateTime)
			m_TimeOfExecution = triggeredAt
		End Sub

		''' <summary>
		'''     Time when the event was triggered
		''' </summary>
		Public ReadOnly Property Time() As DateTime
			Get
				Return m_TimeOfExecution
			End Get
		End Property
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
