Imports ProjectDTO
Imports ProjetDAL

Public Class NotificationBLL
    Inherits Utile

    Private Function verifierNotification(ByVal n As Notification) As Boolean
        Return verifierString(n.etat) And n.emetteur IsNot Nothing And n.destinataire IsNot Nothing And verifierCorr(n.cor)
    End Function

    Public Function AjouterNotification(ByVal n As Notification) As Boolean
        If verifierNotification(n) Then
            Dim nDal As New NotificationDAL()
            n.cor.idCor = CorrespondanceDAL.GetLastId()
            Return nDal.AjouterNotification(n)
        Else
            Return False
        End If
    End Function

    Public Function ModifierNotification(ByVal n As Notification) As Boolean
        If n IsNot Nothing And verifierInt(n.idNot) Then
            Dim nDal As New NotificationDAL()
            Return nDal.ModifierNotification(n)
        Else
            Return False
        End If
    End Function

    Public Function RechercheNotByGrp(ByVal g As Group) As List(Of Notification)
        If verifierInt(g.idGrp) Then
            Dim nDal As New NotificationDAL()
            Return nDal.RechercheNotByGrp(g)
        Else
            Return Nothing
        End If
    End Function

    Public Function RechercheNotBySender(ByVal s As User) As List(Of Notification)
        If verifierInt(s.idUser) Then
            Dim nDal As New NotificationDAL()
            Return nDal.RechercheNotBySender(s)
        Else
            Return Nothing
        End If
    End Function

    Public Function SupprimerNotification(ByVal n As Notification) As Boolean
        If verifierInt(n.idNot) Then
            Dim nDal As New NotificationDAL()
            Return nDal.SupprimerNotification(n)
        Else
            Return False
        End If
    End Function

    Public Function SupprimerOldNot() As Boolean
        Dim nDal As New NotificationDAL()
        Return nDal.SupprimerOldNot()
    End Function

End Class
