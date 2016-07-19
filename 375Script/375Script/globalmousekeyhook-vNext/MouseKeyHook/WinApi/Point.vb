
' This code is distributed under MIT license. 
' Copyright (c) 2015 George Mamaladze
' See license.txt or http://opensource.org/licenses/mit-license.php

Imports System.Runtime.InteropServices

Namespace Gma.System.MouseKeyHook.WinApi
	''' <summary>
	'''     The Point structure defines the X- and Y- coordinates of a point.
	''' </summary>
	''' <remarks>
	'''     http://msdn.microsoft.com/library/default.asp?url=/library/en-us/gdi/rectangl_0tiq.asp
	''' </remarks>
	<StructLayout(LayoutKind.Sequential)> _
	Friend Structure Point
		''' <summary>
		'''     Specifies the X-coordinate of the point.
		''' </summary>
		Public X As Integer

		''' <summary>
		'''     Specifies the Y-coordinate of the point.
		''' </summary>
		Public Y As Integer

		Public Sub New(x__1 As Integer, y__2 As Integer)
			X = x__1
			Y = y__2
		End Sub

		Public Shared Operator =(a As Point, b As Point) As Boolean
			Return a.X = b.X AndAlso a.Y = b.Y
		End Operator

		Public Shared Operator <>(a As Point, b As Point) As Boolean
			Return Not (a = b)
		End Operator

        Public Overloads Function Equals(other As Point) As Boolean
            Return other.X = X AndAlso other.Y = Y
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
			If ReferenceEquals(Nothing, obj) Then
				Return False
			End If
            If TypeOf obj IsNot Point Then
                Return False
            End If
            Return Equals(CType(obj, Point))
		End Function

		Public Overrides Function GetHashCode() As Integer
						Return (X * 397) Xor Y

		End Function
	End Structure
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
