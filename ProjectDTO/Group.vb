Public Class Group
    Inherits CommonBase

    Private _idGrp As Integer?
    Private _nomGrp As String
    Private _membres As List(Of User)
    Private _notifications As List(Of Notification)


    Public Property notifications() As List(Of Notification)
        Get
            Return _notifications
        End Get
        Set(ByVal value As List(Of Notification))
            _notifications = value
        End Set
    End Property

    Public Property membres() As List(Of User)
        Get
            Return _membres
        End Get
        Set(ByVal value As List(Of User))
            _membres = value
        End Set
    End Property


    Public Property nomGrp() As String
        Get
            Return _nomGrp
        End Get
        Set(ByVal value As String)
            _nomGrp = value
        End Set
    End Property


    Public Property idGrp() As Integer?
        Get
            Return _idGrp
        End Get
        Set(ByVal value As Integer?)
            _idGrp = value
        End Set
    End Property


    Public Sub New()
        _idGrp = Int_NullValue
        _nomGrp = String_NullValue
        _membres = New List(Of User)
        _notifications = New List(Of Notification)
    End Sub

End Class
