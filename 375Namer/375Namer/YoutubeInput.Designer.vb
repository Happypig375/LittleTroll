<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YoutubeInput
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
        Me.Input = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Input
        '
        Me.Input.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Input.Location = New System.Drawing.Point(0, 0)
        Me.Input.Multiline = True
        Me.Input.Name = "Input"
        Me.Input.Size = New System.Drawing.Size(402, 313)
        Me.Input.TabIndex = 0
        '
        'YoutubeInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 313)
        Me.Controls.Add(Me.Input)
        Me.Name = "YoutubeInput"
        Me.Text = "YoutubeInput"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Input As TextBox
End Class
