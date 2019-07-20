<ComponentModel.DefaultEvent("Click")>
Public Class HamburgerMenuItem

    Private _Icon As String = "&#xE10F;"
    Public Property Icon As String
        Get
            Return _Icon
        End Get
        Set(value As String)
            _Icon = value
            lblIcon.Content = value
            InvalidateArrange()
        End Set
    End Property

    Private _Caption As String = "Menu item"
    Public Property Caption As String
        Get
            Return _Caption
        End Get
        Set(value As String)
            _Caption = value
            lblCaption.Content = value
            InvalidateArrange()
        End Set
    End Property

    Private _Selected As Boolean = False
    Public Property Selected As Boolean
        Get
            Return _Selected
        End Get
        Set(value As Boolean)
            _Selected = value

            If value = True Then
                lblSelected.Visibility = Visibility.Visible
            Else
                lblSelected.Visibility = Visibility.Collapsed
            End If
        End Set
    End Property

    Private Sub MenuItem_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
        Height = 48
    End Sub

    Public Event Click(Sender As HamburgerMenuItem)

    Private Sub Cmd_Click(sender As Object, e As RoutedEventArgs) Handles Cmd.Click
        RaiseEvent Click(Me)
    End Sub

End Class