﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.MenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilePageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditFindNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditReplace = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditGoTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInsertTimeDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFormat = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatWordWrap = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatFont = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewStatusBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpViewHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpAbout375Script = New System.Windows.Forms.ToolStripMenuItem()
        Me.Edit = New System.Windows.Forms.TextBox()
        Me.Save = New System.Windows.Forms.SaveFileDialog()
        Me.Print = New System.Windows.Forms.PrintDialog()
        Me.PageSetup = New System.Windows.Forms.PageSetupDialog()
        Me.Open = New System.Windows.Forms.OpenFileDialog()
        Me.FileOpenLink = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.MenuEdit, Me.MenuFormat, Me.MenuView, Me.MenuHelp})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(356, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNew, Me.FileOpen, Me.FileOpenLink, Me.FileReload, Me.FileSave, Me.FileSaveAs, Me.FileSeparator1, Me.FilePageSetup, Me.FilePrint, Me.FileSeparator2, Me.FileExit})
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(37, 20)
        Me.MenuFile.Text = "&File"
        '
        'FileNew
        '
        Me.FileNew.Name = "FileNew"
        Me.FileNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.FileNew.Size = New System.Drawing.Size(215, 22)
        Me.FileNew.Text = "&New..."
        '
        'FileOpen
        '
        Me.FileOpen.Name = "FileOpen"
        Me.FileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpen.Size = New System.Drawing.Size(215, 22)
        Me.FileOpen.Text = "&Open..."
        '
        'FileReload
        '
        Me.FileReload.Name = "FileReload"
        Me.FileReload.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.FileReload.Size = New System.Drawing.Size(215, 22)
        Me.FileReload.Text = "&Reload"
        '
        'FileSave
        '
        Me.FileSave.Name = "FileSave"
        Me.FileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSave.Size = New System.Drawing.Size(215, 22)
        Me.FileSave.Text = "&Save"
        '
        'FileSaveAs
        '
        Me.FileSaveAs.Name = "FileSaveAs"
        Me.FileSaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.FileSaveAs.Size = New System.Drawing.Size(215, 22)
        Me.FileSaveAs.Text = "Save &As..."
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Name = "FileSeparator1"
        Me.FileSeparator1.Size = New System.Drawing.Size(212, 6)
        '
        'FilePageSetup
        '
        Me.FilePageSetup.Name = "FilePageSetup"
        Me.FilePageSetup.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.FilePageSetup.Size = New System.Drawing.Size(215, 22)
        Me.FilePageSetup.Text = "Page Setup..."
        '
        'FilePrint
        '
        Me.FilePrint.Name = "FilePrint"
        Me.FilePrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.FilePrint.Size = New System.Drawing.Size(215, 22)
        Me.FilePrint.Text = "&Print..."
        '
        'FileSeparator2
        '
        Me.FileSeparator2.Name = "FileSeparator2"
        Me.FileSeparator2.Size = New System.Drawing.Size(212, 6)
        '
        'FileExit
        '
        Me.FileExit.Name = "FileExit"
        Me.FileExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.FileExit.Size = New System.Drawing.Size(215, 22)
        Me.FileExit.Text = "Exit"
        '
        'MenuEdit
        '
        Me.MenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUndo, Me.EditSeparator1, Me.EditCut, Me.EditCopy, Me.EditPaste, Me.EditDelete, Me.EditSeparator2, Me.EditFind, Me.EditFindNext, Me.EditReplace, Me.EditGoTo, Me.EditSeparator3, Me.EditSelectAll, Me.EditInsertTimeDate})
        Me.MenuEdit.Name = "MenuEdit"
        Me.MenuEdit.Size = New System.Drawing.Size(39, 20)
        Me.MenuEdit.Text = "&Edit"
        '
        'EditUndo
        '
        Me.EditUndo.Name = "EditUndo"
        Me.EditUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.EditUndo.Size = New System.Drawing.Size(204, 22)
        Me.EditUndo.Text = "&Undo"
        '
        'EditSeparator1
        '
        Me.EditSeparator1.Name = "EditSeparator1"
        Me.EditSeparator1.Size = New System.Drawing.Size(201, 6)
        '
        'EditCut
        '
        Me.EditCut.Name = "EditCut"
        Me.EditCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.EditCut.Size = New System.Drawing.Size(204, 22)
        Me.EditCut.Text = "&Cut"
        '
        'EditCopy
        '
        Me.EditCopy.Name = "EditCopy"
        Me.EditCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.EditCopy.Size = New System.Drawing.Size(204, 22)
        Me.EditCopy.Text = "&Copy"
        '
        'EditPaste
        '
        Me.EditPaste.Name = "EditPaste"
        Me.EditPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.EditPaste.Size = New System.Drawing.Size(204, 22)
        Me.EditPaste.Text = "&Paste"
        '
        'EditDelete
        '
        Me.EditDelete.Name = "EditDelete"
        Me.EditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.EditDelete.Size = New System.Drawing.Size(204, 22)
        Me.EditDelete.Text = "&Delete"
        '
        'EditSeparator2
        '
        Me.EditSeparator2.Name = "EditSeparator2"
        Me.EditSeparator2.Size = New System.Drawing.Size(201, 6)
        '
        'EditFind
        '
        Me.EditFind.Name = "EditFind"
        Me.EditFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.EditFind.Size = New System.Drawing.Size(204, 22)
        Me.EditFind.Text = "&Find..."
        '
        'EditFindNext
        '
        Me.EditFindNext.Name = "EditFindNext"
        Me.EditFindNext.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.EditFindNext.Size = New System.Drawing.Size(204, 22)
        Me.EditFindNext.Text = "Find &Next"
        '
        'EditReplace
        '
        Me.EditReplace.Name = "EditReplace"
        Me.EditReplace.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.EditReplace.Size = New System.Drawing.Size(204, 22)
        Me.EditReplace.Text = "&Replace..."
        '
        'EditGoTo
        '
        Me.EditGoTo.Name = "EditGoTo"
        Me.EditGoTo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.EditGoTo.Size = New System.Drawing.Size(204, 22)
        Me.EditGoTo.Text = "&Go To..."
        '
        'EditSeparator3
        '
        Me.EditSeparator3.Name = "EditSeparator3"
        Me.EditSeparator3.Size = New System.Drawing.Size(201, 6)
        '
        'EditSelectAll
        '
        Me.EditSelectAll.Name = "EditSelectAll"
        Me.EditSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.EditSelectAll.Size = New System.Drawing.Size(204, 22)
        Me.EditSelectAll.Text = "Select &All"
        '
        'EditInsertTimeDate
        '
        Me.EditInsertTimeDate.Name = "EditInsertTimeDate"
        Me.EditInsertTimeDate.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.EditInsertTimeDate.Size = New System.Drawing.Size(204, 22)
        Me.EditInsertTimeDate.Text = "Insert &Time/Date"
        '
        'MenuFormat
        '
        Me.MenuFormat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FormatWordWrap, Me.FormatFont})
        Me.MenuFormat.Name = "MenuFormat"
        Me.MenuFormat.Size = New System.Drawing.Size(57, 20)
        Me.MenuFormat.Text = "For&mat"
        '
        'FormatWordWrap
        '
        Me.FormatWordWrap.Name = "FormatWordWrap"
        Me.FormatWordWrap.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.FormatWordWrap.Size = New System.Drawing.Size(159, 22)
        Me.FormatWordWrap.Text = "&Word Wrap"
        '
        'FormatFont
        '
        Me.FormatFont.Name = "FormatFont"
        Me.FormatFont.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.FormatFont.Size = New System.Drawing.Size(159, 22)
        Me.FormatFont.Text = "&Font..."
        '
        'MenuView
        '
        Me.MenuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewStatusBar})
        Me.MenuView.Name = "MenuView"
        Me.MenuView.Size = New System.Drawing.Size(44, 20)
        Me.MenuView.Text = "&View"
        '
        'ViewStatusBar
        '
        Me.ViewStatusBar.Name = "ViewStatusBar"
        Me.ViewStatusBar.Size = New System.Drawing.Size(126, 22)
        Me.ViewStatusBar.Text = "&Status Bar"
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
        'Edit
        '
        Me.Edit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Edit.Location = New System.Drawing.Point(0, 24)
        Me.Edit.Multiline = True
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(356, 237)
        Me.Edit.TabIndex = 1
        '
        'Print
        '
        Me.Print.UseEXDialog = True
        '
        'Open
        '
        Me.Open.DefaultExt = "375"
        '
        'FileOpenLink
        '
        Me.FileOpenLink.Name = "FileOpenLink"
        Me.FileOpenLink.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.FileOpenLink.Size = New System.Drawing.Size(215, 22)
        Me.FileOpenLink.Text = "Open &Link..."
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 261)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Editor"
        Me.Text = "375Script"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilePageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditFindNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditReplace As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditGoTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditInsertTimeDate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFormat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatWordWrap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatFont As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewStatusBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpViewHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpAbout375Script As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Edit As System.Windows.Forms.TextBox
    Friend WithEvents FileReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Print As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetup As System.Windows.Forms.PageSetupDialog
    Friend WithEvents Open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FileOpenLink As System.Windows.Forms.ToolStripMenuItem

End Class