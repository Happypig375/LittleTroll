Public Class Form
    Friend ReadOnly AVI As String = My.Computer.FileSystem.CurrentDirectory & "\AVI.settings"
    Friend Const Delimiter As Char = ChrW(7)
    Friend Names As New List(Of String)
    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim Writer As New IO.StreamWriter(AVI, False) With {.NewLine = vbCrLf}
        Writer.WriteLine(List.SelectedItem & Delimiter & Output.Text)

#If False Then
        MsgBox(List.SelectedItem & Delimiter & Series.Text & Delimiter & SubSeries.Text & Delimiter &
                     Beta.Checked & Delimiter & Number.Value & Delimiter & NumberSuffix.Text & Delimiter &
                     SelectedRadioButton(Me).Name & Delimiter & Special.Checked & Delimiter &
                     SeriesNumber.Checked & Delimiter & SeriesNumberApproximately.Checked & Delimiter &
                     SeriesNumberApproximate.Value & Delimiter & VideoNumber.Checked & Delimiter &
                     VideoNumbers.Value & Delimiter & VideoNumberApproximately.Checked & Delimiter &
                     VideoNumberApproximate.Value & Delimiter & SubscribeCount.Checked & Delimiter &
                     SubscribeCounter.Value & Delimiter & SubscribeCountApproximately.Checked & Delimiter &
                     SubscribeCountApproximate.Value & Delimiter & ...)
#End If
    End Sub
    Friend Function SelectedRadioButton(Container As Control) As RadioButton
        For Each c As Control In Container.Controls
            If TypeOf c Is RadioButton AndAlso CType(c, RadioButton).Checked = True Then Return c
        Next
        Return Nothing
    End Function
    Function GetThreadState(ProcId As Integer, ThreadId As Integer) As Threading.ThreadState
        For Each Thr As Threading.Thread In Process.GetProcessById(ProcId).Threads
            If Thr.ManagedThreadId = ThreadId Then Return Thr.ThreadState
        Next
        Throw New ArgumentOutOfRangeException("Thread not found.")
    End Function
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load

        Series.SelectedIndex = 0
        ContinuedFromSeries.SelectedIndex = 0
        Title.Text = Chr(0)
