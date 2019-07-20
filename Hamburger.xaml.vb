Public Class Hamburger

    Public Property Items As New ObjectModel.Collection(Of HamburgerMenuItem)

    Public Event ItemClicked(Sender)

    Private Hamburger_Open As Animation.Storyboard
    Private Hamburger_Close As Animation.Storyboard

    Private Sub Hamburger_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Hamburger_Open = FindResource("HamburgerOpen")
        Hamburger_Close = FindResource("HamburgerClose")

        If Items.Count > 0 Then
            For i As Integer = 0 To Items.Count - 1
                Dim itm As New HamburgerMenuItem With {.Name = "HamburgerMenuItem" & i, .Caption = Items(i).Caption, .Icon = Items(i).Icon, .Selected = Items(i).Selected}
                stkItems.Children.Add(itm)
                AddHandler itm.Click, AddressOf MenuItem_Click
            Next
        End If
    End Sub

    Private Sub MenuItem_Click(Sender As HamburgerMenuItem)
        SelectItem(Sender)
        RaiseEvent ItemClicked(Sender)
    End Sub

    Private Sub HamburgerButton_Click(sender As Object, e As RoutedEventArgs) Handles HamburgerButton.Click
        If HamburgerMain.Width = 48 Then
            Hamburger_Open.Begin()
        Else
            Hamburger_Close.Begin()
        End If
    End Sub

    Private Sub SelectItem(SelectedItem As HamburgerMenuItem)
        For i As Integer = 0 To Items.Count - 1
            Dim Itm As HamburgerMenuItem = TryCast(stkItems.Children(i), HamburgerMenuItem)
            Itm.Selected = False
            Items(i).Selected = False
        Next

        SelectedItem.Selected = True
    End Sub

End Class