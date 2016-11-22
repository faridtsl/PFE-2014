Public Class Decision
    Inherits CommonBase

    Private _idDec As Integer?
    Private _estApp As Boolean?
    Private _type As TypeDecision
    Private _infDec As String
    Private _commentaire As String
    Private _datDec As Date?
    Private _Cor As Correspondance

    Public Property Cor As Correspondance
        Get
            Return _Cor
        End Get
        Set(ByVal value As Correspondance)
            _Cor = value
        End Set
    End Property

    Public Property idDec() As Integer?
        Get
            Return _idDec
        End Get
        Set(ByVal value As Integer?)
            _idDec = value
        End Set
    End Property


    Public Property estApp() As Boolean
        Get
            Return _estApp
        End Get
        Set(ByVal value As Boolean)
            _estApp = value
        End Set
    End Property


    Public Property type() As TypeDecision
        Get
            Return _type
        End Get
        Set(ByVal value As TypeDecision)
            _type = value
        End Set
    End Property


    Public Property infDec() As String
        Get
            Return _infDec
        End Get
        Set(ByVal value As String)
            _infDec = value
        End Set
    End Property


    Public Property commentaire() As String
        Get
            Return _commentaire
        End Get
        Set(ByVal value As String)
            _commentaire = value
        End Set
    End Property


    Public Property datDec() As Date?
        Get
            Return _datDec
        End Get
        Set(ByVal value As Date?)
            _datDec = value
        End Set
    End Property

    Public Sub New()
        _idDec = Int_NullValue
        _estApp = Nothing
        _type = TypeDecision_NullValue
        _infDec = String_NullValue
        _commentaire = String_NullValue
        _datDec = DateTime_NullValue
    End Sub

End Class
