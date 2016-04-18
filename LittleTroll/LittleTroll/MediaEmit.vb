Public Class MediaEmit
    Friend Sound As System.Media.SoundPlayer
    Friend Style As LittleTroll.MediaEmit.SoundStyle
    Public Enum SoundStyle As Byte
        L00p = 0
        Once = 1
    End Enum
    Sub New(Optional Image As System.Drawing.Image = Nothing, Optional Sound As System.Media.SoundPlayer = Nothing, Optional SoundStyle As SoundStyle = SoundStyle.L00p)
        InitializeComponent()
        Me.Image.Image = Image
        Me.Sound = Sound
        Me.Style = SoundStyle
    End Sub
    Public NotInheritable Class DefaultSounds
        Public ReadOnly Property Schoolbell As System.Media.SoundPlayer
            Get
                Return New System.Media.SoundPlayer(My.Resources.TD72_Amaryllis)
            End Get
        End Property
    End Class
End Class