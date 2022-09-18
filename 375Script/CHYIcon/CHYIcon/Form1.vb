Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Hide()
    End Sub

    Private Sub MyForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason <> CloseReason.TaskManagerClosing And e.CloseReason <> CloseReason.WindowsShutDown Then
            e.Cancel = True
            Hide()
        End If
    End Sub

End Class
