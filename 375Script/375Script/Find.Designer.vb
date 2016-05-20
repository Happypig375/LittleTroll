<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Find
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Find))
        Me.FindTextLabel = New System.Windows.Forms.Label()
        Me.FindText = New System.Windows.Forms.TextBox()
        Me.MatchCase = New System.Windows.Forms.CheckBox()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Highlight = New System.Windows.Forms.CheckBox()
        Me.StartAt = New System.Windows.Forms.TrackBar()
        Me.StartTop = New System.Windows.Forms.Label()
        Me.StartBottom = New System.Windows.Forms.Label()
        Me.WholeWord = New System.Windows.Forms.CheckBox()
        Me.ReplaceText = New System.Windows.Forms.TextBox()
        Me.ReplaceTextLabel = New System.Windows.Forms.Label()
        Me.Reset = New System.Windows.Forms.Button()
        Me.Description = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.StartAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FindTextLabel
        '
        Me.FindTextLabel.AutoSize = True
        Me.FindTextLabel.Location = New System.Drawing.Point(12, 16)
        Me.FindTextLabel.Name = "FindTextLabel"
        Me.FindTextLabel.Size = New System.Drawing.Size(50, 13)
        Me.FindTextLabel.TabIndex = 0
        Me.FindTextLabel.Text = "Find text:"
        '
        'FindText
        '
        Me.FindText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindText.Location = New System.Drawing.Point(70, 13)
        Me.FindText.Name = "FindText"
        Me.FindText.Size = New System.Drawing.Size(202, 20)
        Me.FindText.TabIndex = 1
        '
        'MatchCase
        '
        Me.MatchCase.AutoSize = True
        Me.MatchCase.Location = New System.Drawing.Point(15, 39)
        Me.MatchCase.Name = "MatchCase"
        Me.MatchCase.Size = New System.Drawing.Size(83, 17)
        Me.MatchCase.TabIndex = 2
        Me.MatchCase.Text = "Match Case"
        Me.MatchCase.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Find"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(126, 138)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Highlight
        '
        Me.Highlight.AutoSize = True
        Me.Highlight.Checked = True
        Me.Highlight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Highlight.Location = New System.Drawing.Point(105, 40)
        Me.Highlight.Name = "Highlight"
        Me.Highlight.Size = New System.Drawing.Size(67, 17)
        Me.Highlight.TabIndex = 4
        Me.Highlight.Text = "Highlight"
        Me.Highlight.UseVisualStyleBackColor = True
        '
        'StartAt
        '
        Me.StartAt.Location = New System.Drawing.Point(77, 63)
        Me.StartAt.Maximum = 1
        Me.StartAt.Name = "StartAt"
        Me.StartAt.Size = New System.Drawing.Size(53, 45)
        Me.StartAt.TabIndex = 5
        '
        'StartTop
        '
        Me.StartTop.AutoSize = True
        Me.StartTop.Location = New System.Drawing.Point(12, 72)
        Me.StartTop.Name = "StartTop"
        Me.StartTop.Size = New System.Drawing.Size(59, 13)
        Me.StartTop.TabIndex = 6
        Me.StartTop.Text = "Start at top"
        '
        'StartBottom
        '
        Me.StartBottom.AutoSize = True
        Me.StartBottom.Location = New System.Drawing.Point(137, 72)
        Me.StartBottom.Name = "StartBottom"
        Me.StartBottom.Size = New System.Drawing.Size(76, 13)
        Me.StartBottom.TabIndex = 7
        Me.StartBottom.Text = "Start at bottom"
        '
        'WholeWord
        '
        Me.WholeWord.AutoSize = True
        Me.WholeWord.Location = New System.Drawing.Point(178, 39)
        Me.WholeWord.Name = "WholeWord"
        Me.WholeWord.Size = New System.Drawing.Size(86, 17)
        Me.WholeWord.TabIndex = 8
        Me.WholeWord.Text = "Whole Word"
        Me.WholeWord.UseVisualStyleBackColor = True
        '
        'ReplaceText
        '
        Me.ReplaceText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReplaceText.Location = New System.Drawing.Point(70, 92)
        Me.ReplaceText.Name = "ReplaceText"
        Me.ReplaceText.Size = New System.Drawing.Size(202, 20)
        Me.ReplaceText.TabIndex = 10
        Me.ReplaceText.Visible = False
        '
        'ReplaceTextLabel
        '
        Me.ReplaceTextLabel.AutoSize = True
        Me.ReplaceTextLabel.Location = New System.Drawing.Point(1, 95)
        Me.ReplaceTextLabel.Name = "ReplaceTextLabel"
        Me.ReplaceTextLabel.Size = New System.Drawing.Size(70, 13)
        Me.ReplaceTextLabel.TabIndex = 9
        Me.ReplaceTextLabel.Text = "Replace text:"
        Me.ReplaceTextLabel.Visible = False
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(15, 144)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(83, 23)
        Me.Reset.TabIndex = 11
        Me.Reset.Text = "Reset Options"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'Description
        '
        Me.Description.AutoSize = True
        Me.Description.Location = New System.Drawing.Point(30, 122)
        Me.Description.Name = "Description"
        Me.Description.Size = New System.Drawing.Size(234, 13)
        Me.Description.TabIndex = 12
        Me.Description.Text = "Finds text in selection (if any) or the whole script."
        '
        'Find
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(284, 179)
        Me.Controls.Add(Me.Description)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.ReplaceText)
        Me.Controls.Add(Me.ReplaceTextLabel)
        Me.Controls.Add(Me.WholeWord)
        Me.Controls.Add(Me.StartBottom)
        Me.Controls.Add(Me.StartTop)
        Me.Controls.Add(Me.StartAt)
        Me.Controls.Add(Me.Highlight)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MatchCase)
        Me.Controls.Add(Me.FindText)
        Me.Controls.Add(Me.FindTextLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Find"
        Me.Text = "Find"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.StartAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FindTextLabel As System.Windows.Forms.Label
    Friend WithEvents FindText As System.Windows.Forms.TextBox
    Friend WithEvents MatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Highlight As System.Windows.Forms.CheckBox
    Friend WithEvents StartAt As System.Windows.Forms.TrackBar
    Friend WithEvents StartTop As System.Windows.Forms.Label
    Friend WithEvents StartBottom As System.Windows.Forms.Label
    Friend WithEvents WholeWord As System.Windows.Forms.CheckBox
    Friend WithEvents ReplaceText As System.Windows.Forms.TextBox
    Friend WithEvents ReplaceTextLabel As System.Windows.Forms.Label
    Friend WithEvents Reset As System.Windows.Forms.Button
    Friend WithEvents Description As System.Windows.Forms.Label
End Class
