Imports ProjectDTO
Imports System.Data.OleDb

Public Class EmailDAL

    Dim requete As String = "SELECT * FROM TEmail"
    Dim dAdapter As New OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterEmail(ByVal e As Email, ByVal id As Integer) As Boolean
        Dim insertCmd As New OleDbCommand
        Dim champs As String = "(idMail,textMsg)"
        Dim values As String = "('" & id & "',N'" & e.textMail & "')"
        insertCmd.Connection = connex
        insertCmd.CommandText = "INSERT INTO TEmail " & champs & " VALUES " & values & ";"
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        Try
            insertCmd.ExecuteNonQuery()
            connex.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllMail() As List(Of Email)
        Dim cDal As New CorrespondanceDAL
        Dim l As List(Of Correspondance) = cDal.GetAllMail()
        GetAllMail = RechercheMailByCor(l)
    End Function

    Public Function RechercheMailByAss(ByVal a As Association) As List(Of Email)
        Dim cDal As New CorrespondanceDAL
        Dim l As List(Of Correspondance) = cDal.RechercheMailByAss(a)
        RechercheMailByAss = RechercheMailByCor(l)
    End Function

    Private Function RechercheMailByCor(ByVal l As List(Of Correspondance)) As List(Of Email)
        Dim i As Integer = 0
        Dim result As New List(Of Email)
        Dim temp As Email
        Dim cmd As New OleDbCommand
        cmd.Connection = connex
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        Try
            For Each c As Correspondance In l
                i = c.idCor
                cmd.CommandText = "SELECT textMsg FROM TEmail WHERE idMail = '" & i & "'"
                temp = New Email(c)
                temp.textMail = Convert.ToString(cmd.ExecuteScalar)
                result.Add(temp)
            Next
            connex.Close()
            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function SupprimerMail(ByVal e As Email) As Boolean
        Dim cDal As New CorrespondanceDAL
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TEmail WHERE idMail = '" & e.idCor & "';"
            If connex.State <> ConnectionState.Open Then
                connex.Open()
            End If
            deleteCmd.ExecuteNonQuery()
            connex.Close()
            Return cDal.SupprimerCorByMail(e)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
