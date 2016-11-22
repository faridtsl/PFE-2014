Imports ProjectDTO
Imports ProjetDAL
Imports System.IO
Imports System.Threading

Public Class PostaleBLL
    Inherits CorrespondanceBLL

    Private Function verifierPos(ByVal p As Postale) As Boolean
        Return p IsNot Nothing And verifierString(p.NBO) And VerifierCor(p)
    End Function

    Public Function GetAllPos() As List(Of Postale)
        Dim posDal As New PostaleDAL
        Return posDal.GetAllPostale()
    End Function

    Public Function RecherchePosByAss(ByVal a As Association) As List(Of Postale)
        If verifierAsso(a) And verifierInt(a.ID) Then
            Dim posDal As New PostaleDAL
            Return posDal.RecherchePosByAss(a)
        Else
            Return New List(Of Postale)
        End If
    End Function

    Public Function RecherchePosByNBO(ByVal nbo As String) As Postale
        If verifierString(nbo) Then
            Dim posDal As New PostaleDAL
            Return posDal.RecherchePosByNBO(nbo)
        Else
            Return Nothing
        End If
    End Function


    Public Function AjouterPos(ByVal p As Postale) As Boolean
        If verifierPos(p) Then
            Dim corDal As New CorrespondanceDAL
            If corDal.AjouterCor(p) Then
                Dim aBll As New AssociationBLL
                Dim monThread As Thread = New Thread(New ParameterizedThreadStart(AddressOf aBll.EnvoyerAcc))
                monThread.Start(p)
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function SupprimerPos(ByVal p As Postale) As Boolean
        If verifierInt(p.idCor) Then
            Dim posDal As New PostaleDAL
            Return posDal.SupprimerPos(p)
        Else
            Return False
        End If
    End Function

    ''A TESTER
    ''..............................................
    ''..............................................
    ''..............................................
    ''..............................................
    ''..............................................
    ' Private Function scanCor(ByVal p As Postale) As String
    'Dim fName As String
    '   If p.cheminPDF Is Nothing Then
    '      fName = p.NBO & "p.jpg"
    ' Else
    '    fName = p.NBO & "s.jpg"
    '    End If
    'Dim ls = TwainLib.ScanImages()
    'Dim f = New FileInfo(ls.Item(0))
    'Dim r = f.CopyTo("ServerPath/" & fName, True)
    '    f.Delete()
    '    Return r.FullName
    'End Function

    'Public Function addChemin(ByVal p As Postale) As Postale
    '    If p.cheminPDF Is Nothing Then
    '        p.cheminPDF = scanCor(p)
    '    Else
    '        p.imgSupp = scanCor(p)
    '    End If
    '    Return p
    'End Function
    ''..............................................
    ''..............................................
    ''..............................................
    ''..............................................
    ''..............................................
    ''..............................................


End Class
