Imports ProjectDTO
Imports ProjetBLL

Public Class main
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        Else
            Dim a = Session("association")
            nomLB.Text = a.nomAss
        End If
    End Sub

End Class