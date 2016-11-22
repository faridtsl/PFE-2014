Imports ProjectDTO
Imports ProjetBLL

Public Class envoyerCor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("association") Is Nothing) Then
            Response.Redirect("../default.aspx")
        End If
    End Sub

    Protected Sub sendBT_Click() Handles sendBT.Click
        If Not Equals(textCorTB.Text, "") And Not Equals(objTB.Text, "") Then
            Dim e = creerMail()
            If New EmailBLL().AjouterMail(e) Then
                errLB.Text = "تم الارسال بنجاح"
            Else
                errLB.Text = "لم يتم الارسال المرجوا اعادة المحاولة"
            End If
        End If
    End Sub

    Private Function creerMail() As Email
        Dim e As New Email
        e.ass = Session("association")
        e.datEnv = Date.Now.Date
        e.datRec = Date.Now.Date
        e.estPos = False
        e.etat = "في الطريق"
        e.objet = objTB.Text
        e.textMail = textCorTB.Text
        Return e
    End Function

End Class