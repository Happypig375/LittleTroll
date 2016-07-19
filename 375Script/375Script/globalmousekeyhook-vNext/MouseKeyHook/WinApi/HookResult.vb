
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php


Namespace Gma.System.MouseKeyHook.WinApi
	Friend Class HookResult
		Implements IDisposable
		Private ReadOnly m_Handle As HookProcedureHandle
		Private ReadOnly m_Procedure As HookProcedure

		Public Sub New(handle As HookProcedureHandle, procedure As HookProcedure)
			m_Handle = handle
			m_Procedure = procedure
		End Sub

		Public ReadOnly Property Handle() As HookProcedureHandle
			Get
				Return m_Handle
			End Get
		End Property

		Public ReadOnly Property Procedure() As HookProcedure
			Get
				Return m_Procedure
			End Get
		End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            m_Handle.Dispose()
        End Sub
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
