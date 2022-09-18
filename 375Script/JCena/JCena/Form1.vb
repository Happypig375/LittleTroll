Public Class Form1
    Public Shared ReadOnly DownloadsGuid As New Guid("374DE290-123F-4565-9164-39C4925E467B")
    <Runtime.InteropServices.DllImport("shell32.dll", CharSet:=Runtime.InteropServices.CharSet.Unicode)>
    Private Shared Function SHGetKnownFolderPath(
    <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPStruct)>
    ByVal rfid As Guid, ByVal dwFlags As UInteger, ByVal hToken As IntPtr,
    ByRef pszPath As String) As Integer
    End Function

    Public ReadOnly Property Downloads As String
        Get
            Downloads = ""
            SHGetKnownFolderPath(DownloadsGuid, 0, IntPtr.Zero, Downloads)
        End Get
    End Property
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FilePath.Text = My.Computer.FileSystem.ReadAllText(My.Application.File.Value)
        OpenFile.InitialDirectory = Downloads
    End Sub

    Private Sub FilePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilePath.TextChanged
        My.Computer.FileSystem.WriteAllText(My.Application.File.Value, FilePath.Text, False)
    End Sub

    Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
        If OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then FilePath.Text = OpenFile.FileName
    End Sub
End Class