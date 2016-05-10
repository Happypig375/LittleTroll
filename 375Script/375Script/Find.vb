Public Class Find
    Public Settings As FindSettings
    Public Class FindSettings
        Public Mode As FindMode
        Public FindText As String
        Public ReplaceText As String
        Public MatchCase As Boolean
        Public Highlight As Boolean
        Public WholeWord As Boolean
        Public StartBottom As Boolean
    End Class
    Public Enum FindMode As Byte
        Find = 0
        Replace
    End Enum
    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        MatchCase.Checked = False
        Highlight.Checked = True
        WholeWord.Checked = False
        StartAt.Value = 0
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        With Me.Settings
            .FindText = FindText.Text
            .ReplaceText = ReplaceText.Text
            .MatchCase = MatchCase.Checked
            .Highlight = Highlight.Checked
            .WholeWord = WholeWord.Checked
            .StartBottom = If(Me.StartAt.Value = 1, True, False)
        End With
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub New(Mode As FindMode)
        InitializeComponent()
        Select Case Mode
            Case FindMode.Find
                ReplaceText.Visible = False
                ReplaceTextLabel.Visible = False
                OK_Button.Text = "Find"
                Me.Settings.Mode = FindMode.Find
            Case FindMode.Replace
                ReplaceText.Visible = True
                ReplaceTextLabel.Visible = True
                OK_Button.Text = "Replace"
                Me.Settings.Mode = FindMode.Replace
        End Select
    End Sub
End Class