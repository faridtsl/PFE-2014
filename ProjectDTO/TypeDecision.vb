Public Class TypeDecision
    Inherits CommonBase

    Private _id As Integer?
    Private _libTyp As String


    Public Property id() As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property

    Public Property libTyp() As String
        Get
            Return _libTyp
        End Get
        Set(ByVal value As String)
            _libTyp = value
        End Set
    End Property

    Public Sub New()
        _id = Int_NullValue
        _libTyp = String_NullValue
    End Sub

End Class
