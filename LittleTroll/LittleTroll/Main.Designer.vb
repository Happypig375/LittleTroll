<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.MediaEmitter = New System.Windows.Forms.TabPage()
        Me.Type = New System.Windows.Forms.ComboBox()
        Me.Schedule = New System.Windows.Forms.ListView()
        Me.TimeColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TypeColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.AddSchedule = New System.Windows.Forms.Button()
        Me.UpdateSchedule = New System.Windows.Forms.Button()
        Me.RemoveSchedule = New System.Windows.Forms.Button()
        Me.Time = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Settings = New System.Windows.Forms.TabPage()
        Me.Tabs.SuspendLayout()
        Me.MediaEmitter.SuspendLayout()
        Me.ButtonLayout.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.MediaEmitter)
        Me.Tabs.Controls.Add(Me.Settings)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(331, 261)
        Me.Tabs.TabIndex = 0
        '
        'MediaEmitter
        '
        Me.MediaEmitter.Controls.Add(Me.Type)
        Me.MediaEmitter.Controls.Add(Me.Schedule)
        Me.MediaEmitter.Controls.Add(Me.ButtonLayout)
        Me.MediaEmitter.Controls.Add(Me.Time)
        Me.MediaEmitter.Controls.Add(Me.CheckBox1)
        Me.MediaEmitter.Location = New System.Drawing.Point(4, 22)
        Me.MediaEmitter.Name = "MediaEmitter"
        Me.MediaEmitter.Padding = New System.Windows.Forms.Padding(3)
        Me.MediaEmitter.Size = New System.Drawing.Size(323, 235)
        Me.MediaEmitter.TabIndex = 0
        Me.MediaEmitter.Text = "MediaEmitter"
        Me.MediaEmitter.UseVisualStyleBackColor = True
        '
        'Type
        '
        Me.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Type.FormattingEnabled = True
        Me.Type.Items.AddRange(New Object() {"Schoolbell", "Troll Song", "Trollface", "Troll Song + Trollface"})
        Me.Type.Location = New System.Drawing.Point(193, 6)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(121, 21)
        Me.Type.TabIndex = 7
        '
        'Schedule
        '
        Me.Schedule.AllowColumnReorder = True
        Me.Schedule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Schedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TimeColumn, Me.TypeColumn})
        Me.Schedule.FullRowSelect = True
        Me.Schedule.GridLines = True
        Me.Schedule.Location = New System.Drawing.Point(6, 93)
        Me.Schedule.MultiSelect = False
        Me.Schedule.Name = "Schedule"
        Me.Schedule.Size = New System.Drawing.Size(308, 136)
        Me.Schedule.TabIndex = 6
        Me.Schedule.UseCompatibleStateImageBehavior = False
        Me.Schedule.View = System.Windows.Forms.View.Details
        '
        'TimeColumn
        '
        Me.TimeColumn.Text = "Time"
        Me.TimeColumn.Width = 133
        '
        'TypeColumn
        '
        Me.TypeColumn.Text = "Type"
        Me.TypeColumn.Width = 170
        '
        'ButtonLayout
        '
        Me.ButtonLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonLayout.ColumnCount = 3
        Me.ButtonLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.89372!))
        Me.ButtonLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.10628!))
        Me.ButtonLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.ButtonLayout.Controls.Add(Me.AddSchedule, 0, 0)
        Me.ButtonLayout.Controls.Add(Me.UpdateSchedule, 2, 0)
        Me.ButtonLayout.Controls.Add(Me.RemoveSchedule, 1, 0)
        Me.ButtonLayout.Location = New System.Drawing.Point(8, 56)
        Me.ButtonLayout.Name = "ButtonLayout"
        Me.ButtonLayout.RowCount = 1
        Me.ButtonLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonLayout.Size = New System.Drawing.Size(309, 31)
        Me.ButtonLayout.TabIndex = 5
        '
        'AddSchedule
        '
        Me.AddSchedule.Location = New System.Drawing.Point(3, 3)
        Me.AddSchedule.Name = "AddSchedule"
        Me.AddSchedule.Size = New System.Drawing.Size(86, 23)
        Me.AddSchedule.TabIndex = 2
        Me.AddSchedule.Text = "Add Schedule"
        Me.AddSchedule.UseVisualStyleBackColor = True
        '
        'UpdateSchedule
        '
        Me.UpdateSchedule.Location = New System.Drawing.Point(204, 3)
        Me.UpdateSchedule.Name = "UpdateSchedule"
        Me.UpdateSchedule.Size = New System.Drawing.Size(100, 23)
        Me.UpdateSchedule.TabIndex = 4
        Me.UpdateSchedule.Text = "Update Schedule"
        Me.UpdateSchedule.UseVisualStyleBackColor = True
        '
        'RemoveSchedule
        '
        Me.RemoveSchedule.Location = New System.Drawing.Point(95, 3)
        Me.RemoveSchedule.Name = "RemoveSchedule"
        Me.RemoveSchedule.Size = New System.Drawing.Size(103, 23)
        Me.RemoveSchedule.TabIndex = 3
        Me.RemoveSchedule.Text = "Remove Schedule"
        Me.RemoveSchedule.UseVisualStyleBackColor = True
        '
        'Time
        '
        Me.Time.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Time.CustomFormat = "dd/MM/yyyy dddd HH:mm:ss"
        Me.Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Time.Location = New System.Drawing.Point(8, 30)
        Me.Time.Name = "Time"
        Me.Time.Size = New System.Drawing.Size(307, 20)
        Me.Time.TabIndex = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(8, 6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.Settings.Location = New System.Drawing.Point(4, 22)
        Me.Settings.Name = "Settings"
        Me.Settings.Padding = New System.Windows.Forms.Padding(3)
        Me.Settings.Size = New System.Drawing.Size(323, 235)
        Me.Settings.TabIndex = 1
        Me.Settings.Text = "Settings"
        Me.Settings.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 261)
        Me.Controls.Add(Me.Tabs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.ShowInTaskbar = False
        Me.Text = "LittleTroll"
        Me.Tabs.ResumeLayout(False)
        Me.MediaEmitter.ResumeLayout(False)
        Me.MediaEmitter.PerformLayout()
        Me.ButtonLayout.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents MediaEmitter As System.Windows.Forms.TabPage
    Friend WithEvents Settings As System.Windows.Forms.TabPage
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Time As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonLayout As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UpdateSchedule As System.Windows.Forms.Button
    Friend WithEvents RemoveSchedule As System.Windows.Forms.Button
    Friend WithEvents AddSchedule As System.Windows.Forms.Button
    Friend WithEvents Schedule As System.Windows.Forms.ListView
    Friend WithEvents TimeColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents Type As System.Windows.Forms.ComboBox
    Friend WithEvents TypeColumn As System.Windows.Forms.ColumnHeader

End Class
