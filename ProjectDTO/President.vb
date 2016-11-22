Public Class President
    Inherits CommonBase

    Private _id As Integer?
    Private _nomPres As String
    Private _prenomPres As String
    Private _sexe As Char
    Private _telPres As String
    Private _age As Integer?
    Private _ass As Association

    Public Overrides Function ToString() As String
        Return _nomPres
    End Function

    Public Property prePres() As String
        Get
            Return _prenomPres
        End Get
        Set(ByVal value As String)
            _prenomPres = value
        End Set
    End Property

    Public Property Ass() As Association
        Get
            Return _ass
        End Get
        Set(ByVal value As Association)
            _ass = value
        End Set
    End Property



    Public Property Age() As Integer?
        Get
            Return _age
        End Get
        Set(ByVal value As Integer?)
            _age = value
        End Set
    End Property



    Public Property Id As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property

    Public Property nomPres() As String
        Get
            Return _nomPres
        End Get
        Set(ByVal value As String)
            _nomPres = value
        End Set
    End Property

    Public Property sexe() As Char
        Get
            Return _sexe
        End Get
        Set(ByVal value As Char)
            _sexe = value
        End Set
    End Property


    Public Property telPres() As String
        Get
            Return _telPres
        End Get
        Set(ByVal value As String)
            _telPres = value
        End Set
    End Property

    Public Sub New()
        _id = Int_NullValue
        _nomPres = String_NullValue
        _age = Int_NullValue
        _sexe = Char_NullValue
        _telPres = String_NullValue
    End Sub

End Class
