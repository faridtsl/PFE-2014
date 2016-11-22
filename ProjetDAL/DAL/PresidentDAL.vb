Imports ProjectDTO
Imports System.Data.OleDb

Public Class PresidentDAL

    Dim requete As String = "SELECT * FROM TPresident"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet


    Public Function AjouterPresident(ByVal p As President) As Boolean
        Try
            Dim insertCmd As New OleDb.OleDbCommand()
            Dim champs As String = "(nomPre,prenomPre,telPre,agePre,sexe,idAss)"
            Dim values As String = "(N'" & p.nomPres & "',N'" & p.prePres & "','" & p.telPres & "','" & p.Age & "','" & p.sexe & "','" & p.Ass.ID & "')"
            insertCmd.CommandText = "INSERT INTO TPresident " & champs & " VALUES " & values & ";"
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

    Public Function ModifierPre(ByVal p As President) As Boolean
        Try
            Dim params(5) As OleDbParameter
            params(0) = New OleDbParameter("nomPre", p.nomPres)
            params(1) = New OleDbParameter("telPre", p.telPres)
            params(2) = New OleDbParameter("agePre", p.Age)
            params(3) = New OleDbParameter("sexe", p.sexe)
            params(4) = New OleDbParameter("idAss", p.Ass.ID)
            params(5) = New OleDbParameter("prenomPre", p.prePres)
            Update("TPresident", "idPre", p.Id, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RecherchePreById(ByVal id As Integer) As President
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idPre = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TPresident")
        Dim l = Utile.PreDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RecherchePreByAss(ByVal a As Association) As President
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idAss = '" & a.ID & "';"
        dAdapter.Fill(dSetResultat, "TPresident")
        Dim l = Utile.PreDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function SupprimerPre(ByVal p As President) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand
            deleteCmd.CommandText = "DELETE FROM TPresident WHERE idPre = '" & p.Id & "';"
            deleteCmd.Connection = connex
            If connex.State <> ConnectionState.Open Then
                connex.Open()
            End If
            deleteCmd.ExecuteNonQuery()
            connex.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
