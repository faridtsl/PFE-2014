Imports ProjectDTO

Public Class RegionDAL

    Dim requete As String = "SELECT * FROM TRegion"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function GetAllReg() As List(Of Region)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TRegion")
        Return Utile.RegionDataSetToList(dSetResultat)
    End Function

    Public Function RechercheRegById(ByVal id As Integer) As Region
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idReg = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TRegion")
        Dim l = Utile.RegionDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function


End Class
