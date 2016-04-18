<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MediaEmit
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaEmit))
        Me.Images = New System.Windows.Forms.ImageList(Me.components)
        Me.Image = New System.Windows.Forms.PictureBox()
        CType(Me.Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Images
        '
        Me.Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.Images.ImageSize = New System.Drawing.Size(16, 16)
        Me.Images.TransparentColor = System.Drawing.Color.Transparent
        '
        'Image
        '
        Me.Image.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Image.ErrorImage = CType(resources.GetObject("Image.ErrorImage"), System.Drawing.Image)
        Me.Image.InitialImage = CType(resources.GetObject("Image.InitialImage"), System.Drawing.Image)
        Me.Image.Location = New System.Drawing.Point(0, 0)
        Me.Image.Name = "Image"
        Me.Image.Size = New System.Drawing.Size(284, 261)
        Me.Image.TabIndex = 0
        Me.Image.TabStop = False
        '
        'MediaEmit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Image)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MediaEmit"
        Me.ShowInTaskbar = False
        Me.Text = "MediaEmit"
        Me.TransparencyKey = System.Drawing.Color.AliceBlue
        CType(Me.Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Images As System.Windows.Forms.ImageList
    Friend WithEvents Image As System.Windows.Forms.PictureBox
End Class
