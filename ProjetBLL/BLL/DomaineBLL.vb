Imports ProjectDTO
Imports ProjetDAL

Public Class DomaineBLL

    Public Function GetAllDom() As List(Of Domaine)
        Dim domDal As New DomaineDAL
        Return domDal.GetAllDom()
    End Function

    Public Function RechercheDomById(ByVal id As Integer) As Domaine
        Dim domDal As New DomaineDAL
        Return domDal.RechercheDomById(id)
    End Function

    Public Function RechercheDomByAss(ByVal a As Association) As List(Of Domaine)
        Dim domDal As New DomaineDAL
        Return domDal.RechercheDomByAss(a)
    End Function

End Class
