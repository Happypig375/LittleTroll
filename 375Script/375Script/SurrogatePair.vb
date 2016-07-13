Structure SurrogatePair
    Sub New(Chr As Char)
        IsSurrogatePair = False
        SingleChar = Chr
    End Sub
    Sub New(Str As String)
        Select Case Str.Length
            Case 0
                IsSurrogatePair = False
                SingleChar = Nothing
            Case 1
                IsSurrogatePair = False
                SingleChar = Str
            Case 2
                IsSurrogatePair = True
                HighSurrogate = Str(0)
                LowSurrogate = Str(1)
            Case Else
                Throw New ArgumentOutOfRangeException("Str", "The string is too long.")
        End Select
    End Sub
    Private _HighSurrogate As Char
    Public Property HighSurrogate As Char
        Get
            Return _HighSurrogate
        End Get
        Set(value As Char)
            If AscW(value) < &HD800 OrElse AscW(value) > &HDBFF Then Throw New ArgumentOutOfRangeException("Value is not a high surrogate.")
            _HighSurrogate = value
        End Set
    End Property
    Private _LowSurrogate As Char
    Public Property LowSurrogate As Char
        Get
            Return _LowSurrogate
        End Get
        Set(value As Char)
            If AscW(value) < &HDC00 OrElse AscW(value) > &HDFFF Then Throw New ArgumentOutOfRangeException("Value is not a low surrogate.")
            _LowSurrogate = value
        End Set
    End Property
    Public Property IsSurrogatePair As Boolean
    Public ReadOnly Property IsPrivateUsePlane As Boolean
        Get
            Return IsSurrogatePair AndAlso AscW(HighSurrogate) > &HDB80 AndAlso AscW(HighSurrogate) < &HDBFF
        End Get
    End Property
    Public Property SingleChar As Char
    Public Overrides Function ToString() As String
        Return If(IsSurrogatePair, HighSurrogate & LowSurrogate, SingleChar)
    End Function
    Public Function Asc() As UInteger
        Return If(IsSurrogatePair, &H10000 + (AscW(HighSurrogate) - &HD800) * &H400 + (AscW(LowSurrogate) - &HDC00), AscW(SingleChar))
    End Function
    Public Shared Function Asc(Pair As SurrogatePair) As UInteger
        Return If(Pair.IsSurrogatePair, &H10000 + (AscW(Pair.HighSurrogate) - &HD800) *
            &H400 + (AscW(Pair.LowSurrogate) - &HDC00), AscW(Pair.SingleChar))
    End Function
    Public Shared Function Chr(CodePoint As String) As String
        Return Chr(Convert.ToUInt32(Val(CodePoint))).ToString
    End Function
    Public Shared Function Chr(CodePoint As UInteger) As String
        Return New SurrogatePair(CodePoint).ToString
    End Function
    Public Shared Function Parse(CodePoint As UInteger) As SurrogatePair
        Return New SurrogatePair(CodePoint)
    End Function
    Sub New(CodePoint As UInteger)
        If CodePoint <= &HFFFF Then
            IsSurrogatePair = False
            SingleChar = ChrW(CodePoint)
        ElseIf CodePoint <= &H10FFFF Then
            IsSurrogatePair = True
            CodePoint -= &H10000
            LowSurrogate = ChrW(CodePoint Mod &H400 + &HDC00)
            HighSurrogate = ChrW(CodePoint \ &H400 + &HD800)
        Else
            Throw New ArgumentOutOfRangeException("CodePoint", "The code point is too big.")
        End If
    End Sub
    Sub New(CodePoint As Integer)
        Me.New(Convert.ToUInt32(CodePoint))
    End Sub
    Sub New(Plane As Planes, CodePoint As UShort)
        If Plane = Planes.Basic_Multilingual_Plane Then
            IsSurrogatePair = False
            SingleChar = ChrW(CodePoint)
        ElseIf CodePoint <= &H10FFFF Then
            IsSurrogatePair = True
            Plane -= 1
            LowSurrogate = ChrW((CodePoint + Plane * &H10000) Mod &H400 + &HDC00)
            HighSurrogate = ChrW((CodePoint + Plane * &H10000) \ &H400 + &HD800)
        End If
    End Sub
    Enum Planes As SByte
        Basic_Multilingual_Plane
        Supplementary_Multilingual_Plane
        Supplementary_Ideographic_Plane
        Tertiary_Ideographic_Plane
        Supplementary_Special_purpose_Plane = 14
        Supplementary_Private_Use_Area_A
        Supplementary_Private_Use_Area_B
    End Enum
