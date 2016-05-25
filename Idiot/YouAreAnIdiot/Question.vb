Imports AxShockwaveFlashObjects
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.AxHost

Namespace YouAreAnIdiot
    <DesignerGenerated> _
    Public Class Question
        Inherits Form
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.Question_Load)
            AddHandler MyBase.Closing, New CancelEventHandler(AddressOf Me.Question_Closing)
            Question.__ENCAddToList(Me)
            Me.InitializeComponent()
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            Dim list As List(Of WeakReference) = Question.__ENCList
            SyncLock list
                If (Question.__ENCList.Count = Question.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (Question.__ENCList.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num3)
                        Dim reference As WeakReference = Question.__ENCList.Item(i)
                        If reference.IsAlive Then
                            If (i <> index) Then
                                Question.__ENCList.Item(index) = Question.__ENCList.Item(i)
                            End If
                            index += 1
                        End If
                        i += 1
                    Loop
                    Question.__ENCList.RemoveRange(index, (Question.__ENCList.Count - index))
                    Question.__ENCList.Capacity = Question.__ENCList.Count
                End If
                Question.__ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
            End SyncLock
        End Sub

        <DebuggerNonUserCode> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If (disposing AndAlso (Not Me.components Is Nothing)) Then
                    Me.components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private Sub FontColor_Tick(ByVal sender As Object, ByVal e As EventArgs)
            Me.Timer_FT.Text = Conversions.ToString(CDbl((Conversions.ToDouble(Me.Timer_FT.Text) + 1)))
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 0) Then
                Me.Label_Question.ForeColor = Color.Indigo
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 1) Then
                Me.Label_Question.ForeColor = Color.Ivory
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 2) Then
                Me.Label_Question.ForeColor = Color.LightPink
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 3) Then
                Me.Label_Question.ForeColor = Color.LightSkyBlue
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 4) Then
                Me.Label_Question.ForeColor = Color.Lime
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 5) Then
                Me.Label_Question.ForeColor = Color.MediumPurple
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 6) Then
                Me.Label_Question.ForeColor = Color.MediumSpringGreen
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 7) Then
                Me.Label_Question.ForeColor = Color.Pink
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 8) Then
                Me.Label_Question.ForeColor = Color.Red
            End If
            If (Conversions.ToDouble(Me.Timer_FT.Text) = 9) Then
                Me.Label_Question.ForeColor = Color.Snow
                Me.Timer_FT.Text = Conversions.ToString(0)
            End If
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Dim manager As New ComponentResourceManager(GetType(Question))
            Me.AxShockwaveFlash1 = New AxShockwaveFlash
            Me.Yes = New Button
            Me.Label_Question = New Label
            Me.No = New Button
            Me.None = New Button
            Me.FontColor = New Timer(Me.components)
            Me.Timer_FT = New Label
            Me.AxShockwaveFlash1.BeginInit()
            Me.SuspendLayout()
            Me.AxShockwaveFlash1.AccessibleDescription = ""
            Me.AxShockwaveFlash1.AccessibleName = ""
            Me.AxShockwaveFlash1.Enabled = True
            Dim point2 As New Point(0, -1)
            Me.AxShockwaveFlash1.Location = point2
            Dim padding2 As New Padding(0)
            Me.AxShockwaveFlash1.Margin = padding2
            Me.AxShockwaveFlash1.Name = "AxShockwaveFlash1"
            Me.AxShockwaveFlash1.OcxState = DirectCast(manager.GetObject("AxShockwaveFlash1.OcxState"), State)
            Dim size2 As New Size(&H271, &H1D8)
            Me.AxShockwaveFlash1.Size = size2
            Me.AxShockwaveFlash1.TabIndex = 12
            Me.Yes.Font = New Font("Verdana", 12.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&H1BD, &H20F)
            Me.Yes.Location = point2
            Me.Yes.Name = "Yes"
            size2 = New Size(&HA7, &H21)
            Me.Yes.Size = size2
            Me.Yes.TabIndex = 13
            Me.Yes.Text = "Yes, I am."
            Me.Yes.UseVisualStyleBackColor = True
            Me.Label_Question.AutoSize = True
            Me.Label_Question.Font = New Font("Verdana", 20.25!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&HB0, &H1E1)
            Me.Label_Question.Location = point2
            Me.Label_Question.Name = "Label_Question"
            size2 = New Size(&H107, &H20)
            Me.Label_Question.Size = size2
            Me.Label_Question.TabIndex = 14
            Me.Label_Question.Text = "Are You An Idiot ?"
            Me.No.Font = New Font("Verdana", 12.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&H12, &H20F)
            Me.No.Location = point2
            Me.No.Name = "No"
            size2 = New Size(&HB1, &H21)
            Me.No.Size = size2
            Me.No.TabIndex = 15
            Me.No.Text = "No, I'm not."
            Me.No.UseVisualStyleBackColor = True
            Me.None.Font = New Font("Verdana", 12.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&HC9, &H20F)
            Me.None.Location = point2
            Me.None.Name = "None"
            size2 = New Size(&HEE, &H21)
            Me.None.Size = size2
            Me.None.TabIndex = &H10
            Me.None.Text = "I don't know =["
            Me.None.UseVisualStyleBackColor = True
            Me.FontColor.Enabled = True
            Me.FontColor.Interval = &H37
            Me.Timer_FT.AutoSize = True
            point2 = New Point(630, &H238)
            Me.Timer_FT.Location = point2
            Me.Timer_FT.Name = "Timer_FT"
            size2 = New Size(11, 12)
            Me.Timer_FT.Size = size2
            Me.Timer_FT.TabIndex = &H11
            Me.Timer_FT.Text = "0"
            Dim ef2 As New SizeF(6.0!, 12.0!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = SystemColors.Window
            size2 = New Size(&H270, &H232)
            Me.ClientSize = size2
            Me.Controls.Add(Me.Timer_FT)
            Me.Controls.Add(Me.None)
            Me.Controls.Add(Me.No)
            Me.Controls.Add(Me.Label_Question)
            Me.Controls.Add(Me.Yes)
            Me.Controls.Add(Me.AxShockwaveFlash1)
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Question"
            Me.ShowInTaskbar = False
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Are You An Idiot ?"
            Me.TopMost = True
            Me.AxShockwaveFlash1.EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private Sub Label_Question_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub No_Click(ByVal sender As Object, ByVal e As EventArgs)
            Interaction.MsgBox("Oh.. I think you are an idiot. XD", MsgBoxStyle.ApplicationModal, Nothing)
            Me.Close()
        End Sub

        Private Sub None_Click(ByVal sender As Object, ByVal e As EventArgs)
            Interaction.MsgBox("Oh.. I think you are an idiot. XD", MsgBoxStyle.ApplicationModal, Nothing)
            Me.Close()
        End Sub

        Private Sub Question_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            Dim haha As New HAHA
            Dim haha2 As New HAHA
            Dim haha3 As New HAHA
            Dim haha4 As New HAHA
            Dim haha5 As New HAHA
            haha.Show()
            haha2.Show()
            haha3.Show()
            haha4.Show()
            haha5.Show()
        End Sub

        Private Sub Question_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Timer_FT_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Yes_Click(ByVal sender As Object, ByVal e As EventArgs)
            Interaction.MsgBox("Are you sure ? ", MsgBoxStyle.YesNo, Nothing)
            Me.Close()
        End Sub


        ' Properties
        Friend Overridable Property AxShockwaveFlash1 As AxShockwaveFlash
            <DebuggerNonUserCode> _
            Get
                Return Me._AxShockwaveFlash1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As AxShockwaveFlash)
                Me._AxShockwaveFlash1 = WithEventsValue
            End Set
        End Property

        Friend Overridable Property FontColor As Timer
            <DebuggerNonUserCode> _
            Get
                Return Me._FontColor
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Timer)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.FontColor_Tick)
                If (Not Me._FontColor Is Nothing) Then
                    RemoveHandler Me._FontColor.Tick, handler
                End If
                Me._FontColor = WithEventsValue
                If (Not Me._FontColor Is Nothing) Then
                    AddHandler Me._FontColor.Tick, handler
                End If
            End Set
        End Property

        Friend Overridable Property Label_Question As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label_Question
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Label_Question_Click)
                If (Not Me._Label_Question Is Nothing) Then
                    RemoveHandler Me._Label_Question.Click, handler
                End If
                Me._Label_Question = WithEventsValue
                If (Not Me._Label_Question Is Nothing) Then
                    AddHandler Me._Label_Question.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property No As Button
            <DebuggerNonUserCode> _
            Get
                Return Me._No
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.No_Click)
                If (Not Me._No Is Nothing) Then
                    RemoveHandler Me._No.Click, handler
                End If
                Me._No = WithEventsValue
                If (Not Me._No Is Nothing) Then
                    AddHandler Me._No.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property None As Button
            <DebuggerNonUserCode> _
            Get
                Return Me._None
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.None_Click)
                If (Not Me._None Is Nothing) Then
                    RemoveHandler Me._None.Click, handler
                End If
                Me._None = WithEventsValue
                If (Not Me._None Is Nothing) Then
                    AddHandler Me._None.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Timer_FT As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Timer_FT
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Timer_FT_Click)
                If (Not Me._Timer_FT Is Nothing) Then
                    RemoveHandler Me._Timer_FT.Click, handler
                End If
                Me._Timer_FT = WithEventsValue
                If (Not Me._Timer_FT Is Nothing) Then
                    AddHandler Me._Timer_FT.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Yes As Button
            <DebuggerNonUserCode> _
            Get
                Return Me._Yes
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Button)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Yes_Click)
                If (Not Me._Yes Is Nothing) Then
                    RemoveHandler Me._Yes.Click, handler
                End If
                Me._Yes = WithEventsValue
                If (Not Me._Yes Is Nothing) Then
                    AddHandler Me._Yes.Click, handler
                End If
            End Set
        End Property


        ' Fields
        Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        <AccessedThroughProperty("AxShockwaveFlash1")> _
        Private _AxShockwaveFlash1 As AxShockwaveFlash
        <AccessedThroughProperty("FontColor")> _
        Private _FontColor As Timer
        <AccessedThroughProperty("Label_Question")> _
        Private _Label_Question As Label
        <AccessedThroughProperty("No")> _
        Private _No As Button
        <AccessedThroughProperty("None")> _
        Private _None As Button
        <AccessedThroughProperty("Timer_FT")> _
        Private _Timer_FT As Label
        <AccessedThroughProperty("Yes")> _
        Private _Yes As Button
        Private components As IContainer
    End Class
End Namespace

