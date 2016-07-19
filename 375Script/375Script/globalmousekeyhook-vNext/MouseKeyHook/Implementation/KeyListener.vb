
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Collections.Generic
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
	Friend MustInherit Class KeyListener
		Inherits BaseListener
		Implements IKeyboardEvents
		Protected Sub New(subscribe As Subscribe)
			MyBase.New(subscribe)
		End Sub

        Public Event KeyDown As KeyEventHandler Implements IKeyboardEvents.KeyDown
        Public Event KeyPress As KeyPressEventHandler Implements IKeyboardEvents.KeyPress
        Public Event KeyUp As KeyEventHandler Implements IKeyboardEvents.KeyUp

        Public Sub InvokeKeyDown(e As KeyEventArgsExt)
            If e.Handled OrElse Not e.IsKeyDown Then
                Return
            End If
            RaiseEvent KeyDown(Me, e)
        End Sub

        Public Sub InvokeKeyPress(e As KeyPressEventArgsExt)
            If e.Handled OrElse e.IsNonChar Then
                Return
            End If
            RaiseEvent KeyPress(Me, e)
        End Sub

        Public Sub InvokeKeyUp(e As KeyEventArgsExt)
            If e.Handled OrElse Not e.IsKeyUp Then
                Return
            End If
            RaiseEvent KeyUp(Me, e)
        End Sub

        Protected Overrides Function Callback(data As CallbackData) As Boolean
			Dim eDownUp = GetDownUpEventArgs(data)
			Dim pressEventArgs = GetPressEventArgs(data)

			InvokeKeyDown(eDownUp)
            For Each pressEventArg As KeyPressEventArgsExt In pressEventArgs
                InvokeKeyPress(pressEventArg)
            Next

            InvokeKeyUp(eDownUp)

			Return Not eDownUp.Handled
		End Function

		Protected MustOverride Function GetPressEventArgs(data As CallbackData) As IEnumerable(Of KeyPressEventArgsExt)
		Protected MustOverride Function GetDownUpEventArgs(data As CallbackData) As KeyEventArgsExt
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
