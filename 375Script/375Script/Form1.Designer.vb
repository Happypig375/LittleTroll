<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.FileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilePageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditFindNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditReplace = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditGoTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditInsertTimeDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.MenuEdit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(356, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileNew, Me.FileOpen, Me.FileSave, Me.FileSaveAs, Me.FileSeparator1, Me.FilePageSetup, Me.FilePrint, Me.FileSeparator2, Me.FileExit})
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(37, 20)
        Me.MenuFile.Text = "&File"
        '
        'FileNew
        '
        Me.FileNew.Name = "FileNew"
        Me.FileNew.Size = New System.Drawing.Size(152, 22)
        Me.FileNew.Text = "&New..."
        '
        'FileOpen
        '
        Me.FileOpen.Name = "FileOpen"
        Me.FileOpen.Size = New System.Drawing.Size(152, 22)
        Me.FileOpen.Text = "&Open..."
        '
        'FileSave
        '
        Me.FileSave.Name = "FileSave"
        Me.FileSave.Size = New System.Drawing.Size(152, 22)
        Me.FileSave.Text = "&Save"
        '
        'FileSaveAs
        '
        Me.FileSaveAs.Name = "FileSaveAs"
        Me.FileSaveAs.Size = New System.Drawing.Size(152, 22)
        Me.FileSaveAs.Text = "Save &As..."
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Name = "FileSeparator1"
        Me.FileSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'FilePageSetup
        '
        Me.FilePageSetup.Name = "FilePageSetup"
        Me.FilePageSetup.Size = New System.Drawing.Size(152, 22)
        Me.FilePageSetup.Text = "Page Setup..."
        '
        'FilePrint
        '
        Me.FilePrint.Name = "FilePrint"
        Me.FilePrint.Size = New System.Drawing.Size(152, 22)
        Me.FilePrint.Text = "&Print..."
        '
        'FileSeparator2
        '
        Me.FileSeparator2.Name = "FileSeparator2"
        Me.FileSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'FileExit
        '
        Me.FileExit.Name = "FileExit"
        Me.FileExit.Size = New System.Drawing.Size(152, 22)
        Me.FileExit.Text = "Exit"
        '
        'MenuEdit
        '
        Me.MenuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUndo, Me.EditRedo, Me.EditSeparator1, Me.EditCut, Me.EditCopy, Me.EditPaste, Me.EditDelete, Me.EditSeparator2, Me.EditFind, Me.EditFindNext, Me.EditReplace, Me.EditGoTo, Me.EditSeparator3, Me.EditSelectAll, Me.EditInsertTimeDate})
        Me.MenuEdit.Name = "MenuEdit"
        Me.MenuEdit.Size = New System.Drawing.Size(39, 20)
        Me.MenuEdit.Text = "&Edit"
        '
        'EditUndo
        '
        Me.EditUndo.Name = "EditUndo"
        Me.EditUndo.Size = New System.Drawing.Size(162, 22)
        Me.EditUndo.Text = "&Undo"
        '
        'EditRedo
        '
        Me.EditRedo.Name = "EditRedo"
        Me.EditRedo.Size = New System.Drawing.Size(162, 22)
        Me.EditRedo.Text = "&Redo"
        '
        'EditSeparator1
        '
        Me.EditSeparator1.Name = "EditSeparator1"
        Me.EditSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'EditCut
        '
        Me.EditCut.Name = "EditCut"
        Me.EditCut.Size = New System.Drawing.Size(162, 22)
        Me.EditCut.Text = "&Cut"
        '
        'EditCopy
        '
        Me.EditCopy.Name = "EditCopy"
        Me.EditCopy.Size = New System.Drawing.Size(162, 22)
        Me.EditCopy.Text = "&Copy"
        '
        'EditPaste
        '
        Me.EditPaste.Name = "EditPaste"
        Me.EditPaste.Size = New System.Drawing.Size(162, 22)
        Me.EditPaste.Text = "&Paste"
        '
        'EditDelete
        '
        Me.EditDelete.Name = "EditDelete"
        Me.EditDelete.Size = New System.Drawing.Size(162, 22)
        Me.EditDelete.Text = "&Delete"
        '
        'EditSeparator2
        '
        Me.EditSeparator2.Name = "EditSeparator2"
        Me.EditSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'EditFind
        '
        Me.EditFind.Name = "EditFind"
        Me.EditFind.Size = New System.Drawing.Size(162, 22)
        Me.EditFind.Text = "&Find..."
        '
        'EditFindNext
        '
        Me.EditFindNext.Name = "EditFindNext"
        Me.EditFindNext.Size = New System.Drawing.Size(162, 22)
        Me.EditFindNext.Text = "Find &Next"
        '
        'EditReplace
        '
        Me.EditReplace.Name = "EditReplace"
        Me.EditReplace.Size = New System.Drawing.Size(162, 22)
        Me.EditReplace.Text = "&Replace..."
        '
        'EditSeparator3
        '
        Me.EditSeparator3.Name = "EditSeparator3"
        Me.EditSeparator3.Size = New System.Drawing.Size(159, 6)
        '
        'EditGoTo
        '
        Me.EditGoTo.Name = "EditGoTo"
        Me.EditGoTo.Size = New System.Drawing.Size(162, 22)
        Me.EditGoTo.Text = "&Go To..."
        '
        'EditSelectAll
        '
        Me.EditSelectAll.Name = "EditSelectAll"
        Me.EditSelectAll.Size = New System.Drawing.Size(162, 22)
        Me.EditSelectAll.Text = "Select &All"
        '
        'EditInsertTimeDate
        '
        Me.EditInsertTimeDate.Name = "EditInsertTimeDate"
        Me.EditInsertTimeDate.Size = New System.Drawing.Size(162, 22)
        Me.EditInsertTimeDate.Text = "Insert &Time/Date"
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 261)
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
    Friend WithEvents EditRedo As System.Windows.Forms.ToolStripMenuItem
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

End Class
