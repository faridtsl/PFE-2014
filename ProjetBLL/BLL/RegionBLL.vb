Imports ProjectDTO
Imports ProjetDAL

Public Class RegionBLL

    Public Function GetAllReg() As List(Of Region)
        Dim regDal As New RegionDAL
        Return regDal.GetAllReg()
    End Function

    Public Function RechercheRegById(ByVal id As Integer) As Region
        Dim regDal As New RegionDAL
        Return regDal.RechercheRegById(id)
    End Function

End Class
