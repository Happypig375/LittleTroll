
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Namespace Gma.System.MouseKeyHook.WinApi
	Friend NotInheritable Class HookIds
		Private Sub New()
		End Sub
		''' <summary>
		'''     Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure.
		''' </summary>
		Friend Const WH_MOUSE As Integer = 7

		''' <summary>
		'''     Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook
		'''     procedure.
		''' </summary>
		Friend Const WH_KEYBOARD As Integer = 2

		''' <summary>
		'''     Windows NT/2000/XP/Vista/7: Installs a hook procedure that monitors low-level mouse input events.
		''' </summary>
		Friend Const WH_MOUSE_LL As Integer = 14

		''' <summary>
		'''     Windows NT/2000/XP/Vista/7: Installs a hook procedure that monitors low-level keyboard  input events.
		''' </summary>
		Friend Const WH_KEYBOARD_LL As Integer = 13
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
