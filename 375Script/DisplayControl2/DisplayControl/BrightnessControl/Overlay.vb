
Imports System.Runtime.InteropServices

Public Class Overlay
    Dim StartTime As Date = #9/15/2016 1:15:00 PM#
    Dim EndTime As Date = #9/15/2016 1:55:00 PM#
    Private InitialStyle As Integer
    Public PercentVisible As Decimal = 0.4D
    Public IsRandom As Boolean
    Public ChosenColor As Color

    Public Sub New(ByVal Random As Boolean, ByVal Color As Color,
                   Optional ByVal Opacity As Decimal = 0.4D,
                   Optional ByVal Image As Image = Nothing,
                   Optional ByVal ImageStyle As ImageLayout = ImageLayout.Center,
                   Optional ByVal HideCursor As Boolean = False)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        IsRandom = Random
        ChosenColor = Color
        If ChosenColor = Nothing Then TransparencyKey = SystemColors.Control
        PercentVisible = Opacity
        BackgroundImage = Image
        BackgroundImageLayout = ImageStyle
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Do Until Now > StartTime
        'Loop
        Timer_Tick(sender, e)
        InitialStyle = GetWindowLong(Me.Handle, -20)

        SetWindowLong(Me.Handle, -20, InitialStyle Or &H80000 Or &H20)

        SetLayeredWindowAttributes(Me.Handle, 0, CByte(255 * PercentVisible), &H2)
        Me.Location = New Point(0, 0)
        Me.Size = My.Computer.Screen.Bounds.Size
        Me.BackColor = ChosenColor
        Me.BringToFront()
        Topper.RunWorkerAsync()
    End Sub

    <DllImport("user32.dll", EntryPoint:="GetWindowLong")> Public Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetWindowLong")> Public Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll", EntryPoint:="SetLayeredWindowAttributes")> Public Shared Function SetLayeredWindowAttributes(ByVal hWnd As IntPtr, ByVal crKey As Integer, ByVal alpha As Byte, ByVal dwFlags As Integer) As Boolean
    End Function

    Private Sub Topper_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Topper.DoWork
        Do
            BringToFrontInvoke()
            Threading.Thread.Sleep(70)
        Loop
    End Sub
    Private Delegate Sub NoParamDelegate()

    Public Sub HideInvoke()
        If InvokeRequired Then
            Invoke(New NoParamDelegate(AddressOf HideInvoke))
        Else : Hide()
        End If
    End Sub

    Public Sub BringToFrontInvoke()
        Try
            If InvokeRequired Then
                Invoke(New NoParamDelegate(AddressOf BringToFrontInvoke))
            Else : Me.TopMost = True
            End If
        Catch
        End Try
    End Sub
    Friend Shared Function RandomColour() As Color
        Return Color.FromArgb(New Random().Next(16777215) - 16777216)
    End Function
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        'If Now > EndTime Then Application.Exit()
        If IsRandom Then Me.BackColor = RandomColour()
    End Sub
    Dim ForcingClose As Boolean
    Private Sub Overlay_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.None AndAlso Not ForcingClose Then e.Cancel = True
    End Sub

    Friend Sub ForceClose()
        ForcingClose = True
        Close()
    End Sub
End Class