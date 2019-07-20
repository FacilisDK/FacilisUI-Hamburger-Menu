Class MainWindow

    Private Sub BurgerMenu_ItemClicked(Sender As Object)
        Dim ClickedItem As FacilisUI.HamburgerMenuItem = TryCast(Sender, FacilisUI.HamburgerMenuItem)
        lstEvents.Items.Add(New ListBoxItem With {.Content = "Click fired on HamburgerMenuItem '" & ClickedItem.Caption & "' named " & ClickedItem.Name})
    End Sub

End Class