<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.FilePath = New System.Windows.Forms.TextBox()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FilePath
        '
        Me.FilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilePath.Location = New System.Drawing.Point(-1, -1)
        Me.FilePath.Name = "FilePath"
        Me.FilePath.Size = New System.Drawing.Size(262, 20)
        Me.FilePath.TabIndex = 3
        '
        'OpenButton
        '
        Me.OpenButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenButton.Location = New System.Drawing.Point(259, -1)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(27, 23)
        Me.OpenButton.TabIndex = 4
        Me.OpenButton.Text = "..."
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 19)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.FilePath)
        Me.Name = "Form1"
        Me.Text = "Pick a song"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FilePath As System.Windows.Forms.TextBox
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenButton As System.Windows.Forms.Button
End Class
