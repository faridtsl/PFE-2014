Imports ProjectDTO
Imports ProjetDAL
Imports System.Threading

Public Class EmailBLL
    Inherits CorrespondanceBLL

    Private Function verifierEmail(ByVal e As Email) As Boolean
        Return e IsNot Nothing And VerifierCor(e) And e.textMail.Length < 2000
    End Function

    Public Function GetAllMail() As List(Of Email)
        Dim mailDal As New EmailDAL
        Return mailDal.GetAllMail()
    End Function

    Public Function RechercheMailByAss(ByVal a As Association) As List(Of Email)
        If verifierAsso(a) And verifierInt(a.ID) Then
            Dim mailDal As New EmailDAL
            Return mailDal.RechercheMailByAss(a)
        Else
            Return New List(Of Email)
        End If
    End Function

    Public Function AjouterMail(ByVal e As Email) As Boolean
        If verifierEmail(e) Then
            Dim corDal As New CorrespondanceDAL
            If corDal.AjouterCor(e) Then
                Dim aBll As New AssociationBLL
                Dim monThread As Thread = New Thread(New ParameterizedThreadStart(AddressOf aBll.EnvoyerAcc))
                monThread.Start(e)
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function SupprimerMail(ByVal e As Email) As Boolean
        If verifierInt(e.idCor) Then
            Dim mailDal As New EmailDAL
            Return mailDal.SupprimerMail(e)
        Else
            Return False
        End If
    End Function


End Class
