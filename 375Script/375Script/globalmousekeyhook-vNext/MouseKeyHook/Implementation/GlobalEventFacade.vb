
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Namespace Gma.System.MouseKeyHook.Implementation
	Friend Class GlobalEventFacade
		Inherits EventFacade
		Protected Overrides Function CreateMouseListener() As MouseListener
			Return New GlobalMouseListener()
		End Function

		Protected Overrides Function CreateKeyListener() As KeyListener
			Return New GlobalKeyListener()
		End Function
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
