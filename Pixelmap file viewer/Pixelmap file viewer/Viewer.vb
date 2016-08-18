Imports System.IO
Imports System.Text

Public Class Viewer
    Friend Changed As Boolean
    Private Sub FileOpen_Click(sender As Object, e As EventArgs) Handles FileOpen.Click
        If Not Open.ShowDialog = DialogResult.OK Then Return
        DisplayImage()
        Save.FileName = Open.SafeFileName
    End Sub

    Private Sub FileSave_Click(sender As Object, e As EventArgs) Handles FileSave.Click
        If Not Changed Then Exit Sub
        If Not String.IsNullOrEmpty(FilePath) Then
            SaveImage()
        Else
            FileSaveAs_Click(sender, e)
        End If
    End Sub

    Private Sub FileSaveAs_Click(sender As Object, e As EventArgs) Handles FileSaveAs.Click
        If Not Save.ShowDialog = DialogResult.OK Then Return
        SaveImage()
    End Sub

    Private Sub FileNew_Click(sender As Object, e As EventArgs) Handles FileNew.Click
        SetColor(Color.White)
    End Sub

    Private Sub FileReload_Click(sender As Object, e As EventArgs) Handles FileReload.Click
        If String.IsNullOrEmpty(FilePath) Then Exit Sub
        DisplayImage()
    End Sub

    Friend Sub FilePrint_Click(sender As Object, e As EventArgs) Handles FilePrint.Click
        Dim pd As New Printing.PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintPage
        pd.Print()
    End Sub

    Private Sub PrintPage(o As Object, e As Printing.PrintPageEventArgs)
        e.Graphics.DrawImage(View.Image, New Point(100, 100))
    End Sub

    Friend ReadOnly Property FilePath As String
        Get
            Return Open.FileName
        End Get
    End Property

    Friend Sub DisplayImage()
        DisplayImage(FilePath)
    End Sub

    Friend Sub DisplayImage(Path As String)
        Select Case IO.Path.GetExtension(Path).ToLower
            Case ".pmp"
                Using Reader As New StreamReader(Open.OpenFile, Encoding.UTF32)
                    While Not Reader.EndOfStream
                        Dim BitMap As New Bitmap(Reader.Read, Reader.Read())
                        BitMap.SetResolution(Reader.Read(), Reader.Read())
                        For i As Integer = 0 To BitMap.Width - 1
                            For j As Integer = 0 To BitMap.Height - 1
                                BitMap.SetPixel(i, j, Color.FromArgb(Reader.Read()))
                            Next
                        Next
                        View.Image = BitMap
                    End While
                End Using
            Case Else
                View.Image = Image.FromFile(Path)
        End Select
    End Sub

    Friend Sub SaveImage()
        SaveImage(Save.FileName)
    End Sub

    Friend Sub SaveImage(Path As String)
        Select Case IO.Path.GetExtension(Path).ToLower
            Case ".pmp"
                Using fs As New FileStream(Path, FileMode.Create)
                    Dim BOM() As Byte = New UTF32Encoding().GetPreamble() ' Create a UTF-32 encoding that supports a BOM.
                    fs.Write(BOM, 0, BOM.Length)
                    Dim Bytes(4) As Byte
                    Bytes = BitConverter.GetBytes(View.Image.Width)
                    fs.Write(Bytes, 0, 4)
                    Bytes = BitConverter.GetBytes(View.Image.Height)
                    fs.Write(Bytes, 0, 4)
                    Bytes = BitConverter.GetBytes(View.Image.HorizontalResolution)
                    fs.Write(Bytes, 0, 4)
                    Bytes = BitConverter.GetBytes(View.Image.VerticalResolution)
                    fs.Write(Bytes, 0, 4)
                    Dim BitMap As Bitmap = DirectCast(View.Image, Bitmap)
                    For i As Integer = 0 To View.Image.Width - 1
                        For j As Integer = 0 To View.Image.Height - 1
                            Bytes = BitConverter.GetBytes(BitMap.GetPixel(i, j).ToArgb)
                            fs.Write(Bytes, 0, 4)
                        Next
                    Next
                End Using
            Case Else
                View.Image.Save(Path)
        End Select
    End Sub

    Friend Sub SetColor(Color As Color)
        Dim BitMap As Bitmap = DirectCast(View.Image, Bitmap)
        For i As Integer = 0 To BitMap.Width
            For j As Integer = 0 To BitMap.Height
                BitMap.SetPixel(i, j, Color)
            Next
        Next
        View.Image = BitMap
    End Sub
End Class
