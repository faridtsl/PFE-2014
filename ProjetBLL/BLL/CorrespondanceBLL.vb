Imports ProjectDTO
Imports ProjetDAL

Public Class CorrespondanceBLL
    Inherits Utile

    Friend Function VerifierCor(ByVal c As Correspondance) As Boolean
        Return verifierString(c.objet) And verifierDat(c.datEnv) And verifierAsso(c.ass)
    End Function

    Public Function ModifierCor(ByVal c As Correspondance) As Boolean
        If (verifierCorr(c)) Then
            Dim corDal As New CorrespondanceDAL
            Return corDal.ModifierCor(c)
        Else
            Return False
        End If
    End Function

    Public Function RechercheCorById(ByVal id As Integer) As Correspondance
        Dim corDal As New CorrespondanceDAL
        Return corDal.RechercheCorById(id)
    End Function


End Class
