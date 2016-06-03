Public Class Form

    Private Sub ExpectedCut_CheckedChanged(sender As Object, e As EventArgs) Handles ExpectedCut.CheckedChanged, Me.Load
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

    Private Sub Special_CheckedChanged(sender As Object, e As EventArgs) Handles Special.CheckedChanged, Me.Load
        Specials.Enabled = Special.Checked
        SeriesNumber.Enabled = Specials.Enabled
        VideoNumber.Enabled = Specials.Enabled
        SubscribeCount.Enabled = Specials.Enabled
    End Sub

    Private Sub SeriesNumber_CheckedChanged(sender As Object, e As EventArgs) Handles SeriesNumber.CheckedChanged, Me.Load
        SeriesNumberApproximately.Enabled = SeriesNumber.Checked
    End Sub

    Private Sub SeriesNumberApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles SeriesNumberApproximately.CheckedChanged, Me.Load
        SeriesNumberApproximate.Enabled = SeriesNumberApproximately.Checked
    End Sub
    Private Sub VideoNumber_CheckedChanged(sender As Object, e As EventArgs) Handles VideoNumber.CheckedChanged, Me.Load
        VideoNumberApproximately.Enabled = VideoNumber.Checked
        VideoNumbers.Enabled = VideoNumber.Checked
    End Sub

    Private Sub VideoNumberApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles VideoNumberApproximately.CheckedChanged, Me.Load
        VideoNumberApproximate.Enabled = VideoNumberApproximately.Checked
    End Sub
    Private Sub SubscribeCount_CheckedChanged(sender As Object, e As EventArgs) Handles SubscribeCount.CheckedChanged, Me.Load
        SubscribeCountApproximately.Enabled = SubscribeCount.Checked
        SubscribeCounter.Enabled = SubscribeCount.Checked
    End Sub

    Private Sub SubscribeCountApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles SubscribeCountApproximately.CheckedChanged, Me.Load
        SubscribeCountApproximate.Enabled = SubscribeCountApproximately.Checked
    End Sub

    Private Sub Continued_CheckedChanged(sender As Object, e As EventArgs) Handles Continued.CheckedChanged, Me.Load
        ContinuedFrom.Enabled = Continued.Checked
        ContinuedFromBeta.Enabled = Continued.Checked
        ContinuedFromColon.Enabled = Continued.Checked
        ContinuedFromMidfix.Enabled = Continued.Checked
        ContinuedFromNumber.Enabled = Continued.Checked
        ContinuedFromPrefix.Enabled = Continued.Checked
        ContinuedFromSeries.Enabled = Continued.Checked
        ContinuedFromSubseries.Enabled = Continued.Checked
        ContinuedFromSuffix.Enabled = Continued.Checked
        Refresh()
    End Sub
    Private Overloads Sub Refresh(sender As Object, e As EventArgs) Handles Me.Load, Beta.Click, Continued.Click,
        ContinuedFromBeta.Click, ContinuedFromNumber.ValueChanged, ContinuedFromSeries.TextChanged,
        ContinuedFromSubseries.TextChanged, ContinuedFromSuffix.TextChanged, Copy.Click, Duo.Click, ExpectedCut.Click,
        Extra.Click, JustRecord.Click, List.SelectedIndexChanged, Multiple.Click, NoNarration.Click, NotSuggested.Click,
        Number.ValueChanged, NumberSuffix.TextChanged, Series.TextChanged, SeriesNumber.Click, SeriesNumberApproximate.ValueChanged,
        SeriesNumberApproximately.Click, Solo.Click, Special.Click, Speedrun.Click, SpeedrunMultiplier.ValueChanged,
        SubscribeCount.Click, SubscribeCountApproximate.ValueChanged, SubscribeCountApproximately.Click,
        SubscribeCounter.ValueChanged, SubSeries.TextChanged, Title.TextChanged, Triple.Click, VideoNumber.Click,
        VideoNumberApproximate.ValueChanged, VideoNumberApproximately.Click, VideoNumbers.ValueChanged

        MyBase.Refresh()
        Output.Text = Prefix.Text & Series.Text & SeriesColon.Text &
            SubSeries.Text & Midfix.Text & Number.Value & NumberSuffix.Text &
            Colon.Text & Title.Text & If(Solo.Checked, String.Empty, If(Duo.Checked, "[D]", If(Triple.Checked, "[T]", "[M]"))) &
 _
            If(Special.Checked AndAlso (SeriesNumber.Checked OrElse VideoNumber.Checked OrElse SubscribeCount.Checked),
            "[S-" & If(SeriesNumber.Checked, "SM" & Number.Value &
            If(SeriesNumberApproximately.Checked, "("c & SeriesNumberApproximate.Value & ")"c, String.Empty) &
            If(VideoNumber.Checked OrElse SubscribeCount.Checked, ","c, String.Empty), String.Empty) &
 _
            If(VideoNumber.Checked, "V" & VideoNumbers.Value &
            If(VideoNumberApproximately.Checked, "("c & VideoNumberApproximate.Value & ")"c, String.Empty) &
            If(SubscribeCount.Checked, ","c, String.Empty), String.Empty) &
 _
            If(SubscribeCount.Checked, "S" & SubscribeCounter.Value &
            If(SubscribeCountApproximately.Checked, "("c & SubscribeCountApproximate.Value & ")"c, String.Empty) &
            If(SubscribeCount.Checked, ","c, String.Empty), String.Empty) &
            "]"c, String.Empty)
    End Sub
    Friend Function GetCode(Name As String) As String
        Select Case Name
            Case "Minecraft遊記"
                Return "M"
            Case "Minecraft編輯遊記"
                Return "M"
            Case "Minecraft Hide&Seek遊記"
                Return "M"
            Case "Minecraft Universe遊記"
                Return "M"
            Case "Minecraft版本遊記"
                Return "M"
            Case "Minecraft玩人記"
                Return "M"
            Case "Minecraft Skyblock遊記"
                Return "M"
            Case "Minecraft生存"
                Return "M"
            Case "Minecraft村莊生存"
                Return "M"
            Case "LAN連線記"
                Return "M"
            Case "---"
                Return "M"
            Case "頻道更新"
                Return "M"
            Case "Agar.io"
                Return "M"
            Case "Vlog"
                Return "M"
            Case "趣遊"
                Return "M"
            Case "小遊戲時間"
                Return "M"
        End Select
    End Function
    Friend Enum Serie As Byte
        Minecraft遊記
        Minecraft編輯遊記
        Minecraft_HidenSeek遊記
        Minecraft_Universe遊記
        Minecraft版本遊記
        Minecraft玩人記
        Minecraft_Skyblock遊記
        Minecraft生存
        Minecraft村莊生存
        LAN連線記
        ___ = 255
        頻道更新 = 128
        Agar_io
        Vlog
        趣遊
        小遊戲時間
    End Enum
End Class
