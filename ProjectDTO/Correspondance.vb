Public Class Correspondance
    Inherits CommonBase

    Private _dec As Decision
    Private _etat As String
    Private _datRec As Date?
    Private _datEnv As Date?
    Private _objet As String
    Private _idCor As Integer?
    Private _ass As Association
    Private _estPos As Boolean?

    Public Property estPos() As Boolean?
        Get
            Return _estPos
        End Get
        Set(ByVal value As Boolean?)
            _estPos = value
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


    Public Property idCor() As Integer?
        Get
            Return _idCor
        End Get
        Set(ByVal value As Integer?)
            _idCor = value
        End Set
    End Property


    Public Property objet() As String
        Get
            Return _objet
        End Get
        Set(ByVal value As String)
            _objet = value
        End Set
    End Property


    Public Property datEnv() As Date?
        Get
            Return _datEnv
        End Get
        Set(ByVal value As Date?)
            _datEnv = value
        End Set
    End Property


    Public Property datRec() As Date?
        Get
            Return _datRec
        End Get
        Set(ByVal value As Date?)
            _datRec = value
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


    Public Property dec() As Decision
        Get
            Return _dec
        End Get
        Set(ByVal value As Decision)
            _dec = value
        End Set
    End Property






End Class
