Public Class Compte
    Inherits CommonBase


    Private _id As Integer?
    Private _login As String
    Private _MDP As String
    Private _estComplet As Boolean?
    Private _ass As Association



    Public Property ID() As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property

    Public Property login() As String
        Get
            Return _login
        End Get
        Set(ByVal value As String)
            _login = value
        End Set
    End Property

    Public Property MDP() As String
        Get
            Return _MDP
        End Get
        Set(ByVal value As String)
            _MDP = value
        End Set
    End Property

    Public Property estComplet() As Boolean?
        Get
            Return _estComplet
        End Get
        Set(ByVal value As Boolean?)
            _estComplet = value
        End Set
    End Property

    Public Property ass() As Association
        Get
            Return _ass
        End Get
        Set(ByVal value As Association)
            _ass = value
        End Set
    End Property



    Public Sub New()
        _id = Int_NullValue
        _ass = Association_NullValue
        _MDP = String_NullValue
        _estComplet = Nothing
        _login = String_NullValue
    End Sub

End Class
