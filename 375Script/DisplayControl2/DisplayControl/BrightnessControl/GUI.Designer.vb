<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GUI))
        Me.Brightness = New System.Windows.Forms.TrackBar()
        Me.BrightnessLabel = New System.Windows.Forms.Label()
        Me.ColorSel = New System.Windows.Forms.ColorDialog()
        Me.ColorButton = New System.Windows.Forms.Button()
        Me.ColorDisplay = New System.Windows.Forms.PictureBox()
        Me.ColorClr = New System.Windows.Forms.Button()
        Me.ColorRbw = New System.Windows.Forms.Button()
        Me.ColorRdm = New System.Windows.Forms.Button()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.OpacityLabel = New System.Windows.Forms.Label()
        Me.FilterOpacity = New System.Windows.Forms.TrackBar()
        Me.ImgButton = New System.Windows.Forms.Button()
        Me.ImgSel = New System.Windows.Forms.OpenFileDialog()
        Me.ImgStyle = New System.Windows.Forms.ComboBox()
        Me.ImgDisplay = New System.Windows.Forms.PictureBox()
        Me.HideCursor = New System.Windows.Forms.CheckBox()
        Me.ShowFilter = New System.Windows.Forms.Button()
        CType(Me.Brightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilterOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImgDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Brightness
        '
        Me.Brightness.LargeChange = 25
        Me.Brightness.Location = New System.Drawing.Point(37, 12)
        Me.Brightness.Maximum = 256
        Me.Brightness.Minimum = 1
        Me.Brightness.Name = "Brightness"
        Me.Brightness.Size = New System.Drawing.Size(554, 45)
        Me.Brightness.TabIndex = 0
        Me.Brightness.Value = 100
        '
        'BrightnessLabel
        '
        Me.BrightnessLabel.AutoSize = True
        Me.BrightnessLabel.Location = New System.Drawing.Point(12, 21)
        Me.BrightnessLabel.Name = "BrightnessLabel"
        Me.BrightnessLabel.Size = New System.Drawing.Size(25, 13)
        Me.BrightnessLabel.TabIndex = 1
        Me.BrightnessLabel.Text = "255"
        '
        'ColorButton
        '
        Me.ColorButton.Location = New System.Drawing.Point(43, 63)
        Me.ColorButton.Name = "ColorButton"
        Me.ColorButton.Size = New System.Drawing.Size(75, 23)
        Me.ColorButton.TabIndex = 2
        Me.ColorButton.Text = "Filter Colour"
        Me.ColorButton.UseVisualStyleBackColor = True
        '
        'ColorDisplay
        '
        Me.ColorDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ColorDisplay.Location = New System.Drawing.Point(13, 63)
        Me.ColorDisplay.Name = "ColorDisplay"
        Me.ColorDisplay.Size = New System.Drawing.Size(24, 24)
        Me.ColorDisplay.TabIndex = 3
        Me.ColorDisplay.TabStop = False
        '
        'ColorClr
        '
        Me.ColorClr.Location = New System.Drawing.Point(124, 63)
        Me.ColorClr.Name = "ColorClr"
        Me.ColorClr.Size = New System.Drawing.Size(75, 23)
        Me.ColorClr.TabIndex = 4
        Me.ColorClr.Text = "Clear Filter"
        Me.ColorClr.UseVisualStyleBackColor = True
        '
        'ColorRbw
        '
        Me.ColorRbw.Location = New System.Drawing.Point(205, 63)
        Me.ColorRbw.Name = "ColorRbw"
        Me.ColorRbw.Size = New System.Drawing.Size(89, 23)
        Me.ColorRbw.TabIndex = 5
        Me.ColorRbw.Text = "Rainbow Filter"
        Me.ColorRbw.UseVisualStyleBackColor = True
        '
        'ColorRdm
        '
        Me.ColorRdm.Location = New System.Drawing.Point(301, 64)
        Me.ColorRdm.Name = "ColorRdm"
        Me.ColorRdm.Size = New System.Drawing.Size(89, 23)
        Me.ColorRdm.TabIndex = 6
        Me.ColorRdm.Text = "Random Filter"
        Me.ColorRdm.UseVisualStyleBackColor = True
        '
        'InfoLabel
        '
        Me.InfoLabel.AutoSize = True
        Me.InfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.Location = New System.Drawing.Point(397, 67)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(194, 20)
        Me.InfoLabel.TabIndex = 7
        Me.InfoLabel.Text = "Brightness ⇅ Filter Opacity"
        '
        'OpacityLabel
        '
        Me.OpacityLabel.AutoSize = True
        Me.OpacityLabel.Location = New System.Drawing.Point(10, 110)
        Me.OpacityLabel.Name = "OpacityLabel"
        Me.OpacityLabel.Size = New System.Drawing.Size(33, 13)
        Me.OpacityLabel.TabIndex = 9
        Me.OpacityLabel.Text = "100%"
        '
        'FilterOpacity
        '
        Me.FilterOpacity.LargeChange = 25
        Me.FilterOpacity.Location = New System.Drawing.Point(37, 101)
        Me.FilterOpacity.Maximum = 100
        Me.FilterOpacity.Name = "FilterOpacity"
        Me.FilterOpacity.Size = New System.Drawing.Size(554, 45)
        Me.FilterOpacity.TabIndex = 8
        Me.FilterOpacity.Value = 40
        '
        'ImgButton
        '
        Me.ImgButton.Location = New System.Drawing.Point(43, 135)
        Me.ImgButton.Name = "ImgButton"
        Me.ImgButton.Size = New System.Drawing.Size(75, 23)
        Me.ImgButton.TabIndex = 10
        Me.ImgButton.Text = "Filter Image"
        Me.ImgButton.UseVisualStyleBackColor = True
        '
        'ImgSel
        '
        Me.ImgSel.Filter = resources.GetString("ImgSel.Filter")
        Me.ImgSel.FilterIndex = 6
        '
        'ImgStyle
        '
        Me.ImgStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ImgStyle.FormattingEnabled = True
        Me.ImgStyle.Location = New System.Drawing.Point(124, 137)
        Me.ImgStyle.Name = "ImgStyle"
        Me.ImgStyle.Size = New System.Drawing.Size(57, 21)
        Me.ImgStyle.TabIndex = 11
        '
        'ImgDisplay
        '
        Me.ImgDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ImgDisplay.Location = New System.Drawing.Point(13, 135)
        Me.ImgDisplay.Name = "ImgDisplay"
        Me.ImgDisplay.Size = New System.Drawing.Size(24, 24)
        Me.ImgDisplay.TabIndex = 12
        Me.ImgDisplay.TabStop = False
        '
        'HideCursor
        '
        Me.HideCursor.Appearance = System.Windows.Forms.Appearance.Button
        Me.HideCursor.AutoSize = True
        Me.HideCursor.Location = New System.Drawing.Point(188, 135)
        Me.HideCursor.Name = "HideCursor"
        Me.HideCursor.Size = New System.Drawing.Size(72, 23)
        Me.HideCursor.TabIndex = 13
        Me.HideCursor.Text = "Hide Cursor"
        Me.HideCursor.UseVisualStyleBackColor = True
        '
        'ShowFilter
        '
        Me.ShowFilter.Location = New System.Drawing.Point(266, 135)
        Me.ShowFilter.Name = "ShowFilter"
        Me.ShowFilter.Size = New System.Drawing.Size(75, 23)
        Me.ShowFilter.TabIndex = 14
        Me.ShowFilter.Text = "Show Filter"
        Me.ShowFilter.UseVisualStyleBackColor = True
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 171)
        Me.Controls.Add(Me.ShowFilter)
        Me.Controls.Add(Me.HideCursor)
        Me.Controls.Add(Me.ImgDisplay)
        Me.Controls.Add(Me.ImgStyle)
        Me.Controls.Add(Me.ImgButton)
        Me.Controls.Add(Me.OpacityLabel)
        Me.Controls.Add(Me.FilterOpacity)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.ColorRdm)
        Me.Controls.Add(Me.ColorRbw)
        Me.Controls.Add(Me.ColorClr)
        Me.Controls.Add(Me.ColorDisplay)
        Me.Controls.Add(Me.ColorButton)
        Me.Controls.Add(Me.BrightnessLabel)
        Me.Controls.Add(Me.Brightness)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "GUI"
        Me.Text = "DisplayControl"
        Me.TopMost = True
        CType(Me.Brightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilterOpacity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImgDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Brightness As System.Windows.Forms.TrackBar
    Friend WithEvents BrightnessLabel As System.Windows.Forms.Label
    Friend WithEvents ColorSel As System.Windows.Forms.ColorDialog
    Friend WithEvents ColorButton As System.Windows.Forms.Button
    Friend WithEvents ColorDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents ColorClr As System.Windows.Forms.Button
    Friend WithEvents ColorRbw As System.Windows.Forms.Button
    Friend WithEvents ColorRdm As System.Windows.Forms.Button
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents OpacityLabel As System.Windows.Forms.Label
    Friend WithEvents FilterOpacity As System.Windows.Forms.TrackBar
    Friend WithEvents ImgButton As System.Windows.Forms.Button
    Friend WithEvents ImgSel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImgStyle As System.Windows.Forms.ComboBox
    Friend WithEvents ImgDisplay As System.Windows.Forms.PictureBox
    Friend WithEvents HideCursor As System.Windows.Forms.CheckBox
    Friend WithEvents ShowFilter As System.Windows.Forms.Button

End Class