#If False Then
        Plane 0 	Plane 1 	Plane 2 	Planes 3–13 	Plane 14 	Planes 15–16
       0000–​FFFF  10000–​1FFFF 20000–​2FFFF   30000–​DFFFF    E0000–​EFFFF  F0000–​10FFFF
          BMP 	      SMP 	     SIP 	    unassigned         SSP    	  SPUA-A/B
#End If
    Shared Operator *(Pair As SurrogatePair, Multiplier As Integer) As String
        Return StrDup(Multiplier, Pair.ToString)
    End Operator
    Shared Operator =(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As Boolean
        If Pair1.IsSurrogatePair <> Pair2.IsSurrogatePair Then Return False
        If Pair1.IsSurrogatePair Then
            If Pair1.HighSurrogate <> Pair2.HighSurrogate Then Return False
            If Pair1.LowSurrogate <> Pair2.LowSurrogate Then Return False
        Else
            If Pair1.SingleChar <> Pair2.SingleChar Then Return False
        End If
        Return True
    End Operator
    Shared Operator =(Pair As SurrogatePair, Chr As Char) As Boolean
        If Pair.IsSurrogatePair Then Return False
        If Pair.SingleChar <> Chr Then Return False
        Return True
    End Operator
    Shared Operator <>(Pair As SurrogatePair, Chr As Char) As Boolean
        If Pair.IsSurrogatePair Then Return True
        If Pair.SingleChar <> Chr Then Return True
        Return False
    End Operator
    Shared Operator =(Chr As Char, Pair As SurrogatePair) As Boolean
        If Pair.IsSurrogatePair Then Return False
        If Pair.SingleChar <> Chr Then Return False
        Return True
    End Operator
    Shared Operator <>(Chr As Char, Pair As SurrogatePair) As Boolean
        If Pair.IsSurrogatePair Then Return True
        If Pair.SingleChar <> Chr Then Return True
        Return False
    End Operator
    Shared Operator =(Pair As SurrogatePair, Str As String) As Boolean
        Select Case Str.Length
            Case 0
                If Pair.IsSurrogatePair Then Return False
                If Pair.SingleChar <> Nothing Then Return False
                Return True
            Case 1
                If Pair.IsSurrogatePair Then Return False
                If Pair.SingleChar <> Str Then Return False
                Return True
            Case 2
                If Not Pair.IsSurrogatePair Then Return False
                If Pair.ToString <> Str Then Return False
                Return True
            Case Else
                Return False
        End Select
    End Operator
    Shared Operator <>(Pair As SurrogatePair, Str As String) As Boolean
        Select Case Str.Length
            Case 0
                If Pair.IsSurrogatePair Then Return True
                If Pair.SingleChar <> Nothing Then Return True
                Return False
            Case 1
                If Pair.IsSurrogatePair Then Return True
                If Pair.SingleChar <> Str Then Return True
                Return False
            Case 2
                If Not Pair.IsSurrogatePair Then Return True
                If Pair.ToString <> Str Then Return True
                Return False
            Case Else
                Return True
        End Select
    End Operator
    Shared Operator =(Str As String, Pair As SurrogatePair) As Boolean
        Select Case Str.Length
            Case 0
                If Pair.IsSurrogatePair Then Return False
                If Pair.SingleChar <> Nothing Then Return False
                Return True
            Case 1
                If Pair.IsSurrogatePair Then Return False
                If Pair.SingleChar <> Str Then Return False
                Return True
            Case 2
                If Not Pair.IsSurrogatePair Then Return False
                If Pair.ToString <> Str Then Return False
                Return True
            Case Else
                Return False
        End Select
    End Operator
    Shared Operator <>(Str As String, Pair As SurrogatePair) As Boolean
        Select Case Str.Length
            Case 0
                If Pair.IsSurrogatePair Then Return True
                If Pair.SingleChar <> Nothing Then Return True
                Return False
            Case 1
                If Pair.IsSurrogatePair Then Return True
                If Pair.SingleChar <> Str Then Return True
                Return False
            Case 2
                If Not Pair.IsSurrogatePair Then Return True
                If Pair.ToString <> Str Then Return True
                Return False
            Case Else
                Return True
        End Select
    End Operator
    Shared Operator <>(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As Boolean
        If Pair1.IsSurrogatePair = Pair2.IsSurrogatePair Then Return False
        If Pair1.IsSurrogatePair Then
            If Pair1.HighSurrogate = Pair2.HighSurrogate Then Return False
            If Pair1.LowSurrogate = Pair2.LowSurrogate Then Return False
        Else
            If Pair1.SingleChar = Pair2.SingleChar Then Return False
        End If
        Return True
    End Operator
    Shared Operator &(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As String
        Return Pair1.ToString & Pair2.ToString
    End Operator
    Shared Operator &(Chr As Char, Pair As SurrogatePair) As String
        Return Chr & Pair.ToString
    End Operator
    Shared Operator &(Pair As SurrogatePair, Chr As Char) As String
        Return Pair.ToString & Chr
    End Operator
    Shared Operator &(Str As String, Pair As SurrogatePair) As String
        Return Str & Pair.ToString
    End Operator
    Shared Operator &(Pair As SurrogatePair, Str As String) As String
        Return Pair.ToString & Str
    End Operator
    Shared Operator &(Obj As Object, Pair As SurrogatePair) As String
        Return Obj.ToString & Pair.ToString
    End Operator
    Shared Operator &(Pair As SurrogatePair, Obj As Object) As String
        Return Pair.ToString & Obj.ToString
    End Operator
    Shared Operator +(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As String
        Return Pair1.ToString + Pair2.ToString
    End Operator
    Shared Operator +(Chr As Char, Pair As SurrogatePair) As String
        Return Chr + Pair.ToString
    End Operator
    Shared Operator +(Pair As SurrogatePair, Chr As Char) As String
        Return Pair.ToString + Chr
    End Operator
    Shared Operator +(Str As String, Pair As SurrogatePair) As String
        Return Str + Pair.ToString
    End Operator
    Shared Operator +(Pair As SurrogatePair, Str As String) As String
        Return Pair.ToString + Str
    End Operator
    Shared Operator +(Obj As Object, Pair As SurrogatePair) As String
        Return Obj.ToString + Pair.ToString
    End Operator
    Shared Operator +(Pair As SurrogatePair, Obj As Object) As String
        Return Pair.ToString + Obj.ToString
    End Operator
    Shared Widening Operator CType(Pair As SurrogatePair) As String
        Return Pair.ToString
    End Operator
    Shared Narrowing Operator CType(Str As String) As SurrogatePair
        Return New SurrogatePair(Str)
    End Operator
    Shared Narrowing Operator CType(Pair As SurrogatePair) As Char
        If Pair.IsSurrogatePair Then Throw New ArgumentOutOfRangeException("Pair", "Chars cannot handle surrogate pairs.")
        Return Pair.SingleChar
    End Operator
    Shared Widening Operator CType(Chr As Char) As SurrogatePair
        Return New SurrogatePair(Chr)
    End Operator
End Structure
