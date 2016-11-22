Public Class Postale
    Inherits Correspondance


    Private _NBO As String
    Private _cheminPDF As String
    Private _imgSupp As String

    Public Property imgSupp() As String
        Get
            Return _imgSupp
        End Get
        Set(ByVal value As String)
            _imgSupp = value
        End Set
    End Property
    
    Public Property NBO() As String
        Get
            Return _NBO
        End Get
        Set(ByVal value As String)
            _NBO = value
        End Set
    End Property


    
    Public Property cheminPDF() As String
        Get
            Return _cheminPDF
        End Get
        Set(ByVal value As String)
            _cheminPDF = value
        End Set
    End Property

    Public Sub New()
        dec = Decision_NullValue
        etat = String_NullValue
        datRec = DateTime_NullValue
        datEnv = DateTime_NullValue
        objet = String_NullValue
        idCor = Int_NullValue
        estPos = True
        _NBO = String_NullValue
        _cheminPDF = String_NullValue
    End Sub

    Public Sub New(ByVal c As Correspondance)
        dec = c.dec
        etat = c.etat
        datRec = c.datRec
        datEnv = c.datEnv
        objet = c.objet
        idCor = c.idCor
        ass = c.ass
        estPos = True
        _NBO = String_NullValue
        _cheminPDF = String_NullValue
    End Sub

End Class
