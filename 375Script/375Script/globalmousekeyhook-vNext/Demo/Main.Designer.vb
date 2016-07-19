
Namespace Demo
	Partial Class Main
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.checkBoxSuppressMouse = New System.Windows.Forms.CheckBox()
			Me.panelSeparator = New System.Windows.Forms.Panel()
			Me.radioGlobal = New System.Windows.Forms.RadioButton()
			Me.radioApplication = New System.Windows.Forms.RadioButton()
			Me.labelWheel = New System.Windows.Forms.Label()
			Me.labelMousePosition = New System.Windows.Forms.Label()
			Me.textBoxLog = New System.Windows.Forms.TextBox()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.clearLogButton = New System.Windows.Forms.Button()
			Me.checkBoxSupressMouseWheel = New System.Windows.Forms.CheckBox()
			Me.radioNone = New System.Windows.Forms.RadioButton()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' checkBoxSuppressMouse
			' 
			Me.checkBoxSuppressMouse.AutoSize = True
			Me.checkBoxSuppressMouse.Location = New System.Drawing.Point(211, 49)
			Me.checkBoxSuppressMouse.Name = "checkBoxSuppressMouse"
			Me.checkBoxSuppressMouse.Size = New System.Drawing.Size(159, 17)
			Me.checkBoxSuppressMouse.TabIndex = 13
			Me.checkBoxSuppressMouse.Text = "Suppress Right Mouse Click"
			Me.checkBoxSuppressMouse.UseVisualStyleBackColor = True
			Me.checkBoxSuppressMouse.CheckedChanged += New System.EventHandler(Me.checkBoxSuppressMouse_CheckedChanged)
			' 
			' panelSeparator
			' 
			Me.panelSeparator.Anchor = DirectCast(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.panelSeparator.BackColor = System.Drawing.Color.White
			Me.panelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.panelSeparator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.panelSeparator.Location = New System.Drawing.Point(6, 37)
			Me.panelSeparator.Name = "panelSeparator"
			Me.panelSeparator.Size = New System.Drawing.Size(584, 1)
			Me.panelSeparator.TabIndex = 11
			' 
			' radioGlobal
			' 
			Me.radioGlobal.AutoSize = True
			Me.radioGlobal.BackColor = System.Drawing.Color.White
			Me.radioGlobal.Checked = True
			Me.radioGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.radioGlobal.Location = New System.Drawing.Point(127, 13)
			Me.radioGlobal.Name = "radioGlobal"
			Me.radioGlobal.Size = New System.Drawing.Size(87, 17)
			Me.radioGlobal.TabIndex = 10
			Me.radioGlobal.TabStop = True
			Me.radioGlobal.Text = "Global hooks"
			Me.radioGlobal.UseVisualStyleBackColor = False
			Me.radioGlobal.CheckedChanged += New System.EventHandler(Me.radioGlobal_CheckedChanged)
			' 
			' radioApplication
			' 
			Me.radioApplication.AutoSize = True
			Me.radioApplication.BackColor = System.Drawing.Color.White
			Me.radioApplication.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.radioApplication.Location = New System.Drawing.Point(12, 13)
			Me.radioApplication.Name = "radioApplication"
			Me.radioApplication.Size = New System.Drawing.Size(109, 17)
			Me.radioApplication.TabIndex = 9
			Me.radioApplication.Text = "Application hooks"
			Me.radioApplication.UseVisualStyleBackColor = False
			Me.radioApplication.CheckedChanged += New System.EventHandler(Me.radioApplication_CheckedChanged)
			' 
			' labelWheel
			' 
			Me.labelWheel.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.labelWheel.AutoSize = True
			Me.labelWheel.BackColor = System.Drawing.Color.White
			Me.labelWheel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.labelWheel.Location = New System.Drawing.Point(9, 76)
			Me.labelWheel.Name = "labelWheel"
			Me.labelWheel.Size = New System.Drawing.Size(89, 13)
			Me.labelWheel.TabIndex = 6
			Me.labelWheel.Text = "Wheel={0:####}"
			' 
			' labelMousePosition
			' 
			Me.labelMousePosition.Anchor = DirectCast((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.labelMousePosition.AutoSize = True
			Me.labelMousePosition.BackColor = System.Drawing.Color.White
			Me.labelMousePosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.labelMousePosition.Location = New System.Drawing.Point(9, 50)
			Me.labelMousePosition.Name = "labelMousePosition"
			Me.labelMousePosition.Size = New System.Drawing.Size(125, 13)
			Me.labelMousePosition.TabIndex = 2
			Me.labelMousePosition.Text = "x={0:####}; y={1:####}"
			' 
			' textBoxLog
			' 
			Me.textBoxLog.BackColor = System.Drawing.Color.White
			Me.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
			Me.textBoxLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.textBoxLog.Location = New System.Drawing.Point(0, 106)
			Me.textBoxLog.Multiline = True
			Me.textBoxLog.Name = "textBoxLog"
			Me.textBoxLog.[ReadOnly] = True
			Me.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.textBoxLog.Size = New System.Drawing.Size(602, 233)
			Me.textBoxLog.TabIndex = 8
			Me.textBoxLog.WordWrap = False
			' 
			' groupBox2
			' 
			Me.groupBox2.BackColor = System.Drawing.Color.White
			Me.groupBox2.Controls.Add(Me.clearLogButton)
			Me.groupBox2.Controls.Add(Me.checkBoxSupressMouseWheel)
			Me.groupBox2.Controls.Add(Me.radioNone)
			Me.groupBox2.Controls.Add(Me.checkBoxSuppressMouse)
			Me.groupBox2.Controls.Add(Me.panelSeparator)
			Me.groupBox2.Controls.Add(Me.radioGlobal)
			Me.groupBox2.Controls.Add(Me.radioApplication)
			Me.groupBox2.Controls.Add(Me.labelWheel)
			Me.groupBox2.Controls.Add(Me.labelMousePosition)
			Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
			Me.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
			Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.groupBox2.Location = New System.Drawing.Point(0, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(602, 106)
			Me.groupBox2.TabIndex = 9
			Me.groupBox2.TabStop = False
			' 
			' clearLogButton
			' 
			Me.clearLogButton.Location = New System.Drawing.Point(515, 72)
			Me.clearLogButton.Name = "clearLogButton"
			Me.clearLogButton.Size = New System.Drawing.Size(75, 23)
			Me.clearLogButton.TabIndex = 16
			Me.clearLogButton.Text = "Clear Log"
			Me.clearLogButton.UseVisualStyleBackColor = True
			Me.clearLogButton.Click += New System.EventHandler(Me.clearLog_Click)
			' 
			' checkBoxSupressMouseWheel
			' 
			Me.checkBoxSupressMouseWheel.AutoSize = True
			Me.checkBoxSupressMouseWheel.Location = New System.Drawing.Point(211, 72)
			Me.checkBoxSupressMouseWheel.Name = "checkBoxSupressMouseWheel"
			Me.checkBoxSupressMouseWheel.Size = New System.Drawing.Size(139, 17)
			Me.checkBoxSupressMouseWheel.TabIndex = 15
			Me.checkBoxSupressMouseWheel.Text = "Suppress Mouse Wheel"
			Me.checkBoxSupressMouseWheel.UseVisualStyleBackColor = True
			Me.checkBoxSupressMouseWheel.CheckedChanged += New System.EventHandler(Me.checkBoxSupressMouseWheel_CheckedChanged)
			' 
			' radioNone
			' 
			Me.radioNone.AutoSize = True
			Me.radioNone.BackColor = System.Drawing.Color.White
			Me.radioNone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
			Me.radioNone.Location = New System.Drawing.Point(220, 13)
			Me.radioNone.Name = "radioNone"
			Me.radioNone.Size = New System.Drawing.Size(51, 17)
			Me.radioNone.TabIndex = 14
			Me.radioNone.Text = "None"
			Me.radioNone.UseVisualStyleBackColor = False
			Me.radioNone.CheckedChanged += New System.EventHandler(Me.radioNone_CheckedChanged)
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(602, 339)
			Me.Controls.Add(Me.textBoxLog)
			Me.Controls.Add(Me.groupBox2)
			Me.Name = "Main"
			Me.Text = "Mouse and Keyboard Hooks Demo"
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private checkBoxSuppressMouse As System.Windows.Forms.CheckBox
		Private panelSeparator As System.Windows.Forms.Panel
		Private radioGlobal As System.Windows.Forms.RadioButton
		Private radioApplication As System.Windows.Forms.RadioButton
		Private labelWheel As System.Windows.Forms.Label
		Private labelMousePosition As System.Windows.Forms.Label
		Private textBoxLog As System.Windows.Forms.TextBox
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private radioNone As System.Windows.Forms.RadioButton
		Private checkBoxSupressMouseWheel As System.Windows.Forms.CheckBox
		Private clearLogButton As System.Windows.Forms.Button
	End Class
End Namespace


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
