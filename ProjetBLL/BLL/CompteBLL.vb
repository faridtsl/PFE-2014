Imports ProjectDTO
Imports ProjetDAL
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class CompteBLL
    Inherits Utile

    Private Function verifierCom(ByVal c As Compte) As Boolean
        Return verifierAsso(c.ass) And verifierString(c.login) And verifierString(c.MDP)
    End Function

    Private Function estComplet(ByVal c As Compte) As Boolean
        Return New AssociationBLL().estComplet(c.ass)
    End Function

    Public Function Recuperer(ByVal l As String) As Boolean
        Dim c As Compte = RechercheComByLogin(l)
        If c IsNot Nothing Then
            Return New AssociationBLL().Recuperer(c)
        Else
            Return False
        End If
    End Function

    Friend Shared Function verifierMDP(ByVal mdp As String) As Boolean
        If mdp Is Nothing Then
            Return True
        Else
            Dim s As String = "[a-zA-Z0-9]{6}[a-zA-Z0-9]*"
            Dim regEx As New Regex(s)
            Return regEx.IsMatch(mdp)
        End If
    End Function

    Private Function genererMDP() As String
        Dim letters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim numbers As String = "0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            If i = 3 Or i = 7 Or i = 8 Then
                Dim idx As Integer = r.Next(0, letters.Length - 1)
                sb.Append(letters.Substring(idx, 1))
            Else
                Dim idx As Integer = r.Next(0, 9)
                sb.Append(numbers.Substring(idx, 1))
            End If
        Next
        Return sb.ToString
    End Function

    Friend Function CreerCompte(ByVal a As Association) As Compte
        Dim c As New Compte()
        c.login = a.emailAss
        c.MDP = genererMDP()
        c.ass = a
        c.estComplet = estComplet(c)
        Return c
    End Function

    Public Function Authentifier(ByVal c As Compte) As Boolean
        If verifierMDP(c.MDP) Then
            Dim temp As Compte = RechercheComByLogin(c.login)
            If temp IsNot Nothing Then
                Return Equals(temp.MDP, c.MDP) And Equals(temp.login, c.login)
            End If
        End If
        Return False
    End Function

    Public Function AjouterCompte(ByVal c As Compte) As Boolean
        If c IsNot Nothing And verifierCom(c) Then
            Dim comDal As New CompteDAL
            If comDal.AjouterCompte(c) Then
                Dim aBll As New AssociationBLL
                Dim monThread As Thread = New Thread(New ParameterizedThreadStart(AddressOf aBll.Notifier))
                monThread.Start(c)
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function RechercheComById(ByVal id As Integer) As Compte
        Dim comDal As New CompteDAL
        Return comDal.RechercheComById(id)
    End Function

    Public Function RechercheComByAss(ByVal a As Association) As Compte
        Dim comDal As New CompteDAL
        Return comDal.RechercheComByAss(a)
    End Function

    Public Function RechercheComByLogin(ByVal l As String) As Compte
        Dim comDal As New CompteDAL
        Return comDal.RechercheComByLogin(l)
    End Function

    Public Function ModifierCom(ByVal c As Compte) As Boolean
        If c IsNot Nothing And verifierInt(c.ID) And verifierMDP(c.MDP) Then
            Dim comDal As New CompteDAL
            Return comDal.ModifierCom(c)
        Else
            Return False
        End If
    End Function

    Public Function SupprimerCom(ByVal c As Compte) As Boolean
        If c IsNot Nothing And verifierInt(c.ID) Then
            Dim comDal As New CompteDAL
            Return comDal.SupprimerCom(c)
        Else
            Return False
        End If
    End Function


    Public Function SupprimerComByAss(ByVal a As Association) As Boolean
        If a IsNot Nothing And verifierInt(a.ID) Then
            Dim comDal As New CompteDAL
            Return comDal.SupprimerComByAss(a)
        Else
            Return False
        End If
    End Function



End Class
