Public Class Main
#Region "Inherited from MMLCHelper"
    Dim EnteringPassword As Boolean
    Dim EnteringPasswordCode As Integer
    Private RestoreSize As New Size
    Enum HotkeyModifier As UShort
        None = &H0
        Alt = &H1 'Alt key
        Control = &H2
        Shift = &H4
        Windows = &H8
        WM_HOTKEY = &H312
        Norepeat = &H4000
    End Enum
    <Runtime.InteropServices.DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer, _
                                    ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    End Function
    <Runtime.InteropServices.DllImport("User32.dll")> _
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    End Function
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = HotkeyModifier.WM_HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToInt32)
                Case 400
                    If Not EnteringPassword Then
                        RegisterHotKey(Me.Handle, 401, HotkeyModifier.None, Keys.D1)
                        RegisterHotKey(Me.Handle, 402, HotkeyModifier.None, Keys.D2)
                        RegisterHotKey(Me.Handle, 403, HotkeyModifier.None, Keys.D3)
                        RegisterHotKey(Me.Handle, 404, HotkeyModifier.None, Keys.D4)
                        RegisterHotKey(Me.Handle, 405, HotkeyModifier.None, Keys.D5)
                        RegisterHotKey(Me.Handle, 406, HotkeyModifier.None, Keys.D6)
                        RegisterHotKey(Me.Handle, 407, HotkeyModifier.None, Keys.D7)
                        RegisterHotKey(Me.Handle, 408, HotkeyModifier.None, Keys.D8)
                        RegisterHotKey(Me.Handle, 409, HotkeyModifier.None, Keys.D9)
                        RegisterHotKey(Me.Handle, 410, HotkeyModifier.None, Keys.D0)
                        RegisterHotKey(Me.Handle, 411, HotkeyModifier.None, Keys.NumPad1)
                        RegisterHotKey(Me.Handle, 412, HotkeyModifier.None, Keys.NumPad2)
                        RegisterHotKey(Me.Handle, 413, HotkeyModifier.None, Keys.NumPad3)
                        RegisterHotKey(Me.Handle, 414, HotkeyModifier.None, Keys.NumPad4)
                        RegisterHotKey(Me.Handle, 415, HotkeyModifier.None, Keys.NumPad5)
                        RegisterHotKey(Me.Handle, 416, HotkeyModifier.None, Keys.NumPad6)
                        RegisterHotKey(Me.Handle, 417, HotkeyModifier.None, Keys.NumPad7)
                        RegisterHotKey(Me.Handle, 418, HotkeyModifier.None, Keys.NumPad8)
                        RegisterHotKey(Me.Handle, 419, HotkeyModifier.None, Keys.NumPad9)
                        RegisterHotKey(Me.Handle, 420, HotkeyModifier.None, Keys.NumPad0)
                        RegisterHotKey(Me.Handle, 421, HotkeyModifier.None, Keys.Back)
                        RegisterHotKey(Me.Handle, 422, HotkeyModifier.None, Keys.Enter)
                        RegisterHotKey(Me.Handle, 423, HotkeyModifier.None, Keys.Escape)
                        RegisterHotKey(Me.Handle, 424, HotkeyModifier.None, Keys.OemMinus)
                        RegisterHotKey(Me.Handle, 425, HotkeyModifier.None, Keys.Subtract)
                    End If
                    EnteringPassword = True
                    EnteringPasswordCode = 0
                Case 401 To 409
                    EnteringPasswordCode = CInt(Str(EnteringPasswordCode) & Str(id.ToInt32 - 400))
                Case 410 To 419
                    EnteringPasswordCode = CInt(Str(EnteringPasswordCode) & Str(id.ToInt32 - 410))
                Case 420
                    EnteringPasswordCode = CInt(Str(EnteringPasswordCode) & "0")
                Case 421
                    EnteringPasswordCode = CInt(Str(EnteringPasswordCode).Reverse.ToString.Remove(0).Reverse.ToString)
                Case 422
                    UnregisterInputHotKey()

                Case 423
                    UnregisterInputHotKey()
                    EnteringPasswordCode = 0
                Case 424, 425
                    EnteringPasswordCode = -EnteringPasswordCode
                Case 399
                    ShowHide()
            End Select
        End If
        MyBase.WndProc(m)

    End Sub
    Friend Sub UnregisterInputHotKey()
        EnteringPassword = False
        For i As Integer = 401 To 425
            UnregisterHotKey(Me.Handle, i)
        Next
    End Sub
    Friend Sub ShowHide()
        Me.TopMost = Not Me.TopMost
        If Me.TopMost Then
            Me.Show()
            Me.ClientSize = New Size(Me.RestoreBounds.X, Me.RestoreBounds.Y)
            Me.ClientSize = RestoreSize
        Else : Me.Hide()
        End If
    End Sub
    Friend Sub Register()
        RegisterHotKey(Me.Handle, 399, HotkeyModifier.Control Or HotkeyModifier.Alt Or HotkeyModifier.Shift Or HotkeyModifier.Windows, Keys.F12)
    End Sub
    Friend Sub Unregister()
        UnregisterHotKey(Me.Handle, 399)
    End Sub
