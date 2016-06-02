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
        Me.Beta = New System.Windows.Forms.Button()
        Me.SeriesColon = New System.Windows.Forms.Label()
        Me.SubSeries = New System.Windows.Forms.ComboBox()
        Me.Colon = New System.Windows.Forms.Label()
        Me.Title = New System.Windows.Forms.TextBox()
        Me.Solo = New System.Windows.Forms.RadioButton()
        Me.Duo = New System.Windows.Forms.RadioButton()
        Me.Triple = New System.Windows.Forms.RadioButton()
        Me.Special = New System.Windows.Forms.CheckBox()
        Me.Specials = New System.Windows.Forms.GroupBox()
        Me.SubscribeCountApproximately = New System.Windows.Forms.CheckBox()
        Me.SubscribeCountApproximate = New System.Windows.Forms.NumericUpDown()
        Me.SubscribeCount = New System.Windows.Forms.CheckBox()
        Me.VideoNumberApproximately = New System.Windows.Forms.CheckBox()
        Me.VideoNumberApproximate = New System.Windows.Forms.NumericUpDown()
        Me.VideoNumber = New System.Windows.Forms.CheckBox()
        Me.SeriesNumberApproximately = New System.Windows.Forms.CheckBox()
        Me.SeriesNumberApproximate = New System.Windows.Forms.NumericUpDown()
        Me.SeriesNumber = New System.Windows.Forms.CheckBox()
        Me.ContinuedFrom = New System.Windows.Forms.CheckBox()
        CType(Me.Number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Specials.SuspendLayout()
        CType(Me.SubscribeCountApproximate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VideoNumberApproximate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeriesNumberApproximate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'List
        '
        Me.List.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.List.FormattingEnabled = True
        Me.List.Location = New System.Drawing.Point(13, 13)
        Me.List.Name = "List"
        Me.List.Size = New System.Drawing.Size(92, 251)
        Me.List.TabIndex = 0
        '
        'Sample
        '
        Me.Sample.AutoSize = True
        Me.Sample.Location = New System.Drawing.Point(112, 13)
        Me.Sample.Name = "Sample"
        Me.Sample.Size = New System.Drawing.Size(240, 13)
        Me.Sample.TabIndex = 1
        Me.Sample.Text = "├Minecraft遊記┤40：唔🆗的小波鐘塔之役Ⅶ [T]"
        '
        'Prefix
        '
        Me.Prefix.AutoSize = True
        Me.Prefix.Location = New System.Drawing.Point(112, 30)
        Me.Prefix.Name = "Prefix"
        Me.Prefix.Size = New System.Drawing.Size(13, 13)
        Me.Prefix.TabIndex = 2
        Me.Prefix.Text = "├"
        '
        'Series
        '
        Me.Series.FormattingEnabled = True
        Me.Series.Items.AddRange(New Object() {"Minecraft遊記", "Minecraft編輯遊記", "Minecraft Hide&Seek遊記", "Minecraft Universe遊記", "Minecraft版本遊記", "Minecraft玩人記", "Minecraft Skyblock遊記", "Minecraft生存", "Minecraft村莊生存", "LAN連線記", "---", "頻道更新", "Agar.io", " Vlog", "趣遊", "小遊戲時間"})
        Me.Series.Location = New System.Drawing.Point(131, 30)
        Me.Series.Name = "Series"
        Me.Series.Size = New System.Drawing.Size(121, 21)
        Me.Series.TabIndex = 3
        '
        'Midfix
        '
        Me.Midfix.AutoSize = True
        Me.Midfix.Location = New System.Drawing.Point(402, 34)
        Me.Midfix.Name = "Midfix"
        Me.Midfix.Size = New System.Drawing.Size(13, 13)
        Me.Midfix.TabIndex = 4
        Me.Midfix.Text = "┤"
        '
        'Number
        '
        Me.Number.Location = New System.Drawing.Point(165, 57)
        Me.Number.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.Number.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Number.Name = "Number"
        Me.Number.Size = New System.Drawing.Size(48, 20)
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
        Me.NumberSuffix.Location = New System.Drawing.Point(219, 57)
        Me.NumberSuffix.Name = "NumberSuffix"
        Me.NumberSuffix.Size = New System.Drawing.Size(45, 20)
        Me.NumberSuffix.TabIndex = 6
        Me.NumberSuffix.Text = "a"
        '
        'ExpectedCut
        '
        Me.ExpectedCut.Appearance = System.Windows.Forms.Appearance.Button
        Me.ExpectedCut.AutoSize = True
        Me.ExpectedCut.Checked = True
        Me.ExpectedCut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ExpectedCut.Location = New System.Drawing.Point(358, 3)
        Me.ExpectedCut.Name = "ExpectedCut"
        Me.ExpectedCut.Size = New System.Drawing.Size(81, 23)
        Me.ExpectedCut.TabIndex = 7
        Me.ExpectedCut.Text = "Expected Cut"
        Me.ExpectedCut.UseVisualStyleBackColor = True
        '
        'Beta
        '
        Me.Beta.AutoSize = True
        Me.Beta.Location = New System.Drawing.Point(115, 57)
        Me.Beta.Name = "Beta"
        Me.Beta.Size = New System.Drawing.Size(44, 23)
        Me.Beta.TabIndex = 8
        Me.Beta.Text = "Beta"
        Me.Beta.UseVisualStyleBackColor = True
        '
        'SeriesColon
        '
        Me.SeriesColon.AutoSize = True
        Me.SeriesColon.Location = New System.Drawing.Point(258, 33)
        Me.SeriesColon.Name = "SeriesColon"
        Me.SeriesColon.Size = New System.Drawing.Size(10, 13)
        Me.SeriesColon.TabIndex = 9
        Me.SeriesColon.Text = ":"
        '
        'SubSeries
        '
        Me.SubSeries.FormattingEnabled = True
        Me.SubSeries.Location = New System.Drawing.Point(275, 29)
        Me.SubSeries.Name = "SubSeries"
        Me.SubSeries.Size = New System.Drawing.Size(121, 21)
        Me.SubSeries.TabIndex = 10
        '
        'Colon
        '
        Me.Colon.AutoSize = True
        Me.Colon.Location = New System.Drawing.Point(272, 62)
        Me.Colon.Name = "Colon"
        Me.Colon.Size = New System.Drawing.Size(13, 13)
        Me.Colon.TabIndex = 11
        Me.Colon.Text = "："
        '
        'Title
        '
        Me.Title.Location = New System.Drawing.Point(115, 83)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(323, 20)
        Me.Title.TabIndex = 12
        Me.Title.Text = "[S-SM50,V155(150)]"
        '
        'Solo
        '
        Me.Solo.Appearance = System.Windows.Forms.Appearance.Button
        Me.Solo.AutoSize = True
        Me.Solo.Checked = True
        Me.Solo.Location = New System.Drawing.Point(115, 110)
        Me.Solo.Name = "Solo"
        Me.Solo.Size = New System.Drawing.Size(38, 23)
        Me.Solo.TabIndex = 13
        Me.Solo.TabStop = True
        Me.Solo.Text = "Solo"
        Me.Solo.UseVisualStyleBackColor = True
        '
        'Duo
        '
        Me.Duo.Appearance = System.Windows.Forms.Appearance.Button
        Me.Duo.AutoSize = True
        Me.Duo.Location = New System.Drawing.Point(160, 110)
        Me.Duo.Name = "Duo"
        Me.Duo.Size = New System.Drawing.Size(37, 23)
        Me.Duo.TabIndex = 14
        Me.Duo.TabStop = True
        Me.Duo.Text = "Duo"
        Me.Duo.UseVisualStyleBackColor = True
        '
        'Triple
        '
        Me.Triple.Appearance = System.Windows.Forms.Appearance.Button
        Me.Triple.AutoSize = True
        Me.Triple.Location = New System.Drawing.Point(204, 110)
        Me.Triple.Name = "Triple"
        Me.Triple.Size = New System.Drawing.Size(43, 23)
        Me.Triple.TabIndex = 15
        Me.Triple.TabStop = True
        Me.Triple.Text = "Triple"
        Me.Triple.UseVisualStyleBackColor = True
        '
        'Special
        '
        Me.Special.Appearance = System.Windows.Forms.Appearance.Button
        Me.Special.AutoSize = True
        Me.Special.Location = New System.Drawing.Point(253, 109)
        Me.Special.Name = "Special"
        Me.Special.Size = New System.Drawing.Size(52, 23)
        Me.Special.TabIndex = 16
        Me.Special.Text = "Special"
        Me.Special.UseVisualStyleBackColor = True
        '
        'Specials
        '
        Me.Specials.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
        Me.Specials.Location = New System.Drawing.Point(115, 139)
        Me.Specials.Name = "Specials"
        Me.Specials.Size = New System.Drawing.Size(237, 120)
        Me.Specials.TabIndex = 17
        Me.Specials.TabStop = False
        Me.Specials.Text = "Specials"
        '
        'SubscribeCountApproximately
        '
        Me.SubscribeCountApproximately.Appearance = System.Windows.Forms.Appearance.Button
        Me.SubscribeCountApproximately.AutoSize = True
        Me.SubscribeCountApproximately.Enabled = False
        Me.SubscribeCountApproximately.Location = New System.Drawing.Point(99, 77)
        Me.SubscribeCountApproximately.Name = "SubscribeCountApproximately"
        Me.SubscribeCountApproximately.Size = New System.Drawing.Size(75, 23)
        Me.SubscribeCountApproximately.TabIndex = 8
        Me.SubscribeCountApproximately.Text = "Approximate"
        Me.SubscribeCountApproximately.UseVisualStyleBackColor = True
        '
        'SubscribeCountApproximate
        '
        Me.SubscribeCountApproximate.Enabled = False
        Me.SubscribeCountApproximate.Location = New System.Drawing.Point(180, 78)
        Me.SubscribeCountApproximate.Name = "SubscribeCountApproximate"
        Me.SubscribeCountApproximate.Size = New System.Drawing.Size(51, 20)
        Me.SubscribeCountApproximate.TabIndex = 7
        '
        'SubscribeCount
        '
        Me.SubscribeCount.Appearance = System.Windows.Forms.Appearance.Button
        Me.SubscribeCount.AutoSize = True
        Me.SubscribeCount.Enabled = False
        Me.SubscribeCount.Location = New System.Drawing.Point(7, 78)
        Me.SubscribeCount.Name = "SubscribeCount"
        Me.SubscribeCount.Size = New System.Drawing.Size(95, 23)
        Me.SubscribeCount.TabIndex = 6
        Me.SubscribeCount.Text = "Subscribe Count"
        Me.SubscribeCount.UseVisualStyleBackColor = True
        '
        'VideoNumberApproximately
        '
        Me.VideoNumberApproximately.Appearance = System.Windows.Forms.Appearance.Button
        Me.VideoNumberApproximately.AutoSize = True
        Me.VideoNumberApproximately.Enabled = False
        Me.VideoNumberApproximately.Location = New System.Drawing.Point(99, 48)
        Me.VideoNumberApproximately.Name = "VideoNumberApproximately"
        Me.VideoNumberApproximately.Size = New System.Drawing.Size(75, 23)
        Me.VideoNumberApproximately.TabIndex = 5
        Me.VideoNumberApproximately.Text = "Approximate"
        Me.VideoNumberApproximately.UseVisualStyleBackColor = True
        '
        'VideoNumberApproximate
        '
        Me.VideoNumberApproximate.Enabled = False
        Me.VideoNumberApproximate.Location = New System.Drawing.Point(180, 48)
        Me.VideoNumberApproximate.Name = "VideoNumberApproximate"
        Me.VideoNumberApproximate.Size = New System.Drawing.Size(51, 20)
        Me.VideoNumberApproximate.TabIndex = 4
        '
        'VideoNumber
        '
        Me.VideoNumber.Appearance = System.Windows.Forms.Appearance.Button
        Me.VideoNumber.AutoSize = True
        Me.VideoNumber.Enabled = False
        Me.VideoNumber.Location = New System.Drawing.Point(7, 49)
        Me.VideoNumber.Name = "VideoNumber"
        Me.VideoNumber.Size = New System.Drawing.Size(84, 23)
        Me.VideoNumber.TabIndex = 3
        Me.VideoNumber.Text = "Video Number"
        Me.VideoNumber.UseVisualStyleBackColor = True
        '
        'SeriesNumberApproximately
        '
        Me.SeriesNumberApproximately.Appearance = System.Windows.Forms.Appearance.Button
        Me.SeriesNumberApproximately.AutoSize = True
        Me.SeriesNumberApproximately.Enabled = False
        Me.SeriesNumberApproximately.Location = New System.Drawing.Point(99, 19)
        Me.SeriesNumberApproximately.Name = "SeriesNumberApproximately"
        Me.SeriesNumberApproximately.Size = New System.Drawing.Size(75, 23)
        Me.SeriesNumberApproximately.TabIndex = 2
        Me.SeriesNumberApproximately.Text = "Approximate"
        Me.SeriesNumberApproximately.UseVisualStyleBackColor = True
        '
        'SeriesNumberApproximate
        '
        Me.SeriesNumberApproximate.Enabled = False
        Me.SeriesNumberApproximate.Location = New System.Drawing.Point(180, 19)
        Me.SeriesNumberApproximate.Name = "SeriesNumberApproximate"
        Me.SeriesNumberApproximate.Size = New System.Drawing.Size(51, 20)
        Me.SeriesNumberApproximate.TabIndex = 1
        '
        'SeriesNumber
        '
        Me.SeriesNumber.Appearance = System.Windows.Forms.Appearance.Button
        Me.SeriesNumber.AutoSize = True
        Me.SeriesNumber.Enabled = False
        Me.SeriesNumber.Location = New System.Drawing.Point(7, 20)
        Me.SeriesNumber.Name = "SeriesNumber"
        Me.SeriesNumber.Size = New System.Drawing.Size(86, 23)
        Me.SeriesNumber.TabIndex = 0
        Me.SeriesNumber.Tag = "Short: SM"
        Me.SeriesNumber.Text = "Series Number"
        Me.SeriesNumber.UseVisualStyleBackColor = True
        '
        'ContinuedFrom
        '
        Me.ContinuedFrom.Appearance = System.Windows.Forms.Appearance.Button
        Me.ContinuedFrom.AutoSize = True
        Me.ContinuedFrom.Location = New System.Drawing.Point(312, 110)
        Me.ContinuedFrom.Name = "ContinuedFrom"
        Me.ContinuedFrom.Size = New System.Drawing.Size(91, 23)
        Me.ContinuedFrom.TabIndex = 18
        Me.ContinuedFrom.Text = "Continued From"
        Me.ContinuedFrom.UseVisualStyleBackColor = True
        '
        'Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 269)
        Me.Controls.Add(Me.ContinuedFrom)
        Me.Controls.Add(Me.Specials)
        Me.Controls.Add(Me.Special)
        Me.Controls.Add(Me.Triple)
        Me.Controls.Add(Me.Duo)
        Me.Controls.Add(Me.Solo)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.Colon)
        Me.Controls.Add(Me.SubSeries)
        Me.Controls.Add(Me.SeriesColon)
        Me.Controls.Add(Me.Beta)
        Me.Controls.Add(Me.ExpectedCut)
        Me.Controls.Add(Me.NumberSuffix)
        Me.Controls.Add(Me.Number)
        Me.Controls.Add(Me.Midfix)
        Me.Controls.Add(Me.Series)
        Me.Controls.Add(Me.Prefix)
        Me.Controls.Add(Me.Sample)
        Me.Controls.Add(Me.List)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form"
        Me.Text = "375Namer"
        CType(Me.Number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Specials.ResumeLayout(False)
        Me.Specials.PerformLayout()
        CType(Me.SubscribeCountApproximate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VideoNumberApproximate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeriesNumberApproximate, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Beta As System.Windows.Forms.Button
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
    Friend WithEvents ContinuedFrom As System.Windows.Forms.CheckBox

End Class
