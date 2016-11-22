Public Class User
    Inherits CommonBase

    Private _idUser As Integer?
    Private _userName As String
    Private _mdp As String
    Private _grp As Group
    Private _notSent As List(Of Notification)


    Public Property sent() As List(Of Notification)
        Get
            Return _notSent
        End Get
        Set(ByVal value As List(Of Notification))
            _notSent = value
        End Set
    End Property

    Public Property grp() As Group
        Get
            Return _grp
        End Get
        Set(ByVal value As Group)
            _grp = value
        End Set
    End Property

    Public Property MDP() As String
        Get
            Return _mdp
        End Get
        Set(ByVal value As String)
            _mdp = value
        End Set
    End Property

    Public Property userName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property

    Public Property idUser() As Integer?
        Get
            Return _idUser
        End Get
        Set(ByVal value As Integer?)
            _idUser = value
        End Set
    End Property

    Public Sub New()
        _idUser = Int_NullValue
        _userName = String_NullValue
        _mdp = String_NullValue
        _grp = Nothing
        _notSent = Nothing
    End Sub

End Class
