Public Class Form1

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case "a"
                TextBox1.Text &= "ａ"
            Case "b"
            Case "c"
            Case "d"
            Case "e"
            Case "f"
            Case "g"
            Case "h"
            Case "i"
            Case "j"
            Case "k"
            Case "l"
            Case "m"
            Case "n"
            Case "o"
            Case "p"
            Case "q"
            Case "r"
            Case "s"
            Case "t"
            Case "u"
            Case "v"
            Case "w"
            Case "x"
            Case "y"
            Case "z"
        End Select
    End Sub
End Class
