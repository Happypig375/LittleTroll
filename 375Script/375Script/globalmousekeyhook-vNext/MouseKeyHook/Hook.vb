
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports _375Script.Gma.System.MouseKeyHook.Implementation

Namespace Gma.System.MouseKeyHook
	''' <summary>
	'''     This is the class to start with.
	''' </summary>
	Public NotInheritable Class Hook
		Private Sub New()
		End Sub
		''' <summary>
		'''     Here you find all application wide events. Both mouse and keyboard.
		''' </summary>
		''' <returns>
		'''     Returned instance is used for event subscriptions.
		'''     You can refetch it (you will get the same instance anyway).
		''' </returns>
		Public Shared Function AppEvents() As IKeyboardMouseEvents
			Return New AppEventFacade()
		End Function

		''' <summary>
		'''     Here you find all application wide events. Both mouse and keyboard.
		''' </summary>
		''' <returns>
		'''     Returned instance is used for event subscriptions.
		'''     You can refetch it (you will get the same instance anyway).
		''' </returns>
		Public Shared Function GlobalEvents() As IKeyboardMouseEvents
			Return New GlobalEventFacade()
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
