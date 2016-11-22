Imports ProjectDTO
Imports ProjetDAL

Public Class PresidentBLL
    Inherits Utile

    Private Function verifierPre(ByVal p As President) As Boolean
        Return verifierAsso(p.Ass) And verifierChar(p.sexe) And verifierString(p.nomPres) And verifierString(p.prePres)
    End Function

    Public Function AjouterPresident(ByVal p As President) As Boolean
        If (verifierPre(p)) Then
            Dim preDal As New PresidentDAL
            Return preDal.AjouterPresident(p)
        Else
            Return False
        End If
    End Function

    Public Function ModifierPre(ByVal p As President) As Boolean
        If (verifierPres(p) And verifierInt(p.Id) And verifierPre(p)) Then
            Dim preDal As New PresidentDAL
            Return preDal.ModifierPre(p)
        Else
            Return False
        End If
    End Function

    Public Function SupprimerPre(ByVal p As President) As Boolean
        If (verifierInt(p.Id)) Then
            Dim preDal As New PresidentDAL
            Return preDal.SupprimerPre(p)
        Else
            Return False
        End If
    End Function

    Public Function RecherchePreById(ByVal id As Integer) As President
        Dim preDal As New PresidentDAL
        Return preDal.RecherchePreById(id)
    End Function

    Public Function RecherchePreByAss(ByVal a As Association) As President
        Dim preDal As New PresidentDAL
        Return preDal.RecherchePreByAss(a)
    End Function




End Class
