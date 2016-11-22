Imports ProjectDTO

Public Class VilleDAL

    Dim requete As String = "SELECT * FROM TVille"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet


    Public Function AjouterVille(ByVal v As Ville) As Boolean
        Try
            Dim insertCmd As New OleDb.OleDbCommand()
            Dim champs As String = "(nomVil,idReg)"
            Dim values As String = "(N'" & v.nomVil & "','" & v.reg.ID & "')"
            insertCmd.CommandText = "INSERT INTO TVille " & champs & " VALUES " & values & ";"
            insertCmd.Connection = connex
            If connex.State <> ConnectionState.Open Then
                connex.Open()
            End If
            insertCmd.ExecuteNonQuery()
            connex.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllVille() As List(Of Ville)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TVille")
        Return Utile.VilleDataSetToList(dSetResultat)
    End Function

    Public Function RechercheVilleById(ByVal id As Integer) As Ville
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idVil = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TVille")
        Dim l = Utile.VilleDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheVilleByReg(ByVal r As Region) As List(Of Ville)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idReg = '" & r.ID & "';"
        dAdapter.Fill(dSetResultat, "TVille")
        RechercheVilleByReg = Utile.VilleDataSetToList(dSetResultat)
    End Function

End Class
