Imports ProjectDTO
Imports System.Data.OleDb

Public Class CompteDAL

    Dim requete As String = "SELECT * FROM TComptes"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterCompte(ByVal c As Compte) As Boolean
        Try
            Dim insertCmd As New OleDb.OleDbCommand()
            Dim champs As String = "(loginMail,MDP,estComplet,idAss)"
            Dim values As String = "('" & c.login & "','" & c.MDP & "','" & c.estComplet & "','" & c.ass.ID & "')"
            insertCmd.CommandText = "INSERT INTO TComptes " & champs & " VALUES " & values & ";"
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

    Public Function RechercheComById(ByVal id As Integer) As Compte
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idCom = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TComptes")
        Dim l = Utile.CompteDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheComByLogin(ByVal log As String) As Compte
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE loginMail = '" & log & "';"
        dAdapter.Fill(dSetResultat, "TComptes")
        Dim l = Utile.CompteDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheComByAss(ByVal a As Association) As Compte
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idAss = '" & a.ID & "';"
        dAdapter.Fill(dSetResultat, "TComptes")
        Dim l = Utile.CompteDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function ModifierCom(ByVal c As Compte) As Boolean
        Try
            Dim params(3) As OleDbParameter
            params(0) = New OleDbParameter("loginMail", c.login)
            params(1) = New OleDbParameter("MDP", c.MDP)
            params(2) = New OleDbParameter("estComplet", c.estComplet)
            params(3) = New OleDbParameter("idAss", c.ass.ID)
            Update("TComptes", "idCom", c.ID, params)
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Public Function SupprimerCom(ByVal c As Compte) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TComptes WHERE idCom = '" & c.ID & "';"
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

    Public Function SupprimerComByAss(ByVal a As Association) As Boolean
        SupprimerComByAss = SupprimerCom(RechercheComByAss(a))
    End Function

End Class
