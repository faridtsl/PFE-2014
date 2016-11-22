Imports ProjectDTO
Imports ProjetBLL

Public Class _default
    Inherits System.Web.UI.Page

    Public s As String

    Protected Sub Page_Load() Handles Me.Load
        If Not IsPostBack Then
            s = ""
            Session("count") = 0
        End If
    End Sub

    Protected Sub inscriptionBT_Click() Handles inscriptionBT.Click
        Response.Redirect("inscription.aspx")
    End Sub

    Private Function checkLogin() As Boolean
        Dim c As New Compte
        c.login = userNameTB.Text
        c.MDP = mdpTB.Text
        Dim cBLL As New CompteBLL
        Return cBLL.Authentifier(c)
    End Function

    Protected Sub okBT_Click() Handles okBT.Click
        Dim count As Integer = Session("count")
        If count = 3 Then
            Response.Redirect("recuperation.aspx")
        Else
            If checkLogin() Then
                Dim aBll As New AssociationBLL
                Session("association") = aBll.RechercheAssByEmail(userNameTB.Text)
                Response.Redirect("main/main.aspx")
            Else
                s = "معلومات الدخول خاطئة"
                erreurLB.Text = s
                mdpTB.Text = ""
                userNameTB.Text = ""
                Session("count") = Session("count") + 1
            End If
        End If
    End Sub

End Class