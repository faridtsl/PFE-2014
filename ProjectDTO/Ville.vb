Public Class Ville
    Inherits CommonBase

    Private _id As Integer?
    Private _nomVil As String
    Private _reg As Region

    Public Property reg() As Region
        Get
            Return _reg
        End Get
        Set(ByVal value As Region)
            _reg = value
        End Set
    End Property



    Public Property ID() As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property

    Public Property nomVil() As String
        Get
            Return _nomVil
        End Get
        Set(ByVal value As String)
            _nomVil = value
        End Set
    End Property

    Public Sub New()
        _id = Int_NullValue
        _nomVil = String_NullValue
    End Sub


    Public Overrides Function ToString() As String
        Return _nomVil
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim vObj As Ville = TryCast(obj, Ville)
        If vObj Is Nothing Then
            Return False
        Else
            Return ID.Equals(vObj.ID)
        End If
    End Function

End Class
