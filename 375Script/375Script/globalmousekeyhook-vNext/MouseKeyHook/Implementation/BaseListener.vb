
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports _375Script.Gma.System.MouseKeyHook.WinApi

Namespace Gma.System.MouseKeyHook.Implementation
    Friend MustInherit Class BaseListener
        Implements IDisposable
        Protected Sub New(subscribe As Subscribe)
            Handle = subscribe(AddressOf Callback)
        End Sub

        Protected Property Handle() As HookResult
            Get
                Return m_Handle
            End Get
            Set
                m_Handle = Value
            End Set
        End Property
        Private m_Handle As HookResult

        Public Sub Dispose() Implements IDisposable.Dispose
            Handle.Dispose()
        End Sub

        Protected MustOverride Function Callback(data As CallbackData) As Boolean
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
