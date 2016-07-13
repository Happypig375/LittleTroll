Imports System.Runtime.Serialization

Partial Public Class Editor
    Public Function GetPredefinedVariable(Name As String) As String
        Select Case Name
            Case "filename"
                Return Open.SafeFileName
            Case "filelocation"
                Return Open.FileName
            Case Else
                If IsNumeric(Name) Then Return SurrogatePair.Chr(Name)
                Return PredefinedVariables(Name)
        End Select
    End Function
    Public PredefinedVariables As New ReadOnlyDictionary(Of String, String)(
        {"", " $$ "},
        {"tableflip", "(╯°□°)╯︵ ┻━┻"},
        {"version", My.Application.Info.Version.ToString},
        {"systemversion", My.Computer.Info.OSVersion},
        {"directory", My.Application.Info.DirectoryPath})

    Public Class ReadOnlyDictionary(Of TKey, TValue)
        Inherits ReadOnlyCollectionBase
        Implements IDictionary(Of TKey, TValue),
        IEmptyInterface, 'IDictionary, IReadOnlyDictionary(Of TKey, TValue),ISerializable, IDeserializationCallback
        ICollection(Of KeyValuePair(Of TKey, TValue)), IEnumerable(Of KeyValuePair(Of TKey, TValue)), IEnumerable
        Private ReadOnly _dictionary As IDictionary(Of TKey, TValue)

        Public Sub New()
            _dictionary = New Dictionary(Of TKey, TValue)()
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue))
            _dictionary = New Dictionary(Of TKey, TValue)(dictionary)
        End Sub

        Public Sub New(Key As TKey, Value As TValue)
            Me.New
            _dictionary.Add(Key, Value)
        End Sub

        Public Sub New(KeyValuePair As KeyValuePair(Of TKey, TValue))
            Me.New
            _dictionary.Add(KeyValuePair)
        End Sub

        Public Sub New(KeyValuePairs As KeyValuePair(Of TKey, TValue)())
            Me.New
            _dictionary = KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Sub

        Public Sub New(ParamArray KeyValuePairs As Object()())
            Me.New
            For Each KeyValue As Object() In KeyValuePairs
                _dictionary.Add(KeyValue(0), KeyValue(1))
            Next
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), Key As TKey, Value As TValue)
            Me.New(dictionary)
            _dictionary.Add(Key, Value)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), KeyValuePair As KeyValuePair(Of TKey, TValue))
            Me.New(dictionary)
            _dictionary.Add(KeyValuePair)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), KeyValuePairs As KeyValuePair(Of TKey, TValue)())
            Me.New(dictionary)
            _dictionary = KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), ParamArray KeyValuePairs As Object()())
            Me.New(dictionary)
            For Each KeyValue As Object() In KeyValuePairs
                _dictionary.Add(KeyValue(0), KeyValue(1))
            Next
        End Sub

#Region "IEqualityComparer<TKey> Constructers"

        Public Sub New(comparer As IEqualityComparer(Of TKey))
            _dictionary = New Dictionary(Of TKey, TValue)(comparer)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), comparer As IEqualityComparer(Of TKey))
            _dictionary = New Dictionary(Of TKey, TValue)(dictionary, comparer)
        End Sub

        Public Sub New(Key As TKey, Value As TValue, comparer As IEqualityComparer(Of TKey))
            Me.New(comparer)
            _dictionary.Add(Key, Value)
        End Sub

        Public Sub New(KeyValuePair As KeyValuePair(Of TKey, TValue), comparer As IEqualityComparer(Of TKey))
            Me.New(comparer)
            _dictionary.Add(KeyValuePair)
        End Sub

        Public Sub New(KeyValuePairs As KeyValuePair(Of TKey, TValue)(), comparer As IEqualityComparer(Of TKey))
            Me.New(comparer)
            _dictionary = KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Sub

        Public Sub New(comparer As IEqualityComparer(Of TKey), ParamArray KeyValuePairs As Object()())
            Me.New(comparer)
            For Each KeyValue As Object() In KeyValuePairs
                _dictionary.Add(KeyValue(0), KeyValue(1))
            Next
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), Key As TKey, Value As TValue, comparer As IEqualityComparer(Of TKey))
            Me.New(dictionary, comparer)
            _dictionary.Add(Key, Value)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), KeyValuePair As KeyValuePair(Of TKey, TValue), comparer As IEqualityComparer(Of TKey))
            Me.New(dictionary, comparer)
            _dictionary.Add(KeyValuePair)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), KeyValuePairs As KeyValuePair(Of TKey, TValue)(), comparer As IEqualityComparer(Of TKey))
            Me.New(dictionary, comparer)
            _dictionary = KeyValuePairs.ToDictionary(Function(x) x.Key, Function(x) x.Value)
        End Sub

        Public Sub New(dictionary As IDictionary(Of TKey, TValue), comparer As IEqualityComparer(Of TKey), ParamArray KeyValuePairs As Object()())
            Me.New(dictionary, comparer)
            For Each KeyValue As Object() In KeyValuePairs
                _dictionary.Add(KeyValue(0), KeyValue(1))
            Next
        End Sub
#End Region

