<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Debug
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
        Me.Console = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Console
        '
        Me.Console.BackColor = System.Drawing.Color.Black
        Me.Console.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Console.ForeColor = System.Drawing.Color.White
        Me.Console.Location = New System.Drawing.Point(0, 0)
        Me.Console.Name = "Console"
        Me.Console.ReadOnly = True
        Me.Console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.Console.Size = New System.Drawing.Size(284, 226)
        Me.Console.TabIndex = 1
        Me.Console.Text = ""
        '
        'Debug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 226)
        Me.Controls.Add(Me.Console)
        Me.KeyPreview = True
        Me.Name = "Debug"
        Me.Text = "Console"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Console As System.Windows.Forms.RichTextBox
End Class
