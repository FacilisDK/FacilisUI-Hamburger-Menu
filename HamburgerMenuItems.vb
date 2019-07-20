Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports System.ComponentModel

Public Class HamburgerMenuItems
    Implements INotifyPropertyChanged
    Implements INotifyCollectionChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        Dim myPropertyChangedEventHandler As PropertyChangedEventHandler = PropertyChangedEvent
        If Nothing IsNot myPropertyChangedEventHandler Then
            myPropertyChangedEventHandler(Me, New PropertyChangedEventArgs(propertyName))
        End If
    End Sub

    Public Event CollectionChanged As NotifyCollectionChangedEventHandler Implements INotifyCollectionChanged.CollectionChanged
    Private Sub NotifyCollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        Dim myCollectionChangedEventHandler As NotifyCollectionChangedEventHandler = CollectionChangedEvent
        If Nothing IsNot myCollectionChangedEventHandler Then
            myCollectionChangedEventHandler(Me, New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
        End If
    End Sub

    Public Sub New()
        Items = New ObservableCollection(Of HamburgerMenuItems)()
    End Sub

    Private _items As ObservableCollection(Of HamburgerMenuItems)
    Public Property Items() As ObservableCollection(Of HamburgerMenuItems)
        Get
            Return _items
        End Get
        Private Set(ByVal value As ObservableCollection(Of HamburgerMenuItems))
            _items = value
        End Set
    End Property

    Private _Caption As String
    Public Property Caption() As String
        Get
            Return _Caption
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_Caption) Then
                _Caption = value
                NotifyPropertyChanged("Caption")
            End If
        End Set
    End Property

    Private _Icon As String
    Public Property Icon() As String
        Get
            Return _Icon
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_Icon) Then
                _Icon = value
                NotifyPropertyChanged("Icon")
            End If
        End Set
    End Property

    Private _Selected As String
    Public Property Selected() As String
        Get
            Return _Selected
        End Get
        Set(ByVal value As String)
            If Not value.Equals(_Selected) Then
                _Selected = value
                NotifyPropertyChanged("Selected")
            End If
        End Set
    End Property

End Class

Public Module ExtensionModule
    <Extension()>
    Public Sub Sort(Of TSource, TKey)(source As Collection(Of TSource), keySelector As Func(Of TSource, TKey))
        Dim sortedList = source.OrderBy(keySelector).ToList()

        source.Clear()

        For Each sortedItem In sortedList
            source.Add(sortedItem)
        Next
    End Sub

End Module