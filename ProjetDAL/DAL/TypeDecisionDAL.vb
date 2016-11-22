Imports ProjectDTO

Public Class TypeDecisionDAL

    Dim requete As String = "SELECT * FROM TtypesDecision"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function GetAllTypeDecision() As List(Of TypeDecision)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TtypesDecision")
        Return Utile.TypDecDataSetToList(dSetResultat)
    End Function

    Public Function RechercheTypDecById(ByVal id As Integer) As TypeDecision
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idTyp = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TtypesDecision")
        Dim l = Utile.TypDecDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

End Class
