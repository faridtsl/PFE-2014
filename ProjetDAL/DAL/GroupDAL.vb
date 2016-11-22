Imports ProjectDTO

Public Class GroupDAL

    Dim requete As String = "SELECT * FROM TGroups"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet


    Public Function GetAllGroup() As List(Of Group)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TGroups")
        Return Utile.GrpDataSetToList(dSetResultat)
    End Function

    Public Function GetServices() As List(Of Group)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE nomGrp LIKE N'%مصلحة%';"
        dAdapter.Fill(dSetResultat, "TGroups")
        Return Utile.GrpDataSetToList(dSetResultat)
    End Function

    Public Function RechercheGrpById(ByVal id As Integer) As Group
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idGrp = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TGroups")
        Dim l = Utile.GrpDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

End Class
