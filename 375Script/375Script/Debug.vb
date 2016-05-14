Public Class Debug
    Private KeyNeeded As Boolean = False
    Private _ReturnKey As Keys
    Private Property ReturnKey As Keys
        Get
            Return _ReturnKey
        End Get
        Set(value As Keys)
            If KeyNeeded Then _ReturnKey = value
        End Set
    End Property
    Public Sub Write(Input As Object)
        Console.AppendText(Convert.ToString(Input))
    End Sub
    Public Sub Write(Input As String, ParamArray Params() As Object)
        Static Var As Int16 = Var + 1
        Input = String.Format(Input, Params)
        Write(Input)
    End Sub
    Public Sub WriteLine(Input As Object)
        Console.AppendText(Convert.ToString(Input) & vbCrLf)
    End Sub
    Public Sub WriteLine(Input As String, ParamArray Params() As Object)
        Input = String.Format(Input, Params)
        WriteLine(Input)
    End Sub
    Public Function ReadKey() As Keys
        KeyNeeded = True
        ReturnKey = Keys.None
        While ReturnKey = Keys.None
        End While
        Return ReturnKey
    End Function

    Private Sub Debug_KeyPress(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Oemplus
                If e.Control Then
                    If e.Shift Then
                        Dim Factor As Single = Console.ZoomFactor * 2
                        Console.ZoomFactor = If(Factor <= 63.9999962F, Factor, 63.9999962F)
                    Else
                        Console.ZoomFactor = 1
                    End If
                Else
                    If KeyNeeded Then ReturnKey = e.KeyCode
                End If
            Case Keys.OemMinus
                If e.Control Then
                    If e.Shift Then
                        Dim Factor As Single = Console.ZoomFactor / 2
                        Console.ZoomFactor = If(Factor >= 0.0156250019F, Factor, 0.0156250019F)
                    Else
                        Dim Factor As Single = Val(InputBox("Input the zoom factor: " & vbCrLf &
                                                            "(Must be between 1/64 (0.015625) and 64.0, not inclusive." &
                                                            " A value of 1.0 indicates that no zoom is applied.)", "Set Zoom", Console.ZoomFactor))
                        Console.ZoomFactor = If(Factor >= 0.0156250019F, If(Factor <= 63.9999962F, Factor, 63.9999962F), 0.0156250019F)
                    End If
                Else
                    If KeyNeeded Then ReturnKey = e.KeyCode
                End If
            Case Else
                If KeyNeeded Then ReturnKey = e.KeyCode
        End Select
    End Sub

End Class