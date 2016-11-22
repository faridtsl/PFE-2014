Imports ProjectDTO
Imports ProjetDAL

Public Class UserBLL
    Inherits Utile

    Private Function verifierUser(ByVal u As User) As Boolean
        Return verifierString(u.userName) And verifierString(u.MDP) And verifierInt(u.grp.idGrp)
    End Function

    Public Function Authentifier(ByVal u As User) As Boolean
        Dim temp As User = RechercheUserByName(u.userName)
        If temp IsNot Nothing Then
            Return Equals(temp.userName, u.userName) And Equals(temp.MDP, u.MDP)
        End If
        Return False
    End Function

    Public Function AjouterUser(ByVal u As User) As Boolean
        If verifierUser(u) Then
            Dim uDal As New UserDAL()
            Return uDal.AjouterUser(u)
        Else
            Return False
        End If
    End Function

    Public Function ModifierUser(ByVal u As User) As Boolean
        If verifierInt(u.idUser) Then
            Dim uDal As New UserDAL()
            Return uDal.ModifierUser(u)
        Else
            Return False
        End If
    End Function

    Public Function GetAllUsers() As List(Of User)
        Dim uDal As New UserDAL()
        Return uDal.GetAllUsers()
    End Function

    Public Function RechercheUserById(ByVal id As Integer) As User
        If verifierInt(id) Then
            Dim uDal As New UserDAL()
            Return uDal.RechercheUserById(id)
        Else
            Return Nothing
        End If
    End Function

    Public Function RechercheUserByGrp(ByVal g As Group) As List(Of User)
        If verifierInt(g.idGrp) Then
            Dim uDal As New UserDAL()
            Return uDal.RechercheUserByGrp(g)
        Else
            Return Nothing
        End If
    End Function

    Public Function RechercheUserByName(ByVal n As String) As User
        If verifierString(n) Then
            Dim uDal As New UserDAL()
            Return uDal.RechercheUserByName(n)
        Else
            Return Nothing
        End If
    End Function

    Public Function SupprimerUser(ByVal u As User) As Boolean
        If verifierInt(u.idUser) Then
            Dim uDal As New UserDAL()
            Return uDal.SupprimerUser(u)
        Else
            Return False
        End If
    End Function

End Class
