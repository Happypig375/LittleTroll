Public Class Form
    Friend ReadOnly AVI As String = My.Computer.FileSystem.CurrentDirectory & "\AVI.settings"
    Friend Const Delimiter As Char = ChrW(7)
    ' Friend Reader As New FileIO.TextFieldParser(AVI, System.Text.Encoding.Unicode) With {.Delimiters = {Delimiter.ToString}, .TrimWhiteSpace = True}
    'Friend Writer As New IO.StreamWriter(AVI, False) With {.NewLine = vbCrLf}
    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        Series.SelectedIndex = 0
        ContinuedFromSeries.SelectedIndex = 0
        Title.Text = Chr(8)
    End Sub
    Private Sub ExpectedCut_CheckedChanged(sender As Object, e As EventArgs) Handles ExpectedCut.CheckedChanged, Me.Load
        If ExpectedCut.Checked Then
            NumberSuffix.Items.Clear()
            NumberSuffix.Items.Add("")
            For i = Asc("a"c) To Asc("z"c)
                NumberSuffix.Items.Add(Chr(i))
            Next
        Else
            NumberSuffix.Items.Clear()
            NumberSuffix.Items.Add("")
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
            SubSeries.Text & Midfix.Text & If(Beta.Checked, "Beta ", String.Empty) & Number.Value & NumberSuffix.Text &
            Colon.Text & Title.Text & " "c & If(Solo.Checked, String.Empty, If(Duo.Checked, "[D]", If(Triple.Checked, "[T]", "[M]"))) &
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
            "]"c, String.Empty) &
 _
            If(Continued.Checked, "[C-" & GetCode(ContinuedFromSeries.SelectedItem) & If(ContinuedFromBeta.Checked, "b"c, String.Empty) &
               ContinuedFromNumber.Value & ContinuedFromSuffix.Text & "]"c, String.Empty) &
 _
           If(NoNarration.Checked, "[NN]", String.Empty) & If(Speedrun.Checked, "[R" & SpeedrunMultiplier.Value & "]"c, String.Empty) &
           If(Extra.Checked, "[E]", String.Empty) & If(NotSuggested.Checked, "[X]", String.Empty) & If(JustRecord.Checked, "[J]", String.Empty)
    End Sub
    Friend Function GetCode(Name As String) As String
        Select Case Name
            Case "Minecraft遊記"
                Return "M"
            Case "Minecraft編輯遊記"
                Return "ME"
            Case "Minecraft Hide&Seek遊記"
                Return "MH"
            Case "Minecraft Universe遊記"
                Return "MU"
            Case "Minecraft版本遊記"
                Return "MV"
            Case "Minecraft玩人記"
                Return "MT"
            Case "Minecraft Skyblock遊記"
                Return "MB"
            Case "Minecraft生存"
                Return "MS"
            Case "Minecraft村莊生存"
                Return "MVS"
            Case "LAN連線記"
                Return "L"
            Case "頻道更新"
                Return "U"
            Case "Agar.io"
                Return "A"
            Case "Vlog"
                Return "V"
            Case "趣遊"
                Return "F"
            Case "小遊戲時間"
                Return "G"
            Case "VVVVVV"
                Return "VV"
            Case ""
                Return ""
            Case Else
                '  Throw New ArgumentException
                Error 11
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

    Private Sub ContinuedFromExpectedCut_CheckedChanged(sender As Object, e As EventArgs) Handles ContinuedFromExpectedCut.CheckedChanged, Me.Load
        If ContinuedFromExpectedCut.Checked Then
            ContinuedFromSuffix.Items.Clear()
            ContinuedFromSuffix.Items.Add("")
            For i = Asc("a"c) To Asc("z"c)
                ContinuedFromSuffix.Items.Add(Chr(i))
            Next
        Else
            ContinuedFromSuffix.Items.Clear()
            ContinuedFromSuffix.Items.Add("")
            For i = 1 To 99
                ContinuedFromSuffix.Items.Add("_"c & i)
            Next
        End If

    End Sub
End Class
