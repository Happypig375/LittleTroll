Public Class Form

    Private Sub ExpectedCut_CheckedChanged(sender As Object, e As EventArgs) Handles ExpectedCut.CheckedChanged
        If ExpectedCut.Checked Then
            NumberSuffix.Items.Clear()
            For i = Asc("a"c) To Asc("z"c)
                NumberSuffix.Items.Add(Chr(i))
            Next
        Else
            NumberSuffix.Items.Clear()
            For i = 1 To 99
                NumberSuffix.Items.Add("_"c & i)
            Next
        End If
    End Sub

    Private Sub Special_CheckedChanged(sender As Object, e As EventArgs) Handles Special.CheckedChanged
        Specials.Enabled = Special.Checked
    End Sub

    Private Sub SeriesNumber_CheckedChanged(sender As Object, e As EventArgs) Handles SeriesNumber.CheckedChanged
        SeriesNumberApproximately.Enabled = SeriesNumber.Checked
    End Sub

    Private Sub SeriesNumberApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles SeriesNumberApproximately.CheckedChanged
        SeriesNumberApproximate.Enabled = SeriesNumberApproximately.Checked
    End Sub
    Private Sub VideoNumber_CheckedChanged(sender As Object, e As EventArgs) Handles VideoNumber.CheckedChanged
        VideoNumberApproximately.Enabled = VideoNumber.Checked
    End Sub

    Private Sub VideoNumberApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles VideoNumberApproximately.CheckedChanged
        VideoNumberApproximate.Enabled = VideoNumberApproximately.Checked
    End Sub
    Private Sub SubscribeCount_CheckedChanged(sender As Object, e As EventArgs) Handles SubscribeCount.CheckedChanged
        SubscribeCountApproximately.Enabled = SubscribeCount.Checked
    End Sub

    Private Sub SubscribeCountApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles SubscribeCountApproximately.CheckedChanged
        SubscribeCountApproximate.Enabled = SubscribeCountApproximately.Checked
    End Sub

    Private Sub Specials_EnabledChanged(sender As Object, e As EventArgs) Handles Specials.EnabledChanged
        SeriesNumber.Enabled = Specials.Enabled
        VideoNumber.Enabled = Specials.Enabled
        SubscribeCount.Enabled = Specials.Enabled
    End Sub
End Class
