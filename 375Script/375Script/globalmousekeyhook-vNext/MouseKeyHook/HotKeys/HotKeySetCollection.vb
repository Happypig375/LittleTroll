
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Collections.Generic

Namespace Gma.System.MouseKeyHook.HotKeys
	''' <summary>
	'''     A collection of HotKeySets
	''' </summary>
	Public NotInheritable Class HotKeySetCollection
		Inherits List(Of HotKeySet)
		Private m_keyChain As KeyChainHandler

		''' <summary>
		'''     Adds a HotKeySet to the collection.
		''' </summary>
		''' <param name="hks"></param>
		Public Shadows Sub Add(hks As HotKeySet)
            m_keyChain = DirectCast([Delegate].Combine(m_keyChain, hks.OnKey(New KeyEventArgsExt(hks))), HotKeySetCollection.KeyChainHandler)
            MyBase.Add(hks)
		End Sub

		''' <summary>
		'''     Removes the HotKeySet from the collection.
		''' </summary>
		''' <param name="hks"></param>
		Public Shadows Sub Remove(hks As HotKeySet)
			m_keyChain = DirectCast([Delegate].Remove(m_keyChain, hks.OnKey), HotKeySetCollection.KeyChainHandler)
			MyBase.Remove(hks)
		End Sub

		''' <summary>
		'''     Uses a multi-case delegate to invoke individual HotKeySets if the Key is in use by any HotKeySets.
		''' </summary>
		''' <param name="e"></param>
		Friend Sub OnKey(e As KeyEventArgsExt)
            m_keyChain(e)
        End Sub

		Private Delegate Sub KeyChainHandler(kex As KeyEventArgsExt)
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