#End Region

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Unregister()
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Type.SelectedIndex = 0
        ' CreateMyListView()
        RestoreSize = Me.ClientSize
        Register()
    End Sub

    Private Sub AddSchedule_Click(sender As Object, e As EventArgs) Handles AddSchedule.Click
        Dim NewSchedule As New ListViewItem(Time.Value.ToString)
        NewSchedule.SubItems.Add(Type.SelectedItem)
        Schedule.Items.Add(NewSchedule)
    End Sub
    Private Sub CreateMyListView()
        ' Create a new ListView control.
        Dim listView1 As New ListView()
        listView1.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))

        ' Set the view to show details.
        listView1.View = View.Details
        ' Allow the user to edit item text.
        listView1.LabelEdit = True
        ' Allow the user to rearrange columns.
        listView1.AllowColumnReorder = True
        ' Display check boxes.
        listView1.CheckBoxes = True
        ' Select the item and subitems when selection is made.
        listView1.FullRowSelect = True
        ' Display grid lines.
        listView1.GridLines = True
        ' Sort the items in the list in ascending order.
        listView1.Sorting = SortOrder.Ascending

        ' Create three items and three sets of subitems for each item.
        Dim item1 As New ListViewItem("item1", 0)
        ' Place a check mark next to the item.
        item1.Checked = True
        item1.SubItems.Add("1")
        item1.SubItems.Add("2")
        item1.SubItems.Add("3")
        Dim item2 As New ListViewItem("item2", 1)
        item2.SubItems.Add("4")
        item2.SubItems.Add("5")
        item2.SubItems.Add("6")
        Dim item3 As New ListViewItem("item3", 0)
        ' Place a check mark next to the item.
        item3.Checked = True
        item3.SubItems.Add("7")
        item3.SubItems.Add("8")
        item3.SubItems.Add("9")

        ' Create columns for the items and subitems.
        ' Width of -2 indicates auto-size.
        listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left)
        listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
        listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center)

        'Add the items to the ListView.
        listView1.Items.AddRange(New ListViewItem() {item1, item2, item3})

        ' Create two ImageList objects.
        Dim imageListSmall As New ImageList()
        Dim imageListLarge As New ImageList()
#If False Then
        ' Initialize the ImageList objects with bitmaps.
        imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage1.bmp"))
        imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage2.bmp"))
        imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage1.bmp"))
        imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage2.bmp"))
#End If
        'Assign the ImageList objects to the ListView.
        listView1.LargeImageList = imageListLarge
        listView1.SmallImageList = imageListSmall

        ' Add the ListView to the control collection.
        Me.Controls.Add(listView1)
        Settings.Controls.Add(listView1)
    End Sub 'CreateMyListView

    Private Sub Schedule_ItemSelectionChanged(sender As Object, e As EventArgs) Handles Schedule.ItemSelectionChanged
        For Each Item As ListViewItem In Schedule.SelectedItems
            Time.Value = Convert.ToDateTime(Item.Text)
            Type.SelectedItem = Item.SubItems.Item(0)
        Next
    End Sub

    Private Sub RemoveSchedule_Click(sender As Object, e As EventArgs) Handles RemoveSchedule.Click
        For Each Item As ListViewItem In Schedule.SelectedItems
            Schedule.Items.Remove(Item)
        Next
    End Sub

    Private Sub UpdateSchedule_Click(sender As Object, e As EventArgs) Handles UpdateSchedule.Click
        For Each Item As ListViewItem In Schedule.SelectedItems
            Item.Text = Time.Value.ToString
            Item.SubItems(1).Text = Type.SelectedItem
        Next
    End Sub
End Class
