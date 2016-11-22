Imports ProjectDTO
Imports System.Data.OleDb

Public Class NotificationDAL

    Dim requete As String = "SELECT * FROM TNotifications"
    Dim dAdapter As New OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterNotification(ByVal n As Notification) As Boolean
        Try
            Dim insertCmd As New OleDb.OleDbCommand()
            Dim champs As String = "(info,datNot,etat,idCor,idEmetteur,idRec)"
            Dim values As String = "(N'" & n.info & "','" & n.datNot.Value.ToString("yyyyMMdd") & "','" & n.etat & "','" & n.cor.idCor & "','" & n.emetteur.idUser & "','" & n.destinataire.idGrp & "')"
            insertCmd.CommandText = "INSERT INTO TNotifications " & champs & " VALUES " & values & ";"
            insertCmd.Connection = connex
            If connex.State <> ConnectionState.Open Then
                connex.Open()
            End If
            insertCmd.ExecuteNonQuery()
            connex.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function

    Public Function ModifierNotification(ByVal n As Notification) As Boolean
        Try
            Dim params(5) As OleDbParameter
            params(0) = New OleDbParameter("info", n.info)
            params(1) = New OleDbParameter("datNot", n.datNot)
            params(2) = New OleDbParameter("etat", n.etat)
            params(3) = New OleDbParameter("idCor", n.cor.idCor)
            params(4) = New OleDbParameter("idEmetteur", n.emetteur.idUser)
            params(5) = New OleDbParameter("idRec", n.destinataire.idGrp)
            Update("TNotifications", "idNot", n.idNot, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RechercheNotByGrp(ByVal g As Group) As List(Of Notification)
        Try
            dSetResultat.Clear()
            dAdapter.SelectCommand.CommandText = requete & " WHERE idRec = '" & g.idGrp & "' ORDER BY datNot DESC ;"
            dAdapter.Fill(dSetResultat, "TNotifications")
            Return Utile.NotDataSetToList(dSetResultat)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return New List(Of Notification)
        End Try
    End Function

    Public Function RechercheNotBySender(ByVal s As User) As List(Of Notification)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = requete & " WHERE idEmetteur = '" & s.idUser & "';"
        dAdapter.Fill(dSetResultat, "TNotifications")
        Return Utile.NotDataSetToList(dSetResultat)
    End Function

    Public Function SupprimerNotification(ByVal n As Notification) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TNotifications WHERE idNot = '" & n.idNot & "';"
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

    Public Function SupprimerOldNot() As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TNotifications WHERE etat = 'LU';"
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
