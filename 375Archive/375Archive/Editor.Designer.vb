<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Editor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Menu = New System.Windows.Forms.MenuStrip()
        Me.MenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpenLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditGoTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertTimeDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertChar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFormat = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatWordWrap = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatFont = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatBackground = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewZoomIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewZoomOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewZoomReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewZoomSet = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpViewHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpAbout375Script = New System.Windows.Forms.ToolStripMenuItem()
        Me.Save = New System.Windows.Forms.SaveFileDialog()
        Me.Print = New System.Windows.Forms.PrintDialog()
        Me.PageSetup = New System.Windows.Forms.PageSetupDialog()
        Me.Open = New System.Windows.Forms.OpenFileDialog()
        Me.Edit = New System.Windows.Forms.RichTextBox()
        Me.Status = New System.Windows.Forms.StatusBar()
        Me.SetFont = New System.Windows.Forms.FontDialog()
        Me.Background = New System.Windows.Forms.ColorDialog()
        Me.LineNumbers = New _375Archive.LineNumbers_For_RichTextBox()
        Me.Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu
        '
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.MenuEdit, Me.MenuInsert, Me.MenuFormat, Me.MenuView, Me.MenuHelp})
        Me.Menu.Location = New System.Drawing.Point(0, 0)
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(356, 24)
        Me.Menu.TabIndex = 0
        Me.Menu.Text = "Menu"
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNew, Me.FileOpen, Me.FileOpenLink, Me.FileReload, Me.FileSave, Me.FileSaveAs, Me.FileSeparator1, Me.FileExit})
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(37, 20)
        Me.MenuFile.Text = "&File"
        '
        'FileNew
        '
        Me.FileNew.Name = "FileNew"
        Me.FileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.FileNew.Size = New System.Drawing.Size(212, 22)
        Me.FileNew.Text = "&New..."
        '
        'FileOpen
        '
        Me.FileOpen.Name = "FileOpen"
        Me.FileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpen.Size = New System.Drawing.Size(212, 22)
        Me.FileOpen.Text = "&Open..."
        '
        'FileOpenLink
        '
        Me.FileOpenLink.Name = "FileOpenLink"
        Me.FileOpenLink.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpenLink.Size = New System.Drawing.Size(212, 22)
        Me.FileOpenLink.Text = "Open &Link..."
        '
        'FileReload
        '
        Me.FileReload.Name = "FileReload"
        Me.FileReload.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F5), System.Windows.Forms.Keys)
        Me.FileReload.Size = New System.Drawing.Size(212, 22)
        Me.FileReload.Text = "&Reload"
        '
        'FileSave
        '
        Me.FileSave.Name = "FileSave"
        Me.FileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSave.Size = New System.Drawing.Size(212, 22)
        Me.FileSave.Text = "&Save"
        '
        'FileSaveAs
        '
        Me.FileSaveAs.Name = "FileSaveAs"
        Me.FileSaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSaveAs.Size = New System.Drawing.Size(212, 22)
        Me.FileSaveAs.Text = "Save &As..."
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Name = "FileSeparator1"
        Me.FileSeparator1.Size = New System.Drawing.Size(209, 6)
        '
        'FileExit
        '
        Me.FileExit.Name = "FileExit"
        Me.FileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.FileExit.Size = New System.Drawing.Size(212, 22)
        Me.FileExit.Text = "&Exit"
        '
        'MenuEdit
        '
        Me.MenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUndo, Me.EditSeparator1, Me.EditCut, Me.EditCopy, Me.EditPaste, Me.EditDelete, Me.EditSeparator2, Me.EditGoTo})
        Me.MenuEdit.Name = "MenuEdit"
        Me.MenuEdit.Size = New System.Drawing.Size(39, 20)
        Me.MenuEdit.Text = "&Edit"
        '
        'EditUndo
        '
        Me.EditUndo.Name = "EditUndo"
        Me.EditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.EditUndo.Size = New System.Drawing.Size(156, 22)
        Me.EditUndo.Text = "&Undo"
        '
        'EditSeparator1
        '
        Me.EditSeparator1.Name = "EditSeparator1"
        Me.EditSeparator1.Size = New System.Drawing.Size(153, 6)
        '
        'EditCut
        '
        Me.EditCut.Name = "EditCut"
        Me.EditCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.EditCut.Size = New System.Drawing.Size(156, 22)
        Me.EditCut.Text = "&Cut"
        '
        'EditCopy
        '
        Me.EditCopy.Name = "EditCopy"
        Me.EditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.EditCopy.Size = New System.Drawing.Size(156, 22)
        Me.EditCopy.Text = "C&opy"
        '
        'EditPaste
        '
        Me.EditPaste.Name = "EditPaste"
        Me.EditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.EditPaste.Size = New System.Drawing.Size(156, 22)
        Me.EditPaste.Text = "&Paste"
        '
        'EditDelete
        '
        Me.EditDelete.Name = "EditDelete"
        Me.EditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.EditDelete.Size = New System.Drawing.Size(156, 22)
        Me.EditDelete.Text = "&Delete"
        '
        'EditSeparator2
        '
        Me.EditSeparator2.Name = "EditSeparator2"
        Me.EditSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'EditGoTo
        '
        Me.EditGoTo.Name = "EditGoTo"
        Me.EditGoTo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.EditGoTo.Size = New System.Drawing.Size(156, 22)
        Me.EditGoTo.Text = "&Go To..."
        '
        'MenuInsert
        '
        Me.MenuInsert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertTimeDate, Me.InsertChar})
        Me.MenuInsert.Name = "MenuInsert"
        Me.MenuInsert.Size = New System.Drawing.Size(48, 20)
        Me.MenuInsert.Text = "&Insert"
        '
        'InsertTimeDate
        '
        Me.InsertTimeDate.Name = "InsertTimeDate"
        Me.InsertTimeDate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.InsertTimeDate.Size = New System.Drawing.Size(172, 22)
        Me.InsertTimeDate.Text = "&Time/Date"
        '
        'InsertChar
        '
        Me.InsertChar.Name = "InsertChar"
        Me.InsertChar.ShortcutKeys = System.Windows.Forms.Keys.Insert
        Me.InsertChar.Size = New System.Drawing.Size(172, 22)
        Me.InsertChar.Text = "&Character"
        '
        'MenuFormat
        '
        Me.MenuFormat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormatWordWrap, Me.FormatFont, Me.FormatBackground})
        Me.MenuFormat.Name = "MenuFormat"
        Me.MenuFormat.Size = New System.Drawing.Size(57, 20)
        Me.MenuFormat.Text = "For&mat"
        '
        'FormatWordWrap
        '
        Me.FormatWordWrap.Name = "FormatWordWrap"
        Me.FormatWordWrap.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.FormatWordWrap.Size = New System.Drawing.Size(232, 22)
        Me.FormatWordWrap.Text = "&Word Wrap"
        '
        'FormatFont
        '
        Me.FormatFont.Name = "FormatFont"
        Me.FormatFont.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.FormatFont.Size = New System.Drawing.Size(232, 22)
        Me.FormatFont.Text = "&Font..."
        '
        'FormatBackground
        '
        Me.FormatBackground.Name = "FormatBackground"
        Me.FormatBackground.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F6), System.Windows.Forms.Keys)
        Me.FormatBackground.Size = New System.Drawing.Size(232, 22)
        Me.FormatBackground.Text = "&Background Colour..."
        '
        'MenuView
        '
        Me.MenuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewStatusBar, Me.ViewSeparator1, Me.ViewZoomIn, Me.ViewZoomOut, Me.ViewZoomReset, Me.ViewZoomSet})
        Me.MenuView.Name = "MenuView"
        Me.MenuView.Size = New System.Drawing.Size(44, 20)
        Me.MenuView.Text = "&View"
        '
        'ViewStatusBar
        '
        Me.ViewStatusBar.Name = "ViewStatusBar"
        Me.ViewStatusBar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F12), System.Windows.Forms.Keys)
        Me.ViewStatusBar.Size = New System.Drawing.Size(254, 22)
        Me.ViewStatusBar.Text = "&Status Bar"
        '
        'ViewSeparator1
        '
        Me.ViewSeparator1.Name = "ViewSeparator1"
        Me.ViewSeparator1.Size = New System.Drawing.Size(251, 6)
        '
        'ViewZoomIn
        '
        Me.ViewZoomIn.Name = "ViewZoomIn"
        Me.ViewZoomIn.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.Oemplus), System.Windows.Forms.Keys)
        Me.ViewZoomIn.Size = New System.Drawing.Size(254, 22)
        Me.ViewZoomIn.Text = "Zoom &In"
        '
        'ViewZoomOut
        '
        Me.ViewZoomOut.Name = "ViewZoomOut"
        Me.ViewZoomOut.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.OemMinus), System.Windows.Forms.Keys)
        Me.ViewZoomOut.Size = New System.Drawing.Size(254, 22)
        Me.ViewZoomOut.Text = "Zoom &Out"
        '
        'ViewZoomReset
        '
        Me.ViewZoomReset.Name = "ViewZoomReset"
        Me.ViewZoomReset.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Oemplus), System.Windows.Forms.Keys)
        Me.ViewZoomReset.Size = New System.Drawing.Size(254, 22)
        Me.ViewZoomReset.Text = "&Reset Zoom Level"
        '
        'ViewZoomSet
        '
        Me.ViewZoomSet.Name = "ViewZoomSet"
        Me.ViewZoomSet.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.OemMinus), System.Windows.Forms.Keys)
        Me.ViewZoomSet.Size = New System.Drawing.Size(254, 22)
        Me.ViewZoomSet.Text = "Set &Zoom"
        '
        'MenuHelp
        '
        Me.MenuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpViewHelp, Me.HelpSeparator1, Me.HelpAbout375Script})
        Me.MenuHelp.Name = "MenuHelp"
        Me.MenuHelp.Size = New System.Drawing.Size(44, 20)
        Me.MenuHelp.Text = "&Help"
        '
        'HelpViewHelp
        '
        Me.HelpViewHelp.Name = "HelpViewHelp"
        Me.HelpViewHelp.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpViewHelp.Size = New System.Drawing.Size(204, 22)
        Me.HelpViewHelp.Text = "View &Help"
        '
        'HelpSeparator1
        '
        Me.HelpSeparator1.Name = "HelpSeparator1"
        Me.HelpSeparator1.Size = New System.Drawing.Size(201, 6)
        '
        'HelpAbout375Script
        '
        Me.HelpAbout375Script.Name = "HelpAbout375Script"
        Me.HelpAbout375Script.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.HelpAbout375Script.Size = New System.Drawing.Size(204, 22)
        Me.HelpAbout375Script.Text = "&About 375Script"
        '
        'Save
        '
        Me.Save.Filter = "375Script File|*.375|Text Document|*.txt|Event Log|*.log|All Files|*.*"
        '
        'Print
        '
        Me.Print.UseEXDialog = True
        '
        'Open
        '
        Me.Open.DefaultExt = "375"
        Me.Open.Filter = "375Script File|*.375|Text Document|*.txt|Event Log|*.log|All Files|*.*"
        '
        'Edit
        '
        Me.Edit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Edit.Location = New System.Drawing.Point(25, 24)
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(331, 215)
        Me.Edit.TabIndex = 3
        Me.Edit.Text = ""
        '
        'Status
        '
        Me.Status.Location = New System.Drawing.Point(0, 239)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(356, 22)
        Me.Status.TabIndex = 8
        '
        'SetFont
        '
        Me.SetFont.ShowColor = True
        '
        'Background
        '
        Me.Background.AnyColor = True
        '
        'LineNumbers
        '
        Me.LineNumbers._SeeThroughMode_ = False
        Me.LineNumbers.AutoSizing = True
        Me.LineNumbers.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LineNumbers.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue
        Me.LineNumbers.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.LineNumbers.BorderLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbers.BorderLines_Thickness = 1.0!
        Me.LineNumbers.DockSide = _375Archive.LineNumbers_For_RichTextBox.LineNumberDockSide.Left
        Me.LineNumbers.GridLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbers.GridLines_Thickness = 1.0!
        Me.LineNumbers.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight
        Me.LineNumbers.LineNrs_AntiAlias = True
        Me.LineNumbers.LineNrs_AsHexadecimal = False
        Me.LineNumbers.LineNrs_ClippedByItemRectangle = True
        Me.LineNumbers.LineNrs_LeadingZeroes = True
        Me.LineNumbers.LineNrs_Offset = New System.Drawing.Size(0, 0)
        Me.LineNumbers.Location = New System.Drawing.Point(4, 24)
        Me.LineNumbers.Margin = New System.Windows.Forms.Padding(0)
        Me.LineNumbers.MarginLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers.MarginLines_Side = _375Archive.LineNumbers_For_RichTextBox.LineNumberDockSide.Right
        Me.LineNumbers.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LineNumbers.MarginLines_Thickness = 1.0!
        Me.LineNumbers.Name = "LineNumbers"
        Me.LineNumbers.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.LineNumbers.ParentRichTextBox = Me.Edit
        Me.LineNumbers.Show_BackgroundGradient = True
        Me.LineNumbers.Show_BorderLines = True
        Me.LineNumbers.Show_GridLines = True
        Me.LineNumbers.Show_LineNrs = True
        Me.LineNumbers.Show_MarginLines = True
        Me.LineNumbers.Size = New System.Drawing.Size(20, 215)
        Me.LineNumbers.TabIndex = 9
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 261)
        Me.Controls.Add(Me.LineNumbers)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.Menu)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.Menu
        Me.Name = "Editor"
        Me.Text = "375Archive"
        Me.Menu.ResumeLayout(False)
        Me.Menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend Shadows WithEvents Menu As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditGoTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatWordWrap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatFont As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewStatusBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpViewHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpAbout375Script As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Print As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetup As System.Windows.Forms.PageSetupDialog
    Friend WithEvents Open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FileOpenLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Edit As System.Windows.Forms.RichTextBox
    Friend WithEvents Status As System.Windows.Forms.StatusBar
    Friend WithEvents ViewSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewZoomIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewZoomOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewZoomReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetFont As System.Windows.Forms.FontDialog
    Friend WithEvents FormatBackground As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Background As System.Windows.Forms.ColorDialog
    Friend WithEvents ViewZoomSet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertTimeDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertChar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineNumbers As LineNumbers_For_RichTextBox
End Class