#Region "IDictionary<TKey,TValue> Members"

        Private Sub IDictionary_Add(key As TKey, value As TValue) Implements IDictionary(Of TKey, TValue).Add
            Throw ReadOnlyException()
        End Sub

        Public Function ContainsKey(key As TKey) As Boolean Implements IDictionary(Of TKey, TValue).ContainsKey
            Return _dictionary.ContainsKey(key)
        End Function

        Public ReadOnly Property Keys() As ICollection(Of TKey) Implements IDictionary(Of TKey, TValue).Keys
            Get
                Return _dictionary.Keys
            End Get
        End Property

        Private Function IDictionary_Remove(key As TKey) As Boolean Implements IDictionary(Of TKey, TValue).Remove
            Throw ReadOnlyException()
        End Function

        Public Function TryGetValue(key As TKey, ByRef value As TValue) As Boolean Implements IDictionary(Of TKey, TValue).TryGetValue
            Return _dictionary.TryGetValue(key, value)
        End Function

        Public ReadOnly Property Values() As ICollection(Of TValue) Implements IDictionary(Of TKey, TValue).Values
            Get
                Return _dictionary.Values
            End Get
        End Property

        Public ReadOnly Property Item(key As TKey) As TValue
            Get
                Return _dictionary(key)
            End Get
        End Property

        Default Public Property IDictionary_Item(key As TKey) As TValue Implements IDictionary(Of TKey, TValue).Item
            Get
                Return _dictionary(key)
            End Get
            Set
                Throw ReadOnlyException()
            End Set
        End Property

#End Region

#Region "ICollection<KeyValuePair<TKey,TValue>> Members"

        Private Sub ICollection_Add(item As KeyValuePair(Of TKey, TValue)) Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Add
            Throw ReadOnlyException()
        End Sub

        Private Sub ICollection_Clear() Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Clear
            Throw ReadOnlyException()
        End Sub

        Public Function Contains(item As KeyValuePair(Of TKey, TValue)) As Boolean Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Contains
            Return _dictionary.Contains(item)
        End Function

        Public Sub CopyTo(array As KeyValuePair(Of TKey, TValue)(), arrayIndex As Integer) Implements ICollection(Of KeyValuePair(Of TKey, TValue)).CopyTo
            _dictionary.CopyTo(array, arrayIndex)
        End Sub

        Public Overrides ReadOnly Property Count() As Integer Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Count
            Get
                Return _dictionary.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of KeyValuePair(Of TKey, TValue)).IsReadOnly
            Get
                Return True
            End Get
        End Property

        Private Function ICollection_Remove(item As KeyValuePair(Of TKey, TValue)) As Boolean Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Remove
            Throw ReadOnlyException()
        End Function

#End Region

#Region "IEnumerable<KeyValuePair<TKey,TValue>> Members"

        Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of TKey, TValue)) Implements IEnumerable(Of KeyValuePair(Of TKey, TValue)).GetEnumerator
            Return _dictionary.GetEnumerator()
        End Function

#End Region

#Region "IEnumerable Members"

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return GetEnumerator()
        End Function

#End Region
#If False Then
        ' auto-generated_required
        <System.Security.SecurityCritical>
        Public Overridable Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
            If info Is Nothing Then
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.info)
            End If
            info.AddValue(VersionName, Version)

#If FEATURE_RANDOMIZED_STRING_HASHING Then
	info.AddValue(ComparerName, HashHelpers.GetEqualityComparerForSerialization(comparer), GetType(IEqualityComparer(Of TKey)))
#Else
            info.AddValue(ComparerName, Comparer, GetType(IEqualityComparer(Of TKey)))
#End If

            info.AddValue(HashSizeName, If(buckets Is Nothing, 0, buckets.Length))
            'This is the length of the bucket array.
            If buckets IsNot Nothing Then
                Dim array As KeyValuePair(Of TKey, TValue)() = New KeyValuePair(Of TKey, TValue)(Count - 1) {}
                CopyTo(array, 0)
                info.AddValue(KeyValuePairsName, array, GetType(KeyValuePair(Of TKey, TValue)()))
            End If
        End Sub
        Public Overridable Sub OnDeserialization(sender As [Object])
            Dim siInfo As SerializationInfo
            HashHelpers.SerializationInfoTable.TryGetValue(Me, siInfo)

            If siInfo Is Nothing Then
                ' It might be necessary to call OnDeserialization from a container if the container object also implements
                ' OnDeserialization. However, remoting will call OnDeserialization again.
                ' We can return immediately if this function is called twice. 
                ' Note we set remove the serialization info from the table at the end of this method.
                Return
            End If

            Dim realVersion As Integer = siInfo.GetInt32(VersionName)
            Dim hashsize As Integer = siInfo.GetInt32(HashSizeName)
            Comparer = DirectCast(siInfo.GetValue(ComparerName, GetType(IEqualityComparer(Of TKey))), IEqualityComparer(Of TKey))

            If hashsize <> 0 Then
                buckets = New Integer(hashsize - 1) {}
                For i As Integer = 0 To buckets.Length - 1
                    buckets(i) = -1
                Next
                entries = New Entry(hashsize - 1) {}
                freeList = -1

                Dim array As KeyValuePair(Of TKey, TValue)() = DirectCast(siInfo.GetValue(KeyValuePairsName, GetType(KeyValuePair(Of TKey, TValue)())), KeyValuePair(Of TKey, TValue)())

                If array Is Nothing Then
                    ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_MissingKeys)
                End If

                For i As Integer = 0 To array.Length - 1
                    If array(i).Key Is Nothing Then
                        ThrowHelper.ThrowSerializationException(ExceptionResource.Serialization_NullKey)
                    End If
                    Insert(array(i).Key, array(i).Value, True)
                Next
            Else
                buckets = Nothing
            End If

            Version = realVersion
            HashHelpers.SerializationInfoTable.Remove(Me)
        End Sub
#End If


        Private Shared Function ReadOnlyException() As Exception
            Return New NotSupportedException("This dictionary is read-only")
        End Function

    End Class
End Class
Interface IEmptyInterface

End Interface
<ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
<Obsolete("This class is not intended to be used.", True)>
Class Test
    Sub Main()
        Dim a As new Dictionary(Of String, String)()
        a?.Add("", "")
    End Sub
End Class