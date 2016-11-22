Imports ProjectDTO
Imports System.Data.OleDb

Public Class UserDAL

    Dim requete As String = "SELECT * FROM TUsers"
    Dim dAdapter As New OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterUser(ByVal u As User) As Boolean
        Try
            Dim insertCmd As New OleDb.OleDbCommand()
            Dim champs As String = "(userName,MDP,idGrp)"
            Dim values As String = "('" & u.userName & "','" & u.MDP & "','" & u.grp.idGrp & "')"
            insertCmd.CommandText = "INSERT INTO TUsers " & champs & " VALUES " & values & ";"
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

    Public Function ModifierUser(ByVal u As User) As Boolean
        Try
            Dim params(2) As OleDbParameter
            params(0) = New OleDbParameter("userName", u.userName)
            params(1) = New OleDbParameter("MDP", u.MDP)
            params(2) = New OleDbParameter("idGrp", u.grp.idGrp)
            Update("TUsers", "idUser", u.idUser, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllUsers() As List(Of User)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TUsers")
        Return Utile.UserDataSetToList(dSetResultat)
    End Function

    Public Function RechercheUserById(ByVal id As Integer) As User
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idGrp = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TUsers")
        Dim l = Utile.UserDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheUserByGrp(ByVal grp As Group) As List(Of User)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idGrp = '" & grp.idGrp & "';"
        dAdapter.Fill(dSetResultat, "TUsers")
        Return Utile.UserDataSetToList(dSetResultat)
    End Function

    Public Function RechercheUserByName(ByVal n As String) As User
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE userName = '" & n & "';"
        dAdapter.Fill(dSetResultat, "TUsers")
        Dim l = Utile.UserDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function SupprimerUser(ByVal u As User) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TUsers WHERE idUser = '" & u.idUser & "';"
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
