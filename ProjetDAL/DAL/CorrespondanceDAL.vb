Imports ProjectDTO
Imports System.Data.OleDb

Public Class CorrespondanceDAL

    Dim requete As String = "SELECT * FROM TCorrespondance"
    Dim dAdapter As New OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterCor(ByVal c As Correspondance) As Boolean
        Dim insertCmd As New OleDbCommand
        Dim drec As String
        If c.datRec IsNot Nothing Then
            drec = c.datRec.Value.ToString("yyyy-MM-dd")
        Else
            drec = Nothing
        End If
        Dim champs As String = "(objet,datEnv,datRec,etat,estPostale,idAss)"
        Dim values As String = "(N'" & c.objet & "','" & c.datEnv.Value.ToString("yyyyMMdd") & "','" & drec & "',N'" & c.etat & "','" & c.estPos & "','" & c.ass.ID & "')"
        insertCmd.CommandText = "INSERT INTO TCorrespondance " & champs & " VALUES " & values & ";"
        insertCmd.Connection = connex
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        Try
            insertCmd.ExecuteNonQuery()
            connex.Close()
            If TypeOf c Is Email Then
                Dim eDal As New EmailDAL
                Return eDal.AjouterEmail(c, GetLastId())
            ElseIf TypeOf c Is Postale Then
                Dim pDal As New PostaleDAL
                Return pDal.AjouterPostale(c, GetLastId())
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function GetLastId() As Integer
        Dim cmd As New OleDbCommand
        cmd.CommandText = "SELECT MAX(idCor) FROM TCorrespondance"
        cmd.Connection = connex
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        GetLastId = cmd.ExecuteScalar
        connex.Close()
    End Function

    Public Function RechercheCorById(ByVal id As Integer) As Correspondance
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = "SELECT * FROM TCorrespondance WHERE idCor = '" & id & "';"
        dAdapter.Fill(dSetResultat, "TCorrespondance")
        RechercheCorById = Utile.CorDataSetToList(dSetResultat).Item(0)
    End Function

    Public Function ModifierEta(ByVal c As Correspondance, ByVal e As String) As Boolean
        Dim params(0) As OleDbParameter
        params(0) = New OleDbParameter("etat", e)
        Try
            Update("TCorrespondance", "idCor", c.idCor, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ModifierCor(ByVal c As Correspondance) As Boolean
        Dim params(4) As OleDbParameter
        params(0) = New OleDbParameter("objet", c.objet)
        params(1) = New OleDbParameter("datEnv", c.datEnv)
        params(2) = New OleDbParameter("datRec", c.datRec)
        params(3) = New OleDbParameter("etat", c.etat)
        params(4) = New OleDbParameter("idAss", c.ass.ID)
        Try
            Update("TCorrespondance", "idCor", c.idCor, params)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' EMAIL

    Public Function RechercheMailByAss(ByVal a As Association) As List(Of Correspondance)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = "SELECT * FROM TCorrespondance WHERE estPostale = 'FALSE' AND idAss = '" & a.ID & "';"
        dAdapter.Fill(dSetResultat, "TCorrespondance")
        RechercheMailByAss = Utile.CorDataSetToList(dSetResultat)
    End Function

    Public Function GetAllMail() As List(Of Correspondance)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = "SELECT * FROM TCorrespondance WHERE estPostale = 'FALSE' ;"
        dAdapter.Fill(dSetResultat, "TCorrespondance")
        GetAllMail = Utile.CorDataSetToList(dSetResultat)
    End Function

    Public Function SupprimerCorByMail(ByVal e As Email) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TCorrespondance WHERE idCor = '" & e.idCor & "';"
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

    ''' POSTALE

    Public Function RecherchePosByAss(ByVal a As Association) As List(Of Correspondance)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = "SELECT * FROM TCorrespondance WHERE estPostale = 'TRUE' AND idAss = '" & a.ID & "';"
        dAdapter.Fill(dSetResultat, "TCorrespondance")
        RecherchePosByAss = Utile.CorDataSetToList(dSetResultat)
    End Function
    
    Public Function GetAllPos() As List(Of Correspondance)
        dSetResultat.Clear()
        dAdapter.SelectCommand.CommandText = "SELECT * FROM TCorrespondance WHERE estPostale = 'TRUE' ;"
        dAdapter.Fill(dSetResultat, "TCorrespondance")
        GetAllPos = Utile.CorDataSetToList(dSetResultat)
    End Function

    Public Function SupprimerCorByPos(ByVal p As Postale) As Boolean
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TCorrespondance WHERE idCor = '" & p.idCor & "';"
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
