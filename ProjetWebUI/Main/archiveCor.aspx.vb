Imports ProjectDTO
Imports ProjetBLL

Public Class archiveCor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        Else
            Dim a As Association = Session("association")
            Dim l As New List(Of Correspondance)
            l.AddRange(New PostaleBLL().RecherchePosByAss(a))
            l.AddRange(New EmailBLL().RechercheMailByAss(a))
            corGV.DataSource = l
            corGV.DataBind()
        End If
    End Sub

End Class