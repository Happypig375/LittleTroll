
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
	Friend Class AppMouseListener
		Inherits MouseListener
		Public Sub New()
			MyBase.New(HookHelper.HookAppMouse)
		End Sub

		Protected Overrides Function GetEventArgs(data As CallbackData) As MouseEventExtArgs
			Return MouseEventExtArgs.FromRawDataApp(data)
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
