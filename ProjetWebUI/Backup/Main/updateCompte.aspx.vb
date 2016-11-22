
Public Class updateCompte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        End If
    End Sub

End Class