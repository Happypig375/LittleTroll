Public Class Form
    Friend ReadOnly Settings As String = My.Computer.FileSystem.CurrentDirectory & "\375Namer.settings"
    Friend Const Delimiter As Char = ChrW(7)
    Friend Names As New List(Of String)
    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Using Writer As New IO.StreamWriter(Settings, False, System.Text.Encoding.Unicode) With {.NewLine = vbCrLf}
            For i = 0 To Names.Count - 1
                Writer.WriteLine(List.Items(i).ToString & Delimiter & Names(i))
            Next
            Writer.Flush()
            Writer.Close()
        End Using
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

    Private Sub Form_Load(sender As Object, e As FormClosedEventArgs)
        Dim Items As Dictionary(Of String, String) = LoadItems()
        AddFiles(Items.Keys, New List(Of String)(Items.Values))
    End Sub

    Private Function LoadItems() As Dictionary(Of String, String)
        LoadItems = New Dictionary(Of String, String)
        '<Runtime.InteropServices.Out> Content As IList(Of String)
        Using Reader As New FileIO.TextFieldParser(Settings) With {.Delimiters = {Delimiter}}
            Dim Files, Content As New List(Of String)
            While Not Reader.EndOfData
                Dim Fields As String() = Reader.ReadFields
                LoadItems.Add(Fields(0), Fields(1))
            End While
            Reader.Close()
        End Using
    End Function
    'FileIO.FileSystem.FindInFiles(Drive.Name, PartOfFile, IgnoreCase, FileIO.SearchOption.SearchAllSubDirectories)
    ''' <summary>
    ''' Gets all dirctories containing the file which its part is specified.
    ''' </summary>
    ''' <param name="PartOfTXT">The file specified. Do not contain the TXT extension.</param>
    ''' <returns>All dirctories containing the file which its part is specified.</returns>
    ''' <remarks>Comment if anything is wrong.</remarks>
    Function GetTXTDirectory(PartOfTXT As String) As String()
        Dim List As New List(Of String)
        For Each Drive As System.IO.DriveInfo In System.IO.DriveInfo.GetDrives
            List.AddRange(System.IO.Directory.GetFiles(Drive.Name, "*"c & PartOfTXT & "*.txt", IO.SearchOption.AllDirectories))
        Next
        Return List.ToArray
    End Function
    Friend Function SelectedRadioButton(Container As Control) As RadioButton
        For Each c As Control In Container.Controls
            If TypeOf c Is RadioButton AndAlso CType(c, RadioButton).Checked = True Then Return DirectCast(c, RadioButton)
        Next
        Return Nothing
    End Function
    Function GetThreadState(ProcId As Integer, ThreadId As Integer) As Threading.ThreadState
        For Each Thr As Threading.Thread In Process.GetProcessById(ProcId).Threads
            If Thr.ManagedThreadId = ThreadId Then Return Thr.ThreadState
        Next
        Throw New ArgumentOutOfRangeException("Thread not found.")
    End Function
    Public Class DuplicateKeyComparer(Of TKey As IconConverter)
        'Implements IComparer(Of TKey)
    End Class
    <Serializable>
    Public Structure Nullable(Of T As Structure)
    End Structure
    Public Interface ICompatiable
        Inherits IConvertible
        Function ToTimeSpan(ByVal provider As IFormatProvider) As TimeSpan
        Sub ToVoid(ByVal provider As IFormatProvider)
    End Interface
    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        CodesInit()
        Dim Dictionary As New Dictionary(Of String, String)
        Series.SelectedIndex = 0
        ContinuedFromSeries.SelectedIndex = 0
        Title.Text = Chr(0)
