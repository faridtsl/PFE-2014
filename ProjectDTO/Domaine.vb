Public Class Domaine
    Inherits CommonBase

    Private _id As Integer?
    Private _nomDom As String

    Public Property ID() As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property


    Public Property nomDom() As String
        Get
            Return _nomDom
        End Get
        Set(ByVal value As String)
            _nomDom = value
        End Set
    End Property

    Public Sub New()
        _id = Int_NullValue
        _nomDom = String_NullValue
    End Sub


End Class