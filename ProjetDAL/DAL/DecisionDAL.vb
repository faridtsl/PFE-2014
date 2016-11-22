Imports ProjectDTO
Imports System.Data.OleDb

Public Class DecisionDAL

    Dim requete As String = "SELECT * FROM TDecision"
    Dim dAdapter As New OleDb.OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterDecision(ByVal d As Decision) As Boolean
        Try
            Dim insertCmd As New OleDb.OleDbCommand()
            Dim champs As String = "(idCor,idTyp,infoSuppDec,commentaire,datDec,estApp)"
            Dim values As String = "('" & d.Cor.idCor & "','" & d.type.id & "',N'" & d.infDec & "',N'" & d.commentaire & "','" & d.datDec.Value.ToString("yyyy-MM-dd") & "','" & d.estApp & "')"
            insertCmd.CommandText = "INSERT INTO TDecision " & champs & " VALUES " & values & ";"
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

    Public Function RechercheDecByCor(ByVal c As Correspondance) As Decision
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idCor = '" & c.idCor & "';"
        dAdapter.Fill(dSetResultat, "TDecision")
        Dim l = Utile.DecDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function RechercheDecById(ByVal id As Integer) As Decision
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idDec = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TDecision")
        Dim l = Utile.DecDataSetToList(dSetResultat)
        If l.Count = 0 Then
            Return Nothing
        Else
            Return l.Item(0)
        End If
    End Function

    Public Function ModifierDecision(ByVal d As Decision) As Boolean
        Try
            Dim params(5) As OleDbParameter
            params(0) = New OleDbParameter("idCor", d.Cor.idCor)
            params(1) = New OleDbParameter("idTyp", d.type.id)
            params(2) = New OleDbParameter("infoSuppDec", d.infDec)
            params(3) = New OleDbParameter("commentaire", d.commentaire)
            params(4) = New OleDbParameter("datDec", d.datDec)
            params(5) = New OleDbParameter("estApp", d.estApp)
            Update("TDecision", "idDec", d.idDec, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function SupprimerDecision(ByVal d As Decision) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand
            deleteCmd.CommandText = "DELETE FROM TDecision WHERE idDec = '" & d.idDec & "';"
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

    Public Function SupprimerDecByCor(ByVal c As Correspondance) As Boolean
        Return SupprimerDecision(RechercheDecByCor(c))
    End Function

End Class
