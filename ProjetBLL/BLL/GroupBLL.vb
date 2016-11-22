Imports ProjectDTO
Imports ProjetDAL

Public Class GroupBLL

    Public Function GetAllGroup() As List(Of Group)
        Dim gDal As New GroupDAL
        Return gDal.GetAllGroup()
    End Function

    Public Function RechercheGrpById(ByVal id As Integer) As Group
        Dim gDal As New GroupDAL
        Return gDal.RechercheGrpById(id)
    End Function

    Public Function GetServices() As List(Of Group)
        Dim gDal As New GroupDAL
        Return gDal.GetServices()
    End Function

End Class
