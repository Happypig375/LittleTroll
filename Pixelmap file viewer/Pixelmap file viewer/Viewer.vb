﻿Public Class Viewer
    Private Sub FileOpen_Click(sender As Object, e As EventArgs) Handles FileOpen.Click
        If Not Open.ShowDialog = DialogResult.OK Then Return
        Using Reader As New IO.StreamReader(Open.OpenFile, System.Text.Encoding.UTF32)
            While Not Reader.EndOfStream
                Dim BitMap As New Bitmap(Reader.Read(), Reader.Read())
                For i As Integer = 0 To BitMap.Width
                    For j As Integer = 0 To BitMap.Height
                        Dim Pixel As String = Convert.ToString(Reader.Read(), 16)
                        Pixel = Pixel.PadLeft(6, "0"c)
                        Pixel = Pixel.PadLeft(8, "F"c)
                        Dim PixelColor As Color = Color.FromArgb(Val("&H" & Pixel))
                    Next
                Next
            End While
        End Using
    End Sub
End Class
