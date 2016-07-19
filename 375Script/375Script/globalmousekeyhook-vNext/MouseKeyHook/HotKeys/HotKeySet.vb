
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Collections.Generic
Imports System.Windows.Forms
Imports _375Script.Gma.System.MouseKeyHook.Implementation

Namespace Gma.System.MouseKeyHook.HotKeys
	''' <summary>
	'''     An immutable set of Hot Keys that provides an event for when the set is activated.
	''' </summary>
	Public Class HotKeySet
		''' <summary>
		'''     A delegate representing the signature for the OnHotKeysDownHold event
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Public Delegate Sub HotKeyHandler(sender As Object, e As HotKeyArgs)

		Private ReadOnly m_hotkeys As IEnumerable(Of Keys)
		'hotkeys provided by the user.
		Private ReadOnly m_hotkeystate As Dictionary(Of Keys, Boolean)
		'Keeps track of the status of the set of Keys
		'
'         * Example of m_remapping:
'         * a single key from the set of Keys requested is chosen to be the reference key (aka primary key)
'         * 
'         * m_remapping[ Keys.LShiftKey ] = Keys.LShiftKey
'         * m_remapping[ Keys.RShiftKey ] = Keys.LShiftKey
'         * 
'         * This allows the m_hotkeystate to use a single key (primary key) from the set that will act on behalf of all the keys in the set, 
'         * which in turn reduces to this:
'         * 
'         * Keys k = Keys.RShiftKey
'         * Keys primaryKey = PrimaryKeyOf( k ) = Keys.LShiftKey
'         * m_hotkeystate[ primaryKey ] = true/false
'         
		Private ReadOnly m_remapping As Dictionary(Of Keys, Keys)
		'Used for mapping multiple keys to a single key
		Private m_enabled As Boolean = True
		'enabled by default
		'These provide the actual status of whether a set is truly activated or not.
		Private m_hotkeydowncount As Integer
		'number of hot keys down
		Private m_remappingCount As Integer
		'the number of remappings, i.e., a set of mappings, not the individual count in m_remapping

		''' <summary>
		'''     Creates an instance of the HotKeySet class.  Once created, the keys cannot be changed.
		''' </summary>
		''' <param name="hotkeys">Set of Hot Keys</param>
		Public Sub New(hotkeys As IEnumerable(Of Keys))
			m_hotkeystate = New Dictionary(Of Keys, Boolean)()
			m_remapping = New Dictionary(Of Keys, Keys)()
			m_hotkeys = hotkeys
			InitializeKeys()
		End Sub

		''' <summary>
		'''     Enables the ability to name the set
		''' </summary>
		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Set
				m_Name = Value
			End Set
		End Property
		Private m_Name As String

		''' <summary>
		'''     Enables the ability to describe what the set is used for or supposed to do
		''' </summary>
		Public Property Description() As String
			Get
				Return m_Description
			End Get
			Set
				m_Description = Value
			End Set
		End Property
		Private m_Description As String

		''' <summary>
		'''     Gets the set of hotkeys that this class handles.
		''' </summary>
		Public ReadOnly Property HotKeys() As IEnumerable(Of Keys)
			Get
				Return m_hotkeys
			End Get
		End Property

		''' <summary>
		'''     Returns whether the set of Keys is activated
		''' </summary>
		Public ReadOnly Property HotKeysActivated() As Boolean
			'The number of sets of remapped keys is used to offset the amount originally specified by the user.
			Get
				Return m_hotkeydowncount = (m_hotkeystate.Count - m_remappingCount)
			End Get
		End Property

		''' <summary>
		'''     Gets or sets the enabled state of the HotKey set.
		''' </summary>
		Public Property Enabled() As Boolean
			Get
				Return m_enabled
			End Get
			Set
				If value Then
					InitializeKeys()
				End If
				'must get the actual current state of each key to update
				m_enabled = value
			End Set
		End Property

		''' <summary>
		'''     Called as the user holds down the keys in the set.  It is NOT triggered the first time the keys are set.
		'''     <see cref="OnHotKeysDownOnce" />
		''' </summary>
		Public Event OnHotKeysDownHold As HotKeyHandler

		''' <summary>
		'''     Called whenever the hot key set is no longer active.  This is essentially a KeyPress event, indicating that a full
		'''     key cycle has occurred, only for HotKeys because a single key removed from the set constitutes an incomplete set.
		''' </summary>
		Public Event OnHotKeysUp As HotKeyHandler

		''' <summary>
		'''     Called the first time the down keys are set.  It does not get called throughout the duration the user holds it but
		'''     only the
		'''     first time it's activated.
		''' </summary>
		Public Event OnHotKeysDownOnce As HotKeyHandler

		''' <summary>
		'''     General invocation handler
		''' </summary>
		''' <param name="hotKeyDelegate"></param>
		Private Sub InvokeHotKeyHandler(hotKeyDelegate As HotKeyHandler)
            hotKeyDelegate(Me, New HotKeyArgs(DateTime.Now))
        End Sub

		''' <summary>
		'''     Adds the keys into the dictionary tracking the keys and gets the real-time status of the Keys
		'''     from the OS
		''' </summary>
		Private Sub InitializeKeys()
			For Each k As Keys In HotKeys
				If m_hotkeystate.ContainsKey(k) Then
					m_hotkeystate.Add(k, False)
				End If

				'assign using the current state of the keyboard
				m_hotkeystate(k) = KeyboardState.GetCurrent().IsDown(k)
			Next
		End Sub

		''' <summary>
		'''     Unregisters a previously set exclusive or based on the primary key.
		''' </summary>
		''' <param name="anyKeyInTheExclusiveOrSet">Any key used in the Registration method used to create an exclusive or set</param>
		''' <returns>
		'''     True if successful.  False doesn't indicate a failure to unregister, it indicates that the Key is not
		'''     registered as an Exclusive Or key or it's not the Primary Key.
		''' </returns>
		Public Function UnregisterExclusiveOrKey(anyKeyInTheExclusiveOrSet As Keys) As Boolean
			Dim primaryKey As Keys = GetExclusiveOrPrimaryKey(anyKeyInTheExclusiveOrSet)

			If primaryKey = Keys.None OrElse Not m_remapping.ContainsValue(primaryKey) Then
				Return False
			End If

			Dim keystoremove As New List(Of Keys)()

			For Each pair As KeyValuePair(Of Keys, Keys) In m_remapping
				If pair.Value = primaryKey Then
					keystoremove.Add(pair.Key)
				End If
			Next

			For Each k As Keys In keystoremove
				m_remapping.Remove(k)
			Next

			m_remappingCount -= 1

			Return True
		End Function

		''' <summary>
		'''     Registers a group of Keys that are already part of the HotKeySet in order to provide better flexibility among keys.
		'''     <example>
		'''         <code>
		'''  HotKeySet hks = new HotKeySet( new [] { Keys.T, Keys.LShiftKey, Keys.RShiftKey } );
		'''  RegisterExclusiveOrKey( new [] { Keys.LShiftKey, Keys.RShiftKey } );
		'''  </code>
		'''         allows either Keys.LShiftKey or Keys.RShiftKey to be combined with Keys.T.
		'''     </example>
		''' </summary>
		''' <param name="orKeySet"></param>
		''' <returns>Primary key used for mapping or Keys.None on error</returns>
		Public Function RegisterExclusiveOrKey(orKeySet As IEnumerable(Of Keys)) As Keys
			'Verification first, so as to not leave the m_remapping with a partial set.
			For Each k As Keys In orKeySet
				If Not m_hotkeystate.ContainsKey(k) Then
					Return Keys.None
				End If
			Next

			Dim i As Integer = 0
			Dim primaryKey As Keys = Keys.None

			'Commit after verification
			For Each k As Keys In orKeySet
				If i = 0 Then
					primaryKey = k
				End If

				m_remapping(k) = primaryKey

				i += 1
			Next

			'Must increase to keep a true count of how many keys are necessary for the activation to be true
			m_remappingCount += 1

			Return primaryKey
		End Function

		''' <summary>
		'''     Gets the primary key
		''' </summary>
		''' <param name="k"></param>
		''' <returns>The primary key if it exists, otherwise Keys.None</returns>
		Private Function GetExclusiveOrPrimaryKey(k As Keys) As Keys
			Return (If(m_remapping.ContainsKey(k), m_remapping(k), Keys.None))
		End Function

		''' <summary>
		'''     Resolves obtaining the key used for state checking.
		''' </summary>
		''' <param name="k"></param>
		''' <returns>The primary key if it exists, otherwise the key entered</returns>
		Private Function GetPrimaryKey(k As Keys) As Keys
			'If the key is remapped then get the primary keys
			Return (If(m_remapping.ContainsKey(k), m_remapping(k), k))
		End Function

        ''' <summary>
        ''' </summary>
        ''' <param name="kex"></param>
        Friend Sub OnKey(kex As KeyEventArgsExt)
            If Not Enabled Then
                Return
            End If

            'Gets the primary key if mapped to a single key or gets the key itself
            Dim primaryKey As Keys = GetPrimaryKey(kex.KeyCode)

            If kex.IsKeyDown Then
                OnKeyDown(primaryKey)
            Else
                'reset
                OnKeyUp(primaryKey)
            End If
        End Sub

        Private Sub OnKeyDown(k As Keys)
			'If the keys are activated still then keep invoking the event
			If HotKeysActivated Then
                RaiseEvent OnHotKeysDownHold(Me, New HotKeyArgs(DateTime.Now))
                'Call the duration event
                'indicates the key's state is current false but the key is now down
            ElseIf m_hotkeystate.ContainsKey(k) AndAlso Not m_hotkeystate(k) Then
				m_hotkeystate(k) = True
				'key's state is down
				m_hotkeydowncount += 1
				'increase the number of keys down in this set
				If HotKeysActivated Then
                    'because of the increase, check whether the set is activated
                    RaiseEvent OnHotKeysDownOnce(Me, New HotKeyArgs(DateTime.Now))
                    'Call the initial event
                End If
			End If
		End Sub

		Private Sub OnKeyUp(k As Keys)
			If m_hotkeystate.ContainsKey(k) AndAlso m_hotkeystate(k) Then
				'indicates the key's state was down but now it's up
				Dim wasActive As Boolean = HotKeysActivated

				m_hotkeystate(k) = False
				'key's state is up
				m_hotkeydowncount -= 1
				'this set is no longer ready
				If wasActive Then
                    RaiseEvent OnHotKeysUp(Me, New HotKeyArgs(DateTime.Now))
                    'call the KeyUp event because the set is no longer active
                End If
			End If
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
