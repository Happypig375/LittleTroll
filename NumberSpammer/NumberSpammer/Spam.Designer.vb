<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Spam
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
        Me.Min = New System.Windows.Forms.NumericUpDown()
        Me.Max = New System.Windows.Forms.NumericUpDown()
        Me.From = New System.Windows.Forms.Label()
        Me.Tow = New System.Windows.Forms.Label()
        Me.Steps = New System.Windows.Forms.Label()
        Me.Freq = New System.Windows.Forms.NumericUpDown()
        Me.Between = New System.Windows.Forms.Label()
        Me.Betw = New System.Windows.Forms.TextBox()
        Me.Generate = New System.Windows.Forms.Button()
        Me.Out = New System.Windows.Forms.TextBox()
        Me.Length = New System.Windows.Forms.TextBox()
        CType(Me.Min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Max, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Freq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Min
        '
        Me.Min.Location = New System.Drawing.Point(49, 11)
        Me.Min.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.Min.Minimum = New Decimal(New Integer() {-1593835521, 466537709, 54210, -2147483648})
        Me.Min.Name = "Min"
        Me.Min.Size = New System.Drawing.Size(120, 20)
        Me.Min.TabIndex = 0
        '
        'Max
        '
        Me.Max.Location = New System.Drawing.Point(201, 11)
        Me.Max.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.Max.Minimum = New Decimal(New Integer() {-1593835521, 466537709, 54210, -2147483648})
        Me.Max.Name = "Max"
        Me.Max.Size = New System.Drawing.Size(120, 20)
        Me.Max.TabIndex = 1
        '
        'From
        '
        Me.From.AutoSize = True
        Me.From.Location = New System.Drawing.Point(13, 13)
        Me.From.Name = "From"
        Me.From.Size = New System.Drawing.Size(30, 13)
        Me.From.TabIndex = 2
        Me.From.Text = "From"
        '
        'Tow
        '
        Me.Tow.AutoSize = True
        Me.Tow.Location = New System.Drawing.Point(175, 13)
        Me.Tow.Name = "Tow"
        Me.Tow.Size = New System.Drawing.Size(20, 13)
        Me.Tow.TabIndex = 3
        Me.Tow.Text = "To"
        '
        'Steps
        '
        Me.Steps.AutoSize = True
        Me.Steps.Location = New System.Drawing.Point(327, 13)
        Me.Steps.Name = "Steps"
        Me.Steps.Size = New System.Drawing.Size(29, 13)
        Me.Steps.TabIndex = 4
        Me.Steps.Text = "Step"
        '
        'Freq
        '
        Me.Freq.Location = New System.Drawing.Point(362, 11)
        Me.Freq.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.Freq.Minimum = New Decimal(New Integer() {-1593835521, 466537709, 54210, -2147483648})
        Me.Freq.Name = "Freq"
        Me.Freq.Size = New System.Drawing.Size(120, 20)
        Me.Freq.TabIndex = 5
        Me.Freq.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Between
        '
        Me.Between.AutoSize = True
        Me.Between.Location = New System.Drawing.Point(488, 13)
        Me.Between.Name = "Between"
        Me.Between.Size = New System.Drawing.Size(94, 13)
        Me.Between.TabIndex = 6
        Me.Between.Text = "Between Numbers"
        '
        'Betw
        '
        Me.Betw.Location = New System.Drawing.Point(588, 10)
        Me.Betw.Name = "Betw"
        Me.Betw.Size = New System.Drawing.Size(100, 20)
        Me.Betw.TabIndex = 7
        '
        'Generate
        '
        Me.Generate.Location = New System.Drawing.Point(694, 8)
        Me.Generate.Name = "Generate"
        Me.Generate.Size = New System.Drawing.Size(75, 23)
        Me.Generate.TabIndex = 8
        Me.Generate.Text = "Generate!"
        Me.Generate.UseVisualStyleBackColor = True
        '
        'Out
        '
        Me.Out.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Out.Location = New System.Drawing.Point(-2, 37)
        Me.Out.Multiline = True
        Me.Out.Name = "Out"
        Me.Out.Size = New System.Drawing.Size(838, 281)
        Me.Out.TabIndex = 9
        '
        'Length
        '
        Me.Length.Location = New System.Drawing.Point(-2, 325)
        Me.Length.Name = "Length"
        Me.Length.ReadOnly = True
        Me.Length.Size = New System.Drawing.Size(823, 20)
        Me.Length.TabIndex = 10
        '
        'Spam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 347)
        Me.Controls.Add(Me.Length)
        Me.Controls.Add(Me.Out)
        Me.Controls.Add(Me.Generate)
        Me.Controls.Add(Me.Betw)
        Me.Controls.Add(Me.Between)
        Me.Controls.Add(Me.Freq)
        Me.Controls.Add(Me.Steps)
        Me.Controls.Add(Me.Tow)
        Me.Controls.Add(Me.From)
        Me.Controls.Add(Me.Max)
        Me.Controls.Add(Me.Min)
        Me.Name = "Spam"
        Me.Text = "NumberSpammer"
        CType(Me.Min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Max, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Freq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Min As NumericUpDown
    Friend WithEvents Max As NumericUpDown
    Friend WithEvents From As Label
    Friend WithEvents Tow As Label
    Friend WithEvents Steps As Label
    Friend WithEvents Freq As NumericUpDown
    Friend WithEvents Between As Label
    Friend WithEvents Betw As TextBox
    Friend WithEvents Generate As Button
    Friend WithEvents Out As TextBox
    Friend WithEvents Length As TextBox
End Class
