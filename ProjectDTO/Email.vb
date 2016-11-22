Public Class Email
    Inherits Correspondance



    Private _textMail As String



    Public Property textMail() As String
        Get
            Return _textMail
        End Get
        Set(ByVal value As String)
            _textMail = value
        End Set
    End Property


    Public Sub New()
        dec = Decision_NullValue
        etat = String_NullValue
        datRec = DateTime_NullValue
        datEnv = DateTime_NullValue
        objet = String_NullValue
        idCor = Int_NullValue
        _textMail = String_NullValue
        ass = Association_NullValue
        estPos = False
    End Sub

    Public Sub New(ByVal c As Correspondance)
        dec = c.dec
        etat = c.etat
        datRec = c.datRec
        datEnv = c.datEnv
        objet = c.objet
        idCor = c.idCor
        ass = c.ass
        estPos = False
        _textMail = String_NullValue
    End Sub


End Class
