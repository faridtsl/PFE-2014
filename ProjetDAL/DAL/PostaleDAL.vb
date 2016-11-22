Imports ProjectDTO
Imports System.Data.OleDb

Public Class PostaleDAL

    Dim requete As String = "SELECT * FROM TPostale"
    Dim dAdapter As New OleDbDataAdapter(requete, connex)
    Dim dSetResultat As New DataSet

    Public Function AjouterPostale(ByVal p As Postale, ByVal id As Integer) As Boolean
        Dim insertCmd As New OleDbCommand
        Dim champs As String = "(idPos,NBO,cheminPDF,imgSupp)"
        Dim values As String = "('" & id & "','" & p.NBO & "','" & p.cheminPDF & "','" & p.imgSupp & "')"
        insertCmd.Connection = connex
        insertCmd.CommandText = "INSERT INTO TPostale " & champs & " VALUES " & values & ";"
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

    Public Function GetAllPostale() As List(Of Postale)
        Try
            Dim cDal As New CorrespondanceDAL
            GetAllPostale = RecherchePosByCor(cDal.GetAllPos())
        Catch ex As Exception
            Return New List(Of Postale)
        End Try
    End Function

    Public Function RecherchePosByAss(ByVal a As Association) As List(Of Postale)
        Dim cDal As New CorrespondanceDAL
        RecherchePosByAss = RecherchePosByCor(cDal.RecherchePosByAss(a))
    End Function

    Public Function RecherchePosByNBO(ByVal nbo As String) As Postale
        Dim cmd As New OleDbCommand
        cmd.CommandText = "SELECT idPos FROM TPostale WHERE NBO = '" & nbo & "' ;"
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        Try
            cmd.Connection = connex
            Dim i = cmd.ExecuteScalar
            connex.Close()
            Dim cDal As New CorrespondanceDAL
            Dim l = New List(Of Correspondance)
            If i IsNot Nothing Then
                l.Add(cDal.RechercheCorById(i))
                Return RecherchePosByCor(l).Item(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function RecherchePosByCor(ByVal l As List(Of Correspondance)) As List(Of Postale)
        Dim i As Integer = 0
        Dim result As New List(Of Postale)
        Dim temp As Postale
        Dim cmd As New OleDbCommand
        cmd.Connection = connex
        If connex.State <> ConnectionState.Open Then
            connex.Open()
        End If
        Try
            For Each c As Correspondance In l
                i = c.idCor
                cmd.CommandText = "SELECT NBO,cheminPDF,imgSupp FROM TPostale WHERE idPos = '" & i & "'"
                temp = New Postale(c)
                dAdapter.SelectCommand = cmd
                dAdapter.Fill(dSetResultat, "TPostale")
                Dim dt As DataTable = dSetResultat.Tables("TPostale")
                For Each r As DataRow In dt.Rows
                    temp.NBO = r.Field(Of String)("NBO")
                    temp.cheminPDF = r.Field(Of String)("cheminPDF")
                    temp.imgSupp = r.Field(Of String)("imgSupp")
                Next
                result.Add(temp)
            Next
            connex.Close()
            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function SupprimerPos(ByVal p As Postale) As Boolean
        Dim cDal As New CorrespondanceDAL
        Try
            Dim deleteCmd As New OleDbCommand()
            deleteCmd.Connection = connex
            deleteCmd.CommandText = "DELETE FROM TPostale WHERE idPos = '" & p.idCor & "';"
            If connex.State <> ConnectionState.Open Then
                connex.Open()
            End If
            deleteCmd.ExecuteNonQuery()
            connex.Close()
            Return cDal.SupprimerCorByPos(p)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
