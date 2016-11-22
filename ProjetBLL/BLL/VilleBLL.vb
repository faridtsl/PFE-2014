Imports ProjectDTO
Imports ProjetDAL

Public Class VilleBLL

    Public Function GetAllVille() As List(Of Ville)
        Dim vilDal As New VilleDAL
        Return vilDal.GetAllVille()
    End Function

    Public Function RechercheVilleById(ByVal id As Integer) As Ville
        Dim vilDal As New VilleDAL
        Return vilDal.RechercheVilleById(id)
    End Function

    Public Function RechercheVilleByReg(ByVal r As Region) As List(Of Ville)
        Dim vilDal As New VilleDAL
        Return vilDal.RechercheVilleByReg(r)
    End Function

    Public Function AjouterVille(ByVal v As Ville) As Boolean
        Return New VilleDAL().AjouterVille(v)
    End Function

End Class
