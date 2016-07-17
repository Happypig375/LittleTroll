Imports _375Script.Editor.SyntaxColor
Partial Public Class Editor
    Private Sub InitializeSyntax(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RTBWrapper.bind(Edit)
        With RTBWrapper.rtfSyntax
            .add("^\s*?append\b", True, True, EditorBehaviours)
            .add("^\s*?beep\b", True, True, AudioEmitting)
            .add("^\s*?close\b", True, True, EditorBehaviours)
            .add("^\s*?define\b", True, True, ControlLogic)
            .add("^\s*?display\b", True, True, MessagePopups)
            .add("^\s*?execute\b", True, True, EditorBehaviours)
            .add("^\s*?hide\b", True, True, EditorBehaviours)
            '.rtfSyntax.add("^\s*?play(:l(oop)?|:stop|:x|:s(ystem(sound)?)?|:w(ait(tocomplete)?)?)\b", True, True, AudioEmitting)
            .add("^\s*?loop\b", True, True, ControlLogic)
            .add("(?<=^\s*?play:l)oop\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play):l\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play:s)top\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play):x\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play:system)sound\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play:s)ystem\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play):s\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play:wait)tocomplete\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play:w)ait\b", True, True, AudioEmitting)
            .add("(?<=^\s*?play):w\b", True, True, AudioEmitting)
            .add("^\s*?play\b", True, True, AudioEmitting)
            .add("(?<=^\s*?message:c)ritical\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):c\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):x\b", True, True, MessagePopups)
            .add("(?<=^\s*?message:q)uestion\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):q\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):?\b", True, True, MessagePopups)
            .add("(?<=^\s*?message:e)xclamation\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):e\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):!\b", True, True, MessagePopups)
            .add("(?<=^\s*?message:q)uestion\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):q\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):?\b", True, True, MessagePopups)
            .add("(?<=^\s*?message:info)rmation\b", True, True, MessagePopups)
            .add("(?<=^\s*?message:i)nfo\b", True, True, MessagePopups)
            .add("(?<=^\s*?message):i\b", True, True, MessagePopups)
            .add("^\s*?message\b", True, True, MessagePopups)
            .add("^\s*?opacity\b", True, True, EditorBehaviours)
            .add("(?<=^\s*?redefine:e)xact\b", True, True, ControlLogic)
            .add("(?<=^\s*?redefine):e\b", True, True, ControlLogic)
            .add("^\s*?redefine\b", True, True, ControlLogic)
            .add("^\s*?repeat\b", True, True, ControlLogic)
            .add("^\s*?show\b", True, True, EditorBehaviours)
            .add("(?<=^\s*?stop:a)ll\b", True, True, ControlLogic)
            .add("(?<=^\s*?stop):a\b", True, True, ControlLogic)
            .add("(?<=^\s*?stop:o)thers\b", True, True, ControlLogic)
            .add("(?<=^\s*?stop):o\b", True, True, ControlLogic)
            .add("^\s*?stop\b", True, True, ControlLogic)
            .add("^\s*?stoprender\b", True, True, EditorBehaviours)
            .add("^\s*?undefine\b", True, True, ControlLogic)
            .add("^\s*?waituntil\b", True, True, ControlLogic)
            .add("^\s*?wait\b", True, True, ControlLogic)
#If False Then
            .add("<span.*?>", True, True, Color.Red.ToArgb)
            .add("<p.*>", True, True, Color.Darkdarkcyan.ToArgb)
            .add("<a.*?>", True, True, Color.Blue.ToArgb)
            .add("<table.*?>", True, True, Color.Tan.ToArgb)
            .add("<tr.*?>", True, True, Color.Brown.ToArgb)
            .add("<td.*?>", True, True, Color.Brown.ToArgb)
            .add("<img.*?>", True, True, Color.Red.ToArgb)
            .add("not regex and case sensitive", False, False, Color.Red.ToArgb)
            .add("not regex and case insensitive", False, True, Color.Red.ToArgb)
#End If
        End With
    End Sub
    Friend Enum SyntaxColor
        EditorBehaviours = &HFF0000FF 'Blue
        ControlLogic = &HFF0000 'Red
        AudioEmitting = &HFF008B8B 'DarkCyan
        MessagePopups = &HFFFFA500 'Orange
    End Enum
End Class
