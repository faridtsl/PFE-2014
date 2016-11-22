Public Class Region
    Inherits CommonBase

    Private _id As Integer?
    Private _nomReg As String
    Private _villes As List(Of Ville)

    Public Property ID() As Integer?
        Get
            Return _id
        End Get
        Set(ByVal value As Integer?)
            _id = value
        End Set
    End Property


    Public Property nomReg() As String
        Get
            Return _nomReg
        End Get
        Set(ByVal value As String)
            _nomReg = value
        End Set
    End Property

    Public Property villes() As List(Of Ville)
        Get
            Return _villes
        End Get
        Set(ByVal value As List(Of Ville))
            _villes = value
        End Set
    End Property

    Public Sub New()
        _id = Int_NullValue
        _nomReg = String_NullValue
        _villes = Nothing
    End Sub

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim rObj As Region = TryCast(obj, Region)
        If rObj Is Nothing Then
            Return False
        Else
            Return ID.Equals(rObj.ID)
        End If
    End Function

End Class
