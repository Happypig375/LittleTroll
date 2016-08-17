<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Viewer
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Menu = New System.Windows.Forms.MenuStrip()
        Me.MenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.Open = New System.Windows.Forms.OpenFileDialog()
        Me.Save = New System.Windows.Forms.SaveFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(284, 237)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Menu
        '
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(284, 24)
        Me.Menu.TabIndex = 1
        Me.Menu.Text = "MenuStrip1"
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNew, Me.FileOpen, Me.FileSave, Me.FileSaveAs, Me.FileReload})
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(37, 20)
        Me.MenuFile.Text = "&File"
        '
        'FileNew
        '
        Me.FileNew.Name = "FileNew"
        Me.FileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.FileNew.Size = New System.Drawing.Size(186, 22)
        Me.FileNew.Text = "&New"
        '
        'FileOpen
        '
        Me.FileOpen.Name = "FileOpen"
        Me.FileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpen.Size = New System.Drawing.Size(186, 22)
        Me.FileOpen.Text = "&Open"
        '
        'FileSave
        '
        Me.FileSave.Name = "FileSave"
        Me.FileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSave.Size = New System.Drawing.Size(186, 22)
        Me.FileSave.Text = "&Save"
        '
        'FileSaveAs
        '
        Me.FileSaveAs.Name = "FileSaveAs"
        Me.FileSaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSaveAs.Size = New System.Drawing.Size(186, 22)
        Me.FileSaveAs.Text = "Save &As"
        '
        'FileReload
        '
        Me.FileReload.Name = "FileReload"
        Me.FileReload.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.FileReload.Size = New System.Drawing.Size(186, 22)
        Me.FileReload.Text = "&Reload"
        '
        'Open
        '
        Me.Open.FileName = "OpenFileDialog1"
        '
        'Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Menu)
        Me.MainMenuStrip = Me.Menu
        Me.Name = "Viewer"
        Me.Text = "Pixelmap file viewer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Menu As MenuStrip
    Friend WithEvents MenuFile As ToolStripMenuItem
    Friend WithEvents FileNew As ToolStripMenuItem
    Friend WithEvents FileOpen As ToolStripMenuItem
    Friend WithEvents FileSave As ToolStripMenuItem
    Friend WithEvents FileSaveAs As ToolStripMenuItem
    Friend WithEvents FileReload As ToolStripMenuItem
    Friend WithEvents Open As OpenFileDialog
    Friend WithEvents Save As SaveFileDialog
End Class
