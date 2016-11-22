Imports System.Data.OleDb
Module Globale
    Private Const ConnexionString As String = ""
    Public connex As New OleDb.OleDbConnection(ConnexionString)
    Dim cmd As New OleDbCommand()

    Friend Sub Update(ByVal table As String, ByVal col As String, ByVal id As String, ByVal params As OleDbParameter())
        Dim Parametre As OleDbParameter
        cmd.CommandText = " UPDATE " & table & " SET"
        cmd.Parameters.Clear()
        For Each Parametre In params
            If Parametre.Value <> Nothing Then
                cmd.CommandText = cmd.CommandText & " " & Parametre.ParameterName & " = ? ,"
                cmd.Parameters.Add(Parametre)
            End If
        Next
        cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1, 1)
        cmd.CommandText = cmd.CommandText & " WHERE " & col & " = '" & id & "';"
        connex.Open()
        cmd.Connection = connex
        cmd.ExecuteNonQuery()
        connex.Close()
    End Sub

End Module
