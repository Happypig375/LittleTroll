<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.List = New System.Windows.Forms.ListBox()
        Me.Sample = New System.Windows.Forms.Label()
        Me.Prefix = New System.Windows.Forms.Label()
        Me.Series = New System.Windows.Forms.ComboBox()
        Me.Midfix = New System.Windows.Forms.Label()
        Me.Number = New System.Windows.Forms.NumericUpDown()
        Me.NumberSuffix = New System.Windows.Forms.DomainUpDown()
        Me.ExpectedCut = New System.Windows.Forms.CheckBox()
        Me.SeriesColon = New System.Windows.Forms.Label()
        Me.SubSeries = New System.Windows.Forms.ComboBox()
        Me.Colon = New System.Windows.Forms.Label()
        Me.Title = New System.Windows.Forms.TextBox()
        Me.Solo = New System.Windows.Forms.RadioButton()
        Me.Duo = New System.Windows.Forms.RadioButton()
        Me.Triple = New System.Windows.Forms.RadioButton()
        Me.Special = New System.Windows.Forms.CheckBox()
        Me.Specials = New System.Windows.Forms.GroupBox()
        Me.SubscribeCounter = New System.Windows.Forms.NumericUpDown()
        Me.VideoNumbers = New System.Windows.Forms.NumericUpDown()
        Me.SubscribeCountApproximately = New System.Windows.Forms.CheckBox()
        Me.SubscribeCountApproximate = New System.Windows.Forms.NumericUpDown()
        Me.SubscribeCount = New System.Windows.Forms.CheckBox()
        Me.VideoNumberApproximately = New System.Windows.Forms.CheckBox()
        Me.VideoNumberApproximate = New System.Windows.Forms.NumericUpDown()
        Me.VideoNumber = New System.Windows.Forms.CheckBox()
        Me.SeriesNumberApproximately = New System.Windows.Forms.CheckBox()
        Me.SeriesNumberApproximate = New System.Windows.Forms.NumericUpDown()
        Me.SeriesNumber = New System.Windows.Forms.CheckBox()
        Me.Continued = New System.Windows.Forms.CheckBox()
        Me.ContinuedFrom = New System.Windows.Forms.GroupBox()
        Me.ContinuedFromExpectedCut = New System.Windows.Forms.CheckBox()
        Me.ContinuedFromBeta = New System.Windows.Forms.CheckBox()
        Me.ContinuedFromSubseries = New System.Windows.Forms.ComboBox()
        Me.ContinuedFromSeries = New System.Windows.Forms.ComboBox()
        Me.ContinuedFromColon = New System.Windows.Forms.Label()
        Me.ContinuedFromPrefix = New System.Windows.Forms.Label()
        Me.ContinuedFromMidfix = New System.Windows.Forms.Label()
        Me.ContinuedFromSuffix = New System.Windows.Forms.DomainUpDown()
        Me.ContinuedFromNumber = New System.Windows.Forms.NumericUpDown()
        Me.Multiple = New System.Windows.Forms.RadioButton()
        Me.NoNarration = New System.Windows.Forms.CheckBox()
        Me.Speedrun = New System.Windows.Forms.CheckBox()
        Me.SpeedrunMultiplier = New System.Windows.Forms.NumericUpDown()
        Me.Extra = New System.Windows.Forms.CheckBox()
        Me.NotSuggested = New System.Windows.Forms.CheckBox()
        Me.JustRecord = New System.Windows.Forms.CheckBox()
        Me.Output = New System.Windows.Forms.TextBox()
        Me.Copy = New System.Windows.Forms.Button()
        Me.Beta = New System.Windows.Forms.CheckBox()
        Me.LoadFiles = New System.Windows.Forms.Button()
        CType(Me.Number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Specials.SuspendLayout()
        CType(Me.SubscribeCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VideoNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubscribeCountApproximate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VideoNumberApproximate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeriesNumberApproximate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContinuedFrom.SuspendLayout()
        CType(Me.ContinuedFromNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpeedrunMultiplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'List
        '
        Me.List.FormattingEnabled = True
        Me.List.ItemHeight = 20
        Me.List.Location = New System.Drawing.Point(20, 40)
        Me.List.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.List.Name = "List"
        Me.List.Size = New System.Drawing.Size(398, 404)
        Me.List.TabIndex = 0
        '
        'Sample
        '
        Me.Sample.AutoSize = True
        Me.Sample.Location = New System.Drawing.Point(522, 23)
        Me.Sample.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Sample.Name = "Sample"
        Me.Sample.Size = New System.Drawing.Size(391, 20)
        Me.Sample.TabIndex = 1
        Me.Sample.Text = "Example: ├Minecraft遊記┤40：唔🆗的小波鐘塔之役Ⅶ [T]"
        '
        'Prefix
        '
        Me.Prefix.AutoSize = True
        Me.Prefix.Location = New System.Drawing.Point(429, 65)
        Me.Prefix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Prefix.Name = "Prefix"
        Me.Prefix.Size = New System.Drawing.Size(15, 20)
        Me.Prefix.TabIndex = 2
        Me.Prefix.Text = "├"
        '
        'Series
        '
        Me.Series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Series.FormattingEnabled = True
        Me.Series.Items.AddRange(New Object() {"Minecraft遊記", "Minecraft編輯遊記", "Minecraft Hide&Seek遊記", "Minecraft Universe遊記", "Minecraft版本遊記", "Minecraft玩人記", "Minecraft Skyblock遊記", "Minecraft生存", "Minecraft村莊生存", "LAN連線記", "---", "頻道更新", "Agar.io", " Vlog", "趣遊", "小遊戲時間", "VVVVVV"})
        Me.Series.Location = New System.Drawing.Point(458, 60)
        Me.Series.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Series.Name = "Series"
        Me.Series.Size = New System.Drawing.Size(180, 28)
        Me.Series.TabIndex = 3
        '
        'Midfix
        '
        Me.Midfix.AutoSize = True
        Me.Midfix.Location = New System.Drawing.Point(864, 63)
        Me.Midfix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Midfix.Name = "Midfix"
        Me.Midfix.Size = New System.Drawing.Size(15, 20)
        Me.Midfix.TabIndex = 4
        Me.Midfix.Text = "┤"
        '
        'Number
        '
        Me.Number.Location = New System.Drawing.Point(968, 62)
        Me.Number.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Number.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Number.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Number.Name = "Number"
        Me.Number.Size = New System.Drawing.Size(72, 26)
        Me.Number.TabIndex = 5
        Me.Number.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumberSuffix
        '
        Me.NumberSuffix.Items.Add("a")
        Me.NumberSuffix.Items.Add("b")
        Me.NumberSuffix.Items.Add("c")
        Me.NumberSuffix.Items.Add("d")
        Me.NumberSuffix.Items.Add("e")
        Me.NumberSuffix.Items.Add("f")
        Me.NumberSuffix.Items.Add("g")
        Me.NumberSuffix.Items.Add("h")
        Me.NumberSuffix.Items.Add("i")
        Me.NumberSuffix.Items.Add("j")
        Me.NumberSuffix.Items.Add("k")
        Me.NumberSuffix.Items.Add("l")
        Me.NumberSuffix.Items.Add("m")
        Me.NumberSuffix.Items.Add("n")
        Me.NumberSuffix.Items.Add("o")
        Me.NumberSuffix.Items.Add("p")
        Me.NumberSuffix.Items.Add("q")
        Me.NumberSuffix.Items.Add("r")
        Me.NumberSuffix.Items.Add("s")
        Me.NumberSuffix.Items.Add("t")
        Me.NumberSuffix.Items.Add("u")
        Me.NumberSuffix.Items.Add("v")
        Me.NumberSuffix.Items.Add("w")
        Me.NumberSuffix.Items.Add("x")
        Me.NumberSuffix.Items.Add("y")
        Me.NumberSuffix.Items.Add("z")
        Me.NumberSuffix.Location = New System.Drawing.Point(1048, 60)
        Me.NumberSuffix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NumberSuffix.Name = "NumberSuffix"
        Me.NumberSuffix.Size = New System.Drawing.Size(68, 26)
        Me.NumberSuffix.TabIndex = 6
        Me.NumberSuffix.Text = "a"
        '
        'ExpectedCut
        '
        Me.ExpectedCut.Appearance = System.Windows.Forms.Appearance.Button
        Me.ExpectedCut.AutoSize = True
        Me.ExpectedCut.Checked = True
        Me.ExpectedCut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ExpectedCut.Location = New System.Drawing.Point(962, 15)
        Me.ExpectedCut.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ExpectedCut.Name = "ExpectedCut"
        Me.ExpectedCut.Size = New System.Drawing.Size(115, 30)
        Me.ExpectedCut.TabIndex = 7
        Me.ExpectedCut.Text = "Expected Cut"
        Me.ExpectedCut.UseVisualStyleBackColor = True
        '
        'SeriesColon
        '
        Me.SeriesColon.AutoSize = True
        Me.SeriesColon.Location = New System.Drawing.Point(648, 62)
        Me.SeriesColon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SeriesColon.Name = "SeriesColon"
        Me.SeriesColon.Size = New System.Drawing.Size(13, 20)
        Me.SeriesColon.TabIndex = 9
        Me.SeriesColon.Text = ":"
        '
        'SubSeries
        '
        Me.SubSeries.FormattingEnabled = True
        Me.SubSeries.Location = New System.Drawing.Point(672, 60)
        Me.SubSeries.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SubSeries.Name = "SubSeries"
        Me.SubSeries.Size = New System.Drawing.Size(180, 28)
        Me.SubSeries.TabIndex = 10
        '
        'Colon
        '
        Me.Colon.AutoSize = True
        Me.Colon.Location = New System.Drawing.Point(1130, 65)
        Me.Colon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Colon.Name = "Colon"
        Me.Colon.Size = New System.Drawing.Size(17, 20)
        Me.Colon.TabIndex = 11
        Me.Colon.Text = "："
        '
        'Title
        '
        Me.Title.Location = New System.Drawing.Point(434, 102)
        Me.Title.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(624, 26)
        Me.Title.TabIndex = 12
        Me.Title.Text = "[S-SM50,V155(150)]"
        '
        'Solo
        '
        Me.Solo.Appearance = System.Windows.Forms.Appearance.Button
        Me.Solo.AutoSize = True
        Me.Solo.Checked = True
        Me.Solo.Location = New System.Drawing.Point(434, 143)
        Me.Solo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Solo.Name = "Solo"
        Me.Solo.Size = New System.Drawing.Size(51, 30)
        Me.Solo.TabIndex = 13
        Me.Solo.TabStop = True
        Me.Solo.Text = "Solo"
        Me.Solo.UseVisualStyleBackColor = True
        '
        'Duo
        '
        Me.Duo.Appearance = System.Windows.Forms.Appearance.Button
        Me.Duo.AutoSize = True
        Me.Duo.Location = New System.Drawing.Point(501, 143)
        Me.Duo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Duo.Name = "Duo"
        Me.Duo.Size = New System.Drawing.Size(49, 30)
        Me.Duo.TabIndex = 14
        Me.Duo.TabStop = True
        Me.Duo.Text = "Duo"
        Me.Duo.UseVisualStyleBackColor = True
        '
        'Triple
        '
        Me.Triple.Appearance = System.Windows.Forms.Appearance.Button
        Me.Triple.AutoSize = True
        Me.Triple.Location = New System.Drawing.Point(567, 143)
        Me.Triple.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Triple.Name = "Triple"
        Me.Triple.Size = New System.Drawing.Size(57, 30)
        Me.Triple.TabIndex = 15
        Me.Triple.TabStop = True
        Me.Triple.Text = "Triple"
        Me.Triple.UseVisualStyleBackColor = True
        '
        'Special
        '
        Me.Special.Appearance = System.Windows.Forms.Appearance.Button
        Me.Special.AutoSize = True
        Me.Special.Location = New System.Drawing.Point(729, 143)
        Me.Special.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Special.Name = "Special"
        Me.Special.Size = New System.Drawing.Size(71, 30)
        Me.Special.TabIndex = 16
        Me.Special.Text = "Special"
        Me.Special.UseVisualStyleBackColor = True
        '
        'Specials
        '
        Me.Specials.Controls.Add(Me.SubscribeCounter)
        Me.Specials.Controls.Add(Me.VideoNumbers)
        Me.Specials.Controls.Add(Me.SubscribeCountApproximately)
        Me.Specials.Controls.Add(Me.SubscribeCountApproximate)
        Me.Specials.Controls.Add(Me.SubscribeCount)
        Me.Specials.Controls.Add(Me.VideoNumberApproximately)
        Me.Specials.Controls.Add(Me.VideoNumberApproximate)
        Me.Specials.Controls.Add(Me.VideoNumber)
        Me.Specials.Controls.Add(Me.SeriesNumberApproximately)
        Me.Specials.Controls.Add(Me.SeriesNumberApproximate)
        Me.Specials.Controls.Add(Me.SeriesNumber)
        Me.Specials.Enabled = False
        Me.Specials.Location = New System.Drawing.Point(434, 188)
        Me.Specials.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Specials.Name = "Specials"
        Me.Specials.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Specials.Size = New System.Drawing.Size(356, 258)
        Me.Specials.TabIndex = 17
        Me.Specials.TabStop = False
        Me.Specials.Text = "Specials"
        '
        'SubscribeCounter
        '
        Me.SubscribeCounter.Enabled = False
        Me.SubscribeCounter.Location = New System.Drawing.Point(160, 172)
        Me.SubscribeCounter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SubscribeCounter.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.SubscribeCounter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SubscribeCounter.Name = "SubscribeCounter"
        Me.SubscribeCounter.Size = New System.Drawing.Size(76, 26)
        Me.SubscribeCounter.TabIndex = 10
        Me.SubscribeCounter.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'VideoNumbers
        '
        Me.VideoNumbers.Enabled = False
        Me.VideoNumbers.Location = New System.Drawing.Point(147, 80)
        Me.VideoNumbers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VideoNumbers.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.VideoNumbers.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.VideoNumbers.Name = "VideoNumbers"
        Me.VideoNumbers.Size = New System.Drawing.Size(76, 26)
        Me.VideoNumbers.TabIndex = 9
        Me.VideoNumbers.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SubscribeCountApproximately
        '
        Me.SubscribeCountApproximately.Appearance = System.Windows.Forms.Appearance.Button
        Me.SubscribeCountApproximately.AutoSize = True
        Me.SubscribeCountApproximately.Enabled = False
        Me.SubscribeCountApproximately.Location = New System.Drawing.Point(10, 212)
        Me.SubscribeCountApproximately.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SubscribeCountApproximately.Name = "SubscribeCountApproximately"
        Me.SubscribeCountApproximately.Size = New System.Drawing.Size(108, 30)
        Me.SubscribeCountApproximately.TabIndex = 8
        Me.SubscribeCountApproximately.Text = "Approximate"
        Me.SubscribeCountApproximately.UseVisualStyleBackColor = True
        '
        'SubscribeCountApproximate
        '
        Me.SubscribeCountApproximate.Enabled = False
        Me.SubscribeCountApproximate.Location = New System.Drawing.Point(132, 214)
        Me.SubscribeCountApproximate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SubscribeCountApproximate.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.SubscribeCountApproximate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SubscribeCountApproximate.Name = "SubscribeCountApproximate"
        Me.SubscribeCountApproximate.Size = New System.Drawing.Size(76, 26)
        Me.SubscribeCountApproximate.TabIndex = 7
        Me.SubscribeCountApproximate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SubscribeCount
        '
        Me.SubscribeCount.Appearance = System.Windows.Forms.Appearance.Button
        Me.SubscribeCount.AutoSize = True
        Me.SubscribeCount.Enabled = False
        Me.SubscribeCount.Location = New System.Drawing.Point(9, 168)
        Me.SubscribeCount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SubscribeCount.Name = "SubscribeCount"
        Me.SubscribeCount.Size = New System.Drawing.Size(137, 30)
        Me.SubscribeCount.TabIndex = 6
        Me.SubscribeCount.Text = "Subscribe Count"
        Me.SubscribeCount.UseVisualStyleBackColor = True
        '
        'VideoNumberApproximately
        '
        Me.VideoNumberApproximately.Appearance = System.Windows.Forms.Appearance.Button
        Me.VideoNumberApproximately.AutoSize = True
        Me.VideoNumberApproximately.Enabled = False
        Me.VideoNumberApproximately.Location = New System.Drawing.Point(10, 120)
        Me.VideoNumberApproximately.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VideoNumberApproximately.Name = "VideoNumberApproximately"
        Me.VideoNumberApproximately.Size = New System.Drawing.Size(108, 30)
        Me.VideoNumberApproximately.TabIndex = 5
        Me.VideoNumberApproximately.Text = "Approximate"
        Me.VideoNumberApproximately.UseVisualStyleBackColor = True
        '
        'VideoNumberApproximate
        '
        Me.VideoNumberApproximate.Enabled = False
        Me.VideoNumberApproximate.Location = New System.Drawing.Point(147, 120)
        Me.VideoNumberApproximate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VideoNumberApproximate.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.VideoNumberApproximate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.VideoNumberApproximate.Name = "VideoNumberApproximate"
        Me.VideoNumberApproximate.Size = New System.Drawing.Size(76, 26)
        Me.VideoNumberApproximate.TabIndex = 4
        Me.VideoNumberApproximate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'VideoNumber
        '
        Me.VideoNumber.Appearance = System.Windows.Forms.Appearance.Button
        Me.VideoNumber.AutoSize = True
        Me.VideoNumber.Enabled = False
        Me.VideoNumber.Location = New System.Drawing.Point(10, 75)
        Me.VideoNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.VideoNumber.Name = "VideoNumber"
        Me.VideoNumber.Size = New System.Drawing.Size(120, 30)
        Me.VideoNumber.TabIndex = 3
        Me.VideoNumber.Text = "Video Number"
        Me.VideoNumber.UseVisualStyleBackColor = True
        '
        'SeriesNumberApproximately
        '
        Me.SeriesNumberApproximately.Appearance = System.Windows.Forms.Appearance.Button
        Me.SeriesNumberApproximately.AutoSize = True
        Me.SeriesNumberApproximately.Enabled = False
        Me.SeriesNumberApproximately.Location = New System.Drawing.Point(148, 29)
        Me.SeriesNumberApproximately.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SeriesNumberApproximately.Name = "SeriesNumberApproximately"
        Me.SeriesNumberApproximately.Size = New System.Drawing.Size(108, 30)
        Me.SeriesNumberApproximately.TabIndex = 2
        Me.SeriesNumberApproximately.Text = "Approximate"
        Me.SeriesNumberApproximately.UseVisualStyleBackColor = True
        '
        'SeriesNumberApproximate
        '
        Me.SeriesNumberApproximate.Enabled = False
        Me.SeriesNumberApproximate.Location = New System.Drawing.Point(270, 29)
        Me.SeriesNumberApproximate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SeriesNumberApproximate.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.SeriesNumberApproximate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SeriesNumberApproximate.Name = "SeriesNumberApproximate"
        Me.SeriesNumberApproximate.Size = New System.Drawing.Size(76, 26)
        Me.SeriesNumberApproximate.TabIndex = 1
        Me.SeriesNumberApproximate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SeriesNumber
        '
        Me.SeriesNumber.Appearance = System.Windows.Forms.Appearance.Button
        Me.SeriesNumber.AutoSize = True
        Me.SeriesNumber.Enabled = False
        Me.SeriesNumber.Location = New System.Drawing.Point(10, 31)
        Me.SeriesNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SeriesNumber.Name = "SeriesNumber"
        Me.SeriesNumber.Size = New System.Drawing.Size(124, 30)
        Me.SeriesNumber.TabIndex = 0
        Me.SeriesNumber.Tag = "Short: SM"
        Me.SeriesNumber.Text = "Series Number"
        Me.SeriesNumber.UseVisualStyleBackColor = True
        '
        'Continued
        '
        Me.Continued.Appearance = System.Windows.Forms.Appearance.Button
        Me.Continued.AutoSize = True
        Me.Continued.Location = New System.Drawing.Point(816, 143)
        Me.Continued.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Continued.Name = "Continued"
        Me.Continued.Size = New System.Drawing.Size(133, 30)
        Me.Continued.TabIndex = 18
        Me.Continued.Text = "Continued From"
        Me.Continued.UseVisualStyleBackColor = True
        '
        'ContinuedFrom
        '
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromExpectedCut)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromBeta)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromSubseries)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromSeries)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromColon)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromPrefix)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromMidfix)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromSuffix)
        Me.ContinuedFrom.Controls.Add(Me.ContinuedFromNumber)
        Me.ContinuedFrom.Location = New System.Drawing.Point(800, 188)
        Me.ContinuedFrom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFrom.Name = "ContinuedFrom"
        Me.ContinuedFrom.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFrom.Size = New System.Drawing.Size(267, 258)
        Me.ContinuedFrom.TabIndex = 19
        Me.ContinuedFrom.TabStop = False
        Me.ContinuedFrom.Text = "Continued From"
        '
        'ContinuedFromExpectedCut
        '
        Me.ContinuedFromExpectedCut.Appearance = System.Windows.Forms.Appearance.Button
        Me.ContinuedFromExpectedCut.AutoSize = True
        Me.ContinuedFromExpectedCut.Checked = True
        Me.ContinuedFromExpectedCut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ContinuedFromExpectedCut.Location = New System.Drawing.Point(9, 148)
        Me.ContinuedFromExpectedCut.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFromExpectedCut.Name = "ContinuedFromExpectedCut"
        Me.ContinuedFromExpectedCut.Size = New System.Drawing.Size(115, 30)
        Me.ContinuedFromExpectedCut.TabIndex = 30
        Me.ContinuedFromExpectedCut.Text = "Expected Cut"
        Me.ContinuedFromExpectedCut.UseVisualStyleBackColor = True
        '
        'ContinuedFromBeta
        '
        Me.ContinuedFromBeta.Appearance = System.Windows.Forms.Appearance.Button
        Me.ContinuedFromBeta.AutoSize = True
        Me.ContinuedFromBeta.Location = New System.Drawing.Point(9, 103)
        Me.ContinuedFromBeta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFromBeta.Name = "ContinuedFromBeta"
        Me.ContinuedFromBeta.Size = New System.Drawing.Size(53, 30)
        Me.ContinuedFromBeta.TabIndex = 30
        Me.ContinuedFromBeta.Text = "Beta"
        Me.ContinuedFromBeta.UseVisualStyleBackColor = True
        '
        'ContinuedFromSubseries
        '
        Me.ContinuedFromSubseries.FormattingEnabled = True
        Me.ContinuedFromSubseries.Location = New System.Drawing.Point(16, 66)
        Me.ContinuedFromSubseries.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFromSubseries.Name = "ContinuedFromSubseries"
        Me.ContinuedFromSubseries.Size = New System.Drawing.Size(180, 28)
        Me.ContinuedFromSubseries.TabIndex = 27
        '
        'ContinuedFromSeries
        '
        Me.ContinuedFromSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ContinuedFromSeries.FormattingEnabled = True
        Me.ContinuedFromSeries.Items.AddRange(New Object() {"Minecraft遊記", "Minecraft編輯遊記", "Minecraft Hide&Seek遊記", "Minecraft Universe遊記", "Minecraft版本遊記", "Minecraft玩人記", "Minecraft Skyblock遊記", "Minecraft生存", "Minecraft村莊生存", "LAN連線記", "---", "頻道更新", "Agar.io", " Vlog", "趣遊", "小遊戲時間", "VVVVVV"})
        Me.ContinuedFromSeries.Location = New System.Drawing.Point(48, 25)
        Me.ContinuedFromSeries.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFromSeries.Name = "ContinuedFromSeries"
        Me.ContinuedFromSeries.Size = New System.Drawing.Size(180, 28)
        Me.ContinuedFromSeries.TabIndex = 21
        '
        'ContinuedFromColon
        '
        Me.ContinuedFromColon.AutoSize = True
        Me.ContinuedFromColon.Location = New System.Drawing.Point(238, 29)
        Me.ContinuedFromColon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ContinuedFromColon.Name = "ContinuedFromColon"
        Me.ContinuedFromColon.Size = New System.Drawing.Size(13, 20)
        Me.ContinuedFromColon.TabIndex = 26
        Me.ContinuedFromColon.Text = ":"
        '
        'ContinuedFromPrefix
        '
        Me.ContinuedFromPrefix.AutoSize = True
        Me.ContinuedFromPrefix.Location = New System.Drawing.Point(20, 29)
        Me.ContinuedFromPrefix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ContinuedFromPrefix.Name = "ContinuedFromPrefix"
        Me.ContinuedFromPrefix.Size = New System.Drawing.Size(15, 20)
        Me.ContinuedFromPrefix.TabIndex = 20
        Me.ContinuedFromPrefix.Text = "├"
        '
        'ContinuedFromMidfix
        '
        Me.ContinuedFromMidfix.AutoSize = True
        Me.ContinuedFromMidfix.Location = New System.Drawing.Point(210, 71)
        Me.ContinuedFromMidfix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ContinuedFromMidfix.Name = "ContinuedFromMidfix"
        Me.ContinuedFromMidfix.Size = New System.Drawing.Size(15, 20)
        Me.ContinuedFromMidfix.TabIndex = 22
        Me.ContinuedFromMidfix.Text = "┤"
        '
        'ContinuedFromSuffix
        '
        Me.ContinuedFromSuffix.Items.Add("a")
        Me.ContinuedFromSuffix.Items.Add("b")
        Me.ContinuedFromSuffix.Items.Add("c")
        Me.ContinuedFromSuffix.Items.Add("d")
        Me.ContinuedFromSuffix.Items.Add("e")
        Me.ContinuedFromSuffix.Items.Add("f")
        Me.ContinuedFromSuffix.Items.Add("g")
        Me.ContinuedFromSuffix.Items.Add("h")
        Me.ContinuedFromSuffix.Items.Add("i")
        Me.ContinuedFromSuffix.Items.Add("j")
        Me.ContinuedFromSuffix.Items.Add("k")
        Me.ContinuedFromSuffix.Items.Add("l")
        Me.ContinuedFromSuffix.Items.Add("m")
        Me.ContinuedFromSuffix.Items.Add("n")
        Me.ContinuedFromSuffix.Items.Add("o")
        Me.ContinuedFromSuffix.Items.Add("p")
        Me.ContinuedFromSuffix.Items.Add("q")
        Me.ContinuedFromSuffix.Items.Add("r")
        Me.ContinuedFromSuffix.Items.Add("s")
        Me.ContinuedFromSuffix.Items.Add("t")
        Me.ContinuedFromSuffix.Items.Add("u")
        Me.ContinuedFromSuffix.Items.Add("v")
        Me.ContinuedFromSuffix.Items.Add("w")
        Me.ContinuedFromSuffix.Items.Add("x")
        Me.ContinuedFromSuffix.Items.Add("y")
        Me.ContinuedFromSuffix.Items.Add("z")
        Me.ContinuedFromSuffix.Location = New System.Drawing.Point(162, 108)
        Me.ContinuedFromSuffix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFromSuffix.Name = "ContinuedFromSuffix"
        Me.ContinuedFromSuffix.Size = New System.Drawing.Size(68, 26)
        Me.ContinuedFromSuffix.TabIndex = 24
        Me.ContinuedFromSuffix.Text = "a"
        '
        'ContinuedFromNumber
        '
        Me.ContinuedFromNumber.Location = New System.Drawing.Point(81, 108)
        Me.ContinuedFromNumber.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ContinuedFromNumber.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.ContinuedFromNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ContinuedFromNumber.Name = "ContinuedFromNumber"
        Me.ContinuedFromNumber.Size = New System.Drawing.Size(72, 26)
        Me.ContinuedFromNumber.TabIndex = 23
        Me.ContinuedFromNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Multiple
        '
        Me.Multiple.Appearance = System.Windows.Forms.Appearance.Button
        Me.Multiple.AutoSize = True
        Me.Multiple.Location = New System.Drawing.Point(640, 143)
        Me.Multiple.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Multiple.Name = "Multiple"
        Me.Multiple.Size = New System.Drawing.Size(73, 30)
        Me.Multiple.TabIndex = 20
        Me.Multiple.TabStop = True
        Me.Multiple.Text = "Multiple"
        Me.Multiple.UseVisualStyleBackColor = True
        '
        'NoNarration
        '
        Me.NoNarration.Appearance = System.Windows.Forms.Appearance.Button
        Me.NoNarration.AutoSize = True
        Me.NoNarration.Location = New System.Drawing.Point(962, 143)
        Me.NoNarration.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NoNarration.Name = "NoNarration"
        Me.NoNarration.Size = New System.Drawing.Size(108, 30)
        Me.NoNarration.TabIndex = 21
        Me.NoNarration.Text = "No Narration"
        Me.NoNarration.UseVisualStyleBackColor = True
        '
        'Speedrun
        '
        Me.Speedrun.Appearance = System.Windows.Forms.Appearance.Button
        Me.Speedrun.AutoSize = True
        Me.Speedrun.Location = New System.Drawing.Point(1068, 102)
        Me.Speedrun.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Speedrun.Name = "Speedrun"
        Me.Speedrun.Size = New System.Drawing.Size(89, 30)
        Me.Speedrun.TabIndex = 22
        Me.Speedrun.Text = "Speedrun"
        Me.Speedrun.UseVisualStyleBackColor = True
        '
        'SpeedrunMultiplier
        '
        Me.SpeedrunMultiplier.Location = New System.Drawing.Point(1173, 102)
        Me.SpeedrunMultiplier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SpeedrunMultiplier.Maximum = New Decimal(New Integer() {64, 0, 0, 0})
        Me.SpeedrunMultiplier.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SpeedrunMultiplier.Name = "SpeedrunMultiplier"
        Me.SpeedrunMultiplier.Size = New System.Drawing.Size(45, 26)
        Me.SpeedrunMultiplier.TabIndex = 23
        Me.SpeedrunMultiplier.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Extra
        '
        Me.Extra.Appearance = System.Windows.Forms.Appearance.Button
        Me.Extra.AutoSize = True
        Me.Extra.Location = New System.Drawing.Point(1088, 143)
        Me.Extra.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Extra.Name = "Extra"
        Me.Extra.Size = New System.Drawing.Size(56, 30)
        Me.Extra.TabIndex = 24
        Me.Extra.Text = "Extra"
        Me.Extra.UseVisualStyleBackColor = True
        '
        'NotSuggested
        '
        Me.NotSuggested.Appearance = System.Windows.Forms.Appearance.Button
        Me.NotSuggested.AutoSize = True
        Me.NotSuggested.Location = New System.Drawing.Point(1088, 188)
        Me.NotSuggested.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NotSuggested.Name = "NotSuggested"
        Me.NotSuggested.Size = New System.Drawing.Size(126, 30)
        Me.NotSuggested.TabIndex = 25
        Me.NotSuggested.Text = "Not Suggested"
        Me.NotSuggested.UseVisualStyleBackColor = True
        '
        'JustRecord
        '
        Me.JustRecord.Appearance = System.Windows.Forms.Appearance.Button
        Me.JustRecord.AutoSize = True
        Me.JustRecord.Location = New System.Drawing.Point(1088, 232)
        Me.JustRecord.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.JustRecord.Name = "JustRecord"
        Me.JustRecord.Size = New System.Drawing.Size(105, 30)
        Me.JustRecord.TabIndex = 26
        Me.JustRecord.Text = "Just Record"
        Me.JustRecord.UseVisualStyleBackColor = True
        '
        'Output
        '
        Me.Output.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Output.Location = New System.Drawing.Point(20, 452)
        Me.Output.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Output.Name = "Output"
        Me.Output.ReadOnly = True
        Me.Output.Size = New System.Drawing.Size(1118, 26)
        Me.Output.TabIndex = 27
        '
        'Copy
        '
        Me.Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Copy.AutoSize = True
        Me.Copy.Location = New System.Drawing.Point(1149, 452)
        Me.Copy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Copy.Name = "Copy"
        Me.Copy.Size = New System.Drawing.Size(70, 35)
        Me.Copy.TabIndex = 28
        Me.Copy.Text = "Copy"
        Me.Copy.UseVisualStyleBackColor = True
        '
        'Beta
        '
        Me.Beta.Appearance = System.Windows.Forms.Appearance.Button
        Me.Beta.AutoSize = True
        Me.Beta.Location = New System.Drawing.Point(892, 57)
        Me.Beta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Beta.Name = "Beta"
        Me.Beta.Size = New System.Drawing.Size(53, 30)
        Me.Beta.TabIndex = 29
        Me.Beta.Text = "Beta"
        Me.Beta.UseVisualStyleBackColor = True
        '
        'LoadFiles
        '
        Me.LoadFiles.AutoSize = True
        Me.LoadFiles.Location = New System.Drawing.Point(20, 5)
        Me.LoadFiles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoadFiles.Name = "LoadFiles"
        Me.LoadFiles.Size = New System.Drawing.Size(112, 35)
        Me.LoadFiles.TabIndex = 30
        Me.LoadFiles.Text = "Load Files"
        Me.LoadFiles.UseVisualStyleBackColor = True
        '
        'Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1238, 502)
        Me.Controls.Add(Me.LoadFiles)
        Me.Controls.Add(Me.Beta)
        Me.Controls.Add(Me.Copy)
        Me.Controls.Add(Me.Output)
        Me.Controls.Add(Me.JustRecord)
        Me.Controls.Add(Me.NotSuggested)
        Me.Controls.Add(Me.Extra)
        Me.Controls.Add(Me.SpeedrunMultiplier)
        Me.Controls.Add(Me.Speedrun)
        Me.Controls.Add(Me.NoNarration)
        Me.Controls.Add(Me.Multiple)
        Me.Controls.Add(Me.ContinuedFrom)
        Me.Controls.Add(Me.Continued)
        Me.Controls.Add(Me.Specials)
        Me.Controls.Add(Me.Special)
        Me.Controls.Add(Me.Triple)
        Me.Controls.Add(Me.Duo)
        Me.Controls.Add(Me.Solo)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.Colon)
        Me.Controls.Add(Me.SubSeries)
        Me.Controls.Add(Me.SeriesColon)
        Me.Controls.Add(Me.ExpectedCut)
        Me.Controls.Add(Me.NumberSuffix)
        Me.Controls.Add(Me.Number)
        Me.Controls.Add(Me.Midfix)
        Me.Controls.Add(Me.Series)
        Me.Controls.Add(Me.Prefix)
        Me.Controls.Add(Me.Sample)
        Me.Controls.Add(Me.List)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form"
        Me.Text = "375Namer"
        CType(Me.Number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Specials.ResumeLayout(False)
        Me.Specials.PerformLayout()
        CType(Me.SubscribeCounter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VideoNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubscribeCountApproximate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VideoNumberApproximate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeriesNumberApproximate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContinuedFrom.ResumeLayout(False)
        Me.ContinuedFrom.PerformLayout()
        CType(Me.ContinuedFromNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpeedrunMultiplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents List As System.Windows.Forms.ListBox
    Friend WithEvents Sample As System.Windows.Forms.Label
    Friend WithEvents Prefix As System.Windows.Forms.Label
    Friend WithEvents Series As System.Windows.Forms.ComboBox
    Friend WithEvents Midfix As System.Windows.Forms.Label
    Friend WithEvents Number As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumberSuffix As System.Windows.Forms.DomainUpDown
    Friend WithEvents ExpectedCut As System.Windows.Forms.CheckBox
    Friend WithEvents SeriesColon As System.Windows.Forms.Label
    Friend WithEvents SubSeries As System.Windows.Forms.ComboBox
    Friend WithEvents Colon As System.Windows.Forms.Label
    Friend WithEvents Title As System.Windows.Forms.TextBox
    Friend WithEvents Solo As System.Windows.Forms.RadioButton
    Friend WithEvents Duo As System.Windows.Forms.RadioButton
    Friend WithEvents Triple As System.Windows.Forms.RadioButton
    Friend WithEvents Special As System.Windows.Forms.CheckBox
    Friend WithEvents Specials As System.Windows.Forms.GroupBox
    Friend WithEvents SeriesNumber As System.Windows.Forms.CheckBox
    Friend WithEvents SeriesNumberApproximately As System.Windows.Forms.CheckBox
    Friend WithEvents SeriesNumberApproximate As System.Windows.Forms.NumericUpDown
    Friend WithEvents VideoNumberApproximately As System.Windows.Forms.CheckBox
    Friend WithEvents VideoNumberApproximate As System.Windows.Forms.NumericUpDown
    Friend WithEvents VideoNumber As System.Windows.Forms.CheckBox
    Friend WithEvents SubscribeCountApproximately As System.Windows.Forms.CheckBox
    Friend WithEvents SubscribeCountApproximate As System.Windows.Forms.NumericUpDown
    Friend WithEvents SubscribeCount As System.Windows.Forms.CheckBox
    Friend WithEvents Continued As System.Windows.Forms.CheckBox
    Friend WithEvents ContinuedFrom As System.Windows.Forms.GroupBox
    Friend WithEvents ContinuedFromSubseries As System.Windows.Forms.ComboBox
    Friend WithEvents ContinuedFromSeries As System.Windows.Forms.ComboBox
    Friend WithEvents ContinuedFromColon As System.Windows.Forms.Label
    Friend WithEvents ContinuedFromPrefix As System.Windows.Forms.Label
    Friend WithEvents ContinuedFromMidfix As System.Windows.Forms.Label
    Friend WithEvents ContinuedFromSuffix As System.Windows.Forms.DomainUpDown
    Friend WithEvents ContinuedFromNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents Multiple As System.Windows.Forms.RadioButton
    Friend WithEvents NoNarration As System.Windows.Forms.CheckBox
    Friend WithEvents Speedrun As System.Windows.Forms.CheckBox
    Friend WithEvents SpeedrunMultiplier As System.Windows.Forms.NumericUpDown
    Friend WithEvents Extra As System.Windows.Forms.CheckBox
    Friend WithEvents NotSuggested As System.Windows.Forms.CheckBox
    Friend WithEvents JustRecord As System.Windows.Forms.CheckBox
    Friend WithEvents Output As System.Windows.Forms.TextBox
    Friend WithEvents Copy As System.Windows.Forms.Button
    Friend WithEvents VideoNumbers As System.Windows.Forms.NumericUpDown
    Friend WithEvents SubscribeCounter As System.Windows.Forms.NumericUpDown
    Friend WithEvents Beta As System.Windows.Forms.CheckBox
    Friend WithEvents ContinuedFromBeta As System.Windows.Forms.CheckBox
    Friend WithEvents ContinuedFromExpectedCut As System.Windows.Forms.CheckBox
    Friend WithEvents LoadFiles As System.Windows.Forms.Button

End Class
