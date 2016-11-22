Imports ProjectDTO
Imports System.Data.OleDb

Public Class AssociationDAL

    Dim requete As String = "SELECT * FROM TAssociation"
    Dim dAdapter As New OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    '''Insertion
    Public Function AjouterAss(ByVal a As Association) As Boolean
        Try
            Dim insertCmd As New OleDbCommand
            Dim champs As String = "(nomAss,datCreaAss,adrAss,telAss,emailAss,idVil,siteAss)"
            Dim values As String = "(N'" & a.nomAss & "','" & a.datCrea & "',N'" & a.adrAss & "','" & a.telAss & "','" & a.emailAss & "','" & a.ville.ID & "','" & a.site & "')"
            insertCmd.CommandText = "INSERT INTO TAssociation " & champs & " VALUES " & values & ";"
            insertCmd.Connection = connex
            If connex.State <> ConnectionState.Open Then
                connex.Open()
            End If
            insertCmd.ExecuteNonQuery()
            connex.Close()
            If a.doms IsNot Nothing Then
                Return ajouterDomAss(a, getLastId())
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Private Function ajouterDomAss(ByVal a As Association, ByVal i As String) As Boolean
        ajouterDomAss = True
        For Each d As Domaine In a.doms
            ajouterDomAss = ajouterDomAss And insertDomAss(i, d.ID.Value)
        Next
    End Function

    Private Function insertDomAss(ByVal iAss As Integer, ByVal iDom As Integer) As Boolean
        Try
            Dim insertCmd As New OleDbCommand
            Dim champs As String = "(idAss,idDom)"
            Dim values As String = "('" & iAss & "','" & iDom & "')"
            insertCmd.CommandText = "INSERT INTO TAssDom " & champs & " VALUES " & values & ";"
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

    Public Function getLastId() As Integer
        Dim cmd As New OleDbCommand
        cmd.CommandText = "SELECT MAX(idAss) FROM TAssociation"
        cmd.Connection = connex
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        getLastId = cmd.ExecuteScalar
        connex.Close()
    End Function

    '''Mise à jour
    Public Function ModifierAss(ByVal a As Association) As Boolean
        Try
            Dim params(6) As OleDbParameter
            params(0) = New OleDbParameter("nomAss", a.nomAss)
            params(1) = New OleDbParameter("datCreaAss", a.datCrea)
            params(2) = New OleDbParameter("adrAss", a.adrAss)
            params(3) = New OleDbParameter("telAss", a.telAss)
            params(4) = New OleDbParameter("emailAss", a.emailAss)
            params(5) = New OleDbParameter("idVil", a.ville.ID)
            params(6) = New OleDbParameter("siteAss", a.site)
            Update("TAssociation", "idAss", a.ID, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '''Recherche
    Public Function GetAllAss() As List(Of Association)
        dSetResultat.Clear()
        dAdapter.Fill(dSetResultat, "TAssociation")
        GetAllAss = Utile.AssDataSetToList(dSetResultat)
    End Function

    Public Function RechercheAssById(ByVal id As String) As Association
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idAss = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TAssociation")
        Dim l = Utile.AssDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheAssByTel(ByVal tel As String) As Association
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE telAss = '" & tel & "';"
        dAdapter.Fill(dSetResultat, "TAssociation")
        Dim l = Utile.AssDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheAssByEmail(ByVal email As String) As Association
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE emailAss = '" & email & "';"
        dAdapter.Fill(dSetResultat, "TAssociation")
        Dim l = Utile.AssDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheAssByDom(ByVal d As Domaine) As List(Of Association)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idAss IN (SELECT idAss FROM TAssDom WHERE idDom = '" & d.ID & "');"
        dAdapter.Fill(dSetResultat, "TAssociation")
        Return Utile.AssDataSetToList(dSetResultat)
    End Function

    Public Function RechercheAssByVil(ByVal v As Ville) As List(Of Association)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idVil = '" & v.ID & "';"
        dAdapter.Fill(dSetResultat, "TAssociation")
        RechercheAssByVil = (Utile.AssDataSetToList(dSetResultat))
    End Function

    Public Function RechercheAssByReg(ByVal r As Region) As List(Of Association)
        RechercheAssByReg = New List(Of Association)
        Dim vDAL As New VilleDAL
        Dim villes As List(Of Ville) = vDAL.RechercheVilleByReg(r)
        For Each v In villes
            RechercheAssByReg.AddRange(RechercheAssByVil(v))
        Next
    End Function

    Public Function RechercheAssByNom(ByVal n As String) As List(Of Association)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE nomAss LIKE N'%" & n & "%' ;"
        dAdapter.Fill(dSetResultat, "TAssociation")
        Return Utile.AssDataSetToList(dSetResultat)
    End Function

    '''Suppression
    Public Function SupprimerAss(ByVal a As Association) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TAssociation WHERE idAss = '" & a.ID & "';"
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