Retry:  Try
            Dim Reader As New FileIO.TextFieldParser(AVI, System.Text.Encoding.Unicode) With {.Delimiters = {Delimiter.ToString}, .TrimWhiteSpace = True}
            Do Until Reader.EndOfData
                Dim Line As String() = Reader.ReadFields
                If Line.Count <> 2 Then Throw New FileIO.MalformedLineException("There are more than one or no delimiters in the line.", Reader.LineNumber - 1)
                List.Items.Add(Line(0))
                Names.Add(Line(1))
            Loop
        Catch ex As IO.FileNotFoundException
            Try
                My.Computer.FileSystem.WriteAllText(AVI, "", False)
                GoTo Retry
            Catch exc As UnauthorizedAccessException
                MsgBox("Do not have enough permission. Cannot load/save settings.", MsgBoxStyle.Exclamation)
            End Try
        Catch ex As FileIO.MalformedLineException
            MsgBox(ex.Message & vbCrLf & "Line number: " & ex.LineNumber)
        End Try
        If List.Items.Count = 0 Then
            List.Items.Add("<empty>")
            Names.Add("")
        End If
        List.SelectedIndex = 0
        AddHandler Output.TextChanged, AddressOf Output_TextChanged
        AddHandler List.SelectedIndexChanged, AddressOf List_SelectedIndexChanged
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
        Extra.Click, JustRecord.Click, Multiple.Click, NoNarration.Click, NotSuggested.Click, Number.ValueChanged,
         NumberSuffix.TextChanged, Series.TextChanged, SeriesNumber.Click, SeriesNumberApproximate.ValueChanged,
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
            If(Continued.Checked, "[C-" & ConvertCode(ContinuedFromSeries.SelectedItem, False) & If(ContinuedFromBeta.Checked, "b"c, String.Empty) &
               ContinuedFromNumber.Value & ContinuedFromSuffix.Text & "]"c, String.Empty) &
 _
           If(NoNarration.Checked, "[NN]", String.Empty) & If(Speedrun.Checked, "[R" & SpeedrunMultiplier.Value & "]"c, String.Empty) &
           If(Extra.Checked, "[E]", String.Empty) & If(NotSuggested.Checked, "[X]", String.Empty) & If(JustRecord.Checked, "[J]", String.Empty)
    End Sub
    Friend Function ConvertCode(Input As String, Code As Boolean) As String
        Dim Codes As New Dictionary(Of String, String) From {
            {"Minecraft遊記", "M"},
            {"Minecraft編輯遊記", "ME"},
            {"Minecraft Hide&Seek遊記", "MH"},
            {"Minecraft Universe遊記", "MU"},
            {"Minecraft版本遊記", "MV"},
            {"Minecraft玩人記", "MT"},
            {"Minecraft Skyblock遊記", "MB"},
            {"Minecraft生存", "MS"},
            {"Minecraft村莊生存", "MVS"},
            {"LAN連線記", "L"},
            {"頻道更新", "U"},
            {"Agar.io", "A"},
            {"Vlog", "V"},
            {"趣遊", "F"},
            {"小遊戲時間", "G"},
            {"VVVVVV", "VV"},
            {"", ""}
        }


    End Function
    Structure OtherValueInfo
        Implements SqlTypes.INullable
        Private ReadOnly _IsNull As Boolean
        ReadOnly Property IsNull As Boolean Implements SqlTypes.INullable.IsNull
            Get
                Return _IsNull
            End Get
        End Property
        Public ReadOnly Key As String
        Public ReadOnly Value As String
        Public ReadOnly IndexPos As Integer
        Sub New(Key_ As String, Value_ As String, IndexPos_ As Integer)
            If Key_ = Nothing Or Value_ Is Nothing OrElse IndexPos_.Equals(Nothing) Then _IsNull = True
            Key = Key_
            Value = Value_
            IndexPos = IndexPos_
        End Sub
    End Structure
    Public Function GetOther(Codes As Dictionary(Of String, String), ByVal Key As String) As OtherValueInfo
        If (Codes.ContainsKey(Key)) Then
            Dim v As New KeyValuePair(Of String, String)
            v = Codes.First(Function(S) S.Key.Equals(Key))
            Return New OtherValueInfo(Key, Codes(Key), Codes.ToList().IndexOf(v))
        Else
            Return New OtherValueInfo(Nothing, Nothing, Nothing)
        End If
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

    Private Sub Copy_Click(sender As Object, e As EventArgs) Handles Copy.Click
        My.Computer.Clipboard.SetText(Output.Text)
    End Sub

    Private Sub LoadFiles_Click(sender As Object, e As EventArgs) Handles LoadFiles.Click
        Dim DirInfo As IO.DirectoryInfo = FileIO.FileSystem.GetDirectoryInfo(InputBox("Enter source directory:", "Source", "Y:\"))
        Dim Files As New List(Of String)
        For Each File As IO.FileInfo In DirInfo.GetFiles("*.avi", IO.SearchOption.TopDirectoryOnly)
            Files.Add(File.FullName)
        Next
        For Each File As IO.FileInfo In DirInfo.GetFiles("*.mp4", IO.SearchOption.TopDirectoryOnly)
            Files.Add(File.FullName)
        Next
        For Each File As String In Files
            If List.Items.Contains(File) Then Continue For
            List.Items.Add(File)
            Names.Add("")
        Next
        Dim Temp1 As String() = List.Items.Cast(Of String).ToArray
        Dim Temp2 As String() = Names.ToArray
        Array.Sort(Temp1, Temp2)
        List.Items.Clear()
        List.Items.AddRange(Temp1)
        Names.Clear()
        Names.AddRange(Temp2)
    End Sub

    Private Sub Output_TextChanged(sender As Object, e As EventArgs)
        Names(List.SelectedIndex) = Output.Text
    End Sub

    Private Sub List_SelectedIndexChanged(sender As Object, e As EventArgs)
        Parse(Names(List.SelectedIndex))
    End Sub

    Friend Sub Parse(Input As String)
        If Input = "" Then Parse("├Minecraft遊記:┤1a： ")
        If Input(0) <> Prefix.Text Then ThrowFormatException("First character is not prefix.")
        Dim Serie As String = Input.Substring(1).TakeWhile(Function(c As Char) c <> Midfix.Text).ToArray
        If Serie.Contains(SeriesColon.Text) Then
            Dim Subserie As String = Serie.SkipWhile(Function(c As Char) c <> SeriesColon.Text).ToArray
            Serie = Serie.TakeWhile(Function(c As Char) c <> SeriesColon.Text).ToArray
            SubSeries.Text = Subserie
        End If
        Series.Text = Serie
        Input = Input.Substring(Input.IndexOf(Midfix.Text) + 1)
        If Input.StartsWith("Beta ") Then
            Beta.Checked = True
            Input = Input.Substring(5)
        End If
        Dim SerieNumber As String = Input.Substring(1).TakeWhile(Function(c As Char) c <> Colon.Text).ToArray
        Dim Match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(Serie, "(?<=\d+)([a-z]|[A-Z]|_\d\d?)(?=：)")
        If Match.Success Then
            If Match.Value.Length = 1 Then
                ExpectedCut.Checked = True
            ElseIf Match.Value.Length = 2 Or Match.Value.Length = 3 Then
                ExpectedCut.Checked = False
            Else
                ThrowFormatException("There are more than three characters as the number suffix.")
            End If
            NumberSuffix.Text = Match.Value
        Else
            NumberSuffix.Text = String.Empty
        End If
        Match = System.Text.RegularExpressions.Regex.Match(Input, "(?<=\s)(\[([a-z]|[A-Z]|[0-9]|-|\(|\))+\])+$")
        If Match.Success Then
            For Each Suffix As String In Match.Value.Split({"["c, "]"c}, StringSplitOptions.RemoveEmptyEntries)
                Select Case Suffix
                    Case "D"
                        Duo.Checked = True
                    Case "T"
                        Triple.Checked = True
                    Case "M"
                        Multiple.Checked = True
                    Case "NN"
                        NoNarration.Checked = True
                    Case "E"
                        Extra.Checked = True
                    Case "X"
                        NotSuggested.Checked = True
                    Case "J"
                        JustRecord.Checked = True
                    Case Else
                        Match = System.Text.RegularExpressions.Regex.Match(Suffix,
                                    "^(C-[A-Z]+b?\d\d?|(\[([A-Z]|[0-9]|-|\(|\))+\])+|S-((SM|V|S)\d+(\(\d+\))?\,?)+|R\d\d?)$")
                        If Match.Success Then
                            Select Case Match.Value(0)
                                Case "C"c
                                    Continued.Checked = True

                                Case "S"c
                                Case "R"c
                            End Select
                        End If
                End Select
            Next
        End If
    End Sub

    Friend Function ThrowFormatException(Message As String) As Type
        Throw New FormatException(Message)
        Return GetType(Void)
    End Function

End Class
#If False Then
Namespace Global
    Namespace System
        Partial Structure [String]
            Shared Operator ^(Str1 As System.String, Str2 As System.String) As String
                Return Str1 & System.String.Delimiter.ToString & Str2
            End Operator
        End Structure
    End Namespace
End Namespace
#End If