
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Collections.Generic
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
    Friend Class AppKeyListener
        Inherits KeyListener
        Public Sub New()
            MyBase.New(HookHelper.HookAppKeyboard())
        End Sub

        Protected Overrides Function GetPressEventArgs(data As CallbackData) As IEnumerable(Of KeyPressEventArgsExt)
            Return KeyPressEventArgsExt.FromRawDataApp(data)
        End Function

        Protected Overrides Function GetDownUpEventArgs(data As CallbackData) As KeyEventArgsExt
            Return KeyEventArgsExt.FromRawDataApp(data)
        End Function
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
