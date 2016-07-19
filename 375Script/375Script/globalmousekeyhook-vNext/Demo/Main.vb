
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.ComponentModel
Imports System.Windows.Forms
Imports Gma.System.MouseKeyHook
Imports Gma.System.MouseKeyHook.Implementation

Namespace Demo
	Public Partial Class Main
		Inherits Form
		Private m_Events As IKeyboardMouseEvents

		Public Sub New()
			InitializeComponent()
			radioGlobal.Checked = True
			SubscribeGlobal()
			AddHandler FormClosing, AddressOf Main_Closing
		End Sub

		Private Sub Main_Closing(sender As Object, e As CancelEventArgs)
			Unsubscribe()
		End Sub

		Private Sub SubscribeApplication()
			Unsubscribe()
			Subscribe(Hook.AppEvents())
		End Sub

		Private Sub SubscribeGlobal()
			Unsubscribe()
			Subscribe(Hook.GlobalEvents())
		End Sub

		Private Sub Subscribe(events As IKeyboardMouseEvents)
			m_Events = events
			AddHandler m_Events.KeyDown, AddressOf OnKeyDown
			AddHandler m_Events.KeyUp, AddressOf OnKeyUp
			AddHandler m_Events.KeyPress, AddressOf HookManager_KeyPress

			AddHandler m_Events.MouseUp, AddressOf OnMouseUp
			AddHandler m_Events.MouseClick, AddressOf OnMouseClick
			AddHandler m_Events.MouseDoubleClick, AddressOf OnMouseDoubleClick

			AddHandler m_Events.MouseMove, AddressOf HookManager_MouseMove

			AddHandler m_Events.MouseDragStarted, AddressOf OnMouseDragStarted
			AddHandler m_Events.MouseDragFinished, AddressOf OnMouseDragFinished

			If checkBoxSupressMouseWheel.Checked Then
				AddHandler m_Events.MouseWheelExt, AddressOf HookManager_MouseWheelExt
			Else
				AddHandler m_Events.MouseWheel, AddressOf HookManager_MouseWheel
			End If

			If checkBoxSuppressMouse.Checked Then
				AddHandler m_Events.MouseDownExt, AddressOf HookManager_Supress
			Else
				AddHandler m_Events.MouseDown, AddressOf OnMouseDown
			End If

		End Sub

		Private Sub Unsubscribe()
			If m_Events Is Nothing Then
				Return
			End If
			RemoveHandler m_Events.KeyDown, AddressOf OnKeyDown
			RemoveHandler m_Events.KeyUp, AddressOf OnKeyUp
			RemoveHandler m_Events.KeyPress, AddressOf HookManager_KeyPress

			RemoveHandler m_Events.MouseUp, AddressOf OnMouseUp
			RemoveHandler m_Events.MouseClick, AddressOf OnMouseClick
			RemoveHandler m_Events.MouseDoubleClick, AddressOf OnMouseDoubleClick

			RemoveHandler m_Events.MouseMove, AddressOf HookManager_MouseMove

			RemoveHandler m_Events.MouseDragStarted, AddressOf OnMouseDragStarted
			RemoveHandler m_Events.MouseDragFinished, AddressOf OnMouseDragFinished

			If checkBoxSupressMouseWheel.Checked Then
				RemoveHandler m_Events.MouseWheelExt, AddressOf HookManager_MouseWheelExt
			Else
				RemoveHandler m_Events.MouseWheel, AddressOf HookManager_MouseWheel
			End If

			If checkBoxSuppressMouse.Checked Then
				RemoveHandler m_Events.MouseDownExt, AddressOf HookManager_Supress
			Else
				RemoveHandler m_Events.MouseDown, AddressOf OnMouseDown
			End If

			m_Events.Dispose()
			m_Events = Nothing
		End Sub

		Private Sub HookManager_Supress(sender As Object, e As MouseEventExtArgs)
			If e.Button <> MouseButtons.Right Then
				Log(String.Format("MouseDown " & vbTab & vbTab & " {0}" & vbLf, e.Button))
				Return
			End If

			Log(String.Format("MouseDown " & vbTab & vbTab & " {0} Suppressed" & vbLf, e.Button))
			e.Handled = True
		End Sub

		Private Sub OnKeyDown(sender As Object, e As KeyEventArgs)
			Log(String.Format("KeyDown  " & vbTab & vbTab & " {0}" & vbLf, e.KeyCode))
		End Sub

		Private Sub OnKeyUp(sender As Object, e As KeyEventArgs)
			Log(String.Format("KeyUp  " & vbTab & vbTab & " {0}" & vbLf, e.KeyCode))
		End Sub

		Private Sub HookManager_KeyPress(sender As Object, e As KeyPressEventArgs)
			Log(String.Format("KeyPress " & vbTab & vbTab & " {0}" & vbLf, e.KeyChar))
		End Sub

		Private Sub HookManager_MouseMove(sender As Object, e As MouseEventArgs)
			labelMousePosition.Text = String.Format("x={0:0000}; y={1:0000}", e.X, e.Y)
		End Sub

		Private Sub OnMouseDown(sender As Object, e As MouseEventArgs)
			Log(String.Format("MouseDown " & vbTab & vbTab & " {0}" & vbLf, e.Button))
		End Sub

		Private Sub OnMouseUp(sender As Object, e As MouseEventArgs)
			Log(String.Format("MouseUp " & vbTab & vbTab & " {0}" & vbLf, e.Button))
		End Sub

		Private Sub OnMouseClick(sender As Object, e As MouseEventArgs)
			Log(String.Format("MouseClick " & vbTab & vbTab & " {0}" & vbLf, e.Button))
		End Sub

		Private Sub OnMouseDoubleClick(sender As Object, e As MouseEventArgs)
			Log(String.Format("MouseDoubleClick " & vbTab & vbTab & " {0}" & vbLf, e.Button))
		End Sub

		Private Sub OnMouseDragStarted(sender As Object, e As MouseEventArgs)
			Log("MouseDragStarted" & vbLf)
		End Sub

		Private Sub OnMouseDragFinished(sender As Object, e As MouseEventArgs)
			Log("MouseDragFinished" & vbLf)
		End Sub

		Private Sub HookManager_MouseWheel(sender As Object, e As MouseEventArgs)
			labelWheel.Text = String.Format("Wheel={0:000}", e.Delta)
		End Sub

		Private Sub HookManager_MouseWheelExt(sender As Object, e As MouseEventExtArgs)
			labelWheel.Text = String.Format("Wheel={0:000}", e.Delta)
			Log("Mouse Wheel Move Suppressed." & vbLf)
			e.Handled = True
		End Sub

		Private Sub Log(text As String)
			If IsDisposed Then
				Return
			End If
			textBoxLog.AppendText(text)
			textBoxLog.ScrollToCaret()
		End Sub

		Private Sub radioApplication_CheckedChanged(sender As Object, e As EventArgs)
			If DirectCast(sender, RadioButton).Checked Then
				SubscribeApplication()
			End If
		End Sub

		Private Sub radioGlobal_CheckedChanged(sender As Object, e As EventArgs)
			If DirectCast(sender, RadioButton).Checked Then
				SubscribeGlobal()
			End If
		End Sub

		Private Sub radioNone_CheckedChanged(sender As Object, e As EventArgs)
			If DirectCast(sender, RadioButton).Checked Then
				Unsubscribe()
			End If
		End Sub

		Private Sub checkBoxSupressMouseWheel_CheckedChanged(sender As Object, e As EventArgs)
			If m_Events Is Nothing Then
				Return
			End If

			If DirectCast(sender, CheckBox).Checked Then
				RemoveHandler m_Events.MouseWheel, AddressOf HookManager_MouseWheel
				AddHandler m_Events.MouseWheelExt, AddressOf HookManager_MouseWheelExt
			Else
				RemoveHandler m_Events.MouseWheelExt, AddressOf HookManager_MouseWheelExt
				AddHandler m_Events.MouseWheel, AddressOf HookManager_MouseWheel
			End If
		End Sub

		Private Sub checkBoxSuppressMouse_CheckedChanged(sender As Object, e As EventArgs)
			If m_Events Is Nothing Then
				Return
			End If

			If DirectCast(sender, CheckBox).Checked Then
				RemoveHandler m_Events.MouseDown, AddressOf OnMouseDown
				AddHandler m_Events.MouseDownExt, AddressOf HookManager_Supress
			Else
				RemoveHandler m_Events.MouseDownExt, AddressOf HookManager_Supress
				AddHandler m_Events.MouseDown, AddressOf OnMouseDown
			End If
		End Sub

		Private Sub clearLog_Click(sender As Object, e As EventArgs)
			textBoxLog.Clear()
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
