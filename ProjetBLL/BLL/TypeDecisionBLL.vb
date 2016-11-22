Imports ProjectDTO
Imports ProjetDAL

Public Class TypeDecisionBLL

    Public Function GetAllTypDec() As List(Of TypeDecision)
        Dim typDal As New TypeDecisionDAL
        Return typDal.GetAllTypeDecision()
    End Function

    Public Function RechercheTypDecById(ByVal id As Integer) As TypeDecision
        Dim typDal As New TypeDecisionDAL
        Return typDal.RechercheTypDecById(id)
    End Function

End Class
