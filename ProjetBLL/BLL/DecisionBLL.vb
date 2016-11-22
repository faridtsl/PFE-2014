Imports ProjectDTO
Imports ProjetDAL
Imports System.Threading

Public Class DecisionBLL
    Inherits Utile

    Private Function verifierDec(ByVal d As Decision) As Boolean
        Return verifierType(d.type) And verifierInt(d.Cor.idCor) And verifierDat(d.datDec) And verifierCorr(d.Cor)
    End Function

    Public Function AjouterDecision(ByVal d As Decision) As Boolean
        If (verifierDec(d)) Then
            Dim decDal As New DecisionDAL
            If decDal.AjouterDecision(d) Then
                Dim aBll As New AssociationBLL
                Dim monThread As Thread = New Thread(New ParameterizedThreadStart(AddressOf aBll.NotifierDecision))
                monThread.Start(d)
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function ModifierDecision(ByVal d As Decision) As Boolean
        If (verifierDeci(d) And verifierInt(d.idDec)) Then
            Dim decDal As New DecisionDAL
            Return decDal.ModifierDecision(d)
        Else
            Return False
        End If
    End Function

    Public Function SupprimerDecision(ByVal d As Decision) As Boolean
        If (verifierDeci(d) And verifierInt(d.idDec)) Then
            Dim decDal As New DecisionDAL
            Return decDal.SupprimerDecision(d)
        Else
            Return False
        End If
    End Function

    Public Function SupprimerDecByCor(ByVal c As Correspondance) As Boolean
        If (verifierCorr(c) And verifierInt(c.idCor)) Then
            Dim decDal As New DecisionDAL
            Return decDal.SupprimerDecByCor(c)
        Else
            Return False
        End If
    End Function


    Public Function RechercheDecById(ByVal id As Integer) As Decision
        Dim decDal As New DecisionDAL
        Return decDal.RechercheDecById(id)
    End Function

    Public Function RechercheDecByCor(ByVal c As Correspondance) As Decision
        If (verifierCorr(c) And verifierInt(c.idCor)) Then
            Dim decDal As New DecisionDAL
            Return decDal.RechercheDecByCor(c)
        Else
            Return Nothing
        End If
    End Function

End Class
