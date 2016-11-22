Imports ProjectDTO

Public Class DomaineDAL

    Dim requete As String = "SELECT * FROM TDomaine"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet


    Public Function GetAllDom() As List(Of Domaine)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TDomaine")
        Return Utile.DomaineDataSetToList(dSetResultat)
    End Function

    Public Function RechercheDomById(ByVal id As Integer) As Domaine
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idDom = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TDomaine")
        Dim l = Utile.DomaineDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheDomByAss(ByVal a As Association) As List(Of Domaine)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idDom IN ( SELECT idDom FROM TAssDom WHERE idAss = '" & a.ID & "' );"
        dAdapter.Fill(dSetResultat, "TDomaine")
        Return Utile.DomaineDataSetToList(dSetResultat)
    End Function

End Class