Retry:  Try
            Using Reader As New FileIO.TextFieldParser(Settings, System.Text.Encoding.Unicode) With
                {.Delimiters = {Delimiter.ToString}, .TrimWhiteSpace = True}
                Do Until Reader.EndOfData
                    Dim Line As String() = Nothing
                    Try
                        Line = Reader.ReadFields
                        If Line.Count <> 2 Then Throw New FileIO.MalformedLineException(
                            "There are more than one or no delimiters in the line.", Reader.LineNumber - 1)
                        Dictionary.Add(Line(0), Line(1))
                    Catch ex As FileIO.MalformedLineException
                        MsgBox(ex.Message & vbCrLf & "Line number: " & ex.LineNumber)
                    Catch ex As ArgumentException
                        MsgBox($"""{Line(0)}"" is duplicated: {ex.Message}")
                    End Try
                Loop
            End Using
            AddFiles(Dictionary.Keys, New List(Of String)(Dictionary.Values))
        Catch ex As IO.FileNotFoundException
            Try
                My.Computer.FileSystem.WriteAllText(Settings, "", False)
                GoTo Retry
            Catch exc As UnauthorizedAccessException
                MsgBox("Do not have enough permission. Cannot load/save settings.", MsgBoxStyle.Exclamation)
            End Try
        End Try
        If List.Items.Count = 0 Then
            List.Items.Add("<empty>")
            Names.Add("")
        End If
        List.SelectedIndex = 0
        AddHandler Output.TextChanged, AddressOf Output_TextChanged
        AddHandler List.SelectedIndexChanged, AddressOf List_SelectedIndexChanged
        List_SelectedIndexChanged(List, EventArgs.Empty)
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

    Private Sub SeriesNumberApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles SeriesNumberApproximately.CheckedChanged,
        Me.Load
        SeriesNumberApproximate.Enabled = SeriesNumberApproximately.Checked
    End Sub
    Private Sub VideoNumber_CheckedChanged(sender As Object, e As EventArgs) Handles VideoNumber.CheckedChanged, Me.Load
        VideoNumberApproximately.Enabled = VideoNumber.Checked
        VideoNumbers.Enabled = VideoNumber.Checked
    End Sub

    Private Sub VideoNumberApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles VideoNumberApproximately.CheckedChanged,
        Me.Load
        VideoNumberApproximate.Enabled = VideoNumberApproximately.Checked
    End Sub
    Private Sub SubscribeCount_CheckedChanged(sender As Object, e As EventArgs) Handles SubscribeCount.CheckedChanged, Me.Load
        SubscribeCountApproximately.Enabled = SubscribeCount.Checked
        SubscribeCounter.Enabled = SubscribeCount.Checked
    End Sub

    Private Sub SubscribeCountApproximately_CheckedChanged(sender As Object, e As EventArgs) Handles SubscribeCountApproximately.
        CheckedChanged, Me.Load
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
        Output.Text = Prefix.Text & Series.Text & If(String.IsNullOrEmpty(SubSeries.Text), String.Empty, SeriesColon.Text) &
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
            If(SubscribeCountApproximately.Checked, "("c & SubscribeCountApproximate.Value & ")"c, String.Empty), String.Empty) &
            "]"c, String.Empty) &
 _
            If(Continued.Checked, "[C-" & ConvertCode(ContinuedFromSeries.SelectedItem.ToString, Convert.ToCode) &
            If(ContinuedFromBeta.Checked, "b"c, String.Empty) & ContinuedFromNumber.Value & ContinuedFromSuffix.Text & "]"c, String.Empty) &
 _
            If(NoNarration.Checked, "[NN]", String.Empty) & If(Speedrun.Checked, "[R" & SpeedrunMultiplier.Value & "]"c, String.Empty) &
            If(Extra.Checked, "[E]", String.Empty) & If(NotSuggested.Checked, "[X]", String.Empty) &
            If(JustRecord.Checked, "[J]", String.Empty)
    End Sub

    <Flags> Friend Enum Convert As SByte
        ToCode = -1
        FromCode
    End Enum
    Friend Enum Serie As Byte
        Minecraft遊記
        Minecraft編輯遊記
        Minecraft_Factions_遊記
        Minecraft_Factions_2
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
    Dim Codes As New Dictionary(Of String, String) From {
            {"Minecraft遊記", "M"},
            {"Minecraft編輯遊記", "ME"},
            {"Minecraft Factions遊記", "MF"},
            {"Minecraft Factions 2", "MF2"},
            {"Minecraft Hide&Seek遊記", "MH"},
            {"Minecraft Universe遊記", "MU"},
            {"Minecraft版本遊記", "MV"},
            {"Minecraft玩人記", "MT"},
            {"Minecraft Skyblock遊記", "MB"},
            {"Minecraft生存", "MS"},
            {"Minecraft村莊生存", "MVS"},
            {"---", ""},
            {"LAN連線記", "L"},
            {"頻道更新", "U"},
            {"Agar.io", "A"},
            {"Vlog", "V"},
            {"趣遊", "F"},
            {"小遊戲時間", "G"},
            {"VVVVVV", "VV"},
            {"", ""}
        }
    Sub CodesInit()
        Series.Items.Clear()
        Series.Items.AddRange(Codes.Keys.Where(Function(s As String)
                                                   Return Not String.IsNullOrEmpty(s)
                                               End Function).ToArray)
    End Sub
    Friend Function ConvertCode(Input As String, Convert As Convert) As String
        For Each Pair As KeyValuePair(Of String, String) In Codes
            If Convert = Convert.ToCode Then
                If Pair.Key = Input Then Return Pair.Value
            Else
                If Pair.Value = Input Then Return Pair.Key
            End If
        Next
        Dim Ex As New KeyNotFoundException("Input is unconvertable.")
        Ex.Data.Add("Input", Input)
        Ex.Data.Add("Convert Mode", Convert)
        Throw Ex
    End Function
    Structure SurrogatePair
        Sub New(Chr As Char)
            IsSurrogatePair = False
            SingleChar = Chr
        End Sub
        Sub New(Str As String)
            Select Case Str.Length
                Case 0
                    IsSurrogatePair = False
                    SingleChar = Nothing
                Case 1
                    IsSurrogatePair = False
                    SingleChar = CChar(Str)
                Case 2
                    IsSurrogatePair = True
                    HighSurrogate = Str(0)
                    LowSurrogate = Str(1)
                Case Else
                    Throw New ArgumentOutOfRangeException("Str", "The string is too long.")
            End Select
        End Sub
        Private _HighSurrogate As Char
        Public Property HighSurrogate As Char
            Get
                Return _HighSurrogate
            End Get
            Set(value As Char)
                If AscW(value) < &HD800 OrElse AscW(value) >
                    &HDBFF Then Throw New ArgumentOutOfRangeException("Value is not a high surrogate.")
                _HighSurrogate = value
            End Set
        End Property
        Private _LowSurrogate As Char
        Public Property LowSurrogate As Char
            Get
                Return _LowSurrogate
            End Get
            Set(value As Char)
                If AscW(value) < &HDC00 OrElse AscW(value) > &HDFFF Then Throw New ArgumentOutOfRangeException("Value is not a low surrogate.")
                _LowSurrogate = value
            End Set
        End Property
        Public Property IsSurrogatePair As Boolean
        Public ReadOnly Property IsPrivateUsePlane As Boolean
            Get
                Return IsSurrogatePair AndAlso AscW(HighSurrogate) > &HDB80 AndAlso AscW(HighSurrogate) < &HDBFF
            End Get
        End Property
        Public Property SingleChar As Char
        Public Overrides Function ToString() As String
            Return If(IsSurrogatePair, HighSurrogate & LowSurrogate, SingleChar)
        End Function
        Public Function ToChar() As Char
            If IsSurrogatePair Then Throw New ArgumentOutOfRangeException("Pair", "Chars cannot handle surrogate pairs.")
            Return SingleChar
        End Function
        Public Function ToCharArray() As Char()
            If IsSurrogatePair Then Return {HighSurrogate, LowSurrogate}
            Return {SingleChar}
        End Function
        Public Function ToList() As List(Of Char)
            Return New List(Of Char)(ToCharArray)
        End Function
        Public Iterator Function ToIEnumerable() As IEnumerable(Of Char)
            If IsSurrogatePair Then
                Yield HighSurrogate
                Yield LowSurrogate
            Else Yield SingleChar
            End If
        End Function
        Public Iterator Function ToIEnumerator() As IEnumerator(Of Char)
            If IsSurrogatePair Then
                Yield HighSurrogate
                Yield LowSurrogate
            Else Yield SingleChar
            End If
        End Function
        Public Iterator Function ToNonGenericIEnumerable() As IEnumerable
            If IsSurrogatePair Then
                Yield HighSurrogate
                Yield LowSurrogate
            Else Yield SingleChar
            End If
        End Function
        Public Iterator Function ToNonGenericIEnumerator() As IEnumerator
            If IsSurrogatePair Then
                Yield HighSurrogate
                Yield LowSurrogate
            Else Yield SingleChar
            End If
        End Function
        Public Function Export(Of T As IEnumerable)() As T
            Return CType(ToIEnumerable(), T)
        End Function
        Public Function Asc() As UInteger
            Return CUInt(If(IsSurrogatePair, &H10000 + (AscW(HighSurrogate) - &HD800) * &H400 + (AscW(LowSurrogate) - &HDC00), AscW(SingleChar)))
        End Function
        Public Function GetNumericValue() As Double
            Throw New NotImplementedException
        End Function
        Sub New(CodePoint As UInteger)
            If CodePoint <= &HFFFF Then
                IsSurrogatePair = False
                SingleChar = ChrW(CInt(CodePoint))
            ElseIf CodePoint <= &H10FFFF Then
                IsSurrogatePair = True
                CodePoint -= &H10000UI
                LowSurrogate = ChrW(CInt(CodePoint Mod &H400 + &HDC00))
                HighSurrogate = ChrW(CInt(CodePoint \ &H400 + &HD800))
            Else Throw New ArgumentOutOfRangeException("CodePoint", "The code point is too big.")
            End If
        End Sub
        Public Shared Function Asc(Pair As SurrogatePair) As UInteger
            Return CUInt(If(Pair.IsSurrogatePair,
                &H10000 + (AscW(Pair.HighSurrogate) - &HD800) * &H400 + (AscW(Pair.LowSurrogate) - &HDC00), AscW(Pair.SingleChar)))
        End Function
        Public Shared Function Chr(CodePoint As UInteger) As SurrogatePair
            Return New SurrogatePair(CodePoint)
        End Function
        Public Overloads Shared Function Equals(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As Boolean
            Return Pair1 = Pair2
        End Function
        Public Overloads Function Equals(Pair As SurrogatePair) As Boolean
            Return Me = Pair
        End Function
        Shared Operator =(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As Boolean
            If Pair1.IsSurrogatePair <> Pair2.IsSurrogatePair Then Return False
            If Pair1.IsSurrogatePair Then
                If Pair1.HighSurrogate <> Pair2.HighSurrogate Then Return False
                If Pair1.LowSurrogate <> Pair2.LowSurrogate Then Return False
            Else
                If Pair1.SingleChar <> Pair2.SingleChar Then Return False
            End If
            Return True
        End Operator
        Public Overloads Shared Function NotEquals(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As Boolean
            Return Pair1 <> Pair2
        End Function
        Public Overloads Function NotEquals(Pair As SurrogatePair) As Boolean
            Return Me <> Pair
        End Function
        Shared Operator <>(Pair1 As SurrogatePair, Pair2 As SurrogatePair) As Boolean
            If Pair1.IsSurrogatePair = Pair2.IsSurrogatePair Then Return False
            If Pair1.IsSurrogatePair Then
                If Pair1.HighSurrogate = Pair2.HighSurrogate Then Return False
                If Pair1.LowSurrogate = Pair2.LowSurrogate Then Return False
            Else
                If Pair1.SingleChar = Pair2.SingleChar Then Return False
            End If
            Return True
        End Operator
        Shared Operator *(Pair As SurrogatePair, Multiplier As Integer) As String
            Return StrDup(Multiplier, Pair.ToString)
        End Operator
        Shared Operator +(Pair As SurrogatePair) As SurrogatePair
            Pair = New SurrogatePair(Pair.Asc + 1UI)
        End Operator
        Shared Operator -(Pair As SurrogatePair) As SurrogatePair
            Pair = New SurrogatePair(Pair.Asc - 1UI)
        End Operator
        Delegate Sub NoParamDelegate()
        Delegate Function AscDelegate(Pair As SurrogatePair) As UInteger
        Delegate Function ChrDelegate(CodePoint As UInteger) As SurrogatePair
        Shared Operator &(Chr As Char, Pair As SurrogatePair) As String
            Return Chr & Pair.ToString
        End Operator
        Shared Operator &(Pair As SurrogatePair, Chr As Char) As String
            Return Pair.ToString & Chr
        End Operator
        Shared Operator &(Str As String, Pair As SurrogatePair) As String
            Return Str & Pair.ToString
        End Operator
        Shared Operator &(Pair As SurrogatePair, Str As String) As String
            Return Pair.ToString & Str
        End Operator
        Shared Operator &(Obj As Object, Pair As SurrogatePair) As String
            Return Obj.ToString & Pair.ToString
        End Operator
        Shared Operator &(Pair As SurrogatePair, Obj As Object) As String
            Return Pair.ToString & Obj.ToString
        End Operator
        Shared Operator +(Chr As Char, Pair As SurrogatePair) As String
            Return Chr + Pair.ToString
        End Operator
        Shared Operator +(Pair As SurrogatePair, Chr As Char) As String
            Return Pair.ToString + Chr
        End Operator
        Shared Operator +(Str As String, Pair As SurrogatePair) As String
            Return Str + Pair.ToString
        End Operator
        Shared Operator +(Pair As SurrogatePair, Str As String) As String
            Return Pair.ToString + Str
        End Operator
        Shared Operator +(Obj As Object, Pair As SurrogatePair) As String
            Return Obj.ToString + Pair.ToString
        End Operator
        Shared Operator +(Pair As SurrogatePair, Obj As Object) As String
            Return Pair.ToString + Obj.ToString
        End Operator
        Shared Widening Operator CType(Pair As SurrogatePair) As String
            Return Pair.ToString
        End Operator
        Shared Narrowing Operator CType(Str As String) As SurrogatePair
            Return New SurrogatePair(Str)
        End Operator
        Shared Narrowing Operator CType(Pair As SurrogatePair) As Char
            If Pair.IsSurrogatePair Then Throw New ArgumentOutOfRangeException("Pair", "Chars cannot handle surrogate pairs.")
            Return Pair.SingleChar
        End Operator
        Shared Widening Operator CType(Chr As Char) As SurrogatePair
            Return New SurrogatePair(Chr)
        End Operator
        Shared Widening Operator CType(Pair As SurrogatePair) As Char()
            Return Pair.ToCharArray
        End Operator
        Shared Narrowing Operator CType(ChrArray As Char()) As SurrogatePair
            Return New SurrogatePair(New String(ChrArray))
        End Operator
        Shared Widening Operator CType(Pair As SurrogatePair) As List(Of Char)
            Return Pair.ToList
        End Operator
        Shared Narrowing Operator CType(ChrList As List(Of Char)) As SurrogatePair
            Return New SurrogatePair(New String(ChrList.ToArray))
        End Operator
    End Structure

    <Obsolete("Not implemented.", True)>
    Function ConvertToTraditional(SimplifiedChar As SurrogatePair) As SurrogatePair()
        ' Select Cases or another function?
        Throw New NotImplementedException
    End Function
    ''' <summary>
    ''' Makes this application auto-start when the current user logs in.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeMeStartOnLogin()
        My.Computer.FileSystem.CopyFile(IO.Path.Combine(
        My.Application.Info.DirectoryPath,
        My.Application.Info.AssemblyName & ".exe"),
        Environment.GetFolderPath(Environment.SpecialFolder.Startup))
    End Sub
    ''' <summary>
    ''' Makes this application auto-start when this computer boots up.
    ''' </summary>
    ''' <param name="Create">True if create registry; False if delete registry.</param>
    ''' <remarks>Requires Administrative permission.</remarks>
    Private Sub MakeMeStartOnBoot(Create As Boolean)
        Dim appstartup_path As String = IO.Path.GetDirectoryName(Application.StartupPath)
        Dim app_name As String = My.Application.Info.AssemblyName
        Dim regKey As Microsoft.Win32.RegistryKey =
            Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        If Create Then
            regKey.SetValue(app_name, appstartup_path)
        Else
            regKey.DeleteValue(app_name, False)
        End If
        regKey.Flush()
        regKey.Close()
    End Sub

    ''' <summary>
    ''' Uploads a file to  Microsoft OneDrive.
    ''' </summary>
    ''' <param name="FilePath">Path of a file to upload from.</param>
    ''' <exception cref="KeyNotFoundException">The registry key of MS OneDrive is not found.</exception>
    ''' <returns>The path of file inside MS OneDrive folder.</returns>
    ''' <remarks></remarks>
    Function UploadToMSOneDrive(FilePath As String) As String
        Const keyName As String = "HKEY_CURRENT_USER" & "\\" & "Software\Microsoft\Windows\CurrentVersion\SkyDrive"
        Const DefaultKey As String = "OMG Teh ReGiStRy DOesn''''t E.x;I's|T!!!"
        Dim OneDrivePath As String = DirectCast(Microsoft.Win32.Registry.GetValue(keyName, "UserFolder", DefaultKey), String)
        Dim MSOneDriveProgram As String = IO.Path.Combine(Environment.GetFolderPath(
                                                          Environment.SpecialFolder.LocalApplicationData), "Microsoft\OneDrive\OneDrive.exe")
        Dim Destination As String = IO.Path.Combine(If(OneDrivePath = DefaultKey, OneDrivePath, ThrowKeyNotFoundException(
                                    "Is MS OneDrive not installed?")), IO.Path.GetFileName(FilePath))
        My.Computer.FileSystem.CopyFile(FilePath, Destination)
        Process.Start(MSOneDriveProgram)
        Return Destination
    End Function
    Class SimulateWriting
        Protected WithEvents TextBox1 As TextBox
        Protected WithEvents ProcName As String
        Sub New(Text As String, Optional Interval As Double = 1000, Optional ProcName As String = "notepad")
            Timer.Interval = Interval
            TextBox1.Text = Text
            Me.ProcName = ProcName
        End Sub
        Sub New(ByRef TextBox As TextBox, Optional Interval As Double = 1000, Optional ProcName As String = "notepad")
            Timer.Interval = Interval
            TextBox1 = TextBox
            Me.ProcName = ProcName
        End Sub
        Overridable Sub SimulateWriting()
            InitalizeTimer(True, True, True)
            Process.Start(ProcName)
        End Sub
        Protected Sub InitalizeTimer(AutoReset As Boolean, Enabled As Boolean, Start As Boolean)
            With Timer
                .BeginInit()
                .AutoReset = AutoReset
                .Enabled = Enabled
                .InitializeLifetimeService()
                .EndInit()
                If Start Then .Start()
            End With
        End Sub
        Protected WithEvents Timer As New Timers.Timer(1000)
        Protected Sub Timer_Tick(sender As Object, e As System.Timers.ElapsedEventArgs) Handles Timer.Elapsed
            Static Counter As Integer = 0
            SendKeys.Send(TextBox1.Text(Counter))
            Counter += 1
            If Counter >= TextBox1.Text.Length Then
                Counter = 0
                Timer.Stop()
            End If
        End Sub
    End Class
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

    Private Sub ContinuedFromExpectedCut_CheckedChanged(sender As Object, e As EventArgs) Handles ContinuedFromExpectedCut.CheckedChanged,
        Me.Load
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
        Dim DirInfo As IO.DirectoryInfo
        Try
            DirInfo = FileIO.FileSystem.GetDirectoryInfo(InputBox("Enter source directory:", "Source", "Y:\"))
        Catch
            Exit Sub
        End Try
        Dim Files As New List(Of String)
        For Each File As IO.FileInfo In DirInfo.GetFiles("*.avi", IO.SearchOption.TopDirectoryOnly)
            Files.Add(File.Name)
        Next
        For Each File As IO.FileInfo In DirInfo.GetFiles("*.mp4", IO.SearchOption.TopDirectoryOnly)
            Files.Add(File.Name)
        Next
        AddFiles(Files)
    End Sub

    Friend Sub AddFiles(Files As IEnumerable(Of String), Optional Content As IList(Of String) = Nothing)
        For i As Integer = 0 To Files.Count - 1
            Dim File As String = Files(i)
            If List.Items.Contains(File) Then Continue For
            List.Items.Add(File)
            Names.Add(Content?.Item(i))
        Next
        Dim Selected As Object = List.SelectedItem
        Dim Temp1 As String() = List.Items.Cast(Of String).ToArray
        Dim Temp2 As String() = Names.ToArray
        Array.Sort(Temp1, Temp2)
        List.Items.Clear()
        List.Items.AddRange(Temp1)
        Names.Clear()
        Names.AddRange(Temp2)
        List.SelectedItem = Selected
    End Sub
    Private Sub Output_TextChanged(sender As Object, e As EventArgs)
        Names(List.SelectedIndex) = Output.Text
    End Sub

    Private Sub List_SelectedIndexChanged(sender As Object, e As EventArgs)
        Parse(Names(List.SelectedIndex))
        'My.MyApplication.Main({})
    End Sub

    Friend Sub Parse(Input As String)
        If String.IsNullOrEmpty(Input) Then Input = "├Minecraft遊記┤1："
        If Input(0) <> Prefix.Text Then ThrowFormatException("First character is not prefix.")
        Dim Serie As String = Input.Substring(1).TakeWhile(Function(Ch As Char) Ch <> Midfix.Text).ToArray
        If Serie.Contains(SeriesColon.Text) Then
            Dim Subserie As String = Serie.SkipWhile(Function(Ch As Char) Ch <> SeriesColon.Text).ToArray
            Serie = Serie.TakeWhile(Function(Ch As Char) Ch <> SeriesColon.Text).ToArray
            SubSeries.Text = Subserie.Substring(1)
        End If
        Series.Text = Serie
        Input = Input.Substring(Input.IndexOf(Midfix.Text) + 1)
        If Input.StartsWith("Beta ") Then
            Beta.Checked = True
            Input = Input.Substring(5)
        Else Beta.Checked = False
        End If
        Number.Value = CDec(Val(New String(Input.TakeWhile(Function(Ch As Char) Char.IsDigit(Ch)).ToArray)))
        Dim Match As System.Text.RegularExpressions.Match =
            System.Text.RegularExpressions.Regex.Match(Input, "(?<=\d+)([a-z]|[A-Z]|_\d{1,2)(?=：)")
        If Match.Success Then
            If Match.Value.Length = 1 Then
                ExpectedCut.Checked = True
            ElseIf Match.Value.Length = 2 Or Match.Value.Length = 3 Then
                ExpectedCut.Checked = False
            Else ThrowFormatException("There are more than three characters as the number suffix.")
            End If
            NumberSuffix.Text = Match.Value
        Else NumberSuffix.Text = String.Empty
        End If
        Title.Text = Input.Substring(Input.IndexOf(Colon.Text) + 1)
        Match = System.Text.RegularExpressions.Regex.Match(Input, "(?<=\s)(\[([a-z]|[A-Z]|[0-9]|-|_|,|\(|\))+\])+$")
        Dim Solol As Boolean = True
        Dim NN, E, X, J, C, SSM, SS, SV, R As Boolean
        If Match.Success Then
            Title.Text = Title.Text.Replace(Match.Value, String.Empty)
            Title.Text = Title.Text.TrimEnd
            For Each Suffix As String In Match.Value.Split({"["c, "]"c}, StringSplitOptions.RemoveEmptyEntries)
                Select Case Suffix
                    Case "D"
                        Solol = False
                        Duo.Checked = True
                    Case "T"
                        Solol = False
                        Triple.Checked = True
                    Case "M"
                        Solol = False
                        Multiple.Checked = True
                    Case "NN"
                        NN = True
                        NoNarration.Checked = True
                    Case "E"
                        E = True
                        Extra.Checked = True
                    Case "X"
                        X = True
                        NotSuggested.Checked = True
                    Case "J"
                        J = True
                        JustRecord.Checked = True
                    Case Else
                        Match = System.Text.RegularExpressions.Regex.Match(Suffix,
                                    "^(C-[A-Z]+b?\d{1,5}(_\d{1,2}|[a-z])|S-((SM|V|S)\d+(\(\d+\))?\,?)+|R\d\d?)$")
                        '(\[([A-Z]|[0-9]|-|\(|\))+\])+|
                        If Match.Success Then
                            Input = Match.Value
                            Select Case Input(0)
                                Case "C"c
                                    C = True
                                    Dim SeriesCode As New String(Input.Substring(2).TakeWhile(Function(Ch As Char) Char.IsUpper(Ch)).ToArray)
                                    Continued.Checked = True
                                    ContinuedFromSeries.Text = ConvertCode(SeriesCode, Convert.FromCode)
                                    Dim Last As String = Input.Substring(2).Replace(SeriesCode, String.Empty)
                                    If Last.First = "b"c Then ContinuedFromBeta.Checked = True
                                    ContinuedFromNumber.Value = CDec(Val(New String(If(Last.First = "b"c, Last.Substring(1), Last).
                                                                               TakeWhile(Function(Ch As Char) Char.IsDigit(Ch)).ToArray)))
                                    If Char.IsLetter(Last.Last) Then
                                        ContinuedFromExpectedCut.Checked = True
                                        ContinuedFromSuffix.Text = Last.Last
                                    ElseIf Last.Contains("_"c) AndAlso Char.IsDigit(Last.Last) Then
                                        ContinuedFromExpectedCut.Checked = False
                                        ContinuedFromSuffix.ResetText()
                                        For i As Integer = Last.Length - 1 To 0 Step -1
                                            If Char.IsDigit(Last(i)) OrElse Last(i) = "_"c Then ContinuedFromSuffix.Text &= Last(i)
                                            If Last(i) = "_"c Then Exit For
                                        Next i
                                        ContinuedFromSuffix.Text = ContinuedFromSuffix.Text.Reverse.ToArray
                                    End If
                                Case "S"c
                                    Special.Checked = True
                                    For Each Part As String In Input.Split(","c)
                                        If Part.StartsWith("S-") Then Part = Part.Substring(2)
                                        Select Case Part(0)
                                            Case "S"c
                                                If Part(1) = "M"c Then
                                                    SSM = True
                                                    SeriesNumber.Checked = True
                                                    Dim Index As Integer = Part.IndexOf("("c)
                                                    If Index <> -1 Then
                                                        SeriesNumberApproximately.Checked = True
                                                        SeriesNumberApproximate.Value =
                                                        CDec(Val(Part.Substring(Index + 1).TakeWhile(Function(Ch As Char) Ch <> ")"c).ToArray))
                                                    End If
                                                Else
                                                    SS = True
                                                    SubscribeCount.Checked = True
                                                    SubscribeCounter.Value =
                                                        CDec(Val(New String(Part.Substring(1).TakeWhile(
                                                        Function(Ch As Char) Char.IsDigit(Ch)).ToArray)))
                                                    Dim Index As Integer = Part.IndexOf("("c)
                                                    If Index <> -1 Then
                                                        SubscribeCountApproximately.Checked = True
                                                        SubscribeCountApproximate.Value = CDec(Val(New String(Part.Substring(Index + 1).
                                                            TakeWhile(Function(Ch As Char) Ch <> ")"c).ToArray).TrimEnd(")"c)))
                                                    End If
                                                End If
                                            Case "V"c
                                                SV = True
                                                VideoNumber.Checked = True
                                                VideoNumbers.Value =
                                                    CDec(Val(New String(Part.Substring(1).TakeWhile(
                                                    Function(Ch As Char) Char.IsDigit(Ch)).ToArray)))
                                                Dim Index As Integer = Part.IndexOf("("c)
                                                If Index <> -1 Then
                                                    VideoNumberApproximately.Checked = True
                                                    VideoNumberApproximate.Value = Decimal.Parse(Part.Substring(Index + 1).TrimEnd(")"c))
                                                End If
                                        End Select
                                    Next
                                Case "R"c
                                    R = True
                                    Speedrun.Checked = True
                                    SpeedrunMultiplier.Value = CDec(Input.Substring(1))
                            End Select
                        End If
                End Select
            Next
        End If
        Solo.Checked = Solol
        'NN, E, X, J, C, SSM, SS, SV
        If Not NN Then NoNarration.Checked = False
        If Not E Then Extra.Checked = False
        If Not X Then NotSuggested.Checked = False
        If Not J Then JustRecord.Checked = False
        If Not C Then Continued.Checked = False
        If Not (SSM Or SS Or SV) Then Special.Checked = False
        If Not SSM Then SeriesNumber.Checked = False
        If Not SS Then SubscribeCount.Checked = False
        If Not SV Then VideoNumber.Checked = False
        If Not R Then Speedrun.Checked = False
        Refresh()
    End Sub

    Public Overloads Overrides Sub Refresh()
        Refresh(Me, EventArgs.Empty)
    End Sub

    Friend Function ThrowFormatException(Message As String) As String
        Throw New FormatException(Message)
        Return GetType(Void).ToString
    End Function
    Friend Function ThrowKeyNotFoundException(Message As String) As String
        Throw New KeyNotFoundException(Message)
        Return GetType(Void).ToString
    End Function

    Private Sub LoadYoutube_Click(sender As Object, e As EventArgs) Handles LoadYoutube.Click
        YoutubeInput.Show()
    End Sub

    Private Sub QSearch_Click(sender As Object, e As EventArgs) Handles QSearch.Click
        Process.Start("https://www.youtube.com/my_videos?o=U&sq=" & Encode(List.SelectedItem.ToString))
    End Sub

    Friend Function Encode(Query As String) As String
        Return Uri.EscapeUriString(Query)
    End Function

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Process.Start("https://www.youtube.com/my_videos?o=U&sq=" & Encode(Output.Text))
    End Sub

    Private Sub AddItem_Click(sender As Object, e As EventArgs) Handles AddItem.Click
        Dim Name As String = InputBox("What is the video file name?", "Add Item")
        If Name = "" Then Return
        Dim Value As String = InputBox("What is the video name?", "Add Item")
        Try
            AddFiles({Name}, {Value})
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteItem_Click(sender As Object, e As EventArgs) Handles DeleteItem.Click
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Return
        Dim Selected As Object = List.SelectedItem
        Names.RemoveAt(List.SelectedIndex)
        List.SelectedIndex += 1
        List.Items.Remove(Selected)
    End Sub
End Class
#If False Then
Namespace Global
    Namespace System
        Partial Public Structure [String]
            Public Shared Delimiter As String
            Shared Operator ^(Str1 As String, Str2 As [String]) As String
                Return Str1 & System.String.Delimiter.ToString & Str2.ToString
            End Operator
        End Structure
    End Namespace
End Namespace
Namespace AntiKeylogger
    Class Program
        <Runtime.InteropServices.DllImport("user32.dll")> _
        Public Shared Function CreateDesktop(lpszDesktop As String, lpszDevice As IntPtr,
                                             pDevmode As IntPtr, dwFlags As Integer, dwDesiredAccess As UInteger, lpsa As IntPtr) As IntPtr
        End Function

        <Runtime.InteropServices.DllImport("user32.dll")> _
        Private Shared Function SwitchDesktop(hDesktop As IntPtr) As Boolean
        End Function

        <Runtime.InteropServices.DllImport("user32.dll")> _
        Public Shared Function CloseDesktop(handle As IntPtr) As Boolean
        End Function

        <Runtime.InteropServices.DllImport("user32.dll")> _
        Public Shared Function SetThreadDesktop(hDesktop As IntPtr) As Boolean
        End Function

        <Runtime.InteropServices.DllImport("user32.dll")> _
        Public Shared Function GetThreadDesktop(dwThreadId As Integer) As IntPtr
        End Function

        <Runtime.InteropServices.DllImport("kernel32.dll")> _
        Public Shared Function GetCurrentThreadId() As Integer
        End Function

        Private Enum DESKTOP_ACCESS As UInteger
            DESKTOP_NONE = 0
            DESKTOP_READOBJECTS = &H1
            DESKTOP_CREATEWINDOW = &H2
            DESKTOP_CREATEMENU = &H4
            DESKTOP_HOOKCONTROL = &H8
            DESKTOP_JOURNALRECORD = &H10
            DESKTOP_JOURNALPLAYBACK = &H20
            DESKTOP_ENUMERATE = &H40
            DESKTOP_WRITEOBJECTS = &H80
            DESKTOP_SWITCHDESKTOP = &H100

            GENERIC_ALL = (DESKTOP_READOBJECTS Or DESKTOP_CREATEWINDOW Or DESKTOP_CREATEMENU Or DESKTOP_HOOKCONTROL Or
                DESKTOP_JOURNALRECORD Or DESKTOP_JOURNALPLAYBACK Or DESKTOP_ENUMERATE Or DESKTOP_WRITEOBJECTS Or DESKTOP_SWITCHDESKTOP)
        End Enum

        Private Shared Sub Main(args As String())
            ' old desktop's handle, obtained by getting the current desktop assigned for this thread
            Dim hOldDesktop As IntPtr = GetThreadDesktop(GetCurrentThreadId())

            ' new desktop's handle, assigned automatically by CreateDesktop
            Dim hNewDesktop As IntPtr = CreateDesktop("RandomDesktopName", IntPtr.Zero, IntPtr.Zero, 
                                                      0, CUInt(DESKTOP_ACCESS.GENERIC_ALL), IntPtr.Zero)

            ' switching to the new desktop
            SwitchDesktop(hNewDesktop)

            ' Random login form: used for testing / not required
            Dim passwd As String = ""

            ' running on a different thread, this way SetThreadDesktop won't fail
            ' assigning the new desktop to this thread - 
            ' so the Form will be shown in the new desktop)




            System.Threading.Tasks.Task.Factory.StartNew(Function()
                                                             SetThreadDesktop(hNewDesktop)
                                                             Dim loginWnd As New Form()
                                                             Dim passwordTextBox As New TextBox()
                                                             passwordTextBox.Location = New Point(10, 30)
                                                             passwordTextBox.Width = 250
                                                             passwordTextBox.Font = New Font("Arial", 20, FontStyle.Regular)
                                                             loginWnd.Controls.Add(passwordTextBox)
                                                             loginWnd.FormClosing += Function(sender, e)
                                                                                         passwd = passwordTextBox.Text
                                                                                     End Function
                                                             Application.Run(loginWnd)

                                                         End Function).Wait()
            ' waits for the task to finish
            ' end of login form

            ' if got here, the form is closed => switch back to the old desktop
            SwitchDesktop(hOldDesktop)

            ' disposing the secure desktop since it's no longer needed
            CloseDesktop(hNewDesktop)

            Console.WriteLine(Convert.ToString("Password, typed inside secure desktop: ") & passwd)
            Console.ReadLine()
        End Sub
    End Class
End Namespace
#End If
