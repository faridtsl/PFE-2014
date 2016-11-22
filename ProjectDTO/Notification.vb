Public Class Notification
    Inherits CommonBase

    Private _idNot As Integer?
    Private _info As String
    Private _etat As String
    Private _datNot As Date?
    Private _sender As User
    Private _reciver As Group
    Private _cor As Correspondance


    Public Property cor() As Correspondance
        Get
            Return _cor
        End Get
        Set(ByVal value As Correspondance)
            _cor = value
        End Set
    End Property



    Public Property destinataire() As Group
        Get
            Return _reciver
        End Get
        Set(ByVal value As Group)
            _reciver = value
        End Set
    End Property

    Public Property emetteur() As User
        Get
            Return _sender
        End Get
        Set(ByVal value As User)
            _sender = value
        End Set
    End Property

    Public Property datNot() As Date?
        Get
            Return _datNot
        End Get
        Set(ByVal value As Date?)
            _datNot = value
        End Set
    End Property

    Public Property etat() As String
        Get
            Return _etat
        End Get
        Set(ByVal value As String)
            _etat = value
        End Set
    End Property

    Public Property info() As String
        Get
            Return _info
        End Get
        Set(ByVal value As String)
            _info = value
        End Set
    End Property

    Public Property idNot() As Integer?
        Get
            Return _idNot
        End Get
        Set(ByVal value As Integer?)
            _idNot = value
        End Set
    End Property

    Public Sub New()
        _idNot = Int_NullValue
        _datNot = DateTime_NullValue
        _etat = String_NullValue
        _info = String_NullValue
        _reciver = Nothing
        _sender = Nothing
    End Sub


End Class
